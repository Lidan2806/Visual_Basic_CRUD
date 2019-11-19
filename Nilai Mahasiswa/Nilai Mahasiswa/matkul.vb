Imports System.Data
Imports System.InvalidOperationException
Imports System.ArgumentOutOfRangeException
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient.SqlException
Imports System.IndexOutOfRangeException

Public Class matkul

    Sub tampil()
        tutupkoneksi()
        bukakoneksi()
        da = New SqlDataAdapter("select id_matkul, nama_matkul, semester from matakuliah", conn)
        ds = New DataSet
        da.Fill(ds)
        dt = ds.Tables(0)
        ListView1.Items.Clear()

        For j As Integer = 0 To dt.Rows.Count - 1
            With ListView1
                .Items.Add(dt.Rows(j)("id_matkul"))
                With .Items(.Items.Count - 1).SubItems
                    .Add(dt.Rows(j)("nama_matkul"))
                    .Add(dt.Rows(j)("semester"))
                End With
            End With
        Next
        conn.Close()
    End Sub

    Sub refresh()
        txtKode.Text = ""
        txtNama.Text = ""
        cmbSem.Text = ""
    End Sub

    Private Sub btnKembali_Click(sender As Object, e As EventArgs) Handles btnKembali.Click
        Me.Hide()
        haladmin.Show()
    End Sub

    Private Sub btnRef_Click(sender As Object, e As EventArgs) Handles btnRef.Click
        Refresh()
        tampil()
    End Sub

    Private Sub matkul_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tampil()
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Dim x As String
        x = MsgBox(“Anda Yakin Akan Keluar ??”, vbQuestion + vbOKCancel, “AnnaLee Exit”)

        If x = vbOK Then

            End

        End If
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        Dim list As Integer
        If ListView1.SelectedItems.Count = 0 Then Exit Sub
        With ListView1
            list = .SelectedIndices(0)
            txtKode.Text = .Items(list).SubItems(0).Text
            txtNama.Text = .Items(list).SubItems(1).Text
        End With
    End Sub

    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        Try
            tutupkoneksi()
            bukakoneksi()
            cmd = New SqlCommand("insert into matakuliah (id_matkul, nama_matkul, semester) values ('" & txtKode.Text & "', '" & txtNama.Text & "', '" & cmbSem.Text & "')", conn)
            cmd.ExecuteNonQuery()
            conn.Close()

            tampil()
            refresh()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        tutupkoneksi()
        bukakoneksi()
        Dim sttr As String
        sttr = "update matakuliah set id_matkul = '" & txtKode.Text & "', nama_matkul = '" & txtNama.Text & "', semester = '" & cmbSem.Text & "' where id_matkul = '" & txtKode.Text & "'"
        cmd = New SqlCommand(sttr, conn)
        cmd.ExecuteNonQuery()

        tampil()
        refresh()
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        tutupkoneksi()
        bukakoneksi()
        Dim strrr As String
        strrr = "delete from matakuliah where id_matkul= '" & txtKode.Text & "'"
        cmd = New SqlCommand(strrr, conn)
        cmd.ExecuteNonQuery()

        tampil()
        refresh()
    End Sub
End Class