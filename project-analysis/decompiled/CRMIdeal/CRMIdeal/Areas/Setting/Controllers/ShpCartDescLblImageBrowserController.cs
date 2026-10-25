using System.IO;
using CRMIdeal.Classes.Common;
using Kendo.Mvc.UI;

namespace CRMIdeal.Areas.Setting.Controllers;

public class ShpCartDescLblImageBrowserController : EditorImageBrowserController
{
	private static readonly string[] foldersToCopy = new string[1] { "~/Uploads/shared/" };

	public override string ContentPath => CreateUserFolder();

	private string CreateUserFolder()
	{
		string text = Configuration.HostTempFilesPath + "/ShopCartDescLbl";
		string text2 = base.Server.MapPath(text);
		if (!Directory.Exists(text2))
		{
			Directory.CreateDirectory(text2);
			string[] array = foldersToCopy;
			foreach (string text3 in array)
			{
				CopyFolder(base.Server.MapPath(text3), text2);
			}
		}
		return text;
	}

	private void CopyFolder(string source, string destination)
	{
		if (!Directory.Exists(destination))
		{
			Directory.CreateDirectory(destination);
		}
		foreach (string item in Directory.EnumerateFiles(source))
		{
			string destFileName = Path.Combine(destination, Path.GetFileName(item));
			System.IO.File.Copy(item, destFileName);
		}
		foreach (string item2 in Directory.EnumerateDirectories(source))
		{
			string destination2 = Path.Combine(destination, Path.GetFileName(item2));
			CopyFolder(item2, destination2);
		}
	}
}
