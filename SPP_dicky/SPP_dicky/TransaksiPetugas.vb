Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Drawing.Printing
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar

Public Class TransaksiPetugas
    Dim WithEvents PD As New PrintDocument
    Dim PDD As New PrintPreviewDialog

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        petugas.Show()
        Me.Hide()
    End Sub

    Sub aturdgv()
        sql = "SELECT * FROM pembayaran"
        da = New SqlDataAdapter(sql, con)
        ds = New DataSet
        da.Fill(ds, "pembayaran")
        dgv_user.DataSource = ds.Tables("pembayaran")
    End Sub

    Sub kosong()
        idptgs.Text = ""
        nisn.Text = ""
        bulanb.Text = ""
        tahunb.Text = ""
        idspp.Text = ""
        jmlbyrr.Text = ""
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        connect()
        If bayar.Text = "" Or idptgs.Text = "" Or nisn.Text = "" Or bulanb.Text = "" Or tahunb.Text = "" Or idspp.Text = "" Or jmlbyrr.Text = "" Then
            MsgBox("Pastikan mengisi semua field dengan benar")
        Else
            sql = "INSERT into pembayaran (id_pembayaran, id_petugas, nisn, tgl_bayar, bulan_dibayar, tahun_dibayar, id_spp, jumlah_bayar) VALUES ('" & bayar.Text & "', '" & idptgs.Text & "','" & nisn.Text & "','" & Format(dttbayar.Value, "yyyy-MM-dd") & "','" & bulanb.Text & "','" & tahunb.Text & "','" & idspp.Text & "','" & jmlbyrr.Text & "')"
            cmd = New SqlCommand(sql, con)
            cmd.ExecuteNonQuery()
            MsgBox("Berhasil tambah data")
            aturdgv()
            kosong()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        connect()
        If bayar.Text = "" Or idptgs.Text = "" Or nisn.Text = "" Or bulanb.Text = "" Or tahunb.Text = "" Or idspp.Text = "" Or jmlbyrr.Text = "" Then
            MsgBox("Pastikan mengisi semua field dengan benar")
        Else
            sql = "UPDATE pembayaran set id_petugas='" & idptgs.Text & "', nisn='" & nisn.Text & "', tgl_bayar='" & Format(dttbayar.Value, "yyyy-MM-dd") & "', bulan_dibayar='" & bulanb.Text & "', tahun_dibayar='" & tahunb.Text & "', id_spp='" & idspp.Text & "', jumlah_bayar='" & jmlbyrr.Text & "' WHERE id_pembayaran='" & bayar.Text & "'"
            cmd = New SqlCommand(sql, con)
            cmd.ExecuteNonQuery()
            MsgBox("Berhasil edit data")
            aturdgv()
            kosong()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If bayar.Text = "" Or idptgs.Text = "" Or nisn.Text = "" Or bulanb.Text = "" Or tahunb.Text = "" Or idspp.Text = "" Or jmlbyrr.Text = "" Then
            MsgBox("Pastikan mengisi semua field dengan benar")
        Else
            sql = "DELETE FROM pembayaran where id_pembayaran='" & bayar.Text & "'"
            cmd = New SqlCommand(sql, con)
            cmd.ExecuteNonQuery()
            MsgBox("Berhasil hapus data")
            aturdgv()
            kosong()
        End If
    End Sub

    Private Sub TransaksiPetugas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connect()
        aturdgv()
    End Sub

    Private Sub dgv_user_MouseClick(sender As Object, e As MouseEventArgs) Handles dgv_user.MouseClick
        bayar.Text = dgv_user.Rows(dgv_user.CurrentRow.Index).Cells(0).Value
        idptgs.Text = dgv_user.Rows(dgv_user.CurrentRow.Index).Cells(1).Value
        nisn.Text = dgv_user.Rows(dgv_user.CurrentRow.Index).Cells(2).Value
        dttbayar.Value = dgv_user.Rows(dgv_user.CurrentRow.Index).Cells(3).Value
        bulanb.Text = dgv_user.Rows(dgv_user.CurrentRow.Index).Cells(4).Value
        tahunb.Text = dgv_user.Rows(dgv_user.CurrentRow.Index).Cells(5).Value
        idspp.Text = dgv_user.Rows(dgv_user.CurrentRow.Index).Cells(6).Value
        jmlbyrr.Text = dgv_user.Rows(dgv_user.CurrentRow.Index).Cells(7).Value
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
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        sql = "SELECT * From pembayaran Where (id_pembayaran like '%" & TextBox1.Text & "%')"
        da = New SqlDataAdapter(sql, con)
        ds = New DataSet
        da.Fill(ds, "kelas")
        dgv_user.DataSource = ds.Tables("kelas")
    End Sub

    Private Sub bayar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles bayar.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            MsgBox("Pastikan angka yang di inputkan")
            e.Handled = True
        End If
    End Sub

    Private Sub bulanb_KeyPress(sender As Object, e As KeyPressEventArgs) Handles bulanb.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            MsgBox("Pastikan angka yang di inputkan")
            e.Handled = True
        End If
    End Sub

    Private Sub tahunb_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tahunb.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            MsgBox("Pastikan angka yang di inputkan")
            e.Handled = True
        End If
    End Sub

    Private Sub jmlbyrr_KeyPress(sender As Object, e As KeyPressEventArgs) Handles jmlbyrr.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            MsgBox("Pastikan angka yang di inputkan")
            e.Handled = True
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        connect()
        If TextBox2.Text = 2000000 Then
            MsgBox("Uang anda lebih")
        End If
    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click
        Label13.Text = 1000000
    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click
        Label12.Text = 1000000
    End Sub
End Class