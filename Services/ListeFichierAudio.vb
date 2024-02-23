Imports System.Net.Http

Public Class ListeFichierAudio
    Public Async Function GetAudios(client As HttpClient, apiKey As String) As Task
        Dim url As String = $"audios/{apiKey}"

        Try
            Dim response As HttpResponseMessage = Await client.GetAsync(url)
            If response.IsSuccessStatusCode Then
                Dim responseString As String = Await response.Content.ReadAsStringAsync()
                Console.WriteLine("Audios: " & responseString)
            Else
                Console.WriteLine("Error: " & response.ReasonPhrase)
            End If
        Catch ex As Exception
            Console.WriteLine("Exception: " & ex.Message)
        End Try
    End Function
End Class