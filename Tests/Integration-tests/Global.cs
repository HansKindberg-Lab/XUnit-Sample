using IntegrationTests.Fixtures;

[assembly: AssemblyFixture(typeof(FirstFixture))]
// If we out-comment the following line, then the tests will run in sequence no matter what collection we decorate the test-classes with.
// [assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace IntegrationTests;

public static class Global
{
	#region Fields

	public const bool ExplicitEnabled = true;
	public static readonly DirectoryInfo ProjectDirectory = new DirectoryInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory)).Parent!.Parent!.Parent!;
	public static readonly DirectoryInfo ProjectUnderTestDirectory = new(Path.Combine(ProjectDirectory.Parent!.Parent!.FullName, "Source", "Application"));
	public static readonly DirectoryInfo SolutionDirectory = new(ProjectDirectory.Parent!.Parent!.FullName);

	#endregion
}