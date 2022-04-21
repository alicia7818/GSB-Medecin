Imports MySql.Data.MySqlClient
Public Class admin_modif
    Dim COMMAND As MySqlCommand
    Dim COMMAND1 As MySqlCommand
    Dim COMMAND2 As MySqlCommand
    Dim Query As String
    Dim Query1 As String
    Dim Query2 As String
    Dim READER As MySqlDataReader
    Dim READER1 As MySqlDataReader
    Dim READER2 As MySqlDataReader
    Dim MysqlConn = New MySqlConnection("server=localhost;userid=root;password=;database=gsbappart2")
    Dim asc As Integer
    Dim req As Integer
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim connection As New MySqlConnection("server=localhost;userid=root;password=;database=gsbappart2")
            Dim command As New MySqlCommand("delete from utilisateur where nom='" & ComboBox4.Text & "'", connection)
            Dim command1 As New MySqlCommand("delete from utilisateur where nom='" & ComboBox5.Text & "'", connection)
            Dim command2 As New MySqlCommand("delete from appartement where rue_appart='" & ComboBox6.Text & "'", connection)
            'Dim dataReader As MySqlDataReader
            connection.Open()
            command.ExecuteNonQuery()
            command1.ExecuteNonQuery()
            command2.ExecuteNonQuery()
            connection.Close()
            MsgBox("Suppression réussi !", MsgBoxStyle.OkOnly)
        Catch ex As Exception
            MsgBox("Veuillez réessayer", MsgBoxStyle.OkOnly)
        End Try
    End Sub
    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Label1.Visible = True Then
            'login
            Label2.Visible = True
            TextBox11.Visible = True
            'mdp
            Label3.Visible = True
            TextBox1.Visible = True
            'nom
            Label10.Visible = True
            TextBox2.Visible = True
            'prenom
            Label11.Visible = True
            TextBox3.Visible = True
            'adresse
            Label15.Visible = True
            TextBox10.Visible = True
            'ville
            Label14.Visible = True
            TextBox12.Visible = True
            'cp
            Label13.Visible = True
            TextBox13.Visible = True
            'tel
            Label12.Visible = True
            TextBox14.Visible = True
            'rib
            Label36.Visible = True
            TextBox18.Visible = True
            'nom banque
            Label18.Visible = True
            TextBox17.Visible = True
            'adresse banque
            Label20.Visible = True
            TextBox19.Visible = True
            'ville banque
            Label16.Visible = True
            TextBox16.Visible = True
            'cp banque
            Label23.Visible = True
            TextBox15.Visible = True
        ElseIf Label5.Visible = True Then
            'login
            Label2.Visible = True
            TextBox11.Visible = True
            'mdp
            Label3.Visible = True
            TextBox1.Visible = True
            'nom
            Label10.Visible = True
            TextBox2.Visible = True
            'prenom
            Label11.Visible = True
            TextBox3.Visible = True
            'adresse
            Label15.Visible = True
            TextBox10.Visible = True
            'ville
            Label14.Visible = True
            TextBox12.Visible = True
            'cp
            Label13.Visible = True
            TextBox13.Visible = True
            'tel
            Label12.Visible = True
            TextBox14.Visible = True
        ElseIf Label6.Visible = True Then
            'adresse
            Label32.Visible = True
            TextBox11.Visible = True
            'cp
            Label31.Visible = True
            TextBox1.Visible = True
            'ville
            Label30.Visible = True
            TextBox2.Visible = True
            'prix
            Label29.Visible = True
            TextBox3.Visible = True
            'charge
            Label25.Visible = True
            TextBox10.Visible = True
            'etage
            Label26.Visible = True
            TextBox12.Visible = True
            'type
            Label27.Visible = True
            TextBox13.Visible = True
            'ascenseur
            Label28.Visible = True
            ComboBox1.Visible = True
            'proprietaire
            Label22.Visible = True
            ComboBox2.Visible = True

            ComboBox1.Items.Add("Oui")
            ComboBox1.Items.Add("Non")

            Query = "select * from utilisateur where role='proprietaire'"
            MysqlConn.Open()
            COMMAND = New MySqlCommand(Query, MysqlConn)
            READER = COMMAND.ExecuteReader
            While READER.Read()
                ComboBox2.Items.Add(READER.GetString("nom")) 'prop
            End While
            MysqlConn.Dispose()
        End If
        Query = "select * from utilisateur where role='proprietaire'"
        MysqlConn.Open()
        COMMAND = New MySqlCommand(Query, MysqlConn)
        READER = COMMAND.ExecuteReader
        While READER.Read()
            ComboBox7.Items.Add(READER.GetString("nom")) 'prop
        End While
        MysqlConn.Dispose()
        ComboBox8.Items.Add("Oui")
        ComboBox8.Items.Add("Non")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Panel2.Visible = True Then
            If ComboBox1.Text = "Oui" Then
                Asc = 1
            Else
                Asc = 0
            End If
            Query = "UPDATE appartement set rue_appart='" & TextBox20.Text & "', `cp_appart`='" & TextBox23.Text & "', `ville_appart`='" & TextBox24.Text & "', `prix_loc`='" & TextBox22.Text & "', `prix_charge`='" & TextBox21.Text & "', `etage`='" & TextBox14.Text & "', `type_appart`='" & TextBox4.Text & "', `ascenseur`= '" & asc & "', `id_user`= (Select id_user from utilisateur where nom='" & ComboBox2.Text & "') "
            MysqlConn.dispose()
            MysqlConn.Open()
            COMMAND = New MySqlCommand(Query, MysqlConn)
            READER = COMMAND.ExecuteReader
            MysqlConn.dispose()
        End If
        If Label6.Visible = True Then
            If ComboBox1.Text = "Oui" Then
                Asc = 1
            Else
                Asc = 0
            End If
            Query = "INSERT INTO `appartement`(`rue_appart`, `cp_appart`, `ville_appart`, `prix_loc`, `prix_charge`, `etage`, `type_appart`, `ascenseur`, `id_user`) VALUES(' " & TextBox11.Text & " ','" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox10.Text & "','" & TextBox12.Text & "','" & TextBox13.Text & "','" & asc & "',(Select id_user from utilisateur where nom='" & ComboBox2.Text & "'))"
            MysqlConn.Open()
            COMMAND = New MySqlCommand(Query, MysqlConn)
            READER = COMMAND.ExecuteReader
            MysqlConn.dispose()
        ElseIf Label5.Visible Then
            Query = " INSERT INTO `utilisateur`(`login`, `mdp`, `role`, `nom`, `prenom`, `adresse`, `ville`, `cp`, `tel`) VALUES(' " & TextBox11.Text & " ','" & TextBox1.Text & "','proprietaire','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox10.Text & "','" & TextBox12.Text & "','" & TextBox13.Text & "','" & TextBox14.Text & "')"

            MysqlConn.Open()
            COMMAND = New MySqlCommand(Query, MysqlConn)
            READER = COMMAND.ExecuteReader
            MysqlConn.dispose()

            Query1 = "(Select id_user from utilisateur where login='" & TextBox11.Text & "')"

            COMMAND1 = New MySqlCommand(Query1, MysqlConn)
            MysqlConn.Open()
            READER1 = COMMAND1.ExecuteReader
            While READER1.Read()
                req = READER1.GetString("id_user")
            End While
            MysqlConn.DISPOSE()

            Query2 = "INSERT INTO `propriétaire` (id_user, photo_proprietaire) values (" & req & ", 'a') "
            COMMAND2 = New MySqlCommand(Query2, MysqlConn)
            MysqlConn.Open()
            READER2 = COMMAND2.ExecuteReader
            MysqlConn.DISPOSE()
        ElseIf Label1.Visible Then
            Query = " INSERT INTO `utilisateur`(`login`, `mdp`, `role`, `nom`, `prenom`, `adresse`, `ville`, `cp`, `tel`) VALUES(' " & TextBox11.Text & " ','" & TextBox1.Text & "','locataire','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox10.Text & "','" & TextBox12.Text & "','" & TextBox13.Text & "','" & TextBox14.Text & "')"
            Query1 = "(Select id_user from utilisateur where login='" & TextBox11.Text & "')"
            COMMAND1 = New MySqlCommand(Query1, MysqlConn)
            MysqlConn.Open()
            READER1 = COMMAND1.ExecuteReader
            While READER1.Read()
                REQ = READER1.GetString("id_user")
            End While
            MysqlConn.DISPOSE()
            Query2 = "INSERT INTO `locataire`(`id_user`, `rib`, `banque`, `rue_banque`, `ville_banque`, `cp_banque`) values (" & req & ", '" & TextBox18.Text & "', '" & TextBox17.Text & "', '" & TextBox19.Text & "', '" & TextBox16.Text & "', '" & TextBox15.Text & "')  "


            COMMAND = New MySqlCommand(Query, MysqlConn)
            MysqlConn.Open()
            READER = COMMAND.ExecuteReader
            MysqlConn.DISPOSE()



            COMMAND2 = New MySqlCommand(Query2, MysqlConn)
            MysqlConn.Open()
            READER2 = COMMAND2.ExecuteReader
            MysqlConn.DISPOSE()
        End If

    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged

        Query = "Select * from appartement, utilisateur where rue_appart = '" & ComboBox3.Text & "' and appartement.id_user=utilisateur.id_user "
        MysqlConn.Open()
        COMMAND = New MySqlCommand(Query, MysqlConn)
        READER = COMMAND.ExecuteReader
        While READER.Read
            TextBox20.Text = READER.GetString("rue_appart")
            TextBox24.Text = READER.GetString("ville_appart")
            TextBox23.Text = READER.GetString("cp_appart")
            TextBox14.Text = READER.GetString("etage")
            TextBox22.Text = READER.GetString("prix_loc")
            TextBox21.Text = READER.GetString("prix_charge")
            TextBox4.Text = READER.GetString("type_appart")
            ComboBox7.Text = READER.GetString("nom")
            If READER.GetString("ascenseur") = True Then
                ComboBox8.Text = "Oui"
            Else
                ComboBox8.Text = "Non"
            End If
        End While
        MysqlConn.dispose()
    End Sub
End Class