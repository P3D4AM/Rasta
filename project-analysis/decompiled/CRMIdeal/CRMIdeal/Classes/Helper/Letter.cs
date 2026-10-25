using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using CRM.Models;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes.Common;
using Elmah;
using Newtonsoft.Json;

namespace CRMIdeal.Classes.Helper;

public class Letter
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass0_0
	{
		public int letterId;
	}

	public static bool IsFixed(int letterId = 0, int? isEditAfterFixMode = null)
	{
		_003C_003Ec__DisplayClass0_0 _003C_003Ec__DisplayClass0_ = new _003C_003Ec__DisplayClass0_0();
		_003C_003Ec__DisplayClass0_.letterId = letterId;
		bool result = false;
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		CRMTabelEntities cRMTabelEntities = new CRMTabelEntities();
		try
		{
			DbSet<SecLetters> secLetters = cRMTabelEntities.SecLetters;
			ParameterExpression val = Expression.Parameter(typeof(SecLetters), "c");
			SecLetters secLetters2 = Queryable.FirstOrDefault<SecLetters>((IQueryable<SecLetters>)secLetters, Expression.Lambda<Func<SecLetters, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass0_, typeof(_003C_003Ec__DisplayClass0_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (secLetters2 != null && secLetters2.LetterIsFixed.HasValue && secLetters2.LetterIsFixed.GetValueOrDefault())
			{
				result = true;
			}
			if (IsEditAfterFix(secLetters2.LetterEditAfterFixInfoJs, _003C_003Ec__DisplayClass0_.letterId, isEditAfterFixMode))
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

	public static bool IsEditAfterFix(string editAfterFixInfoJs = "", int letterId = 0, int? mode = null)
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
			if (string.IsNullOrWhiteSpace(editAfterFixInfoJs) && letterId != 0)
			{
				SecspSelectLettersById_Result secspSelectLettersById_Result = Enumerable.FirstOrDefault<SecspSelectLettersById_Result>((IEnumerable<SecspSelectLettersById_Result>)cRMSpIIEntities.SecspSelectLettersById(letterId, lCID, result2));
				if (secspSelectLettersById_Result != null)
				{
					editAfterFixInfoJs = secspSelectLettersById_Result.LetterEditAfterFixInfoJs;
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

	public static bool IsVerified(int letterId)
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
			SecspSelectLettersById_Result secspSelectLettersById_Result = Enumerable.FirstOrDefault<SecspSelectLettersById_Result>((IEnumerable<SecspSelectLettersById_Result>)cRMSpIIEntities.SecspSelectLettersById(letterId, lCID, result2));
			if (secspSelectLettersById_Result != null)
			{
				result = secspSelectLettersById_Result.LetterIsVerified.GetValueOrDefault();
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
