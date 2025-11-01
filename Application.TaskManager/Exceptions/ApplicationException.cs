namespace Application.TaskManager.Exceptions;

public class ApplicationException : Exception
{
	public ApplicationException()
		: base("An unhandled error in application occurred.") { }

	public ApplicationException(string message)
		: base(message) { }

	public ApplicationException(string? message, Exception? innerException) : base(message, innerException)
	{
	}
}

public class  ItemNotFoundException : ApplicationException
{
	public ItemNotFoundException() : base("Item not found") { }
	public ItemNotFoundException(string itemType) : base($"Item of type {itemType} not found") { }

	public ItemNotFoundException(string? message, Exception? innerException) : base(message, innerException)
	{
	}
}

