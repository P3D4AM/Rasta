using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.Objects;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.General.Calendar;
using CRM.General.IO;
using CRM.General.IO.FTP;
using CRM.General.Security;
using CRM.General.Utilities;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Areas.Company.Controllers;
using CRMIdeal.Areas.OtherSystems.Controllers;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Cache.User;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Newtonsoft.Json;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace CRMIdeal.Areas.Products.Controllers;

public class DetailsController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass122_0
	{
		public int prdId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass130_0
	{
		public int prdPriceId;

		public int currLangID;

		internal bool _003CProductsPriceEdit_003Eb__2(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CProductsPriceEdit_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CProductsPriceEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass131_0
	{
		public int defLangID;

		public WSProductPriceLanguageViewModel model;

		public Func<Languages, bool> _003C_003E9__4;

		internal bool _003CProductsPriceEdit_003Eb__2(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CProductsPriceEdit_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CProductsPriceEdit_003Eb__4(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass131_1
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass131_0 CS_0024_003C_003E8__locals1;

		internal bool _003CProductsPriceEdit_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductsPriceEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductsPriceEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductsPriceEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass136_0
	{
		public int prdCostId;

		public int currLangID;

		internal bool _003CProductsCostEdit_003Eb__2(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CProductsCostEdit_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CProductsCostEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass137_0
	{
		public int defLangID;

		public WSProductCostLanguageViewModel model;

		public Func<Languages, bool> _003C_003E9__4;

		internal bool _003CProductsCostEdit_003Eb__2(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CProductsCostEdit_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CProductsCostEdit_003Eb__4(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass137_1
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass137_0 CS_0024_003C_003E8__locals1;

		internal bool _003CProductsCostEdit_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductsCostEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductsCostEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductsCostEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass141_0
	{
		public int id;

		public int currLangID;

		internal bool _003CProductCostGroupEdit_003Eb__2(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CProductCostGroupEdit_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CProductCostGroupEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass142_0
	{
		public WSProductCostGroupLanguageViewModel model;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__5;

		internal bool _003CProductCostGroupEdit_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CProductCostGroupEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CProductCostGroupEdit_003Eb__5(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass142_1
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass142_0 CS_0024_003C_003E8__locals1;

		internal bool _003CProductCostGroupEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductCostGroupEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductCostGroupEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductCostGroupEdit_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass143_0
	{
		public WSProductCostGroup item;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass147_0
	{
		public int id;

		public int currLangID;

		internal bool _003CProductPriceGroupEdit_003Eb__2(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CProductPriceGroupEdit_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CProductPriceGroupEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass148_0
	{
		public WSProductPriceGroupLanguageViewModel model;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__5;

		internal bool _003CProductPriceGroupEdit_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CProductPriceGroupEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CProductPriceGroupEdit_003Eb__5(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass148_1
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass148_0 CS_0024_003C_003E8__locals1;

		internal bool _003CProductPriceGroupEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductPriceGroupEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductPriceGroupEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductPriceGroupEdit_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass149_0
	{
		public WSProductPriceGroup item;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass154_0
	{
		public int id;

		public int currLangID;

		internal bool _003CCurrencyUnitEdit_003Eb__2(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CCurrencyUnitEdit_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CCurrencyUnitEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass155_0
	{
		public WSCurrencyUnitsLanguageViewModel model;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__5;

		internal bool _003CCurrencyUnitEdit_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CCurrencyUnitEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CCurrencyUnitEdit_003Eb__5(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass155_1
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass155_0 CS_0024_003C_003E8__locals1;

		internal bool _003CCurrencyUnitEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CCurrencyUnitEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CCurrencyUnitEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CCurrencyUnitEdit_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass27_0
	{
		public int prdId;

		public int currLangID;

		public WSProductsLanguageViewModel model;

		public WSspSelectWSProductSecondGroup_Result secondGrp;

		internal bool _003CProductEdit_003Eb__18(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CProductEdit_003Eb__19(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CProductEdit_003Eb__20(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CProductEdit_003Eb__21(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CProductEdit_003Eb__22(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CProductEdit_003Eb__23(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CProductEdit_003Eb__24(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CProductEdit_003Eb__25(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CProductEdit_003Eb__26(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CProductEdit_003Eb__27(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CProductEdit_003Eb__28(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CProductEdit_003Eb__29(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CProductEdit_003Eb__30(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CProductEdit_003Eb__31(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CProductEdit_003Eb__32(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CProductEdit_003Eb__33(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CProductEdit_003Eb__34(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CProductEdit_003Eb__35(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CProductEdit_003Eb__36(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CProductEdit_003Eb__37(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CProductEdit_003Eb__38(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CProductEdit_003Eb__39(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CProductEdit_003Eb__40(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CProductEdit_003Eb__41(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CProductEdit_003Eb__42(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CProductEdit_003Eb__43(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CProductEdit_003Eb__44(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CProductEdit_003Eb__45(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CProductEdit_003Eb__46(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CProductEdit_003Eb__47(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CProductEdit_003Eb__48(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CProductEdit_003Eb__49(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CProductEdit_003Eb__50(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CProductEdit_003Eb__51(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CProductEdit_003Eb__52(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CProductEdit_003Eb__53(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CProductEdit_003Eb__54(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CProductEdit_003Eb__55(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CProductEdit_003Eb__56(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CProductEdit_003Eb__57(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CProductEdit_003Eb__58(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CProductEdit_003Eb__59(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CProductEdit_003Eb__2(WSspSelectWSProductSecondGroup_Result c)
		{
			return c.PrdSecondGroupID == model.PrdGroupID;
		}

		internal bool _003CProductEdit_003Eb__3(WSspSelectProductFirstGroup_Result c)
		{
			return c.PrdFirstGroupID == secondGrp.FirstGroupId;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass28_0
	{
		public WSProductsLanguageViewModel model;

		public WSspSelectWSProductSecondGroup_Result secondGrp;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__35;

		internal bool _003CProductEdit_003Eb__0(WSspSelectWSProductSecondGroup_Result c)
		{
			return c.PrdSecondGroupID == model.PrdGroupID;
		}

		internal bool _003CProductEdit_003Eb__1(WSspSelectProductFirstGroup_Result c)
		{
			return c.PrdFirstGroupID == secondGrp.FirstGroupId;
		}

		internal bool _003CProductEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CProductEdit_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CProductEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CProductEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CProductEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CProductEdit_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CProductEdit_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CProductEdit_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CProductEdit_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CProductEdit_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CProductEdit_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CProductEdit_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CProductEdit_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CProductEdit_003Eb__18(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CProductEdit_003Eb__19(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CProductEdit_003Eb__20(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CProductEdit_003Eb__21(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CProductEdit_003Eb__22(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CProductEdit_003Eb__23(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CProductEdit_003Eb__24(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CProductEdit_003Eb__25(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CProductEdit_003Eb__26(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CProductEdit_003Eb__27(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CProductEdit_003Eb__28(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CProductEdit_003Eb__29(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CProductEdit_003Eb__30(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CProductEdit_003Eb__31(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CProductEdit_003Eb__32(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CProductEdit_003Eb__33(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CProductEdit_003Eb__34(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CProductEdit_003Eb__35(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass28_1
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass28_0 CS_0024_003C_003E8__locals1;

		internal bool _003CProductEdit_003Eb__37(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductEdit_003Eb__38(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductEdit_003Eb__39(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductEdit_003Eb__40(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductEdit_003Eb__41(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductEdit_003Eb__42(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductEdit_003Eb__43(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductEdit_003Eb__44(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductEdit_003Eb__45(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductEdit_003Eb__46(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductEdit_003Eb__47(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductEdit_003Eb__48(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductEdit_003Eb__49(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductEdit_003Eb__50(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductEdit_003Eb__51(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductEdit_003Eb__52(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductEdit_003Eb__53(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductEdit_003Eb__54(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductEdit_003Eb__55(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductEdit_003Eb__56(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductEdit_003Eb__57(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductEdit_003Eb__58(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductEdit_003Eb__59(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductEdit_003Eb__60(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductEdit_003Eb__61(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductEdit_003Eb__62(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductEdit_003Eb__63(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductEdit_003Eb__64(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductEdit_003Eb__65(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductEdit_003Eb__66(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductEdit_003Eb__67(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductEdit_003Eb__68(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductEdit_003Eb__69(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductEdit_003Eb__70(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductEdit_003Eb__71(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductEdit_003Eb__72(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductEdit_003Eb__73(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductEdit_003Eb__74(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductEdit_003Eb__75(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductEdit_003Eb__76(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductEdit_003Eb__77(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductEdit_003Eb__78(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductEdit_003Eb__79(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductEdit_003Eb__80(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductEdit_003Eb__81(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductEdit_003Eb__82(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductEdit_003Eb__83(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductEdit_003Eb__84(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductEdit_003Eb__85(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductEdit_003Eb__86(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductEdit_003Eb__87(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductEdit_003Eb__88(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductEdit_003Eb__89(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductEdit_003Eb__90(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductEdit_003Eb__91(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductEdit_003Eb__92(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass29_0
	{
		public int prdId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass30_0
	{
		public int prdSepId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass34_0
	{
		public int prdSepId;

		public int currLangID;

		internal bool _003CProductSpecificationEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CProductSpecificationEdit_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CProductSpecificationEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CProductSpecificationEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CProductSpecificationEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CProductSpecificationEdit_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CProductSpecificationEdit_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CProductSpecificationEdit_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CProductSpecificationEdit_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass35_1
	{
		public WSProductSpecification prdSpecificationEdit;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass35_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass35_1 CS_0024_003C_003E8__locals1;

		internal bool _003CProductSpecificationEdit_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductSpecificationEdit_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductSpecificationEdit_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductSpecificationEdit_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductSpecificationEdit_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductSpecificationEdit_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductSpecificationEdit_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductSpecificationEdit_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductSpecificationEdit_003Eb__18(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductSpecificationEdit_003Eb__19(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductSpecificationEdit_003Eb__20(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductSpecificationEdit_003Eb__21(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass42_0
	{
		public WSspSelectProductPicture_Result prdPic;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass45_0
	{
		public WSspSelectProductPictureWithPrdGroups_Result i;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass47_0
	{
		public int prdId;

		public int currLangID;

		internal bool _003CProductInShop_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CProductInShop_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CProductInShop_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CProductInShop_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CProductInShop_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CProductInShop_003Eb__18(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CProductInShop_003Eb__19(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CProductInShop_003Eb__20(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CProductInShop_003Eb__21(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CProductInShop_003Eb__22(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CProductInShop_003Eb__23(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CProductInShop_003Eb__24(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CProductInShop_003Eb__25(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CProductInShop_003Eb__26(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CProductInShop_003Eb__27(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CProductInShop_003Eb__28(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CProductInShop_003Eb__29(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CProductInShop_003Eb__30(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CProductInShop_003Eb__31(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CProductInShop_003Eb__32(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CProductInShop_003Eb__33(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CProductInShop_003Eb__34(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CProductInShop_003Eb__35(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CProductInShop_003Eb__36(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CProductInShop_003Eb__37(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CProductInShop_003Eb__38(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CProductInShop_003Eb__39(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CProductInShop_003Eb__40(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CProductInShop_003Eb__41(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CProductInShop_003Eb__42(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CProductInShop_003Eb__43(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CProductInShop_003Eb__44(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CProductInShop_003Eb__45(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass48_0
	{
		public WSProductsInShopLanguageViewModel model;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__23;

		internal bool _003CProductInShop_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CProductInShop_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CProductInShop_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CProductInShop_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CProductInShop_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CProductInShop_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CProductInShop_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CProductInShop_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CProductInShop_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CProductInShop_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CProductInShop_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CProductInShop_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CProductInShop_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CProductInShop_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CProductInShop_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CProductInShop_003Eb__18(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CProductInShop_003Eb__19(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CProductInShop_003Eb__20(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CProductInShop_003Eb__21(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CProductInShop_003Eb__22(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CProductInShop_003Eb__23(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass48_1
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass48_0 CS_0024_003C_003E8__locals1;

		internal bool _003CProductInShop_003Eb__25(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductInShop_003Eb__26(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductInShop_003Eb__27(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductInShop_003Eb__28(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductInShop_003Eb__29(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductInShop_003Eb__30(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductInShop_003Eb__31(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductInShop_003Eb__32(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductInShop_003Eb__33(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductInShop_003Eb__34(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductInShop_003Eb__35(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductInShop_003Eb__36(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductInShop_003Eb__37(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductInShop_003Eb__38(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductInShop_003Eb__39(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductInShop_003Eb__40(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductInShop_003Eb__41(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductInShop_003Eb__42(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductInShop_003Eb__43(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductInShop_003Eb__44(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductInShop_003Eb__45(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductInShop_003Eb__46(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductInShop_003Eb__47(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductInShop_003Eb__48(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductInShop_003Eb__49(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductInShop_003Eb__50(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductInShop_003Eb__51(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductInShop_003Eb__52(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductInShop_003Eb__53(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductInShop_003Eb__54(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductInShop_003Eb__55(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductInShop_003Eb__56(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductInShop_003Eb__57(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductInShop_003Eb__58(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductInShop_003Eb__59(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductInShop_003Eb__60(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductInShop_003Eb__61(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductInShop_003Eb__62(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductInShop_003Eb__63(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CProductInShop_003Eb__64(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass52_0
	{
		public int prdGalleryId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass53_0
	{
		public WSProductGallery model;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass54_0
	{
		public int prdGalleryId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass55_0
	{
		public int prdGalleryId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass96_0
	{
		public CRMspSelectProjectTitlesById_Result result;

		public int currLangID;

		internal bool _003CGetProjectTitleInfo_003Eb__2(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetProjectTitleInfo_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetProjectTitleInfo_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	private CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMLinkSpEntities _dbLink = new CRMLinkSpEntities();

	private CRMSpIEntities _dbI = new CRMSpIEntities();

	private CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actPrdDefineProducts")]
	public ActionResult Index(int prdId = 0, int fgId = 0, int sgId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		if (prdId > 0 && fgId == 0 && sgId == 0)
		{
			try
			{
				WSspSelectProductsWithId_Result wSspSelectProductsWithId_Result = Enumerable.FirstOrDefault<WSspSelectProductsWithId_Result>((IEnumerable<WSspSelectProductsWithId_Result>)_db.WSspSelectProductsWithId(prdId, lCID, result));
				if (wSspSelectProductsWithId_Result != null)
				{
					sgId = wSspSelectProductsWithId_Result.PrdGroupID;
					fgId = wSspSelectProductsWithId_Result.PrdFGroupId.GetValueOrDefault();
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
		}
		string text = "";
		bool flag = false;
		try
		{
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				int result2 = 0;
				int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result2);
				if (result2 == 1)
				{
					CRMspSelectLinkAccSetting_Result cRMspSelectLinkAccSetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_dbLink.CRMspSelectLinkAccSetting(0, "PreUsedHintSetting", lCID, result, 1, 0, "PrdPreUsedHint"));
					if (cRMspSelectLinkAccSetting_Result != null)
					{
						text = cRMspSelectLinkAccSetting_Result.PreUsedHint ?? "";
					}
				}
				if (!string.IsNullOrWhiteSpace(text))
				{
					flag = true;
				}
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		base.ViewBag.PreUsedHintLinkAcc = text;
		base.ViewBag.HavePreUsedHintLinkAcc = flag;
		base.ViewBag.prdId = prdId;
		base.ViewBag.fgId = fgId;
		base.ViewBag.sgId = sgId;
		dynamic viewBag = base.ViewBag;
		DbSet<WSProductImportFromExcel> wSProductImportFromExcel = _dbTbl.WSProductImportFromExcel;
		ParameterExpression val = Expression.Parameter(typeof(WSProductImportFromExcel), "c");
		viewBag.ProductImportFromExcel = Queryable.Any<WSProductImportFromExcel>((IQueryable<WSProductImportFromExcel>)wSProductImportFromExcel, Expression.Lambda<Func<WSProductImportFromExcel, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Property((Expression)null, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
		DbSet<WSProductImportFromExcelFields> wSProductImportFromExcelFields = _dbTbl.WSProductImportFromExcelFields;
		val = Expression.Parameter(typeof(WSProductImportFromExcelFields), "c");
		List<WSProductImportFromExcelFields> list = Enumerable.ToList<WSProductImportFromExcelFields>((IEnumerable<WSProductImportFromExcelFields>)Queryable.Where<WSProductImportFromExcelFields>((IQueryable<WSProductImportFromExcelFields>)wSProductImportFromExcelFields, Expression.Lambda<Func<WSProductImportFromExcelFields, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Convert((Expression)(object)Expression.Constant((object)true, typeof(bool)), typeof(bool?))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Convert((Expression)(object)Expression.Constant((object)true, typeof(bool)), typeof(bool?)))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
		base.ViewBag.ProductImportFromExcel_Price = Enumerable.Any<WSProductImportFromExcelFields>((IEnumerable<WSProductImportFromExcelFields>)list, (Func<WSProductImportFromExcelFields, bool>)((WSProductImportFromExcelFields c) => c.FieldName == "Price"));
		base.ViewBag.ProductImportFromExcel_Cost = Enumerable.Any<WSProductImportFromExcelFields>((IEnumerable<WSProductImportFromExcelFields>)list, (Func<WSProductImportFromExcelFields, bool>)((WSProductImportFromExcelFields c) => c.FieldName == "Cost"));
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmProducts", ActionName = "actSavePrdSpecification")]
	public ActionResult ProductSpecification(int prdId)
	{
		base.ViewBag.prdId = prdId;
		return View();
	}

	[AjaxOnly]
	public ActionResult _PartialPrdGroupTree()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			List<WSspSelectProductGroupTree_Result> list = Enumerable.ToList<WSspSelectProductGroupTree_Result>((IEnumerable<WSspSelectProductGroupTree_Result>)_db.WSspSelectProductGroupTree(lCID, result));
			List<WSspSelectProductGroupTree_Result> list2 = Enumerable.ToList<WSspSelectProductGroupTree_Result>(Enumerable.Where<WSspSelectProductGroupTree_Result>((IEnumerable<WSspSelectProductGroupTree_Result>)list, (Func<WSspSelectProductGroupTree_Result, bool>)((WSspSelectProductGroupTree_Result x) => x.ParentId == 0)));
			if (list2 == null)
			{
				list2 = new List<WSspSelectProductGroupTree_Result>();
			}
			List<TreeViewItemModel> list3 = new List<TreeViewItemModel>();
			foreach (WSspSelectProductGroupTree_Result item in list2)
			{
				TreeViewItemModel treeViewItemModel = new TreeViewItemModel();
				treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item.ParentId + "|" + item.SId + "|" + item.FId));
				treeViewItemModel.Id = item.ParentId + "|" + item.SId + "|" + item.FId;
				treeViewItemModel.Text = item.KEYName;
				treeViewItemModel.ImageUrl = "";
				List<WSspSelectProductGroupTree_Result> list4 = Enumerable.ToList<WSspSelectProductGroupTree_Result>(Enumerable.Where<WSspSelectProductGroupTree_Result>((IEnumerable<WSspSelectProductGroupTree_Result>)list, (Func<WSspSelectProductGroupTree_Result, bool>)((WSspSelectProductGroupTree_Result x) => x.ParentId == item.FId)));
				if (list4 == null)
				{
					list4 = new List<WSspSelectProductGroupTree_Result>();
				}
				List<TreeViewItemModel> list5 = new List<TreeViewItemModel>();
				foreach (WSspSelectProductGroupTree_Result item2 in list4)
				{
					TreeViewItemModel treeViewItemModel2 = new TreeViewItemModel();
					treeViewItemModel2.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item2.ParentId + "|" + item2.SId + "|" + item.FId));
					treeViewItemModel2.Id = item2.ParentId + "|" + item2.SId + "|" + item.FId;
					treeViewItemModel2.Text = item2.KEYName;
					treeViewItemModel2.ImageUrl = "";
					treeViewItemModel2.Items = null;
					list5.Add(treeViewItemModel2);
				}
				treeViewItemModel.Items = new List<TreeViewItemModel>(list5);
				list3.Add(treeViewItemModel);
			}
			base.ViewBag.PrdGroups = list3;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return PartialView();
	}

	[AjaxOnly]
	public ActionResult _PartialPrdSpecification(int prdId = 0)
	{
		base.ViewBag.prdId = prdId;
		return PartialView();
	}

	[AjaxOnly]
	public ActionResult PrdSpecification_Read([DataSourceRequest] DataSourceRequest request, int prdId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSProductSpecification> list = new List<WSProductSpecification>();
		try
		{
			List<WSspSelectProductSpecification_Result> list2 = Enumerable.ToList<WSspSelectProductSpecification_Result>(Enumerable.Where<WSspSelectProductSpecification_Result>((IEnumerable<WSspSelectProductSpecification_Result>)Enumerable.ToList<WSspSelectProductSpecification_Result>((IEnumerable<WSspSelectProductSpecification_Result>)_db.WSspSelectProductSpecification(lCID, result)), (Func<WSspSelectProductSpecification_Result, bool>)((WSspSelectProductSpecification_Result w) => w.PrdId == prdId)));
			list.AddRange(Enumerable.Select<WSspSelectProductSpecification_Result, WSProductSpecification>((IEnumerable<WSspSelectProductSpecification_Result>)list2, (Func<WSspSelectProductSpecification_Result, WSProductSpecification>)((WSspSelectProductSpecification_Result item) => new WSProductSpecification
			{
				ProductSpecificationID = item.ProductSpecificationID,
				PrdId = item.PrdId,
				Specification = item.Specification,
				SpecificationI = item.SpecificationI,
				SpecificationII = item.SpecificationII
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request));
	}

	[AjaxOnly]
	public ActionResult _PartialProducts(int prdGroupId = 0)
	{
		base.ViewBag.prdGroupId = prdGroupId;
		return PartialView();
	}

	[AjaxOnly]
	public ActionResult Products_Read([DataSourceRequest] DataSourceRequest request, int prdGroupId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int? centerId = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId : null);
		List<WSspSelectProductByGroup_Result> list = new List<WSspSelectProductByGroup_Result>();
		try
		{
			list = Enumerable.ToList<WSspSelectProductByGroup_Result>((IEnumerable<WSspSelectProductByGroup_Result>)_dbI.WSspSelectProductByGroup(prdGroupId, lCID, result, centerId));
			foreach (WSspSelectProductByGroup_Result item in list)
			{
				if (string.IsNullOrEmpty(item.AppType))
				{
					item.AppType = Configuration.AppType;
				}
				item.AppType = Configuration.GetAppType(item.AppType);
				string text = item.FirstRegisterUser ?? "";
				string text2 = (item.FirstRegisterDate.HasValue ? item.FirstRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
				item.FirstRegisterUser = Labels.frmFirstRegisterUser + ":" + text + " (" + text2 + ")";
				string text3 = item.EditUser ?? "";
				_ = item.RegisterDate;
				string text4 = item.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				item.EditUser = Labels.frmRegisterUser + ":" + text3 + " (" + Labels.AppType + ":" + item.AppType + ")  (" + text4 + ")";
				item.FirstRegisterUser = text;
				item.FirstRegisterDatePersian = text2;
				item.EditUser = text3 + " (" + Labels.AppType + ":" + item.AppType + ")";
				item.RegisterDatePersian = text4;
				item.PrdLinkAccPrdIdStr = ((!string.IsNullOrWhiteSpace(item.PrdLinkAccPrdIdStr)) ? item.PrdLinkAccPrdIdStr : (item.PrdLinkAccPrdId.HasValue ? item.PrdLinkAccPrdId.ToString() : ""));
				item.PrdLinkAccPrdCode = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccCodeWithComa(2, item.PrdLinkAccPrdCode);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(((IEnumerable)list).ToDataSourceResult(request));
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[HttpPost]
	public string ProductsJs(int prdGroupId = 0)
	{
		//IL_0304: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int? centerId = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId : null);
		List<WSspSelectProductByGroup_Result> list = new List<WSspSelectProductByGroup_Result>();
		try
		{
			List<WSspSelectProductByGroup_Result> list2 = Enumerable.ToList<WSspSelectProductByGroup_Result>((IEnumerable<WSspSelectProductByGroup_Result>)_dbI.WSspSelectProductByGroup(prdGroupId, lCID, result, centerId));
			if (list2 != null)
			{
				list = list2;
				CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
				int result2 = 0;
				if (cRMspSelectCrmsysSetting_Result != null)
				{
					int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result2);
				}
				List<CRMspSelectLinkAccSettingDBIsActive_Result> list3 = new List<CRMspSelectLinkAccSettingDBIsActive_Result>();
				if (result2 == 1 || result2 == 4)
				{
					list3 = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccSettingDBList(result2);
				}
				foreach (WSspSelectProductByGroup_Result item in list)
				{
					if (string.IsNullOrEmpty(item.AppType))
					{
						item.AppType = Configuration.AppType;
					}
					item.AppType = Configuration.GetAppType(item.AppType);
					string firstRegisterUser = item.FirstRegisterUser ?? "";
					string firstRegisterDatePersian = (item.FirstRegisterDate.HasValue ? item.FirstRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
					item.FirstRegisterUser = firstRegisterUser;
					item.FirstRegisterDatePersian = firstRegisterDatePersian;
					string text = item.EditUser ?? "";
					_ = item.RegisterDate;
					string registerDatePersian = item.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
					item.EditUser = text + " (" + Labels.AppType + ":" + item.AppType + ")";
					item.RegisterDatePersian = registerDatePersian;
					item.PrdLinkAccPrdIdStr = ((!string.IsNullOrWhiteSpace(item.PrdLinkAccPrdIdStr)) ? item.PrdLinkAccPrdIdStr : (item.PrdLinkAccPrdId.HasValue ? item.PrdLinkAccPrdId.ToString() : ""));
					item.PrdLinkAccFirstTransferDateStr = (item.PrdLinkAccFirstTransferDate.HasValue ? item.PrdLinkAccFirstTransferDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
					item.PrdLinkAccLastTransferDateStr = (item.PrdLinkAccLastTransferDate.HasValue ? item.PrdLinkAccLastTransferDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
					item.PrdLinkAccPrdCode = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccCodeWithComa(2, item.PrdLinkAccPrdCode);
					item.PrdRowColor = Public.TColorToHex(item.PrdRowColor);
					if (result2 != 1 && result2 != 4)
					{
						continue;
					}
					List<PrdLinkAccDataViewModel> list4 = new List<PrdLinkAccDataViewModel>();
					if (!string.IsNullOrWhiteSpace(item.PrdLinkAccData))
					{
						foreach (PrdLinkAccDataViewModel item2 in new JavaScriptSerializer().Deserialize<List<PrdLinkAccDataViewModel>>(item.PrdLinkAccData))
						{
							int dbId = 0;
							int.TryParse(item2.DBId.ToString(), out dbId);
							if (dbId != 0 && list3 != null && Enumerable.Any<CRMspSelectLinkAccSettingDBIsActive_Result>((IEnumerable<CRMspSelectLinkAccSettingDBIsActive_Result>)list3))
							{
								CRMspSelectLinkAccSettingDBIsActive_Result cRMspSelectLinkAccSettingDBIsActive_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDBIsActive_Result>((IEnumerable<CRMspSelectLinkAccSettingDBIsActive_Result>)list3, (Func<CRMspSelectLinkAccSettingDBIsActive_Result, bool>)((CRMspSelectLinkAccSettingDBIsActive_Result m) => m.LinkAccSettingDBId == dbId));
								if (cRMspSelectLinkAccSettingDBIsActive_Result != null)
								{
									item2.DbName = cRMspSelectLinkAccSettingDBIsActive_Result.LinkAccSettingDbName ?? "";
									item2.DbTitle = cRMspSelectLinkAccSettingDBIsActive_Result.LinkAccSettingDbTitle ?? "";
									item2.CodeWithLbl = item2.Code ?? "";
									item2.IdWithLbl = item2.Id ?? "";
									item2.FTDateWithLbl = (item2.FTDate.HasValue ? item2.FTDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
									item2.LTDateWithLbl = (item2.LTDate.HasValue ? item2.LTDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
									list4.Add(item2);
								}
							}
						}
					}
					item.PrdLinkAccData = "";
					if (list4 != null && Enumerable.Any<PrdLinkAccDataViewModel>((IEnumerable<PrdLinkAccDataViewModel>)list4))
					{
						item.PrdLinkAccData = JsonConvert.SerializeObject(Enumerable.ToList<PrdLinkAccDataViewModel>((IEnumerable<PrdLinkAccDataViewModel>)list4));
					}
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	public string GetProductPriceGroupByPrdId(int prdId = 0)
	{
		List<WSspSelectProductPriceGroupByPrdId_Result> value = new List<WSspSelectProductPriceGroupByPrdId_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int? centerId = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId : null);
			List<WSspSelectProductPriceGroupByPrdId_Result> list = Enumerable.ToList<WSspSelectProductPriceGroupByPrdId_Result>((IEnumerable<WSspSelectProductPriceGroupByPrdId_Result>)_dbI.WSspSelectProductPriceGroupByPrdId(prdId, lCID, result, centerId));
			if (list != null)
			{
				value = list;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return JsonConvert.SerializeObject(value);
	}

	private void FillDropdownProduct()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectProductColor_Result> list = Enumerable.ToList<WSspSelectProductColor_Result>((IEnumerable<WSspSelectProductColor_Result>)_db.WSspSelectProductColor(lCID, result));
		List<SelectListItem> list2 = new List<SelectListItem>();
		list2.AddRange(Enumerable.Select<WSspSelectProductColor_Result, SelectListItem>((IEnumerable<WSspSelectProductColor_Result>)list, (Func<WSspSelectProductColor_Result, SelectListItem>)((WSspSelectProductColor_Result item) => new SelectListItem
		{
			Text = item.Color,
			Value = item.ProductColorID.ToString(),
			Selected = false
		})));
		base.ViewBag.ColorList = list2;
		List<WSspSelectProductUnits_Result> list3 = Enumerable.ToList<WSspSelectProductUnits_Result>((IEnumerable<WSspSelectProductUnits_Result>)_db.WSspSelectProductUnits(lCID, result));
		List<SelectListItem> list4 = new List<SelectListItem>();
		list4.AddRange(Enumerable.Select<WSspSelectProductUnits_Result, SelectListItem>((IEnumerable<WSspSelectProductUnits_Result>)list3, (Func<WSspSelectProductUnits_Result, SelectListItem>)((WSspSelectProductUnits_Result item) => new SelectListItem
		{
			Text = item.Unit,
			Value = item.ProductUnitID.ToString(),
			Selected = false
		})));
		base.ViewBag.UnitList = list4;
		List<SelectListItem> list5 = new List<SelectListItem>();
		list5.AddRange(Enumerable.Select<WSspSelectProductUnits_Result, SelectListItem>((IEnumerable<WSspSelectProductUnits_Result>)list3, (Func<WSspSelectProductUnits_Result, SelectListItem>)((WSspSelectProductUnits_Result item) => new SelectListItem
		{
			Text = item.Unit,
			Value = item.ProductUnitID.ToString(),
			Selected = false
		})));
		base.ViewBag.UnitIList = list5;
		List<SelectListItem> list6 = new List<SelectListItem>();
		list6.AddRange(Enumerable.Select<WSspSelectProductUnits_Result, SelectListItem>((IEnumerable<WSspSelectProductUnits_Result>)list3, (Func<WSspSelectProductUnits_Result, SelectListItem>)((WSspSelectProductUnits_Result item) => new SelectListItem
		{
			Text = item.Unit,
			Value = item.ProductUnitID.ToString(),
			Selected = false
		})));
		base.ViewBag.UnitIIList = list6;
	}

	[AjaxOnly]
	public JsonResult GetPrdColor()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CrmDroupDownItem> list = new List<CrmDroupDownItem>();
		try
		{
			list = Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<WSspSelectProductColor_Result, CrmDroupDownItem>((IEnumerable<WSspSelectProductColor_Result>)Enumerable.ToList<WSspSelectProductColor_Result>((IEnumerable<WSspSelectProductColor_Result>)_db.WSspSelectProductColor(lCID, result)), (Func<WSspSelectProductColor_Result, CrmDroupDownItem>)((WSspSelectProductColor_Result item) => new CrmDroupDownItem
			{
				text = item.Color,
				value = item.ProductColorID.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ColorList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetPrdUnit()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CrmDroupDownItem> list = new List<CrmDroupDownItem>();
		try
		{
			list = Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<WSspSelectProductUnits_Result, CrmDroupDownItem>((IEnumerable<WSspSelectProductUnits_Result>)Enumerable.ToList<WSspSelectProductUnits_Result>((IEnumerable<WSspSelectProductUnits_Result>)_db.WSspSelectProductUnits(lCID, result)), (Func<WSspSelectProductUnits_Result, CrmDroupDownItem>)((WSspSelectProductUnits_Result item) => new CrmDroupDownItem
			{
				text = item.Unit,
				value = item.ProductUnitID.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.UnitList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult PrdFirstGroup()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectProductFirstGroup_Result> data = Enumerable.ToList<WSspSelectProductFirstGroup_Result>(Enumerable.Select<WSspSelectProductFirstGroup_Result, WSspSelectProductFirstGroup_Result>((IEnumerable<WSspSelectProductFirstGroup_Result>)Enumerable.ToList<WSspSelectProductFirstGroup_Result>((IEnumerable<WSspSelectProductFirstGroup_Result>)_db.WSspSelectProductFirstGroup(lCID, result)), (Func<WSspSelectProductFirstGroup_Result, WSspSelectProductFirstGroup_Result>)((WSspSelectProductFirstGroup_Result item) => new WSspSelectProductFirstGroup_Result
		{
			PrdFirstGroupID = item.PrdFirstGroupID,
			FGName = (item.FGName ?? "")
		})));
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult PrdSecondGroup(int fgId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectProductSecondGroup_Result> data = Enumerable.ToList<WSspSelectProductSecondGroup_Result>(Enumerable.Select<WSspSelectProductSecondGroup_Result, WSspSelectProductSecondGroup_Result>((IEnumerable<WSspSelectProductSecondGroup_Result>)Enumerable.ToList<WSspSelectProductSecondGroup_Result>((IEnumerable<WSspSelectProductSecondGroup_Result>)_db.WSspSelectProductSecondGroup(fgId, lCID, result)), (Func<WSspSelectProductSecondGroup_Result, WSspSelectProductSecondGroup_Result>)((WSspSelectProductSecondGroup_Result item) => new WSspSelectProductSecondGroup_Result
		{
			PrdSecondGroupID = item.PrdSecondGroupID,
			SGName = item.SGName,
			FGName = (item.FGName ?? "")
		})));
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetPrdSecondGroup(int fgId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CrmDroupDownItem> data = Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<WSspSelectProductSecondGroup_Result, CrmDroupDownItem>((IEnumerable<WSspSelectProductSecondGroup_Result>)Enumerable.ToList<WSspSelectProductSecondGroup_Result>((IEnumerable<WSspSelectProductSecondGroup_Result>)_db.WSspSelectProductSecondGroup(fgId, lCID, result)), (Func<WSspSelectProductSecondGroup_Result, CrmDroupDownItem>)((WSspSelectProductSecondGroup_Result item) => new CrmDroupDownItem
		{
			text = item.SGName,
			value = item.PrdSecondGroupID.ToString()
		})));
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmProducts", ActionName = "actInsertPrd")]
	public ActionResult ProductInsert(int fgId, int sgId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
		int result2 = 0;
		if (cRMspSelectCrmsysSetting_Result != null)
		{
			int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result2);
		}
		if (result2 == 1 || result2 == 4)
		{
			base.ViewBag.LinkAccSettingDBList = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccSettingDB(result2);
		}
		WSProductsLanguageViewModel model = new WSProductsLanguageViewModel();
		GetPrdLinkAccPrdGroup(sgId);
		GetProjectTitleGroup();
		GetProjectTitles();
		GetPrjCnvsStatusGroups();
		GetCnvsTopic();
		GetReferUserActive();
		GetOrderOpr();
		GetPordDefSetting();
		GetCompanyType();
		GetCompanyGroupII();
		try
		{
			if (fgId > 0 && sgId > 0)
			{
				string text = "";
				WSspSelectProductFirstGroup_Result wSspSelectProductFirstGroup_Result = Enumerable.FirstOrDefault<WSspSelectProductFirstGroup_Result>((IEnumerable<WSspSelectProductFirstGroup_Result>)Enumerable.ToList<WSspSelectProductFirstGroup_Result>((IEnumerable<WSspSelectProductFirstGroup_Result>)_db.WSspSelectProductFirstGroup(lCID, result)), (Func<WSspSelectProductFirstGroup_Result, bool>)((WSspSelectProductFirstGroup_Result c) => c.PrdFirstGroupID == fgId));
				text += ((wSspSelectProductFirstGroup_Result != null) ? wSspSelectProductFirstGroup_Result.FGName : "");
				WSspSelectWSProductSecondGroup_Result wSspSelectWSProductSecondGroup_Result = Enumerable.FirstOrDefault<WSspSelectWSProductSecondGroup_Result>((IEnumerable<WSspSelectWSProductSecondGroup_Result>)Enumerable.ToList<WSspSelectWSProductSecondGroup_Result>((IEnumerable<WSspSelectWSProductSecondGroup_Result>)_db.WSspSelectWSProductSecondGroup(lCID, result, 0)), (Func<WSspSelectWSProductSecondGroup_Result, bool>)((WSspSelectWSProductSecondGroup_Result c) => c.PrdSecondGroupID == sgId));
				if (wSspSelectWSProductSecondGroup_Result != null)
				{
					if (text != "")
					{
						text += " - ";
					}
					text += wSspSelectWSProductSecondGroup_Result.SGName;
				}
				base.ViewBag.GrpName = text;
				string sql = $"Select dbo.WSfnMakeAndReturnPrdCode ({fgId}, {sgId})";
				string prdCode = "";
				if (!UserLogin.IsUserAccess("frmProducts", "actCanSetPrdCodeNotAuto", UserLogin.CurrentUser))
				{
					prdCode = Enumerable.FirstOrDefault<string>(_db.Database.SqlQuery<string>(sql, Array.Empty<object>()));
				}
				model = new WSProductsLanguageViewModel
				{
					PrdGroupID = sgId,
					PrdCode = prdCode,
					FPId = fgId,
					PrdInactiveInBuy = false,
					PrdInactiveInSale = false,
					PrdKind = 1,
					PrdInActive = false
				};
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			model = new WSProductsLanguageViewModel
			{
				PrdGroupID = sgId,
				PrdCode = "",
				FPId = fgId,
				PrdInactiveInBuy = false,
				PrdInactiveInSale = false
			};
		}
		FillDropdownProduct();
		base.ViewBag.IsBuying = VersionBuyer.Products;
		return View(model);
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmProductsDataEntry", ActionName = "actPost")]
	public ActionResult ProductInsert(WSProductsLanguageViewModel model)
	{
		//IL_0366: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0435: Unknown result type (might be due to invalid IL or missing references)
		//IL_047a: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0504: Unknown result type (might be due to invalid IL or missing references)
		//IL_0549: Unknown result type (might be due to invalid IL or missing references)
		//IL_058e: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0618: Unknown result type (might be due to invalid IL or missing references)
		//IL_065d: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e7: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
		int result = 0;
		if (cRMspSelectCrmsysSetting_Result != null)
		{
			int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result);
		}
		if (result == 1 || result == 4)
		{
			base.ViewBag.LinkAccSettingDBList = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccSettingDB(result);
		}
		int fgId = model.FPId;
		int sgId = model.PrdGroupID;
		string text = "";
		WSspSelectProductFirstGroup_Result wSspSelectProductFirstGroup_Result = Enumerable.FirstOrDefault<WSspSelectProductFirstGroup_Result>((IEnumerable<WSspSelectProductFirstGroup_Result>)Enumerable.ToList<WSspSelectProductFirstGroup_Result>((IEnumerable<WSspSelectProductFirstGroup_Result>)_db.WSspSelectProductFirstGroup(lCID, defLangID)), (Func<WSspSelectProductFirstGroup_Result, bool>)((WSspSelectProductFirstGroup_Result c) => c.PrdFirstGroupID == fgId));
		text += ((wSspSelectProductFirstGroup_Result != null) ? wSspSelectProductFirstGroup_Result.FGName : "");
		WSspSelectWSProductSecondGroup_Result wSspSelectWSProductSecondGroup_Result = Enumerable.FirstOrDefault<WSspSelectWSProductSecondGroup_Result>((IEnumerable<WSspSelectWSProductSecondGroup_Result>)Enumerable.ToList<WSspSelectWSProductSecondGroup_Result>((IEnumerable<WSspSelectWSProductSecondGroup_Result>)_db.WSspSelectWSProductSecondGroup(lCID, defLangID, 0)), (Func<WSspSelectWSProductSecondGroup_Result, bool>)((WSspSelectWSProductSecondGroup_Result c) => c.PrdSecondGroupID == sgId));
		if (wSspSelectWSProductSecondGroup_Result != null)
		{
			if (text != "")
			{
				text += " - ";
			}
			text += wSspSelectWSProductSecondGroup_Result.SGName;
		}
		base.ViewBag.GrpName = text;
		FillDropdownProduct();
		GetPrdLinkAccPrdGroup(sgId);
		GetProjectTitleGroup();
		GetProjectTitles();
		GetPrjCnvsStatusGroups();
		GetCnvsTopic();
		GetReferUserActive();
		GetOrderOpr();
		GetPordDefSetting();
		GetCompanyType();
		GetCompanyGroupII();
		try
		{
			if (!VersionBuyer.Products)
			{
				DbSet<WSProducts> wSProducts = _dbTbl.WSProducts;
				ParameterExpression val = Expression.Parameter(typeof(WSProducts), "c");
				if (Queryable.Any<WSProducts>((IQueryable<WSProducts>)wSProducts, Expression.Lambda<Func<WSProducts, bool>>((Expression)(object)Expression.GreaterThan((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)10, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val })))
				{
					base.ViewBag.Error = "BV|" + Messages.VersionBuy;
					return View(model);
				}
			}
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.PrdName_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.PrdName_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = model.PrdName,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.PrdType_Lang))
			{
				list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.PrdType_Lang);
			}
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = model.PrdType,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.PrdDesign_Lang))
			{
				list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.PrdDesign_Lang);
			}
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = model.PrdDesign,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.PrdSize_Lang))
			{
				list4 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.PrdSize_Lang);
			}
			list4.Add(new CommonMultiLanguageViewModel
			{
				Value = model.PrdSize,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list5 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.PrdDescription_Lang))
			{
				list5 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.PrdDescription_Lang);
			}
			list5.Add(new CommonMultiLanguageViewModel
			{
				Value = model.PrdDescription,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list6 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.PrdModel_Lang))
			{
				list6 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.PrdModel_Lang);
			}
			list6.Add(new CommonMultiLanguageViewModel
			{
				Value = model.PrdModel,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list7 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.PrdManufacturerName_Lang))
			{
				list7 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.PrdManufacturerName_Lang);
			}
			list7.Add(new CommonMultiLanguageViewModel
			{
				Value = model.PrdManufacturerName,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list8 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.PrdLocation_Lang))
			{
				list8 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.PrdLocation_Lang);
			}
			list8.Add(new CommonMultiLanguageViewModel
			{
				Value = model.PrdLocation,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list9 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.PrdNickname_Lang))
			{
				list9 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.PrdNickname_Lang);
			}
			list9.Add(new CommonMultiLanguageViewModel
			{
				Value = model.PrdNickname,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list10 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.PrdAutoCalcPordItemDesc_Lang))
			{
				list10 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.PrdAutoCalcPordItemDesc_Lang);
			}
			list10.Add(new CommonMultiLanguageViewModel
			{
				Value = model.PrdAutoCalcPordItemDesc,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list11 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.PrdAutoCalcPordPrjPostFix_Lang))
			{
				list11 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.PrdAutoCalcPordPrjPostFix_Lang);
			}
			list11.Add(new CommonMultiLanguageViewModel
			{
				Value = model.PrdAutoCalcPordPrjPostFix,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list12 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.PrdAutoCalcPordCnvsDesc_Lang))
			{
				list12 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.PrdAutoCalcPordCnvsDesc_Lang);
			}
			list12.Add(new CommonMultiLanguageViewModel
			{
				Value = model.PrdAutoCalcPordCnvsDesc,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list13 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.PrdOrdIssuePrjPostFix_Lang))
			{
				list13 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.PrdOrdIssuePrjPostFix_Lang);
			}
			list13.Add(new CommonMultiLanguageViewModel
			{
				Value = model.PrdOrdIssuePrjPostFix,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list14 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.PrdValidityControlFODeActivePrjTitleGroupDesc_Lang))
			{
				list14 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.PrdValidityControlFODeActivePrjTitleGroupDesc_Lang);
			}
			list14.Add(new CommonMultiLanguageViewModel
			{
				Value = model.PrdValidityControlFODeActivePrjTitleGroupDesc,
				LanguageId = lCID
			});
			string text2 = "";
			if (model.PrdName == null && model.PrdName == "")
			{
				text2 = text2 + Messages.CheckPrdName + "<br/>";
			}
			else if (!checkMultiLanguage(model.PrdName, list))
			{
				text2 = text2 + Messages.CheckPrdNameLang + "<br>";
			}
			if (text2 != "")
			{
				base.ViewBag.Error = text2;
			}
			else if (!base.ModelState.IsValid)
			{
				base.ViewBag.Error = Messages.frmErrorMessage + "<br/> " + string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
			else
			{
				string prdValidityTime = null;
				if (model.PrdValidityTimeHour.HasValue || model.PrdValidityTimeMinute.HasValue)
				{
					string obj = ((model.PrdValidityTimeHour.GetValueOrDefault() == 0 || model.PrdValidityTimeHour.GetValueOrDefault() <= 9) ? ("0" + model.PrdValidityTimeHour.GetValueOrDefault()) : model.PrdValidityTimeHour.GetValueOrDefault().ToString());
					string text3 = ((model.PrdValidityTimeMinute.GetValueOrDefault() == 0 || model.PrdValidityTimeMinute.GetValueOrDefault() <= 9) ? ("0" + model.PrdValidityTimeMinute.GetValueOrDefault()) : model.PrdValidityTimeMinute.GetValueOrDefault().ToString());
					prdValidityTime = obj + ":" + text3;
				}
				WSProducts wSProducts2 = new WSProducts
				{
					FPId = Financial.Get().Id,
					UserId = UserLogin.CurrentUser.UserId,
					RegisterDate = DateTime.Now,
					RegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture()),
					Month1 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture())),
					GUId = System.Guid.NewGuid(),
					FirstRegisterUserId = UserLogin.CurrentUser.UserId,
					FirstRegisterDate = DateTime.Now,
					FirstRegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture()),
					LanguageID = defLangID,
					AppType = Configuration.AppType,
					PrdAutoCharBarcode = model.PrdAutoCharBarcode,
					PrdAutoNumBarCodeTypeId = model.PrdAutoNumBarCodeTypeId,
					PrdAutoNumBarcode = model.PrdAutoNumBarcode,
					PrdBarCode = model.PrdBarCode,
					PrdBarCodeTypeId = model.PrdBarCodeTypeId,
					PrdCode = model.PrdCode,
					PrdColorId = model.PrdColorId,
					PrdFirstBarcode = model.PrdFirstBarcode,
					PrdFirstSerial = model.PrdFirstSerial,
					PrdGroupID = model.PrdGroupID,
					PrdInactiveInBuy = model.PrdInactiveInBuy,
					PrdInactiveInSale = model.PrdInactiveInSale,
					PrdLatinName = model.PrdLatinName,
					PrdMaxQty = model.PrdMaxQty,
					PrdMinQty = model.PrdMinQty,
					PrdSecondBarcode = model.PrdSecondBarcode,
					PrdSecondSerial = model.PrdSecondSerial,
					PrdSleepDay = model.PrdSleepDay,
					PrdThirdBarcode = model.PrdThirdBarcode,
					PrdThirdSerial = model.PrdThirdSerial,
					PrdUnitId = model.PrdUnitId,
					prdAutoCharBarCodeTypeId = model.prdAutoCharBarCodeTypeId,
					PrdName = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null),
					PrdType = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null),
					PrdDesign = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null),
					PrdSize = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null),
					PrdDescription = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null),
					PrdModel = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null),
					OrderView = model.OrderView,
					PrdCommissionDisable = model.PrdCommissionDisable,
					PrdCommissionPercentRate = model.PrdCommissionPercentRate,
					PrdIsDefault = model.PrdIsDefault,
					PrdInActive = model.PrdInActive,
					PrdKind = model.PrdKind,
					PrdDefQuantity = model.PrdDefQuantity,
					PrdJustDefQuantity = model.PrdJustDefQuantity,
					PrdMinQuantity = model.PrdMinQuantity,
					PrdMaxQuantity = model.PrdMaxQuantity,
					PrdManufacturerName = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null),
					PrdManufacturerCode = model.PrdManufacturerCode,
					PrdLocation = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null),
					PrdLinkAccPrdGroupIdStr = model.PrdLinkAccPrdGroupIdStr,
					PrdUnitIdI = model.PrdUnitIdI,
					PrdUnitIRate = model.PrdUnitIRate,
					PrdUnitIRateCalcAuto = model.PrdUnitIRateCalcAuto,
					PrdQtyNoFCR = model.PrdQtyNoFCR,
					PrdMustFullTracingCode = model.PrdMustFullTracingCode,
					PrdUnitIdII = model.PrdUnitIdII,
					PrdUnitIIRate = model.PrdUnitIIRate,
					PrdUnitIIRateCalcAuto = model.PrdUnitIIRateCalcAuto,
					PrdSingleItem = model.PrdSingleItem,
					PrdScore = model.PrdScore,
					PrdValidityCounting = model.PrdValidityCounting,
					PrdValidityCountingNum = model.PrdValidityCountingNum,
					PrdValidityCountingMin = model.PrdValidityCountingMin,
					PrdValidityCountingNumIsActive = model.PrdValidityCountingNumIsActive,
					PrdValidityCountingNumNeedOrder = model.PrdValidityCountingNumNeedOrder,
					PrdValidityCountingNumDefaultVal = model.PrdValidityCountingNumDefaultVal,
					PrdValidityCountingNumNoCheckRemain = model.PrdValidityCountingNumNoCheckRemain,
					PrdValidityCountingMinIsActive = model.PrdValidityCountingMinIsActive,
					PrdValidityCountingMinNeedOrder = model.PrdValidityCountingMinNeedOrder,
					PrdValidityCountingMinDefaultVal = model.PrdValidityCountingMinDefaultVal,
					PrdValidityCountingMinNoCheckRemain = model.PrdValidityCountingMinNoCheckRemain,
					PrdNickname = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null),
					PrdModuleName = model.PrdModuleName,
					TspPrdIndentify = model.TspPrdIndentify,
					TspPrdName = model.TspPrdName,
					PrdAutoCalcIndexed = model.PrdAutoCalcIndexed,
					PrdAutoCalcPordPrdId = model.PrdAutoCalcPordPrdId,
					PrdAutoCalcPriceFromOrdItemRate = model.PrdAutoCalcPriceFromOrdItemRate,
					PrdAutoCalcDisabled = model.PrdAutoCalcDisabled,
					PrdAutoCalcPriceFromOrdItemPrdGroups = model.PrdAutoCalcPriceFromOrdItemPrdGroups,
					PrdAutoCalcDynamicRate = model.PrdAutoCalcDynamicRate,
					PrdAutoCalcInflationLastDurationRate = model.PrdAutoCalcInflationLastDurationRate,
					PrdAutoCalcIndexedPrdId = model.PrdAutoCalcIndexedPrdId,
					PrdAutoCalcPordVerifyAfterIssue = model.PrdAutoCalcPordVerifyAfterIssue,
					PrdAutoCalcPordReferUser = model.PrdAutoCalcPordReferUser,
					PrdAutoCalcPordExpireDynamicRate = model.PrdAutoCalcPordExpireDynamicRate,
					PrdAutoCalcPordExpireDay = model.PrdAutoCalcPordExpireDay,
					PrdAutoCalcPordItemDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null),
					PrdAutoCalcPordTaxDetectFromLastOrd = model.PrdAutoCalcPordTaxDetectFromLastOrd,
					PrdAutoCalcPordTaxDefSettingId = model.PrdAutoCalcPordTaxDefSettingId,
					PrdAutoCalcPordNoTaxDefSettingId = model.PrdAutoCalcPordNoTaxDefSettingId,
					PrdAutoCalcPordPrjTitleGroupId = model.PrdAutoCalcPordPrjTitleGroupId,
					PrdAutoCalcPordPrjTitleId = model.PrdAutoCalcPordPrjTitleId,
					PrdAutoCalcPordPrjPostFix = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null),
					PrdAutoCalcPordPrjCnvsStatusGroupId = model.PrdAutoCalcPordPrjCnvsStatusGroupId,
					PrdAutoCalcPordPrjFOCmpCanSee = model.PrdAutoCalcPordPrjFOCmpCanSee,
					PrdAutoCalcPordPrjIsTicket = model.PrdAutoCalcPordPrjIsTicket,
					PrdAutoCalcPordPrjUsedType = model.PrdAutoCalcPordPrjUsedType,
					PrdAutoCalcPordAddCnvs = model.PrdAutoCalcPordAddCnvs,
					PrdAutoCalcPordCnvsTopicId = model.PrdAutoCalcPordCnvsTopicId,
					PrdAutoCalcPordCnvsDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null),
					PrdAutoCalcPordCnvsReferUser = model.PrdAutoCalcPordCnvsReferUser,
					PrdAutoCalcPordCnvsStatusId = model.PrdAutoCalcPordCnvsStatusId,
					PrdAutoCalcPordCnvsStatusResultId = model.PrdAutoCalcPordCnvsStatusResultId,
					PrdAutoCalcPordCnvsRemindDay = model.PrdAutoCalcPordCnvsRemindDay,
					PrdAutoCalcIssueOrdFromIndexed = model.PrdAutoCalcIssueOrdFromIndexed,
					PrdAutoCalcIssueOrdFromIndexedOprId = model.PrdAutoCalcIssueOrdFromIndexedOprId,
					PrdOrdIssueSetSetting = model.PrdOrdIssueSetSetting,
					PrdOrdIssuePrjTitleGroupId = model.PrdOrdIssuePrjTitleGroupId,
					PrdOrdIssuePrjTitleId = model.PrdOrdIssuePrjTitleId,
					PrdOrdIssuePrjPostFix = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null),
					PrdOrdIssuePrjCnvsStatusGroupId = model.PrdOrdIssuePrjCnvsStatusGroupId,
					PrdOrdIssuePrjRemindDay = model.PrdOrdIssuePrjRemindDay,
					PrdOrdIssuePrjFOCmpCanSee = model.PrdOrdIssuePrjFOCmpCanSee,
					PrdOrdIssuePrjIsTicket = model.PrdOrdIssuePrjIsTicket,
					PrdOrdIssuePrjUsedType = model.PrdOrdIssuePrjUsedType,
					PrdValidityUpdatePrjRemindDateAfterIssueOrd = model.PrdValidityUpdatePrjRemindDateAfterIssueOrd,
					PrdOrdIssueUpdateCmpTypeId = model.PrdOrdIssueUpdateCmpTypeId,
					PrdOrdIssueUpdateCmpGroupII = model.PrdOrdIssueUpdateCmpGroupII,
					PrdOrdIssueUpdateTaxCmpGroupIdII = model.PrdOrdIssueUpdateTaxCmpGroupIdII,
					PrdOrdIssueUpdateNoTaxCmpGroupIdII = model.PrdOrdIssueUpdateNoTaxCmpGroupIdII,
					PrdOrdIssueDateToCmpEffectiveDate = model.PrdOrdIssueDateToCmpEffectiveDate,
					PrdAutoCalcIndexBreakDay = model.PrdAutoCalcIndexBreakDay,
					PrdAutoCalcDynamicRateJustCompleteDuration = model.PrdAutoCalcDynamicRateJustCompleteDuration,
					PrdAutoCalcInflationLastYearNumChange = model.PrdAutoCalcInflationLastYearNumChange,
					PrdAutoCalcInflationLastDuration = model.PrdAutoCalcInflationLastDuration,
					PrdAutoCalcInflationLastYearNumChangeRate = model.PrdAutoCalcInflationLastYearNumChangeRate,
					PrdAutoCalcPriceFromOrdItemInBreak = model.PrdAutoCalcPriceFromOrdItemInBreak,
					PrdAutoCalcPriceFromIndex = model.PrdAutoCalcPriceFromIndex,
					PrdAutoCalcPriceFromIndexRate = model.PrdAutoCalcPriceFromIndexRate,
					PrdAutoCalcPriceFromOrdItem = model.PrdAutoCalcPriceFromOrdItem,
					PrdAutoCalcPriceFromOrdItemAfterBreak = model.PrdAutoCalcPriceFromOrdItemAfterBreak,
					PrdValidityControlFOPrjTitleGroup = model.PrdValidityControlFOPrjTitleGroup,
					PrdValidityControlFOPrjTitleGroupIds = model.PrdValidityControlFOPrjTitleGroupIds,
					PrdValidityControlFODeActivePrjTitleGroupDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null),
					PrdCanChangePrice = model.PrdCanChangePrice,
					PrdLinkAccPrdCode = model.PrdLinkAccPrdCode,
					PrdSaleCenterIds = model.PrdSaleCenterIds,
					PrdDoneTimeMin = model.PrdDoneTimeMin,
					PrdRowColor = Public.HexToColor(model.PrdRowColor),
					PrdWeight = model.PrdWeight
				};
				_ = VersionBuyer.PrdIVRLink;
				bool prdIVRLink = VersionBuyer.PrdIVRLink;
				_ = VersionBuyer.PrdValidity;
				bool prdValidity = VersionBuyer.PrdValidity;
				if (prdIVRLink)
				{
					wSProducts2.PrdIVRLink = model.PrdIVRLink;
					wSProducts2.PrdIVRLinkRule = model.PrdIVRLinkRule;
					wSProducts2.PrdIVRLinkDesc = model.PrdIVRLinkDesc;
				}
				else
				{
					bool? prdIVRLink2 = (model.PrdIVRLink = null);
					wSProducts2.PrdIVRLink = prdIVRLink2;
					string prdIVRLinkRule = (model.PrdIVRLinkRule = null);
					wSProducts2.PrdIVRLinkRule = prdIVRLinkRule;
					prdIVRLinkRule = (model.PrdIVRLinkDesc = null);
					wSProducts2.PrdIVRLinkDesc = prdIVRLinkRule;
				}
				if (prdValidity)
				{
					wSProducts2.PrdValidity = model.PrdValidity;
					wSProducts2.PrdValidityDay = model.PrdValidityDay;
					wSProducts2.PrdValidityTime = prdValidityTime;
				}
				else
				{
					bool? prdIVRLink2 = (model.PrdValidity = null);
					wSProducts2.PrdValidity = prdIVRLink2;
					int? prdValidityDay = (model.PrdValidityDay = null);
					wSProducts2.PrdValidityDay = prdValidityDay;
					string prdIVRLinkRule = (model.PrdValidityTime = null);
					wSProducts2.PrdValidityTime = prdIVRLinkRule;
				}
				if (VersionBuyer.PrdAutoCalcPrice)
				{
					wSProducts2.PrdAutoCalcPrice = model.PrdAutoCalcPrice;
					wSProducts2.PrdAutoCalcPricePercent = model.PrdAutoCalcPricePercent;
				}
				else
				{
					wSProducts2.PrdAutoCalcPrice = false;
					wSProducts2.PrdAutoCalcPricePercent = null;
				}
				wSProducts2.PrdQtyCanDecimal = model.PrdQtyCanDecimal;
				_dbTbl.WSProducts.Add(wSProducts2);
				_dbTbl.SaveChanges();
				foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))))
				{
					WSProducts_Lang entity = new WSProducts_Lang
					{
						LanguageID = lang.LanguageID,
						ProductID = wSProducts2.ProductID,
						PrdName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
						PrdType = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
						PrdDesign = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
						PrdSize = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
						PrdDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
						PrdModel = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
						PrdManufacturerName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
						PrdLocation = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
						PrdNickname = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
						PrdAutoCalcPordItemDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
						PrdAutoCalcPordPrjPostFix = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
						PrdAutoCalcPordCnvsDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
						PrdOrdIssuePrjPostFix = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
						PrdValidityControlFODeActivePrjTitleGroupDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null)
					};
					_dbTbl.WSProducts_Lang.Add(entity);
					_dbTbl.SaveChanges();
				}
				string text7 = Messages.frmFormBaseInsertSuccessFulMessage;
				if (wSProducts2.ProductID > 0 && VersionBuyer.LinkAcc && UserLogin.IsUserAccess("frmProducts", "actSendToAcc", UserLogin.CurrentUser) && model.SendToAcc.HasValue && model.SendToAcc.GetValueOrDefault())
				{
					CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result2 = SysSeting.Get();
					if (cRMspSelectCrmsysSetting_Result2 != null)
					{
						int result2 = 0;
						int.TryParse(cRMspSelectCrmsysSetting_Result2.LinkAccSystemId.ToString(), out result2);
						ProductController productController = new ProductController();
						switch (result2)
						{
						case 8:
						{
							string text9 = productController.ShygunActSendToAcc(wSProducts2.ProductID);
							if (!string.IsNullOrEmpty(text9))
							{
								string[] array2 = text9.Split(new char[1] { '|' });
								if (array2 != null)
								{
									text7 = ((!(array2[0] == "1") || array2.Length != 2) ? (text7 + "<br>" + string.Format(Messages.msgErrorTransferPrdToLinkAcc, Labels.Shygun) + "<br>" + array2[0]) : (text7 + "<br>" + Messages.msgPrdAccCode + array2[1]));
								}
							}
							else
							{
								text7 = text7 + "<br>" + string.Format(Messages.msgErrorTransferPrdToLinkAcc, Labels.Shygun);
							}
							break;
						}
						case 9:
						{
							string text8 = productController.ShygunIIActSendToAcc(wSProducts2.ProductID, SendToAccWithPrdPrice: false, model.SendPrdGroupToAcc.GetValueOrDefault());
							if (!string.IsNullOrEmpty(text8))
							{
								string[] array = text8.Split(new char[1] { '|' });
								if (array != null)
								{
									text7 = ((!(array[0] == "1") || array.Length != 2) ? (text7 + "<br>" + string.Format(Messages.msgErrorTransferPrdToLinkAcc, Labels.ShygunII) + "<br>" + array[0]) : (text7 + "<br>" + Messages.msgPrdAccCode + array[1]));
								}
							}
							else
							{
								text7 = text7 + "<br>" + string.Format(Messages.msgErrorTransferPrdToLinkAcc, Labels.ShygunII);
							}
							break;
						}
						}
					}
				}
				base.ViewBag.Successfull = text7;
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProducts");
				string sql = $"Select dbo.WSfnMakeAndReturnPrdCode ({fgId}, {sgId})";
				string prdCode = Enumerable.FirstOrDefault<string>(_db.Database.SqlQuery<string>(sql, Array.Empty<object>()));
				model = new WSProductsLanguageViewModel
				{
					PrdGroupID = sgId,
					PrdCode = prdCode,
					FPId = fgId,
					PrdInactiveInBuy = false,
					PrdInactiveInSale = false
				};
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			base.ViewBag.Error = Messages.frmErrorMessage;
		}
		return View(model);
	}

	[AjaxOnly]
	public string CheckDuplicatePrdCode(string code)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<WSspCheckDuplicatePrdCode_Result> list = Enumerable.ToList<WSspCheckDuplicatePrdCode_Result>((IEnumerable<WSspCheckDuplicatePrdCode_Result>)_db.WSspCheckDuplicatePrdCode(code, 0, lCID, result2));
			if (list.Count > 0)
			{
				result = Messages.msgErrorProductCodeIsDuplicate;
				result += "<br />";
				result += Enumerable.FirstOrDefault<WSspCheckDuplicatePrdCode_Result>((IEnumerable<WSspCheckDuplicatePrdCode_Result>)list).prdName.Replace("\r\n", "<br/>");
				result += "<br />";
				result += Messages.msgErrorProductCodeIsDuplicate1;
				result += "<br />";
				result += Messages.msgDoYouWantModifyPrdCode;
			}
		}
		catch (DbEntityValidationException ex)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)ex);
			result = "-ERROR" + Messages.frmErrorMessage + "<br/>" + ((Exception)(object)ex).Message;
		}
		catch (Exception ex2)
		{
			ErrorSignal.FromCurrentContext().Raise(ex2);
			result = "-ERROR" + Messages.frmErrorMessage + "<br/>" + ex2.Message;
		}
		return result;
	}

	public ActionResult _PartialProductsSearchItemsSimilar(string text = "", int prdId = 0)
	{
		base.ViewBag.Text = text;
		base.ViewBag.PrdId = prdId;
		return PartialView();
	}

	public ActionResult _PartialProductsSearchItemsSimilar_Read([DataSourceRequest] DataSourceRequest request, string text = "", int prdId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspCheckDuplicateProduct_Result> enumerable = Enumerable.ToList<WSspCheckDuplicateProduct_Result>((IEnumerable<WSspCheckDuplicateProduct_Result>)_db.WSspCheckDuplicateProduct(text, prdId, lCID, result));
		return Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	public string CheckDefaultProductForPrdGroup(int prdGroupId, int currPrdId)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (Enumerable.FirstOrDefault<WSspCheckDefaultProductForPrdGroup_Result>((IEnumerable<WSspCheckDefaultProductForPrdGroup_Result>)_db.WSspCheckDefaultProductForPrdGroup(currPrdId, prdGroupId, lCID, result2)) != null)
			{
				result = Messages.msgErrorPrdGroupHasDefPrd;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = Messages.msgErrorRunFunction;
		}
		return result;
	}

	[AjaxOnly]
	public JsonResult GetPrdLinkAccPrdGroup(int groupId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<WSspSelectProductSecondGroupLinkAccGroups_Result> list2 = Enumerable.ToList<WSspSelectProductSecondGroupLinkAccGroups_Result>((IEnumerable<WSspSelectProductSecondGroupLinkAccGroups_Result>)_dbLink.WSspSelectProductSecondGroupLinkAccGroups(groupId, lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectProductSecondGroupLinkAccGroups_Result, SelectListItem>((IEnumerable<WSspSelectProductSecondGroupLinkAccGroups_Result>)list2, (Func<WSspSelectProductSecondGroupLinkAccGroups_Result, SelectListItem>)((WSspSelectProductSecondGroupLinkAccGroups_Result item) => new SelectListItem
			{
				Text = (item.Name ?? ""),
				Value = item.Id,
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PrdLinkAccPrdGroupList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmProducts", ActionName = "actEditPrd")]
	public ActionResult ProductEdit(int prdId)
	{
		_003C_003Ec__DisplayClass27_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass27_0();
		CS_0024_003C_003E8__locals0.prdId = prdId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		DbSet<WSProducts_Lang> wSProducts_Lang = _dbTbl.WSProducts_Lang;
		ParameterExpression val = Expression.Parameter(typeof(WSProducts_Lang), "c");
		List<WSProducts_Lang> list = Enumerable.ToList<WSProducts_Lang>((IEnumerable<WSProducts_Lang>)Queryable.Where<WSProducts_Lang>((IQueryable<WSProducts_Lang>)wSProducts_Lang, Expression.Lambda<Func<WSProducts_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass27_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
		CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
		int result2 = 0;
		if (cRMspSelectCrmsysSetting_Result != null)
		{
			int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result2);
		}
		if (result2 == 1 || result2 == 4)
		{
			base.ViewBag.LinkAccSettingDBList = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccSettingDB(result2);
		}
		FillDropdownProduct();
		GetProjectTitleGroup();
		GetProjectTitles();
		GetPrjCnvsStatusGroups();
		GetCnvsTopic();
		GetReferUserActive();
		GetOrderOpr();
		GetPordDefSetting();
		GetCompanyType();
		GetCompanyGroupII();
		base.ViewBag.GrpName = "";
		DbSet<WSProducts> wSProducts = _dbTbl.WSProducts;
		val = Expression.Parameter(typeof(WSProducts), "c");
		WSProducts wSProducts2 = Queryable.FirstOrDefault<WSProducts>((IQueryable<WSProducts>)wSProducts, Expression.Lambda<Func<WSProducts, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass27_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
		CS_0024_003C_003E8__locals0.model = new WSProductsLanguageViewModel();
		if (wSProducts2 == null)
		{
			CS_0024_003C_003E8__locals0.model = new WSProductsLanguageViewModel();
			CS_0024_003C_003E8__locals0.model.ProductID = CS_0024_003C_003E8__locals0.prdId;
			return View(CS_0024_003C_003E8__locals0.model);
		}
		List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSProducts_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSProducts_Lang>)list, (Func<WSProducts_Lang, CommonMultiLanguageViewModel>)((WSProducts_Lang item) => new CommonMultiLanguageViewModel
		{
			Value = item.PrdDescription,
			LanguageId = item.LanguageID
		})));
		list2.Add(new CommonMultiLanguageViewModel
		{
			Value = wSProducts2.PrdDescription,
			LanguageId = result
		});
		List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSProducts_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSProducts_Lang>)list, (Func<WSProducts_Lang, CommonMultiLanguageViewModel>)((WSProducts_Lang item) => new CommonMultiLanguageViewModel
		{
			Value = item.PrdDesign,
			LanguageId = item.LanguageID
		})));
		list3.Add(new CommonMultiLanguageViewModel
		{
			Value = wSProducts2.PrdDesign,
			LanguageId = result
		});
		List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSProducts_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSProducts_Lang>)list, (Func<WSProducts_Lang, CommonMultiLanguageViewModel>)((WSProducts_Lang item) => new CommonMultiLanguageViewModel
		{
			Value = item.PrdModel,
			LanguageId = item.LanguageID
		})));
		list4.Add(new CommonMultiLanguageViewModel
		{
			Value = wSProducts2.PrdModel,
			LanguageId = result
		});
		List<CommonMultiLanguageViewModel> list5 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSProducts_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSProducts_Lang>)list, (Func<WSProducts_Lang, CommonMultiLanguageViewModel>)((WSProducts_Lang item) => new CommonMultiLanguageViewModel
		{
			Value = item.PrdName,
			LanguageId = item.LanguageID
		})));
		list5.Add(new CommonMultiLanguageViewModel
		{
			Value = wSProducts2.PrdName,
			LanguageId = result
		});
		List<CommonMultiLanguageViewModel> list6 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSProducts_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSProducts_Lang>)list, (Func<WSProducts_Lang, CommonMultiLanguageViewModel>)((WSProducts_Lang item) => new CommonMultiLanguageViewModel
		{
			Value = item.PrdSize,
			LanguageId = item.LanguageID
		})));
		list6.Add(new CommonMultiLanguageViewModel
		{
			Value = wSProducts2.PrdSize,
			LanguageId = result
		});
		List<CommonMultiLanguageViewModel> list7 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSProducts_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSProducts_Lang>)list, (Func<WSProducts_Lang, CommonMultiLanguageViewModel>)((WSProducts_Lang item) => new CommonMultiLanguageViewModel
		{
			Value = item.PrdType,
			LanguageId = item.LanguageID
		})));
		list7.Add(new CommonMultiLanguageViewModel
		{
			Value = wSProducts2.PrdType,
			LanguageId = result
		});
		List<CommonMultiLanguageViewModel> list8 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSProducts_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSProducts_Lang>)list, (Func<WSProducts_Lang, CommonMultiLanguageViewModel>)((WSProducts_Lang item) => new CommonMultiLanguageViewModel
		{
			Value = item.PrdManufacturerName,
			LanguageId = item.LanguageID
		})));
		list8.Add(new CommonMultiLanguageViewModel
		{
			Value = wSProducts2.PrdManufacturerName,
			LanguageId = result
		});
		List<CommonMultiLanguageViewModel> list9 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSProducts_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSProducts_Lang>)list, (Func<WSProducts_Lang, CommonMultiLanguageViewModel>)((WSProducts_Lang item) => new CommonMultiLanguageViewModel
		{
			Value = item.PrdLocation,
			LanguageId = item.LanguageID
		})));
		list9.Add(new CommonMultiLanguageViewModel
		{
			Value = wSProducts2.PrdLocation,
			LanguageId = result
		});
		List<CommonMultiLanguageViewModel> list10 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSProducts_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSProducts_Lang>)list, (Func<WSProducts_Lang, CommonMultiLanguageViewModel>)((WSProducts_Lang item) => new CommonMultiLanguageViewModel
		{
			Value = item.PrdNickname,
			LanguageId = item.LanguageID
		})));
		list10.Add(new CommonMultiLanguageViewModel
		{
			Value = wSProducts2.PrdNickname,
			LanguageId = result
		});
		List<CommonMultiLanguageViewModel> list11 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSProducts_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSProducts_Lang>)list, (Func<WSProducts_Lang, CommonMultiLanguageViewModel>)((WSProducts_Lang item) => new CommonMultiLanguageViewModel
		{
			Value = item.PrdAutoCalcPordItemDesc,
			LanguageId = item.LanguageID
		})));
		list11.Add(new CommonMultiLanguageViewModel
		{
			Value = wSProducts2.PrdAutoCalcPordItemDesc,
			LanguageId = result
		});
		List<CommonMultiLanguageViewModel> list12 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSProducts_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSProducts_Lang>)list, (Func<WSProducts_Lang, CommonMultiLanguageViewModel>)((WSProducts_Lang item) => new CommonMultiLanguageViewModel
		{
			Value = item.PrdAutoCalcPordPrjPostFix,
			LanguageId = item.LanguageID
		})));
		list12.Add(new CommonMultiLanguageViewModel
		{
			Value = wSProducts2.PrdAutoCalcPordPrjPostFix,
			LanguageId = result
		});
		List<CommonMultiLanguageViewModel> list13 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSProducts_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSProducts_Lang>)list, (Func<WSProducts_Lang, CommonMultiLanguageViewModel>)((WSProducts_Lang item) => new CommonMultiLanguageViewModel
		{
			Value = item.PrdAutoCalcPordCnvsDesc,
			LanguageId = item.LanguageID
		})));
		list13.Add(new CommonMultiLanguageViewModel
		{
			Value = wSProducts2.PrdAutoCalcPordCnvsDesc,
			LanguageId = result
		});
		List<CommonMultiLanguageViewModel> list14 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSProducts_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSProducts_Lang>)list, (Func<WSProducts_Lang, CommonMultiLanguageViewModel>)((WSProducts_Lang item) => new CommonMultiLanguageViewModel
		{
			Value = item.PrdOrdIssuePrjPostFix,
			LanguageId = item.LanguageID
		})));
		list14.Add(new CommonMultiLanguageViewModel
		{
			Value = wSProducts2.PrdOrdIssuePrjPostFix,
			LanguageId = result
		});
		List<CommonMultiLanguageViewModel> list15 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSProducts_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSProducts_Lang>)list, (Func<WSProducts_Lang, CommonMultiLanguageViewModel>)((WSProducts_Lang item) => new CommonMultiLanguageViewModel
		{
			Value = item.PrdValidityControlFODeActivePrjTitleGroupDesc,
			LanguageId = item.LanguageID
		})));
		list15.Add(new CommonMultiLanguageViewModel
		{
			Value = wSProducts2.PrdValidityControlFODeActivePrjTitleGroupDesc,
			LanguageId = result
		});
		CS_0024_003C_003E8__locals0.model = new WSProductsLanguageViewModel
		{
			PrdUnitId = wSProducts2.PrdUnitId,
			ProductID = wSProducts2.ProductID,
			prdAutoCharBarCodeTypeId = wSProducts2.prdAutoCharBarCodeTypeId,
			LanguageID = wSProducts2.LanguageID,
			UserId = wSProducts2.UserId,
			FirstRegisterUserId = wSProducts2.FirstRegisterUserId,
			FirstRegisterDatePersian = wSProducts2.FirstRegisterDatePersian,
			FirstRegisterDate = wSProducts2.FirstRegisterDate,
			AppType = wSProducts2.AppType,
			GUId = wSProducts2.GUId,
			RegisterDate = wSProducts2.RegisterDate,
			RegisterDatePersian = wSProducts2.RegisterDatePersian,
			Month1 = wSProducts2.Month1,
			PrdMaxQty = wSProducts2.PrdMaxQty,
			PrdLatinName = wSProducts2.PrdLatinName,
			PrdSecondSerial = wSProducts2.PrdSecondSerial,
			PrdFirstSerial = wSProducts2.PrdFirstSerial,
			PrdMinQty = wSProducts2.PrdMinQty,
			PrdThirdBarcode = wSProducts2.PrdThirdBarcode,
			PrdInactiveInBuy = wSProducts2.PrdInactiveInBuy,
			PrdInactiveInSale = wSProducts2.PrdInactiveInSale,
			PrdAutoCharBarcode = wSProducts2.PrdAutoCharBarcode,
			PrdThirdSerial = wSProducts2.PrdThirdSerial,
			PrdSecondBarcode = wSProducts2.PrdSecondBarcode,
			PrdColorId = wSProducts2.PrdColorId,
			PrdAutoNumBarcode = wSProducts2.PrdAutoNumBarcode,
			PrdFirstBarcode = wSProducts2.PrdFirstBarcode,
			PrdBarCode = wSProducts2.PrdBarCode,
			PrdSleepDay = wSProducts2.PrdSleepDay,
			PrdAutoNumBarCodeTypeId = wSProducts2.PrdAutoNumBarCodeTypeId,
			PrdCode = wSProducts2.PrdCode,
			FPId = wSProducts2.FPId,
			PrdGroupID = wSProducts2.PrdGroupID,
			PrdBarCodeTypeId = wSProducts2.PrdBarCodeTypeId,
			PrdDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
			PrdDesign = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
			PrdModel = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
			PrdName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
			PrdSize = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
			PrdType = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
			PrdDescription_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
			PrdDesign_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
			PrdModel_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
			PrdName_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
			PrdSize_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
			PrdType_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
			OrderView = wSProducts2.OrderView,
			PrdCommissionDisable = wSProducts2.PrdCommissionDisable,
			PrdCommissionPercentRate = wSProducts2.PrdCommissionPercentRate,
			PrdIsDefault = wSProducts2.PrdIsDefault,
			PrdInActive = wSProducts2.PrdInActive,
			PrdKind = wSProducts2.PrdKind,
			PrdDefQuantity = wSProducts2.PrdDefQuantity,
			PrdJustDefQuantity = wSProducts2.PrdJustDefQuantity,
			PrdMinQuantity = wSProducts2.PrdMinQuantity,
			PrdMaxQuantity = wSProducts2.PrdMaxQuantity,
			PrdManufacturerName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
			PrdManufacturerName_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
			PrdManufacturerCode = wSProducts2.PrdManufacturerCode,
			PrdLocation = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
			PrdLocation_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
			PrdLinkAccPrdGroupIdStr = wSProducts2.PrdLinkAccPrdGroupIdStr,
			PrdLinkAccPrdId = wSProducts2.PrdLinkAccPrdId,
			PrdLinkAccPrdCode = wSProducts2.PrdLinkAccPrdCode,
			PrdLinkAccPrdIdStr = wSProducts2.PrdLinkAccPrdIdStr,
			PrdIVRLink = wSProducts2.PrdIVRLink,
			PrdIVRLinkRule = wSProducts2.PrdIVRLinkRule,
			PrdIVRLinkDesc = wSProducts2.PrdIVRLinkDesc,
			PrdValidity = wSProducts2.PrdValidity,
			PrdValidityDay = wSProducts2.PrdValidityDay,
			PrdValidityTime = wSProducts2.PrdValidityTime,
			PrdUnitIdI = wSProducts2.PrdUnitIdI,
			PrdUnitIRate = wSProducts2.PrdUnitIRate,
			PrdUnitIRateCalcAuto = wSProducts2.PrdUnitIRateCalcAuto,
			PrdQtyNoFCR = wSProducts2.PrdQtyNoFCR,
			PrdMustFullTracingCode = wSProducts2.PrdMustFullTracingCode,
			PrdUnitIdII = wSProducts2.PrdUnitIdII,
			PrdUnitIIRate = wSProducts2.PrdUnitIIRate,
			PrdUnitIIRateCalcAuto = wSProducts2.PrdUnitIIRateCalcAuto,
			PrdSingleItem = wSProducts2.PrdSingleItem,
			PrdScore = wSProducts2.PrdScore,
			PrdValidityCounting = wSProducts2.PrdValidityCounting,
			PrdValidityCountingNum = wSProducts2.PrdValidityCountingNum,
			PrdValidityCountingMin = wSProducts2.PrdValidityCountingMin,
			PrdValidityCountingNumIsActive = wSProducts2.PrdValidityCountingNumIsActive,
			PrdValidityCountingNumNeedOrder = wSProducts2.PrdValidityCountingNumNeedOrder,
			PrdValidityCountingNumDefaultVal = wSProducts2.PrdValidityCountingNumDefaultVal,
			PrdValidityCountingNumNoCheckRemain = wSProducts2.PrdValidityCountingNumNoCheckRemain,
			PrdValidityCountingMinIsActive = wSProducts2.PrdValidityCountingMinIsActive,
			PrdValidityCountingMinNeedOrder = wSProducts2.PrdValidityCountingMinNeedOrder,
			PrdValidityCountingMinDefaultVal = wSProducts2.PrdValidityCountingMinDefaultVal,
			PrdValidityCountingMinNoCheckRemain = wSProducts2.PrdValidityCountingMinNoCheckRemain,
			PrdNickname = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
			PrdNickname_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
			PrdModuleName = wSProducts2.PrdModuleName,
			TspPrdIndentify = wSProducts2.TspPrdIndentify,
			TspPrdName = wSProducts2.TspPrdName,
			PrdAutoCalcIndexed = wSProducts2.PrdAutoCalcIndexed,
			PrdAutoCalcPordPrdId = wSProducts2.PrdAutoCalcPordPrdId,
			PrdAutoCalcPriceFromOrdItemRate = wSProducts2.PrdAutoCalcPriceFromOrdItemRate,
			PrdAutoCalcDisabled = wSProducts2.PrdAutoCalcDisabled,
			PrdAutoCalcPriceFromOrdItemPrdGroups = wSProducts2.PrdAutoCalcPriceFromOrdItemPrdGroups,
			PrdAutoCalcDynamicRate = wSProducts2.PrdAutoCalcDynamicRate,
			PrdAutoCalcInflationLastDurationRate = wSProducts2.PrdAutoCalcInflationLastDurationRate,
			PrdAutoCalcIndexedPrdId = wSProducts2.PrdAutoCalcIndexedPrdId,
			PrdAutoCalcPordVerifyAfterIssue = wSProducts2.PrdAutoCalcPordVerifyAfterIssue,
			PrdAutoCalcPordReferUser = wSProducts2.PrdAutoCalcPordReferUser,
			PrdAutoCalcPordExpireDynamicRate = wSProducts2.PrdAutoCalcPordExpireDynamicRate,
			PrdAutoCalcPordExpireDay = wSProducts2.PrdAutoCalcPordExpireDay,
			PrdAutoCalcPordItemDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
			PrdAutoCalcPordItemDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
			PrdAutoCalcPordTaxDetectFromLastOrd = wSProducts2.PrdAutoCalcPordTaxDetectFromLastOrd,
			PrdAutoCalcPordTaxDefSettingId = wSProducts2.PrdAutoCalcPordTaxDefSettingId,
			PrdAutoCalcPordNoTaxDefSettingId = wSProducts2.PrdAutoCalcPordNoTaxDefSettingId,
			PrdAutoCalcPordPrjTitleGroupId = wSProducts2.PrdAutoCalcPordPrjTitleGroupId,
			PrdAutoCalcPordPrjTitleId = wSProducts2.PrdAutoCalcPordPrjTitleId,
			PrdAutoCalcPordPrjPostFix = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
			PrdAutoCalcPordPrjPostFix_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
			PrdAutoCalcPordPrjCnvsStatusGroupId = wSProducts2.PrdAutoCalcPordPrjCnvsStatusGroupId,
			PrdAutoCalcPordPrjFOCmpCanSee = wSProducts2.PrdAutoCalcPordPrjFOCmpCanSee,
			PrdAutoCalcPordPrjIsTicket = wSProducts2.PrdAutoCalcPordPrjIsTicket,
			PrdAutoCalcPordPrjUsedType = wSProducts2.PrdAutoCalcPordPrjUsedType,
			PrdAutoCalcPordAddCnvs = wSProducts2.PrdAutoCalcPordAddCnvs,
			PrdAutoCalcPordCnvsTopicId = wSProducts2.PrdAutoCalcPordCnvsTopicId,
			PrdAutoCalcPordCnvsDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
			PrdAutoCalcPordCnvsDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
			PrdAutoCalcPordCnvsReferUser = wSProducts2.PrdAutoCalcPordCnvsReferUser,
			PrdAutoCalcPordCnvsStatusId = wSProducts2.PrdAutoCalcPordCnvsStatusId,
			PrdAutoCalcPordCnvsStatusResultId = wSProducts2.PrdAutoCalcPordCnvsStatusResultId,
			PrdAutoCalcPordCnvsRemindDay = wSProducts2.PrdAutoCalcPordCnvsRemindDay,
			PrdAutoCalcIssueOrdFromIndexed = wSProducts2.PrdAutoCalcIssueOrdFromIndexed,
			PrdAutoCalcIssueOrdFromIndexedOprId = wSProducts2.PrdAutoCalcIssueOrdFromIndexedOprId,
			PrdOrdIssueSetSetting = wSProducts2.PrdOrdIssueSetSetting,
			PrdOrdIssuePrjTitleGroupId = wSProducts2.PrdOrdIssuePrjTitleGroupId,
			PrdOrdIssuePrjTitleId = wSProducts2.PrdOrdIssuePrjTitleId,
			PrdOrdIssuePrjPostFix = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
			PrdOrdIssuePrjPostFix_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
			PrdOrdIssuePrjCnvsStatusGroupId = wSProducts2.PrdOrdIssuePrjCnvsStatusGroupId,
			PrdOrdIssuePrjRemindDay = wSProducts2.PrdOrdIssuePrjRemindDay,
			PrdOrdIssuePrjFOCmpCanSee = wSProducts2.PrdOrdIssuePrjFOCmpCanSee,
			PrdOrdIssuePrjIsTicket = wSProducts2.PrdOrdIssuePrjIsTicket,
			PrdOrdIssuePrjUsedType = wSProducts2.PrdOrdIssuePrjUsedType,
			PrdValidityUpdatePrjRemindDateAfterIssueOrd = wSProducts2.PrdValidityUpdatePrjRemindDateAfterIssueOrd,
			PrdOrdIssueUpdateCmpTypeId = wSProducts2.PrdOrdIssueUpdateCmpTypeId,
			PrdOrdIssueUpdateCmpGroupII = wSProducts2.PrdOrdIssueUpdateCmpGroupII,
			PrdOrdIssueUpdateTaxCmpGroupIdII = wSProducts2.PrdOrdIssueUpdateTaxCmpGroupIdII,
			PrdOrdIssueUpdateNoTaxCmpGroupIdII = wSProducts2.PrdOrdIssueUpdateNoTaxCmpGroupIdII,
			PrdOrdIssueDateToCmpEffectiveDate = wSProducts2.PrdOrdIssueDateToCmpEffectiveDate,
			PrdAutoCalcIndexBreakDay = wSProducts2.PrdAutoCalcIndexBreakDay,
			PrdAutoCalcDynamicRateJustCompleteDuration = wSProducts2.PrdAutoCalcDynamicRateJustCompleteDuration,
			PrdAutoCalcInflationLastYearNumChange = wSProducts2.PrdAutoCalcInflationLastYearNumChange,
			PrdAutoCalcInflationLastDuration = wSProducts2.PrdAutoCalcInflationLastDuration,
			PrdAutoCalcInflationLastYearNumChangeRate = wSProducts2.PrdAutoCalcInflationLastYearNumChangeRate,
			PrdAutoCalcPriceFromOrdItemInBreak = wSProducts2.PrdAutoCalcPriceFromOrdItemInBreak,
			PrdAutoCalcPriceFromIndex = wSProducts2.PrdAutoCalcPriceFromIndex,
			PrdAutoCalcPriceFromIndexRate = wSProducts2.PrdAutoCalcPriceFromIndexRate,
			PrdAutoCalcPriceFromOrdItem = wSProducts2.PrdAutoCalcPriceFromOrdItem,
			PrdAutoCalcPriceFromOrdItemAfterBreak = wSProducts2.PrdAutoCalcPriceFromOrdItemAfterBreak,
			PrdValidityControlFOPrjTitleGroup = wSProducts2.PrdValidityControlFOPrjTitleGroup,
			PrdValidityControlFOPrjTitleGroupIds = wSProducts2.PrdValidityControlFOPrjTitleGroupIds,
			PrdValidityControlFODeActivePrjTitleGroupDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list15, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list15, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
			PrdValidityControlFODeActivePrjTitleGroupDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list15, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
			PrdCanChangePrice = wSProducts2.PrdCanChangePrice,
			PrdLinkAccData = wSProducts2.PrdLinkAccData,
			PrdSaleCenterIds = wSProducts2.PrdSaleCenterIds,
			PrdDoneTimeMin = wSProducts2.PrdDoneTimeMin,
			PrdRowColor = Public.TColorToHex(wSProducts2.PrdRowColor),
			PrdWeight = wSProducts2.PrdWeight,
			PrdAutoCalcPrice = wSProducts2.PrdAutoCalcPrice,
			PrdAutoCalcPricePercent = wSProducts2.PrdAutoCalcPricePercent,
			PrdQtyCanDecimal = wSProducts2.PrdQtyCanDecimal
		};
		string text = null;
		if (CS_0024_003C_003E8__locals0.model != null)
		{
			text = CS_0024_003C_003E8__locals0.model.PrdValidityTime;
			if (!string.IsNullOrWhiteSpace(text))
			{
				string[] array = text.Split(new char[1] { ':' });
				if (array != null && Enumerable.Any<string>((IEnumerable<string>)array) && array.Length == 2)
				{
					CS_0024_003C_003E8__locals0.model.PrdValidityTimeHour = Convert.ToInt32(array[0]);
					CS_0024_003C_003E8__locals0.model.PrdValidityTimeMinute = Convert.ToInt32(array[1]);
				}
			}
			if (CS_0024_003C_003E8__locals0.model.PrdAutoCalcIndexedPrdId.HasValue)
			{
				WSspSelectProductsWithId_Result wSspSelectProductsWithId_Result = Enumerable.FirstOrDefault<WSspSelectProductsWithId_Result>((IEnumerable<WSspSelectProductsWithId_Result>)_db.WSspSelectProductsWithId(CS_0024_003C_003E8__locals0.model.PrdAutoCalcIndexedPrdId, CS_0024_003C_003E8__locals0.currLangID, result));
				if (wSspSelectProductsWithId_Result != null)
				{
					CS_0024_003C_003E8__locals0.model.Search_PrdAutoCalcIndexedPrdId = wSspSelectProductsWithId_Result.PrdName ?? "";
				}
			}
			if (CS_0024_003C_003E8__locals0.model.PrdAutoCalcPordPrdId.HasValue)
			{
				WSspSelectProductsWithId_Result wSspSelectProductsWithId_Result2 = Enumerable.FirstOrDefault<WSspSelectProductsWithId_Result>((IEnumerable<WSspSelectProductsWithId_Result>)_db.WSspSelectProductsWithId(CS_0024_003C_003E8__locals0.model.PrdAutoCalcPordPrdId, CS_0024_003C_003E8__locals0.currLangID, result));
				if (wSspSelectProductsWithId_Result2 != null)
				{
					CS_0024_003C_003E8__locals0.model.Search_PrdAutoCalcPordPrdId = wSspSelectProductsWithId_Result2.PrdName ?? "";
				}
			}
			if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.model.PrdAutoCalcPriceFromOrdItemPrdGroups))
			{
				List<WSspSelectProductSecondGroupWithIds_Result> list16 = Enumerable.ToList<WSspSelectProductSecondGroupWithIds_Result>((IEnumerable<WSspSelectProductSecondGroupWithIds_Result>)_dbI.WSspSelectProductSecondGroupWithIds(CS_0024_003C_003E8__locals0.model.PrdAutoCalcPriceFromOrdItemPrdGroups, ",", CS_0024_003C_003E8__locals0.currLangID, result));
				if (list16 != null && Enumerable.Any<WSspSelectProductSecondGroupWithIds_Result>((IEnumerable<WSspSelectProductSecondGroupWithIds_Result>)list16))
				{
					List<CommonMultiAndIdLanguageViewModel> list17 = new List<CommonMultiAndIdLanguageViewModel>();
					foreach (WSspSelectProductSecondGroupWithIds_Result item4 in list16)
					{
						CommonMultiAndIdLanguageViewModel item2 = new CommonMultiAndIdLanguageViewModel
						{
							Id = item4.PrdSecondGroupID,
							Value = (item4.SGName ?? "")
						};
						list17.Add(item2);
					}
					if (list17 != null && Enumerable.Any<CommonMultiAndIdLanguageViewModel>((IEnumerable<CommonMultiAndIdLanguageViewModel>)list17))
					{
						CS_0024_003C_003E8__locals0.model.PrdAutoCalcPriceFromOrdItemPrdGroupsJson = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiAndIdLanguageViewModel>((IEnumerable<CommonMultiAndIdLanguageViewModel>)list17));
					}
				}
			}
			if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.model.PrdValidityControlFOPrjTitleGroupIds))
			{
				List<CRMspSelectProjectTitleGroupsWithIds_Result> list18 = Enumerable.ToList<CRMspSelectProjectTitleGroupsWithIds_Result>((IEnumerable<CRMspSelectProjectTitleGroupsWithIds_Result>)_dbI.CRMspSelectProjectTitleGroupsWithIds(CS_0024_003C_003E8__locals0.model.PrdValidityControlFOPrjTitleGroupIds, ",", CS_0024_003C_003E8__locals0.currLangID, result));
				if (list18 != null && Enumerable.Any<CRMspSelectProjectTitleGroupsWithIds_Result>((IEnumerable<CRMspSelectProjectTitleGroupsWithIds_Result>)list18))
				{
					List<CommonMultiAndIdLanguageViewModel> list19 = new List<CommonMultiAndIdLanguageViewModel>();
					foreach (CRMspSelectProjectTitleGroupsWithIds_Result item5 in list18)
					{
						CommonMultiAndIdLanguageViewModel item3 = new CommonMultiAndIdLanguageViewModel
						{
							Id = item5.ProjectTitleGroupId,
							Value = (item5.ProjectTitleGroup ?? "")
						};
						list19.Add(item3);
					}
					if (list19 != null && Enumerable.Any<CommonMultiAndIdLanguageViewModel>((IEnumerable<CommonMultiAndIdLanguageViewModel>)list19))
					{
						CS_0024_003C_003E8__locals0.model.PrdValidityControlFOPrjTitleGroupIdsJson = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiAndIdLanguageViewModel>((IEnumerable<CommonMultiAndIdLanguageViewModel>)list19));
					}
				}
			}
		}
		if (CS_0024_003C_003E8__locals0.model != null && !string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.model.PrdSaleCenterIds))
		{
			List<WSspSelectSaleCenterWithIds_Result> list20 = Enumerable.ToList<WSspSelectSaleCenterWithIds_Result>((IEnumerable<WSspSelectSaleCenterWithIds_Result>)_dbII.WSspSelectSaleCenterWithIds(CS_0024_003C_003E8__locals0.model.PrdSaleCenterIds, ",", CS_0024_003C_003E8__locals0.currLangID, result));
			if (list20 != null && Enumerable.Any<WSspSelectSaleCenterWithIds_Result>((IEnumerable<WSspSelectSaleCenterWithIds_Result>)list20))
			{
				string text2 = "";
				foreach (WSspSelectSaleCenterWithIds_Result item6 in list20)
				{
					if (!string.IsNullOrWhiteSpace(item6.SaleCenterName))
					{
						if (!string.IsNullOrWhiteSpace(text2))
						{
							text2 += ",";
						}
						text2 += item6.SaleCenterName;
					}
				}
				CS_0024_003C_003E8__locals0.model.PrdSaleCenterNames = text2;
			}
		}
		string text3 = "";
		CS_0024_003C_003E8__locals0.secondGrp = Enumerable.FirstOrDefault<WSspSelectWSProductSecondGroup_Result>((IEnumerable<WSspSelectWSProductSecondGroup_Result>)Enumerable.ToList<WSspSelectWSProductSecondGroup_Result>((IEnumerable<WSspSelectWSProductSecondGroup_Result>)_db.WSspSelectWSProductSecondGroup(CS_0024_003C_003E8__locals0.currLangID, result, 0)), (Func<WSspSelectWSProductSecondGroup_Result, bool>)((WSspSelectWSProductSecondGroup_Result c) => c.PrdSecondGroupID == CS_0024_003C_003E8__locals0.model.PrdGroupID));
		WSspSelectProductFirstGroup_Result wSspSelectProductFirstGroup_Result = new WSspSelectProductFirstGroup_Result();
		if (CS_0024_003C_003E8__locals0.secondGrp != null)
		{
			wSspSelectProductFirstGroup_Result = Enumerable.FirstOrDefault<WSspSelectProductFirstGroup_Result>((IEnumerable<WSspSelectProductFirstGroup_Result>)Enumerable.ToList<WSspSelectProductFirstGroup_Result>((IEnumerable<WSspSelectProductFirstGroup_Result>)_db.WSspSelectProductFirstGroup(CS_0024_003C_003E8__locals0.currLangID, result)), (Func<WSspSelectProductFirstGroup_Result, bool>)((WSspSelectProductFirstGroup_Result c) => c.PrdFirstGroupID == CS_0024_003C_003E8__locals0.secondGrp.FirstGroupId));
		}
		text3 += ((wSspSelectProductFirstGroup_Result != null) ? wSspSelectProductFirstGroup_Result.FGName : "");
		if (CS_0024_003C_003E8__locals0.secondGrp != null)
		{
			if (text3 != "")
			{
				text3 += " - ";
			}
			text3 += CS_0024_003C_003E8__locals0.secondGrp.SGName;
		}
		base.ViewBag.GrpName = text3;
		GetPrdLinkAccPrdGroup(CS_0024_003C_003E8__locals0.model.PrdGroupID);
		return View(CS_0024_003C_003E8__locals0.model);
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmProductsDataEntry", ActionName = "actPost")]
	public ActionResult ProductEdit(WSProductsLanguageViewModel model)
	{
		//IL_028b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02df: Unknown result type (might be due to invalid IL or missing references)
		//IL_0333: Unknown result type (might be due to invalid IL or missing references)
		//IL_0387: Unknown result type (might be due to invalid IL or missing references)
		//IL_03db: Unknown result type (might be due to invalid IL or missing references)
		//IL_042f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0483: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_052b: Unknown result type (might be due to invalid IL or missing references)
		//IL_057f: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0627: Unknown result type (might be due to invalid IL or missing references)
		//IL_067b: Unknown result type (might be due to invalid IL or missing references)
		//IL_06cf: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass28_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass28_0();
		CS_0024_003C_003E8__locals0.model = model;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
		int result = 0;
		if (cRMspSelectCrmsysSetting_Result != null)
		{
			int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result);
		}
		if (result == 1 || result == 4)
		{
			base.ViewBag.LinkAccSettingDBList = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccSettingDB(result);
		}
		FillDropdownProduct();
		GetProjectTitleGroup();
		GetProjectTitles();
		GetPrjCnvsStatusGroups();
		GetCnvsTopic();
		GetReferUserActive();
		GetOrderOpr();
		GetPordDefSetting();
		GetCompanyType();
		GetCompanyGroupII();
		string text = "";
		CS_0024_003C_003E8__locals0.secondGrp = Enumerable.FirstOrDefault<WSspSelectWSProductSecondGroup_Result>((IEnumerable<WSspSelectWSProductSecondGroup_Result>)Enumerable.ToList<WSspSelectWSProductSecondGroup_Result>((IEnumerable<WSspSelectWSProductSecondGroup_Result>)_db.WSspSelectWSProductSecondGroup(lCID, CS_0024_003C_003E8__locals0.defLangID, 0)), (Func<WSspSelectWSProductSecondGroup_Result, bool>)((WSspSelectWSProductSecondGroup_Result c) => c.PrdSecondGroupID == CS_0024_003C_003E8__locals0.model.PrdGroupID));
		WSspSelectProductFirstGroup_Result wSspSelectProductFirstGroup_Result = null;
		if (CS_0024_003C_003E8__locals0.secondGrp != null)
		{
			wSspSelectProductFirstGroup_Result = Enumerable.FirstOrDefault<WSspSelectProductFirstGroup_Result>((IEnumerable<WSspSelectProductFirstGroup_Result>)Enumerable.ToList<WSspSelectProductFirstGroup_Result>((IEnumerable<WSspSelectProductFirstGroup_Result>)_db.WSspSelectProductFirstGroup(lCID, CS_0024_003C_003E8__locals0.defLangID)), (Func<WSspSelectProductFirstGroup_Result, bool>)((WSspSelectProductFirstGroup_Result c) => c.PrdFirstGroupID == CS_0024_003C_003E8__locals0.secondGrp.FirstGroupId));
		}
		text += ((wSspSelectProductFirstGroup_Result != null) ? wSspSelectProductFirstGroup_Result.FGName : "");
		if (CS_0024_003C_003E8__locals0.secondGrp != null)
		{
			if (text != "")
			{
				text += " - ";
			}
			text += CS_0024_003C_003E8__locals0.secondGrp.SGName;
		}
		base.ViewBag.GrpName = text;
		GetPrdLinkAccPrdGroup(CS_0024_003C_003E8__locals0.model.PrdGroupID);
		List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.PrdName_Lang))
		{
			list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.PrdName_Lang);
		}
		list.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.model.PrdName,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.PrdType_Lang))
		{
			list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.PrdType_Lang);
		}
		list2.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.model.PrdType,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.PrdDesign_Lang))
		{
			list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.PrdDesign_Lang);
		}
		list3.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.model.PrdDesign,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.PrdSize_Lang))
		{
			list4 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.PrdSize_Lang);
		}
		list4.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.model.PrdSize,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list5 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.PrdDescription_Lang))
		{
			list5 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.PrdDescription_Lang);
		}
		list5.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.model.PrdDescription,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list6 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.PrdModel_Lang))
		{
			list6 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.PrdModel_Lang);
		}
		list6.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.model.PrdModel,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list7 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.PrdManufacturerName_Lang))
		{
			list7 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.PrdManufacturerName_Lang);
		}
		list7.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.model.PrdManufacturerName,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list8 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.PrdLocation_Lang))
		{
			list8 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.PrdLocation_Lang);
		}
		list8.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.model.PrdLocation,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list9 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.PrdNickname_Lang))
		{
			list9 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.PrdNickname_Lang);
		}
		list9.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.model.PrdNickname,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list10 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.PrdAutoCalcPordItemDesc_Lang))
		{
			list10 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.PrdAutoCalcPordItemDesc_Lang);
		}
		list10.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.model.PrdAutoCalcPordItemDesc,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list11 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.PrdAutoCalcPordPrjPostFix_Lang))
		{
			list11 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.PrdAutoCalcPordPrjPostFix_Lang);
		}
		list11.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.model.PrdAutoCalcPordPrjPostFix,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list12 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.PrdAutoCalcPordCnvsDesc_Lang))
		{
			list12 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.PrdAutoCalcPordCnvsDesc_Lang);
		}
		list12.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.model.PrdAutoCalcPordCnvsDesc,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list13 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.PrdOrdIssuePrjPostFix_Lang))
		{
			list13 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.PrdOrdIssuePrjPostFix_Lang);
		}
		list13.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.model.PrdOrdIssuePrjPostFix,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list14 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.PrdValidityControlFODeActivePrjTitleGroupDesc_Lang))
		{
			list14 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.PrdValidityControlFODeActivePrjTitleGroupDesc_Lang);
		}
		list14.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.model.PrdValidityControlFODeActivePrjTitleGroupDesc,
			LanguageId = lCID
		});
		string text2 = "";
		if (CS_0024_003C_003E8__locals0.model.PrdName == null && CS_0024_003C_003E8__locals0.model.PrdName == "")
		{
			text2 = text2 + Messages.CheckPrdName + "<br/>";
		}
		else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.model.PrdName, list))
		{
			text2 = text2 + Messages.CheckPrdNameLang + "<br>";
		}
		if (text2 != "")
		{
			base.ViewBag.Error = text2;
		}
		else if (!base.ModelState.IsValid)
		{
			base.ViewBag.Error = Messages.frmErrorMessage + "<br/> " + string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
		}
		else
		{
			try
			{
				DbSet<WSProducts> wSProducts = _dbTbl.WSProducts;
				ParameterExpression val = Expression.Parameter(typeof(WSProducts), "c");
				WSProducts wSProducts2 = Queryable.FirstOrDefault<WSProducts>((IQueryable<WSProducts>)wSProducts, Expression.Lambda<Func<WSProducts, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass28_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (wSProducts2 == null)
				{
					base.ViewBag.Error = Messages.ErrorNotFound;
				}
				else
				{
					int result2 = 0;
					if (SysSeting.Get() != null)
					{
						int.TryParse(SysSeting.Get().LinkAccSystemId.ToString(), out result2);
					}
					string text3 = "";
					bool flag = false;
					switch (result2)
					{
					case 8:
					{
						flag = true;
						CRMIdeal.Classes.Helper.OtherSystems.ShygunSettingViewModel shygunSetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunSetting();
						if (shygunSetting != null)
						{
							text3 = shygunSetting.PrdLinkedField ?? "";
						}
						break;
					}
					case 9:
					{
						flag = true;
						CRMIdeal.Classes.Helper.OtherSystems.ShygunIISettingViewModel shygunIISetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunIISetting();
						if (shygunIISetting != null)
						{
							text3 = shygunIISetting.PrdLinkedField ?? "";
						}
						break;
					}
					}
					wSProducts2.FPId = Financial.Get().Id;
					wSProducts2.UserId = UserLogin.CurrentUser.UserId;
					wSProducts2.RegisterDate = DateTime.Now;
					wSProducts2.RegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
					wSProducts2.Month1 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					wSProducts2.AppType = Configuration.AppType;
					wSProducts2.PrdAutoCharBarcode = CS_0024_003C_003E8__locals0.model.PrdAutoCharBarcode;
					wSProducts2.PrdAutoNumBarCodeTypeId = CS_0024_003C_003E8__locals0.model.PrdAutoNumBarCodeTypeId;
					wSProducts2.PrdAutoNumBarcode = CS_0024_003C_003E8__locals0.model.PrdAutoNumBarcode;
					wSProducts2.PrdBarCode = CS_0024_003C_003E8__locals0.model.PrdBarCode;
					wSProducts2.PrdBarCodeTypeId = CS_0024_003C_003E8__locals0.model.PrdBarCodeTypeId;
					if (VersionBuyer.LinkAcc && flag && text3.ToLower() == "prdcode")
					{
						if (string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.model.PrdLinkAccPrdCode) && string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.model.PrdLinkAccPrdIdStr) && (!CS_0024_003C_003E8__locals0.model.PrdLinkAccPrdId.HasValue || CS_0024_003C_003E8__locals0.model.PrdLinkAccPrdId <= 0))
						{
							wSProducts2.PrdCode = CS_0024_003C_003E8__locals0.model.PrdCode;
						}
					}
					else
					{
						wSProducts2.PrdCode = CS_0024_003C_003E8__locals0.model.PrdCode;
					}
					wSProducts2.PrdColorId = CS_0024_003C_003E8__locals0.model.PrdColorId;
					if (VersionBuyer.LinkAcc && flag && text3.ToLower() == "prdfirstbarcode")
					{
						if (string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.model.PrdLinkAccPrdCode) && string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.model.PrdLinkAccPrdIdStr) && (!CS_0024_003C_003E8__locals0.model.PrdLinkAccPrdId.HasValue || CS_0024_003C_003E8__locals0.model.PrdLinkAccPrdId <= 0))
						{
							wSProducts2.PrdFirstBarcode = CS_0024_003C_003E8__locals0.model.PrdFirstBarcode;
						}
					}
					else
					{
						wSProducts2.PrdFirstBarcode = CS_0024_003C_003E8__locals0.model.PrdFirstBarcode;
					}
					if (VersionBuyer.LinkAcc && string.IsNullOrWhiteSpace(wSProducts2.PrdLinkAccPrdIdStr) && wSProducts2.PrdLinkAccPrdId.GetValueOrDefault() == 0)
					{
						wSProducts2.PrdLinkAccPrdCode = CS_0024_003C_003E8__locals0.model.PrdLinkAccPrdCode;
					}
					wSProducts2.PrdFirstSerial = CS_0024_003C_003E8__locals0.model.PrdFirstSerial;
					wSProducts2.PrdGroupID = CS_0024_003C_003E8__locals0.model.PrdGroupID;
					wSProducts2.PrdInactiveInBuy = CS_0024_003C_003E8__locals0.model.PrdInactiveInBuy;
					wSProducts2.PrdInactiveInSale = CS_0024_003C_003E8__locals0.model.PrdInactiveInSale;
					wSProducts2.PrdLatinName = CS_0024_003C_003E8__locals0.model.PrdLatinName;
					wSProducts2.PrdMaxQty = CS_0024_003C_003E8__locals0.model.PrdMaxQty;
					wSProducts2.PrdMinQty = CS_0024_003C_003E8__locals0.model.PrdMinQty;
					wSProducts2.PrdSecondBarcode = CS_0024_003C_003E8__locals0.model.PrdSecondBarcode;
					wSProducts2.PrdSecondSerial = CS_0024_003C_003E8__locals0.model.PrdSecondSerial;
					wSProducts2.PrdSleepDay = CS_0024_003C_003E8__locals0.model.PrdSleepDay;
					wSProducts2.PrdThirdBarcode = CS_0024_003C_003E8__locals0.model.PrdThirdBarcode;
					wSProducts2.PrdThirdSerial = CS_0024_003C_003E8__locals0.model.PrdThirdSerial;
					wSProducts2.PrdUnitId = CS_0024_003C_003E8__locals0.model.PrdUnitId;
					wSProducts2.PrdUnitIdI = CS_0024_003C_003E8__locals0.model.PrdUnitIdI;
					wSProducts2.PrdUnitIRate = CS_0024_003C_003E8__locals0.model.PrdUnitIRate;
					wSProducts2.PrdUnitIRateCalcAuto = CS_0024_003C_003E8__locals0.model.PrdUnitIRateCalcAuto;
					wSProducts2.PrdQtyNoFCR = CS_0024_003C_003E8__locals0.model.PrdQtyNoFCR;
					wSProducts2.PrdMustFullTracingCode = CS_0024_003C_003E8__locals0.model.PrdMustFullTracingCode;
					wSProducts2.PrdUnitIdII = CS_0024_003C_003E8__locals0.model.PrdUnitIdII;
					wSProducts2.PrdUnitIIRate = CS_0024_003C_003E8__locals0.model.PrdUnitIIRate;
					wSProducts2.PrdUnitIIRateCalcAuto = CS_0024_003C_003E8__locals0.model.PrdUnitIIRateCalcAuto;
					wSProducts2.PrdSingleItem = CS_0024_003C_003E8__locals0.model.PrdSingleItem;
					wSProducts2.prdAutoCharBarCodeTypeId = CS_0024_003C_003E8__locals0.model.prdAutoCharBarCodeTypeId;
					wSProducts2.PrdName = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					wSProducts2.PrdType = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					wSProducts2.PrdDesign = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					wSProducts2.PrdSize = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					wSProducts2.PrdDescription = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					wSProducts2.PrdNickname = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					wSProducts2.PrdModuleName = CS_0024_003C_003E8__locals0.model.PrdModuleName;
					if (VersionBuyer.LinkAcc && flag && text3.ToLower() == "prdmodel")
					{
						if (string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.model.PrdLinkAccPrdCode) && string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.model.PrdLinkAccPrdIdStr) && (!CS_0024_003C_003E8__locals0.model.PrdLinkAccPrdId.HasValue || CS_0024_003C_003E8__locals0.model.PrdLinkAccPrdId <= 0))
						{
							wSProducts2.PrdModel = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						}
					}
					else
					{
						wSProducts2.PrdModel = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					}
					wSProducts2.PrdScore = CS_0024_003C_003E8__locals0.model.PrdScore;
					wSProducts2.OrderView = CS_0024_003C_003E8__locals0.model.OrderView;
					wSProducts2.PrdCommissionDisable = CS_0024_003C_003E8__locals0.model.PrdCommissionDisable;
					wSProducts2.PrdCommissionPercentRate = CS_0024_003C_003E8__locals0.model.PrdCommissionPercentRate;
					wSProducts2.PrdIsDefault = CS_0024_003C_003E8__locals0.model.PrdIsDefault;
					wSProducts2.PrdInActive = CS_0024_003C_003E8__locals0.model.PrdInActive;
					wSProducts2.PrdKind = CS_0024_003C_003E8__locals0.model.PrdKind;
					wSProducts2.PrdDefQuantity = CS_0024_003C_003E8__locals0.model.PrdDefQuantity;
					wSProducts2.PrdJustDefQuantity = CS_0024_003C_003E8__locals0.model.PrdJustDefQuantity;
					wSProducts2.PrdMinQuantity = CS_0024_003C_003E8__locals0.model.PrdMinQuantity;
					wSProducts2.PrdMaxQuantity = CS_0024_003C_003E8__locals0.model.PrdMaxQuantity;
					wSProducts2.PrdManufacturerName = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					wSProducts2.PrdManufacturerCode = CS_0024_003C_003E8__locals0.model.PrdManufacturerCode;
					wSProducts2.PrdLocation = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					wSProducts2.PrdLinkAccPrdGroupIdStr = CS_0024_003C_003E8__locals0.model.PrdLinkAccPrdGroupIdStr;
					_ = VersionBuyer.PrdIVRLink;
					bool prdIVRLink = VersionBuyer.PrdIVRLink;
					_ = VersionBuyer.PrdValidity;
					bool prdValidity = VersionBuyer.PrdValidity;
					if (prdIVRLink)
					{
						wSProducts2.PrdIVRLink = CS_0024_003C_003E8__locals0.model.PrdIVRLink;
						wSProducts2.PrdIVRLinkRule = CS_0024_003C_003E8__locals0.model.PrdIVRLinkRule;
						wSProducts2.PrdIVRLinkDesc = CS_0024_003C_003E8__locals0.model.PrdIVRLinkDesc;
					}
					else
					{
						bool? prdIVRLink2 = (CS_0024_003C_003E8__locals0.model.PrdIVRLink = null);
						wSProducts2.PrdIVRLink = prdIVRLink2;
						string prdIVRLinkRule = (CS_0024_003C_003E8__locals0.model.PrdIVRLinkRule = null);
						wSProducts2.PrdIVRLinkRule = prdIVRLinkRule;
						prdIVRLinkRule = (CS_0024_003C_003E8__locals0.model.PrdIVRLinkDesc = null);
						wSProducts2.PrdIVRLinkDesc = prdIVRLinkRule;
					}
					if (prdValidity)
					{
						wSProducts2.PrdValidity = CS_0024_003C_003E8__locals0.model.PrdValidity;
						wSProducts2.PrdValidityDay = CS_0024_003C_003E8__locals0.model.PrdValidityDay;
						string prdValidityTime = null;
						if (CS_0024_003C_003E8__locals0.model.PrdValidityTimeHour.HasValue || CS_0024_003C_003E8__locals0.model.PrdValidityTimeMinute.HasValue)
						{
							string obj = ((CS_0024_003C_003E8__locals0.model.PrdValidityTimeHour.GetValueOrDefault() == 0 || CS_0024_003C_003E8__locals0.model.PrdValidityTimeHour.GetValueOrDefault() <= 9) ? ("0" + CS_0024_003C_003E8__locals0.model.PrdValidityTimeHour.GetValueOrDefault()) : CS_0024_003C_003E8__locals0.model.PrdValidityTimeHour.GetValueOrDefault().ToString());
							string text6 = ((CS_0024_003C_003E8__locals0.model.PrdValidityTimeMinute.GetValueOrDefault() == 0 || CS_0024_003C_003E8__locals0.model.PrdValidityTimeMinute.GetValueOrDefault() <= 9) ? ("0" + CS_0024_003C_003E8__locals0.model.PrdValidityTimeMinute.GetValueOrDefault()) : CS_0024_003C_003E8__locals0.model.PrdValidityTimeMinute.GetValueOrDefault().ToString());
							prdValidityTime = obj + ":" + text6;
						}
						wSProducts2.PrdValidityTime = prdValidityTime;
					}
					else
					{
						bool? prdIVRLink2 = (CS_0024_003C_003E8__locals0.model.PrdValidity = null);
						wSProducts2.PrdValidity = prdIVRLink2;
						int? prdValidityDay = (CS_0024_003C_003E8__locals0.model.PrdValidityDay = null);
						wSProducts2.PrdValidityDay = prdValidityDay;
						string prdIVRLinkRule = (CS_0024_003C_003E8__locals0.model.PrdValidityTime = null);
						wSProducts2.PrdValidityTime = prdIVRLinkRule;
					}
					wSProducts2.PrdValidityCounting = CS_0024_003C_003E8__locals0.model.PrdValidityCounting;
					wSProducts2.PrdValidityCountingNum = CS_0024_003C_003E8__locals0.model.PrdValidityCountingNum;
					wSProducts2.PrdValidityCountingMin = CS_0024_003C_003E8__locals0.model.PrdValidityCountingMin;
					wSProducts2.PrdValidityCountingNumIsActive = CS_0024_003C_003E8__locals0.model.PrdValidityCountingNumIsActive;
					wSProducts2.PrdValidityCountingNumNeedOrder = CS_0024_003C_003E8__locals0.model.PrdValidityCountingNumNeedOrder;
					wSProducts2.PrdValidityCountingNumDefaultVal = CS_0024_003C_003E8__locals0.model.PrdValidityCountingNumDefaultVal;
					wSProducts2.PrdValidityCountingNumNoCheckRemain = CS_0024_003C_003E8__locals0.model.PrdValidityCountingNumNoCheckRemain;
					wSProducts2.PrdValidityCountingMinIsActive = CS_0024_003C_003E8__locals0.model.PrdValidityCountingMinIsActive;
					wSProducts2.PrdValidityCountingMinNeedOrder = CS_0024_003C_003E8__locals0.model.PrdValidityCountingMinNeedOrder;
					wSProducts2.PrdValidityCountingMinDefaultVal = CS_0024_003C_003E8__locals0.model.PrdValidityCountingMinDefaultVal;
					wSProducts2.PrdValidityCountingMinNoCheckRemain = CS_0024_003C_003E8__locals0.model.PrdValidityCountingMinNoCheckRemain;
					wSProducts2.TspPrdIndentify = CS_0024_003C_003E8__locals0.model.TspPrdIndentify;
					wSProducts2.TspPrdName = CS_0024_003C_003E8__locals0.model.TspPrdName;
					wSProducts2.PrdAutoCalcIndexed = CS_0024_003C_003E8__locals0.model.PrdAutoCalcIndexed;
					wSProducts2.PrdAutoCalcPordPrdId = CS_0024_003C_003E8__locals0.model.PrdAutoCalcPordPrdId;
					wSProducts2.PrdAutoCalcPriceFromOrdItemRate = CS_0024_003C_003E8__locals0.model.PrdAutoCalcPriceFromOrdItemRate;
					wSProducts2.PrdAutoCalcDisabled = CS_0024_003C_003E8__locals0.model.PrdAutoCalcDisabled;
					wSProducts2.PrdAutoCalcPriceFromOrdItemPrdGroups = CS_0024_003C_003E8__locals0.model.PrdAutoCalcPriceFromOrdItemPrdGroups;
					wSProducts2.PrdAutoCalcDynamicRate = CS_0024_003C_003E8__locals0.model.PrdAutoCalcDynamicRate;
					wSProducts2.PrdAutoCalcInflationLastDurationRate = CS_0024_003C_003E8__locals0.model.PrdAutoCalcInflationLastDurationRate;
					wSProducts2.PrdAutoCalcIndexedPrdId = CS_0024_003C_003E8__locals0.model.PrdAutoCalcIndexedPrdId;
					wSProducts2.PrdAutoCalcPordVerifyAfterIssue = CS_0024_003C_003E8__locals0.model.PrdAutoCalcPordVerifyAfterIssue;
					wSProducts2.PrdAutoCalcPordReferUser = CS_0024_003C_003E8__locals0.model.PrdAutoCalcPordReferUser;
					wSProducts2.PrdAutoCalcPordExpireDynamicRate = CS_0024_003C_003E8__locals0.model.PrdAutoCalcPordExpireDynamicRate;
					wSProducts2.PrdAutoCalcPordExpireDay = CS_0024_003C_003E8__locals0.model.PrdAutoCalcPordExpireDay;
					wSProducts2.PrdAutoCalcPordItemDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					wSProducts2.PrdAutoCalcPordTaxDetectFromLastOrd = CS_0024_003C_003E8__locals0.model.PrdAutoCalcPordTaxDetectFromLastOrd;
					wSProducts2.PrdAutoCalcPordTaxDefSettingId = CS_0024_003C_003E8__locals0.model.PrdAutoCalcPordTaxDefSettingId;
					wSProducts2.PrdAutoCalcPordNoTaxDefSettingId = CS_0024_003C_003E8__locals0.model.PrdAutoCalcPordNoTaxDefSettingId;
					wSProducts2.PrdAutoCalcPordPrjTitleGroupId = CS_0024_003C_003E8__locals0.model.PrdAutoCalcPordPrjTitleGroupId;
					wSProducts2.PrdAutoCalcPordPrjTitleId = CS_0024_003C_003E8__locals0.model.PrdAutoCalcPordPrjTitleId;
					wSProducts2.PrdAutoCalcPordPrjPostFix = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					wSProducts2.PrdAutoCalcPordPrjCnvsStatusGroupId = CS_0024_003C_003E8__locals0.model.PrdAutoCalcPordPrjCnvsStatusGroupId;
					wSProducts2.PrdAutoCalcPordPrjFOCmpCanSee = CS_0024_003C_003E8__locals0.model.PrdAutoCalcPordPrjFOCmpCanSee;
					wSProducts2.PrdAutoCalcPordPrjIsTicket = CS_0024_003C_003E8__locals0.model.PrdAutoCalcPordPrjIsTicket;
					wSProducts2.PrdAutoCalcPordPrjUsedType = CS_0024_003C_003E8__locals0.model.PrdAutoCalcPordPrjUsedType;
					wSProducts2.PrdAutoCalcPordAddCnvs = CS_0024_003C_003E8__locals0.model.PrdAutoCalcPordAddCnvs;
					wSProducts2.PrdAutoCalcPordCnvsTopicId = CS_0024_003C_003E8__locals0.model.PrdAutoCalcPordCnvsTopicId;
					wSProducts2.PrdAutoCalcPordCnvsDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					wSProducts2.PrdAutoCalcPordCnvsReferUser = CS_0024_003C_003E8__locals0.model.PrdAutoCalcPordCnvsReferUser;
					wSProducts2.PrdAutoCalcPordCnvsStatusId = CS_0024_003C_003E8__locals0.model.PrdAutoCalcPordCnvsStatusId;
					wSProducts2.PrdAutoCalcPordCnvsStatusResultId = CS_0024_003C_003E8__locals0.model.PrdAutoCalcPordCnvsStatusResultId;
					wSProducts2.PrdAutoCalcPordCnvsRemindDay = CS_0024_003C_003E8__locals0.model.PrdAutoCalcPordCnvsRemindDay;
					wSProducts2.PrdAutoCalcIssueOrdFromIndexed = CS_0024_003C_003E8__locals0.model.PrdAutoCalcIssueOrdFromIndexed;
					wSProducts2.PrdAutoCalcIssueOrdFromIndexedOprId = CS_0024_003C_003E8__locals0.model.PrdAutoCalcIssueOrdFromIndexedOprId;
					wSProducts2.PrdOrdIssueSetSetting = CS_0024_003C_003E8__locals0.model.PrdOrdIssueSetSetting;
					wSProducts2.PrdOrdIssuePrjTitleGroupId = CS_0024_003C_003E8__locals0.model.PrdOrdIssuePrjTitleGroupId;
					wSProducts2.PrdOrdIssuePrjTitleId = CS_0024_003C_003E8__locals0.model.PrdOrdIssuePrjTitleId;
					wSProducts2.PrdOrdIssuePrjPostFix = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					wSProducts2.PrdOrdIssuePrjCnvsStatusGroupId = CS_0024_003C_003E8__locals0.model.PrdOrdIssuePrjCnvsStatusGroupId;
					wSProducts2.PrdOrdIssuePrjRemindDay = CS_0024_003C_003E8__locals0.model.PrdOrdIssuePrjRemindDay;
					wSProducts2.PrdOrdIssuePrjFOCmpCanSee = CS_0024_003C_003E8__locals0.model.PrdOrdIssuePrjFOCmpCanSee;
					wSProducts2.PrdOrdIssuePrjIsTicket = CS_0024_003C_003E8__locals0.model.PrdOrdIssuePrjIsTicket;
					wSProducts2.PrdOrdIssuePrjUsedType = CS_0024_003C_003E8__locals0.model.PrdOrdIssuePrjUsedType;
					wSProducts2.PrdValidityUpdatePrjRemindDateAfterIssueOrd = CS_0024_003C_003E8__locals0.model.PrdValidityUpdatePrjRemindDateAfterIssueOrd;
					wSProducts2.PrdOrdIssueUpdateCmpTypeId = CS_0024_003C_003E8__locals0.model.PrdOrdIssueUpdateCmpTypeId;
					wSProducts2.PrdOrdIssueUpdateCmpGroupII = CS_0024_003C_003E8__locals0.model.PrdOrdIssueUpdateCmpGroupII;
					wSProducts2.PrdOrdIssueUpdateTaxCmpGroupIdII = CS_0024_003C_003E8__locals0.model.PrdOrdIssueUpdateTaxCmpGroupIdII;
					wSProducts2.PrdOrdIssueUpdateNoTaxCmpGroupIdII = CS_0024_003C_003E8__locals0.model.PrdOrdIssueUpdateNoTaxCmpGroupIdII;
					wSProducts2.PrdOrdIssueDateToCmpEffectiveDate = CS_0024_003C_003E8__locals0.model.PrdOrdIssueDateToCmpEffectiveDate;
					wSProducts2.PrdAutoCalcIndexBreakDay = CS_0024_003C_003E8__locals0.model.PrdAutoCalcIndexBreakDay;
					wSProducts2.PrdAutoCalcDynamicRateJustCompleteDuration = CS_0024_003C_003E8__locals0.model.PrdAutoCalcDynamicRateJustCompleteDuration;
					wSProducts2.PrdAutoCalcInflationLastYearNumChange = CS_0024_003C_003E8__locals0.model.PrdAutoCalcInflationLastYearNumChange;
					wSProducts2.PrdAutoCalcInflationLastDuration = CS_0024_003C_003E8__locals0.model.PrdAutoCalcInflationLastDuration;
					wSProducts2.PrdAutoCalcInflationLastYearNumChangeRate = CS_0024_003C_003E8__locals0.model.PrdAutoCalcInflationLastYearNumChangeRate;
					wSProducts2.PrdAutoCalcPriceFromOrdItemInBreak = CS_0024_003C_003E8__locals0.model.PrdAutoCalcPriceFromOrdItemInBreak;
					wSProducts2.PrdAutoCalcPriceFromIndex = CS_0024_003C_003E8__locals0.model.PrdAutoCalcPriceFromIndex;
					wSProducts2.PrdAutoCalcPriceFromIndexRate = CS_0024_003C_003E8__locals0.model.PrdAutoCalcPriceFromIndexRate;
					wSProducts2.PrdAutoCalcPriceFromOrdItem = CS_0024_003C_003E8__locals0.model.PrdAutoCalcPriceFromOrdItem;
					wSProducts2.PrdAutoCalcPriceFromOrdItemAfterBreak = CS_0024_003C_003E8__locals0.model.PrdAutoCalcPriceFromOrdItemAfterBreak;
					wSProducts2.PrdValidityControlFOPrjTitleGroup = CS_0024_003C_003E8__locals0.model.PrdValidityControlFOPrjTitleGroup;
					wSProducts2.PrdValidityControlFOPrjTitleGroupIds = CS_0024_003C_003E8__locals0.model.PrdValidityControlFOPrjTitleGroupIds;
					wSProducts2.PrdValidityControlFODeActivePrjTitleGroupDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					wSProducts2.PrdCanChangePrice = CS_0024_003C_003E8__locals0.model.PrdCanChangePrice;
					wSProducts2.PrdSaleCenterIds = CS_0024_003C_003E8__locals0.model.PrdSaleCenterIds;
					wSProducts2.PrdDoneTimeMin = CS_0024_003C_003E8__locals0.model.PrdDoneTimeMin;
					wSProducts2.PrdRowColor = Public.HexToColor(CS_0024_003C_003E8__locals0.model.PrdRowColor);
					wSProducts2.PrdWeight = CS_0024_003C_003E8__locals0.model.PrdWeight;
					if (VersionBuyer.PrdAutoCalcPrice)
					{
						wSProducts2.PrdAutoCalcPrice = CS_0024_003C_003E8__locals0.model.PrdAutoCalcPrice;
						wSProducts2.PrdAutoCalcPricePercent = CS_0024_003C_003E8__locals0.model.PrdAutoCalcPricePercent;
					}
					else
					{
						wSProducts2.PrdAutoCalcPrice = false;
						wSProducts2.PrdAutoCalcPricePercent = null;
					}
					wSProducts2.PrdQtyCanDecimal = CS_0024_003C_003E8__locals0.model.PrdQtyCanDecimal;
					_dbTbl.Entry(wSProducts2).State = EntityState.Modified;
					_dbTbl.SaveChanges();
					using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							_003C_003Ec__DisplayClass28_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass28_1();
							CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
							CS_0024_003C_003E8__locals1.lang = enumerator.Current;
							DbSet<WSProducts_Lang> wSProducts_Lang = _dbTbl.WSProducts_Lang;
							val = Expression.Parameter(typeof(WSProducts_Lang), "c");
							WSProducts_Lang wSProducts_Lang2 = Queryable.FirstOrDefault<WSProducts_Lang>((IQueryable<WSProducts_Lang>)wSProducts_Lang, Expression.Lambda<Func<WSProducts_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass28_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass28_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (wSProducts_Lang2 != null)
							{
								wSProducts_Lang2.PrdName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								wSProducts_Lang2.PrdType = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								wSProducts_Lang2.PrdDesign = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								wSProducts_Lang2.PrdSize = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								wSProducts_Lang2.PrdDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								wSProducts_Lang2.PrdModel = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								wSProducts_Lang2.PrdManufacturerName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								wSProducts_Lang2.PrdLocation = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								wSProducts_Lang2.PrdNickname = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								wSProducts_Lang2.PrdAutoCalcPordItemDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								wSProducts_Lang2.PrdAutoCalcPordPrjPostFix = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								wSProducts_Lang2.PrdAutoCalcPordCnvsDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								wSProducts_Lang2.PrdOrdIssuePrjPostFix = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								wSProducts_Lang2.PrdValidityControlFODeActivePrjTitleGroupDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								_dbTbl.Entry(wSProducts_Lang2).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							wSProducts_Lang2 = new WSProducts_Lang
							{
								LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID,
								ProductID = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.ProductID,
								PrdName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
								PrdType = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
								PrdDesign = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
								PrdSize = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
								PrdDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
								PrdModel = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
								PrdManufacturerName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
								PrdLocation = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
								PrdNickname = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
								PrdAutoCalcPordItemDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
								PrdAutoCalcPordPrjPostFix = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
								PrdAutoCalcPordCnvsDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
								PrdOrdIssuePrjPostFix = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
								PrdValidityControlFODeActivePrjTitleGroupDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null)
							};
							_dbTbl.WSProducts_Lang.Add(wSProducts_Lang2);
							_dbTbl.SaveChanges();
						}
					}
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProducts");
					string text8 = Messages.frmFormBaseEditSuccessFulMessage;
					if (wSProducts2.ProductID > 0 && VersionBuyer.LinkAcc && UserLogin.IsUserAccess("frmProducts", "actSendToAcc", UserLogin.CurrentUser) && CS_0024_003C_003E8__locals0.model.SendToAcc.HasValue && CS_0024_003C_003E8__locals0.model.SendToAcc.GetValueOrDefault())
					{
						CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result2 = SysSeting.Get();
						if (cRMspSelectCrmsysSetting_Result2 != null)
						{
							int result3 = 0;
							int.TryParse(cRMspSelectCrmsysSetting_Result2.LinkAccSystemId.ToString(), out result3);
							ProductController productController = new ProductController();
							switch (result3)
							{
							case 8:
							{
								string text10 = productController.ShygunActSendToAcc(wSProducts2.ProductID, CS_0024_003C_003E8__locals0.model.SendToAccWithPrdPrice.GetValueOrDefault());
								if (!string.IsNullOrEmpty(text10))
								{
									string[] array2 = text10.Split(new char[1] { '|' });
									if (array2 != null)
									{
										text8 = ((!(array2[0] == "1") || array2.Length != 2) ? (text8 + "<br>" + string.Format(Messages.msgErrorTransferPrdToLinkAcc, Labels.Shygun) + "<br>" + array2[0]) : (text8 + "<br>" + Messages.msgPrdAccCode + array2[1]));
									}
								}
								else
								{
									text8 = text8 + "<br>" + string.Format(Messages.msgErrorTransferPrdToLinkAcc, Labels.Shygun);
								}
								break;
							}
							case 9:
							{
								string text9 = productController.ShygunIIActSendToAcc(wSProducts2.ProductID, CS_0024_003C_003E8__locals0.model.SendToAccWithPrdPrice.GetValueOrDefault(), CS_0024_003C_003E8__locals0.model.SendPrdGroupToAcc.GetValueOrDefault());
								if (!string.IsNullOrEmpty(text9))
								{
									string[] array = text9.Split(new char[1] { '|' });
									if (array != null)
									{
										text8 = ((!(array[0] == "1") || array.Length != 2) ? (text8 + "<br>" + string.Format(Messages.msgErrorTransferPrdToLinkAcc, Labels.ShygunII) + "<br>" + array[0]) : (text8 + "<br>" + Messages.msgPrdAccCode + array[1]));
									}
								}
								else
								{
									text8 = text8 + "<br>" + string.Format(Messages.msgErrorTransferPrdToLinkAcc, Labels.ShygunII);
								}
								break;
							}
							}
						}
					}
					base.ViewBag.Successfull = text8;
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				base.ViewBag.Error = Messages.frmErrorMessage;
			}
		}
		return View(CS_0024_003C_003E8__locals0.model);
	}

	[DynamicAuthorize(ControllerName = "frmProducts", ActionName = "actDeletePrd")]
	[AjaxOnly]
	public string DeleteProduct(int prdId)
	{
		_003C_003Ec__DisplayClass29_0 _003C_003Ec__DisplayClass29_ = new _003C_003Ec__DisplayClass29_0();
		_003C_003Ec__DisplayClass29_.prdId = prdId;
		string result = "-1";
		try
		{
			if (_003C_003Ec__DisplayClass29_.prdId > 0)
			{
				DbSet<WSProducts> wSProducts = _dbTbl.WSProducts;
				ParameterExpression val = Expression.Parameter(typeof(WSProducts), "c");
				WSProducts wSProducts2 = Queryable.FirstOrDefault<WSProducts>((IQueryable<WSProducts>)wSProducts, Expression.Lambda<Func<WSProducts, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass29_, typeof(_003C_003Ec__DisplayClass29_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (wSProducts2 != null)
				{
					if (wSProducts2.WSBuyOrderItems.Count > 0 || wSProducts2.WSDocItems.Count > 0 || wSProducts2.WSOrderItems.Count > 0 || wSProducts2.WSPreOrderItems.Count > 0 || wSProducts2.WSProductCost.Count > 0 || wSProducts2.WSProductPicture.Count > 0 || wSProducts2.WSProductPrice.Count > 0 || wSProducts2.WSProductSpecification.Count > 0 || wSProducts2.WSUserFavproductItems.Count > 0)
					{
						return result;
					}
					_db.CRMspDyDeleteFormFieldMasterValuesBySysPart(_003C_003Ec__DisplayClass29_.prdId, "prd");
					mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)Enumerable.ToList<mct_Result>((IEnumerable<mct_Result>)_db.WSspDeleteWSProducts(_003C_003Ec__DisplayClass29_.prdId)));
					if (mct_Result != null && mct_Result.Result > 0)
					{
						result = "1";
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return result;
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "frmProductSpecification", ActionName = "actDelete")]
	[AjaxOnly]
	public string ProductSpecificationDelete(int prdSepId)
	{
		_003C_003Ec__DisplayClass30_0 _003C_003Ec__DisplayClass30_ = new _003C_003Ec__DisplayClass30_0();
		_003C_003Ec__DisplayClass30_.prdSepId = prdSepId;
		string result = "-1";
		try
		{
			if (_003C_003Ec__DisplayClass30_.prdSepId > 0)
			{
				DbSet<WSProductSpecification> wSProductSpecification = _dbTbl.WSProductSpecification;
				ParameterExpression val = Expression.Parameter(typeof(WSProductSpecification), "c");
				if (Queryable.FirstOrDefault<WSProductSpecification>((IQueryable<WSProductSpecification>)wSProductSpecification, Expression.Lambda<Func<WSProductSpecification, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass30_, typeof(_003C_003Ec__DisplayClass30_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) != null)
				{
					mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)Enumerable.ToList<mct_Result>((IEnumerable<mct_Result>)_db.WSspDeleteWSProductSpecification(_003C_003Ec__DisplayClass30_.prdSepId)));
					if (mct_Result != null && mct_Result.Result > 0)
					{
						result = "1";
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return result;
		}
		return result;
	}

	public void SetUserNameDateForProductSpecification(WSProductSpecificationLanguageViewModel model)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		string text2 = "";
		try
		{
			string text3 = "";
			string text4 = "";
			string text5 = (model.FirstRegisterUserId ?? UserLogin.CurrentUser.UserId).ToString();
			_ = model.UserId;
			List<CRMspSelectUsersByIds_Result> list = CRMIdeal.Classes.Helper.User.SelectUsersByIds(text5 + "," + model.UserId);
			if (Enumerable.Any<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list))
			{
				model.FirstRegisterUserId = model.FirstRegisterUserId ?? UserLogin.CurrentUser.UserId;
				CRMspSelectUsersByIds_Result cRMspSelectUsersByIds_Result = Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result c) => c.UserId == model.FirstRegisterUserId));
				text3 = ((cRMspSelectUsersByIds_Result != null) ? (cRMspSelectUsersByIds_Result.LName + ((cRMspSelectUsersByIds_Result.FName != null) ? (" " + cRMspSelectUsersByIds_Result.FName) : "")) : "");
				WSProductSpecificationLanguageViewModel wSProductSpecificationLanguageViewModel = model;
				_ = model.UserId;
				wSProductSpecificationLanguageViewModel.UserId = model.UserId;
				CRMspSelectUsersByIds_Result cRMspSelectUsersByIds_Result2 = Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result c) => c.UserId == model.UserId));
				text4 = ((cRMspSelectUsersByIds_Result2 != null) ? (cRMspSelectUsersByIds_Result2.LName + ((cRMspSelectUsersByIds_Result2.FName != null) ? (" " + cRMspSelectUsersByIds_Result2.FName) : "")) : "");
			}
			string text6 = (model.FirstRegisterDate.HasValue ? model.FirstRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
			_ = model.RegisterDate;
			string text7 = model.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
			if (string.IsNullOrEmpty(model.AppType))
			{
				model.AppType = Configuration.AppType;
			}
			string text8 = Labels.AppType + ": " + Configuration.GetAppType(model.AppType);
			text = Labels.frmFirstRegisterUser + ": " + text3 + " (" + text6 + ")";
			text2 = Labels.frmRegisterUser + ": " + text4 + " (" + text8 + ") (" + text7 + ")";
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.FirstRegisterInfo = text;
		base.ViewBag.EditInfo = text2;
	}

	[DynamicAuthorize(ControllerName = "frmProductSpecification", ActionName = "actInsert")]
	public ActionResult ProductSpecificationInsert(int prdId, int fpId)
	{
		int fPId = ((Financial.Get() != null) ? Financial.Get().Id : 0);
		DateTime now = DateTime.Now;
		WSProductSpecificationLanguageViewModel wSProductSpecificationLanguageViewModel = new WSProductSpecificationLanguageViewModel
		{
			PrdId = prdId,
			FPId = fPId,
			UserId = UserLogin.CurrentUser.UserId,
			RegisterDate = now,
			AppType = Configuration.AppType,
			FirstRegisterUserId = UserLogin.CurrentUser.UserId,
			FirstRegisterDate = now
		};
		SetUserNameDateForProductSpecification(wSProductSpecificationLanguageViewModel);
		return View(wSProductSpecificationLanguageViewModel);
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmProductSpecification", ActionName = "actPost")]
	public ActionResult ProductSpecificationInsert(WSProductSpecificationLanguageViewModel model)
	{
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(model.Specification_Lang))
		{
			list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.Specification_Lang);
		}
		list.Add(new CommonMultiLanguageViewModel
		{
			Value = model.Specification,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(model.SpecificationI_Lang))
		{
			list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.SpecificationI_Lang);
		}
		list2.Add(new CommonMultiLanguageViewModel
		{
			Value = model.SpecificationI,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(model.SpecificationII_Lang))
		{
			list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.SpecificationII_Lang);
		}
		list3.Add(new CommonMultiLanguageViewModel
		{
			Value = model.SpecificationII,
			LanguageId = lCID
		});
		string text = "";
		if (model.Specification == null && model.Specification == "")
		{
			text = text + Messages.CheckSpecification + "<br/>";
		}
		else if (!checkMultiLanguage(model.Specification, list))
		{
			text = text + Messages.CheckSpecificationLang + "<br>";
		}
		int fPId = model.FPId;
		if (text == "")
		{
			try
			{
				DateTime now = DateTime.Now;
				WSProductSpecification wSProductSpecification = new WSProductSpecification
				{
					UserId = UserLogin.CurrentUser.UserId,
					RegisterDate = now,
					RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
					Month1 = short.Parse(now.ToString("MM", new PersianCulture())),
					GUId = System.Guid.NewGuid(),
					AppType = Configuration.AppType,
					FPId = Financial.Get().Id,
					FirstRegisterUserId = UserLogin.CurrentUser.UserId,
					FirstRegisterDate = now,
					FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
					LanguageID = defLangID,
					PrdId = model.PrdId,
					Specification = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null),
					SpecificationI = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null),
					SpecificationII = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null)
				};
				if (base.ModelState.IsValid)
				{
					_dbTbl.WSProductSpecification.Add(wSProductSpecification);
					_dbTbl.SaveChanges();
					foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))))
					{
						WSProductSpecification_Lang entity = new WSProductSpecification_Lang
						{
							LanguageID = lang.LanguageID,
							ProductSpecificationID = wSProductSpecification.ProductSpecificationID,
							Specification = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
							SpecificationI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
							SpecificationII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null)
						};
						_dbTbl.WSProductSpecification_Lang.Add(entity);
						_dbTbl.SaveChanges();
					}
					base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
					model.UserId = wSProductSpecification.UserId;
					model.RegisterDate = wSProductSpecification.RegisterDate;
					model.AppType = wSProductSpecification.AppType;
					model.FirstRegisterUserId = wSProductSpecification.FirstRegisterUserId;
					model.FirstRegisterDate = wSProductSpecification.FirstRegisterDate;
				}
				else
				{
					text = Messages.frmErrorMessage + "<br/>" + string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				text = Messages.frmErrorMessage;
			}
		}
		base.ViewBag.Error = text;
		model.FPId = fPId;
		SetUserNameDateForProductSpecification(model);
		return View(model);
	}

	[DynamicAuthorize(ControllerName = "frmProductSpecification", ActionName = "actEdit")]
	public ActionResult ProductSpecificationEdit(int prdSepId)
	{
		_003C_003Ec__DisplayClass34_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass34_0();
		CS_0024_003C_003E8__locals0.prdSepId = prdSepId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		DbSet<WSProductSpecification_Lang> wSProductSpecification_Lang = _dbTbl.WSProductSpecification_Lang;
		ParameterExpression val = Expression.Parameter(typeof(WSProductSpecification_Lang), "c");
		List<WSProductSpecification_Lang> list = Enumerable.ToList<WSProductSpecification_Lang>((IEnumerable<WSProductSpecification_Lang>)Queryable.Where<WSProductSpecification_Lang>((IQueryable<WSProductSpecification_Lang>)wSProductSpecification_Lang, Expression.Lambda<Func<WSProductSpecification_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass34_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
		int fPId = ((Financial.Get() != null) ? Financial.Get().Id : 0);
		DbSet<WSProductSpecification> wSProductSpecification = _dbTbl.WSProductSpecification;
		val = Expression.Parameter(typeof(WSProductSpecification), "c");
		WSProductSpecification wSProductSpecification2 = Queryable.FirstOrDefault<WSProductSpecification>((IQueryable<WSProductSpecification>)wSProductSpecification, Expression.Lambda<Func<WSProductSpecification, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass34_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
		WSProductSpecificationLanguageViewModel wSProductSpecificationLanguageViewModel = new WSProductSpecificationLanguageViewModel();
		if (wSProductSpecification2 == null)
		{
			DateTime now = DateTime.Now;
			wSProductSpecificationLanguageViewModel = new WSProductSpecificationLanguageViewModel();
			wSProductSpecificationLanguageViewModel.ProductSpecificationID = CS_0024_003C_003E8__locals0.prdSepId;
			wSProductSpecificationLanguageViewModel.FPId = fPId;
			wSProductSpecificationLanguageViewModel.UserId = UserLogin.CurrentUser.UserId;
			wSProductSpecificationLanguageViewModel.RegisterDate = now;
			wSProductSpecificationLanguageViewModel.AppType = Configuration.AppType;
			wSProductSpecificationLanguageViewModel.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
			wSProductSpecificationLanguageViewModel.FirstRegisterDate = now;
		}
		else
		{
			List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSProductSpecification_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSProductSpecification_Lang>)list, (Func<WSProductSpecification_Lang, CommonMultiLanguageViewModel>)((WSProductSpecification_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.Specification,
				LanguageId = item.LanguageID
			})));
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = wSProductSpecification2.Specification,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSProductSpecification_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSProductSpecification_Lang>)list, (Func<WSProductSpecification_Lang, CommonMultiLanguageViewModel>)((WSProductSpecification_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.SpecificationI,
				LanguageId = item.LanguageID
			})));
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = wSProductSpecification2.SpecificationI,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSProductSpecification_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSProductSpecification_Lang>)list, (Func<WSProductSpecification_Lang, CommonMultiLanguageViewModel>)((WSProductSpecification_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.SpecificationII,
				LanguageId = item.LanguageID
			})));
			list4.Add(new CommonMultiLanguageViewModel
			{
				Value = wSProductSpecification2.SpecificationII,
				LanguageId = result
			});
			wSProductSpecificationLanguageViewModel = new WSProductSpecificationLanguageViewModel
			{
				PrdId = wSProductSpecification2.PrdId,
				ProductSpecificationID = wSProductSpecification2.ProductSpecificationID,
				LanguageID = wSProductSpecification2.LanguageID,
				UserId = wSProductSpecification2.UserId,
				FirstRegisterUserId = wSProductSpecification2.FirstRegisterUserId,
				FirstRegisterDatePersian = wSProductSpecification2.FirstRegisterDatePersian,
				FirstRegisterDate = wSProductSpecification2.FirstRegisterDate,
				AppType = wSProductSpecification2.AppType,
				GUId = wSProductSpecification2.GUId,
				RegisterDate = wSProductSpecification2.RegisterDate,
				RegisterDatePersian = wSProductSpecification2.RegisterDatePersian,
				Month1 = wSProductSpecification2.Month1,
				FPId = wSProductSpecification2.FPId,
				Specification = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				SpecificationI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				SpecificationII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				Specification_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				SpecificationI_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				SpecificationII_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))))
			};
		}
		SetUserNameDateForProductSpecification(wSProductSpecificationLanguageViewModel);
		return View(wSProductSpecificationLanguageViewModel);
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmProductSpecification", ActionName = "actPost")]
	public ActionResult ProductSpecificationEdit(WSProductSpecificationLanguageViewModel model)
	{
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(model.Specification_Lang))
		{
			list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.Specification_Lang);
		}
		list.Add(new CommonMultiLanguageViewModel
		{
			Value = model.Specification,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(model.SpecificationI_Lang))
		{
			list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.SpecificationI_Lang);
		}
		list2.Add(new CommonMultiLanguageViewModel
		{
			Value = model.SpecificationI,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(model.SpecificationII_Lang))
		{
			list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.SpecificationII_Lang);
		}
		list3.Add(new CommonMultiLanguageViewModel
		{
			Value = model.SpecificationII,
			LanguageId = lCID
		});
		if (model.Specification == null && model.Specification == "")
		{
			text = text + Messages.CheckSpecification + "<br/>";
		}
		else if (!checkMultiLanguage(model.Specification, list))
		{
			text = text + Messages.CheckSpecificationLang + "<br>";
		}
		int fPId = model.FPId;
		if (text == "")
		{
			try
			{
				DateTime now = DateTime.Now;
				model.UserId = UserLogin.CurrentUser.UserId;
				model.RegisterDate = now;
				model.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				model.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
				if (base.ModelState.IsValid)
				{
					_003C_003Ec__DisplayClass35_1 _003C_003Ec__DisplayClass35_ = new _003C_003Ec__DisplayClass35_1();
					_003C_003Ec__DisplayClass35_.prdSpecificationEdit = _dbTbl.WSProductSpecification.Find(model.ProductSpecificationID);
					if (_003C_003Ec__DisplayClass35_.prdSpecificationEdit != null)
					{
						_003C_003Ec__DisplayClass35_.prdSpecificationEdit.UserId = model.UserId;
						_003C_003Ec__DisplayClass35_.prdSpecificationEdit.RegisterDate = model.RegisterDate;
						_003C_003Ec__DisplayClass35_.prdSpecificationEdit.RegisterDatePersian = model.RegisterDatePersian;
						_003C_003Ec__DisplayClass35_.prdSpecificationEdit.Month1 = model.Month1;
						_003C_003Ec__DisplayClass35_.prdSpecificationEdit.Specification = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
						_003C_003Ec__DisplayClass35_.prdSpecificationEdit.SpecificationI = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
						_003C_003Ec__DisplayClass35_.prdSpecificationEdit.SpecificationII = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
						_003C_003Ec__DisplayClass35_.prdSpecificationEdit.AppType = Configuration.AppType;
						_003C_003Ec__DisplayClass35_.prdSpecificationEdit.FPId = Financial.Get().Id;
						_dbTbl.Entry(_003C_003Ec__DisplayClass35_.prdSpecificationEdit).State = EntityState.Modified;
						_dbTbl.SaveChanges();
						using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))).GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								_003C_003Ec__DisplayClass35_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass35_2();
								CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass35_;
								CS_0024_003C_003E8__locals1.lang = enumerator.Current;
								DbSet<WSProductSpecification_Lang> wSProductSpecification_Lang = _dbTbl.WSProductSpecification_Lang;
								ParameterExpression val = Expression.Parameter(typeof(WSProductSpecification_Lang), "c");
								WSProductSpecification_Lang wSProductSpecification_Lang2 = Queryable.FirstOrDefault<WSProductSpecification_Lang>((IQueryable<WSProductSpecification_Lang>)wSProductSpecification_Lang, Expression.Lambda<Func<WSProductSpecification_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass35_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass35_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
								if (wSProductSpecification_Lang2 != null)
								{
									wSProductSpecification_Lang2.Specification = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									wSProductSpecification_Lang2.SpecificationI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									wSProductSpecification_Lang2.SpecificationII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									_dbTbl.Entry(wSProductSpecification_Lang2).State = EntityState.Modified;
									_dbTbl.SaveChanges();
									continue;
								}
								wSProductSpecification_Lang2 = new WSProductSpecification_Lang
								{
									LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID,
									ProductSpecificationID = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.prdSpecificationEdit.ProductSpecificationID,
									Specification = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
									SpecificationI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
									SpecificationII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null)
								};
								_dbTbl.WSProductSpecification_Lang.Add(wSProductSpecification_Lang2);
								_dbTbl.SaveChanges();
							}
						}
						base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
						model.UserId = _003C_003Ec__DisplayClass35_.prdSpecificationEdit.UserId;
						model.RegisterDate = _003C_003Ec__DisplayClass35_.prdSpecificationEdit.RegisterDate;
						model.AppType = _003C_003Ec__DisplayClass35_.prdSpecificationEdit.AppType;
						model.FirstRegisterUserId = _003C_003Ec__DisplayClass35_.prdSpecificationEdit.FirstRegisterUserId;
						model.FirstRegisterDate = _003C_003Ec__DisplayClass35_.prdSpecificationEdit.FirstRegisterDate;
					}
					else
					{
						text = Messages.frmErrorMessage;
					}
				}
				else
				{
					text = Messages.frmErrorMessage + "<br/>" + string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				text = Messages.frmErrorMessage;
			}
		}
		base.ViewBag.Error = text;
		model.FPId = fPId;
		SetUserNameDateForProductSpecification(model);
		return View(model);
	}

	[DynamicAuthorize(ControllerName = "frmProducts", ActionName = "actChangePrdGroup")]
	public ActionResult ProductGroupChange(int prdId, int fgId, int sgId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		WSspSelectProducts_Result wSspSelectProducts_Result = Enumerable.FirstOrDefault<WSspSelectProducts_Result>((IEnumerable<WSspSelectProducts_Result>)Enumerable.ToList<WSspSelectProducts_Result>((IEnumerable<WSspSelectProducts_Result>)_db.WSspSelectProducts(lCID, result)), (Func<WSspSelectProducts_Result, bool>)((WSspSelectProducts_Result c) => c.ProductID == prdId));
		if (wSspSelectProducts_Result != null)
		{
			base.ViewBag.prdId = wSspSelectProducts_Result.ProductID;
			base.ViewBag.prdName = ((!string.IsNullOrEmpty(wSspSelectProducts_Result.PrdName)) ? wSspSelectProducts_Result.PrdName : "");
		}
		base.ViewBag.fgId = fgId;
		base.ViewBag.sgId = sgId;
		List<SelectListItem> list = Enumerable.ToList<SelectListItem>(Enumerable.Select<WSspSelectProductFirstGroup_Result, SelectListItem>((IEnumerable<WSspSelectProductFirstGroup_Result>)Enumerable.ToList<WSspSelectProductFirstGroup_Result>((IEnumerable<WSspSelectProductFirstGroup_Result>)_db.WSspSelectProductFirstGroup(lCID, result)), (Func<WSspSelectProductFirstGroup_Result, SelectListItem>)((WSspSelectProductFirstGroup_Result item) => new SelectListItem
		{
			Text = (item.FGName ?? ""),
			Value = item.PrdFirstGroupID.ToString(),
			Selected = false
		})));
		base.ViewBag.FGList = list;
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmProducts", ActionName = "actChangePrdGroup")]
	[AjaxOnly]
	public string UpdateProductGroup(int prdId, int newGroupId)
	{
		string text = "-1";
		try
		{
			if (prdId > 0 && newGroupId > 0)
			{
				string registerDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
				return (_db.WSspUpdateProductGroup(prdId, newGroupId, UserLogin.CurrentUser.UserId, registerDatePersian, Configuration.AppType) > 0) ? "1" : text;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return text;
		}
		return text;
	}

	public void SetRegisterInfoForProductPicture(WSProductPictureViewModel model)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		string text2 = "";
		try
		{
			string text3 = "";
			string text4 = "";
			string text5 = (model.FirstRegisterUserId ?? UserLogin.CurrentUser.UserId).ToString();
			_ = model.UserId;
			List<CRMspSelectUsersByIds_Result> list = CRMIdeal.Classes.Helper.User.SelectUsersByIds(text5 + "," + model.UserId);
			if (Enumerable.Any<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list))
			{
				model.FirstRegisterUserId = model.FirstRegisterUserId ?? UserLogin.CurrentUser.UserId;
				CRMspSelectUsersByIds_Result cRMspSelectUsersByIds_Result = Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result c) => c.UserId == model.FirstRegisterUserId));
				text3 = ((cRMspSelectUsersByIds_Result != null) ? (cRMspSelectUsersByIds_Result.LName + ((cRMspSelectUsersByIds_Result.FName != null) ? (" " + cRMspSelectUsersByIds_Result.FName) : "")) : "");
				WSProductPictureViewModel wSProductPictureViewModel = model;
				_ = model.UserId;
				wSProductPictureViewModel.UserId = model.UserId;
				CRMspSelectUsersByIds_Result cRMspSelectUsersByIds_Result2 = Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result c) => c.UserId == model.UserId));
				text4 = ((cRMspSelectUsersByIds_Result2 != null) ? (cRMspSelectUsersByIds_Result2.LName + ((cRMspSelectUsersByIds_Result2.FName != null) ? (" " + cRMspSelectUsersByIds_Result2.FName) : "")) : "");
			}
			string text6 = (model.FirstRegisterDate.HasValue ? model.FirstRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
			_ = model.RegisterDate;
			string text7 = model.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
			if (string.IsNullOrEmpty(model.AppType))
			{
				model.AppType = Configuration.AppType;
			}
			string text8 = Labels.AppType + ": " + Configuration.GetAppType(model.AppType);
			if (model.AppType != "new")
			{
				text = Labels.frmFirstRegisterUser + ": " + text3 + " (" + text6 + ")";
				text2 = Labels.frmRegisterUser + ": " + text4 + " (" + text8 + ") (" + text7 + ")";
			}
			else
			{
				text = Labels.frmFirstRegisterUser + ": ";
				text2 = Labels.frmRegisterUser + ": ";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.FirstRegisterInfo = text;
		base.ViewBag.EditInfo = text2;
	}

	[DynamicAuthorize(ControllerName = "frmProducts", ActionName = "actInsertPicture")]
	public ActionResult ProductPictureUpload(int prdId, int fpId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		DateTime now = DateTime.Now;
		WSProductPictureViewModel wSProductPictureViewModel = new WSProductPictureViewModel
		{
			PrdId = prdId
		};
		try
		{
			WSspSelectProductPicture_Result wSspSelectProductPicture_Result = Enumerable.FirstOrDefault<WSspSelectProductPicture_Result>((IEnumerable<WSspSelectProductPicture_Result>)_db.WSspSelectProductPicture(prdId, lCID, result));
			if (wSspSelectProductPicture_Result != null)
			{
				wSProductPictureViewModel.PrdPictureID = wSspSelectProductPicture_Result.PrdPictureID;
				wSProductPictureViewModel.FPId = wSspSelectProductPicture_Result.FPId;
				wSProductPictureViewModel.UserId = wSspSelectProductPicture_Result.UserId;
				wSProductPictureViewModel.FirstRegisterUserId = wSspSelectProductPicture_Result.FirstRegisterUserId;
				wSProductPictureViewModel.RegisterDate = wSspSelectProductPicture_Result.RegisterDate;
				wSProductPictureViewModel.FirstRegisterDate = wSspSelectProductPicture_Result.FirstRegisterDate;
				wSProductPictureViewModel.AppType = wSspSelectProductPicture_Result.AppType;
			}
			else
			{
				wSProductPictureViewModel.UserId = UserLogin.CurrentUser.UserId;
				wSProductPictureViewModel.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
				wSProductPictureViewModel.RegisterDate = now;
				wSProductPictureViewModel.FirstRegisterDate = now;
				wSProductPictureViewModel.AppType = "new";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.Update = false;
		SetRegisterInfoForProductPicture(wSProductPictureViewModel);
		return View(wSProductPictureViewModel);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	[DynamicAuthorize(ControllerName = "frmProducts", ActionName = "actInsertPicture")]
	public ActionResult ProductPictureUpload(WSProductPictureViewModel pic, HttpPostedFileBase prdPicUrlUpload)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			if (base.ModelState.IsValid)
			{
				if (prdPicUrlUpload == null)
				{
					base.ModelState.AddModelError("error", Messages.frmErrorNotFileSelected);
					return View(pic);
				}
				string text = prdPicUrlUpload.ContentType.ToLower();
				string extension = Path.GetExtension(prdPicUrlUpload.FileName);
				if (extension == null)
				{
					base.ModelState.AddModelError("error", Messages.frmErrorNotImageFile);
					return View(pic);
				}
				string text2 = extension.ToLower();
				if ((text != "image/jpg" && text != "image/jpeg" && text != "image/pjpeg" && text != "image/gif" && text != "image/x-png" && text != "image/png") || (text2 != ".jpg" && text2 != ".png" && text2 != ".gif" && text2 != ".jpeg"))
				{
					base.ModelState.AddModelError("error", Messages.frmErrorNotImageFile);
					return View(pic);
				}
				if (prdPicUrlUpload.ContentLength / 1024 > Configuration.MaxImageSizeForUploadKb)
				{
					base.ModelState.AddModelError("error", string.Format(Messages.frmErrorMaxImageSizeForUpload, Configuration.MaxImageSizeForUploadKb));
					return View(pic);
				}
				WSspSelectProductPicture_Result wSspSelectProductPicture_Result = Enumerable.FirstOrDefault<WSspSelectProductPicture_Result>((IEnumerable<WSspSelectProductPicture_Result>)_db.WSspSelectProductPicture(pic.PrdId, lCID, result));
				bool flag = false;
				if (wSspSelectProductPicture_Result == null)
				{
					wSspSelectProductPicture_Result = new WSspSelectProductPicture_Result();
					flag = true;
					wSspSelectProductPicture_Result.PrdId = pic.PrdId;
					wSspSelectProductPicture_Result.Description = "";
					wSspSelectProductPicture_Result.GUId = System.Guid.NewGuid();
				}
				DateTime now = DateTime.Now;
				wSspSelectProductPicture_Result.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
				wSspSelectProductPicture_Result.RegisterDate = now;
				wSspSelectProductPicture_Result.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				wSspSelectProductPicture_Result.UserId = UserLogin.CurrentUser.UserId;
				wSspSelectProductPicture_Result.FPId = pic.FPId;
				_ = string.Empty;
				_ = string.Empty;
				if (prdPicUrlUpload != null)
				{
					wSspSelectProductPicture_Result.PrdFirstPic = ImageManager.CompressHttpPostedFileBase(new ImageManager.ImageParam
					{
						HttpPostedFileBase_Var = prdPicUrlUpload
					});
				}
				else
				{
					wSspSelectProductPicture_Result.PrdFirstPic = null;
				}
				WSProductPicture wSProductPicture = new WSProductPicture();
				wSProductPicture.PrdPictureID = wSspSelectProductPicture_Result.PrdPictureID;
				wSProductPicture.PrdId = wSspSelectProductPicture_Result.PrdId;
				wSProductPicture.PrdFirstPic = wSspSelectProductPicture_Result.PrdFirstPic;
				wSProductPicture.PrdFirstPicDesc = wSspSelectProductPicture_Result.PrdFirstPicDesc;
				wSProductPicture.PrdSecondPic = wSspSelectProductPicture_Result.PrdSecondPic;
				wSProductPicture.PrdSecondPicDesc = wSspSelectProductPicture_Result.PrdSecondPicDesc;
				wSProductPicture.PrdThirdPic = wSspSelectProductPicture_Result.PrdThirdPic;
				wSProductPicture.PrdThirdPicDesc = wSspSelectProductPicture_Result.PrdThirdPicDesc;
				wSProductPicture.PrdFourthPic = wSspSelectProductPicture_Result.PrdFourthPic;
				wSProductPicture.PrdFourthPicDesc = wSspSelectProductPicture_Result.PrdFourthPicDesc;
				wSProductPicture.PrdFifthPic = wSspSelectProductPicture_Result.PrdFifthPic;
				wSProductPicture.PrdFifthPicDesc = wSspSelectProductPicture_Result.PrdFifthPicDesc;
				wSProductPicture.Description = wSspSelectProductPicture_Result.Description;
				wSProductPicture.UserId = wSspSelectProductPicture_Result.UserId;
				wSProductPicture.Month1 = wSspSelectProductPicture_Result.Month1;
				wSProductPicture.FPId = wSspSelectProductPicture_Result.FPId;
				wSProductPicture.RegisterDate = wSspSelectProductPicture_Result.RegisterDate;
				wSProductPicture.RegisterDatePersian = wSspSelectProductPicture_Result.RegisterDatePersian;
				wSProductPicture.WHId = wSspSelectProductPicture_Result.WHId;
				wSProductPicture.GUId = wSspSelectProductPicture_Result.GUId;
				wSProductPicture.FirstRegisterDate = wSspSelectProductPicture_Result.FirstRegisterDate;
				wSProductPicture.FirstRegisterDatePersian = wSspSelectProductPicture_Result.FirstRegisterDatePersian;
				wSProductPicture.FirstRegisterUserId = wSspSelectProductPicture_Result.FirstRegisterUserId;
				wSProductPicture.LanguageID = wSspSelectProductPicture_Result.LanguageID;
				wSProductPicture.AppType = Configuration.AppType;
				if (flag)
				{
					wSProductPicture.FirstRegisterDate = now;
					wSProductPicture.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					wSProductPicture.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
					wSProductPicture.LanguageID = result;
					wSProductPicture.GUId = System.Guid.NewGuid();
					_dbTbl.WSProductPicture.Add(wSProductPicture);
				}
				else
				{
					_dbTbl.Entry(wSProductPicture).State = EntityState.Modified;
				}
				_dbTbl.SaveChanges();
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductPicture");
				pic.PrdId = wSspSelectProductPicture_Result.PrdId;
				base.ViewBag.Update = true;
				pic.UserId = wSProductPicture.UserId;
				pic.FirstRegisterUserId = wSProductPicture.FirstRegisterUserId;
				pic.RegisterDate = wSProductPicture.RegisterDate;
				pic.FirstRegisterDate = wSProductPicture.FirstRegisterDate;
				pic.AppType = wSProductPicture.AppType;
			}
			SetRegisterInfoForProductPicture(pic);
			return View(pic);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			base.ModelState.AddModelError("error", Messages.frmErrorInSendingFile);
			SetRegisterInfoForProductPicture(pic);
			return View(pic);
		}
	}

	public FileResult GetPictureProduct(int prdId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			if (prdId != 0)
			{
				byte[] array = null;
				WSspSelectProductPicture_Result wSspSelectProductPicture_Result = Enumerable.FirstOrDefault<WSspSelectProductPicture_Result>((IEnumerable<WSspSelectProductPicture_Result>)_db.WSspSelectProductPicture(prdId, lCID, result));
				if (wSspSelectProductPicture_Result != null)
				{
					array = wSspSelectProductPicture_Result.PrdFirstPic;
					Image.FromStream((Stream)new MemoryStream(array, writable: false));
				}
				if (array != null)
				{
					return File(array, "image/jpeg");
				}
				return null;
			}
			return null;
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			return null;
		}
	}

	public string PictureProductDelete(int prdId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string result2 = "0";
		try
		{
			_003C_003Ec__DisplayClass42_0 _003C_003Ec__DisplayClass42_ = new _003C_003Ec__DisplayClass42_0();
			_003C_003Ec__DisplayClass42_.prdPic = Enumerable.FirstOrDefault<WSspSelectProductPicture_Result>((IEnumerable<WSspSelectProductPicture_Result>)_db.WSspSelectProductPicture(prdId, lCID, result));
			if (_003C_003Ec__DisplayClass42_.prdPic != null)
			{
				DbSet<WSProductPicture> wSProductPicture = _dbTbl.WSProductPicture;
				ParameterExpression val = Expression.Parameter(typeof(WSProductPicture), "p");
				WSProductPicture entity = Queryable.FirstOrDefault<WSProductPicture>((IQueryable<WSProductPicture>)wSProductPicture, Expression.Lambda<Func<WSProductPicture, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass42_, typeof(_003C_003Ec__DisplayClass42_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				_dbTbl.WSProductPicture.Remove(entity);
				_dbTbl.SaveChanges();
				result2 = "1";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result2;
	}

	[LoginAuthorize]
	public ActionResult CompressDbPictures()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<WSspSelectProductFirstGroup_Result> list2 = Enumerable.ToList<WSspSelectProductFirstGroup_Result>((IEnumerable<WSspSelectProductFirstGroup_Result>)_db.WSspSelectProductFirstGroup(lCID, result));
			if (list2 != null)
			{
				list.AddRange(Enumerable.Select<WSspSelectProductFirstGroup_Result, SelectListItem>((IEnumerable<WSspSelectProductFirstGroup_Result>)list2, (Func<WSspSelectProductFirstGroup_Result, SelectListItem>)((WSspSelectProductFirstGroup_Result x) => new SelectListItem
				{
					Text = x.FGName,
					Value = x.PrdFirstGroupID.ToString()
				})));
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		base.ViewBag.FirstGroups = list;
		return View();
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetProductSecondGroup(int fgId = 0)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (fgId > 0)
			{
				List<WSspSelectProductSecondGroup_Result> list2 = Enumerable.ToList<WSspSelectProductSecondGroup_Result>((IEnumerable<WSspSelectProductSecondGroup_Result>)_db.WSspSelectProductSecondGroup(fgId, lCID, result));
				if (list2 != null)
				{
					list.AddRange(Enumerable.Select<WSspSelectProductSecondGroup_Result, SelectListItem>((IEnumerable<WSspSelectProductSecondGroup_Result>)list2, (Func<WSspSelectProductSecondGroup_Result, SelectListItem>)((WSspSelectProductSecondGroup_Result x) => new SelectListItem
					{
						Text = x.SGName,
						Value = x.PrdSecondGroupID.ToString()
					})));
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string PrdCompressDbPictures(int fgId = 0, int sgId = 0, bool forceAll = false)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			string compressDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			List<WSspSelectProductPictureWithPrdGroups_Result> list2 = Enumerable.ToList<WSspSelectProductPictureWithPrdGroups_Result>((IEnumerable<WSspSelectProductPictureWithPrdGroups_Result>)_dbI.WSspSelectProductPictureWithPrdGroups(fgId, sgId, lCID, result));
			if (list2 != null)
			{
				list2 = Enumerable.ToList<WSspSelectProductPictureWithPrdGroups_Result>(Enumerable.Where<WSspSelectProductPictureWithPrdGroups_Result>((IEnumerable<WSspSelectProductPictureWithPrdGroups_Result>)list2, (Func<WSspSelectProductPictureWithPrdGroups_Result, bool>)((WSspSelectProductPictureWithPrdGroups_Result x) => x.PrdFirstPic.Length > 150000 && string.IsNullOrWhiteSpace(x.CompressDatePersian))));
				if (!forceAll)
				{
					list2 = Enumerable.ToList<WSspSelectProductPictureWithPrdGroups_Result>(Enumerable.Take<WSspSelectProductPictureWithPrdGroups_Result>((IEnumerable<WSspSelectProductPictureWithPrdGroups_Result>)list2, 100));
				}
				using List<WSspSelectProductPictureWithPrdGroups_Result>.Enumerator enumerator = list2.GetEnumerator();
				while (enumerator.MoveNext())
				{
					_003C_003Ec__DisplayClass45_0 _003C_003Ec__DisplayClass45_ = new _003C_003Ec__DisplayClass45_0();
					_003C_003Ec__DisplayClass45_.i = enumerator.Current;
					try
					{
						string fileSizeShort = ImageManager.GetFileSizeShort(_003C_003Ec__DisplayClass45_.i.PrdFirstPic.Length);
						byte[] array = ImageManager.CompressByte(new ImageManager.ImageParam
						{
							Bytes = _003C_003Ec__DisplayClass45_.i.PrdFirstPic,
							MinSizeForCompress = 150000
						});
						string fileSizeShort2 = ImageManager.GetFileSizeShort(array.Length);
						string text = fileSizeShort + " => " + fileSizeShort2;
						DbSet<WSProductPicture> wSProductPicture = _dbTbl.WSProductPicture;
						ParameterExpression val = Expression.Parameter(typeof(WSProductPicture), "x");
						WSProductPicture wSProductPicture2 = Queryable.FirstOrDefault<WSProductPicture>((IQueryable<WSProductPicture>)wSProductPicture, Expression.Lambda<Func<WSProductPicture, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass45_, typeof(_003C_003Ec__DisplayClass45_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
						if (wSProductPicture2 != null)
						{
							wSProductPicture2.PrdFirstPic = array;
							wSProductPicture2.CompressDate = DateTime.Now;
							wSProductPicture2.CompressDatePersian = compressDatePersian;
							wSProductPicture2.CompressUserId = UserLogin.CurrentUser.UserId;
							wSProductPicture2.CompressInfo = text;
							_dbTbl.Entry(wSProductPicture2).State = EntityState.Modified;
							_dbTbl.SaveChanges();
							list.Add(new SelectListItem
							{
								Text = text,
								Value = _003C_003Ec__DisplayClass45_.i.PrdJs,
								Selected = true
							});
						}
					}
					catch (Exception ex)
					{
						Public.InsExceptToElmah(ex);
						list.Add(new SelectListItem
						{
							Text = ex.Message,
							Value = _003C_003Ec__DisplayClass45_.i.PrdJs,
							Selected = false
						});
					}
				}
			}
		}
		catch (Exception ex2)
		{
			Public.InsExceptToElmah(ex2);
		}
		return JsonConvert.SerializeObject(list);
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmProducts", ActionName = "actResetPrdCode")]
	public string ProductResetCode()
	{
		string result = "";
		try
		{
			_db.WSspResetProductsCode();
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
			result = Messages.frmErrorMessage;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			result = Messages.frmErrorMessage;
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "frmProducts", ActionName = "actSHPProductDetails")]
	public ActionResult ProductInShop(int prdId)
	{
		_003C_003Ec__DisplayClass47_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass47_0();
		CS_0024_003C_003E8__locals0.prdId = prdId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		DbSet<WSProducts_Lang> wSProducts_Lang = _dbTbl.WSProducts_Lang;
		ParameterExpression val = Expression.Parameter(typeof(WSProducts_Lang), "c");
		List<WSProducts_Lang> list = Enumerable.ToList<WSProducts_Lang>((IEnumerable<WSProducts_Lang>)Queryable.Where<WSProducts_Lang>((IQueryable<WSProducts_Lang>)wSProducts_Lang, Expression.Lambda<Func<WSProducts_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass47_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
		GetPrdStockManageTypes();
		DbSet<WSProducts> wSProducts = _dbTbl.WSProducts;
		val = Expression.Parameter(typeof(WSProducts), "c");
		WSProducts wSProducts2 = Queryable.FirstOrDefault<WSProducts>((IQueryable<WSProducts>)wSProducts, Expression.Lambda<Func<WSProducts, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass47_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
		WSProductsInShopLanguageViewModel wSProductsInShopLanguageViewModel = new WSProductsInShopLanguageViewModel();
		if (wSProducts2 == null)
		{
			wSProductsInShopLanguageViewModel = new WSProductsInShopLanguageViewModel();
			wSProductsInShopLanguageViewModel.ProductID = CS_0024_003C_003E8__locals0.prdId;
			return View(wSProductsInShopLanguageViewModel);
		}
		List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSProducts_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSProducts_Lang>)list, (Func<WSProducts_Lang, CommonMultiLanguageViewModel>)((WSProducts_Lang item) => new CommonMultiLanguageViewModel
		{
			Value = item.PrdName,
			LanguageId = item.LanguageID
		})));
		list2.Add(new CommonMultiLanguageViewModel
		{
			Value = wSProducts2.PrdName,
			LanguageId = result
		});
		List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSProducts_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSProducts_Lang>)list, (Func<WSProducts_Lang, CommonMultiLanguageViewModel>)((WSProducts_Lang item) => new CommonMultiLanguageViewModel
		{
			Value = item.PrdSHPTitle,
			LanguageId = item.LanguageID
		})));
		list3.Add(new CommonMultiLanguageViewModel
		{
			Value = wSProducts2.PrdSHPTitle,
			LanguageId = result
		});
		List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSProducts_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSProducts_Lang>)list, (Func<WSProducts_Lang, CommonMultiLanguageViewModel>)((WSProducts_Lang item) => new CommonMultiLanguageViewModel
		{
			Value = item.PrdSHPModel,
			LanguageId = item.LanguageID
		})));
		list4.Add(new CommonMultiLanguageViewModel
		{
			Value = wSProducts2.PrdSHPModel,
			LanguageId = result
		});
		List<CommonMultiLanguageViewModel> list5 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSProducts_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSProducts_Lang>)list, (Func<WSProducts_Lang, CommonMultiLanguageViewModel>)((WSProducts_Lang item) => new CommonMultiLanguageViewModel
		{
			Value = item.PrdSHPDescription,
			LanguageId = item.LanguageID
		})));
		list5.Add(new CommonMultiLanguageViewModel
		{
			Value = wSProducts2.PrdSHPDescription,
			LanguageId = result
		});
		List<CommonMultiLanguageViewModel> list6 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSProducts_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSProducts_Lang>)list, (Func<WSProducts_Lang, CommonMultiLanguageViewModel>)((WSProducts_Lang item) => new CommonMultiLanguageViewModel
		{
			Value = item.PrdSHPDescriptionII,
			LanguageId = item.LanguageID
		})));
		list6.Add(new CommonMultiLanguageViewModel
		{
			Value = wSProducts2.PrdSHPDescriptionII,
			LanguageId = result
		});
		List<CommonMultiLanguageViewModel> list7 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSProducts_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSProducts_Lang>)list, (Func<WSProducts_Lang, CommonMultiLanguageViewModel>)((WSProducts_Lang item) => new CommonMultiLanguageViewModel
		{
			Value = item.PrdSeoTitle,
			LanguageId = item.LanguageID
		})));
		list7.Add(new CommonMultiLanguageViewModel
		{
			Value = wSProducts2.PrdSeoTitle,
			LanguageId = result
		});
		List<CommonMultiLanguageViewModel> list8 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSProducts_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSProducts_Lang>)list, (Func<WSProducts_Lang, CommonMultiLanguageViewModel>)((WSProducts_Lang item) => new CommonMultiLanguageViewModel
		{
			Value = item.PrdSeoDescription,
			LanguageId = item.LanguageID
		})));
		list8.Add(new CommonMultiLanguageViewModel
		{
			Value = wSProducts2.PrdSeoDescription,
			LanguageId = result
		});
		List<CommonMultiLanguageViewModel> list9 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSProducts_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSProducts_Lang>)list, (Func<WSProducts_Lang, CommonMultiLanguageViewModel>)((WSProducts_Lang item) => new CommonMultiLanguageViewModel
		{
			Value = item.PrdSeoAuthor,
			LanguageId = item.LanguageID
		})));
		list9.Add(new CommonMultiLanguageViewModel
		{
			Value = wSProducts2.PrdSeoAuthor,
			LanguageId = result
		});
		List<CommonMultiLanguageViewModel> list10 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSProducts_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSProducts_Lang>)list, (Func<WSProducts_Lang, CommonMultiLanguageViewModel>)((WSProducts_Lang item) => new CommonMultiLanguageViewModel
		{
			Value = item.PrdSeoCopyright,
			LanguageId = item.LanguageID
		})));
		list10.Add(new CommonMultiLanguageViewModel
		{
			Value = wSProducts2.PrdSeoCopyright,
			LanguageId = result
		});
		List<CommonMultiLanguageViewModel> list11 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSProducts_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSProducts_Lang>)list, (Func<WSProducts_Lang, CommonMultiLanguageViewModel>)((WSProducts_Lang item) => new CommonMultiLanguageViewModel
		{
			Value = item.PrdSeoKeywords,
			LanguageId = item.LanguageID
		})));
		list11.Add(new CommonMultiLanguageViewModel
		{
			Value = wSProducts2.PrdSeoKeywords,
			LanguageId = result
		});
		List<CommonMultiLanguageViewModel> list12 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSProducts_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSProducts_Lang>)list, (Func<WSProducts_Lang, CommonMultiLanguageViewModel>)((WSProducts_Lang item) => new CommonMultiLanguageViewModel
		{
			Value = item.PrdSeoFAQ,
			LanguageId = item.LanguageID
		})));
		list12.Add(new CommonMultiLanguageViewModel
		{
			Value = wSProducts2.PrdSeoFAQ,
			LanguageId = result
		});
		wSProductsInShopLanguageViewModel = new WSProductsInShopLanguageViewModel
		{
			ProductID = wSProducts2.ProductID,
			PrdName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
			PrdName_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
			PrdSHPIsActive = wSProducts2.PrdSHPIsActive,
			PrdSHPTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
			PrdSHPTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
			PrdSHPCode = wSProducts2.PrdSHPCode,
			PrdSHPModel = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
			PrdSHPModel_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
			PrdSHPDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
			PrdSHPDescription_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
			PrdSHPDescriptionII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
			PrdSHPDescriptionII_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
			PrdSHPStockManageTypeId = wSProducts2.PrdSHPStockManageTypeId,
			PrdSHPStockManualyCount = wSProducts2.PrdSHPStockManualyCount,
			PrdSHPHiddenPriceInNoStock = wSProducts2.PrdSHPHiddenPriceInNoStock,
			PrdSHPSelfSupplier = wSProducts2.PrdSHPSelfSupplier,
			PrdSHPOtherSupplierId = wSProducts2.PrdSHPOtherSupplierId,
			PrdSHPOtherSupplier = CRMIdeal.Classes.Helper.Company.GetCompanyNameWithTitle(wSProducts2.PrdSHPOtherSupplierId.GetValueOrDefault()),
			PrdSHPQtyFromTracing = wSProducts2.PrdSHPQtyFromTracing,
			PrdSHPShowLinkedPrd = wSProducts2.PrdSHPShowLinkedPrd,
			PrdSeoIsActive = wSProducts2.PrdSeoIsActive,
			PrdSeoTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
			PrdSeoDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
			PrdSeoHttpEquiv = wSProducts2.PrdSeoHttpEquiv,
			PrdSeoExpires = wSProducts2.PrdSeoExpires,
			PrdSeoGoogleNotranslate = wSProducts2.PrdSeoGoogleNotranslate,
			PrdSeoDistribution = wSProducts2.PrdSeoDistribution,
			PrdSeoRobots = wSProducts2.PrdSeoRobots,
			PrdSeoRating = wSProducts2.PrdSeoRating,
			PrdSeoAuthor = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
			PrdSeoIsUseSocialNetwork = wSProducts2.PrdSeoIsUseSocialNetwork,
			PrdSeoMobileOptimized = wSProducts2.PrdSeoMobileOptimized,
			PrdSeoCopyright = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
			PrdSeoUseDefault = wSProducts2.PrdSeoUseDefault,
			PrdSeoKeywords = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
			PrdSeoFAQ = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
			PrdSeoTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
			PrdSeoDescription_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
			PrdSeoAuthor_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
			PrdSeoCopyright_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
			PrdSeoKeywords_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
			PrdSeoFAQ_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))))
		};
		return View(wSProductsInShopLanguageViewModel);
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmSHPProductDetails", ActionName = "actPost")]
	public ActionResult ProductInShop(WSProductsInShopLanguageViewModel model)
	{
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Unknown result type (might be due to invalid IL or missing references)
		//IL_0268: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0310: Unknown result type (might be due to invalid IL or missing references)
		//IL_0364: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b8: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass48_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass48_0();
		CS_0024_003C_003E8__locals0.model = model;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		GetPrdStockManageTypes();
		List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.PrdName_Lang))
		{
			list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.PrdName_Lang);
		}
		list.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.model.PrdName,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.PrdSHPTitle_Lang))
		{
			list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.PrdSHPTitle_Lang);
		}
		list2.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.model.PrdSHPTitle,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.PrdSHPModel_Lang))
		{
			list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.PrdSHPModel_Lang);
		}
		list3.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.model.PrdSHPModel,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.PrdSHPDescription_Lang))
		{
			list4 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.PrdSHPDescription_Lang);
		}
		list4.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.model.PrdSHPDescription,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list5 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.PrdSHPDescriptionII_Lang))
		{
			list5 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.PrdSHPDescriptionII_Lang);
		}
		list5.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.model.PrdSHPDescriptionII,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list6 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.PrdSeoTitle_Lang))
		{
			list6 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.PrdSeoTitle_Lang);
		}
		list6.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.model.PrdSeoTitle,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list7 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.PrdSeoDescription_Lang))
		{
			list7 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.PrdSeoDescription_Lang);
		}
		list7.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.model.PrdSeoDescription,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list8 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.PrdSeoAuthor_Lang))
		{
			list8 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.PrdSeoAuthor_Lang);
		}
		list8.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.model.PrdSeoAuthor,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list9 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.PrdSeoCopyright_Lang))
		{
			list9 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.PrdSeoCopyright_Lang);
		}
		list9.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.model.PrdSeoCopyright,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list10 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.PrdSeoKeywords_Lang))
		{
			list10 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.PrdSeoKeywords_Lang);
		}
		list10.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.model.PrdSeoKeywords,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list11 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.PrdSeoFAQ_Lang))
		{
			list11 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.PrdSeoFAQ_Lang);
		}
		list11.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.model.PrdSeoFAQ,
			LanguageId = lCID
		});
		string text = "";
		if (CS_0024_003C_003E8__locals0.model.ProductID <= 0)
		{
			text = text + Messages.msgNotFound + "<br/>";
		}
		if (text != "")
		{
			base.ViewBag.Error = text;
		}
		else if (!base.ModelState.IsValid)
		{
			base.ViewBag.Error = Messages.frmErrorMessage + "<br/> " + string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
		}
		else
		{
			try
			{
				DateTime now = DateTime.Now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short month = short.Parse(now.ToString("MM", new PersianCulture()));
				int userId = UserLogin.CurrentUser.UserId;
				string appType = Configuration.AppType;
				DbSet<WSProducts> wSProducts = _dbTbl.WSProducts;
				ParameterExpression val = Expression.Parameter(typeof(WSProducts), "c");
				WSProducts wSProducts2 = Queryable.FirstOrDefault<WSProducts>((IQueryable<WSProducts>)wSProducts, Expression.Lambda<Func<WSProducts, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass48_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (wSProducts2 == null)
				{
					base.ViewBag.Error = Messages.ErrorNotFound;
				}
				else
				{
					wSProducts2.UserId = userId;
					wSProducts2.RegisterDate = now;
					wSProducts2.RegisterDatePersian = registerDatePersian;
					wSProducts2.Month1 = month;
					wSProducts2.AppType = appType;
					wSProducts2.PrdSHPIsActive = CS_0024_003C_003E8__locals0.model.PrdSHPIsActive;
					wSProducts2.PrdSHPTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					wSProducts2.PrdSHPCode = CS_0024_003C_003E8__locals0.model.PrdSHPCode;
					wSProducts2.PrdSHPModel = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					wSProducts2.PrdSHPDescription = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					wSProducts2.PrdSHPDescriptionII = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					wSProducts2.PrdSHPStockManageTypeId = CS_0024_003C_003E8__locals0.model.PrdSHPStockManageTypeId;
					wSProducts2.PrdSHPStockManualyCount = CS_0024_003C_003E8__locals0.model.PrdSHPStockManualyCount;
					wSProducts2.PrdSHPHiddenPriceInNoStock = CS_0024_003C_003E8__locals0.model.PrdSHPHiddenPriceInNoStock;
					wSProducts2.PrdSHPSelfSupplier = CS_0024_003C_003E8__locals0.model.PrdSHPSelfSupplier;
					wSProducts2.PrdSHPOtherSupplierId = CS_0024_003C_003E8__locals0.model.PrdSHPOtherSupplierId;
					wSProducts2.PrdSHPQtyFromTracing = CS_0024_003C_003E8__locals0.model.PrdSHPQtyFromTracing;
					wSProducts2.PrdSHPShowLinkedPrd = CS_0024_003C_003E8__locals0.model.PrdSHPShowLinkedPrd;
					wSProducts2.PrdSeoIsActive = CS_0024_003C_003E8__locals0.model.PrdSeoIsActive;
					wSProducts2.PrdSeoTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					wSProducts2.PrdSeoDescription = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					wSProducts2.PrdSeoHttpEquiv = CS_0024_003C_003E8__locals0.model.PrdSeoHttpEquiv;
					wSProducts2.PrdSeoExpires = CS_0024_003C_003E8__locals0.model.PrdSeoExpires;
					wSProducts2.PrdSeoGoogleNotranslate = CS_0024_003C_003E8__locals0.model.PrdSeoGoogleNotranslate;
					wSProducts2.PrdSeoDistribution = CS_0024_003C_003E8__locals0.model.PrdSeoDistribution;
					wSProducts2.PrdSeoRobots = CS_0024_003C_003E8__locals0.model.PrdSeoRobots;
					wSProducts2.PrdSeoRating = CS_0024_003C_003E8__locals0.model.PrdSeoRating;
					wSProducts2.PrdSeoAuthor = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					wSProducts2.PrdSeoIsUseSocialNetwork = CS_0024_003C_003E8__locals0.model.PrdSeoIsUseSocialNetwork;
					wSProducts2.PrdSeoMobileOptimized = CS_0024_003C_003E8__locals0.model.PrdSeoMobileOptimized;
					wSProducts2.PrdSeoCopyright = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					wSProducts2.PrdSeoUseDefault = CS_0024_003C_003E8__locals0.model.PrdSeoUseDefault;
					wSProducts2.PrdSeoKeywords = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					wSProducts2.PrdSeoFAQ = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					_dbTbl.Entry(wSProducts2).State = EntityState.Modified;
					_dbTbl.SaveChanges();
					using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							_003C_003Ec__DisplayClass48_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass48_1();
							CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
							CS_0024_003C_003E8__locals1.lang = enumerator.Current;
							DbSet<WSProducts_Lang> wSProducts_Lang = _dbTbl.WSProducts_Lang;
							val = Expression.Parameter(typeof(WSProducts_Lang), "c");
							WSProducts_Lang wSProducts_Lang2 = Queryable.FirstOrDefault<WSProducts_Lang>((IQueryable<WSProducts_Lang>)wSProducts_Lang, Expression.Lambda<Func<WSProducts_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass48_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass48_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (wSProducts_Lang2 != null)
							{
								wSProducts_Lang2.PrdSHPTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								wSProducts_Lang2.PrdSHPModel = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								wSProducts_Lang2.PrdSHPDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								wSProducts_Lang2.PrdSHPDescriptionII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								wSProducts_Lang2.PrdSeoTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								wSProducts_Lang2.PrdSeoDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								wSProducts_Lang2.PrdSeoAuthor = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								wSProducts_Lang2.PrdSeoCopyright = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								wSProducts_Lang2.PrdSeoKeywords = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								wSProducts_Lang2.PrdSeoFAQ = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								_dbTbl.Entry(wSProducts_Lang2).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							wSProducts_Lang2 = new WSProducts_Lang
							{
								LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID,
								ProductID = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.ProductID,
								PrdSHPTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
								PrdSHPModel = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
								PrdSHPDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
								PrdSHPDescriptionII = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
								PrdSeoTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
								PrdSeoDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
								PrdSeoAuthor = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
								PrdSeoCopyright = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
								PrdSeoKeywords = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
								PrdSeoFAQ = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null)
							};
							_dbTbl.WSProducts_Lang.Add(wSProducts_Lang2);
							_dbTbl.SaveChanges();
						}
					}
					new FilesManager();
					new FacadeFTP(Configuration.FacadeFtpFo);
					string pathFtpFo = Configuration.PathFtpFo;
					string userNameFtpFo = Configuration.UserNameFtpFo;
					string passwordFtpFo = Configuration.PasswordFtpFo;
					bool usePassiveFtpFo = Configuration.UsePassiveFtpFo;
					if (!string.IsNullOrEmpty(pathFtpFo) && !string.IsNullOrEmpty(userNameFtpFo) && !string.IsNullOrEmpty(passwordFtpFo))
					{
						try
						{
							if (list4 != null)
							{
								Files.UploadPicFromEditorToFtp(pathFtpFo, userNameFtpFo, passwordFtpFo, usePassiveFtpFo, list4);
							}
							if (list5 != null)
							{
								Files.UploadPicFromEditorToFtp(pathFtpFo, userNameFtpFo, passwordFtpFo, usePassiveFtpFo, list5);
							}
						}
						catch (Exception e)
						{
							ErrorSignal.FromCurrentContext().Raise(e);
						}
					}
					base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
				}
			}
			catch (Exception e2)
			{
				ErrorSignal.FromCurrentContext().Raise(e2);
				base.ViewBag.Error = Messages.frmErrorMessage;
			}
		}
		return View(CS_0024_003C_003E8__locals0.model);
	}

	[AjaxOnly]
	public JsonResult GetPrdStockManageTypes()
	{
		List<MultiGroupItem> list = new List<MultiGroupItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			foreach (WSspSelectProductShpStockManageTypes_Result item2 in Enumerable.ToList<WSspSelectProductShpStockManageTypes_Result>((IEnumerable<WSspSelectProductShpStockManageTypes_Result>)_db.WSspSelectProductShpStockManageTypes(lCID, result)))
			{
				MultiGroupItem item = new MultiGroupItem
				{
					title = item2.ProductShpStockManageType,
					ischeck = false,
					id = item2.ProductShpStockManageTypeId
				};
				list.Add(item);
			}
			base.ViewBag.SockManageTypes = list;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult PrdGallery_Read([DataSourceRequest] DataSourceRequest request, int prdId, bool? isExcept = false)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectProductGallery_Result> list = new List<WSspSelectProductGallery_Result>();
		try
		{
			list = Enumerable.ToList<WSspSelectProductGallery_Result>((IEnumerable<WSspSelectProductGallery_Result>)_db.WSspSelectProductGallery(prdId));
			list = ((!isExcept.GetValueOrDefault()) ? Enumerable.ToList<WSspSelectProductGallery_Result>(Enumerable.Where<WSspSelectProductGallery_Result>((IEnumerable<WSspSelectProductGallery_Result>)list, (Func<WSspSelectProductGallery_Result, bool>)((WSspSelectProductGallery_Result x) => x.PrdShpExceptionId.GetValueOrDefault() == 0))) : Enumerable.ToList<WSspSelectProductGallery_Result>(Enumerable.Where<WSspSelectProductGallery_Result>((IEnumerable<WSspSelectProductGallery_Result>)list, (Func<WSspSelectProductGallery_Result, bool>)((WSspSelectProductGallery_Result x) => x.PrdShpExceptionId.GetValueOrDefault() != 0))));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public void SetRegisterInfoPrdgallery(WSProductGallery model, ref string firstRegInfo, ref string regInfo)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			if (model == null)
			{
				return;
			}
			List<CRMspSelectUsersByIds_Result> list = CRMIdeal.Classes.Helper.User.SelectUsersByIds(model.FirstRegisterUserId + "," + model.UserId);
			if (list == null || !Enumerable.Any<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list))
			{
				return;
			}
			CRMspSelectUsersByIds_Result cRMspSelectUsersByIds_Result = Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result c) => c.UserId == model.FirstRegisterUserId));
			if (cRMspSelectUsersByIds_Result != null)
			{
				firstRegInfo = ((!string.IsNullOrEmpty(cRMspSelectUsersByIds_Result.LName)) ? cRMspSelectUsersByIds_Result.LName : "") + ((!string.IsNullOrEmpty(cRMspSelectUsersByIds_Result.FName)) ? (" " + cRMspSelectUsersByIds_Result.FName) : "");
				_ = model.FirstRegisterDate;
				string text = model.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				firstRegInfo += ((!string.IsNullOrEmpty(text)) ? (" (" + text + ")") : "");
			}
			CRMspSelectUsersByIds_Result cRMspSelectUsersByIds_Result2 = Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result c) => c.UserId == model.UserId));
			if (cRMspSelectUsersByIds_Result2 != null)
			{
				regInfo = ((!string.IsNullOrEmpty(cRMspSelectUsersByIds_Result2.LName)) ? cRMspSelectUsersByIds_Result2.LName : "") + ((!string.IsNullOrEmpty(cRMspSelectUsersByIds_Result2.FName)) ? (" " + cRMspSelectUsersByIds_Result2.FName) : "");
				_ = model.RegisterDate;
				string text2 = model.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				if (string.IsNullOrEmpty(model.AppType))
				{
					model.AppType = Configuration.AppType;
				}
				string text3 = Labels.AppType + ": " + Configuration.GetAppType(model.AppType);
				regInfo = regInfo + " (" + text3 + ")" + ((!string.IsNullOrEmpty(text2)) ? (" (" + text2 + ")") : "");
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}

	[DynamicAuthorize(ControllerName = "frmSHPProductDetails", ActionName = "actInsertGalleryPic,actEditGalleryPic")]
	public ActionResult ProductdGalleryInsertEdit(int prdId, int prdGalleryId = 0, int? exceptionId = null)
	{
		_003C_003Ec__DisplayClass52_0 _003C_003Ec__DisplayClass52_ = new _003C_003Ec__DisplayClass52_0();
		_003C_003Ec__DisplayClass52_.prdGalleryId = prdGalleryId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		WSProductGallery wSProductGallery2;
		try
		{
			if (_003C_003Ec__DisplayClass52_.prdGalleryId > 0)
			{
				if (!UserLogin.IsUserAccess("frmSHPProductDetails", "actEditGalleryPic"))
				{
					base.ViewBag.Error = Messages.NotAccessToPage;
					return null;
				}
				DbSet<WSProductGallery> wSProductGallery = _dbTbl.WSProductGallery;
				ParameterExpression val = Expression.Parameter(typeof(WSProductGallery), "c");
				wSProductGallery2 = Queryable.FirstOrDefault<WSProductGallery>((IQueryable<WSProductGallery>)wSProductGallery, Expression.Lambda<Func<WSProductGallery, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass52_, typeof(_003C_003Ec__DisplayClass52_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (wSProductGallery2 == null)
				{
					base.ViewBag.Error = Messages.ErrorNotFound;
					return null;
				}
			}
			else
			{
				if (!UserLogin.IsUserAccess("frmSHPProductDetails", "actInsertGalleryPic"))
				{
					base.ViewBag.Error = Messages.NotAccessToPage;
					return null;
				}
				DateTime now = DateTime.Now;
				wSProductGallery2 = new WSProductGallery
				{
					PrdId = prdId,
					FirstRegisterUserId = UserLogin.CurrentUser.UserId,
					FirstRegisterDate = now,
					FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
					UserId = UserLogin.CurrentUser.UserId,
					RegisterDate = now,
					RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
					PrdShpExceptionId = exceptionId
				};
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			base.ViewBag.Error = ex.Message;
			return null;
		}
		string firstRegInfo = "";
		string regInfo = "";
		SetRegisterInfoPrdgallery(wSProductGallery2, ref firstRegInfo, ref regInfo);
		base.ViewBag.FirstRegisterUser = firstRegInfo;
		base.ViewBag.EditUser = regInfo;
		return View(wSProductGallery2);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	[DynamicAuthorize(ControllerName = "frmSHPProductDetails", ActionName = "actInsertGalleryPic,actEditGalleryPic")]
	public ActionResult ProductdGalleryInsertEdit(WSProductGallery model, HttpPostedFileBase FileUrlUpload)
	{
		_003C_003Ec__DisplayClass53_0 _003C_003Ec__DisplayClass53_ = new _003C_003Ec__DisplayClass53_0();
		_003C_003Ec__DisplayClass53_.model = model;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		string firstRegInfo = "";
		string regInfo = "";
		try
		{
			DateTime now;
			string text2;
			int userId;
			if (string.IsNullOrEmpty(text))
			{
				if (!base.ModelState.IsValid)
				{
					base.ViewBag.Error = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
				}
				else
				{
					now = DateTime.Now;
					text2 = now.ToString("yyyyMMdd", new PersianCulture());
					short month = short.Parse(now.ToString("MM", new PersianCulture()));
					userId = UserLogin.CurrentUser.UserId;
					string appType = Configuration.AppType;
					int id = Financial.Get().Id;
					WSProductGallery wSProductGallery = new WSProductGallery();
					if (_003C_003Ec__DisplayClass53_.model.ProductGalleryId > 0)
					{
						DbSet<WSProductGallery> wSProductGallery2 = _dbTbl.WSProductGallery;
						ParameterExpression val = Expression.Parameter(typeof(WSProductGallery), "c");
						wSProductGallery = Queryable.FirstOrDefault<WSProductGallery>((IQueryable<WSProductGallery>)wSProductGallery2, Expression.Lambda<Func<WSProductGallery, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass53_, typeof(_003C_003Ec__DisplayClass53_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
					}
					wSProductGallery.PrdId = _003C_003Ec__DisplayClass53_.model.PrdId;
					wSProductGallery.IsMain = _003C_003Ec__DisplayClass53_.model.IsMain;
					wSProductGallery.OrderView = _003C_003Ec__DisplayClass53_.model.OrderView;
					wSProductGallery.UserId = userId;
					wSProductGallery.FPId = id;
					wSProductGallery.Month1 = month;
					wSProductGallery.RegisterDate = now;
					wSProductGallery.RegisterDatePersian = text2;
					wSProductGallery.AppType = appType;
					if (_003C_003Ec__DisplayClass53_.model.ProductGalleryId == 0)
					{
						if (!UserLogin.IsUserAccess("frmSHPProductDetails", "actInsertGalleryPic"))
						{
							text = Messages.NotAccessToPage;
						}
						else
						{
							if (FileUrlUpload == null)
							{
								base.ViewBag.Error = Messages.msgErrorNoFileInNotSelect;
								SetRegisterInfoPrdgallery(_003C_003Ec__DisplayClass53_.model, ref firstRegInfo, ref regInfo);
								base.ViewBag.FirstRegisterUser = firstRegInfo;
								base.ViewBag.EditUser = regInfo;
								return View(_003C_003Ec__DisplayClass53_.model);
							}
							string text3 = FileUrlUpload.ContentType.ToLower();
							string text4 = ((FileUrlUpload.FileName != null) ? Path.GetExtension(FileUrlUpload.FileName).ToLower() : "");
							if ((text3 != "image/jpg" && text3 != "image/jpeg" && text3 != "image/pjpeg" && text3 != "image/gif" && text3 != "image/x-png" && text3 != "image/png") || (text4 != ".jpg" && text4 != ".png" && text4 != ".gif" && text4 != ".jpeg"))
							{
								text = Messages.msgErrorFileIsNotPic;
							}
							else
							{
								int num = 1048576;
								if (FileUrlUpload.ContentLength <= num)
								{
									WSspSelectProductsWithId_Result wSspSelectProductsWithId_Result = Enumerable.FirstOrDefault<WSspSelectProductsWithId_Result>((IEnumerable<WSspSelectProductsWithId_Result>)_db.WSspSelectProductsWithId(_003C_003Ec__DisplayClass53_.model.PrdId, lCID, result));
									if (wSspSelectProductsWithId_Result == null)
									{
										base.ViewBag.Error = Messages.ErrorNotFound;
										SetRegisterInfoPrdgallery(_003C_003Ec__DisplayClass53_.model, ref firstRegInfo, ref regInfo);
										base.ViewBag.FirstRegisterUser = firstRegInfo;
										base.ViewBag.EditUser = regInfo;
										return View(_003C_003Ec__DisplayClass53_.model);
									}
									wSProductGallery.FolderName = wSspSelectProductsWithId_Result.PrdFGroupId + "/" + wSspSelectProductsWithId_Result.PrdGroupID;
									wSProductGallery.FileName = wSspSelectProductsWithId_Result.ProductID.ToString();
									wSProductGallery.FilePath = _003C_003Ec__DisplayClass53_.model.FilePath;
									wSProductGallery.FirstRegisterUserId = userId;
									wSProductGallery.FirstRegisterDate = now;
									wSProductGallery.FirstRegisterDatePersian = text2;
									wSProductGallery.GUId = System.Guid.NewGuid();
									wSProductGallery.LanguageID = result;
									wSProductGallery.PrdShpExceptionId = _003C_003Ec__DisplayClass53_.model.PrdShpExceptionId;
									_dbTbl.WSProductGallery.Add(wSProductGallery);
									_dbTbl.Configuration.ValidateOnSaveEnabled = false;
									_dbTbl.SaveChanges();
									_dbTbl.Configuration.ValidateOnSaveEnabled = true;
									if (wSProductGallery.ProductGalleryId <= 0)
									{
										base.ViewBag.Error = Messages.msgErrorRunFunction;
									}
									else if (FileUrlUpload != null)
									{
										string[] array = FileUrlUpload.FileName.Split(new char[1] { '.' });
										string text5 = wSspSelectProductsWithId_Result.ProductID + "-" + wSProductGallery.ProductGalleryId + "." + array[^1];
										FacadeFTP facadeFTP = new FacadeFTP(Configuration.FacadeFtp);
										string pathFtp = Configuration.PathFtp;
										string userNameFtp = Configuration.UserNameFtp;
										string passwordFtp = Configuration.PasswordFtp;
										bool usePassiveFtp = Configuration.UsePassiveFtp;
										string mainDirectoryPath = Configuration.MainDirectoryPath;
										string prdDirectoryPath = Configuration.PrdDirectoryPath;
										prdDirectoryPath = (prdDirectoryPath.EndsWith("/") ? prdDirectoryPath.TrimEnd(new char[1] { '/' }) : prdDirectoryPath);
										bool flag = facadeFTP.ExistsDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, mainDirectoryPath, prdDirectoryPath, usePassiveFtp);
										if (!flag)
										{
											flag = facadeFTP.CreateDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, Configuration.MainDirectoryPath, prdDirectoryPath, usePassiveFtp);
										}
										mainDirectoryPath = Configuration.MainDirectoryPath + Configuration.PrdDirectoryPath;
										bool flag2 = facadeFTP.ExistsDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, mainDirectoryPath, wSspSelectProductsWithId_Result.PrdFGroupId.ToString(), usePassiveFtp);
										if (!flag2)
										{
											flag2 = facadeFTP.CreateDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, mainDirectoryPath, wSspSelectProductsWithId_Result.PrdFGroupId.ToString(), usePassiveFtp);
										}
										mainDirectoryPath = Configuration.MainDirectoryPath + Configuration.PrdDirectoryPath + wSspSelectProductsWithId_Result.PrdFGroupId + "/";
										bool flag3 = facadeFTP.ExistsDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, mainDirectoryPath, wSspSelectProductsWithId_Result.PrdGroupID.ToString(), usePassiveFtp);
										if (!flag3)
										{
											flag3 = facadeFTP.CreateDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, mainDirectoryPath, wSspSelectProductsWithId_Result.PrdGroupID.ToString(), usePassiveFtp);
										}
										if (flag && flag2 && flag3)
										{
											mainDirectoryPath = Configuration.MainDirectoryPath + Configuration.PrdDirectoryPath + wSspSelectProductsWithId_Result.PrdFGroupId + "/" + wSspSelectProductsWithId_Result.PrdGroupID + "/";
											byte[] bytes = ImageManager.CompressHttpPostedFileBase(new ImageManager.ImageParam
											{
												HttpPostedFileBase_Var = FileUrlUpload
											});
											string text6 = ImageManager.SaveFromByte(new ImageManager.ImageParam
											{
												Bytes = bytes
											});
											if (facadeFTP.UploadFtpFormTable(pathFtp, userNameFtp, passwordFtp, mainDirectoryPath + text5, text6, usePassiveFtp))
											{
												if (!string.IsNullOrWhiteSpace(text6))
												{
													ImageManager.DeleteFile(new ImageManager.ImageParam
													{
														FilePath = text6
													});
												}
												wSProductGallery.FileName = text5;
												wSProductGallery.FilePath = mainDirectoryPath + text5;
												_dbTbl.Entry(wSProductGallery).State = EntityState.Modified;
												_dbTbl.Configuration.ValidateOnSaveEnabled = false;
												_dbTbl.SaveChanges();
												_dbTbl.Configuration.ValidateOnSaveEnabled = true;
												_dbTbl.Entry(wSProductGallery).State = EntityState.Modified;
												_dbTbl.SaveChanges();
												string pathFtpFo = Configuration.PathFtpFo;
												string userNameFtpFo = Configuration.UserNameFtpFo;
												string passwordFtpFo = Configuration.PasswordFtpFo;
												_ = Configuration.UsePassiveFtpFo;
												if (!string.IsNullOrEmpty(pathFtpFo) && !string.IsNullOrEmpty(userNameFtpFo) && !string.IsNullOrEmpty(passwordFtpFo))
												{
													try
													{
														string text7 = "/" + Configuration.PrdDirectoryPath + wSspSelectProductsWithId_Result.PrdFGroupId + "/" + wSspSelectProductsWithId_Result.PrdGroupID;
														string text8 = base.Server.MapPath(text7);
														if (!System.IO.Directory.Exists(text8))
														{
															System.IO.Directory.CreateDirectory(text8);
															CRM.General.IO.Directory.SetFullControlForEveryOne(text8);
														}
														text8 = text8 + "\\" + text5;
														string source = wSProductGallery.FilePath.ToLower().Replace(Configuration.PathFtp.ToLower(), "");
														bool flag4 = facadeFTP.Download(pathFtp, userNameFtp, passwordFtp, text8, source, overwrite: true, usePassiveFtp);
														if (System.IO.File.Exists(text8) && flag4 && text5.IndexOf(".") > 0)
														{
															string text9 = text5;
															text9 = text9.Insert(text5.IndexOf("."), "-Thumb");
															string text10 = HttpContext.Current.Server.MapPath(text7 + "\\" + text9);
															if (!System.IO.File.Exists(text10))
															{
																ImageManager.CompressFile(new ImageManager.ImageParam
																{
																	FilePath = text8,
																	DestPath = text10,
																	CustomHeight = 300,
																	CustomWidth = 300,
																	FileExtension = Path.GetExtension(text8)
																});
															}
															if (System.IO.File.Exists(text10))
															{
																try
																{
																	Files.UploadFileToFtp(pathFtpFo, userNameFtpFo, passwordFtpFo, usePassiveFtp, text7 + "/" + text5);
																	Files.UploadFileToFtp(pathFtpFo, userNameFtpFo, passwordFtpFo, usePassiveFtp, text7 + "/" + text9);
																}
																catch (Exception e)
																{
																	ErrorSignal.FromCurrentContext().Raise(e);
																}
															}
														}
													}
													catch (Exception e2)
													{
														ErrorSignal.FromCurrentContext().Raise(e2);
													}
												}
												base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
											}
											else
											{
												if (!string.IsNullOrWhiteSpace(text6))
												{
													ImageManager.DeleteFile(new ImageManager.ImageParam
													{
														FilePath = text6
													});
												}
												Exception e3 = new Exception(Messages.msgErrorUploadingFileInFtp + "  -  hostname: " + Configuration.PathFtp + " ,username: " + Configuration.UserNameFtp + " ,destination: " + mainDirectoryPath + text5);
												ErrorSignal.FromCurrentContext().Raise(e3);
												text = Messages.frmErrorInSendingFile;
												try
												{
													_dbTbl.WSProductGallery.Remove(wSProductGallery);
													_dbTbl.SaveChanges();
												}
												catch (Exception e4)
												{
													ErrorSignal.FromCurrentContext().Raise(e4);
												}
											}
										}
										else
										{
											Exception e5 = new Exception("خطا در ایجاد فولدر ftp,   -  hostname: " + Configuration.PathFtp + " ,username: " + Configuration.UserNameFtp + " ,destination: " + mainDirectoryPath);
											ErrorSignal.FromCurrentContext().Raise(e5);
											text = Messages.frmErrorInSendingFile;
											try
											{
												_dbTbl.WSProductGallery.Remove(wSProductGallery);
												_dbTbl.SaveChanges();
											}
											catch (Exception e6)
											{
												ErrorSignal.FromCurrentContext().Raise(e6);
											}
										}
									}
									goto IL_0e89;
								}
								string fileFormatByteSize = CRM.General.IO.File.GetFileFormatByteSize(FileUrlUpload.ContentLength);
								string fileFormatByteSize2 = CRM.General.IO.File.GetFileFormatByteSize(num);
								text = string.Format(Messages.msgErrorMessageMaxSizeFile, fileFormatByteSize, fileFormatByteSize2);
							}
						}
					}
					else
					{
						if (UserLogin.IsUserAccess("frmSHPProductDetails", "actEditGalleryPic"))
						{
							_dbTbl.Entry(wSProductGallery).State = EntityState.Modified;
							_dbTbl.Configuration.ValidateOnSaveEnabled = false;
							_dbTbl.SaveChanges();
							_dbTbl.Configuration.ValidateOnSaveEnabled = true;
							base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
							goto IL_0e89;
						}
						text = Messages.NotAccessToPage;
					}
				}
			}
			goto end_IL_005c;
			IL_0e89:
			_003C_003Ec__DisplayClass53_.model.UserId = userId;
			_003C_003Ec__DisplayClass53_.model.RegisterDate = now;
			_003C_003Ec__DisplayClass53_.model.RegisterDatePersian = text2;
			end_IL_005c:;
		}
		catch (DbEntityValidationException e7)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e7);
			base.ViewBag.Error = Messages.msgErrorRunFunction;
		}
		catch (Exception e8)
		{
			ErrorSignal.FromCurrentContext().Raise(e8);
			base.ViewBag.Error = Messages.msgErrorRunFunction;
		}
		base.ViewBag.Error = text;
		firstRegInfo = "";
		regInfo = "";
		SetRegisterInfoPrdgallery(_003C_003Ec__DisplayClass53_.model, ref firstRegInfo, ref regInfo);
		base.ViewBag.FirstRegisterUser = firstRegInfo;
		base.ViewBag.EditUser = regInfo;
		return View(_003C_003Ec__DisplayClass53_.model);
	}

	public string ProductdGalleryDelete(int prdGalleryId)
	{
		_003C_003Ec__DisplayClass54_0 _003C_003Ec__DisplayClass54_ = new _003C_003Ec__DisplayClass54_0();
		_003C_003Ec__DisplayClass54_.prdGalleryId = prdGalleryId;
		string result = "-1";
		DbSet<WSProductGallery> wSProductGallery = _dbTbl.WSProductGallery;
		ParameterExpression val = Expression.Parameter(typeof(WSProductGallery), "c");
		WSProductGallery wSProductGallery2 = Queryable.FirstOrDefault<WSProductGallery>((IQueryable<WSProductGallery>)wSProductGallery, Expression.Lambda<Func<WSProductGallery, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass54_, typeof(_003C_003Ec__DisplayClass54_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
		if (wSProductGallery2 != null)
		{
			try
			{
				string text = wSProductGallery2.FilePath.ToLower().Replace(Configuration.PathFtp.ToLower(), "");
				text = Configuration.MainDirectoryPath + Configuration.PrdDirectoryPath + wSProductGallery2.FolderName + "/" + wSProductGallery2.FileName;
				FacadeFTP facadeFTP = new FacadeFTP(Configuration.FacadeFtp);
				string text2 = text;
				if (facadeFTP.Delete(Configuration.PathFtp, Configuration.UserNameFtp, Configuration.PasswordFtp, wSProductGallery2.FileName, text2, Configuration.UsePassiveFtp))
				{
					_dbTbl.WSProductGallery.Remove(wSProductGallery2);
					_dbTbl.SaveChanges();
					DbSet<WSProductGallery> wSProductGallery3 = _dbTbl.WSProductGallery;
					val = Expression.Parameter(typeof(WSProductGallery), "c");
					wSProductGallery2 = Queryable.FirstOrDefault<WSProductGallery>((IQueryable<WSProductGallery>)wSProductGallery3, Expression.Lambda<Func<WSProductGallery, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass54_, typeof(_003C_003Ec__DisplayClass54_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
					if (wSProductGallery2 == null)
					{
						DeleteOldPrdFromFtp(text2);
						result = Messages.frmDeleteSuccessMessage;
					}
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
		}
		return result;
	}

	[AjaxOnly]
	public string GetProductdGalleryFilePath(int prdGalleryId)
	{
		_003C_003Ec__DisplayClass55_0 _003C_003Ec__DisplayClass55_ = new _003C_003Ec__DisplayClass55_0();
		_003C_003Ec__DisplayClass55_.prdGalleryId = prdGalleryId;
		string text = "";
		if (_003C_003Ec__DisplayClass55_.prdGalleryId != 0)
		{
			try
			{
				DbSet<WSProductGallery> wSProductGallery = _dbTbl.WSProductGallery;
				ParameterExpression val = Expression.Parameter(typeof(WSProductGallery), "c");
				WSProductGallery wSProductGallery2 = Queryable.FirstOrDefault<WSProductGallery>((IQueryable<WSProductGallery>)wSProductGallery, Expression.Lambda<Func<WSProductGallery, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass55_, typeof(_003C_003Ec__DisplayClass55_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (wSProductGallery2 != null)
				{
					string text2 = wSProductGallery2.FilePath.ToLower().Replace(Configuration.PathFtp.ToLower(), "");
					text2 = Configuration.MainDirectoryPath + Configuration.PrdDirectoryPath + wSProductGallery2.FolderName + "/" + wSProductGallery2.FileName;
					if (text2 != "")
					{
						FilesManager filesManager = new FilesManager();
						string text3 = filesManager.SetNameDirectory(UserLogin.CurrentUser.UserId);
						if (filesManager.CreateDirectory(text3))
						{
							text = HttpContext.Current.Server.MapPath(text3 + "/" + wSProductGallery2.FileName);
							if (!new FacadeFTP(Configuration.FacadeFtp).Download(Configuration.PathFtp, Configuration.UserNameFtp, Configuration.PasswordFtp, text, text2, overwrite: true, Configuration.UsePassiveFtp))
							{
								text = "";
								string path = HttpContext.Current.Server.MapPath(text3);
								if (System.IO.Directory.Exists(path))
								{
									DirectoryInfo directoryInfo = new DirectoryInfo(path);
									FileInfo[] files = directoryInfo.GetFiles();
									for (int i = 0; i < files.Length; i++)
									{
										files[i].Delete();
									}
									DirectoryInfo[] directories = directoryInfo.GetDirectories();
									for (int i = 0; i < directories.Length; i++)
									{
										directories[i].Delete(recursive: true);
									}
									if (System.IO.Directory.Exists(path))
									{
										System.IO.Directory.Delete(path);
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
		}
		return text;
	}

	public bool checkMultiLanguage(string defaultValue, List<CommonMultiLanguageViewModel> list)
	{
		bool result = true;
		List<CRMspSelectUserLanguages_Result> list2 = CRMIdeal.Cache.User.Language.Get();
		bool isCurrentUserAllowCopyOtherLanguage = UserLogin.IsCurrentUserAllowCopyOtherLanguage;
		foreach (Languages itemLang in CRMIdeal.Cache.Setting.Language.Get())
		{
			CommonMultiLanguageViewModel commonMultiLanguageViewModel = Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == itemLang.LanguageID));
			if (commonMultiLanguageViewModel == null)
			{
				if (Enumerable.Any<CRMspSelectUserLanguages_Result>((IEnumerable<CRMspSelectUserLanguages_Result>)list2, (Func<CRMspSelectUserLanguages_Result, bool>)((CRMspSelectUserLanguages_Result c) => c.LanguageID == itemLang.LanguageID)))
				{
					if (isCurrentUserAllowCopyOtherLanguage)
					{
						list.Add(new CommonMultiLanguageViewModel
						{
							LanguageId = itemLang.LanguageID,
							Value = defaultValue
						});
					}
					else
					{
						result = false;
					}
				}
				else
				{
					list.Add(new CommonMultiLanguageViewModel
					{
						LanguageId = itemLang.LanguageID,
						Value = defaultValue
					});
				}
			}
			else
			{
				if (!string.IsNullOrEmpty(commonMultiLanguageViewModel.Value))
				{
					continue;
				}
				if (Enumerable.Any<CRMspSelectUserLanguages_Result>((IEnumerable<CRMspSelectUserLanguages_Result>)list2, (Func<CRMspSelectUserLanguages_Result, bool>)((CRMspSelectUserLanguages_Result c) => c.LanguageID == itemLang.LanguageID)))
				{
					if (isCurrentUserAllowCopyOtherLanguage)
					{
						commonMultiLanguageViewModel.Value = defaultValue;
					}
					else
					{
						result = false;
					}
				}
				else
				{
					commonMultiLanguageViewModel.Value = defaultValue;
				}
			}
		}
		return result;
	}

	public ImageFormat SetImageFormat(string fileName)
	{
		ImageFormat result = ImageFormat.Png;
		if (string.IsNullOrEmpty(fileName))
		{
			return result;
		}
		string[] array = fileName.Split(new char[1] { '.' });
		if (Enumerable.Any<string>((IEnumerable<string>)array) && array.Length == 2)
		{
			switch (array[1].ToLower())
			{
			case "jpeg":
			case "jpg":
				result = ImageFormat.Jpeg;
				break;
			case "png":
				result = ImageFormat.Png;
				break;
			case "gif":
				result = ImageFormat.Gif;
				break;
			case "tiff":
				result = ImageFormat.Tiff;
				break;
			case "bmp":
				result = ImageFormat.Bmp;
				break;
			default:
				result = ImageFormat.Png;
				break;
			}
		}
		return result;
	}

	public static bool ResizeImage(string orgFile, string resizedFile, ImageFormat format, int width, int height)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			Image val = Image.FromFile(orgFile);
			try
			{
				Bitmap val2 = new Bitmap(width, height, val.PixelFormat);
				Graphics obj = Graphics.FromImage((Image)val2);
				obj.CompositingQuality = (CompositingQuality)2;
				obj.SmoothingMode = (SmoothingMode)2;
				obj.InterpolationMode = (InterpolationMode)7;
				Rectangle val3 = default(Rectangle);
				((Rectangle)(ref val3))._002Ector(0, 0, width, height);
				obj.DrawImage(val, val3);
				((Image)val2).Save(resizedFile, format);
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
			return true;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return false;
		}
	}

	[AjaxOnly]
	public ActionResult _PartialSearchProduct(int prdFgroupId, int prdSgroupId, string barcode, string val, int prdId, int showMode)
	{
		base.ViewBag.prdSgroupId = prdSgroupId;
		base.ViewBag.prdFgroupId = prdFgroupId;
		base.ViewBag.barcode = barcode;
		base.ViewBag.val = val;
		base.ViewBag.prdId = prdId;
		base.ViewBag.showMode = showMode;
		return PartialView();
	}

	[AjaxOnly]
	public ActionResult SearchProduct_Read([DataSourceRequest] DataSourceRequest request, int prdFgroupId, int prdSgroupId, string barcode, string val, int prdId, int showMode)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSearchProducts_Result> list = new List<WSspSearchProducts_Result>();
		try
		{
			string text = "";
			if (prdId > 0 && prdSgroupId > 0)
			{
				WSspSelectProductsWithId_Result wSspSelectProductsWithId_Result = Enumerable.FirstOrDefault<WSspSelectProductsWithId_Result>((IEnumerable<WSspSelectProductsWithId_Result>)_db.WSspSelectProductsWithId(prdId, lCID, result));
				if (wSspSelectProductsWithId_Result != null)
				{
					text = ((!string.IsNullOrEmpty(wSspSelectProductsWithId_Result.PrdName)) ? wSspSelectProductsWithId_Result.PrdName : "");
				}
				val = text;
				prdId = 0;
				prdSgroupId = 0;
			}
			list = Enumerable.ToList<WSspSearchProducts_Result>((IEnumerable<WSspSearchProducts_Result>)_db.WSspSearchProducts(prdFgroupId, prdSgroupId, barcode, val, prdId, showMode, lCID, result, 0, -1, 0, 0, "", null));
			if (list != null && Enumerable.Any<WSspSearchProducts_Result>((IEnumerable<WSspSearchProducts_Result>)list))
			{
				foreach (WSspSearchProducts_Result item in list)
				{
					item.PrdLinkAccPrdCode = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccCodeWithComa(2, item.PrdLinkAccPrdCode);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[HttpPost]
	public JsonResult DeletePrdAllWithDep(int prdGroupId)
	{
		string text = "";
		string text2 = "";
		CommonResultStatusViewModel commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		CommonResultViewModel<string> data;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (!UserLogin.IsUserAccess("frmProducts", "actDeletePrdAllWithDep", UserLogin.CurrentUser))
			{
				text2 = Messages.ErrorNotAccess;
				text = "";
				data = new CommonResultViewModel<string>
				{
					Data = text,
					Message = Messages.ErrorNotAccess,
					Status = CommonResultStatusViewModel.Error
				};
				return Json(data, JsonRequestBehavior.AllowGet);
			}
			if (prdGroupId == 0)
			{
				text2 = Messages.ErrorNotAccess;
				text = "";
				data = new CommonResultViewModel<string>
				{
					Data = text,
					Message = Messages.msgErrorNotSelectGroup,
					Status = CommonResultStatusViewModel.Error
				};
				return Json(data, JsonRequestBehavior.AllowGet);
			}
			List<WSspSelectProdcutsFilesDirectoryByPrdGroupId_Result> list = Enumerable.ToList<WSspSelectProdcutsFilesDirectoryByPrdGroupId_Result>((IEnumerable<WSspSelectProdcutsFilesDirectoryByPrdGroupId_Result>)_dbI.WSspSelectProdcutsFilesDirectoryByPrdGroupId(prdGroupId, lCID, result));
			List<WSspSelectProductGalleryByPrdGroupId_Result> list2 = Enumerable.ToList<WSspSelectProductGalleryByPrdGroupId_Result>((IEnumerable<WSspSelectProductGalleryByPrdGroupId_Result>)_dbI.WSspSelectProductGalleryByPrdGroupId(prdGroupId));
			string text3 = "";
			text = "";
			List<WSspDeleteAllProductsWithDependencies_Result> list3 = Enumerable.ToList<WSspDeleteAllProductsWithDependencies_Result>((IEnumerable<WSspDeleteAllProductsWithDependencies_Result>)_dbI.WSspDeleteAllProductsWithDependencies(prdGroupId, lCID, result));
			if (list3 != null && Enumerable.Any<WSspDeleteAllProductsWithDependencies_Result>((IEnumerable<WSspDeleteAllProductsWithDependencies_Result>)list3))
			{
				text = "error";
				text3 = GetFileDeleteAllProductsWithDependencies(list3);
			}
			try
			{
				if ((list != null) & Enumerable.Any<WSspSelectProdcutsFilesDirectoryByPrdGroupId_Result>((IEnumerable<WSspSelectProdcutsFilesDirectoryByPrdGroupId_Result>)list))
				{
					foreach (WSspSelectProdcutsFilesDirectoryByPrdGroupId_Result item2 in list)
					{
						bool flag = true;
						if (list3 != null && Enumerable.Any<WSspDeleteAllProductsWithDependencies_Result>((IEnumerable<WSspDeleteAllProductsWithDependencies_Result>)list3) && Enumerable.FirstOrDefault<WSspDeleteAllProductsWithDependencies_Result>((IEnumerable<WSspDeleteAllProductsWithDependencies_Result>)list3, (Func<WSspDeleteAllProductsWithDependencies_Result, bool>)((WSspDeleteAllProductsWithDependencies_Result m) => m.ProductID == item2.PrdId.GetValueOrDefault())) != null)
						{
							flag = false;
						}
						if (flag)
						{
							new CompanyInfoController().DeleteFileByPath(item2.FilePath, item2.FileName, item2.FolderName);
						}
					}
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
			try
			{
				if ((list2 != null) & Enumerable.Any<WSspSelectProductGalleryByPrdGroupId_Result>((IEnumerable<WSspSelectProductGalleryByPrdGroupId_Result>)list2))
				{
					foreach (WSspSelectProductGalleryByPrdGroupId_Result item in list2)
					{
						bool flag2 = true;
						if (list3 != null && Enumerable.Any<WSspDeleteAllProductsWithDependencies_Result>((IEnumerable<WSspDeleteAllProductsWithDependencies_Result>)list3) && Enumerable.FirstOrDefault<WSspDeleteAllProductsWithDependencies_Result>((IEnumerable<WSspDeleteAllProductsWithDependencies_Result>)list3, (Func<WSspDeleteAllProductsWithDependencies_Result, bool>)((WSspDeleteAllProductsWithDependencies_Result m) => m.ProductID == item.PrdId)) != null)
						{
							flag2 = false;
						}
						if (flag2)
						{
							ProductdGalleryDeleteByPath(item.FilePath, item.FileName, item.FolderName);
						}
					}
				}
			}
			catch (Exception e2)
			{
				ErrorSignal.FromCurrentContext().Raise(e2);
			}
			if (!string.IsNullOrWhiteSpace(text3))
			{
				text2 = Messages.msgNotCompeleteSuccessAction;
				text2 = text2 + "<br><a href='" + text3 + "' class='link-excel-file'>" + Messages.msgLinkForDownloadFileWithError + "</a>";
			}
			else
			{
				text2 = Messages.msgSuccessAction;
			}
			commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		}
		catch (Exception e3)
		{
			ErrorSignal.FromCurrentContext().Raise(e3);
			text = "";
			text2 = Messages.msgErrorRunFunction;
			commonResultStatusViewModel = CommonResultStatusViewModel.Error;
		}
		data = new CommonResultViewModel<string>
		{
			Data = text,
			Message = text2,
			Status = commonResultStatusViewModel
		};
		JsonResult jsonResult = Json(data, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public string GetFileDeleteAllProductsWithDependencies(List<WSspDeleteAllProductsWithDependencies_Result> res)
	{
		//IL_0475: Unknown result type (might be due to invalid IL or missing references)
		//IL_0490: Unknown result type (might be due to invalid IL or missing references)
		string text = "";
		System.Guid.NewGuid().ToString();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			short.Parse(Financial.Get().Id.ToString());
			int userId = UserLogin.CurrentUser.UserId;
			if (res != null && Enumerable.Any<WSspDeleteAllProductsWithDependencies_Result>((IEnumerable<WSspDeleteAllProductsWithDependencies_Result>)res))
			{
				ExcelPackage excelPackage = new ExcelPackage();
				ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add(Labels.FileInfoExcelPropertiesTitle);
				int num = 0;
				int num2 = 1;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.PrdInfoExcelListPrdName;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.PrdInfoExcelListPrdCode;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.frmError;
				foreach (WSspDeleteAllProductsWithDependencies_Result re in res)
				{
					num2++;
					num = 0;
					num++;
					excelWorksheet.Cells[num2, num].Value = re.PrdName ?? "";
					num++;
					excelWorksheet.Cells[num2, num].Value = re.PrdCode ?? "";
					string text2 = "";
					string text3 = re.TypeError ?? "";
					if (!string.IsNullOrWhiteSpace(text3))
					{
						string[] array = text3.Split(new char[1] { '|' });
						if (array != null)
						{
							if (array[0] == "0")
							{
								text2 = Messages.msgErrorRunFunction;
							}
							else
							{
								if (text3.IndexOf("-1", StringComparison.Ordinal) >= 0)
								{
									text2 = text2 + Messages.msgErrorPrdUsedInPord + ", ";
								}
								if (text3.IndexOf("-2", StringComparison.Ordinal) >= 0)
								{
									text2 = text2 + "msgErrorPrdUsedInOrd".OrderMessages() + ", ";
								}
								if (text3.IndexOf("-3", StringComparison.Ordinal) >= 0)
								{
									text2 = text2 + Messages.msgErrorPrdUsedInBord + ", ";
								}
								if (text3.IndexOf("-4", StringComparison.Ordinal) >= 0)
								{
									text2 = text2 + Messages.msgErrorPrdUsedInDoc + ", ";
								}
								if (text3.IndexOf("-5", StringComparison.Ordinal) >= 0)
								{
									text2 += Messages.msgErrorPrdHasCost;
								}
								if (text3.IndexOf("-6", StringComparison.Ordinal) >= 0)
								{
									text2 += Messages.msgErrorPrdHasPrice;
								}
								if (text3.IndexOf("-7", StringComparison.Ordinal) >= 0)
								{
									text2 += Messages.msgErrorPrdHasStockSupply;
								}
							}
						}
					}
					num++;
					excelWorksheet.Cells[num2, num].Value = text2;
				}
				string text4 = base.Server.MapPath(Configuration.HostTempFilesPath) + "\\ReportProductInfo\\" + UserLogin.CurrentUser.UserId;
				string text5 = "CRM-Ideal-" + DateTime.Now.ToString("dd-MM-yyyy-hh-mm-ss") + ".xls";
				string path = text4 + "\\" + text5;
				try
				{
					DirectoryInfo directoryInfo = new DirectoryInfo(text4);
					FileInfo[] files = directoryInfo.GetFiles();
					for (int i = 0; i < files.Length; i++)
					{
						files[i].Delete();
					}
					DirectoryInfo[] directories = directoryInfo.GetDirectories();
					for (int i = 0; i < directories.Length; i++)
					{
						directories[i].Delete(recursive: true);
					}
					if (System.IO.Directory.Exists(text4))
					{
						System.IO.Directory.Delete(text4);
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
				}
				if (!System.IO.Directory.Exists(text4))
				{
					System.IO.Directory.CreateDirectory(text4);
					CRM.General.IO.Directory.SetFullControlForEveryOne(text4);
				}
				using (ExcelRange excelRange = excelWorksheet.Cells[1, 1, 1, num])
				{
					excelRange.Style.Font.Bold = true;
					excelRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
					excelRange.Style.Fill.BackgroundColor.SetColor(Color.DarkBlue);
					excelRange.Style.Font.Color.SetColor(Color.White);
				}
				excelPackage.Workbook.Properties.Title = Labels.FileInfoExcelPropertiesTitle;
				excelPackage.Workbook.Properties.Company = Labels.FileInfoExcelPropertiesCompany;
				Stream stream = System.IO.File.Create(path);
				excelPackage.SaveAs(stream);
				stream.Close();
				if (System.IO.File.Exists(path))
				{
					text = Configuration.HostTempFilesPath + "/ReportProductInfo/" + userId + "/" + text5;
					text = text.Replace("~/", "/");
					text = (text.StartsWith("/") ? text : ("/" + text));
				}
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return text;
	}

	[HttpPost]
	public JsonResult DeletePrdAllAndPriceWithDep(int prdGroupId)
	{
		string text = "";
		string text2 = "";
		CommonResultStatusViewModel commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		CommonResultViewModel<string> data;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (!UserLogin.IsUserAccess("frmProducts", "actDeletePrdAllAndPriceWithDep", UserLogin.CurrentUser))
			{
				text2 = Messages.ErrorNotAccess;
				text = "";
				data = new CommonResultViewModel<string>
				{
					Data = text,
					Message = Messages.ErrorNotAccess,
					Status = CommonResultStatusViewModel.Error
				};
				return Json(data, JsonRequestBehavior.AllowGet);
			}
			if (prdGroupId == 0)
			{
				text2 = Messages.ErrorNotAccess;
				text = "";
				data = new CommonResultViewModel<string>
				{
					Data = text,
					Message = Messages.msgErrorNotSelectGroup,
					Status = CommonResultStatusViewModel.Error
				};
				return Json(data, JsonRequestBehavior.AllowGet);
			}
			List<WSspSelectProdcutsFilesDirectoryByPrdGroupId_Result> list = Enumerable.ToList<WSspSelectProdcutsFilesDirectoryByPrdGroupId_Result>((IEnumerable<WSspSelectProdcutsFilesDirectoryByPrdGroupId_Result>)_dbI.WSspSelectProdcutsFilesDirectoryByPrdGroupId(prdGroupId, lCID, result));
			List<WSspSelectProductGalleryByPrdGroupId_Result> list2 = Enumerable.ToList<WSspSelectProductGalleryByPrdGroupId_Result>((IEnumerable<WSspSelectProductGalleryByPrdGroupId_Result>)_dbI.WSspSelectProductGalleryByPrdGroupId(prdGroupId));
			string text3 = "";
			text = "";
			List<WSspDeleteAllProductsAndPriceWithDependencies_Result> list3 = Enumerable.ToList<WSspDeleteAllProductsAndPriceWithDependencies_Result>((IEnumerable<WSspDeleteAllProductsAndPriceWithDependencies_Result>)_dbI.WSspDeleteAllProductsAndPriceWithDependencies(prdGroupId, lCID, result));
			if (list3 != null && Enumerable.Any<WSspDeleteAllProductsAndPriceWithDependencies_Result>((IEnumerable<WSspDeleteAllProductsAndPriceWithDependencies_Result>)list3))
			{
				text = "error";
				text3 = GetFileDeleteAllProductsAndPriceWithDependencies(list3);
			}
			try
			{
				if ((list != null) & Enumerable.Any<WSspSelectProdcutsFilesDirectoryByPrdGroupId_Result>((IEnumerable<WSspSelectProdcutsFilesDirectoryByPrdGroupId_Result>)list))
				{
					foreach (WSspSelectProdcutsFilesDirectoryByPrdGroupId_Result item2 in list)
					{
						bool flag = true;
						if (list3 != null && Enumerable.Any<WSspDeleteAllProductsAndPriceWithDependencies_Result>((IEnumerable<WSspDeleteAllProductsAndPriceWithDependencies_Result>)list3) && Enumerable.FirstOrDefault<WSspDeleteAllProductsAndPriceWithDependencies_Result>((IEnumerable<WSspDeleteAllProductsAndPriceWithDependencies_Result>)list3, (Func<WSspDeleteAllProductsAndPriceWithDependencies_Result, bool>)((WSspDeleteAllProductsAndPriceWithDependencies_Result m) => m.ProductID == item2.TypeOprObjectId.GetValueOrDefault())) != null)
						{
							flag = false;
						}
						if (flag)
						{
							new CompanyInfoController().DeleteFileByPath(item2.FilePath, item2.FileName, item2.FolderName);
						}
					}
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
			try
			{
				if ((list2 != null) & Enumerable.Any<WSspSelectProductGalleryByPrdGroupId_Result>((IEnumerable<WSspSelectProductGalleryByPrdGroupId_Result>)list2))
				{
					foreach (WSspSelectProductGalleryByPrdGroupId_Result item in list2)
					{
						bool flag2 = true;
						if (list3 != null && Enumerable.Any<WSspDeleteAllProductsAndPriceWithDependencies_Result>((IEnumerable<WSspDeleteAllProductsAndPriceWithDependencies_Result>)list3) && Enumerable.FirstOrDefault<WSspDeleteAllProductsAndPriceWithDependencies_Result>((IEnumerable<WSspDeleteAllProductsAndPriceWithDependencies_Result>)list3, (Func<WSspDeleteAllProductsAndPriceWithDependencies_Result, bool>)((WSspDeleteAllProductsAndPriceWithDependencies_Result m) => m.ProductID == item.PrdId)) != null)
						{
							flag2 = false;
						}
						if (flag2)
						{
							ProductdGalleryDeleteByPath(item.FilePath, item.FileName, item.FolderName);
						}
					}
				}
			}
			catch (Exception e2)
			{
				ErrorSignal.FromCurrentContext().Raise(e2);
			}
			if (!string.IsNullOrWhiteSpace(text3))
			{
				text2 = Messages.msgNotCompeleteSuccessAction;
				text2 = text2 + "<br><a href='" + text3 + "' class='link-excel-file'>" + Messages.msgLinkForDownloadFileWithError + "</a>";
			}
			else
			{
				text2 = Messages.msgSuccessAction;
			}
			commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		}
		catch (Exception e3)
		{
			ErrorSignal.FromCurrentContext().Raise(e3);
			text = "";
			text2 = Messages.msgErrorRunFunction;
			commonResultStatusViewModel = CommonResultStatusViewModel.Error;
		}
		data = new CommonResultViewModel<string>
		{
			Data = text,
			Message = text2,
			Status = commonResultStatusViewModel
		};
		JsonResult jsonResult = Json(data, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public string GetFileDeleteAllProductsAndPriceWithDependencies(List<WSspDeleteAllProductsAndPriceWithDependencies_Result> res)
	{
		//IL_0475: Unknown result type (might be due to invalid IL or missing references)
		//IL_0490: Unknown result type (might be due to invalid IL or missing references)
		string text = "";
		System.Guid.NewGuid().ToString();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			short.Parse(Financial.Get().Id.ToString());
			int userId = UserLogin.CurrentUser.UserId;
			if (res != null && Enumerable.Any<WSspDeleteAllProductsAndPriceWithDependencies_Result>((IEnumerable<WSspDeleteAllProductsAndPriceWithDependencies_Result>)res))
			{
				ExcelPackage excelPackage = new ExcelPackage();
				ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add(Labels.FileInfoExcelPropertiesTitle);
				int num = 0;
				int num2 = 1;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.PrdInfoExcelListPrdName;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.PrdInfoExcelListPrdCode;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.frmError;
				foreach (WSspDeleteAllProductsAndPriceWithDependencies_Result re in res)
				{
					num2++;
					num = 0;
					num++;
					excelWorksheet.Cells[num2, num].Value = re.PrdName ?? "";
					num++;
					excelWorksheet.Cells[num2, num].Value = re.PrdCode ?? "";
					string text2 = "";
					string text3 = re.TypeError ?? "";
					if (!string.IsNullOrWhiteSpace(text3))
					{
						string[] array = text3.Split(new char[1] { '|' });
						if (array != null)
						{
							if (array[0] == "0")
							{
								text2 = Messages.msgErrorRunFunction;
							}
							else
							{
								if (text3.IndexOf("-1", StringComparison.Ordinal) >= 0)
								{
									text2 = text2 + Messages.msgErrorPrdUsedInPord + ", ";
								}
								if (text3.IndexOf("-2", StringComparison.Ordinal) >= 0)
								{
									text2 = text2 + "msgErrorPrdUsedInOrd".OrderMessages() + ", ";
								}
								if (text3.IndexOf("-3", StringComparison.Ordinal) >= 0)
								{
									text2 = text2 + Messages.msgErrorPrdUsedInBord + ", ";
								}
								if (text3.IndexOf("-4", StringComparison.Ordinal) >= 0)
								{
									text2 = text2 + Messages.msgErrorPrdUsedInDoc + ", ";
								}
								if (text3.IndexOf("-5", StringComparison.Ordinal) >= 0)
								{
									text2 += Messages.msgErrorPrdHasCost;
								}
								if (text3.IndexOf("-6", StringComparison.Ordinal) >= 0)
								{
									text2 += Messages.msgErrorPrdHasPrice;
								}
								if (text3.IndexOf("-7", StringComparison.Ordinal) >= 0)
								{
									text2 += Messages.msgErrorPrdHasStockSupply;
								}
							}
						}
					}
					num++;
					excelWorksheet.Cells[num2, num].Value = text2;
				}
				string text4 = base.Server.MapPath(Configuration.HostTempFilesPath) + "\\ReportProductInfo\\" + UserLogin.CurrentUser.UserId;
				string text5 = "CRM-Ideal-" + DateTime.Now.ToString("dd-MM-yyyy-hh-mm-ss") + ".xls";
				string path = text4 + "\\" + text5;
				try
				{
					DirectoryInfo directoryInfo = new DirectoryInfo(text4);
					FileInfo[] files = directoryInfo.GetFiles();
					for (int i = 0; i < files.Length; i++)
					{
						files[i].Delete();
					}
					DirectoryInfo[] directories = directoryInfo.GetDirectories();
					for (int i = 0; i < directories.Length; i++)
					{
						directories[i].Delete(recursive: true);
					}
					if (System.IO.Directory.Exists(text4))
					{
						System.IO.Directory.Delete(text4);
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
				}
				if (!System.IO.Directory.Exists(text4))
				{
					System.IO.Directory.CreateDirectory(text4);
					CRM.General.IO.Directory.SetFullControlForEveryOne(text4);
				}
				using (ExcelRange excelRange = excelWorksheet.Cells[1, 1, 1, num])
				{
					excelRange.Style.Font.Bold = true;
					excelRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
					excelRange.Style.Fill.BackgroundColor.SetColor(Color.DarkBlue);
					excelRange.Style.Font.Color.SetColor(Color.White);
				}
				excelPackage.Workbook.Properties.Title = Labels.FileInfoExcelPropertiesTitle;
				excelPackage.Workbook.Properties.Company = Labels.FileInfoExcelPropertiesCompany;
				Stream stream = System.IO.File.Create(path);
				excelPackage.SaveAs(stream);
				stream.Close();
				if (System.IO.File.Exists(path))
				{
					text = Configuration.HostTempFilesPath + "/ReportProductInfo/" + userId + "/" + text5;
					text = text.Replace("~/", "/");
					text = (text.StartsWith("/") ? text : ("/" + text));
				}
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return text;
	}

	[HttpPost]
	public JsonResult DeletePrdWithDep(int prdId)
	{
		string text = "";
		string text2 = "";
		CommonResultStatusViewModel commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		CommonResultViewModel<string> data;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (!UserLogin.IsUserAccess("frmProducts", "actDeleteSinglePrdAllWithDep", UserLogin.CurrentUser))
			{
				text2 = Messages.ErrorNotAccess;
				text = "";
				data = new CommonResultViewModel<string>
				{
					Data = text,
					Message = Messages.ErrorNotAccess,
					Status = CommonResultStatusViewModel.Error
				};
				return Json(data, JsonRequestBehavior.AllowGet);
			}
			if (prdId == 0)
			{
				text2 = Messages.ErrorNotAccess;
				text = "";
				data = new CommonResultViewModel<string>
				{
					Data = text,
					Message = Messages.msgErrorNotSelectGroup,
					Status = CommonResultStatusViewModel.Error
				};
				return Json(data, JsonRequestBehavior.AllowGet);
			}
			List<WSspSelectProdcutFilesDirectory_Result> list = Enumerable.ToList<WSspSelectProdcutFilesDirectory_Result>((IEnumerable<WSspSelectProdcutFilesDirectory_Result>)_dbII.WSspSelectProdcutFilesDirectory(prdId, lCID, result));
			List<WSspSelectProductGallery_Result> list2 = Enumerable.ToList<WSspSelectProductGallery_Result>((IEnumerable<WSspSelectProductGallery_Result>)_db.WSspSelectProductGallery(prdId));
			text = "";
			mct_Result_StrII mct_Result_StrII = Enumerable.FirstOrDefault<mct_Result_StrII>((IEnumerable<mct_Result_StrII>)_dbII.WSspDeleteProductWithDependencies(prdId));
			if (mct_Result_StrII != null && !string.IsNullOrWhiteSpace(mct_Result_StrII.Result))
			{
				string[] array = mct_Result_StrII.Result.Split(new char[1] { '|' });
				if (array != null)
				{
					if (array[0] == "1")
					{
						try
						{
							if ((list != null) & Enumerable.Any<WSspSelectProdcutFilesDirectory_Result>((IEnumerable<WSspSelectProdcutFilesDirectory_Result>)list))
							{
								foreach (WSspSelectProdcutFilesDirectory_Result item in list)
								{
									new CompanyInfoController().DeleteFileByPath(item.FilePath, item.FileName, item.FolderName);
								}
							}
						}
						catch (Exception e)
						{
							ErrorSignal.FromCurrentContext().Raise(e);
						}
						try
						{
							if ((list2 != null) & Enumerable.Any<WSspSelectProductGallery_Result>((IEnumerable<WSspSelectProductGallery_Result>)list2))
							{
								foreach (WSspSelectProductGallery_Result item2 in list2)
								{
									ProductdGalleryDeleteByPath(item2.FilePath, item2.FileName, item2.FolderName);
								}
							}
						}
						catch (Exception e2)
						{
							ErrorSignal.FromCurrentContext().Raise(e2);
						}
						text2 = "";
					}
					else if (array[0] == "0")
					{
						text2 = Messages.msgErrorRunFunction;
					}
					else
					{
						string text3 = "";
						if (mct_Result_StrII.Result.IndexOf("-1", StringComparison.Ordinal) >= 0)
						{
							text3 = text3 + Messages.msgErrorPrdUsedInPord + "<br> ";
						}
						if (mct_Result_StrII.Result.IndexOf("-2", StringComparison.Ordinal) >= 0)
						{
							text3 = text3 + "msgErrorPrdUsedInOrd".OrderMessages() + "<br>  ";
						}
						if (mct_Result_StrII.Result.IndexOf("-3", StringComparison.Ordinal) >= 0)
						{
							text3 = text3 + Messages.msgErrorPrdUsedInBord + "<br>  ";
						}
						if (mct_Result_StrII.Result.IndexOf("-4", StringComparison.Ordinal) >= 0)
						{
							text3 = text3 + Messages.msgErrorPrdUsedInDoc + "<br>  ";
						}
						if (mct_Result_StrII.Result.IndexOf("-5", StringComparison.Ordinal) >= 0)
						{
							text3 = text3 + Messages.msgErrorPrdHasCost + "<br>  ";
						}
						if (mct_Result_StrII.Result.IndexOf("-6", StringComparison.Ordinal) >= 0)
						{
							text3 = text3 + Messages.msgErrorPrdHasPrice + "<br>  ";
						}
						if (mct_Result_StrII.Result.IndexOf("-7", StringComparison.Ordinal) >= 0)
						{
							text3 = text3 + Messages.msgErrorPrdHasStockSupply + "<br>  ";
						}
						text2 = text3;
					}
				}
			}
			if (!string.IsNullOrWhiteSpace(text2))
			{
				text = "-1";
				commonResultStatusViewModel = CommonResultStatusViewModel.Fail;
			}
			else
			{
				text = "1";
				text2 = Messages.msgSuccessAction;
				commonResultStatusViewModel = CommonResultStatusViewModel.Success;
			}
		}
		catch (Exception e3)
		{
			ErrorSignal.FromCurrentContext().Raise(e3);
			text = "-1";
			text2 = Messages.msgErrorRunFunction;
			commonResultStatusViewModel = CommonResultStatusViewModel.Error;
		}
		data = new CommonResultViewModel<string>
		{
			Data = text,
			Message = text2,
			Status = commonResultStatusViewModel
		};
		JsonResult jsonResult = Json(data, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[HttpPost]
	public JsonResult DeletePrdAndPriceWithDep(int prdId)
	{
		string text = "";
		string text2 = "";
		CommonResultStatusViewModel commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		CommonResultViewModel<string> data;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (!UserLogin.IsUserAccess("frmProducts", "actDeleteSinglePrdAllAndPriceWithDep", UserLogin.CurrentUser))
			{
				text2 = Messages.ErrorNotAccess;
				text = "";
				data = new CommonResultViewModel<string>
				{
					Data = text,
					Message = Messages.ErrorNotAccess,
					Status = CommonResultStatusViewModel.Error
				};
				return Json(data, JsonRequestBehavior.AllowGet);
			}
			if (prdId == 0)
			{
				text2 = Messages.ErrorNotAccess;
				text = "";
				data = new CommonResultViewModel<string>
				{
					Data = text,
					Message = Messages.msgErrorNotSelectGroup,
					Status = CommonResultStatusViewModel.Error
				};
				return Json(data, JsonRequestBehavior.AllowGet);
			}
			List<WSspSelectProdcutFilesDirectory_Result> list = Enumerable.ToList<WSspSelectProdcutFilesDirectory_Result>((IEnumerable<WSspSelectProdcutFilesDirectory_Result>)_dbII.WSspSelectProdcutFilesDirectory(prdId, lCID, result));
			List<WSspSelectProductGallery_Result> list2 = Enumerable.ToList<WSspSelectProductGallery_Result>((IEnumerable<WSspSelectProductGallery_Result>)_db.WSspSelectProductGallery(prdId));
			text = "";
			mct_Result_StrII mct_Result_StrII = Enumerable.FirstOrDefault<mct_Result_StrII>((IEnumerable<mct_Result_StrII>)_dbII.WSspDeleteProductAndPriceWithDependencies(prdId));
			if (mct_Result_StrII != null && !string.IsNullOrWhiteSpace(mct_Result_StrII.Result))
			{
				string[] array = mct_Result_StrII.Result.Split(new char[1] { '|' });
				if (array != null)
				{
					if (array[0] == "1")
					{
						try
						{
							if ((list != null) & Enumerable.Any<WSspSelectProdcutFilesDirectory_Result>((IEnumerable<WSspSelectProdcutFilesDirectory_Result>)list))
							{
								foreach (WSspSelectProdcutFilesDirectory_Result item in list)
								{
									new CompanyInfoController().DeleteFileByPath(item.FilePath, item.FileName, item.FolderName);
								}
							}
						}
						catch (Exception e)
						{
							ErrorSignal.FromCurrentContext().Raise(e);
						}
						try
						{
							if ((list2 != null) & Enumerable.Any<WSspSelectProductGallery_Result>((IEnumerable<WSspSelectProductGallery_Result>)list2))
							{
								foreach (WSspSelectProductGallery_Result item2 in list2)
								{
									ProductdGalleryDeleteByPath(item2.FilePath, item2.FileName, item2.FolderName);
								}
							}
						}
						catch (Exception e2)
						{
							ErrorSignal.FromCurrentContext().Raise(e2);
						}
						text2 = "";
					}
					else if (array[0] == "0")
					{
						text2 = Messages.msgErrorRunFunction;
					}
					else
					{
						string text3 = "";
						if (mct_Result_StrII.Result.IndexOf("-1", StringComparison.Ordinal) >= 0)
						{
							text3 = text3 + Messages.msgErrorPrdUsedInPord + "<br>  ";
						}
						if (mct_Result_StrII.Result.IndexOf("-2", StringComparison.Ordinal) >= 0)
						{
							text3 = text3 + "msgErrorPrdUsedInOrd".OrderMessages() + "<br>  ";
						}
						if (mct_Result_StrII.Result.IndexOf("-3", StringComparison.Ordinal) >= 0)
						{
							text3 = text3 + Messages.msgErrorPrdUsedInBord + "<br>  ";
						}
						if (mct_Result_StrII.Result.IndexOf("-4", StringComparison.Ordinal) >= 0)
						{
							text3 = text3 + Messages.msgErrorPrdUsedInDoc + "<br>  ";
						}
						if (mct_Result_StrII.Result.IndexOf("-5", StringComparison.Ordinal) >= 0)
						{
							text3 = text3 + Messages.msgErrorPrdHasCost + "<br>  ";
						}
						if (mct_Result_StrII.Result.IndexOf("-6", StringComparison.Ordinal) >= 0)
						{
							text3 = text3 + Messages.msgErrorPrdHasPrice + "<br>  ";
						}
						if (mct_Result_StrII.Result.IndexOf("-7", StringComparison.Ordinal) >= 0)
						{
							text3 = text3 + Messages.msgErrorPrdHasStockSupply + "<br>  ";
						}
						text2 = text3;
					}
				}
			}
			if (!string.IsNullOrWhiteSpace(text2))
			{
				text = "-1";
				commonResultStatusViewModel = CommonResultStatusViewModel.Fail;
			}
			else
			{
				text = "1";
				text2 = Messages.msgSuccessAction;
				commonResultStatusViewModel = CommonResultStatusViewModel.Success;
			}
		}
		catch (Exception e3)
		{
			ErrorSignal.FromCurrentContext().Raise(e3);
			text = "-1";
			text2 = Messages.msgErrorRunFunction;
			commonResultStatusViewModel = CommonResultStatusViewModel.Error;
		}
		data = new CommonResultViewModel<string>
		{
			Data = text,
			Message = text2,
			Status = commonResultStatusViewModel
		};
		JsonResult jsonResult = Json(data, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public bool ProductdGalleryDeleteByPath(string filePath, string fileName, string folderName)
	{
		bool result = false;
		if (!string.IsNullOrWhiteSpace(filePath) && !string.IsNullOrWhiteSpace(fileName) && !string.IsNullOrWhiteSpace(folderName))
		{
			try
			{
				string text = filePath.ToLower().Replace(Configuration.PathFtp.ToLower(), "");
				text = Configuration.MainDirectoryPath + Configuration.PrdDirectoryPath + folderName + "/" + fileName;
				FacadeFTP facadeFTP = new FacadeFTP(Configuration.FacadeFtp);
				string destination = text;
				if (facadeFTP.Delete(Configuration.PathFtp, Configuration.UserNameFtp, Configuration.PasswordFtp, fileName, destination, Configuration.UsePassiveFtp))
				{
					result = true;
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
		}
		return result;
	}

	[AjaxOnly]
	public JsonResult GetPrdModuleName()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			list = GetPrdModuleNameList();
			if (list == null)
			{
				list = new List<SelectListItem>();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public List<SelectListItem> GetPrdModuleNameList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			SelectListItem selectListItem = new SelectListItem();
			selectListItem = new SelectListItem
			{
				Text = Labels.PrdModuleNameVersionI,
				Value = "I-"
			};
			list.Add(selectListItem);
			selectListItem = new SelectListItem
			{
				Text = Labels.PrdModuleNameVersionII,
				Value = "II"
			};
			list.Add(selectListItem);
			selectListItem = new SelectListItem
			{
				Text = Labels.PrdModuleNameVersionIII,
				Value = "III"
			};
			list.Add(selectListItem);
			selectListItem = new SelectListItem
			{
				Text = Labels.PrdModuleNameVersionIV,
				Value = "IV"
			};
			list.Add(selectListItem);
			selectListItem = new SelectListItem
			{
				Text = Labels.PrdModuleNameVersionV,
				Value = "V"
			};
			list.Add(selectListItem);
			selectListItem = new SelectListItem
			{
				Text = Labels.PrdModuleNameVersionVI,
				Value = "VI"
			};
			list.Add(selectListItem);
			selectListItem = new SelectListItem
			{
				Text = Labels.PrdModuleNameVersionVII,
				Value = "VII"
			};
			list.Add(selectListItem);
			selectListItem = new SelectListItem
			{
				Text = Labels.PrdModuleNameVersionFUL,
				Value = "FUL"
			};
			list.Add(selectListItem);
			selectListItem = new SelectListItem
			{
				Text = Labels.PrdModuleNameCustomer,
				Value = "U"
			};
			list.Add(selectListItem);
			selectListItem = new SelectListItem
			{
				Text = Labels.PrdModuleNamePreOrder,
				Value = "P"
			};
			list.Add(selectListItem);
			selectListItem = new SelectListItem
			{
				Text = Labels.PrdModuleNameOrder,
				Value = "O"
			};
			list.Add(selectListItem);
			selectListItem = new SelectListItem
			{
				Text = Labels.PrdModuleNameWareHouse,
				Value = "W"
			};
			list.Add(selectListItem);
			selectListItem = new SelectListItem
			{
				Text = Labels.PrdModuleNameBuyOrder,
				Value = "B"
			};
			list.Add(selectListItem);
			selectListItem = new SelectListItem
			{
				Text = Labels.PrdModuleNameGSM,
				Value = "G"
			};
			list.Add(selectListItem);
			selectListItem = new SelectListItem
			{
				Text = Labels.PrdModuleNameSMS,
				Value = "S"
			};
			list.Add(selectListItem);
			selectListItem = new SelectListItem
			{
				Text = Labels.PrdModuleNameCallerId,
				Value = "C"
			};
			list.Add(selectListItem);
			selectListItem = new SelectListItem
			{
				Text = Labels.PrdModuleNameRecorder,
				Value = "R"
			};
			list.Add(selectListItem);
			selectListItem = new SelectListItem
			{
				Text = Labels.PrdModuleNameEmail,
				Value = "E"
			};
			list.Add(selectListItem);
			selectListItem = new SelectListItem
			{
				Text = Labels.PrdModuleNameAttachFile,
				Value = "F"
			};
			list.Add(selectListItem);
			selectListItem = new SelectListItem
			{
				Text = Labels.PrdModuleNameLetter,
				Value = "L"
			};
			list.Add(selectListItem);
			selectListItem = new SelectListItem
			{
				Text = Labels.PrdModuleNameProduct,
				Value = "K"
			};
			list.Add(selectListItem);
			selectListItem = new SelectListItem
			{
				Text = Labels.PrdModuleNameProductImportExcel,
				Value = "I"
			};
			list.Add(selectListItem);
			selectListItem = new SelectListItem
			{
				Text = Labels.PrdModuleNameProductExportExcel,
				Value = "X"
			};
			list.Add(selectListItem);
			selectListItem = new SelectListItem
			{
				Text = Labels.PrdModuleNameDyForm,
				Value = "D"
			};
			list.Add(selectListItem);
			selectListItem = new SelectListItem
			{
				Text = Labels.PrdModuleNameTelegram,
				Value = "T"
			};
			list.Add(selectListItem);
			selectListItem = new SelectListItem
			{
				Text = Labels.PrdModuleNamePayRoll,
				Value = "H"
			};
			list.Add(selectListItem);
			selectListItem = new SelectListItem
			{
				Text = Labels.PrdModuleNameFund,
				Value = "FUD"
			};
			list.Add(selectListItem);
			selectListItem = new SelectListItem
			{
				Text = Labels.PrdModuleNameLinkAcc,
				Value = "A"
			};
			list.Add(selectListItem);
			selectListItem = new SelectListItem
			{
				Text = Labels.PrdModuleNameUserPosition,
				Value = "URP"
			};
			list.Add(selectListItem);
			selectListItem = new SelectListItem
			{
				Text = Labels.PrdModuleNameCostsheet,
				Value = "CST"
			};
			list.Add(selectListItem);
			selectListItem = new SelectListItem
			{
				Text = Labels.PrdModuleNameIsDecimal,
				Value = "DEC"
			};
			list.Add(selectListItem);
			selectListItem = new SelectListItem
			{
				Text = Labels.PrdModuleNameCmpImportExcel,
				Value = "CIE"
			};
			list.Add(selectListItem);
			selectListItem = new SelectListItem
			{
				Text = Labels.PrdModuleNameOrdImportExcel,
				Value = "OIE"
			};
			list.Add(selectListItem);
			selectListItem = new SelectListItem
			{
				Text = Labels.PrdModuleNameDiscountCode,
				Value = "DC"
			};
			list.Add(selectListItem);
			selectListItem = new SelectListItem
			{
				Text = Labels.PrdModuleNameWareHouseUserPermission,
				Value = "WHUP"
			};
			list.Add(selectListItem);
			selectListItem = new SelectListItem
			{
				Text = Labels.PrdModuleNameIssueMultiDraftFromOrd,
				Value = "IMDocOrd"
			};
			list.Add(selectListItem);
			selectListItem = new SelectListItem
			{
				Text = Labels.PrdModuleNameVerificationWorkFlow,
				Value = "VerifyWrkflw"
			};
			list.Add(selectListItem);
			selectListItem = new SelectListItem
			{
				Text = Labels.PrdModuleNameMobAccessCmpDistance,
				Value = "MobAccCmpDistance"
			};
			list.Add(selectListItem);
			selectListItem = new SelectListItem
			{
				Text = Labels.PrdModuleNameSurvey,
				Value = "SUR"
			};
			list.Add(selectListItem);
			selectListItem = new SelectListItem
			{
				Text = Labels.PrdModuleNameMobFinancial,
				Value = "MobFinancial"
			};
			list.Add(selectListItem);
			selectListItem = new SelectListItem
			{
				Text = Labels.PrdModuleNameFoClub,
				Value = "FoClub"
			};
			list.Add(selectListItem);
			selectListItem = new SelectListItem
			{
				Text = Labels.PrdModuleNameFoShop,
				Value = "FoShop"
			};
			list.Add(selectListItem);
			selectListItem = new SelectListItem
			{
				Text = Labels.PrdModuleNameScore,
				Value = "SCO"
			};
			list.Add(selectListItem);
			selectListItem = new SelectListItem
			{
				Text = Labels.PrdModuleNameCommission,
				Value = "COM"
			};
			list.Add(selectListItem);
			selectListItem = new SelectListItem
			{
				Text = Labels.PrdModuleNameWhatsApp,
				Value = "WhtApp"
			};
			list.Add(selectListItem);
			selectListItem = new SelectListItem
			{
				Text = Labels.PrdModuleNameDyMenu,
				Value = "DyMenu"
			};
			list.Add(selectListItem);
			selectListItem = new SelectListItem
			{
				Text = Labels.PrdModuleNamePrdValidity,
				Value = "PrdValid"
			};
			list.Add(selectListItem);
			selectListItem = new SelectListItem
			{
				Text = Labels.PrdModuleNamePrdIVRLink,
				Value = "PrdIVR"
			};
			list.Add(selectListItem);
			selectListItem = new SelectListItem
			{
				Text = Labels.PrdModuleNameTicketPlus,
				Value = "TicketPlus"
			};
			list.Add(selectListItem);
			selectListItem = new SelectListItem
			{
				Text = Labels.PrdModuleNameSimpleTicket,
				Value = "SimpleTicket"
			};
			list.Add(selectListItem);
			selectListItem = new SelectListItem
			{
				Text = Labels.PrdModuleNameLetterNumberCounter,
				Value = "LtrNumCounter"
			};
			list.Add(selectListItem);
			selectListItem = new SelectListItem
			{
				Text = Labels.PrdModuleNameSmartTimeAttendance,
				Value = "SmartTmAttend"
			};
			list.Add(selectListItem);
			selectListItem = new SelectListItem
			{
				Text = Labels.PrdModuleNameCRMApi,
				Value = "CrmApi"
			};
			list.Add(selectListItem);
			selectListItem = new SelectListItem
			{
				Text = Labels.PrdModuleNameAPIVoip,
				Value = "APIVoip"
			};
			list.Add(selectListItem);
			selectListItem = new SelectListItem
			{
				Text = Labels.PrdModuleNamePordPlus,
				Value = "PordPlus"
			};
			list.Add(selectListItem);
			selectListItem = new SelectListItem
			{
				Text = Labels.PrdModuleNameBordPlus,
				Value = "BordPlus"
			};
			list.Add(selectListItem);
			selectListItem = new SelectListItem
			{
				Text = Labels.PrdModuleNameMobDyForm,
				Value = "MobDyForm"
			};
			list.Add(selectListItem);
			selectListItem = new SelectListItem
			{
				Text = Labels.PrdModuleNameCnvsStatusResult,
				Value = "CnvsStatusResult"
			};
			list.Add(selectListItem);
			selectListItem = new SelectListItem
			{
				Text = Labels.PrdModuleNameProjectProductHistory,
				Value = "PrjPrdHis"
			};
			list.Add(selectListItem);
			selectListItem = new SelectListItem
			{
				Text = Labels.PrdModuleNameLeave,
				Value = "Leave"
			};
			list.Add(selectListItem);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	public ActionResult SelectPrdModuleName()
	{
		base.ViewBag.ListModules = GetListPrdModuleNames();
		return View();
	}

	public List<PrdModuleNameViewModel> GetListPrdModuleNames()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<PrdModuleNameViewModel> list = new List<PrdModuleNameViewModel>();
		try
		{
			PrdModuleNameViewModel prdModuleNameViewModel = new PrdModuleNameViewModel();
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "Base",
				ModuleLabel = "Base",
				Module = "U",
				ModuleGroup = "CRM",
				OrderView = 10
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "ClientFromQty",
				ModuleLabel = "Client From Qty",
				Module = "ClientFromQty",
				ModuleGroup = "CRM",
				OrderView = 20,
				IsCnt = true
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "UserCount",
				ModuleLabel = "User Count",
				Module = "UserCount",
				ModuleGroup = "CRM",
				OrderView = 30,
				IsCnt = true
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "UserCountDeactive",
				ModuleLabel = "Active NoLogin",
				Module = "UserCountDeactive",
				ModuleGroup = "CRM",
				OrderView = 40,
				IsCnt = true
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "UserDeactiveFromQty",
				ModuleLabel = "Active NoLogin From Qty",
				Module = "UserDeactiveFromQty",
				ModuleGroup = "CRM",
				OrderView = 45,
				IsCnt = true
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "AttachFiles",
				ModuleLabel = "AttachFiles",
				Module = "F",
				ModuleGroup = "CRM",
				OrderView = 50
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "SMS",
				ModuleLabel = "SMS",
				Module = "S",
				ModuleGroup = "CRM",
				OrderView = 60
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "GSM",
				ModuleLabel = "GSM",
				Module = "G",
				ModuleGroup = "CRM",
				OrderView = 70
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "CallerId",
				ModuleLabel = "Caller ID",
				Module = "C",
				ModuleGroup = "CRM",
				OrderView = 80
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "VoipCount",
				ModuleLabel = "Voip Count",
				Module = "VoipCount",
				ModuleGroup = "CRM",
				OrderView = 81,
				IsCnt = true
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "VoipCntFromQty",
				ModuleLabel = "Voip Count From Qty",
				Module = "VoipCntFromQty",
				ModuleGroup = "CRM",
				OrderView = 82,
				IsCnt = true
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "VoipTrunkCount",
				ModuleLabel = "VoipTrunk Count",
				Module = "VoipTrunkCount",
				ModuleGroup = "CRM",
				OrderView = 83,
				IsCnt = true
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "VoipTrunkCntFromQty",
				ModuleLabel = "VoipTrunk Count From Qty",
				Module = "VoipTrunkCntFromQty",
				ModuleGroup = "CRM",
				OrderView = 84,
				IsCnt = true
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "Recorder",
				ModuleLabel = "Recorder",
				Module = "R",
				ModuleGroup = "CRM",
				OrderView = 85
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "Email",
				ModuleLabel = "Email",
				Module = "E",
				ModuleGroup = "CRM",
				OrderView = 90
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "Telegram",
				ModuleLabel = "Telegram",
				Module = "T",
				ModuleGroup = "CRM",
				OrderView = 100
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "WhatsApp",
				ModuleLabel = "WhatsApp",
				Module = "WhtApp",
				ModuleGroup = "CRM",
				OrderView = 110
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "Letters",
				ModuleLabel = "Letters",
				Module = "L",
				ModuleGroup = "CRM",
				OrderView = 120
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "LetterNumberCounter",
				ModuleLabel = "Letter Number Counter",
				Module = "LtrNumCounter",
				ModuleGroup = "CRM",
				OrderView = 130
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "DyForm",
				ModuleLabel = "DyForm",
				Module = "D",
				ModuleGroup = "CRM",
				OrderView = 140
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "Fund",
				ModuleLabel = "Fund",
				Module = "FUD",
				ModuleGroup = "CRM",
				OrderView = 150
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "PayRoll",
				ModuleLabel = "PayRoll",
				Module = "H",
				ModuleGroup = "CRM",
				OrderView = 160
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "Survey",
				ModuleLabel = "Survey",
				Module = "SUR",
				ModuleGroup = "CRM",
				OrderView = 170
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "Score",
				ModuleLabel = "Score",
				Module = "SCO",
				ModuleGroup = "CRM",
				OrderView = 180
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "UserPosition",
				ModuleLabel = "UserPosition",
				Module = "URP",
				ModuleGroup = "CRM",
				OrderView = 190
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "DyMenu",
				ModuleLabel = "DyMenu",
				Module = "DyMenu",
				ModuleGroup = "CRM",
				OrderView = 200
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "Leave",
				ModuleLabel = "Leave",
				Module = "Leave",
				ModuleGroup = "CRM",
				OrderView = 210
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "CnvsStatusResult",
				ModuleLabel = "BPMS",
				Module = "CnvsStatusResult",
				ModuleGroup = "CRM",
				OrderView = 220
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "LangCount",
				ModuleLabel = "Language Count",
				Module = "LangCount",
				ModuleGroup = "CRM",
				OrderView = 230,
				IsCnt = true
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "LangFromQty",
				ModuleLabel = "Lang From Qty",
				Module = "LangFromQty",
				ModuleGroup = "CRM",
				OrderView = 235,
				IsCnt = true
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "SmartTimeAttendance",
				ModuleLabel = "SmartTimeAttendance",
				Module = "SmartTmAttend",
				ModuleGroup = "CRM",
				OrderView = 240
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "UserCountHrm",
				ModuleLabel = "HRM Count",
				Module = "UserCountHrm",
				ModuleGroup = "CRM",
				OrderView = 250,
				IsCnt = true
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "HrmFromQty",
				ModuleLabel = "HRM From Qty",
				Module = "HrmFromQty",
				ModuleGroup = "CRM",
				OrderView = 255,
				IsCnt = true
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "MoneyBag",
				ModuleLabel = "Money Bag",
				Module = "MoneyBag",
				ModuleGroup = "CRM",
				OrderView = 270
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "UserCountCic",
				ModuleLabel = "CIC Count",
				Module = "UserCountCic",
				ModuleGroup = "CRM",
				OrderView = 280,
				IsCnt = true
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "CicFromQty",
				ModuleLabel = "CIC From Qty",
				Module = "CicFromQty",
				ModuleGroup = "CRM",
				OrderView = 285,
				IsCnt = true
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "ADLog",
				ModuleLabel = "AD Login",
				Module = "ADLog",
				ModuleGroup = "CRM",
				OrderView = 295
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "Outlook",
				ModuleLabel = "Link Outlook",
				Module = "Outlook",
				ModuleGroup = "CRM",
				OrderView = 305
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "Enterprise",
				ModuleLabel = "Enterprise",
				Module = "ENT",
				ModuleGroup = "CRM",
				OrderView = 315
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "ProductExportExcel",
				ModuleLabel = "Product Export Excel",
				Module = "X",
				ModuleGroup = "Excel",
				OrderView = 10
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "ProductImportExcel",
				ModuleLabel = "Product Import Excel",
				Module = "I",
				ModuleGroup = "Excel",
				OrderView = 20
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "CmpImportExcel",
				ModuleLabel = "Cmp Import Excel",
				Module = "CIE",
				ModuleGroup = "Excel",
				OrderView = 30
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "OrdImportExcel",
				ModuleLabel = "Ord Import Excel",
				Module = "OIE",
				ModuleGroup = "Excel",
				OrderView = 40
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "UserImportExcel",
				ModuleLabel = "User Import Excel",
				Module = "UIE",
				ModuleGroup = "Excel",
				OrderView = 50
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "Products",
				ModuleLabel = "Products",
				Module = "K",
				ModuleGroup = "FP",
				OrderView = 10
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "PrjPrdHistory",
				ModuleLabel = "PrjPrdHistory",
				Module = "PrjPrdHis",
				ModuleGroup = "FP",
				OrderView = 20
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "Pord",
				ModuleLabel = "Pord",
				Module = "P",
				ModuleGroup = "FP",
				OrderView = 30
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "PordPlus",
				ModuleLabel = "Pord (+)",
				Module = "PordPlus",
				ModuleGroup = "FP",
				OrderView = 40
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "Ord",
				ModuleLabel = "Ord",
				Module = "O",
				ModuleGroup = "FP",
				OrderView = 50
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "IssueMultiDraftFromOrd",
				ModuleLabel = "Ord (+)",
				Module = "IMDocOrd",
				ModuleGroup = "FP",
				OrderView = 60
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "OrdProfit",
				ModuleLabel = "Ord Profit",
				Module = "OrdProfit",
				ModuleGroup = "FP",
				OrderView = 70
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "Bord",
				ModuleLabel = "Bord",
				Module = "B",
				ModuleGroup = "FP",
				OrderView = 80
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "BordPlus",
				ModuleLabel = "Bord (+)",
				Module = "BordPlus",
				ModuleGroup = "FP",
				OrderView = 90
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "Wh",
				ModuleLabel = "Wh",
				Module = "W",
				ModuleGroup = "FP",
				OrderView = 100
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "WhCount",
				ModuleLabel = "Wh Count",
				Module = "WhCount",
				ModuleGroup = "FP",
				OrderView = 110,
				IsCnt = true
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "WhCountFromQty",
				ModuleLabel = "Wh Count From Qty",
				Module = "WhCountFromQty",
				ModuleGroup = "FP",
				OrderView = 120,
				IsCnt = true
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "WareHouseUserPermission",
				ModuleLabel = "Wh (+)",
				Module = "WHUP",
				ModuleGroup = "FP",
				OrderView = 130
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "AccLink",
				ModuleLabel = "AccLink",
				Module = "A",
				ModuleGroup = "FP",
				OrderView = 140
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "AccDbCount",
				ModuleLabel = "AccDb Count",
				Module = "AccDbCount",
				ModuleGroup = "FP",
				OrderView = 143,
				IsCnt = true
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "AccDbCntFromQty",
				ModuleLabel = "AccDb Count From Qty",
				Module = "AccDbCntFromQty",
				ModuleGroup = "FP",
				OrderView = 145,
				IsCnt = true
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "DiscountCode",
				ModuleLabel = "Discount Code",
				Module = "DC",
				ModuleGroup = "FP",
				OrderView = 150
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "IsDecimal",
				ModuleLabel = "IsDecimal",
				Module = "DEC",
				ModuleGroup = "FP",
				OrderView = 160
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "Commissions",
				ModuleLabel = "Commissions",
				Module = "COM",
				ModuleGroup = "FP",
				OrderView = 170
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "VerificationWorkFlow",
				ModuleLabel = "Verification Workflow",
				Module = "VerifyWrkflw",
				ModuleGroup = "FP",
				OrderView = 180
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "Costsheet",
				ModuleLabel = "Costsheet",
				Module = "CST",
				ModuleGroup = "FP",
				OrderView = 190
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "PrdValidity",
				ModuleLabel = "Prd Validity",
				Module = "PrdValid",
				ModuleGroup = "FP",
				OrderView = 200
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "PrdIVRLink",
				ModuleLabel = "Prd IVRLink",
				Module = "PrdIVR",
				ModuleGroup = "FP",
				OrderView = 210
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "Tsp",
				ModuleLabel = "TSP",
				Module = "Tsp",
				ModuleGroup = "FP",
				OrderView = 220
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "AutoCalcIssueBill",
				ModuleLabel = "AutoCalcIssueBillPrd",
				Module = "AutoCalcIssueBill",
				ModuleGroup = "FP",
				OrderView = 230
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "Stsup",
				ModuleLabel = "StockSupply",
				Module = "Stsup",
				ModuleGroup = "FP",
				OrderView = 240
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "DisSt",
				ModuleLabel = "Discount Strategy",
				Module = "DisSt",
				ModuleGroup = "FP",
				OrderView = 250
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "DisPol",
				ModuleLabel = "Discount Policy",
				Module = "DisPol",
				ModuleGroup = "FP",
				OrderView = 255
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "PrdSpec",
				ModuleLabel = "PrdSpec",
				Module = "PrdSpec",
				ModuleGroup = "FP",
				OrderView = 260
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "PrdAutoCalcPrice",
				ModuleLabel = "PrdAutoCalcPriceTelo",
				Module = "PrdAutoCalcPrice",
				ModuleGroup = "FP",
				OrderView = 270
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "WST",
				ModuleLabel = "SalesTarget",
				Module = "WST",
				ModuleGroup = "FP",
				OrderView = 280
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "FoClub",
				ModuleLabel = "FoClub",
				Module = "FoClub",
				ModuleGroup = "FO",
				OrderView = 10
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "FoShop",
				ModuleLabel = "FoShop",
				Module = "FoShop",
				ModuleGroup = "FO",
				OrderView = 120
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "TicketPlus",
				ModuleLabel = "Ticket Plus",
				Module = "TicketPlus",
				ModuleGroup = "FO",
				OrderView = 130
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "SimpleTicket",
				ModuleLabel = "Simple Ticket",
				Module = "SimpleTicket",
				ModuleGroup = "FO",
				OrderView = 135
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "OnlinePay",
				ModuleLabel = "Online Payment",
				Module = "OnlinePay",
				ModuleGroup = "FO",
				OrderView = 140
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "FoCount",
				ModuleLabel = "FO Count",
				Module = "FoCount",
				ModuleGroup = "FO",
				OrderView = 150,
				IsCnt = true
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "FoCntFromQty",
				ModuleLabel = "FO Count From Qty",
				Module = "FoCntFromQty",
				ModuleGroup = "FO",
				OrderView = 155,
				IsCnt = true
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "UserCountMob",
				ModuleLabel = "Mob Count",
				Module = "UserCountMob",
				ModuleGroup = "MOB",
				OrderView = 10,
				IsCnt = true
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "MobFromQty",
				ModuleLabel = "Mob From Qty",
				Module = "MobFromQty",
				ModuleGroup = "MOB",
				OrderView = 15,
				IsCnt = true
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "MobFinancial",
				ModuleLabel = "Mob Financial",
				Module = "MobFinancial",
				ModuleGroup = "MOB",
				OrderView = 20
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "MobDyForm",
				ModuleLabel = "MobDyForm",
				Module = "MobDyForm",
				ModuleGroup = "MOB",
				OrderView = 30
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "MobAccessCmpDistance",
				ModuleLabel = "Mob Access Cmp",
				Module = "MobAccCmpDistance",
				ModuleGroup = "MOB",
				OrderView = 40
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "UserCountCrmShop",
				ModuleLabel = "CRMShop Count",
				Module = "UserCountCrmShop",
				ModuleGroup = "MOB",
				OrderView = 50,
				IsCnt = true
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "CrmShopFromQty",
				ModuleLabel = "CRMShop From Qty",
				Module = "CrmShopFromQty",
				ModuleGroup = "MOB",
				OrderView = 60,
				IsCnt = true
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "CRMApi",
				ModuleLabel = "API",
				Module = "CrmApi",
				ModuleGroup = "API",
				OrderView = 10
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "CrmApiFRL",
				ModuleLabel = "API Full Register Lim",
				Module = "CrmApiFRL",
				ModuleGroup = "API",
				OrderView = 20
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "APIVoip",
				ModuleLabel = "API Voip",
				Module = "APIVoip",
				ModuleGroup = "API",
				OrderView = 30
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "Center",
				ModuleLabel = "Center",
				Module = "Center",
				ModuleGroup = "Center",
				OrderView = 10
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "CenterCount",
				ModuleLabel = "Center Count",
				Module = "CenterCount",
				ModuleGroup = "Center",
				OrderView = 20,
				IsCnt = true
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "CenterCntFromQty",
				ModuleLabel = "Center Count From Qty",
				Module = "CenterCntFromQty",
				ModuleGroup = "Center",
				OrderView = 30,
				IsCnt = true
			};
			list.Add(prdModuleNameViewModel);
			prdModuleNameViewModel = new PrdModuleNameViewModel
			{
				ModuleName = "AI",
				ModuleLabel = "AI",
				Module = "AI",
				ModuleGroup = "AI",
				OrderView = 10
			};
			list.Add(prdModuleNameViewModel);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	public JsonResult GetProductByModuleName(string moduleName)
	{
		string message = "";
		CommonResultStatusViewModel status = CommonResultStatusViewModel.Success;
		List<WSspSelectProductsByModuleName_Result> list = new List<WSspSelectProductsByModuleName_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (!string.IsNullOrWhiteSpace(moduleName))
			{
				list = Enumerable.ToList<WSspSelectProductsByModuleName_Result>((IEnumerable<WSspSelectProductsByModuleName_Result>)_dbI.WSspSelectProductsByModuleName(moduleName, lCID, result));
				if (list == null)
				{
					list = new List<WSspSelectProductsByModuleName_Result>();
					message = Messages.msgErrorCreateRegCodeSerialNumber;
					status = CommonResultStatusViewModel.Fail;
				}
				else
				{
					message = Messages.msgSuccessAction;
					status = CommonResultStatusViewModel.Success;
				}
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			list = null;
			message = Messages.msgErrorRunFunction + " " + ex.Message;
			status = CommonResultStatusViewModel.Error;
		}
		CommonResultViewModel<List<WSspSelectProductsByModuleName_Result>> data = new CommonResultViewModel<List<WSspSelectProductsByModuleName_Result>>
		{
			Data = list,
			Message = message,
			Status = status
		};
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetProjectTitleGroup()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		List<SelectListItem> list2 = new List<SelectListItem>();
		try
		{
			list = GetProjectTitleGroupI();
			list2 = GetProjectTitleGroupI();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PrdAutoCalcPordPrjTitleGroupList = list;
		base.ViewBag.PrdOrdIssuePrjTitleGroupList = list2;
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public List<SelectListItem> GetProjectTitleGroupI()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<CRMspSelectProjectTitleGroups_Result> list2 = Enumerable.ToList<CRMspSelectProjectTitleGroups_Result>((IEnumerable<CRMspSelectProjectTitleGroups_Result>)_dbI.CRMspSelectProjectTitleGroups(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectProjectTitleGroups_Result, SelectListItem>((IEnumerable<CRMspSelectProjectTitleGroups_Result>)list2, (Func<CRMspSelectProjectTitleGroups_Result, SelectListItem>)((CRMspSelectProjectTitleGroups_Result item) => new SelectListItem
			{
				Text = (item.ProjectTitleGroup ?? ""),
				Value = item.ProjectTitleGroupId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[AjaxOnly]
	public JsonResult GetProjectTitles()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		List<SelectListItem> list2 = new List<SelectListItem>();
		try
		{
			list = GetProjectTitlesI();
			list2 = GetProjectTitlesI();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PrdAutoCalcPordPrjTitleList = list;
		base.ViewBag.PrdOrdIssuePrjTitleList = list2;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public List<SelectListItem> GetProjectTitlesI()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<CRMspSelectProjectTitles_Result> list2 = Enumerable.ToList<CRMspSelectProjectTitles_Result>((IEnumerable<CRMspSelectProjectTitles_Result>)_db.CRMspSelectProjectTitles(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectProjectTitles_Result, SelectListItem>((IEnumerable<CRMspSelectProjectTitles_Result>)list2, (Func<CRMspSelectProjectTitles_Result, SelectListItem>)((CRMspSelectProjectTitles_Result item) => new SelectListItem
			{
				Text = (item.ProjectTitle ?? ""),
				Value = item.ProjectTitleID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[AjaxOnly]
	public JsonResult GetPrjCnvsStatusGroups()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		List<SelectListItem> list2 = new List<SelectListItem>();
		try
		{
			list = GetPrjCnvsStatusGroupsI();
			list2 = GetPrjCnvsStatusGroupsI();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PrdAutoCalcPordPrjCnvsStatusGrouplist = list;
		base.ViewBag.PrdOrdIssuePrjCnvsStatusGrouplist = list2;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public List<SelectListItem> GetPrjCnvsStatusGroupsI()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<CRMspSelectConversationStatusGroups_Result> list2 = Enumerable.ToList<CRMspSelectConversationStatusGroups_Result>((IEnumerable<CRMspSelectConversationStatusGroups_Result>)_db.CRMspSelectConversationStatusGroups(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectConversationStatusGroups_Result, SelectListItem>((IEnumerable<CRMspSelectConversationStatusGroups_Result>)list2, (Func<CRMspSelectConversationStatusGroups_Result, SelectListItem>)((CRMspSelectConversationStatusGroups_Result item) => new SelectListItem
			{
				Text = item.ConversationStatusGroup,
				Value = item.ConversationStatusGroupID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[AjaxOnly]
	public JsonResult GetCnvsTopic()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<CRMspSelectConversationTopics_Result> list2 = Enumerable.ToList<CRMspSelectConversationTopics_Result>((IEnumerable<CRMspSelectConversationTopics_Result>)_db.CRMspSelectConversationTopics(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectConversationTopics_Result, SelectListItem>((IEnumerable<CRMspSelectConversationTopics_Result>)list2, (Func<CRMspSelectConversationTopics_Result, SelectListItem>)((CRMspSelectConversationTopics_Result item) => new SelectListItem
			{
				Text = item.Topic,
				Value = item.ConversationTopicsID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PrdAutoCalcPordCnvsTopicList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetCnvsStatusList(int statusGroupId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<CRMspSelectConversationStatus_Result> list2 = Enumerable.ToList<CRMspSelectConversationStatus_Result>((IEnumerable<CRMspSelectConversationStatus_Result>)_db.CRMspSelectConversationStatus(statusGroupId, lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectConversationStatus_Result, SelectListItem>((IEnumerable<CRMspSelectConversationStatus_Result>)list2, (Func<CRMspSelectConversationStatus_Result, SelectListItem>)((CRMspSelectConversationStatus_Result item) => new SelectListItem
			{
				Text = ((!string.IsNullOrEmpty(item.Status)) ? item.Status : "") + (item.ProgressPercent.HasValue ? (" |" + Labels.cnvsPercentStatus + ": " + item.ProgressPercent) : "") + ((!string.IsNullOrEmpty(item.StatusDesc)) ? (" |" + Labels.cnvsDescStatus + ": " + item.StatusDesc) : ""),
				Value = item.ConversationStatusID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PrdAutoPordCnvsStatusList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetCnvsStatusResult(int cnvsStatusId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<CRMspSelectActiveConversationStatusResult_Result> list2 = Enumerable.ToList<CRMspSelectActiveConversationStatusResult_Result>((IEnumerable<CRMspSelectActiveConversationStatusResult_Result>)_dbI.CRMspSelectActiveConversationStatusResult(cnvsStatusId, lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectActiveConversationStatusResult_Result, SelectListItem>((IEnumerable<CRMspSelectActiveConversationStatusResult_Result>)list2, (Func<CRMspSelectActiveConversationStatusResult_Result, SelectListItem>)((CRMspSelectActiveConversationStatusResult_Result item) => new SelectListItem
			{
				Text = (item.ResultTitle ?? ""),
				Value = item.ConversationStatusResultId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetReferUserActive()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		List<SelectListItem> list2 = new List<SelectListItem>();
		try
		{
			list = GetReferUserActiveI();
			list2 = GetReferUserActiveII();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PordReferUserList = list;
		base.ViewBag.PrdAutoCalcPordCnvsReferUserList = list2;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public List<SelectListItem> GetReferUserActiveI()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<CRMspSelectActiveUsers_Result> list2 = Enumerable.ToList<CRMspSelectActiveUsers_Result>((IEnumerable<CRMspSelectActiveUsers_Result>)_db.CRMspSelectActiveUsers(lCID, result, 0));
			list.Add(new SelectListItem
			{
				Text = Labels.PrdCmpReferUserId,
				Value = "-1",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.PrdCmpSuppUserId,
				Value = "-2",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = "--------------------",
				Value = "0",
				Selected = false
			});
			list.AddRange(Enumerable.Select<CRMspSelectActiveUsers_Result, SelectListItem>((IEnumerable<CRMspSelectActiveUsers_Result>)list2, (Func<CRMspSelectActiveUsers_Result, SelectListItem>)((CRMspSelectActiveUsers_Result item) => new SelectListItem
			{
				Text = item.Name,
				Value = item.UserId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	public List<SelectListItem> GetReferUserActiveII()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<CRMspSelectActiveUsers_Result> list2 = Enumerable.ToList<CRMspSelectActiveUsers_Result>((IEnumerable<CRMspSelectActiveUsers_Result>)_db.CRMspSelectActiveUsers(lCID, result, 0));
			list.Add(new SelectListItem
			{
				Text = Labels.PrdCmpReferUserId,
				Value = "-1",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.PrdCmpSuppUserId,
				Value = "-2",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.PrdPordReferUser,
				Value = "-3",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.PrdIndicatorValidityReferUser,
				Value = "-4",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = "--------------------",
				Value = "0",
				Selected = false
			});
			list.AddRange(Enumerable.Select<CRMspSelectActiveUsers_Result, SelectListItem>((IEnumerable<CRMspSelectActiveUsers_Result>)list2, (Func<CRMspSelectActiveUsers_Result, SelectListItem>)((CRMspSelectActiveUsers_Result item) => new SelectListItem
			{
				Text = item.Name,
				Value = item.UserId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[AjaxOnly]
	public JsonResult GetOrderOpr()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<WSspSelectOrderOpr_Result> list2 = Order.SelectOrderOpr();
			if (list2 != null)
			{
				list.AddRange(Enumerable.Select<WSspSelectOrderOpr_Result, SelectListItem>((IEnumerable<WSspSelectOrderOpr_Result>)list2, (Func<WSspSelectOrderOpr_Result, SelectListItem>)((WSspSelectOrderOpr_Result item) => new SelectListItem
				{
					Text = item.Name,
					Value = item.OrderOprID.ToString(),
					Selected = false
				})));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PrdAutoCalcIssueOrdFromIndexedOprList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetPordDefSetting()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		List<SelectListItem> list2 = new List<SelectListItem>();
		try
		{
			list = GetPordDefSettingI();
			list2 = GetPordDefSettingI();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PordTaxDefSettingList = list;
		base.ViewBag.PordNoTaxDefSettingList = list2;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public List<SelectListItem> GetPordDefSettingI()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			_ = UserLogin.CurrentUser.UserId;
			List<WSspSelectPreOrderDefaultSettingPublic_Result> list2 = Enumerable.ToList<WSspSelectPreOrderDefaultSettingPublic_Result>((IEnumerable<WSspSelectPreOrderDefaultSettingPublic_Result>)_dbI.WSspSelectPreOrderDefaultSettingPublic(lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectPreOrderDefaultSettingPublic_Result, SelectListItem>((IEnumerable<WSspSelectPreOrderDefaultSettingPublic_Result>)list2, (Func<WSspSelectPreOrderDefaultSettingPublic_Result, SelectListItem>)((WSspSelectPreOrderDefaultSettingPublic_Result item) => new SelectListItem
			{
				Text = item.SettingTitle,
				Value = item.PreOrderSettingID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[AjaxOnly]
	public JsonResult GetCompanyType()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<CRMspSelectCompanyType_Result> list2 = Enumerable.ToList<CRMspSelectCompanyType_Result>((IEnumerable<CRMspSelectCompanyType_Result>)_db.CRMspSelectCompanyType(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectCompanyType_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyType_Result>)list2, (Func<CRMspSelectCompanyType_Result, SelectListItem>)((CRMspSelectCompanyType_Result item) => new SelectListItem
			{
				Text = item.CompanyTypeName,
				Value = item.CompanyTypeID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PrdOrdIssueUpdateCmpTypeList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetCompanyGroupII()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		List<SelectListItem> list2 = new List<SelectListItem>();
		try
		{
			list = GetCompanyGroupIIList();
			list2 = GetCompanyGroupIIList();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PrdOrdIssueTaxCmpGroupIIList = list;
		base.ViewBag.PrdOrdIssueNoTaxCmpGroupIIList = list2;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public List<SelectListItem> GetCompanyGroupIIList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			_ = UserLogin.CurrentUser.UserId;
			List<CRMspSelectCompanyGroupsII_Result> list2 = Enumerable.ToList<CRMspSelectCompanyGroupsII_Result>((IEnumerable<CRMspSelectCompanyGroupsII_Result>)_db.CRMspSelectCompanyGroupsII(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectCompanyGroupsII_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyGroupsII_Result>)list2, (Func<CRMspSelectCompanyGroupsII_Result, SelectListItem>)((CRMspSelectCompanyGroupsII_Result item) => new SelectListItem
			{
				Text = item.GroupIIName,
				Value = item.CompanyGroupIIID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[AjaxOnly]
	public JsonResult SearchProducts(string text = "", int showMode = 0, int prdKind = 0, int companyId = 0, int projectId = 0)
	{
		List<WSspSearchProducts_Result> list = new List<WSspSearchProducts_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (!string.IsNullOrWhiteSpace(text))
			{
				list = Enumerable.ToList<WSspSearchProducts_Result>(Enumerable.Take<WSspSearchProducts_Result>((IEnumerable<WSspSearchProducts_Result>)_db.WSspSearchProducts(0, 0, text, text, 0, showMode, lCID, result, prdKind, 0, companyId, projectId, "", null), 800));
				foreach (WSspSearchProducts_Result item in list)
				{
					item.PrdLinkAccPrdCode = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccCodeWithComa(2, item.PrdLinkAccPrdCode);
					item.PrdLinkAccPrdIdStr = item.PName + "|" + item.PrdCode + "|" + item.PrdModel + "|" + item.PrdLatinName + "|" + item.PrdBarcode + "|" + item.PrdFirstBarcode + "|" + item.PrdLinkAccPrdCode + "|";
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult SearchProductAutoCalcIndexed(string text = "", int showMode = 0, int prdKind = 0, int companyId = 0, int projectId = 0)
	{
		List<WSspSearchProductAutoCalcIndexed_Result> list = new List<WSspSearchProductAutoCalcIndexed_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (!string.IsNullOrWhiteSpace(text))
			{
				list = Enumerable.ToList<WSspSearchProductAutoCalcIndexed_Result>(Enumerable.Take<WSspSearchProductAutoCalcIndexed_Result>((IEnumerable<WSspSearchProductAutoCalcIndexed_Result>)_dbI.WSspSearchProductAutoCalcIndexed(text, 0, lCID, result), 800));
				foreach (WSspSearchProductAutoCalcIndexed_Result item in list)
				{
					item.PrdLinkAccPrdCode = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccCodeWithComa(2, item.PrdLinkAccPrdCode);
					item.PrdLinkAccPrdIdStr = item.PName + "|" + item.PrdCode + "|" + item.PrdModel + "|" + item.PrdLatinName + "|" + item.PrdBarcode + "|" + item.PrdFirstBarcode + "|" + item.PrdLinkAccPrdCode + "|";
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public ActionResult AddPatternToCnvsDesc(string formName, string itemName, string itemType)
	{
		base.ViewBag.FormName = formName;
		base.ViewBag.ItemName = itemName;
		base.ViewBag.ItemType = itemType;
		return View();
	}

	public List<WSspSelectSaleCenters_Result> SelectSaleCenters()
	{
		List<WSspSelectSaleCenters_Result> list = new List<WSspSelectSaleCenters_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			list = Enumerable.ToList<WSspSelectSaleCenters_Result>((IEnumerable<WSspSelectSaleCenters_Result>)_db.WSspSelectSaleCenters(lCID, result));
			if (list == null)
			{
				list = new List<WSspSelectSaleCenters_Result>();
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return list;
	}

	[HttpPost]
	[LoginAuthorize]
	public string SelectSaleCentersJs()
	{
		return JsonConvert.SerializeObject(SelectSaleCenters());
	}

	[AjaxOnly]
	public JsonResult GetProjectTitleInfo(int prjTitleId)
	{
		_003C_003Ec__DisplayClass96_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass96_0();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		CS_0024_003C_003E8__locals0.result = new CRMspSelectProjectTitlesById_Result();
		try
		{
			CS_0024_003C_003E8__locals0.result = Enumerable.FirstOrDefault<CRMspSelectProjectTitlesById_Result>((IEnumerable<CRMspSelectProjectTitlesById_Result>)_dbI.CRMspSelectProjectTitlesById(prjTitleId, CS_0024_003C_003E8__locals0.currLangID, result));
			if (CS_0024_003C_003E8__locals0.result != null)
			{
				DbSet<CrmProjectTitles_Lang> crmProjectTitles_Lang = _dbTbl.CrmProjectTitles_Lang;
				ParameterExpression val = Expression.Parameter(typeof(CrmProjectTitles_Lang), "c");
				List<CrmProjectTitles_Lang> list = Enumerable.ToList<CrmProjectTitles_Lang>((IEnumerable<CrmProjectTitles_Lang>)Queryable.Where<CrmProjectTitles_Lang>((IQueryable<CrmProjectTitles_Lang>)crmProjectTitles_Lang, Expression.Lambda<Func<CrmProjectTitles_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass96_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
				List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
				if (list != null)
				{
					list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmProjectTitles_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmProjectTitles_Lang>)list, (Func<CrmProjectTitles_Lang, CommonMultiLanguageViewModel>)((CrmProjectTitles_Lang item) => new CommonMultiLanguageViewModel
					{
						Value = item.PrjPostFix,
						LanguageId = item.LanguageID
					})));
				}
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals0.result.PrjPostFix,
					LanguageId = result
				});
				CS_0024_003C_003E8__locals0.result.PrjPostFix = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
				CS_0024_003C_003E8__locals0.result.AppType = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(CS_0024_003C_003E8__locals0.result, JsonRequestBehavior.AllowGet);
	}

	[LoginAuthorize]
	public ActionResult CompressPictures()
	{
		return View();
	}

	[HttpPost]
	[LoginAuthorize]
	public string CompressPictures(int fgId = 0, int sgId = 0)
	{
		return "";
	}

	public void DeleteOldPrdFromFtp(string filePath)
	{
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			new FilesManager();
			string pathFtp = Configuration.PathFtp;
			string userNameFtp = Configuration.UserNameFtp;
			string passwordFtp = Configuration.PasswordFtp;
			_ = Configuration.UsePassiveFtp;
			bool flag = !string.IsNullOrEmpty(pathFtp) && !string.IsNullOrEmpty(userNameFtp) && !string.IsNullOrEmpty(passwordFtp);
			string pathFtpFo = Configuration.PathFtpFo;
			string userNameFtpFo = Configuration.UserNameFtpFo;
			string passwordFtpFo = Configuration.PasswordFtpFo;
			bool usePassiveFtpFo = Configuration.UsePassiveFtpFo;
			bool flag2 = !string.IsNullOrEmpty(pathFtpFo) && !string.IsNullOrEmpty(userNameFtpFo) && !string.IsNullOrEmpty(passwordFtpFo);
			string text = "";
			string[] array = filePath.Split(new char[1] { '/' });
			if (array != null && array.Length != 0)
			{
				text = array[^1];
			}
			if (string.IsNullOrWhiteSpace(filePath) || string.IsNullOrWhiteSpace(text))
			{
				return;
			}
			if (flag)
			{
				new FacadeFTP(Configuration.FacadeFtp);
				filePath.ToLower();
				string text2 = filePath.ToLower().Replace(pathFtp.ToLower(), "");
				text2 = text2.Replace(Configuration.MainDirectoryPath.ToLower(), "/");
				text2 = text2;
				text2 = base.Server.MapPath(text2);
				if (System.IO.File.Exists(text2))
				{
					System.IO.File.Delete(text2);
				}
				if (!string.IsNullOrWhiteSpace(text))
				{
					string text3 = "";
					string[] array2 = text.Split(new char[1] { '.' });
					if (array2 != null && array2.Length != 0)
					{
						text3 = text.Replace("." + array2[^1], "");
						text3 = text3 + "-Thumb." + array2[^1];
					}
					if (!string.IsNullOrWhiteSpace(text3))
					{
						string text4 = text2;
						text4 = text4.Replace(text, text3);
						if (System.IO.File.Exists(text4))
						{
							System.IO.File.Delete(text4);
						}
					}
				}
			}
			if (!flag2)
			{
				return;
			}
			FacadeFTP facadeFTP = new FacadeFTP(Configuration.FacadeFtpFo);
			string text5 = filePath.ToLower().Replace(pathFtp.ToLower(), "");
			text5 = text5.Replace(Configuration.MainDirectoryPath.ToLower(), "/");
			text5 = text5;
			text5 = text5.Replace("~", "").ToLower();
			facadeFTP.Delete(pathFtpFo, userNameFtpFo, passwordFtpFo, text, text5, usePassiveFtpFo);
			if (!string.IsNullOrWhiteSpace(text))
			{
				string text6 = "";
				string[] array3 = text.Split(new char[1] { '.' });
				if (array3 != null && array3.Length != 0)
				{
					text6 = text.Replace("." + array3[^1], "");
					text6 = text6 + "-Thumb." + array3[^1];
				}
				if (!string.IsNullOrWhiteSpace(text6))
				{
					string text7 = text5;
					text7 = text7.Replace(text, text6);
					facadeFTP.Delete(pathFtpFo, userNameFtpFo, passwordFtpFo, text6, text7, usePassiveFtpFo);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		_dbLink.Dispose();
		_dbI.Dispose();
		_dbII.Dispose();
		base.Dispose(disposing);
	}

	public ActionResult PrdDefQuantity(int prdId)
	{
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmProducts", ActionName = "actSavePrdPrice")]
	public ActionResult ProductsPrice(int prdId = 0, int sgId = 0, int prdPricegroupId = 0)
	{
		FillDropdownProductPrice();
		base.ViewBag.prdId = prdId;
		base.ViewBag.sgId = sgId;
		base.ViewBag.PrdPricegroupId = prdPricegroupId;
		return View();
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmProducts", ActionName = "actSavePrdPrice,actSavePrdCost")]
	public JsonResult GetProduct(int currentId, int sgId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int? centerId = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId : null);
		CurrentProductViewModel currentProductViewModel = new CurrentProductViewModel();
		try
		{
			List<WSspSelectProductByGroup_Result> list = Enumerable.ToList<WSspSelectProductByGroup_Result>((IEnumerable<WSspSelectProductByGroup_Result>)_dbI.WSspSelectProductByGroup(sgId, lCID, result, centerId));
			if (Enumerable.Any<WSspSelectProductByGroup_Result>((IEnumerable<WSspSelectProductByGroup_Result>)list))
			{
				currentProductViewModel.IsFind = true;
				currentProductViewModel.Message = "";
				currentProductViewModel.NextId = -1;
				currentProductViewModel.PreviousId = -1;
				currentProductViewModel.SgId = sgId;
				currentProductViewModel.FirstId = -1;
				currentProductViewModel.LastId = -1;
				if (list.Count == 1)
				{
					currentProductViewModel.FirstId = -1;
					currentProductViewModel.LastId = -1;
				}
				else
				{
					currentProductViewModel.FirstId = Enumerable.FirstOrDefault<WSspSelectProductByGroup_Result>((IEnumerable<WSspSelectProductByGroup_Result>)list).ProductID;
					currentProductViewModel.LastId = Enumerable.LastOrDefault<WSspSelectProductByGroup_Result>((IEnumerable<WSspSelectProductByGroup_Result>)list).ProductID;
				}
				WSspSelectProductByGroup_Result currItem;
				if (currentId > 0)
				{
					currItem = list.Find((WSspSelectProductByGroup_Result c) => c.ProductID == currentId);
				}
				else
				{
					currItem = Enumerable.LastOrDefault<WSspSelectProductByGroup_Result>((IEnumerable<WSspSelectProductByGroup_Result>)list);
				}
				if (currItem != null)
				{
					currentProductViewModel.Product = currItem;
					currentProductViewModel.CurrentId = currItem.ProductID;
					string text = "";
					WSspSelectWSProductSecondGroup_Result sGroup = Enumerable.FirstOrDefault<WSspSelectWSProductSecondGroup_Result>((IEnumerable<WSspSelectWSProductSecondGroup_Result>)Enumerable.ToList<WSspSelectWSProductSecondGroup_Result>((IEnumerable<WSspSelectWSProductSecondGroup_Result>)_db.WSspSelectWSProductSecondGroup(lCID, result, 0)), (Func<WSspSelectWSProductSecondGroup_Result, bool>)((WSspSelectWSProductSecondGroup_Result m) => m.PrdSecondGroupID == currItem.PrdGroupID));
					if (sGroup != null)
					{
						text = ((!string.IsNullOrEmpty(sGroup.SGName)) ? sGroup.SGName : "");
						WSspSelectProductFirstGroup_Result wSspSelectProductFirstGroup_Result = Enumerable.FirstOrDefault<WSspSelectProductFirstGroup_Result>((IEnumerable<WSspSelectProductFirstGroup_Result>)_db.WSspSelectProductFirstGroup(lCID, result), (Func<WSspSelectProductFirstGroup_Result, bool>)((WSspSelectProductFirstGroup_Result m) => m.PrdFirstGroupID == sGroup.FirstGroupId));
						if (wSspSelectProductFirstGroup_Result != null)
						{
							text = ((!string.IsNullOrEmpty(wSspSelectProductFirstGroup_Result.FGName)) ? wSspSelectProductFirstGroup_Result.FGName : "") + " - " + text;
						}
					}
					currentProductViewModel.PrdGName = text;
					if (list.Count == 1)
					{
						currentProductViewModel.NextId = -1;
						currentProductViewModel.PreviousId = -1;
					}
					else
					{
						WSspSelectProductByGroup_Result next = Lists.GetNext(list, currItem);
						if (next != null)
						{
							currentProductViewModel.NextId = next.ProductID;
						}
						WSspSelectProductByGroup_Result previous = Lists.GetPrevious(list, currItem);
						if (previous != null)
						{
							currentProductViewModel.PreviousId = previous.ProductID;
						}
					}
				}
				else
				{
					currentProductViewModel.IsFind = false;
					currentProductViewModel.Message = Messages.ErrorNotFound;
					currentProductViewModel.Product = null;
					currentProductViewModel.CurrentId = -1;
					currentProductViewModel.NextId = -1;
					currentProductViewModel.PreviousId = -1;
					currentProductViewModel.SgId = sgId;
					currentProductViewModel.FirstId = -1;
					currentProductViewModel.LastId = -1;
					currentProductViewModel.PrdGName = "";
				}
			}
			else
			{
				currentProductViewModel.IsFind = false;
				currentProductViewModel.Message = Messages.ErrorNotFound;
				currentProductViewModel.Product = null;
				currentProductViewModel.CurrentId = -1;
				currentProductViewModel.NextId = -1;
				currentProductViewModel.PreviousId = -1;
				currentProductViewModel.SgId = sgId;
				currentProductViewModel.FirstId = -1;
				currentProductViewModel.LastId = -1;
				currentProductViewModel.PrdGName = "";
			}
		}
		catch (DbEntityValidationException ex)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)ex);
			currentProductViewModel.Message = Messages.frmErrorMessage + "<br />" + ((Exception)(object)ex).Message;
		}
		catch (Exception ex2)
		{
			ErrorSignal.FromCurrentContext().Raise(ex2);
			currentProductViewModel.Message = Messages.frmErrorMessage + "<br />" + ex2.Message;
		}
		return Json(currentProductViewModel, JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmProducts", ActionName = "actSavePrdCost")]
	public ActionResult ProductsCost(int prdId = 0, int sgId = 0)
	{
		FillDropdownProductCost();
		base.ViewBag.prdId = prdId;
		base.ViewBag.sgId = sgId;
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmProductsCost", ActionName = "actDefineCostGroups")]
	public ActionResult ProductCostGroup()
	{
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmProductsPrice", ActionName = "actDefinePriceGroups")]
	public ActionResult ProductPriceGroup()
	{
		GetPrdPriceGroupList();
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actCurrencyUnit")]
	public ActionResult CurrencyUnit()
	{
		return View();
	}

	[AjaxOnly]
	public ActionResult _PartialProductPrice(int prdId, int priceGroupId)
	{
		base.ViewBag.prdId = prdId;
		base.ViewBag.priceGroupId = priceGroupId;
		return PartialView();
	}

	[AjaxOnly]
	public ActionResult ProductPrice_Read([DataSourceRequest] DataSourceRequest request, int prdId, int priceGroupId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int? centerId = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId : null);
		List<WSspSelectProductPriceByPrdAndGroup_Result> list = new List<WSspSelectProductPriceByPrdAndGroup_Result>();
		try
		{
			if (prdId > 0 && priceGroupId > 0)
			{
				list = Enumerable.ToList<WSspSelectProductPriceByPrdAndGroup_Result>((IEnumerable<WSspSelectProductPriceByPrdAndGroup_Result>)_db.WSspSelectProductPriceByPrdAndGroup(prdId, priceGroupId, lCID, result, centerId));
				if (list != null && Enumerable.Any<WSspSelectProductPriceByPrdAndGroup_Result>((IEnumerable<WSspSelectProductPriceByPrdAndGroup_Result>)list))
				{
					foreach (WSspSelectProductPriceByPrdAndGroup_Result item in list)
					{
						item.DocDate = (item.DocDateTime.HasValue ? item.DocDateTime.Value.ToString("yyyy/MM/dd") : "");
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult _PartialProductCost(int prdId, int costGroupId)
	{
		base.ViewBag.prdId = prdId;
		base.ViewBag.costGroupId = costGroupId;
		return PartialView();
	}

	[AjaxOnly]
	public ActionResult ProductCost_Read([DataSourceRequest] DataSourceRequest request, int prdId, int costGroupId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int? centerId = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId : null);
		List<WSspSelectProductCostByPrdAndGroup_Result> list = new List<WSspSelectProductCostByPrdAndGroup_Result>();
		try
		{
			if (prdId > 0 && costGroupId > 0)
			{
				list = Enumerable.ToList<WSspSelectProductCostByPrdAndGroup_Result>((IEnumerable<WSspSelectProductCostByPrdAndGroup_Result>)_db.WSspSelectProductCostByPrdAndGroup(prdId, costGroupId, lCID, result, centerId));
				if (list != null && Enumerable.Any<WSspSelectProductCostByPrdAndGroup_Result>((IEnumerable<WSspSelectProductCostByPrdAndGroup_Result>)list))
				{
					foreach (WSspSelectProductCostByPrdAndGroup_Result item in list)
					{
						item.DocDate = (item.DocDateTime.HasValue ? item.DocDateTime.Value.ToString("yyyy/MM/dd") : "");
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult _PartialProductCostGroup()
	{
		return PartialView();
	}

	[AjaxOnly]
	public ActionResult ProductCostGroup_Read([DataSourceRequest] DataSourceRequest request)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectProductCostGroup_Result> list = new List<WSspSelectProductCostGroup_Result>();
		try
		{
			list = Enumerable.ToList<WSspSelectProductCostGroup_Result>((IEnumerable<WSspSelectProductCostGroup_Result>)_db.WSspSelectProductCostGroup(lCID, result));
			foreach (WSspSelectProductCostGroup_Result item in list)
			{
				if (string.IsNullOrEmpty(item.AppType))
				{
					item.AppType = Configuration.AppType;
				}
				item.AppType = Configuration.GetAppType(item.AppType);
				string text = item.FirstRegisterUser ?? "";
				string text2 = (item.FirstRegisterDate.HasValue ? item.FirstRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
				item.FirstRegisterDatePersian = text + " (" + text2 + ")";
				string text3 = item.EditUser ?? "";
				_ = item.RegisterDate;
				string text4 = item.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				item.RegisterDatePersian = text3 + " (" + Labels.AppType + ":" + item.AppType + ")  (" + text4 + ")";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request));
	}

	[AjaxOnly]
	public ActionResult _PartialProductPriceGroup()
	{
		return PartialView();
	}

	[AjaxOnly]
	public ActionResult ProductPriceGroup_Read([DataSourceRequest] DataSourceRequest request)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectProductPriceGroup_Result> list = new List<WSspSelectProductPriceGroup_Result>();
		try
		{
			list = Enumerable.ToList<WSspSelectProductPriceGroup_Result>((IEnumerable<WSspSelectProductPriceGroup_Result>)_db.WSspSelectProductPriceGroup(lCID, result));
			foreach (WSspSelectProductPriceGroup_Result item in list)
			{
				if (string.IsNullOrEmpty(item.AppType))
				{
					item.AppType = Configuration.AppType;
				}
				item.AppType = Configuration.GetAppType(item.AppType);
				string text = item.FirstRegisterUser ?? "";
				string text2 = (item.FirstRegisterDate.HasValue ? item.FirstRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
				item.FirstRegisterDatePersian = text + " (" + text2 + ")";
				string text3 = item.EditUser ?? "";
				_ = item.RegisterDate;
				string text4 = item.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				item.RegisterDatePersian = text3 + " (" + Labels.AppType + ":" + item.AppType + ")  (" + text4 + ")";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request));
	}

	[AjaxOnly]
	public ActionResult _PartialCurrencyUnit()
	{
		return PartialView();
	}

	[AjaxOnly]
	public ActionResult CurrencyUnit_Read([DataSourceRequest] DataSourceRequest request)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectCurrencyUnits_Result> list = new List<WSspSelectCurrencyUnits_Result>();
		try
		{
			list = Enumerable.ToList<WSspSelectCurrencyUnits_Result>((IEnumerable<WSspSelectCurrencyUnits_Result>)_db.WSspSelectCurrencyUnits(lCID, result));
			foreach (WSspSelectCurrencyUnits_Result item in list)
			{
				if (string.IsNullOrEmpty(item.AppType))
				{
					item.AppType = Configuration.AppType;
				}
				item.AppType = Configuration.GetAppType(item.AppType);
				string text = item.FirstRegisterUser ?? "";
				string text2 = (item.FirstRegisterDate.HasValue ? item.FirstRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
				item.FirstRegisterDatePersian = text + " (" + text2 + ")";
				string text3 = item.EditUser ?? "";
				_ = item.RegisterDate;
				string text4 = item.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				item.RegisterDatePersian = text3 + " (" + Labels.AppType + ":" + item.AppType + ")  (" + text4 + ")";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request));
	}

	private void FillDropdownProductPrice()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			List<WSspSelectProductPriceGroup_Result> list = Enumerable.ToList<WSspSelectProductPriceGroup_Result>((IEnumerable<WSspSelectProductPriceGroup_Result>)_db.WSspSelectProductPriceGroup(lCID, result));
			List<SelectListItem> list2 = new List<SelectListItem>();
			list2.AddRange(Enumerable.Select<WSspSelectProductPriceGroup_Result, SelectListItem>((IEnumerable<WSspSelectProductPriceGroup_Result>)list, (Func<WSspSelectProductPriceGroup_Result, SelectListItem>)((WSspSelectProductPriceGroup_Result item) => new SelectListItem
			{
				Text = item.ProductPriceGroupName,
				Value = item.ProductPriceGroupID.ToString(),
				Selected = false
			})));
			base.ViewBag.GroupList = list2;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}

	[AjaxOnly]
	public JsonResult GetPrdPriceGroup()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CrmDroupDownItem> list = new List<CrmDroupDownItem>();
		try
		{
			list = Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<WSspSelectProductPriceGroup_Result, CrmDroupDownItem>((IEnumerable<WSspSelectProductPriceGroup_Result>)Enumerable.ToList<WSspSelectProductPriceGroup_Result>((IEnumerable<WSspSelectProductPriceGroup_Result>)_db.WSspSelectProductPriceGroup(lCID, result)), (Func<WSspSelectProductPriceGroup_Result, CrmDroupDownItem>)((WSspSelectProductPriceGroup_Result item) => new CrmDroupDownItem
			{
				text = item.ProductPriceGroupName,
				value = item.ProductPriceGroupID.ToString()
			})));
			base.ViewBag.GroupList = list;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	private void FillDropdownProductCost()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			List<WSspSelectProductCostGroup_Result> list = Enumerable.ToList<WSspSelectProductCostGroup_Result>((IEnumerable<WSspSelectProductCostGroup_Result>)_db.WSspSelectProductCostGroup(lCID, result));
			List<SelectListItem> list2 = new List<SelectListItem>();
			list2.AddRange(Enumerable.Select<WSspSelectProductCostGroup_Result, SelectListItem>((IEnumerable<WSspSelectProductCostGroup_Result>)list, (Func<WSspSelectProductCostGroup_Result, SelectListItem>)((WSspSelectProductCostGroup_Result item) => new SelectListItem
			{
				Text = item.ProductCostGroupName,
				Value = item.ProductCostGroupID.ToString(),
				Selected = false
			})));
			base.ViewBag.GroupList = list2;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}

	[AjaxOnly]
	public JsonResult GetPrdCostGroup()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CrmDroupDownItem> list = new List<CrmDroupDownItem>();
		try
		{
			list = Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<WSspSelectProductCostGroup_Result, CrmDroupDownItem>((IEnumerable<WSspSelectProductCostGroup_Result>)Enumerable.ToList<WSspSelectProductCostGroup_Result>((IEnumerable<WSspSelectProductCostGroup_Result>)_db.WSspSelectProductCostGroup(lCID, result)), (Func<WSspSelectProductCostGroup_Result, CrmDroupDownItem>)((WSspSelectProductCostGroup_Result item) => new CrmDroupDownItem
			{
				text = item.ProductCostGroupName,
				value = item.ProductCostGroupID.ToString()
			})));
			base.ViewBag.GroupList = list;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public ProductInfoViewModel GetProductInfo(int prdId)
	{
		_003C_003Ec__DisplayClass122_0 _003C_003Ec__DisplayClass122_ = new _003C_003Ec__DisplayClass122_0();
		_003C_003Ec__DisplayClass122_.prdId = prdId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		ProductInfoViewModel productInfoViewModel = new ProductInfoViewModel();
		try
		{
			if (_003C_003Ec__DisplayClass122_.prdId > 0)
			{
				DbSet<WSProducts> wSProducts = _dbTbl.WSProducts;
				ParameterExpression val = Expression.Parameter(typeof(WSProducts), "m");
				WSProducts prd = Queryable.FirstOrDefault<WSProducts>((IQueryable<WSProducts>)wSProducts, Expression.Lambda<Func<WSProducts, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass122_, typeof(_003C_003Ec__DisplayClass122_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (prd != null)
				{
					productInfoViewModel.ProductID = prd.ProductID;
					productInfoViewModel.PrdCode = ((!string.IsNullOrEmpty(prd.PrdCode)) ? prd.PrdCode : "");
					productInfoViewModel.PrdName = ((!string.IsNullOrEmpty(prd.PrdName)) ? prd.PrdName : "");
					WSspSelectWSProductSecondGroup_Result sGroup = Enumerable.FirstOrDefault<WSspSelectWSProductSecondGroup_Result>((IEnumerable<WSspSelectWSProductSecondGroup_Result>)Enumerable.ToList<WSspSelectWSProductSecondGroup_Result>((IEnumerable<WSspSelectWSProductSecondGroup_Result>)_db.WSspSelectWSProductSecondGroup(lCID, result, 0)), (Func<WSspSelectWSProductSecondGroup_Result, bool>)((WSspSelectWSProductSecondGroup_Result m) => m.PrdSecondGroupID == prd.PrdGroupID));
					if (sGroup != null)
					{
						productInfoViewModel.SGName = ((!string.IsNullOrEmpty(sGroup.SGName)) ? sGroup.SGName : "");
						productInfoViewModel.SgId = sGroup.PrdSecondGroupID;
						WSspSelectProductFirstGroup_Result wSspSelectProductFirstGroup_Result = Enumerable.FirstOrDefault<WSspSelectProductFirstGroup_Result>((IEnumerable<WSspSelectProductFirstGroup_Result>)_db.WSspSelectProductFirstGroup(lCID, result), (Func<WSspSelectProductFirstGroup_Result, bool>)((WSspSelectProductFirstGroup_Result m) => m.PrdFirstGroupID == sGroup.FirstGroupId));
						if (wSspSelectProductFirstGroup_Result != null)
						{
							productInfoViewModel.FgId = wSspSelectProductFirstGroup_Result.PrdFirstGroupID;
							productInfoViewModel.FGName = ((!string.IsNullOrEmpty(wSspSelectProductFirstGroup_Result.FGName)) ? wSspSelectProductFirstGroup_Result.FGName : "");
						}
					}
					productInfoViewModel.GroupName = productInfoViewModel.FGName + " - " + productInfoViewModel.SGName;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return productInfoViewModel;
	}

	private void FillDropdownCurrencyUnit()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonDroupDownItemViewModel> list = new List<CommonDroupDownItemViewModel>();
		try
		{
			List<WSspSelectCurrencyUnits_Result> list2 = Enumerable.ToList<WSspSelectCurrencyUnits_Result>((IEnumerable<WSspSelectCurrencyUnits_Result>)_db.WSspSelectCurrencyUnits(lCID, result));
			CommonDroupDownItemViewModel item2 = new CommonDroupDownItemViewModel
			{
				Text = Labels.SelectedListDefValue,
				Tag = ""
			};
			list.Add(item2);
			list.AddRange(Enumerable.Select<WSspSelectCurrencyUnits_Result, CommonDroupDownItemViewModel>((IEnumerable<WSspSelectCurrencyUnits_Result>)list2, (Func<WSspSelectCurrencyUnits_Result, CommonDroupDownItemViewModel>)((WSspSelectCurrencyUnits_Result item) => new CommonDroupDownItemViewModel
			{
				Text = item.CurrencyUnit,
				Value = item.CurrencyUnitID.ToString(),
				Tag = ((!string.IsNullOrEmpty(item.CurrencyUnitEn)) ? item.CurrencyUnitEn : "")
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CurrencyUnitList = list;
	}

	[AjaxOnly]
	public JsonResult GetCurrencyUnit()
	{
		List<CommonDroupDownItemViewModel> list = new List<CommonDroupDownItemViewModel>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<WSspSelectCurrencyUnits_Result> list2 = Enumerable.ToList<WSspSelectCurrencyUnits_Result>((IEnumerable<WSspSelectCurrencyUnits_Result>)_db.WSspSelectCurrencyUnits(lCID, result));
			CommonDroupDownItemViewModel item2 = new CommonDroupDownItemViewModel
			{
				Text = Labels.SelectedListDefValue,
				Tag = ""
			};
			list.Add(item2);
			list.AddRange(Enumerable.Select<WSspSelectCurrencyUnits_Result, CommonDroupDownItemViewModel>((IEnumerable<WSspSelectCurrencyUnits_Result>)list2, (Func<WSspSelectCurrencyUnits_Result, CommonDroupDownItemViewModel>)((WSspSelectCurrencyUnits_Result item) => new CommonDroupDownItemViewModel
			{
				Text = item.CurrencyUnit,
				Value = item.CurrencyUnitID.ToString(),
				Tag = ((!string.IsNullOrEmpty(item.CurrencyUnitEn)) ? item.CurrencyUnitEn : "")
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetCurrencyUnitByIsDecimal()
	{
		List<CommonCurrencyUnitDroupDownItemViewModel> list = new List<CommonCurrencyUnitDroupDownItemViewModel>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<WSspSelectCurrencyUnits_Result> list2 = Enumerable.ToList<WSspSelectCurrencyUnits_Result>((IEnumerable<WSspSelectCurrencyUnits_Result>)_db.WSspSelectCurrencyUnits(lCID, result));
			CommonCurrencyUnitDroupDownItemViewModel item2 = new CommonCurrencyUnitDroupDownItemViewModel
			{
				CurrencyUnit = Labels.SelectedListDefValue,
				Tag = "",
				IsDecimal = true
			};
			list.Add(item2);
			list.AddRange(Enumerable.Select<WSspSelectCurrencyUnits_Result, CommonCurrencyUnitDroupDownItemViewModel>((IEnumerable<WSspSelectCurrencyUnits_Result>)list2, (Func<WSspSelectCurrencyUnits_Result, CommonCurrencyUnitDroupDownItemViewModel>)((WSspSelectCurrencyUnits_Result item) => new CommonCurrencyUnitDroupDownItemViewModel
			{
				CurrencyUnit = item.CurrencyUnit,
				CurrencyUnitEn = (item.CurrencyUnitEn ?? ""),
				Value = item.CurrencyUnitID.ToString(),
				Tag = ((!string.IsNullOrEmpty(item.CurrencyUnitEn)) ? item.CurrencyUnitEn : ""),
				IsDecimal = (item.IsDecimal.HasValue && item.IsDecimal != false)
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CurrencyUnitList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public int GetRialCurrencyUnitId()
	{
		int result = 0;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			WSspSelectCurrencyUnitsWithUnit_Result wSspSelectCurrencyUnitsWithUnit_Result = Enumerable.FirstOrDefault<WSspSelectCurrencyUnitsWithUnit_Result>((IEnumerable<WSspSelectCurrencyUnitsWithUnit_Result>)_dbII.WSspSelectCurrencyUnitsWithUnit("ریال", result2, result2));
			if (wSspSelectCurrencyUnitsWithUnit_Result != null)
			{
				result = wSspSelectCurrencyUnitsWithUnit_Result.CurrencyUnitID;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public void SetUserNameDateForProductsPrice(WSProductPriceLanguageViewModel model)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		string text2 = "";
		try
		{
			string text3 = "";
			string text4 = "";
			string text5 = (model.FirstRegisterUserId ?? UserLogin.CurrentUser.UserId).ToString();
			_ = model.UserId;
			List<CRMspSelectUsersByIds_Result> list = CRMIdeal.Classes.Helper.User.SelectUsersByIds(text5 + "," + model.UserId);
			if (Enumerable.Any<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list))
			{
				model.FirstRegisterUserId = model.FirstRegisterUserId ?? UserLogin.CurrentUser.UserId;
				CRMspSelectUsersByIds_Result cRMspSelectUsersByIds_Result = Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result c) => c.UserId == model.FirstRegisterUserId));
				text3 = ((cRMspSelectUsersByIds_Result != null) ? (cRMspSelectUsersByIds_Result.LName + ((cRMspSelectUsersByIds_Result.FName != null) ? (" " + cRMspSelectUsersByIds_Result.FName) : "")) : "");
				WSProductPriceLanguageViewModel wSProductPriceLanguageViewModel = model;
				_ = model.UserId;
				wSProductPriceLanguageViewModel.UserId = model.UserId;
				CRMspSelectUsersByIds_Result cRMspSelectUsersByIds_Result2 = Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result c) => c.UserId == model.UserId));
				text4 = ((cRMspSelectUsersByIds_Result2 != null) ? (cRMspSelectUsersByIds_Result2.LName + ((cRMspSelectUsersByIds_Result2.FName != null) ? (" " + cRMspSelectUsersByIds_Result2.FName) : "")) : "");
			}
			string text6 = (model.FirstRegisterDate.HasValue ? model.FirstRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
			_ = model.RegisterDate;
			string text7 = model.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
			if (string.IsNullOrEmpty(model.AppType))
			{
				model.AppType = Configuration.AppType;
			}
			string text8 = Labels.AppType + ": " + Configuration.GetAppType(model.AppType);
			text = Labels.frmFirstRegisterUser + ": " + text3 + " (" + text6 + ")";
			text2 = Labels.frmRegisterUser + ": " + text4 + " (" + text8 + ") (" + text7 + ")";
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.FirstRegisterInfo = text;
		base.ViewBag.EditInfo = text2;
	}

	[DynamicAuthorize(ControllerName = "frmProductsPrice", ActionName = "actInsert")]
	public ActionResult ProductsPriceInsert(int prdId, int priceGroupId)
	{
		string docDate = DateTime.Now.ToString("yyyy/MM/dd");
		int fPId = ((Financial.Get() != null) ? Financial.Get().Id : 0);
		DateTime now = DateTime.Now;
		int rialCurrencyUnitId = GetRialCurrencyUnitId();
		base.ViewBag.RialCurrencyUnitId = rialCurrencyUnitId;
		WSProductPriceLanguageViewModel wSProductPriceLanguageViewModel = new WSProductPriceLanguageViewModel
		{
			PrdId = prdId,
			ProductPriceGroupId = priceGroupId,
			FPId = fPId,
			DocDate = docDate,
			UserId = UserLogin.CurrentUser.UserId,
			RegisterDate = now,
			AppType = Configuration.AppType,
			FirstRegisterUserId = UserLogin.CurrentUser.UserId,
			FirstRegisterDate = now,
			CurrencyUnitId = ((rialCurrencyUnitId != 0) ? new int?(rialCurrencyUnitId) : null)
		};
		GetCurrencyUnitByIsDecimal();
		SetUserNameDateForProductsPrice(wSProductPriceLanguageViewModel);
		return View(wSProductPriceLanguageViewModel);
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmProductsPriceDataEntry", ActionName = "actPost")]
	public ActionResult ProductsPriceInsert(WSProductPriceLanguageViewModel model)
	{
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		base.ViewBag.RialCurrencyUnitId = GetRialCurrencyUnitId();
		int? cId = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId : null);
		List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(model.Description_Lang))
		{
			list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.Description_Lang);
		}
		list.Add(new CommonMultiLanguageViewModel
		{
			Value = model.Description,
			LanguageId = lCID
		});
		string text = "";
		try
		{
			if (base.ModelState.IsValid)
			{
				DateTime now = DateTime.Now;
				WSProductPrice wSProductPrice = new WSProductPrice();
				wSProductPrice.UserId = UserLogin.CurrentUser.UserId;
				wSProductPrice.RegisterDate = now;
				wSProductPrice.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				wSProductPrice.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
				wSProductPrice.FirstRegisterDate = now;
				wSProductPrice.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				wSProductPrice.LanguageID = defLangID;
				wSProductPrice.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
				wSProductPrice.GUId = System.Guid.NewGuid();
				DateTime value = DateTime.Parse(PersianDate.GetFormatetdDate(model.DocDate.Replace("/", "")));
				wSProductPrice.DocDate = value.ToString("yyyyMMdd", new PersianCulture());
				wSProductPrice.DocDateTime = value;
				wSProductPrice.PrdId = model.PrdId;
				wSProductPrice.DocNumber = model.DocNumber;
				wSProductPrice.Price = model.Price;
				wSProductPrice.CurrencyPrice = model.CurrencyPrice;
				wSProductPrice.CurrencyUnitId = model.CurrencyUnitId;
				wSProductPrice.CooperationPrice = model.CooperationPrice;
				wSProductPrice.PricePercent = model.PricePercent;
				wSProductPrice.DiscountPrecent = model.DiscountPrecent;
				wSProductPrice.Discount = model.Discount;
				wSProductPrice.OtherPrice = model.OtherPrice;
				wSProductPrice.FPId = model.FPId;
				wSProductPrice.ProductPriceGroupId = model.ProductPriceGroupId;
				wSProductPrice.AppType = Configuration.AppType;
				wSProductPrice.Description = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
				wSProductPrice.PrePaymentPrice = model.PrePaymentPrice;
				wSProductPrice.TaxIndex = model.TaxIndex;
				if (wSProductPrice.CId.GetValueOrDefault() == 0)
				{
					wSProductPrice.CId = cId;
				}
				_dbTbl.WSProductPrice.Add(wSProductPrice);
				_dbTbl.SaveChanges();
				foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))))
				{
					WSProductPrice_Lang entity = new WSProductPrice_Lang
					{
						LanguageID = lang.LanguageID,
						PrdPriceID = wSProductPrice.PrdPriceID,
						Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null)
					};
					_dbTbl.WSProductPrice_Lang.Add(entity);
					_dbTbl.SaveChanges();
				}
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductPrice");
				base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
				model.UserId = wSProductPrice.UserId;
				model.RegisterDate = wSProductPrice.RegisterDate;
				model.AppType = wSProductPrice.AppType;
				model.FirstRegisterUserId = wSProductPrice.FirstRegisterUserId;
				model.FirstRegisterDate = wSProductPrice.FirstRegisterDate;
			}
			else
			{
				text = Messages.frmErrorMessage + "<br/>" + string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			text = Messages.frmErrorMessage + ", " + ex.Message;
		}
		base.ViewBag.Error = text;
		GetCurrencyUnitByIsDecimal();
		SetUserNameDateForProductsPrice(model);
		return View(model);
	}

	[DynamicAuthorize(ControllerName = "frmProductsPrice", ActionName = "actEdit")]
	public ActionResult ProductsPriceEdit(int prdPriceId)
	{
		_003C_003Ec__DisplayClass130_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass130_0();
		CS_0024_003C_003E8__locals0.prdPriceId = prdPriceId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		DbSet<WSProductPrice_Lang> wSProductPrice_Lang = _dbTbl.WSProductPrice_Lang;
		ParameterExpression val = Expression.Parameter(typeof(WSProductPrice_Lang), "c");
		List<WSProductPrice_Lang> list = Enumerable.ToList<WSProductPrice_Lang>((IEnumerable<WSProductPrice_Lang>)Queryable.Where<WSProductPrice_Lang>((IQueryable<WSProductPrice_Lang>)wSProductPrice_Lang, Expression.Lambda<Func<WSProductPrice_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass130_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
		WSProductPriceLanguageViewModel wSProductPriceLanguageViewModel = new WSProductPriceLanguageViewModel();
		try
		{
			int fPId = ((Financial.Get() != null) ? Financial.Get().Id : 0);
			WSProductPrice wSProductPrice = _dbTbl.WSProductPrice.Find(CS_0024_003C_003E8__locals0.prdPriceId);
			DateTime now = DateTime.Now;
			if (wSProductPrice == null)
			{
				wSProductPriceLanguageViewModel.PrdPriceID = CS_0024_003C_003E8__locals0.prdPriceId;
				wSProductPriceLanguageViewModel.FPId = fPId;
				wSProductPriceLanguageViewModel.DocDate = DateTime.Now.ToString("yyyy/MM/dd");
				wSProductPriceLanguageViewModel.UserId = UserLogin.CurrentUser.UserId;
				wSProductPriceLanguageViewModel.RegisterDate = now;
				wSProductPriceLanguageViewModel.AppType = Configuration.AppType;
				wSProductPriceLanguageViewModel.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
				wSProductPriceLanguageViewModel.FirstRegisterDate = now;
			}
			else
			{
				List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSProductPrice_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSProductPrice_Lang>)list, (Func<WSProductPrice_Lang, CommonMultiLanguageViewModel>)((WSProductPrice_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.Description,
					LanguageId = item.LanguageID
				})));
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = wSProductPrice.Description,
					LanguageId = result
				});
				wSProductPriceLanguageViewModel = new WSProductPriceLanguageViewModel
				{
					Month1 = wSProductPrice.Month1,
					LanguageID = wSProductPrice.LanguageID,
					UserId = wSProductPrice.UserId,
					FirstRegisterUserId = wSProductPrice.FirstRegisterUserId,
					FirstRegisterDatePersian = wSProductPrice.FirstRegisterDatePersian,
					FirstRegisterDate = wSProductPrice.FirstRegisterDate,
					RegisterDate = wSProductPrice.RegisterDate,
					RegisterDatePersian = wSProductPrice.RegisterDatePersian,
					AppType = wSProductPrice.AppType,
					GUId = wSProductPrice.GUId,
					FPId = wSProductPrice.FPId,
					PrdId = wSProductPrice.PrdId,
					DocDate = wSProductPrice.DocDate,
					DocDateTime = wSProductPrice.DocDateTime,
					PrdPriceID = wSProductPrice.PrdPriceID,
					WHId = wSProductPrice.WHId,
					CooperationPrice = wSProductPrice.CooperationPrice,
					CurrencyPrice = wSProductPrice.CurrencyPrice,
					CurrencyUnitId = wSProductPrice.CurrencyUnitId,
					Discount = wSProductPrice.Discount,
					DiscountPrecent = wSProductPrice.DiscountPrecent,
					DocNumber = wSProductPrice.DocNumber,
					OtherPrice = wSProductPrice.OtherPrice,
					Price = wSProductPrice.Price,
					PricePercent = wSProductPrice.PricePercent,
					ProductPriceGroupId = wSProductPrice.ProductPriceGroupId,
					Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					Description_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					PrePaymentPrice = wSProductPrice.PrePaymentPrice,
					TaxIndex = wSProductPrice.TaxIndex
				};
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		GetCurrencyUnitByIsDecimal();
		SetUserNameDateForProductsPrice(wSProductPriceLanguageViewModel);
		return View(wSProductPriceLanguageViewModel);
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmProductsPriceDataEntry", ActionName = "actPost")]
	public ActionResult ProductsPriceEdit(WSProductPriceLanguageViewModel model)
	{
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass131_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass131_0();
		CS_0024_003C_003E8__locals0.model = model;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.Description_Lang))
		{
			list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.Description_Lang);
		}
		list.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.model.Description,
			LanguageId = lCID
		});
		string text = "";
		try
		{
			if (base.ModelState.IsValid)
			{
				DateTime now = DateTime.Now;
				WSProductPrice wSProductPrice = _dbTbl.WSProductPrice.Find(CS_0024_003C_003E8__locals0.model.PrdPriceID);
				if (wSProductPrice != null)
				{
					wSProductPrice.UserId = UserLogin.CurrentUser.UserId;
					wSProductPrice.RegisterDate = now;
					wSProductPrice.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					wSProductPrice.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
					DateTime value = DateTime.Parse(PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.model.DocDate.Replace("/", "")));
					wSProductPrice.DocDate = value.ToString("yyyyMMdd", new PersianCulture());
					wSProductPrice.DocDateTime = value;
					wSProductPrice.DocNumber = CS_0024_003C_003E8__locals0.model.DocNumber;
					wSProductPrice.Price = CS_0024_003C_003E8__locals0.model.Price;
					wSProductPrice.CurrencyPrice = CS_0024_003C_003E8__locals0.model.CurrencyPrice;
					wSProductPrice.CurrencyUnitId = CS_0024_003C_003E8__locals0.model.CurrencyUnitId;
					wSProductPrice.CooperationPrice = CS_0024_003C_003E8__locals0.model.CooperationPrice;
					wSProductPrice.PricePercent = CS_0024_003C_003E8__locals0.model.PricePercent;
					wSProductPrice.DiscountPrecent = CS_0024_003C_003E8__locals0.model.DiscountPrecent;
					wSProductPrice.Discount = CS_0024_003C_003E8__locals0.model.Discount;
					wSProductPrice.OtherPrice = CS_0024_003C_003E8__locals0.model.OtherPrice;
					wSProductPrice.FPId = CS_0024_003C_003E8__locals0.model.FPId;
					wSProductPrice.ProductPriceGroupId = CS_0024_003C_003E8__locals0.model.ProductPriceGroupId;
					wSProductPrice.AppType = Configuration.AppType;
					wSProductPrice.Description = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					wSProductPrice.PrePaymentPrice = CS_0024_003C_003E8__locals0.model.PrePaymentPrice;
					wSProductPrice.TaxIndex = CS_0024_003C_003E8__locals0.model.TaxIndex;
					_dbTbl.Entry(wSProductPrice).State = EntityState.Modified;
					_dbTbl.SaveChanges();
					using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							_003C_003Ec__DisplayClass131_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass131_1();
							CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
							CS_0024_003C_003E8__locals1.lang = enumerator.Current;
							DbSet<WSProductPrice_Lang> wSProductPrice_Lang = _dbTbl.WSProductPrice_Lang;
							ParameterExpression val = Expression.Parameter(typeof(WSProductPrice_Lang), "c");
							WSProductPrice_Lang wSProductPrice_Lang2 = Queryable.FirstOrDefault<WSProductPrice_Lang>((IQueryable<WSProductPrice_Lang>)wSProductPrice_Lang, Expression.Lambda<Func<WSProductPrice_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass131_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass131_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (wSProductPrice_Lang2 != null)
							{
								wSProductPrice_Lang2.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								_dbTbl.Entry(wSProductPrice_Lang2).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							wSProductPrice_Lang2 = new WSProductPrice_Lang
							{
								LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID,
								PrdPriceID = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.PrdPriceID,
								Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null)
							};
							_dbTbl.WSProductPrice_Lang.Add(wSProductPrice_Lang2);
							_dbTbl.SaveChanges();
						}
					}
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductPrice");
					base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
					CS_0024_003C_003E8__locals0.model.UserId = wSProductPrice.UserId;
					CS_0024_003C_003E8__locals0.model.RegisterDate = wSProductPrice.RegisterDate;
					CS_0024_003C_003E8__locals0.model.AppType = wSProductPrice.AppType;
					CS_0024_003C_003E8__locals0.model.FirstRegisterUserId = wSProductPrice.FirstRegisterUserId;
					CS_0024_003C_003E8__locals0.model.FirstRegisterDate = wSProductPrice.FirstRegisterDate;
				}
				else
				{
					text = Messages.frmErrorMessage;
				}
			}
			else
			{
				text = Messages.frmErrorMessage + "<br/>" + string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
		}
		catch (DbEntityValidationException ex)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)ex);
			text = Messages.frmErrorMessage + ", " + ((Exception)(object)ex).Message;
		}
		catch (Exception ex2)
		{
			ErrorSignal.FromCurrentContext().Raise(ex2);
			text = Messages.frmErrorMessage + ", " + ex2.Message;
		}
		GetCurrencyUnitByIsDecimal();
		base.ViewBag.Error = text;
		SetUserNameDateForProductsPrice(CS_0024_003C_003E8__locals0.model);
		return View(CS_0024_003C_003E8__locals0.model);
	}

	[DynamicAuthorize(ControllerName = "frmProductsPrice", ActionName = "actDelete")]
	[AjaxOnly]
	public string ProductsPriceDelete(int prdPriceId)
	{
		string result = "-1";
		try
		{
			if (prdPriceId > 0 && _dbTbl.WSProductPrice.Find(prdPriceId) != null)
			{
				mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)Enumerable.ToList<mct_Result>((IEnumerable<mct_Result>)_db.WSspDeleteWSProductPrice(prdPriceId)));
				if (mct_Result != null && mct_Result.Result > 0)
				{
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductPrice");
					result = "1";
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return result;
		}
		return result;
	}

	public void SetUserNameDateForProductsCost(WSProductCostLanguageViewModel model)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		string text2 = "";
		try
		{
			string text3 = "";
			string text4 = "";
			string text5 = (model.FirstRegisterUserId ?? UserLogin.CurrentUser.UserId).ToString();
			_ = model.UserId;
			List<CRMspSelectUsersByIds_Result> list = CRMIdeal.Classes.Helper.User.SelectUsersByIds(text5 + "," + model.UserId);
			if (Enumerable.Any<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list))
			{
				model.FirstRegisterUserId = model.FirstRegisterUserId ?? UserLogin.CurrentUser.UserId;
				CRMspSelectUsersByIds_Result cRMspSelectUsersByIds_Result = Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result c) => c.UserId == model.FirstRegisterUserId));
				text3 = ((cRMspSelectUsersByIds_Result != null) ? (cRMspSelectUsersByIds_Result.LName + ((cRMspSelectUsersByIds_Result.FName != null) ? (" " + cRMspSelectUsersByIds_Result.FName) : "")) : "");
				WSProductCostLanguageViewModel wSProductCostLanguageViewModel = model;
				_ = model.UserId;
				wSProductCostLanguageViewModel.UserId = model.UserId;
				CRMspSelectUsersByIds_Result cRMspSelectUsersByIds_Result2 = Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result c) => c.UserId == model.UserId));
				text4 = ((cRMspSelectUsersByIds_Result2 != null) ? (cRMspSelectUsersByIds_Result2.LName + ((cRMspSelectUsersByIds_Result2.FName != null) ? (" " + cRMspSelectUsersByIds_Result2.FName) : "")) : "");
			}
			string text6 = (model.FirstRegisterDate.HasValue ? model.FirstRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
			_ = model.RegisterDate;
			string text7 = model.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
			if (string.IsNullOrEmpty(model.AppType))
			{
				model.AppType = Configuration.AppType;
			}
			string text8 = Labels.AppType + ": " + Configuration.GetAppType(model.AppType);
			text = Labels.frmFirstRegisterUser + ": " + text3 + " (" + text6 + ")";
			text2 = Labels.frmRegisterUser + ": " + text4 + " (" + text8 + ") (" + text7 + ")";
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.FirstRegisterInfo = text;
		base.ViewBag.EditInfo = text2;
	}

	[DynamicAuthorize(ControllerName = "frmProductsCost", ActionName = "actInsert")]
	public ActionResult ProductsCostInsert(int prdId, int costGroupId)
	{
		int fPId = ((Financial.Get() != null) ? Financial.Get().Id : 0);
		string docDate = DateTime.Now.ToString("yyyy/MM/dd");
		DateTime now = DateTime.Now;
		int rialCurrencyUnitId = GetRialCurrencyUnitId();
		base.ViewBag.RialCurrencyUnitId = rialCurrencyUnitId;
		WSProductCostLanguageViewModel wSProductCostLanguageViewModel = new WSProductCostLanguageViewModel
		{
			PrdId = prdId,
			ProductCostGroupId = costGroupId,
			FPId = fPId,
			DocDate = docDate,
			UserId = UserLogin.CurrentUser.UserId,
			RegisterDate = now,
			AppType = Configuration.AppType,
			FirstRegisterUserId = UserLogin.CurrentUser.UserId,
			FirstRegisterDate = now,
			CurrencyUnitId = ((rialCurrencyUnitId != 0) ? new int?(rialCurrencyUnitId) : null)
		};
		GetCurrencyUnitByIsDecimal();
		SetUserNameDateForProductsCost(wSProductCostLanguageViewModel);
		return View(wSProductCostLanguageViewModel);
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmProductsCostDataEntry", ActionName = "actPost")]
	public ActionResult ProductsCostInsert(WSProductCostLanguageViewModel model)
	{
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		base.ViewBag.RialCurrencyUnitId = GetRialCurrencyUnitId();
		int? cId = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId : null);
		List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(model.Description_Lang))
		{
			list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.Description_Lang);
		}
		list.Add(new CommonMultiLanguageViewModel
		{
			Value = model.Description,
			LanguageId = lCID
		});
		string text = "";
		try
		{
			if (base.ModelState.IsValid)
			{
				DateTime now = DateTime.Now;
				WSProductCost wSProductCost = new WSProductCost();
				wSProductCost.UserId = UserLogin.CurrentUser.UserId;
				wSProductCost.RegisterDate = now;
				wSProductCost.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				wSProductCost.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
				wSProductCost.FirstRegisterDate = now;
				wSProductCost.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				wSProductCost.LanguageID = defLangID;
				wSProductCost.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
				wSProductCost.GUId = System.Guid.NewGuid();
				wSProductCost.AppType = Configuration.AppType;
				DateTime value = DateTime.Parse(PersianDate.GetFormatetdDate(model.DocDate.Replace("/", "")));
				wSProductCost.DocDate = value.ToString("yyyyMMdd", new PersianCulture());
				wSProductCost.DocDateTime = value;
				wSProductCost.PrdId = model.PrdId;
				wSProductCost.DocNumber = model.DocNumber;
				wSProductCost.Cost = model.Cost;
				wSProductCost.CurrencyCost = model.CurrencyCost;
				wSProductCost.CurrencyUnitId = model.CurrencyUnitId;
				wSProductCost.TransportCost = model.TransportCost;
				wSProductCost.ReleasingCost = model.ReleasingCost;
				wSProductCost.SlagCost = model.SlagCost;
				wSProductCost.OtherCost = model.OtherCost;
				wSProductCost.FPId = model.FPId;
				wSProductCost.ProductCostGroupId = model.ProductCostGroupId;
				wSProductCost.Description = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
				wSProductCost.CId = cId;
				_dbTbl.WSProductCost.Add(wSProductCost);
				_dbTbl.SaveChanges();
				foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))))
				{
					WSProductCost_Lang entity = new WSProductCost_Lang
					{
						LanguageID = lang.LanguageID,
						ProductCostID = wSProductCost.ProductCostID,
						Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null)
					};
					_dbTbl.WSProductCost_Lang.Add(entity);
					_dbTbl.SaveChanges();
				}
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductCost");
				base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
				model.UserId = wSProductCost.UserId;
				model.RegisterDate = wSProductCost.RegisterDate;
				model.AppType = wSProductCost.AppType;
				model.FirstRegisterUserId = wSProductCost.FirstRegisterUserId;
				model.FirstRegisterDate = wSProductCost.FirstRegisterDate;
			}
			else
			{
				text = Messages.frmErrorMessage + "<br/>" + string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			text = Messages.frmErrorMessage + ", " + ex.Message;
		}
		base.ViewBag.Error = text;
		GetCurrencyUnitByIsDecimal();
		SetUserNameDateForProductsCost(model);
		return View(model);
	}

	[DynamicAuthorize(ControllerName = "frmProductsCost", ActionName = "actEdit")]
	public ActionResult ProductsCostEdit(int prdCostId)
	{
		_003C_003Ec__DisplayClass136_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass136_0();
		CS_0024_003C_003E8__locals0.prdCostId = prdCostId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		DbSet<WSProductCost_Lang> wSProductCost_Lang = _dbTbl.WSProductCost_Lang;
		ParameterExpression val = Expression.Parameter(typeof(WSProductCost_Lang), "c");
		List<WSProductCost_Lang> list = Enumerable.ToList<WSProductCost_Lang>((IEnumerable<WSProductCost_Lang>)Queryable.Where<WSProductCost_Lang>((IQueryable<WSProductCost_Lang>)wSProductCost_Lang, Expression.Lambda<Func<WSProductCost_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass136_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
		WSProductCostLanguageViewModel wSProductCostLanguageViewModel = new WSProductCostLanguageViewModel();
		try
		{
			DateTime now = DateTime.Now;
			int fPId = ((Financial.Get() != null) ? Financial.Get().Id : 0);
			WSProductCost wSProductCost = _dbTbl.WSProductCost.Find(CS_0024_003C_003E8__locals0.prdCostId);
			if (wSProductCost == null)
			{
				string docDate = DateTime.Now.ToString("yyyy/MM/dd");
				wSProductCostLanguageViewModel = new WSProductCostLanguageViewModel();
				wSProductCostLanguageViewModel.ProductCostID = CS_0024_003C_003E8__locals0.prdCostId;
				wSProductCostLanguageViewModel.FPId = fPId;
				wSProductCostLanguageViewModel.DocDate = docDate;
				wSProductCostLanguageViewModel.DocDateTime = DateTime.Now;
				wSProductCostLanguageViewModel.UserId = UserLogin.CurrentUser.UserId;
				wSProductCostLanguageViewModel.RegisterDate = now;
				wSProductCostLanguageViewModel.AppType = Configuration.AppType;
				wSProductCostLanguageViewModel.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
				wSProductCostLanguageViewModel.FirstRegisterDate = now;
			}
			else
			{
				List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSProductCost_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSProductCost_Lang>)list, (Func<WSProductCost_Lang, CommonMultiLanguageViewModel>)((WSProductCost_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.Description,
					LanguageId = item.LanguageID
				})));
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = wSProductCost.Description,
					LanguageId = result
				});
				wSProductCostLanguageViewModel = new WSProductCostLanguageViewModel
				{
					Month1 = wSProductCost.Month1,
					LanguageID = wSProductCost.LanguageID,
					UserId = wSProductCost.UserId,
					FirstRegisterUserId = wSProductCost.FirstRegisterUserId,
					FirstRegisterDatePersian = wSProductCost.FirstRegisterDatePersian,
					FirstRegisterDate = wSProductCost.FirstRegisterDate,
					RegisterDate = wSProductCost.RegisterDate,
					RegisterDatePersian = wSProductCost.RegisterDatePersian,
					AppType = wSProductCost.AppType,
					GUId = wSProductCost.GUId,
					FPId = wSProductCost.FPId,
					PrdId = wSProductCost.PrdId,
					DocDate = wSProductCost.DocDate,
					DocDateTime = wSProductCost.DocDateTime,
					WHId = wSProductCost.WHId,
					CurrencyUnitId = wSProductCost.CurrencyUnitId,
					DocNumber = wSProductCost.DocNumber,
					ProductCostID = wSProductCost.ProductCostID,
					Cost = wSProductCost.Cost,
					CurrencyCost = wSProductCost.CurrencyCost,
					OtherCost = wSProductCost.OtherCost,
					ProductCostGroupId = wSProductCost.ProductCostGroupId,
					ReleasingCost = wSProductCost.ReleasingCost,
					SlagCost = wSProductCost.SlagCost,
					TransportCost = wSProductCost.TransportCost,
					Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					Description_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))))
				};
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		GetCurrencyUnitByIsDecimal();
		SetUserNameDateForProductsCost(wSProductCostLanguageViewModel);
		return View(wSProductCostLanguageViewModel);
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmProductsCostDataEntry", ActionName = "actPost")]
	public ActionResult ProductsCostEdit(WSProductCostLanguageViewModel model)
	{
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass137_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass137_0();
		CS_0024_003C_003E8__locals0.model = model;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.Description_Lang))
		{
			list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.Description_Lang);
		}
		list.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.model.Description,
			LanguageId = lCID
		});
		string text = "";
		try
		{
			if (base.ModelState.IsValid)
			{
				DateTime now = DateTime.Now;
				WSProductCost wSProductCost = _dbTbl.WSProductCost.Find(CS_0024_003C_003E8__locals0.model.ProductCostID);
				if (wSProductCost != null)
				{
					wSProductCost.UserId = UserLogin.CurrentUser.UserId;
					wSProductCost.RegisterDate = now;
					wSProductCost.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					wSProductCost.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
					DateTime value = DateTime.Parse(PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.model.DocDate.Replace("/", "")));
					wSProductCost.DocDate = value.ToString("yyyyMMdd", new PersianCulture());
					wSProductCost.DocDateTime = value;
					wSProductCost.DocNumber = CS_0024_003C_003E8__locals0.model.DocNumber;
					wSProductCost.Cost = CS_0024_003C_003E8__locals0.model.Cost;
					wSProductCost.CurrencyCost = CS_0024_003C_003E8__locals0.model.CurrencyCost;
					wSProductCost.CurrencyUnitId = CS_0024_003C_003E8__locals0.model.CurrencyUnitId;
					wSProductCost.TransportCost = CS_0024_003C_003E8__locals0.model.TransportCost;
					wSProductCost.ReleasingCost = CS_0024_003C_003E8__locals0.model.ReleasingCost;
					wSProductCost.SlagCost = CS_0024_003C_003E8__locals0.model.SlagCost;
					wSProductCost.OtherCost = CS_0024_003C_003E8__locals0.model.OtherCost;
					wSProductCost.FPId = CS_0024_003C_003E8__locals0.model.FPId;
					wSProductCost.ProductCostGroupId = CS_0024_003C_003E8__locals0.model.ProductCostGroupId;
					wSProductCost.AppType = Configuration.AppType;
					wSProductCost.Description = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					_dbTbl.Entry(wSProductCost).State = EntityState.Modified;
					_dbTbl.SaveChanges();
					using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							_003C_003Ec__DisplayClass137_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass137_1();
							CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
							CS_0024_003C_003E8__locals1.lang = enumerator.Current;
							DbSet<WSProductCost_Lang> wSProductCost_Lang = _dbTbl.WSProductCost_Lang;
							ParameterExpression val = Expression.Parameter(typeof(WSProductCost_Lang), "c");
							WSProductCost_Lang wSProductCost_Lang2 = Queryable.FirstOrDefault<WSProductCost_Lang>((IQueryable<WSProductCost_Lang>)wSProductCost_Lang, Expression.Lambda<Func<WSProductCost_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass137_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass137_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (wSProductCost_Lang2 != null)
							{
								wSProductCost_Lang2.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								_dbTbl.Entry(wSProductCost_Lang2).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							wSProductCost_Lang2 = new WSProductCost_Lang
							{
								LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID,
								ProductCostID = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.ProductCostID,
								Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null)
							};
							_dbTbl.WSProductCost_Lang.Add(wSProductCost_Lang2);
							_dbTbl.SaveChanges();
						}
					}
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductCost");
					base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
					CS_0024_003C_003E8__locals0.model.UserId = wSProductCost.UserId;
					CS_0024_003C_003E8__locals0.model.RegisterDate = wSProductCost.RegisterDate;
					CS_0024_003C_003E8__locals0.model.AppType = wSProductCost.AppType;
					CS_0024_003C_003E8__locals0.model.FirstRegisterUserId = wSProductCost.FirstRegisterUserId;
					CS_0024_003C_003E8__locals0.model.FirstRegisterDate = wSProductCost.FirstRegisterDate;
					CS_0024_003C_003E8__locals0.model.DocDateTime = wSProductCost.DocDateTime;
				}
				else
				{
					text = Messages.frmErrorMessage;
				}
			}
			else
			{
				text = Messages.frmErrorMessage + "<br/>" + string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
		}
		catch (DbEntityValidationException ex)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)ex);
			text = Messages.frmErrorMessage + ", " + ((Exception)(object)ex).Message;
		}
		catch (Exception ex2)
		{
			ErrorSignal.FromCurrentContext().Raise(ex2);
			text = Messages.frmErrorMessage + ", " + ex2.Message;
		}
		GetCurrencyUnitByIsDecimal();
		base.ViewBag.Error = text;
		SetUserNameDateForProductsCost(CS_0024_003C_003E8__locals0.model);
		return View(CS_0024_003C_003E8__locals0.model);
	}

	[DynamicAuthorize(ControllerName = "frmProductsCost", ActionName = "actDelete")]
	[AjaxOnly]
	public string ProductsCostDelete(int prdCostId)
	{
		string result = "-1";
		try
		{
			if (prdCostId > 0 && _dbTbl.WSProductCost.Find(prdCostId) != null)
			{
				mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)Enumerable.ToList<mct_Result>((IEnumerable<mct_Result>)_db.WSspDeleteWSProductCost(prdCostId)));
				if (mct_Result != null && mct_Result.Result > 0)
				{
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductCost");
					result = "1";
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return result;
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "frmDefineBaseInfo", ActionName = "actInsert")]
	public ActionResult ProductCostGroupInsert()
	{
		WSProductCostGroupLanguageViewModel model = new WSProductCostGroupLanguageViewModel();
		return View(model);
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmDefineBaseInfoIDataEntry", ActionName = "actPost")]
	public ActionResult ProductCostGroupInsert(WSProductCostGroupLanguageViewModel model)
	{
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(model.ProductCostGroupName_Lang))
		{
			list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.ProductCostGroupName_Lang);
		}
		list.Add(new CommonMultiLanguageViewModel
		{
			Value = model.ProductCostGroupName,
			LanguageId = lCID
		});
		string text = "";
		if (model.ProductCostGroupName == null && model.ProductCostGroupName == "")
		{
			text = text + Messages.CheckCurrencyUnit + "<br/>";
		}
		else if (!checkMultiLanguage(model.ProductCostGroupName, list))
		{
			text = text + Messages.CheckCurrencyUnitLang + "<br>";
		}
		if (text != "")
		{
			base.ViewBag.Error = text;
			return View(model);
		}
		try
		{
			DateTime now = DateTime.Now;
			WSProductCostGroup wSProductCostGroup = new WSProductCostGroup();
			wSProductCostGroup.Year1 = short.Parse(now.ToString("yyyy", new PersianCulture()));
			wSProductCostGroup.UserId = UserLogin.CurrentUser.UserId;
			wSProductCostGroup.RegisterDate = now;
			wSProductCostGroup.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			wSProductCostGroup.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
			wSProductCostGroup.GUId = System.Guid.NewGuid();
			wSProductCostGroup.AppType = Configuration.AppType;
			wSProductCostGroup.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
			wSProductCostGroup.FirstRegisterDate = now;
			wSProductCostGroup.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			wSProductCostGroup.LanguageID = defLangID;
			wSProductCostGroup.OrderView = model.OrderView;
			wSProductCostGroup.ProductCostGroupName = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
			if (base.ModelState.IsValid)
			{
				_dbTbl.WSProductCostGroup.Add(wSProductCostGroup);
				_dbTbl.SaveChanges();
				foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))))
				{
					WSProductCostGroup_Lang entity = new WSProductCostGroup_Lang
					{
						LanguageID = lang.LanguageID,
						ProductCostGroupID = wSProductCostGroup.ProductCostGroupID,
						ProductCostGroupName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null)
					};
					_dbTbl.WSProductCostGroup_Lang.Add(entity);
					_dbTbl.SaveChanges();
				}
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductCostGroup");
				base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
			}
			else
			{
				text = Messages.frmErrorMessage + "<br/>" + string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			text = Messages.frmErrorMessage + ", " + ex.Message;
		}
		base.ViewBag.Error = text;
		return View(model);
	}

	[DynamicAuthorize(ControllerName = "frmDefineBaseInfo", ActionName = "actEdit")]
	public ActionResult ProductCostGroupEdit(int id)
	{
		_003C_003Ec__DisplayClass141_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass141_0();
		CS_0024_003C_003E8__locals0.id = id;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		DbSet<WSProductCostGroup_Lang> wSProductCostGroup_Lang = _dbTbl.WSProductCostGroup_Lang;
		ParameterExpression val = Expression.Parameter(typeof(WSProductCostGroup_Lang), "c");
		List<WSProductCostGroup_Lang> list = Enumerable.ToList<WSProductCostGroup_Lang>((IEnumerable<WSProductCostGroup_Lang>)Queryable.Where<WSProductCostGroup_Lang>((IQueryable<WSProductCostGroup_Lang>)wSProductCostGroup_Lang, Expression.Lambda<Func<WSProductCostGroup_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass141_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
		WSProductCostGroupLanguageViewModel wSProductCostGroupLanguageViewModel = new WSProductCostGroupLanguageViewModel();
		try
		{
			WSProductCostGroup wSProductCostGroup = _dbTbl.WSProductCostGroup.Find(CS_0024_003C_003E8__locals0.id);
			if (wSProductCostGroup == null)
			{
				wSProductCostGroupLanguageViewModel = new WSProductCostGroupLanguageViewModel();
				wSProductCostGroupLanguageViewModel.ProductCostGroupID = CS_0024_003C_003E8__locals0.id;
			}
			else
			{
				List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSProductCostGroup_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSProductCostGroup_Lang>)list, (Func<WSProductCostGroup_Lang, CommonMultiLanguageViewModel>)((WSProductCostGroup_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.ProductCostGroupName,
					LanguageId = item.LanguageID
				})));
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = wSProductCostGroup.ProductCostGroupName,
					LanguageId = result
				});
				wSProductCostGroupLanguageViewModel = new WSProductCostGroupLanguageViewModel
				{
					ProductCostGroupID = wSProductCostGroup.ProductCostGroupID,
					UserId = wSProductCostGroup.UserId,
					FirstRegisterUserId = wSProductCostGroup.FirstRegisterUserId,
					FirstRegisterDatePersian = wSProductCostGroup.FirstRegisterDatePersian,
					FirstRegisterDate = wSProductCostGroup.FirstRegisterDate,
					RegisterDate = wSProductCostGroup.RegisterDate,
					RegisterDatePersian = wSProductCostGroup.RegisterDatePersian,
					AppType = wSProductCostGroup.AppType,
					GUId = wSProductCostGroup.GUId,
					LanguageID = wSProductCostGroup.LanguageID,
					Month1 = wSProductCostGroup.Month1,
					Year1 = wSProductCostGroup.Month1,
					ProductCostGroupDesc = wSProductCostGroup.ProductCostGroupDesc,
					OrderView = wSProductCostGroup.OrderView,
					ProductCostGroupName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					ProductCostGroupName_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))))
				};
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View(wSProductCostGroupLanguageViewModel);
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmDefineBaseInfoIDataEntry", ActionName = "actPost")]
	public ActionResult ProductCostGroupEdit(WSProductCostGroupLanguageViewModel model)
	{
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass142_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass142_0();
		CS_0024_003C_003E8__locals0.model = model;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.ProductCostGroupName_Lang))
		{
			list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.ProductCostGroupName_Lang);
		}
		list.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.model.ProductCostGroupName,
			LanguageId = lCID
		});
		string text = "";
		if (CS_0024_003C_003E8__locals0.model.ProductCostGroupName == null && CS_0024_003C_003E8__locals0.model.ProductCostGroupName == "")
		{
			text = text + Messages.CheckCurrencyUnit + "<br/>";
		}
		else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.model.ProductCostGroupName, list))
		{
			text = text + Messages.CheckCurrencyUnitLang + "<br>";
		}
		if (text != "")
		{
			base.ViewBag.Error = text;
			return View(CS_0024_003C_003E8__locals0.model);
		}
		try
		{
			if (base.ModelState.IsValid)
			{
				DateTime now = DateTime.Now;
				DbSet<WSProductCostGroup> wSProductCostGroup = _dbTbl.WSProductCostGroup;
				ParameterExpression val = Expression.Parameter(typeof(WSProductCostGroup), "c");
				WSProductCostGroup wSProductCostGroup2 = Queryable.FirstOrDefault<WSProductCostGroup>((IQueryable<WSProductCostGroup>)wSProductCostGroup, Expression.Lambda<Func<WSProductCostGroup, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass142_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (wSProductCostGroup2 != null)
				{
					wSProductCostGroup2.UserId = UserLogin.CurrentUser.UserId;
					wSProductCostGroup2.RegisterDate = now;
					wSProductCostGroup2.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					wSProductCostGroup2.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
					wSProductCostGroup2.AppType = Configuration.AppType;
					wSProductCostGroup2.Year1 = short.Parse(now.ToString("yyyy", new PersianCulture()));
					wSProductCostGroup2.OrderView = CS_0024_003C_003E8__locals0.model.OrderView;
					wSProductCostGroup2.OrderView = CS_0024_003C_003E8__locals0.model.OrderView;
					wSProductCostGroup2.ProductCostGroupName = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					_dbTbl.Entry(wSProductCostGroup2).State = EntityState.Modified;
					_dbTbl.SaveChanges();
					using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							_003C_003Ec__DisplayClass142_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass142_1();
							CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
							CS_0024_003C_003E8__locals1.lang = enumerator.Current;
							DbSet<WSProductCostGroup_Lang> wSProductCostGroup_Lang = _dbTbl.WSProductCostGroup_Lang;
							val = Expression.Parameter(typeof(WSProductCostGroup_Lang), "c");
							WSProductCostGroup_Lang wSProductCostGroup_Lang2 = Queryable.FirstOrDefault<WSProductCostGroup_Lang>((IQueryable<WSProductCostGroup_Lang>)wSProductCostGroup_Lang, Expression.Lambda<Func<WSProductCostGroup_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass142_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass142_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (wSProductCostGroup_Lang2 != null)
							{
								wSProductCostGroup_Lang2.ProductCostGroupName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								_dbTbl.Entry(wSProductCostGroup_Lang2).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							wSProductCostGroup_Lang2 = new WSProductCostGroup_Lang
							{
								LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID,
								ProductCostGroupID = wSProductCostGroup2.ProductCostGroupID,
								ProductCostGroupName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null)
							};
							_dbTbl.WSProductCostGroup_Lang.Add(wSProductCostGroup_Lang2);
							_dbTbl.SaveChanges();
						}
					}
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductCostGroup");
					base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
				}
				else
				{
					text = Messages.frmErrorMessage;
				}
			}
			else
			{
				text = Messages.frmErrorMessage + "<br/>" + string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			text = Messages.frmErrorMessage + ", " + ex.Message;
		}
		base.ViewBag.Error = text;
		return View(CS_0024_003C_003E8__locals0.model);
	}

	[DynamicAuthorize(ControllerName = "frmDefineBaseInfo", ActionName = "actDelete")]
	[AjaxOnly]
	public string ProductCostGroupDelete(int id)
	{
		string result = "-1";
		try
		{
			if (id > 0)
			{
				_003C_003Ec__DisplayClass143_0 _003C_003Ec__DisplayClass143_ = new _003C_003Ec__DisplayClass143_0();
				_003C_003Ec__DisplayClass143_.item = _dbTbl.WSProductCostGroup.Find(id);
				if (_003C_003Ec__DisplayClass143_.item != null)
				{
					DbSet<WSProductCost> wSProductCost = _dbTbl.WSProductCost;
					ParameterExpression val = Expression.Parameter(typeof(WSProductCost), "m");
					if (Enumerable.ToList<WSProductCost>((IEnumerable<WSProductCost>)Queryable.Where<WSProductCost>((IQueryable<WSProductCost>)wSProductCost, Expression.Lambda<Func<WSProductCost, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Convert((Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass143_, typeof(_003C_003Ec__DisplayClass143_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), typeof(int?))), (ParameterExpression[])(object)new ParameterExpression[1] { val }))).Count == 0)
					{
						mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)Enumerable.ToList<mct_Result>((IEnumerable<mct_Result>)_db.WSspDeleteWSProductCostGroup(id)));
						if (mct_Result != null && mct_Result.Result > 0)
						{
							CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductCostGroup");
							result = "1";
						}
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return result;
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "frmDefineBaseInfo", ActionName = "actInsert")]
	public ActionResult ProductPriceGroupInsert()
	{
		WSProductPriceGroupLanguageViewModel model = new WSProductPriceGroupLanguageViewModel();
		return View(model);
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmDefineBaseInfoIDataEntry", ActionName = "actPost")]
	public ActionResult ProductPriceGroupInsert(WSProductPriceGroupLanguageViewModel model)
	{
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(model.ProductPriceGroupName_Lang))
		{
			list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.ProductPriceGroupName_Lang);
		}
		list.Add(new CommonMultiLanguageViewModel
		{
			Value = model.ProductPriceGroupName,
			LanguageId = lCID
		});
		string text = "";
		if (model.ProductPriceGroupName == null && model.ProductPriceGroupName == "")
		{
			text = text + Messages.CheckCurrencyUnit + "<br/>";
		}
		else if (!checkMultiLanguage(model.ProductPriceGroupName, list))
		{
			text = text + Messages.CheckCurrencyUnitLang + "<br>";
		}
		if (text != "")
		{
			base.ViewBag.Error = text;
			return View(model);
		}
		try
		{
			DateTime now = DateTime.Now;
			WSProductPriceGroup wSProductPriceGroup = new WSProductPriceGroup();
			wSProductPriceGroup.Year1 = short.Parse(now.ToString("yyyy", new PersianCulture()));
			wSProductPriceGroup.UserId = UserLogin.CurrentUser.UserId;
			wSProductPriceGroup.RegisterDate = now;
			wSProductPriceGroup.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			wSProductPriceGroup.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
			wSProductPriceGroup.GUId = System.Guid.NewGuid();
			wSProductPriceGroup.AppType = Configuration.AppType;
			wSProductPriceGroup.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
			wSProductPriceGroup.FirstRegisterDate = now;
			wSProductPriceGroup.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			wSProductPriceGroup.LanguageID = defLangID;
			wSProductPriceGroup.OrderView = model.OrderView;
			wSProductPriceGroup.ProductPriceGroupName = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
			wSProductPriceGroup.SHPPriceGroupVisible = model.SHPPriceGroupVisible;
			if (base.ModelState.IsValid)
			{
				_dbTbl.WSProductPriceGroup.Add(wSProductPriceGroup);
				_dbTbl.SaveChanges();
				foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))))
				{
					WSProductPriceGroup_Lang entity = new WSProductPriceGroup_Lang
					{
						LanguageID = lang.LanguageID,
						ProductPriceGroupID = wSProductPriceGroup.ProductPriceGroupID,
						ProductPriceGroupName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null)
					};
					_dbTbl.WSProductPriceGroup_Lang.Add(entity);
					_dbTbl.SaveChanges();
				}
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductPriceGroup");
				base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
			}
			else
			{
				text = Messages.frmErrorMessage + "<br/>" + string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			text = Messages.frmErrorMessage + ", " + ex.Message;
		}
		base.ViewBag.Error = text;
		return View(model);
	}

	[DynamicAuthorize(ControllerName = "frmProductsPrice", ActionName = "actDefinePriceGroups")]
	public ActionResult ProductPriceGroupShpDefault()
	{
		GetPrdPriceGroupList();
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmDefineBaseInfo", ActionName = "actEdit")]
	public ActionResult ProductPriceGroupEdit(int id)
	{
		_003C_003Ec__DisplayClass147_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass147_0();
		CS_0024_003C_003E8__locals0.id = id;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		DbSet<WSProductPriceGroup_Lang> wSProductPriceGroup_Lang = _dbTbl.WSProductPriceGroup_Lang;
		ParameterExpression val = Expression.Parameter(typeof(WSProductPriceGroup_Lang), "c");
		List<WSProductPriceGroup_Lang> list = Enumerable.ToList<WSProductPriceGroup_Lang>((IEnumerable<WSProductPriceGroup_Lang>)Queryable.Where<WSProductPriceGroup_Lang>((IQueryable<WSProductPriceGroup_Lang>)wSProductPriceGroup_Lang, Expression.Lambda<Func<WSProductPriceGroup_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass147_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
		WSProductPriceGroupLanguageViewModel wSProductPriceGroupLanguageViewModel = new WSProductPriceGroupLanguageViewModel();
		try
		{
			WSProductPriceGroup wSProductPriceGroup = _dbTbl.WSProductPriceGroup.Find(CS_0024_003C_003E8__locals0.id);
			if (wSProductPriceGroup == null)
			{
				wSProductPriceGroupLanguageViewModel = new WSProductPriceGroupLanguageViewModel();
				wSProductPriceGroupLanguageViewModel.ProductPriceGroupID = CS_0024_003C_003E8__locals0.id;
			}
			else
			{
				List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSProductPriceGroup_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSProductPriceGroup_Lang>)list, (Func<WSProductPriceGroup_Lang, CommonMultiLanguageViewModel>)((WSProductPriceGroup_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.ProductPriceGroupName,
					LanguageId = item.LanguageID
				})));
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = wSProductPriceGroup.ProductPriceGroupName,
					LanguageId = result
				});
				wSProductPriceGroupLanguageViewModel = new WSProductPriceGroupLanguageViewModel
				{
					ProductPriceGroupID = wSProductPriceGroup.ProductPriceGroupID,
					UserId = wSProductPriceGroup.UserId,
					FirstRegisterUserId = wSProductPriceGroup.FirstRegisterUserId,
					FirstRegisterDatePersian = wSProductPriceGroup.FirstRegisterDatePersian,
					FirstRegisterDate = wSProductPriceGroup.FirstRegisterDate,
					RegisterDate = wSProductPriceGroup.RegisterDate,
					RegisterDatePersian = wSProductPriceGroup.RegisterDatePersian,
					AppType = wSProductPriceGroup.AppType,
					GUId = wSProductPriceGroup.GUId,
					LanguageID = wSProductPriceGroup.LanguageID,
					Month1 = wSProductPriceGroup.Month1,
					Year1 = wSProductPriceGroup.Month1,
					ProductPriceGroupDesc = wSProductPriceGroup.ProductPriceGroupDesc,
					OrderView = wSProductPriceGroup.OrderView,
					ProductPriceGroupName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					ProductPriceGroupName_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					SHPPriceGroupVisible = wSProductPriceGroup.SHPPriceGroupVisible,
					SHPDefaultPriceGroup = wSProductPriceGroup.SHPDefaultPriceGroup
				};
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View(wSProductPriceGroupLanguageViewModel);
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmDefineBaseInfoIDataEntry", ActionName = "actPost")]
	public ActionResult ProductPriceGroupEdit(WSProductPriceGroupLanguageViewModel model)
	{
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass148_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass148_0();
		CS_0024_003C_003E8__locals0.model = model;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.ProductPriceGroupName_Lang))
		{
			list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.ProductPriceGroupName_Lang);
		}
		list.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.model.ProductPriceGroupName,
			LanguageId = lCID
		});
		string text = "";
		if (CS_0024_003C_003E8__locals0.model.ProductPriceGroupName == null && CS_0024_003C_003E8__locals0.model.ProductPriceGroupName == "")
		{
			text = text + Messages.CheckCurrencyUnit + "<br/>";
		}
		else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.model.ProductPriceGroupName, list))
		{
			text = text + Messages.CheckCurrencyUnitLang + "<br>";
		}
		if (text != "")
		{
			base.ViewBag.Error = text;
			return View(CS_0024_003C_003E8__locals0.model);
		}
		try
		{
			if (base.ModelState.IsValid)
			{
				DateTime now = DateTime.Now;
				DbSet<WSProductPriceGroup> wSProductPriceGroup = _dbTbl.WSProductPriceGroup;
				ParameterExpression val = Expression.Parameter(typeof(WSProductPriceGroup), "c");
				WSProductPriceGroup wSProductPriceGroup2 = Queryable.FirstOrDefault<WSProductPriceGroup>((IQueryable<WSProductPriceGroup>)wSProductPriceGroup, Expression.Lambda<Func<WSProductPriceGroup, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass148_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (wSProductPriceGroup2 != null)
				{
					wSProductPriceGroup2.UserId = UserLogin.CurrentUser.UserId;
					wSProductPriceGroup2.RegisterDate = now;
					wSProductPriceGroup2.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					wSProductPriceGroup2.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
					wSProductPriceGroup2.AppType = Configuration.AppType;
					wSProductPriceGroup2.Year1 = short.Parse(now.ToString("yyyy", new PersianCulture()));
					wSProductPriceGroup2.OrderView = CS_0024_003C_003E8__locals0.model.OrderView;
					wSProductPriceGroup2.ProductPriceGroupName = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					wSProductPriceGroup2.SHPPriceGroupVisible = CS_0024_003C_003E8__locals0.model.SHPPriceGroupVisible;
					_dbTbl.Entry(wSProductPriceGroup2).State = EntityState.Modified;
					_dbTbl.SaveChanges();
					using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							_003C_003Ec__DisplayClass148_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass148_1();
							CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
							CS_0024_003C_003E8__locals1.lang = enumerator.Current;
							DbSet<WSProductPriceGroup_Lang> wSProductPriceGroup_Lang = _dbTbl.WSProductPriceGroup_Lang;
							val = Expression.Parameter(typeof(WSProductPriceGroup_Lang), "c");
							WSProductPriceGroup_Lang wSProductPriceGroup_Lang2 = Queryable.FirstOrDefault<WSProductPriceGroup_Lang>((IQueryable<WSProductPriceGroup_Lang>)wSProductPriceGroup_Lang, Expression.Lambda<Func<WSProductPriceGroup_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass148_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass148_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (wSProductPriceGroup_Lang2 != null)
							{
								wSProductPriceGroup_Lang2.ProductPriceGroupName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								_dbTbl.Entry(wSProductPriceGroup_Lang2).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							wSProductPriceGroup_Lang2 = new WSProductPriceGroup_Lang
							{
								LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID,
								ProductPriceGroupID = wSProductPriceGroup2.ProductPriceGroupID,
								ProductPriceGroupName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null)
							};
							_dbTbl.WSProductPriceGroup_Lang.Add(wSProductPriceGroup_Lang2);
							_dbTbl.SaveChanges();
						}
					}
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductPriceGroup");
					base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
				}
				else
				{
					text = Messages.frmErrorMessage;
				}
			}
			else
			{
				text = Messages.frmErrorMessage + "<br/>" + string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			text = Messages.frmErrorMessage + ", " + ex.Message;
		}
		base.ViewBag.Error = text;
		return View(CS_0024_003C_003E8__locals0.model);
	}

	[DynamicAuthorize(ControllerName = "frmDefineBaseInfo", ActionName = "actDelete")]
	[AjaxOnly]
	public string ProductPriceGroupDelete(int id)
	{
		string result = "-1";
		try
		{
			if (id > 0)
			{
				_003C_003Ec__DisplayClass149_0 _003C_003Ec__DisplayClass149_ = new _003C_003Ec__DisplayClass149_0();
				_003C_003Ec__DisplayClass149_.item = _dbTbl.WSProductPriceGroup.Find(id);
				if (_003C_003Ec__DisplayClass149_.item != null)
				{
					DbSet<WSProductPrice> wSProductPrice = _dbTbl.WSProductPrice;
					ParameterExpression val = Expression.Parameter(typeof(WSProductPrice), "m");
					if (Enumerable.ToList<WSProductPrice>((IEnumerable<WSProductPrice>)Queryable.Where<WSProductPrice>((IQueryable<WSProductPrice>)wSProductPrice, Expression.Lambda<Func<WSProductPrice, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Convert((Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass149_, typeof(_003C_003Ec__DisplayClass149_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), typeof(int?))), (ParameterExpression[])(object)new ParameterExpression[1] { val }))).Count == 0)
					{
						mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)Enumerable.ToList<mct_Result>((IEnumerable<mct_Result>)_db.WSspDeleteWSProductPriceGroup(id)));
						if (mct_Result != null && mct_Result.Result > 0)
						{
							CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductPriceGroup");
							result = "1";
						}
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return result;
		}
		return result;
	}

	[AjaxOnly]
	public int ChangeShpDefaultPriceGroup(int prdPriceGroupId)
	{
		int num = 0;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			_db.WSspUpdateProductPriceGroupSHPDefault(prdPriceGroupId);
			num = 1;
			if (num == 1)
			{
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductPriceGroup");
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return num;
	}

	[AjaxOnly]
	public JsonResult GetPrdPriceGroupList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<WSspSelectProductPriceGroup_Result> list2 = Enumerable.ToList<WSspSelectProductPriceGroup_Result>((IEnumerable<WSspSelectProductPriceGroup_Result>)_db.WSspSelectProductPriceGroup(lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectProductPriceGroup_Result, SelectListItem>((IEnumerable<WSspSelectProductPriceGroup_Result>)list2, (Func<WSspSelectProductPriceGroup_Result, SelectListItem>)((WSspSelectProductPriceGroup_Result item) => new SelectListItem
			{
				Text = item.ProductPriceGroupName,
				Value = item.ProductPriceGroupID.ToString(),
				Selected = (item.SHPDefaultPriceGroup.HasValue && item.SHPDefaultPriceGroup.GetValueOrDefault())
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.SHPDefaultList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmDefineBaseInfo", ActionName = "actInsert")]
	public ActionResult CurrencyUnitInsert()
	{
		WSCurrencyUnitsLanguageViewModel model = new WSCurrencyUnitsLanguageViewModel();
		return View(model);
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmDefineBaseInfoIDataEntry", ActionName = "actPost")]
	public ActionResult CurrencyUnitInsert(WSCurrencyUnitsLanguageViewModel model)
	{
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(model.CurrencyUnit_Lang))
		{
			list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.CurrencyUnit_Lang);
		}
		list.Add(new CommonMultiLanguageViewModel
		{
			Value = model.CurrencyUnit,
			LanguageId = lCID
		});
		string text = "";
		if (model.CurrencyUnit == null && model.CurrencyUnit == "")
		{
			text = text + Messages.CheckCurrencyUnit + "<br/>";
		}
		else if (!checkMultiLanguage(model.CurrencyUnit, list))
		{
			text = text + Messages.CheckCurrencyUnitLang + "<br>";
		}
		if (text != "")
		{
			base.ViewBag.Error = text;
			return View(model);
		}
		try
		{
			DateTime now = DateTime.Now;
			WSCurrencyUnits wSCurrencyUnits = new WSCurrencyUnits();
			wSCurrencyUnits.UserId = UserLogin.CurrentUser.UserId;
			wSCurrencyUnits.RegisterDate = now;
			wSCurrencyUnits.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			wSCurrencyUnits.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
			wSCurrencyUnits.GUId = System.Guid.NewGuid();
			wSCurrencyUnits.AppType = Configuration.AppType;
			wSCurrencyUnits.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
			wSCurrencyUnits.FirstRegisterDate = now;
			wSCurrencyUnits.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			wSCurrencyUnits.LanguageID = defLangID;
			wSCurrencyUnits.CurrencyUnit = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
			wSCurrencyUnits.CurrencyUnitEn = model.CurrencyUnitEn;
			if (VersionBuyer.IsDecimal)
			{
				wSCurrencyUnits.IsDecimal = model.IsDecimal;
			}
			wSCurrencyUnits.TspCurrencyUnitCode = model.TspCurrencyUnitCode;
			if (base.ModelState.IsValid)
			{
				_dbTbl.WSCurrencyUnits.Add(wSCurrencyUnits);
				_dbTbl.SaveChanges();
				foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))))
				{
					WSCurrencyUnits_Lang entity = new WSCurrencyUnits_Lang
					{
						LanguageID = lang.LanguageID,
						CurrencyUnitID = wSCurrencyUnits.CurrencyUnitID,
						CurrencyUnit = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null)
					};
					_dbTbl.WSCurrencyUnits_Lang.Add(entity);
					_dbTbl.SaveChanges();
				}
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSCurrencyUnits");
				model.CurrencyUnitID = wSCurrencyUnits.CurrencyUnitID;
				base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
			}
			else
			{
				text = Messages.frmErrorMessage + "<br/>" + string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			text = Messages.frmErrorMessage + ", " + ex.Message;
		}
		base.ViewBag.Error = text;
		return View(model);
	}

	[DynamicAuthorize(ControllerName = "frmDefineBaseInfo", ActionName = "actEdit")]
	public ActionResult CurrencyUnitEdit(int id)
	{
		_003C_003Ec__DisplayClass154_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass154_0();
		CS_0024_003C_003E8__locals0.id = id;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		DbSet<WSCurrencyUnits_Lang> wSCurrencyUnits_Lang = _dbTbl.WSCurrencyUnits_Lang;
		ParameterExpression val = Expression.Parameter(typeof(WSCurrencyUnits_Lang), "c");
		List<WSCurrencyUnits_Lang> list = Enumerable.ToList<WSCurrencyUnits_Lang>((IEnumerable<WSCurrencyUnits_Lang>)Queryable.Where<WSCurrencyUnits_Lang>((IQueryable<WSCurrencyUnits_Lang>)wSCurrencyUnits_Lang, Expression.Lambda<Func<WSCurrencyUnits_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass154_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
		WSCurrencyUnitsLanguageViewModel wSCurrencyUnitsLanguageViewModel = new WSCurrencyUnitsLanguageViewModel();
		try
		{
			WSCurrencyUnits wSCurrencyUnits = _dbTbl.WSCurrencyUnits.Find(CS_0024_003C_003E8__locals0.id);
			if (wSCurrencyUnits == null)
			{
				wSCurrencyUnitsLanguageViewModel = new WSCurrencyUnitsLanguageViewModel();
				wSCurrencyUnitsLanguageViewModel.CurrencyUnitID = CS_0024_003C_003E8__locals0.id;
			}
			else
			{
				List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSCurrencyUnits_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSCurrencyUnits_Lang>)list, (Func<WSCurrencyUnits_Lang, CommonMultiLanguageViewModel>)((WSCurrencyUnits_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.CurrencyUnit,
					LanguageId = item.LanguageID
				})));
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = wSCurrencyUnits.CurrencyUnit,
					LanguageId = result
				});
				wSCurrencyUnitsLanguageViewModel = new WSCurrencyUnitsLanguageViewModel
				{
					CurrencyUnitID = wSCurrencyUnits.CurrencyUnitID,
					UserId = wSCurrencyUnits.UserId,
					FirstRegisterUserId = wSCurrencyUnits.FirstRegisterUserId,
					FirstRegisterDatePersian = wSCurrencyUnits.FirstRegisterDatePersian,
					FirstRegisterDate = wSCurrencyUnits.FirstRegisterDate,
					RegisterDate = wSCurrencyUnits.RegisterDate,
					RegisterDatePersian = wSCurrencyUnits.RegisterDatePersian,
					AppType = wSCurrencyUnits.AppType,
					GUId = wSCurrencyUnits.GUId,
					LanguageID = wSCurrencyUnits.LanguageID,
					Month1 = wSCurrencyUnits.Month1,
					Description = wSCurrencyUnits.Description,
					CurrencyUnitEn = wSCurrencyUnits.CurrencyUnitEn,
					CurrencyUnit = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					CurrencyUnit_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					IsDecimal = wSCurrencyUnits.IsDecimal,
					TspCurrencyUnitCode = wSCurrencyUnits.TspCurrencyUnitCode
				};
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View(wSCurrencyUnitsLanguageViewModel);
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmDefineBaseInfoIDataEntry", ActionName = "actPost")]
	public ActionResult CurrencyUnitEdit(WSCurrencyUnitsLanguageViewModel model)
	{
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass155_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass155_0();
		CS_0024_003C_003E8__locals0.model = model;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.CurrencyUnit_Lang))
		{
			list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.CurrencyUnit_Lang);
		}
		list.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.model.CurrencyUnit,
			LanguageId = lCID
		});
		string text = "";
		if (CS_0024_003C_003E8__locals0.model.CurrencyUnit == null && CS_0024_003C_003E8__locals0.model.CurrencyUnit == "")
		{
			text = text + Messages.CheckCurrencyUnit + "<br/>";
		}
		else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.model.CurrencyUnit, list))
		{
			text = text + Messages.CheckCurrencyUnitLang + "<br>";
		}
		if (text != "")
		{
			base.ViewBag.Error = text;
			return View(CS_0024_003C_003E8__locals0.model);
		}
		try
		{
			if (base.ModelState.IsValid)
			{
				DateTime now = DateTime.Now;
				DbSet<WSCurrencyUnits> wSCurrencyUnits = _dbTbl.WSCurrencyUnits;
				ParameterExpression val = Expression.Parameter(typeof(WSCurrencyUnits), "c");
				WSCurrencyUnits wSCurrencyUnits2 = Queryable.FirstOrDefault<WSCurrencyUnits>((IQueryable<WSCurrencyUnits>)wSCurrencyUnits, Expression.Lambda<Func<WSCurrencyUnits, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass155_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (wSCurrencyUnits2 != null)
				{
					wSCurrencyUnits2.UserId = UserLogin.CurrentUser.UserId;
					wSCurrencyUnits2.RegisterDate = now;
					wSCurrencyUnits2.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					wSCurrencyUnits2.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
					wSCurrencyUnits2.AppType = Configuration.AppType;
					wSCurrencyUnits2.CurrencyUnit = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					wSCurrencyUnits2.CurrencyUnitEn = CS_0024_003C_003E8__locals0.model.CurrencyUnitEn;
					if (VersionBuyer.IsDecimal)
					{
						wSCurrencyUnits2.IsDecimal = CS_0024_003C_003E8__locals0.model.IsDecimal;
					}
					wSCurrencyUnits2.TspCurrencyUnitCode = CS_0024_003C_003E8__locals0.model.TspCurrencyUnitCode;
					_dbTbl.Entry(wSCurrencyUnits2).State = EntityState.Modified;
					_dbTbl.SaveChanges();
					using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							_003C_003Ec__DisplayClass155_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass155_1();
							CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
							CS_0024_003C_003E8__locals1.lang = enumerator.Current;
							DbSet<WSCurrencyUnits_Lang> wSCurrencyUnits_Lang = _dbTbl.WSCurrencyUnits_Lang;
							val = Expression.Parameter(typeof(WSCurrencyUnits_Lang), "c");
							WSCurrencyUnits_Lang wSCurrencyUnits_Lang2 = Queryable.FirstOrDefault<WSCurrencyUnits_Lang>((IQueryable<WSCurrencyUnits_Lang>)wSCurrencyUnits_Lang, Expression.Lambda<Func<WSCurrencyUnits_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass155_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass155_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (wSCurrencyUnits_Lang2 != null)
							{
								wSCurrencyUnits_Lang2.CurrencyUnit = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								_dbTbl.Entry(wSCurrencyUnits_Lang2).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							wSCurrencyUnits_Lang2 = new WSCurrencyUnits_Lang
							{
								LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID,
								CurrencyUnitID = wSCurrencyUnits2.CurrencyUnitID,
								CurrencyUnit = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null)
							};
							_dbTbl.WSCurrencyUnits_Lang.Add(wSCurrencyUnits_Lang2);
							_dbTbl.SaveChanges();
						}
					}
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSCurrencyUnits");
					base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
				}
				else
				{
					text = Messages.frmErrorMessage;
				}
			}
			else
			{
				text = Messages.frmErrorMessage + "<br/>" + string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			text = Messages.frmErrorMessage + ", " + ex.Message;
		}
		base.ViewBag.Error = text;
		return View(CS_0024_003C_003E8__locals0.model);
	}

	[DynamicAuthorize(ControllerName = "frmDefineBaseInfo", ActionName = "actDelete")]
	[AjaxOnly]
	public string CurrencyUnitDelete(int id)
	{
		string result = "-1";
		try
		{
			if (id > 0)
			{
				WSCurrencyUnits wSCurrencyUnits = _dbTbl.WSCurrencyUnits.Find(id);
				if (wSCurrencyUnits != null && wSCurrencyUnits.WSBuyOrderItems.Count == 0 && wSCurrencyUnits.WSProductCost.Count == 0 && wSCurrencyUnits.WSProductPrice.Count == 0)
				{
					mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)Enumerable.ToList<mct_Result>((IEnumerable<mct_Result>)_db.WSspDeleteWSCurrencyUnits(id)));
					if (mct_Result != null && mct_Result.Result > 0)
					{
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSCurrencyUnits");
						result = "1";
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return result;
		}
		return result;
	}

	public ActionResult ShowTspCurrencyUnitCode()
	{
		return View();
	}

	[AjaxOnly]
	public JsonResult GetTspCurrencyUnitCode()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			_ = UserLogin.CurrentUser.UserId;
			List<TSPspSelectCurrencyUnitCode_Result> list2 = Enumerable.ToList<TSPspSelectCurrencyUnitCode_Result>((IEnumerable<TSPspSelectCurrencyUnitCode_Result>)_dbI.TSPspSelectCurrencyUnitCode(lCID, result));
			if (list2 != null && Enumerable.Any<TSPspSelectCurrencyUnitCode_Result>((IEnumerable<TSPspSelectCurrencyUnitCode_Result>)list2))
			{
				list = Enumerable.ToList<SelectListItem>(Enumerable.Select<TSPspSelectCurrencyUnitCode_Result, SelectListItem>((IEnumerable<TSPspSelectCurrencyUnitCode_Result>)list2, (Func<TSPspSelectCurrencyUnitCode_Result, SelectListItem>)((TSPspSelectCurrencyUnitCode_Result item) => new SelectListItem
				{
					Text = item.TspCurrencyUnitCodeTitle + ((!string.IsNullOrWhiteSpace(item.TspCurrencyUnitCode)) ? (" (" + item.TspCurrencyUnitCode + ")") : ""),
					Value = (item.TspCurrencyUnitCode ?? "")
				})));
			}
			if (list == null)
			{
				list = new List<SelectListItem>();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetProductSpecificationValues(int prdId = 0)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<WSspSelectProductSpecificationValues_Result> list = Enumerable.ToList<WSspSelectProductSpecificationValues_Result>((IEnumerable<WSspSelectProductSpecificationValues_Result>)_dbII.WSspSelectProductSpecificationValues(prdId, lCID, result2));
			if (list != null)
			{
				result = JsonConvert.SerializeObject(list);
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string PrdSpecificationFieldsInsertEdit(string jsonValue = "", int? prdId = null, int? specificationId = null)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int userId = UserLogin.CurrentUser.UserId;
			short.Parse(Financial.Get().Id.ToString());
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int id = Financial.Get().Id;
			int num = 0;
			if (num == 0)
			{
				num = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId.GetValueOrDefault() : 0);
			}
			ObjectParameter objectParameter = new ObjectParameter("ResultId", 0);
			_dbII.WSspInsertUpdateProductSpecificationValue(jsonValue, prdId, specificationId, userId, value2, id, value, registerDatePersian, appType, lCID, num, objectParameter);
			if (objectParameter != null && !string.IsNullOrWhiteSpace(objectParameter.Value.ToString()))
			{
				result = objectParameter.Value.ToString();
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[LoginAuthorize]
	public ActionResult Centers(int prdId = 0)
	{
		List<WSspSelectCenterProducts_Result> list = new List<WSspSelectCenterProducts_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			List<WSspSelectCenterProducts_Result> list2 = Enumerable.ToList<WSspSelectCenterProducts_Result>((IEnumerable<WSspSelectCenterProducts_Result>)_dbII.WSspSelectCenterProducts(prdId, 0, 0));
			if (list2 != null)
			{
				list = list2;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		base.ViewBag.ProductCentersList = list;
		base.ViewBag.ProductId = prdId;
		return View();
	}

	[HttpPost]
	[LoginAuthorize]
	public string InsertCenterProduct(int cId, int prdId, bool? isActive = null, bool? shpShowAfterLogin = null)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int userId = UserLogin.CurrentUser.UserId;
			short.Parse(Financial.Get().Id.ToString());
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int id = Financial.Get().Id;
			ObjectParameter objectParameter = new ObjectParameter("InsertedId", 0);
			_dbII.WSspInsertCenterProduct(cId, prdId, isActive, shpShowAfterLogin, userId, value, registerDatePersian, id, value2, appType, lCID, objectParameter);
			if (objectParameter != null && int.Parse(objectParameter.Value.ToString()) <= 0)
			{
				result = Messages.MsgErrorDoneOperation;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string DeleteCenterProduct(int prdId = 0, int cId = 0)
	{
		string result = "";
		try
		{
			_dbII.WSspDeleteCenterProduct(cId, prdId);
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			result = Messages.MsgErrorDoneOperation;
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string UpdateCenterProductShpShowAfterLogin(int prdId, int cId, bool? showAfterLogin = null)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int userId = UserLogin.CurrentUser.UserId;
			short.Parse(Financial.Get().Id.ToString());
			short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			_ = Financial.Get().Id;
			_dbII.WSspUpdateCenterProductShpShowAfterLogin(prdId, cId, showAfterLogin, userId, value, registerDatePersian);
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[LoginAuthorize]
	public ActionResult PrdAddPrice(string prdIds = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		base.ViewBag.RialCurrencyUnitId = GetRialCurrencyUnitId();
		if (UserLogin.CurrentUser != null)
		{
			_ = UserLogin.CurrentUser.UserLastCId;
		}
		List<SelectListItem> list = new List<SelectListItem>();
		List<WSspSelectCurrencyUnits_Result> list2 = Enumerable.ToList<WSspSelectCurrencyUnits_Result>((IEnumerable<WSspSelectCurrencyUnits_Result>)_db.WSspSelectCurrencyUnits(lCID, result));
		if (list2 != null)
		{
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<WSspSelectCurrencyUnits_Result, SelectListItem>((IEnumerable<WSspSelectCurrencyUnits_Result>)list2, (Func<WSspSelectCurrencyUnits_Result, SelectListItem>)((WSspSelectCurrencyUnits_Result x) => new SelectListItem
			{
				Text = x.CurrencyUnit,
				Value = x.CurrencyUnitID.ToString()
			})));
		}
		base.ViewBag.CurrencyUnits = list;
		List<WSspSelectProductPriceGroup_Result> list3 = Enumerable.ToList<WSspSelectProductPriceGroup_Result>((IEnumerable<WSspSelectProductPriceGroup_Result>)_db.WSspSelectProductPriceGroup(lCID, result));
		List<SelectListItem> list4 = new List<SelectListItem>();
		if (list3 != null)
		{
			list4 = Enumerable.ToList<SelectListItem>(Enumerable.Select<WSspSelectProductPriceGroup_Result, SelectListItem>((IEnumerable<WSspSelectProductPriceGroup_Result>)list3, (Func<WSspSelectProductPriceGroup_Result, SelectListItem>)((WSspSelectProductPriceGroup_Result x) => new SelectListItem
			{
				Text = x.ProductPriceGroupName,
				Value = x.ProductPriceGroupID.ToString()
			})));
		}
		base.ViewBag.PrdPriceGroups = list4;
		List<WSspSelectProductsWithIds_Result> value = Enumerable.ToList<WSspSelectProductsWithIds_Result>((IEnumerable<WSspSelectProductsWithIds_Result>)_dbI.WSspSelectProductsWithIds(prdIds, ",", lCID, result));
		base.ViewBag.Prds = JsonConvert.SerializeObject(value);
		base.ViewBag.PrdIds = prdIds;
		return View();
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetProductsLastPrice(int prdPriceGroupId = 0, string prdIds = "")
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int? centerId = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId : null);
			List<WSspSelectProductsLastPrice_Result> list = Enumerable.ToList<WSspSelectProductsLastPrice_Result>((IEnumerable<WSspSelectProductsLastPrice_Result>)_dbII.WSspSelectProductsLastPrice(prdPriceGroupId, prdIds, ",", lCID, result2, centerId));
			if (list != null)
			{
				result = JsonConvert.SerializeObject(list);
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetProductsLastCost(int prdCostGroupId = 0, string prdIds = "")
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int? centerId = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId : null);
			List<WSspSelectProductsLastCost_Result> list = Enumerable.ToList<WSspSelectProductsLastCost_Result>((IEnumerable<WSspSelectProductsLastCost_Result>)_dbII.WSspSelectProductsLastCost(prdCostGroupId, prdIds, ",", lCID, result2, centerId));
			if (list != null)
			{
				result = JsonConvert.SerializeObject(list);
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string PrdAddPriceInsert(string js = "")
	{
		string text = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int userId = UserLogin.CurrentUser.UserId;
			short.Parse(Financial.Get().Id.ToString());
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int? centerId = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId : null);
			int value3 = ((Financial.Get() != null) ? Financial.Get().Id : 0);
			if (string.IsNullOrWhiteSpace(js))
			{
				text = Messages.ErrorNotFound;
			}
			if (text == "")
			{
				_dbII.WSspInsertProductPriceMulti(js, userId, value, registerDatePersian, value2, value3, appType, lCID, result, centerId);
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			text = Messages.MsgErrorDoneOperation;
		}
		return text;
	}
}
