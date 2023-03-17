Imports System.Data.SqlClient
Public Class KelolaPetugas
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Admin.Show()
        Me.Hide()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        connect()
        If Txtidpeg.Text = "" Or txtuser.Text = "" Or txtpass.Text = "" Or txtnama.Text = "" Or cblevel.Text = "" Then
            MsgBox("Pastikan mengisi semua field dengan benar")
        Else
            sql = "INSERT into petugas (id_petugas, username, password, nama_petugas, level) VALUES ('" & Txtidpeg.Text & "', '" & txtuser.Text & "','" & txtpass.Text & "','" & txtnama.Text & "','" & cblevel.Text & "')"
            cmd = New SqlCommand(sql, con)
            cmd.ExecuteNonQuery()
            MsgBox("Berhasil tambah data")
            aturdgv()
            kosong()
        End If
    End Sub

    Sub aturdgv()
        sql = "SELECT * From petugas"
        da = New SqlDataAdapter(sql, con)
        ds = New DataSet
        da.Fill(ds, "petugas")
        dgv_user.DataSource = ds.Tables("petugas")
    End Sub

    Sub kosong()
        Txtidpeg.Text = ""
        txtuser.Text = ""
        txtpass.Text = ""
        txtnama.Text = ""
        cblevel.Text = ""
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Txtidpeg.Text = "" Or txtuser.Text = "" Or txtpass.Text = "" Or txtnama.Text = "" Or cblevel.Text = "" Then
            MsgBox("Pastikan mengisi semua field dengan benar")
        Else
            sql = "UPDATE petugas set username = '" & txtuser.Text & "', password='" & txtpass.Text & "', nama_petugas='" & txtnama.Text & "', level='" & cblevel.Text & "' where id_petugas='" & Txtidpeg.Text & "'"
            cmd = New SqlCommand(sql, con)
            cmd.ExecuteNonQuery()
            MsgBox("Berhasil edit data")
            aturdgv()
            kosong()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Txtidpeg.Text = "" Or txtuser.Text = "" Or txtpass.Text = "" Or txtnama.Text = "" Or cblevel.Text = "" Then
            MsgBox("Pastikan mengisi semua field dengan benar")
        Else
            sql = "DELETE FROM petugas where id_petugas='" & Txtidpeg.Text & "'"
            cmd = New SqlCommand(sql, con)
            cmd.ExecuteNonQuery()
            MsgBox("Berhasil hapus data")
            aturdgv()
            kosong()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcari.KeyPress
        sql = "SELECT * From petugas where (username like '%" & txtcari.Text & "%')"
        da = New SqlDataAdapter(sql, con)
        ds = New DataSet
        da.Fill(ds, "petugas")
        dgv_user.DataSource = ds.Tables("petugas")
    End Sub

    Private Sub dgv_user_MouseClick(sender As Object, e As MouseEventArgs) Handles dgv_user.MouseClick
        Txtidpeg.Text = dgv_user.Rows(dgv_user.CurrentRow.Index).Cells(0).Value
        txtuser.Text = dgv_user.Rows(dgv_user.CurrentRow.Index).Cells(1).Value
        txtpass.Text = dgv_user.Rows(dgv_user.CurrentRow.Index).Cells(2).Value
        txtnama.Text = dgv_user.Rows(dgv_user.CurrentRow.Index).Cells(3).Value
        cblevel.Text = dgv_user.Rows(dgv_user.CurrentRow.Index).Cells(4).Value
    End Sub

    Private Sub KelolaPetugas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connect()
        aturdgv()
    End Sub

    Private Sub Txtidpeg_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txtidpeg.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            MsgBox("Pastikan angka yang di inputkan")
            e.Handled = True
        End If
    End Sub
End Class