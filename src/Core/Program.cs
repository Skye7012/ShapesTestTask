using Core;

var circle = ShapeCreator.GetShape(typeof(Circle), 4);
Console.WriteLine(circle.GetArea());

var triangle = ShapeCreator.GetShape("Triangle", 1, 2, 3);
Console.WriteLine(triangle.GetArea());
