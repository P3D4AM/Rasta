using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.General.Security;
using CRM.General.Utilities;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Areas.OtherSystems.Controllers;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes.Common;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Newtonsoft.Json;

namespace CRMIdeal.Classes.Helper;

public class Order
{
	public class KaraAfzarMobDomainViewModel
	{
		public KaraAfzarMobDomainInfoViewModel mobCRM { get; set; }

		public KaraAfzarMobDomainInfoViewModel mobHRM { get; set; }

		public KaraAfzarMobDomainInfoViewModel mobCIC { get; set; }

		public KaraAfzarMobDomainInfoViewModel mobFo { get; set; }

		public KaraAfzarMobDomainInfoViewModel mobParsServiceSupport { get; set; }

		public KaraAfzarMobDomainInfoViewModel mobocsan { get; set; }

		public KaraAfzarMobDomainInfoViewModel mobhamgam { get; set; }

		public KaraAfzarMobDomainInfoViewModel mobkenaretam { get; set; }

		public KaraAfzarMobDomainInfoViewModel mobCRMShop { get; set; }
	}

	public class KaraAfzarMobDomainInfoViewModel
	{
		public string DomainAnd { get; set; }

		public string URLAnd { get; set; }

		public string DomainIos { get; set; }

		public string URLIos { get; set; }

		public string DomainPWA { get; set; }

		public string URLPWA { get; set; }

