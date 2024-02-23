Imports System.Net.Http

Public Class SupprimeEnvoiDiffere
    Public Async Function CancelCampaignAsync() As Task
        Using client As New HttpClient()
            Dim apiKey As String = "YOUR_API_KEY"
            Dim campaignId As String = "CAMPAIGN_ID"
            Dim url As String = $"https://api.voicepartner.fr/v1/campaign/cancel/{apiKey}/{campaignId}"

            Try
                Dim response = Await client.DeleteAsync(url)
                Dim responseContent = Await response.Content.ReadAsStringAsync()

                If response.IsSuccessStatusCode Then
                    Console.WriteLine(responseContent)
                Else
                    Console.WriteLine($"Erreur: {response.StatusCode}")
                    Console.WriteLine($"Contenu : {responseContent}")
                End If
            Catch ex As Exception
                Console.WriteLine($"Exception: {ex.Message}")
            End Try
        End Using
    End Function
End Class

