Imports System.IO
Imports MySql.Data.MySqlClient
Imports System.ComponentModel

Public Class loc_menu
    Dim connection As New MySqlConnection("server=localhost;userid=root;password=;database=gsbappart2")
    Dim command As New MySqlCommand
    Dim datareader As MySqlDataReader

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        connection.Dispose()
        Panel2.Visible = True
        Panel1.Visible = False
        Panel3.Visible = False
        Panel4.Visible = False
        Button4.Visible = True
        'afficher demandes
        Dim command As New MySqlCommand("select statut, rue_appart from demande, appartement, utilisateur where demande.id_appartement=appartement.id_appartement and demande.id_user=utilisateur.id_user and login='" & authentification.TextBox1.Text & "'", connection)
        Dim dataReader As MySqlDataReader
        connection.Open()
        dataReader = command.ExecuteReader()
        While dataReader.Read()
            DataGridView1.Rows.Add(dataReader("rue_appart"), dataReader("statut"))
        End While
        connection.Dispose()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        connection.Dispose()
        Panel1.Visible = False
        Panel3.Visible = True
        Panel2.Visible = False
        Panel4.Visible = False
        Button4.Visible = True
        'afficher appartements
        Dim j As Integer = 1
        command = New MySqlCommand("select * from appartement where id_appartement not in (select id_appartement from louer)", connection)
        connection.Open()
        datareader = command.ExecuteReader()
        While datareader.Read()
            DataGridView2.Rows.Add(datareader("id_appartement"), datareader("type_appart"), datareader("ville_appart"), datareader("prix_loc"))
        End While
        connection.Dispose()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        connection.Dispose()
        Panel1.Visible = False
        Panel4.Visible = True
        Panel2.Visible = False
        Panel3.Visible = False
        Button4.Visible = True
        command = New MySqlCommand("select * from locataire, utilisateur where login='" & authentification.TextBox1.Text & "'", connection)
        connection.Open()
        datareader = command.ExecuteReader()
        While datareader.Read()
            Label4.Text = "Nom : " & datareader.GetString("nom")
            Label5.Text = "Prénom : " & datareader.GetString("prenom")
            Label6.Text = "Téléphone : " & datareader.GetString("tel")
            Label7.Text = "Adresse : " & datareader.GetString("adresse")
            Label8.Text = "Ville : " & datareader.GetString("ville")
            Label9.Text = "Code postal : " & datareader.GetString("cp")
            Label10.Text = "RIB : " & datareader.GetString("rib")
            Label11.Text = "Nom de la banque : " & datareader.GetString("banque")
            Label12.Text = "Adresse de la banque : " & datareader.GetString("rue_banque")
            Label13.Text = "Ville de la banque : " & datareader.GetString("ville_banque")
            Label14.Text = "Code postal : " & datareader.GetString("cp_banque")
        End While
        connection.Dispose()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Panel1.Visible = True
        Panel4.Visible = False
        Panel2.Visible = False
        Panel3.Visible = False
        If Panel5.Visible = True Then
            Panel5.Visible = False
            Panel1.Visible = False
            Panel4.Visible = False
            Panel2.Visible = False
            Panel3.Visible = True
        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        Button4.Visible = False
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel1.Visible = True
        Panel4.Visible = False
        Panel2.Visible = False
        Panel3.Visible = False
    End Sub
    Private Sub DataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        connection.Dispose()
        Dim i As Integer
        For i = 0 To DataGridView2.Rows.Count - 1
            Dim Command As New MySqlCommand("select * from appartement where id_appartement='" & DataGridView2.Rows(e.RowIndex).Cells.Item(0).Value & "'", connection)
            Dim dataReader As MySqlDataReader
            connection.Open()
            dataReader = Command.ExecuteReader()
            While dataReader.Read()
                Panel5.Visible = True
                Label17.Text = "Adresse : " & dataReader.GetString("rue_appart")
                Label18.Text = "Ville : " & dataReader.GetString("ville_appart")
                Label19.Text = "Code postal : " & dataReader.GetString("cp_appart")
                Label20.Text = "Type : " & dataReader.GetString("type_appart")
                Label21.Text = "Prix : " & dataReader.GetString("prix_loc")
                Label22.Text = "Charges : " & dataReader.GetString("prix_charge")
                Label23.Text = "Etage : " & dataReader.GetString("etage")
                Label25.Text = dataReader.GetString("id_appartement")
                If dataReader.GetString("ascenseur") = True Then
                    Label24.Text = "Ascenseur : oui"
                Else
                    Label24.Text = "Ascenseur : non"
                End If
                PictureBox1.Image = Image.FromFile(dataReader.GetString("chemin_photo"))
                Exit For
            End While
        Next
        connection.Dispose()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        connection.Dispose()
        Try
            Dim Command As New MySqlCommand("INSERT INTO `demande`(`statut`, `id_appartement`, `id_user`) VALUES ('en cours'," & Label25.Text & "," & authentification.Label3.Text & ")", connection)
            'Dim command2 As New MySqlCommand("select statut, rue_appart from demande, appartement, utilisateur where demande.id_appartement=appartement.id_appartement and demande.id_user=utilisateur.id_user and login='" & authentification.TextBox1.Text & "'", connection)
            Dim dataReader As MySqlDataReader
            'Dim dataReader2 As MySqlDataReader
            connection.Open()
            dataReader = Command.ExecuteReader()
            MsgBox("Demande envoyée !", MsgBoxStyle.OkOnly)
            Panel5.Visible = False
            'connection.Close()
            'connection.Open()
            'dataReader2 = command2.ExecuteReader()
            'While dataReader2.Read()
            '    DataGridView1.Rows.Add(dataReader("rue_appart"), dataReader("statut"))
            'End While
        Catch ex As Exception
            MsgBox("Une erreur s'est produite, veuillez réessayer.", MsgBoxStyle.OkOnly)
        End Try
        connection.Dispose()

    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        'prix
        If CheckBox1.Checked Then
            DataGridView2.Sort(DataGridView2.Columns(3), ListSortDirection.Ascending)
        End If

        'type
        If CheckBox2.Checked Then
            DataGridView2.Sort(DataGridView2.Columns(1), ListSortDirection.Ascending)
        End If

        'ville
        If CheckBox3.Checked Then
            DataGridView2.Sort(DataGridView2.Columns(2), ListSortDirection.Ascending)
        End If
    End Sub
End Class