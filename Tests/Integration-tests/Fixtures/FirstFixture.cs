using IntegrationTests.Helpers;

namespace IntegrationTests.Fixtures;

public class FirstFixture : IDisposable
{
	#region Properties

	public string Value { get; } = $"First-fixture-{RandomHashGenerator.Generate()}";

	#endregion

	#region Methods

	public void Dispose()
	{
		GC.SuppressFinalize(this);
	}

	#endregion
}