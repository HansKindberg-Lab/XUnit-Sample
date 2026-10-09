namespace IntegrationTests.CollectionDefinitions;

/// <summary>
/// Use this collection to run tests sequentially within the collection and block other collections from running in parallel with it.
/// </summary>
[CollectionDefinition(Name, DisableParallelization = true)]
public class SequentialCollection
{
	#region Fields

	public const string Name = "Sequential collection";

	#endregion
}