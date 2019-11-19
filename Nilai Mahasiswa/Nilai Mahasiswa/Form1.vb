Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient.SqlException

Public Class Form1
    Dim jenkel As String
    Dim Rata As Double

    Sub tampilmhs()
        tutupkoneksi()
        bukakoneksi()
        da = New SqlDataAdapter("select * from nilai where id='111'", conn)
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
                    .Add(dt.Rows(j)("nilai_uts"))
                    .Add(dt.Rows(j)("nilai_uas"))
                    .Add(dt.Rows(j)("nilai_tugas"))
                    .Add(dt.Rows(j)("nilai_absen"))
                    .Add(dt.Rows(j)("nilai_sel"))
                End With
            End With
        Next
        conn.Close()
    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tampilmhs()
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
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        Dim list As Integer
        If ListView1.SelectedItems.Count = 0 Then Exit Sub
        With ListView1
            list = .SelectedIndices(0)
            lblID.Text = .Items(list).SubItems(0).Text
            lblNama.Text = .Items(list).SubItems(1).Text
            lblMat.Text = .Items(list).SubItems(2).Text
        End With
        tampilkandata()
        tampilkandata1()
    End Sub

    Sub tampilkandata()
        tutupkoneksi()
        bukakoneksi()
        Dim sstr As String
        sstr = "select nim, jenkel, prodi, angkatan from mahasiswa where nama_mhs = '" & lblNama.Text & "'"
        cmd = New SqlCommand(sstr, conn)
        rd = cmd.ExecuteReader
        If rd.HasRows Then
            If rd.Read() Then
                lblNIM.Text = rd.Item("nim")
                lblJenkel.Text = rd.Item("jenkel")
                lblProdi.Text = rd.Item("prodi")
                lblAng.Text = rd.Item("angkatan")
            End If
        End If
    End Sub


    Sub tampilkandata1()
        tutupkoneksi()
        bukakoneksi()
        Dim ssstr As String
        ssstr = "select id_matkul from matakuliah where nama_matkul = '" & lblMat.Text & "'"
        cmd = New SqlCommand(ssstr, conn)
        rd = cmd.ExecuteReader
        If rd.HasRows Then
            If rd.Read() Then
                lblKode.Text = rd.Item("id_matkul")
            End If
        End If
    End Sub


    Private Sub btnUrut_Click(sender As Object, e As EventArgs) Handles btnUrut.Click
        urutkan()
    End Sub


    Sub urutkan()
        tutupkoneksi()
        Call bukakoneksi()
        da = New SqlDataAdapter("select id, nama_mhs, nama_matkul, prodi, nilai_uts, nilai_uas, nilai_tugas, nilai_absen, nilai_sel from nilai where nama_matkul= '" & cmbMat.Text & "'", conn)
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
                    .Add(dt.Rows(j)("nilai_uts"))
                    .Add(dt.Rows(j)("nilai_uas"))
                    .Add(dt.Rows(j)("nilai_tugas"))
                    .Add(dt.Rows(j)("nilai_absen"))
                    .Add(dt.Rows(j)("nilai_sel"))
                End With
            End With
        Next
        conn.Close()
    End Sub


    Sub Proses()


        Rata = (Val(TxtUTS.Text) * 0.3) + (Val(TxtUAS.Text) * 0.4) + (Val(TxtTugas.Text) * 0.2) + (Val(TxtAbsen.Text) * 0.1)



    End Sub

    Private Sub Reset()

        tampilmhs()
        lblNIM.Text = ""
        lblNama.Text = ""
        lblJenkel.Text = ""
        lblAng.Text = ""
        lblProdi.Text = ""
        lblID.Text = ""
        lblKode.Text = ""
        lblMat.Text = ""
        TxtUTS.Text = ” ”
        TxtUAS.Text = ” ”
        TxtTugas.Text = ” ”
        TxtAbsen.Text = ” ”

    End Sub

    Private Sub Keluar()
        Dim x As String
        x = MsgBox(“Anda Yakin Akan Keluar ??”, vbQuestion + vbOKCancel, “AnnaLee Exit”)

        If x = vbOK Then

            End

        End If

    End Sub


    Private Sub CmdProses_Click(sender As Object, e As EventArgs) Handles CmdProses.Click
        Proses()
        tutupkoneksi()
        bukakoneksi()


        Dim sttr As String
        cmd = New SqlCommand("update nilai set nama_mhs = '" & lblNama.Text & "', nama_matkul = '" & lblMat.Text & "', prodi = '" & lblProdi.Text & "', nilai_uts = '" & TxtUTS.Text & "', nilai_uas = '" & TxtUAS.Text & "', nilai_tugas = '" & TxtTugas.Text & "', nilai_absen = '" & TxtAbsen.Text & "', nilai_sel = '" & Rata.ToString & "' where id = '" & lblID.Text & "'", conn)

        cmd.ExecuteNonQuery()
        conn.Close()
        Reset()
    End Sub


    Private Sub CmdReset_Click(sender As Object, e As EventArgs) Handles CmdReset.Click
        Reset()
    End Sub

    Private Sub CmdKeluar_Click(sender As Object, e As EventArgs) Handles CmdKeluar.Click
        Keluar()
    End Sub

    Private Sub btnAdmin_Click(sender As Object, e As EventArgs) Handles btnAdmin.Click
        Me.Hide()
        adminlogin.Show()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Reset()
    End Sub

End Class
