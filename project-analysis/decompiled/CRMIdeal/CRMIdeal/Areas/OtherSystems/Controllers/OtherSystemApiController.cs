using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Areas.Products.Controllers;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using Elmah;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.OtherSystems.Controllers;

public class OtherSystemApiController : ApiController
{
	[HttpPost]
	[MobileApiAuthorize]
	public ServiceResult<string> GetPreOrderSepPayIsCqhAndLastFp(int PayId, int LinkAccSettingDBId = 0, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		int culture = ((result > 0) ? result : result2);
		string data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		new BaseInfo().SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new MobileApi().GetToken(token) != null)
				{
					data = "";
					data = new PreOrderController().GetSepPayIsCqhAndLastFp(PayId, LinkAccSettingDBId);
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
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileApiAuthorize]
	public ServiceResult<string> GetOrderSepPayIsCqhAndLastFp(int PayId, int LinkAccSettingDBId = 0, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		int culture = ((result > 0) ? result : result2);
		string data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		new BaseInfo().SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new MobileApi().GetToken(token) != null)
				{
					data = "";
					data = new OrderController().GetSepPayIsCqhAndLastFp(PayId, LinkAccSettingDBId);
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
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileApiAuthorize]
	public ServiceResult<string> PreOrderSepActSendToAcc(int Mode, int PordId, int PayId, int SepFiscalYearRef, int SepUserId, bool SendPordPayToAcc, int Position = 0, int LinkAccSettingDBId = 0, int? ln = 0)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		int culture = ((result > 0) ? result : result2);
		string data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		new BaseInfo().SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				MobileApiTokenViewModel token2 = new MobileApi().GetToken(token);
				if (token2 != null)
				{
					data = "";
					data = new PreOrderController().SepActSendToAcc(Mode, PordId, PayId, SepFiscalYearRef, SepUserId, SendPordPayToAcc, Position, LinkAccSettingDBId, token2.userId);
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
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileApiAuthorize]
	public ServiceResult<string> OrderSepActSendToAcc(int Mode, int OrdId, int PayId, int OprTyep, int SepFiscalYearRef, int SepUserId, bool SendPordPayToAcc, bool SendOrdPayToAcc, bool SendPreOrderToAcc, int Position = 0, int LinkAccSettingDBId = 0, int? ln = 0)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		int culture = ((result > 0) ? result : result2);
		string data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		new BaseInfo().SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				MobileApiTokenViewModel token2 = new MobileApi().GetToken(token);
				if (token2 != null)
				{
					data = "";
					OrderController orderController = new OrderController();
					bool sendOrdPayToAcc = SendOrdPayToAcc;
					bool sendPreOrderToAcc = SendPreOrderToAcc;
					bool sendPordPayToAcc = SendPordPayToAcc;
					data = orderController.SepActSendToAcc(Mode, OrdId, OprTyep, PayId, SepFiscalYearRef, SepUserId, sendPordPayToAcc, sendOrdPayToAcc, sendPreOrderToAcc, Position, LinkAccSettingDBId, sendDocToAcc: false, 0, 0, sepInvIsReturn: false, sendOrdCommToAcc: false, 0, token2.userId);
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
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileApiAuthorize]
	public ServiceResult<int> GetWrhsSyncTypeId(int linkAccSystemId, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		int culture = ((result > 0) ? result : result2);
		int data = 0;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		new BaseInfo().SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new MobileApi().GetToken(token) != null)
				{
					switch (linkAccSystemId)
					{
					case 8:
					{
						CRMIdeal.Classes.Helper.OtherSystems.ShygunSettingViewModel shygunSetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunSetting();
						if (shygunSetting != null)
						{
							data = shygunSetting.WrhsSyncTypeId;
						}
						break;
					}
					case 9:
					{
						CRMIdeal.Classes.Helper.OtherSystems.ShygunIISettingViewModel shygunIISetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunIISetting();
						if (shygunIISetting != null)
						{
							data = shygunIISetting.WrhsSyncTypeId;
						}
						break;
					}
					case 11:
					{
						CRMIdeal.Classes.Helper.OtherSystems.ShomaranSettingViewModel shomaranSetting = CRMIdeal.Classes.Helper.OtherSystems.GetShomaranSetting();
						if (shomaranSetting != null)
						{
							data = shomaranSetting.WrhsSyncTypeId;
						}
						break;
					}
					case 12:
					{
						CRMIdeal.Classes.Helper.OtherSystems.ArpaSettingViewModel arpaSetting = CRMIdeal.Classes.Helper.OtherSystems.GetArpaSetting();
						if (arpaSetting != null)
						{
							data = arpaSetting.WrhsSyncTypeId;
						}
						break;
					}
					case 17:
					{
						CRMIdeal.Classes.Helper.OtherSystems.HamrahanSettingViewModel hamrahanSetting = CRMIdeal.Classes.Helper.OtherSystems.GetHamrahanSetting();
						if (hamrahanSetting != null)
						{
							data = hamrahanSetting.WrhsSyncTypeId;
						}
						break;
					}
					case 18:
					{
						CRMIdeal.Classes.Helper.OtherSystems.NoAvaranCapillarySettingViewModel noAvaranCapillarySetting = CRMIdeal.Classes.Helper.OtherSystems.GetNoAvaranCapillarySetting();
						if (noAvaranCapillarySetting != null)
						{
							data = noAvaranCapillarySetting.WrhsSyncTypeId;
						}
						break;
					}
					case 19:
					{
						CRMIdeal.Classes.Helper.OtherSystems.RahkaranRetailSettingViewModel rahkaranRetailSetting = CRMIdeal.Classes.Helper.OtherSystems.GetRahkaranRetailSetting();
						if (rahkaranRetailSetting != null)
						{
							data = rahkaranRetailSetting.WrhsSyncTypeId;
						}
						break;
					}
					case 20:
					{
						CRMIdeal.Classes.Helper.OtherSystems.NilramSettingViewModel nilramSetting = CRMIdeal.Classes.Helper.OtherSystems.GetNilramSetting();
						if (nilramSetting != null)
						{
							data = nilramSetting.WrhsSyncTypeId;
						}
						break;
					}
					case 22:
						data = new CRMIdeal.Classes.Helper.OtherSystems.RahkaranInternalSalesProvider(isUpdateList: false, isLogin: false).WrhsSyncTypeId;
						break;
					case 23:
						data = new CRMIdeal.Classes.Helper.OtherSystems.RayvarzProvider(isUpdateList: false, isLogin: false).WrhsSyncTypeId;
						break;
					}
					message = "";
					status = ServiceResultStatus.Success;
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
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return new ServiceResult<int>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileApiAuthorize]
	public ServiceResult<List<SelectListItemViewModel>> GetLinkAccWareHousesList(int whId = 0, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		int culture = ((result > 0) ? result : result2);
		List<SelectListItemViewModel> list = new List<SelectListItemViewModel>();
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		new BaseInfo().SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new MobileApi().GetToken(token) != null)
				{
					CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
					WSspSelectWareHouseWithAccLinkField_Result wSspSelectWareHouseWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)new SearchController().GetLinkAccWhList(fillAuto: true, withWrhsLinkAccWhCode: false, withWrhsLinkAccWhId: false, withWrhsLinkAccWhIdStr: false, withWrhsLinkAccWareHouses: true), (Func<WSspSelectWareHouseWithAccLinkField_Result, bool>)((WSspSelectWareHouseWithAccLinkField_Result x) => x.WareHouseID == whId));
					if (wSspSelectWareHouseWithAccLinkField_Result != null && cRMspSelectCrmsysSetting_Result != null)
					{
						int result3 = 0;
						int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result3);
						string text = "";
						string value = "";
						text = wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhName;
						switch (result3)
						{
						case 8:
						{
							text = "";
							value = "";
							if (string.IsNullOrWhiteSpace(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses))
							{
								break;
							}
							List<CommonWithIdStrViewModel> list8 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses);
							if (list8 == null || list8.Count <= 0)
							{
								break;
							}
							foreach (CommonWithIdStrViewModel item in list8)
							{
								list.Add(new SelectListItemViewModel
								{
									Text = item.Name,
									Value = item.Code,
									Selected = false
								});
							}
							break;
						}
						case 9:
						{
							text = "";
							value = "";
							if (string.IsNullOrWhiteSpace(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses))
							{
								break;
							}
							List<CommonWithIdStrViewModel> list9 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses);
							if (list9 == null || list9.Count <= 0)
							{
								break;
							}
							foreach (CommonWithIdStrViewModel item2 in list9)
							{
								list.Add(new SelectListItemViewModel
								{
									Text = item2.Name,
									Value = item2.Code,
									Selected = false
								});
							}
							break;
						}
						case 11:
						{
							text = "";
							value = "";
							if (string.IsNullOrWhiteSpace(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses))
							{
								break;
							}
							List<CommonWithIdStrViewModel> list5 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses);
							if (list5 == null || list5.Count <= 0)
							{
								break;
							}
							foreach (CommonWithIdStrViewModel item3 in list5)
							{
								list.Add(new SelectListItemViewModel
								{
									Text = item3.Name,
									Value = item3.Code,
									Selected = false
								});
							}
							break;
						}
						case 12:
						{
							text = "";
							value = "";
							if (string.IsNullOrWhiteSpace(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses))
							{
								break;
							}
							List<CommonWithIdStrViewModel> list3 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses);
							if (list3 == null || list3.Count <= 0)
							{
								break;
							}
							foreach (CommonWithIdStrViewModel item4 in list3)
							{
								list.Add(new SelectListItemViewModel
								{
									Text = item4.Name,
									Value = item4.Id,
									Selected = false
								});
							}
							break;
						}
						case 17:
						{
							text = "";
							value = "";
							if (string.IsNullOrWhiteSpace(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses))
							{
								break;
							}
							List<CommonWithIdStrViewModel> list4 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses);
							if (list4 == null || list4.Count <= 0)
							{
								break;
							}
							foreach (CommonWithIdStrViewModel item5 in list4)
							{
								list.Add(new SelectListItemViewModel
								{
									Text = item5.Name,
									Value = item5.Id,
									Selected = false
								});
							}
							break;
						}
						case 18:
						{
							text = "";
							value = "";
							if (string.IsNullOrWhiteSpace(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses))
							{
								break;
							}
							List<CommonWithIdStrViewModel> list7 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses);
							if (list7 == null || list7.Count <= 0)
							{
								break;
							}
							foreach (CommonWithIdStrViewModel item6 in list7)
							{
								list.Add(new SelectListItemViewModel
								{
									Text = item6.Name,
									Value = item6.Id,
									Selected = false
								});
							}
							break;
						}
						case 19:
						{
							text = "";
							value = "";
							if (string.IsNullOrWhiteSpace(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses))
							{
								break;
							}
							List<CommonWithIdStrViewModel> list10 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses);
							if (list10 == null || list10.Count <= 0)
							{
								break;
							}
							foreach (CommonWithIdStrViewModel item7 in list10)
							{
								list.Add(new SelectListItemViewModel
								{
									Text = item7.Name,
									Value = item7.Id,
									Selected = false
								});
							}
							break;
						}
						case 20:
						{
							text = "";
							value = "";
							if (string.IsNullOrWhiteSpace(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses))
							{
								break;
							}
							List<CommonWithIdStrViewModel> list6 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses);
							if (list6 == null || list6.Count <= 0)
							{
								break;
							}
							foreach (CommonWithIdStrViewModel item8 in list6)
							{
								list.Add(new SelectListItemViewModel
								{
									Text = item8.Name,
									Value = item8.Id,
									Selected = false
								});
							}
							break;
						}
						case 22:
						case 23:
						{
							text = "";
							value = "";
							if (string.IsNullOrWhiteSpace(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses))
							{
								break;
							}
							List<CommonWithIdStrViewModel> list2 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses);
							if (list2 == null || list2.Count <= 0)
							{
								break;
							}
							foreach (CommonWithIdStrViewModel item9 in list2)
							{
								list.Add(new SelectListItemViewModel
								{
									Text = item9.Name,
									Value = item9.Id,
									Selected = false
								});
							}
							break;
						}
						default:
							text = "";
							value = "";
							break;
						case 1:
						case 2:
						case 3:
						case 4:
						case 5:
						case 6:
						case 7:
							break;
						}
						if (!string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(value))
						{
							list.Add(new SelectListItemViewModel
							{
								Text = text,
								Value = value,
								Selected = false
							});
						}
					}
					status = ServiceResultStatus.Success;
					message = "";
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					list = new List<SelectListItemViewModel>();
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				list = new List<SelectListItemViewModel>();
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return new ServiceResult<List<SelectListItemViewModel>>
		{
			Message = message,
			Data = list,
			Status = status
		};
	}

	[HttpPost]
	[MobileApiAuthorize]
	public ServiceResult<CRMIdeal.Classes.Helper.OtherSystems.SepidarHaveModulesViewModel> GetSepidarModules(int linkAccSettingDBId, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		int culture = ((result > 0) ? result : result2);
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		new BaseInfo().SetCulture(culture);
		CRMIdeal.Classes.Helper.OtherSystems.SepidarHaveModulesViewModel sepidarHaveModulesViewModel = new CRMIdeal.Classes.Helper.OtherSystems.SepidarHaveModulesViewModel
		{
			SepNotHavePordModule = false,
			SepNotHaveOrdModule = false,
			SepNotHaveBordModule = false,
			SepNotHaveDocModule = false,
			SepNotHavePayModule = false,
			SepNotHaveCommModule = false
		};
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new MobileApi().GetToken(token) != null)
				{
					sepidarHaveModulesViewModel = CRMIdeal.Classes.Helper.OtherSystems.GetSepidarModules(linkAccSettingDBId);
					if (sepidarHaveModulesViewModel == null)
					{
						sepidarHaveModulesViewModel = new CRMIdeal.Classes.Helper.OtherSystems.SepidarHaveModulesViewModel
						{
							SepNotHavePordModule = false,
							SepNotHaveOrdModule = false,
							SepNotHaveBordModule = false,
							SepNotHaveDocModule = false,
							SepNotHavePayModule = false,
							SepNotHaveCommModule = false
						};
					}
					message = null;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					sepidarHaveModulesViewModel = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				sepidarHaveModulesViewModel = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return new ServiceResult<CRMIdeal.Classes.Helper.OtherSystems.SepidarHaveModulesViewModel>
		{
			Message = message,
			Data = sepidarHaveModulesViewModel,
			Status = status
		};
	}
}
