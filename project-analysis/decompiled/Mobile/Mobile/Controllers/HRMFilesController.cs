using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using CRM.General.IO;
using CRM.Resources;
using Elmah;
using GSD.Globalization;
using Mobile.Cache.Setting;
using Mobile.Classes;
using Mobile.Classes.Helper;
using Mobile.DataType;
using Mobile.Models;

namespace Mobile.Controllers;

public class HRMFilesController : ApiController
{
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
							HRMMobspSelectUserPictureByUserId_Result hRMMobspSelectUserPictureByUserId_Result = Enumerable.FirstOrDefault<HRMMobspSelectUserPictureByUserId_Result>((IEnumerable<HRMMobspSelectUserPictureByUserId_Result>)cRMEntities.HRMMobspSelectUserPictureByUserId(userId));
							if (hRMMobspSelectUserPictureByUserId_Result != null)
							{
								if (hRMMobspSelectUserPictureByUserId_Result.UserPicture != null)
								{
									array = hRMMobspSelectUserPictureByUserId_Result.UserPicture;
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
	public ServiceResult<string> GetLinkDownloadCoLogoMobHRMApp()
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
						string coLogoMobHRMAppPath = new HrmFiles().GetCoLogoMobHRMAppPath(num2, result);
						if (string.IsNullOrEmpty(coLogoMobHRMAppPath))
						{
							text2 = Messages.MobMsgErrorFileNotExist;
							text = null;
							serviceResultStatus = ServiceResultStatus.Error;
						}
						else
						{
							text = coLogoMobHRMAppPath;
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
	public async Task<ServiceResult<bool>> UploadUserPicture()
	{
		int num = 1065;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		CRMSpEntities dbI = null;
		bool data = false;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int currLangId = ((num > 0) ? num : result);
		baseInfo.SetCulture(currLangId);
		try
		{
			dbI = new CRMSpEntities();
			if (!base.Request.Content.IsMimeMultipartContent())
			{
				ServiceResult<bool> serviceResult = new ServiceResult<bool>();
				HttpStatusCode val = (HttpStatusCode)415;
				serviceResult.Message = ((object)(HttpStatusCode)(ref val)).ToString();
				serviceResult.Data = false;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (base.Request.Headers.Contains("token"))
			{
				string token2 = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token = new Common().GetToken(token2);
				if (token != null)
				{
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
								_ = Mobile.Classes.Configuration.MainDirectoryPath;
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
								if (array != null)
								{
									dbI.HRMMobspInsertUpdateUserPicture(array, token.userId, token.userId, year1, month1, registerDate, registerDatePersian, appType, currLangId);
									data = true;
									message = Messages.MobMsgSuccessAction;
									status = ServiceResultStatus.Success;
								}
								else
								{
									message = Messages.MobMsgErrorFileNotExist;
									data = false;
									status = ServiceResultStatus.Error;
								}
							}
							else
							{
								message = Messages.MobMsgErrorFileNotExist;
								data = false;
								status = ServiceResultStatus.Error;
							}
						}
					}
					catch (Exception ex)
					{
						message = Messages.MobMsgErrorDoneOperation + " (" + ex.Message + ")";
						data = false;
						status = ServiceResultStatus.Error;
						ErrorSignal.FromCurrentContext().Raise(ex);
					}
					finally
					{
						dbI?.Dispose();
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
					data = false;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = false;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception ex3)
		{
			message = Messages.MobMsgErrorDoneOperation + " (" + ex3.Message + ")";
			data = false;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex3);
		}
		finally
		{
			dbI?.Dispose();
		}
		return new ServiceResult<bool>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> DeleteUserPicture()
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
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					new CRMSpEntities().HRMMobspDeleteUserPicturesByUserId(token2.userId);
					text2 = Messages.MobMsgSuccessAction;
					text = null;
					serviceResultStatus = ServiceResultStatus.Success;
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
		catch (Exception e)
		{
			text2 = Messages.MobMsgErrorDoneOperation;
			text = null;
			serviceResultStatus = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
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
							HrmFiles hrmFiles = new HrmFiles();
							string text3 = ((fileId > 0) ? hrmFiles.GetFilePath(fileId) : "");
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
}
