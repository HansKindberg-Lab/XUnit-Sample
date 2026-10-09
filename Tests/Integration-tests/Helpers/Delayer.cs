namespace IntegrationTests.Helpers;

public static class Delayer
{
	#region Properties

	public static TimeSpan Delay { get; } = TimeSpan.FromSeconds(1);

	#endregion
}