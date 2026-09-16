// ConsoleUI.cs
// This class controls the appearance of the chatbot console.

using System;
using System.Threading;

namespace CybersecurityAwarenessBot
{
    public static class ConsoleUI
    {
        // Displays the cybersecurity ASCII logo.
        public static void DisplayLogo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("======================================================");
            Console.WriteLine("          CYBERSECURITY AWARENESS BOT");
            Console.WriteLine("======================================================");

            Console.WriteLine();
            Console.WriteLine("             _______________________");
            Console.WriteLine("            |                       |");
            Console.WriteLine("            |       CYBER           |");
            Console.WriteLine("            |      SECURITY         |");
            Console.WriteLine("            |         []            |");
            Console.WriteLine("            |       /____\\          |");
            Console.WriteLine("            |_______________________|");
            Console.WriteLine();

            Console.ResetColor();
        }

        // Displays the main welcome message.
        public static void DisplayWelcomeMessage()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine(" Welcome to the Cybersecurity Awareness Assistant!");
            Console.WriteLine("------------------------------------------------------");

            Console.ResetColor();

            Console.WriteLine("I can give you simple tips to help you stay safer online.");
            Console.WriteLine();
        }

        // Displays a section heading.
        public static void DisplaySection(string title)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.WriteLine();
            Console.WriteLine("======================================================");
            Console.WriteLine($"                  {title}");
            Console.WriteLine("======================================================");

            Console.ResetColor();
        }

        // Displays the goodbye message.
        public static void DisplayGoodbye(string name)
        {
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("======================================================");
            Console.WriteLine($"Thank you for chatting with me, {name}!");
            Console.WriteLine("Remember: Think before you click.");
            Console.WriteLine("======================================================");

            Console.ResetColor();
        }

        // Optional typing effect.
        // This makes the application feel more conversational.
        public static void TypingEffect(string text)
        {
            foreach (char character in text)
            {
                Console.Write(character);

                // Small delay between characters.
                Thread.Sleep(20);
            }

            Console.WriteLine();
        }
    }
}
