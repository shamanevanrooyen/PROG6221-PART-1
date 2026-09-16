# Cybersecurity Awareness Bot

## Programming 2A - PROG6221

This project is a command-line Cybersecurity Awareness Chatbot developed in C#.

The purpose of the chatbot is to provide users with basic cybersecurity awareness and simple safety tips.

## Features

The chatbot includes:

- Voice greeting when the application starts
- ASCII cybersecurity logo
- Personalised greeting using the user's name
- Basic conversation
- Password safety information
- Phishing information
- Safe browsing information
- Suspicious link information
- Input validation
- Default response for unsupported questions
- Coloured console interface
- Section headings and borders
- Exit command
- Object-oriented code structure
- Automatic property for the User class
- GitHub version control
- GitHub Actions Continuous Integration

## Project Structure

The project contains the following main files:

- `Program.cs` - Starts the application.
- `Chatbot.cs` - Controls the main chatbot flow.
- `User.cs` - Stores user information.
- `ConsoleUI.cs` - Controls the console design.
- `VoiceGreeting.cs` - Plays the WAV voice greeting.
- `CybersecurityResponses.cs` - Contains cybersecurity responses.
- `ascii-art.txt` - Contains the ASCII art.
- `welcome.wav` - Recorded voice greeting.
- `.github/workflows/dotnet.yml` - GitHub Actions CI workflow.

## How to Run

1. Open the project in Visual Studio.
2. Make sure `welcome.wav` is included in the project.
3. Build the project.
4. Run the application.
5. Enter your name.
6. Ask cybersecurity-related questions.
7. Type `exit` to close the chatbot.

## Example Questions

The user can ask:

- How are you?
- What is your purpose?
- What can I ask you about?
- How do I protect my password?
- What is phishing?
- How can I browse safely?
- What should I do with a suspicious link?

## Voice Greeting

The application uses a recorded WAV file named:

`welcome.wav`

The file is played when the application starts.

## Continuous Integration

GitHub Actions is used to automatically build the project when changes are pushed to GitHub.

A screenshot of the successful GitHub Actions run should be added below before final submission.

## Presentation

An unlisted YouTube video demonstrating the application and explaining the code structure will be added here before submission.