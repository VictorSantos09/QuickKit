namespace QuickKit.AspNetCore.Constants;

/// <summary>
/// Contains the endpoint naming conventions from the QuickKit Framework.
/// </summary>
public readonly struct ENDPOINT_NAME_CNT_KIT
{
    /// <summary>
    /// Represents the "delete" endpoint.
    /// </summary>
    public const string DELETE = "delete";

    /// <summary>
    /// Represents the "add" endpoint.
    /// </summary>
    public const string ADD = "add";

    /// <summary>
    /// Represents the "update" endpoint.
    /// </summary>
    public const string UPDATE = "update";

    /// <summary>
    /// Represents the "get all" endpoint.
    /// </summary>
    public const string GET_ALL = "";

    /// <summary>
    /// Represents the "get by id" endpoint with a placeholder for the ID.
    /// </summary>
    public const string GET_BY_ID = "{id}";

    /// <summary>
    /// Represents the "test" endpoint.
    /// </summary>
    public const string TEST = "test";
}
