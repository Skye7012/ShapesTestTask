namespace Core.Shapes;

/// <summary>
/// Ошибка не валидных аргументов для создания фигуры
/// </summary>
public class NotValidShapeConstructorArgumentsException : Exception
{
	/// <summary>
	/// Конструктор
	/// </summary>
	/// <param name="shapeName">Наименование фигуры</param>
	public NotValidShapeConstructorArgumentsException(string shapeName)
		: base($"Не удалось создать {shapeName} с заданными аргументами для создания фигуры")
	{
	}
}