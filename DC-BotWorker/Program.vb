Imports NetCord.Hosting.Gateway
imports System
imports MIcrosoft.Extensions.Logging
Imports Microsoft.Extensions.Hosting
Namespace Bot
    Module Program
        Public  Sub Main()
            BotWorker.Start().GetAwaiter().GetResult()
        End sub
    End Module
End namespace

