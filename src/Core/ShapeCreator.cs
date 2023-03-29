namespace Core;

/// <summary>
/// Создатель фигур
/// </summary>
public static class ShapeCreator
{
	/// <summary>
	/// Получить площадь фигуры
	/// </summary>
	/// <param name="shapeName">Наименование фигуры</param>
	/// <param name="shapeArgs">Аргументы для создания фигуры</param>
	/// <returns>Площадь фигуры</returns>
	public static IShape GetShape(string shapeName, params object[] shapeArgs)
	{
		var shapeType = typeof(Circle).Assembly.ExportedTypes
			.FirstOrDefault(x =>
				x.Name == shapeName
				&& !x.IsAbstract
				&& x.IsAssignableTo(typeof(IShape)))
			?? throw new Exception($"Не найдена фигура с наименованием {shapeName}");

		return GetShape(shapeType, shapeArgs);
	}

	/// <summary>
	/// Получить площадь фигуры
	/// </summary>
	/// <param name="shapeType">Тип фигуры</param>
	/// <param name="shapeArgs">Аргументы для создания фигуры</param>
	/// <returns>Площадь фигуры</returns>
	public static IShape GetShape(Type shapeType, params object[] shapeArgs)
	{
		var isShapeTypeValid = shapeType.IsAssignableTo(typeof(IShape))
			&& !shapeType.IsAbstract
			&& !shapeType.IsInterface;
		
		if (!isShapeTypeValid)
			throw new Exception($"Ошибка: переданный тип {shapeType.Name} не реализует интерфейс {nameof(IShape)}");

		try
		{
			return (IShape)Activator.CreateInstance(shapeType, shapeArgs)!;
		}
		catch
		{
			throw new Exception($"Не удалось создать {shapeType.Name} с заданными параметрами {nameof(shapeArgs)}");
		}
	}
}