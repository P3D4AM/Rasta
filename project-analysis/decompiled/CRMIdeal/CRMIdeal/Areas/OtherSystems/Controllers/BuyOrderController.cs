using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.General.Calendar;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.OtherSystems.Controllers;

public class BuyOrderController : Controller
{
	public class ThreadHub
	{
		public class ThreadHubObj
		{
			public bool? IsDone { get; set; }

			public string message { get; set; }

			public int? Percent { get; set; }

			public DateTime RegDate { get; set; }
		}

		private static List<ThreadHubObj> lstThreads = new List<ThreadHubObj>();

		public static int GetLastIndex()
		{
			return lstThreads.Count - 1;
		}

		public static ThreadHubObj GetThreadResult(int indx = -1)
		{
			if (indx != -1 && lstThreads.Count - 1 >= indx)
			{
				return lstThreads[indx];
			}
			return null;
		}

		public static void SetThreadResult(int indx = -1, int percent = 0, string message = null, bool? isDone = null)
		{
			if (indx != -1 && lstThreads.Count - 1 >= indx)
			{
				if (isDone.HasValue)
				{
					lstThreads[indx].IsDone = isDone;
				}
				if (percent != -1)
				{
					lstThreads[indx].Percent = percent;
				}
				if (message != null)
				{
					lstThreads[indx].message = message;
				}
			}
		}

		public static int AddThread(int percent = 0, string message = null, bool? isDone = null)
		{
			for (int i = 0; i < lstThreads.Count; i++)
			{
				if (lstThreads[i] != null && lstThreads[i].RegDate.AddHours(6.0) <= DateTime.Now)
				{
					lstThreads[i] = null;
				}
			}
			lstThreads.Add(new ThreadHubObj
			{
				IsDone = isDone,
				message = message,
				Percent = percent,
				RegDate = DateTime.Now
			});
			return GetLastIndex();
		}

		public static void ClearThreads(bool forceEmpty = false)
		{
			if (lstThreads.Count == Enumerable.ToList<ThreadHubObj>(Enumerable.Where<ThreadHubObj>((IEnumerable<ThreadHubObj>)lstThreads, (Func<ThreadHubObj, bool>)((ThreadHubObj x) => x == null))).Count)
			{
				lstThreads.Clear();
			}
			if (forceEmpty)
			{
				lstThreads.Clear();
			}
		}

