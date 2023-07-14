using System;

class Menu
{
  List<string> _options;

  public void DisplayMenu()
  {
    for (int i = 0; i < _options.Count; i++)
    {
      Console.WriteLine($"{i + 1}. {_options[i]}");
    }
  }

  public Menu(List<string> options)
  {
    _options = options;
  }

}