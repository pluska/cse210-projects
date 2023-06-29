using System;

class MenuManager
{
  private List<string> _menus;
  private bool _keepRunning;
  public void DisplayMenu(int indexMenu)
  {
    Console.WriteLine(_menus[indexMenu]);
  }
  public void QuitProgram()
  {
    _keepRunning = false;
    Console.WriteLine("Goodbye!");
  }
  public bool GetKeepRunning()
  {
    return _keepRunning;
  }
  public MenuManager(List<string> menus)
  {
    _menus = menus;
    _keepRunning = true;
  }
}