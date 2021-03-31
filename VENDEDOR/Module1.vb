Imports System.Data.SqlClient
Module Module1
    Public con As New SqlConnection
    Public Sub conectar()
        con.ConnectionString = "Data Source=DESKTOP-O5E78PF\SQLEXPRESS;Initial Catalog=prueba;Integrated Security=True"
        con.Open()
    End Sub
End Module
