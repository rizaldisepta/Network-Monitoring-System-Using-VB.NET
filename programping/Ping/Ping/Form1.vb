Imports System.Net.NetworkInformation
Imports System.IO
Imports System.IO.Ports
Imports System.Threading
Imports System.Threading.Thread
Imports MySql.Data.MySqlClient
Public Class Form1

    Dim N As Double
    Private Tunda As Integer
    Private WithEvents COMport As New SerialPort
    Dim koneksistring As String = "Server = localhost; USERID = root; PASSWORD = ; DATABASE = ipcustomer;"
    Dim koneksi As New MySqlConnection(koneksistring)
    Dim koneksiteknisi As New MySqlConnection(koneksistring)
    Dim koneksihistory As New MySqlConnection(koneksistring)
    Dim sqlQuery As String = "Select * from customer"
    Dim sqlQuery2 As String = "Select * from teknisi"
    Dim sqlQuery3 As String = "Select * from history"

    Dim sqlAdapeter As New MySqlDataAdapter

    Dim sqlCommand As New MySqlCommand

    Dim tabel As New DataTable
    Dim tabel2 As New DataTable
    Dim tabel3 As New DataTable


    Dim cmd As New MySqlCommand("SELECT COUNT(*) FROM customer ", koneksi)
    Dim stopclick As Boolean = False
    Dim ulang As Integer
    Dim a As Double
    Dim ButtonOneClick As Boolean
    Private Sub loadhistory()

        Dim x As Double
        x += 1
        Dim z As Double
        z = 0


        With sqlCommand
            .CommandText = sqlQuery3
            .Connection = koneksihistory
        End With

        With sqlAdapeter
            .SelectCommand = sqlCommand
            .Fill(tabel3)




        End With


     



        For Me.a = 0 To tabel3.Rows.Count - 1

            With ListView3



                .Items.Add(tabel3.Rows(a)("Id_hist"))


                With .Items(.Items.Count - 1).SubItems

                    .Add(tabel3.Rows(a)("Id_cust"))

                    .Add(tabel3.Rows(a)("Status_Network"))
                    .Add(tabel3.Rows(a)("Tanggal_Waktu"))





                End With
            End With

        Next
    End Sub
    Private Sub loadteknisi()

        Dim x As Double
        x += 1
        Dim z As Double
        z = 0


        With sqlCommand
            .CommandText = sqlQuery2
            .Connection = koneksiteknisi
        End With

        With sqlAdapeter
            .SelectCommand = sqlCommand
            .Fill(tabel2)




        End With

        'For a As Double = 0 To tabel2.Rows.Count - 1
        'Next

        





        For Me.a = 0 To tabel2.Rows.Count - 1

            
           

            With ListView2



                .Items.Add(tabel2.Rows(a)("id_teknisi"))


                With .Items(.Items.Count - 1).SubItems

                    .Add(tabel2.Rows(a)("Nama"))

                    .Add(tabel2.Rows(a)("No_telepon"))




                End With
            End With

        Next
    End Sub
    Private Sub loadpeople()
        Dim b As Integer = cmd.ExecuteScalar()
        Dim x As Double
        x += 1
        Dim z As Double
        z = 0


        With sqlCommand
            .CommandText = sqlQuery
            .Connection = koneksi
        End With

        With sqlAdapeter
            .SelectCommand = sqlCommand
            .Fill(tabel)




        End With


        TextBox4.Text = (tabel.Rows(N)("Id_Cust")).ToString
        TextBox1.Text = (tabel.Rows(N)("Ip")).ToString
        TextBox2.Text = (tabel.Rows(N)("Nama")).ToString
        CmbStatus.Text = (tabel.Rows(N)("Status")).ToString
        txtKategori.Text = (tabel.Rows(N)("kategori")).ToString



        For Me.a = 0 To tabel.Rows.Count - 1

            With ListView1

                TextBox3.Text = b

                .Items.Add(tabel.Rows(a)("Id_cust"))


                With .Items(.Items.Count - 1).SubItems

                    .Add(tabel.Rows(a)("Nama"))

                    .Add(tabel.Rows(a)("Ip"))
                    .Add(tabel.Rows(a)("Status"))
                    .Add(tabel.Rows(a)("kategori"))

                End With

            End With

        Next


    End Sub

    Public Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



        With cmbinsstatus
            cmbinsstatus.Items.Add("lancar")
            cmbinsstatus.Items.Add("intermittent")
            cmbinsstatus.Items.Add("putus")
            cmbinsstatus.Items.Add("tidak aktif")
        End With
        With cmbKategori
            cmbKategori.Items.Add("1")
            cmbKategori.Items.Add("2")
            cmbKategori.Items.Add("3")
            cmbKategori.Items.Add("4")
            cmbKategori.Items.Add("5")
            cmbKategori.Items.Add("6")
            cmbKategori.Items.Add("7")
        End With

        'Try
        If koneksi.State = ConnectionState.Closed Then

            koneksi.Open()
            koneksiteknisi.Open()
            koneksihistory.Open()

        End If

        loadpeople()
        retriveteknisi()
        retrivehistory()

        TextBox6.Text = ListView1.Items(0).SubItems(3).Text

        For Each COMString As String In My.Computer.Ports.SerialPortNames
            cmbKoneksi.Items.Add(COMString)
        Next
        cmbKoneksi.Sorted = True
        'Catch ex As Exception
        '    MsgBox("Hidupkan Xampp Terlebih Dahulu")
        '    Application.Exit()
        'End Try

    End Sub



    'Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
    '    koneksi = New MySqlConnection
    '    koneksi.ConnectionString = "server=localhost;userid=root;password= ;database=ipcustomer"



    '    Dim sqlAdapeter As New MySqlDataAdapter

    '    Dim sqlCommand As New MySqlCommand
    '    Dim tabel As New DataTable
    '    Dim bSource As New BindingSource
    '    Try
    '        koneksi.Open()
    '        Dim sqlQuery As String = "Select * from customer"
    '        sqlCommand = New MySqlCommand(sqlQuery, koneksi)
    '        sqlAdapeter.SelectCommand = sqlCommand
    '        sqlAdapeter.Fill(tabel)
    '        bSource.DataSource = tabel
    '        DataGridView1.DataSource = bSource
    '        sqlAdapeter.Update(tabel)
    '        koneksi.Close()

    '    Catch ex As Exception
    '    Finally
    '        koneksi.Dispose()
    '    End Try

    'End Sub

    Private Sub RectangleShape2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Panel1.Visible = True
        Panel3.Visible = False
        Panel5.Visible = False
        Panel6.Visible = False
        Panel7.Visible = True

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles BtnCustomer.Click
        Panel3.Visible = True
        Panel1.Visible = False
        Panel5.Visible = True
        Panel6.Visible = False
        Panel7.Visible = False
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs)






    End Sub


    Dim myToken As CancellationTokenSource
    
   
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Button2.Enabled = True
        If My.Computer.Network.IsAvailable = True Then

            SendPings()
        Else
            MsgBox("Not Connect")

        End If

    End Sub

    Private Async Sub SendPings()
        Try
            Dim ak As Integer

            Dim koneksiping As Double


            For ulang As Integer = 0 To 2
                ulang -= 1
                If ListBox1.Items.Count > 5 Then
                    ListBox1.Items.Clear()
                    ListBox2.Items.Clear()

                    Thread.Sleep(500)

                    'Do Untixl (perulangan row database)

                    Try
                        Application.DoEvents()
                        N += 1
                        ak += 1
                        Application.DoEvents()
                        CmbStatus.Text = (tabel.Rows(N)("Status")).ToString
                        TextBox1.Text = (tabel.Rows(N)("Ip")).ToString
                        TextBox2.Text = (tabel.Rows(N)("Nama")).ToString
                        TextBox4.Text = (tabel.Rows(N)("Id_cust")).ToString
                        txtKategori.Text = (tabel.Rows(N)("kategori")).ToString
                        TextBox6.Text = ListView1.Items(ak).SubItems(3).Text

                    Catch ex As Exception

                    End Try

                    'Loop


                    '    Next
                    'Next

                End If
                Dim MyPing As New Net.NetworkInformation.Ping

                Dim MyReply As PingReply = Await MyPing.SendPingAsync(TextBox1.Text, 250)
                Thread.Sleep(500)
                'If TextBox6.Text = False Then
                '    TextBox1.Text=mit

                koneksiping = MyReply.RoundtripTime
                'End If
                If MyReply.RoundtripTime >= 0 & MyReply.Status = True And TextBox6.Text = "lancar" Then
                    Thread.Sleep(500)
                    ListBox1.Items.Add(MyReply.RoundtripTime)
                    Label1.Text = (koneksiping)



                ElseIf MyReply.RoundtripTime >= 0 & MyReply.Status = True And TextBox6.Text = "tidak aktif" Then
                    ListBox2.Items.Clear()
                    Thread.Sleep(500)
                    ListBox1.Items.Add(MyReply.RoundtripTime)
                    Label1.Text = (koneksiping) & "ms" & " tidak aktif"
                    Dim koneksi2 = New MySqlConnection
                    koneksi2.ConnectionString = "server=localhost;userid=root;password= ;database=ipcustomer"
                    Dim READER As MySqlDataReader
                    Dim Command As New MySqlCommand
                    Try
                        koneksi2.Open()
                        Dim SQL As String = "UPDATE customer SET Status = '" & "lancar" & "' WHERE Id_cust = '" & TextBox4.Text & "'"

                        Command = New MySqlCommand(SQL, koneksi2)
                        READER = Command.ExecuteReader
                        Me.ListView1.Items.Clear()
                        Dim sqlQuery As String = "select * from customer"
                        koneksi2.Dispose()
                        koneksi2.Open()

                        sqlCommand = New MySqlCommand(Me.sqlQuery, koneksi2)
                        READER = sqlCommand.ExecuteReader
                        While (READER.Read())


                            With Me.ListView1.Items.Add(READER("Id_cust"))
                                .subitems.add(READER("Nama"))
                                .subitems.add(READER("IP"))
                                .subitems.add(READER("Status"))
                                .subitems.add(READER("kategori"))
                            End With
                            TextBox6.Text = "lancar"

                        End While

                        koneksi2.Dispose()
                        koneksi2.Close()

                    Catch ex As MySqlException
                        MessageBox.Show(ex.Message)
                    Finally
                        koneksi2.Dispose()
                        koneksi2.Open()
                        sqlCommand = New MySqlCommand(sqlQuery, koneksi2)
                        READER = Command.ExecuteReader
                    End Try
                    koneksi2.Dispose()
                ElseIf MyReply.RoundtripTime >= 0 & MyReply.Status = True And TextBox6.Text = "intermittent" Then
                    ListBox2.Items.Clear()
                    Thread.Sleep(500)
                    ListBox1.Items.Add(MyReply.RoundtripTime)
                    Label1.Text = (koneksiping) & "ms" & " intermittent"
                    Dim koneksi2 = New MySqlConnection
                    koneksi2.ConnectionString = "server=localhost;userid=root;password= ;database=ipcustomer"
                    Dim READER As MySqlDataReader
                    Dim Command As New MySqlCommand
                    Try
                        koneksi2.Open()
                        Dim SQL As String = "UPDATE customer SET Status = '" & "lancar" & "' WHERE Id_cust = '" & TextBox4.Text & "'"

                        Command = New MySqlCommand(SQL, koneksi2)
                        READER = Command.ExecuteReader
                        Me.ListView1.Items.Clear()
                        Dim sqlQuery As String = "select * from customer"
                        koneksi2.Dispose()
                        koneksi2.Open()

                        sqlCommand = New MySqlCommand(Me.sqlQuery, koneksi2)
                        READER = sqlCommand.ExecuteReader
                        While (READER.Read())


                            With Me.ListView1.Items.Add(READER("Id_cust"))
                                .subitems.add(READER("Nama"))
                                .subitems.add(READER("IP"))
                                .subitems.add(READER("Status"))
                                .subitems.add(READER("kategori"))
                            End With
                            TextBox6.Text = "lancar"

                        End While

                        koneksi2.Dispose()
                        koneksi2.Close()

                    Catch ex As MySqlException
                        MessageBox.Show(ex.Message)
                    Finally
                        koneksi2.Dispose()
                        koneksi2.Open()
                        sqlCommand = New MySqlCommand(sqlQuery, koneksi2)
                        READER = Command.ExecuteReader
                    End Try
                    koneksi2.Dispose()

                ElseIf MyReply.RoundtripTime >= 0 & MyReply.Status = True And TextBox6.Text = "putus" Then

                    Label1.Text = (koneksiping) & "ms" & " telah diperbaiki"

                    Dim koneksi2 = New MySqlConnection
                    koneksi2.ConnectionString = "server=localhost;userid=root;password= ;database=ipcustomer"
                    Dim READER As MySqlDataReader
                    Dim Command As New MySqlCommand

                    Try
                        koneksi2.Open()
                        Dim Query As String = "insert into history (Id_hist, Id_cust, Status_Network, Tanggal_Waktu) values ('" & TextBox5.Text & "','" & TextBox2.Text & "','" & Label1.Text & "','" & Format(Now, "yyyy-MM-dd HH:mm:ss") & "')"
                        Command = New MySqlCommand(Query, koneksi2)
                        READER = Command.ExecuteReader
                        retrivehistory()
                    Catch ex As MySqlException
                        MessageBox.Show(ex.Message)
                    Finally
                        koneksi2.Dispose()
                    End Try
                    Try
                        koneksi2.Open()
                        Dim SQL As String = "UPDATE customer SET Status = '" & "lancar" & "' WHERE Id_cust = '" & TextBox4.Text & "'"

                        Command = New MySqlCommand(SQL, koneksi2)
                        READER = Command.ExecuteReader
                        Me.ListView1.Items.Clear()
                        Dim sqlQuery As String = "select * from customer"
                        koneksi2.Dispose()
                        koneksi2.Open()

                        sqlCommand = New MySqlCommand(Me.sqlQuery, koneksi2)
                        READER = sqlCommand.ExecuteReader
                        While (READER.Read())


                            With Me.ListView1.Items.Add(READER("Id_cust"))
                                .subitems.add(READER("Nama"))
                                .subitems.add(READER("IP"))
                                .subitems.add(READER("Status"))
                                .subitems.add(READER("kategori"))
                            End With
                            TextBox6.Text = "lancar"

                        End While

                        koneksi2.Dispose()
                        koneksi2.Close()

                    Catch ex As MySqlException
                        MessageBox.Show(ex.Message)
                    Finally
                        koneksi2.Dispose()
                        koneksi2.Open()
                        sqlCommand = New MySqlCommand(sqlQuery, koneksi2)
                        READER = Command.ExecuteReader
                    End Try
                    koneksi2.Dispose()
                    If txtKategori.Text = "1" Then
                        sms1()
                        sms2()
                        sms3()
                        sms4()
                        sms5()
                        sms6()
                        sms7()

                    ElseIf txtKategori.Text = "2" Then
                        sms8()
                        sms9()
                        sms10()
                        sms11()
                        sms12()
                        sms13()
                        sms14()
                    ElseIf txtKategori.Text = "3" Then
                        sms15()
                        sms16()
                        sms17()
                        sms18()
                        sms19()
                        sms20()
                    End If
                    'sms1()
                    'sms2()
                    'sms3()
                    'sms4()
                    'sms5()
                    'sms6()
                    'sms7()
                    'sms8()
                    'sms9()
                    'sms10()
                    'sms11()
                    'sms12()
                    'sms13()
                    'sms14()
                    'sms15()
                    'sms16()
                    'sms17()
                    'sms18()
                    'sms19()
                    'sms20()



                ElseIf MyReply.RoundtripTime >= 0 & MyReply.Status = False And TextBox6.Text = "putus" Then


                    Label1.Text = "Putus"
                    ListBox1.Items.Add(MyReply.Status)
                ElseIf MyReply.RoundtripTime >= 0 & MyReply.Status = False And TextBox6.Text = "tidak aktif" Then


                    Label1.Text = "Putus"
                    ListBox1.Items.Add(MyReply.Status)


                ElseIf MyReply.RoundtripTime >= 0 & MyReply.Status = False And TextBox6.Text = "intermittent" Then


                    Thread.Sleep(500)
                    ListBox1.Items.Add(MyReply.Status)
                    Thread.Sleep(500)
                    ListBox2.Items.Add(MyReply.Status)

                    Label1.Text = "menjadi putus"

                    If ListBox2.Items.Count = 3 Then
                        'MsgBox("sadas")
                        Dim koneksi2 = New MySqlConnection
                        koneksi2.ConnectionString = "server=localhost;userid=root;password= ;database=ipcustomer"
                        Dim READER As MySqlDataReader
                        Dim Command As New MySqlCommand

                        Try
                            koneksi2.Open()
                            Dim Query As String
                            Query = "insert into history (Id_hist, Id_cust, Status_Network, Tanggal_Waktu) values ('" & TextBox5.Text & "','" & TextBox2.Text & "','" & Label1.Text & "','" & Format(Now, "yyyy-MM-dd HH:mm:ss") & "')"

                            Command = New MySqlCommand(Query, koneksi2)
                            READER = Command.ExecuteReader
                            retrivehistory()

                        Catch ex As MySqlException
                            MessageBox.Show(ex.Message)
                        Finally
                            koneksi2.Dispose()

                        End Try
                        Try
                            koneksi2.Open()
                            'If Label1.Text = "putus" Then

                            Dim SQL As String
                            SQL = "UPDATE customer SET Status = '" & "putus" & "' WHERE Id_cust = '" & TextBox4.Text & "'"
                            Command = New MySqlCommand(SQL, koneksi2)
                            READER = Command.ExecuteReader
                            Me.ListView1.Items.Clear()
                            Dim sqlQuery As String = "select * from customer"
                            koneksi2.Dispose()
                            koneksi2.Open()
                            sqlCommand = New MySqlCommand(Me.sqlQuery, koneksi2)
                            READER = sqlCommand.ExecuteReader
                            While (READER.Read())
                                With Me.ListView1.Items.Add(READER("Id_cust"))
                                    .subitems.add(READER("Nama"))
                                    .subitems.add(READER("IP"))
                                    .subitems.add(READER("Status"))
                                    .subitems.add(READER("kategori"))

                                End With
                                TextBox6.Text = "putus"
                            End While
                            koneksi2.Dispose()
                            koneksi2.Close()


                            'End If
                        Catch ex As MySqlException
                            MessageBox.Show(ex.Message)
                        Finally
                            koneksi2.Dispose()
                            koneksi2.Open()
                            sqlCommand = New MySqlCommand(sqlQuery, koneksi2)
                            READER = Command.ExecuteReader
                        End Try

                        If txtKategori.Text = "1" Then
                            smsputus1()
                            smsputus2()
                            smsputus3()
                            smsputus4()
                            smsputus5()
                            smsputus6()
                            smsputus7()
                        ElseIf txtKategori.Text = "2" Then
                            smsputus8()
                            smsputus9()
                            smsputus10()
                            smsputus11()
                            smsputus12()
                            smsputus13()
                            smsputus14()
                        ElseIf txtKategori.Text = "3" Then
                            smsputus15()
                            smsputus16()
                            smsputus17()
                            smsputus18()
                            smsputus19()
                            smsputus20()
                        End If


                        'smsputus1()
                        'smsputus2()
                        'smsputus3()
                        'smsputus4()
                        'smsputus5()
                        'smsputus6()
                        'smsputus7()
                        'smsputus8()
                        'smsputus9()
                        'smsputus10()
                        'smsputus11()
                        'smsputus12()
                        'smsputus13()
                        'smsputus14()
                        'smsputus15()
                        'smsputus16()
                        'smsputus17()
                        'smsputus18()
                        'smsputus19()
                        'smsputus20()
                    End If
                ElseIf MyReply.RoundtripTime >= 0 & MyReply.Status = False And TextBox6.Text = "lancar" Then

                    Thread.Sleep(500)
                    ListBox1.Items.Add(MyReply.Status)
                    Thread.Sleep(500)
                    ListBox2.Items.Add(MyReply.Status)

                    Label1.Text = "menjadi intermittent"
                    Dim koneksi2 = New MySqlConnection
                    koneksi2.ConnectionString = "server=localhost;userid=root;password= ;database=ipcustomer"
                    Dim READER As MySqlDataReader
                    Dim Command As New MySqlCommand

                    'Try
                    '    koneksi2.Open()
                    '    Dim Query As String
                    '    Query = "insert into history (Id_hist, Id_cust, Status_Network, Tanggal_Waktu) values ('" & TextBox5.Text & "','" & TextBox4.Text & "','" & Label1.Text & "','" & Format(Now, "yyyy-MM-dd HH:mm:ss") & "')"

                    '    Command = New MySqlCommand(Query, koneksi2)
                    '    READER = Command.ExecuteReader

                    '    'MessageBox.Show("Data Saved")


                    'Catch ex As MySqlException
                    '    MessageBox.Show(ex.Message)
                    'Finally
                    '    koneksi2.Dispose()

                    'End Try
                    Try
                        koneksi2.Open()
                        'If Label1.Text = "putus" Then

                        Dim SQL As String
                        SQL = "UPDATE customer SET Status = '" & "intermittent" & "' WHERE Id_cust = '" & TextBox4.Text & "'"
                        Command = New MySqlCommand(SQL, koneksi2)
                        READER = Command.ExecuteReader
                        Me.ListView1.Items.Clear()
                        Dim sqlQuery As String = "select * from customer"
                        koneksi2.Dispose()
                        koneksi2.Open()
                        sqlCommand = New MySqlCommand(Me.sqlQuery, koneksi2)
                        READER = sqlCommand.ExecuteReader
                        While (READER.Read())
                            With Me.ListView1.Items.Add(READER("Id_cust"))
                                .subitems.add(READER("Nama"))
                                .subitems.add(READER("IP"))
                                .subitems.add(READER("Status"))
                                .subitems.add(READER("kategori"))

                            End With
                            TextBox6.Text = "intermittent"
                        End While
                        koneksi2.Dispose()
                        koneksi2.Close()


                        'End If
                    Catch ex As MySqlException
                        MessageBox.Show(ex.Message)
                    Finally
                        koneksi2.Dispose()
                        koneksi2.Open()
                        sqlCommand = New MySqlCommand(sqlQuery, koneksi2)
                        READER = Command.ExecuteReader
                    End Try
                    koneksi2.Dispose()


                End If

                While N = TextBox3.Text - 1 And ak = TextBox3.Text - 1

                    N -= TextBox3.Text
                    ak -= TextBox3.Text

                End While

                If Button2.Enabled = False Then
                    ulang += 3

                End If
            Next
        Catch ex As Exception

            Exit Sub
        End Try
    End Sub
    Private Sub sms1()
        Sleep(500)
        COMport.PortName = cmbKoneksi.Text
        COMport.BaudRate = 19200
        COMport.WriteTimeout = 2000
        Try
            COMport.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Sleep(300)   '....tunggu 0.3 second
        Tunda = 300
        Sleep(Tunda)

        Application.DoEvents()
        If COMport.IsOpen Then

            Dim x As String = "AT+CMGF=1" & Chr(13)
            COMport.Write(x)
            Sleep(Tunda)
            Dim y As String = "AT+CMGS=" & Chr(34) & TextBox7.Text & Chr(34) & Chr(13)
            COMport.Write(y)
            Sleep(Tunda)
            Dim z As String = "IP sedang ada gangguan" & Chr(26)
            Dim hi As String = (TextBox2.Text) & " repaired " & Chr(26)
            COMport.Write(hi)

            Sleep(Tunda)
        Else
            MsgBox("COM port tertutup.")
        End If
        If COMport.IsOpen Then
            COMport.Close()
        End If
    End Sub
    Private Sub sms2()
        Sleep(500)
        COMport.PortName = cmbKoneksi.Text
        COMport.BaudRate = 19200
        COMport.WriteTimeout = 2000
        Try
            COMport.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Sleep(300)   '....tunggu 0.3 second
        Tunda = 300
        Sleep(Tunda)

        Application.DoEvents()
        If COMport.IsOpen Then

            Dim x As String = "AT+CMGF=1" & Chr(13)
            COMport.Write(x)
            Sleep(Tunda)
            Dim y As String = "AT+CMGS=" & Chr(34) & TextBox8.Text & Chr(34) & Chr(13)
            COMport.Write(y)
            Sleep(Tunda)
            Dim z As String = "IP sedang ada gangguan" & Chr(26)
            Dim hi As String = (TextBox2.Text) & " repaired " & Chr(26)
            COMport.Write(hi)

            Sleep(Tunda)
        Else
            MsgBox("COM port tertutup.")
        End If
        If COMport.IsOpen Then
            COMport.Close()
        End If
    End Sub
    Private Sub sms3()
        Sleep(500)
        COMport.PortName = cmbKoneksi.Text
        COMport.BaudRate = 19200
        COMport.WriteTimeout = 2000
        Try
            COMport.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Sleep(300)   '....tunggu 0.3 second
        Tunda = 300
        Sleep(Tunda)

        Application.DoEvents()
        If COMport.IsOpen Then

            Dim x As String = "AT+CMGF=1" & Chr(13)
            COMport.Write(x)
            Sleep(Tunda)
            Dim y As String = "AT+CMGS=" & Chr(34) & TextBox9.Text & Chr(34) & Chr(13)
            COMport.Write(y)
            Sleep(Tunda)
            Dim z As String = "IP sedang ada gangguan" & Chr(26)
            Dim hi As String = (TextBox2.Text) & " repaired " & Chr(26)
            COMport.Write(hi)

            Sleep(Tunda)
        Else
            MsgBox("COM port tertutup.")
        End If
        If COMport.IsOpen Then
            COMport.Close()
        End If
    End Sub
    Private Sub sms4()
        Sleep(500)
        COMport.PortName = cmbKoneksi.Text
        COMport.BaudRate = 19200
        COMport.WriteTimeout = 2000
        Try
            COMport.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Sleep(300)   '....tunggu 0.3 second
        Tunda = 300
        Sleep(Tunda)

        Application.DoEvents()
        If COMport.IsOpen Then

            Dim x As String = "AT+CMGF=1" & Chr(13)
            COMport.Write(x)
            Sleep(Tunda)
            Dim y As String = "AT+CMGS=" & Chr(34) & TextBox10.Text & Chr(34) & Chr(13)
            COMport.Write(y)
            Sleep(Tunda)
            Dim z As String = "IP sedang ada gangguan" & Chr(26)
            Dim hi As String = (TextBox2.Text) & " repaired " & Chr(26)
            COMport.Write(hi)

            Sleep(Tunda)
        Else
            MsgBox("COM port tertutup.")
        End If
        If COMport.IsOpen Then
            COMport.Close()
        End If
    End Sub
    Private Sub sms5()
        Sleep(500)
        COMport.PortName = cmbKoneksi.Text
        COMport.BaudRate = 19200
        COMport.WriteTimeout = 2000
        Try
            COMport.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Sleep(300)   '....tunggu 0.3 second
        Tunda = 300
        Sleep(Tunda)

        Application.DoEvents()
        If COMport.IsOpen Then

            Dim x As String = "AT+CMGF=1" & Chr(13)
            COMport.Write(x)
            Sleep(Tunda)
            Dim y As String = "AT+CMGS=" & Chr(34) & TextBox11.Text & Chr(34) & Chr(13)
            COMport.Write(y)
            Sleep(Tunda)
            Dim z As String = "IP sedang ada gangguan" & Chr(26)
            Dim hi As String = (TextBox2.Text) & " repaired " & Chr(26)
            COMport.Write(hi)

            Sleep(Tunda)
        Else
            MsgBox("COM port tertutup.")
        End If
        If COMport.IsOpen Then
            COMport.Close()
        End If
    End Sub
    Private Sub sms6()
        Sleep(500)
        COMport.PortName = cmbKoneksi.Text
        COMport.BaudRate = 19200
        COMport.WriteTimeout = 2000
        Try
            COMport.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Sleep(300)   '....tunggu 0.3 second
        Tunda = 300
        Sleep(Tunda)

        Application.DoEvents()
        If COMport.IsOpen Then

            Dim x As String = "AT+CMGF=1" & Chr(13)
            COMport.Write(x)
            Sleep(Tunda)
            Dim y As String = "AT+CMGS=" & Chr(34) & TextBox12.Text & Chr(34) & Chr(13)
            COMport.Write(y)
            Sleep(Tunda)
            Dim z As String = "IP sedang ada gangguan" & Chr(26)
            Dim hi As String = (TextBox2.Text) & " repaired " & Chr(26)
            COMport.Write(hi)

            Sleep(Tunda)
        Else
            MsgBox("COM port tertutup.")
        End If
        If COMport.IsOpen Then
            COMport.Close()
        End If
    End Sub
    Private Sub sms7()
        Sleep(500)
        COMport.PortName = cmbKoneksi.Text
        COMport.BaudRate = 19200
        COMport.WriteTimeout = 2000
        Try
            COMport.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Sleep(300)   '....tunggu 0.3 second
        Tunda = 300
        Sleep(Tunda)

        Application.DoEvents()
        If COMport.IsOpen Then

            Dim x As String = "AT+CMGF=1" & Chr(13)
            COMport.Write(x)
            Sleep(Tunda)
            Dim y As String = "AT+CMGS=" & Chr(34) & TextBox13.Text & Chr(34) & Chr(13)
            COMport.Write(y)
            Sleep(Tunda)
            Dim z As String = "IP sedang ada gangguan" & Chr(26)
            Dim hi As String = (TextBox2.Text) & " repaired " & Chr(26)
            COMport.Write(hi)

            Sleep(Tunda)
        Else
            MsgBox("COM port tertutup.")
        End If
        If COMport.IsOpen Then
            COMport.Close()
        End If
    End Sub
    Private Sub sms8()
        Sleep(500)
        COMport.PortName = cmbKoneksi.Text
        COMport.BaudRate = 19200
        COMport.WriteTimeout = 2000
        Try
            COMport.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Sleep(300)   '....tunggu 0.3 second
        Tunda = 300
        Sleep(Tunda)

        Application.DoEvents()
        If COMport.IsOpen Then

            Dim x As String = "AT+CMGF=1" & Chr(13)
            COMport.Write(x)
            Sleep(Tunda)
            Dim y As String = "AT+CMGS=" & Chr(34) & TextBox14.Text & Chr(34) & Chr(13)
            COMport.Write(y)
            Sleep(Tunda)
            Dim z As String = "IP sedang ada gangguan" & Chr(26)
            Dim hi As String = (TextBox2.Text) & " repaired " & Chr(26)
            COMport.Write(hi)

            Sleep(Tunda)
        Else
            MsgBox("COM port tertutup.")
        End If
        If COMport.IsOpen Then
            COMport.Close()
        End If
    End Sub
    Private Sub sms9()
        Sleep(500)
        COMport.PortName = cmbKoneksi.Text
        COMport.BaudRate = 19200
        COMport.WriteTimeout = 2000
        Try
            COMport.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Sleep(300)   '....tunggu 0.3 second
        Tunda = 300
        Sleep(Tunda)

        Application.DoEvents()
        If COMport.IsOpen Then

            Dim x As String = "AT+CMGF=1" & Chr(13)
            COMport.Write(x)
            Sleep(Tunda)
            Dim y As String = "AT+CMGS=" & Chr(34) & TextBox15.Text & Chr(34) & Chr(13)
            COMport.Write(y)
            Sleep(Tunda)
            Dim z As String = "IP sedang ada gangguan" & Chr(26)
            Dim hi As String = (TextBox2.Text) & " repaired " & Chr(26)
            COMport.Write(hi)

            Sleep(Tunda)
        Else
            MsgBox("COM port tertutup.")
        End If
        If COMport.IsOpen Then
            COMport.Close()
        End If
    End Sub
    Private Sub sms10()
        Sleep(500)
        COMport.PortName = cmbKoneksi.Text
        COMport.BaudRate = 19200
        COMport.WriteTimeout = 2000
        Try
            COMport.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Sleep(300)   '....tunggu 0.3 second
        Tunda = 300
        Sleep(Tunda)

        Application.DoEvents()
        If COMport.IsOpen Then

            Dim x As String = "AT+CMGF=1" & Chr(13)
            COMport.Write(x)
            Sleep(Tunda)
            Dim y As String = "AT+CMGS=" & Chr(34) & TextBox16.Text & Chr(34) & Chr(13)
            COMport.Write(y)
            Sleep(Tunda)
            Dim z As String = "IP sedang ada gangguan" & Chr(26)
            Dim hi As String = (TextBox2.Text) & " repaired " & Chr(26)
            COMport.Write(hi)

            Sleep(Tunda)
        Else
            MsgBox("COM port tertutup.")
        End If
        If COMport.IsOpen Then
            COMport.Close()
        End If
    End Sub
    Private Sub sms11()
        Sleep(500)
        COMport.PortName = cmbKoneksi.Text
        COMport.BaudRate = 19200
        COMport.WriteTimeout = 2000
        Try
            COMport.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Sleep(300)   '....tunggu 0.3 second
        Tunda = 300
        Sleep(Tunda)

        Application.DoEvents()
        If COMport.IsOpen Then

            Dim x As String = "AT+CMGF=1" & Chr(13)
            COMport.Write(x)
            Sleep(Tunda)
            Dim y As String = "AT+CMGS=" & Chr(34) & TextBox17.Text & Chr(34) & Chr(13)
            COMport.Write(y)
            Sleep(Tunda)
            Dim z As String = "IP sedang ada gangguan" & Chr(26)
            Dim hi As String = (TextBox2.Text) & " repaired " & Chr(26)
            COMport.Write(hi)

            Sleep(Tunda)
        Else
            MsgBox("COM port tertutup.")
        End If
        If COMport.IsOpen Then
            COMport.Close()
        End If
    End Sub
    Private Sub sms12()
        Sleep(500)
        COMport.PortName = cmbKoneksi.Text
        COMport.BaudRate = 19200
        COMport.WriteTimeout = 2000
        Try
            COMport.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Sleep(300)   '....tunggu 0.3 second
        Tunda = 300
        Sleep(Tunda)

        Application.DoEvents()
        If COMport.IsOpen Then

            Dim x As String = "AT+CMGF=1" & Chr(13)
            COMport.Write(x)
            Sleep(Tunda)
            Dim y As String = "AT+CMGS=" & Chr(34) & TextBox18.Text & Chr(34) & Chr(13)
            COMport.Write(y)
            Sleep(Tunda)
            Dim z As String = "IP sedang ada gangguan" & Chr(26)
            Dim hi As String = (TextBox2.Text) & " repaired " & Chr(26)
            COMport.Write(hi)

            Sleep(Tunda)
        Else
            MsgBox("COM port tertutup.")
        End If
        If COMport.IsOpen Then
            COMport.Close()
        End If
    End Sub
    Private Sub sms13()
        Sleep(500)
        COMport.PortName = cmbKoneksi.Text
        COMport.BaudRate = 19200
        COMport.WriteTimeout = 2000
        Try
            COMport.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Sleep(300)   '....tunggu 0.3 second
        Tunda = 300
        Sleep(Tunda)

        Application.DoEvents()
        If COMport.IsOpen Then

            Dim x As String = "AT+CMGF=1" & Chr(13)
            COMport.Write(x)
            Sleep(Tunda)
            Dim y As String = "AT+CMGS=" & Chr(34) & TextBox19.Text & Chr(34) & Chr(13)
            COMport.Write(y)
            Sleep(Tunda)
            Dim z As String = "IP sedang ada gangguan" & Chr(26)
            Dim hi As String = (TextBox2.Text) & " repaired " & Chr(26)
            COMport.Write(hi)

            Sleep(Tunda)
        Else
            MsgBox("COM port tertutup.")
        End If
        If COMport.IsOpen Then
            COMport.Close()
        End If
    End Sub
    Private Sub sms14()
        Sleep(500)
        COMport.PortName = cmbKoneksi.Text
        COMport.BaudRate = 19200
        COMport.WriteTimeout = 2000
        Try
            COMport.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Sleep(300)   '....tunggu 0.3 second
        Tunda = 300
        Sleep(Tunda)

        Application.DoEvents()
        If COMport.IsOpen Then

            Dim x As String = "AT+CMGF=1" & Chr(13)
            COMport.Write(x)
            Sleep(Tunda)
            Dim y As String = "AT+CMGS=" & Chr(34) & TextBox20.Text & Chr(34) & Chr(13)
            COMport.Write(y)
            Sleep(Tunda)
            Dim z As String = "IP sedang ada gangguan" & Chr(26)
            Dim hi As String = (TextBox2.Text) & " repaired " & Chr(26)
            COMport.Write(hi)

            Sleep(Tunda)
        Else
            MsgBox("COM port tertutup.")
        End If
        If COMport.IsOpen Then
            COMport.Close()
        End If
    End Sub
    Private Sub sms15()
        Sleep(500)
        COMport.PortName = cmbKoneksi.Text
        COMport.BaudRate = 19200
        COMport.WriteTimeout = 2000
        Try
            COMport.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Sleep(300)   '....tunggu 0.3 second
        Tunda = 300
        Sleep(Tunda)

        Application.DoEvents()
        If COMport.IsOpen Then

            Dim x As String = "AT+CMGF=1" & Chr(13)
            COMport.Write(x)
            Sleep(Tunda)
            Dim y As String = "AT+CMGS=" & Chr(34) & TextBox21.Text & Chr(34) & Chr(13)
            COMport.Write(y)
            Sleep(Tunda)
            Dim z As String = "IP sedang ada gangguan" & Chr(26)
            Dim hi As String = (TextBox2.Text) & " repaired " & Chr(26)
            COMport.Write(hi)

            Sleep(Tunda)
        Else
            MsgBox("COM port tertutup.")
        End If
        If COMport.IsOpen Then
            COMport.Close()
        End If
    End Sub
    Private Sub sms16()
        Sleep(500)
        COMport.PortName = cmbKoneksi.Text
        COMport.BaudRate = 19200
        COMport.WriteTimeout = 2000
        Try
            COMport.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Sleep(300)   '....tunggu 0.3 second
        Tunda = 300
        Sleep(Tunda)

        Application.DoEvents()
        If COMport.IsOpen Then

            Dim x As String = "AT+CMGF=1" & Chr(13)
            COMport.Write(x)
            Sleep(Tunda)
            Dim y As String = "AT+CMGS=" & Chr(34) & TextBox22.Text & Chr(34) & Chr(13)
            COMport.Write(y)
            Sleep(Tunda)
            Dim z As String = "IP sedang ada gangguan" & Chr(26)
            Dim hi As String = (TextBox2.Text) & " repaired " & Chr(26)
            COMport.Write(hi)

            Sleep(Tunda)
        Else
            MsgBox("COM port tertutup.")
        End If
        If COMport.IsOpen Then
            COMport.Close()
        End If
    End Sub
    Private Sub sms17()
        Sleep(500)
        COMport.PortName = cmbKoneksi.Text
        COMport.BaudRate = 19200
        COMport.WriteTimeout = 2000
        Try
            COMport.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Sleep(300)   '....tunggu 0.3 second
        Tunda = 300
        Sleep(Tunda)

        Application.DoEvents()
        If COMport.IsOpen Then

            Dim x As String = "AT+CMGF=1" & Chr(13)
            COMport.Write(x)
            Sleep(Tunda)
            Dim y As String = "AT+CMGS=" & Chr(34) & TextBox23.Text & Chr(34) & Chr(13)
            COMport.Write(y)
            Sleep(Tunda)
            Dim z As String = "IP sedang ada gangguan" & Chr(26)
            Dim hi As String = (TextBox2.Text) & " repaired " & Chr(26)
            COMport.Write(hi)

            Sleep(Tunda)
        Else
            MsgBox("COM port tertutup.")
        End If
        If COMport.IsOpen Then
            COMport.Close()
        End If
    End Sub
    Private Sub sms18()
        Sleep(500)
        COMport.PortName = cmbKoneksi.Text
        COMport.BaudRate = 19200
        COMport.WriteTimeout = 2000
        Try
            COMport.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Sleep(300)   '....tunggu 0.3 second
        Tunda = 300
        Sleep(Tunda)

        Application.DoEvents()
        If COMport.IsOpen Then

            Dim x As String = "AT+CMGF=1" & Chr(13)
            COMport.Write(x)
            Sleep(Tunda)
            Dim y As String = "AT+CMGS=" & Chr(34) & TextBox24.Text & Chr(34) & Chr(13)
            COMport.Write(y)
            Sleep(Tunda)
            Dim z As String = "IP sedang ada gangguan" & Chr(26)
            Dim hi As String = (TextBox2.Text) & " repaired " & Chr(26)
            COMport.Write(hi)

            Sleep(Tunda)
        Else
            MsgBox("COM port tertutup.")
        End If
        If COMport.IsOpen Then
            COMport.Close()
        End If
    End Sub
    Private Sub sms19()
        Sleep(500)
        COMport.PortName = cmbKoneksi.Text
        COMport.BaudRate = 19200
        COMport.WriteTimeout = 2000
        Try
            COMport.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Sleep(300)   '....tunggu 0.3 second
        Tunda = 300
        Sleep(Tunda)

        Application.DoEvents()
        If COMport.IsOpen Then

            Dim x As String = "AT+CMGF=1" & Chr(13)
            COMport.Write(x)
            Sleep(Tunda)
            Dim y As String = "AT+CMGS=" & Chr(34) & TextBox25.Text & Chr(34) & Chr(13)
            COMport.Write(y)
            Sleep(Tunda)
            Dim z As String = "IP sedang ada gangguan" & Chr(26)
            Dim hi As String = (TextBox2.Text) & " repaired " & Chr(26)
            COMport.Write(hi)

            Sleep(Tunda)
        Else
            MsgBox("COM port tertutup.")
        End If
        If COMport.IsOpen Then
            COMport.Close()
        End If
    End Sub
    Private Sub sms20()
        Sleep(500)
        COMport.PortName = cmbKoneksi.Text
        COMport.BaudRate = 19200
        COMport.WriteTimeout = 2000
        Try
            COMport.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Sleep(300)   '....tunggu 0.3 second
        Tunda = 300
        Sleep(Tunda)

        Application.DoEvents()
        If COMport.IsOpen Then

            Dim x As String = "AT+CMGF=1" & Chr(13)
            COMport.Write(x)
            Sleep(Tunda)

            Dim y As String = "AT+CMGS=" & Chr(34) & TextBox26.Text & Chr(34) & Chr(13)
            COMport.Write(y)
            Sleep(Tunda)
            Dim z As String = "IP sedang ada gangguan" & Chr(26)
            Dim hi As String = (TextBox2.Text) & " repaired " & Chr(26)
            COMport.Write(hi)

            Sleep(Tunda)
        Else
            MsgBox("COM port tertutup.")
        End If
        If COMport.IsOpen Then
            COMport.Close()
        End If
    End Sub
    Private Sub smsputus1()
        Sleep(500)
        COMport.PortName = cmbKoneksi.Text
        COMport.BaudRate = 19200
        COMport.WriteTimeout = 2000
        Try
            COMport.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Sleep(300)   '....tunggu 0.3 second
        Tunda = 300
        Sleep(Tunda)

        Application.DoEvents()
        If COMport.IsOpen Then

            Dim x As String = "AT+CMGF=1" & Chr(13)
            COMport.Write(x)
            Sleep(Tunda)
            Dim y As String = "AT+CMGS=" & Chr(34) & TextBox7.Text & Chr(34) & Chr(13)
            COMport.Write(y)
            Sleep(Tunda)
            Dim z As String = "IP sedang ada gangguan" & Chr(26)
            Dim hi As String = (TextBox2.Text) & " putus " & Chr(26)
            COMport.Write(hi)

            Sleep(Tunda)
        Else
            MsgBox("COM port tertutup.")
        End If
        If COMport.IsOpen Then
            COMport.Close()
        End If
    End Sub
    Private Sub smsputus2()
        Sleep(500)
        COMport.PortName = cmbKoneksi.Text
        COMport.BaudRate = 19200
        COMport.WriteTimeout = 2000
        Try
            COMport.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Sleep(300)   '....tunggu 0.3 second
        Tunda = 300
        Sleep(Tunda)

        Application.DoEvents()
        If COMport.IsOpen Then

            Dim x As String = "AT+CMGF=1" & Chr(13)
            COMport.Write(x)
            Sleep(Tunda)
            Dim y As String = "AT+CMGS=" & Chr(34) & TextBox8.Text & Chr(34) & Chr(13)
            COMport.Write(y)
            Sleep(Tunda)
            Dim z As String = "IP sedang ada gangguan" & Chr(26)
            Dim hi As String = (TextBox2.Text) & " putus " & Chr(26)
            COMport.Write(hi)

            Sleep(Tunda)
        Else
            MsgBox("COM port tertutup.")
        End If
        If COMport.IsOpen Then
            COMport.Close()
        End If
    End Sub
    Private Sub smsputus3()
        Sleep(500)
        COMport.PortName = cmbKoneksi.Text
        COMport.BaudRate = 19200
        COMport.WriteTimeout = 2000
        Try
            COMport.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Sleep(300)   '....tunggu 0.3 second
        Tunda = 300
        Sleep(Tunda)

        Application.DoEvents()
        If COMport.IsOpen Then

            Dim x As String = "AT+CMGF=1" & Chr(13)
            COMport.Write(x)
            Sleep(Tunda)
            Dim y As String = "AT+CMGS=" & Chr(34) & TextBox9.Text & Chr(34) & Chr(13)
            COMport.Write(y)
            Sleep(Tunda)
            Dim z As String = "IP sedang ada gangguan" & Chr(26)
            Dim hi As String = (TextBox2.Text) & " putus " & Chr(26)
            COMport.Write(hi)

            Sleep(Tunda)
        Else
            MsgBox("COM port tertutup.")
        End If
        If COMport.IsOpen Then
            COMport.Close()
        End If
    End Sub
    Private Sub smsputus4()
        Sleep(500)
        COMport.PortName = cmbKoneksi.Text
        COMport.BaudRate = 19200
        COMport.WriteTimeout = 2000
        Try
            COMport.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Sleep(300)   '....tunggu 0.3 second
        Tunda = 300
        Sleep(Tunda)

        Application.DoEvents()
        If COMport.IsOpen Then

            Dim x As String = "AT+CMGF=1" & Chr(13)
            COMport.Write(x)
            Sleep(Tunda)
            Dim y As String = "AT+CMGS=" & Chr(34) & TextBox10.Text & Chr(34) & Chr(13)
            COMport.Write(y)
            Sleep(Tunda)
            Dim z As String = "IP sedang ada gangguan" & Chr(26)
            Dim hi As String = (TextBox2.Text) & " putus " & Chr(26)
            COMport.Write(hi)

            Sleep(Tunda)
        Else
            MsgBox("COM port tertutup.")
        End If
        If COMport.IsOpen Then
            COMport.Close()
        End If
    End Sub
    Private Sub smsputus5()
        Sleep(500)
        COMport.PortName = cmbKoneksi.Text
        COMport.BaudRate = 19200
        COMport.WriteTimeout = 2000
        Try
            COMport.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Sleep(300)   '....tunggu 0.3 second
        Tunda = 300
        Sleep(Tunda)

        Application.DoEvents()
        If COMport.IsOpen Then

            Dim x As String = "AT+CMGF=1" & Chr(13)
            COMport.Write(x)
            Sleep(Tunda)
            Dim y As String = "AT+CMGS=" & Chr(34) & TextBox11.Text & Chr(34) & Chr(13)
            COMport.Write(y)
            Sleep(Tunda)
            Dim z As String = "IP sedang ada gangguan" & Chr(26)
            Dim hi As String = (TextBox2.Text) & " putus " & Chr(26)
            COMport.Write(hi)

            Sleep(Tunda)
        Else
            MsgBox("COM port tertutup.")
        End If
        If COMport.IsOpen Then
            COMport.Close()
        End If
    End Sub
    Private Sub smsputus6()
        Sleep(500)
        COMport.PortName = cmbKoneksi.Text
        COMport.BaudRate = 19200
        COMport.WriteTimeout = 2000
        Try
            COMport.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Sleep(300)   '....tunggu 0.3 second
        Tunda = 300
        Sleep(Tunda)

        Application.DoEvents()
        If COMport.IsOpen Then

            Dim x As String = "AT+CMGF=1" & Chr(13)
            COMport.Write(x)
            Sleep(Tunda)
            Dim y As String = "AT+CMGS=" & Chr(34) & TextBox12.Text & Chr(34) & Chr(13)
            COMport.Write(y)
            Sleep(Tunda)
            Dim z As String = "IP sedang ada gangguan" & Chr(26)
            Dim hi As String = (TextBox2.Text) & " putus " & Chr(26)
            COMport.Write(hi)

            Sleep(Tunda)
        Else
            MsgBox("COM port tertutup.")
        End If
        If COMport.IsOpen Then
            COMport.Close()
        End If
    End Sub

    Private Sub smsputus7()
        Sleep(500)
        COMport.PortName = cmbKoneksi.Text
        COMport.BaudRate = 19200
        COMport.WriteTimeout = 2000
        Try
            COMport.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Sleep(300)   '....tunggu 0.3 second
        Tunda = 300
        Sleep(Tunda)

        Application.DoEvents()
        If COMport.IsOpen Then

            Dim x As String = "AT+CMGF=1" & Chr(13)
            COMport.Write(x)
            Sleep(Tunda)
            Dim y As String = "AT+CMGS=" & Chr(34) & TextBox13.Text & Chr(34) & Chr(13)
            COMport.Write(y)
            Sleep(Tunda)
            Dim z As String = "IP sedang ada gangguan" & Chr(26)
            Dim hi As String = (TextBox2.Text) & " putus " & Chr(26)
            COMport.Write(hi)

            Sleep(Tunda)
        Else
            MsgBox("COM port tertutup.")
        End If
        If COMport.IsOpen Then
            COMport.Close()
        End If
    End Sub
    Private Sub smsputus8()
        Sleep(500)
        COMport.PortName = cmbKoneksi.Text
        COMport.BaudRate = 19200
        COMport.WriteTimeout = 2000
        Try
            COMport.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Sleep(300)   '....tunggu 0.3 second
        Tunda = 300
        Sleep(Tunda)

        Application.DoEvents()
        If COMport.IsOpen Then

            Dim x As String = "AT+CMGF=1" & Chr(13)
            COMport.Write(x)
            Sleep(Tunda)
            Dim y As String = "AT+CMGS=" & Chr(34) & TextBox14.Text & Chr(34) & Chr(13)
            COMport.Write(y)
            Sleep(Tunda)
            Dim z As String = "IP sedang ada gangguan" & Chr(26)
            Dim hi As String = (TextBox2.Text) & " putus " & Chr(26)
            COMport.Write(hi)

            Sleep(Tunda)
        Else
            MsgBox("COM port tertutup.")
        End If
        If COMport.IsOpen Then
            COMport.Close()
        End If
    End Sub
    Private Sub smsputus9()
        Sleep(500)
        COMport.PortName = cmbKoneksi.Text
        COMport.BaudRate = 19200
        COMport.WriteTimeout = 2000
        Try
            COMport.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Sleep(300)   '....tunggu 0.3 second
        Tunda = 300
        Sleep(Tunda)

        Application.DoEvents()
        If COMport.IsOpen Then

            Dim x As String = "AT+CMGF=1" & Chr(13)
            COMport.Write(x)
            Sleep(Tunda)
            Dim y As String = "AT+CMGS=" & Chr(34) & TextBox15.Text & Chr(34) & Chr(13)
            COMport.Write(y)
            Sleep(Tunda)
            Dim z As String = "IP sedang ada gangguan" & Chr(26)
            Dim hi As String = (TextBox2.Text) & " putus " & Chr(26)
            COMport.Write(hi)

            Sleep(Tunda)
        Else
            MsgBox("COM port tertutup.")
        End If
        If COMport.IsOpen Then
            COMport.Close()
        End If
    End Sub
    Private Sub smsputus10()
        Sleep(500)
        COMport.PortName = cmbKoneksi.Text
        COMport.BaudRate = 19200
        COMport.WriteTimeout = 2000
        Try
            COMport.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Sleep(300)   '....tunggu 0.3 second
        Tunda = 300
        Sleep(Tunda)

        Application.DoEvents()
        If COMport.IsOpen Then

            Dim x As String = "AT+CMGF=1" & Chr(13)
            COMport.Write(x)
            Sleep(Tunda)
            Dim y As String = "AT+CMGS=" & Chr(34) & TextBox16.Text & Chr(34) & Chr(13)
            COMport.Write(y)
            Sleep(Tunda)
            Dim z As String = "IP sedang ada gangguan" & Chr(26)
            Dim hi As String = (TextBox2.Text) & " putus " & Chr(26)
            COMport.Write(hi)

            Sleep(Tunda)
        Else
            MsgBox("COM port tertutup.")
        End If
        If COMport.IsOpen Then
            COMport.Close()
        End If
    End Sub
    Private Sub smsputus11()
        Sleep(500)
        COMport.PortName = cmbKoneksi.Text
        COMport.BaudRate = 19200
        COMport.WriteTimeout = 2000
        Try
            COMport.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Sleep(300)   '....tunggu 0.3 second
        Tunda = 300
        Sleep(Tunda)

        Application.DoEvents()
        If COMport.IsOpen Then

            Dim x As String = "AT+CMGF=1" & Chr(13)
            COMport.Write(x)
            Sleep(Tunda)
            Dim y As String = "AT+CMGS=" & Chr(34) & TextBox17.Text & Chr(34) & Chr(13)
            COMport.Write(y)
            Sleep(Tunda)
            Dim z As String = "IP sedang ada gangguan" & Chr(26)
            Dim hi As String = (TextBox2.Text) & " putus " & Chr(26)
            COMport.Write(hi)

            Sleep(Tunda)
        Else
            MsgBox("COM port tertutup.")
        End If
        If COMport.IsOpen Then
            COMport.Close()
        End If
    End Sub
    Private Sub smsputus12()
        Sleep(500)
        COMport.PortName = cmbKoneksi.Text
        COMport.BaudRate = 19200
        COMport.WriteTimeout = 2000
        Try
            COMport.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Sleep(300)   '....tunggu 0.3 second
        Tunda = 300
        Sleep(Tunda)

        Application.DoEvents()
        If COMport.IsOpen Then

            Dim x As String = "AT+CMGF=1" & Chr(13)
            COMport.Write(x)
            Sleep(Tunda)
            Dim y As String = "AT+CMGS=" & Chr(34) & TextBox18.Text & Chr(34) & Chr(13)
            COMport.Write(y)
            Sleep(Tunda)
            Dim z As String = "IP sedang ada gangguan" & Chr(26)
            Dim hi As String = (TextBox2.Text) & " putus " & Chr(26)
            COMport.Write(hi)

            Sleep(Tunda)
        Else
            MsgBox("COM port tertutup.")
        End If
        If COMport.IsOpen Then
            COMport.Close()
        End If
    End Sub
    Private Sub smsputus13()
        Sleep(500)
        COMport.PortName = cmbKoneksi.Text
        COMport.BaudRate = 19200
        COMport.WriteTimeout = 2000
        Try
            COMport.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Sleep(300)   '....tunggu 0.3 second
        Tunda = 300
        Sleep(Tunda)

        Application.DoEvents()
        If COMport.IsOpen Then

            Dim x As String = "AT+CMGF=1" & Chr(13)
            COMport.Write(x)
            Sleep(Tunda)
            Dim y As String = "AT+CMGS=" & Chr(34) & TextBox19.Text & Chr(34) & Chr(13)
            COMport.Write(y)
            Sleep(Tunda)
            Dim z As String = "IP sedang ada gangguan" & Chr(26)
            Dim hi As String = (TextBox2.Text) & " putus " & Chr(26)
            COMport.Write(hi)

            Sleep(Tunda)
        Else
            MsgBox("COM port tertutup.")
        End If
        If COMport.IsOpen Then
            COMport.Close()
        End If
    End Sub
    Private Sub smsputus14()
        Sleep(500)
        COMport.PortName = cmbKoneksi.Text
        COMport.BaudRate = 19200
        COMport.WriteTimeout = 2000
        Try
            COMport.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Sleep(300)   '....tunggu 0.3 second
        Tunda = 300
        Sleep(Tunda)

        Application.DoEvents()
        If COMport.IsOpen Then

            Dim x As String = "AT+CMGF=1" & Chr(13)
            COMport.Write(x)
            Sleep(Tunda)
            Dim y As String = "AT+CMGS=" & Chr(34) & TextBox20.Text & Chr(34) & Chr(13)
            COMport.Write(y)
            Sleep(Tunda)
            Dim z As String = "IP sedang ada gangguan" & Chr(26)
            Dim hi As String = (TextBox2.Text) & " putus " & Chr(26)
            COMport.Write(hi)

            Sleep(Tunda)
        Else
            MsgBox("COM port tertutup.")
        End If
        If COMport.IsOpen Then
            COMport.Close()
        End If
    End Sub
    Private Sub smsputus15()
        Sleep(500)
        COMport.PortName = cmbKoneksi.Text
        COMport.BaudRate = 19200
        COMport.WriteTimeout = 2000
        Try
            COMport.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Sleep(300)   '....tunggu 0.3 second
        Tunda = 300
        Sleep(Tunda)

        Application.DoEvents()
        If COMport.IsOpen Then

            Dim x As String = "AT+CMGF=1" & Chr(13)
            COMport.Write(x)
            Sleep(Tunda)
            Dim y As String = "AT+CMGS=" & Chr(34) & TextBox21.Text & Chr(34) & Chr(13)
            COMport.Write(y)
            Sleep(Tunda)
            Dim z As String = "IP sedang ada gangguan" & Chr(26)
            Dim hi As String = (TextBox2.Text) & " putus " & Chr(26)
            COMport.Write(hi)

            Sleep(Tunda)
        Else
            MsgBox("COM port tertutup.")
        End If
        If COMport.IsOpen Then
            COMport.Close()
        End If
    End Sub
    Private Sub smsputus16()
        Sleep(500)
        COMport.PortName = cmbKoneksi.Text
        COMport.BaudRate = 19200
        COMport.WriteTimeout = 2000
        Try
            COMport.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Sleep(300)   '....tunggu 0.3 second
        Tunda = 300
        Sleep(Tunda)

        Application.DoEvents()
        If COMport.IsOpen Then

            Dim x As String = "AT+CMGF=1" & Chr(13)
            COMport.Write(x)
            Sleep(Tunda)
            Dim y As String = "AT+CMGS=" & Chr(34) & TextBox22.Text & Chr(34) & Chr(13)
            COMport.Write(y)
            Sleep(Tunda)
            Dim z As String = "IP sedang ada gangguan" & Chr(26)
            Dim hi As String = (TextBox2.Text) & " putus " & Chr(26)
            COMport.Write(hi)

            Sleep(Tunda)
        Else
            MsgBox("COM port tertutup.")
        End If
        If COMport.IsOpen Then
            COMport.Close()
        End If
    End Sub
    Private Sub smsputus17()
        Sleep(500)
        COMport.PortName = cmbKoneksi.Text
        COMport.BaudRate = 19200
        COMport.WriteTimeout = 2000
        Try
            COMport.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Sleep(300)   '....tunggu 0.3 second
        Tunda = 300
        Sleep(Tunda)

        Application.DoEvents()
        If COMport.IsOpen Then

            Dim x As String = "AT+CMGF=1" & Chr(13)
            COMport.Write(x)
            Sleep(Tunda)
            Dim y As String = "AT+CMGS=" & Chr(34) & TextBox23.Text & Chr(34) & Chr(13)
            COMport.Write(y)
            Sleep(Tunda)
            Dim z As String = "IP sedang ada gangguan" & Chr(26)
            Dim hi As String = (TextBox2.Text) & " putus " & Chr(26)
            COMport.Write(hi)

            Sleep(Tunda)
        Else
            MsgBox("COM port tertutup.")
        End If
        If COMport.IsOpen Then
            COMport.Close()
        End If
    End Sub
    Private Sub smsputus18()
        Sleep(500)
        COMport.PortName = cmbKoneksi.Text
        COMport.BaudRate = 19200
        COMport.WriteTimeout = 2000
        Try
            COMport.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Sleep(300)   '....tunggu 0.3 second
        Tunda = 300
        Sleep(Tunda)

        Application.DoEvents()
        If COMport.IsOpen Then

            Dim x As String = "AT+CMGF=1" & Chr(13)
            COMport.Write(x)
            Sleep(Tunda)
            Dim y As String = "AT+CMGS=" & Chr(34) & TextBox24.Text & Chr(34) & Chr(13)
            COMport.Write(y)
            Sleep(Tunda)
            Dim z As String = "IP sedang ada gangguan" & Chr(26)
            Dim hi As String = (TextBox2.Text) & " putus " & Chr(26)
            COMport.Write(hi)

            Sleep(Tunda)
        Else
            MsgBox("COM port tertutup.")
        End If
        If COMport.IsOpen Then
            COMport.Close()
        End If
    End Sub
    Private Sub smsputus19()
        Sleep(500)
        COMport.PortName = cmbKoneksi.Text
        COMport.BaudRate = 19200
        COMport.WriteTimeout = 2000
        Try
            COMport.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Sleep(300)   '....tunggu 0.3 second
        Tunda = 300
        Sleep(Tunda)

        Application.DoEvents()
        If COMport.IsOpen Then

            Dim x As String = "AT+CMGF=1" & Chr(13)
            COMport.Write(x)
            Sleep(Tunda)
            Dim y As String = "AT+CMGS=" & Chr(34) & TextBox25.Text & Chr(34) & Chr(13)
            COMport.Write(y)
            Sleep(Tunda)
            Dim z As String = "IP sedang ada gangguan" & Chr(26)
            Dim hi As String = (TextBox2.Text) & " putus " & Chr(26)
            COMport.Write(hi)

            Sleep(Tunda)
        Else
            MsgBox("COM port tertutup.")
        End If
        If COMport.IsOpen Then
            COMport.Close()
        End If
    End Sub
    Private Sub smsputus20()
        Sleep(500)
        COMport.PortName = cmbKoneksi.Text
        COMport.BaudRate = 19200
        COMport.WriteTimeout = 2000
        Try
            COMport.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Sleep(300)   '....tunggu 0.3 second
        Tunda = 300
        Sleep(Tunda)

        Application.DoEvents()
        If COMport.IsOpen Then

            Dim x As String = "AT+CMGF=1" & Chr(13)
            COMport.Write(x)
            Sleep(Tunda)
            Dim y As String = "AT+CMGS=" & Chr(34) & TextBox26.Text & Chr(34) & Chr(13)
            COMport.Write(y)
            Sleep(Tunda)
            Dim z As String = "IP sedang ada gangguan" & Chr(26)
            Dim hi As String = (TextBox2.Text) & " putus " & Chr(26)
            COMport.Write(hi)

            Sleep(Tunda)
        Else
            MsgBox("COM port tertutup.")
        End If
        If COMport.IsOpen Then
            COMport.Close()
        End If
    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles txtTmbNamatelp.TextChanged

    End Sub



    Private Sub btnTambahTelp_Click(sender As Object, e As EventArgs) Handles btnTambahTelp.Click
        Panel5.Location = New Point(1187, 0)
        Do Until Panel5.Location.X = 880
            Panel5.Location = New Point(Panel5.Location.X - 1, 0)
            System.Threading.Thread.Sleep(0.1)
        Loop
        Do Until Panel5.Location.X = 870
            Panel5.Location = New Point(Panel5.Location.X - 1, 0)

            System.Threading.Thread.Sleep(20)
            Refresh()
        Loop
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Panel5.Location = New Point(870, 0)
        Do Until Panel5.Location.X = 1177
            Panel5.Location = New Point(Panel5.Location.X + 1, 0)

        Loop
        Do Until Panel5.Location.X = 1187
            Panel5.Location = New Point(Panel5.Location.X + 1, 0)

            System.Threading.Thread.Sleep(20)
            Refresh()
        Loop
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub BtnHistory_Click(sender As Object, e As EventArgs) Handles BtnHistory.Click
        Panel6.Visible = True
        Panel3.Visible = False
        Panel1.Visible = False
        Panel4.Visible = False
        Panel5.Visible = False
        Panel7.Visible = False
    End Sub
    'Private Sub tampilteknisi()
    '    Dim koneksi2 = New MySqlConnection
    '    koneksi2.ConnectionString = "server=localhost;userid=root;password= ;database=ipcustomer"
    '    Dim READER As MySqlDataReader
    '    Dim Command As New MySqlCommand
    '    Try
    '        Me.ListView2.Items.Clear()
    '        Dim sqlQuery As String = "select * from teknisi"
    '        koneksi2.Dispose()
    '        koneksi2.Open()

    '        sqlCommand = New MySqlCommand(Me.sqlQuery, koneksi2)
    '        reader2 = sqlCommand.ExecuteReader
    '        While (reader2.Read())


    '            With Me.ListView2.Items.Add(reader2("id_teknisi"))
    '                .subitems.add(reader2("Nama"))
    '                .subitems.add(reader2("No_telepon"))

    '            End With


    '        End While

    '        koneksi2.Dispose()
    '        koneksi2.Close()

    '    Catch ex As MySqlException
    '        MessageBox.Show(ex.Message)
    '    Finally
    '        koneksi2.Dispose()
    '        koneksi2.Open()
    '        sqlCommand = New MySqlCommand(sqlQuery, koneksi2)
    '        reader2 = Command.ExecuteReader
    '    End Try
    '    koneksi2.Dispose()
    'End Sub
    Private Sub ListView2_Click(sender As Object, e As EventArgs) Handles ListView2.Click

        With Me.ListView2
            Dim i As Integer
            For Each item As ListViewItem In ListView2.SelectedItems
                i = item.Index
            Next
            Dim innercounter As Integer = 0
            For Each subItem As ListViewItem.ListViewSubItem In ListView2.Items(i).SubItems
                Dim myString As String = ListView2.Items(i).SubItems(innercounter).Text
                Select Case innercounter
                    Case 0
                        txtTmbIDtelp.Text = myString
                    Case 1
                        txtTmbNamatelp.Text = myString
                    Case 2
                        txtTmbNoTelp.Text = myString

                End Select
                innercounter += 1
            Next
        End With
    End Sub
    Private Sub simpanteknisi()


        Dim koneksi2 = New MySqlConnection
        koneksi2.ConnectionString = "server=localhost;userid=root;password= ;database=ipcustomer"
        Dim READER As MySqlDataReader
        Dim Command As New MySqlCommand
        Try
            koneksi2.Open()
            'If Label1.Text = "putus" Then

            Dim SQL As String
            SQL = "UPDATE teknisi SET Nama = '" & txtTmbNamatelp.Text & "', No_telepon='" & txtTmbNoTelp.Text & "' WHERE id_teknisi = '" & txtTmbIDtelp.Text & "'"
            Command = New MySqlCommand(SQL, koneksi2)
            READER = Command.ExecuteReader
            Me.ListView2.Items.Clear()
            retriveteknisi()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            koneksi2.Dispose()

        End Try
        koneksi2.Dispose()
    End Sub


    Private Sub ListView1_Click(sender As Object, e As EventArgs) Handles ListView1.Click

        With Me.ListView1
            Dim i As Integer
            For Each item As ListViewItem In ListView1.SelectedItems
                i = item.Index
            Next
            Dim innercounter As Integer = 0
            For Each subItem As ListViewItem.ListViewSubItem In ListView1.Items(i).SubItems
                Dim myString As String = ListView1.Items(i).SubItems(innercounter).Text
                Select Case innercounter
                    Case 0
                        TxtInsIDCust.Text = myString
                    Case 1
                        TxtInsNamaCust.Text = myString
                    Case 2
                        TxtInsIPCust.Text = myString
                    Case 3
                        cmbinsstatus.Text = myString
                    Case 4
                        cmbKategori.Text = myString
                End Select
                innercounter += 1
            Next
        End With
    End Sub
    Private Sub btnSimpantelp_Click(sender As Object, e As EventArgs) Handles btnSimpantelp.Click
        simpanteknisi()

    End Sub
    Private Sub hapusteknisi()
        Dim x As String
        x = MsgBox("yakin akan dihapus...?", MsgBoxStyle.OkCancel, "Hapus")
        If x = vbOK Then

            Dim del As String = "DELETE FROM teknisi WHERE id_teknisi = '" & txtTmbIDtelp.Text & "'"
            cmd = New MySqlCommand(del, koneksi)
            cmd.ExecuteNonQuery()

        End If
    End Sub
    Private Sub hapushistory()
        Dim x As String
        x = MsgBox("yakin akan dihapus Semua?", MsgBoxStyle.OkCancel, "Hapus")
        If x = vbOK Then

            Dim del As String = "truncate history"
            cmd = New MySqlCommand(del, koneksi)
            cmd.ExecuteNonQuery()

        End If
    End Sub

    Private Sub btnSimpan(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs)

    End Sub


    Private Sub Button2_Click_2(sender As Object, e As EventArgs) Handles Button2.Click
        Button2.Enabled = False
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Application.Exit()
    End Sub
    Private Sub updatecustomer()
        Dim koneksi2 = New MySqlConnection
        koneksi2.ConnectionString = "server=localhost;userid=root;password= ;database=ipcustomer"
        Dim READER As MySqlDataReader
        Dim Command As New MySqlCommand


        Try
            koneksi2.Open()
            'If Label1.Text = "putus" Then

            Dim SQL As String = "UPDATE customer SET Nama = '" & TxtInsNamaCust.Text & "', Ip='" & TxtInsIPCust.Text & "', Status='" & cmbinsstatus.Text & "', kategori='" & cmbKategori.Text & "' WHERE Id_cust = '" & TxtInsIDCust.Text & "'"
            Command = New MySqlCommand(SQL, koneksi2)
            READER = Command.ExecuteReader
            Me.ListView1.Items.Clear()
            Dim sqlQuery As String = "select * from customer"
            koneksi2.Dispose()
            koneksi2.Open()
            sqlCommand = New MySqlCommand(Me.sqlQuery, koneksi2)
            READER = sqlCommand.ExecuteReader
            While (READER.Read())
                With Me.ListView1.Items.Add(READER("Id_cust"))
                    .subitems.add(READER("Nama"))
                    .subitems.add(READER("IP"))
                    .subitems.add(READER("Status"))
                    .subitems.add(READER("kategori"))
                    TextBox6.Text = ListView1.Items(0).SubItems(3).Text
                    TextBox2.Text = ListView1.Items(0).SubItems(1).Text
                    TextBox1.Text = ListView1.Items(0).SubItems(2).Text
                    cmbKategori.Text = ListView1.Items(0).SubItems(4).Text
                End With

            End While
            koneksi2.Dispose()
            koneksi2.Close()


            'End If
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            koneksi2.Dispose()
            koneksi2.Open()
            sqlCommand = New MySqlCommand(sqlQuery, koneksi2)

        End Try
        koneksi2.Dispose()
    End Sub
    Private Sub deletecustomer()
        Dim koneksi2 = New MySqlConnection
        koneksi2.ConnectionString = "server=localhost;userid=root;password= ;database=ipcustomer"
        Dim READER As MySqlDataReader
        Dim Command As New MySqlCommand


        Try
            koneksi2.Open()
            'If Label1.Text = "putus" Then

            Dim x As String
            x = MsgBox("yakin akan dihapus...?", MsgBoxStyle.OkCancel, "Hapus")
            If x = vbOK Then

                Dim del As String = "DELETE FROM customer WHERE Id_cust = '" & TxtInsIDCust.Text & "'"
                cmd = New MySqlCommand(del, koneksi)
                cmd.ExecuteNonQuery()

            End If
            Me.ListView1.Items.Clear()
            Dim sqlQuery As String = "select * from customer"
            koneksi2.Dispose()
            koneksi2.Open()
            sqlCommand = New MySqlCommand(Me.sqlQuery, koneksi2)
            READER = sqlCommand.ExecuteReader
            While (READER.Read())
                With Me.ListView1.Items.Add(READER("Id_cust"))
                    .subitems.add(READER("Nama"))
                    .subitems.add(READER("IP"))
                    .subitems.add(READER("Status"))
                    .subitems.add(READER("kategori"))

                End With

            End While
            koneksi2.Dispose()
            koneksi2.Close()


            'End If
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            koneksi2.Dispose()
            koneksi2.Open()
            sqlCommand = New MySqlCommand(sqlQuery, koneksi2)

        End Try
        koneksi2.Dispose()
    End Sub

    Private Sub insertcustomer()
        Dim koneksi2 = New MySqlConnection
        koneksi2.ConnectionString = "server=localhost;userid=root;password= ;database=ipcustomer"
        Dim READER As MySqlDataReader
        Dim Command As New MySqlCommand

        
        Try
            koneksi2.Open()
            'If Label1.Text = "putus" Then

            Dim sql As String = "insert into customer values ('','" & TxtInsNamaCust.Text & "','" & TxtInsIPCust.Text & "','" & cmbinsstatus.Text & "','" & cmbKategori.Text & "')"
            cmd = New MySqlCommand(sql, koneksi2)
            cmd.ExecuteNonQuery()
            Me.ListView1.Items.Clear()
            Dim sqlQuery As String = "select * from customer"
            koneksi2.Dispose()
            koneksi2.Open()
            sqlCommand = New MySqlCommand(Me.sqlQuery, koneksi2)
            READER = sqlCommand.ExecuteReader
            While (READER.Read())
                With Me.ListView1.Items.Add(READER("Id_cust"))
                    .subitems.add(READER("Nama"))
                    .subitems.add(READER("IP"))
                    .subitems.add(READER("Status"))
                    .subitems.add(READER("kategori"))

                End With

            End While
            koneksi2.Dispose()
            koneksi2.Close()


            'End If
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            koneksi2.Dispose()
            koneksi2.Open()
            sqlCommand = New MySqlCommand(sqlQuery, koneksi2)

        End Try
        koneksi2.Dispose()
    End Sub

    Private Sub confCust_Click(sender As Object, e As EventArgs) Handles confCust.Click
        Panel3.Visible = False
        Panel6.Visible = False

        Panel7.Location = New Point(1187, 0)
        ListView1.Location = New Point(387, 344)

        Do Until Panel7.Location.X = 1003 Or ListView1.Location.X = 190
            Panel7.Location = New Point(Panel7.Location.X - 1, 0)
            ListView1.Location = New Point(ListView1.Location.X - 1, 344)
            System.Threading.Thread.Sleep(0.1)
        Loop
        Do Until Panel7.Location.X = 993 Or ListView1.Location.X = 180
            Panel7.Location = New Point(Panel7.Location.X - 1, 0)
            ListView1.Location = New Point(ListView1.Location.X - 1, 344)
            System.Threading.Thread.Sleep(20)
            Refresh()
        Loop
        
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Panel7.Location = New Point(993, 0)
        ListView1.Location = New Point(201, 344)
        Do Until Panel7.Location.X = 1177 Or ListView1.Location.X = 400
            Panel7.Location = New Point(Panel7.Location.X + 1, 0)
            ListView1.Location = New Point(ListView1.Location.X + 1, 344)

        Loop
        Do Until Panel7.Location.X = 1187
            Panel7.Location = New Point(Panel7.Location.X + 1, 0)

            System.Threading.Thread.Sleep(20)
            Refresh()
        Loop
    End Sub

    Private Sub btnSimpanCust_Click(sender As Object, e As EventArgs) Handles btnSimpanCust.Click
        updatecustomer()
    End Sub
    Private Sub populateteknisi(id_teknisi As String, Nama As String, No_telepon As String)
        Dim row As String() = New String() {id_teknisi, Nama, No_telepon}
        Dim item As New ListViewItem(row)
        ListView2.Items.Add(item)

    End Sub
    Private Sub populate(Id_hist As String, Id_cust As String, Status_Network As String, Tanggal_Waktu As String)
        Dim row As String() = New String() {Id_hist, Id_cust, Status_Network, Tanggal_Waktu}
        Dim item As New ListViewItem(row)
        ListView3.Items.Add(item)
    End Sub
    Private Sub retrivehistory()
        Me.ListView3.Items.Clear()
        koneksihistory.Close()
        Dim Command As New MySqlCommand
        Dim sqlQuery As String = "select * from history"
        cmd = New MySqlCommand(sqlQuery, koneksihistory)
        koneksihistory.Open()
        sqlAdapeter = New MySqlDataAdapter(cmd)
        sqlAdapeter.Fill(tabel3)
        For Each row In tabel3.Rows
            populate(row(0), row(1), row(2), row(3))
        Next
        tabel3.Rows.Clear()
        'MessageBox.Show("Data Saved")

    End Sub

    Private Sub retriveteknisi()
        Me.ListView3.Items.Clear()
        koneksiteknisi.Close()
        Dim Command As New MySqlCommand
        Dim sqlQuery As String = "select * from teknisi"
        cmd = New MySqlCommand(sqlQuery, koneksihistory)
        koneksiteknisi.Open()
        sqlAdapeter = New MySqlDataAdapter(cmd)
        sqlAdapeter.Fill(tabel2)
        Dim a As Integer
        For Each row In tabel2.Rows
            populateteknisi(row(0), row(1), row(2))
            TextBox7.Text = (tabel2.Rows(0)("No_telepon")).ToString
            TextBox8.Text = (tabel2.Rows(1)("No_telepon")).ToString
            TextBox9.Text = (tabel2.Rows(2)("No_telepon")).ToString
            TextBox10.Text = (tabel2.Rows(3)("No_telepon")).ToString
            TextBox11.Text = (tabel2.Rows(4)("No_telepon")).ToString
            TextBox12.Text = (tabel2.Rows(5)("No_telepon")).ToString
            TextBox13.Text = (tabel2.Rows(6)("No_telepon")).ToString
            TextBox14.Text = (tabel2.Rows(7)("No_telepon")).ToString
            TextBox15.Text = (tabel2.Rows(8)("No_telepon")).ToString
            TextBox16.Text = (tabel2.Rows(9)("No_telepon")).ToString
            TextBox17.Text = (tabel2.Rows(10)("No_telepon")).ToString
            TextBox18.Text = (tabel2.Rows(11)("No_telepon")).ToString
            TextBox19.Text = (tabel2.Rows(12)("No_telepon")).ToString
            TextBox20.Text = (tabel2.Rows(13)("No_telepon")).ToString
            TextBox21.Text = (tabel2.Rows(14)("No_telepon")).ToString
            TextBox22.Text = (tabel2.Rows(15)("No_telepon")).ToString
            TextBox23.Text = (tabel2.Rows(16)("No_telepon")).ToString
            TextBox24.Text = (tabel2.Rows(17)("No_telepon")).ToString
            TextBox25.Text = (tabel2.Rows(18)("No_telepon")).ToString
            TextBox26.Text = (tabel2.Rows(19)("No_telepon")).ToString
        Next
        tabel2.Rows.Clear()
        'MessageBox.Show("Data Saved")

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs)
        retrivehistory()
    End Sub
    
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        hapushistory()
        retrivehistory()
    End Sub

    Private Sub btnTmbCust_Click(sender As Object, e As EventArgs) Handles btnTmbCust.Click
        insertcustomer()
    End Sub

    Private Sub btnDelCust_Click(sender As Object, e As EventArgs) Handles btnDelCust.Click
        deletecustomer()
    End Sub

    Private Sub Panel7_Paint(sender As Object, e As PaintEventArgs) Handles Panel7.Paint

    End Sub
End Class
