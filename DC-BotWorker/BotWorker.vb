Imports  NetCord
imports System
Imports Microsoft.Extensions.Configuration
Namespace Bot
    Public Shared Class BotWorker
        Public Shared Property Token as String
        Public Shared Property Prefix as String
        Public Shared Property Dev as Boolean = False
        Public Shared Property SkipReg as Boolean
        Public Shared ReadOnly Property Configuration
        'Dog
        
        Dim env = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT")
        
        

    End Class
End Namespace