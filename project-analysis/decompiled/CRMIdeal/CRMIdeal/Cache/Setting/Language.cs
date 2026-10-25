using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using CRM.General.Cache;
using CRM.Models;
using CRMIdeal.Classes.Common;
using Elmah;

namespace CRMIdeal.Cache.Setting;

public static class Language
{
	private static readonly string MainCacheName = Configuration.CacheDefaultName + Configuration.CacheUniqueName + "-Setting-Language";

	private static readonly int DefaultTimeInMinutes = Configuration.CacheDefaultTimeInMinutes;

	public static List<Languages> Get()
	{
		List<Languages> value = new List<Languages>();
		CRMTabelEntities cRMTabelEntities = new CRMTabelEntities();
		try
		{
			if (!CacheManager.Get<List<Languages>>(MainCacheName, out value))
			{
				DbSet<Languages> languages = cRMTabelEntities.Languages;
				ParameterExpression val = Expression.Parameter(typeof(Languages), "c");
				IQueryable<Languages> obj = Queryable.Where<Languages>((IQueryable<Languages>)languages, Expression.Lambda<Func<Languages, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Convert((Expression)(object)Expression.Constant((object)true, typeof(bool)), typeof(bool?))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				val = Expression.Parameter(typeof(Languages), "c");
				value = Enumerable.ToList<Languages>((IEnumerable<Languages>)Queryable.OrderBy<Languages, int?>(obj, Expression.Lambda<Func<Languages, int?>>((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
				CacheManager.Add(value, MainCacheName, DefaultTimeInMinutes);
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
		return value;
	}

	public static bool Clear()
	{
		try
		{
			CacheManager.Clear(MainCacheName);
			return true;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return false;
	}

	public static bool Update()
	{
		try
		{
			CRMTabelEntities cRMTabelEntities = new CRMTabelEntities();
			DbSet<Languages> languages = cRMTabelEntities.Languages;
			ParameterExpression val = Expression.Parameter(typeof(Languages), "c");
			IQueryable<Languages> obj = Queryable.Where<Languages>((IQueryable<Languages>)languages, Expression.Lambda<Func<Languages, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Convert((Expression)(object)Expression.Constant((object)true, typeof(bool)), typeof(bool?))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			val = Expression.Parameter(typeof(Languages), "c");
			List<Languages> o = Enumerable.ToList<Languages>((IEnumerable<Languages>)Queryable.OrderBy<Languages, int?>(obj, Expression.Lambda<Func<Languages, int?>>((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
			cRMTabelEntities.Dispose();
			CacheManager.Clear(MainCacheName);
			CacheManager.Add(o, MainCacheName, DefaultTimeInMinutes);
			return true;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return false;
	}
}
