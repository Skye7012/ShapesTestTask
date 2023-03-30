using FluentAssertions;
using Xunit;

namespace Core.UnitTests.ShapeTests
{
	/// <summary>
	/// Тесты для <see cref="Circle"/>
	/// </summary>
	public class CircleTests
	{
		/// <summary>
		/// Должен правильно подсчитать площадь, когда верно задан радиус
		/// </summary>
		[Fact]
		public void GetArea_ShoudReturnArea_WhenGivenValidRadius()
		{
			var circle = new Circle(4);

			var result = circle.GetArea();

			result.Should().Be(50.26548245743669);
		}
	}
}