using Core;

var circle = ShapeCreator.Create(typeof(Circle), 4);
Console.WriteLine(circle.GetArea());

var triangle = ShapeCreator.Create("Triangle", 1, 2, 3);
Console.WriteLine(triangle.GetArea());
