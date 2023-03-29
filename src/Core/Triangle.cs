namespace Core;

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
	}

	/// <summary>
	/// Первая сторона треугольника
	/// </summary>
	public double FirstSide { get; set; }

	/// <summary>
	/// Вторая сторона треугольника
	/// </summary>
	public double SecondSide { get; set; }

	/// <summary>
	/// Третья сторона треугольника
	/// </summary>
	public double ThirdSide { get; set; }

	/// <summary>
	/// Стороны треугольника
	/// </summary>
	private double[] Sides => new[] { FirstSide, SecondSide, ThirdSide };

	/// <inheritdoc/>
	public double GetArea()
	{
		var semiPerimeter = Sides.Aggregate((a, b) => a + b);
		return Math.Sqrt(
			semiPerimeter
			* (semiPerimeter - FirstSide)
			* (semiPerimeter - SecondSide)
			* (semiPerimeter - ThirdSide));
	}

	/// <summary>
	/// Является ли прямоугольным
	/// </summary>
	/// <returns>Является ли прямоугольным</returns>
	public bool IsRight()
		=> IsRight(out var legs);

	/// <summary>
	/// Является ли прямоугольным
	/// </summary>
	/// <param name="legs">Катеты</param>
	/// <returns>Является ли прямоугольным</returns>
	private bool IsRight(out double[] legs)
	{
		legs = new double[2];

		for (int i = 0; i < Sides.Count(); i++)
		{
			var firstSide = Sides[i];
			var secondSide = Sides[(i + 1) % 2];
			var thirdSide = Sides[(i + 2) % 2];

			if (firstSide * firstSide == (secondSide * secondSide + thirdSide * thirdSide))
			{
				legs[0] = secondSide;
				legs[1] = thirdSide;
			}
		}

		return false;
	}
}