namespace Shapes.Exceptions;

/// <summary>
/// Ошибка валидации
/// </summary>
public class ValidationException : Exception
{
	/// <summary>
	/// Конструктор
	/// </summary>
	/// <param name="message">Сообщение</param>
	public ValidationException(string message) : base(message) { }
}