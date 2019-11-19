Imports System.Data
Imports System.InvalidOperationException
Imports System.ArgumentOutOfRangeException
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient.SqlException
Imports System.IndexOutOfRangeException

Public Class perkuliahan
    Dim nol As Integer = 0

    Sub tampilmhs()
        tutupkoneksi()
        bukakoneksi()
        da = New SqlDataAdapter("select id, nama_mhs, nama_matkul, prodi from nilai", conn)
        ds = New DataSet
        da.Fill(ds)
        dt = ds.Tables(0)
        ListView1.Items.Clear()

        For j As Integer = 0 To dt.Rows.Count - 1
            With ListView1
                .Items.Add(dt.Rows(j)("id"))
                With .Items(.Items.Count - 1).SubItems
                    .Add(dt.Rows(j)("nama_mhs"))
                    .Add(dt.Rows(j)("nama_matkul"))
                    .Add(dt.Rows(j)("prodi"))
                End With
            End With
        Next
        conn.Close()
    End Sub


    Sub urutkan()
        tutupkoneksi()
        Call bukakoneksi()
        da = New SqlDataAdapter("select id, nama_mhs, nama_matkul, prodi from nilai where nama_matkul= '" & cmbMat.Text & "'", conn)
        ds = New DataSet
        da.Fill(ds)
        dt = ds.Tables(0)
        ListView1.Items.Clear()
        For j As Integer = 0 To dt.Rows.Count - 1
            With ListView1
                .Items.Add(dt.Rows(j)("id"))
                With .Items(.Items.Count - 1).SubItems
                    .Add(dt.Rows(j)("nama_mhs"))
                    .Add(dt.Rows(j)("nama_matkul"))
                    .Add(dt.Rows(j)("prodi"))
                End With
            End With
        Next
        conn.Close()
    End Sub


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call tampilmhs()
        With cmbMat
            tutupkoneksi()
            bukakoneksi()
            Dim str As String
            str = "select nama_matkul from matakuliah"
            cmd = New SqlCommand(str, conn)
            rd = cmd.ExecuteReader
            If rd.HasRows Then
                Do While rd.Read
                    cmbMat.Items.Add(rd("nama_matkul"))
                Loop
            Else
            End If
        End With


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
            lblID.Text = .Items(list).SubItems(0).Text
            cmbNama.Text = .Items(list).SubItems(1).Text
            cmbMat.Text = .Items(list).SubItems(2).Text
            cmbProdi.Text = .Items(list).SubItems(3).Text
        End With
    End Sub


    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        Try
            tutupkoneksi()
            bukakoneksi()
            cmd = New SqlCommand("insert into nilai(nama_matkul, nama_mhs, prodi, nilai_uts, nilai_uas, nilai_tugas, nilai_absen, nilai_sel ) values ('" & cmbMat.Text & "', '" & cmbNama.Text & "', '" & cmbProdi.Text & "', '" & nol.ToString & "', '" & nol.ToString & "', '" & nol.ToString & "', '" & nol.ToString & "', '" & nol.ToString & "')", conn)
            cmd.ExecuteNonQuery()
            conn.Close()

            tampilmhs()

            lblID.Text = ""
            cmbAng.Text = ""
            cmbMat.Text = ""
            cmbNama.Text = ""
            cmbProdi.Text = ""

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        tutupkoneksi()
        bukakoneksi()
        Dim sttr As String
        sttr = "update nilai set nama_mhs = '" & cmbNama.Text & "', nama_matkul = '" & cmbMat.Text & "', prodi = '" & cmbProdi.Text & "' where id = '" & lblID.Text & "'"
        cmd = New SqlCommand(sttr, conn)
        cmd.ExecuteNonQuery()

        tampilmhs()

        lblID.Text = ""
        cmbAng.Text = ""
        cmbMat.Text = ""
        cmbNama.Text = ""
        cmbProdi.Text = ""
    End Sub


    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        tutupkoneksi()
        bukakoneksi()
        Dim strrr As String
        strrr = "delete from nilai where id = '" & lblID.Text & "'"
        cmd = New SqlCommand(strrr, conn)
        cmd.ExecuteNonQuery()

        tampilmhs()
        lblID.Text = ""
        cmbAng.Text = ""
        cmbMat.Text = ""
        cmbNama.Text = ""
        cmbProdi.Text = ""
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        tampilmhs()
        lblID.Text = ""
        cmbAng.Text = ""
        cmbMat.Text = ""
        cmbNama.Text = ""
        cmbProdi.Text = ""
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnCari1.Click
        tutupkoneksi()
        bukakoneksi()

        Dim strr As String
        strr = "select nama_mhs from mahasiswa where angkatan = '" & cmbAng.Text & "'"
        cmd = New SqlCommand(strr, conn)
        rd = cmd.ExecuteReader
        If rd.HasRows Then
            Do While rd.Read
                cmbNama.Items.Add(rd("nama_mhs"))
            Loop
        Else
        End If

    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Dim x As String
        x = MsgBox(“Anda Yakin Akan Keluar ??”, vbQuestion + vbOKCancel, “AnnaLee Exit”)

        If x = vbOK Then

            End

        End If
    End Sub

    Private Sub btnKembali2_Click(sender As Object, e As EventArgs) Handles btnKembali2.Click
        Me.Hide()
        haladmin.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnCari.Click
        urutkan()
    End Sub

End Class