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
public class Labels
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
				resourceMan = new ResourceManager("RegisterCompany.Resources.Labels", typeof(Labels).Assembly);
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

	public static string Person => ResourceManager.GetString("Person", resourceCulture);

	public static string PrsMobile => ResourceManager.GetString("PrsMobile", resourceCulture);

	public static string PrsPreTel => ResourceManager.GetString("PrsPreTel", resourceCulture);

	public static string PrsTel => ResourceManager.GetString("PrsTel", resourceCulture);

	public static string PrsTelUpTo => ResourceManager.GetString("PrsTelUpTo", resourceCulture);

	internal Labels()
	{
	}
}
