Imports NetCord
Imports NetCord.Rest
Imports NetCord.Services.ApplicationCommands

Public Class LocalDataWorker

    Private Const DataFile As String = "C:\Bot-Suggestion\sug.json"

    Public Shared Async Function CreateSuggestion(context As SlashCommandContext) As Task
        Await context.Interaction.SendResponseAsync(InteractionCallback.Modal(SuggestionModal.Build()))
    End Function

End Class