using IntegrationTests.Fixtures;
using IntegrationTests.Helpers;

namespace IntegrationTests.Samples;

public class DefaultFixtureTest(FirstFixture fixture) : IDisposable
{
	#region Fields

	private readonly FirstFixture _fixture = fixture ?? throw new ArgumentNullException(nameof(fixture));

	#endregion

	#region Methods

	public void Dispose()
	{
		this._fixture.Dispose();
		GC.SuppressFinalize(this);
	}

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