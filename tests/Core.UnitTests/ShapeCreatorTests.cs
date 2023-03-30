using Core.Shapes;
using FluentAssertions;
using Xunit;

namespace Core.UnitTests;

/// <summary>
/// Тесты для <see cref="ShapeCreator"/>
/// </summary>
public class ShapeCreatorTests
{
	/// <summary>
	/// Должен создать круг, если правильно указан тип и аргументы для создания
	/// </summary>
	[Fact]
	public void Create_ShouldCreateCircle_WhenGivenValidCircleTypeAndArgs()
	{
		var result = ShapeCreator.Create(typeof(Circle), 4);

		result.Should().NotBeNull();
		result.Should().BeAssignableTo<Circle>();
	}

	/// <summary>
	/// Должен создать треугольник, если правильно указано название фигуры и аргументы для создания
	/// </summary>
	[Fact]
	public void Create_ShouldCreateTriangle_WhenGivenValidShapeNameAndArgs()
	{
		var result = ShapeCreator.Create(nameof(Triangle), 3, 4, 5);

		result.Should().NotBeNull();
		result.Should().BeAssignableTo<Triangle>();
	}

	/// <summary>
	/// Должен выбросить ошибку, когда пытается создать не существующую фигуру
	/// </summary>
	[Fact]
	public void Create_ShouldThrow_WhenNotFoundShape()
	{
		var circleCreation = () => ShapeCreator.Create("Rhombus", 3, 4, 5);

		circleCreation.Should()
			.Throw<NotFoundShapeException>()
			.WithMessage($"Не удалось найти фигуру с наименованием 'Rhombus'");
	}

	/// <summary>
	/// Должен выбросить ошибку, когда передают не валидный тип фигуры
	/// </summary>
	[Fact]
	public void Create_ShouldThrow_WhenShapeTypeNotValid()
	{
		var circleCreation = () => ShapeCreator.Create(typeof(ShapeCreatorTests), 3, 4, 5);

		circleCreation.Should()
			.Throw<NotAssignableFromIShapeException>()
			.WithMessage($"Ошибка: переданный тип {nameof(ShapeCreatorTests)} не реализует интерфейс {nameof(IShape)}");
	}

	/// <summary>
	/// Должен выбросить ошибку, когда передают не валидные аргументы для создания фигуры
	/// </summary>
	[Fact]
	public void Create_ShouldThrow_WhenGivenNotValidShapeArgs()
	{
		var circleCreation = () => ShapeCreator.Create(typeof(Circle), "круг");

		circleCreation.Should()
			.Throw<NotValidShapeConstructorArgumentsException>()
			.WithMessage($"Не удалось создать {nameof(Circle)} с заданными аргументами для создания фигуры");
	}
}
