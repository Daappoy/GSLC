using System;

internal class Program
{
    private string randomWord;
    private string guessedWord;

    public Program()
    {
        randomWord = WordCollection.GetRandomWord();
        guessedWord = new string('_', randomWord.Length); // Initialize guessedWord with underscores

        do
        {
            ShowGuessedWord();
            GetAnswer();
        } while (!AllWordGuessed());

        Console.WriteLine("Congratulations! You guessed the word.");
    }

    private void GetAnswer()
    {
        Console.WriteLine($"Give 1 letter [A-Z]: ");
        string letter = Console.ReadLine();

        if (!string.IsNullOrEmpty(letter) && letter.Length == 1)
        {
            if (IsContainedInRandomWord(letter))
            {
                Replace(letter);
            }
            else
            {
                Console.WriteLine("Letter not in word. Try again.");
            }
        }
        else
        {
            Console.WriteLine("Please enter a valid single letter.");
        }
    }

    /// <summary>
    /// Replaces the "_" in guessedWord with the correct letter where it exists in randomWord.
    /// </summary>
    /// <param name="letter">The letter to replace the underscores with</param>
    private void Replace(string letter)
    {
        char[] guessedArray = guessedWord.ToCharArray();
        for (int i = 0; i < randomWord.Length; i++)
        {
            if (randomWord[i] == letter[0])
            {
                guessedArray[i] = letter[0]; // Replace the correct position in guessedWord
            }
        }
        guessedWord = new string(guessedArray); // Update guessedWord with the new string
    }

    /// <summary>
    /// Checks if the input letter is contained in randomWord.
    /// </summary>
    /// <param name="letter">The letter to check</param>
    /// <returns>True if the letter is in randomWord, otherwise false</returns>
    private bool IsContainedInRandomWord(string letter)
    {
        return randomWord.Contains(letter);
    }

    private bool AllWordGuessed()
    {
        return !guessedWord.Contains("_");
    }

    private void ShowGuessedWord()
    {
        Console.WriteLine("Guess the word:");
        foreach (char c in guessedWord)
        {
            Console.Write($"{c} ");
        }
        Console.WriteLine();
    }

    static void Main(string[] args)
    {
        new Program();
    }
}

internal static class WordCollection
{
    public static string[] words = {
        "buyer",
        "flight",
        "wedding",
        "control",
        "development",
        "photo",
        "permission",
        "shopping",
        "candidate",
        "skill" };

    public static string GetRandomWord()
    {
        int r = new Random().Next(words.Length);
        return words[r];
    }
}