Imports MySql.Data.MySqlClient
Public Class authentification
    Dim MysqlConn As MySqlConnection
    Dim COMMAND As MySqlCommand
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = "server=localhost;userid=root;password=;database=gsbappart2"
        Dim READER As MySqlDataReader
        Try
            MysqlConn.Open()

            Dim Query As String
            Query = "select role, id_user from utilisateur where login='" & TextBox1.Text & "' and mdp='" & TextBox2.Text & "'"

            COMMAND = New MySqlCommand(Query, MysqlConn)
            READER = COMMAND.ExecuteReader
            Dim count As Integer
            count = 0
            While READER.Read
                count = count + 1
                Label3.Text = READER.GetString("id_user")
            End While

            Dim role = READER.GetString(“role”)

            If count = 1 Then
                Me.Visible = False
                If role = "locataire" Then
                    loc_menu.Show()
                ElseIf role = "proprietaire" Then
                    prop_menu.Show()
                ElseIf role = "administrateur" Then
                    admin_menu.Show()
                End If
            ElseIf count > 1 Then
                MessageBox.Show("Username and password are Duplicate")
            Else
                MessageBox.Show("Username or password are not correct")
            End If

        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            MysqlConn.Dispose()

        End Try

    End Sub
End Class