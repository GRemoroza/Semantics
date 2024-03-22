using System;

class Program
{
    static void Main(string[] args)
    {
        for (int i = 0; i < 5; i++)
        {
            Console.Write($"Enter sentence {i + 1}:");
            string userSentence = Console.ReadLine();
            DeriveSentence(userSentence);
            Console.WriteLine();
        }
    }

    static void DeriveSentence(string userSentence)
    {
        string[] parts = userSentence.Split('=');
        string lhsVariable = parts[0].Trim();
        string rhsExpression = parts[1].Trim();

        Console.WriteLine("Derivation Steps:");

        
        Console.WriteLine($"- <assign>=>");
        Console.WriteLine($"- <id>=expression=>");
        Console.WriteLine($"- {lhsVariable}=<id>-<expression>");

        string[] expressionParts = rhsExpression.Split(new char[] { '+', '-', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (string part in expressionParts)
        {
            Console.WriteLine($"- {lhsVariable}={lhsVariable}-{part}");
        }

        Console.WriteLine($"- {lhsVariable}={lhsVariable}-({expressionParts[0]}");
        for (int i = 1; i < expressionParts.Length; i++)
        {
            Console.WriteLine($"- -{expressionParts[i]}");
        }

        Console.WriteLine($"- {lhsVariable}={lhsVariable}-({rhsExpression})");

        string[] subParts = rhsExpression.Split(new char[] { '+', '-' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (string part in subParts)
        {
            Console.WriteLine($"- {lhsVariable}={lhsVariable}-({part})");
        }

        string[] innerParts = rhsExpression.Split(new char[] { '+', '-' });
        foreach (string part in innerParts)
        {
            if (part.Length == 1 && Char.IsLetter(part[0]))
            {
                Console.WriteLine($"- {lhsVariable}={lhsVariable}-({part}+B)");
            }
        }
    }
}
