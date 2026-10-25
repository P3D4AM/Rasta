using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes.Common;
using Elmah;
using Newtonsoft.Json;

namespace CRMIdeal.Classes.Helper;

public class Setting
{
	public static int GetMobNumLen()
	{
		int result = 0;
		try
		{
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				result = cRMspSelectCrmsysSetting_Result.MobNumLen.GetValueOrDefault(1);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public static bool GetMobNumLenNoCheck()
	{
		bool result = false;
		try
		{
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				result = cRMspSelectCrmsysSetting_Result.MobNumLenNoCheck.HasValue && cRMspSelectCrmsysSetting_Result.MobNumLenNoCheck != false;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public static CRMspSelectFoSetting_Result GetFoSetting()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int? centerId = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId : null);
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		CRMspSelectFoSetting_Result cRMspSelectFoSetting_Result = new CRMspSelectFoSetting_Result();
		try
		{
			string positionTopRightTxt = Labels.PositionTopRightTxt;
			string positionTopCenterTxt = Labels.PositionTopCenterTxt;
			string positionTopLeftTxt = Labels.PositionTopLeftTxt;
			string positionCenterRightTxt = Labels.PositionCenterRightTxt;
			string positionCenterTxt = Labels.PositionCenterTxt;
			string positionCenterLeftTxt = Labels.PositionCenterLeftTxt;
			string positionBottomRightTxt = Labels.PositionBottomRightTxt;
			string positionBottomCenterTxt = Labels.PositionBottomCenterTxt;
			string positionBottomLeftTxt = Labels.PositionBottomLeftTxt;
			_ = Labels.SmsSendByWebTxt;
			_ = Labels.SmsSendByGsmTxt;
			string foSettingDefDisplay4Column = Labels.FoSettingDefDisplay4Column;
			string foSettingDefDisplay3Column = Labels.FoSettingDefDisplay3Column;
			string foSettingDefDisplayListView = Labels.FoSettingDefDisplayListView;
			string foSettingDefDisplayListViewSmall = Labels.FoSettingDefDisplayListViewSmall;
			int? languageID = lCID;
			int? defaultLanguageID = result;
			cRMspSelectFoSetting_Result = Enumerable.FirstOrDefault<CRMspSelectFoSetting_Result>((IEnumerable<CRMspSelectFoSetting_Result>)cRMSpEntities.CRMspSelectFoSetting(foSettingDefDisplay4Column, foSettingDefDisplay3Column, foSettingDefDisplayListView, foSettingDefDisplayListViewSmall, positionTopRightTxt, positionTopCenterTxt, positionTopLeftTxt, positionCenterRightTxt, positionCenterTxt, positionCenterLeftTxt, positionBottomRightTxt, positionBottomCenterTxt, positionBottomLeftTxt, languageID, defaultLanguageID, centerId));
			new BaseInfo();
			if (cRMspSelectFoSetting_Result == null)
			{
				cRMspSelectFoSetting_Result = new CRMspSelectFoSetting_Result();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return cRMspSelectFoSetting_Result;
	}

	public static string GetLinkAccSystemTitle(int lnId = 0)
	{
		string text = "";
		CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int num = Thread.CurrentThread.CurrentCulture.LCID;
			if (lnId != 0)
			{
				num = lnId;
			}
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				int result2 = 0;
				int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result2);
				switch (result2)
				{
				case 1:
					text = Labels.ResourceManager.GetString("Sepidar", new CultureInfo(num));
					break;
				case 2:
					text = Labels.ResourceManager.GetString("NoAvaran", new CultureInfo(num));
					break;
				case 3:
					text = Labels.ResourceManager.GetString("TarazSamaneh", new CultureInfo(num));
					break;
				case 4:
					text = Labels.ResourceManager.GetString("Holoo", new CultureInfo(num));
					break;
				case 5:
					text = Labels.ResourceManager.GetString("NoAvaranII", new CultureInfo(num));
					break;
				case 6:
				case 14:
				case 16:
					text = Labels.ResourceManager.GetString("Kyan", new CultureInfo(num));
					break;
				case 7:
					text = Labels.ResourceManager.GetString("Payvast", new CultureInfo(num));
					break;
				case 8:
					text = Labels.ResourceManager.GetString("Shygun", new CultureInfo(num));
					break;
				case 9:
					text = Labels.ResourceManager.GetString("ShygunII", new CultureInfo(num));
					break;
				case 10:
					text = Labels.ResourceManager.GetString("ChamberCommerce", new CultureInfo(num));
					break;
				case 11:
					text = Labels.ResourceManager.GetString("Shomaran", new CultureInfo(num));
					break;
				case 12:
					text = Labels.ResourceManager.GetString("Arpa", new CultureInfo(num));
					break;
				case 13:
					text = Labels.ResourceManager.GetString("Rahkaran", new CultureInfo(num));
					break;
				case 15:
				{
					CRMspSelectLinkAccByViewSetting_Result cRMspSelectLinkAccByViewSetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccByViewSetting_Result>((IEnumerable<CRMspSelectLinkAccByViewSetting_Result>)cRMLinkSpEntities.CRMspSelectLinkAccByViewSetting(linkAccByViewSettingId: 1, linkAccSystemId: result2, objectType: "Setting", languageID: num, defaultLanguageID: result));
					if (cRMspSelectLinkAccByViewSetting_Result != null)
					{
						text = cRMspSelectLinkAccByViewSetting_Result.PartValue ?? "";
					}
					if (string.IsNullOrWhiteSpace(text))
					{
						text = Labels.ResourceManager.GetString("LinkAccByView", new CultureInfo(num));
					}
					break;
				}
				case 17:
					text = Labels.ResourceManager.GetString("Hamrahan", new CultureInfo(num));
					break;
				case 18:
					text = Labels.ResourceManager.GetString("NoAvaranCapillary", new CultureInfo(num));
					break;
				case 19:
					text = Labels.ResourceManager.GetString("RahkaranRetail", new CultureInfo(num));
					break;
				case 20:
					text = Labels.ResourceManager.GetString("Nilram", new CultureInfo(num));
					break;
				case 21:
					text = Labels.ResourceManager.GetString("Hamyar", new CultureInfo(num));
					break;
				case 22:
					text = Labels.ResourceManager.GetString("RahkaranInternalSales", new CultureInfo(num));
					break;
				case 23:
					text = Labels.ResourceManager.GetString("Rayvarz", new CultureInfo(num));
					break;
				case 24:
					text = Labels.ResourceManager.GetString("Karamad", new CultureInfo(num));
					break;
				case 25:
					text = Labels.ResourceManager.GetString("ArianSystem", new CultureInfo(num));
					break;
				case 26:
					text = Labels.ResourceManager.GetString("ShygunDetailedAPI", new CultureInfo(num));
					break;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMLinkSpEntities.Dispose();
		}
		return text;
	}

	public static List<SelectListItem> GetFoSettingLoginAuthenticationType()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			list.Add(new SelectListItem
			{
				Text = Labels.FoSettingLoginAuthenticationTypeUserName,
				Value = "1"
			});
			list.Add(new SelectListItem
			{
				Text = Labels.FoSettingLoginAuthenticationTypeMobile,
				Value = "2"
			});
			list.Add(new SelectListItem
			{
				Text = Labels.FoSettingLoginAuthenticationTypeEmail,
				Value = "3"
			});
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return list;
	}

	public static List<SelectListItem> GetFoSettingLoginType()
	{
		return new List<SelectListItem>
		{
			new SelectListItem
			{
				Text = Labels.FoSettingLoginTypeCompany,
				Value = "1"
			},
			new SelectListItem
			{
				Text = Labels.FoSettingLoginTypePerson,
				Value = "2"
			}
		};
	}

	public static string GetRegNullableFieldsJson(string regNullableFields)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		string result = "";
		try
		{
			List<CrmFoRegisterSettingNullableFieldsViewModel> list = new List<CrmFoRegisterSettingNullableFieldsViewModel>();
			if (!string.IsNullOrWhiteSpace(regNullableFields))
			{
				List<CrmFoRegisterSettingNullableFieldsViewModel> list2 = new JavaScriptSerializer().Deserialize<List<CrmFoRegisterSettingNullableFieldsViewModel>>(regNullableFields);
				if (list2 != null && Enumerable.Any<CrmFoRegisterSettingNullableFieldsViewModel>((IEnumerable<CrmFoRegisterSettingNullableFieldsViewModel>)list2))
				{
					foreach (CrmFoRegisterSettingNullableFieldsViewModel item in list2)
					{
						list.Add(new CrmFoRegisterSettingNullableFieldsViewModel
						{
							FName = item.FName,
							NotNULL = item.NotNULL.GetValueOrDefault()
						});
					}
				}
			}
			if (list == null || !Enumerable.Any<CrmFoRegisterSettingNullableFieldsViewModel>((IEnumerable<CrmFoRegisterSettingNullableFieldsViewModel>)list))
			{
				list.Add(new CrmFoRegisterSettingNullableFieldsViewModel
				{
					FName = "CmpNationalCode",
					NotNULL = false
				});
				list.Add(new CrmFoRegisterSettingNullableFieldsViewModel
				{
					FName = "PrsFName",
					NotNULL = false
				});
				list.Add(new CrmFoRegisterSettingNullableFieldsViewModel
				{
					FName = "CmpMobile",
					NotNULL = false
				});
				list.Add(new CrmFoRegisterSettingNullableFieldsViewModel
				{
					FName = "PrsNationalCode",
					NotNULL = false
				});
				list.Add(new CrmFoRegisterSettingNullableFieldsViewModel
				{
					FName = "CmpTel",
					NotNULL = false
				});
				list.Add(new CrmFoRegisterSettingNullableFieldsViewModel
				{
					FName = "CmpEmail",
					NotNULL = false
				});
				list.Add(new CrmFoRegisterSettingNullableFieldsViewModel
				{
					FName = "CmpCountryId",
					NotNULL = false
				});
				list.Add(new CrmFoRegisterSettingNullableFieldsViewModel
				{
					FName = "CmpProvinceId",
					NotNULL = false
				});
				list.Add(new CrmFoRegisterSettingNullableFieldsViewModel
				{
					FName = "CmpCityId",
					NotNULL = false
				});
				list.Add(new CrmFoRegisterSettingNullableFieldsViewModel
				{
					FName = "CmpAddress",
					NotNULL = false
				});
				list.Add(new CrmFoRegisterSettingNullableFieldsViewModel
				{
					FName = "PrsJobId",
					NotNULL = false
				});
			}
			if (list != null && Enumerable.Any<CrmFoRegisterSettingNullableFieldsViewModel>((IEnumerable<CrmFoRegisterSettingNullableFieldsViewModel>)list))
			{
				result = JsonConvert.SerializeObject(Enumerable.ToList<CrmFoRegisterSettingNullableFieldsViewModel>((IEnumerable<CrmFoRegisterSettingNullableFieldsViewModel>)list));
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	public static string GetRegNullableFieldsByTitleJson(string regNullableFields)
	{
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CrmFoRegisterSettingNullableFieldsByTitleViewModel> list = new List<CrmFoRegisterSettingNullableFieldsByTitleViewModel>();
			if (!string.IsNullOrWhiteSpace(regNullableFields))
			{
				List<CrmFoRegisterSettingNullableFieldsByTitleViewModel> list2 = new JavaScriptSerializer().Deserialize<List<CrmFoRegisterSettingNullableFieldsByTitleViewModel>>(regNullableFields);
				if (list2 != null && Enumerable.Any<CrmFoRegisterSettingNullableFieldsByTitleViewModel>((IEnumerable<CrmFoRegisterSettingNullableFieldsByTitleViewModel>)list2))
				{
					foreach (CrmFoRegisterSettingNullableFieldsByTitleViewModel item in list2)
					{
						string text = "FORegister" + item.FName;
						if (text.EndsWith("Id"))
						{
							text = text.Substring(0, text.Length - 2);
						}
						list.Add(new CrmFoRegisterSettingNullableFieldsByTitleViewModel
						{
							FName = item.FName,
							FTitle = Labels.ResourceManager.GetString(text, new CultureInfo(lCID)),
							NotNULL = item.NotNULL.GetValueOrDefault()
						});
					}
				}
			}
			if (list == null || !Enumerable.Any<CrmFoRegisterSettingNullableFieldsByTitleViewModel>((IEnumerable<CrmFoRegisterSettingNullableFieldsByTitleViewModel>)list))
			{
				list.Add(new CrmFoRegisterSettingNullableFieldsByTitleViewModel
				{
					FName = "CmpNationalCode",
					NotNULL = false
				});
				list.Add(new CrmFoRegisterSettingNullableFieldsByTitleViewModel
				{
					FName = "PrsFName",
					NotNULL = false
				});
				list.Add(new CrmFoRegisterSettingNullableFieldsByTitleViewModel
				{
					FName = "CmpMobile",
					NotNULL = false
				});
				list.Add(new CrmFoRegisterSettingNullableFieldsByTitleViewModel
				{
					FName = "PrsNationalCode",
					NotNULL = false
				});
				list.Add(new CrmFoRegisterSettingNullableFieldsByTitleViewModel
				{
					FName = "CmpTel",
					NotNULL = false
				});
				list.Add(new CrmFoRegisterSettingNullableFieldsByTitleViewModel
				{
					FName = "CmpEmail",
					NotNULL = false
				});
				list.Add(new CrmFoRegisterSettingNullableFieldsByTitleViewModel
				{
					FName = "CmpCountryId",
					NotNULL = false
				});
				list.Add(new CrmFoRegisterSettingNullableFieldsByTitleViewModel
				{
					FName = "CmpProvinceId",
					NotNULL = false
				});
				list.Add(new CrmFoRegisterSettingNullableFieldsByTitleViewModel
				{
					FName = "CmpCityId",
					NotNULL = false
				});
				list.Add(new CrmFoRegisterSettingNullableFieldsByTitleViewModel
				{
					FName = "CmpAddress",
					NotNULL = false
				});
				list.Add(new CrmFoRegisterSettingNullableFieldsByTitleViewModel
				{
					FName = "PrsJobId",
					NotNULL = false
				});
				if (list != null && Enumerable.Any<CrmFoRegisterSettingNullableFieldsByTitleViewModel>((IEnumerable<CrmFoRegisterSettingNullableFieldsByTitleViewModel>)list))
				{
					foreach (CrmFoRegisterSettingNullableFieldsByTitleViewModel item2 in list)
					{
						string text2 = "FORegister" + item2.FName;
						if (text2.EndsWith("Id"))
						{
							text2 = text2.Substring(0, text2.Length - 2);
						}
						item2.FTitle = Labels.ResourceManager.GetString(text2, new CultureInfo(lCID));
					}
				}
			}
			if (list != null && Enumerable.Any<CrmFoRegisterSettingNullableFieldsByTitleViewModel>((IEnumerable<CrmFoRegisterSettingNullableFieldsByTitleViewModel>)list))
			{
				result = JsonConvert.SerializeObject(Enumerable.ToList<CrmFoRegisterSettingNullableFieldsByTitleViewModel>((IEnumerable<CrmFoRegisterSettingNullableFieldsByTitleViewModel>)list));
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	public static string ReturnSystemPartFullTitle(int sysPartId = 0, int sysPartObjId = 0)
	{
		string result = "";
		CRMSpIIEntities cRMSpIIEntities = new CRMSpIIEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			CRMspReturnSystemPartFullTitle_Result cRMspReturnSystemPartFullTitle_Result = Enumerable.FirstOrDefault<CRMspReturnSystemPartFullTitle_Result>((IEnumerable<CRMspReturnSystemPartFullTitle_Result>)cRMSpIIEntities.CRMspReturnSystemPartFullTitle(sysPartId, sysPartObjId, lCID, result2));
			if (cRMspReturnSystemPartFullTitle_Result != null)
			{
				result = cRMspReturnSystemPartFullTitle_Result.PartFullTitle ?? "";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpIIEntities?.Dispose();
		}
		return result;
	}

	public static string ReturnSystemPartTitle(int sysPartId = 0)
	{
		string result = "";
		CRMSpIIEntities cRMSpIIEntities = new CRMSpIIEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			CRMspSelectSystemPartsById_Result cRMspSelectSystemPartsById_Result = Enumerable.FirstOrDefault<CRMspSelectSystemPartsById_Result>((IEnumerable<CRMspSelectSystemPartsById_Result>)cRMSpIIEntities.CRMspSelectSystemPartsById(sysPartId, lCID, result2));
			if (cRMspSelectSystemPartsById_Result != null)
			{
				result = cRMspSelectSystemPartsById_Result.PartTitle ?? "";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpIIEntities?.Dispose();
		}
		return result;
	}
}
