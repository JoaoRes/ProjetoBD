<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Pesquisa
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txt_nota = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_search = New System.Windows.Forms.Button()
        Me.lista = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'txt_nota
        '
        Me.txt_nota.Location = New System.Drawing.Point(833, 30)
        Me.txt_nota.Name = "txt_nota"
        Me.txt_nota.Size = New System.Drawing.Size(100, 23)
        Me.txt_nota.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(833, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 15)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Numero Nota"
        '
        'btn_search
        '
        Me.btn_search.Location = New System.Drawing.Point(912, 415)
        Me.btn_search.Name = "btn_search"
        Me.btn_search.Size = New System.Drawing.Size(156, 35)
        Me.btn_search.TabIndex = 3
        Me.btn_search.Text = "Pesquisar"
        Me.btn_search.UseVisualStyleBackColor = True
        '
        'lista
        '
        Me.lista.FormattingEnabled = True
        Me.lista.ItemHeight = 15
        Me.lista.Location = New System.Drawing.Point(12, 12)
        Me.lista.Name = "lista"
        Me.lista.Size = New System.Drawing.Size(801, 439)
        Me.lista.TabIndex = 4
        '
        'Pesquisa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1134, 471)
        Me.Controls.Add(Me.lista)
        Me.Controls.Add(Me.btn_search)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_nota)
        Me.Name = "Pesquisa"
        Me.Text = "Pesquisa"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txt_nota As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btn_search As Button
    Friend WithEvents lista As ListBox
End Class
