Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Data.SqlClient
Public Class Form1

    Dim CN As SqlConnection
    Dim CMD As SqlCommand

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CN = New SqlConnection("data source=LAPTOP-S4MP155H;integrated security=true;initial catalog=camilton")

        CMD = New SqlCommand
        CMD.Connection = CN

        CN.close()
    End Sub

    Private Sub TabEscrCli_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabEscrCli.SelectedIndexChanged
        CMD.CommandText = "SELECT * FROM dbo.getClients();"
        CN.Open()

        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        list_cli.Items.Clear()
        getCli(RDR)

        CN.Close()
    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles txt_insName.TextChanged

    End Sub

    Private Sub btn_insCli_Click(sender As Object, e As EventArgs) Handles btn_insCli.Click

        Dim C As New Cliente
        C.CLienteID = txt_insID.Text
        C.Nome = txt_insName.Text
        C.Contacto = txt_insCont.Text
        C.Endereco = txt_insEnd.Text
        list_add.Items.Add(C)

        CMD.CommandText = "exec dbo.insCli 
                            @clienteID        = @id       ,
                            @nome             = @nom      ,
                            @contacto         = @cont     ,
                            @endereco          = @end  "
        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@id", C.CLienteID)
        CMD.Parameters.AddWithValue("@nom", C.Nome)
        CMD.Parameters.AddWithValue("@cont", C.Contacto)
        CMD.Parameters.AddWithValue("@end", C.Endereco)
        CN.Open()
        Try
            CMD.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Failed to update contact in database. " & vbCrLf & "ERROR MESSAGE: " & vbCrLf & ex.Message)
        Finally
            CN.Close()
        End Try
        CN.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_escrSearch.Click

        If String.IsNullOrEmpty(txt_idcli.Text) = False And String.IsNullOrEmpty(txt_cliNome.Text) = False And String.IsNullOrEmpty(txt_cliCont.Text) = False Then

            CMD.CommandText = "SELECT * FROM dbo.getClientsIdContName(" + txt_idcli.Text + ", " + txt_cliCont.Text + ", '" + txt_cliNome.Text + "');"
            CN.Open()

            Dim RDR As SqlDataReader
            RDR = CMD.ExecuteReader
            list_cli.Items.Clear()
            getCli(RDR)

        ElseIf String.IsNullOrEmpty(txt_idcli.Text) = False And String.IsNullOrEmpty(txt_cliNome.Text) = False And String.IsNullOrEmpty(txt_cliCont.Text) Then

            CMD.CommandText = "SELECT * FROM dbo.getClientsIdName(" + txt_idcli.Text + ", '" + txt_cliNome.Text + "');"
            CN.Open()

            Dim RDR As SqlDataReader
            RDR = CMD.ExecuteReader
            list_cli.Items.Clear()
            getCli(RDR)

        ElseIf String.IsNullOrEmpty(txt_idcli.Text) = False And String.IsNullOrEmpty(txt_cliNome.Text) And String.IsNullOrEmpty(txt_cliCont.Text) = False Then
            CMD.CommandText = "SELECT * FROM dbo.getClientsIdCont(" + txt_idcli.Text + ", " + txt_cliCont.Text + ");"
            CN.Open()

            Dim RDR As SqlDataReader
            RDR = CMD.ExecuteReader
            list_cli.Items.Clear()
            getCli(RDR)

        ElseIf String.IsNullOrEmpty(txt_idcli.Text) And String.IsNullOrEmpty(txt_cliNome.Text) = False And String.IsNullOrEmpty(txt_cliCont.Text) = False Then
            CMD.CommandText = "SELECT * FROM dbo.getClientsContName(" + txt_cliCont.Text + ", '" + txt_cliNome.Text + "');"
            CN.Open()

            Dim RDR As SqlDataReader
            RDR = CMD.ExecuteReader
            list_cli.Items.Clear()
            getCli(RDR)

        ElseIf String.IsNullOrEmpty(txt_idcli.Text) = False And String.IsNullOrEmpty(txt_cliNome.Text) And String.IsNullOrEmpty(txt_cliCont.Text) Then
            CMD.CommandText = "SELECT * FROM dbo.getClientsId(" + txt_idcli.Text + ");"
            CN.Open()

            Dim RDR As SqlDataReader
            RDR = CMD.ExecuteReader
            list_cli.Items.Clear()
            getCli(RDR)

        ElseIf String.IsNullOrEmpty(txt_idcli.Text) And String.IsNullOrEmpty(txt_cliNome.Text) = False And String.IsNullOrEmpty(txt_cliCont.Text) Then
            CMD.CommandText = "SELECT * FROM dbo.getClientsName( '" + txt_cliNome.Text + "');"
            CN.Open()

            Dim RDR As SqlDataReader
            RDR = CMD.ExecuteReader
            list_cli.Items.Clear()
            getCli(RDR)

        ElseIf String.IsNullOrEmpty(txt_idcli.Text) And String.IsNullOrEmpty(txt_cliNome.Text) And String.IsNullOrEmpty(txt_cliCont.Text) = False Then
            CMD.CommandText = "SELECT * FROM dbo.getClientsCont(" + txt_cliCont.Text + ");"
            CN.Open()

            Dim RDR As SqlDataReader
            RDR = CMD.ExecuteReader
            list_cli.Items.Clear()
            getCli(RDR)

        Else
            CMD.CommandText = "SELECT * FROM dbo.getClients();"
            CN.Open()

            Dim RDR As SqlDataReader
            RDR = CMD.ExecuteReader
            list_cli.Items.Clear()
            getCli(RDR)

        End If

        CN.Close()
    End Sub

    Function getCli(ByVal RDR As SqlDataReader)

        While RDR.Read
            Dim C As New Cliente
            C.CLienteID = RDR.Item("clienteID")
            C.Nome = RDR.Item("nome")
            C.Contacto = RDR.Item("contacto")
            C.Endereco = RDR.Item("endereco")
            list_cli.Items.Add(C)
        End While

        getCli = 0

    End Function
End Class
