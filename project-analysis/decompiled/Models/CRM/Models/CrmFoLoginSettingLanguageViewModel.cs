using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmFoLoginSettingLanguageViewModel
{
	[Key]
	public int FoSettingId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingLoginTitle")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string LoginTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingLoginFormTitle")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string LoginFormTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingLoginBgImagePath")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string LoginBgImagePath { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingLoginBgColor")]
	[MaxLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string LoginBgColor { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingLoginBtnBgColor")]
	[MaxLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string LoginBtnBgColor { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingLoginBtnFontColor")]
	[MaxLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string LoginBtnFontColor { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingLoginLinkColor")]
	[MaxLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string LoginLinkColor { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingLoginRegLinkTitle")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string LoginRegLinkTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingLoginPosition")]
	public int? LoginPosition { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingLoginTextBorderColor")]
	[MaxLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string LoginTextBorderFColor { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingLoginTextBorderColor")]
	[MaxLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string LoginTextBorderTColor { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingLoginRegBtnHide")]
	public bool? LoginRegBtnHide { get; set; }

	public string LoginTitle_Lang { get; set; }

	public string LoginFormTitle_Lang { get; set; }

	public string LoginRegLinkTitle_Lang { get; set; }

	public string LoginAuthenticationType { get; set; }

	public string LoginType { get; set; }

	public bool? LoginSendOTPSms { get; set; }

	public string LoginSendOTPSmsBodyPatternFormula { get; set; }

	public string LoginAuthenticationInfoJson { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingLoginByPassword")]
	public bool? LoginByPassword { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingLoginByOTP")]
	public bool? LoginByOTP { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingLoginByOTPSmsBodyPatternFormula")]
	public string LoginByOTPSmsBodyPatternFormula { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingLoginAndFoActive")]
	public bool? LoginAndFoActive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingLoginAndShpActive")]
	public bool? LoginAndShpActive { get; set; }
}
