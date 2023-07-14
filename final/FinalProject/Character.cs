using System;

class Character
{
  private string _name;
  private int _age;
  private string _description;

  public void DisplayCharacterInfo()
  {
    Console.WriteLine($"Name: {_name}");
    Console.WriteLine($"Age: {_age}");
    Console.WriteLine($"Description: {_description}");
  }
  public Character(string name, int age, string description)
  {
    _name = name;
    _age = age;
    _description = description;
  }
}