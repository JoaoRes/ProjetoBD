Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_escritorio.Click
        Me.Hide()
        Escr.Show()
    End Sub

    Private Sub btn_producao_Click(sender As Object, e As EventArgs) Handles btn_producao.Click
        Me.Hide()
        Prod.Show()
    End Sub
End Class
