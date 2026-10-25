using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using CRM.General.IO;
using CRM.General.IO.FTP;
using CRM.General.Security;
using CRM.General.Utilities;
using CRMIdealApi.ApiModels;
using CRMIdealApi.Classes;
using CRMIdealApi.Classes.Helper;
using CRMIdealApi.DataType;
using CRMIdealApi.Resources;
using Elmah;
using GSD.Globalization;

namespace CRMIdealApi.Controllers;

public class ApiProductGalleryController : ApiController
{
	public class ApiCustomMultipartFormDataStreamProvider : MultipartFormDataStreamProvider
	{
		public ApiCustomMultipartFormDataStreamProvider(string path)
			: base(path)
		{
		}

		public override string GetLocalFileName(HttpContentHeaders headers)
		{
			return headers.ContentDisposition.FileName.Replace("\"", string.Empty);
		}
	}

	[HttpPost]
	public async Task<ServiceResult<int>> Insert(int userId = 0)
	{
		CRMEntities db = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<int>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			db = new CRMEntities();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)db.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<int>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var defLangId);
			if (defLangId <= 0)
			{
				defLangId = 1065;
			}
			List<ApispSelectLanguages_Result> langList = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)db.ApispSelectLanguages());
			string defLangCollation = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)langList, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == defLangId));
			if (apispSelectLanguages_Result != null)
			{
				defLangCollation = apispSelectLanguages_Result.LanguageCollation;
			}
			if (!base.Request.Content.IsMimeMultipartContent())
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				HttpStatusCode val = (HttpStatusCode)415;
				serviceResult.Message = ((object)(HttpStatusCode)(ref val)).ToString();
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			string facadeFtp = CRMIdealApi.Classes.Configuration.FacadeFtp;
			_ = CRMIdealApi.Classes.Configuration.PathFtp;
			string userNameFtp = CRMIdealApi.Classes.Configuration.UserNameFtp;
			string passwordFtp = CRMIdealApi.Classes.Configuration.PasswordFtp;
			bool usePassiveFtp = CRMIdealApi.Classes.Configuration.UsePassiveFtp;
			DateTime dt = DateTime.Now;
			string text = CRMIdealApi.Classes.Configuration.HostTempFilesPath + "/" + CRMIdealApi.Classes.Configuration.UploadFileDirectoryPath;
			string text2 = HttpContext.Current.Server.MapPath(text);
			if (!System.IO.Directory.Exists(text2))
			{
				System.IO.Directory.CreateDirectory(text2);
				CRM.General.IO.Directory.SetFullControlForEveryOne(text2);
			}
			string pathDirPrivateUser = HttpContext.Current.Server.MapPath(text + "Api/");
			if (!System.IO.Directory.Exists(pathDirPrivateUser))
			{
				System.IO.Directory.CreateDirectory(pathDirPrivateUser);
				CRM.General.IO.Directory.SetFullControlForEveryOne(pathDirPrivateUser);
			}
			pathDirPrivateUser = HttpContext.Current.Server.MapPath(text + "Api/" + dt.ToString("yyyyMMddHHmmss", new CultureInfo("en-US")) + "/");
			if (!System.IO.Directory.Exists(pathDirPrivateUser))
			{
				System.IO.Directory.CreateDirectory(pathDirPrivateUser);
				CRM.General.IO.Directory.SetFullControlForEveryOne(pathDirPrivateUser);
			}
			ApiCustomMultipartFormDataStreamProvider provider = new ApiCustomMultipartFormDataStreamProvider(pathDirPrivateUser);
			new List<string>();
			try
			{
				await base.Request.Content.ReadAsMultipartAsync(provider);
				if (provider.FileData == null || Enumerable.Count<MultipartFileData>((IEnumerable<MultipartFileData>)provider.FileData) <= 0)
				{
					status = ServiceResultStatus.Error;
					message = MyResource.GetResourceString("ErrorFileNotExist", defLangCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				}
				foreach (MultipartFileData fileDatum in provider.FileData)
				{
					if (System.IO.File.Exists(fileDatum.LocalFileName))
					{
						int value = 0;
						int? orderView = null;
						int languageId = 1065;
						bool? isMain = null;
						string filePath = null;
						string text3 = null;
						string text4 = null;
						_ = CRMIdealApi.Classes.Configuration.MainDirectoryPath;
						Path.GetFileName(fileDatum.LocalFileName);
						string[] allKeys = provider.FormData.AllKeys;
						foreach (string text5 in allKeys)
						{
							string[] values = provider.FormData.GetValues(text5);
							foreach (string text6 in values)
							{
								switch (text5)
								{
								case "LanguageId":
									languageId = ((!string.IsNullOrEmpty(text6)) ? int.Parse(text6) : 1065);
									break;
								case "ApiProductId":
									value = ((!string.IsNullOrEmpty(text6)) ? int.Parse(text6) : 0);
									break;
								case "ApiOrderView":
									orderView = ((!string.IsNullOrEmpty(text6)) ? new int?(int.Parse(text6)) : null);
									break;
								case "ApiIsMain":
									isMain = ((!string.IsNullOrEmpty(text6)) ? new bool?(bool.Parse(text6)) : null);
									break;
								case "UserName":
									text3 = text6;
									break;
								case "Password":
									text4 = text6;
									break;
								}
							}
						}
						apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)langList, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == languageId));
						if (apispSelectLanguages_Result != null)
						{
							defLangCollation = apispSelectLanguages_Result.LanguageCollation;
						}
						if (!string.IsNullOrEmpty(text4))
						{
							text4 = CodeDecode.DeCodding(text4);
						}
						if (!string.IsNullOrEmpty(text3))
						{
							text3 = CodeDecode.DeCodding(text3);
						}
						int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)db.ApispCheckUserAllowed(text3, text4));
						int result = 0;
						int.TryParse(num.ToString(), out result);
						if (result == 0)
						{
							ServiceResult<int> serviceResult2 = new ServiceResult<int>();
							serviceResult2.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", defLangCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", defLangCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
							serviceResult2.Data = 0;
							serviceResult2.Status = ServiceResultStatus.Error;
							return serviceResult2;
						}
						fileDatum.LocalFileName.ToLower();
						string text7 = ((fileDatum.LocalFileName != null) ? Path.GetExtension(fileDatum.LocalFileName).ToLower() : "");
						if (text7 != ".jpg" && text7 != ".png" && text7 != ".gif" && text7 != ".jpeg")
						{
							ServiceResult<int> serviceResult2 = new ServiceResult<int>();
							serviceResult2.Message = MyResource.GetResourceString("ErrorFileIsNotPic", defLangCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", defLangCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
							serviceResult2.Data = 0;
							serviceResult2.Status = ServiceResultStatus.Error;
							return serviceResult2;
						}
						ApispSelectProducts_Result apispSelectProducts_Result = Enumerable.FirstOrDefault<ApispSelectProducts_Result>((IEnumerable<ApispSelectProducts_Result>)db.ApispSelectProducts(value, 0, "", null, null, null, null, languageId, defLangId, 0, 0));
						if (apispSelectProducts_Result != null)
						{
							DateTime value2 = dt;
							string registerDatePersian = dt.ToString("yyyyMMdd", new PersianCulture());
							short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
							string appType = CRMIdealApi.Classes.Configuration.AppType;
							string folderName = apispSelectProducts_Result.ApiPrdFGroupId + "/" + apispSelectProducts_Result.ApiPrdGroupID;
							string fileName = apispSelectProducts_Result.ApiPrdGroupID.ToString();
							ObjectParameter objectParameter = new ObjectParameter("InsertedPrdGalleryId", 0);
							ObjectParameter objectParameter2 = new ObjectParameter("ErrorMessage", "");
							int num2 = db.ApispInsertProductGallery(value, isMain, folderName, fileName, filePath, orderView, 1, value3, userId, value2, registerDatePersian, appType, defLangId, objectParameter, objectParameter2);
							string resourceString = MyResource.GetResourceString("ErrorDoneOperationTryAgain", defLangCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
							string resourceString2 = MyResource.GetResourceString("ErrorTryAgain", defLangCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
							int result2 = 0;
							int.TryParse(num2.ToString(), out result2);
							if (result2 <= 0)
							{
								return new ServiceResult<int>
								{
									Message = resourceString.Replace("<br>", "\r\n"),
									Data = 0,
									Status = ServiceResultStatus.Error
								};
							}
							if (objectParameter2.Value != null && objectParameter2.Value.ToString() != "")
							{
								string text8 = "";
								string text9 = objectParameter2.Value.ToString();
								if (text9.IndexOf("IsUser=0", StringComparison.Ordinal) >= 0)
								{
									_ = text8 + MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", defLangCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<br>";
									resourceString2 = "<br>" + MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", defLangCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString2;
									return new ServiceResult<int>
									{
										Message = resourceString2.Replace("<br>", "\r\n"),
										Data = 0,
										Status = ServiceResultStatus.Error
									};
								}
								if (text9.IndexOf("Not Prd|", StringComparison.Ordinal) >= 0)
								{
									text8 = text8 + string.Format(MyResource.GetResourceString("ErrorItemIsNotEntered", defLangCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Product", defLangCollation, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
									return new ServiceResult<int>
									{
										Message = text8.Replace("<br>", "\r\n"),
										Data = 0,
										Status = ServiceResultStatus.Error
									};
								}
								if (text9.IndexOf("Error", StringComparison.Ordinal) >= 0)
								{
									_ = text8 + resourceString2;
									return new ServiceResult<int>
									{
										Message = resourceString2.Replace("<br>", "\r\n"),
										Data = 0,
										Status = ServiceResultStatus.Error
									};
								}
								continue;
							}
							if (objectParameter == null || objectParameter.Value.ToString() == "0")
							{
								return new ServiceResult<int>
								{
									Message = resourceString.Replace("<br>", "\r\n"),
									Data = 0,
									Status = ServiceResultStatus.Error
								};
							}
							int num3 = ((objectParameter.Value != null) ? int.Parse(objectParameter.Value.ToString() ?? "0") : 0);
							if (num3 <= 0)
							{
								return new ServiceResult<int>
								{
									Message = resourceString.Replace("<br>", "\r\n"),
									Data = 0,
									Status = ServiceResultStatus.Error
								};
							}
							if (fileDatum != null)
							{
								FacadeFTP facadeFTP = new FacadeFTP(facadeFtp);
								string pathFtp = CRMIdealApi.Classes.Configuration.PathFtp;
								string[] array = fileDatum.LocalFileName.Split(new char[1] { '.' });
								fileName = apispSelectProducts_Result.ApiProductID + "-" + num3 + "." + array[^1];
								string mainDirectoryPath = CRMIdealApi.Classes.Configuration.MainDirectoryPath;
								string prdDirectoryPath = CRMIdealApi.Classes.Configuration.PrdDirectoryPath;
								prdDirectoryPath = (prdDirectoryPath.EndsWith("/") ? prdDirectoryPath.TrimEnd(new char[1] { '/' }) : prdDirectoryPath);
								bool flag = facadeFTP.ExistsDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, mainDirectoryPath, prdDirectoryPath, usePassiveFtp);
								if (!flag)
								{
									flag = facadeFTP.CreateDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, CRMIdealApi.Classes.Configuration.MainDirectoryPath, prdDirectoryPath, usePassiveFtp);
								}
								mainDirectoryPath = CRMIdealApi.Classes.Configuration.MainDirectoryPath + CRMIdealApi.Classes.Configuration.PrdDirectoryPath;
								bool flag2 = facadeFTP.ExistsDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, mainDirectoryPath, apispSelectProducts_Result.ApiPrdFGroupId.ToString(), usePassiveFtp);
								if (!flag2)
								{
									flag2 = facadeFTP.CreateDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, mainDirectoryPath, apispSelectProducts_Result.ApiPrdFGroupId.ToString(), usePassiveFtp);
								}
								mainDirectoryPath = CRMIdealApi.Classes.Configuration.MainDirectoryPath + CRMIdealApi.Classes.Configuration.PrdDirectoryPath + apispSelectProducts_Result.ApiPrdFGroupId + "/";
								bool flag3 = facadeFTP.ExistsDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, mainDirectoryPath, apispSelectProducts_Result.ApiPrdGroupID.ToString(), usePassiveFtp);
								if (!flag3)
								{
									flag3 = facadeFTP.CreateDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, mainDirectoryPath, apispSelectProducts_Result.ApiPrdGroupID.ToString(), usePassiveFtp);
								}
								if (!(flag && flag2 && flag3))
								{
									string message2 = MyResource.GetResourceString("ErrorUploadingFileInFtp", defLangCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "  -  hostname: " + CRMIdealApi.Classes.Configuration.PathFtp + " ,username: " + CRMIdealApi.Classes.Configuration.UserNameFtp + " ,destination: " + mainDirectoryPath + fileName;
									Exception e = new Exception(message2);
									ErrorSignal.FromCurrentContext().Raise(e);
									try
									{
										Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)db.ApispDeleteProductGallery(num3));
									}
									catch (Exception e2)
									{
										ErrorSignal.FromCurrentContext().Raise(e2);
									}
									ServiceResult<int> serviceResult2 = new ServiceResult<int>();
									serviceResult2.Message = MyResource.GetResourceString("ErrorInSendingFile", defLangCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
									serviceResult2.Data = 0;
									serviceResult2.Status = ServiceResultStatus.Error;
									return serviceResult2;
								}
								mainDirectoryPath = CRMIdealApi.Classes.Configuration.MainDirectoryPath + CRMIdealApi.Classes.Configuration.PrdDirectoryPath + apispSelectProducts_Result.ApiPrdFGroupId + "/" + apispSelectProducts_Result.ApiPrdGroupID + "/";
								if (!facadeFTP.UploadFtpFormTable(pathFtp, userNameFtp, passwordFtp, mainDirectoryPath + fileName, fileDatum.LocalFileName, usePassiveFtp))
								{
									string message3 = MyResource.GetResourceString("ErrorUploadingFileInFtp", defLangCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "  -  hostname: " + CRMIdealApi.Classes.Configuration.PathFtp + " ,username: " + CRMIdealApi.Classes.Configuration.UserNameFtp + " ,destination: " + mainDirectoryPath + fileName;
									Exception e3 = new Exception(message3);
									ErrorSignal.FromCurrentContext().Raise(e3);
									try
									{
										Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)db.ApispDeleteProductGallery(num3));
									}
									catch (Exception e4)
									{
										ErrorSignal.FromCurrentContext().Raise(e4);
									}
									ServiceResult<int> serviceResult2 = new ServiceResult<int>();
									serviceResult2.Message = MyResource.GetResourceString("ErrorInSendingFile", defLangCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
									serviceResult2.Data = 0;
									serviceResult2.Status = ServiceResultStatus.Error;
									return serviceResult2;
								}
								int num4 = db.ApispUpdateProductGallery(num3, value, null, null, fileName, mainDirectoryPath + fileName, null, 1, userId: userId, month1: value3, registerDate: value2, registerDatePersian: registerDatePersian, appType: appType, errorMessage: objectParameter2);
								int result3 = 0;
								int.TryParse(num4.ToString(), out result3);
								if (result3 < 0 && objectParameter2.Value == null)
								{
									return new ServiceResult<int>
									{
										Message = resourceString.Replace("<br>", "\r\n"),
										Data = 0,
										Status = ServiceResultStatus.Error
									};
								}
								if (objectParameter2.Value != null && objectParameter2.Value.ToString() != "")
								{
									string text10 = "";
									string text11 = objectParameter2.Value.ToString();
									if (text11.IndexOf("IsUser=0", StringComparison.Ordinal) >= 0)
									{
										_ = text10 + MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", defLangCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<br>";
										resourceString2 = "<br>" + MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", defLangCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString2;
										return new ServiceResult<int>
										{
											Message = resourceString2.Replace("<br>", "\r\n"),
											Data = 0,
											Status = ServiceResultStatus.Error
										};
									}
									if (text11.IndexOf("Not Prd|", StringComparison.Ordinal) >= 0)
									{
										text10 = text10 + string.Format(MyResource.GetResourceString("ErrorItemIsNotEntered", defLangCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Product", defLangCollation, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
										return new ServiceResult<int>
										{
											Message = text10.Replace("<br>", "\r\n"),
											Data = 0,
											Status = ServiceResultStatus.Error
										};
									}
									if (text11.IndexOf("Error", StringComparison.Ordinal) >= 0)
									{
										_ = text10 + resourceString2;
										return new ServiceResult<int>
										{
											Message = resourceString2.Replace("<br>", "\r\n"),
											Data = 0,
											Status = ServiceResultStatus.Error
										};
									}
								}
								else
								{
									message = MyResource.GetResourceString("SuccessDoneRegister", defLangCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
									status = ServiceResultStatus.Success;
								}
							}
							else
							{
								message = MyResource.GetResourceString("ErrorNotFound", defLangCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
								status = ServiceResultStatus.Fail;
							}
						}
						else
						{
							message = MyResource.GetResourceString("ErrorNotFound", defLangCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
							status = ServiceResultStatus.Fail;
						}
					}
					else
					{
						status = ServiceResultStatus.Error;
						message = MyResource.GetResourceString("ErrorFileNotExist", defLangCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
					}
				}
			}
			catch (Exception ex)
			{
				string text12 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
				if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
				{
					text12 = text12 + " - " + ex.InnerException.Message;
				}
				message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text12)) ? (" (" + text12 + ")") : "");
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
					foreach (FileInfo fileInfo in files)
					{
						fileInfo.Delete();
					}
					DirectoryInfo[] directories = directoryInfo.GetDirectories();
					foreach (DirectoryInfo directoryInfo2 in directories)
					{
						directoryInfo2.Delete(recursive: true);
					}
					if (System.IO.Directory.Exists(pathDirPrivateUser))
					{
						System.IO.Directory.Delete(pathDirPrivateUser);
					}
				}
			}
		}
		catch (Exception ex2)
		{
			string text13 = ((!string.IsNullOrEmpty(ex2.Message)) ? ex2.Message : "");
			if (ex2.InnerException != null && !string.IsNullOrEmpty(ex2.InnerException.Message))
			{
				text13 = text13 + " - " + ex2.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text13)) ? (" (" + text13 + ")") : "");
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
			Data = 0,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<int> Update(UpdateProductGalleryViewModel model)
	{
		CRMEntities cRMEntities = null;
		int data = 0;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<int>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<int>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int.TryParse(model.LanguageId.ToString(), out var currLangId);
			if (currLangId <= 0)
			{
				currLangId = result;
			}
			List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)cRMEntities.ApispSelectLanguages());
			string culture = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				culture = apispSelectLanguages_Result.LanguageCollation;
			}
			if (!string.IsNullOrEmpty(model.Password))
			{
				model.Password = CodeDecode.DeCodding(model.Password);
			}
			if (!string.IsNullOrEmpty(model.UserName))
			{
				model.UserName = CodeDecode.DeCodding(model.UserName);
			}
			int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispCheckUserAllowed(model.UserName, model.Password));
			int result2 = 0;
			int.TryParse(num.ToString(), out result2);
			if (result2 == 0)
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiPrdGalleryId <= 0)
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = MyResource.GetResourceString("ErrorNotFound", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Fail;
				return serviceResult;
			}
			int userId = model.UserId;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = CRMIdealApi.Classes.Configuration.AppType;
			ObjectParameter objectParameter = new ObjectParameter("ErrorMessage", "");
			int num2 = cRMEntities.ApispUpdateProductGallery(model.ApiPrdGalleryId, null, model.ApiIsMain, null, null, null, model.ApiOrderView, 1, userId: userId, month1: value2, registerDate: value, registerDatePersian: registerDatePersian, appType: appType, errorMessage: objectParameter);
			string resourceString = MyResource.GetResourceString("ErrorDoneOperationTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			string resourceString2 = MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			int result3 = 0;
			int.TryParse(num2.ToString(), out result3);
			if (result3 < 0 && objectParameter.Value == null)
			{
				return new ServiceResult<int>
				{
					Message = resourceString.Replace("<br>", "\r\n"),
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			if (objectParameter.Value != null && objectParameter.Value.ToString() != "")
			{
				string text = "";
				string text2 = objectParameter.Value.ToString();
				if (text2.IndexOf("IsUser=0", StringComparison.Ordinal) >= 0)
				{
					text = text + MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<br>";
					resourceString2 = "<br>" + MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString2;
					return new ServiceResult<int>
					{
						Message = resourceString2.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text2.IndexOf("Not Prd|", StringComparison.Ordinal) >= 0)
				{
					text = text + string.Format(MyResource.GetResourceString("ErrorItemIsNotEntered", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Product", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text2.IndexOf("Error", StringComparison.Ordinal) >= 0)
				{
					text += resourceString2;
					return new ServiceResult<int>
					{
						Message = resourceString2.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
			}
			else
			{
				data = 1;
				message = MyResource.GetResourceString("SuccessDoneRegister", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Success;
			}
		}
		catch (Exception ex)
		{
			string text3 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text3 = text3 + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text3)) ? (" (" + text3 + ")") : "");
			data = 0;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
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
	public ServiceResult<List<ApispSelectProductGallery_Result>> Select(SelectProductGalleryViewModel model)
	{
		CRMEntities cRMEntities = null;
		List<ApispSelectProductGallery_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<List<ApispSelectProductGallery_Result>>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			CommonClass commonClass = new CommonClass();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<List<ApispSelectProductGallery_Result>>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int.TryParse(model.LanguageId.ToString(), out var currLangId);
			if (currLangId <= 0)
			{
				currLangId = result;
			}
			List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)cRMEntities.ApispSelectLanguages());
			string culture = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				culture = apispSelectLanguages_Result.LanguageCollation;
			}
			if (!string.IsNullOrEmpty(model.Password))
			{
				model.Password = CodeDecode.DeCodding(model.Password);
			}
			if (!string.IsNullOrEmpty(model.UserName))
			{
				model.UserName = CodeDecode.DeCodding(model.UserName);
			}
			int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispCheckUserAllowed(model.UserName, model.Password));
			int result2 = 0;
			int.TryParse(num.ToString(), out result2);
			if (result2 == 0)
			{
				ServiceResult<List<ApispSelectProductGallery_Result>> serviceResult = new ServiceResult<List<ApispSelectProductGallery_Result>>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			List<ApispSelectProductGallery_Result> list2 = Enumerable.ToList<ApispSelectProductGallery_Result>((IEnumerable<ApispSelectProductGallery_Result>)cRMEntities.ApispSelectProductGallery(model.ApiPrdGalleryId, model.ApiPrdId, currLangId, result));
			if (list2 != null)
			{
				if (Enumerable.Any<ApispSelectProductGallery_Result>((IEnumerable<ApispSelectProductGallery_Result>)list2))
				{
					foreach (ApispSelectProductGallery_Result item in list2)
					{
						if (!string.IsNullOrEmpty(item.ApiFilePath) && !string.IsNullOrEmpty(item.ApiFileName))
						{
							item.ApiFilePath = GetLinkDownload(item.ApiFilePath, item.ApiFileName);
						}
					}
				}
				message = MyResource.GetResourceString("SuccessDoneRegister", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Success;
			}
			else
			{
				message = MyResource.GetResourceString("ErrorNotFound", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Fail;
			}
			data = list2;
		}
		catch (Exception ex)
		{
			string text = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text = text + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text)) ? (" (" + text + ")") : "");
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<ApispSelectProductGallery_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<bool> Delete(DeleteProductGalleryViewModel model)
	{
		CRMEntities cRMEntities = null;
		bool data = false;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<bool>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = false,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			CommonClass commonClass = new CommonClass();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<bool>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = false,
					Status = ServiceResultStatus.Error
				};
			}
			int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int.TryParse(model.LanguageId.ToString(), out var currLangId);
			if (currLangId <= 0)
			{
				currLangId = result;
			}
			List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)cRMEntities.ApispSelectLanguages());
			string culture = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				culture = apispSelectLanguages_Result.LanguageCollation;
			}
			if (!string.IsNullOrEmpty(model.Password))
			{
				model.Password = CodeDecode.DeCodding(model.Password);
			}
			if (!string.IsNullOrEmpty(model.UserName))
			{
				model.UserName = CodeDecode.DeCodding(model.UserName);
			}
			int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispCheckUserAllowed(model.UserName, model.Password));
			int result2 = 0;
			int.TryParse(num.ToString(), out result2);
			if (result2 == 0)
			{
				ServiceResult<bool> serviceResult = new ServiceResult<bool>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = false;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiPrdGalleryId > 0)
			{
				ApispSelectProductGallery_Result apispSelectProductGallery_Result = Enumerable.FirstOrDefault<ApispSelectProductGallery_Result>((IEnumerable<ApispSelectProductGallery_Result>)cRMEntities.ApispSelectProductGallery(model.ApiPrdGalleryId, 0, currLangId, result));
				if (apispSelectProductGallery_Result != null)
				{
					string text = apispSelectProductGallery_Result.ApiFilePath.ToLower().Replace(CRMIdealApi.Classes.Configuration.PathFtp.ToLower(), "");
					if (!string.IsNullOrEmpty(text))
					{
						FacadeFTP facadeFTP = new FacadeFTP(CRMIdealApi.Classes.Configuration.FacadeFtp);
						string destination = text;
						if (facadeFTP.Delete(CRMIdealApi.Classes.Configuration.PathFtp, CRMIdealApi.Classes.Configuration.UserNameFtp, CRMIdealApi.Classes.Configuration.PasswordFtp, apispSelectProductGallery_Result.ApiFileName, destination, CRMIdealApi.Classes.Configuration.UsePassiveFtp))
						{
							mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)cRMEntities.ApispDeleteProductGallery(model.ApiPrdGalleryId));
							if (mct_Result != null)
							{
								if (mct_Result.Result > 0)
								{
									data = true;
									message = MyResource.GetResourceString("SuccessDoneRegister", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
									status = ServiceResultStatus.Success;
								}
								else
								{
									data = false;
									message = MyResource.GetResourceString("RedundancyMessage", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
									status = ServiceResultStatus.Fail;
								}
							}
							else
							{
								data = false;
								message = MyResource.GetResourceString("RedundancyMessage", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
								status = ServiceResultStatus.Fail;
							}
						}
						else
						{
							data = false;
							message = MyResource.GetResourceString("ErrorNotFound", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
							status = ServiceResultStatus.Fail;
						}
					}
					else
					{
						data = false;
						message = MyResource.GetResourceString("ErrorNotFound", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
						status = ServiceResultStatus.Fail;
					}
				}
				else
				{
					data = false;
					message = MyResource.GetResourceString("ErrorNotFound", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
					status = ServiceResultStatus.Fail;
				}
			}
			else
			{
				data = false;
				message = MyResource.GetResourceString("ErrorNotFound", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Fail;
			}
		}
		catch (Exception ex)
		{
			string text2 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text2 = text2 + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text2)) ? (" (" + text2 + ")") : "");
			data = false;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<bool>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	public string GetLinkDownload(string filePath, string fileName)
	{
		string result = "";
		try
		{
			string text = "";
			if (!string.IsNullOrEmpty(filePath) && !string.IsNullOrEmpty(fileName))
			{
				string text2 = filePath.ToLower().Replace(CRMIdealApi.Classes.Configuration.PathFtp.ToLower(), "");
				if (!string.IsNullOrEmpty(text2))
				{
					FilesManager filesManager = new FilesManager();
					string text3 = filesManager.SetNameDirectory(DateTime.Now.ToString("yyyyMMdd"));
					if (filesManager.CreateDirectory(text3))
					{
						text = HttpContext.Current.Server.MapPath(text3 + "/" + fileName);
						string absoluteUri = HttpContext.Current.Request.Url.AbsoluteUri;
						string[] array = absoluteUri.Split(new string[1] { "/api/" }, StringSplitOptions.None);
						string text4 = "";
						if (array != null)
						{
							text4 = ((array[0] != null && array[0] != "") ? (array[0] + text3 + "/" + fileName) : "");
						}
						FacadeFTP facadeFTP = new FacadeFTP(CRMIdealApi.Classes.Configuration.FacadeFtp);
						if (!facadeFTP.Download(CRMIdealApi.Classes.Configuration.PathFtp, CRMIdealApi.Classes.Configuration.UserNameFtp, CRMIdealApi.Classes.Configuration.PasswordFtp, text, text2, overwrite: true, CRMIdealApi.Classes.Configuration.UsePassiveFtp))
						{
							if (!string.IsNullOrEmpty(text))
							{
								text = HttpContext.Current.Server.MapPath(text3 + "/");
								if (System.IO.Directory.Exists(text))
								{
									DirectoryInfo directoryInfo = new DirectoryInfo(text);
									FileInfo[] files = directoryInfo.GetFiles();
									foreach (FileInfo fileInfo in files)
									{
										fileInfo.Delete();
									}
									DirectoryInfo[] directories = directoryInfo.GetDirectories();
									foreach (DirectoryInfo directoryInfo2 in directories)
									{
										directoryInfo2.Delete(recursive: true);
									}
									if (System.IO.Directory.Exists(text))
									{
										System.IO.Directory.Delete(text);
									}
								}
							}
							text = "";
						}
						else
						{
							text = text4;
						}
					}
				}
				result = text;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}
}
