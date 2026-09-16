// User.cs
// This class stores information about the chatbot user.

namespace CybersecurityAwarenessBot
{
    public class User
    {
        // Automatic property used to store the user's name.
        public string Name { get; set; }

        // Constructor used to create a User object.
        public User(string name)
        {
            Name = name;
        }
    }
}
