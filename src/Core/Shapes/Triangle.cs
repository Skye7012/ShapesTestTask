namespace Core.Shapes;

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
			var secondSide = Sides[(i + 1) % 3];
			var thirdSide = Sides[(i + 2) % 3];

			if (firstSide * firstSide == secondSide * secondSide + thirdSide * thirdSide)
			{
				legs[0] = secondSide;
				legs[1] = thirdSide;
				return true;
			}
		}

		return false;
	}

	/// <summary>
	/// Провести валидацию
	/// </summary>
	private void Validate()
	{
		if (Sides.Any(x => x <= 0))
			throw new ValidationException("Стороны треугольника должна быть больше нуля");

		for (int i = 0; i < Sides.Count(); i++)
		{
			var firstSide = Sides[i];
			var secondSide = Sides[(i + 1) % 3];
			var thirdSide = Sides[(i + 2) % 3];

			if (firstSide > secondSide + thirdSide)
			{
				throw new ValidationException("Длина любой стороны треугольника не может быть " +
					"больше суммы длин двух других сторон: " +
					$"{firstSide} > {secondSide} + {thirdSide}");
			}
		}

	}
}