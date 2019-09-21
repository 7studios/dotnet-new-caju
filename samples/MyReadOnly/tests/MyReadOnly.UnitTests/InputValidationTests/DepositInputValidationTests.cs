namespace MyReadOnly.UnitTests.InputValidationTests
{
    using System;
    using MyReadOnly.Application.Boundaries.Deposit;
    using MyReadOnly.Application.Exceptions;
    using MyReadOnly.Domain.ValueObjects;
    using Xunit;

    public sealed class DepositInputValidationTests
    {
        [Fact]
        public void GivenEmptyAccountId_InputNotCreated_ThrowsInputValidationException()
        {
            var actualEx = Assert.Throws<InputValidationException>(
                () => new DepositInput(
                    Guid.Empty,
                    new PositiveMoney(10)
                ));
            Assert.Contains("accountId", actualEx.Message);
        }

        [Fact]
        public void GivenNullAmount_InputNotCreated_ThrowsInputValidationException()
        {
            var actualEx = Assert.Throws<InputValidationException>(
                () => new DepositInput(
                    Guid.NewGuid(),
                    null
                ));
            Assert.Contains("amount", actualEx.Message);
        }

        [Fact]
        public void GivenValidData_InputCreated()
        {
            var actual = new DepositInput(
                Guid.NewGuid(),
                new PositiveMoney(10)
            );
            Assert.NotNull(actual);
        }
    }
}