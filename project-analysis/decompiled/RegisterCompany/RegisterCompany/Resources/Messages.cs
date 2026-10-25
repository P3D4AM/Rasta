using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace RegisterCompany.Resources;

[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
[DebuggerNonUserCode]
[CompilerGenerated]
public class Messages
{
	private static ResourceManager resourceMan;

	private static CultureInfo resourceCulture;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public static ResourceManager ResourceManager
	{
		get
		{
			if (resourceMan == null)
			{
				resourceMan = new ResourceManager("RegisterCompany.Resources.Messages", typeof(Messages).Assembly);
			}
			return resourceMan;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public static CultureInfo Culture
	{
		get
		{
			return resourceCulture;
		}
		set
		{
			resourceCulture = value;
		}
	}

	public static string CheckDigit => ResourceManager.GetString("CheckDigit", resourceCulture);

	public static string CheckLenMob => ResourceManager.GetString("CheckLenMob", resourceCulture);

	public static string CheckMobileFormat => ResourceManager.GetString("CheckMobileFormat", resourceCulture);

	public static string CheckPreTelForNotMobile => ResourceManager.GetString("CheckPreTelForNotMobile", resourceCulture);

	public static string DubClickDisplayCmpInfo => ResourceManager.GetString("DubClickDisplayCmpInfo", resourceCulture);

	public static string ErjaConversationDescription => ResourceManager.GetString("ErjaConversationDescription", resourceCulture);

	public static string ErjaDetails => ResourceManager.GetString("ErjaDetails", resourceCulture);

	public static string ErjaFrom => ResourceManager.GetString("ErjaFrom", resourceCulture);

	public static string ErjaInConnection => ResourceManager.GetString("ErjaInConnection", resourceCulture);

	public static string ErjaMultiUser => ResourceManager.GetString("ErjaMultiUser", resourceCulture);

	public static string ErjaPerson => ResourceManager.GetString("ErjaPerson", resourceCulture);

	public static string ErjaProject => ResourceManager.GetString("ErjaProject", resourceCulture);

	public static string ErjaReferDescription => ResourceManager.GetString("ErjaReferDescription", resourceCulture);

	public static string ErjaRonevesht => ResourceManager.GetString("ErjaRonevesht", resourceCulture);

	public static string ErrorCheckCmpCodeDuplicate => ResourceManager.GetString("ErrorCheckCmpCodeDuplicate", resourceCulture);

	public static string ErrorCheckPrsEmailDuplicate => ResourceManager.GetString("ErrorCheckPrsEmailDuplicate", resourceCulture);

	public static string ErrorCheckPrsMobileDuplicate => ResourceManager.GetString("ErrorCheckPrsMobileDuplicate", resourceCulture);

	public static string ErrorDoneOperation => ResourceManager.GetString("ErrorDoneOperation", resourceCulture);

	public static string ErrorDoneOperationTryAgain => ResourceManager.GetString("ErrorDoneOperationTryAgain", resourceCulture);

	public static string ErrorEmailAlreadyRegistered => ResourceManager.GetString("ErrorEmailAlreadyRegistered", resourceCulture);

	public static string ErrorEmailIIAlreadyRegistered => ResourceManager.GetString("ErrorEmailIIAlreadyRegistered", resourceCulture);

	public static string ErrorInInsertCompany => ResourceManager.GetString("ErrorInInsertCompany", resourceCulture);

	public static string ErrorInInsertConversation => ResourceManager.GetString("ErrorInInsertConversation", resourceCulture);

	public static string ErrorInInsertPerson => ResourceManager.GetString("ErrorInInsertPerson", resourceCulture);

	public static string ErrorInInsertProject => ResourceManager.GetString("ErrorInInsertProject", resourceCulture);

	public static string ErrorInReadingFoSetting => ResourceManager.GetString("ErrorInReadingFoSetting", resourceCulture);

	public static string ErrorInReadingSysSetting => ResourceManager.GetString("ErrorInReadingSysSetting", resourceCulture);

	public static string ErrorMobileAlreadyRegistered => ResourceManager.GetString("ErrorMobileAlreadyRegistered", resourceCulture);

	public static string ErrorPrsLNameNotEntered => ResourceManager.GetString("ErrorPrsLNameNotEntered", resourceCulture);

	public static string ErrorPrsMobEmailNotEntered => ResourceManager.GetString("ErrorPrsMobEmailNotEntered", resourceCulture);

	public static string ErrorTryAgain => ResourceManager.GetString("ErrorTryAgain", resourceCulture);

	public static string ErrorUsernameIsRepeat => ResourceManager.GetString("ErrorUsernameIsRepeat", resourceCulture);

	public static string ErrorUsernamePasswordIncorrect => ResourceManager.GetString("ErrorUsernamePasswordIncorrect", resourceCulture);

	public static string SuccessDoneRegister => ResourceManager.GetString("SuccessDoneRegister", resourceCulture);

	internal Messages()
	{
	}
}
