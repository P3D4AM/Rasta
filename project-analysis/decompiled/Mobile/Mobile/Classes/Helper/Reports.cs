using Mobile.Cache.Setting;
using Mobile.Models;
using Mobile.Models.ReportModel;

namespace Mobile.Classes.Helper;

public class Reports
{
	public CrmsysSettingRpt GetSysSetting()
	{
		MobspSelectCrmsysSetting_Result mobspSelectCrmsysSetting_Result = SysSeting.Get();
		CrmsysSettingRpt crmsysSettingRpt = new CrmsysSettingRpt();
		if (mobspSelectCrmsysSetting_Result != null)
		{
			crmsysSettingRpt.ID = mobspSelectCrmsysSetting_Result.ID;
			crmsysSettingRpt.CoName = mobspSelectCrmsysSetting_Result.CoName;
			crmsysSettingRpt.CoLoGo = mobspSelectCrmsysSetting_Result.CoLoGo;
			crmsysSettingRpt.Address = mobspSelectCrmsysSetting_Result.Address;
			crmsysSettingRpt.Telephone = mobspSelectCrmsysSetting_Result.Telephone;
			crmsysSettingRpt.Fax = mobspSelectCrmsysSetting_Result.Fax;
			crmsysSettingRpt.Email = mobspSelectCrmsysSetting_Result.Email;
			crmsysSettingRpt.WebSite = mobspSelectCrmsysSetting_Result.WebSite;
			crmsysSettingRpt.ServerIP = mobspSelectCrmsysSetting_Result.ServerIP;
			crmsysSettingRpt.UserId = mobspSelectCrmsysSetting_Result.UserId;
			crmsysSettingRpt.Year1 = mobspSelectCrmsysSetting_Result.Year1;
			crmsysSettingRpt.Month1 = mobspSelectCrmsysSetting_Result.Month1;
			crmsysSettingRpt.RegisterDate = mobspSelectCrmsysSetting_Result.RegisterDate;
			crmsysSettingRpt.SantralPreNumber = mobspSelectCrmsysSetting_Result.SantralPreNumber;
			crmsysSettingRpt.CallerIDServerIP = mobspSelectCrmsysSetting_Result.CallerIDServerIP;
			crmsysSettingRpt.ServiceSIP = mobspSelectCrmsysSetting_Result.ServiceSIP;
			crmsysSettingRpt.ServiceSGIP = mobspSelectCrmsysSetting_Result.ServiceSGIP;
			crmsysSettingRpt.RegistrationNumber = mobspSelectCrmsysSetting_Result.RegistrationNumber;
			crmsysSettingRpt.EconomicCode = mobspSelectCrmsysSetting_Result.EconomicCode;
			crmsysSettingRpt.NationalCode = mobspSelectCrmsysSetting_Result.NationalCode;
			crmsysSettingRpt.QuickAddress = mobspSelectCrmsysSetting_Result.QuickAddress;
			crmsysSettingRpt.LockSerial = mobspSelectCrmsysSetting_Result.LockSerial;
			crmsysSettingRpt.LockCounter = mobspSelectCrmsysSetting_Result.LockCounter;
			crmsysSettingRpt.LockNU = mobspSelectCrmsysSetting_Result.LockNU;
			crmsysSettingRpt.LockControl = mobspSelectCrmsysSetting_Result.LockControl;
			crmsysSettingRpt.AppFilePath = mobspSelectCrmsysSetting_Result.AppFilePath;
			crmsysSettingRpt.GUId = mobspSelectCrmsysSetting_Result.GUId;
			crmsysSettingRpt.ServiceCIIP = mobspSelectCrmsysSetting_Result.ServiceCIIP;
			crmsysSettingRpt.PublicNotice = mobspSelectCrmsysSetting_Result.PublicNotice;
			crmsysSettingRpt.ZipCode = mobspSelectCrmsysSetting_Result.ZipCode;
			crmsysSettingRpt.ServiceFADeAc = mobspSelectCrmsysSetting_Result.ServiceFADeAc;
			crmsysSettingRpt.RecordingVoiceServerIP = mobspSelectCrmsysSetting_Result.RecordingVoiceServerIP;
			crmsysSettingRpt.ServiceRIP = mobspSelectCrmsysSetting_Result.ServiceRIP;
			crmsysSettingRpt.CantSaveDupPrsMob = mobspSelectCrmsysSetting_Result.CantSaveDupPrsMob;
			crmsysSettingRpt.CantSaveDupPrsEmail = mobspSelectCrmsysSetting_Result.CantSaveDupPrsEmail;
			crmsysSettingRpt.MustFullcnvsRemindDate = mobspSelectCrmsysSetting_Result.MustFullcnvsRemindDate;
			crmsysSettingRpt.CallerIDVersion = mobspSelectCrmsysSetting_Result.CallerIDVersion;
			crmsysSettingRpt.CallerIDOldVersion = mobspSelectCrmsysSetting_Result.CallerIDOldVersion;
			crmsysSettingRpt.SMSServiceVersion = mobspSelectCrmsysSetting_Result.SMSServiceVersion;
			crmsysSettingRpt.SMSServiceOldVersion = mobspSelectCrmsysSetting_Result.SMSServiceOldVersion;
			crmsysSettingRpt.ServiceBuyOrdIP = mobspSelectCrmsysSetting_Result.ServiceBuyOrdIP;
			crmsysSettingRpt.ServiceEmailIP = mobspSelectCrmsysSetting_Result.ServiceEmailIP;
			crmsysSettingRpt.ServiceLetterIP = mobspSelectCrmsysSetting_Result.ServiceLetterIP;
			crmsysSettingRpt.AppType = mobspSelectCrmsysSetting_Result.AppType;
			crmsysSettingRpt.DisablefrmcmpSearchOnType = mobspSelectCrmsysSetting_Result.DisablefrmcmpSearchOnType;
			crmsysSettingRpt.SMSGSMServiceVersion = mobspSelectCrmsysSetting_Result.SMSGSMServiceVersion;
			crmsysSettingRpt.SMSGSMServiceOldVersion = mobspSelectCrmsysSetting_Result.SMSGSMServiceOldVersion;
			crmsysSettingRpt.LanguageID = mobspSelectCrmsysSetting_Result.LanguageID;
			crmsysSettingRpt.DefaultLanguageID = mobspSelectCrmsysSetting_Result.DefaultLanguageID;
			crmsysSettingRpt.FirstRegisterUserId = mobspSelectCrmsysSetting_Result.FirstRegisterUserId;
			crmsysSettingRpt.FirstRegisterDatePersian = mobspSelectCrmsysSetting_Result.FirstRegisterDatePersian;
			crmsysSettingRpt.FirstRegisterDate = mobspSelectCrmsysSetting_Result.FirstRegisterDate;
		}
		return crmsysSettingRpt;
	}
}
