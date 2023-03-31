using FluentAssertions;
using Shapes.Exceptions;
using Shapes.Shapes;
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
	/// Должен выбросить ошибку валидации при создании треугольника с стороной <= 0
	/// </summary>
	[Fact]
	public void Ctor_ShouldThrow_WhenGivenNotPositiveSide()
	{
		var circleCreation = () => new Triangle(-1, 3, 2);

		circleCreation.Should()
			.Throw<ValidationException>()
			.WithMessage("Стороны треугольника должна быть больше нуля");
	}

	/// <summary>
	/// Должен выбросить ошибку валидации при создании треугольника
	/// с нарушением теоремы о неравенстве треугольника
	/// </summary>
	[Fact]
	public void Ctor_ShouldThrow_WhenGivenBreakTriangleInequalityTheorem()
	{
		var circleCreation = () => new Triangle(4, 10, 2);

		circleCreation.Should()
			.Throw<ValidationException>()
			.WithMessage("Длина любой стороны треугольника не может быть " +
				"больше суммы длин двух других сторон: " +
				$"{10} > {2} + {4}");
	}
}
