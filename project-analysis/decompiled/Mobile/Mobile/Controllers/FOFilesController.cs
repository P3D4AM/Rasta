using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using CRM.General.Calendar;
using CRM.General.IO;
using CRM.General.IO.FTP;
using CRM.Resources;
using Elmah;
using GSD.Globalization;
using Mobile.Cache.Setting;
using Mobile.Classes;
using Mobile.Classes.Helper;
using Mobile.DataType;
using Mobile.Models;
using Newtonsoft.Json;

namespace Mobile.Controllers;

public class FOFilesController : ApiController
{
	[HttpPost]
	[FoMobileAuthorize]
	public async Task<ServiceResult<int>> Upload()
	{
		int num = 1065;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangId);
		CRMEntities db = null;
		int data = 0;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((num > 0) ? num : defLangId);
		baseInfo.SetCulture(culture);
		try
		{
			db = new CRMEntities();
			if (!base.Request.Content.IsMimeMultipartContent())
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				HttpStatusCode val = (HttpStatusCode)415;
				serviceResult.Message = ((object)(HttpStatusCode)(ref val)).ToString();
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (base.Request.Headers.Contains("token"))
			{
				string token2 = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				FoToken token = new FoCommon().GetToken(token2);
				if (token != null)
				{
					DateTime now = DateTime.Now;
					_ = Labels.MobPersonLabel;
					int fileUserId = -20;
					short fileYear1 = short.Parse(Financial.Get().Id.ToString());
					short fileMonth1 = short.Parse(now.ToString("MM", new PersianCulture()));
					string fileRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					string docTime = now.ToString("HH:mm:ss");
					string docDay = PersianDate.GetNumberWeekOfDay(now.ToString("yyyy/MM/dd", new PersianCulture())).ToString();
					_ = Messages.MobConversationErjaShow;
					string appType = Mobile.Classes.Configuration.AppType;
					_ = Mobile.Classes.Configuration.FacadeFtp;
					_ = Mobile.Classes.Configuration.PathFtp;
					_ = Mobile.Classes.Configuration.UserNameFtp;
					_ = Mobile.Classes.Configuration.PasswordFtp;
					_ = Mobile.Classes.Configuration.UsePassiveFtp;
					string text = Mobile.Classes.Configuration.HostTempFilesPath + "/" + Mobile.Classes.Configuration.UploadFileDirectoryPath;
					string text2 = HttpContext.Current.Server.MapPath(text);
					if (!System.IO.Directory.Exists(text2))
					{
						System.IO.Directory.CreateDirectory(text2);
						CRM.General.IO.Directory.SetFullControlForEveryOne(text2);
					}
					string pathDirPrivateUser = HttpContext.Current.Server.MapPath(text + fileUserId + "/");
					if (!System.IO.Directory.Exists(pathDirPrivateUser))
					{
						System.IO.Directory.CreateDirectory(pathDirPrivateUser);
						CRM.General.IO.Directory.SetFullControlForEveryOne(pathDirPrivateUser);
					}
					pathDirPrivateUser = HttpContext.Current.Server.MapPath(text + fileUserId + "/" + now.ToString("yyyyMMddHHmmss", new CultureInfo("en-US")) + "/");
					if (!System.IO.Directory.Exists(pathDirPrivateUser))
					{
						System.IO.Directory.CreateDirectory(pathDirPrivateUser);
						CRM.General.IO.Directory.SetFullControlForEveryOne(pathDirPrivateUser);
					}
					CustomMultipartFormDataStreamProvider provider = new CustomMultipartFormDataStreamProvider(pathDirPrivateUser);
					new List<string>();
					try
					{
						await base.Request.Content.ReadAsMultipartAsync(provider);
						foreach (MultipartFileData fileDatum in provider.FileData)
						{
							if (System.IO.File.Exists(fileDatum.LocalFileName))
							{
								int? num2 = null;
								int? num3 = null;
								int? num4 = null;
								int? num5 = null;
								string text3 = null;
								_ = Mobile.Classes.Configuration.MainDirectoryPath;
								string fileName = Path.GetFileName(fileDatum.LocalFileName);
								string[] allKeys = provider.FormData.AllKeys;
								foreach (string text4 in allKeys)
								{
									string[] values = provider.FormData.GetValues(text4);
									foreach (string text5 in values)
									{
										switch (text4)
										{
										case "CompanyPersonId":
											num2 = ((!string.IsNullOrEmpty(text5)) ? new int?(int.Parse(text5)) : null);
											break;
										case "ProjectId":
											num3 = ((!string.IsNullOrEmpty(text5)) ? new int?(int.Parse(text5)) : null);
											break;
										case "ConversationId":
											num4 = ((!string.IsNullOrEmpty(text5)) ? new int?(int.Parse(text5)) : null);
											break;
										case "CenterId":
											num5 = ((!string.IsNullOrEmpty(text5)) ? new int?(int.Parse(text5)) : null);
											break;
										case "FileDesc":
											if (!string.IsNullOrEmpty(text5))
											{
												text3 = text5;
											}
											break;
										}
									}
								}
								List<MobspSelectLanguages_Result> list = Enumerable.ToList<MobspSelectLanguages_Result>((IEnumerable<MobspSelectLanguages_Result>)db.MobspSelectLanguages());
								string fileTitle_lang = "";
								List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
								string text6 = "";
								List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
								foreach (MobspSelectLanguages_Result item in Enumerable.ToList<MobspSelectLanguages_Result>(Enumerable.Where<MobspSelectLanguages_Result>((IEnumerable<MobspSelectLanguages_Result>)list, (Func<MobspSelectLanguages_Result, bool>)((MobspSelectLanguages_Result c) => c.LanguageID != defLangId))))
								{
									list2.Add(new CommonMultiLanguageViewModel
									{
										Value = fileName,
										LanguageId = item.LanguageID
									});
									list3.Add(new CommonMultiLanguageViewModel
									{
										Value = text3,
										LanguageId = item.LanguageID
									});
								}
								if (list2 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2))
								{
									fileTitle_lang = JsonConvert.SerializeObject(list2);
								}
								CRMEntities cRMEntities = db;
								int? fileDirectoryId = -1;
								int? fileDirectoryTypeId = -100;
								int? masterId = token.CompanyId;
								int? detailId = num2;
								int? subDetailId = num3;
								string folderName = token.CompanyId.ToString();
								int? userId = fileUserId;
								short? year = fileYear1;
								short? month = fileMonth1;
								int? typeOprObjectId = num4;
								int? languageID = defLangId;
								bool? fileFOCmpCanSee = true;
								int? centerId = num5;
								string fileDesc = text3;
								string fileDesc_lang = text6;
								int? num6 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.FOMobspInsertCrmFilesDirectory(fileDirectoryId, fileDirectoryTypeId, masterId, detailId, subDetailId, fileName, folderName, null, null, null, userId, year, month, fileRegisterDatePersian, docDay, docTime, typeOprObjectId, appType, languageID, null, null, null, fileFOCmpCanSee, centerId, fileDesc, fileTitle_lang, fileDesc_lang, defLangId));
								int result = 0;
								if (num6.HasValue && num6 > 0)
								{
									int.TryParse(num6.ToString(), out result);
								}
								if (result > 0)
								{
									FacadeFTP facadeFTP = new FacadeFTP(Mobile.Classes.Configuration.FacadeFtp);
									string mainDirectoryPath = Mobile.Classes.Configuration.MainDirectoryPath;
									string text7 = token.CompanyId.ToString();
									bool flag = facadeFTP.ExistsDirectoryInFtp(Mobile.Classes.Configuration.PathFtp, Mobile.Classes.Configuration.UserNameFtp, Mobile.Classes.Configuration.PasswordFtp, mainDirectoryPath, text7, Mobile.Classes.Configuration.UsePassiveFtp);
									if (!flag)
									{
										flag = facadeFTP.CreateDirectoryInFtp(Mobile.Classes.Configuration.PathFtp, Mobile.Classes.Configuration.UserNameFtp, Mobile.Classes.Configuration.PasswordFtp, mainDirectoryPath, text7, Mobile.Classes.Configuration.UsePassiveFtp);
									}
									if (flag)
									{
										mainDirectoryPath = mainDirectoryPath + token.CompanyId + "/";
										string[] array = fileName.Split(new char[1] { '.' });
										string text8 = token.CompanyId + "-" + result + "." + array[^1];
										mainDirectoryPath += text8;
										string localFileName = fileDatum.LocalFileName;
										if (localFileName != "")
										{
											facadeFTP.UploadFtpFormTable(Mobile.Classes.Configuration.PathFtp, Mobile.Classes.Configuration.UserNameFtp, Mobile.Classes.Configuration.PasswordFtp, mainDirectoryPath, localFileName, Mobile.Classes.Configuration.UsePassiveFtp);
										}
										CRMEntities cRMEntities2 = db;
										int? fileDirectoryId2 = result;
										int? fileDirectoryTypeId2 = -100;
										int? masterId2 = token.CompanyId;
										int? detailId2 = num2;
										int? subDetailId2 = num3;
										string folderName2 = token.CompanyId.ToString();
										string filePath = mainDirectoryPath;
										int? userId2 = fileUserId;
										short? year2 = fileYear1;
										short? month2 = fileMonth1;
										int? typeOprObjectId2 = num4;
										int? languageID2 = defLangId;
										bool? fileFOCmpCanSee2 = true;
										int? centerId2 = num5;
										string fileDesc2 = text3;
										fileDesc_lang = text6;
										Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities2.FOMobspInsertCrmFilesDirectory(fileDirectoryId2, fileDirectoryTypeId2, masterId2, detailId2, subDetailId2, fileName, folderName2, text8, filePath, null, userId2, year2, month2, fileRegisterDatePersian, docDay, docTime, typeOprObjectId2, appType, languageID2, null, null, null, fileFOCmpCanSee2, centerId2, fileDesc2, fileTitle_lang, fileDesc_lang, defLangId));
										data = result;
										message = Messages.MobMsgSuccessAction;
										status = ServiceResultStatus.Success;
									}
									else
									{
										Exception e = new Exception(Messages.FOMsgErrorCreateFolderInFtp + " -  hostname: " + Mobile.Classes.Configuration.PathFtp + " ,username: " + Mobile.Classes.Configuration.UserNameFtp + " ,destination: " + mainDirectoryPath + " ,directoryName: " + text7);
										ErrorSignal.FromCurrentContext().Raise(e);
										message = Messages.frmErrorInSendingFile + "<br>";
										try
										{
											db.FOMobspDeleteCrmFilesDirectory(result);
										}
										catch (Exception e2)
										{
											ErrorSignal.FromCurrentContext().Raise(e2);
										}
									}
								}
								else
								{
									data = 0;
									message = Messages.MobMsgErrorDoneOperation;
									status = ServiceResultStatus.Error;
								}
							}
							else
							{
								message = Messages.MobMsgErrorFileNotExist;
								data = 0;
								status = ServiceResultStatus.Error;
							}
						}
					}
					catch (Exception ex)
					{
						message = Messages.MobMsgErrorDoneOperation + " (" + ex.Message + ")";
						data = 0;
						status = ServiceResultStatus.Error;
						ErrorSignal.FromCurrentContext().Raise(ex);
					}
					finally
					{
						db?.Dispose();
						if (!string.IsNullOrEmpty(pathDirPrivateUser) && System.IO.Directory.Exists(pathDirPrivateUser))
						{
							DirectoryInfo directoryInfo = new DirectoryInfo(pathDirPrivateUser);
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
							if (System.IO.Directory.Exists(pathDirPrivateUser))
							{
								System.IO.Directory.Delete(pathDirPrivateUser);
							}
						}
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = 0;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = 0;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception ex2)
		{
			message = Messages.MobMsgErrorDoneOperation + " (" + ex2.Message + ")";
			data = 0;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex2);
		}
		finally
		{
			db?.Dispose();
		}
		return new ServiceResult<int>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[FoMobileAuthorize]
	public ServiceResult<string> GetLinkDownload(int fileId)
	{
		int num = 1065;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		string text = null;
		string text2 = "";
		ServiceResultStatus serviceResultStatus = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((num > 0) ? num : result);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				FoToken token2 = new FoCommon().GetToken(token);
				if (token2 != null)
				{
					try
					{
						if (fileId > 0)
						{
							FoFiles foFiles = new FoFiles();
							string text3 = ((fileId > 0) ? foFiles.GetFilePath(fileId) : "");
							if (string.IsNullOrEmpty(text3))
							{
								text2 = Messages.MobMsgErrorFileNotExist;
								text = null;
								serviceResultStatus = ServiceResultStatus.Error;
							}
							else
							{
								FoPrintLog.InsertPrintLog(token2.CompanyId, fileId, 550, 3);
								text = text3;
								text2 = Messages.MobMsgSuccessAction;
								serviceResultStatus = ServiceResultStatus.Success;
							}
						}
						else
						{
							text2 = Messages.MobMsgErrorFileNotExist;
							text = null;
							serviceResultStatus = ServiceResultStatus.Error;
						}
					}
					catch (Exception e)
					{
						text2 = Messages.MobMsgErrorDoneOperation;
						text = null;
						serviceResultStatus = ServiceResultStatus.Error;
						ErrorSignal.FromCurrentContext().Raise(e);
					}
				}
				else
				{
					text2 = Messages.MobMsgErrorAccessingToken;
					text = null;
					serviceResultStatus = ServiceResultStatus.Error;
				}
			}
			else
			{
				text2 = Messages.MobMsgErrorAccessingToken;
				text = null;
				serviceResultStatus = ServiceResultStatus.Error;
			}
		}
		catch (Exception e2)
		{
			text2 = Messages.MobMsgErrorDoneOperation;
			text = null;
			serviceResultStatus = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return new ServiceResult<string>
		{
			Message = text2,
			Data = text,
			Status = serviceResultStatus
		};
	}

	[HttpPost]
	[FoMobileAuthorize]
	public async Task<ServiceResult<int>> UploadDyForm()
	{
		int num = 1065;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangId);
		CRMEntities db = null;
		int data = 0;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((num > 0) ? num : defLangId);
		baseInfo.SetCulture(culture);
		try
		{
			db = new CRMEntities();
			if (!base.Request.Content.IsMimeMultipartContent())
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				HttpStatusCode val = (HttpStatusCode)415;
				serviceResult.Message = ((object)(HttpStatusCode)(ref val)).ToString();
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new FoCommon().GetToken(token) != null)
				{
					DateTime now = DateTime.Now;
					_ = Labels.MobPersonLabel;
					int fileUserId = -20;
					short fileYear1 = short.Parse(Financial.Get().Id.ToString());
					short fileMonth1 = short.Parse(now.ToString("MM", new PersianCulture()));
					string fileRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					string docTime = now.ToString("HH:mm:ss");
					string docDay = PersianDate.GetNumberWeekOfDay(now.ToString("yyyy/MM/dd", new PersianCulture())).ToString();
					_ = Messages.MobConversationErjaShow;
					string appType = Mobile.Classes.Configuration.AppType;
					_ = Mobile.Classes.Configuration.FacadeFtp;
					_ = Mobile.Classes.Configuration.PathFtp;
					_ = Mobile.Classes.Configuration.UserNameFtp;
					_ = Mobile.Classes.Configuration.PasswordFtp;
					_ = Mobile.Classes.Configuration.UsePassiveFtp;
					string text = Mobile.Classes.Configuration.HostTempFilesPath + "/" + Mobile.Classes.Configuration.UploadFileDirectoryPath;
					string text2 = HttpContext.Current.Server.MapPath(text);
					if (!System.IO.Directory.Exists(text2))
					{
						System.IO.Directory.CreateDirectory(text2);
						CRM.General.IO.Directory.SetFullControlForEveryOne(text2);
					}
					string pathDirPrivateUser = HttpContext.Current.Server.MapPath(text + fileUserId + "/");
					if (!System.IO.Directory.Exists(pathDirPrivateUser))
					{
						System.IO.Directory.CreateDirectory(pathDirPrivateUser);
						CRM.General.IO.Directory.SetFullControlForEveryOne(pathDirPrivateUser);
					}
					pathDirPrivateUser = HttpContext.Current.Server.MapPath(text + fileUserId + "/" + now.ToString("yyyyMMddHHmmss", new CultureInfo("en-US")) + "/");
					if (!System.IO.Directory.Exists(pathDirPrivateUser))
					{
						System.IO.Directory.CreateDirectory(pathDirPrivateUser);
						CRM.General.IO.Directory.SetFullControlForEveryOne(pathDirPrivateUser);
					}
					CustomMultipartFormDataStreamProvider provider = new CustomMultipartFormDataStreamProvider(pathDirPrivateUser);
					new List<string>();
					try
					{
						await base.Request.Content.ReadAsMultipartAsync(provider);
						foreach (MultipartFileData fileDatum in provider.FileData)
						{
							if (System.IO.File.Exists(fileDatum.LocalFileName))
							{
								int? num2 = null;
								int? num3 = null;
								int? num4 = null;
								int? num5 = null;
								int? num6 = null;
								int? num7 = null;
								string text3 = null;
								_ = Mobile.Classes.Configuration.MainDirectoryPath;
								string fileName = Path.GetFileName(fileDatum.LocalFileName);
								string[] allKeys = provider.FormData.AllKeys;
								foreach (string text4 in allKeys)
								{
									string[] values = provider.FormData.GetValues(text4);
									foreach (string text5 in values)
									{
										switch (text4)
										{
										case "CompanyId":
											num2 = ((!string.IsNullOrEmpty(text5)) ? new int?(int.Parse(text5)) : null);
											break;
										case "CompanyPersonId":
											num3 = ((!string.IsNullOrEmpty(text5)) ? new int?(int.Parse(text5)) : null);
											break;
										case "ProjectId":
											num4 = ((!string.IsNullOrEmpty(text5)) ? new int?(int.Parse(text5)) : null);
											break;
										case "MasterValId":
											num5 = ((!string.IsNullOrEmpty(text5)) ? new int?(int.Parse(text5)) : null);
											break;
										case "FormId":
											num6 = ((!string.IsNullOrEmpty(text5)) ? new int?(int.Parse(text5)) : null);
											break;
										case "CenterId":
											num7 = ((!string.IsNullOrEmpty(text5)) ? new int?(int.Parse(text5)) : null);
											break;
										case "FileDesc":
											if (!string.IsNullOrEmpty(text5))
											{
												text3 = text5;
											}
											break;
										}
									}
								}
								string folderName = (num2.HasValue ? num2.ToString() : num6.ToString());
								List<MobspSelectLanguages_Result> list = Enumerable.ToList<MobspSelectLanguages_Result>((IEnumerable<MobspSelectLanguages_Result>)db.MobspSelectLanguages());
								string fileTitle_lang = "";
								List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
								string text6 = "";
								List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
								foreach (MobspSelectLanguages_Result item in Enumerable.ToList<MobspSelectLanguages_Result>(Enumerable.Where<MobspSelectLanguages_Result>((IEnumerable<MobspSelectLanguages_Result>)list, (Func<MobspSelectLanguages_Result, bool>)((MobspSelectLanguages_Result c) => c.LanguageID != defLangId))))
								{
									list2.Add(new CommonMultiLanguageViewModel
									{
										Value = fileName,
										LanguageId = item.LanguageID
									});
									list3.Add(new CommonMultiLanguageViewModel
									{
										Value = text3,
										LanguageId = item.LanguageID
									});
								}
								if (list2 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2))
								{
									fileTitle_lang = JsonConvert.SerializeObject(list2);
								}
								CRMEntities cRMEntities = db;
								int? fileDirectoryId = -1;
								int? fileDirectoryTypeId = -60;
								int? masterId = num2;
								int? detailId = num3;
								int? subDetailId = num4;
								int? userId = fileUserId;
								short? year = fileYear1;
								short? month = fileMonth1;
								int? typeOprObjectId = num5;
								int? languageID = defLangId;
								int? typeOprObjectIdI = num6;
								bool? fileFOCmpCanSee = true;
								int? centerId = num7;
								string fileDesc = text3;
								string fileDesc_lang = text6;
								int? num8 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.FOMobspInsertCrmFilesDirectory(fileDirectoryId, fileDirectoryTypeId, masterId, detailId, subDetailId, fileName, folderName, null, null, null, userId, year, month, fileRegisterDatePersian, docDay, docTime, typeOprObjectId, appType, languageID, null, typeOprObjectIdI, null, fileFOCmpCanSee, centerId, fileDesc, fileTitle_lang, fileDesc_lang, defLangId));
								int result = 0;
								if (num8.HasValue && num8 > 0)
								{
									int.TryParse(num8.ToString(), out result);
								}
								if (result > 0)
								{
									FacadeFTP facadeFTP = new FacadeFTP(Mobile.Classes.Configuration.FacadeFtp);
									string[] array = fileName.Split(new char[1] { '.' });
									string text7 = (num2.HasValue ? num2.ToString() : (Mobile.Classes.Configuration.DyDirectoryPath + num6));
									string text8 = Mobile.Classes.Configuration.MainDirectoryPath + text7 + "/";
									string text9 = text8 + (text8.EndsWith("/") ? "" : "/");
									string text10 = text9.Split(new char[1] { '/' })[^2];
									string destination = text9.Replace(text10 + "/", "");
									bool flag;
									if (!num2.HasValue)
									{
										flag = facadeFTP.ExistsDirectoryInFtp(Mobile.Classes.Configuration.PathFtp, Mobile.Classes.Configuration.UserNameFtp, Mobile.Classes.Configuration.PasswordFtp, Mobile.Classes.Configuration.MainDirectoryPath, Mobile.Classes.Configuration.DyDirectoryPath, Mobile.Classes.Configuration.UsePassiveFtp);
										if (!flag)
										{
											flag = facadeFTP.CreateDirectoryInFtp(Mobile.Classes.Configuration.PathFtp, Mobile.Classes.Configuration.UserNameFtp, Mobile.Classes.Configuration.PasswordFtp, Mobile.Classes.Configuration.MainDirectoryPath, Mobile.Classes.Configuration.DyDirectoryPath, Mobile.Classes.Configuration.UsePassiveFtp);
										}
									}
									else
									{
										flag = true;
									}
									bool flag2 = facadeFTP.ExistsDirectoryInFtp(Mobile.Classes.Configuration.PathFtp, Mobile.Classes.Configuration.UserNameFtp, Mobile.Classes.Configuration.PasswordFtp, destination, text10, Mobile.Classes.Configuration.UsePassiveFtp);
									if (!flag2)
									{
										flag2 = facadeFTP.CreateDirectoryInFtp(Mobile.Classes.Configuration.PathFtp, Mobile.Classes.Configuration.UserNameFtp, Mobile.Classes.Configuration.PasswordFtp, destination, text10, Mobile.Classes.Configuration.UsePassiveFtp);
									}
									if (flag2 && flag)
									{
										string text11 = num5 + "-" + result + "." + array[^1];
										text9 += text11;
										string localFileName = fileDatum.LocalFileName;
										if (localFileName != "")
										{
											facadeFTP.UploadFtpFormTable(Mobile.Classes.Configuration.PathFtp, Mobile.Classes.Configuration.UserNameFtp, Mobile.Classes.Configuration.PasswordFtp, text9, localFileName, Mobile.Classes.Configuration.UsePassiveFtp);
										}
										CRMEntities cRMEntities2 = db;
										int? fileDirectoryId2 = result;
										int? fileDirectoryTypeId2 = -60;
										int? masterId2 = num2;
										int? detailId2 = num3;
										int? subDetailId2 = num4;
										string filePath = text9;
										int? userId2 = fileUserId;
										short? year2 = fileYear1;
										short? month2 = fileMonth1;
										int? typeOprObjectId2 = num5;
										int? languageID2 = defLangId;
										int? typeOprObjectIdI2 = num6;
										bool? fileFOCmpCanSee2 = true;
										int? centerId2 = num7;
										string fileDesc2 = text3;
										fileDesc_lang = text6;
										Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities2.FOMobspInsertCrmFilesDirectory(fileDirectoryId2, fileDirectoryTypeId2, masterId2, detailId2, subDetailId2, fileName, folderName, text11, filePath, null, userId2, year2, month2, fileRegisterDatePersian, docDay, docTime, typeOprObjectId2, appType, languageID2, null, typeOprObjectIdI2, null, fileFOCmpCanSee2, centerId2, fileDesc2, fileTitle_lang, fileDesc_lang, defLangId));
										data = result;
										message = Messages.MobMsgSuccessAction;
										status = ServiceResultStatus.Success;
									}
									else
									{
										Exception e = new Exception(Messages.FOMsgErrorCreateFolderInFtp + " -  hostname: " + Mobile.Classes.Configuration.PathFtp + " ,username: " + Mobile.Classes.Configuration.UserNameFtp + " ,destination: " + text9 + " ,directoryName: " + text10);
										ErrorSignal.FromCurrentContext().Raise(e);
										message = Messages.frmErrorInSendingFile + "<br>";
										try
										{
											db.FOMobspDeleteCrmFilesDirectory(result);
										}
										catch (Exception e2)
										{
											ErrorSignal.FromCurrentContext().Raise(e2);
										}
									}
								}
								else
								{
									data = 0;
									message = Messages.MobMsgErrorDoneOperation;
									status = ServiceResultStatus.Error;
								}
							}
							else
							{
								message = Messages.MobMsgErrorFileNotExist;
								data = 0;
								status = ServiceResultStatus.Error;
							}
						}
					}
					catch (Exception ex)
					{
						message = Messages.MobMsgErrorDoneOperation + " (" + ex.Message + ")";
						data = 0;
						status = ServiceResultStatus.Error;
						ErrorSignal.FromCurrentContext().Raise(ex);
					}
					finally
					{
						db?.Dispose();
						if (!string.IsNullOrEmpty(pathDirPrivateUser) && System.IO.Directory.Exists(pathDirPrivateUser))
						{
							DirectoryInfo directoryInfo = new DirectoryInfo(pathDirPrivateUser);
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
							if (System.IO.Directory.Exists(pathDirPrivateUser))
							{
								System.IO.Directory.Delete(pathDirPrivateUser);
							}
						}
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = 0;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = 0;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception ex2)
		{
			message = Messages.MobMsgErrorDoneOperation + " (" + ex2.Message + ")";
			data = 0;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex2);
		}
		finally
		{
			db?.Dispose();
		}
		return new ServiceResult<int>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[FoMobileAuthorize]
	public ServiceResult<string> DeleteDyFormFilesDirectory(int fileId, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		string data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new FoCommon().GetToken(token) != null)
				{
					string text = "";
					cRMEntities = new CRMEntities();
					FOMobspSelectCrmFilesDirectoryWithId_Result fOMobspSelectCrmFilesDirectoryWithId_Result = Enumerable.FirstOrDefault<FOMobspSelectCrmFilesDirectoryWithId_Result>((IEnumerable<FOMobspSelectCrmFilesDirectoryWithId_Result>)cRMEntities.FOMobspSelectCrmFilesDirectoryWithId(fileId, result, result2));
					if (fOMobspSelectCrmFilesDirectoryWithId_Result != null)
					{
						string text2 = fOMobspSelectCrmFilesDirectoryWithId_Result.FilePath.ToLower().Replace(Mobile.Classes.Configuration.PathFtp.ToLower(), "");
						text2 = ((!text2.Contains("/" + Mobile.Classes.Configuration.IntmsgDirectoryPath.ToLower().Replace("/", "") + "/") && !text2.Contains("\\" + Mobile.Classes.Configuration.IntmsgDirectoryPath.ToLower().Replace("/", "") + "\\")) ? ((!text2.Contains("/" + Mobile.Classes.Configuration.KnlgTDirectoryPath.ToLower().Replace("/", "") + "/") && !text2.Contains("\\" + Mobile.Classes.Configuration.KnlgTDirectoryPath.ToLower().Replace("/", "") + "\\")) ? ((!text2.Contains("/" + Mobile.Classes.Configuration.DyDirectoryPath.ToLower().Replace("/", "") + "/") && !text2.Contains("\\" + Mobile.Classes.Configuration.DyDirectoryPath.ToLower().Replace("/", "") + "\\")) ? (Mobile.Classes.Configuration.MainDirectoryPath + fOMobspSelectCrmFilesDirectoryWithId_Result.FolderName + "/" + fOMobspSelectCrmFilesDirectoryWithId_Result.FileName) : (Mobile.Classes.Configuration.MainDirectoryPath + Mobile.Classes.Configuration.DyDirectoryPath + fOMobspSelectCrmFilesDirectoryWithId_Result.FolderName + "/" + fOMobspSelectCrmFilesDirectoryWithId_Result.FileName)) : (Mobile.Classes.Configuration.MainDirectoryPath + Mobile.Classes.Configuration.KnlgTDirectoryPath + fOMobspSelectCrmFilesDirectoryWithId_Result.FolderName + "/" + fOMobspSelectCrmFilesDirectoryWithId_Result.FileName)) : (Mobile.Classes.Configuration.MainDirectoryPath + Mobile.Classes.Configuration.IntmsgDirectoryPath + fOMobspSelectCrmFilesDirectoryWithId_Result.FolderName + "/" + fOMobspSelectCrmFilesDirectoryWithId_Result.FileName));
						FacadeFTP facadeFTP = new FacadeFTP(Mobile.Classes.Configuration.FacadeFtp);
						string destination = text2;
						if (facadeFTP.Delete(Mobile.Classes.Configuration.PathFtp, Mobile.Classes.Configuration.UserNameFtp, Mobile.Classes.Configuration.PasswordFtp, fOMobspSelectCrmFilesDirectoryWithId_Result.FileName, destination, Mobile.Classes.Configuration.UsePassiveFtp))
						{
							cRMEntities.FOMobspDeleteCrmFilesDirectory(fileId);
							fOMobspSelectCrmFilesDirectoryWithId_Result = Enumerable.FirstOrDefault<FOMobspSelectCrmFilesDirectoryWithId_Result>((IEnumerable<FOMobspSelectCrmFilesDirectoryWithId_Result>)cRMEntities.FOMobspSelectCrmFilesDirectoryWithId(fileId, num, result2));
							text = ((fOMobspSelectCrmFilesDirectoryWithId_Result == null) ? "" : Messages.FOMsgErrorRedundancy);
						}
						else
						{
							text = Messages.FOMsgErrorDoneOperation;
						}
					}
					else
					{
						text = Messages.FOMsgErrorNotFound;
					}
					if (string.IsNullOrEmpty(text))
					{
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					else
					{
						message = text;
						status = ServiceResultStatus.Error;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[FoMobileAuthorize]
	public ServiceResult<int> DeleteFile(int fileId, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		int data = 0;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new FoCommon().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					if (fileId > 0)
					{
						FOMobspSelectCrmFilesDirectoryWithId_Result fOMobspSelectCrmFilesDirectoryWithId_Result = Enumerable.FirstOrDefault<FOMobspSelectCrmFilesDirectoryWithId_Result>((IEnumerable<FOMobspSelectCrmFilesDirectoryWithId_Result>)cRMEntities.FOMobspSelectCrmFilesDirectoryWithId(fileId, num, result2));
						if (fOMobspSelectCrmFilesDirectoryWithId_Result == null)
						{
							return new ServiceResult<int>
							{
								Message = Messages.MobMsgErrorFileNotExist,
								Data = fileId,
								Status = ServiceResultStatus.Error
							};
						}
						string text = fOMobspSelectCrmFilesDirectoryWithId_Result.FilePath.ToLower().Replace(Mobile.Classes.Configuration.PathFtp.ToLower(), "");
						text = ((!text.Contains("/" + Mobile.Classes.Configuration.IntmsgDirectoryPath.ToLower().Replace("/", "") + "/") && !text.Contains("\\" + Mobile.Classes.Configuration.IntmsgDirectoryPath.ToLower().Replace("/", "") + "\\")) ? ((!text.Contains("/" + Mobile.Classes.Configuration.KnlgTDirectoryPath.ToLower().Replace("/", "") + "/") && !text.Contains("\\" + Mobile.Classes.Configuration.KnlgTDirectoryPath.ToLower().Replace("/", "") + "\\")) ? ((!text.Contains("/" + Mobile.Classes.Configuration.DyDirectoryPath.ToLower().Replace("/", "") + "/") && !text.Contains("\\" + Mobile.Classes.Configuration.DyDirectoryPath.ToLower().Replace("/", "") + "\\")) ? (Mobile.Classes.Configuration.MainDirectoryPath + fOMobspSelectCrmFilesDirectoryWithId_Result.FolderName + "/" + fOMobspSelectCrmFilesDirectoryWithId_Result.FileName) : (Mobile.Classes.Configuration.MainDirectoryPath + Mobile.Classes.Configuration.DyDirectoryPath + fOMobspSelectCrmFilesDirectoryWithId_Result.FolderName + "/" + fOMobspSelectCrmFilesDirectoryWithId_Result.FileName)) : (Mobile.Classes.Configuration.MainDirectoryPath + Mobile.Classes.Configuration.KnlgTDirectoryPath + fOMobspSelectCrmFilesDirectoryWithId_Result.FolderName + "/" + fOMobspSelectCrmFilesDirectoryWithId_Result.FileName)) : (Mobile.Classes.Configuration.MainDirectoryPath + Mobile.Classes.Configuration.IntmsgDirectoryPath + fOMobspSelectCrmFilesDirectoryWithId_Result.FolderName + "/" + fOMobspSelectCrmFilesDirectoryWithId_Result.FileName));
						FacadeFTP facadeFTP = new FacadeFTP(Mobile.Classes.Configuration.FacadeFtp);
						string destination = text;
						if (facadeFTP.Delete(Mobile.Classes.Configuration.PathFtp, Mobile.Classes.Configuration.UserNameFtp, Mobile.Classes.Configuration.PasswordFtp, fOMobspSelectCrmFilesDirectoryWithId_Result.FileName, destination, Mobile.Classes.Configuration.UsePassiveFtp))
						{
							cRMEntities.FOMobspDeleteCrmFilesDirectory(fileId);
							fOMobspSelectCrmFilesDirectoryWithId_Result = Enumerable.FirstOrDefault<FOMobspSelectCrmFilesDirectoryWithId_Result>((IEnumerable<FOMobspSelectCrmFilesDirectoryWithId_Result>)cRMEntities.FOMobspSelectCrmFilesDirectoryWithId(fileId, num, result2));
							if (fOMobspSelectCrmFilesDirectoryWithId_Result == null)
							{
								data = fileId;
								message = Messages.MobMsgSuccessAction;
								status = ServiceResultStatus.Success;
							}
							else
							{
								data = fileId;
								message = Messages.MobMsgErrorDoneOperation;
								status = ServiceResultStatus.Fail;
							}
						}
						else
						{
							data = fileId;
							message = Messages.MobMsgErrorInDeleteFileFromFtp;
							status = ServiceResultStatus.Fail;
						}
					}
					else
					{
						message = Messages.MobMsgErrorFileNotExist;
						data = fileId;
						status = ServiceResultStatus.Error;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = fileId;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = fileId;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = fileId;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<int>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[FoMobileAuthorize]
	public async Task<ServiceResult<int>> AddFileToPay()
	{
		int num = 1065;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangId);
		CRMEntities db = null;
		int data = 0;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((num > 0) ? num : defLangId);
		baseInfo.SetCulture(culture);
		try
		{
			db = new CRMEntities();
			if (!base.Request.Content.IsMimeMultipartContent())
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				HttpStatusCode val = (HttpStatusCode)415;
				serviceResult.Message = ((object)(HttpStatusCode)(ref val)).ToString();
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (base.Request.Headers.Contains("token"))
			{
				string token2 = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				FoToken token = new FoCommon().GetToken(token2);
				if (token != null)
				{
					DateTime now = DateTime.Now;
					_ = Labels.MobPersonLabel;
					int fileUserId = -20;
					short fileYear1 = short.Parse(Financial.Get().Id.ToString());
					short fileMonth1 = short.Parse(now.ToString("MM", new PersianCulture()));
					string fileRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					string docTime = now.ToString("HH:mm:ss");
					string docDay = PersianDate.GetNumberWeekOfDay(now.ToString("yyyy/MM/dd", new PersianCulture())).ToString();
					_ = Messages.MobConversationErjaShow;
					string appType = Mobile.Classes.Configuration.AppType;
					_ = Mobile.Classes.Configuration.FacadeFtp;
					_ = Mobile.Classes.Configuration.PathFtp;
					_ = Mobile.Classes.Configuration.UserNameFtp;
					_ = Mobile.Classes.Configuration.PasswordFtp;
					_ = Mobile.Classes.Configuration.UsePassiveFtp;
					string text = Mobile.Classes.Configuration.HostTempFilesPath + "/" + Mobile.Classes.Configuration.UploadFileDirectoryPath;
					string text2 = HttpContext.Current.Server.MapPath(text);
					if (!System.IO.Directory.Exists(text2))
					{
						System.IO.Directory.CreateDirectory(text2);
						CRM.General.IO.Directory.SetFullControlForEveryOne(text2);
					}
					string pathDirPrivateUser = HttpContext.Current.Server.MapPath(text + fileUserId + "/");
					if (!System.IO.Directory.Exists(pathDirPrivateUser))
					{
						System.IO.Directory.CreateDirectory(pathDirPrivateUser);
						CRM.General.IO.Directory.SetFullControlForEveryOne(pathDirPrivateUser);
					}
					pathDirPrivateUser = HttpContext.Current.Server.MapPath(text + fileUserId + "/" + now.ToString("yyyyMMddHHmmss", new CultureInfo("en-US")) + "/");
					if (!System.IO.Directory.Exists(pathDirPrivateUser))
					{
						System.IO.Directory.CreateDirectory(pathDirPrivateUser);
						CRM.General.IO.Directory.SetFullControlForEveryOne(pathDirPrivateUser);
					}
					CustomMultipartFormDataStreamProvider provider = new CustomMultipartFormDataStreamProvider(pathDirPrivateUser);
					new List<string>();
					try
					{
						await base.Request.Content.ReadAsMultipartAsync(provider);
						foreach (MultipartFileData fileDatum in provider.FileData)
						{
							if (System.IO.File.Exists(fileDatum.LocalFileName))
							{
								int? num2 = null;
								int? num3 = null;
								int? num4 = null;
								int? num5 = null;
								int? num6 = null;
								string text3 = null;
								_ = Mobile.Classes.Configuration.MainDirectoryPath;
								string fileName = Path.GetFileName(fileDatum.LocalFileName);
								string[] allKeys = provider.FormData.AllKeys;
								foreach (string text4 in allKeys)
								{
									string[] values = provider.FormData.GetValues(text4);
									foreach (string text5 in values)
									{
										switch (text4)
										{
										case "FileTypeId":
											num2 = ((!string.IsNullOrEmpty(text5)) ? new int?(int.Parse(text5)) : null);
											break;
										case "ProjectId":
											num3 = ((!string.IsNullOrEmpty(text5)) ? new int?(int.Parse(text5)) : null);
											break;
										case "PayId":
											num4 = ((!string.IsNullOrEmpty(text5)) ? new int?(int.Parse(text5)) : null);
											break;
										case "OrdId":
											num5 = ((!string.IsNullOrEmpty(text5)) ? new int?(int.Parse(text5)) : null);
											break;
										case "CenterId":
											num6 = ((!string.IsNullOrEmpty(text5)) ? new int?(int.Parse(text5)) : null);
											break;
										case "FileDesc":
											if (!string.IsNullOrEmpty(text5))
											{
												text3 = text5;
											}
											break;
										}
									}
								}
								List<MobspSelectLanguages_Result> list = Enumerable.ToList<MobspSelectLanguages_Result>((IEnumerable<MobspSelectLanguages_Result>)db.MobspSelectLanguages());
								string fileTitle_lang = "";
								List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
								string text6 = "";
								List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
								foreach (MobspSelectLanguages_Result item in Enumerable.ToList<MobspSelectLanguages_Result>(Enumerable.Where<MobspSelectLanguages_Result>((IEnumerable<MobspSelectLanguages_Result>)list, (Func<MobspSelectLanguages_Result, bool>)((MobspSelectLanguages_Result c) => c.LanguageID != defLangId))))
								{
									list2.Add(new CommonMultiLanguageViewModel
									{
										Value = fileName,
										LanguageId = item.LanguageID
									});
									list3.Add(new CommonMultiLanguageViewModel
									{
										Value = text3,
										LanguageId = item.LanguageID
									});
								}
								if (list2 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2))
								{
									fileTitle_lang = JsonConvert.SerializeObject(list2);
								}
								CRMEntities cRMEntities = db;
								int? fileDirectoryId = -1;
								int? fileDirectoryTypeId = num2;
								int? masterId = token.CompanyId;
								int? subDetailId = num3;
								string folderName = token.CompanyId.ToString();
								int? userId = fileUserId;
								short? year = fileYear1;
								short? month = fileMonth1;
								int? typeOprObjectId = num5;
								int? languageID = defLangId;
								int? typeOprObjectIdI = num4;
								bool? fileFOCmpCanSee = true;
								int? centerId = num6;
								string fileDesc = text3;
								string fileDesc_lang = text6;
								int? num7 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.FOMobspInsertCrmFilesDirectory(fileDirectoryId, fileDirectoryTypeId, masterId, null, subDetailId, fileName, folderName, null, null, null, userId, year, month, fileRegisterDatePersian, docDay, docTime, typeOprObjectId, appType, languageID, null, typeOprObjectIdI, null, fileFOCmpCanSee, centerId, fileDesc, fileTitle_lang, fileDesc_lang, defLangId));
								int result = 0;
								if (num7.HasValue && num7 > 0)
								{
									int.TryParse(num7.ToString(), out result);
								}
								if (result > 0)
								{
									FacadeFTP facadeFTP = new FacadeFTP(Mobile.Classes.Configuration.FacadeFtp);
									string mainDirectoryPath = Mobile.Classes.Configuration.MainDirectoryPath;
									string text7 = token.CompanyId.ToString();
									bool flag = facadeFTP.ExistsDirectoryInFtp(Mobile.Classes.Configuration.PathFtp, Mobile.Classes.Configuration.UserNameFtp, Mobile.Classes.Configuration.PasswordFtp, mainDirectoryPath, text7, Mobile.Classes.Configuration.UsePassiveFtp);
									if (!flag)
									{
										flag = facadeFTP.CreateDirectoryInFtp(Mobile.Classes.Configuration.PathFtp, Mobile.Classes.Configuration.UserNameFtp, Mobile.Classes.Configuration.PasswordFtp, mainDirectoryPath, text7, Mobile.Classes.Configuration.UsePassiveFtp);
									}
									if (flag)
									{
										mainDirectoryPath = mainDirectoryPath + token.CompanyId + "/";
										string[] array = fileName.Split(new char[1] { '.' });
										string text8 = token.CompanyId + "-" + result + "." + array[^1];
										mainDirectoryPath += text8;
										string localFileName = fileDatum.LocalFileName;
										if (localFileName != "")
										{
											facadeFTP.UploadFtpFormTable(Mobile.Classes.Configuration.PathFtp, Mobile.Classes.Configuration.UserNameFtp, Mobile.Classes.Configuration.PasswordFtp, mainDirectoryPath, localFileName, Mobile.Classes.Configuration.UsePassiveFtp);
										}
										CRMEntities cRMEntities2 = db;
										int? fileDirectoryId2 = result;
										int? fileDirectoryTypeId2 = num2;
										int? masterId2 = token.CompanyId;
										int? subDetailId2 = num3;
										string folderName2 = token.CompanyId.ToString();
										string filePath = mainDirectoryPath;
										int? userId2 = fileUserId;
										short? year2 = fileYear1;
										short? month2 = fileMonth1;
										int? typeOprObjectId2 = num5;
										int? languageID2 = defLangId;
										int? typeOprObjectIdI2 = num4;
										bool? fileFOCmpCanSee2 = true;
										int? centerId2 = num6;
										string fileDesc2 = text3;
										fileDesc_lang = text6;
										Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities2.FOMobspInsertCrmFilesDirectory(fileDirectoryId2, fileDirectoryTypeId2, masterId2, null, subDetailId2, fileName, folderName2, text8, filePath, null, userId2, year2, month2, fileRegisterDatePersian, docDay, docTime, typeOprObjectId2, appType, languageID2, null, typeOprObjectIdI2, null, fileFOCmpCanSee2, centerId2, fileDesc2, fileTitle_lang, fileDesc_lang, defLangId));
										data = result;
										message = Messages.MobMsgSuccessAction;
										status = ServiceResultStatus.Success;
									}
									else
									{
										Exception e = new Exception(Messages.FOMsgErrorCreateFolderInFtp + " -  hostname: " + Mobile.Classes.Configuration.PathFtp + " ,username: " + Mobile.Classes.Configuration.UserNameFtp + " ,destination: " + mainDirectoryPath + " ,directoryName: " + text7);
										ErrorSignal.FromCurrentContext().Raise(e);
										message = Messages.frmErrorInSendingFile + "<br>";
										try
										{
											db.FOMobspDeleteCrmFilesDirectory(result);
										}
										catch (Exception e2)
										{
											ErrorSignal.FromCurrentContext().Raise(e2);
										}
									}
								}
								else
								{
									data = 0;
									message = Messages.MobMsgErrorDoneOperation;
									status = ServiceResultStatus.Error;
								}
							}
							else
							{
								message = Messages.MobMsgErrorFileNotExist;
								data = 0;
								status = ServiceResultStatus.Error;
							}
						}
					}
					catch (Exception ex)
					{
						message = Messages.MobMsgErrorDoneOperation + " (" + ex.Message + ")";
						data = 0;
						status = ServiceResultStatus.Error;
						ErrorSignal.FromCurrentContext().Raise(ex);
					}
					finally
					{
						db?.Dispose();
						if (!string.IsNullOrEmpty(pathDirPrivateUser) && System.IO.Directory.Exists(pathDirPrivateUser))
						{
							DirectoryInfo directoryInfo = new DirectoryInfo(pathDirPrivateUser);
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
							if (System.IO.Directory.Exists(pathDirPrivateUser))
							{
								System.IO.Directory.Delete(pathDirPrivateUser);
							}
						}
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = 0;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = 0;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception ex2)
		{
			message = Messages.MobMsgErrorDoneOperation + " (" + ex2.Message + ")";
			data = 0;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex2);
		}
		finally
		{
			db?.Dispose();
		}
		return new ServiceResult<int>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[FoMobileAuthorize]
	public ServiceResult<string> GetLinkDownloadFoMobEntryLogo(int? cId = null, int? foSettingId = null)
	{
		int num = 1065;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		string text = null;
		string text2 = "";
		ServiceResultStatus serviceResultStatus = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int num2 = ((num > 0) ? num : result);
		baseInfo.SetCulture(num2);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new FoCommon().GetToken(token) != null)
				{
					try
					{
						string foMobEntryLogoPath = new FoFiles().GetFoMobEntryLogoPath(num2, result, cId, foSettingId);
						if (string.IsNullOrEmpty(foMobEntryLogoPath))
						{
							text2 = Messages.MobMsgErrorFileNotExist;
							text = null;
							serviceResultStatus = ServiceResultStatus.Error;
						}
						else
						{
							text = foMobEntryLogoPath;
							text2 = Messages.MobMsgSuccessAction;
							serviceResultStatus = ServiceResultStatus.Success;
						}
					}
					catch (Exception e)
					{
						text2 = Messages.MobMsgErrorDoneOperation;
						text = null;
						serviceResultStatus = ServiceResultStatus.Error;
						ErrorSignal.FromCurrentContext().Raise(e);
					}
				}
				else
				{
					text2 = Messages.MobMsgErrorAccessingToken;
					text = null;
					serviceResultStatus = ServiceResultStatus.Error;
				}
			}
			else
			{
				text2 = Messages.MobMsgErrorAccessingToken;
				text = null;
				serviceResultStatus = ServiceResultStatus.Error;
			}
		}
		catch (Exception e2)
		{
			text2 = Messages.MobMsgErrorDoneOperation;
			text = null;
			serviceResultStatus = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return new ServiceResult<string>
		{
			Message = text2,
			Data = text,
			Status = serviceResultStatus
		};
	}
}
