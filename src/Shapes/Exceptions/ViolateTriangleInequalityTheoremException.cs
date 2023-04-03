namespace Shapes.Exceptions;

/// <summary>
/// Нарушение теоремы о неравенстве треугольника
/// </summary>
public class ViolateTriangleInequalityTheoremException : Exception
{
	/// <summary>
	/// Конструктор
	/// </summary>
	/// <param name="maxSide">Наибольшая сторона</param>
	/// <param name="lessSide">Меньшая сторона</param>
	/// <param name="leastSide">Наименьшая сторона сторона</param>
	public ViolateTriangleInequalityTheoremException(
		double maxSide,
		double lessSide,
		double leastSide)
	: base("Каждая сторона треугольника должна быть " +
		"меньше суммы двух других сторон: " +
		$"{maxSide} >= {lessSide} + {leastSide}") 
	{ }
}