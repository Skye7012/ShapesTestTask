using Shapes.Exceptions;

namespace Shapes.Shapes;

/// <summary>
/// Круг
/// </summary>
public class Circle : IShape
{
	/// <summary>
	/// Поле для <see cref="Radius"/>
	/// </summary>
	private double _radius;

	/// <summary>
	/// Конструктор
	/// </summary>
	/// <param name="radius">Радиус круга</param>
	public Circle(double radius)
		=> Radius = radius;

	/// <summary>
	/// Радиус круга
	/// </summary>
	public double Radius
	{
		get => _radius;
		private set
		{
			if (value <= 0)
				throw new ValidationException("Радиус должен быть больше нуля");

			_radius = value;
		}
	}

	/// <inheritdoc/>
	public double GetArea()
		=> Math.PI * Radius * Radius;
}