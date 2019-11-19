Public Class haladmin
    Private Sub btnKembali_Click(sender As Object, e As EventArgs) Handles btnKembali.Click
        Me.Hide()
        Form1.Show()
    End Sub

    Private Sub btnKul_Click(sender As Object, e As EventArgs) Handles btnKul.Click
        Me.Hide()
        perkuliahan.Show()
    End Sub

    Private Sub btnMahasiswa_Click(sender As Object, e As EventArgs) Handles btnMahasiswa.Click
        Me.Hide()
        mahasiswa.Show()
    End Sub

    Private Sub btnProdi_Click(sender As Object, e As EventArgs) Handles btnProdi.Click
        Me.Hide()
        prodi.Show()
    End Sub

    Private Sub btnMat_Click(sender As Object, e As EventArgs) Handles btnMat.Click
        Me.Hide()
        matkul.Show()
    End Sub
End Class