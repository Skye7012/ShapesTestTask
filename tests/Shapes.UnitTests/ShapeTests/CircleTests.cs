using FluentAssertions;
using Shapes.Exceptions;
using Shapes.Shapes;
using Xunit;

namespace Shapes.UnitTests.ShapeTests;

/// <summary>
/// Тесты для <see cref="Circle"/>
/// </summary>
public class CircleTests
{
	/// <summary>
	/// Должен правильно подсчитать площадь, когда верно задан радиус
	/// </summary>
	[Fact]
	public void GetArea_ShouldReturnArea_WhenGivenValidRadius()
	{
		var circle = new Circle(4);

		var result = circle.GetArea();

		result.Should().Be(50.26548245743669);
	}

	/// <summary>
	/// Должен выбросить ошибку валидации при создании круга с радиусом <= 0
	/// </summary>
	[Fact]
	public void Ctor_ShouldThrow_WhenGivenNotPositiveRadius()
	{
		var circleCreation = () => new Circle(-4);

		circleCreation.Should()
			.Throw<ValidationException>()
			.WithMessage("Радиус должен быть больше нуля");
	}
}
