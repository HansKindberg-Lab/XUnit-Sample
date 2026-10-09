using IntegrationTests.Fixtures;

namespace IntegrationTests.CollectionDefinitions;

/// <summary>
/// Use this collection to run tests in parallel with other collections while sharing a ThirdFixture instance across all tests in the collection.
/// </summary>
[CollectionDefinition(Name)]
public class ParallelThirdFixtureCollection : ICollectionFixture<ThirdFixture>
{
	#region Fields

	public const string Name = "Parallel third-fixture collection";

	#endregion
}