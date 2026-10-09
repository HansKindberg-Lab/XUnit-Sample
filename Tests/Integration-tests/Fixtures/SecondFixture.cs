using IntegrationTests.Helpers;

namespace IntegrationTests.Fixtures;

public class SecondFixture : IDisposable
{
	#region Properties

	public string Value { get; } = $"Second-fixture-{RandomHashGenerator.Generate()}";

	#endregion

	#region Methods

	public void Dispose()
	{
		GC.SuppressFinalize(this);
	}

	#endregion
}