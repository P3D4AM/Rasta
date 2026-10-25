using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using CRM.General.Security;
using Elmah;
using Mobile.Cache.Setting;
using Mobile.Models;

namespace Mobile.Classes.Helper;

public class FoCenter
{
	public static FoSettingShareInfoViewModel GetFoSettingShareInfo(bool isSetCache = false)
	{
		FoSettingShareInfoViewModel foSettingShareInfoViewModel = new FoSettingShareInfoViewModel();
		try
		{
			if (isSetCache)
			{
				MobspSelectCrmsysSetting_Result mobspSelectCrmsysSetting_Result = SysSeting.Get();
				if (mobspSelectCrmsysSetting_Result != null)
				{
					foSettingShareInfoViewModel.FoSettingShareMode = mobspSelectCrmsysSetting_Result.FoSettingShareMode;
					foSettingShareInfoViewModel.FoSettingShareId = mobspSelectCrmsysSetting_Result.FoSettingShareId;
					foSettingShareInfoViewModel.FoSettingShareCId = mobspSelectCrmsysSetting_Result.FoSettingShareCId;
					foSettingShareInfoViewModel.FoSettingShareCenterName = mobspSelectCrmsysSetting_Result.FoSettingShareCenterName;
					int result = 0;
					int.TryParse(foSettingShareInfoViewModel.FoSettingShareMode.ToString(), out result);
					if (result == 2)
					{
						string path = AppDomain.CurrentDomain.BaseDirectory + "App_Data\\\\AppSetting\\\\AppSettingCId.txt";
						if (File.Exists(path))
						{
							using FileStream stream = new FileStream(path, FileMode.OpenOrCreate);
							string text = new StreamReader(stream).ReadToEnd();
							if (!string.IsNullOrWhiteSpace(text))
							{
								text = CodeDecode.DeCodding(text);
								if (text.IndexOf("AppSettingCId:{", StringComparison.Ordinal) >= 0)
								{
									_ = text.Length;
									int length = "AppSettingCId:{".Length;
									int length2 = text.IndexOf("}", StringComparison.Ordinal) - length;
									string text2 = text.Substring(text.IndexOf("AppSettingCId:{", StringComparison.Ordinal) + length, length2);
									if (!string.IsNullOrWhiteSpace(text2))
									{
										int result2 = 0;
										int.TryParse(text2, out result2);
										if (result2 != 0)
										{
											foSettingShareInfoViewModel.FoSettingShareCId = result2;
											foSettingShareInfoViewModel.FoSettingShareCenterName = Center.GetNames(result2.ToString()) ?? "";
											foSettingShareInfoViewModel.FoSettingShareId = GetCurrentFoSettingId(result2);
										}
									}
								}
							}
						}
					}
				}
			}
			else
			{
				foSettingShareInfoViewModel = FoSettingShareInfo.Get();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return foSettingShareInfoViewModel;
	}

	public static int? GetFoSettingShareCId()
	{
		int? result = null;
		try
		{
			FoSettingShareInfoViewModel foSettingShareInfo = GetFoSettingShareInfo();
			if (foSettingShareInfo != null)
			{
				result = foSettingShareInfo.FoSettingShareCId;
				return result;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public static int? GetCurrentCId(bool noCreateCmpCache = false)
	{
		int? result = null;
		try
		{
			int result2 = 0;
			if (string.IsNullOrWhiteSpace(Thread.CurrentPrincipal.Identity.Name) || noCreateCmpCache)
			{
				int.TryParse(GetFoSettingShareCId().ToString(), out result2);
			}
			else
			{
				int.TryParse(GetFoSettingShareCId().ToString(), out result2);
			}
			if (result2 != 0)
			{
				result = result2;
				return result;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public static int? GetCurrentFoSettingId(int selectedCId = 0)
	{
		int? result = null;
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			int num = 0;
			if (selectedCId != 0)
			{
				FOMobspSelectCrmFoSetting_Result fOMobspSelectCrmFoSetting_Result = Enumerable.FirstOrDefault<FOMobspSelectCrmFoSetting_Result>((IEnumerable<FOMobspSelectCrmFoSetting_Result>)cRMSpEntities.FOMobspSelectCrmFoSetting(1065, 1065, selectedCId, 0));
				if (fOMobspSelectCrmFoSetting_Result != null)
				{
					num = fOMobspSelectCrmFoSetting_Result.FoSettingId;
				}
			}
			if (num != 0)
			{
				result = num;
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
}
