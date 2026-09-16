// Chatbot.cs
// This class controls the main flow of the chatbot.

using System;

namespace CybersecurityAwarenessBot
{
    public class Chatbot
    {
        // Store the current user's information.
        private User user;

        // This method starts the chatbot.
        public void Start()
        {
            // Clear the console before starting.
            Console.Clear();

            // Play the recorded voice greeting.
            VoiceGreeting.Play();

            // Display the ASCII cybersecurity logo.
            ConsoleUI.DisplayLogo();

            // Display a welcome message.
            ConsoleUI.DisplayWelcomeMessage();

            // Ask the user for their name.
            GetUserName();

            // Start the conversation.
            RunConversation();
        }

        // This method asks the user for their name.
        private void GetUserName()
        {
            ConsoleUI.DisplaySection("USER INFORMATION");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Please enter your name: ");
            Console.ResetColor();

            string? name = Console.ReadLine();

            // Check if the user entered nothing.
            while (string.IsNullOrWhiteSpace(name))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Name cannot be empty.");
                Console.ResetColor();

                Console.Write("Please enter your name: ");
                name = Console.ReadLine();
            }

            // Create a User object using the name.
            user = new User(name.Trim());

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Welcome, {user.Name}! I am happy to help you learn about cybersecurity.");
            Console.ResetColor();
        }

        // This method keeps the chatbot running until the user exits.
        private void RunConversation()
        {
            ConsoleUI.DisplaySection("CYBERSECURITY CHAT");

            Console.WriteLine("You can ask me about:");
            Console.WriteLine("- Password safety");
            Console.WriteLine("- Phishing");
            Console.WriteLine("- Safe browsing");
            Console.WriteLine("- My purpose");
            Console.WriteLine("- How I am doing");
            Console.WriteLine();
            Console.WriteLine("Type 'exit' when you want to leave.");
            Console.WriteLine();

            bool running = true;

            while (running)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"{user.Name}: ");
                Console.ResetColor();

                string? input = Console.ReadLine();

                // Check for empty input.
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Bot: Please type something so I can help you.");
                    Console.ResetColor();

                    continue;
                }

                // Get a response from the response class.
                string response = CybersecurityResponses.GetResponse(input, user.Name);

                // Display the chatbot's response.
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Bot: {response}");
                Console.ResetColor();

                // Stop the application if the user types exit.
                if (input.Trim().ToLower() == "exit")
                {
                    running = false;
                }

                Console.WriteLine();
            }

            ConsoleUI.DisplayGoodbye(user.Name);
        }
    }
}
