Imports System.IO

Module Module1

    Sub Main()
        Try
            Dim reqparm As New Specialized.NameValueCollection
            Dim pram As String()
            Dim url As String = ""
            Dim message As String = ""

            For Each argument As String In My.Application.CommandLineArgs
                pram = argument.Split("=")
                If (pram.Length = 2) Then
                    reqparm.Add(pram(0), pram(1))

                Else
                    url = argument
                End If

            Next



            If (reqparm.Count > 1) Then
                Using client As New Net.WebClient

                    Dim responsebytes = client.UploadValues(url, "POST", reqparm)

                    Dim responsebody = (New Text.UTF8Encoding).GetString(responsebytes)

                    Dim strFile As String = "response.txt"
                    Dim fileExists As Boolean = File.Exists(strFile)
                    If (Not fileExists) Then
                        Using sw As New StreamWriter(File.Open(strFile, FileMode.OpenOrCreate))
                            sw.WriteLine(DateTime.Now & " " & message & " " & responsebody)
                            Console.Write(responsebody + vbCrLf + message)
                        End Using
                    Else
                        Using sw As New StreamWriter(File.Open(strFile, FileMode.Append))
                            sw.WriteLine(DateTime.Now & " " & message & " " & responsebody)
                            Console.Write(responsebody + vbCrLf + message)
                        End Using
                    End If

                    Console.Write("Complete Post to url")

                End Using
            End If
        Catch ex As Exception
            Dim strFile As String = "error.txt"
            Dim fileExists As Boolean = File.Exists(strFile)
            If (Not fileExists) Then
                Using sw As New StreamWriter(File.Open(strFile, FileMode.OpenOrCreate))
                    sw.WriteLine(DateTime.Now & ex.Message)
                End Using
            Else
                Using sw As New StreamWriter(File.Open(strFile, FileMode.Append))
                    sw.WriteLine(DateTime.Now & ex.Message)
                End Using
            End If
            Console.Write("Error : " + ex.Message)

        End Try




    End Sub

End Module
