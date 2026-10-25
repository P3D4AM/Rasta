using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.Objects;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Web.Http;
using CRM.General.Security;
using CRM.General.Utilities;
using CRM.OtherWebServices.LinkNoAvaranCapillary;
using CRMIdealApi.ApiModels;
using CRMIdealApi.Classes;
using CRMIdealApi.Classes.Common;
using CRMIdealApi.Classes.Helper;
using CRMIdealApi.DataType;
using CRMIdealApi.Resources;
using Elmah;
using GSD.Globalization;
using Newtonsoft.Json;

namespace CRMIdealApi.Controllers;

public class ApiOtherSystemsController : ApiController
{
	private readonly CRMEntities db = new CRMEntities();

	private ResourceManager RS = new ResourceManager();

	public string TarazGetPrdQuantityAndPrice(int prdId, int cmpId, int whId, int prdPriceGroupId, ref decimal prdPrice, ref double prdQuantity, string CrmOrdType = "pord", int? userId = 0, int currLangId = 0, int defLangId = 0, int? centerId = null, string centerCode = null, string linkAccPrdPriceIdStr = null, DateTime? linkAccFirstTransferDate = null, DateTime? linkAccLastTransferDate = null, string linkAccData = null)
	{
		//IL_0cbe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cc3: Unknown result type (might be due to invalid IL or missing references)
		string result = "";
		string rsCollation = "fa-IR";
		try
		{
			if (cmpId <= 0)
			{
				string message = RS.Get("ErrorNotFound", rsCollation, RS.TypeMsg) + "(company)";
				Exception e = new Exception(message);
				ErrorSignal.FromCurrentContext().Raise(e);
				result = RS.Get("frmError", rsCollation, RS.TypeLbl);
			}
			else if (prdId <= 0)
			{
				string message2 = RS.Get("ErrorNotFound", rsCollation, RS.TypeMsg) + "(product)";
				Exception e2 = new Exception(message2);
				ErrorSignal.FromCurrentContext().Raise(e2);
				result = RS.Get("frmError", rsCollation, RS.TypeLbl);
			}
			else if (whId <= 0)
			{
				string message3 = RS.Get("ErrorNotFound", rsCollation, RS.TypeMsg) + "(warehouse)";
				Exception e3 = new Exception(message3);
				ErrorSignal.FromCurrentContext().Raise(e3);
				result = RS.Get("frmError", rsCollation, RS.TypeLbl);
			}
			else
			{
				ApispSelectProductsWithId_Result apispSelectProductsWithId_Result = Enumerable.FirstOrDefault<ApispSelectProductsWithId_Result>((IEnumerable<ApispSelectProductsWithId_Result>)db.ApispSelectProductsWithId(prdId, currLangId, defLangId));
				if (apispSelectProductsWithId_Result != null)
				{
					ApispSelectCompanyById_Result apispSelectCompanyById_Result = Enumerable.FirstOrDefault<ApispSelectCompanyById_Result>((IEnumerable<ApispSelectCompanyById_Result>)db.ApispSelectCompanyById(cmpId, currLangId, defLangId, centerId, centerCode));
					if (apispSelectCompanyById_Result != null)
					{
						ApispSelectWareHouseWithAccLinkField_Result apispSelectWareHouseWithAccLinkField_Result = new ApispSelectWareHouseWithAccLinkField_Result();
						List<ApispSelectWareHouseWithAccLinkField_Result> list = Enumerable.ToList<ApispSelectWareHouseWithAccLinkField_Result>((IEnumerable<ApispSelectWareHouseWithAccLinkField_Result>)db.ApispSelectWareHouseWithAccLinkField(false, false, false, false, currLangId, defLangId));
						if (list != null)
						{
							apispSelectWareHouseWithAccLinkField_Result = Enumerable.FirstOrDefault<ApispSelectWareHouseWithAccLinkField_Result>((IEnumerable<ApispSelectWareHouseWithAccLinkField_Result>)list, (Func<ApispSelectWareHouseWithAccLinkField_Result, bool>)((ApispSelectWareHouseWithAccLinkField_Result m) => m.WareHouseID == whId));
						}
						if (apispSelectWareHouseWithAccLinkField_Result != null)
						{
							if (!string.IsNullOrEmpty(apispSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhIdStr))
							{
								if (!string.IsNullOrEmpty(apispSelectProductsWithId_Result.PrdLinkAccPrdCode))
								{
									if (!string.IsNullOrEmpty(apispSelectCompanyById_Result.cmpLinkAccCustomerIdStr))
									{
										List<ApispSelectLinkAccTarazSetting_Result> list2 = Enumerable.ToList<ApispSelectLinkAccTarazSetting_Result>((IEnumerable<ApispSelectLinkAccTarazSetting_Result>)db.ApispSelectLinkAccTarazSetting(0, "Setting", currLangId, defLangId));
										if (list2 != null)
										{
											string text = "";
											ApispSelectLinkAccTarazSetting_Result apispSelectLinkAccTarazSetting_Result = Enumerable.FirstOrDefault<ApispSelectLinkAccTarazSetting_Result>((IEnumerable<ApispSelectLinkAccTarazSetting_Result>)list2, (Func<ApispSelectLinkAccTarazSetting_Result, bool>)((ApispSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 1));
											if (apispSelectLinkAccTarazSetting_Result != null)
											{
												text = apispSelectLinkAccTarazSetting_Result.PartValue ?? "";
											}
											string text2 = "";
											string text3 = "";
											ApispSelectLinkAccTarazSetting_Result apispSelectLinkAccTarazSetting_Result2 = Enumerable.FirstOrDefault<ApispSelectLinkAccTarazSetting_Result>((IEnumerable<ApispSelectLinkAccTarazSetting_Result>)list2, (Func<ApispSelectLinkAccTarazSetting_Result, bool>)((ApispSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 2));
											if (apispSelectLinkAccTarazSetting_Result2 != null)
											{
												text3 = apispSelectLinkAccTarazSetting_Result2.PartValue ?? "";
											}
											string text4 = "";
											ApispSelectLinkAccTarazSetting_Result apispSelectLinkAccTarazSetting_Result3 = Enumerable.FirstOrDefault<ApispSelectLinkAccTarazSetting_Result>((IEnumerable<ApispSelectLinkAccTarazSetting_Result>)list2, (Func<ApispSelectLinkAccTarazSetting_Result, bool>)((ApispSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 3));
											if (apispSelectLinkAccTarazSetting_Result3 != null)
											{
												text4 = apispSelectLinkAccTarazSetting_Result3.PartValue ?? "";
											}
											ApispSelectLinkAccTarazSetting_Result apispSelectLinkAccTarazSetting_Result4 = Enumerable.FirstOrDefault<ApispSelectLinkAccTarazSetting_Result>((IEnumerable<ApispSelectLinkAccTarazSetting_Result>)list2, (Func<ApispSelectLinkAccTarazSetting_Result, bool>)((ApispSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 6));
											if (apispSelectLinkAccTarazSetting_Result4 != null)
											{
												text2 = apispSelectLinkAccTarazSetting_Result4.PartValue ?? "";
											}
											if (!string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(text3) && !string.IsNullOrWhiteSpace(text4))
											{
												if (!text.EndsWith("/"))
												{
													text += "/";
												}
												if (string.IsNullOrWhiteSpace(text2))
												{
													TarazGetAuthViewModel tarazGetAuthViewModel = new TarazGetAuthViewModel();
													tarazGetAuthViewModel.username = text3;
													tarazGetAuthViewModel.password = text4;
													string text5 = "tws/authenticate";
													HttpClient httpClient = new HttpClient();
													httpClient.Timeout = OtherSystems.RestApiTimeout();
													httpClient.BaseAddress = new Uri(text + text5);
													httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
													string content = JsonConvert.SerializeObject(tarazGetAuthViewModel);
													HttpContent content2 = new StringContent(content, Encoding.UTF8, "application/json");
													HttpResponseMessage result2 = httpClient.PostAsync(text + text5, content2).Result;
													if (result2.IsSuccessStatusCode)
													{
														string result3 = result2.Content.ReadAsStringAsync().Result;
														TarazGetAuthResultViewModel tarazGetAuthResultViewModel = JsonConvert.DeserializeObject<TarazGetAuthResultViewModel>(result3);
														if (!string.IsNullOrWhiteSpace(tarazGetAuthResultViewModel.token))
														{
															text2 = ((!string.IsNullOrEmpty(tarazGetAuthResultViewModel.type)) ? (tarazGetAuthResultViewModel.type + " ") : "Bearer ") + tarazGetAuthResultViewModel.token;
															db.ApispUpdateLinkAccTarazSetting(6, text2);
														}
														else
														{
															string message4 = RS.Get("msgErrorRunFunction", rsCollation, RS.TypeMsg) + "  (authentication in tarazSamaneh) ";
															Exception e4 = new Exception(message4);
															ErrorSignal.FromCurrentContext().Raise(e4);
															result = RS.Get("frmError", rsCollation, RS.TypeLbl);
														}
													}
													else
													{
														string text6 = RS.Get("msgErrorRunFunction", rsCollation, RS.TypeMsg) + " (authentication in tarazSamaneh) ";
														string result4 = result2.Content.ReadAsStringAsync().Result;
														TarazExceptionViewModel tarazExceptionViewModel = JsonConvert.DeserializeObject<TarazExceptionViewModel>(result4);
														if (tarazExceptionViewModel != null)
														{
															string[] obj = new string[6]
															{
																text6,
																" [",
																tarazExceptionViewModel.error,
																(!string.IsNullOrEmpty(tarazExceptionViewModel.message)) ? (" -" + tarazExceptionViewModel.message) : "",
																null,
																null
															};
															_ = tarazExceptionViewModel.status;
															obj[4] = " code:" + tarazExceptionViewModel.status;
															obj[5] = "]";
															text6 = string.Concat(obj);
														}
														Exception e5 = new Exception(text6);
														ErrorSignal.FromCurrentContext().Raise(e5);
														result = RS.Get("frmError", rsCollation, RS.TypeLbl);
													}
												}
												if (string.IsNullOrWhiteSpace(text2))
												{
													string message5 = RS.Get("msgErrorRunFunction", rsCollation, RS.TypeMsg) + " (authentication in tarazSamaneh) ";
													Exception e6 = new Exception(message5);
													ErrorSignal.FromCurrentContext().Raise(e6);
													result = RS.Get("frmError", rsCollation, RS.TypeLbl);
												}
												string text7 = "";
												if (prdPriceGroupId == 0)
												{
													List<ApispSelectLinkAccTarazSetting_Result> list3 = Enumerable.ToList<ApispSelectLinkAccTarazSetting_Result>((IEnumerable<ApispSelectLinkAccTarazSetting_Result>)db.ApispSelectLinkAccTarazSetting(0, "PrdPriceGroup", currLangId, defLangId));
													string s = "";
													if (list3 != null)
													{
														ApispSelectLinkAccTarazSetting_Result apispSelectLinkAccTarazSetting_Result5 = Enumerable.FirstOrDefault<ApispSelectLinkAccTarazSetting_Result>((IEnumerable<ApispSelectLinkAccTarazSetting_Result>)list3, (Func<ApispSelectLinkAccTarazSetting_Result, bool>)((ApispSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 7));
														if (apispSelectLinkAccTarazSetting_Result5 != null)
														{
															s = apispSelectLinkAccTarazSetting_Result5.PartValue ?? "";
														}
													}
													int.TryParse(s, out prdPriceGroupId);
												}
												ApispSelectProductPriceGroupById_Result apispSelectProductPriceGroupById_Result = Enumerable.FirstOrDefault<ApispSelectProductPriceGroupById_Result>((IEnumerable<ApispSelectProductPriceGroupById_Result>)db.ApispSelectProductPriceGroupById(prdPriceGroupId, currLangId, defLangId));
												if (apispSelectProductPriceGroupById_Result != null)
												{
													text7 = apispSelectProductPriceGroupById_Result.LinkAccPrdPriceGroupIdStr ?? "";
												}
												if (string.IsNullOrEmpty(text7))
												{
													string message6 = RS.Get("ErrorNotFound", rsCollation, RS.TypeMsg) + "(Not found the product price group is not in Taraz";
													Exception e7 = new Exception(message6);
													ErrorSignal.FromCurrentContext().Raise(e7);
													result = RS.Get("frmError", rsCollation, RS.TypeLbl);
													return result;
												}
												if (!string.IsNullOrWhiteSpace(text2))
												{
													string text8 = DateTime.Now.ToString("yyyy/MM/dd", new PersianCulture());
													HttpClient httpClient2 = new HttpClient();
													httpClient2.Timeout = OtherSystems.RestApiTimeout();
													httpClient2.BaseAddress = new Uri(text);
													httpClient2.DefaultRequestHeaders.Add("Authorization", text2);
													httpClient2.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
													string text9 = "6001";
													List<ApispSelectLinkAccTarazSetting_Result> list4 = Enumerable.ToList<ApispSelectLinkAccTarazSetting_Result>((IEnumerable<ApispSelectLinkAccTarazSetting_Result>)db.ApispSelectLinkAccTarazSetting(0, "VoucherType", currLangId, defLangId));
													if (list4 != null)
													{
														string text10 = "";
														ApispSelectLinkAccTarazSetting_Result apispSelectLinkAccTarazSetting_Result6 = Enumerable.FirstOrDefault<ApispSelectLinkAccTarazSetting_Result>((IEnumerable<ApispSelectLinkAccTarazSetting_Result>)list4, (Func<ApispSelectLinkAccTarazSetting_Result, bool>)((ApispSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 10));
														if (apispSelectLinkAccTarazSetting_Result6 != null)
														{
															text10 = apispSelectLinkAccTarazSetting_Result6.PartValue ?? "";
														}
														if (!string.IsNullOrEmpty(text10))
														{
															text9 = text10;
														}
													}
													if (string.IsNullOrEmpty(text9))
													{
														text9 = "6001";
													}
													string requestUri = "tws/sale/goods?voucherDate=" + text8 + "&voucherTypeID=" + text9 + "&customerID=" + apispSelectCompanyById_Result.cmpLinkAccCustomerIdStr + "&goodsCode=" + apispSelectProductsWithId_Result.PrdLinkAccPrdCode + "&paymentWayID=" + text7 + "&storeID=" + apispSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhIdStr;
													HttpResponseMessage result5 = httpClient2.GetAsync(requestUri).Result;
													if (result5.IsSuccessStatusCode)
													{
														string result6 = result5.Content.ReadAsStringAsync().Result;
														List<TarazSaleGoodsViewModel> list5 = JsonConvert.DeserializeObject<List<TarazSaleGoodsViewModel>>(result6);
														if (list5 == null)
														{
															string message7 = RS.Get("msgErrorRunFunction", rsCollation, RS.TypeMsg) + " (not find prodcut information from Taraz or find more one than) ";
															Exception e8 = new Exception(message7);
															ErrorSignal.FromCurrentContext().Raise(e8);
															return RS.Get("frmError", rsCollation, RS.TypeLbl);
														}
														long prdLinkAccPrdIdStr = 0L;
														long.TryParse(apispSelectProductsWithId_Result.PrdLinkAccPrdIdStr, out prdLinkAccPrdIdStr);
														TarazSaleGoodsViewModel tarazSaleGoodsViewModel = Enumerable.FirstOrDefault<TarazSaleGoodsViewModel>((IEnumerable<TarazSaleGoodsViewModel>)list5, (Func<TarazSaleGoodsViewModel, bool>)((TarazSaleGoodsViewModel m) => m.goodsID == prdLinkAccPrdIdStr));
														if (tarazSaleGoodsViewModel == null)
														{
															string message8 = RS.Get("msgErrorRunFunction", rsCollation, RS.TypeMsg) + " (not find prodcut information from Taraz or find more one than) ";
															Exception e9 = new Exception(message8);
															ErrorSignal.FromCurrentContext().Raise(e9);
															return RS.Get("frmError", rsCollation, RS.TypeLbl);
														}
														prdPrice = tarazSaleGoodsViewModel.price.GetValueOrDefault();
														prdQuantity = tarazSaleGoodsViewModel.remain.GetValueOrDefault();
														if (prdPrice > 0m && prdPriceGroupId > 0 && prdId > 0)
														{
															DateTime now = DateTime.Now;
															DateTime value = now;
															string text11 = now.ToString("yyyyMMdd", new PersianCulture());
															short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
															string appType = CRMIdealApi.Classes.Configuration.AppType;
															decimal valueOrDefault = tarazSaleGoodsViewModel.goodsDiscountPercent.GetValueOrDefault();
															decimal valueOrDefault2 = tarazSaleGoodsViewModel.goodsDiscountPrice.GetValueOrDefault();
															ObjectParameter insertedPrdPriceId = new ObjectParameter("InsertedPrdPriceId", 0);
															ObjectParameter errorMessage = new ObjectParameter("ErrorMessage", "");
															ObjectResult<int?> objectResult = db.ApispInsertProductPrice("", "", text11, value, null, prdPrice, null, null, null, null, (valueOrDefault == 0m) ? null : new decimal?(valueOrDefault), (valueOrDefault2 == 0m) ? null : new decimal?(valueOrDefault2), null, null, null, prdPriceGroupId, prdId, null, userId, value2, value, text11, appType, defLangId, insertedPrdPriceId, errorMessage, centerId, centerCode, linkAccPrdPriceIdStr, linkAccFirstTransferDate, linkAccLastTransferDate, linkAccData);
															CRMIdealApi.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductPriceGroup");
															CRMIdealApi.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductPrice");
														}
														result = "";
													}
													else
													{
														string text12 = RS.Get("msgErrorRunFunction", rsCollation, RS.TypeMsg) + " (get list from tarazSamaneh) ";
														HttpStatusCode statusCode = result5.StatusCode;
														if (((object)(HttpStatusCode)(ref statusCode)).ToString() == "Unauthorized")
														{
															db.ApispUpdateLinkAccTarazSetting(6, "");
														}
														string result7 = result5.Content.ReadAsStringAsync().Result;
														TarazExceptionViewModel tarazExceptionViewModel2 = JsonConvert.DeserializeObject<TarazExceptionViewModel>(result7);
														if (tarazExceptionViewModel2 != null)
														{
															_ = tarazExceptionViewModel2.status;
															if (tarazExceptionViewModel2.status == 401)
															{
																db.ApispUpdateLinkAccTarazSetting(6, "");
															}
															string[] obj2 = new string[6]
															{
																text12,
																" [",
																tarazExceptionViewModel2.error,
																(!string.IsNullOrEmpty(tarazExceptionViewModel2.message)) ? (" -" + tarazExceptionViewModel2.message) : "",
																null,
																null
															};
															_ = tarazExceptionViewModel2.status;
															obj2[4] = " code:" + tarazExceptionViewModel2.status;
															obj2[5] = "]";
															text12 = string.Concat(obj2);
														}
														Exception e10 = new Exception(text12);
														ErrorSignal.FromCurrentContext().Raise(e10);
														result = RS.Get("frmError", rsCollation, RS.TypeLbl);
													}
												}
											}
											else
											{
												string message9 = RS.Get("errorInReadingSetting", rsCollation, RS.TypeMsg) + " (tarazSamaneh) ";
												Exception e11 = new Exception(message9);
												ErrorSignal.FromCurrentContext().Raise(e11);
												result = RS.Get("frmError", rsCollation, RS.TypeLbl);
											}
										}
										else
										{
											string message10 = RS.Get("errorInReadingSetting", rsCollation, RS.TypeMsg) + " (tarazSamaneh) ";
											Exception e12 = new Exception(message10);
											ErrorSignal.FromCurrentContext().Raise(e12);
											result = RS.Get("frmError", rsCollation, RS.TypeLbl);
										}
									}
									else
									{
										string message11 = RS.Get("ErrorNotFound", rsCollation, RS.TypeMsg) + "(This company by name " + apispSelectCompanyById_Result.CompanyName + " is not in Taraz";
										Exception e13 = new Exception(message11);
										ErrorSignal.FromCurrentContext().Raise(e13);
										result = RS.Get("frmError", rsCollation, RS.TypeLbl);
									}
								}
								else
								{
									string message12 = RS.Get("ErrorNotFound", rsCollation, RS.TypeMsg) + "(This product by name " + apispSelectProductsWithId_Result.PrdName + " not have code";
									Exception e14 = new Exception(message12);
									ErrorSignal.FromCurrentContext().Raise(e14);
									result = RS.Get("frmError", rsCollation, RS.TypeLbl);
								}
							}
							else
							{
								string message13 = RS.Get("ErrorNotFound", rsCollation, RS.TypeMsg) + "(This warehouse by name " + apispSelectWareHouseWithAccLinkField_Result.WrhsName + " not have code";
								Exception e15 = new Exception(message13);
								ErrorSignal.FromCurrentContext().Raise(e15);
								result = RS.Get("frmError", rsCollation, RS.TypeLbl);
							}
						}
						else
						{
							string message14 = RS.Get("ErrorNotFound", rsCollation, RS.TypeMsg) + "(warehouse)";
							Exception e16 = new Exception(message14);
							ErrorSignal.FromCurrentContext().Raise(e16);
							result = RS.Get("frmError", rsCollation, RS.TypeLbl);
						}
					}
					else
					{
						string message15 = RS.Get("ErrorNotFound", rsCollation, RS.TypeMsg) + "(company)";
						Exception e17 = new Exception(message15);
						ErrorSignal.FromCurrentContext().Raise(e17);
						result = RS.Get("frmError", rsCollation, RS.TypeLbl);
					}
				}
				else
				{
					string message16 = RS.Get("ErrorNotFound", rsCollation, RS.TypeMsg) + "(product)";
					Exception e18 = new Exception(message16);
					ErrorSignal.FromCurrentContext().Raise(e18);
					result = RS.Get("frmError", rsCollation, RS.TypeLbl);
				}
			}
		}
		catch (Exception e19)
		{
			ErrorSignal.FromCurrentContext().Raise(e19);
		}
		return result;
	}

	public string HolooGetPrdQuantity_Old(int prdId, int currLangID, int defLangID)
	{
		string result = "";
		string rsCollation = "";
		try
		{
			if (prdId <= 0)
			{
				string message = RS.Get("msgErrorRunFunction", rsCollation, RS.TypeMsg) + "(product)";
				Exception e = new Exception(message);
				ErrorSignal.FromCurrentContext().Raise(e);
				return RS.Get("frmError", rsCollation, RS.TypeLbl);
			}
			ApispSelectProductsWithId_Result apispSelectProductsWithId_Result = Enumerable.FirstOrDefault<ApispSelectProductsWithId_Result>((IEnumerable<ApispSelectProductsWithId_Result>)db.ApispSelectProductsWithId(prdId, currLangID, defLangID));
			if (apispSelectProductsWithId_Result == null)
			{
				string message2 = RS.Get("msgErrorRunFunction", rsCollation, RS.TypeMsg) + "(product)";
				Exception e2 = new Exception(message2);
				ErrorSignal.FromCurrentContext().Raise(e2);
				return RS.Get("frmError", rsCollation, RS.TypeLbl);
			}
			if (string.IsNullOrEmpty(apispSelectProductsWithId_Result.PrdLinkAccPrdCode))
			{
				string message3 = RS.Get("msgErrorRunFunction", rsCollation, RS.TypeMsg) + "(This product by name " + apispSelectProductsWithId_Result.PrdName + " not have code";
				Exception e3 = new Exception(message3);
				ErrorSignal.FromCurrentContext().Raise(e3);
				return RS.Get("frmError", rsCollation, RS.TypeLbl);
			}
			List<ApispSelectLinkAccHolooSetting_Result> list = Enumerable.ToList<ApispSelectLinkAccHolooSetting_Result>((IEnumerable<ApispSelectLinkAccHolooSetting_Result>)db.ApispSelectLinkAccHolooSetting(0, "Setting", currLangID, defLangID));
			if (list == null)
			{
				string message4 = RS.Get("msgErrorRunFunction", rsCollation, RS.TypeMsg);
				Exception e4 = new Exception(message4);
				ErrorSignal.FromCurrentContext().Raise(e4);
				return RS.Get("frmError", rsCollation, RS.TypeLbl);
			}
			string text = "";
			ApispSelectLinkAccHolooSetting_Result apispSelectLinkAccHolooSetting_Result = Enumerable.FirstOrDefault<ApispSelectLinkAccHolooSetting_Result>((IEnumerable<ApispSelectLinkAccHolooSetting_Result>)list, (Func<ApispSelectLinkAccHolooSetting_Result, bool>)((ApispSelectLinkAccHolooSetting_Result m) => m.LinkAccHolooSettingId == 1));
			if (apispSelectLinkAccHolooSetting_Result != null)
			{
				text = apispSelectLinkAccHolooSetting_Result.PartValue ?? "";
			}
			string text2 = "";
			ApispSelectLinkAccHolooSetting_Result apispSelectLinkAccHolooSetting_Result2 = Enumerable.FirstOrDefault<ApispSelectLinkAccHolooSetting_Result>((IEnumerable<ApispSelectLinkAccHolooSetting_Result>)list, (Func<ApispSelectLinkAccHolooSetting_Result, bool>)((ApispSelectLinkAccHolooSetting_Result m) => m.LinkAccHolooSettingId == 2));
			if (apispSelectLinkAccHolooSetting_Result2 != null)
			{
				text2 = apispSelectLinkAccHolooSetting_Result2.PartValue ?? "";
			}
			string text3 = "";
			ApispSelectLinkAccHolooSetting_Result apispSelectLinkAccHolooSetting_Result3 = Enumerable.FirstOrDefault<ApispSelectLinkAccHolooSetting_Result>((IEnumerable<ApispSelectLinkAccHolooSetting_Result>)list, (Func<ApispSelectLinkAccHolooSetting_Result, bool>)((ApispSelectLinkAccHolooSetting_Result m) => m.LinkAccHolooSettingId == 3));
			if (apispSelectLinkAccHolooSetting_Result3 != null)
			{
				text3 = apispSelectLinkAccHolooSetting_Result3.PartValue ?? "";
			}
			string text4 = "";
			ApispSelectLinkAccHolooSetting_Result apispSelectLinkAccHolooSetting_Result4 = Enumerable.FirstOrDefault<ApispSelectLinkAccHolooSetting_Result>((IEnumerable<ApispSelectLinkAccHolooSetting_Result>)list, (Func<ApispSelectLinkAccHolooSetting_Result, bool>)((ApispSelectLinkAccHolooSetting_Result m) => m.LinkAccHolooSettingId == 4));
			if (apispSelectLinkAccHolooSetting_Result4 != null)
			{
				text4 = apispSelectLinkAccHolooSetting_Result4.PartValue ?? "";
			}
			string s = "";
			ApispSelectLinkAccHolooSetting_Result apispSelectLinkAccHolooSetting_Result5 = Enumerable.FirstOrDefault<ApispSelectLinkAccHolooSetting_Result>((IEnumerable<ApispSelectLinkAccHolooSetting_Result>)list, (Func<ApispSelectLinkAccHolooSetting_Result, bool>)((ApispSelectLinkAccHolooSetting_Result m) => m.LinkAccHolooSettingId == 6));
			if (apispSelectLinkAccHolooSetting_Result5 != null)
			{
				s = apispSelectLinkAccHolooSetting_Result5.PartValue ?? "";
			}
			string text5 = "";
			if (string.IsNullOrWhiteSpace(text) || string.IsNullOrWhiteSpace(text2) || string.IsNullOrWhiteSpace(text3) || string.IsNullOrWhiteSpace(text4))
			{
				string message5 = RS.Get("msgErrorRunFunction", rsCollation, RS.TypeMsg);
				Exception e5 = new Exception(message5);
				ErrorSignal.FromCurrentContext().Raise(e5);
				return RS.Get("frmError", rsCollation, RS.TypeLbl);
			}
			if (!text.EndsWith("/"))
			{
				text += "/";
			}
			HolooLoginViewModel holooLoginViewModel = new HolooLoginViewModel();
			holooLoginViewModel.userinfo = new HolooUserInfoViewModel
			{
				dbname = text2,
				username = text3,
				userpass = text4
			};
			string text6 = "api/Login";
			HttpClient httpClient = new HttpClient();
			int num = 20;
			httpClient.Timeout = OtherSystems.RestApiTimeout();
			httpClient.BaseAddress = new Uri(text + text6);
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			string content = JsonConvert.SerializeObject(holooLoginViewModel);
			HttpContent content2 = new StringContent(content, Encoding.UTF8, "application/json");
			HttpResponseMessage result2 = httpClient.PostAsync(text + text6, content2).Result;
			if (!result2.IsSuccessStatusCode)
			{
				string message6 = RS.Get("msgErrorRunFunction", rsCollation, RS.TypeMsg) + "<br> Error in login";
				Exception e6 = new Exception(message6);
				ErrorSignal.FromCurrentContext().Raise(e6);
				return RS.Get("frmError", rsCollation, RS.TypeLbl);
			}
			string result3 = result2.Content.ReadAsStringAsync().Result;
			HolooLoginResultViewModel holooLoginResultViewModel = JsonConvert.DeserializeObject<HolooLoginResultViewModel>(result3);
			if (holooLoginResultViewModel == null)
			{
				string message7 = RS.Get("msgErrorRunFunction", rsCollation, RS.TypeMsg) + "<br> Error in login";
				Exception e7 = new Exception(message7);
				ErrorSignal.FromCurrentContext().Raise(e7);
				return RS.Get("frmError", rsCollation, RS.TypeLbl);
			}
			if (holooLoginResultViewModel.Login == null)
			{
				string message8 = RS.Get("msgErrorRunFunction", rsCollation, RS.TypeMsg) + "<br> Error in login";
				Exception e8 = new Exception(message8);
				ErrorSignal.FromCurrentContext().Raise(e8);
				return RS.Get("frmError", rsCollation, RS.TypeLbl);
			}
			if (!holooLoginResultViewModel.Login.State)
			{
				string text7 = RS.Get("msgErrorRunFunction", rsCollation, RS.TypeMsg);
				string error = holooLoginResultViewModel.Login.Error;
				_ = holooLoginResultViewModel.Login.ErrorCode;
				string message9 = string.Concat(text7, "<br>", error, " code:" + holooLoginResultViewModel.Login.ErrorCode);
				Exception e9 = new Exception(message9);
				ErrorSignal.FromCurrentContext().Raise(e9);
				return RS.Get("frmError", rsCollation, RS.TypeLbl);
			}
			text5 = holooLoginResultViewModel.Login.Token ?? "";
			if (string.IsNullOrWhiteSpace(text5))
			{
				string message10 = RS.Get("msgErrorRunFunction", rsCollation, RS.TypeMsg) + "<br> Token is null";
				Exception e10 = new Exception(message10);
				ErrorSignal.FromCurrentContext().Raise(e10);
				return RS.Get("frmError", rsCollation, RS.TypeLbl);
			}
			if (!string.IsNullOrWhiteSpace(text5))
			{
				string text8 = "?code=" + apispSelectProductsWithId_Result.PrdLinkAccPrdCode;
				if (!string.IsNullOrWhiteSpace(apispSelectProductsWithId_Result.FGLinkAccGroupIdStr))
				{
					text8 = text8 + "&maingrouperpcode=" + apispSelectProductsWithId_Result.FGLinkAccGroupIdStr;
				}
				if (!string.IsNullOrWhiteSpace(apispSelectProductsWithId_Result.SGLinkAccGroupIdStr))
				{
					text8 = text8 + "&sidegrouperpcode=" + apispSelectProductsWithId_Result.SGLinkAccGroupIdStr;
				}
				HttpClient httpClient2 = new HttpClient();
				httpClient2.Timeout = OtherSystems.RestApiTimeout();
				httpClient2.BaseAddress = new Uri(text);
				httpClient2.DefaultRequestHeaders.Add("Authorization", text5);
				httpClient2.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				string requestUri = "api/Product" + text8;
				HttpResponseMessage result4 = httpClient2.GetAsync(requestUri).Result;
				if (!result4.IsSuccessStatusCode)
				{
					string message11 = RS.Get("msgErrorRunFunction", rsCollation, RS.TypeMsg) + " (get product information from Holoo) ";
					Exception e11 = new Exception(message11);
					ErrorSignal.FromCurrentContext().Raise(e11);
					return RS.Get("frmError", rsCollation, RS.TypeLbl);
				}
				string result5 = result4.Content.ReadAsStringAsync().Result;
				HolooProductListViewModel holooProductListViewModel = JsonConvert.DeserializeObject<HolooProductListViewModel>(result5);
				if (holooProductListViewModel == null)
				{
					string message12 = RS.Get("msgErrorRunFunction", rsCollation, RS.TypeMsg) + " (get product information from Holoo) ";
					Exception e12 = new Exception(message12);
					ErrorSignal.FromCurrentContext().Raise(e12);
					return RS.Get("frmError", rsCollation, RS.TypeLbl);
				}
				if (holooProductListViewModel.product != null)
				{
					if (holooProductListViewModel.product.Count != 1)
					{
						string message13 = RS.Get("msgErrorRunFunction", rsCollation, RS.TypeMsg) + " (not find prodcut information from Holoo or find more one than) ";
						Exception e13 = new Exception(message13);
						ErrorSignal.FromCurrentContext().Raise(e13);
						return RS.Get("frmError", rsCollation, RS.TypeLbl);
					}
					double valueOrDefault = holooProductListViewModel.product[0].Few.GetValueOrDefault();
					double valueOrDefault2 = holooProductListViewModel.product[0].fewspd.GetValueOrDefault();
					int result6 = 0;
					int.TryParse(s, out result6);
					result = ((result6 != 1) ? valueOrDefault.ToString() : valueOrDefault2.ToString());
				}
			}
		}
		catch (Exception e14)
		{
			ErrorSignal.FromCurrentContext().Raise(e14);
			result = RS.Get("frmError", rsCollation, RS.TypeLbl);
		}
		return result;
	}

	public string HolooGetPrdQuantity(int prdId, int currLangID, int defLangID, int linkAccSettingDBId = 0)
	{
		string result = "";
		string text = "";
		try
		{
			if (prdId <= 0)
			{
				string message = RS.Get("msgErrorRunFunction", text, RS.TypeMsg) + "(product)";
				Exception e = new Exception(message);
				ErrorSignal.FromCurrentContext().Raise(e);
				return RS.Get("frmError", text, RS.TypeLbl);
			}
			ApispSelectProductsWithId_Result apispSelectProductsWithId_Result = Enumerable.FirstOrDefault<ApispSelectProductsWithId_Result>((IEnumerable<ApispSelectProductsWithId_Result>)db.ApispSelectProductsWithId(prdId, currLangID, defLangID));
			if (apispSelectProductsWithId_Result == null)
			{
				string message2 = RS.Get("msgErrorRunFunction", text, RS.TypeMsg) + "(product)";
				Exception e2 = new Exception(message2);
				ErrorSignal.FromCurrentContext().Raise(e2);
				return RS.Get("frmError", text, RS.TypeLbl);
			}
			if (string.IsNullOrEmpty(apispSelectProductsWithId_Result.PrdLinkAccPrdCode))
			{
				string message3 = RS.Get("msgErrorRunFunction", text, RS.TypeMsg) + "(This product by name " + apispSelectProductsWithId_Result.PrdName + " not have code";
				Exception e3 = new Exception(message3);
				ErrorSignal.FromCurrentContext().Raise(e3);
				return RS.Get("frmError", text, RS.TypeLbl);
			}
			if (linkAccSettingDBId == 0)
			{
				string prdLinkAccPrdCode = apispSelectProductsWithId_Result.PrdLinkAccPrdCode;
				List<PrdLinkAccCodeViewModel> list = ((!string.IsNullOrEmpty(prdLinkAccPrdCode)) ? JsonConvert.DeserializeObject<List<PrdLinkAccCodeViewModel>>(prdLinkAccPrdCode) : new List<PrdLinkAccCodeViewModel>());
				PrdLinkAccCodeViewModel prdLinkAccCodeViewModel = Enumerable.FirstOrDefault<PrdLinkAccCodeViewModel>((IEnumerable<PrdLinkAccCodeViewModel>)list, (Func<PrdLinkAccCodeViewModel, bool>)((PrdLinkAccCodeViewModel x) => x.DBId.HasValue && x.DBId != 0));
				if (prdLinkAccCodeViewModel != null)
				{
					linkAccSettingDBId = prdLinkAccCodeViewModel.DBId.Value;
				}
			}
			OtherSystems.HolooProvider holooProvider = new OtherSystems.HolooProvider(linkAccSettingDBId);
			string text2 = holooProvider.Authenticate();
			if (!string.IsNullOrEmpty(text2))
			{
				return text2;
			}
			string errorMessage = "";
			holooProvider.GetPrdQuantity(apispSelectProductsWithId_Result, text, ref result, ref errorMessage);
			if (!string.IsNullOrEmpty(errorMessage))
			{
				result = errorMessage;
			}
		}
		catch (Exception e4)
		{
			ErrorSignal.FromCurrentContext().Raise(e4);
			result = RS.Get("frmError", text, RS.TypeLbl);
		}
		return result;
	}

	public string ShomaranGetPrdQuantity(int prdId, int whId, string linkAccWhId = "", string tracing = "", string sefaresh = "", int currLangID = 0, int defLangID = 0)
	{
		string text = "";
		string rsCollation = "fa-IR";
		try
		{
			if (prdId > 0)
			{
				ApispSelectProductsWithId_Result apispSelectProductsWithId_Result = Enumerable.FirstOrDefault<ApispSelectProductsWithId_Result>((IEnumerable<ApispSelectProductsWithId_Result>)db.ApispSelectProductsWithId(prdId, currLangID, defLangID));
				if (apispSelectProductsWithId_Result == null)
				{
					string message = RS.Get("ErrorNotFound", rsCollation, RS.TypeMsg) + "(product)";
					Exception e = new Exception(message);
					ErrorSignal.FromCurrentContext().Raise(e);
					text = RS.Get("frmError", rsCollation, RS.TypeLbl);
				}
				if (apispSelectProductsWithId_Result != null && !string.IsNullOrWhiteSpace(apispSelectProductsWithId_Result.PrdLinkAccPrdCode))
				{
					ApispSelectWareHouseWithAccLinkField_Result apispSelectWareHouseWithAccLinkField_Result = new ApispSelectWareHouseWithAccLinkField_Result();
					List<ApispSelectWareHouseWithAccLinkField_Result> list = Enumerable.ToList<ApispSelectWareHouseWithAccLinkField_Result>((IEnumerable<ApispSelectWareHouseWithAccLinkField_Result>)db.ApispSelectWareHouseWithAccLinkField(false, false, false, true, currLangID, defLangID));
					if (list != null)
					{
						apispSelectWareHouseWithAccLinkField_Result = Enumerable.FirstOrDefault<ApispSelectWareHouseWithAccLinkField_Result>((IEnumerable<ApispSelectWareHouseWithAccLinkField_Result>)list, (Func<ApispSelectWareHouseWithAccLinkField_Result, bool>)((ApispSelectWareHouseWithAccLinkField_Result m) => m.WareHouseID == whId));
					}
					if (apispSelectWareHouseWithAccLinkField_Result != null)
					{
						if (string.IsNullOrWhiteSpace(apispSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses))
						{
							string message2 = RS.Get("ErrorNotFound", rsCollation, RS.TypeMsg) + "(warehouse in Shomaran)";
							Exception e2 = new Exception(message2);
							ErrorSignal.FromCurrentContext().Raise(e2);
							return RS.Get("frmError", rsCollation, RS.TypeLbl);
						}
						List<ApispLkShomaranReturnProductQuantity_Result> list2 = Enumerable.ToList<ApispLkShomaranReturnProductQuantity_Result>((IEnumerable<ApispLkShomaranReturnProductQuantity_Result>)db.ApispLkShomaranReturnProductQuantity(prdId, whId, linkAccWhId, tracing, sefaresh, currLangID, defLangID));
						decimal num = default(decimal);
						if (list2 != null && Enumerable.Any<ApispLkShomaranReturnProductQuantity_Result>((IEnumerable<ApispLkShomaranReturnProductQuantity_Result>)list2))
						{
							foreach (ApispLkShomaranReturnProductQuantity_Result item in list2)
							{
								num += item.sumaount.GetValueOrDefault();
							}
						}
						return num.ToString();
					}
					string message3 = RS.Get("ErrorNotFound", rsCollation, RS.TypeMsg) + "(warehouse)";
					Exception e3 = new Exception(message3);
					ErrorSignal.FromCurrentContext().Raise(e3);
					return RS.Get("frmError", rsCollation, RS.TypeLbl);
				}
				string message4 = RS.Get("ErrorNotFound", rsCollation, RS.TypeMsg) + "(product)";
				Exception e4 = new Exception(message4);
				ErrorSignal.FromCurrentContext().Raise(e4);
				return RS.Get("frmError", rsCollation, RS.TypeLbl);
			}
			string message5 = RS.Get("ErrorNotFound", rsCollation, RS.TypeMsg) + "(product)";
			Exception e5 = new Exception(message5);
			ErrorSignal.FromCurrentContext().Raise(e5);
			return RS.Get("frmError", rsCollation, RS.TypeLbl);
		}
		catch (Exception e6)
		{
			ErrorSignal.FromCurrentContext().Raise(e6);
			return RS.Get("frmError", rsCollation, RS.TypeLbl);
		}
	}

	public string Arpa_GetToken()
	{
		string text = "";
		try
		{
			OtherSystems.ArpaSettingViewModel arpaSetting = OtherSystems.GetArpaSetting();
			if (arpaSetting != null)
			{
				string text2 = arpaSetting.ArpaServerAddress ?? "";
				string text3 = arpaSetting.ArpaUserName ?? "";
				string text4 = arpaSetting.ArpaPassword ?? "";
				if (!string.IsNullOrWhiteSpace(text2) && !text2.EndsWith("serv/"))
				{
					text2 += "serv/";
				}
				if (!string.IsNullOrWhiteSpace(text2) && !string.IsNullOrWhiteSpace(text3) && !string.IsNullOrWhiteSpace(text4))
				{
					HttpClient httpClient = new HttpClient();
					string text5 = string.Format(text2 + "token/GetServiceToken?username={0}&password={1}", text3, text4);
					httpClient.BaseAddress = new Uri(text5);
					httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
					string content = "";
					HttpContent content2 = new StringContent(content, Encoding.UTF8, "application/json");
					HttpResponseMessage result = httpClient.PostAsync(text5, content2).Result;
					if (result.IsSuccessStatusCode)
					{
						string result2 = result.Content.ReadAsStringAsync().Result;
						string text6 = result2;
						if (!string.IsNullOrWhiteSpace(text6))
						{
							text = text6 ?? "";
							if (!string.IsNullOrWhiteSpace(text))
							{
								text = "Bearer " + text;
							}
						}
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			text = "";
		}
		return text;
	}

	public string ArpaGetPrdQuantity(int prdId, int whId, string linkAccWhId = "", int currLangID = 0, int defLangID = 0)
	{
		string result = "";
		string rsCollation = "fa-IR";
		try
		{
			if (prdId > 0)
			{
				ApispSelectProductsWithId_Result apispSelectProductsWithId_Result = Enumerable.FirstOrDefault<ApispSelectProductsWithId_Result>((IEnumerable<ApispSelectProductsWithId_Result>)db.ApispSelectProductsWithId(prdId, currLangID, defLangID));
				if (apispSelectProductsWithId_Result == null)
				{
					string message = RS.Get("ErrorNotFound", rsCollation, RS.TypeMsg) + "(product)";
					Exception e = new Exception(message);
					ErrorSignal.FromCurrentContext().Raise(e);
					result = RS.Get("frmError", rsCollation, RS.TypeLbl);
				}
				if (apispSelectProductsWithId_Result != null && !string.IsNullOrWhiteSpace(apispSelectProductsWithId_Result.PrdLinkAccPrdCode))
				{
					ApispSelectWareHouseWithAccLinkField_Result apispSelectWareHouseWithAccLinkField_Result = new ApispSelectWareHouseWithAccLinkField_Result();
					List<ApispSelectWareHouseWithAccLinkField_Result> list = Enumerable.ToList<ApispSelectWareHouseWithAccLinkField_Result>((IEnumerable<ApispSelectWareHouseWithAccLinkField_Result>)db.ApispSelectWareHouseWithAccLinkField(false, false, false, true, currLangID, defLangID));
					if (list != null)
					{
						apispSelectWareHouseWithAccLinkField_Result = Enumerable.FirstOrDefault<ApispSelectWareHouseWithAccLinkField_Result>((IEnumerable<ApispSelectWareHouseWithAccLinkField_Result>)list, (Func<ApispSelectWareHouseWithAccLinkField_Result, bool>)((ApispSelectWareHouseWithAccLinkField_Result m) => m.WareHouseID == whId));
					}
					if (apispSelectWareHouseWithAccLinkField_Result != null)
					{
						if (string.IsNullOrWhiteSpace(apispSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses))
						{
							string message2 = RS.Get("ErrorNotFound", rsCollation, RS.TypeMsg) + "(warehouse in Arpa)";
							Exception e2 = new Exception(message2);
							ErrorSignal.FromCurrentContext().Raise(e2);
							result = RS.Get("frmError", rsCollation, RS.TypeLbl);
						}
						else
						{
							List<CommonWithIdStrViewModel> list2 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(apispSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses);
							string linkWhId = "";
							if (list2 != null && Enumerable.Any<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list2))
							{
								CommonWithIdStrViewModel commonWithIdStrViewModel = Enumerable.FirstOrDefault<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list2, (Func<CommonWithIdStrViewModel, bool>)((CommonWithIdStrViewModel m) => m.Id == linkAccWhId));
								if (commonWithIdStrViewModel != null)
								{
									linkWhId = commonWithIdStrViewModel.Id;
								}
							}
							if (string.IsNullOrWhiteSpace(linkWhId) && !string.IsNullOrWhiteSpace(apispSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhIdStr))
							{
								linkWhId = apispSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhIdStr;
							}
							if (!string.IsNullOrWhiteSpace(linkWhId))
							{
								string value = Arpa_GetToken();
								if (!string.IsNullOrWhiteSpace(value))
								{
									OtherSystems.ArpaSettingViewModel arpaSetting = OtherSystems.GetArpaSetting();
									if (arpaSetting != null)
									{
										string text = arpaSetting.ArpaServerAddress ?? "";
										string text2 = arpaSetting.DefUserGroupId;
										if (string.IsNullOrWhiteSpace(text2))
										{
											text2 = "0";
										}
										if (!string.IsNullOrWhiteSpace(text) && !text.EndsWith("serv/"))
										{
											text += "serv/";
										}
										if (!string.IsNullOrWhiteSpace(text))
										{
											string text3 = "?ItemCode=" + apispSelectProductsWithId_Result.PrdLinkAccPrdCode;
											if (!string.IsNullOrWhiteSpace(text2))
											{
												text3 = (string.IsNullOrWhiteSpace(text3) ? "?" : (text3 + "&"));
												text3 = text3 + "UserGroupID=" + text2;
											}
											HttpClient httpClient = new HttpClient();
											string text4 = text + "api/GetStockByDetails" + text3;
											httpClient.BaseAddress = new Uri(text4);
											httpClient.DefaultRequestHeaders.Add("Authorization", value);
											httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
											string content = "";
											HttpContent content2 = new StringContent(content, Encoding.UTF8, "application/json");
											HttpResponseMessage result2 = httpClient.PostAsync(text4, content2).Result;
											if (result2.IsSuccessStatusCode)
											{
												string value2 = result2.Content.ReadAsStringAsync().Result;
												if (!string.IsNullOrWhiteSpace(value2))
												{
													value2 = value2.ClearHiddenCharacters();
												}
												ArpaProductQuantityResponseViewModel arpaProductQuantityResponseViewModel = JsonConvert.DeserializeObject<ArpaProductQuantityResponseViewModel>(value2);
												if (arpaProductQuantityResponseViewModel != null && arpaProductQuantityResponseViewModel.data != null && Enumerable.Any<ArpaProductQuantityInfoViewModel>((IEnumerable<ArpaProductQuantityInfoViewModel>)arpaProductQuantityResponseViewModel.data))
												{
													ArpaProductQuantityInfoViewModel arpaProductQuantityInfoViewModel = Enumerable.FirstOrDefault<ArpaProductQuantityInfoViewModel>((IEnumerable<ArpaProductQuantityInfoViewModel>)arpaProductQuantityResponseViewModel.data, (Func<ArpaProductQuantityInfoViewModel, bool>)((ArpaProductQuantityInfoViewModel m) => m.StockAreaID == linkWhId));
													decimal num = default(decimal);
													if (arpaProductQuantityInfoViewModel != null)
													{
														num = arpaProductQuantityInfoViewModel.Qty.GetValueOrDefault();
													}
													result = num.ToString();
												}
											}
										}
									}
								}
							}
							else
							{
								string message3 = RS.Get("ErrorNotFound", rsCollation, RS.TypeMsg) + "(warehouse)";
								Exception e3 = new Exception(message3);
								ErrorSignal.FromCurrentContext().Raise(e3);
								result = RS.Get("frmError", rsCollation, RS.TypeLbl);
							}
						}
					}
					else
					{
						string message4 = RS.Get("ErrorNotFound", rsCollation, RS.TypeMsg) + "(warehouse)";
						Exception e4 = new Exception(message4);
						ErrorSignal.FromCurrentContext().Raise(e4);
						result = RS.Get("frmError", rsCollation, RS.TypeLbl);
					}
				}
				else
				{
					string message5 = RS.Get("ErrorNotFound", rsCollation, RS.TypeMsg) + "(product)";
					Exception e5 = new Exception(message5);
					ErrorSignal.FromCurrentContext().Raise(e5);
					result = RS.Get("frmError", rsCollation, RS.TypeLbl);
				}
			}
			else
			{
				string message6 = RS.Get("ErrorNotFound", rsCollation, RS.TypeMsg) + "(product)";
				Exception e6 = new Exception(message6);
				ErrorSignal.FromCurrentContext().Raise(e6);
				result = RS.Get("frmError", rsCollation, RS.TypeLbl);
			}
		}
		catch (Exception e7)
		{
			ErrorSignal.FromCurrentContext().Raise(e7);
			result = RS.Get("frmError", rsCollation, RS.TypeLbl);
		}
		return result;
	}

	public string ShygunGetPrdQuantity(int prdId, int whId, string linkAccWhId = "", int currLangID = 0, int defLangID = 0)
	{
		string result = "";
		string rsCollation = "fa-IR";
		try
		{
			if (prdId > 0)
			{
				ApispSelectProductsWithId_Result apispSelectProductsWithId_Result = Enumerable.FirstOrDefault<ApispSelectProductsWithId_Result>((IEnumerable<ApispSelectProductsWithId_Result>)db.ApispSelectProductsWithId(prdId, currLangID, defLangID));
				if (apispSelectProductsWithId_Result == null)
				{
					string message = RS.Get("ErrorNotFound", rsCollation, RS.TypeMsg) + "(product)";
					Exception e = new Exception(message);
					ErrorSignal.FromCurrentContext().Raise(e);
					result = RS.Get("frmError", rsCollation, RS.TypeLbl);
				}
				if (apispSelectProductsWithId_Result != null && !string.IsNullOrWhiteSpace(apispSelectProductsWithId_Result.PrdLinkAccPrdCode))
				{
					ApispSelectWareHouseWithAccLinkField_Result apispSelectWareHouseWithAccLinkField_Result = new ApispSelectWareHouseWithAccLinkField_Result();
					List<ApispSelectWareHouseWithAccLinkField_Result> list = Enumerable.ToList<ApispSelectWareHouseWithAccLinkField_Result>((IEnumerable<ApispSelectWareHouseWithAccLinkField_Result>)db.ApispSelectWareHouseWithAccLinkField(false, false, false, true, currLangID, defLangID));
					if (list != null)
					{
						apispSelectWareHouseWithAccLinkField_Result = Enumerable.FirstOrDefault<ApispSelectWareHouseWithAccLinkField_Result>((IEnumerable<ApispSelectWareHouseWithAccLinkField_Result>)list, (Func<ApispSelectWareHouseWithAccLinkField_Result, bool>)((ApispSelectWareHouseWithAccLinkField_Result m) => m.WareHouseID == whId));
					}
					if (apispSelectWareHouseWithAccLinkField_Result != null)
					{
						if (string.IsNullOrWhiteSpace(apispSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses))
						{
							string message2 = RS.Get("ErrorNotFound", rsCollation, RS.TypeMsg) + "(warehouse in Shygun)";
							Exception e2 = new Exception(message2);
							ErrorSignal.FromCurrentContext().Raise(e2);
							result = RS.Get("frmError", rsCollation, RS.TypeLbl);
						}
						else
						{
							List<CommonWithIdStrViewModel> list2 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(apispSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses);
							string value = "";
							if (list2 != null && Enumerable.Any<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list2))
							{
								CommonWithIdStrViewModel commonWithIdStrViewModel = Enumerable.FirstOrDefault<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list2, (Func<CommonWithIdStrViewModel, bool>)((CommonWithIdStrViewModel m) => m.Id == linkAccWhId));
								if (commonWithIdStrViewModel != null)
								{
									value = commonWithIdStrViewModel.Id;
								}
							}
							if (string.IsNullOrWhiteSpace(value) && !string.IsNullOrWhiteSpace(apispSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhIdStr))
							{
								value = apispSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhIdStr;
							}
							if (!string.IsNullOrWhiteSpace(value))
							{
								OtherSystems.ShygunSettingViewModel shygunSetting = OtherSystems.GetShygunSetting();
								if (shygunSetting != null)
								{
									OtherSystems.ShygunDomainItemRemain shygunDomainItemRemain = new OtherSystems.ShygunDomainItemRemain();
									shygunDomainItemRemain.ItemGuID.In = new string[1];
									shygunDomainItemRemain.ItemGuID.In[0] = apispSelectProductsWithId_Result.PrdLinkAccPrdIdStr;
									shygunDomainItemRemain.StockGuID.In = new string[1];
									shygunDomainItemRemain.StockGuID.In[0] = value;
									string text = shygunSetting.IP;
									if (string.IsNullOrWhiteSpace(text))
									{
										string errorInReadingSetting = Messages.errorInReadingSetting;
										Exception e3 = new Exception(errorInReadingSetting);
										ErrorSignal.FromCurrentContext().Raise(e3);
									}
									if (!text.EndsWith("/"))
									{
										text += "/";
									}
									HttpClient httpClient = new HttpClient();
									httpClient.BaseAddress = new Uri(text);
									httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
									string requestUri = "api/Item/GetRemain";
									OtherSystems.ShygunApiParamViewModel<OtherSystems.ShygunDomainItemRemain> shygunApiParamViewModel = new OtherSystems.ShygunApiParamViewModel<OtherSystems.ShygunDomainItemRemain>();
									shygunApiParamViewModel.Config = shygunSetting.conf;
									shygunApiParamViewModel.Domain = shygunDomainItemRemain;
									shygunApiParamViewModel.StartVersion = "0";
									string content = JsonConvert.SerializeObject(shygunApiParamViewModel);
									HttpContent content2 = new StringContent(content, Encoding.UTF8, "application/json");
									HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
									httpResponseMessage = httpClient.PostAsync(requestUri, content2).Result;
									if (httpResponseMessage.IsSuccessStatusCode)
									{
										string value2 = httpResponseMessage.Content.ReadAsStringAsync().Result;
										if (!string.IsNullOrWhiteSpace(value2))
										{
											value2 = value2.ClearHiddenCharacters();
										}
										if (!string.IsNullOrWhiteSpace(value2))
										{
											OtherSystems.ShygunApiGetItemGetRemainResultViewModel shygunApiGetItemGetRemainResultViewModel = JsonConvert.DeserializeObject<OtherSystems.ShygunApiGetItemGetRemainResultViewModel>(value2);
											if (shygunApiGetItemGetRemainResultViewModel != null && shygunApiGetItemGetRemainResultViewModel.Result != null && Enumerable.Any<OtherSystems.ShygunItemGetRemainViewModel>((IEnumerable<OtherSystems.ShygunItemGetRemainViewModel>)shygunApiGetItemGetRemainResultViewModel.Result))
											{
												OtherSystems.ShygunItemGetRemainViewModel shygunItemGetRemainViewModel = Enumerable.FirstOrDefault<OtherSystems.ShygunItemGetRemainViewModel>((IEnumerable<OtherSystems.ShygunItemGetRemainViewModel>)shygunApiGetItemGetRemainResultViewModel.Result);
												if (shygunItemGetRemainViewModel != null)
												{
													result = shygunItemGetRemainViewModel.Quantity1.GetValueOrDefault().ToString();
												}
											}
										}
									}
								}
							}
							else
							{
								string message3 = RS.Get("ErrorNotFound", rsCollation, RS.TypeMsg) + "(warehouse)";
								Exception e4 = new Exception(message3);
								ErrorSignal.FromCurrentContext().Raise(e4);
								result = RS.Get("frmError", rsCollation, RS.TypeLbl);
							}
						}
					}
					else
					{
						string message4 = RS.Get("ErrorNotFound", rsCollation, RS.TypeMsg) + "(warehouse)";
						Exception e5 = new Exception(message4);
						ErrorSignal.FromCurrentContext().Raise(e5);
						result = RS.Get("frmError", rsCollation, RS.TypeLbl);
					}
				}
				else
				{
					string message5 = RS.Get("ErrorNotFound", rsCollation, RS.TypeMsg) + "(product)";
					Exception e6 = new Exception(message5);
					ErrorSignal.FromCurrentContext().Raise(e6);
					result = RS.Get("frmError", rsCollation, RS.TypeLbl);
				}
			}
			else
			{
				string message6 = RS.Get("ErrorNotFound", rsCollation, RS.TypeMsg) + "(product)";
				Exception e7 = new Exception(message6);
				ErrorSignal.FromCurrentContext().Raise(e7);
				result = RS.Get("frmError", rsCollation, RS.TypeLbl);
			}
		}
		catch (Exception e8)
		{
			ErrorSignal.FromCurrentContext().Raise(e8);
			result = RS.Get("frmError", rsCollation, RS.TypeLbl);
		}
		return result;
	}

	public string Hamrahan_GetToken()
	{
		string result = "";
		try
		{
			OtherSystems.HamrahanSettingViewModel hamrahanSetting = OtherSystems.GetHamrahanSetting();
			if (hamrahanSetting != null)
			{
				string text = hamrahanSetting.HamrahanApiAddress ?? "";
				string text2 = hamrahanSetting.HamrahanApiVersion ?? "";
				string text3 = hamrahanSetting.HamrahanApiKey ?? "";
				if (!string.IsNullOrWhiteSpace(text))
				{
					if (!text.EndsWith("/"))
					{
						text += "/";
					}
					if (!text.EndsWith("api/"))
					{
						text += "api/";
					}
				}
				if (!string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(text2) && !string.IsNullOrWhiteSpace(text3))
				{
					text = text + "v" + text2 + "/";
					HttpClient httpClient = new HttpClient();
					string text4 = string.Format(text + "GetToken?key={0}", text3);
					httpClient.BaseAddress = new Uri(text4);
					httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
					string content = "";
					HttpContent content2 = new StringContent(content, Encoding.UTF8, "application/json");
					HttpResponseMessage result2 = httpClient.PostAsync(text4, content2).Result;
					if (result2.IsSuccessStatusCode)
					{
						string value = result2.Content.ReadAsStringAsync().Result;
						if (!string.IsNullOrWhiteSpace(value))
						{
							value = value.ClearHiddenCharacters();
						}
						if (!string.IsNullOrWhiteSpace(value))
						{
							HamrahanGetTokenResponseViewModel hamrahanGetTokenResponseViewModel = JsonConvert.DeserializeObject<HamrahanGetTokenResponseViewModel>(value);
							if (hamrahanGetTokenResponseViewModel != null && hamrahanGetTokenResponseViewModel.isSuccess.GetValueOrDefault() && !string.IsNullOrWhiteSpace(hamrahanGetTokenResponseViewModel.token))
							{
								result = "Bearer " + hamrahanGetTokenResponseViewModel.token;
							}
						}
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = "";
		}
		return result;
	}

	public string HamrahanGetPrdQuantity(int prdId, int whId, string linkAccWhId = "", int currLangID = 0, int defLangID = 0)
	{
		//IL_03ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f5: Expected O, but got Unknown
		//IL_049c: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a3: Expected O, but got Unknown
		//IL_04b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ba: Expected I4, but got Unknown
		string result = "";
		string rsCollation = "fa-IR";
		try
		{
			if (prdId > 0)
			{
				ApispSelectProductsWithId_Result apispSelectProductsWithId_Result = Enumerable.FirstOrDefault<ApispSelectProductsWithId_Result>((IEnumerable<ApispSelectProductsWithId_Result>)db.ApispSelectProductsWithId(prdId, currLangID, defLangID));
				if (apispSelectProductsWithId_Result == null)
				{
					string message = RS.Get("ErrorNotFound", rsCollation, RS.TypeMsg) + "(product)";
					Exception e = new Exception(message);
					ErrorSignal.FromCurrentContext().Raise(e);
					result = RS.Get("frmError", rsCollation, RS.TypeLbl);
				}
				if (apispSelectProductsWithId_Result != null && !string.IsNullOrWhiteSpace(apispSelectProductsWithId_Result.PrdLinkAccPrdCode))
				{
					ApispSelectWareHouseWithAccLinkField_Result apispSelectWareHouseWithAccLinkField_Result = new ApispSelectWareHouseWithAccLinkField_Result();
					List<ApispSelectWareHouseWithAccLinkField_Result> list = Enumerable.ToList<ApispSelectWareHouseWithAccLinkField_Result>((IEnumerable<ApispSelectWareHouseWithAccLinkField_Result>)db.ApispSelectWareHouseWithAccLinkField(false, false, false, true, currLangID, defLangID));
					if (list != null)
					{
						apispSelectWareHouseWithAccLinkField_Result = Enumerable.FirstOrDefault<ApispSelectWareHouseWithAccLinkField_Result>((IEnumerable<ApispSelectWareHouseWithAccLinkField_Result>)list, (Func<ApispSelectWareHouseWithAccLinkField_Result, bool>)((ApispSelectWareHouseWithAccLinkField_Result m) => m.WareHouseID == whId));
					}
					if (apispSelectWareHouseWithAccLinkField_Result != null)
					{
						if (string.IsNullOrWhiteSpace(apispSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses))
						{
							string message2 = RS.Get("ErrorNotFound", rsCollation, RS.TypeMsg) + "(warehouse in Hamrahan)";
							Exception e2 = new Exception(message2);
							ErrorSignal.FromCurrentContext().Raise(e2);
							result = RS.Get("frmError", rsCollation, RS.TypeLbl);
						}
						else
						{
							List<CommonWithIdStrViewModel> list2 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(apispSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses);
							string linkWhId = "";
							if (list2 != null && Enumerable.Any<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list2))
							{
								CommonWithIdStrViewModel commonWithIdStrViewModel = Enumerable.FirstOrDefault<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list2, (Func<CommonWithIdStrViewModel, bool>)((CommonWithIdStrViewModel m) => m.Id == linkAccWhId));
								if (commonWithIdStrViewModel != null)
								{
									linkWhId = commonWithIdStrViewModel.Id;
								}
							}
							if (string.IsNullOrWhiteSpace(linkWhId) && !string.IsNullOrWhiteSpace(apispSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhIdStr))
							{
								linkWhId = apispSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhIdStr;
							}
							if (!string.IsNullOrWhiteSpace(linkWhId))
							{
								string text = Hamrahan_GetToken();
								if (!string.IsNullOrWhiteSpace(text))
								{
									OtherSystems.HamrahanSettingViewModel hamrahanSetting = OtherSystems.GetHamrahanSetting();
									if (hamrahanSetting != null)
									{
										string text2 = hamrahanSetting.HamrahanApiAddress ?? "";
										string text3 = hamrahanSetting.HamrahanApiVersion ?? "";
										string text4 = hamrahanSetting.HamrahanCompanyId ?? "";
										string s = hamrahanSetting.HamrahanApiUserId ?? "";
										string s2 = hamrahanSetting.HamrahanCurrencyUnit ?? "";
										int result2 = 0;
										int.TryParse(text4, out result2);
										int result3 = 0;
										int.TryParse(s, out result3);
										int result4 = 0;
										int.TryParse(s2, out result4);
										if (!string.IsNullOrWhiteSpace(text2) && !string.IsNullOrWhiteSpace(text3) && !string.IsNullOrWhiteSpace(text4))
										{
											if (!text2.EndsWith("/"))
											{
												text2 += "/";
											}
											if (!text2.EndsWith("api/"))
											{
												text2 += "api/";
											}
											text2 = text2 + "v" + text3 + "/";
											int num = 0;
											num = apispSelectProductsWithId_Result.PrdKind.GetValueOrDefault();
											string text5 = text2 + "CellarPlaceValue/Object";
											string text6 = DateTime.Now.ToString("yyyy/MM/dd", new PersianCulture());
											string value = "{\"company\":" + result2 + ",\"userID\":" + result3 + ",\"refSaleCenter\":0,\"refSaleMethod\":0,\"kindOfService\":" + num + ",\"refProcess\":0,\"documentDate\":\"" + text6 + "\",\"codeObject\":\"" + apispSelectProductsWithId_Result.PrdLinkAccPrdCode + "\",\"qty\":1.0,\"rnValuta\":0,\"refGroupCustomer\":0,\"refCustomer\":0}";
											HttpWebRequest val = (HttpWebRequest)WebRequest.Create(text5);
											((NameValueCollection)((WebRequest)val).Headers).Add("Authorization", text);
											((WebRequest)val).ContentType = "application/json; charset=utf-8";
											((WebRequest)val).Method = "GET";
											val.Accept = "application/json";
											Type type = ((object)val).GetType();
											object value2 = type.GetProperty("CurrentMethod", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(val);
											Type type2 = value2.GetType();
											type2.GetField("ContentBodyNotAllowed", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(value2, false);
											using (StreamWriter streamWriter = new StreamWriter(((WebRequest)val).GetRequestStream()))
											{
												streamWriter.Write(value);
											}
											HttpWebResponse val2 = (HttpWebResponse)((WebRequest)val).GetResponse();
											StreamReader streamReader = new StreamReader(((WebResponse)val2).GetResponseStream());
											int num2 = (int)val2.StatusCode;
											if (num2 == 200)
											{
												string value3 = streamReader.ReadToEnd();
												if (!string.IsNullOrWhiteSpace(value3))
												{
													value3 = value3.ClearHiddenCharacters();
												}
												if (!string.IsNullOrWhiteSpace(value3))
												{
													List<HamrahanProductQtyInfoViewModel> list3 = JsonConvert.DeserializeObject<List<HamrahanProductQtyInfoViewModel>>(value3);
													if (list3 != null && Enumerable.Any<HamrahanProductQtyInfoViewModel>((IEnumerable<HamrahanProductQtyInfoViewModel>)list3))
													{
														HamrahanProductQtyInfoViewModel hamrahanProductQtyInfoViewModel = Enumerable.FirstOrDefault<HamrahanProductQtyInfoViewModel>((IEnumerable<HamrahanProductQtyInfoViewModel>)list3, (Func<HamrahanProductQtyInfoViewModel, bool>)((HamrahanProductQtyInfoViewModel m) => m.rnPhysical.GetValueOrDefault().ToString() == linkWhId));
														if (hamrahanProductQtyInfoViewModel != null)
														{
															result = hamrahanProductQtyInfoViewModel.cellarValue.GetValueOrDefault().ToString();
															decimal valueOrDefault = hamrahanProductQtyInfoViewModel.rate.GetValueOrDefault();
														}
													}
												}
											}
										}
									}
								}
							}
							else
							{
								string message3 = RS.Get("ErrorNotFound", rsCollation, RS.TypeMsg) + "(warehouse)";
								Exception e3 = new Exception(message3);
								ErrorSignal.FromCurrentContext().Raise(e3);
								result = RS.Get("frmError", rsCollation, RS.TypeLbl);
							}
						}
					}
					else
					{
						string message4 = RS.Get("ErrorNotFound", rsCollation, RS.TypeMsg) + "(warehouse)";
						Exception e4 = new Exception(message4);
						ErrorSignal.FromCurrentContext().Raise(e4);
						result = RS.Get("frmError", rsCollation, RS.TypeLbl);
					}
				}
				else
				{
					string message5 = RS.Get("ErrorNotFound", rsCollation, RS.TypeMsg) + "(product)";
					Exception e5 = new Exception(message5);
					ErrorSignal.FromCurrentContext().Raise(e5);
					result = RS.Get("frmError", rsCollation, RS.TypeLbl);
				}
			}
			else
			{
				string message6 = RS.Get("ErrorNotFound", rsCollation, RS.TypeMsg) + "(product)";
				Exception e6 = new Exception(message6);
				ErrorSignal.FromCurrentContext().Raise(e6);
				result = RS.Get("frmError", rsCollation, RS.TypeLbl);
			}
		}
		catch (Exception e7)
		{
			ErrorSignal.FromCurrentContext().Raise(e7);
			result = RS.Get("frmError", rsCollation, RS.TypeLbl);
		}
		return result;
	}

	public string NilramGetPrdQuantity(int prdId, int whId, string linkAccWhId = "", int currLangID = 0, int defLangID = 0)
	{
		string result = "";
		string rsCollation = "fa-IR";
		try
		{
			if (prdId > 0)
			{
				ApispSelectProductsWithId_Result prd = Enumerable.FirstOrDefault<ApispSelectProductsWithId_Result>((IEnumerable<ApispSelectProductsWithId_Result>)db.ApispSelectProductsWithId(prdId, currLangID, defLangID));
				if (prd == null)
				{
					string message = RS.Get("ErrorNotFound", rsCollation, RS.TypeMsg) + "(product)";
					Exception e = new Exception(message);
					ErrorSignal.FromCurrentContext().Raise(e);
					result = RS.Get("frmError", rsCollation, RS.TypeLbl);
				}
				if (prd != null && !string.IsNullOrWhiteSpace(prd.PrdLinkAccPrdCode))
				{
					ApispSelectWareHouseWithAccLinkField_Result apispSelectWareHouseWithAccLinkField_Result = new ApispSelectWareHouseWithAccLinkField_Result();
					List<ApispSelectWareHouseWithAccLinkField_Result> list = Enumerable.ToList<ApispSelectWareHouseWithAccLinkField_Result>((IEnumerable<ApispSelectWareHouseWithAccLinkField_Result>)db.ApispSelectWareHouseWithAccLinkField(false, false, false, true, currLangID, defLangID));
					if (list != null)
					{
						apispSelectWareHouseWithAccLinkField_Result = Enumerable.FirstOrDefault<ApispSelectWareHouseWithAccLinkField_Result>((IEnumerable<ApispSelectWareHouseWithAccLinkField_Result>)list, (Func<ApispSelectWareHouseWithAccLinkField_Result, bool>)((ApispSelectWareHouseWithAccLinkField_Result m) => m.WareHouseID == whId));
					}
					if (apispSelectWareHouseWithAccLinkField_Result != null)
					{
						if (string.IsNullOrWhiteSpace(apispSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses))
						{
							string message2 = RS.Get("ErrorNotFound", rsCollation, RS.TypeMsg) + "(warehouse in Nilram)";
							Exception e2 = new Exception(message2);
							ErrorSignal.FromCurrentContext().Raise(e2);
							result = RS.Get("frmError", rsCollation, RS.TypeLbl);
						}
						else
						{
							List<CommonWithIdStrViewModel> list2 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(apispSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses);
							string linkWhId = "";
							if (list2 != null && Enumerable.Any<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list2))
							{
								CommonWithIdStrViewModel commonWithIdStrViewModel = Enumerable.FirstOrDefault<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list2, (Func<CommonWithIdStrViewModel, bool>)((CommonWithIdStrViewModel m) => m.Id == linkAccWhId));
								if (commonWithIdStrViewModel != null)
								{
									linkWhId = commonWithIdStrViewModel.Code;
								}
							}
							if (string.IsNullOrWhiteSpace(linkWhId) && !string.IsNullOrWhiteSpace(apispSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhCode))
							{
								linkWhId = apispSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhCode;
							}
							if (!string.IsNullOrWhiteSpace(linkWhId))
							{
								OtherSystems.NilramSettingViewModel nilramSetting = OtherSystems.GetNilramSetting();
								if (nilramSetting != null)
								{
									string text = nilramSetting.ApiAddress ?? "";
									string value = nilramSetting.ApiToken ?? "";
									if (!string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(value))
									{
										if (!text.EndsWith("/"))
										{
											text += "/";
										}
										HttpClient httpClient = new HttpClient();
										string text2 = text + "MOJODI_KALA/" + linkWhId + "/" + prd.PrdLinkAccPrdCode;
										httpClient.BaseAddress = new Uri(text2);
										httpClient.DefaultRequestHeaders.Add("Access-Token", value);
										httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
										string content = "";
										HttpContent httpContent = new StringContent(content, Encoding.UTF8, "application/json");
										HttpResponseMessage result2 = httpClient.GetAsync(text2).Result;
										if (result2.IsSuccessStatusCode)
										{
											string value2 = result2.Content.ReadAsStringAsync().Result;
											if (!string.IsNullOrWhiteSpace(value2))
											{
												value2 = value2.ClearHiddenCharacters();
											}
											if (!string.IsNullOrWhiteSpace(value2))
											{
												List<NilramProductQuantityInfoViewModel> list3 = JsonConvert.DeserializeObject<List<NilramProductQuantityInfoViewModel>>(value2);
												if (list3 != null && Enumerable.Any<NilramProductQuantityInfoViewModel>((IEnumerable<NilramProductQuantityInfoViewModel>)list3))
												{
													NilramProductQuantityInfoViewModel nilramProductQuantityInfoViewModel = Enumerable.FirstOrDefault<NilramProductQuantityInfoViewModel>((IEnumerable<NilramProductQuantityInfoViewModel>)list3, (Func<NilramProductQuantityInfoViewModel, bool>)((NilramProductQuantityInfoViewModel m) => (m.T_STK_NO ?? "") == linkWhId && (m.T_STK_GDS ?? "") == prd.PrdLinkAccPrdCode));
													if (nilramProductQuantityInfoViewModel != null)
													{
														result = nilramProductQuantityInfoViewModel.T_CUR_QTY.GetValueOrDefault().ToString();
													}
												}
											}
										}
									}
								}
							}
							else
							{
								string message3 = RS.Get("ErrorNotFound", rsCollation, RS.TypeMsg) + "(warehouse)";
								Exception e3 = new Exception(message3);
								ErrorSignal.FromCurrentContext().Raise(e3);
								result = RS.Get("frmError", rsCollation, RS.TypeLbl);
							}
						}
					}
					else
					{
						string message4 = RS.Get("ErrorNotFound", rsCollation, RS.TypeMsg) + "(warehouse)";
						Exception e4 = new Exception(message4);
						ErrorSignal.FromCurrentContext().Raise(e4);
						result = RS.Get("frmError", rsCollation, RS.TypeLbl);
					}
				}
				else
				{
					string message5 = RS.Get("ErrorNotFound", rsCollation, RS.TypeMsg) + "(product)";
					Exception e5 = new Exception(message5);
					ErrorSignal.FromCurrentContext().Raise(e5);
					result = RS.Get("frmError", rsCollation, RS.TypeLbl);
				}
			}
			else
			{
				string message6 = RS.Get("ErrorNotFound", rsCollation, RS.TypeMsg) + "(product)";
				Exception e6 = new Exception(message6);
				ErrorSignal.FromCurrentContext().Raise(e6);
				result = RS.Get("frmError", rsCollation, RS.TypeLbl);
			}
		}
		catch (Exception e7)
		{
			ErrorSignal.FromCurrentContext().Raise(e7);
			result = RS.Get("frmError", rsCollation, RS.TypeLbl);
		}
		return result;
	}

	public string NoAvaranCapillaryGetPrdQuantity(int prdId, int whId, string linkAccWhId = "", int currLangID = 0, int defLangID = 0)
	{
		string result = "";
		string rsCollation = "fa-IR";
		try
		{
			if (prdId > 0)
			{
				ApispSelectProductsWithId_Result apispSelectProductsWithId_Result = Enumerable.FirstOrDefault<ApispSelectProductsWithId_Result>((IEnumerable<ApispSelectProductsWithId_Result>)db.ApispSelectProductsWithId(prdId, currLangID, defLangID));
				if (apispSelectProductsWithId_Result == null)
				{
					string message = RS.Get("ErrorNotFound", rsCollation, RS.TypeMsg) + "(product)";
					Exception e = new Exception(message);
					ErrorSignal.FromCurrentContext().Raise(e);
					result = RS.Get("frmError", rsCollation, RS.TypeLbl);
				}
				if (apispSelectProductsWithId_Result != null && !string.IsNullOrWhiteSpace(apispSelectProductsWithId_Result.PrdLinkAccPrdCode))
				{
					ApispSelectWareHouseWithAccLinkField_Result apispSelectWareHouseWithAccLinkField_Result = new ApispSelectWareHouseWithAccLinkField_Result();
					List<ApispSelectWareHouseWithAccLinkField_Result> list = Enumerable.ToList<ApispSelectWareHouseWithAccLinkField_Result>((IEnumerable<ApispSelectWareHouseWithAccLinkField_Result>)db.ApispSelectWareHouseWithAccLinkField(false, false, false, true, currLangID, defLangID));
					if (list != null)
					{
						apispSelectWareHouseWithAccLinkField_Result = Enumerable.FirstOrDefault<ApispSelectWareHouseWithAccLinkField_Result>((IEnumerable<ApispSelectWareHouseWithAccLinkField_Result>)list, (Func<ApispSelectWareHouseWithAccLinkField_Result, bool>)((ApispSelectWareHouseWithAccLinkField_Result m) => m.WareHouseID == whId));
					}
					if (apispSelectWareHouseWithAccLinkField_Result != null)
					{
						if (string.IsNullOrWhiteSpace(apispSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses))
						{
							string message2 = RS.Get("ErrorNotFound", rsCollation, RS.TypeMsg) + "(warehouse in NoAvaran)";
							Exception e2 = new Exception(message2);
							ErrorSignal.FromCurrentContext().Raise(e2);
							result = RS.Get("frmError", rsCollation, RS.TypeLbl);
						}
						else
						{
							List<CommonWithIdStrViewModel> list2 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(apispSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses);
							string text = "";
							if (list2 != null && Enumerable.Any<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list2))
							{
								CommonWithIdStrViewModel commonWithIdStrViewModel = Enumerable.FirstOrDefault<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list2, (Func<CommonWithIdStrViewModel, bool>)((CommonWithIdStrViewModel m) => m.Id == linkAccWhId));
								if (commonWithIdStrViewModel != null)
								{
									text = commonWithIdStrViewModel.Id;
								}
							}
							if (string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(apispSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhIdStr))
							{
								text = apispSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhIdStr;
							}
							if (!string.IsNullOrWhiteSpace(text))
							{
								OtherSystems.NoAvaranCapillarySettingViewModel noAvaranCapillarySetting = OtherSystems.GetNoAvaranCapillarySetting();
								if (noAvaranCapillarySetting != null)
								{
									string value = noAvaranCapillarySetting.ApiUserId ?? "";
									if (!string.IsNullOrWhiteSpace(value))
									{
										int result2 = 0;
										int.TryParse(text.ToString(), out result2);
										CommercialSoapClient commercialSoapClient = new CommercialSoapClient();
										string text2 = commercialSoapClient.GetQuanKala("0", "0", apispSelectProductsWithId_Result.PrdLinkAccPrdCode, text);
										if (!string.IsNullOrWhiteSpace(text2))
										{
											text2 = text2.ClearHiddenCharacters();
										}
										if (!string.IsNullOrWhiteSpace(text2) && text2.ToLower() != "null")
										{
											NoAvaranCapillaryProductQuantityInfoViewModel noAvaranCapillaryProductQuantityInfoViewModel = JsonConvert.DeserializeObject<NoAvaranCapillaryProductQuantityInfoViewModel>(text2);
											if (noAvaranCapillaryProductQuantityInfoViewModel != null)
											{
												result = noAvaranCapillaryProductQuantityInfoViewModel.quan.GetValueOrDefault().ToString();
											}
										}
									}
								}
							}
							else
							{
								string message3 = RS.Get("ErrorNotFound", rsCollation, RS.TypeMsg) + "(warehouse)";
								Exception e3 = new Exception(message3);
								ErrorSignal.FromCurrentContext().Raise(e3);
								result = RS.Get("frmError", rsCollation, RS.TypeLbl);
							}
						}
					}
					else
					{
						string message4 = RS.Get("ErrorNotFound", rsCollation, RS.TypeMsg) + "(warehouse)";
						Exception e4 = new Exception(message4);
						ErrorSignal.FromCurrentContext().Raise(e4);
						result = RS.Get("frmError", rsCollation, RS.TypeLbl);
					}
				}
				else
				{
					string message5 = RS.Get("ErrorNotFound", rsCollation, RS.TypeMsg) + "(product)";
					Exception e5 = new Exception(message5);
					ErrorSignal.FromCurrentContext().Raise(e5);
					result = RS.Get("frmError", rsCollation, RS.TypeLbl);
				}
			}
			else
			{
				string message6 = RS.Get("ErrorNotFound", rsCollation, RS.TypeMsg) + "(product)";
				Exception e6 = new Exception(message6);
				ErrorSignal.FromCurrentContext().Raise(e6);
				result = RS.Get("frmError", rsCollation, RS.TypeLbl);
			}
		}
		catch (Exception e7)
		{
			ErrorSignal.FromCurrentContext().Raise(e7);
			result = RS.Get("frmError", rsCollation, RS.TypeLbl);
		}
		return result;
	}

	public string RahkaranRetailGetPrdQuantity(int prdId, int whId, string linkAccWhId = "", int currLangID = 0, int defLangID = 0)
	{
		//IL_0314: Unknown result type (might be due to invalid IL or missing references)
		//IL_031b: Expected O, but got Unknown
		//IL_03c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c9: Expected O, but got Unknown
		//IL_03d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e0: Expected I4, but got Unknown
		string result = "";
		string rsCollation = "fa-IR";
		try
		{
			if (prdId > 0)
			{
				ApispSelectProductsWithId_Result apispSelectProductsWithId_Result = Enumerable.FirstOrDefault<ApispSelectProductsWithId_Result>((IEnumerable<ApispSelectProductsWithId_Result>)db.ApispSelectProductsWithId(prdId, currLangID, defLangID));
				if (apispSelectProductsWithId_Result == null)
				{
					string message = RS.Get("ErrorNotFound", rsCollation, RS.TypeMsg) + "(product)";
					Exception e = new Exception(message);
					ErrorSignal.FromCurrentContext().Raise(e);
					result = RS.Get("frmError", rsCollation, RS.TypeLbl);
				}
				if (apispSelectProductsWithId_Result != null && !string.IsNullOrWhiteSpace(apispSelectProductsWithId_Result.PrdLinkAccPrdCode))
				{
					ApispSelectWareHouseWithAccLinkField_Result apispSelectWareHouseWithAccLinkField_Result = new ApispSelectWareHouseWithAccLinkField_Result();
					List<ApispSelectWareHouseWithAccLinkField_Result> list = Enumerable.ToList<ApispSelectWareHouseWithAccLinkField_Result>((IEnumerable<ApispSelectWareHouseWithAccLinkField_Result>)db.ApispSelectWareHouseWithAccLinkField(false, false, false, true, currLangID, defLangID));
					if (list != null)
					{
						apispSelectWareHouseWithAccLinkField_Result = Enumerable.FirstOrDefault<ApispSelectWareHouseWithAccLinkField_Result>((IEnumerable<ApispSelectWareHouseWithAccLinkField_Result>)list, (Func<ApispSelectWareHouseWithAccLinkField_Result, bool>)((ApispSelectWareHouseWithAccLinkField_Result m) => m.WareHouseID == whId));
					}
					if (apispSelectWareHouseWithAccLinkField_Result != null)
					{
						if (string.IsNullOrWhiteSpace(apispSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses))
						{
							string message2 = RS.Get("ErrorNotFound", rsCollation, RS.TypeMsg) + "(warehouse in Rahkaran)";
							Exception e2 = new Exception(message2);
							ErrorSignal.FromCurrentContext().Raise(e2);
							result = RS.Get("frmError", rsCollation, RS.TypeLbl);
						}
						else
						{
							List<CommonWithIdStrViewModel> list2 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(apispSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses);
							string text = "";
							if (list2 != null && Enumerable.Any<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list2))
							{
								CommonWithIdStrViewModel commonWithIdStrViewModel = Enumerable.FirstOrDefault<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list2, (Func<CommonWithIdStrViewModel, bool>)((CommonWithIdStrViewModel m) => m.Id == linkAccWhId));
								if (commonWithIdStrViewModel != null)
								{
									text = commonWithIdStrViewModel.Id;
								}
							}
							if (string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(apispSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhIdStr))
							{
								text = apispSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhIdStr;
							}
							if (!string.IsNullOrWhiteSpace(text))
							{
								OtherSystems.RahkaranRetailSettingViewModel rahkaranRetailSetting = OtherSystems.GetRahkaranRetailSetting();
								if (rahkaranRetailSetting != null)
								{
									string text2 = rahkaranRetailSetting.ApiCookie ?? "";
									if (!string.IsNullOrWhiteSpace(text2))
									{
										string text3 = OtherSystems.CreateRahkaranCookie(text2);
										if (!string.IsNullOrWhiteSpace(text3))
										{
											string text4 = rahkaranRetailSetting.ApiAddress ?? "";
											if (!string.IsNullOrWhiteSpace(text4) && !text4.EndsWith("/"))
											{
												text4 += "/";
											}
											if (!string.IsNullOrWhiteSpace(text4) && !string.IsNullOrWhiteSpace(text3))
											{
												string text5 = text4 + "Services/Retail/ESales.svc/remaining";
												string value = "{\"productId\":" + (apispSelectProductsWithId_Result.PrdLinkAccPrdIdStr ?? "0") + ",\"storeId\":" + text + ",\"dateTime\":\"" + DateTime.Now.ToString("yyyy/MM/dd", new CultureInfo("en-US")) + "\"}";
												HttpWebRequest val = (HttpWebRequest)WebRequest.Create(text5);
												((NameValueCollection)((WebRequest)val).Headers).Add("Cookie", text3);
												((WebRequest)val).ContentType = "application/json; charset=utf-8";
												((WebRequest)val).Method = "POST";
												val.Accept = "application/json";
												Type type = ((object)val).GetType();
												object value2 = type.GetProperty("CurrentMethod", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(val);
												Type type2 = value2.GetType();
												type2.GetField("ContentBodyNotAllowed", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(value2, false);
												using (StreamWriter streamWriter = new StreamWriter(((WebRequest)val).GetRequestStream()))
												{
													streamWriter.Write(value);
												}
												HttpWebResponse val2 = (HttpWebResponse)((WebRequest)val).GetResponse();
												StreamReader streamReader = new StreamReader(((WebResponse)val2).GetResponseStream());
												int num = (int)val2.StatusCode;
												if (num == 200)
												{
													string value3 = streamReader.ReadToEnd();
													if (!string.IsNullOrWhiteSpace(value3))
													{
														value3 = value3.ClearHiddenCharacters();
													}
													if (!string.IsNullOrWhiteSpace(value3))
													{
														RahkaranRetailProductRemainingResponseViewModel rahkaranRetailProductRemainingResponseViewModel = JsonConvert.DeserializeObject<RahkaranRetailProductRemainingResponseViewModel>(value3);
														if (rahkaranRetailProductRemainingResponseViewModel != null && rahkaranRetailProductRemainingResponseViewModel.result.HasValue)
														{
															result = rahkaranRetailProductRemainingResponseViewModel.result.GetValueOrDefault().ToString();
														}
													}
												}
											}
										}
									}
								}
							}
							else
							{
								string message3 = RS.Get("ErrorNotFound", rsCollation, RS.TypeMsg) + "(warehouse)";
								Exception e3 = new Exception(message3);
								ErrorSignal.FromCurrentContext().Raise(e3);
								result = RS.Get("frmError", rsCollation, RS.TypeLbl);
							}
						}
					}
					else
					{
						string message4 = RS.Get("ErrorNotFound", rsCollation, RS.TypeMsg) + "(warehouse)";
						Exception e4 = new Exception(message4);
						ErrorSignal.FromCurrentContext().Raise(e4);
						result = RS.Get("frmError", rsCollation, RS.TypeLbl);
					}
				}
				else
				{
					string message5 = RS.Get("ErrorNotFound", rsCollation, RS.TypeMsg) + "(product)";
					Exception e5 = new Exception(message5);
					ErrorSignal.FromCurrentContext().Raise(e5);
					result = RS.Get("frmError", rsCollation, RS.TypeLbl);
				}
			}
			else
			{
				string message6 = RS.Get("ErrorNotFound", rsCollation, RS.TypeMsg) + "(product)";
				Exception e6 = new Exception(message6);
				ErrorSignal.FromCurrentContext().Raise(e6);
				result = RS.Get("frmError", rsCollation, RS.TypeLbl);
			}
		}
		catch (Exception e7)
		{
			ErrorSignal.FromCurrentContext().Raise(e7);
			result = RS.Get("frmError", rsCollation, RS.TypeLbl);
		}
		return result;
	}

	public string RahkaranInternalSalesGetPrdQuantity(int prdId, int whId, string linkAccWhId = "", int currLangID = 0, int defLangID = 0)
	{
		string text = "";
		string rsCollation = "fa-IR";
		try
		{
			if (prdId > 0)
			{
				ApispSelectProductsWithId_Result apispSelectProductsWithId_Result = Enumerable.FirstOrDefault<ApispSelectProductsWithId_Result>((IEnumerable<ApispSelectProductsWithId_Result>)db.ApispSelectProductsWithId(prdId, currLangID, defLangID));
				if (apispSelectProductsWithId_Result == null)
				{
					string message = RS.Get("ErrorNotFound", rsCollation, RS.TypeMsg) + "(product)";
					Exception e = new Exception(message);
					ErrorSignal.FromCurrentContext().Raise(e);
					text = RS.Get("frmError", rsCollation, RS.TypeLbl);
				}
				if (apispSelectProductsWithId_Result != null && !string.IsNullOrWhiteSpace(apispSelectProductsWithId_Result.PrdLinkAccPrdIdStr))
				{
					ApispSelectWareHouseWithAccLinkField_Result apispSelectWareHouseWithAccLinkField_Result = new ApispSelectWareHouseWithAccLinkField_Result();
					List<ApispSelectWareHouseWithAccLinkField_Result> list = Enumerable.ToList<ApispSelectWareHouseWithAccLinkField_Result>((IEnumerable<ApispSelectWareHouseWithAccLinkField_Result>)db.ApispSelectWareHouseWithAccLinkField(false, false, false, true, currLangID, defLangID));
					if (list != null)
					{
						apispSelectWareHouseWithAccLinkField_Result = Enumerable.FirstOrDefault<ApispSelectWareHouseWithAccLinkField_Result>((IEnumerable<ApispSelectWareHouseWithAccLinkField_Result>)list, (Func<ApispSelectWareHouseWithAccLinkField_Result, bool>)((ApispSelectWareHouseWithAccLinkField_Result m) => m.WareHouseID == whId));
					}
					if (apispSelectWareHouseWithAccLinkField_Result != null)
					{
						if (string.IsNullOrWhiteSpace(apispSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses))
						{
							string message2 = RS.Get("ErrorNotFound", rsCollation, RS.TypeMsg) + "(warehouse in Rahkaran)";
							Exception e2 = new Exception(message2);
							ErrorSignal.FromCurrentContext().Raise(e2);
							return RS.Get("frmError", rsCollation, RS.TypeLbl);
						}
						List<CommonWithIdStrViewModel> list2 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(apispSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses);
						string text2 = "";
						if (list2 != null && Enumerable.Any<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list2))
						{
							CommonWithIdStrViewModel commonWithIdStrViewModel = Enumerable.FirstOrDefault<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list2, (Func<CommonWithIdStrViewModel, bool>)((CommonWithIdStrViewModel m) => m.Id == linkAccWhId));
							if (commonWithIdStrViewModel != null)
							{
								text2 = commonWithIdStrViewModel.Id;
								if (string.IsNullOrWhiteSpace(text2))
								{
									text2 = commonWithIdStrViewModel.Code;
								}
							}
						}
						if (string.IsNullOrWhiteSpace(text2) && !string.IsNullOrWhiteSpace(apispSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhIdStr))
						{
							text2 = apispSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhIdStr;
						}
						if (string.IsNullOrWhiteSpace(text2) && !string.IsNullOrWhiteSpace(apispSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhIdStr))
						{
							text2 = apispSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhIdStr;
						}
						if (!string.IsNullOrWhiteSpace(text2))
						{
							long result = 0L;
							long.TryParse(text2, out result);
							long result2 = 0L;
							long.TryParse(apispSelectProductsWithId_Result.PrdLinkAccPrdIdStr, out result2);
							OtherSystems.RahkaranInternalSalesProvider rahkaranInternalSalesProvider = new OtherSystems.RahkaranInternalSalesProvider(isUpdateList: false, isLogin: true, currLangID, defLangID);
							return rahkaranInternalSalesProvider.GetPrdQuqntity(result2, result).ToString();
						}
						string message3 = RS.Get("ErrorNotFound", rsCollation, RS.TypeMsg) + "(warehouse)";
						Exception e3 = new Exception(message3);
						ErrorSignal.FromCurrentContext().Raise(e3);
						return RS.Get("frmError", rsCollation, RS.TypeLbl);
					}
					string message4 = RS.Get("ErrorNotFound", rsCollation, RS.TypeMsg) + "(warehouse)";
					Exception e4 = new Exception(message4);
					ErrorSignal.FromCurrentContext().Raise(e4);
					return RS.Get("frmError", rsCollation, RS.TypeLbl);
				}
				string message5 = RS.Get("ErrorNotFound", rsCollation, RS.TypeMsg) + "(product)";
				Exception e5 = new Exception(message5);
				ErrorSignal.FromCurrentContext().Raise(e5);
				return RS.Get("frmError", rsCollation, RS.TypeLbl);
			}
			string message6 = RS.Get("ErrorNotFound", rsCollation, RS.TypeMsg) + "(product)";
			Exception e6 = new Exception(message6);
			ErrorSignal.FromCurrentContext().Raise(e6);
			return RS.Get("frmError", rsCollation, RS.TypeLbl);
		}
		catch (Exception e7)
		{
			ErrorSignal.FromCurrentContext().Raise(e7);
			return RS.Get("frmError", rsCollation, RS.TypeLbl);
		}
	}

	public string RayvarzGetPrdQuantity(int prdId, int whId, string linkAccWhId = "", int currLangID = 0, int defLangID = 0)
	{
		string text = "";
		string rsCollation = "fa-IR";
		try
		{
			if (prdId > 0)
			{
				ApispSelectProductsWithId_Result apispSelectProductsWithId_Result = Enumerable.FirstOrDefault<ApispSelectProductsWithId_Result>((IEnumerable<ApispSelectProductsWithId_Result>)db.ApispSelectProductsWithId(prdId, currLangID, defLangID));
				if (apispSelectProductsWithId_Result == null)
				{
					string message = RS.Get("ErrorNotFound", rsCollation, RS.TypeMsg) + "(product)";
					Exception e = new Exception(message);
					ErrorSignal.FromCurrentContext().Raise(e);
					text = RS.Get("frmError", rsCollation, RS.TypeLbl);
				}
				if (apispSelectProductsWithId_Result != null && !string.IsNullOrWhiteSpace(apispSelectProductsWithId_Result.PrdLinkAccPrdIdStr))
				{
					ApispSelectWareHouseWithAccLinkField_Result apispSelectWareHouseWithAccLinkField_Result = new ApispSelectWareHouseWithAccLinkField_Result();
					List<ApispSelectWareHouseWithAccLinkField_Result> list = Enumerable.ToList<ApispSelectWareHouseWithAccLinkField_Result>((IEnumerable<ApispSelectWareHouseWithAccLinkField_Result>)db.ApispSelectWareHouseWithAccLinkField(false, false, false, true, currLangID, defLangID));
					if (list != null)
					{
						apispSelectWareHouseWithAccLinkField_Result = Enumerable.FirstOrDefault<ApispSelectWareHouseWithAccLinkField_Result>((IEnumerable<ApispSelectWareHouseWithAccLinkField_Result>)list, (Func<ApispSelectWareHouseWithAccLinkField_Result, bool>)((ApispSelectWareHouseWithAccLinkField_Result m) => m.WareHouseID == whId));
					}
					if (apispSelectWareHouseWithAccLinkField_Result != null)
					{
						if (string.IsNullOrWhiteSpace(apispSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses))
						{
							string message2 = RS.Get("ErrorNotFound", rsCollation, RS.TypeMsg) + "(warehouse in Rayvarz)";
							Exception e2 = new Exception(message2);
							ErrorSignal.FromCurrentContext().Raise(e2);
							return RS.Get("frmError", rsCollation, RS.TypeLbl);
						}
						List<CommonWithIdStrViewModel> list2 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(apispSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses);
						string text2 = "";
						if (list2 != null && Enumerable.Any<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list2))
						{
							CommonWithIdStrViewModel commonWithIdStrViewModel = Enumerable.FirstOrDefault<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list2, (Func<CommonWithIdStrViewModel, bool>)((CommonWithIdStrViewModel m) => m.Id == linkAccWhId));
							if (commonWithIdStrViewModel != null)
							{
								text2 = commonWithIdStrViewModel.Id;
							}
						}
						if (string.IsNullOrWhiteSpace(text2) && !string.IsNullOrWhiteSpace(apispSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhIdStr))
						{
							text2 = apispSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhIdStr;
						}
						if (!string.IsNullOrWhiteSpace(text2))
						{
							OtherSystems.RayvarzProvider rayvarzProvider = new OtherSystems.RayvarzProvider();
							return rayvarzProvider.GetPrdQuqntity(apispSelectProductsWithId_Result.PrdLinkAccPrdIdStr, text2).ToString();
						}
						string message3 = RS.Get("ErrorNotFound", rsCollation, RS.TypeMsg) + "(warehouse)";
						Exception e3 = new Exception(message3);
						ErrorSignal.FromCurrentContext().Raise(e3);
						return RS.Get("frmError", rsCollation, RS.TypeLbl);
					}
					string message4 = RS.Get("ErrorNotFound", rsCollation, RS.TypeMsg) + "(warehouse)";
					Exception e4 = new Exception(message4);
					ErrorSignal.FromCurrentContext().Raise(e4);
					return RS.Get("frmError", rsCollation, RS.TypeLbl);
				}
				string message5 = RS.Get("ErrorNotFound", rsCollation, RS.TypeMsg) + "(product)";
				Exception e5 = new Exception(message5);
				ErrorSignal.FromCurrentContext().Raise(e5);
				return RS.Get("frmError", rsCollation, RS.TypeLbl);
			}
			string message6 = RS.Get("ErrorNotFound", rsCollation, RS.TypeMsg) + "(product)";
			Exception e6 = new Exception(message6);
			ErrorSignal.FromCurrentContext().Raise(e6);
			return RS.Get("frmError", rsCollation, RS.TypeLbl);
		}
		catch (Exception e7)
		{
			ErrorSignal.FromCurrentContext().Raise(e7);
			return RS.Get("frmError", rsCollation, RS.TypeLbl);
		}
	}

