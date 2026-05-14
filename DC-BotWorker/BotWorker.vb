Imports NetCord.Hosting.Gateway
Imports NetCord
Imports NetCord.Hosting.Services
Imports NetCord.Hosting.Services.ApplicationCommands
imports NetCord.Rest
imports MIcrosoft.Extensions.Logging
Imports Microsoft.Extensions.Hosting
Namespace Bot
    Public Class BotWorker
        
        Public Sub New()
            Start()
        End Sub
        
        Public Shared async sub Start()
            Dim builder as HostApplicationBuilder = Host.CreateApplicationBuilder()
            builder.Logging.ClearProviders()
            builder.Logging.AddConsole()
            builder.Services.AddDiscordGateway().AddApplicationCommands()
            
            Dim tempHost = builder.Build()
            tempHost.AddSlashCommand("status","get status if the serverr is currently up!",Function() "Currently the server is not working, not even remotely XD lmao" )
            temphost.Run()
        End sub
    End Class
End Namespace