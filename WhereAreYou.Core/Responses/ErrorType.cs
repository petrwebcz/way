namespace WhereAreYou.Core.Responses
{
    public enum ErrorType
    {
        Validation, //Server validation - HTTP 405 Bad Request err (+ summary client validaiton in feature)
        Error, //Server HTTP 401 Not authorized err + Client handled exceptions (network shits, not supported  browser functions etc),
        Critical //Server application shits HTTP 5xx + Client unhadled exceptions (bugs)
    }
}