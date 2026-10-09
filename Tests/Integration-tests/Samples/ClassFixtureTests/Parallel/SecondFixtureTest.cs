using IntegrationTests.Fixtures;
using IntegrationTests.Helpers;

namespace IntegrationTests.Samples.ClassFixtureTests.Parallel;

public class SecondFixtureTest(SecondFixture fixture) : IClassFixture<SecondFixture>
{
	#region Fields

	private readonly SecondFixture _fixture = fixture ?? throw new ArgumentNullException(nameof(fixture));

	#endregion

	#region Methods

	[Fact]
	public async Task FirstTest()
	{
		await Task.Delay(Delayer.Delay, TestContext.Current.CancellationToken);

		Assert.Fail(this._fixture.Value);
	}

	[Fact]
	public async Task SecondTest()
	{
		await Task.Delay(Delayer.Delay, TestContext.Current.CancellationToken);

		Assert.Fail(this._fixture.Value);
	}

	[Fact]
	public async Task ThirdTest()
	{
		await Task.Delay(Delayer.Delay, TestContext.Current.CancellationToken);

		Assert.Fail(this._fixture.Value);
	}

	#endregion
}