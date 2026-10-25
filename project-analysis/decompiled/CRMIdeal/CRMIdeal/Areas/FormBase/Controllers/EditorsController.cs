using System;
using System.IO;
using System.Net;
using System.Web.Mvc;
using CRMIdeal.Classes;
using Elmah;

namespace CRMIdeal.Areas.FormBase.Controllers;

public class EditorsController : Controller
{
	public ActionResult Index()
	{
		return View();
	}

	[LoginAuthorize]
	public string KendoEditor2022(string ctrlName = "")
	{
		base.ViewBag.CtrlName = ctrlName;
		string result = "";
		StreamReader streamReader = null;
		WebResponse val = null;
		try
		{
			val = WebRequest.Create("http://localhost:63695/Home/Index?ctrlName=" + ctrlName).GetResponse();
			streamReader = new StreamReader(val.GetResponseStream());
			result = streamReader.ReadToEnd();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			streamReader?.Close();
			if (val != null)
			{
				val.Close();
			}
		}
		return result;
	}
}
