using System;

namespace CRM.General.Utilities;

public static class Guid
{
	public static string NewGuid => System.Guid.NewGuid().ToString();

	public static string NewGuidWithoutDash => NewGuid.Replace("-", string.Empty);
}
