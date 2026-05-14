Imports System.IO
Imports System.Text.Json
Imports System.Text.Json.Nodes
Imports Netcord
Imports NetCord.Rest
Imports Netcord.Services.ApplicationCommands
Imports NetCord.Services.ComponentInteractions

Public Class SuggestionModalHandler
    
    Private Const DataFile As String = "C:\Bot-Suggestion\sug.json"

    Public Async Shared Function HandleSuggestionModal(context as ModalInteractionContext) as Task
        Dim user = Context.Interaction.User
        Dim inputs = Context.Components.OfType(Of Label).Select(Function(x) x.Component).OfType(Of TextInput).ToList()
        Dim name = inputs.First((FunctioN(x) x.CustomId = "suggestion_name")).Value
        Dim description = inputs.First((FunctioN(x) x.CustomId = "suggestion_description")).Value
        
        Dim data = LoadData()
        Dim entry = New JsonObject From{
                {"id",data.count+1},
                {"name",name},
                {"description",description},
                {"submittedBy", user.Username},
                {"userId",user.Id.ToString()},
                {"timestamp",DateTime.Now.ToString()}}
        data(Guid.NewGuid().ToString()) = entry
        SaveData(data)
        Await context.Interaction.SendResponseAsync(InteractionCallback.Message(New InteractionMessageProperties() With {.Content = $"Tank yuh **{user.GlobalName}**, wi get an log yuh suggestion **{name}**",
                                                          .Flags = MessageFlags.Ephemeral}))
    End Function
    Private Shared Function LoadData() as JsonObject
        if FIle.Exists(DataFile) then
            Dim Content = File.ReadALlText(DataFile)
            if not String.IsNullOrEmpty(Content) then
            Return JsonNode.Parse(File.ReadAllText(DataFile)).AsObject()
            end if  
        End If
        Return New JsonObject()
    End Function
    Private Shared Sub SaveData(data as JsonObject)
        File.WriteAllText(DataFile, data.ToJsonString(New JsonSerializerOptions With {.WriteIndented = True}))
    End Sub
End Class