// CybersecurityResponses.cs
// This class contains the chatbot's basic cybersecurity responses.

using System;

namespace CybersecurityAwarenessBot
{
    public static class CybersecurityResponses
    {
        // This method checks the user's input and returns an appropriate response.
        public static string GetResponse(string input, string userName)
        {
            // Convert the input to lowercase.
            // This makes the chatbot less sensitive to capital letters.
            string message = input.Trim().ToLower();

            // Check if the user wants to exit.
            if (message == "exit" || message == "quit")
            {
                return $"Goodbye, {userName}! Stay safe online.";
            }

            // Response for "how are you?"
            if (message.Contains("how are you"))
            {
                return $"I am doing well, {userName}! Thank you for asking. I am ready to help you stay safe online.";
            }

            // Response for asking the purpose of the chatbot.
            if (message.Contains("purpose") ||
                message.Contains("what do you do") ||
                message.Contains("why are you here"))
            {
                return "My purpose is to help people learn about cybersecurity and safer online behaviour.";
            }

            // Response for asking what the chatbot can discuss.
            if (message.Contains("what can i ask") ||
                message.Contains("what can i learn") ||
                message.Contains("help"))
            {
                return "You can ask me about password safety, phishing, safe browsing, suspicious links and general cybersecurity awareness.";
            }

            // Password safety response.
            if (message.Contains("password") ||
                message.Contains("password safety"))
            {
                return "Use strong and unique passwords for your accounts. Avoid using personal information such as your name or birthday. Multi-factor authentication can also add extra protection.";
            }

            // Phishing response.
            if (message.Contains("phishing") ||
                message.Contains("phishing email"))
            {
                return "Phishing messages try to trick you into giving away information. Be careful with unexpected links, attachments and requests for passwords or banking information.";
            }

            // Safe browsing response.
            if (message.Contains("safe browsing") ||
                message.Contains("browse") ||
                message.Contains("internet safety"))
            {
                return "For safer browsing, check website addresses carefully, use trusted websites, keep your browser updated and avoid downloading files from suspicious sources.";
            }

            // Suspicious link response.
            if (message.Contains("link") ||
                message.Contains("suspicious"))
            {
                return "Do not click suspicious links immediately. Check the sender and website address first. If the message seems unusual, go directly to the official website instead.";
            }

            // Thank-you response.
            if (message.Contains("thank"))
            {
                return $"You're welcome, {userName}! Remember to think before clicking.";
            }

            // Default response for unsupported questions.
            return "I didn't quite understand that. Could you rephrase it? You can ask me about passwords, phishing or safe browsing.";
        }
    }
}
