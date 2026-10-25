using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Transactions;
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
using Newtonsoft.Json;

namespace CRMIdeal.Areas.PayRolls.Controllers;

public class PaymentController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		public int payId;

		public int currLangID;

		internal bool _003CInsertEdit_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public PayRollUserPaymentsLanguageViewModel vm;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__3;

		public Func<Languages, bool> _003C_003E9__9;

		internal bool _003CInsertEdit_003Eb__1(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__2(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__3(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CInsertEdit_003Eb__9(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_1
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals1;

		internal bool _003CInsertEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_0
	{
		public int payId;
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	[LoginAuthorize]
	public ActionResult InsertEdit(int payId, int cycleId)
	{
		_003C_003Ec__DisplayClass3_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass3_0();
		CS_0024_003C_003E8__locals0.payId = payId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		PayRollUserPaymentsLanguageViewModel payRollUserPaymentsLanguageViewModel = new PayRollUserPaymentsLanguageViewModel();
		DateTime now = DateTime.Now;
		int result2 = 0;
		string payRollCycleTitle = "";
		decimal result3 = default(decimal);
		decimal result4 = default(decimal);
		try
		{
			PayRollspSelectUserCycleById_Result payRollspSelectUserCycleById_Result = Enumerable.FirstOrDefault<PayRollspSelectUserCycleById_Result>((IEnumerable<PayRollspSelectUserCycleById_Result>)_dbI.PayRollspSelectUserCycleById(cycleId, CS_0024_003C_003E8__locals0.currLangID, result));
			if (payRollspSelectUserCycleById_Result != null)
			{
				payRollCycleTitle = payRollspSelectUserCycleById_Result.CycleTitle + ((!string.IsNullOrWhiteSpace(payRollspSelectUserCycleById_Result.CrmUser)) ? (" (" + payRollspSelectUserCycleById_Result.CrmUser + ")") : "");
				int.TryParse(payRollspSelectUserCycleById_Result.CycleDefBankingAccountId.ToString(), out result2);
				if (result2 != 0)
				{
					payRollUserPaymentsLanguageViewModel.BankingAccountId = result2;
				}
				decimal.TryParse(payRollspSelectUserCycleById_Result.CycleNetSalary.ToString(), out result3);
				decimal.TryParse(payRollspSelectUserCycleById_Result.AllPayRemain.ToString(), out result4);
			}
			if (CS_0024_003C_003E8__locals0.payId == 0)
			{
				payRollUserPaymentsLanguageViewModel = new PayRollUserPaymentsLanguageViewModel();
				payRollUserPaymentsLanguageViewModel.CycleId = cycleId;
				PayRollUserPaymentsLanguageViewModel payRollUserPaymentsLanguageViewModel2 = payRollUserPaymentsLanguageViewModel;
				DateTime firstRegisterDate = (payRollUserPaymentsLanguageViewModel.RegisterDate = now);
				payRollUserPaymentsLanguageViewModel2.FirstRegisterDate = firstRegisterDate;
				if (result2 != 0)
				{
					payRollUserPaymentsLanguageViewModel.BankingAccountId = result2;
				}
			}
			else
			{
				DbSet<PayRollUserPayments_Lang> payRollUserPayments_Lang = _dbTbl.PayRollUserPayments_Lang;
				ParameterExpression val = Expression.Parameter(typeof(PayRollUserPayments_Lang), "c");
				List<PayRollUserPayments_Lang> list = Enumerable.ToList<PayRollUserPayments_Lang>((IEnumerable<PayRollUserPayments_Lang>)Queryable.Where<PayRollUserPayments_Lang>((IQueryable<PayRollUserPayments_Lang>)payRollUserPayments_Lang, Expression.Lambda<Func<PayRollUserPayments_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass3_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
				DbSet<PayRollUserPayments> payRollUserPayments = _dbTbl.PayRollUserPayments;
				val = Expression.Parameter(typeof(PayRollUserPayments), "m");
				PayRollUserPayments payRollUserPayments2 = Queryable.FirstOrDefault<PayRollUserPayments>((IQueryable<PayRollUserPayments>)payRollUserPayments, Expression.Lambda<Func<PayRollUserPayments, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass3_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) ?? new PayRollUserPayments();
				List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<PayRollUserPayments_Lang, CommonMultiLanguageViewModel>((IEnumerable<PayRollUserPayments_Lang>)list, (Func<PayRollUserPayments_Lang, CommonMultiLanguageViewModel>)((PayRollUserPayments_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.Description,
					LanguageId = item.LanguageID
				})));
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = payRollUserPayments2.Description,
					LanguageId = result
				});
				payRollUserPaymentsLanguageViewModel = new PayRollUserPaymentsLanguageViewModel
				{
					PayRollUserPaymentId = payRollUserPayments2.PayRollUserPaymentId,
					CycleId = payRollUserPayments2.CycleId,
					PayTypeId = payRollUserPayments2.PayTypeId,
					Amount = payRollUserPayments2.Amount,
					UserAccountNumber = payRollUserPayments2.UserAccountNumber,
					PaymentNumber = payRollUserPayments2.PaymentNumber,
					PaymentDatePersian = (payRollUserPayments2.PaymentDate.HasValue ? payRollUserPayments2.PaymentDate.Value.ToString("yyyyMMdd") : ""),
					PaymentDate = payRollUserPayments2.PaymentDate,
					FirstRegisterUserId = payRollUserPayments2.FirstRegisterUserId,
					FirstRegisterDate = payRollUserPayments2.FirstRegisterDate,
					FirstRegisterDatePersian = payRollUserPayments2.FirstRegisterDatePersian,
					UserId = payRollUserPayments2.UserId,
					RegisterDate = payRollUserPayments2.RegisterDate,
					RegisterDatePersian = payRollUserPayments2.RegisterDatePersian,
					Year1 = payRollUserPayments2.Year1,
					Month1 = payRollUserPayments2.Month1,
					GUId = payRollUserPayments2.GUId,
					AppType = payRollUserPayments2.AppType,
					LanguageID = payRollUserPayments2.LanguageID,
					Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					Description_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					BankingAccountId = payRollUserPayments2.BankingAccountId
				};
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		if (payRollUserPaymentsLanguageViewModel != null)
		{
			payRollUserPaymentsLanguageViewModel.PayRollCycleTitle = payRollCycleTitle;
			payRollUserPaymentsLanguageViewModel.PayRollCycleNetSalary = result3;
			payRollUserPaymentsLanguageViewModel.PayRollCycleAllPayRemain = result4;
		}
		GetPaymentType();
		SetRegisterInfo(payRollUserPaymentsLanguageViewModel);
		return View(payRollUserPaymentsLanguageViewModel);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	[LoginAuthorize]
	[DynamicAuthorize(ControllerName = "frmPayRollUserPayment", ActionName = "actPost")]
	public ActionResult InsertEdit(PayRollUserPaymentsLanguageViewModel vm)
	{
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass4_0();
		CS_0024_003C_003E8__locals0.vm = vm;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		GetPaymentType();
		if (base.ModelState.IsValid)
		{
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.Description_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.Description_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.Description,
				LanguageId = lCID
			});
			try
			{
				int userId = UserLogin.CurrentUser.UserId;
				DateTime now = DateTime.Now;
				DateTime dateTime = now;
				string text = now.ToString("yyyyMMdd", new PersianCulture());
				short num = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				short num2 = short.Parse(Financial.Get().Id.ToString());
				CS_0024_003C_003E8__locals0.vm.PaymentDatePersian = CS_0024_003C_003E8__locals0.vm.PaymentDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
					.Replace(".", "")
					.Replace(",", "")
					.Replace("\\", "");
				DateTime dateTime2 = default(DateTime);
				string text2 = "";
				try
				{
					if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.PaymentDatePersian))
					{
						text2 = PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.vm.PaymentDatePersian.Replace("/", ""));
						text2 = text2 + " " + DateTime.Now.ToString("HH:mm:ss");
						switch (lCID)
						{
						case 1065:
							dateTime2 = DateTime.Parse(text2, new PersianCulture());
							CS_0024_003C_003E8__locals0.vm.PaymentDatePersian = dateTime2.ToString("yyyyMMdd");
							break;
						case 1025:
							dateTime2 = DateTime.Parse(text2, new CultureInfo("ar-SA"));
							CS_0024_003C_003E8__locals0.vm.PaymentDatePersian = dateTime2.ToString("yyyyMMdd", new PersianCulture());
							break;
						default:
							dateTime2 = DateTime.Parse(text2, new CultureInfo("en-US"));
							CS_0024_003C_003E8__locals0.vm.PaymentDatePersian = dateTime2.ToString("yyyyMMdd", new PersianCulture());
							break;
						}
						CS_0024_003C_003E8__locals0.vm.PaymentDate = dateTime2;
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
					base.ViewBag.Error = Messages.ErrorFormatDatePersian;
					SetRegisterInfo(CS_0024_003C_003E8__locals0.vm);
					return View(CS_0024_003C_003E8__locals0.vm);
				}
				PayRollUserPayments payRollUserPayments = new PayRollUserPayments();
				if (CS_0024_003C_003E8__locals0.vm.PayRollUserPaymentId > 0)
				{
					DbSet<PayRollUserPayments> payRollUserPayments2 = _dbTbl.PayRollUserPayments;
					ParameterExpression val = Expression.Parameter(typeof(PayRollUserPayments), "m");
					payRollUserPayments = Queryable.FirstOrDefault<PayRollUserPayments>((IQueryable<PayRollUserPayments>)payRollUserPayments2, Expression.Lambda<Func<PayRollUserPayments, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass4_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				}
				payRollUserPayments.CycleId = CS_0024_003C_003E8__locals0.vm.CycleId;
				payRollUserPayments.PayTypeId = CS_0024_003C_003E8__locals0.vm.PayTypeId;
				payRollUserPayments.Amount = CS_0024_003C_003E8__locals0.vm.Amount;
				payRollUserPayments.UserAccountNumber = CS_0024_003C_003E8__locals0.vm.UserAccountNumber;
				payRollUserPayments.PaymentNumber = CS_0024_003C_003E8__locals0.vm.PaymentNumber;
				payRollUserPayments.PaymentDate = CS_0024_003C_003E8__locals0.vm.PaymentDate;
				payRollUserPayments.PaymentDatePersian = CS_0024_003C_003E8__locals0.vm.PaymentDatePersian;
				payRollUserPayments.Description = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				payRollUserPayments.UserId = userId;
				payRollUserPayments.Year1 = num2;
				payRollUserPayments.Month1 = num;
				payRollUserPayments.RegisterDate = dateTime;
				payRollUserPayments.RegisterDatePersian = text;
				payRollUserPayments.AppType = appType;
				payRollUserPayments.BankingAccountId = CS_0024_003C_003E8__locals0.vm.BankingAccountId;
				if (CS_0024_003C_003E8__locals0.vm.PayRollUserPaymentId > 0)
				{
					_dbTbl.Entry(payRollUserPayments).State = EntityState.Modified;
					_dbTbl.SaveChanges();
					using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							_003C_003Ec__DisplayClass4_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass4_1();
							CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
							CS_0024_003C_003E8__locals1.lang = enumerator.Current;
							DbSet<PayRollUserPayments_Lang> payRollUserPayments_Lang = _dbTbl.PayRollUserPayments_Lang;
							ParameterExpression val = Expression.Parameter(typeof(PayRollUserPayments_Lang), "c");
							PayRollUserPayments_Lang payRollUserPayments_Lang2 = Queryable.FirstOrDefault<PayRollUserPayments_Lang>((IQueryable<PayRollUserPayments_Lang>)payRollUserPayments_Lang, Expression.Lambda<Func<PayRollUserPayments_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass4_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass4_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (payRollUserPayments_Lang2 != null)
							{
								payRollUserPayments_Lang2.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								_dbTbl.Entry(payRollUserPayments_Lang2).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							payRollUserPayments_Lang2 = new PayRollUserPayments_Lang();
							payRollUserPayments_Lang2.LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID;
							payRollUserPayments_Lang2.PayRollUserPaymentId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.vm.PayRollUserPaymentId;
							payRollUserPayments_Lang2.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							_dbTbl.PayRollUserPayments_Lang.Add(payRollUserPayments_Lang2);
							_dbTbl.SaveChanges();
						}
					}
					base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
				}
				else
				{
					payRollUserPayments.FirstRegisterUserId = userId;
					payRollUserPayments.FirstRegisterDate = dateTime;
					payRollUserPayments.FirstRegisterDatePersian = text;
					payRollUserPayments.GUId = Guid.NewGuid();
					payRollUserPayments.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
					_dbTbl.PayRollUserPayments.Add(payRollUserPayments);
					_dbTbl.SaveChanges();
					foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
					{
						PayRollUserPayments_Lang payRollUserPayments_Lang3 = new PayRollUserPayments_Lang();
						payRollUserPayments_Lang3.LanguageID = lang.LanguageID;
						payRollUserPayments_Lang3.PayRollUserPaymentId = payRollUserPayments.PayRollUserPaymentId;
						payRollUserPayments_Lang3.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						_dbTbl.PayRollUserPayments_Lang.Add(payRollUserPayments_Lang3);
						_dbTbl.SaveChanges();
					}
					base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
					PayRollspSelectUserCycleById_Result payRollspSelectUserCycleById_Result = Enumerable.FirstOrDefault<PayRollspSelectUserCycleById_Result>((IEnumerable<PayRollspSelectUserCycleById_Result>)_dbI.PayRollspSelectUserCycleById(payRollUserPayments.CycleId, lCID, CS_0024_003C_003E8__locals0.defLangID));
					if (payRollspSelectUserCycleById_Result != null)
					{
						int crmUserId = payRollspSelectUserCycleById_Result.CrmUserId;
						int payRollUserCycleId = payRollspSelectUserCycleById_Result.PayRollUserCycleId;
						if (crmUserId > 0)
						{
							string upUserIds = JsonConvert.SerializeObject(new Dictionary<string, int> { { "upUserId", crmUserId } });
							string upExtraData = JsonConvert.SerializeObject(new Dictionary<string, int> { { "cycleId", payRollUserCycleId } });
							_dbI.CRMspInsertUserPushNotifTank(2, upUserIds, "", "", upExtraData, null, userId, num2, num, dateTime, text, appType, lCID);
							PushNotif.NewPayRollUserPaymentNotify();
						}
					}
				}
				CS_0024_003C_003E8__locals0.vm.AppType = payRollUserPayments.AppType;
				CS_0024_003C_003E8__locals0.vm.UserId = payRollUserPayments.UserId;
				CS_0024_003C_003E8__locals0.vm.FirstRegisterDate = payRollUserPayments.FirstRegisterDate;
				CS_0024_003C_003E8__locals0.vm.RegisterDate = payRollUserPayments.RegisterDate;
			}
			catch (DbEntityValidationException ex)
			{
				ErrorSignal.FromCurrentContext().Raise((Exception)(object)ex);
				base.ViewBag.Error = Messages.frmErrorMessage + "<br/>" + ((Exception)(object)ex).Message;
			}
			catch (Exception ex2)
			{
				ErrorSignal.FromCurrentContext().Raise(ex2);
				base.ViewBag.Error = Messages.frmErrorMessage + "<br/>" + ex2.Message;
			}
		}
		else
		{
			string text3 = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			base.ViewBag.Error = Messages.frmErrorMessage + "<br/>" + text3;
		}
		SetRegisterInfo(CS_0024_003C_003E8__locals0.vm);
		return View(CS_0024_003C_003E8__locals0.vm);
	}

	[AjaxOnly]
	public string GetDateBefore(string date)
	{
		string result = "-1";
		try
		{
			result = PersianDate.GetInsertedDays2Date(date.Replace("-", "").Replace("/", ""), -3.0);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmPayRollUserCycleDetails", ActionName = "actDeletePay")]
	public string ActDeletePay(int payId)
	{
		_003C_003Ec__DisplayClass6_0 _003C_003Ec__DisplayClass6_ = new _003C_003Ec__DisplayClass6_0();
		_003C_003Ec__DisplayClass6_.payId = payId;
		string result = "";
		try
		{
			if (!UserLogin.IsUserAccess("frmPayRollUserCycleDetails", "actDeletePay", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			DbSet<PayRollUserPayments> payRollUserPayments = _dbTbl.PayRollUserPayments;
			ParameterExpression val = Expression.Parameter(typeof(PayRollUserPayments), "m");
			if (Queryable.FirstOrDefault<PayRollUserPayments>((IQueryable<PayRollUserPayments>)payRollUserPayments, Expression.Lambda<Func<PayRollUserPayments, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass6_, typeof(_003C_003Ec__DisplayClass6_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) != null)
			{
				try
				{
					TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.RequiresNew, new TransactionOptions
					{
						IsolationLevel = IsolationLevel.ReadUncommitted
					});
					using (transactionScope)
					{
						_db.PayRollspDeleteUserPayment(_003C_003Ec__DisplayClass6_.payId);
						DbSet<PayRollUserPayments> payRollUserPayments2 = _dbTbl.PayRollUserPayments;
						val = Expression.Parameter(typeof(PayRollUserPayments), "m");
						result = ((Queryable.FirstOrDefault<PayRollUserPayments>((IQueryable<PayRollUserPayments>)payRollUserPayments2, Expression.Lambda<Func<PayRollUserPayments, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass6_, typeof(_003C_003Ec__DisplayClass6_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) == null) ? "" : Messages.RedundancyMessage);
						transactionScope.Complete();
					}
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
		catch (Exception ex2)
		{
			ErrorSignal.FromCurrentContext().Raise(ex2);
			result = Messages.frmErrorMessage + " - " + ex2.Message;
		}
		return result;
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
			List<PayRollspSelectUserPaymentTypes_Result> list2 = Enumerable.ToList<PayRollspSelectUserPaymentTypes_Result>((IEnumerable<PayRollspSelectUserPaymentTypes_Result>)_db.PayRollspSelectUserPaymentTypes(lCID, result));
			list.AddRange(Enumerable.Select<PayRollspSelectUserPaymentTypes_Result, SelectListItem>((IEnumerable<PayRollspSelectUserPaymentTypes_Result>)list2, (Func<PayRollspSelectUserPaymentTypes_Result, SelectListItem>)((PayRollspSelectUserPaymentTypes_Result item) => new SelectListItem
			{
				Text = item.PaymentType,
				Value = item.PayRollUserPaymentTypeId.ToString(),
				Selected = false
			})));
			if (Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)list))
			{
				list[0].Selected = true;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PayTypeList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public void SetRegisterInfo(PayRollUserPaymentsLanguageViewModel model)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		string text2 = "";
		string text3 = "";
		try
		{
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (model.PayRollUserPaymentId > 0)
			{
				if (model.FirstRegisterUserId == currentUser.UserId)
				{
					text = currentUser.FullName;
				}
				else
				{
					CRMspSelectUsersById_Result cRMspSelectUsersById_Result = CRMIdeal.Classes.Helper.User.SelectUsersById(model.FirstRegisterUserId);
					text = ((cRMspSelectUsersById_Result != null) ? (cRMspSelectUsersById_Result.LName + ((cRMspSelectUsersById_Result.FName != null) ? (" " + cRMspSelectUsersById_Result.FName) : "")) : "");
				}
				if (model.UserId == currentUser.UserId)
				{
					text2 = currentUser.FullName;
				}
				else
				{
					CRMspSelectUsersById_Result cRMspSelectUsersById_Result2 = CRMIdeal.Classes.Helper.User.SelectUsersById(model.UserId);
					text2 = ((cRMspSelectUsersById_Result2 != null) ? (cRMspSelectUsersById_Result2.LName + ((cRMspSelectUsersById_Result2.FName != null) ? (" " + cRMspSelectUsersById_Result2.FName) : "")) : "");
				}
				if (string.IsNullOrEmpty(model.AppType))
				{
					model.AppType = Configuration.AppType;
				}
				text3 = Configuration.GetAppType(model.AppType);
			}
			else
			{
				text = currentUser.FullName;
				text2 = "";
				text3 = Configuration.GetAppType(Configuration.AppType);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.RegisterUser = text2;
		base.ViewBag.FirstRegisterUser = text;
		base.ViewBag.AppTypeHelp = text3;
	}

	[AjaxOnly]
	public JsonResult GetBankingAccounts(int cycleId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<PayRollspSelectUserBankingAccounts_Result> list = new List<PayRollspSelectUserBankingAccounts_Result>();
		try
		{
			int result2 = 0;
			PayRollspSelectUserCycleById_Result payRollspSelectUserCycleById_Result = Enumerable.FirstOrDefault<PayRollspSelectUserCycleById_Result>((IEnumerable<PayRollspSelectUserCycleById_Result>)_dbI.PayRollspSelectUserCycleById(cycleId, lCID, result));
			if (payRollspSelectUserCycleById_Result != null)
			{
				int.TryParse(payRollspSelectUserCycleById_Result.CrmUserId.ToString(), out result2);
			}
			list = Enumerable.ToList<PayRollspSelectUserBankingAccounts_Result>((IEnumerable<PayRollspSelectUserBankingAccounts_Result>)_dbI.PayRollspSelectUserBankingAccounts(result2, lCID, result));
			if (list != null && Enumerable.Any<PayRollspSelectUserBankingAccounts_Result>((IEnumerable<PayRollspSelectUserBankingAccounts_Result>)list))
			{
				foreach (PayRollspSelectUserBankingAccounts_Result item in list)
				{
					item.AccountTitle = item.AccountTitle ?? "";
					bool result3 = false;
					bool result4 = false;
					bool.TryParse(item.IsDefault.ToString(), out result3);
					bool.TryParse(item.IsDefaultII.ToString(), out result4);
					if (!(result3 || result4))
					{
						continue;
					}
					string text = "";
					if (result3)
					{
						text = Labels.PayRollUserPayBankingAccountDefault;
					}
					if (result4)
					{
						if (!string.IsNullOrWhiteSpace(text))
						{
							text += " - ";
						}
						text += Labels.PayRollUserPayBankingAccountDefaultII;
					}
					if (!string.IsNullOrWhiteSpace(text))
					{
						item.AccountTitle = item.AccountTitle + " (" + text + " )";
					}
				}
			}
			else
			{
				list = new List<PayRollspSelectUserBankingAccounts_Result>();
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

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		_dbI.Dispose();
		base.Dispose(disposing);
	}
}
