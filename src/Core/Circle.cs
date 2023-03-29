namespace Core;

/// <summary>
/// Круг
/// </summary>
public class Circle : IShape
{
	/// <summary>
	/// Конструктор
	/// </summary>
	/// <param name="raduis">Радиус круга</param>
	public Circle(double raduis)
		=> Radius = raduis;

	/// <summary>
	/// Радиус круга
	/// </summary>
	public double Radius { get; set; }

	/// <inheritdoc/>
	public double GetArea()
		=> Math.PI * Radius * Radius;
}