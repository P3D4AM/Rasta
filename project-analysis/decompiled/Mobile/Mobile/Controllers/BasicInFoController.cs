using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Http;
using CRM.General.Calendar;
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

public class BasicInFoController : ApiController
{
	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<NeedUpdateDetailBaseInfoViewModel> SelectUserBaseInfoStatus(string imeiCode, string appName, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		NeedUpdateDetailBaseInfoViewModel data = null;
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
					List<MobspSelectUserBaseInfoStatus_Result> list = Enumerable.ToList<MobspSelectUserBaseInfoStatus_Result>((IEnumerable<MobspSelectUserBaseInfoStatus_Result>)cRMEntities.MobspSelectUserBaseInfoStatus(token2.userId, imeiCode, appName));
					if (list != null && Enumerable.Any<MobspSelectUserBaseInfoStatus_Result>((IEnumerable<MobspSelectUserBaseInfoStatus_Result>)list))
					{
						NeedUpdateDetailBaseInfoViewModel needUpdateDetailBaseInfoViewModel = new NeedUpdateDetailBaseInfoViewModel();
						List<string> list2 = new List<string>();
						List<string> list3 = new List<string>();
						foreach (MobspSelectUserBaseInfoStatus_Result item in list)
						{
							string[] array2;
							if (item.UserId != 0)
							{
								bool flag = !item.MobAppBaseInfoNeedUpdate.HasValue || item.MobAppBaseInfoNeedUpdate.GetValueOrDefault();
								needUpdateDetailBaseInfoViewModel.MobAppBaseInfoNeedUpdate = flag;
								needUpdateDetailBaseInfoViewModel.UserId = item.UserId;
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
						needUpdateDetailBaseInfoViewModel.Apis = list2;
						needUpdateDetailBaseInfoViewModel.MobAppBaseInfoNeedUpdateDetail = list3;
						data = needUpdateDetailBaseInfoViewModel;
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
		return new ServiceResult<NeedUpdateDetailBaseInfoViewModel>
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
		CRMEntities cRMEntities = null;
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
					cRMEntities = new CRMEntities();
					int userId = token2.userId;
					DateTime now = DateTime.Now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short.Parse(now.ToString("MM", new PersianCulture()));
					_ = Mobile.Classes.Configuration.AppType;
					cRMEntities.MobspUpdatedUserMobBaseInfo(userId, imeiCode, appName, now, registerDatePersian);
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
			cRMEntities?.Dispose();
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
	public ServiceResult<MobspSelectUserBaseInfoLastUpdate_Result> SelectUserBaseInfoLastUpdate(string imeiCode, string appName, int? ln = null)
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
		MobspSelectUserBaseInfoLastUpdate_Result data;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					data = Enumerable.FirstOrDefault<MobspSelectUserBaseInfoLastUpdate_Result>((IEnumerable<MobspSelectUserBaseInfoLastUpdate_Result>)cRMEntities.MobspSelectUserBaseInfoLastUpdate(token2.userId, imeiCode, appName));
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
		return new ServiceResult<MobspSelectUserBaseInfoLastUpdate_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectCompanyTitle(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectCompanyTitle_Result> list = Enumerable.ToList<MobspSelectCompanyTitle_Result>((IEnumerable<MobspSelectCompanyTitle_Result>)cRMEntities.MobspSelectCompanyTitle(result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectCompanyTitle_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.Id.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.Title ?? "";
						int result4 = 0;
						int.TryParse(item.OrderView.ToString(), out result4);
						dropDownItemWithParentId.OrderView = result4;
						dropDownItemWithParentId.ParentId = 0;
						dropDownItemWithParentId.ExtraField = null;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectCompanyReferUsers(int? cId = null, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectCompanyReferUsers_Result> list = Enumerable.ToList<MobspSelectCompanyReferUsers_Result>((IEnumerable<MobspSelectCompanyReferUsers_Result>)cRMEntities.MobspSelectCompanyReferUsers(token2.userId, result, result2, cId));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectCompanyReferUsers_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.Id.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.Title ?? "";
						int result4 = 0;
						int.TryParse(item.OrderView.ToString(), out result4);
						dropDownItemWithParentId.OrderView = result4;
						dropDownItemWithParentId.ParentId = 0;
						dropDownItemWithParentId.ExtraField = null;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectCompanyProvince(int? cId = null, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectCompanyProvince_Result> list = Enumerable.ToList<MobspSelectCompanyProvince_Result>((IEnumerable<MobspSelectCompanyProvince_Result>)cRMEntities.MobspSelectCompanyProvince(token2.userId, result, result2, cId));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectCompanyProvince_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.Id.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.Title ?? "";
						int result4 = 0;
						int.TryParse(item.OrderView.ToString(), out result4);
						dropDownItemWithParentId.OrderView = result4;
						int result5 = 0;
						int.TryParse(item.ParentId.ToString(), out result5);
						dropDownItemWithParentId.ParentId = result5;
						dropDownItemWithParentId.ExtraField = null;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectCompanyCity(int? cId = null, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectCompanyCity_Result> list = Enumerable.ToList<MobspSelectCompanyCity_Result>((IEnumerable<MobspSelectCompanyCity_Result>)cRMEntities.MobspSelectCompanyCity(token2.userId, result, result2, cId));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectCompanyCity_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.Id.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.Title ?? "";
						int result4 = 0;
						int.TryParse(item.OrderView.ToString(), out result4);
						dropDownItemWithParentId.OrderView = result4;
						int result5 = 0;
						int.TryParse(item.ParentId.ToString(), out result5);
						dropDownItemWithParentId.ParentId = result5;
						dropDownItemWithParentId.ExtraField = null;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectCompanyPresentation(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectCompanyPresentation_Result> list = Enumerable.ToList<MobspSelectCompanyPresentation_Result>((IEnumerable<MobspSelectCompanyPresentation_Result>)cRMEntities.MobspSelectCompanyPresentation(result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectCompanyPresentation_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.Id.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.Title ?? "";
						int result4 = 0;
						int.TryParse(item.OrderView.ToString(), out result4);
						dropDownItemWithParentId.OrderView = result4;
						dropDownItemWithParentId.ParentId = 0;
						dropDownItemWithParentId.ExtraField = null;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectCompanyType(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectCompanyType_Result> list = Enumerable.ToList<MobspSelectCompanyType_Result>((IEnumerable<MobspSelectCompanyType_Result>)cRMEntities.MobspSelectCompanyType(result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectCompanyType_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.Id.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.Title ?? "";
						int result4 = 0;
						int.TryParse(item.OrderView.ToString(), out result4);
						dropDownItemWithParentId.OrderView = result4;
						dropDownItemWithParentId.ParentId = 0;
						dropDownItemWithParentId.ExtraField = null;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectCompanyGroup(int? cId = null, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectCompanyGroup_Result> list = Enumerable.ToList<MobspSelectCompanyGroup_Result>((IEnumerable<MobspSelectCompanyGroup_Result>)cRMEntities.MobspSelectCompanyGroup(token2.userId, result, result2, cId));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectCompanyGroup_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.Id.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.Title ?? "";
						int result4 = 0;
						int.TryParse(item.OrderView.ToString(), out result4);
						dropDownItemWithParentId.OrderView = result4;
						dropDownItemWithParentId.ParentId = 0;
						dropDownItemWithParentId.ExtraField = null;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectCompanySubGroup(int? cId = null, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectCompanySubGroup_Result> list = Enumerable.ToList<MobspSelectCompanySubGroup_Result>((IEnumerable<MobspSelectCompanySubGroup_Result>)cRMEntities.MobspSelectCompanySubGroup(token2.userId, result, result2, cId));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectCompanySubGroup_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.Id.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.Title ?? "";
						int result4 = 0;
						int.TryParse(item.OrderView.ToString(), out result4);
						dropDownItemWithParentId.OrderView = result4;
						int result5 = 0;
						int.TryParse(item.ParentId.ToString(), out result5);
						dropDownItemWithParentId.ParentId = result5;
						dropDownItemWithParentId.ExtraField = null;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectCompanyGroupsII(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectCompanyGroupsII_Result> list = Enumerable.ToList<MobspSelectCompanyGroupsII_Result>((IEnumerable<MobspSelectCompanyGroupsII_Result>)cRMEntities.MobspSelectCompanyGroupsII(result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectCompanyGroupsII_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.Id.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.Title ?? "";
						int result4 = 0;
						int.TryParse(item.OrderView.ToString(), out result4);
						dropDownItemWithParentId.OrderView = result4;
						dropDownItemWithParentId.ParentId = 0;
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						dictionary.Add("Rate", item.Rate.GetValueOrDefault().ToString());
						dropDownItemWithParentId.ExtraField = dictionary;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectCompanyGroupsIII(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectCompanyGroupsIII_Result> list = Enumerable.ToList<MobspSelectCompanyGroupsIII_Result>((IEnumerable<MobspSelectCompanyGroupsIII_Result>)cRMEntities.MobspSelectCompanyGroupsIII(result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectCompanyGroupsIII_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.Id.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.Title ?? "";
						int result4 = 0;
						int.TryParse(item.OrderView.ToString(), out result4);
						dropDownItemWithParentId.OrderView = result4;
						dropDownItemWithParentId.ParentId = 0;
						dropDownItemWithParentId.ExtraField = null;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectCompanyGroupsIV(int? cId = null, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectCompanyGroupsIV_Result> list = Enumerable.ToList<MobspSelectCompanyGroupsIV_Result>((IEnumerable<MobspSelectCompanyGroupsIV_Result>)cRMEntities.MobspSelectCompanyGroupsIV(token2.userId, result, result2, cId));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectCompanyGroupsIV_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.Id.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.Title ?? "";
						int result4 = 0;
						int.TryParse(item.OrderView.ToString(), out result4);
						dropDownItemWithParentId.OrderView = result4;
						dropDownItemWithParentId.ParentId = 0;
						dropDownItemWithParentId.ExtraField = null;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectCompanyGroupsMulti(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectCompanyGroupsMulti_Result> list = Enumerable.ToList<MobspSelectCompanyGroupsMulti_Result>((IEnumerable<MobspSelectCompanyGroupsMulti_Result>)cRMEntities.MobspSelectCompanyGroupsMulti(result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectCompanyGroupsMulti_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.Id.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.Title ?? "";
						int result4 = 0;
						int.TryParse(item.OrderView.ToString(), out result4);
						dropDownItemWithParentId.OrderView = result4;
						dropDownItemWithParentId.ParentId = 0;
						dropDownItemWithParentId.ExtraField = null;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectCompanyQuickRegisterDefSetting_Result>> SelectCompanyQuickRegisterDefSetting(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspSelectCompanyQuickRegisterDefSetting_Result> data = null;
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
					data = Enumerable.ToList<MobspSelectCompanyQuickRegisterDefSetting_Result>((IEnumerable<MobspSelectCompanyQuickRegisterDefSetting_Result>)cRMEntities.MobspSelectCompanyQuickRegisterDefSetting(result, result2));
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
		return new ServiceResult<List<MobspSelectCompanyQuickRegisterDefSetting_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectCompanyCampaign(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectCompanyCampaign_Result> list = Enumerable.ToList<MobspSelectCompanyCampaign_Result>((IEnumerable<MobspSelectCompanyCampaign_Result>)cRMEntities.MobspSelectCompanyCampaign(result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectCompanyCampaign_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.CompanyCampaignId.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.CampaignName ?? "";
						int result4 = 0;
						int.TryParse(item.OrderView.ToString(), out result4);
						dropDownItemWithParentId.OrderView = result4;
						int result5 = 0;
						int.TryParse(item.ParentId.ToString(), out result5);
						dropDownItemWithParentId.ParentId = result5;
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						dictionary.Add("ParentName", item.ParentName ?? "");
						dictionary.Add("ParentPath", item.ParentPath ?? "");
						dictionary.Add("CampaignFullName", item.CampaignFullName ?? "");
						dictionary.Add("CampaignDepth", item.CampaignDepth.GetValueOrDefault().ToString());
						dictionary.Add("CampaignIsLeaf", item.CampaignIsLeaf.GetValueOrDefault() ? "true" : "false");
						dropDownItemWithParentId.ExtraField = dictionary;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> GetCompanyAddressType(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectCompanyAddressType_Result> list = Enumerable.ToList<MobspSelectCompanyAddressType_Result>((IEnumerable<MobspSelectCompanyAddressType_Result>)cRMSpEntities.MobspSelectCompanyAddressType(result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectCompanyAddressType_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.CompanyAddressTypeId.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.CompanyAddressTypeName ?? "";
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> GetUserListWithLinkedId(int linkedId, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<DropDownItemWithParentId> data = null;
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
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMSpEntities = new CRMSpEntities();
					List<MobspSelectSingleUsersForRepParam_Result> list = Enumerable.ToList<MobspSelectSingleUsersForRepParam_Result>((IEnumerable<MobspSelectSingleUsersForRepParam_Result>)cRMSpEntities.MobspSelectSingleUsersForRepParam(token2.userId, linkedId, num, result2, cId));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectSingleUsersForRepParam_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.UserId.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.UserName ?? "";
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectCountry(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectCountry_Result> list = Enumerable.ToList<MobspSelectCountry_Result>((IEnumerable<MobspSelectCountry_Result>)cRMEntities.MobspSelectCountry(result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectCountry_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.Id.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.Title ?? "";
						int result4 = 0;
						int.TryParse(item.OrderView.ToString(), out result4);
						dropDownItemWithParentId.OrderView = result4;
						dropDownItemWithParentId.ParentId = 0;
						dropDownItemWithParentId.ExtraField = null;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectGuaranty(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectGuaranty_Result> list = Enumerable.ToList<MobspSelectGuaranty_Result>((IEnumerable<MobspSelectGuaranty_Result>)cRMEntities.MobspSelectGuaranty(result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectGuaranty_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.Id.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.Title ?? "";
						int result4 = 0;
						int.TryParse(item.OrderView.ToString(), out result4);
						dropDownItemWithParentId.OrderView = result4;
						dropDownItemWithParentId.ParentId = 0;
						dropDownItemWithParentId.ExtraField = null;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectPrintFormat(int? pfTypeId = null, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					pfTypeId = pfTypeId.GetValueOrDefault();
					List<MobspSelectPrintFormat_Result> list = Enumerable.ToList<MobspSelectPrintFormat_Result>((IEnumerable<MobspSelectPrintFormat_Result>)cRMEntities.MobspSelectPrintFormat(pfTypeId, result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectPrintFormat_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.Id.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.Title ?? "";
						int result4 = 0;
						int.TryParse(item.OrderView.ToString(), out result4);
						dropDownItemWithParentId.OrderView = result4;
						int result5 = 0;
						int.TryParse(item.PrintFormatTypeId.ToString(), out result5);
						dropDownItemWithParentId.ParentId = result5;
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						dictionary.Add("FileNameWeb", item.FileNameWeb ?? "");
						dropDownItemWithParentId.ExtraField = dictionary;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectOrderPaymentTypes(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectOrderPaymentTypes_Result> list = Enumerable.ToList<MobspSelectOrderPaymentTypes_Result>((IEnumerable<MobspSelectOrderPaymentTypes_Result>)cRMEntities.MobspSelectOrderPaymentTypes(result, result2, token2.userId));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectOrderPaymentTypes_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.Id.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.Title ?? "";
						int result4 = 0;
						int.TryParse(item.OrderView.ToString(), out result4);
						dropDownItemWithParentId.OrderView = result4;
						dropDownItemWithParentId.ParentId = 0;
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						dictionary.Add("ordpayTypeBankingBankID", item.ordpayTypeBankingBankID.ToString());
						dictionary.Add("BankingBankName", item.BankingBankName.ToString());
						dictionary.Add("ordpayTypeBankingBranchID", item.ordpayTypeBankingBranchID.ToString());
						dictionary.Add("BankingBranchName", item.BankingBranchName.ToString());
						dictionary.Add("ordpayTypeBankingAccountID", item.ordpayTypeBankingAccountID.ToString());
						dictionary.Add("BankingAccountTitle", item.BankingAccountTitle.ToString());
						dictionary.Add("ordpayTypeCashId", item.ordpayTypeCashId.ToString());
						dictionary.Add("CashTitle", item.CashTitle.ToString());
						dictionary.Add("ordpayTypeGroupIdI", item.ordpayTypeGroupIdI.ToString());
						dictionary.Add("ordpayGroupIName", item.ordpayGroupIName.ToString());
						dictionary.Add("ordpayTypeGroupIdII", item.ordpayTypeGroupIdII.ToString());
						dictionary.Add("ordpayGroupIIName", item.ordpayGroupIIName.ToString());
						dictionary.Add("ordpayTypeKind", item.ordpayTypeKind.ToString());
						dictionary.Add("ordpayTypeKindTitle", item.ordpayTypeKindTitle.ToString());
						dictionary.Add("TspOrdPayTypeAcn", item.TspOrdPayTypeAcn);
						dictionary.Add("TspOrdpayTypeIinn", item.TspOrdpayTypeIinn);
						dictionary.Add("TspOrdpayTypePmt", item.TspOrdpayTypePmt.ToString());
						dictionary.Add("TspOrdpayTypeTrmn", item.TspOrdpayTypeTrmn);
						dropDownItemWithParentId.ExtraField = dictionary;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectActiveOrderPaymentTypes(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectActiveOrderPaymentTypes_Result> list = Enumerable.ToList<MobspSelectActiveOrderPaymentTypes_Result>((IEnumerable<MobspSelectActiveOrderPaymentTypes_Result>)cRMEntities.MobspSelectActiveOrderPaymentTypes(result, result2, token2.userId));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectActiveOrderPaymentTypes_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.OrderPaymentTypeId.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.ordpayType ?? "";
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						dictionary.Add("ordpayTypeBankingBankID", item.ordpayTypeBankingBankID.ToString());
						dictionary.Add("BankingBankName", item.BankingBankName);
						dictionary.Add("ordpayTypeBankingBranchID", item.ordpayTypeBankingBranchID.ToString());
						dictionary.Add("BankingBranchName", item.BankingBranchName);
						dictionary.Add("ordpayTypeBankingAccountID", item.ordpayTypeBankingAccountID.ToString());
						dictionary.Add("BankingAccountTitle", item.BankingAccountTitle);
						dictionary.Add("ordpayTypeCashId", item.ordpayTypeCashId.ToString());
						dictionary.Add("CashTitle", item.CashTitle);
						dictionary.Add("ordpayTypeGroupIdI", item.ordpayTypeGroupIdI.ToString());
						dictionary.Add("ordpayGroupIName", item.ordpayGroupIName);
						dictionary.Add("ordpayTypeGroupIdII", item.ordpayTypeGroupIdII.ToString());
						dictionary.Add("ordpayGroupIIName", item.ordpayGroupIIName);
						dictionary.Add("ordpayTypeKind", item.ordpayTypeKind.ToString());
						dictionary.Add("ordpayTypeKindTitle", item.ordpayTypeKindTitle);
						dictionary.Add("TspOrdPayTypeAcn", item.TspOrdPayTypeAcn);
						dictionary.Add("TspOrdpayTypeIinn", item.TspOrdpayTypeIinn);
						dictionary.Add("TspOrdpayTypePmt", item.TspOrdpayTypePmt.ToString());
						dictionary.Add("TspOrdpayTypeTrmn", item.TspOrdpayTypeTrmn);
						dropDownItemWithParentId.ExtraField = dictionary;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectActiveOrderPaymentTypes_Result>> SelectActiveOrderPaymentTypeList(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspSelectActiveOrderPaymentTypes_Result> data = null;
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
					data = Enumerable.ToList<MobspSelectActiveOrderPaymentTypes_Result>((IEnumerable<MobspSelectActiveOrderPaymentTypes_Result>)cRMEntities.MobspSelectActiveOrderPaymentTypes(result, result2, token2.userId));
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
		return new ServiceResult<List<MobspSelectActiveOrderPaymentTypes_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> WsSelectLogo(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectLogo_Result> list = Enumerable.ToList<MobspSelectLogo_Result>((IEnumerable<MobspSelectLogo_Result>)cRMEntities.MobspSelectLogo(result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					int num = 1;
					foreach (MobspSelectLogo_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.LogoID.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.LogoDescription ?? "";
						dropDownItemWithParentId.OrderView = num;
						dropDownItemWithParentId.ParentId = 0;
						dropDownItemWithParentId.ExtraField = null;
						list2.Add(dropDownItemWithParentId);
						num++;
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectActiveWareHouse(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectActiveWareHouse_Result> list = Enumerable.ToList<MobspSelectActiveWareHouse_Result>((IEnumerable<MobspSelectActiveWareHouse_Result>)cRMEntities.MobspSelectActiveWareHouse(token2.userId, result, result2, null));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectActiveWareHouse_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.WareHouseID.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.WrhsName ?? "";
						int orderView = 0;
						dropDownItemWithParentId.OrderView = orderView;
						dropDownItemWithParentId.ParentId = 0;
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						dictionary.Add("WrhsCode", item.WrhsCode ?? "");
						dropDownItemWithParentId.ExtraField = dictionary;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectUserIsNotActive(int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectUser_Result> list = Enumerable.ToList<MobspSelectUser_Result>(Enumerable.Where<MobspSelectUser_Result>((IEnumerable<MobspSelectUser_Result>)cRMEntities.MobspSelectUser(0, result, result2, cId), (Func<MobspSelectUser_Result, bool>)((MobspSelectUser_Result c) => c.IsActive == false || !c.IsActive.HasValue)));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					int num = 1;
					foreach (MobspSelectUser_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.UserId.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.FullName ?? "";
						dropDownItemWithParentId.OrderView = num;
						dropDownItemWithParentId.ParentId = 0;
						dropDownItemWithParentId.ExtraField = null;
						list2.Add(dropDownItemWithParentId);
						num++;
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectActiveUsers(int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectActiveUsers_Result> list = Enumerable.ToList<MobspSelectActiveUsers_Result>((IEnumerable<MobspSelectActiveUsers_Result>)cRMEntities.MobspSelectActiveUsers(result, result2, cId));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectActiveUsers_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.UserId.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.Name ?? "";
						list2.Add(dropDownItemWithParentId);
					}
					data = list2;
					message = "";
					status = ServiceResultStatus.Success;
				}
				else
				{
					data = null;
					message = Messages.MobMsgErrorAccessingToken;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				data = null;
				message = Messages.MobMsgErrorAccessingToken;
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Data = data,
			Message = message,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectAllUser(int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectUser_Result> list = Enumerable.ToList<MobspSelectUser_Result>((IEnumerable<MobspSelectUser_Result>)cRMEntities.MobspSelectUser(0, result, result2, cId));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					int num = 1;
					foreach (MobspSelectUser_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.UserId.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.FullName ?? "";
						dropDownItemWithParentId.OrderView = num;
						dropDownItemWithParentId.ParentId = 0;
						dropDownItemWithParentId.ExtraField = null;
						list2.Add(dropDownItemWithParentId);
						num++;
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectSaleCenters(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectSaleCenters_Result> list = Enumerable.ToList<MobspSelectSaleCenters_Result>((IEnumerable<MobspSelectSaleCenters_Result>)cRMEntities.MobspSelectSaleCenters(result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectSaleCenters_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.SaleCenterId.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.SaleCenterName ?? "";
						dropDownItemWithParentId.ParentId = item.ParentId.GetValueOrDefault();
						list2.Add(dropDownItemWithParentId);
					}
					data = list2;
					message = "";
					status = ServiceResultStatus.Success;
				}
				else
				{
					data = null;
					message = Messages.MobMsgErrorAccessingToken;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				data = null;
				message = Messages.MobMsgErrorAccessingToken;
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Data = data,
			Message = message,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectVerificationWorkFlowWithObjectType(int objectType, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectVerificationWorkFlowWithObjectType_Result> list = Enumerable.ToList<MobspSelectVerificationWorkFlowWithObjectType_Result>((IEnumerable<MobspSelectVerificationWorkFlowWithObjectType_Result>)cRMEntities.MobspSelectVerificationWorkFlowWithObjectType(objectType, result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectVerificationWorkFlowWithObjectType_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.VerificationWorkFlowId.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.VerificationWorkFlowTitle ?? "";
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						dictionary.Add("SequenceObservation", item.SequenceObservation.ToString());
						dictionary.Add("ObjectType", item.ObjectType.GetValueOrDefault().ToString());
						dictionary.Add("VerifyRequestText", item.VerifyRequestText ?? "");
						dropDownItemWithParentId.ExtraField = dictionary;
						list2.Add(dropDownItemWithParentId);
					}
					data = list2;
					message = "";
					status = ServiceResultStatus.Success;
				}
				else
				{
					data = null;
					message = Messages.MobMsgErrorAccessingToken;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				data = null;
				message = Messages.MobMsgErrorAccessingToken;
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Data = data,
			Message = message,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectAlternativeUsers(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectAlternativeUsers_Result> list = Enumerable.ToList<MobspSelectAlternativeUsers_Result>((IEnumerable<MobspSelectAlternativeUsers_Result>)cRMEntities.MobspSelectAlternativeUsers(token2.userId, result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectAlternativeUsers_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.UserId.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.FullName ?? "";
						list2.Add(dropDownItemWithParentId);
					}
					data = list2;
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				else
				{
					data = null;
					message = Messages.MobMsgErrorAccessingToken;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				data = null;
				message = Messages.MobMsgErrorAccessingToken;
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Data = data,
			Message = message,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectVerificationWorkFlows_Result>> SelectVerificationWorkFlows(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspSelectVerificationWorkFlows_Result> data = null;
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
					data = Enumerable.ToList<MobspSelectVerificationWorkFlows_Result>((IEnumerable<MobspSelectVerificationWorkFlows_Result>)cRMEntities.MobspSelectVerificationWorkFlows(result, result2));
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				else
				{
					data = null;
					message = Messages.MobMsgErrorAccessingToken;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				data = null;
				message = Messages.MobMsgErrorAccessingToken;
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
		return new ServiceResult<List<MobspSelectVerificationWorkFlows_Result>>
		{
			Data = data,
			Message = message,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectVerificationWorkFlowSteps_Result>> SelectVerificationWorkFlowSteps(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspSelectVerificationWorkFlowSteps_Result> data = null;
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
					data = Enumerable.ToList<MobspSelectVerificationWorkFlowSteps_Result>((IEnumerable<MobspSelectVerificationWorkFlowSteps_Result>)cRMEntities.MobspSelectVerificationWorkFlowSteps(null, result, result2));
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				else
				{
					data = null;
					message = Messages.MobMsgErrorAccessingToken;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				data = null;
				message = Messages.MobMsgErrorAccessingToken;
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
		return new ServiceResult<List<MobspSelectVerificationWorkFlowSteps_Result>>
		{
			Data = data,
			Message = message,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<MobspSelectCrmFoSetting_Result> GetCrmFoSetting(int? ln = null, int? cId = null, int? foSettingId = null)
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
		MobspSelectCrmFoSetting_Result data;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					MobspSelectCrmFoSetting_Result mobspSelectCrmFoSetting_Result = Enumerable.FirstOrDefault<MobspSelectCrmFoSetting_Result>((IEnumerable<MobspSelectCrmFoSetting_Result>)cRMEntities.MobspSelectCrmFoSetting(result, result2, cId, foSettingId));
					if (mobspSelectCrmFoSetting_Result == null)
					{
						mobspSelectCrmFoSetting_Result = new MobspSelectCrmFoSetting_Result();
					}
					if (!string.IsNullOrWhiteSpace(mobspSelectCrmFoSetting_Result.ShpPrdDefPhotoAdd))
					{
						mobspSelectCrmFoSetting_Result.ShpPrdDefPhotoAdd = Mobile.Classes.Configuration.HostTempFilesPath + mobspSelectCrmFoSetting_Result.ShpPrdDefPhotoAdd.Replace("Files/DoNotChange/", "");
					}
					data = mobspSelectCrmFoSetting_Result;
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
		return new ServiceResult<MobspSelectCrmFoSetting_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<MobspSelectCrmFoSetting_Result> GetCrmFoSettingWithoutLogin(int? ln = null, int? cId = null, int? foSettingId = null)
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
		MobspSelectCrmFoSetting_Result data;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string text = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				new Common().GetToken(text);
				if (text != null && text == "CrmIdealMob")
				{
					cRMEntities = new CRMEntities();
					if (!foSettingId.HasValue)
					{
						foSettingId = FoCenter.GetFoSettingShareInfo().FoSettingShareId;
					}
					MobspSelectCrmFoSetting_Result mobspSelectCrmFoSetting_Result = Enumerable.FirstOrDefault<MobspSelectCrmFoSetting_Result>((IEnumerable<MobspSelectCrmFoSetting_Result>)cRMEntities.MobspSelectCrmFoSetting(result, result2, cId, foSettingId));
					if (mobspSelectCrmFoSetting_Result == null)
					{
						mobspSelectCrmFoSetting_Result = new MobspSelectCrmFoSetting_Result();
					}
					if (!string.IsNullOrWhiteSpace(mobspSelectCrmFoSetting_Result.ShpPrdDefPhotoAdd))
					{
						mobspSelectCrmFoSetting_Result.ShpPrdDefPhotoAdd = Mobile.Classes.Configuration.HostTempFilesPath + mobspSelectCrmFoSetting_Result.ShpPrdDefPhotoAdd.Replace("Files/DoNotChange/", "");
					}
					data = mobspSelectCrmFoSetting_Result;
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
		return new ServiceResult<MobspSelectCrmFoSetting_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<MobspSelectEmailSetting_Result> GetEmailSetting(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		MobspSelectEmailSetting_Result data = null;
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
					data = Enumerable.FirstOrDefault<MobspSelectEmailSetting_Result>((IEnumerable<MobspSelectEmailSetting_Result>)cRMEntities.MobspSelectEmailSetting("", ""));
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
		return new ServiceResult<MobspSelectEmailSetting_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectEmailUserDefaultSettingByUser(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectEmailUserDefaultSettingByUser_Result> list = Enumerable.ToList<MobspSelectEmailUserDefaultSettingByUser_Result>((IEnumerable<MobspSelectEmailUserDefaultSettingByUser_Result>)cRMEntities.MobspSelectEmailUserDefaultSettingByUser(token2.userId));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectEmailUserDefaultSettingByUser_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.EmailUserDefaultSettingId.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.eudTitle ?? "";
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						string value = item.eudBody ?? "";
						dictionary.Add("eudBody", value);
						dropDownItemWithParentId.ExtraField = dictionary;
						list2.Add(dropDownItemWithParentId);
					}
					data = list2;
					message = "";
					status = ServiceResultStatus.Success;
				}
				else
				{
					data = null;
					message = Messages.MobMsgErrorAccessingToken;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				data = null;
				message = Messages.MobMsgErrorAccessingToken;
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Data = data,
			Message = message,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectActiveEmailUsersInfoByUserId(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectActiveEmailUsersInfoByUserId_Result> list = Enumerable.ToList<MobspSelectActiveEmailUsersInfoByUserId_Result>((IEnumerable<MobspSelectActiveEmailUsersInfoByUserId_Result>)cRMEntities.MobspSelectActiveEmailUsersInfoByUserId(token2.userId));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectActiveEmailUsersInfoByUserId_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.EmailUsersInfoId.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.euNikeName + "[" + item.euNikeEmail + "]";
						list2.Add(dropDownItemWithParentId);
					}
					data = list2;
					message = "";
					status = ServiceResultStatus.Success;
				}
				else
				{
					data = null;
					message = Messages.MobMsgErrorAccessingToken;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				data = null;
				message = Messages.MobMsgErrorAccessingToken;
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Data = data,
			Message = message,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectUserDepartments(int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectUserDepartments_Result> list = Enumerable.ToList<MobspSelectUserDepartments_Result>((IEnumerable<MobspSelectUserDepartments_Result>)cRMSpEntities.MobspSelectUserDepartments(result, result2, cId));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					int num = 1;
					foreach (MobspSelectUserDepartments_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.DepartmentID.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.Department ?? "";
						dropDownItemWithParentId.OrderView = num;
						dropDownItemWithParentId.ParentId = 0;
						dropDownItemWithParentId.ExtraField = null;
						list2.Add(dropDownItemWithParentId);
						num++;
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<MobspSelectCrmsysCISetting_Result> GetCrmSysCISetting(int? ln)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		MobspSelectCrmsysCISetting_Result data;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMSpEntities = new CRMSpEntities();
					MobspSelectCrmsysCISetting_Result mobspSelectCrmsysCISetting_Result = Enumerable.FirstOrDefault<MobspSelectCrmsysCISetting_Result>((IEnumerable<MobspSelectCrmsysCISetting_Result>)cRMSpEntities.MobspSelectCrmsysCISetting());
					if (mobspSelectCrmsysCISetting_Result == null)
					{
						mobspSelectCrmsysCISetting_Result = new MobspSelectCrmsysCISetting_Result();
					}
					data = mobspSelectCrmsysCISetting_Result;
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
		return new ServiceResult<MobspSelectCrmsysCISetting_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectPersonTitle(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectPersonTitle_Result> list = Enumerable.ToList<MobspSelectPersonTitle_Result>((IEnumerable<MobspSelectPersonTitle_Result>)cRMEntities.MobspSelectPersonTitle(result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectPersonTitle_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.Id.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.Title ?? "";
						int result4 = 0;
						int.TryParse(item.OrderView.ToString(), out result4);
						dropDownItemWithParentId.OrderView = result4;
						dropDownItemWithParentId.ParentId = 0;
						dropDownItemWithParentId.ExtraField = null;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectPersonJob(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectPersonJobs_Result> list = Enumerable.ToList<MobspSelectPersonJobs_Result>((IEnumerable<MobspSelectPersonJobs_Result>)cRMEntities.MobspSelectPersonJobs(result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectPersonJobs_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.Id.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.Title ?? "";
						int result4 = 0;
						int.TryParse(item.OrderView.ToString(), out result4);
						dropDownItemWithParentId.OrderView = result4;
						dropDownItemWithParentId.ParentId = 0;
						dropDownItemWithParentId.ExtraField = null;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectPersonDepartment(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectPersonDepartments_Result> list = Enumerable.ToList<MobspSelectPersonDepartments_Result>((IEnumerable<MobspSelectPersonDepartments_Result>)cRMEntities.MobspSelectPersonDepartments(result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectPersonDepartments_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.Id.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.Title ?? "";
						int result4 = 0;
						int.TryParse(item.OrderView.ToString(), out result4);
						dropDownItemWithParentId.OrderView = result4;
						dropDownItemWithParentId.ParentId = 0;
						dropDownItemWithParentId.ExtraField = null;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectPersonType(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectPersonType_Result> list = Enumerable.ToList<MobspSelectPersonType_Result>((IEnumerable<MobspSelectPersonType_Result>)cRMEntities.MobspSelectPersonType(result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectPersonType_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.Id.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.Title ?? "";
						int result4 = 0;
						int.TryParse(item.OrderView.ToString(), out result4);
						dropDownItemWithParentId.OrderView = result4;
						dropDownItemWithParentId.ParentId = 0;
						dropDownItemWithParentId.ExtraField = null;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectPersonGroup(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectPersonGroups_Result> list = Enumerable.ToList<MobspSelectPersonGroups_Result>((IEnumerable<MobspSelectPersonGroups_Result>)cRMEntities.MobspSelectPersonGroups(result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectPersonGroups_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.Id.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.Title ?? "";
						int result4 = 0;
						int.TryParse(item.OrderView.ToString(), out result4);
						dropDownItemWithParentId.OrderView = result4;
						dropDownItemWithParentId.ParentId = 0;
						dropDownItemWithParentId.ExtraField = null;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectEducation(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectEducation_Result> list = Enumerable.ToList<MobspSelectEducation_Result>((IEnumerable<MobspSelectEducation_Result>)cRMEntities.MobspSelectEducation(result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectEducation_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.Id.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.Title ?? "";
						int result4 = 0;
						int.TryParse(item.OrderView.ToString(), out result4);
						dropDownItemWithParentId.OrderView = result4;
						dropDownItemWithParentId.ParentId = 0;
						dropDownItemWithParentId.ExtraField = null;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectGender(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectSex_Result> list = Enumerable.ToList<MobspSelectSex_Result>((IEnumerable<MobspSelectSex_Result>)cRMEntities.MobspSelectSex(result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectSex_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.Id.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.Title ?? "";
						int result4 = 0;
						int.TryParse(item.OrderView.ToString(), out result4);
						dropDownItemWithParentId.OrderView = result4;
						dropDownItemWithParentId.ParentId = 0;
						dropDownItemWithParentId.ExtraField = null;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectProjectStarterUser(int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectUserForLinkedType_Result> list = Enumerable.ToList<MobspSelectUserForLinkedType_Result>((IEnumerable<MobspSelectUserForLinkedType_Result>)cRMEntities.MobspSelectUserForLinkedType(token2.userId, 11, result, result2, cId, null));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectUserForLinkedType_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.Id.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.Title ?? "";
						int result4 = 0;
						int.TryParse(item.OrderView.ToString(), out result4);
						dropDownItemWithParentId.OrderView = result4;
						dropDownItemWithParentId.ParentId = 0;
						dropDownItemWithParentId.ExtraField = null;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectProjectFinishedUser(int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectUserForLinkedType_Result> list = Enumerable.ToList<MobspSelectUserForLinkedType_Result>((IEnumerable<MobspSelectUserForLinkedType_Result>)cRMEntities.MobspSelectUserForLinkedType(token2.userId, 12, result, result2, cId, null));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectUserForLinkedType_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.Id.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.Title ?? "";
						int result4 = 0;
						int.TryParse(item.OrderView.ToString(), out result4);
						dropDownItemWithParentId.OrderView = result4;
						dropDownItemWithParentId.ParentId = 0;
						dropDownItemWithParentId.ExtraField = null;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectConversationStatusGroup(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectActiveConversationStatusGroups_Result> list = Enumerable.ToList<MobspSelectActiveConversationStatusGroups_Result>((IEnumerable<MobspSelectActiveConversationStatusGroups_Result>)cRMEntities.MobspSelectActiveConversationStatusGroups(result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectActiveConversationStatusGroups_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.ConversationStatusGroupID.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.ConversationStatusGroup ?? "";
						int result4 = 0;
						int.TryParse(item.OrderView.ToString(), out result4);
						dropDownItemWithParentId.OrderView = result4;
						dropDownItemWithParentId.ParentId = 0;
						dropDownItemWithParentId.ExtraField = null;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectProjectGrade(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectProjectGrade_Result> list = Enumerable.ToList<MobspSelectProjectGrade_Result>((IEnumerable<MobspSelectProjectGrade_Result>)cRMEntities.MobspSelectProjectGrade(result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectProjectGrade_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.Id.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.Title ?? "";
						int result4 = 0;
						int.TryParse(item.OrderView.ToString(), out result4);
						dropDownItemWithParentId.OrderView = result4;
						dropDownItemWithParentId.ParentId = 0;
						dropDownItemWithParentId.ExtraField = null;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectProjectGroups(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectProjectGroups_Result> list = Enumerable.ToList<MobspSelectProjectGroups_Result>((IEnumerable<MobspSelectProjectGroups_Result>)cRMEntities.MobspSelectProjectGroups(result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectProjectGroups_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.Id.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.Title ?? "";
						int result4 = 0;
						int.TryParse(item.OrderView.ToString(), out result4);
						dropDownItemWithParentId.OrderView = result4;
						dropDownItemWithParentId.ParentId = 0;
						dropDownItemWithParentId.ExtraField = null;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectProjectPriority(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectProjectPriority_Result> list = Enumerable.ToList<MobspSelectProjectPriority_Result>((IEnumerable<MobspSelectProjectPriority_Result>)cRMEntities.MobspSelectProjectPriority(result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectProjectPriority_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.Id.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.Title ?? "";
						int result4 = 0;
						int.TryParse(item.OrderView.ToString(), out result4);
						dropDownItemWithParentId.OrderView = result4;
						dropDownItemWithParentId.ParentId = 0;
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						dictionary.Add("color", (item.Color != null && item.Color.Length > 8) ? ("#" + item.Color.Substring(7, 2) + item.Color.Substring(5, 2) + item.Color.Substring(3, 2)) : "");
						dropDownItemWithParentId.ExtraField = dictionary;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectCompanyProjectTitle(int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectCompanyProjectTitle_Result> list = Enumerable.ToList<MobspSelectCompanyProjectTitle_Result>((IEnumerable<MobspSelectCompanyProjectTitle_Result>)cRMEntities.MobspSelectCompanyProjectTitle("", token2.userId, result, result2, cId));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					int num = 1;
					foreach (MobspSelectCompanyProjectTitle_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						dropDownItemWithParentId.Id = num;
						string text = item.prjTitle ?? "";
						int valueOrDefault = item.ProjectTitleStatusGroupId.GetValueOrDefault();
						int valueOrDefault2 = item.ProjectTitleGroupId.GetValueOrDefault();
						int valueOrDefault3 = item.ProjectTitleGradeId.GetValueOrDefault();
						int valueOrDefault4 = item.ProjectTitlePriorityId.GetValueOrDefault();
						string value = item.ProjectTitleDesc ?? "";
						int valueOrDefault5 = item.ProjectCategoryId.GetValueOrDefault();
						int valueOrDefault6 = item.PrjTitleGroupId.GetValueOrDefault();
						string value2 = item.PrjTitleGroup ?? "";
						string value3 = item.PrjPostFix ?? "";
						int valueOrDefault7 = item.PrjRemindDay.GetValueOrDefault();
						bool valueOrDefault8 = item.PrjFOCmpCanSee.GetValueOrDefault();
						bool valueOrDefault9 = item.PrjIsTicket.GetValueOrDefault();
						dropDownItemWithParentId.Title = text;
						dropDownItemWithParentId.OrderView = num;
						dropDownItemWithParentId.ParentId = 0;
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						dictionary.Add("prjcnvsStatusGroupId", valueOrDefault.ToString());
						dictionary.Add("prjGroupId", valueOrDefault2.ToString());
						dictionary.Add("prjGradeId", valueOrDefault3.ToString());
						dictionary.Add("prjPriorityId", valueOrDefault4.ToString());
						dictionary.Add("prjDesc", value);
						dictionary.Add("prjCategoryId", valueOrDefault5.ToString());
						dictionary.Add("prjTitleGroupId", valueOrDefault6.ToString());
						dictionary.Add("prjTitleGroup", value2);
						dictionary.Add("prjPostFix", value3);
						dictionary.Add("prjRemindDay", valueOrDefault7.ToString());
						dictionary.Add("prjFOCmpCanSee", valueOrDefault8.ToString().ToLower());
						dictionary.Add("prjIsTicket", valueOrDefault9.ToString().ToLower());
						string value4 = text + " " + item.prjStatusGroup;
						dictionary.Add("prjTitleAndStatusGroup", value4);
						dictionary.Add("prjTitle", text);
						dictionary.Add("prjcnvsStatusGroup", item.prjStatusGroup ?? "");
						dropDownItemWithParentId.ExtraField = dictionary;
						list2.Add(dropDownItemWithParentId);
						num++;
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectProjectCategory_Result>> SelectProjectCategory(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		List<MobspSelectProjectCategory_Result> data;
		string message;
		ServiceResultStatus status;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					data = Enumerable.ToList<MobspSelectProjectCategory_Result>((IEnumerable<MobspSelectProjectCategory_Result>)cRMEntities.MobspSelectProjectCategory(result, result2));
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
		return new ServiceResult<List<MobspSelectProjectCategory_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectProjectUserDepartments(int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectProjectUserDepartments_Result> list = Enumerable.ToList<MobspSelectProjectUserDepartments_Result>((IEnumerable<MobspSelectProjectUserDepartments_Result>)cRMEntities.MobspSelectProjectUserDepartments(result, result2, cId));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectProjectUserDepartments_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.DepartmentID.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.Department ?? "";
						dropDownItemWithParentId.OrderView = 0;
						dropDownItemWithParentId.ParentId = 0;
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						dictionary.Add("color", item.DefaultTicketUserId.GetValueOrDefault().ToString());
						dictionary.Add("CId", item.CId.GetValueOrDefault().ToString());
						dropDownItemWithParentId.ExtraField = dictionary;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SearchProjectTitleGroup(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSearchProjectTitleGroup_Result> list = Enumerable.ToList<MobspSearchProjectTitleGroup_Result>((IEnumerable<MobspSearchProjectTitleGroup_Result>)cRMEntities.MobspSearchProjectTitleGroup("", result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSearchProjectTitleGroup_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						dropDownItemWithParentId.Id = item.ProjectTitleGroupId;
						string title = item.ProjectTitleGroup ?? "";
						dropDownItemWithParentId.Title = title;
						int valueOrDefault = item.ProjectTitleGroupUserDepartmentId.GetValueOrDefault();
						dropDownItemWithParentId.OrderView = 0;
						dropDownItemWithParentId.ParentId = 0;
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						dictionary.Add("prjTitleGroupUserDepartmentId", valueOrDefault.ToString());
						dropDownItemWithParentId.ExtraField = dictionary;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectProjectTitles(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectProjectTitles_Result> list = Enumerable.ToList<MobspSelectProjectTitles_Result>((IEnumerable<MobspSelectProjectTitles_Result>)cRMEntities.MobspSelectProjectTitles(result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectProjectTitles_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.ProjectTitleID.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.ProjectTitle ?? "";
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectCompanyProjectTitles(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<string> list = Enumerable.ToList<string>((IEnumerable<string>)cRMSpEntities.MobspSelectCompanyProjectTitles(token2.userId, result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					int num = 1;
					foreach (string item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						dropDownItemWithParentId.Id = num;
						dropDownItemWithParentId.Title = item ?? "";
						list2.Add(dropDownItemWithParentId);
						num++;
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectConversationEditorUser(int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectUserForLinkedType_Result> list = Enumerable.ToList<MobspSelectUserForLinkedType_Result>((IEnumerable<MobspSelectUserForLinkedType_Result>)cRMEntities.MobspSelectUserForLinkedType(token2.userId, 9, result, result2, cId, null));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectUserForLinkedType_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.Id.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.Title ?? "";
						int result4 = 0;
						int.TryParse(item.OrderView.ToString(), out result4);
						dropDownItemWithParentId.OrderView = result4;
						dropDownItemWithParentId.ParentId = 0;
						dropDownItemWithParentId.ExtraField = null;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectConversationTopics(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectConversationTopics_Result> list = Enumerable.ToList<MobspSelectConversationTopics_Result>((IEnumerable<MobspSelectConversationTopics_Result>)cRMEntities.MobspSelectConversationTopics(result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectConversationTopics_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.Id.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.Title ?? "";
						int result4 = 0;
						int.TryParse(item.OrderView.ToString(), out result4);
						dropDownItemWithParentId.OrderView = result4;
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						dictionary.Add("CheckUserDistanceCmp", item.CheckUserDistanceCmp.GetValueOrDefault().ToString());
						dictionary.Add("UserDistanceCmpVal", item.UserDistanceCmpVal.GetValueOrDefault().ToString());
						dropDownItemWithParentId.ExtraField = dictionary;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectConversationStatus(int groupId = 0, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectConversationStatus_Result> list = Enumerable.ToList<MobspSelectConversationStatus_Result>((IEnumerable<MobspSelectConversationStatus_Result>)cRMEntities.MobspSelectConversationStatus(groupId, result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					int num = 1;
					foreach (MobspSelectConversationStatus_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.ConversationStatusID.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.Title ?? "";
						bool flag = item.UserCanCheckBeforeSend.HasValue && item.UserCanCheckBeforeSend != false;
						string value = item.SMSBodyPatternFormula ?? "";
						bool flag2 = item.ForcedStatus.HasValue && item.ForcedStatus != false;
						int result4 = 0;
						int.TryParse(item.StatusOrder.ToString(), out result4);
						string value2 = ((result4 == 0) ? "" : result4.ToString());
						bool flag3 = item.EventPolicyIsActive.HasValue && item.EventPolicyIsActive != false;
						int result5 = 0;
						int.TryParse(item.OrderView.ToString(), out result5);
						dropDownItemWithParentId.OrderView = result5;
						int result6 = 0;
						int.TryParse(item.GroupId.ToString(), out result6);
						dropDownItemWithParentId.ParentId = result6;
						int result7 = 0;
						int.TryParse(item.ProgressPercent.ToString(), out result7);
						int result8 = 0;
						int.TryParse(item.ProcessKindId.ToString(), out result8);
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						dictionary.Add("UserCanCheckBeforeSend", flag.ToString());
						dictionary.Add("SMSBodyPatternFormula", value);
						dictionary.Add("ForcedStatus", flag2.ToString());
						dictionary.Add("StatusOrder", value2);
						dictionary.Add("EventPolicyIsActive", flag3.ToString());
						dictionary.Add("ProgressPercent", result7.ToString());
						dictionary.Add("ProcessKindId", result8.ToString());
						dropDownItemWithParentId.ExtraField = dictionary;
						list2.Add(dropDownItemWithParentId);
						num++;
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectConversationPriority(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectConversationPriority_Result> list = Enumerable.ToList<MobspSelectConversationPriority_Result>((IEnumerable<MobspSelectConversationPriority_Result>)cRMEntities.MobspSelectConversationPriority(result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectConversationPriority_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.Id.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.Title ?? "";
						int result4 = 0;
						int.TryParse(item.OrderView.ToString(), out result4);
						dropDownItemWithParentId.OrderView = result4;
						dropDownItemWithParentId.ParentId = 0;
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						dictionary.Add("color", (item.Color != null && item.Color.Length > 8) ? ("#" + item.Color.Substring(7, 2) + item.Color.Substring(5, 2) + item.Color.Substring(3, 2)) : "");
						dropDownItemWithParentId.ExtraField = dictionary;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectConversationUser(int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectUserForLinkedType_Result> list = Enumerable.ToList<MobspSelectUserForLinkedType_Result>((IEnumerable<MobspSelectUserForLinkedType_Result>)cRMEntities.MobspSelectUserForLinkedType(token2.userId, 8, result, result2, cId, null));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectUserForLinkedType_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.Id.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.Title ?? "";
						int result4 = 0;
						int.TryParse(item.OrderView.ToString(), out result4);
						dropDownItemWithParentId.OrderView = result4;
						dropDownItemWithParentId.ParentId = 0;
						dropDownItemWithParentId.ExtraField = null;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectConversationReferToUser(int cmpId = 0, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<DropDownItemWithParentId> list = new List<DropDownItemWithParentId>();
					if (cmpId == 0)
					{
						foreach (MobspSelectUserForLinkedType_Result item in Enumerable.ToList<MobspSelectUserForLinkedType_Result>((IEnumerable<MobspSelectUserForLinkedType_Result>)cRMEntities.MobspSelectUserForLinkedType(token2.userId, 7, result, result2, cId, null)))
						{
							DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
							int result3 = 0;
							int.TryParse(item.Id.ToString(), out result3);
							dropDownItemWithParentId.Id = result3;
							dropDownItemWithParentId.Title = item.Title ?? "";
							int result4 = 0;
							int.TryParse(item.OrderView.ToString(), out result4);
							dropDownItemWithParentId.OrderView = result4;
							dropDownItemWithParentId.ParentId = 0;
							dropDownItemWithParentId.ExtraField = null;
							list.Add(dropDownItemWithParentId);
						}
					}
					else
					{
						string mobCnvsReferUserCmpNotAccess = Messages.MobCnvsReferUserCmpNotAccess;
						foreach (MobspSelectUserForCnvsReferToUser_Result item2 in Enumerable.ToList<MobspSelectUserForCnvsReferToUser_Result>((IEnumerable<MobspSelectUserForCnvsReferToUser_Result>)cRMEntities.MobspSelectUserForCnvsReferToUser(token2.userId, 7, cmpId, mobCnvsReferUserCmpNotAccess, result, result2, cId)))
						{
							DropDownItemWithParentId dropDownItemWithParentId2 = new DropDownItemWithParentId();
							int result5 = 0;
							int.TryParse(item2.Id.ToString(), out result5);
							dropDownItemWithParentId2.Id = result5;
							dropDownItemWithParentId2.Title = item2.Title ?? "";
							int result6 = 0;
							int.TryParse(item2.OrderView.ToString(), out result6);
							dropDownItemWithParentId2.OrderView = result6;
							dropDownItemWithParentId2.ParentId = 0;
							dropDownItemWithParentId2.ExtraField = null;
							list.Add(dropDownItemWithParentId2);
						}
					}
					data = list;
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectConversationReferToMultilUser(int cmpId = 0, int referUserId = 0, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<DropDownItemWithParentId> list = new List<DropDownItemWithParentId>();
					if (cmpId == 0)
					{
						foreach (MobspSelectUserForLinkedType_Result item in Enumerable.ToList<MobspSelectUserForLinkedType_Result>((IEnumerable<MobspSelectUserForLinkedType_Result>)cRMEntities.MobspSelectUserForLinkedType(token2.userId, 7, result, result2, cId, true)))
						{
							DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
							int result3 = 0;
							int.TryParse(item.Id.ToString(), out result3);
							dropDownItemWithParentId.Id = result3;
							dropDownItemWithParentId.Title = item.Title ?? "";
							int result4 = 0;
							int.TryParse(item.OrderView.ToString(), out result4);
							dropDownItemWithParentId.OrderView = result4;
							dropDownItemWithParentId.ParentId = 0;
							dropDownItemWithParentId.ExtraField = null;
							list.Add(dropDownItemWithParentId);
						}
					}
					else
					{
						string mobCnvsReferUserCmpNotAccess = Messages.MobCnvsReferUserCmpNotAccess;
						foreach (MobspSelectUserForCnvsReferToMultilUser_Result item2 in Enumerable.ToList<MobspSelectUserForCnvsReferToMultilUser_Result>((IEnumerable<MobspSelectUserForCnvsReferToMultilUser_Result>)cRMEntities.MobspSelectUserForCnvsReferToMultilUser(token2.userId, 7, referUserId, cmpId, mobCnvsReferUserCmpNotAccess, result, result2, cId)))
						{
							DropDownItemWithParentId dropDownItemWithParentId2 = new DropDownItemWithParentId();
							int result5 = 0;
							int.TryParse(item2.Id.ToString(), out result5);
							dropDownItemWithParentId2.Id = result5;
							dropDownItemWithParentId2.Title = item2.Title ?? "";
							int result6 = 0;
							int.TryParse(item2.OrderView.ToString(), out result6);
							dropDownItemWithParentId2.OrderView = result6;
							dropDownItemWithParentId2.ParentId = 0;
							dropDownItemWithParentId2.ExtraField = null;
							list.Add(dropDownItemWithParentId2);
						}
					}
					data = list;
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<MobspSelectConversationDefaultContext_Result> SelectConversationDefaultContext(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		MobspSelectConversationDefaultContext_Result data = null;
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
					_ = Messages.MobCnvsReferUserCmpNotAccess;
					data = Enumerable.FirstOrDefault<MobspSelectConversationDefaultContext_Result>((IEnumerable<MobspSelectConversationDefaultContext_Result>)cRMEntities.MobspSelectConversationDefaultContext(token2.userId, result, result2));
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
		return new ServiceResult<MobspSelectConversationDefaultContext_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectActiveConversationStatus_Result>> SelectConversationStatusList(int groupId = 0, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspSelectActiveConversationStatus_Result> data = null;
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
					data = Enumerable.ToList<MobspSelectActiveConversationStatus_Result>((IEnumerable<MobspSelectActiveConversationStatus_Result>)cRMEntities.MobspSelectActiveConversationStatus(groupId, result, result2));
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
		return new ServiceResult<List<MobspSelectActiveConversationStatus_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectActiveConversationStatusResult_Result>> SelectConversationStatusResult(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspSelectActiveConversationStatusResult_Result> data = null;
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
					data = Enumerable.ToList<MobspSelectActiveConversationStatusResult_Result>((IEnumerable<MobspSelectActiveConversationStatusResult_Result>)cRMEntities.MobspSelectActiveConversationStatusResult(0, result, result2));
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
		return new ServiceResult<List<MobspSelectActiveConversationStatusResult_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectFileDirectoryType(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectFileDirectoryType_Result> list = Enumerable.ToList<MobspSelectFileDirectoryType_Result>((IEnumerable<MobspSelectFileDirectoryType_Result>)cRMEntities.MobspSelectFileDirectoryType(result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectFileDirectoryType_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.Id.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.Title ?? "";
						int result4 = 0;
						int.TryParse(item.OrderView.ToString(), out result4);
						dropDownItemWithParentId.OrderView = result4;
						int result5 = 0;
						int.TryParse(item.ParentId.ToString(), out result5);
						dropDownItemWithParentId.ParentId = result5;
						dropDownItemWithParentId.ExtraField = null;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectInternalMessagePriority(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectInternalMessagePriority_Result> list = Enumerable.ToList<MobspSelectInternalMessagePriority_Result>((IEnumerable<MobspSelectInternalMessagePriority_Result>)cRMEntities.MobspSelectInternalMessagePriority(result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectInternalMessagePriority_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.Id.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.Title ?? "";
						int result4 = 0;
						int.TryParse(item.OrderView.ToString(), out result4);
						dropDownItemWithParentId.OrderView = result4;
						dropDownItemWithParentId.ParentId = 0;
						dropDownItemWithParentId.ExtraField = null;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectInternalMessageGroup(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectInternalMessageGroup_Result> list = Enumerable.ToList<MobspSelectInternalMessageGroup_Result>((IEnumerable<MobspSelectInternalMessageGroup_Result>)cRMEntities.MobspSelectInternalMessageGroup(result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectInternalMessageGroup_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.Id.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.Title ?? "";
						int result4 = 0;
						int.TryParse(item.OrderView.ToString(), out result4);
						dropDownItemWithParentId.OrderView = result4;
						dropDownItemWithParentId.ParentId = 0;
						dropDownItemWithParentId.ExtraField = null;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	public bool UpdateSelectReceiver(int currUserId, int userId, int msgTypeId, bool selected, int mode)
	{
		bool result = false;
		CRMEntities cRMEntities = null;
		try
		{
			cRMEntities = new CRMEntities();
			cRMEntities.MobspIntMsgUpdateSelectReceiver(currUserId.ToString(), userId.ToString(), selected, mode);
			result = true;
		}
		catch (Exception e)
		{
			result = false;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return result;
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectInternalMessageReceiver(int msgTypeId, bool activeInCycle = false, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					if (msgTypeId == 0)
					{
						ServiceResult<List<DropDownItemWithParentId>> result3 = new ServiceResult<List<DropDownItemWithParentId>>
						{
							Message = Messages.MobMsgErrorIntMsgTypeNotSelected,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
						cRMEntities?.Dispose();
						return result3;
					}
					cRMEntities.MobspInternalMessageLoadReceiver(token2.userId);
					if (msgTypeId == 12)
					{
						UpdateSelectReceiver(token2.userId, 0, msgTypeId, selected: false, 3);
					}
					List<MobspIntMsgSelectReceiver_Result> list = new List<MobspIntMsgSelectReceiver_Result>();
					if (activeInCycle)
					{
						if (UpdateSelectReceiver(token2.userId, token2.userId, msgTypeId, selected: false, 1))
						{
							list = Enumerable.ToList<MobspIntMsgSelectReceiver_Result>(Enumerable.Where<MobspIntMsgSelectReceiver_Result>((IEnumerable<MobspIntMsgSelectReceiver_Result>)cRMEntities.MobspIntMsgSelectReceiver(token2.userId, msgTypeId, result, result2, cId), (Func<MobspIntMsgSelectReceiver_Result, bool>)((MobspIntMsgSelectReceiver_Result model) => model.UserId != model.crmUserId)));
						}
					}
					else
					{
						list = Enumerable.ToList<MobspIntMsgSelectReceiver_Result>((IEnumerable<MobspIntMsgSelectReceiver_Result>)cRMEntities.MobspIntMsgSelectReceiver(token2.userId, msgTypeId, result, result2, cId));
					}
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspIntMsgSelectReceiver_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result4 = 0;
						int.TryParse(item.UserId.ToString(), out result4);
						dropDownItemWithParentId.Id = result4;
						dropDownItemWithParentId.Title = item.Val ?? "";
						int result5 = 0;
						int.TryParse(item.OrderView.ToString(), out result5);
						dropDownItemWithParentId.OrderView = result5;
						dropDownItemWithParentId.ParentId = 0;
						dropDownItemWithParentId.ExtraField = null;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<InternalMessageDefaultContextViewModel> SelectInternalMessageDefaultContext(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		InternalMessageDefaultContextViewModel data = null;
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
					MobspSelectInternalMessageDefaultContext_Result mobspSelectInternalMessageDefaultContext_Result = Enumerable.FirstOrDefault<MobspSelectInternalMessageDefaultContext_Result>((IEnumerable<MobspSelectInternalMessageDefaultContext_Result>)cRMEntities.MobspSelectInternalMessageDefaultContext(token2.userId, result, result2));
					InternalMessageDefaultContextViewModel internalMessageDefaultContextViewModel = new InternalMessageDefaultContextViewModel();
					if (mobspSelectInternalMessageDefaultContext_Result != null)
					{
						internalMessageDefaultContextViewModel.Id = mobspSelectInternalMessageDefaultContext_Result.Id.GetValueOrDefault();
						internalMessageDefaultContextViewModel.UserId = mobspSelectInternalMessageDefaultContext_Result.UserId.GetValueOrDefault();
						internalMessageDefaultContextViewModel.Col1 = mobspSelectInternalMessageDefaultContext_Result.Col1 ?? "";
						internalMessageDefaultContextViewModel.Col2 = mobspSelectInternalMessageDefaultContext_Result.Col2 ?? "";
						internalMessageDefaultContextViewModel.Col3 = mobspSelectInternalMessageDefaultContext_Result.Col3 ?? "";
						internalMessageDefaultContextViewModel.Col4 = mobspSelectInternalMessageDefaultContext_Result.Col4 ?? "";
						internalMessageDefaultContextViewModel.Col5 = mobspSelectInternalMessageDefaultContext_Result.Col5 ?? "";
						internalMessageDefaultContextViewModel.Col6 = mobspSelectInternalMessageDefaultContext_Result.Col6 ?? "";
						internalMessageDefaultContextViewModel.Col7 = mobspSelectInternalMessageDefaultContext_Result.Col7 ?? "";
						internalMessageDefaultContextViewModel.Col8 = mobspSelectInternalMessageDefaultContext_Result.Col8 ?? "";
						internalMessageDefaultContextViewModel.Col9 = mobspSelectInternalMessageDefaultContext_Result.Col9 ?? "";
						internalMessageDefaultContextViewModel.Col10 = mobspSelectInternalMessageDefaultContext_Result.Col10 ?? "";
						internalMessageDefaultContextViewModel.Col11 = mobspSelectInternalMessageDefaultContext_Result.Col11 ?? "";
						internalMessageDefaultContextViewModel.Col12 = mobspSelectInternalMessageDefaultContext_Result.Col12 ?? "";
						internalMessageDefaultContextViewModel.Col13 = mobspSelectInternalMessageDefaultContext_Result.Col13 ?? "";
						internalMessageDefaultContextViewModel.Col14 = mobspSelectInternalMessageDefaultContext_Result.Col14 ?? "";
						internalMessageDefaultContextViewModel.Col15 = mobspSelectInternalMessageDefaultContext_Result.Col15 ?? "";
					}
					else
					{
						internalMessageDefaultContextViewModel.Id = 0;
						internalMessageDefaultContextViewModel.UserId = token2.userId;
						internalMessageDefaultContextViewModel.Col1 = "";
						internalMessageDefaultContextViewModel.Col2 = "";
						internalMessageDefaultContextViewModel.Col3 = "";
						internalMessageDefaultContextViewModel.Col4 = "";
						internalMessageDefaultContextViewModel.Col5 = "";
						internalMessageDefaultContextViewModel.Col6 = "";
						internalMessageDefaultContextViewModel.Col7 = "";
						internalMessageDefaultContextViewModel.Col8 = "";
						internalMessageDefaultContextViewModel.Col9 = "";
						internalMessageDefaultContextViewModel.Col10 = "";
						internalMessageDefaultContextViewModel.Col11 = "";
						internalMessageDefaultContextViewModel.Col12 = "";
						internalMessageDefaultContextViewModel.Col13 = "";
						internalMessageDefaultContextViewModel.Col14 = "";
						internalMessageDefaultContextViewModel.Col15 = "";
					}
					data = internalMessageDefaultContextViewModel;
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
		return new ServiceResult<InternalMessageDefaultContextViewModel>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectUserTaskGroups(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectUserTaskGroups_Result> list = Enumerable.ToList<MobspSelectUserTaskGroups_Result>((IEnumerable<MobspSelectUserTaskGroups_Result>)cRMEntities.MobspSelectUserTaskGroups(token2.userId, result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectUserTaskGroups_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.UserTaskGroupId.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.UserTaskGroup ?? "";
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectUserTaskPriorities(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectUserTaskPriorities_Result> list = Enumerable.ToList<MobspSelectUserTaskPriorities_Result>((IEnumerable<MobspSelectUserTaskPriorities_Result>)cRMEntities.MobspSelectUserTaskPriorities(token2.userId, result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectUserTaskPriorities_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.UserTaskPriorityId.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.Priority ?? "";
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						dictionary.Add("color", (item.Color != null && item.Color.Length > 8) ? ("#" + item.Color.Substring(7, 2) + item.Color.Substring(5, 2) + item.Color.Substring(3, 2)) : "");
						dropDownItemWithParentId.ExtraField = dictionary;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectPreOrderVerifiers(int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectPreOrderVerifiers_Result> list = Enumerable.ToList<MobspSelectPreOrderVerifiers_Result>((IEnumerable<MobspSelectPreOrderVerifiers_Result>)cRMEntities.MobspSelectPreOrderVerifiers(token2.userId, result, result2, cId));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					int num = 1;
					foreach (MobspSelectPreOrderVerifiers_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.LinkedUserId.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.UserName ?? "";
						dropDownItemWithParentId.OrderView = num;
						dropDownItemWithParentId.ParentId = 0;
						dropDownItemWithParentId.ExtraField = null;
						list2.Add(dropDownItemWithParentId);
						num++;
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectPreOrderStatus(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectPreOrderStatus_Result> list = Enumerable.ToList<MobspSelectPreOrderStatus_Result>((IEnumerable<MobspSelectPreOrderStatus_Result>)cRMEntities.MobspSelectPreOrderStatus(result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectPreOrderStatus_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.PreOrderStatusId.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.PreOrderStatus ?? "";
						dropDownItemWithParentId.ParentId = 0;
						dropDownItemWithParentId.ExtraField = null;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectPreOrderReferUser(int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectUserForLinkedType_Result> list = Enumerable.ToList<MobspSelectUserForLinkedType_Result>((IEnumerable<MobspSelectUserForLinkedType_Result>)cRMEntities.MobspSelectUserForLinkedType(token2.userId, 7, result, result2, cId, null));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectUserForLinkedType_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.Id.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.Title ?? "";
						int result4 = 0;
						int.TryParse(item.OrderView.ToString(), out result4);
						dropDownItemWithParentId.OrderView = result4;
						dropDownItemWithParentId.ParentId = 0;
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						dictionary.Add("isActive", item.IsActive ? "true" : "false");
						dropDownItemWithParentId.ExtraField = dictionary;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectPreOrderActiveReferUser(int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectUserForLinkedTypeIsActive_Result> list = Enumerable.ToList<MobspSelectUserForLinkedTypeIsActive_Result>((IEnumerable<MobspSelectUserForLinkedTypeIsActive_Result>)cRMEntities.MobspSelectUserForLinkedTypeIsActive(token2.userId, 7, result, result2, cId));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectUserForLinkedTypeIsActive_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.LinkedUserId.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.UserName ?? "";
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectPreOrderOpr(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectPreOrderOpr_Result> list = Enumerable.ToList<MobspSelectPreOrderOpr_Result>((IEnumerable<MobspSelectPreOrderOpr_Result>)cRMEntities.MobspSelectPreOrderOpr(result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectPreOrderOpr_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.Id.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.Title ?? "";
						int result4 = 0;
						int.TryParse(item.OrderView.ToString(), out result4);
						dropDownItemWithParentId.OrderView = result4;
						dropDownItemWithParentId.ParentId = 0;
						dropDownItemWithParentId.ExtraField = null;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectDeliveryTime(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectDeliveryTime_Result> list = Enumerable.ToList<MobspSelectDeliveryTime_Result>((IEnumerable<MobspSelectDeliveryTime_Result>)cRMEntities.MobspSelectDeliveryTime(result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectDeliveryTime_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.Id.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.Title ?? "";
						int result4 = 0;
						int.TryParse(item.OrderView.ToString(), out result4);
						dropDownItemWithParentId.OrderView = result4;
						dropDownItemWithParentId.ParentId = 0;
						dropDownItemWithParentId.ExtraField = null;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectPayCondition(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectPayCondition_Result> list = Enumerable.ToList<MobspSelectPayCondition_Result>((IEnumerable<MobspSelectPayCondition_Result>)cRMEntities.MobspSelectPayCondition(result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectPayCondition_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.PayConditionID.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.Title ?? "";
						int result4 = 0;
						int.TryParse(item.OrderView.ToString(), out result4);
						dropDownItemWithParentId.OrderView = result4;
						dropDownItemWithParentId.ParentId = 0;
						dropDownItemWithParentId.ExtraField = null;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectCreditDuration(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectCreditDuration_Result> list = Enumerable.ToList<MobspSelectCreditDuration_Result>((IEnumerable<MobspSelectCreditDuration_Result>)cRMEntities.MobspSelectCreditDuration(result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectCreditDuration_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.CreditDurationID.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.Title ?? "";
						int result4 = 0;
						int.TryParse(item.OrderView.ToString(), out result4);
						dropDownItemWithParentId.OrderView = result4;
						dropDownItemWithParentId.ParentId = 0;
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						dictionary.Add("CreditDurationHours", item.CreditDurationHours.GetValueOrDefault().ToString());
						dropDownItemWithParentId.ExtraField = dictionary;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectPreOrderDefaultSettingByReferUserId_Result>> SelectPreOrderDefaultSettingByReferUserId(int? ln = null, string lastDateUpdate = null, string lastTimeUpdate = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspSelectPreOrderDefaultSettingByReferUserId_Result> data = null;
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
					DateTime? registerDate = null;
					try
					{
						if (!string.IsNullOrEmpty(lastDateUpdate))
						{
							lastDateUpdate = lastDateUpdate.Replace("/", "").Replace("-", "").Replace("\\", "")
								.Replace(" ", "")
								.Replace("_", "");
							if (string.IsNullOrEmpty(lastTimeUpdate))
							{
								lastTimeUpdate = "00:00:00";
							}
							registerDate = ((result != 1065) ? new DateTime?(DateTime.Parse(PersianDate.GetFormatetdDate(lastDateUpdate) + " " + lastTimeUpdate, new CultureInfo("en-US"), DateTimeStyles.None)) : new DateTime?(DateTime.Parse(PersianDate.GetFormatetdDate(lastDateUpdate) + " " + lastTimeUpdate)));
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						ServiceResult<List<MobspSelectPreOrderDefaultSettingByReferUserId_Result>> result3 = new ServiceResult<List<MobspSelectPreOrderDefaultSettingByReferUserId_Result>>
						{
							Message = Messages.MobMsgErrorDateFormatIncorrect,
							Data = null,
							Status = ServiceResultStatus.Error
						};
						cRMEntities?.Dispose();
						return result3;
					}
					data = Enumerable.ToList<MobspSelectPreOrderDefaultSettingByReferUserId_Result>((IEnumerable<MobspSelectPreOrderDefaultSettingByReferUserId_Result>)cRMEntities.MobspSelectPreOrderDefaultSettingByReferUserId(token2.userId, registerDate, result, result2));
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
		return new ServiceResult<List<MobspSelectPreOrderDefaultSettingByReferUserId_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectPreOrderDefaultSettingByReferUserIdAndIsPublic_Result>> GetPordDefSetting(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<MobspSelectPreOrderDefaultSettingByReferUserIdAndIsPublic_Result> data = null;
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
					data = Enumerable.ToList<MobspSelectPreOrderDefaultSettingByReferUserIdAndIsPublic_Result>((IEnumerable<MobspSelectPreOrderDefaultSettingByReferUserIdAndIsPublic_Result>)cRMSpEntities.MobspSelectPreOrderDefaultSettingByReferUserIdAndIsPublic(token2.userId, result, result2));
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<List<MobspSelectPreOrderDefaultSettingByReferUserIdAndIsPublic_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectCurrencyUnits(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectCurrencyUnits_Result> list = Enumerable.ToList<MobspSelectCurrencyUnits_Result>((IEnumerable<MobspSelectCurrencyUnits_Result>)cRMEntities.MobspSelectCurrencyUnits(result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectCurrencyUnits_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.CurrencyUnitID.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.CurrencyUnit ?? "";
						list2.Add(dropDownItemWithParentId);
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						dictionary.Add("isDecimal", item.IsDecimal.GetValueOrDefault() ? "true" : "false");
						dropDownItemWithParentId.ExtraField = dictionary;
					}
					data = list2;
					message = "";
					status = ServiceResultStatus.Success;
				}
				else
				{
					data = null;
					message = Messages.MobMsgErrorAccessingToken;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				data = null;
				message = Messages.MobMsgErrorAccessingToken;
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Data = data,
			Message = message,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectDeliveryTerms(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectDeliveryTerms_Result> list = Enumerable.ToList<MobspSelectDeliveryTerms_Result>((IEnumerable<MobspSelectDeliveryTerms_Result>)cRMEntities.MobspSelectDeliveryTerms(result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectDeliveryTerms_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.DeliveryTermId.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.DeliveryTerm ?? "";
						list2.Add(dropDownItemWithParentId);
					}
					data = list2;
					message = "";
					status = ServiceResultStatus.Success;
				}
				else
				{
					data = null;
					message = Messages.MobMsgErrorAccessingToken;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				data = null;
				message = Messages.MobMsgErrorAccessingToken;
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Data = data,
			Message = message,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectPreOrderTypes(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectPreOrderTypes_Result> list = Enumerable.ToList<MobspSelectPreOrderTypes_Result>((IEnumerable<MobspSelectPreOrderTypes_Result>)cRMEntities.MobspSelectPreOrderTypes(result, result2, token2.userId));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectPreOrderTypes_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.PreOrderTypeId.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.PreOrderType ?? "";
						list2.Add(dropDownItemWithParentId);
					}
					data = list2;
					message = "";
					status = ServiceResultStatus.Success;
				}
				else
				{
					data = null;
					message = Messages.MobMsgErrorAccessingToken;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				data = null;
				message = Messages.MobMsgErrorAccessingToken;
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Data = data,
			Message = message,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectPreOrderInfoUser(int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectUserForLinkedType_Result> list = Enumerable.ToList<MobspSelectUserForLinkedType_Result>((IEnumerable<MobspSelectUserForLinkedType_Result>)cRMEntities.MobspSelectUserForLinkedType(token2.userId, 15, result, result2, cId, null));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectUserForLinkedType_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.Id.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.Title ?? "";
						int result4 = 0;
						int.TryParse(item.OrderView.ToString(), out result4);
						dropDownItemWithParentId.OrderView = result4;
						dropDownItemWithParentId.ParentId = 0;
						dropDownItemWithParentId.ExtraField = null;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectPreOrderActiveInfoUser(int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectUserForLinkedTypeIsActive_Result> list = Enumerable.ToList<MobspSelectUserForLinkedTypeIsActive_Result>((IEnumerable<MobspSelectUserForLinkedTypeIsActive_Result>)cRMEntities.MobspSelectUserForLinkedTypeIsActive(token2.userId, 15, result, result2, cId));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectUserForLinkedTypeIsActive_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.LinkedUserId.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.UserName ?? "";
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectProductPriceGroup(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectProductPriceGroup_Result> list = Enumerable.ToList<MobspSelectProductPriceGroup_Result>((IEnumerable<MobspSelectProductPriceGroup_Result>)cRMEntities.MobspSelectProductPriceGroup(result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectProductPriceGroup_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.Id.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.Title ?? "";
						int result4 = 0;
						int.TryParse(item.OrderView.ToString(), out result4);
						dropDownItemWithParentId.OrderView = result4;
						dropDownItemWithParentId.ParentId = 0;
						dropDownItemWithParentId.ExtraField = null;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectProductCostGroup(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectProductCostGroup_Result> list = Enumerable.ToList<MobspSelectProductCostGroup_Result>((IEnumerable<MobspSelectProductCostGroup_Result>)cRMEntities.MobspSelectProductCostGroup(result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectProductCostGroup_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.Id.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.Title ?? "";
						int result4 = 0;
						int.TryParse(item.OrderView.ToString(), out result4);
						dropDownItemWithParentId.OrderView = result4;
						dropDownItemWithParentId.ParentId = 0;
						dropDownItemWithParentId.ExtraField = null;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectProductPrice_Result>> SelectProductPrice(int? ln = null, string lastDateUpdate = null, string lastTimeUpdate = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspSelectProductPrice_Result> data = null;
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
					DateTime? registerDate = null;
					try
					{
						if (!string.IsNullOrEmpty(lastDateUpdate))
						{
							lastDateUpdate = lastDateUpdate.Replace("/", "").Replace("-", "").Replace("\\", "")
								.Replace(" ", "")
								.Replace("_", "");
							if (string.IsNullOrEmpty(lastTimeUpdate))
							{
								lastTimeUpdate = "00:00:00";
							}
							registerDate = ((result != 1065) ? new DateTime?(DateTime.Parse(PersianDate.GetFormatetdDate(lastDateUpdate) + " " + lastTimeUpdate, new CultureInfo("en-US"), DateTimeStyles.None)) : new DateTime?(DateTime.Parse(PersianDate.GetFormatetdDate(lastDateUpdate) + " " + lastTimeUpdate)));
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						ServiceResult<List<MobspSelectProductPrice_Result>> result3 = new ServiceResult<List<MobspSelectProductPrice_Result>>
						{
							Message = Messages.MobMsgErrorDateFormatIncorrect,
							Data = null,
							Status = ServiceResultStatus.Error
						};
						cRMEntities?.Dispose();
						return result3;
					}
					data = Enumerable.ToList<MobspSelectProductPrice_Result>((IEnumerable<MobspSelectProductPrice_Result>)cRMEntities.MobspSelectProductPrice(registerDate, result, result2));
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
		return new ServiceResult<List<MobspSelectProductPrice_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<SHPMobspSelectProductPrice_Result>> SelectShopProductPrice(string ids, string split, int? ln = null, string lastDateUpdate = null, string lastTimeUpdate = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<SHPMobspSelectProductPrice_Result> data = null;
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
					DateTime? registerDate = null;
					try
					{
						if (!string.IsNullOrEmpty(lastDateUpdate))
						{
							lastDateUpdate = lastDateUpdate.Replace("/", "").Replace("-", "").Replace("\\", "")
								.Replace(" ", "")
								.Replace("_", "");
							if (string.IsNullOrEmpty(lastTimeUpdate))
							{
								lastTimeUpdate = "00:00:00";
							}
							registerDate = ((result != 1065) ? new DateTime?(DateTime.Parse(PersianDate.GetFormatetdDate(lastDateUpdate) + " " + lastTimeUpdate, new CultureInfo("en-US"), DateTimeStyles.None)) : new DateTime?(DateTime.Parse(PersianDate.GetFormatetdDate(lastDateUpdate) + " " + lastTimeUpdate)));
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						ServiceResult<List<SHPMobspSelectProductPrice_Result>> result3 = new ServiceResult<List<SHPMobspSelectProductPrice_Result>>
						{
							Message = Messages.MobMsgErrorDateFormatIncorrect,
							Data = null,
							Status = ServiceResultStatus.Error
						};
						cRMSpEntities?.Dispose();
						return result3;
					}
					data = Enumerable.ToList<SHPMobspSelectProductPrice_Result>((IEnumerable<SHPMobspSelectProductPrice_Result>)cRMSpEntities.SHPMobspSelectProductPrice(ids, ",", registerDate, result, result2));
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<List<SHPMobspSelectProductPrice_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspReturnProductCost_Result>> ReturnProductCost(int? ln = null, string lastDateUpdate = null, string lastTimeUpdate = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspReturnProductCost_Result> data = null;
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
					DateTime? registerDate = null;
					try
					{
						if (!string.IsNullOrEmpty(lastDateUpdate))
						{
							lastDateUpdate = lastDateUpdate.Replace("/", "").Replace("-", "").Replace("\\", "")
								.Replace(" ", "")
								.Replace("_", "");
							if (string.IsNullOrEmpty(lastTimeUpdate))
							{
								lastTimeUpdate = "00:00:00";
							}
							registerDate = ((result != 1065) ? new DateTime?(DateTime.Parse(PersianDate.GetFormatetdDate(lastDateUpdate) + " " + lastTimeUpdate, new CultureInfo("en-US"), DateTimeStyles.None)) : new DateTime?(DateTime.Parse(PersianDate.GetFormatetdDate(lastDateUpdate) + " " + lastTimeUpdate)));
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						ServiceResult<List<MobspReturnProductCost_Result>> result3 = new ServiceResult<List<MobspReturnProductCost_Result>>
						{
							Message = Messages.MobMsgErrorDateFormatIncorrect,
							Data = null,
							Status = ServiceResultStatus.Error
						};
						cRMEntities?.Dispose();
						return result3;
					}
					data = Enumerable.ToList<MobspReturnProductCost_Result>((IEnumerable<MobspReturnProductCost_Result>)cRMEntities.MobspReturnProductCost(registerDate, result, result2, cId));
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
		return new ServiceResult<List<MobspReturnProductCost_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspReturnProductUserDiscountValue_Result>> ReturnProductUserDiscountValue(int? ln = null, string lastDateUpdate = null, string lastTimeUpdate = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspReturnProductUserDiscountValue_Result> data = null;
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
					DateTime? registerDate = null;
					try
					{
						if (!string.IsNullOrEmpty(lastDateUpdate))
						{
							lastDateUpdate = lastDateUpdate.Replace("/", "").Replace("-", "").Replace("\\", "")
								.Replace(" ", "")
								.Replace("_", "");
							if (string.IsNullOrEmpty(lastTimeUpdate))
							{
								lastTimeUpdate = "00:00:00";
							}
							registerDate = ((result != 1065) ? new DateTime?(DateTime.Parse(PersianDate.GetFormatetdDate(lastDateUpdate) + " " + lastTimeUpdate, new CultureInfo("en-US"), DateTimeStyles.None)) : new DateTime?(DateTime.Parse(PersianDate.GetFormatetdDate(lastDateUpdate) + " " + lastTimeUpdate)));
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						ServiceResult<List<MobspReturnProductUserDiscountValue_Result>> result3 = new ServiceResult<List<MobspReturnProductUserDiscountValue_Result>>
						{
							Message = Messages.MobMsgErrorDateFormatIncorrect,
							Data = null,
							Status = ServiceResultStatus.Error
						};
						cRMEntities?.Dispose();
						return result3;
					}
					data = Enumerable.ToList<MobspReturnProductUserDiscountValue_Result>((IEnumerable<MobspReturnProductUserDiscountValue_Result>)cRMEntities.MobspReturnProductUserDiscountValue(token2.userId, registerDate));
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
		return new ServiceResult<List<MobspReturnProductUserDiscountValue_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectProducts_Result>> SelectProducts(int? ln = null, string lastDateUpdate = null, string lastTimeUpdate = null, int? LastPrdId = 0)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspSelectProducts_Result> data = null;
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
					DateTime? registerDate = null;
					try
					{
						if (!string.IsNullOrEmpty(lastDateUpdate))
						{
							lastDateUpdate = lastDateUpdate.Replace("/", "").Replace("-", "").Replace("\\", "")
								.Replace(" ", "")
								.Replace("_", "");
							if (string.IsNullOrEmpty(lastTimeUpdate))
							{
								lastTimeUpdate = "00:00:00";
							}
							registerDate = ((result != 1065) ? new DateTime?(DateTime.Parse(PersianDate.GetFormatetdDate(lastDateUpdate) + " " + lastTimeUpdate, new CultureInfo("en-US"), DateTimeStyles.None)) : new DateTime?(DateTime.Parse(PersianDate.GetFormatetdDate(lastDateUpdate) + " " + lastTimeUpdate)));
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						ServiceResult<List<MobspSelectProducts_Result>> result3 = new ServiceResult<List<MobspSelectProducts_Result>>
						{
							Message = Messages.MobMsgErrorDateFormatIncorrect,
							Data = null,
							Status = ServiceResultStatus.Error
						};
						cRMEntities?.Dispose();
						return result3;
					}
					data = Enumerable.ToList<MobspSelectProducts_Result>((IEnumerable<MobspSelectProducts_Result>)cRMEntities.MobspSelectProducts(registerDate, result, result2, LastPrdId));
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
		return new ServiceResult<List<MobspSelectProducts_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectActiveProducts_Result>> SelectActiveProducts(int PrdKind, int ShowMode, int? CompanyId = null, int? ProjectId = null, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspSelectActiveProducts_Result> data = null;
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
					data = Enumerable.ToList<MobspSelectActiveProducts_Result>((IEnumerable<MobspSelectActiveProducts_Result>)cRMEntities.MobspSelectActiveProducts(PrdKind, ShowMode, CompanyId, ProjectId, result, result2));
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
		return new ServiceResult<List<MobspSelectActiveProducts_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectUserFavProductsByUserId(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectUserFavproductsByUserId_Result> list = Enumerable.ToList<MobspSelectUserFavproductsByUserId_Result>((IEnumerable<MobspSelectUserFavproductsByUserId_Result>)cRMEntities.MobspSelectUserFavproductsByUserId(token2.userId, result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectUserFavproductsByUserId_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.UserFavproductId.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.FavprdTitle ?? "";
						int result4 = 0;
						int.TryParse(item.OrderView.ToString(), out result4);
						dropDownItemWithParentId.OrderView = result4;
						dropDownItemWithParentId.ParentId = 0;
						dropDownItemWithParentId.ExtraField = null;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectUserFavproductItems_Result>> SelectUserFavProductItems(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspSelectUserFavproductItems_Result> data = null;
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
					data = Enumerable.ToList<MobspSelectUserFavproductItems_Result>((IEnumerable<MobspSelectUserFavproductItems_Result>)cRMEntities.MobspSelectUserFavproductItems(result, result2));
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
		return new ServiceResult<List<MobspSelectUserFavproductItems_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectUserFavproductItemsByUserId_Result>> SelectUserFavProductItemsByUserId(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspSelectUserFavproductItemsByUserId_Result> data = null;
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
					data = Enumerable.ToList<MobspSelectUserFavproductItemsByUserId_Result>((IEnumerable<MobspSelectUserFavproductItemsByUserId_Result>)cRMEntities.MobspSelectUserFavproductItemsByUserId(token2.userId, result, result2));
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
		return new ServiceResult<List<MobspSelectUserFavproductItemsByUserId_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectProductUnits(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectProductUnits_Result> list = Enumerable.ToList<MobspSelectProductUnits_Result>((IEnumerable<MobspSelectProductUnits_Result>)cRMEntities.MobspSelectProductUnits(result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectProductUnits_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.ProductUnitID.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.Unit ?? "";
						int orderView = 0;
						dropDownItemWithParentId.OrderView = orderView;
						dropDownItemWithParentId.ParentId = 0;
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						dictionary.Add("FCR", (!item.FCR.HasValue) ? "" : item.FCR.ToString());
						dictionary.Add("FCRI", (!item.FCRI.HasValue) ? "" : item.FCRI.ToString());
						dictionary.Add("Quantity", (!item.QuantityInUnit.HasValue) ? "" : item.QuantityInUnit.ToString());
						dictionary.Add("UnitIFormula", item.UnitIFormula ?? "");
						dictionary.Add("UnitIIFormula", item.UnitIIFormula ?? "");
						dropDownItemWithParentId.ExtraField = dictionary;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectCurrencyUnitRate_Result>> SelectCurrencyUnitRate(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspSelectCurrencyUnitRate_Result> data = null;
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
					data = Enumerable.ToList<MobspSelectCurrencyUnitRate_Result>((IEnumerable<MobspSelectCurrencyUnitRate_Result>)cRMEntities.MobspSelectCurrencyUnitRate(result, result2));
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
		return new ServiceResult<List<MobspSelectCurrencyUnitRate_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectLinkedProducts_Result>> SelectLinkedProducts(int? ln = null, int? lastPrdLinkId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspSelectLinkedProducts_Result> data = null;
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
					data = Enumerable.ToList<MobspSelectLinkedProducts_Result>((IEnumerable<MobspSelectLinkedProducts_Result>)cRMEntities.MobspSelectLinkedProducts(result, result2, lastPrdLinkId));
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
		return new ServiceResult<List<MobspSelectLinkedProducts_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<SHPMobspSelectProductFirstGroup_Result>> SHPSelectProductFirstGroup(int ShowMode, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<SHPMobspSelectProductFirstGroup_Result> data = null;
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
					data = Enumerable.ToList<SHPMobspSelectProductFirstGroup_Result>((IEnumerable<SHPMobspSelectProductFirstGroup_Result>)cRMSpEntities.SHPMobspSelectProductFirstGroup(ShowMode, result, result2));
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<List<SHPMobspSelectProductFirstGroup_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<SHPMobspSelectProductSecondGroup_Result>> SHPSelectProductSecondGroup(int ShowMode, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<SHPMobspSelectProductSecondGroup_Result> data = null;
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
					data = Enumerable.ToList<SHPMobspSelectProductSecondGroup_Result>((IEnumerable<SHPMobspSelectProductSecondGroup_Result>)cRMSpEntities.SHPMobspSelectProductSecondGroup(ShowMode, result, result2));
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<List<SHPMobspSelectProductSecondGroup_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<SHPMobspSelectActiveProducts_Result>> SHPSelectActiveProducts(int PrdKind, int ShowMode, int? CompanyId = null, int? ProjectId = null, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<SHPMobspSelectActiveProducts_Result> data = null;
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
					data = Enumerable.ToList<SHPMobspSelectActiveProducts_Result>((IEnumerable<SHPMobspSelectActiveProducts_Result>)cRMSpEntities.SHPMobspSelectActiveProducts(PrdKind, ShowMode, CompanyId, ProjectId, result, result2));
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<List<SHPMobspSelectActiveProducts_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectProductColor(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectProductColor_Result> list = Enumerable.ToList<MobspSelectProductColor_Result>((IEnumerable<MobspSelectProductColor_Result>)cRMEntities.MobspSelectProductColor(result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectProductColor_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.ProductColorID.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.Color ?? "";
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectOrderOpr(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectOrderOpr_Result> list = Enumerable.ToList<MobspSelectOrderOpr_Result>((IEnumerable<MobspSelectOrderOpr_Result>)cRMEntities.MobspSelectOrderOpr(result, result2, token2.userId));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectOrderOpr_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.Id.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.Title ?? "";
						int result4 = 0;
						int.TryParse(item.OrderView.ToString(), out result4);
						dropDownItemWithParentId.OrderView = result4;
						dropDownItemWithParentId.ParentId = 0;
						dropDownItemWithParentId.ExtraField = null;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectOrderReferUser(int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectUserForLinkedType_Result> list = Enumerable.ToList<MobspSelectUserForLinkedType_Result>((IEnumerable<MobspSelectUserForLinkedType_Result>)cRMEntities.MobspSelectUserForLinkedType(token2.userId, 7, result, result2, cId, null));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectUserForLinkedType_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.Id.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.Title ?? "";
						int result4 = 0;
						int.TryParse(item.OrderView.ToString(), out result4);
						dropDownItemWithParentId.OrderView = result4;
						dropDownItemWithParentId.ParentId = 0;
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						dictionary.Add("isActive", item.IsActive ? "true" : "false");
						dropDownItemWithParentId.ExtraField = dictionary;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SettlementType(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSettlementType_Result> list = Enumerable.ToList<MobspSettlementType_Result>((IEnumerable<MobspSettlementType_Result>)cRMEntities.MobspSettlementType(result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSettlementType_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.Id.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.Title ?? "";
						int result4 = 0;
						int.TryParse(item.OrderView.ToString(), out result4);
						dropDownItemWithParentId.OrderView = result4;
						dropDownItemWithParentId.ParentId = 0;
						dropDownItemWithParentId.ExtraField = null;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectOrderDefaultSettingByReferUserId_Result>> SelectOrderDefaultSettingByReferUserId(int? ln = null, string lastDateUpdate = null, string lastTimeUpdate = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspSelectOrderDefaultSettingByReferUserId_Result> data = null;
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
					DateTime? registerDate = null;
					try
					{
						if (!string.IsNullOrEmpty(lastDateUpdate))
						{
							lastDateUpdate = lastDateUpdate.Replace("/", "").Replace("-", "").Replace("\\", "")
								.Replace(" ", "")
								.Replace("_", "");
							if (string.IsNullOrEmpty(lastTimeUpdate))
							{
								lastTimeUpdate = "00:00:00";
							}
							registerDate = ((result != 1065) ? new DateTime?(DateTime.Parse(PersianDate.GetFormatetdDate(lastDateUpdate) + " " + lastTimeUpdate, new CultureInfo("en-US"), DateTimeStyles.None)) : new DateTime?(DateTime.Parse(PersianDate.GetFormatetdDate(lastDateUpdate) + " " + lastTimeUpdate)));
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						ServiceResult<List<MobspSelectOrderDefaultSettingByReferUserId_Result>> result3 = new ServiceResult<List<MobspSelectOrderDefaultSettingByReferUserId_Result>>
						{
							Message = Messages.MobMsgErrorDateFormatIncorrect,
							Data = null,
							Status = ServiceResultStatus.Error
						};
						cRMEntities?.Dispose();
						return result3;
					}
					data = Enumerable.ToList<MobspSelectOrderDefaultSettingByReferUserId_Result>((IEnumerable<MobspSelectOrderDefaultSettingByReferUserId_Result>)cRMEntities.MobspSelectOrderDefaultSettingByReferUserId(token2.userId, registerDate, result, result2));
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
		return new ServiceResult<List<MobspSelectOrderDefaultSettingByReferUserId_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectOrderDefaultSettingByReferUserIdAndIsPublic_Result>> GetOrdDefSetting(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<MobspSelectOrderDefaultSettingByReferUserIdAndIsPublic_Result> data = null;
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
					data = Enumerable.ToList<MobspSelectOrderDefaultSettingByReferUserIdAndIsPublic_Result>((IEnumerable<MobspSelectOrderDefaultSettingByReferUserIdAndIsPublic_Result>)cRMSpEntities.MobspSelectOrderDefaultSettingByReferUserIdAndIsPublic(token2.userId, result, result2));
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<List<MobspSelectOrderDefaultSettingByReferUserIdAndIsPublic_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectOrderStatus(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectOrderStatus_Result> list = Enumerable.ToList<MobspSelectOrderStatus_Result>((IEnumerable<MobspSelectOrderStatus_Result>)cRMEntities.MobspSelectOrderStatus(result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectOrderStatus_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.OrderStatusId.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.OrderStatus ?? "";
						dropDownItemWithParentId.ParentId = 0;
						dropDownItemWithParentId.ExtraField = null;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectOrderVerifiers(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectOrderVerifiers_Result> list = Enumerable.ToList<MobspSelectOrderVerifiers_Result>((IEnumerable<MobspSelectOrderVerifiers_Result>)cRMEntities.MobspSelectOrderVerifiers(token2.userId, result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectOrderVerifiers_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.LinkedUserId.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.UserName ?? "";
						dropDownItemWithParentId.ParentId = 0;
						dropDownItemWithParentId.ExtraField = null;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectOrderInfoUser(int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectUserForLinkedType_Result> list = Enumerable.ToList<MobspSelectUserForLinkedType_Result>((IEnumerable<MobspSelectUserForLinkedType_Result>)cRMEntities.MobspSelectUserForLinkedType(token2.userId, 16, result, result2, cId, null));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectUserForLinkedType_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.Id.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.Title ?? "";
						int result4 = 0;
						int.TryParse(item.OrderView.ToString(), out result4);
						dropDownItemWithParentId.OrderView = result4;
						dropDownItemWithParentId.ParentId = 0;
						dropDownItemWithParentId.ExtraField = null;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectOrderActiveReferUser(int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectUserForLinkedTypeIsActive_Result> list = Enumerable.ToList<MobspSelectUserForLinkedTypeIsActive_Result>((IEnumerable<MobspSelectUserForLinkedTypeIsActive_Result>)cRMEntities.MobspSelectUserForLinkedTypeIsActive(token2.userId, 7, result, result2, cId));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectUserForLinkedTypeIsActive_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.LinkedUserId.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.UserName ?? "";
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectOrderGroups(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectOrderGroups_Result> list = Enumerable.ToList<MobspSelectOrderGroups_Result>((IEnumerable<MobspSelectOrderGroups_Result>)cRMSpEntities.MobspSelectOrderGroups(result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectOrderGroups_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.OrderGroupId.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.OrderGroupName ?? "";
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						dictionary.Add("LinkAccGroupIdStr", item.LinkAccGroupIdStr);
						dictionary.Add("LinkAccData", item.LinkAccData);
						dropDownItemWithParentId.ExtraField = dictionary;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectOrderPaymentGroupsI(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectOrderPaymentGroupsI_Result> list = Enumerable.ToList<MobspSelectOrderPaymentGroupsI_Result>((IEnumerable<MobspSelectOrderPaymentGroupsI_Result>)cRMSpEntities.MobspSelectOrderPaymentGroupsI(result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectOrderPaymentGroupsI_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.OrderPaymentGroupIId.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.ordpayGroupIName ?? "";
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						dictionary.Add("ordpayGroupICode", item.ordpayGroupICode);
						dictionary.Add("ordpayGroupILinkAccData", item.ordpayGroupILinkAccData);
						dropDownItemWithParentId.ExtraField = dictionary;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectOrderPaymentGroupsII(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectOrderPaymentGroupsII_Result> list = Enumerable.ToList<MobspSelectOrderPaymentGroupsII_Result>((IEnumerable<MobspSelectOrderPaymentGroupsII_Result>)cRMSpEntities.MobspSelectOrderPaymentGroupsII(result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectOrderPaymentGroupsII_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.OrderPaymentGroupIIId.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.ordpayGroupIIName ?? "";
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						dictionary.Add("ordpayGroupIICode", item.ordpayGroupIICode);
						dictionary.Add("ordpayGroupIILinkAccData", item.ordpayGroupIILinkAccData);
						dropDownItemWithParentId.ExtraField = dictionary;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectCasheList(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectCashes_Result> list = Enumerable.ToList<MobspSelectCashes_Result>((IEnumerable<MobspSelectCashes_Result>)cRMSpEntities.MobspSelectCashes(result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectCashes_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.CashId.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.CashTitle ?? "";
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						dictionary.Add("CashCode", item.CashCode);
						dictionary.Add("CashLinkAccData", item.CashLinkAccData);
						dropDownItemWithParentId.ExtraField = dictionary;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectBankingBankList(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectBankingBanks_Result> list = Enumerable.ToList<MobspSelectBankingBanks_Result>((IEnumerable<MobspSelectBankingBanks_Result>)cRMSpEntities.MobspSelectBankingBanks(result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectBankingBanks_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.BankingBankID.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.BankName ?? "";
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						dictionary.Add("Code", item.Code);
						dictionary.Add("BankDesc", item.BankDesc);
						dropDownItemWithParentId.ExtraField = dictionary;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> BankingBranchesList(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectBankingBranches_Result> list = Enumerable.ToList<MobspSelectBankingBranches_Result>((IEnumerable<MobspSelectBankingBranches_Result>)cRMSpEntities.MobspSelectBankingBranches(result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectBankingBranches_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.BankingBranchID.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.BranchName ?? "";
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						dictionary.Add("BankId", item.BankId.ToString());
						dictionary.Add("BankName", item.BankName);
						dictionary.Add("BranchCode", item.BranchCode);
						dictionary.Add("BranchAddress", item.BranchAddress);
						dictionary.Add("BranchTel", item.BranchTel);
						dictionary.Add("BranchTelII", item.BranchTelII);
						dictionary.Add("BranchDesc", item.BranchDesc);
						dropDownItemWithParentId.ExtraField = dictionary;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectBankingAccountsByBranchAndUserList(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectBankingAccountsByBranchAndUserId_Result> list = Enumerable.ToList<MobspSelectBankingAccountsByBranchAndUserId_Result>((IEnumerable<MobspSelectBankingAccountsByBranchAndUserId_Result>)cRMSpEntities.MobspSelectBankingAccountsByBranchAndUserId(0, 0, result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectBankingAccountsByBranchAndUserId_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.BankingAccountID.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.AccountTitle ?? "";
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						dictionary.Add("BranchId", item.BranchId.ToString());
						dictionary.Add("BranchName", item.BranchName);
						dictionary.Add("MasterId", item.MasterId.ToString());
						dictionary.Add("AccTypeId", item.AccTypeId.ToString());
						dictionary.Add("AccountTypeName", item.AccountTypeName);
						dictionary.Add("AccountNumber", item.AccountNumber);
						dictionary.Add("AccountType", item.AccountType);
						dictionary.Add("AccountOwner", item.AccountOwner);
						dictionary.Add("CrmUserId", item.CrmUserId.ToString());
						dictionary.Add("BankId", item.BankId.ToString());
						dictionary.Add("BankName", item.BankName);
						dictionary.Add("AccountTitle", item.AccountTitle);
						dictionary.Add("AccountShabaNumber", item.AccountShabaNumber);
						dictionary.Add("AccountCardNumber", item.AccountCardNumber);
						dictionary.Add("IsDefault", item.IsDefault.ToString());
						dictionary.Add("IsDefaultII", item.IsDefaultII.ToString());
						dictionary.Add("MobHRMVisible", item.MobHRMVisible.ToString());
						dictionary.Add("CrmUser", item.CrmUser);
						dictionary.Add("AccountLinkAccData", item.AccountLinkAccData);
						dropDownItemWithParentId.ExtraField = dictionary;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectSmsDefaultBodyTextGroups(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectSmsDefaultBodyTextGroups_Result> list = Enumerable.ToList<MobspSelectSmsDefaultBodyTextGroups_Result>((IEnumerable<MobspSelectSmsDefaultBodyTextGroups_Result>)cRMEntities.MobspSelectSmsDefaultBodyTextGroups(result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectSmsDefaultBodyTextGroups_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.Id.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.Name ?? "";
						int orderView = 0;
						dropDownItemWithParentId.OrderView = orderView;
						dropDownItemWithParentId.ParentId = 0;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectSmsDefaultBodyText(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectSmsDefaultBodyText_Result> list = Enumerable.ToList<MobspSelectSmsDefaultBodyText_Result>((IEnumerable<MobspSelectSmsDefaultBodyText_Result>)cRMEntities.MobspSelectSmsDefaultBodyText(token2.userId, result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectSmsDefaultBodyText_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.Id.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.Title ?? "";
						int orderView = 0;
						dropDownItemWithParentId.OrderView = orderView;
						dropDownItemWithParentId.ParentId = 0;
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						dictionary.Add("Text", item.Text);
						dictionary.Add("GroupId", item.GroupId.ToString());
						dropDownItemWithParentId.ExtraField = dictionary;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectReferUserCommissionUser(int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectUserForLinkedType_Result> list = Enumerable.ToList<MobspSelectUserForLinkedType_Result>((IEnumerable<MobspSelectUserForLinkedType_Result>)cRMEntities.MobspSelectUserForLinkedType(token2.userId, 21, result, result2, cId, null));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectUserForLinkedType_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.Id.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.Title ?? "";
						int result4 = 0;
						int.TryParse(item.OrderView.ToString(), out result4);
						dropDownItemWithParentId.OrderView = result4;
						dropDownItemWithParentId.ParentId = 0;
						dropDownItemWithParentId.ExtraField = null;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectCrmUserFund(int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectUserForLinkedType_Result> list = Enumerable.ToList<MobspSelectUserForLinkedType_Result>((IEnumerable<MobspSelectUserForLinkedType_Result>)cRMEntities.MobspSelectUserForLinkedType(token2.userId, 20, result, result2, cId, null));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectUserForLinkedType_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.Id.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.Title ?? "";
						int result4 = 0;
						int.TryParse(item.OrderView.ToString(), out result4);
						dropDownItemWithParentId.OrderView = result4;
						dropDownItemWithParentId.ParentId = 0;
						dropDownItemWithParentId.ExtraField = null;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectFundGroup(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectFundGroupsTree_Result> list = Enumerable.ToList<MobspSelectFundGroupsTree_Result>((IEnumerable<MobspSelectFundGroupsTree_Result>)cRMSpEntities.MobspSelectFundGroupsTree(result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectFundGroupsTree_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.FundGroupId.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.GroupName ?? "";
						int result4 = 0;
						int.TryParse(item.Level.ToString(), out result4);
						dropDownItemWithParentId.OrderView = result4;
						dropDownItemWithParentId.ParentId = item.ParentId.GetValueOrDefault();
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						dictionary.Add("path", item.Path);
						dropDownItemWithParentId.ExtraField = dictionary;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectTicketsProjectTitleGroups(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<string> list = Enumerable.ToList<string>((IEnumerable<string>)cRMEntities.MobspSelectTicketsProjectTitleGroups(result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					int num = 0;
					foreach (string item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						num = (dropDownItemWithParentId.Id = num + 1);
						dropDownItemWithParentId.Title = item;
						dropDownItemWithParentId.OrderView = 0;
						dropDownItemWithParentId.ParentId = 0;
						dropDownItemWithParentId.ExtraField = null;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectTicketProjectTitleAndTitleGroup(int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectTicketProjectTitleAndTitleGroup_Result> list = Enumerable.ToList<MobspSelectTicketProjectTitleAndTitleGroup_Result>((IEnumerable<MobspSelectTicketProjectTitleAndTitleGroup_Result>)cRMEntities.MobspSelectTicketProjectTitleAndTitleGroup(result, result2, cId));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectTicketProjectTitleAndTitleGroup_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.prjTitleGroupId.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.prjTitleGroup ?? "";
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						dictionary.Add("prjcnvsStatusGroupId", item.prjcnvsStatusGroupId.GetValueOrDefault().ToString());
						dictionary.Add("prjcnvsStatusGroup", item.prjcnvsStatusGroup ?? "");
						dictionary.Add("prjUserDepartmentId", item.prjUserDepartmentId.GetValueOrDefault().ToString());
						dictionary.Add("prjUserDepartment", item.prjUserDepartment ?? "");
						dropDownItemWithParentId.ExtraField = dictionary;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> UserTreeTimeAttendanceCartable(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspUserTreeTimeAttendanceCartable_Result> list = Enumerable.ToList<MobspUserTreeTimeAttendanceCartable_Result>((IEnumerable<MobspUserTreeTimeAttendanceCartable_Result>)cRMEntities.MobspUserTreeTimeAttendanceCartable(token2.userId, 2, result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspUserTreeTimeAttendanceCartable_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.KeyId.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.KeyName ?? "";
						int result4 = 0;
						int.TryParse(item.RootId.ToString(), out result4);
						dropDownItemWithParentId.ParentId = result4;
						dropDownItemWithParentId.ExtraField = null;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectKnowledgeTankGroup(int rollId, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspknlgSelectKnowledgeTankGroup_Result> list = Enumerable.ToList<MobspknlgSelectKnowledgeTankGroup_Result>((IEnumerable<MobspknlgSelectKnowledgeTankGroup_Result>)cRMEntities.MobspknlgSelectKnowledgeTankGroup(rollId, result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspknlgSelectKnowledgeTankGroup_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.KnowledgeTankGroupId.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.KnowledgeTankGroupTitle ?? "";
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> ForgetCrtbSelectUsers(int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspForgetCrtbSelectUsers_Result> list = Enumerable.ToList<MobspForgetCrtbSelectUsers_Result>((IEnumerable<MobspForgetCrtbSelectUsers_Result>)cRMEntities.MobspForgetCrtbSelectUsers(token2.userId, Labels.All, result, result2, cId));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspForgetCrtbSelectUsers_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.UserId.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.UserName ?? "";
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> ForgetCrtbSelectReferUsers(int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspForgetCrtbSelectReferUsers_Result> list = Enumerable.ToList<MobspForgetCrtbSelectReferUsers_Result>((IEnumerable<MobspForgetCrtbSelectReferUsers_Result>)cRMEntities.MobspForgetCrtbSelectReferUsers(token2.userId, Labels.All, result, result2, cId));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspForgetCrtbSelectReferUsers_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.ReferUserId.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.Val ?? "";
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> ForgetCrtbSelectConversationStatus(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspForgetCrtbSelectConversationStatus_Result> list = Enumerable.ToList<MobspForgetCrtbSelectConversationStatus_Result>((IEnumerable<MobspForgetCrtbSelectConversationStatus_Result>)cRMEntities.MobspForgetCrtbSelectConversationStatus(token2.userId, Labels.All, result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspForgetCrtbSelectConversationStatus_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.ID.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.Val ?? "";
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> ForgetCrtbSelectProjectTitle(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspForgetCrtbSelectProjectTitle_Result> list = Enumerable.ToList<MobspForgetCrtbSelectProjectTitle_Result>((IEnumerable<MobspForgetCrtbSelectProjectTitle_Result>)cRMEntities.MobspForgetCrtbSelectProjectTitle(token2.userId, Labels.All, result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspForgetCrtbSelectProjectTitle_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						dropDownItemWithParentId.Title = item.Val ?? "";
						list2.Add(dropDownItemWithParentId);
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						dictionary.Add("ProjectId", item.ProjectId ?? "");
						dropDownItemWithParentId.ExtraField = dictionary;
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> UserTreeBookMarksCartable(int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspUserTreeBookMarksCartable_Result> list = Enumerable.ToList<MobspUserTreeBookMarksCartable_Result>((IEnumerable<MobspUserTreeBookMarksCartable_Result>)cRMEntities.MobspUserTreeBookMarksCartable(token2.userId, 4, Labels.AllUsers, result, result2, cId));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					if (Enumerable.Any<MobspUserTreeBookMarksCartable_Result>((IEnumerable<MobspUserTreeBookMarksCartable_Result>)list))
					{
						list.Sort((MobspUserTreeBookMarksCartable_Result a, MobspUserTreeBookMarksCartable_Result b) => a.Sort.GetValueOrDefault().CompareTo(b.Sort.GetValueOrDefault()));
					}
					foreach (MobspUserTreeBookMarksCartable_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.KeyId.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.KeyName ?? "";
						int result4 = 0;
						int.TryParse(item.RootId.ToString(), out result4);
						dropDownItemWithParentId.ParentId = result4;
						dropDownItemWithParentId.ExtraField = null;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectUserTaskReminderUser(int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectUserForLinkedType_Result> list = Enumerable.ToList<MobspSelectUserForLinkedType_Result>((IEnumerable<MobspSelectUserForLinkedType_Result>)cRMEntities.MobspSelectUserForLinkedType(token2.userId, 30, result, result2, cId, null));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectUserForLinkedType_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.Id.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.Title ?? "";
						int result4 = 0;
						int.TryParse(item.OrderView.ToString(), out result4);
						dropDownItemWithParentId.OrderView = result4;
						dropDownItemWithParentId.ParentId = 0;
						dropDownItemWithParentId.ExtraField = null;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectLeaveKinds(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectLeaveKinds_Result> list = Enumerable.ToList<MobspSelectLeaveKinds_Result>((IEnumerable<MobspSelectLeaveKinds_Result>)cRMEntities.MobspSelectLeaveKinds(result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectLeaveKinds_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.LeaveKindID.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.LeaveKind ?? "";
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectLeaveStayType(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectLeaveStayType_Result> list = Enumerable.ToList<MobspSelectLeaveStayType_Result>((IEnumerable<MobspSelectLeaveStayType_Result>)cRMEntities.MobspSelectLeaveStayType(result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectLeaveStayType_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.LeaveStayTypeID.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.LeaveStayType ?? "";
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectLeaveType(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectLeaveType_Result> list = Enumerable.ToList<MobspSelectLeaveType_Result>((IEnumerable<MobspSelectLeaveType_Result>)cRMEntities.MobspSelectLeaveType(result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectLeaveType_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.LeaveTypeID.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.LeaveType ?? "";
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						int result4 = 0;
						int.TryParse(item.LeaveOpr.ToString(), out result4);
						dictionary.Add("LeaveOpr", result4.ToString());
						dictionary.Add("TermText", item.TermText);
						dropDownItemWithParentId.ExtraField = dictionary;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectLeaveVehicleType(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectLeaveVehicleType_Result> list = Enumerable.ToList<MobspSelectLeaveVehicleType_Result>((IEnumerable<MobspSelectLeaveVehicleType_Result>)cRMEntities.MobspSelectLeaveVehicleType(result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectLeaveVehicleType_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.LeavdVehicleTypeID.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.LeaveVehicleType ?? "";
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectDocOpr(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectDocOpr_Result> list = Enumerable.ToList<MobspSelectDocOpr_Result>((IEnumerable<MobspSelectDocOpr_Result>)cRMSpEntities.MobspSelectDocOpr(result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectDocOpr_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.DocOprID.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.Name ?? "";
						int result4 = 0;
						int.TryParse(item.OprType.ToString(), out result4);
						dropDownItemWithParentId.ParentId = result4;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectDocVerifiers(int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectDocVerifiers_Result> list = Enumerable.ToList<MobspSelectDocVerifiers_Result>((IEnumerable<MobspSelectDocVerifiers_Result>)cRMSpEntities.MobspSelectDocVerifiers(token2.userId, result, result2, cId));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectDocVerifiers_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.LinkedUserId.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.UserName ?? "";
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectLetterDefaultSettingsByUser_Result>> GetLetterDefaultSettings(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<MobspSelectLetterDefaultSettingsByUser_Result> data = null;
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
					data = Enumerable.ToList<MobspSelectLetterDefaultSettingsByUser_Result>((IEnumerable<MobspSelectLetterDefaultSettingsByUser_Result>)cRMSpEntities.MobspSelectLetterDefaultSettingsByUser(token2.userId, result, result2));
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<List<MobspSelectLetterDefaultSettingsByUser_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectLetterDefaultSettingsByUserAndIsPublic_Result>> GetAllLetterDefaultSettings(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<MobspSelectLetterDefaultSettingsByUserAndIsPublic_Result> data = null;
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
					data = Enumerable.ToList<MobspSelectLetterDefaultSettingsByUserAndIsPublic_Result>((IEnumerable<MobspSelectLetterDefaultSettingsByUserAndIsPublic_Result>)cRMSpEntities.MobspSelectLetterDefaultSettingsByUserAndIsPublic(token2.userId, result, result2));
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<List<MobspSelectLetterDefaultSettingsByUserAndIsPublic_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> GetLetterVerifiers(int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectUserForLinkedType_Result> list = Enumerable.ToList<MobspSelectUserForLinkedType_Result>((IEnumerable<MobspSelectUserForLinkedType_Result>)cRMEntities.MobspSelectUserForLinkedType(token2.userId, 28, result, result2, cId, null));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectUserForLinkedType_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.Id.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.Title ?? "";
						int result4 = 0;
						int.TryParse(item.OrderView.ToString(), out result4);
						dropDownItemWithParentId.OrderView = result4;
						dropDownItemWithParentId.ParentId = 0;
						dropDownItemWithParentId.ExtraField = null;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> GetLetterNumberCounter(int typeId, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					List<MobspSelectLetterNumberCounterByTypeId_Result> list = Enumerable.ToList<MobspSelectLetterNumberCounterByTypeId_Result>((IEnumerable<MobspSelectLetterNumberCounterByTypeId_Result>)cRMSpEntities.MobspSelectLetterNumberCounterByTypeId(typeId, result, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspSelectLetterNumberCounterByTypeId_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.LetterNumberCounterId.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.LtrNumCntTitle ?? "";
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						string value = item.LtrNumCntPreNumber ?? "";
						dictionary.Add("PreNumber", value);
						dropDownItemWithParentId.ExtraField = dictionary;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectOnlinePayBankInfo_Result>> SelectOnlinePayBankInfo(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<MobspSelectOnlinePayBankInfo_Result> data = null;
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
					cRMSpEntities = new CRMSpEntities();
					data = Enumerable.ToList<MobspSelectOnlinePayBankInfo_Result>((IEnumerable<MobspSelectOnlinePayBankInfo_Result>)cRMSpEntities.MobspSelectOnlinePayBankInfo(num, result2));
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
		return new ServiceResult<List<MobspSelectOnlinePayBankInfo_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectShopOnlinePayBankInfo_Result>> SelectOnlineShopPayBankInfo(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<MobspSelectShopOnlinePayBankInfo_Result> data = null;
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
					cRMSpEntities = new CRMSpEntities();
					data = Enumerable.ToList<MobspSelectShopOnlinePayBankInfo_Result>((IEnumerable<MobspSelectShopOnlinePayBankInfo_Result>)cRMSpEntities.MobspSelectShopOnlinePayBankInfo(num, result2));
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
		return new ServiceResult<List<MobspSelectShopOnlinePayBankInfo_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectSaleAreas(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					cRMSpEntities = new CRMSpEntities();
					List<MobspSelectSaleAreas_Result> list = Enumerable.ToList<MobspSelectSaleAreas_Result>((IEnumerable<MobspSelectSaleAreas_Result>)cRMSpEntities.MobspSelectSaleAreas(num, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					int num2 = 1;
					foreach (MobspSelectSaleAreas_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						dropDownItemWithParentId.OrderView = num2;
						dropDownItemWithParentId.Title = item.SaleAreaName;
						dropDownItemWithParentId.Id = item.SaleAreaId;
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						dictionary.Add("OrderView", item.OrderView.GetValueOrDefault().ToString());
						dictionary.Add("LinkAccSaleAreaIdStr", item.LinkAccSaleAreaIdStr ?? "");
						dropDownItemWithParentId.ExtraField = dictionary;
						list2.Add(dropDownItemWithParentId);
						num2++;
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> SelectShopDeliveryTerms(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					cRMSpEntities = new CRMSpEntities();
					List<SHPMobspSelectDeliveryTerms_Result> list = Enumerable.ToList<SHPMobspSelectDeliveryTerms_Result>((IEnumerable<SHPMobspSelectDeliveryTerms_Result>)cRMSpEntities.SHPMobspSelectDeliveryTerms(num, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					int num2 = 1;
					foreach (SHPMobspSelectDeliveryTerms_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						dropDownItemWithParentId.OrderView = num2;
						dropDownItemWithParentId.Title = item.DeliveryTerm;
						dropDownItemWithParentId.Id = item.DeliveryTermId;
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						dictionary.Add("OrderView", item.OrderView.GetValueOrDefault().ToString());
						dictionary.Add("SHPVisible", item.SHPVisible.GetValueOrDefault().ToString());
						dictionary.Add("SHPDefault", item.SHPDefault.GetValueOrDefault().ToString());
						dictionary.Add("SHPNeedAddress", item.SHPNeedAddress.GetValueOrDefault().ToString());
						dropDownItemWithParentId.ExtraField = dictionary;
						list2.Add(dropDownItemWithParentId);
						num2++;
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<SHPMobspSelectCompanyPersonAddress_Result>> SelectPersonAddress(int cmpId, int? ln, int? cId)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<SHPMobspSelectCompanyPersonAddress_Result> list = null;
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
					cRMSpEntities = new CRMSpEntities();
					list = Enumerable.ToList<SHPMobspSelectCompanyPersonAddress_Result>((IEnumerable<SHPMobspSelectCompanyPersonAddress_Result>)cRMSpEntities.SHPMobspSelectCompanyPersonAddress(cmpId, num, result2, cId));
					if (Enumerable.Any<SHPMobspSelectCompanyPersonAddress_Result>((IEnumerable<SHPMobspSelectCompanyPersonAddress_Result>)list))
					{
						foreach (SHPMobspSelectCompanyPersonAddress_Result item in list)
						{
							item.prsAddress = ((!string.IsNullOrWhiteSpace(item.prsCountry)) ? item.prsCountry : "") + ((!string.IsNullOrWhiteSpace(item.prsProvince)) ? ("-" + item.prsProvince) : "") + ((!string.IsNullOrWhiteSpace(item.prsCity)) ? ("-" + item.prsCity) : "") + ((!string.IsNullOrWhiteSpace(item.prsAddress)) ? ("-" + item.prsAddress) : "") + ((!string.IsNullOrWhiteSpace(item.prsZipCode)) ? ("-" + item.prsZipCode) : "") + ((!string.IsNullOrWhiteSpace(item.prsMobile)) ? (" (" + Labels.FOPrsMobile + ": " + item.prsMobile + ")") : "");
						}
					}
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
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
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			list = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<List<SHPMobspSelectCompanyPersonAddress_Result>>
		{
			Message = message,
			Data = list,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> SelectLinkAccByViewSetting(int LinkAccSystemId, int LinkAccByViewSettingId, string ObjectType, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
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
					cRMSpEntities = new CRMSpEntities();
					MobspSelectLinkAccByViewSetting_Result mobspSelectLinkAccByViewSetting_Result = Enumerable.FirstOrDefault<MobspSelectLinkAccByViewSetting_Result>((IEnumerable<MobspSelectLinkAccByViewSetting_Result>)cRMSpEntities.MobspSelectLinkAccByViewSetting(LinkAccSystemId, LinkAccByViewSettingId, ObjectType, num, result2));
					if (mobspSelectLinkAccByViewSetting_Result != null)
					{
						data = mobspSelectLinkAccByViewSetting_Result.PartValue ?? "";
					}
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
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> GetLinkAccSettingDB(int linkAccSystemId, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<DropDownItemWithParentId> data = null;
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
				if (new FoCommon().GetToken(token) != null)
				{
					cRMSpEntities = new CRMSpEntities();
					List<MobspSelectLinkAccSettingDBIsActive_Result> list = Enumerable.ToList<MobspSelectLinkAccSettingDBIsActive_Result>((IEnumerable<MobspSelectLinkAccSettingDBIsActive_Result>)cRMSpEntities.MobspSelectLinkAccSettingDBIsActive(linkAccSystemId));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					int num = 1;
					foreach (MobspSelectLinkAccSettingDBIsActive_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						dropDownItemWithParentId.OrderView = num;
						dropDownItemWithParentId.Title = item.LinkAccSettingDbTitle + "(" + item.LinkAccSettingDbName + ")";
						dropDownItemWithParentId.Id = item.LinkAccSettingDBId;
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						dictionary.Add("OrderView", item.OrderView.GetValueOrDefault().ToString());
						dictionary.Add("LinkAccSettingDbTitle", item.LinkAccSettingDbTitle);
						dictionary.Add("LinkAccSettingDbName", item.LinkAccSettingDbName);
						dictionary.Add("LinkAccSystemId", item.LinkAccSystemId.ToString());
						dictionary.Add("IsActive", item.IsActive.GetValueOrDefault().ToString());
						dropDownItemWithParentId.ExtraField = dictionary;
						list2.Add(dropDownItemWithParentId);
						num++;
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> GetSepFiscalYear(string linkAccSettingDBIds, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<DropDownItemWithParentId> data = null;
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
					cRMSpEntities = new CRMSpEntities();
					List<DropDownItemWithParentId> list = new List<DropDownItemWithParentId>();
					foreach (string item in Enumerable.ToList<string>((IEnumerable<string>)(linkAccSettingDBIds ?? "").Split(new char[1] { ',' })))
					{
						int result3 = 0;
						int.TryParse(item, out result3);
						List<MobspLkSepSelectFiscalYear_Result> list2 = Enumerable.ToList<MobspLkSepSelectFiscalYear_Result>((IEnumerable<MobspLkSepSelectFiscalYear_Result>)cRMSpEntities.MobspLkSepSelectFiscalYear(result3, num, result2));
						int num2 = 1;
						foreach (MobspLkSepSelectFiscalYear_Result item2 in list2)
						{
							DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
							dropDownItemWithParentId.OrderView = num2;
							dropDownItemWithParentId.Title = item2.Title;
							dropDownItemWithParentId.Id = item2.FiscalYearId.GetValueOrDefault();
							dropDownItemWithParentId.ParentId = result3;
							Dictionary<string, string> dictionary = new Dictionary<string, string>();
							dictionary.Add("StartDate", item2.StartDate.ToString());
							dictionary.Add("EndDate", item2.EndDate.ToString());
							dictionary.Add("Status", item2.Status.GetValueOrDefault().ToString());
							dictionary.Add("Creator", item2.Creator.GetValueOrDefault().ToString());
							dictionary.Add("CreationDate", item2.CreationDate.ToString());
							dictionary.Add("LastModifier", item2.LastModifier.GetValueOrDefault().ToString());
							dictionary.Add("LastModificationDate", item2.LastModificationDate.ToString());
							dictionary.Add("Version", item2.Version.GetValueOrDefault().ToString());
							dropDownItemWithParentId.ExtraField = dictionary;
							list.Add(dropDownItemWithParentId);
							num2++;
						}
					}
					data = list;
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItem>> ReturnExtension(int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
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
					cRMSpEntities = new CRMSpEntities();
					List<string> list = Enumerable.ToList<string>((IEnumerable<string>)cRMSpEntities.MobspSelectAllUsersExtensions(token2.userId, cId));
					List<DropDownItem> list2 = new List<DropDownItem>();
					foreach (string item in list)
					{
						DropDownItem dropDownItem = new DropDownItem();
						int result3 = 0;
						int.TryParse(item, out result3);
						dropDownItem.Id = result3;
						dropDownItem.Title = item;
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
		return new ServiceResult<List<DropDownItem>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}
}
