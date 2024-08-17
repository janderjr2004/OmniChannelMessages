namespace OC.Validations.Errors
{
    public static class ErrorSendMessage
    {
        public static ErrorMessage EmptyMessage =>
            Error.Validation(
                "SendMessage.ConnectionStringUnableToRetrieve",
                "Empty or Null MessageObject in the request!"
            );

        public static ErrorMessage EmptySubject =>
            Error.Validation(
                "SendMessage.EmptySubject",
                "Subject is required in Email provider type!"
            );

        public static ErrorMessage EmptySmtpConfiguration =>
            Error.Validation(
                "SendMessage.EmptySmtpConfiguration",
                "SmtpConfiguration is required in Email provider type!"
            );

        public static ErrorMessage EmptyRecipient =>
            Error.Validation(
                "SendMessage.EmptyRecipient",
                "Empty or Null Recipient in the request!"
            );        
        
        public static ErrorMessage EmptySender =>
            Error.Validation(
                "SendMessage.EmptySender",
                "Empty or Null Sender in the request!"
            );        
        
        public static ErrorMessage EmptyProviderType =>
            Error.Validation(
                "SendMessage.EmptyProviderType",
                "Empty or Null ProviderType in the request!"
            );        
        
        public static ErrorMessage CannotSendMessage =>
            Error.Validation(
                "SendMessage.CannotSendMessage",
                "Cannot send message, please retry again!"
            );
    }
}
