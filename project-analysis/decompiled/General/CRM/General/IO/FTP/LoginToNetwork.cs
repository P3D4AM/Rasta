using System;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Threading;

namespace CRM.General.IO.FTP;

public static class LoginToNetwork
{
	private const int LOGON32_PROVIDER_DEFAULT = 0;

	private const int LOGON32_LOGON_NEW_CREDENTIALS = 9;

	[DllImport("advapi32.DLL", SetLastError = true)]
	public static extern bool LogonUser(string lpszUsername, string lpszDomain, string lpszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken);

	[DllImport("kernel32.dll", CharSet = CharSet.Auto)]
	public static extern bool CloseHandle(IntPtr handle);

	public static bool Impersonate(string Destination, string UserName, string Pwd)
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Expected O, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		IntPtr intPtr = new IntPtr(0);
		intPtr = IntPtr.Zero;
		if (Destination.EndsWith("\\"))
		{
			Destination = Destination.Substring(0, Destination.Length - 1);
		}
		if (!LogonUser(UserName, Destination, Pwd, 9, 0, ref intPtr))
		{
			Marshal.GetLastWin32Error();
			return false;
		}
		WindowsIdentity val = new WindowsIdentity(intPtr);
		Thread.CurrentPrincipal = (IPrincipal?)new WindowsPrincipal(val);
		CloseHandle(intPtr);
		val.Impersonate();
		return true;
	}
}
