<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Escr
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
        Me.btn_pesquisa = New System.Windows.Forms.Button()
        Me.btn_insert = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btn_pesquisa
        '
        Me.btn_pesquisa.Location = New System.Drawing.Point(12, 27)
        Me.btn_pesquisa.Name = "btn_pesquisa"
        Me.btn_pesquisa.Size = New System.Drawing.Size(122, 40)
        Me.btn_pesquisa.TabIndex = 0
        Me.btn_pesquisa.Text = "Pesquisa"
        Me.btn_pesquisa.UseVisualStyleBackColor = True
        '
        'btn_insert
        '
        Me.btn_insert.Location = New System.Drawing.Point(140, 27)
        Me.btn_insert.Name = "btn_insert"
        Me.btn_insert.Size = New System.Drawing.Size(122, 40)
        Me.btn_insert.TabIndex = 1
        Me.btn_insert.Text = "Inserir"
        Me.btn_insert.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(268, 27)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(122, 40)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "Button3"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(396, 27)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(122, 40)
        Me.Button4.TabIndex = 3
        Me.Button4.Text = "Button4"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Escr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(761, 91)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.btn_insert)
        Me.Controls.Add(Me.btn_pesquisa)
        Me.Name = "Escr"
        Me.Text = "Escr"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btn_pesquisa As Button
    Friend WithEvents btn_insert As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
End Class
