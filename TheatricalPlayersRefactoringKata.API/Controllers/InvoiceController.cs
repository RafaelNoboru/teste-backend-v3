using Microsoft.AspNetCore.Mvc;
using TheatricalPlayersRefactoringKata.Enum;
using TheatricalPlayersRefactoringKata.Interface;
using TheatricalPlayersRefactoringKata.Models;

[ApiController]
[Route("api/[controller]")]
public class InvoiceController : ControllerBase
{
    private readonly IStatementFormatter _statementFormatter;
    private readonly Dictionary<string, Play> _plays;

    public InvoiceController(IStatementFormatter statementFormatter)
    {
        _statementFormatter = statementFormatter;
        _plays = new Dictionary<string, Play>
        {
            { "hamlet", new Play("Hamlet", 1500, PlayType.Tragedy) },
            { "as-like", new Play("As You Like It", 2000, PlayType.Comedy) },
            { "othello", new Play("Othello", 1600, PlayType.Tragedy) }
        };
    }

    [HttpPost]
    public IActionResult GenerateInvoice([FromBody] Invoice invoice)
    {
       
        var result = _statementFormatter.Format(invoice, _plays);

        var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Statements");
        var filePath = Path.Combine(directoryPath, "statement.txt");

        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        try
        {
          
            using (var stream = new FileStream(filePath, FileMode.Create))
            using (var writer = new StreamWriter(stream))
            {
                writer.Write(result);  
            }

            return Ok($"Invoice generated at {filePath}");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error writing file: {ex.Message}");
        }
    }
}
