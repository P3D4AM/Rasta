using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using CRM.Models;
using CRMIdeal.Cache.Setting;
using CRMIdeal.GSD.Globalization;
using Elmah;

namespace CRMIdeal.Classes.Helper;

public class StockSupply
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass2_0
	{
		public int stockSupplyId;

		public WSStockSupply model;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		public int stockSupplyId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public int stsupId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public int stsupItemId;
	}

	public static bool CalcAndSetStockSupplyFields(WSStockSupply stockSupply)
	{
		return CalcAndSetStockSupplyFields(0, stockSupply);
	}

	public static bool CalcAndSetStockSupplyFields(int stockSupplyId)
	{
		return CalcAndSetStockSupplyFields(stockSupplyId, null);
	}

	private static bool CalcAndSetStockSupplyFields(int stockSupplyId, WSStockSupply model)
	{
		_003C_003Ec__DisplayClass2_0 _003C_003Ec__DisplayClass2_ = new _003C_003Ec__DisplayClass2_0();
		_003C_003Ec__DisplayClass2_.stockSupplyId = stockSupplyId;
		_003C_003Ec__DisplayClass2_.model = model;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		bool result2 = false;
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		CRMTabelEntities cRMTabelEntities = new CRMTabelEntities();
		CRMSpIIEntities cRMSpIIEntities = new CRMSpIIEntities();
		try
		{
			WSStockSupply model2 = _003C_003Ec__DisplayClass2_.model;
			if (model2 == null)
			{
				DbSet<WSStockSupply> wSStockSupply = cRMTabelEntities.WSStockSupply;
				ParameterExpression val = Expression.Parameter(typeof(WSStockSupply), "c");
				model2 = Queryable.FirstOrDefault<WSStockSupply>((IQueryable<WSStockSupply>)wSStockSupply, Expression.Lambda<Func<WSStockSupply, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass2_, typeof(_003C_003Ec__DisplayClass2_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			}
			else
			{
				DbSet<WSStockSupply> wSStockSupply2 = cRMTabelEntities.WSStockSupply;
				ParameterExpression val = Expression.Parameter(typeof(WSStockSupply), "c");
				model2 = Queryable.FirstOrDefault<WSStockSupply>((IQueryable<WSStockSupply>)wSStockSupply2, Expression.Lambda<Func<WSStockSupply, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass2_, typeof(_003C_003Ec__DisplayClass2_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			}
			_003C_003Ec__DisplayClass2_.stockSupplyId = model2.StockSupplyId;
			WSspReturnStockSupplySumFooter_Result wSspReturnStockSupplySumFooter_Result = Enumerable.FirstOrDefault<WSspReturnStockSupplySumFooter_Result>((IEnumerable<WSspReturnStockSupplySumFooter_Result>)cRMSpIIEntities.WSspReturnStockSupplySumFooter(_003C_003Ec__DisplayClass2_.stockSupplyId));
			if (wSspReturnStockSupplySumFooter_Result != null)
			{
				double valueOrDefault = wSspReturnStockSupplySumFooter_Result.SumQuantity.GetValueOrDefault();
				DbSet<WSStockSupplyItems> wSStockSupplyItems = cRMTabelEntities.WSStockSupplyItems;
				ParameterExpression val = Expression.Parameter(typeof(WSStockSupplyItems), "c");
				int value = Queryable.Count<WSStockSupplyItems>((IQueryable<WSStockSupplyItems>)wSStockSupplyItems, Expression.Lambda<Func<WSStockSupplyItems, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass2_, typeof(_003C_003Ec__DisplayClass2_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				model2.stsupItemCount = value;
				model2.stsupItemsQty = valueOrDefault;
				model2.Month1 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
				cRMTabelEntities.Entry(model2).State = EntityState.Modified;
				cRMTabelEntities.Configuration.ValidateOnSaveEnabled = false;
				cRMTabelEntities.SaveChanges();
				cRMTabelEntities.Configuration.ValidateOnSaveEnabled = true;
				result2 = true;
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
			cRMSpIIEntities.Dispose();
		}
		return result2;
	}

	public static bool IsFixed(int stockSupplyId)
	{
		_003C_003Ec__DisplayClass3_0 _003C_003Ec__DisplayClass3_ = new _003C_003Ec__DisplayClass3_0();
		_003C_003Ec__DisplayClass3_.stockSupplyId = stockSupplyId;
		bool result = false;
		CRMTabelEntities cRMTabelEntities = new CRMTabelEntities();
		try
		{
			DbSet<WSStockSupply> wSStockSupply = cRMTabelEntities.WSStockSupply;
			ParameterExpression val = Expression.Parameter(typeof(WSStockSupply), "m");
			WSStockSupply wSStockSupply2 = Queryable.FirstOrDefault<WSStockSupply>((IQueryable<WSStockSupply>)wSStockSupply, Expression.Lambda<Func<WSStockSupply, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass3_, typeof(_003C_003Ec__DisplayClass3_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (wSStockSupply2 != null)
			{
				bool.TryParse(wSStockSupply2.stsupIsFixed.ToString(), out result);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMTabelEntities.Dispose();
		}
		return result;
	}

	public static int? GetStsupCId(int stsupId)
	{
		_003C_003Ec__DisplayClass4_0 _003C_003Ec__DisplayClass4_ = new _003C_003Ec__DisplayClass4_0();
		_003C_003Ec__DisplayClass4_.stsupId = stsupId;
		int? result = null;
		CRMTabelEntities cRMTabelEntities = new CRMTabelEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			DbSet<WSStockSupply> wSStockSupply = cRMTabelEntities.WSStockSupply;
			ParameterExpression val = Expression.Parameter(typeof(WSStockSupply), "m");
			WSStockSupply wSStockSupply2 = Queryable.FirstOrDefault<WSStockSupply>((IQueryable<WSStockSupply>)wSStockSupply, Expression.Lambda<Func<WSStockSupply, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass4_, typeof(_003C_003Ec__DisplayClass4_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (wSStockSupply2 != null)
			{
				result = wSStockSupply2.stsupCId;
				return result;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMTabelEntities?.Dispose();
		}
		return result;
	}

	public static int? GetStsupItemCId(int stsupItemId)
	{
		_003C_003Ec__DisplayClass5_0 _003C_003Ec__DisplayClass5_ = new _003C_003Ec__DisplayClass5_0();
		_003C_003Ec__DisplayClass5_.stsupItemId = stsupItemId;
		int? result = null;
		CRMTabelEntities cRMTabelEntities = new CRMTabelEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			DbSet<WSStockSupplyItems> wSStockSupplyItems = cRMTabelEntities.WSStockSupplyItems;
			ParameterExpression val = Expression.Parameter(typeof(WSStockSupplyItems), "m");
			WSStockSupplyItems wSStockSupplyItems2 = Queryable.FirstOrDefault<WSStockSupplyItems>((IQueryable<WSStockSupplyItems>)wSStockSupplyItems, Expression.Lambda<Func<WSStockSupplyItems, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass5_, typeof(_003C_003Ec__DisplayClass5_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (wSStockSupplyItems2 != null)
			{
				result = wSStockSupplyItems2.stsupICId;
				return result;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMTabelEntities?.Dispose();
		}
		return result;
	}

	public static bool IsVerified(int stsupId)
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
			WSspSelectStockSupplyById_Result wSspSelectStockSupplyById_Result = Enumerable.FirstOrDefault<WSspSelectStockSupplyById_Result>((IEnumerable<WSspSelectStockSupplyById_Result>)cRMSpIIEntities.WSspSelectStockSupplyById(stsupId, lCID, result2));
			if (wSspSelectStockSupplyById_Result != null)
			{
				result = wSspSelectStockSupplyById_Result.stsupIsVerified.GetValueOrDefault();
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
}
