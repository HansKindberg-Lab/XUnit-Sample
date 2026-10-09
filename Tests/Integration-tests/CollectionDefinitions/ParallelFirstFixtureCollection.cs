using IntegrationTests.Fixtures;

namespace IntegrationTests.CollectionDefinitions;

/// <summary>
/// Use this collection to run tests in parallel with other collections while sharing a FirstFixture instance across all tests in the collection.
/// </summary>
[CollectionDefinition(Name)]
public class ParallelFirstFixtureCollection : ICollectionFixture<FirstFixture>
{
	#region Fields

	public const string Name = "Parallel first-fixture collection";

	#endregion
}