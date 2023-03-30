using FluentAssertions;
using Xunit;

namespace Core.UnitTests
{
	/// <summary>
	/// Тесты для <see cref="ShapeCreator"/>
	/// </summary>
	public class ShapeCreatorTest
	{
		/// <summary>
		/// Должен создать круг, если правильно указан тип и аргументы для создания
		/// </summary>
		[Fact]
		public void Create_ShoudCreateCircle_WhenGivenValidCircleTypeAndArgs()
		{
			var result = ShapeCreator.Create(typeof(Circle), 4);

			result.Should().NotBeNull();
			result.Should().BeAssignableTo<Circle>();
		}

		/// <summary>
		/// Должен создать треугольник, если правильно указано название фигуры и аргументы для создания
		/// </summary>
		[Fact]
		public void Create_ShoudCreateTriangle_WhenGivenValidShapeNameAndArgs()
		{
			var result = ShapeCreator.Create(nameof(Triangle), 3, 4, 5);

			result.Should().NotBeNull();
			result.Should().BeAssignableTo<Triangle>();
		}
	}
}