using System;
using System.Collections.Generic;
using System.Linq;
using Elmah;
using Mobile.Models;

namespace Mobile.Classes.Helper;

public class User
{
	public static string GetUserName(int userId, int currLangId, int defLangId, int? cId = null)
	{
		CRMEntities cRMEntities = new CRMEntities();
		string result = "";
		try
		{
			MobspSelectUsersById_Result mobspSelectUsersById_Result = Enumerable.FirstOrDefault<MobspSelectUsersById_Result>((IEnumerable<MobspSelectUsersById_Result>)cRMEntities.MobspSelectUsersById(userId, currLangId, defLangId, cId));
			if (mobspSelectUsersById_Result != null)
			{
				result = ((!string.IsNullOrEmpty(mobspSelectUsersById_Result.FullName)) ? mobspSelectUsersById_Result.FullName : "");
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

	public static string AccessUserToCIds(string cIds, UserLoginInfo currUser)
	{
		string text = "";
		try
		{
			if (currUser != null && !string.IsNullOrWhiteSpace(cIds))
			{
				string text2 = currUser.UserCIds ?? "";
				if (!string.IsNullOrWhiteSpace(text2))
				{
					string[] array = cIds.Split(new char[1] { ',' });
					string[] array2 = text2.Split(new char[1] { ',' });
					if (array != null && array2 != null && array.Length != 0 && array2.Length != 0)
					{
						string[] array3 = array;
						foreach (string text3 in array3)
						{
							if (string.IsNullOrWhiteSpace(text3))
							{
								continue;
							}
							int result = 0;
							int.TryParse(text3, out result);
							if (result == 0)
							{
								continue;
							}
							string[] array4 = array2;
							foreach (string text4 in array4)
							{
								if (string.IsNullOrWhiteSpace(text4))
								{
									continue;
								}
								int result2 = 0;
								int.TryParse(text4, out result2);
								if (result2 != 0 && result2 == result)
								{
									if (!string.IsNullOrWhiteSpace(text))
									{
										text += ",";
									}
									text += result;
								}
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
		return text;
	}
}
