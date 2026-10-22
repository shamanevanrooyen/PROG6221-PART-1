using System;

namespace CybersecurityAwarenessBot
{
    public static class CybersecurityResponses
    {
        private static readonly string[] Tips =
        {
            "Use a strong, unique password for every important account.",
            "Never share your passwords or one-time PINs.",
            "Enable multi-factor authentication whenever possible.",
            "Check the sender before opening unexpected attachments.",
            "Avoid clicking suspicious links.",
            "Keep your devices and applications updated.",
            "Use trusted websites when banking or shopping online.",
            "Avoid sharing personal information with strangers.",
            "Use secure Wi-Fi when accessing sensitive accounts.",
            "Log out when using a shared computer."
        };

        // Remember information during the current session.
        private static string lastTopic = "";
        private static string rememberedName = "";
        private static string favouriteTopic = "";

        public static string GetRandomTip()
        {
            return Tips[Random.Shared.Next(Tips.Length)];
        }

        public static string GetResponse(string input, string userName)
        {
            string message = input.Trim();
            string lowerMessage = message.ToLowerInvariant();

            // Remember the user's name.
            if (lowerMessage.StartsWith("my name is "))
            {
                string name = message.Substring("my name is ".Length).Trim();

                if (!string.IsNullOrWhiteSpace(name))
                {
                    rememberedName = name;
                    return $"Nice to meet you, {rememberedName}! I'll remember your name during this conversation.";
                }
            }

            // Recall the user's name.
            if (lowerMessage.Contains("what is my name") ||
                lowerMessage.Contains("what's my name") ||
                lowerMessage.Contains("do you remember my name"))
            {
                return string.IsNullOrEmpty(rememberedName)
                    ? "You haven't told me your name yet. Type 'My name is ...' so I can remember it."
                    : $"Your name is {rememberedName}.";
            }

            // Remember the user's favourite topic.
            string favouritePrefix = "my favourite topic is ";

            if (lowerMessage.StartsWith(favouritePrefix))
            {
                string topic = message.Substring(favouritePrefix.Length).Trim();

                if (!string.IsNullOrWhiteSpace(topic))
                {
                    favouriteTopic = topic;
                    lastTopic = topic.ToLowerInvariant();

                    return $"I'll remember that your favourite cybersecurity topic is {favouriteTopic}.";
                }
            }

            // Also accept the American spelling.
            string favoritePrefix = "my favorite topic is ";

            if (lowerMessage.StartsWith(favoritePrefix))
            {
                string topic = message.Substring(favoritePrefix.Length).Trim();

                if (!string.IsNullOrWhiteSpace(topic))
                {
                    favouriteTopic = topic;
                    lastTopic = topic.ToLowerInvariant();

                    return $"I'll remember that your favourite cybersecurity topic is {favouriteTopic}.";
                }
            }

            // Recall the favourite topic.
            if (lowerMessage.Contains("what is my favourite topic") ||
                lowerMessage.Contains("what's my favourite topic") ||
                lowerMessage.Contains("what is my favorite topic") ||
                lowerMessage.Contains("what's my favorite topic"))
            {
                return string.IsNullOrEmpty(favouriteTopic)
                    ? "You haven't told me your favourite topic yet. Try 'My favourite topic is phishing'."
                    : $"Your favourite cybersecurity topic is {favouriteTopic}.";
            }

            // Sentiment detection: recognise worry, curiosity and frustration.
            if (lowerMessage.Contains("worried") ||
                lowerMessage.Contains("scared") ||
                lowerMessage.Contains("afraid") ||
                lowerMessage.Contains("anxious") ||
                lowerMessage.Contains("nervous") ||
                lowerMessage.Contains("someone hacked") ||
                lowerMessage.Contains("been hacked"))
            {
                return "It's understandable to feel worried about online safety. " +
       "Take a breath. Here is a cybersecurity tip: " +
       GetRandomTip() +
       " If you think your account was hacked, change its password " +
       "using the official website and enable multi-factor authentication.";
            }

            if (lowerMessage.Contains("frustrated") ||
                lowerMessage.Contains("annoyed") ||
                lowerMessage.Contains("confused") ||
                lowerMessage.Contains("don't understand") ||
                lowerMessage.Contains("do not understand") ||
                lowerMessage.Contains("this is difficult") ||
                lowerMessage.Contains("this is hard"))
            {
                return "I understand that this can feel frustrating. Let's take it one step at a time. I can explain the cybersecurity topic in simpler words or give you an example. Which part is confusing?";
            }

            if (lowerMessage.Contains("curious") ||
                lowerMessage.Contains("interested") ||
                lowerMessage.Contains("want to learn") ||
                lowerMessage.Contains("tell me about") ||
                lowerMessage.Contains("how does") ||
                lowerMessage.Contains("why does"))
            {
                return "It's great that you're curious about cybersecurity! I can explain the topic step by step. You can ask about passwords, phishing, scams, privacy or safe browsing.";
            }

            // Exit.
            if (lowerMessage == "exit" || lowerMessage == "quit")
            {
                return $"Goodbye, {userName}! Stay safe online.";
            }

            // Follow-up questions use the previous topic.
            if (lowerMessage.Contains("tell me more") ||
                lowerMessage.Contains("explain more") ||
                lowerMessage.Contains("more information"))
            {
                switch (lastTopic)
                {
                    case "password":
                        return "Use a unique password for every account. A password manager can help you manage them, and multi-factor authentication adds extra protection.";

                    case "phishing":
                        return "Phishing can happen through emails, text messages, calls and fake websites. Check the sender and never share passwords or one-time PINs.";

                    case "browsing":
                        return "Check website addresses carefully, install updates and avoid downloads from unknown sources.";

                    case "links":
                        return "Check who sent the link and whether the address matches the official website. When unsure, visit the official website directly.";

                    case "scams":
                        return "Scammers may pretend to be banks, companies or people you trust. Be careful with urgent payment requests, unexpected prizes and requests for PINs. Verify the request using an official contact method.";

                    case "privacy":
                        return "Protect your privacy by limiting what you share online, reviewing app permissions and using privacy settings on your accounts.";

                    case "tip":
                        return "Use unique passwords, enable multi-factor authentication, install updates and check unexpected messages carefully.";

                    default:
                        return "Ask me about passwords, phishing, scams, privacy, safe browsing or suspicious links, and then ask me to tell you more.";
                }
            }

            // Random cybersecurity tips.

            if (lowerMessage == "tip" ||
                lowerMessage == "tips" ||
                lowerMessage.Contains("give me a tip") ||
                lowerMessage.Contains("another tip") ||
                lowerMessage.Contains("cybersecurity tip"))
            {
                lastTopic = "tip";
                return $"Here is a cybersecurity tip: {GetRandomTip()}";
            }

            // Purpose and help.
            if (lowerMessage.Contains("purpose") ||
                lowerMessage.Contains("what do you do") ||
                lowerMessage.Contains("why are you here"))
            {
                return "My purpose is to help people learn about cybersecurity and safer online behaviour.";
            }

            if (lowerMessage.Contains("what can i ask") ||
                lowerMessage.Contains("what can i learn") ||
                lowerMessage == "help")
            {
                return "You can ask me about passwords, phishing, scams, privacy, safe browsing, suspicious links or random cybersecurity tips. I can also respond to feelings such as worry or frustration.";
            }

            // Passwords.
            if (lowerMessage.Contains("password"))
            {
                lastTopic = "password";
                return "Use strong, unique passwords. Avoid personal information such as your name or birthday, and enable multi-factor authentication.";
            }

            // Phishing: choose a response randomly.
            if (lowerMessage.Contains("phishing"))
            {
                lastTopic = "phishing";

                int index = Random.Shared.Next(PhishingTips.Length);

                return "Phishing safety tip: " + PhishingTips[index];
            }

            // Scams.
            if (lowerMessage.Contains("scam") ||
                lowerMessage.Contains("fraud") ||
                lowerMessage.Contains("being scammed"))
            {
                lastTopic = "scams";
                return "Scams often use fake offers, urgent messages or requests for money and personal information. Do not share your PIN or one-time password. Verify suspicious requests through the organisation's official contact details.";
            }

            // Privacy.
            if (lowerMessage.Contains("privacy") ||
                lowerMessage.Contains("personal information") ||
                lowerMessage.Contains("data protection"))
            {
                lastTopic = "privacy";
                return "Protect your privacy by limiting personal details you share online, checking app permissions and using strong privacy settings. Never post passwords, PINs or sensitive information publicly.";
            }

            // Safe browsing.
            if (lowerMessage.Contains("safe browsing") ||
                lowerMessage.Contains("browse") ||
                lowerMessage.Contains("internet safety"))
            {
                lastTopic = "browsing";
                return "Check website addresses carefully, use trusted websites, keep your browser updated and avoid suspicious downloads.";
            }


            // Suspicious links.
            if (lowerMessage.Contains("link") ||
                lowerMessage.Contains("suspicious"))
            {
                lastTopic = "links";
                return "Don't click suspicious links immediately. Check the sender and website address, or visit the official website directly.";
            }

            // General conversation.
            if (lowerMessage.Contains("how are you"))
            {
                return $"I'm doing well, {userName}! I'm ready to help you stay safe online.";
            }

            if (lowerMessage.Contains("thank"))
            {
                return $"You're welcome, {userName}! Remember to think before clicking.";
            }

            return "I didn't quite understand that. Ask me about passwords, phishing, scams, privacy, safe browsing, suspicious links or cybersecurity tips.";
        }
        private static readonly string[] PhishingTips =
{
    "Check the sender's email address before replying.",
    "Avoid clicking unexpected links in emails or text messages.",
    "Never share your password or one-time PIN through a message.",
    "Be careful with messages that pressure you to act urgently.",
    "If a message claims to be from your bank, contact the bank using its official details."
};
    }
}