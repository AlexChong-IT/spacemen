using System;

namespace Spaceman
{
  class Program
  {
    static void Main(string[] args)
    {
      Game Spaceman = new Game();
      Spaceman.Greet();
      while(true)
      {
        if(Spaceman.DidWin() || Spaceman.DidLose())
        {
          break;
        }
        Spaceman.Display();
        Spaceman.Ask();
      }
      
    }
  }
}