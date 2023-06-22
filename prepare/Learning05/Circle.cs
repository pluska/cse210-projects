using System;

class Circle: Shape
{
  private double _radius;

  public override double GetArea()
  {
    return _radius * _radius * Math.PI;
  }
  public Circle(double radius, string color): base(color)
  {
    _radius = radius;
  }
}
