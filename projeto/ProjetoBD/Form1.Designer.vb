<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btn_escritorio = New System.Windows.Forms.Button()
        Me.btn_producao = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btn_escritorio
        '
        Me.btn_escritorio.Location = New System.Drawing.Point(12, 71)
        Me.btn_escritorio.Name = "btn_escritorio"
        Me.btn_escritorio.Size = New System.Drawing.Size(310, 167)
        Me.btn_escritorio.TabIndex = 0
        Me.btn_escritorio.Text = "Escritorio"
        Me.btn_escritorio.UseVisualStyleBackColor = True
        '
        'btn_producao
        '
        Me.btn_producao.Location = New System.Drawing.Point(363, 71)
        Me.btn_producao.Name = "btn_producao"
        Me.btn_producao.Size = New System.Drawing.Size(310, 167)
        Me.btn_producao.TabIndex = 1
        Me.btn_producao.Text = "Producao"
        Me.btn_producao.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(685, 300)
        Me.Controls.Add(Me.btn_producao)
        Me.Controls.Add(Me.btn_escritorio)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btn_escritorio As Button
    Friend WithEvents btn_producao As Button
End Class
