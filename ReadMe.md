# XUnit-Sample

**Note:** All the tests in this solution fails. But look in the Test Explorer how they run, parallel/sequential.

If we set this somewhere:

	[assembly: CollectionBehavior(DisableTestParallelization = true)]

all collections will run sequentially, which means all tests will run one after another with no parallelization across collections. **This assembly-level setting overrides any individual collection definitions** — you cannot use a collection definition to enable parallelization if this is set to `true`.

The default CollectionBehavior is:

	[assembly: CollectionBehavior(DisableTestParallelization = false)]

So if you don't add that assembly attribute, the default is false and collections run in parallel with each other by default. Individual collection definitions can then control whether specific collections block parallelization with `DisableParallelization = true`.

Note: Tests within a collection always run sequentially with each other, regardless of these settings. The `DisableTestParallelization` and `DisableParallelization` settings control whether collections can run in parallel with each other.

So if we have three different fixtures:

- FirstFixture
- SecondFixture
- ThirdFixture

and we have the default behavior, run in parallel, we need 7 different collection-definitions to be able to cover all scenarios. See the summary in each of the collection-definitions to see the explanation for it.

- [ParallelFirstFixtureCollection, ICollectionFixture<FirstFixture>](Tests/Integration-tests/CollectionDefinitions/ParallelFirstFixtureCollection.cs)
- [ParallelSecondFixtureCollection, ICollectionFixture<SecondFixture>](Tests/Integration-tests/CollectionDefinitions/ParallelSecondFixtureCollection.cs)
- [ParallelThirdFixtureCollection, ICollectionFixture<ThirdFixture>](Tests/Integration-tests/CollectionDefinitions/ParallelThirdFixtureCollection.cs)
- [SequentialFirstFixtureCollection, ICollectionFixture<FirstFixture>](Tests/Integration-tests/CollectionDefinitions/SequentialFirstFixtureCollection.cs)
- [SequentialSecondFixtureCollection, ICollectionFixture<SecondFixture>](Tests/Integration-tests/CollectionDefinitions/SequentialSecondFixtureCollection.cs)
- [SequentialThirdFixtureCollection, ICollectionFixture<ThirdFixture>](Tests/Integration-tests/CollectionDefinitions/SequentialThirdFixtureCollection.cs)
- [SequentialCollection](Tests/Integration-tests/CollectionDefinitions/SequentialCollection.cs) - that we can use for test-classes implementing IClassFixture<T> or for test-classes instantiating the fixture inside itself (private readonly Fixture _fixture = new Fixture()).

We also have a global AssemblyFixture:

- [assembly: AssemblyFixture(typeof(FirstFixture))](Tests/Integration-tests/Global.cs#3)

So if we have a test class like this:

	public class MyTest(FirstFixture fixture)
	{
		private readonly FirstFixture _fixture = fixture ?? throw new ArgumentNullException(nameof(fixture));

		[Fact]
		public async Task FirstTest()
		{
			// Here we can use this._fixture.
		}
	}

We will get a single FirstFixture instance.

## 1 Explicit tests

We have some long running tests with the `[Fact(Explicit = Global.ExplicitEnabled)]` attribute, that we dont want to run all the time. So we have an explicit flag in the Global.cs file, that we can set to true or false. If it is set to true, the long running tests will be skipped. But you can run them explicitly by running the specific test.

If you are using ReSharper with Visual Studio (as I do) you have to (at the moment) right-click on the method name and select "Run Tests" to be able to run the explicit test. That is, you have to run the test the "non ReSharper way". That will probably be fixed in ReSharper:

- [Cannot Run Explicit Test in Rider / Resharper](https://youtrack.jetbrains.com/issue/RIDER-125223/Cannot-Run-Explicit-Test-in-Rider-Resharper)
- [xUnit v3 Explicit tests are skipped when run directly from editor gutter](https://youtrack.jetbrains.com/projects/RIDER/issues/RIDER-143385/xUnit-v3-Explicit-tests-are-skipped-when-run-directly-from-editor-gutter)
- [Rider 2026.3 EAP 5 release notes](https://youtrack.jetbrains.com/articles/DOTNET-A-415/Rider-2026.3-EAP-5-release-notes) - Search for "125223" or "Cannot Run Explicit Test in Rider / Resharper" on that page.

### 1.1 Build agents

	dotnet test -- --explicit off
	dotnet test -- --explicit on
	dotnet test -- --explicit only

#### 1.1.1 VSTest

The above does not work with VSTest. With VSTest:

	dotnet test -- xUnit.Explicit=off
	dotnet test -- xUnit.Explicit=on
	dotnet test -- xUnit.Explicit=only

Example:

	- task: DotNetCoreCLI@2
	  displayName: "Test"
	  inputs:
		arguments: '--configuration $(BUILD_CONFIGURATION) --logger "console;verbosity=detailed" -- xUnit.Explicit=on'
		command: test
		projects: "$(TEST_PROJECTS)"

## 2 Links

- [About xUnit.net](https://xunit.net)
- [Sharing Context between Tests](https://xunit.net/docs/shared-context)