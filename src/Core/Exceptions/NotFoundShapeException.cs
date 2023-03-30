namespace Core.Shapes;

/// <summary>
/// Не найдена фигура
/// </summary>
public class NotFoundShapeException : Exception
{
	/// <summary>
	/// Конструктор
	/// </summary>
	/// <param name="shapeName">Наименование фигуры</param>
	public NotFoundShapeException(string shapeName)
		: base($"Не удалось найти фигуру с наименованием '{shapeName}'")
	{
	}
}