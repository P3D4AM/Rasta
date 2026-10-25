using System.IO;
using System.Web;
using System.Web.Mvc;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using Kendo.Mvc.UI;

namespace CRMIdeal.Areas.Cms.Controllers;

public class FooterImageBrowserController : EditorImageBrowserController
{
	private static readonly string[] foldersToCopy = new string[1] { "~/Uploads/shared/" };

	public override string ContentPath => CreateUserFolder();

	private string CreateUserFolder()
	{
		string text = Configuration.HostTempFilesPath + "/CmsFooter";
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

	[AcceptVerbs(HttpVerbs.Post)]
	public virtual ActionResult UploadI(string path, HttpPostedFileBase file)
	{
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		path = NormalizePathI(path);
		string fileName = Path.GetFileName(file.FileName);
		if (AuthorizeUpload(path, file))
		{
			file.SaveAs(Path.Combine(base.Server.MapPath(path), fileName));
			ImageManager.CompressFile(new ImageManager.ImageParam
			{
				FilePath = Path.Combine(base.Server.MapPath(path), fileName)
			});
			return Json(new ImageBrowserEntry
			{
				Size = file.ContentLength,
				Name = fileName
			}, "text/plain");
		}
		throw new HttpException(403, "Forbidden");
	}
}
