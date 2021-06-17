Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Data.SqlClient
Public Class Pesquisa
    Dim CN As SqlConnection
    Dim CMD As SqlCommand
    Private Sub Pesquisa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CN = New SqlConnection("data source=DESKTOP-JR2SDSQ\SQLEXPRESS; integrated security=true;initial catalog=camilton")

        CMD = New SqlCommand
        CMD.Connection = CN

        CN.close()
    End Sub

    Private Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        CMD.CommandText = "SELECT * FROM Producao"
        CN.Open()
        Dim nrnota As String
        nrnota = txt_nota.Text

        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        lista.Items.Clear()
        While RDR.Read
            If nrnota = RDR.Item("nota") Then
                lista.Items.Add(RDR.Item("nota"))
            End If
        End While





    End Sub

End Class