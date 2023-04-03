using FluentAssertions;
using Shapes.Exceptions;
using Shapes.Shapes;
using System;
using System.Linq;
using Xunit;

namespace Shapes.UnitTests.ShapeTests;

/// <summary>
/// Тесты для <see cref="Triangle"/>
/// </summary>
public class TriangleTests
{
	/// <summary>
	/// Должен правильно подсчитать площадь, когда верно заданы стороны треугольника
	/// </summary>
	[Fact]
	public void GetArea_ShouldReturnArea_WhenGivenValidSides()
	{
		var triangle = new Triangle(3, 4, 5);

		var result = triangle.GetArea();

		result.Should().Be(6);
	}

	/// <summary>
	/// Должен вернуть true, если треугольник прямоугольный
	/// </summary>
	/// <param name="firstSide">Первая сторона треугольника</param>
	/// <param name="secondSide">Вторая сторона треугольника</param>
	/// <param name="thirdSide">Третья сторона треугольника</param>
	/// <param name="isRight">Является ли треугольник прямоугольным</param>
	[Theory]
	[InlineData(5, 4, 3, true)]
	[InlineData(4, 5, 3, true)]
	[InlineData(3, 4, 6, false)]
	public void IsRight_ShouldReturnTrue_WhenTriangleIsRight(
		double firstSide,
		double secondSide,
		double thirdSide,
		bool isRight)
	{
		var triangle = new Triangle(firstSide, secondSide, thirdSide);

		var result = triangle.IsRight();

		result.Should().Be(isRight);
	}

	/// <summary>
	/// Должен вернуть true, учитывая погрешность double
	/// </summary>
	[Fact]
	public void IsRight_ShouldReturnTrue_WhenSidesHaveDoublePrecisionLimitation()
	{
		var triangle = new Triangle(2 * Math.Sqrt(2), 2 * Math.Sqrt(2), 4);

		var result = triangle.IsRight();

		result.Should().Be(true);
	}

	/// <summary>
	/// Должен выбросить ошибку валидации при создании треугольника с стороной <= 0
	/// </summary>
	[Fact]
	public void Ctor_ShouldThrow_WhenGivenNotPositiveSide()
	{
		var triangleCreation = () => new Triangle(-1, 3, 2);

		triangleCreation.Should()
			.Throw<ValidationException>()
			.WithMessage("Стороны треугольника должна быть больше нуля");
	}

	/// <summary>
	/// Должен выбросить ошибку валидации при создании треугольника
	/// с нарушением теоремы о неравенстве треугольника
	/// </summary>
	/// <param name="sides">Стороны треугольника</param>
	[Theory]
	[InlineData(new double[] { 4, 10, 2 })]
	[InlineData(new double[] { 10, 2, 4 })]
	[InlineData(new double[] { 4, 2, 10 })]
	public void Ctor_ShouldThrow_WhenGivenBreakTriangleInequalityTheorem(double[] sides)
	{
		var triangleCreation = () => new Triangle(sides[0], sides[1], sides[2]);

		Array.Sort(sides);

		triangleCreation.Should()
			.Throw<ViolateTriangleInequalityTheoremException>()
			.WithMessage("Каждая сторона треугольника должна быть " +
				"меньше суммы двух других сторон: " +
				$"{sides[2]} >= {sides[1]} + {sides[0]}");
	}
}
