using System;
using System.Collections.Generic;
using ApprovalTests;
using ApprovalTests.Reporters;
using TheatricalPlayersRefactoringKata.Models;
using TheatricalPlayersRefactoringKata.Enum; 
using Xunit;

namespace TheatricalPlayersRefactoringKata.Tests
{
    public class StatementPrinterTests
    {
        [Fact]
        [UseReporter(typeof(DiffReporter))]
        public void TestStatementExampleLegacy()
        {
            // Definindo as peças
            var plays = new Dictionary<string, Play>
            {
                { "hamlet", new Play("Hamlet", 4024, Enum.Type.tragedy) },
                { "as-like", new Play("As You Like It", 2670, Enum.Type.comedy) },
                { "othello", new Play("Othello", 3560, Enum.Type.tragedy) }
            };

            // Definindo a fatura com performances
            Invoice invoice = new Invoice(
                "BigCo",
                new List<Performance>
                {
                    new Performance("hamlet", 55),
                    new Performance("as-like", 35),
                    new Performance("othello", 40)
                }
            );

            // Criação do StatementPrinter
            StatementPrinter statementPrinter = new StatementPrinter();
            var result = statementPrinter.Print(invoice, plays);

            // Aprovação do resultado
            Approvals.Verify(result);
        }

        [Fact]
        [UseReporter(typeof(DiffReporter))]
        public void TestTextStatementExample()
        {
            // Definindo as peças com todos os tipos
            var plays = new Dictionary<string, Play>
            {
                { "hamlet", new Play("Hamlet", 4024, Enum.Type.tragedy) },
                { "as-like", new Play("As You Like It", 2670, Enum.Type.comedy) },
                { "othello", new Play("Othello", 3560, Enum.Type.tragedy) },
                { "henry-v", new Play("Henry V", 3227, Enum.Type.historic) },
                { "john", new Play("King John", 2648, Enum.Type.historic) },
                { "richard-iii", new Play("Richard III", 3718, Enum.Type.historic) }
            };

            // Definindo a fatura com performances
            Invoice invoice = new Invoice(
                "BigCo",
                new List<Performance>
                {
                    new Performance("hamlet", 55),
                    new Performance("as-like", 35),
                    new Performance("othello", 40),
                    new Performance("henry-v", 20),
                    new Performance("john", 39),
                    new Performance("henry-v", 20)
                }
            );

            // Criação do StatementPrinter
            StatementPrinter statementPrinter = new StatementPrinter();
            var result = statementPrinter.Print(invoice, plays);

            // Aprovação do resultado
            Approvals.Verify(result);
        }
    }
}
