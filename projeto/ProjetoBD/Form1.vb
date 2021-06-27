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

        Update()
    End Sub

    Private Overloads Function Update()
        CMD = CN.CreateCommand
        CMD.CommandText = "SELECT * FROM camilton.getClients();SELECT * FROM camilton.getProdutos();"
        Dim Aux As SqlCommand = CN.CreateCommand
        Aux.CommandText = "SELECT * FROM camilton.getProdutos();"
        Dim Enc As SqlCommand = CN.CreateCommand
        Enc.CommandText = "SELECT * FROM camilton.getEncomendaComCliente();"
        CN.Open()

        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        list_cli.Items.Clear()
        encCB_clients.Items.Clear()
        While RDR.Read
            Dim C As New Cliente
            C.CLienteID = RDR.Item("clienteID")
            C.Nome = RDR.Item("nome")
            C.Contacto = RDR.Item("contacto")
            C.Endereco = RDR.Item("endereco")
            list_cli.Items.Add(C)
            encCB_clients.Items.Add(RDR.Item("nome"))

        End While

        RDR.Close()

        Dim RDR2 As SqlDataReader
        RDR2 = Aux.ExecuteReader
        encCB_prod.Items.Clear()
        While RDR2.Read
            encCB_prod.Items.Add(RDR2.Item("prodNome"))
        End While

        RDR2.Close()


        Dim RDRENC As SqlDataReader
        RDRENC = Enc.ExecuteReader
        list_Enc.Items.Clear()
        While RDRENC.Read
            Dim E As New Encomenda
            E.ID = RDRENC.Item("id")
            E.CliNome = RDRENC.Item("cliNome")
            E.prodNome = RDRENC.Item("prodNome")
            E.quant = RDRENC.Item("quant")
            E.price = RDRENC.Item("preco")
            E.data = RDRENC.Item("data")
            list_Enc.Items.Add(E)
        End While

        CN.Close()
        Return 0
    End Function


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
            MsgBox("ACEITE", 0, "Valor introduzido!")
            CN.Close()
        End Try
        Update()
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
            Update()

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

    Private Sub btn_addEnc_Click(sender As Object, e As EventArgs) Handles btn_addEnc.Click

        CMD = CN.CreateCommand
        CMD.CommandText = "exec camilton.insEnc 
                            @quantidade       = @quant    ,
                            @envio            = @env      ,
                            @name             = @nom      ,
                            @prodName         = @prodNom  "
        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@quant", txt_encQuant.Text)
        CMD.Parameters.AddWithValue("@env", data_EncEnv.Value)
        CMD.Parameters.AddWithValue("@nom", encCB_clients.SelectedItem.ToString())
        CMD.Parameters.AddWithValue("@prodNom", encCB_prod.SelectedItem.ToString())
        CN.Open()
        Try
            CMD.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Failed to update contact in database. " & vbCrLf & "ERROR MESSAGE: " & vbCrLf & ex.Message)
        Finally
            MsgBox("ACEITE", 0, "Valor introduzido!")
            CN.Close()
        End Try
        Update()
        CN.Close()
    End Sub

    Private Sub btn_checkRem_Click(sender As Object, e As EventArgs) Handles btn_checkRem.Click
        CMD = CN.CreateCommand
        CMD.CommandText = "SELECT * FROM camilton.getEncomenda(" + txt_IDEnc.Text + ");"
        CN.Open()

        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader

        list_checkEnc.Items.Clear()
        While RDR.Read
            list_checkEnc.Items.Add("ID: " + RDR.Item("EncomenID").ToString() + ", Cliente: " + RDR.Item("cliente").ToString() + ", Produto: " + RDR.Item("produto").ToString() + ", Quantidade: " + RDR.Item("quantidade").ToString() + ", Preco total: " + RDR.Item("preco").ToString())
        End While

        CN.Close()
    End Sub

    Private Sub btn_RemoveEnc_Click(sender As Object, e As EventArgs) Handles btn_RemoveEnc.Click
        CMD = CN.CreateCommand
        CMD.CommandText = "exec camilton.delEnc " + txt_IDEnc.Text + ";"
        CN.Open()

        Try
            CMD.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Failed to update contact in database. " & vbCrLf & "ERROR MESSAGE: " & vbCrLf & ex.Message)
        Finally
            MsgBox("ACEITE", 0, "Valor Removido!")
            list_checkEnc.Items.Clear()

        End Try

        CN.Close()
        Update()
    End Sub


End Class
