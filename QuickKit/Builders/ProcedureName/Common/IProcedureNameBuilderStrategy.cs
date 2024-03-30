namespace QuickKit.Builders.ProcedureName.Common;
/// <summary>
/// Represents a strategy for building procedure names.
/// </summary>
public interface IProcedureNameBuilderStrategy
{
    /// <summary>
    /// Builds the procedure name.
    /// </summary>
    /// <returns>The procedure name as a string.</returns>
    public string Build();
}