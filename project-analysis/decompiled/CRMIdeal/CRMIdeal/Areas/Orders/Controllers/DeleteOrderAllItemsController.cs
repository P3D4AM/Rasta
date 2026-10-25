using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web.Mvc;
using CRM.General.Calendar;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Helper;
using Elmah;

namespace CRMIdeal.Areas.Orders.Controllers;

public class DeleteOrderAllItemsController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		public int orderId;
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	[DynamicAuthorize(ControllerName = "frmOrder", ActionName = "actDeleteAllItems")]
	public ActionResult Index(int orderId)
	{
		base.ViewBag.OrderId = orderId;
		base.ViewBag.Message = "";
		base.ViewBag.Doc = null;
		if (orderId > 0)
		{
			WSspReturnDraftFromOrder_Result wSspReturnDraftFromOrder_Result = Order.ReturnDraftFromOrder(orderId);
			if (wSspReturnDraftFromOrder_Result != null)
			{
				base.ViewBag.Doc = wSspReturnDraftFromOrder_Result;
				string text = "";
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				if (!string.IsNullOrEmpty(wSspReturnDraftFromOrder_Result.DocDate))
				{
					if (lCID == 1065)
					{
						text = wSspReturnDraftFromOrder_Result.DocDate;
					}
					else
					{
						DateTime dateTime = DateTime.Parse(PersianDate.GetShamsi2Miladi(wSspReturnDraftFromOrder_Result.DocDate.Replace("/", "")));
						text = ((lCID != 1025) ? dateTime.ToString("yyyy/MM/dd", new CultureInfo("en-US")) : dateTime.ToString("yyyy/MM/dd", new CultureInfo("ar-SA")));
					}
					text = PersianDate.GetFormatetdDate(text);
				}
				string text2 = "";
				if (!string.IsNullOrEmpty(wSspReturnDraftFromOrder_Result.RegisterDatePersian))
				{
					if (lCID == 1065)
					{
						text2 = wSspReturnDraftFromOrder_Result.RegisterDatePersian;
					}
					else
					{
						DateTime dateTime2 = DateTime.Parse(PersianDate.GetShamsi2Miladi(wSspReturnDraftFromOrder_Result.RegisterDatePersian.Replace("/", "")));
						text2 = ((lCID != 1025) ? dateTime2.ToString("yyyy/MM/dd", new CultureInfo("en-US")) : dateTime2.ToString("yyyy/MM/dd", new CultureInfo("ar-SA")));
					}
					text2 = PersianDate.GetFormatetdDate(text2);
				}
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
				if (result2 <= 0)
				{
					result2 = 1065;
				}
				int lCID2 = Thread.CurrentThread.CurrentCulture.LCID;
				List<WSspReturnDraftFromOrder_Result> list = Enumerable.ToList<WSspReturnDraftFromOrder_Result>((IEnumerable<WSspReturnDraftFromOrder_Result>)_db.WSspReturnDraftFromOrder(orderId, lCID2, result2));
				string text3 = "";
				if (list != null && Enumerable.Any<WSspReturnDraftFromOrder_Result>((IEnumerable<WSspReturnDraftFromOrder_Result>)list))
				{
					if (list.Count > 1)
					{
						string text4 = "";
						foreach (WSspReturnDraftFromOrder_Result item in list)
						{
							text4 = text4 + item.DocNumber + ",";
						}
						if (!string.IsNullOrEmpty(text4) && text4.EndsWith(","))
						{
							text4 = text4.TrimEnd(new char[1] { ',' });
						}
						text3 = Labels.DeleteOrdAllOrderHaveDraftsWithNumber + " : " + text4;
					}
					else
					{
						text3 = Labels.DeleteOrdAllOrderHaveDraftWithNumber + " : " + wSspReturnDraftFromOrder_Result.DocNumber;
					}
				}
				else
				{
					text3 = Labels.DeleteOrdAllOrderHaveDraftWithNumber + " : " + wSspReturnDraftFromOrder_Result.DocNumber;
				}
				base.ViewBag.Message = Labels.DeleteOrdAllAttention + "\r\n" + text3 + "\r\n" + Labels.DeleteOrdAllDated + " : " + text + "\r\n" + Labels.DeleteOrdAllInDate + " : " + text2 + "\r\n" + Labels.DeleteOrdAllByUser + " : " + wSspReturnDraftFromOrder_Result.UserName + "\r\n" + Labels.DeleteOrdAllBeenIssued + "\r\n" + Labels.DeleteOrdAllFirstDelDraft;
			}
		}
		return View();
	}

	[AjaxOnly]
	public string DeleteOrder(int orderId, int mode)
	{
		_003C_003Ec__DisplayClass3_0 _003C_003Ec__DisplayClass3_ = new _003C_003Ec__DisplayClass3_0();
		_003C_003Ec__DisplayClass3_.orderId = orderId;
		string result = "-1";
		if (_003C_003Ec__DisplayClass3_.orderId > 0)
		{
			try
			{
				DbSet<WSOrder> wSOrder = _dbTbl.WSOrder;
				ParameterExpression val = Expression.Parameter(typeof(WSOrder), "c");
				WSOrder wSOrder2 = Queryable.FirstOrDefault<WSOrder>((IQueryable<WSOrder>)wSOrder, Expression.Lambda<Func<WSOrder, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass3_, typeof(_003C_003Ec__DisplayClass3_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (wSOrder2 != null)
				{
					if (Order.IsSentToLinkAccByAction(wSOrder2.OrderID))
					{
						string linkAccSystemTitle = CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
						result = string.Format(Messages.msgErrorUnableChangeInSentToLinkAcc, linkAccSystemTitle);
						return result;
					}
					try
					{
						mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)Enumerable.ToList<mct_Result>((IEnumerable<mct_Result>)_db.WSspDeleteOrder(mode, _003C_003Ec__DisplayClass3_.orderId, UserLogin.CurrentUser.UserId, DateTime.Now.ToString("yyyy/MM/dd"))));
						int result2 = 0;
						if (mct_Result != null)
						{
							int.TryParse(mct_Result.Result.ToString(), out result2);
						}
						result = ((result2 > 0) ? "1" : (result2 switch
						{
							-1 => Messages.msgErrorDeleteOrderAndDocHaveMultiDoc, 
							-2 => Messages.msgErrorDeleteOrderAndDocHaveMultiOrd, 
							_ => Messages.RedundancyMessage, 
						}));
					}
					catch (DbEntityValidationException e)
					{
						ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
						result = Messages.RedundancyMessage;
					}
					catch (Exception ex)
					{
						ErrorSignal.FromCurrentContext().Raise(ex);
						result = Messages.msgErrorCommunicateWithServer + "<br><p style=text-align:left;>" + ex.Message + "</p>";
					}
				}
				else
				{
					result = Messages.ErrorNotFound;
				}
			}
			catch (DbEntityValidationException e2)
			{
				ErrorSignal.FromCurrentContext().Raise((Exception)(object)e2);
			}
			catch (Exception e3)
			{
				ErrorSignal.FromCurrentContext().Raise(e3);
			}
		}
		return result;
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		base.Dispose(disposing);
	}
}
