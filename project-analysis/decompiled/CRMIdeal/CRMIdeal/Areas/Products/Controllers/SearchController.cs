using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.General.Calendar;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Areas.OtherSystems.Controllers;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Products.Controllers;

public class SearchController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass10_0
	{
		public int currLangID;

		public AddProductViewModel addProduct;

		internal bool _003C_PartialProduct_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003C_PartialProduct_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003C_PartialProduct_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003C_PartialProduct_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003C_PartialProduct_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003C_PartialProduct_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003C_PartialProduct_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003C_PartialProduct_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003C_PartialProduct_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003C_PartialProduct_003Eb__18(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003C_PartialProduct_003Eb__19(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003C_PartialProduct_003Eb__20(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003C_PartialProduct_003Eb__26(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003C_PartialProduct_003Eb__27(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003C_PartialProduct_003Eb__28(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003C_PartialProduct_003Eb__29(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003C_PartialProduct_003Eb__30(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003C_PartialProduct_003Eb__31(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003C_PartialProduct_003Eb__32(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003C_PartialProduct_003Eb__33(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003C_PartialProduct_003Eb__34(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003C_PartialProduct_003Eb__36(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003C_PartialProduct_003Eb__37(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003C_PartialProduct_003Eb__38(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003C_PartialProduct_003Eb__43(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003C_PartialProduct_003Eb__44(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003C_PartialProduct_003Eb__45(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003C_PartialProduct_003Eb__46(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003C_PartialProduct_003Eb__47(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003C_PartialProduct_003Eb__48(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003C_PartialProduct_003Eb__51(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003C_PartialProduct_003Eb__52(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003C_PartialProduct_003Eb__53(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003C_PartialProduct_003Eb__54(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003C_PartialProduct_003Eb__55(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003C_PartialProduct_003Eb__56(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003C_PartialProduct_003Eb__58(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003C_PartialProduct_003Eb__59(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003C_PartialProduct_003Eb__60(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003C_PartialProduct_003Eb__65(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003C_PartialProduct_003Eb__66(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003C_PartialProduct_003Eb__67(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003C_PartialProduct_003Eb__68(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003C_PartialProduct_003Eb__69(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003C_PartialProduct_003Eb__70(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003C_PartialProduct_003Eb__71(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003C_PartialProduct_003Eb__72(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003C_PartialProduct_003Eb__73(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass10_1
	{
		public WSPreOrderItems preOrderItem;

		public WSOrderItems orderItem;

		public WSBuyOrderItems buyOrderItem;

		public WSStockSupplyItems stocksupplyItem;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass46_0
	{
		public AddProductViewModel addProduct;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__49;

		public Func<Languages, bool> _003C_003E9__67;

		public Func<Languages, bool> _003C_003E9__76;

		public Func<Languages, bool> _003C_003E9__79;

		public Func<Languages, bool> _003C_003E9__97;

		public Func<Languages, bool> _003C_003E9__107;

		public Func<Languages, bool> _003C_003E9__129;

		public Func<Languages, bool> _003C_003E9__140;

		public Func<Languages, bool> _003C_003E9__154;

		internal bool _003CAddProductItem_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CAddProductItem_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CAddProductItem_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CAddProductItem_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CAddProductItem_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CAddProductItem_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CAddProductItem_003Eb__18(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CAddProductItem_003Eb__19(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CAddProductItem_003Eb__49(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CAddProductItem_003Eb__67(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CAddProductItem_003Eb__20(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CAddProductItem_003Eb__21(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CAddProductItem_003Eb__76(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CAddProductItem_003Eb__23(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CAddProductItem_003Eb__24(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CAddProductItem_003Eb__25(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CAddProductItem_003Eb__26(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CAddProductItem_003Eb__27(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CAddProductItem_003Eb__28(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CAddProductItem_003Eb__29(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CAddProductItem_003Eb__30(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CAddProductItem_003Eb__79(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CAddProductItem_003Eb__97(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CAddProductItem_003Eb__32(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CAddProductItem_003Eb__33(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CAddProductItem_003Eb__34(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CAddProductItem_003Eb__35(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CAddProductItem_003Eb__36(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CAddProductItem_003Eb__37(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CAddProductItem_003Eb__38(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CAddProductItem_003Eb__39(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CAddProductItem_003Eb__40(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CAddProductItem_003Eb__41(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CAddProductItem_003Eb__107(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CAddProductItem_003Eb__129(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CAddProductItem_003Eb__43(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CAddProductItem_003Eb__44(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CAddProductItem_003Eb__45(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CAddProductItem_003Eb__46(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CAddProductItem_003Eb__47(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CAddProductItem_003Eb__48(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CAddProductItem_003Eb__140(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CAddProductItem_003Eb__154(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass46_1
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass46_0 CS_0024_003C_003E8__locals1;

		internal bool _003CAddProductItem_003Eb__51(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__52(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__53(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__54(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__55(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__56(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__57(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__58(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__59(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__60(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__61(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__62(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__63(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__64(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__65(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__66(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass46_4
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass46_0 CS_0024_003C_003E8__locals2;

		internal bool _003CAddProductItem_003Eb__81(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__82(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__83(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__84(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__85(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__86(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__87(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__88(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__89(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__90(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__91(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__92(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__93(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__94(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__95(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__96(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass46_6
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass46_0 CS_0024_003C_003E8__locals3;

		internal bool _003CAddProductItem_003Eb__109(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__110(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__111(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__112(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__113(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__114(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__115(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__116(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__117(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__118(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__119(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__120(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__121(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__122(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__123(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__124(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__125(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__126(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__127(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__128(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass46_8
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass46_0 CS_0024_003C_003E8__locals4;

		internal bool _003CAddProductItem_003Eb__142(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__143(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__144(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__145(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__146(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__147(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__148(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__149(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__150(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__151(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__152(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAddProductItem_003Eb__153(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass67_0
	{
		public int prdId;

		public int currLangID;

		internal bool _003CGetAllProductInfo_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CGetAllProductInfo_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	private CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private CRMSpIEntities _dbI = new CRMSpIEntities();

	private CRMLinkSpEntities _dbLink = new CRMLinkSpEntities();

	private CRMSpIIEntities _dbII = new CRMSpIIEntities();

	private CRMSpIIIEntities _dbIII = new CRMSpIIIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actPrdShowProducts")]
	public ActionResult Index()
	{
		base.ViewBag.PrdId = 0;
		base.ViewBag.CmpId = 0;
		base.ViewBag.Mode = "Price";
		base.ViewBag.MasterId = 0;
		base.ViewBag.MasterForm = "product";
		base.ViewBag.DetailId = 0;
		return View();
	}

	[LoginAuthorize]
	public ActionResult SearchProductFromIndicator(string masterForm, string mode, int masterId = 0, int detailId = 0, int prdId = 0, int cmpId = 0, double taxInDoc = 0.0, int position = 0)
	{
		string text = "";
		string text2 = "";
		switch (position)
		{
		case 1:
			text = "frmPreOrderIndicator";
			text2 = "actSearchProduct";
			break;
		case 2:
			text = "frmBuyOrderIndicator";
			text2 = "actSearchProduct";
			break;
		case 4:
			text = "frmOrderIndicator";
			text2 = "actSearchProduct";
			break;
		case 5:
			text = "frmProductCardex";
			text2 = "actSearchProduct";
			break;
		case 6:
			text = "frmProductUserDiscountDataEntry";
			text2 = "actSearchPrd";
			break;
		case 7:
			text = "frmDefineDiscountCodeDataEntry";
			text2 = "actSearchPrd";
			break;
		case 8:
			text = "frmLinkedProducts";
			text2 = "actLinkedProductAdd";
			break;
		case 9:
			text = "frmStockSupplyIndicator";
			text2 = "actSearchProduct";
			break;
		case 10:
			text = "ok";
			text2 = "ok";
			break;
		default:
			return RedirectToAction("Login", "Account", (object)new
			{
				area = "",
				d = DateTime.Now
			});
		case 3:
			break;
		}
		if (text != "ok" && text2 != "ok" && !UserLogin.IsUserAccess(text, text2, UserLogin.CurrentUser) && position != 3)
		{
			return RedirectToAction("Login", "Account", (object)new
			{
				area = "",
				d = DateTime.Now
			});
		}
		base.ViewBag.PrdId = 0;
		base.ViewBag.CmpId = 0;
		mode = ((mode == "1" || mode == "Cost") ? "Cost" : "Price");
		base.ViewBag.Mode = mode;
		base.ViewBag.MasterId = 0;
		base.ViewBag.MasterForm = masterForm;
		base.ViewBag.DetailId = 0;
		base.ViewBag.HaveTaxInDoc = 0;
		base.ViewBag.DefTaxIndex = 0;
		return View();
	}

	public ActionResult AddProduct(string masterForm, string mode, int masterId = 0, int detailId = 0, int prdId = 0, int cmpId = 0, double taxInDoc = 0.0)
	{
		base.ViewBag.prdId = prdId;
		base.ViewBag.CmpId = cmpId;
		mode = ((mode == "1" || mode == "Cost") ? "Cost" : "Price");
		base.ViewBag.Mode = mode;
		base.ViewBag.MasterId = masterId;
		base.ViewBag.MasterForm = masterForm;
		base.ViewBag.DetailId = detailId;
		base.ViewBag.HaveTaxInDoc = taxInDoc;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "frmAddProduct";
		try
		{
			if (cmpId > 0)
			{
				CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
				int num = 0;
				if (cRMspSelectCrmsysSetting_Result != null)
				{
					num = cRMspSelectCrmsysSetting_Result.LinkAccSystemId.GetValueOrDefault();
				}
				if (num > 0)
				{
					CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(cmpId);
					if (companyById != null && num == 3 && string.IsNullOrEmpty(companyById.cmpLinkAccCustomerIdStr ?? ""))
					{
						string text2 = new CompanyController().TarazCmpSendToAcc(companyById.CompanyID);
						if (!string.IsNullOrEmpty(text2))
						{
							string[] array = text2.Split(new char[1] { '|' });
							if (array != null && array[0] != "1")
							{
								Exception e = new Exception(array[0] + "(in Taraz)");
								ErrorSignal.FromCurrentContext().Raise(e);
							}
						}
						else
						{
							Exception e2 = new Exception(Messages.msgErrorRunFunction + "(in send company to Taraz)");
							ErrorSignal.FromCurrentContext().Raise(e2);
						}
					}
				}
			}
			text = masterForm.ToLower() switch
			{
				"preorder" => "frmPreOrderItemDataEntry", 
				"saleorder" => "frmOrderItemDataEntry", 
				"buyorder" => "frmBuyOrderItemDataEntry", 
				"stocksupply" => "frmStockSupplyItemDataEntry", 
				_ => "frmAddProduct", 
			};
		}
		catch (Exception e3)
		{
			ErrorSignal.FromCurrentContext().Raise(e3);
		}
		base.ViewBag.ItemFormName = text;
		return View();
	}

	public void SetUserNameDateForProductInOreders(AddProductViewModel model)
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
				AddProductViewModel addProductViewModel = model;
				_ = model.UserId;
				addProductViewModel.UserId = model.UserId;
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

	[AjaxOnly]
	public ActionResult _PartialProduct(string masterForm, string mode, int masterId = 0, int detailId = 0, int prdId = 0)
	{
		_003C_003Ec__DisplayClass10_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass10_0();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		GetCurrencyUnit();
		GetDeliveryTerms();
		GetProductColor();
		GetProductDeliveryUsers();
		base.ViewBag.Mode = mode;
		int num = 0;
		base.ViewBag.ModeInsertEdit = ((detailId > 0) ? "Edit" : "Insert");
		CS_0024_003C_003E8__locals0.addProduct = new AddProductViewModel();
		int result2 = 0;
		if (SysSeting.Get() != null)
		{
			int.TryParse(SysSeting.Get().LinkAccSystemId.ToString(), out result2);
		}
		string text = masterForm.ToLower();
		string text2 = "frmAddProduct";
		base.ViewBag.ItemFormName = text switch
		{
			"preorder" => "frmPreOrderItemDataEntry", 
			"saleorder" => "frmOrderItemDataEntry", 
			"buyorder" => "frmBuyOrderItemDataEntry", 
			"stocksupply" => "frmStockSupplyItemDataEntry", 
			_ => "frmAddProduct", 
		};
		try
		{
			if (detailId == 0 && masterId > 0)
			{
				CS_0024_003C_003E8__locals0.addProduct = new AddProductViewModel
				{
					ProductId = 0,
					MasterId = masterId,
					Quantity = 1.0,
					DetailId = 0,
					Price = default(decimal),
					Discount = default(decimal),
					MasterForm = masterForm,
					FCR = null
				};
				switch (masterForm)
				{
				case "preOrder":
				{
					WSspSelectPreOrderItems_Result wSspSelectPreOrderItems_Result = Enumerable.FirstOrDefault<WSspSelectPreOrderItems_Result>((IEnumerable<WSspSelectPreOrderItems_Result>)Enumerable.OrderByDescending<WSspSelectPreOrderItems_Result, int>((IEnumerable<WSspSelectPreOrderItems_Result>)_db.WSspSelectPreOrderItems(masterId, CS_0024_003C_003E8__locals0.currLangID, result), (Func<WSspSelectPreOrderItems_Result, int>)((WSspSelectPreOrderItems_Result m) => m.PreOrderItemID)));
					num = wSspSelectPreOrderItems_Result?.pordIPrdId ?? 0;
					if (result2 == 4)
					{
						CS_0024_003C_003E8__locals0.addProduct.LinkAccSettingDBId = ((wSspSelectPreOrderItems_Result != null) ? wSspSelectPreOrderItems_Result.pordILinkAccSettingDBId : new int?(0));
					}
					break;
				}
				case "BuyOrder":
				{
					WSspSelectBuyOrderItems_Result wSspSelectBuyOrderItems_Result = Enumerable.FirstOrDefault<WSspSelectBuyOrderItems_Result>((IEnumerable<WSspSelectBuyOrderItems_Result>)Enumerable.OrderByDescending<WSspSelectBuyOrderItems_Result, int>((IEnumerable<WSspSelectBuyOrderItems_Result>)_db.WSspSelectBuyOrderItems(masterId, CS_0024_003C_003E8__locals0.currLangID, result), (Func<WSspSelectBuyOrderItems_Result, int>)((WSspSelectBuyOrderItems_Result m) => m.BuyOrderItemId)));
					num = wSspSelectBuyOrderItems_Result?.bordIPrdId ?? 0;
					if (result2 == 4)
					{
						CS_0024_003C_003E8__locals0.addProduct.LinkAccSettingDBId = ((wSspSelectBuyOrderItems_Result != null) ? wSspSelectBuyOrderItems_Result.bordILinkAccSettingDBId : new int?(0));
					}
					break;
				}
				case "SaleOrder":
				{
					WSspSelectOrderItems_Result wSspSelectOrderItems_Result = Enumerable.FirstOrDefault<WSspSelectOrderItems_Result>((IEnumerable<WSspSelectOrderItems_Result>)Enumerable.OrderByDescending<WSspSelectOrderItems_Result, int>((IEnumerable<WSspSelectOrderItems_Result>)_db.WSspSelectOrderItems(masterId, CS_0024_003C_003E8__locals0.currLangID, result), (Func<WSspSelectOrderItems_Result, int>)((WSspSelectOrderItems_Result m) => m.OrderItemID)));
					num = wSspSelectOrderItems_Result?.ordIPrdId ?? 0;
					if (result2 == 4)
					{
						CS_0024_003C_003E8__locals0.addProduct.LinkAccSettingDBId = ((wSspSelectOrderItems_Result != null) ? wSspSelectOrderItems_Result.ordILinkAccSettingDBId : new int?(0));
					}
					break;
				}
				case "UserPavProduct":
					num = prdId;
					break;
				case "StockSupply":
				{
					WSspSelectStockSupplyItems_Result wSspSelectStockSupplyItems_Result = Enumerable.FirstOrDefault<WSspSelectStockSupplyItems_Result>((IEnumerable<WSspSelectStockSupplyItems_Result>)Enumerable.OrderByDescending<WSspSelectStockSupplyItems_Result, int>((IEnumerable<WSspSelectStockSupplyItems_Result>)_dbII.WSspSelectStockSupplyItems(masterId, CS_0024_003C_003E8__locals0.currLangID, result), (Func<WSspSelectStockSupplyItems_Result, int>)((WSspSelectStockSupplyItems_Result m) => m.StockSupplyItemId)));
					num = wSspSelectStockSupplyItems_Result?.stsupIPrdId ?? 0;
					if (result2 == 4)
					{
						CS_0024_003C_003E8__locals0.addProduct.LinkAccSettingDBId = ((wSspSelectStockSupplyItems_Result != null) ? wSspSelectStockSupplyItems_Result.stsupILinkAccSettingDBId : new int?(0));
					}
					break;
				}
				default:
					num = 0;
					break;
				}
				DateTime now = DateTime.Now;
				CS_0024_003C_003E8__locals0.addProduct.UserId = UserLogin.CurrentUser.UserId;
				CS_0024_003C_003E8__locals0.addProduct.RegisterDate = now;
				CS_0024_003C_003E8__locals0.addProduct.AppType = Configuration.AppType;
				CS_0024_003C_003E8__locals0.addProduct.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
				CS_0024_003C_003E8__locals0.addProduct.FirstRegisterDate = now;
				CS_0024_003C_003E8__locals0.addProduct.ProductId = num;
			}
			else if (detailId > 0 && masterId > 0)
			{
				_003C_003Ec__DisplayClass10_1 _003C_003Ec__DisplayClass10_ = new _003C_003Ec__DisplayClass10_1();
				switch (masterForm)
				{
				case "preOrder":
					_003C_003Ec__DisplayClass10_.preOrderItem = _dbTbl.WSPreOrderItems.Find(detailId);
					if (_003C_003Ec__DisplayClass10_.preOrderItem != null)
					{
						CS_0024_003C_003E8__locals0.addProduct = new AddProductViewModel();
						CS_0024_003C_003E8__locals0.addProduct.ProductId = _003C_003Ec__DisplayClass10_.preOrderItem.pordIPrdId;
						CS_0024_003C_003E8__locals0.addProduct.MasterId = _003C_003Ec__DisplayClass10_.preOrderItem.PreOrderId;
						CS_0024_003C_003E8__locals0.addProduct.DetailId = _003C_003Ec__DisplayClass10_.preOrderItem.PreOrderItemID;
						double.TryParse(_003C_003Ec__DisplayClass10_.preOrderItem.pordIQuantity.ToString(), out var result5);
						CS_0024_003C_003E8__locals0.addProduct.Quantity = ((result5 > 0.0) ? result5 : 1.0);
						CS_0024_003C_003E8__locals0.addProduct.Price = _003C_003Ec__DisplayClass10_.preOrderItem.pordIPrice;
						CS_0024_003C_003E8__locals0.addProduct.DiscountPrecent = _003C_003Ec__DisplayClass10_.preOrderItem.pordIDiscountPercent;
						CS_0024_003C_003E8__locals0.addProduct.Discount = _003C_003Ec__DisplayClass10_.preOrderItem.pordIDiscount;
						CS_0024_003C_003E8__locals0.addProduct.Round = _003C_003Ec__DisplayClass10_.preOrderItem.pordIRound;
						CS_0024_003C_003E8__locals0.addProduct.RoundPlus = _003C_003Ec__DisplayClass10_.preOrderItem.pordIRoundPlus;
						CS_0024_003C_003E8__locals0.addProduct.TotalPrice = _003C_003Ec__DisplayClass10_.preOrderItem.pordITotalPrice;
						CS_0024_003C_003E8__locals0.addProduct.OrderView = _003C_003Ec__DisplayClass10_.preOrderItem.pordIOrderView;
						CS_0024_003C_003E8__locals0.addProduct.FCR = _003C_003Ec__DisplayClass10_.preOrderItem.pordIFCR;
						CS_0024_003C_003E8__locals0.addProduct.FCRI = _003C_003Ec__DisplayClass10_.preOrderItem.pordIFCRI;
						CS_0024_003C_003E8__locals0.addProduct.QuantityTotal = _003C_003Ec__DisplayClass10_.preOrderItem.pordIQuantityTotal;
						CS_0024_003C_003E8__locals0.addProduct.CalculateTax = _003C_003Ec__DisplayClass10_.preOrderItem.pordICalculateTax.HasValue && _003C_003Ec__DisplayClass10_.preOrderItem.pordICalculateTax != false;
						CS_0024_003C_003E8__locals0.addProduct.TaxIndex = _003C_003Ec__DisplayClass10_.preOrderItem.pordITaxIndex;
						CS_0024_003C_003E8__locals0.addProduct.Tax = _003C_003Ec__DisplayClass10_.preOrderItem.pordITax;
						CS_0024_003C_003E8__locals0.addProduct.SelectedNotVisible = _003C_003Ec__DisplayClass10_.preOrderItem.pordINotVisible.HasValue && _003C_003Ec__DisplayClass10_.preOrderItem.pordINotVisible != false;
						CS_0024_003C_003E8__locals0.addProduct.SelectedNotInSum = _003C_003Ec__DisplayClass10_.preOrderItem.pordINotInSum.HasValue && _003C_003Ec__DisplayClass10_.preOrderItem.pordINotInSum != false;
						CS_0024_003C_003E8__locals0.addProduct.PrdUnitId = _003C_003Ec__DisplayClass10_.preOrderItem.pordIPrdUnitId;
						CS_0024_003C_003E8__locals0.addProduct.CurrencyUnitId = _003C_003Ec__DisplayClass10_.preOrderItem.pordICurrencyUnitId;
						CS_0024_003C_003E8__locals0.addProduct.WHId = _003C_003Ec__DisplayClass10_.preOrderItem.pordIWHId;
						CS_0024_003C_003E8__locals0.addProduct.WHIdLinkAcc = _003C_003Ec__DisplayClass10_.preOrderItem.pordILinkAccWHIdStr;
						CS_0024_003C_003E8__locals0.addProduct.MasterForm = masterForm;
						CS_0024_003C_003E8__locals0.addProduct.Tracing = _003C_003Ec__DisplayClass10_.preOrderItem.pordITracing;
						CS_0024_003C_003E8__locals0.addProduct.ItemPrdWeight = _003C_003Ec__DisplayClass10_.preOrderItem.pordIPrdWeight;
						if (result2 == 4)
						{
							CS_0024_003C_003E8__locals0.addProduct.LinkAccSettingDBId = _003C_003Ec__DisplayClass10_.preOrderItem.pordILinkAccSettingDBId;
						}
						DbSet<WSPreOrderItems_Lang> wSPreOrderItems_Lang = _dbTbl.WSPreOrderItems_Lang;
						ParameterExpression val = Expression.Parameter(typeof(WSPreOrderItems_Lang), "c");
						List<WSPreOrderItems_Lang> list12 = Enumerable.ToList<WSPreOrderItems_Lang>((IEnumerable<WSPreOrderItems_Lang>)Queryable.Where<WSPreOrderItems_Lang>((IQueryable<WSPreOrderItems_Lang>)wSPreOrderItems_Lang, Expression.Lambda<Func<WSPreOrderItems_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass10_, typeof(_003C_003Ec__DisplayClass10_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
						List<CommonMultiLanguageViewModel> list13 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSPreOrderItems_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSPreOrderItems_Lang>)list12, (Func<WSPreOrderItems_Lang, CommonMultiLanguageViewModel>)((WSPreOrderItems_Lang item) => new CommonMultiLanguageViewModel
						{
							Value = item.pordIQuantityDesc,
							LanguageId = item.LanguageID
						})));
						list13.Add(new CommonMultiLanguageViewModel
						{
							Value = _003C_003Ec__DisplayClass10_.preOrderItem.pordIQuantityDesc,
							LanguageId = result
						});
						List<CommonMultiLanguageViewModel> list14 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSPreOrderItems_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSPreOrderItems_Lang>)list12, (Func<WSPreOrderItems_Lang, CommonMultiLanguageViewModel>)((WSPreOrderItems_Lang item) => new CommonMultiLanguageViewModel
						{
							Value = item.pordIDescription,
							LanguageId = item.LanguageID
						})));
						list14.Add(new CommonMultiLanguageViewModel
						{
							Value = _003C_003Ec__DisplayClass10_.preOrderItem.pordIDescription,
							LanguageId = result
						});
						List<CommonMultiLanguageViewModel> list15 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSPreOrderItems_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSPreOrderItems_Lang>)list12, (Func<WSPreOrderItems_Lang, CommonMultiLanguageViewModel>)((WSPreOrderItems_Lang item) => new CommonMultiLanguageViewModel
						{
							Value = item.pordIDescriptionI,
							LanguageId = item.LanguageID
						})));
						list15.Add(new CommonMultiLanguageViewModel
						{
							Value = _003C_003Ec__DisplayClass10_.preOrderItem.pordIDescriptionI,
							LanguageId = result
						});
						CS_0024_003C_003E8__locals0.addProduct.QuantityDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
						CS_0024_003C_003E8__locals0.addProduct.QuantityDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
						CS_0024_003C_003E8__locals0.addProduct.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
						CS_0024_003C_003E8__locals0.addProduct.Description_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
						CS_0024_003C_003E8__locals0.addProduct.DescriptionI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list15, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list15, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
						CS_0024_003C_003E8__locals0.addProduct.DescriptionI_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list15, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
						CS_0024_003C_003E8__locals0.addProduct.UserId = _003C_003Ec__DisplayClass10_.preOrderItem.UserId;
						CS_0024_003C_003E8__locals0.addProduct.RegisterDate = _003C_003Ec__DisplayClass10_.preOrderItem.RegisterDate;
						CS_0024_003C_003E8__locals0.addProduct.AppType = _003C_003Ec__DisplayClass10_.preOrderItem.AppType;
						CS_0024_003C_003E8__locals0.addProduct.FirstRegisterUserId = _003C_003Ec__DisplayClass10_.preOrderItem.FirstRegisterUserId;
						CS_0024_003C_003E8__locals0.addProduct.FirstRegisterDate = _003C_003Ec__DisplayClass10_.preOrderItem.FirstRegisterDate;
						CS_0024_003C_003E8__locals0.addProduct.PrdPriceGroupId = _003C_003Ec__DisplayClass10_.preOrderItem.pordIPrdPriceGroupID;
						CS_0024_003C_003E8__locals0.addProduct.DeliveryDate = _003C_003Ec__DisplayClass10_.preOrderItem.pordIDeliveryDate;
						CS_0024_003C_003E8__locals0.addProduct.DeliveryDatePersian = (_003C_003Ec__DisplayClass10_.preOrderItem.pordIDeliveryDate.HasValue ? _003C_003Ec__DisplayClass10_.preOrderItem.pordIDeliveryDate.Value.ToString("yyyy/MM/dd") : "");
						CS_0024_003C_003E8__locals0.addProduct.DeliveryTime = _003C_003Ec__DisplayClass10_.preOrderItem.pordIDeliveryTime;
						CS_0024_003C_003E8__locals0.addProduct.DeliveryDay = _003C_003Ec__DisplayClass10_.preOrderItem.pordIDeliveryDay;
						CS_0024_003C_003E8__locals0.addProduct.DeliveryEndDate = _003C_003Ec__DisplayClass10_.preOrderItem.pordIDeliveryEndDate;
						CS_0024_003C_003E8__locals0.addProduct.DeliveryEndDatePersian = (_003C_003Ec__DisplayClass10_.preOrderItem.pordIDeliveryEndDate.HasValue ? _003C_003Ec__DisplayClass10_.preOrderItem.pordIDeliveryEndDate.Value.ToString("yyyy/MM/dd") : "");
						CS_0024_003C_003E8__locals0.addProduct.DeliveryEndTime = _003C_003Ec__DisplayClass10_.preOrderItem.pordIDeliveryEndTime;
						CS_0024_003C_003E8__locals0.addProduct.DeliveryEndDay = _003C_003Ec__DisplayClass10_.preOrderItem.pordIDeliveryEndDay;
						CS_0024_003C_003E8__locals0.addProduct.DeliveryTermId = _003C_003Ec__DisplayClass10_.preOrderItem.pordIDeliveryTermId;
						CS_0024_003C_003E8__locals0.addProduct.PriceSum = _003C_003Ec__DisplayClass10_.preOrderItem.pordIPriceSum;
						CS_0024_003C_003E8__locals0.addProduct.DiscountSum = _003C_003Ec__DisplayClass10_.preOrderItem.pordIDiscountSum;
						CS_0024_003C_003E8__locals0.addProduct.DiscountISum = _003C_003Ec__DisplayClass10_.preOrderItem.pordIDiscountISum;
						CS_0024_003C_003E8__locals0.addProduct.TaxSum = _003C_003Ec__DisplayClass10_.preOrderItem.pordITaxSum;
						CS_0024_003C_003E8__locals0.addProduct.PrdColorId = _003C_003Ec__DisplayClass10_.preOrderItem.pordIPrdColorId;
						CS_0024_003C_003E8__locals0.addProduct.PrdUnitIdI = _003C_003Ec__DisplayClass10_.preOrderItem.pordIPrdUnitIdI;
						CS_0024_003C_003E8__locals0.addProduct.PrdUnitIRateResult = _003C_003Ec__DisplayClass10_.preOrderItem.pordIPrdUnitIRateResult;
						CS_0024_003C_003E8__locals0.addProduct.PrdUnitIdII = _003C_003Ec__DisplayClass10_.preOrderItem.pordIPrdUnitIdII;
						CS_0024_003C_003E8__locals0.addProduct.PrdUnitIIRateResult = _003C_003Ec__DisplayClass10_.preOrderItem.pordIPrdUnitIIRateResult;
						List<CommonMultiLanguageViewModel> list16 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSPreOrderItems_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSPreOrderItems_Lang>)list12, (Func<WSPreOrderItems_Lang, CommonMultiLanguageViewModel>)((WSPreOrderItems_Lang item) => new CommonMultiLanguageViewModel
						{
							Value = item.pordIPrdNickname,
							LanguageId = item.LanguageID
						})));
						list16.Add(new CommonMultiLanguageViewModel
						{
							Value = _003C_003Ec__DisplayClass10_.preOrderItem.pordIPrdNickname,
							LanguageId = result
						});
						CS_0024_003C_003E8__locals0.addProduct.PrdNickname = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list16, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list16, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
						CS_0024_003C_003E8__locals0.addProduct.PrdNickname_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list16, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
						CS_0024_003C_003E8__locals0.addProduct.ValidityExpireDate = _003C_003Ec__DisplayClass10_.preOrderItem.pordIValidityExpireDate;
						CS_0024_003C_003E8__locals0.addProduct.ValidityExpireDatePersian = (_003C_003Ec__DisplayClass10_.preOrderItem.pordIValidityExpireDate.HasValue ? _003C_003Ec__DisplayClass10_.preOrderItem.pordIValidityExpireDate.Value.ToString("yyyy/MM/dd") : "");
						CS_0024_003C_003E8__locals0.addProduct.ValidityExpireTime = (_003C_003Ec__DisplayClass10_.preOrderItem.pordIValidityExpireDate.HasValue ? _003C_003Ec__DisplayClass10_.preOrderItem.pordIValidityExpireDate.Value.ToString("HH:mm") : "");
						CS_0024_003C_003E8__locals0.addProduct.PrdAutoCalcRate = _003C_003Ec__DisplayClass10_.preOrderItem.pordIPrdAutoCalcRate;
						CS_0024_003C_003E8__locals0.addProduct.PrdAutoCalcInflationRateInfo = _003C_003Ec__DisplayClass10_.preOrderItem.pordIPrdAutoCalcInflationRateInfo;
						CS_0024_003C_003E8__locals0.addProduct.DiscountCodeId = _003C_003Ec__DisplayClass10_.preOrderItem.pordIDiscountCodeId;
						CS_0024_003C_003E8__locals0.addProduct.DiscountCode = "";
						if (CS_0024_003C_003E8__locals0.addProduct.DiscountCodeId > 0)
						{
							AddProductViewModel addProduct = CS_0024_003C_003E8__locals0.addProduct;
							DbSet<WSDiscountCode> wSDiscountCode = _dbTbl.WSDiscountCode;
							val = Expression.Parameter(typeof(WSDiscountCode), "x");
							addProduct.DiscountCode = Queryable.FirstOrDefault<WSDiscountCode>(Queryable.Where<WSDiscountCode>((IQueryable<WSDiscountCode>)wSDiscountCode, Expression.Lambda<Func<WSDiscountCode, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Convert((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), typeof(int?)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass10_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }))).DisCode;
						}
						CS_0024_003C_003E8__locals0.addProduct.DiscountCodeUserId = _003C_003Ec__DisplayClass10_.preOrderItem.pordIDiscountCodeUserId;
						CS_0024_003C_003E8__locals0.addProduct.DiscountCodeRegisterDate = _003C_003Ec__DisplayClass10_.preOrderItem.pordIDiscountCodeRegisterDate;
						CS_0024_003C_003E8__locals0.addProduct.DiscountCodeRegisterDatePersian = _003C_003Ec__DisplayClass10_.preOrderItem.pordIDiscountCodeRegisterDatePersian;
						CS_0024_003C_003E8__locals0.addProduct.SaleCenterId = _003C_003Ec__DisplayClass10_.preOrderItem.pordISaleCenterId;
						CS_0024_003C_003E8__locals0.addProduct.PrdPriceCurrencyRate = _003C_003Ec__DisplayClass10_.preOrderItem.pordIPriceCurrencyRate;
					}
					break;
				case "SaleOrder":
					_003C_003Ec__DisplayClass10_.orderItem = _dbTbl.WSOrderItems.Find(detailId);
					if (_003C_003Ec__DisplayClass10_.orderItem != null)
					{
						CS_0024_003C_003E8__locals0.addProduct = new AddProductViewModel();
						CS_0024_003C_003E8__locals0.addProduct.ProductId = _003C_003Ec__DisplayClass10_.orderItem.ordIPrdId;
						CS_0024_003C_003E8__locals0.addProduct.MasterId = _003C_003Ec__DisplayClass10_.orderItem.OrderId;
						CS_0024_003C_003E8__locals0.addProduct.DetailId = _003C_003Ec__DisplayClass10_.orderItem.OrderItemID;
						double.TryParse(_003C_003Ec__DisplayClass10_.orderItem.ordIQuantity.ToString(), out var result6);
						CS_0024_003C_003E8__locals0.addProduct.Quantity = ((result6 > 0.0) ? result6 : 1.0);
						CS_0024_003C_003E8__locals0.addProduct.Price = _003C_003Ec__DisplayClass10_.orderItem.ordIPrice;
						CS_0024_003C_003E8__locals0.addProduct.DiscountPrecent = _003C_003Ec__DisplayClass10_.orderItem.ordIDiscountPercent;
						CS_0024_003C_003E8__locals0.addProduct.Discount = _003C_003Ec__DisplayClass10_.orderItem.ordIDiscount;
						CS_0024_003C_003E8__locals0.addProduct.Round = _003C_003Ec__DisplayClass10_.orderItem.ordIRound;
						CS_0024_003C_003E8__locals0.addProduct.RoundPlus = _003C_003Ec__DisplayClass10_.orderItem.ordIRoundPlus;
						CS_0024_003C_003E8__locals0.addProduct.TotalPrice = _003C_003Ec__DisplayClass10_.orderItem.ordITotalPrice;
						CS_0024_003C_003E8__locals0.addProduct.OrderView = _003C_003Ec__DisplayClass10_.orderItem.ordIOrderView;
						CS_0024_003C_003E8__locals0.addProduct.FCR = _003C_003Ec__DisplayClass10_.orderItem.ordIFCR;
						CS_0024_003C_003E8__locals0.addProduct.FCRI = _003C_003Ec__DisplayClass10_.orderItem.ordIFCRI;
						CS_0024_003C_003E8__locals0.addProduct.QuantityTotal = _003C_003Ec__DisplayClass10_.orderItem.ordIQuantityTotal;
						CS_0024_003C_003E8__locals0.addProduct.CalculateTax = _003C_003Ec__DisplayClass10_.orderItem.ordICalculateTax.HasValue && _003C_003Ec__DisplayClass10_.orderItem.ordICalculateTax != false;
						CS_0024_003C_003E8__locals0.addProduct.TaxIndex = _003C_003Ec__DisplayClass10_.orderItem.ordITaxIndex;
						CS_0024_003C_003E8__locals0.addProduct.Tax = _003C_003Ec__DisplayClass10_.orderItem.ordITax;
						CS_0024_003C_003E8__locals0.addProduct.SelectedNotVisible = _003C_003Ec__DisplayClass10_.orderItem.ordINotVisible.HasValue && _003C_003Ec__DisplayClass10_.orderItem.ordINotVisible != false;
						CS_0024_003C_003E8__locals0.addProduct.SelectedNotInSum = _003C_003Ec__DisplayClass10_.orderItem.ordINotInSum.HasValue && _003C_003Ec__DisplayClass10_.orderItem.ordINotInSum != false;
						CS_0024_003C_003E8__locals0.addProduct.PrdUnitId = _003C_003Ec__DisplayClass10_.orderItem.ordIPrdUnitId;
						CS_0024_003C_003E8__locals0.addProduct.CurrencyUnitId = _003C_003Ec__DisplayClass10_.orderItem.ordICurrencyUnitId;
						CS_0024_003C_003E8__locals0.addProduct.WHId = _003C_003Ec__DisplayClass10_.orderItem.ordIWHId;
						CS_0024_003C_003E8__locals0.addProduct.WHIdLinkAcc = _003C_003Ec__DisplayClass10_.orderItem.ordILinkAccWHIdStr;
						CS_0024_003C_003E8__locals0.addProduct.MasterForm = masterForm;
						CS_0024_003C_003E8__locals0.addProduct.Tracing = _003C_003Ec__DisplayClass10_.orderItem.ordITracing;
						CS_0024_003C_003E8__locals0.addProduct.ItemPrdWeight = _003C_003Ec__DisplayClass10_.orderItem.ordIPrdWeight;
						if (result2 == 4)
						{
							CS_0024_003C_003E8__locals0.addProduct.LinkAccSettingDBId = _003C_003Ec__DisplayClass10_.orderItem.ordILinkAccSettingDBId;
						}
						DbSet<WSOrderItems_Lang> wSOrderItems_Lang = _dbTbl.WSOrderItems_Lang;
						ParameterExpression val = Expression.Parameter(typeof(WSOrderItems_Lang), "c");
						List<WSOrderItems_Lang> list17 = Enumerable.ToList<WSOrderItems_Lang>((IEnumerable<WSOrderItems_Lang>)Queryable.Where<WSOrderItems_Lang>((IQueryable<WSOrderItems_Lang>)wSOrderItems_Lang, Expression.Lambda<Func<WSOrderItems_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass10_, typeof(_003C_003Ec__DisplayClass10_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
						List<CommonMultiLanguageViewModel> list18 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSOrderItems_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSOrderItems_Lang>)list17, (Func<WSOrderItems_Lang, CommonMultiLanguageViewModel>)((WSOrderItems_Lang item) => new CommonMultiLanguageViewModel
						{
							Value = item.ordIQuantityDesc,
							LanguageId = item.LanguageID
						})));
						list18.Add(new CommonMultiLanguageViewModel
						{
							Value = _003C_003Ec__DisplayClass10_.orderItem.ordIQuantityDesc,
							LanguageId = result
						});
						List<CommonMultiLanguageViewModel> list19 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSOrderItems_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSOrderItems_Lang>)list17, (Func<WSOrderItems_Lang, CommonMultiLanguageViewModel>)((WSOrderItems_Lang item) => new CommonMultiLanguageViewModel
						{
							Value = item.ordIDescription,
							LanguageId = item.LanguageID
						})));
						list19.Add(new CommonMultiLanguageViewModel
						{
							Value = _003C_003Ec__DisplayClass10_.orderItem.ordIDescription,
							LanguageId = result
						});
						List<CommonMultiLanguageViewModel> list20 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSOrderItems_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSOrderItems_Lang>)list17, (Func<WSOrderItems_Lang, CommonMultiLanguageViewModel>)((WSOrderItems_Lang item) => new CommonMultiLanguageViewModel
						{
							Value = item.ordIDescriptionI,
							LanguageId = item.LanguageID
						})));
						list20.Add(new CommonMultiLanguageViewModel
						{
							Value = _003C_003Ec__DisplayClass10_.orderItem.ordIDescriptionI,
							LanguageId = result
						});
						CS_0024_003C_003E8__locals0.addProduct.QuantityDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list18, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list18, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
						CS_0024_003C_003E8__locals0.addProduct.QuantityDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list18, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
						CS_0024_003C_003E8__locals0.addProduct.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list19, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list19, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
						CS_0024_003C_003E8__locals0.addProduct.Description_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list19, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
						CS_0024_003C_003E8__locals0.addProduct.DescriptionI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list20, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list20, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
						CS_0024_003C_003E8__locals0.addProduct.DescriptionI_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list20, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
						CS_0024_003C_003E8__locals0.addProduct.UserId = _003C_003Ec__DisplayClass10_.orderItem.UserId;
						CS_0024_003C_003E8__locals0.addProduct.RegisterDate = _003C_003Ec__DisplayClass10_.orderItem.RegisterDate;
						CS_0024_003C_003E8__locals0.addProduct.AppType = _003C_003Ec__DisplayClass10_.orderItem.AppType;
						CS_0024_003C_003E8__locals0.addProduct.FirstRegisterUserId = _003C_003Ec__DisplayClass10_.orderItem.FirstRegisterUserId;
						CS_0024_003C_003E8__locals0.addProduct.FirstRegisterDate = _003C_003Ec__DisplayClass10_.orderItem.FirstRegisterDate;
						CS_0024_003C_003E8__locals0.addProduct.PricePartRate = _003C_003Ec__DisplayClass10_.orderItem.ordIPricePartRate;
						CS_0024_003C_003E8__locals0.addProduct.PricePartI = _003C_003Ec__DisplayClass10_.orderItem.ordIPricePartI;
						CS_0024_003C_003E8__locals0.addProduct.PricePartII = _003C_003Ec__DisplayClass10_.orderItem.ordIPricePartII;
						CS_0024_003C_003E8__locals0.addProduct.PrdPriceGroupId = _003C_003Ec__DisplayClass10_.orderItem.ordIPrdPriceGroupID;
						CS_0024_003C_003E8__locals0.addProduct.DeliveryDate = _003C_003Ec__DisplayClass10_.orderItem.ordIDeliveryDate;
						CS_0024_003C_003E8__locals0.addProduct.DeliveryDatePersian = (_003C_003Ec__DisplayClass10_.orderItem.ordIDeliveryDate.HasValue ? _003C_003Ec__DisplayClass10_.orderItem.ordIDeliveryDate.Value.ToString("yyyy/MM/dd") : "");
						CS_0024_003C_003E8__locals0.addProduct.DeliveryTime = _003C_003Ec__DisplayClass10_.orderItem.ordIDeliveryTime;
						CS_0024_003C_003E8__locals0.addProduct.DeliveryDay = _003C_003Ec__DisplayClass10_.orderItem.ordIDeliveryDay;
						CS_0024_003C_003E8__locals0.addProduct.DeliveryEndDate = _003C_003Ec__DisplayClass10_.orderItem.ordIDeliveryEndDate;
						CS_0024_003C_003E8__locals0.addProduct.DeliveryEndDatePersian = (_003C_003Ec__DisplayClass10_.orderItem.ordIDeliveryEndDate.HasValue ? _003C_003Ec__DisplayClass10_.orderItem.ordIDeliveryEndDate.Value.ToString("yyyy/MM/dd") : "");
						CS_0024_003C_003E8__locals0.addProduct.DeliveryEndTime = _003C_003Ec__DisplayClass10_.orderItem.ordIDeliveryEndTime;
						CS_0024_003C_003E8__locals0.addProduct.DeliveryEndDay = _003C_003Ec__DisplayClass10_.orderItem.ordIDeliveryEndDay;
						CS_0024_003C_003E8__locals0.addProduct.DeliveryTermId = _003C_003Ec__DisplayClass10_.orderItem.ordIDeliveryTermId;
						CS_0024_003C_003E8__locals0.addProduct.PrdDeliveryUserId = _003C_003Ec__DisplayClass10_.orderItem.ordIDeliveryUserId;
						CS_0024_003C_003E8__locals0.addProduct.PriceSum = _003C_003Ec__DisplayClass10_.orderItem.ordIPriceSum;
						CS_0024_003C_003E8__locals0.addProduct.DiscountSum = _003C_003Ec__DisplayClass10_.orderItem.ordIDiscountSum;
						CS_0024_003C_003E8__locals0.addProduct.DiscountISum = _003C_003Ec__DisplayClass10_.orderItem.ordIDiscountISum;
						CS_0024_003C_003E8__locals0.addProduct.TaxSum = _003C_003Ec__DisplayClass10_.orderItem.ordITaxSum;
						CS_0024_003C_003E8__locals0.addProduct.ValidityExpireDate = _003C_003Ec__DisplayClass10_.orderItem.ordIValidityExpireDate;
						CS_0024_003C_003E8__locals0.addProduct.ValidityExpireDatePersian = (_003C_003Ec__DisplayClass10_.orderItem.ordIValidityExpireDate.HasValue ? _003C_003Ec__DisplayClass10_.orderItem.ordIValidityExpireDate.Value.ToString("yyyy/MM/dd") : "");
						CS_0024_003C_003E8__locals0.addProduct.ValidityExpireTime = (_003C_003Ec__DisplayClass10_.orderItem.ordIValidityExpireDate.HasValue ? _003C_003Ec__DisplayClass10_.orderItem.ordIValidityExpireDate.Value.ToString("HH:mm") : "");
						CS_0024_003C_003E8__locals0.addProduct.PrdColorId = _003C_003Ec__DisplayClass10_.orderItem.ordIPrdColorId;
						CS_0024_003C_003E8__locals0.addProduct.PrdUnitIdI = _003C_003Ec__DisplayClass10_.orderItem.ordIPrdUnitIdI;
						CS_0024_003C_003E8__locals0.addProduct.PrdUnitIRateResult = _003C_003Ec__DisplayClass10_.orderItem.ordIPrdUnitIRateResult;
						CS_0024_003C_003E8__locals0.addProduct.PrdUnitIdII = _003C_003Ec__DisplayClass10_.orderItem.ordIPrdUnitIdII;
						CS_0024_003C_003E8__locals0.addProduct.PrdUnitIIRateResult = _003C_003Ec__DisplayClass10_.orderItem.ordIPrdUnitIIRateResult;
						CS_0024_003C_003E8__locals0.addProduct.PrdValidityCountingNum = _003C_003Ec__DisplayClass10_.orderItem.ordIPrdValidityCountingNum;
						CS_0024_003C_003E8__locals0.addProduct.PrdValidityCountingMin = _003C_003Ec__DisplayClass10_.orderItem.ordIPrdValidityCountingMin;
						List<CommonMultiLanguageViewModel> list21 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSOrderItems_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSOrderItems_Lang>)list17, (Func<WSOrderItems_Lang, CommonMultiLanguageViewModel>)((WSOrderItems_Lang item) => new CommonMultiLanguageViewModel
						{
							Value = item.ordIPrdNickname,
							LanguageId = item.LanguageID
						})));
						list21.Add(new CommonMultiLanguageViewModel
						{
							Value = _003C_003Ec__DisplayClass10_.orderItem.ordIPrdNickname,
							LanguageId = result
						});
						CS_0024_003C_003E8__locals0.addProduct.PrdNickname = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list21, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list21, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
						CS_0024_003C_003E8__locals0.addProduct.PrdNickname_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list21, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
						CS_0024_003C_003E8__locals0.addProduct.TspCfee = _003C_003Ec__DisplayClass10_.orderItem.TspOrdICfee;
						CS_0024_003C_003E8__locals0.addProduct.TspCut = _003C_003Ec__DisplayClass10_.orderItem.TspOrdICut;
						CS_0024_003C_003E8__locals0.addProduct.TspExr = _003C_003Ec__DisplayClass10_.orderItem.TspOrdIExr;
						CS_0024_003C_003E8__locals0.addProduct.TspOdt = _003C_003Ec__DisplayClass10_.orderItem.TspOrdIOdt;
						CS_0024_003C_003E8__locals0.addProduct.TspOdr = _003C_003Ec__DisplayClass10_.orderItem.TspOrdIOdr;
						CS_0024_003C_003E8__locals0.addProduct.TspOdam = _003C_003Ec__DisplayClass10_.orderItem.TspOrdIOdam;
						CS_0024_003C_003E8__locals0.addProduct.TspOlt = _003C_003Ec__DisplayClass10_.orderItem.TspOrdIOlt;
						CS_0024_003C_003E8__locals0.addProduct.TspOlr = _003C_003Ec__DisplayClass10_.orderItem.TspOrdIOlr;
						CS_0024_003C_003E8__locals0.addProduct.TspOlam = _003C_003Ec__DisplayClass10_.orderItem.TspOrdIOlam;
						CS_0024_003C_003E8__locals0.addProduct.TspConsfee = _003C_003Ec__DisplayClass10_.orderItem.TspOrdIConsfee;
						CS_0024_003C_003E8__locals0.addProduct.TspSpro = _003C_003Ec__DisplayClass10_.orderItem.TspOrdISpro;
						CS_0024_003C_003E8__locals0.addProduct.TspBros = _003C_003Ec__DisplayClass10_.orderItem.TspOrdIBros;
						CS_0024_003C_003E8__locals0.addProduct.TspCop = _003C_003Ec__DisplayClass10_.orderItem.TspOrdICop;
						CS_0024_003C_003E8__locals0.addProduct.TspVop = _003C_003Ec__DisplayClass10_.orderItem.TspOrdIVop;
						CS_0024_003C_003E8__locals0.addProduct.TspNw = _003C_003Ec__DisplayClass10_.orderItem.TspOrdINw;
						CS_0024_003C_003E8__locals0.addProduct.TspSsrv = _003C_003Ec__DisplayClass10_.orderItem.TspOrdISsrv;
						CS_0024_003C_003E8__locals0.addProduct.TspSscv = _003C_003Ec__DisplayClass10_.orderItem.TspOrdISscv;
						CS_0024_003C_003E8__locals0.addProduct.PrdAutoCalcRate = _003C_003Ec__DisplayClass10_.orderItem.ordIPrdAutoCalcRate;
						CS_0024_003C_003E8__locals0.addProduct.PrdAutoCalcInflationRateInfo = _003C_003Ec__DisplayClass10_.orderItem.ordIPrdAutoCalcInflationRateInfo;
						CS_0024_003C_003E8__locals0.addProduct.PrdDeActiveModuleInReg = _003C_003Ec__DisplayClass10_.orderItem.ordIDeActiveModuleInReg;
						CS_0024_003C_003E8__locals0.addProduct.TspPspd = _003C_003Ec__DisplayClass10_.orderItem.TspOrdIPspd;
						CS_0024_003C_003E8__locals0.addProduct.TspCui = _003C_003Ec__DisplayClass10_.orderItem.TspOrdICui;
						CS_0024_003C_003E8__locals0.addProduct.TspBsrn = _003C_003Ec__DisplayClass10_.orderItem.TspOrdIBsrn;
						CS_0024_003C_003E8__locals0.addProduct.BuyOrderItemIds = _003C_003Ec__DisplayClass10_.orderItem.BuyOrderItemIds;
						CS_0024_003C_003E8__locals0.addProduct.OrdIWhId = CS_0024_003C_003E8__locals0.addProduct.WHId;
						List<WSspSelectOrderItemSerialsByOrderItemId_Result> list22 = Enumerable.ToList<WSspSelectOrderItemSerialsByOrderItemId_Result>((IEnumerable<WSspSelectOrderItemSerialsByOrderItemId_Result>)_db.WSspSelectOrderItemSerialsByOrderItemId(CS_0024_003C_003E8__locals0.addProduct.DetailId, CS_0024_003C_003E8__locals0.currLangID, result));
						if (list22 != null && Enumerable.Any<WSspSelectOrderItemSerialsByOrderItemId_Result>((IEnumerable<WSspSelectOrderItemSerialsByOrderItemId_Result>)list22))
						{
							CS_0024_003C_003E8__locals0.addProduct.HaveSerial = 1;
						}
						CS_0024_003C_003E8__locals0.addProduct.DiscountCodeId = _003C_003Ec__DisplayClass10_.orderItem.ordIDiscountCodeId;
						CS_0024_003C_003E8__locals0.addProduct.DiscountCode = "";
						if (CS_0024_003C_003E8__locals0.addProduct.DiscountCodeId > 0)
						{
							AddProductViewModel addProduct2 = CS_0024_003C_003E8__locals0.addProduct;
							DbSet<WSDiscountCode> wSDiscountCode2 = _dbTbl.WSDiscountCode;
							val = Expression.Parameter(typeof(WSDiscountCode), "x");
							addProduct2.DiscountCode = Queryable.FirstOrDefault<WSDiscountCode>(Queryable.Where<WSDiscountCode>((IQueryable<WSDiscountCode>)wSDiscountCode2, Expression.Lambda<Func<WSDiscountCode, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Convert((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), typeof(int?)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass10_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }))).DisCode;
						}
						CS_0024_003C_003E8__locals0.addProduct.DiscountCodeUserId = _003C_003Ec__DisplayClass10_.orderItem.ordIDiscountCodeUserId;
						CS_0024_003C_003E8__locals0.addProduct.DiscountCodeRegisterDate = _003C_003Ec__DisplayClass10_.orderItem.ordIDiscountCodeRegisterDate;
						CS_0024_003C_003E8__locals0.addProduct.DiscountCodeRegisterDatePersian = _003C_003Ec__DisplayClass10_.orderItem.ordIDiscountCodeRegisterDatePersian;
						CS_0024_003C_003E8__locals0.addProduct.SaleCenterId = _003C_003Ec__DisplayClass10_.orderItem.ordISaleCenterId;
						CS_0024_003C_003E8__locals0.addProduct.PrdPriceCurrencyRate = _003C_003Ec__DisplayClass10_.orderItem.ordIPriceCurrencyRate;
					}
					break;
				case "BuyOrder":
					_003C_003Ec__DisplayClass10_.buyOrderItem = _dbTbl.WSBuyOrderItems.Find(detailId);
					if (_003C_003Ec__DisplayClass10_.buyOrderItem != null)
					{
						CS_0024_003C_003E8__locals0.addProduct = new AddProductViewModel();
						CS_0024_003C_003E8__locals0.addProduct.ProductId = _003C_003Ec__DisplayClass10_.buyOrderItem.bordIPrdId;
						CS_0024_003C_003E8__locals0.addProduct.MasterId = _003C_003Ec__DisplayClass10_.buyOrderItem.BuyOrderId;
						CS_0024_003C_003E8__locals0.addProduct.DetailId = _003C_003Ec__DisplayClass10_.buyOrderItem.BuyOrderItemId;
						double.TryParse(_003C_003Ec__DisplayClass10_.buyOrderItem.bordIQuantity.ToString(), out var result4);
						CS_0024_003C_003E8__locals0.addProduct.Quantity = ((result4 > 0.0) ? result4 : 1.0);
						CS_0024_003C_003E8__locals0.addProduct.Price = _003C_003Ec__DisplayClass10_.buyOrderItem.bordICost;
						CS_0024_003C_003E8__locals0.addProduct.DiscountPrecent = _003C_003Ec__DisplayClass10_.buyOrderItem.bordIDiscountPercent;
						CS_0024_003C_003E8__locals0.addProduct.Discount = _003C_003Ec__DisplayClass10_.buyOrderItem.bordIDiscount;
						CS_0024_003C_003E8__locals0.addProduct.TotalPrice = _003C_003Ec__DisplayClass10_.buyOrderItem.bordITotalCost;
						CS_0024_003C_003E8__locals0.addProduct.OrderView = _003C_003Ec__DisplayClass10_.buyOrderItem.bordIOrderView;
						CS_0024_003C_003E8__locals0.addProduct.FCR = _003C_003Ec__DisplayClass10_.buyOrderItem.bordIFCR;
						CS_0024_003C_003E8__locals0.addProduct.FCRI = _003C_003Ec__DisplayClass10_.buyOrderItem.bordIFCRI;
						CS_0024_003C_003E8__locals0.addProduct.QuantityTotal = _003C_003Ec__DisplayClass10_.buyOrderItem.bordIQuantityTotal;
						CS_0024_003C_003E8__locals0.addProduct.CalculateTax = _003C_003Ec__DisplayClass10_.buyOrderItem.bordICalculateTax.HasValue && _003C_003Ec__DisplayClass10_.buyOrderItem.bordICalculateTax != false;
						CS_0024_003C_003E8__locals0.addProduct.TaxIndex = _003C_003Ec__DisplayClass10_.buyOrderItem.bordITaxIndex;
						CS_0024_003C_003E8__locals0.addProduct.Tax = _003C_003Ec__DisplayClass10_.buyOrderItem.bordITax;
						CS_0024_003C_003E8__locals0.addProduct.SelectedNotVisible = _003C_003Ec__DisplayClass10_.buyOrderItem.bordINotVisible.HasValue && _003C_003Ec__DisplayClass10_.buyOrderItem.bordINotVisible != false;
						CS_0024_003C_003E8__locals0.addProduct.SelectedNotInSum = _003C_003Ec__DisplayClass10_.buyOrderItem.bordINotInSum.HasValue && _003C_003Ec__DisplayClass10_.buyOrderItem.bordINotInSum != false;
						CS_0024_003C_003E8__locals0.addProduct.PrdUnitId = _003C_003Ec__DisplayClass10_.buyOrderItem.bordIPrdUnitId;
						CS_0024_003C_003E8__locals0.addProduct.CurrencyUnitId = _003C_003Ec__DisplayClass10_.buyOrderItem.bordICurrencyUnitId;
						CS_0024_003C_003E8__locals0.addProduct.WHId = _003C_003Ec__DisplayClass10_.buyOrderItem.bordIWHId;
						CS_0024_003C_003E8__locals0.addProduct.WHIdLinkAcc = _003C_003Ec__DisplayClass10_.buyOrderItem.bordILinkAccWHIdStr;
						CS_0024_003C_003E8__locals0.addProduct.MasterForm = masterForm;
						CS_0024_003C_003E8__locals0.addProduct.Tracing = _003C_003Ec__DisplayClass10_.buyOrderItem.bordITracing;
						CS_0024_003C_003E8__locals0.addProduct.ItemPrdWeight = _003C_003Ec__DisplayClass10_.buyOrderItem.bordIPrdWeight;
						if (result2 == 4)
						{
							CS_0024_003C_003E8__locals0.addProduct.LinkAccSettingDBId = _003C_003Ec__DisplayClass10_.buyOrderItem.bordILinkAccSettingDBId;
						}
						DbSet<WSBuyOrderItems_Lang> wSBuyOrderItems_Lang = _dbTbl.WSBuyOrderItems_Lang;
						ParameterExpression val = Expression.Parameter(typeof(WSBuyOrderItems_Lang), "c");
						List<WSBuyOrderItems_Lang> list5 = Enumerable.ToList<WSBuyOrderItems_Lang>((IEnumerable<WSBuyOrderItems_Lang>)Queryable.Where<WSBuyOrderItems_Lang>((IQueryable<WSBuyOrderItems_Lang>)wSBuyOrderItems_Lang, Expression.Lambda<Func<WSBuyOrderItems_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass10_, typeof(_003C_003Ec__DisplayClass10_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
						List<CommonMultiLanguageViewModel> list6 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSBuyOrderItems_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSBuyOrderItems_Lang>)list5, (Func<WSBuyOrderItems_Lang, CommonMultiLanguageViewModel>)((WSBuyOrderItems_Lang item) => new CommonMultiLanguageViewModel
						{
							Value = item.bordIQuantityDesc,
							LanguageId = item.LanguageID
						})));
						list6.Add(new CommonMultiLanguageViewModel
						{
							Value = _003C_003Ec__DisplayClass10_.buyOrderItem.bordIQuantityDesc,
							LanguageId = result
						});
						List<CommonMultiLanguageViewModel> list7 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSBuyOrderItems_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSBuyOrderItems_Lang>)list5, (Func<WSBuyOrderItems_Lang, CommonMultiLanguageViewModel>)((WSBuyOrderItems_Lang item) => new CommonMultiLanguageViewModel
						{
							Value = item.bordIDescription,
							LanguageId = item.LanguageID
						})));
						list7.Add(new CommonMultiLanguageViewModel
						{
							Value = _003C_003Ec__DisplayClass10_.buyOrderItem.bordIDescription,
							LanguageId = result
						});
						CS_0024_003C_003E8__locals0.addProduct.QuantityDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
						CS_0024_003C_003E8__locals0.addProduct.QuantityDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
						CS_0024_003C_003E8__locals0.addProduct.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
						CS_0024_003C_003E8__locals0.addProduct.Description_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
						CS_0024_003C_003E8__locals0.addProduct.UserId = _003C_003Ec__DisplayClass10_.buyOrderItem.UserId;
						CS_0024_003C_003E8__locals0.addProduct.RegisterDate = _003C_003Ec__DisplayClass10_.buyOrderItem.RegisterDate;
						CS_0024_003C_003E8__locals0.addProduct.AppType = _003C_003Ec__DisplayClass10_.buyOrderItem.AppType;
						CS_0024_003C_003E8__locals0.addProduct.FirstRegisterUserId = _003C_003Ec__DisplayClass10_.buyOrderItem.FirstRegisterUserId;
						CS_0024_003C_003E8__locals0.addProduct.FirstRegisterDate = _003C_003Ec__DisplayClass10_.buyOrderItem.FirstRegisterDate;
						CS_0024_003C_003E8__locals0.addProduct.PrdPriceGroupId = _003C_003Ec__DisplayClass10_.buyOrderItem.bordIPrdCostGroupID;
						List<CommonMultiLanguageViewModel> list8 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSBuyOrderItems_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSBuyOrderItems_Lang>)list5, (Func<WSBuyOrderItems_Lang, CommonMultiLanguageViewModel>)((WSBuyOrderItems_Lang item) => new CommonMultiLanguageViewModel
						{
							Value = item.bordIForwarderName,
							LanguageId = item.LanguageID
						})));
						list8.Add(new CommonMultiLanguageViewModel
						{
							Value = _003C_003Ec__DisplayClass10_.buyOrderItem.bordIForwarderName,
							LanguageId = result
						});
						List<CommonMultiLanguageViewModel> list9 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSBuyOrderItems_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSBuyOrderItems_Lang>)list5, (Func<WSBuyOrderItems_Lang, CommonMultiLanguageViewModel>)((WSBuyOrderItems_Lang item) => new CommonMultiLanguageViewModel
						{
							Value = item.bordICustomsPart,
							LanguageId = item.LanguageID
						})));
						list9.Add(new CommonMultiLanguageViewModel
						{
							Value = _003C_003Ec__DisplayClass10_.buyOrderItem.bordICustomsPart,
							LanguageId = result
						});
						CS_0024_003C_003E8__locals0.addProduct.TaxCleared = _003C_003Ec__DisplayClass10_.buyOrderItem.bordITaxCleared;
						CS_0024_003C_003E8__locals0.addProduct.TaxClearedDate = _003C_003Ec__DisplayClass10_.buyOrderItem.bordITaxClearedDate;
						CS_0024_003C_003E8__locals0.addProduct.TaxClearedDatePersian = (_003C_003Ec__DisplayClass10_.buyOrderItem.bordITaxClearedDate.HasValue ? _003C_003Ec__DisplayClass10_.buyOrderItem.bordITaxClearedDate.Value.ToString("yyyy/MM/dd") : "");
						CS_0024_003C_003E8__locals0.addProduct.FacilityCost = _003C_003Ec__DisplayClass10_.buyOrderItem.bordIFacilityCost;
						CS_0024_003C_003E8__locals0.addProduct.FacilityCostPercent = _003C_003Ec__DisplayClass10_.buyOrderItem.bordIFacilityCostPercent;
						CS_0024_003C_003E8__locals0.addProduct.ForwarderName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
						CS_0024_003C_003E8__locals0.addProduct.ForwarderName_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
						CS_0024_003C_003E8__locals0.addProduct.FreightCost = _003C_003Ec__DisplayClass10_.buyOrderItem.bordIFreightCost;
						CS_0024_003C_003E8__locals0.addProduct.FreightCurrUnId = _003C_003Ec__DisplayClass10_.buyOrderItem.bordIFreightCurrUnId;
						CS_0024_003C_003E8__locals0.addProduct.FreightCurrencyRate = _003C_003Ec__DisplayClass10_.buyOrderItem.bordIFreightCurrencyRate;
						CS_0024_003C_003E8__locals0.addProduct.FinalFreightCost = _003C_003Ec__DisplayClass10_.buyOrderItem.bordIFinalFreightCost;
						CS_0024_003C_003E8__locals0.addProduct.CustomsPart = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
						CS_0024_003C_003E8__locals0.addProduct.CustomsPart_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
						CS_0024_003C_003E8__locals0.addProduct.CustomsFee = _003C_003Ec__DisplayClass10_.buyOrderItem.bordICustomsFee;
						CS_0024_003C_003E8__locals0.addProduct.CustomsCurrUnId = _003C_003Ec__DisplayClass10_.buyOrderItem.bordICustomsCurrUnId;
						CS_0024_003C_003E8__locals0.addProduct.CustomsCurrencyRate = _003C_003Ec__DisplayClass10_.buyOrderItem.bordICustomsCurrencyRate;
						CS_0024_003C_003E8__locals0.addProduct.FinalCustomsFee = _003C_003Ec__DisplayClass10_.buyOrderItem.bordIFinalCustomsFee;
						CS_0024_003C_003E8__locals0.addProduct.Commission = _003C_003Ec__DisplayClass10_.buyOrderItem.bordICommission;
						CS_0024_003C_003E8__locals0.addProduct.CommissionCurrUnId = _003C_003Ec__DisplayClass10_.buyOrderItem.bordICommissionCurrUnId;
						CS_0024_003C_003E8__locals0.addProduct.CommissionCurrencyRate = _003C_003Ec__DisplayClass10_.buyOrderItem.bordICommissionCurrencyRate;
						CS_0024_003C_003E8__locals0.addProduct.FinalCommission = _003C_003Ec__DisplayClass10_.buyOrderItem.bordIFinalCommission;
						CS_0024_003C_003E8__locals0.addProduct.PriceSum = _003C_003Ec__DisplayClass10_.buyOrderItem.bordICostSum;
						CS_0024_003C_003E8__locals0.addProduct.DiscountSum = _003C_003Ec__DisplayClass10_.buyOrderItem.bordIDiscountSum;
						CS_0024_003C_003E8__locals0.addProduct.DiscountISum = _003C_003Ec__DisplayClass10_.buyOrderItem.bordIDiscountISum;
						CS_0024_003C_003E8__locals0.addProduct.TaxSum = _003C_003Ec__DisplayClass10_.buyOrderItem.bordITaxSum;
						CS_0024_003C_003E8__locals0.addProduct.PrdColorId = _003C_003Ec__DisplayClass10_.buyOrderItem.bordIPrdColorId;
						CS_0024_003C_003E8__locals0.addProduct.PrdUnitIdI = _003C_003Ec__DisplayClass10_.buyOrderItem.bordIPrdUnitIdI;
						CS_0024_003C_003E8__locals0.addProduct.PrdUnitIRateResult = _003C_003Ec__DisplayClass10_.buyOrderItem.bordIPrdUnitIRateResult;
						CS_0024_003C_003E8__locals0.addProduct.PrdUnitIdII = _003C_003Ec__DisplayClass10_.buyOrderItem.bordIPrdUnitIdII;
						CS_0024_003C_003E8__locals0.addProduct.PrdUnitIIRateResult = _003C_003Ec__DisplayClass10_.buyOrderItem.bordIPrdUnitIIRateResult;
						List<CommonMultiLanguageViewModel> list10 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSBuyOrderItems_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSBuyOrderItems_Lang>)list5, (Func<WSBuyOrderItems_Lang, CommonMultiLanguageViewModel>)((WSBuyOrderItems_Lang item) => new CommonMultiLanguageViewModel
						{
							Value = item.bordIPrdNickname,
							LanguageId = item.LanguageID
						})));
						list10.Add(new CommonMultiLanguageViewModel
						{
							Value = _003C_003Ec__DisplayClass10_.buyOrderItem.bordIPrdNickname,
							LanguageId = result
						});
						CS_0024_003C_003E8__locals0.addProduct.PrdNickname = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
						CS_0024_003C_003E8__locals0.addProduct.PrdNickname_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
						CS_0024_003C_003E8__locals0.addProduct.PrdPriceCurrencyRate = _003C_003Ec__DisplayClass10_.buyOrderItem.bordICostCurrencyRate;
						CS_0024_003C_003E8__locals0.addProduct.OrdIWhId = CS_0024_003C_003E8__locals0.addProduct.WHId;
						List<WSspSelectBuyOrderItemSerials_Result> list11 = Enumerable.ToList<WSspSelectBuyOrderItemSerials_Result>((IEnumerable<WSspSelectBuyOrderItemSerials_Result>)_db.WSspSelectBuyOrderItemSerials(CS_0024_003C_003E8__locals0.addProduct.DetailId, CS_0024_003C_003E8__locals0.currLangID, result));
						if (list11 != null && Enumerable.Any<WSspSelectBuyOrderItemSerials_Result>((IEnumerable<WSspSelectBuyOrderItemSerials_Result>)list11))
						{
							CS_0024_003C_003E8__locals0.addProduct.HaveSerial = 1;
						}
					}
					break;
				case "StockSupply":
					_003C_003Ec__DisplayClass10_.stocksupplyItem = _dbTbl.WSStockSupplyItems.Find(detailId);
					if (_003C_003Ec__DisplayClass10_.stocksupplyItem != null)
					{
						CS_0024_003C_003E8__locals0.addProduct = new AddProductViewModel();
						CS_0024_003C_003E8__locals0.addProduct.ProductId = _003C_003Ec__DisplayClass10_.stocksupplyItem.stsupIPrdId;
						CS_0024_003C_003E8__locals0.addProduct.MasterId = _003C_003Ec__DisplayClass10_.stocksupplyItem.StockSupplyId;
						CS_0024_003C_003E8__locals0.addProduct.DetailId = _003C_003Ec__DisplayClass10_.stocksupplyItem.StockSupplyItemId;
						double.TryParse(_003C_003Ec__DisplayClass10_.stocksupplyItem.stsupIQuantity.ToString(), out var result3);
						CS_0024_003C_003E8__locals0.addProduct.Quantity = ((result3 > 0.0) ? result3 : 1.0);
						CS_0024_003C_003E8__locals0.addProduct.OrderView = _003C_003Ec__DisplayClass10_.stocksupplyItem.stsupIOrderView;
						CS_0024_003C_003E8__locals0.addProduct.FCR = _003C_003Ec__DisplayClass10_.stocksupplyItem.stsupIFCR;
						CS_0024_003C_003E8__locals0.addProduct.FCRI = _003C_003Ec__DisplayClass10_.stocksupplyItem.stsupIFCRI;
						CS_0024_003C_003E8__locals0.addProduct.PrdUnitId = _003C_003Ec__DisplayClass10_.stocksupplyItem.stsupIPrdUnitId;
						CS_0024_003C_003E8__locals0.addProduct.WHId = _003C_003Ec__DisplayClass10_.stocksupplyItem.stsupIWHId;
						CS_0024_003C_003E8__locals0.addProduct.WHIdLinkAcc = _003C_003Ec__DisplayClass10_.stocksupplyItem.stsupILinkAccWHIdStr;
						CS_0024_003C_003E8__locals0.addProduct.MasterForm = masterForm;
						CS_0024_003C_003E8__locals0.addProduct.Tracing = _003C_003Ec__DisplayClass10_.stocksupplyItem.stsupITracing;
						CS_0024_003C_003E8__locals0.addProduct.PrdUnitIdI = _003C_003Ec__DisplayClass10_.stocksupplyItem.stsupIPrdUnitIdI;
						CS_0024_003C_003E8__locals0.addProduct.PrdUnitIRateResult = _003C_003Ec__DisplayClass10_.stocksupplyItem.stsupIPrdUnitIRateResult;
						CS_0024_003C_003E8__locals0.addProduct.PrdUnitIdII = _003C_003Ec__DisplayClass10_.stocksupplyItem.stsupIPrdUnitIdII;
						CS_0024_003C_003E8__locals0.addProduct.PrdUnitIIRateResult = _003C_003Ec__DisplayClass10_.stocksupplyItem.stsupIPrdUnitIIRateResult;
						CS_0024_003C_003E8__locals0.addProduct.PrdColorId = _003C_003Ec__DisplayClass10_.stocksupplyItem.stsupIPrdColorId;
						CS_0024_003C_003E8__locals0.addProduct.UserId = _003C_003Ec__DisplayClass10_.stocksupplyItem.UserId;
						CS_0024_003C_003E8__locals0.addProduct.RegisterDate = _003C_003Ec__DisplayClass10_.stocksupplyItem.RegisterDate;
						CS_0024_003C_003E8__locals0.addProduct.AppType = _003C_003Ec__DisplayClass10_.stocksupplyItem.AppType;
						CS_0024_003C_003E8__locals0.addProduct.FirstRegisterUserId = _003C_003Ec__DisplayClass10_.stocksupplyItem.FirstRegisterUserId;
						CS_0024_003C_003E8__locals0.addProduct.FirstRegisterDate = _003C_003Ec__DisplayClass10_.stocksupplyItem.FirstRegisterDate;
						CS_0024_003C_003E8__locals0.addProduct.ItemPrdWeight = _003C_003Ec__DisplayClass10_.stocksupplyItem.stsupIPrdWeight;
						CS_0024_003C_003E8__locals0.addProduct.PrdCost = _003C_003Ec__DisplayClass10_.stocksupplyItem.stsupICost;
						if (result2 == 4)
						{
							CS_0024_003C_003E8__locals0.addProduct.LinkAccSettingDBId = _003C_003Ec__DisplayClass10_.stocksupplyItem.stsupILinkAccSettingDBId;
						}
						DbSet<WSStockSupplyItems_Lang> wSStockSupplyItems_Lang = _dbTbl.WSStockSupplyItems_Lang;
						ParameterExpression val = Expression.Parameter(typeof(WSStockSupplyItems_Lang), "c");
						List<WSStockSupplyItems_Lang> list = Enumerable.ToList<WSStockSupplyItems_Lang>((IEnumerable<WSStockSupplyItems_Lang>)Queryable.Where<WSStockSupplyItems_Lang>((IQueryable<WSStockSupplyItems_Lang>)wSStockSupplyItems_Lang, Expression.Lambda<Func<WSStockSupplyItems_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass10_, typeof(_003C_003Ec__DisplayClass10_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
						List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSStockSupplyItems_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSStockSupplyItems_Lang>)list, (Func<WSStockSupplyItems_Lang, CommonMultiLanguageViewModel>)((WSStockSupplyItems_Lang item) => new CommonMultiLanguageViewModel
						{
							Value = item.stsupIQuantityDesc,
							LanguageId = item.LanguageID
						})));
						list2.Add(new CommonMultiLanguageViewModel
						{
							Value = _003C_003Ec__DisplayClass10_.stocksupplyItem.stsupIQuantityDesc,
							LanguageId = result
						});
						List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSStockSupplyItems_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSStockSupplyItems_Lang>)list, (Func<WSStockSupplyItems_Lang, CommonMultiLanguageViewModel>)((WSStockSupplyItems_Lang item) => new CommonMultiLanguageViewModel
						{
							Value = item.stsupIDescription,
							LanguageId = item.LanguageID
						})));
						list3.Add(new CommonMultiLanguageViewModel
						{
							Value = _003C_003Ec__DisplayClass10_.stocksupplyItem.stsupIDescription,
							LanguageId = result
						});
						List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSStockSupplyItems_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSStockSupplyItems_Lang>)list, (Func<WSStockSupplyItems_Lang, CommonMultiLanguageViewModel>)((WSStockSupplyItems_Lang item) => new CommonMultiLanguageViewModel
						{
							Value = item.stsupIPrdNickname,
							LanguageId = item.LanguageID
						})));
						list4.Add(new CommonMultiLanguageViewModel
						{
							Value = _003C_003Ec__DisplayClass10_.stocksupplyItem.stsupIPrdNickname,
							LanguageId = result
						});
						CS_0024_003C_003E8__locals0.addProduct.QuantityDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
						CS_0024_003C_003E8__locals0.addProduct.QuantityDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
						CS_0024_003C_003E8__locals0.addProduct.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
						CS_0024_003C_003E8__locals0.addProduct.Description_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
						CS_0024_003C_003E8__locals0.addProduct.PrdNickname = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
						CS_0024_003C_003E8__locals0.addProduct.PrdNickname_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
					}
					break;
				default:
				{
					DateTime now2 = DateTime.Now;
					CS_0024_003C_003E8__locals0.addProduct = new AddProductViewModel
					{
						ProductId = 0,
						MasterId = masterId,
						Quantity = 1.0,
						DetailId = 0,
						Price = default(decimal),
						Discount = default(decimal),
						MasterForm = masterForm,
						FCR = 1.0,
						UserId = UserLogin.CurrentUser.UserId,
						RegisterDate = now2,
						AppType = Configuration.AppType,
						FirstRegisterUserId = UserLogin.CurrentUser.UserId,
						FirstRegisterDate = now2
					};
					break;
				}
				}
				if (CS_0024_003C_003E8__locals0.addProduct != null && CS_0024_003C_003E8__locals0.addProduct.SaleCenterId.GetValueOrDefault() != 0)
				{
					WSspSelectSaleCenterWithId_Result wSspSelectSaleCenterWithId_Result = Enumerable.FirstOrDefault<WSspSelectSaleCenterWithId_Result>((IEnumerable<WSspSelectSaleCenterWithId_Result>)_dbII.WSspSelectSaleCenterWithId(CS_0024_003C_003E8__locals0.addProduct.SaleCenterId, CS_0024_003C_003E8__locals0.currLangID, result));
					if (wSspSelectSaleCenterWithId_Result != null)
					{
						CS_0024_003C_003E8__locals0.addProduct.SaleCenterName = wSspSelectSaleCenterWithId_Result.SaleCenterName ?? "";
					}
				}
			}
			else
			{
				CS_0024_003C_003E8__locals0.addProduct = new AddProductViewModel
				{
					ProductId = 0,
					MasterId = 0,
					Quantity = 1.0,
					DetailId = 0,
					Price = default(decimal),
					Discount = default(decimal),
					MasterForm = masterForm,
					FCR = 1.0,
					RegisterDate = DateTime.Now
				};
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			base.ViewBag.Error = Messages.frmErrorMessage;
		}
		base.ViewBag.PrdId = num;
		FillDropdownProduct();
		SetUserNameDateForProductInOreders(CS_0024_003C_003E8__locals0.addProduct);
		int num2 = 0;
		if (masterForm == "SaleOrder")
		{
			num2 = Order.OrderItemsDoneTimeSum(masterId, detailId);
		}
		base.ViewBag.OrderItemsDoneTimeSum = num2;
		switch (result2)
		{
		case 8:
		{
			CRMIdeal.Classes.Helper.OtherSystems.ShygunSettingViewModel shygunSetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunSetting();
			if (shygunSetting != null)
			{
				base.ViewBag.LinkAccWrhsSyncTypeId = shygunSetting.WrhsSyncTypeId;
			}
			break;
		}
		case 9:
		{
			CRMIdeal.Classes.Helper.OtherSystems.ShygunIISettingViewModel shygunIISetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunIISetting();
			if (shygunIISetting != null)
			{
				base.ViewBag.LinkAccWrhsSyncTypeId = shygunIISetting.WrhsSyncTypeId;
			}
			break;
		}
		case 11:
		{
			CRMIdeal.Classes.Helper.OtherSystems.ShomaranSettingViewModel shomaranSetting = CRMIdeal.Classes.Helper.OtherSystems.GetShomaranSetting();
			if (shomaranSetting != null)
			{
				base.ViewBag.LinkAccWrhsSyncTypeId = shomaranSetting.WrhsSyncTypeId;
			}
			break;
		}
		case 12:
		{
			CRMIdeal.Classes.Helper.OtherSystems.ArpaSettingViewModel arpaSetting = CRMIdeal.Classes.Helper.OtherSystems.GetArpaSetting();
			if (arpaSetting != null)
			{
				base.ViewBag.LinkAccWrhsSyncTypeId = arpaSetting.WrhsSyncTypeId;
			}
			break;
		}
		case 17:
		{
			CRMIdeal.Classes.Helper.OtherSystems.HamrahanSettingViewModel hamrahanSetting = CRMIdeal.Classes.Helper.OtherSystems.GetHamrahanSetting();
			if (hamrahanSetting != null)
			{
				base.ViewBag.LinkAccWrhsSyncTypeId = hamrahanSetting.WrhsSyncTypeId;
			}
			break;
		}
		case 18:
		{
			CRMIdeal.Classes.Helper.OtherSystems.NoAvaranCapillarySettingViewModel noAvaranCapillarySetting = CRMIdeal.Classes.Helper.OtherSystems.GetNoAvaranCapillarySetting();
			if (noAvaranCapillarySetting != null)
			{
				base.ViewBag.LinkAccWrhsSyncTypeId = noAvaranCapillarySetting.WrhsSyncTypeId;
			}
			break;
		}
		case 19:
		{
			CRMIdeal.Classes.Helper.OtherSystems.RahkaranRetailSettingViewModel rahkaranRetailSetting = CRMIdeal.Classes.Helper.OtherSystems.GetRahkaranRetailSetting();
			if (rahkaranRetailSetting != null)
			{
				base.ViewBag.LinkAccWrhsSyncTypeId = rahkaranRetailSetting.WrhsSyncTypeId;
			}
			break;
		}
		case 20:
		{
			CRMIdeal.Classes.Helper.OtherSystems.NilramSettingViewModel nilramSetting = CRMIdeal.Classes.Helper.OtherSystems.GetNilramSetting();
			if (nilramSetting != null)
			{
				base.ViewBag.LinkAccWrhsSyncTypeId = nilramSetting.WrhsSyncTypeId;
			}
			break;
		}
		case 22:
		{
			CRMIdeal.Classes.Helper.OtherSystems.RahkaranInternalSalesProvider rahkaranInternalSalesProvider = new CRMIdeal.Classes.Helper.OtherSystems.RahkaranInternalSalesProvider(isUpdateList: false, isLogin: false);
			base.ViewBag.LinkAccWrhsSyncTypeId = rahkaranInternalSalesProvider.WrhsSyncTypeId;
			break;
		}
		case 23:
		{
			CRMIdeal.Classes.Helper.OtherSystems.RayvarzProvider rayvarzProvider = new CRMIdeal.Classes.Helper.OtherSystems.RayvarzProvider(isUpdateList: false, isLogin: false);
			base.ViewBag.LinkAccWrhsSyncTypeId = rayvarzProvider.WrhsSyncTypeId;
			break;
		}
		case 25:
		{
			CRMIdeal.Classes.Helper.OtherSystems.ArianSystemProvider arianSystemProvider = new CRMIdeal.Classes.Helper.OtherSystems.ArianSystemProvider(isUpdateList: false, isLogin: false);
			base.ViewBag.LinkAccWrhsSyncTypeId = arianSystemProvider.WrhsSyncTypeId;
			break;
		}
		}
		base.ViewBag.IsDecimalModule = VersionBuyer.IsDecimal;
		return PartialView(CS_0024_003C_003E8__locals0.addProduct);
	}

	public ActionResult SalePriceNearHistory(int prdId = 0, int cmpId = 0, int mode = 0)
	{
		base.ViewBag.prdId = prdId;
		base.ViewBag.CmpId = cmpId;
		base.ViewBag.Mode = mode;
		return View();
	}

	public ActionResult BuyCostNearHistory(int prdId = 0, int cmpId = 0)
	{
		base.ViewBag.prdId = prdId;
		base.ViewBag.CmpId = cmpId;
		return View();
	}

	[LoginAuthorize]
	public ActionResult PrdStockSerials(int prdId = 0, int? wHid = null)
	{
		base.ViewBag.prdId = prdId;
		base.ViewBag.wHID = wHid;
		return View();
	}

	[LoginAuthorize]
	public ActionResult ShowProdcutStocks(int position, int prdId, int currId, int whId, double fcr, double fcrI, string tracing, int cmpId = 0, int prdPriceGroupId = 0, string crmOrdType = "pord", string linkAccWhId = "", string sefareshCode = "", string masterFormName = "", int linkAccSettingDBId = 0, int currItemId = 0)
	{
		string text = "";
		string text2 = "";
		if (position == 1)
		{
			text = "frmOrderIssueQuick";
			text2 = "actShowPrdRemain";
			if (!UserLogin.IsUserAccess(text, text2, UserLogin.CurrentUser))
			{
				return RedirectToAction("Login", "Account", (object)new
				{
					area = "",
					d = DateTime.Now
				});
			}
			base.ViewBag.PrdId = prdId;
			base.ViewBag.CurrId = currId;
			base.ViewBag.WhId = whId;
			base.ViewBag.Fcr = fcr;
			base.ViewBag.FcrI = fcrI;
			base.ViewBag.Tracing = tracing;
			base.ViewBag.CmpId = cmpId;
			base.ViewBag.PrdPriceGroupId = prdPriceGroupId;
			base.ViewBag.CrmOrdType = crmOrdType;
			base.ViewBag.LinkAccWhId = linkAccWhId;
			base.ViewBag.SefareshCode = sefareshCode;
			base.ViewBag.MasterFormName = masterFormName;
			base.ViewBag.LinkAccSettingDBId = linkAccSettingDBId;
			base.ViewBag.CurrItemId = currItemId;
			try
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				_ = Thread.CurrentThread.CurrentCulture.LCID;
				int result2 = 0;
				CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
				if (cRMspSelectCrmsysSetting_Result != null)
				{
					int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result2);
				}
				switch (result2)
				{
				case 8:
				{
					CRMIdeal.Classes.Helper.OtherSystems.ShygunSettingViewModel shygunSetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunSetting();
					if (shygunSetting != null)
					{
						base.ViewBag.LinkAccWrhsSyncTypeId = shygunSetting.WrhsSyncTypeId;
					}
					break;
				}
				case 9:
				{
					CRMIdeal.Classes.Helper.OtherSystems.ShygunIISettingViewModel shygunIISetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunIISetting();
					if (shygunIISetting != null)
					{
						base.ViewBag.LinkAccWrhsSyncTypeId = shygunIISetting.WrhsSyncTypeId;
					}
					break;
				}
				case 11:
				{
					CRMIdeal.Classes.Helper.OtherSystems.ShomaranSettingViewModel shomaranSetting = CRMIdeal.Classes.Helper.OtherSystems.GetShomaranSetting();
					if (shomaranSetting != null)
					{
						base.ViewBag.LinkAccWrhsSyncTypeId = shomaranSetting.WrhsSyncTypeId;
					}
					break;
				}
				case 12:
				{
					CRMIdeal.Classes.Helper.OtherSystems.ArpaSettingViewModel arpaSetting = CRMIdeal.Classes.Helper.OtherSystems.GetArpaSetting();
					if (arpaSetting != null)
					{
						base.ViewBag.LinkAccWrhsSyncTypeId = arpaSetting.WrhsSyncTypeId;
					}
					break;
				}
				case 17:
				{
					CRMIdeal.Classes.Helper.OtherSystems.HamrahanSettingViewModel hamrahanSetting = CRMIdeal.Classes.Helper.OtherSystems.GetHamrahanSetting();
					if (hamrahanSetting != null)
					{
						base.ViewBag.LinkAccWrhsSyncTypeId = hamrahanSetting.WrhsSyncTypeId;
					}
					break;
				}
				case 18:
				{
					CRMIdeal.Classes.Helper.OtherSystems.NoAvaranCapillarySettingViewModel noAvaranCapillarySetting = CRMIdeal.Classes.Helper.OtherSystems.GetNoAvaranCapillarySetting();
					if (noAvaranCapillarySetting != null)
					{
						base.ViewBag.LinkAccWrhsSyncTypeId = noAvaranCapillarySetting.WrhsSyncTypeId;
					}
					break;
				}
				case 19:
				{
					CRMIdeal.Classes.Helper.OtherSystems.RahkaranRetailSettingViewModel rahkaranRetailSetting = CRMIdeal.Classes.Helper.OtherSystems.GetRahkaranRetailSetting();
					if (rahkaranRetailSetting != null)
					{
						base.ViewBag.LinkAccWrhsSyncTypeId = rahkaranRetailSetting.WrhsSyncTypeId;
					}
					break;
				}
				case 20:
				{
					CRMIdeal.Classes.Helper.OtherSystems.NilramSettingViewModel nilramSetting = CRMIdeal.Classes.Helper.OtherSystems.GetNilramSetting();
					if (nilramSetting != null)
					{
						base.ViewBag.LinkAccWrhsSyncTypeId = nilramSetting.WrhsSyncTypeId;
					}
					break;
				}
				case 22:
				{
					CRMIdeal.Classes.Helper.OtherSystems.RahkaranInternalSalesProvider rahkaranInternalSalesProvider = new CRMIdeal.Classes.Helper.OtherSystems.RahkaranInternalSalesProvider(isUpdateList: false, isLogin: false);
					base.ViewBag.LinkAccWrhsSyncTypeId = rahkaranInternalSalesProvider.WrhsSyncTypeId;
					break;
				}
				case 23:
				{
					CRMIdeal.Classes.Helper.OtherSystems.RayvarzProvider rayvarzProvider = new CRMIdeal.Classes.Helper.OtherSystems.RayvarzProvider(isUpdateList: false, isLogin: false);
					base.ViewBag.LinkAccWrhsSyncTypeId = rayvarzProvider.WrhsSyncTypeId;
					break;
				}
				case 25:
				{
					CRMIdeal.Classes.Helper.OtherSystems.ArianSystemProvider arianSystemProvider = new CRMIdeal.Classes.Helper.OtherSystems.ArianSystemProvider(isUpdateList: false, isLogin: false);
					base.ViewBag.LinkAccWrhsSyncTypeId = arianSystemProvider.WrhsSyncTypeId;
					break;
				}
				}
				List<WSspSelectActiveWareHouse_Result> list = CRMIdeal.Classes.Helper.Warehouse.SelectActiveWareHouse();
				List<SelectListItem> list2 = new List<SelectListItem>();
				list2.AddRange(Enumerable.Select<WSspSelectActiveWareHouse_Result, SelectListItem>((IEnumerable<WSspSelectActiveWareHouse_Result>)list, (Func<WSspSelectActiveWareHouse_Result, SelectListItem>)((WSspSelectActiveWareHouse_Result item) => new SelectListItem
				{
					Text = item.WrhsName + ((!string.IsNullOrWhiteSpace(item.WrhsCode)) ? (" (" + item.WrhsCode + ")") : ""),
					Value = item.WareHouseID.ToString(),
					Selected = false
				})));
				base.ViewBag.WareHouseList = list2;
				if (result2 > 0)
				{
					GetLinkAccWhSelectList(fillAuto: false, withWrhsLinkAccWhCode: false, withWrhsLinkAccWhId: false, withWrhsLinkAccWhIdStr: false, withWrhsLinkAccWareHouses: true);
				}
				if (result2 == 4)
				{
					List<CRMspSelectLinkAccSettingDB_Result> list3 = Enumerable.ToList<CRMspSelectLinkAccSettingDB_Result>((IEnumerable<CRMspSelectLinkAccSettingDB_Result>)_dbLink.CRMspSelectLinkAccSettingDB(4, 0, 0, 0));
					if (list3 != null && Enumerable.Any<CRMspSelectLinkAccSettingDB_Result>((IEnumerable<CRMspSelectLinkAccSettingDB_Result>)list3))
					{
						List<SelectListItem> list4 = new List<SelectListItem>();
						list4.AddRange(Enumerable.Select<CRMspSelectLinkAccSettingDB_Result, SelectListItem>((IEnumerable<CRMspSelectLinkAccSettingDB_Result>)list3, (Func<CRMspSelectLinkAccSettingDB_Result, SelectListItem>)((CRMspSelectLinkAccSettingDB_Result item) => new SelectListItem
						{
							Text = (item.LinkAccSettingDbTitle ?? ""),
							Value = item.LinkAccSettingDBId.ToString(),
							Selected = false
						})));
						base.ViewBag.LinkAccSettingDBList = list4;
					}
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
			return View();
		}
		return RedirectToAction("Login", "Account", (object)new
		{
			area = "",
			d = DateTime.Now
		});
	}

	[AjaxOnly]
	public ActionResult _PartialPrdTree(int mode, int prdKind, int prdInActive, int cmpId, int prjId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<TreeViewItemModel> list = new List<TreeViewItemModel>();
		try
		{
			List<WSspProductsTree_Result> list2 = Enumerable.ToList<WSspProductsTree_Result>((IEnumerable<WSspProductsTree_Result>)_db.WSspProductsTree(mode, lCID, result, prdKind, prdInActive, cmpId, prjId));
			foreach (WSspProductsTree_Result item in Enumerable.ToList<WSspProductsTree_Result>(Enumerable.Where<WSspProductsTree_Result>((IEnumerable<WSspProductsTree_Result>)list2, (Func<WSspProductsTree_Result, bool>)((WSspProductsTree_Result c) => c.ParentId == 0))))
			{
				TreeViewItemModel treeViewItemModel = new TreeViewItemModel();
				treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item.FId + "|" + item.SId + "|" + item.PrdId));
				treeViewItemModel.Id = item.FId + "|" + item.SId + "|" + item.PrdId;
				treeViewItemModel.Text = item.KEYName;
				treeViewItemModel.ImageUrl = "";
				List<WSspProductsTree_Result> list3 = Enumerable.ToList<WSspProductsTree_Result>(Enumerable.Where<WSspProductsTree_Result>((IEnumerable<WSspProductsTree_Result>)list2, (Func<WSspProductsTree_Result, bool>)((WSspProductsTree_Result c) => c.ParentId == item.FId)));
				List<TreeViewItemModel> list4 = new List<TreeViewItemModel>();
				foreach (WSspProductsTree_Result itemIn in list3)
				{
					TreeViewItemModel treeViewItemModel2 = new TreeViewItemModel();
					treeViewItemModel2.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", itemIn.FId + "|" + itemIn.SId + "|" + itemIn.PrdId));
					treeViewItemModel2.Id = itemIn.FId + "|" + itemIn.SId + "|" + itemIn.PrdId;
					treeViewItemModel2.Text = itemIn.KEYName;
					treeViewItemModel2.ImageUrl = "";
					int.Parse("100" + itemIn.SId);
					List<WSspProductsTree_Result> list5 = Enumerable.ToList<WSspProductsTree_Result>(Enumerable.Where<WSspProductsTree_Result>((IEnumerable<WSspProductsTree_Result>)list2, (Func<WSspProductsTree_Result, bool>)((WSspProductsTree_Result c) => c.ParentId == itemIn.KeyId && c.FId == 0)));
					List<TreeViewItemModel> list6 = new List<TreeViewItemModel>();
					foreach (WSspProductsTree_Result item2 in list5)
					{
						TreeViewItemModel treeViewItemModel3 = new TreeViewItemModel();
						treeViewItemModel3.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item2.FId + "|" + item2.SId + "|" + item2.PrdId));
						treeViewItemModel3.Id = item2.FId + "|" + item2.SId + "|" + item2.PrdId;
						treeViewItemModel3.Text = item2.KEYName;
						treeViewItemModel3.ImageUrl = "";
						treeViewItemModel3.Items = null;
						list6.Add(treeViewItemModel3);
					}
					treeViewItemModel2.Items = new List<TreeViewItemModel>(list6);
					list4.Add(treeViewItemModel2);
				}
				treeViewItemModel.Items = new List<TreeViewItemModel>(list4);
				list.Add(treeViewItemModel);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PrdGroups = list;
		return PartialView();
	}

	public ActionResult LoadProductTree(int? mode, int? prdKind, int? prdInActive, int? cmpId, int? prjId, int? level, int? parentId, int? productId, int pageNumber = 1, int pageSize = 20, string textSearch = "", int searchMode = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspProductsTreeByLevel_Result> data = new List<WSspProductsTreeByLevel_Result>();
		try
		{
			if (productId.HasValue && productId != 0)
			{
				textSearch = "";
			}
			if ((!parentId.HasValue || parentId == 0) && !string.IsNullOrEmpty(textSearch))
			{
				level = searchMode;
			}
			textSearch = textSearch.Trim();
			parentId = ((parentId.HasValue && parentId.GetValueOrDefault() == -1) ? new int?(0) : parentId);
			data = Enumerable.ToList<WSspProductsTreeByLevel_Result>((IEnumerable<WSspProductsTreeByLevel_Result>)_dbII.WSspProductsTreeByLevel(mode, lCID, result, prdKind, prdInActive, cmpId, prjId, level, textSearch, searchMode, parentId, productId, pageSize, pageNumber));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	public ActionResult _PartialSelectProduct(int prdFgroupId, int prdSgroupId, string barcode, string val, int prdId, int showMode, int prdKind, int prdInActive, int cmpId, int prjId, string prdSpecs = "")
	{
		base.ViewBag.prdSgroupId = prdSgroupId;
		base.ViewBag.prdFgroupId = prdFgroupId;
		base.ViewBag.barcode = barcode;
		base.ViewBag.val = val;
		base.ViewBag.prdId = prdId;
		base.ViewBag.showMode = showMode;
		base.ViewBag.prdKind = prdKind;
		base.ViewBag.prdInActive = prdInActive;
		base.ViewBag.cmpId = cmpId;
		base.ViewBag.prjId = prjId;
		base.ViewBag.prdSpecs = prdSpecs;
		return PartialView();
	}

	[AjaxOnly]
	public ActionResult SelectProduct_Read([DataSourceRequest] DataSourceRequest request, int prdFgroupId, int prdSgroupId, string barcode, string val, int prdId, int showMode, int prdKind, int prdInActive, int cmpId, int prjId, string prdSpecs = "")
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
			list = Enumerable.ToList<WSspSearchProducts_Result>((IEnumerable<WSspSearchProducts_Result>)_db.WSspSearchProducts(prdFgroupId, prdSgroupId, barcode, val, prdId, showMode, lCID, result, prdKind, prdInActive, cmpId, prjId, "", prdSpecs));
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

	[AjaxOnly]
	public ActionResult SalePriceNearHistory_Read([DataSourceRequest] DataSourceRequest request, int prdId = 0, int cmpId = 0, int mode = 0)
	{
		List<WSspCmpPrdSalePriceHistory_Result> list = new List<WSspCmpPrdSalePriceHistory_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (prdId > 0 && cmpId > 0)
			{
				list = Enumerable.ToList<WSspCmpPrdSalePriceHistory_Result>((IEnumerable<WSspCmpPrdSalePriceHistory_Result>)_db.WSspCmpPrdSalePriceHistory(cmpId, prdId, mode));
				foreach (WSspCmpPrdSalePriceHistory_Result item in list)
				{
					if (item.DateTimeM.HasValue)
					{
						item.DateP = (item.DateTimeM.HasValue ? item.DateTimeM.Value.ToString("yyyyMMdd") : "");
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request));
	}

	[AjaxOnly]
	public ActionResult BuyCostNearHistory_Read([DataSourceRequest] DataSourceRequest request, int prdId = 0, int cmpId = 0)
	{
		List<WSspCmpPrdBuyCostNearHistory_Result> list = new List<WSspCmpPrdBuyCostNearHistory_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (prdId > 0 && cmpId > 0)
			{
				list = Enumerable.ToList<WSspCmpPrdBuyCostNearHistory_Result>((IEnumerable<WSspCmpPrdBuyCostNearHistory_Result>)_db.WSspCmpPrdBuyCostNearHistory(cmpId, prdId));
				foreach (WSspCmpPrdBuyCostNearHistory_Result item in list)
				{
					if (lCID == 1025 && !string.IsNullOrEmpty(item.bordDate))
					{
						item.bordDate = DateTime.Parse(PersianDate.GetShamsi2Miladi(item.bordDate.Replace("/", ""))).ToString("yyyyMMdd", new CultureInfo("ar-SA"));
					}
					if (lCID != 1065 && !string.IsNullOrEmpty(item.bordDate))
					{
						item.bordDate = PersianDate.GetShamsi2Miladi(item.bordDate.Replace("/", "")).Replace("/", "");
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request));
	}

	[AjaxOnly]
	public ActionResult ReturnDocItemSerialStockByPrdId_Read([DataSourceRequest] DataSourceRequest request, int prdId = 0, int? wHid = null)
	{
		List<WSspReturnDocItemSerialStockByPrdId_Result> list = new List<WSspReturnDocItemSerialStockByPrdId_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (prdId > 0)
			{
				list = Enumerable.ToList<WSspReturnDocItemSerialStockByPrdId_Result>((IEnumerable<WSspReturnDocItemSerialStockByPrdId_Result>)_db.WSspReturnDocItemSerialStockByPrdId(prdId, wHid, lCID, result, result2));
				foreach (WSspReturnDocItemSerialStockByPrdId_Result item in list)
				{
					item.DocDate = ((!string.IsNullOrEmpty(item.DocDate) && lCID != 1065) ? ((lCID == 1025) ? DateTime.Parse(PersianDate.GetShamsi2Miladi(item.DocDate.Replace("/", ""))).ToString("yyyyMMdd", new CultureInfo("ar-SA")) : DateTime.Parse(PersianDate.GetShamsi2Miladi(item.DocDate.Replace("/", ""))).ToString("yyyyMMdd", new CultureInfo("en-US"))) : item.DocDate);
					item.AppType = (item.ExpDate.HasValue ? item.ExpDate.Value.ToString("yyyyMMdd", new CultureInfo("en-US")) : "");
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

	private void FillDropdownProduct()
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
			base.ViewBag.PrdPriceGupList = list2;
			List<SelectListItem> list3 = new List<SelectListItem>();
			list3.AddRange(Enumerable.Select<WSspSelectProductPriceGroup_Result, SelectListItem>((IEnumerable<WSspSelectProductPriceGroup_Result>)list, (Func<WSspSelectProductPriceGroup_Result, SelectListItem>)((WSspSelectProductPriceGroup_Result item) => new SelectListItem
			{
				Text = item.ProductPriceGroupName,
				Value = item.ProductPriceGroupID.ToString(),
				Selected = false
			})));
			base.ViewBag.PrdPriceGupListExtra = list3;
			List<WSspSelectProductCostGroup_Result> list4 = Enumerable.ToList<WSspSelectProductCostGroup_Result>((IEnumerable<WSspSelectProductCostGroup_Result>)_db.WSspSelectProductCostGroup(lCID, result));
			List<SelectListItem> list5 = new List<SelectListItem>();
			list5.AddRange(Enumerable.Select<WSspSelectProductCostGroup_Result, SelectListItem>((IEnumerable<WSspSelectProductCostGroup_Result>)list4, (Func<WSspSelectProductCostGroup_Result, SelectListItem>)((WSspSelectProductCostGroup_Result item) => new SelectListItem
			{
				Text = item.ProductCostGroupName,
				Value = item.ProductCostGroupID.ToString(),
				Selected = false
			})));
			base.ViewBag.PrdCostGupList = list5;
			List<WSspSelectActiveWareHouse_Result> list6 = CRMIdeal.Classes.Helper.Warehouse.SelectActiveWareHouse();
			List<SelectListItem> list7 = new List<SelectListItem>();
			list7.AddRange(Enumerable.Select<WSspSelectActiveWareHouse_Result, SelectListItem>((IEnumerable<WSspSelectActiveWareHouse_Result>)list6, (Func<WSspSelectActiveWareHouse_Result, SelectListItem>)((WSspSelectActiveWareHouse_Result item) => new SelectListItem
			{
				Text = item.WrhsName + ((!string.IsNullOrWhiteSpace(item.WrhsCode)) ? (" (" + item.WrhsCode + ")") : ""),
				Value = item.WareHouseID.ToString(),
				Selected = false
			})));
			base.ViewBag.WareHouseList = list7;
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			if (cRMspSelectCrmsysSetting_Result != null && cRMspSelectCrmsysSetting_Result.LinkAccSystemId > 0)
			{
				GetLinkAccWhSelectList(fillAuto: false, withWrhsLinkAccWhCode: false, withWrhsLinkAccWhId: false, withWrhsLinkAccWhIdStr: false, withWrhsLinkAccWareHouses: true);
			}
			List<WSspSelectProductUnits_Result> list8 = Enumerable.ToList<WSspSelectProductUnits_Result>((IEnumerable<WSspSelectProductUnits_Result>)_db.WSspSelectProductUnits(lCID, result));
			List<SelectListItem> list9 = new List<SelectListItem>();
			List<WSProductUnitsListViewModel> list10 = new List<WSProductUnitsListViewModel>();
			list9.AddRange(Enumerable.Select<WSspSelectProductUnits_Result, SelectListItem>((IEnumerable<WSspSelectProductUnits_Result>)list8, (Func<WSspSelectProductUnits_Result, SelectListItem>)((WSspSelectProductUnits_Result item) => new SelectListItem
			{
				Text = item.Unit,
				Value = item.ProductUnitID.ToString(),
				Selected = false
			})));
			list10.AddRange(Enumerable.Select<WSspSelectProductUnits_Result, WSProductUnitsListViewModel>((IEnumerable<WSspSelectProductUnits_Result>)list8, (Func<WSspSelectProductUnits_Result, WSProductUnitsListViewModel>)((WSspSelectProductUnits_Result item) => new WSProductUnitsListViewModel
			{
				ProductUnitID = item.ProductUnitID,
				Unit = item.Unit,
				QuantityInUnit = item.QuantityInUnit,
				UnitEn = item.UnitEn,
				FCR = item.FCR,
				FCRI = item.FCRI
			})));
			List<WSProductUnitsFormulaListViewModel> list11 = new List<WSProductUnitsFormulaListViewModel>();
			list11.AddRange(Enumerable.Select<WSspSelectProductUnits_Result, WSProductUnitsFormulaListViewModel>((IEnumerable<WSspSelectProductUnits_Result>)list8, (Func<WSspSelectProductUnits_Result, WSProductUnitsFormulaListViewModel>)((WSspSelectProductUnits_Result item) => new WSProductUnitsFormulaListViewModel
			{
				ProductUnitID = item.ProductUnitID,
				UnitIFormula = item.UnitIFormula,
				UnitIIFormula = item.UnitIIFormula
			})));
			string text = "";
			if (list11 != null && Enumerable.Any<WSProductUnitsFormulaListViewModel>((IEnumerable<WSProductUnitsFormulaListViewModel>)list11))
			{
				text = JsonConvert.SerializeObject(Enumerable.ToList<WSProductUnitsFormulaListViewModel>((IEnumerable<WSProductUnitsFormulaListViewModel>)list11));
			}
			base.ViewBag.PrdUnitFormulaListJson = text;
			base.ViewBag.UnitList = list9;
			base.ViewBag.PrdUnitList = list10;
			base.ViewBag.UnitIList = list9;
			base.ViewBag.UnitIIList = list9;
			List<SelectListItem> list12 = new List<SelectListItem>();
			List<WSspSelectCurrencyUnitTspCode_Result> list13 = Enumerable.ToList<WSspSelectCurrencyUnitTspCode_Result>((IEnumerable<WSspSelectCurrencyUnitTspCode_Result>)_dbI.WSspSelectCurrencyUnitTspCode(lCID, result));
			list12.AddRange(Enumerable.Select<WSspSelectCurrencyUnitTspCode_Result, SelectListItem>((IEnumerable<WSspSelectCurrencyUnitTspCode_Result>)list13, (Func<WSspSelectCurrencyUnitTspCode_Result, SelectListItem>)((WSspSelectCurrencyUnitTspCode_Result item) => new SelectListItem
			{
				Text = item.CurrencyUnit + ((!string.IsNullOrWhiteSpace(item.TspCurrencyUnitCode)) ? ("(" + item.TspCurrencyUnitCode + ")") : ""),
				Value = item.TspCurrencyUnitCode,
				Selected = false
			})));
			base.ViewBag.TspCurrencyUnitCodeList = list12;
			int result2 = 0;
			if (SysSeting.Get() != null)
			{
				int.TryParse(SysSeting.Get().LinkAccSystemId.ToString(), out result2);
			}
			if (result2 != 4)
			{
				return;
			}
			List<CRMspSelectLinkAccSettingDB_Result> list14 = Enumerable.ToList<CRMspSelectLinkAccSettingDB_Result>((IEnumerable<CRMspSelectLinkAccSettingDB_Result>)_dbLink.CRMspSelectLinkAccSettingDB(4, 0, 0, 0));
			if (list14 != null && Enumerable.Any<CRMspSelectLinkAccSettingDB_Result>((IEnumerable<CRMspSelectLinkAccSettingDB_Result>)list14))
			{
				List<SelectListItem> list15 = new List<SelectListItem>();
				list15.AddRange(Enumerable.Select<CRMspSelectLinkAccSettingDB_Result, SelectListItem>((IEnumerable<CRMspSelectLinkAccSettingDB_Result>)list14, (Func<CRMspSelectLinkAccSettingDB_Result, SelectListItem>)((CRMspSelectLinkAccSettingDB_Result item) => new SelectListItem
				{
					Text = (item.LinkAccSettingDbTitle ?? ""),
					Value = item.LinkAccSettingDBId.ToString(),
					Selected = false
				})));
				base.ViewBag.LinkAccSettingDBList = list15;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}

	[AjaxOnly]
	public JsonResult GetCurrencyUnit()
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
			List<WSspSelectCurrencyUnits_Result> list2 = Enumerable.ToList<WSspSelectCurrencyUnits_Result>((IEnumerable<WSspSelectCurrencyUnits_Result>)_db.WSspSelectCurrencyUnits(lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectCurrencyUnits_Result, SelectListItem>((IEnumerable<WSspSelectCurrencyUnits_Result>)list2, (Func<WSspSelectCurrencyUnits_Result, SelectListItem>)((WSspSelectCurrencyUnits_Result item) => new SelectListItem
			{
				Text = item.CurrencyUnit,
				Value = item.CurrencyUnitID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.FreightCurrUnList = list;
		base.ViewBag.CustomsCurrUnList = list;
		base.ViewBag.CommissionCurrUnList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetDeliveryTerms()
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
			List<WSspSelectDeliveryTerms_Result> list2 = Enumerable.ToList<WSspSelectDeliveryTerms_Result>((IEnumerable<WSspSelectDeliveryTerms_Result>)_db.WSspSelectDeliveryTerms(lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectDeliveryTerms_Result, SelectListItem>((IEnumerable<WSspSelectDeliveryTerms_Result>)list2, (Func<WSspSelectDeliveryTerms_Result, SelectListItem>)((WSspSelectDeliveryTerms_Result item) => new SelectListItem
			{
				Text = item.DeliveryTerm,
				Value = item.DeliveryTermId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.DeliveryTermsList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetProductColor()
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
			List<WSspSelectProductColor_Result> list2 = Enumerable.ToList<WSspSelectProductColor_Result>((IEnumerable<WSspSelectProductColor_Result>)_db.WSspSelectProductColor(lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectProductColor_Result, SelectListItem>((IEnumerable<WSspSelectProductColor_Result>)list2, (Func<WSspSelectProductColor_Result, SelectListItem>)((WSspSelectProductColor_Result item) => new SelectListItem
			{
				Text = item.Color,
				Value = item.ProductColorID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PrdColorList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetProductDeliveryUsers()
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
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<CRMspSelectActiveUsers_Result> list2 = Enumerable.ToList<CRMspSelectActiveUsers_Result>((IEnumerable<CRMspSelectActiveUsers_Result>)_db.CRMspSelectActiveUsers(lCID, result, result2));
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
		base.ViewBag.PrdDeliveryUserList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public List<WSspSelectWareHouseWithAccLinkField_Result> GetLinkAccWhList(bool fillAuto = true, bool withWrhsLinkAccWhCode = true, bool withWrhsLinkAccWhId = true, bool withWrhsLinkAccWhIdStr = true, bool withWrhsLinkAccWareHouses = false, bool removeDups = true)
	{
		List<WSspSelectWareHouseWithAccLinkField_Result> list = new List<WSspSelectWareHouseWithAccLinkField_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (VersionBuyer.LinkAcc)
			{
				CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
				if (fillAuto && cRMspSelectCrmsysSetting_Result != null)
				{
					int result2 = 0;
					int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result2);
					switch (result2)
					{
					case 8:
						withWrhsLinkAccWhCode = true;
						withWrhsLinkAccWhId = true;
						withWrhsLinkAccWhIdStr = false;
						break;
					case 9:
						withWrhsLinkAccWhCode = true;
						withWrhsLinkAccWhId = true;
						withWrhsLinkAccWhIdStr = false;
						break;
					case 11:
						withWrhsLinkAccWhCode = false;
						withWrhsLinkAccWhId = false;
						withWrhsLinkAccWhIdStr = false;
						withWrhsLinkAccWareHouses = true;
						break;
					case 12:
						withWrhsLinkAccWhCode = false;
						withWrhsLinkAccWhId = false;
						withWrhsLinkAccWhIdStr = false;
						withWrhsLinkAccWareHouses = true;
						break;
					case 17:
						withWrhsLinkAccWhCode = false;
						withWrhsLinkAccWhId = false;
						withWrhsLinkAccWhIdStr = false;
						withWrhsLinkAccWareHouses = true;
						break;
					case 18:
						withWrhsLinkAccWhCode = false;
						withWrhsLinkAccWhId = false;
						withWrhsLinkAccWhIdStr = false;
						withWrhsLinkAccWareHouses = true;
						break;
					case 19:
						withWrhsLinkAccWhCode = false;
						withWrhsLinkAccWhId = false;
						withWrhsLinkAccWhIdStr = false;
						withWrhsLinkAccWareHouses = true;
						break;
					case 20:
						withWrhsLinkAccWhCode = false;
						withWrhsLinkAccWhId = false;
						withWrhsLinkAccWhIdStr = false;
						withWrhsLinkAccWareHouses = true;
						break;
					case 22:
					case 23:
					case 25:
						withWrhsLinkAccWhCode = false;
						withWrhsLinkAccWhId = false;
						withWrhsLinkAccWhIdStr = false;
						withWrhsLinkAccWareHouses = true;
						break;
					default:
						withWrhsLinkAccWhCode = false;
						withWrhsLinkAccWhId = false;
						withWrhsLinkAccWhIdStr = false;
						break;
					case 1:
					case 2:
					case 3:
					case 4:
					case 5:
					case 6:
					case 7:
						break;
					}
				}
				CRMLinkSpEntities dbLink = _dbLink;
				bool? flag = withWrhsLinkAccWhCode;
				List<WSspSelectWareHouseWithAccLinkField_Result> list2 = Enumerable.ToList<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)dbLink.WSspSelectWareHouseWithAccLinkField(withWrhsLinkAccWhId, flag, withWrhsLinkAccWhIdStr, languageID: lCID, defaultLanguageID: result, withWrhsLinkAccWareHouses: withWrhsLinkAccWareHouses));
				if (list2 != null && list2.Count > 0)
				{
					if (removeDups)
					{
						foreach (WSspSelectWareHouseWithAccLinkField_Result i in list2)
						{
							if (Enumerable.FirstOrDefault<WSspSelectWareHouseWithAccLinkField_Result>(Enumerable.Where<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)list, (Func<WSspSelectWareHouseWithAccLinkField_Result, bool>)((WSspSelectWareHouseWithAccLinkField_Result x) => x.WrhsLinkAccWhId == i.WrhsLinkAccWhId && x.WrhsLinkAccWhCode == i.WrhsLinkAccWhCode && x.WrhsLinkAccWhIdStr == i.WrhsLinkAccWhIdStr))) == null)
							{
								list.Add(i);
							}
						}
					}
					else
					{
						list.AddRange(list2);
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.LinkAccWareHouseList = list;
		return list;
	}

	public List<SelectListItem> GetLinkAccWhSelectList(bool fillAuto = true, bool withWrhsLinkAccWhCode = true, bool withWrhsLinkAccWhId = true, bool withWrhsLinkAccWhIdStr = true, bool withWrhsLinkAccWareHouses = false)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			if (VersionBuyer.LinkAcc)
			{
				CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
				if (fillAuto && cRMspSelectCrmsysSetting_Result != null)
				{
					int result = 0;
					int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result);
					switch (result)
					{
					case 8:
						withWrhsLinkAccWhCode = true;
						withWrhsLinkAccWhId = true;
						withWrhsLinkAccWhIdStr = false;
						break;
					case 9:
						withWrhsLinkAccWhCode = true;
						withWrhsLinkAccWhId = true;
						withWrhsLinkAccWhIdStr = false;
						break;
					case 11:
						withWrhsLinkAccWhCode = true;
						withWrhsLinkAccWhId = true;
						withWrhsLinkAccWhIdStr = false;
						break;
					case 12:
						withWrhsLinkAccWhCode = true;
						withWrhsLinkAccWhId = true;
						withWrhsLinkAccWhIdStr = false;
						break;
					case 17:
						withWrhsLinkAccWhCode = true;
						withWrhsLinkAccWhId = true;
						withWrhsLinkAccWhIdStr = false;
						break;
					case 18:
						withWrhsLinkAccWhCode = true;
						withWrhsLinkAccWhId = true;
						withWrhsLinkAccWhIdStr = false;
						break;
					case 19:
						withWrhsLinkAccWhCode = true;
						withWrhsLinkAccWhId = true;
						withWrhsLinkAccWhIdStr = false;
						break;
					case 20:
						withWrhsLinkAccWhCode = true;
						withWrhsLinkAccWhId = true;
						withWrhsLinkAccWhIdStr = false;
						break;
					case 22:
					case 23:
					case 25:
						withWrhsLinkAccWhCode = true;
						withWrhsLinkAccWhId = true;
						withWrhsLinkAccWhIdStr = false;
						break;
					default:
						withWrhsLinkAccWhCode = false;
						withWrhsLinkAccWhId = false;
						withWrhsLinkAccWhIdStr = false;
						break;
					case 1:
					case 2:
					case 3:
					case 4:
					case 5:
					case 6:
					case 7:
						break;
					}
				}
				List<WSspSelectWareHouseWithAccLinkField_Result> linkAccWhList = GetLinkAccWhList(fillAuto: true, withWrhsLinkAccWhCode, withWrhsLinkAccWhId, withWrhsLinkAccWhIdStr, withWrhsLinkAccWareHouses);
				if (linkAccWhList != null && linkAccWhList.Count > 0 && cRMspSelectCrmsysSetting_Result != null)
				{
					int result2 = 0;
					int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result2);
					foreach (WSspSelectWareHouseWithAccLinkField_Result item in linkAccWhList)
					{
						string text = "";
						string value = "";
						text = item.WrhsLinkAccWhName;
						switch (result2)
						{
						case 8:
						{
							if (withWrhsLinkAccWhCode)
							{
								value = item.WrhsLinkAccWhCode;
								break;
							}
							text = "";
							value = "";
							if (string.IsNullOrWhiteSpace(item.WrhsLinkAccWareHouses))
							{
								break;
							}
							List<CommonWithIdStrViewModel> list3 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(item.WrhsLinkAccWareHouses);
							if (list3 == null || list3.Count <= 0)
							{
								break;
							}
							foreach (CommonWithIdStrViewModel item2 in list3)
							{
								list.Add(new SelectListItem
								{
									Text = item2.Name,
									Value = item2.Code,
									Selected = false
								});
							}
							break;
						}
						case 9:
						{
							if (withWrhsLinkAccWhCode)
							{
								value = item.WrhsLinkAccWhCode;
								break;
							}
							text = "";
							value = "";
							if (string.IsNullOrWhiteSpace(item.WrhsLinkAccWareHouses))
							{
								break;
							}
							List<CommonWithIdStrViewModel> list4 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(item.WrhsLinkAccWareHouses);
							if (list4 == null || list4.Count <= 0)
							{
								break;
							}
							foreach (CommonWithIdStrViewModel item3 in list4)
							{
								list.Add(new SelectListItem
								{
									Text = item3.Name,
									Value = item3.Code,
									Selected = false
								});
							}
							break;
						}
						case 11:
						{
							if (withWrhsLinkAccWhCode)
							{
								value = item.WrhsLinkAccWhCode;
								break;
							}
							text = "";
							value = "";
							if (string.IsNullOrWhiteSpace(item.WrhsLinkAccWareHouses))
							{
								break;
							}
							List<CommonWithIdStrViewModel> list9 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(item.WrhsLinkAccWareHouses);
							if (list9 == null || list9.Count <= 0)
							{
								break;
							}
							foreach (CommonWithIdStrViewModel item4 in list9)
							{
								list.Add(new SelectListItem
								{
									Text = item4.Name,
									Value = item4.Code,
									Selected = false
								});
							}
							break;
						}
						case 12:
						{
							if (withWrhsLinkAccWhCode)
							{
								value = item.WrhsLinkAccWhCode;
								break;
							}
							text = "";
							value = "";
							if (string.IsNullOrWhiteSpace(item.WrhsLinkAccWareHouses))
							{
								break;
							}
							List<CommonWithIdStrViewModel> list10 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(item.WrhsLinkAccWareHouses);
							if (list10 == null || list10.Count <= 0)
							{
								break;
							}
							foreach (CommonWithIdStrViewModel item5 in list10)
							{
								list.Add(new SelectListItem
								{
									Text = item5.Name,
									Value = item5.Id,
									Selected = false
								});
							}
							break;
						}
						case 17:
						{
							if (withWrhsLinkAccWhCode)
							{
								value = item.WrhsLinkAccWhCode;
								break;
							}
							text = "";
							value = "";
							if (string.IsNullOrWhiteSpace(item.WrhsLinkAccWareHouses))
							{
								break;
							}
							List<CommonWithIdStrViewModel> list7 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(item.WrhsLinkAccWareHouses);
							if (list7 == null || list7.Count <= 0)
							{
								break;
							}
							foreach (CommonWithIdStrViewModel item6 in list7)
							{
								list.Add(new SelectListItem
								{
									Text = item6.Name,
									Value = item6.Id,
									Selected = false
								});
							}
							break;
						}
						case 18:
						{
							if (withWrhsLinkAccWhCode)
							{
								value = item.WrhsLinkAccWhCode;
								break;
							}
							text = "";
							value = "";
							if (string.IsNullOrWhiteSpace(item.WrhsLinkAccWareHouses))
							{
								break;
							}
							List<CommonWithIdStrViewModel> list5 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(item.WrhsLinkAccWareHouses);
							if (list5 == null || list5.Count <= 0)
							{
								break;
							}
							foreach (CommonWithIdStrViewModel item7 in list5)
							{
								list.Add(new SelectListItem
								{
									Text = item7.Name,
									Value = item7.Id,
									Selected = false
								});
							}
							break;
						}
						case 19:
						{
							if (withWrhsLinkAccWhCode)
							{
								value = item.WrhsLinkAccWhCode;
								break;
							}
							text = "";
							value = "";
							if (string.IsNullOrWhiteSpace(item.WrhsLinkAccWareHouses))
							{
								break;
							}
							List<CommonWithIdStrViewModel> list6 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(item.WrhsLinkAccWareHouses);
							if (list6 == null || list6.Count <= 0)
							{
								break;
							}
							foreach (CommonWithIdStrViewModel item8 in list6)
							{
								list.Add(new SelectListItem
								{
									Text = item8.Name,
									Value = item8.Id,
									Selected = false
								});
							}
							break;
						}
						case 20:
						{
							if (withWrhsLinkAccWhCode)
							{
								value = item.WrhsLinkAccWhCode;
								break;
							}
							text = "";
							value = "";
							if (string.IsNullOrWhiteSpace(item.WrhsLinkAccWareHouses))
							{
								break;
							}
							List<CommonWithIdStrViewModel> list8 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(item.WrhsLinkAccWareHouses);
							if (list8 == null || list8.Count <= 0)
							{
								break;
							}
							foreach (CommonWithIdStrViewModel item9 in list8)
							{
								list.Add(new SelectListItem
								{
									Text = item9.Name,
									Value = item9.Id,
									Selected = false
								});
							}
							break;
						}
						case 22:
						case 23:
						case 25:
						{
							if (withWrhsLinkAccWhCode)
							{
								value = item.WrhsLinkAccWhCode;
								break;
							}
							text = "";
							value = "";
							if (string.IsNullOrWhiteSpace(item.WrhsLinkAccWareHouses))
							{
								break;
							}
							List<CommonWithIdStrViewModel> list2 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(item.WrhsLinkAccWareHouses);
							if (list2 == null || list2.Count <= 0)
							{
								break;
							}
							foreach (CommonWithIdStrViewModel item10 in list2)
							{
								list.Add(new SelectListItem
								{
									Text = item10.Name,
									Value = item10.Id,
									Selected = false
								});
							}
							break;
						}
						default:
							text = "";
							value = "";
							break;
						case 1:
						case 2:
						case 3:
						case 4:
						case 5:
						case 6:
						case 7:
							break;
						}
						if (!string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(value))
						{
							list.Add(new SelectListItem
							{
								Text = text,
								Value = value,
								Selected = false
							});
						}
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.LinkAccWareHouseSelectList = list;
		return list;
	}

	public JsonResult GetLinkAccWareHousesJs(int whId = 0)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			if (VersionBuyer.LinkAcc)
			{
				CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
				WSspSelectWareHouseWithAccLinkField_Result wSspSelectWareHouseWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)GetLinkAccWhList(fillAuto: false, withWrhsLinkAccWhCode: false, withWrhsLinkAccWhId: false, withWrhsLinkAccWhIdStr: false, withWrhsLinkAccWareHouses: true, removeDups: false), (Func<WSspSelectWareHouseWithAccLinkField_Result, bool>)((WSspSelectWareHouseWithAccLinkField_Result x) => x.WareHouseID == whId));
				if (wSspSelectWareHouseWithAccLinkField_Result != null && cRMspSelectCrmsysSetting_Result != null)
				{
					int result = 0;
					int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result);
					string text = "";
					string value = "";
					text = wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhName;
					switch (result)
					{
					case 8:
					{
						text = "";
						value = "";
						if (string.IsNullOrWhiteSpace(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses))
						{
							break;
						}
						List<CommonWithIdStrViewModel> list8 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses);
						if (list8 == null || list8.Count <= 0)
						{
							break;
						}
						foreach (CommonWithIdStrViewModel item in list8)
						{
							list.Add(new SelectListItem
							{
								Text = item.Name,
								Value = item.Code,
								Selected = false
							});
						}
						break;
					}
					case 9:
					{
						text = "";
						value = "";
						if (string.IsNullOrWhiteSpace(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses))
						{
							break;
						}
						List<CommonWithIdStrViewModel> list9 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses);
						if (list9 == null || list9.Count <= 0)
						{
							break;
						}
						foreach (CommonWithIdStrViewModel item2 in list9)
						{
							list.Add(new SelectListItem
							{
								Text = item2.Name,
								Value = item2.Code,
								Selected = false
							});
						}
						break;
					}
					case 11:
					{
						text = "";
						value = "";
						if (string.IsNullOrWhiteSpace(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses))
						{
							break;
						}
						List<CommonWithIdStrViewModel> list5 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses);
						if (list5 == null || list5.Count <= 0)
						{
							break;
						}
						foreach (CommonWithIdStrViewModel item3 in list5)
						{
							list.Add(new SelectListItem
							{
								Text = item3.Name,
								Value = item3.Code,
								Selected = false
							});
						}
						break;
					}
					case 12:
					{
						text = "";
						value = "";
						if (string.IsNullOrWhiteSpace(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses))
						{
							break;
						}
						List<CommonWithIdStrViewModel> list3 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses);
						if (list3 == null || list3.Count <= 0)
						{
							break;
						}
						foreach (CommonWithIdStrViewModel item4 in list3)
						{
							list.Add(new SelectListItem
							{
								Text = item4.Name,
								Value = item4.Id,
								Selected = false
							});
						}
						break;
					}
					case 17:
					{
						text = "";
						value = "";
						if (string.IsNullOrWhiteSpace(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses))
						{
							break;
						}
						List<CommonWithIdStrViewModel> list4 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses);
						if (list4 == null || list4.Count <= 0)
						{
							break;
						}
						foreach (CommonWithIdStrViewModel item5 in list4)
						{
							list.Add(new SelectListItem
							{
								Text = item5.Name,
								Value = item5.Id,
								Selected = false
							});
						}
						break;
					}
					case 18:
					{
						text = "";
						value = "";
						if (string.IsNullOrWhiteSpace(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses))
						{
							break;
						}
						List<CommonWithIdStrViewModel> list7 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses);
						if (list7 == null || list7.Count <= 0)
						{
							break;
						}
						foreach (CommonWithIdStrViewModel item6 in list7)
						{
							list.Add(new SelectListItem
							{
								Text = item6.Name,
								Value = item6.Id,
								Selected = false
							});
						}
						break;
					}
					case 19:
					{
						text = "";
						value = "";
						if (string.IsNullOrWhiteSpace(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses))
						{
							break;
						}
						List<CommonWithIdStrViewModel> list10 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses);
						if (list10 == null || list10.Count <= 0)
						{
							break;
						}
						foreach (CommonWithIdStrViewModel item7 in list10)
						{
							list.Add(new SelectListItem
							{
								Text = item7.Name,
								Value = item7.Id,
								Selected = false
							});
						}
						break;
					}
					case 20:
					{
						text = "";
						value = "";
						if (string.IsNullOrWhiteSpace(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses))
						{
							break;
						}
						List<CommonWithIdStrViewModel> list6 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses);
						if (list6 == null || list6.Count <= 0)
						{
							break;
						}
						foreach (CommonWithIdStrViewModel item8 in list6)
						{
							list.Add(new SelectListItem
							{
								Text = item8.Name,
								Value = item8.Id,
								Selected = false
							});
						}
						break;
					}
					case 22:
					case 23:
					case 25:
					{
						text = "";
						value = "";
						if (string.IsNullOrWhiteSpace(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses))
						{
							break;
						}
						List<CommonWithIdStrViewModel> list2 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses);
						if (list2 == null || list2.Count <= 0)
						{
							break;
						}
						foreach (CommonWithIdStrViewModel item9 in list2)
						{
							list.Add(new SelectListItem
							{
								Text = item9.Name,
								Value = item9.Id,
								Selected = false
							});
						}
						break;
					}
					default:
						text = "";
						value = "";
						break;
					case 1:
					case 2:
					case 3:
					case 4:
					case 5:
					case 6:
					case 7:
						break;
					}
					if (!string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(value))
					{
						list.Add(new SelectListItem
						{
							Text = text,
							Value = value,
							Selected = false
						});
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.LinkAccWareHouseSelectList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
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
	public int FindCostPermission()
	{
		int result = 0;
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			ObjectResult<WSspSelectRollPrdCostPermission_Result> objectResult = _db.WSspSelectRollPrdCostPermission(UserLogin.CurrentUser.RollId, result2);
			result = ((objectResult != null && Enumerable.Count<WSspSelectRollPrdCostPermission_Result>((IEnumerable<WSspSelectRollPrdCostPermission_Result>)objectResult) > 0) ? 1 : 0);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public WSspReturnProductPriceViewModel ReturnProductPriceResult(int prdId, int prdPriceGroupId, int currUnitId = 0, int cmpId = 0, int whId = 0, string CrmOrdType = "pord", string linkedPrdIds = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int? centerId = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId : null);
		WSspReturnProductPriceViewModel wSspReturnProductPriceViewModel = new WSspReturnProductPriceViewModel();
		try
		{
			WSspReturnProductPrice_Result wSspReturnProductPrice_Result = Enumerable.FirstOrDefault<WSspReturnProductPrice_Result>((IEnumerable<WSspReturnProductPrice_Result>)_db.WSspReturnProductPrice(prdId, prdPriceGroupId, lCID, result, currUnitId, centerId)) ?? new WSspReturnProductPrice_Result
			{
				Price = 0m,
				CurrencyPrice = default(decimal),
				CurrencyUnit = "",
				CooperationPrice = default(decimal),
				CurrencyUnitId = 0,
				Discount = default(decimal),
				DiscountPrecent = default(decimal),
				DocNumber = null,
				TaxIndex = null
			};
			if (wSspReturnProductPrice_Result != null)
			{
				wSspReturnProductPriceViewModel = new WSspReturnProductPriceViewModel
				{
					PrdId = wSspReturnProductPrice_Result.PrdId,
					DocDate = wSspReturnProductPrice_Result.DocDate,
					DocDateTime = wSspReturnProductPrice_Result.DocDateTime,
					DocNumber = wSspReturnProductPrice_Result.DocNumber,
					Price = wSspReturnProductPrice_Result.Price,
					CurrencyPrice = wSspReturnProductPrice_Result.CurrencyPrice,
					CurrencyUnitId = wSspReturnProductPrice_Result.CurrencyUnitId,
					CurrencyUnit = wSspReturnProductPrice_Result.CurrencyUnit,
					CurrencyUnitEn = wSspReturnProductPrice_Result.CurrencyUnitEn,
					CooperationPrice = wSspReturnProductPrice_Result.CooperationPrice,
					PricePercent = wSspReturnProductPrice_Result.PricePercent,
					DiscountPrecent = wSspReturnProductPrice_Result.DiscountPrecent,
					Discount = wSspReturnProductPrice_Result.Discount,
					OtherPrice = wSspReturnProductPrice_Result.OtherPrice,
					CurrencyRate = wSspReturnProductPrice_Result.CurrencyRate,
					IsDecimal = (wSspReturnProductPrice_Result.IsDecimal.HasValue && wSspReturnProductPrice_Result.IsDecimal != false),
					TaxIndex = wSspReturnProductPrice_Result.TaxIndex
				};
				wSspReturnProductPriceViewModel.SumLinkedProductPrice = Enumerable.FirstOrDefault<decimal?>((IEnumerable<decimal?>)_db.WSspReturnSumLinkedProductPrice(prdId, prdPriceGroupId, currUnitId, linkedPrdIds, centerId)) ?? new decimal?(default(decimal));
			}
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			bool flag = false;
			int num = 0;
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				flag = ((cRMspSelectCrmsysSetting_Result.PrdPriceFromLink.HasValue && cRMspSelectCrmsysSetting_Result.PrdPriceFromLink.GetValueOrDefault()) ? true : false);
				num = cRMspSelectCrmsysSetting_Result.LinkAccSystemId.GetValueOrDefault();
			}
			if (flag && num > 0 && wSspReturnProductPriceViewModel != null)
			{
				ProductController productController = new ProductController();
				string text = "";
				if (num == 3)
				{
					decimal prdPrice = default(decimal);
					double prdQuantity = 0.0;
					productController.TarazGetPrdQuantityAndPrice(prdId, cmpId, whId, prdPriceGroupId, ref prdPrice, ref prdQuantity, CrmOrdType, 0);
					text = prdPrice.ToString();
				}
				decimal result2 = default(decimal);
				if (!string.IsNullOrEmpty(text))
				{
					decimal.TryParse(text, out result2);
					wSspReturnProductPriceViewModel.DocNumber = result2.ToString();
				}
				else
				{
					wSspReturnProductPriceViewModel.DocNumber = "0";
				}
			}
			else
			{
				wSspReturnProductPriceViewModel.DocNumber = null;
			}
			if (wSspReturnProductPriceViewModel != null)
			{
				if (wSspReturnProductPriceViewModel.DocDateTime.HasValue)
				{
					wSspReturnProductPriceViewModel.DocDate = (wSspReturnProductPriceViewModel.DocDateTime.HasValue ? wSspReturnProductPriceViewModel.DocDateTime.Value.ToString("yyyy/MM/dd") : "");
				}
				else
				{
					wSspReturnProductPriceViewModel.DocDate = "";
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return wSspReturnProductPriceViewModel;
	}

	[AjaxOnly]
	public JsonResult ReturnProductPrice(int prdId, int prdPriceGroupId, int currUnitId = 0, int cmpId = 0, int whId = 0, string CrmOrdType = "pord", string linkedPrdIds = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		WSspReturnProductPriceViewModel data = new WSspReturnProductPriceViewModel();
		try
		{
			data = ReturnProductPriceResult(prdId, prdPriceGroupId, currUnitId, cmpId, whId, CrmOrdType, linkedPrdIds);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	public WSspCmpPrdSalePriceHistory_Result CmpPrdSalePriceNearHistoryResult(int prdId, int cmpId, int mode)
	{
		WSspCmpPrdSalePriceHistory_Result result = new WSspCmpPrdSalePriceHistory_Result();
		try
		{
			result = Enumerable.FirstOrDefault<WSspCmpPrdSalePriceHistory_Result>((IEnumerable<WSspCmpPrdSalePriceHistory_Result>)_db.WSspCmpPrdSalePriceHistory(cmpId, prdId, mode)) ?? new WSspCmpPrdSalePriceHistory_Result
			{
				cmpId = 0,
				LastCmpPrice = default(decimal),
				LastCmpQuantity = 0.0,
				cmpMinPrice = default(decimal),
				cmpMaxPrice = default(decimal),
				cmpAvePrice = default(decimal)
			};
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[AjaxOnly]
	public JsonResult CmpPrdSalePriceNearHistory(int prdId, int cmpId, int mode)
	{
		WSspCmpPrdSalePriceHistory_Result data = new WSspCmpPrdSalePriceHistory_Result();
		try
		{
			data = CmpPrdSalePriceNearHistoryResult(prdId, cmpId, mode);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	public WSspPrdSalePriceHistory_Result PrdSalePriceHistoryResult(int prdId, int mode)
	{
		WSspPrdSalePriceHistory_Result result = new WSspPrdSalePriceHistory_Result();
		try
		{
			result = Enumerable.FirstOrDefault<WSspPrdSalePriceHistory_Result>((IEnumerable<WSspPrdSalePriceHistory_Result>)_db.WSspPrdSalePriceHistory(prdId, mode)) ?? new WSspPrdSalePriceHistory_Result
			{
				LastPrice = default(decimal),
				LastPriceLastCmp = "",
				LastPriceLastCmpId = 0,
				minPrice = default(decimal),
				minPriceLastCmp = "",
				minPriceLastCmpId = 0,
				maxPrice = default(decimal),
				maxPriceLastCmp = "",
				maxPriceLastCmpId = 0,
				avePrice = default(decimal),
				avePriceLastCmp = "",
				avePriceLastCmpId = 0
			};
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[AjaxOnly]
	public JsonResult PrdSalePriceHistory(int prdId, int mode)
	{
		WSspPrdSalePriceHistory_Result data = new WSspPrdSalePriceHistory_Result();
		try
		{
			data = PrdSalePriceHistoryResult(prdId, mode);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	public ReturnPrdQuantityViewModel ReturnPrdQuantityResult(int prdId, int currId, int whId, double fcr, double fcrI, string tracing, int cmpId = 0, int prdPriceGroupId = 0, string CrmOrdType = "pord", string linkAccWhId = "", string sefareshCode = "", string masterFormName = "", int linkAccSettingDBId = 0, int currItemId = 0)
	{
		ReturnPrdQuantityViewModel returnPrdQuantityViewModel = new ReturnPrdQuantityViewModel();
		returnPrdQuantityViewModel.PrdQuantity = new WSspReturnPrdQuantity_Result();
		returnPrdQuantityViewModel.ValidpordQuantity = 0.0;
		returnPrdQuantityViewModel.QtyRemain = 0.0;
		returnPrdQuantityViewModel.ValidpordQuantityTotal = "0/0";
		returnPrdQuantityViewModel.SoldOrdPrdQuantity = 0.0;
		returnPrdQuantityViewModel.RemainSoldOrdPrdQuantity = 0.0;
		returnPrdQuantityViewModel.SoldOrdPrdQuantityTotal = "0/0";
		try
		{
			tracing = ConvertCharacter.DecodeTracing(tracing);
			int value = 0;
			string text = masterFormName.ToLower();
			string text2 = "frmAddProduct";
			switch (text)
			{
			case "preorder":
				text2 = "frmPreOrderItemDataEntry";
				value = currId;
				break;
			case "saleorder":
				text2 = "frmOrderItemDataEntry";
				break;
			case "buyorder":
				text2 = "frmBuyOrderItemDataEntry";
				break;
			case "stocksupply":
				text2 = "frmStockSupplyItemDataEntry";
				break;
			default:
				text2 = "frmAddProduct";
				break;
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			int id = Financial.Get().Id;
			returnPrdQuantityViewModel.PrdQuantity = Enumerable.FirstOrDefault<WSspReturnPrdQuantity_Result>((IEnumerable<WSspReturnPrdQuantity_Result>)_db.WSspReturnPrdQuantity(prdId, id, whId, 0, lCID, result, fcr, fcrI, tracing, result2));
			if (returnPrdQuantityViewModel.PrdQuantity == null)
			{
				returnPrdQuantityViewModel.PrdQuantity = new WSspReturnPrdQuantity_Result();
			}
			WSspReturnValidPordPrdCount_Result wSspReturnValidPordPrdCount_Result = Enumerable.FirstOrDefault<WSspReturnValidPordPrdCount_Result>((IEnumerable<WSspReturnValidPordPrdCount_Result>)_db.WSspReturnValidPordPrdCount(prdId, value, DateTime.Now, fcr, fcrI, whId, (!string.IsNullOrWhiteSpace(tracing)) ? tracing.Trim() : ""));
			if (wSspReturnValidPordPrdCount_Result != null)
			{
				returnPrdQuantityViewModel.ValidpordQuantity = wSspReturnValidPordPrdCount_Result.ValidpordQuantity.GetValueOrDefault();
				returnPrdQuantityViewModel.ValidpordQuantityTotal = wSspReturnValidPordPrdCount_Result.ValidpordQuantity.GetValueOrDefault() + "/" + wSspReturnValidPordPrdCount_Result.ValidpordQuantityTotal.GetValueOrDefault();
			}
			if (returnPrdQuantityViewModel.PrdQuantity != null)
			{
				double valueOrDefault = returnPrdQuantityViewModel.PrdQuantity.TracingRemainCount.GetValueOrDefault();
				returnPrdQuantityViewModel.QtyRemain = valueOrDefault - returnPrdQuantityViewModel.ValidpordQuantity;
				if (!UserLogin.IsUserAccess(text2, "actShowPrdQuantityRemainCurrAndAll", UserLogin.CurrentUser))
				{
					string text3 = returnPrdQuantityViewModel.PrdQuantity.QuantityRemain.GetValueOrDefault().ToString();
					returnPrdQuantityViewModel.PrdQuantity.RemainCurrAndAll = text3 + "/" + text3;
				}
			}
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			bool flag = false;
			int num = 0;
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				flag = ((cRMspSelectCrmsysSetting_Result.InvStockFromLink.HasValue && cRMspSelectCrmsysSetting_Result.InvStockFromLink.GetValueOrDefault()) ? true : false);
				num = cRMspSelectCrmsysSetting_Result.LinkAccSystemId.GetValueOrDefault();
			}
			if (flag && num > 0 && returnPrdQuantityViewModel.PrdQuantity != null)
			{
				ProductController productController = new ProductController();
				string text4 = "";
				switch (num)
				{
				case 3:
				{
					decimal prdPrice = default(decimal);
					double prdQuantity = 0.0;
					productController.TarazGetPrdQuantityAndPrice(prdId, cmpId, whId, prdPriceGroupId, ref prdPrice, ref prdQuantity, CrmOrdType, 0);
					text4 = prdQuantity.ToString();
					break;
				}
				case 4:
					text4 = productController.HolooGetPrdQuantity(prdId, linkAccSettingDBId);
					break;
				case 6:
					text4 = productController.KyanGetPrdQuantity(prdId, whId);
					break;
				case 7:
					text4 = productController.PayvastGetPrdQuantity(prdId, whId);
					break;
				case 11:
					text4 = productController.ShomaranGetPrdQuantity(prdId, whId, linkAccWhId, tracing, sefareshCode);
					break;
				case 12:
					text4 = productController.LinkAccGetPrdQuantity(num, prdId, whId, linkAccWhId, tracing);
					break;
				default:
					text4 = productController.LinkAccGetPrdQuantity(num, prdId, whId, linkAccWhId, tracing, "", prdPriceGroupId);
					break;
				}
				double result3 = 0.0;
				if (!string.IsNullOrEmpty(text4) && text4 != Labels.frmError)
				{
					double.TryParse(text4, out result3);
				}
				returnPrdQuantityViewModel.PrdQuantity.TracingRemainCount = result3;
				returnPrdQuantityViewModel.QtyRemain = result3 - returnPrdQuantityViewModel.ValidpordQuantity;
			}
			double result4 = 0.0;
			double result5 = 0.0;
			int value2 = 0;
			if (masterFormName.ToLower() == "saleorder")
			{
				value2 = currItemId;
			}
			WSspReturnSoldOrdPrdCount_Result wSspReturnSoldOrdPrdCount_Result = Enumerable.FirstOrDefault<WSspReturnSoldOrdPrdCount_Result>((IEnumerable<WSspReturnSoldOrdPrdCount_Result>)_dbIII.WSspReturnSoldOrdPrdCount(prdId, value2, fcr, fcrI, whId, tracing, result2));
			if (wSspReturnSoldOrdPrdCount_Result != null)
			{
				double.TryParse(wSspReturnSoldOrdPrdCount_Result.RemainOrdQty.ToString(), out result4);
				double.TryParse(wSspReturnSoldOrdPrdCount_Result.RemainOrdQtyTotal.ToString(), out result5);
			}
			returnPrdQuantityViewModel.SoldOrdPrdQuantity = result4;
			returnPrdQuantityViewModel.SoldOrdPrdQuantityTotal = result4 + "/" + result5;
			double result6 = 0.0;
			if (returnPrdQuantityViewModel.PrdQuantity != null)
			{
				double.TryParse(returnPrdQuantityViewModel.PrdQuantity.TracingRemainCount.ToString(), out result6);
			}
			returnPrdQuantityViewModel.RemainSoldOrdPrdQuantity = result6 - result4;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return returnPrdQuantityViewModel;
	}

	[AjaxOnly]
	public JsonResult ReturnPrdQuantity(int prdId, int currId, int whId, double fcr, double fcrI, string tracing, int cmpId = 0, int prdPriceGroupId = 0, string CrmOrdType = "pord", string linkAccWhId = "", string sefareshCode = "", string masterFormName = "", int linkAccSettingDBId = 0, int currItemId = 0)
	{
		ReturnPrdQuantityViewModel returnPrdQuantityViewModel = new ReturnPrdQuantityViewModel();
		returnPrdQuantityViewModel.PrdQuantity = new WSspReturnPrdQuantity_Result();
		returnPrdQuantityViewModel.ValidpordQuantity = 0.0;
		returnPrdQuantityViewModel.QtyRemain = 0.0;
		returnPrdQuantityViewModel.ValidpordQuantityTotal = "0/0";
		try
		{
			tracing = ConvertCharacter.DecodeTracing(tracing);
			returnPrdQuantityViewModel = ReturnPrdQuantityResult(prdId, currId, whId, fcr, fcrI, tracing, cmpId, prdPriceGroupId, CrmOrdType, linkAccWhId, sefareshCode, masterFormName, linkAccSettingDBId, currItemId);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(returnPrdQuantityViewModel, JsonRequestBehavior.AllowGet);
	}

	public WSspCmpPrdBuyCostNearHistory_Result CmpPrdBuyCostNearHistoryResult(int prdId, int cmpId)
	{
		WSspCmpPrdBuyCostNearHistory_Result result = new WSspCmpPrdBuyCostNearHistory_Result();
		try
		{
			result = Enumerable.FirstOrDefault<WSspCmpPrdBuyCostNearHistory_Result>((IEnumerable<WSspCmpPrdBuyCostNearHistory_Result>)_db.WSspCmpPrdBuyCostNearHistory(cmpId, prdId)) ?? new WSspCmpPrdBuyCostNearHistory_Result
			{
				bordICost = default(decimal),
				bordIQuantity = 0.0
			};
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[AjaxOnly]
	public JsonResult CmpPrdBuyCostNearHistory(int prdId, int cmpId)
	{
		WSspCmpPrdBuyCostNearHistory_Result data = new WSspCmpPrdBuyCostNearHistory_Result();
		try
		{
			data = CmpPrdBuyCostNearHistoryResult(prdId, cmpId);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	public WSspReturnProductCost_Result ReturnProductCostResult(int prdId, int prdCostGroupId, int currUnitId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int? centerId = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId : null);
		WSspReturnProductCost_Result result2 = new WSspReturnProductCost_Result();
		try
		{
			result2 = Enumerable.FirstOrDefault<WSspReturnProductCost_Result>((IEnumerable<WSspReturnProductCost_Result>)_db.WSspReturnProductCost(prdId, prdCostGroupId, lCID, result, currUnitId, centerId)) ?? new WSspReturnProductCost_Result
			{
				Cost = 0m,
				CurrencyCost = default(decimal),
				CurrencyUnit = "",
				CurrencyUnitId = 0,
				IsDecimal = false
			};
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result2;
	}

	[AjaxOnly]
	public JsonResult ReturnProductCost(int prdId, int prdCostGroupId, int currUnitId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		WSspReturnProductCost_Result data = new WSspReturnProductCost_Result();
		try
		{
			data = ReturnProductCostResult(prdId, prdCostGroupId, currUnitId);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public double ReturnPricePartRateFromCmpGroupII(int cmpId)
	{
		double result = 0.0;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		if (result2 <= 0)
		{
			result2 = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			double? num = Enumerable.FirstOrDefault<double?>((IEnumerable<double?>)_db.WSspReturnPricePartRateFromCmpGroupII(cmpId));
			if (num.HasValue)
			{
				double.TryParse(num.ToString(), out result);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[LoginAuthorize]
	public string AddProductItem(AddProductViewModel addProduct)
	{
		//IL_102c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1080: Unknown result type (might be due to invalid IL or missing references)
		//IL_10d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_121d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1271: Unknown result type (might be due to invalid IL or missing references)
		//IL_12c5: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass46_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass46_0();
		CS_0024_003C_003E8__locals0.addProduct = addProduct;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		GetCurrencyUnit();
		GetDeliveryTerms();
		GetProductColor();
		string result = "";
		if (CS_0024_003C_003E8__locals0.addProduct.ProductId > 0)
		{
			try
			{
				CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
				int? centerId = null;
				if (currentUser != null)
				{
					centerId = currentUser.UserLastCId;
				}
				string crmOrdType = "pord";
				string text = CS_0024_003C_003E8__locals0.addProduct.MasterForm.ToLower();
				string text2 = "frmAddProduct";
				switch (text)
				{
				case "preorder":
					text2 = "frmPreOrderItemDataEntry";
					break;
				case "saleorder":
					text2 = "frmOrderItemDataEntry";
					crmOrdType = "ord";
					break;
				case "buyorder":
					text2 = "frmBuyOrderItemDataEntry";
					crmOrdType = "bord";
					break;
				case "stocksupply":
					text2 = "frmStockSupplyItemDataEntry";
					break;
				default:
					text2 = "frmAddProduct";
					break;
				}
				string linkAccSystemTitle = CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
				switch (text)
				{
				case "preorder":
					if (PreOrder.IsSentToLinkAccByAction(CS_0024_003C_003E8__locals0.addProduct.MasterId))
					{
						return "0|" + string.Format(Messages.msgErrorUnableChangeInSentToLinkAcc, linkAccSystemTitle);
					}
					break;
				case "saleorder":
					if (Order.IsSentToLinkAccByAction(CS_0024_003C_003E8__locals0.addProduct.MasterId))
					{
						return "0|" + string.Format(Messages.msgErrorUnableChangeInSentToLinkAcc, linkAccSystemTitle);
					}
					break;
				case "buyorder":
					if (BuyOrder.IsSentToLinkAccByAction(CS_0024_003C_003E8__locals0.addProduct.MasterId))
					{
						return "0|" + string.Format(Messages.msgErrorUnableChangeInSentToLinkAcc, linkAccSystemTitle);
					}
					break;
				}
				CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
				bool flag = false;
				int num = 0;
				if (cRMspSelectCrmsysSetting_Result != null)
				{
					flag = ((cRMspSelectCrmsysSetting_Result.InvStockFromLink.HasValue && cRMspSelectCrmsysSetting_Result.InvStockFromLink.GetValueOrDefault()) ? true : false);
					num = cRMspSelectCrmsysSetting_Result.LinkAccSystemId.GetValueOrDefault();
				}
				if (text == "preorder" && !string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.addProduct.Tracing) && UserLogin.IsUserAccess("frmPreOrder", "actCanNotVerifyNoStockFromShop", currentUser))
				{
					int cmpId = 0;
					WSspSelectPreOrderWithId_Result wSspSelectPreOrderWithId_Result = Enumerable.FirstOrDefault<WSspSelectPreOrderWithId_Result>((IEnumerable<WSspSelectPreOrderWithId_Result>)_db.WSspSelectPreOrderWithId(CS_0024_003C_003E8__locals0.addProduct.MasterId, lCID, CS_0024_003C_003E8__locals0.defLangID));
					if (wSspSelectPreOrderWithId_Result != null)
					{
						cmpId = wSspSelectPreOrderWithId_Result.pordCompanyId.GetValueOrDefault();
					}
					double result2 = 0.0;
					if (flag && num > 0)
					{
						new ProductController();
						string text3 = "";
						text3 = CRMIdeal.Classes.Helper.OtherSystems.GetPrdQuantity(currentUser.UserId, CS_0024_003C_003E8__locals0.addProduct.ProductId, CS_0024_003C_003E8__locals0.addProduct.WHId.GetValueOrDefault(), CS_0024_003C_003E8__locals0.addProduct.LinkAccWHIdStr ?? "", CS_0024_003C_003E8__locals0.addProduct.Tracing ?? "", cmpId, "", CS_0024_003C_003E8__locals0.addProduct.LinkAccSettingDBId.GetValueOrDefault());
						if (!string.IsNullOrEmpty(text3))
						{
							if (text3 == Labels.frmError)
							{
								text3 = "0";
							}
							if (text3 != Labels.frmError)
							{
								double.TryParse(text3, out result2);
							}
						}
					}
					ObjectParameter resultJson = new ObjectParameter("ResultJson", "");
					WSspCheckDuplicatePreOrderItemTracingFromShop_Result wSspCheckDuplicatePreOrderItemTracingFromShop_Result = Enumerable.FirstOrDefault<WSspCheckDuplicatePreOrderItemTracingFromShop_Result>((IEnumerable<WSspCheckDuplicatePreOrderItemTracingFromShop_Result>)_dbII.WSspCheckDuplicatePreOrderItemTracingFromShop(CS_0024_003C_003E8__locals0.addProduct.DetailId, CS_0024_003C_003E8__locals0.addProduct.ProductId, CS_0024_003C_003E8__locals0.addProduct.WHId, CS_0024_003C_003E8__locals0.addProduct.Tracing, result2, centerId, lCID, CS_0024_003C_003E8__locals0.defLangID, false, resultJson));
					if (wSspCheckDuplicatePreOrderItemTracingFromShop_Result != null && wSspCheckDuplicatePreOrderItemTracingFromShop_Result.PreOrderItemID > 0)
					{
						string text4 = (wSspCheckDuplicatePreOrderItemTracingFromShop_Result.pordDateTime.HasValue ? wSspCheckDuplicatePreOrderItemTracingFromShop_Result.pordDateTime.Value.ToString("yyyy/MM/dd") : "");
						return "0|" + string.Format(Messages.msgErrorNotSaveDupTracingByFoShop, Labels.lblPOrd, wSspCheckDuplicatePreOrderItemTracingFromShop_Result.pordNumber.GetValueOrDefault().ToString(), text4, CS_0024_003C_003E8__locals0.addProduct.Tracing ?? "");
					}
				}
				if (text == "saleorder" && CS_0024_003C_003E8__locals0.addProduct.SaleCenterId.GetValueOrDefault() != 0)
				{
					CRMspSelectFoSetting_Result foSetting = CRMIdeal.Classes.Helper.Setting.GetFoSetting();
					if (foSetting != null)
					{
						bool result3 = false;
						bool.TryParse(foSetting.ShpUniqueSaleCenterParentInOrd.ToString(), out result3);
						if (result3)
						{
							ObjectParameter objectParameter = new ObjectParameter("Result", typeof(int));
							_dbII.WSspCheckOrderItemSaleCenterUnique(CS_0024_003C_003E8__locals0.addProduct.MasterId, CS_0024_003C_003E8__locals0.addProduct.SaleCenterId, objectParameter);
							if (objectParameter != null && objectParameter.Value != null)
							{
								int result4 = 0;
								int.TryParse(objectParameter.Value.ToString(), out result4);
								if (result4 == 0)
								{
									return "0|" + "msgErrorNotSaveOrdItemByDifferentOrdSaleCenter".OrderMessages();
								}
							}
						}
					}
				}
				bool result5 = false;
				bool result6 = false;
				bool result7 = false;
				int result8 = 1;
				WSspSelectProductsWithId_Result wSspSelectProductsWithId_Result = Enumerable.FirstOrDefault<WSspSelectProductsWithId_Result>((IEnumerable<WSspSelectProductsWithId_Result>)_db.WSspSelectProductsWithId(CS_0024_003C_003E8__locals0.addProduct.ProductId, lCID, CS_0024_003C_003E8__locals0.defLangID));
				if (wSspSelectProductsWithId_Result != null)
				{
					bool.TryParse(wSspSelectProductsWithId_Result.PrdQtyNoFCR.ToString(), out result5);
					bool.TryParse(wSspSelectProductsWithId_Result.PrdMustFullTracingCode.ToString(), out result6);
					bool.TryParse(wSspSelectProductsWithId_Result.PrdSingleItem.ToString(), out result7);
					int.TryParse(wSspSelectProductsWithId_Result.PrdKind.ToString(), out result8);
				}
				else
				{
					bool.TryParse(CS_0024_003C_003E8__locals0.addProduct.PrdQtyNoFCR.ToString(), out result5);
					bool.TryParse(CS_0024_003C_003E8__locals0.addProduct.PrdMustFullTracingCode.ToString(), out result6);
					bool.TryParse(CS_0024_003C_003E8__locals0.addProduct.PrdSingleItem.ToString(), out result7);
				}
				int cmpId2 = 0;
				int num2 = 0;
				if (text == "preorder" || text == "saleorder")
				{
					bool flag2 = false;
					if (text == "preorder")
					{
						WSspSelectPreOrderWithId_Result wSspSelectPreOrderWithId_Result2 = Enumerable.FirstOrDefault<WSspSelectPreOrderWithId_Result>((IEnumerable<WSspSelectPreOrderWithId_Result>)_db.WSspSelectPreOrderWithId(CS_0024_003C_003E8__locals0.addProduct.MasterId, lCID, CS_0024_003C_003E8__locals0.defLangID));
						if (wSspSelectPreOrderWithId_Result2 != null)
						{
							cmpId2 = wSspSelectPreOrderWithId_Result2.pordCompanyId.GetValueOrDefault();
						}
						if (UserLogin.IsUserAccess(text2, "actCanNotSelectWithNoStockInPord", currentUser) || UserLogin.IsUserAccess(text2, "actCanNotSelectWithNoReserveStockInPord", currentUser) || UserLogin.IsUserAccess(text2, "actCanNotSelectWithNoSoldStockInPord", currentUser))
						{
							flag2 = true;
						}
					}
					else if (text == "saleorder")
					{
						WSspSelectOrderById_Result wSspSelectOrderById_Result = Enumerable.FirstOrDefault<WSspSelectOrderById_Result>((IEnumerable<WSspSelectOrderById_Result>)_db.WSspSelectOrderById(CS_0024_003C_003E8__locals0.addProduct.MasterId, lCID, CS_0024_003C_003E8__locals0.defLangID));
						if (wSspSelectOrderById_Result != null)
						{
							cmpId2 = wSspSelectOrderById_Result.ordCompanyId;
							num2 = wSspSelectOrderById_Result.OrderOprType.GetValueOrDefault();
						}
						if (UserLogin.IsUserAccess(text2, "actCanNotSelectWithNoStockInOrd", currentUser) || UserLogin.IsUserAccess(text2, "actCanNotSelectWithNoReserveStockInOrd", currentUser) || UserLogin.IsUserAccess(text2, "actCanNotSelectWithNoSoldStockInOrd", currentUser))
						{
							flag2 = true;
						}
					}
					if ((!flag || num == 0) && flag2 && result8 != 2 && num2 != 2)
					{
						ReturnPrdQuantityViewModel returnPrdQuantityViewModel = ReturnPrdQuantityResult(CS_0024_003C_003E8__locals0.addProduct.ProductId, CS_0024_003C_003E8__locals0.addProduct.MasterId, CS_0024_003C_003E8__locals0.addProduct.WHId.GetValueOrDefault(), CS_0024_003C_003E8__locals0.addProduct.FCR.GetValueOrDefault(), CS_0024_003C_003E8__locals0.addProduct.FCRI.GetValueOrDefault(), CS_0024_003C_003E8__locals0.addProduct.Tracing ?? "", cmpId2, CS_0024_003C_003E8__locals0.addProduct.PrdPriceGroupId.GetValueOrDefault(), crmOrdType, CS_0024_003C_003E8__locals0.addProduct.LinkAccWHIdStr ?? "", CS_0024_003C_003E8__locals0.addProduct.DescriptionI ?? "", CS_0024_003C_003E8__locals0.addProduct.MasterForm, CS_0024_003C_003E8__locals0.addProduct.LinkAccSettingDBId.GetValueOrDefault(), CS_0024_003C_003E8__locals0.addProduct.DetailId);
						if (returnPrdQuantityViewModel != null)
						{
							double quantity = CS_0024_003C_003E8__locals0.addProduct.Quantity;
							double result9 = 0.0;
							if (returnPrdQuantityViewModel.PrdQuantity != null)
							{
								double.TryParse(returnPrdQuantityViewModel.PrdQuantity.TracingRemainCount.ToString(), out result9);
							}
							double result10 = 0.0;
							double.TryParse(returnPrdQuantityViewModel.QtyRemain.ToString(), out result10);
							double result11 = 0.0;
							double.TryParse(returnPrdQuantityViewModel.RemainSoldOrdPrdQuantity.ToString(), out result11);
							if (((text == "preorder" && UserLogin.IsUserAccess(text2, "actCanNotSelectWithNoStockInPord", currentUser)) || (text == "saleorder" && UserLogin.IsUserAccess(text2, "actCanNotSelectWithNoStockInOrd", currentUser))) && (result9 <= 0.0 || result9 < quantity))
							{
								return "0|" + Messages.ProductLackOfStock;
							}
							if (((text == "preorder" && UserLogin.IsUserAccess(text2, "actCanNotSelectWithNoReserveStockInPord", currentUser)) || (text == "saleorder" && UserLogin.IsUserAccess(text2, "actCanNotSelectWithNoReserveStockInOrd", currentUser))) && result10 < quantity)
							{
								return "0|" + Messages.ProductLackOfReserveStock;
							}
							if (((text == "preorder" && UserLogin.IsUserAccess(text2, "actCanNotSelectWithNoSoldStockInPord", currentUser)) || (text == "saleorder" && UserLogin.IsUserAccess(text2, "actCanNotSelectWithNoSoldStockInOrd", currentUser))) && result11 < quantity)
							{
								return "0|" + Messages.msgErrorProductLackOfSoldStock;
							}
						}
					}
				}
				if (base.ModelState.IsValid)
				{
					switch (CS_0024_003C_003E8__locals0.addProduct.MasterForm)
					{
					case "PreOrderHavePrdMustExist":
					case "preOrder":
					{
						List<WSspCheckUsedPrdSingleItemInPreOrder_Result> list2 = Enumerable.ToList<WSspCheckUsedPrdSingleItemInPreOrder_Result>((IEnumerable<WSspCheckUsedPrdSingleItemInPreOrder_Result>)_dbI.WSspCheckUsedPrdSingleItemInPreOrder(CS_0024_003C_003E8__locals0.addProduct.MasterId, CS_0024_003C_003E8__locals0.addProduct.DetailId, CS_0024_003C_003E8__locals0.addProduct.ProductId));
						if (list2 != null && Enumerable.Any<WSspCheckUsedPrdSingleItemInPreOrder_Result>((IEnumerable<WSspCheckUsedPrdSingleItemInPreOrder_Result>)list2))
						{
							return (!result7) ? ("0|" + Messages.msgErrorNoRegisterPrdInPordWithSingleItem) : ("0|" + Messages.msgErrorNoRegisterPrdSingleItemInPord);
						}
						break;
					}
					case "UserPavProduct":
					{
						List<WSspCheckUsedPrdSingleItemInUserFavproduct_Result> list5 = Enumerable.ToList<WSspCheckUsedPrdSingleItemInUserFavproduct_Result>((IEnumerable<WSspCheckUsedPrdSingleItemInUserFavproduct_Result>)_dbI.WSspCheckUsedPrdSingleItemInUserFavproduct(CS_0024_003C_003E8__locals0.addProduct.MasterId, CS_0024_003C_003E8__locals0.addProduct.DetailId, CS_0024_003C_003E8__locals0.addProduct.ProductId));
						if (list5 != null && Enumerable.Any<WSspCheckUsedPrdSingleItemInUserFavproduct_Result>((IEnumerable<WSspCheckUsedPrdSingleItemInUserFavproduct_Result>)list5))
						{
							return (!result7) ? ("0|" + Messages.msgErrorNoRegisterPrdInFavPrdWithSingleItem) : ("0|" + Messages.msgErrorNoRegisterPrdSingleItemInFavPrd);
						}
						break;
					}
					case "SaleOrder":
					{
						List<WSspCheckUsedPrdSingleItemInOrder_Result> list4 = Enumerable.ToList<WSspCheckUsedPrdSingleItemInOrder_Result>((IEnumerable<WSspCheckUsedPrdSingleItemInOrder_Result>)_dbI.WSspCheckUsedPrdSingleItemInOrder(CS_0024_003C_003E8__locals0.addProduct.MasterId, CS_0024_003C_003E8__locals0.addProduct.DetailId, CS_0024_003C_003E8__locals0.addProduct.ProductId));
						if (list4 != null && Enumerable.Any<WSspCheckUsedPrdSingleItemInOrder_Result>((IEnumerable<WSspCheckUsedPrdSingleItemInOrder_Result>)list4))
						{
							return (!result7) ? ("0|" + Messages.msgErrorNoRegisterPrdInOrdWithSingleItem) : ("0|" + Messages.msgErrorNoRegisterPrdSingleItemInOrd);
						}
						break;
					}
					case "BuyOrder":
					{
						List<WSspCheckUsedPrdSingleItemInBuyOrder_Result> list3 = Enumerable.ToList<WSspCheckUsedPrdSingleItemInBuyOrder_Result>((IEnumerable<WSspCheckUsedPrdSingleItemInBuyOrder_Result>)_dbI.WSspCheckUsedPrdSingleItemInBuyOrder(CS_0024_003C_003E8__locals0.addProduct.MasterId, CS_0024_003C_003E8__locals0.addProduct.DetailId, CS_0024_003C_003E8__locals0.addProduct.ProductId));
						if (list3 != null && Enumerable.Any<WSspCheckUsedPrdSingleItemInBuyOrder_Result>((IEnumerable<WSspCheckUsedPrdSingleItemInBuyOrder_Result>)list3))
						{
							return (!result7) ? ("0|" + Messages.msgErrorNoRegisterPrdInBordWithSingleItem) : ("0|" + Messages.msgErrorNoRegisterPrdSingleItemInBord);
						}
						break;
					}
					case "StockSupply":
					{
						List<WSspCheckUsedPrdSingleItemInStockSupply_Result> list = Enumerable.ToList<WSspCheckUsedPrdSingleItemInStockSupply_Result>((IEnumerable<WSspCheckUsedPrdSingleItemInStockSupply_Result>)_dbII.WSspCheckUsedPrdSingleItemInStockSupply(CS_0024_003C_003E8__locals0.addProduct.MasterId, CS_0024_003C_003E8__locals0.addProduct.DetailId, CS_0024_003C_003E8__locals0.addProduct.ProductId));
						if (list != null && Enumerable.Any<WSspCheckUsedPrdSingleItemInStockSupply_Result>((IEnumerable<WSspCheckUsedPrdSingleItemInStockSupply_Result>)list))
						{
							return (!result7) ? ("0|" + Messages.msgErrorNoRegisterPrdInStsupWithSingleItem) : ("0|" + Messages.msgErrorNoRegisterPrdSingleItemInStsup);
						}
						break;
					}
					}
					CS_0024_003C_003E8__locals0.addProduct.Tracing = ConvertCharacter.DecodeTracing(CS_0024_003C_003E8__locals0.addProduct.Tracing);
					bool flag3 = false;
					CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result2 = SysSeting.Get();
					if (cRMspSelectCrmsysSetting_Result2 != null)
					{
						flag3 = cRMspSelectCrmsysSetting_Result2.MustFullTracingCode.HasValue && cRMspSelectCrmsysSetting_Result2.MustFullTracingCode != false;
					}
					if (flag3)
					{
						if (string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.addProduct.Tracing))
						{
							return "0|" + string.Format(Messages.msgErrorIsNotSpecified, Labels.prdTracing);
						}
					}
					else if (result6 && string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.addProduct.Tracing))
					{
						return "0|" + string.Format(Messages.msgErrorIsNotSpecified, Labels.prdTracing);
					}
					if (CS_0024_003C_003E8__locals0.addProduct.MasterForm == "BuyOrder")
					{
						if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.addProduct.Tracing))
						{
							int value = CS_0024_003C_003E8__locals0.addProduct.ProductId;
							if (UserLogin.IsUserAccess(text2, "actLoadTracingCodeFromAllPrd", UserLogin.CurrentUser))
							{
								value = 0;
							}
							if (UserLogin.IsUserAccess(text2, "actCanNotAddNewTracingCode", UserLogin.CurrentUser) && Enumerable.FirstOrDefault<WSspSelectBuyOrderItemTracing_Result>((IEnumerable<WSspSelectBuyOrderItemTracing_Result>)_dbI.WSspSelectBuyOrderItemTracing(CS_0024_003C_003E8__locals0.addProduct.Tracing, value)) == null)
							{
								return "0|" + string.Format(Messages.msgErrorCanNotAddNewTracingCode, CS_0024_003C_003E8__locals0.addProduct.Tracing);
							}
						}
					}
					else if (CS_0024_003C_003E8__locals0.addProduct.MasterForm == "StockSupply" && !string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.addProduct.Tracing))
					{
						int value2 = CS_0024_003C_003E8__locals0.addProduct.ProductId;
						if (UserLogin.IsUserAccess(text2, "actLoadTracingCodeFromAllPrd", UserLogin.CurrentUser))
						{
							value2 = 0;
						}
						if (UserLogin.IsUserAccess(text2, "actCanNotAddNewTracingCode", UserLogin.CurrentUser) && Enumerable.FirstOrDefault<WSspSelectStockSupplyItemTracing_Result>((IEnumerable<WSspSelectStockSupplyItemTracing_Result>)_dbII.WSspSelectStockSupplyItemTracing(CS_0024_003C_003E8__locals0.addProduct.Tracing, value2)) == null)
						{
							return "0|" + string.Format(Messages.msgErrorCanNotAddNewTracingCode, CS_0024_003C_003E8__locals0.addProduct.Tracing);
						}
					}
					List<CommonMultiLanguageViewModel> list6 = new List<CommonMultiLanguageViewModel>();
					if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.addProduct.QuantityDesc_Lang))
					{
						list6 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.addProduct.QuantityDesc_Lang);
					}
					list6.Add(new CommonMultiLanguageViewModel
					{
						Value = CS_0024_003C_003E8__locals0.addProduct.QuantityDesc,
						LanguageId = lCID
					});
					List<CommonMultiLanguageViewModel> list7 = new List<CommonMultiLanguageViewModel>();
					if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.addProduct.Description_Lang))
					{
						list7 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.addProduct.Description_Lang);
					}
					list7.Add(new CommonMultiLanguageViewModel
					{
						Value = CS_0024_003C_003E8__locals0.addProduct.Description,
						LanguageId = lCID
					});
					List<CommonMultiLanguageViewModel> list8 = new List<CommonMultiLanguageViewModel>();
					if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.addProduct.DescriptionI_Lang))
					{
						list8 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.addProduct.DescriptionI_Lang);
					}
					list8.Add(new CommonMultiLanguageViewModel
					{
						Value = CS_0024_003C_003E8__locals0.addProduct.DescriptionI,
						LanguageId = lCID
					});
					int result12 = 0;
					CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result3 = SysSeting.Get();
					if (cRMspSelectCrmsysSetting_Result3 != null)
					{
						int.TryParse(cRMspSelectCrmsysSetting_Result3.LinkAccSystemId.ToString(), out result12);
					}
					if (result12 == 11 && list8 != null)
					{
						if (list8.Count == 1)
						{
							list8 = new List<CommonMultiLanguageViewModel>();
							foreach (Languages item in Enumerable.ToList<Languages>((IEnumerable<Languages>)Language.Get()))
							{
								CommonMultiLanguageViewModel commonMultiLanguageViewModel = new CommonMultiLanguageViewModel();
								commonMultiLanguageViewModel.LanguageId = item.LanguageID;
								commonMultiLanguageViewModel.Value = CS_0024_003C_003E8__locals0.addProduct.DescriptionI;
								list8.Add(commonMultiLanguageViewModel);
							}
						}
						if (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8))
						{
							foreach (CommonMultiLanguageViewModel item2 in list8)
							{
								item2.Value = CS_0024_003C_003E8__locals0.addProduct.DescriptionI;
							}
						}
					}
					List<CommonMultiLanguageViewModel> list9 = new List<CommonMultiLanguageViewModel>();
					if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.addProduct.ForwarderName_Lang))
					{
						list9 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.addProduct.ForwarderName_Lang);
					}
					list9.Add(new CommonMultiLanguageViewModel
					{
						Value = CS_0024_003C_003E8__locals0.addProduct.ForwarderName,
						LanguageId = lCID
					});
					List<CommonMultiLanguageViewModel> list10 = new List<CommonMultiLanguageViewModel>();
					if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.addProduct.CustomsPart_Lang))
					{
						list10 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.addProduct.CustomsPart_Lang);
					}
					list10.Add(new CommonMultiLanguageViewModel
					{
						Value = CS_0024_003C_003E8__locals0.addProduct.CustomsPart,
						LanguageId = lCID
					});
					List<CommonMultiLanguageViewModel> list11 = new List<CommonMultiLanguageViewModel>();
					if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.addProduct.PrdNickname_Lang))
					{
						list11 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.addProduct.PrdNickname_Lang);
					}
					list11.Add(new CommonMultiLanguageViewModel
					{
						Value = CS_0024_003C_003E8__locals0.addProduct.PrdNickname,
						LanguageId = lCID
					});
					double result13 = 1.0;
					double result14 = 1.0;
					if (CS_0024_003C_003E8__locals0.addProduct.FCR.HasValue && CS_0024_003C_003E8__locals0.addProduct.FCR != 0.0)
					{
						double.TryParse(CS_0024_003C_003E8__locals0.addProduct.FCR.ToString(), out result13);
					}
					if (CS_0024_003C_003E8__locals0.addProduct.FCRI.HasValue && CS_0024_003C_003E8__locals0.addProduct.FCRI != 0.0)
					{
						double.TryParse(CS_0024_003C_003E8__locals0.addProduct.FCRI.ToString(), out result14);
					}
					if (result5)
					{
						result13 = 1.0;
						result14 = 1.0;
					}
					double result15 = 0.0;
					double.TryParse(CS_0024_003C_003E8__locals0.addProduct.QuantityTotal.ToString(), out result15);
					decimal.TryParse(CS_0024_003C_003E8__locals0.addProduct.Discount.ToString(), out var result16);
					decimal.TryParse(CS_0024_003C_003E8__locals0.addProduct.Price.ToString(), out var result17);
					decimal.TryParse(CS_0024_003C_003E8__locals0.addProduct.Round.ToString(), out var result18);
					decimal.TryParse(CS_0024_003C_003E8__locals0.addProduct.RoundPlus.ToString(), out var result19);
					decimal.TryParse(CS_0024_003C_003E8__locals0.addProduct.Tax.ToString(), out var result20);
					decimal num3 = (decimal)(CS_0024_003C_003E8__locals0.addProduct.Quantity * result13 * result14);
					if (result15 > 0.0)
					{
						num3 = (decimal)(result15 * result14);
					}
					if (CS_0024_003C_003E8__locals0.addProduct.DiscountSum.HasValue && result16 == 0m)
					{
						result16 = CS_0024_003C_003E8__locals0.addProduct.DiscountSum.GetValueOrDefault() / num3;
						CS_0024_003C_003E8__locals0.addProduct.Discount = result16;
					}
					decimal.TryParse(CS_0024_003C_003E8__locals0.addProduct.DiscountPrecent.ToString(), out var _);
					if (!CS_0024_003C_003E8__locals0.addProduct.DiscountSum.HasValue)
					{
						decimal? discountSum = CS_0024_003C_003E8__locals0.addProduct.DiscountSum;
						if ((discountSum.GetValueOrDefault() == default(decimal)) & discountSum.HasValue)
						{
							CS_0024_003C_003E8__locals0.addProduct.DiscountSum = num3 * result16;
						}
					}
					_ = result17 - result16 - result18 + result19;
					decimal valueOrDefault = CS_0024_003C_003E8__locals0.addProduct.DiscountSum.GetValueOrDefault();
					decimal num4 = (result17 - result18 + result19) * num3 - valueOrDefault;
					decimal.TryParse(CS_0024_003C_003E8__locals0.addProduct.TaxIndex.ToString(), out var result22);
					if (result22 != 0m)
					{
						CS_0024_003C_003E8__locals0.addProduct.TaxSum = num4 * result22 / 100m;
					}
					else
					{
						CS_0024_003C_003E8__locals0.addProduct.TaxSum = num3 * result20;
					}
					CS_0024_003C_003E8__locals0.addProduct.PriceSum = num4;
					CS_0024_003C_003E8__locals0.addProduct.TotalPrice = CS_0024_003C_003E8__locals0.addProduct.PriceSum + CS_0024_003C_003E8__locals0.addProduct.TaxSum;
					decimal.TryParse(CS_0024_003C_003E8__locals0.addProduct.TspOdr.ToString(), out var result23);
					if (result23 != 0m)
					{
						CS_0024_003C_003E8__locals0.addProduct.TspOdam = num4 * result23 / 100m;
					}
					else
					{
						CS_0024_003C_003E8__locals0.addProduct.TspOdam = default(decimal);
					}
					decimal.TryParse(CS_0024_003C_003E8__locals0.addProduct.TspOlr.ToString(), out var result24);
					if (result24 != 0m)
					{
						CS_0024_003C_003E8__locals0.addProduct.TspOlam = num4 * result24 / 100m;
					}
					else
					{
						CS_0024_003C_003E8__locals0.addProduct.TspOlam = default(decimal);
					}
					decimal num5 = CS_0024_003C_003E8__locals0.addProduct.FacilityCost.GetValueOrDefault();
					decimal valueOrDefault2 = CS_0024_003C_003E8__locals0.addProduct.TotalPrice.GetValueOrDefault();
					decimal num6 = CS_0024_003C_003E8__locals0.addProduct.FacilityCostPercent.GetValueOrDefault();
					if (CS_0024_003C_003E8__locals0.addProduct.FacilityCostPercent.HasValue)
					{
						if (num6 > 0m)
						{
							num5 = Convert.ToDecimal(valueOrDefault2 * num6) / 100m;
						}
					}
					else if (num5 > 0m && valueOrDefault2 > 0m)
					{
						num6 = Convert.ToDecimal(Convert.ToDecimal(num5 * 100m) / valueOrDefault2);
					}
					decimal valueOrDefault3 = CS_0024_003C_003E8__locals0.addProduct.FreightCost.GetValueOrDefault();
					double valueOrDefault4 = CS_0024_003C_003E8__locals0.addProduct.FreightCurrencyRate.GetValueOrDefault(1.0);
					decimal num7 = valueOrDefault3 * (decimal)valueOrDefault4;
					decimal valueOrDefault5 = CS_0024_003C_003E8__locals0.addProduct.CustomsFee.GetValueOrDefault();
					double valueOrDefault6 = CS_0024_003C_003E8__locals0.addProduct.CustomsCurrencyRate.GetValueOrDefault(1.0);
					decimal num8 = valueOrDefault5 * (decimal)valueOrDefault6;
					decimal valueOrDefault7 = CS_0024_003C_003E8__locals0.addProduct.Commission.GetValueOrDefault();
					double valueOrDefault8 = CS_0024_003C_003E8__locals0.addProduct.CommissionCurrencyRate.GetValueOrDefault(1.0);
					decimal num9 = valueOrDefault7 * (decimal)valueOrDefault8;
					decimal value3 = valueOrDefault2 + num5 + num7 + num8 + num9;
					CS_0024_003C_003E8__locals0.addProduct.FacilityCost = num5;
					CS_0024_003C_003E8__locals0.addProduct.FacilityCostPercent = num6;
					CS_0024_003C_003E8__locals0.addProduct.FreightCost = valueOrDefault3;
					CS_0024_003C_003E8__locals0.addProduct.FreightCurrencyRate = valueOrDefault4;
					CS_0024_003C_003E8__locals0.addProduct.FinalFreightCost = num7;
					CS_0024_003C_003E8__locals0.addProduct.CustomsFee = valueOrDefault5;
					CS_0024_003C_003E8__locals0.addProduct.CustomsCurrencyRate = valueOrDefault6;
					CS_0024_003C_003E8__locals0.addProduct.FinalCustomsFee = num8;
					CS_0024_003C_003E8__locals0.addProduct.Commission = valueOrDefault7;
					CS_0024_003C_003E8__locals0.addProduct.CommissionCurrencyRate = valueOrDefault8;
					CS_0024_003C_003E8__locals0.addProduct.FinalCommission = num9;
					bool result25 = false;
					WSspSelectCurrencyUnitsWithId_Result wSspSelectCurrencyUnitsWithId_Result = Enumerable.FirstOrDefault<WSspSelectCurrencyUnitsWithId_Result>((IEnumerable<WSspSelectCurrencyUnitsWithId_Result>)_db.WSspSelectCurrencyUnitsWithId(CS_0024_003C_003E8__locals0.addProduct.CurrencyUnitId, lCID, CS_0024_003C_003E8__locals0.defLangID));
					if (wSspSelectCurrencyUnitsWithId_Result != null)
					{
						bool.TryParse(wSspSelectCurrencyUnitsWithId_Result.IsDecimal.ToString(), out result25);
					}
					if (!result25)
					{
						if (CS_0024_003C_003E8__locals0.addProduct.Discount.HasValue)
						{
							CS_0024_003C_003E8__locals0.addProduct.Discount = RoundCalculation.RoundNumber(CS_0024_003C_003E8__locals0.addProduct.Discount.GetValueOrDefault());
						}
						if (CS_0024_003C_003E8__locals0.addProduct.Tax.HasValue)
						{
							CS_0024_003C_003E8__locals0.addProduct.Tax = RoundCalculation.RoundNumber(CS_0024_003C_003E8__locals0.addProduct.Tax.GetValueOrDefault());
						}
						if (CS_0024_003C_003E8__locals0.addProduct.TaxSum.HasValue)
						{
							CS_0024_003C_003E8__locals0.addProduct.TaxSum = RoundCalculation.RoundNumber(CS_0024_003C_003E8__locals0.addProduct.TaxSum.GetValueOrDefault());
						}
						if (CS_0024_003C_003E8__locals0.addProduct.DiscountSum.HasValue)
						{
							CS_0024_003C_003E8__locals0.addProduct.DiscountSum = RoundCalculation.RoundNumber(CS_0024_003C_003E8__locals0.addProduct.DiscountSum.GetValueOrDefault());
						}
						if (CS_0024_003C_003E8__locals0.addProduct.DiscountISum.HasValue)
						{
							CS_0024_003C_003E8__locals0.addProduct.DiscountISum = RoundCalculation.RoundNumber(CS_0024_003C_003E8__locals0.addProduct.DiscountISum.GetValueOrDefault());
						}
						if (CS_0024_003C_003E8__locals0.addProduct.PriceSum.HasValue)
						{
							CS_0024_003C_003E8__locals0.addProduct.PriceSum = RoundCalculation.RoundNumber(CS_0024_003C_003E8__locals0.addProduct.PriceSum.GetValueOrDefault());
						}
						if (CS_0024_003C_003E8__locals0.addProduct.TotalPrice.HasValue)
						{
							CS_0024_003C_003E8__locals0.addProduct.TotalPrice = RoundCalculation.RoundNumber(CS_0024_003C_003E8__locals0.addProduct.PriceSum.GetValueOrDefault() + CS_0024_003C_003E8__locals0.addProduct.TaxSum.GetValueOrDefault());
						}
						if (CS_0024_003C_003E8__locals0.addProduct.TspOdam.HasValue)
						{
							CS_0024_003C_003E8__locals0.addProduct.TspOdam = RoundCalculation.RoundNumber(CS_0024_003C_003E8__locals0.addProduct.TspOdam.GetValueOrDefault());
						}
						if (CS_0024_003C_003E8__locals0.addProduct.TspOlam.HasValue)
						{
							CS_0024_003C_003E8__locals0.addProduct.TspOlam = RoundCalculation.RoundNumber(CS_0024_003C_003E8__locals0.addProduct.TspOlam.GetValueOrDefault());
						}
					}
					DateTime dateTime = default(DateTime);
					string text5 = "";
					try
					{
						if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.addProduct.TaxClearedDatePersian))
						{
							text5 = PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.addProduct.TaxClearedDatePersian.Replace("/", ""));
							text5 += " 00:00:00";
							switch (lCID)
							{
							case 1065:
								dateTime = DateTime.Parse(text5, new PersianCulture());
								CS_0024_003C_003E8__locals0.addProduct.TaxClearedDatePersian = dateTime.ToString("yyyyMMdd");
								break;
							case 1025:
								dateTime = DateTime.Parse(text5, new CultureInfo("ar-SA"));
								CS_0024_003C_003E8__locals0.addProduct.TaxClearedDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
								break;
							default:
								dateTime = DateTime.Parse(text5, new CultureInfo("en-US"));
								CS_0024_003C_003E8__locals0.addProduct.TaxClearedDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
								break;
							}
							CS_0024_003C_003E8__locals0.addProduct.TaxClearedDate = dateTime;
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						result = "0|" + string.Format(Messages.ErrorInFormat, Labels.PrdTaxClearedDate) + "<br/> ";
						result += string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
					}
					if (CS_0024_003C_003E8__locals0.addProduct.TaxClearedDatePersian != null)
					{
						CS_0024_003C_003E8__locals0.addProduct.TaxClearedDatePersian = CS_0024_003C_003E8__locals0.addProduct.TaxClearedDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
							.Replace(".", "")
							.Replace(",", "")
							.Replace("\\", "");
					}
					try
					{
						if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.addProduct.DeliveryDatePersian))
						{
							text5 = PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.addProduct.DeliveryDatePersian.Replace("/", ""));
							text5 = (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.addProduct.DeliveryTime) ? (text5 + " 00:00:00") : (text5 + " " + CS_0024_003C_003E8__locals0.addProduct.DeliveryTime.Trim()));
							switch (lCID)
							{
							case 1065:
								dateTime = DateTime.Parse(text5, new PersianCulture());
								CS_0024_003C_003E8__locals0.addProduct.DeliveryDatePersian = dateTime.ToString("yyyyMMdd");
								break;
							case 1025:
								dateTime = DateTime.Parse(text5, new CultureInfo("ar-SA"));
								CS_0024_003C_003E8__locals0.addProduct.DeliveryDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
								break;
							default:
								dateTime = DateTime.Parse(text5, new CultureInfo("en-US"));
								CS_0024_003C_003E8__locals0.addProduct.DeliveryDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
								break;
							}
							CS_0024_003C_003E8__locals0.addProduct.DeliveryDate = dateTime;
							CS_0024_003C_003E8__locals0.addProduct.DeliveryDay = DateTimeClass.DefineDayeOfWeekStartWith7(dateTime.DayOfWeek.ToString());
						}
						else
						{
							CS_0024_003C_003E8__locals0.addProduct.DeliveryDate = null;
							CS_0024_003C_003E8__locals0.addProduct.DeliveryDay = null;
						}
					}
					catch (Exception e2)
					{
						ErrorSignal.FromCurrentContext().Raise(e2);
						result = "0|" + string.Format(Messages.ErrorInFormat, Labels.PrdDeliveryDate_I) + "<br/> ";
						result += string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
					}
					if (CS_0024_003C_003E8__locals0.addProduct.DeliveryDatePersian != null)
					{
						CS_0024_003C_003E8__locals0.addProduct.DeliveryDatePersian = CS_0024_003C_003E8__locals0.addProduct.DeliveryDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
							.Replace(".", "")
							.Replace(",", "")
							.Replace("\\", "");
					}
					try
					{
						if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.addProduct.DeliveryEndDatePersian))
						{
							text5 = PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.addProduct.DeliveryEndDatePersian.Replace("/", ""));
							text5 = (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.addProduct.DeliveryEndTime) ? (text5 + " 00:00:00") : (text5 + " " + CS_0024_003C_003E8__locals0.addProduct.DeliveryEndTime.Trim()));
							switch (lCID)
							{
							case 1065:
								dateTime = DateTime.Parse(text5, new PersianCulture());
								CS_0024_003C_003E8__locals0.addProduct.DeliveryEndDatePersian = dateTime.ToString("yyyyMMdd");
								break;
							case 1025:
								dateTime = DateTime.Parse(text5, new CultureInfo("ar-SA"));
								CS_0024_003C_003E8__locals0.addProduct.DeliveryEndDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
								break;
							default:
								dateTime = DateTime.Parse(text5, new CultureInfo("en-US"));
								CS_0024_003C_003E8__locals0.addProduct.DeliveryEndDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
								break;
							}
							CS_0024_003C_003E8__locals0.addProduct.DeliveryEndDate = dateTime;
							CS_0024_003C_003E8__locals0.addProduct.DeliveryEndDay = DateTimeClass.DefineDayeOfWeekStartWith7(dateTime.DayOfWeek.ToString());
						}
						else
						{
							CS_0024_003C_003E8__locals0.addProduct.DeliveryEndDate = null;
							CS_0024_003C_003E8__locals0.addProduct.DeliveryEndDay = null;
						}
					}
					catch (Exception e3)
					{
						ErrorSignal.FromCurrentContext().Raise(e3);
						result = "0|" + string.Format(Messages.ErrorInFormat, Labels.PrdDeliveryEndDate) + "<br/> ";
						result += string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
					}
					if (CS_0024_003C_003E8__locals0.addProduct.DeliveryEndDatePersian != null)
					{
						CS_0024_003C_003E8__locals0.addProduct.DeliveryEndDatePersian = CS_0024_003C_003E8__locals0.addProduct.DeliveryEndDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
							.Replace(".", "")
							.Replace(",", "")
							.Replace("\\", "");
					}
					try
					{
						if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.addProduct.ValidityExpireDatePersian))
						{
							text5 = PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.addProduct.ValidityExpireDatePersian.Replace("/", ""));
							text5 = (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.addProduct.ValidityExpireTime) ? (text5 + " 00:00:00") : (text5 + " " + CS_0024_003C_003E8__locals0.addProduct.ValidityExpireTime.Trim()));
							switch (lCID)
							{
							case 1065:
								dateTime = DateTime.Parse(text5, new PersianCulture());
								CS_0024_003C_003E8__locals0.addProduct.ValidityExpireDatePersian = dateTime.ToString("yyyyMMdd");
								break;
							case 1025:
								dateTime = DateTime.Parse(text5, new CultureInfo("ar-SA"));
								CS_0024_003C_003E8__locals0.addProduct.ValidityExpireDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
								break;
							default:
								dateTime = DateTime.Parse(text5, new CultureInfo("en-US"));
								CS_0024_003C_003E8__locals0.addProduct.ValidityExpireDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
								break;
							}
							CS_0024_003C_003E8__locals0.addProduct.ValidityExpireDate = dateTime;
						}
						else
						{
							CS_0024_003C_003E8__locals0.addProduct.ValidityExpireDate = null;
						}
					}
					catch (Exception e4)
					{
						ErrorSignal.FromCurrentContext().Raise(e4);
						result = "0|" + string.Format(Messages.ErrorInFormat, Labels.PrdValidityExpireDate) + "<br/> ";
						result += string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
					}
					if (CS_0024_003C_003E8__locals0.addProduct.ValidityExpireDatePersian != null)
					{
						CS_0024_003C_003E8__locals0.addProduct.ValidityExpireDatePersian = CS_0024_003C_003E8__locals0.addProduct.ValidityExpireDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
							.Replace(".", "")
							.Replace(",", "")
							.Replace("\\", "");
					}
					int userId = UserLogin.CurrentUser.UserId;
					int id = Financial.Get().Id;
					string appType = Configuration.AppType;
					switch (CS_0024_003C_003E8__locals0.addProduct.MasterForm)
					{
					case "PreOrderHavePrdMustExist":
					case "preOrder":
					{
						if (PreOrder.IsFixed(CS_0024_003C_003E8__locals0.addProduct.MasterId))
						{
							return "0|" + Messages.msgErrorNotActiveProd;
						}
						WSspSelectPreOrderItems_Result wSspSelectPreOrderItems_Result = Enumerable.FirstOrDefault<WSspSelectPreOrderItems_Result>((IEnumerable<WSspSelectPreOrderItems_Result>)Enumerable.OrderByDescending<WSspSelectPreOrderItems_Result, int>((IEnumerable<WSspSelectPreOrderItems_Result>)_db.WSspSelectPreOrderItems(CS_0024_003C_003E8__locals0.addProduct.MasterId, lCID, CS_0024_003C_003E8__locals0.defLangID), (Func<WSspSelectPreOrderItems_Result, int>)((WSspSelectPreOrderItems_Result m) => m.PreOrderItemID)));
						int num11 = wSspSelectPreOrderItems_Result?.pordIPrdId ?? 0;
						_ = wSspSelectPreOrderItems_Result?.pordIOrderView;
						int num12 = 0;
						WSPreOrderItems wSPreOrderItems2;
						if (CS_0024_003C_003E8__locals0.addProduct.DetailId > 0)
						{
							DbSet<WSPreOrderItems> wSPreOrderItems = _dbTbl.WSPreOrderItems;
							ParameterExpression val = Expression.Parameter(typeof(WSPreOrderItems), "c");
							wSPreOrderItems2 = Queryable.FirstOrDefault<WSPreOrderItems>((IQueryable<WSPreOrderItems>)wSPreOrderItems, Expression.Lambda<Func<WSPreOrderItems, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass46_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							int num13;
							if (wSPreOrderItems2 != null)
							{
								_ = wSPreOrderItems2.pordIPrdId;
								num13 = wSPreOrderItems2.pordIPrdId;
							}
							else
							{
								num13 = 0;
							}
							num12 = num13;
						}
						else
						{
							wSPreOrderItems2 = new WSPreOrderItems();
						}
						if (result12 == 4)
						{
							if (CS_0024_003C_003E8__locals0.addProduct.DetailId > 0)
							{
								if (wSPreOrderItems2 != null && wSPreOrderItems2.pordILinkAccSettingDBId > 0 && wSPreOrderItems2.pordILinkAccSettingDBId != CS_0024_003C_003E8__locals0.addProduct.LinkAccSettingDBId)
								{
									return "0|" + Messages.HolooConflictLinkAccSettingDB;
								}
							}
							else if (wSspSelectPreOrderItems_Result != null && wSspSelectPreOrderItems_Result.pordILinkAccSettingDBId > 0 && wSspSelectPreOrderItems_Result.pordILinkAccSettingDBId != CS_0024_003C_003E8__locals0.addProduct.LinkAccSettingDBId)
							{
								return "0|" + Messages.HolooConflictLinkAccSettingDB;
							}
						}
						wSPreOrderItems2.pordIPrdId = CS_0024_003C_003E8__locals0.addProduct.ProductId;
						wSPreOrderItems2.PreOrderId = CS_0024_003C_003E8__locals0.addProduct.MasterId;
						wSPreOrderItems2.pordIQuantity = CS_0024_003C_003E8__locals0.addProduct.Quantity;
						wSPreOrderItems2.pordIQuantityDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						wSPreOrderItems2.pordIDescription = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						wSPreOrderItems2.pordIDescriptionI = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						WSPreOrderItems wSPreOrderItems3 = wSPreOrderItems2;
						decimal? discountPrecent = CS_0024_003C_003E8__locals0.addProduct.Price;
						wSPreOrderItems3.pordIPrice = (((discountPrecent.GetValueOrDefault() == default(decimal)) & discountPrecent.HasValue) ? null : CS_0024_003C_003E8__locals0.addProduct.Price);
						WSPreOrderItems wSPreOrderItems4 = wSPreOrderItems2;
						discountPrecent = CS_0024_003C_003E8__locals0.addProduct.DiscountPrecent;
						wSPreOrderItems4.pordIDiscountPercent = (((discountPrecent.GetValueOrDefault() == default(decimal)) & discountPrecent.HasValue) ? null : CS_0024_003C_003E8__locals0.addProduct.DiscountPrecent);
						WSPreOrderItems wSPreOrderItems5 = wSPreOrderItems2;
						discountPrecent = CS_0024_003C_003E8__locals0.addProduct.Discount;
						wSPreOrderItems5.pordIDiscount = (((discountPrecent.GetValueOrDefault() == default(decimal)) & discountPrecent.HasValue) ? null : CS_0024_003C_003E8__locals0.addProduct.Discount);
						WSPreOrderItems wSPreOrderItems6 = wSPreOrderItems2;
						discountPrecent = CS_0024_003C_003E8__locals0.addProduct.Round;
						wSPreOrderItems6.pordIRound = (((discountPrecent.GetValueOrDefault() == default(decimal)) & discountPrecent.HasValue) ? null : CS_0024_003C_003E8__locals0.addProduct.Round);
						WSPreOrderItems wSPreOrderItems7 = wSPreOrderItems2;
						discountPrecent = CS_0024_003C_003E8__locals0.addProduct.RoundPlus;
						wSPreOrderItems7.pordIRoundPlus = (((discountPrecent.GetValueOrDefault() == default(decimal)) & discountPrecent.HasValue) ? null : CS_0024_003C_003E8__locals0.addProduct.RoundPlus);
						wSPreOrderItems2.pordITotalPrice = CS_0024_003C_003E8__locals0.addProduct.TotalPrice;
						wSPreOrderItems2.pordIFCR = ((CS_0024_003C_003E8__locals0.addProduct.FCR == 0.0) ? null : CS_0024_003C_003E8__locals0.addProduct.FCR);
						wSPreOrderItems2.pordIFCRI = ((CS_0024_003C_003E8__locals0.addProduct.FCRI == 0.0) ? null : CS_0024_003C_003E8__locals0.addProduct.FCRI);
						wSPreOrderItems2.pordIQuantityTotal = ((CS_0024_003C_003E8__locals0.addProduct.QuantityTotal == 0.0) ? null : CS_0024_003C_003E8__locals0.addProduct.QuantityTotal);
						wSPreOrderItems2.pordICalculateTax = ((!CS_0024_003C_003E8__locals0.addProduct.CalculateTax) ? null : new bool?(CS_0024_003C_003E8__locals0.addProduct.CalculateTax));
						WSPreOrderItems wSPreOrderItems8 = wSPreOrderItems2;
						discountPrecent = CS_0024_003C_003E8__locals0.addProduct.TaxIndex;
						wSPreOrderItems8.pordITaxIndex = (((discountPrecent.GetValueOrDefault() == default(decimal)) & discountPrecent.HasValue) ? null : CS_0024_003C_003E8__locals0.addProduct.TaxIndex);
						WSPreOrderItems wSPreOrderItems9 = wSPreOrderItems2;
						discountPrecent = CS_0024_003C_003E8__locals0.addProduct.Tax;
						wSPreOrderItems9.pordITax = (((discountPrecent.GetValueOrDefault() == default(decimal)) & discountPrecent.HasValue) ? null : CS_0024_003C_003E8__locals0.addProduct.Tax);
						wSPreOrderItems2.pordINotVisible = ((!CS_0024_003C_003E8__locals0.addProduct.SelectedNotVisible) ? null : new bool?(CS_0024_003C_003E8__locals0.addProduct.SelectedNotVisible));
						wSPreOrderItems2.pordINotInSum = ((!CS_0024_003C_003E8__locals0.addProduct.SelectedNotInSum) ? null : new bool?(CS_0024_003C_003E8__locals0.addProduct.SelectedNotInSum));
						wSPreOrderItems2.pordIPrdUnitId = ((CS_0024_003C_003E8__locals0.addProduct.PrdUnitId == 0) ? null : CS_0024_003C_003E8__locals0.addProduct.PrdUnitId);
						wSPreOrderItems2.pordICurrencyUnitId = ((CS_0024_003C_003E8__locals0.addProduct.CurrencyUnitId == 0) ? null : CS_0024_003C_003E8__locals0.addProduct.CurrencyUnitId);
						wSPreOrderItems2.pordIWHId = CS_0024_003C_003E8__locals0.addProduct.WHId;
						wSPreOrderItems2.pordILinkAccWHIdStr = CS_0024_003C_003E8__locals0.addProduct.WHIdLinkAcc;
						wSPreOrderItems2.UserId = userId;
						wSPreOrderItems2.AppType = appType;
						wSPreOrderItems2.pordIPrdPriceGroupID = CS_0024_003C_003E8__locals0.addProduct.PrdPriceGroupId;
						CS_0024_003C_003E8__locals0.addProduct.Tracing = ConvertCharacter.DecodeTracing(CS_0024_003C_003E8__locals0.addProduct.Tracing);
						wSPreOrderItems2.pordITracing = ((!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.addProduct.Tracing)) ? CS_0024_003C_003E8__locals0.addProduct.Tracing : null);
						wSPreOrderItems2.pordIPrdWeight = CS_0024_003C_003E8__locals0.addProduct.ItemPrdWeight;
						WSPreOrderItems wSPreOrderItems10 = wSPreOrderItems2;
						discountPrecent = CS_0024_003C_003E8__locals0.addProduct.TaxSum;
						wSPreOrderItems10.pordITaxSum = (((discountPrecent.GetValueOrDefault() == default(decimal)) & discountPrecent.HasValue) ? null : CS_0024_003C_003E8__locals0.addProduct.TaxSum);
						WSPreOrderItems wSPreOrderItems11 = wSPreOrderItems2;
						discountPrecent = CS_0024_003C_003E8__locals0.addProduct.DiscountSum;
						wSPreOrderItems11.pordIDiscountSum = (((discountPrecent.GetValueOrDefault() == default(decimal)) & discountPrecent.HasValue) ? null : CS_0024_003C_003E8__locals0.addProduct.DiscountSum);
						WSPreOrderItems wSPreOrderItems12 = wSPreOrderItems2;
						discountPrecent = CS_0024_003C_003E8__locals0.addProduct.DiscountISum;
						wSPreOrderItems12.pordIDiscountISum = (((discountPrecent.GetValueOrDefault() == default(decimal)) & discountPrecent.HasValue) ? null : CS_0024_003C_003E8__locals0.addProduct.DiscountISum);
						WSPreOrderItems wSPreOrderItems13 = wSPreOrderItems2;
						discountPrecent = CS_0024_003C_003E8__locals0.addProduct.PriceSum;
						wSPreOrderItems13.pordIPriceSum = (((discountPrecent.GetValueOrDefault() == default(decimal)) & discountPrecent.HasValue) ? null : CS_0024_003C_003E8__locals0.addProduct.PriceSum);
						wSPreOrderItems2.pordIDeliveryDate = CS_0024_003C_003E8__locals0.addProduct.DeliveryDate;
						wSPreOrderItems2.pordIDeliveryDatePersian = CS_0024_003C_003E8__locals0.addProduct.DeliveryDatePersian;
						wSPreOrderItems2.pordIDeliveryTime = CS_0024_003C_003E8__locals0.addProduct.DeliveryTime;
						wSPreOrderItems2.pordIDeliveryDay = CS_0024_003C_003E8__locals0.addProduct.DeliveryDay;
						wSPreOrderItems2.pordIDeliveryEndDate = CS_0024_003C_003E8__locals0.addProduct.DeliveryEndDate;
						wSPreOrderItems2.pordIDeliveryEndDatePersian = CS_0024_003C_003E8__locals0.addProduct.DeliveryEndDatePersian;
						wSPreOrderItems2.pordIDeliveryEndTime = CS_0024_003C_003E8__locals0.addProduct.DeliveryEndTime;
						wSPreOrderItems2.pordIDeliveryEndDay = CS_0024_003C_003E8__locals0.addProduct.DeliveryEndDay;
						wSPreOrderItems2.pordIDeliveryTermId = CS_0024_003C_003E8__locals0.addProduct.DeliveryTermId;
						wSPreOrderItems2.pordIPrdColorId = CS_0024_003C_003E8__locals0.addProduct.PrdColorId;
						wSPreOrderItems2.pordIPrdUnitIdI = CS_0024_003C_003E8__locals0.addProduct.PrdUnitIdI;
						wSPreOrderItems2.pordIPrdUnitIRateResult = CS_0024_003C_003E8__locals0.addProduct.PrdUnitIRateResult;
						wSPreOrderItems2.pordIPrdUnitIdII = CS_0024_003C_003E8__locals0.addProduct.PrdUnitIdII;
						wSPreOrderItems2.pordIPrdUnitIIRateResult = CS_0024_003C_003E8__locals0.addProduct.PrdUnitIIRateResult;
						wSPreOrderItems2.pordIPrdNickname = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						wSPreOrderItems2.pordIValidityExpireDate = CS_0024_003C_003E8__locals0.addProduct.ValidityExpireDate;
						wSPreOrderItems2.pordIValidityExpireDatePersian = CS_0024_003C_003E8__locals0.addProduct.ValidityExpireDatePersian;
						wSPreOrderItems2.pordIPrdAutoCalcRate = CS_0024_003C_003E8__locals0.addProduct.PrdAutoCalcRate;
						if (wSPreOrderItems2.pordIDiscountCodeId != CS_0024_003C_003E8__locals0.addProduct.DiscountCodeId)
						{
							wSPreOrderItems2.pordIDiscountCodeId = CS_0024_003C_003E8__locals0.addProduct.DiscountCodeId;
							wSPreOrderItems2.pordIDiscountCodeUserId = userId;
							wSPreOrderItems2.pordIDiscountCodeRegisterDate = DateTime.Now;
							wSPreOrderItems2.pordIDiscountCodeRegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
						}
						wSPreOrderItems2.pordISaleCenterId = CS_0024_003C_003E8__locals0.addProduct.SaleCenterId;
						wSPreOrderItems2.pordIPriceCurrencyRate = CS_0024_003C_003E8__locals0.addProduct.PrdPriceCurrencyRate;
						if (result12 == 4)
						{
							wSPreOrderItems2.pordILinkAccSettingDBId = CS_0024_003C_003E8__locals0.addProduct.LinkAccSettingDBId;
						}
						wSPreOrderItems2.pordIDescription = wSPreOrderItems2.pordIDescription ?? "";
						wSPreOrderItems2.pordIQuantityDesc = wSPreOrderItems2.pordIQuantityDesc ?? "";
						wSPreOrderItems2.pordIDescriptionI = wSPreOrderItems2.pordIDescriptionI ?? "";
						if (UserLogin.IsUserAccess("frmPreOrder", "actMustPrdGroupSame", UserLogin.CurrentUser))
						{
							List<WSspControlPreOrderItemsPrdGroupSame_Result> list13 = Enumerable.ToList<WSspControlPreOrderItemsPrdGroupSame_Result>((IEnumerable<WSspControlPreOrderItemsPrdGroupSame_Result>)_dbI.WSspControlPreOrderItemsPrdGroupSame(wSPreOrderItems2.PreOrderId, wSPreOrderItems2.pordIPrdId, wSPreOrderItems2.PreOrderItemID, lCID, CS_0024_003C_003E8__locals0.defLangID));
							if (list13 != null && Enumerable.Any<WSspControlPreOrderItemsPrdGroupSame_Result>((IEnumerable<WSspControlPreOrderItemsPrdGroupSame_Result>)list13))
							{
								return "0|" + Messages.msgErrorCanNotSelectWithNotPrdGroupSameInPord;
							}
						}
						if (CS_0024_003C_003E8__locals0.addProduct.DetailId > 0)
						{
							WSspCheckPreOrderItemHaveStockSupply_Result wSspCheckPreOrderItemHaveStockSupply_Result = Enumerable.FirstOrDefault<WSspCheckPreOrderItemHaveStockSupply_Result>((IEnumerable<WSspCheckPreOrderItemHaveStockSupply_Result>)_dbII.WSspCheckPreOrderItemHaveStockSupply(CS_0024_003C_003E8__locals0.addProduct.DetailId, lCID, CS_0024_003C_003E8__locals0.defLangID));
							if (wSspCheckPreOrderItemHaveStockSupply_Result != null && !string.IsNullOrWhiteSpace(wSspCheckPreOrderItemHaveStockSupply_Result.StockSupplyItemIds))
							{
								string text6 = string.Format(Messages.msgErrorNoEditPordItemHaveStsup, wSspCheckPreOrderItemHaveStockSupply_Result.PrdName ?? "");
								return "0|" + text6;
							}
							wSPreOrderItems2.pordIOrderView = CS_0024_003C_003E8__locals0.addProduct.OrderView;
							wSPreOrderItems2.Month1 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
							wSPreOrderItems2.RegisterDate = DateTime.Now;
							wSPreOrderItems2.RegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
							_dbTbl.Entry(wSPreOrderItems2).State = EntityState.Modified;
							_dbTbl.SaveChanges();
							using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
							{
								while (enumerator.MoveNext())
								{
									_003C_003Ec__DisplayClass46_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass46_1();
									CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
									CS_0024_003C_003E8__locals1.lang = enumerator.Current;
									DbSet<WSPreOrderItems_Lang> wSPreOrderItems_Lang = _dbTbl.WSPreOrderItems_Lang;
									ParameterExpression val = Expression.Parameter(typeof(WSPreOrderItems_Lang), "c");
									WSPreOrderItems_Lang wSPreOrderItems_Lang2 = Queryable.FirstOrDefault<WSPreOrderItems_Lang>((IQueryable<WSPreOrderItems_Lang>)wSPreOrderItems_Lang, Expression.Lambda<Func<WSPreOrderItems_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass46_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass46_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
									if (wSPreOrderItems_Lang2 != null)
									{
										wSPreOrderItems_Lang2.pordIQuantityDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
										wSPreOrderItems_Lang2.pordIDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
										wSPreOrderItems_Lang2.pordIPrdNickname = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
										wSPreOrderItems_Lang2.pordIDescriptionI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
										_dbTbl.Entry(wSPreOrderItems_Lang2).State = EntityState.Modified;
										_dbTbl.SaveChanges();
										continue;
									}
									wSPreOrderItems_Lang2 = new WSPreOrderItems_Lang();
									wSPreOrderItems_Lang2.LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID;
									wSPreOrderItems_Lang2.PreOrderItemID = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.addProduct.DetailId;
									wSPreOrderItems_Lang2.pordIQuantityDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									wSPreOrderItems_Lang2.pordIDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									wSPreOrderItems_Lang2.pordIPrdNickname = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									wSPreOrderItems_Lang2.pordIDescriptionI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									_dbTbl.WSPreOrderItems_Lang.Add(wSPreOrderItems_Lang2);
									_dbTbl.SaveChanges();
								}
							}
							if (num12 != 0 && wSPreOrderItems2.pordIPrdId != num12)
							{
								_db.WSspDeletePreOrderItemSpecification(wSPreOrderItems2.PreOrderItemID);
								_db.WSspInsertPreOrderItemSpecification(wSPreOrderItems2.pordIPrdId, wSPreOrderItems2.PreOrderItemID, userId, short.Parse(DateTime.Now.ToString("MM", new PersianCulture())), id, DateTime.Now.ToString("yyyyMMdd", new PersianCulture()), appType, CS_0024_003C_003E8__locals0.defLangID);
							}
							result = ((!PreOrder.CalcAndSetPreOrderAmounts(wSPreOrderItems2.PreOrderId)) ? ("0|" + Messages.msgErrorInCalculation) : ("1|" + Messages.frmFormBaseEditSuccessFulMessage));
							break;
						}
						List<WSspSelectPreOrderItems_Result> list14 = Enumerable.ToList<WSspSelectPreOrderItems_Result>((IEnumerable<WSspSelectPreOrderItems_Result>)_db.WSspSelectPreOrderItems(CS_0024_003C_003E8__locals0.addProduct.MasterId, lCID, CS_0024_003C_003E8__locals0.defLangID));
						int num14 = (Enumerable.Any<WSspSelectPreOrderItems_Result>((IEnumerable<WSspSelectPreOrderItems_Result>)list14) ? Enumerable.Count<WSspSelectPreOrderItems_Result>((IEnumerable<WSspSelectPreOrderItems_Result>)list14) : 0);
						wSPreOrderItems2.FPId = id;
						wSPreOrderItems2.GUId = Guid.NewGuid();
						wSPreOrderItems2.Month1 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
						wSPreOrderItems2.RegisterDate = DateTime.Now;
						wSPreOrderItems2.FirstRegisterUserId = userId;
						wSPreOrderItems2.FirstRegisterDate = DateTime.Now;
						wSPreOrderItems2.FirstRegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
						wSPreOrderItems2.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
						wSPreOrderItems2.RegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
						wSPreOrderItems2.pordIOrderView = num14 + 1 + num14 * 4 - 1;
						if (CS_0024_003C_003E8__locals0.addProduct.OrderView.HasValue)
						{
							wSPreOrderItems2.pordIOrderView = CS_0024_003C_003E8__locals0.addProduct.OrderView;
						}
						wSPreOrderItems2.pordICId = PreOrder.GetPordCId(CS_0024_003C_003E8__locals0.addProduct.MasterId);
						_dbTbl.WSPreOrderItems.Add(wSPreOrderItems2);
						_dbTbl.SaveChanges();
						foreach (Languages lang3 in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
						{
							WSPreOrderItems_Lang wSPreOrderItems_Lang3 = new WSPreOrderItems_Lang();
							wSPreOrderItems_Lang3.LanguageID = lang3.LanguageID;
							wSPreOrderItems_Lang3.PreOrderItemID = wSPreOrderItems2.PreOrderItemID;
							wSPreOrderItems_Lang3.pordIQuantityDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang3.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang3.LanguageID)).Value : null);
							wSPreOrderItems_Lang3.pordIDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang3.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang3.LanguageID)).Value : null);
							wSPreOrderItems_Lang3.pordIPrdNickname = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang3.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang3.LanguageID)).Value : null);
							wSPreOrderItems_Lang3.pordIDescriptionI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang3.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang3.LanguageID)).Value : null);
							_dbTbl.WSPreOrderItems_Lang.Add(wSPreOrderItems_Lang3);
							_dbTbl.SaveChanges();
						}
						if (wSPreOrderItems2.PreOrderItemID > 0)
						{
							if (wSPreOrderItems2.pordIPrdId != num11)
							{
								_db.WSspInsertPreOrderItemSpecification(wSPreOrderItems2.pordIPrdId, wSPreOrderItems2.PreOrderItemID, userId, short.Parse(DateTime.Now.ToString("MM", new PersianCulture())), id, DateTime.Now.ToString("yyyyMMdd", new PersianCulture()), appType, CS_0024_003C_003E8__locals0.defLangID);
							}
							if (CS_0024_003C_003E8__locals0.addProduct.AddLinkedPrd.HasValue && CS_0024_003C_003E8__locals0.addProduct.AddLinkedPrd.GetValueOrDefault() && !result7)
							{
								DateTime now = DateTime.Now;
								string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
								short value4 = short.Parse(now.ToString("MM", new PersianCulture()));
								mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.WSspInsertPreOrderItemFromLinkedPrd(CS_0024_003C_003E8__locals0.addProduct.ProductId, CS_0024_003C_003E8__locals0.addProduct.MasterId, CS_0024_003C_003E8__locals0.addProduct.PrdPriceGroupId, CS_0024_003C_003E8__locals0.addProduct.WHId, userId, id, value4, now, registerDatePersian, appType, CS_0024_003C_003E8__locals0.defLangID, "", wSPreOrderItems2.PreOrderItemID, centerId));
								if (mct_Result != null && mct_Result.Result == 0)
								{
									return "0|" + Messages.msgErrorInAddLinkedPrd;
								}
							}
							result = ((!PreOrder.CalcAndSetPreOrderAmounts(wSPreOrderItems2.PreOrderId)) ? ("0|" + Messages.msgErrorInCalculation) : ("1|" + Messages.frmFormBaseInsertSuccessFulMessage));
						}
						else
						{
							result = "0|" + Messages.frmErrorMessage;
						}
						break;
					}
					case "UserPavProduct":
					{
						WSUserFavproductItems wSUserFavproductItems = new WSUserFavproductItems();
						wSUserFavproductItems.UserFavproductId = CS_0024_003C_003E8__locals0.addProduct.MasterId;
						wSUserFavproductItems.FavprdIPrdId = CS_0024_003C_003E8__locals0.addProduct.ProductId;
						wSUserFavproductItems.FavprdIQuantity = CS_0024_003C_003E8__locals0.addProduct.Quantity;
						wSUserFavproductItems.UserId = userId;
						wSUserFavproductItems.Month1 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
						wSUserFavproductItems.RegisterDate = DateTime.Now;
						wSUserFavproductItems.RegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
						wSUserFavproductItems.FavprdIOrderView = CS_0024_003C_003E8__locals0.addProduct.OrderView.GetValueOrDefault();
						wSUserFavproductItems.Selector = true;
						wSUserFavproductItems.GUId = Guid.NewGuid();
						wSUserFavproductItems.FavprdIWHId = CS_0024_003C_003E8__locals0.addProduct.WHId;
						wSUserFavproductItems.AppType = appType;
						wSUserFavproductItems.FirstRegisterUserId = userId;
						wSUserFavproductItems.FirstRegisterDate = DateTime.Now;
						wSUserFavproductItems.FirstRegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
						wSUserFavproductItems.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
						decimal? discountPrecent = CS_0024_003C_003E8__locals0.addProduct.DiscountPrecent;
						wSUserFavproductItems.FavprdIDiscountPercent = (((discountPrecent.GetValueOrDefault() == default(decimal)) & discountPrecent.HasValue) ? null : CS_0024_003C_003E8__locals0.addProduct.DiscountPrecent);
						wSUserFavproductItems.FavprdINotVisible = ((!CS_0024_003C_003E8__locals0.addProduct.SelectedNotVisible) ? null : new bool?(CS_0024_003C_003E8__locals0.addProduct.SelectedNotVisible));
						wSUserFavproductItems.FavprdINotInSum = ((!CS_0024_003C_003E8__locals0.addProduct.SelectedNotInSum) ? null : new bool?(CS_0024_003C_003E8__locals0.addProduct.SelectedNotInSum));
						wSUserFavproductItems.FavprdIPriceGroupId = CS_0024_003C_003E8__locals0.addProduct.PrdPriceGroupId;
						wSUserFavproductItems.FavprdIQuantityDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						wSUserFavproductItems.FavprdIQuantityDesc = CS_0024_003C_003E8__locals0.addProduct.QuantityDesc ?? "";
						_dbTbl.WSUserFavproductItems.Add(wSUserFavproductItems);
						_dbTbl.SaveChanges();
						foreach (Languages lang4 in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
						{
							WSUserFavproductItems_Lang wSUserFavproductItems_Lang = new WSUserFavproductItems_Lang();
							wSUserFavproductItems_Lang.LanguageID = lang4.LanguageID;
							wSUserFavproductItems_Lang.UserFavproductItemId = wSUserFavproductItems.UserFavproductItemId;
							wSUserFavproductItems_Lang.FavprdIQuantityDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang4.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang4.LanguageID)).Value : null);
							_dbTbl.WSUserFavproductItems_Lang.Add(wSUserFavproductItems_Lang);
							_dbTbl.SaveChanges();
						}
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSUserFavproductItems", UserLogin.CurrentUser.UserId);
						result = ((wSUserFavproductItems.UserFavproductItemId > 0) ? ("1|" + Messages.frmFormBaseInsertSuccessFulMessage) : ("0|" + Messages.frmErrorMessage));
						break;
					}
					case "SaleOrder":
					{
						if (Order.IsFixed(CS_0024_003C_003E8__locals0.addProduct.MasterId))
						{
							return "0|" + Messages.msgErrorNotActiveOrd;
						}
						WSspSelectOrderItems_Result wSspSelectOrderItems_Result = Enumerable.FirstOrDefault<WSspSelectOrderItems_Result>((IEnumerable<WSspSelectOrderItems_Result>)Enumerable.OrderByDescending<WSspSelectOrderItems_Result, int>((IEnumerable<WSspSelectOrderItems_Result>)_db.WSspSelectOrderItems(CS_0024_003C_003E8__locals0.addProduct.MasterId, lCID, CS_0024_003C_003E8__locals0.defLangID), (Func<WSspSelectOrderItems_Result, int>)((WSspSelectOrderItems_Result m) => m.OrderItemID)));
						_ = wSspSelectOrderItems_Result?.ordIPrdId;
						_ = wSspSelectOrderItems_Result?.ordIOrderView;
						WSOrderItems wSOrderItems;
						if (CS_0024_003C_003E8__locals0.addProduct.DetailId > 0)
						{
							wSOrderItems = _dbTbl.WSOrderItems.Find(CS_0024_003C_003E8__locals0.addProduct.DetailId);
							_ = wSOrderItems?.ordIPrdId;
						}
						else
						{
							wSOrderItems = new WSOrderItems();
						}
						if (result12 == 4)
						{
							if (CS_0024_003C_003E8__locals0.addProduct.DetailId > 0)
							{
								if (wSOrderItems != null && wSOrderItems.ordILinkAccSettingDBId > 0 && wSOrderItems.ordILinkAccSettingDBId != CS_0024_003C_003E8__locals0.addProduct.LinkAccSettingDBId)
								{
									return "0|" + Messages.HolooConflictLinkAccSettingDB;
								}
							}
							else if (wSspSelectOrderItems_Result != null && wSspSelectOrderItems_Result.ordILinkAccSettingDBId > 0 && wSspSelectOrderItems_Result.ordILinkAccSettingDBId != CS_0024_003C_003E8__locals0.addProduct.LinkAccSettingDBId)
							{
								return "0|" + Messages.HolooConflictLinkAccSettingDB;
							}
						}
						wSOrderItems.ordIPrdId = CS_0024_003C_003E8__locals0.addProduct.ProductId;
						wSOrderItems.OrderId = CS_0024_003C_003E8__locals0.addProduct.MasterId;
						wSOrderItems.ordIQuantity = CS_0024_003C_003E8__locals0.addProduct.Quantity;
						WSOrderItems wSOrderItems2 = wSOrderItems;
						decimal? discountPrecent = CS_0024_003C_003E8__locals0.addProduct.Price;
						wSOrderItems2.ordIPrice = (((discountPrecent.GetValueOrDefault() == default(decimal)) & discountPrecent.HasValue) ? null : CS_0024_003C_003E8__locals0.addProduct.Price);
						WSOrderItems wSOrderItems3 = wSOrderItems;
						discountPrecent = CS_0024_003C_003E8__locals0.addProduct.DiscountPrecent;
						wSOrderItems3.ordIDiscountPercent = (((discountPrecent.GetValueOrDefault() == default(decimal)) & discountPrecent.HasValue) ? null : CS_0024_003C_003E8__locals0.addProduct.DiscountPrecent);
						WSOrderItems wSOrderItems4 = wSOrderItems;
						discountPrecent = CS_0024_003C_003E8__locals0.addProduct.Discount;
						wSOrderItems4.ordIDiscount = (((discountPrecent.GetValueOrDefault() == default(decimal)) & discountPrecent.HasValue) ? null : CS_0024_003C_003E8__locals0.addProduct.Discount);
						WSOrderItems wSOrderItems5 = wSOrderItems;
						discountPrecent = CS_0024_003C_003E8__locals0.addProduct.Round;
						wSOrderItems5.ordIRound = (((discountPrecent.GetValueOrDefault() == default(decimal)) & discountPrecent.HasValue) ? null : CS_0024_003C_003E8__locals0.addProduct.Round);
						WSOrderItems wSOrderItems6 = wSOrderItems;
						discountPrecent = CS_0024_003C_003E8__locals0.addProduct.RoundPlus;
						wSOrderItems6.ordIRoundPlus = (((discountPrecent.GetValueOrDefault() == default(decimal)) & discountPrecent.HasValue) ? null : CS_0024_003C_003E8__locals0.addProduct.RoundPlus);
						wSOrderItems.ordITotalPrice = CS_0024_003C_003E8__locals0.addProduct.TotalPrice;
						wSOrderItems.ordIQuantityDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						wSOrderItems.ordIDescription = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						wSOrderItems.ordIDescriptionI = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						wSOrderItems.ordIFCR = ((CS_0024_003C_003E8__locals0.addProduct.FCR == 0.0) ? null : CS_0024_003C_003E8__locals0.addProduct.FCR);
						wSOrderItems.ordIFCRI = ((CS_0024_003C_003E8__locals0.addProduct.FCRI == 0.0) ? null : CS_0024_003C_003E8__locals0.addProduct.FCRI);
						wSOrderItems.ordIQuantityTotal = ((CS_0024_003C_003E8__locals0.addProduct.QuantityTotal == 0.0) ? null : CS_0024_003C_003E8__locals0.addProduct.QuantityTotal);
						wSOrderItems.ordICalculateTax = ((!CS_0024_003C_003E8__locals0.addProduct.CalculateTax) ? null : new bool?(CS_0024_003C_003E8__locals0.addProduct.CalculateTax));
						WSOrderItems wSOrderItems7 = wSOrderItems;
						discountPrecent = CS_0024_003C_003E8__locals0.addProduct.TaxIndex;
						wSOrderItems7.ordITaxIndex = (((discountPrecent.GetValueOrDefault() == default(decimal)) & discountPrecent.HasValue) ? null : CS_0024_003C_003E8__locals0.addProduct.TaxIndex);
						WSOrderItems wSOrderItems8 = wSOrderItems;
						discountPrecent = CS_0024_003C_003E8__locals0.addProduct.Tax;
						wSOrderItems8.ordITax = (((discountPrecent.GetValueOrDefault() == default(decimal)) & discountPrecent.HasValue) ? null : CS_0024_003C_003E8__locals0.addProduct.Tax);
						wSOrderItems.ordINotVisible = ((!CS_0024_003C_003E8__locals0.addProduct.SelectedNotVisible) ? null : new bool?(CS_0024_003C_003E8__locals0.addProduct.SelectedNotVisible));
						wSOrderItems.ordINotInSum = ((!CS_0024_003C_003E8__locals0.addProduct.SelectedNotInSum) ? null : new bool?(CS_0024_003C_003E8__locals0.addProduct.SelectedNotInSum));
						wSOrderItems.ordIPrdUnitId = ((CS_0024_003C_003E8__locals0.addProduct.PrdUnitId == 0) ? null : CS_0024_003C_003E8__locals0.addProduct.PrdUnitId);
						wSOrderItems.ordICurrencyUnitId = ((CS_0024_003C_003E8__locals0.addProduct.CurrencyUnitId == 0) ? null : CS_0024_003C_003E8__locals0.addProduct.CurrencyUnitId);
						wSOrderItems.ordIWHId = CS_0024_003C_003E8__locals0.addProduct.WHId;
						wSOrderItems.ordILinkAccWHIdStr = CS_0024_003C_003E8__locals0.addProduct.WHIdLinkAcc;
						wSOrderItems.UserId = userId;
						wSOrderItems.AppType = appType;
						wSOrderItems.ordIPricePartRate = CS_0024_003C_003E8__locals0.addProduct.PricePartRate;
						wSOrderItems.ordIPricePartI = CS_0024_003C_003E8__locals0.addProduct.PricePartI;
						wSOrderItems.ordIPricePartII = CS_0024_003C_003E8__locals0.addProduct.PricePartII;
						wSOrderItems.ordIPrdPriceGroupID = CS_0024_003C_003E8__locals0.addProduct.PrdPriceGroupId;
						CS_0024_003C_003E8__locals0.addProduct.Tracing = ConvertCharacter.DecodeTracing(CS_0024_003C_003E8__locals0.addProduct.Tracing);
						wSOrderItems.ordITracing = ((!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.addProduct.Tracing)) ? CS_0024_003C_003E8__locals0.addProduct.Tracing : null);
						wSOrderItems.ordIPrdWeight = CS_0024_003C_003E8__locals0.addProduct.ItemPrdWeight;
						WSOrderItems wSOrderItems9 = wSOrderItems;
						discountPrecent = CS_0024_003C_003E8__locals0.addProduct.TaxSum;
						wSOrderItems9.ordITaxSum = (((discountPrecent.GetValueOrDefault() == default(decimal)) & discountPrecent.HasValue) ? null : CS_0024_003C_003E8__locals0.addProduct.TaxSum);
						WSOrderItems wSOrderItems10 = wSOrderItems;
						discountPrecent = CS_0024_003C_003E8__locals0.addProduct.DiscountSum;
						wSOrderItems10.ordIDiscountSum = (((discountPrecent.GetValueOrDefault() == default(decimal)) & discountPrecent.HasValue) ? null : CS_0024_003C_003E8__locals0.addProduct.DiscountSum);
						WSOrderItems wSOrderItems11 = wSOrderItems;
						discountPrecent = CS_0024_003C_003E8__locals0.addProduct.DiscountISum;
						wSOrderItems11.ordIDiscountISum = (((discountPrecent.GetValueOrDefault() == default(decimal)) & discountPrecent.HasValue) ? null : CS_0024_003C_003E8__locals0.addProduct.DiscountISum);
						WSOrderItems wSOrderItems12 = wSOrderItems;
						discountPrecent = CS_0024_003C_003E8__locals0.addProduct.PriceSum;
						wSOrderItems12.ordIPriceSum = (((discountPrecent.GetValueOrDefault() == default(decimal)) & discountPrecent.HasValue) ? null : CS_0024_003C_003E8__locals0.addProduct.PriceSum);
						wSOrderItems.ordIDeliveryDate = CS_0024_003C_003E8__locals0.addProduct.DeliveryDate;
						wSOrderItems.ordIDeliveryDatePersian = CS_0024_003C_003E8__locals0.addProduct.DeliveryDatePersian;
						wSOrderItems.ordIDeliveryTime = CS_0024_003C_003E8__locals0.addProduct.DeliveryTime;
						wSOrderItems.ordIDeliveryDay = CS_0024_003C_003E8__locals0.addProduct.DeliveryDay;
						wSOrderItems.ordIDeliveryEndDate = CS_0024_003C_003E8__locals0.addProduct.DeliveryEndDate;
						wSOrderItems.ordIDeliveryEndDatePersian = CS_0024_003C_003E8__locals0.addProduct.DeliveryEndDatePersian;
						wSOrderItems.ordIDeliveryEndTime = CS_0024_003C_003E8__locals0.addProduct.DeliveryEndTime;
						wSOrderItems.ordIDeliveryEndDay = CS_0024_003C_003E8__locals0.addProduct.DeliveryEndDay;
						wSOrderItems.ordIDeliveryTermId = CS_0024_003C_003E8__locals0.addProduct.DeliveryTermId;
						wSOrderItems.ordIDeliveryUserId = CS_0024_003C_003E8__locals0.addProduct.PrdDeliveryUserId;
						wSOrderItems.ordIValidityExpireDate = CS_0024_003C_003E8__locals0.addProduct.ValidityExpireDate;
						wSOrderItems.ordIValidityExpireDatePersian = CS_0024_003C_003E8__locals0.addProduct.ValidityExpireDatePersian;
						wSOrderItems.ordIPrdColorId = CS_0024_003C_003E8__locals0.addProduct.PrdColorId;
						wSOrderItems.ordIPrdUnitIdI = CS_0024_003C_003E8__locals0.addProduct.PrdUnitIdI;
						wSOrderItems.ordIPrdUnitIRateResult = CS_0024_003C_003E8__locals0.addProduct.PrdUnitIRateResult;
						wSOrderItems.ordIPrdUnitIdII = CS_0024_003C_003E8__locals0.addProduct.PrdUnitIdII;
						wSOrderItems.ordIPrdUnitIIRateResult = CS_0024_003C_003E8__locals0.addProduct.PrdUnitIIRateResult;
						wSOrderItems.ordIPrdValidityCountingNum = CS_0024_003C_003E8__locals0.addProduct.PrdValidityCountingNum;
						wSOrderItems.ordIPrdValidityCountingMin = CS_0024_003C_003E8__locals0.addProduct.PrdValidityCountingMin;
						wSOrderItems.ordIPrdNickname = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						WSOrderItems wSOrderItems13 = wSOrderItems;
						discountPrecent = CS_0024_003C_003E8__locals0.addProduct.TspCfee;
						wSOrderItems13.TspOrdICfee = (((discountPrecent.GetValueOrDefault() == default(decimal)) & discountPrecent.HasValue) ? null : CS_0024_003C_003E8__locals0.addProduct.TspCfee);
						wSOrderItems.TspOrdICut = CS_0024_003C_003E8__locals0.addProduct.TspCut;
						WSOrderItems wSOrderItems14 = wSOrderItems;
						discountPrecent = CS_0024_003C_003E8__locals0.addProduct.TspExr;
						wSOrderItems14.TspOrdIExr = (((discountPrecent.GetValueOrDefault() == default(decimal)) & discountPrecent.HasValue) ? null : CS_0024_003C_003E8__locals0.addProduct.TspExr);
						wSOrderItems.TspOrdIOdt = CS_0024_003C_003E8__locals0.addProduct.TspOdt;
						WSOrderItems wSOrderItems15 = wSOrderItems;
						discountPrecent = CS_0024_003C_003E8__locals0.addProduct.TspOdr;
						wSOrderItems15.TspOrdIOdr = (((discountPrecent.GetValueOrDefault() == default(decimal)) & discountPrecent.HasValue) ? null : CS_0024_003C_003E8__locals0.addProduct.TspOdr);
						WSOrderItems wSOrderItems16 = wSOrderItems;
						discountPrecent = CS_0024_003C_003E8__locals0.addProduct.TspOdam;
						wSOrderItems16.TspOrdIOdam = (((discountPrecent.GetValueOrDefault() == default(decimal)) & discountPrecent.HasValue) ? null : CS_0024_003C_003E8__locals0.addProduct.TspOdam);
						wSOrderItems.TspOrdIOlt = CS_0024_003C_003E8__locals0.addProduct.TspOlt;
						WSOrderItems wSOrderItems17 = wSOrderItems;
						discountPrecent = CS_0024_003C_003E8__locals0.addProduct.TspOlr;
						wSOrderItems17.TspOrdIOlr = (((discountPrecent.GetValueOrDefault() == default(decimal)) & discountPrecent.HasValue) ? null : CS_0024_003C_003E8__locals0.addProduct.TspOlr);
						WSOrderItems wSOrderItems18 = wSOrderItems;
						discountPrecent = CS_0024_003C_003E8__locals0.addProduct.TspOlam;
						wSOrderItems18.TspOrdIOlam = (((discountPrecent.GetValueOrDefault() == default(decimal)) & discountPrecent.HasValue) ? null : CS_0024_003C_003E8__locals0.addProduct.TspOlam);
						WSOrderItems wSOrderItems19 = wSOrderItems;
						discountPrecent = CS_0024_003C_003E8__locals0.addProduct.TspConsfee;
						wSOrderItems19.TspOrdIConsfee = (((discountPrecent.GetValueOrDefault() == default(decimal)) & discountPrecent.HasValue) ? null : CS_0024_003C_003E8__locals0.addProduct.TspConsfee);
						WSOrderItems wSOrderItems20 = wSOrderItems;
						discountPrecent = CS_0024_003C_003E8__locals0.addProduct.TspSpro;
						wSOrderItems20.TspOrdISpro = (((discountPrecent.GetValueOrDefault() == default(decimal)) & discountPrecent.HasValue) ? null : CS_0024_003C_003E8__locals0.addProduct.TspSpro);
						WSOrderItems wSOrderItems21 = wSOrderItems;
						discountPrecent = CS_0024_003C_003E8__locals0.addProduct.TspBros;
						wSOrderItems21.TspOrdIBros = (((discountPrecent.GetValueOrDefault() == default(decimal)) & discountPrecent.HasValue) ? null : CS_0024_003C_003E8__locals0.addProduct.TspBros);
						WSOrderItems wSOrderItems22 = wSOrderItems;
						discountPrecent = CS_0024_003C_003E8__locals0.addProduct.TspCop;
						wSOrderItems22.TspOrdICop = (((discountPrecent.GetValueOrDefault() == default(decimal)) & discountPrecent.HasValue) ? null : CS_0024_003C_003E8__locals0.addProduct.TspCop);
						WSOrderItems wSOrderItems23 = wSOrderItems;
						discountPrecent = CS_0024_003C_003E8__locals0.addProduct.TspVop;
						wSOrderItems23.TspOrdIVop = (((discountPrecent.GetValueOrDefault() == default(decimal)) & discountPrecent.HasValue) ? null : CS_0024_003C_003E8__locals0.addProduct.TspVop);
						wSOrderItems.TspOrdINw = ((CS_0024_003C_003E8__locals0.addProduct.TspNw == 0.0) ? null : CS_0024_003C_003E8__locals0.addProduct.TspNw);
						WSOrderItems wSOrderItems24 = wSOrderItems;
						discountPrecent = CS_0024_003C_003E8__locals0.addProduct.TspSsrv;
						wSOrderItems24.TspOrdISsrv = (((discountPrecent.GetValueOrDefault() == default(decimal)) & discountPrecent.HasValue) ? null : CS_0024_003C_003E8__locals0.addProduct.TspSsrv);
						WSOrderItems wSOrderItems25 = wSOrderItems;
						discountPrecent = CS_0024_003C_003E8__locals0.addProduct.TspSscv;
						wSOrderItems25.TspOrdISscv = (((discountPrecent.GetValueOrDefault() == default(decimal)) & discountPrecent.HasValue) ? null : CS_0024_003C_003E8__locals0.addProduct.TspSscv);
						WSOrderItems wSOrderItems26 = wSOrderItems;
						discountPrecent = CS_0024_003C_003E8__locals0.addProduct.TspPspd;
						wSOrderItems26.TspOrdIPspd = (((discountPrecent.GetValueOrDefault() == default(decimal)) & discountPrecent.HasValue) ? null : CS_0024_003C_003E8__locals0.addProduct.TspPspd);
						WSOrderItems wSOrderItems27 = wSOrderItems;
						discountPrecent = CS_0024_003C_003E8__locals0.addProduct.TspCui;
						wSOrderItems27.TspOrdICui = (((discountPrecent.GetValueOrDefault() == default(decimal)) & discountPrecent.HasValue) ? null : CS_0024_003C_003E8__locals0.addProduct.TspCui);
						wSOrderItems.TspOrdIBsrn = CS_0024_003C_003E8__locals0.addProduct.TspBsrn;
						wSOrderItems.ordIPrdAutoCalcRate = CS_0024_003C_003E8__locals0.addProduct.PrdAutoCalcRate;
						wSOrderItems.ordIDeActiveModuleInReg = CS_0024_003C_003E8__locals0.addProduct.PrdDeActiveModuleInReg;
						wSOrderItems.ordISaleCenterId = CS_0024_003C_003E8__locals0.addProduct.SaleCenterId;
						wSOrderItems.ordIPriceCurrencyRate = CS_0024_003C_003E8__locals0.addProduct.PrdPriceCurrencyRate;
						if (result12 == 4)
						{
							wSOrderItems.ordILinkAccSettingDBId = CS_0024_003C_003E8__locals0.addProduct.LinkAccSettingDBId;
						}
						wSOrderItems.ordIDescription = wSOrderItems.ordIDescription ?? "";
						wSOrderItems.ordIQuantityDesc = wSOrderItems.ordIQuantityDesc ?? "";
						wSOrderItems.ordIDescriptionI = wSOrderItems.ordIDescriptionI ?? "";
						if (wSOrderItems.ordIDiscountCodeId != CS_0024_003C_003E8__locals0.addProduct.DiscountCodeId)
						{
							wSOrderItems.ordIDiscountCodeId = CS_0024_003C_003E8__locals0.addProduct.DiscountCodeId;
							wSOrderItems.ordIDiscountCodeUserId = userId;
							wSOrderItems.ordIDiscountCodeRegisterDate = DateTime.Now;
							wSOrderItems.ordIDiscountCodeRegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
						}
						if (CS_0024_003C_003E8__locals0.addProduct.DetailId > 0)
						{
							wSOrderItems.ordIOrderView = CS_0024_003C_003E8__locals0.addProduct.OrderView;
							wSOrderItems.Month1 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
							wSOrderItems.RegisterDate = DateTime.Now;
							wSOrderItems.RegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
							_dbTbl.Entry(wSOrderItems).State = EntityState.Modified;
							_dbTbl.SaveChanges();
							using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
							{
								while (enumerator.MoveNext())
								{
									_003C_003Ec__DisplayClass46_4 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass46_4();
									CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals2 = CS_0024_003C_003E8__locals0;
									CS_0024_003C_003E8__locals4.lang = enumerator.Current;
									DbSet<WSOrderItems_Lang> wSOrderItems_Lang = _dbTbl.WSOrderItems_Lang;
									ParameterExpression val = Expression.Parameter(typeof(WSOrderItems_Lang), "c");
									WSOrderItems_Lang wSOrderItems_Lang2 = Queryable.FirstOrDefault<WSOrderItems_Lang>((IQueryable<WSOrderItems_Lang>)wSOrderItems_Lang, Expression.Lambda<Func<WSOrderItems_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals4, typeof(_003C_003Ec__DisplayClass46_4)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals4, typeof(_003C_003Ec__DisplayClass46_4)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
									if (wSOrderItems_Lang2 != null)
									{
										wSOrderItems_Lang2.ordIQuantityDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals4.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals4.lang.LanguageID)).Value : null);
										wSOrderItems_Lang2.ordIDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals4.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals4.lang.LanguageID)).Value : null);
										wSOrderItems_Lang2.ordIPrdNickname = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals4.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals4.lang.LanguageID)).Value : null);
										wSOrderItems_Lang2.ordIDescriptionI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals4.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals4.lang.LanguageID)).Value : null);
										_dbTbl.Entry(wSOrderItems_Lang2).State = EntityState.Modified;
										_dbTbl.SaveChanges();
										continue;
									}
									wSOrderItems_Lang2 = new WSOrderItems_Lang();
									wSOrderItems_Lang2.LanguageID = CS_0024_003C_003E8__locals4.lang.LanguageID;
									wSOrderItems_Lang2.OrderItemID = CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals2.addProduct.DetailId;
									wSOrderItems_Lang2.ordIQuantityDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals4.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals4.lang.LanguageID)).Value : null);
									wSOrderItems_Lang2.ordIDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals4.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals4.lang.LanguageID)).Value : null);
									wSOrderItems_Lang2.ordIPrdNickname = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals4.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals4.lang.LanguageID)).Value : null);
									wSOrderItems_Lang2.ordIDescriptionI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals4.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals4.lang.LanguageID)).Value : null);
									_dbTbl.WSOrderItems_Lang.Add(wSOrderItems_Lang2);
									_dbTbl.SaveChanges();
								}
							}
							result = ((!Order.CalcAndSetOrderAmounts(wSOrderItems.OrderId)) ? ("0|" + Messages.msgErrorInCalculation) : ("1|" + Messages.frmFormBaseEditSuccessFulMessage));
							bool result26 = false;
							bool.TryParse(CS_0024_003C_003E8__locals0.addProduct.IsUpdateBordItem.ToString(), out result26);
							if (result26 && !string.IsNullOrWhiteSpace(wSOrderItems.BuyOrderItemIds) && wSOrderItems.OrderItemID != 0 && UserLogin.IsUserAccess(text2, "actCanUpdateBordItemQty", UserLogin.CurrentUser))
							{
								int userId2 = UserLogin.CurrentUser.UserId;
								DateTime now2 = DateTime.Now;
								string registerDatePersian2 = now2.ToString("yyyyMMdd", new PersianCulture());
								short value5 = short.Parse(now2.ToString("MM", new PersianCulture()));
								string appType2 = Configuration.AppType;
								ObjectParameter objectParameter2 = new ObjectParameter("Result", typeof(int));
								_dbII.WSspUpdateBuyOrderItemByOrdItemId(wSOrderItems.OrderItemID, userId2, value5, now2, registerDatePersian2, appType2, CS_0024_003C_003E8__locals0.defLangID, objectParameter2);
								if (objectParameter2 != null && objectParameter2.Value != null)
								{
									int result27 = 0;
									int.TryParse(objectParameter2.Value.ToString(), out result27);
									if (result27 <= 0)
									{
										result = "0|" + Messages.msgErrorInUpdateBordItem;
									}
								}
							}
						}
						else
						{
							List<WSspSelectOrderItems_Result> list15 = Enumerable.ToList<WSspSelectOrderItems_Result>((IEnumerable<WSspSelectOrderItems_Result>)_db.WSspSelectOrderItems(CS_0024_003C_003E8__locals0.addProduct.MasterId, lCID, CS_0024_003C_003E8__locals0.defLangID));
							int num15 = (Enumerable.Any<WSspSelectOrderItems_Result>((IEnumerable<WSspSelectOrderItems_Result>)list15) ? Enumerable.Count<WSspSelectOrderItems_Result>((IEnumerable<WSspSelectOrderItems_Result>)list15) : 0);
							wSOrderItems.FPId = id;
							wSOrderItems.GUId = Guid.NewGuid();
							wSOrderItems.Month1 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
							wSOrderItems.RegisterDate = DateTime.Now;
							wSOrderItems.RegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
							wSOrderItems.FirstRegisterUserId = userId;
							wSOrderItems.FirstRegisterDate = DateTime.Now;
							wSOrderItems.FirstRegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
							wSOrderItems.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
							wSOrderItems.ordIOrderView = num15 + 1 + num15 * 4 - 1;
							if (CS_0024_003C_003E8__locals0.addProduct.OrderView.HasValue)
							{
								wSOrderItems.ordIOrderView = CS_0024_003C_003E8__locals0.addProduct.OrderView;
							}
							wSOrderItems.ordICId = Order.GetOrdCId(CS_0024_003C_003E8__locals0.addProduct.MasterId);
							_dbTbl.WSOrderItems.Add(wSOrderItems);
							_dbTbl.SaveChanges();
							foreach (Languages lang2 in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
							{
								WSOrderItems_Lang wSOrderItems_Lang3 = new WSOrderItems_Lang();
								wSOrderItems_Lang3.LanguageID = lang2.LanguageID;
								wSOrderItems_Lang3.OrderItemID = wSOrderItems.OrderItemID;
								wSOrderItems_Lang3.ordIQuantityDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang2.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang2.LanguageID)).Value : null);
								wSOrderItems_Lang3.ordIDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang2.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang2.LanguageID)).Value : null);
								wSOrderItems_Lang3.ordIPrdNickname = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang2.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang2.LanguageID)).Value : null);
								wSOrderItems_Lang3.ordIDescriptionI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang2.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang2.LanguageID)).Value : null);
								_dbTbl.WSOrderItems_Lang.Add(wSOrderItems_Lang3);
								_dbTbl.SaveChanges();
							}
							if (wSOrderItems.OrderItemID > 0)
							{
								if (CS_0024_003C_003E8__locals0.addProduct.AddLinkedPrd.HasValue && CS_0024_003C_003E8__locals0.addProduct.AddLinkedPrd.GetValueOrDefault() && !result7)
								{
									DateTime now3 = DateTime.Now;
									string registerDatePersian3 = now3.ToString("yyyyMMdd", new PersianCulture());
									short value6 = short.Parse(now3.ToString("MM", new PersianCulture()));
									mct_Result mct_Result2 = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.WSspInsertOrderItemFromLinkedPrd(CS_0024_003C_003E8__locals0.addProduct.ProductId, CS_0024_003C_003E8__locals0.addProduct.MasterId, CS_0024_003C_003E8__locals0.addProduct.PrdPriceGroupId, CS_0024_003C_003E8__locals0.addProduct.WHId, userId, id, value6, now3, registerDatePersian3, appType, CS_0024_003C_003E8__locals0.defLangID, "", wSOrderItems.OrderItemID, centerId));
									if (mct_Result2 != null && mct_Result2.Result == 0)
									{
										return "0|" + Messages.msgErrorInAddLinkedPrd;
									}
								}
								result = ((!Order.CalcAndSetOrderAmounts(wSOrderItems.OrderId)) ? ("0|" + Messages.msgErrorInCalculation) : ("1|" + Messages.frmFormBaseInsertSuccessFulMessage));
							}
							else
							{
								result = "0|" + Messages.frmErrorMessage;
							}
						}
						if (CS_0024_003C_003E8__locals0.addProduct.SaleCenterId.GetValueOrDefault() != 0)
						{
							DbSet<WSOrderItems> wSOrderItems28 = _dbTbl.WSOrderItems;
							ParameterExpression val = Expression.Parameter(typeof(WSOrderItems), "x");
							List<WSOrderItems> list16 = Enumerable.ToList<WSOrderItems>((IEnumerable<WSOrderItems>)Queryable.Where<WSOrderItems>((IQueryable<WSOrderItems>)wSOrderItems28, Expression.Lambda<Func<WSOrderItems, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass46_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.NotEqual((Expression)(object)Expression.Coalesce((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)0, typeof(int))), (Expression)(object)Expression.Constant((object)0, typeof(int)))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
							for (int i = 0; i < list16.Count; i++)
							{
								WSOrderItems wSOrderItems29 = list16[i];
								wSOrderItems29.ordISaleCenterId = CS_0024_003C_003E8__locals0.addProduct.SaleCenterId;
								wSOrderItems29.ordIDeliveryDate = CS_0024_003C_003E8__locals0.addProduct.DeliveryDate;
								wSOrderItems29.ordIDeliveryDatePersian = CS_0024_003C_003E8__locals0.addProduct.DeliveryDatePersian;
								wSOrderItems29.ordIDeliveryDay = CS_0024_003C_003E8__locals0.addProduct.DeliveryDay;
								wSOrderItems29.ordIDeliveryEndDate = CS_0024_003C_003E8__locals0.addProduct.DeliveryEndDate;
								wSOrderItems29.ordIDeliveryEndDatePersian = CS_0024_003C_003E8__locals0.addProduct.DeliveryEndDatePersian;
								wSOrderItems29.ordIDeliveryEndDay = CS_0024_003C_003E8__locals0.addProduct.DeliveryEndDay;
								wSOrderItems29.ordIDeliveryEndTime = CS_0024_003C_003E8__locals0.addProduct.DeliveryEndTime;
								wSOrderItems29.ordIDeliveryTime = CS_0024_003C_003E8__locals0.addProduct.DeliveryTime;
								_dbTbl.Entry(wSOrderItems29).State = EntityState.Modified;
							}
							_dbTbl.SaveChanges();
						}
						break;
					}
					case "BuyOrder":
					{
						if (BuyOrder.IsFixed(CS_0024_003C_003E8__locals0.addProduct.MasterId))
						{
							return "0|" + Messages.msgErrorNotActiveBOrd;
						}
						WSspSelectBuyOrderItems_Result wSspSelectBuyOrderItems_Result = Enumerable.FirstOrDefault<WSspSelectBuyOrderItems_Result>((IEnumerable<WSspSelectBuyOrderItems_Result>)Enumerable.OrderByDescending<WSspSelectBuyOrderItems_Result, int>((IEnumerable<WSspSelectBuyOrderItems_Result>)_db.WSspSelectBuyOrderItems(CS_0024_003C_003E8__locals0.addProduct.MasterId, lCID, CS_0024_003C_003E8__locals0.defLangID), (Func<WSspSelectBuyOrderItems_Result, int>)((WSspSelectBuyOrderItems_Result m) => m.BuyOrderItemId)));
						_ = wSspSelectBuyOrderItems_Result?.bordIPrdId;
						_ = wSspSelectBuyOrderItems_Result?.bordIOrderView;
						WSBuyOrderItems wSBuyOrderItems;
						if (CS_0024_003C_003E8__locals0.addProduct.DetailId > 0)
						{
							wSBuyOrderItems = _dbTbl.WSBuyOrderItems.Find(CS_0024_003C_003E8__locals0.addProduct.DetailId);
							_ = wSBuyOrderItems?.bordIPrdId;
						}
						else
						{
							wSBuyOrderItems = new WSBuyOrderItems();
						}
						if (result12 == 4)
						{
							if (CS_0024_003C_003E8__locals0.addProduct.DetailId > 0)
							{
								if (wSBuyOrderItems != null && wSBuyOrderItems.bordILinkAccSettingDBId > 0 && wSBuyOrderItems.bordILinkAccSettingDBId != CS_0024_003C_003E8__locals0.addProduct.LinkAccSettingDBId)
								{
									return "0|" + Messages.HolooConflictLinkAccSettingDB;
								}
							}
							else if (wSspSelectBuyOrderItems_Result != null && wSspSelectBuyOrderItems_Result.bordILinkAccSettingDBId > 0 && wSspSelectBuyOrderItems_Result.bordILinkAccSettingDBId != CS_0024_003C_003E8__locals0.addProduct.LinkAccSettingDBId)
							{
								return "0|" + Messages.HolooConflictLinkAccSettingDB;
							}
						}
						wSBuyOrderItems.bordIPrdId = CS_0024_003C_003E8__locals0.addProduct.ProductId;
						wSBuyOrderItems.BuyOrderId = CS_0024_003C_003E8__locals0.addProduct.MasterId;
						wSBuyOrderItems.bordIQuantity = CS_0024_003C_003E8__locals0.addProduct.Quantity;
						WSBuyOrderItems wSBuyOrderItems2 = wSBuyOrderItems;
						decimal? discountPrecent = CS_0024_003C_003E8__locals0.addProduct.Price;
						wSBuyOrderItems2.bordICost = (((discountPrecent.GetValueOrDefault() == default(decimal)) & discountPrecent.HasValue) ? null : CS_0024_003C_003E8__locals0.addProduct.Price);
						WSBuyOrderItems wSBuyOrderItems3 = wSBuyOrderItems;
						discountPrecent = CS_0024_003C_003E8__locals0.addProduct.DiscountPrecent;
						wSBuyOrderItems3.bordIDiscountPercent = (((discountPrecent.GetValueOrDefault() == default(decimal)) & discountPrecent.HasValue) ? null : CS_0024_003C_003E8__locals0.addProduct.DiscountPrecent);
						WSBuyOrderItems wSBuyOrderItems4 = wSBuyOrderItems;
						discountPrecent = CS_0024_003C_003E8__locals0.addProduct.Discount;
						wSBuyOrderItems4.bordIDiscount = (((discountPrecent.GetValueOrDefault() == default(decimal)) & discountPrecent.HasValue) ? null : CS_0024_003C_003E8__locals0.addProduct.Discount);
						wSBuyOrderItems.bordITotalCost = CS_0024_003C_003E8__locals0.addProduct.TotalPrice;
						wSBuyOrderItems.bordIFCR = ((CS_0024_003C_003E8__locals0.addProduct.FCR == 0.0) ? null : CS_0024_003C_003E8__locals0.addProduct.FCR);
						wSBuyOrderItems.bordIFCRI = ((CS_0024_003C_003E8__locals0.addProduct.FCRI == 0.0) ? null : CS_0024_003C_003E8__locals0.addProduct.FCRI);
						wSBuyOrderItems.bordIQuantityTotal = ((CS_0024_003C_003E8__locals0.addProduct.QuantityTotal == 0.0) ? null : CS_0024_003C_003E8__locals0.addProduct.QuantityTotal);
						wSBuyOrderItems.bordICalculateTax = ((!CS_0024_003C_003E8__locals0.addProduct.CalculateTax) ? null : new bool?(CS_0024_003C_003E8__locals0.addProduct.CalculateTax));
						WSBuyOrderItems wSBuyOrderItems5 = wSBuyOrderItems;
						discountPrecent = CS_0024_003C_003E8__locals0.addProduct.TaxIndex;
						wSBuyOrderItems5.bordITaxIndex = (((discountPrecent.GetValueOrDefault() == default(decimal)) & discountPrecent.HasValue) ? null : CS_0024_003C_003E8__locals0.addProduct.TaxIndex);
						WSBuyOrderItems wSBuyOrderItems6 = wSBuyOrderItems;
						discountPrecent = CS_0024_003C_003E8__locals0.addProduct.Tax;
						wSBuyOrderItems6.bordITax = (((discountPrecent.GetValueOrDefault() == default(decimal)) & discountPrecent.HasValue) ? null : CS_0024_003C_003E8__locals0.addProduct.Tax);
						wSBuyOrderItems.bordINotVisible = ((!CS_0024_003C_003E8__locals0.addProduct.SelectedNotVisible) ? null : new bool?(CS_0024_003C_003E8__locals0.addProduct.SelectedNotVisible));
						wSBuyOrderItems.bordINotInSum = ((!CS_0024_003C_003E8__locals0.addProduct.SelectedNotInSum) ? null : new bool?(CS_0024_003C_003E8__locals0.addProduct.SelectedNotInSum));
						wSBuyOrderItems.bordIPrdUnitId = ((CS_0024_003C_003E8__locals0.addProduct.PrdUnitId == 0) ? null : CS_0024_003C_003E8__locals0.addProduct.PrdUnitId);
						wSBuyOrderItems.bordICurrencyUnitId = ((CS_0024_003C_003E8__locals0.addProduct.CurrencyUnitId == 0) ? null : CS_0024_003C_003E8__locals0.addProduct.CurrencyUnitId);
						wSBuyOrderItems.bordIWHId = CS_0024_003C_003E8__locals0.addProduct.WHId;
						wSBuyOrderItems.bordILinkAccWHIdStr = CS_0024_003C_003E8__locals0.addProduct.WHIdLinkAcc;
						wSBuyOrderItems.UserId = userId;
						wSBuyOrderItems.AppType = appType;
						wSBuyOrderItems.bordIPrdCostGroupID = CS_0024_003C_003E8__locals0.addProduct.PrdPriceGroupId;
						if (CanUpdateBuyOrderItemTracing(wSBuyOrderItems.bordIWHId, wSBuyOrderItems.bordIPrdId, wSBuyOrderItems.bordITracing) == 1)
						{
							CS_0024_003C_003E8__locals0.addProduct.Tracing = ConvertCharacter.DecodeTracing(CS_0024_003C_003E8__locals0.addProduct.Tracing);
							wSBuyOrderItems.bordITracing = ((!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.addProduct.Tracing)) ? CS_0024_003C_003E8__locals0.addProduct.Tracing : null);
						}
						wSBuyOrderItems.bordIPrdWeight = CS_0024_003C_003E8__locals0.addProduct.ItemPrdWeight;
						wSBuyOrderItems.bordIQuantityDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						wSBuyOrderItems.bordIDescription = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						WSBuyOrderItems wSBuyOrderItems7 = wSBuyOrderItems;
						discountPrecent = CS_0024_003C_003E8__locals0.addProduct.TaxSum;
						wSBuyOrderItems7.bordITaxSum = (((discountPrecent.GetValueOrDefault() == default(decimal)) & discountPrecent.HasValue) ? null : CS_0024_003C_003E8__locals0.addProduct.TaxSum);
						WSBuyOrderItems wSBuyOrderItems8 = wSBuyOrderItems;
						discountPrecent = CS_0024_003C_003E8__locals0.addProduct.DiscountSum;
						wSBuyOrderItems8.bordIDiscountSum = (((discountPrecent.GetValueOrDefault() == default(decimal)) & discountPrecent.HasValue) ? null : CS_0024_003C_003E8__locals0.addProduct.DiscountSum);
						WSBuyOrderItems wSBuyOrderItems9 = wSBuyOrderItems;
						discountPrecent = CS_0024_003C_003E8__locals0.addProduct.DiscountISum;
						wSBuyOrderItems9.bordIDiscountISum = (((discountPrecent.GetValueOrDefault() == default(decimal)) & discountPrecent.HasValue) ? null : CS_0024_003C_003E8__locals0.addProduct.DiscountISum);
						WSBuyOrderItems wSBuyOrderItems10 = wSBuyOrderItems;
						discountPrecent = CS_0024_003C_003E8__locals0.addProduct.PriceSum;
						wSBuyOrderItems10.bordICostSum = (((discountPrecent.GetValueOrDefault() == default(decimal)) & discountPrecent.HasValue) ? null : CS_0024_003C_003E8__locals0.addProduct.PriceSum);
						wSBuyOrderItems.bordITaxCleared = CS_0024_003C_003E8__locals0.addProduct.TaxCleared;
						wSBuyOrderItems.bordITaxClearedDate = CS_0024_003C_003E8__locals0.addProduct.TaxClearedDate;
						wSBuyOrderItems.bordITaxClearedDatePersian = CS_0024_003C_003E8__locals0.addProduct.TaxClearedDatePersian;
						WSBuyOrderItems wSBuyOrderItems11 = wSBuyOrderItems;
						discountPrecent = CS_0024_003C_003E8__locals0.addProduct.FacilityCost;
						wSBuyOrderItems11.bordIFacilityCost = (((discountPrecent.GetValueOrDefault() == default(decimal)) & discountPrecent.HasValue) ? null : CS_0024_003C_003E8__locals0.addProduct.FacilityCost);
						WSBuyOrderItems wSBuyOrderItems12 = wSBuyOrderItems;
						discountPrecent = CS_0024_003C_003E8__locals0.addProduct.FacilityCostPercent;
						wSBuyOrderItems12.bordIFacilityCostPercent = (((discountPrecent.GetValueOrDefault() == default(decimal)) & discountPrecent.HasValue) ? null : CS_0024_003C_003E8__locals0.addProduct.FacilityCostPercent);
						wSBuyOrderItems.bordIForwarderName = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						WSBuyOrderItems wSBuyOrderItems13 = wSBuyOrderItems;
						discountPrecent = CS_0024_003C_003E8__locals0.addProduct.FreightCost;
						wSBuyOrderItems13.bordIFreightCost = (((discountPrecent.GetValueOrDefault() == default(decimal)) & discountPrecent.HasValue) ? null : CS_0024_003C_003E8__locals0.addProduct.FreightCost);
						wSBuyOrderItems.bordIFreightCurrUnId = CS_0024_003C_003E8__locals0.addProduct.FreightCurrUnId;
						wSBuyOrderItems.bordIFreightCurrencyRate = ((CS_0024_003C_003E8__locals0.addProduct.FreightCurrencyRate == 0.0) ? null : CS_0024_003C_003E8__locals0.addProduct.FreightCurrencyRate);
						WSBuyOrderItems wSBuyOrderItems14 = wSBuyOrderItems;
						discountPrecent = CS_0024_003C_003E8__locals0.addProduct.FinalFreightCost;
						wSBuyOrderItems14.bordIFinalFreightCost = (((discountPrecent.GetValueOrDefault() == default(decimal)) & discountPrecent.HasValue) ? null : CS_0024_003C_003E8__locals0.addProduct.FinalFreightCost);
						wSBuyOrderItems.bordICustomsPart = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						WSBuyOrderItems wSBuyOrderItems15 = wSBuyOrderItems;
						discountPrecent = CS_0024_003C_003E8__locals0.addProduct.CustomsFee;
						wSBuyOrderItems15.bordICustomsFee = (((discountPrecent.GetValueOrDefault() == default(decimal)) & discountPrecent.HasValue) ? null : CS_0024_003C_003E8__locals0.addProduct.CustomsFee);
						wSBuyOrderItems.bordICustomsCurrUnId = CS_0024_003C_003E8__locals0.addProduct.CustomsCurrUnId;
						wSBuyOrderItems.bordICustomsCurrencyRate = ((CS_0024_003C_003E8__locals0.addProduct.CustomsCurrencyRate == 0.0) ? null : CS_0024_003C_003E8__locals0.addProduct.CustomsCurrencyRate);
						WSBuyOrderItems wSBuyOrderItems16 = wSBuyOrderItems;
						discountPrecent = CS_0024_003C_003E8__locals0.addProduct.FinalCustomsFee;
						wSBuyOrderItems16.bordIFinalCustomsFee = (((discountPrecent.GetValueOrDefault() == default(decimal)) & discountPrecent.HasValue) ? null : CS_0024_003C_003E8__locals0.addProduct.FinalCustomsFee);
						wSBuyOrderItems.bordITotalFinalCost = value3;
						WSBuyOrderItems wSBuyOrderItems17 = wSBuyOrderItems;
						discountPrecent = CS_0024_003C_003E8__locals0.addProduct.Commission;
						wSBuyOrderItems17.bordICommission = (((discountPrecent.GetValueOrDefault() == default(decimal)) & discountPrecent.HasValue) ? null : CS_0024_003C_003E8__locals0.addProduct.Commission);
						wSBuyOrderItems.bordICommissionCurrUnId = CS_0024_003C_003E8__locals0.addProduct.CommissionCurrUnId;
						wSBuyOrderItems.bordICommissionCurrencyRate = ((CS_0024_003C_003E8__locals0.addProduct.CommissionCurrencyRate == 0.0) ? null : CS_0024_003C_003E8__locals0.addProduct.CommissionCurrencyRate);
						WSBuyOrderItems wSBuyOrderItems18 = wSBuyOrderItems;
						discountPrecent = CS_0024_003C_003E8__locals0.addProduct.FinalCommission;
						wSBuyOrderItems18.bordIFinalCommission = (((discountPrecent.GetValueOrDefault() == default(decimal)) & discountPrecent.HasValue) ? null : CS_0024_003C_003E8__locals0.addProduct.FinalCommission);
						wSBuyOrderItems.bordIPrdColorId = CS_0024_003C_003E8__locals0.addProduct.PrdColorId;
						wSBuyOrderItems.bordIPrdUnitIdI = CS_0024_003C_003E8__locals0.addProduct.PrdUnitIdI;
						wSBuyOrderItems.bordIPrdUnitIRateResult = CS_0024_003C_003E8__locals0.addProduct.PrdUnitIRateResult;
						wSBuyOrderItems.bordIPrdUnitIdII = CS_0024_003C_003E8__locals0.addProduct.PrdUnitIdII;
						wSBuyOrderItems.bordIPrdUnitIIRateResult = CS_0024_003C_003E8__locals0.addProduct.PrdUnitIIRateResult;
						wSBuyOrderItems.bordIPrdNickname = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						wSBuyOrderItems.bordICostCurrencyRate = CS_0024_003C_003E8__locals0.addProduct.PrdPriceCurrencyRate;
						if (result12 == 4)
						{
							wSBuyOrderItems.bordILinkAccSettingDBId = CS_0024_003C_003E8__locals0.addProduct.LinkAccSettingDBId;
						}
						wSBuyOrderItems.bordIDescription = wSBuyOrderItems.bordIDescription ?? "";
						wSBuyOrderItems.bordIQuantityDesc = wSBuyOrderItems.bordIQuantityDesc ?? "";
						if (CS_0024_003C_003E8__locals0.addProduct.DetailId > 0)
						{
							wSBuyOrderItems.bordIOrderView = CS_0024_003C_003E8__locals0.addProduct.OrderView;
							wSBuyOrderItems.Month1 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
							wSBuyOrderItems.RegisterDate = DateTime.Now;
							wSBuyOrderItems.RegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
							_dbTbl.Entry(wSBuyOrderItems).State = EntityState.Modified;
							_dbTbl.SaveChanges();
							using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
							{
								while (enumerator.MoveNext())
								{
									_003C_003Ec__DisplayClass46_6 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass46_6();
									CS_0024_003C_003E8__locals6.CS_0024_003C_003E8__locals3 = CS_0024_003C_003E8__locals0;
									CS_0024_003C_003E8__locals6.lang = enumerator.Current;
									DbSet<WSBuyOrderItems_Lang> wSBuyOrderItems_Lang = _dbTbl.WSBuyOrderItems_Lang;
									ParameterExpression val = Expression.Parameter(typeof(WSBuyOrderItems_Lang), "c");
									WSBuyOrderItems_Lang wSBuyOrderItems_Lang2 = Queryable.FirstOrDefault<WSBuyOrderItems_Lang>((IQueryable<WSBuyOrderItems_Lang>)wSBuyOrderItems_Lang, Expression.Lambda<Func<WSBuyOrderItems_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals6, typeof(_003C_003Ec__DisplayClass46_6)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals6, typeof(_003C_003Ec__DisplayClass46_6)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
									if (wSBuyOrderItems_Lang2 != null)
									{
										wSBuyOrderItems_Lang2.bordIQuantityDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals6.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals6.lang.LanguageID)).Value : null);
										wSBuyOrderItems_Lang2.bordIDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals6.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals6.lang.LanguageID)).Value : null);
										wSBuyOrderItems_Lang2.bordIForwarderName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals6.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals6.lang.LanguageID)).Value : null);
										wSBuyOrderItems_Lang2.bordICustomsPart = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals6.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals6.lang.LanguageID)).Value : null);
										wSBuyOrderItems_Lang2.bordIPrdNickname = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals6.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals6.lang.LanguageID)).Value : null);
										_dbTbl.Entry(wSBuyOrderItems_Lang2).State = EntityState.Modified;
										_dbTbl.SaveChanges();
										continue;
									}
									wSBuyOrderItems_Lang2 = new WSBuyOrderItems_Lang();
									wSBuyOrderItems_Lang2.LanguageID = CS_0024_003C_003E8__locals6.lang.LanguageID;
									wSBuyOrderItems_Lang2.BuyOrderItemId = CS_0024_003C_003E8__locals6.CS_0024_003C_003E8__locals3.addProduct.DetailId;
									wSBuyOrderItems_Lang2.bordIQuantityDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals6.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals6.lang.LanguageID)).Value : null);
									wSBuyOrderItems_Lang2.bordIDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals6.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals6.lang.LanguageID)).Value : null);
									wSBuyOrderItems_Lang2.bordIForwarderName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals6.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals6.lang.LanguageID)).Value : null);
									wSBuyOrderItems_Lang2.bordICustomsPart = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals6.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals6.lang.LanguageID)).Value : null);
									wSBuyOrderItems_Lang2.bordIPrdNickname = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals6.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals6.lang.LanguageID)).Value : null);
									_dbTbl.WSBuyOrderItems_Lang.Add(wSBuyOrderItems_Lang2);
									_dbTbl.SaveChanges();
								}
							}
							result = ((!BuyOrder.CalcAndSetOrderAmounts(wSBuyOrderItems.BuyOrderId)) ? ("0|" + Messages.msgErrorInCalculation) : ("1|" + Messages.frmFormBaseEditSuccessFulMessage));
							break;
						}
						List<WSspSelectBuyOrderItems_Result> list17 = Enumerable.ToList<WSspSelectBuyOrderItems_Result>((IEnumerable<WSspSelectBuyOrderItems_Result>)_db.WSspSelectBuyOrderItems(CS_0024_003C_003E8__locals0.addProduct.MasterId, lCID, CS_0024_003C_003E8__locals0.defLangID));
						int num16 = (Enumerable.Any<WSspSelectBuyOrderItems_Result>((IEnumerable<WSspSelectBuyOrderItems_Result>)list17) ? Enumerable.Count<WSspSelectBuyOrderItems_Result>((IEnumerable<WSspSelectBuyOrderItems_Result>)list17) : 0);
						wSBuyOrderItems.FPId = id;
						wSBuyOrderItems.GUId = Guid.NewGuid();
						wSBuyOrderItems.Month1 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
						wSBuyOrderItems.RegisterDate = DateTime.Now;
						wSBuyOrderItems.RegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
						wSBuyOrderItems.FirstRegisterUserId = userId;
						wSBuyOrderItems.FirstRegisterDate = DateTime.Now;
						wSBuyOrderItems.FirstRegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
						wSBuyOrderItems.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
						wSBuyOrderItems.bordIOrderView = num16 + 1 + num16 * 4 - 1;
						if (CS_0024_003C_003E8__locals0.addProduct.OrderView.HasValue)
						{
							wSBuyOrderItems.bordIOrderView = CS_0024_003C_003E8__locals0.addProduct.OrderView;
						}
						wSBuyOrderItems.bordICId = BuyOrder.GetBordCId(CS_0024_003C_003E8__locals0.addProduct.MasterId);
						_dbTbl.WSBuyOrderItems.Add(wSBuyOrderItems);
						_dbTbl.SaveChanges();
						foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
						{
							WSBuyOrderItems_Lang wSBuyOrderItems_Lang3 = new WSBuyOrderItems_Lang();
							wSBuyOrderItems_Lang3.LanguageID = lang.LanguageID;
							wSBuyOrderItems_Lang3.BuyOrderItemId = wSBuyOrderItems.BuyOrderItemId;
							wSBuyOrderItems_Lang3.bordIQuantityDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
							wSBuyOrderItems_Lang3.bordIDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
							wSBuyOrderItems_Lang3.bordIForwarderName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
							wSBuyOrderItems_Lang3.bordICustomsPart = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
							wSBuyOrderItems_Lang3.bordIPrdNickname = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
							_dbTbl.WSBuyOrderItems_Lang.Add(wSBuyOrderItems_Lang3);
							_dbTbl.SaveChanges();
						}
						if (wSBuyOrderItems.BuyOrderItemId > 0)
						{
							if (CS_0024_003C_003E8__locals0.addProduct.AddLinkedPrd.HasValue && CS_0024_003C_003E8__locals0.addProduct.AddLinkedPrd.GetValueOrDefault() && !result7)
							{
								DateTime now4 = DateTime.Now;
								string registerDatePersian4 = now4.ToString("yyyyMMdd", new PersianCulture());
								short value7 = short.Parse(now4.ToString("MM", new PersianCulture()));
								mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.WSspInsertBuyOrderItemFromLinkedPrd(CS_0024_003C_003E8__locals0.addProduct.ProductId, CS_0024_003C_003E8__locals0.addProduct.MasterId, CS_0024_003C_003E8__locals0.addProduct.PrdPriceGroupId, CS_0024_003C_003E8__locals0.addProduct.WHId, userId, id, value7, now4, registerDatePersian4, appType, CS_0024_003C_003E8__locals0.defLangID, "", wSBuyOrderItems.BuyOrderItemId, centerId));
								if (mct_I_Result != null && mct_I_Result.Result == 0)
								{
									return "0|" + Messages.msgErrorInAddLinkedPrd;
								}
							}
							result = ((!BuyOrder.CalcAndSetOrderAmounts(wSBuyOrderItems.BuyOrderId)) ? ("0|" + Messages.msgErrorInCalculation) : ("1|" + Messages.frmFormBaseInsertSuccessFulMessage));
						}
						else
						{
							result = "0|" + Messages.frmErrorMessage;
						}
						break;
					}
					case "StockSupply":
					{
						if (CRMIdeal.Classes.Helper.StockSupply.IsFixed(CS_0024_003C_003E8__locals0.addProduct.MasterId))
						{
							return "0|" + Messages.msgErrorNotEditStSup;
						}
						WSspSelectStockSupplyItems_Result wSspSelectStockSupplyItems_Result = Enumerable.FirstOrDefault<WSspSelectStockSupplyItems_Result>((IEnumerable<WSspSelectStockSupplyItems_Result>)Enumerable.OrderByDescending<WSspSelectStockSupplyItems_Result, int>((IEnumerable<WSspSelectStockSupplyItems_Result>)_dbII.WSspSelectStockSupplyItems(CS_0024_003C_003E8__locals0.addProduct.MasterId, lCID, CS_0024_003C_003E8__locals0.defLangID), (Func<WSspSelectStockSupplyItems_Result, int>)((WSspSelectStockSupplyItems_Result m) => m.StockSupplyItemId)));
						_ = wSspSelectStockSupplyItems_Result?.stsupIPrdId;
						_ = wSspSelectStockSupplyItems_Result?.stsupIOrderView;
						WSStockSupplyItems wSStockSupplyItems;
						if (CS_0024_003C_003E8__locals0.addProduct.DetailId > 0)
						{
							wSStockSupplyItems = _dbTbl.WSStockSupplyItems.Find(CS_0024_003C_003E8__locals0.addProduct.DetailId);
							_ = wSStockSupplyItems?.stsupIPrdId;
						}
						else
						{
							wSStockSupplyItems = new WSStockSupplyItems();
						}
						wSStockSupplyItems.stsupIPrdId = CS_0024_003C_003E8__locals0.addProduct.ProductId;
						wSStockSupplyItems.StockSupplyId = CS_0024_003C_003E8__locals0.addProduct.MasterId;
						wSStockSupplyItems.stsupIQuantity = CS_0024_003C_003E8__locals0.addProduct.Quantity;
						wSStockSupplyItems.stsupIFCR = ((CS_0024_003C_003E8__locals0.addProduct.FCR == 0.0) ? null : CS_0024_003C_003E8__locals0.addProduct.FCR);
						wSStockSupplyItems.stsupIFCRI = ((CS_0024_003C_003E8__locals0.addProduct.FCRI == 0.0) ? null : CS_0024_003C_003E8__locals0.addProduct.FCRI);
						wSStockSupplyItems.stsupIPrdUnitId = ((CS_0024_003C_003E8__locals0.addProduct.PrdUnitId == 0) ? null : CS_0024_003C_003E8__locals0.addProduct.PrdUnitId);
						wSStockSupplyItems.stsupIWHId = CS_0024_003C_003E8__locals0.addProduct.WHId;
						wSStockSupplyItems.stsupILinkAccWHIdStr = CS_0024_003C_003E8__locals0.addProduct.WHIdLinkAcc;
						wSStockSupplyItems.UserId = userId;
						wSStockSupplyItems.AppType = appType;
						wSStockSupplyItems.stsupICost = CS_0024_003C_003E8__locals0.addProduct.PrdCost;
						if (CanUpdateStockSupplyItemTracing(wSStockSupplyItems.stsupIWHId, wSStockSupplyItems.stsupIPrdId, wSStockSupplyItems.stsupITracing) == 1)
						{
							CS_0024_003C_003E8__locals0.addProduct.Tracing = ConvertCharacter.DecodeTracing(CS_0024_003C_003E8__locals0.addProduct.Tracing);
							wSStockSupplyItems.stsupITracing = ((!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.addProduct.Tracing)) ? CS_0024_003C_003E8__locals0.addProduct.Tracing : null);
						}
						wSStockSupplyItems.stsupIPrdWeight = CS_0024_003C_003E8__locals0.addProduct.ItemPrdWeight;
						wSStockSupplyItems.stsupIPrdColorId = CS_0024_003C_003E8__locals0.addProduct.PrdColorId;
						wSStockSupplyItems.stsupIPrdUnitIdI = CS_0024_003C_003E8__locals0.addProduct.PrdUnitIdI;
						wSStockSupplyItems.stsupIPrdUnitIRateResult = CS_0024_003C_003E8__locals0.addProduct.PrdUnitIRateResult;
						wSStockSupplyItems.stsupIPrdUnitIdII = CS_0024_003C_003E8__locals0.addProduct.PrdUnitIdII;
						wSStockSupplyItems.stsupIPrdUnitIIRateResult = CS_0024_003C_003E8__locals0.addProduct.PrdUnitIIRateResult;
						wSStockSupplyItems.stsupIQuantityDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						wSStockSupplyItems.stsupIDescription = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						wSStockSupplyItems.stsupIPrdNickname = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						if (result12 == 4)
						{
							wSStockSupplyItems.stsupILinkAccSettingDBId = CS_0024_003C_003E8__locals0.addProduct.LinkAccSettingDBId;
						}
						wSStockSupplyItems.stsupIDescription = wSStockSupplyItems.stsupIDescription ?? "";
						wSStockSupplyItems.stsupIQuantityDesc = wSStockSupplyItems.stsupIQuantityDesc ?? "";
						wSStockSupplyItems.stsupIPrdNickname = wSStockSupplyItems.stsupIPrdNickname ?? "";
						if (CS_0024_003C_003E8__locals0.addProduct.DetailId > 0)
						{
							if (!string.IsNullOrWhiteSpace(wSStockSupplyItems.stsupIBuyOrderIds))
							{
								WSspSelectProductsWithId_Result wSspSelectProductsWithId_Result2 = Enumerable.FirstOrDefault<WSspSelectProductsWithId_Result>((IEnumerable<WSspSelectProductsWithId_Result>)_db.WSspSelectProductsWithId(wSStockSupplyItems.stsupIPrdId, lCID, CS_0024_003C_003E8__locals0.defLangID));
								if (wSspSelectProductsWithId_Result2 != null)
								{
									return "0|" + string.Format(Messages.msgErrorNoEditStsupItemHaveBord, wSspSelectProductsWithId_Result2.PrdName ?? "");
								}
							}
							wSStockSupplyItems.stsupIOrderView = CS_0024_003C_003E8__locals0.addProduct.OrderView;
							wSStockSupplyItems.Month1 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
							wSStockSupplyItems.RegisterDate = DateTime.Now;
							wSStockSupplyItems.RegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
							_dbTbl.Entry(wSStockSupplyItems).State = EntityState.Modified;
							_dbTbl.SaveChanges();
							using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
							{
								while (enumerator.MoveNext())
								{
									_003C_003Ec__DisplayClass46_8 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass46_8();
									CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals4 = CS_0024_003C_003E8__locals0;
									CS_0024_003C_003E8__locals8.lang = enumerator.Current;
									DbSet<WSStockSupplyItems_Lang> wSStockSupplyItems_Lang = _dbTbl.WSStockSupplyItems_Lang;
									ParameterExpression val = Expression.Parameter(typeof(WSStockSupplyItems_Lang), "c");
									WSStockSupplyItems_Lang wSStockSupplyItems_Lang2 = Queryable.FirstOrDefault<WSStockSupplyItems_Lang>((IQueryable<WSStockSupplyItems_Lang>)wSStockSupplyItems_Lang, Expression.Lambda<Func<WSStockSupplyItems_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals8, typeof(_003C_003Ec__DisplayClass46_8)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals8, typeof(_003C_003Ec__DisplayClass46_8)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
									if (wSStockSupplyItems_Lang2 != null)
									{
										wSStockSupplyItems_Lang2.stsupIQuantityDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals8.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals8.lang.LanguageID)).Value : null);
										wSStockSupplyItems_Lang2.stsupIDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals8.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals8.lang.LanguageID)).Value : null);
										wSStockSupplyItems_Lang2.stsupIPrdNickname = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals8.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals8.lang.LanguageID)).Value : null);
										_dbTbl.Entry(wSStockSupplyItems_Lang2).State = EntityState.Modified;
										_dbTbl.SaveChanges();
										continue;
									}
									wSStockSupplyItems_Lang2 = new WSStockSupplyItems_Lang();
									wSStockSupplyItems_Lang2.LanguageID = CS_0024_003C_003E8__locals8.lang.LanguageID;
									wSStockSupplyItems_Lang2.StockSupplyItemId = CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals4.addProduct.DetailId;
									wSStockSupplyItems_Lang2.stsupIQuantityDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals8.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals8.lang.LanguageID)).Value : null);
									wSStockSupplyItems_Lang2.stsupIDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals8.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals8.lang.LanguageID)).Value : null);
									wSStockSupplyItems_Lang2.stsupIPrdNickname = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals8.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals8.lang.LanguageID)).Value : null);
									_dbTbl.WSStockSupplyItems_Lang.Add(wSStockSupplyItems_Lang2);
									_dbTbl.SaveChanges();
								}
							}
							result = ((!CRMIdeal.Classes.Helper.StockSupply.CalcAndSetStockSupplyFields(wSStockSupplyItems.StockSupplyId)) ? ("0|" + Messages.msgErrorInCalculation) : ("1|" + Messages.frmFormBaseEditSuccessFulMessage));
							break;
						}
						List<WSspSelectStockSupplyItems_Result> list12 = Enumerable.ToList<WSspSelectStockSupplyItems_Result>((IEnumerable<WSspSelectStockSupplyItems_Result>)_dbII.WSspSelectStockSupplyItems(CS_0024_003C_003E8__locals0.addProduct.MasterId, lCID, CS_0024_003C_003E8__locals0.defLangID));
						int num10 = (Enumerable.Any<WSspSelectStockSupplyItems_Result>((IEnumerable<WSspSelectStockSupplyItems_Result>)list12) ? Enumerable.Count<WSspSelectStockSupplyItems_Result>((IEnumerable<WSspSelectStockSupplyItems_Result>)list12) : 0);
						wSStockSupplyItems.FPId = id;
						wSStockSupplyItems.GUId = Guid.NewGuid();
						wSStockSupplyItems.Month1 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
						wSStockSupplyItems.RegisterDate = DateTime.Now;
						wSStockSupplyItems.RegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
						wSStockSupplyItems.FirstRegisterUserId = userId;
						wSStockSupplyItems.FirstRegisterDate = DateTime.Now;
						wSStockSupplyItems.FirstRegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
						wSStockSupplyItems.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
						wSStockSupplyItems.stsupIOrderView = num10 + 1 + num10 * 4 - 1;
						if (CS_0024_003C_003E8__locals0.addProduct.OrderView.HasValue)
						{
							wSStockSupplyItems.stsupIOrderView = CS_0024_003C_003E8__locals0.addProduct.OrderView;
						}
						wSStockSupplyItems.stsupICId = CRMIdeal.Classes.Helper.StockSupply.GetStsupCId(CS_0024_003C_003E8__locals0.addProduct.MasterId);
						_dbTbl.WSStockSupplyItems.Add(wSStockSupplyItems);
						_dbTbl.SaveChanges();
						if (wSStockSupplyItems.StockSupplyItemId > 0)
						{
							foreach (Languages lang5 in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
							{
								WSStockSupplyItems_Lang wSStockSupplyItems_Lang3 = new WSStockSupplyItems_Lang();
								wSStockSupplyItems_Lang3.LanguageID = lang5.LanguageID;
								wSStockSupplyItems_Lang3.StockSupplyItemId = wSStockSupplyItems.StockSupplyItemId;
								wSStockSupplyItems_Lang3.stsupIQuantityDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang5.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang5.LanguageID)).Value : null);
								wSStockSupplyItems_Lang3.stsupIDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang5.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang5.LanguageID)).Value : null);
								wSStockSupplyItems_Lang3.stsupIPrdNickname = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang5.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang5.LanguageID)).Value : null);
								_dbTbl.WSStockSupplyItems_Lang.Add(wSStockSupplyItems_Lang3);
								_dbTbl.SaveChanges();
							}
							result = ((!CRMIdeal.Classes.Helper.StockSupply.CalcAndSetStockSupplyFields(wSStockSupplyItems.StockSupplyId)) ? ("0|" + Messages.msgErrorInCalculation) : ("1|" + Messages.frmFormBaseInsertSuccessFulMessage));
						}
						else
						{
							result = "0|" + Messages.frmErrorMessage;
						}
						break;
					}
					}
				}
				else
				{
					result = "0|" + Messages.frmErrorMessage + "<br/> ";
					result += string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
				}
			}
			catch (Exception e5)
			{
				ErrorSignal.FromCurrentContext().Raise(e5);
				result = "0|" + Messages.frmErrorMessage;
			}
		}
		else
		{
			result = "0|" + Messages.msgErrorNotSelectProduct;
		}
		return result;
	}

	public string CheckDuplicateProduct(string masterForm, int masterId, int prdId, int currentId)
	{
		string text = "0";
		try
		{
			switch (masterForm)
			{
			case "preOrder":
			{
				IQueryable<int?> val = _db.WSfnCheckDuplicatePreOrderProduct(masterId, prdId, currentId);
				return (val != null && Queryable.Any<int?>(val)) ? "1" : "0";
			}
			case "UserPavProduct":
			{
				IQueryable<WSfnCheckDuplicateUserFavPrd_Result> val3 = _db.WSfnCheckDuplicateUserFavPrd(prdId, UserLogin.CurrentUser.UserId, masterId);
				return (val3 != null && Queryable.Any<WSfnCheckDuplicateUserFavPrd_Result>(val3)) ? "-1" : "0";
			}
			case "SaleOrder":
			{
				IQueryable<int?> val2 = _db.WSfnCheckDuplicateOrderProduct(masterId, prdId, currentId);
				return (val2 != null && Queryable.Any<int?>(val2)) ? "1" : "0";
			}
			case "BuyOrder":
			{
				IQueryable<int?> val4 = _db.WSfnCheckDuplicateBuyOrderProduct(masterId, prdId, currentId);
				return (val4 != null && Queryable.Any<int?>(val4)) ? "1" : "0";
			}
			case "StockSupply":
			{
				ObjectResult<WSspCheckDuplicateStockSupplyProduct_Result> objectResult = _dbII.WSspCheckDuplicateStockSupplyProduct(masterId, prdId, currentId);
				return (objectResult != null && Enumerable.Any<WSspCheckDuplicateStockSupplyProduct_Result>((IEnumerable<WSspCheckDuplicateStockSupplyProduct_Result>)objectResult)) ? "1" : "0";
			}
			default:
				return "0";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return "-1";
		}
	}

	public decimal ReturnProductUserDiscountResult(int prdGroupId, int prdId)
	{
		decimal result = default(decimal);
		try
		{
			decimal? num = Enumerable.FirstOrDefault<decimal?>((IEnumerable<decimal?>)_db.WSspReturnProductUserDiscountValue(prdGroupId, prdId, UserLogin.CurrentUser.UserId));
			if (num.HasValue)
			{
				result = num.Value;
				return result;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[AjaxOnly]
	public JsonResult ReturnProductUserDiscount(int prdGroupId, int prdId)
	{
		decimal num = default(decimal);
		try
		{
			num = ReturnProductUserDiscountResult(prdGroupId, prdId);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(num, JsonRequestBehavior.AllowGet);
	}

	public List<SelectListItem> GetOrderTracingList(int whId, int prdId, string masterFormName, int currentItemId = 0)
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
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			int result2 = 0;
			if (currentUser != null)
			{
				int.TryParse(currentUser.UserLastCId.ToString(), out result2);
			}
			if (whId != 0 && prdId != 0)
			{
				if ((masterFormName ?? "").ToLower() == "preorder" && UserLogin.IsUserAccess("frmPreOrder", "actCanNotVerifyNoStockFromShop", currentUser))
				{
					List<WSspReturnProductTracingFromShop_Result> list2 = Enumerable.ToList<WSspReturnProductTracingFromShop_Result>((IEnumerable<WSspReturnProductTracingFromShop_Result>)_dbII.WSspReturnProductTracingFromShop(whId, prdId, 0, currentItemId, 0, 0, result2, lCID, result));
					list.AddRange(Enumerable.Select<WSspReturnProductTracingFromShop_Result, SelectListItem>((IEnumerable<WSspReturnProductTracingFromShop_Result>)list2, (Func<WSspReturnProductTracingFromShop_Result, SelectListItem>)((WSspReturnProductTracingFromShop_Result item) => new SelectListItem
					{
						Text = (item.Tracing ?? ""),
						Value = (item.Tracing ?? ""),
						Selected = false
					})));
				}
				else
				{
					List<WSspReturnProductTracing_Result> list3 = Enumerable.ToList<WSspReturnProductTracing_Result>((IEnumerable<WSspReturnProductTracing_Result>)_db.WSspReturnProductTracing(whId, prdId, result2));
					list.AddRange(Enumerable.Select<WSspReturnProductTracing_Result, SelectListItem>((IEnumerable<WSspReturnProductTracing_Result>)list3, (Func<WSspReturnProductTracing_Result, SelectListItem>)((WSspReturnProductTracing_Result item) => new SelectListItem
					{
						Text = (item.Tracing ?? ""),
						Value = (item.Tracing ?? ""),
						Selected = false
					})));
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[AjaxOnly]
	public JsonResult GetOrderTracing(int whId, int prdId, string masterFormName, int currentItemId = 0)
	{
		List<SelectListItem> data = new List<SelectListItem>();
		try
		{
			data = GetOrderTracingList(whId, prdId, masterFormName, currentItemId);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(data, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public int CanUpdateBuyOrderItemTracing(int? whId = 0, int prdId = 0, string tracing = null)
	{
		int result = 0;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			tracing = ConvertCharacter.DecodeTracing(tracing);
			if (Enumerable.FirstOrDefault<WSspCheckCanUpdateBuyOrderItemTracing_Result>((IEnumerable<WSspCheckCanUpdateBuyOrderItemTracing_Result>)_db.WSspCheckCanUpdateBuyOrderItemTracing(prdId, whId, tracing, lCID, result2)) == null)
			{
				result = 1;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public string CheckDuplicateBuyOrderItemTracing(string masterForm, int masterId, int prdId, int currentId, string tracing)
	{
		string result = "1";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (string.IsNullOrWhiteSpace(tracing))
			{
				return result;
			}
			tracing = ConvertCharacter.DecodeTracing(tracing);
			bool flag = false;
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				flag = ((cRMspSelectCrmsysSetting_Result.CanUseDupTracing.HasValue && cRMspSelectCrmsysSetting_Result.CanUseDupTracing != false) ? true : false);
			}
			if (!flag)
			{
				if (!(masterForm == "BuyOrder"))
				{
					if (masterForm == "StockSupply")
					{
						WSspCheckDuplicateStockSupplyItemTracing_Result wSspCheckDuplicateStockSupplyItemTracing_Result = Enumerable.FirstOrDefault<WSspCheckDuplicateStockSupplyItemTracing_Result>((IEnumerable<WSspCheckDuplicateStockSupplyItemTracing_Result>)_dbII.WSspCheckDuplicateStockSupplyItemTracing(prdId, currentId, tracing, lCID, result2));
						if (wSspCheckDuplicateStockSupplyItemTracing_Result != null)
						{
							result = string.Format(Messages.msgErrorStockSupplyItemTracingDuplicate, wSspCheckDuplicateStockSupplyItemTracing_Result.stsupNumber);
						}
					}
				}
				else
				{
					WSspCheckDuplicateBuyOrderItemTracing_Result wSspCheckDuplicateBuyOrderItemTracing_Result = Enumerable.FirstOrDefault<WSspCheckDuplicateBuyOrderItemTracing_Result>((IEnumerable<WSspCheckDuplicateBuyOrderItemTracing_Result>)_db.WSspCheckDuplicateBuyOrderItemTracing(prdId, currentId, tracing, lCID, result2));
					if (wSspCheckDuplicateBuyOrderItemTracing_Result != null)
					{
						result = string.Format(Messages.msgErrorOrderItemTracingDuplicate, wSspCheckDuplicateBuyOrderItemTracing_Result.bordNumber);
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = "-1";
		}
		return result;
	}

	public List<SelectListItem> GetShomaranTracingList(int whId, int prdId, string linkAccWhId = "")
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspLkShomaranReturnProductTracing_Result> list2 = Enumerable.ToList<CRMspLkShomaranReturnProductTracing_Result>((IEnumerable<CRMspLkShomaranReturnProductTracing_Result>)_dbLink.CRMspLkShomaranReturnProductTracing(prdId, whId, linkAccWhId));
			list.AddRange(Enumerable.Select<CRMspLkShomaranReturnProductTracing_Result, SelectListItem>((IEnumerable<CRMspLkShomaranReturnProductTracing_Result>)list2, (Func<CRMspLkShomaranReturnProductTracing_Result, SelectListItem>)((CRMspLkShomaranReturnProductTracing_Result item) => new SelectListItem
			{
				Text = (item.Tracing ?? ""),
				Value = (item.Tracing ?? ""),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	public List<SelectListItem> GetShomaranSefareshCodeList(int whId, int prdId, string linkAccWhId = "")
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspLkShomaranReturnProductSefareshCode_Result> list2 = Enumerable.ToList<CRMspLkShomaranReturnProductSefareshCode_Result>((IEnumerable<CRMspLkShomaranReturnProductSefareshCode_Result>)_dbLink.CRMspLkShomaranReturnProductSefareshCode(prdId, whId, linkAccWhId));
			list.AddRange(Enumerable.Select<CRMspLkShomaranReturnProductSefareshCode_Result, SelectListItem>((IEnumerable<CRMspLkShomaranReturnProductSefareshCode_Result>)list2, (Func<CRMspLkShomaranReturnProductSefareshCode_Result, SelectListItem>)((CRMspLkShomaranReturnProductSefareshCode_Result item) => new SelectListItem
			{
				Text = (item.SefareshCode ?? ""),
				Value = (item.SefareshCode ?? ""),
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
	public JsonResult GetShomaranTracingAndSefaresh(int whId, int prdId, string linkAccWhId = "")
	{
		CommonSelectListItemsViewModel commonSelectListItemsViewModel = new CommonSelectListItemsViewModel();
		commonSelectListItemsViewModel.ListI = new List<SelectListItem>();
		commonSelectListItemsViewModel.ListII = new List<SelectListItem>();
		try
		{
			commonSelectListItemsViewModel.ListI = GetShomaranTracingList(whId, prdId, linkAccWhId);
			commonSelectListItemsViewModel.ListII = GetShomaranSefareshCodeList(whId, prdId, linkAccWhId);
			if (commonSelectListItemsViewModel.ListI == null)
			{
				commonSelectListItemsViewModel.ListI = new List<SelectListItem>();
			}
			if (commonSelectListItemsViewModel.ListII == null)
			{
				commonSelectListItemsViewModel.ListII = new List<SelectListItem>();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(commonSelectListItemsViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public int CanUpdateStockSupplyItemTracing(int? whId = 0, int prdId = 0, string tracing = null)
	{
		int result = 0;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			tracing = ConvertCharacter.DecodeTracing(tracing);
			if (Enumerable.FirstOrDefault<WSspCheckCanUpdateStockSupplyItemTracing_Result>((IEnumerable<WSspCheckCanUpdateStockSupplyItemTracing_Result>)_dbII.WSspCheckCanUpdateStockSupplyItemTracing(prdId, whId, tracing, lCID, result2)) == null)
			{
				result = 1;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[AjaxOnly]
	public ActionResult LinkedProducts_Read([DataSourceRequest] DataSourceRequest request, int prdId, int productPriceGroupId, int destCurrencyUnitId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectLinkedProductsWithPrice_Result> enumerable = new List<WSspSelectLinkedProductsWithPrice_Result>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			enumerable = Enumerable.ToList<WSspSelectLinkedProductsWithPrice_Result>((IEnumerable<WSspSelectLinkedProductsWithPrice_Result>)_dbI.WSspSelectLinkedProductsWithPrice(prdId, productPriceGroupId, destCurrencyUnitId, lCID, result, result2));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public WSspReturnDraftItemQuantityByOrdItemId_Result ReturnDraftItemQuantityResult(int mode, int itemId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		WSspReturnDraftItemQuantityByOrdItemId_Result wSspReturnDraftItemQuantityByOrdItemId_Result = new WSspReturnDraftItemQuantityByOrdItemId_Result();
		try
		{
			if (itemId > 0)
			{
				switch (mode)
				{
				case 1:
					wSspReturnDraftItemQuantityByOrdItemId_Result = Enumerable.FirstOrDefault<WSspReturnDraftItemQuantityByOrdItemId_Result>((IEnumerable<WSspReturnDraftItemQuantityByOrdItemId_Result>)_dbI.WSspReturnDraftItemQuantityByOrdItemId(itemId));
					break;
				case 2:
				{
					WSspReturnDocItemQuantityByBordItemId_Result wSspReturnDocItemQuantityByBordItemId_Result = Enumerable.FirstOrDefault<WSspReturnDocItemQuantityByBordItemId_Result>((IEnumerable<WSspReturnDocItemQuantityByBordItemId_Result>)_dbI.WSspReturnDocItemQuantityByBordItemId(itemId));
					if (wSspReturnDocItemQuantityByBordItemId_Result != null)
					{
						wSspReturnDraftItemQuantityByOrdItemId_Result = new WSspReturnDraftItemQuantityByOrdItemId_Result
						{
							OrderId = wSspReturnDocItemQuantityByBordItemId_Result.BuyOrderId,
							OrderItemID = wSspReturnDocItemQuantityByBordItemId_Result.BuyOrderItemId,
							ordIPrdId = wSspReturnDocItemQuantityByBordItemId_Result.bordIPrdId,
							ordIWHId = wSspReturnDocItemQuantityByBordItemId_Result.bordIWHId,
							ordIQuantity = wSspReturnDocItemQuantityByBordItemId_Result.bordIQuantity,
							DocItemQuantity = wSspReturnDocItemQuantityByBordItemId_Result.DocItemQuantity,
							RemainedQuantity = wSspReturnDocItemQuantityByBordItemId_Result.RemainedQuantity
						};
					}
					break;
				}
				case 3:
				{
					WSspReturnDraftItemQuantityByPordItemId_Result wSspReturnDraftItemQuantityByPordItemId_Result = Enumerable.FirstOrDefault<WSspReturnDraftItemQuantityByPordItemId_Result>((IEnumerable<WSspReturnDraftItemQuantityByPordItemId_Result>)_dbI.WSspReturnDraftItemQuantityByPordItemId(itemId));
					if (wSspReturnDraftItemQuantityByPordItemId_Result != null)
					{
						wSspReturnDraftItemQuantityByOrdItemId_Result = new WSspReturnDraftItemQuantityByOrdItemId_Result
						{
							OrderId = wSspReturnDraftItemQuantityByPordItemId_Result.PreOrderId,
							OrderItemID = wSspReturnDraftItemQuantityByPordItemId_Result.PreOrderItemID,
							ordIPrdId = wSspReturnDraftItemQuantityByPordItemId_Result.pordIPrdId,
							ordIWHId = wSspReturnDraftItemQuantityByPordItemId_Result.pordIWHId,
							ordIQuantity = wSspReturnDraftItemQuantityByPordItemId_Result.pordIQuantity,
							DocItemQuantity = wSspReturnDraftItemQuantityByPordItemId_Result.DocItemQuantity,
							RemainedQuantity = wSspReturnDraftItemQuantityByPordItemId_Result.RemainedQuantity
						};
					}
					break;
				}
				}
			}
			if (wSspReturnDraftItemQuantityByOrdItemId_Result == null)
			{
				wSspReturnDraftItemQuantityByOrdItemId_Result = new WSspReturnDraftItemQuantityByOrdItemId_Result();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return wSspReturnDraftItemQuantityByOrdItemId_Result;
	}

	[AjaxOnly]
	public JsonResult ReturnDraftItemQuantity(int mode, int itemId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		WSspReturnDraftItemQuantityByOrdItemId_Result wSspReturnDraftItemQuantityByOrdItemId_Result = new WSspReturnDraftItemQuantityByOrdItemId_Result();
		try
		{
			wSspReturnDraftItemQuantityByOrdItemId_Result = ReturnDraftItemQuantityResult(mode, itemId);
			if (wSspReturnDraftItemQuantityByOrdItemId_Result == null)
			{
				wSspReturnDraftItemQuantityByOrdItemId_Result = new WSspReturnDraftItemQuantityByOrdItemId_Result();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(wSspReturnDraftItemQuantityByOrdItemId_Result, JsonRequestBehavior.AllowGet);
	}

	public WSspReturnBuyOrderItemQuantityByOrdItemId_Result ReturnBordItemQuantityResult(int mode, int itemId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		WSspReturnBuyOrderItemQuantityByOrdItemId_Result wSspReturnBuyOrderItemQuantityByOrdItemId_Result = new WSspReturnBuyOrderItemQuantityByOrdItemId_Result();
		try
		{
			if (itemId > 0 && mode == 1)
			{
				wSspReturnBuyOrderItemQuantityByOrdItemId_Result = Enumerable.FirstOrDefault<WSspReturnBuyOrderItemQuantityByOrdItemId_Result>((IEnumerable<WSspReturnBuyOrderItemQuantityByOrdItemId_Result>)_dbII.WSspReturnBuyOrderItemQuantityByOrdItemId(itemId));
			}
			if (wSspReturnBuyOrderItemQuantityByOrdItemId_Result == null)
			{
				wSspReturnBuyOrderItemQuantityByOrdItemId_Result = new WSspReturnBuyOrderItemQuantityByOrdItemId_Result();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return wSspReturnBuyOrderItemQuantityByOrdItemId_Result;
	}

	[AjaxOnly]
	public JsonResult ReturnBordItemQuantity(int mode, int itemId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		WSspReturnBuyOrderItemQuantityByOrdItemId_Result wSspReturnBuyOrderItemQuantityByOrdItemId_Result = new WSspReturnBuyOrderItemQuantityByOrdItemId_Result();
		try
		{
			wSspReturnBuyOrderItemQuantityByOrdItemId_Result = ReturnBordItemQuantityResult(mode, itemId);
			if (wSspReturnBuyOrderItemQuantityByOrdItemId_Result == null)
			{
				wSspReturnBuyOrderItemQuantityByOrdItemId_Result = new WSspReturnBuyOrderItemQuantityByOrdItemId_Result();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(wSspReturnBuyOrderItemQuantityByOrdItemId_Result, JsonRequestBehavior.AllowGet);
	}

	public WSspReturnOrderItemQuantityByPordItemId_Result ReturnOrderItemQuantityResult(int itemId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		WSspReturnOrderItemQuantityByPordItemId_Result wSspReturnOrderItemQuantityByPordItemId_Result = new WSspReturnOrderItemQuantityByPordItemId_Result();
		try
		{
			if (itemId > 0)
			{
				wSspReturnOrderItemQuantityByPordItemId_Result = Enumerable.FirstOrDefault<WSspReturnOrderItemQuantityByPordItemId_Result>((IEnumerable<WSspReturnOrderItemQuantityByPordItemId_Result>)_dbI.WSspReturnOrderItemQuantityByPordItemId(itemId));
			}
			if (wSspReturnOrderItemQuantityByPordItemId_Result == null)
			{
				wSspReturnOrderItemQuantityByPordItemId_Result = new WSspReturnOrderItemQuantityByPordItemId_Result();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return wSspReturnOrderItemQuantityByPordItemId_Result;
	}

	[AjaxOnly]
	public JsonResult ReturnOrderItemQuantity(int itemId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		WSspReturnOrderItemQuantityByPordItemId_Result wSspReturnOrderItemQuantityByPordItemId_Result = new WSspReturnOrderItemQuantityByPordItemId_Result();
		try
		{
			wSspReturnOrderItemQuantityByPordItemId_Result = ReturnOrderItemQuantityResult(itemId);
			if (wSspReturnOrderItemQuantityByPordItemId_Result == null)
			{
				wSspReturnOrderItemQuantityByPordItemId_Result = new WSspReturnOrderItemQuantityByPordItemId_Result();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(wSspReturnOrderItemQuantityByPordItemId_Result, JsonRequestBehavior.AllowGet);
	}

	[HttpPost]
	public JsonResult SearchTracingInBord(string tracing, int prdId)
	{
		List<WSspSearchTracingInBuyOrder_Result> data = new List<WSspSearchTracingInBuyOrder_Result>();
		try
		{
			tracing = ConvertCharacter.DecodeTracing(tracing);
			data = Enumerable.ToList<WSspSearchTracingInBuyOrder_Result>((IEnumerable<WSspSearchTracingInBuyOrder_Result>)_dbI.WSspSearchTracingInBuyOrder(tracing, prdId));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(data, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[HttpPost]
	public JsonResult SearchTracingInStsup(string tracing, int prdId)
	{
		List<WSspSearchTracingInBuyOrder_Result> list = new List<WSspSearchTracingInBuyOrder_Result>();
		try
		{
			tracing = ConvertCharacter.DecodeTracing(tracing);
			List<WSspSearchTracingInStockSupply_Result> list2 = Enumerable.ToList<WSspSearchTracingInStockSupply_Result>((IEnumerable<WSspSearchTracingInStockSupply_Result>)_dbII.WSspSearchTracingInStockSupply(tracing, prdId));
			if (list2 != null && Enumerable.Any<WSspSearchTracingInStockSupply_Result>((IEnumerable<WSspSearchTracingInStockSupply_Result>)list2))
			{
				foreach (WSspSearchTracingInStockSupply_Result item2 in list2)
				{
					WSspSearchTracingInBuyOrder_Result item = new WSspSearchTracingInBuyOrder_Result
					{
						bordITracing = item2.stsupITracing
					};
					list.Add(item);
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
	public JsonResult GetAllProductInfo(string masterFormName, int modeInsEdt, int prdId, int prdGroupId, int whId, int prdPriceGroupId, int prdCostGroupId, double fcr, double fcrI, int modeOtherCmpSaleReord, int modeSaleReord, int currentMasterId = 0, int currentItemId = 0, int currUnitId = 0, int cmpId = 0, string tracing = null, string crmOrdType = "pord", string linkAccWhId = "", string sefareshCode = "", int linkAccSettingDBId = 0)
	{
		_003C_003Ec__DisplayClass67_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass67_0();
		CS_0024_003C_003E8__locals0.prdId = prdId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		tracing = ConvertCharacter.DecodeTracing(tracing);
		int? centerId = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId : null);
		CurrentAllProductInfoViewModel currentAllProductInfoViewModel = new CurrentAllProductInfoViewModel();
		currentAllProductInfoViewModel.TracingList = new List<SelectListItem>();
		currentAllProductInfoViewModel.ProductPrice = new WSspReturnProductPriceViewModel();
		currentAllProductInfoViewModel.ProductCost = new WSspReturnProductCost_Result();
		currentAllProductInfoViewModel.ProductQuantity = new ReturnPrdQuantityViewModel();
		currentAllProductInfoViewModel.PrdSalePriceHistory = new WSspPrdSalePriceHistory_Result();
		currentAllProductInfoViewModel.CmpPrdSalePriceNearHistory = new WSspCmpPrdSalePriceHistory_Result();
		currentAllProductInfoViewModel.CmpPrdBuyCostNearHistory = new WSspCmpPrdBuyCostNearHistory_Result();
		currentAllProductInfoViewModel.DraftItemQuantity = new WSspReturnDraftItemQuantityByOrdItemId_Result();
		currentAllProductInfoViewModel.OrderItemQuantity = new WSspReturnOrderItemQuantityByPordItemId_Result();
		currentAllProductInfoViewModel.LinkedProductIds = "";
		currentAllProductInfoViewModel.ValidityExpireDate = "";
		currentAllProductInfoViewModel.ValidityExpireTime = "";
		currentAllProductInfoViewModel.PrdNickname_Lang = "";
		currentAllProductInfoViewModel.Description_Lang = "";
		currentAllProductInfoViewModel.DeliveryScheduleTotalCount = 0;
		currentAllProductInfoViewModel.ListPrdPriceGroup = new List<SelectListItem>();
		currentAllProductInfoViewModel.CmpGroupIIRate = -1.0;
		currentAllProductInfoViewModel.SefareshCodeList = new List<SelectListItem>();
		currentAllProductInfoViewModel.BuyOrderItemQuantity = new WSspReturnBuyOrderItemQuantityByOrdItemId_Result();
		try
		{
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			if (CS_0024_003C_003E8__locals0.prdId != 0)
			{
				int result2 = 0;
				if (UserLogin.CurrentUser != null)
				{
					int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
				}
				int num = 0;
				if (cRMspSelectCrmsysSetting_Result != null)
				{
					num = cRMspSelectCrmsysSetting_Result.LinkAccSystemId.GetValueOrDefault();
				}
				WSspSelectProductsWithId_Result wSspSelectProductsWithId_Result = Enumerable.FirstOrDefault<WSspSelectProductsWithId_Result>((IEnumerable<WSspSelectProductsWithId_Result>)_db.WSspSelectProductsWithId(CS_0024_003C_003E8__locals0.prdId, result, result));
				DbSet<WSProducts_Lang> wSProducts_Lang = _dbTbl.WSProducts_Lang;
				ParameterExpression val = Expression.Parameter(typeof(WSProducts_Lang), "c");
				List<WSProducts_Lang> list = Enumerable.ToList<WSProducts_Lang>((IEnumerable<WSProducts_Lang>)Queryable.Where<WSProducts_Lang>((IQueryable<WSProducts_Lang>)wSProducts_Lang, Expression.Lambda<Func<WSProducts_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass67_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
				if (wSspSelectProductsWithId_Result != null)
				{
					List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
					if (list != null)
					{
						list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSProducts_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSProducts_Lang>)list, (Func<WSProducts_Lang, CommonMultiLanguageViewModel>)((WSProducts_Lang item) => new CommonMultiLanguageViewModel
						{
							Value = item.PrdNickname,
							LanguageId = item.LanguageID
						})));
					}
					list2.Add(new CommonMultiLanguageViewModel
					{
						Value = wSspSelectProductsWithId_Result.PrdNickname,
						LanguageId = result
					});
					List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
					if (list != null)
					{
						list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WSProducts_Lang, CommonMultiLanguageViewModel>((IEnumerable<WSProducts_Lang>)list, (Func<WSProducts_Lang, CommonMultiLanguageViewModel>)((WSProducts_Lang item) => new CommonMultiLanguageViewModel
						{
							Value = item.PrdDescription,
							LanguageId = item.LanguageID
						})));
					}
					list3.Add(new CommonMultiLanguageViewModel
					{
						Value = wSspSelectProductsWithId_Result.PrdDescription,
						LanguageId = result
					});
					currentAllProductInfoViewModel.PrdNickname_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
					currentAllProductInfoViewModel.Description_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
					currentAllProductInfoViewModel.PrdDoneTimeMin = wSspSelectProductsWithId_Result.PrdDoneTimeMin;
					currentAllProductInfoViewModel.PrdSaleCenterIds = wSspSelectProductsWithId_Result.PrdSaleCenterIds;
					currentAllProductInfoViewModel.PrdAutoCalcPrice = wSspSelectProductsWithId_Result.PrdAutoCalcPrice.GetValueOrDefault();
					decimal result3 = default(decimal);
					if (currentAllProductInfoViewModel.PrdAutoCalcPrice.GetValueOrDefault())
					{
						ObjectParameter objectParameter = new ObjectParameter("price", typeof(decimal));
						if (masterFormName == "preOrder")
						{
							_dbII.WSspAutoCalcPreOrderItemPrice(currentMasterId, CS_0024_003C_003E8__locals0.prdId, objectParameter);
						}
						else if (masterFormName == "SaleOrder")
						{
							_dbII.WSspAutoCalcOrderItemPrice(currentMasterId, CS_0024_003C_003E8__locals0.prdId, objectParameter);
						}
						if (objectParameter != null && objectParameter.Value != null && !string.IsNullOrWhiteSpace(objectParameter.Value.ToString()))
						{
							decimal.TryParse(objectParameter.Value.ToString(), out result3);
						}
					}
					currentAllProductInfoViewModel.PrdAutoCalcItemPrice = result3;
				}
				if (masterFormName == "SaleOrder" || masterFormName == "preOrder")
				{
					if (num == 11)
					{
						currentAllProductInfoViewModel.TracingList = GetShomaranTracingList(whId, CS_0024_003C_003E8__locals0.prdId, linkAccWhId);
						currentAllProductInfoViewModel.SefareshCodeList = GetShomaranSefareshCodeList(whId, CS_0024_003C_003E8__locals0.prdId, linkAccWhId);
					}
					else
					{
						currentAllProductInfoViewModel.TracingList = GetOrderTracingList(whId, CS_0024_003C_003E8__locals0.prdId, masterFormName, currentItemId);
					}
				}
				if (!string.IsNullOrWhiteSpace(tracing))
				{
					if (masterFormName == "BuyOrder")
					{
						currentAllProductInfoViewModel.CanUpdateBuyOrderItemTracing = CanUpdateBuyOrderItemTracing(whId, CS_0024_003C_003E8__locals0.prdId, tracing);
					}
					else if (masterFormName == "StockSupply")
					{
						currentAllProductInfoViewModel.CanUpdateBuyOrderItemTracing = CanUpdateStockSupplyItemTracing(whId, CS_0024_003C_003E8__locals0.prdId, tracing);
					}
				}
				bool flag = false;
				bool flag2 = false;
				if (cRMspSelectCrmsysSetting_Result != null)
				{
					flag2 = ((cRMspSelectCrmsysSetting_Result.PrdPriceFromLink.HasValue && cRMspSelectCrmsysSetting_Result.PrdPriceFromLink.GetValueOrDefault()) ? true : false);
				}
				if (flag2 && num > 0 && num == 3)
				{
					flag = true;
				}
				if (flag)
				{
					currentAllProductInfoViewModel.ProductPrice = new WSspReturnProductPriceViewModel();
					currentAllProductInfoViewModel.ProductPrice.CurrencyUnitEn = "GetPriceForAccLink";
				}
				else
				{
					currentAllProductInfoViewModel.ProductPrice = ReturnProductPriceResult(CS_0024_003C_003E8__locals0.prdId, prdPriceGroupId, currUnitId, cmpId, whId, crmOrdType, "-1");
				}
				List<WSspSelectProductPriceGroupByPrdId_Result> list4 = Enumerable.ToList<WSspSelectProductPriceGroupByPrdId_Result>((IEnumerable<WSspSelectProductPriceGroupByPrdId_Result>)_dbI.WSspSelectProductPriceGroupByPrdId(CS_0024_003C_003E8__locals0.prdId, CS_0024_003C_003E8__locals0.currLangID, result, centerId));
				if (list4 != null && Enumerable.Any<WSspSelectProductPriceGroupByPrdId_Result>((IEnumerable<WSspSelectProductPriceGroupByPrdId_Result>)list4))
				{
					foreach (WSspSelectProductPriceGroupByPrdId_Result item3 in list4)
					{
						string text = "";
						text = ((!item3.LastPriceDocDateTime.HasValue) ? "" : (item3.LastPriceDocDateTime.HasValue ? item3.LastPriceDocDateTime.Value.ToString("yyyy/MM/dd") : ""));
						if (!string.IsNullOrWhiteSpace(text))
						{
							text = " (" + text + ")";
						}
						SelectListItem item2 = new SelectListItem
						{
							Text = item3.ProductPriceGroupName + text,
							Value = item3.ProductPriceGroupID.ToString()
						};
						currentAllProductInfoViewModel.ListPrdPriceGroup.Add(item2);
					}
				}
				if (currentAllProductInfoViewModel.ListPrdPriceGroup == null)
				{
					currentAllProductInfoViewModel.ListPrdPriceGroup = new List<SelectListItem>();
				}
				currentAllProductInfoViewModel.ProductUserDiscount = ReturnProductUserDiscountResult(prdGroupId, CS_0024_003C_003E8__locals0.prdId);
				currentAllProductInfoViewModel.ProductCost = ReturnProductCostResult(CS_0024_003C_003E8__locals0.prdId, prdCostGroupId, currUnitId);
				bool flag3 = false;
				bool flag4 = false;
				num = 0;
				if (cRMspSelectCrmsysSetting_Result != null)
				{
					flag4 = ((cRMspSelectCrmsysSetting_Result.InvStockFromLink.HasValue && cRMspSelectCrmsysSetting_Result.InvStockFromLink.GetValueOrDefault()) ? true : false);
					num = cRMspSelectCrmsysSetting_Result.LinkAccSystemId.GetValueOrDefault();
				}
				if (flag4 && num > 0)
				{
					new ProductController();
					switch (num)
					{
					case 3:
						flag3 = true;
						break;
					case 4:
						flag3 = true;
						break;
					case 6:
						flag3 = true;
						break;
					case 7:
						flag3 = true;
						break;
					case 11:
						flag3 = true;
						break;
					case 12:
						flag3 = true;
						break;
					}
				}
				if (flag3)
				{
					currentAllProductInfoViewModel.ProductQuantity = new ReturnPrdQuantityViewModel();
					currentAllProductInfoViewModel.ProductQuantity.PrdQuantity = new WSspReturnPrdQuantity_Result();
					currentAllProductInfoViewModel.ProductQuantity.PrdQuantity.PrdName = "GetQuantityForAccLink";
				}
				else
				{
					currentAllProductInfoViewModel.ProductQuantity = ReturnPrdQuantityResult(CS_0024_003C_003E8__locals0.prdId, currentMasterId, whId, fcr, fcrI, tracing, cmpId, prdPriceGroupId, crmOrdType, linkAccWhId, sefareshCode, masterFormName, linkAccSettingDBId, currentItemId);
				}
				currentAllProductInfoViewModel.PrdSalePriceHistory = PrdSalePriceHistoryResult(CS_0024_003C_003E8__locals0.prdId, modeOtherCmpSaleReord);
				currentAllProductInfoViewModel.CmpPrdSalePriceNearHistory = CmpPrdSalePriceNearHistoryResult(CS_0024_003C_003E8__locals0.prdId, cmpId, modeSaleReord);
				currentAllProductInfoViewModel.CmpPrdBuyCostNearHistory = CmpPrdBuyCostNearHistoryResult(CS_0024_003C_003E8__locals0.prdId, cmpId);
				switch (masterFormName)
				{
				case "SaleOrder":
					currentAllProductInfoViewModel.DraftItemQuantity = ReturnDraftItemQuantityResult(1, currentItemId);
					currentAllProductInfoViewModel.BuyOrderItemQuantity = ReturnBordItemQuantityResult(1, currentItemId);
					break;
				case "BuyOrder":
					currentAllProductInfoViewModel.DraftItemQuantity = ReturnDraftItemQuantityResult(2, currentItemId);
					break;
				case "preOrder":
					currentAllProductInfoViewModel.OrderItemQuantity = ReturnOrderItemQuantityResult(currentItemId);
					currentAllProductInfoViewModel.DraftItemQuantity = ReturnDraftItemQuantityResult(3, currentItemId);
					break;
				}
				List<WSspSelectLinkedProductsWithPrice_Result> list5 = Enumerable.ToList<WSspSelectLinkedProductsWithPrice_Result>((IEnumerable<WSspSelectLinkedProductsWithPrice_Result>)_dbI.WSspSelectLinkedProductsWithPrice(CS_0024_003C_003E8__locals0.prdId, prdPriceGroupId, currUnitId, CS_0024_003C_003E8__locals0.currLangID, result, result2));
				if (list5 != null && Enumerable.Any<WSspSelectLinkedProductsWithPrice_Result>((IEnumerable<WSspSelectLinkedProductsWithPrice_Result>)list5))
				{
					foreach (WSspSelectLinkedProductsWithPrice_Result item4 in list5)
					{
						bool result4 = false;
						bool.TryParse(item4.LinkedPrdIsSelect.ToString(), out result4);
						if (result4)
						{
							currentAllProductInfoViewModel.LinkedProductIds = currentAllProductInfoViewModel.LinkedProductIds + item4.LinkedProductId + ",";
						}
					}
				}
				if (masterFormName == "SaleOrder" || masterFormName == "preOrder")
				{
					WSspReturnProductValidity_Result wSspReturnProductValidity_Result = Enumerable.FirstOrDefault<WSspReturnProductValidity_Result>((IEnumerable<WSspReturnProductValidity_Result>)_dbI.WSspReturnProductValidity(CS_0024_003C_003E8__locals0.prdId));
					if (wSspReturnProductValidity_Result != null)
					{
						bool flag5 = false;
						int result5 = 0;
						int result6 = 0;
						int result7 = 0;
						if (wSspReturnProductValidity_Result.PrdValidityDay.HasValue)
						{
							int.TryParse(wSspReturnProductValidity_Result.PrdValidityDay.ToString(), out result5);
							flag5 = true;
						}
						if (!string.IsNullOrWhiteSpace(wSspReturnProductValidity_Result.PrdValidityTime))
						{
							string[] array = wSspReturnProductValidity_Result.PrdValidityTime.Split(new char[1] { ':' });
							if (array != null && Enumerable.Any<string>((IEnumerable<string>)array) && array.Length == 2)
							{
								int.TryParse(array[0] ?? "0", out result6);
								int.TryParse(array[1] ?? "0", out result7);
							}
							flag5 = true;
						}
						if (flag5 && currentMasterId > 0 && masterFormName == "SaleOrder")
						{
							WSspSelectOrderById_Result wSspSelectOrderById_Result = Enumerable.FirstOrDefault<WSspSelectOrderById_Result>((IEnumerable<WSspSelectOrderById_Result>)_db.WSspSelectOrderById(currentMasterId, CS_0024_003C_003E8__locals0.currLangID, result));
							if (wSspSelectOrderById_Result != null && wSspSelectOrderById_Result.ordDateTime.HasValue)
							{
								DateTime dateTime = default(DateTime);
								dateTime = wSspSelectOrderById_Result.ordDateTime.Value.AddDays(result5).AddHours(result6).AddMinutes(result7);
								currentAllProductInfoViewModel.ValidityExpireDate = dateTime.ToString("yyyy/MM/dd");
								currentAllProductInfoViewModel.ValidityExpireTime = dateTime.ToString("HH:mm");
							}
						}
						else if (flag5 && currentMasterId > 0 && masterFormName == "preOrder")
						{
							WSspSelectPreOrderWithId_Result wSspSelectPreOrderWithId_Result = Enumerable.FirstOrDefault<WSspSelectPreOrderWithId_Result>((IEnumerable<WSspSelectPreOrderWithId_Result>)_db.WSspSelectPreOrderWithId(currentMasterId, CS_0024_003C_003E8__locals0.currLangID, result));
							if (wSspSelectPreOrderWithId_Result != null && wSspSelectPreOrderWithId_Result.pordDateTime.HasValue)
							{
								DateTime dateTime2 = default(DateTime);
								dateTime2 = wSspSelectPreOrderWithId_Result.pordDateTime.Value.AddDays(result5).AddHours(result6).AddMinutes(result7);
								currentAllProductInfoViewModel.ValidityExpireDate = dateTime2.ToString("yyyy/MM/dd");
								currentAllProductInfoViewModel.ValidityExpireTime = dateTime2.ToString("HH:mm");
							}
						}
					}
				}
				CRMspSelectFoSetting_Result foSetting = CRMIdeal.Classes.Helper.Setting.GetFoSetting();
				bool result8 = false;
				if (foSetting != null)
				{
					bool.TryParse(foSetting.ShpPrdDeliveryScheduleActive.ToString(), out result8);
				}
				if (result8)
				{
					currentAllProductInfoViewModel.DeliveryScheduleTotalCount = DeliverySchedule.GetPrdDeliveryScheduleTotalCount(CS_0024_003C_003E8__locals0.prdId);
				}
				bool result9 = false;
				if (cRMspSelectCrmsysSetting_Result != null)
				{
					bool.TryParse(cRMspSelectCrmsysSetting_Result.FullDiscountPerWithRateInAdd.ToString(), out result9);
				}
				if (result9)
				{
					WSspReturnCmpGroupIIRateFromPrdGroup_Result wSspReturnCmpGroupIIRateFromPrdGroup_Result = Enumerable.FirstOrDefault<WSspReturnCmpGroupIIRateFromPrdGroup_Result>((IEnumerable<WSspReturnCmpGroupIIRateFromPrdGroup_Result>)_dbI.WSspReturnCmpGroupIIRateFromPrdGroup(cmpId, CS_0024_003C_003E8__locals0.prdId));
					if (wSspReturnCmpGroupIIRateFromPrdGroup_Result != null && (wSspReturnCmpGroupIIRateFromPrdGroup_Result.Rate.HasValue || wSspReturnCmpGroupIIRateFromPrdGroup_Result.CmpGroupIIRate.HasValue))
					{
						double result10 = 0.0;
						double result11 = 0.0;
						double.TryParse(wSspReturnCmpGroupIIRateFromPrdGroup_Result.Rate.ToString(), out result10);
						double.TryParse(wSspReturnCmpGroupIIRateFromPrdGroup_Result.CmpGroupIIRate.ToString(), out result11);
						currentAllProductInfoViewModel.CmpGroupIIRate = result10;
						if (currentAllProductInfoViewModel.CmpGroupIIRate == 0.0 && !wSspReturnCmpGroupIIRateFromPrdGroup_Result.Rate.HasValue)
						{
							currentAllProductInfoViewModel.CmpGroupIIRate = result11;
						}
					}
				}
				currentAllProductInfoViewModel.ProductId = CS_0024_003C_003E8__locals0.prdId;
				currentAllProductInfoViewModel.IsFind = true;
				currentAllProductInfoViewModel.Message = "";
			}
			else
			{
				currentAllProductInfoViewModel.IsFind = false;
				currentAllProductInfoViewModel.Message = Messages.ErrorNotFound;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			currentAllProductInfoViewModel.IsFind = false;
			currentAllProductInfoViewModel.Message = Messages.frmErrorMessage + "<br />" + ex.Message;
		}
		JsonResult jsonResult = Json(currentAllProductInfoViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public decimal ReturnSumLinkedProductPrice(int prdId, int prdPriceGroupId, int currUnitId = 0, string linkedPrdIds = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		decimal result2 = default(decimal);
		try
		{
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			decimal.TryParse(Enumerable.FirstOrDefault<decimal?>((IEnumerable<decimal?>)_db.WSspReturnSumLinkedProductPrice(prdId, prdPriceGroupId, currUnitId, linkedPrdIds, result3)).ToString(), out result2);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result2;
	}

	public string CheckItemTaxIndex(string masterForm, int masterId, int currentId, decimal? taxIndex = null)
	{
		string result = "1";
		try
		{
			switch (masterForm.ToLower())
			{
			case "preOrder":
			case "PreOrder":
			case "preorder":
			{
				WSspCheckPreOrderItemTaxIndex_Result wSspCheckPreOrderItemTaxIndex_Result = Enumerable.FirstOrDefault<WSspCheckPreOrderItemTaxIndex_Result>((IEnumerable<WSspCheckPreOrderItemTaxIndex_Result>)_dbII.WSspCheckPreOrderItemTaxIndex(masterId, currentId));
				if (wSspCheckPreOrderItemTaxIndex_Result != null)
				{
					decimal result3 = default(decimal);
					decimal.TryParse(wSspCheckPreOrderItemTaxIndex_Result.pordITaxIndex.ToString(), out result3);
					result = ((!(result3 == taxIndex.GetValueOrDefault())) ? "0" : "1");
				}
				break;
			}
			case "SaleOrder":
			case "saleorder":
			{
				WSspCheckOrderItemTaxIndex_Result wSspCheckOrderItemTaxIndex_Result = Enumerable.FirstOrDefault<WSspCheckOrderItemTaxIndex_Result>((IEnumerable<WSspCheckOrderItemTaxIndex_Result>)_dbII.WSspCheckOrderItemTaxIndex(masterId, currentId));
				if (wSspCheckOrderItemTaxIndex_Result != null)
				{
					decimal result2 = default(decimal);
					decimal.TryParse(wSspCheckOrderItemTaxIndex_Result.ordITaxIndex.ToString(), out result2);
					result = ((!(result2 == taxIndex.GetValueOrDefault())) ? "0" : "1");
				}
				break;
			}
			default:
				result = "0";
				break;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = "-1";
		}
		return result;
	}

	[HttpPost]
	public string GetSaleCentersWithPrdIds(string ids = "")
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
			List<WSspSelectProductsWithIds_Result> list = Enumerable.ToList<WSspSelectProductsWithIds_Result>((IEnumerable<WSspSelectProductsWithIds_Result>)_dbI.WSspSelectProductsWithIds(ids, ",", lCID, result2));
			if (list != null)
			{
				string text = "";
				foreach (WSspSelectProductsWithIds_Result item in list)
				{
					if (!string.IsNullOrWhiteSpace(item.PrdSaleCenterIds))
					{
						if (text != "")
						{
							text += ",";
						}
						text += item.PrdSaleCenterIds;
					}
				}
				List<WSspSelectSaleCentersWithIds_Result> list2 = Enumerable.ToList<WSspSelectSaleCentersWithIds_Result>((IEnumerable<WSspSelectSaleCentersWithIds_Result>)_dbII.WSspSelectSaleCentersWithIds(text, lCID, result2));
				if (list2 != null)
				{
					result = JsonConvert.SerializeObject(list2);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[HttpPost]
	public string GetSaleCentersWithIds(string ids = "")
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
			List<WSspSelectSaleCentersWithIds_Result> list = Enumerable.ToList<WSspSelectSaleCentersWithIds_Result>((IEnumerable<WSspSelectSaleCentersWithIds_Result>)_dbII.WSspSelectSaleCentersWithIds(ids, lCID, result2));
			if (list != null)
			{
				foreach (WSspSelectSaleCentersWithIds_Result item in list)
				{
					item.FirstRegisterDatePersian = item.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm");
					item.RegisterDatePersian = item.RegisterDate.ToString("yyyy/MM/dd HH:mm");
				}
				result = JsonConvert.SerializeObject(list);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[HttpPost]
	public string GetOrderItemsSaleCenterDelivery(string dt = "", int orderId = 0)
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
			if (!string.IsNullOrWhiteSpace(dt))
			{
				dt = HttpUtility.UrlDecode(dt);
				DateTime dateTime = default(DateTime);
				string text = "";
				try
				{
					text = PersianDate.GetFormatetdDate(dt.Replace("/", ""));
					switch (lCID)
					{
					case 1065:
						dateTime = DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
						dt = dateTime.ToString("yyyyMMdd");
						break;
					case 1025:
						dateTime = DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
						dt = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					default:
						dateTime = DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
						dt = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
					base.ViewBag.Error = Messages.WrongDateTime;
					return "";
				}
				List<WSspSelectOrderItemsSaleCenterDelivery_Result> list = Enumerable.ToList<WSspSelectOrderItemsSaleCenterDelivery_Result>((IEnumerable<WSspSelectOrderItemsSaleCenterDelivery_Result>)_dbII.WSspSelectOrderItemsSaleCenterDelivery(dateTime, orderId, lCID, result2));
				if (list != null)
				{
					foreach (WSspSelectOrderItemsSaleCenterDelivery_Result item in list)
					{
						item.RegisterDatePersian = item.RegisterDate.ToString("yyyy/MM/dd");
						item.FirstRegisterDatePersian = item.FirstRegisterDate?.ToString("yyyy/MM/dd");
					}
					result = JsonConvert.SerializeObject(list);
				}
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return result;
	}

	[HttpPost]
	public string GetAllSpecifications()
	{
		List<WSspSelectProductSpecificationFields_Result> list = new List<WSspSelectProductSpecificationFields_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int num = 0;
			if (num == 0)
			{
				num = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId.GetValueOrDefault() : 0);
			}
			List<WSspSelectProductSpecificationFields_Result> list2 = Enumerable.ToList<WSspSelectProductSpecificationFields_Result>((IEnumerable<WSspSelectProductSpecificationFields_Result>)_dbII.WSspSelectProductSpecificationFields(num, lCID, result));
			if (list2 != null)
			{
				list.AddRange(list2);
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return JsonConvert.SerializeObject(list);
	}

	[LoginAuthorize]
	public ActionResult PrdReserveStock(int position, int prdId, int whId, double fcr, double fcrI, string tracing, int currHeadId = 0, int currItemId = 0)
	{
		string text = "frmAddProduct";
		string actionName = "actGoToReserveStock";
		try
		{
			switch (position)
			{
			case 1:
				text = "frmPreOrderItemDataEntry";
				break;
			case 2:
				text = "frmOrderItemDataEntry";
				currHeadId = 0;
				currItemId = 0;
				break;
			case 3:
				text = "frmBuyOrderItemDataEntry";
				currHeadId = 0;
				currItemId = 0;
				break;
			case 4:
				text = "frmStockSupplyItemDataEntry";
				currHeadId = 0;
				currItemId = 0;
				break;
			default:
				text = "frmAddProduct";
				currHeadId = 0;
				currItemId = 0;
				break;
			}
			if (!UserLogin.IsUserAccess(text, actionName, UserLogin.CurrentUser))
			{
				return RedirectToAction("Login", "Account", (object)new
				{
					area = "",
					d = DateTime.Now
				});
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PrdId = prdId;
		base.ViewBag.WhId = whId;
		base.ViewBag.Fcr = fcr;
		base.ViewBag.FcrI = fcrI;
		base.ViewBag.Tracing = tracing;
		base.ViewBag.CurrHeadId = currHeadId;
		base.ViewBag.CurrItemId = currItemId;
		return View();
	}

	[AjaxOnly]
	public JsonResult GetPrdReserveStock(int prdId, int whId, double fcr, double fcrI, string tracing, int currHeadId = 0, int currItemId = 0, long lastRowNumber = 0L, int topCount = 500)
	{
		List<WSspSelectValidPordProduct_Result> list = new List<WSspSelectValidPordProduct_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			int result2 = 0;
			int value = 0;
			if (currentUser != null)
			{
				int.TryParse(currentUser.UserLastCId.ToString(), out result2);
				value = currentUser.UserId;
			}
			tracing = ConvertCharacter.DecodeTracing(tracing);
			list = Enumerable.ToList<WSspSelectValidPordProduct_Result>((IEnumerable<WSspSelectValidPordProduct_Result>)_dbIII.WSspSelectValidPordProduct(prdId, fcr, fcrI, whId, tracing, currHeadId, now, value, result2, topCount, lastRowNumber, lCID, result));
			if (list == null)
			{
				list = new List<WSspSelectValidPordProduct_Result>();
			}
			if (list != null && Enumerable.Any<WSspSelectValidPordProduct_Result>((IEnumerable<WSspSelectValidPordProduct_Result>)list))
			{
				foreach (WSspSelectValidPordProduct_Result item in list)
				{
					item.pordDate = (item.pordDateTime.HasValue ? item.pordDateTime.Value.ToString("yyyy/MM/dd") : "");
					item.pordExpireDate = (item.pordExpireDateTime.HasValue ? item.pordExpireDateTime.Value.ToString("yyyy/MM/dd") : "");
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

	[LoginAuthorize]
	public ActionResult PrdSoldStock(int position, int prdId, int whId, double fcr, double fcrI, string tracing, int currHeadId = 0, int currItemId = 0)
	{
		string text = "frmAddProduct";
		string actionName = "actGoToSoldStock";
		try
		{
			switch (position)
			{
			case 1:
				text = "frmPreOrderItemDataEntry";
				currHeadId = 0;
				currItemId = 0;
				break;
			case 2:
				text = "frmOrderItemDataEntry";
				break;
			case 3:
				text = "frmBuyOrderItemDataEntry";
				currHeadId = 0;
				currItemId = 0;
				break;
			case 4:
				text = "frmStockSupplyItemDataEntry";
				currHeadId = 0;
				currItemId = 0;
				break;
			default:
				text = "frmAddProduct";
				currHeadId = 0;
				currItemId = 0;
				break;
			}
			if (!UserLogin.IsUserAccess(text, actionName, UserLogin.CurrentUser))
			{
				return RedirectToAction("Login", "Account", (object)new
				{
					area = "",
					d = DateTime.Now
				});
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PrdId = prdId;
		base.ViewBag.WhId = whId;
		base.ViewBag.Fcr = fcr;
		base.ViewBag.FcrI = fcrI;
		base.ViewBag.Tracing = tracing;
		base.ViewBag.CurrHeadId = currHeadId;
		base.ViewBag.CurrItemId = currItemId;
		return View();
	}

	[AjaxOnly]
	public JsonResult GetPrdSoldStock(int prdId, int whId, double fcr, double fcrI, string tracing, int currHeadId = 0, int currItemId = 0, long lastRowNumber = 0L, int topCount = 500)
	{
		List<WSspSelectSoldOrdProduct_Result> list = new List<WSspSelectSoldOrdProduct_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			_ = DateTime.Now;
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			int result2 = 0;
			int value = 0;
			if (currentUser != null)
			{
				int.TryParse(currentUser.UserLastCId.ToString(), out result2);
				value = currentUser.UserId;
			}
			tracing = ConvertCharacter.DecodeTracing(tracing);
			list = Enumerable.ToList<WSspSelectSoldOrdProduct_Result>((IEnumerable<WSspSelectSoldOrdProduct_Result>)_dbIII.WSspSelectSoldOrdProduct(prdId, fcr, fcrI, whId, tracing, currItemId, value, result2, topCount, lastRowNumber, lCID, result));
			if (list == null)
			{
				list = new List<WSspSelectSoldOrdProduct_Result>();
			}
			if (list != null && Enumerable.Any<WSspSelectSoldOrdProduct_Result>((IEnumerable<WSspSelectSoldOrdProduct_Result>)list))
			{
				foreach (WSspSelectSoldOrdProduct_Result item in list)
				{
					item.ordDate = (item.ordDateTime.HasValue ? item.ordDateTime.Value.ToString("yyyy/MM/dd") : "");
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

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		_dbI.Dispose();
		_dbLink.Dispose();
		_dbII.Dispose();
		_dbIII.Dispose();
		base.Dispose(disposing);
	}

	public ActionResult AddProductNew(string masterForm, string mode, int masterId = 0, int detailId = 0, int prdId = 0, int cmpId = 0, double taxInDoc = 0.0)
	{
		SearchProductsViewModel searchProductsViewModel = new SearchProductsViewModel();
		base.ViewBag.prdId = prdId;
		base.ViewBag.CmpId = cmpId;
		mode = ((mode == "1" && mode == "Cost") ? "Cost" : "Price");
		base.ViewBag.Mode = mode;
		base.ViewBag.MasterId = masterId;
		base.ViewBag.MasterForm = masterForm;
		base.ViewBag.DetailId = detailId;
		base.ViewBag.HaveTaxInDoc = taxInDoc;
		try
		{
			DbSet<WSPreOrderDefaultSetting> wSPreOrderDefaultSetting = _dbTbl.WSPreOrderDefaultSetting;
			ParameterExpression val = Expression.Parameter(typeof(WSPreOrderDefaultSetting), "m");
			WSPreOrderDefaultSetting wSPreOrderDefaultSetting2 = Queryable.FirstOrDefault<WSPreOrderDefaultSetting>((IQueryable<WSPreOrderDefaultSetting>)(object)Queryable.OrderByDescending<WSPreOrderDefaultSetting, int>((IQueryable<WSPreOrderDefaultSetting>)wSPreOrderDefaultSetting, Expression.Lambda<Func<WSPreOrderDefaultSetting, int>>((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
			base.ViewBag.DefTaxIndex = ((wSPreOrderDefaultSetting2 != null && wSPreOrderDefaultSetting2.TaxIndex.HasValue) ? wSPreOrderDefaultSetting2.TaxIndex : new decimal?(default(decimal)));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.MyModel = searchProductsViewModel;
		return View();
	}

	public List<TreeViewItemModel> GetTree1(int mode)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<TreeViewItemModel> list = new List<TreeViewItemModel>();
		try
		{
			List<WSspProductsTree_Result> list2 = Enumerable.ToList<WSspProductsTree_Result>((IEnumerable<WSspProductsTree_Result>)_db.WSspProductsTree(mode, lCID, result, 0, 0, 0, 0));
			foreach (WSspProductsTree_Result item in Enumerable.ToList<WSspProductsTree_Result>(Enumerable.Where<WSspProductsTree_Result>((IEnumerable<WSspProductsTree_Result>)list2, (Func<WSspProductsTree_Result, bool>)((WSspProductsTree_Result c) => c.ParentId == 0))))
			{
				TreeViewItemModel treeViewItemModel = new TreeViewItemModel();
				treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item.FId + "|" + item.SId + "|" + item.PrdId));
				treeViewItemModel.Id = item.FId + "|" + item.SId + "|" + item.PrdId;
				treeViewItemModel.Text = item.KEYName;
				treeViewItemModel.ImageUrl = "";
				List<WSspProductsTree_Result> list3 = Enumerable.ToList<WSspProductsTree_Result>(Enumerable.Where<WSspProductsTree_Result>((IEnumerable<WSspProductsTree_Result>)list2, (Func<WSspProductsTree_Result, bool>)((WSspProductsTree_Result c) => c.ParentId == item.FId)));
				List<TreeViewItemModel> list4 = new List<TreeViewItemModel>();
				foreach (WSspProductsTree_Result itemIn in list3)
				{
					TreeViewItemModel treeViewItemModel2 = new TreeViewItemModel();
					treeViewItemModel2.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", itemIn.FId + "|" + itemIn.SId + "|" + itemIn.PrdId));
					treeViewItemModel2.Id = itemIn.FId + "|" + itemIn.SId + "|" + itemIn.PrdId;
					treeViewItemModel2.Text = itemIn.KEYName;
					treeViewItemModel2.ImageUrl = "";
					int.Parse("100" + itemIn.SId);
					List<WSspProductsTree_Result> list5 = Enumerable.ToList<WSspProductsTree_Result>(Enumerable.Where<WSspProductsTree_Result>((IEnumerable<WSspProductsTree_Result>)list2, (Func<WSspProductsTree_Result, bool>)((WSspProductsTree_Result c) => c.ParentId == itemIn.KeyId && c.FId == 0)));
					List<TreeViewItemModel> list6 = new List<TreeViewItemModel>();
					foreach (WSspProductsTree_Result item2 in list5)
					{
						TreeViewItemModel treeViewItemModel3 = new TreeViewItemModel();
						treeViewItemModel3.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item2.FId + "|" + item2.SId + "|" + item2.PrdId));
						treeViewItemModel3.Id = item2.FId + "|" + item2.SId + "|" + item2.PrdId;
						treeViewItemModel3.Text = item2.KEYName;
						treeViewItemModel3.ImageUrl = "";
						treeViewItemModel3.Items = null;
						list6.Add(treeViewItemModel3);
					}
					treeViewItemModel2.Items = new List<TreeViewItemModel>(list6);
					list4.Add(treeViewItemModel2);
				}
				treeViewItemModel.Items = new List<TreeViewItemModel>(list4);
				list.Add(treeViewItemModel);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[AjaxOnly]
	[HttpPost]
	public JsonResult GetTree(string mode)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<TreeViewItemModel> list = new List<TreeViewItemModel>();
		int num = 0;
		num = ((mode == "Cost" || mode == "1") ? 1 : 2);
		try
		{
			List<WSspProductsTree_Result> list2 = Enumerable.ToList<WSspProductsTree_Result>((IEnumerable<WSspProductsTree_Result>)_db.WSspProductsTree(num, lCID, result, 0, -1, 0, 0));
			foreach (WSspProductsTree_Result item in Enumerable.ToList<WSspProductsTree_Result>(Enumerable.Where<WSspProductsTree_Result>((IEnumerable<WSspProductsTree_Result>)list2, (Func<WSspProductsTree_Result, bool>)((WSspProductsTree_Result c) => c.ParentId == 0))))
			{
				TreeViewItemModel treeViewItemModel = new TreeViewItemModel();
				treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item.FId + "|" + item.SId + "|" + item.PrdId));
				treeViewItemModel.Id = item.FId + "|" + item.SId + "|" + item.PrdId;
				treeViewItemModel.Text = item.KEYName;
				treeViewItemModel.ImageUrl = "";
				List<WSspProductsTree_Result> list3 = Enumerable.ToList<WSspProductsTree_Result>(Enumerable.Where<WSspProductsTree_Result>((IEnumerable<WSspProductsTree_Result>)list2, (Func<WSspProductsTree_Result, bool>)((WSspProductsTree_Result c) => c.ParentId == item.FId)));
				List<TreeViewItemModel> list4 = new List<TreeViewItemModel>();
				foreach (WSspProductsTree_Result itemIn in list3)
				{
					TreeViewItemModel treeViewItemModel2 = new TreeViewItemModel();
					treeViewItemModel2.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", itemIn.FId + "|" + itemIn.SId + "|" + itemIn.PrdId));
					treeViewItemModel2.Id = itemIn.FId + "|" + itemIn.SId + "|" + itemIn.PrdId;
					treeViewItemModel2.Text = itemIn.KEYName;
					treeViewItemModel2.ImageUrl = "";
					int.Parse("100" + itemIn.SId);
					List<WSspProductsTree_Result> list5 = Enumerable.ToList<WSspProductsTree_Result>(Enumerable.Where<WSspProductsTree_Result>((IEnumerable<WSspProductsTree_Result>)list2, (Func<WSspProductsTree_Result, bool>)((WSspProductsTree_Result c) => c.ParentId == itemIn.KeyId && c.FId == 0)));
					List<TreeViewItemModel> list6 = new List<TreeViewItemModel>();
					foreach (WSspProductsTree_Result item2 in list5)
					{
						TreeViewItemModel treeViewItemModel3 = new TreeViewItemModel();
						treeViewItemModel3.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item2.FId + "|" + item2.SId + "|" + item2.PrdId));
						treeViewItemModel3.Id = item2.FId + "|" + item2.SId + "|" + item2.PrdId;
						treeViewItemModel3.Text = item2.KEYName;
						treeViewItemModel3.ImageUrl = "";
						treeViewItemModel3.Items = null;
						list6.Add(treeViewItemModel3);
					}
					treeViewItemModel2.Items = new List<TreeViewItemModel>(list6);
					list4.Add(treeViewItemModel2);
				}
				treeViewItemModel.Items = new List<TreeViewItemModel>(list4);
				list.Add(treeViewItemModel);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[LoginAuthorize]
	public List<SelectListItem> SelectProductFirstGroup(int selectedId = 0)
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
			if (list2 != null && list2.Count > 0)
			{
				list.AddRange(Enumerable.Select<WSspSelectProductFirstGroup_Result, SelectListItem>((IEnumerable<WSspSelectProductFirstGroup_Result>)list2, (Func<WSspSelectProductFirstGroup_Result, SelectListItem>)((WSspSelectProductFirstGroup_Result x) => new SelectListItem
				{
					Text = x.FGName,
					Value = x.PrdFirstGroupID.ToString(),
					Selected = (x.PrdFirstGroupID == selectedId)
				})));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[HttpPost]
	public string SelectProductFirstGroupJs(int selectedId = 0)
	{
		return JsonConvert.SerializeObject(SelectProductFirstGroup(selectedId));
	}

	[LoginAuthorize]
	public List<SelectListItem> SelectProductSecondGroup(int fgId = 0, int selectedId = 0)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			if (fgId > 0)
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				List<WSspSelectProductSecondGroup_Result> list2 = Enumerable.ToList<WSspSelectProductSecondGroup_Result>((IEnumerable<WSspSelectProductSecondGroup_Result>)_db.WSspSelectProductSecondGroup(fgId, lCID, result));
				if (list2 != null && list2.Count > 0)
				{
					list.AddRange(Enumerable.Select<WSspSelectProductSecondGroup_Result, SelectListItem>((IEnumerable<WSspSelectProductSecondGroup_Result>)list2, (Func<WSspSelectProductSecondGroup_Result, SelectListItem>)((WSspSelectProductSecondGroup_Result x) => new SelectListItem
					{
						Text = x.SGName,
						Value = x.PrdSecondGroupID.ToString(),
						Selected = (x.PrdSecondGroupID == selectedId)
					})));
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[LoginAuthorize]
	[HttpPost]
	public string SelectProductSecondGroupJs(int fgId = 0, int selectedId = 0)
	{
		return JsonConvert.SerializeObject(SelectProductSecondGroup(fgId, selectedId));
	}

	[LoginAuthorize]
	public ActionResult SelectProductMulti(string mode = "", string selectedPrdIds = "", string selectedSep = ",", int fgId = 0, int sgId = 0, bool showScoreRuleItems = false, int? selectionType = null, bool? srchEmptPrdName = null)
	{
		base.ViewBag.Mode = mode;
		base.ViewBag.SelectedPrdIds = selectedPrdIds;
		base.ViewBag.SelectedSeperator = selectedSep;
		base.ViewBag.FGId = fgId;
		base.ViewBag.SGId = sgId;
		base.ViewBag.SearchEmptyPrdName = srchEmptPrdName;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (!string.IsNullOrWhiteSpace(selectedPrdIds))
			{
				List<WSspSelectProductsWithIds_Result> list = Enumerable.ToList<WSspSelectProductsWithIds_Result>((IEnumerable<WSspSelectProductsWithIds_Result>)_dbI.WSspSelectProductsWithIds(selectedPrdIds, selectedSep, lCID, result));
				if (list != null)
				{
					base.ViewBag.SelectedPrdsListJs = JsonConvert.SerializeObject(list);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.FirstGroupList = SelectProductFirstGroup(fgId);
		base.ViewBag.SecondGroupList = SelectProductSecondGroup(fgId, sgId);
		base.ViewBag.ShowScoreRuleItems = showScoreRuleItems;
		base.ViewBag.SelectionType = selectionType;
		return View();
	}

	public List<WSspSearchProducts_Result> SearchProducts(int fgId = 0, int sgId = 0, string val = "", string barcode = "", int prdId = 0, int showMode = 2, int prdKind = 0, int prdInActive = -1, int companyId = 0, int projectId = 0, string prdManufacturerName = "", bool? srchEmptPrdName = null)
	{
		List<WSspSearchProducts_Result> result = new List<WSspSearchProducts_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (fgId > 0 || sgId > 0 || !string.IsNullOrEmpty(val) || !string.IsNullOrWhiteSpace(barcode) || srchEmptPrdName.GetValueOrDefault())
			{
				result = Enumerable.ToList<WSspSearchProducts_Result>(Enumerable.Take<WSspSearchProducts_Result>((IEnumerable<WSspSearchProducts_Result>)_db.WSspSearchProducts(fgId, sgId, barcode, val, prdId, showMode, lCID, result2, prdKind, prdInActive, companyId, projectId, prdManufacturerName, null), 300));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public string SearchProductsJs(int fgId = 0, int sgId = 0, string val = "", string barcode = "", string prdManufacturerName = "")
	{
		return JsonConvert.SerializeObject(SearchProducts(fgId, sgId, val, barcode, 0, 2, 0, -1, 0, 0, prdManufacturerName));
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetPrdGroupsTree()
	{
		return JsonConvert.SerializeObject(Product.GetPrdGroupsTree());
	}
}
