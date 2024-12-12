using System;
using System.Collections.Generic;
using System.Linq;

namespace TheatricalPlayersRefactoringKata.Models;
public class Invoice
{
    public string Customer { get; set; }
    public IReadOnlyList<Performance> Performances { get; }

    public Invoice(string customer, List<Performance> performances)
    {
        Customer = customer ?? throw new ArgumentNullException(nameof(customer));
        Performances = performances ?? throw new ArgumentNullException(nameof(performances));
    }
   
    public int TotalAudience() => Performances.Sum(p => p.Audience);
}