		public string CrossOrgURLPWA { get; set; }
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass0_0
	{
		public int orderId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public int orderId;

		public WSOrder model;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__3;

		internal bool _003CCalcAndSetOrderAmounts_003Eb__3(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_1
	{
		public WSOrder order;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass4_1 CS_0024_003C_003E8__locals1;
	}

	public const int _OprType_Returned = 2;

	public static bool IsFixed(int orderId = 0, int? isEditAfterFixMode = null)
	{
		_003C_003Ec__DisplayClass0_0 _003C_003Ec__DisplayClass0_ = new _003C_003Ec__DisplayClass0_0();
		_003C_003Ec__DisplayClass0_.orderId = orderId;
		bool result = false;
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		CRMTabelEntities cRMTabelEntities = new CRMTabelEntities();
		try
		{
			DbSet<WSOrder> wSOrder = cRMTabelEntities.WSOrder;
			ParameterExpression val = Expression.Parameter(typeof(WSOrder), "c");
			WSOrder wSOrder2 = Queryable.FirstOrDefault<WSOrder>((IQueryable<WSOrder>)wSOrder, Expression.Lambda<Func<WSOrder, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass0_, typeof(_003C_003Ec__DisplayClass0_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (wSOrder2 != null && wSOrder2.ordIsFixed.HasValue && wSOrder2.ordIsFixed.GetValueOrDefault())
			{
				result = true;
			}
			if (IsEditAfterFix(wSOrder2.ordEditAfterFixInfoJs, _003C_003Ec__DisplayClass0_.orderId, isEditAfterFixMode))
			{
				result = false;
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		finally
		{
			cRMSpEntities.Dispose();
			cRMTabelEntities.Dispose();
		}
		return result;
	}

	public static bool IsEditAfterFix(string editAfterFixInfoJs = "", int ordId = 0, int? mode = null)
	{
		bool result = false;
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int userId = UserLogin.CurrentUser.UserId;
			mode = mode.GetValueOrDefault(1);
			if (string.IsNullOrWhiteSpace(editAfterFixInfoJs) && ordId != 0)
			{
				WSspSelectOrderById_Result wSspSelectOrderById_Result = Enumerable.FirstOrDefault<WSspSelectOrderById_Result>((IEnumerable<WSspSelectOrderById_Result>)cRMSpEntities.WSspSelectOrderById(ordId, lCID, result2));
				if (wSspSelectOrderById_Result != null)
				{
					editAfterFixInfoJs = wSspSelectOrderById_Result.ordEditAfterFixInfoJs;
				}
			}
			List<EditAfterFixInfoViewModel> list = new List<EditAfterFixInfoViewModel>();
			if (!string.IsNullOrWhiteSpace((editAfterFixInfoJs ?? "").Replace("[]", "")))
			{
				bool flag = false;
				list = JsonConvert.DeserializeObject<List<EditAfterFixInfoViewModel>>(editAfterFixInfoJs);
				if (list != null)
				{
					EditAfterFixInfoViewModel editAfterFixInfoViewModel = Enumerable.FirstOrDefault<EditAfterFixInfoViewModel>((IEnumerable<EditAfterFixInfoViewModel>)list, (Func<EditAfterFixInfoViewModel, bool>)((EditAfterFixInfoViewModel x) => x.eafModeId == mode && x.eafUserId == userId && !x.eafIsDone.GetValueOrDefault()));
					if (editAfterFixInfoViewModel != null)
					{
						if (editAfterFixInfoViewModel.eafEndDate.HasValue)
						{
							if (editAfterFixInfoViewModel.eafEndDate >= DateTime.Now)
							{
								flag = true;
							}
						}
						else
						{
							flag = true;
						}
					}
					if (flag)
					{
						result = true;
					}
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return result;
	}

	public static bool CalcAndSetOrderAmounts(WSOrder order, bool autoCalcPriceNoChangeDiscount = false, bool autoCalcPriceNoChangeTax = false)
	{
		return CalcAndSetOrderAmounts(0, order, autoCalcPriceNoChangeDiscount, autoCalcPriceNoChangeTax);
	}

	public static bool CalcAndSetOrderAmounts(int orderId, bool autoCalcPriceNoChangeDiscount = false, bool autoCalcPriceNoChangeTax = false)
	{
		return CalcAndSetOrderAmounts(orderId, null, autoCalcPriceNoChangeDiscount, autoCalcPriceNoChangeTax);
	}

	private static bool CalcAndSetOrderAmounts(int orderId, WSOrder model, bool autoCalcPriceNoChangeDiscount = false, bool autoCalcPriceNoChangeTax = false)
	{
		_003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass4_0();
		CS_0024_003C_003E8__locals0.orderId = orderId;
		CS_0024_003C_003E8__locals0.model = model;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		bool result = false;
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		CRMTabelEntities cRMTabelEntities = new CRMTabelEntities();
		CRMSpIIEntities cRMSpIIEntities = new CRMSpIIEntities();
		try
		{
			_003C_003Ec__DisplayClass4_1 _003C_003Ec__DisplayClass4_ = new _003C_003Ec__DisplayClass4_1();
			_003C_003Ec__DisplayClass4_.order = CS_0024_003C_003E8__locals0.model;
			if (_003C_003Ec__DisplayClass4_.order == null)
			{
				DbSet<WSOrder> wSOrder = cRMTabelEntities.WSOrder;
				ParameterExpression val = Expression.Parameter(typeof(WSOrder), "c");
				_003C_003Ec__DisplayClass4_.order = Queryable.FirstOrDefault<WSOrder>((IQueryable<WSOrder>)wSOrder, Expression.Lambda<Func<WSOrder, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass4_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			}
			else
			{
				DbSet<WSOrder> wSOrder2 = cRMTabelEntities.WSOrder;
				ParameterExpression val = Expression.Parameter(typeof(WSOrder), "c");
				_003C_003Ec__DisplayClass4_.order = Queryable.FirstOrDefault<WSOrder>((IQueryable<WSOrder>)wSOrder2, Expression.Lambda<Func<WSOrder, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass4_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			}
			CS_0024_003C_003E8__locals0.orderId = _003C_003Ec__DisplayClass4_.order.OrderID;
			if (CS_0024_003C_003E8__locals0.orderId != 0)
			{
				ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
				DateTime now = DateTime.Now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short value = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				_ = Financial.Get().Id;
				int userId = UserLogin.CurrentUser.UserId;
				cRMSpIIEntities.WSspAutoCalcAndUpdateOrderItemPrice(CS_0024_003C_003E8__locals0.orderId, userId, value, now, registerDatePersian, appType, CS_0024_003C_003E8__locals0.defLangID, autoCalcPriceNoChangeDiscount, autoCalcPriceNoChangeTax, objectParameter);
				if (objectParameter != null && objectParameter.Value != null)
				{
					string text = objectParameter.Value.ToString();
					if (!string.IsNullOrWhiteSpace(text))
					{
						Public.InsTextToElmah(text);
					}
				}
			}
			if (CS_0024_003C_003E8__locals0.orderId != 0)
			{
				ObjectParameter result2 = new ObjectParameter("result", 0);
				short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
				cRMSpIIEntities.WSspCalcAndUpdateOrderItemsTax(CS_0024_003C_003E8__locals0.orderId, value2, result2);
			}
			WSfnReturnOrderSumFooter_Result wSfnReturnOrderSumFooter_Result = Enumerable.FirstOrDefault<WSfnReturnOrderSumFooter_Result>((IEnumerable<WSfnReturnOrderSumFooter_Result>)Enumerable.ToList<WSfnReturnOrderSumFooter_Result>((IEnumerable<WSfnReturnOrderSumFooter_Result>)cRMSpEntities.WSfnReturnOrderSumFooter(CS_0024_003C_003E8__locals0.orderId)));
			if (wSfnReturnOrderSumFooter_Result != null)
			{
				decimal num = Convert.ToDecimal(wSfnReturnOrderSumFooter_Result.SumPriceAmount.GetValueOrDefault());
				if (num >= 0m)
				{
					decimal num2 = num;
					decimal valueOrDefault = _003C_003Ec__DisplayClass4_.order.ordInstallAmount.GetValueOrDefault();
					decimal num3 = _003C_003Ec__DisplayClass4_.order.ordDiscount.GetValueOrDefault();
					if (_003C_003Ec__DisplayClass4_.order.ordDiscountPercent.HasValue)
					{
						decimal valueOrDefault2 = _003C_003Ec__DisplayClass4_.order.ordDiscountPercent.GetValueOrDefault();
						if (valueOrDefault2 > 0m)
						{
							num3 = Convert.ToDecimal(num * valueOrDefault2) / 100m;
						}
					}
					decimal valueOrDefault3 = _003C_003Ec__DisplayClass4_.order.ordTransportation.GetValueOrDefault();
					decimal valueOrDefault4 = _003C_003Ec__DisplayClass4_.order.ordRound.GetValueOrDefault();
					decimal num4 = num2 + valueOrDefault - num3;
					decimal valueOrDefault5 = _003C_003Ec__DisplayClass4_.order.ordTaxIndex.GetValueOrDefault();
					decimal num5 = ((_003C_003Ec__DisplayClass4_.order.ordCalculateTax.HasValue && _003C_003Ec__DisplayClass4_.order.ordCalculateTax.GetValueOrDefault()) ? (num4 * valueOrDefault5 / 100m) : 0m);
					decimal num6 = num4 + num5 + valueOrDefault3 - valueOrDefault4;
					double valueOrDefault6 = wSfnReturnOrderSumFooter_Result.SumQuantity.GetValueOrDefault();
					decimal num7 = wSfnReturnOrderSumFooter_Result.TotalDiscountSum.GetValueOrDefault();
					decimal num8 = wSfnReturnOrderSumFooter_Result.TotalTaxSum.GetValueOrDefault();
					bool result3 = false;
					WSspSelectCurrencyUnitsWithId_Result wSspSelectCurrencyUnitsWithId_Result = Enumerable.FirstOrDefault<WSspSelectCurrencyUnitsWithId_Result>((IEnumerable<WSspSelectCurrencyUnitsWithId_Result>)cRMSpEntities.WSspSelectCurrencyUnitsWithId(_003C_003Ec__DisplayClass4_.order.ordCurrencyUnitId, lCID, CS_0024_003C_003E8__locals0.defLangID));
					if (wSspSelectCurrencyUnitsWithId_Result != null)
					{
						bool.TryParse(wSspSelectCurrencyUnitsWithId_Result.IsDecimal.ToString(), out result3);
					}
					if (!result3)
					{
						if (num > 0m)
						{
							num = RoundCalculation.RoundNumber(num);
						}
						num4 = RoundCalculation.RoundNumber(num4);
						num5 = RoundCalculation.RoundNumber(num5);
						num3 = RoundCalculation.RoundNumber(num3);
						num6 = RoundCalculation.RoundNumber(num6);
						num7 = RoundCalculation.RoundNumber(num7);
						num8 = RoundCalculation.RoundNumber(num8);
					}
					DbSet<WSOrderItems> wSOrderItems = cRMTabelEntities.WSOrderItems;
					ParameterExpression val = Expression.Parameter(typeof(WSOrderItems), "c");
					int value3 = Queryable.Count<WSOrderItems>((IQueryable<WSOrderItems>)wSOrderItems, Expression.Lambda<Func<WSOrderItems, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass4_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
					_003C_003Ec__DisplayClass4_.order.ordItemCount = value3;
					_003C_003Ec__DisplayClass4_.order.ordItemsAmount = num;
					_003C_003Ec__DisplayClass4_.order.ordSumAmount = num4;
					_003C_003Ec__DisplayClass4_.order.ordTax = num5;
					_003C_003Ec__DisplayClass4_.order.ordItemsQty = valueOrDefault6;
					_003C_003Ec__DisplayClass4_.order.ordItemsDiscount = num7;
					_003C_003Ec__DisplayClass4_.order.ordItemsTax = num8;
					_003C_003Ec__DisplayClass4_.order.ordTotalAmount = num6;
					string[] array = num6.ToString().Split(new char[1] { '.' });
					if (Enumerable.Count<string>((IEnumerable<string>)array) > 1 && !string.IsNullOrEmpty(array[1]))
					{
						array[1] = ((array[1].Length == 2) ? array[1] : array[1].Substring(0, 2));
					}
					if (CS_0024_003C_003E8__locals0.defLangID == 1065)
					{
						if (Enumerable.Any<string>((IEnumerable<string>)array))
						{
							_003C_003Ec__DisplayClass4_.order.ordTotalAmountStr = SayNumber.GetNumber(Convert.ToDouble(array[0]));
							if (Enumerable.Count<string>((IEnumerable<string>)array) > 1 && !string.IsNullOrEmpty(array[1]) && num6 > 0m && !string.IsNullOrEmpty(array[1]) && int.Parse(array[1]) > 0)
							{
								WSOrder order = _003C_003Ec__DisplayClass4_.order;
								order.ordTotalAmountStr = order.ordTotalAmountStr + "." + SayNumber.GetNumber(Convert.ToDouble(array[1]));
							}
						}
					}
					else if (CS_0024_003C_003E8__locals0.defLangID == 1025)
					{
						if (Enumerable.Any<string>((IEnumerable<string>)array))
						{
							_003C_003Ec__DisplayClass4_.order.ordTotalAmountStr = SayNumber.GetNumberInArabic(Convert.ToDouble(array[0]));
							if (Enumerable.Count<string>((IEnumerable<string>)array) > 1 && !string.IsNullOrEmpty(array[1]) && num6 > 0m && !string.IsNullOrEmpty(array[1]) && int.Parse(array[1]) > 0)
							{
								WSOrder order2 = _003C_003Ec__DisplayClass4_.order;
								order2.ordTotalAmountStr = order2.ordTotalAmountStr + "." + SayNumber.GetNumberInArabic(Convert.ToDouble(array[1]));
							}
						}
					}
					else if (Enumerable.Any<string>((IEnumerable<string>)array))
					{
						_003C_003Ec__DisplayClass4_.order.ordTotalAmountStr = SayNumber.GetNumberInEnglish(Convert.ToDouble(array[0]));
						if (Enumerable.Count<string>((IEnumerable<string>)array) > 1 && !string.IsNullOrEmpty(array[1]) && num6 > 0m && !string.IsNullOrEmpty(array[1]) && int.Parse(array[1]) > 0)
						{
							WSOrder order3 = _003C_003Ec__DisplayClass4_.order;
							order3.ordTotalAmountStr = order3.ordTotalAmountStr + "." + SayNumber.GetNumberInEnglish(Convert.ToDouble(array[1]));
						}
					}
					_003C_003Ec__DisplayClass4_.order.ordDiscount = num3;
					_003C_003Ec__DisplayClass4_.order.Month1 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					cRMTabelEntities.Entry(_003C_003Ec__DisplayClass4_.order).State = EntityState.Modified;
					cRMTabelEntities.Configuration.ValidateOnSaveEnabled = false;
					cRMTabelEntities.SaveChanges();
					cRMTabelEntities.Configuration.ValidateOnSaveEnabled = true;
					using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							_003C_003Ec__DisplayClass4_2 _003C_003Ec__DisplayClass4_2 = new _003C_003Ec__DisplayClass4_2();
							_003C_003Ec__DisplayClass4_2.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass4_;
							_003C_003Ec__DisplayClass4_2.lang = enumerator.Current;
							DbSet<WSOrder_Lang> wSOrder_Lang = cRMTabelEntities.WSOrder_Lang;
							val = Expression.Parameter(typeof(WSOrder_Lang), "c");
							WSOrder_Lang wSOrder_Lang2 = Queryable.FirstOrDefault<WSOrder_Lang>((IQueryable<WSOrder_Lang>)wSOrder_Lang, Expression.Lambda<Func<WSOrder_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass4_2, typeof(_003C_003Ec__DisplayClass4_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass4_2, typeof(_003C_003Ec__DisplayClass4_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (wSOrder_Lang2 != null)
							{
								if (wSOrder_Lang2.LanguageID == 1065)
								{
									if (Enumerable.Any<string>((IEnumerable<string>)array))
									{
										wSOrder_Lang2.ordTotalAmountStr = SayNumber.GetNumber(Convert.ToDouble(array[0]));
										if (Enumerable.Count<string>((IEnumerable<string>)array) > 1 && !string.IsNullOrEmpty(array[1]) && num6 > 0m && !string.IsNullOrEmpty(array[1]) && int.Parse(array[1]) > 0)
										{
											WSOrder_Lang wSOrder_Lang3 = wSOrder_Lang2;
											wSOrder_Lang3.ordTotalAmountStr = wSOrder_Lang3.ordTotalAmountStr + "." + SayNumber.GetNumber(Convert.ToDouble(array[1]));
										}
									}
								}
								else if (wSOrder_Lang2.LanguageID == 1025)
								{
									if (Enumerable.Any<string>((IEnumerable<string>)array))
									{
										wSOrder_Lang2.ordTotalAmountStr = SayNumber.GetNumberInArabic(Convert.ToDouble(array[0]));
										if (Enumerable.Count<string>((IEnumerable<string>)array) > 1 && !string.IsNullOrEmpty(array[1]) && num6 > 0m && !string.IsNullOrEmpty(array[1]) && int.Parse(array[1]) > 0)
										{
											WSOrder_Lang wSOrder_Lang4 = wSOrder_Lang2;
											wSOrder_Lang4.ordTotalAmountStr = wSOrder_Lang4.ordTotalAmountStr + "." + SayNumber.GetNumberInArabic(Convert.ToDouble(array[1]));
										}
									}
								}
								else if (Enumerable.Any<string>((IEnumerable<string>)array))
								{
									wSOrder_Lang2.ordTotalAmountStr = SayNumber.GetNumberInEnglish(Convert.ToDouble(array[0]));
									if (Enumerable.Count<string>((IEnumerable<string>)array) > 1 && !string.IsNullOrEmpty(array[1]) && num6 > 0m && !string.IsNullOrEmpty(array[1]) && int.Parse(array[1]) > 0)
									{
										WSOrder_Lang wSOrder_Lang5 = wSOrder_Lang2;
										wSOrder_Lang5.ordTotalAmountStr = wSOrder_Lang5.ordTotalAmountStr + "." + SayNumber.GetNumberInEnglish(Convert.ToDouble(array[1]));
									}
								}
								cRMTabelEntities.Entry(wSOrder_Lang2).State = EntityState.Modified;
								cRMTabelEntities.SaveChanges();
								continue;
							}
							wSOrder_Lang2 = new WSOrder_Lang();
							wSOrder_Lang2.LanguageID = _003C_003Ec__DisplayClass4_2.lang.LanguageID;
							wSOrder_Lang2.OrderID = _003C_003Ec__DisplayClass4_2.CS_0024_003C_003E8__locals1.order.OrderID;
							if (wSOrder_Lang2.LanguageID == 1065)
							{
								if (Enumerable.Any<string>((IEnumerable<string>)array))
								{
									wSOrder_Lang2.ordTotalAmountStr = SayNumber.GetNumber(Convert.ToDouble(array[0]));
									if (Enumerable.Count<string>((IEnumerable<string>)array) > 1 && !string.IsNullOrEmpty(array[1]) && num6 > 0m && !string.IsNullOrEmpty(array[1]) && int.Parse(array[1]) > 0)
									{
										WSOrder_Lang wSOrder_Lang6 = wSOrder_Lang2;
										wSOrder_Lang6.ordTotalAmountStr = wSOrder_Lang6.ordTotalAmountStr + "." + SayNumber.GetNumber(Convert.ToDouble(array[1]));
									}
								}
							}
							else if (wSOrder_Lang2.LanguageID == 1025)
							{
								if (Enumerable.Any<string>((IEnumerable<string>)array))
								{
									wSOrder_Lang2.ordTotalAmountStr = SayNumber.GetNumberInArabic(Convert.ToDouble(array[0]));
									if (Enumerable.Count<string>((IEnumerable<string>)array) > 1 && !string.IsNullOrEmpty(array[1]) && num6 > 0m && !string.IsNullOrEmpty(array[1]) && int.Parse(array[1]) > 0)
									{
										WSOrder_Lang wSOrder_Lang7 = wSOrder_Lang2;
										wSOrder_Lang7.ordTotalAmountStr = wSOrder_Lang7.ordTotalAmountStr + "." + SayNumber.GetNumberInArabic(Convert.ToDouble(array[1]));
									}
								}
							}
							else if (Enumerable.Any<string>((IEnumerable<string>)array))
							{
								wSOrder_Lang2.ordTotalAmountStr = SayNumber.GetNumberInEnglish(Convert.ToDouble(array[0]));
								if (Enumerable.Count<string>((IEnumerable<string>)array) > 1 && !string.IsNullOrEmpty(array[1]) && num6 > 0m && !string.IsNullOrEmpty(array[1]) && int.Parse(array[1]) > 0)
								{
									WSOrder_Lang wSOrder_Lang8 = wSOrder_Lang2;
									wSOrder_Lang8.ordTotalAmountStr = wSOrder_Lang8.ordTotalAmountStr + "." + SayNumber.GetNumberInEnglish(Convert.ToDouble(array[1]));
								}
							}
							cRMTabelEntities.WSOrder_Lang.Add(wSOrder_Lang2);
							cRMTabelEntities.SaveChanges();
						}
					}
					result = SetPaymentStatus(_003C_003Ec__DisplayClass4_.order);
				}
				else
				{
					result = true;
				}
			}
			if (CS_0024_003C_003E8__locals0.orderId != 0)
			{
				ObjectParameter result4 = new ObjectParameter("result", 0);
				DateTime now2 = DateTime.Now;
				short value4 = short.Parse(now2.ToString("MM", new PersianCulture()));
				cRMSpIIEntities.WSspCalcAndUpdateOrderOtherAmounts(CS_0024_003C_003E8__locals0.orderId, value4, now2, result4);
			}
			if (CS_0024_003C_003E8__locals0.orderId != 0)
			{
				cRMSpIIEntities.WSspCalcAndUpdateOrderAmountsCurrency(CS_0024_003C_003E8__locals0.orderId, lCID, CS_0024_003C_003E8__locals0.defLangID);
			}
			if (CS_0024_003C_003E8__locals0.orderId != 0)
			{
				CalcOrderCancelledScores(CS_0024_003C_003E8__locals0.orderId);
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		finally
		{
			cRMSpEntities.Dispose();
			cRMTabelEntities.Dispose();
			cRMSpIIEntities.Dispose();
		}
		return result;
	}

	public static bool SetPaymentStatus(WSOrder order)
	{
		return SetPaymentStatus(0, order);
	}

	public static bool SetPaymentStatus(int orderId)
	{
		return SetPaymentStatus(orderId, null);
	}

	private static bool SetPaymentStatus(int orderId, WSOrder order)
	{
		bool result = false;
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		CRMTabelEntities cRMTabelEntities = new CRMTabelEntities();
		try
		{
			if (order == null)
			{
				order = cRMTabelEntities.WSOrder.Find(orderId);
			}
			orderId = order.OrderID;
			WSspReturnSumOrderPay_Result wSspReturnSumOrderPay_Result = Enumerable.FirstOrDefault<WSspReturnSumOrderPay_Result>((IEnumerable<WSspReturnSumOrderPay_Result>)Enumerable.ToList<WSspReturnSumOrderPay_Result>((IEnumerable<WSspReturnSumOrderPay_Result>)cRMSpEntities.WSspReturnSumOrderPay(orderId)));
			if (wSspReturnSumOrderPay_Result != null)
			{
				if (order.ordStatusId.GetValueOrDefault() == 4 || order.ordStatusId.GetValueOrDefault() == 5)
				{
					return true;
				}
				decimal? sumordpayAmount = wSspReturnSumOrderPay_Result.sumordpayAmount;
				if ((sumordpayAmount.GetValueOrDefault() == default(decimal)) & sumordpayAmount.HasValue)
				{
					if (order.ordStatusId.GetValueOrDefault() == 1)
					{
						return true;
					}
					cRMSpEntities.WSspUpdateOrderStatus(orderId, 1);
				}
				else if (order.ordTotalAmount > wSspReturnSumOrderPay_Result.sumordpayAmount)
				{
					if (order.ordStatusId.GetValueOrDefault() == 2)
					{
						return true;
					}
					cRMSpEntities.WSspUpdateOrderStatus(orderId, 2);
				}
				else if (order.ordTotalAmount <= wSspReturnSumOrderPay_Result.sumordpayAmount)
				{
					if (order.ordStatusId.GetValueOrDefault() == 3)
					{
						return true;
					}
					cRMSpEntities.WSspUpdateOrderStatus(orderId, 3);
				}
				result = true;
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		finally
		{
			cRMSpEntities.Dispose();
			cRMTabelEntities.Dispose();
		}
		return result;
	}

	public static WSspReturnDraftFromOrder_Result ReturnDraftFromOrder(int orderId)
	{
		WSspReturnDraftFromOrder_Result result = null;
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			result = Enumerable.LastOrDefault<WSspReturnDraftFromOrder_Result>((IEnumerable<WSspReturnDraftFromOrder_Result>)cRMSpEntities.WSspReturnDraftFromOrder(orderId, lCID, result2));
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		finally
		{
			cRMSpEntities.Dispose();
		}
		return result;
	}

	public static string VerifyOrderComplete(int id, string formName = "frmOrder", bool actVerifyOrder_Value = false, bool actVerifyOrder_Passed = false, bool actAutoReferOrderToWrhsUserAfterVerify_Value = false, bool actIssueDraftAuto_Value = false, string actIssueDraftAuto_Name = "actIssueDraftAuto", bool actGetOrdFOLink_Value = false, int? currentLoginUserId = null)
	{
		string text = "";
		CRMspLoadUserLoginInfoViewModel cRMspLoadUserLoginInfoViewModel = null;
		cRMspLoadUserLoginInfoViewModel = ((currentLoginUserId.GetValueOrDefault() == 0) ? UserLogin.CurrentUser : UserLogin.User(currentLoginUserId));
		int result = 0;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result);
		}
		if (!actVerifyOrder_Value)
		{
			return Messages.DoNotHaveAccess;
		}
		if (!actVerifyOrder_Passed)
		{
			text = VerifyOrder(id, currentLoginUserId);
			if (!string.IsNullOrWhiteSpace(text))
			{
				return text;
			}
		}
		if (actAutoReferOrderToWrhsUserAfterVerify_Value)
		{
			ReferOrderToWrhsUser(id, currentLoginUserId);
		}
		if (actIssueDraftAuto_Value)
		{
			string text2 = "";
			string text3 = "";
			string refResult = "";
			bool flag = IssueDraftAuto(id, cRMspLoadUserLoginInfoViewModel.UserId, ref refResult, 0, formName, actIssueDraftAuto_Name, result);
			if (!string.IsNullOrWhiteSpace(refResult))
			{
				if (flag)
				{
					text3 = refResult;
				}
				else
				{
					text2 = refResult;
				}
			}
			text = "1|" + cRMspLoadUserLoginInfoViewModel.UserId + "|" + cRMspLoadUserLoginInfoViewModel.FullName + " (" + DateTime.Now.ToString("yyyy/MM/dd HH:mm") + ")";
			if (!string.IsNullOrWhiteSpace(text2))
			{
				return text + "|doc-1^,^" + text2;
			}
			if (!string.IsNullOrWhiteSpace(text3))
			{
				text = text + "|doc1^,^" + text3;
			}
		}
		if (!string.IsNullOrWhiteSpace(CalcScoreWithId(id, currentLoginUserId, result)))
		{
			return text;
		}
		if (id > 0)
		{
			string msg = "";
			AddProjectProductHistoryFromOrder(id, addPrdValidity: false, "", ref msg, currentLoginUserId);
			if (!string.IsNullOrWhiteSpace(msg))
			{
				Public.InsTextToElmah(msg);
			}
		}
		SendSMSOrdFOLinkAfterVerify(id, actGetOrdFOLink_Value, currentLoginUserId);
		SendSmsFoSettingOrdAfterVerify(id, currentLoginUserId);
		return text;
	}

	public static string VerifyOrder(int id, int? currentLoginUserId = null)
	{
		string text = "";
		CRMspLoadUserLoginInfoViewModel cRMspLoadUserLoginInfoViewModel = null;
		cRMspLoadUserLoginInfoViewModel = ((currentLoginUserId.GetValueOrDefault() == 0) ? UserLogin.CurrentUser : UserLogin.User(currentLoginUserId));
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		new CRMSpIEntities();
		try
		{
			DateTime now = DateTime.Now;
			now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			short.Parse(Financial.Get().Id.ToString());
			_ = cRMspLoadUserLoginInfoViewModel.UserId;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			WSspSelectOrderById_Result wSspSelectOrderById_Result = Enumerable.FirstOrDefault<WSspSelectOrderById_Result>((IEnumerable<WSspSelectOrderById_Result>)cRMSpEntities.WSspSelectOrderById(id, lCID, result));
			if (wSspSelectOrderById_Result != null)
			{
				string text2 = CheckBeforeVerification(wSspSelectOrderById_Result.OrderID, "", 1, currentLoginUserId);
				if (!string.IsNullOrWhiteSpace(text2))
				{
					return text + text2 + "<br/>";
				}
				cRMSpEntities.WSspOrderVerify(id, cRMspLoadUserLoginInfoViewModel.UserId, DateTime.Now.ToString("yyyyMMdd", new PersianCulture()));
			}
			else
			{
				text = Messages.ErrorNotFound;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			text = Messages.frmErrorMessage;
		}
		return text;
	}

	public static CommonResultViewModel<string> GetOrdFOLink(int ordId = 0, bool actGetOrdFOLink = false)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string data = "";
		string text = "";
		CommonResultStatusViewModel status = CommonResultStatusViewModel.Fail;
		new CommonResultViewModel<string>();
		try
		{
			if (ordId != 0)
			{
				if (!actGetOrdFOLink)
				{
					text = Messages.ErrorNotAccess;
				}
				else
				{
					CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
					if (cRMspSelectCrmsysSetting_Result != null)
					{
						string text2 = cRMspSelectCrmsysSetting_Result.FOUrl ?? "";
						text2 = text2.Trim();
						if (!string.IsNullOrWhiteSpace(text2))
						{
							if (!text2.StartsWith("http"))
							{
								text2 = "http://" + text2;
							}
							if (text2.EndsWith("/"))
							{
								text2 = text2.Substring(0, text2.Length - 1);
							}
							string text3 = CodeDecode.CoddingUTF8(ordId.ToString());
							text2 = text2 + "?" + "Ord".ToLower() + "=" + text3;
							data = text2;
							text = Messages.msgSuccessAction;
							status = CommonResultStatusViewModel.Success;
						}
						else
						{
							text = Messages.errorInReadingSetting;
						}
					}
					else
					{
						text = Messages.errorInReadingSetting;
					}
				}
			}
			else
			{
				text = string.Format(Messages.msgErrorIsNotSelectedItem, Labels.lblPOrd);
				data = null;
				status = CommonResultStatusViewModel.Fail;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			text = Messages.msgErrorRunFunction;
			data = "";
			status = CommonResultStatusViewModel.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return new CommonResultViewModel<string>
		{
			Message = text,
			Data = data,
			Status = status
		};
	}

	public static string CalcScoreWithId(int orderId, int? currentLoginUserId = null, int? cId = null)
	{
		string result = "";
		CRMSpIEntities cRMSpIEntities = new CRMSpIEntities();
		try
		{
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			short value3 = short.Parse(Financial.Get().Id.ToString());
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			if (cId.GetValueOrDefault() == 0)
			{
				cId = result3;
			}
			int num = currentLoginUserId.GetValueOrDefault();
			if (num == 0)
			{
				num = UserLogin.CurrentUser.UserId;
			}
			int? orderId2 = orderId;
			bool? calcAutoScoreInIssue = false;
			bool? calcAutoScoreInVerify = true;
			cRMSpIEntities.ScorespInsertAndCalcOrderScores(null, orderId2, null, null, null, calcAutoScoreInIssue, calcAutoScoreInVerify, DateTime.Now, num, value3, value2, value, registerDatePersian, appType, lCID, result2, null, true, cId);
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			result = Messages.msgErrorOperationFailed;
		}
		finally
		{
			cRMSpIEntities?.Dispose();
		}
		return result;
	}

	public static string SendSMSOrdFOLinkAfterVerify(int id, bool actGetOrdFOLink_Value = false, int? currentLoginUserId = null)
	{
		string text = "";
		try
		{
			DateTime now = DateTime.Now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			short value2 = short.Parse(Financial.Get().Id.ToString());
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			int num = currentLoginUserId.GetValueOrDefault();
			if (num == 0)
			{
				num = UserLogin.CurrentUser.UserId;
			}
			CRMSpIEntities cRMSpIEntities = new CRMSpIEntities();
			bool? sendSMSOrdFOLinkAfterVerify = SysSeting.Get().SendSMSOrdFOLinkAfterVerify;
			int? sendSMSOrdFOLinkAfterVerifyType = SysSeting.Get().SendSMSOrdFOLinkAfterVerifyType;
			string text2 = "";
			string text3 = "";
			string text4 = "";
			string text5 = "";
			if (sendSMSOrdFOLinkAfterVerify.GetValueOrDefault())
			{
				List<SelectListItem> ordFoShortLinks = GetOrdFoShortLinks(id, currentLoginUserId);
				text3 = ordFoShortLinks[1].Value;
				text4 = ordFoShortLinks[2].Value;
				text5 = ordFoShortLinks[3].Value;
				if (sendSMSOrdFOLinkAfterVerifyType.GetValueOrDefault() == 1)
				{
					text2 = text3;
				}
				else if (sendSMSOrdFOLinkAfterVerifyType.GetValueOrDefault() == 2)
				{
					text2 = text4;
				}
				else if (sendSMSOrdFOLinkAfterVerifyType.GetValueOrDefault() == 3)
				{
					text2 = text5;
				}
			}
			if (!string.IsNullOrWhiteSpace(text2))
			{
				ObjectParameter objectParameter = new ObjectParameter("Result", 0);
				cRMSpIEntities.CRMspSendSmsOrdFOLinkAfterVerify(id, text2, text3, text4, num, value2, value, registerDatePersian, appType, lCID, result, objectParameter, text5, centerId);
				if (objectParameter != null && (int)objectParameter.Value == 1 && text != "")
				{
					text += "<br>";
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return text;
	}

	public static int OrderItemsDoneTimeSum(int ordId = 0, int currOrdItemId = 0)
	{
		int result = 0;
		CRMSpIIEntities cRMSpIIEntities = new CRMSpIIEntities();
		try
		{
			if (ordId != 0)
			{
				WSspReturnOrderItemsDoneTimeSum_Result wSspReturnOrderItemsDoneTimeSum_Result = Enumerable.FirstOrDefault<WSspReturnOrderItemsDoneTimeSum_Result>((IEnumerable<WSspReturnOrderItemsDoneTimeSum_Result>)cRMSpIIEntities.WSspReturnOrderItemsDoneTimeSum(ordId, currOrdItemId));
				if (wSspReturnOrderItemsDoneTimeSum_Result != null)
				{
					result = wSspReturnOrderItemsDoneTimeSum_Result.DoneTimeMinSum;
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		finally
		{
			cRMSpIIEntities?.Dispose();
		}
		return result;
	}

	public static bool ReferOrderToWrhsUser(int orderId, int? currentLoginUserId = null)
	{
		bool result = false;
		CRMSpIEntities cRMSpIEntities = new CRMSpIEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
			if (defLangID <= 0)
			{
				defLangID = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			if (orderId != 0)
			{
				DateTime now = DateTime.Now;
				DateTime value = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				short value3 = short.Parse(now.ToString("yyyy", new PersianCulture()));
				int num = currentLoginUserId.GetValueOrDefault();
				if (num == 0)
				{
					num = UserLogin.CurrentUser.UserId;
				}
				List<CrmInternalMessage_Lang> list = new List<CrmInternalMessage_Lang>();
				foreach (Languages item in Enumerable.ToList<Languages>((IEnumerable<Languages>)Language.Get()))
				{
					CrmInternalMessage_Lang crmInternalMessage_Lang = new CrmInternalMessage_Lang();
					crmInternalMessage_Lang.LanguageID = item.LanguageID;
					crmInternalMessage_Lang.msgSubject = MyResource.GetResourceString("ordVerifiedRequestSubject", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
					crmInternalMessage_Lang.msgBody = MyResource.GetResourceString("ordVerifiedRequest", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly) + "-" + MyResource.GetResourceString("ordVerifiedRequestOrdAtach", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly) + "\n" + MyResource.GetResourceString("ordVerifiedRequestOrdNumber", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly) + ": [#ordNumber#]\n" + MyResource.GetResourceString("ordVerifiedRequestOrdDate", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly) + ": [#ordDate#]\n" + MyResource.GetResourceString("ordVerifiedRequestCompanayName", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly) + ": [#CmpName#]\n" + MyResource.GetResourceString("ordVerifiedRequestReferUserName", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly) + ": [#ReferUser#]\n" + MyResource.GetResourceString("ordVerifiedRequestFirstRegisterUserName", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly) + ": [#FirstRegisterUser#]\n" + MyResource.GetResourceString("ordVerifiedRequestOrdVerified", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly) + ": [#Verifier#]\n" + MyResource.GetResourceString("ordVerifiedRequestDbClickOnOtherInfo", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly) + "\n";
					list.Add(crmInternalMessage_Lang);
				}
				string intMsgBody = "";
				string intMsgSubject = "";
				string intMsgLang = "";
				if (list != null && Enumerable.Any<CrmInternalMessage_Lang>((IEnumerable<CrmInternalMessage_Lang>)list))
				{
					intMsgSubject = (Enumerable.Any<CrmInternalMessage_Lang>((IEnumerable<CrmInternalMessage_Lang>)list, (Func<CrmInternalMessage_Lang, bool>)((CrmInternalMessage_Lang c) => c.LanguageID == defLangID)) ? Enumerable.FirstOrDefault<CrmInternalMessage_Lang>((IEnumerable<CrmInternalMessage_Lang>)list, (Func<CrmInternalMessage_Lang, bool>)((CrmInternalMessage_Lang c) => c.LanguageID == defLangID)).msgSubject : "");
					intMsgBody = (Enumerable.Any<CrmInternalMessage_Lang>((IEnumerable<CrmInternalMessage_Lang>)list, (Func<CrmInternalMessage_Lang, bool>)((CrmInternalMessage_Lang c) => c.LanguageID == defLangID)) ? Enumerable.FirstOrDefault<CrmInternalMessage_Lang>((IEnumerable<CrmInternalMessage_Lang>)list, (Func<CrmInternalMessage_Lang, bool>)((CrmInternalMessage_Lang c) => c.LanguageID == defLangID)).msgBody : "");
					intMsgLang = JsonConvert.SerializeObject(Enumerable.ToList<CrmInternalMessage_Lang>(Enumerable.Where<CrmInternalMessage_Lang>((IEnumerable<CrmInternalMessage_Lang>)list, (Func<CrmInternalMessage_Lang, bool>)((CrmInternalMessage_Lang c) => c.LanguageID != defLangID))));
				}
				mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)cRMSpIEntities.WSspReferOrderToWrhsUser(orderId, intMsgBody, intMsgSubject, intMsgLang, num, value3, value2, value, registerDatePersian, appType, defLangID, centerId));
				int result2 = 0;
				if (mct_I_Result != null)
				{
					int.TryParse(mct_I_Result.Result.ToString(), out result2);
				}
				result = result2 == 1;
				PushNotif.NewIntMsgNotify();
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		finally
		{
			cRMSpIEntities.Dispose();
		}
		return result;
	}

	public static void AddProjectProductHistoryFromOrder(int orderId, bool addPrdValidity, string addPrdValidityPrjTitle, ref string msg, int? currentLoginUserId = null)
	{
		CRMSpIEntities cRMSpIEntities = new CRMSpIEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (orderId != 0)
			{
				int? centerId = null;
				if (UserLogin.CurrentUser != null)
				{
					centerId = UserLogin.CurrentUser.UserLastCId;
				}
				DateTime now = DateTime.Now;
				DateTime value = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				short value3 = short.Parse(Financial.Get().Id.ToString());
				int num = currentLoginUserId.GetValueOrDefault();
				if (num == 0)
				{
					num = UserLogin.CurrentUser.UserId;
				}
				mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)cRMSpIEntities.CRMspAddProjectProductHistoryFromOrder(orderId, addPrdValidity, addPrdValidityPrjTitle, num, value3, value2, value, registerDatePersian, appType, lCID, result, centerId));
				int result2 = 0;
				if (mct_I_Result != null)
				{
					int.TryParse(mct_I_Result.Result.ToString(), out result2);
				}
				switch (result2)
				{
				case -100:
				case 0:
					msg = Messages.msgErrorRunFunction;
					break;
				case -1:
					msg = "msgErrorNoSavePrjPrdHisByOrdNotVerified".OrderMessages();
					break;
				case -2:
					msg = "msgErrorNoSavePrjPrdHisNoSelectedPrj".OrderMessages();
					break;
				case -3:
					msg = "msgErrorNoSavePrjPrdHisNoDefaultPrjTitles".OrderMessages();
					break;
				case -4:
					msg = "msgErrorNoSavePrjPrdHisNoPrj".OrderMessages();
					break;
				case 1:
					msg = "";
					break;
				}
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		finally
		{
			cRMSpIEntities.Dispose();
		}
	}

	public static bool CheckLastCompanyOrderHaveTax(int cmpId, ref bool haveOrd)
	{
		bool result = false;
		CRMSpIEntities cRMSpIEntities = new CRMSpIEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (cmpId != 0)
			{
				WSspCheckLastCompanyOrderHaveTax_Result wSspCheckLastCompanyOrderHaveTax_Result = Enumerable.FirstOrDefault<WSspCheckLastCompanyOrderHaveTax_Result>((IEnumerable<WSspCheckLastCompanyOrderHaveTax_Result>)cRMSpIEntities.WSspCheckLastCompanyOrderHaveTax(cmpId));
				decimal result3 = default(decimal);
				decimal result4 = default(decimal);
				if (wSspCheckLastCompanyOrderHaveTax_Result != null)
				{
					decimal.TryParse(wSspCheckLastCompanyOrderHaveTax_Result.ordTax.ToString(), out result3);
					decimal.TryParse(wSspCheckLastCompanyOrderHaveTax_Result.ordItemsTax.ToString(), out result4);
					haveOrd = true;
				}
				else
				{
					haveOrd = false;
				}
				if (result3 != 0m || result4 != 0m)
				{
					result = true;
				}
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		finally
		{
			cRMSpIEntities.Dispose();
		}
		return result;
	}

	public static bool IssueDraftAuto(int orderId, int userId, ref string refResult, int langId = 0, string formName = "frmOrder", string actionName = "actIssueDraftAuto", int userLastCId = 0)
	{
		bool result = false;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		int value = ((langId > 0) ? langId : result2);
		CRMSpEntities cRMSpEntities = null;
		try
		{
			string text = "";
			int num = 0;
			string text2 = "";
			if (UserLogin.CurrentUser != null && userLastCId == 0)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out userLastCId);
			}
			cRMSpEntities = new CRMSpEntities();
			if (VersionBuyer.WareHouse && UserLogin.IsUserAccessByUserId(formName, actionName, userId, userLastCId))
			{
				WSspSelectOrderById_Result wSspSelectOrderById_Result = Enumerable.FirstOrDefault<WSspSelectOrderById_Result>((IEnumerable<WSspSelectOrderById_Result>)cRMSpEntities.WSspSelectOrderById(orderId, value, result2));
				if (wSspSelectOrderById_Result != null)
				{
					int result3 = 0;
					int.TryParse(wSspSelectOrderById_Result.ordStatusId.ToString(), out result3);
					if (result3 == 4)
					{
						text = "msgErrorIssueDraftForCanceledOrd".OrderMessages();
						num++;
					}
					if (num == 0)
					{
						WSspReturnDraftFromOrder_Result wSspReturnDraftFromOrder_Result = new WSspReturnDraftFromOrder_Result();
						string text3 = "";
						List<WSspReturnDraftFromOrder_Result> list = Enumerable.ToList<WSspReturnDraftFromOrder_Result>((IEnumerable<WSspReturnDraftFromOrder_Result>)cRMSpEntities.WSspReturnDraftFromOrder(orderId, value, result2));
						if (list != null && Enumerable.Any<WSspReturnDraftFromOrder_Result>((IEnumerable<WSspReturnDraftFromOrder_Result>)list))
						{
							wSspReturnDraftFromOrder_Result = Enumerable.LastOrDefault<WSspReturnDraftFromOrder_Result>((IEnumerable<WSspReturnDraftFromOrder_Result>)list);
							if (list.Count > 0)
							{
								foreach (WSspReturnDraftFromOrder_Result item3 in list)
								{
									text3 = text3 + item3.DocNumber + ",";
								}
								if (!string.IsNullOrEmpty(text3) && text3.EndsWith(","))
								{
									text3 = text3.TrimEnd(new char[1] { ',' });
								}
								num++;
								string text4 = wSspReturnDraftFromOrder_Result.DocDateTime?.ToString("yyyy/MM/dd") ?? wSspReturnDraftFromOrder_Result.DocDate;
								string text5 = wSspReturnDraftFromOrder_Result.RegisterDate.ToString("yyyy/MM/dd") ?? wSspReturnDraftFromOrder_Result.RegisterDatePersian;
								text = string.Format(Messages.msgErrorVerifyOrderIssuedDoc, wSspSelectOrderById_Result.ordNumber, wSspReturnDraftFromOrder_Result.Opr, text3, text4, text5, wSspReturnDraftFromOrder_Result.UserName);
							}
						}
					}
					List<WSspSelectOrderItems_Result> list2 = Enumerable.ToList<WSspSelectOrderItems_Result>((IEnumerable<WSspSelectOrderItems_Result>)cRMSpEntities.WSspSelectOrderItems(orderId, value, result2));
					List<DocIdKeyValueViewModel> list3 = new List<DocIdKeyValueViewModel>();
					string text6 = "";
					int result4 = 0;
					if (list2 != null && Enumerable.Any<WSspSelectOrderItems_Result>((IEnumerable<WSspSelectOrderItems_Result>)list2))
					{
						WSspSelectOrderItems_Result wSspSelectOrderItems_Result = Enumerable.FirstOrDefault<WSspSelectOrderItems_Result>((IEnumerable<WSspSelectOrderItems_Result>)list2);
						if (wSspSelectOrderItems_Result != null)
						{
							int.TryParse(wSspSelectOrderItems_Result.ordIWHId.ToString(), out result4);
						}
						foreach (WSspSelectOrderItems_Result item4 in list2)
						{
							DocIdKeyValueViewModel item = new DocIdKeyValueViewModel
							{
								Id = item4.OrderItemID.ToString(),
								Value = item4.ordIQuantity.GetValueOrDefault().ToString()
							};
							list3.Add(item);
						}
						if (Enumerable.Any<DocIdKeyValueViewModel>((IEnumerable<DocIdKeyValueViewModel>)list3))
						{
							foreach (DocIdKeyValueViewModel item5 in list3)
							{
								string id = item5.Id;
								_ = item5.Type;
								_ = item5.Tag;
								string value2 = item5.Value;
								int result5 = 0;
								int.TryParse(id, out result5);
								double result6 = 0.0;
								double.TryParse(value2, out result6);
								if (result6 > 0.0)
								{
									text6 = text6 + result5 + "," + result6 + "|";
								}
							}
						}
					}
					if (num == 0)
					{
						if (UserLogin.IsUserAccessByUserId("frmIssueDraftFromOrder", "actCanNotIssueDraftWithNoStock", userId, userLastCId))
						{
							CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
							bool flag = false;
							int num2 = 0;
							bool flag2 = false;
							if (cRMspSelectCrmsysSetting_Result != null)
							{
								flag = ((cRMspSelectCrmsysSetting_Result.InvStockFromLink.HasValue && cRMspSelectCrmsysSetting_Result.InvStockFromLink.GetValueOrDefault()) ? true : false);
								num2 = cRMspSelectCrmsysSetting_Result.LinkAccSystemId.GetValueOrDefault();
							}
							if (flag && num2 > 0)
							{
								int num3 = 0;
								num3 = wSspSelectOrderById_Result.ordCompanyId;
								List<WSspSelectOrderItems_Result> list4 = new List<WSspSelectOrderItems_Result>();
								if (list2 != null && Enumerable.Any<WSspSelectOrderItems_Result>((IEnumerable<WSspSelectOrderItems_Result>)list2) && list3 != null && Enumerable.Any<DocIdKeyValueViewModel>((IEnumerable<DocIdKeyValueViewModel>)list3))
								{
									foreach (DocIdKeyValueViewModel item6 in list3)
									{
										string id2 = item6.Id;
										_ = item6.Type;
										_ = item6.Tag;
										string value3 = item6.Value;
										int objId = 0;
										int.TryParse(id2, out objId);
										double result7 = 0.0;
										double.TryParse(value3, out result7);
										WSspSelectOrderItems_Result linkAccitem = Enumerable.FirstOrDefault<WSspSelectOrderItems_Result>((IEnumerable<WSspSelectOrderItems_Result>)list2, (Func<WSspSelectOrderItems_Result, bool>)((WSspSelectOrderItems_Result m) => m.OrderItemID == objId));
										if (linkAccitem == null || result7 == 0.0)
										{
											continue;
										}
										bool flag3 = true;
										if (Enumerable.FirstOrDefault<WSspSelectOrderItems_Result>((IEnumerable<WSspSelectOrderItems_Result>)list4, (Func<WSspSelectOrderItems_Result, bool>)((WSspSelectOrderItems_Result m) => m.ordIPrdId == linkAccitem.ordIPrdId && m.ordIWHId == linkAccitem.ordIWHId && (m.ordILinkAccWHIdStr ?? "") == (linkAccitem.ordILinkAccWHIdStr ?? "") && (m.ordITracing ?? "") == (linkAccitem.ordITracing ?? "") && m.ordILinkAccSettingDBId.GetValueOrDefault() == linkAccitem.ordILinkAccSettingDBId.GetValueOrDefault())) != null)
										{
											flag3 = false;
											foreach (WSspSelectOrderItems_Result item7 in list4)
											{
												if (item7.ordIPrdId == linkAccitem.ordIPrdId && item7.ordIWHId == linkAccitem.ordIWHId && (item7.ordILinkAccWHIdStr ?? "") == (linkAccitem.ordILinkAccWHIdStr ?? "") && (item7.ordITracing ?? "") == (linkAccitem.ordITracing ?? "") && item7.ordILinkAccSettingDBId.GetValueOrDefault() == linkAccitem.ordILinkAccSettingDBId.GetValueOrDefault())
												{
													item7.ordIQuantity = item7.ordIQuantity.GetValueOrDefault() + result7;
												}
											}
										}
										if (flag3)
										{
											WSspSelectOrderItems_Result item2 = new WSspSelectOrderItems_Result
											{
												OrderItemID = linkAccitem.OrderItemID,
												ordIQuantity = result7,
												ordIPrice = linkAccitem.ordIPrice,
												ordIPrdPriceGroupID = linkAccitem.ordIPrdPriceGroupID,
												ordIPrdId = linkAccitem.ordIPrdId,
												ordIWHId = linkAccitem.ordIWHId,
												ordILinkAccWHIdStr = linkAccitem.ordILinkAccWHIdStr,
												ordITracing = linkAccitem.ordITracing,
												ordILinkAccSettingDBId = linkAccitem.ordILinkAccSettingDBId,
												ordIDescriptionI = linkAccitem.ordIDescriptionI,
												PrdName = linkAccitem.PrdName
											};
											list4.Add(item2);
										}
									}
								}
								if (list4 != null && Enumerable.Any<WSspSelectOrderItems_Result>((IEnumerable<WSspSelectOrderItems_Result>)list4))
								{
									foreach (WSspSelectOrderItems_Result item8 in list4)
									{
										if (item8 == null || num != 0)
										{
											continue;
										}
										double valueOrDefault = item8.ordIQuantity.GetValueOrDefault();
										string text7 = OtherSystems.GetPrdQuantity(userId, item8.ordIPrdId, item8.ordIWHId.GetValueOrDefault(), item8.ordILinkAccWHIdStr ?? "", item8.ordITracing ?? "", num3, item8.ordIDescriptionI ?? "", item8.ordILinkAccSettingDBId.GetValueOrDefault());
										double result8 = 0.0;
										if (string.IsNullOrEmpty(text7))
										{
											continue;
										}
										if (text7 == Labels.frmError)
										{
											text7 = "0";
										}
										if (text7 != Labels.frmError)
										{
											double.TryParse(text7, out result8);
											if (result8 < valueOrDefault)
											{
												flag2 = true;
												text = Messages.msgIssueDraftFormOrderImpossibilityIissued + "\r\n" + Messages.msgIssueDraftFormOrderLackInventory + "\r\n" + item8.PrdName;
												num++;
											}
											flag2 = true;
										}
									}
								}
							}
							if (!flag2)
							{
								WSspControlOrderItemsStock_Result wSspControlOrderItemsStock_Result = Enumerable.FirstOrDefault<WSspControlOrderItemsStock_Result>((IEnumerable<WSspControlOrderItemsStock_Result>)cRMSpEntities.WSspControlOrderItemsStock(orderId, value, result2, text6, userLastCId));
								if (wSspControlOrderItemsStock_Result != null)
								{
									text = Messages.msgIssueDraftFormOrderImpossibilityIissued + "\r\n" + Messages.msgIssueDraftFormOrderLackInventory + "\r\n" + wSspControlOrderItemsStock_Result.PrdName;
									num++;
								}
							}
						}
						if (UserLogin.IsUserAccessByUserId("frmIssueDraftFromOrder", "actCanNotIssueDraftWithNoStockFromSold", userId, userLastCId))
						{
							string ordItemJson = "";
							string ordItemListStr = "";
							if (!string.IsNullOrWhiteSpace(text6))
							{
								ordItemListStr = text6;
							}
							string text8 = "";
							text8 = ControlOrderItemsSoldStock(orderId, 1, "", ordItemJson, ordItemListStr, userId, userLastCId);
							if (!string.IsNullOrWhiteSpace(text8))
							{
								text = text8;
								num++;
							}
						}
					}
					if (num == 0)
					{
						DateTime now = DateTime.Now;
						string draftDate = now.ToString("yyyyMMdd", new PersianCulture());
						ObjectParameter objectParameter = new ObjectParameter("insertedDraftID", 0);
						ObjectParameter objectParameter2 = new ObjectParameter("insertedDraftNumber", 0);
						cRMSpEntities.WSspIssueDraftFromOrder(orderId, draftDate, userId, short.Parse(now.ToString("MM", new PersianCulture())), Financial.Get().Id, result4, now.ToString("yyyyMMdd", new PersianCulture()), Configuration.AppType, objectParameter, objectParameter2, result2, text6, (userLastCId != 0) ? new int?(userLastCId) : null);
						int num4 = (int)objectParameter.Value;
						int num5 = (int)objectParameter2.Value;
						WSspReturnDraftFromOrder_Result wSspReturnDraftFromOrder_Result2 = new WSspReturnDraftFromOrder_Result();
						List<WSspReturnDraftFromOrder_Result> list5 = Enumerable.ToList<WSspReturnDraftFromOrder_Result>((IEnumerable<WSspReturnDraftFromOrder_Result>)cRMSpEntities.WSspReturnDraftFromOrder(orderId, value, result2));
						string text9 = "";
						string text10 = "";
						if (list5 != null && Enumerable.Any<WSspReturnDraftFromOrder_Result>((IEnumerable<WSspReturnDraftFromOrder_Result>)list5))
						{
							wSspReturnDraftFromOrder_Result2 = Enumerable.LastOrDefault<WSspReturnDraftFromOrder_Result>((IEnumerable<WSspReturnDraftFromOrder_Result>)list5);
							if (list5.Count > 1)
							{
								foreach (WSspReturnDraftFromOrder_Result item9 in list5)
								{
									text9 = text9 + item9.DocNumber + ",";
									text10 = text10 + item9.DocID + ",";
								}
								if (!string.IsNullOrEmpty(text9) && text9.EndsWith(","))
								{
									text9 = text9.TrimEnd(new char[1] { ',' });
								}
								if (!string.IsNullOrEmpty(text10) && text10.EndsWith(","))
								{
									text10 = text10.TrimEnd(new char[1] { ',' });
								}
							}
						}
						else
						{
							wSspReturnDraftFromOrder_Result2 = null;
						}
						if (wSspReturnDraftFromOrder_Result2 != null)
						{
							if (string.IsNullOrEmpty(text9))
							{
								text9 = wSspReturnDraftFromOrder_Result2.DocNumber.ToString();
							}
							text2 = num4 + "," + text9 + "," + wSspReturnDraftFromOrder_Result2.OprType;
							if (UserLogin.IsUserAccessByUserId("frmIssueDraftFromOrder", "actAutoReferDocToOrdReferUserAfterIssue", userId, userLastCId))
							{
								Doc.ReferDocToOrdReferUser(text10, userId);
							}
						}
						else
						{
							text2 = num4 + "," + num5 + ",1";
						}
					}
				}
				else
				{
					text = Messages.ErrorNotFound;
				}
			}
			if (!string.IsNullOrWhiteSpace(text))
			{
				result = false;
				refResult = text;
			}
			else if (!string.IsNullOrWhiteSpace(text2))
			{
				result = true;
				refResult = text2;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public static bool UpdateOrderLinkAccConflictByPay(int ordId)
	{
		bool result = false;
		CRMSpIEntities cRMSpIEntities = new CRMSpIEntities();
		try
		{
			if (ordId != 0)
			{
				cRMSpIEntities.WSspUpdateOrderLinkAccConflictByPay(ordId);
				result = true;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpIEntities.Dispose();
		}
		return result;
	}

	public static string KaraAfzarGetSmsPanelUserName(int cmpId)
	{
		string result = "";
		CRMSpIEntities cRMSpIEntities = new CRMSpIEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			WSspSelectOrderItemsByCmpIdAndManufacturerName_Result wSspSelectOrderItemsByCmpIdAndManufacturerName_Result = Enumerable.FirstOrDefault<WSspSelectOrderItemsByCmpIdAndManufacturerName_Result>((IEnumerable<WSspSelectOrderItemsByCmpIdAndManufacturerName_Result>)cRMSpIEntities.WSspSelectOrderItemsByCmpIdAndManufacturerName(cmpId, "SMSMehrAfraz", lCID, result2, false, ""));
			if (wSspSelectOrderItemsByCmpIdAndManufacturerName_Result != null)
			{
				string text = wSspSelectOrderItemsByCmpIdAndManufacturerName_Result.ordIDescriptionI ?? "";
				if (!string.IsNullOrWhiteSpace(text))
				{
					string text2 = "";
					int num = text.IndexOf("UserName:", StringComparison.Ordinal);
					int num2 = text.IndexOf("\n", StringComparison.Ordinal) - num;
					if (num2 > 0)
					{
						text2 = text.Substring(num, num2);
					}
					text2 = text2.Replace("UserName:", "");
					if (!string.IsNullOrWhiteSpace(text2))
					{
						if (text2.StartsWith(" "))
						{
							text2 = text2.TrimStart(new char[1] { ' ' });
						}
						if (text2.EndsWith(" "))
						{
							text2 = text2.TrimEnd(new char[1] { ' ' });
						}
					}
					if (!string.IsNullOrWhiteSpace(text2))
					{
						result = text2;
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
			cRMSpIEntities.Dispose();
		}
		return result;
	}

	public static WSspSelectOrderItemsByPordIdAndManufacturerName_Result KaraAfzarGetChargeSmsOrdItem(int pordId)
	{
		WSspSelectOrderItemsByPordIdAndManufacturerName_Result result = new WSspSelectOrderItemsByPordIdAndManufacturerName_Result();
		CRMSpIEntities cRMSpIEntities = new CRMSpIEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			result = Enumerable.FirstOrDefault<WSspSelectOrderItemsByPordIdAndManufacturerName_Result>((IEnumerable<WSspSelectOrderItemsByPordIdAndManufacturerName_Result>)cRMSpIEntities.WSspSelectOrderItemsByPordIdAndManufacturerName(pordId, "SMSMehrAfrazCharge", lCID, result2, false, ""));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpIEntities.Dispose();
		}
		return result;
	}

	public static WSspSelectPreOrderItemsByPordIdAndManufacturerName_Result KaraAfzarGetChargeSmsPordItem(int pordId, string pordItemIds)
	{
		WSspSelectPreOrderItemsByPordIdAndManufacturerName_Result result = new WSspSelectPreOrderItemsByPordIdAndManufacturerName_Result();
		CRMSpIIEntities cRMSpIIEntities = new CRMSpIIEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			result = Enumerable.FirstOrDefault<WSspSelectPreOrderItemsByPordIdAndManufacturerName_Result>((IEnumerable<WSspSelectPreOrderItemsByPordIdAndManufacturerName_Result>)cRMSpIIEntities.WSspSelectPreOrderItemsByPordIdAndManufacturerName(pordId, "SMSMehrAfrazCharge", lCID, result2, false, "", pordItemIds));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpIIEntities.Dispose();
		}
		return result;
	}

	public static string KaraAfzarGetSmsPanelNumber(int cmpId)
	{
		string result = "";
		CRMSpIEntities cRMSpIEntities = new CRMSpIEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			WSspSelectOrderItemsByCmpIdAndManufacturerName_Result wSspSelectOrderItemsByCmpIdAndManufacturerName_Result = Enumerable.FirstOrDefault<WSspSelectOrderItemsByCmpIdAndManufacturerName_Result>((IEnumerable<WSspSelectOrderItemsByCmpIdAndManufacturerName_Result>)cRMSpIEntities.WSspSelectOrderItemsByCmpIdAndManufacturerName(cmpId, "SMSMehrAfraz", lCID, result2, false, ""));
			if (wSspSelectOrderItemsByCmpIdAndManufacturerName_Result != null)
			{
				string text = wSspSelectOrderItemsByCmpIdAndManufacturerName_Result.ordIDescriptionI ?? "";
				if (!string.IsNullOrWhiteSpace(text))
				{
					string text2 = "";
					string[] array = text.Split(new string[1] { "\n" }, StringSplitOptions.None);
					if (array != null && array.Length >= 3)
					{
						text2 = array[2];
					}
					text2 = text2.Replace("Num:", "");
					if (!string.IsNullOrWhiteSpace(text2))
					{
						text2 = text2.Replace("\r", "");
						if (text2.StartsWith(" "))
						{
							text2 = text2.TrimStart(new char[1] { ' ' });
						}
						if (text2.EndsWith(" "))
						{
							text2 = text2.TrimEnd(new char[1] { ' ' });
						}
					}
					if (!string.IsNullOrWhiteSpace(text2))
					{
						result = text2;
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
			cRMSpIEntities.Dispose();
		}
		return result;
	}

	public static bool KaraAfzarCreateUsernameAndPasswordForSmsOrdItem(int pordId, ref string newSmsUserName)
	{
		bool result = false;
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		CRMSpIEntities cRMSpIEntities = new CRMSpIEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			WSspSelectOrderItemsByPordIdAndManufacturerName_Result wSspSelectOrderItemsByPordIdAndManufacturerName_Result = Enumerable.FirstOrDefault<WSspSelectOrderItemsByPordIdAndManufacturerName_Result>((IEnumerable<WSspSelectOrderItemsByPordIdAndManufacturerName_Result>)cRMSpIEntities.WSspSelectOrderItemsByPordIdAndManufacturerName(pordId, "SMSMehrAfraz", lCID, result2, false, ""));
			if (wSspSelectOrderItemsByPordIdAndManufacturerName_Result != null && string.IsNullOrWhiteSpace(wSspSelectOrderItemsByPordIdAndManufacturerName_Result.ordIDescriptionI))
			{
				int valueOrDefault = wSspSelectOrderItemsByPordIdAndManufacturerName_Result.cmpNumber.GetValueOrDefault();
				string text = wSspSelectOrderItemsByPordIdAndManufacturerName_Result.cmpUserName ?? "";
				if (!string.IsNullOrWhiteSpace(text))
				{
					if (text.StartsWith(" "))
					{
						text = text.TrimStart(new char[1] { ' ' });
					}
					if (text.EndsWith(" "))
					{
						text = text.TrimEnd(new char[1] { ' ' });
					}
				}
				if (valueOrDefault > 0 && !string.IsNullOrWhiteSpace(text))
				{
					string text2 = valueOrDefault.ToString();
					string text3 = "SMSideal" + text + "921@3";
					string value = "UserName:" + text2 + "\nPass:" + text3 + "\nNum:\n";
					newSmsUserName = text2;
					string ordiDescriptionIJson = "";
					List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
					foreach (Languages item in Enumerable.ToList<Languages>((IEnumerable<Languages>)Language.Get()))
					{
						CommonMultiLanguageViewModel commonMultiLanguageViewModel = new CommonMultiLanguageViewModel();
						commonMultiLanguageViewModel.LanguageId = item.LanguageID;
						commonMultiLanguageViewModel.Value = value;
						list.Add(commonMultiLanguageViewModel);
					}
					if (list != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list))
					{
						ordiDescriptionIJson = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list));
					}
					DateTime now = DateTime.Now;
					DateTime value2 = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					DateTimeClass.DefineDayeOfWeekStartWith7(now.DayOfWeek.ToString());
					now.ToString("HH:mm:ss");
					short value3 = short.Parse(now.ToString("MM", new PersianCulture()));
					string appType = Configuration.AppType;
					_ = Financial.Get().Id;
					short.Parse(now.ToString("yyyy", new PersianCulture()));
					int userId = UserLogin.CurrentUser.UserId;
					cRMSpIEntities.WSspUpdateOrderItemDescriptionI(wSspSelectOrderItemsByPordIdAndManufacturerName_Result.OrderItemID, ordiDescriptionIJson, appType, value3, userId, value2, registerDatePersian, result2);
					result = true;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities.Dispose();
			cRMSpIEntities.Dispose();
		}
		return result;
	}

	public static string KaraAfzarCreateUsernameAndPasswordForSmsOrdItemByCmp(int cmpId, ref string newSmsUserName)
	{
		string result = "";
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		CRMSpIEntities cRMSpIEntities = new CRMSpIEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			WSspSelectOrderItemsByCmpIdAndManufacturerName_Result wSspSelectOrderItemsByCmpIdAndManufacturerName_Result = Enumerable.FirstOrDefault<WSspSelectOrderItemsByCmpIdAndManufacturerName_Result>((IEnumerable<WSspSelectOrderItemsByCmpIdAndManufacturerName_Result>)cRMSpIEntities.WSspSelectOrderItemsByCmpIdAndManufacturerName(cmpId, "SMSMehrAfraz", lCID, result2, false, ""));
			if (wSspSelectOrderItemsByCmpIdAndManufacturerName_Result != null)
			{
				if (string.IsNullOrWhiteSpace(wSspSelectOrderItemsByCmpIdAndManufacturerName_Result.ordIDescriptionI))
				{
					int valueOrDefault = wSspSelectOrderItemsByCmpIdAndManufacturerName_Result.cmpNumber.GetValueOrDefault();
					string text = wSspSelectOrderItemsByCmpIdAndManufacturerName_Result.cmpUserName ?? "";
					if (!string.IsNullOrWhiteSpace(text))
					{
						if (text.StartsWith(" "))
						{
							text = text.TrimStart(new char[1] { ' ' });
						}
						if (text.EndsWith(" "))
						{
							text = text.TrimEnd(new char[1] { ' ' });
						}
					}
					if (valueOrDefault > 0 && !string.IsNullOrWhiteSpace(text))
					{
						string text2 = valueOrDefault.ToString();
						string text3 = "SMSideal" + text + "921@3";
						string value = "UserName:" + text2 + "\nPass:" + text3 + "\nNum:\n";
						newSmsUserName = text2;
						string ordiDescriptionIJson = "";
						List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
						foreach (Languages item in Enumerable.ToList<Languages>((IEnumerable<Languages>)Language.Get()))
						{
							CommonMultiLanguageViewModel commonMultiLanguageViewModel = new CommonMultiLanguageViewModel();
							commonMultiLanguageViewModel.LanguageId = item.LanguageID;
							commonMultiLanguageViewModel.Value = value;
							list.Add(commonMultiLanguageViewModel);
						}
						if (list != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list))
						{
							ordiDescriptionIJson = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list));
						}
						DateTime now = DateTime.Now;
						DateTime value2 = now;
						string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						DateTimeClass.DefineDayeOfWeekStartWith7(now.DayOfWeek.ToString());
						now.ToString("HH:mm:ss");
						short value3 = short.Parse(now.ToString("MM", new PersianCulture()));
						string appType = Configuration.AppType;
						_ = Financial.Get().Id;
						short.Parse(now.ToString("yyyy", new PersianCulture()));
						int userId = UserLogin.CurrentUser.UserId;
						cRMSpIEntities.WSspUpdateOrderItemDescriptionI(wSspSelectOrderItemsByCmpIdAndManufacturerName_Result.OrderItemID, ordiDescriptionIJson, appType, value3, userId, value2, registerDatePersian, result2);
						result = "";
					}
				}
				else
				{
					string text4 = KaraAfzarGetSmsPanelUserName(cmpId);
					if (!string.IsNullOrWhiteSpace(text4))
					{
						result = string.Format(Messages.msgErrorAlreadyCreatedsmsPanelbyUsername, text4);
					}
				}
			}
			else
			{
				result = Messages.msgNotFound;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = ex.Message;
		}
		finally
		{
			cRMSpEntities.Dispose();
			cRMSpIEntities.Dispose();
		}
		return result;
	}

	public static bool KaraAfzarCreateDomainandUrlForMob(int pordId)
	{
		bool result = false;
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		CRMSpIEntities cRMSpIEntities = new CRMSpIEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<WSspSelectOrderItemsByPordIdAndManufacturerName_Result> list = Enumerable.ToList<WSspSelectOrderItemsByPordIdAndManufacturerName_Result>((IEnumerable<WSspSelectOrderItemsByPordIdAndManufacturerName_Result>)cRMSpIEntities.WSspSelectOrderItemsByPordIdAndManufacturerName(pordId, "mobCRM:%;mobHRM:%;mobCIC:%;mobFo:%;mobParsServiceSupport:%;mobocsan:%;mobhamgam:%;mobkenaretam:%;mobCRMShop:%", lCID, result2, true, ";"));
			if (list != null && Enumerable.Any<WSspSelectOrderItemsByPordIdAndManufacturerName_Result>((IEnumerable<WSspSelectOrderItemsByPordIdAndManufacturerName_Result>)list))
			{
				foreach (WSspSelectOrderItemsByPordIdAndManufacturerName_Result item in list)
				{
					string text = "";
					int? cmpNumber = item.cmpNumber;
					if (!string.IsNullOrWhiteSpace(item.ordIDescriptionI) || !cmpNumber.HasValue)
					{
						continue;
					}
					string text2 = item.PrdManufacturerName ?? "";
					string text3 = item.PrdManufacturerCode ?? "";
					if (string.IsNullOrWhiteSpace(text2) || string.IsNullOrWhiteSpace(text3))
					{
						continue;
					}
					bool android = false;
					bool ios = false;
					bool pwa = false;
					string[] array = text3.Split(new char[1] { ';' });
					if (array != null && array.Length != 0)
					{
						string[] array2 = array;
						foreach (string text4 in array2)
						{
							if (string.IsNullOrWhiteSpace(text4))
							{
								continue;
							}
							string[] array3 = text4.Split(new char[1] { ':' });
							if (array3 == null || array3.Length < 2)
							{
								continue;
							}
							if (!string.IsNullOrWhiteSpace(array3[0]))
							{
								if (array3[0].StartsWith(" "))
								{
									array3[0] = array3[0].TrimStart(new char[1] { ' ' });
								}
								if (array3[0].EndsWith(" "))
								{
									array3[0] = array3[0].TrimEnd(new char[1] { ' ' });
								}
							}
							if (!string.IsNullOrWhiteSpace(array3[1]))
							{
								if (array3[1].StartsWith(" "))
								{
									array3[1] = array3[1].TrimStart(new char[1] { ' ' });
								}
								if (array3[1].EndsWith(" "))
								{
									array3[1] = array3[1].TrimEnd(new char[1] { ' ' });
								}
							}
							string text5 = array3[0];
							int result3 = 0;
							int.TryParse(array3[1], out result3);
							if (result3 == 1 && !string.IsNullOrWhiteSpace(text5))
							{
								switch (text5.ToLower())
								{
								case "and":
									android = true;
									break;
								case "ios":
									ios = true;
									break;
								case "pwa":
									pwa = true;
									break;
								}
							}
						}
					}
					string[] array4 = text2.Split(new char[1] { ';' });
					if (array4 != null && array4.Length != 0)
					{
						string[] array2 = array4;
						foreach (string text6 in array2)
						{
							if (string.IsNullOrWhiteSpace(text6))
							{
								continue;
							}
							string[] array5 = text6.Split(new char[1] { ':' });
							if (array5 == null || array5.Length < 2)
							{
								continue;
							}
							if (!string.IsNullOrWhiteSpace(array5[0]))
							{
								if (array5[0].StartsWith(" "))
								{
									array5[0] = array5[0].TrimStart(new char[1] { ' ' });
								}
								if (array5[0].EndsWith(" "))
								{
									array5[0] = array5[0].TrimEnd(new char[1] { ' ' });
								}
							}
							if (!string.IsNullOrWhiteSpace(array5[1]))
							{
								if (array5[1].StartsWith(" "))
								{
									array5[1] = array5[1].TrimStart(new char[1] { ' ' });
								}
								if (array5[1].EndsWith(" "))
								{
									array5[1] = array5[1].TrimEnd(new char[1] { ' ' });
								}
							}
							string text7 = array5[0];
							int result4 = 0;
							int.TryParse(array5[1], out result4);
							if (result4 != 1 || string.IsNullOrWhiteSpace(text7))
							{
								continue;
							}
							string text8 = "";
							switch (text7.ToLower())
							{
							case "mobcrm":
								text8 = "";
								text8 = KaraafzarCreateDomainForMob(cmpNumber.GetValueOrDefault(), "mobCRM", "", "", android, ios, pwa);
								if (!string.IsNullOrWhiteSpace(text8))
								{
									if (!string.IsNullOrWhiteSpace(text))
									{
										text += ",";
									}
									text += text8;
								}
								break;
							case "mobhrm":
								text8 = "";
								text8 = KaraafzarCreateDomainForMob(cmpNumber.GetValueOrDefault(), "mobHRM", "", "hrm", android, ios, pwa);
								if (!string.IsNullOrWhiteSpace(text8))
								{
									if (!string.IsNullOrWhiteSpace(text))
									{
										text += ",";
									}
									text += text8;
								}
								break;
							case "mobcic":
								text8 = "";
								text8 = KaraafzarCreateDomainForMob(cmpNumber.GetValueOrDefault(), "mobCIC", "", "cic", android, ios, pwa);
								if (!string.IsNullOrWhiteSpace(text8))
								{
									if (!string.IsNullOrWhiteSpace(text))
									{
										text += ",";
									}
									text += text8;
								}
								break;
							case "mobfo":
								text8 = "";
								text8 = KaraafzarCreateDomainForMob(cmpNumber.GetValueOrDefault(), "mobFo", "", "fo", android, ios, pwa);
								if (!string.IsNullOrWhiteSpace(text8))
								{
									if (!string.IsNullOrWhiteSpace(text))
									{
										text += ",";
									}
									text += text8;
								}
								break;
							case "mobparsservicesupport":
								text8 = "";
								text8 = KaraafzarCreateDomainForMob(cmpNumber.GetValueOrDefault(), "mobParsServiceSupport", "", "pss", android, ios, pwa);
								if (!string.IsNullOrWhiteSpace(text8))
								{
									if (!string.IsNullOrWhiteSpace(text))
									{
										text += ",";
									}
									text += text8;
								}
								break;
							case "mobocsan":
								text8 = "";
								text8 = KaraafzarCreateDomainForMob(cmpNumber.GetValueOrDefault(), "mobocsan", "", "ocsan", android, ios, pwa);
								if (!string.IsNullOrWhiteSpace(text8))
								{
									if (!string.IsNullOrWhiteSpace(text))
									{
										text += ",";
									}
									text += text8;
								}
								break;
							case "mobhamgam":
								text8 = "";
								text8 = KaraafzarCreateDomainForMob(cmpNumber.GetValueOrDefault(), "mobhamgam", "", "hamgam", android, ios, pwa);
								if (!string.IsNullOrWhiteSpace(text8))
								{
									if (!string.IsNullOrWhiteSpace(text))
									{
										text += ",";
									}
									text += text8;
								}
								break;
							case "mobkenaretam":
								text8 = "";
								text8 = KaraafzarCreateDomainForMob(cmpNumber.GetValueOrDefault(), "mobkenaretam", "", "kenar", android, ios, pwa);
								if (!string.IsNullOrWhiteSpace(text8))
								{
									if (!string.IsNullOrWhiteSpace(text))
									{
										text += ",";
									}
									text += text8;
								}
								break;
							case "mobcrmshop":
								text8 = "";
								text8 = KaraafzarCreateDomainForMob(cmpNumber.GetValueOrDefault(), "mobCRMShop", "", "crmshop", android, ios, pwa);
								if (!string.IsNullOrWhiteSpace(text8))
								{
									if (!string.IsNullOrWhiteSpace(text))
									{
										text += ",";
									}
									text += text8;
								}
								break;
							}
						}
					}
					if (string.IsNullOrWhiteSpace(text))
					{
						continue;
					}
					text = "[{" + text + "}]";
					string ordiDescriptionIJson = "";
					List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
					foreach (Languages item2 in Enumerable.ToList<Languages>((IEnumerable<Languages>)Language.Get()))
					{
						CommonMultiLanguageViewModel commonMultiLanguageViewModel = new CommonMultiLanguageViewModel();
						commonMultiLanguageViewModel.LanguageId = item2.LanguageID;
						commonMultiLanguageViewModel.Value = text;
						list2.Add(commonMultiLanguageViewModel);
					}
					if (list2 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2))
					{
						ordiDescriptionIJson = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2));
					}
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					DateTimeClass.DefineDayeOfWeekStartWith7(now.DayOfWeek.ToString());
					now.ToString("HH:mm:ss");
					short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
					string appType = Configuration.AppType;
					_ = Financial.Get().Id;
					short.Parse(now.ToString("yyyy", new PersianCulture()));
					int userId = UserLogin.CurrentUser.UserId;
					cRMSpIEntities.WSspUpdateOrderItemDescriptionI(item.OrderItemID, ordiDescriptionIJson, appType, value2, userId, value, registerDatePersian, result2);
					result = true;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities.Dispose();
			cRMSpIEntities.Dispose();
		}
		return result;
	}

	public static string KaraAfzarCreateDomainandUrlForMobByCmp(int cmpId)
	{
		string text = "";
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		CRMSpIEntities cRMSpIEntities = new CRMSpIEntities();
		string text7;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<WSspSelectOrderItemsByCmpIdAndManufacturerName_Result> list = Enumerable.ToList<WSspSelectOrderItemsByCmpIdAndManufacturerName_Result>((IEnumerable<WSspSelectOrderItemsByCmpIdAndManufacturerName_Result>)cRMSpIEntities.WSspSelectOrderItemsByCmpIdAndManufacturerName(cmpId, "mobCRM:%;mobHRM:%;mobCIC:%;mobFo:%;mobParsServiceSupport:%;mobocsan:%;mobhamgam:%;mobkenaretam:%;mobCRMShop:%", lCID, result, true, ";"));
			if (list != null)
			{
				if (Enumerable.Any<WSspSelectOrderItemsByCmpIdAndManufacturerName_Result>((IEnumerable<WSspSelectOrderItemsByCmpIdAndManufacturerName_Result>)list))
				{
					foreach (WSspSelectOrderItemsByCmpIdAndManufacturerName_Result item in list)
					{
						string text2 = "";
						int? cmpNumber = item.cmpNumber;
						if (!string.IsNullOrWhiteSpace(item.ordIDescriptionI) || !cmpNumber.HasValue)
						{
							continue;
						}
						string text3 = item.PrdManufacturerName ?? "";
						string text4 = item.PrdManufacturerCode ?? "";
						if (!string.IsNullOrWhiteSpace(text3) && !string.IsNullOrWhiteSpace(text4))
						{
							bool android = false;
							bool ios = false;
							bool pwa = false;
							string[] array = text4.Split(new char[1] { ';' });
							if (array != null && array.Length != 0)
							{
								string[] array2 = array;
								foreach (string text5 in array2)
								{
									if (string.IsNullOrWhiteSpace(text5))
									{
										continue;
									}
									string[] array3 = text5.Split(new char[1] { ':' });
									if (array3 == null || array3.Length < 2)
									{
										continue;
									}
									if (!string.IsNullOrWhiteSpace(array3[0]))
									{
										if (array3[0].StartsWith(" "))
										{
											array3[0] = array3[0].TrimStart(new char[1] { ' ' });
										}
										if (array3[0].EndsWith(" "))
										{
											array3[0] = array3[0].TrimEnd(new char[1] { ' ' });
										}
									}
									if (!string.IsNullOrWhiteSpace(array3[1]))
									{
										if (array3[1].StartsWith(" "))
										{
											array3[1] = array3[1].TrimStart(new char[1] { ' ' });
										}
										if (array3[1].EndsWith(" "))
										{
											array3[1] = array3[1].TrimEnd(new char[1] { ' ' });
										}
									}
									string text6 = array3[0];
									int result2 = 0;
									int.TryParse(array3[1], out result2);
									if (result2 == 1 && !string.IsNullOrWhiteSpace(text6))
									{
										text7 = text6.ToLower();
										switch (text7)
										{
										case "and":
											android = true;
											break;
										case "ios":
											ios = true;
											break;
										case "pwa":
											pwa = true;
											break;
										}
									}
								}
							}
							string[] array4 = text3.Split(new char[1] { ';' });
							if (array4 != null && array4.Length != 0)
							{
								string[] array2 = array4;
								foreach (string text8 in array2)
								{
									if (string.IsNullOrWhiteSpace(text8))
									{
										continue;
									}
									string[] array5 = text8.Split(new char[1] { ':' });
									if (array5 == null || array5.Length < 2)
									{
										continue;
									}
									if (!string.IsNullOrWhiteSpace(array5[0]))
									{
										if (array5[0].StartsWith(" "))
										{
											array5[0] = array5[0].TrimStart(new char[1] { ' ' });
										}
										if (array5[0].EndsWith(" "))
										{
											array5[0] = array5[0].TrimEnd(new char[1] { ' ' });
										}
									}
									if (!string.IsNullOrWhiteSpace(array5[1]))
									{
										if (array5[1].StartsWith(" "))
										{
											array5[1] = array5[1].TrimStart(new char[1] { ' ' });
										}
										if (array5[1].EndsWith(" "))
										{
											array5[1] = array5[1].TrimEnd(new char[1] { ' ' });
										}
									}
									string text9 = array5[0];
									int result3 = 0;
									int.TryParse(array5[1], out result3);
									if (result3 != 1 || string.IsNullOrWhiteSpace(text9))
									{
										continue;
									}
									string text10 = "";
									text7 = text9.ToLower();
									switch (text7)
									{
									case "mobcrm":
										text10 = "";
										text10 = KaraafzarCreateDomainForMob(cmpNumber.GetValueOrDefault(), "mobCRM", "", "", android, ios, pwa);
										if (!string.IsNullOrWhiteSpace(text10))
										{
											if (!string.IsNullOrWhiteSpace(text2))
											{
												text2 += ",";
											}
											text2 += text10;
										}
										break;
									case "mobhrm":
										text10 = "";
										text10 = KaraafzarCreateDomainForMob(cmpNumber.GetValueOrDefault(), "mobHRM", "", "hrm", android, ios, pwa);
										if (!string.IsNullOrWhiteSpace(text10))
										{
											if (!string.IsNullOrWhiteSpace(text2))
											{
												text2 += ",";
											}
											text2 += text10;
										}
										break;
									case "mobcic":
										text10 = "";
										text10 = KaraafzarCreateDomainForMob(cmpNumber.GetValueOrDefault(), "mobCIC", "", "cic", android, ios, pwa);
										if (!string.IsNullOrWhiteSpace(text10))
										{
											if (!string.IsNullOrWhiteSpace(text2))
											{
												text2 += ",";
											}
											text2 += text10;
										}
										break;
									case "mobfo":
										text10 = "";
										text10 = KaraafzarCreateDomainForMob(cmpNumber.GetValueOrDefault(), "mobFo", "", "fo", android, ios, pwa);
										if (!string.IsNullOrWhiteSpace(text10))
										{
											if (!string.IsNullOrWhiteSpace(text2))
											{
												text2 += ",";
											}
											text2 += text10;
										}
										break;
									case "mobparsservicesupport":
										text10 = "";
										text10 = KaraafzarCreateDomainForMob(cmpNumber.GetValueOrDefault(), "mobParsServiceSupport", "", "pss", android, ios, pwa);
										if (!string.IsNullOrWhiteSpace(text10))
										{
											if (!string.IsNullOrWhiteSpace(text2))
											{
												text2 += ",";
											}
											text2 += text10;
										}
										break;
									case "mobocsan":
										text10 = "";
										text10 = KaraafzarCreateDomainForMob(cmpNumber.GetValueOrDefault(), "mobocsan", "", "ocsan", android, ios, pwa);
										if (!string.IsNullOrWhiteSpace(text10))
										{
											if (!string.IsNullOrWhiteSpace(text2))
											{
												text2 += ",";
											}
											text2 += text10;
										}
										break;
									case "mobhamgam":
										text10 = "";
										text10 = KaraafzarCreateDomainForMob(cmpNumber.GetValueOrDefault(), "mobhamgam", "", "hamgam", android, ios, pwa);
										if (!string.IsNullOrWhiteSpace(text10))
										{
											if (!string.IsNullOrWhiteSpace(text2))
											{
												text2 += ",";
											}
											text2 += text10;
										}
										break;
									case "mobkenaretam":
										text10 = "";
										text10 = KaraafzarCreateDomainForMob(cmpNumber.GetValueOrDefault(), "mobkenaretam", "", "kenar", android, ios, pwa);
										if (!string.IsNullOrWhiteSpace(text10))
										{
											if (!string.IsNullOrWhiteSpace(text2))
											{
												text2 += ",";
											}
											text2 += text10;
										}
										break;
									case "mobcrmshop":
										text10 = "";
										text10 = KaraafzarCreateDomainForMob(cmpNumber.GetValueOrDefault(), "mobCRMShop", "", "crmshop", android, ios, pwa);
										if (!string.IsNullOrWhiteSpace(text10))
										{
											if (!string.IsNullOrWhiteSpace(text2))
											{
												text2 += ",";
											}
											text2 += text10;
										}
										break;
									}
								}
							}
							if (!string.IsNullOrWhiteSpace(text2))
							{
								text2 = "[{" + text2 + "}]";
								string ordiDescriptionIJson = "";
								List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
								foreach (Languages item2 in Enumerable.ToList<Languages>((IEnumerable<Languages>)Language.Get()))
								{
									CommonMultiLanguageViewModel commonMultiLanguageViewModel = new CommonMultiLanguageViewModel();
									commonMultiLanguageViewModel.LanguageId = item2.LanguageID;
									commonMultiLanguageViewModel.Value = text2;
									list2.Add(commonMultiLanguageViewModel);
								}
								if (list2 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2))
								{
									ordiDescriptionIJson = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2));
								}
								DateTime now = DateTime.Now;
								DateTime value = now;
								string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
								DateTimeClass.DefineDayeOfWeekStartWith7(now.DayOfWeek.ToString());
								now.ToString("HH:mm:ss");
								short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
								string appType = Configuration.AppType;
								_ = Financial.Get().Id;
								short.Parse(now.ToString("yyyy", new PersianCulture()));
								int userId = UserLogin.CurrentUser.UserId;
								cRMSpIEntities.WSspUpdateOrderItemDescriptionI(item.OrderItemID, ordiDescriptionIJson, appType, value2, userId, value, registerDatePersian, result);
								text = "";
								continue;
							}
							text = string.Format(Messages.msgErrorCreateMobDomainForPrd, item.PrdName ?? "");
							text7 = text;
						}
						else
						{
							text = string.Format(Messages.msgErrorNotDefineNameOrCodePrdManufacture, item.PrdName ?? "");
							text7 = text;
						}
						goto IL_0a72;
					}
				}
				else
				{
					text = Messages.msgErrorNotFoundProductToCreateMobDomain;
				}
			}
			else
			{
				text = Messages.msgErrorNotFoundProductToCreateMobDomain;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			text = ex.Message;
		}
		finally
		{
			cRMSpEntities.Dispose();
			cRMSpIEntities.Dispose();
		}
		return text;
		IL_0a72:
		return text7;
	}

	public static string KaraafzarCreateDomainForMob(int cmpNumber, string appName, string prefixDomain, string suffixDomain, bool android, bool ios, bool pwa)
	{
		string result = "";
		try
		{
			string text = "";
			if (android)
			{
				if (!string.IsNullOrWhiteSpace(text))
				{
					text += ",";
				}
				text = text + "\"DomainAnd\":\"" + cmpNumber + suffixDomain + "\",";
				text += "\"URLAnd\": \"\"";
			}
			if (ios)
			{
				if (!string.IsNullOrWhiteSpace(text))
				{
					text += ",";
				}
				text = text + "\"DomainIos\":\"" + cmpNumber + suffixDomain + "ios\",";
				text += "\"URLIos\": \"\"";
			}
			if (pwa)
			{
				if (!string.IsNullOrWhiteSpace(text))
				{
					text += ",";
				}
				text = text + "\"DomainPWA\":\"" + cmpNumber + suffixDomain + "pwa\",";
				text += "\"URLPWA\":\"\",";
				text += "\"CrossOrgURLPWA\":\"\"";
			}
			if (!string.IsNullOrWhiteSpace(text))
			{
				text = "\"" + appName + "\":{" + text + "}";
			}
			if (!string.IsNullOrWhiteSpace(text))
			{
				result = text;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public static string KaraAfzarUpdateDomainandUrlForMobByCmp(int cmpId)
	{
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		string text = "";
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		CRMSpIEntities cRMSpIEntities = new CRMSpIEntities();
		string text7;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<WSspSelectOrderItemsByCmpIdAndManufacturerName_Result> list = Enumerable.ToList<WSspSelectOrderItemsByCmpIdAndManufacturerName_Result>((IEnumerable<WSspSelectOrderItemsByCmpIdAndManufacturerName_Result>)cRMSpIEntities.WSspSelectOrderItemsByCmpIdAndManufacturerName(cmpId, "mobCRM:%;mobHRM:%;mobCIC:%;mobFo:%;mobParsServiceSupport:%;mobocsan:%;mobhamgam:%;mobkenaretam:%;mobCRMShop:%", lCID, result, true, ";"));
			if (list != null)
			{
				if (Enumerable.Any<WSspSelectOrderItemsByCmpIdAndManufacturerName_Result>((IEnumerable<WSspSelectOrderItemsByCmpIdAndManufacturerName_Result>)list))
				{
					foreach (WSspSelectOrderItemsByCmpIdAndManufacturerName_Result item in list)
					{
						string text2 = "";
						int? cmpNumber = item.cmpNumber;
						KaraAfzarMobDomainViewModel karaAfzarMobDomainViewModel = new KaraAfzarMobDomainViewModel();
						if (!string.IsNullOrWhiteSpace(item.ordIDescriptionI))
						{
							List<KaraAfzarMobDomainViewModel> list2 = new JavaScriptSerializer().Deserialize<List<KaraAfzarMobDomainViewModel>>(item.ordIDescriptionI);
							if (list2 != null && Enumerable.Any<KaraAfzarMobDomainViewModel>((IEnumerable<KaraAfzarMobDomainViewModel>)list2))
							{
								karaAfzarMobDomainViewModel = Enumerable.FirstOrDefault<KaraAfzarMobDomainViewModel>((IEnumerable<KaraAfzarMobDomainViewModel>)list2);
								if (karaAfzarMobDomainViewModel != null)
								{
									string text3 = "mobCRM:0;mobHRM:0;mobCIC:0;mobFo:0;mobParsServiceSupport:0;mobocsan:0;mobhamgam:0;mobkenaretam:0;mobCRMShop:0";
									string text4 = item.PrdManufacturerName ?? "";
									if (!string.IsNullOrWhiteSpace(text4))
									{
										string[] array = text4.Split(new char[1] { ';' });
										if (array != null && array.Length != 0)
										{
											string[] array2 = array;
											foreach (string text5 in array2)
											{
												if (string.IsNullOrWhiteSpace(text5))
												{
													continue;
												}
												string[] array3 = text5.Split(new char[1] { ':' });
												if (array3 == null || array3.Length < 2)
												{
													continue;
												}
												if (!string.IsNullOrWhiteSpace(array3[0]))
												{
													if (array3[0].StartsWith(" "))
													{
														array3[0] = array3[0].TrimStart(new char[1] { ' ' });
													}
													if (array3[0].EndsWith(" "))
													{
														array3[0] = array3[0].TrimEnd(new char[1] { ' ' });
													}
												}
												if (!string.IsNullOrWhiteSpace(array3[1]))
												{
													if (array3[1].StartsWith(" "))
													{
														array3[1] = array3[1].TrimStart(new char[1] { ' ' });
													}
													if (array3[1].EndsWith(" "))
													{
														array3[1] = array3[1].TrimEnd(new char[1] { ' ' });
													}
												}
												string text6 = array3[0];
												int result2 = 0;
												int.TryParse(array3[1], out result2);
												if (result2 == 1 && !string.IsNullOrWhiteSpace(text6))
												{
													text7 = text6.ToLower();
													switch (text7)
													{
													case "mobcrm":
														text3 = text3.Replace("mobCRM:0", "mobCRM:1");
														break;
													case "mobhrm":
														text3 = text3.Replace("mobHRM:0", "mobHRM:1");
														break;
													case "mobcic":
														text3 = text3.Replace("mobCIC:0", "mobCIC:1");
														break;
													case "mobfo":
														text3 = text3.Replace("mobFo:0", "mobFo:1");
														break;
													case "mobparsservicesupport":
														text3 = text3.Replace("mobParsServiceSupport:0", "mobParsServiceSupport:1");
														break;
													case "mobocsan":
														text3 = text3.Replace("mobocsan:0", "mobocsan:1");
														break;
													case "mobhamgam":
														text3 = text3.Replace("mobhamgam:0", "mobhamgam:1");
														break;
													case "mobkenaretam":
														text3 = text3.Replace("mobkenaretam:0", "mobkenaretam:1");
														break;
													case "mobcrmshop":
														text3 = text3.Replace("mobCRMShop:0", "mobCRMShop:1");
														break;
													}
												}
											}
										}
									}
									if (karaAfzarMobDomainViewModel.mobCRM != null)
									{
										text3 = text3.Replace("mobCRM:0", "mobCRM:1");
									}
									if (karaAfzarMobDomainViewModel.mobHRM != null)
									{
										text3 = text3.Replace("mobHRM:0", "mobHRM:1");
									}
									if (karaAfzarMobDomainViewModel.mobCIC != null)
									{
										text3 = text3.Replace("mobCIC:0", "mobCIC:1");
									}
									if (karaAfzarMobDomainViewModel.mobFo != null)
									{
										text3 = text3.Replace("mobFo:0", "mobFo:1");
									}
									if (karaAfzarMobDomainViewModel.mobParsServiceSupport != null)
									{
										text3 = text3.Replace("mobParsServiceSupport:0", "mobParsServiceSupport:1");
									}
									if (karaAfzarMobDomainViewModel.mobocsan != null)
									{
										text3 = text3.Replace("mobocsan:0", "mobocsan:1");
									}
									if (karaAfzarMobDomainViewModel.mobhamgam != null)
									{
										text3 = text3.Replace("mobhamgam:0", "mobhamgam:1");
									}
									if (karaAfzarMobDomainViewModel.mobkenaretam != null)
									{
										text3 = text3.Replace("mobkenaretam:0", "mobkenaretam:1");
									}
									if (karaAfzarMobDomainViewModel.mobCRMShop != null)
									{
										text3 = text3.Replace("mobCRMShop:0", "mobCRMShop:1");
									}
									if (text3 != "mobCRM:0;mobHRM:0;mobCIC:0;mobFo:0;mobParsServiceSupport:0;mobocsan:0;mobhamgam:0;mobkenaretam:0;mobCRMShop:0")
									{
										item.PrdManufacturerName = text3;
									}
								}
							}
						}
						if (!cmpNumber.HasValue)
						{
							continue;
						}
						string text8 = item.PrdManufacturerName ?? "";
						string text9 = item.PrdManufacturerCode ?? "";
						if (!string.IsNullOrWhiteSpace(text8) && !string.IsNullOrWhiteSpace(text9))
						{
							bool android = false;
							bool ios = false;
							bool pwa = false;
							string[] array4 = text9.Split(new char[1] { ';' });
							if (array4 != null && array4.Length != 0)
							{
								string[] array2 = array4;
								foreach (string text10 in array2)
								{
									if (string.IsNullOrWhiteSpace(text10))
									{
										continue;
									}
									string[] array5 = text10.Split(new char[1] { ':' });
									if (array5 == null || array5.Length < 2)
									{
										continue;
									}
									if (!string.IsNullOrWhiteSpace(array5[0]))
									{
										if (array5[0].StartsWith(" "))
										{
											array5[0] = array5[0].TrimStart(new char[1] { ' ' });
										}
										if (array5[0].EndsWith(" "))
										{
											array5[0] = array5[0].TrimEnd(new char[1] { ' ' });
										}
									}
									if (!string.IsNullOrWhiteSpace(array5[1]))
									{
										if (array5[1].StartsWith(" "))
										{
											array5[1] = array5[1].TrimStart(new char[1] { ' ' });
										}
										if (array5[1].EndsWith(" "))
										{
											array5[1] = array5[1].TrimEnd(new char[1] { ' ' });
										}
									}
									string text11 = array5[0];
									int result3 = 0;
									int.TryParse(array5[1], out result3);
									if (result3 == 1 && !string.IsNullOrWhiteSpace(text11))
									{
										text7 = text11.ToLower();
										switch (text7)
										{
										case "and":
											android = true;
											break;
										case "ios":
											ios = true;
											break;
										case "pwa":
											pwa = true;
											break;
										}
									}
								}
							}
							string[] array6 = text8.Split(new char[1] { ';' });
							if (array6 != null && array6.Length != 0)
							{
								string[] array2 = array6;
								foreach (string text12 in array2)
								{
									if (string.IsNullOrWhiteSpace(text12))
									{
										continue;
									}
									string[] array7 = text12.Split(new char[1] { ':' });
									if (array7 == null || array7.Length < 2)
									{
										continue;
									}
									if (!string.IsNullOrWhiteSpace(array7[0]))
									{
										if (array7[0].StartsWith(" "))
										{
											array7[0] = array7[0].TrimStart(new char[1] { ' ' });
										}
										if (array7[0].EndsWith(" "))
										{
											array7[0] = array7[0].TrimEnd(new char[1] { ' ' });
										}
									}
									if (!string.IsNullOrWhiteSpace(array7[1]))
									{
										if (array7[1].StartsWith(" "))
										{
											array7[1] = array7[1].TrimStart(new char[1] { ' ' });
										}
										if (array7[1].EndsWith(" "))
										{
											array7[1] = array7[1].TrimEnd(new char[1] { ' ' });
										}
									}
									string text13 = array7[0];
									int result4 = 0;
									int.TryParse(array7[1], out result4);
									if (result4 != 1 || string.IsNullOrWhiteSpace(text13))
									{
										continue;
									}
									string text14 = "";
									text7 = text13.ToLower();
									switch (text7)
									{
									case "mobcrm":
										text14 = "";
										text14 = KaraafzarUpdateDomainForMob(cmpNumber.GetValueOrDefault(), "mobCRM", "", "", android, ios, pwa, karaAfzarMobDomainViewModel);
										if (!string.IsNullOrWhiteSpace(text14))
										{
											if (!string.IsNullOrWhiteSpace(text2))
											{
												text2 += ",";
											}
											text2 += text14;
										}
										break;
									case "mobhrm":
										text14 = "";
										text14 = KaraafzarUpdateDomainForMob(cmpNumber.GetValueOrDefault(), "mobHRM", "", "hrm", android, ios, pwa, karaAfzarMobDomainViewModel);
										if (!string.IsNullOrWhiteSpace(text14))
										{
											if (!string.IsNullOrWhiteSpace(text2))
											{
												text2 += ",";
											}
											text2 += text14;
										}
										break;
									case "mobcic":
										text14 = "";
										text14 = KaraafzarUpdateDomainForMob(cmpNumber.GetValueOrDefault(), "mobCIC", "", "cic", android, ios, pwa, karaAfzarMobDomainViewModel);
										if (!string.IsNullOrWhiteSpace(text14))
										{
											if (!string.IsNullOrWhiteSpace(text2))
											{
												text2 += ",";
											}
											text2 += text14;
										}
										break;
									case "mobfo":
										text14 = "";
										text14 = KaraafzarUpdateDomainForMob(cmpNumber.GetValueOrDefault(), "mobFo", "", "fo", android, ios, pwa, karaAfzarMobDomainViewModel);
										if (!string.IsNullOrWhiteSpace(text14))
										{
											if (!string.IsNullOrWhiteSpace(text2))
											{
												text2 += ",";
											}
											text2 += text14;
										}
										break;
									case "mobparsservicesupport":
										text14 = "";
										text14 = KaraafzarUpdateDomainForMob(cmpNumber.GetValueOrDefault(), "mobParsServiceSupport", "", "pss", android, ios, pwa, karaAfzarMobDomainViewModel);
										if (!string.IsNullOrWhiteSpace(text14))
										{
											if (!string.IsNullOrWhiteSpace(text2))
											{
												text2 += ",";
											}
											text2 += text14;
										}
										break;
									case "mobocsan":
										text14 = "";
										text14 = KaraafzarUpdateDomainForMob(cmpNumber.GetValueOrDefault(), "mobocsan", "", "ocsan", android, ios, pwa, karaAfzarMobDomainViewModel);
										if (!string.IsNullOrWhiteSpace(text14))
										{
											if (!string.IsNullOrWhiteSpace(text2))
											{
												text2 += ",";
											}
											text2 += text14;
										}
										break;
									case "mobhamgam":
										text14 = "";
										text14 = KaraafzarUpdateDomainForMob(cmpNumber.GetValueOrDefault(), "mobhamgam", "", "hamgam", android, ios, pwa, karaAfzarMobDomainViewModel);
										if (!string.IsNullOrWhiteSpace(text14))
										{
											if (!string.IsNullOrWhiteSpace(text2))
											{
												text2 += ",";
											}
											text2 += text14;
										}
										break;
									case "mobkenaretam":
										text14 = "";
										text14 = KaraafzarUpdateDomainForMob(cmpNumber.GetValueOrDefault(), "mobkenaretam", "", "kenar", android, ios, pwa, karaAfzarMobDomainViewModel);
										if (!string.IsNullOrWhiteSpace(text14))
										{
											if (!string.IsNullOrWhiteSpace(text2))
											{
												text2 += ",";
											}
											text2 += text14;
										}
										break;
									case "mobcrmshop":
										text14 = "";
										text14 = KaraafzarUpdateDomainForMob(cmpNumber.GetValueOrDefault(), "mobCRMShop", "", "crmshop", android, ios, pwa, karaAfzarMobDomainViewModel);
										if (!string.IsNullOrWhiteSpace(text14))
										{
											if (!string.IsNullOrWhiteSpace(text2))
											{
												text2 += ",";
											}
											text2 += text14;
										}
										break;
									}
								}
							}
							if (!string.IsNullOrWhiteSpace(text2))
							{
								text2 = "[{" + text2 + "}]";
								string ordiDescriptionIJson = "";
								List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
								foreach (Languages item2 in Enumerable.ToList<Languages>((IEnumerable<Languages>)Language.Get()))
								{
									CommonMultiLanguageViewModel commonMultiLanguageViewModel = new CommonMultiLanguageViewModel();
									commonMultiLanguageViewModel.LanguageId = item2.LanguageID;
									commonMultiLanguageViewModel.Value = text2;
									list3.Add(commonMultiLanguageViewModel);
								}
								if (list3 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3))
								{
									ordiDescriptionIJson = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3));
								}
								DateTime now = DateTime.Now;
								DateTime value = now;
								string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
								DateTimeClass.DefineDayeOfWeekStartWith7(now.DayOfWeek.ToString());
								now.ToString("HH:mm:ss");
								short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
								string appType = Configuration.AppType;
								_ = Financial.Get().Id;
								short.Parse(now.ToString("yyyy", new PersianCulture()));
								int userId = UserLogin.CurrentUser.UserId;
								cRMSpIEntities.WSspUpdateOrderItemDescriptionI(item.OrderItemID, ordiDescriptionIJson, appType, value2, userId, value, registerDatePersian, result);
								text = "";
								continue;
							}
							text = string.Format(Messages.msgErrorCreateMobDomainForPrd, item.PrdName ?? "");
							text7 = text;
						}
						else
						{
							text = string.Format(Messages.msgErrorNotDefineNameOrCodePrdManufacture, item.PrdName ?? "");
							text7 = text;
						}
						goto IL_0f3a;
					}
				}
				else
				{
					text = Messages.msgErrorNotFoundProductToCreateMobDomain;
				}
			}
			else
			{
				text = Messages.msgErrorNotFoundProductToCreateMobDomain;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			text = ex.Message;
		}
		finally
		{
			cRMSpEntities.Dispose();
			cRMSpIEntities.Dispose();
		}
		return text;
		IL_0f3a:
		return text7;
	}

	public static string KaraafzarUpdateDomainForMob(int cmpNumber, string appName, string prefixDomain, string suffixDomain, bool android, bool ios, bool pwa, KaraAfzarMobDomainViewModel model)
	{
		string result = "";
		try
		{
			string text = "";
			string text2 = "";
			string text3 = "";
			string text4 = "";
			string text5 = "";
			string text6 = "";
			string text7 = "";
			KaraAfzarMobDomainInfoViewModel karaAfzarMobDomainInfoViewModel = new KaraAfzarMobDomainInfoViewModel();
			switch (appName.ToLower())
			{
			case "mobcrm":
				if (model != null && model.mobCRM != null)
				{
					karaAfzarMobDomainInfoViewModel = model.mobCRM;
				}
				break;
			case "mobhrm":
				if (model != null && model.mobHRM != null)
				{
					karaAfzarMobDomainInfoViewModel = model.mobHRM;
				}
				break;
			case "mobcic":
				if (model != null && model.mobCIC != null)
				{
					karaAfzarMobDomainInfoViewModel = model.mobCIC;
				}
				break;
			case "mobfo":
				if (model != null && model.mobFo != null)
				{
					karaAfzarMobDomainInfoViewModel = model.mobFo;
				}
				break;
			case "mobparsservicesupport":
				if (model != null && model.mobParsServiceSupport != null)
				{
					karaAfzarMobDomainInfoViewModel = model.mobParsServiceSupport;
				}
				break;
			case "mobocsan":
				if (model != null && model.mobocsan != null)
				{
					karaAfzarMobDomainInfoViewModel = model.mobocsan;
				}
				break;
			case "mobhamgam":
				if (model != null && model.mobhamgam != null)
				{
					karaAfzarMobDomainInfoViewModel = model.mobhamgam;
				}
				break;
			case "mobkenaretam":
				if (model != null && model.mobkenaretam != null)
				{
					karaAfzarMobDomainInfoViewModel = model.mobkenaretam;
				}
				break;
			case "mobcrmshop":
				if (model != null && model.mobCRMShop != null)
				{
					karaAfzarMobDomainInfoViewModel = model.mobCRMShop;
				}
				break;
			}
			if (karaAfzarMobDomainInfoViewModel != null)
			{
				text = karaAfzarMobDomainInfoViewModel.DomainAnd ?? "";
				text2 = karaAfzarMobDomainInfoViewModel.URLAnd ?? "";
				text3 = karaAfzarMobDomainInfoViewModel.DomainIos ?? "";
				text4 = karaAfzarMobDomainInfoViewModel.URLIos ?? "";
				text5 = karaAfzarMobDomainInfoViewModel.DomainPWA ?? "";
				text6 = karaAfzarMobDomainInfoViewModel.URLPWA ?? "";
				text7 = karaAfzarMobDomainInfoViewModel.CrossOrgURLPWA ?? "";
				if (!android && (!string.IsNullOrWhiteSpace(text) || !string.IsNullOrWhiteSpace(text2)))
				{
					android = true;
				}
				if (!ios && (!string.IsNullOrWhiteSpace(text3) || !string.IsNullOrWhiteSpace(text4)))
				{
					ios = true;
				}
				if (!pwa && (!string.IsNullOrWhiteSpace(text5) || !string.IsNullOrWhiteSpace(text6) || !string.IsNullOrWhiteSpace(text7)))
				{
					pwa = true;
				}
			}
			string text8 = "";
			if (android)
			{
				if (!string.IsNullOrWhiteSpace(text8))
				{
					text8 += ",";
				}
				text8 = (string.IsNullOrWhiteSpace(text) ? (text8 + "\"DomainAnd\":\"" + cmpNumber + suffixDomain + "\",") : (text8 + "\"DomainAnd\":\"" + text + "\","));
				text8 = (string.IsNullOrWhiteSpace(text2) ? (text8 + "\"URLAnd\": \"\"") : (text8 + "\"URLAnd\": \"" + text2 + "\""));
			}
			if (ios)
			{
				if (!string.IsNullOrWhiteSpace(text8))
				{
					text8 += ",";
				}
				text8 = (string.IsNullOrWhiteSpace(text3) ? (text8 + "\"DomainIos\":\"" + cmpNumber + suffixDomain + "ios\",") : (text8 + "\"DomainIos\":\"" + text3 + "\","));
				text8 = (string.IsNullOrWhiteSpace(text4) ? (text8 + "\"URLIos\": \"\"") : (text8 + "\"URLIos\": \"" + text4 + "\""));
			}
			if (pwa)
			{
				if (!string.IsNullOrWhiteSpace(text8))
				{
					text8 += ",";
				}
				text8 = (string.IsNullOrWhiteSpace(text5) ? (text8 + "\"DomainPWA\":\"" + cmpNumber + suffixDomain + "pwa\",") : (text8 + "\"DomainPWA\":\"" + text5 + "\","));
				text8 = (string.IsNullOrWhiteSpace(text6) ? (text8 + "\"URLPWA\":\"\",") : (text8 + "\"URLPWA\":\"" + text6 + "\","));
				text8 = (string.IsNullOrWhiteSpace(text7) ? (text8 + "\"CrossOrgURLPWA\":\"\"") : (text8 + "\"CrossOrgURLPWA\":\"" + text7 + "\""));
			}
			if (!string.IsNullOrWhiteSpace(text8))
			{
				text8 = "\"" + appName + "\":{" + text8 + "}";
			}
			if (!string.IsNullOrWhiteSpace(text8))
			{
				result = text8;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public static bool CanChangeCommissionByOtherUser(int ordId)
	{
		bool result = true;
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (!UserLogin.IsUserAccess("frmOrder", "actAddCommByOtherUser", currentUser))
			{
				WSspSelectOrderById_Result wSspSelectOrderById_Result = Enumerable.FirstOrDefault<WSspSelectOrderById_Result>((IEnumerable<WSspSelectOrderById_Result>)cRMSpEntities.WSspSelectOrderById(ordId, lCID, result2));
				if (wSspSelectOrderById_Result != null && ("," + wSspSelectOrderById_Result.cmpReferUserId.GetValueOrDefault() + "," + wSspSelectOrderById_Result.cmpSuppUserId.GetValueOrDefault() + "," + wSspSelectOrderById_Result.ordReferUserId.GetValueOrDefault() + "," + wSspSelectOrderById_Result.ordSellerId.GetValueOrDefault() + ",").IndexOf("," + currentUser.UserId + ",", StringComparison.Ordinal) < 0)
				{
					result = false;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities.Dispose();
		}
		return result;
	}

	public static List<SelectListItem> GetOrdExternalLinks(int ordId = 0, int? currentLoginUserId = null)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		list.Add(new SelectListItem());
		list.Add(new SelectListItem
		{
			Text = string.Format(Labels.lblFolinkWithLogin, "lblOrd".OrderLabels())
		});
		list.Add(new SelectListItem
		{
			Text = string.Format(Labels.lblFolinkWithoutLogin, "lblOrd".OrderLabels())
		});
		list.Add(new SelectListItem
		{
			Text = string.Format(Labels.lbllinkWithoutLogin, "lblOrd".OrderLabels())
		});
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		CRMspLoadUserLoginInfoViewModel cRMspLoadUserLoginInfoViewModel = null;
		cRMspLoadUserLoginInfoViewModel = ((currentLoginUserId.GetValueOrDefault() == 0) ? UserLogin.CurrentUser : UserLogin.User(currentLoginUserId));
		try
		{
			if (ordId != 0)
			{
				CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
				string text = CodeDecode.CoddingUTF8(ordId.ToString());
				if (cRMspSelectCrmsysSetting_Result != null)
				{
					if (!UserLogin.IsUserAccess("frmOrder", "actGetOrdFOLink", cRMspLoadUserLoginInfoViewModel))
					{
						list[0].Value = Messages.ErrorNotAccess;
					}
					else
					{
						string text2 = (cRMspSelectCrmsysSetting_Result.FOUrl ?? "").Trim();
						if (!string.IsNullOrWhiteSpace(text2))
						{
							if (!text2.StartsWith("http"))
							{
								text2 = "http://" + text2;
							}
							text2 = text2.TrimEnd(new char[1] { '/' });
							list[1].Value = text2 + "?" + "Ord".ToLower() + "=" + text;
							list[2].Value = list[1].Value + "&nl=1";
						}
					}
					string text3 = (cRMspSelectCrmsysSetting_Result.CrmIPStatic ?? "").TrimEnd(new char[1] { '/' });
					if (!string.IsNullOrWhiteSpace(text3))
					{
						list[3].Value = text3 + "/OnlinePayment/Home/ShowOprDetails?t=" + CodeDecode.CoddingUTF8(30 + "|" + ordId);
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			list[0].Value = Messages.msgErrorRunFunction;
			list = null;
		}
		return list;
	}

	public static List<SelectListItem> GetOrdFoShortLinks(int ordId = 0, int? currentLoginUserId = null)
	{
		DateTime now = DateTime.Now;
		string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
		short.Parse(now.ToString("MM", new PersianCulture()));
		string appType = Configuration.AppType;
		short.Parse(Financial.Get().Id.ToString());
		int num = currentLoginUserId.GetValueOrDefault();
		if (num == 0)
		{
			num = UserLogin.CurrentUser.UserId;
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> ordExternalLinks = GetOrdExternalLinks(ordId, currentLoginUserId);
		List<SelectListItem> list = new List<SelectListItem>();
		CRMSpIIEntities cRMSpIIEntities = new CRMSpIIEntities();
		for (int i = 0; i < ordExternalLinks.Count; i++)
		{
			if (i == 0)
			{
				list.Add(new SelectListItem
				{
					Value = ordExternalLinks[i].Value,
					Text = ordExternalLinks[i].Text
				});
			}
			else if (!string.IsNullOrWhiteSpace(ordExternalLinks[i].Value))
			{
				Uri uri = new Uri(ordExternalLinks[i].Value);
				string text = uri.Scheme + "://" + uri.Authority;
				ObjectParameter objectParameter = new ObjectParameter("ShortKey", typeof(string));
				cRMSpIIEntities.CRMspInsertShortLink(ordExternalLinks[i].Value, 30, ordId, null, null, null, null, null, null, num, now, registerDatePersian, appType, lCID, text, objectParameter);
				string text2 = objectParameter.Value?.ToString();
				list.Add(new SelectListItem
				{
					Value = text + "/s/" + text2 + " ",
					Text = ordExternalLinks[i].Text
				});
			}
			else
			{
				list.Add(new SelectListItem
				{
					Value = (ordExternalLinks[i].Value ?? ""),
					Text = (ordExternalLinks[i].Text ?? "")
				});
			}
		}
		return list;
	}

	public static bool IsSentToLinkAcc(int ordId)
	{
		bool result = false;
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			WSspSelectOrderById_Result wSspSelectOrderById_Result = Enumerable.FirstOrDefault<WSspSelectOrderById_Result>((IEnumerable<WSspSelectOrderById_Result>)cRMSpEntities.WSspSelectOrderById(ordId, lCID, result2));
			if (wSspSelectOrderById_Result != null)
			{
				bool.TryParse(wSspSelectOrderById_Result.IsSentToLinkAcc.ToString(), out result);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return result;
	}

	public static bool IsSentToLinkAccByAction(int ordId)
	{
		bool result = false;
		try
		{
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (!UserLogin.IsUserAccess("frmOrder", "actChangeAfterSendToLinkAcc", currentUser))
			{
				result = IsSentToLinkAcc(ordId);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public static bool PayIsSentToLinkAcc(int payId)
	{
		bool result = false;
		CRMSpIEntities cRMSpIEntities = new CRMSpIEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			WSspSelectOrderPaymentsWithId_Result wSspSelectOrderPaymentsWithId_Result = Enumerable.FirstOrDefault<WSspSelectOrderPaymentsWithId_Result>((IEnumerable<WSspSelectOrderPaymentsWithId_Result>)cRMSpIEntities.WSspSelectOrderPaymentsWithId(payId, lCID, result2));
			if (wSspSelectOrderPaymentsWithId_Result != null)
			{
				bool.TryParse(wSspSelectOrderPaymentsWithId_Result.IsSentToLinkAcc.ToString(), out result);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpIEntities?.Dispose();
		}
		return result;
	}

	public static bool PayIsSentToLinkAccByAction(int payId)
	{
		bool result = false;
		try
		{
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (!UserLogin.IsUserAccess("frmOrder", "actChangeAfterSendToLinkAcc", currentUser))
			{
				result = PayIsSentToLinkAcc(payId);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public static string GetOrdFOLink(int ordId = 0)
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
			if (ordId != 0)
			{
				CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
				if (cRMspSelectCrmsysSetting_Result != null)
				{
					string text = cRMspSelectCrmsysSetting_Result.FOUrl ?? "";
					text = text.Trim();
					if (!string.IsNullOrWhiteSpace(text))
					{
						if (!text.StartsWith("http"))
						{
							text = "http://" + text;
						}
						if (text.EndsWith("/"))
						{
							text = text.Substring(0, text.Length - 1);
						}
						string text2 = CodeDecode.CoddingUTF8(ordId.ToString());
						text = text + "?" + "Ord".ToLower() + "=" + text2;
						result2 = text;
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result2;
	}

	public static bool SendSmsFoSettingOrdAfterVerify(int ordId, int? currentLoginUserId = null)
	{
		bool result = false;
		CRMSpIIEntities cRMSpIIEntities = new CRMSpIIEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			if (ordId != 0)
			{
				DateTime now = DateTime.Now;
				DateTime value = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				short value3 = short.Parse(now.ToString("yyyy", new PersianCulture()));
				int num = currentLoginUserId.GetValueOrDefault();
				if (num == 0)
				{
					num = UserLogin.CurrentUser.UserId;
				}
				string ordFOLink = GetOrdFOLink(ordId);
				ordFOLink = ordFOLink ?? "";
				ObjectParameter objectParameter = new ObjectParameter("Result", 0);
				cRMSpIIEntities.CRMspSendSmsFoSettingOrdAfterVerify(ordId, ordFOLink, num, value3, value2, value, registerDatePersian, appType, lCID, result2, objectParameter, centerId);
				if (objectParameter != null && objectParameter.Value != null)
				{
					int result3 = 0;
					int.TryParse(objectParameter.Value.ToString(), out result3);
					if (result3 == 1)
					{
						result = true;
					}
				}
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		finally
		{
			cRMSpIIEntities.Dispose();
		}
		return result;
	}

	public static int? GetOrdCId(int ordId)
	{
		int? result = null;
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			WSspSelectOrderById_Result wSspSelectOrderById_Result = Enumerable.FirstOrDefault<WSspSelectOrderById_Result>((IEnumerable<WSspSelectOrderById_Result>)cRMSpEntities.WSspSelectOrderById(ordId, lCID, result2));
			if (wSspSelectOrderById_Result != null)
			{
				result = wSspSelectOrderById_Result.ordCId;
				return result;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return result;
	}

	public static int? GetOrdItemCId(int ordItemId)
	{
		int? result = null;
		CRMSpIEntities cRMSpIEntities = new CRMSpIEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			WSspSelectOrderItemsById_Result wSspSelectOrderItemsById_Result = Enumerable.FirstOrDefault<WSspSelectOrderItemsById_Result>((IEnumerable<WSspSelectOrderItemsById_Result>)cRMSpIEntities.WSspSelectOrderItemsById(ordItemId, lCID, result2));
			if (wSspSelectOrderItemsById_Result != null)
			{
				result = wSspSelectOrderItemsById_Result.ordICId;
				return result;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpIEntities?.Dispose();
		}
		return result;
	}

	public static List<WSspSelectOrderOprByOprType_Result> SelectOrderOprByOprType(int oprType = 0)
	{
		List<WSspSelectOrderOprByOprType_Result> result = new List<WSspSelectOrderOprByOprType_Result>();
		CRMSpIIEntities cRMSpIIEntities = new CRMSpIIEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int value = 0;
			if (UserLogin.CurrentUser != null)
			{
				value = UserLogin.CurrentUser.UserId;
			}
			List<WSspSelectOrderOprByOprType_Result> list = Enumerable.ToList<WSspSelectOrderOprByOprType_Result>((IEnumerable<WSspSelectOrderOprByOprType_Result>)cRMSpIIEntities.WSspSelectOrderOprByOprType(oprType, lCID, result2, value));
			if (list != null)
			{
				result = list;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		finally
		{
			cRMSpIIEntities?.Dispose();
		}
		return result;
	}

	public static List<SelectListItem> SelectOrderOprByOprType_SelectListItem(int oprType = 0, int selectedId = 0)
	{
		return Enumerable.ToList<SelectListItem>(Enumerable.Select<WSspSelectOrderOprByOprType_Result, SelectListItem>((IEnumerable<WSspSelectOrderOprByOprType_Result>)SelectOrderOprByOprType(oprType), (Func<WSspSelectOrderOprByOprType_Result, SelectListItem>)((WSspSelectOrderOprByOprType_Result x) => new SelectListItem
		{
			Text = x.Name,
			Value = x.OrderOprID.ToString(),
			Selected = (x.OrderOprID == selectedId)
		})));
	}

	public static List<WSspSelectOrderOpr_Result> SelectOrderOpr(int userId = -1, int currLangId = 0, int defLangId = 0)
	{
		List<WSspSelectOrderOpr_Result> result = new List<WSspSelectOrderOpr_Result>();
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			if (defLangId == 0)
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out defLangId);
			}
			if (defLangId <= 0)
			{
				defLangId = 1065;
			}
			if (currLangId == 0)
			{
				currLangId = Thread.CurrentThread.CurrentCulture.LCID;
			}
			if (userId == -1 && UserLogin.CurrentUser != null)
			{
				userId = UserLogin.CurrentUser.UserId;
			}
			result = Enumerable.ToList<WSspSelectOrderOpr_Result>((IEnumerable<WSspSelectOrderOpr_Result>)cRMSpEntities.WSspSelectOrderOpr(currLangId, defLangId, userId));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return result;
	}

	public static bool SendToLinkAccNeedVerify(int ordId, ref string errorMessage)
	{
		bool result = true;
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			string linkAccSystemTitle = Setting.GetLinkAccSystemTitle();
			string actionName = "actSendToLinkAccNeedVerify";
			if (UserLogin.IsUserAccess("frmOrder", actionName, UserLogin.CurrentUser))
			{
				WSspSelectOrderById_Result wSspSelectOrderById_Result = Enumerable.FirstOrDefault<WSspSelectOrderById_Result>((IEnumerable<WSspSelectOrderById_Result>)cRMSpEntities.WSspSelectOrderById(ordId, lCID, result2));
				if (wSspSelectOrderById_Result != null && !wSspSelectOrderById_Result.ordIsVerified.GetValueOrDefault())
				{
					result = false;
					errorMessage = string.Format(Messages.msgErrorSendToLinkAccNeedVerifyByNumber, "lblOrd".OrderLabels(), wSspSelectOrderById_Result.ordNumber.ToString(), linkAccSystemTitle);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return result;
	}

	public static bool IsVerified(int ordId)
	{
		bool result = false;
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			WSspSelectOrderById_Result wSspSelectOrderById_Result = Enumerable.FirstOrDefault<WSspSelectOrderById_Result>((IEnumerable<WSspSelectOrderById_Result>)cRMSpEntities.WSspSelectOrderById(ordId, lCID, result2));
			if (wSspSelectOrderById_Result != null)
			{
				result = wSspSelectOrderById_Result.ordIsVerified.GetValueOrDefault();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return result;
	}

	public static bool CheckCmpCredit(int ordId)
	{
		bool result = false;
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			WSspSelectOrderById_Result wSspSelectOrderById_Result = Enumerable.FirstOrDefault<WSspSelectOrderById_Result>((IEnumerable<WSspSelectOrderById_Result>)cRMSpEntities.WSspSelectOrderById(ordId, lCID, result2));
			if (wSspSelectOrderById_Result != null)
			{
				result = OtherSystems.CheckCmpCreditByAmount(0, wSspSelectOrderById_Result.ordCompanyId, wSspSelectOrderById_Result.ordTotalAmount.GetValueOrDefault());
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return result;
	}

	public static bool CalcOrderCancelledScores(int ordId)
	{
		bool result = false;
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		CRMSpIIIEntities cRMSpIIIEntities = new CRMSpIIIEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			short value3 = short.Parse(Financial.Get().Id.ToString());
			int? centerId = null;
			int? userId = null;
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (currentUser != null)
			{
				centerId = currentUser.UserLastCId;
				userId = currentUser.UserId;
			}
			int result3 = 0;
			WSspSelectOrderById_Result wSspSelectOrderById_Result = Enumerable.FirstOrDefault<WSspSelectOrderById_Result>((IEnumerable<WSspSelectOrderById_Result>)cRMSpEntities.WSspSelectOrderById(ordId, lCID, result2));
			if (wSspSelectOrderById_Result != null)
			{
				int.TryParse(wSspSelectOrderById_Result.ordStatusId.ToString(), out result3);
			}
			if (result3 == 4)
			{
				ObjectParameter objectParameter = new ObjectParameter("result", typeof(int));
				cRMSpIIIEntities.ScorespInsertAndCalcOrderCancelledScores(ordId, value, true, userId, value3, value2, value, registerDatePersian, appType, lCID, result2, centerId, objectParameter);
				if (objectParameter != null)
				{
					int result4 = 0;
					int.TryParse(objectParameter.Value.ToString(), out result4);
					if (result4 > 0)
					{
						result = true;
					}
				}
			}
			else
			{
				result = true;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
			cRMSpIIIEntities?.Dispose();
		}
		return result;
	}

	public static string CheckBeforeVerification(int ordId, string txt = "", int mode = 1, int? currentLoginUserId = null)
	{
		string result = "";
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		CRMSpIEntities cRMSpIEntities = new CRMSpIEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			CRMspLoadUserLoginInfoViewModel cRMspLoadUserLoginInfoViewModel = null;
			cRMspLoadUserLoginInfoViewModel = ((currentLoginUserId.GetValueOrDefault() == 0) ? UserLogin.CurrentUser : UserLogin.User(currentLoginUserId));
			if (cRMspLoadUserLoginInfoViewModel != null)
			{
				_ = cRMspLoadUserLoginInfoViewModel.UserLastCId;
				_ = cRMspLoadUserLoginInfoViewModel.UserId;
			}
			if (string.IsNullOrWhiteSpace(txt))
			{
				txt = "lblOrd".OrderLabels();
			}
			if (mode == 0)
			{
				mode = 1;
			}
			WSspSelectOrderById_Result wSspSelectOrderById_Result = Enumerable.FirstOrDefault<WSspSelectOrderById_Result>((IEnumerable<WSspSelectOrderById_Result>)cRMSpEntities.WSspSelectOrderById(ordId, lCID, result2));
			decimal num;
			WSfnReturnOrderSumFooter_Result wSfnReturnOrderSumFooter_Result;
			decimal obj;
			if (wSspSelectOrderById_Result != null)
			{
				if (!UserLogin.IsUserAccess("frmOrder", "actVerifyAfterCancel", cRMspLoadUserLoginInfoViewModel) && wSspSelectOrderById_Result.ordStatusId.GetValueOrDefault() == 4)
				{
					result = string.Format("msgErrorUnableVerifyOrderCanceledByParam".OrderMessages(), txt);
					return result;
				}
				if (!CheckCmpCredit(ordId))
				{
					result = string.Format(Messages.msgErrorNoVerifyObjByCmpWithoutCredit, txt) + "<br/>";
					return result;
				}
				num = default(decimal);
				CRMspReturnRollDiscountLimitation_Result cRMspReturnRollDiscountLimitation_Result = Enumerable.FirstOrDefault<CRMspReturnRollDiscountLimitation_Result>((IEnumerable<CRMspReturnRollDiscountLimitation_Result>)Enumerable.ToList<CRMspReturnRollDiscountLimitation_Result>((IEnumerable<CRMspReturnRollDiscountLimitation_Result>)cRMSpEntities.CRMspReturnRollDiscountLimitation(cRMspLoadUserLoginInfoViewModel.RollId)));
				if (cRMspReturnRollDiscountLimitation_Result == null)
				{
					result = Messages.ErrorNotFoundSetting;
					return result;
				}
				if (cRMspReturnRollDiscountLimitation_Result.LimitOrderDiscountActive.HasValue && cRMspReturnRollDiscountLimitation_Result.LimitOrderDiscountActive.GetValueOrDefault())
				{
					num = cRMspReturnRollDiscountLimitation_Result.LimitOrderDiscountPercent.GetValueOrDefault();
				}
				if (num > 0m)
				{
					wSfnReturnOrderSumFooter_Result = Enumerable.FirstOrDefault<WSfnReturnOrderSumFooter_Result>((IEnumerable<WSfnReturnOrderSumFooter_Result>)Enumerable.ToList<WSfnReturnOrderSumFooter_Result>((IEnumerable<WSfnReturnOrderSumFooter_Result>)cRMSpEntities.WSfnReturnOrderSumFooter(ordId)));
					if (wSfnReturnOrderSumFooter_Result != null)
					{
						if (wSfnReturnOrderSumFooter_Result.TotalPriceSumWithoutDiscount.HasValue)
						{
							decimal? totalPriceSumWithoutDiscount = wSfnReturnOrderSumFooter_Result.TotalPriceSumWithoutDiscount;
							if ((totalPriceSumWithoutDiscount.GetValueOrDefault() > default(decimal)) & totalPriceSumWithoutDiscount.HasValue)
							{
								obj = Convert.ToDecimal(wSfnReturnOrderSumFooter_Result.TotalDiscountSum * (decimal?)100) / Convert.ToDecimal(wSfnReturnOrderSumFooter_Result.TotalPriceSumWithoutDiscount);
								goto IL_025c;
							}
						}
						obj = 0m;
						goto IL_025c;
					}
				}
			}
			else
			{
				result = Messages.ErrorNotFound;
			}
			goto end_IL_0012;
			IL_045d:
			decimal obj2;
			decimal num2 = (decimal)obj2;
			if (num2 > num)
			{
				result = "MaxDiscountPercentOrderInActiveOrder".OrderMessages() + " " + num;
				if (mode == 2)
				{
					result = string.Format("MaxDiscountPercentOrderInActiveOrderByParam".OrderMessages(), txt) + " " + num;
				}
				return result;
			}
			goto end_IL_0012;
			IL_025c:
			num2 = obj;
			if (num2 != 0m)
			{
				List<WSspSelectOrderItemsByNotInSum_Result> list = Enumerable.ToList<WSspSelectOrderItemsByNotInSum_Result>((IEnumerable<WSspSelectOrderItemsByNotInSum_Result>)cRMSpEntities.WSspSelectOrderItemsByNotInSum(ordId, false, lCID, result2));
				if (list != null && Enumerable.Any<WSspSelectOrderItemsByNotInSum_Result>((IEnumerable<WSspSelectOrderItemsByNotInSum_Result>)list))
				{
					decimal num3 = default(decimal);
					int num4 = 0;
					foreach (WSspSelectOrderItemsByNotInSum_Result item in list)
					{
						if (item.ordIDiscountPercent.GetValueOrDefault() != 0m)
						{
							num3 += item.ordIDiscountPercent.GetValueOrDefault();
							num4++;
						}
					}
					if (num3 > 0m && num4 > 0)
					{
						num2 = num3 / (decimal)num4;
					}
				}
			}
			if (wSfnReturnOrderSumFooter_Result.SumPriceAmount.HasValue)
			{
				if (num2 > num)
				{
					result = Messages.MaxDiscountPercentInActiveOrder + " " + num;
					if (mode == 2)
					{
						result = string.Format(Messages.MaxDiscountPercentInActiveOrderByParam, txt) + " " + num;
					}
					return result;
				}
				if (wSfnReturnOrderSumFooter_Result.SumPriceAmount.GetValueOrDefault() == 0m && wSspSelectOrderById_Result.ordDiscount.GetValueOrDefault() != 0m)
				{
					result = Messages.msgErrorDivisionByZero;
					return result;
				}
				if (wSfnReturnOrderSumFooter_Result.SumPriceAmount.HasValue)
				{
					decimal? totalPriceSumWithoutDiscount = wSfnReturnOrderSumFooter_Result.SumPriceAmount;
					if ((totalPriceSumWithoutDiscount.GetValueOrDefault() > default(decimal)) & totalPriceSumWithoutDiscount.HasValue)
					{
						obj2 = Convert.ToDecimal(wSspSelectOrderById_Result.ordDiscount.GetValueOrDefault() * 100m) / Convert.ToDecimal(wSfnReturnOrderSumFooter_Result.SumPriceAmount);
						goto IL_045d;
					}
				}
				obj2 = 0m;
				goto IL_045d;
			}
			end_IL_0012:;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
			cRMSpIEntities?.Dispose();
		}
		return result;
	}

	public static string ControlOrderItemsSoldStock(int ordId, int mode, string txt = "", string ordItemJson = "", string ordItemListStr = "", int userId = 0, int userLastCId = 0)
	{
		string result = "";
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		CRMSpIIEntities cRMSpIIEntities = new CRMSpIIEntities();
		CRMSpIIIEntities cRMSpIIIEntities = new CRMSpIIIEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int num = 0;
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (currentUser == null)
			{
				num = ((userId == 0) ? (-3) : userId);
			}
			else
			{
				int.TryParse(currentUser.UserLastCId.ToString(), out userLastCId);
				num = currentUser.UserId;
			}
			int id = Financial.Get().Id;
			int cmpId = 0;
			string msgIssueDraftFormOrderLackSoldStock = Messages.msgIssueDraftFormOrderLackSoldStock;
			string text = "";
			string text2 = "";
			bool flag = false;
			WSspSelectOrderById_Result wSspSelectOrderById_Result = Enumerable.FirstOrDefault<WSspSelectOrderById_Result>((IEnumerable<WSspSelectOrderById_Result>)cRMSpEntities.WSspSelectOrderById(ordId, lCID, result2));
			if (wSspSelectOrderById_Result != null)
			{
				cmpId = wSspSelectOrderById_Result.ordCompanyId;
				userLastCId = wSspSelectOrderById_Result.ordCId.GetValueOrDefault();
			}
			if (mode == 1)
			{
				msgIssueDraftFormOrderLackSoldStock = Messages.msgIssueDraftFormOrderLackSoldStock;
				text = "frmIssueDraftFromOrder";
				text2 = "actCanNotIssueDraftWithNoStockFromSold";
			}
			if (string.IsNullOrWhiteSpace(text) && string.IsNullOrWhiteSpace(text2))
			{
				flag = true;
			}
			else if (currentUser != null)
			{
				if (UserLogin.IsUserAccess(text, text2, currentUser))
				{
					flag = true;
				}
			}
			else if (UserLogin.IsUserAccessByUserId(text, text2, num, userLastCId))
			{
				flag = true;
			}
			if (flag)
			{
				List<WSspControlOrderItemsSoldStock_Result> list = Enumerable.ToList<WSspControlOrderItemsSoldStock_Result>((IEnumerable<WSspControlOrderItemsSoldStock_Result>)cRMSpIIIEntities.WSspControlOrderItemsSoldStock(ordId, ordItemJson, ordItemListStr, userLastCId, 1, id, lCID, result2));
				if (list != null && Enumerable.Any<WSspControlOrderItemsSoldStock_Result>((IEnumerable<WSspControlOrderItemsSoldStock_Result>)list))
				{
					CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
					bool flag2 = false;
					int num2 = 0;
					bool flag3 = false;
					if (cRMspSelectCrmsysSetting_Result != null)
					{
						flag2 = ((cRMspSelectCrmsysSetting_Result.InvStockFromLink.HasValue && cRMspSelectCrmsysSetting_Result.InvStockFromLink.GetValueOrDefault()) ? true : false);
						num2 = cRMspSelectCrmsysSetting_Result.LinkAccSystemId.GetValueOrDefault();
					}
					foreach (WSspControlOrderItemsSoldStock_Result item in list)
					{
						new ProductController();
						string text3 = "";
						double result3 = 0.0;
						double valueOrDefault = item.ordIQuantity.GetValueOrDefault();
						item.RemainCountAllWH.GetValueOrDefault();
						double valueOrDefault2 = item.SoldOrdQuantity.GetValueOrDefault();
						double valueOrDefault3 = item.TracingRemainCount.GetValueOrDefault();
						if (flag2 && num2 > 0)
						{
							text3 = OtherSystems.GetPrdQuantity(num, item.ordIPrdId.GetValueOrDefault(), item.ordIWHId.GetValueOrDefault(), item.ordILinkAccWHIdStr ?? "", item.ordITracing ?? "", cmpId);
							if (!string.IsNullOrEmpty(text3))
							{
								if (text3 == Labels.frmError)
								{
									text3 = "0";
								}
								if (text3 != Labels.frmError)
								{
									double.TryParse(text3, out result3);
									result3 -= valueOrDefault2;
									if (result3 < valueOrDefault)
									{
										result = string.Format(msgIssueDraftFormOrderLackSoldStock, item.PrdName ?? "");
										return result;
									}
									flag3 = true;
								}
							}
						}
						if (!flag3 && valueOrDefault3 - valueOrDefault2 < valueOrDefault)
						{
							result = string.Format(msgIssueDraftFormOrderLackSoldStock, item.PrdName ?? "");
							return result;
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
			cRMSpEntities?.Dispose();
			cRMSpIIEntities?.Dispose();
			cRMSpIIIEntities?.Dispose();
		}
		return result;
	}

	public static string GetTspOrdSendTypeTitle(int tspOrdSendTypeId)
	{
		string result = "";
		try
		{
			switch (tspOrdSendTypeId)
			{
			case 1:
				result = Labels.TspOrdSendTypeTitle;
				break;
			case 2:
				result = Labels.TspOrdSendTypeTitleInDate;
				break;
			case 3:
				result = Labels.TspOrdSendTypeTitleByMadeh9;
				break;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}
}
