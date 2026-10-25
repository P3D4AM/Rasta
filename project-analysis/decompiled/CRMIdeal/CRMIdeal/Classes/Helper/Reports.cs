using CRM.Models;
using CRM.Models.ReportModel;
using CRMIdeal.Cache.Setting;

namespace CRMIdeal.Classes.Helper;

public class Reports
{
	public CrmsysSettingRpt GetSysSetting()
	{
		CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
		CrmsysSettingRpt crmsysSettingRpt = new CrmsysSettingRpt();
		if (cRMspSelectCrmsysSetting_Result != null)
		{
			crmsysSettingRpt.ID = cRMspSelectCrmsysSetting_Result.ID;
			crmsysSettingRpt.CoName = cRMspSelectCrmsysSetting_Result.CoName;
			crmsysSettingRpt.CoLoGo = cRMspSelectCrmsysSetting_Result.CoLoGo;
			crmsysSettingRpt.Address = cRMspSelectCrmsysSetting_Result.Address;
			crmsysSettingRpt.Telephone = cRMspSelectCrmsysSetting_Result.Telephone;
			crmsysSettingRpt.Fax = cRMspSelectCrmsysSetting_Result.Fax;
			crmsysSettingRpt.Email = cRMspSelectCrmsysSetting_Result.Email;
			crmsysSettingRpt.WebSite = cRMspSelectCrmsysSetting_Result.WebSite;
			crmsysSettingRpt.ServerIP = cRMspSelectCrmsysSetting_Result.ServerIP;
			crmsysSettingRpt.UserId = cRMspSelectCrmsysSetting_Result.UserId;
			crmsysSettingRpt.Year1 = cRMspSelectCrmsysSetting_Result.Year1;
			crmsysSettingRpt.Month1 = cRMspSelectCrmsysSetting_Result.Month1;
			crmsysSettingRpt.RegisterDate = cRMspSelectCrmsysSetting_Result.RegisterDate;
			crmsysSettingRpt.SantralPreNumber = cRMspSelectCrmsysSetting_Result.SantralPreNumber;
			crmsysSettingRpt.CallerIDServerIP = cRMspSelectCrmsysSetting_Result.CallerIDServerIP;
			crmsysSettingRpt.ServiceSIP = cRMspSelectCrmsysSetting_Result.ServiceSIP;
			crmsysSettingRpt.ServiceSGIP = cRMspSelectCrmsysSetting_Result.ServiceSGIP;
			crmsysSettingRpt.RegistrationNumber = cRMspSelectCrmsysSetting_Result.RegistrationNumber;
			crmsysSettingRpt.EconomicCode = cRMspSelectCrmsysSetting_Result.EconomicCode;
			crmsysSettingRpt.NationalCode = cRMspSelectCrmsysSetting_Result.NationalCode;
			crmsysSettingRpt.QuickAddress = cRMspSelectCrmsysSetting_Result.QuickAddress;
			crmsysSettingRpt.LockSerial = cRMspSelectCrmsysSetting_Result.LockSerial;
			crmsysSettingRpt.LockCounter = cRMspSelectCrmsysSetting_Result.LockCounter;
			crmsysSettingRpt.LockNU = cRMspSelectCrmsysSetting_Result.LockNU;
			crmsysSettingRpt.LockControl = cRMspSelectCrmsysSetting_Result.LockControl;
			crmsysSettingRpt.AppFilePath = cRMspSelectCrmsysSetting_Result.AppFilePath;
			crmsysSettingRpt.GUId = cRMspSelectCrmsysSetting_Result.GUId;
			crmsysSettingRpt.ServiceCIIP = cRMspSelectCrmsysSetting_Result.ServiceCIIP;
			crmsysSettingRpt.PublicNotice = cRMspSelectCrmsysSetting_Result.PublicNotice;
			crmsysSettingRpt.ZipCode = cRMspSelectCrmsysSetting_Result.ZipCode;
			crmsysSettingRpt.ServiceFADeAc = cRMspSelectCrmsysSetting_Result.ServiceFADeAc;
			crmsysSettingRpt.RecordingVoiceServerIP = cRMspSelectCrmsysSetting_Result.RecordingVoiceServerIP;
			crmsysSettingRpt.ServiceRIP = cRMspSelectCrmsysSetting_Result.ServiceRIP;
			crmsysSettingRpt.CantSaveDupPrsMob = cRMspSelectCrmsysSetting_Result.CantSaveDupPrsMob;
			crmsysSettingRpt.CantSaveDupPrsEmail = cRMspSelectCrmsysSetting_Result.CantSaveDupPrsEmail;
			crmsysSettingRpt.MustFullcnvsRemindDate = cRMspSelectCrmsysSetting_Result.MustFullcnvsRemindDate;
			crmsysSettingRpt.CallerIDVersion = cRMspSelectCrmsysSetting_Result.CallerIDVersion;
			crmsysSettingRpt.CallerIDOldVersion = cRMspSelectCrmsysSetting_Result.CallerIDOldVersion;
			crmsysSettingRpt.SMSServiceVersion = cRMspSelectCrmsysSetting_Result.SMSServiceVersion;
			crmsysSettingRpt.SMSServiceOldVersion = cRMspSelectCrmsysSetting_Result.SMSServiceOldVersion;
			crmsysSettingRpt.ServiceBuyOrdIP = cRMspSelectCrmsysSetting_Result.ServiceBuyOrdIP;
			crmsysSettingRpt.ServiceEmailIP = cRMspSelectCrmsysSetting_Result.ServiceEmailIP;
			crmsysSettingRpt.ServiceLetterIP = cRMspSelectCrmsysSetting_Result.ServiceLetterIP;
			crmsysSettingRpt.AppType = cRMspSelectCrmsysSetting_Result.AppType;
			crmsysSettingRpt.DisablefrmcmpSearchOnType = cRMspSelectCrmsysSetting_Result.DisablefrmcmpSearchOnType;
			crmsysSettingRpt.SMSGSMServiceVersion = cRMspSelectCrmsysSetting_Result.SMSGSMServiceVersion;
			crmsysSettingRpt.SMSGSMServiceOldVersion = cRMspSelectCrmsysSetting_Result.SMSGSMServiceOldVersion;
			crmsysSettingRpt.LanguageID = cRMspSelectCrmsysSetting_Result.LanguageID;
			crmsysSettingRpt.DefaultLanguageID = cRMspSelectCrmsysSetting_Result.DefaultLanguageID;
			crmsysSettingRpt.FirstRegisterUserId = cRMspSelectCrmsysSetting_Result.FirstRegisterUserId;
			crmsysSettingRpt.FirstRegisterDatePersian = cRMspSelectCrmsysSetting_Result.FirstRegisterDatePersian;
			crmsysSettingRpt.FirstRegisterDate = cRMspSelectCrmsysSetting_Result.FirstRegisterDate;
			crmsysSettingRpt.CityId = cRMspSelectCrmsysSetting_Result.CityId;
			crmsysSettingRpt.CityName = cRMspSelectCrmsysSetting_Result.CityName;
			crmsysSettingRpt.ProvinceId = cRMspSelectCrmsysSetting_Result.ProvinceId;
			crmsysSettingRpt.ProvinceName = cRMspSelectCrmsysSetting_Result.ProvinceName;
			crmsysSettingRpt.CountryId = cRMspSelectCrmsysSetting_Result.CountryId;
			crmsysSettingRpt.CountryName = cRMspSelectCrmsysSetting_Result.CountryName;
		}
		return crmsysSettingRpt;
	}
}
