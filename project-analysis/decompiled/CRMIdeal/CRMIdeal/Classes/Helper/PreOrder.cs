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
using CRM.General.Security;
using CRM.General.Utilities;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Areas.OtherSystems.Controllers;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Cache.User;
using CRMIdeal.Classes.Common;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Newtonsoft.Json;

namespace CRMIdeal.Classes.Helper;

public class PreOrder
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass2_0
	{
		public int preOrderId;

		public WSPreOrder model;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__3;

		internal bool _003CCalcAndSetPreOrderAmounts_003Eb__3(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass2_1
	{
		public WSPreOrder preOrder;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass2_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass2_1 CS_0024_003C_003E8__locals1;
	}

	public static bool CalcAndSetPreOrderAmounts(WSPreOrder preOrder, bool autoCalcPriceNoChangeDiscount = false, bool autoCalcPriceNoChangeTax = false)
	{
		return CalcAndSetPreOrderAmounts(0, preOrder, autoCalcPriceNoChangeDiscount, autoCalcPriceNoChangeTax);
	}

	public static bool CalcAndSetPreOrderAmounts(int preOrderId, bool autoCalcPriceNoChangeDiscount = false, bool autoCalcPriceNoChangeTax = false)
	{
		return CalcAndSetPreOrderAmounts(preOrderId, null, autoCalcPriceNoChangeDiscount, autoCalcPriceNoChangeTax);
	}

	private static bool CalcAndSetPreOrderAmounts(int preOrderId, WSPreOrder model, bool autoCalcPriceNoChangeDiscount = false, bool autoCalcPriceNoChangeTax = false)
	{
		_003C_003Ec__DisplayClass2_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass2_0();
		CS_0024_003C_003E8__locals0.preOrderId = preOrderId;
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
			_003C_003Ec__DisplayClass2_1 _003C_003Ec__DisplayClass2_ = new _003C_003Ec__DisplayClass2_1();
			_003C_003Ec__DisplayClass2_.preOrder = CS_0024_003C_003E8__locals0.model;
			if (_003C_003Ec__DisplayClass2_.preOrder == null)
			{
				DbSet<WSPreOrder> wSPreOrder = cRMTabelEntities.WSPreOrder;
				ParameterExpression val = Expression.Parameter(typeof(WSPreOrder), "c");
				_003C_003Ec__DisplayClass2_.preOrder = Queryable.FirstOrDefault<WSPreOrder>((IQueryable<WSPreOrder>)wSPreOrder, Expression.Lambda<Func<WSPreOrder, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass2_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			}
			else
			{
				DbSet<WSPreOrder> wSPreOrder2 = cRMTabelEntities.WSPreOrder;
				ParameterExpression val = Expression.Parameter(typeof(WSPreOrder), "c");
				_003C_003Ec__DisplayClass2_.preOrder = Queryable.FirstOrDefault<WSPreOrder>((IQueryable<WSPreOrder>)wSPreOrder2, Expression.Lambda<Func<WSPreOrder, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass2_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			}
			CS_0024_003C_003E8__locals0.preOrderId = _003C_003Ec__DisplayClass2_.preOrder.PreOrderID;
			if (CS_0024_003C_003E8__locals0.preOrderId != 0)
			{
				ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
				DateTime now = DateTime.Now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short value = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				_ = Financial.Get().Id;
				int userId = UserLogin.CurrentUser.UserId;
				cRMSpIIEntities.WSspAutoCalcAndUpdatePreOrderItemPrice(CS_0024_003C_003E8__locals0.preOrderId, userId, value, now, registerDatePersian, appType, CS_0024_003C_003E8__locals0.defLangID, autoCalcPriceNoChangeDiscount, autoCalcPriceNoChangeTax, objectParameter);
				if (objectParameter != null && objectParameter.Value != null)
				{
					string text = objectParameter.Value.ToString();
					if (!string.IsNullOrWhiteSpace(text))
					{
						Public.InsTextToElmah(text);
					}
				}
			}
			if (CS_0024_003C_003E8__locals0.preOrderId != 0)
			{
				ObjectParameter result2 = new ObjectParameter("result", 0);
				short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
				cRMSpIIEntities.WSspCalcAndUpdatePreOrderItemsTax(CS_0024_003C_003E8__locals0.preOrderId, value2, result2);
			}
			WSfnReturnPreOrderSumFooter_Result wSfnReturnPreOrderSumFooter_Result = Enumerable.FirstOrDefault<WSfnReturnPreOrderSumFooter_Result>((IEnumerable<WSfnReturnPreOrderSumFooter_Result>)Enumerable.ToList<WSfnReturnPreOrderSumFooter_Result>((IEnumerable<WSfnReturnPreOrderSumFooter_Result>)cRMSpEntities.WSfnReturnPreOrderSumFooter(CS_0024_003C_003E8__locals0.preOrderId)));
			if (wSfnReturnPreOrderSumFooter_Result != null)
			{
				decimal num = Convert.ToDecimal(wSfnReturnPreOrderSumFooter_Result.SumPriceAmount.GetValueOrDefault());
				if (num >= 0m)
				{
					decimal num2 = num;
					decimal valueOrDefault = _003C_003Ec__DisplayClass2_.preOrder.pordInstallAmount.GetValueOrDefault();
					decimal num3 = _003C_003Ec__DisplayClass2_.preOrder.pordDiscount.GetValueOrDefault();
					if (_003C_003Ec__DisplayClass2_.preOrder.pordDiscountPercent.HasValue)
					{
						decimal valueOrDefault2 = _003C_003Ec__DisplayClass2_.preOrder.pordDiscountPercent.GetValueOrDefault();
						if (valueOrDefault2 > 0m)
						{
							num3 = Convert.ToDecimal(num * valueOrDefault2) / 100m;
						}
					}
					decimal valueOrDefault3 = _003C_003Ec__DisplayClass2_.preOrder.pordTransportation.GetValueOrDefault();
					decimal valueOrDefault4 = _003C_003Ec__DisplayClass2_.preOrder.pordRound.GetValueOrDefault();
					decimal num4 = num2 + valueOrDefault - num3;
					decimal valueOrDefault5 = _003C_003Ec__DisplayClass2_.preOrder.pordTaxIndex.GetValueOrDefault();
					decimal num5 = ((_003C_003Ec__DisplayClass2_.preOrder.pordCalculateTax.HasValue && _003C_003Ec__DisplayClass2_.preOrder.pordCalculateTax.GetValueOrDefault()) ? (num4 * valueOrDefault5 / 100m) : 0m);
					decimal num6 = num4 + num5 + valueOrDefault3 - valueOrDefault4;
					double valueOrDefault6 = wSfnReturnPreOrderSumFooter_Result.SumQuantity.GetValueOrDefault();
					decimal num7 = wSfnReturnPreOrderSumFooter_Result.TotalDiscountSum.GetValueOrDefault();
					decimal num8 = wSfnReturnPreOrderSumFooter_Result.TotalTaxSum.GetValueOrDefault();
					bool result3 = false;
					WSspSelectCurrencyUnitsWithId_Result wSspSelectCurrencyUnitsWithId_Result = Enumerable.FirstOrDefault<WSspSelectCurrencyUnitsWithId_Result>((IEnumerable<WSspSelectCurrencyUnitsWithId_Result>)cRMSpEntities.WSspSelectCurrencyUnitsWithId(_003C_003Ec__DisplayClass2_.preOrder.pordCurrencyUnitId, lCID, CS_0024_003C_003E8__locals0.defLangID));
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
					DbSet<WSPreOrderItems> wSPreOrderItems = cRMTabelEntities.WSPreOrderItems;
					ParameterExpression val = Expression.Parameter(typeof(WSPreOrderItems), "c");
					int value3 = Queryable.Count<WSPreOrderItems>((IQueryable<WSPreOrderItems>)wSPreOrderItems, Expression.Lambda<Func<WSPreOrderItems, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass2_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
					_003C_003Ec__DisplayClass2_.preOrder.pordItemCount = value3;
					_003C_003Ec__DisplayClass2_.preOrder.pordItemsAmount = num;
					_003C_003Ec__DisplayClass2_.preOrder.pordSumAmount = num4;
					_003C_003Ec__DisplayClass2_.preOrder.pordTax = num5;
					_003C_003Ec__DisplayClass2_.preOrder.pordItemsQty = valueOrDefault6;
					_003C_003Ec__DisplayClass2_.preOrder.pordItemsDiscount = num7;
					_003C_003Ec__DisplayClass2_.preOrder.pordItemsTax = num8;
					_003C_003Ec__DisplayClass2_.preOrder.pordTotalAmount = num6;
					string[] array = num6.ToString().Split(new char[1] { '.' });
					if (Enumerable.Count<string>((IEnumerable<string>)array) > 1 && !string.IsNullOrEmpty(array[1]))
					{
						array[1] = ((array[1].Length == 2) ? array[1] : array[1].Substring(0, 2));
					}
					if (CS_0024_003C_003E8__locals0.defLangID == 1065)
					{
						if (Enumerable.Any<string>((IEnumerable<string>)array))
						{
							_003C_003Ec__DisplayClass2_.preOrder.pordTotalAmountStr = SayNumber.GetNumber(Convert.ToDouble(array[0]));
							if (Enumerable.Count<string>((IEnumerable<string>)array) > 1 && !string.IsNullOrEmpty(array[1]) && num6 > 0m && !string.IsNullOrEmpty(array[1]) && int.Parse(array[1]) > 0)
							{
								WSPreOrder preOrder = _003C_003Ec__DisplayClass2_.preOrder;
								preOrder.pordTotalAmountStr = preOrder.pordTotalAmountStr + "." + SayNumber.GetNumber(Convert.ToDouble(array[1]));
							}
						}
					}
					else if (CS_0024_003C_003E8__locals0.defLangID == 1025)
					{
						if (Enumerable.Any<string>((IEnumerable<string>)array))
						{
							_003C_003Ec__DisplayClass2_.preOrder.pordTotalAmountStr = SayNumber.GetNumberInArabic(Convert.ToDouble(array[0]));
							if (Enumerable.Count<string>((IEnumerable<string>)array) > 1 && !string.IsNullOrEmpty(array[1]) && num6 > 0m && !string.IsNullOrEmpty(array[1]) && int.Parse(array[1]) > 0)
							{
								WSPreOrder preOrder2 = _003C_003Ec__DisplayClass2_.preOrder;
								preOrder2.pordTotalAmountStr = preOrder2.pordTotalAmountStr + "." + SayNumber.GetNumberInArabic(Convert.ToDouble(array[1]));
							}
						}
					}
					else if (Enumerable.Any<string>((IEnumerable<string>)array))
					{
						_003C_003Ec__DisplayClass2_.preOrder.pordTotalAmountStr = SayNumber.GetNumberInEnglish(Convert.ToDouble(array[0]));
						if (Enumerable.Count<string>((IEnumerable<string>)array) > 1 && !string.IsNullOrEmpty(array[1]) && num6 > 0m && !string.IsNullOrEmpty(array[1]) && int.Parse(array[1]) > 0)
						{
							WSPreOrder preOrder3 = _003C_003Ec__DisplayClass2_.preOrder;
							preOrder3.pordTotalAmountStr = preOrder3.pordTotalAmountStr + "." + SayNumber.GetNumberInEnglish(Convert.ToDouble(array[1]));
						}
					}
					_003C_003Ec__DisplayClass2_.preOrder.pordDiscount = num3;
					_003C_003Ec__DisplayClass2_.preOrder.Month1 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					cRMTabelEntities.Entry(_003C_003Ec__DisplayClass2_.preOrder).State = EntityState.Modified;
					cRMTabelEntities.Configuration.ValidateOnSaveEnabled = false;
					cRMTabelEntities.SaveChanges();
					cRMTabelEntities.Configuration.ValidateOnSaveEnabled = true;
					using List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator();
					while (enumerator.MoveNext())
					{
						_003C_003Ec__DisplayClass2_2 _003C_003Ec__DisplayClass2_2 = new _003C_003Ec__DisplayClass2_2();
						_003C_003Ec__DisplayClass2_2.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass2_;
						_003C_003Ec__DisplayClass2_2.lang = enumerator.Current;
						DbSet<WSPreOrder_Lang> wSPreOrder_Lang = cRMTabelEntities.WSPreOrder_Lang;
						val = Expression.Parameter(typeof(WSPreOrder_Lang), "c");
						WSPreOrder_Lang wSPreOrder_Lang2 = Queryable.FirstOrDefault<WSPreOrder_Lang>((IQueryable<WSPreOrder_Lang>)wSPreOrder_Lang, Expression.Lambda<Func<WSPreOrder_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass2_2, typeof(_003C_003Ec__DisplayClass2_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass2_2, typeof(_003C_003Ec__DisplayClass2_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
						if (wSPreOrder_Lang2 != null)
						{
							if (wSPreOrder_Lang2.LanguageID == 1065)
							{
								if (Enumerable.Any<string>((IEnumerable<string>)array))
								{
									wSPreOrder_Lang2.pordTotalAmountStr = SayNumber.GetNumber(Convert.ToDouble(array[0]));
									if (Enumerable.Count<string>((IEnumerable<string>)array) > 1 && !string.IsNullOrEmpty(array[1]) && num6 > 0m && !string.IsNullOrEmpty(array[1]) && int.Parse(array[1]) > 0)
									{
										WSPreOrder_Lang wSPreOrder_Lang3 = wSPreOrder_Lang2;
										wSPreOrder_Lang3.pordTotalAmountStr = wSPreOrder_Lang3.pordTotalAmountStr + "." + SayNumber.GetNumber(Convert.ToDouble(array[1]));
									}
								}
							}
							else if (wSPreOrder_Lang2.LanguageID == 1025)
							{
								if (Enumerable.Any<string>((IEnumerable<string>)array))
								{
									wSPreOrder_Lang2.pordTotalAmountStr = SayNumber.GetNumberInArabic(Convert.ToDouble(array[0]));
									if (Enumerable.Count<string>((IEnumerable<string>)array) > 1 && !string.IsNullOrEmpty(array[1]) && num6 > 0m && !string.IsNullOrEmpty(array[1]) && int.Parse(array[1]) > 0)
									{
										WSPreOrder_Lang wSPreOrder_Lang4 = wSPreOrder_Lang2;
										wSPreOrder_Lang4.pordTotalAmountStr = wSPreOrder_Lang4.pordTotalAmountStr + "." + SayNumber.GetNumberInArabic(Convert.ToDouble(array[1]));
									}
								}
							}
							else if (Enumerable.Any<string>((IEnumerable<string>)array))
							{
								wSPreOrder_Lang2.pordTotalAmountStr = SayNumber.GetNumberInEnglish(Convert.ToDouble(array[0]));
								if (Enumerable.Count<string>((IEnumerable<string>)array) > 1 && !string.IsNullOrEmpty(array[1]) && num6 > 0m && !string.IsNullOrEmpty(array[1]) && int.Parse(array[1]) > 0)
								{
									WSPreOrder_Lang wSPreOrder_Lang5 = wSPreOrder_Lang2;
									wSPreOrder_Lang5.pordTotalAmountStr = wSPreOrder_Lang5.pordTotalAmountStr + "." + SayNumber.GetNumberInEnglish(Convert.ToDouble(array[1]));
								}
							}
							cRMTabelEntities.Entry(wSPreOrder_Lang2).State = EntityState.Modified;
							cRMTabelEntities.SaveChanges();
							continue;
						}
						wSPreOrder_Lang2 = new WSPreOrder_Lang();
						wSPreOrder_Lang2.LanguageID = _003C_003Ec__DisplayClass2_2.lang.LanguageID;
						wSPreOrder_Lang2.PreOrderID = _003C_003Ec__DisplayClass2_2.CS_0024_003C_003E8__locals1.preOrder.PreOrderID;
						if (wSPreOrder_Lang2.LanguageID == 1065)
						{
							if (Enumerable.Any<string>((IEnumerable<string>)array))
							{
								wSPreOrder_Lang2.pordTotalAmountStr = SayNumber.GetNumber(Convert.ToDouble(array[0]));
								if (Enumerable.Count<string>((IEnumerable<string>)array) > 1 && !string.IsNullOrEmpty(array[1]) && num6 > 0m && !string.IsNullOrEmpty(array[1]) && int.Parse(array[1]) > 0)
								{
									WSPreOrder_Lang wSPreOrder_Lang6 = wSPreOrder_Lang2;
									wSPreOrder_Lang6.pordTotalAmountStr = wSPreOrder_Lang6.pordTotalAmountStr + "." + SayNumber.GetNumber(Convert.ToDouble(array[1]));
								}
							}
						}
						else if (wSPreOrder_Lang2.LanguageID == 1025)
						{
							if (Enumerable.Any<string>((IEnumerable<string>)array))
							{
								wSPreOrder_Lang2.pordTotalAmountStr = SayNumber.GetNumberInArabic(Convert.ToDouble(array[0]));
								if (Enumerable.Count<string>((IEnumerable<string>)array) > 1 && !string.IsNullOrEmpty(array[1]) && num6 > 0m && !string.IsNullOrEmpty(array[1]) && int.Parse(array[1]) > 0)
								{
									WSPreOrder_Lang wSPreOrder_Lang7 = wSPreOrder_Lang2;
									wSPreOrder_Lang7.pordTotalAmountStr = wSPreOrder_Lang7.pordTotalAmountStr + "." + SayNumber.GetNumberInArabic(Convert.ToDouble(array[1]));
								}
							}
						}
						else if (Enumerable.Any<string>((IEnumerable<string>)array))
						{
							wSPreOrder_Lang2.pordTotalAmountStr = SayNumber.GetNumberInEnglish(Convert.ToDouble(array[0]));
							if (Enumerable.Count<string>((IEnumerable<string>)array) > 1 && !string.IsNullOrEmpty(array[1]) && num6 > 0m && !string.IsNullOrEmpty(array[1]) && int.Parse(array[1]) > 0)
							{
								WSPreOrder_Lang wSPreOrder_Lang8 = wSPreOrder_Lang2;
								wSPreOrder_Lang8.pordTotalAmountStr = wSPreOrder_Lang8.pordTotalAmountStr + "." + SayNumber.GetNumberInEnglish(Convert.ToDouble(array[1]));
							}
						}
						cRMTabelEntities.WSPreOrder_Lang.Add(wSPreOrder_Lang2);
						cRMTabelEntities.SaveChanges();
					}
				}
				result = true;
			}
			result = SetPaymentStatus(_003C_003Ec__DisplayClass2_.preOrder);
			if (CS_0024_003C_003E8__locals0.preOrderId != 0)
			{
				cRMSpIIEntities.WSspCalcAndUpdatePreOrderAmountsCurrency(CS_0024_003C_003E8__locals0.preOrderId, lCID, CS_0024_003C_003E8__locals0.defLangID);
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

	public static bool IsFixed(int preOrderId, int? isEditAfterFixMode = null)
	{
		bool result = false;
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		CRMTabelEntities cRMTabelEntities = new CRMTabelEntities();
		try
		{
			WSPreOrder wSPreOrder = cRMTabelEntities.WSPreOrder.Find(preOrderId);
			if (wSPreOrder != null && wSPreOrder.pordIsFixed.HasValue && wSPreOrder.pordIsFixed.GetValueOrDefault())
			{
				result = true;
			}
			if (IsEditAfterFix(wSPreOrder.pordEditAfterFixInfoJs, preOrderId, isEditAfterFixMode))
			{
				result = false;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities.Dispose();
			cRMTabelEntities.Dispose();
		}
		return result;
	}

	public static bool IsEditAfterFix(string editAfterFixInfoJs = "", int preordId = 0, int? mode = null)
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
			if (string.IsNullOrWhiteSpace(editAfterFixInfoJs) && preordId != 0)
			{
				WSspSelectPreOrderWithId_Result wSspSelectPreOrderWithId_Result = Enumerable.FirstOrDefault<WSspSelectPreOrderWithId_Result>((IEnumerable<WSspSelectPreOrderWithId_Result>)cRMSpEntities.WSspSelectPreOrderWithId(preordId, lCID, result2));
				if (wSspSelectPreOrderWithId_Result != null)
				{
					editAfterFixInfoJs = wSspSelectPreOrderWithId_Result.pordEditAfterFixInfoJs;
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

	public static bool CheckCheckPreOrderHaveTax(int pordId)
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
			if (pordId != 0)
			{
				WSspCheckPreOrderHaveTax_Result wSspCheckPreOrderHaveTax_Result = Enumerable.FirstOrDefault<WSspCheckPreOrderHaveTax_Result>((IEnumerable<WSspCheckPreOrderHaveTax_Result>)cRMSpIEntities.WSspCheckPreOrderHaveTax(pordId));
				decimal result3 = default(decimal);
				decimal result4 = default(decimal);
				if (wSspCheckPreOrderHaveTax_Result != null)
				{
					decimal.TryParse(wSspCheckPreOrderHaveTax_Result.pordTax.ToString(), out result3);
					decimal.TryParse(wSspCheckPreOrderHaveTax_Result.pordItemsTax.ToString(), out result4);
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

	public static bool AddUserMoneyBagFormPord(int pordId)
	{
		bool result = false;
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		CRMSpIIEntities cRMSpIIEntities = new CRMSpIIEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
			if (defLangID <= 0)
			{
				defLangID = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			if (pordId != 0)
			{
				DateTime now = DateTime.Now;
				DateTime value = now;
				string text = now.ToString("yyyyMMdd", new PersianCulture());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				short value3 = short.Parse(Financial.Get().Id.ToString());
				int userId = UserLogin.CurrentUser.UserId;
				long result2 = 0L;
				int result3 = 0;
				WSspSelectPreOrderWithId_Result wSspSelectPreOrderWithId_Result = Enumerable.FirstOrDefault<WSspSelectPreOrderWithId_Result>((IEnumerable<WSspSelectPreOrderWithId_Result>)cRMSpEntities.WSspSelectPreOrderWithId(pordId, lCID, defLangID));
				if (wSspSelectPreOrderWithId_Result != null)
				{
					long.TryParse(wSspSelectPreOrderWithId_Result.pordNumber.ToString(), out result2);
					int.TryParse(wSspSelectPreOrderWithId_Result.pordReferUserId.ToString(), out result3);
				}
				string uMnBgDesc = "";
				string uMnBgDesc_Lang = "";
				List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
				foreach (Languages item in Enumerable.ToList<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get()))
				{
					CommonMultiLanguageViewModel commonMultiLanguageViewModel = new CommonMultiLanguageViewModel();
					commonMultiLanguageViewModel.LanguageId = item.LanguageID;
					commonMultiLanguageViewModel.Value = MyResource.GetResourceString("lblPOrd", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly) + " (" + result2 + ")";
					list.Add(commonMultiLanguageViewModel);
				}
				if (list != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list))
				{
					uMnBgDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
					uMnBgDesc_Lang = "";
					if (list != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list))
					{
						uMnBgDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel m) => m.LanguageId != defLangID))));
					}
				}
				string uMnBgDescForUsage = "";
				string uMnBgDescForUsage_Lang = "";
				List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
				foreach (Languages item2 in Enumerable.ToList<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get()))
				{
					CommonMultiLanguageViewModel commonMultiLanguageViewModel2 = new CommonMultiLanguageViewModel();
					commonMultiLanguageViewModel2.LanguageId = item2.LanguageID;
					string arg = MyResource.GetResourceString("lblPOrd", item2.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly) + " (" + result2 + ")";
					commonMultiLanguageViewModel2.Value = string.Format(MyResource.GetResourceString("UMnBgDescINUsageOtherPartSys", item2.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly), arg);
					list2.Add(commonMultiLanguageViewModel2);
				}
				if (list2 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2))
				{
					uMnBgDescForUsage = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
					uMnBgDescForUsage_Lang = "";
					if (list2 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2))
					{
						uMnBgDescForUsage_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel m) => m.LanguageId != defLangID))));
					}
				}
				mct_II_Result mct_II_Result = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)cRMSpIIEntities.WSspAddUserMoneyBagFromPreOrderDiscounts(pordId, value, text, uMnBgDesc, uMnBgDesc_Lang, userId, value3, value2, value, text, appType, defLangID, uMnBgDescForUsage, uMnBgDescForUsage_Lang, centerId));
				int result4 = 0;
				if (mct_II_Result != null)
				{
					int.TryParse(mct_II_Result.Result.ToString(), out result4);
				}
				result = result4 == 1;
				if (result3 != 0)
				{
					Info.Update(result3, true);
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
			cRMSpIIEntities.Dispose();
		}
		return result;
	}

	public static bool CanChangeCommissionByOtherUser(int pordId)
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
			if (!UserLogin.IsUserAccess("frmPreOrder", "actAddCommByOtherUser", currentUser))
			{
				WSspSelectPreOrderWithId_Result wSspSelectPreOrderWithId_Result = Enumerable.FirstOrDefault<WSspSelectPreOrderWithId_Result>((IEnumerable<WSspSelectPreOrderWithId_Result>)cRMSpEntities.WSspSelectPreOrderWithId(pordId, lCID, result2));
				if (wSspSelectPreOrderWithId_Result != null && ("," + wSspSelectPreOrderWithId_Result.cmpReferUserId.GetValueOrDefault() + "," + wSspSelectPreOrderWithId_Result.cmpSuppUserId.GetValueOrDefault() + "," + wSspSelectPreOrderWithId_Result.pordReferUserId.GetValueOrDefault() + "," + wSspSelectPreOrderWithId_Result.pordSellerId.GetValueOrDefault() + ",").IndexOf("," + currentUser.UserId + ",", StringComparison.Ordinal) < 0)
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

	public static List<SelectListItem> GetPordExternalLinks(int pordId = 0)
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
		try
		{
			if (pordId != 0)
			{
				CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
				string text = CodeDecode.CoddingUTF8(pordId.ToString());
				if (cRMspSelectCrmsysSetting_Result != null)
				{
					if (!UserLogin.IsUserAccess("frmPreOrder", "actGetPordFOLink", UserLogin.CurrentUser))
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
							list[1].Value = text2 + "?" + "Pord".ToLower() + "=" + text;
							list[2].Value = list[1].Value + "&nl=1";
						}
					}
					string text3 = (cRMspSelectCrmsysSetting_Result.CrmIPStatic ?? "").TrimEnd(new char[1] { '/' });
					if (!string.IsNullOrWhiteSpace(text3))
					{
						list[3].Value = text3 + "/OnlinePayment/Home/ShowOprDetails?t=" + CodeDecode.CoddingUTF8(20 + "|" + pordId);
					}
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			list[0].Value = Messages.msgErrorRunFunction;
			list = null;
		}
		return list;
	}

	public static List<SelectListItem> GetPordFoShortLinks(int pordId = 0)
	{
		DateTime now = DateTime.Now;
		string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
		short.Parse(now.ToString("MM", new PersianCulture()));
		string appType = Configuration.AppType;
		short.Parse(Financial.Get().Id.ToString());
		int userId = UserLogin.CurrentUser.UserId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> pordExternalLinks = GetPordExternalLinks(pordId);
		List<SelectListItem> list = new List<SelectListItem>();
		CRMSpIIEntities cRMSpIIEntities = new CRMSpIIEntities();
		WSspSelectPreOrderWithId_Result wSspSelectPreOrderWithId_Result = Enumerable.FirstOrDefault<WSspSelectPreOrderWithId_Result>((IEnumerable<WSspSelectPreOrderWithId_Result>)new CRMSpEntities().WSspSelectPreOrderWithId(pordId, lCID, result));
		for (int i = 0; i < pordExternalLinks.Count; i++)
		{
			if (i == 0)
			{
				list.Add(new SelectListItem
				{
					Value = pordExternalLinks[i].Value,
					Text = pordExternalLinks[i].Text
				});
			}
			else if (!string.IsNullOrWhiteSpace(pordExternalLinks[i].Value))
			{
				Uri uri = new Uri(pordExternalLinks[i].Value);
				string text = uri.Scheme + "://" + uri.Authority;
				ObjectParameter objectParameter = new ObjectParameter("ShortKey", typeof(string));
				cRMSpIIEntities.CRMspInsertShortLink(pordExternalLinks[i].Value, 20, pordId, null, null, null, null, wSspSelectPreOrderWithId_Result.pordExpireDateTime, null, userId, now, registerDatePersian, appType, lCID, text, objectParameter);
				string text2 = objectParameter.Value?.ToString();
				list.Add(new SelectListItem
				{
					Value = text + "/s/" + text2 + " ",
					Text = pordExternalLinks[i].Text
				});
			}
			else
			{
				list.Add(new SelectListItem
				{
					Value = (pordExternalLinks[i].Value ?? ""),
					Text = (pordExternalLinks[i].Text ?? "")
				});
			}
		}
		return list;
	}

	public static bool IsSentToLinkAcc(int pordId)
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
			WSspSelectPreOrderWithId_Result wSspSelectPreOrderWithId_Result = Enumerable.FirstOrDefault<WSspSelectPreOrderWithId_Result>((IEnumerable<WSspSelectPreOrderWithId_Result>)cRMSpEntities.WSspSelectPreOrderWithId(pordId, lCID, result2));
			if (wSspSelectPreOrderWithId_Result != null)
			{
				bool.TryParse(wSspSelectPreOrderWithId_Result.IsSentToLinkAcc.ToString(), out result);
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

	public static bool IsSentToLinkAccByAction(int pordId)
	{
		bool result = false;
		try
		{
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (!UserLogin.IsUserAccess("frmPreOrder", "actChangeAfterSendToLinkAcc", currentUser))
			{
				result = IsSentToLinkAcc(pordId);
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
			WSspSelectPreOrderPaymentsWithId_Result wSspSelectPreOrderPaymentsWithId_Result = Enumerable.FirstOrDefault<WSspSelectPreOrderPaymentsWithId_Result>((IEnumerable<WSspSelectPreOrderPaymentsWithId_Result>)cRMSpIEntities.WSspSelectPreOrderPaymentsWithId(payId, lCID, result2));
			if (wSspSelectPreOrderPaymentsWithId_Result != null)
			{
				bool.TryParse(wSspSelectPreOrderPaymentsWithId_Result.IsSentToLinkAcc.ToString(), out result);
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
			if (!UserLogin.IsUserAccess("frmPreOrder", "actChangeAfterSendToLinkAcc", currentUser))
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

	public static string GetPordFOLink(int pordId = 0)
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
			if (pordId != 0)
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
						string text2 = CodeDecode.CoddingUTF8(pordId.ToString());
						text = text + "?" + "Pord".ToLower() + "=" + text2;
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

	public static bool SendSmsFoSettingPordAfterVerify(int pordId)
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
			if (pordId != 0)
			{
				DateTime now = DateTime.Now;
				DateTime value = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				short value3 = short.Parse(now.ToString("yyyy", new PersianCulture()));
				int userId = UserLogin.CurrentUser.UserId;
				string pordFOLink = GetPordFOLink(pordId);
				pordFOLink = pordFOLink ?? "";
				ObjectParameter objectParameter = new ObjectParameter("Result", 0);
				cRMSpIIEntities.CRMspSendSmsFoSettingPordAfterVerify(pordId, pordFOLink, userId, value3, value2, value, registerDatePersian, appType, lCID, result2, objectParameter, centerId);
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

	public static int? GetPordCId(int pordId)
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
			WSspSelectPreOrderWithId_Result wSspSelectPreOrderWithId_Result = Enumerable.FirstOrDefault<WSspSelectPreOrderWithId_Result>((IEnumerable<WSspSelectPreOrderWithId_Result>)cRMSpEntities.WSspSelectPreOrderWithId(pordId, lCID, result2));
			if (wSspSelectPreOrderWithId_Result != null)
			{
				result = wSspSelectPreOrderWithId_Result.pordCId;
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

	public static int? GetPordItemCId(int pordItemId)
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
			WSspSelectPreOrderItemsWithId_Result wSspSelectPreOrderItemsWithId_Result = Enumerable.FirstOrDefault<WSspSelectPreOrderItemsWithId_Result>((IEnumerable<WSspSelectPreOrderItemsWithId_Result>)cRMSpIIEntities.WSspSelectPreOrderItemsWithId(pordItemId, lCID, result2));
			if (wSspSelectPreOrderItemsWithId_Result != null)
			{
				result = wSspSelectPreOrderItemsWithId_Result.pordICId;
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

	public static List<CRMspSelectFilesDirectory_Result> GetAllFiles(int pordId = 0)
	{
		List<CRMspSelectFilesDirectory_Result> result = new List<CRMspSelectFilesDirectory_Result>();
		try
		{
			List<CRMspSelectFilesDirectory_Result> list = Files.SelectFilesDirectory("", "", "", "10", pordId.ToString(), "0", "0", false);
			if (list != null)
			{
				result = list;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	public static bool SetPaymentStatus(WSPreOrder preorder)
	{
		return SetPaymentStatus(0, preorder);
	}

	public static bool SetPaymentStatus(int preorderId)
	{
		return SetPaymentStatus(preorderId, null);
	}

	private static bool SetPaymentStatus(int preorderId, WSPreOrder preorder)
	{
		bool result = false;
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		CRMTabelEntities cRMTabelEntities = new CRMTabelEntities();
		CRMSpIIEntities cRMSpIIEntities = new CRMSpIIEntities();
		try
		{
			if (preorder == null)
			{
				preorder = cRMTabelEntities.WSPreOrder.Find(preorderId);
			}
			preorderId = preorder.PreOrderID;
			WSspReturnSumPreOrderPay_Result wSspReturnSumPreOrderPay_Result = Enumerable.FirstOrDefault<WSspReturnSumPreOrderPay_Result>((IEnumerable<WSspReturnSumPreOrderPay_Result>)cRMSpEntities.WSspReturnSumPreOrderPay(preorderId));
			if (wSspReturnSumPreOrderPay_Result != null)
			{
				preorder.pordStatusId = preorder.pordStatusId.GetValueOrDefault();
				preorder.pordTotalAmount = preorder.pordTotalAmount.GetValueOrDefault();
				if (preorder.pordStatusId.GetValueOrDefault() == 4)
				{
					return true;
				}
				decimal? sumpordpayAmount = wSspReturnSumPreOrderPay_Result.sumpordpayAmount;
				if ((sumpordpayAmount.GetValueOrDefault() == default(decimal)) & sumpordpayAmount.HasValue)
				{
					if (preorder.pordStatusId.GetValueOrDefault() == 1)
					{
						return true;
					}
					cRMSpIIEntities.WSspUpdatePreOrderStatus(preorderId, 1);
				}
				else if (preorder.pordTotalAmount > wSspReturnSumPreOrderPay_Result.sumpordpayAmount)
				{
					if (preorder.pordStatusId.GetValueOrDefault() == 2)
					{
						return true;
					}
					cRMSpIIEntities.WSspUpdatePreOrderStatus(preorderId, 2);
				}
				else if (preorder.pordTotalAmount <= wSspReturnSumPreOrderPay_Result.sumpordpayAmount)
				{
					if (preorder.pordStatusId.GetValueOrDefault() == 3)
					{
						return true;
					}
					cRMSpIIEntities.WSspUpdatePreOrderStatus(preorderId, 3);
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
			cRMSpIIEntities.Dispose();
		}
		return result;
	}

	public static bool CheckCmpShpIsActive(int pordId)
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
			WSspSelectPreOrderWithId_Result wSspSelectPreOrderWithId_Result = Enumerable.FirstOrDefault<WSspSelectPreOrderWithId_Result>((IEnumerable<WSspSelectPreOrderWithId_Result>)cRMSpEntities.WSspSelectPreOrderWithId(pordId, lCID, result2));
			if (wSspSelectPreOrderWithId_Result != null && !string.IsNullOrWhiteSpace(wSspSelectPreOrderWithId_Result.CmpShpIsActive) && (wSspSelectPreOrderWithId_Result.CmpShpIsActive ?? "0") == "1")
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
		}
		return result;
	}

	public static string ControlPreOrderItemsStock(int pordId, int mode, string txt = "")
	{
		string result = "";
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		CRMSpIIEntities cRMSpIIEntities = new CRMSpIIEntities();
		try
		{
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
			int id = Financial.Get().Id;
			int userId = UserLogin.CurrentUser.UserId;
			int cmpId = 0;
			string format = Messages.msgErrorCanNotVerifyNoStockFromWarehouse;
			string text = "";
			string text2 = "";
			bool flag = false;
			WSspSelectPreOrderWithId_Result wSspSelectPreOrderWithId_Result = Enumerable.FirstOrDefault<WSspSelectPreOrderWithId_Result>((IEnumerable<WSspSelectPreOrderWithId_Result>)cRMSpEntities.WSspSelectPreOrderWithId(pordId, lCID, result2));
			if (wSspSelectPreOrderWithId_Result != null)
			{
				cmpId = wSspSelectPreOrderWithId_Result.pordCompanyId.GetValueOrDefault();
				result3 = wSspSelectPreOrderWithId_Result.pordCId.GetValueOrDefault();
			}
			switch (mode)
			{
			case 1:
				format = Messages.msgErrorCanNotVerifyNoStockFromWarehouse;
				text = "frmPreOrder";
				text2 = "actCanNotVerifyNoStockFromWarehouse";
				break;
			case 2:
				format = Messages.msgErrorCanNotVerifyNoStockFromWarehouseParam;
				format = format.Replace("{1}", txt);
				text = "frmPreOrder";
				text2 = "actCanNotVerifyNoStockFromWarehouse";
				break;
			}
			if (string.IsNullOrWhiteSpace(text) && string.IsNullOrWhiteSpace(text2))
			{
				flag = true;
			}
			else if (UserLogin.IsUserAccess(text, text2, UserLogin.CurrentUser))
			{
				flag = true;
			}
			if (flag)
			{
				List<WSspSelectPreOrderItems_Result> list = Enumerable.ToList<WSspSelectPreOrderItems_Result>((IEnumerable<WSspSelectPreOrderItems_Result>)cRMSpEntities.WSspSelectPreOrderItems(pordId, lCID, result2));
				CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
				bool flag2 = false;
				int num = 0;
				bool flag3 = false;
				if (cRMspSelectCrmsysSetting_Result != null)
				{
					flag2 = ((cRMspSelectCrmsysSetting_Result.InvStockFromLink.HasValue && cRMspSelectCrmsysSetting_Result.InvStockFromLink.GetValueOrDefault()) ? true : false);
					num = cRMspSelectCrmsysSetting_Result.LinkAccSystemId.GetValueOrDefault();
				}
				if (flag2 && num > 0)
				{
					List<WSspSelectPreOrderItems_Result> list2 = new List<WSspSelectPreOrderItems_Result>();
					if (list != null && Enumerable.Any<WSspSelectPreOrderItems_Result>((IEnumerable<WSspSelectPreOrderItems_Result>)list))
					{
						foreach (WSspSelectPreOrderItems_Result linkAccitem in list)
						{
							int num2 = linkAccitem.PrdKind.GetValueOrDefault(1);
							if (num2 == 0)
							{
								num2 = 1;
							}
							if (num2 != 1)
							{
								continue;
							}
							bool flag4 = true;
							if (Enumerable.FirstOrDefault<WSspSelectPreOrderItems_Result>((IEnumerable<WSspSelectPreOrderItems_Result>)list2, (Func<WSspSelectPreOrderItems_Result, bool>)((WSspSelectPreOrderItems_Result m) => m.pordIPrdId == linkAccitem.pordIPrdId && m.pordIWHId == linkAccitem.pordIWHId && (m.pordILinkAccWHIdStr ?? "") == (linkAccitem.pordILinkAccWHIdStr ?? "") && (m.pordITracing ?? "") == (linkAccitem.pordITracing ?? "") && m.pordILinkAccSettingDBId.GetValueOrDefault() == linkAccitem.pordILinkAccSettingDBId.GetValueOrDefault())) != null)
							{
								flag4 = false;
							}
							if (!flag4)
							{
								continue;
							}
							List<WSspSelectPreOrderItems_Result> list3 = Enumerable.ToList<WSspSelectPreOrderItems_Result>(Enumerable.Where<WSspSelectPreOrderItems_Result>((IEnumerable<WSspSelectPreOrderItems_Result>)list, (Func<WSspSelectPreOrderItems_Result, bool>)((WSspSelectPreOrderItems_Result m) => m.pordIPrdId == linkAccitem.pordIPrdId && m.pordIWHId == linkAccitem.pordIWHId && (m.pordILinkAccWHIdStr ?? "") == (linkAccitem.pordILinkAccWHIdStr ?? "") && (m.pordITracing ?? "") == (linkAccitem.pordITracing ?? "") && m.pordILinkAccSettingDBId.GetValueOrDefault() == linkAccitem.pordILinkAccSettingDBId.GetValueOrDefault())));
							double num3 = 0.0;
							if (list3 != null && Enumerable.Any<WSspSelectPreOrderItems_Result>((IEnumerable<WSspSelectPreOrderItems_Result>)list3))
							{
								foreach (WSspSelectPreOrderItems_Result item2 in list3)
								{
									num3 += item2.pordIQuantity.GetValueOrDefault();
								}
							}
							WSspSelectPreOrderItems_Result item = new WSspSelectPreOrderItems_Result
							{
								PreOrderItemID = linkAccitem.PreOrderItemID,
								pordIQuantity = num3,
								pordIPrice = linkAccitem.pordIPrice,
								pordIPrdPriceGroupID = linkAccitem.pordIPrdPriceGroupID,
								pordIPrdId = linkAccitem.pordIPrdId,
								pordIWHId = linkAccitem.pordIWHId,
								pordILinkAccWHIdStr = linkAccitem.pordILinkAccWHIdStr,
								pordITracing = linkAccitem.pordITracing,
								pordILinkAccSettingDBId = linkAccitem.pordILinkAccSettingDBId,
								pordIDescriptionI = linkAccitem.pordIDescriptionI,
								PrdName = linkAccitem.PrdName
							};
							list2.Add(item);
						}
					}
					if (list2 != null && Enumerable.Any<WSspSelectPreOrderItems_Result>((IEnumerable<WSspSelectPreOrderItems_Result>)list2))
					{
						foreach (WSspSelectPreOrderItems_Result item3 in list2)
						{
							new ProductController();
							string text3 = "";
							text3 = OtherSystems.GetPrdQuantity(userId, item3.pordIPrdId, item3.pordIWHId.GetValueOrDefault(), item3.pordILinkAccWHIdStr ?? "", item3.pordITracing ?? "", cmpId, "", item3.pordILinkAccSettingDBId.GetValueOrDefault());
							double result4 = 0.0;
							double valueOrDefault = item3.pordIQuantity.GetValueOrDefault();
							if (string.IsNullOrEmpty(text3))
							{
								continue;
							}
							if (text3 == Labels.frmError)
							{
								text3 = "0";
							}
							if (text3 != Labels.frmError)
							{
								double.TryParse(text3, out result4);
								if (result4 < valueOrDefault)
								{
									result = string.Format(format, item3.PrdName ?? "");
									return result;
								}
								flag3 = true;
							}
						}
					}
				}
				if (!flag3)
				{
					List<WSspControlPreOrderItemsFromWarehouse_Result> list4 = Enumerable.ToList<WSspControlPreOrderItemsFromWarehouse_Result>((IEnumerable<WSspControlPreOrderItemsFromWarehouse_Result>)cRMSpIIEntities.WSspControlPreOrderItemsFromWarehouse(pordId, result3, 1, id, lCID, result2));
					if (list4 != null && Enumerable.Any<WSspControlPreOrderItemsFromWarehouse_Result>((IEnumerable<WSspControlPreOrderItemsFromWarehouse_Result>)list4))
					{
						foreach (WSspControlPreOrderItemsFromWarehouse_Result item4 in list4)
						{
							double valueOrDefault2 = item4.pordIQuantity.GetValueOrDefault();
							if (item4.QuantityRemain.GetValueOrDefault() < valueOrDefault2)
							{
								result = string.Format(format, item4.PrdName ?? "");
								return result;
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
		finally
		{
			if (cRMSpEntities != null)
			{
				cRMSpEntities.Dispose();
				cRMSpIIEntities.Dispose();
			}
		}
		return result;
	}

	public static string ControlPreOrderItemsReserveStock(int pordId, int mode, string txt = "")
	{
		string result = "";
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		CRMSpIIEntities cRMSpIIEntities = new CRMSpIIEntities();
		try
		{
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
			int id = Financial.Get().Id;
			int userId = UserLogin.CurrentUser.UserId;
			int cmpId = 0;
			string format = Messages.msgErrorCanNotVerifyNoStockFromReserve;
			string text = "";
			string text2 = "";
			bool flag = false;
			WSspSelectPreOrderWithId_Result wSspSelectPreOrderWithId_Result = Enumerable.FirstOrDefault<WSspSelectPreOrderWithId_Result>((IEnumerable<WSspSelectPreOrderWithId_Result>)cRMSpEntities.WSspSelectPreOrderWithId(pordId, lCID, result2));
			if (wSspSelectPreOrderWithId_Result != null)
			{
				cmpId = wSspSelectPreOrderWithId_Result.pordCompanyId.GetValueOrDefault();
				result3 = wSspSelectPreOrderWithId_Result.pordCId.GetValueOrDefault();
			}
			switch (mode)
			{
			case 1:
				format = Messages.msgErrorCanNotVerifyNoStockFromReserve;
				text = "frmPreOrder";
				text2 = "actCanNotVerifyNoStockFromReserve";
				break;
			case 2:
				format = Messages.msgErrorCanNotVerifyNoStockFromReserveByParam;
				format = format.Replace("{1}", txt);
				text = "frmPreOrder";
				text2 = "actCanNotVerifyNoStockFromReserve";
				break;
			}
			if (string.IsNullOrWhiteSpace(text) && string.IsNullOrWhiteSpace(text2))
			{
				flag = true;
			}
			else if (UserLogin.IsUserAccess(text, text2, UserLogin.CurrentUser))
			{
				flag = true;
			}
			if (flag)
			{
				List<WSspControlPreOrderItemsReserveStock_Result> list = Enumerable.ToList<WSspControlPreOrderItemsReserveStock_Result>((IEnumerable<WSspControlPreOrderItemsReserveStock_Result>)cRMSpIIEntities.WSspControlPreOrderItemsReserveStock(pordId, result3, DateTime.Now, 1, id, lCID, result2));
				if (list != null && Enumerable.Any<WSspControlPreOrderItemsReserveStock_Result>((IEnumerable<WSspControlPreOrderItemsReserveStock_Result>)list))
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
					foreach (WSspControlPreOrderItemsReserveStock_Result item in list)
					{
						new ProductController();
						string text3 = "";
						double result4 = 0.0;
						double valueOrDefault = item.pordIQuantity.GetValueOrDefault();
						item.RemainCountAllWH.GetValueOrDefault();
						double valueOrDefault2 = item.ValidpordQuantity.GetValueOrDefault();
						double valueOrDefault3 = item.TracingRemainCount.GetValueOrDefault();
						if (flag2 && num > 0)
						{
							text3 = OtherSystems.GetPrdQuantity(userId, item.pordIPrdId.GetValueOrDefault(), item.pordIWHId.GetValueOrDefault(), item.pordILinkAccWHIdStr ?? "", item.pordITracing ?? "", cmpId);
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
			if (cRMSpEntities != null)
			{
				cRMSpEntities.Dispose();
				cRMSpIIEntities.Dispose();
			}
		}
		return result;
	}

	public static string ControlPreOrderItemsFromShop(int pordId, int mode, string txt = "")
	{
		string result = "";
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		CRMSpIIEntities cRMSpIIEntities = new CRMSpIIEntities();
		try
		{
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
			int userId = UserLogin.CurrentUser.UserId;
			int cmpId = 0;
			string format = Messages.msgErrorCanNotVerifyNoStockFromShop;
			string text = "";
			string text2 = "";
			bool flag = false;
			WSspSelectPreOrderWithId_Result wSspSelectPreOrderWithId_Result = Enumerable.FirstOrDefault<WSspSelectPreOrderWithId_Result>((IEnumerable<WSspSelectPreOrderWithId_Result>)cRMSpEntities.WSspSelectPreOrderWithId(pordId, lCID, result2));
			if (wSspSelectPreOrderWithId_Result != null)
			{
				cmpId = wSspSelectPreOrderWithId_Result.pordCompanyId.GetValueOrDefault();
				result3 = wSspSelectPreOrderWithId_Result.pordCId.GetValueOrDefault();
			}
			switch (mode)
			{
			case 1:
				format = Messages.msgErrorCanNotVerifyNoStockFromShop;
				text = "frmPreOrder";
				text2 = "actCanNotVerifyNoStockFromShop";
				break;
			case 2:
				format = Messages.msgErrorCanNotVerifyNoStockFromShopByParam;
				format = format.Replace("{1}", txt);
				text = "frmPreOrder";
				text2 = "actCanNotVerifyNoStockFromShop";
				break;
			}
			if (string.IsNullOrWhiteSpace(text) && string.IsNullOrWhiteSpace(text2))
			{
				flag = true;
			}
			else if (UserLogin.IsUserAccess(text, text2, UserLogin.CurrentUser))
			{
				flag = true;
			}
			if (flag)
			{
				string text3 = "";
				List<CommonIdValueByParamViewModel<double>> list = new List<CommonIdValueByParamViewModel<double>>();
				List<WSspSelectPreOrderItems_Result> list2 = Enumerable.ToList<WSspSelectPreOrderItems_Result>((IEnumerable<WSspSelectPreOrderItems_Result>)cRMSpEntities.WSspSelectPreOrderItems(pordId, lCID, result2));
				CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
				bool flag2 = false;
				int num = 0;
				if (cRMspSelectCrmsysSetting_Result != null)
				{
					flag2 = ((cRMspSelectCrmsysSetting_Result.InvStockFromLink.HasValue && cRMspSelectCrmsysSetting_Result.InvStockFromLink.GetValueOrDefault()) ? true : false);
					num = cRMspSelectCrmsysSetting_Result.LinkAccSystemId.GetValueOrDefault();
				}
				if (list2 != null && Enumerable.Any<WSspSelectPreOrderItems_Result>((IEnumerable<WSspSelectPreOrderItems_Result>)list2))
				{
					foreach (WSspSelectPreOrderItems_Result item2 in list2)
					{
						double result4 = 0.0;
						if (flag2 && num > 0)
						{
							new ProductController();
							string text4 = "";
							text4 = OtherSystems.GetPrdQuantity(userId, item2.pordIPrdId, item2.pordIWHId.GetValueOrDefault(), item2.pordILinkAccWHIdStr ?? "", item2.pordITracing ?? "", cmpId, "", item2.pordILinkAccSettingDBId.GetValueOrDefault());
							if (!string.IsNullOrEmpty(text4))
							{
								if (text4 == Labels.frmError)
								{
									text4 = "0";
								}
								if (text4 != Labels.frmError)
								{
									double.TryParse(text4, out result4);
								}
							}
						}
						CommonIdValueByParamViewModel<double> item = new CommonIdValueByParamViewModel<double>
						{
							Id = item2.pordIPrdId,
							Value = result4
						};
						list.Add(item);
					}
				}
				if (list != null && Enumerable.Any<CommonIdValueByParamViewModel<double>>((IEnumerable<CommonIdValueByParamViewModel<double>>)list))
				{
					text3 = JsonConvert.SerializeObject(Enumerable.ToList<CommonIdValueByParamViewModel<double>>((IEnumerable<CommonIdValueByParamViewModel<double>>)list));
					List<WSspControlPreOrderItemsFromShop_Result> list3 = Enumerable.ToList<WSspControlPreOrderItemsFromShop_Result>((IEnumerable<WSspControlPreOrderItemsFromShop_Result>)cRMSpIIEntities.WSspControlPreOrderItemsFromShop(pordId, text3, result3, 1, lCID, result2));
					if (list3 != null && Enumerable.Any<WSspControlPreOrderItemsFromShop_Result>((IEnumerable<WSspControlPreOrderItemsFromShop_Result>)list3))
					{
						foreach (WSspControlPreOrderItemsFromShop_Result item3 in list3)
						{
							double valueOrDefault = item3.pordIQuantity.GetValueOrDefault();
							if (item3.QuantityRemain.GetValueOrDefault() < valueOrDefault)
							{
								result = string.Format(format, item3.PrdName ?? "");
								return result;
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
		finally
		{
			if (cRMSpEntities != null)
			{
				cRMSpEntities.Dispose();
				cRMSpIIEntities.Dispose();
			}
		}
		return result;
	}

	public static string ControlPreOrderItemsSoldStock(int pordId, int mode, string txt = "", string pordItemJson = "")
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
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			int id = Financial.Get().Id;
			int userId = UserLogin.CurrentUser.UserId;
			int cmpId = 0;
			string format = Messages.msgErrorCanNotVerifyNoStockFromSold;
			string text = "";
			string text2 = "";
			bool flag = false;
			WSspSelectPreOrderWithId_Result wSspSelectPreOrderWithId_Result = Enumerable.FirstOrDefault<WSspSelectPreOrderWithId_Result>((IEnumerable<WSspSelectPreOrderWithId_Result>)cRMSpEntities.WSspSelectPreOrderWithId(pordId, lCID, result2));
			if (wSspSelectPreOrderWithId_Result != null)
			{
				cmpId = wSspSelectPreOrderWithId_Result.pordCompanyId.GetValueOrDefault();
				result3 = wSspSelectPreOrderWithId_Result.pordCId.GetValueOrDefault();
			}
			switch (mode)
			{
			case 1:
				format = Messages.msgErrorCanNotVerifyNoStockFromSold;
				text = "frmPreOrder";
				text2 = "actCanNotVerifyNoStockFromSold";
				break;
			case 2:
				format = Messages.msgErrorCanNotVerifyNoStockFromSoldByParam;
				format = format.Replace("{1}", txt);
				text = "frmPreOrder";
				text2 = "actCanNotVerifyNoStockFromSold";
				break;
			case 3:
				format = Messages.msgErrorIssueOrderFormPreOrderLackSoldStock;
				text = "frmIssueOrderFromPreOrder";
				text2 = "actCanNotIssueOrderWithNoStockFromSold";
				break;
			case 4:
				format = Messages.msgIssueDraftFormPreOrderLackSoldStock;
				text = "frmIssueDraftFromPreOrder";
				text2 = "actCanNotIssueDraftWithNoStockFromSold";
				break;
			}
			if (string.IsNullOrWhiteSpace(text) && string.IsNullOrWhiteSpace(text2))
			{
				flag = true;
			}
			else if (UserLogin.IsUserAccess(text, text2, UserLogin.CurrentUser))
			{
				flag = true;
			}
			if (flag)
			{
				List<WSspControlPreOrderItemsSoldStock_Result> list = Enumerable.ToList<WSspControlPreOrderItemsSoldStock_Result>((IEnumerable<WSspControlPreOrderItemsSoldStock_Result>)cRMSpIIIEntities.WSspControlPreOrderItemsSoldStock(pordId, pordItemJson, result3, 1, id, lCID, result2));
				if (list != null && Enumerable.Any<WSspControlPreOrderItemsSoldStock_Result>((IEnumerable<WSspControlPreOrderItemsSoldStock_Result>)list))
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
					foreach (WSspControlPreOrderItemsSoldStock_Result item in list)
					{
						new ProductController();
						string text3 = "";
						double result4 = 0.0;
						double valueOrDefault = item.pordIQuantity.GetValueOrDefault();
						item.RemainCountAllWH.GetValueOrDefault();
						double valueOrDefault2 = item.SoldOrdQuantity.GetValueOrDefault();
						double valueOrDefault3 = item.TracingRemainCount.GetValueOrDefault();
						if (flag2 && num > 0)
						{
							text3 = OtherSystems.GetPrdQuantity(userId, item.pordIPrdId.GetValueOrDefault(), item.pordIWHId.GetValueOrDefault(), item.pordILinkAccWHIdStr ?? "", item.pordITracing ?? "", cmpId);
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

	public static List<WSspSelectPreOrderTypes_Result> SelectPreOrderTypes(int userId = -1, int currLangId = 0, int defLangId = 0)
	{
		List<WSspSelectPreOrderTypes_Result> result = new List<WSspSelectPreOrderTypes_Result>();
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
			result = Enumerable.ToList<WSspSelectPreOrderTypes_Result>((IEnumerable<WSspSelectPreOrderTypes_Result>)cRMSpEntities.WSspSelectPreOrderTypes(currLangId, defLangId, userId));
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

	public static bool SendToLinkAccNeedVerify(int pordId, ref string errorMessage)
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
			if (UserLogin.IsUserAccess("frmPreOrder", actionName, UserLogin.CurrentUser))
			{
				WSspSelectPreOrderWithId_Result wSspSelectPreOrderWithId_Result = Enumerable.FirstOrDefault<WSspSelectPreOrderWithId_Result>((IEnumerable<WSspSelectPreOrderWithId_Result>)cRMSpEntities.WSspSelectPreOrderWithId(pordId, lCID, result2));
				if (wSspSelectPreOrderWithId_Result != null && !wSspSelectPreOrderWithId_Result.pordIsVerified.GetValueOrDefault())
				{
					result = false;
					errorMessage = string.Format(Messages.msgErrorSendToLinkAccNeedVerifyByNumber, Labels.lblPOrd, wSspSelectPreOrderWithId_Result.pordNumber.ToString(), linkAccSystemTitle);
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

	public static bool IsVerified(int pordId)
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
			WSspSelectPreOrderWithId_Result wSspSelectPreOrderWithId_Result = Enumerable.FirstOrDefault<WSspSelectPreOrderWithId_Result>((IEnumerable<WSspSelectPreOrderWithId_Result>)cRMSpEntities.WSspSelectPreOrderWithId(pordId, lCID, result2));
			if (wSspSelectPreOrderWithId_Result != null)
			{
				result = wSspSelectPreOrderWithId_Result.pordIsVerified.GetValueOrDefault();
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

	public static bool CheckCmpCredit(int pordId)
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
			WSspSelectPreOrderWithId_Result wSspSelectPreOrderWithId_Result = Enumerable.FirstOrDefault<WSspSelectPreOrderWithId_Result>((IEnumerable<WSspSelectPreOrderWithId_Result>)cRMSpEntities.WSspSelectPreOrderWithId(pordId, lCID, result2));
			if (wSspSelectPreOrderWithId_Result != null)
			{
				result = OtherSystems.CheckCmpCreditByAmount(0, wSspSelectPreOrderWithId_Result.pordCompanyId.GetValueOrDefault(), wSspSelectPreOrderWithId_Result.pordTotalAmount.GetValueOrDefault());
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

	public static string CheckBeforeVerification(int pordId, string txt = "", int mode = 1)
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
				txt = Labels.lblPOrd;
			}
			if (mode == 0)
			{
				mode = 1;
			}
			WSspSelectPreOrderWithId_Result wSspSelectPreOrderWithId_Result = Enumerable.FirstOrDefault<WSspSelectPreOrderWithId_Result>((IEnumerable<WSspSelectPreOrderWithId_Result>)cRMSpEntities.WSspSelectPreOrderWithId(pordId, lCID, result2));
			decimal num;
			WSfnReturnPreOrderSumFooter_Result wSfnReturnPreOrderSumFooter_Result;
			decimal obj;
			if (wSspSelectPreOrderWithId_Result != null)
			{
				if (!UserLogin.IsUserAccess("frmPreOrder", "actVerifyAfterExp", currentUser) && ((wSspSelectPreOrderWithId_Result.pordExpireDateTime.HasValue && wSspSelectPreOrderWithId_Result.pordExpireDateTime?.Date < DateTime.Now.Date) || wSspSelectPreOrderWithId_Result.pordStatusId.GetValueOrDefault() == 4))
				{
					result = string.Format(Messages.msgErrorUnableVerifyPreOrderExpiredByParam, txt);
					return result;
				}
				if (!CheckCmpCredit(pordId))
				{
					result = string.Format(Messages.msgErrorNoVerifyObjByCmpWithoutCredit, txt);
					return result;
				}
				if (UserLogin.IsUserAccess("frmPreOrder", "actCanNotVerifyPordDeactiveCmpInShp", currentUser) && !CheckCmpShpIsActive(pordId))
				{
					result = string.Format(Messages.msgErrorCanNotVerifyPordDeactiveCmpInShpByParam, txt);
					return result;
				}
				if (UserLogin.IsUserAccess("frmPreOrder", "actCanNotVerifyNoStockFromWarehouse", currentUser))
				{
					string text = "";
					text = ControlPreOrderItemsStock(pordId, mode, txt);
					if (!string.IsNullOrWhiteSpace(text))
					{
						result = text;
						return result;
					}
				}
				if (UserLogin.IsUserAccess("frmPreOrder", "actCanNotVerifyNoStockFromReserve", currentUser))
				{
					string text2 = "";
					text2 = ControlPreOrderItemsReserveStock(pordId, mode, txt);
					if (!string.IsNullOrWhiteSpace(text2))
					{
						result = text2;
						return result;
					}
				}
				if (UserLogin.IsUserAccess("frmPreOrder", "actCanNotVerifyNoStockFromShop", currentUser))
				{
					string text3 = "";
					text3 = ControlPreOrderItemsFromShop(pordId, mode, txt);
					if (!string.IsNullOrWhiteSpace(text3))
					{
						result = text3;
						return result;
					}
				}
				if (UserLogin.IsUserAccess("frmPreOrder", "actCanNotVerifyNoStockFromSold", currentUser))
				{
					string text4 = "";
					text4 = ControlPreOrderItemsSoldStock(pordId, mode, txt);
					if (!string.IsNullOrWhiteSpace(text4))
					{
						result = text4;
						return result;
					}
				}
				if (UserLogin.IsUserAccess("frmPreOrder", "actMustPrdGroupSame", UserLogin.CurrentUser))
				{
					List<WSspCheckPrdGroupSameInPreOrder_Result> list = Enumerable.ToList<WSspCheckPrdGroupSameInPreOrder_Result>((IEnumerable<WSspCheckPrdGroupSameInPreOrder_Result>)cRMSpIEntities.WSspCheckPrdGroupSameInPreOrder(pordId, lCID, result2));
					if (list != null && Enumerable.Any<WSspCheckPrdGroupSameInPreOrder_Result>((IEnumerable<WSspCheckPrdGroupSameInPreOrder_Result>)list))
					{
						result = string.Format(Messages.msgErrorNotVerifiedPordNoPrdGroupSameByParam, txt);
						return result;
					}
				}
				num = default(decimal);
				CRMspReturnRollDiscountLimitation_Result cRMspReturnRollDiscountLimitation_Result = Enumerable.FirstOrDefault<CRMspReturnRollDiscountLimitation_Result>((IEnumerable<CRMspReturnRollDiscountLimitation_Result>)Enumerable.ToList<CRMspReturnRollDiscountLimitation_Result>((IEnumerable<CRMspReturnRollDiscountLimitation_Result>)cRMSpEntities.CRMspReturnRollDiscountLimitation(currentUser.RollId)));
				if (cRMspReturnRollDiscountLimitation_Result != null)
				{
					if (cRMspReturnRollDiscountLimitation_Result.LimitPreOrderDiscountActive.HasValue && cRMspReturnRollDiscountLimitation_Result.LimitPreOrderDiscountActive.GetValueOrDefault())
					{
						num = cRMspReturnRollDiscountLimitation_Result.LimitPreOrderDiscountPercent.GetValueOrDefault();
					}
					wSfnReturnPreOrderSumFooter_Result = Queryable.FirstOrDefault<WSfnReturnPreOrderSumFooter_Result>(cRMSpEntities.WSfnReturnPreOrderSumFooter(pordId));
					if (num > 0m && wSfnReturnPreOrderSumFooter_Result != null)
					{
						if (wSfnReturnPreOrderSumFooter_Result.TotalPriceSumWithoutDiscount.HasValue)
						{
							decimal? totalPriceSumWithoutDiscount = wSfnReturnPreOrderSumFooter_Result.TotalPriceSumWithoutDiscount;
							if ((totalPriceSumWithoutDiscount.GetValueOrDefault() > default(decimal)) & totalPriceSumWithoutDiscount.HasValue)
							{
								obj = Convert.ToDecimal(wSfnReturnPreOrderSumFooter_Result.TotalDiscountSum * (decimal?)100) / Convert.ToDecimal(wSfnReturnPreOrderSumFooter_Result.TotalPriceSumWithoutDiscount);
								goto IL_0418;
							}
						}
						obj = 0m;
						goto IL_0418;
					}
					goto IL_0674;
				}
				result = Messages.ErrorNotFoundSetting;
				return result;
			}
			result = Messages.ErrorNotFound;
			goto end_IL_0018;
			IL_0627:
			decimal obj2;
			decimal num2 = (decimal)obj2;
			if (num2 > num)
			{
				result = Messages.MaxDiscountPercentPreOrderInActivePreOrder + " " + num;
				if (mode == 2)
				{
					result = string.Format(Messages.MaxDiscountPercentPreOrderInActivePreOrderByParam, txt) + " " + num;
				}
				return result;
			}
			goto IL_0674;
			IL_0418:
			num2 = obj;
			if (num2 != 0m)
			{
				List<WSspSelectPreOrderItemsByNotInSum_Result> list2 = Enumerable.ToList<WSspSelectPreOrderItemsByNotInSum_Result>((IEnumerable<WSspSelectPreOrderItemsByNotInSum_Result>)cRMSpEntities.WSspSelectPreOrderItemsByNotInSum(pordId, false, lCID, result2));
				if (list2 != null && Enumerable.Any<WSspSelectPreOrderItemsByNotInSum_Result>((IEnumerable<WSspSelectPreOrderItemsByNotInSum_Result>)list2))
				{
					decimal num3 = default(decimal);
					int num4 = 0;
					foreach (WSspSelectPreOrderItemsByNotInSum_Result item in list2)
					{
						if (item.pordIDiscountPercent.GetValueOrDefault() != 0m)
						{
							num3 += item.pordIDiscountPercent.GetValueOrDefault();
							num4++;
						}
					}
					if (num3 > 0m && num4 > 0)
					{
						num2 = num3 / (decimal)num4;
					}
				}
			}
			if (wSfnReturnPreOrderSumFooter_Result.SumPriceAmount.HasValue)
			{
				if (num2 > num)
				{
					result = Messages.MaxDiscountPercentInActivePreOrder + " " + num;
					if (mode == 2)
					{
						result = string.Format(Messages.MaxDiscountPercentInActivePreOrderByParam, txt) + " " + num;
					}
					return result;
				}
				if (wSfnReturnPreOrderSumFooter_Result.SumPriceAmount.GetValueOrDefault() == 0m)
				{
					decimal? totalPriceSumWithoutDiscount = wSspSelectPreOrderWithId_Result.pordDiscount;
					if (!((totalPriceSumWithoutDiscount.GetValueOrDefault() == default(decimal)) & totalPriceSumWithoutDiscount.HasValue))
					{
						result = Messages.msgErrorDivisionByZero;
						return result;
					}
				}
				if (wSfnReturnPreOrderSumFooter_Result.SumPriceAmount.HasValue)
				{
					decimal? totalPriceSumWithoutDiscount = wSfnReturnPreOrderSumFooter_Result.SumPriceAmount;
					if ((totalPriceSumWithoutDiscount.GetValueOrDefault() > default(decimal)) & totalPriceSumWithoutDiscount.HasValue)
					{
						obj2 = Convert.ToDecimal(wSspSelectPreOrderWithId_Result.pordDiscount.GetValueOrDefault() * 100m) / Convert.ToDecimal(wSfnReturnPreOrderSumFooter_Result.SumPriceAmount);
						goto IL_0627;
					}
				}
				obj2 = 0m;
				goto IL_0627;
			}
			goto IL_0674;
			IL_0674:
			if (wSfnReturnPreOrderSumFooter_Result != null)
			{
				decimal result3 = default(decimal);
				decimal.TryParse(wSfnReturnPreOrderSumFooter_Result.TotalDiscountSum.ToString(), out result3);
				decimal valueOrDefault = Enumerable.FirstOrDefault<decimal?>((IEnumerable<decimal?>)cRMSpIIEntities.WSspReturnPreOrderDiscountSumDisAmount(pordId)).GetValueOrDefault();
				if (valueOrDefault > 0m)
				{
					if (result3 == 0m)
					{
						result = string.Format(Messages.msgErrorNotVerifyBecauseNotAddDisStToItemDis, txt);
						return result;
					}
					if (result3 != valueOrDefault)
					{
						result = string.Format(Messages.msgErrorNotVerifyBecauseDifferentDisStWithItemDis, txt);
						return result;
					}
				}
			}
			end_IL_0018:;
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
