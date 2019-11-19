Public Class adminlogin
    Private Sub btnKembali1_Click(sender As Object, e As EventArgs) Handles btnKembali1.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim ID As String
        Dim Password As String
        ID = txtID.Text
        Password = txtPass.Text
        If ID = "ash" And Password = "111" Then

            haladmin.Show()
            Me.Hide()
        Else
            MessageBox.Show("Gagal untuk melakukan login", "Login Gagal")
        End If
    End Sub
End Class