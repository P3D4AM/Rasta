using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Objects;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.General.Calendar;
using CRM.General.IO;
using CRM.General.Security;
using CRM.Models;
using CRM.OtherWebServices.LinkNoAvanran_II;
using CRM.OtherWebServices.LinkNoAvaranCapillary;
using CRM.Resources;
using CRMIdeal.Areas.Setting.Controllers;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using CRMIdeal.Hubs;
using CRMIdeal.LinkPayvast;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using NR.Shygun.WS.ClientModel;
using NR.Shygun.WS.ClientModel.GeneralModels;
using NR.Shygun.WS.ClientSDK;
using NR.Shygun.WS.FilterDomains;
using Newtonsoft.Json;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace CRMIdeal.Areas.OtherSystems.Controllers;

public class PreOrderController : Controller
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
	private sealed class _003C_003Ec__DisplayClass111_1
	{
		public CRMspLkWSSelectPreOrderPaymentsWithId_Result pay;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass24_0
	{
		public int pordId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass34_0
	{
		public int pordId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass39_0
	{
		public int pordId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass55_0
	{
		public int pordId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass55_1
	{
		public CRMspLkWSSelectPreOrderById_Result pord;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass55_3
	{
		public WSspSelectPreOrderItems_Result pordI;

		internal bool _003CShygunActSendToAcc_003Eb__4(WSspSelectWareHouse_Result x)
		{
			return x.WareHouseID == pordI.pordIWHId;
		}

		internal bool _003CShygunActSendToAcc_003Eb__6(CommonWithIdStrViewModel x)
		{
			return x.Code == pordI.pordILinkAccWHIdStr;
		}

		internal bool _003CShygunActSendToAcc_003Eb__5(WSspSelectWareHouse_Result x)
		{
			return x.WareHouseID == pordI.pordIWHId;
		}

		internal bool _003CShygunActSendToAcc_003Eb__2(WSspSelectWareHouse_Result x)
		{
			return x.WareHouseID == pordI.pordIWHId;
		}

		internal bool _003CShygunActSendToAcc_003Eb__3(WSspSelectProductWithAccLinkField_Result x)
		{
			return x.ProductID == pordI.pordIPrdId;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass56_1
	{
		public CRMspLkWSSelectPreOrder_Result pord;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass56_2
	{
		public WSspSelectPreOrderItems_Result pordI;

		internal bool _003CShygunExportInfo_003Eb__6(WSspSelectWareHouse_Result x)
		{
			return x.WareHouseID == pordI.pordIWHId;
		}

		internal bool _003CShygunExportInfo_003Eb__8(CommonWithIdStrViewModel x)
		{
			return x.Code == pordI.pordILinkAccWHIdStr;
		}

		internal bool _003CShygunExportInfo_003Eb__7(WSspSelectWareHouse_Result x)
		{
			return x.WareHouseID == pordI.pordIWHId;
		}

		internal bool _003CShygunExportInfo_003Eb__4(WSspSelectWareHouse_Result x)
		{
			return x.WareHouseID == pordI.pordIWHId;
		}

		internal bool _003CShygunExportInfo_003Eb__5(WSspSelectProductWithAccLinkField_Result x)
		{
			return x.ProductID == pordI.pordIPrdId;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass56_3
	{
		public int Id;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public int pordId;

		public int payId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass73_0
	{
		public WSspSelectPreOrderWithId_Result pord;

		internal bool _003CTarazActSendToAcc_003Eb__0(CRMspSelectUsersWithAccLinkField_Result m)
		{
			return m.UserId == pord.pordReferUserId;
		}

		internal bool _003CTarazActSendToAcc_003Eb__2(CRMspSelectUsersWithAccLinkField_Result m)
		{
			return m.UserId == pord.pordSellerId;
		}

		internal bool _003CTarazActSendToAcc_003Eb__3(WSspSelectProductPriceGroupWithAccLinkField_Result m)
		{
			return m.ProductPriceGroupID == pord.pordDefPrdPriceGroupId;
		}

		internal bool _003CTarazActSendToAcc_003Eb__4(WSspSelectWareHouseWithAccLinkField_Result m)
		{
			return m.WareHouseID == pord.pordDefWHId;
		}

		internal bool _003CTarazActSendToAcc_003Eb__5(WSspSelectPreOrderTypesWithAccLinkField_Result m)
		{
			return m.PreOrderTypeId == pord.pordTypeId;
		}

		internal bool _003CTarazActSendToAcc_003Eb__6(WSspSelectDeliveryTermWithAccLinkField_Result m)
		{
			return m.DeliveryTermId == pord.pordDeliveryTermId;
		}

		internal bool _003CTarazActSendToAcc_003Eb__7(WSspSelectSaleCenterWithAccLinkField_Result m)
		{
			return m.SaleCenterId == pord.pordSaleCenterId;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass73_3
	{
		public WSspSelectPreOrderItems_Result odItem;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass73_6
	{
		public TarazSaleVoucherDetailsInsertResultViewModel vouItem;

		internal bool _003CTarazActSendToAcc_003Eb__33(WSspSelectProductWithAccLinkField_Result m)
		{
			return m.PrdLinkAccPrdIdStr == vouItem.goodsID.ToString();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass73_7
	{
		public int prdId;

		public WSspSelectPreOrderItems_Result odItem;

		public _003C_003Ec__DisplayClass73_6 CS_0024_003C_003E8__locals2;

		internal bool _003CTarazActSendToAcc_003Eb__32(WSspSelectPreOrderItems_Result m)
		{
			if (m.pordIQuantity != CS_0024_003C_003E8__locals2.vouItem.quantity || !((decimal)(m.pordIFCR.GetValueOrDefault(1.0) * m.pordIFCRI.GetValueOrDefault(1.0)) == CS_0024_003C_003E8__locals2.vouItem.computeValue.GetValueOrDefault(1m)) || !(m.pordIPrice == CS_0024_003C_003E8__locals2.vouItem.fee) || m.pordIPrdId != prdId)
			{
				return (m.pordILinkAccItemIdStr ?? "0") == CS_0024_003C_003E8__locals2.vouItem.voucherDetailID.GetValueOrDefault().ToString();
			}
			return true;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass84_1
	{
		public CRMspLkWSSelectPreOrder_Result pord;

		internal bool _003CShygunIIExportInfo_003Eb__4(CRMspSelectUsersWithAccLinkField_Result m)
		{
			return m.UserId == pord.pordReferUserId;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass84_2
	{
		public WSspSelectPreOrderItems_Result pordI;

		internal bool _003CShygunIIExportInfo_003Eb__7(WSspSelectWareHouse_Result x)
		{
			return x.WareHouseID == pordI.pordIWHId;
		}

		internal bool _003CShygunIIExportInfo_003Eb__9(CommonWithIdStrViewModel x)
		{
			return x.Code == pordI.pordILinkAccWHIdStr;
		}

		internal bool _003CShygunIIExportInfo_003Eb__8(WSspSelectWareHouse_Result x)
		{
			return x.WareHouseID == pordI.pordIWHId;
		}

		internal bool _003CShygunIIExportInfo_003Eb__5(WSspSelectWareHouse_Result x)
		{
			return x.WareHouseID == pordI.pordIWHId;
		}

		internal bool _003CShygunIIExportInfo_003Eb__6(WSspSelectProductWithAccLinkField_Result x)
		{
			return x.ProductID == pordI.pordIPrdId;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass84_3
	{
		public int Id;
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMLinkSpEntities _dbLink = new CRMLinkSpEntities();

	public string WrhsSyncTypeId = "WrhsSyncTypeId";

	public string shygunIIWrhsSyncTypeId = "WrhsSyncTypeId";

	public ActionResult SepPordSendToAcc(int mode, int position = 0, int payId = 0, int linkAccSettingDBId = 0)
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
				text = "frmPreOrder";
				text2 = "actSendToAcc";
				break;
			case 2:
				text = "frmPreOrder";
				text2 = "actSendPayToAcc";
				break;
			case 3:
				text = "frmPreOrder";
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
			text = "frmPordLinkAccDetails";
			text2 = "actAddLinkPordToAcc";
			break;
		case 2:
			text = "frmPordLinkAccDetails";
			text2 = "actAddLinkPordPayToAcc";
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
	public string SepActSendToAcc(int mode, int pordId, int payId, int sepFiscalYearRef, int sepUserId, bool sendPordPayToAcc, int position = 0, int linkAccSettingDBId = 0, int userId = 0)
	{
		_003C_003Ec__DisplayClass5_0 _003C_003Ec__DisplayClass5_ = new _003C_003Ec__DisplayClass5_0();
		_003C_003Ec__DisplayClass5_.pordId = pordId;
		_003C_003Ec__DisplayClass5_.payId = payId;
		string text = "";
		try
		{
			CRMspLoadUserLoginInfoViewModel cRMspLoadUserLoginInfoViewModel = null;
			if (userId != 0)
			{
				cRMspLoadUserLoginInfoViewModel = UserLogin.User(userId);
			}
			else
			{
				cRMspLoadUserLoginInfoViewModel = UserLogin.CurrentUser;
				userId = cRMspLoadUserLoginInfoViewModel.UserId;
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			base.ViewBag.Mode = mode;
			switch (mode)
			{
			case 1:
			{
				string formName = "frmPreOrder";
				string actionName = "actSendToAcc";
				if (position == 1)
				{
					formName = "frmPordLinkAccDetails";
					actionName = "actAddLinkPordToAcc";
				}
				if (!UserLogin.IsUserAccess(formName, actionName, cRMspLoadUserLoginInfoViewModel))
				{
					return Messages.ErrorNotAccess + "|";
				}
				if (_003C_003Ec__DisplayClass5_.pordId > 0)
				{
					DbSet<WSPreOrder> wSPreOrder2 = _dbTbl.WSPreOrder;
					ParameterExpression val = Expression.Parameter(typeof(WSPreOrder), "m");
					if (Queryable.FirstOrDefault<WSPreOrder>((IQueryable<WSPreOrder>)wSPreOrder2, Expression.Lambda<Func<WSPreOrder, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass5_, typeof(_003C_003Ec__DisplayClass5_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) != null)
					{
						string errorMessage2 = "";
						if (!PreOrder.SendToLinkAccNeedVerify(_003C_003Ec__DisplayClass5_.pordId, ref errorMessage2))
						{
							return errorMessage2 + "|";
						}
						ObjectParameter objectParameter2 = new ObjectParameter("insertedId", 0);
						ObjectParameter objectParameter3 = new ObjectParameter("errorMessage", "");
						ObjectParameter objectParameter4 = new ObjectParameter("preOrderNumber", 0);
						CRMLinkSpEntities dbLink2 = _dbLink;
						int? preOrderId2 = _003C_003Ec__DisplayClass5_.pordId;
						int? crmUserId = cRMspLoadUserLoginInfoViewModel.UserId;
						string appType = Configuration.AppType;
						ObjectParameter errorMessage = objectParameter2;
						ObjectParameter preOrderNumber = objectParameter4;
						ObjectParameter errorMessage3 = objectParameter3;
						dbLink2.CRMspLkSepWSIssuePreOrder(preOrderId2, sepFiscalYearRef, crmUserId, appType, errorMessage, preOrderNumber, errorMessage3, sepUserId, sendPordPayToAcc, linkAccSettingDBId);
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
								if (!string.IsNullOrWhiteSpace(text3) && text3.IndexOf("Financially incorrect in pordpayment", StringComparison.Ordinal) >= 0)
								{
									text3 = text3.Replace("Financially incorrect in pordpayment", "");
									text3 = text3.Replace(",,", "");
									text3 = text3 + ",(" + Labels.lblPordPay + ") " + Messages.msgErrorfinancialYearWrong;
									text3 = text3.TrimStart(new char[1] { ' ' }).TrimEnd(new char[1] { ' ' });
									return text3.TrimStart(new char[1] { ',' }).TrimEnd(new char[1] { ',' });
								}
								if (!string.IsNullOrWhiteSpace(text3) && text3.IndexOf("No Items", StringComparison.Ordinal) >= 0)
								{
									text3 = text3.Replace("No Items", "");
									text3 = text3.Replace(",,", "");
									text3 = text3 + "," + string.Format(Messages.msgErrorNotHaveItems, Labels.lblPOrd);
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
				string formName2 = "frmPreOrder";
				string actionName2 = "actSendPayToAcc";
				if (position == 2)
				{
					formName2 = "frmPordLinkAccDetails";
					actionName2 = "actAddLinkPordPayToAcc";
				}
				if (!UserLogin.IsUserAccess(formName2, actionName2, cRMspLoadUserLoginInfoViewModel))
				{
					return Messages.ErrorNotAccess + "|";
				}
				if (_003C_003Ec__DisplayClass5_.payId > 0)
				{
					DbSet<WSPreOrderPayments> wSPreOrderPayments = _dbTbl.WSPreOrderPayments;
					ParameterExpression val = Expression.Parameter(typeof(WSPreOrderPayments), "m");
					WSPreOrderPayments wSPreOrderPayments2 = Queryable.FirstOrDefault<WSPreOrderPayments>((IQueryable<WSPreOrderPayments>)wSPreOrderPayments, Expression.Lambda<Func<WSPreOrderPayments, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass5_, typeof(_003C_003Ec__DisplayClass5_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
					if (wSPreOrderPayments2 != null)
					{
						int result2 = 0;
						CRMspSelectLinkAccSetting_Result cRMspSelectLinkAccSetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_dbLink.CRMspSelectLinkAccSetting(0, "DefOrdPayType", lCID, result, 1, linkAccSettingDBId, "DefOrdPayTypeId"));
						if (cRMspSelectLinkAccSetting_Result != null && !string.IsNullOrEmpty(cRMspSelectLinkAccSetting_Result.PartValue))
						{
							int.TryParse(cRMspSelectLinkAccSetting_Result.PartValue, out result2);
						}
						if (result2 != 0 && result2 == wSPreOrderPayments2.pordpayTypeId)
						{
							return Messages.msgErrorNotTransferDefOrdPayToSepidar;
						}
						ObjectParameter objectParameter5 = new ObjectParameter("insertedId", 0);
						ObjectParameter objectParameter6 = new ObjectParameter("errorMessage", "");
						ObjectParameter objectParameter7 = new ObjectParameter("insertedNumber", 0);
						CRMLinkSpEntities dbLink3 = _dbLink;
						int? preOrderPaymentId = _003C_003Ec__DisplayClass5_.payId;
						int? crmUserId2 = cRMspLoadUserLoginInfoViewModel.UserId;
						string appType = Configuration.AppType;
						ObjectParameter errorMessage3 = objectParameter5;
						ObjectParameter preOrderNumber = objectParameter7;
						ObjectParameter errorMessage = objectParameter6;
						dbLink3.CRMspLkSepWSInsertUpdatePreOrderPayment(preOrderPaymentId, crmUserId2, sepFiscalYearRef, appType, errorMessage3, preOrderNumber, errorMessage, linkAccSettingDBId);
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
										case "-1":
											return Messages.msgErrorNotTransferDefOrdPayToSepidar;
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
									case "-1":
										return Messages.msgErrorNotTransferDefOrdPayToSepidar;
									case "-2":
										return Messages.msgErrorNotTransferPayWithNegativeAmountToSepidar;
									case "-3":
										return Messages.msgErrorfinancialYearWrong;
									case "-4":
										return Messages.msgErrorNotTransferPayNoAmountToSepidar;
									case "-5":
										return Messages.msgErrorNotTransferPayWithPositiveAmountToSepidar;
									}
									text7 = string.Format(Labels.PordPayListAccLinkHeaderNumber, text7);
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
								case "-1":
									return Messages.msgErrorNotTransferDefOrdPayToSepidar;
								case "-2":
									return Messages.msgErrorNotTransferPayWithNegativeAmountToSepidar;
								case "-3":
									return Messages.msgErrorfinancialYearWrong;
								case "-4":
									return Messages.msgErrorNotTransferPayNoAmountToSepidar;
								case "-5":
									return Messages.msgErrorNotTransferPayWithPositiveAmountToSepidar;
								}
								text8 = string.Format(Labels.PordPayListAccLinkHeaderNumber, text8);
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
				if (!UserLogin.IsUserAccess("frmPreOrder", "actSendAllPayToAcc", cRMspLoadUserLoginInfoViewModel))
				{
					return Messages.ErrorNotAccess + "|";
				}
				if (_003C_003Ec__DisplayClass5_.pordId > 0)
				{
					DbSet<WSPreOrder> wSPreOrder = _dbTbl.WSPreOrder;
					ParameterExpression val = Expression.Parameter(typeof(WSPreOrder), "m");
					if (Queryable.FirstOrDefault<WSPreOrder>((IQueryable<WSPreOrder>)wSPreOrder, Expression.Lambda<Func<WSPreOrder, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass5_, typeof(_003C_003Ec__DisplayClass5_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) != null)
					{
						ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
						CRMLinkSpEntities dbLink = _dbLink;
						int? preOrderId = _003C_003Ec__DisplayClass5_.pordId;
						int? crmUserId = cRMspLoadUserLoginInfoViewModel.UserId;
						string appType = Configuration.AppType;
						ObjectParameter errorMessage = objectParameter;
						dbLink.CRMspLkSepWSInsertUpdatePreOrderPaymentsAll(preOrderId, sepFiscalYearRef, crmUserId, appType, errorMessage, linkAccSettingDBId);
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
					CRMspLkSepWSSelectPreOrderPaymentsById_Result cRMspLkSepWSSelectPreOrderPaymentsById_Result = Enumerable.FirstOrDefault<CRMspLkSepWSSelectPreOrderPaymentsById_Result>((IEnumerable<CRMspLkSepWSSelectPreOrderPaymentsById_Result>)_dbLink.CRMspLkSepWSSelectPreOrderPaymentsById(payId, lCID, result2, linkAccSettingDBId));
					if (cRMspLkSepWSSelectPreOrderPaymentsById_Result != null)
					{
						int result3 = 0;
						int.TryParse(cRMspLkSepWSSelectPreOrderPaymentsById_Result.SepDetailType.ToString(), out result3);
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
					CRMspLkSepWSSelectPreOrderPaymentsById_Result cRMspLkSepWSSelectPreOrderPaymentsById_Result = Enumerable.FirstOrDefault<CRMspLkSepWSSelectPreOrderPaymentsById_Result>((IEnumerable<CRMspLkSepWSSelectPreOrderPaymentsById_Result>)_dbLink.CRMspLkSepWSSelectPreOrderPaymentsById(payId, lCID, result2, linkAccSettingDBId));
					if (cRMspLkSepWSSelectPreOrderPaymentsById_Result != null)
					{
						int result4 = 0;
						int.TryParse(cRMspLkSepWSSelectPreOrderPaymentsById_Result.SepDetailType.ToString(), out result4);
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

	[DynamicAuthorize(ControllerName = "frmPreOrder", ActionName = "actImportFromAcc")]
	public ActionResult SepImportPreOrder()
	{
		GetPreOrderOpr();
		GetPordReferUser();
		GetCrmFinancialPeriod();
		base.ViewBag.LinkAccSettingDBList = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccSettingDB(1);
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmImportFromAcc", ActionName = "actShowInfo")]
	public ActionResult SepPreOrder_Read([DataSourceRequest] DataSourceRequest request, int sepSaleTypeId, int pageNumber, string fDate = "", string tDate = "", int value = 0, int linkAccSettingDBId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SepPreOrderViewModel> list = new List<SepPreOrderViewModel>();
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
			foreach (CRMspLkSepWSSelectPreOrderFromSep_Result item2 in Enumerable.ToList<CRMspLkSepWSSelectPreOrderFromSep_Result>((IEnumerable<CRMspLkSepWSSelectPreOrderFromSep_Result>)_dbLink.CRMspLkSepWSSelectPreOrderFromSep(sepSaleTypeId, (!string.IsNullOrEmpty(fDate)) ? new DateTime?(value3) : null, (!string.IsNullOrEmpty(tDate)) ? new DateTime?(value4) : null, value, pageNumber, value2, lCID, result, linkAccSettingDBId)))
			{
				SepPreOrderViewModel item = new SepPreOrderViewModel
				{
					QuotationId = item2.QuotationId,
					CustomerParty = item2.CustomerParty,
					Number = item2.Number,
					Date = item2.Date,
					DatePersian = (item2.Date.HasValue ? item2.Date.Value.ToString("yyyy/MM/dd") : ""),
					NetPrice = item2.NetPrice,
					ItemCount = item2.ItemCount,
					PreOrderId = item2.PreOrderId,
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

	public int SepImportInfo(string records, int sepSaleTypeId, int preOrderOprId, int pordReferUserId, int pageNumber, string fDate = "", string tDate = "", int value = 0, bool isUsedCmpReferUserId = false, int crmFPId = 0, int linkAccSettingDBId = 0, int pagesCnt = 0)
	{
		int indx = -1;
		try
		{
			indx = ThreadHub.AddThread();
			new Thread((ThreadStart)delegate
			{
				SepImportInfoAsync(records, sepSaleTypeId, preOrderOprId, pordReferUserId, pageNumber, fDate, tDate, value, isUsedCmpReferUserId, crmFPId, linkAccSettingDBId, pagesCnt, indx);
			}).Start();
		}
		catch (Exception ex)
		{
			ThreadHub.SetThreadResult(indx, 0, ex.Message, false);
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		return indx;
	}

	public void SepImportInfoAsync(string records, int sepSaleTypeId, int preOrderOprId, int pordReferUserId, int pageNumber, string fDate = "", string tDate = "", int value = 0, bool isUsedCmpReferUserId = false, int crmFPId = 0, int linkAccSettingDBId = 0, int pagesCnt = 0, int indx = 0)
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
						ObjectParameter insertedPordId = new ObjectParameter("insertedPordId", 0);
						ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
						cRMLinkSpEntities.CRMspLkSepWSIssuePreOrderFromSep(item.Id, preOrderOprId, userId, value3, value2, registerDatePersian, appType, result, insertedPordId, objectParameter, pordReferUserId, isUsedCmpReferUserId, crmFPId, linkAccSettingDBId, centerId);
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
								text2 = text2 + "," + string.Format(Messages.msgErrorNotHaveItems, Labels.lblPOrd);
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
	public JsonResult GetSepImportPreOrderList(string records, int totalPage, int sepSaleTypeId, string fDate = "", string tDate = "", int value = 0, int linkAccSettingDBId = 0)
	{
		//IL_0237: Unknown result type (might be due to invalid IL or missing references)
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
			foreach (CRMspLkSepWSSelectPreOrderFromSep_Result item2 in Enumerable.ToList<CRMspLkSepWSSelectPreOrderFromSep_Result>((IEnumerable<CRMspLkSepWSSelectPreOrderFromSep_Result>)_dbLink.CRMspLkSepWSSelectPreOrderFromSep(sepSaleTypeId, (!string.IsNullOrEmpty(fDate)) ? new DateTime?(value4) : null, (!string.IsNullOrEmpty(tDate)) ? new DateTime?(value5) : null, value, value3, value2, lCID, result, linkAccSettingDBId)))
			{
				OtherSystemSelectedViewModel item = new OtherSystemSelectedViewModel
				{
					Row = item2.RowNumber.GetValueOrDefault(),
					Id = item2.QuotationId.GetValueOrDefault(),
					Selected = !item2.PreOrderId.HasValue
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

	[DynamicAuthorize(ControllerName = "frmPreOrder", ActionName = "actExportToAcc")]
	public ActionResult SepExportPreOrder()
	{
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
	public ActionResult SepExportPreOrder_Read([DataSourceRequest] DataSourceRequest request, int pageNumber, string fDate = "", string tDate = "", long value = 0L, int linkAccSettingDBId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SepPreOrderViewModel> list = new List<SepPreOrderViewModel>();
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
			foreach (CRMspLkSepWSSelectPreOrder_Result item2 in Enumerable.ToList<CRMspLkSepWSSelectPreOrder_Result>((IEnumerable<CRMspLkSepWSSelectPreOrder_Result>)_dbLink.CRMspLkSepWSSelectPreOrder(UserLogin.CurrentUser.UserId, (!string.IsNullOrEmpty(fDate)) ? new DateTime?(value3) : null, (!string.IsNullOrEmpty(tDate)) ? new DateTime?(value4) : null, value, pageNumber, value2, lCID, result, linkAccSettingDBId, result2)))
			{
				SepPreOrderViewModel item = new SepPreOrderViewModel
				{
					pordLinkAccPreOrderId = item2.pordLinkAccPreOrderId,
					Company = ((!string.IsNullOrEmpty(item2.CompanyName)) ? item2.CompanyName : "") + ((!string.IsNullOrEmpty(item2.CompanyPerson)) ? (" - " + item2.CompanyPerson) : ""),
					PordNumber = item2.pordNumber,
					Date = item2.pordDateTime,
					DatePersian = (item2.pordDateTime.HasValue ? item2.pordDateTime.Value.ToString("yyyy/MM/dd") : ""),
					pordTotalAmount = item2.pordTotalAmount,
					ItemCount = item2.pordItemCount,
					PreOrderId = item2.PreOrderID,
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

	public int SepExportInfo(int sepFiscalYearRef, string records, int sepUserId, bool sendPordPayToAcc, int pageNumber, string fDate = "", string tDate = "", long value = 0L, int linkAccSettingDBId = 0, int pagesCnt = 0)
	{
		int indx = -1;
		try
		{
			indx = ThreadHub.AddThread();
			new Thread((ThreadStart)delegate
			{
				SepExportInfoAsync(sepFiscalYearRef, records, sepUserId, sendPordPayToAcc, pageNumber, fDate, tDate, value, linkAccSettingDBId, pagesCnt, indx);
			}).Start();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return indx;
	}

	public void SepExportInfoAsync(int sepFiscalYearRef, string records, int sepUserId, bool sendPordPayToAcc, int pageNumber, string fDate = "", string tDate = "", long value = 0L, int linkAccSettingDBId = 0, int pagesCnt = 0, int indx = 0)
	{
		//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
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
			DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			_ = Financial.Get().Id;
			short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
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
							CRMspLkWSSelectPreOrderById_Result cRMspLkWSSelectPreOrderById_Result = Enumerable.FirstOrDefault<CRMspLkWSSelectPreOrderById_Result>((IEnumerable<CRMspLkWSSelectPreOrderById_Result>)cRMLinkSpEntities.CRMspLkWSSelectPreOrderById(item.Id, lCID, result, result2));
							if (cRMspLkWSSelectPreOrderById_Result != null)
							{
								string errorMessage = "";
								if (!PreOrder.SendToLinkAccNeedVerify(item.Id, ref errorMessage))
								{
									text = text + errorMessage + "<br>";
									num = 0;
								}
								else
								{
									ObjectParameter objectParameter = new ObjectParameter("insertedId", 0);
									ObjectParameter objectParameter2 = new ObjectParameter("errorMessage", "");
									ObjectParameter objectParameter3 = new ObjectParameter("preOrderNumber", typeof(long));
									int? preOrderId = item.Id;
									int? crmUserId = userId;
									string appType2 = appType;
									ObjectParameter insertedId = objectParameter;
									ObjectParameter preOrderNumber = objectParameter3;
									ObjectParameter errorMessage2 = objectParameter2;
									cRMLinkSpEntities.CRMspLkSepWSIssuePreOrder(preOrderId, sepFiscalYearRef, crmUserId, appType2, insertedId, preOrderNumber, errorMessage2, sepUserId, sendPordPayToAcc, linkAccSettingDBId);
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
													cRMspLkWSSelectPreOrderById_Result.pordLinkAccPreOrderNumber = text3;
												}
											}
											string text4 = objectParameter2.Value.ToString();
											if (!string.IsNullOrWhiteSpace(text4) && text4.IndexOf("Financially incorrect in pordpayment", StringComparison.Ordinal) >= 0)
											{
												text4 = text4.Replace("Financially incorrect in pordpayment", "");
												text4 = text4.Replace(",,", "");
												text4 = text4 + ",(" + Labels.lblPordPay + ") " + Messages.msgErrorfinancialYearWrong;
												text4 = text4.TrimStart(new char[1] { ' ' }).TrimEnd(new char[1] { ' ' });
												text4 = text4.TrimStart(new char[1] { ',' }).TrimEnd(new char[1] { ',' });
												if (!string.IsNullOrWhiteSpace(text2))
												{
													text2 += "<br>";
												}
												text2 += text4;
											}
											if (!string.IsNullOrWhiteSpace(text4) && text4.IndexOf("No Items", StringComparison.Ordinal) >= 0)
											{
												text4 = text4.Replace("No Items", "");
												text4 = text4.Replace(",,", "");
												text4 = text4 + "," + string.Format(Messages.msgErrorNotHaveItems, Labels.lblPOrd);
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
													cRMspLkWSSelectPreOrderById_Result.pordLinkAccPreOrderNumber = text5;
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
												cRMspLkWSSelectPreOrderById_Result.pordLinkAccPreOrderNumber = text6;
											}
										}
									}
									if (!string.IsNullOrWhiteSpace(text2))
									{
										num = 0;
										if (text2.IndexOf("Financially incorrect in pordpayment", StringComparison.Ordinal) >= 0)
										{
											text2 = text2.Replace("Financially incorrect in pordpayment", "");
											text2 = text2.Replace(",,", "");
											text2 = text2 + ",(" + Labels.lblPordPay + ") " + Messages.msgErrorfinancialYearWrong;
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
		}
	}

	[AjaxOnly]
	public JsonResult GetExportPreOrderList(string records, int totalPage, string fDate = "", string tDate = "", long value = 0L, int linkAccSettingDBId = 0)
	{
		//IL_026e: Unknown result type (might be due to invalid IL or missing references)
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
			foreach (CRMspLkSepWSSelectPreOrder_Result item2 in Enumerable.ToList<CRMspLkSepWSSelectPreOrder_Result>((IEnumerable<CRMspLkSepWSSelectPreOrder_Result>)_dbLink.CRMspLkSepWSSelectPreOrder(UserLogin.CurrentUser.UserId, (!string.IsNullOrEmpty(fDate)) ? new DateTime?(value4) : null, (!string.IsNullOrEmpty(tDate)) ? new DateTime?(value5) : null, value, value3, value2, lCID, result, linkAccSettingDBId, result2)))
			{
				OtherSystemSelectedViewModel item = new OtherSystemSelectedViewModel
				{
					Row = item2.RowNumber.GetValueOrDefault(),
					Id = item2.PreOrderID.GetValueOrDefault(),
					Selected = !item2.pordLinkAccPreOrderId.HasValue
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

	public ActionResult SepSetFieldsIssuedOrdFromPord(int mode)
	{
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmPreOrder", ActionName = "actImportFromAcc")]
	public ActionResult SepControlAndDeletePreOrder()
	{
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmPreOrder", ActionName = "actPordLinkAccDetails")]
	public ActionResult SepPordLinkAccDetails(int pordId)
	{
		base.ViewBag.PordId = pordId;
		base.ViewBag.LinkAccSettingDBList = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccSettingDB(1);
		return View();
	}

	[AjaxOnly]
	public JsonResult GetPordLinkAccDetails(int pordId, int linkAccSettingDBId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		SepPordLinkAccDetailsViewModel sepPordLinkAccDetailsViewModel = new SepPordLinkAccDetailsViewModel();
		sepPordLinkAccDetailsViewModel.PreOrderInfo = new CRMspLkSepWSSelectPreOrderByPordId_Result();
		sepPordLinkAccDetailsViewModel.PreOrderItems = new List<CRMspLkSepWSSelectPreOrderItemsByPordId_Result>();
		sepPordLinkAccDetailsViewModel.PreOrderPayments = new List<CRMspLkSepWSSelectPreOrderPaymentsByPordId_Result>();
		sepPordLinkAccDetailsViewModel.IsFind = false;
		try
		{
			if (pordId != 0)
			{
				sepPordLinkAccDetailsViewModel.PreOrderInfo = Enumerable.FirstOrDefault<CRMspLkSepWSSelectPreOrderByPordId_Result>((IEnumerable<CRMspLkSepWSSelectPreOrderByPordId_Result>)_dbLink.CRMspLkSepWSSelectPreOrderByPordId(pordId, lCID, result, linkAccSettingDBId));
				if (sepPordLinkAccDetailsViewModel.PreOrderInfo != null)
				{
					sepPordLinkAccDetailsViewModel.IsFind = true;
					sepPordLinkAccDetailsViewModel.PreOrderInfo.pordDate = (sepPordLinkAccDetailsViewModel.PreOrderInfo.pordDateTime.HasValue ? sepPordLinkAccDetailsViewModel.PreOrderInfo.pordDateTime.Value.ToString("yyyy/MM/dd") : "");
					sepPordLinkAccDetailsViewModel.PreOrderInfo.SepQuotationDatePersian = (sepPordLinkAccDetailsViewModel.PreOrderInfo.SepQuotationDate.HasValue ? sepPordLinkAccDetailsViewModel.PreOrderInfo.SepQuotationDate.Value.ToString("yyyy/MM/dd") : "");
					sepPordLinkAccDetailsViewModel.PreOrderInfo.PreOrderOpr = ((!string.IsNullOrWhiteSpace(sepPordLinkAccDetailsViewModel.PreOrderInfo.PreOrderOpr)) ? sepPordLinkAccDetailsViewModel.PreOrderInfo.PreOrderOpr : Labels.lblPOrd) + " (" + sepPordLinkAccDetailsViewModel.PreOrderInfo.pordNumber + ")";
					sepPordLinkAccDetailsViewModel.PreOrderInfo.pordCurrencyUnitIsDecimal = sepPordLinkAccDetailsViewModel.PreOrderInfo.pordCurrencyUnitIsDecimal.GetValueOrDefault();
					sepPordLinkAccDetailsViewModel.PreOrderInfo.pordLinkAccFirstTransferDateStr = (sepPordLinkAccDetailsViewModel.PreOrderInfo.pordLinkAccFirstTransferDate.HasValue ? sepPordLinkAccDetailsViewModel.PreOrderInfo.pordLinkAccFirstTransferDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
					sepPordLinkAccDetailsViewModel.PreOrderInfo.pordLinkAccLastTransferDateStr = (sepPordLinkAccDetailsViewModel.PreOrderInfo.pordLinkAccLastTransferDate.HasValue ? sepPordLinkAccDetailsViewModel.PreOrderInfo.pordLinkAccLastTransferDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
					sepPordLinkAccDetailsViewModel.PreOrderItems = Enumerable.ToList<CRMspLkSepWSSelectPreOrderItemsByPordId_Result>((IEnumerable<CRMspLkSepWSSelectPreOrderItemsByPordId_Result>)_dbLink.CRMspLkSepWSSelectPreOrderItemsByPordId(pordId, lCID, result, linkAccSettingDBId));
					if (sepPordLinkAccDetailsViewModel.PreOrderItems != null && Enumerable.Any<CRMspLkSepWSSelectPreOrderItemsByPordId_Result>((IEnumerable<CRMspLkSepWSSelectPreOrderItemsByPordId_Result>)sepPordLinkAccDetailsViewModel.PreOrderItems))
					{
						foreach (CRMspLkSepWSSelectPreOrderItemsByPordId_Result preOrderItem in sepPordLinkAccDetailsViewModel.PreOrderItems)
						{
							preOrderItem.PrdQtyNoFCR = preOrderItem.PrdQtyNoFCR.GetValueOrDefault();
							preOrderItem.pordILinkAccFirstTransferDateStr = (preOrderItem.pordILinkAccFirstTransferDate.HasValue ? preOrderItem.pordILinkAccFirstTransferDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
							preOrderItem.pordILinkAccLastTransferDateStr = (preOrderItem.pordILinkAccLastTransferDate.HasValue ? preOrderItem.pordILinkAccLastTransferDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
						}
					}
					else
					{
						sepPordLinkAccDetailsViewModel.PreOrderItems = new List<CRMspLkSepWSSelectPreOrderItemsByPordId_Result>();
					}
					sepPordLinkAccDetailsViewModel.PreOrderPayments = Enumerable.ToList<CRMspLkSepWSSelectPreOrderPaymentsByPordId_Result>((IEnumerable<CRMspLkSepWSSelectPreOrderPaymentsByPordId_Result>)_dbLink.CRMspLkSepWSSelectPreOrderPaymentsByPordId(pordId, lCID, result, linkAccSettingDBId));
					if (sepPordLinkAccDetailsViewModel.PreOrderPayments != null && Enumerable.Any<CRMspLkSepWSSelectPreOrderPaymentsByPordId_Result>((IEnumerable<CRMspLkSepWSSelectPreOrderPaymentsByPordId_Result>)sepPordLinkAccDetailsViewModel.PreOrderPayments))
					{
						foreach (CRMspLkSepWSSelectPreOrderPaymentsByPordId_Result preOrderPayment in sepPordLinkAccDetailsViewModel.PreOrderPayments)
						{
							preOrderPayment.ImportDate = (preOrderPayment.ImportDateTime.HasValue ? preOrderPayment.ImportDateTime.Value.ToString("yyyy/MM/dd") : "");
							preOrderPayment.pordpayDocDate = (preOrderPayment.pordpayDocDateTime.HasValue ? preOrderPayment.pordpayDocDateTime.Value.ToString("yyyy/MM/dd") : "");
							preOrderPayment.pordpayLinkAccFirstTransferDateStr = (preOrderPayment.pordpayLinkAccFirstTransferDate.HasValue ? preOrderPayment.pordpayLinkAccFirstTransferDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
							preOrderPayment.pordpayLinkAccLastTransferDateStr = (preOrderPayment.pordpayLinkAccLastTransferDate.HasValue ? preOrderPayment.pordpayLinkAccLastTransferDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
							int result2 = 0;
							int.TryParse(preOrderPayment.SepDetailType.ToString(), out result2);
							if (string.IsNullOrWhiteSpace(preOrderPayment.pordpayLinkAccPayType))
							{
								switch (result2)
								{
								case 1:
									preOrderPayment.SepDetailTypeTitle = Labels.LinkAccSettingCash;
									break;
								case 2:
									preOrderPayment.SepDetailTypeTitle = Labels.LinkAccSettingChqeue;
									break;
								case 3:
									preOrderPayment.SepDetailTypeTitle = Labels.LinkAccSettingDraft;
									break;
								case 4:
									preOrderPayment.SepDetailTypeTitle = Labels.LinkAccSettingCardReader;
									break;
								default:
									preOrderPayment.SepDetailTypeTitle = "";
									break;
								}
							}
							else
							{
								if (string.IsNullOrWhiteSpace(preOrderPayment.pordpayLinkAccPayType))
								{
									continue;
								}
								if (preOrderPayment.pordpayLinkAccPayType == "neg")
								{
									switch (result2)
									{
									case 1:
										preOrderPayment.SepDetailTypeTitle = Labels.LinkAccSettingCash;
										break;
									case 2:
										preOrderPayment.SepDetailTypeTitle = Labels.LinkAccSettingChqeue;
										break;
									case 3:
										preOrderPayment.SepDetailTypeTitle = Labels.LinkAccSettingWithdrawalNotice;
										break;
									default:
										preOrderPayment.SepDetailTypeTitle = "";
										break;
									}
								}
								else
								{
									if (!(preOrderPayment.pordpayLinkAccPayType == "dup"))
									{
										continue;
									}
									if (preOrderPayment.pordpayAmount < 0m)
									{
										switch (result2)
										{
										case 1:
											preOrderPayment.SepDetailTypeTitle = Labels.LinkAccSettingCash;
											break;
										case 2:
											preOrderPayment.SepDetailTypeTitle = Labels.LinkAccSettingChqeue;
											break;
										case 3:
											preOrderPayment.SepDetailTypeTitle = Labels.LinkAccSettingWithdrawalNotice;
											break;
										default:
											preOrderPayment.SepDetailTypeTitle = "";
											break;
										}
									}
									else if (preOrderPayment.pordpayAmount > 0m)
									{
										switch (result2)
										{
										case 1:
											preOrderPayment.SepDetailTypeTitle = Labels.LinkAccSettingCash;
											break;
										case 2:
											preOrderPayment.SepDetailTypeTitle = Labels.LinkAccSettingChqeue;
											break;
										case 3:
											preOrderPayment.SepDetailTypeTitle = Labels.LinkAccSettingDraft;
											break;
										case 4:
											preOrderPayment.SepDetailTypeTitle = Labels.LinkAccSettingCardReader;
											break;
										default:
											preOrderPayment.SepDetailTypeTitle = "";
											break;
										}
									}
								}
							}
						}
					}
					else
					{
						sepPordLinkAccDetailsViewModel.PreOrderPayments = new List<CRMspLkSepWSSelectPreOrderPaymentsByPordId_Result>();
					}
				}
				else
				{
					sepPordLinkAccDetailsViewModel.Message = Messages.ErrorNotFound;
				}
			}
			else
			{
				sepPordLinkAccDetailsViewModel.Message = Messages.msgErrorNotSelectedItem;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			sepPordLinkAccDetailsViewModel.Message = Messages.msgErrorRunFunction + "<br />" + ex.Message;
		}
		JsonResult jsonResult = Json(sepPordLinkAccDetailsViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult SepDeletePreOrderInfo(int pordId, int pordItemId, int pordPayId, int mode, int position, int linkAccSettingDBId)
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
				actionName = "actDelLinkPordInAcc";
				break;
			case 2:
				actionName = "actDelLinkPordInCrm";
				break;
			case 11:
				actionName = "actDelLinkPordItemInAcc";
				break;
			case 12:
				actionName = "actDelLinkPordItemInCrm";
				break;
			case 21:
				actionName = "actDelLinkPordPayInAcc";
				flag = true;
				break;
			case 22:
				actionName = "actDelLinkPordPayInCrm";
				flag = true;
				break;
			case 23:
				actionName = "actDelLinkPordPayRefundInAcc";
				flag = true;
				break;
			case 24:
				actionName = "actDelLinkPordPayRefundInCrm";
				flag = true;
				break;
			}
			if (!UserLogin.IsUserAccess("frmPordLinkAccDetails", actionName, currentUser))
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
			if (pordId > 0)
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
					_dbLink.CRMspLkSepWSDeletePreOrderPaymentFromSep(pordPayId, userId, value2, id, value, text3, appType, objectParameter, mode, linkAccSettingDBId);
				}
				else
				{
					CRMLinkSpEntities dbLink = _dbLink;
					int? preOrderId = pordId;
					int? preOrderItemId = pordItemId;
					int? crmUserId = userId;
					int? month = value2;
					int? fPId = id;
					DateTime? registerDate = value;
					string registerDatePersian = text3;
					string appType2 = appType;
					ObjectParameter errorMessage = objectParameter;
					dbLink.CRMspLkSepWSDeletePreOrderInfoFromSep(preOrderId, preOrderItemId, mode, crmUserId, month, fPId, registerDate, registerDatePersian, appType2, errorMessage, linkAccSettingDBId);
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

	[DynamicAuthorize(ControllerName = "frmPreOrder", ActionName = "actSendToAcc")]
	public ActionResult NoAvPordSendToAcc()
	{
		return View();
	}

	[AjaxOnly]
	public string NoAvActSendToAcc(int pordId, string comDbName, string whDbName, int noAvCodeStore, int noAvIdCompany, int noAvSalesManId, int noAvKindFactor)
	{
		_003C_003Ec__DisplayClass24_0 _003C_003Ec__DisplayClass24_ = new _003C_003Ec__DisplayClass24_0();
		_003C_003Ec__DisplayClass24_.pordId = pordId;
		string text = "";
		try
		{
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (!UserLogin.IsUserAccess("frmPreOrder", "actSendToAcc", currentUser))
			{
				return Messages.ErrorNotAccess + "|";
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (_003C_003Ec__DisplayClass24_.pordId > 0)
			{
				DbSet<WSPreOrder> wSPreOrder = _dbTbl.WSPreOrder;
				ParameterExpression val = Expression.Parameter(typeof(WSPreOrder), "m");
				if (Queryable.FirstOrDefault<WSPreOrder>((IQueryable<WSPreOrder>)wSPreOrder, Expression.Lambda<Func<WSPreOrder, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass24_, typeof(_003C_003Ec__DisplayClass24_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) != null)
				{
					string errorMessage = "";
					if (!PreOrder.SendToLinkAccNeedVerify(_003C_003Ec__DisplayClass24_.pordId, ref errorMessage))
					{
						return errorMessage + "|";
					}
					ObjectParameter insertedId = new ObjectParameter("insertedId", 0);
					ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
					ObjectParameter objectParameter2 = new ObjectParameter("insertedNumber", 0);
					_dbLink.CRMspLkNoAvWSIssuePreOrder(_003C_003Ec__DisplayClass24_.pordId, noAvIdCompany, noAvSalesManId, noAvKindFactor, noAvCodeStore, comDbName, whDbName, UserLogin.CurrentUser.UserId, Configuration.AppType, insertedId, objectParameter2, objectParameter);
					if (objectParameter.Value != null)
					{
						if (!string.IsNullOrEmpty(objectParameter.Value.ToString()))
						{
							return objectParameter.Value.ToString();
						}
						string text2 = "";
						if (objectParameter2.Value != null)
						{
							text2 = objectParameter2.Value.ToString() ?? "";
						}
						return "1|" + text2;
					}
					string text3 = "";
					if (objectParameter2.Value != null)
					{
						text3 = objectParameter2.Value.ToString() ?? "";
					}
					return "1|" + text3;
				}
				return Messages.ErrorNotFound + "|";
			}
			return Messages.ErrorNotFound + "|";
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return Messages.msgErrorRunFunction + "|";
		}
	}

	[DynamicAuthorize(ControllerName = "frmPreOrder", ActionName = "actExportToAcc")]
	public ActionResult NoAvExportPreOrder()
	{
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmExportToAcc", ActionName = "actShowInfo")]
	public ActionResult NoAvExportPreOrder_Read([DataSourceRequest] DataSourceRequest request, int pageNumber, string fDate = "", string tDate = "", long value = 0L)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SepPreOrderViewModel> list = new List<SepPreOrderViewModel>();
		try
		{
			int value2 = 500;
			pageNumber = ((pageNumber <= 0) ? 1 : pageNumber);
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
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
			foreach (CRMspLkNoAvWSSelectPreOrder_Result item2 in Enumerable.ToList<CRMspLkNoAvWSSelectPreOrder_Result>((IEnumerable<CRMspLkNoAvWSSelectPreOrder_Result>)_dbLink.CRMspLkNoAvWSSelectPreOrder(UserLogin.CurrentUser.UserId, (!string.IsNullOrEmpty(fDate)) ? new DateTime?(value3) : null, (!string.IsNullOrEmpty(tDate)) ? new DateTime?(value4) : null, value, pageNumber, value2, lCID, result, centerId)))
			{
				SepPreOrderViewModel item = new SepPreOrderViewModel
				{
					pordLinkAccPreOrderId = item2.pordLinkAccPreOrderId,
					Company = ((!string.IsNullOrEmpty(item2.CompanyName)) ? item2.CompanyName : "") + ((!string.IsNullOrEmpty(item2.CompanyPerson)) ? (" - " + item2.CompanyPerson) : ""),
					PordNumber = item2.pordNumber,
					Date = item2.pordDateTime,
					DatePersian = (item2.pordDateTime.HasValue ? item2.pordDateTime.Value.ToString("yyyy/MM/dd") : ""),
					pordTotalAmount = item2.pordTotalAmount,
					ItemCount = item2.pordItemCount,
					PreOrderId = item2.PreOrderID,
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

	[DynamicAuthorize(ControllerName = "frmExportToAcc", ActionName = "actSendToAcc")]
	[AjaxOnly]
	public JsonResult NoAvExportInfo(string records, string comDbName, string whDbName, int noAvCodeStore, int noAvIdCompany, int noAvSalesManId, int noAvKindFactor, int pageNumber, string fDate = "", string tDate = "", long value = 0L)
	{
		//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int num = 0;
		string text = "";
		CommonResultStatusViewModel commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		CommonResultViewModel<int> data;
		try
		{
			DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			_ = Financial.Get().Id;
			short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			int value2 = 500;
			pageNumber = ((pageNumber <= 0) ? 1 : pageNumber);
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
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
			string text2 = "";
			if (!string.IsNullOrWhiteSpace(records))
			{
				List<OtherSystemSelectedViewModel> list = new List<OtherSystemSelectedViewModel>();
				list = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedViewModel>>(records);
				if (Enumerable.Any<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list))
				{
					foreach (OtherSystemSelectedViewModel item in list)
					{
						if (item.Selected)
						{
							text2 = text2 + item.Id + ",";
						}
					}
				}
			}
			ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
			CRMLinkSpEntities dbLink = _dbLink;
			int? noAvIdCompany2 = noAvIdCompany;
			int? noAvSalesManId2 = noAvSalesManId;
			int? noAvKindFactor2 = noAvKindFactor;
			int? noAvCodeStore2 = noAvCodeStore;
			DateTime? fDate2 = ((!string.IsNullOrEmpty(fDate)) ? new DateTime?(value3) : null);
			DateTime? tDATE = ((!string.IsNullOrEmpty(tDate)) ? new DateTime?(value4) : null);
			long? pordNumber = value;
			int? pageNumber2 = pageNumber;
			int? pageSize = value2;
			int? userId2 = userId;
			string appType2 = appType;
			ObjectParameter errorMessage = objectParameter;
			dbLink.CRMspLkNoAvWSExportPreOrder(noAvIdCompany2, noAvSalesManId2, noAvKindFactor2, noAvCodeStore2, comDbName, whDbName, fDate2, tDATE, pordNumber, text2, pageNumber2, pageSize, userId2, appType2, errorMessage, centerId);
			if (objectParameter.Value != null)
			{
				if (!string.IsNullOrEmpty(objectParameter.Value.ToString()))
				{
					num = 0;
					text = objectParameter.Value.ToString();
					commonResultStatusViewModel = CommonResultStatusViewModel.Error;
				}
				else
				{
					num = 1;
					text = Messages.msgSuccessAction;
					commonResultStatusViewModel = CommonResultStatusViewModel.Success;
				}
			}
			else
			{
				num = 1;
				text = Messages.msgSuccessAction;
				commonResultStatusViewModel = CommonResultStatusViewModel.Success;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			num = 0;
			data = new CommonResultViewModel<int>
			{
				Data = num,
				Message = Messages.msgErrorRunFunction,
				Status = CommonResultStatusViewModel.Error
			};
			return Json(data, JsonRequestBehavior.AllowGet);
		}
		data = new CommonResultViewModel<int>
		{
			Data = num,
			Message = text,
			Status = commonResultStatusViewModel
		};
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetNoAvExportPreOrderList(string records, int totalPage, string fDate = "", string tDate = "", long value = 0L)
	{
		//IL_024b: Unknown result type (might be due to invalid IL or missing references)
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
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
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
			foreach (CRMspLkNoAvWSSelectPreOrder_Result item2 in Enumerable.ToList<CRMspLkNoAvWSSelectPreOrder_Result>((IEnumerable<CRMspLkNoAvWSSelectPreOrder_Result>)_dbLink.CRMspLkNoAvWSSelectPreOrder(UserLogin.CurrentUser.UserId, (!string.IsNullOrEmpty(fDate)) ? new DateTime?(value4) : null, (!string.IsNullOrEmpty(tDate)) ? new DateTime?(value5) : null, value, value3, value2, lCID, result, centerId)))
			{
				OtherSystemSelectedViewModel item = new OtherSystemSelectedViewModel
				{
					Row = item2.RowNumber.GetValueOrDefault(),
					Id = item2.PreOrderID,
					Selected = !item2.pordLinkAccPreOrderId.HasValue
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

	[AjaxOnly]
	public JsonResult GetNoAvDatabase(string dbName)
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
			List<CRMspLkNoAvSelectDbNames_Result> list2 = Enumerable.ToList<CRMspLkNoAvSelectDbNames_Result>((IEnumerable<CRMspLkNoAvSelectDbNames_Result>)_dbLink.CRMspLkNoAvSelectDbNames(dbName));
			list.AddRange(Enumerable.Select<CRMspLkNoAvSelectDbNames_Result, SelectListItem>((IEnumerable<CRMspLkNoAvSelectDbNames_Result>)list2, (Func<CRMspLkNoAvSelectDbNames_Result, SelectListItem>)((CRMspLkNoAvSelectDbNames_Result item) => new SelectListItem
			{
				Text = item.name,
				Value = item.name,
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.DatabaseList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetSelfCompany(string dbName)
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
			List<mct_CRMspLkNoAvSelectSelfCompany_Result> list2 = Enumerable.ToList<mct_CRMspLkNoAvSelectSelfCompany_Result>((IEnumerable<mct_CRMspLkNoAvSelectSelfCompany_Result>)_dbLink.mfi_CRMspLkNoAvSelectSelfCompany(dbName));
			list.AddRange(Enumerable.Select<mct_CRMspLkNoAvSelectSelfCompany_Result, SelectListItem>((IEnumerable<mct_CRMspLkNoAvSelectSelfCompany_Result>)list2, (Func<mct_CRMspLkNoAvSelectSelfCompany_Result, SelectListItem>)((mct_CRMspLkNoAvSelectSelfCompany_Result item) => new SelectListItem
			{
				Text = item.NameCmp + ((!string.IsNullOrWhiteSpace(item.FirstName) || !string.IsNullOrWhiteSpace(item.LastName)) ? (" (" + ((!string.IsNullOrWhiteSpace(item.FirstName)) ? (item.FirstName + " ") : "") + ((!string.IsNullOrWhiteSpace(item.LastName)) ? item.LastName : "") + ")") : ""),
				Value = item.id.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.SelfCompanyList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetNoAvStore(string dbName)
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
			List<mct_CRMspLkNoAvSelectStore_Result> list2 = Enumerable.ToList<mct_CRMspLkNoAvSelectStore_Result>((IEnumerable<mct_CRMspLkNoAvSelectStore_Result>)_dbLink.mfi_CRMspLkNoAvSelectStore(dbName));
			list.AddRange(Enumerable.Select<mct_CRMspLkNoAvSelectStore_Result, SelectListItem>((IEnumerable<mct_CRMspLkNoAvSelectStore_Result>)list2, (Func<mct_CRMspLkNoAvSelectStore_Result, SelectListItem>)((mct_CRMspLkNoAvSelectStore_Result item) => new SelectListItem
			{
				Text = item.Name,
				Value = item.Code.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.StoreList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetNoAvSalesMan(string dbName)
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
			List<mct_CRMspLkNoAvSelectSalesMan_Result> list2 = Enumerable.ToList<mct_CRMspLkNoAvSelectSalesMan_Result>((IEnumerable<mct_CRMspLkNoAvSelectSalesMan_Result>)_dbLink.mfi_CRMspLkNoAvSelectSalesMan(dbName));
			list.AddRange(Enumerable.Select<mct_CRMspLkNoAvSelectSalesMan_Result, SelectListItem>((IEnumerable<mct_CRMspLkNoAvSelectSalesMan_Result>)list2, (Func<mct_CRMspLkNoAvSelectSalesMan_Result, SelectListItem>)((mct_CRMspLkNoAvSelectSalesMan_Result item) => new SelectListItem
			{
				Text = item.FullName,
				Value = item.id.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.SalesManList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmPreOrder", ActionName = "actSendToAcc")]
	public ActionResult NoAvIIPordSendToAcc()
	{
		return View();
	}

	[AjaxOnly]
	public string NoAvIIActSendToAcc(int pordId)
	{
		_003C_003Ec__DisplayClass34_0 _003C_003Ec__DisplayClass34_ = new _003C_003Ec__DisplayClass34_0();
		_003C_003Ec__DisplayClass34_.pordId = pordId;
		string result = "";
		try
		{
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (!UserLogin.IsUserAccess("frmPreOrder", "actSendToAcc", currentUser))
			{
				return Messages.ErrorNotAccess + "|";
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (_003C_003Ec__DisplayClass34_.pordId > 0)
			{
				WSspSelectPreOrderWithId_Result pord = Enumerable.FirstOrDefault<WSspSelectPreOrderWithId_Result>((IEnumerable<WSspSelectPreOrderWithId_Result>)_db.WSspSelectPreOrderWithId(_003C_003Ec__DisplayClass34_.pordId, lCID, result2));
				if (pord != null)
				{
					string errorMessage = "";
					if (!PreOrder.SendToLinkAccNeedVerify(_003C_003Ec__DisplayClass34_.pordId, ref errorMessage))
					{
						return errorMessage + "|";
					}
					if (!string.IsNullOrWhiteSpace(pord.pordLinkAccPreOrderNumber))
					{
						return string.Format(Messages.msgErrorNotReSendPordToOtherSystem, pord.pordNumber.ToString(), Labels.NoAvaranII) + "|";
					}
					List<WSspSelectProducts_Result> list = Enumerable.ToList<WSspSelectProducts_Result>((IEnumerable<WSspSelectProducts_Result>)_db.WSspSelectProducts(lCID, result2));
					List<WSspSelectWareHouseWithAccLinkField_Result> list2 = Enumerable.ToList<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)_dbLink.WSspSelectWareHouseWithAccLinkField(false, false, false, languageID: lCID, defaultLanguageID: result2, withWrhsLinkAccWareHouses: false));
					List<WSspSelectPreOrderItems_Result> list3 = Enumerable.ToList<WSspSelectPreOrderItems_Result>((IEnumerable<WSspSelectPreOrderItems_Result>)_db.WSspSelectPreOrderItems(_003C_003Ec__DisplayClass34_.pordId, lCID, result2));
					if (list3 != null && Enumerable.Any<WSspSelectPreOrderItems_Result>((IEnumerable<WSspSelectPreOrderItems_Result>)list3))
					{
						foreach (WSspSelectPreOrderItems_Result item2 in list3)
						{
							WSspSelectProducts_Result wSspSelectProducts_Result = Enumerable.FirstOrDefault<WSspSelectProducts_Result>((IEnumerable<WSspSelectProducts_Result>)list, (Func<WSspSelectProducts_Result, bool>)((WSspSelectProducts_Result m) => m.ProductID == item2.pordIPrdId));
							if (wSspSelectProducts_Result != null && string.IsNullOrEmpty(wSspSelectProducts_Result.PrdLinkAccPrdCode))
							{
								result = string.Format(Messages.msgErrorInSendOrdToAccLinkNotFoundPrdInAcc, pord.pordNumber, Labels.NoAvaranII, wSspSelectProducts_Result.PrdName ?? "") + "|";
								return result;
							}
							if (item2.pordIWHId.HasValue)
							{
								WSspSelectWareHouseWithAccLinkField_Result wSspSelectWareHouseWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)list2, (Func<WSspSelectWareHouseWithAccLinkField_Result, bool>)((WSspSelectWareHouseWithAccLinkField_Result m) => m.WareHouseID == item2.pordIWHId));
								if (wSspSelectWareHouseWithAccLinkField_Result != null && string.IsNullOrEmpty(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhCode))
								{
									result = string.Format(Messages.msgErrorInSendOrdToAccLinkNotFoundWhInAcc, pord.pordNumber, Labels.NoAvaranII, wSspSelectWareHouseWithAccLinkField_Result.WrhsName ?? "") + "|";
									return result;
								}
							}
						}
					}
					string text = "";
					CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(pord.pordCompanyId.GetValueOrDefault());
					if (companyById == null)
					{
						return Messages.CompanyNotFound + "|";
					}
					text = companyById.cmpLinkAccCode ?? "";
					if (string.IsNullOrEmpty(text))
					{
						string text2 = new CompanyController().NoAvIIActCmpSendToAcc(pord.pordCompanyId.GetValueOrDefault());
						if (string.IsNullOrEmpty(text2))
						{
							return Messages.msgErrorRunFunction + "|";
						}
						string[] array = text2.Split(new char[1] { '|' });
						if (array != null)
						{
							if (!(array[0] == "1"))
							{
								return array[0] + "|";
							}
							companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(pord.pordCompanyId.GetValueOrDefault());
							if (companyById == null)
							{
								return Messages.CompanyNotFound + "|";
							}
							text = companyById.cmpLinkAccCode ?? "";
						}
					}
					if (string.IsNullOrEmpty(text))
					{
						return string.Format(Messages.msgErrorInSendToAccLinkNotFoundCmpInAcc, Labels.NoAvaranII);
					}
					DateTime dateTime = default(DateTime);
					string text3 = "";
					try
					{
						if (pord.pordDateTime.HasValue)
						{
							text3 = (pord.pordDateTime.HasValue ? pord.pordDateTime.Value.ToString("yyyy/MM/dd", new PersianCulture()) : "");
						}
						else if (!string.IsNullOrEmpty(pord.pordDate))
						{
							text3 = DateTime.Parse(PersianDate.GetFormatetdDate(pord.pordDate.Replace("/", "")) + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()).ToString("yyyy/MM/dd", new PersianCulture());
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						return Messages.WrongPordDateTime;
					}
					List<CRMspSelectUsersWithAccLinkField_Result> list4 = Enumerable.ToList<CRMspSelectUsersWithAccLinkField_Result>((IEnumerable<CRMspSelectUsersWithAccLinkField_Result>)_dbLink.CRMspSelectUsersWithAccLinkField(false, true, lCID, result2));
					string text4 = "";
					CRMspSelectLinkAccNoAvIISetting_Result cRMspSelectLinkAccNoAvIISetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccNoAvIISetting_Result>((IEnumerable<CRMspSelectLinkAccNoAvIISetting_Result>)_dbLink.CRMspSelectLinkAccNoAvIISetting(1, "Setting", lCID, result2));
					if (cRMspSelectLinkAccNoAvIISetting_Result != null)
					{
						text4 = cRMspSelectLinkAccNoAvIISetting_Result.PartValue ?? "";
					}
					else
					{
						Exception e2 = new Exception(Messages.errorInReadingSetting + " (noAvaran II) ");
						ErrorSignal.FromCurrentContext().Raise(e2);
					}
					if (string.IsNullOrWhiteSpace(text4))
					{
						return string.Format(Messages.msgErrorInSendPordToAccLinkNotSetFieldInSetting, pord.pordNumber, Labels.NoAvaranII, Labels.NoAvIITransferUser) + "|";
					}
					string text5 = "";
					if (!pord.pordReferUserId.HasValue)
					{
						return string.Format(Messages.msgErrorInSendPordToAccLinkNotSelectedItem, pord.pordNumber, Labels.NoAvaranII, Labels.pordReferUserId) + "|";
					}
					CRMspSelectUsersWithAccLinkField_Result cRMspSelectUsersWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectUsersWithAccLinkField_Result>((IEnumerable<CRMspSelectUsersWithAccLinkField_Result>)list4, (Func<CRMspSelectUsersWithAccLinkField_Result, bool>)((CRMspSelectUsersWithAccLinkField_Result m) => m.UserId == pord.pordReferUserId));
					if (cRMspSelectUsersWithAccLinkField_Result == null)
					{
						return string.Format(Messages.msgErrorInSendPordToAccLinkNotFoundIteminAcc, pord.pordNumber, Labels.NoAvaranII, Labels.pordReferUserId, pord.pordReferUser ?? "") + "|";
					}
					string linkAccUserCode = cRMspSelectUsersWithAccLinkField_Result.LinkAccUserCode;
					if (string.IsNullOrEmpty(linkAccUserCode))
					{
						return string.Format(Messages.msgErrorInSendPordToAccLinkNotFoundIteminAcc, pord.pordNumber, Labels.NoAvaranII, Labels.pordReferUserId, cRMspSelectUsersWithAccLinkField_Result.FullName ?? "") + "|";
					}
					text5 = linkAccUserCode;
					int num = 1;
					ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
					string text6 = pord.pordLinkAccPreOrderNumber;
					foreach (WSspSelectPreOrderItems_Result item in list3)
					{
						decimal num2 = (decimal)(item.pordIQuantity.GetValueOrDefault(1.0) * item.pordIFCR.GetValueOrDefault(1.0) * item.pordIFCRI.GetValueOrDefault(1.0));
						_ = item.pordIPrice.GetValueOrDefault() - item.pordIDiscount.GetValueOrDefault() - item.pordIRound.GetValueOrDefault() + item.pordIRoundPlus.GetValueOrDefault();
						decimal num3 = default(decimal);
						decimal num4 = default(decimal);
						if (item.pordICalculateTax.GetValueOrDefault() && item.pordITaxSum.GetValueOrDefault() > 0m)
						{
							num3 = item.pordITaxSum.GetValueOrDefault();
							num4 = default(decimal);
						}
						string text7 = "0";
						WSspSelectProducts_Result wSspSelectProducts_Result2 = Enumerable.FirstOrDefault<WSspSelectProducts_Result>((IEnumerable<WSspSelectProducts_Result>)list, (Func<WSspSelectProducts_Result, bool>)((WSspSelectProducts_Result m) => m.ProductID == item.pordIPrdId));
						if (wSspSelectProducts_Result2 != null)
						{
							text7 = wSspSelectProducts_Result2.PrdLinkAccPrdCode ?? "0";
						}
						string text8 = "";
						WSspSelectWareHouseWithAccLinkField_Result wSspSelectWareHouseWithAccLinkField_Result2 = Enumerable.FirstOrDefault<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)list2, (Func<WSspSelectWareHouseWithAccLinkField_Result, bool>)((WSspSelectWareHouseWithAccLinkField_Result m) => m.WareHouseID == item.pordIWHId));
						if (wSspSelectWareHouseWithAccLinkField_Result2 != null)
						{
							text8 = wSspSelectWareHouseWithAccLinkField_Result2.WrhsLinkAccWhCode.ToString() ?? "";
						}
						text8 = ((!string.IsNullOrEmpty(text8)) ? text8 : "");
						companyById.cmpLinkAccCode = ((!string.IsNullOrEmpty(companyById.cmpLinkAccCode)) ? companyById.cmpLinkAccCode : "");
						text7 = ((!string.IsNullOrEmpty(text7)) ? text7 : "");
						item.pordITotalPrice = ((!item.pordITotalPrice.HasValue) ? new decimal?(default(decimal)) : item.pordITotalPrice);
						item.pordIPrice = ((!item.pordIPrice.HasValue) ? new decimal?(default(decimal)) : item.pordIPrice);
						text6 = (string.IsNullOrEmpty(text6) ? "0" : text6);
						item.pordIDescription = ((!string.IsNullOrEmpty(item.pordIDescription)) ? item.pordIDescription : "");
						item.pordIDiscountSum = ((!item.pordIDiscountSum.HasValue) ? new decimal?(default(decimal)) : item.pordIDiscountSum);
						num4 = num4;
						num3 = num3;
						num2 = num2;
						decimal num5 = item.pordIPrice.GetValueOrDefault() - item.pordIRound.GetValueOrDefault() + item.pordIRoundPlus.GetValueOrDefault();
						decimal num6 = num5 * num2;
						string text9 = serviceSoapClient.InsertIntoPish_Factor(text8, companyById.cmpLinkAccCode, num2.ToString(), text7, num6.ToString(), num5.ToString(), text6, text3 ?? "", item.pordIDescription, "", item.pordIDiscountSum.ToString(), num4.ToString(), num3.ToString(), num.ToString(), text4 ?? "", text5 ?? "", text5);
						if (!string.IsNullOrWhiteSpace(text9))
						{
							if (text9.ToLower().IndexOf("success") >= 0)
							{
								string[] array2 = text9.Split(new char[1] { ' ' });
								if (array2 != null && array2.Length == 4)
								{
									if (string.IsNullOrWhiteSpace(text6) || text6 == "0")
									{
										text6 = array2[3].ToString() ?? "0";
										DbSet<WSPreOrder> wSPreOrder = _dbTbl.WSPreOrder;
										ParameterExpression val = Expression.Parameter(typeof(WSPreOrder), "m");
										WSPreOrder wSPreOrder2 = Queryable.FirstOrDefault<WSPreOrder>((IQueryable<WSPreOrder>)wSPreOrder, Expression.Lambda<Func<WSPreOrder, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass34_, typeof(_003C_003Ec__DisplayClass34_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
										if (wSPreOrder2 != null)
										{
											wSPreOrder2.pordLinkAccPreOrderNumber = text6;
											_dbTbl.Entry(wSPreOrder2).State = EntityState.Modified;
											_dbTbl.Configuration.ValidateOnSaveEnabled = false;
											_dbTbl.SaveChanges();
											_dbTbl.Configuration.ValidateOnSaveEnabled = true;
											text6 = wSPreOrder2.pordLinkAccPreOrderNumber ?? "0";
											result = "1|" + text6;
										}
										else
										{
											result = Messages.msgErrorInSendToOtherSystem + " ," + Messages.msgNotFound + "(" + Labels.lblPOrd + ")|";
										}
									}
								}
								else
								{
									result = Messages.msgErrorInSendToOtherSystem + "<br>" + text9 + Messages.msgErrorNoAvIISuccessLength + " |";
								}
							}
							else
							{
								result = Messages.msgErrorInSendToOtherSystem + "<br>" + text9 + "|";
							}
						}
						else
						{
							result = Messages.msgErrorRunFunction + "|";
						}
						num++;
					}
				}
				else
				{
					result = Messages.ErrorNotFound + "|";
				}
			}
			else
			{
				result = Messages.ErrorNotFound + "|";
			}
		}
		catch (Exception e3)
		{
			ErrorSignal.FromCurrentContext().Raise(e3);
			result = Messages.msgErrorRunFunction + "|";
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "frmPreOrder", ActionName = "actExportToAcc")]
	public ActionResult NoAvIIExportPreOrder()
	{
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmExportToAcc", ActionName = "actShowInfo")]
	public ActionResult NoAvIIExportPreOrder_Read([DataSourceRequest] DataSourceRequest request, int pageNumber, string fDate = "", string tDate = "", long value = 0L)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<NoAvaranIIPreOrderInfoViewModel> list = new List<NoAvaranIIPreOrderInfoViewModel>();
		try
		{
			int value2 = 500;
			pageNumber = ((pageNumber <= 0) ? 1 : pageNumber);
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
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
			foreach (CRMspLkNoAvIIWSSelectPreOrder_Result item2 in Enumerable.ToList<CRMspLkNoAvIIWSSelectPreOrder_Result>((IEnumerable<CRMspLkNoAvIIWSSelectPreOrder_Result>)_dbLink.CRMspLkNoAvIIWSSelectPreOrder(UserLogin.CurrentUser.UserId, (!string.IsNullOrEmpty(fDate)) ? new DateTime?(value3) : null, (!string.IsNullOrEmpty(tDate)) ? new DateTime?(value4) : null, value, pageNumber, value2, lCID, result, centerId)))
			{
				NoAvaranIIPreOrderInfoViewModel item = new NoAvaranIIPreOrderInfoViewModel
				{
					pordLinkAccPreOrderId = item2.pordLinkAccPreOrderId,
					Company = ((!string.IsNullOrEmpty(item2.CompanyName)) ? item2.CompanyName : "") + ((!string.IsNullOrEmpty(item2.CompanyPerson)) ? (" - " + item2.CompanyPerson) : ""),
					PordNumber = item2.pordNumber,
					Date = item2.pordDateTime,
					DatePersian = (item2.pordDateTime.HasValue ? item2.pordDateTime.Value.ToString("yyyy/MM/dd") : ""),
					pordTotalAmount = item2.pordTotalAmount,
					ItemCount = item2.pordItemCount,
					PreOrderId = item2.PreOrderID,
					RowNumber = item2.RowNumber,
					AllPage = item2.AllPage,
					pordLinkAccPreOrderNumber = item2.pordLinkAccPreOrderNumber
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

	[DynamicAuthorize(ControllerName = "frmExportToAcc", ActionName = "actSendToAcc")]
	[AjaxOnly]
	public JsonResult NoAvIIExportInfo(string records, int pageNumber, string fDate = "", string tDate = "")
	{
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int num = 0;
		string text = "";
		CommonResultStatusViewModel commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		CommonResultViewModel<int> data;
		try
		{
			DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			_ = Financial.Get().Id;
			short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			pageNumber = ((pageNumber <= 0) ? 1 : pageNumber);
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
			string text2 = "";
			List<OtherSystemSelectedViewModel> list = new List<OtherSystemSelectedViewModel>();
			if (!string.IsNullOrWhiteSpace(records))
			{
				list = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedViewModel>>(records);
				if (Enumerable.Any<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list))
				{
					foreach (OtherSystemSelectedViewModel item in list)
					{
						if (item.Selected)
						{
							text2 = text2 + item.Id + ",";
						}
					}
				}
			}
			text = "";
			int num2 = 0;
			if (Enumerable.Any<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list))
			{
				List<OtherSystemSelectedViewModel> list2 = Enumerable.ToList<OtherSystemSelectedViewModel>(Enumerable.Where<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list, (Func<OtherSystemSelectedViewModel, bool>)((OtherSystemSelectedViewModel m) => m.Selected && m.Id > 0)));
				if (Enumerable.Any<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list2) && list2 != null)
				{
					num2 = Enumerable.Count<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list2);
					int num3 = 0;
					foreach (OtherSystemSelectedViewModel item2 in list2)
					{
						string text3 = NoAvIIActSendToAcc(item2.Id);
						if (!string.IsNullOrEmpty(text3))
						{
							string[] array = text3.Split(new char[1] { '|' });
							if (array == null)
							{
								continue;
							}
							if (array[0] == "1")
							{
								long result2 = 0L;
								long.TryParse(array[1], out result2);
								if (result2 > 0)
								{
									num3++;
									int count = num3 * 100 / num2;
									ProgressHub.SendMessage("ok", count, userId);
								}
								else
								{
									text = text + "<br>" + Messages.msgErrorRunFunction;
									num3++;
									int count2 = num3 * 100 / num2;
									ProgressHub.SendMessage(Messages.msgErrorRunFunction, count2, userId);
								}
							}
							else
							{
								text = text + "<br>" + array[0];
								num3++;
								int count3 = num3 * 100 / num2;
								ProgressHub.SendMessage(array[0], count3, userId);
							}
						}
						else
						{
							text = text + "<br>" + Messages.msgErrorRunFunction;
						}
					}
				}
				else
				{
					text = Messages.msgErrorRunFunction + " (" + Messages.msgErrorNotSelectedItem + ")";
				}
			}
			if (!string.IsNullOrEmpty(text))
			{
				num = 0;
				commonResultStatusViewModel = CommonResultStatusViewModel.Fail;
				ProgressHub.SendMessage(text, 0, userId);
			}
			else
			{
				text = Messages.msgSuccessAction;
				num = 1;
				commonResultStatusViewModel = CommonResultStatusViewModel.Success;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			num = 0;
			data = new CommonResultViewModel<int>
			{
				Data = num,
				Message = Messages.msgErrorRunFunction,
				Status = CommonResultStatusViewModel.Error
			};
			return Json(data, JsonRequestBehavior.AllowGet);
		}
		data = new CommonResultViewModel<int>
		{
			Data = num,
			Message = text,
			Status = commonResultStatusViewModel
		};
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetNoAvIIExportPreOrderList(string records, int totalPage, string fDate = "", string tDate = "", long value = 0L)
	{
		//IL_0248: Unknown result type (might be due to invalid IL or missing references)
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
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
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
			foreach (CRMspLkNoAvIIWSSelectPreOrder_Result item2 in Enumerable.ToList<CRMspLkNoAvIIWSSelectPreOrder_Result>((IEnumerable<CRMspLkNoAvIIWSSelectPreOrder_Result>)_dbLink.CRMspLkNoAvIIWSSelectPreOrder(UserLogin.CurrentUser.UserId, (!string.IsNullOrEmpty(fDate)) ? new DateTime?(value4) : null, (!string.IsNullOrEmpty(tDate)) ? new DateTime?(value5) : null, value, value3, value2, lCID, result, centerId)))
			{
				OtherSystemSelectedViewModel item = new OtherSystemSelectedViewModel
				{
					Row = item2.RowNumber.GetValueOrDefault(),
					Id = item2.PreOrderID,
					Selected = string.IsNullOrEmpty(item2.pordLinkAccPreOrderNumber)
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

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmPreOrder", ActionName = "actSendToAcc")]
	public string PayvastActSendToAcc(int pordId)
	{
		_003C_003Ec__DisplayClass39_0 _003C_003Ec__DisplayClass39_ = new _003C_003Ec__DisplayClass39_0();
		_003C_003Ec__DisplayClass39_.pordId = pordId;
		string text = "";
		try
		{
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (!UserLogin.IsUserAccess("frmPreOrder", "actSendToAcc", currentUser))
			{
				return Messages.ErrorNotAccess + "|";
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (_003C_003Ec__DisplayClass39_.pordId > 0)
			{
				WSspSelectPreOrderWithId_Result wSspSelectPreOrderWithId_Result = Enumerable.FirstOrDefault<WSspSelectPreOrderWithId_Result>((IEnumerable<WSspSelectPreOrderWithId_Result>)_db.WSspSelectPreOrderWithId(_003C_003Ec__DisplayClass39_.pordId, lCID, result));
				if (wSspSelectPreOrderWithId_Result != null)
				{
					string errorMessage = "";
					if (!PreOrder.SendToLinkAccNeedVerify(_003C_003Ec__DisplayClass39_.pordId, ref errorMessage))
					{
						return errorMessage + "|";
					}
					if (wSspSelectPreOrderWithId_Result.pordLinkAccPreOrderId.HasValue)
					{
						return string.Format(Messages.msgErrorNotReSendPordToOtherSystem, wSspSelectPreOrderWithId_Result.pordNumber.ToString(), Labels.Payvast) + "|";
					}
					List<WSspSelectProducts_Result> list = Enumerable.ToList<WSspSelectProducts_Result>((IEnumerable<WSspSelectProducts_Result>)_db.WSspSelectProducts(lCID, result));
					Enumerable.ToList<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)_dbLink.WSspSelectWareHouseWithAccLinkField(false, false, false, languageID: lCID, defaultLanguageID: result, withWrhsLinkAccWareHouses: false));
					List<WSspSelectPreOrderItems_Result> list2 = Enumerable.ToList<WSspSelectPreOrderItems_Result>((IEnumerable<WSspSelectPreOrderItems_Result>)_db.WSspSelectPreOrderItems(_003C_003Ec__DisplayClass39_.pordId, lCID, result));
					if (list2 != null && Enumerable.Any<WSspSelectPreOrderItems_Result>((IEnumerable<WSspSelectPreOrderItems_Result>)list2))
					{
						foreach (WSspSelectPreOrderItems_Result item2 in list2)
						{
							WSspSelectProducts_Result wSspSelectProducts_Result = Enumerable.FirstOrDefault<WSspSelectProducts_Result>((IEnumerable<WSspSelectProducts_Result>)list, (Func<WSspSelectProducts_Result, bool>)((WSspSelectProducts_Result m) => m.ProductID == item2.pordIPrdId));
							if (wSspSelectProducts_Result != null && wSspSelectProducts_Result.PrdLinkAccPrdId <= 0)
							{
								text = string.Format(Messages.msgErrorInSendOrdToAccLinkNotFoundPrdInAcc, wSspSelectPreOrderWithId_Result.pordNumber, Labels.Payvast, wSspSelectProducts_Result.PrdName ?? "") + "|";
								return text;
							}
						}
					}
					int num = 0;
					CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(wSspSelectPreOrderWithId_Result.pordCompanyId.GetValueOrDefault());
					if (companyById == null)
					{
						return Messages.CompanyNotFound + "|";
					}
					num = companyById.cmpLinkAccCustomerId.GetValueOrDefault();
					if (num <= 0)
					{
						string text2 = new CompanyController().PayvastActCmpSendToAcc(wSspSelectPreOrderWithId_Result.pordCompanyId.GetValueOrDefault());
						if (string.IsNullOrEmpty(text2))
						{
							return Messages.msgErrorRunFunction + "|";
						}
						string[] array = text2.Split(new char[1] { '|' });
						if (array != null)
						{
							if (!(array[0] == "1"))
							{
								return array[0] + "|";
							}
							companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(wSspSelectPreOrderWithId_Result.pordCompanyId.GetValueOrDefault());
							if (companyById == null)
							{
								return Messages.CompanyNotFound + "|";
							}
							num = companyById.cmpLinkAccCustomerId.GetValueOrDefault();
						}
					}
					if (num <= 0)
					{
						return string.Format(Messages.msgErrorInSendToAccLinkNotFoundCmpInAcc, "");
					}
					DateTime dateTime = default(DateTime);
					try
					{
						if (wSspSelectPreOrderWithId_Result.pordDateTime.HasValue)
						{
							if (wSspSelectPreOrderWithId_Result.pordDateTime.HasValue)
							{
								wSspSelectPreOrderWithId_Result.pordDateTime.Value.ToString("yyyy/MM/dd", new PersianCulture());
							}
						}
						else if (!string.IsNullOrEmpty(wSspSelectPreOrderWithId_Result.pordDate))
						{
							DateTime.Parse(PersianDate.GetFormatetdDate(wSspSelectPreOrderWithId_Result.pordDate.Replace("/", "")) + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()).ToString("yyyy/MM/dd", new PersianCulture());
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						return Messages.WrongPordDateTime;
					}
					AccountingServiceSoapClient accountingServiceSoapClient = new AccountingServiceSoapClient();
					PayvastSettingViewModel payvastSetting = CRMIdeal.Classes.Helper.OtherSystems.GetPayvastSetting();
					int num2 = accountingServiceSoapClient.CreateFactor(wSspSelectPreOrderWithId_Result.pordDateTime ?? DateTime.Now, num, payvastSetting.PayvastAccountId, "", payvastSetting.PayvastPreOrderFloatingAccountII, "", wSspSelectPreOrderWithId_Result.pordDescriptionI, wSspSelectPreOrderWithId_Result.pordDescriptionII, 0, 0, 0m, payvastSetting.PayvastUsername, payvastSetting.PayvastPassword, 4, "0", wSspSelectPreOrderWithId_Result.pordDeliveryDateTime ?? DateTime.Now, 0);
					if (num2 > 0)
					{
						ProductController productController = new ProductController();
						List<WSspSelectProductWithAccLinkField_Result> list3 = Enumerable.ToList<WSspSelectProductWithAccLinkField_Result>((IEnumerable<WSspSelectProductWithAccLinkField_Result>)productController.SelectProductWithAccLinkField(withPrdLinkAccPrdCode: false, withPrdLinkAccPrdId: true, withPrdLinkAccPrdIdStr: false, lCID, result));
						List<WSspSelectProductUnitWithAccLinkField_Result> list4 = productController.SelectProductUnitWithAccLinkField(withUnitLinkAccUnitId: true, withUnitLinkAccUnitIdStr: false, lCID, result);
						List<WSspSelectWareHouseWithAccLinkField_Result> list5 = Enumerable.ToList<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)_dbLink.WSspSelectWareHouseWithAccLinkField(true, false, false, languageID: lCID, defaultLanguageID: result, withWrhsLinkAccWareHouses: false));
						foreach (WSspSelectPreOrderItems_Result item in list2)
						{
							WSspSelectProductWithAccLinkField_Result wSspSelectProductWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectProductWithAccLinkField_Result>((IEnumerable<WSspSelectProductWithAccLinkField_Result>)list3, (Func<WSspSelectProductWithAccLinkField_Result, bool>)((WSspSelectProductWithAccLinkField_Result x) => x.ProductID == item.pordIPrdId));
							WSspSelectProductUnitWithAccLinkField_Result wSspSelectProductUnitWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectProductUnitWithAccLinkField_Result>((IEnumerable<WSspSelectProductUnitWithAccLinkField_Result>)list4, (Func<WSspSelectProductUnitWithAccLinkField_Result, bool>)((WSspSelectProductUnitWithAccLinkField_Result x) => x.ProductUnitID == item.pordIPrdUnitId));
							WSspSelectWareHouseWithAccLinkField_Result wSspSelectWareHouseWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)list5, (Func<WSspSelectWareHouseWithAccLinkField_Result, bool>)((WSspSelectWareHouseWithAccLinkField_Result x) => x.WareHouseID == item.pordIWHId.GetValueOrDefault()));
							if (wSspSelectProductWithAccLinkField_Result == null || wSspSelectProductWithAccLinkField_Result.PrdLinkAccPrdId <= 0)
							{
								text = string.Format(Messages.msgErrorInSendPreOrdToAccLinkNotFoundPrdInAcc, wSspSelectPreOrderWithId_Result.pordNumber.ToString(), Labels.Payvast, item.PrdName) + "|";
								continue;
							}
							if ((wSspSelectProductUnitWithAccLinkField_Result == null || wSspSelectProductUnitWithAccLinkField_Result.UnitLinkAccUnitId <= 0) && item.pordIPrdUnitId.HasValue)
							{
								text = string.Format(Messages.msgErrorInSendPreOrdToAccLinkNotFoundPrdUnitInAcc, wSspSelectPreOrderWithId_Result.pordNumber.ToString(), Labels.Payvast, item.PrdUnitName) + "|";
								continue;
							}
							if (wSspSelectWareHouseWithAccLinkField_Result == null || wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhId <= 0)
							{
								text = string.Format(Messages.msgErrorInSendPreOrdToAccLinkNotFoundWhInAcc, wSspSelectPreOrderWithId_Result.pordNumber.ToString(), Labels.Payvast, item.pordIWrhsName) + "|";
								continue;
							}
							int merchandiseId = 0;
							WSspSelectProducts_Result wSspSelectProducts_Result2 = Enumerable.FirstOrDefault<WSspSelectProducts_Result>((IEnumerable<WSspSelectProducts_Result>)list, (Func<WSspSelectProducts_Result, bool>)((WSspSelectProducts_Result m) => m.ProductID == item.pordIPrdId));
							if (wSspSelectProducts_Result2 != null)
							{
								merchandiseId = wSspSelectProducts_Result2.PrdLinkAccPrdId.GetValueOrDefault();
							}
							double result2 = 0.0;
							double.TryParse(item.pordIQuantity.GetValueOrDefault(1.0).ToString(), out result2);
							result2 *= item.pordIFCR.GetValueOrDefault(1.0) * item.pordIFCRI.GetValueOrDefault(1.0);
							accountingServiceSoapClient.AddArticle(num2, merchandiseId, int.Parse(item.pordIQuantity.ToString()), wSspSelectProductUnitWithAccLinkField_Result?.UnitLinkAccUnitId.GetValueOrDefault() ?? 0, item.pordIPrice.GetValueOrDefault(), int.Parse(result2.ToString()), item.pordITaxSum.GetValueOrDefault(), item.pordIDiscountSum.GetValueOrDefault(), wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhId.HasValue ? wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhId.GetValueOrDefault() : 0, item.pordIDescription, payvastSetting.PayvastACC);
							double num3 = double.Parse(item.pordIRound.GetValueOrDefault().ToString()) * item.pordIQuantity.GetValueOrDefault(1.0) * item.pordIFCR.GetValueOrDefault(1.0) * item.pordIFCRI.GetValueOrDefault(1.0);
							if (num3 > 1.0 && payvastSetting.PayvastEKTypeCodeDeductions > -1)
							{
								PayvastAddCost(num2, decimal.Parse(num3.ToString()), isIncremental: false, "کسر رند در پیش فاکتور CRM با شماره: " + wSspSelectPreOrderWithId_Result.pordNumber, payvastSetting.PayvastEKTypeCodeDeductions);
							}
							num3 = double.Parse(item.pordIRoundPlus.GetValueOrDefault().ToString()) * item.pordIQuantity.GetValueOrDefault(1.0) * item.pordIFCR.GetValueOrDefault(1.0) * item.pordIFCRI.GetValueOrDefault(1.0);
							if (num3 > 1.0 && payvastSetting.PayvastEKTypeCodeAdditions > -1)
							{
								PayvastAddCost(num2, decimal.Parse(num3.ToString()), isIncremental: true, "کسر رند در محصول(" + item.PrdName + ") پیش فاکتور CRM با شماره پیش فاکتور: " + wSspSelectPreOrderWithId_Result.pordNumber, payvastSetting.PayvastEKTypeCodeAdditions);
							}
						}
						if (string.IsNullOrWhiteSpace(text))
						{
							if (wSspSelectPreOrderWithId_Result.pordTransportation.GetValueOrDefault() > 0m && payvastSetting.PayvastEKTypeCodeAdditions > -1)
							{
								PayvastAddCost(num2, wSspSelectPreOrderWithId_Result.pordTransportation.GetValueOrDefault(), isIncremental: true, "هزینه جا به جایی در پیش فاکتور CRM با شماره: " + wSspSelectPreOrderWithId_Result.pordNumber, payvastSetting.PayvastEKTypeCodeAdditions);
							}
							if (wSspSelectPreOrderWithId_Result.pordRound.GetValueOrDefault() > 0m && payvastSetting.PayvastEKTypeCodeDeductions > -1)
							{
								PayvastAddCost(num2, wSspSelectPreOrderWithId_Result.pordRound.GetValueOrDefault(), isIncremental: false, "کسر رند در پیش فاکتور CRM با شماره: " + wSspSelectPreOrderWithId_Result.pordNumber, payvastSetting.PayvastEKTypeCodeDeductions);
							}
							AddMethodsResult addMethodsResult = accountingServiceSoapClient.CommitFactor(num2, CRMIdeal.Classes.Helper.OtherSystems.GetPayvastFPId(DateTime.Now));
							DbSet<WSPreOrder> wSPreOrder = _dbTbl.WSPreOrder;
							ParameterExpression val = Expression.Parameter(typeof(WSPreOrder), "m");
							WSPreOrder wSPreOrder2 = Queryable.FirstOrDefault<WSPreOrder>((IQueryable<WSPreOrder>)wSPreOrder, Expression.Lambda<Func<WSPreOrder, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass39_, typeof(_003C_003Ec__DisplayClass39_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (wSPreOrder2 != null && addMethodsResult != null)
							{
								_dbTbl.Entry(wSPreOrder2).State = EntityState.Modified;
								wSPreOrder2.pordLinkAccPreOrderId = addMethodsResult.Id;
								wSPreOrder2.pordLinkAccPreOrderNumber = addMethodsResult.Number.ToString();
								_dbTbl.Configuration.ValidateOnSaveEnabled = false;
								_dbTbl.SaveChanges();
								_dbTbl.Configuration.ValidateOnSaveEnabled = true;
								string text3 = addMethodsResult.Number.ToString();
								text = "1|" + text3;
							}
							else
							{
								text = Messages.msgErrorInSendToOtherSystem + "|";
							}
						}
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
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			text = Messages.msgErrorRunFunction + "| Error: " + ex.Message;
		}
		return text;
	}

	public void PayvastAddCost(int factorId, decimal amount, bool isIncremental, string description, int EKTypeCode)
	{
		try
		{
			new AccountingServiceSoapClient().AddCost(factorId, amount, isIncremental, description, EKTypeCode);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}

	[DynamicAuthorize(ControllerName = "frmPreOrder", ActionName = "actExportToAcc")]
	public ActionResult PayvastExportPreOrder()
	{
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmExportToAcc", ActionName = "actShowInfo")]
	public ActionResult PayvastExportPreOrder_Read([DataSourceRequest] DataSourceRequest request, string fDate = "", string tDate = "", long value = 0L)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<LkPreOrderInfoViewModel> list = new List<LkPreOrderInfoViewModel>();
		try
		{
			foreach (CRMspLkWSSelectPreOrder_Result item2 in SelectPreOrder(fDate, tDate, value, lCID, result))
			{
				LkPreOrderInfoViewModel item = new LkPreOrderInfoViewModel
				{
					pordLinkAccPreOrderId = item2.pordLinkAccPreOrderId,
					Company = ((!string.IsNullOrEmpty(item2.CompanyName)) ? item2.CompanyName : "") + ((!string.IsNullOrEmpty(item2.CompanyPerson)) ? (" - " + item2.CompanyPerson) : ""),
					PordNumber = item2.pordNumber,
					Date = item2.pordDateTime,
					DatePersian = (item2.pordDateTime.HasValue ? item2.pordDateTime.Value.ToString("yyyy/MM/dd") : ""),
					pordTotalAmount = item2.pordTotalAmount,
					ItemCount = item2.pordItemCount,
					PreOrderId = item2.PreOrderID,
					RowNumber = item2.RowNumber,
					pordLinkAccPreOrderNumber = item2.pordLinkAccPreOrderNumber,
					AllPage = 0
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

	[DynamicAuthorize(ControllerName = "frmExportToAcc", ActionName = "actSendToAcc")]
	[AjaxOnly]
	public JsonResult PayvastExportInfo(string records)
	{
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		int num = 0;
		string text = "";
		CommonResultStatusViewModel commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		CommonResultViewModel<int> data;
		try
		{
			DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			_ = Financial.Get().Id;
			short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			List<OtherSystemSelectedViewModel> list = new List<OtherSystemSelectedViewModel>();
			if (!string.IsNullOrWhiteSpace(records))
			{
				list = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedViewModel>>(records);
			}
			text = "";
			int num2 = 0;
			if (Enumerable.Any<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list) && list != null)
			{
				list = Enumerable.ToList<OtherSystemSelectedViewModel>(Enumerable.Where<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list, (Func<OtherSystemSelectedViewModel, bool>)((OtherSystemSelectedViewModel m) => m.Selected && m.Id > 0)));
				num2 = Enumerable.Count<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list);
				int num3 = 0;
				foreach (OtherSystemSelectedViewModel item in list)
				{
					string text2 = PayvastActSendToAcc(item.Id);
					if (!string.IsNullOrEmpty(text2))
					{
						string[] array = text2.Split(new char[1] { '|' });
						if (array == null)
						{
							continue;
						}
						if (array[0] == "1")
						{
							long result2 = 0L;
							long.TryParse(array[1], out result2);
							if (result2 > 0)
							{
								num3++;
								int count = num3 * 100 / num2;
								ProgressHub.SendMessage("ok", count, userId);
							}
							else
							{
								text = text + "<br>" + Messages.msgErrorRunFunction;
								num3++;
								int count2 = num3 * 100 / num2;
								ProgressHub.SendMessage(Messages.msgErrorRunFunction, count2, userId);
							}
						}
						else
						{
							text = text + "<br>" + array[0];
							num3++;
							int count3 = num3 * 100 / num2;
							ProgressHub.SendMessage(array[0], count3, userId);
						}
					}
					else
					{
						text = text + "<br>" + Messages.msgErrorRunFunction;
					}
				}
			}
			else
			{
				text = Messages.msgErrorRunFunction + " (" + Messages.msgErrorNotSelectedItem + ")";
			}
			if (!string.IsNullOrEmpty(text))
			{
				num = 0;
				data = new CommonResultViewModel<int>
				{
					Data = num,
					Message = text,
					Status = CommonResultStatusViewModel.Error
				};
				return Json(data, JsonRequestBehavior.AllowGet);
			}
			if (!string.IsNullOrEmpty(text))
			{
				num = 0;
				commonResultStatusViewModel = CommonResultStatusViewModel.Fail;
				ProgressHub.SendMessage(text, 0, userId);
			}
			else
			{
				text = Messages.msgSuccessAction;
				num = 1;
				commonResultStatusViewModel = CommonResultStatusViewModel.Success;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			num = 0;
			data = new CommonResultViewModel<int>
			{
				Data = num,
				Message = Messages.msgErrorRunFunction,
				Status = CommonResultStatusViewModel.Error
			};
			return Json(data, JsonRequestBehavior.AllowGet);
		}
		data = new CommonResultViewModel<int>
		{
			Data = num,
			Message = text,
			Status = commonResultStatusViewModel
		};
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetPayvastExportPreOrderList(string records, int totalPage, string fDate = "", string tDate = "", long value = 0L)
	{
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		List<OtherSystemSelectedViewModel> list = new List<OtherSystemSelectedViewModel>();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			List<CRMspLkWSSelectPreOrder_Result> list2 = SelectPreOrder(fDate, tDate, value, lCID, result);
			List<OtherSystemSelectedViewModel> list3 = new List<OtherSystemSelectedViewModel>();
			if (!string.IsNullOrWhiteSpace(records))
			{
				list3 = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedViewModel>>(records);
			}
			foreach (CRMspLkWSSelectPreOrder_Result item in list2)
			{
				OtherSystemSelectedViewModel otherSystemSelectedViewModel = new OtherSystemSelectedViewModel
				{
					Row = item.RowNumber.GetValueOrDefault(),
					Id = item.PreOrderID,
					Selected = string.IsNullOrEmpty(item.pordLinkAccPreOrderNumber)
				};
				if (!string.IsNullOrWhiteSpace(records) && Enumerable.Any<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list3))
				{
					OtherSystemSelectedViewModel otherSystemSelectedViewModel2 = Enumerable.FirstOrDefault<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list3, (Func<OtherSystemSelectedViewModel, bool>)((OtherSystemSelectedViewModel x) => x.Id == item.PreOrderID));
					if (otherSystemSelectedViewModel2 != null)
					{
						otherSystemSelectedViewModel.Selected = otherSystemSelectedViewModel2.Selected;
					}
				}
				list.Add(otherSystemSelectedViewModel);
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

	public List<WSspSelectPreOrderWithAccLinkField_Result> SelectPreOrderWithAccLinkField(bool withPordpordLinkAccPreOrderId = false, bool withPordpordLinkAccPreOrderIdStr = false, bool withPordLinkAccPreOrderNumber = false)
	{
		List<WSspSelectPreOrderWithAccLinkField_Result> result = new List<WSspSelectPreOrderWithAccLinkField_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			result = Enumerable.ToList<WSspSelectPreOrderWithAccLinkField_Result>((IEnumerable<WSspSelectPreOrderWithAccLinkField_Result>)_dbLink.WSspSelectPreOrderWithAccLinkField(withPordpordLinkAccPreOrderId, withPordpordLinkAccPreOrderIdStr, withPordLinkAccPreOrderNumber, lCID, result2));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public List<CRMspLkWSSelectPreOrder_Result> SelectPreOrderExport(int oprId = 0, string fDate = "", string tDate = "", long pordNumber = 0L, int currentItemId = 0)
	{
		List<CRMspLkWSSelectPreOrder_Result> list = new List<CRMspLkWSSelectPreOrder_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int userLastCId = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out userLastCId);
			}
			DateTime value = DateTime.Now;
			DateTime value2 = DateTime.Now;
			if (!string.IsNullOrEmpty(fDate))
			{
				value = DateTime.Parse(PersianDate.GetFormatetdDate(fDate.Replace("/", "")) + " 00:00:00", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			if (!string.IsNullOrEmpty(tDate))
			{
				value2 = DateTime.Parse(PersianDate.GetFormatetdDate(tDate.Replace("/", "")) + " 23:59:59", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			list = Enumerable.ToList<CRMspLkWSSelectPreOrder_Result>((IEnumerable<CRMspLkWSSelectPreOrder_Result>)_dbLink.CRMspLkWSSelectPreOrder(oprId, UserLogin.CurrentUser.UserId, (!string.IsNullOrEmpty(fDate)) ? new DateTime?(value) : null, (!string.IsNullOrEmpty(tDate)) ? new DateTime?(value2) : null, pordNumber, lCID, result, userLastCId, currentItemId));
			foreach (CRMspLkWSSelectPreOrder_Result item in list)
			{
				if (string.IsNullOrWhiteSpace(item.pordDate))
				{
					item.pordDate = item.pordDateTime?.ToString("yyyy/MM/dd");
				}
				if (string.IsNullOrWhiteSpace(item.pordLinkAccData))
				{
					continue;
				}
				List<LinkAccDataViewModel> list2 = JsonConvert.DeserializeObject<List<LinkAccDataViewModel>>(item.pordLinkAccData);
				if (list2 == null)
				{
					continue;
				}
				List<LinkAccDataViewModel> list3 = Enumerable.ToList<LinkAccDataViewModel>(Enumerable.Where<LinkAccDataViewModel>((IEnumerable<LinkAccDataViewModel>)list2, (Func<LinkAccDataViewModel, bool>)((LinkAccDataViewModel x) => !string.IsNullOrWhiteSpace(x.Id) || !string.IsNullOrWhiteSpace(x.Code))));
				if (Center.HaveModule)
				{
					list3 = Enumerable.ToList<LinkAccDataViewModel>(Enumerable.Where<LinkAccDataViewModel>((IEnumerable<LinkAccDataViewModel>)list3, (Func<LinkAccDataViewModel, bool>)((LinkAccDataViewModel x) => x.CId == userLastCId)));
				}
				if (list3 == null)
				{
					continue;
				}
				LinkAccDataViewModel linkAccDataViewModel = Enumerable.FirstOrDefault<LinkAccDataViewModel>((IEnumerable<LinkAccDataViewModel>)list3);
				if (linkAccDataViewModel != null)
				{
					if (!string.IsNullOrWhiteSpace(linkAccDataViewModel.Id))
					{
						item.pordLinkAccPreOrderIdStr = linkAccDataViewModel.Id;
					}
					else if (!string.IsNullOrWhiteSpace(linkAccDataViewModel.Code))
					{
						item.pordLinkAccPreOrderIdStr = linkAccDataViewModel.Code;
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[DynamicAuthorize(ControllerName = "frmPreOrder", ActionName = "actImportFromAcc")]
	public ActionResult ShygunImportPreOrder()
	{
		GetPreOrderOpr();
		GetCrmWh();
		GetPordReferUser();
		int num = 0;
		DbSet<CrmLinkAccShygunSetting> crmLinkAccShygunSetting = _dbTbl.CrmLinkAccShygunSetting;
		ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccShygunSetting), "x");
		CrmLinkAccShygunSetting crmLinkAccShygunSetting2 = Queryable.FirstOrDefault<CrmLinkAccShygunSetting>((IQueryable<CrmLinkAccShygunSetting>)crmLinkAccShygunSetting, Expression.Lambda<Func<CrmLinkAccShygunSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)this, typeof(PreOrderController)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
		if (crmLinkAccShygunSetting2 != null)
		{
			num = ((!string.IsNullOrWhiteSpace(crmLinkAccShygunSetting2.PartValue)) ? int.Parse(crmLinkAccShygunSetting2.PartValue) : 0);
		}
		base.ViewBag.SyncTypeId = num;
		return View();
	}

	public ShygunPreOrderInfoViewModelObjects GetShygunPreOrderList(string fDate = "", string tDate = "", string fNumber = "0", string tNumber = "0", int fOrderType = 13, int tOrderType = 13, int fPrinted = 0, int tPrinted = 0, int fromRec = 0, int recCount = 20)
	{
		//IL_09b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_09bc: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		ShygunPreOrderInfoViewModelObjects shygunPreOrderInfoViewModelObjects = new ShygunPreOrderInfoViewModelObjects();
		try
		{
			DateTime dateTime = DateTime.Now;
			DateTime dateTime2 = DateTime.Now;
			if (!string.IsNullOrEmpty(fDate))
			{
				dateTime = DateTime.Parse(PersianDate.GetFormatetdDate(fDate.Replace("/", "")) + " 00:00:00", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			if (!string.IsNullOrEmpty(tDate))
			{
				dateTime2 = DateTime.Parse(PersianDate.GetFormatetdDate(tDate.Replace("/", "")) + " 23:59:59", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			List<ShygunPreOrderInfoViewModel> list = new List<ShygunPreOrderInfoViewModel>();
			List<WSspSelectPreOrderWithAccLinkField_Result> list2 = SelectPreOrderWithAccLinkField(withPordpordLinkAccPreOrderId: false, withPordpordLinkAccPreOrderIdStr: true);
			CRMIdeal.Classes.Helper.OtherSystems.ShygunSettingViewModel shygunSetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunSetting();
			DomainInvoiceHeader domainInvoiceHeader = new DomainInvoiceHeader();
			domainInvoiceHeader.InvoiceDate.From = dateTime.ToString("yyyy/MM/dd");
			domainInvoiceHeader.InvoiceDate.To = dateTime2.ToString("yyyy/MM/dd");
			domainInvoiceHeader.InvoiceNumber.From = ((fNumber == "0" || string.IsNullOrWhiteSpace(fNumber)) ? "" : fNumber);
			domainInvoiceHeader.InvoiceNumber.To = ((tNumber == "0" || string.IsNullOrWhiteSpace(tNumber)) ? "" : tNumber);
			domainInvoiceHeader.InvoiceType.From = fOrderType.ToString();
			domainInvoiceHeader.InvoiceType.To = tOrderType.ToString();
			domainInvoiceHeader.Printed.From = fPrinted.ToString();
			domainInvoiceHeader.Printed.To = tPrinted.ToString();
			string text = shygunSetting.IP;
			if (string.IsNullOrWhiteSpace(text))
			{
				Exception e = new Exception(Messages.errorInReadingSetting);
				ErrorSignal.FromCurrentContext().Raise(e);
			}
			if (!text.EndsWith("/"))
			{
				text += "/";
			}
			HttpClient httpClient = new HttpClient();
			httpClient.BaseAddress = new Uri(text);
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			string text2 = "api/Invoice/Get";
			text2 = text2 + "?RowStart=" + fromRec + "&RowCount=" + recCount;
			HttpContent content = new StringContent(JsonConvert.SerializeObject(new CRMIdeal.Classes.Helper.OtherSystems.ShygunApiGetInvParamViewModel
			{
				Config = shygunSetting.conf,
				Domain = domainInvoiceHeader,
				StartVersion = "0"
			}), Encoding.UTF8, "application/json");
			HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
			httpResponseMessage = httpClient.PostAsync(text2, content).Result;
			if (httpResponseMessage.IsSuccessStatusCode)
			{
				CRMIdeal.Classes.Helper.OtherSystems.ShygunApiGetInvResultViewModel shygunApiGetInvResultViewModel = JsonConvert.DeserializeObject<CRMIdeal.Classes.Helper.OtherSystems.ShygunApiGetInvResultViewModel>(httpResponseMessage.Content.ReadAsStringAsync().Result);
				if (shygunApiGetInvResultViewModel != null && shygunApiGetInvResultViewModel.Result != null && Enumerable.Any<CRMIdeal.Classes.Helper.OtherSystems.ShygunInvoiceViewModel>((IEnumerable<CRMIdeal.Classes.Helper.OtherSystems.ShygunInvoiceViewModel>)shygunApiGetInvResultViewModel.Result))
				{
					foreach (CRMIdeal.Classes.Helper.OtherSystems.ShygunInvoiceViewModel item in shygunApiGetInvResultViewModel.Result)
					{
						ShygunPreOrderInfoViewModel shygunPreOrderInfoViewModel = new ShygunPreOrderInfoViewModel();
						shygunPreOrderInfoViewModel.InvTyp = item.InvTyp;
						shygunPreOrderInfoViewModel.InvNo = item.InvNo;
						shygunPreOrderInfoViewModel.AccountGuId = item.AccountGuId;
						shygunPreOrderInfoViewModel.JobCostingGuId = item.JobCostingGuId;
						shygunPreOrderInfoViewModel.InvDescription = item.InvDescription;
						shygunPreOrderInfoViewModel.InvDate = item.InvDate;
						shygunPreOrderInfoViewModel.InvPayDue = item.InvPayDue;
						shygunPreOrderInfoViewModel.AccountNumber = item.AccountNumber;
						shygunPreOrderInfoViewModel.AccountName = item.AccountName;
						shygunPreOrderInfoViewModel.JobCostingNumber = item.JobCostingNumber;
						shygunPreOrderInfoViewModel.JobCostingName = item.JobCostingName;
						shygunPreOrderInfoViewModel.CurrencyAbb1 = item.CurrencyAbb1;
						shygunPreOrderInfoViewModel.SAccountGuId = item.SAccountGuId;
						shygunPreOrderInfoViewModel.SJobGuId = item.SJobGuId;
						shygunPreOrderInfoViewModel.bijak = item.bijak;
						shygunPreOrderInfoViewModel.GuId = item.GuId;
						if (item.CreatedDate.HasValue)
						{
							shygunPreOrderInfoViewModel.CreatedDate = item.CreatedDate;
							shygunPreOrderInfoViewModel.CreatedDatePersian = (item.CreatedDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
						}
						else
						{
							shygunPreOrderInfoViewModel.CreatedDate = null;
							shygunPreOrderInfoViewModel.CreatedDatePersian = "";
						}
						shygunPreOrderInfoViewModel.GeneralRef = item.GeneralRef;
						shygunPreOrderInfoViewModel.SAccountNumber = item.SAccountNumber;
						shygunPreOrderInfoViewModel.SJobNumber = item.SJobNumber;
						shygunPreOrderInfoViewModel.DiscountPercent = item.DiscountPercent;
						shygunPreOrderInfoViewModel.DiscAmount = item.DiscAmount;
						shygunPreOrderInfoViewModel.DepartmentNumber = item.DepartmentNumber;
						shygunPreOrderInfoViewModel.ST1Number = item.ST1Number;
						shygunPreOrderInfoViewModel.ST1GuId = item.ST1GuId;
						shygunPreOrderInfoViewModel.ST2Number = item.ST2Number;
						shygunPreOrderInfoViewModel.ST2GuId = item.ST2GuId;
						shygunPreOrderInfoViewModel.AtfNumber = item.AtfNumber;
						shygunPreOrderInfoViewModel.AtfGuId = item.AtfGuId;
						item.InvNo.ToString();
						string InvGuId = item.GuId.ToString();
						WSspSelectPreOrderWithAccLinkField_Result wSspSelectPreOrderWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectPreOrderWithAccLinkField_Result>((IEnumerable<WSspSelectPreOrderWithAccLinkField_Result>)list2, (Func<WSspSelectPreOrderWithAccLinkField_Result, bool>)((WSspSelectPreOrderWithAccLinkField_Result x) => x.pordLinkAccPreOrderIdStr == InvGuId));
						if (wSspSelectPreOrderWithAccLinkField_Result != null && wSspSelectPreOrderWithAccLinkField_Result.PreOrderID > 0)
						{
							shygunPreOrderInfoViewModel.PreOrderId = wSspSelectPreOrderWithAccLinkField_Result.PreOrderID;
						}
						List<ShygunPreOrderBodyInfoViewModel> list3 = new List<ShygunPreOrderBodyInfoViewModel>();
						shygunPreOrderInfoViewModel.PreOrderBodyCount = 0;
						if (item.Body != null && item.Body.Count > 0)
						{
							foreach (InvoiceBody item2 in item.Body)
							{
								ShygunPreOrderBodyInfoViewModel shygunPreOrderBodyInfoViewModel = new ShygunPreOrderBodyInfoViewModel();
								shygunPreOrderBodyInfoViewModel.InvNo = shygunPreOrderInfoViewModel.InvNo;
								shygunPreOrderBodyInfoViewModel.InvGuId = shygunPreOrderInfoViewModel.GuId;
								shygunPreOrderBodyInfoViewModel.LineItemId = item2.LineItemId;
								shygunPreOrderBodyInfoViewModel.InvHeaderId = item2.InvHeaderId;
								shygunPreOrderBodyInfoViewModel.LineItemOrder = item2.LineItemOrder;
								shygunPreOrderBodyInfoViewModel.ItemNumber = item2.ItemNumber;
								shygunPreOrderBodyInfoViewModel.STNumber = item2.STNumber;
								shygunPreOrderBodyInfoViewModel.STDesc = item2.STDesc;
								shygunPreOrderBodyInfoViewModel.STGuId = item2.STGuId;
								shygunPreOrderBodyInfoViewModel.ItemGuId = item2.ItemGuId;
								shygunPreOrderBodyInfoViewModel.Quan = item2.Quan;
								shygunPreOrderBodyInfoViewModel.Quan2 = item2.Quan2;
								shygunPreOrderBodyInfoViewModel.Price = item2.Price;
								shygunPreOrderBodyInfoViewModel.Price2 = item2.Price2;
								shygunPreOrderBodyInfoViewModel.Amount = item2.Amount;
								shygunPreOrderBodyInfoViewModel.AmortizePercent = item2.AmortizePercent;
								shygunPreOrderBodyInfoViewModel.LineDiscAmount = item2.LineDiscAmount;
								shygunPreOrderBodyInfoViewModel.LineDiscPer = item2.LineDiscPer;
								shygunPreOrderBodyInfoViewModel.LineItemDesc = item2.LineItemDesc;
								shygunPreOrderBodyInfoViewModel.ReturnRial = item2.ReturnRial;
								shygunPreOrderBodyInfoViewModel.OrderRemain1 = item2.OrderRemain1;
								shygunPreOrderBodyInfoViewModel.OrderRemain2 = item2.OrderRemain2;
								shygunPreOrderBodyInfoViewModel.FinalOrderQuan = item2.FinalOrderQuan;
								shygunPreOrderBodyInfoViewModel.FinalOrderQuan2 = item2.FinalOrderQuan2;
								shygunPreOrderBodyInfoViewModel.PreOrderId = shygunPreOrderInfoViewModel.PreOrderId;
								shygunPreOrderBodyInfoViewModel.RowNumber = list3.Count + 1;
								list3.Add(shygunPreOrderBodyInfoViewModel);
							}
							shygunPreOrderInfoViewModel.PreOrderBodyCount = list3.Count;
						}
						shygunPreOrderInfoViewModel.PreOrderBody = list3;
						List<ShygunPreOrderExpenseViewModel> list4 = new List<ShygunPreOrderExpenseViewModel>();
						shygunPreOrderInfoViewModel.PreOrderExpenseCount = 0;
						if (item.Expense != null && item.Expense.Count > 0)
						{
							foreach (InvoiceExpense item3 in item.Expense)
							{
								ShygunPreOrderExpenseViewModel shygunPreOrderExpenseViewModel = new ShygunPreOrderExpenseViewModel();
								shygunPreOrderExpenseViewModel.InvExpRowId = item3.InvExpRowId;
								shygunPreOrderExpenseViewModel.InvExpRowOrder = item3.InvExpRowOrder;
								shygunPreOrderExpenseViewModel.InvHeaderId = item3.InvHeaderId;
								shygunPreOrderExpenseViewModel.AccountGuId = item3.AccountGuId;
								shygunPreOrderExpenseViewModel.JobCostingGuId = item3.JobCostingGuId;
								shygunPreOrderExpenseViewModel.AccountNumber = item3.AccountNumber;
								shygunPreOrderExpenseViewModel.AccountName = item3.AccountName;
								shygunPreOrderExpenseViewModel.JobCostingNumber = item3.JobCostingNumber;
								shygunPreOrderExpenseViewModel.InvExpRowDesc = item3.InvExpRowDesc;
								shygunPreOrderExpenseViewModel.InvExpRowAmount = item3.InvExpRowAmount;
								shygunPreOrderExpenseViewModel.SecondAccountNumber = item3.SecondAccountNumber;
								shygunPreOrderExpenseViewModel.SecondAccountName = item3.SecondAccountName;
								shygunPreOrderExpenseViewModel.SecondJobCostingGuId = item3.SecondJobCostingGuId;
								shygunPreOrderExpenseViewModel.SecondAccountGuId = item3.SecondAccountGuId;
								shygunPreOrderExpenseViewModel.SecondJobCostingNumber = item3.SecondJobCostingNumber;
								shygunPreOrderExpenseViewModel.FixCostType = item3.FixCostType;
								shygunPreOrderExpenseViewModel.PreOrderId = shygunPreOrderInfoViewModel.PreOrderId;
								shygunPreOrderExpenseViewModel.InvGuId = shygunPreOrderInfoViewModel.GuId;
								shygunPreOrderExpenseViewModel.RowNumber = list4.Count + 1;
								list4.Add(shygunPreOrderExpenseViewModel);
							}
							shygunPreOrderInfoViewModel.PreOrderExpenseCount = list4.Count;
						}
						shygunPreOrderInfoViewModel.PreOrderExpense = list4;
						shygunPreOrderInfoViewModel.RowNumber = list.Count + 1;
						list.Add(shygunPreOrderInfoViewModel);
					}
				}
			}
			else
			{
				HttpStatusCode statusCode = httpResponseMessage.StatusCode;
				Exception e2 = new Exception(((object)(HttpStatusCode)(ref statusCode)).ToString());
				ErrorSignal.FromCurrentContext().Raise(e2);
			}
			shygunPreOrderInfoViewModelObjects.lst = list;
			shygunPreOrderInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			shygunPreOrderInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
		}
		catch (Exception e3)
		{
			ErrorSignal.FromCurrentContext().Raise(e3);
		}
		return shygunPreOrderInfoViewModelObjects;
	}

	[DynamicAuthorize(ControllerName = "frmManagePordLinkAcc", ActionName = "actImportShowInfo")]
	public ActionResult ShygunImportPreOrder_Read([DataSourceRequest] DataSourceRequest request, string fDate = "", string tDate = "", string fNumber = "0", string tNumber = "0", int fOrderType = 13, int tOrderType = 13, int fPrinted = 0, int tPrinted = 0, int fromRec = 0, int recCount = 100)
	{
		List<ShygunPreOrderInfoViewModel> list = new List<ShygunPreOrderInfoViewModel>();
		ShygunPreOrderInfoViewModelObjects shygunPreOrderList = GetShygunPreOrderList(fDate, tDate, fNumber, tNumber, fOrderType, tOrderType, fPrinted, tPrinted, fromRec, recCount);
		if (shygunPreOrderList != null)
		{
			list = shygunPreOrderList.lst;
			if (list != null && Enumerable.Any<ShygunPreOrderInfoViewModel>((IEnumerable<ShygunPreOrderInfoViewModel>)list))
			{
				foreach (ShygunPreOrderInfoViewModel item in list)
				{
					if (!string.IsNullOrWhiteSpace(item.InvDate))
					{
						DateTime dateTime = default(DateTime);
						item.InvDate = item.InvDate.Replace("-", "/");
						item.InvDate = DateTime.Parse(PersianDate.GetFormatetdDate(item.InvDate) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None).ToString("yyyy/MM/dd");
					}
				}
			}
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetShygunImportPreOrderList(string fDate = "", string tDate = "", string fNumber = "0", string tNumber = "0", int fOrderType = 13, int tOrderType = 13, int fPrinted = 0, int tPrinted = 0, int fromRec = 0, int recCount = 20)
	{
		List<OtherSystemSelectedVIiewModel> list = new List<OtherSystemSelectedVIiewModel>();
		try
		{
			foreach (ShygunPreOrderInfoViewModel item2 in GetShygunPreOrderList(fDate, tDate, fNumber, tNumber, fOrderType, tOrderType, fPrinted, tPrinted, fromRec, recCount).lst)
			{
				OtherSystemSelectedVIiewModel item = new OtherSystemSelectedVIiewModel
				{
					Row = item2.RowNumber,
					Id = item2.GuId.ToString(),
					Selected = (item2.PreOrderId <= 0)
				};
				list.Add(item);
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

	[DynamicAuthorize(ControllerName = "frmManagePordLinkAcc", ActionName = "actImportInfo")]
	[AjaxOnly]
	public JsonResult ShygunImportInfo(string records, string fDate = "", string tDate = "", string fNumber = "0", string tNumber = "0", int fOrderType = 13, int tOrderType = 13, int fPrinted = 0, int tPrinted = 0, int preOrderOprId = 0, int whId = 0, int fromRec = 0, int recCount = 20, int referUserId = 0)
	{
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b3: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int num = 0;
		string text = "";
		CommonResultStatusViewModel commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		CommonResultViewModel<int> data;
		try
		{
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int id = Financial.Get().Id;
			short value2 = short.Parse(Financial.Get().Id.ToString());
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			List<OtherSystemSelectedVIiewModel> list = new List<OtherSystemSelectedVIiewModel>();
			if (!string.IsNullOrWhiteSpace(records))
			{
				List<OtherSystemSelectedVIiewModel> list2 = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedVIiewModel>>(records);
				if (Enumerable.Any<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list2))
				{
					list = Enumerable.ToList<OtherSystemSelectedVIiewModel>(Enumerable.Where<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list2, (Func<OtherSystemSelectedVIiewModel, bool>)((OtherSystemSelectedVIiewModel m) => m.Selected)));
				}
			}
			List<ShygunPreOrderInfoViewModel> list3 = new List<ShygunPreOrderInfoViewModel>();
			List<ShygunPreOrderInfoViewModel> lst = GetShygunPreOrderList(fDate, tDate, fNumber, tNumber, fOrderType, tOrderType, fPrinted, tPrinted, fromRec, recCount).lst;
			if (list != null)
			{
				foreach (OtherSystemSelectedVIiewModel SelectedRowitem in list)
				{
					ShygunPreOrderInfoViewModel shygunPreOrderInfoViewModel = Enumerable.FirstOrDefault<ShygunPreOrderInfoViewModel>(Enumerable.Where<ShygunPreOrderInfoViewModel>((IEnumerable<ShygunPreOrderInfoViewModel>)lst, (Func<ShygunPreOrderInfoViewModel, bool>)((ShygunPreOrderInfoViewModel w) => w.GuId.ToString() == SelectedRowitem.Id)));
					if (shygunPreOrderInfoViewModel != null)
					{
						list3.Add(shygunPreOrderInfoViewModel);
					}
				}
			}
			else
			{
				string text2 = Messages.msgErrorRunFunction + " (get list from Shygun) ";
				Exception e = new Exception(text2);
				ErrorSignal.FromCurrentContext().Raise(e);
				text = text2;
			}
			if (list3 != null && Enumerable.Any<ShygunPreOrderInfoViewModel>((IEnumerable<ShygunPreOrderInfoViewModel>)list3) && string.IsNullOrWhiteSpace(text))
			{
				CRMIdeal.Classes.Helper.OtherSystems.ShygunSettingViewModel set = CRMIdeal.Classes.Helper.OtherSystems.GetShygunSetting();
				List<WSspSelectSaleCenterWithAccLinkField_Result> list4 = Enumerable.ToList<WSspSelectSaleCenterWithAccLinkField_Result>((IEnumerable<WSspSelectSaleCenterWithAccLinkField_Result>)_dbLink.WSspSelectSaleCenterWithAccLinkField(false, lCID, result));
				foreach (ShygunPreOrderInfoViewModel item in list3)
				{
					int? pordSaleCenterId = null;
					if (!string.IsNullOrWhiteSpace(item.DepartmentNumber))
					{
						bool flag = false;
						if (list4 != null && Enumerable.Any<WSspSelectSaleCenterWithAccLinkField_Result>((IEnumerable<WSspSelectSaleCenterWithAccLinkField_Result>)list4))
						{
							foreach (WSspSelectSaleCenterWithAccLinkField_Result item2 in list4)
							{
								if (string.IsNullOrWhiteSpace(item2.LinkAccData) || flag)
								{
									continue;
								}
								try
								{
									List<BaseInfoLinkAccDataViewModel> list5 = new JavaScriptSerializer().Deserialize<List<BaseInfoLinkAccDataViewModel>>(item2.LinkAccData);
									if (list5 != null && Enumerable.Any<BaseInfoLinkAccDataViewModel>((IEnumerable<BaseInfoLinkAccDataViewModel>)list5) && Enumerable.FirstOrDefault<BaseInfoLinkAccDataViewModel>((IEnumerable<BaseInfoLinkAccDataViewModel>)list5, (Func<BaseInfoLinkAccDataViewModel, bool>)((BaseInfoLinkAccDataViewModel m) => (m.Code ?? "") == (item.DepartmentNumber ?? ""))) != null)
									{
										pordSaleCenterId = item2.SaleCenterId;
										flag = true;
									}
								}
								catch (Exception e2)
								{
									ErrorSignal.FromCurrentContext().Raise(e2);
								}
							}
						}
					}
					if (!string.IsNullOrWhiteSpace(text))
					{
						continue;
					}
					decimal num2 = default(decimal);
					decimal value4 = default(decimal);
					decimal value5 = default(decimal);
					int result2 = 0;
					decimal value6 = default(decimal);
					decimal value7 = default(decimal);
					decimal value8 = default(decimal);
					decimal value9 = default(decimal);
					if (item.PreOrderExpenseCount > 0)
					{
						List<ShygunPreOrderExpenseViewModel> list6 = Enumerable.ToList<ShygunPreOrderExpenseViewModel>(Enumerable.Where<ShygunPreOrderExpenseViewModel>((IEnumerable<ShygunPreOrderExpenseViewModel>)item.PreOrderExpense, (Func<ShygunPreOrderExpenseViewModel, bool>)((ShygunPreOrderExpenseViewModel x) => x.AccountNumber == set.OrdTax)));
						if (list6 != null)
						{
							foreach (ShygunPreOrderExpenseViewModel item3 in list6)
							{
								num2 += item3.InvExpRowAmount.GetValueOrDefault();
							}
						}
						List<ShygunPreOrderExpenseViewModel> list7 = Enumerable.ToList<ShygunPreOrderExpenseViewModel>(Enumerable.Where<ShygunPreOrderExpenseViewModel>((IEnumerable<ShygunPreOrderExpenseViewModel>)item.PreOrderExpense, (Func<ShygunPreOrderExpenseViewModel, bool>)((ShygunPreOrderExpenseViewModel x) => x.AccountNumber == set.OrdRound)));
						if (list7 != null)
						{
							foreach (ShygunPreOrderExpenseViewModel item4 in list7)
							{
								value4 += item4.InvExpRowAmount.GetValueOrDefault();
							}
						}
						List<ShygunPreOrderExpenseViewModel> list8 = Enumerable.ToList<ShygunPreOrderExpenseViewModel>(Enumerable.Where<ShygunPreOrderExpenseViewModel>((IEnumerable<ShygunPreOrderExpenseViewModel>)item.PreOrderExpense, (Func<ShygunPreOrderExpenseViewModel, bool>)((ShygunPreOrderExpenseViewModel x) => x.AccountNumber == set.OrdTransportation)));
						if (list8 != null)
						{
							foreach (ShygunPreOrderExpenseViewModel item5 in list8)
							{
								value5 += item5.InvExpRowAmount.GetValueOrDefault();
							}
						}
					}
					int.TryParse(set.OrdCurrencyUnit, out result2);
					WSspSelectCurrencyUnitsWithId_Result wSspSelectCurrencyUnitsWithId_Result = Enumerable.FirstOrDefault<WSspSelectCurrencyUnitsWithId_Result>((IEnumerable<WSspSelectCurrencyUnitsWithId_Result>)_db.WSspSelectCurrencyUnitsWithId(result2, lCID, result));
					if (wSspSelectCurrencyUnitsWithId_Result == null || wSspSelectCurrencyUnitsWithId_Result.CurrencyUnitID <= 0)
					{
						text = Messages.msgErrorOrderCurrencyUnit;
					}
					else
					{
						result2 = wSspSelectCurrencyUnitsWithId_Result.CurrencyUnitID;
					}
					if (whId <= 0 && item.PreOrderBodyCount > 0)
					{
						List<WSspSelectActiveWareHouse_Result> list9 = SelectActiveWareHouse();
						foreach (ShygunPreOrderBodyInfoViewModel i in item.PreOrderBody)
						{
							WSspSelectActiveWareHouse_Result wSspSelectActiveWareHouse_Result = Enumerable.FirstOrDefault<WSspSelectActiveWareHouse_Result>((IEnumerable<WSspSelectActiveWareHouse_Result>)list9, (Func<WSspSelectActiveWareHouse_Result, bool>)((WSspSelectActiveWareHouse_Result x) => x.WrhsLinkAccWhCode == i.STNumber));
							if (wSspSelectActiveWareHouse_Result == null || wSspSelectActiveWareHouse_Result.WareHouseID <= 0)
							{
								text += string.Format(Messages.msgErrorPreOrderItemWhNotFound, i.STNumber, item.InvNo);
							}
						}
					}
					if (referUserId == 0)
					{
						text += Messages.CheckEmptycmpReferUserId;
					}
					if (!string.IsNullOrWhiteSpace(text))
					{
						continue;
					}
					DateTime now2 = DateTime.Now;
					string text3 = "";
					now2 = (string.IsNullOrWhiteSpace(item.InvDate) ? (item.CreatedDate ?? DateTime.Now) : DateTime.Parse(PersianDate.GetFormatetdDate(item.InvDate.Replace("-", "/")) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None));
					text3 = now2.ToString("yyyyMMdd", new PersianCulture());
					ObjectParameter objectParameter = new ObjectParameter("InsertedId", 0);
					ObjectParameter objectParameter2 = new ObjectParameter("ErrorMessage", "");
					_dbLink.CRMspLkShygunWSInsertUpdatePreOrder((preOrderOprId == 0) ? null : new int?(preOrderOprId), "", 0L, text3, now2, item.AccountGuId.HasValue ? item.AccountGuId.ToString() : null, item.AccountNumber, item.AccountName, (!string.IsNullOrWhiteSpace(set.DefPrjTitle)) ? set.DefPrjTitle : "", result2, item.DiscAmount.GetValueOrDefault(), num2, (num2 > 0m) ? 9 : 0, num2 > 0m, "0", (item.CreatedDate ?? DateTime.Now).ToString("hh:mm:ss"), value5, item.DiscountPercent.GetValueOrDefault(), "", item.InvDescription ?? "", value4, (!item.CreatedDate.HasValue) ? DateTime.Now.ToString("yyyyMMdd", new PersianCulture()) : item.CreatedDate?.ToString("yyyyMMdd", new PersianCulture()), item.CreatedDate ?? DateTime.Now, null, item.GuId.ToString(), item.InvNo.ToString(), userId, id, value2, value3, DateTime.Now, DateTime.Now.ToString("yyyyMMdd", new PersianCulture()), appType, lCID, result, defPrjCvnsStatusGroupId: set.DefPrjCvnsStatusGroupId, prjStartDate: (item.CreatedDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture()), prjStartTime: (item.CreatedDate ?? DateTime.Now).ToString("hh:mm:ss"), prjStartDateTime: item.CreatedDate ?? DateTime.Now, prjStarterUserId: referUserId, pordReferUserId: referUserId, pordItemsAmount: value6, pordInstallAmount: value7, pordSumAmount: value8, pordTotalAmount: value9, insertedId: objectParameter, errorMessage: objectParameter2, centerId: centerId, pordSaleCenterId: pordSaleCenterId);
					if (string.IsNullOrWhiteSpace(objectParameter2.Value.ToString()))
					{
						int result3 = 0;
						int.TryParse(objectParameter.Value.ToString(), out result3);
						if (result3 <= 0)
						{
							text = text + "<br>" + Messages.msgErrorInsertPreOrderNotSuccess;
							continue;
						}
						int result4 = 0;
						int.TryParse(objectParameter.Value.ToString(), out result4);
						if (item.PreOrderBodyCount <= 0)
						{
							continue;
						}
						foreach (ShygunPreOrderBodyInfoViewModel item6 in item.PreOrderBody)
						{
							item6.PreOrderId = result4;
						}
						string json = JsonConvert.SerializeObject(item.PreOrderBody);
						_dbLink.CRMspLkShygunWSInsertUpdatePreOrderItems(json, userId, value3, id, value, registerDatePersian, appType, lCID, whId, objectParameter2);
						if (!string.IsNullOrWhiteSpace(objectParameter2.Value.ToString()))
						{
							text = text + "<br>" + objectParameter2.Value.ToString();
						}
					}
					else
					{
						text = text + "<br>" + objectParameter2.Value.ToString();
					}
				}
			}
			else
			{
				text = Messages.msgErrorRunFunction + " (" + Messages.ErrorNotFound + ")";
			}
			if (!string.IsNullOrEmpty(text))
			{
				num = 0;
				commonResultStatusViewModel = CommonResultStatusViewModel.Fail;
				ProgressHub.SendMessage(text, 0, userId);
			}
			else
			{
				text = Messages.msgSuccessAction;
				num = 1;
				commonResultStatusViewModel = CommonResultStatusViewModel.Success;
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
		catch (Exception e3)
		{
			ErrorSignal.FromCurrentContext().Raise(e3);
			num = 0;
			data = new CommonResultViewModel<int>
			{
				Data = num,
				Message = Messages.msgErrorRunFunction,
				Status = CommonResultStatusViewModel.Error
			};
			return Json(data, JsonRequestBehavior.AllowGet);
		}
		data = new CommonResultViewModel<int>
		{
			Data = num,
			Message = text,
			Status = commonResultStatusViewModel
		};
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmPreOrder", ActionName = "actExportToAcc")]
	public ActionResult ShygunExportPreOrder()
	{
		GetPreOrderOpr();
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmManagePordLinkAcc", ActionName = "actExportShowInfo")]
	public ActionResult ShygunExportPreOrder_Read([DataSourceRequest] DataSourceRequest request, int oprId = 0, string fDate = "", string tDate = "", long value = 0L, int currentItemId = 0)
	{
		List<CRMspLkWSSelectPreOrder_Result> list = SelectPreOrderExport(oprId, fDate, tDate, value, currentItemId);
		if (list != null && Enumerable.Any<CRMspLkWSSelectPreOrder_Result>((IEnumerable<CRMspLkWSSelectPreOrder_Result>)list))
		{
			foreach (CRMspLkWSSelectPreOrder_Result item in list)
			{
				item.pordDate = (item.pordDateTime.HasValue ? item.pordDateTime.Value.ToString("yyyy/MM/dd") : "");
			}
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmPreOrder", ActionName = "actSendToAcc,actSendPayToAcc,actSendAllPayToAcc")]
	[AjaxOnly]
	public string ShygunActSendToAcc(int pordId, bool checkAction = true)
	{
		//IL_0228: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass55_0 _003C_003Ec__DisplayClass55_ = new _003C_003Ec__DisplayClass55_0();
		_003C_003Ec__DisplayClass55_.pordId = pordId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		try
		{
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (!UserLogin.IsUserAccess("frmCompanyI", "actSendToAcc", currentUser) && checkAction)
			{
				return Messages.ErrorNotAccess + "|";
			}
			DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(Financial.Get().Id.ToString());
			short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			_ = UserLogin.CurrentUser.UserId;
			List<WSspSelectProductWithAccLinkField_Result> list = Enumerable.ToList<WSspSelectProductWithAccLinkField_Result>((IEnumerable<WSspSelectProductWithAccLinkField_Result>)_dbLink.WSspSelectProductWithAccLinkField(false, false, true, lCID, result));
			List<WSspSelectWareHouse_Result> list2 = CRMIdeal.Classes.Helper.Warehouse.SelectWareHouse();
			CRMIdeal.Classes.Helper.OtherSystems.ShygunSettingViewModel shygunSetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunSetting();
			List<Invoice> list3 = new List<Invoice>();
			if (_003C_003Ec__DisplayClass55_.pordId > 0)
			{
				_003C_003Ec__DisplayClass55_1 _003C_003Ec__DisplayClass55_2 = new _003C_003Ec__DisplayClass55_1();
				int result2 = 0;
				if (UserLogin.CurrentUser != null)
				{
					int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
				}
				string shygun = Labels.Shygun;
				_003C_003Ec__DisplayClass55_2.pord = Enumerable.FirstOrDefault<CRMspLkWSSelectPreOrderById_Result>((IEnumerable<CRMspLkWSSelectPreOrderById_Result>)_dbLink.CRMspLkWSSelectPreOrderById(_003C_003Ec__DisplayClass55_.pordId, lCID, result, result2));
				if (_003C_003Ec__DisplayClass55_2.pord != null && _003C_003Ec__DisplayClass55_2.pord.PreOrderID > 0)
				{
					string errorMessage = "";
					if (!PreOrder.SendToLinkAccNeedVerify(_003C_003Ec__DisplayClass55_.pordId, ref errorMessage))
					{
						text = "<br>" + errorMessage;
						return text;
					}
					string text2 = "";
					if (_003C_003Ec__DisplayClass55_2.pord.pordSaleCenterId.GetValueOrDefault() != 0)
					{
						if (!string.IsNullOrWhiteSpace(_003C_003Ec__DisplayClass55_2.pord.SaleCenterLinkAccData))
						{
							List<BaseInfoLinkAccDataViewModel> list4 = new JavaScriptSerializer().Deserialize<List<BaseInfoLinkAccDataViewModel>>(_003C_003Ec__DisplayClass55_2.pord.SaleCenterLinkAccData);
							if (list4 != null && Enumerable.Any<BaseInfoLinkAccDataViewModel>((IEnumerable<BaseInfoLinkAccDataViewModel>)list4))
							{
								BaseInfoLinkAccDataViewModel baseInfoLinkAccDataViewModel = Enumerable.FirstOrDefault<BaseInfoLinkAccDataViewModel>((IEnumerable<BaseInfoLinkAccDataViewModel>)list4);
								if (baseInfoLinkAccDataViewModel != null)
								{
									text2 = baseInfoLinkAccDataViewModel.Code ?? "";
								}
							}
						}
						if (string.IsNullOrWhiteSpace(text2))
						{
							text = string.Format(Messages.msgErrorInSendPordToAccLinkNotFoundIteminAcc, _003C_003Ec__DisplayClass55_2.pord.pordNumber, shygun, Labels.pordSaleCenterId, _003C_003Ec__DisplayClass55_2.pord.pordSaleCenter ?? "") + "|";
							return text;
						}
					}
					if (!string.IsNullOrWhiteSpace(_003C_003Ec__DisplayClass55_2.pord.pordLinkAccPreOrderNumber))
					{
						ShygunPreOrderInfoViewModelObjects shygunPreOrderList = GetShygunPreOrderList(_003C_003Ec__DisplayClass55_2.pord.pordDateTime?.ToString("yyyy/MM/dd"), _003C_003Ec__DisplayClass55_2.pord.pordDateTime?.ToString("yyyy/MM/dd"), _003C_003Ec__DisplayClass55_2.pord.pordLinkAccPreOrderNumber, _003C_003Ec__DisplayClass55_2.pord.pordLinkAccPreOrderNumber);
						if (shygunPreOrderList != null && shygunPreOrderList.lst != null && shygunPreOrderList.lst.Count > 0)
						{
							int InvNo = 0;
							int.TryParse(_003C_003Ec__DisplayClass55_2.pord.pordLinkAccPreOrderNumber, out InvNo);
							ShygunPreOrderInfoViewModel shygunPreOrderInfoViewModel = Enumerable.FirstOrDefault<ShygunPreOrderInfoViewModel>((IEnumerable<ShygunPreOrderInfoViewModel>)shygunPreOrderList.lst, (Func<ShygunPreOrderInfoViewModel, bool>)((ShygunPreOrderInfoViewModel x) => x.InvNo == InvNo));
							if (shygunPreOrderInfoViewModel != null && shygunPreOrderInfoViewModel.InvNo > 0)
							{
								text = text + "<br>" + string.Format(Messages.msgErrorPreOrderAlreadyExistsInAccLink, _003C_003Ec__DisplayClass55_2.pord.pordNumber.ToString(), Labels.Shygun);
							}
						}
					}
					else
					{
						DbSet<WSPreOrder> wSPreOrder = _dbTbl.WSPreOrder;
						ParameterExpression val = Expression.Parameter(typeof(WSPreOrder), "x");
						WSPreOrder wSPreOrder2 = Queryable.FirstOrDefault<WSPreOrder>((IQueryable<WSPreOrder>)wSPreOrder, Expression.Lambda<Func<WSPreOrder, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass55_2, typeof(_003C_003Ec__DisplayClass55_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
						if (wSPreOrder2 != null)
						{
							_dbTbl.Entry(wSPreOrder2).State = EntityState.Modified;
							wSPreOrder2.pordLinkAccPreOrderId = null;
							wSPreOrder2.pordLinkAccPreOrderIdStr = null;
							wSPreOrder2.pordLinkAccPreOrderNumber = null;
							_dbTbl.Configuration.ValidateOnSaveEnabled = false;
							_dbTbl.SaveChanges();
							_dbTbl.Configuration.ValidateOnSaveEnabled = true;
						}
					}
					if (string.IsNullOrWhiteSpace(text))
					{
						CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(_003C_003Ec__DisplayClass55_2.pord.pordCompanyId.GetValueOrDefault());
						if (companyById == null || string.IsNullOrWhiteSpace(companyById.cmpLinkAccCustomerIdStr))
						{
							text = text + "<br>" + string.Format(Messages.msgErrorCompanyNotFoundInAccLink, companyById.cmpName, Labels.Shygun);
						}
						else
						{
							Invoice invoice = new Invoice();
							invoice.AccountNumber = companyById.cmpLinkAccCode;
							invoice.AccountGuId = ((!string.IsNullOrWhiteSpace(companyById.cmpLinkAccCustomerIdStr)) ? Guid.Parse(companyById.cmpLinkAccCustomerIdStr) : Guid.NewGuid());
							invoice.InvTyp = 13;
							if (!string.IsNullOrWhiteSpace(text2))
							{
								invoice.DepartmentNumber = text2;
							}
							if (_003C_003Ec__DisplayClass55_2.pord.pordDiscount.HasValue)
							{
								invoice.DiscAmount = _003C_003Ec__DisplayClass55_2.pord.pordDiscount;
							}
							else if (_003C_003Ec__DisplayClass55_2.pord.pordDiscountPercent.HasValue)
							{
								invoice.DiscountPercent = _003C_003Ec__DisplayClass55_2.pord.pordDiscountPercent;
							}
							invoice.GuId = _003C_003Ec__DisplayClass55_2.pord.GUId;
							invoice.InvDescription = _003C_003Ec__DisplayClass55_2.pord.pordDescriptionI ?? "";
							invoice.UpdateKind = ActionType.insert;
							if (_003C_003Ec__DisplayClass55_2.pord.pordDateTime.HasValue)
							{
								invoice.InvDate = _003C_003Ec__DisplayClass55_2.pord.pordDateTime.Value.ToString("yyyyMMdd", new CultureInfo("en-US"));
							}
							if (_003C_003Ec__DisplayClass55_2.pord.FirstRegisterDate.HasValue)
							{
								invoice.CreatedDate = _003C_003Ec__DisplayClass55_2.pord.FirstRegisterDate;
							}
							invoice.DeleteAllExpenses = true;
							decimal num = default(decimal);
							decimal num2 = default(decimal);
							List<InvoiceBody> list5 = new List<InvoiceBody>();
							List<WSspSelectPreOrderItems_Result> list6 = Enumerable.ToList<WSspSelectPreOrderItems_Result>((IEnumerable<WSspSelectPreOrderItems_Result>)_db.WSspSelectPreOrderItems(_003C_003Ec__DisplayClass55_2.pord.PreOrderID, lCID, result));
							if (list6 != null && string.IsNullOrWhiteSpace(text))
							{
								using List<WSspSelectPreOrderItems_Result>.Enumerator enumerator = list6.GetEnumerator();
								while (enumerator.MoveNext())
								{
									_003C_003Ec__DisplayClass55_3 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass55_3();
									CS_0024_003C_003E8__locals1.pordI = enumerator.Current;
									string text3 = "";
									string text4 = "";
									WSspSelectWareHouse_Result wSspSelectWareHouse_Result = new WSspSelectWareHouse_Result();
									if (shygunSetting.WrhsSyncTypeId == 2 && !string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals1.pordI.pordILinkAccWHIdStr))
									{
										WSspSelectWareHouse_Result wSspSelectWareHouse_Result2 = Enumerable.FirstOrDefault<WSspSelectWareHouse_Result>((IEnumerable<WSspSelectWareHouse_Result>)list2, (Func<WSspSelectWareHouse_Result, bool>)((WSspSelectWareHouse_Result x) => x.WareHouseID == CS_0024_003C_003E8__locals1.pordI.pordIWHId));
										if (wSspSelectWareHouse_Result2 != null && !string.IsNullOrWhiteSpace(wSspSelectWareHouse_Result2.WrhsLinkAccWareHouses))
										{
											List<CommonWithIdStrViewModel> list7 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(wSspSelectWareHouse_Result2.WrhsLinkAccWareHouses);
											if (list7 != null && list7.Count > 0)
											{
												CommonWithIdStrViewModel commonWithIdStrViewModel = Enumerable.FirstOrDefault<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list7, (Func<CommonWithIdStrViewModel, bool>)((CommonWithIdStrViewModel x) => x.Code == CS_0024_003C_003E8__locals1.pordI.pordILinkAccWHIdStr));
												if (commonWithIdStrViewModel != null)
												{
													text4 = commonWithIdStrViewModel.Name;
													text3 = commonWithIdStrViewModel.Id;
												}
											}
											else
											{
												wSspSelectWareHouse_Result = Enumerable.FirstOrDefault<WSspSelectWareHouse_Result>((IEnumerable<WSspSelectWareHouse_Result>)list2, (Func<WSspSelectWareHouse_Result, bool>)((WSspSelectWareHouse_Result x) => x.WareHouseID == CS_0024_003C_003E8__locals1.pordI.pordIWHId));
											}
										}
									}
									else
									{
										wSspSelectWareHouse_Result = Enumerable.FirstOrDefault<WSspSelectWareHouse_Result>((IEnumerable<WSspSelectWareHouse_Result>)list2, (Func<WSspSelectWareHouse_Result, bool>)((WSspSelectWareHouse_Result x) => x.WareHouseID == CS_0024_003C_003E8__locals1.pordI.pordIWHId));
										if (wSspSelectWareHouse_Result != null)
										{
											text3 = wSspSelectWareHouse_Result.WrhsLinkAccWhIdStr;
											text4 = wSspSelectWareHouse_Result.WrhsName;
										}
									}
									if (string.IsNullOrWhiteSpace(text3) || string.IsNullOrWhiteSpace(text4))
									{
										text = text + "<br>" + string.Format(Messages.msgErrorWareHouseNotFoundInAccLink, (wSspSelectWareHouse_Result != null) ? wSspSelectWareHouse_Result.WrhsName : "", Labels.Shygun);
									}
									WSspSelectProductWithAccLinkField_Result wSspSelectProductWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectProductWithAccLinkField_Result>((IEnumerable<WSspSelectProductWithAccLinkField_Result>)list, (Func<WSspSelectProductWithAccLinkField_Result, bool>)((WSspSelectProductWithAccLinkField_Result x) => x.ProductID == CS_0024_003C_003E8__locals1.pordI.pordIPrdId));
									if (wSspSelectProductWithAccLinkField_Result == null)
									{
										text = text + "<br>" + string.Format(Messages.msgErrorProductNotFoundInAccLink, CS_0024_003C_003E8__locals1.pordI.PrdName ?? "", Labels.Shygun);
									}
									else if (string.IsNullOrWhiteSpace(wSspSelectProductWithAccLinkField_Result.PrdLinkAccPrdIdStr))
									{
										text = text + "<br>" + string.Format(Messages.msgErrorWareHouseNotFoundInAccLink, wSspSelectProductWithAccLinkField_Result.PrdName ?? "", Labels.Shygun);
									}
									if (string.IsNullOrWhiteSpace(text))
									{
										InvoiceBody invoiceBody = new InvoiceBody();
										invoiceBody.ItemNumber = wSspSelectProductWithAccLinkField_Result.PrdLinkAccPrdCode;
										invoiceBody.ItemGuId = Guid.Parse(wSspSelectProductWithAccLinkField_Result.PrdLinkAccPrdIdStr);
										invoiceBody.Price = CS_0024_003C_003E8__locals1.pordI.pordIPrice.GetValueOrDefault();
										invoiceBody.Amount = CS_0024_003C_003E8__locals1.pordI.pordITotalPrice;
										invoiceBody.ItemDescription = CS_0024_003C_003E8__locals1.pordI.pordIDescription ?? "";
										if (CS_0024_003C_003E8__locals1.pordI.pordIDiscount.HasValue)
										{
											invoiceBody.LineDiscAmount = CS_0024_003C_003E8__locals1.pordI.pordIDiscount;
										}
										else if (CS_0024_003C_003E8__locals1.pordI.pordIDiscountPercent.HasValue)
										{
											invoiceBody.LineDiscPer = CS_0024_003C_003E8__locals1.pordI.pordIDiscountPercent;
											WSspSelectPreOrderItems_Result pordI = CS_0024_003C_003E8__locals1.pordI;
											decimal valueOrDefault = CS_0024_003C_003E8__locals1.pordI.pordIPrice.GetValueOrDefault();
											decimal? pordIDiscountPercent = CS_0024_003C_003E8__locals1.pordI.pordIDiscountPercent;
											pordI.pordIDiscount = (decimal?)valueOrDefault * pordIDiscountPercent / (decimal?)100;
										}
										invoiceBody.Price -= (decimal?)CS_0024_003C_003E8__locals1.pordI.pordIDiscount.GetValueOrDefault();
										double num3 = CS_0024_003C_003E8__locals1.pordI.pordIQuantity.GetValueOrDefault(1.0) * CS_0024_003C_003E8__locals1.pordI.pordIFCR.GetValueOrDefault(1.0) * CS_0024_003C_003E8__locals1.pordI.pordIFCRI.GetValueOrDefault(1.0);
										invoiceBody.Quan = ((num3 > 0.0) ? decimal.Parse(num3.ToString()) : 0m);
										num += CS_0024_003C_003E8__locals1.pordI.pordITaxSum.GetValueOrDefault();
										num2 += (CS_0024_003C_003E8__locals1.pordI.pordIRound.GetValueOrDefault() - CS_0024_003C_003E8__locals1.pordI.pordIRoundPlus.GetValueOrDefault()) * decimal.Parse(num3.ToString());
										invoiceBody.LineItemDesc = CS_0024_003C_003E8__locals1.pordI.pordIDescription;
										invoiceBody.STGuId = Guid.Parse(text3);
										invoiceBody.STDesc = text4;
										invoiceBody.GuId = Guid.NewGuid();
										invoiceBody.UpdateKind = ActionType.insert;
										DbSet<WSPreOrderItems> wSPreOrderItems = _dbTbl.WSPreOrderItems;
										ParameterExpression val = Expression.Parameter(typeof(WSPreOrderItems), "x");
										WSPreOrderItems wSPreOrderItems2 = Queryable.FirstOrDefault<WSPreOrderItems>((IQueryable<WSPreOrderItems>)wSPreOrderItems, Expression.Lambda<Func<WSPreOrderItems, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass55_3)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
										if (wSPreOrderItems2 != null)
										{
											_dbTbl.Entry(wSPreOrderItems2).State = EntityState.Modified;
											wSPreOrderItems2.pordILinkAccItemIdStr = invoiceBody.GuId.ToString();
											_dbTbl.Configuration.ValidateOnSaveEnabled = false;
											_dbTbl.SaveChanges();
											_dbTbl.Configuration.ValidateOnSaveEnabled = true;
										}
										list5.Add(invoiceBody);
									}
								}
							}
							invoice.Body = list5;
							List<InvoiceExpense> list8 = new List<InvoiceExpense>();
							if (!string.IsNullOrWhiteSpace(shygunSetting.OrdTax))
							{
								decimal? pordTax = _003C_003Ec__DisplayClass55_2.pord.pordTax;
								if ((pordTax.GetValueOrDefault() > default(decimal)) & pordTax.HasValue)
								{
									InvoiceExpense invoiceExpense = new InvoiceExpense();
									invoiceExpense.AccountNumber = shygunSetting.OrdTax;
									invoiceExpense.AccountName = shygunSetting.OrdTaxFieldTitle;
									invoiceExpense.InvExpRowAmount = _003C_003Ec__DisplayClass55_2.pord.pordTax;
									invoiceExpense.UpdateKind = ActionType.insert;
									list8.Add(invoiceExpense);
								}
							}
							if (!string.IsNullOrWhiteSpace(shygunSetting.OrdTransportation))
							{
								decimal? pordTax = _003C_003Ec__DisplayClass55_2.pord.pordTransportation;
								if ((pordTax.GetValueOrDefault() > default(decimal)) & pordTax.HasValue)
								{
									InvoiceExpense invoiceExpense2 = new InvoiceExpense();
									invoiceExpense2.AccountNumber = shygunSetting.OrdTransportation;
									invoiceExpense2.AccountName = shygunSetting.OrdTransportationFieldTitle;
									invoiceExpense2.InvExpRowAmount = _003C_003Ec__DisplayClass55_2.pord.pordTransportation;
									invoiceExpense2.UpdateKind = ActionType.insert;
									list8.Add(invoiceExpense2);
								}
							}
							if (!string.IsNullOrWhiteSpace(shygunSetting.OrdRound))
							{
								decimal? pordTax = _003C_003Ec__DisplayClass55_2.pord.pordRound;
								if ((pordTax.GetValueOrDefault() > default(decimal)) & pordTax.HasValue)
								{
									InvoiceExpense invoiceExpense3 = new InvoiceExpense();
									invoiceExpense3.AccountNumber = shygunSetting.OrdRound;
									invoiceExpense3.AccountName = shygunSetting.OrdRoundFieldTitle;
									invoiceExpense3.InvExpRowAmount = _003C_003Ec__DisplayClass55_2.pord.pordRound;
									invoiceExpense3.UpdateKind = ActionType.insert;
									list8.Add(invoiceExpense3);
								}
							}
							invoice.Expense = list8;
							if (string.IsNullOrWhiteSpace(text))
							{
								list3.Add(invoice);
							}
						}
					}
				}
			}
			if (list3 != null && list3.Count > 0 && string.IsNullOrWhiteSpace(text))
			{
				PutResults putResults = new WebServiePutInvoice(shygunSetting.IP, shygunSetting.conf, list3).PutOperation();
				if (string.IsNullOrWhiteSpace(putResults.ErrorMessage))
				{
					text = putResults.Result[0].ErrorMessage;
					if (string.IsNullOrWhiteSpace(text))
					{
						DbSet<WSPreOrder> wSPreOrder3 = _dbTbl.WSPreOrder;
						ParameterExpression val = Expression.Parameter(typeof(WSPreOrder), "m");
						WSPreOrder wSPreOrder4 = Queryable.FirstOrDefault<WSPreOrder>((IQueryable<WSPreOrder>)wSPreOrder3, Expression.Lambda<Func<WSPreOrder, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass55_, typeof(_003C_003Ec__DisplayClass55_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
						if (wSPreOrder4 != null)
						{
							_dbTbl.Entry(wSPreOrder4).State = EntityState.Modified;
							wSPreOrder4.pordLinkAccPreOrderNumber = putResults.Result[0].Number;
							wSPreOrder4.pordLinkAccPreOrderIdStr = putResults.Result[0].GuId;
							_dbTbl.Configuration.ValidateOnSaveEnabled = false;
							_dbTbl.SaveChanges();
							_dbTbl.Configuration.ValidateOnSaveEnabled = true;
							text = "1|" + putResults.Result[0].Number;
						}
						else
						{
							text = "<br>" + Messages.msgErrorInSendToOtherSystem + " " + Labels.OtherSystemsOrder;
						}
					}
				}
				else
				{
					text = text + "<br>" + putResults.ErrorMessage;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return text;
	}

	[DynamicAuthorize(ControllerName = "frmManagePordLinkAcc", ActionName = "actExportInfo")]
	[AjaxOnly]
	public JsonResult ShygunExportInfo(string records, int pordOprId, string fDate, string tDate, long pordNumber, int currentItemId = 0)
	{
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int data = 0;
		string text = "";
		CommonResultStatusViewModel commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		CommonResultViewModel<int> data2;
		try
		{
			DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(Financial.Get().Id.ToString());
			short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			_ = UserLogin.CurrentUser.UserId;
			List<OtherSystemSelectedViewModel> list = new List<OtherSystemSelectedViewModel>();
			if (!string.IsNullOrWhiteSpace(records))
			{
				list = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedViewModel>>(records);
				if (list != null)
				{
					list = Enumerable.ToList<OtherSystemSelectedViewModel>(Enumerable.Where<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list, (Func<OtherSystemSelectedViewModel, bool>)((OtherSystemSelectedViewModel x) => x.Selected && x.Id > 0)));
				}
			}
			string text2 = "";
			List<CRMspLkWSSelectPreOrder_Result> list2 = SelectPreOrderExport(pordOprId, fDate, tDate, pordNumber, currentItemId);
			List<WSspSelectProductWithAccLinkField_Result> list3 = Enumerable.ToList<WSspSelectProductWithAccLinkField_Result>((IEnumerable<WSspSelectProductWithAccLinkField_Result>)_dbLink.WSspSelectProductWithAccLinkField(false, false, true, lCID, result));
			List<WSspSelectWareHouse_Result> list4 = CRMIdeal.Classes.Helper.Warehouse.SelectWareHouse();
			string shygun = Labels.Shygun;
			CRMIdeal.Classes.Helper.OtherSystems.ShygunSettingViewModel shygunSetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunSetting();
			List<Invoice> list5 = new List<Invoice>();
			foreach (OtherSystemSelectedViewModel item in list)
			{
				_003C_003Ec__DisplayClass56_1 _003C_003Ec__DisplayClass56_ = new _003C_003Ec__DisplayClass56_1();
				_003C_003Ec__DisplayClass56_.pord = Enumerable.FirstOrDefault<CRMspLkWSSelectPreOrder_Result>((IEnumerable<CRMspLkWSSelectPreOrder_Result>)list2, (Func<CRMspLkWSSelectPreOrder_Result, bool>)((CRMspLkWSSelectPreOrder_Result x) => x.PreOrderID == item.Id));
				if (_003C_003Ec__DisplayClass56_.pord == null || _003C_003Ec__DisplayClass56_.pord.PreOrderID <= 0)
				{
					continue;
				}
				string errorMessage = "";
				if (!PreOrder.SendToLinkAccNeedVerify(item.Id, ref errorMessage))
				{
					text = text + "<br>" + errorMessage;
				}
				string text3 = "";
				if (_003C_003Ec__DisplayClass56_.pord.pordSaleCenterId.GetValueOrDefault() != 0)
				{
					if (!string.IsNullOrWhiteSpace(_003C_003Ec__DisplayClass56_.pord.SaleCenterLinkAccData))
					{
						List<BaseInfoLinkAccDataViewModel> list6 = new JavaScriptSerializer().Deserialize<List<BaseInfoLinkAccDataViewModel>>(_003C_003Ec__DisplayClass56_.pord.SaleCenterLinkAccData);
						if (list6 != null && Enumerable.Any<BaseInfoLinkAccDataViewModel>((IEnumerable<BaseInfoLinkAccDataViewModel>)list6))
						{
							BaseInfoLinkAccDataViewModel baseInfoLinkAccDataViewModel = Enumerable.FirstOrDefault<BaseInfoLinkAccDataViewModel>((IEnumerable<BaseInfoLinkAccDataViewModel>)list6);
							if (baseInfoLinkAccDataViewModel != null)
							{
								text3 = baseInfoLinkAccDataViewModel.Code ?? "";
							}
						}
					}
					if (string.IsNullOrWhiteSpace(text3))
					{
						text = text + "<br>" + string.Format(Messages.msgErrorInSendPordToAccLinkNotFoundIteminAcc, _003C_003Ec__DisplayClass56_.pord.pordNumber, shygun, Labels.pordSaleCenterId, _003C_003Ec__DisplayClass56_.pord.pordSaleCenter ?? "") + "|";
					}
				}
				if (!string.IsNullOrWhiteSpace(_003C_003Ec__DisplayClass56_.pord.pordLinkAccPreOrderNumber))
				{
					ShygunPreOrderInfoViewModelObjects shygunPreOrderList = GetShygunPreOrderList(_003C_003Ec__DisplayClass56_.pord.pordDateTime?.ToString("yyyy/MM/dd"), _003C_003Ec__DisplayClass56_.pord.pordDateTime?.ToString("yyyy/MM/dd"), _003C_003Ec__DisplayClass56_.pord.pordLinkAccPreOrderNumber, _003C_003Ec__DisplayClass56_.pord.pordLinkAccPreOrderNumber, 2, 2);
					if (shygunPreOrderList != null && shygunPreOrderList.lst == null && !Enumerable.Any<ShygunPreOrderInfoViewModel>((IEnumerable<ShygunPreOrderInfoViewModel>)shygunPreOrderList.lst))
					{
						DbSet<WSPreOrder> wSPreOrder = _dbTbl.WSPreOrder;
						ParameterExpression val = Expression.Parameter(typeof(WSPreOrder), "x");
						WSPreOrder wSPreOrder2 = Queryable.FirstOrDefault<WSPreOrder>((IQueryable<WSPreOrder>)wSPreOrder, Expression.Lambda<Func<WSPreOrder, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass56_, typeof(_003C_003Ec__DisplayClass56_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
						if (wSPreOrder2 != null)
						{
							_dbTbl.Entry(wSPreOrder2).State = EntityState.Modified;
							wSPreOrder2.pordLinkAccPreOrderId = null;
							wSPreOrder2.pordLinkAccPreOrderNumber = null;
							wSPreOrder2.pordLinkAccPreOrderIdStr = null;
							_dbTbl.Configuration.ValidateOnSaveEnabled = false;
							_dbTbl.SaveChanges();
							_dbTbl.Configuration.ValidateOnSaveEnabled = true;
						}
					}
				}
				else
				{
					DbSet<WSPreOrder> wSPreOrder3 = _dbTbl.WSPreOrder;
					ParameterExpression val = Expression.Parameter(typeof(WSPreOrder), "x");
					WSPreOrder wSPreOrder4 = Queryable.FirstOrDefault<WSPreOrder>((IQueryable<WSPreOrder>)wSPreOrder3, Expression.Lambda<Func<WSPreOrder, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass56_, typeof(_003C_003Ec__DisplayClass56_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
					if (wSPreOrder4 != null)
					{
						_dbTbl.Entry(wSPreOrder4).State = EntityState.Modified;
						wSPreOrder4.pordLinkAccPreOrderId = null;
						wSPreOrder4.pordLinkAccPreOrderNumber = null;
						wSPreOrder4.pordLinkAccPreOrderIdStr = null;
						_dbTbl.Configuration.ValidateOnSaveEnabled = false;
						_dbTbl.SaveChanges();
						_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					}
				}
				CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(_003C_003Ec__DisplayClass56_.pord.pordCompanyId.GetValueOrDefault());
				if (!string.IsNullOrWhiteSpace(text))
				{
					continue;
				}
				if (companyById == null || string.IsNullOrWhiteSpace(companyById.cmpLinkAccCustomerIdStr))
				{
					text = text + "<br>" + string.Format(Messages.msgErrorCompanyNotFoundInAccLink, companyById.cmpName, Labels.Shygun);
					continue;
				}
				Invoice invoice = new Invoice();
				invoice.AccountNumber = companyById.cmpLinkAccCode;
				invoice.AccountGuId = ((!string.IsNullOrWhiteSpace(companyById.cmpLinkAccCustomerIdStr)) ? Guid.Parse(companyById.cmpLinkAccCustomerIdStr) : Guid.NewGuid());
				invoice.InvTyp = 13;
				if (!string.IsNullOrWhiteSpace(text3))
				{
					invoice.DepartmentNumber = text3;
				}
				if (_003C_003Ec__DisplayClass56_.pord.pordDiscount.HasValue)
				{
					invoice.DiscAmount = _003C_003Ec__DisplayClass56_.pord.pordDiscount;
				}
				else if (_003C_003Ec__DisplayClass56_.pord.pordDiscountPercent.HasValue)
				{
					invoice.DiscountPercent = _003C_003Ec__DisplayClass56_.pord.pordDiscountPercent;
				}
				invoice.GuId = _003C_003Ec__DisplayClass56_.pord.GUId;
				invoice.InvDescription = _003C_003Ec__DisplayClass56_.pord.pordDescriptionI ?? "";
				invoice.UpdateKind = ActionType.insert;
				if (!string.IsNullOrWhiteSpace(_003C_003Ec__DisplayClass56_.pord.pordLinkAccPreOrderIdStr))
				{
					invoice.GuId = Guid.Parse(_003C_003Ec__DisplayClass56_.pord.pordLinkAccPreOrderIdStr);
					invoice.UpdateKind = ActionType.insertOrUpdate;
				}
				if (_003C_003Ec__DisplayClass56_.pord.pordDateTime.HasValue)
				{
					invoice.InvDate = _003C_003Ec__DisplayClass56_.pord.pordDateTime.Value.ToString("yyyyMMdd", new CultureInfo("en-US"));
				}
				if (_003C_003Ec__DisplayClass56_.pord.FirstRegisterDate.HasValue)
				{
					invoice.CreatedDate = _003C_003Ec__DisplayClass56_.pord.FirstRegisterDate;
				}
				invoice.DeleteAllExpenses = true;
				decimal num = default(decimal);
				decimal num2 = default(decimal);
				List<InvoiceBody> list7 = new List<InvoiceBody>();
				List<WSspSelectPreOrderItems_Result> list8 = Enumerable.ToList<WSspSelectPreOrderItems_Result>((IEnumerable<WSspSelectPreOrderItems_Result>)_db.WSspSelectPreOrderItems(_003C_003Ec__DisplayClass56_.pord.PreOrderID, lCID, result));
				if (list8 != null && string.IsNullOrWhiteSpace(text))
				{
					using List<WSspSelectPreOrderItems_Result>.Enumerator enumerator2 = list8.GetEnumerator();
					while (enumerator2.MoveNext())
					{
						_003C_003Ec__DisplayClass56_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass56_2();
						CS_0024_003C_003E8__locals1.pordI = enumerator2.Current;
						string text4 = "";
						string text5 = "";
						WSspSelectWareHouse_Result wSspSelectWareHouse_Result = new WSspSelectWareHouse_Result();
						if (shygunSetting.WrhsSyncTypeId == 2 && !string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals1.pordI.pordILinkAccWHIdStr))
						{
							WSspSelectWareHouse_Result wSspSelectWareHouse_Result2 = Enumerable.FirstOrDefault<WSspSelectWareHouse_Result>((IEnumerable<WSspSelectWareHouse_Result>)list4, (Func<WSspSelectWareHouse_Result, bool>)((WSspSelectWareHouse_Result x) => x.WareHouseID == CS_0024_003C_003E8__locals1.pordI.pordIWHId));
							if (wSspSelectWareHouse_Result2 != null && !string.IsNullOrWhiteSpace(wSspSelectWareHouse_Result2.WrhsLinkAccWareHouses))
							{
								List<CommonWithIdStrViewModel> list9 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(wSspSelectWareHouse_Result2.WrhsLinkAccWareHouses);
								if (list9 != null && list9.Count > 0)
								{
									CommonWithIdStrViewModel commonWithIdStrViewModel = Enumerable.FirstOrDefault<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list9, (Func<CommonWithIdStrViewModel, bool>)((CommonWithIdStrViewModel x) => x.Code == CS_0024_003C_003E8__locals1.pordI.pordILinkAccWHIdStr));
									if (commonWithIdStrViewModel != null)
									{
										text5 = commonWithIdStrViewModel.Name;
										text4 = commonWithIdStrViewModel.Id;
									}
								}
								else
								{
									wSspSelectWareHouse_Result = Enumerable.FirstOrDefault<WSspSelectWareHouse_Result>((IEnumerable<WSspSelectWareHouse_Result>)list4, (Func<WSspSelectWareHouse_Result, bool>)((WSspSelectWareHouse_Result x) => x.WareHouseID == CS_0024_003C_003E8__locals1.pordI.pordIWHId));
								}
							}
						}
						else
						{
							wSspSelectWareHouse_Result = Enumerable.FirstOrDefault<WSspSelectWareHouse_Result>((IEnumerable<WSspSelectWareHouse_Result>)list4, (Func<WSspSelectWareHouse_Result, bool>)((WSspSelectWareHouse_Result x) => x.WareHouseID == CS_0024_003C_003E8__locals1.pordI.pordIWHId));
							if (wSspSelectWareHouse_Result != null)
							{
								text4 = wSspSelectWareHouse_Result.WrhsLinkAccWhIdStr;
								text5 = wSspSelectWareHouse_Result.WrhsName;
							}
						}
						if (string.IsNullOrWhiteSpace(text4) || string.IsNullOrWhiteSpace(text5))
						{
							text = text + "<br>" + string.Format(Messages.msgErrorWareHouseNotFoundInAccLink, (wSspSelectWareHouse_Result != null) ? wSspSelectWareHouse_Result.WrhsName : "", Labels.Shygun);
						}
						WSspSelectProductWithAccLinkField_Result wSspSelectProductWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectProductWithAccLinkField_Result>((IEnumerable<WSspSelectProductWithAccLinkField_Result>)list3, (Func<WSspSelectProductWithAccLinkField_Result, bool>)((WSspSelectProductWithAccLinkField_Result x) => x.ProductID == CS_0024_003C_003E8__locals1.pordI.pordIPrdId));
						if (wSspSelectProductWithAccLinkField_Result == null)
						{
							text = text + "<br>" + string.Format(Messages.msgErrorProductNotFoundInAccLink, CS_0024_003C_003E8__locals1.pordI.PrdName ?? "", Labels.Shygun);
						}
						else if (string.IsNullOrWhiteSpace(wSspSelectProductWithAccLinkField_Result.PrdLinkAccPrdIdStr))
						{
							text = text + "<br>" + string.Format(Messages.msgErrorProductNotFoundInAccLink, wSspSelectProductWithAccLinkField_Result.PrdName ?? "", Labels.Shygun);
						}
						if (string.IsNullOrWhiteSpace(text))
						{
							InvoiceBody invoiceBody = new InvoiceBody();
							invoiceBody.ItemNumber = wSspSelectProductWithAccLinkField_Result.PrdLinkAccPrdCode;
							invoiceBody.ItemGuId = Guid.Parse(wSspSelectProductWithAccLinkField_Result.PrdLinkAccPrdIdStr);
							invoiceBody.ItemDescription = CS_0024_003C_003E8__locals1.pordI.pordIDescription ?? "";
							invoiceBody.Price = CS_0024_003C_003E8__locals1.pordI.pordIPrice.GetValueOrDefault();
							invoiceBody.Amount = CS_0024_003C_003E8__locals1.pordI.pordITotalPrice;
							if (CS_0024_003C_003E8__locals1.pordI.pordIDiscount.HasValue)
							{
								invoiceBody.LineDiscAmount = CS_0024_003C_003E8__locals1.pordI.pordIDiscount;
							}
							else if (CS_0024_003C_003E8__locals1.pordI.pordIDiscountPercent.HasValue)
							{
								invoiceBody.LineDiscPer = CS_0024_003C_003E8__locals1.pordI.pordIDiscountPercent;
								WSspSelectPreOrderItems_Result pordI = CS_0024_003C_003E8__locals1.pordI;
								decimal valueOrDefault = CS_0024_003C_003E8__locals1.pordI.pordIPrice.GetValueOrDefault();
								decimal? pordIDiscountPercent = CS_0024_003C_003E8__locals1.pordI.pordIDiscountPercent;
								pordI.pordIDiscount = (decimal?)valueOrDefault * pordIDiscountPercent / (decimal?)100;
							}
							invoiceBody.Price -= (decimal?)CS_0024_003C_003E8__locals1.pordI.pordIDiscount.GetValueOrDefault();
							double num3 = CS_0024_003C_003E8__locals1.pordI.pordIQuantity.GetValueOrDefault(1.0) * CS_0024_003C_003E8__locals1.pordI.pordIFCR.GetValueOrDefault(1.0) * CS_0024_003C_003E8__locals1.pordI.pordIFCRI.GetValueOrDefault(1.0);
							invoiceBody.Quan = ((num3 > 0.0) ? decimal.Parse(num3.ToString()) : 0m);
							num += CS_0024_003C_003E8__locals1.pordI.pordITaxSum.GetValueOrDefault();
							num2 += (CS_0024_003C_003E8__locals1.pordI.pordIRound.GetValueOrDefault() - CS_0024_003C_003E8__locals1.pordI.pordIRoundPlus.GetValueOrDefault()) * decimal.Parse(num3.ToString());
							invoiceBody.LineItemDesc = CS_0024_003C_003E8__locals1.pordI.pordIDescription;
							invoiceBody.STGuId = Guid.Parse(text4);
							invoiceBody.STDesc = text5;
							invoiceBody.GuId = Guid.NewGuid();
							invoiceBody.UpdateKind = ActionType.insert;
							if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals1.pordI.pordILinkAccItemIdStr))
							{
								invoiceBody.GuId = Guid.Parse(CS_0024_003C_003E8__locals1.pordI.pordILinkAccItemIdStr);
								invoiceBody.UpdateKind = ActionType.insertOrUpdate;
							}
							DbSet<WSPreOrderItems> wSPreOrderItems = _dbTbl.WSPreOrderItems;
							ParameterExpression val = Expression.Parameter(typeof(WSPreOrderItems), "x");
							WSPreOrderItems wSPreOrderItems2 = Queryable.FirstOrDefault<WSPreOrderItems>((IQueryable<WSPreOrderItems>)wSPreOrderItems, Expression.Lambda<Func<WSPreOrderItems, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass56_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (wSPreOrderItems2 != null)
							{
								_dbTbl.Entry(wSPreOrderItems2).State = EntityState.Modified;
								wSPreOrderItems2.pordILinkAccItemIdStr = invoiceBody.GuId.ToString();
								_dbTbl.Configuration.ValidateOnSaveEnabled = false;
								_dbTbl.SaveChanges();
								_dbTbl.Configuration.ValidateOnSaveEnabled = true;
							}
							list7.Add(invoiceBody);
						}
					}
				}
				invoice.Body = list7;
				if (num > 0m)
				{
					_003C_003Ec__DisplayClass56_.pord.pordTax = _003C_003Ec__DisplayClass56_.pord.pordTax.GetValueOrDefault() + num;
				}
				if (num2 > 0m)
				{
					_003C_003Ec__DisplayClass56_.pord.pordRound = _003C_003Ec__DisplayClass56_.pord.pordRound.GetValueOrDefault() + num2;
				}
				List<InvoiceExpense> list10 = new List<InvoiceExpense>();
				if (!string.IsNullOrWhiteSpace(shygunSetting.OrdTax))
				{
					decimal? pordTax = _003C_003Ec__DisplayClass56_.pord.pordTax;
					if ((pordTax.GetValueOrDefault() > default(decimal)) & pordTax.HasValue)
					{
						InvoiceExpense invoiceExpense = new InvoiceExpense();
						invoiceExpense.AccountNumber = shygunSetting.OrdTax;
						invoiceExpense.AccountName = shygunSetting.OrdTaxFieldTitle;
						invoiceExpense.InvExpRowAmount = _003C_003Ec__DisplayClass56_.pord.pordTax;
						invoiceExpense.UpdateKind = ActionType.insert;
						if (!string.IsNullOrWhiteSpace(_003C_003Ec__DisplayClass56_.pord.pordLinkAccPreOrderIdStr))
						{
							invoiceExpense.UpdateKind = ActionType.insertOrUpdate;
						}
						list10.Add(invoiceExpense);
					}
				}
				if (!string.IsNullOrWhiteSpace(shygunSetting.OrdTransportation))
				{
					decimal? pordTax = _003C_003Ec__DisplayClass56_.pord.pordTransportation;
					if ((pordTax.GetValueOrDefault() > default(decimal)) & pordTax.HasValue)
					{
						InvoiceExpense invoiceExpense2 = new InvoiceExpense();
						invoiceExpense2.AccountNumber = shygunSetting.OrdTransportation;
						invoiceExpense2.AccountName = shygunSetting.OrdTransportationFieldTitle;
						invoiceExpense2.InvExpRowAmount = _003C_003Ec__DisplayClass56_.pord.pordTransportation;
						invoiceExpense2.UpdateKind = ActionType.insert;
						if (!string.IsNullOrWhiteSpace(_003C_003Ec__DisplayClass56_.pord.pordLinkAccPreOrderIdStr))
						{
							invoiceExpense2.UpdateKind = ActionType.insertOrUpdate;
						}
						list10.Add(invoiceExpense2);
					}
				}
				if (!string.IsNullOrWhiteSpace(shygunSetting.OrdRound))
				{
					decimal? pordTax = _003C_003Ec__DisplayClass56_.pord.pordRound;
					if ((pordTax.GetValueOrDefault() > default(decimal)) & pordTax.HasValue)
					{
						InvoiceExpense invoiceExpense3 = new InvoiceExpense();
						invoiceExpense3.AccountNumber = shygunSetting.OrdRound;
						invoiceExpense3.AccountName = shygunSetting.OrdRoundFieldTitle;
						invoiceExpense3.InvExpRowAmount = _003C_003Ec__DisplayClass56_.pord.pordRound;
						invoiceExpense3.UpdateKind = ActionType.insert;
						if (!string.IsNullOrWhiteSpace(_003C_003Ec__DisplayClass56_.pord.pordLinkAccPreOrderIdStr))
						{
							invoiceExpense3.UpdateKind = ActionType.insertOrUpdate;
						}
						list10.Add(invoiceExpense3);
					}
				}
				invoice.Expense = list10;
				if (string.IsNullOrWhiteSpace(text))
				{
					list5.Add(invoice);
					if (!string.IsNullOrWhiteSpace(text2))
					{
						text2 += ",";
					}
					text2 += _003C_003Ec__DisplayClass56_.pord.PreOrderID;
				}
			}
			if (list5 != null && list5.Count > 0 && string.IsNullOrWhiteSpace(text))
			{
				PutResults putResults = new WebServiePutInvoice(shygunSetting.IP, shygunSetting.conf, list5).PutOperation();
				if (string.IsNullOrWhiteSpace(putResults.ErrorMessage))
				{
					string[] array = text2.Split(new char[1] { ',' });
					for (int i = 0; i < array.Length; i++)
					{
						text = putResults.Result[i].ErrorMessage;
						if (string.IsNullOrWhiteSpace(text))
						{
							_003C_003Ec__DisplayClass56_3 _003C_003Ec__DisplayClass56_2 = new _003C_003Ec__DisplayClass56_3();
							_003C_003Ec__DisplayClass56_2.Id = 0;
							int.TryParse(array[i], out _003C_003Ec__DisplayClass56_2.Id);
							DbSet<WSPreOrder> wSPreOrder5 = _dbTbl.WSPreOrder;
							ParameterExpression val = Expression.Parameter(typeof(WSPreOrder), "m");
							WSPreOrder wSPreOrder6 = Queryable.FirstOrDefault<WSPreOrder>((IQueryable<WSPreOrder>)wSPreOrder5, Expression.Lambda<Func<WSPreOrder, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass56_2, typeof(_003C_003Ec__DisplayClass56_3)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (wSPreOrder6 != null)
							{
								_dbTbl.Entry(wSPreOrder6).State = EntityState.Modified;
								wSPreOrder6.pordLinkAccPreOrderNumber = putResults.Result[i].Number;
								wSPreOrder6.pordLinkAccPreOrderIdStr = putResults.Result[i].GuId;
								_dbTbl.Configuration.ValidateOnSaveEnabled = false;
								_dbTbl.SaveChanges();
								_dbTbl.Configuration.ValidateOnSaveEnabled = true;
							}
							else
							{
								text = "<br>" + Messages.msgErrorInSendToOtherSystem + " " + Labels.OtherSystemsOrder;
							}
						}
					}
				}
				else
				{
					text += putResults.ErrorMessage;
				}
			}
			if (!string.IsNullOrEmpty(text))
			{
				data = 0;
				data2 = new CommonResultViewModel<int>
				{
					Data = data,
					Message = text,
					Status = CommonResultStatusViewModel.Error
				};
				return Json(data2, JsonRequestBehavior.AllowGet);
			}
			text = "";
			commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			data = 0;
			data2 = new CommonResultViewModel<int>
			{
				Data = data,
				Message = Messages.msgErrorRunFunction,
				Status = CommonResultStatusViewModel.Error
			};
			return Json(data2, JsonRequestBehavior.AllowGet);
		}
		data2 = new CommonResultViewModel<int>
		{
			Data = data,
			Message = text,
			Status = commonResultStatusViewModel
		};
		return Json(data2, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetShygunExportPreOrderList(int pordOprId, string fDate = "", string tDate = "", long value = 0L, int currentItemId = 0)
	{
		List<OtherSystemSelectedViewModel> list = new List<OtherSystemSelectedViewModel>();
		try
		{
			foreach (CRMspLkWSSelectPreOrder_Result item2 in SelectPreOrderExport(pordOprId, fDate, tDate, value, currentItemId))
			{
				OtherSystemSelectedViewModel item = new OtherSystemSelectedViewModel
				{
					Row = item2.RowNumber.GetValueOrDefault(),
					Id = item2.PreOrderID,
					Selected = string.IsNullOrEmpty(item2.pordLinkAccPreOrderIdStr)
				};
				list.Add(item);
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

	[DynamicAuthorize(ControllerName = "frmPreOrder", ActionName = "actManagePordLinkAcc,actSendToAcc,actSendPayToAcc,actSendAllPayToAcc")]
	public ActionResult ShygunManagePordLinkAcc()
	{
		GetPreOrderOpr();
		GetCrmWh();
		GetPordReferUser();
		int num = 0;
		DbSet<CrmLinkAccShygunSetting> crmLinkAccShygunSetting = _dbTbl.CrmLinkAccShygunSetting;
		ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccShygunSetting), "x");
		CrmLinkAccShygunSetting crmLinkAccShygunSetting2 = Queryable.FirstOrDefault<CrmLinkAccShygunSetting>((IQueryable<CrmLinkAccShygunSetting>)crmLinkAccShygunSetting, Expression.Lambda<Func<CrmLinkAccShygunSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)this, typeof(PreOrderController)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
		if (crmLinkAccShygunSetting2 != null)
		{
			num = ((!string.IsNullOrWhiteSpace(crmLinkAccShygunSetting2.PartValue)) ? int.Parse(crmLinkAccShygunSetting2.PartValue) : 0);
		}
		base.ViewBag.SyncTypeId = num;
		return View();
	}

	[HttpPost]
	public JsonResult ShygunDeleteImportedInfo(string records)
	{
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
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
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			new List<LinkedCompanyWithAccViewModel>();
			List<OtherSystemSelectedVIiewModel> list = new List<OtherSystemSelectedVIiewModel>();
			string text3 = "";
			int num = 0;
			if (!UserLogin.IsUserAccess("frmManagePordLinkAcc", "actDeleteImportedInfo", UserLogin.CurrentUser))
			{
				text3 = text3 + Messages.ErrorNotAccess + "<br>";
				num++;
			}
			if (string.IsNullOrWhiteSpace(records))
			{
				text3 = text3 + Messages.msgErrorNotSelectedItem + "<br>";
				num++;
			}
			else
			{
				List<OtherSystemSelectedVIiewModel> list2 = new List<OtherSystemSelectedVIiewModel>();
				if (!string.IsNullOrWhiteSpace(records))
				{
					list2 = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedVIiewModel>>(records);
					if (Enumerable.Any<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list2))
					{
						list = Enumerable.ToList<OtherSystemSelectedVIiewModel>(Enumerable.Where<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list2, (Func<OtherSystemSelectedVIiewModel, bool>)((OtherSystemSelectedVIiewModel m) => m.Selected)));
					}
				}
			}
			string text4 = "";
			if (list == null && !Enumerable.Any<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list))
			{
				text3 = Messages.msgErrorNotSelectedItem + "<br>";
				num++;
			}
			else
			{
				foreach (OtherSystemSelectedVIiewModel item in list)
				{
					text4 = text4 + item.Id + ",";
				}
			}
			if (string.IsNullOrWhiteSpace(text4))
			{
				text3 = Messages.msgErrorNotSelectedItem + "<br>";
				num++;
			}
			if (num == 0)
			{
				string text5 = "";
				text = "";
				List<CRMspLkShygunWSDeleteLinkedPreOrder_Result> list3 = Enumerable.ToList<CRMspLkShygunWSDeleteLinkedPreOrder_Result>((IEnumerable<CRMspLkShygunWSDeleteLinkedPreOrder_Result>)_dbLink.CRMspLkShygunWSDeleteLinkedPreOrder(text4, lCID, result));
				if (list3 != null && Enumerable.Any<CRMspLkShygunWSDeleteLinkedPreOrder_Result>((IEnumerable<CRMspLkShygunWSDeleteLinkedPreOrder_Result>)list3))
				{
					text = "error";
					text5 = GetFileShygunNotDeletedImportedInfo(list3);
				}
				if (!string.IsNullOrWhiteSpace(text5))
				{
					text2 = Messages.msgNotCompeleteSuccessAction;
					text2 = text2 + "<br><a href='" + text5 + "' class='link-excel-file' target='_blank'>" + Messages.msgLinkForDownloadFileWithError + "</a>";
				}
				else
				{
					text2 = Messages.msgSuccessAction;
				}
				commonResultStatusViewModel = CommonResultStatusViewModel.Success;
			}
			else
			{
				text = "";
				text2 = text3;
				commonResultStatusViewModel = CommonResultStatusViewModel.Error;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			text = "";
			data = new CommonResultViewModel<string>
			{
				Data = text,
				Message = Messages.msgErrorRunFunction + "<br>" + ex.Message,
				Status = CommonResultStatusViewModel.Error
			};
			return Json(data, JsonRequestBehavior.AllowGet);
		}
		data = new CommonResultViewModel<string>
		{
			Data = text,
			Message = text2,
			Status = commonResultStatusViewModel
		};
		JsonResult jsonResult = Json(data, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public string GetFileShygunNotDeletedImportedInfo(List<CRMspLkShygunWSDeleteLinkedPreOrder_Result> res)
	{
		//IL_0343: Unknown result type (might be due to invalid IL or missing references)
		//IL_035e: Unknown result type (might be due to invalid IL or missing references)
		string text = "";
		Guid.NewGuid().ToString();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			int userId = UserLogin.CurrentUser.UserId;
			if (res != null && Enumerable.Any<CRMspLkShygunWSDeleteLinkedPreOrder_Result>((IEnumerable<CRMspLkShygunWSDeleteLinkedPreOrder_Result>)res))
			{
				ExcelPackage excelPackage = new ExcelPackage();
				ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add(Labels.OtherSystemsExcelPropertiesTitle);
				int num = 0;
				int num2 = 1;
				num++;
				excelWorksheet.Cells[num2, num].Value = string.Format(Labels.OtherSystemsImListPordNumber, "CRM");
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsImListPordNumber + " (" + Labels.Shygun + ")";
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsLinkedListCmpName;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListLinkDesc;
				foreach (CRMspLkShygunWSDeleteLinkedPreOrder_Result re in res)
				{
					num2++;
					num = 0;
					num++;
					excelWorksheet.Cells[num2, num].Value = re.pordNumber.ToString();
					num++;
					excelWorksheet.Cells[num2, num].Value = re.pordLinkAccPreOrderNumber ?? "";
					num++;
					excelWorksheet.Cells[num2, num].Value = re.CompanyName ?? "";
					string redundancyMessage = Messages.RedundancyMessage;
					num++;
					excelWorksheet.Cells[num2, num].Value = redundancyMessage;
				}
				string text2 = base.Server.MapPath(Configuration.HostTempFilesPath) + "\\ReportLinkAccNotDeletedInfo\\" + userId;
				string text3 = "CRM-Ideal-" + DateTime.Now.ToString("dd-MM-yyyy-hh-mm-ss") + ".xls";
				string path = text2 + "\\" + text3;
				try
				{
					DirectoryInfo directoryInfo = new DirectoryInfo(text2);
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
					if (System.IO.Directory.Exists(text2))
					{
						System.IO.Directory.Delete(text2);
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
				}
				if (!System.IO.Directory.Exists(text2))
				{
					System.IO.Directory.CreateDirectory(text2);
					CRM.General.IO.Directory.SetFullControlForEveryOne(text2);
				}
				using (ExcelRange excelRange = excelWorksheet.Cells[1, 1, 1, num])
				{
					excelRange.Style.Font.Bold = true;
					excelRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
					excelRange.Style.Fill.BackgroundColor.SetColor(Color.DarkBlue);
					excelRange.Style.Font.Color.SetColor(Color.White);
				}
				excelPackage.Workbook.Properties.Title = Labels.OtherSystemsExcelPropertiesTitle;
				excelPackage.Workbook.Properties.Company = Labels.OtherSystemsExcelPropertiesCompany;
				Stream stream = System.IO.File.Create(path);
				excelPackage.SaveAs(stream);
				stream.Close();
				if (System.IO.File.Exists(path))
				{
					text = Configuration.HostTempFilesPath + "/ReportLinkAccNotDeletedInfo/" + userId + "/" + text3;
					text = text.Replace("~/", "/");
					text = (text.StartsWith("/") ? text : ("/" + text));
				}
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return text;
	}

	public List<CRMspLkWSSelectPreOrder_Result> SelectPreOrder(string fDate = "", string tDate = "", long value = 0L, int currLangId = 1065, int defaultLanguageID = 1065, int oprId = 0, int currentItemId = 0)
	{
		List<CRMspLkWSSelectPreOrder_Result> list = new List<CRMspLkWSSelectPreOrder_Result>();
		try
		{
			int result = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result);
			}
			DateTime value2 = DateTime.Now;
			DateTime value3 = DateTime.Now;
			if (!string.IsNullOrEmpty(fDate))
			{
				value2 = DateTime.Parse(PersianDate.GetFormatetdDate(fDate.Replace("/", "")) + " 00:00:00", currLangId switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			if (!string.IsNullOrEmpty(tDate))
			{
				value3 = DateTime.Parse(PersianDate.GetFormatetdDate(tDate.Replace("/", "")) + " 23:59:59", currLangId switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			list = Enumerable.ToList<CRMspLkWSSelectPreOrder_Result>((IEnumerable<CRMspLkWSSelectPreOrder_Result>)_dbLink.CRMspLkWSSelectPreOrder(oprId, UserLogin.CurrentUser.UserId, (!string.IsNullOrEmpty(fDate)) ? new DateTime?(value2) : null, (!string.IsNullOrEmpty(tDate)) ? new DateTime?(value3) : null, value, currLangId, defaultLanguageID, result, currentItemId));
			JsonConvert.SerializeObject(list);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[AjaxOnly]
	public JsonResult GetPreOrderOpr()
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
			List<WSspSelectPreOrderOpr_Result> list2 = Enumerable.ToList<WSspSelectPreOrderOpr_Result>((IEnumerable<WSspSelectPreOrderOpr_Result>)_db.WSspSelectPreOrderOpr(lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectPreOrderOpr_Result, SelectListItem>((IEnumerable<WSspSelectPreOrderOpr_Result>)list2, (Func<WSspSelectPreOrderOpr_Result, SelectListItem>)((WSspSelectPreOrderOpr_Result item) => new SelectListItem
			{
				Text = item.PreOrderOpr,
				Value = item.PreOrderOprID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PreOrderOprList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetSepSaleType(int linkAccSettingDBId)
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
			List<CRMspLkSepSelectSaleType_Result> list2 = Enumerable.ToList<CRMspLkSepSelectSaleType_Result>((IEnumerable<CRMspLkSepSelectSaleType_Result>)_dbLink.CRMspLkSepSelectSaleType(linkAccSettingDBId, lCID, result));
			list.AddRange(Enumerable.Select<CRMspLkSepSelectSaleType_Result, SelectListItem>((IEnumerable<CRMspLkSepSelectSaleType_Result>)list2, (Func<CRMspLkSepSelectSaleType_Result, SelectListItem>)((CRMspLkSepSelectSaleType_Result item) => new SelectListItem
			{
				Text = item.Title,
				Value = item.SaleTypeId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.SepSaleTypeList = list;
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
	public JsonResult GetPordReferUser()
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

	public List<WSspSelectActiveWareHouse_Result> SelectActiveWareHouse()
	{
		List<WSspSelectActiveWareHouse_Result> result = new List<WSspSelectActiveWareHouse_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			_ = UserLogin.CurrentUser.UserId;
			result = CRMIdeal.Classes.Helper.Warehouse.SelectActiveWareHouse();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public JsonResult GetCrmWh()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<WSspSelectActiveWareHouse_Result> list2 = SelectActiveWareHouse();
			if (list2 != null && list2.Count > 0)
			{
				list.AddRange(Enumerable.Select<WSspSelectActiveWareHouse_Result, SelectListItem>((IEnumerable<WSspSelectActiveWareHouse_Result>)list2, (Func<WSspSelectActiveWareHouse_Result, SelectListItem>)((WSspSelectActiveWareHouse_Result item) => new SelectListItem
				{
					Text = item.WrhsName,
					Value = item.WareHouseID.ToString(),
					Selected = false
				})));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CrmWHList = list;
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
	public JsonResult GetCrmOrderPayType()
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
		base.ViewBag.CrmOrdPayTypeList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public JsonResult GetPordPrintFormat()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int result = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result);
			}
			List<spSelectPrintFormat_Result> list2 = CRMIdeal.Classes.Helper.PrintFormat.GetspPrintFortants(result, 1);
			if (list2 != null && list2.Count > 0)
			{
				list.AddRange(Enumerable.Select<spSelectPrintFormat_Result, SelectListItem>((IEnumerable<spSelectPrintFormat_Result>)list2, (Func<spSelectPrintFormat_Result, SelectListItem>)((spSelectPrintFormat_Result item) => new SelectListItem
				{
					Text = (item.Title ?? ""),
					Value = item.PrintFormatID.ToString(),
					Selected = false
				})));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PordPrintFormatList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmPreOrder", ActionName = "actSendToAcc")]
	public ActionResult TarazPordSendToAcc()
	{
		return View();
	}

	[AjaxOnly]
	public string TarazActSendToAcc(int pordId)
	{
		//IL_1fc4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fc9: Unknown result type (might be due to invalid IL or missing references)
		//IL_28af: Unknown result type (might be due to invalid IL or missing references)
		//IL_28b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_2fb7: Unknown result type (might be due to invalid IL or missing references)
		//IL_2fbc: Unknown result type (might be due to invalid IL or missing references)
		//IL_2411: Unknown result type (might be due to invalid IL or missing references)
		//IL_2416: Unknown result type (might be due to invalid IL or missing references)
		string result = "";
		try
		{
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			long result2 = 0L;
			long result3 = 0L;
			long result4 = 0L;
			long result5 = 0L;
			long result6 = 0L;
			long result7 = 0L;
			long result8 = 0L;
			int result9 = 0;
			if (!UserLogin.IsUserAccess("frmPreOrder", "actSendToAcc", currentUser))
			{
				return Messages.ErrorNotAccess + "|";
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result10);
			if (result10 <= 0)
			{
				result10 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (pordId > 0)
			{
				_003C_003Ec__DisplayClass73_0 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass73_0();
				CS_0024_003C_003E8__locals1.pord = Enumerable.FirstOrDefault<WSspSelectPreOrderWithId_Result>((IEnumerable<WSspSelectPreOrderWithId_Result>)_db.WSspSelectPreOrderWithId(pordId, lCID, result10));
				if (CS_0024_003C_003E8__locals1.pord != null)
				{
					string errorMessage = "";
					if (!PreOrder.SendToLinkAccNeedVerify(pordId, ref errorMessage))
					{
						return errorMessage + "|";
					}
					List<WSspSelectProductWithAccLinkField_Result> list = Enumerable.ToList<WSspSelectProductWithAccLinkField_Result>((IEnumerable<WSspSelectProductWithAccLinkField_Result>)_dbLink.WSspSelectProductWithAccLinkField(false, false, true, lCID, result10));
					List<WSspSelectWareHouseWithAccLinkField_Result> list2 = Enumerable.ToList<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)_dbLink.WSspSelectWareHouseWithAccLinkField(false, false, true, languageID: lCID, defaultLanguageID: result10, withWrhsLinkAccWareHouses: false));
					List<WSspSelectProductUnitWithAccLinkField_Result> list3 = Enumerable.ToList<WSspSelectProductUnitWithAccLinkField_Result>((IEnumerable<WSspSelectProductUnitWithAccLinkField_Result>)_dbLink.WSspSelectProductUnitWithAccLinkField(false, true, lCID, result10));
					List<CRMspSelectUsersWithAccLinkField_Result> list4 = Enumerable.ToList<CRMspSelectUsersWithAccLinkField_Result>((IEnumerable<CRMspSelectUsersWithAccLinkField_Result>)_dbLink.CRMspSelectUsersWithAccLinkField(true, false, lCID, result10));
					List<WSspSelectProductPriceGroupWithAccLinkField_Result> list5 = Enumerable.ToList<WSspSelectProductPriceGroupWithAccLinkField_Result>((IEnumerable<WSspSelectProductPriceGroupWithAccLinkField_Result>)_dbLink.WSspSelectProductPriceGroupWithAccLinkField(true, lCID, result10));
					List<WSspSelectPreOrderTypesWithAccLinkField_Result> list6 = Enumerable.ToList<WSspSelectPreOrderTypesWithAccLinkField_Result>((IEnumerable<WSspSelectPreOrderTypesWithAccLinkField_Result>)_dbLink.WSspSelectPreOrderTypesWithAccLinkField(true, lCID, result10));
					List<WSspSelectDeliveryTermWithAccLinkField_Result> list7 = Enumerable.ToList<WSspSelectDeliveryTermWithAccLinkField_Result>((IEnumerable<WSspSelectDeliveryTermWithAccLinkField_Result>)_dbLink.WSspSelectDeliveryTermWithAccLinkField(true, lCID, result10));
					List<WSspSelectSaleCenterWithAccLinkField_Result> list8 = Enumerable.ToList<WSspSelectSaleCenterWithAccLinkField_Result>((IEnumerable<WSspSelectSaleCenterWithAccLinkField_Result>)_dbLink.WSspSelectSaleCenterWithAccLinkField(true, lCID, result10));
					if (!CS_0024_003C_003E8__locals1.pord.pordReferUserId.HasValue)
					{
						return string.Format(Messages.msgErrorInSendPordToAccLinkNotSelectedItem, CS_0024_003C_003E8__locals1.pord.pordNumber, Labels.TarazSamaneh, Labels.pordReferUserId) + "|";
					}
					CRMspSelectUsersWithAccLinkField_Result cRMspSelectUsersWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectUsersWithAccLinkField_Result>((IEnumerable<CRMspSelectUsersWithAccLinkField_Result>)list4, (Func<CRMspSelectUsersWithAccLinkField_Result, bool>)((CRMspSelectUsersWithAccLinkField_Result m) => m.UserId == CS_0024_003C_003E8__locals1.pord.pordReferUserId));
					if (cRMspSelectUsersWithAccLinkField_Result == null)
					{
						return string.Format(Messages.msgErrorInSendPordToAccLinkNotFoundIteminAcc, CS_0024_003C_003E8__locals1.pord.pordNumber, Labels.TarazSamaneh, Labels.pordReferUserId, CS_0024_003C_003E8__locals1.pord.pordReferUser ?? "") + "|";
					}
					string linkAccUserIdStr = cRMspSelectUsersWithAccLinkField_Result.LinkAccUserIdStr;
					if (string.IsNullOrEmpty(linkAccUserIdStr))
					{
						return string.Format(Messages.msgErrorInSendPordToAccLinkNotFoundIteminAcc, CS_0024_003C_003E8__locals1.pord.pordNumber, Labels.TarazSamaneh, Labels.pordReferUserId, cRMspSelectUsersWithAccLinkField_Result.FullName ?? "") + "|";
					}
					long.TryParse(linkAccUserIdStr, out result5);
					int result11 = 0;
					List<CRMspSelectLinkAccTarazSetting_Result> list9 = Enumerable.ToList<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)_dbLink.CRMspSelectLinkAccTarazSetting(11, "Setting", lCID, result10));
					if (list9 != null)
					{
						string text = "0";
						CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list9, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 11));
						if (cRMspSelectLinkAccTarazSetting_Result != null)
						{
							text = cRMspSelectLinkAccTarazSetting_Result.PartValue ?? "0";
						}
						if (!string.IsNullOrEmpty(text))
						{
							int.TryParse(text, out result11);
						}
					}
					else
					{
						Exception e = new Exception(Messages.errorInReadingSetting + " (tarazSamaneh) ");
						ErrorSignal.FromCurrentContext().Raise(e);
					}
					if (!CS_0024_003C_003E8__locals1.pord.pordSellerId.HasValue && result11 == 1)
					{
						return string.Format(Messages.msgErrorInSendPordToAccLinkNotSelectedItem, CS_0024_003C_003E8__locals1.pord.pordNumber, Labels.TarazSamaneh, Labels.pordSellerId) + "|";
					}
					if (CS_0024_003C_003E8__locals1.pord.pordSellerId.HasValue)
					{
						CRMspSelectUsersWithAccLinkField_Result cRMspSelectUsersWithAccLinkField_Result2 = Enumerable.FirstOrDefault<CRMspSelectUsersWithAccLinkField_Result>((IEnumerable<CRMspSelectUsersWithAccLinkField_Result>)list4, (Func<CRMspSelectUsersWithAccLinkField_Result, bool>)((CRMspSelectUsersWithAccLinkField_Result m) => m.UserId == CS_0024_003C_003E8__locals1.pord.pordSellerId));
						if (cRMspSelectUsersWithAccLinkField_Result2 == null)
						{
							return string.Format(Messages.msgErrorInSendPordToAccLinkNotFoundIteminAcc, CS_0024_003C_003E8__locals1.pord.pordNumber, Labels.TarazSamaneh, Labels.pordSellerId, CS_0024_003C_003E8__locals1.pord.pordSeller ?? "") + "|";
						}
						string linkAccUserIdStr2 = cRMspSelectUsersWithAccLinkField_Result2.LinkAccUserIdStr;
						if (string.IsNullOrEmpty(linkAccUserIdStr2))
						{
							return string.Format(Messages.msgErrorInSendPordToAccLinkNotFoundIteminAcc, CS_0024_003C_003E8__locals1.pord.pordNumber, Labels.TarazSamaneh, Labels.pordSellerId, cRMspSelectUsersWithAccLinkField_Result2.FullName ?? "") + "|";
						}
						long.TryParse(linkAccUserIdStr2, out result8);
					}
					if (!CS_0024_003C_003E8__locals1.pord.pordDefPrdPriceGroupId.HasValue)
					{
						return string.Format(Messages.msgErrorInSendPordToAccLinkNotSelectedItem, CS_0024_003C_003E8__locals1.pord.pordNumber, Labels.TarazSamaneh, Labels.pordDefPrdPriceGroupId) + "|";
					}
					WSspSelectProductPriceGroupWithAccLinkField_Result wSspSelectProductPriceGroupWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectProductPriceGroupWithAccLinkField_Result>((IEnumerable<WSspSelectProductPriceGroupWithAccLinkField_Result>)list5, (Func<WSspSelectProductPriceGroupWithAccLinkField_Result, bool>)((WSspSelectProductPriceGroupWithAccLinkField_Result m) => m.ProductPriceGroupID == CS_0024_003C_003E8__locals1.pord.pordDefPrdPriceGroupId));
					if (wSspSelectProductPriceGroupWithAccLinkField_Result == null)
					{
						return string.Format(Messages.msgErrorInSendPordToAccLinkNotFoundIteminAcc, CS_0024_003C_003E8__locals1.pord.pordNumber, Labels.TarazSamaneh, Labels.pordDefPrdPriceGroupId, CS_0024_003C_003E8__locals1.pord.pordDefPrdPriceGroup ?? "") + "|";
					}
					string linkAccPrdPriceGroupIdStr = wSspSelectProductPriceGroupWithAccLinkField_Result.LinkAccPrdPriceGroupIdStr;
					if (string.IsNullOrEmpty(linkAccPrdPriceGroupIdStr))
					{
						return string.Format(Messages.msgErrorInSendPordToAccLinkNotFoundIteminAcc, CS_0024_003C_003E8__locals1.pord.pordNumber, Labels.TarazSamaneh, Labels.pordDefPrdPriceGroupId, wSspSelectProductPriceGroupWithAccLinkField_Result.ProductPriceGroupName ?? "") + "|";
					}
					long.TryParse(linkAccPrdPriceGroupIdStr, out result6);
					if (!CS_0024_003C_003E8__locals1.pord.pordDefWHId.HasValue)
					{
						return string.Format(Messages.msgErrorInSendPordToAccLinkNotSelectedItem, CS_0024_003C_003E8__locals1.pord.pordNumber, Labels.TarazSamaneh, Labels.pordDefWHId) + "|";
					}
					WSspSelectWareHouseWithAccLinkField_Result wSspSelectWareHouseWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)list2, (Func<WSspSelectWareHouseWithAccLinkField_Result, bool>)((WSspSelectWareHouseWithAccLinkField_Result m) => m.WareHouseID == CS_0024_003C_003E8__locals1.pord.pordDefWHId));
					if (wSspSelectWareHouseWithAccLinkField_Result == null)
					{
						return string.Format(Messages.msgErrorInSendPordToAccLinkNotFoundIteminAcc, CS_0024_003C_003E8__locals1.pord.pordNumber, Labels.TarazSamaneh, Labels.pordDefWHId, CS_0024_003C_003E8__locals1.pord.pordDefWH ?? "") + "|";
					}
					string wrhsLinkAccWhIdStr = wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhIdStr;
					if (string.IsNullOrEmpty(wrhsLinkAccWhIdStr))
					{
						return string.Format(Messages.msgErrorInSendPordToAccLinkNotFoundIteminAcc, CS_0024_003C_003E8__locals1.pord.pordNumber, Labels.TarazSamaneh, Labels.pordDefWHId, wSspSelectWareHouseWithAccLinkField_Result.WrhsName ?? "") + "|";
					}
					long.TryParse(wrhsLinkAccWhIdStr, out result7);
					if (!CS_0024_003C_003E8__locals1.pord.pordTypeId.HasValue)
					{
						return string.Format(Messages.msgErrorInSendPordToAccLinkNotSelectedItem, CS_0024_003C_003E8__locals1.pord.pordNumber, Labels.TarazSamaneh, Labels.pordTypeId) + "|";
					}
					WSspSelectPreOrderTypesWithAccLinkField_Result wSspSelectPreOrderTypesWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectPreOrderTypesWithAccLinkField_Result>((IEnumerable<WSspSelectPreOrderTypesWithAccLinkField_Result>)list6, (Func<WSspSelectPreOrderTypesWithAccLinkField_Result, bool>)((WSspSelectPreOrderTypesWithAccLinkField_Result m) => m.PreOrderTypeId == CS_0024_003C_003E8__locals1.pord.pordTypeId));
					if (wSspSelectPreOrderTypesWithAccLinkField_Result == null)
					{
						return string.Format(Messages.msgErrorInSendPordToAccLinkNotFoundIteminAcc, CS_0024_003C_003E8__locals1.pord.pordNumber, Labels.TarazSamaneh, Labels.pordTypeId, CS_0024_003C_003E8__locals1.pord.pordType ?? "") + "|";
					}
					string linkAccPreOrderTypeIdStr = wSspSelectPreOrderTypesWithAccLinkField_Result.LinkAccPreOrderTypeIdStr;
					if (string.IsNullOrEmpty(linkAccPreOrderTypeIdStr))
					{
						return string.Format(Messages.msgErrorInSendPordToAccLinkNotFoundIteminAcc, CS_0024_003C_003E8__locals1.pord.pordNumber, Labels.TarazSamaneh, Labels.pordTypeId, wSspSelectPreOrderTypesWithAccLinkField_Result.PreOrderType ?? "") + "|";
					}
					long.TryParse(linkAccPreOrderTypeIdStr, out result2);
					if (!CS_0024_003C_003E8__locals1.pord.pordDeliveryTermId.HasValue)
					{
						return string.Format(Messages.msgErrorInSendPordToAccLinkNotSelectedItem, CS_0024_003C_003E8__locals1.pord.pordNumber, Labels.TarazSamaneh, Labels.pordDeliveryTermId) + "|";
					}
					WSspSelectDeliveryTermWithAccLinkField_Result wSspSelectDeliveryTermWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectDeliveryTermWithAccLinkField_Result>((IEnumerable<WSspSelectDeliveryTermWithAccLinkField_Result>)list7, (Func<WSspSelectDeliveryTermWithAccLinkField_Result, bool>)((WSspSelectDeliveryTermWithAccLinkField_Result m) => m.DeliveryTermId == CS_0024_003C_003E8__locals1.pord.pordDeliveryTermId));
					if (wSspSelectDeliveryTermWithAccLinkField_Result == null)
					{
						return string.Format(Messages.msgErrorInSendPordToAccLinkNotFoundIteminAcc, CS_0024_003C_003E8__locals1.pord.pordNumber, Labels.TarazSamaneh, Labels.pordDeliveryTermId, CS_0024_003C_003E8__locals1.pord.pordDeliveryTerm ?? "") + "|";
					}
					string linkAccDeliveryTermIdStr = wSspSelectDeliveryTermWithAccLinkField_Result.LinkAccDeliveryTermIdStr;
					if (string.IsNullOrEmpty(linkAccDeliveryTermIdStr))
					{
						return string.Format(Messages.msgErrorInSendPordToAccLinkNotFoundIteminAcc, CS_0024_003C_003E8__locals1.pord.pordNumber, Labels.TarazSamaneh, Labels.pordDeliveryTermId, wSspSelectDeliveryTermWithAccLinkField_Result.DeliveryTerm ?? "") + "|";
					}
					long.TryParse(linkAccDeliveryTermIdStr, out result4);
					if (!CS_0024_003C_003E8__locals1.pord.pordSaleCenterId.HasValue)
					{
						return string.Format(Messages.msgErrorInSendPordToAccLinkNotSelectedItem, CS_0024_003C_003E8__locals1.pord.pordNumber, Labels.TarazSamaneh, Labels.pordSaleCenterId) + "|";
					}
					WSspSelectSaleCenterWithAccLinkField_Result wSspSelectSaleCenterWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectSaleCenterWithAccLinkField_Result>((IEnumerable<WSspSelectSaleCenterWithAccLinkField_Result>)list8, (Func<WSspSelectSaleCenterWithAccLinkField_Result, bool>)((WSspSelectSaleCenterWithAccLinkField_Result m) => m.SaleCenterId == CS_0024_003C_003E8__locals1.pord.pordSaleCenterId));
					if (wSspSelectSaleCenterWithAccLinkField_Result == null)
					{
						return string.Format(Messages.msgErrorInSendPordToAccLinkNotFoundIteminAcc, CS_0024_003C_003E8__locals1.pord.pordNumber, Labels.TarazSamaneh, Labels.pordSaleCenterId, CS_0024_003C_003E8__locals1.pord.pordSaleCenter ?? "") + "|";
					}
					string linkAccSaleCenterIdStr = wSspSelectSaleCenterWithAccLinkField_Result.LinkAccSaleCenterIdStr;
					if (string.IsNullOrEmpty(linkAccSaleCenterIdStr))
					{
						return string.Format(Messages.msgErrorInSendPordToAccLinkNotFoundIteminAcc, CS_0024_003C_003E8__locals1.pord.pordNumber, Labels.TarazSamaneh, Labels.pordSaleCenterId, wSspSelectSaleCenterWithAccLinkField_Result.SaleCenterName ?? "") + "|";
					}
					long.TryParse(linkAccSaleCenterIdStr, out result3);
					if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals1.pord.pordSpecialWord))
					{
						result9 = 0;
						CS_0024_003C_003E8__locals1.pord.pordSpecialWord = CS_0024_003C_003E8__locals1.pord.pordSpecialWord.Trim();
						bool flag = true;
						for (int i = 0; i < CS_0024_003C_003E8__locals1.pord.pordSpecialWord.Length; i++)
						{
							if (!char.IsDigit(CS_0024_003C_003E8__locals1.pord.pordSpecialWord[i]))
							{
								flag = false;
							}
						}
						if (flag)
						{
							int.TryParse(CS_0024_003C_003E8__locals1.pord.pordSpecialWord, out result9);
						}
					}
					List<WSspSelectPreOrderItems_Result> list10 = Enumerable.ToList<WSspSelectPreOrderItems_Result>((IEnumerable<WSspSelectPreOrderItems_Result>)_db.WSspSelectPreOrderItems(pordId, lCID, result10));
					if (list10 != null && Enumerable.Any<WSspSelectPreOrderItems_Result>((IEnumerable<WSspSelectPreOrderItems_Result>)list10))
					{
						foreach (WSspSelectPreOrderItems_Result item3 in list10)
						{
							WSspSelectProductWithAccLinkField_Result wSspSelectProductWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectProductWithAccLinkField_Result>((IEnumerable<WSspSelectProductWithAccLinkField_Result>)list, (Func<WSspSelectProductWithAccLinkField_Result, bool>)((WSspSelectProductWithAccLinkField_Result m) => m.ProductID == item3.pordIPrdId));
							if (wSspSelectProductWithAccLinkField_Result != null)
							{
								if (string.IsNullOrEmpty(wSspSelectProductWithAccLinkField_Result.PrdLinkAccPrdIdStr))
								{
									result = string.Format(Messages.msgErrorInSendPordToAccLinkNotFoundPrdInAcc, CS_0024_003C_003E8__locals1.pord.pordNumber, Labels.TarazSamaneh, wSspSelectProductWithAccLinkField_Result.PrdName ?? "") + "|";
									return result;
								}
								if (item3.pordIWHId.HasValue)
								{
									WSspSelectWareHouseWithAccLinkField_Result wSspSelectWareHouseWithAccLinkField_Result2 = Enumerable.FirstOrDefault<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)list2, (Func<WSspSelectWareHouseWithAccLinkField_Result, bool>)((WSspSelectWareHouseWithAccLinkField_Result m) => m.WareHouseID == item3.pordIWHId));
									if (wSspSelectWareHouseWithAccLinkField_Result2 == null)
									{
										result = string.Format(Messages.msgErrorInSendPordToAccLinkNotFoundWhInAcc, CS_0024_003C_003E8__locals1.pord.pordNumber, Labels.TarazSamaneh, item3.pordIWrhsName ?? "") + "|";
										return result;
									}
									if (string.IsNullOrEmpty(wSspSelectWareHouseWithAccLinkField_Result2.WrhsLinkAccWhIdStr))
									{
										result = string.Format(Messages.msgErrorInSendPordToAccLinkNotFoundWhInAcc, CS_0024_003C_003E8__locals1.pord.pordNumber, Labels.TarazSamaneh, wSspSelectWareHouseWithAccLinkField_Result2.WrhsName ?? "") + "|";
										return result;
									}
								}
								if (item3.pordIPrdUnitId.HasValue)
								{
									WSspSelectProductUnitWithAccLinkField_Result wSspSelectProductUnitWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectProductUnitWithAccLinkField_Result>((IEnumerable<WSspSelectProductUnitWithAccLinkField_Result>)list3, (Func<WSspSelectProductUnitWithAccLinkField_Result, bool>)((WSspSelectProductUnitWithAccLinkField_Result m) => m.ProductUnitID == item3.pordIPrdUnitId));
									if (wSspSelectProductUnitWithAccLinkField_Result == null)
									{
										result = string.Format(Messages.msgErrorInSendPordToAccLinkNotFoundPrdUnitInAcc, CS_0024_003C_003E8__locals1.pord.pordNumber, Labels.TarazSamaneh, item3.pordIPrdUnit ?? "") + "|";
										return result;
									}
									if (string.IsNullOrEmpty(wSspSelectProductUnitWithAccLinkField_Result.UnitLinkAccUnitIdStr))
									{
										result = string.Format(Messages.msgErrorInSendPordToAccLinkNotFoundPrdUnitInAcc, CS_0024_003C_003E8__locals1.pord.pordNumber, Labels.TarazSamaneh, wSspSelectProductUnitWithAccLinkField_Result.Unit ?? "") + "|";
										return result;
									}
								}
								continue;
							}
							result = string.Format(Messages.msgErrorInSendPordToAccLinkNotFoundPrdInAcc, CS_0024_003C_003E8__locals1.pord.pordNumber, Labels.TarazSamaneh, item3.PrdName ?? "") + "|";
							return result;
						}
					}
					string text2 = "";
					CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(CS_0024_003C_003E8__locals1.pord.pordCompanyId.GetValueOrDefault());
					if (companyById == null)
					{
						return Messages.CompanyNotFound + "|";
					}
					text2 = companyById.cmpLinkAccCustomerIdStr ?? "";
					if (string.IsNullOrEmpty(text2))
					{
						string text3 = new CompanyController().TarazCmpSendToAcc(CS_0024_003C_003E8__locals1.pord.pordCompanyId.GetValueOrDefault());
						if (string.IsNullOrEmpty(text3))
						{
							return Messages.msgErrorRunFunction + "|";
						}
						string[] array = text3.Split(new char[1] { '|' });
						if (array != null)
						{
							if (!(array[0] == "1"))
							{
								return array[0] + "|";
							}
							companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(CS_0024_003C_003E8__locals1.pord.pordCompanyId.GetValueOrDefault());
							if (companyById == null)
							{
								return Messages.CompanyNotFound + "|";
							}
							text2 = companyById.cmpLinkAccCustomerIdStr ?? "";
						}
					}
					if (string.IsNullOrEmpty(text2))
					{
						return string.Format(Messages.msgErrorInSendToAccLinkNotFoundCmpInAcc, Labels.TarazSamaneh);
					}
					DateTime dateTime = default(DateTime);
					string voucherDate = "";
					string vocherTime = "";
					try
					{
						if (CS_0024_003C_003E8__locals1.pord.pordDateTime.HasValue)
						{
							voucherDate = (CS_0024_003C_003E8__locals1.pord.pordDateTime.HasValue ? CS_0024_003C_003E8__locals1.pord.pordDateTime.Value.ToString("yyyy/MM/dd", new PersianCulture()) : "");
							vocherTime = (CS_0024_003C_003E8__locals1.pord.pordDateTime.HasValue ? CS_0024_003C_003E8__locals1.pord.pordDateTime.Value.ToString("HH:mm:ss") : "");
						}
						else if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals1.pord.pordDate))
						{
							dateTime = DateTime.Parse(PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals1.pord.pordDate.Replace("/", "")) + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
							voucherDate = dateTime.ToString("yyyy/MM/dd", new PersianCulture());
							vocherTime = dateTime.ToString("HH:mm:ss");
						}
					}
					catch (Exception e2)
					{
						ErrorSignal.FromCurrentContext().Raise(e2);
						return Messages.WrongOrdDateTime;
					}
					int result12 = 0;
					List<CRMspSelectLinkAccTarazSetting_Result> list11 = Enumerable.ToList<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)_dbLink.CRMspSelectLinkAccTarazSetting(0, "VoucherType", lCID, result10));
					if (list11 != null)
					{
						string text4 = "";
						CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list11, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 8));
						if (cRMspSelectLinkAccTarazSetting_Result2 != null)
						{
							text4 = cRMspSelectLinkAccTarazSetting_Result2.PartValue ?? "";
						}
						if (!string.IsNullOrEmpty(text4))
						{
							int.TryParse(text4, out result12);
						}
					}
					else
					{
						Exception e3 = new Exception(Messages.errorInReadingSetting + " (tarazSamaneh) ");
						ErrorSignal.FromCurrentContext().Raise(e3);
					}
					if (result12 == 0)
					{
						return Messages.errorInReadingSetting + " (tarazSamaneh) |";
					}
					TarazSaleVoucherIEViewModel tarazSaleVoucherIEViewModel = new TarazSaleVoucherIEViewModel();
					tarazSaleVoucherIEViewModel.header = new TarazSaleVoucherHeaderViewModel();
					tarazSaleVoucherIEViewModel.other = new TarazSaleVoucherOrderViewModel();
					tarazSaleVoucherIEViewModel.details = new List<TarazSaleVoucherDetailViewModel>();
					tarazSaleVoucherIEViewModel.promotions = new List<TarazSaleVoucherPromotionViewModel>();
					tarazSaleVoucherIEViewModel.elements = new List<TarazSaleVoucherElementViewModel>();
					TarazSaleComputePromotionViewModel tarazSaleComputePromotionViewModel = new TarazSaleComputePromotionViewModel();
					tarazSaleComputePromotionViewModel.header = new TarazSaleComputePromotionHeaderViewModel();
					tarazSaleComputePromotionViewModel.details = new List<TarazSaleComputePromotionDetailViewModel>();
					long? num = null;
					if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals1.pord.pordLinkAccPreOrderIdStr))
					{
						num = long.Parse(CS_0024_003C_003E8__locals1.pord.pordLinkAccPreOrderIdStr);
					}
					tarazSaleVoucherIEViewModel.header = new TarazSaleVoucherHeaderViewModel
					{
						saleCenterID = result3,
						deliverCenterID = result4,
						paymentWayID = result6,
						voucherDesc = CS_0024_003C_003E8__locals1.pord.pordDescriptionI + "\r\n" + CS_0024_003C_003E8__locals1.pord.pordDescriptionII,
						saleTypeID = result2,
						voucherDate = voucherDate,
						vocherTime = vocherTime,
						voucherDateG = CS_0024_003C_003E8__locals1.pord.pordDateTime,
						voucherHeaderID = num,
						marketingManID = result5,
						voucherTypeID = result12,
						customerID = long.Parse(text2),
						storeID = result7,
						salesManID = ((result8 != 0L) ? new long?(result8) : null),
						dayCount = result9
					};
					tarazSaleComputePromotionViewModel.header = new TarazSaleComputePromotionHeaderViewModel
					{
						saleCenterID = result3,
						deliverCenterID = result4,
						voucherTypeID = result12,
						perComID = long.Parse(text2),
						customerID = long.Parse(text2),
						storeID = result7
					};
					if (list10 != null && Enumerable.Any<WSspSelectPreOrderItems_Result>((IEnumerable<WSspSelectPreOrderItems_Result>)list10))
					{
						foreach (WSspSelectPreOrderItems_Result item2 in list10)
						{
							TarazSaleVoucherDetailViewModel tarazSaleVoucherDetailViewModel = new TarazSaleVoucherDetailViewModel();
							TarazSaleComputePromotionDetailViewModel tarazSaleComputePromotionDetailViewModel = new TarazSaleComputePromotionDetailViewModel();
							string text5 = "";
							string s = "";
							string text6 = "";
							WSspSelectProductWithAccLinkField_Result wSspSelectProductWithAccLinkField_Result2 = Enumerable.FirstOrDefault<WSspSelectProductWithAccLinkField_Result>((IEnumerable<WSspSelectProductWithAccLinkField_Result>)list, (Func<WSspSelectProductWithAccLinkField_Result, bool>)((WSspSelectProductWithAccLinkField_Result m) => m.ProductID == item2.pordIPrdId));
							if (wSspSelectProductWithAccLinkField_Result2 != null)
							{
								text5 = wSspSelectProductWithAccLinkField_Result2.PrdLinkAccPrdIdStr;
							}
							if (item2.pordIWHId.HasValue)
							{
								WSspSelectWareHouseWithAccLinkField_Result wSspSelectWareHouseWithAccLinkField_Result3 = Enumerable.FirstOrDefault<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)list2, (Func<WSspSelectWareHouseWithAccLinkField_Result, bool>)((WSspSelectWareHouseWithAccLinkField_Result m) => m.WareHouseID == item2.pordIWHId));
								if (wSspSelectWareHouseWithAccLinkField_Result3 != null)
								{
									s = wSspSelectWareHouseWithAccLinkField_Result3.WrhsLinkAccWhIdStr;
								}
							}
							if (item2.pordIPrdUnitId.HasValue)
							{
								WSspSelectProductUnitWithAccLinkField_Result wSspSelectProductUnitWithAccLinkField_Result2 = Enumerable.FirstOrDefault<WSspSelectProductUnitWithAccLinkField_Result>((IEnumerable<WSspSelectProductUnitWithAccLinkField_Result>)list3, (Func<WSspSelectProductUnitWithAccLinkField_Result, bool>)((WSspSelectProductUnitWithAccLinkField_Result m) => m.ProductUnitID == item2.pordIPrdUnitId));
								if (wSspSelectProductUnitWithAccLinkField_Result2 != null)
								{
									text6 = wSspSelectProductUnitWithAccLinkField_Result2.UnitLinkAccUnitIdStr;
								}
							}
							if (!string.IsNullOrEmpty(text5))
							{
								tarazSaleVoucherDetailViewModel.goodsID = long.Parse(text5);
								tarazSaleVoucherDetailViewModel.secUnitID = long.Parse(text6);
								tarazSaleVoucherDetailViewModel.storeID = long.Parse(s);
								tarazSaleVoucherDetailViewModel.quantity = item2.pordIQuantity.GetValueOrDefault(1.0);
								tarazSaleVoucherDetailViewModel.crmFcr = item2.pordIFCR.GetValueOrDefault(1.0) * item2.pordIFCRI.GetValueOrDefault(1.0);
								tarazSaleVoucherDetailViewModel.fee = item2.pordIPrice.GetValueOrDefault();
								tarazSaleVoucherDetailViewModel.detailXDesc = item2.pordIDescription ?? "";
								tarazSaleVoucherDetailViewModel.feeDiscountPrice = item2.pordIDiscount;
								tarazSaleVoucherDetailViewModel.feeDiscountPercent = item2.pordIDiscountPercent;
								if (tarazSaleVoucherDetailViewModel.feeDiscountPrice.HasValue)
								{
									tarazSaleVoucherDetailViewModel.feeAgreement = tarazSaleVoucherDetailViewModel.fee.GetValueOrDefault() - tarazSaleVoucherDetailViewModel.feeDiscountPrice.GetValueOrDefault();
								}
								else
								{
									tarazSaleVoucherDetailViewModel.feeAgreement = tarazSaleVoucherDetailViewModel.fee.GetValueOrDefault();
								}
								long? voucherDetailID = null;
								if (!string.IsNullOrEmpty(item2.pordILinkAccItemIdStr))
								{
									voucherDetailID = long.Parse(item2.pordILinkAccItemIdStr);
								}
								tarazSaleVoucherDetailViewModel.voucherDetailID = voucherDetailID;
								tarazSaleComputePromotionDetailViewModel.goodsID = long.Parse(text5);
								if (!string.IsNullOrEmpty(text6))
								{
									tarazSaleComputePromotionDetailViewModel.secUnitID = long.Parse(text6);
								}
								tarazSaleComputePromotionDetailViewModel.quantity = item2.pordIQuantity;
								tarazSaleComputePromotionDetailViewModel.fee = item2.pordIPrice.GetValueOrDefault();
								tarazSaleComputePromotionDetailViewModel.detailXDesc = item2.pordIDescription ?? "";
								tarazSaleVoucherIEViewModel.details.Add(tarazSaleVoucherDetailViewModel);
								tarazSaleComputePromotionViewModel.details.Add(tarazSaleComputePromotionDetailViewModel);
								continue;
							}
							result = Messages.msgErrorRunFunction;
							return result;
						}
					}
					new List<TarazSaleTypesViewModel>();
					List<CRMspSelectLinkAccTarazSetting_Result> list12 = Enumerable.ToList<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)_dbLink.CRMspSelectLinkAccTarazSetting(0, "Setting", lCID, result10));
					if (list12 != null)
					{
						string text7 = "";
						CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result3 = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list12, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 1));
						if (cRMspSelectLinkAccTarazSetting_Result3 != null)
						{
							text7 = cRMspSelectLinkAccTarazSetting_Result3.PartValue ?? "";
						}
						string text8 = "";
						string text9 = "";
						CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result4 = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list12, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 2));
						if (cRMspSelectLinkAccTarazSetting_Result4 != null)
						{
							text9 = cRMspSelectLinkAccTarazSetting_Result4.PartValue ?? "";
						}
						string text10 = "";
						CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result5 = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list12, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 3));
						if (cRMspSelectLinkAccTarazSetting_Result5 != null)
						{
							text10 = cRMspSelectLinkAccTarazSetting_Result5.PartValue ?? "";
						}
						CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result6 = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list12, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 6));
						if (cRMspSelectLinkAccTarazSetting_Result6 != null)
						{
							text8 = cRMspSelectLinkAccTarazSetting_Result6.PartValue ?? "";
						}
						if (!string.IsNullOrWhiteSpace(text7) && !string.IsNullOrWhiteSpace(text9) && !string.IsNullOrWhiteSpace(text10))
						{
							if (!text7.EndsWith("/"))
							{
								text7 += "/";
							}
							if (string.IsNullOrWhiteSpace(text8))
							{
								TarazGetAuthViewModel tarazGetAuthViewModel = new TarazGetAuthViewModel();
								tarazGetAuthViewModel.username = text9;
								tarazGetAuthViewModel.password = text10;
								string text11 = "tws/authenticate";
								HttpResponseMessage result13 = new HttpClient
								{
									BaseAddress = new Uri(text7 + text11),
									DefaultRequestHeaders = 
									{
										Accept = 
										{
											new MediaTypeWithQualityHeaderValue("application/json")
										}
									}
								}.PostAsync(content: new StringContent(JsonConvert.SerializeObject(tarazGetAuthViewModel), Encoding.UTF8, "application/json"), requestUri: text7 + text11).Result;
								if (!result13.IsSuccessStatusCode)
								{
									string text12 = Messages.msgErrorRunFunction + " (authentication in tarazSamaneh) ";
									TarazExceptionViewModel tarazExceptionViewModel = JsonConvert.DeserializeObject<TarazExceptionViewModel>(result13.Content.ReadAsStringAsync().Result);
									if (tarazExceptionViewModel != null)
									{
										string[] obj = new string[6]
										{
											text12,
											" [",
											tarazExceptionViewModel.error,
											(!string.IsNullOrEmpty(tarazExceptionViewModel.message)) ? (" -" + tarazExceptionViewModel.message) : "",
											null,
											null
										};
										_ = tarazExceptionViewModel.status;
										obj[4] = " code:" + tarazExceptionViewModel.status;
										obj[5] = "]";
										text12 = string.Concat(obj);
									}
									Exception ex = new Exception(text12);
									ErrorSignal.FromCurrentContext().Raise(ex);
									return ex.Message;
								}
								TarazGetAuthResultViewModel tarazGetAuthResultViewModel = JsonConvert.DeserializeObject<TarazGetAuthResultViewModel>(result13.Content.ReadAsStringAsync().Result);
								if (string.IsNullOrWhiteSpace(tarazGetAuthResultViewModel.token))
								{
									Exception ex2 = new Exception(Messages.msgErrorRunFunction + "  (authentication in tarazSamaneh) ");
									ErrorSignal.FromCurrentContext().Raise(ex2);
									return ex2.Message;
								}
								text8 = ((!string.IsNullOrEmpty(tarazGetAuthResultViewModel.type)) ? (tarazGetAuthResultViewModel.type + " ") : "Bearer ") + tarazGetAuthResultViewModel.token;
								DbSet<CrmLinkAccTarazSetting> crmLinkAccTarazSetting = _dbTbl.CrmLinkAccTarazSetting;
								ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccTarazSetting), "m");
								CrmLinkAccTarazSetting crmLinkAccTarazSetting2 = Queryable.FirstOrDefault<CrmLinkAccTarazSetting>((IQueryable<CrmLinkAccTarazSetting>)crmLinkAccTarazSetting, Expression.Lambda<Func<CrmLinkAccTarazSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)6, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
								if (crmLinkAccTarazSetting2 != null)
								{
									crmLinkAccTarazSetting2.PartValue = text8;
									_dbTbl.Entry(crmLinkAccTarazSetting2).State = EntityState.Modified;
									_dbTbl.Configuration.ValidateOnSaveEnabled = false;
									_dbTbl.SaveChanges();
									_dbTbl.Configuration.ValidateOnSaveEnabled = true;
								}
							}
							if (string.IsNullOrWhiteSpace(text8))
							{
								Exception ex3 = new Exception(Messages.msgErrorRunFunction + " (authentication in tarazSamaneh) ");
								ErrorSignal.FromCurrentContext().Raise(ex3);
								return ex3.Message;
							}
							if (!string.IsNullOrWhiteSpace(text8))
							{
								HttpClient httpClient = new HttpClient();
								httpClient.BaseAddress = new Uri(text7);
								httpClient.DefaultRequestHeaders.Add("Authorization", text8);
								httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
								string text13 = "";
								HttpStatusCode statusCode;
								ParameterExpression val;
								if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals1.pord.pordLinkAccPreOrderIdStr))
								{
									text13 = "tws/sale/vouchers/headers/" + CS_0024_003C_003E8__locals1.pord.pordLinkAccPreOrderIdStr;
									HttpResponseMessage result14 = httpClient.GetAsync(text13).Result;
									if (!result14.IsSuccessStatusCode)
									{
										statusCode = result14.StatusCode;
										if (((object)(HttpStatusCode)(ref statusCode)).ToString() == "Unauthorized")
										{
											DbSet<CrmLinkAccTarazSetting> crmLinkAccTarazSetting3 = _dbTbl.CrmLinkAccTarazSetting;
											val = Expression.Parameter(typeof(CrmLinkAccTarazSetting), "m");
											CrmLinkAccTarazSetting crmLinkAccTarazSetting4 = Queryable.FirstOrDefault<CrmLinkAccTarazSetting>((IQueryable<CrmLinkAccTarazSetting>)crmLinkAccTarazSetting3, Expression.Lambda<Func<CrmLinkAccTarazSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)6, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
											if (crmLinkAccTarazSetting4 != null)
											{
												crmLinkAccTarazSetting4.PartValue = "";
												_dbTbl.Entry(crmLinkAccTarazSetting4).State = EntityState.Modified;
												_dbTbl.Configuration.ValidateOnSaveEnabled = false;
												_dbTbl.SaveChanges();
												_dbTbl.Configuration.ValidateOnSaveEnabled = true;
											}
											result = Messages.msgErrorRunFunction + " (Get voucher header in tarazSamaneh) |";
										}
										else
										{
											TarazExceptionViewModel tarazExceptionViewModel2 = JsonConvert.DeserializeObject<TarazExceptionViewModel>(result14.Content.ReadAsStringAsync().Result);
											if (tarazExceptionViewModel2 != null)
											{
												_ = tarazExceptionViewModel2.status;
												if (tarazExceptionViewModel2.status == 401)
												{
													DbSet<CrmLinkAccTarazSetting> crmLinkAccTarazSetting5 = _dbTbl.CrmLinkAccTarazSetting;
													val = Expression.Parameter(typeof(CrmLinkAccTarazSetting), "m");
													CrmLinkAccTarazSetting crmLinkAccTarazSetting6 = Queryable.FirstOrDefault<CrmLinkAccTarazSetting>((IQueryable<CrmLinkAccTarazSetting>)crmLinkAccTarazSetting5, Expression.Lambda<Func<CrmLinkAccTarazSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)6, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
													if (crmLinkAccTarazSetting6 != null)
													{
														crmLinkAccTarazSetting6.PartValue = "";
														_dbTbl.Entry(crmLinkAccTarazSetting6).State = EntityState.Modified;
														_dbTbl.Configuration.ValidateOnSaveEnabled = false;
														_dbTbl.SaveChanges();
														_dbTbl.Configuration.ValidateOnSaveEnabled = true;
													}
												}
												string[] obj2 = new string[6]
												{
													Messages.msgErrorRunFunction,
													" (Get voucher header in tarazSamaneh)  [",
													tarazExceptionViewModel2.error,
													(!string.IsNullOrEmpty(tarazExceptionViewModel2.message)) ? (" -" + tarazExceptionViewModel2.message) : "",
													null,
													null
												};
												_ = tarazExceptionViewModel2.status;
												obj2[4] = " code:" + tarazExceptionViewModel2.status;
												obj2[5] = "]|";
												result = string.Concat(obj2);
											}
										}
										return result;
									}
									if (JsonConvert.DeserializeObject<TarazGetSaleVoucherHeaderResultViewModel>(result14.Content.ReadAsStringAsync().Result) != null)
									{
										return string.Format(Messages.msgErrorNotReSendPordToOtherSystem, CS_0024_003C_003E8__locals1.pord.pordNumber.ToString(), Labels.TarazSamaneh) + "|";
									}
									num = null;
									tarazSaleVoucherIEViewModel.header.voucherHeaderID = null;
									DbSet<WSPreOrder> wSPreOrder = _dbTbl.WSPreOrder;
									val = Expression.Parameter(typeof(WSPreOrder), "c");
									WSPreOrder wSPreOrder2 = Queryable.FirstOrDefault<WSPreOrder>((IQueryable<WSPreOrder>)wSPreOrder, Expression.Lambda<Func<WSPreOrder, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass73_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
									if (wSPreOrder2 == null)
									{
										return Messages.ErrorNotFound + "|";
									}
									wSPreOrder2.pordLinkAccPreOrderNumber = null;
									wSPreOrder2.pordLinkAccPreOrderIdStr = null;
									_dbTbl.Entry(wSPreOrder2).State = EntityState.Modified;
									_dbTbl.Configuration.ValidateOnSaveEnabled = false;
									_dbTbl.SaveChanges();
									_dbTbl.Configuration.ValidateOnSaveEnabled = true;
									if (list10 != null)
									{
										using List<WSspSelectPreOrderItems_Result>.Enumerator enumerator = list10.GetEnumerator();
										while (enumerator.MoveNext())
										{
											_003C_003Ec__DisplayClass73_3 _003C_003Ec__DisplayClass73_ = new _003C_003Ec__DisplayClass73_3();
											_003C_003Ec__DisplayClass73_.odItem = enumerator.Current;
											DbSet<WSPreOrderItems> wSPreOrderItems = _dbTbl.WSPreOrderItems;
											val = Expression.Parameter(typeof(WSPreOrderItems), "m");
											WSPreOrderItems wSPreOrderItems2 = Queryable.FirstOrDefault<WSPreOrderItems>((IQueryable<WSPreOrderItems>)wSPreOrderItems, Expression.Lambda<Func<WSPreOrderItems, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass73_, typeof(_003C_003Ec__DisplayClass73_3)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
											if (wSPreOrderItems2 != null)
											{
												wSPreOrderItems2.pordILinkAccItemIdStr = null;
												_dbTbl.Entry(wSPreOrderItems2).State = EntityState.Modified;
												_dbTbl.Configuration.ValidateOnSaveEnabled = false;
												_dbTbl.SaveChanges();
												_dbTbl.Configuration.ValidateOnSaveEnabled = true;
											}
										}
									}
								}
								if (tarazSaleVoucherIEViewModel.details != null)
								{
									foreach (TarazSaleVoucherDetailViewModel item in tarazSaleVoucherIEViewModel.details)
									{
										if (!item.secUnitID.HasValue)
										{
											continue;
										}
										text13 = "";
										text13 = "tws/inv/goods/" + item.goodsID + "/goodsunits";
										HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
										httpResponseMessage = httpClient.GetAsync(text13).Result;
										if (httpResponseMessage.IsSuccessStatusCode)
										{
											List<TarazGoodsUnitsForVoucherViewModel> list13 = JsonConvert.DeserializeObject<List<TarazGoodsUnitsForVoucherViewModel>>(httpResponseMessage.Content.ReadAsStringAsync().Result);
											if (list13 == null)
											{
												continue;
											}
											double computeValue = 0.0;
											computeValue = item.crmFcr.GetValueOrDefault();
											TarazGoodsUnitsForVoucherViewModel tarazGoodsUnitsForVoucherViewModel = Enumerable.FirstOrDefault<TarazGoodsUnitsForVoucherViewModel>((IEnumerable<TarazGoodsUnitsForVoucherViewModel>)list13, (Func<TarazGoodsUnitsForVoucherViewModel, bool>)((TarazGoodsUnitsForVoucherViewModel m) => m.unitID == item.secUnitID && m.computeValue.GetValueOrDefault() == computeValue));
											if (tarazGoodsUnitsForVoucherViewModel == null || !tarazGoodsUnitsForVoucherViewModel.secUnitID.HasValue || tarazGoodsUnitsForVoucherViewModel.unitID.GetValueOrDefault() != item.secUnitID)
											{
												continue;
											}
											if (tarazSaleComputePromotionViewModel != null && tarazSaleComputePromotionViewModel.details != null && Enumerable.FirstOrDefault<TarazSaleComputePromotionDetailViewModel>((IEnumerable<TarazSaleComputePromotionDetailViewModel>)tarazSaleComputePromotionViewModel.details, (Func<TarazSaleComputePromotionDetailViewModel, bool>)((TarazSaleComputePromotionDetailViewModel m) => m.goodsID == item.goodsID && m.secUnitID == item.secUnitID)) != null)
											{
												Enumerable.FirstOrDefault<TarazSaleComputePromotionDetailViewModel>((IEnumerable<TarazSaleComputePromotionDetailViewModel>)tarazSaleComputePromotionViewModel.details, (Func<TarazSaleComputePromotionDetailViewModel, bool>)((TarazSaleComputePromotionDetailViewModel m) => m.goodsID == item.goodsID && m.secUnitID == item.secUnitID)).secUnitID = tarazGoodsUnitsForVoucherViewModel.secUnitID;
											}
											item.secUnitID = tarazGoodsUnitsForVoucherViewModel.secUnitID;
											continue;
										}
										statusCode = httpResponseMessage.StatusCode;
										if (((object)(HttpStatusCode)(ref statusCode)).ToString() == "Unauthorized")
										{
											DbSet<CrmLinkAccTarazSetting> crmLinkAccTarazSetting7 = _dbTbl.CrmLinkAccTarazSetting;
											val = Expression.Parameter(typeof(CrmLinkAccTarazSetting), "m");
											CrmLinkAccTarazSetting crmLinkAccTarazSetting8 = Queryable.FirstOrDefault<CrmLinkAccTarazSetting>((IQueryable<CrmLinkAccTarazSetting>)crmLinkAccTarazSetting7, Expression.Lambda<Func<CrmLinkAccTarazSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)6, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
											if (crmLinkAccTarazSetting8 != null)
											{
												crmLinkAccTarazSetting8.PartValue = "";
												_dbTbl.Entry(crmLinkAccTarazSetting8).State = EntityState.Modified;
												_dbTbl.Configuration.ValidateOnSaveEnabled = false;
												_dbTbl.SaveChanges();
												_dbTbl.Configuration.ValidateOnSaveEnabled = true;
											}
											result = Messages.msgErrorRunFunction + " (set secunitID from tarazSamaneh) |";
										}
										else
										{
											TarazExceptionViewModel tarazExceptionViewModel3 = JsonConvert.DeserializeObject<TarazExceptionViewModel>(httpResponseMessage.Content.ReadAsStringAsync().Result);
											if (tarazExceptionViewModel3 != null)
											{
												_ = tarazExceptionViewModel3.status;
												if (tarazExceptionViewModel3.status == 401)
												{
													DbSet<CrmLinkAccTarazSetting> crmLinkAccTarazSetting9 = _dbTbl.CrmLinkAccTarazSetting;
													val = Expression.Parameter(typeof(CrmLinkAccTarazSetting), "m");
													CrmLinkAccTarazSetting crmLinkAccTarazSetting10 = Queryable.FirstOrDefault<CrmLinkAccTarazSetting>((IQueryable<CrmLinkAccTarazSetting>)crmLinkAccTarazSetting9, Expression.Lambda<Func<CrmLinkAccTarazSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)6, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
													if (crmLinkAccTarazSetting10 != null)
													{
														crmLinkAccTarazSetting10.PartValue = "";
														_dbTbl.Entry(crmLinkAccTarazSetting10).State = EntityState.Modified;
														_dbTbl.Configuration.ValidateOnSaveEnabled = false;
														_dbTbl.SaveChanges();
														_dbTbl.Configuration.ValidateOnSaveEnabled = true;
													}
												}
												string[] obj3 = new string[6]
												{
													Messages.msgErrorRunFunction,
													" (set secunitID from tarazSamaneh)  [",
													tarazExceptionViewModel3.error,
													(!string.IsNullOrEmpty(tarazExceptionViewModel3.message)) ? (" -" + tarazExceptionViewModel3.message) : "",
													null,
													null
												};
												_ = tarazExceptionViewModel3.status;
												obj3[4] = " code:" + tarazExceptionViewModel3.status;
												obj3[5] = "]|";
												result = string.Concat(obj3);
											}
										}
										return result;
									}
								}
								text13 = "";
								if (!num.HasValue || num == 0)
								{
									text13 = "tws/sale/promotionelements";
									HttpContent content2 = new StringContent(JsonConvert.SerializeObject(tarazSaleComputePromotionViewModel), Encoding.UTF8, "application/json");
									HttpResponseMessage httpResponseMessage2 = new HttpResponseMessage();
									httpResponseMessage2 = httpClient.PostAsync(text13, content2).Result;
									if (!httpResponseMessage2.IsSuccessStatusCode)
									{
										statusCode = httpResponseMessage2.StatusCode;
										if (((object)(HttpStatusCode)(ref statusCode)).ToString() == "Unauthorized")
										{
											DbSet<CrmLinkAccTarazSetting> crmLinkAccTarazSetting11 = _dbTbl.CrmLinkAccTarazSetting;
											val = Expression.Parameter(typeof(CrmLinkAccTarazSetting), "m");
											CrmLinkAccTarazSetting crmLinkAccTarazSetting12 = Queryable.FirstOrDefault<CrmLinkAccTarazSetting>((IQueryable<CrmLinkAccTarazSetting>)crmLinkAccTarazSetting11, Expression.Lambda<Func<CrmLinkAccTarazSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)6, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
											if (crmLinkAccTarazSetting12 != null)
											{
												crmLinkAccTarazSetting12.PartValue = "";
												_dbTbl.Entry(crmLinkAccTarazSetting12).State = EntityState.Modified;
												_dbTbl.Configuration.ValidateOnSaveEnabled = false;
												_dbTbl.SaveChanges();
												_dbTbl.Configuration.ValidateOnSaveEnabled = true;
											}
											result = Messages.msgErrorRunFunction + " (sale compute promotion in tarazSamaneh) |";
										}
										else
										{
											TarazExceptionViewModel tarazExceptionViewModel4 = JsonConvert.DeserializeObject<TarazExceptionViewModel>(httpResponseMessage2.Content.ReadAsStringAsync().Result);
											if (tarazExceptionViewModel4 != null)
											{
												_ = tarazExceptionViewModel4.status;
												if (tarazExceptionViewModel4.status == 401)
												{
													DbSet<CrmLinkAccTarazSetting> crmLinkAccTarazSetting13 = _dbTbl.CrmLinkAccTarazSetting;
													val = Expression.Parameter(typeof(CrmLinkAccTarazSetting), "m");
													CrmLinkAccTarazSetting crmLinkAccTarazSetting14 = Queryable.FirstOrDefault<CrmLinkAccTarazSetting>((IQueryable<CrmLinkAccTarazSetting>)crmLinkAccTarazSetting13, Expression.Lambda<Func<CrmLinkAccTarazSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)6, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
													if (crmLinkAccTarazSetting14 != null)
													{
														crmLinkAccTarazSetting14.PartValue = "";
														_dbTbl.Entry(crmLinkAccTarazSetting14).State = EntityState.Modified;
														_dbTbl.Configuration.ValidateOnSaveEnabled = false;
														_dbTbl.SaveChanges();
														_dbTbl.Configuration.ValidateOnSaveEnabled = true;
													}
												}
												string[] obj4 = new string[6]
												{
													Messages.msgErrorRunFunction,
													" (sale compute promotion in tarazSamaneh)  [",
													tarazExceptionViewModel4.error,
													(!string.IsNullOrEmpty(tarazExceptionViewModel4.message)) ? (" -" + tarazExceptionViewModel4.message) : "",
													null,
													null
												};
												_ = tarazExceptionViewModel4.status;
												obj4[4] = " code:" + tarazExceptionViewModel4.status;
												obj4[5] = "]|";
												result = string.Concat(obj4);
											}
										}
										return result;
									}
									TarazSaleComputePromotionResultViewModel tarazSaleComputePromotionResultViewModel = JsonConvert.DeserializeObject<TarazSaleComputePromotionResultViewModel>(httpResponseMessage2.Content.ReadAsStringAsync().Result);
									if (tarazSaleComputePromotionResultViewModel != null)
									{
										if (tarazSaleComputePromotionResultViewModel.promotions != null && Enumerable.Any<TarazSaleComputePromotionsResultViewModel>((IEnumerable<TarazSaleComputePromotionsResultViewModel>)tarazSaleComputePromotionResultViewModel.promotions))
										{
											foreach (TarazSaleComputePromotionsResultViewModel promotion in tarazSaleComputePromotionResultViewModel.promotions)
											{
												TarazSaleVoucherPromotionViewModel tarazSaleVoucherPromotionViewModel = new TarazSaleVoucherPromotionViewModel();
												tarazSaleVoucherPromotionViewModel.goodsID = promotion.goodsID;
												tarazSaleVoucherPromotionViewModel.quantity = promotion.quantity;
												tarazSaleVoucherPromotionViewModel.goodsDesc = promotion.goodsDesc;
												tarazSaleVoucherPromotionViewModel.secUnitID = promotion.secUnitID;
												tarazSaleVoucherPromotionViewModel.unitDesc = promotion.unitDesc;
												tarazSaleVoucherIEViewModel.promotions.Add(tarazSaleVoucherPromotionViewModel);
											}
										}
										if (tarazSaleComputePromotionResultViewModel.elements != null && Enumerable.Any<TarazSaleComputePromotionElementsResultViewModel>((IEnumerable<TarazSaleComputePromotionElementsResultViewModel>)tarazSaleComputePromotionResultViewModel.elements))
										{
											foreach (TarazSaleComputePromotionElementsResultViewModel element in tarazSaleComputePromotionResultViewModel.elements)
											{
												TarazSaleVoucherElementViewModel tarazSaleVoucherElementViewModel = new TarazSaleVoucherElementViewModel();
												tarazSaleVoucherElementViewModel.goodsID = element.goodsID;
												tarazSaleVoucherElementViewModel.elementID = element.elementID;
												tarazSaleVoucherElementViewModel.elementDesc = element.elementDesc;
												tarazSaleVoucherElementViewModel.elementType = element.elementType;
												tarazSaleVoucherElementViewModel.elementMab = element.elementMab;
												tarazSaleVoucherIEViewModel.elements.Add(tarazSaleVoucherElementViewModel);
											}
										}
									}
								}
								text13 = "tws/sale/vouchers";
								HttpContent content3 = new StringContent(JsonConvert.SerializeObject(tarazSaleVoucherIEViewModel), Encoding.UTF8, "application/json");
								HttpResponseMessage httpResponseMessage3 = new HttpResponseMessage();
								httpResponseMessage3 = ((!tarazSaleVoucherIEViewModel.header.voucherHeaderID.HasValue) ? httpClient.PostAsync(text13, content3).Result : httpClient.PutAsync(text13, content3).Result);
								if (!httpResponseMessage3.IsSuccessStatusCode)
								{
									statusCode = httpResponseMessage3.StatusCode;
									if (((object)(HttpStatusCode)(ref statusCode)).ToString() == "Unauthorized")
									{
										DbSet<CrmLinkAccTarazSetting> crmLinkAccTarazSetting15 = _dbTbl.CrmLinkAccTarazSetting;
										val = Expression.Parameter(typeof(CrmLinkAccTarazSetting), "m");
										CrmLinkAccTarazSetting crmLinkAccTarazSetting16 = Queryable.FirstOrDefault<CrmLinkAccTarazSetting>((IQueryable<CrmLinkAccTarazSetting>)crmLinkAccTarazSetting15, Expression.Lambda<Func<CrmLinkAccTarazSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)6, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
										if (crmLinkAccTarazSetting16 != null)
										{
											crmLinkAccTarazSetting16.PartValue = "";
											_dbTbl.Entry(crmLinkAccTarazSetting16).State = EntityState.Modified;
											_dbTbl.Configuration.ValidateOnSaveEnabled = false;
											_dbTbl.SaveChanges();
											_dbTbl.Configuration.ValidateOnSaveEnabled = true;
										}
										result = Messages.msgErrorRunFunction + "|";
									}
									else
									{
										TarazExceptionViewModel tarazExceptionViewModel5 = JsonConvert.DeserializeObject<TarazExceptionViewModel>(httpResponseMessage3.Content.ReadAsStringAsync().Result);
										if (tarazExceptionViewModel5 != null)
										{
											_ = tarazExceptionViewModel5.status;
											if (tarazExceptionViewModel5.status == 401)
											{
												DbSet<CrmLinkAccTarazSetting> crmLinkAccTarazSetting17 = _dbTbl.CrmLinkAccTarazSetting;
												val = Expression.Parameter(typeof(CrmLinkAccTarazSetting), "m");
												CrmLinkAccTarazSetting crmLinkAccTarazSetting18 = Queryable.FirstOrDefault<CrmLinkAccTarazSetting>((IQueryable<CrmLinkAccTarazSetting>)crmLinkAccTarazSetting17, Expression.Lambda<Func<CrmLinkAccTarazSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)6, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
												if (crmLinkAccTarazSetting18 != null)
												{
													crmLinkAccTarazSetting18.PartValue = "";
													_dbTbl.Entry(crmLinkAccTarazSetting18).State = EntityState.Modified;
													_dbTbl.Configuration.ValidateOnSaveEnabled = false;
													_dbTbl.SaveChanges();
													_dbTbl.Configuration.ValidateOnSaveEnabled = true;
												}
											}
											string[] obj5 = new string[6]
											{
												Messages.msgErrorRunFunction,
												" [",
												tarazExceptionViewModel5.error,
												(!string.IsNullOrEmpty(tarazExceptionViewModel5.message)) ? (" -" + tarazExceptionViewModel5.message) : "",
												null,
												null
											};
											_ = tarazExceptionViewModel5.status;
											obj5[4] = " code:" + tarazExceptionViewModel5.status;
											obj5[5] = "]|";
											result = string.Concat(obj5);
										}
									}
									return result;
								}
								TarazSaleVoucherInsertResultViewModel tarazSaleVoucherInsertResultViewModel = JsonConvert.DeserializeObject<TarazSaleVoucherInsertResultViewModel>(httpResponseMessage3.Content.ReadAsStringAsync().Result);
								if (tarazSaleVoucherInsertResultViewModel == null)
								{
									return Messages.msgErrorRunFunction + "|";
								}
								if (tarazSaleVoucherInsertResultViewModel.header == null)
								{
									return string.Format(Messages.msgErrorOtherSystemsNotRegistered, Labels.OtherSystemsPreOrder, Labels.TarazSamaneh) + "|";
								}
								if (!tarazSaleVoucherIEViewModel.header.voucherHeaderID.HasValue && tarazSaleVoucherInsertResultViewModel.header != null)
								{
									if (!tarazSaleVoucherInsertResultViewModel.header.voucherHeaderID.HasValue)
									{
										return string.Format(Messages.msgErrorOtherSystemsNotRegistered, Labels.OtherSystemsPreOrder, Labels.TarazSamaneh) + "|";
									}
									tarazSaleVoucherIEViewModel.header.voucherHeaderID = tarazSaleVoucherInsertResultViewModel.header.voucherHeaderID;
								}
								if (tarazSaleVoucherInsertResultViewModel.header == null)
								{
									return Messages.msgErrorRunFunction + "|";
								}
								string text14 = "";
								text14 = tarazSaleVoucherInsertResultViewModel.header.voucherNumber.ToString();
								DbSet<WSPreOrder> wSPreOrder3 = _dbTbl.WSPreOrder;
								val = Expression.Parameter(typeof(WSPreOrder), "c");
								WSPreOrder wSPreOrder4 = Queryable.FirstOrDefault<WSPreOrder>((IQueryable<WSPreOrder>)wSPreOrder3, Expression.Lambda<Func<WSPreOrder, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass73_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
								if (wSPreOrder4 == null)
								{
									return Messages.ErrorNotFound + "|";
								}
								wSPreOrder4.pordLinkAccPreOrderNumber = text14;
								wSPreOrder4.pordLinkAccPreOrderIdStr = tarazSaleVoucherIEViewModel.header.voucherHeaderID.ToString();
								_dbTbl.Entry(wSPreOrder4).State = EntityState.Modified;
								_dbTbl.Configuration.ValidateOnSaveEnabled = false;
								_dbTbl.SaveChanges();
								_dbTbl.Configuration.ValidateOnSaveEnabled = true;
								if (tarazSaleVoucherInsertResultViewModel.details != null && Enumerable.Any<TarazSaleVoucherDetailsInsertResultViewModel>((IEnumerable<TarazSaleVoucherDetailsInsertResultViewModel>)tarazSaleVoucherInsertResultViewModel.details))
								{
									using List<TarazSaleVoucherDetailsInsertResultViewModel>.Enumerator enumerator5 = tarazSaleVoucherInsertResultViewModel.details.GetEnumerator();
									while (enumerator5.MoveNext())
									{
										_003C_003Ec__DisplayClass73_6 _003C_003Ec__DisplayClass73_2 = new _003C_003Ec__DisplayClass73_6();
										_003C_003Ec__DisplayClass73_2.vouItem = enumerator5.Current;
										_003C_003Ec__DisplayClass73_7 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass73_7();
										CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals2 = _003C_003Ec__DisplayClass73_2;
										CS_0024_003C_003E8__locals2.prdId = 0;
										if (CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals2.vouItem.goodsID.HasValue)
										{
											WSspSelectProductWithAccLinkField_Result wSspSelectProductWithAccLinkField_Result3 = Enumerable.FirstOrDefault<WSspSelectProductWithAccLinkField_Result>((IEnumerable<WSspSelectProductWithAccLinkField_Result>)list, (Func<WSspSelectProductWithAccLinkField_Result, bool>)((WSspSelectProductWithAccLinkField_Result m) => m.PrdLinkAccPrdIdStr == CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals2.vouItem.goodsID.ToString()));
											if (wSspSelectProductWithAccLinkField_Result3 != null)
											{
												CS_0024_003C_003E8__locals2.prdId = wSspSelectProductWithAccLinkField_Result3.ProductID;
											}
										}
										CS_0024_003C_003E8__locals2.odItem = Enumerable.FirstOrDefault<WSspSelectPreOrderItems_Result>((IEnumerable<WSspSelectPreOrderItems_Result>)list10, (Func<WSspSelectPreOrderItems_Result, bool>)((WSspSelectPreOrderItems_Result m) => (m.pordIQuantity == CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals2.vouItem.quantity && (decimal)(m.pordIFCR.GetValueOrDefault(1.0) * m.pordIFCRI.GetValueOrDefault(1.0)) == CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals2.vouItem.computeValue.GetValueOrDefault(1m) && m.pordIPrice == CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals2.vouItem.fee && m.pordIPrdId == CS_0024_003C_003E8__locals2.prdId) || (m.pordILinkAccItemIdStr ?? "0") == CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals2.vouItem.voucherDetailID.GetValueOrDefault().ToString()));
										if (CS_0024_003C_003E8__locals2.odItem != null)
										{
											DbSet<WSPreOrderItems> wSPreOrderItems3 = _dbTbl.WSPreOrderItems;
											val = Expression.Parameter(typeof(WSPreOrderItems), "m");
											WSPreOrderItems wSPreOrderItems4 = Queryable.FirstOrDefault<WSPreOrderItems>((IQueryable<WSPreOrderItems>)wSPreOrderItems3, Expression.Lambda<Func<WSPreOrderItems, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals2, typeof(_003C_003Ec__DisplayClass73_7)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
											if (wSPreOrderItems4 != null)
											{
												wSPreOrderItems4.pordILinkAccItemIdStr = CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals2.vouItem.voucherDetailID.ToString();
												_dbTbl.Entry(wSPreOrderItems4).State = EntityState.Modified;
												_dbTbl.Configuration.ValidateOnSaveEnabled = false;
												_dbTbl.SaveChanges();
												_dbTbl.Configuration.ValidateOnSaveEnabled = true;
											}
										}
									}
								}
								string text15 = text14 ?? "";
								result = "1|" + text15;
							}
						}
						else
						{
							Exception e4 = new Exception(Messages.errorInReadingSetting + " (tarazSamaneh) ");
							ErrorSignal.FromCurrentContext().Raise(e4);
						}
					}
					else
					{
						Exception e5 = new Exception(Messages.errorInReadingSetting + " (tarazSamaneh) ");
						ErrorSignal.FromCurrentContext().Raise(e5);
					}
				}
				else
				{
					result = Messages.ErrorNotFound + "|";
				}
			}
			else
			{
				result = Messages.ErrorNotFound + "|";
			}
		}
		catch (Exception e6)
		{
			ErrorSignal.FromCurrentContext().Raise(e6);
			result = Messages.msgErrorRunFunction + "|";
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "frmPreOrder", ActionName = "actExportToAcc")]
	public ActionResult TarazExportPreOrder()
	{
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmExportToAcc", ActionName = "actShowInfo")]
	public ActionResult TarazExportPreOrder_Read([DataSourceRequest] DataSourceRequest request, int pageNumber, string fDate = "", string tDate = "", long value = 0L)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SepPreOrderViewModel> list = new List<SepPreOrderViewModel>();
		try
		{
			int value2 = 500;
			pageNumber = ((pageNumber <= 0) ? 1 : pageNumber);
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
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
			foreach (CRMspLkTarazWSSelectPreOrder_Result item2 in Enumerable.ToList<CRMspLkTarazWSSelectPreOrder_Result>((IEnumerable<CRMspLkTarazWSSelectPreOrder_Result>)_dbLink.CRMspLkTarazWSSelectPreOrder(UserLogin.CurrentUser.UserId, (!string.IsNullOrEmpty(fDate)) ? new DateTime?(value3) : null, (!string.IsNullOrEmpty(tDate)) ? new DateTime?(value4) : null, value, pageNumber, value2, lCID, result, centerId)))
			{
				SepPreOrderViewModel item = new SepPreOrderViewModel
				{
					pordLinkAccPreOrderId = item2.pordLinkAccPreOrderId,
					pordLinkAccPreOrderIdStr = item2.pordLinkAccPreOrderIdStr,
					Company = ((!string.IsNullOrEmpty(item2.CompanyName)) ? item2.CompanyName : "") + ((!string.IsNullOrEmpty(item2.CompanyPerson)) ? (" - " + item2.CompanyPerson) : ""),
					PordNumber = item2.pordNumber,
					Date = item2.pordDateTime,
					DatePersian = (item2.pordDateTime.HasValue ? item2.pordDateTime.Value.ToString("yyyy/MM/dd") : ""),
					pordTotalAmount = item2.pordTotalAmount,
					ItemCount = item2.pordItemCount,
					PreOrderId = item2.PreOrderID,
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

	[DynamicAuthorize(ControllerName = "frmExportToAcc", ActionName = "actSendToAcc")]
	[AjaxOnly]
	public JsonResult TarazExportInfo(string records)
	{
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		int num = 0;
		string text = "";
		CommonResultStatusViewModel commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		CommonResultViewModel<int> data;
		try
		{
			DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			_ = Financial.Get().Id;
			short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			List<OtherSystemSelectedViewModel> list = new List<OtherSystemSelectedViewModel>();
			if (!string.IsNullOrWhiteSpace(records))
			{
				list = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedViewModel>>(records);
			}
			text = "";
			int num2 = 0;
			if (Enumerable.Any<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list))
			{
				List<OtherSystemSelectedViewModel> list2 = Enumerable.ToList<OtherSystemSelectedViewModel>(Enumerable.Where<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list, (Func<OtherSystemSelectedViewModel, bool>)((OtherSystemSelectedViewModel m) => m.Selected && m.Id > 0)));
				if (Enumerable.Any<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list2) && list2 != null)
				{
					num2 = Enumerable.Count<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list2);
					int num3 = 0;
					foreach (OtherSystemSelectedViewModel item in list2)
					{
						string text2 = TarazActSendToAcc(item.Id);
						if (!string.IsNullOrEmpty(text2))
						{
							string[] array = text2.Split(new char[1] { '|' });
							if (array == null)
							{
								continue;
							}
							if (array[0] == "1")
							{
								long result2 = 0L;
								long.TryParse(array[1], out result2);
								if (result2 > 0)
								{
									num3++;
									int count = num3 * 100 / num2;
									ProgressHub.SendMessage("ok", count, userId);
								}
								else
								{
									text = text + "<br>" + Messages.msgErrorRunFunction;
									num3++;
									int count2 = num3 * 100 / num2;
									ProgressHub.SendMessage(Messages.msgErrorRunFunction, count2, userId);
								}
							}
							else
							{
								text = text + "<br>" + array[0];
								num3++;
								int count3 = num3 * 100 / num2;
								ProgressHub.SendMessage(array[0], count3, userId);
							}
						}
						else
						{
							text = text + "<br>" + Messages.msgErrorRunFunction;
						}
					}
				}
				else
				{
					text = Messages.msgErrorRunFunction + " (" + Messages.msgErrorNotSelectedItem + ")";
				}
			}
			if (!string.IsNullOrEmpty(text))
			{
				num = 0;
				commonResultStatusViewModel = CommonResultStatusViewModel.Fail;
				ProgressHub.SendMessage(text, 0, userId);
			}
			else
			{
				text = Messages.msgSuccessAction;
				num = 1;
				commonResultStatusViewModel = CommonResultStatusViewModel.Success;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			num = 0;
			data = new CommonResultViewModel<int>
			{
				Data = num,
				Message = Messages.msgErrorRunFunction,
				Status = CommonResultStatusViewModel.Error
			};
			return Json(data, JsonRequestBehavior.AllowGet);
		}
		data = new CommonResultViewModel<int>
		{
			Data = num,
			Message = text,
			Status = commonResultStatusViewModel
		};
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetTarazExportPreOrderList(string records, int totalPage, string fDate = "", string tDate = "", long value = 0L)
	{
		//IL_0248: Unknown result type (might be due to invalid IL or missing references)
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
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
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
			foreach (CRMspLkTarazWSSelectPreOrder_Result item2 in Enumerable.ToList<CRMspLkTarazWSSelectPreOrder_Result>((IEnumerable<CRMspLkTarazWSSelectPreOrder_Result>)_dbLink.CRMspLkTarazWSSelectPreOrder(UserLogin.CurrentUser.UserId, (!string.IsNullOrEmpty(fDate)) ? new DateTime?(value4) : null, (!string.IsNullOrEmpty(tDate)) ? new DateTime?(value5) : null, value, value3, value2, lCID, result, centerId)))
			{
				OtherSystemSelectedViewModel item = new OtherSystemSelectedViewModel
				{
					Row = item2.RowNumber.GetValueOrDefault(),
					Id = item2.PreOrderID,
					Selected = string.IsNullOrEmpty(item2.pordLinkAccPreOrderIdStr)
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

	public ShygunIIPreOrderInfoViewModelObjects GetShygunIIPreOrderList(string fDate = "", string tDate = "", string fNumber = "0", string tNumber = "0", int fOrderType = 13, int tOrderType = 13, int fPrinted = 0, int tPrinted = 0, int fromRec = 0, int recCount = 20)
	{
		//IL_09c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_09cd: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		ShygunIIPreOrderInfoViewModelObjects shygunIIPreOrderInfoViewModelObjects = new ShygunIIPreOrderInfoViewModelObjects();
		try
		{
			DateTime dateTime = DateTime.Now;
			DateTime dateTime2 = DateTime.Now;
			if (!string.IsNullOrEmpty(fDate))
			{
				dateTime = DateTime.Parse(PersianDate.GetFormatetdDate(fDate.Replace("/", "")) + " 00:00:00", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			if (!string.IsNullOrEmpty(tDate))
			{
				dateTime2 = DateTime.Parse(PersianDate.GetFormatetdDate(tDate.Replace("/", "")) + " 23:59:59", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			List<ShygunIIPreOrderInfoViewModel> list = new List<ShygunIIPreOrderInfoViewModel>();
			List<WSspSelectPreOrderWithAccLinkField_Result> list2 = SelectPreOrderWithAccLinkField(withPordpordLinkAccPreOrderId: false, withPordpordLinkAccPreOrderIdStr: true);
			CRMIdeal.Classes.Helper.OtherSystems.ShygunIISettingViewModel shygunIISetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunIISetting();
			DomainInvoiceHeader domainInvoiceHeader = new DomainInvoiceHeader();
			domainInvoiceHeader.InvoiceDate.From = dateTime.ToString("yyyy/MM/dd");
			domainInvoiceHeader.InvoiceDate.To = dateTime2.ToString("yyyy/MM/dd");
			domainInvoiceHeader.InvoiceNumber.From = ((fNumber == "0" || string.IsNullOrWhiteSpace(fNumber)) ? "" : fNumber);
			domainInvoiceHeader.InvoiceNumber.To = ((tNumber == "0" || string.IsNullOrWhiteSpace(tNumber)) ? "" : tNumber);
			domainInvoiceHeader.InvoiceType.From = fOrderType.ToString();
			domainInvoiceHeader.InvoiceType.To = tOrderType.ToString();
			domainInvoiceHeader.Printed.From = fPrinted.ToString();
			domainInvoiceHeader.Printed.To = tPrinted.ToString();
			string text = shygunIISetting.IP;
			if (string.IsNullOrWhiteSpace(text))
			{
				Exception e = new Exception(Messages.errorInReadingSetting);
				ErrorSignal.FromCurrentContext().Raise(e);
			}
			if (!text.EndsWith("/"))
			{
				text += "/";
			}
			HttpClient httpClient = new HttpClient();
			httpClient.Timeout = CRMIdeal.Classes.Helper.OtherSystems.RestApiTimeout();
			httpClient.BaseAddress = new Uri(text);
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			string text2 = "api/Invoice/Get";
			text2 = text2 + "?RowStart=" + fromRec + "&RowCount=" + recCount;
			HttpContent content = new StringContent(JsonConvert.SerializeObject(new CRMIdeal.Classes.Helper.OtherSystems.ShygunIIApiGetInvParamViewModel
			{
				Config = shygunIISetting.conf,
				Domain = domainInvoiceHeader,
				StartVersion = "0"
			}), Encoding.UTF8, "application/json");
			HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
			httpResponseMessage = httpClient.PostAsync(text2, content).Result;
			if (httpResponseMessage.IsSuccessStatusCode)
			{
				CRMIdeal.Classes.Helper.OtherSystems.ShygunIIApiGetInvResultViewModel shygunIIApiGetInvResultViewModel = JsonConvert.DeserializeObject<CRMIdeal.Classes.Helper.OtherSystems.ShygunIIApiGetInvResultViewModel>(httpResponseMessage.Content.ReadAsStringAsync().Result);
				if (shygunIIApiGetInvResultViewModel != null && shygunIIApiGetInvResultViewModel.Result != null && Enumerable.Any<CRMIdeal.Classes.Helper.OtherSystems.ShygunIIInvoiceViewModel>((IEnumerable<CRMIdeal.Classes.Helper.OtherSystems.ShygunIIInvoiceViewModel>)shygunIIApiGetInvResultViewModel.Result))
				{
					foreach (CRMIdeal.Classes.Helper.OtherSystems.ShygunIIInvoiceViewModel item in shygunIIApiGetInvResultViewModel.Result)
					{
						ShygunIIPreOrderInfoViewModel shygunIIPreOrderInfoViewModel = new ShygunIIPreOrderInfoViewModel();
						shygunIIPreOrderInfoViewModel.InvTyp = item.InvTyp;
						shygunIIPreOrderInfoViewModel.InvNo = item.InvNo;
						shygunIIPreOrderInfoViewModel.AccountGuId = item.AccountGuId;
						shygunIIPreOrderInfoViewModel.JobCostingGuId = item.JobCostingGuId;
						shygunIIPreOrderInfoViewModel.InvDescription = item.InvDescription;
						shygunIIPreOrderInfoViewModel.InvDate = item.InvDate;
						shygunIIPreOrderInfoViewModel.InvPayDue = item.InvPayDue;
						shygunIIPreOrderInfoViewModel.AccountNumber = item.AccountNumber;
						shygunIIPreOrderInfoViewModel.AccountName = item.AccountName;
						shygunIIPreOrderInfoViewModel.JobCostingNumber = item.JobCostingNumber;
						shygunIIPreOrderInfoViewModel.JobCostingName = item.JobCostingName;
						shygunIIPreOrderInfoViewModel.CurrencyAbb1 = item.CurrencyAbb1;
						shygunIIPreOrderInfoViewModel.SAccountGuId = item.SAccountGuId;
						shygunIIPreOrderInfoViewModel.SJobGuId = item.SJobGuId;
						shygunIIPreOrderInfoViewModel.bijak = item.bijak;
						shygunIIPreOrderInfoViewModel.GuId = item.GuId;
						if (item.CreatedDate.HasValue)
						{
							shygunIIPreOrderInfoViewModel.CreatedDate = item.CreatedDate;
							shygunIIPreOrderInfoViewModel.CreatedDatePersian = (item.CreatedDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
						}
						else
						{
							shygunIIPreOrderInfoViewModel.CreatedDate = null;
							shygunIIPreOrderInfoViewModel.CreatedDatePersian = "";
						}
						shygunIIPreOrderInfoViewModel.GeneralRef = item.GeneralRef;
						shygunIIPreOrderInfoViewModel.SAccountNumber = item.SAccountNumber;
						shygunIIPreOrderInfoViewModel.SJobNumber = item.SJobNumber;
						shygunIIPreOrderInfoViewModel.DiscountPercent = item.DiscountPercent;
						shygunIIPreOrderInfoViewModel.DiscAmount = item.DiscAmount;
						shygunIIPreOrderInfoViewModel.DepartmentNumber = item.DepartmentNumber;
						shygunIIPreOrderInfoViewModel.ST1Number = item.ST1Number;
						shygunIIPreOrderInfoViewModel.ST1GuId = item.ST1GuId;
						shygunIIPreOrderInfoViewModel.ST2Number = item.ST2Number;
						shygunIIPreOrderInfoViewModel.ST2GuId = item.ST2GuId;
						shygunIIPreOrderInfoViewModel.AtfNumber = item.AtfNumber;
						shygunIIPreOrderInfoViewModel.AtfGuId = item.AtfGuId;
						item.InvNo.ToString();
						string InvGuId = item.GuId.ToString();
						WSspSelectPreOrderWithAccLinkField_Result wSspSelectPreOrderWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectPreOrderWithAccLinkField_Result>((IEnumerable<WSspSelectPreOrderWithAccLinkField_Result>)list2, (Func<WSspSelectPreOrderWithAccLinkField_Result, bool>)((WSspSelectPreOrderWithAccLinkField_Result x) => x.pordLinkAccPreOrderIdStr == InvGuId));
						if (wSspSelectPreOrderWithAccLinkField_Result != null && wSspSelectPreOrderWithAccLinkField_Result.PreOrderID > 0)
						{
							shygunIIPreOrderInfoViewModel.PreOrderId = wSspSelectPreOrderWithAccLinkField_Result.PreOrderID;
						}
						List<ShygunIIPreOrderBodyInfoViewModel> list3 = new List<ShygunIIPreOrderBodyInfoViewModel>();
						shygunIIPreOrderInfoViewModel.PreOrderBodyCount = 0;
						if (item.Body != null && item.Body.Count > 0)
						{
							foreach (InvoiceBody item2 in item.Body)
							{
								ShygunIIPreOrderBodyInfoViewModel shygunIIPreOrderBodyInfoViewModel = new ShygunIIPreOrderBodyInfoViewModel();
								shygunIIPreOrderBodyInfoViewModel.InvNo = shygunIIPreOrderInfoViewModel.InvNo;
								shygunIIPreOrderBodyInfoViewModel.InvGuId = shygunIIPreOrderInfoViewModel.GuId;
								shygunIIPreOrderBodyInfoViewModel.LineItemId = item2.LineItemId;
								shygunIIPreOrderBodyInfoViewModel.InvHeaderId = item2.InvHeaderId;
								shygunIIPreOrderBodyInfoViewModel.LineItemOrder = item2.LineItemOrder;
								shygunIIPreOrderBodyInfoViewModel.ItemNumber = item2.ItemNumber;
								shygunIIPreOrderBodyInfoViewModel.STNumber = item2.STNumber;
								shygunIIPreOrderBodyInfoViewModel.STDesc = item2.STDesc;
								shygunIIPreOrderBodyInfoViewModel.STGuId = item2.STGuId;
								shygunIIPreOrderBodyInfoViewModel.ItemGuId = item2.ItemGuId;
								shygunIIPreOrderBodyInfoViewModel.Quan = item2.Quan;
								shygunIIPreOrderBodyInfoViewModel.Quan2 = item2.Quan2;
								shygunIIPreOrderBodyInfoViewModel.Price = item2.Price;
								shygunIIPreOrderBodyInfoViewModel.Price2 = item2.Price2;
								shygunIIPreOrderBodyInfoViewModel.Amount = item2.Amount;
								shygunIIPreOrderBodyInfoViewModel.AmortizePercent = item2.AmortizePercent;
								shygunIIPreOrderBodyInfoViewModel.LineDiscAmount = item2.LineDiscAmount;
								shygunIIPreOrderBodyInfoViewModel.LineDiscPer = item2.LineDiscPer;
								shygunIIPreOrderBodyInfoViewModel.LineItemDesc = item2.LineItemDesc;
								shygunIIPreOrderBodyInfoViewModel.ReturnRial = item2.ReturnRial;
								shygunIIPreOrderBodyInfoViewModel.OrderRemain1 = item2.OrderRemain1;
								shygunIIPreOrderBodyInfoViewModel.OrderRemain2 = item2.OrderRemain2;
								shygunIIPreOrderBodyInfoViewModel.FinalOrderQuan = item2.FinalOrderQuan;
								shygunIIPreOrderBodyInfoViewModel.FinalOrderQuan2 = item2.FinalOrderQuan2;
								shygunIIPreOrderBodyInfoViewModel.PreOrderId = shygunIIPreOrderInfoViewModel.PreOrderId;
								shygunIIPreOrderBodyInfoViewModel.RowNumber = list3.Count + 1;
								list3.Add(shygunIIPreOrderBodyInfoViewModel);
							}
							shygunIIPreOrderInfoViewModel.PreOrderBodyCount = list3.Count;
						}
						shygunIIPreOrderInfoViewModel.PreOrderBody = list3;
						List<ShygunIIPreOrderExpenseViewModel> list4 = new List<ShygunIIPreOrderExpenseViewModel>();
						shygunIIPreOrderInfoViewModel.PreOrderExpenseCount = 0;
						if (item.Expense != null && item.Expense.Count > 0)
						{
							foreach (InvoiceExpense item3 in item.Expense)
							{
								ShygunIIPreOrderExpenseViewModel shygunIIPreOrderExpenseViewModel = new ShygunIIPreOrderExpenseViewModel();
								shygunIIPreOrderExpenseViewModel.InvExpRowId = item3.InvExpRowId;
								shygunIIPreOrderExpenseViewModel.InvExpRowOrder = item3.InvExpRowOrder;
								shygunIIPreOrderExpenseViewModel.InvHeaderId = item3.InvHeaderId;
								shygunIIPreOrderExpenseViewModel.AccountGuId = item3.AccountGuId;
								shygunIIPreOrderExpenseViewModel.JobCostingGuId = item3.JobCostingGuId;
								shygunIIPreOrderExpenseViewModel.AccountNumber = item3.AccountNumber;
								shygunIIPreOrderExpenseViewModel.AccountName = item3.AccountName;
								shygunIIPreOrderExpenseViewModel.JobCostingNumber = item3.JobCostingNumber;
								shygunIIPreOrderExpenseViewModel.InvExpRowDesc = item3.InvExpRowDesc;
								shygunIIPreOrderExpenseViewModel.InvExpRowAmount = item3.InvExpRowAmount;
								shygunIIPreOrderExpenseViewModel.SecondAccountNumber = item3.SecondAccountNumber;
								shygunIIPreOrderExpenseViewModel.SecondAccountName = item3.SecondAccountName;
								shygunIIPreOrderExpenseViewModel.SecondJobCostingGuId = item3.SecondJobCostingGuId;
								shygunIIPreOrderExpenseViewModel.SecondAccountGuId = item3.SecondAccountGuId;
								shygunIIPreOrderExpenseViewModel.SecondJobCostingNumber = item3.SecondJobCostingNumber;
								shygunIIPreOrderExpenseViewModel.FixCostType = item3.FixCostType;
								shygunIIPreOrderExpenseViewModel.PreOrderId = shygunIIPreOrderInfoViewModel.PreOrderId;
								shygunIIPreOrderExpenseViewModel.InvGuId = shygunIIPreOrderInfoViewModel.GuId;
								shygunIIPreOrderExpenseViewModel.RowNumber = list4.Count + 1;
								list4.Add(shygunIIPreOrderExpenseViewModel);
							}
							shygunIIPreOrderInfoViewModel.PreOrderExpenseCount = list4.Count;
						}
						shygunIIPreOrderInfoViewModel.PreOrderExpense = list4;
						shygunIIPreOrderInfoViewModel.RowNumber = list.Count + 1;
						list.Add(shygunIIPreOrderInfoViewModel);
					}
				}
			}
			else
			{
				HttpStatusCode statusCode = httpResponseMessage.StatusCode;
				Exception e2 = new Exception(((object)(HttpStatusCode)(ref statusCode)).ToString());
				ErrorSignal.FromCurrentContext().Raise(e2);
			}
			shygunIIPreOrderInfoViewModelObjects.lst = list;
			shygunIIPreOrderInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			shygunIIPreOrderInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
		}
		catch (Exception e3)
		{
			ErrorSignal.FromCurrentContext().Raise(e3);
		}
		return shygunIIPreOrderInfoViewModelObjects;
	}

	[DynamicAuthorize(ControllerName = "frmManagePordLinkAcc", ActionName = "actImportShowInfo")]
	public ActionResult ShygunIIImportPreOrder_Read([DataSourceRequest] DataSourceRequest request, string fDate = "", string tDate = "", string fNumber = "0", string tNumber = "0", int fOrderType = 13, int tOrderType = 13, int fPrinted = 0, int tPrinted = 0, int fromRec = 0, int recCount = 20)
	{
		List<ShygunIIPreOrderInfoViewModel> list = new List<ShygunIIPreOrderInfoViewModel>();
		ShygunIIPreOrderInfoViewModelObjects shygunIIPreOrderList = GetShygunIIPreOrderList(fDate, tDate, fNumber, tNumber, fOrderType, tOrderType, fPrinted, tPrinted, fromRec, recCount);
		if (shygunIIPreOrderList != null)
		{
			list = shygunIIPreOrderList.lst;
			if (list != null && Enumerable.Any<ShygunIIPreOrderInfoViewModel>((IEnumerable<ShygunIIPreOrderInfoViewModel>)list))
			{
				foreach (ShygunIIPreOrderInfoViewModel item in list)
				{
					if (!string.IsNullOrWhiteSpace(item.InvDate))
					{
						DateTime dateTime = default(DateTime);
						item.InvDate = item.InvDate.Replace("-", "/");
						item.InvDate = DateTime.Parse(PersianDate.GetFormatetdDate(item.InvDate) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None).ToString("yyyy/MM/dd");
					}
				}
			}
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetShygunIIImportPreOrderList(string fDate = "", string tDate = "", string fNumber = "0", string tNumber = "0", int fOrderType = 13, int tOrderType = 13, int fPrinted = 0, int tPrinted = 0, int fromRec = 0, int recCount = 20)
	{
		List<OtherSystemSelectedVIiewModel> list = new List<OtherSystemSelectedVIiewModel>();
		try
		{
			foreach (ShygunIIPreOrderInfoViewModel item2 in GetShygunIIPreOrderList(fDate, tDate, fNumber, tNumber, fOrderType, tOrderType, fPrinted, tPrinted, fromRec, recCount).lst)
			{
				OtherSystemSelectedVIiewModel item = new OtherSystemSelectedVIiewModel
				{
					Row = item2.RowNumber,
					Id = item2.GuId.ToString(),
					Selected = (item2.PreOrderId <= 0)
				};
				list.Add(item);
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

	[DynamicAuthorize(ControllerName = "frmManagePordLinkAcc", ActionName = "actImportInfo")]
	[AjaxOnly]
	public JsonResult ShygunIIImportInfo(string records, string fDate = "", string tDate = "", string fNumber = "0", string tNumber = "0", int fOrderType = 13, int tOrderType = 13, int fPrinted = 0, int tPrinted = 0, int preOrderOprId = 0, int whId = 0, int fromRec = 0, int recCount = 20, int referUserId = 0)
	{
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int num = 0;
		string text = "";
		CommonResultStatusViewModel commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		CommonResultViewModel<int> data;
		try
		{
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int id = Financial.Get().Id;
			short value2 = short.Parse(Financial.Get().Id.ToString());
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			List<OtherSystemSelectedVIiewModel> list = new List<OtherSystemSelectedVIiewModel>();
			if (!string.IsNullOrWhiteSpace(records))
			{
				List<OtherSystemSelectedVIiewModel> list2 = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedVIiewModel>>(records);
				if (Enumerable.Any<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list2))
				{
					list = Enumerable.ToList<OtherSystemSelectedVIiewModel>(Enumerable.Where<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list2, (Func<OtherSystemSelectedVIiewModel, bool>)((OtherSystemSelectedVIiewModel m) => m.Selected)));
				}
			}
			List<ShygunIIPreOrderInfoViewModel> list3 = new List<ShygunIIPreOrderInfoViewModel>();
			List<ShygunIIPreOrderInfoViewModel> lst = GetShygunIIPreOrderList(fDate, tDate, fNumber, tNumber, fOrderType, tOrderType, fPrinted, tPrinted, fromRec, recCount).lst;
			if (list != null)
			{
				foreach (OtherSystemSelectedVIiewModel SelectedRowitem in list)
				{
					ShygunIIPreOrderInfoViewModel shygunIIPreOrderInfoViewModel = Enumerable.FirstOrDefault<ShygunIIPreOrderInfoViewModel>(Enumerable.Where<ShygunIIPreOrderInfoViewModel>((IEnumerable<ShygunIIPreOrderInfoViewModel>)lst, (Func<ShygunIIPreOrderInfoViewModel, bool>)((ShygunIIPreOrderInfoViewModel w) => w.GuId.ToString() == SelectedRowitem.Id)));
					if (shygunIIPreOrderInfoViewModel != null)
					{
						list3.Add(shygunIIPreOrderInfoViewModel);
					}
				}
			}
			else
			{
				string text2 = Messages.msgErrorRunFunction + " (get list from ShygunII) ";
				Exception e = new Exception(text2);
				ErrorSignal.FromCurrentContext().Raise(e);
				text = text2;
			}
			if (list3 != null && Enumerable.Any<ShygunIIPreOrderInfoViewModel>((IEnumerable<ShygunIIPreOrderInfoViewModel>)list3) && string.IsNullOrWhiteSpace(text))
			{
				CRMIdeal.Classes.Helper.OtherSystems.ShygunIISettingViewModel set = CRMIdeal.Classes.Helper.OtherSystems.GetShygunIISetting();
				foreach (ShygunIIPreOrderInfoViewModel item in list3)
				{
					if (!string.IsNullOrWhiteSpace(text))
					{
						continue;
					}
					decimal num2 = default(decimal);
					decimal value4 = default(decimal);
					decimal value5 = default(decimal);
					int result2 = 0;
					decimal value6 = default(decimal);
					decimal value7 = default(decimal);
					decimal value8 = default(decimal);
					decimal value9 = default(decimal);
					if (item.PreOrderExpenseCount > 0)
					{
						List<ShygunIIPreOrderExpenseViewModel> list4 = Enumerable.ToList<ShygunIIPreOrderExpenseViewModel>(Enumerable.Where<ShygunIIPreOrderExpenseViewModel>((IEnumerable<ShygunIIPreOrderExpenseViewModel>)item.PreOrderExpense, (Func<ShygunIIPreOrderExpenseViewModel, bool>)((ShygunIIPreOrderExpenseViewModel x) => x.AccountNumber == set.DefTax)));
						if (list4 != null)
						{
							foreach (ShygunIIPreOrderExpenseViewModel item2 in list4)
							{
								num2 += item2.InvExpRowAmount.GetValueOrDefault();
							}
						}
						List<ShygunIIPreOrderExpenseViewModel> list5 = Enumerable.ToList<ShygunIIPreOrderExpenseViewModel>(Enumerable.Where<ShygunIIPreOrderExpenseViewModel>((IEnumerable<ShygunIIPreOrderExpenseViewModel>)item.PreOrderExpense, (Func<ShygunIIPreOrderExpenseViewModel, bool>)((ShygunIIPreOrderExpenseViewModel x) => x.AccountNumber == set.DefRound)));
						if (list5 != null)
						{
							foreach (ShygunIIPreOrderExpenseViewModel item3 in list5)
							{
								value4 += item3.InvExpRowAmount.GetValueOrDefault();
							}
						}
						List<ShygunIIPreOrderExpenseViewModel> list6 = Enumerable.ToList<ShygunIIPreOrderExpenseViewModel>(Enumerable.Where<ShygunIIPreOrderExpenseViewModel>((IEnumerable<ShygunIIPreOrderExpenseViewModel>)item.PreOrderExpense, (Func<ShygunIIPreOrderExpenseViewModel, bool>)((ShygunIIPreOrderExpenseViewModel x) => x.AccountNumber == set.DefTransportation)));
						if (list6 != null)
						{
							foreach (ShygunIIPreOrderExpenseViewModel item4 in list6)
							{
								value5 += item4.InvExpRowAmount.GetValueOrDefault();
							}
						}
					}
					int.TryParse(set.DefCurrencyUnit, out result2);
					WSspSelectCurrencyUnitsWithId_Result wSspSelectCurrencyUnitsWithId_Result = Enumerable.FirstOrDefault<WSspSelectCurrencyUnitsWithId_Result>((IEnumerable<WSspSelectCurrencyUnitsWithId_Result>)_db.WSspSelectCurrencyUnitsWithId(result2, lCID, result));
					if (wSspSelectCurrencyUnitsWithId_Result == null || wSspSelectCurrencyUnitsWithId_Result.CurrencyUnitID <= 0)
					{
						text = Messages.msgErrorOrderCurrencyUnit;
					}
					else
					{
						result2 = wSspSelectCurrencyUnitsWithId_Result.CurrencyUnitID;
					}
					if (whId <= 0 && item.PreOrderBodyCount > 0)
					{
						List<WSspSelectActiveWareHouse_Result> list7 = SelectActiveWareHouse();
						foreach (ShygunIIPreOrderBodyInfoViewModel i in item.PreOrderBody)
						{
							WSspSelectActiveWareHouse_Result wSspSelectActiveWareHouse_Result = Enumerable.FirstOrDefault<WSspSelectActiveWareHouse_Result>((IEnumerable<WSspSelectActiveWareHouse_Result>)list7, (Func<WSspSelectActiveWareHouse_Result, bool>)((WSspSelectActiveWareHouse_Result x) => x.WrhsLinkAccWhCode == i.STNumber));
							if (wSspSelectActiveWareHouse_Result == null || wSspSelectActiveWareHouse_Result.WareHouseID <= 0)
							{
								text += string.Format(Messages.msgErrorPreOrderItemWhNotFound, i.STNumber, item.InvNo);
							}
						}
					}
					if (referUserId == 0)
					{
						text += Messages.CheckEmptycmpReferUserId;
					}
					if (!string.IsNullOrWhiteSpace(text))
					{
						continue;
					}
					DateTime now2 = DateTime.Now;
					string text3 = "";
					now2 = (string.IsNullOrWhiteSpace(item.InvDate) ? (item.CreatedDate ?? DateTime.Now) : DateTime.Parse(PersianDate.GetFormatetdDate(item.InvDate.Replace("-", "/")) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None));
					text3 = now2.ToString("yyyyMMdd", new PersianCulture());
					ObjectParameter objectParameter = new ObjectParameter("InsertedId", 0);
					ObjectParameter objectParameter2 = new ObjectParameter("ErrorMessage", "");
					_dbLink.CRMspLkShygunIIWSInsertUpdatePreOrder((preOrderOprId == 0) ? null : new int?(preOrderOprId), "", 0L, text3, now2, item.JobCostingGuId.HasValue ? item.JobCostingGuId.ToString() : null, item.JobCostingNumber ?? "", item.JobCostingName ?? "", (!string.IsNullOrWhiteSpace(set.DefPrjTitle)) ? set.DefPrjTitle : "", result2, item.DiscAmount.GetValueOrDefault(), num2, (num2 > 0m) ? 9 : 0, num2 > 0m, "0", (item.CreatedDate ?? DateTime.Now).ToString("hh:mm:ss"), value5, item.DiscountPercent.GetValueOrDefault(), "", item.InvDescription ?? "", value4, (!item.CreatedDate.HasValue) ? DateTime.Now.ToString("yyyyMMdd", new PersianCulture()) : item.CreatedDate?.ToString("yyyyMMdd", new PersianCulture()), item.CreatedDate ?? DateTime.Now, null, item.GuId.ToString(), item.InvNo.ToString(), userId, id, value2, value3, DateTime.Now, DateTime.Now.ToString("yyyyMMdd", new PersianCulture()), appType, lCID, result, defPrjCvnsStatusGroupId: set.DefPrjCvnsStatusGroupId, prjStartDate: (item.CreatedDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture()), prjStartTime: (item.CreatedDate ?? DateTime.Now).ToString("hh:mm:ss"), prjStartDateTime: item.CreatedDate ?? DateTime.Now, prjStarterUserId: referUserId, pordReferUserId: referUserId, pordItemsAmount: value6, pordInstallAmount: value7, pordSumAmount: value8, pordTotalAmount: value9, insertedId: objectParameter, errorMessage: objectParameter2, centerId: centerId);
					if (string.IsNullOrWhiteSpace(objectParameter2.Value.ToString()))
					{
						int result3 = 0;
						int.TryParse(objectParameter.Value.ToString(), out result3);
						if (result3 <= 0)
						{
							text = text + "<br>" + Messages.msgErrorInsertPreOrderNotSuccess;
							continue;
						}
						int result4 = 0;
						int.TryParse(objectParameter.Value.ToString(), out result4);
						if (item.PreOrderBodyCount <= 0)
						{
							continue;
						}
						foreach (ShygunIIPreOrderBodyInfoViewModel item5 in item.PreOrderBody)
						{
							item5.PreOrderId = result4;
						}
						string json = JsonConvert.SerializeObject(item.PreOrderBody);
						_dbLink.CRMspLkShygunIIWSInsertUpdatePreOrderItems(json, userId, value3, id, value, registerDatePersian, appType, lCID, whId, objectParameter2);
						if (!string.IsNullOrWhiteSpace(objectParameter2.Value.ToString()))
						{
							text = text + "<br>" + objectParameter2.Value.ToString();
						}
					}
					else
					{
						text = text + "<br>" + objectParameter2.Value.ToString();
					}
				}
			}
			else
			{
				text = Messages.msgErrorRunFunction + " (" + Messages.ErrorNotFound + ")";
			}
			if (!string.IsNullOrEmpty(text))
			{
				num = 0;
				commonResultStatusViewModel = CommonResultStatusViewModel.Fail;
				ProgressHub.SendMessage(text, 0, userId);
			}
			else
			{
				text = Messages.msgSuccessAction;
				num = 1;
				commonResultStatusViewModel = CommonResultStatusViewModel.Success;
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
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			num = 0;
			data = new CommonResultViewModel<int>
			{
				Data = num,
				Message = Messages.msgErrorRunFunction,
				Status = CommonResultStatusViewModel.Error
			};
			return Json(data, JsonRequestBehavior.AllowGet);
		}
		data = new CommonResultViewModel<int>
		{
			Data = num,
			Message = text,
			Status = commonResultStatusViewModel
		};
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmManagePordLinkAcc", ActionName = "actExportShowInfo")]
	public ActionResult ShygunIIExportPreOrder_Read([DataSourceRequest] DataSourceRequest request, int oprId = 0, string fDate = "", string tDate = "", long value = 0L, int currentItemId = 0)
	{
		List<CRMspLkWSSelectPreOrder_Result> list = SelectPreOrderExport(oprId, fDate, tDate, value, currentItemId);
		if (list != null && Enumerable.Any<CRMspLkWSSelectPreOrder_Result>((IEnumerable<CRMspLkWSSelectPreOrder_Result>)list))
		{
			foreach (CRMspLkWSSelectPreOrder_Result item in list)
			{
				item.pordDate = (item.pordDateTime.HasValue ? item.pordDateTime.Value.ToString("yyyy/MM/dd") : "");
			}
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmManagePordLinkAcc", ActionName = "actExportInfo")]
	[AjaxOnly]
	public JsonResult ShygunIIExportInfo(string records, int pordOprId, string fDate, string tDate, long pordNumber, string pordAccNumber, bool sendPordPayToAcc = false, int currentItemId = 0)
	{
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int data = 0;
		string text = "";
		CommonResultStatusViewModel commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		CommonResultViewModel<int> data2;
		try
		{
			DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(Financial.Get().Id.ToString());
			short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			_ = UserLogin.CurrentUser.UserId;
			List<OtherSystemSelectedViewModel> list = new List<OtherSystemSelectedViewModel>();
			if (!string.IsNullOrWhiteSpace(records))
			{
				list = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedViewModel>>(records);
				if (list != null)
				{
					list = Enumerable.ToList<OtherSystemSelectedViewModel>(Enumerable.Where<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list, (Func<OtherSystemSelectedViewModel, bool>)((OtherSystemSelectedViewModel x) => x.Selected && x.Id > 0)));
				}
			}
			string text2 = "";
			List<CRMspLkWSSelectPreOrder_Result> list2 = SelectPreOrderExport(pordOprId, fDate, tDate, pordNumber, currentItemId);
			List<WSspSelectProductWithAccLinkField_Result> list3 = Enumerable.ToList<WSspSelectProductWithAccLinkField_Result>((IEnumerable<WSspSelectProductWithAccLinkField_Result>)_dbLink.WSspSelectProductWithAccLinkField(false, false, true, lCID, result));
			List<CRMspSelectUsersWithAccLinkField_Result> list4 = Enumerable.ToList<CRMspSelectUsersWithAccLinkField_Result>((IEnumerable<CRMspSelectUsersWithAccLinkField_Result>)_dbLink.CRMspSelectUsersWithAccLinkField(true, false, lCID, result));
			List<WSspSelectWareHouse_Result> list5 = CRMIdeal.Classes.Helper.Warehouse.SelectWareHouse();
			CRMIdeal.Classes.Helper.OtherSystems.ShygunIISettingViewModel shygunIISetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunIISetting();
			string text3 = "";
			if (shygunIISetting == null)
			{
				text3 = Messages.errorInReadingSetting;
			}
			string text4 = "";
			string text5 = "";
			if (!string.IsNullOrWhiteSpace(pordAccNumber))
			{
				string[] array = pordAccNumber.Split(new char[1] { '|' });
				if (array != null)
				{
					if (array.Length != 0)
					{
						text4 = array[0];
					}
					if (array.Length > 1)
					{
						text5 = array[1];
					}
				}
				if (string.IsNullOrWhiteSpace(text4) || string.IsNullOrWhiteSpace(text5))
				{
					text3 = string.Format(Messages.msgErrorIsNotSelectedItem, Labels.OtherSystemsLinkedShygunIIAccountNumber);
				}
			}
			else
			{
				text3 = string.Format(Messages.msgErrorIsNotSelectedItem, Labels.OtherSystemsLinkedShygunIIAccountNumber);
			}
			if (!string.IsNullOrWhiteSpace(text3))
			{
				data2 = new CommonResultViewModel<int>
				{
					Data = 0,
					Message = text3,
					Status = CommonResultStatusViewModel.Error
				};
				return Json(data2, JsonRequestBehavior.AllowGet);
			}
			List<Invoice> list6 = new List<Invoice>();
			foreach (OtherSystemSelectedViewModel item in list)
			{
				_003C_003Ec__DisplayClass84_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass84_1();
				CS_0024_003C_003E8__locals1.pord = Enumerable.FirstOrDefault<CRMspLkWSSelectPreOrder_Result>((IEnumerable<CRMspLkWSSelectPreOrder_Result>)list2, (Func<CRMspLkWSSelectPreOrder_Result, bool>)((CRMspLkWSSelectPreOrder_Result x) => x.PreOrderID == item.Id));
				if (CS_0024_003C_003E8__locals1.pord == null || CS_0024_003C_003E8__locals1.pord.PreOrderID <= 0)
				{
					continue;
				}
				string errorMessage = "";
				if (!PreOrder.SendToLinkAccNeedVerify(item.Id, ref errorMessage))
				{
					text = text + "<br>" + errorMessage;
				}
				if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals1.pord.pordLinkAccPreOrderNumber))
				{
					ShygunIIPreOrderInfoViewModelObjects shygunIIPreOrderList = GetShygunIIPreOrderList(CS_0024_003C_003E8__locals1.pord.pordDateTime?.ToString("yyyy/MM/dd"), CS_0024_003C_003E8__locals1.pord.pordDateTime?.ToString("yyyy/MM/dd"), CS_0024_003C_003E8__locals1.pord.pordLinkAccPreOrderNumber, CS_0024_003C_003E8__locals1.pord.pordLinkAccPreOrderNumber, 2, 2);
					if (shygunIIPreOrderList != null && shygunIIPreOrderList.lst == null && !Enumerable.Any<ShygunIIPreOrderInfoViewModel>((IEnumerable<ShygunIIPreOrderInfoViewModel>)shygunIIPreOrderList.lst))
					{
						DbSet<WSPreOrder> wSPreOrder = _dbTbl.WSPreOrder;
						ParameterExpression val = Expression.Parameter(typeof(WSPreOrder), "x");
						WSPreOrder wSPreOrder2 = Queryable.FirstOrDefault<WSPreOrder>((IQueryable<WSPreOrder>)wSPreOrder, Expression.Lambda<Func<WSPreOrder, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass84_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
						if (wSPreOrder2 != null)
						{
							_dbTbl.Entry(wSPreOrder2).State = EntityState.Modified;
							wSPreOrder2.pordLinkAccPreOrderId = null;
							wSPreOrder2.pordLinkAccPreOrderNumber = null;
							wSPreOrder2.pordLinkAccPreOrderIdStr = null;
							_dbTbl.Configuration.ValidateOnSaveEnabled = false;
							_dbTbl.SaveChanges();
							_dbTbl.Configuration.ValidateOnSaveEnabled = true;
						}
					}
				}
				else
				{
					DbSet<WSPreOrder> wSPreOrder3 = _dbTbl.WSPreOrder;
					ParameterExpression val = Expression.Parameter(typeof(WSPreOrder), "x");
					WSPreOrder wSPreOrder4 = Queryable.FirstOrDefault<WSPreOrder>((IQueryable<WSPreOrder>)wSPreOrder3, Expression.Lambda<Func<WSPreOrder, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass84_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
					if (wSPreOrder4 != null)
					{
						_dbTbl.Entry(wSPreOrder4).State = EntityState.Modified;
						wSPreOrder4.pordLinkAccPreOrderId = null;
						wSPreOrder4.pordLinkAccPreOrderNumber = null;
						wSPreOrder4.pordLinkAccPreOrderIdStr = null;
						_dbTbl.Configuration.ValidateOnSaveEnabled = false;
						_dbTbl.SaveChanges();
						_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					}
				}
				CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(CS_0024_003C_003E8__locals1.pord.pordCompanyId.GetValueOrDefault());
				if (!string.IsNullOrWhiteSpace(text))
				{
					continue;
				}
				if (companyById == null || string.IsNullOrWhiteSpace(companyById.cmpLinkAccCustomerIdStr))
				{
					text = text + "<br>" + string.Format(Messages.msgErrorCompanyNotFoundInAccLink, companyById.cmpName, Labels.ShygunII);
					continue;
				}
				Invoice invoice = new Invoice();
				_ = CS_0024_003C_003E8__locals1.pord.pordNumber;
				invoice.InvNo = int.Parse(CS_0024_003C_003E8__locals1.pord.pordNumber.ToString());
				invoice.AccountNumber = text5;
				invoice.AccountGuId = ((!string.IsNullOrWhiteSpace(text4)) ? Guid.Parse(text4) : Guid.NewGuid());
				invoice.JobCostingNumber = companyById.cmpLinkAccCode;
				invoice.JobCostingGuId = ((!string.IsNullOrWhiteSpace(companyById.cmpLinkAccCustomerIdStr)) ? Guid.Parse(companyById.cmpLinkAccCustomerIdStr) : Guid.NewGuid());
				invoice.InvTyp = 13;
				if (CS_0024_003C_003E8__locals1.pord.pordDiscount.HasValue)
				{
					invoice.DiscAmount = CS_0024_003C_003E8__locals1.pord.pordDiscount;
				}
				else if (CS_0024_003C_003E8__locals1.pord.pordDiscountPercent.HasValue)
				{
					invoice.DiscountPercent = CS_0024_003C_003E8__locals1.pord.pordDiscountPercent;
				}
				invoice.GuId = CS_0024_003C_003E8__locals1.pord.GUId;
				invoice.InvDescription = CS_0024_003C_003E8__locals1.pord.pordDescriptionI ?? "";
				invoice.UpdateKind = ActionType.insert;
				if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals1.pord.pordLinkAccPreOrderIdStr))
				{
					invoice.GuId = Guid.Parse(CS_0024_003C_003E8__locals1.pord.pordLinkAccPreOrderIdStr);
					invoice.UpdateKind = ActionType.insertOrUpdate;
				}
				if (CS_0024_003C_003E8__locals1.pord.pordDateTime.HasValue)
				{
					invoice.InvDate = CS_0024_003C_003E8__locals1.pord.pordDateTime.Value.ToString("yyyyMMdd", new CultureInfo("en-US"));
				}
				if (CS_0024_003C_003E8__locals1.pord.FirstRegisterDate.HasValue)
				{
					invoice.CreatedDate = CS_0024_003C_003E8__locals1.pord.FirstRegisterDate;
				}
				invoice.DeleteAllExpenses = true;
				if (!CS_0024_003C_003E8__locals1.pord.pordReferUserId.HasValue)
				{
					text = text + "<br>" + string.Format(Messages.msgErrorInSendPordToAccLinkNotSelectedItem, CS_0024_003C_003E8__locals1.pord.pordNumber, Labels.ShygunII, Labels.pordReferUserId);
				}
				else
				{
					CRMspSelectUsersWithAccLinkField_Result cRMspSelectUsersWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectUsersWithAccLinkField_Result>((IEnumerable<CRMspSelectUsersWithAccLinkField_Result>)list4, (Func<CRMspSelectUsersWithAccLinkField_Result, bool>)((CRMspSelectUsersWithAccLinkField_Result m) => m.UserId == CS_0024_003C_003E8__locals1.pord.pordReferUserId));
					if (cRMspSelectUsersWithAccLinkField_Result != null)
					{
						string linkAccUserIdStr = cRMspSelectUsersWithAccLinkField_Result.LinkAccUserIdStr;
						if (string.IsNullOrWhiteSpace(linkAccUserIdStr))
						{
							text = text + "<br>" + string.Format(Messages.msgErrorInSendPordToAccLinkNotFoundIteminAcc, CS_0024_003C_003E8__locals1.pord.pordNumber, Labels.ShygunII, Labels.pordReferUserId, cRMspSelectUsersWithAccLinkField_Result.FullName ?? "");
						}
						else
						{
							invoice.SJobGuId = ((!string.IsNullOrWhiteSpace(linkAccUserIdStr)) ? Guid.Parse(linkAccUserIdStr) : Guid.NewGuid());
							invoice.SJobNumber = cRMspSelectUsersWithAccLinkField_Result.LinkAccUserCode ?? "";
						}
					}
					else
					{
						text = text + "<br>" + string.Format(Messages.msgErrorInSendPordToAccLinkNotFoundIteminAcc, CS_0024_003C_003E8__locals1.pord.pordNumber, Labels.ShygunII, Labels.pordReferUserId, CS_0024_003C_003E8__locals1.pord.pordReferUser ?? "");
					}
				}
				List<InvoiceBody> list7 = new List<InvoiceBody>();
				decimal num = default(decimal);
				decimal num2 = default(decimal);
				List<WSspSelectPreOrderItems_Result> list8 = Enumerable.ToList<WSspSelectPreOrderItems_Result>((IEnumerable<WSspSelectPreOrderItems_Result>)_db.WSspSelectPreOrderItems(CS_0024_003C_003E8__locals1.pord.PreOrderID, lCID, result));
				if (list8 != null && string.IsNullOrWhiteSpace(text))
				{
					using List<WSspSelectPreOrderItems_Result>.Enumerator enumerator2 = list8.GetEnumerator();
					while (enumerator2.MoveNext())
					{
						_003C_003Ec__DisplayClass84_2 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass84_2();
						CS_0024_003C_003E8__locals2.pordI = enumerator2.Current;
						string text6 = "";
						string text7 = "";
						WSspSelectWareHouse_Result wSspSelectWareHouse_Result = new WSspSelectWareHouse_Result();
						if (shygunIISetting.WrhsSyncTypeId == 2 && !string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals2.pordI.pordILinkAccWHIdStr))
						{
							WSspSelectWareHouse_Result wSspSelectWareHouse_Result2 = Enumerable.FirstOrDefault<WSspSelectWareHouse_Result>((IEnumerable<WSspSelectWareHouse_Result>)list5, (Func<WSspSelectWareHouse_Result, bool>)((WSspSelectWareHouse_Result x) => x.WareHouseID == CS_0024_003C_003E8__locals2.pordI.pordIWHId));
							if (wSspSelectWareHouse_Result2 != null && !string.IsNullOrWhiteSpace(wSspSelectWareHouse_Result2.WrhsLinkAccWareHouses))
							{
								List<CommonWithIdStrViewModel> list9 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(wSspSelectWareHouse_Result2.WrhsLinkAccWareHouses);
								if (list9 != null && list9.Count > 0)
								{
									CommonWithIdStrViewModel commonWithIdStrViewModel = Enumerable.FirstOrDefault<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list9, (Func<CommonWithIdStrViewModel, bool>)((CommonWithIdStrViewModel x) => x.Code == CS_0024_003C_003E8__locals2.pordI.pordILinkAccWHIdStr));
									if (commonWithIdStrViewModel != null)
									{
										text7 = commonWithIdStrViewModel.Name;
										text6 = commonWithIdStrViewModel.Id;
									}
								}
								else
								{
									wSspSelectWareHouse_Result = Enumerable.FirstOrDefault<WSspSelectWareHouse_Result>((IEnumerable<WSspSelectWareHouse_Result>)list5, (Func<WSspSelectWareHouse_Result, bool>)((WSspSelectWareHouse_Result x) => x.WareHouseID == CS_0024_003C_003E8__locals2.pordI.pordIWHId));
								}
							}
						}
						else
						{
							wSspSelectWareHouse_Result = Enumerable.FirstOrDefault<WSspSelectWareHouse_Result>((IEnumerable<WSspSelectWareHouse_Result>)list5, (Func<WSspSelectWareHouse_Result, bool>)((WSspSelectWareHouse_Result x) => x.WareHouseID == CS_0024_003C_003E8__locals2.pordI.pordIWHId));
							if (wSspSelectWareHouse_Result != null)
							{
								text6 = wSspSelectWareHouse_Result.WrhsLinkAccWhIdStr;
								text7 = wSspSelectWareHouse_Result.WrhsName;
							}
						}
						if (string.IsNullOrWhiteSpace(text6) || string.IsNullOrWhiteSpace(text7))
						{
							text = text + "<br>" + string.Format(Messages.msgErrorWareHouseNotFoundInAccLink, (wSspSelectWareHouse_Result != null) ? wSspSelectWareHouse_Result.WrhsName : "", Labels.ShygunII);
						}
						WSspSelectProductWithAccLinkField_Result wSspSelectProductWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectProductWithAccLinkField_Result>((IEnumerable<WSspSelectProductWithAccLinkField_Result>)list3, (Func<WSspSelectProductWithAccLinkField_Result, bool>)((WSspSelectProductWithAccLinkField_Result x) => x.ProductID == CS_0024_003C_003E8__locals2.pordI.pordIPrdId));
						if (wSspSelectProductWithAccLinkField_Result == null)
						{
							text = text + "<br>" + string.Format(Messages.msgErrorProductNotFoundInAccLink, CS_0024_003C_003E8__locals2.pordI.PrdName ?? "", Labels.ShygunII);
						}
						else if (string.IsNullOrWhiteSpace(wSspSelectProductWithAccLinkField_Result.PrdLinkAccPrdIdStr))
						{
							text = text + "<br>" + string.Format(Messages.msgErrorProductNotFoundInAccLink, wSspSelectProductWithAccLinkField_Result.PrdName ?? "", Labels.ShygunII);
						}
						if (string.IsNullOrWhiteSpace(text))
						{
							InvoiceBody invoiceBody = new InvoiceBody();
							invoiceBody.ItemNumber = wSspSelectProductWithAccLinkField_Result.PrdLinkAccPrdCode;
							invoiceBody.ItemGuId = Guid.Parse(wSspSelectProductWithAccLinkField_Result.PrdLinkAccPrdIdStr);
							invoiceBody.ItemDescription = CS_0024_003C_003E8__locals2.pordI.pordIDescription ?? "";
							invoiceBody.Price = CS_0024_003C_003E8__locals2.pordI.pordIPrice.GetValueOrDefault();
							invoiceBody.Amount = CS_0024_003C_003E8__locals2.pordI.pordITotalPrice;
							if (CS_0024_003C_003E8__locals2.pordI.pordIDiscount.HasValue)
							{
								invoiceBody.LineDiscAmount = CS_0024_003C_003E8__locals2.pordI.pordIDiscount;
							}
							else if (CS_0024_003C_003E8__locals2.pordI.pordIDiscountPercent.HasValue)
							{
								invoiceBody.LineDiscPer = CS_0024_003C_003E8__locals2.pordI.pordIDiscountPercent;
								WSspSelectPreOrderItems_Result pordI = CS_0024_003C_003E8__locals2.pordI;
								decimal valueOrDefault = CS_0024_003C_003E8__locals2.pordI.pordIPrice.GetValueOrDefault();
								decimal? pordIDiscountPercent = CS_0024_003C_003E8__locals2.pordI.pordIDiscountPercent;
								pordI.pordIDiscount = (decimal?)valueOrDefault * pordIDiscountPercent / (decimal?)100;
							}
							invoiceBody.Price -= (decimal?)CS_0024_003C_003E8__locals2.pordI.pordIDiscount.GetValueOrDefault();
							double num3 = CS_0024_003C_003E8__locals2.pordI.pordIQuantity.GetValueOrDefault(1.0) * CS_0024_003C_003E8__locals2.pordI.pordIFCR.GetValueOrDefault(1.0) * CS_0024_003C_003E8__locals2.pordI.pordIFCRI.GetValueOrDefault(1.0);
							invoiceBody.Quan = ((num3 > 0.0) ? decimal.Parse(num3.ToString()) : 0m);
							invoiceBody.LineItemDesc = CS_0024_003C_003E8__locals2.pordI.pordIDescription;
							invoiceBody.STGuId = Guid.Parse(text6);
							invoiceBody.STDesc = text7;
							num += CS_0024_003C_003E8__locals2.pordI.pordITaxSum.GetValueOrDefault();
							num2 += (CS_0024_003C_003E8__locals2.pordI.pordIRound.GetValueOrDefault() - CS_0024_003C_003E8__locals2.pordI.pordIRoundPlus.GetValueOrDefault()) * decimal.Parse(num3.ToString());
							invoiceBody.GuId = Guid.NewGuid();
							invoiceBody.UpdateKind = ActionType.insert;
							if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals2.pordI.pordILinkAccItemIdStr))
							{
								invoiceBody.GuId = Guid.Parse(CS_0024_003C_003E8__locals2.pordI.pordILinkAccItemIdStr);
								invoiceBody.UpdateKind = ActionType.insertOrUpdate;
							}
							DbSet<WSPreOrderItems> wSPreOrderItems = _dbTbl.WSPreOrderItems;
							ParameterExpression val = Expression.Parameter(typeof(WSPreOrderItems), "x");
							WSPreOrderItems wSPreOrderItems2 = Queryable.FirstOrDefault<WSPreOrderItems>((IQueryable<WSPreOrderItems>)wSPreOrderItems, Expression.Lambda<Func<WSPreOrderItems, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals2, typeof(_003C_003Ec__DisplayClass84_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (wSPreOrderItems2 != null)
							{
								_dbTbl.Entry(wSPreOrderItems2).State = EntityState.Modified;
								wSPreOrderItems2.pordILinkAccItemIdStr = invoiceBody.GuId.ToString();
								_dbTbl.Configuration.ValidateOnSaveEnabled = false;
								_dbTbl.SaveChanges();
								_dbTbl.Configuration.ValidateOnSaveEnabled = true;
							}
							list7.Add(invoiceBody);
						}
					}
				}
				invoice.Body = list7;
				List<InvoiceExpense> list10 = new List<InvoiceExpense>();
				if (num > 0m)
				{
					CS_0024_003C_003E8__locals1.pord.pordTax = CS_0024_003C_003E8__locals1.pord.pordTax.GetValueOrDefault() + num;
				}
				if (num2 > 0m)
				{
					CS_0024_003C_003E8__locals1.pord.pordRound = CS_0024_003C_003E8__locals1.pord.pordRound.GetValueOrDefault() + num2;
				}
				if (!string.IsNullOrWhiteSpace(shygunIISetting.DefTax))
				{
					decimal? pordTax = CS_0024_003C_003E8__locals1.pord.pordTax;
					if ((pordTax.GetValueOrDefault() > default(decimal)) & pordTax.HasValue)
					{
						InvoiceExpense invoiceExpense = new InvoiceExpense();
						invoiceExpense.AccountNumber = shygunIISetting.DefTax;
						invoiceExpense.AccountName = shygunIISetting.DefTaxFieldTitle;
						invoiceExpense.InvExpRowAmount = CS_0024_003C_003E8__locals1.pord.pordTax;
						invoiceExpense.UpdateKind = ActionType.insert;
						if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals1.pord.pordLinkAccPreOrderIdStr))
						{
							invoiceExpense.UpdateKind = ActionType.insertOrUpdate;
						}
						list10.Add(invoiceExpense);
					}
				}
				if (!string.IsNullOrWhiteSpace(shygunIISetting.DefTransportation))
				{
					decimal? pordTax = CS_0024_003C_003E8__locals1.pord.pordTransportation;
					if ((pordTax.GetValueOrDefault() > default(decimal)) & pordTax.HasValue)
					{
						InvoiceExpense invoiceExpense2 = new InvoiceExpense();
						invoiceExpense2.AccountNumber = shygunIISetting.DefTransportation;
						invoiceExpense2.AccountName = shygunIISetting.DefTransportationFieldTitle;
						invoiceExpense2.InvExpRowAmount = CS_0024_003C_003E8__locals1.pord.pordTransportation;
						invoiceExpense2.UpdateKind = ActionType.insert;
						if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals1.pord.pordLinkAccPreOrderIdStr))
						{
							invoiceExpense2.UpdateKind = ActionType.insertOrUpdate;
						}
						list10.Add(invoiceExpense2);
					}
				}
				if (!string.IsNullOrWhiteSpace(shygunIISetting.DefRound))
				{
					decimal? pordTax = CS_0024_003C_003E8__locals1.pord.pordRound;
					if ((pordTax.GetValueOrDefault() > default(decimal)) & pordTax.HasValue)
					{
						InvoiceExpense invoiceExpense3 = new InvoiceExpense();
						invoiceExpense3.AccountNumber = shygunIISetting.DefRound;
						invoiceExpense3.AccountName = shygunIISetting.DefRoundFieldTitle;
						invoiceExpense3.InvExpRowAmount = CS_0024_003C_003E8__locals1.pord.pordRound;
						invoiceExpense3.UpdateKind = ActionType.insert;
						if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals1.pord.pordLinkAccPreOrderIdStr))
						{
							invoiceExpense3.UpdateKind = ActionType.insertOrUpdate;
						}
						list10.Add(invoiceExpense3);
					}
				}
				invoice.Expense = list10;
				if (string.IsNullOrWhiteSpace(text))
				{
					list6.Add(invoice);
					if (!string.IsNullOrWhiteSpace(text2))
					{
						text2 += ",";
					}
					text2 += CS_0024_003C_003E8__locals1.pord.PreOrderID;
				}
			}
			if (list6 != null && list6.Count > 0 && string.IsNullOrWhiteSpace(text))
			{
				PutResults putResults = new WebServiePutInvoice(shygunIISetting.IP, shygunIISetting.conf, list6).PutOperation();
				if (string.IsNullOrWhiteSpace(putResults.ErrorMessage))
				{
					string[] array2 = text2.Split(new char[1] { ',' });
					for (int i = 0; i < array2.Length; i++)
					{
						text = putResults.Result[i].ErrorMessage;
						if (!string.IsNullOrWhiteSpace(text))
						{
							continue;
						}
						_003C_003Ec__DisplayClass84_3 _003C_003Ec__DisplayClass84_ = new _003C_003Ec__DisplayClass84_3();
						_003C_003Ec__DisplayClass84_.Id = 0;
						int.TryParse(array2[i], out _003C_003Ec__DisplayClass84_.Id);
						DbSet<WSPreOrder> wSPreOrder5 = _dbTbl.WSPreOrder;
						ParameterExpression val = Expression.Parameter(typeof(WSPreOrder), "m");
						WSPreOrder wSPreOrder6 = Queryable.FirstOrDefault<WSPreOrder>((IQueryable<WSPreOrder>)wSPreOrder5, Expression.Lambda<Func<WSPreOrder, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass84_, typeof(_003C_003Ec__DisplayClass84_3)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
						if (wSPreOrder6 != null)
						{
							_dbTbl.Entry(wSPreOrder6).State = EntityState.Modified;
							wSPreOrder6.pordLinkAccPreOrderNumber = putResults.Result[i].Number;
							wSPreOrder6.pordLinkAccPreOrderIdStr = putResults.Result[i].GuId;
							_dbTbl.Configuration.ValidateOnSaveEnabled = false;
							_dbTbl.SaveChanges();
							_dbTbl.Configuration.ValidateOnSaveEnabled = true;
							if (!sendPordPayToAcc)
							{
								continue;
							}
							string text8 = "";
							string text9 = ShygunIISendPayment(wSPreOrder6.PreOrderID);
							if (!string.IsNullOrWhiteSpace(text9))
							{
								string[] array3 = text9.Split(new char[1] { '|' });
								if (array3 != null && array3.Length != 0 && array3[0] != "1")
								{
									text8 = ((!string.IsNullOrWhiteSpace(array3[0])) ? (array3[0] + "<br>") : "");
								}
								if (!string.IsNullOrWhiteSpace(text8))
								{
									text = text + "<br>" + text8 + "<br>";
								}
							}
						}
						else
						{
							text = "<br>" + Messages.msgErrorInSendToOtherSystem + " " + Labels.OtherSystemsOrder;
						}
					}
				}
				else
				{
					text += putResults.ErrorMessage;
				}
			}
			if (!string.IsNullOrEmpty(text))
			{
				data = 0;
				data2 = new CommonResultViewModel<int>
				{
					Data = data,
					Message = text,
					Status = CommonResultStatusViewModel.Error
				};
				return Json(data2, JsonRequestBehavior.AllowGet);
			}
			text = "";
			commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			data = 0;
			data2 = new CommonResultViewModel<int>
			{
				Data = data,
				Message = Messages.msgErrorRunFunction,
				Status = CommonResultStatusViewModel.Error
			};
			return Json(data2, JsonRequestBehavior.AllowGet);
		}
		data2 = new CommonResultViewModel<int>
		{
			Data = data,
			Message = text,
			Status = commonResultStatusViewModel
		};
		return Json(data2, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetShygunIIExportPreOrderList(int pordOprId, string fDate = "", string tDate = "", long value = 0L, int currentItemId = 0)
	{
		List<OtherSystemSelectedViewModel> list = new List<OtherSystemSelectedViewModel>();
		try
		{
			foreach (CRMspLkWSSelectPreOrder_Result item2 in SelectPreOrderExport(pordOprId, fDate, tDate, value, currentItemId))
			{
				OtherSystemSelectedViewModel item = new OtherSystemSelectedViewModel
				{
					Row = item2.RowNumber.GetValueOrDefault(),
					Id = item2.PreOrderID,
					Selected = string.IsNullOrEmpty(item2.pordLinkAccPreOrderIdStr)
				};
				list.Add(item);
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

	[DynamicAuthorize(ControllerName = "frmPreOrder", ActionName = "actManagePordLinkAcc,actSendToAcc,actSendPayToAcc,actSendAllPayToAcc")]
	public ActionResult ShygunIIManagePordLinkAcc()
	{
		GetPreOrderOpr();
		GetCrmWh();
		GetPordReferUser();
		GetShygunIIAccountNumber();
		int num = 0;
		DbSet<CrmLinkAccShygunIISetting> crmLinkAccShygunIISetting = _dbTbl.CrmLinkAccShygunIISetting;
		ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccShygunIISetting), "x");
		CrmLinkAccShygunIISetting crmLinkAccShygunIISetting2 = Queryable.FirstOrDefault<CrmLinkAccShygunIISetting>((IQueryable<CrmLinkAccShygunIISetting>)crmLinkAccShygunIISetting, Expression.Lambda<Func<CrmLinkAccShygunIISetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)this, typeof(PreOrderController)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
		if (crmLinkAccShygunIISetting2 != null)
		{
			num = ((!string.IsNullOrWhiteSpace(crmLinkAccShygunIISetting2.PartValue)) ? int.Parse(crmLinkAccShygunIISetting2.PartValue) : 0);
		}
		base.ViewBag.SyncTypeId = num;
		return View();
	}

	[HttpPost]
	public JsonResult ShygunIIDeleteImportedInfo(string records)
	{
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
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
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			new List<LinkedCompanyWithAccViewModel>();
			List<OtherSystemSelectedVIiewModel> list = new List<OtherSystemSelectedVIiewModel>();
			string text3 = "";
			int num = 0;
			if (!UserLogin.IsUserAccess("frmManagePordLinkAcc", "actDeleteImportedInfo", UserLogin.CurrentUser))
			{
				text3 = text3 + Messages.ErrorNotAccess + "<br>";
				num++;
			}
			if (string.IsNullOrWhiteSpace(records))
			{
				text3 = text3 + Messages.msgErrorNotSelectedItem + "<br>";
				num++;
			}
			else
			{
				List<OtherSystemSelectedVIiewModel> list2 = new List<OtherSystemSelectedVIiewModel>();
				if (!string.IsNullOrWhiteSpace(records))
				{
					list2 = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedVIiewModel>>(records);
					if (Enumerable.Any<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list2))
					{
						list = Enumerable.ToList<OtherSystemSelectedVIiewModel>(Enumerable.Where<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list2, (Func<OtherSystemSelectedVIiewModel, bool>)((OtherSystemSelectedVIiewModel m) => m.Selected)));
					}
				}
			}
			string text4 = "";
			if (list == null && !Enumerable.Any<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list))
			{
				text3 = Messages.msgErrorNotSelectedItem + "<br>";
				num++;
			}
			else
			{
				foreach (OtherSystemSelectedVIiewModel item in list)
				{
					text4 = text4 + item.Id + ",";
				}
			}
			if (string.IsNullOrWhiteSpace(text4))
			{
				text3 = Messages.msgErrorNotSelectedItem + "<br>";
				num++;
			}
			if (num == 0)
			{
				string text5 = "";
				text = "";
				List<CRMspLkShygunIIWSDeleteLinkedPreOrder_Result> list3 = Enumerable.ToList<CRMspLkShygunIIWSDeleteLinkedPreOrder_Result>((IEnumerable<CRMspLkShygunIIWSDeleteLinkedPreOrder_Result>)_dbLink.CRMspLkShygunIIWSDeleteLinkedPreOrder(text4, lCID, result));
				if (list3 != null && Enumerable.Any<CRMspLkShygunIIWSDeleteLinkedPreOrder_Result>((IEnumerable<CRMspLkShygunIIWSDeleteLinkedPreOrder_Result>)list3))
				{
					text = "error";
					text5 = GetFileShygunIINotDeletedImportedInfo(list3);
				}
				if (!string.IsNullOrWhiteSpace(text5))
				{
					text2 = Messages.msgNotCompeleteSuccessAction;
					text2 = text2 + "<br><a href='" + text5 + "' class='link-excel-file' target='_blank'>" + Messages.msgLinkForDownloadFileWithError + "</a>";
				}
				else
				{
					text2 = Messages.msgSuccessAction;
				}
				commonResultStatusViewModel = CommonResultStatusViewModel.Success;
			}
			else
			{
				text = "";
				text2 = text3;
				commonResultStatusViewModel = CommonResultStatusViewModel.Error;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			text = "";
			data = new CommonResultViewModel<string>
			{
				Data = text,
				Message = Messages.msgErrorRunFunction + "<br>" + ex.Message,
				Status = CommonResultStatusViewModel.Error
			};
			return Json(data, JsonRequestBehavior.AllowGet);
		}
		data = new CommonResultViewModel<string>
		{
			Data = text,
			Message = text2,
			Status = commonResultStatusViewModel
		};
		JsonResult jsonResult = Json(data, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public string GetFileShygunIINotDeletedImportedInfo(List<CRMspLkShygunIIWSDeleteLinkedPreOrder_Result> res)
	{
		//IL_0343: Unknown result type (might be due to invalid IL or missing references)
		//IL_035e: Unknown result type (might be due to invalid IL or missing references)
		string text = "";
		Guid.NewGuid().ToString();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			int userId = UserLogin.CurrentUser.UserId;
			if (res != null && Enumerable.Any<CRMspLkShygunIIWSDeleteLinkedPreOrder_Result>((IEnumerable<CRMspLkShygunIIWSDeleteLinkedPreOrder_Result>)res))
			{
				ExcelPackage excelPackage = new ExcelPackage();
				ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add(Labels.OtherSystemsExcelPropertiesTitle);
				int num = 0;
				int num2 = 1;
				num++;
				excelWorksheet.Cells[num2, num].Value = string.Format(Labels.OtherSystemsImListPordNumber, "CRM");
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsImListPordNumber + " (" + Labels.ShygunII + ")";
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsLinkedListCmpName;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListLinkDesc;
				foreach (CRMspLkShygunIIWSDeleteLinkedPreOrder_Result re in res)
				{
					num2++;
					num = 0;
					num++;
					excelWorksheet.Cells[num2, num].Value = re.pordNumber.ToString();
					num++;
					excelWorksheet.Cells[num2, num].Value = re.pordLinkAccPreOrderNumber ?? "";
					num++;
					excelWorksheet.Cells[num2, num].Value = re.CompanyName ?? "";
					string redundancyMessage = Messages.RedundancyMessage;
					num++;
					excelWorksheet.Cells[num2, num].Value = redundancyMessage;
				}
				string text2 = base.Server.MapPath(Configuration.HostTempFilesPath) + "\\ReportLinkAccNotDeletedInfo\\" + userId;
				string text3 = "CRM-Ideal-" + DateTime.Now.ToString("dd-MM-yyyy-hh-mm-ss") + ".xls";
				string path = text2 + "\\" + text3;
				try
				{
					DirectoryInfo directoryInfo = new DirectoryInfo(text2);
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
					if (System.IO.Directory.Exists(text2))
					{
						System.IO.Directory.Delete(text2);
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
				}
				if (!System.IO.Directory.Exists(text2))
				{
					System.IO.Directory.CreateDirectory(text2);
					CRM.General.IO.Directory.SetFullControlForEveryOne(text2);
				}
				using (ExcelRange excelRange = excelWorksheet.Cells[1, 1, 1, num])
				{
					excelRange.Style.Font.Bold = true;
					excelRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
					excelRange.Style.Fill.BackgroundColor.SetColor(Color.DarkBlue);
					excelRange.Style.Font.Color.SetColor(Color.White);
				}
				excelPackage.Workbook.Properties.Title = Labels.OtherSystemsExcelPropertiesTitle;
				excelPackage.Workbook.Properties.Company = Labels.OtherSystemsExcelPropertiesCompany;
				Stream stream = System.IO.File.Create(path);
				excelPackage.SaveAs(stream);
				stream.Close();
				if (System.IO.File.Exists(path))
				{
					text = Configuration.HostTempFilesPath + "/ReportLinkAccNotDeletedInfo/" + userId + "/" + text3;
					text = text.Replace("~/", "/");
					text = (text.StartsWith("/") ? text : ("/" + text));
				}
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return text;
	}

	[AjaxOnly]
	public JsonResult GetShygunIIAccountNumber()
	{
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			CRMspSelectLinkAccShygunIISetting_Result cRMspSelectLinkAccShygunIISetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunIISetting_Result>((IEnumerable<CRMspSelectLinkAccShygunIISetting_Result>)_dbLink.CRMspSelectLinkAccShygunIISetting(25, "Order", lCID, result));
			if (cRMspSelectLinkAccShygunIISetting_Result != null && !string.IsNullOrWhiteSpace(cRMspSelectLinkAccShygunIISetting_Result.PartValue) && cRMspSelectLinkAccShygunIISetting_Result.PartValue.IndexOf("[{") >= 0)
			{
				List<CrmLinkAccShygunIIAccountInfoViewModel> list2 = new JavaScriptSerializer().Deserialize<List<CrmLinkAccShygunIIAccountInfoViewModel>>(cRMspSelectLinkAccShygunIISetting_Result.PartValue);
				if (list2 != null && Enumerable.Any<CrmLinkAccShygunIIAccountInfoViewModel>((IEnumerable<CrmLinkAccShygunIIAccountInfoViewModel>)list2))
				{
					foreach (CrmLinkAccShygunIIAccountInfoViewModel item2 in list2)
					{
						string text = "";
						text = item2.Name + " (" + item2.Code + ")";
						SelectListItem item = new SelectListItem
						{
							Value = item2.GuId + "|" + item2.Code,
							Text = text,
							Selected = false
						};
						list.Add(item);
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.AccountNumberList = list;
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public string ShygunIISendPayment(int pordId, int payId = 0, int mode = 1)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		try
		{
			DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(Financial.Get().Id.ToString());
			short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			_ = UserLogin.CurrentUser.UserId;
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			_ = Financial.Get().Id;
			if (CRMIdeal.Classes.Helper.OtherSystems.GetShygunIISetting() == null)
			{
				return Messages.errorInReadingSetting + "|";
			}
			switch (mode)
			{
			case 2:
				if (!UserLogin.IsUserAccess("frmPreOrder", "actSendPayToAcc", currentUser))
				{
					return Messages.ErrorNotAccess + "|";
				}
				if (payId == 0)
				{
					return Messages.ErrorNotFound + "|";
				}
				break;
			case 3:
				if (!UserLogin.IsUserAccess("frmPreOrder", "actSendAllPayToAcc", currentUser))
				{
					return Messages.ErrorNotAccess + "|";
				}
				break;
			}
			if (pordId > 0)
			{
				if (mode == 2 && payId != 0)
				{
					return ShygunIISendPaymentByPayId(pordId, payId);
				}
				string text2 = "";
				List<WSspSelectPreOrderPayments_Result> list = Enumerable.ToList<WSspSelectPreOrderPayments_Result>((IEnumerable<WSspSelectPreOrderPayments_Result>)_db.WSspSelectPreOrderPayments(pordId, lCID, result));
				if (list != null && Enumerable.Any<WSspSelectPreOrderPayments_Result>((IEnumerable<WSspSelectPreOrderPayments_Result>)list))
				{
					foreach (WSspSelectPreOrderPayments_Result item in list)
					{
						string text3 = ShygunIISendPaymentByPayId(pordId, item.PreOrderPaymentId);
						if (!string.IsNullOrWhiteSpace(text3))
						{
							string[] array = text3.Split(new char[1] { '|' });
							if (array != null && array.Length != 0 && array[0] != "1")
							{
								text2 += ((!string.IsNullOrWhiteSpace(array[0])) ? (array[0] + "<br>") : "");
							}
						}
					}
				}
				if (!string.IsNullOrWhiteSpace(text2))
				{
					return text2 + "|";
				}
				return "1|";
			}
			return Messages.ErrorNotFound + "|";
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			return Messages.msgErrorRunFunction + "<br>" + ex.Message + "|";
		}
	}

	public string ShygunIISendPaymentByPayId(int pordId, int payId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		try
		{
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(Financial.Get().Id.ToString());
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			_ = UserLogin.CurrentUser;
			int id = Financial.Get().Id;
			WSspSelectPreOrderPaymentsWithId_Result wSspSelectPreOrderPaymentsWithId_Result = Enumerable.FirstOrDefault<WSspSelectPreOrderPaymentsWithId_Result>((IEnumerable<WSspSelectPreOrderPaymentsWithId_Result>)_dbI.WSspSelectPreOrderPaymentsWithId(payId, lCID, result));
			if (wSspSelectPreOrderPaymentsWithId_Result == null)
			{
				return Messages.ErrorNotFound + "|";
			}
			CRMIdeal.Classes.Helper.OtherSystems.ShygunIISettingViewModel shygunIISetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunIISetting();
			if (shygunIISetting == null)
			{
				return Messages.errorInReadingSetting + "|";
			}
			if (pordId <= 0)
			{
				return Messages.ErrorNotFound + "|";
			}
			string text2 = "";
			string text3 = "";
			string jobCostingNumber = "";
			string text4 = "";
			WSspSelectPreOrderWithId_Result wSspSelectPreOrderWithId_Result = Enumerable.FirstOrDefault<WSspSelectPreOrderWithId_Result>((IEnumerable<WSspSelectPreOrderWithId_Result>)_db.WSspSelectPreOrderWithId(pordId, lCID, result));
			if (wSspSelectPreOrderWithId_Result != null)
			{
				text2 = wSspSelectPreOrderWithId_Result.pordLinkAccPreOrderIdStr ?? "";
				text4 = wSspSelectPreOrderWithId_Result.pordNumber.ToString();
				CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(wSspSelectPreOrderWithId_Result.pordCompanyId.GetValueOrDefault());
				if (companyById != null)
				{
					text3 = companyById.cmpLinkAccCustomerIdStr ?? "";
					jobCostingNumber = companyById.cmpLinkAccCode ?? "";
				}
			}
			string text5 = "";
			string text6 = "";
			string text7 = "";
			string text8 = "";
			string text9 = "";
			string text10 = "";
			string text11 = "";
			string text12 = "";
			string text13 = "";
			string text14 = "";
			List<CRMspSelectLinkAccShygunIISettingDetails_Result> list = Enumerable.ToList<CRMspSelectLinkAccShygunIISettingDetails_Result>((IEnumerable<CRMspSelectLinkAccShygunIISettingDetails_Result>)_dbLink.CRMspSelectLinkAccShygunIISettingDetails(0, wSspSelectPreOrderPaymentsWithId_Result.pordpayTypeId, "OrdPayType", lCID, result));
			if (list == null || !Enumerable.Any<CRMspSelectLinkAccShygunIISettingDetails_Result>((IEnumerable<CRMspSelectLinkAccShygunIISettingDetails_Result>)list))
			{
				return Messages.errorInReadingSetting + " (" + wSspSelectPreOrderPaymentsWithId_Result.pordpayType + ")|";
			}
			CRMspSelectLinkAccShygunIISettingDetails_Result cRMspSelectLinkAccShygunIISettingDetails_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunIISettingDetails_Result>((IEnumerable<CRMspSelectLinkAccShygunIISettingDetails_Result>)list, (Func<CRMspSelectLinkAccShygunIISettingDetails_Result, bool>)((CRMspSelectLinkAccShygunIISettingDetails_Result m) => m.PartTitle == "ShygunVoucherType"));
			if (cRMspSelectLinkAccShygunIISettingDetails_Result != null)
			{
				text5 = cRMspSelectLinkAccShygunIISettingDetails_Result.PartValue ?? "";
				if (string.IsNullOrWhiteSpace(text5))
				{
					return string.Format(Messages.msgErrorIsNotEnteredItem, cRMspSelectLinkAccShygunIISettingDetails_Result.PartDescription ?? "") + "|";
				}
			}
			if (string.IsNullOrWhiteSpace(text5))
			{
				return Messages.errorInReadingSetting + " (" + wSspSelectPreOrderPaymentsWithId_Result.pordpayType + ")|";
			}
			CRMspSelectLinkAccShygunIISettingDetails_Result cRMspSelectLinkAccShygunIISettingDetails_Result2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunIISettingDetails_Result>((IEnumerable<CRMspSelectLinkAccShygunIISettingDetails_Result>)list, (Func<CRMspSelectLinkAccShygunIISettingDetails_Result, bool>)((CRMspSelectLinkAccShygunIISettingDetails_Result m) => m.PartTitle == "ShygunAccountNumber"));
			if (cRMspSelectLinkAccShygunIISettingDetails_Result2 != null)
			{
				text6 = cRMspSelectLinkAccShygunIISettingDetails_Result2.PartValue ?? "";
				if (string.IsNullOrWhiteSpace(text6))
				{
					return string.Format(Messages.msgErrorIsNotEnteredItem, cRMspSelectLinkAccShygunIISettingDetails_Result2.PartDescription ?? "") + "|";
				}
			}
			if (string.IsNullOrWhiteSpace(text6))
			{
				return Messages.errorInReadingSetting + " (" + wSspSelectPreOrderPaymentsWithId_Result.pordpayType + ")|";
			}
			CRMspSelectLinkAccShygunIISettingDetails_Result cRMspSelectLinkAccShygunIISettingDetails_Result3 = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunIISettingDetails_Result>((IEnumerable<CRMspSelectLinkAccShygunIISettingDetails_Result>)list, (Func<CRMspSelectLinkAccShygunIISettingDetails_Result, bool>)((CRMspSelectLinkAccShygunIISettingDetails_Result m) => m.PartTitle == "ShygunVoucherDate"));
			if (cRMspSelectLinkAccShygunIISettingDetails_Result3 != null)
			{
				text7 = cRMspSelectLinkAccShygunIISettingDetails_Result3.PartValue ?? "";
				if (string.IsNullOrWhiteSpace(text7))
				{
					return string.Format(Messages.msgErrorIsNotEnteredItem, cRMspSelectLinkAccShygunIISettingDetails_Result3.PartDescription ?? "") + "|";
				}
			}
			if (string.IsNullOrWhiteSpace(text7))
			{
				return Messages.errorInReadingSetting + " (" + wSspSelectPreOrderPaymentsWithId_Result.pordpayType + ")|";
			}
			CRMspSelectLinkAccShygunIISettingDetails_Result cRMspSelectLinkAccShygunIISettingDetails_Result4 = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunIISettingDetails_Result>((IEnumerable<CRMspSelectLinkAccShygunIISettingDetails_Result>)list, (Func<CRMspSelectLinkAccShygunIISettingDetails_Result, bool>)((CRMspSelectLinkAccShygunIISettingDetails_Result m) => m.PartTitle == "ShygunCurrency"));
			if (cRMspSelectLinkAccShygunIISettingDetails_Result4 != null)
			{
				text8 = cRMspSelectLinkAccShygunIISettingDetails_Result4.PartValue ?? "IRR";
				if (string.IsNullOrWhiteSpace(text8))
				{
					return string.Format(Messages.msgErrorIsNotEnteredItem, cRMspSelectLinkAccShygunIISettingDetails_Result4.PartDescription ?? "") + "|";
				}
			}
			if (string.IsNullOrWhiteSpace(text8))
			{
				text8 = "IRR";
			}
			CRMspSelectLinkAccShygunIISettingDetails_Result cRMspSelectLinkAccShygunIISettingDetails_Result5 = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunIISettingDetails_Result>((IEnumerable<CRMspSelectLinkAccShygunIISettingDetails_Result>)list, (Func<CRMspSelectLinkAccShygunIISettingDetails_Result, bool>)((CRMspSelectLinkAccShygunIISettingDetails_Result m) => m.PartTitle == "ShygunCurrencyRate"));
			if (cRMspSelectLinkAccShygunIISettingDetails_Result5 != null)
			{
				text9 = cRMspSelectLinkAccShygunIISettingDetails_Result5.PartValue ?? "1";
				if (string.IsNullOrWhiteSpace(text9))
				{
					return string.Format(Messages.msgErrorIsNotEnteredItem, cRMspSelectLinkAccShygunIISettingDetails_Result5.PartDescription ?? "") + "|";
				}
			}
			if (string.IsNullOrWhiteSpace(text9))
			{
				text9 = "1";
			}
			CRMspSelectLinkAccShygunIISettingDetails_Result cRMspSelectLinkAccShygunIISettingDetails_Result6 = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunIISettingDetails_Result>((IEnumerable<CRMspSelectLinkAccShygunIISettingDetails_Result>)list, (Func<CRMspSelectLinkAccShygunIISettingDetails_Result, bool>)((CRMspSelectLinkAccShygunIISettingDetails_Result m) => m.PartTitle == "ShygunDepartmentNumber"));
			if (cRMspSelectLinkAccShygunIISettingDetails_Result6 != null)
			{
				text10 = cRMspSelectLinkAccShygunIISettingDetails_Result6.PartValue ?? "";
			}
			CRMspSelectLinkAccShygunIISettingDetails_Result cRMspSelectLinkAccShygunIISettingDetails_Result7 = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunIISettingDetails_Result>((IEnumerable<CRMspSelectLinkAccShygunIISettingDetails_Result>)list, (Func<CRMspSelectLinkAccShygunIISettingDetails_Result, bool>)((CRMspSelectLinkAccShygunIISettingDetails_Result m) => m.PartTitle == "ShygunPayType"));
			if (cRMspSelectLinkAccShygunIISettingDetails_Result7 != null)
			{
				text11 = cRMspSelectLinkAccShygunIISettingDetails_Result7.PartValue ?? "";
				if (string.IsNullOrWhiteSpace(text11))
				{
					return string.Format(Messages.msgErrorIsNotEnteredItem, cRMspSelectLinkAccShygunIISettingDetails_Result7.PartDescription ?? "") + "|";
				}
			}
			if (string.IsNullOrWhiteSpace(text11))
			{
				return Messages.errorInReadingSetting + " (" + wSspSelectPreOrderPaymentsWithId_Result.pordpayType + ")|";
			}
			CRMspSelectLinkAccShygunIISettingDetails_Result cRMspSelectLinkAccShygunIISettingDetails_Result8 = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunIISettingDetails_Result>((IEnumerable<CRMspSelectLinkAccShygunIISettingDetails_Result>)list, (Func<CRMspSelectLinkAccShygunIISettingDetails_Result, bool>)((CRMspSelectLinkAccShygunIISettingDetails_Result m) => m.PartTitle == "ShygunDueDate"));
			if (cRMspSelectLinkAccShygunIISettingDetails_Result8 != null)
			{
				text12 = cRMspSelectLinkAccShygunIISettingDetails_Result8.PartValue ?? "";
			}
			CRMspSelectLinkAccShygunIISettingDetails_Result cRMspSelectLinkAccShygunIISettingDetails_Result9 = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunIISettingDetails_Result>((IEnumerable<CRMspSelectLinkAccShygunIISettingDetails_Result>)list, (Func<CRMspSelectLinkAccShygunIISettingDetails_Result, bool>)((CRMspSelectLinkAccShygunIISettingDetails_Result m) => m.PartTitle == "ShygunBankTabNumber"));
			if (cRMspSelectLinkAccShygunIISettingDetails_Result9 != null)
			{
				text13 = cRMspSelectLinkAccShygunIISettingDetails_Result9.PartValue ?? "";
			}
			CRMspSelectLinkAccShygunIISettingDetails_Result cRMspSelectLinkAccShygunIISettingDetails_Result10 = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunIISettingDetails_Result>((IEnumerable<CRMspSelectLinkAccShygunIISettingDetails_Result>)list, (Func<CRMspSelectLinkAccShygunIISettingDetails_Result, bool>)((CRMspSelectLinkAccShygunIISettingDetails_Result m) => m.PartTitle == "ShygunBankBranchCode"));
			if (cRMspSelectLinkAccShygunIISettingDetails_Result10 != null)
			{
				text14 = cRMspSelectLinkAccShygunIISettingDetails_Result10.PartValue ?? "";
			}
			List<Voucher> list2 = new List<Voucher>();
			Voucher voucher = new Voucher();
			voucher.AccountNumber = text6 ?? "";
			voucher.JobCostingNumber = jobCostingNumber;
			if (!string.IsNullOrWhiteSpace(text3))
			{
				voucher.JobCostingGuId = Guid.Parse(text3);
			}
			if (!string.IsNullOrWhiteSpace(text2))
			{
				voucher.InvoiceGuid = Guid.Parse(text2);
			}
			voucher.DepartmentNumber = text10 ?? "";
			voucher.CurrencyAbb1 = text8 ?? "IRR";
			voucher.Rate = double.Parse(text9 ?? "1");
			if (int.Parse(text5 ?? "0") == 21)
			{
				voucher.VouchType = VouchType.Input;
			}
			else if (int.Parse(text5 ?? "0") == 22)
			{
				voucher.VouchType = VouchType.OutPut;
			}
			voucher.VouchDesc = wSspSelectPreOrderPaymentsWithId_Result.pordpayDescription ?? "";
			if (int.Parse(text7 ?? "0") == 1)
			{
				voucher.VouchDate = (wSspSelectPreOrderPaymentsWithId_Result.ImportDateTime.HasValue ? wSspSelectPreOrderPaymentsWithId_Result.ImportDateTime.Value.ToString("yyyyMMdd") : DateTime.Now.ToString("yyyyMMdd", new CultureInfo("en-US")));
			}
			else if (int.Parse(text7 ?? "0") == 2)
			{
				voucher.VouchDate = (wSspSelectPreOrderPaymentsWithId_Result.pordpayDocDateTime.HasValue ? wSspSelectPreOrderPaymentsWithId_Result.pordpayDocDateTime.Value.ToString("yyyyMMdd") : DateTime.Now.ToString("yyyyMMdd", new CultureInfo("en-US")));
			}
			else
			{
				voucher.VouchDate = DateTime.Now.ToString("yyyyMMdd", new CultureInfo("en-US"));
			}
			voucher.GuId = Guid.NewGuid();
			voucher.UpdateKind = ActionType.insert;
			if (!string.IsNullOrWhiteSpace(wSspSelectPreOrderPaymentsWithId_Result.pordpayLinkAccHeaderIdStr))
			{
				voucher.GuId = Guid.Parse(wSspSelectPreOrderPaymentsWithId_Result.pordpayLinkAccHeaderIdStr);
				voucher.UpdateKind = ActionType.insertOrUpdate;
				string msgErrorPordPayIsAllreadyInLinkAcc = Messages.msgErrorPordPayIsAllreadyInLinkAcc;
				object[] obj = new object[4]
				{
					wSspSelectPreOrderPaymentsWithId_Result.pordpayType ?? "",
					null,
					null,
					null
				};
				_ = wSspSelectPreOrderPaymentsWithId_Result.pordpayAmount;
				obj[1] = $"{wSspSelectPreOrderPaymentsWithId_Result.pordpayAmount:N2}";
				obj[2] = Labels.ShygunII;
				obj[3] = text4;
				return string.Format(msgErrorPordPayIsAllreadyInLinkAcc, obj) + "|";
			}
			List<VoucherBody> list3 = new List<VoucherBody>();
			VoucherBody voucherBody = new VoucherBody();
			if (int.Parse(text11 ?? "0") == 0)
			{
				voucherBody.PayType = 0;
			}
			else if (int.Parse(text11 ?? "0") == 1)
			{
				voucherBody.PayType = 1;
			}
			voucherBody.Amount = double.Parse(wSspSelectPreOrderPaymentsWithId_Result.pordpayAmount.ToString());
			voucherBody.VuchLineDesc = wSspSelectPreOrderPaymentsWithId_Result.pordpayDescription ?? "";
			if (voucherBody.PayType != 0)
			{
				voucherBody.CheckNo = wSspSelectPreOrderPaymentsWithId_Result.pordpayDocNumber ?? "";
				voucherBody.CheckDesc = "";
				if (int.Parse(text12 ?? "0") == 1)
				{
					voucherBody.DueDate = (wSspSelectPreOrderPaymentsWithId_Result.ImportDateTime.HasValue ? wSspSelectPreOrderPaymentsWithId_Result.ImportDateTime.Value.ToString("yyyyMMdd") : DateTime.Now.ToString("yyyyMMdd", new CultureInfo("en-US")));
				}
				else if (int.Parse(text12 ?? "0") == 2)
				{
					voucherBody.DueDate = (wSspSelectPreOrderPaymentsWithId_Result.pordpayDocDateTime.HasValue ? wSspSelectPreOrderPaymentsWithId_Result.pordpayDocDateTime.Value.ToString("yyyyMMdd") : DateTime.Now.ToString("yyyyMMdd", new CultureInfo("en-US")));
				}
				else if (int.Parse(text12 ?? "0") == 0)
				{
					voucherBody.DueDate = DateTime.Now.ToString("yyyyMMdd", new CultureInfo("en-US"));
				}
			}
			voucherBody.BankBranchCode = text14 ?? "";
			voucherBody.BankTabNumber = text13 ?? "";
			voucherBody.GuId = Guid.NewGuid();
			voucherBody.UpdateKind = ActionType.insert;
			if (!string.IsNullOrWhiteSpace(wSspSelectPreOrderPaymentsWithId_Result.pordpayLinkAccDetailIdStr))
			{
				voucherBody.GuId = Guid.Parse(wSspSelectPreOrderPaymentsWithId_Result.pordpayLinkAccDetailIdStr);
				voucherBody.UpdateKind = ActionType.insertOrUpdate;
			}
			if (string.IsNullOrWhiteSpace(wSspSelectPreOrderPaymentsWithId_Result.pordpayLinkAccDetailIdStr))
			{
				wSspSelectPreOrderPaymentsWithId_Result.pordpayLinkAccDetailIdStr = voucherBody.GuId.ToString();
			}
			list3.Add(voucherBody);
			voucher.Body = list3;
			list2.Add(voucher);
			if (list2 != null && list2.Count > 0 && string.IsNullOrWhiteSpace(text))
			{
				PutResults putResults = new WebServiePutVoucher(shygunIISetting.IP, shygunIISetting.conf, list2).PutOperation();
				string errorMessage = putResults.ErrorMessage;
				if (string.IsNullOrWhiteSpace(errorMessage))
				{
					errorMessage = putResults.Result[0].ErrorMessage;
					if (string.IsNullOrWhiteSpace(errorMessage))
					{
						string text15 = putResults.Result[0].Number.ToString();
						string pordpayLinkAccHeaderIdStr = putResults.Result[0].GuId.ToString();
						string pordpayLinkAccDetailIdStr = wSspSelectPreOrderPaymentsWithId_Result.pordpayLinkAccDetailIdStr;
						_dbLink.CRMspUpdatePreOrderPaymentWithLinkAccField(wSspSelectPreOrderPaymentsWithId_Result.PreOrderPaymentId, 0, text15, 0, 0, "", pordpayLinkAccHeaderIdStr, pordpayLinkAccDetailIdStr, "", userId, value2, id, value, registerDatePersian, appType);
						text = "1|" + text15;
					}
					else
					{
						text = Messages.msgErrorRunFunction + "<br>" + errorMessage + "|";
					}
				}
				else
				{
					text = Messages.msgErrorRunFunction + "<br>" + errorMessage + "|";
				}
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			text = Messages.msgErrorRunFunction + "<br>" + ex.Message + "|";
		}
		return text;
	}

	public LkPreOrderInfoViewModelObjects GetNoAvaranCapillaryPreOrderList(string fDate = "", string tDate = "", string number = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		LkPreOrderInfoViewModelObjects lkPreOrderInfoViewModelObjects = new LkPreOrderInfoViewModelObjects();
		List<LkWSPreOrderInfoViewModel> list = new List<LkWSPreOrderInfoViewModel>();
		List<LkWSPreOrderItemsInfoViewModel> list2 = new List<LkWSPreOrderItemsInfoViewModel>();
		try
		{
			CRMIdeal.Classes.Helper.OtherSystems.NoAvaranCapillarySettingViewModel noAvaranCapillarySetting = CRMIdeal.Classes.Helper.OtherSystems.GetNoAvaranCapillarySetting();
			if (noAvaranCapillarySetting != null)
			{
				string text = noAvaranCapillarySetting.ApiUserId ?? "";
				if (!string.IsNullOrWhiteSpace(text))
				{
					string fromDate = "";
					string toDate = "";
					try
					{
						DateTime now = DateTime.Now;
						DateTime now2 = DateTime.Now;
						if (!string.IsNullOrWhiteSpace(fDate))
						{
							fDate = fDate.Replace("/", "").Replace("-", "").Replace("\\", "")
								.Replace(" ", "")
								.Replace("_", "");
							fromDate = (lCID switch
							{
								1065 => DateTime.Parse(PersianDate.GetFormatetdDate(fDate) + " 00:00:00"), 
								1025 => DateTime.Parse(PersianDate.GetFormatetdDate(fDate) + " 00:00:00", new CultureInfo("ar-SA"), DateTimeStyles.None), 
								_ => DateTime.Parse(PersianDate.GetFormatetdDate(fDate) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None), 
							}).ToString("yyyy/MM/dd", new PersianCulture());
						}
						if (!string.IsNullOrEmpty(tDate))
						{
							tDate = tDate.Replace("/", "").Replace("-", "").Replace("\\", "")
								.Replace(" ", "")
								.Replace("_", "");
							toDate = (lCID switch
							{
								1065 => DateTime.Parse(PersianDate.GetFormatetdDate(tDate) + " 23:59:59"), 
								1025 => DateTime.Parse(PersianDate.GetFormatetdDate(tDate) + " 23:59:59", new CultureInfo("ar-SA"), DateTimeStyles.None), 
								_ => DateTime.Parse(PersianDate.GetFormatetdDate(tDate) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None), 
							}).ToString("yyyy/MM/dd", new PersianCulture());
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
					}
					string value = new CommercialSoapClient().ReadFromPishFactor(text, fromDate, toDate, (!string.IsNullOrWhiteSpace(number)) ? number : "");
					if (!string.IsNullOrWhiteSpace(value))
					{
						value = value.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(value))
					{
						List<NoAvaranCapillaryPreOrderInfoViewModel> list3 = JsonConvert.DeserializeObject<List<NoAvaranCapillaryPreOrderInfoViewModel>>(value);
						if (list3 != null && Enumerable.Any<NoAvaranCapillaryPreOrderInfoViewModel>((IEnumerable<NoAvaranCapillaryPreOrderInfoViewModel>)list3))
						{
							List<WSspSelectPreOrderWithAccLinkField_Result> list4 = SelectPreOrderWithAccLinkField(withPordpordLinkAccPreOrderId: false, withPordpordLinkAccPreOrderIdStr: true);
							List<LkCompanyAndPersonViewModel> noAvaranCapillaryCompanyList = GetNoAvaranCapillaryCompanyList();
							int num = 1;
							foreach (NoAvaranCapillaryPreOrderInfoViewModel item in list3)
							{
								NoAvaranCapillaryPreOrderHeaderInfoViewModel itedmHead = item.x;
								if (itedmHead == null)
								{
									continue;
								}
								bool flag = false;
								if (list != null && Enumerable.Any<LkWSPreOrderInfoViewModel>((IEnumerable<LkWSPreOrderInfoViewModel>)list) && Enumerable.FirstOrDefault<LkWSPreOrderInfoViewModel>((IEnumerable<LkWSPreOrderInfoViewModel>)list, (Func<LkWSPreOrderInfoViewModel, bool>)((LkWSPreOrderInfoViewModel m) => m.pordLinkAccPreOrderIdStr == itedmHead.id.GetValueOrDefault().ToString())) != null)
								{
									flag = true;
								}
								if (flag)
								{
									continue;
								}
								LkWSPreOrderInfoViewModel vmPord = new LkWSPreOrderInfoViewModel();
								vmPord.pordDate = itedmHead.PishFactorDate;
								DateTime dateTime = default(DateTime);
								if (!string.IsNullOrWhiteSpace(itedmHead.PishFactorDate))
								{
									dateTime = DateTime.Parse(PersianDate.GetFormatetdDate(itedmHead.PishFactorDate.Replace("/", "")) + " 00:00:00", new PersianCulture());
									vmPord.pordDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
									vmPord.pordDateTime = dateTime;
								}
								vmPord.pordLinkAccPreOrderIdStr = itedmHead.id.GetValueOrDefault().ToString();
								vmPord.pordLinkAccPreOrderNumber = itedmHead.PishFactorNo;
								vmPord.cmpLinkAccCustomerIdStr = itedmHead.idCustomer.GetValueOrDefault().ToString();
								if (noAvaranCapillaryCompanyList != null && !string.IsNullOrWhiteSpace(vmPord.cmpLinkAccCustomerIdStr) && Enumerable.Any<LkCompanyAndPersonViewModel>((IEnumerable<LkCompanyAndPersonViewModel>)noAvaranCapillaryCompanyList))
								{
									LkCompanyAndPersonViewModel lkCompanyAndPersonViewModel = Enumerable.FirstOrDefault<LkCompanyAndPersonViewModel>((IEnumerable<LkCompanyAndPersonViewModel>)noAvaranCapillaryCompanyList, (Func<LkCompanyAndPersonViewModel, bool>)((LkCompanyAndPersonViewModel m) => m.cmpLinkAccCustomerIdStr == vmPord.cmpLinkAccCustomerIdStr));
									if (lkCompanyAndPersonViewModel != null)
									{
										vmPord.pordCompanyId = lkCompanyAndPersonViewModel.CompanyId;
										vmPord.cmpName = lkCompanyAndPersonViewModel.cmpName + ((!string.IsNullOrWhiteSpace(lkCompanyAndPersonViewModel.prsFName) || !string.IsNullOrWhiteSpace(lkCompanyAndPersonViewModel.prsLName)) ? (" (" + ((!string.IsNullOrWhiteSpace(lkCompanyAndPersonViewModel.prsFName)) ? (lkCompanyAndPersonViewModel.prsFName + " ") : "") + ((!string.IsNullOrWhiteSpace(lkCompanyAndPersonViewModel.prsLName)) ? lkCompanyAndPersonViewModel.prsLName : "") + ")") : "");
										vmPord.cmpLinkAccCode = lkCompanyAndPersonViewModel.cmpLinkAccCode;
									}
								}
								vmPord.LinkAccReferUserIdStr = itedmHead.idSalesMan.GetValueOrDefault().ToString();
								vmPord.pordTotalAmount = itedmHead.MablaghPish.GetValueOrDefault();
								List<NoAvaranCapillaryPreOrderInfoViewModel> list5 = Enumerable.ToList<NoAvaranCapillaryPreOrderInfoViewModel>(Enumerable.Where<NoAvaranCapillaryPreOrderInfoViewModel>((IEnumerable<NoAvaranCapillaryPreOrderInfoViewModel>)list3, (Func<NoAvaranCapillaryPreOrderInfoViewModel, bool>)((NoAvaranCapillaryPreOrderInfoViewModel m) => m.x.id == itedmHead.id)));
								decimal num2 = default(decimal);
								decimal value2 = default(decimal);
								if (list5 != null && Enumerable.Any<NoAvaranCapillaryPreOrderInfoViewModel>((IEnumerable<NoAvaranCapillaryPreOrderInfoViewModel>)list5))
								{
									foreach (NoAvaranCapillaryPreOrderInfoViewModel item2 in list5)
									{
										LkWSPreOrderItemsInfoViewModel lkWSPreOrderItemsInfoViewModel = new LkWSPreOrderItemsInfoViewModel();
										lkWSPreOrderItemsInfoViewModel.pordLinkAccPreOrderIdStr = itedmHead.id.GetValueOrDefault().ToString();
										lkWSPreOrderItemsInfoViewModel.pordLinkAccPreOrderNumber = itedmHead.PishFactorNo;
										lkWSPreOrderItemsInfoViewModel.PrdName = item2.NameKala;
										lkWSPreOrderItemsInfoViewModel.PrdLinkAccPrdCode = item2.CodeKala;
										lkWSPreOrderItemsInfoViewModel.PrdLinkAccPrdIdStr = item2.idMaterial.GetValueOrDefault().ToString();
										lkWSPreOrderItemsInfoViewModel.Unit = item2.NameUnit;
										lkWSPreOrderItemsInfoViewModel.WrhsLinkAccWhIdStr = item2.Store.GetValueOrDefault().ToString();
										lkWSPreOrderItemsInfoViewModel.pordIQuantity = item2.Amount.GetValueOrDefault(1.0);
										lkWSPreOrderItemsInfoViewModel.pordIPrice = item2.Price;
										lkWSPreOrderItemsInfoViewModel.pordITotalPrice = item2.CostPardakht;
										value2 += lkWSPreOrderItemsInfoViewModel.pordITotalPrice.GetValueOrDefault();
										if (item2.AmountKasr.GetValueOrDefault() != 0m)
										{
											lkWSPreOrderItemsInfoViewModel.pordIDiscountSum = item2.AmountKasr;
										}
										if (item2.DarsadKasr.GetValueOrDefault() != 0m)
										{
											lkWSPreOrderItemsInfoViewModel.pordIDiscountPercent = item2.DarsadKasr;
										}
										if (item2.AmountEzaf.GetValueOrDefault() != 0m)
										{
											lkWSPreOrderItemsInfoViewModel.pordITaxSum = item2.AmountEzaf;
											num2 += lkWSPreOrderItemsInfoViewModel.pordITaxSum.GetValueOrDefault();
										}
										if (item2.DarsadEzaf.GetValueOrDefault() != 0m)
										{
											lkWSPreOrderItemsInfoViewModel.pordITaxIndex = item2.DarsadEzaf;
										}
										if (item2.AmountKindBag.GetValueOrDefault() != 0.0)
										{
											lkWSPreOrderItemsInfoViewModel.pordIPrdUnitIRateResult = item2.AmountKindBag;
										}
										if (item2.Weight.GetValueOrDefault() != 0.0)
										{
											lkWSPreOrderItemsInfoViewModel.pordIPrdWeight = item2.Weight;
										}
										list2.Add(lkWSPreOrderItemsInfoViewModel);
									}
								}
								if (itedmHead.MablaghPish.GetValueOrDefault() == 0m)
								{
									vmPord.pordTotalAmount = value2;
								}
								else
								{
									vmPord.pordTotalAmount = vmPord.pordTotalAmount.GetValueOrDefault() + num2;
								}
								vmPord.RowNumber = num;
								if (list4 != null && Enumerable.Any<WSspSelectPreOrderWithAccLinkField_Result>((IEnumerable<WSspSelectPreOrderWithAccLinkField_Result>)list4))
								{
									WSspSelectPreOrderWithAccLinkField_Result wSspSelectPreOrderWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectPreOrderWithAccLinkField_Result>((IEnumerable<WSspSelectPreOrderWithAccLinkField_Result>)list4, (Func<WSspSelectPreOrderWithAccLinkField_Result, bool>)((WSspSelectPreOrderWithAccLinkField_Result x) => x.pordLinkAccPreOrderIdStr == vmPord.pordLinkAccPreOrderIdStr));
									if (wSspSelectPreOrderWithAccLinkField_Result != null)
									{
										if (!string.IsNullOrWhiteSpace(wSspSelectPreOrderWithAccLinkField_Result.pordLinkAccPreOrderIdStr))
										{
											vmPord.PreOrderID = wSspSelectPreOrderWithAccLinkField_Result.PreOrderID;
										}
									}
									else
									{
										vmPord.PreOrderID = 0;
									}
								}
								list.Add(vmPord);
								num++;
							}
						}
					}
				}
			}
			lkPreOrderInfoViewModelObjects.lst = list;
			lkPreOrderInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			lkPreOrderInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
			lkPreOrderInfoViewModelObjects.lstItems = list2;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return lkPreOrderInfoViewModelObjects;
	}

	public List<LkCompanyAndPersonViewModel> GetNoAvaranCapillaryCompanyList()
	{
		List<LkCompanyAndPersonViewModel> result = new List<LkCompanyAndPersonViewModel>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			LkCompanyInfoViewModelObjects noAvaranCapillaryCompanyList = new CompanyController().GetNoAvaranCapillaryCompanyList();
			if (noAvaranCapillaryCompanyList != null)
			{
				result = noAvaranCapillaryCompanyList.lst;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public LkWSPreOrderInfoViewModel GetNoAvaranCapillaryPreOrder(string fDate = "", string tDate = "", string number = "", string pordLinkAccPreOrderIdStr = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		LkWSPreOrderInfoViewModel result2 = new LkWSPreOrderInfoViewModel();
		try
		{
			LkPreOrderInfoViewModelObjects noAvaranCapillaryPreOrderList = GetNoAvaranCapillaryPreOrderList(fDate, tDate, number);
			if (noAvaranCapillaryPreOrderList != null && noAvaranCapillaryPreOrderList.lst != null && Enumerable.Any<LkWSPreOrderInfoViewModel>((IEnumerable<LkWSPreOrderInfoViewModel>)noAvaranCapillaryPreOrderList.lst))
			{
				result2 = Enumerable.FirstOrDefault<LkWSPreOrderInfoViewModel>((IEnumerable<LkWSPreOrderInfoViewModel>)noAvaranCapillaryPreOrderList.lst, (Func<LkWSPreOrderInfoViewModel, bool>)((LkWSPreOrderInfoViewModel m) => m.pordLinkAccPreOrderIdStr == pordLinkAccPreOrderIdStr));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result2;
	}

	[AjaxOnly]
	public string NoAvaranCapillaryActSendToAcc(int pordId, int noAvIdCompany, bool sendPordPayToAcc = false, int noAvIdPart = 0, int noAvPrdGroup = 0)
	{
		string text = "";
		try
		{
			_ = UserLogin.CurrentUser;
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
			if (pordId > 0)
			{
				try
				{
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
					string appType = Configuration.AppType;
					short.Parse(Financial.Get().Id.ToString());
					int userId = UserLogin.CurrentUser.UserId;
					_ = Financial.Get().Id;
					string noAvaranCapillary = Labels.NoAvaranCapillary;
					CRMspLkWSSelectPreOrderById_Result cRMspLkWSSelectPreOrderById_Result = Enumerable.FirstOrDefault<CRMspLkWSSelectPreOrderById_Result>((IEnumerable<CRMspLkWSSelectPreOrderById_Result>)_dbLink.CRMspLkWSSelectPreOrderById(pordId, lCID, result, result2));
					if (cRMspLkWSSelectPreOrderById_Result != null)
					{
						string errorMessage = "";
						if (!PreOrder.SendToLinkAccNeedVerify(pordId, ref errorMessage))
						{
							text = errorMessage + "|";
							return text;
						}
						if (!string.IsNullOrWhiteSpace(cRMspLkWSSelectPreOrderById_Result.pordLinkAccPreOrderIdStr))
						{
							string text2 = (cRMspLkWSSelectPreOrderById_Result.pordDateTime.HasValue ? cRMspLkWSSelectPreOrderById_Result.pordDateTime.Value.ToString("yyyy/MM/dd") : "");
							LkWSPreOrderInfoViewModel noAvaranCapillaryPreOrder = GetNoAvaranCapillaryPreOrder(text2, text2, cRMspLkWSSelectPreOrderById_Result.pordLinkAccPreOrderNumber ?? "", cRMspLkWSSelectPreOrderById_Result.pordLinkAccPreOrderIdStr);
							if (noAvaranCapillaryPreOrder != null)
							{
								if (!string.IsNullOrWhiteSpace(noAvaranCapillaryPreOrder.pordLinkAccPreOrderIdStr))
								{
									text = string.Format(Messages.msgErrorNotReSendPordToOtherSystem, cRMspLkWSSelectPreOrderById_Result.pordNumber.ToString(), noAvaranCapillary) + "|";
									if (sendPordPayToAcc)
									{
										string text3 = NoAvaranCapillaryActSendPaymentsToAcc(pordId, noAvIdCompany);
										if (!string.IsNullOrWhiteSpace(text3))
										{
											string[] array = text3.Split(new char[1] { '|' });
											if (array != null && array.Length >= 1)
											{
												if (array[0] != "1")
												{
													text = array[0] + "|";
													return text;
												}
												text = "1|" + cRMspLkWSSelectPreOrderById_Result.pordLinkAccPreOrderIdStr;
												return text;
											}
											text = text3;
										}
										else
										{
											text = "1|" + cRMspLkWSSelectPreOrderById_Result.pordLinkAccPreOrderIdStr;
										}
									}
									return text;
								}
								_dbLink.WSspUpdatePreOrderAndItemWithAccLinkField(pordId, null, null, null, null, null, true, userId, value2, value, registerDatePersian, appType);
							}
						}
						string text4 = "0";
						string text5 = "0";
						string idKindMaterial = noAvPrdGroup.ToString();
						string kindFactor = "0";
						string uDate = now.ToString("yyyy/MM/dd", new PersianCulture());
						string uTime = now.ToString("HH:mm");
						string text6 = "";
						string idPart = noAvIdPart.ToString();
						if (!cRMspLkWSSelectPreOrderById_Result.pordReferUserId.HasValue)
						{
							text = string.Format(Messages.msgErrorInSendPordToAccLinkNotSelectedItem, cRMspLkWSSelectPreOrderById_Result.pordNumber, noAvaranCapillary, Labels.pordReferUserId) + "|";
							return text;
						}
						if (string.IsNullOrWhiteSpace(cRMspLkWSSelectPreOrderById_Result.LinkAccReferUserIdStr))
						{
							text = string.Format(Messages.msgErrorInSendPordToAccLinkNotSelectedItem, cRMspLkWSSelectPreOrderById_Result.pordNumber, noAvaranCapillary, Labels.pordReferUserId, cRMspLkWSSelectPreOrderById_Result.pordReferUser ?? "") + "|";
							return text;
						}
						text4 = cRMspLkWSSelectPreOrderById_Result.LinkAccReferUserIdStr;
						if (!cRMspLkWSSelectPreOrderById_Result.pordPayConditionId.HasValue)
						{
							text = string.Format(Messages.msgErrorInSendPordToAccLinkNotSelectedItem, cRMspLkWSSelectPreOrderById_Result.pordNumber, noAvaranCapillary, Labels.pordPayConditionId) + "|";
							return text;
						}
						if (string.IsNullOrWhiteSpace(cRMspLkWSSelectPreOrderById_Result.LinkAccPayConditionIdStr))
						{
							text = string.Format(Messages.msgErrorInSendPordToAccLinkNotSelectedItem, cRMspLkWSSelectPreOrderById_Result.pordNumber, noAvaranCapillary, Labels.pordPayConditionId, cRMspLkWSSelectPreOrderById_Result.pordReferUser ?? "") + "|";
							return text;
						}
						text5 = cRMspLkWSSelectPreOrderById_Result.LinkAccPayConditionIdStr;
						CRMIdeal.Classes.Helper.OtherSystems.NoAvaranCapillarySettingViewModel noAvaranCapillarySetting = CRMIdeal.Classes.Helper.OtherSystems.GetNoAvaranCapillarySetting();
						if (noAvaranCapillarySetting != null)
						{
							string text7 = noAvaranCapillarySetting.ApiUserId ?? "";
							string text8 = noAvaranCapillarySetting.ApiUserName ?? "";
							int wrhsSyncTypeId = noAvaranCapillarySetting.WrhsSyncTypeId;
							int pordOprFieldLinkTokindFactor = noAvaranCapillarySetting.PordOprFieldLinkTokindFactor;
							if (string.IsNullOrWhiteSpace(text7) || string.IsNullOrWhiteSpace(text8) || !string.IsNullOrWhiteSpace(cRMspLkWSSelectPreOrderById_Result.pordLinkAccPreOrderIdStr))
							{
								text = ((!string.IsNullOrWhiteSpace(text7) && !string.IsNullOrWhiteSpace(text8)) ? ((string.IsNullOrWhiteSpace(cRMspLkWSSelectPreOrderById_Result.pordLinkAccPreOrderIdStr) || string.IsNullOrWhiteSpace(cRMspLkWSSelectPreOrderById_Result.pordLinkAccPreOrderNumber)) ? (Messages.msgErrorRunFunction + "|") : ("1|" + cRMspLkWSSelectPreOrderById_Result.pordLinkAccPreOrderNumber)) : (Messages.errorInReadingSetting + "|"));
							}
							else
							{
								switch (pordOprFieldLinkTokindFactor)
								{
								case 1:
								{
									if (!cRMspLkWSSelectPreOrderById_Result.PreOrderOprID.HasValue)
									{
										text = string.Format(Messages.msgErrorInSendPordToAccLinkNotSelectedItem, cRMspLkWSSelectPreOrderById_Result.pordNumber, noAvaranCapillary, Labels.PreOrderOprID) + "|";
										return text;
									}
									CRMIdeal.Classes.Helper.OtherSystems.NoAvaranCapillarySettingDetailsViewModel noAvaranCapillarySettingDetails2 = CRMIdeal.Classes.Helper.OtherSystems.GetNoAvaranCapillarySettingDetails(0, cRMspLkWSSelectPreOrderById_Result.PreOrderOprID.GetValueOrDefault(), "PreOrderOpr");
									if (noAvaranCapillarySettingDetails2 != null)
									{
										kindFactor = noAvaranCapillarySettingDetails2.PordOprkindFactor.ToString();
										break;
									}
									text = string.Format(Messages.msgErrorInSendPordToAccLinkNotSelectedItem, cRMspLkWSSelectPreOrderById_Result.pordNumber, noAvaranCapillary, string.Format(Labels.SettingByFormat, Labels.PreOrderOprID)) + "|";
									return text;
								}
								case 2:
								{
									if (!cRMspLkWSSelectPreOrderById_Result.pordTypeId.HasValue)
									{
										text = string.Format(Messages.msgErrorInSendPordToAccLinkNotSelectedItem, cRMspLkWSSelectPreOrderById_Result.pordNumber, noAvaranCapillary, Labels.pordTypeId) + "|";
										return text;
									}
									CRMIdeal.Classes.Helper.OtherSystems.NoAvaranCapillarySettingDetailsViewModel noAvaranCapillarySettingDetails = CRMIdeal.Classes.Helper.OtherSystems.GetNoAvaranCapillarySettingDetails(0, cRMspLkWSSelectPreOrderById_Result.pordTypeId.GetValueOrDefault(), "PreOrderOpr");
									if (noAvaranCapillarySettingDetails != null)
									{
										kindFactor = noAvaranCapillarySettingDetails.PordOprkindFactor.ToString();
										break;
									}
									text = string.Format(Messages.msgErrorInSendPordToAccLinkNotSelectedItem, cRMspLkWSSelectPreOrderById_Result.pordNumber, noAvaranCapillary, string.Format(Labels.SettingByFormat, Labels.pordTypeId)) + "|";
									return text;
								}
								}
								List<CRMspLkWSSelectPreOrderItems_Result> list = Enumerable.ToList<CRMspLkWSSelectPreOrderItems_Result>((IEnumerable<CRMspLkWSSelectPreOrderItems_Result>)_dbLink.CRMspLkWSSelectPreOrderItems(pordId, lCID, result));
								if (list == null || !Enumerable.Any<CRMspLkWSSelectPreOrderItems_Result>((IEnumerable<CRMspLkWSSelectPreOrderItems_Result>)list))
								{
									text = Messages.ErrorNotFound + "|";
									return text;
								}
								foreach (CRMspLkWSSelectPreOrderItems_Result item2 in list)
								{
									if (string.IsNullOrWhiteSpace(item2.PrdLinkAccPrdIdStr))
									{
										text = string.Format(Messages.msgErrorInSendPordToAccLinkNotFoundPrdInAcc, cRMspLkWSSelectPreOrderById_Result.pordNumber, noAvaranCapillary, item2.PrdName ?? "") + "|";
										return text;
									}
									if (item2.pordIWHId.HasValue)
									{
										string value3 = "";
										string value4 = "";
										if (wrhsSyncTypeId == 2 && !string.IsNullOrWhiteSpace(item2.pordILinkAccWHIdStr))
										{
											if (!string.IsNullOrWhiteSpace(item2.WrhsLinkAccWareHouses))
											{
												List<CommonWithIdStrViewModel> list2 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(item2.WrhsLinkAccWareHouses);
												if (list2 != null && list2.Count > 0)
												{
													CommonWithIdStrViewModel commonWithIdStrViewModel = Enumerable.FirstOrDefault<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list2, (Func<CommonWithIdStrViewModel, bool>)((CommonWithIdStrViewModel x) => x.Id == item2.pordILinkAccWHIdStr));
													if (commonWithIdStrViewModel != null)
													{
														value4 = commonWithIdStrViewModel.Name;
														value3 = commonWithIdStrViewModel.Id;
													}
												}
											}
										}
										else
										{
											value3 = item2.WrhsLinkAccWhIdStr;
											value4 = item2.pordIWrhsName;
										}
										if (string.IsNullOrWhiteSpace(value3) || string.IsNullOrWhiteSpace(value4))
										{
											text = string.Format(Messages.msgErrorWareHouseNotFoundInAccLink, item2.pordIWrhsName ?? "", noAvaranCapillary);
											return text;
										}
										continue;
									}
									text = string.Format(Messages.msgErrorInSendPordToAccLinkNotSelectedItem, cRMspLkWSSelectPreOrderById_Result.pordNumber, noAvaranCapillary, Labels.lblWareHouse) + "|";
									return text;
								}
								string text9 = "";
								string text10 = (cRMspLkWSSelectPreOrderById_Result.pordAddress ?? text9) ?? "";
								string desc = (cRMspLkWSSelectPreOrderById_Result.pordDescriptionI ?? cRMspLkWSSelectPreOrderById_Result.pordDescriptionII) ?? "";
								string text11 = "";
								CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(cRMspLkWSSelectPreOrderById_Result.pordCompanyId.GetValueOrDefault());
								if (companyById == null)
								{
									text = Messages.CompanyNotFound + "|";
									return text;
								}
								text11 = companyById.cmpLinkAccCustomerIdStr ?? "";
								text9 = companyById.cmpAddress ?? "";
								if (string.IsNullOrWhiteSpace(text10))
								{
									text10 = text9;
								}
								if (string.IsNullOrWhiteSpace(text11))
								{
									string text12 = new CompanyController().NoAvaranCapillaryActCmpSendToAcc(cRMspLkWSSelectPreOrderById_Result.pordCompanyId.GetValueOrDefault(), noAvIdCompany, 0, 0, 0, checkAction: false);
									if (string.IsNullOrEmpty(text12))
									{
										text = Messages.msgErrorRunFunction + "(insert company to noavaran)|";
										return text;
									}
									string[] array2 = text12.Split(new char[1] { '|' });
									if (array2 != null)
									{
										if (!(array2[0] == "1"))
										{
											text = array2[0] + "|";
											return text;
										}
										companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(cRMspLkWSSelectPreOrderById_Result.pordCompanyId.GetValueOrDefault());
										if (companyById == null)
										{
											text = Messages.CompanyNotFound + "|";
											return text;
										}
										text11 = companyById.cmpLinkAccCustomerIdStr ?? "";
									}
								}
								if (string.IsNullOrWhiteSpace(text11))
								{
									text = string.Format(Messages.msgErrorInSendToAccLinkNotFoundCmpInAcc, noAvaranCapillary);
									return text;
								}
								DateTime dateTime = default(DateTime);
								string text13 = "";
								try
								{
									if (cRMspLkWSSelectPreOrderById_Result.pordDateTime.HasValue)
									{
										text13 = cRMspLkWSSelectPreOrderById_Result.pordDateTime.Value.ToString("yyyy/MM/dd", new PersianCulture());
									}
									else if (!string.IsNullOrWhiteSpace(cRMspLkWSSelectPreOrderById_Result.pordDate))
									{
										text13 = DateTime.Parse(PersianDate.GetFormatetdDate(cRMspLkWSSelectPreOrderById_Result.pordDate.Replace("/", "")) + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")).ToString("yyyy/MM/dd", new PersianCulture());
									}
								}
								catch (Exception e)
								{
									ErrorSignal.FromCurrentContext().Raise(e);
									text = string.Format(Messages.ErrorInFormat, Labels.pordDate);
									return text;
								}
								dateTime = default(DateTime);
								string text14 = "";
								try
								{
									if (cRMspLkWSSelectPreOrderById_Result.pordExpireDateTime.HasValue)
									{
										text14 = cRMspLkWSSelectPreOrderById_Result.pordExpireDateTime.Value.ToString("yyyy/MM/dd", new PersianCulture());
									}
									else if (!string.IsNullOrWhiteSpace(cRMspLkWSSelectPreOrderById_Result.pordExpireDate))
									{
										text14 = DateTime.Parse(PersianDate.GetFormatetdDate(cRMspLkWSSelectPreOrderById_Result.pordExpireDate.Replace("/", "")) + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")).ToString("yyyy/MM/dd", new PersianCulture());
									}
								}
								catch (Exception e2)
								{
									ErrorSignal.FromCurrentContext().Raise(e2);
									text = string.Format(Messages.ErrorInFormat, Labels.pordExpireDate);
									return text;
								}
								if (string.IsNullOrWhiteSpace(text14))
								{
									text14 = text13;
								}
								List<NoAvaranCapillaryPishFactorDetailViewModel> list3 = new List<NoAvaranCapillaryPishFactorDetailViewModel>();
								if (list != null && Enumerable.Any<CRMspLkWSSelectPreOrderItems_Result>((IEnumerable<CRMspLkWSSelectPreOrderItems_Result>)list))
								{
									foreach (CRMspLkWSSelectPreOrderItems_Result item in list)
									{
										NoAvaranCapillaryPishFactorDetailViewModel noAvaranCapillaryPishFactorDetailViewModel = new NoAvaranCapillaryPishFactorDetailViewModel();
										string text15 = item.PrdLinkAccPrdIdStr ?? "";
										string text16 = item.PrdLinkAccPrdCode ?? "";
										_ = item.UnitLinkAccUnitIdStr;
										string text17 = "";
										if (item.pordIWHId.HasValue)
										{
											string text18 = "";
											if (wrhsSyncTypeId == 2 && !string.IsNullOrWhiteSpace(item.pordILinkAccWHIdStr))
											{
												if (!string.IsNullOrWhiteSpace(item.WrhsLinkAccWareHouses))
												{
													List<CommonWithIdStrViewModel> list4 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(item.WrhsLinkAccWareHouses);
													if (list4 != null && list4.Count > 0)
													{
														CommonWithIdStrViewModel commonWithIdStrViewModel2 = Enumerable.FirstOrDefault<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list4, (Func<CommonWithIdStrViewModel, bool>)((CommonWithIdStrViewModel x) => x.Id == item.pordILinkAccWHIdStr));
														if (commonWithIdStrViewModel2 != null)
														{
															_ = commonWithIdStrViewModel2.Name;
															text18 = commonWithIdStrViewModel2.Id;
														}
													}
												}
											}
											else
											{
												text18 = item.WrhsLinkAccWhIdStr;
												_ = item.pordIWrhsName;
											}
											if (!string.IsNullOrWhiteSpace(text18))
											{
												text17 = text18;
											}
										}
										if (string.IsNullOrWhiteSpace(text6) && !string.IsNullOrWhiteSpace(text17))
										{
											text6 = text17;
										}
										if (!string.IsNullOrWhiteSpace(text15) && !string.IsNullOrWhiteSpace(text16))
										{
											double num = item.pordIQuantity.GetValueOrDefault(1.0) * item.pordIFCR.GetValueOrDefault(1.0) * item.pordIFCRI.GetValueOrDefault(1.0);
											decimal num2 = item.pordIPrice.GetValueOrDefault() * (decimal)num;
											decimal num3 = default(decimal);
											double num4 = item.pordIPrdUnitIRateResult.GetValueOrDefault();
											if (num4 == 0.0)
											{
												num4 = num;
											}
											double valueOrDefault = item.pordIPrdWeight.GetValueOrDefault();
											string text19 = item.pordIPrice.GetValueOrDefault().ToString();
											string text20 = item.pordIDiscountPercent.GetValueOrDefault().ToString();
											string text21 = item.pordIDiscountSum.GetValueOrDefault().ToString();
											string text22 = item.pordITaxIndex.GetValueOrDefault().ToString();
											string text23 = item.pordITaxSum.GetValueOrDefault().ToString();
											string text24 = item.pordITotalPrice.GetValueOrDefault().ToString();
											string text25 = num2.ToString();
											if (text19.EndsWith(".00"))
											{
												text19 = text19.Replace(".00", "");
											}
											if (text20.EndsWith(".00"))
											{
												text20 = text20.Replace(".00", "");
											}
											if (text21.EndsWith(".00"))
											{
												text21 = text21.Replace(".00", "");
											}
											if (text22.EndsWith(".00"))
											{
												text22 = text22.Replace(".00", "");
											}
											if (text23.EndsWith(".00"))
											{
												text23 = text23.Replace(".00", "");
											}
											if (text24.EndsWith(".00"))
											{
												text24 = text24.Replace(".00", "");
											}
											if (text25.EndsWith(".00"))
											{
												text25 = text25.Replace(".00", "");
											}
											noAvaranCapillaryPishFactorDetailViewModel.CodeKala = text16;
											noAvaranCapillaryPishFactorDetailViewModel.PreOrderItemID = item.PreOrderItemID;
											noAvaranCapillaryPishFactorDetailViewModel.IdMaterial = text15;
											noAvaranCapillaryPishFactorDetailViewModel.Amount = num.ToString();
											noAvaranCapillaryPishFactorDetailViewModel.AmountKindBag = num4.ToString();
											noAvaranCapillaryPishFactorDetailViewModel.Olaviat = "";
											noAvaranCapillaryPishFactorDetailViewModel.Desc = (item.pordIDescription ?? item.pordIDescriptionI) ?? "";
											noAvaranCapillaryPishFactorDetailViewModel.Price = text19;
											noAvaranCapillaryPishFactorDetailViewModel.Cost = text25;
											noAvaranCapillaryPishFactorDetailViewModel.DarsadKasr = text20;
											noAvaranCapillaryPishFactorDetailViewModel.AmountKasr = text21;
											noAvaranCapillaryPishFactorDetailViewModel.DarsadEzaf = text22;
											noAvaranCapillaryPishFactorDetailViewModel.AmountEzaf = text23;
											noAvaranCapillaryPishFactorDetailViewModel.CostPardakht = text24;
											noAvaranCapillaryPishFactorDetailViewModel.Weight = valueOrDefault.ToString();
											noAvaranCapillaryPishFactorDetailViewModel.Avarez = "";
											noAvaranCapillaryPishFactorDetailViewModel.Malyat = noAvaranCapillaryPishFactorDetailViewModel.AmountEzaf;
											noAvaranCapillaryPishFactorDetailViewModel.Haml = num3.ToString();
											noAvaranCapillaryPishFactorDetailViewModel.Store = text17;
											noAvaranCapillaryPishFactorDetailViewModel.ModatPardakht = "";
											noAvaranCapillaryPishFactorDetailViewModel.SerialKala = "";
											noAvaranCapillaryPishFactorDetailViewModel.DateEngheza = "";
											noAvaranCapillaryPishFactorDetailViewModel.Dategaranti = "";
											noAvaranCapillaryPishFactorDetailViewModel.IdpishFactor = "";
											list3.Add(noAvaranCapillaryPishFactorDetailViewModel);
											continue;
										}
										text = Messages.msgErrorRunFunction + " (Error in create json)";
										return text;
									}
								}
								if (list3 == null || !Enumerable.Any<NoAvaranCapillaryPishFactorDetailViewModel>((IEnumerable<NoAvaranCapillaryPishFactorDetailViewModel>)list3))
								{
									text = Messages.ErrorNotFound + "|";
									return text;
								}
								string text26 = "";
								CommercialSoapClient commercialSoapClient = new CommercialSoapClient();
								string text27 = commercialSoapClient.GetLastidPishFactor();
								if (!string.IsNullOrWhiteSpace(text27))
								{
									text27 = text27.ClearHiddenCharacters();
								}
								if (!string.IsNullOrWhiteSpace(text27))
								{
									string text28 = text27;
									if (!string.IsNullOrWhiteSpace(text28))
									{
										int result3 = 0;
										int.TryParse(text28.ToString(), out result3);
										text26 = result3.ToString();
										if (!string.IsNullOrWhiteSpace(text26))
										{
											text27 = "";
											cRMspLkWSSelectPreOrderById_Result.pordTotalAmount.GetValueOrDefault().ToString();
											text27 = commercialSoapClient.Idealsp_InsertPishFactor("0", text13, text14, text4, text11, text9, text10, text5, noAvIdCompany.ToString(), idKindMaterial, "", kindFactor, desc, text8, uDate, uTime, text6, "", "", "", text7, idPart, "", text26);
											if (!string.IsNullOrWhiteSpace(text27))
											{
												text27 = text27.ClearHiddenCharacters();
											}
											if (!string.IsNullOrWhiteSpace(text27))
											{
												if (text27.Trim().ToLower() == "Success tbl_PishFactor".ToLower() || text27.Trim().ToLower().IndexOf("Success tbl_PishFactor".ToLower(), StringComparison.Ordinal) >= 0)
												{
													bool flag = false;
													List<LkPreOrderItemLinkAccFieldsViewModel> list5 = new List<LkPreOrderItemLinkAccFieldsViewModel>();
													string pordLinkAccPreOrderIdStr = text26;
													string text29 = "";
													if (list3 != null && Enumerable.Any<NoAvaranCapillaryPishFactorDetailViewModel>((IEnumerable<NoAvaranCapillaryPishFactorDetailViewModel>)list3))
													{
														foreach (NoAvaranCapillaryPishFactorDetailViewModel item3 in list3)
														{
															flag = false;
															text27 = "";
															text27 = commercialSoapClient.Idealsp_InsertPishFactorDetail(item3.IdMaterial, item3.Amount, item3.AmountKindBag, item3.Olaviat, item3.Desc, item3.Price, item3.Cost, item3.DarsadKasr, item3.AmountKasr, item3.DarsadEzaf, item3.AmountEzaf, item3.CostPardakht, item3.Weight, item3.Avarez, item3.Malyat, item3.Haml, item3.Store, item3.ModatPardakht, item3.SerialKala, item3.DateEngheza, item3.Dategaranti, text26, item3.CodeKala);
															if (!string.IsNullOrWhiteSpace(text27))
															{
																text27 = text27.ClearHiddenCharacters();
															}
															if (!string.IsNullOrWhiteSpace(text27))
															{
																if (text27.ToLower().IndexOf("Success Insert PishFactorDetail".ToLower(), StringComparison.Ordinal) >= 0)
																{
																	flag = true;
																	continue;
																}
																flag = false;
																text = text + "<br>" + text27 + "|";
															}
															else
															{
																text = text + "<br>" + Messages.msgErrorCommunicateWithServer + "|";
															}
														}
													}
													if (flag)
													{
														string itemJson = "";
														if (list5 != null && Enumerable.Any<LkPreOrderItemLinkAccFieldsViewModel>((IEnumerable<LkPreOrderItemLinkAccFieldsViewModel>)list5))
														{
															itemJson = JsonConvert.SerializeObject(Enumerable.ToList<LkPreOrderItemLinkAccFieldsViewModel>((IEnumerable<LkPreOrderItemLinkAccFieldsViewModel>)list5));
														}
														LkWSPreOrderInfoViewModel noAvaranCapillaryPreOrder2 = GetNoAvaranCapillaryPreOrder(text13, text13, text29 ?? "", pordLinkAccPreOrderIdStr);
														if (noAvaranCapillaryPreOrder2 != null && !string.IsNullOrWhiteSpace(noAvaranCapillaryPreOrder2.pordLinkAccPreOrderIdStr))
														{
															text29 = noAvaranCapillaryPreOrder2.pordLinkAccPreOrderNumber ?? "";
														}
														_dbLink.WSspUpdatePreOrderAndItemWithAccLinkField(pordId, null, text29, pordLinkAccPreOrderIdStr, null, itemJson, false, userId, value2, value, registerDatePersian, appType);
														text = "1|" + text29;
														if (sendPordPayToAcc)
														{
															string text30 = NoAvaranCapillaryActSendPaymentsToAcc(pordId, noAvIdCompany);
															if (!string.IsNullOrWhiteSpace(text30))
															{
																string[] array3 = text30.Split(new char[1] { '|' });
																if (array3 != null && array3.Length >= 1 && array3[0] != "1")
																{
																	text = array3[0] + "|";
																	return text;
																}
															}
														}
													}
													else
													{
														text = text + "<br>" + Messages.msgErrorCommunicateWithServer + "|";
													}
												}
												else
												{
													text = text + "<br>" + text27 + "|";
												}
											}
											else
											{
												text = text + "<br>" + Messages.msgErrorCommunicateWithServer + "|";
											}
										}
										else
										{
											text = text + "<br>" + Messages.msgErrorCommunicateWithServer + "|";
										}
									}
									else
									{
										text = text + "<br>" + Messages.msgErrorCommunicateWithServer + "|";
									}
								}
								else
								{
									text = text + "<br>" + Messages.msgErrorCommunicateWithServer + "|";
								}
							}
						}
						else
						{
							text = Messages.errorInReadingSetting + "|";
						}
					}
					else
					{
						text = Messages.ErrorNotFound + "|";
					}
				}
				catch (Exception ex)
				{
					text = text + "\n\nException: " + ex.Message;
				}
			}
			else
			{
				text = Messages.ErrorNotFound + "|";
			}
		}
		catch (Exception e3)
		{
			ErrorSignal.FromCurrentContext().Raise(e3);
			text = Messages.msgErrorRunFunction + "|";
		}
		return text;
	}

	public LkWSPreOrderPaymentsInfoViewModel GetNoAvaranCapillaryPayment(string fDate = "", string tDate = "", string number = "", string pordpayLinkAccHeaderIdStr = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		LkWSPreOrderPaymentsInfoViewModel result2 = new LkWSPreOrderPaymentsInfoViewModel();
		try
		{
			List<LkWSPreOrderPaymentsInfoViewModel> list = new List<LkWSPreOrderPaymentsInfoViewModel>();
			CRMIdeal.Classes.Helper.OtherSystems.NoAvaranCapillarySettingViewModel noAvaranCapillarySetting = CRMIdeal.Classes.Helper.OtherSystems.GetNoAvaranCapillarySetting();
			if (noAvaranCapillarySetting != null && !string.IsNullOrWhiteSpace(noAvaranCapillarySetting.ApiUserId ?? ""))
			{
				string date = "";
				string date2 = "";
				try
				{
					DateTime now = DateTime.Now;
					DateTime now2 = DateTime.Now;
					if (!string.IsNullOrWhiteSpace(fDate))
					{
						fDate = fDate.Replace("/", "").Replace("-", "").Replace("\\", "")
							.Replace(" ", "")
							.Replace("_", "");
						date = (lCID switch
						{
							1065 => DateTime.Parse(PersianDate.GetFormatetdDate(fDate) + " 00:00:00"), 
							1025 => DateTime.Parse(PersianDate.GetFormatetdDate(fDate) + " 00:00:00", new CultureInfo("ar-SA"), DateTimeStyles.None), 
							_ => DateTime.Parse(PersianDate.GetFormatetdDate(fDate) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None), 
						}).ToString("yyyy/MM/dd", new PersianCulture());
					}
					if (!string.IsNullOrEmpty(tDate))
					{
						tDate = tDate.Replace("/", "").Replace("-", "").Replace("\\", "")
							.Replace(" ", "")
							.Replace("_", "");
						date2 = (lCID switch
						{
							1065 => DateTime.Parse(PersianDate.GetFormatetdDate(tDate) + " 23:59:59"), 
							1025 => DateTime.Parse(PersianDate.GetFormatetdDate(tDate) + " 23:59:59", new CultureInfo("ar-SA"), DateTimeStyles.None), 
							_ => DateTime.Parse(PersianDate.GetFormatetdDate(tDate) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None), 
						}).ToString("yyyy/MM/dd", new PersianCulture());
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
				}
				string value = new CommercialSoapClient().GetDaryaft(date, date2);
				if (!string.IsNullOrWhiteSpace(value))
				{
					value = value.ClearHiddenCharacters();
				}
				if (!string.IsNullOrWhiteSpace(value))
				{
					List<NoAvaranCapillaryPreOrderPaymentInfoViewModel> list2 = JsonConvert.DeserializeObject<List<NoAvaranCapillaryPreOrderPaymentInfoViewModel>>(value);
					if (list2 != null && Enumerable.Any<NoAvaranCapillaryPreOrderPaymentInfoViewModel>((IEnumerable<NoAvaranCapillaryPreOrderPaymentInfoViewModel>)list2))
					{
						int num = 1;
						foreach (NoAvaranCapillaryPreOrderPaymentInfoViewModel item in list2)
						{
							if (item.i == null)
							{
								continue;
							}
							NoAvaranCapillaryPreOrderPaymentXHeaderInfoViewModel itedmHead = item.i.x;
							if (itedmHead == null)
							{
								continue;
							}
							bool flag = false;
							if (list != null && Enumerable.Any<LkWSPreOrderPaymentsInfoViewModel>((IEnumerable<LkWSPreOrderPaymentsInfoViewModel>)list) && Enumerable.FirstOrDefault<LkWSPreOrderPaymentsInfoViewModel>((IEnumerable<LkWSPreOrderPaymentsInfoViewModel>)list, (Func<LkWSPreOrderPaymentsInfoViewModel, bool>)((LkWSPreOrderPaymentsInfoViewModel m) => m.pordpayLinkAccHeaderIdStr == itedmHead.id.GetValueOrDefault().ToString())) != null)
							{
								flag = true;
							}
							if (flag)
							{
								continue;
							}
							LkWSPreOrderPaymentsInfoViewModel lkWSPreOrderPaymentsInfoViewModel = new LkWSPreOrderPaymentsInfoViewModel();
							lkWSPreOrderPaymentsInfoViewModel.ImportDate = itedmHead.Date;
							DateTime dateTime = default(DateTime);
							if (!string.IsNullOrWhiteSpace(itedmHead.Date))
							{
								dateTime = DateTime.Parse(PersianDate.GetFormatetdDate(itedmHead.Date.Replace("/", "")) + " 00:00:00", new PersianCulture());
								lkWSPreOrderPaymentsInfoViewModel.ImportDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
								lkWSPreOrderPaymentsInfoViewModel.ImportDateTime = dateTime;
								lkWSPreOrderPaymentsInfoViewModel.pordpayDocDate = lkWSPreOrderPaymentsInfoViewModel.ImportDate;
								lkWSPreOrderPaymentsInfoViewModel.pordpayDocDateTime = lkWSPreOrderPaymentsInfoViewModel.ImportDateTime;
							}
							lkWSPreOrderPaymentsInfoViewModel.pordpayLinkAccHeaderIdStr = itedmHead.id.GetValueOrDefault().ToString();
							lkWSPreOrderPaymentsInfoViewModel.pordpayLinkAccHeaderNumber = itedmHead.Code ?? "";
							List<NoAvaranCapillaryPreOrderPaymentInfoViewModel> list3 = Enumerable.ToList<NoAvaranCapillaryPreOrderPaymentInfoViewModel>(Enumerable.Where<NoAvaranCapillaryPreOrderPaymentInfoViewModel>((IEnumerable<NoAvaranCapillaryPreOrderPaymentInfoViewModel>)list2, (Func<NoAvaranCapillaryPreOrderPaymentInfoViewModel, bool>)((NoAvaranCapillaryPreOrderPaymentInfoViewModel m) => m.i.x.id == itedmHead.id)));
							if (list3 != null && Enumerable.Any<NoAvaranCapillaryPreOrderPaymentInfoViewModel>((IEnumerable<NoAvaranCapillaryPreOrderPaymentInfoViewModel>)list3))
							{
								foreach (NoAvaranCapillaryPreOrderPaymentInfoViewModel item2 in list3)
								{
									lkWSPreOrderPaymentsInfoViewModel.pordpayAmount += item2.Mablagh.GetValueOrDefault();
								}
							}
							list.Add(lkWSPreOrderPaymentsInfoViewModel);
							num++;
						}
					}
				}
			}
			if (list != null && Enumerable.Any<LkWSPreOrderPaymentsInfoViewModel>((IEnumerable<LkWSPreOrderPaymentsInfoViewModel>)list))
			{
				if (!string.IsNullOrWhiteSpace(pordpayLinkAccHeaderIdStr))
				{
					result2 = Enumerable.FirstOrDefault<LkWSPreOrderPaymentsInfoViewModel>((IEnumerable<LkWSPreOrderPaymentsInfoViewModel>)list, (Func<LkWSPreOrderPaymentsInfoViewModel, bool>)((LkWSPreOrderPaymentsInfoViewModel m) => m.pordpayLinkAccHeaderIdStr == pordpayLinkAccHeaderIdStr));
				}
				else if (!string.IsNullOrWhiteSpace(number))
				{
					result2 = Enumerable.FirstOrDefault<LkWSPreOrderPaymentsInfoViewModel>((IEnumerable<LkWSPreOrderPaymentsInfoViewModel>)list, (Func<LkWSPreOrderPaymentsInfoViewModel, bool>)((LkWSPreOrderPaymentsInfoViewModel m) => m.pordpayLinkAccHeaderNumber == number));
				}
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return result2;
	}

	[AjaxOnly]
	public string NoAvaranCapillaryActSendPaymentsToAcc(int pordId, int noAvIdCompany, int payId = 0)
	{
		string text = "";
		try
		{
			_ = UserLogin.CurrentUser;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (pordId > 0)
			{
				try
				{
					if (payId != 0)
					{
						text = NoAvaranCapillaryActSendPayToAcc(payId, noAvIdCompany);
					}
					else
					{
						List<CRMspLkWSSelectPreOrderPayments_Result> list = Enumerable.ToList<CRMspLkWSSelectPreOrderPayments_Result>((IEnumerable<CRMspLkWSSelectPreOrderPayments_Result>)_dbLink.CRMspLkWSSelectPreOrderPayments(pordId, lCID, result));
						if (list != null && Enumerable.Any<CRMspLkWSSelectPreOrderPayments_Result>((IEnumerable<CRMspLkWSSelectPreOrderPayments_Result>)list))
						{
							foreach (CRMspLkWSSelectPreOrderPayments_Result item in list)
							{
								string text2 = NoAvaranCapillaryActSendPayToAcc(item.PreOrderPaymentId, noAvIdCompany);
								if (!string.IsNullOrWhiteSpace(text2))
								{
									string[] array = text2.Split(new char[1] { '|' });
									if (array != null && array.Length >= 1 && array[0] != "1")
									{
										text = array[0] + "|";
										return text;
									}
								}
							}
							text = "1|" + Messages.msgSuccessAction;
						}
					}
				}
				catch (Exception ex)
				{
					text = text + "\n\nException: " + ex.Message;
				}
			}
			else
			{
				text = Messages.ErrorNotFound + "|";
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
	public string NoAvaranCapillaryActSendPayToAcc(int payId, int noAvIdCompany)
	{
		string text = "";
		try
		{
			_ = UserLogin.CurrentUser;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (payId > 0)
			{
				try
				{
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
					string appType = Configuration.AppType;
					short.Parse(Financial.Get().Id.ToString());
					int userId = UserLogin.CurrentUser.UserId;
					_ = Financial.Get().Id;
					string noAvaranCapillary = Labels.NoAvaranCapillary;
					CRMspLkWSSelectPreOrderPaymentsWithId_Result cRMspLkWSSelectPreOrderPaymentsWithId_Result = Enumerable.FirstOrDefault<CRMspLkWSSelectPreOrderPaymentsWithId_Result>((IEnumerable<CRMspLkWSSelectPreOrderPaymentsWithId_Result>)_dbLink.CRMspLkWSSelectPreOrderPaymentsWithId(payId, lCID, result));
					if (cRMspLkWSSelectPreOrderPaymentsWithId_Result != null)
					{
						string text2 = cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayAmount.ToString().FormatForPrice();
						if (string.IsNullOrWhiteSpace(cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordLinkAccPreOrderIdStr))
						{
							text = string.Format(Messages.msgErrorNotSendPordPayToOtherSystemWithOutPordToAcc, cRMspLkWSSelectPreOrderPaymentsWithId_Result.PayTypeTitle, text2, cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordNumber.ToString(), noAvaranCapillary) + "|";
							return text;
						}
						CRMspLkWSCheckDuplicatePreOrderPayment_Result cRMspLkWSCheckDuplicatePreOrderPayment_Result = Enumerable.FirstOrDefault<CRMspLkWSCheckDuplicatePreOrderPayment_Result>((IEnumerable<CRMspLkWSCheckDuplicatePreOrderPayment_Result>)_dbLink.CRMspLkWSCheckDuplicatePreOrderPayment(payId));
						if (cRMspLkWSCheckDuplicatePreOrderPayment_Result != null)
						{
							cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayAmount = cRMspLkWSCheckDuplicatePreOrderPayment_Result.pordpayAmount ?? cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayAmount;
							cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayDocAmount = cRMspLkWSCheckDuplicatePreOrderPayment_Result.pordpayDocAmount ?? cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayDocAmount;
							cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayDocDateTime = cRMspLkWSCheckDuplicatePreOrderPayment_Result.pordpayDocDateTime ?? cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayDocDateTime;
							cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayDocNumber = cRMspLkWSCheckDuplicatePreOrderPayment_Result.pordpayDocNumber ?? cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayDocNumber;
							int result2 = 0;
							int.TryParse(cRMspLkWSCheckDuplicatePreOrderPayment_Result.AlreadySendPreOrderPaymentId.ToString(), out result2);
							if (result2 != 0 && !string.IsNullOrWhiteSpace(cRMspLkWSCheckDuplicatePreOrderPayment_Result.AlreadyPordpayLinkAccHeaderIdStr))
							{
								_dbLink.WSspUpdatePreOrderPaymentWithAccLinkField(payId, cRMspLkWSCheckDuplicatePreOrderPayment_Result.AlreadyPordpayLinkAccHeaderId, cRMspLkWSCheckDuplicatePreOrderPayment_Result.AlreadyPordpayLinkAccHeaderNumber, cRMspLkWSCheckDuplicatePreOrderPayment_Result.AlreadyPordpayLinkAccDetailId, cRMspLkWSCheckDuplicatePreOrderPayment_Result.AlreadyPordpayLinkAccVoucherId, cRMspLkWSCheckDuplicatePreOrderPayment_Result.AlreadyPordpayLinkAccVoucherNumber, cRMspLkWSCheckDuplicatePreOrderPayment_Result.AlreadyPordpayLinkAccHeaderIdStr, cRMspLkWSCheckDuplicatePreOrderPayment_Result.AlreadyPordpayLinkAccDetailIdStr, cRMspLkWSCheckDuplicatePreOrderPayment_Result.AlreadyPordpayLinkAccVoucherIdStr, "dup", cRMspLkWSCheckDuplicatePreOrderPayment_Result.AlreadySendPordpayLinkAccData, false, userId, value2, value, registerDatePersian, appType);
								text = "1|" + cRMspLkWSCheckDuplicatePreOrderPayment_Result.AlreadyPordpayLinkAccHeaderNumber;
								return text;
							}
						}
						decimal pordpayAmount = cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayAmount;
						if (!cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayDocDateTime.HasValue)
						{
							cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayDocDateTime = cRMspLkWSSelectPreOrderPaymentsWithId_Result.ImportDateTime;
						}
						CRMIdeal.Classes.Helper.OtherSystems.NoAvaranCapillarySettingViewModel noAvaranCapillarySetting = CRMIdeal.Classes.Helper.OtherSystems.GetNoAvaranCapillarySetting();
						if (noAvaranCapillarySetting != null)
						{
							string value3 = noAvaranCapillarySetting.ApiUserId ?? "";
							string text3 = noAvaranCapillarySetting.ApiUserName ?? "";
							string uDate = now.ToString("yyyy/MM/dd", new PersianCulture());
							string time = now.ToString("HH:mm");
							int num = 0;
							int num2 = 0;
							int num3 = 0;
							int num4 = 0;
							string text4 = "";
							string kindSabtDis = "";
							CRMIdeal.Classes.Helper.OtherSystems.NoAvaranCapillarySettingDetailsViewModel noAvaranCapillarySettingDetails = CRMIdeal.Classes.Helper.OtherSystems.GetNoAvaranCapillarySettingDetails(0, cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayTypeId, "PordPayType");
							if (noAvaranCapillarySettingDetails != null)
							{
								num = noAvaranCapillarySettingDetails.PordPayDateType;
								num2 = noAvaranCapillarySettingDetails.PordPayDateFirstType;
								num3 = noAvaranCapillarySettingDetails.PordPayDateRasType;
								num4 = noAvaranCapillarySettingDetails.PordPayCheckDateType;
								text4 = noAvaranCapillarySettingDetails.PordPayKindSabt;
								switch (text4)
								{
								case "0":
									kindSabtDis = "چک";
									break;
								case "1":
									kindSabtDis = "واریز";
									break;
								case "2":
									kindSabtDis = "نقد";
									break;
								}
							}
							string modat = "0";
							string text5 = "";
							string text6 = "";
							string text7 = "";
							string text8 = "";
							try
							{
								DateTime dateTime = cRMspLkWSSelectPreOrderPaymentsWithId_Result.ImportDateTime ?? DateTime.Now;
								if (num == 2)
								{
									dateTime = cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayDocDateTime ?? DateTime.Now;
								}
								DateTime dateTime2 = dateTime;
								text5 = dateTime2.ToString("yyyy/MM/dd", new PersianCulture());
								dateTime = cRMspLkWSSelectPreOrderPaymentsWithId_Result.ImportDateTime ?? DateTime.Now;
								if (num2 == 2)
								{
									dateTime = cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayDocDateTime ?? DateTime.Now;
								}
								dateTime2 = dateTime;
								text6 = dateTime2.ToString("yyyy/MM/dd", new PersianCulture());
								dateTime = cRMspLkWSSelectPreOrderPaymentsWithId_Result.ImportDateTime ?? DateTime.Now;
								if (num3 == 2)
								{
									dateTime = cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayDocDateTime ?? DateTime.Now;
								}
								dateTime2 = dateTime;
								text7 = dateTime2.ToString("yyyy/MM/dd", new PersianCulture());
								dateTime = cRMspLkWSSelectPreOrderPaymentsWithId_Result.ImportDateTime ?? DateTime.Now;
								if (num4 == 2)
								{
									dateTime = cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayDocDateTime ?? DateTime.Now;
								}
								dateTime2 = dateTime;
								text8 = dateTime2.ToString("yyyy/MM/dd", new PersianCulture());
							}
							catch (Exception e)
							{
								ErrorSignal.FromCurrentContext().Raise(e);
								text = string.Format(Messages.ErrorInFormat, Labels.Date);
								return text;
							}
							if (!string.IsNullOrWhiteSpace(cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayLinkAccHeaderIdStr))
							{
								LkWSPreOrderPaymentsInfoViewModel noAvaranCapillaryPayment = GetNoAvaranCapillaryPayment(text5, text5, cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayLinkAccHeaderNumber ?? "", cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayLinkAccHeaderIdStr ?? "");
								if (noAvaranCapillaryPayment != null)
								{
									if (!string.IsNullOrWhiteSpace(noAvaranCapillaryPayment.pordpayLinkAccHeaderIdStr))
									{
										text = string.Format(Messages.msgErrorNotReSendPordPayToOtherSystem, cRMspLkWSSelectPreOrderPaymentsWithId_Result.PayTypeTitle, text2, cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordNumber.ToString(), noAvaranCapillary) + "|";
										return text;
									}
									_dbLink.WSspUpdatePreOrderPaymentWithAccLinkField(payId, null, null, null, null, null, null, null, null, null, null, true, userId, value2, value, registerDatePersian, appType);
								}
							}
							if (string.IsNullOrWhiteSpace(value3) || string.IsNullOrWhiteSpace(text3) || !string.IsNullOrWhiteSpace(cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayLinkAccHeaderIdStr))
							{
								text = ((!string.IsNullOrWhiteSpace(value3) && !string.IsNullOrWhiteSpace(text3)) ? (string.IsNullOrWhiteSpace(cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayLinkAccHeaderNumber) ? (Messages.msgErrorRunFunction + "|") : ("1|" + cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayLinkAccHeaderNumber)) : (Messages.errorInReadingSetting + "|"));
							}
							else
							{
								string text9 = "";
								CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordCompanyId.GetValueOrDefault());
								if (companyById == null)
								{
									text = Messages.CompanyNotFound + "|";
									return text;
								}
								text9 = companyById.cmpLinkAccCustomerIdStr ?? "";
								if (string.IsNullOrWhiteSpace(text9))
								{
									string text10 = new CompanyController().NoAvaranCapillaryActCmpSendToAcc(cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordCompanyId.GetValueOrDefault(), noAvIdCompany, 0, 0, 0, checkAction: false);
									if (string.IsNullOrEmpty(text10))
									{
										text = Messages.msgErrorRunFunction + "(insert company to noavaran)|";
										return text;
									}
									string[] array = text10.Split(new char[1] { '|' });
									if (array != null)
									{
										if (!(array[0] == "1"))
										{
											text = array[0] + "|";
											return text;
										}
										companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordCompanyId.GetValueOrDefault());
										if (companyById == null)
										{
											text = Messages.CompanyNotFound + "|";
											return text;
										}
										text9 = companyById.cmpLinkAccCustomerIdStr ?? "";
									}
								}
								if (string.IsNullOrWhiteSpace(text9))
								{
									text = string.Format(Messages.msgErrorInSendToAccLinkNotFoundCmpInAcc, noAvaranCapillary);
									return text;
								}
								string text11 = "0";
								CommercialSoapClient commercialSoapClient = new CommercialSoapClient();
								string text12 = commercialSoapClient.Idealsp_LastResidno();
								if (!string.IsNullOrWhiteSpace(text12))
								{
									text12 = text12.ClearHiddenCharacters();
								}
								if (!string.IsNullOrWhiteSpace(text12))
								{
									text11 = text12;
									text12 = commercialSoapClient.Idealsp_InsertDaryaft(text11, text9, text5, text6, text7, noAvIdCompany.ToString(), text3, uDate, time, cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayDescription ?? "", "", "", "", "");
									if (!string.IsNullOrWhiteSpace(text12))
									{
										text12 = text12.ClearHiddenCharacters();
									}
									if (!string.IsNullOrWhiteSpace(text12))
									{
										if (!string.IsNullOrWhiteSpace(text12))
										{
											if (text12.ToLower().IndexOf("Success Daryaft".ToLower(), StringComparison.Ordinal) >= 0)
											{
												text12 = "";
												text12 = commercialSoapClient.Idealsp_InsertDaryaftDetail(text11, text9, CheckDate: text8, CheckNo: cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayDocNumber ?? " ", Mablagh: pordpayAmount.ToString(), Bank: "", CodeShobeh: "", Jari: "", Modat: modat, NameShobeh: cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayDescription ?? " ", Radif: "1", SahebCheck: " ", FactorNo: "", NDaftar: "", KindSabt: text4, IdFactorTasvie: "", KindSabtDis: kindSabtDis, CheckNoKamel: "", ShSayadi: "", KindDis: "", CodeRahgiri: "");
												if (!string.IsNullOrWhiteSpace(text12))
												{
													text12 = text12.ClearHiddenCharacters();
												}
												if (!string.IsNullOrWhiteSpace(text12))
												{
													if (text12.ToLower().IndexOf("Success DaryaftDetail".ToLower(), StringComparison.Ordinal) >= 0)
													{
														string pordpayLinkAccHeaderIdStr = "";
														string text13 = text11;
														string pordpayLinkAccDetailIdStr = "";
														LkWSPreOrderPaymentsInfoViewModel noAvaranCapillaryPayment2 = GetNoAvaranCapillaryPayment(text5, text5, text13 ?? "");
														if (noAvaranCapillaryPayment2 != null && !string.IsNullOrWhiteSpace(noAvaranCapillaryPayment2.pordpayLinkAccHeaderIdStr))
														{
															pordpayLinkAccHeaderIdStr = noAvaranCapillaryPayment2.pordpayLinkAccHeaderIdStr ?? "";
														}
														if (!string.IsNullOrWhiteSpace(text13))
														{
															_dbLink.WSspUpdatePreOrderPaymentWithAccLinkField(payId, null, text13, null, null, null, pordpayLinkAccHeaderIdStr, pordpayLinkAccDetailIdStr, null, null, null, false, userId, value2, value, registerDatePersian, appType);
															text = "1|" + text13;
														}
														else
														{
															text = text + "<br>" + Messages.msgErrorCommunicateWithServer + "|";
														}
													}
													else
													{
														text = text + "<br>" + text12 + "|";
													}
												}
												else
												{
													text = text + "<br>" + Messages.msgErrorCommunicateWithServer + "|";
												}
											}
											else
											{
												text = text + "<br>" + Messages.msgErrorCommunicateWithServer + "|";
											}
										}
										else
										{
											text = text + "<br>" + Messages.msgErrorCommunicateWithServer + "|";
										}
									}
									else
									{
										text = text + "<br>" + Messages.msgErrorCommunicateWithServer + "|";
									}
								}
								else
								{
									text = text + "<br>" + Messages.msgErrorCommunicateWithServer + "|";
								}
							}
						}
						else
						{
							text = Messages.errorInReadingSetting + "|";
						}
					}
					else
					{
						text = Messages.ErrorNotFound + "|";
					}
				}
				catch (Exception ex)
				{
					text = text + "\n\nException: " + ex.Message;
				}
			}
			else
			{
				text = Messages.ErrorNotFound + "|";
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			text = Messages.msgErrorRunFunction + "|";
		}
		return text;
	}

	public List<SelectListItem> GetNoAvaranCapillaryPrdGrouos()
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
			LkProductSecondGroupInfoViewModelObjects noAvaranCapillaryProductGroupList = new ProductGroupController().GetNoAvaranCapillaryProductGroupList();
			if (noAvaranCapillaryProductGroupList != null)
			{
				List<LkProductSecondGroupInfoViewModel> lst = noAvaranCapillaryProductGroupList.lst;
				if (lst != null && Enumerable.Any<LkProductSecondGroupInfoViewModel>((IEnumerable<LkProductSecondGroupInfoViewModel>)lst))
				{
					list.AddRange(Enumerable.Select<LkProductSecondGroupInfoViewModel, SelectListItem>((IEnumerable<LkProductSecondGroupInfoViewModel>)lst, (Func<LkProductSecondGroupInfoViewModel, SelectListItem>)((LkProductSecondGroupInfoViewModel item) => new SelectListItem
					{
						Text = (item.SGName ?? ""),
						Value = (item.SGLinkAccGroupIdStr ?? ""),
						Selected = false
					})));
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	public LkPreOrderInfoViewModelObjects GetNilramPreOrderList(string fDate = "", string tDate = "", string number = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		LkPreOrderInfoViewModelObjects lkPreOrderInfoViewModelObjects = new LkPreOrderInfoViewModelObjects();
		List<LkWSPreOrderInfoViewModel> list = new List<LkWSPreOrderInfoViewModel>();
		List<LkWSPreOrderItemsInfoViewModel> list2 = new List<LkWSPreOrderItemsInfoViewModel>();
		try
		{
			CRMIdeal.Classes.Helper.OtherSystems.NilramSettingViewModel nilramSetting = CRMIdeal.Classes.Helper.OtherSystems.GetNilramSetting();
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
					string text2 = "null";
					string text3 = "null";
					try
					{
						DateTime now = DateTime.Now;
						DateTime now2 = DateTime.Now;
						if (!string.IsNullOrWhiteSpace(fDate))
						{
							fDate = fDate.Replace("/", "").Replace("-", "").Replace("\\", "")
								.Replace(" ", "")
								.Replace("_", "");
							text2 = (lCID switch
							{
								1065 => DateTime.Parse(PersianDate.GetFormatetdDate(fDate) + " 00:00:00"), 
								1025 => DateTime.Parse(PersianDate.GetFormatetdDate(fDate) + " 00:00:00", new CultureInfo("ar-SA"), DateTimeStyles.None), 
								_ => DateTime.Parse(PersianDate.GetFormatetdDate(fDate) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None), 
							}).ToString("yyyy-MM-dd", new PersianCulture());
						}
						if (!string.IsNullOrEmpty(tDate))
						{
							tDate = tDate.Replace("/", "").Replace("-", "").Replace("\\", "")
								.Replace(" ", "")
								.Replace("_", "");
							text3 = (lCID switch
							{
								1065 => DateTime.Parse(PersianDate.GetFormatetdDate(tDate) + " 23:59:59"), 
								1025 => DateTime.Parse(PersianDate.GetFormatetdDate(tDate) + " 23:59:59", new CultureInfo("ar-SA"), DateTimeStyles.None), 
								_ => DateTime.Parse(PersianDate.GetFormatetdDate(tDate) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None), 
							}).ToString("yyyy-MM-dd", new PersianCulture());
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
					}
					if (string.IsNullOrWhiteSpace(number))
					{
						number = "null";
					}
					HttpClient httpClient = new HttpClient();
					string text4 = text + "SALE_ORDERS/" + number + "/" + text2 + "/" + text3;
					httpClient.BaseAddress = new Uri(text4);
					httpClient.DefaultRequestHeaders.Add("Access-Token", value);
					httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
					new StringContent("", Encoding.UTF8, "application/json");
					HttpResponseMessage result2 = httpClient.GetAsync(text4).Result;
					if (result2.IsSuccessStatusCode)
					{
						string value2 = result2.Content.ReadAsStringAsync().Result;
						if (!string.IsNullOrWhiteSpace(value2))
						{
							value2 = value2.ClearHiddenCharacters();
						}
						if (!string.IsNullOrWhiteSpace(value2))
						{
							List<NilramPreOrderInfoViewModel> list3 = JsonConvert.DeserializeObject<List<NilramPreOrderInfoViewModel>>(value2);
							if (list3 != null && Enumerable.Any<NilramPreOrderInfoViewModel>((IEnumerable<NilramPreOrderInfoViewModel>)list3))
							{
								List<WSspSelectPreOrderWithAccLinkField_Result> list4 = SelectPreOrderWithAccLinkField(withPordpordLinkAccPreOrderId: false, withPordpordLinkAccPreOrderIdStr: true);
								List<CRMspSelectCompanyWithAccLinkField_Result> list5 = new CompanyController().SelectCompanyWithAccLinkField(withLinkAccCode: false, withLinkAccCodeId: false, withLinkCustomerId: false, withLinkCustomerIdStr: true);
								int num = 1;
								foreach (NilramPreOrderInfoViewModel item in list3)
								{
									string text5 = "";
									LkWSPreOrderInfoViewModel vmPord = new LkWSPreOrderInfoViewModel();
									vmPord.pordDate = item.sef_dt;
									DateTime dateTime = default(DateTime);
									if (item.sef_dt_miladi != null)
									{
										DateTime dateTime2 = DateTime.Parse(item.sef_dt_miladi, new CultureInfo("en-US"));
										LkWSPreOrderInfoViewModel lkWSPreOrderInfoViewModel = vmPord;
										DateTime dateTime3 = dateTime2;
										lkWSPreOrderInfoViewModel.pordDate = dateTime3.ToString("yyyyMMdd", new PersianCulture());
										vmPord.pordDateTime = dateTime2;
									}
									else if (!string.IsNullOrWhiteSpace(item.sef_dt))
									{
										dateTime = DateTime.Parse(PersianDate.GetFormatetdDate(item.sef_dt.Replace("/", "")) + " 00:00:00", new PersianCulture());
										vmPord.pordDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
										vmPord.pordDateTime = dateTime;
									}
									text5 = (vmPord.pordDateTime.HasValue ? vmPord.pordDateTime.Value.ToString("yyyy-MM-dd", new PersianCulture()) : "null");
									vmPord.pordLinkAccPreOrderIdStr = item.id_seq.GetValueOrDefault().ToString();
									vmPord.pordLinkAccPreOrderNumber = item.sef_no.GetValueOrDefault().ToString();
									vmPord.cmpLinkAccCustomerIdStr = item.custcode.GetValueOrDefault().ToString();
									if (list5 != null && !string.IsNullOrWhiteSpace(vmPord.cmpLinkAccCustomerIdStr) && Enumerable.Any<CRMspSelectCompanyWithAccLinkField_Result>((IEnumerable<CRMspSelectCompanyWithAccLinkField_Result>)list5))
									{
										CRMspSelectCompanyWithAccLinkField_Result cRMspSelectCompanyWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyWithAccLinkField_Result>((IEnumerable<CRMspSelectCompanyWithAccLinkField_Result>)list5, (Func<CRMspSelectCompanyWithAccLinkField_Result, bool>)((CRMspSelectCompanyWithAccLinkField_Result m) => m.cmpLinkAccCustomerIdStr == vmPord.cmpLinkAccCustomerIdStr));
										if (cRMspSelectCompanyWithAccLinkField_Result != null)
										{
											vmPord.pordCompanyId = cRMspSelectCompanyWithAccLinkField_Result.CompanyID;
											vmPord.cmpName = cRMspSelectCompanyWithAccLinkField_Result.CompanyName ?? "";
											vmPord.cmpLinkAccCode = cRMspSelectCompanyWithAccLinkField_Result.cmpLinkAccCode;
										}
									}
									if (string.IsNullOrWhiteSpace(vmPord.cmpName))
									{
										vmPord.cmpName = string.Format(Labels.OtherSystemsItemNotLinked, Labels.lblCmp);
										if (!string.IsNullOrWhiteSpace(vmPord.cmpLinkAccCustomerIdStr))
										{
											LkWSPreOrderInfoViewModel lkWSPreOrderInfoViewModel2 = vmPord;
											lkWSPreOrderInfoViewModel2.cmpName = lkWSPreOrderInfoViewModel2.cmpName + " (" + vmPord.cmpLinkAccCustomerIdStr + ")";
										}
									}
									vmPord.LinkAccReferUserIdStr = item.bazaryab ?? "";
									vmPord.LinkAccReferUserCode = vmPord.LinkAccReferUserIdStr;
									vmPord.LinkAccSellerUserIdStr = item.karshenas ?? "";
									vmPord.LinkAccSellerUserCode = vmPord.LinkAccSellerUserIdStr;
									vmPord.pordTotalAmount = item.orders_mab.GetValueOrDefault();
									httpClient = new HttpClient();
									text4 = text + "SALE_ORDERS_PRSL/" + vmPord.pordLinkAccPreOrderNumber + "/" + text5 + "/" + text5;
									httpClient.BaseAddress = new Uri(text4);
									httpClient.DefaultRequestHeaders.Add("Access-Token", value);
									httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
									new StringContent("", Encoding.UTF8, "application/json");
									result2 = httpClient.GetAsync(text4).Result;
									if (result2.IsSuccessStatusCode)
									{
										value2 = result2.Content.ReadAsStringAsync().Result;
										if (!string.IsNullOrWhiteSpace(value2))
										{
											value2 = value2.ClearHiddenCharacters();
										}
										if (!string.IsNullOrWhiteSpace(value2))
										{
											List<NilramPreOrderUsersInfoViewModel> list6 = JsonConvert.DeserializeObject<List<NilramPreOrderUsersInfoViewModel>>(value2);
											if (list6 != null && Enumerable.Any<NilramPreOrderUsersInfoViewModel>((IEnumerable<NilramPreOrderUsersInfoViewModel>)list6))
											{
												NilramPreOrderUsersInfoViewModel nilramPreOrderUsersInfoViewModel = Enumerable.FirstOrDefault<NilramPreOrderUsersInfoViewModel>((IEnumerable<NilramPreOrderUsersInfoViewModel>)list6);
												if (nilramPreOrderUsersInfoViewModel != null)
												{
													vmPord.ReferUserLName = nilramPreOrderUsersInfoViewModel.PRSL_BAZARYAB_name ?? "";
													vmPord.LinkAccReferUserIdStr = nilramPreOrderUsersInfoViewModel.PRSL_BAZARYAB ?? "";
													vmPord.LinkAccReferUserCode = vmPord.LinkAccReferUserIdStr;
													vmPord.SellerUserLName = nilramPreOrderUsersInfoViewModel.PRSL_FURUSH_name ?? "";
													vmPord.LinkAccSellerUserIdStr = nilramPreOrderUsersInfoViewModel.PRSL_FURUSH ?? "";
													vmPord.LinkAccSellerUserCode = vmPord.LinkAccSellerUserIdStr;
												}
											}
										}
									}
									httpClient = new HttpClient();
									text4 = text + "SALE_ORDERS_DET/" + vmPord.pordLinkAccPreOrderNumber + "/" + text5 + "/" + text5;
									httpClient.BaseAddress = new Uri(text4);
									httpClient.DefaultRequestHeaders.Add("Access-Token", value);
									httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
									new StringContent("", Encoding.UTF8, "application/json");
									result2 = httpClient.GetAsync(text4).Result;
									if (result2.IsSuccessStatusCode)
									{
										value2 = result2.Content.ReadAsStringAsync().Result;
										if (!string.IsNullOrWhiteSpace(value2))
										{
											value2 = value2.ClearHiddenCharacters();
										}
										if (!string.IsNullOrWhiteSpace(value2))
										{
											List<NilramPreOrderItemsInfoViewModel> list7 = JsonConvert.DeserializeObject<List<NilramPreOrderItemsInfoViewModel>>(value2);
											if (list7 != null && Enumerable.Any<NilramPreOrderItemsInfoViewModel>((IEnumerable<NilramPreOrderItemsInfoViewModel>)list7))
											{
												list7 = Enumerable.ToList<NilramPreOrderItemsInfoViewModel>((IEnumerable<NilramPreOrderItemsInfoViewModel>)Enumerable.OrderBy<NilramPreOrderItemsInfoViewModel, int>((IEnumerable<NilramPreOrderItemsInfoViewModel>)list7, (Func<NilramPreOrderItemsInfoViewModel, int>)((NilramPreOrderItemsInfoViewModel m) => m.rdf.GetValueOrDefault())));
												foreach (NilramPreOrderItemsInfoViewModel item2 in list7)
												{
													LkWSPreOrderItemsInfoViewModel lkWSPreOrderItemsInfoViewModel = new LkWSPreOrderItemsInfoViewModel();
													lkWSPreOrderItemsInfoViewModel.pordLinkAccPreOrderIdStr = vmPord.pordLinkAccPreOrderIdStr;
													lkWSPreOrderItemsInfoViewModel.pordLinkAccPreOrderNumber = vmPord.pordLinkAccPreOrderNumber;
													lkWSPreOrderItemsInfoViewModel.PrdLinkAccPrdCode = item2.t_stk_gds;
													lkWSPreOrderItemsInfoViewModel.pordIQuantity = item2.request_qty.GetValueOrDefault(1.0);
													lkWSPreOrderItemsInfoViewModel.pordIPrice = item2.real_price.GetValueOrDefault();
													lkWSPreOrderItemsInfoViewModel.pordITotalPrice = item2.rest_price.GetValueOrDefault();
													lkWSPreOrderItemsInfoViewModel.WrhsLinkAccWhCode = item2.t_stk_no;
													lkWSPreOrderItemsInfoViewModel.pordIDiscountSum = item2.sum_kosor.GetValueOrDefault();
													list2.Add(lkWSPreOrderItemsInfoViewModel);
												}
											}
										}
									}
									vmPord.RowNumber = num;
									if (list4 != null && Enumerable.Any<WSspSelectPreOrderWithAccLinkField_Result>((IEnumerable<WSspSelectPreOrderWithAccLinkField_Result>)list4))
									{
										WSspSelectPreOrderWithAccLinkField_Result wSspSelectPreOrderWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectPreOrderWithAccLinkField_Result>((IEnumerable<WSspSelectPreOrderWithAccLinkField_Result>)list4, (Func<WSspSelectPreOrderWithAccLinkField_Result, bool>)((WSspSelectPreOrderWithAccLinkField_Result x) => x.pordLinkAccPreOrderIdStr == vmPord.pordLinkAccPreOrderIdStr));
										if (wSspSelectPreOrderWithAccLinkField_Result != null)
										{
											if (!string.IsNullOrWhiteSpace(wSspSelectPreOrderWithAccLinkField_Result.pordLinkAccPreOrderIdStr))
											{
												vmPord.PreOrderID = wSspSelectPreOrderWithAccLinkField_Result.PreOrderID;
											}
										}
										else
										{
											vmPord.PreOrderID = 0;
										}
									}
									list.Add(vmPord);
									num++;
								}
							}
						}
					}
				}
			}
			lkPreOrderInfoViewModelObjects.lst = list;
			lkPreOrderInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			lkPreOrderInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
			lkPreOrderInfoViewModelObjects.lstItems = list2;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return lkPreOrderInfoViewModelObjects;
	}

	public List<LkWSPreOrderPaymentsInfoViewModel> GetNilramPreOrderPaymentsList(string fDate = "", string tDate = "", string number = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<LkWSPreOrderPaymentsInfoViewModel> list = new List<LkWSPreOrderPaymentsInfoViewModel>();
		try
		{
			CRMIdeal.Classes.Helper.OtherSystems.NilramSettingViewModel nilramSetting = CRMIdeal.Classes.Helper.OtherSystems.GetNilramSetting();
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
					string text2 = "";
					string text3 = "";
					try
					{
						DateTime now = DateTime.Now;
						DateTime now2 = DateTime.Now;
						if (!string.IsNullOrWhiteSpace(fDate))
						{
							fDate = fDate.Replace("/", "").Replace("-", "").Replace("\\", "")
								.Replace(" ", "")
								.Replace("_", "");
							text2 = (lCID switch
							{
								1065 => DateTime.Parse(PersianDate.GetFormatetdDate(fDate) + " 00:00:00"), 
								1025 => DateTime.Parse(PersianDate.GetFormatetdDate(fDate) + " 00:00:00", new CultureInfo("ar-SA"), DateTimeStyles.None), 
								_ => DateTime.Parse(PersianDate.GetFormatetdDate(fDate) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None), 
							}).ToString("yyyy-MM-dd", new PersianCulture());
						}
						if (!string.IsNullOrEmpty(tDate))
						{
							tDate = tDate.Replace("/", "").Replace("-", "").Replace("\\", "")
								.Replace(" ", "")
								.Replace("_", "");
							text3 = (lCID switch
							{
								1065 => DateTime.Parse(PersianDate.GetFormatetdDate(tDate) + " 23:59:59"), 
								1025 => DateTime.Parse(PersianDate.GetFormatetdDate(tDate) + " 23:59:59", new CultureInfo("ar-SA"), DateTimeStyles.None), 
								_ => DateTime.Parse(PersianDate.GetFormatetdDate(tDate) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None), 
							}).ToString("yyyy-MM-dd", new PersianCulture());
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
					}
					if (string.IsNullOrWhiteSpace(number))
					{
						number = "null";
					}
					HttpClient httpClient = new HttpClient();
					string text4 = text + "SALE_TASVIE/" + number + "/" + text2 + "/" + text3;
					httpClient.BaseAddress = new Uri(text4);
					httpClient.DefaultRequestHeaders.Add("Access-Token", value);
					httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
					new StringContent("", Encoding.UTF8, "application/json");
					HttpResponseMessage result2 = httpClient.GetAsync(text4).Result;
					if (result2.IsSuccessStatusCode)
					{
						string value2 = result2.Content.ReadAsStringAsync().Result;
						if (!string.IsNullOrWhiteSpace(value2))
						{
							value2 = value2.ClearHiddenCharacters();
						}
						if (!string.IsNullOrWhiteSpace(value2))
						{
							List<NilramPreOrderPaymentsInfoViewModel> list2 = JsonConvert.DeserializeObject<List<NilramPreOrderPaymentsInfoViewModel>>(value2);
							if (list2 != null && Enumerable.Any<NilramPreOrderPaymentsInfoViewModel>((IEnumerable<NilramPreOrderPaymentsInfoViewModel>)list2))
							{
								list2 = Enumerable.ToList<NilramPreOrderPaymentsInfoViewModel>((IEnumerable<NilramPreOrderPaymentsInfoViewModel>)Enumerable.OrderBy<NilramPreOrderPaymentsInfoViewModel, long>((IEnumerable<NilramPreOrderPaymentsInfoViewModel>)list2, (Func<NilramPreOrderPaymentsInfoViewModel, long>)((NilramPreOrderPaymentsInfoViewModel m) => m.id.GetValueOrDefault())));
								foreach (NilramPreOrderPaymentsInfoViewModel item in list2)
								{
									LkWSPreOrderPaymentsInfoViewModel lkWSPreOrderPaymentsInfoViewModel = new LkWSPreOrderPaymentsInfoViewModel();
									lkWSPreOrderPaymentsInfoViewModel.pordpayLinkAccHeaderIdStr = item.id.GetValueOrDefault().ToString();
									lkWSPreOrderPaymentsInfoViewModel.pordLinkAccPreOrderIdStr = item.id_seq.GetValueOrDefault().ToString();
									lkWSPreOrderPaymentsInfoViewModel.pordLinkAccPreOrderNumber = item.sef_no.GetValueOrDefault().ToString();
									lkWSPreOrderPaymentsInfoViewModel.pordpayAmount = (item.total_price ?? item.TOTAL_PRICE_ARZI).GetValueOrDefault();
									lkWSPreOrderPaymentsInfoViewModel.pordpayDocAmount = lkWSPreOrderPaymentsInfoViewModel.pordpayAmount;
									if (item.date_dedline != null)
									{
										DateTime dateTime = DateTime.Parse(item.date_dedline, new CultureInfo("en-US"));
										DateTime dateTime2 = dateTime;
										lkWSPreOrderPaymentsInfoViewModel.pordpayDocDate = dateTime2.ToString("yyyyMMdd", new PersianCulture());
										lkWSPreOrderPaymentsInfoViewModel.pordpayDocDateTime = dateTime;
										lkWSPreOrderPaymentsInfoViewModel.ImportDate = lkWSPreOrderPaymentsInfoViewModel.pordpayDocDate;
										lkWSPreOrderPaymentsInfoViewModel.ImportDateTime = lkWSPreOrderPaymentsInfoViewModel.pordpayDocDateTime;
									}
									list.Add(lkWSPreOrderPaymentsInfoViewModel);
								}
							}
						}
					}
				}
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return list;
	}

	public LkPreOrderInfoViewModelObjects GetRahkaranInternalSalesPreOrderList(string fDate = "", string tDate = "", long linkAccId = 0L, bool isUpdateList = false)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		LkPreOrderInfoViewModelObjects lkPreOrderInfoViewModelObjects = new LkPreOrderInfoViewModelObjects();
		List<LkWSPreOrderInfoViewModel> list = new List<LkWSPreOrderInfoViewModel>();
		List<LkWSPreOrderItemsInfoViewModel> list2 = new List<LkWSPreOrderItemsInfoViewModel>();
		try
		{
			string text = fDate;
			string text2 = tDate;
			string fromDate = "";
			string toDate = "";
			try
			{
				DateTime now = DateTime.Now;
				DateTime now2 = DateTime.Now;
				if (!string.IsNullOrWhiteSpace(text))
				{
					text = text.Replace("/", "").Replace("-", "").Replace("\\", "")
						.Replace(" ", "")
						.Replace("_", "");
					fromDate = "\\/Date(" + ((DateTimeOffset)(lCID switch
					{
						1065 => DateTime.Parse(PersianDate.GetFormatetdDate(text) + " 00:00:00"), 
						1025 => DateTime.Parse(PersianDate.GetFormatetdDate(text) + " 00:00:00", new CultureInfo("ar-SA"), DateTimeStyles.None), 
						_ => DateTime.Parse(PersianDate.GetFormatetdDate(text) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None), 
					})).ToUnixTimeMilliseconds() + "+0330)\\/";
				}
				if (!string.IsNullOrEmpty(text2))
				{
					text2 = text2.Replace("/", "").Replace("-", "").Replace("\\", "")
						.Replace(" ", "")
						.Replace("_", "");
					toDate = "\\/Date(" + ((DateTimeOffset)(lCID switch
					{
						1065 => DateTime.Parse(PersianDate.GetFormatetdDate(text2) + " 23:59:59"), 
						1025 => DateTime.Parse(PersianDate.GetFormatetdDate(text2) + " 23:59:59", new CultureInfo("ar-SA"), DateTimeStyles.None), 
						_ => DateTime.Parse(PersianDate.GetFormatetdDate(text2) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None), 
					})).ToUnixTimeMilliseconds() + "+0330)\\/";
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
			CRMIdeal.Classes.Helper.OtherSystems.RahkaranInternalSalesProvider rahkaranInternalSalesProvider = new CRMIdeal.Classes.Helper.OtherSystems.RahkaranInternalSalesProvider(isUpdateList);
			string value = rahkaranInternalSalesProvider.GetQuotationsList(fromDate, toDate, linkAccId);
			if (!string.IsNullOrWhiteSpace(value))
			{
				if (!string.IsNullOrWhiteSpace(value))
				{
					value = value.ClearHiddenCharacters();
				}
				if (!string.IsNullOrWhiteSpace(value))
				{
					List<RahkaranInternalSalesQuotationResponseViewModel> list3 = JsonConvert.DeserializeObject<List<RahkaranInternalSalesQuotationResponseViewModel>>(value);
					if (list3 != null && Enumerable.Any<RahkaranInternalSalesQuotationResponseViewModel>((IEnumerable<RahkaranInternalSalesQuotationResponseViewModel>)list3))
					{
						int value2 = 22;
						int value3 = -1;
						List<CRMspSelectLinkAccSettingDetails_Result> list4 = Enumerable.ToList<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)_dbLink.CRMspSelectLinkAccSettingDetails(0, 0, "PordPayCondition", lCID, result, value2, value3));
						List<WSspSelectPreOrderWithAccLinkField_Result> list5 = SelectPreOrderWithAccLinkField(withPordpordLinkAccPreOrderId: false, withPordpordLinkAccPreOrderIdStr: true);
						List<LkCompanyAndPersonViewModel> listCompany = rahkaranInternalSalesProvider.GetListCompany(false);
						List<LkProductInfoViewModel> listProduct = rahkaranInternalSalesProvider.GetListProduct(false);
						int num = 1;
						foreach (RahkaranInternalSalesQuotationResponseViewModel itemHead in list3)
						{
							LkWSPreOrderInfoViewModel vmPord = new LkWSPreOrderInfoViewModel();
							if (itemHead.Date.HasValue)
							{
								vmPord.pordDateTime = DateTime.Parse(itemHead.Date.Value.ToString("yyyy-MM-dd"));
								vmPord.pordDate = (vmPord.pordDateTime.HasValue ? vmPord.pordDateTime.Value.ToString("yyyyMMdd") : "");
							}
							if (itemHead.ExpirationDate.HasValue)
							{
								vmPord.pordExpireDateTime = DateTime.Parse(itemHead.ExpirationDate.Value.ToString("yyyy-MM-dd"));
								vmPord.pordExpireDate = (vmPord.pordExpireDateTime.HasValue ? vmPord.pordExpireDateTime.Value.ToString("yyyyMMdd") : "");
							}
							vmPord.pordLinkAccPreOrderIdStr = itemHead.ID.GetValueOrDefault().ToString();
							vmPord.pordLinkAccPreOrderNumber = itemHead.Number;
							vmPord.cmpLinkAccCustomerIdStr = itemHead.CustomerRef.GetValueOrDefault().ToString();
							if (listCompany != null && !string.IsNullOrWhiteSpace(vmPord.cmpLinkAccCustomerIdStr) && Enumerable.Any<LkCompanyAndPersonViewModel>((IEnumerable<LkCompanyAndPersonViewModel>)listCompany))
							{
								LkCompanyAndPersonViewModel lkCompanyAndPersonViewModel = Enumerable.FirstOrDefault<LkCompanyAndPersonViewModel>((IEnumerable<LkCompanyAndPersonViewModel>)listCompany, (Func<LkCompanyAndPersonViewModel, bool>)((LkCompanyAndPersonViewModel m) => m.cmpLinkAccCustomerIdStr == vmPord.cmpLinkAccCustomerIdStr));
								if (lkCompanyAndPersonViewModel != null)
								{
									vmPord.pordCompanyId = lkCompanyAndPersonViewModel.CompanyId;
									vmPord.cmpName = lkCompanyAndPersonViewModel.cmpName + ((!string.IsNullOrWhiteSpace(lkCompanyAndPersonViewModel.prsFName) || !string.IsNullOrWhiteSpace(lkCompanyAndPersonViewModel.prsLName)) ? (" (" + ((!string.IsNullOrWhiteSpace(lkCompanyAndPersonViewModel.prsFName)) ? (lkCompanyAndPersonViewModel.prsFName + " ") : "") + ((!string.IsNullOrWhiteSpace(lkCompanyAndPersonViewModel.prsLName)) ? lkCompanyAndPersonViewModel.prsLName : "") + ")") : "");
									vmPord.cmpLinkAccCode = lkCompanyAndPersonViewModel.cmpLinkAccCode;
								}
							}
							vmPord.LinkAccReferUserIdStr = itemHead.BrokerRef.GetValueOrDefault().ToString();
							if (itemHead.CurrencyRef.GetValueOrDefault() != 0L)
							{
								vmPord.LinkAccCurrencyUnitIdStr = itemHead.CurrencyRef.GetValueOrDefault().ToString();
							}
							vmPord.pordTotalAmount = itemHead.NetPrice.GetValueOrDefault();
							vmPord.pordDescriptionI = itemHead.Description;
							if (itemHead.SalesTypeRef.GetValueOrDefault() != 0L)
							{
								vmPord.LinkAccPreOrderTypeIdStr = itemHead.SalesTypeRef.GetValueOrDefault().ToString();
							}
							if (itemHead.PlantRef.GetValueOrDefault() != 0L)
							{
								vmPord.LinkAccPreOrderOprIdStr = itemHead.PlantRef.GetValueOrDefault().ToString();
							}
							if (itemHead.SalesOfficeRef.GetValueOrDefault() != 0L)
							{
								vmPord.LinkAccSaleCenterIdStr = itemHead.SalesOfficeRef.GetValueOrDefault().ToString();
							}
							if (itemHead.PaymentAgreementRef.GetValueOrDefault() != 0L && list4 != null && Enumerable.Any<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list4))
							{
								CRMspSelectLinkAccSettingDetails_Result cRMspSelectLinkAccSettingDetails_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list4, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result m) => (m.PartValue ?? "") == itemHead.PaymentAgreementRef.GetValueOrDefault().ToString()));
								if (cRMspSelectLinkAccSettingDetails_Result != null)
								{
									int result2 = 0;
									int.TryParse(cRMspSelectLinkAccSettingDetails_Result.ObjectId.ToString(), out result2);
									if (result2 != 0)
									{
										vmPord.pordPayConditionId = result2;
									}
								}
							}
							List<RahkaranInternalSalesQuotationItemResponseViewModel> items = itemHead.Items;
							decimal num2 = default(decimal);
							decimal value4 = default(decimal);
							if (items != null && Enumerable.Any<RahkaranInternalSalesQuotationItemResponseViewModel>((IEnumerable<RahkaranInternalSalesQuotationItemResponseViewModel>)items))
							{
								items = Enumerable.ToList<RahkaranInternalSalesQuotationItemResponseViewModel>((IEnumerable<RahkaranInternalSalesQuotationItemResponseViewModel>)Enumerable.OrderBy<RahkaranInternalSalesQuotationItemResponseViewModel, int>((IEnumerable<RahkaranInternalSalesQuotationItemResponseViewModel>)items, (Func<RahkaranInternalSalesQuotationItemResponseViewModel, int>)((RahkaranInternalSalesQuotationItemResponseViewModel m) => m.RowNumber.GetValueOrDefault())));
								foreach (RahkaranInternalSalesQuotationItemResponseViewModel item in items)
								{
									LkWSPreOrderItemsInfoViewModel vmPordItem = new LkWSPreOrderItemsInfoViewModel();
									vmPordItem.pordLinkAccPreOrderIdStr = itemHead.ID.GetValueOrDefault().ToString();
									vmPordItem.pordLinkAccPreOrderNumber = itemHead.Number;
									vmPordItem.PrdLinkAccPrdIdStr = item.ProductRef.GetValueOrDefault().ToString();
									vmPordItem.pordILinkAccItemIdStr = item.ID.GetValueOrDefault().ToString();
									if (listProduct != null && Enumerable.Any<LkProductInfoViewModel>((IEnumerable<LkProductInfoViewModel>)listProduct))
									{
										LkProductInfoViewModel lkProductInfoViewModel = Enumerable.FirstOrDefault<LkProductInfoViewModel>((IEnumerable<LkProductInfoViewModel>)listProduct, (Func<LkProductInfoViewModel, bool>)((LkProductInfoViewModel m) => m.PrdLinkAccPrdIdStr == vmPordItem.PrdLinkAccPrdIdStr));
										if (lkProductInfoViewModel != null)
										{
											vmPordItem.PrdName = lkProductInfoViewModel.PrdName;
											vmPordItem.PrdLinkAccPrdCode = lkProductInfoViewModel.PrdLinkAccPrdCode;
										}
									}
									if (item.UnitRef.GetValueOrDefault() != 0L)
									{
										vmPordItem.UnitLinkAccUnitIdStr = item.UnitRef.GetValueOrDefault().ToString();
									}
									vmPordItem.WrhsLinkAccWhIdStr = itemHead.InventoryRef.GetValueOrDefault().ToString();
									vmPordItem.pordIQuantity = item.Quantity ?? item.InitialQuantity.GetValueOrDefault(1.0);
									vmPordItem.pordIPrice = item.Fee;
									vmPordItem.pordITotalPrice = item.NetPrice;
									value4 += vmPordItem.pordITotalPrice.GetValueOrDefault();
									if (item.Reductions.GetValueOrDefault() != 0m)
									{
										vmPordItem.pordIDiscountSum = item.Reductions;
									}
									if (item.Additions.GetValueOrDefault() != 0m)
									{
										vmPordItem.pordITaxSum = item.Additions;
										num2 += vmPordItem.pordITaxSum.GetValueOrDefault();
									}
									list2.Add(vmPordItem);
								}
							}
							if (vmPord.pordTotalAmount.GetValueOrDefault() == 0m)
							{
								vmPord.pordTotalAmount = value4;
							}
							vmPord.RowNumber = num;
							if (list5 != null && Enumerable.Any<WSspSelectPreOrderWithAccLinkField_Result>((IEnumerable<WSspSelectPreOrderWithAccLinkField_Result>)list5))
							{
								WSspSelectPreOrderWithAccLinkField_Result wSspSelectPreOrderWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectPreOrderWithAccLinkField_Result>((IEnumerable<WSspSelectPreOrderWithAccLinkField_Result>)list5, (Func<WSspSelectPreOrderWithAccLinkField_Result, bool>)((WSspSelectPreOrderWithAccLinkField_Result x) => x.pordLinkAccPreOrderIdStr == vmPord.pordLinkAccPreOrderIdStr));
								if (wSspSelectPreOrderWithAccLinkField_Result != null)
								{
									if (!string.IsNullOrWhiteSpace(wSspSelectPreOrderWithAccLinkField_Result.pordLinkAccPreOrderIdStr))
									{
										vmPord.PreOrderID = wSspSelectPreOrderWithAccLinkField_Result.PreOrderID;
									}
								}
								else
								{
									vmPord.PreOrderID = 0;
								}
							}
							list.Add(vmPord);
							num++;
						}
					}
				}
			}
			lkPreOrderInfoViewModelObjects.lst = list;
			lkPreOrderInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			lkPreOrderInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
			lkPreOrderInfoViewModelObjects.lstItems = list2;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return lkPreOrderInfoViewModelObjects;
	}

	public LkWSPreOrderInfoViewModel GetRahkaranInternalSalesPreOrder(string pordLinkAccPreOrderIdStr = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		LkWSPreOrderInfoViewModel result2 = new LkWSPreOrderInfoViewModel();
		try
		{
			long result3 = 0L;
			long.TryParse(pordLinkAccPreOrderIdStr, out result3);
			LkPreOrderInfoViewModelObjects rahkaranInternalSalesPreOrderList = GetRahkaranInternalSalesPreOrderList("", "", result3);
			if (rahkaranInternalSalesPreOrderList != null && rahkaranInternalSalesPreOrderList.lst != null && Enumerable.Any<LkWSPreOrderInfoViewModel>((IEnumerable<LkWSPreOrderInfoViewModel>)rahkaranInternalSalesPreOrderList.lst))
			{
				result2 = Enumerable.FirstOrDefault<LkWSPreOrderInfoViewModel>((IEnumerable<LkWSPreOrderInfoViewModel>)rahkaranInternalSalesPreOrderList.lst, (Func<LkWSPreOrderInfoViewModel, bool>)((LkWSPreOrderInfoViewModel m) => m.pordLinkAccPreOrderIdStr == pordLinkAccPreOrderIdStr));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result2;
	}

	[AjaxOnly]
	public string RahkaranInternalSalesActSendToAcc(int pordId, bool sendPordPayToAcc = false)
	{
		string text = "";
		try
		{
			_ = UserLogin.CurrentUser;
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
			if (pordId > 0)
			{
				try
				{
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
					string appType = Configuration.AppType;
					short.Parse(Financial.Get().Id.ToString());
					int userId = UserLogin.CurrentUser.UserId;
					_ = Financial.Get().Id;
					string rahkaranInternalSales = Labels.RahkaranInternalSales;
					CRMspLkWSSelectPreOrderById_Result cRMspLkWSSelectPreOrderById_Result = Enumerable.FirstOrDefault<CRMspLkWSSelectPreOrderById_Result>((IEnumerable<CRMspLkWSSelectPreOrderById_Result>)_dbLink.CRMspLkWSSelectPreOrderById(pordId, lCID, result, result2));
					if (cRMspLkWSSelectPreOrderById_Result != null)
					{
						string errorMessage = "";
						if (!PreOrder.SendToLinkAccNeedVerify(pordId, ref errorMessage))
						{
							text = errorMessage + "|";
							return text;
						}
						CRMIdeal.Classes.Helper.OtherSystems.RahkaranInternalSalesProvider rahkaranInternalSalesProvider = new CRMIdeal.Classes.Helper.OtherSystems.RahkaranInternalSalesProvider();
						int wrhsSyncTypeId = rahkaranInternalSalesProvider.WrhsSyncTypeId;
						string pordTaxPolicyId = rahkaranInternalSalesProvider.PordTaxPolicyId;
						string pordTaxPolicyName = rahkaranInternalSalesProvider.PordTaxPolicyName;
						string pordTaxConditionId = rahkaranInternalSalesProvider.PordTaxConditionId;
						string pordTaxConditionRowId = rahkaranInternalSalesProvider.PordTaxConditionRowId;
						string pordDiscountPolicyId = rahkaranInternalSalesProvider.PordDiscountPolicyId;
						string pordDiscountPolicyName = rahkaranInternalSalesProvider.PordDiscountPolicyName;
						string pordDiscountConditionId = rahkaranInternalSalesProvider.PordDiscountConditionId;
						string pordDiscountConditionRowId = rahkaranInternalSalesProvider.PordDiscountConditionRowId;
						string text2 = "";
						if (cRMspLkWSSelectPreOrderById_Result.pordPayConditionId.GetValueOrDefault() != 0)
						{
							CRMIdeal.Classes.Helper.OtherSystems.RahkaranInternalSalesProvider.SettingDetailsViewModel settingDetails = rahkaranInternalSalesProvider.GetSettingDetails(0, cRMspLkWSSelectPreOrderById_Result.pordPayConditionId.GetValueOrDefault(), "PordPayCondition");
							if (settingDetails != null)
							{
								text2 = settingDetails.PordPayAgreementId;
							}
						}
						if (!string.IsNullOrWhiteSpace(cRMspLkWSSelectPreOrderById_Result.pordLinkAccPreOrderIdStr))
						{
							LkWSPreOrderInfoViewModel rahkaranInternalSalesPreOrder = GetRahkaranInternalSalesPreOrder(cRMspLkWSSelectPreOrderById_Result.pordLinkAccPreOrderIdStr);
							if (rahkaranInternalSalesPreOrder != null)
							{
								if (!string.IsNullOrWhiteSpace(rahkaranInternalSalesPreOrder.pordLinkAccPreOrderIdStr))
								{
									text = string.Format(Messages.msgErrorNotReSendPordToOtherSystem, cRMspLkWSSelectPreOrderById_Result.pordNumber.ToString(), rahkaranInternalSales) + "|";
									if (sendPordPayToAcc)
									{
										string text3 = RahkaranInternalSalesActSendPaymentsToAcc(pordId);
										if (!string.IsNullOrWhiteSpace(text3))
										{
											string[] array = text3.Split(new char[1] { '|' });
											if (array != null && array.Length >= 1)
											{
												if (array[0] != "1")
												{
													text = array[0] + "|";
													return text;
												}
												text = "1|" + cRMspLkWSSelectPreOrderById_Result.pordLinkAccPreOrderIdStr;
												return text;
											}
											text = text3;
										}
										else
										{
											text = "1|" + cRMspLkWSSelectPreOrderById_Result.pordLinkAccPreOrderIdStr;
										}
									}
									return text;
								}
								_dbLink.WSspUpdatePreOrderAndItemWithAccLinkField(pordId, null, null, null, null, null, true, userId, value2, value, registerDatePersian, appType);
							}
						}
						string text4 = "";
						string text5 = "";
						string text6 = "";
						string text7 = "";
						string text8 = "";
						string text9 = "";
						if (!cRMspLkWSSelectPreOrderById_Result.pordCurrencyUnitId.HasValue)
						{
							text = string.Format(Messages.msgErrorInSendPordToAccLinkNotSelectedItem, cRMspLkWSSelectPreOrderById_Result.pordNumber, rahkaranInternalSales, Labels.pordCurrencyUnitId) + "|";
							return text;
						}
						if (string.IsNullOrWhiteSpace(cRMspLkWSSelectPreOrderById_Result.LinkAccCurrencyUnitIdStr))
						{
							text = string.Format(Messages.msgErrorInSendPordToAccLinkNotFoundIteminAcc, cRMspLkWSSelectPreOrderById_Result.pordNumber, rahkaranInternalSales, Labels.pordCurrencyUnitId, cRMspLkWSSelectPreOrderById_Result.pordCurrencyUnit ?? "") + "|";
							return text;
						}
						text4 = cRMspLkWSSelectPreOrderById_Result.LinkAccCurrencyUnitIdStr;
						if (!cRMspLkWSSelectPreOrderById_Result.pordReferUserId.HasValue)
						{
							text = string.Format(Messages.msgErrorInSendPordToAccLinkNotSelectedItem, cRMspLkWSSelectPreOrderById_Result.pordNumber, rahkaranInternalSales, Labels.pordReferUserId) + "|";
							return text;
						}
						if (string.IsNullOrWhiteSpace(cRMspLkWSSelectPreOrderById_Result.LinkAccReferUserIdStr))
						{
							text = string.Format(Messages.msgErrorInSendPordToAccLinkNotFoundIteminAcc, cRMspLkWSSelectPreOrderById_Result.pordNumber, rahkaranInternalSales, Labels.pordReferUserId, cRMspLkWSSelectPreOrderById_Result.pordReferUser ?? "") + "|";
							return text;
						}
						text5 = cRMspLkWSSelectPreOrderById_Result.LinkAccReferUserIdStr;
						if (!cRMspLkWSSelectPreOrderById_Result.PreOrderOprID.HasValue)
						{
							text = string.Format(Messages.msgErrorInSendPordToAccLinkNotSelectedItem, cRMspLkWSSelectPreOrderById_Result.pordNumber, rahkaranInternalSales, Labels.PreOrderOprID) + "|";
							return text;
						}
						if (string.IsNullOrWhiteSpace(cRMspLkWSSelectPreOrderById_Result.LinkAccPreOrderOprIdStr))
						{
							text = string.Format(Messages.msgErrorInSendPordToAccLinkNotFoundIteminAcc, cRMspLkWSSelectPreOrderById_Result.pordNumber, rahkaranInternalSales, Labels.PreOrderOprID, cRMspLkWSSelectPreOrderById_Result.PreOrderOpr ?? "") + "|";
							return text;
						}
						text6 = cRMspLkWSSelectPreOrderById_Result.LinkAccPreOrderOprIdStr;
						if (!cRMspLkWSSelectPreOrderById_Result.pordTypeId.HasValue)
						{
							text = string.Format(Messages.msgErrorInSendPordToAccLinkNotSelectedItem, cRMspLkWSSelectPreOrderById_Result.pordNumber, rahkaranInternalSales, Labels.pordTypeId) + "|";
							return text;
						}
						if (string.IsNullOrWhiteSpace(cRMspLkWSSelectPreOrderById_Result.LinkAccPreOrderTypeIdStr))
						{
							text = string.Format(Messages.msgErrorInSendPordToAccLinkNotFoundIteminAcc, cRMspLkWSSelectPreOrderById_Result.pordNumber, rahkaranInternalSales, Labels.pordTypeId, cRMspLkWSSelectPreOrderById_Result.pordType ?? "") + "|";
							return text;
						}
						text7 = cRMspLkWSSelectPreOrderById_Result.LinkAccPreOrderTypeIdStr;
						if (!cRMspLkWSSelectPreOrderById_Result.pordSaleCenterId.HasValue)
						{
							text = string.Format(Messages.msgErrorInSendPordToAccLinkNotSelectedItem, cRMspLkWSSelectPreOrderById_Result.pordNumber, rahkaranInternalSales, Labels.pordSaleCenterId) + "|";
							return text;
						}
						if (string.IsNullOrWhiteSpace(cRMspLkWSSelectPreOrderById_Result.LinkAccSaleCenterIdStr))
						{
							text = string.Format(Messages.msgErrorInSendPordToAccLinkNotFoundIteminAcc, cRMspLkWSSelectPreOrderById_Result.pordNumber, rahkaranInternalSales, Labels.pordSaleCenterId, cRMspLkWSSelectPreOrderById_Result.pordSaleCenter ?? "") + "|";
							return text;
						}
						text8 = cRMspLkWSSelectPreOrderById_Result.LinkAccSaleCenterIdStr;
						if (!cRMspLkWSSelectPreOrderById_Result.pordSaleAreaId.HasValue)
						{
							text = string.Format(Messages.msgErrorInSendPordToAccLinkNotSelectedItem, cRMspLkWSSelectPreOrderById_Result.pordNumber, rahkaranInternalSales, Labels.pordSaleAreaId) + "|";
							return text;
						}
						if (string.IsNullOrWhiteSpace(cRMspLkWSSelectPreOrderById_Result.LinkAccSaleAreaIdStr))
						{
							text = string.Format(Messages.msgErrorInSendPordToAccLinkNotFoundIteminAcc, cRMspLkWSSelectPreOrderById_Result.pordNumber, rahkaranInternalSales, Labels.pordSaleAreaId, cRMspLkWSSelectPreOrderById_Result.pordSaleArea ?? "") + "|";
							return text;
						}
						text9 = cRMspLkWSSelectPreOrderById_Result.LinkAccSaleAreaIdStr;
						List<CRMspLkWSSelectPreOrderItems_Result> list = Enumerable.ToList<CRMspLkWSSelectPreOrderItems_Result>((IEnumerable<CRMspLkWSSelectPreOrderItems_Result>)_dbLink.CRMspLkWSSelectPreOrderItems(pordId, lCID, result));
						if (list == null || !Enumerable.Any<CRMspLkWSSelectPreOrderItems_Result>((IEnumerable<CRMspLkWSSelectPreOrderItems_Result>)list))
						{
							text = Messages.ErrorNotFound + "|";
							return text;
						}
						foreach (CRMspLkWSSelectPreOrderItems_Result item2 in list)
						{
							if (string.IsNullOrWhiteSpace(item2.PrdLinkAccPrdIdStr))
							{
								text = string.Format(Messages.msgErrorInSendPordToAccLinkNotFoundPrdInAcc, cRMspLkWSSelectPreOrderById_Result.pordNumber, rahkaranInternalSales, item2.PrdName ?? "") + "|";
								return text;
							}
							if (item2.pordIPrdUnitId.HasValue && string.IsNullOrWhiteSpace(item2.UnitLinkAccUnitIdStr))
							{
								text = string.Format(Messages.msgErrorInSendPordToAccLinkNotFoundPrdUnitInAcc, cRMspLkWSSelectPreOrderById_Result.pordNumber, rahkaranInternalSales, item2.pordIPrdUnit ?? "") + "|";
								return text;
							}
							if (item2.pordIWHId.HasValue)
							{
								string value3 = "";
								string value4 = "";
								if (wrhsSyncTypeId == 2 && !string.IsNullOrWhiteSpace(item2.pordILinkAccWHIdStr))
								{
									if (!string.IsNullOrWhiteSpace(item2.WrhsLinkAccWareHouses))
									{
										List<CommonWithIdStrViewModel> list2 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(item2.WrhsLinkAccWareHouses);
										if (list2 != null && list2.Count > 0)
										{
											CommonWithIdStrViewModel commonWithIdStrViewModel = Enumerable.FirstOrDefault<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list2, (Func<CommonWithIdStrViewModel, bool>)((CommonWithIdStrViewModel x) => x.Id == item2.pordILinkAccWHIdStr));
											if (commonWithIdStrViewModel != null)
											{
												value4 = commonWithIdStrViewModel.Name;
												value3 = commonWithIdStrViewModel.Id;
											}
										}
									}
								}
								else
								{
									value3 = item2.WrhsLinkAccWhIdStr;
									value4 = item2.pordIWrhsName;
								}
								if (string.IsNullOrWhiteSpace(value3) || string.IsNullOrWhiteSpace(value4))
								{
									text = string.Format(Messages.msgErrorWareHouseNotFoundInAccLink, item2.pordIWrhsName ?? "", rahkaranInternalSales);
									return text;
								}
								_ = item2.pordITaxSum.GetValueOrDefault() != 0m;
								_ = item2.pordIDiscountSum.GetValueOrDefault() != 0m;
								continue;
							}
							text = string.Format(Messages.msgErrorInSendPordToAccLinkNotSelectedItem, cRMspLkWSSelectPreOrderById_Result.pordNumber, rahkaranInternalSales, Labels.lblWareHouse) + "|";
							return text;
						}
						string text10 = "";
						CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(cRMspLkWSSelectPreOrderById_Result.pordCompanyId.GetValueOrDefault());
						if (companyById == null)
						{
							text = Messages.CompanyNotFound + "|";
							return text;
						}
						text10 = companyById.cmpLinkAccCustomerIdStr ?? "";
						if (string.IsNullOrWhiteSpace(text10))
						{
							string text11 = new CompanyController().RahkaranInternalSalesActCmpSendToAcc(cRMspLkWSSelectPreOrderById_Result.pordCompanyId.GetValueOrDefault(), 0, isExportCustomer: false, checkAction: false);
							if (string.IsNullOrEmpty(text11))
							{
								text = Messages.msgErrorRunFunction + "(insert company to rahkaran)|";
								return text;
							}
							string[] array2 = text11.Split(new char[1] { '|' });
							if (array2 != null)
							{
								if (!(array2[0] == "1"))
								{
									text = array2[0] + "|";
									return text;
								}
								companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(cRMspLkWSSelectPreOrderById_Result.pordCompanyId.GetValueOrDefault());
								if (companyById == null)
								{
									text = Messages.CompanyNotFound + "|";
									return text;
								}
								text10 = companyById.cmpLinkAccCustomerIdStr ?? "";
							}
						}
						if (string.IsNullOrWhiteSpace(text10))
						{
							text = string.Format(Messages.msgErrorInSendToAccLinkNotFoundCmpInAcc, rahkaranInternalSales);
							return text;
						}
						DateTime dateTime = default(DateTime);
						string date = "";
						try
						{
							if (cRMspLkWSSelectPreOrderById_Result.pordDateTime.HasValue)
							{
								date = "\\/Date(" + ((DateTimeOffset)cRMspLkWSSelectPreOrderById_Result.pordDateTime.Value).ToUnixTimeMilliseconds() + "+0330)\\/";
							}
							else if (!string.IsNullOrWhiteSpace(cRMspLkWSSelectPreOrderById_Result.pordDate))
							{
								dateTime = DateTime.Parse(PersianDate.GetFormatetdDate(cRMspLkWSSelectPreOrderById_Result.pordDate.Replace("/", "")) + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
								date = "\\/Date(" + ((DateTimeOffset)dateTime).ToUnixTimeMilliseconds() + "+0330)\\/";
							}
						}
						catch (Exception e)
						{
							ErrorSignal.FromCurrentContext().Raise(e);
							text = string.Format(Messages.ErrorInFormat, Labels.pordDate);
							return text;
						}
						dateTime = default(DateTime);
						try
						{
							if (cRMspLkWSSelectPreOrderById_Result.pordExpireDateTime.HasValue)
							{
								_ = "\\/Date(" + ((DateTimeOffset)cRMspLkWSSelectPreOrderById_Result.pordExpireDateTime.Value).ToUnixTimeMilliseconds() + "+0330)\\/";
							}
							else if (!string.IsNullOrWhiteSpace(cRMspLkWSSelectPreOrderById_Result.pordExpireDate))
							{
								dateTime = DateTime.Parse(PersianDate.GetFormatetdDate(cRMspLkWSSelectPreOrderById_Result.pordExpireDate.Replace("/", "")) + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
								_ = "\\/Date(" + ((DateTimeOffset)dateTime).ToUnixTimeMilliseconds() + "+0330)\\/";
							}
						}
						catch (Exception e2)
						{
							ErrorSignal.FromCurrentContext().Raise(e2);
							text = string.Format(Messages.ErrorInFormat, Labels.pordExpireDate);
							return text;
						}
						RahkaranInternalSalesCalculatePoliciesDefineResponseViewModel rahkaranInternalSalesCalculatePoliciesDefineResponseViewModel = new RahkaranInternalSalesCalculatePoliciesDefineResponseViewModel();
						rahkaranInternalSalesCalculatePoliciesDefineResponseViewModel.items = new List<RahkaranInternalSalesCalculatePoliciesItemDefineResponseViewModel>();
						rahkaranInternalSalesCalculatePoliciesDefineResponseViewModel.policyResults = new List<RahkaranInternalSalesCalculatePoliciesPolicyResultsDefineResponseViewModel>();
						rahkaranInternalSalesCalculatePoliciesDefineResponseViewModel.operationControlPolicyResult = null;
						decimal num = default(decimal);
						string text12 = "";
						if (list != null && Enumerable.Any<CRMspLkWSSelectPreOrderItems_Result>((IEnumerable<CRMspLkWSSelectPreOrderItems_Result>)list))
						{
							int num2 = 1;
							foreach (CRMspLkWSSelectPreOrderItems_Result item in list)
							{
								RahkaranInternalSalesCalculatePoliciesItemDefineResponseViewModel rahkaranInternalSalesCalculatePoliciesItemDefineResponseViewModel = new RahkaranInternalSalesCalculatePoliciesItemDefineResponseViewModel();
								rahkaranInternalSalesCalculatePoliciesItemDefineResponseViewModel.policyResults = new List<RahkaranInternalSalesCalculatePoliciesPolicyResultsDefineResponseViewModel>();
								rahkaranInternalSalesCalculatePoliciesItemDefineResponseViewModel.referenceType = null;
								string text13 = item.PrdLinkAccPrdIdStr ?? "";
								_ = item.PrdLinkAccPrdCode;
								string unitId = item.UnitLinkAccUnitIdStr ?? "0";
								string text14 = "";
								string text15 = "";
								if (item.pordIWHId.HasValue)
								{
									string text16 = "";
									if (wrhsSyncTypeId == 2 && !string.IsNullOrWhiteSpace(item.pordILinkAccWHIdStr))
									{
										if (!string.IsNullOrWhiteSpace(item.WrhsLinkAccWareHouses))
										{
											List<CommonWithIdStrViewModel> list3 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(item.WrhsLinkAccWareHouses);
											if (list3 != null && list3.Count > 0)
											{
												CommonWithIdStrViewModel commonWithIdStrViewModel2 = Enumerable.FirstOrDefault<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list3, (Func<CommonWithIdStrViewModel, bool>)((CommonWithIdStrViewModel x) => x.Id == item.pordILinkAccWHIdStr));
												if (commonWithIdStrViewModel2 != null)
												{
													_ = commonWithIdStrViewModel2.Name;
													text16 = commonWithIdStrViewModel2.Id;
												}
											}
										}
									}
									else
									{
										text16 = item.WrhsLinkAccWhIdStr;
										_ = item.pordIWrhsName;
									}
									if (!string.IsNullOrWhiteSpace(text16))
									{
										text15 = text16;
									}
								}
								if (string.IsNullOrWhiteSpace(text14) && !string.IsNullOrWhiteSpace(text15))
								{
									text14 = text15;
								}
								if (string.IsNullOrWhiteSpace(text12) && !string.IsNullOrWhiteSpace(text15))
								{
									text12 = text15;
								}
								if (!string.IsNullOrWhiteSpace(text13))
								{
									double num3 = item.pordIQuantity.GetValueOrDefault(1.0) * item.pordIFCR.GetValueOrDefault(1.0) * item.pordIFCRI.GetValueOrDefault(1.0);
									decimal num4 = item.pordIPrice.GetValueOrDefault() * (decimal)num3;
									decimal valueOrDefault = item.pordITotalPrice.GetValueOrDefault();
									num += num4;
									rahkaranInternalSalesCalculatePoliciesItemDefineResponseViewModel.description = item.pordIDescription ?? "";
									rahkaranInternalSalesCalculatePoliciesItemDefineResponseViewModel.id = (num2 * -1).ToString();
									rahkaranInternalSalesCalculatePoliciesItemDefineResponseViewModel.index = num2;
									rahkaranInternalSalesCalculatePoliciesItemDefineResponseViewModel.productId = text13;
									rahkaranInternalSalesCalculatePoliciesItemDefineResponseViewModel.quantity = num3.ToString();
									rahkaranInternalSalesCalculatePoliciesItemDefineResponseViewModel.unitId = unitId;
									rahkaranInternalSalesCalculatePoliciesItemDefineResponseViewModel.additionAmount = item.pordITaxSum.GetValueOrDefault().ToString();
									rahkaranInternalSalesCalculatePoliciesItemDefineResponseViewModel.fee = item.pordIPrice.GetValueOrDefault().ToString();
									rahkaranInternalSalesCalculatePoliciesItemDefineResponseViewModel.netPrice = valueOrDefault.ToString();
									rahkaranInternalSalesCalculatePoliciesItemDefineResponseViewModel.price = num4.ToString();
									rahkaranInternalSalesCalculatePoliciesItemDefineResponseViewModel.reductionAmount = item.pordIDiscountSum.GetValueOrDefault().ToString();
									rahkaranInternalSalesCalculatePoliciesItemDefineResponseViewModel.type = 1;
									rahkaranInternalSalesCalculatePoliciesItemDefineResponseViewModel.inventoryID = text14.ToString();
									rahkaranInternalSalesCalculatePoliciesItemDefineResponseViewModel.plantID = text6;
									rahkaranInternalSalesCalculatePoliciesItemDefineResponseViewModel.productPackQuantity = "0";
									rahkaranInternalSalesCalculatePoliciesItemDefineResponseViewModel.salesAreaId = text9;
									rahkaranInternalSalesCalculatePoliciesItemDefineResponseViewModel.settlementRespite = 0;
									if (item.pordITaxSum.GetValueOrDefault() != 0m && !string.IsNullOrWhiteSpace(pordTaxPolicyId) && pordTaxPolicyId != "0")
									{
										string text17 = item.pordITaxSum.GetValueOrDefault().ToString();
										text17 = text17.Replace(".00", "");
										string text18 = item.pordITaxIndex.GetValueOrDefault().ToString();
										text18 = text18.Replace(".00", "");
										string valueTitle = text18 + "%معادل " + $"{item.pordITaxSum.GetValueOrDefault():N0}" + " " + cRMspLkWSSelectPreOrderById_Result.pordCurrencyUnit;
										RahkaranInternalSalesCalculatePoliciesPolicyResultsDefineResponseViewModel item3 = new RahkaranInternalSalesCalculatePoliciesPolicyResultsDefineResponseViewModel
										{
											amount = text17,
											calculationMethod = "1",
											conditionId = pordTaxConditionId,
											conditionRowId = pordTaxConditionRowId,
											isApplied = true,
											isFixed = false,
											isShrinked = false,
											isValueChanged = true,
											name = pordTaxPolicyName,
											policyId = pordTaxPolicyId,
											targetDocumentID = "-1",
											targetItemID = "-1",
											typeName = "Tax",
											value = text18,
											valueTitle = valueTitle
										};
										rahkaranInternalSalesCalculatePoliciesItemDefineResponseViewModel.policyResults.Add(item3);
									}
									if (item.pordIDiscountSum.GetValueOrDefault() != 0m && !string.IsNullOrWhiteSpace(pordDiscountPolicyId) && pordDiscountPolicyId != "0")
									{
										string text19 = item.pordIDiscountSum.GetValueOrDefault().ToString();
										text19 = text19.Replace(".00", "");
										string valueTitle2 = "معادل " + $"{item.pordIDiscountSum.GetValueOrDefault():N0}" + " " + cRMspLkWSSelectPreOrderById_Result.pordCurrencyUnit;
										RahkaranInternalSalesCalculatePoliciesPolicyResultsDefineResponseViewModel item4 = new RahkaranInternalSalesCalculatePoliciesPolicyResultsDefineResponseViewModel
										{
											amount = text19,
											calculationMethod = "1",
											conditionId = pordDiscountConditionId,
											conditionRowId = pordDiscountConditionRowId,
											isApplied = true,
											isFixed = false,
											isShrinked = false,
											isValueChanged = true,
											name = pordDiscountPolicyName,
											policyId = pordDiscountPolicyId,
											targetDocumentID = "-1",
											targetItemID = "-1",
											typeName = "Discount",
											value = text19,
											valueTitle = valueTitle2
										};
										rahkaranInternalSalesCalculatePoliciesItemDefineResponseViewModel.policyResults.Add(item4);
									}
									rahkaranInternalSalesCalculatePoliciesDefineResponseViewModel.items.Add(rahkaranInternalSalesCalculatePoliciesItemDefineResponseViewModel);
									num2++;
									continue;
								}
								text = Messages.msgErrorRunFunction + " (Error in create json)";
								return text;
							}
						}
						if (rahkaranInternalSalesCalculatePoliciesDefineResponseViewModel.items == null || !Enumerable.Any<RahkaranInternalSalesCalculatePoliciesItemDefineResponseViewModel>((IEnumerable<RahkaranInternalSalesCalculatePoliciesItemDefineResponseViewModel>)rahkaranInternalSalesCalculatePoliciesDefineResponseViewModel.items))
						{
							text = Messages.ErrorNotFound + "|";
							return text;
						}
						rahkaranInternalSalesCalculatePoliciesDefineResponseViewModel.addressId = null;
						rahkaranInternalSalesCalculatePoliciesDefineResponseViewModel.brokerId = null;
						rahkaranInternalSalesCalculatePoliciesDefineResponseViewModel.currencyId = text4;
						rahkaranInternalSalesCalculatePoliciesDefineResponseViewModel.customerId = text10;
						rahkaranInternalSalesCalculatePoliciesDefineResponseViewModel.date = date;
						rahkaranInternalSalesCalculatePoliciesDefineResponseViewModel.description = (cRMspLkWSSelectPreOrderById_Result.pordDescriptionI ?? cRMspLkWSSelectPreOrderById_Result.pordDescriptionII) ?? "";
						rahkaranInternalSalesCalculatePoliciesDefineResponseViewModel.id = "-1";
						rahkaranInternalSalesCalculatePoliciesDefineResponseViewModel.inventoryId = text12;
						rahkaranInternalSalesCalculatePoliciesDefineResponseViewModel.payerType = 1;
						rahkaranInternalSalesCalculatePoliciesDefineResponseViewModel.plantId = text6;
						rahkaranInternalSalesCalculatePoliciesDefineResponseViewModel.salesAreaId = text9;
						rahkaranInternalSalesCalculatePoliciesDefineResponseViewModel.salesOfficeId = text8;
						rahkaranInternalSalesCalculatePoliciesDefineResponseViewModel.salesTypeId = text7;
						rahkaranInternalSalesCalculatePoliciesDefineResponseViewModel.additionAmount = cRMspLkWSSelectPreOrderById_Result.pordItemsTax.GetValueOrDefault().ToString();
						rahkaranInternalSalesCalculatePoliciesDefineResponseViewModel.netPrice = cRMspLkWSSelectPreOrderById_Result.pordTotalAmount.GetValueOrDefault().ToString();
						rahkaranInternalSalesCalculatePoliciesDefineResponseViewModel.price = num.ToString();
						rahkaranInternalSalesCalculatePoliciesDefineResponseViewModel.reductionAmount = cRMspLkWSSelectPreOrderById_Result.pordItemsDiscount.GetValueOrDefault().ToString();
						rahkaranInternalSalesCalculatePoliciesDefineResponseViewModel.recipientType = 1;
						rahkaranInternalSalesCalculatePoliciesDefineResponseViewModel.settlementRespite = 0;
						rahkaranInternalSalesCalculatePoliciesDefineResponseViewModel.deliveryAddressType = 0;
						if (!string.IsNullOrWhiteSpace(text2))
						{
							rahkaranInternalSalesCalculatePoliciesDefineResponseViewModel.paymentAgreementId = text2;
						}
						bool isDone = false;
						string text20 = rahkaranInternalSalesProvider.SendCalculatePolicies(rahkaranInternalSalesCalculatePoliciesDefineResponseViewModel, ref isDone);
						if (!string.IsNullOrWhiteSpace(text20))
						{
							text20 = text20.ClearHiddenCharacters();
						}
						if (!string.IsNullOrWhiteSpace(text20))
						{
							if (isDone)
							{
								RahkaranInternalSalesQuotationDefineResponseViewModel rahkaranInternalSalesQuotationDefineResponseViewModel = JsonConvert.DeserializeObject<RahkaranInternalSalesQuotationDefineResponseViewModel>(text20);
								if (rahkaranInternalSalesQuotationDefineResponseViewModel != null)
								{
									rahkaranInternalSalesQuotationDefineResponseViewModel.brokerId = text5;
									if (rahkaranInternalSalesQuotationDefineResponseViewModel.items != null && rahkaranInternalSalesCalculatePoliciesDefineResponseViewModel != null && Enumerable.Any<RahkaranInternalSalesQuotationItemDefineResponseViewModel>((IEnumerable<RahkaranInternalSalesQuotationItemDefineResponseViewModel>)rahkaranInternalSalesQuotationDefineResponseViewModel.items) && rahkaranInternalSalesCalculatePoliciesDefineResponseViewModel.items != null && Enumerable.Any<RahkaranInternalSalesCalculatePoliciesItemDefineResponseViewModel>((IEnumerable<RahkaranInternalSalesCalculatePoliciesItemDefineResponseViewModel>)rahkaranInternalSalesCalculatePoliciesDefineResponseViewModel.items))
									{
										foreach (RahkaranInternalSalesQuotationItemDefineResponseViewModel hitem in rahkaranInternalSalesQuotationDefineResponseViewModel.items)
										{
											RahkaranInternalSalesCalculatePoliciesItemDefineResponseViewModel rahkaranInternalSalesCalculatePoliciesItemDefineResponseViewModel2 = Enumerable.FirstOrDefault<RahkaranInternalSalesCalculatePoliciesItemDefineResponseViewModel>((IEnumerable<RahkaranInternalSalesCalculatePoliciesItemDefineResponseViewModel>)rahkaranInternalSalesCalculatePoliciesDefineResponseViewModel.items, (Func<RahkaranInternalSalesCalculatePoliciesItemDefineResponseViewModel, bool>)((RahkaranInternalSalesCalculatePoliciesItemDefineResponseViewModel m) => m.index == hitem.index));
											if (rahkaranInternalSalesCalculatePoliciesItemDefineResponseViewModel2 == null || hitem.policyResults == null || rahkaranInternalSalesCalculatePoliciesItemDefineResponseViewModel2.policyResults == null || !Enumerable.Any<RahkaranInternalSalesQuotationPolicyResultsDefineResponseViewModel>((IEnumerable<RahkaranInternalSalesQuotationPolicyResultsDefineResponseViewModel>)hitem.policyResults) || !Enumerable.Any<RahkaranInternalSalesCalculatePoliciesPolicyResultsDefineResponseViewModel>((IEnumerable<RahkaranInternalSalesCalculatePoliciesPolicyResultsDefineResponseViewModel>)rahkaranInternalSalesCalculatePoliciesItemDefineResponseViewModel2.policyResults))
											{
												continue;
											}
											foreach (RahkaranInternalSalesQuotationPolicyResultsDefineResponseViewModel pr in hitem.policyResults)
											{
												RahkaranInternalSalesCalculatePoliciesPolicyResultsDefineResponseViewModel rahkaranInternalSalesCalculatePoliciesPolicyResultsDefineResponseViewModel = Enumerable.FirstOrDefault<RahkaranInternalSalesCalculatePoliciesPolicyResultsDefineResponseViewModel>((IEnumerable<RahkaranInternalSalesCalculatePoliciesPolicyResultsDefineResponseViewModel>)rahkaranInternalSalesCalculatePoliciesItemDefineResponseViewModel2.policyResults, (Func<RahkaranInternalSalesCalculatePoliciesPolicyResultsDefineResponseViewModel, bool>)((RahkaranInternalSalesCalculatePoliciesPolicyResultsDefineResponseViewModel m) => m.policyId == pr.policyId));
												if (rahkaranInternalSalesCalculatePoliciesPolicyResultsDefineResponseViewModel != null)
												{
													pr.amount = rahkaranInternalSalesCalculatePoliciesPolicyResultsDefineResponseViewModel.amount;
													pr.calculationMethod = rahkaranInternalSalesCalculatePoliciesPolicyResultsDefineResponseViewModel.calculationMethod;
													pr.conditionId = rahkaranInternalSalesCalculatePoliciesPolicyResultsDefineResponseViewModel.conditionId;
													pr.conditionRowId = rahkaranInternalSalesCalculatePoliciesPolicyResultsDefineResponseViewModel.conditionRowId;
													pr.isApplied = rahkaranInternalSalesCalculatePoliciesPolicyResultsDefineResponseViewModel.isApplied;
													pr.isFixed = rahkaranInternalSalesCalculatePoliciesPolicyResultsDefineResponseViewModel.isFixed;
													pr.isShrinked = rahkaranInternalSalesCalculatePoliciesPolicyResultsDefineResponseViewModel.isShrinked;
													pr.isValueChanged = rahkaranInternalSalesCalculatePoliciesPolicyResultsDefineResponseViewModel.isValueChanged;
													pr.policyId = rahkaranInternalSalesCalculatePoliciesPolicyResultsDefineResponseViewModel.policyId;
													pr.typeName = rahkaranInternalSalesCalculatePoliciesPolicyResultsDefineResponseViewModel.typeName;
													pr.value = rahkaranInternalSalesCalculatePoliciesPolicyResultsDefineResponseViewModel.value;
													pr.valueTitle = rahkaranInternalSalesCalculatePoliciesPolicyResultsDefineResponseViewModel.valueTitle;
												}
											}
										}
									}
									text20 = "";
									long linkAccId = 0L;
									text20 = rahkaranInternalSalesProvider.SendPreOrder(rahkaranInternalSalesQuotationDefineResponseViewModel, ref linkAccId);
									if (!string.IsNullOrWhiteSpace(text20))
									{
										text20 = text20.ClearHiddenCharacters();
									}
									if (!string.IsNullOrWhiteSpace(text20))
									{
										if (linkAccId != 0L)
										{
											string pordLinkAccPreOrderIdStr = linkAccId.ToString();
											string text21 = "";
											LkWSPreOrderInfoViewModel rahkaranInternalSalesPreOrder2 = GetRahkaranInternalSalesPreOrder(pordLinkAccPreOrderIdStr);
											if (rahkaranInternalSalesPreOrder2 != null && !string.IsNullOrWhiteSpace(rahkaranInternalSalesPreOrder2.pordLinkAccPreOrderIdStr))
											{
												text21 = rahkaranInternalSalesPreOrder2.pordLinkAccPreOrderNumber ?? "";
											}
											_dbLink.WSspUpdatePreOrderAndItemWithAccLinkField(pordId, null, text21, pordLinkAccPreOrderIdStr, null, "", false, userId, value2, value, registerDatePersian, appType);
											text = "1|" + text21;
											if (sendPordPayToAcc)
											{
												string text22 = RahkaranInternalSalesActSendPaymentsToAcc(pordId);
												if (!string.IsNullOrWhiteSpace(text22))
												{
													string[] array3 = text22.Split(new char[1] { '|' });
													if (array3 != null && array3.Length >= 1 && array3[0] != "1")
													{
														text = array3[0] + "|";
														return text;
													}
												}
											}
										}
										else
										{
											text = text + "<br>" + Messages.msgErrorCommunicateWithServer + "<br>" + text20 + "|";
										}
									}
									else
									{
										text = text + "<br>" + Messages.msgErrorCommunicateWithServer + "|";
									}
								}
								else
								{
									text = text + "<br>" + Messages.msgErrorCommunicateWithServer + "|";
								}
							}
							else
							{
								text = text + "<br>" + Messages.msgErrorCommunicateWithServer + "<br>" + text20 + "|";
							}
						}
						else
						{
							text = text + "<br>" + Messages.msgErrorCommunicateWithServer + "|";
						}
					}
					else
					{
						text = Messages.ErrorNotFound + "|";
					}
				}
				catch (Exception ex)
				{
					text = text + "\n\nException: " + ex.Message;
				}
			}
			else
			{
				text = Messages.ErrorNotFound + "|";
			}
		}
		catch (Exception e3)
		{
			ErrorSignal.FromCurrentContext().Raise(e3);
			text = Messages.msgErrorRunFunction + "|";
		}
		return text;
	}

	[AjaxOnly]
	public string RahkaranInternalSalesActSendPaymentsToAcc(int pordId, int payId = 0)
	{
		string text = "";
		try
		{
			_ = UserLogin.CurrentUser;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (pordId > 0)
			{
				try
				{
					if (payId != 0)
					{
						text = RahkaranInternalSalesActSendPayToAcc(payId);
					}
					else
					{
						List<CRMspLkWSSelectPreOrderPayments_Result> list = Enumerable.ToList<CRMspLkWSSelectPreOrderPayments_Result>((IEnumerable<CRMspLkWSSelectPreOrderPayments_Result>)_dbLink.CRMspLkWSSelectPreOrderPayments(pordId, lCID, result));
						if (list != null && Enumerable.Any<CRMspLkWSSelectPreOrderPayments_Result>((IEnumerable<CRMspLkWSSelectPreOrderPayments_Result>)list))
						{
							foreach (CRMspLkWSSelectPreOrderPayments_Result item in list)
							{
								string text2 = RahkaranInternalSalesActSendPayToAcc(item.PreOrderPaymentId);
								if (!string.IsNullOrWhiteSpace(text2))
								{
									string[] array = text2.Split(new char[1] { '|' });
									if (array != null && array.Length >= 1 && array[0] != "1")
									{
										text = array[0] + "|";
										return text;
									}
								}
							}
							text = "1|" + Messages.msgSuccessAction;
						}
					}
				}
				catch (Exception ex)
				{
					text = text + "\n\nException: " + ex.Message;
				}
			}
			else
			{
				text = Messages.ErrorNotFound + "|";
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
	public string RahkaranInternalSalesActSendPayToAcc(int payId)
	{
		//IL_058a: Unknown result type (might be due to invalid IL or missing references)
		//IL_067b: Unknown result type (might be due to invalid IL or missing references)
		//IL_082d: Unknown result type (might be due to invalid IL or missing references)
		//IL_09df: Unknown result type (might be due to invalid IL or missing references)
		//IL_1104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ed9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bc0: Unknown result type (might be due to invalid IL or missing references)
		string text = "";
		try
		{
			_ = UserLogin.CurrentUser;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (payId > 0)
			{
				try
				{
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
					string appType = Configuration.AppType;
					short.Parse(Financial.Get().Id.ToString());
					int userId = UserLogin.CurrentUser.UserId;
					_ = Financial.Get().Id;
					string rahkaranInternalSales = Labels.RahkaranInternalSales;
					CRMspLkWSSelectPreOrderPaymentsWithId_Result cRMspLkWSSelectPreOrderPaymentsWithId_Result = Enumerable.FirstOrDefault<CRMspLkWSSelectPreOrderPaymentsWithId_Result>((IEnumerable<CRMspLkWSSelectPreOrderPaymentsWithId_Result>)_dbLink.CRMspLkWSSelectPreOrderPaymentsWithId(payId, lCID, result));
					if (cRMspLkWSSelectPreOrderPaymentsWithId_Result != null)
					{
						CRMIdeal.Classes.Helper.OtherSystems.RahkaranInternalSalesProvider rahkaranInternalSalesProvider = new CRMIdeal.Classes.Helper.OtherSystems.RahkaranInternalSalesProvider();
						string text2 = cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayAmount.ToString().FormatForPrice();
						cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordNumber = cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordNumber.GetValueOrDefault();
						CRMIdeal.Classes.Helper.OtherSystems.RahkaranInternalSalesProvider.SettingDetailsViewModel settingDetails = rahkaranInternalSalesProvider.GetSettingDetails(0, cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayTypeId, "PordPayType");
						int num = 0;
						int num2 = 0;
						if (settingDetails != null)
						{
							num = settingDetails.PordPayHeaderDateType;
							num2 = settingDetails.PordPayDetailDateType;
						}
						int result2 = 0;
						int.TryParse(cRMspLkWSSelectPreOrderPaymentsWithId_Result.ordpayTypeKind.ToString(), out result2);
						if (result2 == 0)
						{
							text = string.Format(Messages.msgErrorNotReSendPayToOtherSystemNotSetKind, cRMspLkWSSelectPreOrderPaymentsWithId_Result.PayTypeTitle, text2, Labels.lblPOrd, cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordNumber.ToString()) + "|";
							return text;
						}
						if (string.IsNullOrWhiteSpace(cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordLinkAccPreOrderIdStr))
						{
							text = string.Format(Messages.msgErrorNotSendPordPayToOtherSystemWithOutPordToAcc, cRMspLkWSSelectPreOrderPaymentsWithId_Result.PayTypeTitle, text2, cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordNumber.ToString(), rahkaranInternalSales) + "|";
							return text;
						}
						if (!string.IsNullOrWhiteSpace(cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayLinkAccHeaderIdStr))
						{
							text = string.Format(Messages.msgErrorNotReSendPordPayToOtherSystem, cRMspLkWSSelectPreOrderPaymentsWithId_Result.PayTypeTitle, text2, cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordNumber.ToString(), rahkaranInternalSales) + "|";
							return text;
						}
						CRMspLkWSCheckDuplicatePreOrderPayment_Result cRMspLkWSCheckDuplicatePreOrderPayment_Result = Enumerable.FirstOrDefault<CRMspLkWSCheckDuplicatePreOrderPayment_Result>((IEnumerable<CRMspLkWSCheckDuplicatePreOrderPayment_Result>)_dbLink.CRMspLkWSCheckDuplicatePreOrderPayment(payId));
						if (cRMspLkWSCheckDuplicatePreOrderPayment_Result != null)
						{
							cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayAmount = cRMspLkWSCheckDuplicatePreOrderPayment_Result.pordpayAmount ?? cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayAmount;
							cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayDocAmount = cRMspLkWSCheckDuplicatePreOrderPayment_Result.pordpayDocAmount ?? cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayDocAmount;
							cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayDocDateTime = cRMspLkWSCheckDuplicatePreOrderPayment_Result.pordpayDocDateTime ?? cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayDocDateTime;
							cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayDocNumber = cRMspLkWSCheckDuplicatePreOrderPayment_Result.pordpayDocNumber ?? cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayDocNumber;
							int result3 = 0;
							int.TryParse(cRMspLkWSCheckDuplicatePreOrderPayment_Result.AlreadySendPreOrderPaymentId.ToString(), out result3);
							if (result3 != 0 && !string.IsNullOrWhiteSpace(cRMspLkWSCheckDuplicatePreOrderPayment_Result.AlreadyPordpayLinkAccHeaderIdStr))
							{
								_dbLink.WSspUpdatePreOrderPaymentWithAccLinkField(payId, cRMspLkWSCheckDuplicatePreOrderPayment_Result.AlreadyPordpayLinkAccHeaderId, cRMspLkWSCheckDuplicatePreOrderPayment_Result.AlreadyPordpayLinkAccHeaderNumber, cRMspLkWSCheckDuplicatePreOrderPayment_Result.AlreadyPordpayLinkAccDetailId, cRMspLkWSCheckDuplicatePreOrderPayment_Result.AlreadyPordpayLinkAccVoucherId, cRMspLkWSCheckDuplicatePreOrderPayment_Result.AlreadyPordpayLinkAccVoucherNumber, cRMspLkWSCheckDuplicatePreOrderPayment_Result.AlreadyPordpayLinkAccHeaderIdStr, cRMspLkWSCheckDuplicatePreOrderPayment_Result.AlreadyPordpayLinkAccDetailIdStr, cRMspLkWSCheckDuplicatePreOrderPayment_Result.AlreadyPordpayLinkAccVoucherIdStr, "dup", cRMspLkWSCheckDuplicatePreOrderPayment_Result.AlreadySendPordpayLinkAccData, false, userId, value2, value, registerDatePersian, appType);
								text = "1|" + cRMspLkWSCheckDuplicatePreOrderPayment_Result.AlreadyPordpayLinkAccHeaderNumber;
								return text;
							}
						}
						decimal pordpayAmount = cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayAmount;
						if (!cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayDocDateTime.HasValue)
						{
							cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayDocDateTime = cRMspLkWSSelectPreOrderPaymentsWithId_Result.ImportDateTime;
						}
						int dbId = 0;
						bool value3 = false;
						long result4 = 0L;
						long result5 = 0L;
						string text3 = "";
						string text4 = cRMspLkWSSelectPreOrderPaymentsWithId_Result.BankingBranchName ?? "";
						long result6 = 0L;
						long result7 = 0L;
						long result8 = 0L;
						long result9 = 0L;
						decimal value4 = 1m;
						decimal value5 = 1m;
						string text5 = cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayDescription;
						int num3 = cRMspLkWSSelectPreOrderPaymentsWithId_Result.ordpayTypeMode.GetValueOrDefault();
						if (num3 == 0)
						{
							num3 = 1;
						}
						if (!cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayCashId.HasValue)
						{
							text = string.Format(Messages.msgErrorInSendPayToAccLinkNotSelectedItem, cRMspLkWSSelectPreOrderPaymentsWithId_Result.PayTypeTitle, text2, Labels.lblPOrd, cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordNumber.ToString(), rahkaranInternalSales, Labels.pordpayCashId) + "|";
							return text;
						}
						if (string.IsNullOrWhiteSpace(cRMspLkWSSelectPreOrderPaymentsWithId_Result.CashLinkAccData))
						{
							text = string.Format(Messages.msgErrorInSendPayToAccLinkNotFoundIteminAcc, cRMspLkWSSelectPreOrderPaymentsWithId_Result.PayTypeTitle, text2, Labels.lblPOrd, cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordNumber.ToString(), rahkaranInternalSales, Labels.pordpayCashId, cRMspLkWSSelectPreOrderPaymentsWithId_Result.CashTitle ?? "") + "|";
							return text;
						}
						List<BaseInfoLinkAccDataViewModel> list = new JavaScriptSerializer().Deserialize<List<BaseInfoLinkAccDataViewModel>>(cRMspLkWSSelectPreOrderPaymentsWithId_Result.CashLinkAccData);
						if (list != null && Enumerable.Any<BaseInfoLinkAccDataViewModel>((IEnumerable<BaseInfoLinkAccDataViewModel>)list))
						{
							BaseInfoLinkAccDataViewModel baseInfoLinkAccDataViewModel = Enumerable.FirstOrDefault<BaseInfoLinkAccDataViewModel>((IEnumerable<BaseInfoLinkAccDataViewModel>)list, (Func<BaseInfoLinkAccDataViewModel, bool>)((BaseInfoLinkAccDataViewModel m) => m.DBId.GetValueOrDefault() == dbId));
							if (baseInfoLinkAccDataViewModel != null)
							{
								long.TryParse(baseInfoLinkAccDataViewModel.Id, out result7);
							}
						}
						if (result7 == 0L)
						{
							text = string.Format(Messages.msgErrorInSendPayToAccLinkNotFoundIteminAcc, cRMspLkWSSelectPreOrderPaymentsWithId_Result.PayTypeTitle, text2, Labels.lblPOrd, cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordNumber.ToString(), rahkaranInternalSales, Labels.pordpayCashId, cRMspLkWSSelectPreOrderPaymentsWithId_Result.CashTitle ?? "") + "|";
							return text;
						}
						if (!cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayBankingBranchID.HasValue)
						{
							result5 = 0L;
						}
						else if (string.IsNullOrWhiteSpace(cRMspLkWSSelectPreOrderPaymentsWithId_Result.BankingBranchLinkAccData))
						{
							result5 = 0L;
						}
						else
						{
							List<BaseInfoLinkAccDataViewModel> list2 = new JavaScriptSerializer().Deserialize<List<BaseInfoLinkAccDataViewModel>>(cRMspLkWSSelectPreOrderPaymentsWithId_Result.BankingBranchLinkAccData);
							if (list2 != null && Enumerable.Any<BaseInfoLinkAccDataViewModel>((IEnumerable<BaseInfoLinkAccDataViewModel>)list2))
							{
								BaseInfoLinkAccDataViewModel baseInfoLinkAccDataViewModel2 = Enumerable.FirstOrDefault<BaseInfoLinkAccDataViewModel>((IEnumerable<BaseInfoLinkAccDataViewModel>)list2, (Func<BaseInfoLinkAccDataViewModel, bool>)((BaseInfoLinkAccDataViewModel m) => m.DBId.GetValueOrDefault() == dbId));
								if (baseInfoLinkAccDataViewModel2 != null)
								{
									long.TryParse(baseInfoLinkAccDataViewModel2.Id, out result5);
								}
							}
							if (result5 == 0L)
							{
								text = string.Format(Messages.msgErrorInSendPayToAccLinkNotFoundIteminAcc, cRMspLkWSSelectPreOrderPaymentsWithId_Result.PayTypeTitle, text2, Labels.lblPOrd, cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordNumber.ToString(), rahkaranInternalSales, Labels.pordpayBankingBranchID, cRMspLkWSSelectPreOrderPaymentsWithId_Result.BankingBranchName ?? "") + "|";
								return text;
							}
						}
						if (!cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayGroupIdI.HasValue)
						{
							text = string.Format(Messages.msgErrorInSendPayToAccLinkNotSelectedItem, cRMspLkWSSelectPreOrderPaymentsWithId_Result.PayTypeTitle, text2, Labels.lblPOrd, cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordNumber.ToString(), rahkaranInternalSales, Labels.pordpayGroupIdI) + "|";
							return text;
						}
						if (string.IsNullOrWhiteSpace(cRMspLkWSSelectPreOrderPaymentsWithId_Result.ordpayGroupILinkAccData))
						{
							text = string.Format(Messages.msgErrorInSendPayToAccLinkNotFoundIteminAcc, cRMspLkWSSelectPreOrderPaymentsWithId_Result.PayTypeTitle, text2, Labels.lblPOrd, cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordNumber.ToString(), rahkaranInternalSales, Labels.pordpayGroupIdI, cRMspLkWSSelectPreOrderPaymentsWithId_Result.ordpayGroupIName ?? "") + "|";
							return text;
						}
						List<BaseInfoLinkAccDataViewModel> list3 = new JavaScriptSerializer().Deserialize<List<BaseInfoLinkAccDataViewModel>>(cRMspLkWSSelectPreOrderPaymentsWithId_Result.ordpayGroupILinkAccData);
						if (list3 != null && Enumerable.Any<BaseInfoLinkAccDataViewModel>((IEnumerable<BaseInfoLinkAccDataViewModel>)list3))
						{
							BaseInfoLinkAccDataViewModel baseInfoLinkAccDataViewModel3 = Enumerable.FirstOrDefault<BaseInfoLinkAccDataViewModel>((IEnumerable<BaseInfoLinkAccDataViewModel>)list3, (Func<BaseInfoLinkAccDataViewModel, bool>)((BaseInfoLinkAccDataViewModel m) => m.DBId.GetValueOrDefault() == dbId));
							if (baseInfoLinkAccDataViewModel3 != null)
							{
								long.TryParse(baseInfoLinkAccDataViewModel3.Id, out result8);
							}
						}
						if (result8 == 0L)
						{
							text = string.Format(Messages.msgErrorInSendPayToAccLinkNotFoundIteminAcc, cRMspLkWSSelectPreOrderPaymentsWithId_Result.PayTypeTitle, text2, Labels.lblPOrd, cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordNumber.ToString(), rahkaranInternalSales, Labels.pordpayGroupIdI, cRMspLkWSSelectPreOrderPaymentsWithId_Result.ordpayGroupIName ?? "") + "|";
							return text;
						}
						if (!cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayGroupIdII.HasValue)
						{
							text = string.Format(Messages.msgErrorInSendPayToAccLinkNotSelectedItem, cRMspLkWSSelectPreOrderPaymentsWithId_Result.PayTypeTitle, text2, Labels.lblPOrd, cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordNumber.ToString(), rahkaranInternalSales, Labels.pordpayGroupIdII) + "|";
							return text;
						}
						if (string.IsNullOrWhiteSpace(cRMspLkWSSelectPreOrderPaymentsWithId_Result.ordpayGroupIILinkAccData))
						{
							text = string.Format(Messages.msgErrorInSendPayToAccLinkNotFoundIteminAcc, cRMspLkWSSelectPreOrderPaymentsWithId_Result.PayTypeTitle, text2, Labels.lblPOrd, cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordNumber.ToString(), rahkaranInternalSales, Labels.pordpayGroupIdII, cRMspLkWSSelectPreOrderPaymentsWithId_Result.ordpayGroupIIName ?? "") + "|";
							return text;
						}
						List<BaseInfoLinkAccDataViewModel> list4 = new JavaScriptSerializer().Deserialize<List<BaseInfoLinkAccDataViewModel>>(cRMspLkWSSelectPreOrderPaymentsWithId_Result.ordpayGroupIILinkAccData);
						if (list4 != null && Enumerable.Any<BaseInfoLinkAccDataViewModel>((IEnumerable<BaseInfoLinkAccDataViewModel>)list4))
						{
							BaseInfoLinkAccDataViewModel baseInfoLinkAccDataViewModel4 = Enumerable.FirstOrDefault<BaseInfoLinkAccDataViewModel>((IEnumerable<BaseInfoLinkAccDataViewModel>)list4, (Func<BaseInfoLinkAccDataViewModel, bool>)((BaseInfoLinkAccDataViewModel m) => m.DBId.GetValueOrDefault() == dbId));
							if (baseInfoLinkAccDataViewModel4 != null)
							{
								long.TryParse(baseInfoLinkAccDataViewModel4.Id, out result9);
							}
						}
						if (result9 == 0L)
						{
							text = string.Format(Messages.msgErrorInSendPayToAccLinkNotFoundIteminAcc, cRMspLkWSSelectPreOrderPaymentsWithId_Result.PayTypeTitle, text2, Labels.lblPOrd, cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordNumber.ToString(), rahkaranInternalSales, Labels.pordpayGroupIdII, cRMspLkWSSelectPreOrderPaymentsWithId_Result.ordpayGroupIIName ?? "") + "|";
							return text;
						}
						text4 = "";
						text3 = "";
						switch (result2)
						{
						case 2:
							if (pordpayAmount > 0m && num3 == 1)
							{
								if (!cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayBankingBankID.HasValue)
								{
									text = string.Format(Messages.msgErrorInSendPayToAccLinkNotSelectedItem, cRMspLkWSSelectPreOrderPaymentsWithId_Result.PayTypeTitle, text2, Labels.lblPOrd, cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordNumber.ToString(), rahkaranInternalSales, Labels.pordpayBankingBankID) + "|";
									return text;
								}
								if (string.IsNullOrWhiteSpace(cRMspLkWSSelectPreOrderPaymentsWithId_Result.BankingBankLinkAccData))
								{
									text = string.Format(Messages.msgErrorInSendPayToAccLinkNotFoundIteminAcc, cRMspLkWSSelectPreOrderPaymentsWithId_Result.PayTypeTitle, text2, Labels.lblPOrd, cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordNumber.ToString(), rahkaranInternalSales, Labels.pordpayBankingBankID, cRMspLkWSSelectPreOrderPaymentsWithId_Result.BankingBankName ?? "") + "|";
									return text;
								}
								List<BaseInfoLinkAccDataViewModel> list6 = new JavaScriptSerializer().Deserialize<List<BaseInfoLinkAccDataViewModel>>(cRMspLkWSSelectPreOrderPaymentsWithId_Result.BankingBankLinkAccData);
								if (list6 != null && Enumerable.Any<BaseInfoLinkAccDataViewModel>((IEnumerable<BaseInfoLinkAccDataViewModel>)list6))
								{
									BaseInfoLinkAccDataViewModel baseInfoLinkAccDataViewModel6 = Enumerable.FirstOrDefault<BaseInfoLinkAccDataViewModel>((IEnumerable<BaseInfoLinkAccDataViewModel>)list6, (Func<BaseInfoLinkAccDataViewModel, bool>)((BaseInfoLinkAccDataViewModel m) => m.DBId.GetValueOrDefault() == dbId));
									if (baseInfoLinkAccDataViewModel6 != null)
									{
										long.TryParse(baseInfoLinkAccDataViewModel6.Id, out result4);
									}
								}
								if (result4 == 0L)
								{
									text = string.Format(Messages.msgErrorInSendPayToAccLinkNotFoundIteminAcc, cRMspLkWSSelectPreOrderPaymentsWithId_Result.PayTypeTitle, text2, Labels.lblPOrd, cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordNumber.ToString(), rahkaranInternalSales, Labels.pordpayBankingBankID, cRMspLkWSSelectPreOrderPaymentsWithId_Result.BankingBankName ?? "") + "|";
									return text;
								}
								text4 = cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayBranchName ?? "";
								text3 = cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayBranchCode ?? "";
								if (string.IsNullOrWhiteSpace(text4))
								{
									text = string.Format(Messages.msgErrorInSendPayToAccLinkNotSelectedItem, cRMspLkWSSelectPreOrderPaymentsWithId_Result.PayTypeTitle, text2, Labels.lblPOrd, cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordNumber.ToString(), rahkaranInternalSales, Labels.pordpayBranchName) + "|";
									return text;
								}
								if (string.IsNullOrWhiteSpace(text3))
								{
									text = string.Format(Messages.msgErrorInSendPayToAccLinkNotSelectedItem, cRMspLkWSSelectPreOrderPaymentsWithId_Result.PayTypeTitle, text2, Labels.lblPOrd, cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordNumber.ToString(), rahkaranInternalSales, Labels.pordpayBranchCode) + "|";
									return text;
								}
								if (string.IsNullOrWhiteSpace(cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayAccountNumber))
								{
									text = string.Format(Messages.msgErrorInSendPayToAccLinkNotSelectedItem, cRMspLkWSSelectPreOrderPaymentsWithId_Result.PayTypeTitle, text2, Labels.lblPOrd, cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordNumber.ToString(), rahkaranInternalSales, Labels.pordpayAccountNumber) + "|";
									return text;
								}
							}
							else
							{
								if (!cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayBankingAccountID.HasValue)
								{
									text = string.Format(Messages.msgErrorInSendPayToAccLinkNotSelectedItem, cRMspLkWSSelectPreOrderPaymentsWithId_Result.PayTypeTitle, text2, Labels.lblPOrd, cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordNumber.ToString(), rahkaranInternalSales, Labels.pordpayBankingAccountID) + "|";
									return text;
								}
								if (string.IsNullOrWhiteSpace(cRMspLkWSSelectPreOrderPaymentsWithId_Result.BankingAccountLinkAccData))
								{
									text = string.Format(Messages.msgErrorInSendPayToAccLinkNotFoundIteminAcc, cRMspLkWSSelectPreOrderPaymentsWithId_Result.PayTypeTitle, text2, Labels.lblPOrd, cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordNumber.ToString(), rahkaranInternalSales, Labels.pordpayBankingAccountID, cRMspLkWSSelectPreOrderPaymentsWithId_Result.BankingAccountTitle ?? "") + "|";
									return text;
								}
								List<BaseInfoLinkAccDataViewModel> list7 = new JavaScriptSerializer().Deserialize<List<BaseInfoLinkAccDataViewModel>>(cRMspLkWSSelectPreOrderPaymentsWithId_Result.BankingAccountLinkAccData);
								if (list7 != null && Enumerable.Any<BaseInfoLinkAccDataViewModel>((IEnumerable<BaseInfoLinkAccDataViewModel>)list7))
								{
									BaseInfoLinkAccDataViewModel baseInfoLinkAccDataViewModel7 = Enumerable.FirstOrDefault<BaseInfoLinkAccDataViewModel>((IEnumerable<BaseInfoLinkAccDataViewModel>)list7, (Func<BaseInfoLinkAccDataViewModel, bool>)((BaseInfoLinkAccDataViewModel m) => m.DBId.GetValueOrDefault() == dbId));
									if (baseInfoLinkAccDataViewModel7 != null)
									{
										long.TryParse(baseInfoLinkAccDataViewModel7.Id, out result6);
									}
								}
								if (result6 == 0L)
								{
									text = string.Format(Messages.msgErrorInSendPayToAccLinkNotFoundIteminAcc, cRMspLkWSSelectPreOrderPaymentsWithId_Result.PayTypeTitle, text2, Labels.lblPOrd, cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordNumber.ToString(), rahkaranInternalSales, Labels.pordpayBankingAccountID, cRMspLkWSSelectPreOrderPaymentsWithId_Result.BankingAccountTitle ?? "") + "|";
									return text;
								}
							}
							if (string.IsNullOrWhiteSpace(cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayDocNumber))
							{
								text = string.Format(Messages.msgErrorInSendPayToAccLinkNotSelectedItem, cRMspLkWSSelectPreOrderPaymentsWithId_Result.PayTypeTitle, text2, Labels.lblPOrd, cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordNumber.ToString(), rahkaranInternalSales, Labels.pordpayDocNumberChq) + "|";
								return text;
							}
							break;
						case 3:
						{
							if (!cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayBankingAccountID.HasValue)
							{
								text = string.Format(Messages.msgErrorInSendPayToAccLinkNotSelectedItem, cRMspLkWSSelectPreOrderPaymentsWithId_Result.PayTypeTitle, text2, Labels.lblPOrd, cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordNumber.ToString(), rahkaranInternalSales, Labels.pordpayBankingAccountID) + "|";
								return text;
							}
							if (string.IsNullOrWhiteSpace(cRMspLkWSSelectPreOrderPaymentsWithId_Result.BankingAccountLinkAccData))
							{
								text = string.Format(Messages.msgErrorInSendPayToAccLinkNotFoundIteminAcc, cRMspLkWSSelectPreOrderPaymentsWithId_Result.PayTypeTitle, text2, Labels.lblPOrd, cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordNumber.ToString(), rahkaranInternalSales, Labels.pordpayBankingAccountID, cRMspLkWSSelectPreOrderPaymentsWithId_Result.BankingAccountTitle ?? "") + "|";
								return text;
							}
							List<BaseInfoLinkAccDataViewModel> list5 = new JavaScriptSerializer().Deserialize<List<BaseInfoLinkAccDataViewModel>>(cRMspLkWSSelectPreOrderPaymentsWithId_Result.BankingAccountLinkAccData);
							if (list5 != null && Enumerable.Any<BaseInfoLinkAccDataViewModel>((IEnumerable<BaseInfoLinkAccDataViewModel>)list5))
							{
								BaseInfoLinkAccDataViewModel baseInfoLinkAccDataViewModel5 = Enumerable.FirstOrDefault<BaseInfoLinkAccDataViewModel>((IEnumerable<BaseInfoLinkAccDataViewModel>)list5, (Func<BaseInfoLinkAccDataViewModel, bool>)((BaseInfoLinkAccDataViewModel m) => m.DBId.GetValueOrDefault() == dbId));
								if (baseInfoLinkAccDataViewModel5 != null)
								{
									long.TryParse(baseInfoLinkAccDataViewModel5.Id, out result6);
								}
							}
							if (result6 == 0L)
							{
								text = string.Format(Messages.msgErrorInSendPayToAccLinkNotFoundIteminAcc, cRMspLkWSSelectPreOrderPaymentsWithId_Result.PayTypeTitle, text2, Labels.lblPOrd, cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordNumber.ToString(), rahkaranInternalSales, Labels.pordpayBankingAccountID, cRMspLkWSSelectPreOrderPaymentsWithId_Result.BankingAccountTitle ?? "") + "|";
								return text;
							}
							if (string.IsNullOrWhiteSpace(cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayDocNumber))
							{
								text = string.Format(Messages.msgErrorInSendPayToAccLinkNotSelectedItem, cRMspLkWSSelectPreOrderPaymentsWithId_Result.PayTypeTitle, text2, Labels.lblPOrd, cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordNumber.ToString(), rahkaranInternalSales, Labels.pordpayDocNumber) + "|";
								return text;
							}
							break;
						}
						}
						string text6 = "";
						string text7 = "";
						string text8 = "";
						try
						{
							DateTime dateTime = cRMspLkWSSelectPreOrderPaymentsWithId_Result.ImportDateTime ?? DateTime.Now;
							if (num == 2)
							{
								dateTime = cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayDocDateTime ?? DateTime.Now;
							}
							text6 = "\\/Date(" + ((DateTimeOffset)dateTime).ToUnixTimeMilliseconds() + "+0330)\\/";
							DateTime dateTime2 = cRMspLkWSSelectPreOrderPaymentsWithId_Result.ImportDateTime ?? DateTime.Now;
							if (num2 == 2)
							{
								dateTime2 = cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayDocDateTime ?? DateTime.Now;
							}
							text7 = "\\/Date(" + ((DateTimeOffset)dateTime2).ToUnixTimeMilliseconds() + "+0330)\\/";
							DateTime dateTime3 = dateTime2;
							text8 = dateTime3.ToString("yyyy/MM/dd", new PersianCulture());
						}
						catch (Exception e)
						{
							ErrorSignal.FromCurrentContext().Raise(e);
							text = string.Format(Messages.ErrorInFormat, Labels.Date);
							return text;
						}
						string text9 = "";
						string text10 = "";
						string text11 = "";
						CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordCompanyId.GetValueOrDefault());
						if (companyById == null)
						{
							text = Messages.CompanyNotFound + "|";
							return text;
						}
						text11 = companyById.cmpLinkAccCustomerIdStr ?? "";
						text10 = companyById.cmpLinkAccCode ?? "";
						text9 = companyById.CompanyName ?? "";
						if (string.IsNullOrWhiteSpace(text11))
						{
							string text12 = new CompanyController().RahkaranInternalSalesActCmpSendToAcc(cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordCompanyId.GetValueOrDefault(), 0, isExportCustomer: false, checkAction: false);
							if (string.IsNullOrEmpty(text12))
							{
								text = Messages.msgErrorRunFunction + "(insert company to rahkaran)|";
								return text;
							}
							string[] array = text12.Split(new char[1] { '|' });
							if (array != null)
							{
								if (!(array[0] == "1"))
								{
									text = array[0] + "|";
									return text;
								}
								companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordCompanyId.GetValueOrDefault());
								if (companyById == null)
								{
									text = Messages.CompanyNotFound + "|";
									return text;
								}
								text11 = companyById.cmpLinkAccCustomerIdStr ?? "";
								text10 = companyById.cmpLinkAccCode ?? "";
							}
						}
						if (string.IsNullOrWhiteSpace(text11) || string.IsNullOrWhiteSpace(text10))
						{
							text = string.Format(Messages.msgErrorInSendToAccLinkNotFoundCmpInAcc, rahkaranInternalSales) + "|";
							return text;
						}
						int mode = ((pordpayAmount > 0m && num3 == 1) ? 1 : 2);
						if (pordpayAmount < 0m)
						{
							pordpayAmount *= -1m;
						}
						string text13 = Labels.lblPOrd + " با شماره " + cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordLinkAccPreOrderNumber;
						RahkaranInternalSalesReceiptViewModel rahkaranInternalSalesReceiptViewModel = new RahkaranInternalSalesReceiptViewModel();
						rahkaranInternalSalesReceiptViewModel.BranchID = result5;
						rahkaranInternalSalesReceiptViewModel.CashID = result7;
						rahkaranInternalSalesReceiptViewModel.CounterPartDLCode = text10;
						rahkaranInternalSalesReceiptViewModel.Date = text6;
						rahkaranInternalSalesReceiptViewModel.Description = cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayDescription ?? "";
						rahkaranInternalSalesReceiptViewModel.Description_En = cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayDescription ?? "";
						rahkaranInternalSalesReceiptViewModel.IsApproved = value3;
						switch (result2)
						{
						case 1:
						{
							if (string.IsNullOrWhiteSpace(text5))
							{
								text5 = $"دریافت وجه نقد از {text9} بابت  {text13}";
							}
							rahkaranInternalSalesReceiptViewModel.ReceiptCashMoneys = new List<RahkaranInternalSalesReceiptCashMoneysViewModel>();
							RahkaranInternalSalesReceiptCashMoneysViewModel item2 = new RahkaranInternalSalesReceiptCashMoneysViewModel
							{
								AccountingOperationID = result8,
								Amount = pordpayAmount,
								BaseCurrencyExchangeRate = value4,
								CashFlowFactorID = result9,
								CounterPartDLCode = text10,
								Description = text5,
								Description_En = text5,
								OperationalCurrencyExchangeRate = value5
							};
							rahkaranInternalSalesReceiptViewModel.ReceiptCashMoneys.Add(item2);
							break;
						}
						case 2:
						{
							if (string.IsNullOrWhiteSpace(text5))
							{
								text5 = string.Format("دریافت چک به شماره {0} به تاریخ  سر رسید {1} بابت {2}", cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayDocNumber ?? "", text8, text13);
							}
							rahkaranInternalSalesReceiptViewModel.ReceiptReceivableCheques = new List<RahkaranInternalSalesReceiptReceivableChequesViewModel>();
							RahkaranInternalSalesReceiptReceivableChequesViewModel item3 = new RahkaranInternalSalesReceiptReceivableChequesViewModel
							{
								AccountNumber = (cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayAccountNumber ?? ""),
								AccountingOperationID = result8,
								Amount = pordpayAmount,
								BankBranchCode = text3,
								BankBranchName = text4,
								BankID = result4,
								BaseCurrencyExchangeRate = value4,
								CashFlowFactorID = result9,
								CounterPartDLCode = text10,
								Description = text5,
								Description_En = text5,
								DueDate = text7,
								OperationalCurrencyExchangeRate = value5,
								SayadNumber = (cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayChqSayadNumber ?? ""),
								SerialNumber = (cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayDocNumber ?? "")
							};
							rahkaranInternalSalesReceiptViewModel.ReceiptReceivableCheques.Add(item3);
							break;
						}
						case 3:
						{
							if (string.IsNullOrWhiteSpace(text5))
							{
								text5 = string.Format("واریز از نوع {0} به حساب از {1} بابت {2}", cRMspLkWSSelectPreOrderPaymentsWithId_Result.PayTypeTitle ?? "", text9, text13);
							}
							rahkaranInternalSalesReceiptViewModel.ReceiptDeposits = new List<RahkaranInternalSalesReceiptDepositsViewModel>();
							RahkaranInternalSalesReceiptDepositsViewModel item = new RahkaranInternalSalesReceiptDepositsViewModel
							{
								AccountingOperationID = result8,
								Amount = pordpayAmount,
								BankAccountID = result6,
								BaseCurrencyExchangeRate = value4,
								CashFlowFactorID = result9,
								CounterPartDLCode = text10,
								Date = text7,
								Description = text5,
								Description_En = text5,
								Number = (cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayDocNumber ?? ""),
								OperationalCurrencyExchangeRate = value5
							};
							rahkaranInternalSalesReceiptViewModel.ReceiptDeposits.Add(item);
							break;
						}
						}
						text5 = cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayDescription ?? "";
						RahkaranInternalSalesPaymentViewModel rahkaranInternalSalesPaymentViewModel = new RahkaranInternalSalesPaymentViewModel();
						rahkaranInternalSalesPaymentViewModel.BranchID = result5;
						rahkaranInternalSalesPaymentViewModel.CashID = result7;
						rahkaranInternalSalesPaymentViewModel.CounterPartDLCode = text10;
						rahkaranInternalSalesPaymentViewModel.Date = text6;
						rahkaranInternalSalesPaymentViewModel.Description = cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayDescription ?? "";
						rahkaranInternalSalesPaymentViewModel.Description_En = cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayDescription ?? "";
						switch (result2)
						{
						case 1:
						{
							if (string.IsNullOrWhiteSpace(text5))
							{
								text5 = $"واریز وجه نقد به {text9} بابت  {text13}";
							}
							rahkaranInternalSalesPaymentViewModel.PaymentCashMoneys = new List<RahkaranInternalSalesPaymentCashMoneysViewModel>();
							RahkaranInternalSalesPaymentCashMoneysViewModel item5 = new RahkaranInternalSalesPaymentCashMoneysViewModel
							{
								AccountingOperationID = result8,
								Amount = pordpayAmount,
								BaseCurrencyExchangeRate = value4,
								CashFlowFactorID = result9,
								CounterPartDLCode = text10,
								Description = text5,
								Description_En = text5,
								OperationalCurrencyExchangeRate = value5
							};
							rahkaranInternalSalesPaymentViewModel.PaymentCashMoneys.Add(item5);
							break;
						}
						case 2:
						{
							if (string.IsNullOrWhiteSpace(text5))
							{
								text5 = string.Format("چک به شماره {0} به تاریخ  سر رسید {1} بابت {2}", cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayDocNumber ?? "", text8, text13);
							}
							rahkaranInternalSalesPaymentViewModel.PaymentPayableCheques = new List<RahkaranInternalSalesPaymentPayableChequesViewModel>();
							RahkaranInternalSalesPaymentPayableChequesViewModel item6 = new RahkaranInternalSalesPaymentPayableChequesViewModel
							{
								AccountingOperationID = result8,
								Amount = pordpayAmount,
								BankAccountID = result6,
								BaseCurrencyExchangeRate = value4,
								CashFlowFactorID = result9,
								ChequeNumber = (cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayChqSayadNumber ?? ""),
								ChequeSeriesNumber = (cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayDocNumber ?? ""),
								CounterPartDLCode = text10,
								Description = text5,
								Description_En = text5,
								DueDate = text7,
								OperationalCurrencyExchangeRate = value5
							};
							rahkaranInternalSalesPaymentViewModel.PaymentPayableCheques.Add(item6);
							break;
						}
						case 3:
						{
							if (string.IsNullOrWhiteSpace(text5))
							{
								text5 = string.Format("واریز از نوع {0} به حساب {1} بابت {2}", cRMspLkWSSelectPreOrderPaymentsWithId_Result.PayTypeTitle ?? "", text9, text13);
							}
							rahkaranInternalSalesPaymentViewModel.PaymentDeposits = new List<RahkaranInternalSalesPaymentDepositsViewModel>();
							RahkaranInternalSalesPaymentDepositsViewModel item4 = new RahkaranInternalSalesPaymentDepositsViewModel
							{
								AccountingOperationID = result8,
								Amount = pordpayAmount,
								BankAccountID = result6,
								BaseCurrencyExchangeRate = value4,
								CashFlowFactorID = result9,
								CounterPartDLCode = text10,
								Date = text7,
								Description = text5,
								Description_En = text5,
								Number = (cRMspLkWSSelectPreOrderPaymentsWithId_Result.pordpayDocNumber ?? ""),
								OperationalCurrencyExchangeRate = value5
							};
							rahkaranInternalSalesPaymentViewModel.PaymentDeposits.Add(item4);
							break;
						}
						}
						long linkAccId = 0L;
						string linkAccNumber = "";
						string errorMsg = "";
						string text14 = rahkaranInternalSalesProvider.SendPayment(mode, rahkaranInternalSalesReceiptViewModel, rahkaranInternalSalesPaymentViewModel, ref linkAccId, ref linkAccNumber, ref errorMsg);
						if (!string.IsNullOrWhiteSpace(text14))
						{
							text14 = text14.ClearHiddenCharacters();
						}
						if (linkAccId <= 0)
						{
							text = (string.IsNullOrWhiteSpace(errorMsg) ? (text + "<br>" + Messages.msgErrorCommunicateWithServer + "<br>" + text14 + "|") : (text + "<br>" + Messages.msgErrorCommunicateWithServer + "<br>" + errorMsg + "|"));
						}
						else
						{
							string text15 = linkAccId.ToString();
							string text16 = linkAccNumber;
							if (!string.IsNullOrWhiteSpace(text15))
							{
								_dbLink.WSspUpdatePreOrderPaymentWithAccLinkField(payId, null, text16, null, null, null, text15, null, null, null, null, false, userId, value2, value, registerDatePersian, appType);
								text = "1|" + text16;
							}
							else
							{
								text = text + "<br>" + Messages.msgErrorCommunicateWithServer + "|";
							}
						}
					}
					else
					{
						text = Messages.ErrorNotFound + "|";
					}
				}
				catch (Exception ex)
				{
					text = text + "\n\nException: " + ex.Message;
				}
			}
			else
			{
				text = Messages.ErrorNotFound + "|";
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			text = Messages.msgErrorRunFunction + "|";
		}
		return text;
	}

	public LkPreOrderInfoViewModelObjects GetRayvarzPreOrderList(string fDate = "", string tDate = "", int kind = 0, bool isUpdateList = false, int linkAccPageNum = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		LkPreOrderInfoViewModelObjects lkPreOrderInfoViewModelObjects = new LkPreOrderInfoViewModelObjects();
		List<LkWSPreOrderInfoViewModel> list = new List<LkWSPreOrderInfoViewModel>();
		List<LkWSPreOrderItemsInfoViewModel> list2 = new List<LkWSPreOrderItemsInfoViewModel>();
		try
		{
			string text = fDate;
			string text2 = tDate;
			string fromDate = "";
			string toDate = "";
			try
			{
				DateTime now = DateTime.Now;
				DateTime now2 = DateTime.Now;
				if (!string.IsNullOrWhiteSpace(text))
				{
					text = text.Replace("/", "").Replace("-", "").Replace("\\", "")
						.Replace(" ", "")
						.Replace("_", "");
					fromDate = (lCID switch
					{
						1065 => DateTime.Parse(PersianDate.GetFormatetdDate(text) + " 00:00:00"), 
						1025 => DateTime.Parse(PersianDate.GetFormatetdDate(text) + " 00:00:00", new CultureInfo("ar-SA"), DateTimeStyles.None), 
						_ => DateTime.Parse(PersianDate.GetFormatetdDate(text) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None), 
					}).ToString("yyyyMMdd", new PersianCulture());
				}
				if (!string.IsNullOrEmpty(text2))
				{
					text2 = text2.Replace("/", "").Replace("-", "").Replace("\\", "")
						.Replace(" ", "")
						.Replace("_", "");
					toDate = (lCID switch
					{
						1065 => DateTime.Parse(PersianDate.GetFormatetdDate(text2) + " 23:59:59"), 
						1025 => DateTime.Parse(PersianDate.GetFormatetdDate(text2) + " 23:59:59", new CultureInfo("ar-SA"), DateTimeStyles.None), 
						_ => DateTime.Parse(PersianDate.GetFormatetdDate(text2) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None), 
					}).ToString("yyyyMMdd", new PersianCulture());
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
			int oprType = 1;
			kind = 0;
			CRMIdeal.Classes.Helper.OtherSystems.RayvarzProvider rayvarzProvider = new CRMIdeal.Classes.Helper.OtherSystems.RayvarzProvider(isUpdateList);
			int pordLinkedToAccApiMode = rayvarzProvider.PordLinkedToAccApiMode;
			string value = rayvarzProvider.GetSalesIssueList(fromDate, toDate, linkAccPageNum, oprType, pordLinkedToAccApiMode);
			if (!string.IsNullOrWhiteSpace(value))
			{
				if (!string.IsNullOrWhiteSpace(value))
				{
					value = value.ClearHiddenCharacters();
				}
				if (!string.IsNullOrWhiteSpace(value))
				{
					List<RayvarzSalesIssueListResponseViewModel> list3 = JsonConvert.DeserializeObject<List<RayvarzSalesIssueListResponseViewModel>>(value);
					if (list3 != null && Enumerable.Any<RayvarzSalesIssueListResponseViewModel>((IEnumerable<RayvarzSalesIssueListResponseViewModel>)list3))
					{
						List<WSspSelectPreOrderWithAccLinkField_Result> list4 = SelectPreOrderWithAccLinkField(withPordpordLinkAccPreOrderId: false, withPordpordLinkAccPreOrderIdStr: true, withPordLinkAccPreOrderNumber: true);
						List<CRMspSelectCompanyWithAccLinkField_Result> list5 = new CompanyController().SelectCompanyWithAccLinkField(withLinkAccCode: false, withLinkAccCodeId: false, withLinkCustomerId: false, withLinkCustomerIdStr: true);
						int num = 1;
						foreach (RayvarzSalesIssueListResponseViewModel item in list3)
						{
							LkWSPreOrderInfoViewModel vmPord = new LkWSPreOrderInfoViewModel();
							if (!string.IsNullOrWhiteSpace(item.docDate))
							{
								DateTime dateTime = default(DateTime);
								try
								{
									if (!string.IsNullOrWhiteSpace(item.docDate))
									{
										dateTime = DateTime.Parse(PersianDate.GetFormatetdDate(item.docDate.Replace("/", "")) + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
										vmPord.pordDateTime = dateTime;
									}
									else
									{
										vmPord.pordDateTime = DateTime.Now;
									}
								}
								catch (Exception e2)
								{
									ErrorSignal.FromCurrentContext().Raise(e2);
								}
								vmPord.pordDate = (vmPord.pordDateTime.HasValue ? vmPord.pordDateTime.Value.ToString("yyyyMMdd") : "");
							}
							DateTime value2 = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
							vmPord.pordLinkAccPreOrderIdStr = item.salesJournalId.GetValueOrDefault().ToString();
							vmPord.pordLinkAccPreOrderNumber = item.docNo.GetValueOrDefault().ToString();
							string voucherNumber = item.proFormaDocNo.GetValueOrDefault().ToString();
							string extraField = item.rayGuid ?? "";
							string text3 = "";
							PordLinkAccDataByVoucherAndExtraViewModel value3 = new PordLinkAccDataByVoucherAndExtraViewModel
							{
								DBId = -1,
								Id = vmPord.pordLinkAccPreOrderIdStr,
								Number = vmPord.pordLinkAccPreOrderNumber,
								VoucherId = "0",
								VoucherNumber = voucherNumber,
								FTDate = value2,
								LTDate = value2,
								ExtraField = extraField
							};
							text3 = "[" + JsonConvert.SerializeObject(value3) + "]";
							vmPord.pordLinkAccData = text3;
							vmPord.cmpLinkAccCustomerIdStr = item.customerId ?? "";
							if (list5 != null && !string.IsNullOrWhiteSpace(vmPord.cmpLinkAccCustomerIdStr) && Enumerable.Any<CRMspSelectCompanyWithAccLinkField_Result>((IEnumerable<CRMspSelectCompanyWithAccLinkField_Result>)list5))
							{
								CRMspSelectCompanyWithAccLinkField_Result cRMspSelectCompanyWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyWithAccLinkField_Result>((IEnumerable<CRMspSelectCompanyWithAccLinkField_Result>)list5, (Func<CRMspSelectCompanyWithAccLinkField_Result, bool>)((CRMspSelectCompanyWithAccLinkField_Result m) => m.cmpLinkAccCustomerIdStr == vmPord.cmpLinkAccCustomerIdStr));
								if (cRMspSelectCompanyWithAccLinkField_Result != null)
								{
									vmPord.pordCompanyId = cRMspSelectCompanyWithAccLinkField_Result.CompanyID;
									vmPord.cmpName = cRMspSelectCompanyWithAccLinkField_Result.CompanyName ?? "";
									vmPord.cmpLinkAccCode = cRMspSelectCompanyWithAccLinkField_Result.cmpLinkAccCode;
								}
							}
							vmPord.pordTotalAmount = item.totalPayableAmount.GetValueOrDefault();
							vmPord.LinkAccSaleCenterIdStr = item.contractNo ?? "";
							RayvarzSalesIssueListResponseViewModel rayvarzSalesIssueListResponseViewModel = new RayvarzSalesIssueListResponseViewModel();
							rayvarzSalesIssueListResponseViewModel = ((pordLinkedToAccApiMode != 2) ? rayvarzProvider.GetSalesIssue(item.salesJournalId.GetValueOrDefault(), oprType, pordLinkedToAccApiMode) : item);
							if (rayvarzSalesIssueListResponseViewModel != null)
							{
								List<RayvarzSalesIssueItemListResponseViewModel> salesJournalItems = rayvarzSalesIssueListResponseViewModel.salesJournalItems;
								if (salesJournalItems != null && Enumerable.Any<RayvarzSalesIssueItemListResponseViewModel>((IEnumerable<RayvarzSalesIssueItemListResponseViewModel>)salesJournalItems))
								{
									salesJournalItems = Enumerable.ToList<RayvarzSalesIssueItemListResponseViewModel>((IEnumerable<RayvarzSalesIssueItemListResponseViewModel>)Enumerable.OrderBy<RayvarzSalesIssueItemListResponseViewModel, long>((IEnumerable<RayvarzSalesIssueItemListResponseViewModel>)salesJournalItems, (Func<RayvarzSalesIssueItemListResponseViewModel, long>)((RayvarzSalesIssueItemListResponseViewModel m) => m.row.GetValueOrDefault())));
									foreach (RayvarzSalesIssueItemListResponseViewModel item2 in salesJournalItems)
									{
										LkWSPreOrderItemsInfoViewModel lkWSPreOrderItemsInfoViewModel = new LkWSPreOrderItemsInfoViewModel();
										lkWSPreOrderItemsInfoViewModel.pordLinkAccPreOrderIdStr = item.salesJournalId.GetValueOrDefault().ToString();
										lkWSPreOrderItemsInfoViewModel.pordLinkAccPreOrderNumber = vmPord.pordLinkAccPreOrderNumber;
										lkWSPreOrderItemsInfoViewModel.PrdLinkAccPrdIdStr = item2.itemDataId ?? "";
										lkWSPreOrderItemsInfoViewModel.pordILinkAccItemIdStr = item2.salesJournalItemId.GetValueOrDefault().ToString();
										PordItemLinkAccDataByExtraViewModel value4 = new PordItemLinkAccDataByExtraViewModel
										{
											DBId = -1,
											Id = lkWSPreOrderItemsInfoViewModel.pordILinkAccItemIdStr,
											FTDate = value2,
											LTDate = value2,
											ExtraField = (item2.rayGuid ?? "")
										};
										lkWSPreOrderItemsInfoViewModel.pordILinkAccData = "[" + JsonConvert.SerializeObject(value4) + "]";
										lkWSPreOrderItemsInfoViewModel.PrdName = item2.itemData ?? lkWSPreOrderItemsInfoViewModel.PrdLinkAccPrdIdStr;
										if (!string.IsNullOrWhiteSpace(item2.totalQtyUnitId))
										{
											lkWSPreOrderItemsInfoViewModel.UnitLinkAccUnitIdStr = item2.totalQtyUnitId;
										}
										lkWSPreOrderItemsInfoViewModel.WrhsLinkAccWhIdStr = item2.warehouseId ?? "";
										lkWSPreOrderItemsInfoViewModel.pordIQuantity = item2.totalWeight.GetValueOrDefault();
										if (item2.partialQty.GetValueOrDefault() > 0.0 && !string.IsNullOrWhiteSpace(item2.partialQtyUnitId))
										{
											lkWSPreOrderItemsInfoViewModel.UnitLinkAccUnitIdStrI = item2.partialQtyUnitId;
										}
										lkWSPreOrderItemsInfoViewModel.pordIDescription = item2.description ?? "";
										lkWSPreOrderItemsInfoViewModel.pordIPrice = item2.unitAmount;
										lkWSPreOrderItemsInfoViewModel.pordITotalPrice = item2.payableAmount;
										if (item2.discountAmount.GetValueOrDefault() != 0m)
										{
											lkWSPreOrderItemsInfoViewModel.pordIDiscountSum = item2.discountAmount;
										}
										if (item2.totalTollAmount.GetValueOrDefault() != 0m)
										{
											lkWSPreOrderItemsInfoViewModel.pordITaxSum = item2.totalTollAmount;
										}
										list2.Add(lkWSPreOrderItemsInfoViewModel);
									}
								}
							}
							vmPord.RowNumber = num;
							if (list4 != null && Enumerable.Any<WSspSelectPreOrderWithAccLinkField_Result>((IEnumerable<WSspSelectPreOrderWithAccLinkField_Result>)list4))
							{
								WSspSelectPreOrderWithAccLinkField_Result wSspSelectPreOrderWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectPreOrderWithAccLinkField_Result>((IEnumerable<WSspSelectPreOrderWithAccLinkField_Result>)list4, (Func<WSspSelectPreOrderWithAccLinkField_Result, bool>)((WSspSelectPreOrderWithAccLinkField_Result x) => x.pordLinkAccPreOrderIdStr == vmPord.pordLinkAccPreOrderIdStr));
								if (wSspSelectPreOrderWithAccLinkField_Result != null)
								{
									if (!string.IsNullOrWhiteSpace(wSspSelectPreOrderWithAccLinkField_Result.pordLinkAccPreOrderIdStr))
									{
										vmPord.PreOrderID = wSspSelectPreOrderWithAccLinkField_Result.PreOrderID;
									}
								}
								else
								{
									vmPord.PreOrderID = 0;
								}
							}
							list.Add(vmPord);
							num++;
						}
					}
				}
			}
			lkPreOrderInfoViewModelObjects.lst = list;
			lkPreOrderInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			lkPreOrderInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
			lkPreOrderInfoViewModelObjects.lstItems = list2;
		}
		catch (Exception e3)
		{
			ErrorSignal.FromCurrentContext().Raise(e3);
		}
		return lkPreOrderInfoViewModelObjects;
	}

	public LkWSPreOrderInfoViewModel GetRayvarzPreOrder(string pordLinkAccPreOrderIdStr = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		LkWSPreOrderInfoViewModel lkWSPreOrderInfoViewModel = new LkWSPreOrderInfoViewModel();
		try
		{
			long result2 = 0L;
			long.TryParse(pordLinkAccPreOrderIdStr, out result2);
			CRMIdeal.Classes.Helper.OtherSystems.RayvarzProvider rayvarzProvider = new CRMIdeal.Classes.Helper.OtherSystems.RayvarzProvider();
			RayvarzSalesIssueListResponseViewModel rayvarzSalesIssueListResponseViewModel = rayvarzProvider.GetSalesIssue(linkedToAccApiMode: rayvarzProvider.PordLinkedToAccApiMode, linkAccId: result2);
			if (rayvarzSalesIssueListResponseViewModel != null)
			{
				lkWSPreOrderInfoViewModel.pordLinkAccPreOrderIdStr = rayvarzSalesIssueListResponseViewModel.salesJournalId.ToString();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return lkWSPreOrderInfoViewModel;
	}

	[AjaxOnly]
	public string RayvarzActSendToAcc(int pordId, bool sendPordPayToAcc = false, bool isPayCanceled = false, bool isHeadCanceled = false)
	{
		//IL_099a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a98: Unknown result type (might be due to invalid IL or missing references)
		//IL_171b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a9f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f1f: Unknown result type (might be due to invalid IL or missing references)
		string text = "";
		try
		{
			_ = UserLogin.CurrentUser;
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
			if (pordId > 0)
			{
				try
				{
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
					string appType = Configuration.AppType;
					short.Parse(Financial.Get().Id.ToString());
					int userId = UserLogin.CurrentUser.UserId;
					_ = Financial.Get().Id;
					string rayvarz = Labels.Rayvarz;
					CRMspLkWSSelectPreOrderById_Result cRMspLkWSSelectPreOrderById_Result = Enumerable.FirstOrDefault<CRMspLkWSSelectPreOrderById_Result>((IEnumerable<CRMspLkWSSelectPreOrderById_Result>)_dbLink.CRMspLkWSSelectPreOrderById(pordId, lCID, result, result2));
					if (cRMspLkWSSelectPreOrderById_Result != null)
					{
						string errorMessage = "";
						if (!PreOrder.SendToLinkAccNeedVerify(pordId, ref errorMessage))
						{
							text = errorMessage + "|";
							return text;
						}
						CRMIdeal.Classes.Helper.OtherSystems.RayvarzProvider rayvarzProvider = new CRMIdeal.Classes.Helper.OtherSystems.RayvarzProvider();
						int wrhsSyncTypeId = rayvarzProvider.WrhsSyncTypeId;
						string pordFieldLinkedToAcc = rayvarzProvider.PordFieldLinkedToAcc;
						long fiscalYearId = rayvarzProvider.FiscalYearId;
						long result3 = 0L;
						long.TryParse(rayvarzProvider.ApiBranchId, out result3);
						long num = 0L;
						long num2 = 0L;
						long num3 = 0L;
						string text2 = "";
						string text3 = "RLS";
						long num4 = 0L;
						long num5 = 0L;
						long num6 = 0L;
						long num7 = 0L;
						int pordLinkedToAccApiMode = rayvarzProvider.PordLinkedToAccApiMode;
						switch (pordLinkedToAccApiMode)
						{
						case 0:
							text = string.Format(Messages.msgErrorInSendPordToAccLinkNotSelectedItem, cRMspLkWSSelectPreOrderById_Result.pordNumber, rayvarz, Labels.OtherSystemApiSendMode) + "|";
							return text;
						case 2:
							sendPordPayToAcc = false;
							isPayCanceled = false;
							break;
						}
						int result4 = 0;
						string text4 = "";
						if (pordFieldLinkedToAcc == "1")
						{
							int.TryParse(cRMspLkWSSelectPreOrderById_Result.PreOrderOprID.ToString(), out result4);
							text4 = Labels.PreOrderOprID;
						}
						else if (pordFieldLinkedToAcc == "2")
						{
							int.TryParse(cRMspLkWSSelectPreOrderById_Result.pordTypeId.ToString(), out result4);
							text4 = Labels.pordTypeId;
						}
						if (result4 == 0)
						{
							text = string.Format(Messages.msgErrorInSendPordToAccLinkNotSelectedItem, cRMspLkWSSelectPreOrderById_Result.pordNumber, rayvarz, text4) + "|";
							return text;
						}
						CRMIdeal.Classes.Helper.OtherSystems.RayvarzProvider.RayvarzSettingDetailsViewModel settingDetails = rayvarzProvider.GetSettingDetails(0, result4, "PreOrderOpr");
						if (settingDetails == null)
						{
							text = string.Format(Messages.msgErrorInSendPordToAccLinkNotSelectedItem, cRMspLkWSSelectPreOrderById_Result.pordNumber, rayvarz, string.Format(Labels.SettingByFormat, text4)) + "|";
							return text;
						}
						num = settingDetails.PordWebDocTypeId;
						num2 = settingDetails.PordSalesTypeId;
						num3 = settingDetails.PordReceiveTypeId;
						text2 = settingDetails.PordUserId;
						text3 = settingDetails.PordCurrencyId;
						num4 = settingDetails.PordDiscountTypeId;
						num5 = settingDetails.PordSalesDocTypeId;
						num6 = settingDetails.PordReturnReasonId;
						num7 = settingDetails.PordSalesDocProduceTypeId;
						if (num == 0L || num2 == 0L)
						{
							text = string.Format(Messages.msgErrorInSendPordToAccLinkNotSelectedItem, cRMspLkWSSelectPreOrderById_Result.pordNumber, rayvarz, string.Format(Labels.SettingByFormat, text4)) + "|";
							return text;
						}
						string text5 = "";
						if (cRMspLkWSSelectPreOrderById_Result.pordSaleCenterId.HasValue)
						{
							int result5 = 0;
							int.TryParse(cRMspLkWSSelectPreOrderById_Result.pordSaleCenterId.ToString(), out result5);
							if (result5 != 0)
							{
								CRMIdeal.Classes.Helper.OtherSystems.RayvarzProvider.RayvarzSettingDetailsViewModel settingDetails2 = rayvarzProvider.GetSettingDetails(0, result5, "SaleCenter");
								if (settingDetails2 != null)
								{
									text5 = settingDetails2.SaleCenterAccCode ?? "";
								}
							}
						}
						int num8 = 1;
						if (num8 != 2)
						{
							num6 = 0L;
						}
						if (!string.IsNullOrWhiteSpace(cRMspLkWSSelectPreOrderById_Result.pordLinkAccPreOrderIdStr))
						{
							LkWSPreOrderInfoViewModel rayvarzPreOrder = GetRayvarzPreOrder(cRMspLkWSSelectPreOrderById_Result.pordLinkAccPreOrderIdStr);
							bool flag = false;
							if (rayvarzPreOrder != null)
							{
								if (string.IsNullOrWhiteSpace(cRMspLkWSSelectPreOrderById_Result.pordLinkAccPreOrderIdStr))
								{
									_dbLink.WSspUpdatePreOrderAndItemWithAccLinkField(pordId, null, null, null, null, null, true, userId, value2, value, registerDatePersian, appType);
								}
								else
								{
									flag = true;
								}
							}
							else
							{
								_dbLink.WSspUpdatePreOrderAndItemWithAccLinkField(pordId, null, null, null, null, null, true, userId, value2, value, registerDatePersian, appType);
								cRMspLkWSSelectPreOrderById_Result.pordLinkAccPreOrderIdStr = "";
								cRMspLkWSSelectPreOrderById_Result.pordLinkAccPreOrderNumber = "";
								cRMspLkWSSelectPreOrderById_Result.pordLinkAccData = "";
							}
							if (flag)
							{
								if (!isHeadCanceled)
								{
									text = string.Format(Messages.msgErrorNotReSendPordToOtherSystem, cRMspLkWSSelectPreOrderById_Result.pordNumber.ToString(), rayvarz) + "|";
									return text;
								}
								long result6 = 0L;
								long.TryParse(cRMspLkWSSelectPreOrderById_Result.pordLinkAccPreOrderIdStr, out result6);
								if (result6 != 0L)
								{
									bool isDone = false;
									string text6 = rayvarzProvider.DeleteSales(result6, ref isDone, pordLinkedToAccApiMode);
									if (isDone)
									{
										_dbLink.WSspUpdatePreOrderAndItemWithAccLinkField(pordId, null, null, null, null, null, true, userId, value2, value, registerDatePersian, appType);
										cRMspLkWSSelectPreOrderById_Result.pordLinkAccPreOrderIdStr = "";
										cRMspLkWSSelectPreOrderById_Result.pordLinkAccPreOrderNumber = "";
										cRMspLkWSSelectPreOrderById_Result.pordLinkAccData = "";
										text = "1|-100000";
										if (isPayCanceled)
										{
											string text7 = RayvarzActSendPaymentsToAcc(pordId, 0, isPayCanceled);
											if (!string.IsNullOrWhiteSpace(text7))
											{
												string[] array = text7.Split(new char[1] { '|' });
												if (array != null && array.Length >= 1 && array[0] != "1")
												{
													text = array[0] + "|";
													return text;
												}
											}
										}
										return text;
									}
									if (!string.IsNullOrWhiteSpace(text6))
									{
										text = text + "<br>" + Messages.msgErrorRunFunction + " (" + text6 + ")|";
										return text;
									}
									text = Messages.msgErrorRunFunction + "|";
									return text;
								}
							}
						}
						long result7 = 0L;
						long.TryParse(cRMspLkWSSelectPreOrderById_Result.pordLinkAccPreOrderIdStr, out result7);
						List<CRMspLkWSSelectPreOrderItems_Result> list = Enumerable.ToList<CRMspLkWSSelectPreOrderItems_Result>((IEnumerable<CRMspLkWSSelectPreOrderItems_Result>)_dbLink.CRMspLkWSSelectPreOrderItems(pordId, lCID, result));
						if (list == null || !Enumerable.Any<CRMspLkWSSelectPreOrderItems_Result>((IEnumerable<CRMspLkWSSelectPreOrderItems_Result>)list))
						{
							text = Messages.ErrorNotFound + "|";
							return text;
						}
						foreach (CRMspLkWSSelectPreOrderItems_Result item2 in list)
						{
							if (string.IsNullOrWhiteSpace(item2.PrdLinkAccPrdIdStr))
							{
								text = string.Format(Messages.msgErrorInSendPordToAccLinkNotFoundPrdInAcc, cRMspLkWSSelectPreOrderById_Result.pordNumber, rayvarz, item2.PrdName ?? "") + "|";
								return text;
							}
							if (string.IsNullOrWhiteSpace(item2.SGLinkAccGroupIdStr))
							{
								text = string.Format(Messages.msgErrorInSendPordToAccLinkNotFoundPrdGroupInAcc, cRMspLkWSSelectPreOrderById_Result.pordNumber, rayvarz, item2.PrdSGName ?? "") + "|";
								return text;
							}
							if (item2.pordIPrdUnitId.HasValue && string.IsNullOrWhiteSpace(item2.UnitLinkAccUnitIdStr))
							{
								text = string.Format(Messages.msgErrorInSendPordToAccLinkNotFoundPrdUnitInAcc, cRMspLkWSSelectPreOrderById_Result.pordNumber, rayvarz, item2.pordIPrdUnit ?? "") + "|";
								return text;
							}
							if (item2.pordIWHId.HasValue)
							{
								string value3 = "";
								string value4 = "";
								if (wrhsSyncTypeId == 2 && !string.IsNullOrWhiteSpace(item2.pordILinkAccWHIdStr))
								{
									if (!string.IsNullOrWhiteSpace(item2.WrhsLinkAccWareHouses))
									{
										List<CommonWithIdStrViewModel> list2 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(item2.WrhsLinkAccWareHouses);
										if (list2 != null && list2.Count > 0)
										{
											CommonWithIdStrViewModel commonWithIdStrViewModel = Enumerable.FirstOrDefault<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list2, (Func<CommonWithIdStrViewModel, bool>)((CommonWithIdStrViewModel x) => x.Id == item2.pordILinkAccWHIdStr));
											if (commonWithIdStrViewModel != null)
											{
												value4 = commonWithIdStrViewModel.Name;
												value3 = commonWithIdStrViewModel.Id;
											}
										}
									}
								}
								else
								{
									value3 = item2.WrhsLinkAccWhIdStr;
									value4 = item2.pordIWrhsName;
								}
								if (string.IsNullOrWhiteSpace(value3) || string.IsNullOrWhiteSpace(value4))
								{
									text = string.Format(Messages.msgErrorWareHouseNotFoundInAccLink, item2.pordIWrhsName ?? "", rayvarz);
									return text;
								}
								continue;
							}
							text = string.Format(Messages.msgErrorInSendPordToAccLinkNotSelectedItem, cRMspLkWSSelectPreOrderById_Result.pordNumber, rayvarz, Labels.lblWareHouse) + "|";
							return text;
						}
						string text8 = "";
						long result8 = 0L;
						long result9 = 0L;
						CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(cRMspLkWSSelectPreOrderById_Result.pordCompanyId.GetValueOrDefault());
						if (companyById == null)
						{
							text = Messages.CompanyNotFound + "|";
							return text;
						}
						text8 = companyById.cmpLinkAccCustomerIdStr ?? "";
						if (!string.IsNullOrWhiteSpace(companyById.LinkAccGroupIdStr))
						{
							long.TryParse(companyById.LinkAccGroupIdStr, out result8);
						}
						if (!string.IsNullOrWhiteSpace(companyById.cmpLinkAccData))
						{
							List<LinkAccDataViewModel> list3 = new JavaScriptSerializer().Deserialize<List<LinkAccDataViewModel>>(companyById.cmpLinkAccData);
							if (list3 != null && Enumerable.Any<LinkAccDataViewModel>((IEnumerable<LinkAccDataViewModel>)list3))
							{
								LinkAccDataViewModel linkAccDataViewModel = Enumerable.FirstOrDefault<LinkAccDataViewModel>((IEnumerable<LinkAccDataViewModel>)list3);
								if (linkAccDataViewModel != null)
								{
									long.TryParse(linkAccDataViewModel.LACId, out result9);
								}
							}
						}
						if (string.IsNullOrWhiteSpace(text8))
						{
							string text9 = new CompanyController().RayvarzActCmpSendToAcc(cRMspLkWSSelectPreOrderById_Result.pordCompanyId.GetValueOrDefault(), checkAction: false);
							if (string.IsNullOrEmpty(text9))
							{
								text = Messages.msgErrorRunFunction + "(insert company to rayvarz)|";
								return text;
							}
							string[] array2 = text9.Split(new char[1] { '|' });
							if (array2 != null)
							{
								if (!(array2[0] == "1"))
								{
									text = array2[0] + "|";
									return text;
								}
								companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(cRMspLkWSSelectPreOrderById_Result.pordCompanyId.GetValueOrDefault());
								if (companyById == null)
								{
									text = Messages.CompanyNotFound + "|";
									return text;
								}
								text8 = companyById.cmpLinkAccCustomerIdStr ?? "";
								if (!string.IsNullOrWhiteSpace(companyById.LinkAccGroupIdStr))
								{
									long.TryParse(companyById.LinkAccGroupIdStr, out result8);
								}
								if (!string.IsNullOrWhiteSpace(companyById.cmpLinkAccData))
								{
									List<LinkAccDataViewModel> list4 = new JavaScriptSerializer().Deserialize<List<LinkAccDataViewModel>>(companyById.cmpLinkAccData);
									if (list4 != null && Enumerable.Any<LinkAccDataViewModel>((IEnumerable<LinkAccDataViewModel>)list4))
									{
										LinkAccDataViewModel linkAccDataViewModel2 = Enumerable.FirstOrDefault<LinkAccDataViewModel>((IEnumerable<LinkAccDataViewModel>)list4);
										if (linkAccDataViewModel2 != null)
										{
											long.TryParse(linkAccDataViewModel2.LACId, out result9);
										}
									}
								}
							}
						}
						if (string.IsNullOrWhiteSpace(text8))
						{
							text = string.Format(Messages.msgErrorInSendToAccLinkNotFoundCmpInAcc, rayvarz);
							return text;
						}
						DateTime dateTime = default(DateTime);
						string text10 = "";
						try
						{
							if (cRMspLkWSSelectPreOrderById_Result.pordDateTime.HasValue)
							{
								text10 = cRMspLkWSSelectPreOrderById_Result.pordDateTime.Value.ToString("yyyyMMdd", new PersianCulture());
							}
							else if (!string.IsNullOrWhiteSpace(cRMspLkWSSelectPreOrderById_Result.pordDate))
							{
								text10 = DateTime.Parse(PersianDate.GetFormatetdDate(cRMspLkWSSelectPreOrderById_Result.pordDate.Replace("/", "")) + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")).ToString("yyyyMMdd", new PersianCulture());
							}
						}
						catch (Exception e)
						{
							ErrorSignal.FromCurrentContext().Raise(e);
							text = string.Format(Messages.ErrorInFormat, Labels.pordDate);
							return text;
						}
						RayvarzSalesIssueDefineViewModel rayvarzSalesIssueDefineViewModel = new RayvarzSalesIssueDefineViewModel();
						rayvarzSalesIssueDefineViewModel.salesJournalItems = new List<RayvarzSalesIssueItemDefineViewModel>();
						decimal value5 = default(decimal);
						decimal value6 = default(decimal);
						if (list != null && Enumerable.Any<CRMspLkWSSelectPreOrderItems_Result>((IEnumerable<CRMspLkWSSelectPreOrderItems_Result>)list))
						{
							int num9 = 1;
							foreach (CRMspLkWSSelectPreOrderItems_Result item in list)
							{
								RayvarzSalesIssueItemDefineViewModel rayvarzSalesIssueItemDefineViewModel = new RayvarzSalesIssueItemDefineViewModel();
								string text11 = item.PrdLinkAccPrdIdStr ?? "";
								_ = item.PrdLinkAccPrdCode;
								string s = item.UnitLinkAccUnitIdStr ?? "0";
								string text12 = item.UnitLinkAccUnitIdStrI ?? "0";
								string text13 = item.SGLinkAccGroupIdStr ?? "";
								string text14 = "";
								if (item.pordIWHId.HasValue)
								{
									string text15 = "";
									if (wrhsSyncTypeId == 2 && !string.IsNullOrWhiteSpace(item.pordILinkAccWHIdStr))
									{
										if (!string.IsNullOrWhiteSpace(item.WrhsLinkAccWareHouses))
										{
											List<CommonWithIdStrViewModel> list5 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(item.WrhsLinkAccWareHouses);
											if (list5 != null && list5.Count > 0)
											{
												CommonWithIdStrViewModel commonWithIdStrViewModel2 = Enumerable.FirstOrDefault<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list5, (Func<CommonWithIdStrViewModel, bool>)((CommonWithIdStrViewModel x) => x.Id == item.pordILinkAccWHIdStr));
												if (commonWithIdStrViewModel2 != null)
												{
													_ = commonWithIdStrViewModel2.Name;
													text15 = commonWithIdStrViewModel2.Id;
												}
											}
										}
									}
									else
									{
										text15 = item.WrhsLinkAccWhIdStr;
										_ = item.pordIWrhsName;
									}
									if (!string.IsNullOrWhiteSpace(text15))
									{
										text14 = text15;
									}
								}
								if (string.IsNullOrWhiteSpace(rayvarzSalesIssueDefineViewModel.warehouseId) && !string.IsNullOrWhiteSpace(text14))
								{
									rayvarzSalesIssueDefineViewModel.warehouseId = text14;
								}
								if (!string.IsNullOrWhiteSpace(text11))
								{
									double result10 = item.pordIQuantity.GetValueOrDefault(1.0) * item.pordIFCR.GetValueOrDefault(1.0) * item.pordIFCRI.GetValueOrDefault(1.0);
									double num10 = item.pordIPrdUnitIRateResult.GetValueOrDefault() * item.pordIFCR.GetValueOrDefault(1.0) * item.pordIFCRI.GetValueOrDefault(1.0);
									num10 = 0.0;
									decimal num11 = item.pordIPrice.GetValueOrDefault() * (decimal)result10;
									value6 += num11;
									value5 += item.pordIPriceSum.GetValueOrDefault();
									string text16 = "";
									if (!string.IsNullOrWhiteSpace(item.pordILinkAccData))
									{
										List<PordItemLinkAccDataByExtraViewModel> list6 = new JavaScriptSerializer().Deserialize<List<PordItemLinkAccDataByExtraViewModel>>(item.pordILinkAccData);
										if (list6 != null && Enumerable.Any<PordItemLinkAccDataByExtraViewModel>((IEnumerable<PordItemLinkAccDataByExtraViewModel>)list6))
										{
											PordItemLinkAccDataByExtraViewModel pordItemLinkAccDataByExtraViewModel = Enumerable.FirstOrDefault<PordItemLinkAccDataByExtraViewModel>((IEnumerable<PordItemLinkAccDataByExtraViewModel>)list6);
											if (pordItemLinkAccDataByExtraViewModel != null)
											{
												text16 = pordItemLinkAccDataByExtraViewModel.ExtraField ?? "";
											}
										}
									}
									if (string.IsNullOrWhiteSpace(text16))
									{
										text16 = Guid.NewGuid().ToString();
									}
									long result11 = 0L;
									if (!string.IsNullOrWhiteSpace(text12) && text12 != "0")
									{
										long.TryParse(text12, out result11);
									}
									long result12 = 0L;
									long.TryParse(s, out result12);
									if (result11 == 0L)
									{
										result11 = result12;
									}
									double valueOrDefault = item.PrdUnitIRate.GetValueOrDefault();
									double num12 = result10;
									if (result11 != 0L)
									{
										string[] array3 = result10.ToString().Split(new char[1] { '.' });
										if (array3 != null && array3.Length > 1)
										{
											double.TryParse(array3[0], out result10);
											double.TryParse("0." + array3[1], out num10);
											if (valueOrDefault != 0.0)
											{
												num10 *= valueOrDefault;
											}
										}
									}
									else
									{
										num10 = 0.0;
									}
									if (result11 == 0L)
									{
										result11 = result12;
									}
									if (result11 == result12)
									{
										num10 = 0.0;
									}
									decimal num13 = (decimal)num10;
									rayvarzSalesIssueItemDefineViewModel.isValidationsApplied = false;
									rayvarzSalesIssueItemDefineViewModel.isDataFast = false;
									if (!string.IsNullOrWhiteSpace(item.pordILinkAccItemIdStr))
									{
										rayvarzSalesIssueItemDefineViewModel.state = 16L;
										long result13 = 0L;
										long.TryParse(item.pordILinkAccItemIdStr, out result13);
										rayvarzSalesIssueItemDefineViewModel.salesJournalItemId = result13;
									}
									else
									{
										rayvarzSalesIssueItemDefineViewModel.state = 4L;
									}
									rayvarzSalesIssueItemDefineViewModel.lastState = 0L;
									rayvarzSalesIssueItemDefineViewModel.adjustTotalQtyDescription = default(decimal);
									rayvarzSalesIssueItemDefineViewModel.adjustPartialQtyDescription = default(decimal);
									rayvarzSalesIssueItemDefineViewModel.adjustmentUnitPricePer = default(decimal);
									rayvarzSalesIssueItemDefineViewModel.adjustmentUnitPriceDifferent = default(decimal);
									rayvarzSalesIssueItemDefineViewModel.inventoryConvertQty = default(decimal);
									rayvarzSalesIssueItemDefineViewModel.row = num9;
									rayvarzSalesIssueItemDefineViewModel.itemDataId = text11;
									rayvarzSalesIssueItemDefineViewModel.partialQty = num13;
									rayvarzSalesIssueItemDefineViewModel.partialQtyUnitId = ((result11 != 0L) ? new long?(result11) : null);
									rayvarzSalesIssueItemDefineViewModel.totalQty = (decimal)result10;
									rayvarzSalesIssueItemDefineViewModel.totalQtyUnitId = ((result12 != 0L) ? new long?(result12) : null);
									rayvarzSalesIssueItemDefineViewModel.partialQtySum = ((num13 > 0m) ? num13 : 0m);
									rayvarzSalesIssueItemDefineViewModel.unitAmount = item.pordIPrice.GetValueOrDefault();
									rayvarzSalesIssueItemDefineViewModel.totalAmount = num11;
									rayvarzSalesIssueItemDefineViewModel.rialEquivalent = num11;
									rayvarzSalesIssueItemDefineViewModel.discountPercent = item.pordIDiscountPercent.GetValueOrDefault();
									rayvarzSalesIssueItemDefineViewModel.perDiscountUnitRate = item.pordIDiscount.GetValueOrDefault();
									rayvarzSalesIssueItemDefineViewModel.discountAmount = item.pordIDiscountSum.GetValueOrDefault();
									rayvarzSalesIssueItemDefineViewModel.discountAmountEquivalentRial = item.pordIDiscountSum.GetValueOrDefault();
									rayvarzSalesIssueItemDefineViewModel.totalTollAmount = item.pordITaxSum.GetValueOrDefault();
									rayvarzSalesIssueItemDefineViewModel.totalTollAmountEquivalentRial = item.pordITaxSum.GetValueOrDefault();
									rayvarzSalesIssueItemDefineViewModel.preReceive = default(decimal);
									rayvarzSalesIssueItemDefineViewModel.totalWeight = (decimal)num12;
									rayvarzSalesIssueItemDefineViewModel.unitWeightId = ((result12 != 0L) ? new long?(result12) : null);
									rayvarzSalesIssueItemDefineViewModel.afterDiscountDeduct = item.pordITotalPrice.GetValueOrDefault();
									rayvarzSalesIssueItemDefineViewModel.discountTypeId = ((num4 != 0L) ? new long?(num4) : null);
									rayvarzSalesIssueItemDefineViewModel.salesTypeId = num2;
									rayvarzSalesIssueItemDefineViewModel.receiveTypeId = num3;
									rayvarzSalesIssueItemDefineViewModel.userEnteredWeight = default(decimal);
									rayvarzSalesIssueItemDefineViewModel.buyerId = text8;
									rayvarzSalesIssueItemDefineViewModel.isPrize = 0L;
									rayvarzSalesIssueItemDefineViewModel.customerCreditDiscount = default(decimal);
									rayvarzSalesIssueItemDefineViewModel.salesJournalId = ((result7 != 0L) ? new long?(result7) : null);
									rayvarzSalesIssueItemDefineViewModel.payableAmount = item.pordITotalPrice.GetValueOrDefault();
									rayvarzSalesIssueItemDefineViewModel.itemGroupId = ((!string.IsNullOrWhiteSpace(text13) && text13 != "0") ? text13 : null);
									rayvarzSalesIssueItemDefineViewModel.buyerCenterId = ((result9 != 0L) ? new long?(result9) : null);
									rayvarzSalesIssueItemDefineViewModel.salesFiscalYearId = fiscalYearId;
									rayvarzSalesIssueItemDefineViewModel.docDate = text10;
									rayvarzSalesIssueItemDefineViewModel.salesDocTypeId = num5;
									rayvarzSalesIssueItemDefineViewModel.warehouseId = text14;
									rayvarzSalesIssueItemDefineViewModel.isCanceled = 0L;
									rayvarzSalesIssueItemDefineViewModel.adjustTotalQty = default(decimal);
									rayvarzSalesIssueItemDefineViewModel.adjustPartialQty = default(decimal);
									rayvarzSalesIssueItemDefineViewModel.adjustmentalUnitAmount = default(decimal);
									rayvarzSalesIssueItemDefineViewModel.consumedTotalQty = default(decimal);
									rayvarzSalesIssueItemDefineViewModel.consumedPartialQty = default(decimal);
									rayvarzSalesIssueItemDefineViewModel.returnReasonId = ((num6 != 0L) ? new long?(num6) : null);
									rayvarzSalesIssueItemDefineViewModel.pourcentage = default(decimal);
									rayvarzSalesIssueItemDefineViewModel.payablePrcWithOutEffect = default(decimal);
									rayvarzSalesIssueItemDefineViewModel.isChange = false;
									rayvarzSalesIssueItemDefineViewModel.docNo = 0L;
									rayvarzSalesIssueItemDefineViewModel.description = item.pordIDescription ?? "";
									rayvarzSalesIssueItemDefineViewModel.rayGuid = text16;
									rayvarzSalesIssueItemDefineViewModel.hasMetadata = true;
									rayvarzSalesIssueItemDefineViewModel.hasErrors = false;
									rayvarzSalesIssueItemDefineViewModel.disposing = false;
									if (item.pordIDiscountSum.GetValueOrDefault() > 0m)
									{
										rayvarzSalesIssueDefineViewModel.hasDiscount = 1L;
									}
									rayvarzSalesIssueItemDefineViewModel.CrmOrdItemId = item.PreOrderItemID;
									rayvarzSalesIssueDefineViewModel.salesJournalItems.Add(rayvarzSalesIssueItemDefineViewModel);
									num9++;
									continue;
								}
								text = Messages.msgErrorRunFunction + " (Error in create json)|";
								return text;
							}
						}
						if (rayvarzSalesIssueDefineViewModel.salesJournalItems == null || !Enumerable.Any<RayvarzSalesIssueItemDefineViewModel>((IEnumerable<RayvarzSalesIssueItemDefineViewModel>)rayvarzSalesIssueDefineViewModel.salesJournalItems))
						{
							text = Messages.ErrorNotFound + "|";
							return text;
						}
						rayvarzSalesIssueDefineViewModel.isValidationsApplied = false;
						if (result7 != 0L)
						{
							rayvarzSalesIssueDefineViewModel.state = 16;
							rayvarzSalesIssueDefineViewModel.salesJournalId = result7;
						}
						else
						{
							rayvarzSalesIssueDefineViewModel.state = 4;
						}
						rayvarzSalesIssueDefineViewModel.lastState = 0;
						rayvarzSalesIssueDefineViewModel.webDocTypeId = num;
						long result14 = 0L;
						long.TryParse(cRMspLkWSSelectPreOrderById_Result.pordLinkAccPreOrderNumber, out result14);
						if (result14 != 0L)
						{
							rayvarzSalesIssueDefineViewModel.proFormaDocNo = result14;
						}
						rayvarzSalesIssueDefineViewModel.deliveryDocNo = 0L;
						rayvarzSalesIssueDefineViewModel.salesFiscalYearId = fiscalYearId;
						string s2 = "";
						if (!string.IsNullOrWhiteSpace(cRMspLkWSSelectPreOrderById_Result.pordLinkAccData))
						{
							List<PordLinkAccDataByVoucherAndExtraViewModel> list7 = new JavaScriptSerializer().Deserialize<List<PordLinkAccDataByVoucherAndExtraViewModel>>(cRMspLkWSSelectPreOrderById_Result.pordLinkAccData);
							if (list7 != null && Enumerable.Any<PordLinkAccDataByVoucherAndExtraViewModel>((IEnumerable<PordLinkAccDataByVoucherAndExtraViewModel>)list7))
							{
								PordLinkAccDataByVoucherAndExtraViewModel pordLinkAccDataByVoucherAndExtraViewModel = Enumerable.FirstOrDefault<PordLinkAccDataByVoucherAndExtraViewModel>((IEnumerable<PordLinkAccDataByVoucherAndExtraViewModel>)list7);
								if (pordLinkAccDataByVoucherAndExtraViewModel != null)
								{
									s2 = pordLinkAccDataByVoucherAndExtraViewModel.VoucherNumber ?? "";
								}
							}
						}
						long result15 = 0L;
						long.TryParse(s2, out result15);
						if (result15 != 0L)
						{
							rayvarzSalesIssueDefineViewModel.docNo = result15;
						}
						rayvarzSalesIssueDefineViewModel.docDate = text10;
						rayvarzSalesIssueDefineViewModel.numberOfNextStepDoc = 0L;
						rayvarzSalesIssueDefineViewModel.customerId = text8;
						rayvarzSalesIssueDefineViewModel.isCancel = 0L;
						rayvarzSalesIssueDefineViewModel.voucherRunNo = 0L;
						rayvarzSalesIssueDefineViewModel.discountTypeId = num4;
						rayvarzSalesIssueDefineViewModel.salesTypeId = num2;
						rayvarzSalesIssueDefineViewModel.receiveTypeId = num3;
						rayvarzSalesIssueDefineViewModel.dailyCurrencyRate = 1;
						rayvarzSalesIssueDefineViewModel.userId = text2;
						rayvarzSalesIssueDefineViewModel.buyerId = text8;
						rayvarzSalesIssueDefineViewModel.totalDocAmount = value6;
						rayvarzSalesIssueDefineViewModel.totalDocAmountEquivalentRial = value6;
						rayvarzSalesIssueDefineViewModel.totalDiscountAmount = cRMspLkWSSelectPreOrderById_Result.pordItemsDiscount.GetValueOrDefault() + cRMspLkWSSelectPreOrderById_Result.pordDiscount.GetValueOrDefault();
						rayvarzSalesIssueDefineViewModel.totalDiscountAmountEquivalentRial = rayvarzSalesIssueDefineViewModel.totalDiscountAmount;
						rayvarzSalesIssueDefineViewModel.totalAmountAfterDiscountDeduct = value5;
						rayvarzSalesIssueDefineViewModel.totalTollAmount = cRMspLkWSSelectPreOrderById_Result.pordItemsTax.GetValueOrDefault() + cRMspLkWSSelectPreOrderById_Result.pordTax.GetValueOrDefault();
						rayvarzSalesIssueDefineViewModel.totalTollAmountEquivalentRial = cRMspLkWSSelectPreOrderById_Result.pordItemsTax.GetValueOrDefault() + cRMspLkWSSelectPreOrderById_Result.pordTax.GetValueOrDefault();
						rayvarzSalesIssueDefineViewModel.totalPreReceiveAmount = default(decimal);
						rayvarzSalesIssueDefineViewModel.totalPayableAmount = cRMspLkWSSelectPreOrderById_Result.pordTotalAmount.GetValueOrDefault();
						rayvarzSalesIssueDefineViewModel.currencyId = text3;
						rayvarzSalesIssueDefineViewModel.isRemainedDoc = 0L;
						rayvarzSalesIssueDefineViewModel.sendToWarehouse = 0L;
						rayvarzSalesIssueDefineViewModel.customerGroupId = ((result8 != 0L) ? new long?(result8) : null);
						rayvarzSalesIssueDefineViewModel.buyerGroupId = rayvarzSalesIssueDefineViewModel.customerGroupId;
						rayvarzSalesIssueDefineViewModel.buyerCenterId = ((result9 != 0L) ? new long?(result9) : null);
						rayvarzSalesIssueDefineViewModel.customerCenterId = result9;
						rayvarzSalesIssueDefineViewModel.beforeYearTrnsfer = 0L;
						rayvarzSalesIssueDefineViewModel.nextYearTransfer = 0L;
						rayvarzSalesIssueDefineViewModel.endSalesCycle = 0L;
						rayvarzSalesIssueDefineViewModel.previousStepDocId = 0L;
						rayvarzSalesIssueDefineViewModel.salesDocProduceTypeId = num7;
						rayvarzSalesIssueDefineViewModel.parentIssueDocId = 0L;
						rayvarzSalesIssueDefineViewModel.parentDeliveryDocId = 0L;
						rayvarzSalesIssueDefineViewModel.issueDocDate = text10;
						rayvarzSalesIssueDefineViewModel.parentDocNo = 0L;
						rayvarzSalesIssueDefineViewModel.invoiceDocNo = 0L;
						rayvarzSalesIssueDefineViewModel.parentFactorId = 0L;
						rayvarzSalesIssueDefineViewModel.totalCreditDiscountAmount = default(decimal);
						rayvarzSalesIssueDefineViewModel.branchId = result3;
						rayvarzSalesIssueDefineViewModel.sendSms = 0L;
						rayvarzSalesIssueDefineViewModel.hasMetadata = true;
						rayvarzSalesIssueDefineViewModel.hasErrors = false;
						rayvarzSalesIssueDefineViewModel.disposing = false;
						rayvarzSalesIssueDefineViewModel.contractNo2 = cRMspLkWSSelectPreOrderById_Result.pordNumber.ToString();
						rayvarzSalesIssueDefineViewModel.proFormaId = 0L;
						if (!string.IsNullOrWhiteSpace(cRMspLkWSSelectPreOrderById_Result.pordLinkAccData))
						{
							List<PordLinkAccDataByVoucherAndExtraViewModel> list8 = new JavaScriptSerializer().Deserialize<List<PordLinkAccDataByVoucherAndExtraViewModel>>(cRMspLkWSSelectPreOrderById_Result.pordLinkAccData);
							if (list8 != null && Enumerable.Any<PordLinkAccDataByVoucherAndExtraViewModel>((IEnumerable<PordLinkAccDataByVoucherAndExtraViewModel>)list8))
							{
								PordLinkAccDataByVoucherAndExtraViewModel pordLinkAccDataByVoucherAndExtraViewModel2 = Enumerable.FirstOrDefault<PordLinkAccDataByVoucherAndExtraViewModel>((IEnumerable<PordLinkAccDataByVoucherAndExtraViewModel>)list8);
								if (pordLinkAccDataByVoucherAndExtraViewModel2 != null)
								{
									rayvarzSalesIssueDefineViewModel.rayGuid = pordLinkAccDataByVoucherAndExtraViewModel2.ExtraField ?? "";
								}
							}
						}
						if (!string.IsNullOrWhiteSpace(text5))
						{
							rayvarzSalesIssueDefineViewModel.contractNo = text5;
						}
						RayvarzProformaDefineViewModel rayvarzProformaDefineViewModel = new RayvarzProformaDefineViewModel();
						rayvarzProformaDefineViewModel.salesJournalItems = new List<RayvarzProformaItemDefineViewModel>();
						if (pordLinkedToAccApiMode == 2)
						{
							if (rayvarzSalesIssueDefineViewModel.salesJournalItems != null && Enumerable.Any<RayvarzSalesIssueItemDefineViewModel>((IEnumerable<RayvarzSalesIssueItemDefineViewModel>)rayvarzSalesIssueDefineViewModel.salesJournalItems))
							{
								foreach (RayvarzSalesIssueItemDefineViewModel salesJournalItem in rayvarzSalesIssueDefineViewModel.salesJournalItems)
								{
									RayvarzProformaItemDefineViewModel rayvarzProformaItemDefineViewModel = new RayvarzProformaItemDefineViewModel
									{
										isValidationsApplied = salesJournalItem.isValidationsApplied,
										isDataFast = salesJournalItem.isDataFast,
										partialAmount = salesJournalItem.partialAmount,
										adjustTotalQtyDescription = salesJournalItem.adjustTotalQtyDescription,
										adjustPartialQtyDescription = salesJournalItem.adjustPartialQtyDescription,
										adjustmentUnitPricePer = salesJournalItem.adjustmentUnitPricePer,
										adjustmentUnitPriceDifferent = salesJournalItem.adjustmentUnitPriceDifferent,
										inventoryConvertQty = salesJournalItem.inventoryConvertQty,
										row = salesJournalItem.row,
										itemDataId = salesJournalItem.itemDataId,
										itemData = salesJournalItem.itemData,
										serialNo = salesJournalItem.serialNo,
										partialQty = salesJournalItem.partialQty,
										partialQtyUnitId = ((salesJournalItem.partialQtyUnitId.GetValueOrDefault() != 0L) ? salesJournalItem.partialQtyUnitId.GetValueOrDefault().ToString() : null),
										partialQtyUnit = salesJournalItem.partialQtyUnit,
										totalQty = salesJournalItem.totalQty,
										totalQtyUnitId = ((salesJournalItem.totalQtyUnitId.GetValueOrDefault() != 0L) ? salesJournalItem.totalQtyUnitId.GetValueOrDefault().ToString() : null),
										totalQtyUnit = salesJournalItem.totalQtyUnit,
										unitAmount = salesJournalItem.unitAmount,
										totalAmount = salesJournalItem.totalAmount,
										rialEquivalent = salesJournalItem.rialEquivalent,
										discountPercent = salesJournalItem.discountPercent,
										perDiscountUnitRate = salesJournalItem.perDiscountUnitRate,
										discountAmount = salesJournalItem.discountAmount,
										discountAmountEquivalentRial = salesJournalItem.discountAmountEquivalentRial,
										discountComputeStyle = salesJournalItem.discountComputeStyle,
										totalTollAmount = salesJournalItem.totalTollAmount,
										totalTollAmountEquivalentRial = salesJournalItem.totalTollAmountEquivalentRial,
										preReceive = salesJournalItem.preReceive,
										preReceivePercent = salesJournalItem.preReceivePercent,
										totalWeight = salesJournalItem.totalWeight,
										unitWeightId = ((salesJournalItem.unitWeightId.GetValueOrDefault() != 0L) ? salesJournalItem.unitWeightId.GetValueOrDefault().ToString() : null),
										unitWeight = salesJournalItem.unitWeight,
										afterDiscountDeduct = salesJournalItem.afterDiscountDeduct,
										discountTypeId = salesJournalItem.discountTypeId,
										discountType = salesJournalItem.discountType,
										salesTypeId = salesJournalItem.salesTypeId,
										salesType = salesJournalItem.salesType,
										receiveTypeId = salesJournalItem.receiveTypeId,
										receiveType = salesJournalItem.receiveType,
										userEnteredWeight = salesJournalItem.userEnteredWeight,
										buyerId = salesJournalItem.buyerId,
										buyer = salesJournalItem.buyer,
										isPrize = salesJournalItem.isPrize,
										discountTemplateId = salesJournalItem.discountTemplateId,
										unitPriceTemplateId = salesJournalItem.unitPriceTemplateId,
										unitPriceTemplate = salesJournalItem.unitPriceTemplate,
										previousSalesJournalItemId = salesJournalItem.previousSalesJournalItemId,
										previousSalesJournalItem = salesJournalItem.previousSalesJournalItem,
										customerCreditDiscount = salesJournalItem.customerCreditDiscount,
										salesJournalId = salesJournalItem.salesJournalId,
										payableAmount = salesJournalItem.payableAmount,
										itemGroupId = salesJournalItem.itemGroupId,
										itemGroup = salesJournalItem.itemGroup,
										centerId = result9,
										center = null,
										buyerCenterId = salesJournalItem.buyerCenterId,
										buyerCenter = salesJournalItem.buyerCenter,
										salesFiscalYearId = salesJournalItem.salesFiscalYearId,
										salesFiscalYear = salesJournalItem.salesFiscalYear,
										docDate = salesJournalItem.docDate,
										salesDocTypeId = salesJournalItem.salesDocTypeId,
										salesDocType = salesJournalItem.salesDocType,
										warehouseId = salesJournalItem.warehouseId,
										warehouse = salesJournalItem.warehouse,
										isCanceled = salesJournalItem.isCanceled,
										adjustTotalQty = salesJournalItem.adjustTotalQty,
										adjustPartialQty = salesJournalItem.adjustPartialQty,
										adjustmentalUnitAmount = salesJournalItem.adjustmentalUnitAmount,
										consumedTotalQty = salesJournalItem.consumedTotalQty,
										consumedPartialQty = salesJournalItem.consumedPartialQty,
										returnReasonId = salesJournalItem.returnReasonId,
										returnReason = salesJournalItem.returnReason,
										adjustmentReasonId = salesJournalItem.adjustmentReasonId,
										adjustmentReason = salesJournalItem.adjustmentReason,
										pourcentage = salesJournalItem.pourcentage,
										commissionPercent = salesJournalItem.commissionPercent,
										payablePrcWithOutEffect = salesJournalItem.payablePrcWithOutEffect,
										rayGuid = salesJournalItem.rayGuid,
										salesJournalItemAdjectives = salesJournalItem.salesJournalItemAdjectives,
										deliveryDocNo = salesJournalItem.deliveryDocNo,
										salesErrorMessage = salesJournalItem.salesErrorMessage,
										docNo = salesJournalItem.docNo,
										description = salesJournalItem.description,
										technicalNo = salesJournalItem.technicalNo,
										state = salesJournalItem.state,
										lastState = salesJournalItem.lastState,
										backupOriginalData = salesJournalItem.backupOriginalData,
										rayValidationResults = salesJournalItem.rayValidationResults,
										validationErrors = salesJournalItem.validationErrors,
										validationErrorsMessages = salesJournalItem.validationErrorsMessages,
										metadataRaySystemId = salesJournalItem.metadataRaySystemId,
										hasMetadata = salesJournalItem.hasMetadata,
										modifiedProperties = salesJournalItem.modifiedProperties,
										hasErrors = salesJournalItem.hasErrors,
										disposing = salesJournalItem.disposing,
										CrmOrdItemId = salesJournalItem.CrmOrdItemId
									};
									if (rayvarzProformaItemDefineViewModel.discountAmount.GetValueOrDefault() == 0m)
									{
										rayvarzProformaItemDefineViewModel.discountTypeId = null;
										rayvarzProformaItemDefineViewModel.discountType = null;
									}
									rayvarzProformaDefineViewModel.salesJournalItems.Add(rayvarzProformaItemDefineViewModel);
								}
							}
							if (rayvarzSalesIssueDefineViewModel != null)
							{
								rayvarzProformaDefineViewModel.issueDocNo = rayvarzSalesIssueDefineViewModel.issueDocNo.GetValueOrDefault();
								rayvarzProformaDefineViewModel.deliveryDocNo = rayvarzSalesIssueDefineViewModel.deliveryDocNo;
								rayvarzProformaDefineViewModel.salesFiscalYearId = rayvarzSalesIssueDefineViewModel.salesFiscalYearId;
								rayvarzProformaDefineViewModel.salesFiscalYear = rayvarzSalesIssueDefineViewModel.salesFiscalYear;
								rayvarzProformaDefineViewModel.warehouseId = rayvarzSalesIssueDefineViewModel.warehouseId;
								rayvarzProformaDefineViewModel.warehouse = rayvarzSalesIssueDefineViewModel.warehouse;
								rayvarzProformaDefineViewModel.docDate = rayvarzSalesIssueDefineViewModel.docDate;
								rayvarzProformaDefineViewModel.numberOfNextStepDoc = rayvarzSalesIssueDefineViewModel.numberOfNextStepDoc;
								rayvarzProformaDefineViewModel.contractNo = rayvarzSalesIssueDefineViewModel.contractNo;
								rayvarzProformaDefineViewModel.customerId = rayvarzSalesIssueDefineViewModel.customerId;
								rayvarzProformaDefineViewModel.customer = rayvarzSalesIssueDefineViewModel.customer;
								rayvarzProformaDefineViewModel.isCancel = rayvarzSalesIssueDefineViewModel.isCancel;
								rayvarzProformaDefineViewModel.voucherRunNo = rayvarzSalesIssueDefineViewModel.voucherRunNo;
								rayvarzProformaDefineViewModel.discountTypeId = rayvarzSalesIssueDefineViewModel.discountTypeId;
								rayvarzProformaDefineViewModel.discountType = rayvarzSalesIssueDefineViewModel.discountType;
								rayvarzProformaDefineViewModel.hasDiscount = rayvarzSalesIssueDefineViewModel.hasDiscount;
								rayvarzProformaDefineViewModel.salesTypeId = rayvarzSalesIssueDefineViewModel.salesTypeId;
								rayvarzProformaDefineViewModel.salesType = rayvarzSalesIssueDefineViewModel.salesType;
								rayvarzProformaDefineViewModel.receiveTypeId = rayvarzSalesIssueDefineViewModel.receiveTypeId;
								rayvarzProformaDefineViewModel.receiveType = rayvarzSalesIssueDefineViewModel.receiveType;
								rayvarzProformaDefineViewModel.dailyCurrencyRate = rayvarzSalesIssueDefineViewModel.dailyCurrencyRate;
								rayvarzProformaDefineViewModel.currencyRateDate = rayvarzSalesIssueDefineViewModel.currencyRateDate;
								rayvarzProformaDefineViewModel.userId = rayvarzSalesIssueDefineViewModel.userId;
								rayvarzProformaDefineViewModel.user = rayvarzSalesIssueDefineViewModel.user;
								rayvarzProformaDefineViewModel.buyerId = rayvarzSalesIssueDefineViewModel.buyerId;
								rayvarzProformaDefineViewModel.buyer = rayvarzSalesIssueDefineViewModel.buyer;
								rayvarzProformaDefineViewModel.totalDocAmount = rayvarzSalesIssueDefineViewModel.totalDocAmount;
								rayvarzProformaDefineViewModel.totalDocAmountEquivalentRial = rayvarzSalesIssueDefineViewModel.totalDocAmountEquivalentRial;
								rayvarzProformaDefineViewModel.totalDiscountAmount = rayvarzSalesIssueDefineViewModel.totalDiscountAmount;
								rayvarzProformaDefineViewModel.totalDiscountAmountEquivalentRial = rayvarzSalesIssueDefineViewModel.totalDiscountAmountEquivalentRial;
								rayvarzProformaDefineViewModel.totalAmountAfterDiscountDeduct = rayvarzSalesIssueDefineViewModel.totalAmountAfterDiscountDeduct;
								rayvarzProformaDefineViewModel.totalTollAmount = rayvarzSalesIssueDefineViewModel.totalTollAmount;
								rayvarzProformaDefineViewModel.totalTollAmountEquivalentRial = rayvarzSalesIssueDefineViewModel.totalTollAmountEquivalentRial;
								rayvarzProformaDefineViewModel.totalPreReceiveAmount = rayvarzSalesIssueDefineViewModel.totalPreReceiveAmount;
								rayvarzProformaDefineViewModel.totalCommissionAmount = rayvarzSalesIssueDefineViewModel.totalCommissionAmount;
								rayvarzProformaDefineViewModel.totalPayableAmount = rayvarzSalesIssueDefineViewModel.totalPayableAmount;
								rayvarzProformaDefineViewModel.currencyId = rayvarzSalesIssueDefineViewModel.currencyId;
								rayvarzProformaDefineViewModel.currency = rayvarzSalesIssueDefineViewModel.currency;
								rayvarzProformaDefineViewModel.isRemainedDoc = rayvarzSalesIssueDefineViewModel.isRemainedDoc;
								rayvarzProformaDefineViewModel.receiptDate = rayvarzSalesIssueDefineViewModel.receiptDate;
								rayvarzProformaDefineViewModel.receiptPeriod = rayvarzSalesIssueDefineViewModel.receiptPeriod;
								rayvarzProformaDefineViewModel.salesConfirmLevelId = rayvarzSalesIssueDefineViewModel.salesConfirmLevelId;
								rayvarzProformaDefineViewModel.salesConfirmLevel = rayvarzSalesIssueDefineViewModel.salesConfirmLevel;
								rayvarzProformaDefineViewModel.sendToWarehouse = rayvarzSalesIssueDefineViewModel.sendToWarehouse;
								rayvarzProformaDefineViewModel.customerGroupId = rayvarzSalesIssueDefineViewModel.customerGroupId;
								rayvarzProformaDefineViewModel.customerGroup = rayvarzSalesIssueDefineViewModel.customerGroup;
								rayvarzProformaDefineViewModel.buyerGroupId = rayvarzSalesIssueDefineViewModel.buyerGroupId;
								rayvarzProformaDefineViewModel.buyerGroup = rayvarzSalesIssueDefineViewModel.buyerGroup;
								rayvarzProformaDefineViewModel.buyerCenterId = rayvarzSalesIssueDefineViewModel.buyerCenterId;
								rayvarzProformaDefineViewModel.buyerCenter = rayvarzSalesIssueDefineViewModel.buyerCenter;
								rayvarzProformaDefineViewModel.customerCenterId = rayvarzSalesIssueDefineViewModel.customerCenterId;
								rayvarzProformaDefineViewModel.customerCenter = rayvarzSalesIssueDefineViewModel.customerCenter;
								rayvarzProformaDefineViewModel.beforeYearTrnsfer = rayvarzSalesIssueDefineViewModel.beforeYearTrnsfer;
								rayvarzProformaDefineViewModel.nextYearTransfer = rayvarzSalesIssueDefineViewModel.nextYearTransfer;
								rayvarzProformaDefineViewModel.endSalesCycle = rayvarzSalesIssueDefineViewModel.endSalesCycle;
								rayvarzProformaDefineViewModel.previousStepDocId = rayvarzSalesIssueDefineViewModel.previousStepDocId;
								rayvarzProformaDefineViewModel.quotaGroup = rayvarzSalesIssueDefineViewModel.quotaGroup;
								rayvarzProformaDefineViewModel.salesDocProduceTypeId = rayvarzSalesIssueDefineViewModel.salesDocProduceTypeId;
								rayvarzProformaDefineViewModel.parentIssueDocId = rayvarzSalesIssueDefineViewModel.parentIssueDocId;
								rayvarzProformaDefineViewModel.parentDeliveryDocId = rayvarzSalesIssueDefineViewModel.parentDeliveryDocId;
								rayvarzProformaDefineViewModel.proFormaDocDate = text10;
								rayvarzProformaDefineViewModel.parentDocDate = rayvarzSalesIssueDefineViewModel.parentDocDate;
								rayvarzProformaDefineViewModel.issueDocDate = null;
								rayvarzProformaDefineViewModel.deliveryDocDate = rayvarzSalesIssueDefineViewModel.deliveryDocDate;
								rayvarzProformaDefineViewModel.invoiceDocDate = rayvarzSalesIssueDefineViewModel.invoiceDocDate;
								rayvarzProformaDefineViewModel.parentDocNo = rayvarzSalesIssueDefineViewModel.parentDocNo;
								rayvarzProformaDefineViewModel.invoiceDocNo = rayvarzSalesIssueDefineViewModel.invoiceDocNo;
								rayvarzProformaDefineViewModel.parentFactorId = rayvarzSalesIssueDefineViewModel.parentFactorId;
								rayvarzProformaDefineViewModel.totalCreditDiscountAmount = rayvarzSalesIssueDefineViewModel.totalCreditDiscountAmount;
								rayvarzProformaDefineViewModel.multimediaDoc = rayvarzSalesIssueDefineViewModel.multimediaDoc;
								rayvarzProformaDefineViewModel.multiMediaDocX = rayvarzSalesIssueDefineViewModel.multiMediaDocX;
								rayvarzProformaDefineViewModel.branchId = rayvarzSalesIssueDefineViewModel.branchId;
								rayvarzProformaDefineViewModel.branch = rayvarzSalesIssueDefineViewModel.branch;
								rayvarzProformaDefineViewModel.sendSms = rayvarzSalesIssueDefineViewModel.sendSms;
								rayvarzProformaDefineViewModel.docSerial = rayvarzSalesIssueDefineViewModel.docSerial;
								rayvarzProformaDefineViewModel.journalGeneralAdjectives = rayvarzSalesIssueDefineViewModel.journalGeneralAdjectives;
								rayvarzProformaDefineViewModel.journalSpecialAdjective = rayvarzSalesIssueDefineViewModel.journalSpecialAdjective;
								rayvarzProformaDefineViewModel.customerRequestId = rayvarzSalesIssueDefineViewModel.customerRequestId;
								rayvarzProformaDefineViewModel.customerRequest = rayvarzSalesIssueDefineViewModel.customerRequest;
								rayvarzProformaDefineViewModel.contractNo2 = rayvarzSalesIssueDefineViewModel.contractNo2;
								rayvarzProformaDefineViewModel.rayGuid = rayvarzSalesIssueDefineViewModel.rayGuid;
								rayvarzProformaDefineViewModel.state = rayvarzSalesIssueDefineViewModel.state;
								rayvarzProformaDefineViewModel.lastState = rayvarzSalesIssueDefineViewModel.lastState;
								rayvarzProformaDefineViewModel.backupOriginalData = rayvarzSalesIssueDefineViewModel.backupOriginalData;
								rayvarzProformaDefineViewModel.rayValidationResults = rayvarzSalesIssueDefineViewModel.rayValidationResults;
								rayvarzProformaDefineViewModel.validationErrors = rayvarzSalesIssueDefineViewModel.validationErrors;
								rayvarzProformaDefineViewModel.validationErrorsMessages = rayvarzSalesIssueDefineViewModel.validationErrorsMessages;
								rayvarzProformaDefineViewModel.metadataRaySystemId = rayvarzSalesIssueDefineViewModel.metadataRaySystemId;
								rayvarzProformaDefineViewModel.hasMetadata = rayvarzSalesIssueDefineViewModel.hasMetadata;
								rayvarzProformaDefineViewModel.modifiedProperties = rayvarzSalesIssueDefineViewModel.modifiedProperties;
								rayvarzProformaDefineViewModel.hasErrors = rayvarzSalesIssueDefineViewModel.hasErrors;
								rayvarzProformaDefineViewModel.disposing = rayvarzSalesIssueDefineViewModel.disposing;
							}
							if (string.IsNullOrWhiteSpace(rayvarzProformaDefineViewModel.rayGuid))
							{
								rayvarzProformaDefineViewModel.rayGuid = Guid.NewGuid().ToString();
							}
							if (rayvarzProformaDefineViewModel.hasDiscount.GetValueOrDefault() == 0L)
							{
								rayvarzProformaDefineViewModel.discountTypeId = null;
								rayvarzProformaDefineViewModel.discountType = null;
								rayvarzProformaDefineViewModel.hasDiscount = 0L;
							}
						}
						bool isDone2 = false;
						long linkAccId = 0L;
						RayvarzSalesIssueDefineResponseViewModel resultSendOrd = new RayvarzSalesIssueDefineResponseViewModel();
						string text17 = rayvarzProvider.SendSalesIssue(rayvarzSalesIssueDefineViewModel, num8, ref linkAccId, ref resultSendOrd, ref isDone2, pordLinkedToAccApiMode, rayvarzProformaDefineViewModel);
						if (!isDone2 || linkAccId == 0L)
						{
							if (!string.IsNullOrWhiteSpace(text17))
							{
								text = text + "<br>" + Messages.msgErrorRunFunction + " (" + text17 + ")|";
								return text;
							}
							text = Messages.msgErrorRunFunction + "|";
							return text;
						}
						string text18 = linkAccId.ToString();
						string text19 = "";
						string voucherNumber = "";
						string extraField = "";
						string itemJson = "";
						List<LkPreOrderItemLinkAccFieldsViewModel> list9 = new List<LkPreOrderItemLinkAccFieldsViewModel>();
						DateTime value7 = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
						if (resultSendOrd != null && resultSendOrd.entities != null && Enumerable.Any<RayvarzSalesIssueEntitiesResponseViewModel>((IEnumerable<RayvarzSalesIssueEntitiesResponseViewModel>)resultSendOrd.entities))
						{
							RayvarzSalesIssueEntitiesResponseViewModel rayvarzSalesIssueEntitiesResponseViewModel = Enumerable.FirstOrDefault<RayvarzSalesIssueEntitiesResponseViewModel>((IEnumerable<RayvarzSalesIssueEntitiesResponseViewModel>)resultSendOrd.entities);
							if (rayvarzSalesIssueEntitiesResponseViewModel != null)
							{
								text19 = rayvarzSalesIssueEntitiesResponseViewModel.docNo.GetValueOrDefault().ToString();
								voucherNumber = rayvarzSalesIssueEntitiesResponseViewModel.proFormaDocNo.GetValueOrDefault().ToString();
								extraField = rayvarzSalesIssueEntitiesResponseViewModel.rayGuid ?? "";
								if (rayvarzSalesIssueEntitiesResponseViewModel.salesJournalItems != null && rayvarzSalesIssueDefineViewModel.salesJournalItems != null && Enumerable.Any<RayvarzSalesIssueItemEntitiesResponseViewModel>((IEnumerable<RayvarzSalesIssueItemEntitiesResponseViewModel>)rayvarzSalesIssueEntitiesResponseViewModel.salesJournalItems) && Enumerable.Any<RayvarzSalesIssueItemDefineViewModel>((IEnumerable<RayvarzSalesIssueItemDefineViewModel>)rayvarzSalesIssueDefineViewModel.salesJournalItems))
								{
									foreach (RayvarzSalesIssueItemDefineViewModel lkItem in rayvarzSalesIssueDefineViewModel.salesJournalItems)
									{
										RayvarzSalesIssueItemEntitiesResponseViewModel rayvarzSalesIssueItemEntitiesResponseViewModel = Enumerable.FirstOrDefault<RayvarzSalesIssueItemEntitiesResponseViewModel>((IEnumerable<RayvarzSalesIssueItemEntitiesResponseViewModel>)rayvarzSalesIssueEntitiesResponseViewModel.salesJournalItems, (Func<RayvarzSalesIssueItemEntitiesResponseViewModel, bool>)((RayvarzSalesIssueItemEntitiesResponseViewModel m) => m.row.GetValueOrDefault() == lkItem.row.GetValueOrDefault() && (m.itemDataId ?? "") == (lkItem.itemDataId ?? "") && (lkItem.salesJournalItemId.GetValueOrDefault() == 0L || (lkItem.salesJournalItemId.GetValueOrDefault() != 0L && m.salesJournalItemId.GetValueOrDefault() == lkItem.salesJournalItemId.GetValueOrDefault())) && (m.rayGuid ?? "") == (lkItem.rayGuid ?? "")));
										if (rayvarzSalesIssueItemEntitiesResponseViewModel != null)
										{
											long result16 = 0L;
											long.TryParse(rayvarzSalesIssueItemEntitiesResponseViewModel.salesJournalItemId.ToString(), out result16);
											if (result16 != 0L)
											{
												string text20 = "";
												PordItemLinkAccDataByExtraViewModel value8 = new PordItemLinkAccDataByExtraViewModel
												{
													DBId = -1,
													Id = result16.ToString(),
													FTDate = value7,
													LTDate = value7,
													ExtraField = (lkItem.rayGuid ?? "")
												};
												text20 = "[" + JsonConvert.SerializeObject(value8) + "]";
												LkPreOrderItemLinkAccFieldsViewModel item3 = new LkPreOrderItemLinkAccFieldsViewModel
												{
													PreOrderItemID = lkItem.CrmOrdItemId.GetValueOrDefault(),
													pordILinkAccItemId = 0,
													pordILinkAccItemIdStr = result16.ToString(),
													pordILinkAccData = text20
												};
												list9.Add(item3);
											}
										}
									}
								}
							}
						}
						if (list9 != null && Enumerable.Any<LkPreOrderItemLinkAccFieldsViewModel>((IEnumerable<LkPreOrderItemLinkAccFieldsViewModel>)list9))
						{
							itemJson = JsonConvert.SerializeObject(Enumerable.ToList<LkPreOrderItemLinkAccFieldsViewModel>((IEnumerable<LkPreOrderItemLinkAccFieldsViewModel>)list9));
						}
						string text21 = "";
						OrdLinkAccDataByExtraViewModel value9 = new OrdLinkAccDataByExtraViewModel
						{
							DBId = -1,
							Id = text18,
							Number = text19,
							VoucherId = "0",
							VoucherNumber = voucherNumber,
							FTDate = value7,
							LTDate = value7,
							ExtraField = extraField
						};
						text21 = "[" + JsonConvert.SerializeObject(value9) + "]";
						_dbLink.WSspUpdatePreOrderAndItemWithAccLinkField(pordId, null, text19, text18, text21, itemJson, false, userId, value2, value, registerDatePersian, appType);
						text = (string.IsNullOrWhiteSpace(text19) ? ("1|" + text19) : ("1|" + text19));
						if (sendPordPayToAcc)
						{
							string text22 = RayvarzActSendPaymentsToAcc(pordId, 0, isPayCanceled);
							if (!string.IsNullOrWhiteSpace(text22))
							{
								string[] array4 = text22.Split(new char[1] { '|' });
								if (array4 != null && array4.Length >= 1 && array4[0] != "1")
								{
									text = array4[0] + "|";
									return text;
								}
							}
						}
					}
					else
					{
						text = Messages.ErrorNotFound + "|";
					}
				}
				catch (Exception ex)
				{
					text = text + "\n\nException: " + ex.Message;
				}
			}
			else
			{
				text = Messages.ErrorNotFound + "|";
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			text = Messages.msgErrorRunFunction + "|";
		}
		return text;
	}

	[AjaxOnly]
	public string RayvarzActSendPaymentsToAcc(int pordId, int payId = 0, bool isPayCanceled = false)
	{
		string text = "";
		try
		{
			_ = UserLogin.CurrentUser;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (pordId > 0)
			{
				try
				{
					if (payId != 0)
					{
						text = RayvarzActSendPayToAcc(payId, isPayCanceled);
					}
					else
					{
						List<CRMspLkWSSelectPreOrderPayments_Result> list = Enumerable.ToList<CRMspLkWSSelectPreOrderPayments_Result>((IEnumerable<CRMspLkWSSelectPreOrderPayments_Result>)_dbLink.CRMspLkWSSelectPreOrderPayments(pordId, lCID, result));
						if (list != null && Enumerable.Any<CRMspLkWSSelectPreOrderPayments_Result>((IEnumerable<CRMspLkWSSelectPreOrderPayments_Result>)list))
						{
							foreach (CRMspLkWSSelectPreOrderPayments_Result item in list)
							{
								string text2 = RayvarzActSendPayToAcc(item.PreOrderPaymentId, isPayCanceled);
								if (!string.IsNullOrWhiteSpace(text2))
								{
									string[] array = text2.Split(new char[1] { '|' });
									if (array != null && array.Length >= 1 && array[0] != "1")
									{
										text = array[0] + "|";
										return text;
									}
								}
							}
							text = "1|" + Messages.msgSuccessAction;
						}
					}
				}
				catch (Exception ex)
				{
					text = text + "\n\nException: " + ex.Message;
				}
			}
			else
			{
				text = Messages.ErrorNotFound + "|";
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
	public string RayvarzActSendPayToAcc(int payId, bool isPayCanceled = false)
	{
		//IL_09ea: Unknown result type (might be due to invalid IL or missing references)
		string text = "";
		try
		{
			_ = UserLogin.CurrentUser;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
			if (defLangID <= 0)
			{
				defLangID = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (payId > 0)
			{
				try
				{
					_003C_003Ec__DisplayClass111_1 _003C_003Ec__DisplayClass111_ = new _003C_003Ec__DisplayClass111_1();
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
					string appType = Configuration.AppType;
					short.Parse(Financial.Get().Id.ToString());
					int userId = UserLogin.CurrentUser.UserId;
					_ = Financial.Get().Id;
					string rayvarz = Labels.Rayvarz;
					_003C_003Ec__DisplayClass111_.pay = Enumerable.FirstOrDefault<CRMspLkWSSelectPreOrderPaymentsWithId_Result>((IEnumerable<CRMspLkWSSelectPreOrderPaymentsWithId_Result>)_dbLink.CRMspLkWSSelectPreOrderPaymentsWithId(payId, lCID, defLangID));
					if (_003C_003Ec__DisplayClass111_.pay != null)
					{
						CRMIdeal.Classes.Helper.OtherSystems.RayvarzProvider rayvarzProvider = new CRMIdeal.Classes.Helper.OtherSystems.RayvarzProvider();
						long result = 0L;
						long.TryParse(rayvarzProvider.FiscalYear, out result);
						long result2 = 0L;
						long.TryParse(rayvarzProvider.ApiBranchId, out result2);
						string text2 = _003C_003Ec__DisplayClass111_.pay.pordpayAmount.ToString().FormatForPrice();
						_003C_003Ec__DisplayClass111_.pay.pordNumber = _003C_003Ec__DisplayClass111_.pay.pordNumber.GetValueOrDefault();
						int result3 = 0;
						int.TryParse(_003C_003Ec__DisplayClass111_.pay.ordpayTypeKind.ToString(), out result3);
						if (result3 == 0)
						{
							text = string.Format(Messages.msgErrorNotReSendPayToOtherSystemNotSetKind, _003C_003Ec__DisplayClass111_.pay.PayTypeTitle, text2, Labels.lblPOrd, _003C_003Ec__DisplayClass111_.pay.pordNumber.ToString()) + "|";
							return text;
						}
						if (!string.IsNullOrWhiteSpace(_003C_003Ec__DisplayClass111_.pay.pordpayLinkAccHeaderIdStr))
						{
							long result4 = 0L;
							long.TryParse(_003C_003Ec__DisplayClass111_.pay.pordpayLinkAccVoucherNumber, out result4);
							if (isPayCanceled && result4 != 0L)
							{
								bool isDone = false;
								string text3 = rayvarzProvider.DeletePayment(result2, result, result4, ref isDone);
								if (isDone)
								{
									_dbLink.WSspUpdatePreOrderPaymentWithAccLinkField(payId, null, null, null, null, null, null, null, null, null, null, true, userId, value2, value, registerDatePersian, appType);
									text = "1|-100000";
									return text;
								}
								if (!string.IsNullOrWhiteSpace(text3))
								{
									text = text + "<br>" + Messages.msgErrorRunFunction + " (" + text3 + ")|";
									return text;
								}
								text = Messages.msgErrorRunFunction + "|";
								return text;
							}
							text = string.Format(Messages.msgErrorNotReSendPordPayToOtherSystem, _003C_003Ec__DisplayClass111_.pay.PayTypeTitle, text2, _003C_003Ec__DisplayClass111_.pay.pordNumber.ToString(), rayvarz) + "|";
							return text;
						}
						if (string.IsNullOrWhiteSpace(_003C_003Ec__DisplayClass111_.pay.pordLinkAccPreOrderIdStr))
						{
							text = string.Format(Messages.msgErrorNotSendPordPayToOtherSystemWithOutPordToAcc, _003C_003Ec__DisplayClass111_.pay.PayTypeTitle, text2, _003C_003Ec__DisplayClass111_.pay.pordNumber.ToString(), rayvarz) + "|";
							return text;
						}
						CRMspLkWSCheckDuplicatePreOrderPayment_Result cRMspLkWSCheckDuplicatePreOrderPayment_Result = Enumerable.FirstOrDefault<CRMspLkWSCheckDuplicatePreOrderPayment_Result>((IEnumerable<CRMspLkWSCheckDuplicatePreOrderPayment_Result>)_dbLink.CRMspLkWSCheckDuplicatePreOrderPayment(payId));
						if (cRMspLkWSCheckDuplicatePreOrderPayment_Result != null)
						{
							_003C_003Ec__DisplayClass111_.pay.pordpayAmount = cRMspLkWSCheckDuplicatePreOrderPayment_Result.pordpayAmount ?? _003C_003Ec__DisplayClass111_.pay.pordpayAmount;
							_003C_003Ec__DisplayClass111_.pay.pordpayDocAmount = cRMspLkWSCheckDuplicatePreOrderPayment_Result.pordpayDocAmount ?? _003C_003Ec__DisplayClass111_.pay.pordpayDocAmount;
							_003C_003Ec__DisplayClass111_.pay.pordpayDocDateTime = cRMspLkWSCheckDuplicatePreOrderPayment_Result.pordpayDocDateTime ?? _003C_003Ec__DisplayClass111_.pay.pordpayDocDateTime;
							_003C_003Ec__DisplayClass111_.pay.pordpayDocNumber = cRMspLkWSCheckDuplicatePreOrderPayment_Result.pordpayDocNumber ?? _003C_003Ec__DisplayClass111_.pay.pordpayDocNumber;
							int result5 = 0;
							int.TryParse(cRMspLkWSCheckDuplicatePreOrderPayment_Result.AlreadySendPreOrderPaymentId.ToString(), out result5);
							if (result5 != 0 && !string.IsNullOrWhiteSpace(cRMspLkWSCheckDuplicatePreOrderPayment_Result.AlreadyPordpayLinkAccHeaderIdStr))
							{
								_dbLink.WSspUpdatePreOrderPaymentWithAccLinkField(payId, cRMspLkWSCheckDuplicatePreOrderPayment_Result.AlreadyPordpayLinkAccHeaderId, cRMspLkWSCheckDuplicatePreOrderPayment_Result.AlreadyPordpayLinkAccHeaderNumber, cRMspLkWSCheckDuplicatePreOrderPayment_Result.AlreadyPordpayLinkAccDetailId, cRMspLkWSCheckDuplicatePreOrderPayment_Result.AlreadyPordpayLinkAccVoucherId, cRMspLkWSCheckDuplicatePreOrderPayment_Result.AlreadyPordpayLinkAccVoucherNumber, cRMspLkWSCheckDuplicatePreOrderPayment_Result.AlreadyPordpayLinkAccHeaderIdStr, cRMspLkWSCheckDuplicatePreOrderPayment_Result.AlreadyPordpayLinkAccDetailIdStr, cRMspLkWSCheckDuplicatePreOrderPayment_Result.AlreadyPordpayLinkAccVoucherIdStr, "dup", cRMspLkWSCheckDuplicatePreOrderPayment_Result.AlreadySendPordpayLinkAccData, false, userId, value2, value, registerDatePersian, appType);
								text = "1|" + cRMspLkWSCheckDuplicatePreOrderPayment_Result.AlreadyPordpayLinkAccHeaderNumber;
								return text;
							}
						}
						decimal pordpayAmount = _003C_003Ec__DisplayClass111_.pay.pordpayAmount;
						if (!_003C_003Ec__DisplayClass111_.pay.pordpayDocDateTime.HasValue)
						{
							_003C_003Ec__DisplayClass111_.pay.pordpayDocDateTime = _003C_003Ec__DisplayClass111_.pay.ImportDateTime;
						}
						string objectType = "PordPayType";
						if (pordpayAmount < 0m)
						{
							objectType = "PordPayType_Negative";
						}
						CRMIdeal.Classes.Helper.OtherSystems.RayvarzProvider.RayvarzSettingDetailsViewModel settingDetails = rayvarzProvider.GetSettingDetails(0, _003C_003Ec__DisplayClass111_.pay.pordpayTypeId, objectType);
						int num = 0;
						int num2 = 0;
						long num3 = 0L;
						long num4 = 0L;
						long value3 = 0L;
						long num5 = 0L;
						long num6 = 0L;
						string text4 = "";
						if (settingDetails != null)
						{
							num3 = settingDetails.OrdPayCashTypeId;
							num4 = settingDetails.OrdPayFundId;
							value3 = settingDetails.OrdPaySeries;
							num5 = settingDetails.OrdPaySubjectId;
							num6 = settingDetails.OrdPayCenter1Id;
							num = settingDetails.OrdPayHeaderDateType;
							num2 = settingDetails.OrdPayDetailDateType;
							text4 = settingDetails.OrdPayShopName ?? "";
						}
						if (num3 == 0L || num4 == 0L || num5 == 0L || num6 == 0L)
						{
							text = Messages.errorInReadingSetting + "|";
							return text;
						}
						long result6 = 0L;
						string pordLinkAccPreOrderNumber = _003C_003Ec__DisplayClass111_.pay.pordLinkAccPreOrderNumber;
						if ((result3 == 2 || result3 == 3) && string.IsNullOrWhiteSpace(_003C_003Ec__DisplayClass111_.pay.pordpayDocNumber))
						{
							text = string.Format(Messages.msgErrorInSendPayToAccLinkNotSelectedItem, _003C_003Ec__DisplayClass111_.pay.PayTypeTitle, text2, Labels.lblOrd, _003C_003Ec__DisplayClass111_.pay.pordNumber.ToString(), rayvarz, Labels.pordpayDocNumber) + "|";
							return text;
						}
						string text5 = "";
						string text6 = "";
						_ = 3;
						try
						{
							DateTime dateTime = _003C_003Ec__DisplayClass111_.pay.ImportDateTime ?? DateTime.Now;
							if (num == 2)
							{
								dateTime = _003C_003Ec__DisplayClass111_.pay.pordpayDocDateTime ?? DateTime.Now;
							}
							DateTime dateTime2 = dateTime;
							text5 = dateTime2.ToString("yyyyMMdd", new PersianCulture());
							DateTime dateTime3 = _003C_003Ec__DisplayClass111_.pay.ImportDateTime ?? DateTime.Now;
							if (num2 == 2)
							{
								dateTime3 = _003C_003Ec__DisplayClass111_.pay.pordpayDocDateTime ?? DateTime.Now;
							}
							dateTime2 = dateTime3;
							text6 = dateTime2.ToString("yyyyMMdd", new PersianCulture());
						}
						catch (Exception e)
						{
							ErrorSignal.FromCurrentContext().Raise(e);
							text = string.Format(Messages.ErrorInFormat, Labels.Date);
							return text;
						}
						string text7 = "";
						string text8 = "";
						string text9 = "";
						CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(_003C_003Ec__DisplayClass111_.pay.pordCompanyId.GetValueOrDefault());
						if (companyById == null)
						{
							text = Messages.CompanyNotFound + "|";
							return text;
						}
						text7 = companyById.CompanyName ?? "";
						text9 = companyById.cmpLinkAccCustomerIdStr ?? "";
						text8 = companyById.cmpLinkAccData ?? "";
						if (string.IsNullOrWhiteSpace(text9))
						{
							string text10 = new CompanyController().RahkaranInternalSalesActCmpSendToAcc(_003C_003Ec__DisplayClass111_.pay.pordCompanyId.GetValueOrDefault(), 0, isExportCustomer: false, checkAction: false);
							if (string.IsNullOrEmpty(text10))
							{
								text = Messages.msgErrorRunFunction + "(insert company to rayvarz)|";
								return text;
							}
							string[] array = text10.Split(new char[1] { '|' });
							if (array != null)
							{
								if (!(array[0] == "1"))
								{
									text = array[0] + "|";
									return text;
								}
								companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(_003C_003Ec__DisplayClass111_.pay.pordCompanyId.GetValueOrDefault());
								if (companyById == null)
								{
									text = Messages.CompanyNotFound + "|";
									return text;
								}
								text9 = companyById.cmpLinkAccCustomerIdStr ?? "";
								text8 = companyById.cmpLinkAccData ?? "";
							}
						}
						if (string.IsNullOrWhiteSpace(text9) || string.IsNullOrWhiteSpace(text8))
						{
							text = string.Format(Messages.msgErrorInSendToAccLinkNotFoundCmpInAcc, rayvarz) + "|";
							return text;
						}
						if (!string.IsNullOrWhiteSpace(text8))
						{
							List<LinkAccDataViewModel> list = new JavaScriptSerializer().Deserialize<List<LinkAccDataViewModel>>(text8);
							if (list != null && Enumerable.Any<LinkAccDataViewModel>((IEnumerable<LinkAccDataViewModel>)list))
							{
								LinkAccDataViewModel linkAccDataViewModel = Enumerable.FirstOrDefault<LinkAccDataViewModel>((IEnumerable<LinkAccDataViewModel>)list);
								if (linkAccDataViewModel != null)
								{
									long.TryParse(linkAccDataViewModel.LACId ?? "", out result6);
								}
							}
						}
						if (result6 == 0L)
						{
							text = string.Format(Messages.msgErrorInSendPayToAccLinkNotFoundCmpLACenter, _003C_003Ec__DisplayClass111_.pay.PayTypeTitle, text2, Labels.lblOrd, _003C_003Ec__DisplayClass111_.pay.pordNumber.ToString(), rayvarz, text7) + "|";
							return text;
						}
						int num7 = ((pordpayAmount > 0m) ? 1 : 2);
						int num8 = ((!(pordpayAmount > 0m)) ? 1 : 0);
						num7 = 1;
						if (num8 == 1)
						{
							num7 = 2;
						}
						if (pordpayAmount < 0m)
						{
							pordpayAmount *= -1m;
						}
						string text11 = "";
						string text12 = "";
						string text13 = "";
						string text14 = "";
						CRMTabelEntities cRMTabelEntities = new CRMTabelEntities();
						DbSet<WSPreOrderPayments_Lang> wSPreOrderPayments_Lang = cRMTabelEntities.WSPreOrderPayments_Lang;
						ParameterExpression val = Expression.Parameter(typeof(WSPreOrderPayments_Lang), "c");
						List<WSPreOrderPayments_Lang> list2 = Enumerable.ToList<WSPreOrderPayments_Lang>((IEnumerable<WSPreOrderPayments_Lang>)Queryable.Where<WSPreOrderPayments_Lang>((IQueryable<WSPreOrderPayments_Lang>)wSPreOrderPayments_Lang, Expression.Lambda<Func<WSPreOrderPayments_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass111_, typeof(_003C_003Ec__DisplayClass111_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
						string pordpayDescription = _003C_003Ec__DisplayClass111_.pay.pordpayDescription;
						if (lCID != defLangID)
						{
							DbSet<WSPreOrderPayments> wSPreOrderPayments = cRMTabelEntities.WSPreOrderPayments;
							val = Expression.Parameter(typeof(WSPreOrderPayments), "c");
							WSPreOrderPayments wSPreOrderPayments2 = Queryable.FirstOrDefault<WSPreOrderPayments>((IQueryable<WSPreOrderPayments>)wSPreOrderPayments, Expression.Lambda<Func<WSPreOrderPayments, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass111_, typeof(_003C_003Ec__DisplayClass111_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (wSPreOrderPayments2 != null)
							{
								pordpayDescription = wSPreOrderPayments2.pordpayDescription;
							}
						}
						List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
						if (list2 != null && Enumerable.Any<WSPreOrderPayments_Lang>((IEnumerable<WSPreOrderPayments_Lang>)list2))
						{
							list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSPreOrderPayments_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSPreOrderPayments_Lang>)list2, (Func<WSPreOrderPayments_Lang, CommonMultiLanguageViewModel>)((WSPreOrderPayments_Lang item) => new CommonMultiLanguageViewModel
							{
								Value = item.pordpayDescription,
								LanguageId = item.LanguageID
							})));
						}
						list3.Add(new CommonMultiLanguageViewModel
						{
							Value = pordpayDescription,
							LanguageId = defLangID
						});
						if (list3 != null)
						{
							if (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3))
							{
								text11 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : "");
								text12 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == 1033)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == 1033)).Value : "");
							}
							text13 = text11;
							text14 = text12;
						}
						if (string.IsNullOrWhiteSpace(text11))
						{
							switch (num7)
							{
							case 1:
								switch (num3)
								{
								case 1L:
									text11 = "وب سرویس - دریافت وجه نقد";
									break;
								case 2L:
									text11 = "وب سرویس - دریافت حواله نقدی";
									break;
								case 3L:
									text11 = "وب سرویس - دریافت چک روز";
									break;
								case 4L:
									text11 = "وب سرویس - دریافت چک مدت دار";
									break;
								}
								break;
							case 2:
								switch (num3)
								{
								case 1L:
									text11 = "وب سرویس - پرداخت وجه نقد";
									break;
								case 2L:
									text11 = "وب سرویس - پرداخت حواله نقدی";
									break;
								case 3L:
									text11 = "وب سرویس - پرداخت چک روز";
									break;
								case 4L:
									text11 = "وب سرویس - پرداخت چک مدت دار";
									break;
								}
								break;
							}
							if (!string.IsNullOrWhiteSpace(text4))
							{
								text11 = text11 + " - " + text4;
							}
						}
						if (string.IsNullOrWhiteSpace(text12))
						{
							switch (num7)
							{
							case 1:
								switch (num3)
								{
								case 1L:
									text12 = "Web service - Cash receipt";
									break;
								case 2L:
									text12 = "Cash remittance web service";
									break;
								case 3L:
									text12 = "Web service - Receive daily cheque";
									break;
								case 4L:
									text12 = "Web service - Receive a fixed-term cheque";
									break;
								}
								break;
							case 2:
								switch (num3)
								{
								case 1L:
									text12 = "Web service - cash payment";
									break;
								case 2L:
									text12 = "Web service - Cash transfer payment";
									break;
								case 3L:
									text12 = "Web Service - Daily cheque payment";
									break;
								case 4L:
									text12 = "Web service - Payment of term cheque";
									break;
								}
								break;
							}
							if (!string.IsNullOrWhiteSpace(text4))
							{
								text12 = text12 + " - " + text4;
							}
						}
						if (string.IsNullOrWhiteSpace(text13))
						{
							switch (num7)
							{
							case 1:
								switch (num3)
								{
								case 1L:
									text13 = "بابت دریافت وجه نقد";
									break;
								case 2L:
									text13 = "بابت دریافت حواله نقدی";
									break;
								case 3L:
									text13 = "بابت دریافت چک روز";
									break;
								case 4L:
									text13 = "بابت دریافت چک مدت دار";
									break;
								}
								break;
							case 2:
								switch (num3)
								{
								case 1L:
									text13 = "بابت پرداخت وجه نقد";
									break;
								case 2L:
									text13 = "بابت پرداخت حواله نقدی";
									break;
								case 3L:
									text13 = "بابت پرداخت چک روز";
									break;
								case 4L:
									text13 = "بابت پرداخت چک مدت دار";
									break;
								}
								break;
							}
						}
						if (string.IsNullOrWhiteSpace(text14))
						{
							switch (num7)
							{
							case 1:
								switch (num3)
								{
								case 1L:
									text14 = "For receiving cash";
									break;
								case 2L:
									text14 = "For receiving a cash order";
									break;
								case 3L:
									text14 = "For receiving a daily cheque";
									break;
								case 4L:
									text14 = "For receiving a term cheque";
									break;
								}
								break;
							case 2:
								switch (num3)
								{
								case 1L:
									text14 = "For cash payment";
									break;
								case 2L:
									text14 = "For cash transfer payment";
									break;
								case 3L:
									text14 = "For payment of the cheque of the day";
									break;
								case 4L:
									text14 = "For payment of a time cheque";
									break;
								}
								break;
							}
						}
						cRMTabelEntities?.Dispose();
						RayvarzJournalSubjectDefineViewModel rayvarzJournalSubjectDefineViewModel = new RayvarzJournalSubjectDefineViewModel();
						rayvarzJournalSubjectDefineViewModel.BranchId = result2;
						rayvarzJournalSubjectDefineViewModel.FiscalYearId = result;
						rayvarzJournalSubjectDefineViewModel.DocNo = 0L;
						rayvarzJournalSubjectDefineViewModel.DocRow = 1L;
						rayvarzJournalSubjectDefineViewModel.SubjectRow = 1L;
						rayvarzJournalSubjectDefineViewModel.SubjectId = num5;
						rayvarzJournalSubjectDefineViewModel.SubjectExchangedValue = pordpayAmount;
						rayvarzJournalSubjectDefineViewModel.SubjectValue = pordpayAmount;
						rayvarzJournalSubjectDefineViewModel.CurrencyId = null;
						rayvarzJournalSubjectDefineViewModel.CurrencyDateId = null;
						rayvarzJournalSubjectDefineViewModel.CurrencyRateId = 1;
						rayvarzJournalSubjectDefineViewModel.Center1Id = num6;
						rayvarzJournalSubjectDefineViewModel.Center2Id = null;
						rayvarzJournalSubjectDefineViewModel.Center3Id = result6;
						rayvarzJournalSubjectDefineViewModel.Center4Id = null;
						rayvarzJournalSubjectDefineViewModel.Center5Id = null;
						rayvarzJournalSubjectDefineViewModel.Remark = text13;
						rayvarzJournalSubjectDefineViewModel.RemarkEn = text14;
						rayvarzJournalSubjectDefineViewModel.RefNo1 = pordLinkAccPreOrderNumber;
						rayvarzJournalSubjectDefineViewModel.RefNo2 = null;
						rayvarzJournalSubjectDefineViewModel.RefNo3 = null;
						rayvarzJournalSubjectDefineViewModel.RefNo4 = null;
						rayvarzJournalSubjectDefineViewModel.CreditsRefCreditId = null;
						rayvarzJournalSubjectDefineViewModel.CreditsVoucherTypeId = null;
						RayvarzJournalCashDefineViewModel rayvarzJournalCashDefineViewModel = new RayvarzJournalCashDefineViewModel();
						rayvarzJournalCashDefineViewModel.JournalSubjects = new List<RayvarzJournalSubjectDefineViewModel>();
						rayvarzJournalCashDefineViewModel.BranchId = result2;
						rayvarzJournalCashDefineViewModel.FiscalYearId = result;
						rayvarzJournalCashDefineViewModel.DocNo = 0L;
						rayvarzJournalCashDefineViewModel.DocRow = 1L;
						rayvarzJournalCashDefineViewModel.CashTypeId = num3;
						rayvarzJournalCashDefineViewModel.FundId = num4;
						rayvarzJournalCashDefineViewModel.CashCenterId = null;
						rayvarzJournalCashDefineViewModel.ChequeBookId = null;
						rayvarzJournalCashDefineViewModel.CashNo = _003C_003Ec__DisplayClass111_.pay.pordpayDocNumber;
						rayvarzJournalCashDefineViewModel.CashDate = text6;
						rayvarzJournalCashDefineViewModel.ChequePayee = null;
						rayvarzJournalCashDefineViewModel.BankId = null;
						rayvarzJournalCashDefineViewModel.BankAccountNo = "";
						rayvarzJournalCashDefineViewModel.BankAccountOwner = "";
						rayvarzJournalCashDefineViewModel.BankBranchId = "";
						rayvarzJournalCashDefineViewModel.PersonId = null;
						rayvarzJournalCashDefineViewModel.JournalSubjects.Add(rayvarzJournalSubjectDefineViewModel);
						RayvarzJournalDefineViewModel rayvarzJournalDefineViewModel = new RayvarzJournalDefineViewModel();
						rayvarzJournalDefineViewModel.JournalCashs = new List<RayvarzJournalCashDefineViewModel>();
						rayvarzJournalDefineViewModel.BranchId = result2;
						rayvarzJournalDefineViewModel.FiscalYearId = result;
						rayvarzJournalDefineViewModel.DocNo = 0L;
						rayvarzJournalDefineViewModel.raySysId = "cash";
						rayvarzJournalDefineViewModel.systemVoucherItemTypeId = 0L;
						rayvarzJournalDefineViewModel.error = 0L;
						rayvarzJournalDefineViewModel.allowChange = false;
						rayvarzJournalDefineViewModel.senderFlag = false;
						rayvarzJournalDefineViewModel.SenderKey = null;
						rayvarzJournalDefineViewModel.traceKey = null;
						rayvarzJournalDefineViewModel.JournalCashs.Add(rayvarzJournalCashDefineViewModel);
						rayvarzJournalDefineViewModel.DocDate = text5;
						rayvarzJournalDefineViewModel.CashJournalTypeId = num8;
						rayvarzJournalDefineViewModel.DocGroupId = 0L;
						rayvarzJournalDefineViewModel.ReceiverId = 0L;
						rayvarzJournalDefineViewModel.Remark = text11;
						rayvarzJournalDefineViewModel.RemarkEn = text12;
						rayvarzJournalDefineViewModel.LetterNo = null;
						rayvarzJournalDefineViewModel.LetterDate = null;
						rayvarzJournalDefineViewModel.Series = value3.ToString();
						rayvarzJournalDefineViewModel.SystemVoucherItemSeries = value3;
						RayvarzJournalMainDefineViewModel rayvarzJournalMainDefineViewModel = new RayvarzJournalMainDefineViewModel();
						rayvarzJournalMainDefineViewModel.Journals = new List<RayvarzJournalDefineViewModel>();
						rayvarzJournalMainDefineViewModel.RaySystemId = "Cash";
						rayvarzJournalMainDefineViewModel.Journals.Add(rayvarzJournalDefineViewModel);
						rayvarzJournalMainDefineViewModel.SaveToCash = true;
						rayvarzJournalMainDefineViewModel.IsComplete = true;
						bool isDone2 = false;
						long linkAccHeaderNumber = 0L;
						long linkAccVoucherNumber = 0L;
						string text15 = rayvarzProvider.SendPayment(rayvarzJournalMainDefineViewModel, ref linkAccHeaderNumber, ref linkAccVoucherNumber, ref isDone2);
						if (!isDone2 || (linkAccHeaderNumber == 0L && linkAccVoucherNumber == 0L))
						{
							if (!string.IsNullOrWhiteSpace(text15))
							{
								text = text + "<br>" + Messages.msgErrorRunFunction + " (" + text15 + ")|";
								return text;
							}
							text = Messages.msgErrorRunFunction + "|";
							return text;
						}
						string pordpayLinkAccHeaderIdStr = linkAccHeaderNumber.ToString();
						string text16 = linkAccHeaderNumber.ToString();
						string pordpayLinkAccVoucherNumber = linkAccVoucherNumber.ToString();
						_dbLink.WSspUpdatePreOrderPaymentWithAccLinkField(payId, null, text16, null, null, pordpayLinkAccVoucherNumber, pordpayLinkAccHeaderIdStr, null, null, null, null, false, userId, value2, value, registerDatePersian, appType);
						text = "1|" + text16;
					}
					else
					{
						text = Messages.ErrorNotFound + "|";
					}
				}
				catch (Exception ex)
				{
					text = text + "\n\nException: " + ex.Message;
				}
			}
			else
			{
				text = Messages.ErrorNotFound + "|";
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			text = Messages.msgErrorRunFunction + "|";
		}
		return text;
	}

	[DynamicAuthorize(ControllerName = "frmPreOrder", ActionName = "actManagePordLinkAcc,actSendToAcc,actSendPayToAcc,actSendAllPayToAcc")]
	public ActionResult ManagePordLinkAcc(int linkAccSystemId)
	{
		if (linkAccSystemId == 18)
		{
			LinkAccNoAvCapillarySettingController linkAccNoAvCapillarySettingController = new LinkAccNoAvCapillarySettingController();
			base.ViewBag.NoAvCompany = linkAccNoAvCapillarySettingController.GetNoAvaranCapillaryCompanyList();
			base.ViewBag.NoAvPart = linkAccNoAvCapillarySettingController.GetNoAvaranCapillaryPartList();
			base.ViewBag.NoAvPrdGrouos = GetNoAvaranCapillaryPrdGrouos();
		}
		GetPreOrderOpr();
		GetCrmWh();
		GetPordReferUser();
		GetCrmOrderPayType();
		base.ViewBag.LinkAccSystemId = linkAccSystemId;
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmManagePordLinkAcc", ActionName = "actImportShowInfo")]
	public ActionResult ManageImportPreOrder_Read([DataSourceRequest] DataSourceRequest request, int linkAccSystemId, string fDate = "", string tDate = "", string linkAccNumber = "", string records = "", int linkAccPageNum = 0)
	{
		//IL_0234: Unknown result type (might be due to invalid IL or missing references)
		List<LkWSPreOrderInfoViewModel> list = new List<LkWSPreOrderInfoViewModel>();
		List<OtherSystemSelectedVIiewModel> list2 = new List<OtherSystemSelectedVIiewModel>();
		OtherSystemSelectedVIiewModel item2 = new OtherSystemSelectedVIiewModel
		{
			Row = 0L,
			Id = "0",
			Selected = false
		};
		list2.Add(item2);
		switch (linkAccSystemId)
		{
		case 18:
		{
			LkPreOrderInfoViewModelObjects noAvaranCapillaryPreOrderList = GetNoAvaranCapillaryPreOrderList(fDate, tDate, linkAccNumber);
			if (noAvaranCapillaryPreOrderList != null)
			{
				list = noAvaranCapillaryPreOrderList.lst;
			}
			break;
		}
		case 20:
		{
			LkPreOrderInfoViewModelObjects nilramPreOrderList = GetNilramPreOrderList(fDate, tDate, linkAccNumber);
			if (nilramPreOrderList != null)
			{
				list = nilramPreOrderList.lst;
			}
			break;
		}
		case 22:
		{
			LkPreOrderInfoViewModelObjects rahkaranInternalSalesPreOrderList = GetRahkaranInternalSalesPreOrderList(fDate, tDate, 0L, isUpdateList: true);
			if (rahkaranInternalSalesPreOrderList != null)
			{
				list = rahkaranInternalSalesPreOrderList.lst;
			}
			break;
		}
		case 23:
		{
			LkPreOrderInfoViewModelObjects rayvarzPreOrderList = GetRayvarzPreOrderList(fDate, tDate, 0, isUpdateList: true, linkAccPageNum);
			if (rayvarzPreOrderList != null)
			{
				list = rayvarzPreOrderList.lst;
			}
			break;
		}
		}
		if (list == null)
		{
			list = new List<LkWSPreOrderInfoViewModel>();
		}
		else if (Enumerable.Any<LkWSPreOrderInfoViewModel>((IEnumerable<LkWSPreOrderInfoViewModel>)list))
		{
			foreach (LkWSPreOrderInfoViewModel item4 in list)
			{
				item4.pordDate = (item4.pordDateTime.HasValue ? item4.pordDateTime.Value.ToString("yyyy/MM/dd") : "");
				item4.ReferUserLName = ((!string.IsNullOrWhiteSpace(item4.ReferUserFName)) ? (item4.ReferUserFName + " ") : "") + ((!string.IsNullOrWhiteSpace(item4.ReferUserLName)) ? item4.ReferUserLName : "");
				if (string.IsNullOrWhiteSpace(item4.ReferUserLName))
				{
					item4.ReferUserLName = item4.LinkAccReferUserIdStr ?? item4.LinkAccReferUserCode;
				}
				if (string.IsNullOrWhiteSpace(item4.PreOrderOpr))
				{
					item4.PreOrderOpr = item4.LinkAccPreOrderOprIdStr;
				}
				OtherSystemSelectedVIiewModel item3 = new OtherSystemSelectedVIiewModel
				{
					Row = item4.RowNumber,
					Id = (item4.pordLinkAccPreOrderIdStr ?? "0"),
					Selected = (item4.PreOrderID <= 0)
				};
				list2.Add(item3);
			}
			if (list2 != null && Enumerable.Any<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list2))
			{
				if (!string.IsNullOrWhiteSpace(records))
				{
					List<OtherSystemSelectedVIiewModel> list3 = new List<OtherSystemSelectedVIiewModel>();
					list3 = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedVIiewModel>>(records);
					if (list3 != null && Enumerable.Any<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list3))
					{
						foreach (OtherSystemSelectedVIiewModel item in list3)
						{
							if (Enumerable.FirstOrDefault<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list2, (Func<OtherSystemSelectedVIiewModel, bool>)((OtherSystemSelectedVIiewModel m) => m.Row == item.Row)) != null)
							{
								Enumerable.FirstOrDefault<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list2, (Func<OtherSystemSelectedVIiewModel, bool>)((OtherSystemSelectedVIiewModel m) => m.Row == item.Row)).Selected = item.Selected;
							}
						}
					}
				}
				int num = 0;
				if (request != null)
				{
					int page = request.Page;
					int pageSize = request.PageSize;
					if (page > 1)
					{
						num = page * pageSize - pageSize;
					}
				}
				string listItemRecords = JsonConvert.SerializeObject(Enumerable.ToList<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list2));
				if (Enumerable.Count<LkWSPreOrderInfoViewModel>((IEnumerable<LkWSPreOrderInfoViewModel>)list) >= num && list[num] != null)
				{
					list[num].ListItemRecords = listItemRecords;
				}
			}
		}
		JsonResult jsonResult = Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult GetManageImportPreOrderList(string records, int linkAccSystemId, string fDate = "", string tDate = "", string linkAccNumber = "", int linkAccPageNum = 0)
	{
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		List<OtherSystemSelectedVIiewModel> list = new List<OtherSystemSelectedVIiewModel>();
		try
		{
			List<LkWSPreOrderInfoViewModel> list2 = new List<LkWSPreOrderInfoViewModel>();
			switch (linkAccSystemId)
			{
			case 18:
			{
				LkPreOrderInfoViewModelObjects noAvaranCapillaryPreOrderList = GetNoAvaranCapillaryPreOrderList(fDate, tDate, linkAccNumber);
				if (noAvaranCapillaryPreOrderList != null)
				{
					list2 = noAvaranCapillaryPreOrderList.lst;
				}
				break;
			}
			case 20:
			{
				LkPreOrderInfoViewModelObjects nilramPreOrderList = GetNilramPreOrderList(fDate, tDate, linkAccNumber);
				if (nilramPreOrderList != null)
				{
					list2 = nilramPreOrderList.lst;
				}
				break;
			}
			case 22:
			{
				LkPreOrderInfoViewModelObjects rahkaranInternalSalesPreOrderList = GetRahkaranInternalSalesPreOrderList(fDate, tDate, 0L);
				if (rahkaranInternalSalesPreOrderList != null)
				{
					list2 = rahkaranInternalSalesPreOrderList.lst;
				}
				break;
			}
			case 23:
			{
				LkPreOrderInfoViewModelObjects rayvarzPreOrderList = GetRayvarzPreOrderList(fDate, tDate, 0, isUpdateList: false, linkAccPageNum);
				if (rayvarzPreOrderList != null)
				{
					list2 = rayvarzPreOrderList.lst;
				}
				break;
			}
			}
			if (list2 != null && Enumerable.Any<LkWSPreOrderInfoViewModel>((IEnumerable<LkWSPreOrderInfoViewModel>)list2))
			{
				foreach (LkWSPreOrderInfoViewModel item2 in list2)
				{
					OtherSystemSelectedVIiewModel item = new OtherSystemSelectedVIiewModel
					{
						Row = item2.RowNumber,
						Id = (item2.pordLinkAccPreOrderIdStr ?? "0"),
						Selected = (item2.PreOrderID <= 0)
					};
					list.Add(item);
				}
			}
			if (list != null)
			{
				if (!string.IsNullOrWhiteSpace(records))
				{
					List<OtherSystemSelectedVIiewModel> list3 = new List<OtherSystemSelectedVIiewModel>();
					list3 = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedVIiewModel>>(records);
					if (Enumerable.Any<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list3))
					{
						foreach (OtherSystemSelectedVIiewModel item3 in list3)
						{
							foreach (OtherSystemSelectedVIiewModel item4 in list)
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
			else
			{
				list = new List<OtherSystemSelectedVIiewModel>();
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

	[DynamicAuthorize(ControllerName = "frmManagePordLinkAcc", ActionName = "actImportInfo")]
	[AjaxOnly]
	public JsonResult ManagePordImportInfo(string records, int linkAccSystemId, int preOrderOprId = 0, int whId = 0, int referUserId = 0, string fDate = "", string tDate = "", string linkAccNumber = "", bool getPayFromLinkAcc = false, int payTypeId = 0, int linkAccPageNum = 0)
	{
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c0f: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int num = 0;
		string text = "";
		CommonResultStatusViewModel commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		CommonResultViewModel<int> data;
		try
		{
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int id = Financial.Get().Id;
			short value2 = short.Parse(Financial.Get().Id.ToString());
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			List<OtherSystemSelectedVIiewModel> list = new List<OtherSystemSelectedVIiewModel>();
			if (!string.IsNullOrWhiteSpace(records))
			{
				List<OtherSystemSelectedVIiewModel> list2 = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedVIiewModel>>(records);
				if (Enumerable.Any<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list2))
				{
					list = Enumerable.ToList<OtherSystemSelectedVIiewModel>(Enumerable.Where<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list2, (Func<OtherSystemSelectedVIiewModel, bool>)((OtherSystemSelectedVIiewModel m) => m.Selected)));
				}
			}
			int value4 = 0;
			string prjTitle = "";
			int value5 = 0;
			List<LkWSPreOrderInfoViewModel> list3 = new List<LkWSPreOrderInfoViewModel>();
			List<LkWSPreOrderItemsInfoViewModel> list4 = new List<LkWSPreOrderItemsInfoViewModel>();
			List<LkWSPreOrderPaymentsInfoViewModel> list5 = new List<LkWSPreOrderPaymentsInfoViewModel>();
			switch (linkAccSystemId)
			{
			case 18:
			{
				LkPreOrderInfoViewModelObjects noAvaranCapillaryPreOrderList = GetNoAvaranCapillaryPreOrderList(fDate, tDate, linkAccNumber);
				if (noAvaranCapillaryPreOrderList != null)
				{
					List<LkWSPreOrderInfoViewModel> lst4 = noAvaranCapillaryPreOrderList.lst;
					if (lst4 != null)
					{
						if (Enumerable.Any<LkWSPreOrderInfoViewModel>((IEnumerable<LkWSPreOrderInfoViewModel>)lst4))
						{
							if (list != null)
							{
								foreach (OtherSystemSelectedVIiewModel item in list)
								{
									LkWSPreOrderInfoViewModel lkWSPreOrderInfoViewModel4 = Enumerable.FirstOrDefault<LkWSPreOrderInfoViewModel>((IEnumerable<LkWSPreOrderInfoViewModel>)lst4, (Func<LkWSPreOrderInfoViewModel, bool>)((LkWSPreOrderInfoViewModel x) => x.pordLinkAccPreOrderIdStr == item.Id));
									if (lkWSPreOrderInfoViewModel4 != null)
									{
										list3.Add(lkWSPreOrderInfoViewModel4);
									}
								}
							}
							List<LkWSPreOrderItemsInfoViewModel> lstItems4 = noAvaranCapillaryPreOrderList.lstItems;
							if (list3 != null && Enumerable.Any<LkWSPreOrderInfoViewModel>((IEnumerable<LkWSPreOrderInfoViewModel>)list3) && lstItems4 != null && Enumerable.Any<LkWSPreOrderItemsInfoViewModel>((IEnumerable<LkWSPreOrderItemsInfoViewModel>)lstItems4))
							{
								foreach (LkWSPreOrderInfoViewModel ord in list3)
								{
									List<LkWSPreOrderItemsInfoViewModel> list9 = Enumerable.ToList<LkWSPreOrderItemsInfoViewModel>(Enumerable.Where<LkWSPreOrderItemsInfoViewModel>((IEnumerable<LkWSPreOrderItemsInfoViewModel>)lstItems4, (Func<LkWSPreOrderItemsInfoViewModel, bool>)((LkWSPreOrderItemsInfoViewModel m) => m.pordLinkAccPreOrderIdStr == ord.pordLinkAccPreOrderIdStr)));
									if (list9 != null && Enumerable.Any<LkWSPreOrderItemsInfoViewModel>((IEnumerable<LkWSPreOrderItemsInfoViewModel>)list9))
									{
										list4.AddRange(list9);
									}
								}
							}
						}
						else
						{
							string text12 = Messages.msgErrorRunFunction + " (get list from NoAvaran) ";
							Exception e10 = new Exception(text12);
							ErrorSignal.FromCurrentContext().Raise(e10);
							text = text12;
						}
					}
					else
					{
						string text13 = Messages.msgErrorRunFunction + " (get list from NoAvaran) ";
						Exception e11 = new Exception(text13);
						ErrorSignal.FromCurrentContext().Raise(e11);
						text = text13;
					}
				}
				else
				{
					string text14 = Messages.msgErrorRunFunction + " (get list from NoAvaran) ";
					Exception e12 = new Exception(text14);
					ErrorSignal.FromCurrentContext().Raise(e12);
					text = text14;
				}
				CRMIdeal.Classes.Helper.OtherSystems.NoAvaranCapillarySettingViewModel noAvaranCapillarySetting = CRMIdeal.Classes.Helper.OtherSystems.GetNoAvaranCapillarySetting();
				if (noAvaranCapillarySetting != null)
				{
					value4 = noAvaranCapillarySetting.DefCurrencyUnitId;
					prjTitle = noAvaranCapillarySetting.DefPrjTitle;
					value5 = noAvaranCapillarySetting.DefPrjCvnsStatusGroupId;
				}
				break;
			}
			case 20:
			{
				LkPreOrderInfoViewModelObjects nilramPreOrderList = GetNilramPreOrderList(fDate, tDate, linkAccNumber);
				if (nilramPreOrderList != null)
				{
					List<LkWSPreOrderInfoViewModel> lst2 = nilramPreOrderList.lst;
					if (lst2 != null)
					{
						if (Enumerable.Any<LkWSPreOrderInfoViewModel>((IEnumerable<LkWSPreOrderInfoViewModel>)lst2))
						{
							if (list != null)
							{
								foreach (OtherSystemSelectedVIiewModel item3 in list)
								{
									LkWSPreOrderInfoViewModel lkWSPreOrderInfoViewModel2 = Enumerable.FirstOrDefault<LkWSPreOrderInfoViewModel>((IEnumerable<LkWSPreOrderInfoViewModel>)lst2, (Func<LkWSPreOrderInfoViewModel, bool>)((LkWSPreOrderInfoViewModel x) => x.pordLinkAccPreOrderIdStr == item3.Id));
									if (lkWSPreOrderInfoViewModel2 != null)
									{
										list3.Add(lkWSPreOrderInfoViewModel2);
									}
								}
							}
							List<LkWSPreOrderItemsInfoViewModel> lstItems2 = nilramPreOrderList.lstItems;
							if (list3 != null && Enumerable.Any<LkWSPreOrderInfoViewModel>((IEnumerable<LkWSPreOrderInfoViewModel>)list3) && lstItems2 != null && Enumerable.Any<LkWSPreOrderItemsInfoViewModel>((IEnumerable<LkWSPreOrderItemsInfoViewModel>)lstItems2))
							{
								foreach (LkWSPreOrderInfoViewModel ord3 in list3)
								{
									List<LkWSPreOrderItemsInfoViewModel> list7 = Enumerable.ToList<LkWSPreOrderItemsInfoViewModel>(Enumerable.Where<LkWSPreOrderItemsInfoViewModel>((IEnumerable<LkWSPreOrderItemsInfoViewModel>)lstItems2, (Func<LkWSPreOrderItemsInfoViewModel, bool>)((LkWSPreOrderItemsInfoViewModel m) => m.pordLinkAccPreOrderIdStr == ord3.pordLinkAccPreOrderIdStr)));
									if (list7 != null && Enumerable.Any<LkWSPreOrderItemsInfoViewModel>((IEnumerable<LkWSPreOrderItemsInfoViewModel>)list7))
									{
										list4.AddRange(list7);
									}
								}
							}
							if (list3 != null && getPayFromLinkAcc && Enumerable.Any<LkWSPreOrderInfoViewModel>((IEnumerable<LkWSPreOrderInfoViewModel>)list3))
							{
								foreach (LkWSPreOrderInfoViewModel item5 in list3)
								{
									string text5 = (item5.pordDateTime.HasValue ? item5.pordDateTime.Value.ToString("yyyy/MM/dd") : "");
									List<LkWSPreOrderPaymentsInfoViewModel> nilramPreOrderPaymentsList = GetNilramPreOrderPaymentsList(text5, text5, item5.pordLinkAccPreOrderNumber ?? "");
									if (nilramPreOrderPaymentsList != null && Enumerable.Any<LkWSPreOrderPaymentsInfoViewModel>((IEnumerable<LkWSPreOrderPaymentsInfoViewModel>)nilramPreOrderPaymentsList))
									{
										list5.AddRange(nilramPreOrderPaymentsList);
									}
								}
							}
						}
						else
						{
							string text6 = Messages.msgErrorRunFunction + " (get list from Nilram) ";
							Exception e4 = new Exception(text6);
							ErrorSignal.FromCurrentContext().Raise(e4);
							text = text6;
						}
					}
					else
					{
						string text7 = Messages.msgErrorRunFunction + " (get list from Nilram) ";
						Exception e5 = new Exception(text7);
						ErrorSignal.FromCurrentContext().Raise(e5);
						text = text7;
					}
				}
				else
				{
					string text8 = Messages.msgErrorRunFunction + " (get list from Nilram) ";
					Exception e6 = new Exception(text8);
					ErrorSignal.FromCurrentContext().Raise(e6);
					text = text8;
				}
				CRMIdeal.Classes.Helper.OtherSystems.NilramSettingViewModel nilramSetting = CRMIdeal.Classes.Helper.OtherSystems.GetNilramSetting();
				if (nilramSetting != null)
				{
					value4 = nilramSetting.DefCurrencyUnitId;
					prjTitle = nilramSetting.DefPrjTitle;
					value5 = nilramSetting.DefPrjCvnsStatusGroupId;
				}
				break;
			}
			case 22:
			{
				LkPreOrderInfoViewModelObjects rahkaranInternalSalesPreOrderList = GetRahkaranInternalSalesPreOrderList(fDate, tDate, 0L);
				if (rahkaranInternalSalesPreOrderList != null)
				{
					List<LkWSPreOrderInfoViewModel> lst3 = rahkaranInternalSalesPreOrderList.lst;
					if (lst3 != null)
					{
						if (Enumerable.Any<LkWSPreOrderInfoViewModel>((IEnumerable<LkWSPreOrderInfoViewModel>)lst3))
						{
							if (list != null)
							{
								foreach (OtherSystemSelectedVIiewModel item2 in list)
								{
									LkWSPreOrderInfoViewModel lkWSPreOrderInfoViewModel3 = Enumerable.FirstOrDefault<LkWSPreOrderInfoViewModel>((IEnumerable<LkWSPreOrderInfoViewModel>)lst3, (Func<LkWSPreOrderInfoViewModel, bool>)((LkWSPreOrderInfoViewModel x) => x.pordLinkAccPreOrderIdStr == item2.Id));
									if (lkWSPreOrderInfoViewModel3 != null)
									{
										list3.Add(lkWSPreOrderInfoViewModel3);
									}
								}
							}
							List<LkWSPreOrderItemsInfoViewModel> lstItems3 = rahkaranInternalSalesPreOrderList.lstItems;
							if (list3 != null && Enumerable.Any<LkWSPreOrderInfoViewModel>((IEnumerable<LkWSPreOrderInfoViewModel>)list3) && lstItems3 != null && Enumerable.Any<LkWSPreOrderItemsInfoViewModel>((IEnumerable<LkWSPreOrderItemsInfoViewModel>)lstItems3))
							{
								foreach (LkWSPreOrderInfoViewModel ord2 in list3)
								{
									List<LkWSPreOrderItemsInfoViewModel> list8 = Enumerable.ToList<LkWSPreOrderItemsInfoViewModel>(Enumerable.Where<LkWSPreOrderItemsInfoViewModel>((IEnumerable<LkWSPreOrderItemsInfoViewModel>)lstItems3, (Func<LkWSPreOrderItemsInfoViewModel, bool>)((LkWSPreOrderItemsInfoViewModel m) => m.pordLinkAccPreOrderIdStr == ord2.pordLinkAccPreOrderIdStr)));
									if (list8 != null && Enumerable.Any<LkWSPreOrderItemsInfoViewModel>((IEnumerable<LkWSPreOrderItemsInfoViewModel>)list8))
									{
										list4.AddRange(list8);
									}
								}
							}
						}
						else
						{
							string text9 = Messages.msgErrorRunFunction + " (get list from Rahkaran) ";
							Exception e7 = new Exception(text9);
							ErrorSignal.FromCurrentContext().Raise(e7);
							text = text9;
						}
					}
					else
					{
						string text10 = Messages.msgErrorRunFunction + " (get list from Rahkaran) ";
						Exception e8 = new Exception(text10);
						ErrorSignal.FromCurrentContext().Raise(e8);
						text = text10;
					}
				}
				else
				{
					string text11 = Messages.msgErrorRunFunction + " (get list from Rahkaran) ";
					Exception e9 = new Exception(text11);
					ErrorSignal.FromCurrentContext().Raise(e9);
					text = text11;
				}
				CRMIdeal.Classes.Helper.OtherSystems.RahkaranInternalSalesProvider rahkaranInternalSalesProvider = new CRMIdeal.Classes.Helper.OtherSystems.RahkaranInternalSalesProvider();
				value4 = rahkaranInternalSalesProvider.DefCurrencyUnitId;
				prjTitle = rahkaranInternalSalesProvider.DefPrjTitle;
				value5 = rahkaranInternalSalesProvider.DefPrjCvnsStatusGroupId;
				break;
			}
			case 23:
			{
				LkPreOrderInfoViewModelObjects rayvarzPreOrderList = GetRayvarzPreOrderList(fDate, tDate, 0, isUpdateList: false, linkAccPageNum);
				if (rayvarzPreOrderList != null)
				{
					List<LkWSPreOrderInfoViewModel> lst = rayvarzPreOrderList.lst;
					if (lst != null)
					{
						if (Enumerable.Any<LkWSPreOrderInfoViewModel>((IEnumerable<LkWSPreOrderInfoViewModel>)lst))
						{
							if (list != null)
							{
								foreach (OtherSystemSelectedVIiewModel item4 in list)
								{
									LkWSPreOrderInfoViewModel lkWSPreOrderInfoViewModel = Enumerable.FirstOrDefault<LkWSPreOrderInfoViewModel>((IEnumerable<LkWSPreOrderInfoViewModel>)lst, (Func<LkWSPreOrderInfoViewModel, bool>)((LkWSPreOrderInfoViewModel x) => x.pordLinkAccPreOrderIdStr == item4.Id));
									if (lkWSPreOrderInfoViewModel != null)
									{
										list3.Add(lkWSPreOrderInfoViewModel);
									}
								}
							}
							List<LkWSPreOrderItemsInfoViewModel> lstItems = rayvarzPreOrderList.lstItems;
							if (list3 != null && Enumerable.Any<LkWSPreOrderInfoViewModel>((IEnumerable<LkWSPreOrderInfoViewModel>)list3) && lstItems != null && Enumerable.Any<LkWSPreOrderItemsInfoViewModel>((IEnumerable<LkWSPreOrderItemsInfoViewModel>)lstItems))
							{
								foreach (LkWSPreOrderInfoViewModel ord4 in list3)
								{
									List<LkWSPreOrderItemsInfoViewModel> list6 = Enumerable.ToList<LkWSPreOrderItemsInfoViewModel>(Enumerable.Where<LkWSPreOrderItemsInfoViewModel>((IEnumerable<LkWSPreOrderItemsInfoViewModel>)lstItems, (Func<LkWSPreOrderItemsInfoViewModel, bool>)((LkWSPreOrderItemsInfoViewModel m) => m.pordLinkAccPreOrderIdStr == ord4.pordLinkAccPreOrderIdStr)));
									if (list6 != null && Enumerable.Any<LkWSPreOrderItemsInfoViewModel>((IEnumerable<LkWSPreOrderItemsInfoViewModel>)list6))
									{
										list4.AddRange(list6);
									}
								}
							}
						}
						else
						{
							string text2 = Messages.msgErrorRunFunction + " (get list from Rayvarz) ";
							Exception e = new Exception(text2);
							ErrorSignal.FromCurrentContext().Raise(e);
							text = text2;
						}
					}
					else
					{
						string text3 = Messages.msgErrorRunFunction + " (get list from Rayvarz) ";
						Exception e2 = new Exception(text3);
						ErrorSignal.FromCurrentContext().Raise(e2);
						text = text3;
					}
				}
				else
				{
					string text4 = Messages.msgErrorRunFunction + " (get list from Rayvarz) ";
					Exception e3 = new Exception(text4);
					ErrorSignal.FromCurrentContext().Raise(e3);
					text = text4;
				}
				CRMIdeal.Classes.Helper.OtherSystems.RayvarzProvider rayvarzProvider = new CRMIdeal.Classes.Helper.OtherSystems.RayvarzProvider();
				value4 = rayvarzProvider.DefCurrencyUnitId;
				prjTitle = rayvarzProvider.DefPrjTitle;
				value5 = rayvarzProvider.DefPrjCvnsStatusGroupId;
				break;
			}
			}
			int result2 = 0;
			if (list3 != null && Enumerable.Any<LkWSPreOrderInfoViewModel>((IEnumerable<LkWSPreOrderInfoViewModel>)list3) && string.IsNullOrWhiteSpace(text))
			{
				int num2;
				int num3 = (num2 = Enumerable.Count<LkWSPreOrderInfoViewModel>((IEnumerable<LkWSPreOrderInfoViewModel>)list3));
				_ = new long[num3];
				int num4 = 100;
				int num5 = num3 / num4;
				int num6 = num3 % num4;
				int num7 = 0;
				int num8 = num4;
				if (num6 != 0)
				{
					num5++;
				}
				for (int i = 0; i < num5; i++)
				{
					if (i == num5 - 1 && num6 != 0)
					{
						num8 = num6;
					}
					List<LkWSPreOrderInfoViewModel> list10 = new List<LkWSPreOrderInfoViewModel>();
					for (int j = 0; j < num8; j++)
					{
						num7 = i * num4 + j;
						list10.Add(list3[num7]);
					}
					if (list10 == null || !Enumerable.Any<LkWSPreOrderInfoViewModel>((IEnumerable<LkWSPreOrderInfoViewModel>)list10))
					{
						continue;
					}
					string preOrderJson = JsonConvert.SerializeObject(list10);
					List<LkWSPreOrderItemsInfoViewModel> list11 = new List<LkWSPreOrderItemsInfoViewModel>();
					List<LkWSPreOrderPaymentsInfoViewModel> list12 = new List<LkWSPreOrderPaymentsInfoViewModel>();
					foreach (LkWSPreOrderInfoViewModel pord in list10)
					{
						if (list4 != null && Enumerable.Any<LkWSPreOrderItemsInfoViewModel>((IEnumerable<LkWSPreOrderItemsInfoViewModel>)list4))
						{
							List<LkWSPreOrderItemsInfoViewModel> list13 = Enumerable.ToList<LkWSPreOrderItemsInfoViewModel>(Enumerable.Where<LkWSPreOrderItemsInfoViewModel>((IEnumerable<LkWSPreOrderItemsInfoViewModel>)list4, (Func<LkWSPreOrderItemsInfoViewModel, bool>)((LkWSPreOrderItemsInfoViewModel m) => (m.pordLinkAccPreOrderIdStr ?? "") == (pord.pordLinkAccPreOrderIdStr ?? "") && (m.pordLinkAccPreOrderNumber ?? "") == (pord.pordLinkAccPreOrderNumber ?? ""))));
							if (list13 != null && Enumerable.Any<LkWSPreOrderItemsInfoViewModel>((IEnumerable<LkWSPreOrderItemsInfoViewModel>)list13))
							{
								list11.AddRange(list13);
							}
						}
						if (list5 != null && Enumerable.Any<LkWSPreOrderPaymentsInfoViewModel>((IEnumerable<LkWSPreOrderPaymentsInfoViewModel>)list5))
						{
							List<LkWSPreOrderPaymentsInfoViewModel> list14 = Enumerable.ToList<LkWSPreOrderPaymentsInfoViewModel>(Enumerable.Where<LkWSPreOrderPaymentsInfoViewModel>((IEnumerable<LkWSPreOrderPaymentsInfoViewModel>)list5, (Func<LkWSPreOrderPaymentsInfoViewModel, bool>)((LkWSPreOrderPaymentsInfoViewModel m) => (m.pordLinkAccPreOrderIdStr ?? "") == (pord.pordLinkAccPreOrderIdStr ?? "") && (m.pordLinkAccPreOrderNumber ?? "") == (pord.pordLinkAccPreOrderNumber ?? ""))));
							if (list14 != null && Enumerable.Any<LkWSPreOrderPaymentsInfoViewModel>((IEnumerable<LkWSPreOrderPaymentsInfoViewModel>)list14))
							{
								list12.AddRange(list14);
							}
						}
					}
					string preOrderItemJson = "";
					if (list11 != null && Enumerable.Any<LkWSPreOrderItemsInfoViewModel>((IEnumerable<LkWSPreOrderItemsInfoViewModel>)list11))
					{
						preOrderItemJson = JsonConvert.SerializeObject(list11);
					}
					string preOrderPaymentJson = "";
					if (getPayFromLinkAcc && payTypeId != 0 && list12 != null && Enumerable.Any<LkWSPreOrderPaymentsInfoViewModel>((IEnumerable<LkWSPreOrderPaymentsInfoViewModel>)list12))
					{
						preOrderPaymentJson = JsonConvert.SerializeObject(list12);
					}
					ObjectParameter objectParameter = new ObjectParameter("ErrorMessage", "");
					mct_Link_Result mct_Link_Result = Enumerable.FirstOrDefault<mct_Link_Result>((IEnumerable<mct_Link_Result>)_dbLink.CRMspLkWSIssueOrUpdatePreOrderByJson(linkAccSystemId, preOrderOprId, referUserId, whId, preOrderJson, preOrderItemJson, value4, value5, prjTitle, userId, id, value2, value3, value, registerDatePersian, appType, lCID, result, objectParameter, getPayFromLinkAcc, payTypeId, preOrderPaymentJson, centerId));
					string text15 = "";
					if (objectParameter.Value != null && !string.IsNullOrWhiteSpace(objectParameter.Value.ToString()))
					{
						text15 = objectParameter.Value.ToString();
						if (!string.IsNullOrWhiteSpace(text15))
						{
							string[] array = text15.Split(new char[1] { '|' });
							if (array != null)
							{
								if (array.Length > 1)
								{
									if (array[0] == "0")
									{
										string text16 = array[1];
										if (!string.IsNullOrWhiteSpace(text16))
										{
											List<LkErrorInfoViewModel> list15 = new JavaScriptSerializer().Deserialize<List<LkErrorInfoViewModel>>(text16);
											if (list15 != null && Enumerable.Any<LkErrorInfoViewModel>((IEnumerable<LkErrorInfoViewModel>)list15))
											{
												foreach (LkErrorInfoViewModel item6 in list15)
												{
													string text17 = "";
													if (!string.IsNullOrWhiteSpace(item6.Type))
													{
														if (item6.Type == "1")
														{
															text17 = Messages.msgerrorOtherSystemNotFindPordCmp;
															text17 = string.Format(text17, item6.Extra ?? "", item6.Number ?? "", "CRM");
														}
														else if (item6.Type == "2")
														{
															text17 = Messages.msgErrorOtherSystemNotDefinePordItems;
														}
														else if (item6.Type == "3")
														{
															text17 = Messages.msgerrorOtherSystemNotFindPrd;
															text17 = string.Format(text17, item6.Extra ?? "", item6.Number ?? "", "CRM");
														}
														else if (item6.Type == "4")
														{
															text17 = Messages.msgerrorOtherSystemNotFindPordItem;
															text17 = string.Format(text17, item6.Number ?? "");
														}
														else if (item6.Type == "5")
														{
															text17 = Messages.msgerrorOtherSystemNotInsertPordPrs;
															text17 = string.Format(text17, item6.Number ?? "");
														}
														else if (item6.Type == "6")
														{
															text17 = Messages.msgerrorOtherSystemNotInsertPordPrj;
															text17 = string.Format(text17, item6.Number ?? "");
														}
														else if (item6.Type == "7")
														{
															text17 = Messages.msgerrorOtherSystemNotInsertPord;
															text17 = string.Format(text17, item6.Number ?? "");
														}
														else if (item6.Type == "8")
														{
															text17 = Messages.msgerrorOtherSystemNotInsertPordItems;
															text17 = string.Format(text17, item6.Number ?? "");
														}
														else if (item6.Type == "9")
														{
															text17 = Messages.msgerrorOtherSystemNotInsertPordPayments;
															text17 = string.Format(text17, item6.Number ?? "");
														}
													}
													if (!string.IsNullOrWhiteSpace(text17))
													{
														text = text + "<br>" + text17;
													}
												}
											}
										}
									}
								}
								else if (!string.IsNullOrWhiteSpace(array[0]))
								{
									text = text + "<br>" + array[0];
								}
							}
						}
					}
					if (mct_Link_Result != null)
					{
						int.TryParse(mct_Link_Result.Result.ToString(), out result2);
					}
					int num9 = num7 * 100 / num2;
					if (num9 >= 100)
					{
						num9 = 100;
					}
					ProgressHub.SendMessage("ok", num9, userId);
				}
			}
			else
			{
				text = Messages.msgErrorRunFunction + " (" + Messages.ErrorNotFound + ")";
			}
			if (result2 == 0)
			{
				if (!string.IsNullOrWhiteSpace(text))
				{
					num = 0;
					commonResultStatusViewModel = CommonResultStatusViewModel.Fail;
					ProgressHub.SendMessage(text, 0, userId);
				}
				else
				{
					num = 0;
					commonResultStatusViewModel = CommonResultStatusViewModel.Fail;
					ProgressHub.SendMessage(Messages.msgErrorRunFunction, 0, userId);
				}
			}
			else
			{
				text = (string.IsNullOrWhiteSpace(text) ? "" : (Messages.msgOperationCompleted + "<br>" + Labels.Error + ":<br>" + text));
				num = 1;
				commonResultStatusViewModel = CommonResultStatusViewModel.Success;
			}
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductUnits");
		}
		catch (Exception e13)
		{
			ErrorSignal.FromCurrentContext().Raise(e13);
			num = 0;
			data = new CommonResultViewModel<int>
			{
				Data = num,
				Message = Messages.msgErrorRunFunction,
				Status = CommonResultStatusViewModel.Error
			};
			return Json(data, JsonRequestBehavior.AllowGet);
		}
		data = new CommonResultViewModel<int>
		{
			Data = num,
			Message = text,
			Status = commonResultStatusViewModel
		};
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmManagePordLinkAcc", ActionName = "actExportShowInfo")]
	public ActionResult ManageExportPreOrder_Read([DataSourceRequest] DataSourceRequest request, int oprId = 0, string fDate = "", string tDate = "", long value = 0L, int currentItemId = 0, string records = "")
	{
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		List<CRMspLkWSSelectPreOrder_Result> list = SelectPreOrderExport(oprId, fDate, tDate, value, currentItemId);
		List<OtherSystemSelectedViewModel> list2 = new List<OtherSystemSelectedViewModel>();
		OtherSystemSelectedViewModel item2 = new OtherSystemSelectedViewModel
		{
			Row = 0L,
			Id = 0,
			Selected = false
		};
		list2.Add(item2);
		if (list != null && Enumerable.Any<CRMspLkWSSelectPreOrder_Result>((IEnumerable<CRMspLkWSSelectPreOrder_Result>)list))
		{
			foreach (CRMspLkWSSelectPreOrder_Result item4 in list)
			{
				item4.pordDate = (item4.pordDateTime.HasValue ? item4.pordDateTime.Value.ToString("yyyy/MM/dd") : "");
				OtherSystemSelectedViewModel item3 = new OtherSystemSelectedViewModel
				{
					Row = item4.RowNumber.GetValueOrDefault(),
					Id = item4.PreOrderID,
					Selected = string.IsNullOrEmpty(item4.pordLinkAccPreOrderIdStr)
				};
				list2.Add(item3);
			}
			if (list2 != null && Enumerable.Any<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list2))
			{
				if (!string.IsNullOrWhiteSpace(records))
				{
					List<OtherSystemSelectedVIiewModel> list3 = new List<OtherSystemSelectedVIiewModel>();
					list3 = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedVIiewModel>>(records);
					if (list3 != null && Enumerable.Any<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list3))
					{
						foreach (OtherSystemSelectedVIiewModel item in list3)
						{
							if (Enumerable.FirstOrDefault<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list2, (Func<OtherSystemSelectedViewModel, bool>)((OtherSystemSelectedViewModel m) => m.Row == item.Row)) != null)
							{
								Enumerable.FirstOrDefault<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list2, (Func<OtherSystemSelectedViewModel, bool>)((OtherSystemSelectedViewModel m) => m.Row == item.Row)).Selected = item.Selected;
							}
						}
					}
				}
				int num = 0;
				if (request != null)
				{
					int page = request.Page;
					int pageSize = request.PageSize;
					if (page > 1)
					{
						num = page * pageSize - pageSize;
					}
				}
				string listItemRecords = JsonConvert.SerializeObject(Enumerable.ToList<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list2));
				if (Enumerable.Count<CRMspLkWSSelectPreOrder_Result>((IEnumerable<CRMspLkWSSelectPreOrder_Result>)list) >= num && list[num] != null)
				{
					list[num].ListItemRecords = listItemRecords;
				}
			}
		}
		if (list == null)
		{
			list = new List<CRMspLkWSSelectPreOrder_Result>();
		}
		JsonResult jsonResult = Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult GetManageExportPreOrderList(string records, int pordOprId, string fDate = "", string tDate = "", long value = 0L, int currentItemId = 0)
	{
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		List<OtherSystemSelectedViewModel> list = new List<OtherSystemSelectedViewModel>();
		try
		{
			List<CRMspLkWSSelectPreOrder_Result> list2 = SelectPreOrderExport(pordOprId, fDate, tDate, value, currentItemId);
			if (list2 != null && Enumerable.Any<CRMspLkWSSelectPreOrder_Result>((IEnumerable<CRMspLkWSSelectPreOrder_Result>)list2))
			{
				foreach (CRMspLkWSSelectPreOrder_Result item2 in list2)
				{
					OtherSystemSelectedViewModel item = new OtherSystemSelectedViewModel
					{
						Row = item2.RowNumber.GetValueOrDefault(),
						Id = item2.PreOrderID,
						Selected = string.IsNullOrEmpty(item2.pordLinkAccPreOrderIdStr)
					};
					list.Add(item);
				}
			}
			if (list != null)
			{
				if (!string.IsNullOrWhiteSpace(records))
				{
					List<OtherSystemSelectedVIiewModel> list3 = new List<OtherSystemSelectedVIiewModel>();
					list3 = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedVIiewModel>>(records);
					if (Enumerable.Any<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list3))
					{
						foreach (OtherSystemSelectedVIiewModel item3 in list3)
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
			else
			{
				list = new List<OtherSystemSelectedViewModel>();
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

	[DynamicAuthorize(ControllerName = "frmManagePordLinkAcc", ActionName = "actExportInfo")]
	[AjaxOnly]
	public string ManagePordExportInfo(string records, int pordOprId, string fDate, string tDate, long pordNumber, bool sendPordPayToAcc = false, int noAvIdCompany = 0, int noAvIdPart = 0, int noAvPrdGroup = 0, bool sendPordFilesToAcc = false, int currentItemId = 0, bool isPayCanceled = false, bool isHeadCanceled = false)
	{
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		int data = 0;
		string text = "";
		CommonResultStatusViewModel commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		try
		{
			int result2 = 0;
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result2);
			}
			CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
			DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(Financial.Get().Id.ToString());
			short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			List<OtherSystemSelectedViewModel> list = new List<OtherSystemSelectedViewModel>();
			if (!string.IsNullOrWhiteSpace(records))
			{
				list = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedViewModel>>(records);
				if (list != null)
				{
					list = Enumerable.ToList<OtherSystemSelectedViewModel>(Enumerable.Where<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list, (Func<OtherSystemSelectedViewModel, bool>)((OtherSystemSelectedViewModel x) => x.Selected && x.Id > 0)));
				}
			}
			text = "";
			int num = 0;
			if (Enumerable.Any<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list))
			{
				List<OtherSystemSelectedViewModel> list2 = Enumerable.ToList<OtherSystemSelectedViewModel>(Enumerable.Where<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list, (Func<OtherSystemSelectedViewModel, bool>)((OtherSystemSelectedViewModel m) => m.Selected && m.Id > 0)));
				if (Enumerable.Any<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list2) && list2 != null)
				{
					List<AdvanceResultViewModel> list3 = new List<AdvanceResultViewModel>();
					num = Enumerable.Count<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list2);
					int num2 = 0;
					foreach (OtherSystemSelectedViewModel item in list2)
					{
						string text2 = "";
						switch (result2)
						{
						case 18:
							text2 = NoAvaranCapillaryActSendToAcc(item.Id, noAvIdCompany, sendPordPayToAcc, noAvIdPart, noAvPrdGroup);
							break;
						case 21:
							list3.AddRange(new CRMIdeal.Classes.Helper.OtherSystems.HamyarProvider(false).SendPord(item.Id, sendPordPayToAcc, sendPordFilesToAcc));
							break;
						case 22:
							text2 = RahkaranInternalSalesActSendToAcc(item.Id, sendPordPayToAcc);
							break;
						case 23:
							text2 = RayvarzActSendToAcc(item.Id, sendPordPayToAcc, isPayCanceled, isHeadCanceled);
							break;
						}
						if (result2 == 21)
						{
							continue;
						}
						if (!string.IsNullOrWhiteSpace(text2))
						{
							string[] array = text2.Split(new char[1] { '|' });
							if (array == null)
							{
								continue;
							}
							if (array[0] == "1")
							{
								if (!string.IsNullOrWhiteSpace(array[1]))
								{
									num2++;
									int count = num2 * 100 / num;
									ProgressHub.SendMessage("ok", count, userId);
								}
								else
								{
									text = text + "<br>" + Messages.msgErrorRunFunction;
									num2++;
									int count2 = num2 * 100 / num;
									ProgressHub.SendMessage(Messages.msgErrorRunFunction, count2, userId);
								}
							}
							else
							{
								text = text + "<br>" + array[0];
								num2++;
								int count3 = num2 * 100 / num;
								ProgressHub.SendMessage(array[0], count3, userId);
							}
						}
						else
						{
							text = text + "<br>" + Messages.msgErrorRunFunction;
						}
					}
					if (list3.Count > 0)
					{
						text = JsonConvert.SerializeObject(list3);
					}
				}
				else
				{
					text = Messages.msgErrorRunFunction + " (" + Messages.msgErrorNotSelectedItem + ")";
				}
			}
			if (!string.IsNullOrEmpty(text))
			{
				data = 0;
				return JsonConvert.SerializeObject(new CommonResultViewModel<int>
				{
					Data = data,
					Message = text,
					Status = CommonResultStatusViewModel.Error
				});
			}
			text = "";
			commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			data = 0;
			return JsonConvert.SerializeObject(new CommonResultViewModel<int>
			{
				Data = data,
				Message = Messages.msgErrorRunFunction,
				Status = CommonResultStatusViewModel.Error
			});
		}
		return JsonConvert.SerializeObject(new CommonResultViewModel<int>
		{
			Data = data,
			Message = text,
			Status = commonResultStatusViewModel
		});
	}

	public ActionResult ManagePordPaySendToAcc(int linkAccSystemId, int mode, int pordId, int payId = 0)
	{
		base.ViewBag.Mode = mode;
		string text = "";
		string text2 = "";
		switch (mode)
		{
		case 1:
			text = "frmPreOrder";
			text2 = "actSendToAcc";
			break;
		case 2:
			text = "frmPreOrder";
			text2 = "actSendPayToAcc";
			break;
		case 3:
			text = "frmPreOrder";
			text2 = "actSendAllPayToAcc";
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
		if (linkAccSystemId == 18)
		{
			LinkAccNoAvCapillarySettingController linkAccNoAvCapillarySettingController = new LinkAccNoAvCapillarySettingController();
			base.ViewBag.NoAvCompany = linkAccNoAvCapillarySettingController.GetNoAvaranCapillaryCompanyList();
		}
		base.ViewBag.LinkAccSystemId = linkAccSystemId;
		return View();
	}

	[AjaxOnly]
	public string ManagePordPayExportInfo(int pordId, int payId = 0, int noAvIdCompany = 0, bool isPayCanceled = false)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string result2 = "";
		try
		{
			int result3 = 0;
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result3);
			}
			CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
			DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(Financial.Get().Id.ToString());
			short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			_ = UserLogin.CurrentUser.UserId;
			string text = "";
			switch (result3)
			{
			case 18:
				text = NoAvaranCapillaryActSendPaymentsToAcc(pordId, noAvIdCompany, payId);
				break;
			case 21:
				foreach (AdvanceResultViewModel item in new CRMIdeal.Classes.Helper.OtherSystems.HamyarProvider(false).SendPreOrderPay(pordId, null, null, null, payId))
				{
					text = text + string.Join("|", item.Errors) + "|";
				}
				break;
			case 22:
				text = RahkaranInternalSalesActSendPaymentsToAcc(pordId, payId);
				break;
			case 23:
				text = RayvarzActSendPaymentsToAcc(pordId, payId, isPayCanceled);
				break;
			}
			if (!string.IsNullOrWhiteSpace(text))
			{
				string[] array = text.Split(new char[1] { '|' });
				if (array != null)
				{
					if (array[0] == "1")
					{
						if (!string.IsNullOrWhiteSpace(array[1]))
						{
							if (payId != 0)
							{
								result2 = "1|" + string.Format(Labels.PordPayListAccLinkHeaderNumber, array[1]);
								string text2 = array[1];
								if (!string.IsNullOrWhiteSpace(text2) && text2 == "-100000")
								{
									result2 = "1|";
								}
							}
							else
							{
								result2 = "1|" + array[1];
							}
						}
						else
						{
							result2 = "1|" + Messages.msgOperationCompleted + "|";
						}
					}
					else
					{
						result2 = array[0] + "|";
					}
				}
			}
			else
			{
				result2 = Messages.msgErrorRunFunction + "|";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result2 = Messages.msgErrorRunFunction + "|";
		}
		return result2;
	}

	[AjaxOnly]
	public string ManagePordFileExportInfo(int pordId, int fileId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string result2 = "";
		try
		{
			int result3 = 0;
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result3);
			}
			CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
			DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(Financial.Get().Id.ToString());
			short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			_ = UserLogin.CurrentUser.UserId;
			if (result3 == 21)
			{
				result2 = new CRMIdeal.Classes.Helper.OtherSystems.HamyarProvider.SendPordFiles(pordId).SendAll(fileId, true);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result2 = Messages.msgErrorRunFunction + "|";
		}
		return result2;
	}

	[HttpPost]
	public JsonResult DeletePordImportedInfo(string records)
	{
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
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
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			new List<LinkedCompanyWithAccViewModel>();
			List<OtherSystemSelectedVIiewModel> list = new List<OtherSystemSelectedVIiewModel>();
			string text3 = "";
			int num = 0;
			if (!UserLogin.IsUserAccess("frmManagePordLinkAcc", "actDeleteImportedInfo", UserLogin.CurrentUser))
			{
				text3 = text3 + Messages.ErrorNotAccess + "<br>";
				num++;
			}
			if (string.IsNullOrWhiteSpace(records))
			{
				text3 = text3 + Messages.msgErrorNotSelectedItem + "<br>";
				num++;
			}
			else
			{
				List<OtherSystemSelectedVIiewModel> list2 = new List<OtherSystemSelectedVIiewModel>();
				if (!string.IsNullOrWhiteSpace(records))
				{
					list2 = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedVIiewModel>>(records);
					if (Enumerable.Any<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list2))
					{
						list = Enumerable.ToList<OtherSystemSelectedVIiewModel>(Enumerable.Where<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list2, (Func<OtherSystemSelectedVIiewModel, bool>)((OtherSystemSelectedVIiewModel m) => m.Selected)));
					}
				}
			}
			string text4 = "";
			if (list == null && !Enumerable.Any<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list))
			{
				text3 = Messages.msgErrorNotSelectedItem + "<br>";
				num++;
			}
			else
			{
				foreach (OtherSystemSelectedVIiewModel item in list)
				{
					text4 = text4 + item.Id + ",";
				}
			}
			if (string.IsNullOrWhiteSpace(text4))
			{
				text3 = Messages.msgErrorNotSelectedItem + "<br>";
				num++;
			}
			int result2 = 0;
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result2);
			}
			CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
			if (num == 0)
			{
				string text5 = "";
				text = "";
				List<CRMspLkWSDeleteLinkedPreOrder_Result> list3 = Enumerable.ToList<CRMspLkWSDeleteLinkedPreOrder_Result>((IEnumerable<CRMspLkWSDeleteLinkedPreOrder_Result>)_dbLink.CRMspLkWSDeleteLinkedPreOrder(result2, text4, lCID, result));
				if (list3 != null && Enumerable.Any<CRMspLkWSDeleteLinkedPreOrder_Result>((IEnumerable<CRMspLkWSDeleteLinkedPreOrder_Result>)list3))
				{
					text = "error";
					text5 = GetFileNotDeletedPordImportedInfo(list3);
				}
				if (!string.IsNullOrWhiteSpace(text5))
				{
					text2 = Messages.msgNotCompeleteSuccessAction;
					text2 = text2 + "<br><a href='" + text5 + "' class='link-excel-file' target='_blank'>" + Messages.msgLinkForDownloadFileWithError + "</a>";
				}
				else
				{
					text2 = Messages.msgSuccessAction;
				}
				commonResultStatusViewModel = CommonResultStatusViewModel.Success;
			}
			else
			{
				text = "";
				text2 = text3;
				commonResultStatusViewModel = CommonResultStatusViewModel.Error;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			text = "";
			data = new CommonResultViewModel<string>
			{
				Data = text,
				Message = Messages.msgErrorRunFunction + "<br>" + ex.Message,
				Status = CommonResultStatusViewModel.Error
			};
			return Json(data, JsonRequestBehavior.AllowGet);
		}
		data = new CommonResultViewModel<string>
		{
			Data = text,
			Message = text2,
			Status = commonResultStatusViewModel
		};
		JsonResult jsonResult = Json(data, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public string GetFileNotDeletedPordImportedInfo(List<CRMspLkWSDeleteLinkedPreOrder_Result> res)
	{
		//IL_037b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0396: Unknown result type (might be due to invalid IL or missing references)
		string text = "";
		Guid.NewGuid().ToString();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			int userId = UserLogin.CurrentUser.UserId;
			if (res != null && Enumerable.Any<CRMspLkWSDeleteLinkedPreOrder_Result>((IEnumerable<CRMspLkWSDeleteLinkedPreOrder_Result>)res))
			{
				int result2 = 0;
				string text2 = "";
				CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
				if (cRMspSelectCrmsysSetting_Result != null)
				{
					int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result2);
				}
				text2 = CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
				ExcelPackage excelPackage = new ExcelPackage();
				ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add(Labels.OtherSystemsExcelPropertiesTitle);
				int num = 0;
				int num2 = 1;
				num++;
				excelWorksheet.Cells[num2, num].Value = string.Format(Labels.OtherSystemsImListPordNumber, "CRM");
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsImListPordNumber + " (" + text2 + ")";
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsLinkedListCmpName;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListLinkDesc;
				foreach (CRMspLkWSDeleteLinkedPreOrder_Result re in res)
				{
					num2++;
					num = 0;
					num++;
					excelWorksheet.Cells[num2, num].Value = re.pordNumber.ToString();
					num++;
					excelWorksheet.Cells[num2, num].Value = re.pordLinkAccPreOrderNumber ?? "";
					num++;
					excelWorksheet.Cells[num2, num].Value = re.CompanyName ?? "";
					string redundancyMessage = Messages.RedundancyMessage;
					num++;
					excelWorksheet.Cells[num2, num].Value = redundancyMessage;
				}
				string text3 = base.Server.MapPath(Configuration.HostTempFilesPath) + "\\ReportLinkAccNotDeletedInfo\\" + userId;
				string text4 = "CRM-Ideal-" + DateTime.Now.ToString("dd-MM-yyyy-hh-mm-ss") + ".xls";
				string path = text3 + "\\" + text4;
				try
				{
					DirectoryInfo directoryInfo = new DirectoryInfo(text3);
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
					if (System.IO.Directory.Exists(text3))
					{
						System.IO.Directory.Delete(text3);
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
				}
				if (!System.IO.Directory.Exists(text3))
				{
					System.IO.Directory.CreateDirectory(text3);
					CRM.General.IO.Directory.SetFullControlForEveryOne(text3);
				}
				using (ExcelRange excelRange = excelWorksheet.Cells[1, 1, 1, num])
				{
					excelRange.Style.Font.Bold = true;
					excelRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
					excelRange.Style.Fill.BackgroundColor.SetColor(Color.DarkBlue);
					excelRange.Style.Font.Color.SetColor(Color.White);
				}
				excelPackage.Workbook.Properties.Title = Labels.OtherSystemsExcelPropertiesTitle;
				excelPackage.Workbook.Properties.Company = Labels.OtherSystemsExcelPropertiesCompany;
				Stream stream = System.IO.File.Create(path);
				excelPackage.SaveAs(stream);
				stream.Close();
				if (System.IO.File.Exists(path))
				{
					text = Configuration.HostTempFilesPath + "/ReportLinkAccNotDeletedInfo/" + userId + "/" + text4;
					text = text.Replace("~/", "/");
					text = (text.StartsWith("/") ? text : ("/" + text));
				}
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return text;
	}

	public List<CRMspSelectLinkAccSettingDB_Result> GetLinkAccHolooDatabases()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		List<CRMspSelectLinkAccSettingDB_Result> list2 = Enumerable.ToList<CRMspSelectLinkAccSettingDB_Result>((IEnumerable<CRMspSelectLinkAccSettingDB_Result>)_dbLink.CRMspSelectLinkAccSettingDB(4, null, lCID, result));
		if (list2 != null)
		{
			list.AddRange(Enumerable.Select<CRMspSelectLinkAccSettingDB_Result, SelectListItem>((IEnumerable<CRMspSelectLinkAccSettingDB_Result>)list2, (Func<CRMspSelectLinkAccSettingDB_Result, SelectListItem>)((CRMspSelectLinkAccSettingDB_Result item) => new SelectListItem
			{
				Text = item.LinkAccSettingDbTitle,
				Value = item.LinkAccSettingDBId.ToString(),
				Selected = false
			})));
		}
		base.ViewBag.LinkAccSettingDBList = list;
		return list2;
	}

	[DynamicAuthorize(ControllerName = "frmPreOrder", ActionName = "actSendToAcc,actSendPayToAcc,actSendAllPayToAcc")]
	public ActionResult HolooPordSendToAcc()
	{
		GetLinkAccHolooDatabases();
		return View();
	}

	[AjaxOnly]
	public string HolooActSendToAcc(int pordId, int oprType, int linkAccSettingDBId)
	{
		//IL_0748: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e1b: Unknown result type (might be due to invalid IL or missing references)
		string text = "";
		try
		{
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (!UserLogin.IsUserAccess("frmPreOrder", "actSendToAcc", currentUser))
			{
				return Messages.ErrorNotAccess + "|";
			}
			string value = "";
			string value2 = "";
			int result2 = 0;
			if (pordId > 0)
			{
				CRMspLkHolooWSSelectOrderByOrdIds_Result pord = Enumerable.FirstOrDefault<CRMspLkHolooWSSelectOrderByOrdIds_Result>((IEnumerable<CRMspLkHolooWSSelectOrderByOrdIds_Result>)_dbLink.CRMspLkHolooWSSelectOrderByOrdIds($"{pordId}", lCID, result, linkAccSettingDBId), (Func<CRMspLkHolooWSSelectOrderByOrdIds_Result, bool>)((CRMspLkHolooWSSelectOrderByOrdIds_Result c) => c.OrderID == pordId));
				if (pord != null)
				{
					string errorMessage = "";
					if (!PreOrder.SendToLinkAccNeedVerify(pordId, ref errorMessage))
					{
						return errorMessage + "|";
					}
					int.TryParse(pord.ordReferUserId.ToString(), out result2);
					if (result2 == 0)
					{
						return string.Format(Messages.msgErrorIsNotSelectedItem, string.Format(Labels.OtherSystemsReferUser, "CRM")) + "|";
					}
					CRMspSelectLinkAccSettingUsers_Result cRMspSelectLinkAccSettingUsers_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingUsers_Result>((IEnumerable<CRMspSelectLinkAccSettingUsers_Result>)_dbLink.CRMspSelectLinkAccSettingUsers(0, linkAccSettingDBId, result2, lCID, result));
					if (cRMspSelectLinkAccSettingUsers_Result != null)
					{
						value = cRMspSelectLinkAccSettingUsers_Result.UserName ?? "";
						value2 = ((!string.IsNullOrEmpty(cRMspSelectLinkAccSettingUsers_Result.Password)) ? XorCipher.DecryptByPrivateKey(cRMspSelectLinkAccSettingUsers_Result.Password) : string.Empty);
					}
					if (string.IsNullOrWhiteSpace(value) || string.IsNullOrWhiteSpace(value2))
					{
						return string.Format(Messages.msgErrorNotDefineLinkAccHolooSettingUsers, Labels.Holoo) + "|";
					}
					List<CRMspLkHolooWSSelectOrderItems_Result> list = Enumerable.ToList<CRMspLkHolooWSSelectOrderItems_Result>((IEnumerable<CRMspLkHolooWSSelectOrderItems_Result>)_dbLink.CRMspLkHolooWSSelectOrderItems(pordId, lCID, result, linkAccSettingDBId));
					if (list != null && Enumerable.Any<CRMspLkHolooWSSelectOrderItems_Result>((IEnumerable<CRMspLkHolooWSSelectOrderItems_Result>)list))
					{
						foreach (CRMspLkHolooWSSelectOrderItems_Result item in list)
						{
							if (string.IsNullOrWhiteSpace(item.PrdLinkAccPrdIdStr))
							{
								return string.Format(Messages.msgErrorInSendPordToAccLinkNotFoundPrdInAcc, pord.ordNumber, Labels.Holoo, item.PrdName ?? "") + "|";
							}
							if (item.ordIPrdUnitId.HasValue && string.IsNullOrWhiteSpace(item.UnitLinkAccUnitIdStr))
							{
								return string.Format(Messages.msgErrorInSendPordToAccLinkNotFoundPrdUnitInAcc, pord.ordNumber, Labels.Holoo, item.ordIPrdUnit ?? "") + "|";
							}
						}
					}
					string text2 = "";
					double value3 = 0.0;
					string text3 = "";
					CRMspSelectCompanyWithAccLinkField_Result cRMspSelectCompanyWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyWithAccLinkField_Result>((IEnumerable<CRMspSelectCompanyWithAccLinkField_Result>)_dbLink.CRMspSelectCompanyWithAccLinkField(false, false, false, true, lCID, result, linkAccSettingDBId), (Func<CRMspSelectCompanyWithAccLinkField_Result, bool>)((CRMspSelectCompanyWithAccLinkField_Result c) => c.CompanyID == pord.ordCompanyId));
					if (cRMspSelectCompanyWithAccLinkField_Result == null)
					{
						return Messages.CompanyNotFound + "|";
					}
					text3 = cRMspSelectCompanyWithAccLinkField_Result.cmpLinkAccCustomerIdStr ?? "";
					if (string.IsNullOrEmpty(text3))
					{
						CompanyController companyController = new CompanyController();
						int linkAccSettingDBId2 = linkAccSettingDBId;
						string text4 = companyController.HolooActCmpSendToAcc(pord.ordCompanyId, ispurchaser: true, isseller: false, 0, linkAccSettingDBId2);
						if (string.IsNullOrEmpty(text4))
						{
							return Messages.msgErrorRunFunction + "(insert company to holoo)|";
						}
						string[] array = text4.Split(new char[1] { '|' });
						if (array != null)
						{
							if (!(array[0] == "1"))
							{
								return array[0] + "|";
							}
							cRMspSelectCompanyWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyWithAccLinkField_Result>((IEnumerable<CRMspSelectCompanyWithAccLinkField_Result>)_dbLink.CRMspSelectCompanyWithAccLinkField(false, false, false, true, lCID, result, linkAccSettingDBId), (Func<CRMspSelectCompanyWithAccLinkField_Result, bool>)((CRMspSelectCompanyWithAccLinkField_Result c) => c.CompanyID == pord.ordCompanyId));
							if (cRMspSelectCompanyWithAccLinkField_Result == null)
							{
								return Messages.CompanyNotFound + "|";
							}
							text3 = cRMspSelectCompanyWithAccLinkField_Result.cmpLinkAccCustomerIdStr ?? "";
						}
					}
					if (string.IsNullOrEmpty(text3))
					{
						return string.Format(Messages.msgErrorInSendToAccLinkNotFoundCmpInAcc, Labels.Holoo);
					}
					DateTime dateTime = default(DateTime);
					string date = "";
					string time = "";
					try
					{
						if (pord.ordDateTime.HasValue)
						{
							date = (pord.ordDateTime.HasValue ? pord.ordDateTime.Value.ToString("yyyy-MM-dd", new CultureInfo("en-US")) : "");
							time = (pord.ordDateTime.HasValue ? pord.ordDateTime.Value.ToString("HH:mm") : "");
						}
						else if (!string.IsNullOrEmpty(pord.ordDate))
						{
							dateTime = DateTime.Parse(PersianDate.GetFormatetdDate(pord.ordDate.Replace("/", "")) + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
							date = dateTime.ToString("yyyy-MM-dd", new CultureInfo("en-US"));
							time = dateTime.ToString("HH:mm");
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						return Messages.WrongPordDateTime;
					}
					string text5 = pord.ordLinkAccTransferKey ?? "";
					string text6 = pord.ordLinkAccTransferResult ?? "";
					bool isReCheckSent = true;
					CRMIdeal.Classes.Helper.OtherSystems.HolooProvider holooProvider = new CRMIdeal.Classes.Helper.OtherSystems.HolooProvider(linkAccSettingDBId);
					bool sendPrdUnitToApi = holooProvider.SendPrdUnitToApi;
					bool sendTaxAndDutyPercentToApi = holooProvider.SendTaxAndDutyPercentToApi;
					int taxCalculateType = holooProvider.TaxCalculateType;
					HolooInvoiceIEViewModel holooInvoiceIEViewModel = new HolooInvoiceIEViewModel();
					holooInvoiceIEViewModel.invoiceinfo = new List<HolooInvoiceInfoIEViewModel>();
					if (!string.IsNullOrEmpty(pord.ordLinkAccOrderIdStr))
					{
						_ = pord.ordLinkAccOrderIdStr;
						return string.Format(Messages.msgErrorNotReSendPordToOtherSystem, pord.ordNumber.ToString(), Labels.Holoo) + "|";
					}
					if (!string.IsNullOrWhiteSpace(text5))
					{
						new JavaScriptSerializer().Deserialize<List<HolooInvoiceInfoIETransferKeyViewModel>>(text5);
						string linkAccPreOrderNumber = "";
						string linkAccVoucherNumber = "";
						string linkAccPreOrderIdStr = "";
						string text7 = CheckPreOrderInHoloo(pordId, linkAccSettingDBId, text5, ref linkAccPreOrderNumber, ref linkAccVoucherNumber, ref linkAccPreOrderIdStr, result2);
						if (!string.IsNullOrWhiteSpace(text7))
						{
							if (text7 == "Ok")
							{
								string text8 = linkAccVoucherNumber ?? "";
								return "1|" + text8;
							}
							if (text7 != "-1")
							{
								return Messages.msgErrorRunFunction;
							}
						}
					}
					string text9 = holooProvider.Authenticate();
					if (!string.IsNullOrEmpty(text9))
					{
						return text9;
					}
					HolooInvoiceInfoIEViewModel holooInvoiceInfoIEViewModel = new HolooInvoiceInfoIEViewModel
					{
						id = pord.OrderID.ToString(),
						comment = pord.ordDescriptionII,
						customererpcode = text3,
						date = date,
						time = time,
						discount = pord.ordDiscount,
						Nesiyeh = pord.ordTotalAmount.GetValueOrDefault()
					};
					if (!string.IsNullOrWhiteSpace(text2))
					{
						holooInvoiceInfoIEViewModel.midManErpCode = text2 ?? "";
						holooInvoiceInfoIEViewModel.commission = value3;
					}
					holooInvoiceInfoIEViewModel.detailinfo = new List<HolooInvoiceDetailInfoIEViewModel>();
					decimal num = default(decimal);
					decimal num2 = default(decimal);
					decimal num3 = default(decimal);
					if (list != null && Enumerable.Any<CRMspLkHolooWSSelectOrderItems_Result>((IEnumerable<CRMspLkHolooWSSelectOrderItems_Result>)list))
					{
						foreach (CRMspLkHolooWSSelectOrderItems_Result item2 in list)
						{
							HolooInvoiceDetailInfoIEViewModel holooInvoiceDetailInfoIEViewModel = new HolooInvoiceDetailInfoIEViewModel();
							string text10 = item2.PrdLinkAccPrdIdStr ?? "";
							string text11 = item2.UnitLinkAccUnitIdStr ?? "";
							if (!string.IsNullOrEmpty(text10))
							{
								holooInvoiceDetailInfoIEViewModel.id = item2.OrderItemID.ToString();
								holooInvoiceDetailInfoIEViewModel.producterpcode = text10;
								holooInvoiceDetailInfoIEViewModel.few = item2.ordIQuantity.GetValueOrDefault(1.0) * item2.ordIFCR.GetValueOrDefault(1.0) * item2.ordIFCRI.GetValueOrDefault(1.0);
								if (!string.IsNullOrWhiteSpace(text11) && sendPrdUnitToApi)
								{
									holooInvoiceDetailInfoIEViewModel.few = item2.ordIQuantity.GetValueOrDefault(1.0);
								}
								holooInvoiceDetailInfoIEViewModel.price = item2.ordIPrice.GetValueOrDefault();
								_ = (decimal)(item2.ordIQuantity.GetValueOrDefault(1.0) * item2.ordIFCR.GetValueOrDefault(1.0) * item2.ordIFCRI.GetValueOrDefault(1.0));
								_ = item2.ordIPrice.GetValueOrDefault() - item2.ordIDiscount.GetValueOrDefault() - item2.ordIRound.GetValueOrDefault() + item2.ordIRoundPlus.GetValueOrDefault();
								holooInvoiceDetailInfoIEViewModel.discountprice = item2.ordIDiscountSum.GetValueOrDefault();
								holooInvoiceDetailInfoIEViewModel.discountpercent = item2.ordIDiscountPercent.GetValueOrDefault();
								num += holooInvoiceDetailInfoIEViewModel.discountprice.GetValueOrDefault();
								if (item2.ordIDiscountSum.GetValueOrDefault() > 0m)
								{
									holooInvoiceDetailInfoIEViewModel.discountpercent = item2.ordIDiscountPercent.GetValueOrDefault();
								}
								else
								{
									holooInvoiceDetailInfoIEViewModel.discountprice = default(decimal);
								}
								num2 += item2.ordIPriceSum.GetValueOrDefault();
								holooInvoiceDetailInfoIEViewModel.comment = item2.ordIDescription ?? "";
								if (!string.IsNullOrWhiteSpace(text11) && sendPrdUnitToApi)
								{
									holooInvoiceDetailInfoIEViewModel.unitid = text11 ?? "";
								}
								decimal value4 = default(decimal);
								decimal num4 = default(decimal);
								if (sendTaxAndDutyPercentToApi)
								{
									if (item2.ordITaxSum.GetValueOrDefault() > 0m)
									{
										value4 = item2.ordITaxIndex.GetValueOrDefault();
									}
									num4 = default(decimal);
									holooInvoiceDetailInfoIEViewModel.levy = value4;
									holooInvoiceDetailInfoIEViewModel.scot = num4;
									num3 += item2.ordITaxSum.GetValueOrDefault();
								}
								else
								{
									value4 = item2.ordITaxSum.GetValueOrDefault();
									num4 = default(decimal);
									num3 += value4 + num4;
									holooInvoiceDetailInfoIEViewModel.levy = value4;
									holooInvoiceDetailInfoIEViewModel.scot = num4;
								}
								holooInvoiceInfoIEViewModel.detailinfo.Add(holooInvoiceDetailInfoIEViewModel);
								continue;
							}
							return Messages.msgErrorRunFunction + " (Error in create json)";
						}
					}
					holooInvoiceInfoIEViewModel.discount = holooInvoiceInfoIEViewModel.discount.GetValueOrDefault() + num;
					switch (taxCalculateType)
					{
					case 1:
						holooInvoiceInfoIEViewModel.Nesiyeh = num2 - pord.ordDiscount.GetValueOrDefault();
						break;
					case 2:
						holooInvoiceInfoIEViewModel.Nesiyeh = num2 + num3 - pord.ordDiscount.GetValueOrDefault();
						break;
					}
					holooInvoiceIEViewModel.invoiceinfo.Add(holooInvoiceInfoIEViewModel);
					HolooInvoiceInfoIETransferKeyViewModel holooInvoiceInfoIETransferKeyViewModel = new HolooInvoiceInfoIETransferKeyViewModel();
					if (holooInvoiceInfoIEViewModel != null)
					{
						holooInvoiceInfoIETransferKeyViewModel.DBId = linkAccSettingDBId;
						holooInvoiceInfoIETransferKeyViewModel.type = holooInvoiceInfoIEViewModel.type;
						holooInvoiceInfoIETransferKeyViewModel.customererpcode = holooInvoiceInfoIEViewModel.customererpcode;
						holooInvoiceInfoIETransferKeyViewModel.date = holooInvoiceInfoIEViewModel.date;
						holooInvoiceInfoIETransferKeyViewModel.time = holooInvoiceInfoIEViewModel.time;
						holooInvoiceInfoIETransferKeyViewModel.Nesiyeh = holooInvoiceInfoIEViewModel.Nesiyeh;
					}
					text5 = JsonConvert.SerializeObject(holooInvoiceInfoIETransferKeyViewModel);
					if (!string.IsNullOrWhiteSpace(text5))
					{
						if (!text5.StartsWith("["))
						{
							text5 = "[" + text5;
						}
						if (!text5.EndsWith("]"))
						{
							text5 += "]";
						}
					}
					string code = "";
					string errorMessage2 = "";
					holooProvider.SendOrderToAcc(holooInvoiceIEViewModel, pord, ref text5, ref isReCheckSent, ref errorMessage2, ref code);
					if (!string.IsNullOrEmpty(errorMessage2))
					{
						return errorMessage2;
					}
					text = "1|" + code;
					if (!string.IsNullOrWhiteSpace(text5) && isReCheckSent)
					{
						new JavaScriptSerializer().Deserialize<List<HolooInvoiceInfoIETransferKeyViewModel>>(text5);
						string linkAccPreOrderNumber2 = "";
						string linkAccVoucherNumber2 = "";
						string linkAccPreOrderIdStr2 = "";
						string text12 = CheckPreOrderInHoloo(pordId, linkAccSettingDBId, text5, ref linkAccPreOrderNumber2, ref linkAccVoucherNumber2, ref linkAccPreOrderIdStr2, result2);
						if (!string.IsNullOrWhiteSpace(text12) && text12 == "Ok")
						{
							string text13 = linkAccVoucherNumber2 ?? "";
							return "1|" + text13;
						}
					}
					if (!string.IsNullOrWhiteSpace(text))
					{
						string[] array2 = text.Split(new char[1] { '|' });
						if (array2 != null)
						{
							string text14 = array2[0];
							text14 = text14 ?? "'";
							if (text14 != "1" && !string.IsNullOrWhiteSpace(text14))
							{
								HolooInvoiceInfoIETransferResultViewModel holooInvoiceInfoIETransferResultViewModel = new HolooInvoiceInfoIETransferResultViewModel();
								if (holooInvoiceInfoIEViewModel != null)
								{
									holooInvoiceInfoIETransferResultViewModel.DBId = linkAccSettingDBId;
									holooInvoiceInfoIETransferResultViewModel.Message = text14;
								}
								text6 = JsonConvert.SerializeObject(holooInvoiceInfoIETransferResultViewModel);
								if (!string.IsNullOrWhiteSpace(text6))
								{
									if (!text6.StartsWith("["))
									{
										text6 = "[" + text6;
									}
									if (!text6.EndsWith("]"))
									{
										text6 += "]";
									}
								}
								string text15 = "[PordId=" + pord.OrderID + "|,|LinkAccTransferKey=" + ((!string.IsNullOrWhiteSpace(text5)) ? text5 : "") + "|,|LinkAccTransferResult=" + ((!string.IsNullOrWhiteSpace(text6)) ? text6 : "") + "|,|]@";
								if (!string.IsNullOrEmpty(text15))
								{
									Enumerable.FirstOrDefault<mct_Link_Result>((IEnumerable<mct_Link_Result>)_dbLink.CRMspLkHolooWSUpdateOrderLinkAccFields(text15, linkAccSettingDBId));
								}
							}
						}
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
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			text = Messages.msgErrorRunFunction + "|";
		}
		return text;
	}

	[DynamicAuthorize(ControllerName = "frmOrder", ActionName = "actExportToAcc")]
	public ActionResult HolooExportPreOrder()
	{
		GetPreOrderOpr();
		GetPordReferUser();
		GetLinkAccHolooDatabases();
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmExportToAcc", ActionName = "actShowInfo")]
	public ActionResult HolooExportPreOrder_Read([DataSourceRequest] DataSourceRequest request, int linkAccSettingDBId, int pageNumber, int pordOprId, string fDate = "", string tDate = "", int value = 0, int pordReferUserId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SepOrderViewModel> list = new List<SepOrderViewModel>();
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
			foreach (CRMspLkHolooWSSelectOrder_Result item2 in Enumerable.ToList<CRMspLkHolooWSSelectOrder_Result>((IEnumerable<CRMspLkHolooWSSelectOrder_Result>)_dbLink.CRMspLkHolooWSSelectOrder(UserLogin.CurrentUser.UserId, pordOprId, (!string.IsNullOrEmpty(fDate)) ? new DateTime?(value3) : null, (!string.IsNullOrEmpty(tDate)) ? new DateTime?(value4) : null, value, pageNumber, value2, lCID, result, pordReferUserId, result2, linkAccSettingDBId)))
			{
				SepOrderViewModel item = new SepOrderViewModel
				{
					ordLinkAccOrderId = item2.ordLinkAccOrderId,
					ordLinkAccOrderIdStr = item2.ordLinkAccOrderIdStr,
					Company = ((!string.IsNullOrEmpty(item2.CompanyName)) ? item2.CompanyName : "") + ((!string.IsNullOrEmpty(item2.CompanyPerson)) ? (" - " + item2.CompanyPerson) : ""),
					OrdNumber = item2.ordNumber,
					Date = item2.ordDateTime,
					DatePersian = (item2.ordDateTime.HasValue ? item2.ordDateTime.Value.ToString("yyyy/MM/dd") : ""),
					ordTotalAmount = item2.ordTotalAmount,
					ItemCount = item2.ordItemCount,
					OrderId = item2.OrderID,
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

	[DynamicAuthorize(ControllerName = "frmExportToAcc", ActionName = "actSendToAcc")]
	[AjaxOnly]
	public JsonResult HolooExportInfo(string records, int totalPage, int linkAccSettingDBId, int pordReferUserId = 0)
	{
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0839: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int num = 0;
		string text = "";
		CommonResultStatusViewModel commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		CommonResultViewModel<int> data;
		try
		{
			DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			_ = Financial.Get().Id;
			short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			text = "";
			int num2 = 0;
			string value = "";
			string value2 = "";
			if (pordReferUserId == 0)
			{
				num = 0;
				data = new CommonResultViewModel<int>
				{
					Data = num,
					Message = string.Format(Messages.msgErrorIsNotSelectedItem, string.Format(Labels.OtherSystemsReferUser, "CRM")),
					Status = CommonResultStatusViewModel.Error
				};
				return Json(data, JsonRequestBehavior.AllowGet);
			}
			CRMspSelectLinkAccSettingUsers_Result cRMspSelectLinkAccSettingUsers_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingUsers_Result>((IEnumerable<CRMspSelectLinkAccSettingUsers_Result>)_dbLink.CRMspSelectLinkAccSettingUsers(0, linkAccSettingDBId, pordReferUserId, lCID, result));
			if (cRMspSelectLinkAccSettingUsers_Result != null)
			{
				value = cRMspSelectLinkAccSettingUsers_Result.UserName ?? "";
				value2 = ((!string.IsNullOrEmpty(cRMspSelectLinkAccSettingUsers_Result.Password)) ? XorCipher.DecryptByPrivateKey(cRMspSelectLinkAccSettingUsers_Result.Password) : string.Empty);
			}
			if (string.IsNullOrWhiteSpace(value) || string.IsNullOrWhiteSpace(value2))
			{
				num = 0;
				data = new CommonResultViewModel<int>
				{
					Data = num,
					Message = string.Format(Messages.msgErrorNotDefineLinkAccHolooSettingUsers, Labels.Holoo),
					Status = CommonResultStatusViewModel.Error
				};
				return Json(data, JsonRequestBehavior.AllowGet);
			}
			string text2 = "";
			List<OtherSystemSelectedViewModel> list = new List<OtherSystemSelectedViewModel>();
			List<OtherSystemSelectedViewModel> list2 = new List<OtherSystemSelectedViewModel>();
			if (!string.IsNullOrWhiteSpace(records))
			{
				list = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedViewModel>>(records);
				if (Enumerable.Any<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list))
				{
					list2 = Enumerable.ToList<OtherSystemSelectedViewModel>(Enumerable.Where<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list, (Func<OtherSystemSelectedViewModel, bool>)((OtherSystemSelectedViewModel m) => m.Selected && m.Id > 0)));
					if (Enumerable.Any<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list2))
					{
						foreach (OtherSystemSelectedViewModel item2 in list2)
						{
							if (item2.Selected)
							{
								text2 = text2 + item2.Id + ",";
							}
						}
					}
				}
			}
			int num3 = 0;
			decimal num4 = default(decimal);
			decimal num5 = default(decimal);
			bool flag = false;
			bool flag2 = false;
			CRMIdeal.Classes.Helper.OtherSystems.HolooProvider holooProvider = new CRMIdeal.Classes.Helper.OtherSystems.HolooProvider(linkAccSettingDBId);
			num3 = holooProvider.TaxCalculateType;
			num5 = holooProvider.DutyPercent;
			flag = holooProvider.SendTaxAndDutyPercentToApi;
			flag2 = holooProvider.SendPrdUnitToApi;
			string text3 = holooProvider.Authenticate();
			if (!string.IsNullOrEmpty(text3))
			{
				text = text3;
			}
			num3 = ((num3 == 0) ? 1 : num3);
			num4 = ((num4 == 0m) ? 6m : num4);
			num5 = ((num5 == 0m) ? 3m : num5);
			if (!string.IsNullOrEmpty(text))
			{
				num = 0;
				data = new CommonResultViewModel<int>
				{
					Data = num,
					Message = text,
					Status = CommonResultStatusViewModel.Error
				};
				return Json(data, JsonRequestBehavior.AllowGet);
			}
			List<CRMspLkHolooWSSelectOrderByOrdIds_Result> list3 = Enumerable.ToList<CRMspLkHolooWSSelectOrderByOrdIds_Result>((IEnumerable<CRMspLkHolooWSSelectOrderByOrdIds_Result>)_dbLink.CRMspLkHolooWSSelectOrderByOrdIds(text2, lCID, result, linkAccSettingDBId));
			List<HolooInvoiceInfoListTransferKeyViewModel> transferkeys = new List<HolooInvoiceInfoListTransferKeyViewModel>();
			if (list3 != null && Enumerable.Any<CRMspLkHolooWSSelectOrderByOrdIds_Result>((IEnumerable<CRMspLkHolooWSSelectOrderByOrdIds_Result>)list3))
			{
				num2 = Enumerable.Count<CRMspLkHolooWSSelectOrderByOrdIds_Result>((IEnumerable<CRMspLkHolooWSSelectOrderByOrdIds_Result>)list3);
				int num6 = 200;
				int num7 = Enumerable.Count<CRMspLkHolooWSSelectOrderByOrdIds_Result>((IEnumerable<CRMspLkHolooWSSelectOrderByOrdIds_Result>)list3);
				int num8 = num7 / num6;
				int num9 = num7 % num6;
				if (num9 != 0)
				{
					num8++;
				}
				int num10 = 0;
				int num11 = num6;
				for (int i = 0; i < num8; i++)
				{
					HolooInvoiceIEViewModel invoice = new HolooInvoiceIEViewModel();
					invoice.invoiceinfo = new List<HolooInvoiceInfoIEViewModel>();
					num11 = ((i == num8 - 1 && num9 != 0) ? num9 : num6);
					for (int j = 0; j < num11; j++)
					{
						int index = i * num6 + j;
						CRMspLkHolooWSSelectOrderByOrdIds_Result cRMspLkHolooWSSelectOrderByOrdIds_Result = list3[index];
						if (cRMspLkHolooWSSelectOrderByOrdIds_Result == null)
						{
							continue;
						}
						string errorMessage = "";
						if (!Order.SendToLinkAccNeedVerify(cRMspLkHolooWSSelectOrderByOrdIds_Result.OrderID, ref errorMessage))
						{
							text = text + errorMessage + "<br>";
							continue;
						}
						List<CRMspLkHolooWSSelectOrderItems_Result> list4 = Enumerable.ToList<CRMspLkHolooWSSelectOrderItems_Result>((IEnumerable<CRMspLkHolooWSSelectOrderItems_Result>)_dbLink.CRMspLkHolooWSSelectOrderItems(cRMspLkHolooWSSelectOrderByOrdIds_Result.OrderID, lCID, result, linkAccSettingDBId));
						if (list4 != null && Enumerable.Any<CRMspLkHolooWSSelectOrderItems_Result>((IEnumerable<CRMspLkHolooWSSelectOrderItems_Result>)list4))
						{
							foreach (CRMspLkHolooWSSelectOrderItems_Result item3 in list4)
							{
								if (string.IsNullOrWhiteSpace(item3.PrdLinkAccPrdIdStr))
								{
									text = text + string.Format(Messages.msgErrorInSendPordToAccLinkNotFoundPrdInAcc, cRMspLkHolooWSSelectOrderByOrdIds_Result.ordNumber, Labels.Holoo, item3.PrdName ?? "") + "<br>";
								}
								else if (item3.ordIPrdUnitId.HasValue && string.IsNullOrWhiteSpace(item3.UnitLinkAccUnitIdStr))
								{
									text = text + string.Format(Messages.msgErrorInSendPordToAccLinkNotFoundPrdUnitInAcc, cRMspLkHolooWSSelectOrderByOrdIds_Result.ordNumber, Labels.Holoo, item3.ordIPrdUnit ?? "") + "<br>";
								}
							}
						}
						string text4 = "";
						double value3 = 0.0;
						string text5 = cRMspLkHolooWSSelectOrderByOrdIds_Result.cmpLinkAccCustomerIdStr ?? "";
						if (string.IsNullOrEmpty(text5))
						{
							CompanyController companyController = new CompanyController();
							int linkAccSettingDBId2 = linkAccSettingDBId;
							string text6 = companyController.HolooActCmpSendToAcc(cRMspLkHolooWSSelectOrderByOrdIds_Result.ordCompanyId, ispurchaser: true, isseller: false, 0, linkAccSettingDBId2);
							if (string.IsNullOrEmpty(text6))
							{
								text = text + Messages.msgErrorRunFunction + "(insert company to holoo)<br>";
								continue;
							}
							string[] array = text6.Split(new char[1] { '|' });
							if (array != null)
							{
								if (!(array[0] == "1"))
								{
									text = text + array[0] + "<br>";
									continue;
								}
								CRMspLkHolooSelectCompanyByCmpIds_Result cRMspLkHolooSelectCompanyByCmpIds_Result = Enumerable.FirstOrDefault<CRMspLkHolooSelectCompanyByCmpIds_Result>((IEnumerable<CRMspLkHolooSelectCompanyByCmpIds_Result>)_dbLink.CRMspLkHolooSelectCompanyByCmpIds(cRMspLkHolooWSSelectOrderByOrdIds_Result.ordCompanyId.ToString(), lCID, result, linkAccSettingDBId));
								if (cRMspLkHolooSelectCompanyByCmpIds_Result == null)
								{
									text = text + Messages.CompanyNotFound + "<br>";
									continue;
								}
								text5 = cRMspLkHolooSelectCompanyByCmpIds_Result.cmpLinkAccCustomerIdStr ?? "";
							}
						}
						DateTime dateTime = default(DateTime);
						string date = "";
						string time = "";
						try
						{
							if (cRMspLkHolooWSSelectOrderByOrdIds_Result.ordDateTime.HasValue)
							{
								date = (cRMspLkHolooWSSelectOrderByOrdIds_Result.ordDateTime.HasValue ? cRMspLkHolooWSSelectOrderByOrdIds_Result.ordDateTime.Value.ToString("yyyy-MM-dd", new CultureInfo("en-US")) : "");
								time = (cRMspLkHolooWSSelectOrderByOrdIds_Result.ordDateTime.HasValue ? cRMspLkHolooWSSelectOrderByOrdIds_Result.ordDateTime.Value.ToString("HH:mm") : "");
							}
							else if (!string.IsNullOrEmpty(cRMspLkHolooWSSelectOrderByOrdIds_Result.ordDate))
							{
								dateTime = DateTime.Parse(PersianDate.GetFormatetdDate(cRMspLkHolooWSSelectOrderByOrdIds_Result.ordDate.Replace("/", "")) + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
								date = dateTime.ToString("yyyy-MM-dd", new CultureInfo("en-US"));
								time = dateTime.ToString("HH:mm");
							}
						}
						catch (Exception e)
						{
							ErrorSignal.FromCurrentContext().Raise(e);
							text = text + Messages.WrongPordDateTime + "<br>";
							continue;
						}
						string text7 = cRMspLkHolooWSSelectOrderByOrdIds_Result.ordLinkAccTransferKey ?? "";
						_ = cRMspLkHolooWSSelectOrderByOrdIds_Result.ordLinkAccTransferResult;
						if (!string.IsNullOrEmpty(cRMspLkHolooWSSelectOrderByOrdIds_Result.ordLinkAccOrderIdStr))
						{
							_ = cRMspLkHolooWSSelectOrderByOrdIds_Result.ordLinkAccOrderIdStr;
							text = text + string.Format(Messages.msgErrorNotReSendPordToOtherSystem, cRMspLkHolooWSSelectOrderByOrdIds_Result.ordNumber.ToString(), Labels.Holoo) + "<br>";
							continue;
						}
						if (!string.IsNullOrWhiteSpace(text7))
						{
							new JavaScriptSerializer().Deserialize<List<HolooInvoiceInfoIETransferKeyViewModel>>(text7);
							string linkAccPreOrderNumber = "";
							string linkAccVoucherNumber = "";
							string linkAccPreOrderIdStr = "";
							string text8 = CheckPreOrderInHoloo(cRMspLkHolooWSSelectOrderByOrdIds_Result.OrderID, linkAccSettingDBId, text7, ref linkAccPreOrderNumber, ref linkAccVoucherNumber, ref linkAccPreOrderIdStr, pordReferUserId);
							if (!string.IsNullOrWhiteSpace(text8) && text8 == "Ok")
							{
								continue;
							}
						}
						HolooInvoiceInfoIEViewModel holooInvoiceInfoIEViewModel = new HolooInvoiceInfoIEViewModel
						{
							id = cRMspLkHolooWSSelectOrderByOrdIds_Result.OrderID.ToString(),
							customererpcode = text5,
							date = date,
							comment = cRMspLkHolooWSSelectOrderByOrdIds_Result.ordDescriptionII,
							time = time,
							discount = cRMspLkHolooWSSelectOrderByOrdIds_Result.ordDiscount.GetValueOrDefault(),
							Nesiyeh = cRMspLkHolooWSSelectOrderByOrdIds_Result.ordTotalAmount.GetValueOrDefault()
						};
						if (!string.IsNullOrWhiteSpace(text4))
						{
							holooInvoiceInfoIEViewModel.midManErpCode = text4 ?? "";
							holooInvoiceInfoIEViewModel.commission = value3;
						}
						holooInvoiceInfoIEViewModel.detailinfo = new List<HolooInvoiceDetailInfoIEViewModel>();
						decimal num12 = default(decimal);
						decimal num13 = default(decimal);
						decimal num14 = default(decimal);
						if (list4 != null && Enumerable.Any<CRMspLkHolooWSSelectOrderItems_Result>((IEnumerable<CRMspLkHolooWSSelectOrderItems_Result>)list4))
						{
							foreach (CRMspLkHolooWSSelectOrderItems_Result item4 in list4)
							{
								HolooInvoiceDetailInfoIEViewModel holooInvoiceDetailInfoIEViewModel = new HolooInvoiceDetailInfoIEViewModel();
								string text9 = item4.PrdLinkAccPrdIdStr ?? "";
								string text10 = item4.UnitLinkAccUnitIdStr ?? "";
								if (!string.IsNullOrEmpty(text9))
								{
									holooInvoiceDetailInfoIEViewModel.id = item4.OrderItemID.ToString();
									holooInvoiceDetailInfoIEViewModel.producterpcode = text9;
									holooInvoiceDetailInfoIEViewModel.few = item4.ordIQuantity.GetValueOrDefault(1.0) * item4.ordIFCR.GetValueOrDefault(1.0) * item4.ordIFCRI.GetValueOrDefault(1.0);
									if (!string.IsNullOrWhiteSpace(text10) && flag2)
									{
										holooInvoiceDetailInfoIEViewModel.few = item4.ordIQuantity.GetValueOrDefault(1.0);
									}
									holooInvoiceDetailInfoIEViewModel.price = item4.ordIPrice.GetValueOrDefault();
									_ = (decimal)(item4.ordIQuantity.GetValueOrDefault(1.0) * item4.ordIFCR.GetValueOrDefault(1.0) * item4.ordIFCRI.GetValueOrDefault(1.0));
									_ = item4.ordIPrice.GetValueOrDefault() - item4.ordIDiscount.GetValueOrDefault() - item4.ordIRound.GetValueOrDefault() + item4.ordIRoundPlus.GetValueOrDefault();
									holooInvoiceDetailInfoIEViewModel.discountprice = item4.ordIDiscountSum.GetValueOrDefault();
									holooInvoiceDetailInfoIEViewModel.discountpercent = item4.ordIDiscountPercent.GetValueOrDefault();
									num12 += holooInvoiceDetailInfoIEViewModel.discountprice.GetValueOrDefault();
									if (item4.ordIDiscountSum.GetValueOrDefault() > 0m)
									{
										holooInvoiceDetailInfoIEViewModel.discountpercent = item4.ordIDiscountPercent.GetValueOrDefault();
									}
									else
									{
										holooInvoiceDetailInfoIEViewModel.discountprice = default(decimal);
									}
									num13 += item4.ordIPriceSum.GetValueOrDefault();
									holooInvoiceDetailInfoIEViewModel.comment = item4.ordIDescription ?? "";
									if (!string.IsNullOrWhiteSpace(text10) && flag2)
									{
										holooInvoiceDetailInfoIEViewModel.unitid = text10 ?? "";
									}
									decimal value4 = default(decimal);
									decimal num15 = default(decimal);
									if (flag)
									{
										if (item4.ordITaxSum.GetValueOrDefault() > 0m)
										{
											value4 = item4.ordITaxIndex.GetValueOrDefault();
										}
										num15 = default(decimal);
										holooInvoiceDetailInfoIEViewModel.levy = value4;
										holooInvoiceDetailInfoIEViewModel.scot = num15;
										num14 += item4.ordITaxSum.GetValueOrDefault();
									}
									else
									{
										value4 = item4.ordITaxSum.GetValueOrDefault();
										num15 = default(decimal);
										num14 += value4 + num15;
										holooInvoiceDetailInfoIEViewModel.levy = value4;
										holooInvoiceDetailInfoIEViewModel.scot = num15;
									}
									holooInvoiceInfoIEViewModel.detailinfo.Add(holooInvoiceDetailInfoIEViewModel);
								}
								else
								{
									text = text + Messages.msgErrorRunFunction + " (Error in create json)";
								}
							}
						}
						holooInvoiceInfoIEViewModel.discount = holooInvoiceInfoIEViewModel.discount.GetValueOrDefault() + num12;
						switch (num3)
						{
						case 1:
							holooInvoiceInfoIEViewModel.Nesiyeh = num13 - cRMspLkHolooWSSelectOrderByOrdIds_Result.ordDiscount.GetValueOrDefault();
							break;
						case 2:
							holooInvoiceInfoIEViewModel.Nesiyeh = num13 + num14 - cRMspLkHolooWSSelectOrderByOrdIds_Result.ordDiscount.GetValueOrDefault();
							break;
						}
						HolooInvoiceInfoIETransferKeyViewModel holooInvoiceInfoIETransferKeyViewModel = new HolooInvoiceInfoIETransferKeyViewModel();
						if (holooInvoiceInfoIEViewModel != null)
						{
							holooInvoiceInfoIETransferKeyViewModel.DBId = linkAccSettingDBId;
							holooInvoiceInfoIETransferKeyViewModel.type = holooInvoiceInfoIEViewModel.type;
							holooInvoiceInfoIETransferKeyViewModel.customererpcode = holooInvoiceInfoIEViewModel.customererpcode;
							holooInvoiceInfoIETransferKeyViewModel.date = holooInvoiceInfoIEViewModel.date;
							holooInvoiceInfoIETransferKeyViewModel.time = holooInvoiceInfoIEViewModel.time;
							holooInvoiceInfoIETransferKeyViewModel.Nesiyeh = holooInvoiceInfoIEViewModel.Nesiyeh;
						}
						text7 = JsonConvert.SerializeObject(holooInvoiceInfoIETransferKeyViewModel);
						if (!string.IsNullOrWhiteSpace(text7))
						{
							if (!text7.StartsWith("["))
							{
								text7 = "[" + text7;
							}
							if (!text7.EndsWith("]"))
							{
								text7 += "]";
							}
							HolooInvoiceInfoListTransferKeyViewModel item = new HolooInvoiceInfoListTransferKeyViewModel
							{
								OrderId = cRMspLkHolooWSSelectOrderByOrdIds_Result.OrderID,
								TransferKey = text7
							};
							transferkeys.Add(item);
						}
						invoice.invoiceinfo.Add(holooInvoiceInfoIEViewModel);
					}
					string errorMessage2 = "";
					holooProvider.OrderExportInfo(ref invoice, ref transferkeys, ref errorMessage2);
					if (!string.IsNullOrEmpty(errorMessage2))
					{
						text = errorMessage2;
					}
					num10 += num11;
					int count = num10 * 100 / num2;
					ProgressHub.SendMessage(string.IsNullOrEmpty(text) ? "ok" : text, count, userId);
				}
			}
			else
			{
				text = Messages.msgErrorRunFunction + " (" + Messages.msgErrorNotSelectedItem + ")";
			}
			if (!string.IsNullOrEmpty(text))
			{
				num = 0;
				commonResultStatusViewModel = CommonResultStatusViewModel.Fail;
				ProgressHub.SendMessage(text, 0, userId);
			}
			else
			{
				text = Messages.msgSuccessAction;
				num = 1;
				commonResultStatusViewModel = CommonResultStatusViewModel.Success;
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			num = 0;
			data = new CommonResultViewModel<int>
			{
				Data = num,
				Message = Messages.msgErrorRunFunction,
				Status = CommonResultStatusViewModel.Error
			};
			return Json(data, JsonRequestBehavior.AllowGet);
		}
		data = new CommonResultViewModel<int>
		{
			Data = num,
			Message = text,
			Status = commonResultStatusViewModel
		};
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetHolooExportPreOrderList(string records, int linkAccSettingDBId, int totalPage, int pordOprId, string fDate = "", string tDate = "", int value = 0, int pordReferUserId = 0)
	{
		//IL_0274: Unknown result type (might be due to invalid IL or missing references)
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
			foreach (CRMspLkHolooWSSelectOrder_Result item2 in Enumerable.ToList<CRMspLkHolooWSSelectOrder_Result>((IEnumerable<CRMspLkHolooWSSelectOrder_Result>)_dbLink.CRMspLkHolooWSSelectOrder(UserLogin.CurrentUser.UserId, pordOprId, (!string.IsNullOrEmpty(fDate)) ? new DateTime?(value4) : null, (!string.IsNullOrEmpty(tDate)) ? new DateTime?(value5) : null, value, value3, value2, lCID, result, pordReferUserId, result2, linkAccSettingDBId)))
			{
				OtherSystemSelectedViewModel item = new OtherSystemSelectedViewModel
				{
					Row = item2.RowNumber.GetValueOrDefault(),
					Id = item2.OrderID,
					Selected = string.IsNullOrEmpty(item2.ordLinkAccOrderIdStr)
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

	[DynamicAuthorize(ControllerName = "frmPreOrder", ActionName = "actImportFromAcc")]
	public ActionResult HolooImportPreOrder()
	{
		GetPreOrderOpr();
		GetPordReferUser();
		GetLinkAccHolooDatabases();
		return View();
	}

	public HolooInvoiceViewModel GetPreOrderListFromHoloo(int pordType, int linkAccSettingDBId, string fDate = "", string tDate = "", string pordNumber = "")
	{
		HolooInvoiceViewModel model = new HolooInvoiceViewModel();
		model.invoice = new List<HolooInvoiceListViewModel>();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			DateTime dateTime = DateTime.Now;
			DateTime dateTime2 = DateTime.Now;
			if (!string.IsNullOrEmpty(fDate))
			{
				dateTime = DateTime.Parse(PersianDate.GetFormatetdDate(fDate.Replace("/", "")) + " 00:00:00", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			if (!string.IsNullOrEmpty(tDate))
			{
				dateTime2 = DateTime.Parse(PersianDate.GetFormatetdDate(tDate.Replace("/", "")) + " 23:59:59", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			CRMIdeal.Classes.Helper.OtherSystems.HolooProvider holooProvider = new CRMIdeal.Classes.Helper.OtherSystems.HolooProvider(linkAccSettingDBId);
			if (!string.IsNullOrEmpty(holooProvider.Authenticate()))
			{
				return model;
			}
			string text = "?Type=" + pordType;
			if (!string.IsNullOrEmpty(pordNumber))
			{
				text = text + "&code=" + pordNumber;
			}
			if (!string.IsNullOrEmpty(fDate) && !string.IsNullOrEmpty(tDate))
			{
				text = text + "&date.from=" + dateTime.ToString("yyyy/MM/dd", new CultureInfo("en-US")) + "&date.to=" + dateTime2.ToString("yyyy/MM/dd", new CultureInfo("en-US"));
			}
			string errorMessage = "";
			holooProvider.GetOrderList(pordType, lCID, result, ref model, text, ref errorMessage, pordNumber);
			if (!string.IsNullOrEmpty(errorMessage))
			{
				return model;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return model;
	}

	[DynamicAuthorize(ControllerName = "frmImportFromAcc", ActionName = "actShowInfo")]
	public ActionResult HolooImportPreOrder_Read([DataSourceRequest] DataSourceRequest request, int linkAccSettingDBId, int pordType, string fDate = "", string tDate = "", string pordNumber = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<HolooInvoiceListViewModel> enumerable = new List<HolooInvoiceListViewModel>();
		try
		{
			HolooInvoiceViewModel preOrderListFromHoloo = GetPreOrderListFromHoloo(pordType, linkAccSettingDBId, fDate, tDate, pordNumber);
			if (preOrderListFromHoloo != null && preOrderListFromHoloo.invoice != null)
			{
				foreach (HolooInvoiceListViewModel item in preOrderListFromHoloo.invoice)
				{
					item.SumPrice = item.SumPrice.GetValueOrDefault() - item.SumDiscount.GetValueOrDefault();
				}
				enumerable = preOrderListFromHoloo.invoice;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[DynamicAuthorize(ControllerName = "frmImportFromAcc", ActionName = "actImportInfo")]
	[AjaxOnly]
	public JsonResult HolooImportInfo(string records, int linkAccSettingDBId, int preOrderOprId, int pordReferUserId, int whId, int pordType, string fDate = "", string tDate = "", string pordNumber = "")
	{
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int num = 0;
		string text = "";
		CommonResultStatusViewModel commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		CommonResultViewModel<int> data;
		try
		{
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int id = Financial.Get().Id;
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			List<OtherSystemSelectedVIiewModel> list = new List<OtherSystemSelectedVIiewModel>();
			List<OtherSystemSelectedVIiewModel> list2 = new List<OtherSystemSelectedVIiewModel>();
			if (!string.IsNullOrWhiteSpace(records))
			{
				list = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedVIiewModel>>(records);
				if (Enumerable.Any<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list))
				{
					list2 = Enumerable.ToList<OtherSystemSelectedVIiewModel>(Enumerable.Where<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list, (Func<OtherSystemSelectedVIiewModel, bool>)((OtherSystemSelectedVIiewModel m) => m.Selected)));
				}
			}
			List<HolooInvoiceListViewModel> list3 = new List<HolooInvoiceListViewModel>();
			HolooInvoiceViewModel preOrderListFromHoloo = GetPreOrderListFromHoloo(pordType, linkAccSettingDBId, fDate, tDate, pordNumber);
			if (preOrderListFromHoloo != null && preOrderListFromHoloo.invoice != null)
			{
				foreach (OtherSystemSelectedVIiewModel SelectedRowitem in list2)
				{
					HolooInvoiceListViewModel holooInvoiceListViewModel = Enumerable.FirstOrDefault<HolooInvoiceListViewModel>(Enumerable.Where<HolooInvoiceListViewModel>((IEnumerable<HolooInvoiceListViewModel>)preOrderListFromHoloo.invoice, (Func<HolooInvoiceListViewModel, bool>)((HolooInvoiceListViewModel w) => w.ErpCode == SelectedRowitem.Id)));
					if (holooInvoiceListViewModel != null)
					{
						list3.Add(holooInvoiceListViewModel);
					}
				}
			}
			if (list3 != null && Enumerable.Any<HolooInvoiceListViewModel>((IEnumerable<HolooInvoiceListViewModel>)list3))
			{
				text = "";
				List<LkCompanyAndPersonViewModel> list4 = new List<LkCompanyAndPersonViewModel>();
				string linkAccIds = string.Join(",", Enumerable.ToList<string>(Enumerable.Select<HolooInvoiceListViewModel, string>((IEnumerable<HolooInvoiceListViewModel>)list3, (Func<HolooInvoiceListViewModel, string>)((HolooInvoiceListViewModel c) => c.CustomerErpCode))));
				List<CRMspLkHolooSelectCompanyWithLinkAccIdStr_Result> list5 = Enumerable.ToList<CRMspLkHolooSelectCompanyWithLinkAccIdStr_Result>((IEnumerable<CRMspLkHolooSelectCompanyWithLinkAccIdStr_Result>)_dbLink.CRMspLkHolooSelectCompanyWithLinkAccIdStr(linkAccIds, lCID, result, linkAccSettingDBId));
				List<string> existingCmpLinkAccIds = Enumerable.ToList<string>(Enumerable.Select<CRMspLkHolooSelectCompanyWithLinkAccIdStr_Result, string>((IEnumerable<CRMspLkHolooSelectCompanyWithLinkAccIdStr_Result>)list5, (Func<CRMspLkHolooSelectCompanyWithLinkAccIdStr_Result, string>)((CRMspLkHolooSelectCompanyWithLinkAccIdStr_Result c) => c.cmpLinkAccIdStr)));
				List<string> missingCmpLinkAccIds = Enumerable.ToList<string>(Enumerable.Where<string>(Enumerable.Select<HolooInvoiceListViewModel, string>((IEnumerable<HolooInvoiceListViewModel>)list3, (Func<HolooInvoiceListViewModel, string>)((HolooInvoiceListViewModel c) => c.CustomerErpCode)), (Func<string, bool>)((string c) => !existingCmpLinkAccIds.Contains(c))));
				IEnumerable<string> enumerable = Enumerable.Select<HolooInvoiceListViewModel, string>(Enumerable.Where<HolooInvoiceListViewModel>((IEnumerable<HolooInvoiceListViewModel>)list3, (Func<HolooInvoiceListViewModel, bool>)((HolooInvoiceListViewModel c) => missingCmpLinkAccIds.Contains(c.CustomerErpCode))), (Func<HolooInvoiceListViewModel, string>)((HolooInvoiceListViewModel c) => c.customerCodeC));
				CompanyController companyController = new CompanyController();
				double num2 = (double)Enumerable.Count<string>(enumerable) + (1.0 + Math.Ceiling((double)list3.Count / 100.0)) * 3.0;
				int num3 = 0;
				int num4;
				foreach (string item in enumerable)
				{
					LkCompanyAndPersonViewModel lkCompanyAndPersonViewModel = Enumerable.FirstOrDefault<LkCompanyAndPersonViewModel>((IEnumerable<LkCompanyAndPersonViewModel>)companyController.GetHolooCompanyList(linkAccSettingDBId, "", "", item));
					if (lkCompanyAndPersonViewModel != null)
					{
						list4.Add(lkCompanyAndPersonViewModel);
					}
					num3++;
					num4 = (int)((double)(num3 * 100) / num2);
					if (num4 >= 100)
					{
						num4 = 100;
					}
					ProgressHub.SendMessage("ok", num4, userId);
				}
				if (list4 != null && Enumerable.Any<LkCompanyAndPersonViewModel>((IEnumerable<LkCompanyAndPersonViewModel>)list4))
				{
					companyController.HolooOrdCmpImportInfo(linkAccSettingDBId, list4, pordReferUserId);
				}
				num3 += 3;
				num4 = (int)((double)(num3 * 100) / num2);
				if (num4 >= 100)
				{
					num4 = 100;
				}
				ProgressHub.SendMessage("ok", num4, userId);
				int num5 = Enumerable.Count<HolooInvoiceListViewModel>((IEnumerable<HolooInvoiceListViewModel>)list3);
				_ = new long[num5];
				int num6 = 100;
				int num7 = num5 / num6;
				int num8 = num5 % num6;
				int num9 = 0;
				int num10 = num6;
				if (num8 != 0)
				{
					num7++;
				}
				for (int i = 0; i < num7; i++)
				{
					if (i == num7 - 1 && num8 != 0)
					{
						num10 = num8;
					}
					List<HolooInvoiceListViewModel> list6 = new List<HolooInvoiceListViewModel>();
					for (int j = 0; j < num10; j++)
					{
						num9 = i * num6 + j;
						list6.Add(list3[num9]);
					}
					if (list6 == null || !Enumerable.Any<HolooInvoiceListViewModel>((IEnumerable<HolooInvoiceListViewModel>)list6))
					{
						continue;
					}
					string text2 = "";
					foreach (HolooInvoiceListViewModel item2 in list3)
					{
						text2 = text2 + "Code=" + (item2.Code.HasValue ? item2.Code.ToString() : "") + "|Type=" + item2.Type + "|SanadCode=" + (item2.SanadCode.HasValue ? item2.SanadCode.ToString() : "") + "|CustomerName=" + item2.CustomerName + "|CustomerErpCode=" + item2.CustomerErpCode + "|cmpLinkAccCode = " + item2.customerCodeC + "|Date=" + item2.Date + "|Time=" + item2.Time + "|SumNaghd=" + (item2.SumNaghd.HasValue ? item2.SumNaghd.ToString() : "") + "|SumCard=" + (item2.SumCard.HasValue ? item2.SumCard.ToString() : "") + "|SumNesiyeh=" + (item2.SumNesiyeh.HasValue ? item2.SumNesiyeh.ToString() : "") + "|SumDiscount=" + (item2.SumDiscount.HasValue ? item2.SumDiscount.ToString() : "") + "|SumCheck=" + (item2.SumCheck.HasValue ? item2.SumCheck.ToString() : "") + "|SumLevy=" + (item2.SumLevy.HasValue ? item2.SumLevy.ToString() : "") + "|SumScot=" + (item2.SumScot.HasValue ? item2.SumScot.ToString() : "") + "|SumPrice=" + (item2.SumPrice.HasValue ? item2.SumPrice.ToString() : "") + "|Comment=" + ((item2.comment != null) ? item2.comment.ToString() : "") + "|ErpCode=" + item2.ErpCode;
						string text3 = "";
						if (item2.Detail != null)
						{
							foreach (HolooInvoiceDetailListViewModel item3 in item2.Detail)
							{
								text3 = text3 + "^(Row:" + (item3.Row.HasValue ? item3.Row.ToString() : "") + "^#^ProductCode:" + item3.ProductCode + "^#^ProductName:" + item3.ProductName + "^#^ProductErpCode:" + item3.ProductErpCode + "^#^Few:" + (item3.Few.HasValue ? item3.Few.ToString() : "") + "^#^Karton:" + (item3.Karton.HasValue ? item3.Karton.ToString() : "") + "^#^Price:" + (item3.Price.HasValue ? item3.Price.ToString() : "") + "^#^SumPrice:" + (item3.SumPrice.HasValue ? item3.SumPrice.ToString() : "") + "^#^Levy:" + (item3.Levy.HasValue ? item3.Levy.ToString() : "") + "^#^Scot:" + (item3.Scot.HasValue ? item3.Scot.ToString() : "") + "^#^PersentDiscount:" + (item3.PersentDiscount.HasValue ? item3.PersentDiscount.ToString() : "") + "^#^Discount:" + (item3.Discount.HasValue ? item3.Discount.ToString() : "") + "^#^)^";
							}
						}
						text2 = text2 + "|Detail=" + text3 + "@";
					}
					ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
					_dbLink.CRMspLkHolooWSInsertUpdateOrderFromHoloo(text2, preOrderOprId, pordReferUserId, whId, userId, value2, id, value, registerDatePersian, appType, result, objectParameter, centerId, linkAccSettingDBId);
					if (objectParameter.Value != null)
					{
						if (!string.IsNullOrEmpty(objectParameter.Value.ToString()))
						{
							text = text + "<br>" + objectParameter.Value.ToString();
							continue;
						}
						num3 += 3;
						num4 = (int)((double)(num3 * 100) / num2);
						if (num4 >= 100)
						{
							num4 = 100;
						}
						ProgressHub.SendMessage("ok", num4, userId);
					}
					else
					{
						num3 += 3;
						num4 = (int)((double)(num3 * 100) / num2);
						if (num4 >= 100)
						{
							num4 = 100;
						}
						ProgressHub.SendMessage("ok", num4, userId);
					}
				}
				new PendingOperations().StartPendingOperations();
			}
			else
			{
				text = Messages.msgErrorRunFunction + " (" + Messages.ErrorNotFound + ")";
			}
			if (!string.IsNullOrEmpty(text))
			{
				num = 0;
				commonResultStatusViewModel = CommonResultStatusViewModel.Fail;
				ProgressHub.SendMessage(text, 0, userId);
			}
			else
			{
				text = Messages.msgSuccessAction;
				num = 1;
				commonResultStatusViewModel = CommonResultStatusViewModel.Success;
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
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			num = 0;
			data = new CommonResultViewModel<int>
			{
				Data = num,
				Message = Messages.msgErrorRunFunction,
				Status = CommonResultStatusViewModel.Error
			};
			return Json(data, JsonRequestBehavior.AllowGet);
		}
		data = new CommonResultViewModel<int>
		{
			Data = num,
			Message = text,
			Status = commonResultStatusViewModel
		};
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetHolooImportPreOrderList(string records, int linkAccSettingDBId, int pordType, string fDate = "", string tDate = "", string pordNumber = "")
	{
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		List<OtherSystemSelectedVIiewModel> list = new List<OtherSystemSelectedVIiewModel>();
		List<HolooInvoiceListViewModel> list2 = new List<HolooInvoiceListViewModel>();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			HolooInvoiceViewModel preOrderListFromHoloo = GetPreOrderListFromHoloo(pordType, linkAccSettingDBId, fDate, tDate, pordNumber);
			if (preOrderListFromHoloo != null && preOrderListFromHoloo.invoice != null)
			{
				list2 = preOrderListFromHoloo.invoice;
			}
			foreach (HolooInvoiceListViewModel item2 in list2)
			{
				OtherSystemSelectedVIiewModel item = new OtherSystemSelectedVIiewModel
				{
					Row = item2.RowNumber,
					Id = (item2.ErpCode ?? "0"),
					Selected = (item2.OrderId == 0)
				};
				list.Add(item);
			}
			if (!string.IsNullOrWhiteSpace(records))
			{
				List<OtherSystemSelectedVIiewModel> list3 = new List<OtherSystemSelectedVIiewModel>();
				list3 = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedVIiewModel>>(records);
				if (Enumerable.Any<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list3))
				{
					foreach (OtherSystemSelectedVIiewModel item3 in list3)
					{
						foreach (OtherSystemSelectedVIiewModel item4 in list)
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

	public string CheckPreOrderInHoloo(int pordId, int linkAccSettingDBId, string linkAccTransferKey, ref string linkAccPreOrderNumber, ref string linkAccVoucherNumber, ref string linkAccPreOrderIdStr, int pordReferUserId)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		string result = "-1";
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		if (result2 <= 0)
		{
			result2 = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string value = "";
		string value2 = "";
		if (!string.IsNullOrWhiteSpace(linkAccTransferKey))
		{
			List<HolooInvoiceInfoIETransferKeyViewModel> list = new JavaScriptSerializer().Deserialize<List<HolooInvoiceInfoIETransferKeyViewModel>>(linkAccTransferKey);
			if (list != null && Enumerable.Any<HolooInvoiceInfoIETransferKeyViewModel>((IEnumerable<HolooInvoiceInfoIETransferKeyViewModel>)list))
			{
				HolooInvoiceInfoIETransferKeyViewModel holooInvoiceInfoIETransferKeyViewModel = Enumerable.FirstOrDefault<HolooInvoiceInfoIETransferKeyViewModel>((IEnumerable<HolooInvoiceInfoIETransferKeyViewModel>)list);
				if (holooInvoiceInfoIETransferKeyViewModel != null)
				{
					int type = holooInvoiceInfoIETransferKeyViewModel.type;
					string text = holooInvoiceInfoIETransferKeyViewModel.date;
					string text2 = holooInvoiceInfoIETransferKeyViewModel.date;
					string customererpcode = holooInvoiceInfoIETransferKeyViewModel.customererpcode;
					string time = holooInvoiceInfoIETransferKeyViewModel.time ?? "00:00:00";
					if (time.Length == 5)
					{
						time += ":00";
					}
					decimal nesiyeh = holooInvoiceInfoIETransferKeyViewModel.Nesiyeh.GetValueOrDefault();
					HolooInvoiceViewModel model = new HolooInvoiceViewModel();
					model.invoice = new List<HolooInvoiceListViewModel>();
					try
					{
						DateTime dateTime = DateTime.Now;
						DateTime dateTime2 = DateTime.Now;
						if (!string.IsNullOrEmpty(text))
						{
							text = text.Replace("/", "").Replace("-", "");
							dateTime = DateTime.Parse(PersianDate.GetFormatetdDate(text.Replace("/", "")) + " " + holooInvoiceInfoIETransferKeyViewModel.time, new CultureInfo("en-US"));
						}
						if (!string.IsNullOrEmpty(text2))
						{
							text2 = text2.Replace("/", "").Replace("-", "");
							dateTime2 = DateTime.Parse(PersianDate.GetFormatetdDate(text2.Replace("/", "")) + " " + holooInvoiceInfoIETransferKeyViewModel.time, new CultureInfo("en-US"));
						}
						if (pordReferUserId != 0)
						{
							CRMspSelectLinkAccSettingUsers_Result cRMspSelectLinkAccSettingUsers_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingUsers_Result>((IEnumerable<CRMspSelectLinkAccSettingUsers_Result>)_dbLink.CRMspSelectLinkAccSettingUsers(0, linkAccSettingDBId, pordReferUserId, lCID, result2));
							if (cRMspSelectLinkAccSettingUsers_Result != null)
							{
								value = cRMspSelectLinkAccSettingUsers_Result.UserName ?? "";
								value2 = ((!string.IsNullOrEmpty(cRMspSelectLinkAccSettingUsers_Result.Password)) ? XorCipher.DecryptByPrivateKey(cRMspSelectLinkAccSettingUsers_Result.Password) : string.Empty);
							}
						}
						if (string.IsNullOrWhiteSpace(value) || string.IsNullOrWhiteSpace(value2))
						{
							return string.Format(Messages.msgErrorNotDefineLinkAccHolooSettingUsers, Labels.Holoo) + "|";
						}
						CRMIdeal.Classes.Helper.OtherSystems.HolooProvider holooProvider = new CRMIdeal.Classes.Helper.OtherSystems.HolooProvider(linkAccSettingDBId);
						string text3 = holooProvider.Authenticate();
						if (!string.IsNullOrEmpty(text3))
						{
							return text3;
						}
						string errorMessage = "";
						string text4 = "?Type=" + type;
						if (!string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(text2))
						{
							text4 = text4 + "&date.from=" + dateTime.ToString("yyyy/MM/dd", new CultureInfo("en-US")) + "&date.to=" + dateTime2.ToString("yyyy/MM/dd", new CultureInfo("en-US"));
						}
						holooProvider.CheckOrder(text4, type, ref model, ref errorMessage);
						if (!string.IsNullOrEmpty(errorMessage))
						{
							return errorMessage;
						}
						if (model != null && model.invoice != null)
						{
							string pordDateI = holooInvoiceInfoIETransferKeyViewModel.date;
							if (!string.IsNullOrWhiteSpace(pordDateI))
							{
								pordDateI = pordDateI.Replace("-", "/");
							}
							HolooInvoiceListViewModel holooInvoiceListViewModel = Enumerable.FirstOrDefault<HolooInvoiceListViewModel>((IEnumerable<HolooInvoiceListViewModel>)model.invoice, (Func<HolooInvoiceListViewModel, bool>)((HolooInvoiceListViewModel m) => m.Date == pordDateI && m.Time == time && (m.SumPrice.GetValueOrDefault() == nesiyeh || m.SumNesiyeh.GetValueOrDefault() == nesiyeh) && m.CustomerErpCode == customererpcode && m.OrderId == 0));
							if (holooInvoiceListViewModel != null)
							{
								string text5 = "";
								text5 = holooInvoiceListViewModel.Code.GetValueOrDefault().ToString();
								string text6 = "";
								text6 = holooInvoiceListViewModel.SanadCode.GetValueOrDefault().ToString();
								string erpCode = holooInvoiceListViewModel.ErpCode;
								if (!string.IsNullOrWhiteSpace(erpCode))
								{
									string text7 = "[PordId=" + pordId + "|,|LinkAccPordNumber =" + ((!string.IsNullOrWhiteSpace(text5)) ? text5 : "") + "|,|LinkAccVoucherNumber =" + ((!string.IsNullOrWhiteSpace(text6)) ? text6 : "") + "|,|LinkAccPordIdStr=" + ((!string.IsNullOrEmpty(erpCode)) ? erpCode : "") + "|,|LinkAccTransferKey=" + ((!string.IsNullOrEmpty(linkAccTransferKey)) ? linkAccTransferKey : "") + "|,|LinkAccTransferResult=Ok|,|]@";
									if (!string.IsNullOrEmpty(text7))
									{
										mct_Link_Result mct_Link_Result = Enumerable.FirstOrDefault<mct_Link_Result>((IEnumerable<mct_Link_Result>)_dbLink.CRMspLkHolooWSUpdateOrderLinkAccFields(text7, linkAccSettingDBId));
										if (mct_Link_Result != null && mct_Link_Result.Result > 0)
										{
											linkAccPreOrderNumber = text5;
											linkAccVoucherNumber = text6;
											linkAccPreOrderIdStr = erpCode;
											result = "Ok";
										}
									}
									else
									{
										result = string.Format(Messages.msgErrorOtherSystemsNotRegistered, Labels.OtherSystemsPreOrder, Labels.Holoo) + "<br>";
									}
								}
								else
								{
									result = "NotFind";
								}
							}
						}
					}
					catch (Exception ex)
					{
						ErrorSignal.FromCurrentContext().Raise(ex);
						return ex.Message;
					}
				}
			}
		}
		return result;
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
		_dbI.Dispose();
		_dbLink.Dispose();
		base.Dispose(disposing);
	}
}
