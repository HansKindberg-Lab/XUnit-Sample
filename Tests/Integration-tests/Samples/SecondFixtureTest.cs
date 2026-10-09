using IntegrationTests.CollectionDefinitions;
using IntegrationTests.Fixtures;
using IntegrationTests.Helpers;

namespace IntegrationTests.Samples;

[Collection(SequentialCollection.Name)]
public class SecondFixtureTest : IDisposable
{
	#region Fields

	private readonly SecondFixture _fixture = new();

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