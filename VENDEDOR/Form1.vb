Imports System.Data.SqlClient
Public Class Vendedor
    Private Sub Vendedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conectar()
        mostrardatos()
    End Sub
    Sub mostrardatos()
        Dim dat As New SqlDataAdapter(" select * from vendedor ", con)

        Dim d As New DataSet
        dat.Fill(d)
        DataGridView1.DataSource = d.Tables(0)
        DataGridView1.Columns("dni").HeaderText = "DNI"
        DataGridView1.Columns("nombre").HeaderText = "Nombre"
        DataGridView1.Columns("dirección").HeaderText = "Dirección"
        DataGridView1.Columns("teléfono").HeaderText = "Teléfono"
    End Sub

    Private Sub cmdInsetar_Click(sender As Object, e As EventArgs) Handles cmdInsetar.Click
        Try
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = " insert into vendedor (dni, nombre, direccion, telefono) values ('" & txtDNI.Text & "','" & txtNombre.Text & "','" & txtDireccion.Text & "'," & txtxTelefono.Text & " ) "
            cmd.Parameters.AddWithValue("@nombre", txtNombre.Text)
            cmd.Parameters.AddWithValue("@direccion", txtDireccion.Text)
            cmd.Parameters.AddWithValue("@dni", txtDNI.Text)
            cmd.Parameters.AddWithValue("@telefono", txtxTelefono.Text)

            cmd.ExecuteNonQuery()
            Dim fila As Integer
            If fila > 0 Then
                MessageBox.Show("Datos guardados")
            End If
            mostrardatos()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cmdActualizar_Click(sender As Object, e As EventArgs) Handles cmdActualizar.Click
        Try
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = " update vendedor set nombre='" & txtNombre.Text & "', dirección='" & txtDireccion.Text & "', teléfono=" & txtxTelefono.Text & " dni=" & txtDNI.Text & ""
            cmd.ExecuteNonQuery()
            MessageBox.Show("Datos guardados")
            mostrardatos()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cmdEliminar_Click(sender As Object, e As EventArgs) Handles cmdEliminar.Click
        Dim cmd As New SqlCommand
        cmd.Connection = con
        cmd.CommandText = "delete from vendedor where dni= '" & txtDNI.Text & "'"
        cmd.ExecuteNonQuery()
        MessageBox.Show("Datos eliminados")
        mostrardatos()
    End Sub

    Private Sub cmdLimpiar_Click(sender As Object, e As EventArgs) Handles cmdLimpiar.Click
        txtDNI.Clear()
        txtNombre.Clear()
        txtDireccion.Clear()
        txtxTelefono.Clear()
    End Sub

    Private Sub cmdSalir_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        If DataGridView1.Rows.Count > 0 Then


            If DataGridView1.SelectedRows.Count > 0 Then
                txtDNI.Text = DataGridView1.SelectedRows(0).Cells("dni").Value
                txtNombre.Text = DataGridView1.SelectedRows(0).Cells("nombre").Value
                txtDireccion.Text = DataGridView1.SelectedRows(0).Cells("dirección").Value
                txtxTelefono.Text = DataGridView1.SelectedRows(0).Cells("teléfono").Value
            End If
        End If
    End Sub
End Class
