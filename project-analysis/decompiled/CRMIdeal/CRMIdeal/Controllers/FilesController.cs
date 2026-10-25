using System;
using System.IO;
using System.Web.Mvc;
using CRMIdeal.Classes;

namespace CRMIdeal.Controllers;

public class FilesController : Controller
{
	[HttpGet]
	public FileResult Download(string filePath, bool isDelete = false)
	{
		try
		{
			FileContentResult result = File(System.IO.File.ReadAllBytes(filePath), "application/octet-stream", Path.GetFileName(filePath));
			if (isDelete)
			{
				new FilesManager().DeleteDirectory(new FileInfo(filePath).DirectoryName, 1);
			}
			return result;
		}
		catch (Exception)
		{
			return null;
		}
	}
}
