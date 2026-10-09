using System.Runtime.CompilerServices;

namespace Shared;

public class WindowsFactAttribute : FactAttribute
{
	#region Fields

	public const string SkipMessage = "This test runs only on Windows.";

	#endregion

	#region Constructors

	public WindowsFactAttribute([CallerFilePath] string? sourceFilePath = null, [CallerLineNumber] int sourceLineNumber = -1) : base(sourceFilePath, sourceLineNumber)
	{
		if(!OperatingSystem.IsWindows())
			this.Skip = SkipMessage;
	}

	#endregion
}