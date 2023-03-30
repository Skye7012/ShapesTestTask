namespace Core.Shapes;

/// <summary>
/// Фигура не реализует <see cref="IShape"/>
/// </summary>
public class NotAssignableFromIShapeException : Exception
{
	/// <summary>
	/// Конструктор
	/// </summary>
	/// <param name="shapeName">Наименование фигуры</param>
	public NotAssignableFromIShapeException(string shapeName)
		: base($"Ошибка: переданный тип {shapeName} не реализует интерфейс {nameof(IShape)}")
	{
	}
}