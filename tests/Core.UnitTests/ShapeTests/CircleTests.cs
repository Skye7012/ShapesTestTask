using Core.Shapes;
using FluentAssertions;
using Xunit;

namespace Core.UnitTests.ShapeTests;

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
	/// Должен выбросить ошибку валидации при создании круга с отрицательным радиусом
	/// </summary>
	[Fact]
	public void Ctor_ShouldThrow_WhenGivenNegativeRadius()
	{
		var circleCreation = () => new Circle(-4);

		circleCreation.Should()
			.Throw<ValidationException>()
			.WithMessage("Радиус должен быть больше нуля");
	}
}
