using Shapes.Exceptions;

namespace Shapes.Shapes;

/// <summary>
/// Треугольник
/// </summary>
public class Triangle : IShape
{
	/// <summary>
	/// Конструктор
	/// </summary>
	/// <param name="firstSide">Первая сторона треугольника</param>
	/// <param name="secondSide">Вторая сторона треугольника</param>
	/// <param name="thirdSide">Третья сторона треугольника</param>
	public Triangle(double firstSide, double secondSide, double thirdSide)
	{
		FirstSide = firstSide;
		SecondSide = secondSide;
		ThirdSide = thirdSide;

		Validate();
	}

	/// <summary>
	/// Первая сторона треугольника
	/// </summary>
	public double FirstSide { get; private set; }

	/// <summary>
	/// Вторая сторона треугольника
	/// </summary>
	public double SecondSide { get; private set; }

	/// <summary>
	/// Третья сторона треугольника
	/// </summary>
	public double ThirdSide { get; private set; }

	/// <summary>
	/// Стороны треугольника
	/// </summary>
	private double[] Sides => new[] { FirstSide, SecondSide, ThirdSide };

	/// <inheritdoc/>
	public double GetArea()
	{
		var semiPerimeter = Sides.Aggregate((a, b) => a + b) / 2;
		return Math.Sqrt(
			semiPerimeter
			* (semiPerimeter - FirstSide)
			* (semiPerimeter - SecondSide)
			* (semiPerimeter - ThirdSide));
	}

	/// <summary>
	/// Является ли прямоугольным
	/// </summary>
	/// <param name="epsilon">Погрешность</param>
	/// <returns>Является ли прямоугольным</returns>
	public bool IsRight(double epsilon = 0.00001)
	{
		var sides = Sides;
		Array.Sort(sides);
		return Math.Abs(Math.Pow(sides[2], 2) - (Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2))) < epsilon;
	}

	/// <summary>
	/// Провести валидацию
	/// </summary>
	private void Validate()
	{
		if (Sides.Any(x => x <= 0))
			throw new ValidationException("Стороны треугольника должна быть больше нуля");

		var sides = Sides;
		Array.Sort(sides);

		if (sides[2] >= sides[1] + sides[0])
			throw new ViolateTriangleInequalityTheoremException(sides[2], sides[1], sides[0]);
	}
}