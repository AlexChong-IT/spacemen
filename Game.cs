using System;

namespace Spaceman
{
  class Game
  {
    //Properties
    private string Codeword {get; set;}     // winning word
    private string CurrentWord {get; set;}  // guessed letters of the winning word
    private int MaxGuess {get; set;}        // maximum tries before you lose
    private int CurrentGuess {get; set;}    // keeps track of current tries
    private int remainingTries {get; set;}  // remaining tries for the user
    private string[] CodeList {get; set;}   // list of all codeword options
    private Ufo f = new Ufo();              // Calls Ufo class

    //Constructor
    public Game()
    {
      //Generates random number for the codeword
      Random rnd = new Random();
      int randomNumber = rnd.Next(0,5);
      remainingTries = 5;
      CodeList = new string[5]
      {
        "banana",
        "apple",
        "peach",
        "person",
        "rat"
      };
    // Initialize Codeword before using it to determine the length
    Codeword = CodeList[randomNumber];

    // Initialize CurrentWord with underscores or placeholders
    char placeholder = '-'; // Example of using '-' as a placeholder
    CurrentWord = new string(placeholder, Codeword.Length);
      MaxGuess = 5;
      CurrentGuess = 0;

      //loop to generate underscores
      for(int i = 0; i > Codeword.Length; i++)
      {
        CurrentWord.Insert(i, "_");
      }
    }

    // Methods
    public void Greet()
    {
      Console.WriteLine("-----------------------------------------------");
      Console.WriteLine("Welcome to the Spaceman game!");
      Console.WriteLine("-----------------------------------------------");
    }
      //Win/Lose conditions
    public bool DidWin()
    {
      bool result = Codeword.Equals(CurrentWord);
      if(result)
      {
        Console.WriteLine($"Congratuliation you Won! The solution is {Codeword}");
        return result;
      }
      return result;
    }

    public bool DidLose()
    {
      if(remainingTries == 0 )
      {
        Console.WriteLine($"You lost! The solution is {Codeword}");
        return true;
      }
      else
      {
        return false;
      }
    }

    public void Display()
    {
      Console.WriteLine("-----------------------------------------------");
      Console.WriteLine(f.Stringify());
      Console.WriteLine("-----------------------------------------------");
      Console.WriteLine($"You have {(remainingTries)} tries remaining");
      Console.WriteLine("-----------------------------------------------");
    }
  

    public void Ask()
    {
      // User inputs his guess for the codeword
      Console.WriteLine("Please guess a letter: ");
      string guess = Console.ReadLine().ToLower(); // Convert the guess to lowercase for case-insensitive comparison

      // Checks if it's a letter
      if (guess.Length == 1 && char.IsLetter(guess[0]))
      {
          // checks if the letter is correctly guessed
          if (Codeword.Contains(guess))
          {
              // Replaces the _ with the correctly guessed letter
              Console.WriteLine("-----------------------------------------------");
              Console.WriteLine($"The letter {guess} is correct!");
              Console.WriteLine("-----------------------------------------------");
              int index = Codeword.IndexOf(guess);
              CurrentWord = CurrentWord.Remove(index, 1).Insert(index, guess);

              // Shows result
              Console.WriteLine($"{CurrentWord}");
          }
          else
          {
              remainingTries--;
              Console.WriteLine($"Sorry, the letter {guess} is incorrect. ");
              Console.WriteLine($"{CurrentWord}");
              f.AddPart();
          }
      }
      else
      {
          Console.WriteLine("Please enter a single letter!");
          return;
      }
    }

  }
}