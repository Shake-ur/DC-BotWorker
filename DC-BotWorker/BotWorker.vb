Imports NetCord.Hosting.Gateway
Imports NetCord
Imports NetCord.Hosting.Services
Imports NetCord.Hosting.Services.ApplicationCommands
imports NetCord.Rest
imports MIcrosoft.Extensions.Logging
Imports Microsoft.Extensions.Hosting
Imports NetCord.Hosting.Services.ComponentInteractions
Imports NetCord.Services.ApplicationCommands
Imports NetCord.Modal
Imports NetCord.Services.ComponentInteractions

Namespace Bot
    Public Class BotWorker
        
        Public Sub New()
            Start()
        End Sub
        
        Public Shared async Function Start() as Task
            Dim builder as HostApplicationBuilder = Host.CreateApplicationBuilder()
            builder.Logging.ClearProviders()
            builder.Logging.AddConsole()
            builder.Services.AddDiscordGateway().AddApplicationCommands().AddComponentInteractions(Of ModalInteraction, ModalInteractionContext)
            
            Dim tempHost = builder.Build()

            tempHost.AddSlashCommand("status", "Get status if the server is currently up!",
                                     Function() "Currently the server is not working, not even remotely XD lmao")

            tempHost.AddSlashCommand("suggest", "Add a suggestion what feature would be cool to have here.",
                                     Function() InteractionCallback.Modal(SuggestionModal.Build()))

            tempHost.AddComponentInteraction("suggestion_modal",
                                             Function(context As ModalInteractionContext) SuggestionModalHandler.HandleSuggestionModal(context))

            await temphost.RunAsync()
        End Function
    End Class
End Namespace