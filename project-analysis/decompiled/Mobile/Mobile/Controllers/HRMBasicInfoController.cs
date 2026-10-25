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

public class HRMBasicInfoController : ApiController
{
	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<HrmNeedUpdateDetailBaseInfoViewModel> SelectUserBaseInfoStatus(string imeiCode, string appName, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		HrmNeedUpdateDetailBaseInfoViewModel data = null;
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
					cRMEntities = new CRMEntities();
					List<HRMMobspSelectUserBaseInfoStatus_Result> list = Enumerable.ToList<HRMMobspSelectUserBaseInfoStatus_Result>((IEnumerable<HRMMobspSelectUserBaseInfoStatus_Result>)cRMEntities.HRMMobspSelectUserBaseInfoStatus(token2.userId, imeiCode, appName));
					if (list != null && Enumerable.Any<HRMMobspSelectUserBaseInfoStatus_Result>((IEnumerable<HRMMobspSelectUserBaseInfoStatus_Result>)list))
					{
						HrmNeedUpdateDetailBaseInfoViewModel hrmNeedUpdateDetailBaseInfoViewModel = new HrmNeedUpdateDetailBaseInfoViewModel();
						List<string> list2 = new List<string>();
						List<string> list3 = new List<string>();
						foreach (HRMMobspSelectUserBaseInfoStatus_Result item in list)
						{
							string[] array2;
							if (item.UserId != 0)
							{
								bool flag = !item.MobAppBaseInfoNeedUpdate.HasValue || item.MobAppBaseInfoNeedUpdate.GetValueOrDefault();
								hrmNeedUpdateDetailBaseInfoViewModel.MobAppBaseInfoNeedUpdate = flag;
								hrmNeedUpdateDetailBaseInfoViewModel.UserId = item.UserId;
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
						hrmNeedUpdateDetailBaseInfoViewModel.Apis = list2;
						hrmNeedUpdateDetailBaseInfoViewModel.MobAppBaseInfoNeedUpdateDetail = list3;
						data = hrmNeedUpdateDetailBaseInfoViewModel;
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
			cRMEntities?.Dispose();
		}
		return new ServiceResult<HrmNeedUpdateDetailBaseInfoViewModel>
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
					cRMSpEntities.HRMMobspUpdatedUserMobBaseInfo(userId, imeiCode, appName, now, registerDatePersian);
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
	public ServiceResult<HRMMobspSelectUserBaseInfoLastUpdate_Result> SelectUserBaseInfoLastUpdate(string imeiCode, string appName, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		HRMMobspSelectUserBaseInfoLastUpdate_Result data;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					data = Enumerable.FirstOrDefault<HRMMobspSelectUserBaseInfoLastUpdate_Result>((IEnumerable<HRMMobspSelectUserBaseInfoLastUpdate_Result>)cRMEntities.HRMMobspSelectUserBaseInfoLastUpdate(token2.userId, imeiCode, appName));
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
		return new ServiceResult<HRMMobspSelectUserBaseInfoLastUpdate_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<HRMMobspSelectCrmsysSetting_Result>> SelectCrmsysSetting(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<HRMMobspSelectCrmsysSetting_Result> data = null;
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
					cRMEntities = new CRMEntities();
					data = Enumerable.ToList<HRMMobspSelectCrmsysSetting_Result>((IEnumerable<HRMMobspSelectCrmsysSetting_Result>)cRMEntities.HRMMobspSelectCrmsysSetting(result, result2));
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
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<HRMMobspSelectCrmsysSetting_Result>>
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
		CRMEntities cRMEntities = null;
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
						cRMEntities = new CRMEntities();
						dictionary = new Dictionary<string, string>();
						HRMMobspSelectCrmsysSetting_Result hRMMobspSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<HRMMobspSelectCrmsysSetting_Result>((IEnumerable<HRMMobspSelectCrmsysSetting_Result>)cRMEntities.HRMMobspSelectCrmsysSetting(result, result2));
						if (hRMMobspSelectCrmsysSetting_Result != null)
						{
							dictionary.Add("CoName", hRMMobspSelectCrmsysSetting_Result.CoNameMobHRMApp ?? "");
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
			cRMEntities?.Dispose();
		}
		return new ServiceResult<Dictionary<string, string>>
		{
			Message = message,
			Data = dictionary,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<HrmDropDownItem>> SelectCountry(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<HrmDropDownItem> data = null;
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
					cRMEntities = new CRMEntities();
					List<HRMMobspSelectCountry_Result> list = Enumerable.ToList<HRMMobspSelectCountry_Result>((IEnumerable<HRMMobspSelectCountry_Result>)cRMEntities.HRMMobspSelectCountry(result, result2));
					List<HrmDropDownItem> list2 = new List<HrmDropDownItem>();
					foreach (HRMMobspSelectCountry_Result item in list)
					{
						HrmDropDownItem hrmDropDownItem = new HrmDropDownItem();
						int result3 = 0;
						int.TryParse(item.CountryID.ToString(), out result3);
						hrmDropDownItem.Id = result3;
						hrmDropDownItem.Title = item.Country ?? "";
						list2.Add(hrmDropDownItem);
					}
					data = list2;
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
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<HrmDropDownItem>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<HrmDropDownItem>> SelectProvince(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<HrmDropDownItem> data = null;
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
					cRMEntities = new CRMEntities();
					List<HRMMobspSelectProvince_Result> list = Enumerable.ToList<HRMMobspSelectProvince_Result>((IEnumerable<HRMMobspSelectProvince_Result>)cRMEntities.HRMMobspSelectProvince(result, result2));
					List<HrmDropDownItem> list2 = new List<HrmDropDownItem>();
					foreach (HRMMobspSelectProvince_Result item in list)
					{
						HrmDropDownItem hrmDropDownItem = new HrmDropDownItem();
						int result3 = 0;
						int.TryParse(item.ProvinceID.ToString(), out result3);
						hrmDropDownItem.Id = result3;
						hrmDropDownItem.Title = item.Province ?? "";
						int result4 = 0;
						int.TryParse(item.CountryID.ToString(), out result4);
						hrmDropDownItem.ParentId = result4;
						list2.Add(hrmDropDownItem);
					}
					data = list2;
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
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<HrmDropDownItem>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<HrmDropDownItem>> SelectCity(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<HrmDropDownItem> data = null;
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
					cRMEntities = new CRMEntities();
					List<HRMMobspSelectCity_Result> list = Enumerable.ToList<HRMMobspSelectCity_Result>((IEnumerable<HRMMobspSelectCity_Result>)cRMEntities.HRMMobspSelectCity(result, result2));
					List<HrmDropDownItem> list2 = new List<HrmDropDownItem>();
					foreach (HRMMobspSelectCity_Result item in list)
					{
						HrmDropDownItem hrmDropDownItem = new HrmDropDownItem();
						int result3 = 0;
						int.TryParse(item.CityID.ToString(), out result3);
						hrmDropDownItem.Id = result3;
						hrmDropDownItem.Title = item.City ?? "";
						int result4 = 0;
						int.TryParse(item.ProvinceId.ToString(), out result4);
						hrmDropDownItem.ParentId = result4;
						list2.Add(hrmDropDownItem);
					}
					data = list2;
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
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<HrmDropDownItem>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<HrmDropDownItem>> SelectTimeAttendanceBase(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		List<HrmDropDownItem> data;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					List<HRMMobspSelectTimeAttendanceBase_Result> list = Enumerable.ToList<HRMMobspSelectTimeAttendanceBase_Result>((IEnumerable<HRMMobspSelectTimeAttendanceBase_Result>)cRMEntities.HRMMobspSelectTimeAttendanceBase());
					List<HrmDropDownItem> list2 = new List<HrmDropDownItem>();
					foreach (HRMMobspSelectTimeAttendanceBase_Result item in list)
					{
						HrmDropDownItem hrmDropDownItem = new HrmDropDownItem();
						int result3 = 0;
						int.TryParse(item.TimeAttendanceBaseId.ToString(), out result3);
						hrmDropDownItem.Id = result3;
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						dictionary.Add("tmbDay", item.tmbDay.ToString());
						dictionary.Add("tmbEntryBase", item.tmbEntryBase.ToString());
						dictionary.Add("tmbEntryAllowMin", item.tmbEntryAllowMin.ToString());
						dictionary.Add("tmbExitBase", item.tmbExitBase.ToString());
						dictionary.Add("tmbExitAllowMin", item.tmbExitAllowMin.ToString());
						hrmDropDownItem.ExtraField = dictionary;
						list2.Add(hrmDropDownItem);
					}
					data = list2;
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
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<HrmDropDownItem>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<HrmDropDownItem>> SelectAlternativeUsers(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<HrmDropDownItem> data = null;
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
					cRMEntities = new CRMEntities();
					List<HRMMobspSelectAlternativeUsers_Result> list = Enumerable.ToList<HRMMobspSelectAlternativeUsers_Result>((IEnumerable<HRMMobspSelectAlternativeUsers_Result>)cRMEntities.HRMMobspSelectAlternativeUsers(token2.userId, result, result2));
					List<HrmDropDownItem> list2 = new List<HrmDropDownItem>();
					foreach (HRMMobspSelectAlternativeUsers_Result item in list)
					{
						HrmDropDownItem hrmDropDownItem = new HrmDropDownItem();
						int result3 = 0;
						int.TryParse(item.UserId.ToString(), out result3);
						hrmDropDownItem.Id = result3;
						hrmDropDownItem.Title = item.FullName ?? "";
						list2.Add(hrmDropDownItem);
					}
					data = list2;
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
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<HrmDropDownItem>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<HRMMobspSelectBankingAccountsByUserId_Result>> SelectBankingAccounts(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<HRMMobspSelectBankingAccountsByUserId_Result> data = null;
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
					data = Enumerable.ToList<HRMMobspSelectBankingAccountsByUserId_Result>((IEnumerable<HRMMobspSelectBankingAccountsByUserId_Result>)cRMSpEntities.HRMMobspSelectBankingAccountsByUserId(token2.userId, result, result2));
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
		return new ServiceResult<List<HRMMobspSelectBankingAccountsByUserId_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<HRMMobspSelectEmailUsersInfoByUser_Result>> SelectEmailUsersInfo(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<HRMMobspSelectEmailUsersInfoByUser_Result> data = null;
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
					data = Enumerable.ToList<HRMMobspSelectEmailUsersInfoByUser_Result>((IEnumerable<HRMMobspSelectEmailUsersInfoByUser_Result>)cRMSpEntities.HRMMobspSelectEmailUsersInfoByUser(token2.userId));
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
		return new ServiceResult<List<HRMMobspSelectEmailUsersInfoByUser_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<HrmDropDownItem>> SelectLeaveKinds(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<HrmDropDownItem> data = null;
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
					cRMEntities = new CRMEntities();
					List<HRMMobspSelectLeaveKinds_Result> list = Enumerable.ToList<HRMMobspSelectLeaveKinds_Result>((IEnumerable<HRMMobspSelectLeaveKinds_Result>)cRMEntities.HRMMobspSelectLeaveKinds(result, result2));
					List<HrmDropDownItem> list2 = new List<HrmDropDownItem>();
					foreach (HRMMobspSelectLeaveKinds_Result item in list)
					{
						HrmDropDownItem hrmDropDownItem = new HrmDropDownItem();
						int result3 = 0;
						int.TryParse(item.LeaveKindID.ToString(), out result3);
						hrmDropDownItem.Id = result3;
						hrmDropDownItem.Title = item.LeaveKind ?? "";
						list2.Add(hrmDropDownItem);
					}
					data = list2;
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
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<HrmDropDownItem>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<HrmDropDownItem>> SelectLeaveStayType(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<HrmDropDownItem> data = null;
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
					cRMEntities = new CRMEntities();
					List<HRMMobspSelectLeaveStayType_Result> list = Enumerable.ToList<HRMMobspSelectLeaveStayType_Result>((IEnumerable<HRMMobspSelectLeaveStayType_Result>)cRMEntities.HRMMobspSelectLeaveStayType(result, result2));
					List<HrmDropDownItem> list2 = new List<HrmDropDownItem>();
					foreach (HRMMobspSelectLeaveStayType_Result item in list)
					{
						HrmDropDownItem hrmDropDownItem = new HrmDropDownItem();
						int result3 = 0;
						int.TryParse(item.LeaveStayTypeID.ToString(), out result3);
						hrmDropDownItem.Id = result3;
						hrmDropDownItem.Title = item.LeaveStayType ?? "";
						list2.Add(hrmDropDownItem);
					}
					data = list2;
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
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<HrmDropDownItem>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<HrmDropDownItem>> SelectLeaveType(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<HrmDropDownItem> data = null;
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
					cRMEntities = new CRMEntities();
					List<HRMMobspSelectLeaveType_Result> list = Enumerable.ToList<HRMMobspSelectLeaveType_Result>((IEnumerable<HRMMobspSelectLeaveType_Result>)cRMEntities.HRMMobspSelectLeaveType(result, result2));
					List<HrmDropDownItem> list2 = new List<HrmDropDownItem>();
					foreach (HRMMobspSelectLeaveType_Result item in list)
					{
						HrmDropDownItem hrmDropDownItem = new HrmDropDownItem();
						int result3 = 0;
						int.TryParse(item.LeaveTypeID.ToString(), out result3);
						hrmDropDownItem.Id = result3;
						hrmDropDownItem.Title = item.LeaveType ?? "";
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						int result4 = 0;
						int.TryParse(item.LeaveOpr.ToString(), out result4);
						dictionary.Add("LeaveOpr", result4.ToString());
						dictionary.Add("TermText", item.TermText);
						hrmDropDownItem.ExtraField = dictionary;
						list2.Add(hrmDropDownItem);
					}
					data = list2;
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
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<HrmDropDownItem>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<HrmDropDownItem>> SelectLeaveVehicleType(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<HrmDropDownItem> data = null;
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
					cRMEntities = new CRMEntities();
					List<HRMMobspSelectLeaveVehicleType_Result> list = Enumerable.ToList<HRMMobspSelectLeaveVehicleType_Result>((IEnumerable<HRMMobspSelectLeaveVehicleType_Result>)cRMEntities.HRMMobspSelectLeaveVehicleType(result, result2));
					List<HrmDropDownItem> list2 = new List<HrmDropDownItem>();
					foreach (HRMMobspSelectLeaveVehicleType_Result item in list)
					{
						HrmDropDownItem hrmDropDownItem = new HrmDropDownItem();
						int result3 = 0;
						int.TryParse(item.LeavdVehicleTypeID.ToString(), out result3);
						hrmDropDownItem.Id = result3;
						hrmDropDownItem.Title = item.LeaveVehicleType ?? "";
						list2.Add(hrmDropDownItem);
					}
					data = list2;
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
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<HrmDropDownItem>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<HRMMobspSelectVerificationWorkFlows_Result>> SelectVerificationWorkFlows(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<HRMMobspSelectVerificationWorkFlows_Result> data = null;
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
					cRMEntities = new CRMEntities();
					data = Enumerable.ToList<HRMMobspSelectVerificationWorkFlows_Result>((IEnumerable<HRMMobspSelectVerificationWorkFlows_Result>)cRMEntities.HRMMobspSelectVerificationWorkFlows(result, result2));
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
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<HRMMobspSelectVerificationWorkFlows_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<HRMMobspSelectVerificationWorkFlowSteps_Result>> SelectVerificationWorkFlowSteps(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<HRMMobspSelectVerificationWorkFlowSteps_Result> data = null;
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
					cRMEntities = new CRMEntities();
					data = Enumerable.ToList<HRMMobspSelectVerificationWorkFlowSteps_Result>((IEnumerable<HRMMobspSelectVerificationWorkFlowSteps_Result>)cRMEntities.HRMMobspSelectVerificationWorkFlowSteps(result, result2));
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
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<HRMMobspSelectVerificationWorkFlowSteps_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}
}
