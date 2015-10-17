using System;
using System.Collections.Generic;
using System.Linq;

public static class Program
{
    public static void Main()
    {
        var input = GetInput();
        if(!Char.IsLetter(input))
        {
            Console.WriteLine("");
            Console.WriteLine("You must enter a valid letter of the alphabet");
            return;
        }
        var letters = Letters(input);
        
        DrawDiamond(letters);
    }
    
    private static char GetInput()
    {
        Console.WriteLine("Please enter a letter of the alphabet: ");
        return Console.ReadKey().KeyChar;   
    }
	
	private static IEnumerable<AlphabetLetter> Letters(char input)
    {
        var num_letters = (int)input % 32;
        var letters = new List<AlphabetLetter>();
        var i = 0;
        
        while(i < num_letters)
        {
            letters.Add(new AlphabetLetter(Convert.ToChar(i + 65), num_letters));
            i += 1;
        }
		
		return letters;
    }
	
	private static void DrawDiamond(IEnumerable<AlphabetLetter> letters)
	{
	    Console.WriteLine("");
	    
	    foreach(var letter in letters)
	    {
	        letter.Write();
	    }
	    
	    int i = letters.Count() - 2;
	    while(i >= 0)
	    {
	        letters.ElementAt(i).Write();
	        i -= 1;
	    }
	}
}

public class AlphabetLetter
{
    public char Letter { get; set; }
    public int Left_Pad { get; set; }
    public int Inner_Pad { get; set; }
    
    public int Index
    {
        get
        {
            return (int)Letter % 32;  
        }
    }
    
    public int LeftPad(int num_letters)
    {
        return (num_letters - Index) + 1;    
    }
    
    public int InnerPad(int num_letters)
    {
        return ((Index - 1) * 2) + 1;
    }
    
    public AlphabetLetter(char letter, int num_letters)
    {
        Letter = letter;
        Left_Pad = LeftPad(num_letters);
        Inner_Pad = InnerPad(num_letters);
    }
    
    public void Write()
    {
        if (Index == 1)
        {
            Console.WriteLine(string.Format("{0}", Letter.ToString().PadLeft(Left_Pad)));
            return;
        }
        
        var output = string.Format("{0}{1}", Letter.ToString().PadLeft(Left_Pad), Letter.ToString().PadLeft(Inner_Pad));
        Console.WriteLine(output);
    }
    
    
}
