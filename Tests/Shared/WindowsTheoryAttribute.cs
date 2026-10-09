using System.Runtime.CompilerServices;

namespace Shared;

public class WindowsTheoryAttribute : TheoryAttribute
{
	#region Constructors

	public WindowsTheoryAttribute([CallerFilePath] string? sourceFilePath = null, [CallerLineNumber] int sourceLineNumber = -1) : base(sourceFilePath, sourceLineNumber)
	{
		if(!OperatingSystem.IsWindows())
			this.Skip = WindowsFactAttribute.SkipMessage;
	}

	#endregion
}