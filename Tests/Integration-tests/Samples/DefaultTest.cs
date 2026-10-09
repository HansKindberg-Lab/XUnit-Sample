using IntegrationTests.Helpers;

namespace IntegrationTests.Samples;

public class DefaultTest : IDisposable
{
	#region Methods

	public void Dispose()
	{
		GC.SuppressFinalize(this);
	}

	[Fact]
	public async Task FirstTest()
	{
		await Task.Delay(Delayer.Delay, TestContext.Current.CancellationToken);

		Assert.Fail(RandomHashGenerator.Generate());
	}

	[Fact]
	public async Task SecondTest()
	{
		await Task.Delay(Delayer.Delay, TestContext.Current.CancellationToken);

		Assert.Fail(RandomHashGenerator.Generate());
	}

	[Fact]
	public async Task ThirdTest()
	{
		await Task.Delay(Delayer.Delay, TestContext.Current.CancellationToken);

		Assert.Fail(RandomHashGenerator.Generate());
	}

	#endregion
}