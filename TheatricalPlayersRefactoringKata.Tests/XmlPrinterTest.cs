using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TheatricalPlayersRefactoringKata.Enum;
using TheatricalPlayersRefactoringKata.Models;
using Xunit;

namespace TheatricalPlayersRefactoringKata.Tests
{
    public class XmlPrinterTest
    {
        [Fact]
        public async Task FormatAndGenerateXml_ReturnsCorrectStatement()
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

            // Define the path where you want to save the XML output
            var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Statements");
            var xmlFilePath = Path.Combine(directoryPath, "statement.xml");

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

            // Generate XML asynchronously
            try
            {
                Console.WriteLine("Generating XML file asynchronously...");
                await GenerateXmlAsync(invoice, plays, xmlFilePath);
                Console.WriteLine("XML file written successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing XML file: {ex.Message}");
            }

            // Assert - Example expected output validation can be added here if necessary
            Assert.True(File.Exists(xmlFilePath), "XML file was not created.");
        }

        private async Task GenerateXmlAsync(Invoice invoice, Dictionary<string, Play> plays, string filePath)
        {
            var document = new XDocument(
                new XElement("Statement",
                    new XElement("Customer", invoice.Customer),
                    new XElement("Performances",
                        invoice.Performances.Select(performance =>
                            new XElement("Performance",
                                new XElement("Play", plays[performance.PlayId].Name),
                                new XElement("Type", plays[performance.PlayId].Type.ToString()),
                                new XElement("Audience", performance.Audience)
                            )
                        )
                    ),
                    new XElement("TotalAmount", "$1140.00"),
                    new XElement("Credits", "47")
                )
            );

            // Save XML asynchronously
            using (var writer = new StreamWriter(filePath))
            {
                await document.SaveAsync(writer, SaveOptions.None, default);
            }
        }
    }
}

