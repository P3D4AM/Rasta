using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Mobile.Properties;

[CompilerGenerated]
[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.0.3.0")]
internal sealed class Settings : ApplicationSettingsBase
{
	private static Settings defaultInstance = (Settings)(object)SettingsBase.Synchronized((SettingsBase)(object)new Settings());

	public static Settings Default => defaultInstance;

	[ApplicationScopedSetting]
	[DebuggerNonUserCode]
	[SpecialSetting(/*Could not decode attribute arguments.*/)]
	[DefaultSettingValue("http://176.62.145.9/index.php")]
	public string Mobile_ir_smsline_webservice_SMS_WebServer_Service => (string)((SettingsBase)this)["Mobile_ir_smsline_webservice_SMS_WebServer_Service"];

	[ApplicationScopedSetting]
	[DebuggerNonUserCode]
	[SpecialSetting(/*Could not decode attribute arguments.*/)]
	[DefaultSettingValue("https://www.payam-resan.com/ws/v2/ws.asmx")]
	public string Mobile_SmsPayamResan_SmsV2 => (string)((SettingsBase)this)["Mobile_SmsPayamResan_SmsV2"];

	[ApplicationScopedSetting]
	[DebuggerNonUserCode]
	[SpecialSetting(/*Could not decode attribute arguments.*/)]
	[DefaultSettingValue("http://api.kavenegar.com/soap/v1.asmx")]
	public string Mobile_SmsKaveNegar_v1 => (string)((SettingsBase)this)["Mobile_SmsKaveNegar_v1"];

	[ApplicationScopedSetting]
	[DebuggerNonUserCode]
	[SpecialSetting(/*Could not decode attribute arguments.*/)]
	[DefaultSettingValue("http://www.smsfor.ir/webservice/soap/smsService.php")]
	public string Mobile_SmsFor_SmsPanelWebservice => (string)((SettingsBase)this)["Mobile_SmsFor_SmsPanelWebservice"];

	[ApplicationScopedSetting]
	[DebuggerNonUserCode]
	[SpecialSetting(/*Could not decode attribute arguments.*/)]
	[DefaultSettingValue("http://services.smsafzar.com/smsWebService.asmx")]
	public string Mobile_SmsAfzar_smsWebService => (string)((SettingsBase)this)["Mobile_SmsAfzar_smsWebService"];
}
