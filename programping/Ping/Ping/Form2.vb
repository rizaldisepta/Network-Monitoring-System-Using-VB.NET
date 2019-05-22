Public Class Form2

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            RectangleShape2.Width += 10

            If RectangleShape2.Width >= 590 Then
                Timer1.Stop()
                Form1.Show()
                Me.Close()



            End If

        Catch ex As Exception

        End Try



    End Sub



    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub
End Class
