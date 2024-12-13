using System.Collections.Generic;
using Xunit;
using TheatricalPlayersRefactoringKata.Models;
using TheatricalPlayersRefactoringKata.Enum;
using System.IO;
using ApprovalTests;
using System;

namespace TheatricalPlayersRefactoringKata.Tests
{
    public class TextFormatterTests
    {
        [Fact]
        public void Format_ReturnsCorrectStatement()
        {
            // Arrange
            var formatter = new TextFormatter();

            // Mock plays
            var plays = new Dictionary<string, Play>
    {
        { "hamlet", new Play("Hamlet", 1500, PlayType.Tragedy) },
        { "as-like", new Play("As You Like It", 2000, PlayType.Comedy) },
        { "othello", new Play("Othello", 1600, PlayType.Tragedy) }
    };

            // Mock invoice
            var performances = new List<Performance>
    {
        new Performance("hamlet", 55),
        new Performance("as-like", 35),
        new Performance("othello", 40)
    };

            var invoice = new Invoice("BigCo", performances);

            // Act
            var result = formatter.Format(invoice, plays);

            // Define the path where you want to save the output
            var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Statements");
            var filePath = Path.Combine(directoryPath, "statement.txt");


            // Ensure the directory exists
            if (!Directory.Exists(directoryPath))
            {
                Console.WriteLine("Directory does not exist. Creating directory...");
                Directory.CreateDirectory(directoryPath);
            }
            else
            {
                Console.WriteLine("Directory already exists.");
            }

            // Save the result to a file
            try
            {
                Console.WriteLine("Writing to file...");
                File.WriteAllText(filePath, result);
                Console.WriteLine("File written successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing file: {ex.Message}");
            }

            // Assert 
            var expectedOutput =
    @"Statement for BigCo
  Hamlet: $400.00 (55 seats)
  As You Like It: $480.00 (35 seats)
  Othello: $260.00 (40 seats)
Amount owed is $1,140.00
You earned 47 credits
";

            Assert.Equal(expectedOutput, result);
        }
    }
}
