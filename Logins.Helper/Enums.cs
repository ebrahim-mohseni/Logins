namespace Logins.Helper
{
    public enum EnumLookup
    {
        UserType = 1,
        Position = 2
    }

    public enum EnumErrorStatus
    {
        NoError = 0,
        LogicError = 1,
        CatchError = 2
    }

    public enum EnumLogType
    {
        Information = 1,
        Debug = 2,
        Error = 3
    }

    public enum EnumErrorType
    {
        Database = 1,
        Service = 2
    }
}
