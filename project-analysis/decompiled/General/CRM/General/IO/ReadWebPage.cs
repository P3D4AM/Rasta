using System.IO;
using System.Net;
using System.Text;

namespace CRM.General.IO;

public static class ReadWebPage
{
	public static string Read(string url)
	{
		try
		{
			return new StreamReader(WebRequest.Create(url).GetResponse().GetResponseStream(), Encoding.UTF8).ReadToEnd();
		}
		catch
		{
			return null;
		}
	}
}
