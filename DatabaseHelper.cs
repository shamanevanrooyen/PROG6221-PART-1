using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace CybersecurityAwarenessBot
{
    public class DatabaseHelper
    {
        private string connectionString =
            "server=localhost;database=cybersecurity_bot;user=root;password=Kelebogile@18;";

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        public bool TestConnection()
        {
            try
            {
                using (MySqlConnection connection = GetConnection())
                {
                    connection.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(
                    "Database connection failed: " + ex.Message);
                return false;
            }
        }
            public void TestDatabase()
        {
            try
            {
                using (MySqlConnection connection = GetConnection())
                {
                    connection.Open();
                    MessageBox.Show("Database connected successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    }
