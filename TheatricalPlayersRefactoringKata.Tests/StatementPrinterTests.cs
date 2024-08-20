using ApprovalTests.Reporters;
using ApprovalTests;
using System.Collections.Generic;
using TheatricalPlayersRefactoringKata;
using Xunit;

public class StatementPrinterTests
{
    [Fact]
    [UseReporter(typeof(DiffReporter))]
    public void TestStatementExampleLegacy()
    {
        var plays = new Dictionary<string, Play>
        {
            { "hamlet", new Play("Hamlet", 4024, PlayType.Tragedy) },
            { "as-like", new Play("As You Like It", 2670, PlayType.Comedy) },
            { "othello", new Play("Othello", 3560, PlayType.Tragedy) }
        };

        var invoice = new Invoice(
            "BigCo",
            new List<Performance>
            {
                new Performance("hamlet", 55, plays["hamlet"]),
                new Performance("as-like", 35, plays["as-like"]),
                new Performance("othello", 40, plays["othello"])
            }
        );

        var statementPrinter = new StatementPrinter();
        var result = statementPrinter.Print(invoice);

        Approvals.Verify(result);
    }

    [Fact]
    [UseReporter(typeof(DiffReporter))]
    public void TestTextStatementExample()
    {
        var plays = new Dictionary<string, Play>
        {
            { "hamlet", new Play("Hamlet", 4024, PlayType.Tragedy) },
            { "as-like", new Play("As You Like It", 2670, PlayType.Comedy) },
            { "othello", new Play("Othello", 3560, PlayType.Tragedy) },
            { "henry-v", new Play("Henry V", 3227, PlayType.Historical) },
            { "john", new Play("King John", 2648, PlayType.Historical) },
            { "richard-iii", new Play("Richard III", 3718, PlayType.Historical) }
        };

        var invoice = new Invoice(
            "BigCo",
            new List<Performance>
            {
                new Performance("hamlet", 55, plays["hamlet"]),
                new Performance("as-like", 35, plays["as-like"]),
                new Performance("othello", 40, plays["othello"]),
                new Performance("henry-v", 20, plays["henry-v"]),
                new Performance("john", 39, plays["john"]),
                new Performance("richard-iii", 30, plays["richard-iii"])
            }
        );

        var statementPrinter = new StatementPrinter();
        var result = statementPrinter.Print(invoice);

        Approvals.Verify(result);
    }
}
