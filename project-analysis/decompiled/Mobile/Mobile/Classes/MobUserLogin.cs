using System;
using Elmah;
using Mobile.Cache.MobUser;
using Mobile.Models;

namespace Mobile.Classes;

public static class MobUserLogin
{
	public static UserLoginInfo CurrentUser
	{
		get
		{
			UserLoginInfo result = null;
			try
			{
				result = Info.Get();
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
			return result;
		}
	}
}
