using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Objects;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using CRM.General.IO.FTP;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;

namespace CRMIdeal.Areas.PreOrders.Controllers;

public class TransferPordFileToOrdController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public int Id;
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	[DynamicAuthorize(ControllerName = "frmPreOrder", ActionName = "actTransferPreOrderFileToOrderOneToOne")]
	public ActionResult TransferPordFileToOrdOneToOne(int pordId = 0, int currFileDirId = 0, int ordId = 0)
	{
		CRMspSelectFilesDirectory_Result cRMspSelectFilesDirectory_Result = new CRMspSelectFilesDirectory_Result();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			if (pordId > 0 && currFileDirId > 0)
			{
				List<CRMspSelectFilesDirectory_Result> list = Files.SelectFilesDirectory("", "", "", "10", pordId.ToString(), "0", "0", false);
				if (list != null && Enumerable.Any<CRMspSelectFilesDirectory_Result>((IEnumerable<CRMspSelectFilesDirectory_Result>)list))
				{
					cRMspSelectFilesDirectory_Result = Enumerable.FirstOrDefault<CRMspSelectFilesDirectory_Result>((IEnumerable<CRMspSelectFilesDirectory_Result>)list, (Func<CRMspSelectFilesDirectory_Result, bool>)((CRMspSelectFilesDirectory_Result x) => x.FileDirectoryID == currFileDirId));
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.FilesDirectories = cRMspSelectFilesDirectory_Result;
		base.ViewBag.OrderFileDirectoryTypes = SelectFileDirectoryTypeByOprId();
		base.ViewBag.OrderId = ordId;
		return View();
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmPreOrder", ActionName = "actTransferPreOrderFileToOrderOneToOne")]
	public JsonResult ftpTransferPordFileToOrdOneToOne(int orderId = 0, int pordId = 0, int currFileDirId = 0, int selectedFileDirType = 0)
	{
		CommonReturnResultViewModel commonReturnResultViewModel = new CommonReturnResultViewModel();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
		_ = UserLogin.CurrentUser.UserId;
		_ = Financial.Get().Id;
		short.Parse(Financial.Get().Id.ToString());
		short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
		_ = Configuration.AppType;
		if (orderId > 0 && pordId > 0 && currFileDirId > 0 && selectedFileDirType != 0)
		{
			CRMspSelectFilesDirectory_Result pordFileDir = new CRMspSelectFilesDirectory_Result();
			List<CRMspSelectFilesDirectory_Result> list = Files.SelectFilesDirectory("", "", "", "10", pordId.ToString(), "0", "0", false);
			if (list != null && Enumerable.Any<CRMspSelectFilesDirectory_Result>((IEnumerable<CRMspSelectFilesDirectory_Result>)list))
			{
				pordFileDir = Enumerable.FirstOrDefault<CRMspSelectFilesDirectory_Result>((IEnumerable<CRMspSelectFilesDirectory_Result>)list, (Func<CRMspSelectFilesDirectory_Result, bool>)((CRMspSelectFilesDirectory_Result x) => x.FileDirectoryID == currFileDirId));
			}
			commonReturnResultViewModel.IsDone = true;
			commonReturnResultViewModel.Message = CopyFtp(pordFileDir, orderId, pordId, currFileDirId, selectedFileDirType);
		}
		else
		{
			commonReturnResultViewModel.IsDone = false;
			commonReturnResultViewModel.Message = Messages.msgErrorNotSelectedItem;
		}
		base.ViewBag.Result = commonReturnResultViewModel;
		return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
	}

	public string CopyFtp(CRMspSelectFilesDirectory_Result PordFileDir, int orderId, int pordId, int currFileDirId, int selectedFileDirType)
	{
		string text = "";
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		DateTime now = DateTime.Now;
		DateTime value = now;
		string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
		int userId = UserLogin.CurrentUser.UserId;
		int id = Financial.Get().Id;
		short value2 = short.Parse(Financial.Get().Id.ToString());
		short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
		string appType = Configuration.AppType;
		if (PordFileDir != null && PordFileDir.FileDirectoryID > 0 && pordId > 0 && VersionBuyer.AttachFiles)
		{
			ObjectParameter objectParameter = new ObjectParameter("InsertedId", -1);
			_dbI.WSspTransferPreOrderFileToOrderOneToOne(PordFileDir.TypeOprObjectId, orderId, currFileDirId, selectedFileDirType, userId, id, value2, value3, value, registerDatePersian, appType, lCID, objectParameter);
			FilesManager filesManager = new FilesManager();
			FacadeFTP facadeFTP = new FacadeFTP(Configuration.FacadeFtp);
			string pathFtp = Configuration.PathFtp;
			string userNameFtp = Configuration.UserNameFtp;
			string passwordFtp = Configuration.PasswordFtp;
			bool usePassiveFtp = Configuration.UsePassiveFtp;
			string text2 = "";
			string text3 = "";
			if (!string.IsNullOrEmpty(PordFileDir.FilePath) && !string.IsNullOrEmpty(PordFileDir.FileName) && !string.IsNullOrWhiteSpace(objectParameter.Value.ToString()))
			{
				string[] array = PordFileDir.FileName.Split(new char[1] { '.' });
				string text4 = PordFileDir.FilePath.Replace(PordFileDir.FileName, "");
				text4 += (text4.EndsWith("/") ? "" : "/");
				string text5 = text4.Split(new char[1] { '/' })[^2];
				string text6 = text4.Replace(text5 + "/", "");
				string text7 = PordFileDir.FilePath.ToLower().Replace(Configuration.PathFtp.ToLower(), "");
				text7 = Configuration.MainDirectoryPath + PordFileDir.FolderName + "/" + PordFileDir.FileName;
				if (text7 != "")
				{
					text2 = filesManager.SetNameDirectory(UserLogin.CurrentUser.UserId);
					if (filesManager.CreateDirectory(text2))
					{
						text3 = HttpContext.Current.Server.MapPath(text2 + "/" + objectParameter.Value.ToString());
						if (!facadeFTP.Download(pathFtp, userNameFtp, passwordFtp, text3, text7, overwrite: true, usePassiveFtp))
						{
							if (!string.IsNullOrEmpty(text3))
							{
								text3 = HttpContext.Current.Server.MapPath(text2 + "/");
								if (Directory.Exists(text3))
								{
									DirectoryInfo directoryInfo = new DirectoryInfo(text3);
									FileInfo[] files = directoryInfo.GetFiles();
									for (int i = 0; i < files.Length; i++)
									{
										files[i].Delete();
									}
									DirectoryInfo[] directories = directoryInfo.GetDirectories();
									for (int i = 0; i < directories.Length; i++)
									{
										directories[i].Delete(recursive: true);
									}
									if (Directory.Exists(text3))
									{
										Directory.Delete(text3);
									}
								}
							}
							text3 = "";
							try
							{
								_db.CRMspDeleteCrmFilesDirectory(PordFileDir.FileDirectoryID);
							}
							catch (Exception e)
							{
								ErrorSignal.FromCurrentContext().Raise(e);
							}
						}
					}
				}
				if (!string.IsNullOrEmpty(text3))
				{
					bool flag = facadeFTP.ExistsDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, text6, text5, usePassiveFtp);
					if (!flag)
					{
						flag = facadeFTP.CreateDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, text6, text5, usePassiveFtp);
					}
					if (flag)
					{
						string text8 = orderId + "-" + objectParameter.Value.ToString() + "." + array[^1];
						if (facadeFTP.UploadFtpFormTable(pathFtp, userNameFtp, passwordFtp, text4 + text8, text3, usePassiveFtp))
						{
							_003C_003Ec__DisplayClass5_0 _003C_003Ec__DisplayClass5_ = new _003C_003Ec__DisplayClass5_0();
							string text9 = Configuration.PathFtp + text4 + text8;
							string fileName = text8;
							_003C_003Ec__DisplayClass5_.Id = 0;
							int.TryParse(objectParameter.Value.ToString(), out _003C_003Ec__DisplayClass5_.Id);
							DbSet<CrmFilesDirectory> crmFilesDirectory = _dbTbl.CrmFilesDirectory;
							ParameterExpression val = Expression.Parameter(typeof(CrmFilesDirectory), "m");
							CrmFilesDirectory crmFilesDirectory2 = Queryable.FirstOrDefault<CrmFilesDirectory>((IQueryable<CrmFilesDirectory>)crmFilesDirectory, Expression.Lambda<Func<CrmFilesDirectory, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass5_, typeof(_003C_003Ec__DisplayClass5_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (crmFilesDirectory2 != null)
							{
								text9 = text9.Trim().Replace(Configuration.PathFtp, "");
								crmFilesDirectory2.FilePath = text9;
								crmFilesDirectory2.FileName = fileName;
								_dbTbl.Entry(crmFilesDirectory2).State = EntityState.Modified;
								_dbTbl.SaveChanges();
							}
							if (!string.IsNullOrEmpty(text3))
							{
								text3 = HttpContext.Current.Server.MapPath(text2 + "/");
								if (Directory.Exists(text3))
								{
									DirectoryInfo directoryInfo2 = new DirectoryInfo(text3);
									FileInfo[] files = directoryInfo2.GetFiles();
									for (int i = 0; i < files.Length; i++)
									{
										files[i].Delete();
									}
									DirectoryInfo[] directories = directoryInfo2.GetDirectories();
									for (int i = 0; i < directories.Length; i++)
									{
										directories[i].Delete(recursive: true);
									}
									if (Directory.Exists(text3))
									{
										Directory.Delete(text3);
									}
								}
							}
						}
						else
						{
							Exception e2 = new Exception(Messages.msgErrorUploadingFileInFtp + "  -  hostname: " + Configuration.PathFtp + " ,username: " + Configuration.UserNameFtp + " ,destination: " + text6 + " ,directoryName: " + text5);
							ErrorSignal.FromCurrentContext().Raise(e2);
							text = text + "|" + Messages.frmErrorInSendingFile;
							try
							{
								_db.CRMspDeleteCrmFilesDirectory(PordFileDir.FileDirectoryID);
							}
							catch (Exception e3)
							{
								ErrorSignal.FromCurrentContext().Raise(e3);
							}
							if (!string.IsNullOrEmpty(text3))
							{
								text3 = HttpContext.Current.Server.MapPath(text2 + "/");
								if (Directory.Exists(text3))
								{
									DirectoryInfo directoryInfo3 = new DirectoryInfo(text3);
									FileInfo[] files = directoryInfo3.GetFiles();
									for (int i = 0; i < files.Length; i++)
									{
										files[i].Delete();
									}
									DirectoryInfo[] directories = directoryInfo3.GetDirectories();
									for (int i = 0; i < directories.Length; i++)
									{
										directories[i].Delete(recursive: true);
									}
									if (Directory.Exists(text3))
									{
										Directory.Delete(text3);
									}
								}
							}
						}
					}
					else
					{
						Exception e4 = new Exception(Messages.msgErrorUploadingFileInFtp + " -  hostname: " + Configuration.PathFtp + " ,username: " + Configuration.UserNameFtp + " ,destination: " + text6 + " ,directoryName: " + text5);
						ErrorSignal.FromCurrentContext().Raise(e4);
						text = text + "|" + Messages.frmErrorInSendingFile;
						try
						{
							_db.CRMspDeleteCrmFilesDirectory(PordFileDir.FileDirectoryID);
						}
						catch (Exception e5)
						{
							ErrorSignal.FromCurrentContext().Raise(e5);
						}
						if (!string.IsNullOrEmpty(text3))
						{
							text3 = HttpContext.Current.Server.MapPath(text2 + "/");
							if (Directory.Exists(text3))
							{
								DirectoryInfo directoryInfo4 = new DirectoryInfo(text3);
								FileInfo[] files = directoryInfo4.GetFiles();
								for (int i = 0; i < files.Length; i++)
								{
									files[i].Delete();
								}
								DirectoryInfo[] directories = directoryInfo4.GetDirectories();
								for (int i = 0; i < directories.Length; i++)
								{
									directories[i].Delete(recursive: true);
								}
								if (Directory.Exists(text3))
								{
									Directory.Delete(text3);
								}
							}
						}
					}
				}
				else
				{
					try
					{
						_db.CRMspDeleteCrmFilesDirectory(PordFileDir.FileDirectoryID);
					}
					catch (Exception e6)
					{
						ErrorSignal.FromCurrentContext().Raise(e6);
					}
					text = text + "|" + Messages.frmErrorInSendingFile;
				}
			}
		}
		return text;
	}

	[LoginAuthorize]
	public ActionResult TransferPordFileToOrdAll(int pordId = 0, string selectedTypes = "", bool CheckPermissions = true, int position = 1, int ordId = 0)
	{
		string text = "";
		string text2 = "";
		switch (position)
		{
		case 1:
			text = "frmPreOrder";
			text2 = "actTransferPreOrderFileToOrderAll";
			break;
		case 2:
			text = "frmIssueOrderFromPreOrder";
			text2 = "actTransferPreOrderFileToOrder";
			break;
		default:
			return RedirectToAction("Login", "Account", (object)new
			{
				area = "",
				d = DateTime.Now
			});
		}
		if (!UserLogin.IsUserAccess(text, text2, UserLogin.CurrentUser))
		{
			return RedirectToAction("Login", "Account", (object)new
			{
				area = "",
				d = DateTime.Now
			});
		}
		List<CRMspSelectFilesDirectory_Result> list = new List<CRMspSelectFilesDirectory_Result>();
		List<SelectListItem> list2 = new List<SelectListItem>();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			if (pordId > 0)
			{
				list = Files.SelectFilesDirectory("", "", "", "10", pordId.ToString(), "0", "0", false);
				if (!string.IsNullOrWhiteSpace(selectedTypes))
				{
					string[] array = selectedTypes.Split(new char[1] { '|' });
					foreach (string text3 in array)
					{
						if (!string.IsNullOrWhiteSpace(text3))
						{
							string[] array2 = text3.Split(new char[1] { '=' });
							list2.Add(new SelectListItem
							{
								Text = array2[0],
								Value = array2[1]
							});
						}
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.lstSelectedFilesDirecoryTypes = list2;
		base.ViewBag.CheckPermissions = CheckPermissions;
		base.ViewBag.FilesDirectories = list;
		base.ViewBag.OrderFileDirectoryTypes = SelectFileDirectoryTypeByOprId();
		base.ViewBag.OrderId = ordId;
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmPreOrder", ActionName = "actTransferPreOrderFileToOrderAll")]
	public JsonResult ftpTransferPordFileToOrdAll(int orderId = 0, int pordId = 0, string filesDirectoryTypes = "")
	{
		CommonReturnResultViewModel commonReturnResultViewModel = new CommonReturnResultViewModel();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			if (pordId > 0 && !string.IsNullOrWhiteSpace(filesDirectoryTypes))
			{
				List<CRMspSelectFilesDirectory_Result> list = Files.SelectFilesDirectory("", "", "", "10", pordId.ToString(), "0", "0", false);
				List<SelectListItem> list2 = new List<SelectListItem>();
				string[] array = filesDirectoryTypes.Split(new char[1] { '|' });
				foreach (string text in array)
				{
					if (!string.IsNullOrWhiteSpace(text))
					{
						string[] array2 = text.Split(new char[1] { '=' });
						list2.Add(new SelectListItem
						{
							Text = array2[0],
							Value = array2[1]
						});
					}
				}
				if (list != null && list.Count > 0)
				{
					foreach (CRMspSelectFilesDirectory_Result itm in list)
					{
						SelectListItem selectListItem = Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list2, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == itm.FileDirectoryID.ToString()));
						if (selectListItem != null)
						{
							commonReturnResultViewModel.Message += CopyFtp(itm, orderId, pordId, itm.FileDirectoryID, int.Parse(selectListItem.Value));
						}
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.Result = commonReturnResultViewModel;
		return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
	}

	public List<SelectListItem> SelectFileDirectoryTypeByOprId(int fileDirectoryTypeOprId = 20)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<CRMspSelectFileDirectoryTypeByOprId_Result> list2 = Enumerable.ToList<CRMspSelectFileDirectoryTypeByOprId_Result>((IEnumerable<CRMspSelectFileDirectoryTypeByOprId_Result>)_db.CRMspSelectFileDirectoryTypeByOprId(fileDirectoryTypeOprId, lCID, result));
			if (list2 != null && list2.Count > 0)
			{
				foreach (CRMspSelectFileDirectoryTypeByOprId_Result item2 in list2)
				{
					SelectListItem item = new SelectListItem
					{
						Text = item2.FileDirectoryType,
						Value = item2.FileDirectoryTypeID.ToString(),
						Selected = false
					};
					list.Add(item);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		_dbI.Dispose();
		base.Dispose(disposing);
	}
}
