using System;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;

namespace CRM.General.IO;

public static class Directory
{
	public static void SetFullControlForEveryOne(string path)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		try
		{
			DirectorySecurity accessControl = System.IO.Directory.GetAccessControl(path);
			FileSystemAccessRule rule = new FileSystemAccessRule((IdentityReference)new SecurityIdentifier((WellKnownSidType)1, (SecurityIdentifier)null), FileSystemRights.FullControl, (InheritanceFlags)3, (PropagationFlags)0, (AccessControlType)0);
			accessControl.AddAccessRule(rule);
			System.IO.Directory.SetAccessControl(path, accessControl);
		}
		catch (Exception ex)
		{
			_ = ex.Message;
		}
	}
}
