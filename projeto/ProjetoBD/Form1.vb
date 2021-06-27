Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Data.SqlClient
Public Class Form1

    Dim CN As SqlConnection
    Dim CMD As SqlCommand

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CN = New SqlConnection("Data Source = tcp:mednat.ieeta.pt\SQLSERVER,8101 ;" + "Initial Catalog = p3g6; uid = p3g6;" + "password = Arroz-tomate1")
        Try
            CN.Open()
            If CN.State = ConnectionState.Open Then
                MsgBox("Successful connection to database " + CN.Database + " on the " + CN.DataSource + " server", MsgBoxStyle.OkOnly, "Connection Test")
            End If
        Catch ex As Exception
            MsgBox("FAILED TO OPEN CONNECTION TO DATABASE DUE TO THE FOLLOWING ERROR" + vbCrLf + ex.Message, MsgBoxStyle.Critical, "Connection Test")
        End Try
        If CN.State = ConnectionState.Open Then CN.Close()
    End Sub

    Private Sub TabEscr_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabEscr.SelectedIndexChanged
        CMD = CN.CreateCommand
        CMD.CommandText = "SELECT * FROM camilton.getClients();"
        CN.Open()

        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        list_cli.Items.Clear()
        encCB_clients.Items.Clear()
        encCB_prod.Items.Clear()
        While RDR.Read
            Dim C As New Cliente
            C.CLienteID = RDR.Item("clienteID")
            C.Nome = RDR.Item("nome")
            C.Contacto = RDR.Item("contacto")
            C.Endereco = RDR.Item("endereco")
            list_cli.Items.Add(C)
            encCB_clients.Items.Add(RDR.Item("nome"))
        End While

        CN.Close()

    End Sub

    Private Sub btn_insCli_Click(sender As Object, e As EventArgs) Handles btn_insCli.Click

        Dim C As New Cliente
        C.Nome = txt_insName.Text
        C.Contacto = txt_insCont.Text
        C.Endereco = txt_insEnd.Text
        list_add.Items.Add(C)

        CMD = CN.CreateCommand
        CMD.CommandText = "exec camilton.insCli 
                            @nome             = @nom      ,
                            @contacto         = @cont     ,
                            @endereco          = @end  "
        CMD.Parameters.Clear()
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
            CMD = CN.CreateCommand
            CMD.CommandText = "SELECT * FROM camilton.getClientsIdContName(" + txt_idcli.Text + ", " + txt_cliCont.Text + ", '" + txt_cliNome.Text + "');"
            CN.Open()

            Dim RDR As SqlDataReader
            RDR = CMD.ExecuteReader
            list_cli.Items.Clear()
            getCli(RDR)

        ElseIf String.IsNullOrEmpty(txt_idcli.Text) = False And String.IsNullOrEmpty(txt_cliNome.Text) = False And String.IsNullOrEmpty(txt_cliCont.Text) Then
            CMD = CN.CreateCommand
            CMD.CommandText = "SELECT * FROM camilton.getClientsIdName(" + txt_idcli.Text + ", '" + txt_cliNome.Text + "');"
            CN.Open()

            Dim RDR As SqlDataReader
            RDR = CMD.ExecuteReader
            list_cli.Items.Clear()
            getCli(RDR)

        ElseIf String.IsNullOrEmpty(txt_idcli.Text) = False And String.IsNullOrEmpty(txt_cliNome.Text) And String.IsNullOrEmpty(txt_cliCont.Text) = False Then
            CMD = CN.CreateCommand
            CMD.CommandText = "SELECT * FROM camilton.getClientsIdCont(" + txt_idcli.Text + ", " + txt_cliCont.Text + ");"
            CN.Open()

            Dim RDR As SqlDataReader
            RDR = CMD.ExecuteReader
            list_cli.Items.Clear()
            getCli(RDR)

        ElseIf String.IsNullOrEmpty(txt_idcli.Text) And String.IsNullOrEmpty(txt_cliNome.Text) = False And String.IsNullOrEmpty(txt_cliCont.Text) = False Then
            CMD = CN.CreateCommand
            CMD.CommandText = "SELECT * FROM camilton.getClientsContName(" + txt_cliCont.Text + ", '" + txt_cliNome.Text + "');"
            CN.Open()

            Dim RDR As SqlDataReader
            RDR = CMD.ExecuteReader
            list_cli.Items.Clear()
            getCli(RDR)

        ElseIf String.IsNullOrEmpty(txt_idcli.Text) = False And String.IsNullOrEmpty(txt_cliNome.Text) And String.IsNullOrEmpty(txt_cliCont.Text) Then
            CMD = CN.CreateCommand
            CMD.CommandText = "SELECT * FROM camilton.getClientsId(" + txt_idcli.Text + ");"
            CN.Open()

            Dim RDR As SqlDataReader
            RDR = CMD.ExecuteReader
            list_cli.Items.Clear()
            getCli(RDR)

        ElseIf String.IsNullOrEmpty(txt_idcli.Text) And String.IsNullOrEmpty(txt_cliNome.Text) = False And String.IsNullOrEmpty(txt_cliCont.Text) Then
            CMD = CN.CreateCommand
            CMD.CommandText = "SELECT * FROM camilton.getClientsName( '" + txt_cliNome.Text + "');"
            CN.Open()

            Dim RDR As SqlDataReader
            RDR = CMD.ExecuteReader
            list_cli.Items.Clear()
            getCli(RDR)

        ElseIf String.IsNullOrEmpty(txt_idcli.Text) And String.IsNullOrEmpty(txt_cliNome.Text) And String.IsNullOrEmpty(txt_cliCont.Text) = False Then
            CMD = CN.CreateCommand
            CMD.CommandText = "SELECT * FROM camilton.getClientsCont(" + txt_cliCont.Text + ");"
            CN.Open()

            Dim RDR As SqlDataReader
            RDR = CMD.ExecuteReader
            list_cli.Items.Clear()
            getCli(RDR)

        Else
            CMD = CN.CreateCommand
            CMD.CommandText = "SELECT * FROM camilton.getClients();"
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

    Private Sub tabEscrEnc_add_Click(sender As Object, e As EventArgs) Handles tabEscrEnc_add.Click
        CMD = CN.CreateCommand
        CMD.CommandText = "SELECT nome FROM camilton.getClients();"
        CN.Open()

        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader

        encCB_clients.Items.Clear()
        While RDR.Read

            encCB_clients.Items.Add(RDR.Item("nome"))
        End While

        CN.Close()

    End Sub

End Class
