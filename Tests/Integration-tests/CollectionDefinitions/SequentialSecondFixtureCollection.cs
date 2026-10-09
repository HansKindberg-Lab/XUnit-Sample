using IntegrationTests.Fixtures;

namespace IntegrationTests.CollectionDefinitions;

/// <summary>
/// Use this collection to run tests sequentially within the collection, block other collections from running in parallel, and share a SecondFixture instance across all tests in the collection.
/// </summary>
[CollectionDefinition(Name, DisableParallelization = true)]
public class SequentialSecondFixtureCollection : ICollectionFixture<SecondFixture>
{
	#region Fields

	public const string Name = "Sequential second-fixture collection";

	#endregion
}