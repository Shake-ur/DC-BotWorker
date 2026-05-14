Imports NetCord
Imports NetCord.Rest

Public Class SuggestionModal

    Public Shared Function Build() As ModalProperties
        Return New ModalProperties("suggestion_modal", "Submit a Suggestion") With {
            .Components = New List(Of LabelProperties) From {
                New LabelProperties("Feature Name",
                                    New TextInputProperties("suggestion_name", TextInputStyle.Short) With {
                                       .Placeholder = "Give your feature a short name",
                                       .MinLength = 1,
                                       .MaxLength = 80,
                                       .Required = True
                                       }
                                    ),
                New LabelProperties("Description",
                                    New TextInputProperties("suggestion_description", TextInputStyle.Paragraph) With {
                                       .Placeholder = "Describe what the feature should do...",
                                       .MinLength = 0,
                                       .MaxLength = 1000,
                                       .Required = True
                                       }
                                    )
                }
            }
    End Function

End Class