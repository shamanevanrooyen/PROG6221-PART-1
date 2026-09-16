// Program.cs
// This is the starting point of the Cybersecurity Awareness Chatbot.
// The Program class starts the application and calls the chatbot.

namespace CybersecurityAwarenessBot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create an object of the Chatbot class.
            Chatbot chatbot = new Chatbot();

            // Start the chatbot application.
            chatbot.Start();
        }
    }
}