using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CRM.Resources;
using Elmah;
using GSD.Globalization;
using Mobile.Cache;
using Mobile.Cache.Setting;
using Mobile.Cache.User;
using Mobile.Classes;
using Mobile.Classes.Helper;
using Mobile.DataType;
using Mobile.Models;

namespace Mobile.Controllers;

public class CICBasicInfoController : ApiController
{
	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<CicNeedUpdateDetailBaseInfoViewModel> SelectUserBaseInfoStatus(string imeiCode, string appName, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		CicNeedUpdateDetailBaseInfoViewModel data = null;
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
					cRMSpEntities = new CRMSpEntities();
					List<CICMobspSelectUserBaseInfoStatus_Result> list = Enumerable.ToList<CICMobspSelectUserBaseInfoStatus_Result>((IEnumerable<CICMobspSelectUserBaseInfoStatus_Result>)cRMSpEntities.CICMobspSelectUserBaseInfoStatus(token2.userId, imeiCode, appName));
					if (list != null && Enumerable.Any<CICMobspSelectUserBaseInfoStatus_Result>((IEnumerable<CICMobspSelectUserBaseInfoStatus_Result>)list))
					{
						CicNeedUpdateDetailBaseInfoViewModel cicNeedUpdateDetailBaseInfoViewModel = new CicNeedUpdateDetailBaseInfoViewModel();
						List<string> list2 = new List<string>();
						List<string> list3 = new List<string>();
						foreach (CICMobspSelectUserBaseInfoStatus_Result item in list)
						{
							string[] array2;
							if (item.UserId != 0)
							{
								bool flag = !item.MobAppBaseInfoNeedUpdate.HasValue || item.MobAppBaseInfoNeedUpdate.GetValueOrDefault();
								cicNeedUpdateDetailBaseInfoViewModel.MobAppBaseInfoNeedUpdate = flag;
								cicNeedUpdateDetailBaseInfoViewModel.UserId = item.UserId;
								if (flag)
								{
									Info.Update(token2.userId, true);
									Permissions.Update(token2.userId);
									Manager.UpdateAllSettingCach();
								}
								if (!string.IsNullOrEmpty(item.MobAppBaseInfoNeedUpdateDetail))
								{
									string[] array = item.MobAppBaseInfoNeedUpdateDetail.Split(new char[1] { ',' });
									if (array != null && Enumerable.Any<string>((IEnumerable<string>)array))
									{
										array2 = array;
										foreach (string tblName in array2)
										{
											if (!string.IsNullOrEmpty(tblName) && (list3 == null || Enumerable.FirstOrDefault<string>((IEnumerable<string>)list3, (Func<string, bool>)((string l) => l.Equals(tblName))) == null))
											{
												list3.Add(tblName);
											}
										}
									}
								}
							}
							if (string.IsNullOrEmpty(item.Apis))
							{
								continue;
							}
							string[] array3 = item.Apis.Split(new char[1] { ',' });
							if (array3 == null || !Enumerable.Any<string>((IEnumerable<string>)array3))
							{
								continue;
							}
							array2 = array3;
							foreach (string apiName in array2)
							{
								if (!string.IsNullOrEmpty(apiName) && (list2 == null || Enumerable.FirstOrDefault<string>((IEnumerable<string>)list2, (Func<string, bool>)((string l) => l.Equals(apiName))) == null))
								{
									list2.Add(apiName);
								}
							}
						}
						cicNeedUpdateDetailBaseInfoViewModel.Apis = list2;
						cicNeedUpdateDetailBaseInfoViewModel.MobAppBaseInfoNeedUpdateDetail = list3;
						data = cicNeedUpdateDetailBaseInfoViewModel;
						message = "";
						status = ServiceResultStatus.Success;
					}
					else
					{
						data = null;
						message = Messages.MobMsgErrorNotFound;
						status = ServiceResultStatus.Fail;
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<CicNeedUpdateDetailBaseInfoViewModel>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<bool> UpdatedUserMobBaseInfo(string imeiCode, string appName, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		bool data = false;
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
					cRMSpEntities = new CRMSpEntities();
					int userId = token2.userId;
					DateTime now = DateTime.Now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short.Parse(now.ToString("MM", new PersianCulture()));
					_ = Mobile.Classes.Configuration.AppType;
					cRMSpEntities.CICMobspUpdatedUserMobBaseInfo(userId, imeiCode, appName, now, registerDatePersian);
					Info.Update(token2.userId, true);
					Permissions.Update(token2.userId);
					Manager.UpdateAllSettingCach();
					data = true;
					message = "";
					status = ServiceResultStatus.Success;
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
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = false;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
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
	public ServiceResult<List<CICMobspSelectCrmsysSetting_Result>> SelectCrmsysSetting(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<CICMobspSelectCrmsysSetting_Result> data = null;
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
					cRMSpEntities = new CRMSpEntities();
					data = Enumerable.ToList<CICMobspSelectCrmsysSetting_Result>((IEnumerable<CICMobspSelectCrmsysSetting_Result>)cRMSpEntities.CICMobspSelectCrmsysSetting(result, result2));
					message = Messages.MobMsgSuccessAction;
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
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<List<CICMobspSelectCrmsysSetting_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<Dictionary<string, string>> SelectCrmsysSettingCoName(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		Dictionary<string, string> dictionary = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			string text = "";
			if (base.Request.Headers.Contains("extra"))
			{
				text = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("extra"));
			}
			if (new Common().CheckExtra(text))
			{
				if (base.Request.Headers.Contains("token"))
				{
					if (Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token")) == text)
					{
						cRMSpEntities = new CRMSpEntities();
						dictionary = new Dictionary<string, string>();
						CICMobspSelectCrmsysSetting_Result cICMobspSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<CICMobspSelectCrmsysSetting_Result>((IEnumerable<CICMobspSelectCrmsysSetting_Result>)cRMSpEntities.CICMobspSelectCrmsysSetting(result, result2));
						if (cICMobspSelectCrmsysSetting_Result != null)
						{
							dictionary.Add("CoName", cICMobspSelectCrmsysSetting_Result.CoName ?? "");
						}
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					else
					{
						message = Messages.MobMsgErrorAccessingToken;
						dictionary = null;
						status = ServiceResultStatus.Error;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					dictionary = null;
					status = ServiceResultStatus.Error;
				}
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			dictionary = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<Dictionary<string, string>>
		{
			Message = message,
			Data = dictionary,
			Status = status
		};
	}
}
