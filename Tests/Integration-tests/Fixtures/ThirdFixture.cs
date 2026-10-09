using IntegrationTests.Helpers;

namespace IntegrationTests.Fixtures;

public class ThirdFixture : IDisposable
{
	#region Properties

	public string Value { get; } = $"Third-fixture-{RandomHashGenerator.Generate()}";

	#endregion

	#region Methods

	public void Dispose()
	{
		GC.SuppressFinalize(this);
	}

	#endregion
}