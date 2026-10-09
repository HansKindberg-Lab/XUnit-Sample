using IntegrationTests.CollectionDefinitions;
using IntegrationTests.Fixtures;
using IntegrationTests.Helpers;

namespace IntegrationTests.Samples.ClassFixtureTests.Sequential;

[Collection(SequentialCollection.Name)]
public class ThirdFixtureTest(ThirdFixture fixture) : IClassFixture<ThirdFixture>
{
	#region Fields

	private readonly ThirdFixture _fixture = fixture ?? throw new ArgumentNullException(nameof(fixture));

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