using QuickKit.Shared.Entities;

namespace QuickKit.Shared.Builders
{
    /// <summary>
    /// Represents a builder class for generating procedure names based on the entity type.
    /// <para>Remove the "Entity" suffix from the entity type name and convert it to lowercase.</para>
    /// <para>These names are used to call the stored procedures in the database.</para>
    /// <para>Example: For a stored procedure for add a PersonEntity, the output would be "sp_person_add"</para>
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public class ProcedureNameEntityBuilder<TEntity> where TEntity : IEntity
    {
        /// <summary>
        /// Gets the name for the "Add" procedure.
        /// </summary>
        public static string Add => $"{BuildName()}_add";

        /// <summary>
        /// Gets the name for the "Update" procedure.
        /// </summary>
        public static string Update => $"{BuildName()}_update";

        /// <summary>
        /// Gets the name for the "Delete" procedure.
        /// </summary>
        public static string Delete => $"{BuildName()}_delete";

        /// <summary>
        /// Gets the name for the "GetAll" procedure.
        /// </summary>
        public static string GetAll => $"{BuildName()}_getAll";

        /// <summary>
        /// Gets the name for the "GetById" procedure.
        /// </summary>
        public static string GetById => $"{BuildName()}_getById";

        /// <summary>
        /// Generates the base name for the procedures based on the entity type.
        /// </summary>
        /// <returns>The generated base name.</returns>
        private static string BuildName()
        {
            return $"sp_{typeof(TEntity).Name.ToLower().Replace("entity", "")}";
        }

        /// <summary>
        /// Gets the name for the "ExistsById" procedure.
        /// </summary>
        /// <returns>The name for the "ExistsById" procedure.</returns>
        public static string ExistsById()
        {
            return $"{BuildName()}_existsById";
        }
    }
}
