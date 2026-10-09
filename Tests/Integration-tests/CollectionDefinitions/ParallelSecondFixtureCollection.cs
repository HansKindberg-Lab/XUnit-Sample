using IntegrationTests.Fixtures;

namespace IntegrationTests.CollectionDefinitions;

/// <summary>
/// Use this collection to run tests in parallel with other collections while sharing a SecondFixture instance across all tests in the collection.
/// </summary>
[CollectionDefinition(Name)]
public class ParallelSecondFixtureCollection : ICollectionFixture<SecondFixture>
{
	#region Fields

	public const string Name = "Parallel second-fixture collection";

	#endregion
}