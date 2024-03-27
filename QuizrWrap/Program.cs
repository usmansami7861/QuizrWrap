using Dapper;
using Microsoft.Data.Sqlite;
using QuizrWrap;

namespace ASPNETConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Data Source=database.db;";
            try
            {
                using var connection = new SqliteConnection(connectionString);
                connection.Open();

                // Create tables if not exist
                connection.Execute(@"CREATE TABLE IF NOT EXISTS Users (
                                    Username TEXT PRIMARY KEY,
                                    FirstName TEXT,
                                    LastName TEXT,
                                    ThreeDigitNumber INTEGER,
                                    Wins INTEGER,
                                    Losses INTEGER)");

                connection.Execute(@"CREATE TABLE IF NOT EXISTS Questions (
                                    QuestionText TEXT PRIMARY KEY,
                                    OptionA TEXT,
                                    OptionB TEXT,
                                    OptionC TEXT,
                                    OptionD TEXT,
                                    CorrectAnswer TEXT,
                                    Image BLOB,
                                    AnsweredBy TEXT)");

                connection.Execute(@"CREATE TABLE IF NOT EXISTS Networks (
                                    Code TEXT PRIMARY KEY,
                                    NetworkName TEXT)");

                // Insert data
                InsertUsersContent(connection);
                InsertContentTextBased(connection);
                InsertNetworks(connection);

                // Retrieve users by wins in descending order
                var usersByWins = connection.Query<User>("SELECT * FROM Users ORDER BY Wins DESC");
                foreach (var user in usersByWins)
                {
                    Console.WriteLine($"Username: {user.Username}, Wins: {user.Wins}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }


        // Helper methods to insert data
        static void InsertUsersContent(SqliteConnection connection)
        {
            //10 rows of data Network Names Data here it will generated on Runtime
            var users = new List<User>
            {
              new User { Username = "user1", FirstName = "John", LastName = "Doe", ThreeDigitNumber = 123, Wins = 5, Losses = 2 },
              new User { Username = "user2", FirstName = "Jane", LastName = "Smith", ThreeDigitNumber = 456, Wins = 3, Losses = 1 },
              new User { Username = "user3", FirstName = "Alice", LastName = "Johnson", ThreeDigitNumber = 789, Wins = 7, Losses = 3 },
              new User { Username = "user4", FirstName = "Bob", LastName = "Williams", ThreeDigitNumber = 246, Wins = 9, Losses = 5 },
              new User { Username = "user5", FirstName = "Emily", LastName = "Brown", ThreeDigitNumber = 135, Wins = 2, Losses = 4 },
              new User { Username = "user6", FirstName = "Michael", LastName = "Taylor", ThreeDigitNumber = 579, Wins = 6, Losses = 2 },
              new User { Username = "user7", FirstName = "Sarah", LastName = "Miller", ThreeDigitNumber = 369, Wins = 4, Losses = 3 },
              new User { Username = "user8", FirstName = "David", LastName = "Anderson", ThreeDigitNumber = 852, Wins = 8, Losses = 6 },
              new User { Username = "user9", FirstName = "Emma", LastName = "Martinez", ThreeDigitNumber = 741, Wins = 1, Losses = 1 },
              new User { Username = "user10", FirstName = "Christopher", LastName = "Garcia", ThreeDigitNumber = 963, Wins = 10, Losses = 4 }
            };
            foreach (var user in users)
            {
                connection.Execute("INSERT OR IGNORE INTO Users (Username, FirstName, LastName, ThreeDigitNumber, Wins, Losses) VALUES (@Username, @FirstName, @LastName, @ThreeDigitNumber, @Wins, @Losses)", user);
            }
        }

        static void InsertContentTextBased(SqliteConnection connection)
        {
            //10 rows of data Content (text-based questions with text-based answers) this Data here it will generated on Runtime
            var questions = new List<Content>
            {
              new Content
              {
                QuestionText = "What is the capital of France?",
                OptionA = "London",
                OptionB = "Paris",
                OptionC = "Berlin",
                OptionD = "Rome",
                CorrectAnswer = "B",
                Image = ImageHelper.LoadImageAsByteArray("paris.jpg"),
                AnsweredBy = "user1"
              },
              new Content
              {
                QuestionText = "What is the largest ocean in the world?",
                OptionA = "Atlantic Ocean",
                OptionB = "Arctic Ocean",
                OptionC = "Indian Ocean",
                OptionD = "Pacific Ocean",
                CorrectAnswer = "D",
                Image = ImageHelper.LoadImageAsByteArray("pacific.jpg"),
                AnsweredBy = "user2"
              },
              new Content
              {
                QuestionText = "Which planet is known as the Red Planet?",
                OptionA = "Earth",
                OptionB = "Mars",
                OptionC = "Venus",
                OptionD = "Jupiter",
                CorrectAnswer = "B",
                Image = ImageHelper.LoadImageAsByteArray("mars.jpg"),
                AnsweredBy = "user3"
              },
              new Content
              {
                QuestionText = "What is the chemical symbol for water?",
                OptionA = "H",
                OptionB = "O",
                OptionC = "W",
                OptionD = "H2O",
                CorrectAnswer = "D",
                Image = ImageHelper.LoadImageAsByteArray("water.jpg"),
                AnsweredBy = "user4"
              },
              new Content
              {
                QuestionText = "Which country is known as the Land of the Rising Sun?",
                OptionA = "China",
                OptionB = "Japan",
                OptionC = "India",
                OptionD = "Russia",
                CorrectAnswer = "B",
                Image = ImageHelper.LoadImageAsByteArray("japan.jpg"),
                AnsweredBy = "user5"
              },
              new Content
              {
                QuestionText = "Who wrote the play 'Romeo and Juliet'?",
                OptionA = "William Shakespeare",
                OptionB = "Jane Austen",
                OptionC = "Charles Dickens",
                OptionD = "Leo Tolstoy",
                CorrectAnswer = "A",
                Image = ImageHelper.LoadImageAsByteArray("romeo_and_juliet.jpg"),
                AnsweredBy = "user6"
              },
              new Content
              {
                QuestionText = "What is the chemical symbol for gold?",
                OptionA = "Au",
                OptionB = "Ag",
                OptionC = "Fe",
                OptionD = "Pb",
                CorrectAnswer = "A",
                Image = ImageHelper.LoadImageAsByteArray("gold.jpg"),
                AnsweredBy = "user7"
              },
              new Content
              {
                QuestionText = "Which mammal can fly?",
                OptionA = "Bat",
                OptionB = "Dolphin",
                OptionC = "Elephant",
                OptionD = "Kangaroo",
                CorrectAnswer = "A",
                Image = ImageHelper.LoadImageAsByteArray("bat.jpg"),
                AnsweredBy = "user8"
              },
              new Content
              {
                QuestionText = "What is the chemical symbol for oxygen?",
                OptionA = "H",
                OptionB = "O",
                OptionC = "N",
                OptionD = "O2",
                CorrectAnswer = "B",
                Image = ImageHelper.LoadImageAsByteArray("oxygen.jpg"),
                AnsweredBy = "user9"
              },
              new Content
              {
                QuestionText = "Who painted the Mona Lisa?",
                OptionA = "Leonardo da Vinci",
                OptionB = "Vincent van Gogh",
                OptionC = "Pablo Picasso",
                OptionD = "Michelangelo",
                CorrectAnswer = "A",
                Image = ImageHelper.LoadImageAsByteArray("mona_lisa.jpg"),
                AnsweredBy = "user10"
              }
            };
            foreach (var question in questions)
            {
                connection.Execute("INSERT OR IGNORE INTO Questions (QuestionText, OptionA, OptionB, OptionC, OptionD, CorrectAnswer, Image, AnsweredBy) VALUES (@QuestionText, @OptionA, @OptionB, @OptionC, @OptionD, @CorrectAnswer, @Image, @AnsweredBy)", question);
            }
        }

        static void InsertNetworks(SqliteConnection connection)
        {
            var networks = new List<Network>
            {
               //10 rows of data Network Names Data here it will generated on Runtime
                 new Network { Code = "4F6I", NetworkName = "Library_Network_4G" },
                 new Network { Code = "7H3D", NetworkName = "Coffee_Shop_WiFi" },
                 new Network { Code = "2K9R", NetworkName = "Mall_Free_WiFi" },
                 new Network { Code = "5S8Q", NetworkName = "Park_Public_WiFi" },
                 new Network { Code = "1A2B", NetworkName = "Restaurant_WiFi" },
                 new Network { Code = "8G4F", NetworkName = "Airport_WiFi" },
                 new Network { Code = "3J7K", NetworkName = "Hotel_WiFi" },
                 new Network { Code = "6L9H", NetworkName = "School_WiFi" },
                 new Network { Code = "9M5N", NetworkName = "Hospital_WiFi" },
                 new Network { Code = "0P1Q", NetworkName = "Bus_Station_WiFi" }
            };
            foreach (var network in networks)
            {
                connection.Execute("INSERT OR IGNORE INTO Networks (Code, NetworkName) VALUES (@Code, @NetworkName)", network);
            }
        }
    }
}