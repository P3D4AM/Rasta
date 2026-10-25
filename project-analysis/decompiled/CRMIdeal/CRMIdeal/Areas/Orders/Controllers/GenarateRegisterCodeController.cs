using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.General.Security;
using CRM.General.Utilities;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Areas.Products.Controllers;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;

namespace CRMIdeal.Areas.Orders.Controllers;

public class GenarateRegisterCodeController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	[LoginAuthorize]
	public ActionResult Index(int cmpId, int position)
	{
		string text = "";
		string text2 = "";
		switch (position)
		{
		case 1:
			text = "frmOrder";
			text2 = "actGenerateRegisterCode";
			break;
		case 2:
			text = "frmCompanyI";
			text2 = "actGenerateRegisterCode";
			break;
		default:
			return RedirectToAction("Login", "Account", (object)new
			{
				area = "",
				d = DateTime.Now
			});
		}
		if (!UserLogin.IsUserAccess(text, text2, UserLogin.CurrentUser))
		{
			return RedirectToAction("Login", "Account", (object)new
			{
				area = "",
				d = DateTime.Now
			});
		}
		base.ViewBag.CompanyId = cmpId;
		base.ViewBag.Position = position;
		return View();
	}

	[AjaxOnly]
	public JsonResult CreateRegisterCode(string objModel)
	{
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_024b: Unknown result type (might be due to invalid IL or missing references)
		string text = "";
		CommonResultStatusViewModel commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		RegisterCodeCreateResultViewModel registerCodeCreateResultViewModel = new RegisterCodeCreateResultViewModel();
		CommonResultViewModel<RegisterCodeCreateResultViewModel> data;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (!string.IsNullOrWhiteSpace(objModel))
			{
				RegisterCodeCreateViewModel registerCodeCreateViewModel = new JavaScriptSerializer().Deserialize<RegisterCodeCreateViewModel>(objModel);
				if (registerCodeCreateViewModel != null)
				{
					DateTime now = DateTime.Now;
					now.ToString("yyyyMMdd", new PersianCulture());
					short.Parse(now.ToString("MM", new PersianCulture()));
					_ = Configuration.AppType;
					short.Parse(Financial.Get().Id.ToString());
					_ = UserLogin.CurrentUser.UserId;
					string text2 = "";
					int num = 0;
					if (registerCodeCreateViewModel.CompanyId <= 0)
					{
						num++;
						text = text + Messages.msgErrorNotSelectCompany + "<br>";
					}
					else
					{
						CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(registerCodeCreateViewModel.CompanyId);
						if (companyById != null)
						{
							text2 = companyById.cmpNumber.ToString();
						}
						else
						{
							num++;
							text = text + Messages.msgErrorNotSelectCompany + "<br>";
						}
					}
					List<WSspSelectRegisterCodeOrderItems_Result> list = Enumerable.ToList<WSspSelectRegisterCodeOrderItems_Result>((IEnumerable<WSspSelectRegisterCodeOrderItems_Result>)_dbI.WSspSelectRegisterCodeOrderItems(registerCodeCreateViewModel.CompanyId, lCID, result));
					if (list == null || !Enumerable.Any<WSspSelectRegisterCodeOrderItems_Result>((IEnumerable<WSspSelectRegisterCodeOrderItems_Result>)list))
					{
						num++;
						text = text + Messages.msgErrorCmpNotHaveOrder + "<br>";
					}
					if (string.IsNullOrWhiteSpace(registerCodeCreateViewModel.DomainName))
					{
						num++;
						text = text + string.Format(Messages.msgErrorIsNotEnteredItem, Labels.GenerateRegisterCodeDomain) + "<br>";
					}
					if (num == 0)
					{
						if (list != null && Enumerable.Any<WSspSelectRegisterCodeOrderItems_Result>((IEnumerable<WSspSelectRegisterCodeOrderItems_Result>)list))
						{
							string text3 = "";
							Dictionary<string, bool> dictionary = new Dictionary<string, bool>();
							Dictionary<string, bool> defaultModules = GetDefaultModules();
							int num2 = 0;
							int num3 = 0;
							int num4 = 0;
							int num5 = 0;
							int num6 = 1;
							int num7 = 0;
							int num8 = 0;
							int num9 = 0;
							int num10 = 0;
							int num11 = 0;
							int num12 = 0;
							int num13 = 0;
							int num14 = 0;
							int num15 = 0;
							List<PrdModulesViewModel> list2 = new List<PrdModulesViewModel>();
							foreach (WSspSelectRegisterCodeOrderItems_Result item in list)
							{
								text3 = item.PrdModuleName ?? "";
								if (string.IsNullOrWhiteSpace(text3))
								{
									continue;
								}
								List<PrdModulesViewModel> list3 = new JavaScriptSerializer().Deserialize<List<PrdModulesViewModel>>(text3);
								if (list3 == null || !Enumerable.Any<PrdModulesViewModel>((IEnumerable<PrdModulesViewModel>)list3))
								{
									continue;
								}
								foreach (PrdModulesViewModel item2 in list3)
								{
									string text4 = item2.Module ?? "";
									_ = item2.Value;
									int count = item2.Count;
									if (!string.IsNullOrWhiteSpace(text4))
									{
										if (text4 == "ClientFromQty" && count > 0)
										{
											item2.Count = count * int.Parse(item.ordIQuantity.GetValueOrDefault(1.0).ToString());
										}
										else if (text4 == "WhCountFromQty" && count > 0)
										{
											item2.Count = count * int.Parse(item.ordIQuantity.GetValueOrDefault(1.0).ToString());
										}
										else if (text4 == "LangFromQty" && count > 0)
										{
											item2.Count = count * int.Parse(item.ordIQuantity.GetValueOrDefault(1.0).ToString());
										}
										else if (text4 == "HrmFromQty" && count > 0)
										{
											item2.Count = count * int.Parse(item.ordIQuantity.GetValueOrDefault(1.0).ToString());
										}
										else if (text4 == "MobFromQty" && count > 0)
										{
											item2.Count = count * int.Parse(item.ordIQuantity.GetValueOrDefault(1.0).ToString());
										}
										else if (text4 == "UserDeactiveFromQty" && count > 0)
										{
											item2.Count = count * int.Parse(item.ordIQuantity.GetValueOrDefault(1.0).ToString());
										}
										else if (text4 == "CicFromQty" && count > 0)
										{
											item2.Count = count * int.Parse(item.ordIQuantity.GetValueOrDefault(1.0).ToString());
										}
										else if (text4 == "CrmShopFromQty" && count > 0)
										{
											item2.Count = count * int.Parse(item.ordIQuantity.GetValueOrDefault(1.0).ToString());
										}
										else if (text4 == "AccDbCntFromQty" && count > 0)
										{
											item2.Count = count * int.Parse(item.ordIQuantity.GetValueOrDefault(1.0).ToString());
										}
										else if (text4 == "VoipCntFromQty" && count > 0)
										{
											item2.Count = count * int.Parse(item.ordIQuantity.GetValueOrDefault(1.0).ToString());
										}
										else if (text4 == "VoipTrunkCntFromQty" && count > 0)
										{
											item2.Count = count * int.Parse(item.ordIQuantity.GetValueOrDefault(1.0).ToString());
										}
										else if (text4 == "FoCntFromQty" && count > 0)
										{
											item2.Count = count * int.Parse(item.ordIQuantity.GetValueOrDefault(1.0).ToString());
										}
										else if (text4 == "CenterCntFromQty" && count > 0)
										{
											item2.Count = count * int.Parse(item.ordIQuantity.GetValueOrDefault(1.0).ToString());
										}
									}
								}
								list2.AddRange(list3);
							}
							if (list2 != null && Enumerable.Any<PrdModulesViewModel>((IEnumerable<PrdModulesViewModel>)list2))
							{
								foreach (PrdModulesViewModel item3 in list2)
								{
									string moduleName = item3.Module ?? "";
									_ = item3.Value;
									int count2 = item3.Count;
									if (string.IsNullOrWhiteSpace(moduleName))
									{
										continue;
									}
									if (moduleName == "UserCount")
									{
										num2 += count2;
										continue;
									}
									if (moduleName == "UserCountMob")
									{
										num3 += count2;
										continue;
									}
									if (moduleName == "UserCountDeactive")
									{
										num4 += count2;
										continue;
									}
									if (moduleName == "UserCountHrm")
									{
										num5 += count2;
										continue;
									}
									if (moduleName == "LangCount")
									{
										num6 += count2;
										continue;
									}
									if (moduleName == "WhCount")
									{
										num7 += count2;
										continue;
									}
									if (moduleName == "ClientFromQty" && count2 > 0)
									{
										num2 += count2;
										continue;
									}
									if (moduleName == "WhCountFromQty" && count2 > 0)
									{
										num7 += count2;
										continue;
									}
									if (moduleName == "PfCount" && count2 > 0)
									{
										num8 += count2;
										continue;
									}
									if (moduleName == "LangFromQty" && count2 > 0)
									{
										num6 += count2;
										continue;
									}
									if (moduleName == "HrmFromQty" && count2 > 0)
									{
										num5 += count2;
										continue;
									}
									if (moduleName == "MobFromQty" && count2 > 0)
									{
										num3 += count2;
										continue;
									}
									if (moduleName == "UserDeactiveFromQty" && count2 > 0)
									{
										num4 += count2;
										continue;
									}
									if (moduleName == "UserCountCic")
									{
										num9 += count2;
										continue;
									}
									if (moduleName == "CicFromQty" && count2 > 0)
									{
										num9 += count2;
										continue;
									}
									if (moduleName == "UserCountCrmShop")
									{
										num10 += count2;
										continue;
									}
									if (moduleName == "CrmShopFromQty" && count2 > 0)
									{
										num10 += count2;
										continue;
									}
									if (moduleName == "AccDbCount")
									{
										num11 += count2;
										continue;
									}
									if (moduleName == "AccDbCntFromQty" && count2 > 0)
									{
										num11 += count2;
										continue;
									}
									if (moduleName == "VoipCount")
									{
										num12 += count2;
										continue;
									}
									if (moduleName == "VoipCntFromQty" && count2 > 0)
									{
										num12 += count2;
										continue;
									}
									if (moduleName == "VoipTrunkCount")
									{
										num13 += count2;
										continue;
									}
									if (moduleName == "VoipTrunkCntFromQty" && count2 > 0)
									{
										num13 += count2;
										continue;
									}
									if (moduleName == "FoCount")
									{
										num14 += count2;
										continue;
									}
									if (moduleName == "FoCntFromQty" && count2 > 0)
									{
										num14 += count2;
										continue;
									}
									if (moduleName == "CenterCount")
									{
										num15 += count2;
										continue;
									}
									if (moduleName == "CenterCntFromQty" && count2 > 0)
									{
										num15 += count2;
										continue;
									}
									if (dictionary != null && Enumerable.Any<KeyValuePair<string, bool>>((IEnumerable<KeyValuePair<string, bool>>)dictionary))
									{
										if (string.IsNullOrWhiteSpace(Enumerable.FirstOrDefault<KeyValuePair<string, bool>>((IEnumerable<KeyValuePair<string, bool>>)dictionary, (Func<KeyValuePair<string, bool>, bool>)((KeyValuePair<string, bool> m) => m.Key == moduleName)).Key))
										{
											dictionary.Add(moduleName, value: true);
										}
									}
									else
									{
										dictionary.Add(moduleName, value: true);
									}
									defaultModules[moduleName] = true;
								}
							}
							if (dictionary != null && Enumerable.Count<KeyValuePair<string, bool>>((IEnumerable<KeyValuePair<string, bool>>)dictionary) > 0 && defaultModules != null)
							{
								string text5 = "";
								CRMspSelectSysRegCDCByCmpId_Result cRMspSelectSysRegCDCByCmpId_Result = Enumerable.FirstOrDefault<CRMspSelectSysRegCDCByCmpId_Result>((IEnumerable<CRMspSelectSysRegCDCByCmpId_Result>)_dbI.CRMspSelectSysRegCDCByCmpId(registerCodeCreateViewModel.CompanyId));
								try
								{
									if (cRMspSelectSysRegCDCByCmpId_Result != null)
									{
										if (!string.IsNullOrWhiteSpace(cRMspSelectSysRegCDCByCmpId_Result.Code))
										{
											text5 = CodeDecode.CrtRegDeCodding(cRMspSelectSysRegCDCByCmpId_Result.Code);
										}
									}
									else
									{
										CRMspSelectSysRegCDCLast_Result cRMspSelectSysRegCDCLast_Result = Enumerable.FirstOrDefault<CRMspSelectSysRegCDCLast_Result>((IEnumerable<CRMspSelectSysRegCDCLast_Result>)_dbI.CRMspSelectSysRegCDCLast());
										if (cRMspSelectSysRegCDCLast_Result != null)
										{
											string code = cRMspSelectSysRegCDCLast_Result.Code;
											if (!string.IsNullOrWhiteSpace(code))
											{
												string s = CodeDecode.CrtRegDeCodding(code);
												long result2 = 0L;
												long.TryParse(s, out result2);
												if (result2 > 0)
												{
													result2++;
													string code2 = CodeDecode.CrtRegCodding(result2.ToString());
													mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.CRMspInsertSysRegCDC(registerCodeCreateViewModel.CompanyId, code2));
													int result3 = 0;
													if (mct_I_Result != null)
													{
														int.TryParse(mct_I_Result.Result.ToString(), out result3);
													}
													if (result3 > 0)
													{
														text5 = result2.ToString();
													}
												}
											}
										}
									}
								}
								catch (Exception e)
								{
									ErrorSignal.FromCurrentContext().Raise(e);
									text5 = "";
								}
								if (string.IsNullOrWhiteSpace(text5))
								{
									registerCodeCreateResultViewModel = null;
									text = Messages.msgErrorCreateRegCodeSerialNumber;
									commonResultStatusViewModel = CommonResultStatusViewModel.Error;
									data = new CommonResultViewModel<RegisterCodeCreateResultViewModel>
									{
										Data = registerCodeCreateResultViewModel,
										Message = text,
										Status = commonResultStatusViewModel
									};
									return Json(data, JsonRequestBehavior.AllowGet);
								}
								registerCodeCreateViewModel.SerialKey = "1362-4717-" + text2 + "-" + text5;
								registerCodeCreateViewModel.UserCount = ((num2 == 0) ? 1 : num2);
								registerCodeCreateViewModel.UserCountMob = ((num3 == 0) ? 1 : num3);
								registerCodeCreateViewModel.DeActiveUserCount = ((num4 == 0) ? 1 : num4);
								registerCodeCreateViewModel.UserCountHrm = ((num5 == 0) ? 1 : num5);
								registerCodeCreateViewModel.LanguageCount = ((num6 == 0) ? 1 : num6);
								registerCodeCreateViewModel.PfCount = ((num8 == 0) ? 1 : num8);
								registerCodeCreateViewModel.WhCount = ((num7 == 0) ? 1 : num7);
								registerCodeCreateViewModel.UserCountCic = ((num9 == 0) ? 1 : num9);
								registerCodeCreateViewModel.UserCountCrmShop = ((num10 == 0) ? 1 : num10);
								registerCodeCreateViewModel.AccDbCount = num11;
								registerCodeCreateViewModel.VoipCount = num12;
								registerCodeCreateViewModel.VoipTrunkCount = num13;
								registerCodeCreateViewModel.FoCount = ((num14 == 0) ? 1 : num14);
								registerCodeCreateViewModel.CenterCount = ((num15 == 0) ? 1 : num15);
								RandomText randomText = new RandomText();
								string text6 = randomText.CreateRandomCode(6, WithNumber: true, false).Trim().Replace(" ", "");
								string text7 = randomText.CreateRandomCode(5, WithNumber: true, false).Trim().Replace(" ", "");
								string text8 = CodeDecode.RegCodding(text6 + registerCodeCreateViewModel.UserCount + text7);
								string text9 = CodeDecode.RegCodding(text6 + registerCodeCreateViewModel.UserCountMob + text7);
								string text10 = CodeDecode.RegCodding(text6 + registerCodeCreateViewModel.DeActiveUserCount + text7);
								string text11 = CodeDecode.RegCodding(text6 + registerCodeCreateViewModel.UserCountHrm + text7);
								string text12 = CodeDecode.RegCodding(text6 + registerCodeCreateViewModel.WhCount + text7);
								string text13 = CodeDecode.RegCodding(text6 + registerCodeCreateViewModel.UserCountCic + text7);
								string text14 = CodeDecode.RegCodding(text6 + registerCodeCreateViewModel.UserCountCrmShop + text7);
								string text15 = CodeDecode.RegCodding(text6 + registerCodeCreateViewModel.AccDbCount + text7);
								string text16 = CodeDecode.RegCodding(text6 + registerCodeCreateViewModel.VoipCount + text7);
								string text17 = CodeDecode.RegCodding(text6 + registerCodeCreateViewModel.VoipTrunkCount + text7);
								string text18 = CodeDecode.RegCodding(text6 + registerCodeCreateViewModel.FoCount + text7);
								string text19 = CodeDecode.RegCodding(text6 + registerCodeCreateViewModel.CenterCount + text7);
								text8 = CodeDecode.RegCodding(text8 + "UsrMob" + text9 + "UsrDeAct" + text10 + "UsrHrm" + text11 + "WhCnt" + text12 + "CicCnt" + text13 + "CRMShopCnt" + text14 + "AccDbCnt" + text15 + "VoipCnt" + text16 + "VoipTunkCnt" + text17 + "FoCnt" + text18 + "CCnt" + text19);
								string text20 = CodeDecode.RegCodding(registerCodeCreateViewModel.SerialKey);
								string text21 = "";
								bool flag = false;
								bool flag2 = false;
								bool flag3 = false;
								bool flag4 = false;
								bool flag5 = false;
								bool flag6 = false;
								foreach (KeyValuePair<string, bool> item4 in defaultModules)
								{
									string text22 = item4.Key ?? "";
									bool value = item4.Value;
									if (text22 == "I-" && value)
									{
										text21 = "I";
										text21 += "|U1|P0|O0|W0|";
										flag2 = true;
										flag = true;
									}
									else if (text22 == "II" && value)
									{
										text21 = "II";
										text21 += "|U1|P1|O0|W0|";
										defaultModules["K"] = true;
										flag2 = true;
										flag3 = true;
										flag6 = true;
										flag = true;
									}
									else if (text22 == "III" && value)
									{
										text21 = "III";
										text21 += "|U1|P1|O1|W0|";
										defaultModules["K"] = true;
										flag2 = true;
										flag3 = true;
										flag4 = true;
										flag6 = true;
										flag = true;
									}
									else if (text22 == "IV" && value)
									{
										text21 = "IV";
										text21 += "|U1|P0|O1|W0|";
										defaultModules["K"] = true;
										flag2 = true;
										flag4 = true;
										flag6 = true;
										flag = true;
									}
									else if (text22 == "V" && value)
									{
										text21 = "V";
										text21 += "|U1|P1|O0|W1|";
										defaultModules["K"] = true;
										flag2 = true;
										flag3 = true;
										flag5 = true;
										flag6 = true;
										flag = true;
									}
									else if (text22 == "VI" && value)
									{
										text21 = "VI";
										text21 += "|U1|P0|O1|W1|";
										defaultModules["K"] = true;
										flag2 = true;
										flag4 = true;
										flag5 = true;
										flag6 = true;
										flag = true;
									}
									else if (text22 == "VII" && value)
									{
										text21 = "VII";
										text21 += "|U1|P0|O0|W1|";
										defaultModules["K"] = true;
										flag2 = true;
										flag5 = true;
										flag6 = true;
										flag = true;
									}
									else if (text22 == "FUL" && value)
									{
										text21 = "FUL";
										text21 += "|U1|P1|O1|W1|";
										defaultModules["K"] = true;
										flag2 = true;
										flag3 = true;
										flag4 = true;
										flag5 = true;
										flag6 = true;
										flag = true;
									}
									else if (text22 == "U" && !flag)
									{
										if (text22 == "U" && value)
										{
											text21 += "U1|";
											flag2 = true;
										}
										else if (text22 == "U" && !value)
										{
											text21 += "U0|";
										}
									}
									else if (text22 == "P" && !flag)
									{
										if (text22 == "P" && value)
										{
											text21 += "P1|";
											flag3 = true;
											flag6 = true;
										}
										else if (text22 == "P" && !value)
										{
											text21 += "P0|";
										}
									}
									else if (text22 == "O" && !flag)
									{
										if (text22 == "O" && value)
										{
											text21 += "O1|";
											flag4 = true;
											flag6 = true;
										}
										else if (text22 == "O" && !value)
										{
											text21 += "O0|";
										}
									}
									else if (text22 == "W" && !flag)
									{
										if (text22 == "W" && value)
										{
											text21 += "W1|";
											flag5 = true;
											flag6 = true;
										}
										else if (text22 == "W" && !value)
										{
											text21 += "W0|";
										}
									}
									else if (text22 == "K")
									{
										if (flag6)
										{
											text21 += "K1|";
										}
										else if (value)
										{
											text21 += "K1|";
											flag6 = true;
										}
										else if (!value)
										{
											text21 += "K0|";
										}
									}
									else if (text22 != "I-" && text22 != "II" && text22 != "III" && text22 != "IV" && text22 != "V" && text22 != "VI" && text22 != "VII" && text22 != "FUL" && text22 != "U" && text22 != "P" && text22 != "O" && text22 != "W" && text22 != "K")
									{
										if (value)
										{
											text21 = text21 + text22 + "1|";
										}
										else if (!value)
										{
											text21 = text21 + text22 + "0|";
										}
									}
								}
								if (!flag && text21.StartsWith("U"))
								{
									text21 = ((flag2 && !flag3 && !flag4 && !flag5) ? ("I|" + text21) : ((flag2 && flag3 && !flag4 && !flag5) ? ("II|" + text21) : ((flag2 && flag3 && flag4 && !flag5) ? ("III|" + text21) : ((flag2 && !flag3 && flag4 && !flag5) ? ("IV|" + text21) : ((flag2 && flag3 && !flag4 && flag5) ? ("V|" + text21) : ((flag2 && !flag3 && flag4 && flag5) ? ("VI|" + text21) : ((flag2 && !flag3 && !flag4 && flag5) ? ("VII|" + text21) : ((!(flag2 && flag3 && flag4 && flag5)) ? ("I|" + text21) : ("FUL|" + text21)))))))));
								}
								if (text21.EndsWith("|"))
								{
									text21 = text21.TrimEnd(new char[1] { '|' });
								}
								text21 = CodeDecode.RegCodding(text21);
								string text23 = CodeDecode.RegCodding(registerCodeCreateViewModel.DomainName);
								int result4 = 0;
								int.TryParse(registerCodeCreateViewModel.LanguageCount.ToString(), out result4);
								string text24 = CodeDecode.RegCodding(result4.ToString());
								string registerCode = CodeDecode.RegCodding(text8 + "@" + text20 + "|" + text21 + "|" + text23 + "|" + text24);
								registerCodeCreateResultViewModel = new RegisterCodeCreateResultViewModel();
								registerCodeCreateResultViewModel.RegisterCode = registerCode;
								registerCodeCreateResultViewModel.SerialKey = registerCodeCreateViewModel.SerialKey;
								text = Messages.msgSuccessAction;
								commonResultStatusViewModel = CommonResultStatusViewModel.Success;
							}
							else
							{
								text = text + Messages.msgErrorCmpOrderItemNotInModules + "<br>";
								registerCodeCreateResultViewModel = null;
								commonResultStatusViewModel = CommonResultStatusViewModel.Error;
							}
						}
						else
						{
							text = text + Messages.msgErrorCmpNotHaveOrder + "<br>";
							registerCodeCreateResultViewModel = null;
							commonResultStatusViewModel = CommonResultStatusViewModel.Error;
						}
					}
					else
					{
						registerCodeCreateResultViewModel = null;
						if (string.IsNullOrWhiteSpace(text))
						{
							text = Messages.msgErrorRunFunction;
						}
						commonResultStatusViewModel = CommonResultStatusViewModel.Error;
					}
				}
				else
				{
					registerCodeCreateResultViewModel = null;
					text = Messages.msgErrorRunFunction;
					commonResultStatusViewModel = CommonResultStatusViewModel.Error;
				}
			}
			else
			{
				registerCodeCreateResultViewModel = null;
				text = Messages.msgErrorRunFunction;
				commonResultStatusViewModel = CommonResultStatusViewModel.Error;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			registerCodeCreateResultViewModel = null;
			text = Messages.msgErrorRunFunction + " " + ex.Message;
			commonResultStatusViewModel = CommonResultStatusViewModel.Error;
		}
		data = new CommonResultViewModel<RegisterCodeCreateResultViewModel>
		{
			Data = registerCodeCreateResultViewModel,
			Message = text,
			Status = commonResultStatusViewModel
		};
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	public Dictionary<string, bool> GetDefaultModules()
	{
		Dictionary<string, bool> dictionary = new Dictionary<string, bool>();
		try
		{
			string[] array = "I-0|II0|III0|IV0|V0|VI0|VII0|FUL0|U0|P0|O0|W0|G0|B0|S0|C0|R0|E0|F0|L0|K0|X0|I0|T0|D0|H0|A0|URP0|FUD0|CTC1|CST0|DEC0|CIE0|OIE0|DC0|WHUP0|IMDocOrd0|VerifyWrkflw0|MobAccCmpDistance0|SUR0|MobFinancial0|FoClub0|FoShop0|FoCmsPage1|FoCmsNews1|SCO0|COM0|WhtApp0|DyMenu0|PrdValid0|PrdIVR0|TicketPlus0|LtrNumCounter0|SmartTmAttend0|CrmApi0|PordPlus0|BordPlus0|MobDyForm0|CnvsStatusResult0|APIVoip0|SimpleTicket0|PrjPrdHis0|Leave0|Tsp0|MoneyBag0|OnlinePay0|AutoCalcIssueBill0|Stsup0|ADLog0|UIE0|DisSt0|Outlook0|OrdProfit0|Center0|PrdSpec0|PrdAutoCalcPrice0|DisPol0|AI0|ENT0|CrmApiFRL0|WST0".Split(new char[1] { '|' });
			foreach (string text in array)
			{
				if (text.EndsWith("0"))
				{
					if (text.Length == 2)
					{
						dictionary.Add(text.Substring(0, 1), value: false);
					}
					else
					{
						dictionary.Add(text.Substring(0, text.Length - 1), value: false);
					}
				}
				else if (text.EndsWith("1"))
				{
					if (text.Length == 2)
					{
						dictionary.Add(text.Substring(0, 1), value: true);
					}
					else
					{
						dictionary.Add(text.Substring(0, text.Length - 1), value: true);
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return dictionary;
	}

	public ActionResult TestRegisterCode()
	{
		RegisterCodeTestResultViewModel registerCodeTestResultViewModel = new RegisterCodeTestResultViewModel();
		registerCodeTestResultViewModel.ModuleList = new List<PrdModuleNameByValViewModel>();
		try
		{
			string text = "";
			HttpCookie val = base.Request.Cookies.Get("TestRegCode");
			if (val != null && val.Value != null)
			{
				text = base.Server.UrlDecode(val.Value.ToString());
			}
			if (!string.IsNullOrWhiteSpace(text))
			{
				text = text.Trim();
				List<PrdModuleNameViewModel> listPrdModuleNames = new DetailsController().GetListPrdModuleNames();
				if (listPrdModuleNames != null && Enumerable.Any<PrdModuleNameViewModel>((IEnumerable<PrdModuleNameViewModel>)listPrdModuleNames))
				{
					foreach (PrdModuleNameViewModel item2 in listPrdModuleNames)
					{
						PrdModuleNameByValViewModel item = new PrdModuleNameByValViewModel
						{
							ModuleName = item2.ModuleName,
							ModuleLabel = item2.ModuleLabel,
							ModuleGroup = item2.ModuleGroup,
							Module = item2.Module,
							OrderView = item2.OrderView,
							IsCnt = item2.IsCnt
						};
						registerCodeTestResultViewModel.ModuleList.Add(item);
					}
				}
				string getString = text.Trim();
				getString = CodeDecode.RegDeCodding(getString);
				string[] array = getString.Split(new char[1] { '|' });
				getString = array[0].Split(new char[1] { '@' })[0];
				string text2 = "";
				string text3 = "";
				string text4 = "";
				string text5 = "";
				string text6 = "";
				string text7 = "";
				string text8 = "";
				string text9 = "";
				string text10 = "";
				string text11 = "";
				string text12 = "";
				if (!string.IsNullOrWhiteSpace(getString))
				{
					getString = CodeDecode.RegDeCodding(getString);
					if (getString.IndexOf("UsrDeAct") < 0)
					{
						string[] array2 = getString.Split(new string[1] { "UsrMob" }, StringSplitOptions.None);
						if (array2 != null && array2.Length == 2)
						{
							getString = array2[0];
							text2 = array2[1];
						}
					}
					else if (getString.IndexOf("UsrDeAct") >= 0)
					{
						string[] array3 = getString.Split(new string[1] { "UsrMob" }, StringSplitOptions.None);
						if (array3 != null && array3.Length == 2)
						{
							getString = array3[0];
							text2 = array3[1];
						}
						if (!string.IsNullOrWhiteSpace(text2) && text2.IndexOf("UsrDeAct") >= 0)
						{
							string[] array4 = text2.Split(new string[1] { "UsrDeAct" }, StringSplitOptions.None);
							if (array4 != null && array4.Length == 2)
							{
								text2 = array4[0];
								text3 = array4[1];
							}
						}
						if (!string.IsNullOrWhiteSpace(text3) && text3.IndexOf("UsrHrm") >= 0)
						{
							string[] array5 = text3.Split(new string[1] { "UsrHrm" }, StringSplitOptions.None);
							if (array5 != null && array5.Length == 2)
							{
								text3 = array5[0];
								text4 = array5[1];
							}
						}
						if (!string.IsNullOrWhiteSpace(text4) && text4.IndexOf("WhCnt") >= 0)
						{
							string[] array6 = text4.Split(new string[1] { "WhCnt" }, StringSplitOptions.None);
							if (array6 != null && array6.Length == 2)
							{
								text4 = array6[0];
								text5 = array6[1];
							}
						}
						if (!string.IsNullOrWhiteSpace(text5) && text5.IndexOf("CicCnt") >= 0)
						{
							string[] array7 = text5.Split(new string[1] { "CicCnt" }, StringSplitOptions.None);
							if (array7 != null && array7.Length == 2)
							{
								text5 = array7[0];
								text6 = array7[1];
							}
						}
						if (!string.IsNullOrWhiteSpace(text6) && text6.IndexOf("CRMShopCnt") >= 0)
						{
							string[] array8 = text6.Split(new string[1] { "CRMShopCnt" }, StringSplitOptions.None);
							if (array8 != null && array8.Length == 2)
							{
								text6 = array8[0];
								text7 = array8[1];
							}
						}
						if (!string.IsNullOrWhiteSpace(text7) && text7.IndexOf("AccDbCnt") >= 0)
						{
							string[] array9 = text7.Split(new string[1] { "AccDbCnt" }, StringSplitOptions.None);
							if (array9 != null && array9.Length == 2)
							{
								text7 = array9[0];
								text8 = array9[1];
							}
						}
					}
					else if (getString.IndexOf("UsrHrm") >= 0)
					{
						string[] array10 = getString.Split(new string[1] { "UsrMob" }, StringSplitOptions.None);
						if (array10 != null && array10.Length == 2)
						{
							getString = array10[0];
							text2 = array10[1];
						}
						if (!string.IsNullOrWhiteSpace(text2) && text2.IndexOf("UsrDeAct") >= 0)
						{
							string[] array11 = text2.Split(new string[1] { "UsrDeAct" }, StringSplitOptions.None);
							if (array11 != null && array11.Length == 2)
							{
								text2 = array11[0];
								text3 = array11[1];
							}
						}
						if (!string.IsNullOrWhiteSpace(text3) && text3.IndexOf("UsrHrm") >= 0)
						{
							string[] array12 = text3.Split(new string[1] { "UsrHrm" }, StringSplitOptions.None);
							if (array12 != null && array12.Length == 2)
							{
								text3 = array12[0];
								text4 = array12[1];
							}
						}
						if (!string.IsNullOrWhiteSpace(text4) && text4.IndexOf("WhCnt") >= 0)
						{
							string[] array13 = text4.Split(new string[1] { "WhCnt" }, StringSplitOptions.None);
							if (array13 != null && array13.Length == 2)
							{
								text4 = array13[0];
								text5 = array13[1];
							}
						}
						if (!string.IsNullOrWhiteSpace(text5) && text5.IndexOf("CicCnt") >= 0)
						{
							string[] array14 = text5.Split(new string[1] { "CicCnt" }, StringSplitOptions.None);
							if (array14 != null && array14.Length == 2)
							{
								text5 = array14[0];
								text6 = array14[1];
							}
						}
						if (!string.IsNullOrWhiteSpace(text6) && text6.IndexOf("CRMShopCnt") >= 0)
						{
							string[] array15 = text6.Split(new string[1] { "CRMShopCnt" }, StringSplitOptions.None);
							if (array15 != null && array15.Length == 2)
							{
								text6 = array15[0];
								text7 = array15[1];
							}
						}
						if (!string.IsNullOrWhiteSpace(text7) && text7.IndexOf("AccDbCnt") >= 0)
						{
							string[] array16 = text7.Split(new string[1] { "AccDbCnt" }, StringSplitOptions.None);
							if (array16 != null && array16.Length == 2)
							{
								text7 = array16[0];
								text8 = array16[1];
							}
						}
					}
					else if (getString.IndexOf("WhCnt") >= 0)
					{
						string[] array17 = getString.Split(new string[1] { "UsrMob" }, StringSplitOptions.None);
						if (array17 != null && array17.Length == 2)
						{
							getString = array17[0];
							text2 = array17[1];
						}
						if (!string.IsNullOrWhiteSpace(text2) && text2.IndexOf("UsrDeAct") >= 0)
						{
							string[] array18 = text2.Split(new string[1] { "UsrDeAct" }, StringSplitOptions.None);
							if (array18 != null && array18.Length == 2)
							{
								text2 = array18[0];
								text3 = array18[1];
							}
						}
						if (!string.IsNullOrWhiteSpace(text3) && text3.IndexOf("UsrHrm") >= 0)
						{
							string[] array19 = text3.Split(new string[1] { "UsrHrm" }, StringSplitOptions.None);
							if (array19 != null && array19.Length == 2)
							{
								text3 = array19[0];
								text4 = array19[1];
							}
						}
						if (!string.IsNullOrWhiteSpace(text4) && text4.IndexOf("WhCnt") >= 0)
						{
							string[] array20 = text4.Split(new string[1] { "WhCnt" }, StringSplitOptions.None);
							if (array20 != null && array20.Length == 2)
							{
								text4 = array20[0];
								text5 = array20[1];
							}
						}
						if (!string.IsNullOrWhiteSpace(text5) && text5.IndexOf("CicCnt") >= 0)
						{
							string[] array21 = text5.Split(new string[1] { "CicCnt" }, StringSplitOptions.None);
							if (array21 != null && array21.Length == 2)
							{
								text5 = array21[0];
								text6 = array21[1];
							}
						}
						if (!string.IsNullOrWhiteSpace(text6) && text6.IndexOf("CRMShopCnt") >= 0)
						{
							string[] array22 = text6.Split(new string[1] { "CRMShopCnt" }, StringSplitOptions.None);
							if (array22 != null && array22.Length == 2)
							{
								text6 = array22[0];
								text7 = array22[1];
							}
						}
						if (!string.IsNullOrWhiteSpace(text7) && text7.IndexOf("AccDbCnt") >= 0)
						{
							string[] array23 = text7.Split(new string[1] { "AccDbCnt" }, StringSplitOptions.None);
							if (array23 != null && array23.Length == 2)
							{
								text7 = array23[0];
								text8 = array23[1];
							}
						}
					}
					else if (getString.IndexOf("CicCnt") >= 0)
					{
						string[] array24 = getString.Split(new string[1] { "UsrMob" }, StringSplitOptions.None);
						if (array24 != null && array24.Length == 2)
						{
							getString = array24[0];
							text2 = array24[1];
						}
						if (!string.IsNullOrWhiteSpace(text2) && text2.IndexOf("UsrDeAct") >= 0)
						{
							string[] array25 = text2.Split(new string[1] { "UsrDeAct" }, StringSplitOptions.None);
							if (array25 != null && array25.Length == 2)
							{
								text2 = array25[0];
								text3 = array25[1];
							}
						}
						if (!string.IsNullOrWhiteSpace(text3) && text3.IndexOf("UsrHrm") >= 0)
						{
							string[] array26 = text3.Split(new string[1] { "UsrHrm" }, StringSplitOptions.None);
							if (array26 != null && array26.Length == 2)
							{
								text3 = array26[0];
								text4 = array26[1];
							}
						}
						if (!string.IsNullOrWhiteSpace(text4) && text4.IndexOf("WhCnt") >= 0)
						{
							string[] array27 = text4.Split(new string[1] { "WhCnt" }, StringSplitOptions.None);
							if (array27 != null && array27.Length == 2)
							{
								text4 = array27[0];
								text5 = array27[1];
							}
						}
						if (!string.IsNullOrWhiteSpace(text5) && text5.IndexOf("CicCnt") >= 0)
						{
							string[] array28 = text5.Split(new string[1] { "CicCnt" }, StringSplitOptions.None);
							if (array28 != null && array28.Length == 2)
							{
								text5 = array28[0];
								text6 = array28[1];
							}
						}
						if (!string.IsNullOrWhiteSpace(text6) && text6.IndexOf("CRMShopCnt") >= 0)
						{
							string[] array29 = text6.Split(new string[1] { "CRMShopCnt" }, StringSplitOptions.None);
							if (array29 != null && array29.Length == 2)
							{
								text6 = array29[0];
								text7 = array29[1];
							}
						}
						if (!string.IsNullOrWhiteSpace(text7) && text7.IndexOf("AccDbCnt") >= 0)
						{
							string[] array30 = text7.Split(new string[1] { "AccDbCnt" }, StringSplitOptions.None);
							if (array30 != null && array30.Length == 2)
							{
								text7 = array30[0];
								text8 = array30[1];
							}
						}
					}
					else if (getString.IndexOf("CRMShopCnt") >= 0)
					{
						string[] array31 = getString.Split(new string[1] { "UsrMob" }, StringSplitOptions.None);
						if (array31 != null && array31.Length == 2)
						{
							getString = array31[0];
							text2 = array31[1];
						}
						if (!string.IsNullOrWhiteSpace(text2) && text2.IndexOf("UsrDeAct") >= 0)
						{
							string[] array32 = text2.Split(new string[1] { "UsrDeAct" }, StringSplitOptions.None);
							if (array32 != null && array32.Length == 2)
							{
								text2 = array32[0];
								text3 = array32[1];
							}
						}
						if (!string.IsNullOrWhiteSpace(text3) && text3.IndexOf("UsrHrm") >= 0)
						{
							string[] array33 = text3.Split(new string[1] { "UsrHrm" }, StringSplitOptions.None);
							if (array33 != null && array33.Length == 2)
							{
								text3 = array33[0];
								text4 = array33[1];
							}
						}
						if (!string.IsNullOrWhiteSpace(text4) && text4.IndexOf("WhCnt") >= 0)
						{
							string[] array34 = text4.Split(new string[1] { "WhCnt" }, StringSplitOptions.None);
							if (array34 != null && array34.Length == 2)
							{
								text4 = array34[0];
								text5 = array34[1];
							}
						}
						if (!string.IsNullOrWhiteSpace(text5) && text5.IndexOf("CicCnt") >= 0)
						{
							string[] array35 = text5.Split(new string[1] { "CicCnt" }, StringSplitOptions.None);
							if (array35 != null && array35.Length == 2)
							{
								text5 = array35[0];
								text6 = array35[1];
							}
						}
						if (!string.IsNullOrWhiteSpace(text6) && text6.IndexOf("CRMShopCnt") >= 0)
						{
							string[] array36 = text6.Split(new string[1] { "CRMShopCnt" }, StringSplitOptions.None);
							if (array36 != null && array36.Length == 2)
							{
								text6 = array36[0];
								text7 = array36[1];
							}
						}
						if (!string.IsNullOrWhiteSpace(text7) && text7.IndexOf("AccDbCnt") >= 0)
						{
							string[] array37 = text7.Split(new string[1] { "AccDbCnt" }, StringSplitOptions.None);
							if (array37 != null && array37.Length == 2)
							{
								text7 = array37[0];
								text8 = array37[1];
							}
						}
					}
					else if (getString.IndexOf("AccDbCnt") >= 0)
					{
						string[] array38 = getString.Split(new string[1] { "UsrMob" }, StringSplitOptions.None);
						if (array38 != null && array38.Length == 2)
						{
							getString = array38[0];
							text2 = array38[1];
						}
						if (!string.IsNullOrWhiteSpace(text2) && text2.IndexOf("UsrDeAct") >= 0)
						{
							string[] array39 = text2.Split(new string[1] { "UsrDeAct" }, StringSplitOptions.None);
							if (array39 != null && array39.Length == 2)
							{
								text2 = array39[0];
								text3 = array39[1];
							}
						}
						if (!string.IsNullOrWhiteSpace(text3) && text3.IndexOf("UsrHrm") >= 0)
						{
							string[] array40 = text3.Split(new string[1] { "UsrHrm" }, StringSplitOptions.None);
							if (array40 != null && array40.Length == 2)
							{
								text3 = array40[0];
								text4 = array40[1];
							}
						}
						if (!string.IsNullOrWhiteSpace(text4) && text4.IndexOf("WhCnt") >= 0)
						{
							string[] array41 = text4.Split(new string[1] { "WhCnt" }, StringSplitOptions.None);
							if (array41 != null && array41.Length == 2)
							{
								text4 = array41[0];
								text5 = array41[1];
							}
						}
						if (!string.IsNullOrWhiteSpace(text5) && text5.IndexOf("CicCnt") >= 0)
						{
							string[] array42 = text5.Split(new string[1] { "CicCnt" }, StringSplitOptions.None);
							if (array42 != null && array42.Length == 2)
							{
								text5 = array42[0];
								text6 = array42[1];
							}
						}
						if (!string.IsNullOrWhiteSpace(text6) && text6.IndexOf("CRMShopCnt") >= 0)
						{
							string[] array43 = text6.Split(new string[1] { "CRMShopCnt" }, StringSplitOptions.None);
							if (array43 != null && array43.Length == 2)
							{
								text6 = array43[0];
								text7 = array43[1];
							}
						}
						if (!string.IsNullOrWhiteSpace(text7) && text7.IndexOf("AccDbCnt") >= 0)
						{
							string[] array44 = text7.Split(new string[1] { "AccDbCnt" }, StringSplitOptions.None);
							if (array44 != null && array44.Length == 2)
							{
								text7 = array44[0];
								text8 = array44[1];
							}
						}
					}
					if (!string.IsNullOrWhiteSpace(text8) && text8.IndexOf("VoipCnt") >= 0)
					{
						string[] array45 = text8.Split(new string[1] { "VoipCnt" }, StringSplitOptions.None);
						if (array45 != null && array45.Length == 2)
						{
							text8 = array45[0];
							text9 = array45[1];
						}
					}
					if (!string.IsNullOrWhiteSpace(text9) && text9.IndexOf("VoipTunkCnt") >= 0)
					{
						string[] array46 = text9.Split(new string[1] { "VoipTunkCnt" }, StringSplitOptions.None);
						if (array46 != null && array46.Length == 2)
						{
							text9 = array46[0];
							text10 = array46[1];
						}
					}
					if (!string.IsNullOrWhiteSpace(text10) && text10.IndexOf("FoCnt") >= 0)
					{
						string[] array47 = text10.Split(new string[1] { "FoCnt" }, StringSplitOptions.None);
						if (array47 != null && array47.Length == 2)
						{
							text10 = array47[0];
							text11 = array47[1];
						}
					}
					if (!string.IsNullOrWhiteSpace(text11) && text11.IndexOf("CCnt") >= 0)
					{
						string[] array48 = text11.Split(new string[1] { "CCnt" }, StringSplitOptions.None);
						if (array48 != null && array48.Length == 2)
						{
							text11 = array48[0];
							text12 = array48[1];
						}
					}
				}
				registerCodeTestResultViewModel.SerialKey = CodeDecode.RegDeCodding(array[0].Split(new char[1] { '@' })[1]);
				getString = CodeDecode.RegDeCodding(getString);
				getString = getString.Remove(getString.Length - 5);
				registerCodeTestResultViewModel.UserCount = getString.Substring(6);
				if (!string.IsNullOrWhiteSpace(text2))
				{
					text2 = CodeDecode.RegDeCodding(text2);
					text2 = text2.Remove(text2.Length - 5);
					registerCodeTestResultViewModel.UserCountMob = text2.Substring(6);
				}
				if (!string.IsNullOrWhiteSpace(text3))
				{
					text3 = CodeDecode.RegDeCodding(text3);
					text3 = text3.Remove(text3.Length - 5);
					registerCodeTestResultViewModel.DeActiveUserCount = text3.Substring(6);
				}
				if (!string.IsNullOrWhiteSpace(text4))
				{
					text4 = CodeDecode.RegDeCodding(text4);
					text4 = text4.Remove(text4.Length - 5);
					registerCodeTestResultViewModel.UserCountHrm = text4.Substring(6);
				}
				if (!string.IsNullOrWhiteSpace(text5))
				{
					text5 = CodeDecode.RegDeCodding(text5);
					text5 = text5.Remove(text5.Length - 5);
					registerCodeTestResultViewModel.WhCount = text5.Substring(6);
				}
				if (!string.IsNullOrWhiteSpace(text6))
				{
					text6 = CodeDecode.RegDeCodding(text6);
					text6 = text6.Remove(text6.Length - 5);
					registerCodeTestResultViewModel.UserCountCic = text6.Substring(6);
				}
				if (!string.IsNullOrWhiteSpace(text7))
				{
					text7 = CodeDecode.RegDeCodding(text7);
					text7 = text7.Remove(text7.Length - 5);
					registerCodeTestResultViewModel.UserCountCrmShop = text7.Substring(6);
				}
				if (!string.IsNullOrWhiteSpace(text8))
				{
					text8 = CodeDecode.RegDeCodding(text8);
					text8 = text8.Remove(text8.Length - 5);
					registerCodeTestResultViewModel.AccDbCount = text8.Substring(6);
				}
				if (!string.IsNullOrWhiteSpace(text9))
				{
					text9 = CodeDecode.RegDeCodding(text9);
					text9 = text9.Remove(text9.Length - 5);
					registerCodeTestResultViewModel.VoipCount = text9.Substring(6);
				}
				if (!string.IsNullOrWhiteSpace(text10))
				{
					text10 = CodeDecode.RegDeCodding(text10);
					text10 = text10.Remove(text10.Length - 5);
					registerCodeTestResultViewModel.VoipTrunkCount = text10.Substring(6);
				}
				if (!string.IsNullOrWhiteSpace(text11))
				{
					text11 = CodeDecode.RegDeCodding(text11);
					text11 = text11.Remove(text11.Length - 5);
					registerCodeTestResultViewModel.FoCount = text11.Substring(6);
				}
				if (!string.IsNullOrWhiteSpace(text12))
				{
					text12 = CodeDecode.RegDeCodding(text12);
					text12 = text12.Remove(text12.Length - 5);
					registerCodeTestResultViewModel.CenterCount = text12.Substring(6);
				}
				string[] array49 = CodeDecode.RegDeCodding(array[1]).Split(new char[1] { '|' });
				foreach (string text13 in array49)
				{
					string text14 = "";
					bool moduleChecked = false;
					if (text13.EndsWith("0"))
					{
						moduleChecked = false;
						text14 = ((text13.Length != 2) ? text13.Substring(0, text13.Length - 1) : text13.Substring(0, 1));
					}
					else if (text13.EndsWith("1"))
					{
						moduleChecked = true;
						text14 = ((text13.Length != 2) ? text13.Substring(0, text13.Length - 1) : text13.Substring(0, 1));
					}
					if (string.IsNullOrWhiteSpace(text14) || registerCodeTestResultViewModel.ModuleList == null || !Enumerable.Any<PrdModuleNameByValViewModel>((IEnumerable<PrdModuleNameByValViewModel>)registerCodeTestResultViewModel.ModuleList))
					{
						continue;
					}
					foreach (PrdModuleNameByValViewModel module in registerCodeTestResultViewModel.ModuleList)
					{
						if (!string.IsNullOrWhiteSpace(module.Module) && module.Module == text14)
						{
							module.ModuleChecked = moduleChecked;
						}
					}
				}
				string getString2 = array[2];
				registerCodeTestResultViewModel.DomainName = CodeDecode.RegDeCodding(getString2);
				if (array.Length > 3)
				{
					string getString3 = array[3];
					registerCodeTestResultViewModel.LanguageCount = CodeDecode.RegDeCodding(getString3);
				}
				if (registerCodeTestResultViewModel.ModuleList != null && Enumerable.Any<PrdModuleNameByValViewModel>((IEnumerable<PrdModuleNameByValViewModel>)registerCodeTestResultViewModel.ModuleList))
				{
					foreach (PrdModuleNameByValViewModel module2 in registerCodeTestResultViewModel.ModuleList)
					{
						if (string.IsNullOrWhiteSpace(module2.Module))
						{
							continue;
						}
						if (module2.Module == "UserCount")
						{
							module2.ModuleChecked = true;
							module2.ModuleCount = int.Parse(registerCodeTestResultViewModel.UserCount);
						}
						else if (module2.Module == "UserCountMob")
						{
							module2.ModuleChecked = true;
							module2.ModuleCount = int.Parse(registerCodeTestResultViewModel.UserCountMob);
						}
						else if (module2.Module == "UserCountDeactive")
						{
							module2.ModuleChecked = true;
							module2.ModuleCount = int.Parse(registerCodeTestResultViewModel.DeActiveUserCount);
						}
						else if (module2.Module == "UserCountHrm")
						{
							module2.ModuleChecked = true;
							module2.ModuleCount = int.Parse(registerCodeTestResultViewModel.UserCountHrm);
						}
						else if (module2.Module == "LangCount")
						{
							module2.ModuleChecked = true;
							module2.ModuleCount = int.Parse(registerCodeTestResultViewModel.LanguageCount);
						}
						else if (module2.Module == "WhCount")
						{
							module2.ModuleChecked = true;
							module2.ModuleCount = int.Parse(registerCodeTestResultViewModel.WhCount);
						}
						else if (module2.Module == "UserCountCic")
						{
							module2.ModuleChecked = true;
							module2.ModuleCount = int.Parse(registerCodeTestResultViewModel.UserCountCic);
						}
						else if (module2.Module == "UserCountCrmShop")
						{
							module2.ModuleChecked = true;
							module2.ModuleCount = int.Parse(registerCodeTestResultViewModel.UserCountCrmShop);
						}
						else if (module2.Module == "AccDbCount")
						{
							module2.ModuleChecked = true;
							module2.ModuleCount = int.Parse(registerCodeTestResultViewModel.AccDbCount);
							if (module2.ModuleCount == 0)
							{
								module2.ModuleChecked = false;
							}
						}
						else if (module2.Module == "VoipCount")
						{
							module2.ModuleChecked = true;
							module2.ModuleCount = int.Parse(registerCodeTestResultViewModel.VoipCount);
							if (module2.ModuleCount == 0)
							{
								module2.ModuleChecked = false;
							}
						}
						else if (module2.Module == "VoipTrunkCount")
						{
							module2.ModuleChecked = true;
							module2.ModuleCount = int.Parse(registerCodeTestResultViewModel.VoipTrunkCount);
							if (module2.ModuleCount == 0)
							{
								module2.ModuleChecked = false;
							}
						}
						else if (module2.Module == "FoCount")
						{
							module2.ModuleChecked = true;
							module2.ModuleCount = int.Parse(registerCodeTestResultViewModel.FoCount);
							if (module2.ModuleCount == 0)
							{
								module2.ModuleChecked = false;
							}
						}
						else if (module2.Module == "CenterCount")
						{
							module2.ModuleChecked = true;
							module2.ModuleCount = int.Parse(registerCodeTestResultViewModel.CenterCount);
							if (module2.ModuleCount == 0)
							{
								module2.ModuleChecked = false;
							}
						}
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View(registerCodeTestResultViewModel);
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbI.Dispose();
		base.Dispose(disposing);
	}
}
