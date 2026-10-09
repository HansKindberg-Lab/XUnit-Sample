using IntegrationTests.Helpers;

namespace IntegrationTests.Samples;

public class LongRunningTest : IDisposable
{
	#region Fields

	private static readonly TimeSpan _delay = TimeSpan.FromSeconds(10);

	#endregion

	#region Methods

	public void Dispose()
	{
		GC.SuppressFinalize(this);
	}

	[Fact(Explicit = Global.ExplicitEnabled)]
	public async Task FirstTest()
	{
		await Task.Delay(_delay, TestContext.Current.CancellationToken);

		Assert.Fail(RandomHashGenerator.Generate());
	}

	[Fact(Explicit = Global.ExplicitEnabled)]
	public async Task SecondTest()
	{
		await Task.Delay(_delay, TestContext.Current.CancellationToken);

		Assert.Fail(RandomHashGenerator.Generate());
	}

	[Fact(Explicit = Global.ExplicitEnabled)]
	public async Task ThirdTest()
	{
		await Task.Delay(_delay, TestContext.Current.CancellationToken);

		Assert.Fail(RandomHashGenerator.Generate());
	}

	#endregion
}