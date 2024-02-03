namespace OC.Validations.Errors
{
    public static class ErrorConnectionString
    {
        public static ErrorMessage ConnectionStringUnableToRetrieve =>
            Error.Validation(
                "ConnectionString.ConnectionStringUnableToRetrieve",
                "Unable to retrieve connection string!"
            );
    }
}
