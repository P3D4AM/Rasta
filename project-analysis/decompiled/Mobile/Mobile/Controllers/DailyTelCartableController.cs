using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using CRM.General.Calendar;
using CRM.General.IO.FTP;
using CRM.Resources;
using Elmah;
using Mobile.Cache.Setting;
using Mobile.Classes;
using Mobile.Classes.Helper;
using Mobile.DataType;
using Mobile.Models;

namespace Mobile.Controllers;

public class DailyTelCartableController : ApiController
{
	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItem>> ReturnLineNumber(string date, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItem> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (!UserLogin.IsUserAccess("frmMain", "actcDailyTel", UserLogin.CurrentUser, cId))
			{
				return new ServiceResult<List<DropDownItem>>
				{
					Message = Messages.MobMsgErrorAccessLimited,
					Data = null,
					Status = ServiceResultStatus.Fail
				};
			}
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					DateTime value;
					DateTime value2;
					try
					{
						if (string.IsNullOrEmpty(date))
						{
							ServiceResult<List<DropDownItem>> result3 = new ServiceResult<List<DropDownItem>>
							{
								Message = Messages.MobMsgErrorDateNotEntered,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
							cRMEntities?.Dispose();
							return result3;
						}
						date = date.Replace("/", "").Replace("-", "").Replace("\\", "")
							.Replace(" ", "")
							.Replace("_", "");
						if (result == 1065)
						{
							value = DateTime.Parse(PersianDate.GetFormatetdDate(date) + " 00:00:00");
							value2 = DateTime.Parse(PersianDate.GetFormatetdDate(date) + " 23:59:59");
						}
						else
						{
							value = DateTime.Parse(PersianDate.GetFormatetdDate(date) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None);
							value2 = DateTime.Parse(PersianDate.GetFormatetdDate(date) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None);
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						ServiceResult<List<DropDownItem>> result4 = new ServiceResult<List<DropDownItem>>
						{
							Message = Messages.MobMsgErrorDateFormatIncorrect,
							Data = null,
							Status = ServiceResultStatus.Error
						};
						cRMEntities?.Dispose();
						return result4;
					}
					string mobAllLine = Labels.MobAllLine;
					string mobLine = Labels.MobLine;
					List<MobspReturnDailyCIRecordVoiceLineNumber_Result> list = Enumerable.ToList<MobspReturnDailyCIRecordVoiceLineNumber_Result>((IEnumerable<MobspReturnDailyCIRecordVoiceLineNumber_Result>)cRMEntities.MobspReturnDailyCIRecordVoiceLineNumber(value, value2, mobAllLine, mobLine, token2.userId, cId));
					List<DropDownItem> list2 = new List<DropDownItem>();
					foreach (MobspReturnDailyCIRecordVoiceLineNumber_Result item in list)
					{
						DropDownItem dropDownItem = new DropDownItem();
						int result5 = 0;
						int.TryParse(item.LineNumber.ToString(), out result5);
						dropDownItem.Id = result5;
						dropDownItem.Title = item.LineName;
						int result6 = 0;
						int.TryParse(item.OrderView.ToString(), out result6);
						dropDownItem.OrderView = result6;
						list2.Add(dropDownItem);
					}
					data = list2;
					message = "";
					status = ServiceResultStatus.Success;
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
		return new ServiceResult<List<DropDownItem>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspReturnDailyCIRecordVoiceInformation_Result>> ReturnDailyCiRecordVoiceInformation(string date, int typeId, int lineNumber, int? pageNumber = 1, int? pageSize = 10, int? ln = null, int? cId = null, string userIds = null, string extensionNumber = null, int? conversasionStatus = null, long? fCallLength = null, long? tCallLength = null, bool? orderByCmp = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspReturnDailyCIRecordVoiceInformation_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (!UserLogin.IsUserAccess("frmMain", "actcDailyTel", UserLogin.CurrentUser, cId))
			{
				return new ServiceResult<List<MobspReturnDailyCIRecordVoiceInformation_Result>>
				{
					Message = Messages.MobMsgErrorAccessLimited,
					Data = null,
					Status = ServiceResultStatus.Fail
				};
			}
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					DateTime today = DateTime.Today;
					DateTime value;
					DateTime value2;
					try
					{
						if (string.IsNullOrEmpty(date))
						{
							ServiceResult<List<MobspReturnDailyCIRecordVoiceInformation_Result>> result3 = new ServiceResult<List<MobspReturnDailyCIRecordVoiceInformation_Result>>
							{
								Message = Messages.MobMsgErrorDateNotEntered,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
							cRMEntities?.Dispose();
							return result3;
						}
						date = date.Replace("/", "").Replace("-", "").Replace("\\", "")
							.Replace(" ", "")
							.Replace("_", "");
						if (result == 1065)
						{
							value = DateTime.Parse(PersianDate.GetFormatetdDate(date) + " 00:00:00");
							value2 = DateTime.Parse(PersianDate.GetFormatetdDate(date) + " 00:00:00");
						}
						else
						{
							value = DateTime.Parse(PersianDate.GetFormatetdDate(date) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None);
							value2 = DateTime.Parse(PersianDate.GetFormatetdDate(date) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None);
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						ServiceResult<List<MobspReturnDailyCIRecordVoiceInformation_Result>> result4 = new ServiceResult<List<MobspReturnDailyCIRecordVoiceInformation_Result>>
						{
							Message = Messages.MobMsgErrorDateFormatIncorrect,
							Data = null,
							Status = ServiceResultStatus.Error
						};
						cRMEntities?.Dispose();
						return result4;
					}
					if (lineNumber == 0)
					{
						ServiceResult<List<MobspReturnDailyCIRecordVoiceInformation_Result>> result5 = new ServiceResult<List<MobspReturnDailyCIRecordVoiceInformation_Result>>
						{
							Message = Messages.MobMsgErrorlineNumberNotSelected,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
						cRMEntities?.Dispose();
						return result5;
					}
					CRMEntities cRMEntities2 = cRMEntities;
					DateTime? fDate = value;
					DateTime? tDate = value2;
					string callDate = date;
					string callTypeId = typeId.ToString();
					string lineNumber2 = lineNumber.ToString();
					string userId = token2.userId.ToString();
					string rptDate = today.ToString("yyyyMMdd");
					string rptDay = today.ToString("dddd");
					int? languageID = result;
					int? defaultLanguageID = result2;
					int? pageSize2 = pageSize;
					data = Enumerable.ToList<MobspReturnDailyCIRecordVoiceInformation_Result>((IEnumerable<MobspReturnDailyCIRecordVoiceInformation_Result>)cRMEntities2.MobspReturnDailyCIRecordVoiceInformation(fDate, tDate, callDate, callTypeId, lineNumber2, userId, rptDate, rptDay, languageID, defaultLanguageID, pageNumber, extensionNumber, conversasionStatus, fCallLength, tCallLength, orderByCmp, pageSize2, 0, 0, userIds, cId));
					message = "";
					status = ServiceResultStatus.Success;
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
		return new ServiceResult<List<MobspReturnDailyCIRecordVoiceInformation_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspReturnCallTypeCount_Result>> ReturnCallTypeCount(string date, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspReturnCallTypeCount_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (!UserLogin.IsUserAccess("frmMain", "actcDailyTel", UserLogin.CurrentUser, cId))
			{
				return new ServiceResult<List<MobspReturnCallTypeCount_Result>>
				{
					Message = Messages.MobMsgErrorAccessLimited,
					Data = null,
					Status = ServiceResultStatus.Fail
				};
			}
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					_ = DateTime.Today;
					DateTime value;
					DateTime value2;
					try
					{
						if (string.IsNullOrEmpty(date))
						{
							ServiceResult<List<MobspReturnCallTypeCount_Result>> result3 = new ServiceResult<List<MobspReturnCallTypeCount_Result>>
							{
								Message = Messages.MobMsgErrorDateNotEntered,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
							cRMEntities?.Dispose();
							return result3;
						}
						date = date.Replace("/", "").Replace("-", "").Replace("\\", "")
							.Replace(" ", "")
							.Replace("_", "");
						if (result == 1065)
						{
							value = DateTime.Parse(PersianDate.GetFormatetdDate(date) + " 00:00:00");
							value2 = DateTime.Parse(PersianDate.GetFormatetdDate(date) + " 23:59:59");
						}
						else
						{
							value = DateTime.Parse(PersianDate.GetFormatetdDate(date) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None);
							value2 = DateTime.Parse(PersianDate.GetFormatetdDate(date) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None);
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						ServiceResult<List<MobspReturnCallTypeCount_Result>> result4 = new ServiceResult<List<MobspReturnCallTypeCount_Result>>
						{
							Message = Messages.MobMsgErrorDateFormatIncorrect,
							Data = null,
							Status = ServiceResultStatus.Error
						};
						cRMEntities?.Dispose();
						return result4;
					}
					data = Enumerable.ToList<MobspReturnCallTypeCount_Result>((IEnumerable<MobspReturnCallTypeCount_Result>)cRMEntities.MobspReturnCallTypeCount(value, value2, result, result2, token2.userId, cId));
					message = "";
					status = ServiceResultStatus.Success;
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
		return new ServiceResult<List<MobspReturnCallTypeCount_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	public string GetFileRecPath(string filePath, int devType = 1)
	{
		string text = "";
		try
		{
			if (filePath != null)
			{
				string text2 = "";
				string text3 = "";
				string text4 = "";
				string text5 = "";
				string text6 = "";
				bool flag = false;
				if (!string.IsNullOrEmpty(Mobile.Classes.Configuration.PathFtpRecording) && devType == 1)
				{
					text2 = filePath.ToLower().Replace(Mobile.Classes.Configuration.PathFtpRecording.ToLower(), "");
					text3 = Mobile.Classes.Configuration.FacadeFtpRecording;
					text4 = Mobile.Classes.Configuration.PathFtpRecording;
					text5 = Mobile.Classes.Configuration.UserNameFtpRecording;
					text6 = Mobile.Classes.Configuration.PasswordFtpRecording;
					flag = Mobile.Classes.Configuration.UsePassiveFtpRecording;
				}
				else if (!string.IsNullOrEmpty(Mobile.Classes.Configuration.PathFtpRecordingII) && devType == 2)
				{
					text2 = filePath.ToLower().Replace(Mobile.Classes.Configuration.PathFtpRecordingII.ToLower(), "");
					text3 = Mobile.Classes.Configuration.FacadeFtpRecordingII;
					text4 = Mobile.Classes.Configuration.PathFtpRecordingII;
					text5 = Mobile.Classes.Configuration.UserNameFtpRecordingII;
					text6 = Mobile.Classes.Configuration.PasswordFtpRecordingII;
					flag = Mobile.Classes.Configuration.UsePassiveFtpRecordingII;
				}
				else
				{
					if (filePath.IndexOf("CRMRecording\\", StringComparison.Ordinal) < 0)
					{
						filePath = "CRMRecording\\" + filePath;
					}
					text2 = filePath.ToLower().Replace(Mobile.Classes.Configuration.PathFtp.ToLower(), "");
					text3 = Mobile.Classes.Configuration.FacadeFtp;
					text4 = Mobile.Classes.Configuration.PathFtp;
					text5 = Mobile.Classes.Configuration.UserNameFtp;
					text6 = Mobile.Classes.Configuration.PasswordFtp;
					flag = Mobile.Classes.Configuration.UsePassiveFtp;
				}
				if (text2 != "")
				{
					FilesManager filesManager = new FilesManager();
					string text7 = filesManager.SetNameDirectory(UserLogin.CurrentUser.UserId);
					if (filesManager.CreateDirectory(text7))
					{
						char c = '/';
						if (text2.Contains("\\"))
						{
							c = '\\';
						}
						else if (text2.Contains("/"))
						{
							c = '/';
						}
						string[] array = text2.Split(new char[1] { c });
						text7 += (text7.EndsWith("\\") ? "" : "\\");
						text = HttpContext.Current.Server.MapPath(text7 + array[^1]);
						string[] array2 = HttpContext.Current.Request.Url.AbsoluteUri.Split(new string[1] { "/api/" }, StringSplitOptions.None);
						string text8 = "";
						if (array2 != null)
						{
							text8 = ((array2[0] != null && array2[0] != "") ? (array2[0] + text7.Replace("\\\\", "/") + array[^1]) : "");
						}
						if (!new FacadeFTP(text3).Download(text4, text5, text6, text, text2, overwrite: true, flag))
						{
							text = "";
							string path = HttpContext.Current.Server.MapPath(text7);
							if (Directory.Exists(path))
							{
								DirectoryInfo directoryInfo = new DirectoryInfo(path);
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
								if (Directory.Exists(path))
								{
									Directory.Delete(path);
								}
							}
						}
						else
						{
							text = text8;
						}
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return text;
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> GetFileRecLinkDownload(string fileRecPath, int devType = 1, int? cId = null)
	{
		int num = 1065;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		string text = null;
		string text2 = "";
		ServiceResultStatus serviceResultStatus = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : num);
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
						if (!UserLogin.IsUserAccess("frmMain", "actcOpenRecordingFile", UserLogin.CurrentUser, cId))
						{
							return new ServiceResult<string>
							{
								Message = Messages.MobMsgErrorAccessLimited,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
						}
						if (!string.IsNullOrEmpty(fileRecPath))
						{
							string fileRecPath2 = GetFileRecPath(fileRecPath, devType);
							if (string.IsNullOrEmpty(fileRecPath2))
							{
								text2 = Messages.MobMsgErrorFileNotExist;
								text = null;
								serviceResultStatus = ServiceResultStatus.Error;
							}
							else
							{
								text = fileRecPath2;
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
