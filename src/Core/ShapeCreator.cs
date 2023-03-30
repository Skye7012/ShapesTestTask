using Core.Shapes;

namespace Core;

/// <summary>
/// Создатель фигур
/// </summary>
public static class ShapeCreator
{
	/// <summary>
	/// Создать фигуру
	/// </summary>
	/// <param name="shapeName">Наименование фигуры</param>
	/// <param name="shapeArgs">Аргументы для создания фигуры</param>
	/// <returns>Фигура</returns>
	public static IShape Create(string shapeName, params object[] shapeArgs)
	{
		var shapeType = typeof(Circle).Assembly.ExportedTypes
			.FirstOrDefault(x =>
				x.Name == shapeName
				&& !x.IsAbstract
				&& x.IsAssignableTo(typeof(IShape)))
			?? throw new NotFoundShapeException(shapeName);

		return Create(shapeType, shapeArgs);
	}

	/// <summary>
	/// Создать фигуру
	/// </summary>
	/// <param name="shapeType">Тип фигуры</param>
	/// <param name="shapeArgs">Аргументы для создания фигуры</param>
	/// <returns>Фигура</returns>
	public static IShape Create(Type shapeType, params object[] shapeArgs)
	{
		var isShapeTypeValid = (typeof(IShape)).IsAssignableFrom(shapeType)
			&& !shapeType.IsAbstract
			&& !shapeType.IsInterface;
		
		if (!isShapeTypeValid)
			throw new NotAssignableFromIShapeException(shapeType.Name);

		try
		{
			return (IShape)Activator.CreateInstance(shapeType, shapeArgs)!;
		}
		catch (Exception ex)
		{
			if(ex.InnerException is ValidationException)
				throw;

			throw new NotValidShapeConstructorArgumentsException(shapeType.Name);
		}
	}
}