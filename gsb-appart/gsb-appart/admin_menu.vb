Imports MySql.Data.MySqlClient
Public Class admin_menu
    Dim MysqlConn As MySqlConnection
    Dim COMMAND As MySqlCommand
    Dim Query As String
    Dim READER As MySqlDataReader

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = False Then
            Button4.Visible = False
            Button2.Visible = False
            Button3.Visible = False
        Else
            Button4.Visible = True
            Button2.Visible = True
            Button3.Visible = True
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = False Then
            Button4.Visible = False
            Button2.Visible = False
            Button3.Visible = False
        Else
            Button4.Visible = False
            Button2.Visible = False
            Button3.Visible = True

        End If
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked = False Then
            Button4.Visible = False
            Button2.Visible = False
            Button3.Visible = False
        Else
            Button4.Visible = True
            Button2.Visible = True
            Button3.Visible = True
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If CheckBox1.Checked Then
            admin_modif.Label1.Visible = True
            admin_modif.Panel1.Visible = True
            admin_modif.Panel2.Visible = False
            admin_modif.Panel3.Visible = False
        ElseIf CheckBox3.Checked Then
            admin_modif.Panel1.Visible = False
            admin_modif.Panel2.Visible = False
            admin_modif.Panel3.Visible = True
            admin_modif.Label7.Visible = True
            admin_modif.ComboBox4.Visible = True
        End If
        admin_modif.Show()
        Query = "select * from utilisateur where role='locataire'"
        MysqlConn.Dispose()
        MysqlConn.Open()
        COMMAND = New MySqlCommand(Query, MysqlConn)
        READER = COMMAND.ExecuteReader
        While READER.Read()
            admin_modif.ComboBox4.Items.Add(READER.GetString("nom"))
        End While
        MysqlConn.Dispose()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If CheckBox1.Checked Then
            admin_modif.Label6.Visible = True
            admin_modif.Panel1.Visible = True
            admin_modif.Panel2.Visible = False
            admin_modif.Panel3.Visible = False
        ElseIf CheckBox2.Checked Then
            admin_modif.Panel1.Visible = False
            admin_modif.Panel3.Visible = False
            admin_modif.Panel2.Visible = True
            Query = "select * from appartement"
            MysqlConn.Dispose()
            MysqlConn.Open()
            COMMAND = New MySqlCommand(Query, MysqlConn)
            READER = COMMAND.ExecuteReader
            While READER.Read()
                admin_modif.ComboBox3.Items.Add(READER.GetString("rue_appart"))
            End While
            MysqlConn.Dispose()
        ElseIf CheckBox3.Checked Then
            admin_modif.Panel1.Visible = False
            admin_modif.Panel2.Visible = False
            admin_modif.Panel3.Visible = True
            admin_modif.Label8.Visible = True
            admin_modif.ComboBox6.Visible = True
            Query = "select * from appartement"
            MysqlConn.Open()
            COMMAND = New MySqlCommand(Query, MysqlConn)
            READER = COMMAND.ExecuteReader
            While READER.Read()
                admin_modif.ComboBox6.Items.Add(READER.GetString("rue_appart"))
            End While
            MysqlConn.Dispose()
        End If
        admin_modif.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If CheckBox1.Checked Then
            admin_modif.Label5.Visible = True
            admin_modif.Panel1.Visible = True
            admin_modif.Panel2.Visible = False
            admin_modif.Panel3.Visible = False
        ElseIf CheckBox3.Checked Then
            admin_modif.Panel1.Visible = False
            admin_modif.Panel2.Visible = False
            admin_modif.Panel3.Visible = True
            admin_modif.Label9.Visible = True
            admin_modif.ComboBox5.Visible = True
            Query = "select * from utilisateur where role='proprietaire'"
            MysqlConn.Dispose()
            MysqlConn.Open()
            COMMAND = New MySqlCommand(Query, MysqlConn)
            READER = COMMAND.ExecuteReader
            While READER.Read()
                admin_modif.ComboBox5.Items.Add(READER.GetString("nom")) 'prop
            End While
            MysqlConn.Dispose()
        End If
        admin_modif.Show()
    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = "server=localhost;userid=root;password=;database=gsbappart2"

        'afficher demandes
        Dim command As New MySqlCommand("select * from demande where statut='en cours'", MysqlConn)
        Dim dataReader As MySqlDataReader
        MysqlConn.Dispose()

        MysqlConn.Open()
        dataReader = command.ExecuteReader()
        While dataReader.Read()
            DataGridView1.Rows.Add(dataReader("id_demande"), "voir", "accepter", "refuser")
        End While
        MysqlConn.Dispose()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Panel1.Visible = True
        Panel3.Visible = False
        Panel2.Visible = False
        Panel4.Visible = False
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Panel1.Visible = False
        Panel3.Visible = False
        Panel2.Visible = True
        Panel4.Visible = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Panel1.Visible = False
        Panel3.Visible = True
        Panel2.Visible = False
        Panel4.Visible = False
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim i As Integer
        For i = 0 To DataGridView1.Rows.Count - 1
            Dim Command As New MySqlCommand("select * from demande where id_demande='" & DataGridView1.Rows(e.RowIndex).Cells.Item(0).Value & "'", MysqlConn)
            Dim dataReader As MySqlDataReader
            MysqlConn.Close()
            MysqlConn.Open()
            dataReader = Command.ExecuteReader()
            While dataReader.Read()
                If DataGridView1.CurrentCell.Value = "accepter" Then 'accepter
                    MysqlConn.Close()
                    Command = New MySqlCommand("update demande set statut='accepté' where id_demande=" & DataGridView1.Rows(e.RowIndex).Cells.Item(0).Value & "", MysqlConn)
                    MysqlConn.Open()
                    dataReader = Command.ExecuteReader()
                    MysqlConn.Close()
                    MsgBox("Demande acceptée.", MsgBoxStyle.OkOnly)
                    '     Command = New MySqlCommand("alter table louer values ('(select id_user from locataire, utilisateur, demande where demande.id_user=utilisateur.id_user and locataire.id_user=demande.id_user and id_demande='" & DataGridView1.Rows(e.RowIndex).Cells.Item(0).Value & "'), '')", MysqlConn)
                    '         MysqlConn.Open()
                    '         dataReader = Command.ExecuteReader()
                    '      MysqlConn.Close()
                ElseIf DataGridView1.CurrentCell.Value = "refuser" Then 'refuser
                    MysqlConn.Close()
                    Command = New MySqlCommand("update demande Set statut='refusé' where id_demande='" & DataGridView1.Rows(e.RowIndex).Cells.Item(0).Value & "'", MysqlConn)
                    MysqlConn.Open()
                    dataReader = Command.ExecuteReader()
                    MysqlConn.Close()
                    MsgBox("Demande refusée.", MsgBoxStyle.OkOnly)
                ElseIf DataGridView1.CurrentCell.Value = "voir" Then 'profil
                    MysqlConn.Close()
                    Panel1.Visible = False
                    Panel2.Visible = False
                    Panel3.Visible = False
                    Panel4.Visible = True
                    Command = New MySqlCommand("select * from locataire, utilisateur, demande where demande.id_user=utilisateur.id_user and locataire.id_user=demande.id_user and id_demande='" & DataGridView1.Rows(e.RowIndex).Cells.Item(0).Value & "'", MysqlConn)
                    MysqlConn.Open()
                    dataReader = Command.ExecuteReader()
                    While dataReader.Read()
                        Label4.Text = "Nom : " & dataReader.GetString("nom")
                        Label5.Text = "Prénom : " & dataReader.GetString("prenom")
                        Label6.Text = "Téléphone : " & dataReader.GetString("tel")
                        Label7.Text = "Adresse : " & dataReader.GetString("adresse")
                        Label8.Text = "Ville : " & dataReader.GetString("ville")
                        Label9.Text = "Code postal : " & dataReader.GetString("cp")
                        Label10.Text = "RIB : " & dataReader.GetString("rib")
                        Label11.Text = "Nom de la banque : " & dataReader.GetString("banque")
                        Label12.Text = "Adresse de la banque : " & dataReader.GetString("rue_banque")
                        Label13.Text = "Ville de la banque : " & dataReader.GetString("ville_banque")
                        Label14.Text = "Code postal : " & dataReader.GetString("cp_banque")
                    End While
                    MysqlConn.Close()

                End If
                Exit For
            End While
        Next
    End Sub
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        Button6.Visible = False
    End Sub
End Class