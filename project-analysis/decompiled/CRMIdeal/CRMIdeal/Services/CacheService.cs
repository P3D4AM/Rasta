using System.ServiceModel.Activation;
using CRMIdeal.Cache;

namespace CRMIdeal.Services;

[AspNetCompatibilityRequirements(/*Could not decode attribute arguments.*/)]
public class CacheService : ICacheService
{
	public bool UpdateSettings(string username, string password)
	{
		if (username == "Shir" && password == "Palang")
		{
			return Manager.UpdateAllSettingCach();
		}
		return false;
	}

	public bool UpdateUser(string username, string password, int userId)
	{
		if (username == "Shir" && password == "Palang")
		{
			return Manager.UpdateAllUserCach(userId);
		}
		return false;
	}

	public bool ClearAll(string username, string password)
	{
		if (username == "Shir" && password == "Palang")
		{
			return Manager.ClearAllCach();
		}
		return false;
	}

	public bool ClearUser(string username, string password, int userId)
	{
		if (username == "Shir" && password == "Palang")
		{
			return Manager.ClearAllUserCach(userId);
		}
		return false;
	}

	public bool ClearSetting(string username, string password)
	{
		if (username == "Shir" && password == "Palang")
		{
			return Manager.ClearAllSettingCach();
		}
		return false;
	}
}
