Imports System.Data.SqlClient

Public Class KelolaSiswa
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Admin.Show()
        Me.Hide()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        connect()
        If txtnisn.Text = "" Or txtnis.Text = "" Or txtnama.Text = "" Or cbidkel.Text = "" Or txtalamat.Text = "" Or txtnotelp.Text = "" Or cbidspp.Text = "" Then
            MsgBox("Pastikan mengisi semua field dengan benar")
        Else
            sql = "INSERT into siswa (nisn, nis, nama, id_kelas, alamat, no_telp, id_spp) VALUES ('" & txtnisn.Text & "', '" & txtnis.Text & "','" & txtnama.Text & "', '" & cbidkel.Text & "', '" & txtalamat.Text & "','" & txtnotelp.Text & "','" & cbidspp.Text & "')"
            cmd = New SqlCommand(sql, con)
            cmd.ExecuteNonQuery()
            MsgBox("Berhasil tambah data")
            aturdgv()
            kosong()
        End If
    End Sub

    Sub aturdgv()
        sql = "SELECT * From siswa"
        da = New SqlDataAdapter(sql, con)
        ds = New DataSet
        da.Fill(ds, "siswa")
        dgv_user.DataSource = ds.Tables("siswa")
    End Sub

    Sub kosong()
        txtnisn.Text = ""
        txtnis.Text = ""
        txtnama.Text = ""
        cbidkel.Text = ""
        txtalamat.Text = ""
        txtnotelp.Text = ""
        cbidspp.Text = ""
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If txtnisn.Text = "" Or txtnis.Text = "" Or txtnama.Text = "" Or cbidkel.Text = "" Or txtalamat.Text = "" Or txtnotelp.Text = "" Or cbidspp.Text = "" Then
            MsgBox("Pastikan mengisi semua field dengan benar")
        Else
            sql = "UPDATE siswa set nis='" & txtnis.Text & "',nama = '" & txtnama.Text & "',id_kelas = '" & cbidkel.Text & "',alamat = '" & txtalamat.Text & "',no_telp = '" & txtnotelp.Text & "' ,id_spp = '" & cbidspp.Text & "'where nisn='" & txtnisn.Text & "'"
            cmd = New SqlCommand(sql, con)
            cmd.ExecuteNonQuery()
            MsgBox("Berhasil edit data")
            aturdgv()
            kosong()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If txtnisn.Text = "" Or txtnis.Text = "" Or txtnama.Text = "" Or cbidkel.Text = "" Or txtalamat.Text = "" Or txtnotelp.Text = "" Or cbidspp.Text = "" Then
            MsgBox("Pastikan mengisi semua field dengan benar")
        Else
            sql = "DELETE FROM siswa where nisn='" & txtnisn.Text & "'"
            cmd = New SqlCommand(sql, con)
            cmd.ExecuteNonQuery()
            MsgBox("Berhasil hapus data")
            aturdgv()
            kosong()
        End If
    End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcari.KeyPress
        sql = "SELECT * From siswa where (nama like '%" & txtcari.Text & "%')"
        da = New SqlDataAdapter(sql, con)
        ds = New DataSet
        da.Fill(ds, "siswa")
        dgv_user.DataSource = ds.Tables("siswa")
    End Sub

    Private Sub dgv_user_MouseClick(sender As Object, e As MouseEventArgs) Handles dgv_user.MouseClick
        txtnisn.Text = dgv_user.Rows(dgv_user.CurrentRow.Index).Cells(0).Value
        txtnis.Text = dgv_user.Rows(dgv_user.CurrentRow.Index).Cells(1).Value
        txtnama.Text = dgv_user.Rows(dgv_user.CurrentRow.Index).Cells(2).Value
        cbidkel.Text = dgv_user.Rows(dgv_user.CurrentRow.Index).Cells(3).Value
        txtalamat.Text = dgv_user.Rows(dgv_user.CurrentRow.Index).Cells(4).Value
        txtnotelp.Text = dgv_user.Rows(dgv_user.CurrentRow.Index).Cells(5).Value
        cbidspp.Text = dgv_user.Rows(dgv_user.CurrentRow.Index).Cells(6).Value
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub KelolaSiswa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connect()
        aturdgv()
    End Sub

    Private Sub txtnisn_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnisn.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            MsgBox("Pastikan angka yang di inputkan")
            e.Handled = True
        End If
    End Sub

    Private Sub txtnis_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnis.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            MsgBox("Pastikan angka yang di inputkan")
            e.Handled = True
        End If
    End Sub

    Private Sub txtnotelp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnotelp.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            MsgBox("Pastikan angka yang di inputkan")
            e.Handled = True
        End If
    End Sub
End Class