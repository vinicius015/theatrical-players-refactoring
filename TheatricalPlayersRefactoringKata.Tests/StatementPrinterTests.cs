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
        public Task Print_WithTypicalInvoice_ReturnsExpectedStatement()
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
        public void Print_WithUnknownPlayType_ThrowsArgumentException()
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

        [Fact]
        public Task Print_WithEmptyInvoice_ReturnsStatementWithZeroTotals()
        {
            var plays = new Dictionary<string, Play>();
            Invoice invoice = new("NoCustomer", new List<Performance>());

            StatementPrinter statementPrinter = new();
            var result = statementPrinter.Print(invoice, plays);

            return Verifier.Verify(result);
        }

        [Fact]
        public Task Print_WithMinimumAudience_ReturnsExpectedStatement()
        {
            var plays = new Dictionary<string, Play>
                {
                    { "hamlet", new Play("Hamlet", PlayType.Tragedy) },
                    { "as-like", new Play("As You Like It", PlayType.Comedy) }
                };

            Invoice invoice = new("SmallAudience", new List<Performance>
                {
                    new("hamlet", 1),
                    new("as-like", 1)
                });

            StatementPrinter statementPrinter = new();
            var result = statementPrinter.Print(invoice, plays);

            return Verifier.Verify(result);
        }

        [Fact]
        public Task Print_WithAudienceAtThresholds_ReturnsExpectedStatement()
        {
            var plays = new Dictionary<string, Play>
                {
                    { "hamlet", new Play("Hamlet", PlayType.Tragedy) },
                    { "as-like", new Play("As You Like It", PlayType.Comedy) }
                };

            Invoice invoice = new("Thresholds", new List<Performance>
                {
                    new("hamlet", 30), // Tragedy threshold
                    new("as-like", 20)
                });

            StatementPrinter statementPrinter = new();
            var result = statementPrinter.Print(invoice, plays);

            return Verifier.Verify(result);
        }

        [Fact]
        public Task Print_WithOnlyTragedyPlays_ReturnsExpectedStatement()
        {
            var plays = new Dictionary<string, Play>
                {
                    { "hamlet", new Play("Hamlet", PlayType.Tragedy) },
                    { "othello", new Play("Othello", PlayType.Tragedy) }
                };

            Invoice invoice = new("TragedyOnly", new List<Performance>
                {
                    new("hamlet", 40),
                    new("othello", 35)
                });

            StatementPrinter statementPrinter = new();
            var result = statementPrinter.Print(invoice, plays);

            return Verifier.Verify(result);
        }

        [Fact]
        public Task Print_WithOnlyComedyPlays_ReturnsExpectedStatement()
        {
            var plays = new Dictionary<string, Play>
                {
                    { "as-like", new Play("As You Like It", PlayType.Comedy) },
                    { "twelfth-night", new Play("Twelfth Night", PlayType.Comedy) }
                };

            Invoice invoice = new("ComedyOnly", new List<Performance>
                {
                    new("as-like", 25),
                    new("twelfth-night", 30)
                });

            StatementPrinter statementPrinter = new();
            var result = statementPrinter.Print(invoice, plays);

            return Verifier.Verify(result);
        }

        [Fact]
        public Task Print_WithLargeAudienceNumbers_ReturnsExpectedStatement()
        {
            var plays = new Dictionary<string, Play>
                {
                    { "hamlet", new Play("Hamlet", PlayType.Tragedy) },
                    { "as-like", new Play("As You Like It", PlayType.Comedy) }
                };

            Invoice invoice = new("BigAudience", new List<Performance>
                {
                    new("hamlet", 1000),
                    new("as-like", 2000)
                });

            StatementPrinter statementPrinter = new();
            var result = statementPrinter.Print(invoice, plays);

            return Verifier.Verify(result);
        }

        [Fact]
        public Task Print_WithEmptyCustomerName_ReturnsExpectedStatement()
        {
            var plays = new Dictionary<string, Play>
                {
                    { "hamlet", new Play("Hamlet", PlayType.Tragedy) }
                };

            Invoice invoice = new("", new List<Performance>
                {
                    new("hamlet", 10)
                });

            StatementPrinter statementPrinter = new();
            var result = statementPrinter.Print(invoice, plays);

            return Verifier.Verify(result);
        }
    }
}