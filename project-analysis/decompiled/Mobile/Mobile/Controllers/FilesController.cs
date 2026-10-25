using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Objects;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using CRM.General.Calendar;
using CRM.General.IO;
using CRM.General.IO.FTP;
using CRM.General.Utilities;
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

public class FilesController : ApiController
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass1_0
	{
		public int? cmpId;

		public int? prsId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_0
	{
		public int cmpId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public int prsId;
	}

	[HttpPost]
	[MobileAuthorize]
	public async Task<ServiceResult<FileUploadResultViewModel>> Upload()
	{
		int LangId = 1065;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangId);
		CRMEntities db = null;
		FileUploadResultViewModel data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((LangId > 0) ? LangId : defLangId);
		baseInfo.SetCulture(culture);
		try
		{
			db = new CRMEntities();
			if (!VersionBuyer.AttachFiles && Enumerable.Any<MobspSelectCrmFilesDirectory_Result>((IEnumerable<MobspSelectCrmFilesDirectory_Result>)db.MobspSelectCrmFilesDirectory(0), (Func<MobspSelectCrmFilesDirectory_Result, bool>)((MobspSelectCrmFilesDirectory_Result c) => c.FileDirectoryID > 10)))
			{
				ServiceResult<FileUploadResultViewModel> result = new ServiceResult<FileUploadResultViewModel>
				{
					Message = Messages.MobMsgVersionBuy,
					Data = null,
					Status = ServiceResultStatus.Fail
				};
				db?.Dispose();
				return result;
			}
			if (!base.Request.Content.IsMimeMultipartContent())
			{
				ServiceResult<FileUploadResultViewModel> serviceResult = new ServiceResult<FileUploadResultViewModel>();
				HttpStatusCode val = (HttpStatusCode)415;
				serviceResult.Message = ((object)(HttpStatusCode)(ref val)).ToString();
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (base.Request.Headers.Contains("token"))
			{
				string token2 = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token = new Common().GetToken(token2);
				if (token != null)
				{
					int countError = 0;
					DateTime now = DateTime.Now;
					_ = Labels.MobPersonLabel;
					DateTime registerDate = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short year1 = short.Parse(Financial.Get().Id.ToString());
					short month1 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					_ = Messages.MobConversationErjaShow;
					string appType = Mobile.Classes.Configuration.AppType;
					string facadeFtp = Mobile.Classes.Configuration.FacadeFtp;
					string pathFtp = Mobile.Classes.Configuration.PathFtp;
					string userNameFtp = Mobile.Classes.Configuration.UserNameFtp;
					string passwordFtp = Mobile.Classes.Configuration.PasswordFtp;
					bool usePassiveFtp = Mobile.Classes.Configuration.UsePassiveFtp;
					List<MobspSelectLanguages_Result> langList = Enumerable.ToList<MobspSelectLanguages_Result>((IEnumerable<MobspSelectLanguages_Result>)db.MobspSelectLanguages());
					string text = Mobile.Classes.Configuration.HostTempFilesPath + "/" + Mobile.Classes.Configuration.UploadFileDirectoryPath;
					string text2 = HttpContext.Current.Server.MapPath(text);
					if (!System.IO.Directory.Exists(text2))
					{
						System.IO.Directory.CreateDirectory(text2);
						CRM.General.IO.Directory.SetFullControlForEveryOne(text2);
					}
					string pathDirPrivateUser = HttpContext.Current.Server.MapPath(text + token.userId + "/");
					if (!System.IO.Directory.Exists(pathDirPrivateUser))
					{
						System.IO.Directory.CreateDirectory(pathDirPrivateUser);
						CRM.General.IO.Directory.SetFullControlForEveryOne(pathDirPrivateUser);
					}
					pathDirPrivateUser = HttpContext.Current.Server.MapPath(text + token.userId + "/" + now.ToString("yyyyMMddHHmmss", new CultureInfo("en-US")) + "/");
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
								int? centerId = null;
								int value = 0;
								int? num = null;
								int? fileDirectoryTypeId = null;
								int? detailId = null;
								int? num2 = null;
								int? num3 = null;
								string fileName = null;
								string copyFromPath = null;
								string docDate = null;
								string docDay = null;
								string docTime = null;
								string firstRegisterDatePersian = null;
								string text3 = null;
								string fileNumRef = null;
								bool? fileFOCmpCanSee = null;
								string text4 = null;
								string mainDirectoryPath = Mobile.Classes.Configuration.MainDirectoryPath;
								string text5 = Path.GetFileName(fileDatum.LocalFileName);
								string[] allKeys = provider.FormData.AllKeys;
								foreach (string text6 in allKeys)
								{
									string[] values = provider.FormData.GetValues(text6);
									foreach (string text7 in values)
									{
										switch (text6)
										{
										case "LangId":
											int.TryParse(text7, out LangId);
											break;
										case "fileDirectoryTypeId":
											fileDirectoryTypeId = ((!string.IsNullOrEmpty(text7)) ? new int?(int.Parse(text7)) : null);
											break;
										case "masterId":
											num = ((!string.IsNullOrEmpty(text7)) ? new int?(int.Parse(text7)) : null);
											break;
										case "detailId":
											detailId = ((!string.IsNullOrEmpty(text7)) ? new int?(int.Parse(text7)) : null);
											break;
										case "subDetailId":
											num2 = ((!string.IsNullOrEmpty(text7)) ? new int?(int.Parse(text7)) : null);
											break;
										case "typeOprObjectId":
											num3 = ((!string.IsNullOrEmpty(text7)) ? new int?(int.Parse(text7)) : null);
											break;
										case "fileNumRef":
											fileNumRef = text7;
											break;
										case "firstRegisterUserId":
											if (!string.IsNullOrEmpty(text7))
											{
												value = int.Parse(text7);
											}
											else
											{
												countError++;
											}
											break;
										case "docDate":
											docDate = text7;
											break;
										case "docDay":
											docDay = text7;
											break;
										case "docTime":
											docTime = text7;
											break;
										case "firstRegisterDatePersian":
											firstRegisterDatePersian = text7;
											break;
										case "formName":
											text3 = text7;
											break;
										case "title":
											text5 = (string.IsNullOrEmpty(text7) ? Path.GetFileName(fileDatum.LocalFileName) : text7);
											break;
										case "fileFOCmpCanSee":
											fileFOCmpCanSee = text7 == "true";
											break;
										case "centerId":
											centerId = ((!string.IsNullOrEmpty(text7)) ? new int?(int.Parse(text7)) : null);
											break;
										case "fileDesc":
											if (!string.IsNullOrEmpty(text7))
											{
												text4 = text7;
											}
											break;
										}
									}
								}
								FacadeFTP facadeFTP = new FacadeFTP(facadeFtp);
								if (!string.IsNullOrEmpty(text3))
								{
									switch (text3)
									{
									case "Intmsg":
										if (Enumerable.FirstOrDefault<MobspSelectInternalMessage_Result>((IEnumerable<MobspSelectInternalMessage_Result>)Enumerable.ToList<MobspSelectInternalMessage_Result>((IEnumerable<MobspSelectInternalMessage_Result>)db.MobspSelectInternalMessage(num3, LangId, defLangId))) == null)
										{
											return new ServiceResult<FileUploadResultViewModel>
											{
												Message = Messages.MobMsgErrorIsNotInternalMessage,
												Data = null,
												Status = ServiceResultStatus.Error
											};
										}
										break;
									case "Cnvs":
										if (Enumerable.FirstOrDefault<MobspSelectConversationWithID_Result>((IEnumerable<MobspSelectConversationWithID_Result>)Enumerable.ToList<MobspSelectConversationWithID_Result>((IEnumerable<MobspSelectConversationWithID_Result>)db.MobspSelectConversationWithID(num3, LangId, defLangId))) == null)
										{
											return new ServiceResult<FileUploadResultViewModel>
											{
												Message = Messages.MobMsgErrorIsNotConversation,
												Data = null,
												Status = ServiceResultStatus.Error
											};
										}
										break;
									case "Cmp":
										if (Enumerable.FirstOrDefault<mct_MobspSelectCompanyWithID_Result>((IEnumerable<mct_MobspSelectCompanyWithID_Result>)Enumerable.ToList<mct_MobspSelectCompanyWithID_Result>((IEnumerable<mct_MobspSelectCompanyWithID_Result>)db.MobspSelectCompanyWithID(num, token.userId, LangId, defLangId, centerId))) == null)
										{
											return new ServiceResult<FileUploadResultViewModel>
											{
												Message = Messages.MobMsgErrorIsNotCompany,
												Data = null,
												Status = ServiceResultStatus.Error
											};
										}
										break;
									case "Prj":
										if (Enumerable.FirstOrDefault<MobspSelectProjectWithID_Result>((IEnumerable<MobspSelectProjectWithID_Result>)Enumerable.ToList<MobspSelectProjectWithID_Result>((IEnumerable<MobspSelectProjectWithID_Result>)db.MobspSelectProjectWithID(num2, LangId, defLangId))) == null)
										{
											return new ServiceResult<FileUploadResultViewModel>
											{
												Message = Messages.MobMsgErrorIsNotProject,
												Data = null,
												Status = ServiceResultStatus.Error
											};
										}
										break;
									}
									string text8;
									string text9;
									switch (text3)
									{
									case "Intmsg":
										text8 = Mobile.Classes.Configuration.IntmsgDirectoryPath;
										text9 = (num3.HasValue ? num3.ToString() : null);
										detailId = null;
										break;
									case "KnlgT":
										text8 = Mobile.Classes.Configuration.KnlgTDirectoryPath;
										text9 = (num3.HasValue ? num3.ToString() : null);
										detailId = null;
										break;
									case "Cnvs":
										text8 = "";
										text9 = (num.HasValue ? num.ToString() : null);
										break;
									case "Cmp":
									case "Prj":
										text8 = "";
										text9 = (num.HasValue ? num.ToString() : null);
										break;
									default:
										text8 = "";
										text9 = (num.HasValue ? num.ToString() : null);
										detailId = null;
										break;
									}
									if (!string.IsNullOrEmpty(text8))
									{
										string text10 = text8;
										text10 = (text10.EndsWith("/") ? text10.TrimEnd(new char[1] { '/' }) : text10);
										if (!facadeFTP.ExistsDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, mainDirectoryPath, text10, usePassiveFtp))
										{
											facadeFTP.CreateDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, mainDirectoryPath, text10, usePassiveFtp);
										}
									}
									string fileTitle_lang = "";
									List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
									string fileDesc_lang = "";
									List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
									foreach (MobspSelectLanguages_Result item in Enumerable.ToList<MobspSelectLanguages_Result>(Enumerable.Where<MobspSelectLanguages_Result>((IEnumerable<MobspSelectLanguages_Result>)langList, (Func<MobspSelectLanguages_Result, bool>)((MobspSelectLanguages_Result c) => c.LanguageID != defLangId))))
									{
										list.Add(new CommonMultiLanguageViewModel
										{
											Value = text5,
											LanguageId = item.LanguageID
										});
										list2.Add(new CommonMultiLanguageViewModel
										{
											Value = text4,
											LanguageId = item.LanguageID
										});
									}
									if (list != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list))
									{
										fileTitle_lang = JsonConvert.SerializeObject(list);
									}
									string text11 = mainDirectoryPath + text8 + text9 + "/";
									string destination = mainDirectoryPath + text8;
									bool flag = facadeFTP.ExistsDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, destination, text9, usePassiveFtp);
									if (!flag)
									{
										flag = facadeFTP.CreateDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, destination, text9, usePassiveFtp);
									}
									if (flag)
									{
										int result2 = 0;
										if (countError == 0)
										{
											ObjectParameter objectParameter = new ObjectParameter("insertedFileDirectoryId", 0);
											ObjectParameter objectParameter2 = new ObjectParameter("errorMessage", "");
											int? num4 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)db.MobspInsertCrmFilesDirectory(0, fileDirectoryTypeId, num, detailId, num2, text5, text9, fileName, text11, copyFromPath, docDate, docDay, docTime, num3, fileNumRef, fileFOCmpCanSee, value, firstRegisterDatePersian, token.userId, year1, month1, registerDate, registerDatePersian, appType, LangId, defLangId, objectParameter, objectParameter2, centerId, text4, fileTitle_lang, fileDesc_lang));
											FileUploadResultViewModel fileUploadResultViewModel = new FileUploadResultViewModel();
											if (objectParameter2.Value != null)
											{
												fileUploadResultViewModel.ErrorMessage = "";
												allKeys = objectParameter2.Value.ToString().Split(new string[1] { "|^|" }, StringSplitOptions.None);
												foreach (string text12 in allKeys)
												{
													if (!string.IsNullOrEmpty(text12))
													{
														string[] array = text12.Split(new char[1] { ',' });
														if (array[0] == "DuplicateNumRef")
														{
															string arg = array[1].Replace("@DupTitle=", "") ?? "";
															fileUploadResultViewModel.ErrorMessage += string.Format(Messages.FileDirectoryNumRefIsRepeated, arg);
														}
														else
														{
															fileUploadResultViewModel.ErrorMessage += ((objectParameter2.Value.ToString() != "") ? objectParameter2.Value.ToString() : "");
														}
													}
												}
											}
											if (objectParameter.Value != null)
											{
												int.TryParse(objectParameter.Value.ToString(), out result2);
												fileUploadResultViewModel.FileId = result2;
											}
											else
											{
												fileUploadResultViewModel.FileId = 0;
												result2 = 0;
											}
											if (!num4.HasValue || num4 >= 1)
											{
												if (result2 > 0)
												{
													string[] array2 = Path.GetFileName(fileDatum.LocalFileName).Split(new char[1] { '.' });
													switch (text3)
													{
													case "Cnvs":
													case "Cmp":
													case "Prj":
														fileName = num + "-" + result2 + "." + array2[^1];
														break;
													default:
														fileName = num3 + "-" + result2 + "." + array2[^1];
														break;
													}
													if (!facadeFTP.UploadFtpFormTable(pathFtp, userNameFtp, passwordFtp, text11 + fileName, fileDatum.LocalFileName, usePassiveFtp))
													{
														continue;
													}
													int result3 = 0;
													num4 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)db.MobspInsertCrmFilesDirectory(result2, fileDirectoryTypeId, num, detailId, num2, text5, text9, fileName, text11 + fileName, copyFromPath, docDate, docDay, docTime, num3, fileNumRef, fileFOCmpCanSee, value, firstRegisterDatePersian, token.userId, year1, month1, registerDate, registerDatePersian, appType, LangId, defLangId, objectParameter, objectParameter2, centerId, text4, fileTitle_lang, fileDesc_lang));
													if (objectParameter2.Value != null)
													{
														fileUploadResultViewModel.ErrorMessage = ((objectParameter2.Value.ToString() != "") ? objectParameter2.Value.ToString() : "");
													}
													if (objectParameter.Value != null)
													{
														int.TryParse(objectParameter.Value.ToString(), out result3);
														fileUploadResultViewModel.FileId = result3;
													}
													else
													{
														fileUploadResultViewModel.FileId = 0;
														result3 = 0;
													}
													if (!num4.HasValue || num4 >= 1)
													{
														if (result3 > 0)
														{
															if (text3 == "Intmsg")
															{
																db.MobspUpdateInternalMessageAttachFileCount(num3, 1);
															}
															data = fileUploadResultViewModel;
															message = Messages.MobMsgSuccessAction;
															status = ServiceResultStatus.Success;
															continue;
														}
														int? num5 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)db.MobspDeleteCrmFilesDirectory(result2));
														int result4 = 0;
														int.TryParse(num5.ToString(), out result4);
														if (result4 == 1)
														{
															Exception e = new Exception(Messages.MobMsgErrorInCreateFolderInFtp + ",   -  hostname: " + pathFtp + " ,username: " + userNameFtp + " ,destination: " + text8 + " ,directoryName: " + text3);
															ErrorSignal.FromCurrentContext().Raise(e);
															data = null;
															message = Messages.MobMsgErrorInSendingFile;
															status = ServiceResultStatus.Error;
														}
														else
														{
															data = null;
															message = Messages.MobMsgErrorDoneOperation;
															status = ServiceResultStatus.Error;
														}
													}
													else
													{
														data = null;
														message = Messages.MobMsgErrorDoneOperation;
														status = ServiceResultStatus.Error;
													}
												}
												else
												{
													data = null;
													message = ((!string.IsNullOrWhiteSpace(fileUploadResultViewModel.ErrorMessage)) ? fileUploadResultViewModel.ErrorMessage : Messages.MobMsgErrorDoneOperation);
													status = ServiceResultStatus.Error;
												}
											}
											else
											{
												data = null;
												message = ((!string.IsNullOrWhiteSpace(fileUploadResultViewModel.ErrorMessage)) ? fileUploadResultViewModel.ErrorMessage : Messages.MobMsgErrorDoneOperation);
												status = ServiceResultStatus.Error;
											}
										}
										else
										{
											data = null;
											message = Messages.MobMsgErrorDoneOperation;
											status = ServiceResultStatus.Error;
										}
									}
									else
									{
										data = null;
										message = Messages.MobMsgErrorDoneOperation;
										status = ServiceResultStatus.Error;
									}
								}
								else
								{
									message = Messages.MobMsgErrorFormNameNotSelected;
									data = null;
									status = ServiceResultStatus.Error;
								}
							}
							else
							{
								message = Messages.MobMsgErrorFileNotExist;
								data = null;
								status = ServiceResultStatus.Error;
							}
						}
					}
					catch (Exception ex)
					{
						message = Messages.MobMsgErrorDoneOperation + " (" + ex.Message + ")";
						data = null;
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
		catch (Exception ex2)
		{
			message = Messages.MobMsgErrorDoneOperation + " (" + ex2.Message + ")";
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex2);
		}
		finally
		{
			db?.Dispose();
		}
		return new ServiceResult<FileUploadResultViewModel>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public async Task<ServiceResult<LogoUploadResultViewModel>> LogoUpload()
	{
		int LangId = 1065;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangId);
		CRMEntities db = null;
		LogoUploadResultViewModel data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((LangId > 0) ? LangId : defLangId);
		baseInfo.SetCulture(culture);
		try
		{
			db = new CRMEntities();
			if (!base.Request.Content.IsMimeMultipartContent())
			{
				ServiceResult<LogoUploadResultViewModel> serviceResult = new ServiceResult<LogoUploadResultViewModel>();
				HttpStatusCode val = (HttpStatusCode)415;
				serviceResult.Message = ((object)(HttpStatusCode)(ref val)).ToString();
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (base.Request.Headers.Contains("token"))
			{
				string token2 = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token = new Common().GetToken(token2);
				if (token != null)
				{
					int countError = 0;
					DateTime now = DateTime.Now;
					_ = Labels.MobPersonLabel;
					DateTime registerDate = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short year1 = short.Parse(Financial.Get().Id.ToString());
					short month1 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					string appType = Mobile.Classes.Configuration.AppType;
					string text = Mobile.Classes.Configuration.HostTempFilesPath + "/" + Mobile.Classes.Configuration.UploadFileDirectoryPath;
					string text2 = HttpContext.Current.Server.MapPath(text);
					if (!System.IO.Directory.Exists(text2))
					{
						System.IO.Directory.CreateDirectory(text2);
						CRM.General.IO.Directory.SetFullControlForEveryOne(text2);
					}
					string pathDirPrivateUser2 = HttpContext.Current.Server.MapPath(text + token.userId + "/");
					if (!System.IO.Directory.Exists(pathDirPrivateUser2))
					{
						System.IO.Directory.CreateDirectory(pathDirPrivateUser2);
						CRM.General.IO.Directory.SetFullControlForEveryOne(pathDirPrivateUser2);
					}
					pathDirPrivateUser2 = HttpContext.Current.Server.MapPath(text + token.userId + "/" + now.ToString("yyyyMMddHHmmss", new CultureInfo("en-US")) + "/");
					if (!System.IO.Directory.Exists(pathDirPrivateUser2))
					{
						System.IO.Directory.CreateDirectory(pathDirPrivateUser2);
						CRM.General.IO.Directory.SetFullControlForEveryOne(pathDirPrivateUser2);
					}
					CustomMultipartFormDataStreamProvider provider = new CustomMultipartFormDataStreamProvider(pathDirPrivateUser2);
					new List<string>();
					try
					{
						await base.Request.Content.ReadAsMultipartAsync(provider);
						foreach (MultipartFileData fileDatum in provider.FileData)
						{
							if (System.IO.File.Exists(fileDatum.LocalFileName))
							{
								_003C_003Ec__DisplayClass1_0 _003C_003Ec__DisplayClass1_ = new _003C_003Ec__DisplayClass1_0();
								int? centerId = null;
								_003C_003Ec__DisplayClass1_.cmpId = null;
								int? num = null;
								_003C_003Ec__DisplayClass1_.prsId = null;
								string text3 = null;
								_ = Mobile.Classes.Configuration.MainDirectoryPath;
								string[] allKeys = provider.FormData.AllKeys;
								foreach (string text4 in allKeys)
								{
									string[] values = provider.FormData.GetValues(text4);
									foreach (string text5 in values)
									{
										switch (text4)
										{
										case "LangId":
											int.TryParse(text5, out LangId);
											break;
										case "mode":
											num = ((!string.IsNullOrEmpty(text5)) ? new int?(int.Parse(text5)) : null);
											break;
										case "cmpId":
											_003C_003Ec__DisplayClass1_.cmpId = ((!string.IsNullOrEmpty(text5)) ? new int?(int.Parse(text5)) : null);
											break;
										case "prsId":
											_003C_003Ec__DisplayClass1_.prsId = ((!string.IsNullOrEmpty(text5)) ? new int?(int.Parse(text5)) : null);
											break;
										case "firstRegisterUserId":
											if (!string.IsNullOrEmpty(text5))
											{
												int.Parse(text5);
											}
											else
											{
												countError++;
											}
											break;
										case "firstRegisterDatePersian":
											text3 = text5;
											break;
										case "centerId":
											centerId = ((!string.IsNullOrEmpty(text5)) ? new int?(int.Parse(text5)) : null);
											break;
										}
									}
								}
								LogoUploadResultViewModel logoUploadResultViewModel = new LogoUploadResultViewModel
								{
									CompanyId = _003C_003Ec__DisplayClass1_.cmpId.GetValueOrDefault(),
									CompanyPersonId = _003C_003Ec__DisplayClass1_.prsId.GetValueOrDefault()
								};
								bool flag = false;
								bool flag2 = false;
								if (num == 0)
								{
									if (Enumerable.FirstOrDefault<mct_MobspSelectCompanyWithID_Result>((IEnumerable<mct_MobspSelectCompanyWithID_Result>)Enumerable.ToList<mct_MobspSelectCompanyWithID_Result>((IEnumerable<mct_MobspSelectCompanyWithID_Result>)db.MobspSelectCompanyWithID(_003C_003Ec__DisplayClass1_.cmpId, token.userId, LangId, defLangId, centerId))) == null)
									{
										return new ServiceResult<LogoUploadResultViewModel>
										{
											Message = Messages.MobMsgErrorIsNotCompany,
											Data = logoUploadResultViewModel,
											Status = ServiceResultStatus.Error
										};
									}
									if (Enumerable.FirstOrDefault<MobspSelectPersonWithID_Result>((IEnumerable<MobspSelectPersonWithID_Result>)Enumerable.ToList<MobspSelectPersonWithID_Result>((IEnumerable<MobspSelectPersonWithID_Result>)db.MobspSelectPersonWithID(_003C_003Ec__DisplayClass1_.prsId, LangId, defLangId))) == null)
									{
										return new ServiceResult<LogoUploadResultViewModel>
										{
											Message = Messages.MobMsgErrorIsNotCompanyPerson,
											Data = logoUploadResultViewModel,
											Status = ServiceResultStatus.Error
										};
									}
									flag = true;
									flag2 = true;
								}
								else if (num.GetValueOrDefault() == 1)
								{
									if (Enumerable.FirstOrDefault<mct_MobspSelectCompanyWithID_Result>((IEnumerable<mct_MobspSelectCompanyWithID_Result>)Enumerable.ToList<mct_MobspSelectCompanyWithID_Result>((IEnumerable<mct_MobspSelectCompanyWithID_Result>)db.MobspSelectCompanyWithID(_003C_003Ec__DisplayClass1_.cmpId, token.userId, LangId, defLangId, centerId))) == null)
									{
										return new ServiceResult<LogoUploadResultViewModel>
										{
											Message = Messages.MobMsgErrorIsNotCompany,
											Data = logoUploadResultViewModel,
											Status = ServiceResultStatus.Error
										};
									}
									flag = true;
									flag2 = false;
								}
								else if (num.GetValueOrDefault() == 2)
								{
									if (Enumerable.FirstOrDefault<MobspSelectPersonWithID_Result>((IEnumerable<MobspSelectPersonWithID_Result>)Enumerable.ToList<MobspSelectPersonWithID_Result>((IEnumerable<MobspSelectPersonWithID_Result>)db.MobspSelectPersonWithID(_003C_003Ec__DisplayClass1_.prsId, LangId, defLangId))) == null)
									{
										return new ServiceResult<LogoUploadResultViewModel>
										{
											Message = Messages.MobMsgErrorIsNotCompanyPerson,
											Data = logoUploadResultViewModel,
											Status = ServiceResultStatus.Error
										};
									}
									flag = false;
									flag2 = true;
								}
								DateTime value = DateTime.Now;
								try
								{
									if (!string.IsNullOrEmpty(text3))
									{
										string formatetdDate = PersianDate.GetFormatetdDate(text3.Replace("/", ""));
										DateTime dateTime;
										if (LangId == 1065)
										{
											dateTime = DateTime.Parse(formatetdDate + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
											text3 = dateTime.ToString("yyyyMMdd");
										}
										else
										{
											dateTime = DateTime.Parse(formatetdDate + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
											text3 = dateTime.ToString("yyyyMMdd", new PersianCulture());
										}
										value = dateTime;
									}
								}
								catch (Exception e)
								{
									ErrorSignal.FromCurrentContext().Raise(e);
									ServiceResult<LogoUploadResultViewModel> result = new ServiceResult<LogoUploadResultViewModel>
									{
										Message = Messages.MobMsgErrorDateFormatIncorrect,
										Data = logoUploadResultViewModel,
										Status = ServiceResultStatus.Error
									};
									db?.Dispose();
									return result;
								}
								byte[] array;
								if (System.IO.File.Exists(fileDatum.LocalFileName))
								{
									Bitmap val2 = new Bitmap(fileDatum.LocalFileName);
									MemoryStream memoryStream = new MemoryStream();
									((Image)val2).Save((Stream)memoryStream, ImageFormat.Jpeg);
									array = memoryStream.GetBuffer();
									memoryStream.Dispose();
									((Image)val2).Dispose();
								}
								else
								{
									array = null;
								}
								if (flag)
								{
									DbSet<CrmCompanyLoGo> crmCompanyLoGo = db.CrmCompanyLoGo;
									ParameterExpression val3 = Expression.Parameter(typeof(CrmCompanyLoGo), "c");
									CrmCompanyLoGo crmCompanyLoGo2 = Queryable.FirstOrDefault<CrmCompanyLoGo>((IQueryable<CrmCompanyLoGo>)crmCompanyLoGo, Expression.Lambda<Func<CrmCompanyLoGo, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val3, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass1_, typeof(_003C_003Ec__DisplayClass1_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val3 }));
									bool flag3 = false;
									if (crmCompanyLoGo2 == null)
									{
										crmCompanyLoGo2 = new CrmCompanyLoGo();
										flag3 = true;
										crmCompanyLoGo2.CompanyId = _003C_003Ec__DisplayClass1_.cmpId;
										crmCompanyLoGo2.FirstRegisterUserId = token.userId;
										crmCompanyLoGo2.FirstRegisterDate = value;
										crmCompanyLoGo2.FirstRegisterDatePersian = text3;
										crmCompanyLoGo2.LanguageID = defLangId;
										crmCompanyLoGo2.GUId = System.Guid.NewGuid();
									}
									crmCompanyLoGo2.CompanyLogo = array;
									crmCompanyLoGo2.Year1 = year1;
									crmCompanyLoGo2.Month1 = month1;
									crmCompanyLoGo2.RegisterDate = registerDate;
									crmCompanyLoGo2.RegisterDatePersian = registerDatePersian;
									crmCompanyLoGo2.UserId = token.userId;
									crmCompanyLoGo2.AppType = appType;
									if (flag3)
									{
										db.CrmCompanyLoGo.Add(crmCompanyLoGo2);
									}
									else
									{
										db.Entry(crmCompanyLoGo2).State = EntityState.Modified;
									}
									db.SaveChanges();
								}
								if (flag2)
								{
									DbSet<CrmPersonPicture> crmPersonPicture = db.CrmPersonPicture;
									ParameterExpression val3 = Expression.Parameter(typeof(CrmPersonPicture), "c");
									CrmPersonPicture crmPersonPicture2 = Queryable.FirstOrDefault<CrmPersonPicture>((IQueryable<CrmPersonPicture>)crmPersonPicture, Expression.Lambda<Func<CrmPersonPicture, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val3, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass1_, typeof(_003C_003Ec__DisplayClass1_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val3 }));
									bool flag4 = false;
									if (crmPersonPicture2 == null)
									{
										crmPersonPicture2 = new CrmPersonPicture();
										flag4 = true;
										crmPersonPicture2.CompanyPersonId = _003C_003Ec__DisplayClass1_.prsId;
										crmPersonPicture2.GUId = System.Guid.NewGuid();
										crmPersonPicture2.FirstRegisterUserId = token.userId;
										crmPersonPicture2.FirstRegisterDatePersian = text3;
										crmPersonPicture2.FirstRegisterDate = value;
										crmPersonPicture2.LanguageID = defLangId;
									}
									crmPersonPicture2.AppType = appType;
									crmPersonPicture2.Year1 = year1;
									crmPersonPicture2.Month1 = month1;
									crmPersonPicture2.RegisterDate = registerDate;
									crmPersonPicture2.RegisterDatePersian = registerDatePersian;
									crmPersonPicture2.UserId = token.userId;
									crmPersonPicture2.PersonPicture = array;
									if (flag4)
									{
										db.CrmPersonPicture.Add(crmPersonPicture2);
									}
									else
									{
										db.Entry(crmPersonPicture2).State = EntityState.Modified;
									}
									db.SaveChanges();
								}
								data = logoUploadResultViewModel;
								message = Messages.MobMsgSuccessAction;
								status = ServiceResultStatus.Success;
							}
							else
							{
								message = Messages.MobMsgErrorFileNotExist;
								data = null;
								status = ServiceResultStatus.Error;
							}
						}
					}
					catch (Exception ex)
					{
						message = Messages.MobMsgErrorDoneOperation + " (" + ex.Message + ")";
						data = null;
						status = ServiceResultStatus.Error;
						ErrorSignal.FromCurrentContext().Raise(ex);
					}
					finally
					{
						db?.Dispose();
						try
						{
							if (System.IO.Directory.Exists(pathDirPrivateUser2))
							{
								DirectoryInfo directoryInfo = new DirectoryInfo(pathDirPrivateUser2);
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
								if (System.IO.Directory.Exists(pathDirPrivateUser2))
								{
									System.IO.Directory.Delete(pathDirPrivateUser2);
								}
							}
						}
						catch (Exception)
						{
						}
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
		catch (Exception ex3)
		{
			message = Messages.MobMsgErrorDoneOperation + " (" + ex3.Message + ")";
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex3);
		}
		finally
		{
			db?.Dispose();
		}
		return new ServiceResult<LogoUploadResultViewModel>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
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
				if (new Common().GetToken(token) != null)
				{
					try
					{
						if (fileId > 0)
						{
							Files files = new Files();
							string text3 = ((fileId > 0) ? files.GetFilePath(fileId) : "");
							if (string.IsNullOrEmpty(text3))
							{
								text2 = Messages.MobMsgErrorFileNotExist;
								text = null;
								serviceResultStatus = ServiceResultStatus.Error;
							}
							else
							{
								PrintLog.InsertPrintLog(fileId, 550, 3);
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
	[MobileAuthorize]
	public ServiceResult<string> DeletePathDownload(string filePath)
	{
		int num = 1065;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		string data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((num > 0) ? num : result);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					try
					{
						if (!string.IsNullOrEmpty(filePath))
						{
							string[] array = HttpContext.Current.Request.Url.AbsoluteUri.Split(new string[1] { "/api/" }, StringSplitOptions.None);
							if (array != null)
							{
								if (array[0] != null && array[0] != "")
								{
									filePath = filePath.Replace(array[0], "");
									string path = HttpContext.Current.Server.MapPath(filePath);
									if (System.IO.File.Exists(path))
									{
										DirectoryInfo parent = System.IO.Directory.GetParent(path);
										if (System.IO.Directory.Exists(parent.FullName))
										{
											FileInfo[] files = parent.GetFiles();
											for (int i = 0; i < files.Length; i++)
											{
												files[i].Delete();
											}
											DirectoryInfo[] directories = parent.GetDirectories();
											for (int i = 0; i < directories.Length; i++)
											{
												directories[i].Delete(recursive: true);
											}
											if (System.IO.Directory.Exists(parent.FullName))
											{
												System.IO.Directory.Delete(parent.FullName);
											}
											if (!System.IO.Directory.Exists(parent.FullName))
											{
												data = "Ok";
												message = Messages.MobMsgSuccessAction;
												status = ServiceResultStatus.Success;
											}
											else
											{
												message = Messages.MobMsgErrorDoneOperation;
												data = null;
												status = ServiceResultStatus.Error;
											}
										}
										else
										{
											message = Messages.MobMsgErrorDoneOperation;
											data = null;
											status = ServiceResultStatus.Error;
										}
									}
								}
								else
								{
									message = Messages.MobMsgErrorDoneOperation;
									data = null;
									status = ServiceResultStatus.Error;
								}
							}
							else
							{
								message = Messages.MobMsgErrorFilePathIsEmpty;
								data = null;
								status = ServiceResultStatus.Error;
							}
						}
						else
						{
							message = Messages.MobMsgErrorFilePathIsEmpty;
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
		catch (Exception e2)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> DeleteSinglePathDownload(string filePath)
	{
		int num = 1065;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		string data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((num > 0) ? num : result);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					try
					{
						if (!string.IsNullOrEmpty(filePath))
						{
							string[] array = HttpContext.Current.Request.Url.AbsoluteUri.Split(new string[1] { "/api/" }, StringSplitOptions.None);
							if (array != null)
							{
								if (array[0] != null && array[0] != "")
								{
									filePath = filePath.Replace(array[0], "");
									string text = HttpContext.Current.Server.MapPath(filePath);
									if (System.IO.File.Exists(text))
									{
										DirectoryInfo parent = System.IO.Directory.GetParent(text);
										if (System.IO.Directory.Exists(parent.FullName))
										{
											FileInfo[] files = parent.GetFiles();
											foreach (FileInfo fileInfo in files)
											{
												if (fileInfo.FullName == text)
												{
													fileInfo.Delete();
												}
											}
											DirectoryInfo[] directories = parent.GetDirectories();
											foreach (DirectoryInfo directoryInfo in directories)
											{
												if (directoryInfo.GetFiles() == null)
												{
													directoryInfo.Delete(recursive: true);
												}
											}
											if (System.IO.Directory.Exists(parent.FullName) && parent.GetFiles() == null)
											{
												System.IO.Directory.Delete(parent.FullName);
											}
											if (!System.IO.Directory.Exists(text))
											{
												data = "Ok";
												message = Messages.MobMsgSuccessAction;
												status = ServiceResultStatus.Success;
											}
											else
											{
												message = Messages.MobMsgErrorDoneOperation;
												data = null;
												status = ServiceResultStatus.Error;
											}
										}
										else
										{
											message = Messages.MobMsgErrorDoneOperation;
											data = null;
											status = ServiceResultStatus.Error;
										}
									}
								}
								else
								{
									message = Messages.MobMsgErrorDoneOperation;
									data = null;
									status = ServiceResultStatus.Error;
								}
							}
							else
							{
								message = Messages.MobMsgErrorFilePathIsEmpty;
								data = null;
								status = ServiceResultStatus.Error;
							}
						}
						else
						{
							message = Messages.MobMsgErrorFilePathIsEmpty;
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
		catch (Exception e2)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> GetLinkDownloadUserPicture(int userId)
	{
		int num = 1065;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		CRMEntities cRMEntities = null;
		string data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((num > 0) ? num : result);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					try
					{
						if (userId != 0)
						{
							_ = DateTime.Now;
							string text = "";
							string text2 = "";
							cRMEntities = new CRMEntities();
							byte[] array = null;
							MobspSelectUserPictureByUserId_Result mobspSelectUserPictureByUserId_Result = Enumerable.FirstOrDefault<MobspSelectUserPictureByUserId_Result>((IEnumerable<MobspSelectUserPictureByUserId_Result>)cRMEntities.MobspSelectUserPictureByUserId(userId));
							if (mobspSelectUserPictureByUserId_Result != null)
							{
								if (mobspSelectUserPictureByUserId_Result.UserPicture != null)
								{
									array = mobspSelectUserPictureByUserId_Result.UserPicture;
									new MemoryStream();
									MemoryStream memoryStream = new MemoryStream(array, writable: false);
									Image.FromStream((Stream)memoryStream);
									memoryStream.Dispose();
									FilesManager filesManager = new FilesManager();
									string text3 = filesManager.SetNameDirectory(token2.userId);
									if (!string.IsNullOrEmpty(text3) && filesManager.CreateDirectory(text3))
									{
										text = HttpContext.Current.Server.MapPath(text3 + "/" + userId + ".jpg");
										string[] array2 = HttpContext.Current.Request.Url.AbsoluteUri.Split(new string[1] { "/api/" }, StringSplitOptions.None);
										if (array2 != null)
										{
											text2 = ((array2[0] != null && array2[0] != "") ? (array2[0] + text3 + "/" + userId + ".jpg") : "");
										}
									}
									if (text != "" && text != null)
									{
										if (CRM.General.IO.File.SaveBytesToFile(text, array))
										{
											if (System.IO.File.Exists(text))
											{
												data = text2;
												message = Messages.MobMsgSuccessAction;
												status = ServiceResultStatus.Success;
											}
											else
											{
												message = Messages.MobMsgErrorDoneOperation;
												data = null;
												status = ServiceResultStatus.Error;
											}
										}
										else
										{
											message = Messages.MobMsgErrorDoneOperation;
											data = null;
											status = ServiceResultStatus.Error;
										}
									}
									else
									{
										message = Messages.MobMsgErrorDoneOperation;
										data = null;
										status = ServiceResultStatus.Error;
									}
								}
								else
								{
									data = "No Picture";
									message = Messages.MobMsgSuccessAction;
									status = ServiceResultStatus.Success;
								}
							}
							else
							{
								data = "No Picture";
								message = Messages.MobMsgSuccessAction;
								status = ServiceResultStatus.Success;
							}
						}
						else
						{
							message = Messages.MobMsgErrorIsNotCompany;
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
		catch (Exception e2)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e2);
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
	[MobileAuthorize]
	public ServiceResult<string> GetLinkDownloadCompanyLogo(int cmpId)
	{
		_003C_003Ec__DisplayClass6_0 _003C_003Ec__DisplayClass6_ = new _003C_003Ec__DisplayClass6_0();
		_003C_003Ec__DisplayClass6_.cmpId = cmpId;
		int num = 1065;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		CRMEntities cRMEntities = null;
		string data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((num > 0) ? num : result);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					try
					{
						if (_003C_003Ec__DisplayClass6_.cmpId > 0)
						{
							_ = DateTime.Now;
							string text = "";
							string text2 = "";
							cRMEntities = new CRMEntities();
							byte[] array = null;
							DbSet<CrmCompanyLoGo> crmCompanyLoGo = cRMEntities.CrmCompanyLoGo;
							ParameterExpression val = Expression.Parameter(typeof(CrmCompanyLoGo), "c");
							CrmCompanyLoGo crmCompanyLoGo2 = Queryable.FirstOrDefault<CrmCompanyLoGo>((IQueryable<CrmCompanyLoGo>)crmCompanyLoGo, Expression.Lambda<Func<CrmCompanyLoGo, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Convert((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass6_, typeof(_003C_003Ec__DisplayClass6_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), typeof(int?))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (crmCompanyLoGo2 != null)
							{
								if (crmCompanyLoGo2.CompanyLogo != null)
								{
									array = crmCompanyLoGo2.CompanyLogo;
									new MemoryStream();
									MemoryStream memoryStream = new MemoryStream(array, writable: false);
									Image.FromStream((Stream)memoryStream);
									memoryStream.Dispose();
									FilesManager filesManager = new FilesManager();
									string text3 = filesManager.SetNameDirectory(token2.userId);
									if (!string.IsNullOrEmpty(text3) && filesManager.CreateDirectory(text3))
									{
										text = HttpContext.Current.Server.MapPath(text3 + "/" + _003C_003Ec__DisplayClass6_.cmpId + ".jpg");
										string[] array2 = HttpContext.Current.Request.Url.AbsoluteUri.Split(new string[1] { "/api/" }, StringSplitOptions.None);
										if (array2 != null)
										{
											text2 = ((array2[0] != null && array2[0] != "") ? (array2[0] + text3 + "/" + _003C_003Ec__DisplayClass6_.cmpId + ".jpg") : "");
										}
									}
									if (text != "" && text != null)
									{
										if (CRM.General.IO.File.SaveBytesToFile(text, array))
										{
											if (System.IO.File.Exists(text))
											{
												data = text2;
												message = Messages.MobMsgSuccessAction;
												status = ServiceResultStatus.Success;
											}
											else
											{
												message = Messages.MobMsgErrorDoneOperation;
												data = null;
												status = ServiceResultStatus.Error;
											}
										}
										else
										{
											message = Messages.MobMsgErrorDoneOperation;
											data = null;
											status = ServiceResultStatus.Error;
										}
									}
									else
									{
										message = Messages.MobMsgErrorDoneOperation;
										data = null;
										status = ServiceResultStatus.Error;
									}
								}
								else
								{
									data = "No Picture";
									message = Messages.MobMsgSuccessAction;
									status = ServiceResultStatus.Success;
								}
							}
							else
							{
								data = "No Picture";
								message = Messages.MobMsgSuccessAction;
								status = ServiceResultStatus.Success;
							}
						}
						else
						{
							message = Messages.MobMsgErrorIsNotCompany;
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
		catch (Exception e2)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e2);
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
	[MobileAuthorize]
	public ServiceResult<string> GetLinkDownloadPersonPicture(int prsId)
	{
		_003C_003Ec__DisplayClass7_0 _003C_003Ec__DisplayClass7_ = new _003C_003Ec__DisplayClass7_0();
		_003C_003Ec__DisplayClass7_.prsId = prsId;
		int num = 1065;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		CRMEntities cRMEntities = null;
		string data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((num > 0) ? num : result);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					try
					{
						if (_003C_003Ec__DisplayClass7_.prsId > 0)
						{
							_ = DateTime.Now;
							string text = "";
							string text2 = "";
							cRMEntities = new CRMEntities();
							byte[] array = null;
							DbSet<CrmPersonPicture> crmPersonPicture = cRMEntities.CrmPersonPicture;
							ParameterExpression val = Expression.Parameter(typeof(CrmPersonPicture), "c");
							CrmPersonPicture crmPersonPicture2 = Queryable.FirstOrDefault<CrmPersonPicture>((IQueryable<CrmPersonPicture>)crmPersonPicture, Expression.Lambda<Func<CrmPersonPicture, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Convert((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass7_, typeof(_003C_003Ec__DisplayClass7_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), typeof(int?))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (crmPersonPicture2 != null)
							{
								if (crmPersonPicture2.PersonPicture != null)
								{
									array = crmPersonPicture2.PersonPicture;
									new MemoryStream();
									MemoryStream memoryStream = new MemoryStream(array, writable: false);
									Image.FromStream((Stream)memoryStream);
									memoryStream.Dispose();
									FilesManager filesManager = new FilesManager();
									string text3 = filesManager.SetNameDirectory(token2.userId);
									if (!string.IsNullOrEmpty(text3) && filesManager.CreateDirectory(text3))
									{
										text = HttpContext.Current.Server.MapPath(text3 + "/" + _003C_003Ec__DisplayClass7_.prsId + ".jpg");
										string[] array2 = HttpContext.Current.Request.Url.AbsoluteUri.Split(new string[1] { "/api/" }, StringSplitOptions.None);
										if (array2 != null)
										{
											text2 = ((array2[0] != null && array2[0] != "") ? (array2[0] + text3 + "/" + _003C_003Ec__DisplayClass7_.prsId + ".jpg") : "");
										}
									}
									if (text != "" && text != null)
									{
										if (CRM.General.IO.File.SaveBytesToFile(text, array))
										{
											if (System.IO.File.Exists(text))
											{
												data = text2;
												message = Messages.MobMsgSuccessAction;
												status = ServiceResultStatus.Success;
											}
											else
											{
												message = Messages.MobMsgErrorDoneOperation;
												data = null;
												status = ServiceResultStatus.Error;
											}
										}
										else
										{
											message = Messages.MobMsgErrorDoneOperation;
											data = null;
											status = ServiceResultStatus.Error;
										}
									}
									else
									{
										message = Messages.MobMsgErrorDoneOperation;
										data = null;
										status = ServiceResultStatus.Error;
									}
								}
								else
								{
									data = "No Picture";
									message = Messages.MobMsgSuccessAction;
									status = ServiceResultStatus.Success;
								}
							}
							else
							{
								data = "No Picture";
								message = Messages.MobMsgSuccessAction;
								status = ServiceResultStatus.Success;
							}
						}
						else
						{
							message = Messages.MobMsgErrorIsNotPerson;
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
		catch (Exception e2)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e2);
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
	[MobileAuthorize]
	public ServiceResult<string> GetLinkDownloadWsLogo(int logoId)
	{
		int num = 1065;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		CRMEntities cRMEntities = null;
		string data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((num > 0) ? num : result);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					try
					{
						if (logoId > 0)
						{
							_ = DateTime.Now;
							string text = "";
							string text2 = "";
							cRMEntities = new CRMEntities();
							byte[] array = null;
							MobspSelectLogoWithID_Result mobspSelectLogoWithID_Result = Enumerable.FirstOrDefault<MobspSelectLogoWithID_Result>((IEnumerable<MobspSelectLogoWithID_Result>)cRMEntities.MobspSelectLogoWithID(logoId, num, result));
							if (mobspSelectLogoWithID_Result != null)
							{
								if (mobspSelectLogoWithID_Result.Logo != null)
								{
									array = mobspSelectLogoWithID_Result.Logo;
									new MemoryStream();
									MemoryStream memoryStream = new MemoryStream(array, writable: false);
									Image.FromStream((Stream)memoryStream);
									memoryStream.Dispose();
									FilesManager filesManager = new FilesManager();
									string text3 = filesManager.SetNameDirectory(token2.userId);
									if (!string.IsNullOrEmpty(text3) && filesManager.CreateDirectory(text3))
									{
										text = HttpContext.Current.Server.MapPath(text3 + "/" + logoId + ".jpg");
										string[] array2 = HttpContext.Current.Request.Url.AbsoluteUri.Split(new string[1] { "/api/" }, StringSplitOptions.None);
										if (array2 != null)
										{
											text2 = ((array2[0] != null && array2[0] != "") ? (array2[0] + text3 + "/" + logoId + ".jpg") : "");
										}
									}
									if (text != "" && text != null)
									{
										if (CRM.General.IO.File.SaveBytesToFile(text, array))
										{
											if (System.IO.File.Exists(text))
											{
												data = text2;
												message = Messages.MobMsgSuccessAction;
												status = ServiceResultStatus.Success;
											}
											else
											{
												message = Messages.MobMsgErrorDoneOperation;
												data = null;
												status = ServiceResultStatus.Error;
											}
										}
										else
										{
											message = Messages.MobMsgErrorDoneOperation;
											data = null;
											status = ServiceResultStatus.Error;
										}
									}
									else
									{
										message = Messages.MobMsgErrorDoneOperation;
										data = null;
										status = ServiceResultStatus.Error;
									}
								}
								else
								{
									data = "No Picture";
									message = Messages.MobMsgSuccessAction;
									status = ServiceResultStatus.Success;
								}
							}
							else
							{
								data = "No Picture";
								message = Messages.MobMsgSuccessAction;
								status = ServiceResultStatus.Success;
							}
						}
						else
						{
							message = Messages.MobMsgErrorIsNotCompany;
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
		catch (Exception e2)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e2);
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
	[MobileAuthorize]
	public ServiceResult<List<FileDirectoryViewModel>> SelectFilesDirectory(string masterId, string detailId, string subDetailId, string fileDirectoryTypeOprId, string typeOprObjectId, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<FileDirectoryViewModel> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					try
					{
						cRMEntities = new CRMEntities();
						List<MobspSelectFilesDirectory_Result> list = Enumerable.ToList<MobspSelectFilesDirectory_Result>((IEnumerable<MobspSelectFilesDirectory_Result>)cRMEntities.MobspSelectFilesDirectory(masterId, detailId, subDetailId, fileDirectoryTypeOprId, typeOprObjectId, result, result2, false, cId));
						List<FileDirectoryViewModel> list2 = new List<FileDirectoryViewModel>();
						foreach (MobspSelectFilesDirectory_Result item in list)
						{
							FileDirectoryViewModel fileDirectoryViewModel = new FileDirectoryViewModel();
							fileDirectoryViewModel.FileDirectoryID = item.FileDirectoryID;
							fileDirectoryViewModel.FileDirectoryTypeId = item.FileDirectoryTypeId.GetValueOrDefault();
							fileDirectoryViewModel.MasterId = item.MasterId.GetValueOrDefault();
							fileDirectoryViewModel.DetailId = item.DetailId.GetValueOrDefault();
							fileDirectoryViewModel.SubDetailId = item.SubDetailId.GetValueOrDefault();
							fileDirectoryViewModel.TypeOprObjectId = item.TypeOprObjectId.GetValueOrDefault();
							fileDirectoryViewModel.Title = item.Title ?? "";
							fileDirectoryViewModel.FileName = item.FileName ?? "";
							int result3 = 0;
							int.TryParse(item.FileDirectoryID.ToString(), out result3);
							fileDirectoryViewModel.FilePath = "";
							fileDirectoryViewModel.DocDate = (item.DocDateTime ?? DateTime.Now).ToString("yyyy/MM/dd", new CultureInfo("en-US"));
							fileDirectoryViewModel.DocDatePersian = DateTimeClass.ConvertDateWoSlashToSlash(item.DocDate);
							fileDirectoryViewModel.DocDay = item.DocDay ?? "";
							fileDirectoryViewModel.DocDayPersian = (item.DocDateTime ?? DateTime.Now).ToString("dddd", new PersianCulture());
							fileDirectoryViewModel.DocTime = item.DocTime ?? "";
							fileDirectoryViewModel.FileDirectoryType = item.FileDirectoryType ?? "";
							fileDirectoryViewModel.ProjectTitle = item.prjTitle ?? "";
							fileDirectoryViewModel.CompanyName = "";
							fileDirectoryViewModel.FileDirectoryTypeOprId = item.FileDirectoryTypeOprId.GetValueOrDefault();
							fileDirectoryViewModel.FileDirectoryTypeOpr = item.FileDirectoryTypeOpr ?? "";
							fileDirectoryViewModel.otherFields = null;
							fileDirectoryViewModel.otherFieldsHeader = null;
							list2.Add(fileDirectoryViewModel);
						}
						data = list2;
						message = "";
						status = ServiceResultStatus.Success;
					}
					catch (Exception e)
					{
						message = Messages.MobMsgErrorDoneOperation;
						data = null;
						status = ServiceResultStatus.Error;
						ErrorSignal.FromCurrentContext().Raise(e);
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
		catch (Exception e2)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<FileDirectoryViewModel>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> GetLinkDownloadPrdGroupPictureByPrdGroupId(int prdGroupId, int type)
	{
		CRMEntities cRMEntities = null;
		string data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					try
					{
						if (prdGroupId > 0)
						{
							_ = DateTime.Now;
							string text = "";
							string text2 = "";
							cRMEntities = new CRMEntities();
							byte[] array = null;
							MobspSelectProductGroupPictureByPrdGroupId_Result mobspSelectProductGroupPictureByPrdGroupId_Result = Enumerable.FirstOrDefault<MobspSelectProductGroupPictureByPrdGroupId_Result>((IEnumerable<MobspSelectProductGroupPictureByPrdGroupId_Result>)cRMEntities.MobspSelectProductGroupPictureByPrdGroupId(prdGroupId, type));
							if (mobspSelectProductGroupPictureByPrdGroupId_Result != null)
							{
								if (mobspSelectProductGroupPictureByPrdGroupId_Result.PrdGroupPic != null)
								{
									array = mobspSelectProductGroupPictureByPrdGroupId_Result.PrdGroupPic;
									new MemoryStream();
									MemoryStream memoryStream = new MemoryStream(array, writable: false);
									Image.FromStream((Stream)memoryStream);
									memoryStream.Dispose();
									FilesManager filesManager = new FilesManager();
									string text3 = filesManager.SetNameDirectory(token2.userId);
									if (!string.IsNullOrEmpty(text3) && filesManager.CreateDirectory(text3))
									{
										text = HttpContext.Current.Server.MapPath(text3 + "/" + prdGroupId + ".jpg");
										string[] array2 = HttpContext.Current.Request.Url.AbsoluteUri.Split(new string[1] { "/api/" }, StringSplitOptions.None);
										if (array2 != null)
										{
											text2 = ((array2[0] != null && array2[0] != "") ? (array2[0] + text3 + "/" + prdGroupId + ".jpg") : "");
										}
									}
									if (text != "" && text != null)
									{
										if (CRM.General.IO.File.SaveBytesToFile(text, array))
										{
											if (System.IO.File.Exists(text))
											{
												data = text2;
												message = Messages.MobMsgSuccessAction;
												status = ServiceResultStatus.Success;
											}
											else
											{
												message = Messages.MobMsgErrorDoneOperation;
												data = null;
												status = ServiceResultStatus.Error;
											}
										}
										else
										{
											message = Messages.MobMsgErrorDoneOperation;
											data = null;
											status = ServiceResultStatus.Error;
										}
									}
									else
									{
										message = Messages.MobMsgErrorDoneOperation;
										data = null;
										status = ServiceResultStatus.Error;
									}
								}
								else
								{
									data = "No Picture";
									message = Messages.MobMsgSuccessAction;
									status = ServiceResultStatus.Success;
								}
							}
							else
							{
								data = "No Picture";
								message = Messages.MobMsgSuccessAction;
								status = ServiceResultStatus.Success;
							}
						}
						else
						{
							message = Messages.MobMsgErrorIsNotCompany;
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
		catch (Exception e2)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e2);
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
	[MobileAuthorize]
	public ServiceResult<string> GetLinkDownloadPrdGroupPictureByPrdGroupIdFromFTP(int prdGroupId, int type)
	{
		CRMEntities cRMEntities = null;
		string data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					try
					{
						if (prdGroupId > 0)
						{
							cRMEntities = new CRMEntities();
							MobspSelectProductGroupPictureByPrdGroupId_Result mobspSelectProductGroupPictureByPrdGroupId_Result = Enumerable.FirstOrDefault<MobspSelectProductGroupPictureByPrdGroupId_Result>((IEnumerable<MobspSelectProductGroupPictureByPrdGroupId_Result>)cRMEntities.MobspSelectProductGroupPictureByPrdGroupId(prdGroupId, type));
							if (mobspSelectProductGroupPictureByPrdGroupId_Result != null)
							{
								if (mobspSelectProductGroupPictureByPrdGroupId_Result.FilePath != null)
								{
									mobspSelectProductGroupPictureByPrdGroupId_Result.FilePath = Product.GetProductPictureFilePath(mobspSelectProductGroupPictureByPrdGroupId_Result.FilePath, mobspSelectProductGroupPictureByPrdGroupId_Result.FileName, mobspSelectProductGroupPictureByPrdGroupId_Result.FolderName);
									if (mobspSelectProductGroupPictureByPrdGroupId_Result.FilePath != "")
									{
										data = mobspSelectProductGroupPictureByPrdGroupId_Result.FilePath;
										message = Messages.MobMsgSuccessAction;
										status = ServiceResultStatus.Success;
									}
								}
								else
								{
									data = "No Picture";
									message = Messages.MobMsgSuccessAction;
									status = ServiceResultStatus.Success;
								}
							}
							else
							{
								data = "No Picture";
								message = Messages.MobMsgSuccessAction;
								status = ServiceResultStatus.Success;
							}
						}
						else
						{
							message = Messages.MobMsgErrorIsNotCompany;
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
		catch (Exception e2)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e2);
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
	[MobileAuthorize]
	public ServiceResult<List<ProductGroupPictureModel>> SelectProductGroupPictureInMode(int showMode, int type)
	{
		CRMEntities cRMEntities = null;
		List<ProductGroupPictureModel> list = new List<ProductGroupPictureModel>();
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					try
					{
						_ = DateTime.Now;
						cRMEntities = new CRMEntities();
						List<MobspSelectProductGroupPictureInMode_Result> list2 = Enumerable.ToList<MobspSelectProductGroupPictureInMode_Result>((IEnumerable<MobspSelectProductGroupPictureInMode_Result>)cRMEntities.MobspSelectProductGroupPictureInMode(showMode, type));
						if (list2 != null)
						{
							foreach (MobspSelectProductGroupPictureInMode_Result item in list2)
							{
								if (item.PrdGroupPic == null)
								{
									continue;
								}
								string text = "";
								string downloadLink = "";
								byte[] array = null;
								array = item.PrdGroupPic;
								new MemoryStream();
								MemoryStream memoryStream = new MemoryStream(array, writable: false);
								Image.FromStream((Stream)memoryStream);
								memoryStream.Dispose();
								FilesManager filesManager = new FilesManager();
								string text2 = filesManager.SetNameDirectory(token2.userId);
								if (!string.IsNullOrEmpty(text2) && filesManager.CreateDirectory(text2))
								{
									text = HttpContext.Current.Server.MapPath(text2 + "/" + item.PrdGroupId + ".jpg");
									string[] array2 = HttpContext.Current.Request.Url.AbsoluteUri.Split(new string[1] { "/api/" }, StringSplitOptions.None);
									if (array2 != null)
									{
										downloadLink = ((array2[0] != null && array2[0] != "") ? (array2[0] + text2 + "/" + item.PrdGroupId + ".jpg") : "");
									}
								}
								if (CRM.General.IO.File.SaveBytesToFile(text, array) && System.IO.File.Exists(text))
								{
									ProductGroupPictureModel productGroupPictureModel = new ProductGroupPictureModel();
									productGroupPictureModel.DownloadLink = downloadLink;
									productGroupPictureModel.PrdGroupId = item.PrdGroupId;
									productGroupPictureModel.ProductGroupPictureId = item.ProductGroupPictureId;
									list.Add(productGroupPictureModel);
								}
							}
							message = Messages.MobMsgSuccessAction;
							status = ServiceResultStatus.Success;
						}
						else
						{
							list = null;
							message = Messages.MobMsgErrorDoneOperation;
							status = ServiceResultStatus.Error;
						}
					}
					catch (Exception e)
					{
						message = Messages.MobMsgErrorDoneOperation;
						list = null;
						status = ServiceResultStatus.Error;
						ErrorSignal.FromCurrentContext().Raise(e);
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					list = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				list = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e2)
		{
			message = Messages.MobMsgErrorDoneOperation;
			list = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<ProductGroupPictureModel>>
		{
			Message = message,
			Data = list,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<ProductGroupPictureModel>> SelectProductGroupPictureInModeFromFTP(int showMode, int type)
	{
		CRMEntities cRMEntities = null;
		List<ProductGroupPictureModel> list = new List<ProductGroupPictureModel>();
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					try
					{
						_ = DateTime.Now;
						cRMEntities = new CRMEntities();
						List<MobspSelectProductGroupPictureInMode_Result> list2 = Enumerable.ToList<MobspSelectProductGroupPictureInMode_Result>((IEnumerable<MobspSelectProductGroupPictureInMode_Result>)cRMEntities.MobspSelectProductGroupPictureInMode(showMode, type));
						if (list2 != null)
						{
							foreach (MobspSelectProductGroupPictureInMode_Result item in list2)
							{
								if (item.FilePath != null)
								{
									item.FilePath = Product.GetProductPictureFilePath(item.FilePath, item.FileName, item.FolderName);
									if (item.FileName != "")
									{
										ProductGroupPictureModel productGroupPictureModel = new ProductGroupPictureModel();
										productGroupPictureModel.DownloadLink = item.FilePath;
										productGroupPictureModel.PrdGroupId = item.PrdGroupId;
										productGroupPictureModel.ProductGroupPictureId = item.ProductGroupPictureId;
										list.Add(productGroupPictureModel);
									}
								}
							}
							message = Messages.MobMsgSuccessAction;
							status = ServiceResultStatus.Success;
						}
						else
						{
							list = null;
							message = Messages.MobMsgErrorDoneOperation;
							status = ServiceResultStatus.Error;
						}
					}
					catch (Exception e)
					{
						message = Messages.MobMsgErrorDoneOperation;
						list = null;
						status = ServiceResultStatus.Error;
						ErrorSignal.FromCurrentContext().Raise(e);
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					list = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				list = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e2)
		{
			message = Messages.MobMsgErrorDoneOperation;
			list = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<ProductGroupPictureModel>>
		{
			Message = message,
			Data = list,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<ProductPictureViewModel>> SelectProductPicture(int PrdKind, int ShowMode, int? prdId = null, int? PrdGroupId = null, int? FirstGroupId = null, int? CompanyId = null, int? ProjectId = null, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<ProductPictureViewModel> list = new List<ProductPictureViewModel>();
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					try
					{
						_ = DateTime.Now;
						cRMEntities = new CRMEntities();
						List<MobspSelectProductPicture_Result> list2 = Enumerable.ToList<MobspSelectProductPicture_Result>((IEnumerable<MobspSelectProductPicture_Result>)cRMEntities.MobspSelectProductPicture(prdId, PrdGroupId, FirstGroupId, PrdKind, ShowMode, CompanyId, ProjectId, result, result2));
						if (list2 != null)
						{
							foreach (MobspSelectProductPicture_Result item in list2)
							{
								if (item.PrdFirstPic == null)
								{
									continue;
								}
								string text = "";
								string downloadLink = "";
								byte[] array = null;
								array = item.PrdFirstPic;
								new MemoryStream();
								MemoryStream memoryStream = new MemoryStream(array, writable: false);
								Image.FromStream((Stream)memoryStream);
								memoryStream.Dispose();
								FilesManager filesManager = new FilesManager();
								string text2 = filesManager.SetNameDirectory(token2.userId);
								if (!string.IsNullOrEmpty(text2) && filesManager.CreateDirectory(text2))
								{
									text = HttpContext.Current.Server.MapPath(text2 + "/" + item.PrdId + ".jpg");
									string[] array2 = HttpContext.Current.Request.Url.AbsoluteUri.Split(new string[1] { "/api/" }, StringSplitOptions.None);
									if (array2 != null)
									{
										downloadLink = ((array2[0] != null && array2[0] != "") ? (array2[0] + text2 + "/" + item.PrdId + ".jpg") : "");
									}
								}
								if (CRM.General.IO.File.SaveBytesToFile(text, array) && System.IO.File.Exists(text))
								{
									ProductPictureViewModel productPictureViewModel = new ProductPictureViewModel();
									productPictureViewModel.DownloadLink = downloadLink;
									productPictureViewModel.ProductId = item.PrdId;
									productPictureViewModel.ProductPictureId = item.PrdPictureID;
									list.Add(productPictureViewModel);
								}
							}
							message = Messages.MobMsgSuccessAction;
							status = ServiceResultStatus.Success;
						}
						else
						{
							list = null;
							message = Messages.MobMsgErrorDoneOperation;
							status = ServiceResultStatus.Error;
						}
					}
					catch (Exception e)
					{
						message = Messages.MobMsgErrorDoneOperation;
						list = null;
						status = ServiceResultStatus.Error;
						ErrorSignal.FromCurrentContext().Raise(e);
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					list = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				list = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e2)
		{
			message = Messages.MobMsgErrorDoneOperation;
			list = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<ProductPictureViewModel>>
		{
			Message = message,
			Data = list,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> GetNewsPicture(int newsId)
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
				if (new Common().GetToken(token) != null)
				{
					try
					{
						if (newsId > 0)
						{
							MobspCmsSelectNewsPicture_Result mobspCmsSelectNewsPicture_Result = Enumerable.FirstOrDefault<MobspCmsSelectNewsPicture_Result>((IEnumerable<MobspCmsSelectNewsPicture_Result>)new CRMEntities().MobspCmsSelectNewsPicture(0, -110, newsId, num, result));
							string filePath = mobspCmsSelectNewsPicture_Result.FilePath;
							string filePath2 = mobspCmsSelectNewsPicture_Result.FilePath;
							filePath2 = filePath2.Replace(Mobile.Classes.Configuration.MainDirectoryPath, "/");
							filePath2 = "~" + filePath2;
							string text3 = HttpContext.Current.Server.MapPath(filePath2);
							if (!System.IO.File.Exists(text3))
							{
								if (DownlaodFile(filePath, filePath2))
								{
									mobspCmsSelectNewsPicture_Result.FilePath = filePath2;
								}
								else
								{
									mobspCmsSelectNewsPicture_Result.FilePath = "";
								}
							}
							else
							{
								mobspCmsSelectNewsPicture_Result.FilePath = filePath2;
							}
							if (string.IsNullOrEmpty(text3))
							{
								text2 = Messages.MobMsgErrorFileNotExist;
								text = null;
								serviceResultStatus = ServiceResultStatus.Success;
							}
							else
							{
								text = mobspCmsSelectNewsPicture_Result.FilePath;
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

	private bool DownlaodFile(string sourceFile, string distinitionFile)
	{
		throw new NotImplementedException();
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<FileDirectoryViewModel>> SelectNewsFilesDirectory(string masterId, string detailId, string subDetailId, string fileDirectoryTypeOprId, string typeOprObjectId, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<FileDirectoryViewModel> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					try
					{
						cRMEntities = new CRMEntities();
						List<MobspSelectNewsFilesDirectory_Result> list = Enumerable.ToList<MobspSelectNewsFilesDirectory_Result>((IEnumerable<MobspSelectNewsFilesDirectory_Result>)cRMEntities.MobspSelectNewsFilesDirectory(masterId, detailId, subDetailId, fileDirectoryTypeOprId, typeOprObjectId, result, result2));
						List<FileDirectoryViewModel> list2 = new List<FileDirectoryViewModel>();
						foreach (MobspSelectNewsFilesDirectory_Result item in list)
						{
							FileDirectoryViewModel fileDirectoryViewModel = new FileDirectoryViewModel();
							fileDirectoryViewModel.FileDirectoryID = item.FileDirectoryID;
							fileDirectoryViewModel.FileDirectoryTypeId = item.FileDirectoryTypeId.GetValueOrDefault();
							fileDirectoryViewModel.MasterId = item.MasterId.GetValueOrDefault();
							fileDirectoryViewModel.DetailId = item.DetailId.GetValueOrDefault();
							fileDirectoryViewModel.SubDetailId = item.SubDetailId.GetValueOrDefault();
							fileDirectoryViewModel.TypeOprObjectId = item.TypeOprObjectId.GetValueOrDefault();
							fileDirectoryViewModel.Title = item.Title ?? "";
							fileDirectoryViewModel.FileName = item.FileName ?? "";
							int result3 = 0;
							int.TryParse(item.FileDirectoryID.ToString(), out result3);
							fileDirectoryViewModel.FilePath = "";
							fileDirectoryViewModel.DocDate = (item.DocDateTime ?? DateTime.Now).ToString("yyyy/MM/dd", new CultureInfo("en-US"));
							fileDirectoryViewModel.DocDatePersian = DateTimeClass.ConvertDateWoSlashToSlash(item.DocDate);
							fileDirectoryViewModel.DocDay = item.DocDay ?? "";
							fileDirectoryViewModel.DocDayPersian = (item.DocDateTime ?? DateTime.Now).ToString("dddd", new PersianCulture());
							fileDirectoryViewModel.DocTime = item.DocTime ?? "";
							fileDirectoryViewModel.FileDirectoryType = item.FileDirectoryType ?? "";
							fileDirectoryViewModel.ProjectTitle = item.prjTitle ?? "";
							fileDirectoryViewModel.CompanyName = "";
							fileDirectoryViewModel.FileDirectoryTypeOprId = item.FileDirectoryTypeOprId.GetValueOrDefault();
							fileDirectoryViewModel.FileDirectoryTypeOpr = item.FileDirectoryTypeOpr ?? "";
							fileDirectoryViewModel.otherFields = null;
							fileDirectoryViewModel.otherFieldsHeader = null;
							list2.Add(fileDirectoryViewModel);
						}
						data = list2;
						message = "";
						status = ServiceResultStatus.Success;
					}
					catch (Exception e)
					{
						message = Messages.MobMsgErrorDoneOperation;
						data = null;
						status = ServiceResultStatus.Error;
						ErrorSignal.FromCurrentContext().Raise(e);
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
		catch (Exception e2)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<FileDirectoryViewModel>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public async Task<ServiceResult<FileUploadResultViewModel>> DyUploadIntoTemplate()
	{
		int result = 1065;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangId);
		CRMEntities db = null;
		FileUploadResultViewModel data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : defLangId);
		baseInfo.SetCulture(culture);
		try
		{
			if (!base.Request.Content.IsMimeMultipartContent())
			{
				ServiceResult<FileUploadResultViewModel> serviceResult = new ServiceResult<FileUploadResultViewModel>();
				HttpStatusCode val = (HttpStatusCode)415;
				serviceResult.Message = ((object)(HttpStatusCode)(ref val)).ToString();
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (base.Request.Headers.Contains("token"))
			{
				string token2 = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token = new Common().GetToken(token2);
				if (token != null)
				{
					db = new CRMEntities();
					DateTime dt = DateTime.Now;
					_ = Labels.MobPersonLabel;
					string registerDatePersian = dt.ToString("yyyyMMdd", new PersianCulture());
					short.Parse(Financial.Get().Id.ToString());
					short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					_ = Messages.MobConversationErjaShow;
					string appType = Mobile.Classes.Configuration.AppType;
					_ = Mobile.Classes.Configuration.FacadeFtp;
					_ = Mobile.Classes.Configuration.PathFtp;
					_ = Mobile.Classes.Configuration.UserNameFtp;
					_ = Mobile.Classes.Configuration.PasswordFtp;
					_ = Mobile.Classes.Configuration.UsePassiveFtp;
					string text = Mobile.Classes.Configuration.HostTempFilesPath + "/" + Mobile.Classes.Configuration.DyFormFileTmpDirectoryPath;
					string text2 = HttpContext.Current.Server.MapPath(text);
					if (!System.IO.Directory.Exists(text2))
					{
						System.IO.Directory.CreateDirectory(text2);
						CRM.General.IO.Directory.SetFullControlForEveryOne(text2);
					}
					string pathDirPrivateUser2 = HttpContext.Current.Server.MapPath(text + token.userId + "/");
					if (!System.IO.Directory.Exists(pathDirPrivateUser2))
					{
						System.IO.Directory.CreateDirectory(pathDirPrivateUser2);
						CRM.General.IO.Directory.SetFullControlForEveryOne(pathDirPrivateUser2);
					}
					pathDirPrivateUser2 = HttpContext.Current.Server.MapPath(text + token.userId + "/" + dt.ToString("yyyyMMddHHmmss", new CultureInfo("en-US")) + "/");
					if (!System.IO.Directory.Exists(pathDirPrivateUser2))
					{
						System.IO.Directory.CreateDirectory(pathDirPrivateUser2);
						CRM.General.IO.Directory.SetFullControlForEveryOne(pathDirPrivateUser2);
					}
					CustomMultipartFormDataStreamProvider provider = new CustomMultipartFormDataStreamProvider(pathDirPrivateUser2);
					try
					{
						data = new FileUploadResultViewModel();
						await base.Request.Content.ReadAsMultipartAsync(provider);
						int? objectIdI = null;
						int? objectIdII = null;
						string text3 = "";
						string[] allKeys = provider.FormData.AllKeys;
						foreach (string text4 in allKeys)
						{
							string[] values = provider.FormData.GetValues(text4);
							foreach (string text5 in values)
							{
								switch (text4)
								{
								case "LangId":
									int.TryParse(text5, out result);
									break;
								case "MainFormId":
									objectIdI = ((!string.IsNullOrEmpty(text5)) ? new int?(int.Parse(text5)) : null);
									break;
								case "FieldId":
									objectIdII = ((!string.IsNullOrEmpty(text5)) ? new int?(int.Parse(text5)) : null);
									break;
								case "FileName":
									text3 = text5;
									break;
								}
							}
						}
						string copyFromPath = Path.Combine(pathDirPrivateUser2, text3);
						ObjectParameter objectParameter = new ObjectParameter("InsertedId", 0);
						db.MobspInsertFilesDirectoryTemplate(text3, copyFromPath, token.userId, 3, -65, null, objectIdI, objectIdII, dt, registerDatePersian, appType, defLangId, objectParameter);
						int result2 = 0;
						if (objectParameter != null)
						{
							int.TryParse(objectParameter.Value.ToString(), out result2);
							data.FileId = result2;
						}
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					catch (Exception ex)
					{
						message = Messages.MobMsgErrorDoneOperation + " (" + ex.Message + ")";
						data = null;
						status = ServiceResultStatus.Error;
						ErrorSignal.FromCurrentContext().Raise(ex);
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
		catch (Exception ex2)
		{
			message = Messages.MobMsgErrorDoneOperation + " (" + ex2.Message + ")";
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex2);
		}
		finally
		{
			db?.Dispose();
		}
		return new ServiceResult<FileUploadResultViewModel>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public async Task<ServiceResult<int>> UploadDyFormFile()
	{
		int result = 1065;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangId);
		CRMEntities db = null;
		int data = 0;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : defLangId);
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
				Token token = new Common().GetToken(token2);
				if (token != null)
				{
					DateTime dt = DateTime.Now;
					string registerDatePersian = dt.ToString("yyyyMMdd", new PersianCulture());
					short year1 = short.Parse(Financial.Get().Id.ToString());
					short month1 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					_ = Messages.MobConversationErjaShow;
					string appType = Mobile.Classes.Configuration.AppType;
					string facadeFtp = Mobile.Classes.Configuration.FacadeFtp;
					string pathFtp = Mobile.Classes.Configuration.PathFtp;
					string userNameFtp = Mobile.Classes.Configuration.UserNameFtp;
					string passwordFtp = Mobile.Classes.Configuration.PasswordFtp;
					bool usePassiveFtp = Mobile.Classes.Configuration.UsePassiveFtp;
					List<MobspSelectLanguages_Result> langList = Enumerable.ToList<MobspSelectLanguages_Result>((IEnumerable<MobspSelectLanguages_Result>)db.MobspSelectLanguages());
					string text = Mobile.Classes.Configuration.HostTempFilesPath + "/" + Mobile.Classes.Configuration.UploadFileDirectoryPath;
					string text2 = HttpContext.Current.Server.MapPath(text);
					if (!System.IO.Directory.Exists(text2))
					{
						System.IO.Directory.CreateDirectory(text2);
						CRM.General.IO.Directory.SetFullControlForEveryOne(text2);
					}
					string pathDirPrivateUser = HttpContext.Current.Server.MapPath(text + token.userId + "/");
					if (!System.IO.Directory.Exists(pathDirPrivateUser))
					{
						System.IO.Directory.CreateDirectory(pathDirPrivateUser);
						CRM.General.IO.Directory.SetFullControlForEveryOne(pathDirPrivateUser);
					}
					pathDirPrivateUser = HttpContext.Current.Server.MapPath(text + token.userId + "/" + dt.ToString("yyyyMMddHHmmss", new CultureInfo("en-US")) + "/");
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
								int? centerId = null;
								int userId = token.userId;
								int? masterId = null;
								int? detailId = null;
								int? subDetailId = null;
								int? num = null;
								int? typeOprObjectIdI = null;
								int? orderView = null;
								FacadeFTP facadeFTP = new FacadeFTP(facadeFtp);
								_ = Mobile.Classes.Configuration.MainDirectoryPath;
								string fileName = Path.GetFileName(fileDatum.LocalFileName);
								string[] allKeys = provider.FormData.AllKeys;
								foreach (string text3 in allKeys)
								{
									string[] values = provider.FormData.GetValues(text3);
									foreach (string text4 in values)
									{
										switch (text3)
										{
										case "LangId":
											int.TryParse(text4, out result);
											break;
										case "masterId":
											masterId = ((!string.IsNullOrEmpty(text4)) ? new int?(int.Parse(text4)) : null);
											break;
										case "detailId":
											detailId = ((!string.IsNullOrEmpty(text4)) ? new int?(int.Parse(text4)) : null);
											break;
										case "subDetailId":
											subDetailId = ((!string.IsNullOrEmpty(text4)) ? new int?(int.Parse(text4)) : null);
											break;
										case "typeOprObjectId":
											num = ((!string.IsNullOrEmpty(text4)) ? new int?(int.Parse(text4)) : null);
											break;
										case "typeOprObjectIdI":
											typeOprObjectIdI = ((!string.IsNullOrEmpty(text4)) ? new int?(int.Parse(text4)) : null);
											break;
										case "orderView":
											orderView = ((!string.IsNullOrEmpty(text4)) ? new int?(int.Parse(text4)) : null);
											break;
										case "centerId":
											centerId = ((!string.IsNullOrEmpty(text4)) ? new int?(int.Parse(text4)) : null);
											break;
										}
									}
								}
								string text5 = (masterId.HasValue ? masterId.ToString() : (Mobile.Classes.Configuration.DyDirectoryPath + typeOprObjectIdI));
								string folderName = (masterId.HasValue ? masterId.ToString() : typeOprObjectIdI.ToString());
								string title_Lang = "";
								List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
								foreach (MobspSelectLanguages_Result item in Enumerable.ToList<MobspSelectLanguages_Result>(Enumerable.Where<MobspSelectLanguages_Result>((IEnumerable<MobspSelectLanguages_Result>)langList, (Func<MobspSelectLanguages_Result, bool>)((MobspSelectLanguages_Result c) => c.LanguageID != defLangId))))
								{
									list.Add(new CommonMultiLanguageViewModel
									{
										Value = fileName,
										LanguageId = item.LanguageID
									});
								}
								if (list != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list))
								{
									title_Lang = JsonConvert.SerializeObject(list);
								}
								string docTime = dt.ToString("HH:mm:ss");
								int result2 = 0;
								MobspInsertFilesDirectory_Result mobspInsertFilesDirectory_Result = Enumerable.FirstOrDefault<MobspInsertFilesDirectory_Result>((IEnumerable<MobspInsertFilesDirectory_Result>)db.MobspInsertFilesDirectory(0, -60, masterId, detailId, subDetailId, fileName, title_Lang, folderName, "", "", "", userId, year1, month1, dt, registerDatePersian, dt, registerDatePersian, PersianDate.GetNumberWeekOfDay(dt.ToString("yyyy/MM/dd", new PersianCulture())).ToString(), docTime, num, appType, defLangId, orderView, typeOprObjectIdI, null, "", null, null, centerId));
								if (mobspInsertFilesDirectory_Result != null)
								{
									int.TryParse(mobspInsertFilesDirectory_Result.FileId.ToString(), out result2);
								}
								if (result2 <= 0)
								{
									continue;
								}
								string[] array = fileName.Split(new char[1] { '.' });
								string text6 = Mobile.Classes.Configuration.MainDirectoryPath + text5 + "/";
								string text7 = text6 + (text6.EndsWith("/") ? "" : "/");
								string text8 = text7.Split(new char[1] { '/' })[^2];
								string text9 = text7.Replace(text8 + "/", "");
								string pathFtp2 = Mobile.Classes.Configuration.PathFtp;
								string userNameFtp2 = Mobile.Classes.Configuration.UserNameFtp;
								string passwordFtp2 = Mobile.Classes.Configuration.PasswordFtp;
								bool usePassiveFtp2 = Mobile.Classes.Configuration.UsePassiveFtp;
								bool flag;
								if (!masterId.HasValue)
								{
									flag = facadeFTP.ExistsDirectoryInFtp(pathFtp2, userNameFtp2, passwordFtp2, Mobile.Classes.Configuration.MainDirectoryPath, Mobile.Classes.Configuration.DyDirectoryPath, usePassiveFtp2);
									if (!flag)
									{
										flag = facadeFTP.CreateDirectoryInFtp(pathFtp2, userNameFtp2, passwordFtp2, Mobile.Classes.Configuration.MainDirectoryPath, Mobile.Classes.Configuration.DyDirectoryPath, usePassiveFtp2);
									}
								}
								else
								{
									flag = true;
								}
								bool flag2 = facadeFTP.ExistsDirectoryInFtp(pathFtp2, userNameFtp2, passwordFtp2, text9, text8, usePassiveFtp2);
								if (!flag2)
								{
									flag2 = facadeFTP.CreateDirectoryInFtp(pathFtp2, userNameFtp2, passwordFtp2, text9, text8, usePassiveFtp2);
								}
								if (flag2 && flag)
								{
									string[] array2 = new string[5];
									int? num2 = num;
									array2[0] = num2.ToString();
									array2[1] = "-";
									array2[2] = result2.ToString();
									array2[3] = ".";
									array2[4] = array[^1];
									string text10 = string.Concat(array2);
									if (facadeFTP.UploadFtpFormTable(pathFtp, userNameFtp, passwordFtp, text6 + text10, fileDatum.LocalFileName, usePassiveFtp))
									{
										text6 = pathFtp2 + text7 + text10;
										string fileName2 = text10;
										text6 = text6.Trim().Replace(pathFtp2, "");
										Enumerable.FirstOrDefault<MobspInsertFilesDirectory_Result>((IEnumerable<MobspInsertFilesDirectory_Result>)db.MobspInsertFilesDirectory(result2, -60, masterId, detailId, subDetailId, fileName, title_Lang, folderName, fileName2, text6, "", userId, year1, month1, dt, registerDatePersian, dt, registerDatePersian, PersianDate.GetNumberWeekOfDay(dt.ToString("yyyy/MM/dd", new PersianCulture())).ToString(), docTime, num, appType, defLangId, orderView, typeOprObjectIdI, null, "", null, null, centerId));
										data = result2;
										message = Messages.MobMsgSuccessAction;
										status = ServiceResultStatus.Success;
										continue;
									}
									Exception e = new Exception(Messages.msgErrorUploadingFileInFtp + "  -  hostname: " + pathFtp2 + " ,username: " + userNameFtp2 + " ,destination: " + text9 + " ,directoryName: " + text8);
									ErrorSignal.FromCurrentContext().Raise(e);
									base.ModelState.AddModelError("error", Messages.frmErrorInSendingFile);
									try
									{
										db.MobspDeleteCrmFilesDirectory(result2);
									}
									catch (Exception e2)
									{
										ErrorSignal.FromCurrentContext().Raise(e2);
									}
									message = Messages.frmErrorInSendingFile;
									status = ServiceResultStatus.Fail;
								}
								else
								{
									Exception e3 = new Exception(Messages.msgErrorCreateFolderInFtp + " -  hostname: " + pathFtp2 + " ,username: " + userNameFtp2 + " ,destination: " + text9 + " ,directoryName: " + text8);
									ErrorSignal.FromCurrentContext().Raise(e3);
									base.ModelState.AddModelError("error", Messages.frmErrorInSendingFile);
									try
									{
										db.MobspDeleteCrmFilesDirectory(result2);
									}
									catch (Exception e4)
									{
										ErrorSignal.FromCurrentContext().Raise(e4);
									}
									message = Messages.frmErrorInSendingFile;
									status = ServiceResultStatus.Fail;
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
	[MobileAuthorize]
	public ServiceResult<string> GetLinkDownloadSysSettingCoLogo()
	{
		int num = 1065;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		CRMEntities cRMEntities = null;
		string data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((num > 0) ? num : result);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					try
					{
						_ = DateTime.Now;
						string text = "";
						string text2 = "";
						cRMEntities = new CRMEntities();
						byte[] array = null;
						MobspSelectCrmsysSetting_Result mobspSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<MobspSelectCrmsysSetting_Result>((IEnumerable<MobspSelectCrmsysSetting_Result>)cRMEntities.MobspSelectCrmsysSetting(num, result));
						if (mobspSelectCrmsysSetting_Result != null)
						{
							if (mobspSelectCrmsysSetting_Result.CoLoGo != null)
							{
								array = mobspSelectCrmsysSetting_Result.CoLoGo;
								new MemoryStream();
								MemoryStream memoryStream = new MemoryStream(array, writable: false);
								Image.FromStream((Stream)memoryStream);
								memoryStream.Dispose();
								FilesManager filesManager = new FilesManager();
								string text3 = filesManager.SetNameDirectory(token2.userId);
								if (!string.IsNullOrEmpty(text3) && filesManager.CreateDirectory(text3))
								{
									text = HttpContext.Current.Server.MapPath(text3 + "/CoLogo.jpg");
									string[] array2 = HttpContext.Current.Request.Url.AbsoluteUri.Split(new string[1] { "/api/" }, StringSplitOptions.None);
									if (array2 != null)
									{
										text2 = ((array2[0] != null && array2[0] != "") ? (array2[0] + text3 + "/CoLogo.jpg") : "");
									}
								}
								if (text != "" && text != null)
								{
									if (CRM.General.IO.File.SaveBytesToFile(text, array))
									{
										if (System.IO.File.Exists(text))
										{
											data = text2;
											message = Messages.MobMsgSuccessAction;
											status = ServiceResultStatus.Success;
										}
										else
										{
											message = Messages.MobMsgErrorDoneOperation;
											data = null;
											status = ServiceResultStatus.Error;
										}
									}
									else
									{
										message = Messages.MobMsgErrorDoneOperation;
										data = null;
										status = ServiceResultStatus.Error;
									}
								}
								else
								{
									message = Messages.MobMsgErrorDoneOperation;
									data = null;
									status = ServiceResultStatus.Error;
								}
							}
							else
							{
								data = "No Picture";
								message = Messages.MobMsgSuccessAction;
								status = ServiceResultStatus.Success;
							}
						}
						else
						{
							data = "No Picture";
							message = Messages.MobMsgSuccessAction;
							status = ServiceResultStatus.Success;
						}
					}
					catch (Exception e)
					{
						message = Messages.MobMsgErrorDoneOperation;
						data = null;
						status = ServiceResultStatus.Error;
						ErrorSignal.FromCurrentContext().Raise(e);
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
		catch (Exception e2)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e2);
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
	[MobileAuthorize]
	public ServiceResult<string> GetLinkDownloadCoLogoMobApp()
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
				if (new Common().GetToken(token) != null)
				{
					try
					{
						string coLogoMobAppPath = new Files().GetCoLogoMobAppPath(num2, result);
						if (string.IsNullOrEmpty(coLogoMobAppPath))
						{
							text2 = Messages.MobMsgErrorFileNotExist;
							text = null;
							serviceResultStatus = ServiceResultStatus.Error;
						}
						else
						{
							text = coLogoMobAppPath;
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

	[HttpPost]
	[MobileAuthorize]
	public async Task<ServiceResult<FileUploadResultViewModel>> UploadEmailFile()
	{
		int LangId = 1065;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		CRMEntities db = null;
		CRMSpEntities dbI = null;
		FileUploadResultViewModel data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((LangId > 0) ? LangId : result);
		baseInfo.SetCulture(culture);
		try
		{
			db = new CRMEntities();
			dbI = new CRMSpEntities();
			if (!base.Request.Content.IsMimeMultipartContent())
			{
				ServiceResult<FileUploadResultViewModel> serviceResult = new ServiceResult<FileUploadResultViewModel>();
				HttpStatusCode val = (HttpStatusCode)415;
				serviceResult.Message = ((object)(HttpStatusCode)(ref val)).ToString();
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					DateTime now = DateTime.Now;
					_ = Labels.MobPersonLabel;
					DateTime registerDate = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short.Parse(Financial.Get().Id.ToString());
					short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					_ = Messages.MobConversationErjaShow;
					string appType = Mobile.Classes.Configuration.AppType;
					string facadeFtp = Mobile.Classes.Configuration.FacadeFtp;
					string pathFtp = Mobile.Classes.Configuration.PathFtp;
					string userNameFtp = Mobile.Classes.Configuration.UserNameFtp;
					string passwordFtp = Mobile.Classes.Configuration.PasswordFtp;
					bool usePassiveFtp = Mobile.Classes.Configuration.UsePassiveFtp;
					int userId = token2.userId;
					string text = Mobile.Classes.Configuration.HostTempFilesPath + "/" + Mobile.Classes.Configuration.UploadFileDirectoryPath;
					string text2 = HttpContext.Current.Server.MapPath(text);
					if (!System.IO.Directory.Exists(text2))
					{
						System.IO.Directory.CreateDirectory(text2);
						CRM.General.IO.Directory.SetFullControlForEveryOne(text2);
					}
					string pathDirPrivateUser2 = HttpContext.Current.Server.MapPath(text + token2.userId + "/");
					if (!System.IO.Directory.Exists(pathDirPrivateUser2))
					{
						System.IO.Directory.CreateDirectory(pathDirPrivateUser2);
						CRM.General.IO.Directory.SetFullControlForEveryOne(pathDirPrivateUser2);
					}
					pathDirPrivateUser2 = HttpContext.Current.Server.MapPath(text + token2.userId + "/" + now.ToString("yyyyMMddHHmmss", new CultureInfo("en-US")) + "/");
					if (!System.IO.Directory.Exists(pathDirPrivateUser2))
					{
						System.IO.Directory.CreateDirectory(pathDirPrivateUser2);
						CRM.General.IO.Directory.SetFullControlForEveryOne(pathDirPrivateUser2);
					}
					CustomMultipartFormDataStreamProvider provider = new CustomMultipartFormDataStreamProvider(pathDirPrivateUser2);
					new List<string>();
					try
					{
						await base.Request.Content.ReadAsMultipartAsync(provider);
						foreach (MultipartFileData fileDatum in provider.FileData)
						{
							if (System.IO.File.Exists(fileDatum.LocalFileName))
							{
								int num = 0;
								string[] allKeys = provider.FormData.AllKeys;
								foreach (string text3 in allKeys)
								{
									string[] values = provider.FormData.GetValues(text3);
									foreach (string text4 in values)
									{
										if (text3 == "EmailSendHeaderId")
										{
											num = ((!string.IsNullOrEmpty(text4)) ? int.Parse(text4) : 0);
										}
									}
								}
								MobspSelectEmailSetting_Result mobspSelectEmailSetting_Result = Enumerable.FirstOrDefault<MobspSelectEmailSetting_Result>((IEnumerable<MobspSelectEmailSetting_Result>)db.MobspSelectEmailSetting("", ""));
								if (mobspSelectEmailSetting_Result == null)
								{
									return new ServiceResult<FileUploadResultViewModel>
									{
										Message = Messages.MobMsgEmailSettingNotFound,
										Data = null,
										Status = ServiceResultStatus.Error
									};
								}
								if (num == 0)
								{
									return new ServiceResult<FileUploadResultViewModel>
									{
										Message = Messages.MobMsgEmailNotDefined,
										Data = null,
										Status = ServiceResultStatus.Error
									};
								}
								string text5 = ((mobspSelectEmailSetting_Result.EmailsAttachFilePath == null) ? "" : (mobspSelectEmailSetting_Result.EmailsAttachFilePath + (mobspSelectEmailSetting_Result.EmailsAttachFilePath.EndsWith("\\") ? "" : "\\")));
								string text6 = ((mobspSelectEmailSetting_Result.EmailsAttachShareFilePathFtp == null) ? "" : (mobspSelectEmailSetting_Result.EmailsAttachShareFilePathFtp + (mobspSelectEmailSetting_Result.EmailsAttachShareFilePathFtp.EndsWith("/") ? "" : "/")));
								string text7 = Path.GetFileName(fileDatum.LocalFileName).Split(new char[1] { '.' })[^1];
								RandomText randomText = new RandomText();
								string text8 = num + "-" + randomText.CreateRandomCode(5, WithNumber: true, false).Replace(" ", "").Trim() + "-" + DateTime.Now.ToString("yyyyMMdd") + "-" + DateTime.Now.ToString("HHmmss") + "." + text7.Replace(".", "");
								string text9 = text5 + text8;
								string destination = text6 + text8;
								if (new FacadeFTP(facadeFtp).UploadFtpFormTable(pathFtp, userNameFtp, passwordFtp, destination, fileDatum.LocalFileName, usePassiveFtp))
								{
									dbI.MobspInsertEmailSendAttachment(num, text8, text9, registerDate, registerDatePersian, appType, LangId, userId);
									message = Messages.MobMsgSuccessAction;
									status = ServiceResultStatus.Success;
									continue;
								}
								Exception e = new Exception(Messages.msgErrorUploadingFileInFtp + "  -  hostname: " + pathFtp + " ,username: " + userNameFtp + " ,destination: " + text9);
								ErrorSignal.FromCurrentContext().Raise(e);
								message = Messages.frmErrorInSendingFile;
								status = ServiceResultStatus.Fail;
							}
							else
							{
								message = Messages.MobMsgErrorFileNotExist;
								data = null;
								status = ServiceResultStatus.Error;
							}
						}
					}
					catch (Exception ex)
					{
						message = Messages.MobMsgErrorDoneOperation + " (" + ex.Message + ")";
						data = null;
						status = ServiceResultStatus.Error;
						ErrorSignal.FromCurrentContext().Raise(ex);
					}
					finally
					{
						db?.Dispose();
						if (!string.IsNullOrEmpty(pathDirPrivateUser2) && System.IO.Directory.Exists(pathDirPrivateUser2))
						{
							DirectoryInfo directoryInfo = new DirectoryInfo(pathDirPrivateUser2);
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
							if (System.IO.Directory.Exists(pathDirPrivateUser2))
							{
								System.IO.Directory.Delete(pathDirPrivateUser2);
							}
						}
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
		catch (Exception ex2)
		{
			message = Messages.MobMsgErrorDoneOperation + " (" + ex2.Message + ")";
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex2);
		}
		finally
		{
			db?.Dispose();
			dbI?.Dispose();
		}
		return new ServiceResult<FileUploadResultViewModel>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}
}
