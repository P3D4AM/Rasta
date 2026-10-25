using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRM.General.IO;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using Elmah;

namespace CRMIdeal.Areas.Setting.Controllers;

public class SettingCrmPicController : Controller
{
	private CRMSpEntities _db = new CRMSpEntities();

	private CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actEdit")]
	public ActionResult Index()
	{
		return View();
	}

	[ValidateAntiForgeryToken]
	public ActionResult ActAttachFile(HttpPostedFileBase attachFileUrlUpload)
	{
		string text = "";
		bool flag = false;
		try
		{
			if (attachFileUrlUpload != null)
			{
				string text2 = attachFileUrlUpload.ContentType.ToLower();
				string text3 = Path.GetExtension(attachFileUrlUpload.FileName).ToLower();
				if ((text2 != "image/x-png" && text2 != "image/png") || text3 != ".png")
				{
					text = Messages.msgErrorWrongFileType;
					return Json(new
					{
						Success = false.ToString(),
						Message = text
					}, JsonRequestBehavior.AllowGet);
				}
				double num = 1536.0;
				if ((double)(attachFileUrlUpload.ContentLength / 1024) > num)
				{
					text = string.Format(Messages.frmErrorMaxImageSizeForUpload, num);
					return Json(new
					{
						Success = flag.ToString(),
						Message = text
					}, JsonRequestBehavior.AllowGet);
				}
				string text4 = "~/Images/CustomImages";
				string text5 = base.Server.MapPath(text4);
				if (!System.IO.Directory.Exists(text5))
				{
					System.IO.Directory.CreateDirectory(text5);
					CRM.General.IO.Directory.SetFullControlForEveryOne(text5);
				}
				string text6 = base.Server.MapPath(text4 + "/");
				if (!System.IO.Directory.Exists(text6))
				{
					System.IO.Directory.CreateDirectory(text6);
					CRM.General.IO.Directory.SetFullControlForEveryOne(text6);
				}
				string path = "CRMIdeal-CustomerLogoInLogin.png";
				string text7 = Path.Combine(text6, path);
				if (System.IO.File.Exists(text7))
				{
					System.IO.File.Delete(text7);
				}
				attachFileUrlUpload.SaveAs(text7);
				ImageManager.CompressFile(new ImageManager.ImageParam
				{
					FilePath = text7,
					CustomHeight = 150,
					CustomWidth = 170
				});
				if (System.IO.File.Exists(text7))
				{
					text = "yes";
					flag = true;
				}
				else
				{
					text += Messages.msgErrorNotCreateFileInServer;
					flag = false;
				}
			}
			else
			{
				text += Messages.frmErrorNotFileSelected;
				flag = false;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			text += Messages.frmErrorInSendingFile;
			flag = false;
		}
		var data = new
		{
			Success = flag.ToString(),
			Message = text
		};
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public string DeleteCustomerLogoInLogin()
	{
		string result = "0";
		try
		{
			string text = "~/Images/CustomImages/CRMIdeal-CustomerLogoInLogin.png";
			string path = base.Server.MapPath(text);
			if (System.IO.File.Exists(path))
			{
				System.IO.File.Delete(path);
				result = "1";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[ValidateAntiForgeryToken]
	public ActionResult ActAttachLoginPic(HttpPostedFileBase attachLoginPicUrlUpload)
	{
		string text = "";
		bool flag = false;
		try
		{
			if (attachLoginPicUrlUpload != null)
			{
				string text2 = attachLoginPicUrlUpload.ContentType.ToLower();
				string text3 = Path.GetExtension(attachLoginPicUrlUpload.FileName).ToLower();
				if ((text2 != "image/x-png" && text2 != "image/png") || text3 != ".png")
				{
					text = Messages.msgErrorWrongFileType;
					return Json(new
					{
						Success = false.ToString(),
						Message = text
					}, JsonRequestBehavior.AllowGet);
				}
				double num = 1536.0;
				if ((double)(attachLoginPicUrlUpload.ContentLength / 1024) > num)
				{
					text = string.Format(Messages.frmErrorMaxImageSizeForUpload, num);
					return Json(new
					{
						Success = flag.ToString(),
						Message = text
					}, JsonRequestBehavior.AllowGet);
				}
				string text4 = "~/Images/CustomImages";
				string text5 = base.Server.MapPath(text4);
				if (!System.IO.Directory.Exists(text5))
				{
					System.IO.Directory.CreateDirectory(text5);
					CRM.General.IO.Directory.SetFullControlForEveryOne(text5);
				}
				string text6 = base.Server.MapPath(text4 + "/");
				if (!System.IO.Directory.Exists(text6))
				{
					System.IO.Directory.CreateDirectory(text6);
					CRM.General.IO.Directory.SetFullControlForEveryOne(text6);
				}
				string path = "CRMIdeal-Login-Pic.png";
				string text7 = Path.Combine(text6, path);
				if (System.IO.File.Exists(text7))
				{
					System.IO.File.Delete(text7);
				}
				string path2 = "CRMIdeal-Login-PicI.png";
				string text8 = Path.Combine(text6, path2);
				if (System.IO.File.Exists(text8))
				{
					System.IO.File.Delete(text8);
				}
				attachLoginPicUrlUpload.SaveAs(text8);
				ImageFormat format = SetImageFormat(text8);
				int width = 1440;
				int height = 970;
				ResizeImage(text8, text7, format, width, height);
				if (System.IO.File.Exists(text8))
				{
					System.IO.File.Delete(text8);
				}
				if (System.IO.File.Exists(text7))
				{
					text = "yes";
					flag = true;
				}
				else
				{
					text += Messages.msgErrorNotCreateFileInServer;
					flag = false;
				}
			}
			else
			{
				text += Messages.frmErrorNotFileSelected;
				flag = false;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			text += Messages.frmErrorInSendingFile;
			flag = false;
		}
		var data = new
		{
			Success = flag.ToString(),
			Message = text
		};
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public string DeleteLoginPic()
	{
		string result = "0";
		try
		{
			string text = "~/Images/CustomImages/CRMIdeal-Login-Pic.png";
			string path = base.Server.MapPath(text);
			if (System.IO.File.Exists(path))
			{
				System.IO.File.Delete(path);
				result = "1";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[ValidateAntiForgeryToken]
	public ActionResult ActAttachHomePic(HttpPostedFileBase attachHomePicUrlUpload)
	{
		string text = "";
		bool flag = false;
		try
		{
			if (attachHomePicUrlUpload != null)
			{
				string text2 = attachHomePicUrlUpload.ContentType.ToLower();
				string text3 = Path.GetExtension(attachHomePicUrlUpload.FileName).ToLower();
				if ((text2 != "image/x-png" && text2 != "image/png") || text3 != ".png")
				{
					text = Messages.msgErrorWrongFileType;
					return Json(new
					{
						Success = false.ToString(),
						Message = text
					}, JsonRequestBehavior.AllowGet);
				}
				double num = 1536.0;
				if ((double)(attachHomePicUrlUpload.ContentLength / 1024) > num)
				{
					text = string.Format(Messages.frmErrorMaxImageSizeForUpload, num);
					return Json(new
					{
						Success = flag.ToString(),
						Message = text
					}, JsonRequestBehavior.AllowGet);
				}
				string text4 = "~/Images/CustomImages";
				string text5 = base.Server.MapPath(text4);
				if (!System.IO.Directory.Exists(text5))
				{
					System.IO.Directory.CreateDirectory(text5);
					CRM.General.IO.Directory.SetFullControlForEveryOne(text5);
				}
				string text6 = base.Server.MapPath(text4 + "/");
				if (!System.IO.Directory.Exists(text6))
				{
					System.IO.Directory.CreateDirectory(text6);
					CRM.General.IO.Directory.SetFullControlForEveryOne(text6);
				}
				string path = "CRMIdeal-Home-Pic.png";
				string text7 = Path.Combine(text6, path);
				if (System.IO.File.Exists(text7))
				{
					System.IO.File.Delete(text7);
				}
				string path2 = "CRMIdeal-Home-PicI.png";
				string text8 = Path.Combine(text6, path2);
				if (System.IO.File.Exists(text8))
				{
					System.IO.File.Delete(text8);
				}
				attachHomePicUrlUpload.SaveAs(text8);
				ImageFormat format = SetImageFormat(text8);
				int width = 1250;
				int height = 550;
				ResizeImage(text8, text7, format, width, height);
				if (System.IO.File.Exists(text8))
				{
					System.IO.File.Delete(text8);
				}
				if (System.IO.File.Exists(text7))
				{
					text = "yes";
					flag = true;
				}
				else
				{
					text += Messages.msgErrorNotCreateFileInServer;
					flag = false;
				}
			}
			else
			{
				text += Messages.frmErrorNotFileSelected;
				flag = false;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			text += Messages.frmErrorInSendingFile;
			flag = false;
		}
		var data = new
		{
			Success = flag.ToString(),
			Message = text
		};
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public string DeleteHomePic()
	{
		string result = "0";
		try
		{
			string text = "~/Images/CustomImages/CRMIdeal-Home-Pic.png";
			string path = base.Server.MapPath(text);
			if (System.IO.File.Exists(path))
			{
				System.IO.File.Delete(path);
				result = "1";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public static bool ResizeImage(string orgFile, string resizedFile, ImageFormat format, int width, int height)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			Image val = Image.FromFile(orgFile);
			try
			{
				Bitmap val2 = new Bitmap(width, height, val.PixelFormat);
				Graphics obj = Graphics.FromImage((Image)val2);
				obj.CompositingQuality = (CompositingQuality)2;
				obj.SmoothingMode = (SmoothingMode)2;
				obj.InterpolationMode = (InterpolationMode)7;
				obj.PixelOffsetMode = (PixelOffsetMode)2;
				Rectangle val3 = default(Rectangle);
				((Rectangle)(ref val3))._002Ector(0, 0, width, height);
				obj.DrawImage(val, val3);
				((Image)val2).Save(resizedFile, format);
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
			return true;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return false;
		}
	}

	public ImageFormat SetImageFormat(string fileName)
	{
		ImageFormat result = ImageFormat.Png;
		if (string.IsNullOrEmpty(fileName))
		{
			return result;
		}
		string[] array = fileName.Split(new char[1] { '.' });
		if (Enumerable.Any<string>((IEnumerable<string>)array) && array.Length == 2)
		{
			switch (array[1].ToLower())
			{
			case "jpeg":
			case "jpg":
				result = ImageFormat.Jpeg;
				break;
			case "png":
				result = ImageFormat.Png;
				break;
			case "gif":
				result = ImageFormat.Gif;
				break;
			case "tiff":
				result = ImageFormat.Tiff;
				break;
			case "bmp":
				result = ImageFormat.Bmp;
				break;
			default:
				result = ImageFormat.Png;
				break;
			}
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string SetLoginAuthType(string loginAuthTypes = null, int? loginAuthTypesDef = null, string activeDirectoryDomain = null, string loginAuthTypesInfoJson = "")
	{
		string result = "";
		try
		{
			if (!string.IsNullOrWhiteSpace(loginAuthTypesInfoJson))
			{
				loginAuthTypesInfoJson = HttpUtility.UrlDecode(loginAuthTypesInfoJson);
			}
			_dbII.CRMspUpdateSysSettingLoginAuth(loginAuthTypes, loginAuthTypesDef, activeDirectoryDomain, loginAuthTypesInfoJson);
			SysSeting.Update();
		}
		catch (Exception ex)
		{
			result = "Error: " + ex.Message;
		}
		return result;
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		base.Dispose(disposing);
	}
}
