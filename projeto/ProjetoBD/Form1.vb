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

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.Click
        CMD = CN.CreateCommand
        CMD.CommandText = "SELECT nota FROM camilton.getNotas();"
        CN.Open()

        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        ComboBox1.Items.Clear()
        While RDR.Read
            ComboBox1.Items.Add(RDR.Item("nota"))
        End While

        CN.Close()

    End Sub

    Private Sub TabEscrCli_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabEscrCli.SelectedIndexChanged

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.Click

        CMD = CN.CreateCommand
        CMD.CommandText = "SELECT * FROM camilton.getSeccao();"
        CN.Open()

        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        ComboBox2.Items.Clear()
        While RDR.Read
            ComboBox2.Items.Add(RDR.Item("seccao"))
        End While

        CN.Close()
    End Sub

    Private Sub AdiconarSeccao_Click(sender As Object, e As EventArgs) Handles AdiconarSeccao.Click
        CMD = CN.CreateCommand
        CMD.CommandText = "exec camilton.insSeccao 
                            @nota             = @nota      ,
                            @dataini         = @ini     ,
                            @datafim          = @fim,
                            @FK_TPSeccao        =@tipo"
        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@nota", ComboBox1.Text)
        CMD.Parameters.AddWithValue("@ini", DateTimePicker1.Value)
        CMD.Parameters.AddWithValue("@fim", DateTimePicker2.Value)
        CMD.Parameters.AddWithValue("@tipo", ComboBox2.Text)
        CN.Open()
        Try
            CMD.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Failed to update contact in database. " & vbCrLf & "ERROR MESSAGE: " & vbCrLf & ex.Message)
        Finally
            CN.Close()
            MsgBox("ACEITE", 0, "Valor introduzido!")
        End Try
        CN.Close()
    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub ComboProd_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboProd.Click
        CMD = CN.CreateCommand
        CMD.CommandText = "SELECT * FROM camilton.getProdutosComEncomenda();"
        CN.Open()

        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        ComboProd.Items.Clear()
        While RDR.Read
            ComboProd.Items.Add(RDR.Item("Ref Produto"))
        End While

        CN.Close()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Btn_PesqMat.Click
        CMD = CN.CreateCommand
        CMD.CommandText = "SELECT * FROM ReferenciasPorUmProduto(" + ComboProd.Text + ");"
        CN.Open()

        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        List_Mat.Items.Clear()

        While RDR.Read
            List_Mat.Items.Add(String.Format("{0} | {1} | {2} ", RDR.Item("material"), RDR.Item("referencia"), RDR.Item("quantidade")))
        End While
        CN.Close()
    End Sub

    Private Sub btn_Pele_Click(sender As Object, e As EventArgs) Handles btn_Pele.Click
        CMD = CN.CreateCommand
        CMD.CommandText = "exec camilton.insPele 
                            @ref             = @ref      ,
                            @cor         = @cor "
        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@ref", txt_refPele.Text)
        CMD.Parameters.AddWithValue("@cor", txt_corPele.Text)

        CN.Open()
        Try
            CMD.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Failed to update contact in database. " & vbCrLf & "ERROR MESSAGE: " & vbCrLf & ex.Message)
        Finally
            CN.Close()
            MsgBox("ACEITE", 0, "Valor introduzido!")
        End Try
        CN.Close()
    End Sub

    Private Sub btn_Solas_Click(sender As Object, e As EventArgs) Handles btn_Solas.Click
        CMD = CN.CreateCommand
        CMD.CommandText = "exec camilton.insSolas
                            @ref             = @ref      ,
                            @size         = @size "
        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@ref", txt_refSola.Text)
        CMD.Parameters.AddWithValue("@size", txt_tamanhoSola.Text)

        CN.Open()
        Try
            CMD.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Failed to update contact in database. " & vbCrLf & "ERROR MESSAGE: " & vbCrLf & ex.Message)
        Finally
            CN.Close()
            MsgBox("ACEITE", 0, "Valor introduzido!")
        End Try
        CN.Close()
    End Sub

    Private Sub btn_Palmilhas_Click(sender As Object, e As EventArgs) Handles btn_Palmilhas.Click
        CMD = CN.CreateCommand
        CMD.CommandText = "exec camilton.insPalmilhas
                            @ref             = @ref      ,
                            @size         = @size "
        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@ref", txt_refPalmilhas.Text)
        CMD.Parameters.AddWithValue("@size", txt_tamanhoPalmilhas.Text)

        CN.Open()
        Try
            CMD.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Failed to update contact in database. " & vbCrLf & "ERROR MESSAGE: " & vbCrLf & ex.Message)
        Finally
            CN.Close()
            MsgBox("ACEITE", 0, "Valor introduzido!")
        End Try
        CN.Close()
    End Sub

    Private Sub btn_Aplicacoes_Click(sender As Object, e As EventArgs) Handles btn_Aplicacoes.Click
        CMD = CN.CreateCommand
        CMD.CommandText = "exec camilton.insSolas
                            @ref             = @ref      ,
                            @tipo         = @tipo"
        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@ref", txt_refAplicacoes.Text)
        CMD.Parameters.AddWithValue("@size", txt_tipoAplicacoes.Text)

        CN.Open()
        Try
            CMD.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Failed to update contact in database. " & vbCrLf & "ERROR MESSAGE: " & vbCrLf & ex.Message)
        Finally
            CN.Close()
            MsgBox("ACEITE", 0, "Valor introduzido!")
        End Try
        CN.Close()
    End Sub

End Class
