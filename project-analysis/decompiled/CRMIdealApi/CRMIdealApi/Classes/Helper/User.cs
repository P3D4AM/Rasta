using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using CRMIdealApi.ApiModels;
using Elmah;
using GSD.Globalization;

namespace CRMIdealApi.Classes.Helper;

public class User
{
	public static string GetUserName(int userId, int currLangId, int defLangId)
	{
		CRMEntities cRMEntities = new CRMEntities();
		string result = "";
		try
		{
			ApispSelectUsersById_Result apispSelectUsersById_Result = Enumerable.FirstOrDefault<ApispSelectUsersById_Result>((IEnumerable<ApispSelectUsersById_Result>)cRMEntities.ApispSelectUsersById(userId, currLangId, defLangId));
			if (apispSelectUsersById_Result != null)
			{
				result = ((!string.IsNullOrEmpty(apispSelectUsersById_Result.FullName)) ? apispSelectUsersById_Result.FullName : "");
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities.Dispose();
		}
		return result;
	}

	public static bool IsUserAccess(string formName, string actionName, int userId)
	{
		bool result = false;
		try
		{
			ObjectParameter objectParameter = new ObjectParameter("HasAction", false);
			CRMEntities cRMEntities = new CRMEntities();
			cRMEntities.ApispCheckActionForUser(formName, actionName, userId, objectParameter);
			if (objectParameter != null && !string.IsNullOrWhiteSpace(objectParameter.Value.ToString()))
			{
				bool.TryParse(objectParameter.Value.ToString(), out result);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public static void UpdateUsersMobBaseInfo(string updateDetail, int? userId = null, int? rollId = null)
	{
		CRMEntities cRMEntities = new CRMEntities();
		try
		{
			DateTime now = DateTime.Now;
			string text = now.ToString("yyyyMMdd", new PersianCulture());
			short num = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int num2 = cRMEntities.ApispNeedUpdateUsersMobBaseInfo(updateDetail, userId, rollId);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities.Dispose();
		}
	}
}
