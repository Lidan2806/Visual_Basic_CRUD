﻿Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.ArgumentException

Module koneksi
    Public comSQL As New SqlClient.SqlCommand
    Public sql As String
    Public conn As New SqlConnection
    Public cmd As SqlCommand
    Public cmdd As SqlCommand
    Public rd As SqlDataReader
    Public da As SqlDataAdapter
    Public ds As DataSet
    Public dt As DataTable

    Public builder As New SqlCommandBuilder

    Public str As String = "Data Source=LAPTOP-T7AETA5Q\SQLEXPRESS;Initial Catalog=nilai_mahasiswa;Integrated Security=True"

    Public Sub bukakoneksi()
        If conn.State = ConnectionState.Closed Then
            conn.ConnectionString = str
            Try
                conn.Open()

            Catch ex As Exception
                MsgBox("Koneksi Gagal: " & ex.ToString)
            End Try
        End If
    End Sub

    Public Sub tutupkoneksi()
        If conn.State = ConnectionState.Open Then
            Try
                conn.Close()
            Catch ex As Exception
                MsgBox("Gagal menutup koneksi: " & ex.ToString)
            End Try
        End If
    End Sub
End Module