	public string LinkAccGetPrdQuantity(int linkAccSystemId, int prdId, int whId, string linkAccWhId = "", string tracing = "", string sefaresh = "", int currLangID = 0, int defLangID = 0)
	{
		string text = "";
		string rsCollation = "fa-IR";
		try
		{
			switch (linkAccSystemId)
			{
			case 8:
				text = ShygunGetPrdQuantity(prdId, whId, linkAccWhId);
				break;
			case 12:
				text = ArpaGetPrdQuantity(prdId, whId, linkAccWhId);
				break;
			case 17:
				text = HamrahanGetPrdQuantity(prdId, whId, linkAccWhId);
				break;
			case 18:
				text = NoAvaranCapillaryGetPrdQuantity(prdId, whId, linkAccWhId);
				break;
			case 19:
				text = RahkaranRetailGetPrdQuantity(prdId, whId, linkAccWhId);
				break;
			case 20:
				text = NilramGetPrdQuantity(prdId, whId, linkAccWhId);
				break;
			case 22:
				text = RahkaranInternalSalesGetPrdQuantity(prdId, whId, linkAccWhId);
				break;
			case 23:
				text = RayvarzGetPrdQuantity(prdId, whId, linkAccWhId);
				break;
			}
			if (string.IsNullOrWhiteSpace(text))
			{
				text = "0";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			text = RS.Get("frmError", rsCollation, RS.TypeLbl);
		}
		return text;
	}

	[HttpPost]
	public ServiceResult<IssueLkOrderResultViewModel> SendOrderToLinkAcc(LkWSOrderViewModel model)
	{
		CRMEntities cRMEntities = null;
		IssueLkOrderResultViewModel data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			int result = 0;
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<IssueLkOrderResultViewModel>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			CommonClass commonClass = new CommonClass();
			if (model.ApiOrderId <= 0)
			{
				model.ApiOrderId = null;
			}
			if (model.ApiOrdNumber <= 0)
			{
				model.ApiOrdNumber = null;
			}
			if (model.ApiLinkAccOrdType <= 0)
			{
				model.ApiLinkAccOrdType = null;
			}
			if (model.ApiLinkAccSettingDBId <= 0)
			{
				model.ApiLinkAccSettingDBId = null;
			}
			if (model.ApiLinkAccFiscalYearId <= 0)
			{
				model.ApiLinkAccFiscalYearId = null;
			}
			if (model.ApiLinkAccUserId <= 0)
			{
				model.ApiLinkAccUserId = null;
			}
			if (model.ApiLinkAccInventoryType <= 0)
			{
				model.ApiLinkAccInventoryType = null;
			}
			if (model.ApiLinkAccDocType <= 0)
			{
				model.ApiLinkAccDocType = null;
			}
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<IssueLkOrderResultViewModel>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int.TryParse(apispSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result);
			int.TryParse(model.LanguageId.ToString(), out var currLangId);
			if (currLangId <= 0)
			{
				currLangId = result2;
			}
			List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)cRMEntities.ApispSelectLanguages());
			string culture = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				culture = apispSelectLanguages_Result.LanguageCollation;
			}
			if (!VersionBuyer.LinkAcc)
			{
				ServiceResult<IssueLkOrderResultViewModel> serviceResult = new ServiceResult<IssueLkOrderResultViewModel>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorMsgBuyModule", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), "LinkAcc");
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
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
			int result3 = 0;
			int.TryParse(num.ToString(), out result3);
			if (result3 == 0)
			{
				ServiceResult<IssueLkOrderResultViewModel> serviceResult = new ServiceResult<IssueLkOrderResultViewModel>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			SelectBaseInfoViewModel model2 = new SelectBaseInfoViewModel
			{
				UserName = model.UserName,
				Password = model.Password,
				ApiUserId = model.UserId,
				ApiLinkAccSettingDBId = model.ApiLinkAccSettingDBId,
				LanguageId = model.LanguageId,
				ApiOrderOprId = model.ApiOrderOprId
			};
			string text = "";
			if (result == 1)
			{
				if (model.ApiLinkAccOrdType.GetValueOrDefault() <= 0)
				{
					if (!string.IsNullOrWhiteSpace(text))
					{
						text += ",";
					}
					text += string.Format(MyResource.GetResourceString("ErrorItemIsNotEntered", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("LinkAccOrdType", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				}
				if (model.ApiLinkAccSettingDBId.GetValueOrDefault() <= 0)
				{
					if (!string.IsNullOrWhiteSpace(text))
					{
						text += ",";
					}
					text += string.Format(MyResource.GetResourceString("ErrorItemIsNotEntered", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("LinkAccSettingDB", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				}
				if (model.ApiLinkAccFiscalYearId.GetValueOrDefault() <= 0)
				{
					if (!string.IsNullOrWhiteSpace(text))
					{
						text += ",";
					}
					text += string.Format(MyResource.GetResourceString("ErrorItemIsNotEntered", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("LinkAccFiscalYear", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				}
				else
				{
					List<ApispLkSelectFiscalYear_Result> list2 = SelectLinkAccFiscalYearList(model2);
					if (list2 != null && Enumerable.Any<ApispLkSelectFiscalYear_Result>((IEnumerable<ApispLkSelectFiscalYear_Result>)list2))
					{
						ApispLkSelectFiscalYear_Result apispLkSelectFiscalYear_Result = Enumerable.FirstOrDefault<ApispLkSelectFiscalYear_Result>((IEnumerable<ApispLkSelectFiscalYear_Result>)list2, (Func<ApispLkSelectFiscalYear_Result, bool>)((ApispLkSelectFiscalYear_Result m) => m.ApiFiscalYearId == model.ApiLinkAccFiscalYearId.GetValueOrDefault()));
						if (apispLkSelectFiscalYear_Result == null)
						{
							if (!string.IsNullOrWhiteSpace(text))
							{
								text += ",";
							}
							text += string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("LinkAccFiscalYear", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
						}
					}
				}
				if (model.ApiLinkAccUserId.GetValueOrDefault() != 0)
				{
					List<ApispLkSelectUsers_Result> list3 = SelectLinkAccUsersList(model2);
					if (list3 != null && Enumerable.Any<ApispLkSelectUsers_Result>((IEnumerable<ApispLkSelectUsers_Result>)list3))
					{
						ApispLkSelectUsers_Result apispLkSelectUsers_Result = Enumerable.FirstOrDefault<ApispLkSelectUsers_Result>((IEnumerable<ApispLkSelectUsers_Result>)list3, (Func<ApispLkSelectUsers_Result, bool>)((ApispLkSelectUsers_Result m) => m.ApiUserId == model.ApiLinkAccUserId.GetValueOrDefault()));
						if (apispLkSelectUsers_Result == null)
						{
							if (!string.IsNullOrWhiteSpace(text))
							{
								text += ",";
							}
							text += string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("LinkAccUser", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
						}
					}
				}
				if (model.ApiLinkAccInventoryType.GetValueOrDefault() != 0)
				{
					List<SepidarInventoryTypeViewModel> list4 = SelectLinkInventoryTypeByOrdOprList(model2);
					if (list4 != null && Enumerable.Any<SepidarInventoryTypeViewModel>((IEnumerable<SepidarInventoryTypeViewModel>)list4))
					{
						SepidarInventoryTypeViewModel sepidarInventoryTypeViewModel = Enumerable.FirstOrDefault<SepidarInventoryTypeViewModel>((IEnumerable<SepidarInventoryTypeViewModel>)list4, (Func<SepidarInventoryTypeViewModel, bool>)((SepidarInventoryTypeViewModel m) => m.Id == model.ApiLinkAccInventoryType.GetValueOrDefault().ToString()));
						if (sepidarInventoryTypeViewModel == null)
						{
							if (!string.IsNullOrWhiteSpace(text))
							{
								text += ",";
							}
							text += string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("LinkAccInventoryType", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
						}
					}
				}
			}
			if (!string.IsNullOrWhiteSpace(text))
			{
				return new ServiceResult<IssueLkOrderResultViewModel>
				{
					Message = text,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			int userId = model.UserId;
			DateTime now = DateTime.Now;
			DateTime dateTime = now;
			string text2 = now.ToString("yyyyMMdd", new PersianCulture());
			short num2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = CRMIdealApi.Classes.Configuration.AppType;
			ObjectParameter objectParameter = new ObjectParameter("InsertedId", "");
			ObjectParameter objectParameter2 = new ObjectParameter("InsertedNumebr", "");
			ObjectParameter objectParameter3 = new ObjectParameter("ErrorMessage", "");
			int num3 = cRMEntities.ApispLkWSIssueOrUpdateOrder(model.ApiOrderId, model.ApiOrdNumber, model.ApiLinkAccOrdType, model.ApiLinkAccSettingDBId, model.ApiLinkAccFiscalYearId, model.ApiLinkAccUserId, model.ApiSendOrdPayToAcc, model.ApiSendPreOrderToAcc, model.ApiSendPordPayToAcc, model.ApiSendDocToAcc, model.ApiLinkAccInventoryType, model.ApiLinkAccDocType, model.ApiLinkAccInvIsReturn, userId, appType, objectParameter, objectParameter2, objectParameter3, model.ApiSendOrdCommToAcc);
			string resourceString = MyResource.GetResourceString("ErrorDoneOperationTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			string resourceString2 = MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			int result4 = 0;
			int.TryParse(num3.ToString(), out result4);
			if (result4 <= 0)
			{
				return new ServiceResult<IssueLkOrderResultViewModel>
				{
					Message = resourceString.Replace("<br>", "\r\n"),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			if (objectParameter3.Value != null && !string.IsNullOrWhiteSpace(objectParameter3.Value.ToString()))
			{
				string text3 = "";
				string text4 = objectParameter3.Value.ToString();
				if (!string.IsNullOrWhiteSpace(text4))
				{
					if (text4.IndexOf("No LinkAcc|", StringComparison.Ordinal) >= 0)
					{
						if (!string.IsNullOrWhiteSpace(text3))
						{
							text3 += "<br>";
						}
						text3 += MyResource.GetResourceString("ErrorNoSetLinkAccSystemId", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
					}
					if (text4.IndexOf("No OrdId|", StringComparison.Ordinal) >= 0)
					{
						if (!string.IsNullOrWhiteSpace(text3))
						{
							text3 += "<br>";
						}
						text3 += string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Order", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly));
					}
					if (text4.IndexOf("No LkDBId|", StringComparison.Ordinal) >= 0)
					{
						if (!string.IsNullOrWhiteSpace(text3))
						{
							text3 += "<br>";
						}
						text3 += (text3 += string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("LinkAccSettingDB", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly)));
					}
					if (text4.IndexOf("Not send to link acc|", StringComparison.Ordinal) >= 0)
					{
						if (!string.IsNullOrWhiteSpace(text3))
						{
							text3 += "<br>";
						}
						text3 += MyResource.GetResourceString("ErrorNotSendToLinkAcc", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
					}
					if (text4.IndexOf("Can not send LinkAcc|", StringComparison.Ordinal) >= 0)
					{
						if (!string.IsNullOrWhiteSpace(text3))
						{
							text3 += "<br>";
						}
						text3 += MyResource.GetResourceString("ErrorNotSendToLinkAcc", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
					}
					if (text4.IndexOf("Error|", StringComparison.Ordinal) >= 0)
					{
						if (!string.IsNullOrWhiteSpace(text3))
						{
							text3 += "<br>";
						}
						text3 += resourceString2;
						ErrorSignal.FromCurrentContext().Raise(new Exception(text4));
					}
					if (string.IsNullOrEmpty(text3) && !string.IsNullOrWhiteSpace(text4))
					{
						text3 = text4;
					}
					if (!string.IsNullOrWhiteSpace(text3))
					{
						text3 = text3 + "<br>" + resourceString2;
						return new ServiceResult<IssueLkOrderResultViewModel>
						{
							Message = text3.Replace("<br>", "\r\n"),
							Data = null,
							Status = ServiceResultStatus.Error
						};
					}
				}
			}
			if (objectParameter == null || objectParameter.Value.ToString() == "0" || string.IsNullOrWhiteSpace(objectParameter.Value.ToString()))
			{
				return new ServiceResult<IssueLkOrderResultViewModel>
				{
					Message = resourceString.Replace("<br>", "\r\n"),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			IssueLkOrderResultViewModel issueLkOrderResultViewModel = new IssueLkOrderResultViewModel();
			issueLkOrderResultViewModel.LinkAccOrderId = ((objectParameter.Value != null) ? objectParameter.Value.ToString() : "0");
			issueLkOrderResultViewModel.LinkAccOrderNumber = ((objectParameter2.Value != null) ? objectParameter2.Value.ToString() : "0");
			data = issueLkOrderResultViewModel;
			message = MyResource.GetResourceString("SuccessDoneRegister", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			status = ServiceResultStatus.Success;
		}
		catch (Exception ex)
		{
			string text5 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text5 = text5 + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text5)) ? (" (" + text5 + ")") : "");
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<IssueLkOrderResultViewModel>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<List<ApispSelectLinkAccSettingDB_Result>> SelectLinkAccSettingDB(SelectBaseInfoViewModel model)
	{
		CRMEntities cRMEntities = null;
		List<ApispSelectLinkAccSettingDB_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<List<ApispSelectLinkAccSettingDB_Result>>
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
				return new ServiceResult<List<ApispSelectLinkAccSettingDB_Result>>
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
				ServiceResult<List<ApispSelectLinkAccSettingDB_Result>> serviceResult = new ServiceResult<List<ApispSelectLinkAccSettingDB_Result>>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			List<ApispSelectLinkAccSettingDB_Result> list2 = Enumerable.ToList<ApispSelectLinkAccSettingDB_Result>((IEnumerable<ApispSelectLinkAccSettingDB_Result>)cRMEntities.ApispSelectLinkAccSettingDB(currLangId, result));
			if (list2 != null)
			{
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
		return new ServiceResult<List<ApispSelectLinkAccSettingDB_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	public List<ApispLkSelectFiscalYear_Result> SelectLinkAccFiscalYearList(SelectBaseInfoViewModel model)
	{
		CRMEntities cRMEntities = null;
		List<ApispLkSelectFiscalYear_Result> result = new List<ApispLkSelectFiscalYear_Result>();
		try
		{
			cRMEntities = new CRMEntities();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			int result2 = 0;
			if (apispSelectCrmsysSetting_Result != null)
			{
				int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out result2);
			}
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int.TryParse(model.LanguageId.ToString(), out var result3);
			if (result3 <= 0)
			{
				result3 = result2;
			}
			result = Enumerable.ToList<ApispLkSelectFiscalYear_Result>((IEnumerable<ApispLkSelectFiscalYear_Result>)cRMEntities.ApispLkSelectFiscalYear(model.ApiLinkAccSettingDBId, result3, result2));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return result;
	}

	[HttpPost]
	public ServiceResult<List<ApispLkSelectFiscalYear_Result>> SelectLinkAccFiscalYear(SelectBaseInfoViewModel model)
	{
		CRMEntities cRMEntities = null;
		List<ApispLkSelectFiscalYear_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<List<ApispLkSelectFiscalYear_Result>>
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
				return new ServiceResult<List<ApispLkSelectFiscalYear_Result>>
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
			if (!VersionBuyer.LinkAcc)
			{
				ServiceResult<List<ApispLkSelectFiscalYear_Result>> serviceResult = new ServiceResult<List<ApispLkSelectFiscalYear_Result>>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorMsgBuyModule", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), "LinkAcc");
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
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
				ServiceResult<List<ApispLkSelectFiscalYear_Result>> serviceResult = new ServiceResult<List<ApispLkSelectFiscalYear_Result>>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			List<ApispLkSelectFiscalYear_Result> list2 = SelectLinkAccFiscalYearList(model);
			if (list2 != null)
			{
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
		return new ServiceResult<List<ApispLkSelectFiscalYear_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	public List<ApispLkSelectUsers_Result> SelectLinkAccUsersList(SelectBaseInfoViewModel model)
	{
		CRMEntities cRMEntities = null;
		List<ApispLkSelectUsers_Result> result = new List<ApispLkSelectUsers_Result>();
		try
		{
			cRMEntities = new CRMEntities();
			CommonClass commonClass = new CommonClass();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			int result2 = 0;
			if (apispSelectCrmsysSetting_Result != null)
			{
				int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out result2);
			}
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int.TryParse(model.LanguageId.ToString(), out var result3);
			if (result3 <= 0)
			{
				result3 = result2;
			}
			result = Enumerable.ToList<ApispLkSelectUsers_Result>((IEnumerable<ApispLkSelectUsers_Result>)cRMEntities.ApispLkSelectUsers(model.ApiLinkAccSettingDBId, result3, result2));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return result;
	}

	[HttpPost]
	public ServiceResult<List<ApispLkSelectUsers_Result>> SelectLinkAccUsers(SelectBaseInfoViewModel model)
	{
		CRMEntities cRMEntities = null;
		List<ApispLkSelectUsers_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<List<ApispLkSelectUsers_Result>>
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
				return new ServiceResult<List<ApispLkSelectUsers_Result>>
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
			if (!VersionBuyer.LinkAcc)
			{
				ServiceResult<List<ApispLkSelectUsers_Result>> serviceResult = new ServiceResult<List<ApispLkSelectUsers_Result>>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorMsgBuyModule", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), "LinkAcc");
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
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
				ServiceResult<List<ApispLkSelectUsers_Result>> serviceResult = new ServiceResult<List<ApispLkSelectUsers_Result>>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			List<ApispLkSelectUsers_Result> list2 = SelectLinkAccUsersList(model);
			if (list2 != null)
			{
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
		return new ServiceResult<List<ApispLkSelectUsers_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	public List<SepidarInventoryTypeViewModel> SelectLinkInventoryTypeByOrdOprList(SelectBaseInfoViewModel model)
	{
		CRMEntities cRMEntities = null;
		List<SepidarInventoryTypeViewModel> list = new List<SepidarInventoryTypeViewModel>();
		try
		{
			cRMEntities = new CRMEntities();
			CommonClass commonClass = new CommonClass();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			int result = 0;
			if (apispSelectCrmsysSetting_Result != null)
			{
				int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out result);
			}
			if (result <= 0)
			{
				result = 1065;
			}
			int.TryParse(model.LanguageId.ToString(), out var currLangId);
			if (currLangId <= 0)
			{
				currLangId = result;
			}
			List<ApispSelectLanguages_Result> list2 = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)cRMEntities.ApispSelectLanguages());
			string culture = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list2, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				culture = apispSelectLanguages_Result.LanguageCollation;
			}
			int result2 = 0;
			int.TryParse(model.ApiOrderOprId.ToString(), out result2);
			ApispSelectOrderOprById_Result apispSelectOrderOprById_Result = Enumerable.FirstOrDefault<ApispSelectOrderOprById_Result>((IEnumerable<ApispSelectOrderOprById_Result>)cRMEntities.ApispSelectOrderOprById(result2, currLangId, result));
			if (apispSelectOrderOprById_Result != null)
			{
				int docOprId = apispSelectOrderOprById_Result.ApiDocOprId.GetValueOrDefault();
				List<ApispSelectDocOpr_Result> list3 = Enumerable.ToList<ApispSelectDocOpr_Result>((IEnumerable<ApispSelectDocOpr_Result>)cRMEntities.ApispSelectDocOpr(0, 0, currLangId, result));
				if (list3 != null && Enumerable.Any<ApispSelectDocOpr_Result>((IEnumerable<ApispSelectDocOpr_Result>)list3))
				{
					ApispSelectDocOpr_Result apispSelectDocOpr_Result = Enumerable.FirstOrDefault<ApispSelectDocOpr_Result>((IEnumerable<ApispSelectDocOpr_Result>)list3, (Func<ApispSelectDocOpr_Result, bool>)((ApispSelectDocOpr_Result m) => m.ApiDocOprID == docOprId));
					if (apispSelectDocOpr_Result != null)
					{
						int valueOrDefault = apispSelectDocOpr_Result.ApiOprType.GetValueOrDefault();
						int num = 2;
						switch (valueOrDefault)
						{
						case 1:
							num = 1;
							break;
						case 3:
							num = 3;
							break;
						}
						bool isReturn = false;
						if (docOprId == 10 || docOprId == 21)
						{
							isReturn = true;
						}
						switch (num)
						{
						case 1:
							if (docOprId == 10 || docOprId == 12)
							{
								string docType3 = "2";
								SepidarInventoryTypeViewModel sepidarInventoryTypeViewModel = new SepidarInventoryTypeViewModel();
								sepidarInventoryTypeViewModel.Title = MyResource.GetResourceString("OtherSystemsSepInvDelTypeI", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
								sepidarInventoryTypeViewModel.Id = "1";
								sepidarInventoryTypeViewModel.DocType = docType3;
								sepidarInventoryTypeViewModel.IsReturn = isReturn;
								SepidarInventoryTypeViewModel item3 = sepidarInventoryTypeViewModel;
								list.Add(item3);
								sepidarInventoryTypeViewModel = new SepidarInventoryTypeViewModel();
								sepidarInventoryTypeViewModel.Title = MyResource.GetResourceString("OtherSystemsSepInvDelTypeII", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
								sepidarInventoryTypeViewModel.Id = "2";
								sepidarInventoryTypeViewModel.DocType = docType3;
								sepidarInventoryTypeViewModel.IsReturn = isReturn;
								item3 = sepidarInventoryTypeViewModel;
								list.Add(item3);
								sepidarInventoryTypeViewModel = new SepidarInventoryTypeViewModel();
								sepidarInventoryTypeViewModel.Title = MyResource.GetResourceString("OtherSystemsSepInvDelTypeIII", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
								sepidarInventoryTypeViewModel.Id = "3";
								sepidarInventoryTypeViewModel.DocType = docType3;
								sepidarInventoryTypeViewModel.IsReturn = isReturn;
								item3 = sepidarInventoryTypeViewModel;
								list.Add(item3);
							}
							else
							{
								string docType4 = "1";
								SepidarInventoryTypeViewModel sepidarInventoryTypeViewModel = new SepidarInventoryTypeViewModel();
								sepidarInventoryTypeViewModel.Title = MyResource.GetResourceString("OtherSystemsSepInvRecTypeI", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
								sepidarInventoryTypeViewModel.Id = "1";
								sepidarInventoryTypeViewModel.DocType = docType4;
								sepidarInventoryTypeViewModel.IsReturn = isReturn;
								SepidarInventoryTypeViewModel item4 = sepidarInventoryTypeViewModel;
								list.Add(item4);
								sepidarInventoryTypeViewModel = new SepidarInventoryTypeViewModel();
								sepidarInventoryTypeViewModel.Title = MyResource.GetResourceString("OtherSystemsSepInvRecTypeII", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
								sepidarInventoryTypeViewModel.Id = "2";
								sepidarInventoryTypeViewModel.DocType = docType4;
								sepidarInventoryTypeViewModel.IsReturn = isReturn;
								item4 = sepidarInventoryTypeViewModel;
								list.Add(item4);
								sepidarInventoryTypeViewModel = new SepidarInventoryTypeViewModel();
								sepidarInventoryTypeViewModel.Title = MyResource.GetResourceString("OtherSystemsSepInvRecTypeIII", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
								sepidarInventoryTypeViewModel.Id = "3";
								sepidarInventoryTypeViewModel.DocType = docType4;
								sepidarInventoryTypeViewModel.IsReturn = isReturn;
								item4 = sepidarInventoryTypeViewModel;
								list.Add(item4);
								sepidarInventoryTypeViewModel = new SepidarInventoryTypeViewModel();
								sepidarInventoryTypeViewModel.Title = MyResource.GetResourceString("OtherSystemsSepInvRecTypeIV", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
								sepidarInventoryTypeViewModel.Id = "4";
								sepidarInventoryTypeViewModel.DocType = docType4;
								sepidarInventoryTypeViewModel.IsReturn = isReturn;
								item4 = sepidarInventoryTypeViewModel;
								list.Add(item4);
								sepidarInventoryTypeViewModel = new SepidarInventoryTypeViewModel();
								sepidarInventoryTypeViewModel.Title = MyResource.GetResourceString("OtherSystemsSepInvRecTypeV", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
								sepidarInventoryTypeViewModel.Id = "5";
								sepidarInventoryTypeViewModel.DocType = docType4;
								sepidarInventoryTypeViewModel.IsReturn = isReturn;
								item4 = sepidarInventoryTypeViewModel;
								list.Add(item4);
							}
							break;
						case 2:
							if (docOprId == 21)
							{
								string docType = "1";
								SepidarInventoryTypeViewModel sepidarInventoryTypeViewModel = new SepidarInventoryTypeViewModel();
								sepidarInventoryTypeViewModel.Title = MyResource.GetResourceString("OtherSystemsSepInvRecTypeI", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
								sepidarInventoryTypeViewModel.Id = "1";
								sepidarInventoryTypeViewModel.DocType = docType;
								sepidarInventoryTypeViewModel.IsReturn = isReturn;
								SepidarInventoryTypeViewModel item = sepidarInventoryTypeViewModel;
								list.Add(item);
								sepidarInventoryTypeViewModel = new SepidarInventoryTypeViewModel();
								sepidarInventoryTypeViewModel.Title = MyResource.GetResourceString("OtherSystemsSepInvRecTypeII", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
								sepidarInventoryTypeViewModel.Id = "2";
								sepidarInventoryTypeViewModel.DocType = docType;
								sepidarInventoryTypeViewModel.IsReturn = isReturn;
								item = sepidarInventoryTypeViewModel;
								list.Add(item);
								sepidarInventoryTypeViewModel = new SepidarInventoryTypeViewModel();
								sepidarInventoryTypeViewModel.Title = MyResource.GetResourceString("OtherSystemsSepInvRecTypeIII", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
								sepidarInventoryTypeViewModel.Id = "3";
								sepidarInventoryTypeViewModel.DocType = docType;
								sepidarInventoryTypeViewModel.IsReturn = isReturn;
								item = sepidarInventoryTypeViewModel;
								list.Add(item);
								sepidarInventoryTypeViewModel = new SepidarInventoryTypeViewModel();
								sepidarInventoryTypeViewModel.Title = MyResource.GetResourceString("OtherSystemsSepInvRecTypeIV", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
								sepidarInventoryTypeViewModel.Id = "4";
								sepidarInventoryTypeViewModel.DocType = docType;
								sepidarInventoryTypeViewModel.IsReturn = isReturn;
								item = sepidarInventoryTypeViewModel;
								list.Add(item);
								sepidarInventoryTypeViewModel = new SepidarInventoryTypeViewModel();
								sepidarInventoryTypeViewModel.Title = MyResource.GetResourceString("OtherSystemsSepInvRecTypeV", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
								sepidarInventoryTypeViewModel.Id = "5";
								sepidarInventoryTypeViewModel.DocType = docType;
								sepidarInventoryTypeViewModel.IsReturn = isReturn;
								item = sepidarInventoryTypeViewModel;
								list.Add(item);
							}
							else
							{
								string docType2 = "2";
								SepidarInventoryTypeViewModel sepidarInventoryTypeViewModel = new SepidarInventoryTypeViewModel();
								sepidarInventoryTypeViewModel.Title = MyResource.GetResourceString("OtherSystemsSepInvDelTypeI", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
								sepidarInventoryTypeViewModel.Id = "1";
								sepidarInventoryTypeViewModel.DocType = docType2;
								sepidarInventoryTypeViewModel.IsReturn = isReturn;
								SepidarInventoryTypeViewModel item2 = sepidarInventoryTypeViewModel;
								list.Add(item2);
								sepidarInventoryTypeViewModel = new SepidarInventoryTypeViewModel();
								sepidarInventoryTypeViewModel.Title = MyResource.GetResourceString("OtherSystemsSepInvDelTypeII", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
								sepidarInventoryTypeViewModel.Id = "2";
								sepidarInventoryTypeViewModel.DocType = docType2;
								sepidarInventoryTypeViewModel.IsReturn = isReturn;
								item2 = sepidarInventoryTypeViewModel;
								list.Add(item2);
								sepidarInventoryTypeViewModel = new SepidarInventoryTypeViewModel();
								sepidarInventoryTypeViewModel.Title = MyResource.GetResourceString("OtherSystemsSepInvDelTypeIII", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
								sepidarInventoryTypeViewModel.Id = "3";
								sepidarInventoryTypeViewModel.DocType = docType2;
								sepidarInventoryTypeViewModel.IsReturn = isReturn;
								item2 = sepidarInventoryTypeViewModel;
								list.Add(item2);
							}
							break;
						}
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return list;
	}

	[HttpPost]
	public ServiceResult<List<SepidarInventoryTypeViewModel>> SelectLinkAccInventoryTypeByOrdOpr(SelectBaseInfoViewModel model)
	{
		CRMEntities cRMEntities = null;
		List<SepidarInventoryTypeViewModel> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<List<SepidarInventoryTypeViewModel>>
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
				return new ServiceResult<List<SepidarInventoryTypeViewModel>>
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
			if (!VersionBuyer.LinkAcc)
			{
				ServiceResult<List<SepidarInventoryTypeViewModel>> serviceResult = new ServiceResult<List<SepidarInventoryTypeViewModel>>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorMsgBuyModule", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), "LinkAcc");
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
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
				ServiceResult<List<SepidarInventoryTypeViewModel>> serviceResult = new ServiceResult<List<SepidarInventoryTypeViewModel>>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			List<SepidarInventoryTypeViewModel> list2 = SelectLinkInventoryTypeByOrdOprList(model);
			if (list2 != null)
			{
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
		return new ServiceResult<List<SepidarInventoryTypeViewModel>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}
}
