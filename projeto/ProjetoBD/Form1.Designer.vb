<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.tab1 = New System.Windows.Forms.TabControl()
        Me.tab_escr = New System.Windows.Forms.TabPage()
        Me.TabEscr = New System.Windows.Forms.TabControl()
        Me.tabEscr_cli = New System.Windows.Forms.TabPage()
        Me.TabEscrCli = New System.Windows.Forms.TabControl()
        Me.tabEscrCli_search = New System.Windows.Forms.TabPage()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btn_escrSearch = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txt_cliCont = New System.Windows.Forms.TextBox()
        Me.txt_cliNome = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_idcli = New System.Windows.Forms.TextBox()
        Me.list_cli = New System.Windows.Forms.ListBox()
        Me.tabEscr_ins = New System.Windows.Forms.TabPage()
        Me.list_add = New System.Windows.Forms.ListBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btn_insCli = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_insName = New System.Windows.Forms.TextBox()
        Me.txt_insCont = New System.Windows.Forms.TextBox()
        Me.txt_insEnd = New System.Windows.Forms.TextBox()
        Me.tabEscr_del = New System.Windows.Forms.TabPage()
        Me.tabEscrEnc = New System.Windows.Forms.TabPage()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.tabEscrEnc_add = New System.Windows.Forms.TabPage()
        Me.encCB_clients = New System.Windows.Forms.ComboBox()
        Me.tabEscrEnc_del = New System.Windows.Forms.TabPage()
        Me.tab_fab = New System.Windows.Forms.TabPage()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.encCB_prod = New System.Windows.Forms.ComboBox()
        Me.tab1.SuspendLayout()
        Me.tab_escr.SuspendLayout()
        Me.TabEscr.SuspendLayout()
        Me.tabEscr_cli.SuspendLayout()
        Me.TabEscrCli.SuspendLayout()
        Me.tabEscrCli_search.SuspendLayout()
        Me.tabEscr_ins.SuspendLayout()
        Me.tabEscrEnc.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.tabEscrEnc_add.SuspendLayout()
        Me.tab_fab.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tab1
        '
        Me.tab1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.tab1.Controls.Add(Me.tab_escr)
        Me.tab1.Controls.Add(Me.tab_fab)
        Me.tab1.Location = New System.Drawing.Point(0, 2)
        Me.tab1.Name = "tab1"
        Me.tab1.SelectedIndex = 0
        Me.tab1.Size = New System.Drawing.Size(832, 526)
        Me.tab1.TabIndex = 2
        '
        'tab_escr
        '
        Me.tab_escr.Controls.Add(Me.TabEscr)
        Me.tab_escr.Location = New System.Drawing.Point(4, 27)
        Me.tab_escr.Name = "tab_escr"
        Me.tab_escr.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_escr.Size = New System.Drawing.Size(824, 495)
        Me.tab_escr.TabIndex = 0
        Me.tab_escr.Text = "Escritório"
        Me.tab_escr.UseVisualStyleBackColor = True
        '
        'TabEscr
        '
        Me.TabEscr.Controls.Add(Me.tabEscr_cli)
        Me.TabEscr.Controls.Add(Me.tabEscrEnc)
        Me.TabEscr.Location = New System.Drawing.Point(-4, 3)
        Me.TabEscr.Name = "TabEscr"
        Me.TabEscr.SelectedIndex = 0
        Me.TabEscr.Size = New System.Drawing.Size(832, 495)
        Me.TabEscr.TabIndex = 0
        '
        'tabEscr_cli
        '
        Me.tabEscr_cli.Controls.Add(Me.TabEscrCli)
        Me.tabEscr_cli.Location = New System.Drawing.Point(4, 24)
        Me.tabEscr_cli.Name = "tabEscr_cli"
        Me.tabEscr_cli.Padding = New System.Windows.Forms.Padding(3)
        Me.tabEscr_cli.Size = New System.Drawing.Size(824, 467)
        Me.tabEscr_cli.TabIndex = 0
        Me.tabEscr_cli.Text = "Cliente"
        Me.tabEscr_cli.UseVisualStyleBackColor = True
        '
        'TabEscrCli
        '
        Me.TabEscrCli.Controls.Add(Me.tabEscrCli_search)
        Me.TabEscrCli.Controls.Add(Me.tabEscr_ins)
        Me.TabEscrCli.Controls.Add(Me.tabEscr_del)
        Me.TabEscrCli.Location = New System.Drawing.Point(-6, 3)
        Me.TabEscrCli.Name = "TabEscrCli"
        Me.TabEscrCli.SelectedIndex = 0
        Me.TabEscrCli.Size = New System.Drawing.Size(832, 464)
        Me.TabEscrCli.TabIndex = 0
        '
        'tabEscrCli_search
        '
        Me.tabEscrCli_search.Controls.Add(Me.Label10)
        Me.tabEscrCli_search.Controls.Add(Me.btn_escrSearch)
        Me.tabEscrCli_search.Controls.Add(Me.Label9)
        Me.tabEscrCli_search.Controls.Add(Me.Label8)
        Me.tabEscrCli_search.Controls.Add(Me.txt_cliCont)
        Me.tabEscrCli_search.Controls.Add(Me.txt_cliNome)
        Me.tabEscrCli_search.Controls.Add(Me.Label2)
        Me.tabEscrCli_search.Controls.Add(Me.txt_idcli)
        Me.tabEscrCli_search.Controls.Add(Me.list_cli)
        Me.tabEscrCli_search.Location = New System.Drawing.Point(4, 24)
        Me.tabEscrCli_search.Name = "tabEscrCli_search"
        Me.tabEscrCli_search.Padding = New System.Windows.Forms.Padding(3)
        Me.tabEscrCli_search.Size = New System.Drawing.Size(824, 436)
        Me.tabEscrCli_search.TabIndex = 0
        Me.tabEscrCli_search.Text = "Pesquisa"
        Me.tabEscrCli_search.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(657, 14)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(39, 15)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "Filtros"
        '
        'btn_escrSearch
        '
        Me.btn_escrSearch.Location = New System.Drawing.Point(574, 319)
        Me.btn_escrSearch.Name = "btn_escrSearch"
        Me.btn_escrSearch.Size = New System.Drawing.Size(99, 25)
        Me.btn_escrSearch.TabIndex = 7
        Me.btn_escrSearch.Text = "Pesquisar"
        Me.btn_escrSearch.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(574, 219)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 15)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Contacto"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(574, 129)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 15)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Nome"
        '
        'txt_cliCont
        '
        Me.txt_cliCont.Location = New System.Drawing.Point(573, 240)
        Me.txt_cliCont.Name = "txt_cliCont"
        Me.txt_cliCont.Size = New System.Drawing.Size(100, 23)
        Me.txt_cliCont.TabIndex = 4
        '
        'txt_cliNome
        '
        Me.txt_cliNome.Location = New System.Drawing.Point(573, 150)
        Me.txt_cliNome.Name = "txt_cliNome"
        Me.txt_cliNome.Size = New System.Drawing.Size(100, 23)
        Me.txt_cliNome.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(573, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "ID do Cliente"
        '
        'txt_idcli
        '
        Me.txt_idcli.Location = New System.Drawing.Point(573, 60)
        Me.txt_idcli.Name = "txt_idcli"
        Me.txt_idcli.Size = New System.Drawing.Size(100, 23)
        Me.txt_idcli.TabIndex = 1
        '
        'list_cli
        '
        Me.list_cli.FormattingEnabled = True
        Me.list_cli.ItemHeight = 15
        Me.list_cli.Location = New System.Drawing.Point(8, 27)
        Me.list_cli.Name = "list_cli"
        Me.list_cli.Size = New System.Drawing.Size(559, 394)
        Me.list_cli.TabIndex = 0
        '
        'tabEscr_ins
        '
        Me.tabEscr_ins.Controls.Add(Me.list_add)
        Me.tabEscr_ins.Controls.Add(Me.Label7)
        Me.tabEscr_ins.Controls.Add(Me.btn_insCli)
        Me.tabEscr_ins.Controls.Add(Me.Label6)
        Me.tabEscr_ins.Controls.Add(Me.Label5)
        Me.tabEscr_ins.Controls.Add(Me.Label4)
        Me.tabEscr_ins.Controls.Add(Me.txt_insName)
        Me.tabEscr_ins.Controls.Add(Me.txt_insCont)
        Me.tabEscr_ins.Controls.Add(Me.txt_insEnd)
        Me.tabEscr_ins.Location = New System.Drawing.Point(4, 24)
        Me.tabEscr_ins.Name = "tabEscr_ins"
        Me.tabEscr_ins.Padding = New System.Windows.Forms.Padding(3)
        Me.tabEscr_ins.Size = New System.Drawing.Size(824, 436)
        Me.tabEscr_ins.TabIndex = 1
        Me.tabEscr_ins.Text = "Inserir"
        Me.tabEscr_ins.UseVisualStyleBackColor = True
        '
        'list_add
        '
        Me.list_add.FormattingEnabled = True
        Me.list_add.ItemHeight = 15
        Me.list_add.Location = New System.Drawing.Point(100, 185)
        Me.list_add.Name = "list_add"
        Me.list_add.Size = New System.Drawing.Size(433, 94)
        Me.list_add.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(96, 15)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Adicionar cliente"
        '
        'btn_insCli
        '
        Me.btn_insCli.Location = New System.Drawing.Point(552, 185)
        Me.btn_insCli.Name = "btn_insCli"
        Me.btn_insCli.Size = New System.Drawing.Size(100, 24)
        Me.btn_insCli.TabIndex = 7
        Me.btn_insCli.Text = "Adicionar"
        Me.btn_insCli.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(433, 115)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 15)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Endereço"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(267, 109)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 15)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Contacto"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(100, 109)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 15)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Nome"
        '
        'txt_insName
        '
        Me.txt_insName.Location = New System.Drawing.Point(101, 133)
        Me.txt_insName.Name = "txt_insName"
        Me.txt_insName.Size = New System.Drawing.Size(100, 23)
        Me.txt_insName.TabIndex = 2
        '
        'txt_insCont
        '
        Me.txt_insCont.Location = New System.Drawing.Point(267, 133)
        Me.txt_insCont.Name = "txt_insCont"
        Me.txt_insCont.Size = New System.Drawing.Size(100, 23)
        Me.txt_insCont.TabIndex = 2
        '
        'txt_insEnd
        '
        Me.txt_insEnd.Location = New System.Drawing.Point(433, 133)
        Me.txt_insEnd.Name = "txt_insEnd"
        Me.txt_insEnd.Size = New System.Drawing.Size(100, 23)
        Me.txt_insEnd.TabIndex = 0
        '
        'tabEscr_del
        '
        Me.tabEscr_del.Location = New System.Drawing.Point(4, 24)
        Me.tabEscr_del.Name = "tabEscr_del"
        Me.tabEscr_del.Padding = New System.Windows.Forms.Padding(3)
        Me.tabEscr_del.Size = New System.Drawing.Size(824, 436)
        Me.tabEscr_del.TabIndex = 2
        Me.tabEscr_del.Text = "Eliminar"
        Me.tabEscr_del.UseVisualStyleBackColor = True
        '
        'tabEscrEnc
        '
        Me.tabEscrEnc.Controls.Add(Me.TabControl2)
        Me.tabEscrEnc.Location = New System.Drawing.Point(4, 24)
        Me.tabEscrEnc.Name = "tabEscrEnc"
        Me.tabEscrEnc.Padding = New System.Windows.Forms.Padding(3)
        Me.tabEscrEnc.Size = New System.Drawing.Size(824, 467)
        Me.tabEscrEnc.TabIndex = 1
        Me.tabEscrEnc.Text = "Encomenda"
        Me.tabEscrEnc.UseVisualStyleBackColor = True
        '
        'TabControl2
        '
        Me.TabControl2.Controls.Add(Me.tabEscrEnc_add)
        Me.TabControl2.Controls.Add(Me.tabEscrEnc_del)
        Me.TabControl2.Location = New System.Drawing.Point(0, 0)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(824, 472)
        Me.TabControl2.TabIndex = 0
        '
        'tabEscrEnc_add
        '
        Me.tabEscrEnc_add.Controls.Add(Me.encCB_prod)
        Me.tabEscrEnc_add.Controls.Add(Me.encCB_clients)
        Me.tabEscrEnc_add.Location = New System.Drawing.Point(4, 24)
        Me.tabEscrEnc_add.Name = "tabEscrEnc_add"
        Me.tabEscrEnc_add.Padding = New System.Windows.Forms.Padding(3)
        Me.tabEscrEnc_add.Size = New System.Drawing.Size(816, 444)
        Me.tabEscrEnc_add.TabIndex = 0
        Me.tabEscrEnc_add.Text = "Nova Encomenda"
        Me.tabEscrEnc_add.UseVisualStyleBackColor = True
        '
        'encCB_clients
        '
        Me.encCB_clients.FormattingEnabled = True
        Me.encCB_clients.Location = New System.Drawing.Point(64, 172)
        Me.encCB_clients.Name = "encCB_clients"
        Me.encCB_clients.Size = New System.Drawing.Size(121, 23)
        Me.encCB_clients.TabIndex = 0
        '
        'tabEscrEnc_del
        '
        Me.tabEscrEnc_del.Location = New System.Drawing.Point(4, 24)
        Me.tabEscrEnc_del.Name = "tabEscrEnc_del"
        Me.tabEscrEnc_del.Padding = New System.Windows.Forms.Padding(3)
        Me.tabEscrEnc_del.Size = New System.Drawing.Size(816, 444)
        Me.tabEscrEnc_del.TabIndex = 1
        Me.tabEscrEnc_del.Text = "Cancelar"
        Me.tabEscrEnc_del.UseVisualStyleBackColor = True
        '
        'tab_fab
        '
        Me.tab_fab.Controls.Add(Me.TabControl1)
        Me.tab_fab.Location = New System.Drawing.Point(4, 27)
        Me.tab_fab.Name = "tab_fab"
        Me.tab_fab.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_fab.Size = New System.Drawing.Size(824, 495)
        Me.tab_fab.TabIndex = 1
        Me.tab_fab.Text = "Fábrica"
        Me.tab_fab.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(-4, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(832, 499)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(824, 471)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(824, 471)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 15
        Me.ListBox1.Location = New System.Drawing.Point(3, 36)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(498, 364)
        Me.ListBox1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(372, 211)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 15)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Numero Nota"
        '
        'encCB_prod
        '
        Me.encCB_prod.FormattingEnabled = True
        Me.encCB_prod.Location = New System.Drawing.Point(303, 172)
        Me.encCB_prod.Name = "encCB_prod"
        Me.encCB_prod.Size = New System.Drawing.Size(121, 23)
        Me.encCB_prod.TabIndex = 1
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(834, 527)
        Me.Controls.Add(Me.tab1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.tab1.ResumeLayout(False)
        Me.tab_escr.ResumeLayout(False)
        Me.TabEscr.ResumeLayout(False)
        Me.tabEscr_cli.ResumeLayout(False)
        Me.TabEscrCli.ResumeLayout(False)
        Me.tabEscrCli_search.ResumeLayout(False)
        Me.tabEscrCli_search.PerformLayout()
        Me.tabEscr_ins.ResumeLayout(False)
        Me.tabEscr_ins.PerformLayout()
        Me.tabEscrEnc.ResumeLayout(False)
        Me.TabControl2.ResumeLayout(False)
        Me.tabEscrEnc_add.ResumeLayout(False)
        Me.tab_fab.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tab1 As TabControl
    Friend WithEvents tab_escr As TabPage
    Friend WithEvents TabEscr As TabControl
    Friend WithEvents tabEscr_cli As TabPage
    Friend WithEvents tabEscrEnc As TabPage
    Friend WithEvents tab_fab As TabPage
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabEscrCli As TabControl
    Friend WithEvents tabEscr_ins As TabPage
    Friend WithEvents tabEscrCli_search As TabPage
    Friend WithEvents Label1 As Label
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents list_cli As ListBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txt_idcli As TextBox
    Friend WithEvents txt_insName As TextBox
    Friend WithEvents txt_insCont As TextBox
    Friend WithEvents txt_insEnd As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents btn_insCli As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents list_add As ListBox
    Friend WithEvents Label10 As Label
    Friend WithEvents btn_escrSearch As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txt_cliCont As TextBox
    Friend WithEvents txt_cliNome As TextBox
    Friend WithEvents tabEscr_del As TabPage
    Friend WithEvents TabControl2 As TabControl
    Friend WithEvents tabEscrEnc_add As TabPage
    Friend WithEvents tabEscrEnc_del As TabPage
    Friend WithEvents encCB_clients As ComboBox
    Friend WithEvents encCB_prod As ComboBox
End Class
