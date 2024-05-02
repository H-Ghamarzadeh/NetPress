namespace NetPress.Application.Exceptions;

public class MissingOrInvalidOrNullPropertyValueException(Type classType, params string[] propertyName) : Exception($"Required property value is missing or invalid or null ({classType.FullName} -> {string.Join(",", propertyName)})")
{
}