Imports System.Data
Imports System.InvalidOperationException
Imports System.ArgumentOutOfRangeException
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient.SqlException
Imports System.IndexOutOfRangeException

Public Class mahasiswa
    Dim nol As Integer = 0

    Sub tampilmhs()
        tutupkoneksi()
        bukakoneksi()
        da = New SqlDataAdapter("select nim, nama_mhs, jenkel, prodi, angkatan from mahasiswa", conn)
        ds = New DataSet
        da.Fill(ds)
        dt = ds.Tables(0)
        ListView1.Items.Clear()

        For j As Integer = 0 To dt.Rows.Count - 1
            With ListView1
                .Items.Add(dt.Rows(j)("nim"))
                With .Items(.Items.Count - 1).SubItems
                    .Add(dt.Rows(j)("nama_mhs"))
                    .Add(dt.Rows(j)("prodi"))
                    .Add(dt.Rows(j)("jenkel"))
                    .Add(dt.Rows(j)("angkatan"))
                End With
            End With
        Next
        conn.Close()
    End Sub


    Sub refresh()
        txtNIM.Text = ""
        txtNama.Text = ""
        cmbProdi.Text = ""
        cmbJenkel.Text = ""
        cmbAng.Text = ""
    End Sub


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call tampilmhs()
        With cmbProdi
            tutupkoneksi()
            bukakoneksi()
            Dim str As String
            str = "select nama_prodi from prodi"
            cmd = New SqlCommand(str, conn)
            rd = cmd.ExecuteReader
            If rd.HasRows Then
                Do While rd.Read
                    cmbProdi.Items.Add(rd("nama_prodi"))
                Loop
            Else
            End If
        End With
    End Sub


    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        Dim list As Integer
        If ListView1.SelectedItems.Count = 0 Then Exit Sub
        With ListView1
            list = .SelectedIndices(0)
            txtNIM.Text = .Items(list).SubItems(0).Text
            txtNama.Text = .Items(list).SubItems(1).Text
            cmbProdi.Text = .Items(list).SubItems(2).Text
            cmbJenkel.Text = .Items(list).SubItems(3).Text
            cmbAng.Text = .Items(list).SubItems(4).Text
        End With
    End Sub

    Private Sub btnKembali2_Click(sender As Object, e As EventArgs) Handles btnKembali.Click
        Me.Hide()
        haladmin.Show()
    End Sub


    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Dim x As String
        x = MsgBox(“Anda Yakin Akan Keluar ??”, vbQuestion + vbOKCancel, “AnnaLee Exit”)

        If x = vbOK Then

            End

        End If
    End Sub


    Private Sub btnRef_Click(sender As Object, e As EventArgs) Handles btnRef.Click
        tampilmhs()
        refresh()
    End Sub

    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        Try
            tutupkoneksi()
            bukakoneksi()
            cmd = New SqlCommand("insert into mahasiswa(nim, nama_mhs, jenkel, prodi, angkatan) values ('" & txtNIM.Text & "', '" & txtNama.Text & "', '" & cmbJenkel.Text & "', '" & cmbProdi.Text & "', '" & cmbAng.Text & "')", conn)
            cmd.ExecuteNonQuery()
            conn.Close()

            tampilmhs()
            refresh()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        tutupkoneksi()
        bukakoneksi()
        Dim sttr As String
        sttr = "update mahasiswa set nim = '" & txtNIM.Text & "', nama_mhs = '" & txtNama.Text & "', jenkel = '" & cmbJenkel.Text & "', prodi = '" & cmbProdi.Text & "', angkatan = '" & cmbAng.Text & "' where nim = '" & txtNIM.Text & "'"
        cmd = New SqlCommand(sttr, conn)
        cmd.ExecuteNonQuery()

        tampilmhs()
        refresh()
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        tutupkoneksi()
        bukakoneksi()
        Dim strrr As String
        strrr = "delete from mahasiswa where nim = '" & txtNIM.Text & "'"
        cmd = New SqlCommand(strrr, conn)
        cmd.ExecuteNonQuery()

        tampilmhs()
        refresh()
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class