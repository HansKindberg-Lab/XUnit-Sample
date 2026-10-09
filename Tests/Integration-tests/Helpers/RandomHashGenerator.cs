using System.Security.Cryptography;

namespace IntegrationTests.Helpers;

public static class RandomHashGenerator
{
	#region Fields

	private const string _characters = "abcdefghijklmnopqrstuvwxyz0123456789";

	#endregion

	#region Methods

	public static string Generate(int length = 8)
	{
		return string.Create(length, _characters, static (character, value) =>
		{
			for(int i = 0; i < character.Length; i++)
			{
				character[i] = value[RandomNumberGenerator.GetInt32(value.Length)];
			}
		});
	}

	#endregion
}