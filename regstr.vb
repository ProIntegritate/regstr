    Sub Main()

        Dim sArg() As String = Environment.GetCommandLineArgs
        If UBound(sArg) = 0 Then
            Console.WriteLine("RegStr, a strings replacement with built in RegExp support. Written in 2021 by Glenn Larsson. Freeware and CC0.")
            Console.WriteLine("Syntax: RegStr filename.bin 'regexp' (true)".Replace("'", Chr(34)))
            Console.WriteLine("Last (true) is optional and fixes output if you're extracting domain names from certain files.")
            End
        End If

        Dim rx As System.Text.RegularExpressions.Regex
        Dim sLegitChars As String = "abcdefghijklmnopqrstuvwxyzABCEDFGHIJKLMNOPQRSTUVWXYZ0123456789-.*"

        Dim sFilename As String = ""
        Dim sRegExp As String = ""
        Dim sCleanCertExtact As String = "false"

        Try
            sFilename = sArg(1)
            sRegExp = sArg(2)
            sCleanCertExtact = sArg(3)
        Catch ex As Exception
        End Try

        Dim bBytes() As Byte = System.IO.File.ReadAllBytes(sFilename)

        Dim sTemp As String = ""
        For n = 0 To UBound(bBytes)
            If InStr(1, sLegitChars, Chr(bBytes(n))) > 0 Then
                sTemp = sTemp & Chr(bBytes(n))
            Else
                If rx.IsMatch(sTemp, sRegExp) Then
                    'If LCase(sCleanCertExtact) = "true" Then
                    If Microsoft.VisualBasic.Right(sTemp, 3) = "0Y0" Then sTemp = Microsoft.VisualBasic.Left(sTemp, Len(sTemp) - 3)
                    If Microsoft.VisualBasic.Right(sTemp, 1) = "0" Then sTemp = Microsoft.VisualBasic.Left(sTemp, Len(sTemp) - 1)
                    'End If
                    Console.WriteLine(sTemp)
            End If
            sTemp = ""
            End If
        Next

    End Sub
