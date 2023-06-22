using System;

class Square: Shape
{
  private double _side;
  public override double GetArea()
  {
    return _side * _side;
  }
  public Square(double side, string color) : base(color)
  {
    _side = side;
  }
}
  
