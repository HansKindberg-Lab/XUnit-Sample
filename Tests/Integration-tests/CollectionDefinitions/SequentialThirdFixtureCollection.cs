using IntegrationTests.Fixtures;

namespace IntegrationTests.CollectionDefinitions;

/// <summary>
/// Use this collection to run tests sequentially within the collection, block other collections from running in parallel, and share a ThirdFixture instance across all tests in the collection.
/// </summary>
[CollectionDefinition(Name, DisableParallelization = true)]
public class SequentialThirdFixtureCollection : ICollectionFixture<ThirdFixture>
{
	#region Fields

	public const string Name = "Sequential third-fixture collection";

	#endregion
}