Imports System.Data.SqlClient

Public Class KelolaSpp
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Admin.Show()
        Me.Hide()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        connect()
        If cbidspp.Text = "" Or txttahun.Text = "" Or txtnom.Text = "" Then
            MsgBox("Pastikan mengisi semua field dengan benar")
        Else
            sql = "INSERT into spp (id_spp, tahun, nominal) VALUES ('" & cbidspp.Text & "', '" & txttahun.Text & "','" & txtnom.Text & "')"
            cmd = New SqlCommand(sql, con)
            cmd.ExecuteNonQuery()
            MsgBox("Berhasil tambah data")
            aturdgv()
            kosong()
        End If
    End Sub

    Sub aturdgv()
        sql = "SELECT * From spp"
        da = New SqlDataAdapter(sql, con)
        ds = New DataSet
        da.Fill(ds, "spp")
        dgv_user.DataSource = ds.Tables("spp")
    End Sub

    Sub kosong()
        cbidspp.Text = ""
        txttahun.Text = ""
        txtnom.Text = ""
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If cbidspp.Text = "" Or txttahun.Text = "" Or txtnom.Text = "" Then
            MsgBox("Pastikan mengisi semua field dengan benar")
        Else
            sql = "UPDATE spp set tahun='" & txttahun.Text & "',nominal='" & txtnom.Text & "'where id_spp='" & cbidspp.Text & "'"
            cmd = New SqlCommand(sql, con)
            cmd.ExecuteNonQuery()
            MsgBox("Berhasil edit data")
            aturdgv()
            kosong()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If cbidspp.Text = "" Or txttahun.Text = "" Or txtnom.Text = "" Then
            MsgBox("Pastikan mengisi semua field dengan benar")
        Else
            sql = "DELETE FROM spp where id_spp='" & cbidspp.Text & "'"
            cmd = New SqlCommand(sql, con)
            cmd.ExecuteNonQuery()
            MsgBox("Berhasil hapus data")
            aturdgv()
            kosong()
        End If
    End Sub

    Private Sub dgv_user_MouseClick(sender As Object, e As MouseEventArgs) Handles dgv_user.MouseClick
        cbidspp.Text = dgv_user.Rows(dgv_user.CurrentRow.Index).Cells(0).Value
        txttahun.Text = dgv_user.Rows(dgv_user.CurrentRow.Index).Cells(1).Value
        txtnom.Text = dgv_user.Rows(dgv_user.CurrentRow.Index).Cells(2).Value
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcari.KeyPress
        sql = "SELECT * From spp where (tahun like '%" & txtcari.Text & "%')"
        da = New SqlDataAdapter(sql, con)
        ds = New DataSet
        da.Fill(ds, "spp")
        dgv_user.DataSource = ds.Tables("spp")
    End Sub

    Private Sub KelolaSpp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connect()
        aturdgv()
    End Sub

    Private Sub cbidspp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbidspp.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            MsgBox("Pastikan angka yang di inputkan")
            e.Handled = True
        End If
    End Sub

    Private Sub txttahun_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txttahun.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            MsgBox("Pastikan angka yang di inputkan")
            e.Handled = True
        End If
    End Sub

    Private Sub txtnom_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnom.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            MsgBox("Pastikan angka yang di inputkan")
            e.Handled = True
        End If
    End Sub
End Class