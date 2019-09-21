namespace MyReadOnly.UnitTests.UseCasesTests.Withdraw
{
    using System.Linq;
    using System.Threading.Tasks;
    using MyReadOnly.Application.Boundaries.Withdraw;
    using MyReadOnly.Application.UseCases;
    using MyReadOnly.Domain.ValueObjects;
    using MyReadOnly.UnitTests.TestFixtures;
    using Xunit;

    public sealed class WithdrawlTests : IClassFixture<StandardFixture>
    {
        private readonly StandardFixture _fixture;
        public WithdrawlTests(StandardFixture fixture)
        {
            _fixture = fixture;
        }

        [Theory]
        [ClassData(typeof(PositiveDataSetup))]
        public async Task Withdraw_Valid_Amount(
            decimal amount,
            decimal expectedBalance)
        {
            var sut = new Withdraw(
                _fixture.EntityFactory,
                _fixture.Presenter,
                _fixture.AccountRepository,
                _fixture.UnitOfWork
            );

            await sut.Execute(new WithdrawInput(
                _fixture.Context.DefaultAccountId,
                new PositiveMoney(amount)));

            var actual = _fixture.Presenter.Withdrawals.Last();
            Assert.Equal(expectedBalance, actual.UpdatedBalance);
        }
    }
}