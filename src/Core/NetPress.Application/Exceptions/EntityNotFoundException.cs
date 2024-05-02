namespace NetPress.Application.Exceptions
{
    public class EntityNotFoundException(Type entityType, params string[] filterConditions) : Exception($"No entity found with the given information ({entityType.FullName} -> {string.Join(",", filterConditions)})")
    {
    }
}
