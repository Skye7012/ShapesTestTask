using Core;
using Core.Shapes;

var circle = ShapeCreator.Create(typeof(Circle), -5);
Console.WriteLine(circle.GetArea());

var triangle = ShapeCreator.Create("Triangle", 1, 2, 3);
Console.WriteLine(triangle.GetArea());
