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
using CRM.General.Calendar;
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

public class BuyOrder
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass0_0
	{
		public int orderId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public int orderId;

		public WSBuyOrder model;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__3;

		internal bool _003CCalcAndSetOrderAmounts_003Eb__3(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_1
	{
		public WSBuyOrder order;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass5_1 CS_0024_003C_003E8__locals1;
	}

	public static bool IsFixed(int orderId, int? isEditAfterFixMode = null)
	{
		_003C_003Ec__DisplayClass0_0 _003C_003Ec__DisplayClass0_ = new _003C_003Ec__DisplayClass0_0();
		_003C_003Ec__DisplayClass0_.orderId = orderId;
		bool result = false;
		CRMTabelEntities cRMTabelEntities = new CRMTabelEntities();
		try
		{
			DbSet<WSBuyOrder> wSBuyOrder = cRMTabelEntities.WSBuyOrder;
			ParameterExpression val = Expression.Parameter(typeof(WSBuyOrder), "c");
			WSBuyOrder wSBuyOrder2 = Queryable.FirstOrDefault<WSBuyOrder>((IQueryable<WSBuyOrder>)wSBuyOrder, Expression.Lambda<Func<WSBuyOrder, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass0_, typeof(_003C_003Ec__DisplayClass0_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (wSBuyOrder2 != null && wSBuyOrder2.bordIsFixed.HasValue && wSBuyOrder2.bordIsFixed.GetValueOrDefault())
			{
				result = true;
			}
			if (IsEditAfterFix(wSBuyOrder2.bordEditAfterFixInfoJs, _003C_003Ec__DisplayClass0_.orderId, isEditAfterFixMode))
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
			cRMTabelEntities.Dispose();
		}
		return result;
	}

	public static bool IsEditAfterFix(string editAfterFixInfoJs = "", int bordId = 0, int? mode = null)
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
			int userId = UserLogin.CurrentUser.UserId;
			mode = mode.GetValueOrDefault(1);
			if (string.IsNullOrWhiteSpace(editAfterFixInfoJs) && bordId != 0)
			{
				WSspSelectBuyOrderById_Result wSspSelectBuyOrderById_Result = Enumerable.FirstOrDefault<WSspSelectBuyOrderById_Result>((IEnumerable<WSspSelectBuyOrderById_Result>)cRMSpIIEntities.WSspSelectBuyOrderById(bordId, lCID, result2));
				if (wSspSelectBuyOrderById_Result != null)
				{
					editAfterFixInfoJs = wSspSelectBuyOrderById_Result.bordEditAfterFixInfoJs;
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
			cRMSpIIEntities?.Dispose();
		}
		return result;
	}

	public static bool CalcAndSetOrderAmounts(WSBuyOrder order)
	{
		return CalcAndSetOrderAmounts(0, order, null);
	}

	public static bool CalcAndSetOrderAmounts(int orderId)
	{
		return CalcAndSetOrderAmounts(orderId, null, null);
	}

	public static bool CalcAndSetOrderAmountsWithTax(int orderId, decimal bordTax)
	{
		return CalcAndSetOrderAmounts(orderId, null, bordTax);
	}

	private static bool CalcAndSetOrderAmounts(int orderId, WSBuyOrder model, decimal? bordTax)
	{
		_003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass5_0();
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
			_003C_003Ec__DisplayClass5_1 _003C_003Ec__DisplayClass5_ = new _003C_003Ec__DisplayClass5_1();
			_003C_003Ec__DisplayClass5_.order = CS_0024_003C_003E8__locals0.model;
			if (_003C_003Ec__DisplayClass5_.order == null)
			{
				DbSet<WSBuyOrder> wSBuyOrder = cRMTabelEntities.WSBuyOrder;
				ParameterExpression val = Expression.Parameter(typeof(WSBuyOrder), "c");
				_003C_003Ec__DisplayClass5_.order = Queryable.FirstOrDefault<WSBuyOrder>((IQueryable<WSBuyOrder>)wSBuyOrder, Expression.Lambda<Func<WSBuyOrder, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass5_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			}
			else
			{
				DbSet<WSBuyOrder> wSBuyOrder2 = cRMTabelEntities.WSBuyOrder;
				ParameterExpression val = Expression.Parameter(typeof(WSBuyOrder), "c");
				_003C_003Ec__DisplayClass5_.order = Queryable.FirstOrDefault<WSBuyOrder>((IQueryable<WSBuyOrder>)wSBuyOrder2, Expression.Lambda<Func<WSBuyOrder, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass5_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			}
			CS_0024_003C_003E8__locals0.orderId = _003C_003Ec__DisplayClass5_.order.BuyOrderID;
			WSfnReturnBuyOrderSumFooter_Result wSfnReturnBuyOrderSumFooter_Result = Enumerable.FirstOrDefault<WSfnReturnBuyOrderSumFooter_Result>((IEnumerable<WSfnReturnBuyOrderSumFooter_Result>)Enumerable.ToList<WSfnReturnBuyOrderSumFooter_Result>((IEnumerable<WSfnReturnBuyOrderSumFooter_Result>)cRMSpEntities.WSfnReturnBuyOrderSumFooter(CS_0024_003C_003E8__locals0.orderId)));
			if (wSfnReturnBuyOrderSumFooter_Result != null)
			{
				decimal num = Convert.ToDecimal(wSfnReturnBuyOrderSumFooter_Result.SumCostAmount.GetValueOrDefault());
				if (num >= 0m)
				{
					decimal num2 = num;
					int num3 = 0;
					decimal num4 = _003C_003Ec__DisplayClass5_.order.bordDiscount.GetValueOrDefault();
					if (_003C_003Ec__DisplayClass5_.order.bordDiscountPercent.HasValue)
					{
						decimal valueOrDefault = _003C_003Ec__DisplayClass5_.order.bordDiscountPercent.GetValueOrDefault();
						if (valueOrDefault > 0m)
						{
							num4 = Convert.ToDecimal(num * valueOrDefault) / 100m;
						}
					}
					decimal valueOrDefault2 = _003C_003Ec__DisplayClass5_.order.bordTransportation.GetValueOrDefault();
					decimal valueOrDefault3 = _003C_003Ec__DisplayClass5_.order.bordRound.GetValueOrDefault();
					decimal num5 = num2 + (decimal)num3 - num4;
					decimal valueOrDefault4 = _003C_003Ec__DisplayClass5_.order.bordTaxIndex.GetValueOrDefault();
					decimal num6 = _003C_003Ec__DisplayClass5_.order.bordTax.GetValueOrDefault();
					if (_003C_003Ec__DisplayClass5_.order.bordTaxIndex.HasValue)
					{
						num6 = ((_003C_003Ec__DisplayClass5_.order.bordCalculateTax.HasValue && _003C_003Ec__DisplayClass5_.order.bordCalculateTax.GetValueOrDefault()) ? (num5 * valueOrDefault4 / 100m) : 0m);
					}
					if (bordTax.HasValue)
					{
						num6 = bordTax.GetValueOrDefault();
					}
					decimal num7 = num5 + num6 + valueOrDefault2 - valueOrDefault3;
					DbSet<WSBuyOrderItems> wSBuyOrderItems = cRMTabelEntities.WSBuyOrderItems;
					ParameterExpression val = Expression.Parameter(typeof(WSBuyOrderItems), "c");
					int value = Queryable.Count<WSBuyOrderItems>((IQueryable<WSBuyOrderItems>)wSBuyOrderItems, Expression.Lambda<Func<WSBuyOrderItems, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass5_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
					decimal num8 = _003C_003Ec__DisplayClass5_.order.bordFacilityCost.GetValueOrDefault();
					if (_003C_003Ec__DisplayClass5_.order.bordFacilityCostPercent.HasValue)
					{
						decimal valueOrDefault5 = _003C_003Ec__DisplayClass5_.order.bordFacilityCostPercent.GetValueOrDefault();
						if (valueOrDefault5 > 0m)
						{
							num8 = Convert.ToDecimal(num * valueOrDefault5) / 100m;
						}
					}
					decimal valueOrDefault6 = _003C_003Ec__DisplayClass5_.order.bordFreightCost.GetValueOrDefault();
					double valueOrDefault7 = _003C_003Ec__DisplayClass5_.order.bordFreightCurrencyRate.GetValueOrDefault(1.0);
					decimal num9 = valueOrDefault6 * (decimal)valueOrDefault7;
					decimal valueOrDefault8 = _003C_003Ec__DisplayClass5_.order.bordCustomsFee.GetValueOrDefault();
					double valueOrDefault9 = _003C_003Ec__DisplayClass5_.order.bordCustomsCurrencyRate.GetValueOrDefault(1.0);
					decimal num10 = valueOrDefault8 * (decimal)valueOrDefault9;
					decimal valueOrDefault10 = _003C_003Ec__DisplayClass5_.order.bordCommission.GetValueOrDefault();
					double valueOrDefault11 = _003C_003Ec__DisplayClass5_.order.bordCommissionCurrencyRate.GetValueOrDefault(1.0);
					decimal num11 = valueOrDefault10 * (decimal)valueOrDefault11;
					decimal value2 = num7 + num8 + num9 + num10 + num11;
					double valueOrDefault12 = wSfnReturnBuyOrderSumFooter_Result.SumQuantity.GetValueOrDefault();
					decimal num12 = wSfnReturnBuyOrderSumFooter_Result.TotalDiscountSum.GetValueOrDefault();
					decimal num13 = wSfnReturnBuyOrderSumFooter_Result.TotalTaxSum.GetValueOrDefault();
					_003C_003Ec__DisplayClass5_.order.bordFacilityCost = num8;
					_003C_003Ec__DisplayClass5_.order.bordFreightCost = valueOrDefault6;
					_003C_003Ec__DisplayClass5_.order.bordFreightCurrencyRate = valueOrDefault7;
					_003C_003Ec__DisplayClass5_.order.bordFinalFreightCost = num9;
					_003C_003Ec__DisplayClass5_.order.bordCustomsFee = valueOrDefault8;
					_003C_003Ec__DisplayClass5_.order.bordCustomsCurrencyRate = valueOrDefault9;
					_003C_003Ec__DisplayClass5_.order.bordFinalCustomsFee = num10;
					_003C_003Ec__DisplayClass5_.order.bordCommission = valueOrDefault10;
					_003C_003Ec__DisplayClass5_.order.bordCommissionCurrencyRate = valueOrDefault11;
					_003C_003Ec__DisplayClass5_.order.bordFinalCommission = num11;
					_003C_003Ec__DisplayClass5_.order.bordTotalFinalCost = value2;
					bool result2 = false;
					WSspSelectCurrencyUnitsWithId_Result wSspSelectCurrencyUnitsWithId_Result = Enumerable.FirstOrDefault<WSspSelectCurrencyUnitsWithId_Result>((IEnumerable<WSspSelectCurrencyUnitsWithId_Result>)cRMSpEntities.WSspSelectCurrencyUnitsWithId(_003C_003Ec__DisplayClass5_.order.bordCurrencyUnitId, lCID, CS_0024_003C_003E8__locals0.defLangID));
					if (wSspSelectCurrencyUnitsWithId_Result != null)
					{
						bool.TryParse(wSspSelectCurrencyUnitsWithId_Result.IsDecimal.ToString(), out result2);
					}
					if (!result2)
					{
						if (num > 0m)
						{
							num = RoundCalculation.RoundNumber(num);
						}
						num5 = RoundCalculation.RoundNumber(num5);
						num6 = RoundCalculation.RoundNumber(num6);
						num4 = RoundCalculation.RoundNumber(num4);
						num7 = RoundCalculation.RoundNumber(num7);
						num12 = RoundCalculation.RoundNumber(num12);
						num13 = RoundCalculation.RoundNumber(num13);
					}
					_003C_003Ec__DisplayClass5_.order.bordItemCount = value;
					_003C_003Ec__DisplayClass5_.order.bordItemsAmount = num;
					_003C_003Ec__DisplayClass5_.order.bordSumAmount = num5;
					_003C_003Ec__DisplayClass5_.order.bordTax = num6;
					_003C_003Ec__DisplayClass5_.order.bordItemsQty = valueOrDefault12;
					_003C_003Ec__DisplayClass5_.order.bordItemsDiscount = num12;
					_003C_003Ec__DisplayClass5_.order.bordItemsTax = num13;
					_003C_003Ec__DisplayClass5_.order.bordTotalAmount = num7;
					string[] array = num7.ToString().Split(new char[1] { '.' });
					if (Enumerable.Count<string>((IEnumerable<string>)array) > 1 && !string.IsNullOrEmpty(array[1]))
					{
						array[1] = ((array[1].Length == 2) ? array[1] : array[1].Substring(0, 2));
					}
					if (CS_0024_003C_003E8__locals0.defLangID == 1065)
					{
						if (Enumerable.Any<string>((IEnumerable<string>)array))
						{
							_003C_003Ec__DisplayClass5_.order.bordTotalAmountStr = SayNumber.GetNumber(Convert.ToDouble(array[0]));
							if (Enumerable.Count<string>((IEnumerable<string>)array) > 1 && !string.IsNullOrEmpty(array[1]) && num7 > 0m && !string.IsNullOrEmpty(array[1]) && int.Parse(array[1]) > 0)
							{
								WSBuyOrder order = _003C_003Ec__DisplayClass5_.order;
								order.bordTotalAmountStr = order.bordTotalAmountStr + "." + SayNumber.GetNumber(Convert.ToDouble(array[1]));
							}
						}
					}
					else if (CS_0024_003C_003E8__locals0.defLangID == 1025)
					{
						if (Enumerable.Any<string>((IEnumerable<string>)array))
						{
							_003C_003Ec__DisplayClass5_.order.bordTotalAmountStr = SayNumber.GetNumberInArabic(Convert.ToDouble(array[0]));
							if (Enumerable.Count<string>((IEnumerable<string>)array) > 1 && !string.IsNullOrEmpty(array[1]) && num7 > 0m && !string.IsNullOrEmpty(array[1]) && int.Parse(array[1]) > 0)
							{
								WSBuyOrder order2 = _003C_003Ec__DisplayClass5_.order;
								order2.bordTotalAmountStr = order2.bordTotalAmountStr + "." + SayNumber.GetNumberInArabic(Convert.ToDouble(array[1]));
							}
						}
					}
					else if (Enumerable.Any<string>((IEnumerable<string>)array))
					{
						_003C_003Ec__DisplayClass5_.order.bordTotalAmountStr = SayNumber.GetNumberInEnglish(Convert.ToDouble(array[0]));
						if (Enumerable.Count<string>((IEnumerable<string>)array) > 1 && !string.IsNullOrEmpty(array[1]) && num7 > 0m && !string.IsNullOrEmpty(array[1]) && int.Parse(array[1]) > 0)
						{
							WSBuyOrder order3 = _003C_003Ec__DisplayClass5_.order;
							order3.bordTotalAmountStr = order3.bordTotalAmountStr + "." + SayNumber.GetNumberInEnglish(Convert.ToDouble(array[1]));
						}
					}
					_003C_003Ec__DisplayClass5_.order.bordDiscount = num4;
					_003C_003Ec__DisplayClass5_.order.Month1 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					cRMTabelEntities.Entry(_003C_003Ec__DisplayClass5_.order).State = EntityState.Modified;
					cRMTabelEntities.Configuration.ValidateOnSaveEnabled = false;
					cRMTabelEntities.SaveChanges();
					cRMTabelEntities.Configuration.ValidateOnSaveEnabled = true;
					using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							_003C_003Ec__DisplayClass5_2 _003C_003Ec__DisplayClass5_2 = new _003C_003Ec__DisplayClass5_2();
							_003C_003Ec__DisplayClass5_2.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass5_;
							_003C_003Ec__DisplayClass5_2.lang = enumerator.Current;
							DbSet<WSBuyOrder_Lang> wSBuyOrder_Lang = cRMTabelEntities.WSBuyOrder_Lang;
							val = Expression.Parameter(typeof(WSBuyOrder_Lang), "c");
							WSBuyOrder_Lang wSBuyOrder_Lang2 = Queryable.FirstOrDefault<WSBuyOrder_Lang>((IQueryable<WSBuyOrder_Lang>)wSBuyOrder_Lang, Expression.Lambda<Func<WSBuyOrder_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass5_2, typeof(_003C_003Ec__DisplayClass5_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass5_2, typeof(_003C_003Ec__DisplayClass5_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (wSBuyOrder_Lang2 != null)
							{
								if (wSBuyOrder_Lang2.LanguageID == 1065)
								{
									if (Enumerable.Any<string>((IEnumerable<string>)array))
									{
										wSBuyOrder_Lang2.bordTotalAmountStr = SayNumber.GetNumber(Convert.ToDouble(array[0]));
										if (Enumerable.Count<string>((IEnumerable<string>)array) > 1 && !string.IsNullOrEmpty(array[1]) && num7 > 0m && !string.IsNullOrEmpty(array[1]) && int.Parse(array[1]) > 0)
										{
											WSBuyOrder_Lang wSBuyOrder_Lang3 = wSBuyOrder_Lang2;
											wSBuyOrder_Lang3.bordTotalAmountStr = wSBuyOrder_Lang3.bordTotalAmountStr + "." + SayNumber.GetNumber(Convert.ToDouble(array[1]));
										}
									}
								}
								else if (wSBuyOrder_Lang2.LanguageID == 1025)
								{
									if (Enumerable.Any<string>((IEnumerable<string>)array))
									{
										wSBuyOrder_Lang2.bordTotalAmountStr = SayNumber.GetNumberInArabic(Convert.ToDouble(array[0]));
										if (Enumerable.Count<string>((IEnumerable<string>)array) > 1 && !string.IsNullOrEmpty(array[1]) && num7 > 0m && !string.IsNullOrEmpty(array[1]) && int.Parse(array[1]) > 0)
										{
											WSBuyOrder_Lang wSBuyOrder_Lang4 = wSBuyOrder_Lang2;
											wSBuyOrder_Lang4.bordTotalAmountStr = wSBuyOrder_Lang4.bordTotalAmountStr + "." + SayNumber.GetNumberInArabic(Convert.ToDouble(array[1]));
										}
									}
								}
								else if (Enumerable.Any<string>((IEnumerable<string>)array))
								{
									wSBuyOrder_Lang2.bordTotalAmountStr = SayNumber.GetNumberInEnglish(Convert.ToDouble(array[0]));
									if (Enumerable.Count<string>((IEnumerable<string>)array) > 1 && !string.IsNullOrEmpty(array[1]) && num7 > 0m && !string.IsNullOrEmpty(array[1]) && int.Parse(array[1]) > 0)
									{
										WSBuyOrder_Lang wSBuyOrder_Lang5 = wSBuyOrder_Lang2;
										wSBuyOrder_Lang5.bordTotalAmountStr = wSBuyOrder_Lang5.bordTotalAmountStr + "." + SayNumber.GetNumberInEnglish(Convert.ToDouble(array[1]));
									}
								}
								cRMTabelEntities.Entry(wSBuyOrder_Lang2).State = EntityState.Modified;
								cRMTabelEntities.SaveChanges();
								continue;
							}
							wSBuyOrder_Lang2 = new WSBuyOrder_Lang();
							wSBuyOrder_Lang2.LanguageID = _003C_003Ec__DisplayClass5_2.lang.LanguageID;
							wSBuyOrder_Lang2.BuyOrderID = _003C_003Ec__DisplayClass5_2.CS_0024_003C_003E8__locals1.order.BuyOrderID;
							if (wSBuyOrder_Lang2.LanguageID == 1065)
							{
								if (Enumerable.Any<string>((IEnumerable<string>)array))
								{
									wSBuyOrder_Lang2.bordTotalAmountStr = SayNumber.GetNumber(Convert.ToDouble(array[0]));
									if (Enumerable.Count<string>((IEnumerable<string>)array) > 1 && !string.IsNullOrEmpty(array[1]) && num7 > 0m && !string.IsNullOrEmpty(array[1]) && int.Parse(array[1]) > 0)
									{
										WSBuyOrder_Lang wSBuyOrder_Lang6 = wSBuyOrder_Lang2;
										wSBuyOrder_Lang6.bordTotalAmountStr = wSBuyOrder_Lang6.bordTotalAmountStr + "." + SayNumber.GetNumber(Convert.ToDouble(array[1]));
									}
								}
							}
							else if (wSBuyOrder_Lang2.LanguageID == 1025)
							{
								if (Enumerable.Any<string>((IEnumerable<string>)array))
								{
									wSBuyOrder_Lang2.bordTotalAmountStr = SayNumber.GetNumberInArabic(Convert.ToDouble(array[0]));
									if (Enumerable.Count<string>((IEnumerable<string>)array) > 1 && !string.IsNullOrEmpty(array[1]) && num7 > 0m && !string.IsNullOrEmpty(array[1]) && int.Parse(array[1]) > 0)
									{
										WSBuyOrder_Lang wSBuyOrder_Lang7 = wSBuyOrder_Lang2;
										wSBuyOrder_Lang7.bordTotalAmountStr = wSBuyOrder_Lang7.bordTotalAmountStr + "." + SayNumber.GetNumberInArabic(Convert.ToDouble(array[1]));
									}
								}
							}
							else if (Enumerable.Any<string>((IEnumerable<string>)array))
							{
								wSBuyOrder_Lang2.bordTotalAmountStr = SayNumber.GetNumberInEnglish(Convert.ToDouble(array[0]));
								if (Enumerable.Count<string>((IEnumerable<string>)array) > 1 && !string.IsNullOrEmpty(array[1]) && num7 > 0m && !string.IsNullOrEmpty(array[1]) && int.Parse(array[1]) > 0)
								{
									WSBuyOrder_Lang wSBuyOrder_Lang8 = wSBuyOrder_Lang2;
									wSBuyOrder_Lang8.bordTotalAmountStr = wSBuyOrder_Lang8.bordTotalAmountStr + "." + SayNumber.GetNumberInEnglish(Convert.ToDouble(array[1]));
								}
							}
							cRMTabelEntities.WSBuyOrder_Lang.Add(wSBuyOrder_Lang2);
							cRMTabelEntities.SaveChanges();
						}
					}
					result = SetPaymentStatus(_003C_003Ec__DisplayClass5_.order);
				}
				else
				{
					result = true;
				}
			}
			if (CS_0024_003C_003E8__locals0.orderId != 0)
			{
				cRMSpIIEntities.WSspCalcAndUpdateBuyOrderAmountsCurrency(CS_0024_003C_003E8__locals0.orderId, lCID, CS_0024_003C_003E8__locals0.defLangID);
			}
			if (CS_0024_003C_003E8__locals0.orderId != 0)
			{
				short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
				cRMSpIIEntities.WSspCalcAndUpdateOrderAmountsByBordId(CS_0024_003C_003E8__locals0.orderId, value3, lCID, CS_0024_003C_003E8__locals0.defLangID);
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

	public static bool SetPaymentStatus(WSBuyOrder order)
	{
		return SetPaymentStatus(0, order);
	}

	public static bool SetPaymentStatus(int orderId)
	{
		return SetPaymentStatus(orderId, null);
	}

	private static bool SetPaymentStatus(int orderId, WSBuyOrder order)
	{
		bool result = false;
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		CRMTabelEntities cRMTabelEntities = new CRMTabelEntities();
		try
		{
			if (order == null)
			{
				order = cRMTabelEntities.WSBuyOrder.Find(orderId);
			}
			orderId = order.BuyOrderID;
			WSspReturnSumBuyOrderPay_Result wSspReturnSumBuyOrderPay_Result = Enumerable.FirstOrDefault<WSspReturnSumBuyOrderPay_Result>((IEnumerable<WSspReturnSumBuyOrderPay_Result>)Enumerable.ToList<WSspReturnSumBuyOrderPay_Result>((IEnumerable<WSspReturnSumBuyOrderPay_Result>)cRMSpEntities.WSspReturnSumBuyOrderPay(orderId)));
			if (wSspReturnSumBuyOrderPay_Result != null)
			{
				if (order.bordStatusId.GetValueOrDefault() == 4 || order.bordStatusId.GetValueOrDefault() == 5)
				{
					return true;
				}
				decimal? sumbordpayAmount = wSspReturnSumBuyOrderPay_Result.sumbordpayAmount;
				if ((sumbordpayAmount.GetValueOrDefault() == default(decimal)) & sumbordpayAmount.HasValue)
				{
					if (order.bordStatusId.GetValueOrDefault() == 1)
					{
						return true;
					}
					cRMSpEntities.WSspUpdateBuyOrderStatus(orderId, 1);
				}
				else if (order.bordTotalAmount > wSspReturnSumBuyOrderPay_Result.sumbordpayAmount)
				{
					if (order.bordStatusId.GetValueOrDefault() == 2)
					{
						return true;
					}
					cRMSpEntities.WSspUpdateBuyOrderStatus(orderId, 2);
				}
				else if (order.bordTotalAmount <= wSspReturnSumBuyOrderPay_Result.sumbordpayAmount)
				{
					if (order.bordStatusId.GetValueOrDefault() == 3)
					{
						return true;
					}
					cRMSpEntities.WSspUpdateBuyOrderStatus(orderId, 3);
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

	public static WSspReturnDocFromOrder_Result ReturnDocFromOrder(int borderId)
	{
		WSspReturnDocFromOrder_Result result = null;
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			result = Enumerable.FirstOrDefault<WSspReturnDocFromOrder_Result>((IEnumerable<WSspReturnDocFromOrder_Result>)Enumerable.ToList<WSspReturnDocFromOrder_Result>((IEnumerable<WSspReturnDocFromOrder_Result>)cRMSpEntities.WSspReturnDocFromOrder(borderId, lCID, result2)));
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

	public static bool AutoIssueDocFromBord(int buyorderId, int userId, ref string refResult, int langId = 0, int userLastCId = 0)
	{
		bool result = false;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		int value = ((langId > 0) ? langId : result2);
		CRMSpEntities cRMSpEntities = null;
		CRMSpIIEntities cRMSpIIEntities = null;
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
			cRMSpIIEntities = new CRMSpIIEntities();
			if (VersionBuyer.WareHouse && UserLogin.IsUserAccessByUserId("frmBuyOrder", "actIssueDocAuto", userId, userLastCId))
			{
				if (Enumerable.FirstOrDefault<WSspSelectBuyOrderById_Result>((IEnumerable<WSspSelectBuyOrderById_Result>)cRMSpIIEntities.WSspSelectBuyOrderById(buyorderId, value, result2)) != null)
				{
					if (num == 0)
					{
						WSspReturnDocFromOrder_Result wSspReturnDocFromOrder_Result = new WSspReturnDocFromOrder_Result();
						string text3 = "";
						List<WSspReturnDocFromOrder_Result> list = Enumerable.ToList<WSspReturnDocFromOrder_Result>((IEnumerable<WSspReturnDocFromOrder_Result>)cRMSpEntities.WSspReturnDocFromOrder(buyorderId, value, result2));
						if (list != null && Enumerable.Any<WSspReturnDocFromOrder_Result>((IEnumerable<WSspReturnDocFromOrder_Result>)list))
						{
							wSspReturnDocFromOrder_Result = Enumerable.LastOrDefault<WSspReturnDocFromOrder_Result>((IEnumerable<WSspReturnDocFromOrder_Result>)list);
							if (list.Count > 1)
							{
								foreach (WSspReturnDocFromOrder_Result item2 in list)
								{
									text3 = text3 + item2.DocNumber + ",";
								}
								if (!string.IsNullOrEmpty(text3) && text3.EndsWith(","))
								{
									text3 = text3.TrimEnd(new char[1] { ',' });
								}
								num++;
								text = Labels.Error + " !!<br>" + Messages.msgIssueDocFormBuyOrderOfType + " " + wSspReturnDocFromOrder_Result.Opr + "<br>" + Messages.msgIssueDocFormBuyOrderWithNumber + " " + text3 + "<br>" + Messages.msgIssueDocFormBuyOrderDate + " " + PersianDate.GetFormatetdDate(wSspReturnDocFromOrder_Result.DocDate) + "<br>" + Messages.msgIssueDocFormBuyOrderInDate + " " + PersianDate.GetFormatetdDate(wSspReturnDocFromOrder_Result.RegisterDatePersian) + "<br>" + Messages.msgIssueDocFormBuyOrderByUser + " " + wSspReturnDocFromOrder_Result.UserName + "<br>" + Messages.msgIssueDocFormBuyOrderBeenIissued + "|" + wSspReturnDocFromOrder_Result.DocID + "|" + wSspReturnDocFromOrder_Result.OprType;
							}
						}
					}
					List<WSspSelectBuyOrderItems_Result> list2 = Enumerable.ToList<WSspSelectBuyOrderItems_Result>((IEnumerable<WSspSelectBuyOrderItems_Result>)cRMSpEntities.WSspSelectBuyOrderItems(buyorderId, value, result2));
					List<DocIdKeyValueViewModel> list3 = new List<DocIdKeyValueViewModel>();
					string text4 = "";
					int result3 = 0;
					if (list2 != null && Enumerable.Any<WSspSelectBuyOrderItems_Result>((IEnumerable<WSspSelectBuyOrderItems_Result>)list2))
					{
						WSspSelectBuyOrderItems_Result wSspSelectBuyOrderItems_Result = Enumerable.FirstOrDefault<WSspSelectBuyOrderItems_Result>((IEnumerable<WSspSelectBuyOrderItems_Result>)list2);
						if (wSspSelectBuyOrderItems_Result != null)
						{
							int.TryParse(wSspSelectBuyOrderItems_Result.bordIWHId.ToString(), out result3);
						}
						foreach (WSspSelectBuyOrderItems_Result item3 in list2)
						{
							DocIdKeyValueViewModel item = new DocIdKeyValueViewModel
							{
								Id = item3.BuyOrderItemId.ToString(),
								Value = item3.bordIQuantity.GetValueOrDefault().ToString()
							};
							list3.Add(item);
						}
						if (Enumerable.Any<DocIdKeyValueViewModel>((IEnumerable<DocIdKeyValueViewModel>)list3))
						{
							foreach (DocIdKeyValueViewModel item4 in list3)
							{
								string id = item4.Id;
								_ = item4.Type;
								_ = item4.Tag;
								string value2 = item4.Value;
								int result4 = 0;
								int.TryParse(id, out result4);
								double result5 = 0.0;
								double.TryParse(value2, out result5);
								if (result5 > 0.0)
								{
									text4 = text4 + result4 + "," + result5 + "|";
								}
							}
						}
					}
					if (num == 0)
					{
						DateTime now = DateTime.Now;
						string docDate = now.ToString("yyyyMMdd", new PersianCulture());
						ObjectParameter objectParameter = new ObjectParameter("insertedDocID", 0);
						ObjectParameter objectParameter2 = new ObjectParameter("insertedDocNumber", 0);
						cRMSpEntities.WSspIssueDocFromBuyOrder(buyorderId, docDate, UserLogin.CurrentUser.UserId, short.Parse(now.ToString("MM", new PersianCulture())), Financial.Get().Id, result3, now.ToString("yyyyMMdd", new PersianCulture()), Configuration.AppType, objectParameter, objectParameter2, result2, text4, (userLastCId != 0) ? new int?(userLastCId) : null);
						int num2 = (int)objectParameter.Value;
						int num3 = (int)objectParameter2.Value;
						WSspReturnDocFromOrder_Result wSspReturnDocFromOrder_Result2 = new WSspReturnDocFromOrder_Result();
						List<WSspReturnDocFromOrder_Result> list4 = Enumerable.ToList<WSspReturnDocFromOrder_Result>((IEnumerable<WSspReturnDocFromOrder_Result>)cRMSpEntities.WSspReturnDocFromOrder(buyorderId, value, result2));
						string text5 = "";
						if (list4 != null && Enumerable.Any<WSspReturnDocFromOrder_Result>((IEnumerable<WSspReturnDocFromOrder_Result>)list4))
						{
							wSspReturnDocFromOrder_Result2 = Enumerable.LastOrDefault<WSspReturnDocFromOrder_Result>((IEnumerable<WSspReturnDocFromOrder_Result>)list4);
							if (list4.Count > 1)
							{
								foreach (WSspReturnDocFromOrder_Result item5 in list4)
								{
									text5 = text5 + item5.DocNumber + ",";
								}
								if (!string.IsNullOrEmpty(text5) && text5.EndsWith(","))
								{
									text5 = text5.TrimEnd(new char[1] { ',' });
								}
							}
						}
						else
						{
							wSspReturnDocFromOrder_Result2 = null;
						}
						if (wSspReturnDocFromOrder_Result2 != null)
						{
							if (string.IsNullOrEmpty(text5))
							{
								text5 = wSspReturnDocFromOrder_Result2.DocNumber.ToString();
							}
							text2 = num2 + "," + text5 + "," + wSspReturnDocFromOrder_Result2.OprType;
						}
						else
						{
							text2 = num2 + "," + num3 + ",1";
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
		finally
		{
			cRMSpEntities?.Dispose();
			cRMSpIIEntities?.Dispose();
		}
		return result;
	}

	public static bool IsSentToLinkAcc(int bordId)
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
			WSspSelectBuyOrderById_Result wSspSelectBuyOrderById_Result = Enumerable.FirstOrDefault<WSspSelectBuyOrderById_Result>((IEnumerable<WSspSelectBuyOrderById_Result>)cRMSpIIEntities.WSspSelectBuyOrderById(bordId, lCID, result2));
			if (wSspSelectBuyOrderById_Result != null)
			{
				bool.TryParse(wSspSelectBuyOrderById_Result.IsSentToLinkAcc.ToString(), out result);
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

	public static bool IsSentToLinkAccByAction(int bordId)
	{
		bool result = false;
		try
		{
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (!UserLogin.IsUserAccess("frmBuyOrder", "actChangeAfterSendToLinkAcc", currentUser))
			{
				result = IsSentToLinkAcc(bordId);
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
		CRMSpIIEntities cRMSpIIEntities = new CRMSpIIEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			WSspSelectBuyOrderPaymentsWithId_Result wSspSelectBuyOrderPaymentsWithId_Result = Enumerable.FirstOrDefault<WSspSelectBuyOrderPaymentsWithId_Result>((IEnumerable<WSspSelectBuyOrderPaymentsWithId_Result>)cRMSpIIEntities.WSspSelectBuyOrderPaymentsWithId(payId, lCID, result2));
			if (wSspSelectBuyOrderPaymentsWithId_Result != null)
			{
				bool.TryParse(wSspSelectBuyOrderPaymentsWithId_Result.IsSentToLinkAcc.ToString(), out result);
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

	public static bool PayIsSentToLinkAccByAction(int payId)
	{
		bool result = false;
		try
		{
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (!UserLogin.IsUserAccess("frmBuyOrder", "actChangeAfterSendToLinkAcc", currentUser))
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

	public static int? GetBordCId(int bordId)
	{
		int? result = null;
		CRMSpIIEntities cRMSpIIEntities = new CRMSpIIEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			WSspSelectBuyOrderById_Result wSspSelectBuyOrderById_Result = Enumerable.FirstOrDefault<WSspSelectBuyOrderById_Result>((IEnumerable<WSspSelectBuyOrderById_Result>)cRMSpIIEntities.WSspSelectBuyOrderById(bordId, lCID, result2));
			if (wSspSelectBuyOrderById_Result != null)
			{
				result = wSspSelectBuyOrderById_Result.bordCId;
				return result;
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

	public static int? GetBordItemCId(int bordItemId)
	{
		int? result = null;
		CRMSpIIEntities cRMSpIIEntities = new CRMSpIIEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			WSspSelectBuyOrderItemsById_Result wSspSelectBuyOrderItemsById_Result = Enumerable.FirstOrDefault<WSspSelectBuyOrderItemsById_Result>((IEnumerable<WSspSelectBuyOrderItemsById_Result>)cRMSpIIEntities.WSspSelectBuyOrderItemsById(bordItemId, lCID, result2));
			if (wSspSelectBuyOrderItemsById_Result != null)
			{
				result = wSspSelectBuyOrderItemsById_Result.bordICId;
				return result;
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

	public static List<WSspSelectBuyOrderOpr_Result> SelectBuyOrderOpr(int userId = -1, int currLangId = 0, int defLangId = 0)
	{
		List<WSspSelectBuyOrderOpr_Result> result = new List<WSspSelectBuyOrderOpr_Result>();
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
			result = Enumerable.ToList<WSspSelectBuyOrderOpr_Result>((IEnumerable<WSspSelectBuyOrderOpr_Result>)cRMSpEntities.WSspSelectBuyOrderOpr(currLangId, defLangId, userId));
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

	public static bool SendToLinkAccNeedVerify(int bordId, ref string errorMessage)
	{
		bool result = true;
		CRMSpIIEntities cRMSpIIEntities = new CRMSpIIEntities();
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
			if (UserLogin.IsUserAccess("frmBuyOrder", actionName, UserLogin.CurrentUser))
			{
				WSspSelectBuyOrderById_Result wSspSelectBuyOrderById_Result = Enumerable.FirstOrDefault<WSspSelectBuyOrderById_Result>((IEnumerable<WSspSelectBuyOrderById_Result>)cRMSpIIEntities.WSspSelectBuyOrderById(bordId, lCID, result2));
				if (wSspSelectBuyOrderById_Result != null && !wSspSelectBuyOrderById_Result.bordIsVerified.GetValueOrDefault())
				{
					result = false;
					errorMessage = string.Format(Messages.msgErrorSendToLinkAccNeedVerifyByNumber, Labels.lblBOrd, wSspSelectBuyOrderById_Result.bordNumber.ToString(), linkAccSystemTitle);
				}
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

	public static bool IsVerified(int bordId)
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
			WSspSelectBuyOrderById_Result wSspSelectBuyOrderById_Result = Enumerable.FirstOrDefault<WSspSelectBuyOrderById_Result>((IEnumerable<WSspSelectBuyOrderById_Result>)cRMSpIIEntities.WSspSelectBuyOrderById(bordId, lCID, result2));
			if (wSspSelectBuyOrderById_Result != null)
			{
				result = wSspSelectBuyOrderById_Result.bordIsVerified.GetValueOrDefault();
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

	public static string ControlBuyOrderItemsSoldStock(int bordId, int mode, string txt = "", string bordItemJson = "")
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
			int currUserId = 0;
			int result3 = 0;
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (currentUser != null)
			{
				int.TryParse(currentUser.UserLastCId.ToString(), out result3);
				currUserId = currentUser.UserId;
			}
			int id = Financial.Get().Id;
			int cmpId = 0;
			string format = "msgErrorUnableIssueOrderFormBuyOrderPrdNotSoldStock".OrderMessages();
			string text = "";
			string text2 = "";
			bool flag = false;
			WSspSelectBuyOrderById_Result wSspSelectBuyOrderById_Result = Enumerable.FirstOrDefault<WSspSelectBuyOrderById_Result>((IEnumerable<WSspSelectBuyOrderById_Result>)cRMSpIIEntities.WSspSelectBuyOrderById(bordId, lCID, result2));
			if (wSspSelectBuyOrderById_Result != null)
			{
				cmpId = wSspSelectBuyOrderById_Result.bordCompanyId;
				result3 = wSspSelectBuyOrderById_Result.bordCId.GetValueOrDefault();
			}
			switch (mode)
			{
			case 1:
				format = "msgErrorUnableIssueOrderFormBuyOrderPrdNotSoldStock".OrderMessages();
				text = "frmIssueOrderFromBuyOrder";
				text2 = "actCanNotIssueOrderWithNoStockFromSold";
				break;
			case 2:
				format = "msgErrorUnableAddBuyOrderToOrderPrdNotSoldStock".OrderMessages();
				text = "frmIssueOrderFromBuyOrder";
				text2 = "actCanNotIssueOrderWithNoStockFromSold";
				break;
			}
			if (string.IsNullOrWhiteSpace(text) && string.IsNullOrWhiteSpace(text2))
			{
				flag = true;
			}
			else if (UserLogin.IsUserAccess(text, text2, currentUser))
			{
				flag = true;
			}
			if (flag)
			{
				List<WSspControlBuyOrderItemsSoldStock_Result> list = Enumerable.ToList<WSspControlBuyOrderItemsSoldStock_Result>((IEnumerable<WSspControlBuyOrderItemsSoldStock_Result>)cRMSpIIIEntities.WSspControlBuyOrderItemsSoldStock(bordId, bordItemJson, result3, 1, id, lCID, result2));
				if (list != null && Enumerable.Any<WSspControlBuyOrderItemsSoldStock_Result>((IEnumerable<WSspControlBuyOrderItemsSoldStock_Result>)list))
				{
					CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
					bool flag2 = false;
					int num = 0;
					bool flag3 = false;
					if (cRMspSelectCrmsysSetting_Result != null)
					{
						flag2 = ((cRMspSelectCrmsysSetting_Result.InvStockFromLink.HasValue && cRMspSelectCrmsysSetting_Result.InvStockFromLink.GetValueOrDefault()) ? true : false);
						num = cRMspSelectCrmsysSetting_Result.LinkAccSystemId.GetValueOrDefault();
					}
					foreach (WSspControlBuyOrderItemsSoldStock_Result item in list)
					{
						new ProductController();
						string text3 = "";
						double result4 = 0.0;
						double valueOrDefault = item.bordIQuantity.GetValueOrDefault();
						item.RemainCountAllWH.GetValueOrDefault();
						double valueOrDefault2 = item.SoldOrdQuantity.GetValueOrDefault();
						double valueOrDefault3 = item.TracingRemainCount.GetValueOrDefault();
						if (flag2 && num > 0)
						{
							text3 = OtherSystems.GetPrdQuantity(currUserId, item.bordIPrdId.GetValueOrDefault(), item.bordIWHId.GetValueOrDefault(), item.bordILinkAccWHIdStr ?? "", item.bordITracing ?? "", cmpId);
							if (!string.IsNullOrEmpty(text3))
							{
								if (text3 == Labels.frmError)
								{
									text3 = "0";
								}
								if (text3 != Labels.frmError)
								{
									double.TryParse(text3, out result4);
									result4 -= valueOrDefault2;
									if (result4 < valueOrDefault)
									{
										result = string.Format(format, item.PrdName ?? "");
										return result;
									}
									flag3 = true;
								}
							}
						}
						if (!flag3 && valueOrDefault3 - valueOrDefault2 < valueOrDefault)
						{
							result = string.Format(format, item.PrdName ?? "");
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

	public static string CheckBeforeVerification(int bordId, string txt = "", int mode = 1)
	{
		string result = "";
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		CRMSpIEntities cRMSpIEntities = new CRMSpIEntities();
		CRMSpIIEntities cRMSpIIEntities = new CRMSpIIEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (currentUser != null)
			{
				_ = currentUser.UserLastCId;
				_ = currentUser.UserId;
			}
			if (string.IsNullOrWhiteSpace(txt))
			{
				txt = Labels.lblBOrd;
			}
			if (mode == 0)
			{
				mode = 1;
			}
			WSspSelectBuyOrderById_Result wSspSelectBuyOrderById_Result = Enumerable.FirstOrDefault<WSspSelectBuyOrderById_Result>((IEnumerable<WSspSelectBuyOrderById_Result>)cRMSpIIEntities.WSspSelectBuyOrderById(bordId, lCID, result2));
			if (wSspSelectBuyOrderById_Result != null)
			{
				if (!UserLogin.IsUserAccess("frmBuyOrder", "actVerifyAfterCancel", currentUser) && (wSspSelectBuyOrderById_Result.bordStatusId.GetValueOrDefault() == 4 || wSspSelectBuyOrderById_Result.bordStatusId.GetValueOrDefault() == 5))
				{
					result = string.Format(Messages.msgErrorUnableVerifyBuyOrderCanceledByParam, txt);
					return result;
				}
			}
			else
			{
				result = Messages.ErrorNotFound;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
			cRMSpIEntities?.Dispose();
			cRMSpIIEntities?.Dispose();
		}
		return result;
	}
}
