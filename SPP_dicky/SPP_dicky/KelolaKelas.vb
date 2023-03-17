Imports System.Data.SqlClient

Public Class KelolaKelas
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Admin.Show()
        Me.Hide()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        connect()
        If txtidkls.Text = "" Or txtnama.Text = "" Or txtkom.Text = "" Then
            MsgBox("Pastikan mengisi semua field dengan benar")
        Else
            sql = "INSERT into kelas (id_kelas, nama_kelas, kompetensi_keahlian) VALUES ('" & txtidkls.Text & "', '" & txtnama.Text & "','" & txtkom.Text & "')"
            cmd = New SqlCommand(sql, con)
            cmd.ExecuteNonQuery()
            MsgBox("Berhasil tambah data")
            aturdgv()
            kosong()
        End If
    End Sub
    Sub aturdgv()
        sql = "SELECT * From kelas"
        da = New SqlDataAdapter(sql, con)
        ds = New DataSet
        da.Fill(ds, "kelas")
        dgv_user.DataSource = ds.Tables("kelas")
    End Sub

    Sub kosong()
        txtidkls.Text = ""
        txtnama.Text = ""
        txtkom.Text = ""
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If txtidkls.Text = "" Or txtnama.Text = "" Or txtkom.Text = "" Then
            MsgBox("Pastikan mengisi semua field dengan benar")
        Else
            sql = "UPDATE kelas set nama_kelas='" & txtnama.Text & "',kompetensi_keahlian='" & txtkom.Text & "'where id_kelas='" & txtidkls.Text & "'"
            cmd = New SqlCommand(sql, con)
            cmd.ExecuteNonQuery()
            MsgBox("Berhasil edit data")
            aturdgv()
            kosong()
        End If
    End Sub

    Private Sub KelolaKelas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connect()
        aturdgv()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If txtidkls.Text = "" Or txtnama.Text = "" Or txtkom.Text = "" Then
            MsgBox("Pastikan mengisi semua field dengan benar")
        Else
            sql = "DELETE FROM kelas where id_kelas='" & txtidkls.Text & "'"
            cmd = New SqlCommand(sql, con)
            cmd.ExecuteNonQuery()
            MsgBox("Berhasil hapus data")
            aturdgv()
            kosong()
        End If
    End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcari.KeyPress
        sql = "SELECT * From kelas where (nama_kelas like '%" & txtcari.Text & "%')"
        da = New SqlDataAdapter(sql, con)
        ds = New DataSet
        da.Fill(ds, "kelas")
        dgv_user.DataSource = ds.Tables("kelas")
    End Sub

    Private Sub dgv_user_MouseClick(sender As Object, e As MouseEventArgs) Handles dgv_user.MouseClick
        txtidkls.Text = dgv_user.Rows(dgv_user.CurrentRow.Index).Cells(0).Value
        txtnama.Text = dgv_user.Rows(dgv_user.CurrentRow.Index).Cells(1).Value
        txtkom.Text = dgv_user.Rows(dgv_user.CurrentRow.Index).Cells(2).Value
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub txtidkls_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtidkls.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            MsgBox("Pastikan angka yang di inputkan")
            e.Handled = True
        End If
    End Sub
End Class