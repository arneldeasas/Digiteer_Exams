namespace Application.TaskManager.Exceptions;

public class DatabaseException : Exception
{
	public DatabaseException()
		: base("An unhandled error in addon database occurred.") { }

	public DatabaseException(string message)
		: base(message) { }

	public DatabaseException(string message, Exception innerException)
		: base(message, innerException) { }
}

