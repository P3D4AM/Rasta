using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using CRM.Models;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes.Common;
using CRMIdeal.GSD.Globalization;
using Elmah;

namespace CRMIdeal.Classes.Helper;

public class User
{
	public static void UpdateUsersMobBaseInfo(string updateDetail, int? userId = null, int? rollId = null)
	{
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			_ = UserLogin.CurrentUser.UserId;
			DateTime now = DateTime.Now;
			now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			cRMSpEntities.CRMspNeedUpdateUsersMobBaseInfo(updateDetail, userId, rollId);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities.Dispose();
		}
	}

	public static string CodeQRBarcode(string qrBarcode)
	{
		string result = "";
		try
		{
			if (!string.IsNullOrWhiteSpace(qrBarcode))
			{
				string text = "CRMIdealTimeAttendance";
				string text2 = DateTime.Now.ToString("fffss");
				string text3 = new Random().Next(1000, 9999).ToString();
				result = text + "-" + text2 + qrBarcode + text3;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public static string DecodeQRBarcode(string qrBarcode)
	{
		string text = "";
		try
		{
			if (!string.IsNullOrWhiteSpace(qrBarcode))
			{
				string text2 = "CRMIdealTimeAttendance";
				DateTime.Now.ToString("fffss");
				new Random().Next(1000, 9999).ToString();
				text = qrBarcode.Replace(text2 + "-", "");
				text = text.Substring(5);
				text = text.Substring(0, text.Length - 4);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return text;
	}

	public static string GetUserName(int userId, int currLangId, int defLangId)
	{
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		string result = "";
		try
		{
			CRMspSelectUsersById_Result cRMspSelectUsersById_Result = SelectUsersById(userId, -1, currLangId, defLangId);
			if (cRMspSelectUsersById_Result != null)
			{
				result = ((!string.IsNullOrEmpty(cRMspSelectUsersById_Result.FullName)) ? cRMspSelectUsersById_Result.FullName : "");
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

	public static bool CheckUserImeiCode(int userId, string imei, string appName)
	{
		if (string.IsNullOrEmpty(imei) || string.IsNullOrEmpty(appName))
		{
			return true;
		}
		CRMSpIEntities cRMSpIEntities = null;
		bool result = false;
		try
		{
			cRMSpIEntities = new CRMSpIEntities();
			result = Enumerable.Any<CRMspSelectUserAppDeviceInfoByUserId_Result>((IEnumerable<CRMspSelectUserAppDeviceInfoByUserId_Result>)Enumerable.ToList<CRMspSelectUserAppDeviceInfoByUserId_Result>((IEnumerable<CRMspSelectUserAppDeviceInfoByUserId_Result>)cRMSpIEntities.CRMspSelectUserAppDeviceInfoByUserId(userId, appName)), (Func<CRMspSelectUserAppDeviceInfoByUserId_Result, bool>)((CRMspSelectUserAppDeviceInfoByUserId_Result e) => e.ImeiCode == imei));
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		finally
		{
			cRMSpIEntities?.Dispose();
		}
		return result;
	}

	public static void UpdateUserLastCId(int userId, int cId)
	{
		CRMSpIIEntities cRMSpIIEntities = null;
		try
		{
			cRMSpIIEntities = new CRMSpIIEntities();
			cRMSpIIEntities.CRMspUpdateUserLastCId(userId, cId);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpIIEntities?.Dispose();
		}
	}

	public static void UpdateUserLastCIdForFirst(int userId, string userCId)
	{
		try
		{
			if (string.IsNullOrWhiteSpace(userCId))
			{
				return;
			}
			string[] array = userCId.Split(new char[1] { ',' });
			if (array == null || array.Length == 0)
			{
				return;
			}
			bool flag = false;
			string[] array2 = array;
			foreach (string text in array2)
			{
				if (!string.IsNullOrWhiteSpace(text) && !flag)
				{
					int result = 0;
					int.TryParse(text, out result);
					if (result != 0)
					{
						UpdateUserLastCId(userId, result);
						flag = true;
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}

	public static int GetUserLastCId(int userId, int currLangId, int defLangId)
	{
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		int result = 0;
		try
		{
			CRMspSelectUsersById_Result cRMspSelectUsersById_Result = SelectUsersById(userId, -1, currLangId, defLangId);
			if (cRMspSelectUsersById_Result != null)
			{
				int.TryParse(cRMspSelectUsersById_Result.UserLastCId.ToString(), out result);
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

	public static List<CRMspSelectUsersByIds_Result> SelectUsersByIds(string userIds, string seperator = ",")
	{
		List<CRMspSelectUsersByIds_Result> list = new List<CRMspSelectUsersByIds_Result>();
		CRMSpIEntities cRMSpIEntities = new CRMSpIEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			list = Enumerable.ToList<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)cRMSpIEntities.CRMspSelectUsersByIds(userIds, seperator, lCID, result, result2));
			if (list == null)
			{
				list = new List<CRMspSelectUsersByIds_Result>();
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
		return list;
	}

	public static List<CRMspSelectUsers_Result> SelectUsers(int userLastCId = -1)
	{
		List<CRMspSelectUsers_Result> list = new List<CRMspSelectUsers_Result>();
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (userLastCId == -1)
			{
				if (UserLogin.CurrentUser != null)
				{
					int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out userLastCId);
				}
				if (userLastCId == -1)
				{
					userLastCId = 0;
				}
			}
			list = Enumerable.ToList<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)cRMSpEntities.CRMspSelectUsers(lCID, result, userLastCId));
			if (list == null)
			{
				list = new List<CRMspSelectUsers_Result>();
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
		return list;
	}

	public static string AccessUserToCIds(string cIds)
	{
		string text = "";
		try
		{
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (currentUser != null && !string.IsNullOrWhiteSpace(cIds))
			{
				string text2 = currentUser.UserCIds ?? "";
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

	public static List<CRMspSelectActiveUsers_Result> SelectActiveUsers(int userLastCId = -1)
	{
		List<CRMspSelectActiveUsers_Result> list = new List<CRMspSelectActiveUsers_Result>();
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (userLastCId == -1)
			{
				if (UserLogin.CurrentUser != null)
				{
					int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out userLastCId);
				}
				if (userLastCId == -1)
				{
					userLastCId = 0;
				}
			}
			list = Enumerable.ToList<CRMspSelectActiveUsers_Result>((IEnumerable<CRMspSelectActiveUsers_Result>)cRMSpEntities.CRMspSelectActiveUsers(lCID, result, userLastCId));
			if (list == null)
			{
				list = new List<CRMspSelectActiveUsers_Result>();
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
		return list;
	}

	public static CRMspSelectUsersById_Result SelectUsersById(int userId, int userLastCId = -1, int currLangId = 0, int defLangId = 0)
	{
		CRMspSelectUsersById_Result result = new CRMspSelectUsersById_Result();
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
			if (userLastCId == -1)
			{
				if (UserLogin.CurrentUser != null)
				{
					int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out userLastCId);
				}
				if (userLastCId == -1)
				{
					userLastCId = 0;
				}
			}
			result = Enumerable.FirstOrDefault<CRMspSelectUsersById_Result>((IEnumerable<CRMspSelectUsersById_Result>)cRMSpEntities.CRMspSelectUsersById(userId, currLangId, defLangId, userLastCId));
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
}
