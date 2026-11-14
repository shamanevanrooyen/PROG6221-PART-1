Cybersecurity Awareness Chatbot

Project Overview

The Cybersecurity Awareness Chatbot is a C# Windows Forms application that helps users learn about cybersecurity and safer online behaviour.

Features

* Graphical user interface with a chat history and message input.
* Cybersecurity information about passwords, phishing, scams, privacy and safe browsing.
* Random cybersecurity tips.
* Follow-up questions that provide more information about a topic.
* Memory and recall of the user’s name and favourite topic during the current session.
* Basic sentiment detection for worried, curious and frustrated users.
* ASCII art and an optional voice greeting.
* Basic input validation and error handling.
* Part 3

* MySQL database integration.
* Task Assistant for creating, viewing, completing and deleting tasks.
* Cybersecurity quiz with multiple-choice and true/false questions.
* Natural Language Processing command recognition.
* Activity log with timestamps.

Technologies Used

* C#
* .NET 8
* Windows Forms
* MySQL
* MySQL Workbench
* Visual Studio



How to Run

1. Install Visual Studio with the .NET desktop development workload.
2. Open the project solution in Visual Studio.
3. Confirm that the project targets net8.0-windows and has Windows Forms enabled.
4. Build the solution.
5. Run the application.

The ascii-art.txt and welcome.wav files should be included in the project output for the greeting features to work.

How to Use

Type a question into the message box and select Send, or press Enter.

Examples:

* How can I create a strong password?
* What is phishing?
* Tell me about scams
* How can I protect my privacy?
* Give me a cybersecurity tip
* My name is Alex
* What is my name?
* My favourite topic is phishing
* What is my favourite topic?
* I'm worried about my online account
* I'm curious about cybersecurity
* I'm frustrated because I don't understand

Memory

The chatbot remembers the user’s name and favourite topic while the application is running. This information is stored in memory and is not intended to persist after the application closes.

Error Handling

The application checks for empty messages and displays an error response if processing a message fails. The greeting can still display if the optional audio or ASCII art file is unavailable.

Project Structure

* Program.cs — starts the Windows Forms application.
* ChatbotForm.cs — creates the graphical interface and handles user input.
* CybersecurityResponses.cs — contains chatbot responses, tips, memory, follow-up logic and sentiment detection.
* Chatbot.cs — contains the earlier console chatbot implementation, if retained.
* ConsoleUI.cs — contains the earlier console interface, if retained.
* VoiceGreeting.cs — contains the earlier voice greeting implementation, if retained.
* ascii-art.txt — ASCII greeting artwork.
* welcome.wav — voice greeting audio.

Testing

Test the graphical interface, all main cybersecurity topics, random tips, follow-up questions, name and favourite-topic recall, sentiment responses, empty input and behaviour when optional greeting files are missing.

Author

Student project for PROG6221 Programming 2A.

Disclaimer

This chatbot provides general cybersecurity awareness information for learning purposes. It is not a substitute for professional cybersecurity incident response.
