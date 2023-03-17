﻿Imports System.Data.SqlClient
Imports System.Drawing.Printing

Public Class siswa
    Dim WithEvents PD As New PrintDocument
    Dim PDD As New PrintPreviewDialog
    Private Sub siswa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connect()
        aturdgv()
    End Sub

    Sub aturdgv()
        sql = "SELECT bulan_dibayar, tgl_bayar, jumlah_bayar FROM pembayaran"
        da = New SqlDataAdapter(sql, con)
        ds = New DataSet
        da.Fill(ds, "pembayaran")
        dgv_user.DataSource = ds.Tables("pembayaran")
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        sql = "SELECT bulan_dibayar, tgl_bayar, jumlah_bayar from pembayaran WHERE tgl_bayar between '" & dtdari.Value.Date.ToString("MM/dd/yyyy") & "' and '" & dtsampai.Value.Date.ToString("MM/dd/yyyy") & "'"
        da = New SqlDataAdapter(sql, con)
        ds = New DataSet
        da.Fill(ds, "pembayaran")
        dgv_user.DataSource = ds.Tables("pembayaran")
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'printPD()
        PDD.Document = PD
        PDD.ShowDialog()
    End Sub
    Private Sub PD_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PD.PrintPage
        Dim f10 As New Font("Times New Roman", 10, FontStyle.Regular)
        Dim f10b As New Font("Times New Roman", 10, FontStyle.Bold)
        Dim f14 As New Font("Times New Roman", 14, FontStyle.Bold)

        Dim leftmargin As Integer = PD.DefaultPageSettings.Margins.Left
        Dim centermargin As Integer = PD.DefaultPageSettings.PaperSize.Width / 2
        Dim rightmargin As Integer = PD.DefaultPageSettings.PaperSize.Width

        Dim kanan As New StringFormat
        Dim tengah As New StringFormat
        kanan.Alignment = StringAlignment.Far
        tengah.Alignment = StringAlignment.Center

        Dim garis As String
        garis = "--------------------------------------------------------------------------------------"

        e.Graphics.DrawString("SPP SMK Negeri 2 Kuningan", f14, Brushes.Black, centermargin, 5, tengah)
        e.Graphics.DrawString("Jl.Sukamulya No.77", f10, Brushes.Black, centermargin, 25, tengah)
        e.Graphics.DrawString("No Tlp: 0812", f10, Brushes.Black, centermargin, 40, tengah)

        e.Graphics.DrawString("Petugas", f10, Brushes.Black, 0, 65)
        e.Graphics.DrawString(":", f10, Brushes.Black, 60, 65)
        e.Graphics.DrawString("Dicky", f10, Brushes.Black, 80, 65)

        e.Graphics.DrawString(garis, f10, Brushes.Black, 0, 80)
        e.Graphics.DrawString("nisn", f10, Brushes.Black, 20, 95)
        e.Graphics.DrawString("harga", f10, Brushes.Black, 60, 95)
        e.Graphics.DrawString("tanggal bayar", f10, Brushes.Black, 120, 95)
        dgv_user.AllowUserToAddRows = False

        Dim tinggi As Integer
        For baris As Integer = 0 To dgv_user.RowCount - 1
            tinggi += 15
            e.Graphics.DrawString(dgv_user.Rows(baris).Cells(2).Value.ToString, f10, Brushes.Black, 20, 100 + tinggi)
            e.Graphics.DrawString(dgv_user.Rows(baris).Cells(7).Value.ToString, f10, Brushes.Black, 60, 100 + tinggi)
            e.Graphics.DrawString(dgv_user.Rows(baris).Cells(3).Value.ToString, f10, Brushes.Black, 120, 100 + tinggi)


        Next
        tinggi = 110 + tinggi
        e.Graphics.DrawString(garis, f10, Brushes.Black, 0, 400)
        e.Graphics.DrawString("Terimakasih:)))))))))))))))", f10, Brushes.Black, centermargin, 450, tengah)


    End Sub

    Sub printPD()
        PrintDoc.PrinterSettings.PrinterName = "Microsoft Print to PDF"
        PrintDoc.Print()
    End Sub

    Private Sub PD_BeginPrint(sender As Object, e As PrintEventArgs) Handles PD.BeginPrint
        Dim pagesetup As New PageSettings
        pagesetup.PaperSize = New PaperSize("Custom", 350, 500)
        PD.DefaultPageSettings = pagesetup
    End Sub
End Class