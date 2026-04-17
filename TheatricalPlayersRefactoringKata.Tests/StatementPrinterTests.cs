using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheatricalPlayersRefactoringKata.Models;
using VerifyXunit;
using Xunit;

namespace TheatricalPlayersRefactoringKata.Tests
{
    public class StatementPrinterTests
    {
        [Fact]
        public Task test_statement_example()
        {
            var plays = new Dictionary<string, Play>
                {
                    { "hamlet", new Play("Hamlet", PlayType.Tragedy) },
                    { "as-like", new Play("As You Like It", PlayType.Comedy) },
                    { "othello", new Play("Othello", PlayType.Tragedy) }
                };

            Invoice invoice = new("BigCo", new List<Performance>
                {
                    new("hamlet", 55),
                    new("as-like", 35),
                    new("othello", 40)
                });

            StatementPrinter statementPrinter = new();
            var result = statementPrinter.Print(invoice, plays);

            return Verifier.Verify(result);
        }

        [Fact]
        public void test_statement_with_new_play_types()
        {
            var plays = new Dictionary<string, Play>
                {
                    { "henry-v", new Play("Henry V", (PlayType)999) },
                    { "as-like", new Play("As You Like It", (PlayType)998) }
                };

            Invoice invoice = new("BigCoII", new List<Performance>
                {
                    new("henry-v", 53),
                    new("as-like", 55)
                });

            StatementPrinter statementPrinter = new();

            var exception = Assert.Throws<ArgumentException>(() => statementPrinter.Print(invoice, plays));
            Assert.Equal("Unknown play type: 999", exception.Message);
        }
    }
}
