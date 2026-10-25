using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using CRM.General.IO;
using CRM.General.IO.FTP;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using Elmah;

namespace CRMIdeal.Areas.Setting.Controllers;

public class TestFtpController : Controller
{
	private CRMSpEntities _db = new CRMSpEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actSetting")]
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
				attachFileUrlUpload.ContentType.ToLower();
				Path.GetExtension(attachFileUrlUpload.FileName).ToLower();
				string text2 = Configuration.HostTempFilesPath + "/Test";
				string text3 = base.Server.MapPath(text2);
				if (!System.IO.Directory.Exists(text3))
				{
					System.IO.Directory.CreateDirectory(text3);
					CRM.General.IO.Directory.SetFullControlForEveryOne(text3);
				}
				string text4 = base.Server.MapPath(text2 + "/");
				if (!System.IO.Directory.Exists(text4))
				{
					System.IO.Directory.CreateDirectory(text4);
					CRM.General.IO.Directory.SetFullControlForEveryOne(text4);
				}
				string text5 = Path.GetFileName(attachFileUrlUpload.FileName);
				if (text5 != null)
				{
					string text6 = Path.Combine(text4, text5);
					if (System.IO.File.Exists(text6))
					{
						text5 = DateTime.Now.ToString("yyyyMMdd-HHmmss") + "-" + text5;
						text6 = Path.Combine(text4, text5);
					}
					attachFileUrlUpload.SaveAs(text6);
					if (System.IO.File.Exists(text6))
					{
						FacadeFTP facadeFTP = new FacadeFTP(Configuration.FacadeFtp);
						string mainDirectoryPath = Configuration.MainDirectoryPath;
						string text7 = "Test";
						bool flag2 = facadeFTP.ExistsDirectoryInFtp(Configuration.PathFtp, Configuration.UserNameFtp, Configuration.PasswordFtp, mainDirectoryPath, text7, Configuration.UsePassiveFtp);
						if (!flag2)
						{
							flag2 = facadeFTP.CreateDirectoryInFtp(Configuration.PathFtp, Configuration.UserNameFtp, Configuration.PasswordFtp, mainDirectoryPath, text7, Configuration.UsePassiveFtp);
						}
						if (flag2)
						{
							string text8 = "";
							string text9 = "";
							mainDirectoryPath = mainDirectoryPath + text7 + "/";
							string[] array = text5.Split(new char[1] { '.' });
							text8 = text7 + "-" + DateTime.Now.ToString("yyyyMMdd-HHmmss") + "." + array[^1];
							mainDirectoryPath += text8;
							text9 = text6;
							if (text9 != "")
							{
								flag = facadeFTP.UploadFtpFormTable(Configuration.PathFtp, Configuration.UserNameFtp, Configuration.PasswordFtp, mainDirectoryPath, text9, Configuration.UsePassiveFtp);
							}
							text = (flag ? "yes" : "no");
						}
						else
						{
							text += Messages.msgErrorFtpIncorrect;
							flag = false;
						}
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

	[ValidateAntiForgeryToken]
	public ActionResult ActAttachFileRecording(HttpPostedFileBase attachFileRecordingUrlUpload)
	{
		string text = "";
		bool flag = false;
		try
		{
			if (!string.IsNullOrEmpty(Configuration.PathFtpRecording))
			{
				if (attachFileRecordingUrlUpload != null)
				{
					attachFileRecordingUrlUpload.ContentType.ToLower();
					Path.GetExtension(attachFileRecordingUrlUpload.FileName).ToLower();
					string text2 = Configuration.HostTempFilesPath + "/Test";
					string text3 = base.Server.MapPath(text2);
					if (!System.IO.Directory.Exists(text3))
					{
						System.IO.Directory.CreateDirectory(text3);
						CRM.General.IO.Directory.SetFullControlForEveryOne(text3);
					}
					string text4 = base.Server.MapPath(text2 + "/");
					if (!System.IO.Directory.Exists(text4))
					{
						System.IO.Directory.CreateDirectory(text4);
						CRM.General.IO.Directory.SetFullControlForEveryOne(text4);
					}
					string text5 = Path.GetFileName(attachFileRecordingUrlUpload.FileName);
					if (text5 != null)
					{
						string text6 = Path.Combine(text4, text5);
						if (System.IO.File.Exists(text6))
						{
							text5 = DateTime.Now.ToString("yyyyMMdd-HHmmss") + "-" + text5;
							text6 = Path.Combine(text4, text5);
						}
						attachFileRecordingUrlUpload.SaveAs(text6);
						if (System.IO.File.Exists(text6))
						{
							FacadeFTP facadeFTP = new FacadeFTP(Configuration.FacadeFtpRecording);
							string text7 = "/";
							string text8 = "Test";
							bool flag2 = facadeFTP.ExistsDirectoryInFtp(Configuration.PathFtpRecording, Configuration.UserNameFtpRecording, Configuration.PasswordFtpRecording, text7, text8, Configuration.UsePassiveFtpRecording);
							if (!flag2)
							{
								flag2 = facadeFTP.CreateDirectoryInFtp(Configuration.PathFtpRecording, Configuration.UserNameFtpRecording, Configuration.PasswordFtpRecording, text7, text8, Configuration.UsePassiveFtpRecording);
							}
							if (flag2)
							{
								string text9 = "";
								string text10 = "";
								text7 = text7 + text8 + "/";
								string[] array = text5.Split(new char[1] { '.' });
								text9 = text8 + "-" + DateTime.Now.ToString("yyyyMMdd-HHmmss") + "." + array[^1];
								text7 += text9;
								text10 = text6;
								if (text10 != "")
								{
									flag = facadeFTP.UploadFtpFormTable(Configuration.PathFtpRecording, Configuration.UserNameFtpRecording, Configuration.PasswordFtpRecording, text7, text10, Configuration.UsePassiveFtpRecording);
								}
								text = (flag ? "yes" : "no");
							}
							else
							{
								text += Messages.msgErrorFtpIncorrect;
								flag = false;
							}
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
			}
			else
			{
				text += Messages.msgErrorFtpRecordingNotDefined;
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

	[ValidateAntiForgeryToken]
	public ActionResult ActAttachFileRecordingII(HttpPostedFileBase attachFileRecordingIIUrlUpload)
	{
		string text = "";
		bool flag = false;
		try
		{
			if (!string.IsNullOrEmpty(Configuration.PathFtpRecordingII))
			{
				if (attachFileRecordingIIUrlUpload != null)
				{
					attachFileRecordingIIUrlUpload.ContentType.ToLower();
					Path.GetExtension(attachFileRecordingIIUrlUpload.FileName).ToLower();
					string text2 = Configuration.HostTempFilesPath + "/Test";
					string text3 = base.Server.MapPath(text2);
					if (!System.IO.Directory.Exists(text3))
					{
						System.IO.Directory.CreateDirectory(text3);
						CRM.General.IO.Directory.SetFullControlForEveryOne(text3);
					}
					string text4 = base.Server.MapPath(text2 + "/");
					if (!System.IO.Directory.Exists(text4))
					{
						System.IO.Directory.CreateDirectory(text4);
						CRM.General.IO.Directory.SetFullControlForEveryOne(text4);
					}
					string text5 = Path.GetFileName(attachFileRecordingIIUrlUpload.FileName);
					if (text5 != null)
					{
						string text6 = Path.Combine(text4, text5);
						if (System.IO.File.Exists(text6))
						{
							text5 = DateTime.Now.ToString("yyyyMMdd-HHmmss") + "-" + text5;
							text6 = Path.Combine(text4, text5);
						}
						attachFileRecordingIIUrlUpload.SaveAs(text6);
						if (System.IO.File.Exists(text6))
						{
							FacadeFTP facadeFTP = new FacadeFTP(Configuration.FacadeFtpRecordingII);
							string text7 = "/";
							string text8 = "Test";
							bool flag2 = facadeFTP.ExistsDirectoryInFtp(Configuration.PathFtpRecordingII, Configuration.UserNameFtpRecordingII, Configuration.PasswordFtpRecordingII, text7, text8, Configuration.UsePassiveFtpRecordingII);
							if (!flag2)
							{
								flag2 = facadeFTP.CreateDirectoryInFtp(Configuration.PathFtpRecordingII, Configuration.UserNameFtpRecordingII, Configuration.PasswordFtpRecordingII, text7, text8, Configuration.UsePassiveFtpRecordingII);
							}
							if (flag2)
							{
								string text9 = "";
								string text10 = "";
								text7 = text7 + text8 + "/";
								string[] array = text5.Split(new char[1] { '.' });
								text9 = text8 + "-" + DateTime.Now.ToString("yyyyMMdd-HHmmss") + "." + array[^1];
								text7 += text9;
								text10 = text6;
								if (text10 != "")
								{
									flag = facadeFTP.UploadFtpFormTable(Configuration.PathFtpRecordingII, Configuration.UserNameFtpRecordingII, Configuration.PasswordFtpRecordingII, text7, text10, Configuration.UsePassiveFtpRecordingII);
								}
								text = (flag ? "yes" : "no");
							}
							else
							{
								text += Messages.msgErrorFtpIncorrect;
								flag = false;
							}
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
			}
			else
			{
				text += Messages.msgErrorFtpRecordingNotDefined;
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

	[ValidateAntiForgeryToken]
	public ActionResult ActAttachFileFO(HttpPostedFileBase attachFileFOUrlUpload)
	{
		string text = "";
		bool flag = false;
		try
		{
			if (!string.IsNullOrEmpty(Configuration.PathFtpFo))
			{
				if (attachFileFOUrlUpload != null)
				{
					attachFileFOUrlUpload.ContentType.ToLower();
					Path.GetExtension(attachFileFOUrlUpload.FileName).ToLower();
					string text2 = Configuration.HostTempFilesPath + "/Test";
					string text3 = base.Server.MapPath(text2);
					if (!System.IO.Directory.Exists(text3))
					{
						System.IO.Directory.CreateDirectory(text3);
						CRM.General.IO.Directory.SetFullControlForEveryOne(text3);
					}
					string text4 = base.Server.MapPath(text2 + "/");
					if (!System.IO.Directory.Exists(text4))
					{
						System.IO.Directory.CreateDirectory(text4);
						CRM.General.IO.Directory.SetFullControlForEveryOne(text4);
					}
					string text5 = Path.GetFileName(attachFileFOUrlUpload.FileName);
					if (text5 != null)
					{
						string text6 = Path.Combine(text4, text5);
						if (System.IO.File.Exists(text6))
						{
							text5 = DateTime.Now.ToString("yyyyMMdd-HHmmss") + "-" + text5;
							text6 = Path.Combine(text4, text5);
						}
						attachFileFOUrlUpload.SaveAs(text6);
						if (System.IO.File.Exists(text6))
						{
							FacadeFTP facadeFTP = new FacadeFTP(Configuration.FacadeFtpFo);
							string text7 = "/";
							string text8 = "Test";
							bool flag2 = facadeFTP.ExistsDirectoryInFtp(Configuration.PathFtpFo, Configuration.UserNameFtpFo, Configuration.PasswordFtpFo, text7, text8, Configuration.UsePassiveFtpFo);
							if (!flag2)
							{
								flag2 = facadeFTP.CreateDirectoryInFtp(Configuration.PathFtpFo, Configuration.UserNameFtpFo, Configuration.PasswordFtpFo, text7, text8, Configuration.UsePassiveFtpFo);
							}
							if (flag2)
							{
								string text9 = "";
								string text10 = "";
								text7 = text7 + text8 + "/";
								string[] array = text5.Split(new char[1] { '.' });
								text9 = text8 + "-" + DateTime.Now.ToString("yyyyMMdd-HHmmss") + "." + array[^1];
								text7 += text9;
								text10 = text6;
								if (text10 != "")
								{
									flag = facadeFTP.UploadFtpFormTable(Configuration.PathFtpFo, Configuration.UserNameFtpFo, Configuration.PasswordFtpFo, text7, text10, Configuration.UsePassiveFtpFo);
								}
								text = (flag ? "yes" : "no");
							}
							else
							{
								text += Messages.msgErrorFtpIncorrect;
								flag = false;
							}
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
			}
			else
			{
				text += Messages.msgErrorFtpFONotDefined;
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

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		base.Dispose(disposing);
	}
}
