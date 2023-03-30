using FluentAssertions;
using Xunit;

namespace Core.UnitTests.ShapeTests
{
	/// <summary>
	/// Тесты для <see cref="Triangle"/>
	/// </summary>
	public class TriangleTests
	{
		/// <summary>
		/// Должен правильно подсчитать площадь, когда верно задан радиус
		/// </summary>
		[Fact]
		public void GetArea_ShoudReturnArea_WhenGivenValidRadius()
		{
			var triangle = new Triangle(3, 4, 5);

			var result = triangle.GetArea();

			result.Should().Be(6);
		}
		
		/// <summary>
		/// 
		/// </summary>
		[Theory]
		[InlineData(3, 4, 5, true)]
		[InlineData(3, 4, 6, false)]
		public void IsRight_ShouldReturnTrue_WhenTriangleIsRight(
			double firstSide, double secondSide, double thirdSide, bool isRight)
		{
			var triangle = new Triangle(firstSide, secondSide, thirdSide);

			var result = triangle.IsRight();

			result.Should().Be(isRight);
		}
	}
}