		public static void RemoveThread(int indx = -1, bool autoEmpty = false)
		{
			if (indx != -1)
			{
				lstThreads[indx] = null;
			}
			if (autoEmpty)
			{
				ClearThreads();
			}
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public int bordId;

		public int payId;
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMLinkSpEntities _dbLink = new CRMLinkSpEntities();

	public ActionResult SepBordSendToAcc(int mode, int position = 0, int payId = 0, int linkAccSettingDBId = 0)
	{
		base.ViewBag.Mode = mode;
		base.ViewBag.Position = position;
		string text = "";
		string text2 = "";
		switch (position)
		{
		case 0:
			switch (mode)
			{
			case 1:
				text = "frmBuyOrder";
				text2 = "actSendToAcc";
				break;
			case 2:
				text = "frmBuyOrder";
				text2 = "actSendPayToAcc";
				break;
			case 3:
				text = "frmBuyOrder";
				text2 = "actSendAllPayToAcc";
				break;
			default:
				return RedirectToAction("Login", "Account", (object)new
				{
					area = "",
					d = DateTime.Now
				});
			}
			break;
		case 1:
			text = "frmBordLinkAccDetails";
			text2 = "actAddLinkBordToAcc";
			break;
		case 2:
			text = "frmBordLinkAccDetails";
			text2 = "actAddLinkBordPayToAcc";
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
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		base.ViewBag.LinkAccSettingDBList = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccSettingDB(1);
		return View();
	}

	[AjaxOnly]
	public string SepActSendToAcc(int mode, int bordId, int payId, int sepFiscalYearRef, int sepUserId, bool sendBordPayToAcc = false, int position = 0, int linkAccSettingDBId = 0)
	{
		_003C_003Ec__DisplayClass4_0 _003C_003Ec__DisplayClass4_ = new _003C_003Ec__DisplayClass4_0();
		_003C_003Ec__DisplayClass4_.bordId = bordId;
		_003C_003Ec__DisplayClass4_.payId = payId;
		string text = "";
		try
		{
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			base.ViewBag.Mode = mode;
			switch (mode)
			{
			case 1:
			{
				string formName = "frmBuyOrder";
				string actionName = "actSendToAcc";
				if (position == 1)
				{
					formName = "frmBordLinkAccDetails";
					actionName = "actAddLinkBordToAcc";
				}
				if (!UserLogin.IsUserAccess(formName, actionName, currentUser))
				{
					return Messages.ErrorNotAccess + "|";
				}
				if (_003C_003Ec__DisplayClass4_.bordId > 0)
				{
					DbSet<WSBuyOrder> wSBuyOrder2 = _dbTbl.WSBuyOrder;
					ParameterExpression val = Expression.Parameter(typeof(WSBuyOrder), "m");
					if (Queryable.FirstOrDefault<WSBuyOrder>((IQueryable<WSBuyOrder>)wSBuyOrder2, Expression.Lambda<Func<WSBuyOrder, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass4_, typeof(_003C_003Ec__DisplayClass4_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) != null)
					{
						string errorMessage2 = "";
						if (!BuyOrder.SendToLinkAccNeedVerify(_003C_003Ec__DisplayClass4_.bordId, ref errorMessage2))
						{
							return errorMessage2 + "|";
						}
						ObjectParameter objectParameter2 = new ObjectParameter("insertedId", 0);
						ObjectParameter objectParameter3 = new ObjectParameter("errorMessage", "");
						ObjectParameter objectParameter4 = new ObjectParameter("buyOrderNumebr", 0);
						CRMLinkSpEntities dbLink2 = _dbLink;
						int? buyOrderId2 = _003C_003Ec__DisplayClass4_.bordId;
						int? crmUserId = UserLogin.CurrentUser.UserId;
						string appType = Configuration.AppType;
						ObjectParameter errorMessage = objectParameter2;
						ObjectParameter buyOrderNumebr = objectParameter4;
						ObjectParameter errorMessage3 = objectParameter3;
						dbLink2.CRMspLkSepWSIssueBuyOrder(buyOrderId2, null, sepFiscalYearRef, crmUserId, appType, errorMessage, buyOrderNumebr, errorMessage3, sepUserId, sendBordPayToAcc, linkAccSettingDBId);
						if (objectParameter3.Value != null)
						{
							if (!string.IsNullOrEmpty(objectParameter3.Value.ToString()))
							{
								string text2 = "";
								if (objectParameter4.Value != null)
								{
									text2 = objectParameter4.Value.ToString() ?? "";
									if (!string.IsNullOrWhiteSpace(text2) && text2 == "-3")
									{
										return Messages.msgErrorfinancialYearWrong;
									}
								}
								string text3 = objectParameter3.Value.ToString();
								if (!string.IsNullOrWhiteSpace(text3) && text3.IndexOf("Financially incorrect in bordpayment", StringComparison.Ordinal) >= 0)
								{
									text3 = text3.Replace("Financially incorrect in bordpayment", "");
									text3 = text3.Replace(",,", "");
									text3 = text3 + ",(" + Labels.lblBordPay + ") " + Messages.msgErrorfinancialYearWrong;
									text3 = text3.TrimStart(new char[1] { ' ' }).TrimEnd(new char[1] { ' ' });
									return text3.TrimStart(new char[1] { ',' }).TrimEnd(new char[1] { ',' });
								}
								if (!string.IsNullOrWhiteSpace(text3) && text3.IndexOf("No Items", StringComparison.Ordinal) >= 0)
								{
									text3 = text3.Replace("No Items", "");
									text3 = text3.Replace(",,", "");
									text3 = text3 + "," + string.Format(Messages.msgErrorNotHaveItems, Labels.lblBOrd);
									text3 = text3.TrimStart(new char[1] { ' ' }).TrimEnd(new char[1] { ' ' });
									return text3.TrimStart(new char[1] { ',' }).TrimEnd(new char[1] { ',' });
								}
								text = objectParameter3.Value.ToString();
								break;
							}
							string text4 = "";
							if (objectParameter4.Value != null)
							{
								text4 = objectParameter4.Value.ToString() ?? "";
								if (!string.IsNullOrWhiteSpace(text4) && text4 == "-3")
								{
									return Messages.msgErrorfinancialYearWrong;
								}
							}
							text = "1|" + text4;
							break;
						}
						string text5 = "";
						if (objectParameter4.Value != null)
						{
							text5 = objectParameter4.Value.ToString() ?? "";
							if (!string.IsNullOrWhiteSpace(text5) && text5 == "-3")
							{
								return Messages.msgErrorfinancialYearWrong;
							}
						}
						text = "1|" + text5;
					}
					else
					{
						text = Messages.ErrorNotFound + "|";
					}
				}
				else
				{
					text = Messages.ErrorNotFound + "|";
				}
				break;
			}
			case 2:
			{
				string formName2 = "frmBuyOrder";
				string actionName2 = "actSendPayToAcc";
				if (position == 2)
				{
					formName2 = "frmBordLinkAccDetails";
					actionName2 = "actAddLinkBordPayToAcc";
				}
				if (!UserLogin.IsUserAccess(formName2, actionName2, currentUser))
				{
					return Messages.ErrorNotAccess + "|";
				}
				if (_003C_003Ec__DisplayClass4_.payId > 0)
				{
					DbSet<WSBuyOrderPayments> wSBuyOrderPayments = _dbTbl.WSBuyOrderPayments;
					ParameterExpression val = Expression.Parameter(typeof(WSBuyOrderPayments), "m");
					if (Queryable.FirstOrDefault<WSBuyOrderPayments>((IQueryable<WSBuyOrderPayments>)wSBuyOrderPayments, Expression.Lambda<Func<WSBuyOrderPayments, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass4_, typeof(_003C_003Ec__DisplayClass4_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) != null)
					{
						ObjectParameter objectParameter5 = new ObjectParameter("insertedId", 0);
						ObjectParameter objectParameter6 = new ObjectParameter("errorMessage", "");
						ObjectParameter objectParameter7 = new ObjectParameter("insertedNumber", 0);
						CRMLinkSpEntities dbLink3 = _dbLink;
						int? buyOrderPaymentId = _003C_003Ec__DisplayClass4_.payId;
						int? crmUserId = UserLogin.CurrentUser.UserId;
						string appType = Configuration.AppType;
						ObjectParameter errorMessage3 = objectParameter5;
						ObjectParameter buyOrderNumebr = objectParameter7;
						ObjectParameter errorMessage = objectParameter6;
						dbLink3.CRMspLkSepWSInsertUpdateBuyOrderPayment(buyOrderPaymentId, sepFiscalYearRef, crmUserId, appType, errorMessage3, buyOrderNumebr, errorMessage, linkAccSettingDBId);
						if (objectParameter6.Value != null)
						{
							if (!string.IsNullOrEmpty(objectParameter6.Value.ToString()))
							{
								string text6 = "";
								if (objectParameter7.Value != null)
								{
									text6 = objectParameter7.Value.ToString() ?? "";
									if (!string.IsNullOrWhiteSpace(text6))
									{
										switch (text6)
										{
										case "-2":
											return Messages.msgErrorNotTransferPayWithNegativeAmountToSepidar;
										case "-3":
											return Messages.msgErrorfinancialYearWrong;
										case "-4":
											return Messages.msgErrorNotTransferPayNoAmountToSepidar;
										case "-5":
											return Messages.msgErrorNotTransferPayWithPositiveAmountToSepidar;
										}
									}
								}
								text = objectParameter6.Value.ToString();
								break;
							}
							string text7 = "";
							if (objectParameter7.Value != null)
							{
								text7 = objectParameter7.Value.ToString() ?? "";
								if (!string.IsNullOrWhiteSpace(text7))
								{
									switch (text7)
									{
									case "-2":
										return Messages.msgErrorNotTransferPayWithNegativeAmountToSepidar;
									case "-3":
										return Messages.msgErrorfinancialYearWrong;
									case "-4":
										return Messages.msgErrorNotTransferPayNoAmountToSepidar;
									case "-5":
										return Messages.msgErrorNotTransferPayWithPositiveAmountToSepidar;
									}
									text7 = string.Format(Labels.BordPayListAccLinkHeaderNumber, text7);
								}
							}
							text = "1|" + text7;
							break;
						}
						string text8 = "";
						if (objectParameter7.Value != null)
						{
							text8 = objectParameter7.Value.ToString() ?? "";
							if (!string.IsNullOrWhiteSpace(text8))
							{
								switch (text8)
								{
								case "-2":
									return Messages.msgErrorNotTransferPayWithNegativeAmountToSepidar;
								case "-3":
									return Messages.msgErrorfinancialYearWrong;
								case "-4":
									return Messages.msgErrorNotTransferPayNoAmountToSepidar;
								case "-5":
									return Messages.msgErrorNotTransferPayWithPositiveAmountToSepidar;
								}
								text8 = string.Format(Labels.BordPayListAccLinkHeaderNumber, text8);
							}
						}
						text = "1|" + text8;
					}
					else
					{
						text = Messages.ErrorNotFound + "|";
					}
				}
				else
				{
					text = Messages.ErrorNotFound + "|";
				}
				break;
			}
			case 3:
				if (!UserLogin.IsUserAccess("frmBuyOrder", "actSendAllPayToAcc", currentUser))
				{
					return Messages.ErrorNotAccess + "|";
				}
				if (_003C_003Ec__DisplayClass4_.bordId > 0)
				{
					DbSet<WSBuyOrder> wSBuyOrder = _dbTbl.WSBuyOrder;
					ParameterExpression val = Expression.Parameter(typeof(WSBuyOrder), "m");
					if (Queryable.FirstOrDefault<WSBuyOrder>((IQueryable<WSBuyOrder>)wSBuyOrder, Expression.Lambda<Func<WSBuyOrder, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass4_, typeof(_003C_003Ec__DisplayClass4_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) != null)
					{
						ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
						CRMLinkSpEntities dbLink = _dbLink;
						int? buyOrderId = _003C_003Ec__DisplayClass4_.bordId;
						int? crmUserId = UserLogin.CurrentUser.UserId;
						string appType = Configuration.AppType;
						ObjectParameter errorMessage = objectParameter;
						dbLink.CRMspLkSepWSInsertUpdateBuyOrderPaymentsAll(buyOrderId, sepFiscalYearRef, crmUserId, appType, errorMessage, linkAccSettingDBId);
						if (objectParameter.Value != null)
						{
							if (!string.IsNullOrEmpty(objectParameter.Value.ToString()))
							{
								text = objectParameter.Value.ToString();
								if (!string.IsNullOrWhiteSpace(text) && text.IndexOf("Financially incorrect", StringComparison.Ordinal) >= 0)
								{
									text = text.Replace("Financially incorrect ,", "");
									text = text.Replace(",,", "");
									text = text + "," + Messages.msgErrorfinancialYearWrong;
									text = text.TrimStart(new char[1] { ' ' }).TrimEnd(new char[1] { ' ' });
									text = text.TrimStart(new char[1] { ',' }).TrimEnd(new char[1] { ',' });
								}
							}
							else
							{
								text = "1|" + Messages.msgSuccessAction;
							}
						}
						else
						{
							text = "1|" + Messages.msgSuccessAction;
						}
					}
					else
					{
						text = Messages.ErrorNotFound + "|";
					}
				}
				else
				{
					text = Messages.ErrorNotFound + "|";
				}
				break;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			text = Messages.msgErrorRunFunction + "|";
		}
		return text;
	}

	[AjaxOnly]
	public string GetSepPayIsCqh(int payId, int linkAccSettingDBId = 0)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (payId != 0)
			{
				bool flag = false;
				try
				{
					CRMspLkSepWSSelectBuyOrderPaymentsById_Result cRMspLkSepWSSelectBuyOrderPaymentsById_Result = Enumerable.FirstOrDefault<CRMspLkSepWSSelectBuyOrderPaymentsById_Result>((IEnumerable<CRMspLkSepWSSelectBuyOrderPaymentsById_Result>)_dbLink.CRMspLkSepWSSelectBuyOrderPaymentsById(payId, lCID, result2, linkAccSettingDBId));
					if (cRMspLkSepWSSelectBuyOrderPaymentsById_Result != null)
					{
						int result3 = 0;
						int.TryParse(cRMspLkSepWSSelectBuyOrderPaymentsById_Result.SepDetailType.ToString(), out result3);
						flag = result3 == 2;
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
				}
				base.ViewBag.PayIsCqh = flag;
				result = flag.ToString();
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			result = Messages.msgErrorRunFunction + "|";
		}
		return result;
	}

	[AjaxOnly]
	public string GetSepPayIsCqhAndLastFp(int payId, int linkAccSettingDBId = 0)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (payId != 0)
			{
				bool flag = false;
				int result3 = 0;
				try
				{
					CRMspLkSepWSSelectBuyOrderPaymentsById_Result cRMspLkSepWSSelectBuyOrderPaymentsById_Result = Enumerable.FirstOrDefault<CRMspLkSepWSSelectBuyOrderPaymentsById_Result>((IEnumerable<CRMspLkSepWSSelectBuyOrderPaymentsById_Result>)_dbLink.CRMspLkSepWSSelectBuyOrderPaymentsById(payId, lCID, result2, linkAccSettingDBId));
					if (cRMspLkSepWSSelectBuyOrderPaymentsById_Result != null)
					{
						int result4 = 0;
						int.TryParse(cRMspLkSepWSSelectBuyOrderPaymentsById_Result.SepDetailType.ToString(), out result4);
						flag = result4 == 2;
					}
					CRMspLkSepSelectFiscalYear_Result cRMspLkSepSelectFiscalYear_Result = Enumerable.FirstOrDefault<CRMspLkSepSelectFiscalYear_Result>((IEnumerable<CRMspLkSepSelectFiscalYear_Result>)_dbLink.CRMspLkSepSelectFiscalYear(linkAccSettingDBId, lCID, result2));
					if (cRMspLkSepSelectFiscalYear_Result != null)
					{
						int.TryParse(cRMspLkSepSelectFiscalYear_Result.FiscalYearId.ToString(), out result3);
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
				}
				result = flag + "|" + result3;
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "frmBuyOrder", ActionName = "actImportFromAcc")]
	public ActionResult SepImportBuyOrder()
	{
		GetBuyOrderOpr();
		GetWareHouse();
		GetPaymentType();
		GetBordReferUser();
		GetCrmFinancialPeriod();
		base.ViewBag.LinkAccSettingDBList = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccSettingDB(1);
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmImportFromAcc", ActionName = "actShowInfo")]
	public ActionResult SepBuyOrder_Read([DataSourceRequest] DataSourceRequest request, int pageNumber, string fDate = "", string tDate = "", int value = 0, int linkAccSettingDBId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SepBuyOrderViewModel> list = new List<SepBuyOrderViewModel>();
		try
		{
			int value2 = 500;
			pageNumber = ((pageNumber <= 0) ? 1 : pageNumber);
			DateTime value3 = DateTime.Now;
			DateTime value4 = DateTime.Now;
			if (!string.IsNullOrEmpty(fDate))
			{
				value3 = DateTime.Parse(PersianDate.GetFormatetdDate(fDate.Replace("/", "")) + " 00:00:00", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			if (!string.IsNullOrEmpty(tDate))
			{
				value4 = DateTime.Parse(PersianDate.GetFormatetdDate(tDate.Replace("/", "")) + " 23:59:59", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			foreach (CRMspLkSepWSSelectBuyOrderFromSep_Result item2 in Enumerable.ToList<CRMspLkSepWSSelectBuyOrderFromSep_Result>((IEnumerable<CRMspLkSepWSSelectBuyOrderFromSep_Result>)_dbLink.CRMspLkSepWSSelectBuyOrderFromSep((!string.IsNullOrEmpty(fDate)) ? new DateTime?(value3) : null, (!string.IsNullOrEmpty(tDate)) ? new DateTime?(value4) : null, value, pageNumber, value2, lCID, result, linkAccSettingDBId)))
			{
				SepBuyOrderViewModel item = new SepBuyOrderViewModel
				{
					InventoryPurchaseInvoiceID = item2.InventoryPurchaseInvoiceID,
					Vendor = item2.Vendor,
					Number = item2.Number,
					Date = item2.Date,
					DatePersian = (item2.Date.HasValue ? item2.Date.Value.ToString("yyyy/MM/dd") : ""),
					TotalNetPrice = item2.TotalNetPrice,
					ItemCount = item2.ItemCount,
					BuyOrderId = item2.BuyOrderId,
					RowNumber = item2.RowNumber,
					AllPage = item2.AllPage
				};
				list.Add(item);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	public int SepImportInfo(string records, int buyOrderOprId, int bordpayTypeId, int bordReferUserId, int whId, int pageNumber, string fDate = "", string tDate = "", int value = 0, bool isUsedCmpReferUserId = false, int crmFPId = 0, bool addBordPayment = false, int linkAccSettingDBId = 0, int pagesCnt = 0)
	{
		int indx = -1;
		try
		{
			indx = ThreadHub.AddThread();
			new Thread((ThreadStart)delegate
			{
				SepImportInfoAsync(records, buyOrderOprId, bordpayTypeId, bordReferUserId, whId, pageNumber, fDate, tDate, value, isUsedCmpReferUserId, crmFPId, addBordPayment, linkAccSettingDBId, pagesCnt, indx);
			}).Start();
		}
		catch (Exception ex)
		{
			ThreadHub.SetThreadResult(indx, 0, ex.Message, false);
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		return indx;
	}

	public void SepImportInfoAsync(string records, int buyOrderOprId, int bordpayTypeId, int bordReferUserId, int whId, int pageNumber, string fDate = "", string tDate = "", int value = 0, bool isUsedCmpReferUserId = false, int crmFPId = 0, bool addBordPayment = false, int linkAccSettingDBId = 0, int pagesCnt = 0, int indx = 0)
	{
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int num = 0;
		string text = "";
		CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
		pagesCnt = ((pagesCnt <= 0) ? 1 : pagesCnt);
		int num2 = pagesCnt;
		int num3 = 0;
		pageNumber = 1;
		int userId = UserLogin.CurrentUser.UserId;
		try
		{
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			DateTime now = DateTime.Now;
			DateTime value2 = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			_ = Financial.Get().Id;
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			_ = DateTime.Now;
			_ = DateTime.Now;
			if (!string.IsNullOrEmpty(fDate))
			{
				DateTime.Parse(PersianDate.GetFormatetdDate(fDate.Replace("/", "")) + " 00:00:00", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			if (!string.IsNullOrEmpty(tDate))
			{
				DateTime.Parse(PersianDate.GetFormatetdDate(tDate.Replace("/", "")) + " 23:59:59", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			List<OtherSystemSelectedViewModel> list = new List<OtherSystemSelectedViewModel>();
			if (!string.IsNullOrWhiteSpace(records))
			{
				List<OtherSystemSelectedViewModel> list2 = new List<OtherSystemSelectedViewModel>();
				list2 = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedViewModel>>(records);
				if (Enumerable.Any<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list2))
				{
					list = Enumerable.ToList<OtherSystemSelectedViewModel>(Enumerable.Where<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list2, (Func<OtherSystemSelectedViewModel, bool>)((OtherSystemSelectedViewModel m) => m.Selected && m.Id > 0)));
				}
			}
			if (crmFPId == 0)
			{
				crmFPId = Financial.Get().Id;
			}
			if (list != null)
			{
				if (Enumerable.Any<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list))
				{
					num2 = Enumerable.Count<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list);
					num3 = 0;
					new List<CRMspLkSepWSExportOrder_Result>();
					foreach (OtherSystemSelectedViewModel item in list)
					{
						ObjectParameter insertedBordId = new ObjectParameter("insertedBordId", 0);
						ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
						cRMLinkSpEntities.CRMspLkSepWSIssueBuyOrderFromSep(item.Id, buyOrderOprId, bordpayTypeId, whId, userId, value3, value2, registerDatePersian, appType, result, insertedBordId, objectParameter, bordReferUserId, isUsedCmpReferUserId, crmFPId, addBordPayment, linkAccSettingDBId, centerId);
						string text2 = "";
						if (objectParameter.Value != null && !string.IsNullOrWhiteSpace(objectParameter.Value.ToString()))
						{
							if (!string.IsNullOrWhiteSpace(text2))
							{
								text2 += "<br>";
							}
							text2 += objectParameter.Value.ToString();
							if (!string.IsNullOrWhiteSpace(text2) && text2.IndexOf("No Items", StringComparison.Ordinal) >= 0)
							{
								text2 = text2.Replace("No Items", "");
								text2 = text2.Replace(",,", "");
								text2 = text2 + "," + string.Format(Messages.msgErrorNotHaveItems, Labels.lblBOrd);
								text2 = text2.TrimStart(new char[1] { ' ' }).TrimEnd(new char[1] { ' ' });
								text2 = text2.TrimStart(new char[1] { ',' }).TrimEnd(new char[1] { ',' });
							}
						}
						if (!string.IsNullOrWhiteSpace(text2))
						{
							num = 0;
							text = text + text2 + "<br>";
						}
						else
						{
							num = 1;
						}
						bool? isDone = null;
						if (num == 1)
						{
							num3++;
							int num4 = num3 * 100 / num2;
							if (num4 >= 100)
							{
								num4 = 100;
								isDone = true;
							}
							ThreadHub.SetThreadResult(indx, num4, "", isDone);
							continue;
						}
						num3++;
						int num5 = num3 * 100 / num2;
						string message = text;
						if (num5 >= 100)
						{
							num5 = 100;
							message = text;
							isDone = false;
						}
						ThreadHub.SetThreadResult(indx, num5, message, isDone);
					}
				}
				else
				{
					text = Messages.msgErrorRunFunction + " (" + Messages.msgErrorNotSelectedItem + ")";
					num3++;
					int percent = 100;
					string message2 = text;
					ThreadHub.SetThreadResult(indx, percent, message2, false);
				}
			}
			else
			{
				text = Messages.msgErrorRunFunction + " (" + Messages.msgErrorNotSelectedItem + ")";
				num3++;
				int percent2 = 100;
				string message3 = text;
				ThreadHub.SetThreadResult(indx, percent2, message3, false);
			}
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductFirstGroup");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductSecondGroup");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProducts");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductPriceGroup");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductPrice");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductCostGroup");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductCost");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WsWareHouse");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductUnits");
		}
		catch (Exception)
		{
			num = 0;
			num3++;
			int percent3 = 100;
			string msgErrorRunFunction = Messages.msgErrorRunFunction;
			ThreadHub.SetThreadResult(indx, percent3, msgErrorRunFunction, false);
		}
		finally
		{
			cRMLinkSpEntities?.Dispose();
		}
	}

	[AjaxOnly]
	public JsonResult GetSepImportBuyOrderList(string records, int totalPage, string fDate = "", string tDate = "", int value = 0, int linkAccSettingDBId = 0)
	{
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		List<OtherSystemSelectedViewModel> list = new List<OtherSystemSelectedViewModel>();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			totalPage = ((totalPage <= 0) ? 1 : totalPage);
			int value2 = 500 * totalPage;
			int value3 = 1;
			DateTime value4 = DateTime.Now;
			DateTime value5 = DateTime.Now;
			if (!string.IsNullOrEmpty(fDate))
			{
				value4 = DateTime.Parse(PersianDate.GetFormatetdDate(fDate.Replace("/", "")) + " 00:00:00", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			if (!string.IsNullOrEmpty(tDate))
			{
				value5 = DateTime.Parse(PersianDate.GetFormatetdDate(tDate.Replace("/", "")) + " 23:59:59", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			foreach (CRMspLkSepWSSelectBuyOrderFromSep_Result item2 in Enumerable.ToList<CRMspLkSepWSSelectBuyOrderFromSep_Result>((IEnumerable<CRMspLkSepWSSelectBuyOrderFromSep_Result>)_dbLink.CRMspLkSepWSSelectBuyOrderFromSep((!string.IsNullOrEmpty(fDate)) ? new DateTime?(value4) : null, (!string.IsNullOrEmpty(tDate)) ? new DateTime?(value5) : null, value, value3, value2, lCID, result, linkAccSettingDBId)))
			{
				OtherSystemSelectedViewModel item = new OtherSystemSelectedViewModel
				{
					Row = item2.RowNumber.GetValueOrDefault(),
					Id = item2.InventoryPurchaseInvoiceID.GetValueOrDefault(),
					Selected = !item2.BuyOrderId.HasValue
				};
				list.Add(item);
			}
			if (!string.IsNullOrWhiteSpace(records))
			{
				List<OtherSystemSelectedViewModel> list2 = new List<OtherSystemSelectedViewModel>();
				list2 = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedViewModel>>(records);
				if (Enumerable.Any<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list2))
				{
					foreach (OtherSystemSelectedViewModel item3 in list2)
					{
						foreach (OtherSystemSelectedViewModel item4 in list)
						{
							if (item4.Row == item3.Row)
							{
								item4.Selected = item3.Selected;
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
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[DynamicAuthorize(ControllerName = "frmBuyOrder", ActionName = "actExportToAcc")]
	public ActionResult SepExportBuyOrder()
	{
		GetBuyOrderOprByType(1);
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		base.ViewBag.LinkAccSettingDBList = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccSettingDB(1);
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmExportToAcc", ActionName = "actShowInfo")]
	public ActionResult SepExportBuyOrder_Read([DataSourceRequest] DataSourceRequest request, int buyOrderOprId, int pageNumber, string fDate = "", string tDate = "", int value = 0, int linkAccSettingDBId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SepBuyOrderViewModel> list = new List<SepBuyOrderViewModel>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			int value2 = 500;
			pageNumber = ((pageNumber <= 0) ? 1 : pageNumber);
			DateTime value3 = DateTime.Now;
			DateTime value4 = DateTime.Now;
			if (!string.IsNullOrEmpty(fDate))
			{
				value3 = DateTime.Parse(PersianDate.GetFormatetdDate(fDate.Replace("/", "")) + " 00:00:00", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			if (!string.IsNullOrEmpty(tDate))
			{
				value4 = DateTime.Parse(PersianDate.GetFormatetdDate(tDate.Replace("/", "")) + " 23:59:59", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			foreach (CRMspLkSepWSSelectBuyOrder_Result item2 in Enumerable.ToList<CRMspLkSepWSSelectBuyOrder_Result>((IEnumerable<CRMspLkSepWSSelectBuyOrder_Result>)_dbLink.CRMspLkSepWSSelectBuyOrder(UserLogin.CurrentUser.UserId, buyOrderOprId, (!string.IsNullOrEmpty(fDate)) ? new DateTime?(value3) : null, (!string.IsNullOrEmpty(tDate)) ? new DateTime?(value4) : null, value, pageNumber, value2, lCID, result, linkAccSettingDBId, result2)))
			{
				SepBuyOrderViewModel item = new SepBuyOrderViewModel
				{
					bordLinkAccBuyOrderId = item2.bordLinkAccBuyOrderId,
					Company = ((!string.IsNullOrEmpty(item2.CompanyName)) ? item2.CompanyName : "") + ((!string.IsNullOrEmpty(item2.CompanyPerson)) ? (" - " + item2.CompanyPerson) : ""),
					bordNumber = item2.bordNumber,
					Date = item2.bordDateTime,
					DatePersian = (item2.bordDateTime.HasValue ? item2.bordDateTime.Value.ToString("yyyy/MM/dd") : ""),
					bordTotalAmount = item2.bordTotalAmount,
					ItemCount = item2.bordItemCount,
					BuyOrderId = item2.BuyOrderID,
					RowNumber = item2.RowNumber,
					AllPage = item2.AllPage
				};
				list.Add(item);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	public int SepExportInfo(int sepFiscalYearRef, string records, int sepUserId, int buyOrderOprId, int sepCachId, int pageNumber, string fDate = "", string tDate = "", int value = 0, bool sendBordPayToAcc = false, int linkAccSettingDBId = 0, int pagesCnt = 0)
	{
		int indx = -1;
		try
		{
			indx = ThreadHub.AddThread();
			new Thread((ThreadStart)delegate
			{
				SepExportInfoAsync(sepFiscalYearRef, records, sepUserId, buyOrderOprId, sepCachId, pageNumber, fDate, tDate, value, sendBordPayToAcc, linkAccSettingDBId, pagesCnt, indx);
			}).Start();
		}
		catch (Exception ex)
		{
			ThreadHub.SetThreadResult(indx, 0, ex.Message, false);
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		return indx;
	}

	public void SepExportInfoAsync(int sepFiscalYearRef, string records, int sepUserId, int buyOrderOprId, int sepCachId, int pageNumber, string fDate = "", string tDate = "", int value = 0, bool sendBordPayToAcc = false, int linkAccSettingDBId = 0, int pagesCnt = 0, int indx = 0)
	{
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int num = 0;
		string text = "";
		CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
		CRMSpIIEntities cRMSpIIEntities = new CRMSpIIEntities();
		pagesCnt = ((pagesCnt <= 0) ? 1 : pagesCnt);
		int num2 = pagesCnt;
		int num3 = 0;
		pageNumber = 1;
		int userId = UserLogin.CurrentUser.UserId;
		try
		{
			DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			_ = Financial.Get().Id;
			short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			_ = DateTime.Now;
			_ = DateTime.Now;
			if (!string.IsNullOrEmpty(fDate))
			{
				DateTime.Parse(PersianDate.GetFormatetdDate(fDate.Replace("/", "")) + " 00:00:00", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			if (!string.IsNullOrEmpty(tDate))
			{
				DateTime.Parse(PersianDate.GetFormatetdDate(tDate.Replace("/", "")) + " 23:59:59", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			List<OtherSystemSelectedViewModel> list = new List<OtherSystemSelectedViewModel>();
			if (!string.IsNullOrWhiteSpace(records))
			{
				List<OtherSystemSelectedViewModel> list2 = new List<OtherSystemSelectedViewModel>();
				list2 = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedViewModel>>(records);
				if (Enumerable.Any<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list2))
				{
					list = Enumerable.ToList<OtherSystemSelectedViewModel>(Enumerable.Where<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list2, (Func<OtherSystemSelectedViewModel, bool>)((OtherSystemSelectedViewModel m) => m.Selected && m.Id > 0)));
				}
			}
			if (list != null)
			{
				if (Enumerable.Any<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list))
				{
					num2 = Enumerable.Count<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list);
					num3 = 0;
					new List<CRMspLkSepWSExportOrder_Result>();
					{
						foreach (OtherSystemSelectedViewModel item in list)
						{
							WSspSelectBuyOrderById_Result wSspSelectBuyOrderById_Result = Enumerable.FirstOrDefault<WSspSelectBuyOrderById_Result>((IEnumerable<WSspSelectBuyOrderById_Result>)cRMSpIIEntities.WSspSelectBuyOrderById(item.Id, lCID, result));
							if (wSspSelectBuyOrderById_Result != null)
							{
								string errorMessage = "";
								if (!BuyOrder.SendToLinkAccNeedVerify(item.Id, ref errorMessage))
								{
									text = text + errorMessage + "<br>";
									num = 0;
								}
								else
								{
									ObjectParameter objectParameter = new ObjectParameter("insertedId", 0);
									ObjectParameter objectParameter2 = new ObjectParameter("errorMessage", "");
									ObjectParameter objectParameter3 = new ObjectParameter("buyOrderNumebr", typeof(long));
									int? buyOrderId = item.Id;
									int? crmUserId = userId;
									string appType2 = appType;
									ObjectParameter insertedId = objectParameter;
									ObjectParameter buyOrderNumebr = objectParameter3;
									ObjectParameter errorMessage2 = objectParameter2;
									cRMLinkSpEntities.CRMspLkSepWSIssueBuyOrder(buyOrderId, null, sepFiscalYearRef, crmUserId, appType2, insertedId, buyOrderNumebr, errorMessage2, sepUserId, sendBordPayToAcc, linkAccSettingDBId);
									string text2 = "";
									if (objectParameter2.Value != null)
									{
										if (!string.IsNullOrWhiteSpace(objectParameter2.Value.ToString()))
										{
											if (!string.IsNullOrWhiteSpace(text2))
											{
												text2 += "<br>";
											}
											text2 += objectParameter2.Value.ToString();
											string text3 = "";
											if (objectParameter3.Value != null)
											{
												text3 = objectParameter3.Value.ToString() ?? "";
												if (text3 != "-3")
												{
													wSspSelectBuyOrderById_Result.bordLinkAccBuyOrderNumber = text3;
												}
											}
											string text4 = objectParameter2.Value.ToString();
											if (!string.IsNullOrWhiteSpace(text4) && text4.IndexOf("Financially incorrect in bordpayment", StringComparison.Ordinal) >= 0)
											{
												text4 = text4.Replace("Financially incorrect in bordpayment", "");
												text4 = text4.Replace(",,", "");
												text4 = text4 + ",(" + Labels.lblBordPay + ") " + Messages.msgErrorfinancialYearWrong;
												text4 = text4.TrimStart(new char[1] { ' ' }).TrimEnd(new char[1] { ' ' });
												text4 = text4.TrimStart(new char[1] { ',' }).TrimEnd(new char[1] { ',' });
												if (!string.IsNullOrWhiteSpace(text2))
												{
													text2 += "<br>";
												}
												text2 += text4;
											}
											if (!string.IsNullOrWhiteSpace(text2) && text2.IndexOf("No Items", StringComparison.Ordinal) >= 0)
											{
												text4 = text4.Replace("No Items", "");
												text4 = text4.Replace(",,", "");
												text4 = text4 + "," + string.Format(Messages.msgErrorNotHaveItems, Labels.lblBOrd);
												text4 = text4.TrimStart(new char[1] { ' ' }).TrimEnd(new char[1] { ' ' });
												text4 = text4.TrimStart(new char[1] { ',' }).TrimEnd(new char[1] { ',' });
												if (!string.IsNullOrWhiteSpace(text2))
												{
													text2 += "<br>";
												}
												text2 += text4;
											}
										}
										else
										{
											string text5 = "";
											if (objectParameter3.Value != null)
											{
												text5 = objectParameter3.Value.ToString() ?? "";
												if (text5 != "-3")
												{
													wSspSelectBuyOrderById_Result.bordLinkAccBuyOrderNumber = text5;
												}
											}
										}
									}
									else
									{
										string text6 = "";
										if (objectParameter3.Value != null)
										{
											text6 = objectParameter3.Value.ToString() ?? "";
											if (text6 != "-3")
											{
												wSspSelectBuyOrderById_Result.bordLinkAccBuyOrderNumber = text6;
											}
										}
									}
									if (!string.IsNullOrWhiteSpace(text2))
									{
										num = 0;
										if (text2.IndexOf("Financially incorrect in bordpayment", StringComparison.Ordinal) >= 0)
										{
											text2 = text2.Replace("Financially incorrect in bordpayment", "");
											text2 = text2.Replace(",,", "");
											text2 = text2 + ",(" + Labels.lblBordPay + ") " + Messages.msgErrorfinancialYearWrong;
											text2 = text2.TrimStart(new char[1] { ' ' }).TrimEnd(new char[1] { ' ' });
											text2 = text2.TrimStart(new char[1] { ',' }).TrimEnd(new char[1] { ',' });
										}
										else if (text2.IndexOf("Financially incorrect", StringComparison.Ordinal) >= 0)
										{
											text2 = text2.Replace("Financially incorrect,", "");
											text2 = text2.Replace("Financially incorrect<br>Financially incorrect", "");
											text2 = text2.Replace("Financially incorrect", "");
											text2 = text2.Replace(",,", "");
											text2 = text2 + "," + Messages.msgErrorfinancialYearWrong;
											text2 = text2.TrimStart(new char[1] { ' ' }).TrimEnd(new char[1] { ' ' });
											text2 = text2.TrimStart(new char[1] { ',' }).TrimEnd(new char[1] { ',' });
										}
										text = text + text2 + "<br>";
									}
									else
									{
										num = 1;
									}
								}
							}
							else
							{
								num = 1;
							}
							bool? isDone = null;
							if (num == 1)
							{
								num3++;
								int num4 = num3 * 100 / num2;
								if (num4 >= 100)
								{
									num4 = 100;
									isDone = true;
								}
								ThreadHub.SetThreadResult(indx, num4, "", isDone);
								continue;
							}
							num3++;
							int num5 = num3 * 100 / num2;
							string message = text;
							if (num5 >= 100)
							{
								num5 = 100;
								message = text;
								isDone = false;
							}
							ThreadHub.SetThreadResult(indx, num5, message, isDone);
						}
						return;
					}
				}
				text = Messages.msgErrorRunFunction + " (" + Messages.msgErrorNotSelectedItem + ")";
				num3++;
				int percent = 100;
				string message2 = text;
				ThreadHub.SetThreadResult(indx, percent, message2, false);
			}
			else
			{
				text = Messages.msgErrorRunFunction + " (" + Messages.msgErrorNotSelectedItem + ")";
				num3++;
				int percent2 = 100;
				string message3 = text;
				ThreadHub.SetThreadResult(indx, percent2, message3, false);
			}
		}
		catch (Exception)
		{
			num = 0;
			num3++;
			int percent3 = 100;
			string msgErrorRunFunction = Messages.msgErrorRunFunction;
			ThreadHub.SetThreadResult(indx, percent3, msgErrorRunFunction, false);
		}
		finally
		{
			cRMLinkSpEntities?.Dispose();
			cRMSpIIEntities?.Dispose();
		}
	}

	[AjaxOnly]
	public JsonResult GetSepExportBuyOrderList(string records, int totalPage, int buyOrderOprId, string fDate = "", string tDate = "", int value = 0, int linkAccSettingDBId = 0)
	{
		//IL_0278: Unknown result type (might be due to invalid IL or missing references)
		List<OtherSystemSelectedViewModel> list = new List<OtherSystemSelectedViewModel>();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			totalPage = ((totalPage <= 0) ? 1 : totalPage);
			int value2 = 500 * totalPage;
			int value3 = 1;
			DateTime value4 = DateTime.Now;
			DateTime value5 = DateTime.Now;
			if (!string.IsNullOrEmpty(fDate))
			{
				value4 = DateTime.Parse(PersianDate.GetFormatetdDate(fDate.Replace("/", "")) + " 00:00:00", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			if (!string.IsNullOrEmpty(tDate))
			{
				value5 = DateTime.Parse(PersianDate.GetFormatetdDate(tDate.Replace("/", "")) + " 23:59:59", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			foreach (CRMspLkSepWSSelectBuyOrder_Result item2 in Enumerable.ToList<CRMspLkSepWSSelectBuyOrder_Result>((IEnumerable<CRMspLkSepWSSelectBuyOrder_Result>)_dbLink.CRMspLkSepWSSelectBuyOrder(UserLogin.CurrentUser.UserId, buyOrderOprId, (!string.IsNullOrEmpty(fDate)) ? new DateTime?(value4) : null, (!string.IsNullOrEmpty(tDate)) ? new DateTime?(value5) : null, value, value3, value2, lCID, result, linkAccSettingDBId, result2)))
			{
				OtherSystemSelectedViewModel item = new OtherSystemSelectedViewModel
				{
					Row = item2.RowNumber.GetValueOrDefault(),
					Id = item2.BuyOrderID.GetValueOrDefault(),
					Selected = !item2.bordLinkAccBuyOrderId.HasValue
				};
				list.Add(item);
			}
			if (!string.IsNullOrWhiteSpace(records))
			{
				List<OtherSystemSelectedViewModel> list2 = new List<OtherSystemSelectedViewModel>();
				list2 = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedViewModel>>(records);
				if (Enumerable.Any<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list2))
				{
					foreach (OtherSystemSelectedViewModel item3 in list2)
					{
						foreach (OtherSystemSelectedViewModel item4 in list)
						{
							if (item4.Row == item3.Row)
							{
								item4.Selected = item3.Selected;
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
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[DynamicAuthorize(ControllerName = "frmBuyOrder", ActionName = "actBordLinkAccDetails")]
	public ActionResult SepBordLinkAccDetails(int bordId)
	{
		base.ViewBag.BordId = bordId;
		base.ViewBag.LinkAccSettingDBList = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccSettingDB(1);
		return View();
	}

	[AjaxOnly]
	public JsonResult GetBordLinkAccDetails(int bordId, int linkAccSettingDBId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		SepBordLinkAccDetailsViewModel sepBordLinkAccDetailsViewModel = new SepBordLinkAccDetailsViewModel();
		sepBordLinkAccDetailsViewModel.BuyOrderInfo = new CRMspLkSepWSSelectBuyOrderByBordId_Result();
		sepBordLinkAccDetailsViewModel.BuyOrderItems = new List<CRMspLkSepWSSelectBuyOrderItemsByBordId_Result>();
		sepBordLinkAccDetailsViewModel.BuyOrderPayments = new List<CRMspLkSepWSSelectBuyOrderPaymentsByBordId_Result>();
		sepBordLinkAccDetailsViewModel.IsFind = false;
		try
		{
			if (bordId != 0)
			{
				sepBordLinkAccDetailsViewModel.BuyOrderInfo = Enumerable.FirstOrDefault<CRMspLkSepWSSelectBuyOrderByBordId_Result>((IEnumerable<CRMspLkSepWSSelectBuyOrderByBordId_Result>)_dbLink.CRMspLkSepWSSelectBuyOrderByBordId(bordId, lCID, result, linkAccSettingDBId));
				if (sepBordLinkAccDetailsViewModel.BuyOrderInfo != null)
				{
					sepBordLinkAccDetailsViewModel.IsFind = true;
					sepBordLinkAccDetailsViewModel.BuyOrderInfo.bordDate = (sepBordLinkAccDetailsViewModel.BuyOrderInfo.bordDateTime.HasValue ? sepBordLinkAccDetailsViewModel.BuyOrderInfo.bordDateTime.Value.ToString("yyyy/MM/dd") : "");
					sepBordLinkAccDetailsViewModel.BuyOrderInfo.SepInvoiceDatePersian = (sepBordLinkAccDetailsViewModel.BuyOrderInfo.SepInvoiceDate.HasValue ? sepBordLinkAccDetailsViewModel.BuyOrderInfo.SepInvoiceDate.Value.ToString("yyyy/MM/dd") : "");
					sepBordLinkAccDetailsViewModel.BuyOrderInfo.BuyOrderOpr = ((!string.IsNullOrWhiteSpace(sepBordLinkAccDetailsViewModel.BuyOrderInfo.BuyOrderOpr)) ? sepBordLinkAccDetailsViewModel.BuyOrderInfo.BuyOrderOpr : Labels.lblBOrd) + " (" + sepBordLinkAccDetailsViewModel.BuyOrderInfo.bordNumber + ")";
					sepBordLinkAccDetailsViewModel.BuyOrderInfo.bordCurrencyUnitIsDecimal = sepBordLinkAccDetailsViewModel.BuyOrderInfo.bordCurrencyUnitIsDecimal.GetValueOrDefault();
					sepBordLinkAccDetailsViewModel.BuyOrderInfo.bordLinkAccFirstTransferDateStr = (sepBordLinkAccDetailsViewModel.BuyOrderInfo.bordLinkAccFirstTransferDate.HasValue ? sepBordLinkAccDetailsViewModel.BuyOrderInfo.bordLinkAccFirstTransferDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
					sepBordLinkAccDetailsViewModel.BuyOrderInfo.bordLinkAccLastTransferDateStr = (sepBordLinkAccDetailsViewModel.BuyOrderInfo.bordLinkAccLastTransferDate.HasValue ? sepBordLinkAccDetailsViewModel.BuyOrderInfo.bordLinkAccLastTransferDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
					sepBordLinkAccDetailsViewModel.BuyOrderItems = Enumerable.ToList<CRMspLkSepWSSelectBuyOrderItemsByBordId_Result>((IEnumerable<CRMspLkSepWSSelectBuyOrderItemsByBordId_Result>)_dbLink.CRMspLkSepWSSelectBuyOrderItemsByBordId(bordId, lCID, result, linkAccSettingDBId));
					if (sepBordLinkAccDetailsViewModel.BuyOrderItems != null && Enumerable.Any<CRMspLkSepWSSelectBuyOrderItemsByBordId_Result>((IEnumerable<CRMspLkSepWSSelectBuyOrderItemsByBordId_Result>)sepBordLinkAccDetailsViewModel.BuyOrderItems))
					{
						foreach (CRMspLkSepWSSelectBuyOrderItemsByBordId_Result buyOrderItem in sepBordLinkAccDetailsViewModel.BuyOrderItems)
						{
							buyOrderItem.PrdQtyNoFCR = buyOrderItem.PrdQtyNoFCR.GetValueOrDefault();
							buyOrderItem.bordILinkAccFirstTransferDateStr = (buyOrderItem.bordILinkAccFirstTransferDate.HasValue ? buyOrderItem.bordILinkAccFirstTransferDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
							buyOrderItem.bordILinkAccLastTransferDateStr = (buyOrderItem.bordILinkAccLastTransferDate.HasValue ? buyOrderItem.bordILinkAccLastTransferDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
						}
					}
					else
					{
						sepBordLinkAccDetailsViewModel.BuyOrderItems = new List<CRMspLkSepWSSelectBuyOrderItemsByBordId_Result>();
					}
					sepBordLinkAccDetailsViewModel.BuyOrderPayments = Enumerable.ToList<CRMspLkSepWSSelectBuyOrderPaymentsByBordId_Result>((IEnumerable<CRMspLkSepWSSelectBuyOrderPaymentsByBordId_Result>)_dbLink.CRMspLkSepWSSelectBuyOrderPaymentsByBordId(bordId, lCID, result, linkAccSettingDBId));
					if (sepBordLinkAccDetailsViewModel.BuyOrderPayments != null && Enumerable.Any<CRMspLkSepWSSelectBuyOrderPaymentsByBordId_Result>((IEnumerable<CRMspLkSepWSSelectBuyOrderPaymentsByBordId_Result>)sepBordLinkAccDetailsViewModel.BuyOrderPayments))
					{
						foreach (CRMspLkSepWSSelectBuyOrderPaymentsByBordId_Result buyOrderPayment in sepBordLinkAccDetailsViewModel.BuyOrderPayments)
						{
							buyOrderPayment.ImportDate = (buyOrderPayment.ImportDateTime.HasValue ? buyOrderPayment.ImportDateTime.Value.ToString("yyyy/MM/dd") : "");
							buyOrderPayment.bordpayDocDate = (buyOrderPayment.bordpayDocDateTime.HasValue ? buyOrderPayment.bordpayDocDateTime.Value.ToString("yyyy/MM/dd") : "");
							buyOrderPayment.bordpayLinkAccFirstTransferDateStr = (buyOrderPayment.bordpayLinkAccFirstTransferDate.HasValue ? buyOrderPayment.bordpayLinkAccFirstTransferDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
							buyOrderPayment.bordpayLinkAccLastTransferDateStr = (buyOrderPayment.bordpayLinkAccLastTransferDate.HasValue ? buyOrderPayment.bordpayLinkAccLastTransferDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
							int result2 = 0;
							int.TryParse(buyOrderPayment.SepDetailType.ToString(), out result2);
							if (string.IsNullOrWhiteSpace(buyOrderPayment.bordpayLinkAccPayType))
							{
								switch (result2)
								{
								case 1:
									buyOrderPayment.SepDetailTypeTitle = Labels.LinkAccSettingCash;
									break;
								case 2:
									buyOrderPayment.SepDetailTypeTitle = Labels.LinkAccSettingChqeue;
									break;
								case 3:
									buyOrderPayment.SepDetailTypeTitle = Labels.LinkAccSettingWithdrawalNotice;
									break;
								default:
									buyOrderPayment.SepDetailTypeTitle = "";
									break;
								}
							}
							else
							{
								if (string.IsNullOrWhiteSpace(buyOrderPayment.bordpayLinkAccPayType))
								{
									continue;
								}
								if (buyOrderPayment.bordpayLinkAccPayType == "neg")
								{
									switch (result2)
									{
									case 1:
										buyOrderPayment.SepDetailTypeTitle = Labels.LinkAccSettingCash;
										break;
									case 2:
										buyOrderPayment.SepDetailTypeTitle = Labels.LinkAccSettingChqeue;
										break;
									case 3:
										buyOrderPayment.SepDetailTypeTitle = Labels.LinkAccSettingDraft;
										break;
									case 4:
										buyOrderPayment.SepDetailTypeTitle = Labels.LinkAccSettingCardReader;
										break;
									default:
										buyOrderPayment.SepDetailTypeTitle = "";
										break;
									}
								}
								else
								{
									if (!(buyOrderPayment.bordpayLinkAccPayType == "dup"))
									{
										continue;
									}
									if (buyOrderPayment.bordpayAmount > 0m)
									{
										switch (result2)
										{
										case 1:
											buyOrderPayment.SepDetailTypeTitle = Labels.LinkAccSettingCash;
											break;
										case 2:
											buyOrderPayment.SepDetailTypeTitle = Labels.LinkAccSettingChqeue;
											break;
										case 3:
											buyOrderPayment.SepDetailTypeTitle = Labels.LinkAccSettingWithdrawalNotice;
											break;
										default:
											buyOrderPayment.SepDetailTypeTitle = "";
											break;
										}
									}
									else if (buyOrderPayment.bordpayAmount < 0m)
									{
										switch (result2)
										{
										case 1:
											buyOrderPayment.SepDetailTypeTitle = Labels.LinkAccSettingCash;
											break;
										case 2:
											buyOrderPayment.SepDetailTypeTitle = Labels.LinkAccSettingChqeue;
											break;
										case 3:
											buyOrderPayment.SepDetailTypeTitle = Labels.LinkAccSettingDraft;
											break;
										case 4:
											buyOrderPayment.SepDetailTypeTitle = Labels.LinkAccSettingCardReader;
											break;
										default:
											buyOrderPayment.SepDetailTypeTitle = "";
											break;
										}
									}
								}
							}
						}
					}
					else
					{
						sepBordLinkAccDetailsViewModel.BuyOrderPayments = new List<CRMspLkSepWSSelectBuyOrderPaymentsByBordId_Result>();
					}
				}
				else
				{
					sepBordLinkAccDetailsViewModel.Message = Messages.ErrorNotFound;
				}
			}
			else
			{
				sepBordLinkAccDetailsViewModel.Message = Messages.msgErrorNotSelectedItem;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			sepBordLinkAccDetailsViewModel.Message = Messages.msgErrorRunFunction + "<br />" + ex.Message;
		}
		JsonResult jsonResult = Json(sepBordLinkAccDetailsViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult SepDeleteBuyOrderInfo(int bordId, int bordItemId, int bordPayId, int mode, int position, int linkAccSettingDBId)
	{
		string text = "";
		string text2 = "";
		CommonResultStatusViewModel commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		CommonResultViewModel<string> data;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			bool flag = false;
			string actionName = "";
			switch (position)
			{
			case 1:
				actionName = "actDelLinkBordInAcc";
				break;
			case 2:
				actionName = "actDelLinkBordInCrm";
				break;
			case 11:
				actionName = "actDelLinkBordItemInAcc";
				break;
			case 12:
				actionName = "actDelLinkBordItemInCrm";
				break;
			case 21:
				actionName = "actDelLinkBordPayInAcc";
				flag = true;
				break;
			case 22:
				actionName = "actDelLinkBordPayInCrm";
				flag = true;
				break;
			case 23:
				actionName = "actDelLinkBordPayRefundInAcc";
				flag = true;
				break;
			case 24:
				actionName = "actDelLinkBordPayRefundInCrm";
				flag = true;
				break;
			}
			if (!UserLogin.IsUserAccess("frmBordLinkAccDetails", actionName, currentUser))
			{
				text = "";
				text2 = Messages.ErrorNotAccess;
				commonResultStatusViewModel = CommonResultStatusViewModel.Error;
				data = new CommonResultViewModel<string>
				{
					Data = text,
					Message = text2,
					Status = commonResultStatusViewModel
				};
				return Json(data, JsonRequestBehavior.AllowGet);
			}
			if (bordId > 0)
			{
				DateTime now = DateTime.Now;
				DateTime value = now;
				string text3 = now.ToString("yyyyMMdd", new PersianCulture());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				short.Parse(Financial.Get().Id.ToString());
				int id = Financial.Get().Id;
				int userId = currentUser.UserId;
				ObjectParameter objectParameter = new ObjectParameter("ErrorMessage", "");
				if (flag)
				{
					_dbLink.CRMspLkSepWSDeleteBuyOrderPaymentFromSep(bordPayId, userId, value2, id, value, text3, appType, objectParameter, mode, linkAccSettingDBId);
				}
				else
				{
					CRMLinkSpEntities dbLink = _dbLink;
					int? buyOrderId = bordId;
					int? buyOrderItemId = bordItemId;
					int? crmUserId = userId;
					int? month = value2;
					int? fPId = id;
					DateTime? registerDate = value;
					string registerDatePersian = text3;
					string appType2 = appType;
					ObjectParameter errorMessage = objectParameter;
					dbLink.CRMspLkSepWSDeleteBuyOrderInfoFromSep(buyOrderId, buyOrderItemId, mode, crmUserId, month, fPId, registerDate, registerDatePersian, appType2, errorMessage, linkAccSettingDBId);
				}
				if (objectParameter.Value != null)
				{
					if (!string.IsNullOrEmpty(objectParameter.Value.ToString()))
					{
						text2 = objectParameter.Value.ToString();
						if (mode == 1)
						{
							text2 = text2 + "<br>" + Messages.RedundancyMessage;
						}
					}
					else
					{
						text2 = "";
					}
				}
				else
				{
					text2 = "";
				}
			}
			else
			{
				text2 = Messages.ErrorNotFound;
			}
			if (!string.IsNullOrWhiteSpace(text2))
			{
				text = "0";
				text2 = Messages.msgErrorRunFunction + "<br>" + text2;
				commonResultStatusViewModel = CommonResultStatusViewModel.Error;
			}
			else
			{
				text = "1";
				text2 = Messages.msgSuccessAction;
				commonResultStatusViewModel = CommonResultStatusViewModel.Success;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			text = "0";
			text2 = Messages.msgErrorRunFunction + " " + ex.Message;
			commonResultStatusViewModel = CommonResultStatusViewModel.Error;
		}
		data = new CommonResultViewModel<string>
		{
			Data = text,
			Message = text2,
			Status = commonResultStatusViewModel
		};
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetBuyOrderOpr()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			List<WSspSelectBuyOrderOpr_Result> list2 = BuyOrder.SelectBuyOrderOpr();
			if (list2 != null)
			{
				list.AddRange(Enumerable.Select<WSspSelectBuyOrderOpr_Result, SelectListItem>((IEnumerable<WSspSelectBuyOrderOpr_Result>)list2, (Func<WSspSelectBuyOrderOpr_Result, SelectListItem>)((WSspSelectBuyOrderOpr_Result item) => new SelectListItem
				{
					Text = item.Name,
					Value = item.BuyOrderOprID.ToString(),
					Selected = false
				})));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.BuyOrderOprList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetWareHouse()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			List<WSspSelectActiveWareHouse_Result> list2 = CRMIdeal.Classes.Helper.Warehouse.SelectActiveWareHouse();
			list.AddRange(Enumerable.Select<WSspSelectActiveWareHouse_Result, SelectListItem>((IEnumerable<WSspSelectActiveWareHouse_Result>)list2, (Func<WSspSelectActiveWareHouse_Result, SelectListItem>)((WSspSelectActiveWareHouse_Result item) => new SelectListItem
			{
				Text = item.WrhsName,
				Value = item.WareHouseID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.WareHouseList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetPaymentType()
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
			List<WSspSelectBuyOrderPaymentTypes_Result> list2 = Enumerable.ToList<WSspSelectBuyOrderPaymentTypes_Result>((IEnumerable<WSspSelectBuyOrderPaymentTypes_Result>)_db.WSspSelectBuyOrderPaymentTypes(lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectBuyOrderPaymentTypes_Result, SelectListItem>((IEnumerable<WSspSelectBuyOrderPaymentTypes_Result>)list2, (Func<WSspSelectBuyOrderPaymentTypes_Result, SelectListItem>)((WSspSelectBuyOrderPaymentTypes_Result item) => new SelectListItem
			{
				Text = item.bordpayType,
				Value = item.BuyOrderPaymentTypeId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PaymentTypeList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetSepCash(int linkAccSettingDBId)
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
			List<CRMspLkSepSelectCash_Result> list2 = Enumerable.ToList<CRMspLkSepSelectCash_Result>((IEnumerable<CRMspLkSepSelectCash_Result>)_dbLink.CRMspLkSepSelectCash(linkAccSettingDBId, lCID, result));
			list.AddRange(Enumerable.Select<CRMspLkSepSelectCash_Result, SelectListItem>((IEnumerable<CRMspLkSepSelectCash_Result>)list2, (Func<CRMspLkSepSelectCash_Result, SelectListItem>)((CRMspLkSepSelectCash_Result item) => new SelectListItem
			{
				Text = item.Title,
				Value = item.CashId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CashList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetSepFiscalYear(int linkAccSettingDBId)
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
			List<CRMspLkSepSelectFiscalYear_Result> list2 = Enumerable.ToList<CRMspLkSepSelectFiscalYear_Result>((IEnumerable<CRMspLkSepSelectFiscalYear_Result>)_dbLink.CRMspLkSepSelectFiscalYear(linkAccSettingDBId, lCID, result));
			list.AddRange(Enumerable.Select<CRMspLkSepSelectFiscalYear_Result, SelectListItem>((IEnumerable<CRMspLkSepSelectFiscalYear_Result>)list2, (Func<CRMspLkSepSelectFiscalYear_Result, SelectListItem>)((CRMspLkSepSelectFiscalYear_Result item) => new SelectListItem
			{
				Text = item.Title,
				Value = item.FiscalYearId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.SepSepFiscalYearList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetBordReferUser()
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
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<CRMspSelectUserForLinkedType_Result> list2 = Enumerable.ToList<CRMspSelectUserForLinkedType_Result>((IEnumerable<CRMspSelectUserForLinkedType_Result>)_db.CRMspSelectUserForLinkedType(UserLogin.CurrentUser.UserId, 7, lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspSelectUserForLinkedType_Result, SelectListItem>((IEnumerable<CRMspSelectUserForLinkedType_Result>)list2, (Func<CRMspSelectUserForLinkedType_Result, SelectListItem>)((CRMspSelectUserForLinkedType_Result item) => new SelectListItem
			{
				Text = item.UserName,
				Value = item.LinkedUserId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ReferUserList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetSepUser(int linkAccSettingDBId)
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
			List<CRMspLkSepSelectUser_Result> list2 = Enumerable.ToList<CRMspLkSepSelectUser_Result>((IEnumerable<CRMspLkSepSelectUser_Result>)_dbLink.CRMspLkSepSelectUser(linkAccSettingDBId, lCID, result));
			list.AddRange(Enumerable.Select<CRMspLkSepSelectUser_Result, SelectListItem>((IEnumerable<CRMspLkSepSelectUser_Result>)list2, (Func<CRMspLkSepSelectUser_Result, SelectListItem>)((CRMspLkSepSelectUser_Result item) => new SelectListItem
			{
				Text = item.Name,
				Value = item.UserID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.UserList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetCrmFinancialPeriod()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			List<WSspSelectFinancialPeriod_Result> list2 = Enumerable.ToList<WSspSelectFinancialPeriod_Result>((IEnumerable<WSspSelectFinancialPeriod_Result>)Enumerable.OrderByDescending<WSspSelectFinancialPeriod_Result, int>((IEnumerable<WSspSelectFinancialPeriod_Result>)_db.WSspSelectFinancialPeriod(), (Func<WSspSelectFinancialPeriod_Result, int>)((WSspSelectFinancialPeriod_Result m) => m.ID)));
			list.AddRange(Enumerable.Select<WSspSelectFinancialPeriod_Result, SelectListItem>((IEnumerable<WSspSelectFinancialPeriod_Result>)list2, (Func<WSspSelectFinancialPeriod_Result, SelectListItem>)((WSspSelectFinancialPeriod_Result item) => new SelectListItem
			{
				Text = item.Name,
				Value = item.ID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CrmFinancialPeriodList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetBuyOrderOprByType(int oprType)
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
			int value = 0;
			if (UserLogin.CurrentUser != null)
			{
				value = UserLogin.CurrentUser.UserId;
			}
			List<WSspSelectBuyOrderOprByOprType_Result> list2 = Enumerable.ToList<WSspSelectBuyOrderOprByOprType_Result>((IEnumerable<WSspSelectBuyOrderOprByOprType_Result>)_db.WSspSelectBuyOrderOprByOprType(oprType, lCID, result, value));
			list.AddRange(Enumerable.Select<WSspSelectBuyOrderOprByOprType_Result, SelectListItem>((IEnumerable<WSspSelectBuyOrderOprByOprType_Result>)list2, (Func<WSspSelectBuyOrderOprByOprType_Result, SelectListItem>)((WSspSelectBuyOrderOprByOprType_Result item) => new SelectListItem
			{
				Text = item.Name,
				Value = item.BuyOrderOprID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.BuyOrderOprList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetLinkAccThreadResult(int indx = -1)
	{
		ThreadHub.ThreadHubObj threadResult = ThreadHub.GetThreadResult(indx);
		if (threadResult.IsDone.GetValueOrDefault() || threadResult.IsDone == false)
		{
			ThreadHub.RemoveThread(indx, autoEmpty: true);
		}
		return JsonConvert.SerializeObject(threadResult);
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		_dbLink.Dispose();
		base.Dispose(disposing);
	}
}
