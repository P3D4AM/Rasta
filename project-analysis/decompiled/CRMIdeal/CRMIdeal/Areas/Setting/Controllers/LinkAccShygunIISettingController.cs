using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Cache.User;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using NR.Shygun.WS.ClientSDK;
using NR.Shygun.WS.FilterDomains;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Setting.Controllers;

public class LinkAccShygunIISettingController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass15_1
	{
		public CRMspSelectLinkAccShygunIISettingDetails_Result item;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_1
	{
		public CRMspSelectLinkAccShygunIISetting_Result item;
	}

	private CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMLinkSpEntities _dbLink = new CRMLinkSpEntities();

	private readonly CRMSpEntities _dbSp = new CRMSpEntities();

	private CRMSpIEntities _dbI = new CRMSpIEntities();

	[JsonIgnore]
	private string JsonRender;

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actSetting")]
	public ActionResult Index()
	{
		SelectProductPriceGroupList();
		GetcmpTypeList();
		GetOrdPayType();
		return View();
	}

	[AjaxOnly]
	public JsonResult GetSelectLinkAccShygunIISetting(string objType = "")
	{
		//IL_030d: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectLinkAccShygunIISetting_Result> list = new List<CRMspSelectLinkAccShygunIISetting_Result>();
		try
		{
			if (!string.IsNullOrEmpty(objType))
			{
				list = Enumerable.ToList<CRMspSelectLinkAccShygunIISetting_Result>(Enumerable.Where<CRMspSelectLinkAccShygunIISetting_Result>((IEnumerable<CRMspSelectLinkAccShygunIISetting_Result>)_dbLink.CRMspSelectLinkAccShygunIISetting(0, objType, lCID, result), (Func<CRMspSelectLinkAccShygunIISetting_Result, bool>)((CRMspSelectLinkAccShygunIISetting_Result m) => m.LinkAccShygunIISettingId != 26 && m.LinkAccShygunIISettingId != 28 && m.LinkAccShygunIISettingId != 30 && m.LinkAccShygunIISettingId != 32 && m.LinkAccShygunIISettingId != 34)));
				foreach (CRMspSelectLinkAccShygunIISetting_Result item in list)
				{
					if (string.IsNullOrWhiteSpace(item.PartValue))
					{
						continue;
					}
					if (item.LinkAccShygunIISettingId == 3 || item.LinkAccShygunIISettingId == 7)
					{
						item.PartValue = "**********";
					}
					else if (item.LinkAccShygunIISettingId == 17)
					{
						if (!string.IsNullOrWhiteSpace(item.PartValue))
						{
							if (item.PartValue.ToLower() == "prdcode")
							{
								item.PartValue = Labels.OtherSystemsLinkedPrdCode;
							}
							else if (item.PartValue.ToLower() == "prdfirstbarcode")
							{
								item.PartValue = Labels.OtherSystemsLinkedPrdFirstBarcode;
							}
							else if (item.PartValue.ToLower() == "prdmodel")
							{
								item.PartValue = Labels.OtherSystemsLinkedPrdModel;
							}
						}
						else
						{
							item.PartValue = "";
						}
					}
					else if (item.LinkAccShygunIISettingId == 19)
					{
						int result2 = 0;
						int.TryParse(item.PartValue, out result2);
						WSspSelectCurrencyUnitsWithId_Result wSspSelectCurrencyUnitsWithId_Result = Enumerable.FirstOrDefault<WSspSelectCurrencyUnitsWithId_Result>((IEnumerable<WSspSelectCurrencyUnitsWithId_Result>)_db.WSspSelectCurrencyUnitsWithId(result2, lCID, result));
						if (wSspSelectCurrencyUnitsWithId_Result != null)
						{
							item.PartValue = wSspSelectCurrencyUnitsWithId_Result.CurrencyUnit ?? "";
						}
						else
						{
							item.PartValue = "";
						}
					}
					else if (item.LinkAccShygunIISettingId == 24)
					{
						item.PartValue = Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)SelectConversationStatusGroups(), (Func<SelectListItem, bool>)((SelectListItem x) => x.Value == item.PartValue)).Text ?? "";
					}
					else
					{
						if ((item.LinkAccShygunIISettingId != 25 && item.LinkAccShygunIISettingId != 27 && item.LinkAccShygunIISettingId != 45) || string.IsNullOrWhiteSpace(item.PartValue) || item.PartValue.IndexOf("[{") < 0)
						{
							continue;
						}
						List<CrmLinkAccShygunIIAccountInfoViewModel> list2 = new JavaScriptSerializer().Deserialize<List<CrmLinkAccShygunIIAccountInfoViewModel>>(item.PartValue);
						if (list2 == null || !Enumerable.Any<CrmLinkAccShygunIIAccountInfoViewModel>((IEnumerable<CrmLinkAccShygunIIAccountInfoViewModel>)list2))
						{
							continue;
						}
						string text = "";
						foreach (CrmLinkAccShygunIIAccountInfoViewModel item2 in list2)
						{
							text = text + "," + item2.Code;
						}
						if (string.IsNullOrWhiteSpace(text) && text.StartsWith(","))
						{
							text = text.Substring(0, 1);
						}
						item.PartValue = text;
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actEdit")]
	public ActionResult InsertEdit(string objectType)
	{
		//IL_02b1: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CrmLinkAccSettingOtherLanguageViewModel> list = new List<CrmLinkAccSettingOtherLanguageViewModel>();
		try
		{
			List<CRMspSelectLinkAccShygunIISetting_Result> list2 = Enumerable.ToList<CRMspSelectLinkAccShygunIISetting_Result>(Enumerable.Where<CRMspSelectLinkAccShygunIISetting_Result>((IEnumerable<CRMspSelectLinkAccShygunIISetting_Result>)_dbLink.CRMspSelectLinkAccShygunIISetting(0, objectType, currLangID, result), (Func<CRMspSelectLinkAccShygunIISetting_Result, bool>)((CRMspSelectLinkAccShygunIISetting_Result m) => m.LinkAccShygunIISettingId != 26 && m.LinkAccShygunIISettingId != 28 && m.LinkAccShygunIISettingId != 30 && m.LinkAccShygunIISettingId != 32 && m.LinkAccShygunIISettingId != 34)));
			if (list2 != null)
			{
				using List<CRMspSelectLinkAccShygunIISetting_Result>.Enumerator enumerator = list2.GetEnumerator();
				while (enumerator.MoveNext())
				{
					_003C_003Ec__DisplayClass7_1 _003C_003Ec__DisplayClass7_ = new _003C_003Ec__DisplayClass7_1();
					_003C_003Ec__DisplayClass7_.item = enumerator.Current;
					DbSet<CrmLinkAccShygunIISetting_Lang> crmLinkAccShygunIISetting_Lang = _dbTbl.CrmLinkAccShygunIISetting_Lang;
					ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccShygunIISetting_Lang), "c");
					List<CrmLinkAccShygunIISetting_Lang> list3 = Enumerable.ToList<CrmLinkAccShygunIISetting_Lang>((IEnumerable<CrmLinkAccShygunIISetting_Lang>)Queryable.Where<CrmLinkAccShygunIISetting_Lang>((IQueryable<CrmLinkAccShygunIISetting_Lang>)crmLinkAccShygunIISetting_Lang, Expression.Lambda<Func<CrmLinkAccShygunIISetting_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass7_, typeof(_003C_003Ec__DisplayClass7_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
					DbSet<CrmLinkAccShygunIISetting> crmLinkAccShygunIISetting = _dbTbl.CrmLinkAccShygunIISetting;
					val = Expression.Parameter(typeof(CrmLinkAccShygunIISetting), "c");
					CrmLinkAccShygunIISetting crmLinkAccShygunIISetting2 = Queryable.FirstOrDefault<CrmLinkAccShygunIISetting>(Queryable.Where<CrmLinkAccShygunIISetting>((IQueryable<CrmLinkAccShygunIISetting>)crmLinkAccShygunIISetting, Expression.Lambda<Func<CrmLinkAccShygunIISetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass7_, typeof(_003C_003Ec__DisplayClass7_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
					List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmLinkAccShygunIISetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmLinkAccShygunIISetting_Lang>)list3, (Func<CrmLinkAccShygunIISetting_Lang, CommonMultiLanguageViewModel>)((CrmLinkAccShygunIISetting_Lang itemI) => new CommonMultiLanguageViewModel
					{
						Value = itemI.Description,
						LanguageId = itemI.LanguageID
					})));
					list4.Add(new CommonMultiLanguageViewModel
					{
						Value = crmLinkAccShygunIISetting2.Description,
						LanguageId = result
					});
					CrmLinkAccSettingOtherLanguageViewModel crmLinkAccSettingOtherLanguageViewModel = new CrmLinkAccSettingOtherLanguageViewModel();
					crmLinkAccSettingOtherLanguageViewModel.LinkAccSettingId = _003C_003Ec__DisplayClass7_.item.LinkAccShygunIISettingId;
					crmLinkAccSettingOtherLanguageViewModel.PartField = _003C_003Ec__DisplayClass7_.item.PartField;
					crmLinkAccSettingOtherLanguageViewModel.PartValue = _003C_003Ec__DisplayClass7_.item.PartValue;
					if (!string.IsNullOrWhiteSpace(crmLinkAccSettingOtherLanguageViewModel.PartValue) && crmLinkAccSettingOtherLanguageViewModel.PartValue.IndexOf("[{") >= 0 && (crmLinkAccSettingOtherLanguageViewModel.LinkAccSettingId == 25 || crmLinkAccSettingOtherLanguageViewModel.LinkAccSettingId == 27 || crmLinkAccSettingOtherLanguageViewModel.LinkAccSettingId == 45))
					{
						List<CrmLinkAccShygunIIAccountInfoViewModel> list5 = new JavaScriptSerializer().Deserialize<List<CrmLinkAccShygunIIAccountInfoViewModel>>(crmLinkAccSettingOtherLanguageViewModel.PartValue);
						if (list5 != null && Enumerable.Any<CrmLinkAccShygunIIAccountInfoViewModel>((IEnumerable<CrmLinkAccShygunIIAccountInfoViewModel>)list5))
						{
							string text = "";
							foreach (CrmLinkAccShygunIIAccountInfoViewModel item in list5)
							{
								text = text + "," + item.Code;
							}
							crmLinkAccSettingOtherLanguageViewModel.PartValue = text;
						}
					}
					crmLinkAccSettingOtherLanguageViewModel.PartDescription = _003C_003Ec__DisplayClass7_.item.PartDescription;
					crmLinkAccSettingOtherLanguageViewModel.PartLabelTitle = _003C_003Ec__DisplayClass7_.item.PartLabelTitle;
					crmLinkAccSettingOtherLanguageViewModel.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : "");
					crmLinkAccSettingOtherLanguageViewModel.Description_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))));
					crmLinkAccSettingOtherLanguageViewModel.PartTitle = _003C_003Ec__DisplayClass7_.item.PartTitle;
					list.Add(crmLinkAccSettingOtherLanguageViewModel);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ObjectType = objectType;
		if (objectType == "CmpProject")
		{
			base.ViewBag.StatusGroupslist = SelectConversationStatusGroups();
		}
		if (objectType == "Order")
		{
			base.ViewBag.CurrencyUnitList = GetCurrencyUnit();
		}
		return View(list);
	}

	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actPost")]
	public string UpdateLinkAccSetting(string setting, string objType)
	{
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string result = "1";
		try
		{
			new List<CrmLinkAccSettingViewModel>();
			List<CrmLinkAccSettingViewModel> list = new JavaScriptSerializer().Deserialize<List<CrmLinkAccSettingViewModel>>(setting);
			DateTime now = DateTime.Now;
			int userId = UserLogin.CurrentUser.UserId;
			short value = short.Parse(Financial.Get().Id.ToString());
			short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
			DateTime value3 = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			string appType = Configuration.AppType;
			string text = "";
			string text2 = "";
			foreach (CrmLinkAccSettingViewModel item4 in list)
			{
				int accSettimgId = item4.AccSettimgId;
				string text3 = item4.PartValue ?? "";
				string text4 = item4.PartField ?? "";
				List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(item4.Desc_Lang))
				{
					list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(item4.Desc_Lang);
				}
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = item4.Desc,
					LanguageId = lCID
				});
				string text5 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : "");
				List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != defLangID)));
				if (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3))
				{
					foreach (CommonMultiLanguageViewModel item5 in list3)
					{
						text2 = text2 + "[AccSettimgId=" + accSettimgId + ",Desc=" + item5.Value + ",LangId=" + item5.LanguageId + ",]|";
					}
				}
				if (item4.PartTitle != "PordAccountNumber" && item4.PartTitle != "OrdAccountNumber" && item4.PartTitle != "ShygunSaleMoinNumber")
				{
					text = text + "[AccSettimgId=" + accSettimgId + ",PartField=" + text4 + ",PartValue=" + text3 + ",Desc=" + text5 + ",]|";
				}
				CRMIdeal.Classes.Helper.OtherSystems.ShygunIISettingViewModel shygunIISetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunIISetting();
				if (shygunIISetting == null)
				{
					continue;
				}
				if (item4.PartTitle == "PordAccountNumber")
				{
					string text6 = "";
					if (!string.IsNullOrWhiteSpace(item4.PartValue))
					{
						string[] array = item4.PartValue.Split(new char[1] { ',' });
						if (array != null && array.Length != 0)
						{
							List<CrmLinkAccShygunIIAccountInfoViewModel> list4 = new List<CrmLinkAccShygunIIAccountInfoViewModel>();
							string[] array2 = array;
							foreach (string text7 in array2)
							{
								if (string.IsNullOrWhiteSpace(text7))
								{
									continue;
								}
								string accountGuIdAndName = GetAccountGuIdAndName(text7, shygunIISetting.PordAccountNumberFieldTitle);
								if (string.IsNullOrWhiteSpace(accountGuIdAndName))
								{
									continue;
								}
								string[] array3 = accountGuIdAndName.Split(new char[1] { '|' });
								string guId = "";
								string name = "";
								if (array3 != null)
								{
									if (array3.Length != 0)
									{
										guId = array3[0];
									}
									if (array3.Length > 1)
									{
										name = array3[1];
									}
								}
								CrmLinkAccShygunIIAccountInfoViewModel item = new CrmLinkAccShygunIIAccountInfoViewModel
								{
									GuId = guId,
									Name = name,
									Code = text7
								};
								list4.Add(item);
							}
							if (list4 != null && Enumerable.Any<CrmLinkAccShygunIIAccountInfoViewModel>((IEnumerable<CrmLinkAccShygunIIAccountInfoViewModel>)list4))
							{
								text6 = JsonConvert.SerializeObject(Enumerable.ToList<CrmLinkAccShygunIIAccountInfoViewModel>((IEnumerable<CrmLinkAccShygunIIAccountInfoViewModel>)list4));
								text6 = text6.Replace(",", "COMA");
							}
						}
					}
					text = text + "[AccSettimgId=" + accSettimgId + ",PartField=" + text4 + ",PartValue=" + text6 + ",Desc=" + text5 + ",]|";
					text += "[AccSettimgId = 26,PartField=,PartValue=,Desc=,]|";
				}
				else if (item4.PartTitle == "OrdAccountNumber")
				{
					string text8 = "";
					if (!string.IsNullOrWhiteSpace(item4.PartValue))
					{
						string[] array4 = item4.PartValue.Split(new char[1] { ',' });
						if (array4 != null && array4.Length != 0)
						{
							List<CrmLinkAccShygunIIAccountInfoViewModel> list5 = new List<CrmLinkAccShygunIIAccountInfoViewModel>();
							string[] array2 = array4;
							foreach (string text9 in array2)
							{
								if (string.IsNullOrWhiteSpace(text9))
								{
									continue;
								}
								string accountGuIdAndName2 = GetAccountGuIdAndName(text9, shygunIISetting.OrdAccountNumberFieldTitle);
								if (string.IsNullOrWhiteSpace(accountGuIdAndName2))
								{
									continue;
								}
								string[] array5 = accountGuIdAndName2.Split(new char[1] { '|' });
								string guId2 = "";
								string name2 = "";
								if (array5 != null)
								{
									if (array5.Length != 0)
									{
										guId2 = array5[0];
									}
									if (array5.Length > 1)
									{
										name2 = array5[1];
									}
								}
								CrmLinkAccShygunIIAccountInfoViewModel item2 = new CrmLinkAccShygunIIAccountInfoViewModel
								{
									GuId = guId2,
									Name = name2,
									Code = text9
								};
								list5.Add(item2);
							}
							if (list5 != null && Enumerable.Any<CrmLinkAccShygunIIAccountInfoViewModel>((IEnumerable<CrmLinkAccShygunIIAccountInfoViewModel>)list5))
							{
								text8 = JsonConvert.SerializeObject(Enumerable.ToList<CrmLinkAccShygunIIAccountInfoViewModel>((IEnumerable<CrmLinkAccShygunIIAccountInfoViewModel>)list5));
								text8 = text8.Replace(",", "COMA");
							}
						}
					}
					text = text + "[AccSettimgId=" + accSettimgId + ",PartField=" + text4 + ",PartValue=" + text8 + ",Desc=" + text5 + ",]|";
					text += "[AccSettimgId = 28,PartField=,PartValue=,Desc=,]|";
				}
				else if (item4.PartTitle == "DocAccountNumber")
				{
					string text10 = "";
					if (shygunIISetting.DocAccountNumber != item4.PartValue)
					{
						if (string.IsNullOrWhiteSpace(item4.PartValue))
						{
							item4.PartValue = "";
						}
						else
						{
							text10 = GetAccountGuId(item4.PartValue, shygunIISetting.DocAccountNumberFieldTitle);
						}
						text = text + "[AccSettimgId = 30,PartField=,PartValue=" + text10 + ",Desc=,]|";
					}
				}
				else if (item4.PartTitle == "DraftAccountNumber")
				{
					string text11 = "";
					if (shygunIISetting.DraftAccountNumber != item4.PartValue)
					{
						if (string.IsNullOrWhiteSpace(item4.PartValue))
						{
							item4.PartValue = "";
						}
						else
						{
							text11 = GetAccountGuId(item4.PartValue, shygunIISetting.DraftAccountNumberFieldTitle);
						}
						text = text + "[AccSettimgId = 32,PartField=,PartValue=" + text11 + ",Desc=,]|";
					}
				}
				else if (item4.PartTitle == "WrhsMovementAccountNumber")
				{
					string text12 = "";
					if (shygunIISetting.WrhsMovementAccountNumber != item4.PartValue)
					{
						if (string.IsNullOrWhiteSpace(item4.PartValue))
						{
							item4.PartValue = "";
						}
						else
						{
							text12 = GetAccountGuId(item4.PartValue, shygunIISetting.WrhsMovementAccountNumberFieldTitle);
						}
						text = text + "[AccSettimgId = 34,PartField=,PartValue=" + text12 + ",Desc=,]|";
					}
				}
				else
				{
					if (!(item4.PartTitle == "ShygunSaleMoinNumber"))
					{
						continue;
					}
					string text13 = "";
					if (!string.IsNullOrWhiteSpace(item4.PartValue))
					{
						string[] array6 = item4.PartValue.Split(new char[1] { ',' });
						if (array6 != null && array6.Length != 0)
						{
							List<CrmLinkAccShygunIIAccountInfoViewModel> list6 = new List<CrmLinkAccShygunIIAccountInfoViewModel>();
							string[] array2 = array6;
							foreach (string text14 in array2)
							{
								if (!string.IsNullOrWhiteSpace(text14))
								{
									string accountJobGroupGuIdGuId = GetAccountJobGroupGuIdGuId(text14, shygunIISetting.ShygunSaleMoinNumberFieldTitle);
									if (!string.IsNullOrWhiteSpace(accountJobGroupGuIdGuId))
									{
										string text15 = accountJobGroupGuIdGuId;
										text15 = text15.Replace(",", "COMA");
										string name3 = "";
										CrmLinkAccShygunIIAccountInfoViewModel item3 = new CrmLinkAccShygunIIAccountInfoViewModel
										{
											GuId = text15,
											Name = name3,
											Code = text14
										};
										list6.Add(item3);
									}
								}
							}
							if (list6 != null && Enumerable.Any<CrmLinkAccShygunIIAccountInfoViewModel>((IEnumerable<CrmLinkAccShygunIIAccountInfoViewModel>)list6))
							{
								text13 = JsonConvert.SerializeObject(Enumerable.ToList<CrmLinkAccShygunIIAccountInfoViewModel>((IEnumerable<CrmLinkAccShygunIIAccountInfoViewModel>)list6));
								text13 = text13.Replace(",", "COMA");
							}
						}
					}
					text = text + "[AccSettimgId=" + accSettimgId + ",PartField=" + text4 + ",PartValue=" + text13 + ",Desc=" + text5 + ",]|";
				}
			}
			if (!string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(text2))
			{
				_dbLink.CRMspUpdateLinkAccShygunIISetting(text, text2, userId, value, value2, value3, registerDatePersian, appType, defLangID);
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = ex.Message;
		}
		return result;
	}

	public bool checkMultiLanguage(string defaultValue, List<CommonMultiLanguageViewModel> list)
	{
		bool result = true;
		List<CRMspSelectUserLanguages_Result> list2 = CRMIdeal.Cache.User.Language.Get();
		bool isCurrentUserAllowCopyOtherLanguage = UserLogin.IsCurrentUserAllowCopyOtherLanguage;
		foreach (Languages itemLang in CRMIdeal.Cache.Setting.Language.Get())
		{
			CommonMultiLanguageViewModel commonMultiLanguageViewModel = Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == itemLang.LanguageID));
			if (commonMultiLanguageViewModel == null)
			{
				if (Enumerable.Any<CRMspSelectUserLanguages_Result>((IEnumerable<CRMspSelectUserLanguages_Result>)list2, (Func<CRMspSelectUserLanguages_Result, bool>)((CRMspSelectUserLanguages_Result c) => c.LanguageID == itemLang.LanguageID)))
				{
					if (isCurrentUserAllowCopyOtherLanguage)
					{
						list.Add(new CommonMultiLanguageViewModel
						{
							LanguageId = itemLang.LanguageID,
							Value = defaultValue
						});
					}
					else
					{
						result = false;
					}
				}
				else
				{
					list.Add(new CommonMultiLanguageViewModel
					{
						LanguageId = itemLang.LanguageID,
						Value = defaultValue
					});
				}
			}
			else
			{
				if (!string.IsNullOrEmpty(commonMultiLanguageViewModel.Value))
				{
					continue;
				}
				if (Enumerable.Any<CRMspSelectUserLanguages_Result>((IEnumerable<CRMspSelectUserLanguages_Result>)list2, (Func<CRMspSelectUserLanguages_Result, bool>)((CRMspSelectUserLanguages_Result c) => c.LanguageID == itemLang.LanguageID)))
				{
					if (isCurrentUserAllowCopyOtherLanguage)
					{
						commonMultiLanguageViewModel.Value = defaultValue;
					}
					else
					{
						result = false;
					}
				}
				else
				{
					commonMultiLanguageViewModel.Value = defaultValue;
				}
			}
		}
		return result;
	}

	[AjaxOnly]
	public JsonResult GetSelectLinkAccSettingDetails(int objId = 0, string objType = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectLinkAccShygunIISettingDetails_Result> list = new List<CRMspSelectLinkAccShygunIISettingDetails_Result>();
		try
		{
			if (objId > 0 && !string.IsNullOrEmpty(objType))
			{
				DateTime now = DateTime.Now;
				int userId = UserLogin.CurrentUser.UserId;
				short value = short.Parse(Financial.Get().Id.ToString());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				DateTime value3 = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				string appType = Configuration.AppType;
				_dbLink.CRMspInsertLinkAccShygunIISettingDetails(objId, objType, userId, value, value2, value3, registerDatePersian, appType, result);
				list = Enumerable.ToList<CRMspSelectLinkAccShygunIISettingDetails_Result>((IEnumerable<CRMspSelectLinkAccShygunIISettingDetails_Result>)_dbLink.CRMspSelectLinkAccShygunIISettingDetails(0, objId, objType, lCID, result));
				foreach (CRMspSelectLinkAccShygunIISettingDetails_Result item in list)
				{
					if (string.IsNullOrWhiteSpace(item.PartValue))
					{
						continue;
					}
					if (item.LinkAccShygunIISettingId == 15)
					{
						switch (item.PartValue)
						{
						case "1":
							item.PartValue = Labels.OtherSystemsShygunProductPriceI;
							break;
						case "2":
							item.PartValue = Labels.OtherSystemsShygunProductPriceII;
							break;
						case "3":
							item.PartValue = Labels.OtherSystemsShygunProductPriceIII;
							break;
						case "4":
							item.PartValue = Labels.OtherSystemsShygunProductPriceIV;
							break;
						case "5":
							item.PartValue = Labels.OtherSystemsShygunProductPriceV;
							break;
						}
					}
					else if (item.LinkAccShygunIISettingId == 35)
					{
						string partValue = item.PartValue;
						if (!(partValue == "21"))
						{
							if (partValue == "22")
							{
								item.PartValue = Labels.LinkAccSettingPaymentSheet;
							}
						}
						else
						{
							item.PartValue = Labels.LinkAccSettingReceiptSheet;
						}
					}
					else if (item.LinkAccShygunIISettingId == 37 || item.LinkAccShygunIISettingId == 42)
					{
						string partValue = item.PartValue;
						if (!(partValue == "1"))
						{
							if (partValue == "2")
							{
								item.PartValue = Labels.LinkAccSettingPayDocDate;
							}
						}
						else
						{
							item.PartValue = Labels.LinkAccSettingPayImportDate;
						}
					}
					else
					{
						if (item.LinkAccShygunIISettingId != 41)
						{
							continue;
						}
						string partValue = item.PartValue;
						if (!(partValue == "0"))
						{
							if (partValue == "1")
							{
								item.PartValue = Labels.LinkAccSettingChqeue;
							}
						}
						else
						{
							item.PartValue = Labels.LinkAccSettingCash;
						}
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public List<WSspSelectProductPriceGroup_Result> SelectProductPriceGroup()
	{
		List<WSspSelectProductPriceGroup_Result> result = new List<WSspSelectProductPriceGroup_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			result = Enumerable.ToList<WSspSelectProductPriceGroup_Result>((IEnumerable<WSspSelectProductPriceGroup_Result>)_dbSp.WSspSelectProductPriceGroup(lCID, result2));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public List<SelectListItem> SelectProductPriceGroupList()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<WSspSelectProductPriceGroup_Result> list2 = SelectProductPriceGroup();
			if (list2 != null)
			{
				foreach (WSspSelectProductPriceGroup_Result item2 in list2)
				{
					SelectListItem item = new SelectListItem
					{
						Value = item2.ProductPriceGroupID.ToString(),
						Text = item2.ProductPriceGroupName,
						Selected = false
					};
					list.Add(item);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ProductPriceGroupList = list;
		return list;
	}

	public List<SelectListItem> SelectConversationStatusGroups()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectConversationStatusGroups_Result> list2 = Enumerable.ToList<CRMspSelectConversationStatusGroups_Result>((IEnumerable<CRMspSelectConversationStatusGroups_Result>)_dbSp.CRMspSelectConversationStatusGroups(lCID, result));
			if (list2 != null)
			{
				foreach (CRMspSelectConversationStatusGroups_Result item2 in list2)
				{
					SelectListItem item = new SelectListItem
					{
						Value = item2.ConversationStatusGroupID.ToString(),
						Text = item2.ConversationStatusGroup,
						Selected = false
					};
					list.Add(item);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	public List<SelectListItem> GetCurrencyUnit()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<WSspSelectCurrencyUnits_Result> list2 = Enumerable.ToList<WSspSelectCurrencyUnits_Result>((IEnumerable<WSspSelectCurrencyUnits_Result>)_db.WSspSelectCurrencyUnits(lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectCurrencyUnits_Result, SelectListItem>((IEnumerable<WSspSelectCurrencyUnits_Result>)list2, (Func<WSspSelectCurrencyUnits_Result, SelectListItem>)((WSspSelectCurrencyUnits_Result item) => new SelectListItem
			{
				Text = item.CurrencyUnit,
				Value = item.CurrencyUnitID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actEdit")]
	public ActionResult InsertEditDetail(string objType = "", int objId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		base.ViewBag.ObjectId = objId;
		base.ViewBag.ObjectType = objType;
		string text = "";
		List<CrmLinkAccSettingDetailsLanguageViewModel> list = new List<CrmLinkAccSettingDetailsLanguageViewModel>();
		try
		{
			List<CRMspSelectLinkAccShygunIISettingDetails_Result> list2 = Enumerable.ToList<CRMspSelectLinkAccShygunIISettingDetails_Result>((IEnumerable<CRMspSelectLinkAccShygunIISettingDetails_Result>)_dbLink.CRMspSelectLinkAccShygunIISettingDetails(0, objId, objType, currLangID, result));
			if (list2 != null)
			{
				using List<CRMspSelectLinkAccShygunIISettingDetails_Result>.Enumerator enumerator = list2.GetEnumerator();
				while (enumerator.MoveNext())
				{
					_003C_003Ec__DisplayClass15_1 _003C_003Ec__DisplayClass15_ = new _003C_003Ec__DisplayClass15_1();
					_003C_003Ec__DisplayClass15_.item = enumerator.Current;
					DbSet<CrmLinkAccShygunIISettingDetails_Lang> crmLinkAccShygunIISettingDetails_Lang = _dbTbl.CrmLinkAccShygunIISettingDetails_Lang;
					ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccShygunIISettingDetails_Lang), "c");
					List<CrmLinkAccShygunIISettingDetails_Lang> list3 = Enumerable.ToList<CrmLinkAccShygunIISettingDetails_Lang>((IEnumerable<CrmLinkAccShygunIISettingDetails_Lang>)Queryable.Where<CrmLinkAccShygunIISettingDetails_Lang>((IQueryable<CrmLinkAccShygunIISettingDetails_Lang>)crmLinkAccShygunIISettingDetails_Lang, Expression.Lambda<Func<CrmLinkAccShygunIISettingDetails_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass15_, typeof(_003C_003Ec__DisplayClass15_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
					DbSet<CrmLinkAccShygunIISettingDetails> crmLinkAccShygunIISettingDetails = _dbTbl.CrmLinkAccShygunIISettingDetails;
					val = Expression.Parameter(typeof(CrmLinkAccShygunIISettingDetails), "c");
					CrmLinkAccShygunIISettingDetails crmLinkAccShygunIISettingDetails2 = Queryable.FirstOrDefault<CrmLinkAccShygunIISettingDetails>(Queryable.Where<CrmLinkAccShygunIISettingDetails>((IQueryable<CrmLinkAccShygunIISettingDetails>)crmLinkAccShygunIISettingDetails, Expression.Lambda<Func<CrmLinkAccShygunIISettingDetails, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass15_, typeof(_003C_003Ec__DisplayClass15_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
					List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmLinkAccShygunIISettingDetails_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmLinkAccShygunIISettingDetails_Lang>)list3, (Func<CrmLinkAccShygunIISettingDetails_Lang, CommonMultiLanguageViewModel>)((CrmLinkAccShygunIISettingDetails_Lang itemI) => new CommonMultiLanguageViewModel
					{
						Value = itemI.Description,
						LanguageId = itemI.LanguageID
					})));
					list4.Add(new CommonMultiLanguageViewModel
					{
						Value = crmLinkAccShygunIISettingDetails2.Description,
						LanguageId = result
					});
					text = _003C_003Ec__DisplayClass15_.item.ObjectTypeTitle ?? "";
					CrmLinkAccSettingDetailsLanguageViewModel crmLinkAccSettingDetailsLanguageViewModel = new CrmLinkAccSettingDetailsLanguageViewModel();
					crmLinkAccSettingDetailsLanguageViewModel.LinkAccSettingDetailId = _003C_003Ec__DisplayClass15_.item.LinkAccShygunIISettingDetailId;
					crmLinkAccSettingDetailsLanguageViewModel.PartField = _003C_003Ec__DisplayClass15_.item.PartField;
					crmLinkAccSettingDetailsLanguageViewModel.PartValue = _003C_003Ec__DisplayClass15_.item.PartValue;
					crmLinkAccSettingDetailsLanguageViewModel.PartDescription = _003C_003Ec__DisplayClass15_.item.PartDescription;
					crmLinkAccSettingDetailsLanguageViewModel.PartLabelTitle = _003C_003Ec__DisplayClass15_.item.PartLabelTitle;
					crmLinkAccSettingDetailsLanguageViewModel.LinkAccSettingId = _003C_003Ec__DisplayClass15_.item.LinkAccShygunIISettingId;
					crmLinkAccSettingDetailsLanguageViewModel.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : "");
					crmLinkAccSettingDetailsLanguageViewModel.Description_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))));
					list.Add(crmLinkAccSettingDetailsLanguageViewModel);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ObjectTypeTitle = text;
		return View(list);
	}

	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actPost")]
	public string UpdateLinkAccSettingDetails(int objId, string objType, string settingDetail)
	{
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string result = "1";
		try
		{
			if (objId > 0 && !string.IsNullOrEmpty(objType))
			{
				new List<CrmLinkAccSettingDetailsViewModel>();
				List<CrmLinkAccSettingDetailsViewModel> list = new JavaScriptSerializer().Deserialize<List<CrmLinkAccSettingDetailsViewModel>>(settingDetail);
				DateTime now = DateTime.Now;
				int userId = UserLogin.CurrentUser.UserId;
				short value = short.Parse(Financial.Get().Id.ToString());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				DateTime value3 = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				string appType = Configuration.AppType;
				string text = "";
				string text2 = "";
				foreach (CrmLinkAccSettingDetailsViewModel item in list)
				{
					int accSdId = item.AccSdId;
					string text3 = item.PartValue ?? "";
					string text4 = item.PartField ?? "";
					List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
					if (!string.IsNullOrEmpty(item.Desc_Lang))
					{
						list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(item.Desc_Lang);
					}
					list2.Add(new CommonMultiLanguageViewModel
					{
						Value = item.Desc,
						LanguageId = lCID
					});
					string text5 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : "");
					List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != defLangID)));
					if (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3))
					{
						foreach (CommonMultiLanguageViewModel item2 in list3)
						{
							text2 = text2 + "[AccSdId=" + accSdId + ",Desc=" + item2.Value + ",LangId=" + item2.LanguageId + ",]|";
						}
					}
					text = text + "[AccSdId=" + accSdId + ",PartField=" + text4 + ",PartValue=" + text3 + ",Desc=" + text5 + ",]|";
				}
				_dbLink.CRMspUpdateLinkAccShygunIISettingDetails(objId, objType, text, text2, userId, value, value2, value3, registerDatePersian, appType, defLangID);
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = ex.Message;
		}
		return result;
	}

	public string GetAccountGuId(string accountNumber, string title)
	{
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Expected O, but got Unknown
		string text = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			CRMIdeal.Classes.Helper.OtherSystems.ShygunIISettingViewModel shygunIISetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunIISetting();
			string startVersion = null;
			DomainAccount domainAccount = new DomainAccount();
			domainAccount.AccountNumber.From = accountNumber;
			domainAccount.AccountNumber.To = accountNumber;
			foreach (DataRow item in (InternalDataCollectionBase)new WebServiceGetAccount(shygunIISetting.IP, shygunIISetting.conf, domainAccount, 0, 1, startVersion).GetDataTableObject(out JsonRender).Rows)
			{
				DataRow val = item;
				new ShygunIICompanyInfoViewModel();
				if (val["GuId"] != null)
				{
					text = val["GuId"].ToString();
				}
			}
			if (string.IsNullOrWhiteSpace(text))
			{
				text = string.Format(Messages.msgErrorOtherSystemAuthFieldValue, Labels.ShygunII, title);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return text;
	}

	public string GetAccountGuIdAndName(string accountNumber, string title)
	{
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Expected O, but got Unknown
		string text = "";
		string text2 = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			CRMIdeal.Classes.Helper.OtherSystems.ShygunIISettingViewModel shygunIISetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunIISetting();
			string startVersion = null;
			DomainAccount domainAccount = new DomainAccount();
			domainAccount.AccountNumber.From = accountNumber;
			domainAccount.AccountNumber.To = accountNumber;
			foreach (DataRow item in (InternalDataCollectionBase)new WebServiceGetAccount(shygunIISetting.IP, shygunIISetting.conf, domainAccount, 0, 1, startVersion).GetDataTableObject(out JsonRender).Rows)
			{
				DataRow val = item;
				new ShygunIICompanyInfoViewModel();
				if (val["GuId"] != null)
				{
					text = val["GuId"].ToString();
				}
				if (val["AccountName"] != null)
				{
					text2 = val["AccountName"].ToString();
				}
			}
			if (string.IsNullOrWhiteSpace(text))
			{
				text = string.Format(Messages.msgErrorOtherSystemAuthFieldValue, Labels.ShygunII, title);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return text + "|" + text2;
	}

	public string GetAccountJobGroupGuIdGuId(string moienNumber, string title)
	{
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Expected O, but got Unknown
		string text = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			CRMIdeal.Classes.Helper.OtherSystems.ShygunIISettingViewModel shygunIISetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunIISetting();
			string startVersion = null;
			DomainAccount domainAccount = new DomainAccount();
			domainAccount.MoinNumber.From = moienNumber;
			domainAccount.MoinNumber.To = moienNumber;
			foreach (DataRow item in (InternalDataCollectionBase)new WebServiceGetAccount(shygunIISetting.IP, shygunIISetting.conf, domainAccount, 0, 1, startVersion).GetDataTableObject(out JsonRender).Rows)
			{
				DataRow val = item;
				new ShygunIICompanyInfoViewModel();
				if (val["JobGroupGuId"] != null)
				{
					text = text + val["JobGroupGuId"].ToString() + ",";
				}
			}
			if (string.IsNullOrWhiteSpace(text))
			{
				text = string.Format(Messages.msgErrorOtherSystemAuthFieldValue, Labels.ShygunII, title);
			}
			else if (text.EndsWith(","))
			{
				text = text.TrimEnd(new char[1] { ',' });
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return text ?? "";
	}

	[AjaxOnly]
	public JsonResult GetcmpTypeList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectCompanyType_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyType_Result>)Enumerable.ToList<CRMspSelectCompanyType_Result>((IEnumerable<CRMspSelectCompanyType_Result>)_dbSp.CRMspSelectCompanyType(lCID, result)), (Func<CRMspSelectCompanyType_Result, SelectListItem>)((CRMspSelectCompanyType_Result item) => new SelectListItem
			{
				Text = item.CompanyTypeName,
				Value = item.CompanyTypeID.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.cmpTypeList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetOrdPayType()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int value = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserId : 0);
			List<WSspSelectActiveOrderPaymentTypes_Result> list2 = Enumerable.ToList<WSspSelectActiveOrderPaymentTypes_Result>((IEnumerable<WSspSelectActiveOrderPaymentTypes_Result>)_dbI.WSspSelectActiveOrderPaymentTypes(lCID, result, value));
			list.AddRange(Enumerable.Select<WSspSelectActiveOrderPaymentTypes_Result, SelectListItem>((IEnumerable<WSspSelectActiveOrderPaymentTypes_Result>)list2, (Func<WSspSelectActiveOrderPaymentTypes_Result, SelectListItem>)((WSspSelectActiveOrderPaymentTypes_Result item) => new SelectListItem
			{
				Text = item.ordpayType,
				Value = item.OrderPaymentTypeId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.OrdPayTypeList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		_dbLink.Dispose();
		_dbI.Dispose();
		base.Dispose(disposing);
	}
}
