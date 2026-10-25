using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.Objects;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
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
using CRMIdeal.Cache;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Cache.User;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Accounts.Controllers;

public class AccountsController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass11_0
	{
		public int uId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass121_0
	{
		public int userId;

		public int currLangID;

		internal bool _003CUserMoreInfo_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CUserMoreInfo_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CUserMoreInfo_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CUserMoreInfo_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CUserMoreInfo_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CUserMoreInfo_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CUserMoreInfo_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CUserMoreInfo_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CUserMoreInfo_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CUserMoreInfo_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CUserMoreInfo_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CUserMoreInfo_003Eb__18(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CUserMoreInfo_003Eb__19(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CUserMoreInfo_003Eb__20(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CUserMoreInfo_003Eb__21(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass122_0
	{
		public UserMoreInfoLanguageViewModel vm;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__9;

		internal bool _003CUserMoreInfo_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CUserMoreInfo_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CUserMoreInfo_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CUserMoreInfo_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CUserMoreInfo_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CUserMoreInfo_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CUserMoreInfo_003Eb__9(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass122_1
	{
		public Users model;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass122_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass122_1 CS_0024_003C_003E8__locals1;

		internal bool _003CUserMoreInfo_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CUserMoreInfo_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CUserMoreInfo_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CUserMoreInfo_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CUserMoreInfo_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CUserMoreInfo_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CUserMoreInfo_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CUserMoreInfo_003Eb__18(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CUserMoreInfo_003Eb__19(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CUserMoreInfo_003Eb__20(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CUserMoreInfo_003Eb__21(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CUserMoreInfo_003Eb__22(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass125_0
	{
		public UserPicturesViewModel vm;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass129_0
	{
		public int fileId;

		public int currLangID;

		internal bool _003CFileInsertEdit_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CFileInsertEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CFileInsertEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CFileInsertEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CFileInsertEdit_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CFileInsertEdit_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass130_0
	{
		public CrmFilesDirectoryLanguageViewModel model;

		public int defLangID;

		public Func<CommonMultiLanguageViewModel, bool> _003C_003E9__10;

		public Func<CommonMultiLanguageViewModel, bool> _003C_003E9__11;

		public Func<CommonMultiLanguageViewModel, bool> _003C_003E9__12;

		public Func<CommonMultiLanguageViewModel, bool> _003C_003E9__13;

		public Func<Languages, bool> _003C_003E9__14;

		public Func<Languages, bool> _003C_003E9__19;

		internal bool _003CFileInsertEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CFileInsertEdit_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CFileInsertEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CFileInsertEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CFileInsertEdit_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CFileInsertEdit_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CFileInsertEdit_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CFileInsertEdit_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CFileInsertEdit_003Eb__14(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CFileInsertEdit_003Eb__19(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass130_1
	{
		public CrmFilesDirectory fileDir;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass130_3
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass130_1 CS_0024_003C_003E8__locals1;

		internal bool _003CFileInsertEdit_003Eb__21(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CFileInsertEdit_003Eb__22(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CFileInsertEdit_003Eb__23(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CFileInsertEdit_003Eb__24(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CFileInsertEdit_003Eb__25(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CFileInsertEdit_003Eb__26(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CFileInsertEdit_003Eb__27(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CFileInsertEdit_003Eb__28(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass136_0
	{
		public int userId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass138_0
	{
		public int emailUsersInfoId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass139_0
	{
		public int emailUsersInfoId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass146_0
	{
		public int id;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass147_0
	{
		public EmailUsersInfoViewModel vm;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass150_0
	{
		public int euId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass163_0
	{
		public int bankAccId;

		public int currLangID;

		internal bool _003CBankingAccountInsertEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CBankingAccountInsertEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CBankingAccountInsertEdit_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CBankingAccountInsertEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CBankingAccountInsertEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CBankingAccountInsertEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass164_0
	{
		public CrmBankingAccountsLanguageViewModel model;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__5;

		public Func<Languages, bool> _003C_003E9__15;

		internal bool _003CBankingAccountInsertEdit_003Eb__1(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CBankingAccountInsertEdit_003Eb__2(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CBankingAccountInsertEdit_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CBankingAccountInsertEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CBankingAccountInsertEdit_003Eb__5(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CBankingAccountInsertEdit_003Eb__15(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass164_1
	{
		public CrmBankingAccounts bankAcc;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass164_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass164_1 CS_0024_003C_003E8__locals1;

		internal bool _003CBankingAccountInsertEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CBankingAccountInsertEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CBankingAccountInsertEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CBankingAccountInsertEdit_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CBankingAccountInsertEdit_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CBankingAccountInsertEdit_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CBankingAccountInsertEdit_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CBankingAccountInsertEdit_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass25_0
	{
		public int uId;

		public int currLangID;

		public int userLastCId;

		internal bool _003CUserDefineEdit_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CUserDefineEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CUserDefineEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CUserDefineEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CUserDefineEdit_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CUserDefineEdit_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CUserDefineEdit_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CUserDefineEdit_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CUserDefineEdit_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CUserDefineEdit_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CUserDefineEdit_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CUserDefineEdit_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CUserDefineEdit_003Eb__18(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CUserDefineEdit_003Eb__19(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CUserDefineEdit_003Eb__20(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CUserDefineEdit_003Eb__21(UserDepartmentInfoViewModel m)
		{
			return m.CId.GetValueOrDefault() == userLastCId;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass26_1
	{
		public Users uSer;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass26_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass26_1 CS_0024_003C_003E8__locals1;

		internal bool _003CUserDefineEdit_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CUserDefineEdit_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CUserDefineEdit_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CUserDefineEdit_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CUserDefineEdit_003Eb__18(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CUserDefineEdit_003Eb__19(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CUserDefineEdit_003Eb__20(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CUserDefineEdit_003Eb__21(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CUserDefineEdit_003Eb__22(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CUserDefineEdit_003Eb__23(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CUserDefineEdit_003Eb__24(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CUserDefineEdit_003Eb__25(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CUserDefineEdit_003Eb__26(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CUserDefineEdit_003Eb__27(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CUserDefineEdit_003Eb__28(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CUserDefineEdit_003Eb__29(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CUserDefineEdit_003Eb__30(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CUserDefineEdit_003Eb__31(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CUserDefineEdit_003Eb__32(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CUserDefineEdit_003Eb__33(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass37_0
	{
		public int uId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass39_0
	{
		public UsersPermissionLanguageViewModel model;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__5;

		internal bool _003CUserRollDefineInsert_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CUserRollDefineInsert_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CUserRollDefineInsert_003Eb__5(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass42_0
	{
		public int upId;

		public int currLangID;

		internal bool _003CUserRollDefineEdit_003Eb__2(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CUserRollDefineEdit_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CUserRollDefineEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass43_0
	{
		public UsersPermissionLanguageViewModel model;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__5;

		internal bool _003CUserRollDefineEdit_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CUserRollDefineEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CUserRollDefineEdit_003Eb__5(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass43_1
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass43_0 CS_0024_003C_003E8__locals1;

		internal bool _003CUserRollDefineEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CUserRollDefineEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CUserRollDefineEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CUserRollDefineEdit_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass50_0
	{
		public int rId;

		public int currLangID;

		internal bool _003CRollsDefineEdit_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CRollsDefineEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CRollsDefineEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CRollsDefineEdit_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CRollsDefineEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CRollsDefineEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass51_0
	{
		public int defLangID;

		public CrmsysRollsViewModel rollVM;

		public Func<Languages, bool> _003C_003E9__6;

		internal bool _003CRollsDefineEdit_003Eb__2(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CRollsDefineEdit_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CRollsDefineEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CRollsDefineEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CRollsDefineEdit_003Eb__6(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass51_1
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass51_0 CS_0024_003C_003E8__locals1;

		internal bool _003CRollsDefineEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CRollsDefineEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CRollsDefineEdit_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CRollsDefineEdit_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CRollsDefineEdit_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CRollsDefineEdit_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CRollsDefineEdit_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CRollsDefineEdit_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass52_0
	{
		public int rId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public int uId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_0
	{
		public UserSignatureViewModel UsignVM;
	}

	private CRMSpEntities db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private CRMSpIEntities dbI = new CRMSpIEntities();

	private CRMSpIIEntities _dbII = new CRMSpIIEntities();

	public ActionResult Index()
	{
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actDefineUsers")]
	public ActionResult UserDefine(int uId = 0)
	{
		Users model = new Users();
		base.ViewBag.UserId = uId;
		return View(model);
	}

	public ActionResult _PartialUserInfo(int uId, string kind)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		UsersViewModel usersViewModel = new UsersViewModel();
		CRMspSelectUsers_Result cRMspSelectUsers_Result = null;
		int result2 = 0;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
		}
		if (uId == 0)
		{
			cRMspSelectUsers_Result = Enumerable.FirstOrDefault<CRMspSelectUsers_Result>(Enumerable.Take<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)Enumerable.OrderByDescending<CRMspSelectUsers_Result, int>((IEnumerable<CRMspSelectUsers_Result>)Enumerable.ToList<CRMspSelectUsers_Result>(Enumerable.Where<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)db.CRMspSelectUsers(lCID, result, result2), (Func<CRMspSelectUsers_Result, bool>)((CRMspSelectUsers_Result m) => m.UserId > 0))), (Func<CRMspSelectUsers_Result, int>)((CRMspSelectUsers_Result c) => c.UserId)), 1));
		}
		else
		{
			switch (kind)
			{
			case "next":
				cRMspSelectUsers_Result = Enumerable.FirstOrDefault<CRMspSelectUsers_Result>(Enumerable.Take<CRMspSelectUsers_Result>(Enumerable.Where<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)Enumerable.ToList<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)db.CRMspSelectUsers(lCID, result, result2)), (Func<CRMspSelectUsers_Result, bool>)((CRMspSelectUsers_Result c) => c.UserId > uId && c.UserId > 0)), 1));
				if (cRMspSelectUsers_Result == null)
				{
					cRMspSelectUsers_Result = Enumerable.FirstOrDefault<CRMspSelectUsers_Result>(Enumerable.Take<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)Enumerable.OrderByDescending<CRMspSelectUsers_Result, int>((IEnumerable<CRMspSelectUsers_Result>)Enumerable.ToList<CRMspSelectUsers_Result>(Enumerable.Where<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)db.CRMspSelectUsers(lCID, result, result2), (Func<CRMspSelectUsers_Result, bool>)((CRMspSelectUsers_Result m) => m.UserId > 0))), (Func<CRMspSelectUsers_Result, int>)((CRMspSelectUsers_Result c) => c.UserId)), 1));
				}
				break;
			case "prev":
				cRMspSelectUsers_Result = Enumerable.FirstOrDefault<CRMspSelectUsers_Result>(Enumerable.Take<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)Enumerable.OrderByDescending<CRMspSelectUsers_Result, int>(Enumerable.Where<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)Enumerable.ToList<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)db.CRMspSelectUsers(lCID, result, result2)), (Func<CRMspSelectUsers_Result, bool>)((CRMspSelectUsers_Result c) => c.UserId < uId && c.UserId > 0)), (Func<CRMspSelectUsers_Result, int>)((CRMspSelectUsers_Result c) => c.UserId)), 1));
				if (cRMspSelectUsers_Result == null)
				{
					cRMspSelectUsers_Result = Enumerable.FirstOrDefault<CRMspSelectUsers_Result>(Enumerable.Take<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)Enumerable.ToList<CRMspSelectUsers_Result>(Enumerable.Where<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)db.CRMspSelectUsers(lCID, result, result2), (Func<CRMspSelectUsers_Result, bool>)((CRMspSelectUsers_Result m) => m.UserId > 0))), 1));
				}
				break;
			case "first":
			{
				CRMspSelectUsers_Result cRMspSelectUsers_Result3 = Enumerable.FirstOrDefault<CRMspSelectUsers_Result>(Enumerable.Take<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)Enumerable.ToList<CRMspSelectUsers_Result>(Enumerable.Where<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)db.CRMspSelectUsers(lCID, result, result2), (Func<CRMspSelectUsers_Result, bool>)((CRMspSelectUsers_Result m) => m.UserId > 0))), 1));
				cRMspSelectUsers_Result = ((uId != cRMspSelectUsers_Result3.UserId) ? Enumerable.FirstOrDefault<CRMspSelectUsers_Result>(Enumerable.Take<CRMspSelectUsers_Result>(Enumerable.Where<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)Enumerable.ToList<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)db.CRMspSelectUsers(lCID, result, result2)), (Func<CRMspSelectUsers_Result, bool>)((CRMspSelectUsers_Result c) => c.UserId < uId && c.UserId > 0)), 1)) : Enumerable.FirstOrDefault<CRMspSelectUsers_Result>(Enumerable.Take<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)Enumerable.ToList<CRMspSelectUsers_Result>(Enumerable.Where<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)db.CRMspSelectUsers(lCID, result, result2), (Func<CRMspSelectUsers_Result, bool>)((CRMspSelectUsers_Result m) => m.UserId > 0))), 1)));
				break;
			}
			case "last":
			{
				CRMspSelectUsers_Result cRMspSelectUsers_Result2 = Enumerable.FirstOrDefault<CRMspSelectUsers_Result>(Enumerable.Take<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)Enumerable.OrderByDescending<CRMspSelectUsers_Result, int>((IEnumerable<CRMspSelectUsers_Result>)Enumerable.ToList<CRMspSelectUsers_Result>(Enumerable.Where<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)db.CRMspSelectUsers(lCID, result, result2), (Func<CRMspSelectUsers_Result, bool>)((CRMspSelectUsers_Result m) => m.UserId > 0))), (Func<CRMspSelectUsers_Result, int>)((CRMspSelectUsers_Result c) => c.UserId)), 1));
				cRMspSelectUsers_Result = ((uId != cRMspSelectUsers_Result2.UserId) ? Enumerable.FirstOrDefault<CRMspSelectUsers_Result>(Enumerable.Take<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)Enumerable.OrderByDescending<CRMspSelectUsers_Result, int>(Enumerable.Where<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)Enumerable.ToList<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)db.CRMspSelectUsers(lCID, result, result2)), (Func<CRMspSelectUsers_Result, bool>)((CRMspSelectUsers_Result c) => c.UserId > uId && c.UserId > 0)), (Func<CRMspSelectUsers_Result, int>)((CRMspSelectUsers_Result c) => c.UserId)), 1)) : Enumerable.FirstOrDefault<CRMspSelectUsers_Result>(Enumerable.Take<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)Enumerable.OrderByDescending<CRMspSelectUsers_Result, int>((IEnumerable<CRMspSelectUsers_Result>)Enumerable.ToList<CRMspSelectUsers_Result>(Enumerable.Where<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)db.CRMspSelectUsers(lCID, result, result2), (Func<CRMspSelectUsers_Result, bool>)((CRMspSelectUsers_Result m) => m.UserId > 0))), (Func<CRMspSelectUsers_Result, int>)((CRMspSelectUsers_Result c) => c.UserId)), 1)));
				break;
			}
			default:
				cRMspSelectUsers_Result = Enumerable.FirstOrDefault<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)Enumerable.ToList<CRMspSelectUsers_Result>(Enumerable.Where<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)db.CRMspSelectUsers(lCID, result, result2), (Func<CRMspSelectUsers_Result, bool>)((CRMspSelectUsers_Result m) => m.UserId > 0))), (Func<CRMspSelectUsers_Result, bool>)((CRMspSelectUsers_Result c) => c.UserId == uId));
				break;
			}
		}
		DateTime now = DateTime.Now;
		if (cRMspSelectUsers_Result == null)
		{
			cRMspSelectUsers_Result = new CRMspSelectUsers_Result();
			cRMspSelectUsers_Result.RegisterDate = now;
			cRMspSelectUsers_Result.FirstRegisterDate = now;
			cRMspSelectUsers_Result.UserId = 0;
		}
		usersViewModel.UserId = cRMspSelectUsers_Result.UserId;
		usersViewModel.Row = cRMspSelectUsers_Result.Row;
		usersViewModel.FName = cRMspSelectUsers_Result.FName;
		usersViewModel.PersCode = cRMspSelectUsers_Result.PersCode;
		usersViewModel.LName = cRMspSelectUsers_Result.LName;
		usersViewModel.VmUName = cRMspSelectUsers_Result.UserName;
		usersViewModel.IsAdmin = cRMspSelectUsers_Result.IsAdmin;
		usersViewModel.VmPword = cRMspSelectUsers_Result.Password;
		usersViewModel.IsActive = cRMspSelectUsers_Result.IsActive;
		usersViewModel.UserIsActiveInWinApp = cRMspSelectUsers_Result.UserIsActiveInWinApp;
		usersViewModel.UserIsActiveInWebApp = cRMspSelectUsers_Result.UserIsActiveInWebApp;
		usersViewModel.UserIsActiveInMobApp = cRMspSelectUsers_Result.UserIsActiveInMobApp;
		usersViewModel.Nickname = cRMspSelectUsers_Result.Nickname;
		usersViewModel.AppLocationRequired = cRMspSelectUsers_Result.AppLocationRequired;
		CRMspChartUserAccess_Result cRMspChartUserAccess_Result = Enumerable.FirstOrDefault<CRMspChartUserAccess_Result>((IEnumerable<CRMspChartUserAccess_Result>)db.CRMspChartUserAccess(usersViewModel.UserId));
		if (cRMspChartUserAccess_Result != null)
		{
			usersViewModel.UserAccessDailyChrtAllUsers = cRMspChartUserAccess_Result.UserAccessDailyChrtAllUsers.HasValue && cRMspChartUserAccess_Result.UserAccessDailyChrtAllUsers != false;
			usersViewModel.UserAccessSaleChrtAllUsers = cRMspChartUserAccess_Result.UserAccessSaleChrtAllUsers.HasValue && cRMspChartUserAccess_Result.UserAccessSaleChrtAllUsers != false;
		}
		usersViewModel.MobDeActiveAccessToLocation = cRMspSelectUsers_Result.MobDeActiveAccessToLocation;
		usersViewModel.UserIsActiveInFOSetting = cRMspSelectUsers_Result.UserIsActiveInFOSetting;
		usersViewModel.Description = cRMspSelectUsers_Result.Description;
		usersViewModel.UserId1 = cRMspSelectUsers_Result.UserId1;
		usersViewModel.Month1 = cRMspSelectUsers_Result.Month1;
		usersViewModel.RegisterDate = cRMspSelectUsers_Result.RegisterDate;
		usersViewModel.RegisterDatePersian = cRMspSelectUsers_Result.RegisterDatePersian;
		if (!string.IsNullOrEmpty(usersViewModel.RegisterDatePersian))
		{
			usersViewModel.RegisterDatePersian = usersViewModel.RegisterDatePersian.Insert(4, "/");
			usersViewModel.RegisterDatePersian = usersViewModel.RegisterDatePersian.Insert(7, "/");
		}
		usersViewModel.IPAddress = cRMspSelectUsers_Result.IPAddress;
		usersViewModel.Tel = cRMspSelectUsers_Result.Tel;
		usersViewModel.TelDesc = cRMspSelectUsers_Result.TelDesc;
		usersViewModel.PositionId = cRMspSelectUsers_Result.PositionId;
		usersViewModel.PositionIdTitle = cRMspSelectUsers_Result.PositionName;
		usersViewModel.SignatureId = cRMspSelectUsers_Result.SignatureId;
		usersViewModel.DepartmentId = cRMspSelectUsers_Result.DepartmentId;
		usersViewModel.DepartmentIdTitle = cRMspSelectUsers_Result.Department ?? "";
		usersViewModel.ResponsibleUserId = cRMspSelectUsers_Result.ResponsibleUserId;
		usersViewModel.ResponsibleUserIdTitle = cRMspSelectUsers_Result.ResponsibleUser ?? "";
		usersViewModel.ComputerName = cRMspSelectUsers_Result.ComputerName;
		usersViewModel.GUId = cRMspSelectUsers_Result.GUId;
		usersViewModel.CallreIdDeActive = cRMspSelectUsers_Result.CallreIdDeActive;
		usersViewModel.CallreIdDeActiveLines = cRMspSelectUsers_Result.CallreIdDeActiveLines;
		usersViewModel.DisableInternalMessageAllarmVoice = cRMspSelectUsers_Result.DisableInternalMessageAllarmVoice;
		usersViewModel.DisableReceiveCNVSInfoAllarm = cRMspSelectUsers_Result.DisableReceiveCNVSInfoAllarm;
		usersViewModel.EmailAttachFileLocation = cRMspSelectUsers_Result.EmailAttachFileLocation;
		usersViewModel.AllowCopyOtherLanguage = cRMspSelectUsers_Result.AllowCopyOtherLanguage;
		usersViewModel.FirstRegisterDatePersian = ((!cRMspSelectUsers_Result.FirstRegisterDate.HasValue) ? DateTimeClass.ConvertDateWOSlashToSlash(cRMspSelectUsers_Result.FirstRegisterDatePersian) : ((lCID != 1065) ? cRMspSelectUsers_Result.FirstRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : cRMspSelectUsers_Result.FirstRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss", new PersianCulture())));
		usersViewModel.RegisterDatePersian = ((!cRMspSelectUsers_Result.RegisterDate.HasValue) ? DateTimeClass.ConvertDateWOSlashToSlash(cRMspSelectUsers_Result.RegisterDatePersian) : ((lCID != 1065) ? cRMspSelectUsers_Result.RegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : cRMspSelectUsers_Result.RegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss", new PersianCulture())));
		if (string.IsNullOrEmpty(cRMspSelectUsers_Result.AppType))
		{
			cRMspSelectUsers_Result.AppType = Configuration.AppType;
		}
		usersViewModel.AppType = Labels.AppType + ": " + Configuration.GetAppType(cRMspSelectUsers_Result.AppType);
		usersViewModel.FirstRegisterUser = cRMspSelectUsers_Result.FirstRegisterUser ?? "";
		usersViewModel.LastEditUser = cRMspSelectUsers_Result.EditUser + " (" + usersViewModel.AppType + ")";
		usersViewModel.MaxNumberCmpDraft = cRMspSelectUsers_Result.MaxNumberCmpDraft;
		usersViewModel.StartDate = cRMspSelectUsers_Result.StartDate;
		usersViewModel.StartDatePersian = (usersViewModel.StartDate.HasValue ? usersViewModel.StartDate.Value.ToString("yyyy/MM/dd") : "");
		usersViewModel.ExpireDate = cRMspSelectUsers_Result.ExpireDate;
		usersViewModel.ExpireDatePersian = (usersViewModel.ExpireDate.HasValue ? usersViewModel.ExpireDate.Value.ToString("yyyy/MM/dd") : "");
		usersViewModel.UserGroupId = cRMspSelectUsers_Result.UserGroupId;
		usersViewModel.UserGroup = cRMspSelectUsers_Result.UserGroup;
		usersViewModel.UserExtensions = cRMspSelectUsers_Result.UserExtensions;
		usersViewModel.CallPreNumber = cRMspSelectUsers_Result.CallPreNumber;
		usersViewModel.LinkAccUserCode = Labels.UserShowLinkAccUserCode + ":" + cRMspSelectUsers_Result.LinkAccUserCode;
		usersViewModel.LinkAccUserIdStr = Labels.UserShowLinkAccUserIdStr + ":" + cRMspSelectUsers_Result.LinkAccUserIdStr;
		usersViewModel.DeActiveSmartTimeAttendance = cRMspSelectUsers_Result.DeActiveSmartTimeAttendance;
		usersViewModel.MobImeiCode = cRMspSelectUsers_Result.MobImeiCode;
		usersViewModel.CrmNotifDeactivInHrm = cRMspSelectUsers_Result.CrmNotifDeactivInHrm;
		return PartialView(usersViewModel);
	}

	public void SetRegisterInfoForUserSignature(UserSignatureViewModel model)
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
				UserSignatureViewModel userSignatureViewModel = model;
				_ = model.UserId;
				userSignatureViewModel.UserId = model.UserId;
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

	[DynamicAuthorize(ControllerName = "frmDefineUsers", ActionName = "actInsertUserSignature")]
	public ActionResult UserSignatureUpload(int uId)
	{
		_003C_003Ec__DisplayClass8_0 _003C_003Ec__DisplayClass8_ = new _003C_003Ec__DisplayClass8_0();
		_003C_003Ec__DisplayClass8_.uId = uId;
		DbSet<UserSignature> userSignature = _dbTbl.UserSignature;
		ParameterExpression val = Expression.Parameter(typeof(UserSignature), "c");
		IQueryable<UserSignature> obj = Queryable.Where<UserSignature>((IQueryable<UserSignature>)userSignature, Expression.Lambda<Func<UserSignature, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass8_, typeof(_003C_003Ec__DisplayClass8_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
		val = Expression.Parameter(typeof(UserSignature), "c");
		UserSignature userSignature2 = Queryable.FirstOrDefault<UserSignature>((IQueryable<UserSignature>)(object)Queryable.OrderByDescending<UserSignature, DateTime>(obj, Expression.Lambda<Func<UserSignature, DateTime>>((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
		UserSignatureViewModel userSignatureViewModel = new UserSignatureViewModel();
		userSignatureViewModel.SignatureUserId = _003C_003Ec__DisplayClass8_.uId;
		DateTime now = DateTime.Now;
		if (userSignature2 != null)
		{
			userSignatureViewModel.SignatureID = userSignature2.SignatureID;
			userSignatureViewModel.UserId = userSignature2.UserId;
			userSignatureViewModel.FirstRegisterUserId = userSignature2.FirstRegisterUserId;
			userSignatureViewModel.RegisterDate = userSignature2.RegisterDate;
			userSignatureViewModel.FirstRegisterDate = userSignature2.FirstRegisterDate;
			userSignatureViewModel.AppType = userSignature2.AppType;
		}
		else
		{
			userSignatureViewModel.UserId = UserLogin.CurrentUser.UserId;
			userSignatureViewModel.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
			userSignatureViewModel.RegisterDate = now;
			userSignatureViewModel.FirstRegisterDate = now;
			userSignatureViewModel.AppType = "new";
		}
		base.ViewBag.Update = false;
		SetRegisterInfoForUserSignature(userSignatureViewModel);
		return View(userSignatureViewModel);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	[DynamicAuthorize(ControllerName = "frmDefineUsers", ActionName = "actInsertUserSignature")]
	public ActionResult UserSignatureUpload(UserSignatureViewModel UsignVM, HttpPostedFileBase UserSignatureUrlUpload)
	{
		_003C_003Ec__DisplayClass9_0 _003C_003Ec__DisplayClass9_ = new _003C_003Ec__DisplayClass9_0();
		_003C_003Ec__DisplayClass9_.UsignVM = UsignVM;
		if (base.ModelState.IsValid)
		{
			try
			{
				if (UserSignatureUrlUpload == null)
				{
					base.ModelState.AddModelError("error", Messages.frmErrorNotFileSelected);
					return View(_003C_003Ec__DisplayClass9_.UsignVM);
				}
				string text = UserSignatureUrlUpload.ContentType.ToLower();
				string text2 = Path.GetExtension(UserSignatureUrlUpload.FileName).ToLower();
				if ((text != "image/jpg" && text != "image/jpeg" && text != "image/pjpeg" && text != "image/gif" && text != "image/x-png" && text != "image/png") || (text2 != ".jpg" && text2 != ".png" && text2 != ".gif" && text2 != ".jpeg"))
				{
					base.ModelState.AddModelError("error", Messages.frmErrorNotImageFile);
					return View(_003C_003Ec__DisplayClass9_.UsignVM);
				}
				if (UserSignatureUrlUpload.ContentLength / 1024 > Configuration.MaxImageSizeForUploadKb)
				{
					base.ModelState.AddModelError("error", string.Format(Messages.frmErrorMaxImageSizeForUpload, Configuration.MaxImageSizeForUploadKb));
					return View(_003C_003Ec__DisplayClass9_.UsignVM);
				}
				DbSet<UserSignature> userSignature = _dbTbl.UserSignature;
				ParameterExpression val = Expression.Parameter(typeof(UserSignature), "c");
				UserSignature userSignature2 = Queryable.FirstOrDefault<UserSignature>((IQueryable<UserSignature>)userSignature, Expression.Lambda<Func<UserSignature, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass9_, typeof(_003C_003Ec__DisplayClass9_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				bool flag = false;
				if (userSignature2 == null)
				{
					userSignature2 = new UserSignature();
					flag = true;
					userSignature2.SignatureUserId = _003C_003Ec__DisplayClass9_.UsignVM.SignatureUserId;
					userSignature2.GUId = System.Guid.NewGuid();
				}
				userSignature2.RegisterDate = DateTime.Now;
				userSignature2.RegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
				userSignature2.UserId = UserLogin.CurrentUser.UserId;
				userSignature2.Year1 = short.Parse(Financial.Get().Id.ToString());
				userSignature2.Month1 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
				_ = string.Empty;
				_ = string.Empty;
				if (UserSignatureUrlUpload != null)
				{
					userSignature2.Signature = ImageManager.CompressHttpPostedFileBase(new ImageManager.ImageParam
					{
						HttpPostedFileBase_Var = UserSignatureUrlUpload,
						FileExtension = "png"
					});
				}
				else
				{
					userSignature2.Signature = null;
				}
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				userSignature2.AppType = Configuration.AppType;
				if (flag)
				{
					userSignature2.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
					userSignature2.FirstRegisterDate = DateTime.Now;
					userSignature2.FirstRegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
					userSignature2.LanguageID = result;
					_dbTbl.UserSignature.Add(userSignature2);
				}
				else
				{
					_dbTbl.Entry(userSignature2).State = EntityState.Modified;
				}
				_dbTbl.SaveChanges();
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("UserSignature", _003C_003Ec__DisplayClass9_.UsignVM.SignatureUserId);
				_003C_003Ec__DisplayClass9_.UsignVM.SignatureID = userSignature2.SignatureID;
				base.ViewBag.Update = true;
				_003C_003Ec__DisplayClass9_.UsignVM.UserId = userSignature2.UserId;
				_003C_003Ec__DisplayClass9_.UsignVM.FirstRegisterUserId = userSignature2.FirstRegisterUserId;
				_003C_003Ec__DisplayClass9_.UsignVM.RegisterDate = userSignature2.RegisterDate;
				_003C_003Ec__DisplayClass9_.UsignVM.FirstRegisterDate = userSignature2.FirstRegisterDate;
				_003C_003Ec__DisplayClass9_.UsignVM.AppType = userSignature2.AppType;
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				base.ModelState.AddModelError("error", Messages.frmErrorInSendingFile);
			}
		}
		SetRegisterInfoForUserSignature(_003C_003Ec__DisplayClass9_.UsignVM);
		return View(_003C_003Ec__DisplayClass9_.UsignVM);
	}

	public FileResult GetSignatureImage(int uId)
	{
		byte[] array = null;
		CRMspSelectUserSignatureByUserId_Result cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)dbI.CRMspSelectUserSignatureByUserId(uId));
		if (cRMspSelectUserSignatureByUserId_Result != null)
		{
			array = cRMspSelectUserSignatureByUserId_Result.Signature;
			new MemoryStream();
			Image.FromStream((Stream)new MemoryStream(array, writable: false));
		}
		return File(array, "image/jpeg");
	}

	public string DeleteSignatureFile(int uId)
	{
		_003C_003Ec__DisplayClass11_0 _003C_003Ec__DisplayClass11_ = new _003C_003Ec__DisplayClass11_0();
		_003C_003Ec__DisplayClass11_.uId = uId;
		string result = "0";
		DbSet<UserSignature> userSignature = _dbTbl.UserSignature;
		ParameterExpression val = Expression.Parameter(typeof(UserSignature), "c");
		List<UserSignature> list = Enumerable.ToList<UserSignature>((IEnumerable<UserSignature>)Queryable.Where<UserSignature>((IQueryable<UserSignature>)userSignature, Expression.Lambda<Func<UserSignature, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass11_, typeof(_003C_003Ec__DisplayClass11_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
		if (list != null && list.Count > 0)
		{
			foreach (UserSignature item in list)
			{
				_dbTbl.UserSignature.Remove(item);
				_dbTbl.SaveChanges();
			}
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("UserSignature", _003C_003Ec__DisplayClass11_.uId);
			result = "1";
		}
		return result;
	}

	public ActionResult _PartialUsersRoll(int uId)
	{
		base.ViewBag.UserId = uId;
		return PartialView();
	}

	public ActionResult _PartialUsersRoll_Read([DataSourceRequest] DataSourceRequest request, int uId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectAllUsersPermissionByUserId_Result> list = new List<CRMspSelectAllUsersPermissionByUserId_Result>();
		try
		{
			list = Enumerable.ToList<CRMspSelectAllUsersPermissionByUserId_Result>((IEnumerable<CRMspSelectAllUsersPermissionByUserId_Result>)dbI.CRMspSelectAllUsersPermissionByUserId(uId, lCID, result));
			if (list == null)
			{
				list = new List<CRMspSelectAllUsersPermissionByUserId_Result>();
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

	public ActionResult _PartialUserList(string val, int mode)
	{
		base.ViewBag.Val = val;
		base.ViewBag.Mode = mode;
		return PartialView();
	}

	public ActionResult _PartialUserList_Read([DataSourceRequest] DataSourceRequest request, string val, int mode)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectUsersInMode_Result> list = new List<CRMspSelectUsersInMode_Result>();
		int? userLastCId = UserLogin.CurrentUser.UserLastCId;
		try
		{
			list = Enumerable.ToList<CRMspSelectUsersInMode_Result>(Enumerable.Where<CRMspSelectUsersInMode_Result>((IEnumerable<CRMspSelectUsersInMode_Result>)dbI.CRMspSelectUsersInMode(mode, val, lCID, result, userLastCId, UserLogin.CurrentUser.UserCIds), (Func<CRMspSelectUsersInMode_Result, bool>)((CRMspSelectUsersInMode_Result m) => m.UserId > 0)));
			foreach (CRMspSelectUsersInMode_Result item in list)
			{
				item.UserIsActiveInWebApp = item.UserIsActiveInWebApp.GetValueOrDefault();
				item.UserIsActiveInMobApp = item.UserIsActiveInMobApp.GetValueOrDefault();
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

	[AjaxOnly]
	public JsonResult GetUserInfo(int currUserId, int mode, string textSearch = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int? userLastCId = UserLogin.CurrentUser.UserLastCId;
		CurrentUserViewModel currentUserViewModel = new CurrentUserViewModel();
		currentUserViewModel.CurrUser = new CRMspSelectUsersInMode_Result();
		currentUserViewModel.UserAccessDailyChrtAllUsers = false;
		currentUserViewModel.UserAccessSaleChrtAllUsers = false;
		try
		{
			List<CRMspSelectUsersInMode_Result> list = Enumerable.ToList<CRMspSelectUsersInMode_Result>(Enumerable.Where<CRMspSelectUsersInMode_Result>((IEnumerable<CRMspSelectUsersInMode_Result>)dbI.CRMspSelectUsersInMode(mode, textSearch, lCID, result, userLastCId, UserLogin.CurrentUser.UserCIds), (Func<CRMspSelectUsersInMode_Result, bool>)((CRMspSelectUsersInMode_Result m) => m.UserId > 0)));
			if (Enumerable.Any<CRMspSelectUsersInMode_Result>((IEnumerable<CRMspSelectUsersInMode_Result>)list))
			{
				currentUserViewModel.IsFind = true;
				currentUserViewModel.Message = "";
				currentUserViewModel.PreviousUserId = -1;
				currentUserViewModel.NextUserId = -1;
				currentUserViewModel.FirstUserId = -1;
				currentUserViewModel.LastUserId = -1;
				if (list.Count == 1)
				{
					currentUserViewModel.FirstUserId = -1;
					currentUserViewModel.LastUserId = -1;
				}
				else
				{
					currentUserViewModel.FirstUserId = Enumerable.FirstOrDefault<CRMspSelectUsersInMode_Result>((IEnumerable<CRMspSelectUsersInMode_Result>)list).UserId;
					currentUserViewModel.LastUserId = Enumerable.LastOrDefault<CRMspSelectUsersInMode_Result>((IEnumerable<CRMspSelectUsersInMode_Result>)list).UserId;
				}
				CRMspSelectUsersInMode_Result cRMspSelectUsersInMode_Result = ((currUserId <= 0) ? Enumerable.LastOrDefault<CRMspSelectUsersInMode_Result>((IEnumerable<CRMspSelectUsersInMode_Result>)list) : list.Find((CRMspSelectUsersInMode_Result c) => c.UserId == currUserId));
				if (cRMspSelectUsersInMode_Result != null)
				{
					cRMspSelectUsersInMode_Result.FirstRegisterDatePersian = (cRMspSelectUsersInMode_Result.FirstRegisterDate.HasValue ? cRMspSelectUsersInMode_Result.FirstRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : null);
					cRMspSelectUsersInMode_Result.RegisterDatePersian = (cRMspSelectUsersInMode_Result.RegisterDate.HasValue ? cRMspSelectUsersInMode_Result.RegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : null);
					if (string.IsNullOrEmpty(cRMspSelectUsersInMode_Result.AppType))
					{
						cRMspSelectUsersInMode_Result.AppType = Configuration.AppType;
					}
					cRMspSelectUsersInMode_Result.AppType = Labels.AppType + ": " + Configuration.GetAppType(cRMspSelectUsersInMode_Result.AppType);
					cRMspSelectUsersInMode_Result.EditUser = cRMspSelectUsersInMode_Result.EditUser + " (" + cRMspSelectUsersInMode_Result.AppType + ")";
					cRMspSelectUsersInMode_Result.FirstRegisterUser = cRMspSelectUsersInMode_Result.FirstRegisterUser ?? "";
					cRMspSelectUsersInMode_Result.StartDatePersian = (cRMspSelectUsersInMode_Result.StartDate.HasValue ? cRMspSelectUsersInMode_Result.StartDate.Value.ToString("yyyy/MM/dd") : "");
					cRMspSelectUsersInMode_Result.ExpireDatePersian = (cRMspSelectUsersInMode_Result.ExpireDate.HasValue ? cRMspSelectUsersInMode_Result.ExpireDate.Value.ToString("yyyy/MM/dd") : "");
					cRMspSelectUsersInMode_Result.LinkAccUserCode = Labels.UserShowLinkAccUserCode + ":" + cRMspSelectUsersInMode_Result.LinkAccUserCode;
					cRMspSelectUsersInMode_Result.LinkAccUserIdStr = Labels.UserShowLinkAccUserIdStr + ":" + cRMspSelectUsersInMode_Result.LinkAccUserIdStr;
					if (!string.IsNullOrEmpty(cRMspSelectUsersInMode_Result.Password))
					{
						cRMspSelectUsersInMode_Result.Password = XorCipher.EncryptByPrivateKey(cRMspSelectUsersInMode_Result.Password);
					}
					CRMspChartUserAccess_Result cRMspChartUserAccess_Result = Enumerable.FirstOrDefault<CRMspChartUserAccess_Result>((IEnumerable<CRMspChartUserAccess_Result>)db.CRMspChartUserAccess(cRMspSelectUsersInMode_Result.UserId));
					if (cRMspChartUserAccess_Result != null)
					{
						currentUserViewModel.UserAccessDailyChrtAllUsers = cRMspChartUserAccess_Result.UserAccessDailyChrtAllUsers.HasValue && cRMspChartUserAccess_Result.UserAccessDailyChrtAllUsers != false;
						currentUserViewModel.UserAccessSaleChrtAllUsers = cRMspChartUserAccess_Result.UserAccessSaleChrtAllUsers.HasValue && cRMspChartUserAccess_Result.UserAccessSaleChrtAllUsers != false;
					}
					currentUserViewModel.CurrUser = cRMspSelectUsersInMode_Result;
					currentUserViewModel.CurrentUserId = cRMspSelectUsersInMode_Result.UserId;
					if (list.Count == 1)
					{
						currentUserViewModel.NextUserId = -1;
						currentUserViewModel.PreviousUserId = -1;
					}
					else
					{
						CRMspSelectUsersInMode_Result next = Lists.GetNext(list, cRMspSelectUsersInMode_Result);
						if (next != null)
						{
							currentUserViewModel.NextUserId = next.UserId;
						}
						CRMspSelectUsersInMode_Result previous = Lists.GetPrevious(list, cRMspSelectUsersInMode_Result);
						if (previous != null)
						{
							currentUserViewModel.PreviousUserId = previous.UserId;
						}
					}
				}
				else
				{
					currentUserViewModel.IsFind = false;
					currentUserViewModel.Message = Messages.ErrorNotFound;
					currentUserViewModel.CurrUser = null;
					currentUserViewModel.CurrentUserId = -1;
					currentUserViewModel.NextUserId = -1;
					currentUserViewModel.PreviousUserId = -1;
					currentUserViewModel.FirstUserId = -1;
					currentUserViewModel.LastUserId = -1;
				}
			}
			else
			{
				currentUserViewModel.IsFind = false;
				currentUserViewModel.Message = Messages.ErrorNotFound;
				currentUserViewModel.CurrUser = null;
				currentUserViewModel.CurrentUserId = -1;
				currentUserViewModel.NextUserId = -1;
				currentUserViewModel.PreviousUserId = -1;
				currentUserViewModel.FirstUserId = -1;
				currentUserViewModel.LastUserId = -1;
			}
		}
		catch (DbEntityValidationException ex)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)ex);
			currentUserViewModel.Message = Messages.frmErrorMessage + "<br />" + ((Exception)(object)ex).Message;
		}
		catch (Exception ex2)
		{
			ErrorSignal.FromCurrentContext().Raise(ex2);
			currentUserViewModel.Message = Messages.frmErrorMessage + "<br />" + ex2.Message;
		}
		JsonResult jsonResult = Json(currentUserViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public ActionResult _PartialUserSignature(int userId)
	{
		base.ViewBag.CurrUserId = userId;
		return PartialView();
	}

	[DynamicAuthorize(ControllerName = "frmDefineUsers", ActionName = "actShowDetailsUserCount")]
	public ActionResult ShowDetailsUserCount()
	{
		return View();
	}

	public JsonResult GetDetailsUserCount()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		UserCountViewModel userCountViewModel = new UserCountViewModel();
		try
		{
			CRMspReturnUsersCount_Result cRMspReturnUsersCount_Result = Enumerable.FirstOrDefault<CRMspReturnUsersCount_Result>((IEnumerable<CRMspReturnUsersCount_Result>)dbI.CRMspReturnUsersCount());
			if (cRMspReturnUsersCount_Result != null)
			{
				userCountViewModel.UsersCount = cRMspReturnUsersCount_Result.UsersCount;
				userCountViewModel.UsersIsActiveCount = cRMspReturnUsersCount_Result.UsersIsActiveCount;
				userCountViewModel.UsersDeActiveCount = cRMspReturnUsersCount_Result.UsersDeActiveCount;
				userCountViewModel.UsersIsActiveInWinAppCount = cRMspReturnUsersCount_Result.UsersIsActiveInWinAppCount;
				userCountViewModel.UsersDeActiveInWinAppCount = cRMspReturnUsersCount_Result.UsersDeActiveInWinAppCount;
				userCountViewModel.UsersIsActiveInWebAppCount = cRMspReturnUsersCount_Result.UsersIsActiveInWebAppCount;
				userCountViewModel.UsersDeActiveInWebAppCount = cRMspReturnUsersCount_Result.UsersDeActiveInWebAppCount;
				userCountViewModel.UsersIsActiveInMobAppCount = cRMspReturnUsersCount_Result.UsersIsActiveInMobAppCount;
				userCountViewModel.UsersDeActiveInMobAppCount = cRMspReturnUsersCount_Result.UsersDeActiveInMobAppCount;
				userCountViewModel.UsersIsActiveInHRMCount = cRMspReturnUsersCount_Result.UsersIsActiveInHRMCount;
				userCountViewModel.UsersDeActiveInHRMCount = cRMspReturnUsersCount_Result.UsersDeActiveInHRMCount;
			}
			if (VersionBuyer.Enterprise)
			{
				_ = Configuration.MaxCountOfOnlineUser;
			}
			userCountViewModel.UsersCountInLock = Configuration.MaxCountOfOnlineUser + Configuration.MaxCountOfOnlineUserDeActive;
			userCountViewModel.UsersIsActiveCountInLock = Configuration.MaxCountOfOnlineUser;
			userCountViewModel.UsersDeActiveCountInLock = Configuration.MaxCountOfOnlineUserDeActive;
			userCountViewModel.UsersIsActiveInWebAppCountInLock = Configuration.MaxCountOfOnlineUser;
			userCountViewModel.UsersIsActiveInMobAppCountInLock = Configuration.MaxCountOfOnlineUserInMob;
			userCountViewModel.UsersIsActiveInHRMCountInLock = Configuration.MaxCountOfOnlineUserInHrm;
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			int result2 = 0;
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				int.TryParse(cRMspSelectCrmsysSetting_Result.LockCounter, out result2);
			}
			userCountViewModel.UsersIsActiveInWinAppCountInLock = result2;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(userCountViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[DynamicAuthorize(ControllerName = "frmDefineUsers", ActionName = "actInsert")]
	public ActionResult UserDefineInsert()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		UsersViewModel usersViewModel = new UsersViewModel
		{
			UserId1 = UserLogin.CurrentUser.UserId,
			Month1 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture())),
			RegisterDate = DateTime.Now,
			RegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture()),
			IsActive = true,
			UserIsActiveInWinApp = true,
			UserIsActiveInWebApp = true,
			AccessOtherUsersCmpInfo = true,
			AccessOtherUsersPrsInfo = true,
			AccessOtherUsersPrjInfo = true,
			AccessOtherUsersCnvsInfo = true,
			AccessPreOrderType = true,
			AccessOrderOpr = true,
			AccessBuyOrderOpr = true,
			AppLocationRequired = false,
			CrmNotifDeactivInHrm = false
		};
		UserFullcombo();
		GetUserGroup();
		if (Center.HaveModule)
		{
			usersViewModel.UserCIds = UserLogin.CurrentUser.UserLastCId.ToString();
		}
		try
		{
			dbI.CRMspUpdateExpiredUsersStatus();
			int num = 0;
			int num2 = 0;
			num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)dbI.CRMspReturnActiveUsersCount()).GetValueOrDefault();
			num2 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)dbI.CRMspReturnActiveUsersInWebAppCount()).GetValueOrDefault();
			int num3 = 50;
			int num4 = Configuration.MaxCountOfOnlineUser + Configuration.MaxCountOfOnlineUserDeActive;
			if (VersionBuyer.Enterprise)
			{
				num3 = Configuration.MaxCountOfOnlineUser;
			}
			if (num4 <= num || num3 <= num2)
			{
				base.ViewBag.Error = Messages.msgErrorFinishingUserDefinitionCapacity;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View(usersViewModel);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	[DynamicAuthorize(ControllerName = "frmDefineUsers", ActionName = "actInsert")]
	public ActionResult UserDefineInsert(UsersViewModel userVm)
	{
		//IL_0406: Unknown result type (might be due to invalid IL or missing references)
		//IL_044b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0490: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_051a: Unknown result type (might be due to invalid IL or missing references)
		int userId = UserLogin.CurrentUser.UserId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int countError = 0;
		GetUserGroup();
		BaseInfo baseInfo = new BaseInfo();
		try
		{
			if (UserLogin.CurrentUser != null)
			{
				_ = UserLogin.CurrentUser.UserLastCId;
			}
			bool result = false;
			bool.TryParse(userVm.IsActive.ToString(), out result);
			bool result2 = false;
			bool.TryParse(userVm.UserIsActiveInWinApp.ToString(), out result2);
			bool result3 = false;
			bool.TryParse(userVm.UserIsActiveInWebApp.ToString(), out result3);
			bool result4 = false;
			bool.TryParse(userVm.UserIsActiveInMobApp.ToString(), out result4);
			bool result5 = false;
			bool.TryParse(userVm.UserIsActiveInHRM.ToString(), out result5);
			bool result6 = false;
			bool.TryParse(userVm.UserIsActiveInCIC.ToString(), out result6);
			if (!result)
			{
				userVm.UserIsActiveInWinApp = false;
				userVm.UserIsActiveInWebApp = false;
				userVm.UserIsActiveInMobApp = false;
				userVm.UserIsActiveInHRM = false;
				userVm.UserIsActiveInCIC = false;
			}
			if (result2 || result3 || result4 || result5 || result6)
			{
				userVm.IsActive = true;
			}
			try
			{
				int num = 0;
				int num2 = 0;
				num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)dbI.CRMspReturnActiveUsersCount()).GetValueOrDefault();
				num2 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)dbI.CRMspReturnActiveUsersInWebAppCount()).GetValueOrDefault();
				int num3 = 50;
				int num4 = Configuration.MaxCountOfOnlineUser + Configuration.MaxCountOfOnlineUserDeActive;
				if (VersionBuyer.Enterprise)
				{
					num3 = Configuration.MaxCountOfOnlineUser;
				}
				bool result7 = false;
				bool.TryParse(userVm.IsActive.ToString(), out result7);
				bool result8 = false;
				bool.TryParse(userVm.UserIsActiveInWebApp.ToString(), out result8);
				int maxCountOfOnlineUser = Configuration.MaxCountOfOnlineUser;
				if (result7)
				{
					if (num4 <= num)
					{
						countError++;
						base.ViewBag.Error = Messages.msgErrorFinishingUserDefinitionCapacity;
						UserFullcombo();
						return View(userVm);
					}
					if (result8 && maxCountOfOnlineUser <= num2)
					{
						countError++;
						base.ViewBag.Error = Messages.msgErrorFinishingUserDefinitionCapacity;
						UserFullcombo();
						return View(userVm);
					}
					if (num3 <= num2)
					{
						countError++;
						base.ViewBag.Error = Messages.msgErrorFinishingUserDefinitionCapacity;
						UserFullcombo();
						return View(userVm);
					}
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
			if (base.ModelState.IsValid)
			{
				List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(userVm.FName_Lang))
				{
					list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(userVm.FName_Lang);
				}
				list.Add(new CommonMultiLanguageViewModel
				{
					Value = userVm.FName,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(userVm.LName_Lang))
				{
					list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(userVm.LName_Lang);
				}
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = userVm.LName,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(userVm.Description_Lang))
				{
					list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(userVm.Description_Lang);
				}
				list3.Add(new CommonMultiLanguageViewModel
				{
					Value = userVm.Description,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(userVm.Nickname_Lang))
				{
					list4 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(userVm.Nickname_Lang);
				}
				list4.Add(new CommonMultiLanguageViewModel
				{
					Value = userVm.Nickname,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list5 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(userVm.DefCmpPrjTitle_Lang))
				{
					list5 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(userVm.DefCmpPrjTitle_Lang);
				}
				list5.Add(new CommonMultiLanguageViewModel
				{
					Value = userVm.DefCmpPrjTitle,
					LanguageId = lCID
				});
				text = ChkBeforeSubmitUser(userVm, list2, ref countError);
				DateTime dateTime = default(DateTime);
				string text2 = "";
				try
				{
					if (!string.IsNullOrEmpty(userVm.StartDatePersian))
					{
						text2 = PersianDate.GetFormatetdDate(userVm.StartDatePersian.Replace("/", ""));
						switch (lCID)
						{
						case 1065:
							dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
							userVm.StartDatePersian = dateTime.ToString("yyyyMMdd");
							break;
						case 1025:
							dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
							userVm.StartDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
							break;
						default:
							dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
							userVm.StartDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
							break;
						}
						userVm.StartDate = dateTime;
					}
					else
					{
						userVm.StartDate = null;
					}
				}
				catch (Exception e2)
				{
					ErrorSignal.FromCurrentContext().Raise(e2);
					text += string.Format(Messages.ErrorInFormat, Labels.UserStartDate);
					countError++;
				}
				if (userVm.StartDatePersian != null)
				{
					userVm.StartDatePersian = userVm.StartDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
						.Replace(".", "")
						.Replace(",", "")
						.Replace("\\", "");
				}
				dateTime = default(DateTime);
				text2 = "";
				try
				{
					if (!string.IsNullOrEmpty(userVm.ExpireDatePersian))
					{
						text2 = PersianDate.GetFormatetdDate(userVm.ExpireDatePersian.Replace("/", ""));
						switch (lCID)
						{
						case 1065:
							dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
							userVm.ExpireDatePersian = dateTime.ToString("yyyyMMdd");
							break;
						case 1025:
							dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
							userVm.ExpireDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
							break;
						default:
							dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
							userVm.ExpireDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
							break;
						}
						userVm.ExpireDate = dateTime;
					}
					else
					{
						userVm.ExpireDate = null;
					}
				}
				catch (Exception e3)
				{
					ErrorSignal.FromCurrentContext().Raise(e3);
					text += string.Format(Messages.ErrorInFormat, Labels.UserExpireDate);
					countError++;
				}
				if (userVm.ExpireDatePersian != null)
				{
					userVm.ExpireDatePersian = userVm.ExpireDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
						.Replace(".", "")
						.Replace(",", "")
						.Replace("\\", "");
				}
				bool result9 = false;
				bool.TryParse(userVm.UserIsActiveInWebApp.ToString(), out result9);
				bool result10 = false;
				bool.TryParse(userVm.UserIsActiveInMobApp.ToString(), out result10);
				_ = Configuration.MaxCountOfOnlineUser;
				int maxCountOfOnlineUserInMob = Configuration.MaxCountOfOnlineUserInMob;
				if (!result10)
				{
					userVm.MobUserAppUseCnt = null;
				}
				if (result10 && Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)dbI.CRMspReturnSumMobUserAppUseCnt()).GetValueOrDefault() + userVm.MobUserAppUseCnt.GetValueOrDefault() > maxCountOfOnlineUserInMob)
				{
					countError++;
					text = text + string.Format(Messages.msgErrorDefineNewUserAppUseCntMoreThenMaxCountAllowedInMob, maxCountOfOnlineUserInMob.ToString()) + "<br>";
				}
				bool result11 = false;
				bool.TryParse(userVm.UserIsActiveInHRM.ToString(), out result11);
				int maxCountOfOnlineUserInHrm = Configuration.MaxCountOfOnlineUserInHrm;
				if (!result11)
				{
					userVm.MobHRMUserAppUseCnt = null;
				}
				if (result11 && Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)dbI.CRMspReturnSumMobHRMUserAppUseCnt()).GetValueOrDefault() + userVm.MobHRMUserAppUseCnt.GetValueOrDefault() > maxCountOfOnlineUserInHrm)
				{
					countError++;
					text = text + string.Format(Messages.msgErrorDefineNewUserAppUseCntMoreThenMaxCountAllowedInHrm, maxCountOfOnlineUserInHrm.ToString()) + "<br>";
				}
				bool result12 = false;
				bool.TryParse(userVm.UserIsActiveInCIC.ToString(), out result12);
				int maxCountCic = Configuration.MaxCountCic;
				if (!result12)
				{
					userVm.MobCICUserAppUseCnt = null;
				}
				if (result12 && Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)dbI.CRMspReturnSumMobCICUserAppUseCnt()).GetValueOrDefault() + userVm.MobCICUserAppUseCnt.GetValueOrDefault() > maxCountCic)
				{
					countError++;
					text = text + string.Format(Messages.msgErrorDefineNewUserAppUseCntMoreThenMaxCountAllowedInCic, maxCountCic.ToString()) + "<br>";
				}
				if (countError == 0)
				{
					DateTime now = DateTime.Now;
					userVm.PositionId = ((userVm.PositionId == 0) ? null : userVm.PositionId);
					int? userCId = null;
					if (!string.IsNullOrWhiteSpace(userVm.UserCIds))
					{
						string[] array = userVm.UserCIds.Split(new char[1] { ',' });
						if (array != null && array.Length != 0)
						{
							string[] array2 = array;
							foreach (string text3 in array2)
							{
								int result13 = 0;
								if (!string.IsNullOrWhiteSpace(text3))
								{
									int.TryParse(text3, out result13);
									if (result13 != 0 && userCId.GetValueOrDefault() == 0)
									{
										userCId = result13;
									}
								}
							}
						}
					}
					Users users = new Users
					{
						Row = userVm.Row,
						PersCode = userVm.PersCode,
						UserName = userVm.VmUName,
						IsAdmin = baseInfo.ConvertMd5(userVm.VmPword).ToLower() + userVm.VmPword,
						Password = baseInfo.ConvertMd5(userVm.VmPword).ToLower(),
						IsActive = userVm.IsActive,
						UserIsActiveInWinApp = userVm.UserIsActiveInWinApp,
						UserIsActiveInWebApp = userVm.UserIsActiveInWebApp,
						UserIsActiveInMobApp = userVm.UserIsActiveInMobApp,
						UserIsActiveInFOSetting = userVm.UserIsActiveInFOSetting,
						UserAccessDailyChrtAllUsers = userVm.UserAccessDailyChrtAllUsers,
						UserAccessSaleChrtAllUsers = userVm.UserAccessSaleChrtAllUsers,
						MobDeActiveAccessToLocation = userVm.MobDeActiveAccessToLocation,
						IPAddress = userVm.IPAddress,
						Tel = userVm.Tel,
						TelDesc = userVm.TelDesc,
						PositionId = userVm.PositionId,
						SignatureId = userVm.SignatureId,
						DepartmentInfo = userVm.DepartmentInfo,
						ResponsibleUserId = userVm.ResponsibleUserId,
						ComputerName = userVm.ComputerName,
						CallreIdDeActive = userVm.CallreIdDeActive,
						CallreIdDeActiveLines = userVm.CallreIdDeActiveLines,
						DisableInternalMessageAllarmVoice = userVm.DisableInternalMessageAllarmVoice,
						DisableReceiveCNVSInfoAllarm = userVm.DisableReceiveCNVSInfoAllarm,
						EmailAttachFileLocation = userVm.EmailAttachFileLocation,
						AllowCopyOtherLanguage = userVm.AllowCopyOtherLanguage,
						DeActiveSmartTimeAttendance = userVm.DeActiveSmartTimeAttendance,
						MobImeiCode = userVm.MobImeiCode,
						DeActiveLoginWithoutShift = userVm.DeActiveLoginWithoutShift,
						UserIsActiveInHRM = userVm.UserIsActiveInHRM,
						MobHRMImeiCode = userVm.MobHRMImeiCode,
						ActiveMobMovementTracking = userVm.ActiveMobMovementTracking,
						MobMovementTrackingDistanceInterval = userVm.MobMovementTrackingDistanceInterval,
						MobMovementTrackingTimeInterval = userVm.MobMovementTrackingTimeInterval,
						UserId1 = userId,
						RegisterDate = now,
						RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
						Month1 = short.Parse(now.ToString("MM", new PersianCulture())),
						GUId = System.Guid.NewGuid(),
						AppType = Configuration.AppType,
						FirstRegisterDate = now,
						FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
						LanguageID = defLangID,
						FirstRegisterUserId = userId,
						FName = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null),
						LName = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null),
						Description = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null),
						MaxNumberCmpDraft = userVm.MaxNumberCmpDraft,
						StartDate = userVm.StartDate,
						StartDatePersian = userVm.StartDatePersian,
						ExpireDate = userVm.ExpireDate,
						ExpireDatePersian = userVm.ExpireDatePersian,
						UserGroupId = userVm.UserGroupId,
						UserExtensions = userVm.UserExtensions,
						CallPreNumber = userVm.CallPreNumber,
						Nickname = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null),
						DefCmpPrjTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null),
						MobDeActiveScreenshot = userVm.MobDeActiveScreenshot,
						MobCallerIdDeActive = userVm.MobCallerIdDeActive,
						MobUserAppUseCnt = userVm.MobUserAppUseCnt,
						MobHRMUserAppUseCnt = userVm.MobHRMUserAppUseCnt,
						UserIsActiveInCIC = userVm.UserIsActiveInCIC,
						MobCICUserAppUseCnt = userVm.MobCICUserAppUseCnt,
						CallerIdDeActiveFromMobile = userVm.CallerIdDeActiveFromMobile,
						UserCIds = userVm.UserCIds,
						MobHRMLoginMode = userVm.MobHRMLoginMode,
						UserLoginCheckLocationType = userVm.UserLoginCheckLocationType,
						UserLoginCheckLocations = userVm.UserLoginCheckLocations,
						UserCId = userCId,
						ActiveDirectoryUser = userVm.ActiveDirectoryUser,
						ShiftWorkingId = userVm.ShiftWorkingId,
						AppLocationRequired = userVm.AppLocationRequired,
						CrmNotifDeactivInHrm = userVm.CrmNotifDeactivInHrm
					};
					_dbTbl.Users.Add(users);
					_dbTbl.SaveChanges();
					foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))))
					{
						Users_Lang entity = new Users_Lang
						{
							LanguageID = lang.LanguageID,
							UserId = users.UserId,
							FName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
							LName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
							Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
							Nickname = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
							DefCmpPrjTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null)
						};
						_dbTbl.Users_Lang.Add(entity);
						_dbTbl.SaveChanges();
					}
					if (userVm.AccessAllLanguage)
					{
						foreach (Languages item in CRMIdeal.Cache.Setting.Language.Get())
						{
							UserLanguages entity2 = new UserLanguages
							{
								LanguageID = item.LanguageID,
								UserId = users.UserId,
								AppType = Configuration.AppType,
								GUId = System.Guid.NewGuid(),
								Year1 = short.Parse(Financial.Get().Id.ToString()),
								Month1 = short.Parse(now.ToString("MM", new PersianCulture())),
								IsActive = true,
								RegisterDate = now,
								RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
								LanguageDirection = item.LanguageDirection,
								UserId1 = userId,
								FirstRegisterDate = now,
								FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
								FirstRegisterUserId = userId
							};
							_dbTbl.UserLanguages.Add(entity2);
							_dbTbl.SaveChanges();
						}
					}
					else
					{
						string languageDirection = "";
						Languages languages = Enumerable.FirstOrDefault<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID == defLangID));
						if (languages != null)
						{
							languageDirection = languages.LanguageDirection;
						}
						UserLanguages entity3 = new UserLanguages
						{
							LanguageID = defLangID,
							UserId = users.UserId,
							AppType = Configuration.AppType,
							GUId = System.Guid.NewGuid(),
							Year1 = short.Parse(Financial.Get().Id.ToString()),
							Month1 = short.Parse(now.ToString("MM", new PersianCulture())),
							IsActive = true,
							RegisterDate = now,
							RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
							LanguageDirection = languageDirection,
							UserId1 = userId,
							FirstRegisterDate = now,
							FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
							FirstRegisterUserId = userId
						};
						_dbTbl.UserLanguages.Add(entity3);
						_dbTbl.SaveChanges();
					}
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("Users");
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("UserLanguages", users.UserId);
					if (users.UserId > 0)
					{
						int userId2 = UserLogin.CurrentUser.UserId;
						short value = short.Parse(now.ToString("MM", new PersianCulture()));
						DateTime value2 = now;
						string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						string appType = Configuration.AppType;
						short value3 = short.Parse(Financial.Get().Id.ToString());
						string[] array3 = null;
						if (!string.IsNullOrWhiteSpace(users.UserCIds))
						{
							array3 = users.UserCIds.Split(new char[1] { ',' });
						}
						if (array3 != null && array3.Length != 0)
						{
							string[] array2 = array3;
							foreach (string text4 in array2)
							{
								if (string.IsNullOrWhiteSpace(text4))
								{
									continue;
								}
								int result14 = 0;
								int.TryParse(text4, out result14);
								if (result14 != 0)
								{
									if (userVm.AccessOtherUsersCmpInfo.HasValue && userVm.AccessOtherUsersCmpInfo.GetValueOrDefault())
									{
										db.CRMspInsertCrmLinkedUserToAllUsers(14, users.UserId, userId2, value3, value, value2, registerDatePersian, appType, defLangID, result14);
									}
									if (userVm.AccessOtherUsersPrsInfo.HasValue && userVm.AccessOtherUsersPrsInfo.GetValueOrDefault())
									{
										db.CRMspInsertCrmLinkedUserToAllUsers(23, users.UserId, userId2, value3, value, value2, registerDatePersian, appType, defLangID, result14);
									}
									if (userVm.AccessOtherUsersPrjInfo.HasValue && userVm.AccessOtherUsersPrjInfo.GetValueOrDefault())
									{
										db.CRMspInsertCrmLinkedUserToAllUsers(24, users.UserId, userId2, value3, value, value2, registerDatePersian, appType, defLangID, result14);
									}
									if (userVm.AccessOtherUsersCnvsInfo.HasValue && userVm.AccessOtherUsersCnvsInfo.GetValueOrDefault())
									{
										db.CRMspInsertCrmLinkedUserToAllUsers(25, users.UserId, userId2, value3, value, value2, registerDatePersian, appType, defLangID, result14);
									}
								}
							}
						}
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmLinkedUsers", users.UserId);
						DateTime value4 = now;
						string registerDatePersian2 = value4.ToString("yyyyMMdd", new PersianCulture());
						short value5 = short.Parse(value4.ToString("MM", new PersianCulture()));
						string appType2 = Configuration.AppType;
						short.Parse(Financial.Get().Id.ToString());
						int userId3 = UserLogin.CurrentUser.UserId;
						int id = Financial.Get().Id;
						if (userVm.AccessPreOrderType.GetValueOrDefault())
						{
							_dbII.WSspInsertPreOrderTypeUserAccessAll(users.UserId.ToString(), userId3, id, value5, value4, registerDatePersian2, appType2, defLangID);
							CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSPreOrderTypeUserAccess");
						}
						if (userVm.AccessOrderOpr.GetValueOrDefault())
						{
							_dbII.WSspInsertOrderOprUserAccessAll(users.UserId.ToString(), userId3, id, value5, value4, registerDatePersian2, appType2, defLangID);
							CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSOrderOprUserAccess");
						}
						if (userVm.AccessBuyOrderOpr.GetValueOrDefault())
						{
							_dbII.WSspInsertBuyOrderOprUserAccessAll(users.UserId.ToString(), userId3, id, value5, value4, registerDatePersian2, appType2, defLangID);
							CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSBuyOrderOprUserAccess");
						}
					}
					if (users.PositionId > 0)
					{
						DateTime value6 = now;
						string registerDatePersian3 = now.ToString("yyyyMMdd", new PersianCulture());
						short value7 = short.Parse(now.ToString("MM", new PersianCulture()));
						string appType3 = Configuration.AppType;
						short value8 = short.Parse(Financial.Get().Id.ToString());
						int userId4 = UserLogin.CurrentUser.UserId;
						string[] array4 = null;
						if (!string.IsNullOrWhiteSpace(users.UserCIds))
						{
							array4 = users.UserCIds.Split(new char[1] { ',' });
						}
						if (array4 != null && array4.Length != 0)
						{
							string[] array2 = array4;
							foreach (string text5 in array2)
							{
								if (!string.IsNullOrWhiteSpace(text5))
								{
									int result15 = 0;
									int.TryParse(text5, out result15);
									if (result15 != 0)
									{
										db.CRMspInsertLinkedUserPositionsByUserId(users.UserId, users.PositionId, userId4, value8, value7, value6, registerDatePersian3, appType3, defLangID, result15);
									}
								}
							}
						}
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmLinkedUsers");
					}
					if (!string.IsNullOrWhiteSpace(users.UserCIds) && VersionBuyer.Center)
					{
						DateTime value9 = now;
						string registerDatePersian4 = now.ToString("yyyyMMdd", new PersianCulture());
						short value10 = short.Parse(now.ToString("MM", new PersianCulture()));
						string appType4 = Configuration.AppType;
						short value11 = short.Parse(Financial.Get().Id.ToString());
						int userId5 = UserLogin.CurrentUser.UserId;
						_dbII.CRMspInsertCenterLinkedByUserId(users.UserId, 0, users.UserCId.GetValueOrDefault(), userId5, value11, value10, value9, registerDatePersian4, appType4, defLangID);
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmLinkedUsers");
					}
					userVm.StartDatePersian = (userVm.StartDate.HasValue ? userVm.StartDate.Value.ToString("yyyy/MM/dd") : "");
					userVm.ExpireDatePersian = (userVm.ExpireDate.HasValue ? userVm.ExpireDate.Value.ToString("yyyy/MM/dd") : "");
					base.ViewBag.SuccessfullInsert = Messages.frmFormBaseInsertSuccessFulMessage;
				}
			}
			else
			{
				text = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
		}
		catch (DbEntityValidationException e4)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e4);
			text = Messages.frmErrorMessage;
		}
		catch (Exception e5)
		{
			ErrorSignal.FromCurrentContext().Raise(e5);
			text = Messages.frmErrorMessage;
		}
		base.ViewBag.Error = text;
		UserFullcombo();
		return View(userVm);
	}

	public string ChkBeforeSubmitUser(UsersViewModel uSer, List<CommonMultiLanguageViewModel> listModelObj_LName_Lang, ref int countError)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		if (string.IsNullOrEmpty(uSer.LName))
		{
			text = text + Messages.CheckUserLName + "<br>";
			countError++;
		}
		else if (!checkMultiLanguage(uSer.LName, listModelObj_LName_Lang))
		{
			text = text + Messages.CheckUserLNameLang + "<br>";
			countError++;
		}
		if (string.IsNullOrEmpty(uSer.VmUName))
		{
			text = text + Messages.CheckUserName + "<br>";
			countError++;
		}
		if (string.IsNullOrEmpty(uSer.VmPword))
		{
			text = text + Messages.CheckUserPassword + "<br>";
			countError++;
		}
		if (Enumerable.FirstOrDefault<CRMspCheckDuplicateUserName_Result>((IEnumerable<CRMspCheckDuplicateUserName_Result>)dbI.CRMspCheckDuplicateUserName(uSer.VmUName, uSer.UserId, lCID, result)) == null)
		{
			return text;
		}
		text = text + Messages.msgErrorUsernameIsDuplicate + "<br>";
		countError++;
		return text;
	}

	private void UserFullcombo()
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
		List<SelectListItem> list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectUserDepartments_Result, SelectListItem>((IEnumerable<CRMspSelectUserDepartments_Result>)Enumerable.ToList<CRMspSelectUserDepartments_Result>((IEnumerable<CRMspSelectUserDepartments_Result>)db.CRMspSelectUserDepartments(lCID, result, result2)), (Func<CRMspSelectUserDepartments_Result, SelectListItem>)((CRMspSelectUserDepartments_Result item) => new SelectListItem
		{
			Text = item.Department,
			Value = item.DepartmentID.ToString(),
			Selected = false
		})));
		base.ViewBag.DepartmentList = list;
		List<CRMspSelectUsers_Result> list2 = CRMIdeal.Classes.Helper.User.SelectUsers();
		if (list2 != null && Enumerable.Any<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)list2))
		{
			list2 = Enumerable.ToList<CRMspSelectUsers_Result>(Enumerable.Where<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)list2, (Func<CRMspSelectUsers_Result, bool>)((CRMspSelectUsers_Result c) => c.IsActive.GetValueOrDefault())));
			if (list2 == null)
			{
				list2 = new List<CRMspSelectUsers_Result>();
			}
		}
		List<SelectListItem> list3 = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectUsers_Result, SelectListItem>((IEnumerable<CRMspSelectUsers_Result>)list2, (Func<CRMspSelectUsers_Result, SelectListItem>)((CRMspSelectUsers_Result item) => new SelectListItem
		{
			Text = item.LName + " " + item.FName,
			Value = item.UserId.ToString(),
			Selected = false
		})));
		base.ViewBag.ResponsibleList = list3;
		List<SelectListItem> list4 = new List<SelectListItem>
		{
			new SelectListItem
			{
				Text = Labels.HrmLoginWithScan,
				Value = "1",
				Selected = false
			},
			new SelectListItem
			{
				Text = Labels.HrmLoginWioutScan,
				Value = "2",
				Selected = false
			}
		};
		base.ViewBag.HrmLoginMode = list4;
		List<SelectListItem> list5 = new List<SelectListItem>
		{
			new SelectListItem
			{
				Text = Labels.HrmLocationCheckWithCmpLoc,
				Value = "1",
				Selected = false
			},
			new SelectListItem
			{
				Text = Labels.HrmLocationCheckWithUserLoc,
				Value = "2",
				Selected = false
			}
		};
		base.ViewBag.HrmCheckLocationType = list5;
		List<SelectListItem> list6 = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectShiftWorkings_Result, SelectListItem>((IEnumerable<CRMspSelectShiftWorkings_Result>)Enumerable.ToList<CRMspSelectShiftWorkings_Result>((IEnumerable<CRMspSelectShiftWorkings_Result>)_dbII.CRMspSelectShiftWorkings(lCID, result)), (Func<CRMspSelectShiftWorkings_Result, SelectListItem>)((CRMspSelectShiftWorkings_Result item) => new SelectListItem
		{
			Text = item.swTitle,
			Value = item.ShiftWorkingID.ToString(),
			Selected = false
		})));
		base.ViewBag.ShiftWorks = list6;
	}

	[AjaxOnly]
	public JsonResult GetUserGroup()
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
			List<CRMspSelectUserGroups_Result> list2 = Enumerable.ToList<CRMspSelectUserGroups_Result>((IEnumerable<CRMspSelectUserGroups_Result>)db.CRMspSelectUserGroups(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectUserGroups_Result, SelectListItem>((IEnumerable<CRMspSelectUserGroups_Result>)list2, (Func<CRMspSelectUserGroups_Result, SelectListItem>)((CRMspSelectUserGroups_Result item) => new SelectListItem
			{
				Text = item.GroupName,
				Value = item.UserGroupId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.UserGroupList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmDefineUsers", ActionName = "actEdit")]
	public ActionResult UserDefineEdit(int uId)
	{
		//IL_0744: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass25_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass25_0();
		CS_0024_003C_003E8__locals0.uId = uId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		DbSet<Users_Lang> users_Lang = _dbTbl.Users_Lang;
		ParameterExpression val = Expression.Parameter(typeof(Users_Lang), "c");
		List<Users_Lang> list = Enumerable.ToList<Users_Lang>((IEnumerable<Users_Lang>)Queryable.Where<Users_Lang>((IQueryable<Users_Lang>)users_Lang, Expression.Lambda<Func<Users_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass25_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
		GetUserGroup();
		CS_0024_003C_003E8__locals0.userLastCId = 0;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out CS_0024_003C_003E8__locals0.userLastCId);
		}
		Users users = _dbTbl.Users.Find(CS_0024_003C_003E8__locals0.uId);
		List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<Users_Lang, CommonMultiLanguageViewModel>((IEnumerable<Users_Lang>)list, (Func<Users_Lang, CommonMultiLanguageViewModel>)((Users_Lang item) => new CommonMultiLanguageViewModel
		{
			Value = item.FName,
			LanguageId = item.LanguageID
		})));
		list2.Add(new CommonMultiLanguageViewModel
		{
			Value = users.FName,
			LanguageId = result
		});
		List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<Users_Lang, CommonMultiLanguageViewModel>((IEnumerable<Users_Lang>)list, (Func<Users_Lang, CommonMultiLanguageViewModel>)((Users_Lang item) => new CommonMultiLanguageViewModel
		{
			Value = item.LName,
			LanguageId = item.LanguageID
		})));
		list3.Add(new CommonMultiLanguageViewModel
		{
			Value = users.LName,
			LanguageId = result
		});
		List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<Users_Lang, CommonMultiLanguageViewModel>((IEnumerable<Users_Lang>)list, (Func<Users_Lang, CommonMultiLanguageViewModel>)((Users_Lang item) => new CommonMultiLanguageViewModel
		{
			Value = item.Description,
			LanguageId = item.LanguageID
		})));
		list4.Add(new CommonMultiLanguageViewModel
		{
			Value = users.Description,
			LanguageId = result
		});
		List<CommonMultiLanguageViewModel> list5 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<Users_Lang, CommonMultiLanguageViewModel>((IEnumerable<Users_Lang>)list, (Func<Users_Lang, CommonMultiLanguageViewModel>)((Users_Lang item) => new CommonMultiLanguageViewModel
		{
			Value = item.Nickname,
			LanguageId = item.LanguageID
		})));
		list5.Add(new CommonMultiLanguageViewModel
		{
			Value = users.Nickname,
			LanguageId = result
		});
		List<CommonMultiLanguageViewModel> list6 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<Users_Lang, CommonMultiLanguageViewModel>((IEnumerable<Users_Lang>)list, (Func<Users_Lang, CommonMultiLanguageViewModel>)((Users_Lang item) => new CommonMultiLanguageViewModel
		{
			Value = item.DefCmpPrjTitle,
			LanguageId = item.LanguageID
		})));
		list6.Add(new CommonMultiLanguageViewModel
		{
			Value = users.DefCmpPrjTitle,
			LanguageId = result
		});
		UsersViewModel usersViewModel = new UsersViewModel();
		if (users == null)
		{
			usersViewModel = new UsersViewModel
			{
				UserId1 = UserLogin.CurrentUser.UserId,
				Month1 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture())),
				RegisterDate = DateTime.Now,
				RegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture()),
				UserId = CS_0024_003C_003E8__locals0.uId
			};
		}
		else
		{
			usersViewModel = new UsersViewModel
			{
				UserId = users.UserId,
				Row = users.Row,
				PersCode = users.PersCode,
				VmUName = users.UserName,
				IsAdmin = users.IsAdmin,
				VmPword = users.Password,
				VmVerifyPword = users.Password,
				IsActive = users.IsActive,
				UserIsActiveInWinApp = users.UserIsActiveInWinApp,
				UserIsActiveInWebApp = users.UserIsActiveInWebApp,
				UserIsActiveInMobApp = users.UserIsActiveInMobApp,
				UserIsActiveInFOSetting = users.UserIsActiveInFOSetting,
				UserAccessDailyChrtAllUsers = users.UserAccessDailyChrtAllUsers,
				UserAccessSaleChrtAllUsers = users.UserAccessSaleChrtAllUsers,
				MobDeActiveAccessToLocation = users.MobDeActiveAccessToLocation,
				UserId1 = users.UserId1,
				Month1 = users.Month1,
				RegisterDate = users.RegisterDate,
				RegisterDatePersian = users.RegisterDatePersian,
				FName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				LName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				FName_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				LName_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				Description_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				MaxNumberCmpDraft = users.MaxNumberCmpDraft,
				LinkAccUserCode = users.LinkAccUserCode,
				LinkAccUserIdStr = users.LinkAccUserIdStr,
				Nickname = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				Nickname_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				DefCmpPrjTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				DefCmpPrjTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				MobDeActiveScreenshot = users.MobDeActiveScreenshot,
				MobCallerIdDeActive = users.MobCallerIdDeActive,
				MobUserAppUseCnt = users.MobUserAppUseCnt,
				MobHRMUserAppUseCnt = users.MobHRMUserAppUseCnt,
				UserIsActiveInCIC = users.UserIsActiveInCIC,
				MobCICUserAppUseCnt = users.MobCICUserAppUseCnt,
				CallerIdDeActiveFromMobile = users.CallerIdDeActiveFromMobile,
				UserCIds = users.UserCIds,
				ActiveDirectoryUser = users.ActiveDirectoryUser,
				ShiftWorkingId = users.ShiftWorkingId,
				AppLocationRequired = users.AppLocationRequired,
				CrmNotifDeactivInHrm = users.CrmNotifDeactivInHrm
			};
			if (!string.IsNullOrEmpty(usersViewModel.RegisterDatePersian))
			{
				usersViewModel.RegisterDatePersian = usersViewModel.RegisterDatePersian.Insert(4, "/");
				usersViewModel.RegisterDatePersian = usersViewModel.RegisterDatePersian.Insert(7, "/");
			}
			usersViewModel.IPAddress = users.IPAddress;
			usersViewModel.Tel = users.Tel;
			usersViewModel.TelDesc = users.TelDesc;
			usersViewModel.PositionId = users.PositionId;
			usersViewModel.PositionIdTitle = "";
			usersViewModel.SignatureId = users.SignatureId;
			usersViewModel.DepartmentInfo = users.DepartmentInfo;
			if (!string.IsNullOrWhiteSpace(usersViewModel.DepartmentInfo))
			{
				List<UserDepartmentInfoViewModel> list7 = new JavaScriptSerializer().Deserialize<List<UserDepartmentInfoViewModel>>(usersViewModel.DepartmentInfo);
				if (list7 != null && Enumerable.Any<UserDepartmentInfoViewModel>((IEnumerable<UserDepartmentInfoViewModel>)list7))
				{
					UserDepartmentInfoViewModel userDepartmentInfoViewModel = new UserDepartmentInfoViewModel();
					userDepartmentInfoViewModel = ((CS_0024_003C_003E8__locals0.userLastCId == 0) ? Enumerable.FirstOrDefault<UserDepartmentInfoViewModel>((IEnumerable<UserDepartmentInfoViewModel>)list7) : Enumerable.FirstOrDefault<UserDepartmentInfoViewModel>((IEnumerable<UserDepartmentInfoViewModel>)list7, (Func<UserDepartmentInfoViewModel, bool>)((UserDepartmentInfoViewModel m) => m.CId.GetValueOrDefault() == CS_0024_003C_003E8__locals0.userLastCId)));
					if (userDepartmentInfoViewModel != null)
					{
						int result2 = 0;
						int.TryParse(userDepartmentInfoViewModel.DPId.ToString(), out result2);
						if (result2 != 0)
						{
							usersViewModel.DepartmentId = result2;
						}
					}
				}
			}
			usersViewModel.DepartmentIdTitle = "";
			usersViewModel.ResponsibleUserId = users.ResponsibleUserId;
			CRMspSelectUsersById_Result cRMspSelectUsersById_Result = CRMIdeal.Classes.Helper.User.SelectUsersById(users.ResponsibleUserId.GetValueOrDefault());
			usersViewModel.ResponsibleUserIdTitle = ((cRMspSelectUsersById_Result != null) ? (cRMspSelectUsersById_Result.FullName ?? "") : "");
			usersViewModel.ComputerName = users.ComputerName;
			usersViewModel.GUId = users.GUId;
			usersViewModel.CallreIdDeActive = users.CallreIdDeActive;
			usersViewModel.CallreIdDeActiveLines = users.CallreIdDeActiveLines;
			usersViewModel.DisableInternalMessageAllarmVoice = users.DisableInternalMessageAllarmVoice;
			usersViewModel.DisableReceiveCNVSInfoAllarm = users.DisableReceiveCNVSInfoAllarm;
			usersViewModel.EmailAttachFileLocation = users.EmailAttachFileLocation;
			usersViewModel.AllowCopyOtherLanguage = users.AllowCopyOtherLanguage;
			usersViewModel.DeActiveSmartTimeAttendance = users.DeActiveSmartTimeAttendance;
			usersViewModel.MobImeiCode = users.MobImeiCode;
			usersViewModel.DeActiveLoginWithoutShift = users.DeActiveLoginWithoutShift;
			usersViewModel.UserIsActiveInHRM = users.UserIsActiveInHRM;
			usersViewModel.MobHRMImeiCode = users.MobHRMImeiCode;
			usersViewModel.ActiveMobMovementTracking = users.ActiveMobMovementTracking;
			usersViewModel.MobMovementTrackingDistanceInterval = users.MobMovementTrackingDistanceInterval;
			usersViewModel.MobMovementTrackingTimeInterval = users.MobMovementTrackingTimeInterval;
			usersViewModel.StartDate = users.StartDate;
			usersViewModel.StartDatePersian = (users.StartDate.HasValue ? users.StartDate.Value.ToString("yyyy/MM/dd") : "");
			usersViewModel.ExpireDate = users.ExpireDate;
			usersViewModel.ExpireDatePersian = (users.ExpireDate.HasValue ? users.ExpireDate.Value.ToString("yyyy/MM/dd") : "");
			usersViewModel.UserGroupId = users.UserGroupId;
			usersViewModel.UserExtensions = users.UserExtensions;
			usersViewModel.CallPreNumber = users.CallPreNumber;
			usersViewModel.MobHRMLoginMode = users.MobHRMLoginMode.GetValueOrDefault(1);
			usersViewModel.UserLoginCheckLocationType = users.UserLoginCheckLocationType.GetValueOrDefault(1);
			usersViewModel.UserLoginCheckLocations = users.UserLoginCheckLocations;
			if (usersViewModel.VmUName == "adm")
			{
				usersViewModel.ShowBtnEditAdmPassword = true;
			}
			usersViewModel.AppLocationRequired = users.AppLocationRequired;
			usersViewModel.CrmNotifDeactivInHrm = users.CrmNotifDeactivInHrm;
		}
		UserFullcombo();
		return View(usersViewModel);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	[DynamicAuthorize(ControllerName = "frmDefineUsers", ActionName = "actEdit")]
	public ActionResult UserDefineEdit(UsersViewModel userVm)
	{
		//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_022f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0274: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b9: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		GetUserGroup();
		string text = "";
		int countError = 0;
		BaseInfo baseInfo = new BaseInfo();
		try
		{
			bool result = false;
			bool.TryParse(userVm.IsActive.ToString(), out result);
			bool result2 = false;
			bool.TryParse(userVm.UserIsActiveInWinApp.ToString(), out result2);
			bool result3 = false;
			bool.TryParse(userVm.UserIsActiveInWebApp.ToString(), out result3);
			bool result4 = false;
			bool.TryParse(userVm.UserIsActiveInMobApp.ToString(), out result4);
			bool result5 = false;
			bool.TryParse(userVm.UserIsActiveInHRM.ToString(), out result5);
			bool result6 = false;
			bool.TryParse(userVm.UserIsActiveInCIC.ToString(), out result6);
			if (!result)
			{
				userVm.UserIsActiveInWinApp = false;
				userVm.UserIsActiveInWebApp = false;
				userVm.UserIsActiveInMobApp = false;
				userVm.UserIsActiveInHRM = false;
				userVm.UserIsActiveInCIC = false;
			}
			if (result2 || result3 || result4 || result6 || result5)
			{
				userVm.IsActive = true;
			}
			if (base.ModelState.IsValid)
			{
				List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(userVm.FName_Lang))
				{
					list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(userVm.FName_Lang);
				}
				list.Add(new CommonMultiLanguageViewModel
				{
					Value = userVm.FName,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(userVm.LName_Lang))
				{
					list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(userVm.LName_Lang);
				}
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = userVm.LName,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(userVm.Description_Lang))
				{
					list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(userVm.Description_Lang);
				}
				list3.Add(new CommonMultiLanguageViewModel
				{
					Value = userVm.Description,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(userVm.Nickname_Lang))
				{
					list4 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(userVm.Nickname_Lang);
				}
				list4.Add(new CommonMultiLanguageViewModel
				{
					Value = userVm.Nickname,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list5 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(userVm.DefCmpPrjTitle_Lang))
				{
					list5 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(userVm.DefCmpPrjTitle_Lang);
				}
				list5.Add(new CommonMultiLanguageViewModel
				{
					Value = userVm.DefCmpPrjTitle,
					LanguageId = lCID
				});
				if (userVm.UserId > 0)
				{
					_003C_003Ec__DisplayClass26_1 _003C_003Ec__DisplayClass26_ = new _003C_003Ec__DisplayClass26_1();
					text = ChkBeforeSubmitUser(userVm, list2, ref countError);
					DateTime dateTime = default(DateTime);
					string text2 = "";
					try
					{
						if (!string.IsNullOrEmpty(userVm.StartDatePersian))
						{
							text2 = PersianDate.GetFormatetdDate(userVm.StartDatePersian.Replace("/", ""));
							switch (lCID)
							{
							case 1065:
								dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
								userVm.StartDatePersian = dateTime.ToString("yyyyMMdd");
								break;
							case 1025:
								dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
								userVm.StartDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
								break;
							default:
								dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
								userVm.StartDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
								break;
							}
							userVm.StartDate = dateTime;
						}
						else
						{
							userVm.StartDate = null;
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						text += string.Format(Messages.ErrorInFormat, Labels.UserStartDate);
						countError++;
					}
					if (userVm.StartDatePersian != null)
					{
						userVm.StartDatePersian = userVm.StartDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
							.Replace(".", "")
							.Replace(",", "")
							.Replace("\\", "");
					}
					dateTime = default(DateTime);
					text2 = "";
					try
					{
						if (!string.IsNullOrEmpty(userVm.ExpireDatePersian))
						{
							text2 = PersianDate.GetFormatetdDate(userVm.ExpireDatePersian.Replace("/", ""));
							switch (lCID)
							{
							case 1065:
								dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
								userVm.ExpireDatePersian = dateTime.ToString("yyyyMMdd");
								break;
							case 1025:
								dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
								userVm.ExpireDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
								break;
							default:
								dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
								userVm.ExpireDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
								break;
							}
							userVm.ExpireDate = dateTime;
						}
						else
						{
							userVm.ExpireDate = null;
						}
					}
					catch (Exception e2)
					{
						ErrorSignal.FromCurrentContext().Raise(e2);
						text += string.Format(Messages.ErrorInFormat, Labels.UserExpireDate);
						countError++;
					}
					if (userVm.ExpireDatePersian != null)
					{
						userVm.ExpireDatePersian = userVm.ExpireDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
							.Replace(".", "")
							.Replace(",", "")
							.Replace("\\", "");
					}
					_003C_003Ec__DisplayClass26_.uSer = _dbTbl.Users.Find(userVm.UserId);
					if (_003C_003Ec__DisplayClass26_.uSer != null)
					{
						if (_003C_003Ec__DisplayClass26_.uSer.UserName == "adm" && userVm.VmUName != "adm")
						{
							countError++;
							text = text + Messages.msgErrorDefineEditUserNameIsNotEdiable + "<br>";
						}
						if (_003C_003Ec__DisplayClass26_.uSer.UserName == "adm" && !userVm.CanEditAdmPassword.GetValueOrDefault() && _003C_003Ec__DisplayClass26_.uSer.Password != userVm.VmPword)
						{
							countError++;
							text = text + Messages.msgErrorDefineEditUserPasswordIsNotEdiable + "<br>";
						}
						bool result7 = false;
						bool.TryParse(userVm.IsActive.ToString(), out result7);
						bool result8 = false;
						bool.TryParse(_003C_003Ec__DisplayClass26_.uSer.IsActive.ToString(), out result8);
						bool result9 = false;
						bool.TryParse(userVm.UserIsActiveInWebApp.ToString(), out result9);
						bool result10 = false;
						bool.TryParse(_003C_003Ec__DisplayClass26_.uSer.UserIsActiveInWebApp.ToString(), out result10);
						int maxCountOfOnlineUser = Configuration.MaxCountOfOnlineUser;
						if (result7 && !result8)
						{
							try
							{
								int num = 0;
								int num2 = 0;
								num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)dbI.CRMspReturnActiveUsersCount()).GetValueOrDefault();
								num2 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)dbI.CRMspReturnActiveUsersInWebAppCount()).GetValueOrDefault();
								int num3 = 50;
								int num4 = Configuration.MaxCountOfOnlineUser + Configuration.MaxCountOfOnlineUserDeActive;
								if (VersionBuyer.Enterprise)
								{
									num3 = Configuration.MaxCountOfOnlineUser;
								}
								if (result7)
								{
									if (num4 <= num)
									{
										countError++;
										text = text + Messages.msgErrorFinishingUserDefinitionCapacity + "<br>";
									}
									if (result9 && !result10 && maxCountOfOnlineUser <= num2)
									{
										countError++;
										if (text.IndexOf(Messages.msgErrorFinishingUserDefinitionCapacity, StringComparison.Ordinal) < 0)
										{
											text = text + Messages.msgErrorFinishingUserDefinitionCapacity + "<br>";
										}
									}
									if (num3 <= num2)
									{
										countError++;
										if (text.IndexOf(Messages.msgErrorFinishingUserDefinitionCapacity, StringComparison.Ordinal) < 0)
										{
											text = text + Messages.msgErrorFinishingUserDefinitionCapacity + "<br>";
										}
									}
								}
							}
							catch (Exception e3)
							{
								ErrorSignal.FromCurrentContext().Raise(e3);
							}
						}
						if (result9 && !result10)
						{
							int num5 = 0;
							num5 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)dbI.CRMspReturnActiveUsersInWebAppCount()).GetValueOrDefault();
							if (maxCountOfOnlineUser <= num5)
							{
								countError++;
								if (text.IndexOf(Messages.msgErrorFinishingUserDefinitionCapacity, StringComparison.Ordinal) < 0)
								{
									text = text + Messages.msgErrorFinishingUserDefinitionCapacity + "<br>";
								}
							}
						}
						bool result11 = false;
						bool.TryParse(_003C_003Ec__DisplayClass26_.uSer.UserIsActiveInWebApp.ToString(), out result11);
						bool result12 = false;
						bool.TryParse(_003C_003Ec__DisplayClass26_.uSer.UserIsActiveInMobApp.ToString(), out result12);
						bool result13 = false;
						bool.TryParse(userVm.UserIsActiveInWebApp.ToString(), out result13);
						bool result14 = false;
						bool.TryParse(userVm.UserIsActiveInMobApp.ToString(), out result14);
						_ = Configuration.MaxCountOfOnlineUser;
						int maxCountOfOnlineUserInMob = Configuration.MaxCountOfOnlineUserInMob;
						if (!result14)
						{
							userVm.MobUserAppUseCnt = null;
						}
						int valueOrDefault = _003C_003Ec__DisplayClass26_.uSer.MobUserAppUseCnt.GetValueOrDefault();
						int valueOrDefault2 = userVm.MobUserAppUseCnt.GetValueOrDefault();
						if (valueOrDefault != valueOrDefault2 && userVm.UserId > 0)
						{
							int valueOrDefault3 = _003C_003Ec__DisplayClass26_.uSer.MobUserAppUseCnt.GetValueOrDefault();
							if (Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)dbI.CRMspReturnSumMobUserAppUseCnt()).GetValueOrDefault() - valueOrDefault3 + userVm.MobUserAppUseCnt.GetValueOrDefault() > maxCountOfOnlineUserInMob)
							{
								countError++;
								text = text + string.Format(Messages.msgErrorDefineEditUserAppUseCntMoreThenMaxCountAllowedInMob, maxCountOfOnlineUserInMob.ToString()) + "<br>";
							}
						}
						if (!result14 || (valueOrDefault > valueOrDefault2 && userVm.UserId > 0))
						{
							dbI.CRMspDeactiveExtraUserAppDeviceInfo(userVm.MobUserAppUseCnt.GetValueOrDefault(), userVm.UserId, Configuration.MobAppProjectName);
						}
						bool result15 = false;
						bool.TryParse(_003C_003Ec__DisplayClass26_.uSer.UserIsActiveInHRM.ToString(), out result15);
						bool result16 = false;
						bool.TryParse(userVm.UserIsActiveInHRM.ToString(), out result16);
						int maxCountOfOnlineUserInHrm = Configuration.MaxCountOfOnlineUserInHrm;
						if (!result16)
						{
							userVm.MobHRMUserAppUseCnt = null;
						}
						int valueOrDefault4 = _003C_003Ec__DisplayClass26_.uSer.MobHRMUserAppUseCnt.GetValueOrDefault();
						int valueOrDefault5 = userVm.MobHRMUserAppUseCnt.GetValueOrDefault();
						if (valueOrDefault4 != valueOrDefault5)
						{
							int valueOrDefault6 = _003C_003Ec__DisplayClass26_.uSer.MobHRMUserAppUseCnt.GetValueOrDefault();
							if (Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)dbI.CRMspReturnSumMobHRMUserAppUseCnt()).GetValueOrDefault() - valueOrDefault6 + userVm.MobHRMUserAppUseCnt.GetValueOrDefault() > maxCountOfOnlineUserInHrm)
							{
								countError++;
								text = text + string.Format(Messages.msgErrorDefineEditUserAppUseCntMoreThenMaxCountAllowedInHrm, maxCountOfOnlineUserInHrm.ToString()) + "<br>";
							}
						}
						if (!result16 || valueOrDefault4 > valueOrDefault5)
						{
							dbI.CRMspDeactiveExtraUserAppDeviceInfo(userVm.MobHRMUserAppUseCnt.GetValueOrDefault(), userVm.UserId, Configuration.MobHRMAppProjectName);
						}
						bool result17 = false;
						bool.TryParse(_003C_003Ec__DisplayClass26_.uSer.UserIsActiveInCIC.ToString(), out result17);
						bool result18 = false;
						bool.TryParse(userVm.UserIsActiveInCIC.ToString(), out result18);
						int maxCountCic = Configuration.MaxCountCic;
						if (!result18)
						{
							userVm.MobCICUserAppUseCnt = null;
						}
						int valueOrDefault7 = _003C_003Ec__DisplayClass26_.uSer.MobCICUserAppUseCnt.GetValueOrDefault();
						int valueOrDefault8 = userVm.MobCICUserAppUseCnt.GetValueOrDefault();
						if (valueOrDefault7 != valueOrDefault8)
						{
							int valueOrDefault9 = _003C_003Ec__DisplayClass26_.uSer.MobCICUserAppUseCnt.GetValueOrDefault();
							if (Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)dbI.CRMspReturnSumMobCICUserAppUseCnt()).GetValueOrDefault() - valueOrDefault9 + userVm.MobCICUserAppUseCnt.GetValueOrDefault() > maxCountCic)
							{
								countError++;
								text = text + string.Format(Messages.msgErrorDefineEditUserAppUseCntMoreThenMaxCountAllowedInCic, maxCountCic.ToString()) + "<br>";
							}
						}
						if (!result18 || valueOrDefault7 > valueOrDefault8)
						{
							dbI.CRMspDeactiveExtraUserAppDeviceInfo(userVm.MobCICUserAppUseCnt.GetValueOrDefault(), userVm.UserId, Configuration.MobCICAppProjectName);
						}
						if (countError == 0)
						{
							DateTime now = DateTime.Now;
							if (VersionBuyer.LinkAcc)
							{
								if (string.IsNullOrWhiteSpace(_003C_003Ec__DisplayClass26_.uSer.LinkAccUserCode) && string.IsNullOrWhiteSpace(_003C_003Ec__DisplayClass26_.uSer.LinkAccUserIdStr))
								{
									_003C_003Ec__DisplayClass26_.uSer.PersCode = userVm.PersCode;
								}
							}
							else
							{
								_003C_003Ec__DisplayClass26_.uSer.PersCode = userVm.PersCode;
							}
							if (_003C_003Ec__DisplayClass26_.uSer.UserName != "adm" || userVm.CanEditAdmPassword.GetValueOrDefault())
							{
								_003C_003Ec__DisplayClass26_.uSer.UserName = userVm.VmUName;
								if (_003C_003Ec__DisplayClass26_.uSer.Password != userVm.VmPword)
								{
									_003C_003Ec__DisplayClass26_.uSer.IsAdmin = baseInfo.ConvertMd5(userVm.VmPword).ToLower() + userVm.VmPword;
									_003C_003Ec__DisplayClass26_.uSer.Password = baseInfo.ConvertMd5(userVm.VmPword).ToLower();
								}
								else
								{
									_003C_003Ec__DisplayClass26_.uSer.IsAdmin = _003C_003Ec__DisplayClass26_.uSer.IsAdmin;
									_003C_003Ec__DisplayClass26_.uSer.Password = _003C_003Ec__DisplayClass26_.uSer.Password;
								}
							}
							_003C_003Ec__DisplayClass26_.uSer.IsActive = userVm.IsActive;
							_003C_003Ec__DisplayClass26_.uSer.UserIsActiveInWinApp = userVm.UserIsActiveInWinApp;
							_003C_003Ec__DisplayClass26_.uSer.UserIsActiveInWebApp = userVm.UserIsActiveInWebApp;
							_003C_003Ec__DisplayClass26_.uSer.UserIsActiveInMobApp = userVm.UserIsActiveInMobApp;
							_003C_003Ec__DisplayClass26_.uSer.UserIsActiveInFOSetting = userVm.UserIsActiveInFOSetting;
							_003C_003Ec__DisplayClass26_.uSer.UserAccessDailyChrtAllUsers = userVm.UserAccessDailyChrtAllUsers;
							_003C_003Ec__DisplayClass26_.uSer.UserAccessSaleChrtAllUsers = userVm.UserAccessSaleChrtAllUsers;
							_003C_003Ec__DisplayClass26_.uSer.MobDeActiveAccessToLocation = userVm.MobDeActiveAccessToLocation;
							_003C_003Ec__DisplayClass26_.uSer.IPAddress = userVm.IPAddress;
							_003C_003Ec__DisplayClass26_.uSer.Tel = userVm.Tel;
							_003C_003Ec__DisplayClass26_.uSer.TelDesc = userVm.TelDesc;
							int? positionId = _003C_003Ec__DisplayClass26_.uSer.PositionId;
							userVm.PositionId = ((userVm.PositionId == 0) ? null : userVm.PositionId);
							_003C_003Ec__DisplayClass26_.uSer.PositionId = userVm.PositionId;
							_003C_003Ec__DisplayClass26_.uSer.SignatureId = userVm.SignatureId;
							_003C_003Ec__DisplayClass26_.uSer.DepartmentInfo = userVm.DepartmentInfo;
							_003C_003Ec__DisplayClass26_.uSer.ResponsibleUserId = userVm.ResponsibleUserId;
							_003C_003Ec__DisplayClass26_.uSer.ComputerName = userVm.ComputerName;
							_003C_003Ec__DisplayClass26_.uSer.CallreIdDeActive = userVm.CallreIdDeActive;
							_003C_003Ec__DisplayClass26_.uSer.CallreIdDeActiveLines = userVm.CallreIdDeActiveLines;
							_003C_003Ec__DisplayClass26_.uSer.DisableInternalMessageAllarmVoice = userVm.DisableInternalMessageAllarmVoice;
							_003C_003Ec__DisplayClass26_.uSer.DisableReceiveCNVSInfoAllarm = userVm.DisableReceiveCNVSInfoAllarm;
							_003C_003Ec__DisplayClass26_.uSer.EmailAttachFileLocation = userVm.EmailAttachFileLocation;
							_003C_003Ec__DisplayClass26_.uSer.AllowCopyOtherLanguage = userVm.AllowCopyOtherLanguage;
							_003C_003Ec__DisplayClass26_.uSer.DeActiveSmartTimeAttendance = userVm.DeActiveSmartTimeAttendance;
							_003C_003Ec__DisplayClass26_.uSer.MobImeiCode = userVm.MobImeiCode;
							_003C_003Ec__DisplayClass26_.uSer.DeActiveLoginWithoutShift = userVm.DeActiveLoginWithoutShift;
							_003C_003Ec__DisplayClass26_.uSer.UserIsActiveInHRM = userVm.UserIsActiveInHRM;
							_003C_003Ec__DisplayClass26_.uSer.MobHRMImeiCode = userVm.MobHRMImeiCode;
							_003C_003Ec__DisplayClass26_.uSer.ActiveMobMovementTracking = userVm.ActiveMobMovementTracking;
							_003C_003Ec__DisplayClass26_.uSer.MobMovementTrackingDistanceInterval = userVm.MobMovementTrackingDistanceInterval;
							_003C_003Ec__DisplayClass26_.uSer.MobMovementTrackingTimeInterval = userVm.MobMovementTrackingTimeInterval;
							_003C_003Ec__DisplayClass26_.uSer.UserId1 = UserLogin.CurrentUser.UserId;
							_003C_003Ec__DisplayClass26_.uSer.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
							_003C_003Ec__DisplayClass26_.uSer.RegisterDate = now;
							_003C_003Ec__DisplayClass26_.uSer.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
							_003C_003Ec__DisplayClass26_.uSer.AppType = Configuration.AppType;
							_003C_003Ec__DisplayClass26_.uSer.FName = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
							_003C_003Ec__DisplayClass26_.uSer.LName = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
							_003C_003Ec__DisplayClass26_.uSer.Description = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
							_003C_003Ec__DisplayClass26_.uSer.MaxNumberCmpDraft = userVm.MaxNumberCmpDraft;
							_003C_003Ec__DisplayClass26_.uSer.Nickname = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
							_003C_003Ec__DisplayClass26_.uSer.DefCmpPrjTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
							_003C_003Ec__DisplayClass26_.uSer.MobDeActiveScreenshot = userVm.MobDeActiveScreenshot;
							_003C_003Ec__DisplayClass26_.uSer.MobCallerIdDeActive = userVm.MobCallerIdDeActive;
							_003C_003Ec__DisplayClass26_.uSer.MobUserAppUseCnt = userVm.MobUserAppUseCnt;
							_003C_003Ec__DisplayClass26_.uSer.MobHRMUserAppUseCnt = userVm.MobHRMUserAppUseCnt;
							_003C_003Ec__DisplayClass26_.uSer.UserIsActiveInCIC = userVm.UserIsActiveInCIC;
							_003C_003Ec__DisplayClass26_.uSer.MobCICUserAppUseCnt = userVm.MobCICUserAppUseCnt;
							_003C_003Ec__DisplayClass26_.uSer.CallerIdDeActiveFromMobile = userVm.CallerIdDeActiveFromMobile;
							_003C_003Ec__DisplayClass26_.uSer.StartDate = userVm.StartDate;
							_003C_003Ec__DisplayClass26_.uSer.StartDatePersian = userVm.StartDatePersian;
							_003C_003Ec__DisplayClass26_.uSer.ExpireDate = userVm.ExpireDate;
							_003C_003Ec__DisplayClass26_.uSer.ExpireDatePersian = userVm.ExpireDatePersian;
							_003C_003Ec__DisplayClass26_.uSer.UserGroupId = userVm.UserGroupId;
							_003C_003Ec__DisplayClass26_.uSer.UserExtensions = userVm.UserExtensions;
							_003C_003Ec__DisplayClass26_.uSer.CallPreNumber = userVm.CallPreNumber;
							string text3 = _003C_003Ec__DisplayClass26_.uSer.UserCIds ?? "";
							string text4 = userVm.UserCIds ?? "";
							_003C_003Ec__DisplayClass26_.uSer.UserCIds = userVm.UserCIds;
							_003C_003Ec__DisplayClass26_.uSer.ActiveDirectoryUser = userVm.ActiveDirectoryUser;
							_003C_003Ec__DisplayClass26_.uSer.AppLocationRequired = userVm.AppLocationRequired;
							_003C_003Ec__DisplayClass26_.uSer.CrmNotifDeactivInHrm = userVm.CrmNotifDeactivInHrm;
							int? userCId = null;
							int num6 = 0;
							int valueOrDefault10 = _003C_003Ec__DisplayClass26_.uSer.UserLastCId.GetValueOrDefault();
							if (!string.IsNullOrWhiteSpace(userVm.UserCIds))
							{
								string[] array = userVm.UserCIds.Split(new char[1] { ',' });
								if (array != null && array.Length != 0)
								{
									string[] array2 = array;
									foreach (string text5 in array2)
									{
										int result19 = 0;
										if (!string.IsNullOrWhiteSpace(text5))
										{
											int.TryParse(text5, out result19);
											if (result19 != 0 && userCId.GetValueOrDefault() == 0)
											{
												userCId = result19;
											}
											if (valueOrDefault10 != 0 && valueOrDefault10 == result19)
											{
												num6 = result19;
											}
										}
									}
								}
							}
							int? userCId2 = _003C_003Ec__DisplayClass26_.uSer.UserCId;
							_003C_003Ec__DisplayClass26_.uSer.UserCId = userCId;
							if (num6 == 0)
							{
								_003C_003Ec__DisplayClass26_.uSer.UserLastCId = _003C_003Ec__DisplayClass26_.uSer.UserCId;
							}
							_003C_003Ec__DisplayClass26_.uSer.MobHRMLoginMode = userVm.MobHRMLoginMode;
							_003C_003Ec__DisplayClass26_.uSer.UserLoginCheckLocationType = userVm.UserLoginCheckLocationType;
							_003C_003Ec__DisplayClass26_.uSer.ShiftWorkingId = userVm.ShiftWorkingId;
							_dbTbl.Entry(_003C_003Ec__DisplayClass26_.uSer).State = EntityState.Modified;
							_dbTbl.SaveChanges();
							using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))).GetEnumerator())
							{
								while (enumerator.MoveNext())
								{
									_003C_003Ec__DisplayClass26_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass26_2();
									CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass26_;
									CS_0024_003C_003E8__locals1.lang = enumerator.Current;
									DbSet<Users_Lang> users_Lang = _dbTbl.Users_Lang;
									ParameterExpression val = Expression.Parameter(typeof(Users_Lang), "c");
									Users_Lang users_Lang2 = Queryable.FirstOrDefault<Users_Lang>((IQueryable<Users_Lang>)users_Lang, Expression.Lambda<Func<Users_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass26_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass26_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
									if (users_Lang2 != null)
									{
										users_Lang2.FName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
										users_Lang2.LName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
										users_Lang2.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
										users_Lang2.Nickname = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
										users_Lang2.DefCmpPrjTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
										_dbTbl.Entry(users_Lang2).State = EntityState.Modified;
										_dbTbl.SaveChanges();
										continue;
									}
									users_Lang2 = new Users_Lang
									{
										LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID,
										UserId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.uSer.UserId,
										FName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
										LName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
										Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
										Nickname = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
										DefCmpPrjTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null)
									};
									_dbTbl.Users_Lang.Add(users_Lang2);
									_dbTbl.SaveChanges();
								}
							}
							CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("Users");
							CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("UserLanguages", _003C_003Ec__DisplayClass26_.uSer.UserId);
							if (_003C_003Ec__DisplayClass26_.uSer.PositionId > 0)
							{
								DateTime value = now;
								string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
								short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
								string appType = Configuration.AppType;
								short value3 = short.Parse(Financial.Get().Id.ToString());
								int userId = UserLogin.CurrentUser.UserId;
								if (positionId.HasValue && positionId != _003C_003Ec__DisplayClass26_.uSer.PositionId)
								{
									string[] array3 = null;
									if (!string.IsNullOrWhiteSpace(_003C_003Ec__DisplayClass26_.uSer.UserCIds))
									{
										array3 = _003C_003Ec__DisplayClass26_.uSer.UserCIds.Split(new char[1] { ',' });
									}
									if (array3 != null && array3.Length != 0)
									{
										string[] array2 = array3;
										foreach (string text6 in array2)
										{
											if (!string.IsNullOrWhiteSpace(text6))
											{
												int result20 = 0;
												int.TryParse(text6, out result20);
												if (result20 != 0)
												{
													db.CRMspTransferUsersToAnotherPosition(positionId, _003C_003Ec__DisplayClass26_.uSer.PositionId, _003C_003Ec__DisplayClass26_.uSer.UserId.ToString(), userId, value, registerDatePersian, value2, appType, result20);
												}
											}
										}
									}
								}
								string[] array4 = null;
								if (!string.IsNullOrWhiteSpace(_003C_003Ec__DisplayClass26_.uSer.UserCIds))
								{
									array4 = _003C_003Ec__DisplayClass26_.uSer.UserCIds.Split(new char[1] { ',' });
								}
								if (array4 != null && array4.Length != 0)
								{
									string[] array2 = array4;
									foreach (string text7 in array2)
									{
										if (!string.IsNullOrWhiteSpace(text7))
										{
											int result21 = 0;
											int.TryParse(text7, out result21);
											if (result21 != 0)
											{
												db.CRMspInsertLinkedUserPositionsByUserId(_003C_003Ec__DisplayClass26_.uSer.UserId, _003C_003Ec__DisplayClass26_.uSer.PositionId, userId, value3, value2, value, registerDatePersian, appType, defLangID, result21);
											}
										}
									}
								}
								CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmLinkedUsers");
							}
							else
							{
								if (positionId.HasValue && positionId != _003C_003Ec__DisplayClass26_.uSer.PositionId)
								{
									DateTime value4 = now;
									string registerDatePersian2 = now.ToString("yyyyMMdd", new PersianCulture());
									short value5 = short.Parse(now.ToString("MM", new PersianCulture()));
									string appType2 = Configuration.AppType;
									short value6 = short.Parse(Financial.Get().Id.ToString());
									int userId2 = UserLogin.CurrentUser.UserId;
									string[] array5 = null;
									if (!string.IsNullOrWhiteSpace(_003C_003Ec__DisplayClass26_.uSer.UserCIds))
									{
										array5 = _003C_003Ec__DisplayClass26_.uSer.UserCIds.Split(new char[1] { ',' });
									}
									if (array5 != null && array5.Length != 0)
									{
										string[] array2 = array5;
										foreach (string text8 in array2)
										{
											if (!string.IsNullOrWhiteSpace(text8))
											{
												int result22 = 0;
												int.TryParse(text8, out result22);
												if (result22 != 0)
												{
													db.CRMspInsertLinkedUserPositionsByUserId(_003C_003Ec__DisplayClass26_.uSer.UserId, _003C_003Ec__DisplayClass26_.uSer.PositionId, userId2, value6, value5, value4, registerDatePersian2, appType2, defLangID, result22);
												}
											}
										}
									}
								}
								CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmLinkedUsers");
							}
							if (!string.IsNullOrWhiteSpace(_003C_003Ec__DisplayClass26_.uSer.UserCIds) && text3 != text4 && VersionBuyer.Center)
							{
								DateTime value7 = now;
								string registerDatePersian3 = now.ToString("yyyyMMdd", new PersianCulture());
								short value8 = short.Parse(now.ToString("MM", new PersianCulture()));
								string appType3 = Configuration.AppType;
								short value9 = short.Parse(Financial.Get().Id.ToString());
								int userId3 = UserLogin.CurrentUser.UserId;
								_dbII.CRMspInsertCenterLinkedByUserId(_003C_003Ec__DisplayClass26_.uSer.UserId, userCId2.GetValueOrDefault(), userCId.GetValueOrDefault(), userId3, value9, value8, value7, registerDatePersian3, appType3, defLangID);
								CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmLinkedUsers");
							}
							userVm.StartDatePersian = (userVm.StartDate.HasValue ? userVm.StartDate.Value.ToString("yyyy/MM/dd") : "");
							userVm.ExpireDatePersian = (userVm.ExpireDate.HasValue ? userVm.ExpireDate.Value.ToString("yyyy/MM/dd") : "");
							base.ViewBag.SuccessfullEdit = Messages.frmFormBaseEditSuccessFulMessage;
							Info.Update(_003C_003Ec__DisplayClass26_.uSer.UserId);
						}
					}
					else
					{
						text = Messages.ErrorNotFound;
					}
				}
				else
				{
					text = Messages.ErrorNotFound;
				}
			}
			else
			{
				text = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
		}
		catch (DbEntityValidationException e4)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e4);
			text = Messages.frmErrorMessage;
		}
		catch (Exception e5)
		{
			ErrorSignal.FromCurrentContext().Raise(e5);
			text = Messages.frmErrorMessage;
		}
		base.ViewBag.Error = text;
		UserFullcombo();
		return View(userVm);
	}

	public List<TreeViewItemModel> GetUserPositionNodeTree(List<CRMspSelectUserPositionTree_Result> lstPositions, int? posId)
	{
		List<TreeViewItemModel> list = new List<TreeViewItemModel>();
		try
		{
			List<CRMspSelectUserPositionTree_Result> list2 = Enumerable.ToList<CRMspSelectUserPositionTree_Result>(Enumerable.Where<CRMspSelectUserPositionTree_Result>((IEnumerable<CRMspSelectUserPositionTree_Result>)lstPositions, (Func<CRMspSelectUserPositionTree_Result, bool>)((CRMspSelectUserPositionTree_Result m) => m.ParentId == posId)));
			if (Enumerable.Any<CRMspSelectUserPositionTree_Result>((IEnumerable<CRMspSelectUserPositionTree_Result>)list2))
			{
				foreach (CRMspSelectUserPositionTree_Result item in list2)
				{
					TreeViewItemModel treeViewItemModel = new TreeViewItemModel();
					treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item.PositionId.ToString()));
					treeViewItemModel.Id = item.PositionId.ToString();
					treeViewItemModel.Text = item.PositionNameWithCode;
					treeViewItemModel.ImageUrl = "";
					List<TreeViewItemModel> userPositionNodeTree = GetUserPositionNodeTree(lstPositions, item.PositionId);
					treeViewItemModel.Items = new List<TreeViewItemModel>(userPositionNodeTree);
					list.Add(treeViewItemModel);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	public List<TreeViewItemModel> GetUserPositionTree(int posId = 0)
	{
		List<TreeViewItemModel> list = new List<TreeViewItemModel>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectUserPositionTree_Result> list2 = Enumerable.ToList<CRMspSelectUserPositionTree_Result>(Enumerable.Where<CRMspSelectUserPositionTree_Result>((IEnumerable<CRMspSelectUserPositionTree_Result>)db.CRMspSelectUserPositionTree(lCID, result), (Func<CRMspSelectUserPositionTree_Result, bool>)((CRMspSelectUserPositionTree_Result m) => m.PositionId != posId)));
			if (Enumerable.Any<CRMspSelectUserPositionTree_Result>((IEnumerable<CRMspSelectUserPositionTree_Result>)list2))
			{
				List<CRMspSelectUserPositionTree_Result> list3 = Enumerable.ToList<CRMspSelectUserPositionTree_Result>(Enumerable.Where<CRMspSelectUserPositionTree_Result>((IEnumerable<CRMspSelectUserPositionTree_Result>)list2, (Func<CRMspSelectUserPositionTree_Result, bool>)((CRMspSelectUserPositionTree_Result m) => m.ParentId == 0)));
				if (Enumerable.Any<CRMspSelectUserPositionTree_Result>((IEnumerable<CRMspSelectUserPositionTree_Result>)list3))
				{
					foreach (CRMspSelectUserPositionTree_Result item in list3)
					{
						TreeViewItemModel treeViewItemModel = new TreeViewItemModel();
						treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item.PositionId.ToString()));
						treeViewItemModel.Id = item.PositionId.ToString();
						treeViewItemModel.Text = item.PositionNameWithCode;
						treeViewItemModel.ImageUrl = "";
						List<TreeViewItemModel> userPositionNodeTree = GetUserPositionNodeTree(list2, item.PositionId);
						treeViewItemModel.Items = new List<TreeViewItemModel>(userPositionNodeTree);
						list.Add(treeViewItemModel);
					}
				}
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return list;
	}

	[AjaxOnly]
	public ActionResult _PartialUserPositionsTree(int posId = 0)
	{
		try
		{
			List<TreeViewItemModel> userPositionTree = GetUserPositionTree(posId);
			base.ViewBag.PositionsTree = userPositionTree;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return PartialView();
	}

	[AjaxOnly]
	public JsonResult GetCenterUserDepartment()
	{
		List<CRMspSelectUserDepartments_Result> list = new List<CRMspSelectUserDepartments_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			list = Enumerable.ToList<CRMspSelectUserDepartments_Result>((IEnumerable<CRMspSelectUserDepartments_Result>)db.CRMspSelectUserDepartments(lCID, result, 0));
			if (list == null)
			{
				list = new List<CRMspSelectUserDepartments_Result>();
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
	public JsonResult GetUserDepartment()
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
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<CRMspSelectUserDepartments_Result> list2 = Enumerable.ToList<CRMspSelectUserDepartments_Result>((IEnumerable<CRMspSelectUserDepartments_Result>)db.CRMspSelectUserDepartments(lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspSelectUserDepartments_Result, SelectListItem>((IEnumerable<CRMspSelectUserDepartments_Result>)list2, (Func<CRMspSelectUserDepartments_Result, SelectListItem>)((CRMspSelectUserDepartments_Result item) => new SelectListItem
			{
				Text = item.Department,
				Value = item.DepartmentID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.DepartmentList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetDefCmpPrjTitle()
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
			List<CRMspSelectProjectTitles_Result> list2 = Enumerable.ToList<CRMspSelectProjectTitles_Result>((IEnumerable<CRMspSelectProjectTitles_Result>)db.CRMspSelectProjectTitles(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectProjectTitles_Result, SelectListItem>((IEnumerable<CRMspSelectProjectTitles_Result>)list2, (Func<CRMspSelectProjectTitles_Result, SelectListItem>)((CRMspSelectProjectTitles_Result item) => new SelectListItem
			{
				Text = (item.ProjectTitle ?? ""),
				Value = (item.ProjectTitle ?? ""),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public JsonResult GetDefCmpPrjTitle_Lang(int currLangID)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<CRMspSelectProjectTitles_Result> list2 = Enumerable.ToList<CRMspSelectProjectTitles_Result>((IEnumerable<CRMspSelectProjectTitles_Result>)db.CRMspSelectProjectTitles(currLangID, result));
			list.AddRange(Enumerable.Select<CRMspSelectProjectTitles_Result, SelectListItem>((IEnumerable<CRMspSelectProjectTitles_Result>)list2, (Func<CRMspSelectProjectTitles_Result, SelectListItem>)((CRMspSelectProjectTitles_Result item) => new SelectListItem
			{
				Text = (item.ProjectTitle ?? ""),
				Value = (item.ProjectTitle ?? ""),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmDefineUsers", ActionName = "actExLocations")]
	public ActionResult UserDefineEditLocation(int userId)
	{
		base.ViewBag.Zoom = 18;
		base.ViewBag.UserId = userId;
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
		foreach (Languages item in CRMIdeal.Cache.Setting.Language.Get())
		{
			if (item.LanguageID != lCID)
			{
				list.Add(new CommonMultiLanguageViewModel
				{
					LanguageId = item.LanguageID
				});
			}
		}
		base.ViewBag.LangModel = JsonConvert.SerializeObject(list);
		base.ViewBag.AllowCopyLanguage = UserLogin.IsCurrentUserAllowCopyOtherLanguage;
		return View();
	}

	[HttpPost]
	public string GetUserLocations(int userId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		string value = "";
		string value2 = "";
		CRMspSelectUsersById_Result cRMspSelectUsersById_Result = CRMIdeal.Classes.Helper.User.SelectUsersById(userId);
		if (cRMspSelectUsersById_Result != null)
		{
			if ((currLangID != result) & (cRMspSelectUsersById_Result.UserLoginCheckLocations != null))
			{
				List<CrmSysSettingCoLocationViewModel> list = JsonConvert.DeserializeObject<List<CrmSysSettingCoLocationViewModel>>(cRMspSelectUsersById_Result.UserLoginCheckLocations);
				string value3 = Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)JsonConvert.DeserializeObject<List<CommonMultiLanguageViewModel>>(cRMspSelectUsersById_Result.UserLoginCheckLocations_Lang), (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel x) => x.LanguageId == currLangID)).Value;
				if (!string.IsNullOrWhiteSpace(value3))
				{
					List<CrmSysSettingCoLocationViewModel> list2 = JsonConvert.DeserializeObject<List<CrmSysSettingCoLocationViewModel>>(value3);
					for (int i = 0; i < list.Count; i++)
					{
						list[i].Title = list2[i].Title;
					}
				}
				cRMspSelectUsersById_Result.UserLoginCheckLocations = JsonConvert.SerializeObject(list);
			}
			value = cRMspSelectUsersById_Result.UserLoginCheckLocations;
			value2 = cRMspSelectUsersById_Result.UserLoginCheckLocations_Lang;
		}
		return JsonConvert.SerializeObject(new Dictionary<string, string>
		{
			{ "Data", value },
			{ "LangData", value2 }
		});
	}

	[HttpPost]
	public void UpdateUserLocations(int userID, string locationsStr, string langLocationsStr)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		if (CRMIdeal.Cache.User.Language.Get(UserLogin.CurrentUser.UserId).Count <= 1)
		{
			langLocationsStr = "";
		}
		_dbII.CRMspUpdateUserLoginCheckLocations(userID, locationsStr, langLocationsStr, result);
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmDefineUsers", ActionName = "actDelete")]
	public string UserDefineDelete(int uId)
	{
		_003C_003Ec__DisplayClass37_0 _003C_003Ec__DisplayClass37_ = new _003C_003Ec__DisplayClass37_0();
		_003C_003Ec__DisplayClass37_.uId = uId;
		string result = "-1";
		try
		{
			DbSet<Users> users = _dbTbl.Users;
			ParameterExpression val = Expression.Parameter(typeof(Users), "c");
			if (Queryable.FirstOrDefault<Users>((IQueryable<Users>)users, Expression.Lambda<Func<Users, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass37_, typeof(_003C_003Ec__DisplayClass37_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) != null && db.CRMspDeleteUsers(_003C_003Ec__DisplayClass37_.uId) > 0)
			{
				DbSet<Users> users2 = _dbTbl.Users;
				val = Expression.Parameter(typeof(Users), "c");
				if (!Queryable.Any<Users>((IQueryable<Users>)users2, Expression.Lambda<Func<Users, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass37_, typeof(_003C_003Ec__DisplayClass37_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })))
				{
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("Users");
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("UserLanguages", _003C_003Ec__DisplayClass37_.uId);
					result = Messages.frmDeleteSuccessMessage;
					Manager.ClearAllUserCach(_003C_003Ec__DisplayClass37_.uId);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "frmDefineUsers", ActionName = "actInsertRoll")]
	public ActionResult UserRollDefineInsert(int uId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		UsersPermissionLanguageViewModel usersPermissionLanguageViewModel = new UsersPermissionLanguageViewModel
		{
			RegisterDate = DateTime.Now,
			UserId = uId
		};
		try
		{
			CRMspSelectUsersById_Result cRMspSelectUsersById_Result = CRMIdeal.Classes.Helper.User.SelectUsersById(uId);
			if (cRMspSelectUsersById_Result != null)
			{
				usersPermissionLanguageViewModel.UserCIds = cRMspSelectUsersById_Result.UserCIds;
			}
			DateTime now = DateTime.Now;
			usersPermissionLanguageViewModel.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
			usersPermissionLanguageViewModel.FirstRegisterDate = now;
			usersPermissionLanguageViewModel.RegisterDate = now;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			db.Dispose();
		}
		SetUserNameDateForUserRoll(usersPermissionLanguageViewModel);
		UserPermissionFullcombo();
		return View(usersPermissionLanguageViewModel);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	[DynamicAuthorize(ControllerName = "frmDefineUsers", ActionName = "actInsertRoll")]
	public ActionResult UserRollDefineInsert(UsersPermissionLanguageViewModel model)
	{
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass39_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass39_0();
		CS_0024_003C_003E8__locals0.model = model;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int countError = 0;
		try
		{
			if (base.ModelState.IsValid)
			{
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
				DbSet<UsersPermission> usersPermission = _dbTbl.UsersPermission;
				ParameterExpression val = Expression.Parameter(typeof(UsersPermission), "up");
				if (Queryable.FirstOrDefault<UsersPermission>((IQueryable<UsersPermission>)usersPermission, Expression.Lambda<Func<UsersPermission, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass39_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass39_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) != null)
				{
					text += Messages.NotDefineOneMoreRollPerCID;
					countError++;
				}
				else
				{
					text = ChkBeforeSubmitUserRoll(CS_0024_003C_003E8__locals0.model, ref countError);
					if (countError == 0)
					{
						UsersPermission usersPermission2 = new UsersPermission
						{
							RegisterDate = DateTime.Now,
							GUId = System.Guid.NewGuid(),
							AppType = Configuration.AppType,
							RollId = CS_0024_003C_003E8__locals0.model.RollId,
							PrjId = CS_0024_003C_003E8__locals0.model.PrjId,
							FirstRegisterDate = DateTime.Now,
							FirstRegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture()),
							UserId = CS_0024_003C_003E8__locals0.model.UserId,
							FirstRegisterUserId = UserLogin.CurrentUser.UserId,
							AccessLevel = CS_0024_003C_003E8__locals0.model.AccessLevel,
							LanguageID = CS_0024_003C_003E8__locals0.defLangID,
							Description = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null),
							CId = CS_0024_003C_003E8__locals0.model.CId
						};
						_dbTbl.UsersPermission.Add(usersPermission2);
						_dbTbl.SaveChanges();
						foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
						{
							UsersPermission_Lang entity = new UsersPermission_Lang
							{
								LanguageID = lang.LanguageID,
								ID = usersPermission2.ID,
								Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null)
							};
							_dbTbl.UsersPermission_Lang.Add(entity);
							_dbTbl.SaveChanges();
						}
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("UsersPermission", usersPermission2.UserId);
						if (usersPermission2.ID > 0)
						{
							DateTime now = DateTime.Now;
							DateTime value = now;
							string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
							short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
							string appType = Configuration.AppType;
							short value3 = short.Parse(Financial.Get().Id.ToString());
							int userId = UserLogin.CurrentUser.UserId;
							db.CRMspInsertLinkedUsersByRollId(1, usersPermission2.UserId, usersPermission2.RollId, userId, value3, value2, value, registerDatePersian, appType, CS_0024_003C_003E8__locals0.defLangID, usersPermission2.CId);
							CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmLinkedUsers");
						}
						base.ViewBag.SuccessfullInsert = Messages.frmFormBaseInsertSuccessFulMessage;
						Permissions.Update(usersPermission2.UserId);
						CS_0024_003C_003E8__locals0.model.UserId = usersPermission2.UserId;
						CS_0024_003C_003E8__locals0.model.FirstRegisterUserId = usersPermission2.FirstRegisterUserId;
						CS_0024_003C_003E8__locals0.model.FirstRegisterDate = usersPermission2.FirstRegisterDate;
						CS_0024_003C_003E8__locals0.model.RegisterDate = usersPermission2.RegisterDate;
						CS_0024_003C_003E8__locals0.model.AppType = usersPermission2.AppType;
					}
				}
			}
			else
			{
				text = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
			text = Messages.frmErrorMessage;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			text = Messages.frmErrorMessage;
		}
		base.ViewBag.Error = text;
		UserPermissionFullcombo();
		SetUserNameDateForUserRoll(CS_0024_003C_003E8__locals0.model);
		return View(CS_0024_003C_003E8__locals0.model);
	}

	private void UserPermissionFullcombo()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectProjects_Result, SelectListItem>((IEnumerable<CRMspSelectProjects_Result>)Enumerable.ToList<CRMspSelectProjects_Result>(Enumerable.Where<CRMspSelectProjects_Result>((IEnumerable<CRMspSelectProjects_Result>)Enumerable.ToList<CRMspSelectProjects_Result>((IEnumerable<CRMspSelectProjects_Result>)db.CRMspSelectProjects(lCID, result)), (Func<CRMspSelectProjects_Result, bool>)((CRMspSelectProjects_Result p) => p.Id == 11))), (Func<CRMspSelectProjects_Result, SelectListItem>)((CRMspSelectProjects_Result item) => new SelectListItem
		{
			Text = item.Title,
			Value = item.Id.ToString(),
			Selected = false
		})));
		base.ViewBag.ProjectsList = list;
		List<SelectListItem> list2 = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectsysRolls_Result, SelectListItem>((IEnumerable<CRMspSelectsysRolls_Result>)Enumerable.ToList<CRMspSelectsysRolls_Result>((IEnumerable<CRMspSelectsysRolls_Result>)db.CRMspSelectsysRolls(lCID, result)), (Func<CRMspSelectsysRolls_Result, SelectListItem>)((CRMspSelectsysRolls_Result item) => new SelectListItem
		{
			Text = item.RollName,
			Value = item.ID.ToString(),
			Selected = false
		})));
		base.ViewBag.RollList = list2;
	}

	public void SetUserNameDateForUserRoll(UsersPermissionLanguageViewModel model)
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
				CRMspSelectUsersByIds_Result cRMspSelectUsersByIds_Result = Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result c) => c.UserId == model.FirstRegisterUserId));
				text3 = ((cRMspSelectUsersByIds_Result != null) ? (cRMspSelectUsersByIds_Result.LName + ((cRMspSelectUsersByIds_Result.FName != null) ? (" " + cRMspSelectUsersByIds_Result.FName) : "")) : "");
				CRMspSelectUsersByIds_Result cRMspSelectUsersByIds_Result2 = Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result c) => c.UserId == model.UserId));
				text4 = ((cRMspSelectUsersByIds_Result2 != null) ? (cRMspSelectUsersByIds_Result2.LName + ((cRMspSelectUsersByIds_Result2.FName != null) ? (" " + cRMspSelectUsersByIds_Result2.FName) : "")) : "");
			}
			string text6 = (model.FirstRegisterDate.HasValue ? model.FirstRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
			string text7 = (model.RegisterDate.HasValue ? model.RegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
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

	[DynamicAuthorize(ControllerName = "frmDefineUsers", ActionName = "actEditRoll")]
	public ActionResult UserRollDefineEdit(int upId)
	{
		_003C_003Ec__DisplayClass42_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass42_0();
		CS_0024_003C_003E8__locals0.upId = upId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		DbSet<UsersPermission_Lang> usersPermission_Lang = _dbTbl.UsersPermission_Lang;
		ParameterExpression val = Expression.Parameter(typeof(UsersPermission_Lang), "c");
		List<UsersPermission_Lang> list = Enumerable.ToList<UsersPermission_Lang>((IEnumerable<UsersPermission_Lang>)Queryable.Where<UsersPermission_Lang>((IQueryable<UsersPermission_Lang>)usersPermission_Lang, Expression.Lambda<Func<UsersPermission_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass42_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
		UsersPermission usersPermission = _dbTbl.UsersPermission.Find(CS_0024_003C_003E8__locals0.upId);
		if (usersPermission == null)
		{
			usersPermission = new UsersPermission();
			usersPermission.RegisterDate = DateTime.Now;
			usersPermission.ID = CS_0024_003C_003E8__locals0.upId;
		}
		CRMspSelectUsersById_Result cRMspSelectUsersById_Result = CRMIdeal.Classes.Helper.User.SelectUsersById(usersPermission.UserId);
		List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<UsersPermission_Lang, CommonMultiLanguageViewModel>((IEnumerable<UsersPermission_Lang>)list, (Func<UsersPermission_Lang, CommonMultiLanguageViewModel>)((UsersPermission_Lang item) => new CommonMultiLanguageViewModel
		{
			Value = item.Description,
			LanguageId = item.LanguageID
		})));
		list2.Add(new CommonMultiLanguageViewModel
		{
			Value = usersPermission.Description,
			LanguageId = result
		});
		UsersPermissionLanguageViewModel usersPermissionLanguageViewModel = new UsersPermissionLanguageViewModel
		{
			LanguageID = usersPermission.LanguageID,
			AccessLevel = usersPermission.AccessLevel,
			ID = usersPermission.ID,
			UserId = usersPermission.UserId,
			FirstRegisterUserId = usersPermission.FirstRegisterUserId,
			FirstRegisterDate = usersPermission.FirstRegisterDate,
			AppType = usersPermission.AppType,
			FirstRegisterDatePersian = usersPermission.FirstRegisterDatePersian,
			GUId = usersPermission.GUId,
			RegisterDate = usersPermission.RegisterDate,
			PrjId = usersPermission.PrjId,
			RollId = usersPermission.RollId,
			Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
			Description_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
			CId = usersPermission.CId,
			UserCIds = cRMspSelectUsersById_Result?.UserCIds
		};
		UserPermissionFullcombo();
		SetUserNameDateForUserRoll(usersPermissionLanguageViewModel);
		return View(usersPermissionLanguageViewModel);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	[DynamicAuthorize(ControllerName = "frmDefineUsers", ActionName = "actEditRoll")]
	public ActionResult UserRollDefineEdit(UsersPermissionLanguageViewModel model)
	{
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass43_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass43_0();
		CS_0024_003C_003E8__locals0.model = model;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int countError = 0;
		try
		{
			if (base.ModelState.IsValid)
			{
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
				DbSet<UsersPermission> usersPermission = _dbTbl.UsersPermission;
				ParameterExpression val = Expression.Parameter(typeof(UsersPermission), "up");
				if (Queryable.FirstOrDefault<UsersPermission>((IQueryable<UsersPermission>)usersPermission, Expression.Lambda<Func<UsersPermission, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass43_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass43_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (Expression)(object)Expression.NotEqual((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass43_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) != null)
				{
					text += Messages.NotDefineOneMoreRollPerCID;
					countError++;
				}
				else
				{
					text = ChkBeforeSubmitUserRoll(CS_0024_003C_003E8__locals0.model, ref countError);
					if (countError == 0)
					{
						UsersPermission usersPermission2 = _dbTbl.UsersPermission.Find(CS_0024_003C_003E8__locals0.model.ID);
						usersPermission2.RegisterDate = DateTime.Now;
						usersPermission2.AppType = Configuration.AppType;
						usersPermission2.AccessLevel = CS_0024_003C_003E8__locals0.model.AccessLevel;
						usersPermission2.RollId = CS_0024_003C_003E8__locals0.model.RollId;
						usersPermission2.PrjId = CS_0024_003C_003E8__locals0.model.PrjId;
						usersPermission2.Description = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						usersPermission2.CId = CS_0024_003C_003E8__locals0.model.CId;
						_dbTbl.Entry(usersPermission2).State = EntityState.Modified;
						_dbTbl.SaveChanges();
						using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								_003C_003Ec__DisplayClass43_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass43_1();
								CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
								CS_0024_003C_003E8__locals1.lang = enumerator.Current;
								DbSet<UsersPermission_Lang> usersPermission_Lang = _dbTbl.UsersPermission_Lang;
								val = Expression.Parameter(typeof(UsersPermission_Lang), "c");
								UsersPermission_Lang usersPermission_Lang2 = Queryable.FirstOrDefault<UsersPermission_Lang>((IQueryable<UsersPermission_Lang>)usersPermission_Lang, Expression.Lambda<Func<UsersPermission_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass43_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass43_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
								if (usersPermission_Lang2 != null)
								{
									usersPermission_Lang2.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									_dbTbl.Entry(usersPermission_Lang2).State = EntityState.Modified;
									_dbTbl.SaveChanges();
									continue;
								}
								UsersPermission_Lang entity = new UsersPermission_Lang
								{
									LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID,
									ID = usersPermission2.ID,
									Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null)
								};
								_dbTbl.UsersPermission_Lang.Add(entity);
								_dbTbl.SaveChanges();
							}
						}
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("UsersPermission", usersPermission2.UserId);
						if (usersPermission2.ID > 0)
						{
							DateTime now = DateTime.Now;
							DateTime value = now;
							string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
							short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
							string appType = Configuration.AppType;
							short value3 = short.Parse(Financial.Get().Id.ToString());
							int userId = UserLogin.CurrentUser.UserId;
							db.CRMspInsertLinkedUsersByRollId(1, usersPermission2.UserId, usersPermission2.RollId, userId, value3, value2, value, registerDatePersian, appType, CS_0024_003C_003E8__locals0.defLangID, usersPermission2.CId);
							CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmLinkedUsers");
						}
						base.ViewBag.SuccessfullEdit = Messages.frmFormBaseEditSuccessFulMessage;
						Permissions.Update(usersPermission2.UserId);
						CS_0024_003C_003E8__locals0.model.UserId = usersPermission2.UserId;
						CS_0024_003C_003E8__locals0.model.RegisterDate = usersPermission2.RegisterDate;
						CS_0024_003C_003E8__locals0.model.AppType = usersPermission2.AppType;
					}
				}
			}
			else
			{
				text = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
			text = Messages.frmErrorMessage;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			text = Messages.frmErrorMessage;
		}
		base.ViewBag.Error = text;
		UserPermissionFullcombo();
		SetUserNameDateForUserRoll(CS_0024_003C_003E8__locals0.model);
		return View(CS_0024_003C_003E8__locals0.model);
	}

	public string ChkBeforeSubmitUserRoll(UsersPermissionLanguageViewModel uPermission, ref int countError)
	{
		string text = "";
		if (uPermission.PrjId == 0)
		{
			text += Messages.CheckEmptyPrjId;
			countError++;
		}
		if (!uPermission.RollId.HasValue || uPermission.RollId == 0)
		{
			text += Messages.CheckEmptyRollId;
			countError++;
		}
		if (!uPermission.CId.HasValue || uPermission.CId == 0)
		{
			text += Messages.CheckEmptyCId;
			countError++;
		}
		return text;
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmDefineUsers", ActionName = "actDeleteRoll")]
	public string UserRollDefineDelete(int upId)
	{
		string result = "-1";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			UsersPermission usersPermission = _dbTbl.UsersPermission.Find(upId);
			if (usersPermission != null && db.CRMspDeleteUsersPermission(upId) > 0)
			{
				if (usersPermission.ID > 0)
				{
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
					string appType = Configuration.AppType;
					short value3 = short.Parse(Financial.Get().Id.ToString());
					int userId = UserLogin.CurrentUser.UserId;
					db.CRMspInsertLinkedUsersByRollId(2, usersPermission.UserId, usersPermission.RollId, userId, value3, value2, value, registerDatePersian, appType, result2, usersPermission.CId);
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmLinkedUsers");
				}
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("UsersPermission", usersPermission.UserId);
				result = Messages.frmDeleteSuccessMessage;
				Permissions.Update(upId);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actUserRoll")]
	public ActionResult RollsDefine()
	{
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmsysRolls", ActionName = "actInsert")]
	public ActionResult RollsDefineInsert()
	{
		CrmsysRollsViewModel model = new CrmsysRollsViewModel();
		return View(model);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	[DynamicAuthorize(ControllerName = "frmsysRolls", ActionName = "actPost")]
	public ActionResult RollsDefineInsert(CrmsysRollsViewModel rollVM)
	{
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		DateTime now = DateTime.Now;
		DateTime value = now;
		string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
		short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
		string appType = Configuration.AppType;
		short value3 = short.Parse(Financial.Get().Id.ToString());
		int userId = UserLogin.CurrentUser.UserId;
		string text = "";
		int num = 0;
		try
		{
			if (base.ModelState.IsValid)
			{
				List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(rollVM.RollName_Lang))
				{
					list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(rollVM.RollName_Lang);
				}
				list.Add(new CommonMultiLanguageViewModel
				{
					Value = rollVM.RollName,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(rollVM.Description_Lang))
				{
					list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(rollVM.Description_Lang);
				}
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = rollVM.Description,
					LanguageId = lCID
				});
				if (string.IsNullOrEmpty(rollVM.RollName))
				{
					num++;
					text = text + Messages.CheckUserTaskTitle + "<br>";
				}
				else if (!checkMultiLanguage(rollVM.RollName, list))
				{
					text = text + Messages.CheckUserTaskTitleLang + "<br>";
					num++;
				}
				if (num == 0)
				{
					DateTime now2 = DateTime.Now;
					CrmsysRolls crmsysRolls = new CrmsysRolls
					{
						GUId = System.Guid.NewGuid(),
						LimitPreOrderDiscountActive = rollVM.LimitPreOrderDiscountActive,
						LimitPreOrderDiscountPercent = rollVM.LimitPreOrderDiscountPercent,
						LimitOrderDiscountActive = rollVM.LimitOrderDiscountActive,
						LimitOrderDiscountPercent = rollVM.LimitOrderDiscountPercent,
						AppType = Configuration.AppType,
						LanguageID = defLangID,
						FirstRegisterUserId = UserLogin.CurrentUser.UserId,
						FirstRegisterDate = now2,
						FirstRegisterDatePersian = now2.ToString("yyyyMMdd", new PersianCulture()),
						Description = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null),
						RollName = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null)
					};
					_dbTbl.CrmsysRolls.Add(crmsysRolls);
					_dbTbl.SaveChanges();
					foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))))
					{
						CrmsysRolls_Lang entity = new CrmsysRolls_Lang
						{
							LanguageID = lang.LanguageID,
							ID = crmsysRolls.ID,
							RollName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
							Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null)
						};
						_dbTbl.CrmsysRolls_Lang.Add(entity);
						_dbTbl.SaveChanges();
					}
					dbI.CRMspInsertAutoSysRollMenu(year1: value3, month1: value2, userId: UserLogin.CurrentUser.UserId, registerDate: now2, registerDatePersian: now2.ToString("yyyyMMdd", new PersianCulture()), appType: Configuration.AppType, languageID: defLangID);
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmsysRolls", null, crmsysRolls.ID);
					if (crmsysRolls.ID > 0)
					{
						db.CRMspInsertLinkedRollsByRollId(crmsysRolls.ID, userId, value3, value2, value, registerDatePersian, appType, defLangID);
					}
					base.ViewBag.SuccessfullInsert = Messages.frmFormBaseInsertSuccessFulMessage;
				}
			}
			else
			{
				text = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
			text = Messages.frmErrorMessage;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			text = Messages.frmErrorMessage;
		}
		base.ViewBag.Error = text;
		return View(rollVM);
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

	[DynamicAuthorize(ControllerName = "frmsysRolls", ActionName = "actEdit")]
	public ActionResult RollsDefineEdit(int rId)
	{
		_003C_003Ec__DisplayClass50_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass50_0();
		CS_0024_003C_003E8__locals0.rId = rId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		DbSet<CrmsysRolls_Lang> crmsysRolls_Lang = _dbTbl.CrmsysRolls_Lang;
		ParameterExpression val = Expression.Parameter(typeof(CrmsysRolls_Lang), "c");
		List<CrmsysRolls_Lang> list = Enumerable.ToList<CrmsysRolls_Lang>((IEnumerable<CrmsysRolls_Lang>)Queryable.Where<CrmsysRolls_Lang>((IQueryable<CrmsysRolls_Lang>)crmsysRolls_Lang, Expression.Lambda<Func<CrmsysRolls_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass50_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
		CrmsysRollsViewModel crmsysRollsViewModel = new CrmsysRollsViewModel();
		CrmsysRolls crmsysRolls = _dbTbl.CrmsysRolls.Find(CS_0024_003C_003E8__locals0.rId);
		if (crmsysRolls == null)
		{
			crmsysRolls.ID = CS_0024_003C_003E8__locals0.rId;
		}
		else
		{
			List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmsysRolls_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmsysRolls_Lang>)list, (Func<CrmsysRolls_Lang, CommonMultiLanguageViewModel>)((CrmsysRolls_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.RollName,
				LanguageId = item.LanguageID
			})));
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = crmsysRolls.RollName,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmsysRolls_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmsysRolls_Lang>)list, (Func<CrmsysRolls_Lang, CommonMultiLanguageViewModel>)((CrmsysRolls_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.Description,
				LanguageId = item.LanguageID
			})));
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = crmsysRolls.Description,
				LanguageId = result
			});
			crmsysRollsViewModel.ID = crmsysRolls.ID;
			crmsysRollsViewModel.GUId = crmsysRolls.GUId;
			crmsysRollsViewModel.LimitPreOrderDiscountActive = crmsysRolls.LimitPreOrderDiscountActive;
			crmsysRollsViewModel.LimitPreOrderDiscountPercent = crmsysRolls.LimitPreOrderDiscountPercent;
			crmsysRollsViewModel.LimitOrderDiscountActive = crmsysRolls.LimitOrderDiscountActive;
			crmsysRollsViewModel.LimitOrderDiscountPercent = crmsysRolls.LimitOrderDiscountPercent;
			crmsysRollsViewModel.RollName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
			crmsysRollsViewModel.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
			crmsysRollsViewModel.RollName_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
			crmsysRollsViewModel.Description_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
		}
		return View(crmsysRollsViewModel);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	[DynamicAuthorize(ControllerName = "frmsysRolls", ActionName = "actPost")]
	public ActionResult RollsDefineEdit(CrmsysRollsViewModel rollVM)
	{
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass51_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass51_0();
		CS_0024_003C_003E8__locals0.rollVM = rollVM;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		DateTime now = DateTime.Now;
		DateTime value = now;
		string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
		short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
		_ = Configuration.AppType;
		short value3 = short.Parse(Financial.Get().Id.ToString());
		_ = UserLogin.CurrentUser.UserId;
		string text = "";
		int num = 0;
		try
		{
			if (base.ModelState.IsValid)
			{
				List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.rollVM.RollName_Lang))
				{
					list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.rollVM.RollName_Lang);
				}
				list.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals0.rollVM.RollName,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.rollVM.Description_Lang))
				{
					list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.rollVM.Description_Lang);
				}
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = CS_0024_003C_003E8__locals0.rollVM.Description,
					LanguageId = lCID
				});
				if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.rollVM.RollName))
				{
					num++;
					text = text + Messages.CheckUserTaskTitle + "<br>";
				}
				else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.rollVM.RollName, list))
				{
					text = text + Messages.CheckUserTaskTitleLang + "<br>";
					num++;
				}
				if (num == 0)
				{
					CrmsysRolls crmsysRolls = _dbTbl.CrmsysRolls.Find(CS_0024_003C_003E8__locals0.rollVM.ID);
					if (crmsysRolls != null)
					{
						crmsysRolls.LimitPreOrderDiscountActive = CS_0024_003C_003E8__locals0.rollVM.LimitPreOrderDiscountActive;
						crmsysRolls.LimitPreOrderDiscountPercent = CS_0024_003C_003E8__locals0.rollVM.LimitPreOrderDiscountPercent;
						crmsysRolls.LimitOrderDiscountActive = CS_0024_003C_003E8__locals0.rollVM.LimitOrderDiscountActive;
						crmsysRolls.LimitOrderDiscountPercent = CS_0024_003C_003E8__locals0.rollVM.LimitOrderDiscountPercent;
						crmsysRolls.AppType = Configuration.AppType;
						crmsysRolls.Description = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						crmsysRolls.RollName = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					}
					_dbTbl.Entry(crmsysRolls).State = EntityState.Modified;
					_dbTbl.SaveChanges();
					using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							_003C_003Ec__DisplayClass51_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass51_1();
							CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
							CS_0024_003C_003E8__locals1.lang = enumerator.Current;
							DbSet<CrmsysRolls_Lang> crmsysRolls_Lang = _dbTbl.CrmsysRolls_Lang;
							ParameterExpression val = Expression.Parameter(typeof(CrmsysRolls_Lang), "c");
							CrmsysRolls_Lang crmsysRolls_Lang2 = Queryable.FirstOrDefault<CrmsysRolls_Lang>((IQueryable<CrmsysRolls_Lang>)crmsysRolls_Lang, Expression.Lambda<Func<CrmsysRolls_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass51_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass51_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (crmsysRolls_Lang2 != null)
							{
								crmsysRolls_Lang2.RollName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmsysRolls_Lang2.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								_dbTbl.Entry(crmsysRolls_Lang2).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							CrmsysRolls_Lang entity = new CrmsysRolls_Lang
							{
								LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID,
								ID = crmsysRolls.ID,
								RollName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
								Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null)
							};
							_dbTbl.CrmsysRolls_Lang.Add(entity);
							_dbTbl.SaveChanges();
						}
					}
					dbI.CRMspInsertAutoSysRollMenu(year1: value3, month1: value2, userId: UserLogin.CurrentUser.UserId, registerDate: value, registerDatePersian: registerDatePersian, appType: Configuration.AppType, languageID: CS_0024_003C_003E8__locals0.defLangID);
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmsysRolls", null, crmsysRolls.ID);
					base.ViewBag.SuccessfullEdit = Messages.frmFormBaseEditSuccessFulMessage;
				}
			}
			else
			{
				text = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
			text = Messages.frmErrorMessage;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			text = Messages.frmErrorMessage;
		}
		base.ViewBag.Error = text;
		return View(CS_0024_003C_003E8__locals0.rollVM);
	}

	[DynamicAuthorize(ControllerName = "frmsysRolls", ActionName = "actDelete")]
	[AjaxOnly]
	public string RollsDefineDelete(int rId)
	{
		_003C_003Ec__DisplayClass52_0 _003C_003Ec__DisplayClass52_ = new _003C_003Ec__DisplayClass52_0();
		_003C_003Ec__DisplayClass52_.rId = rId;
		string result = "-1";
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
			short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			short value3 = short.Parse(Financial.Get().Id.ToString());
			_ = UserLogin.CurrentUser.UserId;
			if (_dbTbl.CrmsysRolls.Find(_003C_003Ec__DisplayClass52_.rId) != null)
			{
				dbI.CRMspDeleteSysRollMenuWithRollId(_003C_003Ec__DisplayClass52_.rId);
				if (db.CRMspDeleteCrmsysRolls(_003C_003Ec__DisplayClass52_.rId) <= 0)
				{
					goto IL_026a;
				}
				DbSet<CrmsysRolls> crmsysRolls = _dbTbl.CrmsysRolls;
				ParameterExpression val = Expression.Parameter(typeof(CrmsysRolls), "model");
				if (Queryable.FirstOrDefault<CrmsysRolls>((IQueryable<CrmsysRolls>)crmsysRolls, Expression.Lambda<Func<CrmsysRolls, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass52_, typeof(_003C_003Ec__DisplayClass52_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) != null)
				{
					goto IL_026a;
				}
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmsysRolls", null, _003C_003Ec__DisplayClass52_.rId);
				result = "1";
				DbSet<UsersPermission> usersPermission = _dbTbl.UsersPermission;
				val = Expression.Parameter(typeof(UsersPermission), "u");
				foreach (UsersPermission item in Enumerable.ToList<UsersPermission>((IEnumerable<UsersPermission>)Queryable.Where<UsersPermission>((IQueryable<UsersPermission>)usersPermission, Expression.Lambda<Func<UsersPermission, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Convert((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass52_, typeof(_003C_003Ec__DisplayClass52_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), typeof(int?))), (ParameterExpression[])(object)new ParameterExpression[1] { val }))))
				{
					Permissions.Update(item.UserId);
				}
			}
			goto end_IL_0013;
			IL_026a:
			dbI.CRMspInsertAutoSysRollMenu(year1: value3, month1: value2, userId: UserLogin.CurrentUser.UserId, registerDate: value, registerDatePersian: registerDatePersian, appType: Configuration.AppType, languageID: result2);
			result = Messages.RedundancyMessage;
			end_IL_0013:;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = Messages.msgErrorRunFunction;
		}
		return result;
	}

	public ActionResult _PartialRollsDefine()
	{
		return PartialView();
	}

	public ActionResult _PartialRollsDefine_Read([DataSourceRequest] DataSourceRequest request)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CrmsysRollsViewModel> list = new List<CrmsysRollsViewModel>();
		try
		{
			foreach (CRMspSelectsysRolls_Result item in Enumerable.ToList<CRMspSelectsysRolls_Result>((IEnumerable<CRMspSelectsysRolls_Result>)Enumerable.OrderBy<CRMspSelectsysRolls_Result, int>((IEnumerable<CRMspSelectsysRolls_Result>)Enumerable.ToList<CRMspSelectsysRolls_Result>((IEnumerable<CRMspSelectsysRolls_Result>)db.CRMspSelectsysRolls(lCID, result)), (Func<CRMspSelectsysRolls_Result, int>)((CRMspSelectsysRolls_Result c) => c.ID))))
			{
				CrmsysRollsViewModel crmsysRollsViewModel = new CrmsysRollsViewModel
				{
					ID = item.ID,
					RollName = item.RollName,
					Description = item.Description,
					GUId = item.GUId,
					LimitPreOrderDiscountActive = item.LimitPreOrderDiscountActive,
					LimitPreOrderDiscountPercent = item.LimitPreOrderDiscountPercent,
					LimitOrderDiscountActive = item.LimitOrderDiscountActive,
					LimitOrderDiscountPercent = item.LimitOrderDiscountPercent
				};
				if (string.IsNullOrEmpty(item.AppType))
				{
					item.AppType = Configuration.AppType;
				}
				crmsysRollsViewModel.AppType = Configuration.GetAppType(item.AppType);
				string text = item.FirstRegisterUser ?? "";
				string text2 = (item.FirstRegisterDate.HasValue ? item.FirstRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
				crmsysRollsViewModel.FirstRegisterDatePersian = text + " (" + Labels.AppType + ":" + crmsysRollsViewModel.AppType + ") (" + text2 + ")";
				list.Add(crmsysRollsViewModel);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actChangePassword")]
	public ActionResult ChangePassword()
	{
		if (!UserLogin.IsUserAccess("frmMain", "actChangePassword", UserLogin.CurrentUser))
		{
			return null;
		}
		ChangePasswordViewModel changePasswordViewModel = new ChangePasswordViewModel();
		changePasswordViewModel.UserId = UserLogin.CurrentUser.UserId;
		changePasswordViewModel.FName = UserLogin.CurrentUser.FName;
		changePasswordViewModel.LName = UserLogin.CurrentUser.LName;
		return View(changePasswordViewModel);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	[DynamicAuthorize(ControllerName = "frmChangePassword", ActionName = "actChangePassword")]
	public ActionResult ChangePassword(ChangePasswordViewModel ChgPwd)
	{
		string text = "";
		int num = 0;
		try
		{
			if (base.ModelState.IsValid)
			{
				BaseInfo baseInfo = new BaseInfo();
				ChgPwd.Password = baseInfo.ConvertMd5(ChgPwd.Password).ToLower();
				if (ChgPwd.Password != UserLogin.CurrentUser.Password)
				{
					text += Messages.NotCorrectPasswordMessage;
					num++;
				}
				if (num == 0 && ChgPwd.Password == UserLogin.CurrentUser.Password)
				{
					Users users = _dbTbl.Users.Find(ChgPwd.UserId);
					if (users != null)
					{
						if (users.Password != ChgPwd.NewPassword)
						{
							users.IsAdmin = baseInfo.ConvertMd5(ChgPwd.NewPassword).ToLower() + ChgPwd.NewPassword;
							users.Password = baseInfo.ConvertMd5(ChgPwd.NewPassword).ToLower();
						}
						else
						{
							users.IsAdmin = users.IsAdmin;
							users.Password = users.Password;
						}
						users.UserId = users.UserId;
						users.UserId1 = UserLogin.CurrentUser.UserId;
						users.Month1 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
						users.RegisterDate = DateTime.Now;
						users.RegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
						users.AppType = Configuration.AppType;
						_dbTbl.Entry(users).State = EntityState.Modified;
						_dbTbl.SaveChanges();
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("Users", users.UserId);
						base.ViewBag.SuccessfullEdit = Messages.ChangePasswordSuccessMessage;
						Info.Update(users.UserId);
					}
				}
			}
			else
			{
				text = "1";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			text = Messages.frmErrorMessage;
		}
		base.ViewBag.Error = text;
		return View(ChgPwd);
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actuLinkedUsers")]
	public ActionResult UsersLinked()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectLinkedType_Result> list = Enumerable.ToList<CRMspSelectLinkedType_Result>((IEnumerable<CRMspSelectLinkedType_Result>)db.CRMspSelectLinkedType(lCID, result));
		List<TreeViewItemModel> list2 = new List<TreeViewItemModel>();
		foreach (CRMspSelectLinkedType_Result item in list)
		{
			TreeViewItemModel treeViewItemModel = new TreeViewItemModel();
			treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item.LinkedTypeId + "|" + item.TypeOrder));
			treeViewItemModel.Id = item.LinkedTypeId + "|" + item.TypeOrder;
			treeViewItemModel.Text = item.LinkTypeName;
			treeViewItemModel.ImageUrl = "";
			treeViewItemModel.Items = null;
			list2.Add(treeViewItemModel);
		}
		base.ViewBag.LinkedTypeTree = list2;
		base.ViewBag.LinkedTypeTreeID = list2[0].Id;
		return View();
	}

	[AjaxOnly]
	public JsonResult GetUsersList()
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
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<CRMspSelectUsersByIds_Result> list2 = CRMIdeal.Classes.Helper.User.SelectUsersByIds("-20");
			if (list2 != null)
			{
				list.AddRange(Enumerable.Select<CRMspSelectUsersByIds_Result, CrmDroupDownItem>((IEnumerable<CRMspSelectUsersByIds_Result>)Enumerable.ToList<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list2), (Func<CRMspSelectUsersByIds_Result, CrmDroupDownItem>)((CRMspSelectUsersByIds_Result i) => new CrmDroupDownItem
				{
					text = (i.FullName ?? ""),
					value = i.UserId.ToString()
				})));
			}
			List<CRMspSelectActiveUsers_Result> list3 = Enumerable.ToList<CRMspSelectActiveUsers_Result>((IEnumerable<CRMspSelectActiveUsers_Result>)db.CRMspSelectActiveUsers(lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspSelectActiveUsers_Result, CrmDroupDownItem>((IEnumerable<CRMspSelectActiveUsers_Result>)list3, (Func<CRMspSelectActiveUsers_Result, CrmDroupDownItem>)((CRMspSelectActiveUsers_Result item) => new CrmDroupDownItem
			{
				text = item.Name,
				value = item.UserId.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public ActionResult _PartialUsersLinkedFilter(int uId, int linkId)
	{
		base.ViewBag.ListId = uId + "|" + linkId;
		return PartialView();
	}

	public ActionResult _PartialUsersLinkedFilter_Read([DataSourceRequest] DataSourceRequest request, string ListId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string[] array = ListId.Split(new char[1] { '|' });
		List<CrmLinkedUsersViewModel> list = new List<CrmLinkedUsersViewModel>();
		string isActiveText = "(" + Labels.Active + ")";
		string deActiveText = "(" + Labels.Passive + ")";
		string linkedUserText = Labels.LinkedUserText;
		string linkedRollText = Labels.LinkedRollText;
		string linkedUserPositionText = Labels.LinkedUserPositionText;
		int result2 = 0;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
		}
		try
		{
			if (array[0] != "" && array[1] != "")
			{
				int value = int.Parse(array[0]);
				int value2 = int.Parse(array[1]);
				foreach (CRMspSelectLinkedUsersForLinkedType_Result item in Enumerable.ToList<CRMspSelectLinkedUsersForLinkedType_Result>((IEnumerable<CRMspSelectLinkedUsersForLinkedType_Result>)db.CRMspSelectLinkedUsersForLinkedType(value, value2, isActiveText, deActiveText, linkedUserText, linkedRollText, linkedUserPositionText, lCID, result, result2)))
				{
					CrmLinkedUsersViewModel crmLinkedUsersViewModel = new CrmLinkedUsersViewModel();
					crmLinkedUsersViewModel.ID = item.ID;
					crmLinkedUsersViewModel.LinkedTypeId = item.LinkedTypeId;
					crmLinkedUsersViewModel.LinkedUserId = item.LinkedUserId;
					crmLinkedUsersViewModel.LinkedUserFLName = item.LinkedUser ?? "";
					list.Add(crmLinkedUsersViewModel);
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

	public ActionResult _PartialUsersLinkedSelectActive(int uId, int linkId)
	{
		base.ViewBag.ListId = uId + "|" + linkId;
		return PartialView();
	}

	public ActionResult _PartialUsersLinkedSelectActive_Read([DataSourceRequest] DataSourceRequest request, string ListId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string[] array = ListId.Split(new char[1] { '|' });
		List<CrmLinkedUsersViewModel> list = new List<CrmLinkedUsersViewModel>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (array[0] != "" && array[1] != "")
			{
				int value = int.Parse(array[0]);
				int value2 = int.Parse(array[1]);
				foreach (CRMspSelectActiveUsersForLinkedType_Result item in Enumerable.ToList<CRMspSelectActiveUsersForLinkedType_Result>((IEnumerable<CRMspSelectActiveUsersForLinkedType_Result>)db.CRMspSelectActiveUsersForLinkedType(value, value2, Labels.Active, Labels.Passive, lCID, result, result2)))
				{
					CrmLinkedUsersViewModel crmLinkedUsersViewModel = new CrmLinkedUsersViewModel();
					crmLinkedUsersViewModel.ID = item.UserId;
					crmLinkedUsersViewModel.LinkedUserFLName = item.NameWithStatus;
					list.Add(crmLinkedUsersViewModel);
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
	public JsonResult GetLinkedUsersList_old(int crmUserId, int linkedTypeId, int pageNumber, int pageSize, int mode, string textSearch)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CrmLinkedUsersListViewModel crmLinkedUsersListViewModel = new CrmLinkedUsersListViewModel();
		crmLinkedUsersListViewModel.LinkedUsersList = new List<CRMspSelectLinkedUsersForLinkedTypeWithPaging_Result>();
		crmLinkedUsersListViewModel.AllPage = 0;
		crmLinkedUsersListViewModel.UsersCount = 0;
		int result2 = 0;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
		}
		try
		{
			if (crmUserId != 0 && linkedTypeId != 0)
			{
				string isActiveText = "(" + Labels.Active + ")";
				string deActiveText = "(" + Labels.Passive + ")";
				string linkedUserText = Labels.LinkedUserText;
				string linkedRollText = Labels.LinkedRollText;
				string linkedUserPositionText = Labels.LinkedUserPositionText;
				string linkedCenterText = Labels.LinkedCenterText;
				_ = Labels.Active;
				_ = Labels.Passive;
				crmLinkedUsersListViewModel.LinkedUsersList = Enumerable.ToList<CRMspSelectLinkedUsersForLinkedTypeWithPaging_Result>((IEnumerable<CRMspSelectLinkedUsersForLinkedTypeWithPaging_Result>)dbI.CRMspSelectLinkedUsersForLinkedTypeWithPaging(crmUserId, linkedTypeId, mode, textSearch, pageNumber, pageSize, isActiveText, deActiveText, linkedUserText, linkedRollText, linkedUserPositionText, lCID, result, result2, linkedCenterText));
				if (crmLinkedUsersListViewModel.LinkedUsersList != null && Enumerable.Any<CRMspSelectLinkedUsersForLinkedTypeWithPaging_Result>((IEnumerable<CRMspSelectLinkedUsersForLinkedTypeWithPaging_Result>)crmLinkedUsersListViewModel.LinkedUsersList))
				{
					CRMspSelectLinkedUsersForLinkedTypeWithPaging_Result cRMspSelectLinkedUsersForLinkedTypeWithPaging_Result = Enumerable.FirstOrDefault<CRMspSelectLinkedUsersForLinkedTypeWithPaging_Result>((IEnumerable<CRMspSelectLinkedUsersForLinkedTypeWithPaging_Result>)crmLinkedUsersListViewModel.LinkedUsersList);
					if (cRMspSelectLinkedUsersForLinkedTypeWithPaging_Result != null)
					{
						crmLinkedUsersListViewModel.AllPage = cRMspSelectLinkedUsersForLinkedTypeWithPaging_Result.AllPage.GetValueOrDefault();
					}
				}
				else
				{
					crmLinkedUsersListViewModel.LinkedUsersList = new List<CRMspSelectLinkedUsersForLinkedTypeWithPaging_Result>();
				}
				CRMspReturnUsersCountByUserId_Result cRMspReturnUsersCountByUserId_Result = Enumerable.FirstOrDefault<CRMspReturnUsersCountByUserId_Result>((IEnumerable<CRMspReturnUsersCountByUserId_Result>)dbI.CRMspReturnUsersCountByUserId(crmUserId, result2));
				int result3 = 0;
				if (cRMspReturnUsersCountByUserId_Result != null)
				{
					switch (mode)
					{
					case -1:
						int.TryParse(cRMspReturnUsersCountByUserId_Result.UsersCount.ToString(), out result3);
						break;
					case 0:
						int.TryParse(cRMspReturnUsersCountByUserId_Result.DeactiveUsersCount.ToString(), out result3);
						break;
					case 1:
						int.TryParse(cRMspReturnUsersCountByUserId_Result.ActiveUsersCount.ToString(), out result3);
						break;
					}
				}
				crmLinkedUsersListViewModel.UsersCount = result3;
				crmLinkedUsersListViewModel.IsFind = true;
				crmLinkedUsersListViewModel.Message = "";
			}
			else
			{
				crmLinkedUsersListViewModel.IsFind = false;
				crmLinkedUsersListViewModel.Message = Messages.msgErrorNotSelectedUser;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			crmLinkedUsersListViewModel.IsFind = false;
			crmLinkedUsersListViewModel.Message = Messages.msgErrorRunFunction + "<br />" + ex.Message;
		}
		JsonResult jsonResult = Json(crmLinkedUsersListViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult GetLinkedUsersList(int crmUserId, int linkedTypeId, int pageNumber, int pageSize, int mode, string textSearch)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CrmLinkedUsersListViewModel crmLinkedUsersListViewModel = new CrmLinkedUsersListViewModel();
		crmLinkedUsersListViewModel.LinkedUsersList = new List<CRMspSelectLinkedUsersForLinkedTypeWithPaging_Result>();
		crmLinkedUsersListViewModel.AllPage = 0;
		crmLinkedUsersListViewModel.UsersCount = 0;
		int result2 = 0;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
		}
		crmLinkedUsersListViewModel.CentersTree = new List<CRMspSelectCentersTreeFullInfo_Result>();
		crmLinkedUsersListViewModel.UserPositionsTree = new List<CRMspSelectUserPositionTreeFullInfo_Result>();
		crmLinkedUsersListViewModel.RollsList = new List<CRMspSelectsysRolls_Result>();
		try
		{
			if (crmUserId != 0 && linkedTypeId != 0)
			{
				string isActiveText = "(" + Labels.Active + ")";
				string deActiveText = "(" + Labels.Passive + ")";
				string linkedUserText = Labels.LinkedUserText;
				string linkedRollText = Labels.LinkedRollText;
				string linkedUserPositionText = Labels.LinkedUserPositionText;
				string linkedCenterText = Labels.LinkedCenterText;
				_ = Labels.Active;
				_ = Labels.Passive;
				crmLinkedUsersListViewModel.LinkedUsersList = Enumerable.ToList<CRMspSelectLinkedUsersForLinkedTypeWithPaging_Result>((IEnumerable<CRMspSelectLinkedUsersForLinkedTypeWithPaging_Result>)dbI.CRMspSelectLinkedUsersForLinkedTypeWithPaging(crmUserId, linkedTypeId, mode, textSearch, pageNumber, pageSize, isActiveText, deActiveText, linkedUserText, linkedRollText, linkedUserPositionText, lCID, result, result2, linkedCenterText));
				if (crmLinkedUsersListViewModel.LinkedUsersList != null && Enumerable.Any<CRMspSelectLinkedUsersForLinkedTypeWithPaging_Result>((IEnumerable<CRMspSelectLinkedUsersForLinkedTypeWithPaging_Result>)crmLinkedUsersListViewModel.LinkedUsersList))
				{
					CRMspSelectLinkedUsersForLinkedTypeWithPaging_Result cRMspSelectLinkedUsersForLinkedTypeWithPaging_Result = Enumerable.FirstOrDefault<CRMspSelectLinkedUsersForLinkedTypeWithPaging_Result>((IEnumerable<CRMspSelectLinkedUsersForLinkedTypeWithPaging_Result>)crmLinkedUsersListViewModel.LinkedUsersList);
					if (cRMspSelectLinkedUsersForLinkedTypeWithPaging_Result != null)
					{
						crmLinkedUsersListViewModel.AllPage = cRMspSelectLinkedUsersForLinkedTypeWithPaging_Result.AllPage.GetValueOrDefault();
					}
				}
				else
				{
					crmLinkedUsersListViewModel.LinkedUsersList = new List<CRMspSelectLinkedUsersForLinkedTypeWithPaging_Result>();
				}
				CRMspReturnUsersCountByUserId_Result cRMspReturnUsersCountByUserId_Result = Enumerable.FirstOrDefault<CRMspReturnUsersCountByUserId_Result>((IEnumerable<CRMspReturnUsersCountByUserId_Result>)dbI.CRMspReturnUsersCountByUserId(crmUserId, result2));
				int result3 = 0;
				if (cRMspReturnUsersCountByUserId_Result != null)
				{
					switch (mode)
					{
					case -1:
						int.TryParse(cRMspReturnUsersCountByUserId_Result.UsersCount.ToString(), out result3);
						break;
					case 0:
						int.TryParse(cRMspReturnUsersCountByUserId_Result.DeactiveUsersCount.ToString(), out result3);
						break;
					case 1:
						int.TryParse(cRMspReturnUsersCountByUserId_Result.ActiveUsersCount.ToString(), out result3);
						break;
					}
				}
				crmLinkedUsersListViewModel.UsersCount = result3;
				crmLinkedUsersListViewModel.CentersTree = Enumerable.ToList<CRMspSelectCentersTreeFullInfo_Result>((IEnumerable<CRMspSelectCentersTreeFullInfo_Result>)_dbII.CRMspSelectCentersTreeFullInfo(lCID, result));
				if (crmLinkedUsersListViewModel.CentersTree == null)
				{
					crmLinkedUsersListViewModel.CentersTree = new List<CRMspSelectCentersTreeFullInfo_Result>();
				}
				crmLinkedUsersListViewModel.UserPositionsTree = Enumerable.ToList<CRMspSelectUserPositionTreeFullInfo_Result>((IEnumerable<CRMspSelectUserPositionTreeFullInfo_Result>)_dbII.CRMspSelectUserPositionTreeFullInfo(lCID, result));
				if (crmLinkedUsersListViewModel.UserPositionsTree == null)
				{
					crmLinkedUsersListViewModel.UserPositionsTree = new List<CRMspSelectUserPositionTreeFullInfo_Result>();
				}
				crmLinkedUsersListViewModel.RollsList = Enumerable.ToList<CRMspSelectsysRolls_Result>((IEnumerable<CRMspSelectsysRolls_Result>)db.CRMspSelectsysRolls(lCID, result));
				if (crmLinkedUsersListViewModel.RollsList == null)
				{
					crmLinkedUsersListViewModel.RollsList = new List<CRMspSelectsysRolls_Result>();
				}
				crmLinkedUsersListViewModel.IsFind = true;
				crmLinkedUsersListViewModel.Message = "";
			}
			else
			{
				crmLinkedUsersListViewModel.IsFind = false;
				crmLinkedUsersListViewModel.Message = Messages.msgErrorNotSelectedUser;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			crmLinkedUsersListViewModel.IsFind = false;
			crmLinkedUsersListViewModel.Message = Messages.msgErrorRunFunction + "<br />" + ex.Message;
		}
		JsonResult jsonResult = Json(crmLinkedUsersListViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public string UserLinedAssignExecute(int crmUserId, string crmUserIds, int linkedUserId, int linkedTypeId, bool isLinkedPrs = false, bool isLinkedPrj = false, bool isLinkedCnvs = false)
	{
		string result = "";
		if (!UserLogin.IsUserAccess("frmLinkedUsers", "actAssign", UserLogin.CurrentUser))
		{
			return "-1";
		}
		try
		{
			if (crmUserId != 0 && linkedUserId != 0 && linkedTypeId != 0)
			{
				if (!string.IsNullOrWhiteSpace(crmUserIds))
				{
					crmUserIds = crmUserIds.Replace('|', ',');
					crmUserIds = crmUserId + "," + crmUserIds;
				}
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
				if (result2 <= 0)
				{
					result2 = 1065;
				}
				_ = Thread.CurrentThread.CurrentCulture.LCID;
				DateTime now = DateTime.Now;
				int userId = UserLogin.CurrentUser.UserId;
				short value = short.Parse(now.ToString("MM", new PersianCulture()));
				DateTime value2 = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				string appType = Configuration.AppType;
				short value3 = short.Parse(Financial.Get().Id.ToString());
				int? centerId = null;
				if (UserLogin.CurrentUser != null)
				{
					centerId = UserLogin.CurrentUser.UserLastCId;
				}
				db.CRMspInsertCrmLinkedUsersForUser(linkedTypeId, crmUserId, linkedUserId, userId, value3, value, value2, registerDatePersian, appType, result2, crmUserIds, centerId);
				if (linkedTypeId == 14)
				{
					if (isLinkedPrs)
					{
						db.CRMspInsertCrmLinkedUsersForUser(23, crmUserId, linkedUserId, userId, value3, value, value2, registerDatePersian, appType, result2, crmUserIds, centerId);
					}
					if (isLinkedPrj)
					{
						db.CRMspInsertCrmLinkedUsersForUser(24, crmUserId, linkedUserId, userId, value3, value, value2, registerDatePersian, appType, result2, crmUserIds, centerId);
					}
					if (isLinkedCnvs)
					{
						db.CRMspInsertCrmLinkedUsersForUser(25, crmUserId, linkedUserId, userId, value3, value, value2, registerDatePersian, appType, result2, crmUserIds, centerId);
					}
				}
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmLinkedUsers");
				result = "1";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public string UserLinedRemoveExecute(int linkedId, int crmUserId, string crmUserIds, int linkedTypeId, int linkedUserId, bool isLinkedPrs = false, bool isLinkedPrj = false, bool isLinkedCnvs = false)
	{
		string result = "";
		if (!UserLogin.IsUserAccess("frmLinkedUsers", "actRemove", UserLogin.CurrentUser))
		{
			result = "-1";
			return "-1";
		}
		try
		{
			if (!string.IsNullOrWhiteSpace(crmUserIds))
			{
				crmUserIds = crmUserIds.Replace('|', ',');
				crmUserIds = crmUserId + "," + crmUserIds;
			}
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (linkedId != 0 || linkedUserId != 0)
			{
				db.CRMspDeleteCrmLinkedUsersForUser(linkedId);
				db.CRMspDeleteCrmLinkedUsersForUserInOtherType(crmUserId, linkedTypeId, linkedUserId, crmUserIds, result2);
				if (linkedTypeId == 14)
				{
					if (isLinkedPrs)
					{
						db.CRMspDeleteCrmLinkedUsersForUserInOtherType(crmUserId, 23, linkedUserId, crmUserIds, result2);
					}
					if (isLinkedPrj)
					{
						db.CRMspDeleteCrmLinkedUsersForUserInOtherType(crmUserId, 24, linkedUserId, crmUserIds, result2);
					}
					if (isLinkedCnvs)
					{
						db.CRMspDeleteCrmLinkedUsersForUserInOtherType(crmUserId, 25, linkedUserId, crmUserIds, result2);
					}
				}
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmLinkedUsers");
				result = "1";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public string UserLinedAssignAllExecute(int crmUserId, string crmUserIds, string linkedUserIds, int linkedTypeId, bool isLinkedPrs = false, bool isLinkedPrj = false, bool isLinkedCnvs = false)
	{
		string result = "";
		if (!UserLogin.IsUserAccess("frmLinkedUsers", "actAssignAll", UserLogin.CurrentUser))
		{
			result = "-1";
			return "-1";
		}
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			int userId = UserLogin.CurrentUser.UserId;
			short value = short.Parse(now.ToString("MM", new PersianCulture()));
			DateTime value2 = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			string appType = Configuration.AppType;
			short value3 = short.Parse(Financial.Get().Id.ToString());
			if (!string.IsNullOrWhiteSpace(crmUserIds))
			{
				crmUserIds = crmUserIds.Replace('|', ',');
				crmUserIds = crmUserId + "," + crmUserIds;
			}
			else
			{
				crmUserIds = crmUserId.ToString();
			}
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			dbI.CRMspInsertCrmLinkedUsersForUserIds(linkedTypeId, crmUserIds, linkedUserIds, userId, value3, value, value2, registerDatePersian, appType, result2, centerId);
			if (linkedTypeId == 14)
			{
				if (isLinkedPrs)
				{
					dbI.CRMspInsertCrmLinkedUsersForUserIds(23, crmUserIds, linkedUserIds, userId, value3, value, value2, registerDatePersian, appType, result2, centerId);
				}
				if (isLinkedPrj)
				{
					dbI.CRMspInsertCrmLinkedUsersForUserIds(24, crmUserIds, linkedUserIds, userId, value3, value, value2, registerDatePersian, appType, result2, centerId);
				}
				if (isLinkedCnvs)
				{
					dbI.CRMspInsertCrmLinkedUsersForUserIds(25, crmUserIds, linkedUserIds, userId, value3, value, value2, registerDatePersian, appType, result2, centerId);
				}
			}
			result = "1";
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmLinkedUsers");
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public string UserLinedRemoveAllExecute(int crmUserId, string crmUserIds, int linkedTypeId, string linkedIds, string linkedUserIds, bool isLinkedPrs = false, bool isLinkedPrj = false, bool isLinkedCnvs = false)
	{
		string result = "";
		if (!UserLogin.IsUserAccess("frmLinkedUsers", "actRemoveAll", UserLogin.CurrentUser))
		{
			result = "-1";
			return "-1";
		}
		try
		{
			if (!string.IsNullOrWhiteSpace(crmUserIds))
			{
				crmUserIds = crmUserIds.Replace('|', ',');
				crmUserIds = crmUserId + "," + crmUserIds;
			}
			else
			{
				crmUserIds = crmUserId.ToString();
			}
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			ObjectResult<int?> objectResult = dbI.CRMspDeleteCrmLinkedUsersForUserIds(crmUserIds, linkedTypeId, "", linkedIds, result2);
			int result3 = 0;
			int.TryParse(objectResult.ToString(), out result3);
			if (result3 == 0)
			{
				dbI.CRMspDeleteCrmLinkedUsersForUserIds(crmUserIds, linkedTypeId, linkedUserIds, "", result2);
			}
			if (linkedTypeId == 14)
			{
				if (isLinkedPrs)
				{
					dbI.CRMspDeleteCrmLinkedUsersForUserIds(crmUserIds, 23, linkedUserIds, "", result2);
				}
				if (isLinkedPrj)
				{
					dbI.CRMspDeleteCrmLinkedUsersForUserIds(crmUserIds, 24, linkedUserIds, "", result2);
				}
				if (isLinkedCnvs)
				{
					dbI.CRMspDeleteCrmLinkedUsersForUserIds(crmUserIds, 25, linkedUserIds, "", result2);
				}
			}
			result = "1";
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmLinkedUsers");
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public string UserLinekdPastLinkedUserExecute(int crmUserId, string crmUserIds, int oldLinkedTypeId, int newLinkedTypeId, string linkedUserIds)
	{
		string text = "";
		if (!UserLogin.IsUserAccess("frmLinkedUsers", "actPastLinkedUser", UserLogin.CurrentUser))
		{
			text = "-1";
			return "-1";
		}
		try
		{
			if (crmUserId != 0 && oldLinkedTypeId != 0 && newLinkedTypeId != 0 && !string.IsNullOrWhiteSpace(linkedUserIds))
			{
				if (!string.IsNullOrWhiteSpace(crmUserIds))
				{
					crmUserIds = crmUserIds.Replace('|', ',');
					crmUserIds = crmUserId + "," + crmUserIds;
				}
				else
				{
					crmUserIds = crmUserId.ToString();
				}
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				_ = Thread.CurrentThread.CurrentCulture.LCID;
				DateTime now = DateTime.Now;
				int userId = UserLogin.CurrentUser.UserId;
				short value = short.Parse(now.ToString("MM", new PersianCulture()));
				DateTime value2 = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				string appType = Configuration.AppType;
				short value3 = short.Parse(Financial.Get().Id.ToString());
				int? centerId = null;
				if (UserLogin.CurrentUser != null)
				{
					centerId = UserLogin.CurrentUser.UserLastCId;
				}
				dbI.CRMspCopyPastLinkedUserFromOtherTypeForUserIds(newLinkedTypeId, oldLinkedTypeId, crmUserIds, linkedUserIds, userId, value3, value, value2, registerDatePersian, appType, result, centerId);
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmLinkedUsers");
				return "1";
			}
			return "-2";
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return "-2";
		}
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actRollPermission")]
	public ActionResult RollPermissionDefine()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectRollPermissionFormTree_Result> list = Enumerable.ToList<CRMspSelectRollPermissionFormTree_Result>((IEnumerable<CRMspSelectRollPermissionFormTree_Result>)db.CRMspSelectRollPermissionFormTree(lCID, result));
		List<TreeViewItemModel> list2 = new List<TreeViewItemModel>();
		foreach (CRMspSelectRollPermissionFormTree_Result item in list)
		{
			TreeViewItemModel treeViewItemModel = new TreeViewItemModel();
			treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item.rootId + "|" + item.Id));
			treeViewItemModel.Id = item.rootId + "|" + item.Id;
			treeViewItemModel.Text = item.FormPersianName;
			treeViewItemModel.ImageUrl = "";
			treeViewItemModel.Items = null;
			list2.Add(treeViewItemModel);
		}
		base.ViewBag.FormNameTree = list2;
		base.ViewBag.FormNameTreeID = list2[0].Id;
		int? num = 0;
		if (UserLogin.CurrentUser != null)
		{
			num = UserLogin.CurrentUser.RollId.GetValueOrDefault();
		}
		base.ViewBag.RollID = num;
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actRollPermission")]
	public ActionResult RollPermissionDefinePopup(string formName)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int? num = 0;
		if (UserLogin.CurrentUser != null)
		{
			num = UserLogin.CurrentUser.RollId.GetValueOrDefault();
		}
		base.ViewBag.RollID = num;
		CRMspSelectsysForms_Result cRMspSelectsysForms_Result = Enumerable.FirstOrDefault<CRMspSelectsysForms_Result>((IEnumerable<CRMspSelectsysForms_Result>)Enumerable.ToList<CRMspSelectsysForms_Result>((IEnumerable<CRMspSelectsysForms_Result>)db.CRMspSelectsysForms(lCID, result)), (Func<CRMspSelectsysForms_Result, bool>)((CRMspSelectsysForms_Result m) => m.FormName == formName));
		base.ViewBag.FormId = cRMspSelectsysForms_Result?.ID ?? 0;
		base.ViewBag.FormName = ((cRMspSelectsysForms_Result != null) ? cRMspSelectsysForms_Result.FormPersianName : "");
		return View();
	}

	[AjaxOnly]
	public JsonResult GetRollsList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CrmDroupDownItem> data = Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<CRMspSelectsysRolls_Result, CrmDroupDownItem>((IEnumerable<CRMspSelectsysRolls_Result>)Enumerable.ToList<CRMspSelectsysRolls_Result>((IEnumerable<CRMspSelectsysRolls_Result>)db.CRMspSelectsysRolls(lCID, result)), (Func<CRMspSelectsysRolls_Result, CrmDroupDownItem>)((CRMspSelectsysRolls_Result roll) => new CrmDroupDownItem
		{
			text = roll.RollName,
			value = roll.ID.ToString()
		})));
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	public ActionResult _PartialRollPermissionNotAssignedActions(int rollId, int formId, int cId = 0)
	{
		base.ViewBag.ListId = rollId + "|" + formId;
		base.ViewBag.RollPermissonCId = cId;
		return PartialView();
	}

	public ActionResult _PartialRollPermissionNotAssignedActions_Read([DataSourceRequest] DataSourceRequest request, string ListId, int cId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string[] array = ListId.Split(new char[1] { '|' });
		List<CRMspSelectNotAssignedFormActionsToRoll_Result> enumerable = new List<CRMspSelectNotAssignedFormActionsToRoll_Result>();
		if (array[0] != "" && array[1] != "")
		{
			int value = int.Parse(array[0]);
			int value2 = int.Parse(array[1]);
			enumerable = Enumerable.ToList<CRMspSelectNotAssignedFormActionsToRoll_Result>((IEnumerable<CRMspSelectNotAssignedFormActionsToRoll_Result>)db.CRMspSelectNotAssignedFormActionsToRoll(value2, value, lCID, result, cId));
		}
		return Json(((IEnumerable)enumerable).ToDataSourceResult(request));
	}

	[AjaxOnly]
	public ActionResult _PartialRollPermissionAssignedActions(int rollId, int formId, int cId = 0)
	{
		base.ViewBag.ListId = rollId + "|" + formId;
		base.ViewBag.RollPermissonCId = cId;
		return PartialView();
	}

	[AjaxOnly]
	public ActionResult _PartialRollPermissionAssignedActions_Read([DataSourceRequest] DataSourceRequest request, string ListId, int cId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string[] array = ListId.Split(new char[1] { '|' });
		List<CRMspSelectAssignedFormActionsToRoll_Result> enumerable = new List<CRMspSelectAssignedFormActionsToRoll_Result>();
		if (array[0] != "" && array[1] != "")
		{
			int value = int.Parse(array[0]);
			int value2 = int.Parse(array[1]);
			enumerable = Enumerable.ToList<CRMspSelectAssignedFormActionsToRoll_Result>((IEnumerable<CRMspSelectAssignedFormActionsToRoll_Result>)db.CRMspSelectAssignedFormActionsToRoll(value2, value, lCID, result, cId));
		}
		return Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetLoadAssignedActions(int rollId, int formId, int cId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectAssignedFormActionsToRoll_Result> data = new List<CRMspSelectAssignedFormActionsToRoll_Result>();
		try
		{
			data = Enumerable.ToList<CRMspSelectAssignedFormActionsToRoll_Result>((IEnumerable<CRMspSelectAssignedFormActionsToRoll_Result>)db.CRMspSelectAssignedFormActionsToRoll(formId, rollId, lCID, result, cId));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetNotAssignedActions(int rollId, int formId, int cId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectNotAssignedFormActionsToRoll_Result> data = new List<CRMspSelectNotAssignedFormActionsToRoll_Result>();
		try
		{
			data = Enumerable.ToList<CRMspSelectNotAssignedFormActionsToRoll_Result>((IEnumerable<CRMspSelectNotAssignedFormActionsToRoll_Result>)db.CRMspSelectNotAssignedFormActionsToRoll(formId, rollId, lCID, result, cId));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public string RollPermissionAssigneAction(int rollID, int formID, int actionID, int cId = 0)
	{
		string text = "";
		try
		{
			if (rollID != 0 && formID != 0 && actionID != 0)
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				string firstRegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
				if (db.CRMspInsertRollPermissionFormAction(rollID, formID, actionID, Configuration.AppType, result, firstRegisterDatePersian, UserLogin.CurrentUser.UserId, (cId != 0) ? new int?(cId) : null) > 0)
				{
					List<CRMspSelectAllUsersPermissionByRollId_Result> list = Enumerable.ToList<CRMspSelectAllUsersPermissionByRollId_Result>((IEnumerable<CRMspSelectAllUsersPermissionByRollId_Result>)_dbII.CRMspSelectAllUsersPermissionByRollId(rollID, cId, lCID, result));
					if (list != null && Enumerable.Any<CRMspSelectAllUsersPermissionByRollId_Result>((IEnumerable<CRMspSelectAllUsersPermissionByRollId_Result>)list))
					{
						foreach (CRMspSelectAllUsersPermissionByRollId_Result item in list)
						{
							Permissions.Update(item.UserId, item.CId);
						}
					}
				}
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmsysRollPermission", null, rollID);
				return "1";
			}
			return "-1";
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return "-1";
		}
	}

	[AjaxOnly]
	public string RollPermissionRemoveAssigneAction(int rollID, int formID, int actionID, int cId = 0)
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
			if (rollID != 0 && formID != 0 && actionID != 0)
			{
				if (db.CRMspDeleteRollPermissionFormAction(rollID, formID, actionID, cId) > 0)
				{
					List<CRMspSelectAllUsersPermissionByRollId_Result> list = Enumerable.ToList<CRMspSelectAllUsersPermissionByRollId_Result>((IEnumerable<CRMspSelectAllUsersPermissionByRollId_Result>)_dbII.CRMspSelectAllUsersPermissionByRollId(rollID, cId, lCID, result));
					if (list != null && Enumerable.Any<CRMspSelectAllUsersPermissionByRollId_Result>((IEnumerable<CRMspSelectAllUsersPermissionByRollId_Result>)list))
					{
						foreach (CRMspSelectAllUsersPermissionByRollId_Result item in list)
						{
							Permissions.Update(item.UserId, item.CId);
						}
					}
				}
				text = "1";
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmsysRollPermission", null, rollID);
			}
			else
			{
				text = "-1";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			text = "-1";
		}
		return text;
	}

	[AjaxOnly]
	public string RollPermissionAssigneActionAll(int rollID, int formID, string lstActionID, int cId = 0)
	{
		string text = "";
		try
		{
			if (rollID != 0 && formID != 0)
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				string firstRegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
				db.CRMspInsertRollPermissionFormActions(rollID, formID, Configuration.AppType, result, firstRegisterDatePersian, UserLogin.CurrentUser.UserId, (cId != 0) ? new int?(cId) : null);
				text = "1";
				List<CRMspSelectAllUsersPermissionByRollId_Result> list = Enumerable.ToList<CRMspSelectAllUsersPermissionByRollId_Result>((IEnumerable<CRMspSelectAllUsersPermissionByRollId_Result>)_dbII.CRMspSelectAllUsersPermissionByRollId(rollID, cId, lCID, result));
				if (list != null && Enumerable.Any<CRMspSelectAllUsersPermissionByRollId_Result>((IEnumerable<CRMspSelectAllUsersPermissionByRollId_Result>)list))
				{
					foreach (CRMspSelectAllUsersPermissionByRollId_Result item in list)
					{
						Permissions.Update(item.UserId, item.CId);
					}
				}
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmsysRollPermission", null, rollID);
			}
			else
			{
				text = "-1";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			text = "-1";
		}
		return text;
	}

	[AjaxOnly]
	public string RollPermissionRemoveAssigneActionAll(int rollID, int formID, int cId = 0)
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
			if (rollID != 0 && formID != 0)
			{
				db.CRMspDeleteRollPermissionFormActions(rollID, formID, cId);
				text = "1";
				List<CRMspSelectAllUsersPermissionByRollId_Result> list = Enumerable.ToList<CRMspSelectAllUsersPermissionByRollId_Result>((IEnumerable<CRMspSelectAllUsersPermissionByRollId_Result>)_dbII.CRMspSelectAllUsersPermissionByRollId(rollID, cId, lCID, result));
				if (list != null && Enumerable.Any<CRMspSelectAllUsersPermissionByRollId_Result>((IEnumerable<CRMspSelectAllUsersPermissionByRollId_Result>)list))
				{
					foreach (CRMspSelectAllUsersPermissionByRollId_Result item in list)
					{
						Permissions.Update(item.UserId, item.CId);
					}
				}
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmsysRollPermission", null, rollID);
			}
			else
			{
				text = "-1";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			text = "-1";
		}
		return text;
	}

	[AjaxOnly]
	public string RollPermissionFormSearch(string searchVal)
	{
		string text = "";
		try
		{
			if (searchVal != "")
			{
				string text2 = "";
				text2 = ((!Regex.IsMatch(searchVal, "^[a-zA-Z0-9]*$")) ? "Persian" : "Eng");
				foreach (CRMspSerachsysFormByName_Result item in Enumerable.ToList<CRMspSerachsysFormByName_Result>((IEnumerable<CRMspSerachsysFormByName_Result>)db.CRMspSerachsysFormByName(searchVal, text2)))
				{
					text = text + "0|" + item.ID + "-";
				}
			}
			else
			{
				text = "-1";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			text = "-1";
		}
		return text;
	}

	[AjaxOnly]
	public string RollPermissionSysForms()
	{
		string result = "-1";
		try
		{
			if (_dbII.CRMspDeletesysForms() > 0)
			{
				result = "1";
				Manager.ClearAllUserCach();
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmsysForms");
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = "-1";
		}
		return result;
	}

	[AjaxOnly]
	public string RollPermissionDeleteActionFromForm(int formId)
	{
		string result = "-1";
		try
		{
			if (_dbII.CRMspDeletesysFormActions(formId) > 0)
			{
				Manager.ClearAllUserCach();
				result = "1";
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmsysFormActions");
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = "-1";
		}
		return result;
	}

	[AjaxOnly]
	public string RollPermissionDeleteRollPermissions(int rollId, int cId = 0)
	{
		string text = "-1";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			_dbII.CRMspDeleteRollPermissionFormRoll(rollId, cId);
			text = "1";
			List<CRMspSelectAllUsersPermissionByRollId_Result> list = Enumerable.ToList<CRMspSelectAllUsersPermissionByRollId_Result>((IEnumerable<CRMspSelectAllUsersPermissionByRollId_Result>)_dbII.CRMspSelectAllUsersPermissionByRollId(rollId, cId, lCID, result));
			if (list != null && Enumerable.Any<CRMspSelectAllUsersPermissionByRollId_Result>((IEnumerable<CRMspSelectAllUsersPermissionByRollId_Result>)list))
			{
				foreach (CRMspSelectAllUsersPermissionByRollId_Result item in list)
				{
					Permissions.Update(item.UserId, item.CId);
				}
			}
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmsysRollPermission", null, rollId);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			text = "-1";
		}
		return text;
	}

	[AjaxOnly]
	public string RollPermissionPasteAllPermission(int fromRollID, int confirm, int toRollID, int cId = 0, int formId = 0)
	{
		string result = "";
		if (confirm == 1)
		{
			try
			{
				if (fromRollID > 0 && toRollID > 0)
				{
					int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
					if (result2 <= 0)
					{
						result2 = 1065;
					}
					int lCID = Thread.CurrentThread.CurrentCulture.LCID;
					string firstRegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
					if (db.CRMspCopyRollPermissionBetweenRolls(fromRollID, toRollID, Configuration.AppType, result2, firstRegisterDatePersian, UserLogin.CurrentUser.UserId, (cId != 0) ? new int?(cId) : null, formId) > 0)
					{
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmsysRollPermission", null, toRollID);
						result = "1";
						List<CRMspSelectAllUsersPermissionByRollId_Result> list = Enumerable.ToList<CRMspSelectAllUsersPermissionByRollId_Result>((IEnumerable<CRMspSelectAllUsersPermissionByRollId_Result>)_dbII.CRMspSelectAllUsersPermissionByRollId(toRollID, cId, lCID, result2));
						if (list != null && Enumerable.Any<CRMspSelectAllUsersPermissionByRollId_Result>((IEnumerable<CRMspSelectAllUsersPermissionByRollId_Result>)list))
						{
							foreach (CRMspSelectAllUsersPermissionByRollId_Result item in list)
							{
								Permissions.Update(item.UserId, item.CId);
							}
						}
					}
				}
				else
				{
					result = "-1";
				}
			}
			catch (Exception e)
			{
				result = "-1";
				ErrorSignal.FromCurrentContext().Raise(e);
			}
		}
		return result;
	}

	[AjaxOnly]
	public string RollPermissionPasteAllPermissionToCenter(int fromCId, int toCId)
	{
		string text = "";
		try
		{
			if (fromCId != 0 && toCId != 0)
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
				DateTime now = DateTime.Now;
				DateTime value = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				short.Parse(now.ToString("yyyy", new PersianCulture()));
				int userId = UserLogin.CurrentUser.UserId;
				mct_II_Result mct_II_Result = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.CRMspCopyRollPermissionBetweenCenters(fromCId, toCId, userId, value, registerDatePersian, appType, result));
				int result2 = 0;
				if (mct_II_Result != null)
				{
					int.TryParse(mct_II_Result.Result.ToString(), out result2);
				}
				if (result2 == 1)
				{
					text = "1";
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmsysRollPermission");
					List<CRMspSelectAllUsersPermissionByRollId_Result> list = Enumerable.ToList<CRMspSelectAllUsersPermissionByRollId_Result>((IEnumerable<CRMspSelectAllUsersPermissionByRollId_Result>)_dbII.CRMspSelectAllUsersPermissionByRollId(0, toCId, lCID, result));
					if (list != null && Enumerable.Any<CRMspSelectAllUsersPermissionByRollId_Result>((IEnumerable<CRMspSelectAllUsersPermissionByRollId_Result>)list))
					{
						foreach (CRMspSelectAllUsersPermissionByRollId_Result item in list)
						{
							Permissions.Update(item.UserId, item.CId);
						}
					}
				}
				else
				{
					text = Messages.msgErrorRunFunction;
				}
			}
			else
			{
				text = string.Format(Messages.msgErrorIsNotSelectedItem, Labels.Center);
			}
		}
		catch (Exception e)
		{
			text = Messages.msgErrorRunFunction;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return text;
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actuLinkedProjectsForbiddenForUser")]
	public ActionResult LinkedProjectsForbiddenForUser()
	{
		FillDropdownUsersAndData();
		return View();
	}

	[AjaxOnly]
	public ActionResult _PartialProjectsNotForbiddenForUser(int userId)
	{
		base.ViewBag.userId = userId;
		return PartialView();
	}

	public ActionResult ProjectsNotForbiddenForUser_Read([DataSourceRequest] DataSourceRequest request, int userId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CrmListItemViewModel> list = new List<CrmListItemViewModel>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			userId = ((userId != 0) ? userId : UserLogin.CurrentUser.UserId);
			List<mct_CRMspSelectCrmProjectsNotForbiddenForUser_Result> list2 = Enumerable.ToList<mct_CRMspSelectCrmProjectsNotForbiddenForUser_Result>((IEnumerable<mct_CRMspSelectCrmProjectsNotForbiddenForUser_Result>)db.mfi_CRMspSelectCrmProjectsNotForbiddenForUser(userId, lCID, result, result2));
			list.AddRange(Enumerable.Select<mct_CRMspSelectCrmProjectsNotForbiddenForUser_Result, CrmListItemViewModel>((IEnumerable<mct_CRMspSelectCrmProjectsNotForbiddenForUser_Result>)list2, (Func<mct_CRMspSelectCrmProjectsNotForbiddenForUser_Result, CrmListItemViewModel>)((mct_CRMspSelectCrmProjectsNotForbiddenForUser_Result item) => new CrmListItemViewModel
			{
				ItemName = item.prjTitle
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request));
	}

	public ActionResult _PartialProjectsForbiddenForUser(int userId)
	{
		base.ViewBag.userId = userId;
		return PartialView();
	}

	public ActionResult ProjectsForbiddenForUser_Read([DataSourceRequest] DataSourceRequest request, int userId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CrmListItemViewModel> list = new List<CrmListItemViewModel>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			userId = ((userId != 0) ? userId : UserLogin.CurrentUser.UserId);
			List<mct_CRMspSelectCrmProjectsForbiddenForUser_Result> list2 = Enumerable.ToList<mct_CRMspSelectCrmProjectsForbiddenForUser_Result>((IEnumerable<mct_CRMspSelectCrmProjectsForbiddenForUser_Result>)db.mfi_CRMspSelectCrmProjectsForbiddenForUser(userId, lCID, result, result2));
			list.AddRange(Enumerable.Select<mct_CRMspSelectCrmProjectsForbiddenForUser_Result, CrmListItemViewModel>((IEnumerable<mct_CRMspSelectCrmProjectsForbiddenForUser_Result>)list2, (Func<mct_CRMspSelectCrmProjectsForbiddenForUser_Result, CrmListItemViewModel>)((mct_CRMspSelectCrmProjectsForbiddenForUser_Result item) => new CrmListItemViewModel
			{
				ItemName = item.prjTitle
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request));
	}

	public string LinkedUserAndPrjAssign(int crmUserId, string prjTitle)
	{
		string result = "-1";
		try
		{
			int userId = UserLogin.CurrentUser.UserId;
			short value = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			short value2 = short.Parse(DateTime.Now.ToString("yyyy", new PersianCulture()));
			DateTime now = DateTime.Now;
			string text = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			if (crmUserId != 0 && prjTitle != "")
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
				if (result2 <= 0)
				{
					result2 = 1065;
				}
				_ = Thread.CurrentThread.CurrentCulture.LCID;
				int result3 = 0;
				if (UserLogin.CurrentUser != null)
				{
					int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
				}
				if (db.CRMspInsertCrmProjectsForbiddenForUser(crmUserId, prjTitle, now, text, userId, userId, value2, value, now, text, Configuration.AppType, result2, (result3 != 0) ? new int?(result3) : null) > 0)
				{
					result = "1";
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmProjectsForbiddenForUser", crmUserId);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public string LinkedUserAndPrjRemove(int crmUserId, string prjTitle)
	{
		string result = "-1";
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (crmUserId != 0 && prjTitle != "" && db.CRMspDeleteCrmProjectsForbiddenForUser(crmUserId, prjTitle, result2) > 0)
			{
				result = "1";
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmProjectsForbiddenForUser", crmUserId);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public string LinkedUserAndPrjAssignAll(int crmUserId)
	{
		string result = "-1";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			int userId = UserLogin.CurrentUser.UserId;
			short value = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			short value2 = short.Parse(DateTime.Now.ToString("yyyy", new PersianCulture()));
			DateTime now = DateTime.Now;
			string text = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			if (crmUserId != 0 && db.CRMspInsertCrmProjectsForbiddenForUserAll(crmUserId, now, text, userId, userId, value2, value, now, text, Configuration.AppType, result2, (result3 != 0) ? new int?(result3) : null) > 0)
			{
				result = "1";
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmProjectsForbiddenForUser", crmUserId);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public string LinkedUserAndPrjRemoveAll(int crmUserId)
	{
		string result = "-1";
		try
		{
			if (crmUserId != 0)
			{
				int result2 = 0;
				if (UserLogin.CurrentUser != null)
				{
					int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
				}
				mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)Enumerable.ToList<mct_Result>((IEnumerable<mct_Result>)db.CRMspDeleteCrmProjectsForbiddenForUserAll(crmUserId, result2)));
				if (mct_Result != null && mct_Result.Result > 0)
				{
					result = "1";
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmProjectsForbiddenForUser", crmUserId);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actuLinkedUsersAndData")]
	public ActionResult LinkedUsersAndData()
	{
		FillDropdownUsersAndData();
		return View();
	}

	private void FillDropdownUsersAndData()
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
		List<CRMspSelectActiveUsers_Result> list = Enumerable.ToList<CRMspSelectActiveUsers_Result>((IEnumerable<CRMspSelectActiveUsers_Result>)db.CRMspSelectActiveUsers(lCID, result, result2));
		List<SelectListItem> list2 = new List<SelectListItem>();
		list2.AddRange(Enumerable.Select<CRMspSelectActiveUsers_Result, SelectListItem>((IEnumerable<CRMspSelectActiveUsers_Result>)list, (Func<CRMspSelectActiveUsers_Result, SelectListItem>)((CRMspSelectActiveUsers_Result item) => new SelectListItem
		{
			Text = item.Name,
			Value = item.UserId.ToString(),
			Selected = false
		})));
		base.ViewBag.UsersList = list2;
	}

	[AjaxOnly]
	public string GetListNotForbiddenUserProvince(int userId)
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
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<CRMspSelectCompanyForbiddenProvinceForUser_Result> list = Enumerable.ToList<CRMspSelectCompanyForbiddenProvinceForUser_Result>((IEnumerable<CRMspSelectCompanyForbiddenProvinceForUser_Result>)_dbII.CRMspSelectCompanyForbiddenProvinceForUser(userId, result2, lCID, result));
			if (list != null && Enumerable.Any<CRMspSelectCompanyForbiddenProvinceForUser_Result>((IEnumerable<CRMspSelectCompanyForbiddenProvinceForUser_Result>)list))
			{
				foreach (CRMspSelectCompanyForbiddenProvinceForUser_Result item in list)
				{
					text = text + item.ForbiddenProvinceName + "," + item.ID + "|";
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return text;
	}

	[AjaxOnly]
	public string GetListNotForbiddenUserCity(int userId)
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
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<CRMspSelectCompanyForbiddenCityForUser_Result> list = Enumerable.ToList<CRMspSelectCompanyForbiddenCityForUser_Result>((IEnumerable<CRMspSelectCompanyForbiddenCityForUser_Result>)_dbII.CRMspSelectCompanyForbiddenCityForUser(userId, result2, lCID, result));
			if (list != null && Enumerable.Any<CRMspSelectCompanyForbiddenCityForUser_Result>((IEnumerable<CRMspSelectCompanyForbiddenCityForUser_Result>)list))
			{
				foreach (CRMspSelectCompanyForbiddenCityForUser_Result item in list)
				{
					text = text + item.ForbiddenCityName + "," + item.ID + "|";
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return text;
	}

	[AjaxOnly]
	public string GetListNotForbiddenUserGroup(int userId)
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
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<CRMspSelectCompanyForbiddenGroupForUser_Result> list = Enumerable.ToList<CRMspSelectCompanyForbiddenGroupForUser_Result>((IEnumerable<CRMspSelectCompanyForbiddenGroupForUser_Result>)_dbII.CRMspSelectCompanyForbiddenGroupForUser(userId, result2, lCID, result));
			if (list != null && Enumerable.Any<CRMspSelectCompanyForbiddenGroupForUser_Result>((IEnumerable<CRMspSelectCompanyForbiddenGroupForUser_Result>)list))
			{
				foreach (CRMspSelectCompanyForbiddenGroupForUser_Result item in list)
				{
					text = text + item.ForbiddenGroupName + "," + item.ID + "|";
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return text;
	}

	[AjaxOnly]
	public string GetListNotForbiddenUserSubGroup(int userId)
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
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<CRMspSelectCompanyForbiddenSubGroupForUser_Result> list = Enumerable.ToList<CRMspSelectCompanyForbiddenSubGroupForUser_Result>((IEnumerable<CRMspSelectCompanyForbiddenSubGroupForUser_Result>)_dbII.CRMspSelectCompanyForbiddenSubGroupForUser(userId, result2, lCID, result));
			if (list != null && Enumerable.Any<CRMspSelectCompanyForbiddenSubGroupForUser_Result>((IEnumerable<CRMspSelectCompanyForbiddenSubGroupForUser_Result>)list))
			{
				foreach (CRMspSelectCompanyForbiddenSubGroupForUser_Result item in list)
				{
					text = text + item.ForbiddenSubGroupName + "," + item.ID + "|";
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return text;
	}

	[AjaxOnly]
	public string GetListNotForbiddenUserGroupIv(int userId)
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
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<CRMspSelectCompanyForbiddenGroupIVForUser_Result> list = Enumerable.ToList<CRMspSelectCompanyForbiddenGroupIVForUser_Result>((IEnumerable<CRMspSelectCompanyForbiddenGroupIVForUser_Result>)_dbII.CRMspSelectCompanyForbiddenGroupIVForUser(userId, result2, lCID, result));
			if (list != null && Enumerable.Any<CRMspSelectCompanyForbiddenGroupIVForUser_Result>((IEnumerable<CRMspSelectCompanyForbiddenGroupIVForUser_Result>)list))
			{
				foreach (CRMspSelectCompanyForbiddenGroupIVForUser_Result item in list)
				{
					text = text + item.ForbiddenGroupIVName + "," + item.ID + "|";
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return text;
	}

	[AjaxOnly]
	public string GetListNotForbiddenUserCmpName(int userId)
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
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<CRMspSelectCompanyForbiddenCompanyForUser_Result> list = Enumerable.ToList<CRMspSelectCompanyForbiddenCompanyForUser_Result>((IEnumerable<CRMspSelectCompanyForbiddenCompanyForUser_Result>)_dbII.CRMspSelectCompanyForbiddenCompanyForUser(userId, result2, lCID, result));
			if (list != null && Enumerable.Any<CRMspSelectCompanyForbiddenCompanyForUser_Result>((IEnumerable<CRMspSelectCompanyForbiddenCompanyForUser_Result>)list))
			{
				foreach (CRMspSelectCompanyForbiddenCompanyForUser_Result item in list)
				{
					text = text + item.ForbiddenCompanyName + "," + item.ID + "|";
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return text;
	}

	[AjaxOnly]
	public string GetListJustAccessUserProvince(int userId)
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
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<CRMspSelectCompanyJustAccessProvinceForUser_Result> list = Enumerable.ToList<CRMspSelectCompanyJustAccessProvinceForUser_Result>((IEnumerable<CRMspSelectCompanyJustAccessProvinceForUser_Result>)_dbII.CRMspSelectCompanyJustAccessProvinceForUser(userId, result2, lCID, result));
			if (list != null && Enumerable.Any<CRMspSelectCompanyJustAccessProvinceForUser_Result>((IEnumerable<CRMspSelectCompanyJustAccessProvinceForUser_Result>)list))
			{
				foreach (CRMspSelectCompanyJustAccessProvinceForUser_Result item in list)
				{
					text = text + item.JustAccessProvinceName + "," + item.ID + "|";
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return text;
	}

	[AjaxOnly]
	public string GetListJustAccessUserCity(int userId)
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
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<CRMspSelectCompanyJustAccessCityForUser_Result> list = Enumerable.ToList<CRMspSelectCompanyJustAccessCityForUser_Result>((IEnumerable<CRMspSelectCompanyJustAccessCityForUser_Result>)_dbII.CRMspSelectCompanyJustAccessCityForUser(userId, result2, lCID, result));
			if (list != null && Enumerable.Any<CRMspSelectCompanyJustAccessCityForUser_Result>((IEnumerable<CRMspSelectCompanyJustAccessCityForUser_Result>)list))
			{
				foreach (CRMspSelectCompanyJustAccessCityForUser_Result item in list)
				{
					text = text + item.JustAccessCityName + "," + item.ID + "|";
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return text;
	}

	[AjaxOnly]
	public string GetListJustAccessUserGroup(int userId)
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
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<CRMspSelectCompanyJustAccessGroupForUser_Result> list = Enumerable.ToList<CRMspSelectCompanyJustAccessGroupForUser_Result>((IEnumerable<CRMspSelectCompanyJustAccessGroupForUser_Result>)_dbII.CRMspSelectCompanyJustAccessGroupForUser(userId, result2, lCID, result));
			if (list != null && Enumerable.Any<CRMspSelectCompanyJustAccessGroupForUser_Result>((IEnumerable<CRMspSelectCompanyJustAccessGroupForUser_Result>)list))
			{
				foreach (CRMspSelectCompanyJustAccessGroupForUser_Result item in list)
				{
					text = text + item.JustAccessGroupName + "," + item.ID + "|";
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return text;
	}

	[AjaxOnly]
	public string GetListJustAccessUserSubGroup(int userId)
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
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<CRMspSelectCompanyJustAccessSubGroupForUser_Result> list = Enumerable.ToList<CRMspSelectCompanyJustAccessSubGroupForUser_Result>((IEnumerable<CRMspSelectCompanyJustAccessSubGroupForUser_Result>)_dbII.CRMspSelectCompanyJustAccessSubGroupForUser(userId, result2, lCID, result));
			if (list != null && Enumerable.Any<CRMspSelectCompanyJustAccessSubGroupForUser_Result>((IEnumerable<CRMspSelectCompanyJustAccessSubGroupForUser_Result>)list))
			{
				foreach (CRMspSelectCompanyJustAccessSubGroupForUser_Result item in list)
				{
					text = text + item.JustAccessSubGroupName + "," + item.ID + "|";
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return text;
	}

	[AjaxOnly]
	public string GetListJustAccessUserGroupIv(int userId)
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
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<CRMspSelectCompanyJustAccessGroupIVForUser_Result> list = Enumerable.ToList<CRMspSelectCompanyJustAccessGroupIVForUser_Result>((IEnumerable<CRMspSelectCompanyJustAccessGroupIVForUser_Result>)_dbII.CRMspSelectCompanyJustAccessGroupIVForUser(userId, result2, lCID, result));
			if (list != null && Enumerable.Any<CRMspSelectCompanyJustAccessGroupIVForUser_Result>((IEnumerable<CRMspSelectCompanyJustAccessGroupIVForUser_Result>)list))
			{
				foreach (CRMspSelectCompanyJustAccessGroupIVForUser_Result item in list)
				{
					text = text + item.JustAccessGroupIVName + "," + item.ID + "|";
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return text;
	}

	[AjaxOnly]
	public string GetListJustAccessUserCmpName(int userId)
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
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<CRMspSelectCompanyJustAccessCompanyForUser_Result> list = Enumerable.ToList<CRMspSelectCompanyJustAccessCompanyForUser_Result>((IEnumerable<CRMspSelectCompanyJustAccessCompanyForUser_Result>)_dbII.CRMspSelectCompanyJustAccessCompanyForUser(userId, result2, lCID, result));
			if (list != null && Enumerable.Any<CRMspSelectCompanyJustAccessCompanyForUser_Result>((IEnumerable<CRMspSelectCompanyJustAccessCompanyForUser_Result>)list))
			{
				foreach (CRMspSelectCompanyJustAccessCompanyForUser_Result item in list)
				{
					text = text + item.JustAccessCompanyName + "," + item.ID + "|";
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return text;
	}

	[AjaxOnly]
	public string RemoveLinkUserAndData(int itemId, int mode, int userId)
	{
		string result = "-1";
		try
		{
			switch (mode)
			{
			case 1:
				_dbII.CRMspDeleteCompanyForbiddenProvince(itemId);
				result = GetListNotForbiddenUserProvince(userId);
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmCompanyForbiddenProvince", userId);
				return result;
			case 2:
				_dbII.CRMspDeleteCompanyForbiddenCity(itemId);
				result = GetListNotForbiddenUserCity(userId);
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmCompanyForbiddenCity", userId);
				return result;
			case 3:
				_dbII.CRMspDeleteCompanyForbiddenGroup(itemId);
				result = GetListNotForbiddenUserGroup(userId);
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmCompanyForbiddenGroup", userId);
				return result;
			case 4:
				_dbII.CRMspDeleteCompanyForbiddenSubGroup(itemId);
				result = GetListNotForbiddenUserSubGroup(userId);
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmCompanyForbiddenSubGroup", userId);
				return result;
			case 5:
				_dbII.CRMspDeleteCompanyForbiddenGroupIV(itemId);
				result = GetListNotForbiddenUserGroupIv(userId);
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmCompanyForbiddenGroupIV", userId);
				return result;
			case 6:
				_dbII.CRMspDeleteCompanyForbiddenCompany(itemId);
				result = GetListNotForbiddenUserCmpName(userId);
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmCompanyForbiddenCompany", userId);
				return result;
			case 7:
				_dbII.CRMspDeleteCompanyJustAccessProvince(itemId);
				result = GetListJustAccessUserProvince(userId);
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmCompanyJustAccessProvince", userId);
				return result;
			case 8:
				_dbII.CRMspDeleteCompanyJustAccessCity(itemId);
				result = GetListJustAccessUserCity(userId);
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmCompanyJustAccessCity", userId);
				return result;
			case 9:
				_dbII.CRMspDeleteCompanyJustAccessGroup(itemId);
				result = GetListJustAccessUserGroup(userId);
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmCompanyJustAccessGroup", userId);
				return result;
			case 10:
				_dbII.CRMspDeleteCompanyJustAccessSubGroup(itemId);
				result = GetListJustAccessUserSubGroup(userId);
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmCompanyJustAccessSubGroup", userId);
				return result;
			case 11:
				_dbII.CRMspDeleteCompanyJustAccessGroupIV(itemId);
				result = GetListJustAccessUserGroupIv(userId);
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmCompanyJustAccessGroupIV", userId);
				return result;
			case 12:
				_dbII.CRMspDeleteCompanyJustAccessCompany(itemId);
				result = GetListJustAccessUserCmpName(userId);
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmCompanyJustAccessCompany", userId);
				return result;
			default:
				result = "-1";
				break;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[AjaxOnly]
	public string AssignLinkUserAndData(int mode, int userId, string itemId)
	{
		string result = "-1";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			if (!string.IsNullOrEmpty(itemId))
			{
				itemId.Split(new char[1] { '|' });
				int userId2 = UserLogin.CurrentUser.UserId;
				short value = short.Parse(Financial.Get().Id.ToString());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				DateTime value3 = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				string appType = Configuration.AppType;
				switch (mode)
				{
				case 1:
					_dbII.CRMspInsertCompanyForbiddenProvince(userId, centerId, itemId, userId2, value, value2, value3, registerDatePersian, appType, result2);
					result = GetListNotForbiddenUserProvince(userId);
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmCompanyForbiddenProvince", userId);
					return result;
				case 2:
					_dbII.CRMspInsertCompanyForbiddenCity(userId, centerId, itemId, userId2, value, value2, value3, registerDatePersian, appType, result2);
					result = GetListNotForbiddenUserCity(userId);
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmCompanyForbiddenCity", userId);
					return result;
				case 3:
					_dbII.CRMspInsertCompanyForbiddenGroup(userId, centerId, itemId, userId2, value, value2, value3, registerDatePersian, appType, result2);
					result = GetListNotForbiddenUserGroup(userId);
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmCompanyForbiddenGroup", userId);
					return result;
				case 4:
					_dbII.CRMspInsertCompanyForbiddenSubGroup(userId, centerId, itemId, userId2, value, value2, value3, registerDatePersian, appType, result2);
					result = GetListNotForbiddenUserSubGroup(userId);
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmCompanyForbiddenSubGroup", userId);
					return result;
				case 5:
					_dbII.CRMspInsertCompanyForbiddenGroupIV(userId, centerId, itemId, userId2, value, value2, value3, registerDatePersian, appType, result2);
					result = GetListNotForbiddenUserGroupIv(userId);
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmCompanyForbiddenGroupIV", userId);
					return result;
				case 6:
					_dbII.CRMspInsertCompanyForbiddenCompany(userId, centerId, itemId, userId2, value, value2, value3, registerDatePersian, appType, result2);
					result = GetListNotForbiddenUserCmpName(userId);
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmCompanyForbiddenCompany", userId);
					return result;
				case 7:
					_dbII.CRMspInsertCompanyJustAccessProvince(userId, centerId, itemId, userId2, value, value2, value3, registerDatePersian, appType, result2);
					result = GetListJustAccessUserProvince(userId);
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmCompanyJustAccessProvince", userId);
					return result;
				case 8:
					_dbII.CRMspInsertCompanyJustAccessCity(userId, centerId, itemId, userId2, value, value2, value3, registerDatePersian, appType, result2);
					result = GetListJustAccessUserCity(userId);
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmCompanyJustAccessCity", userId);
					return result;
				case 9:
					_dbII.CRMspInsertCompanyJustAccessGroup(userId, centerId, itemId, userId2, value, value2, value3, registerDatePersian, appType, result2);
					result = GetListJustAccessUserGroup(userId);
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmCompanyJustAccessGroup", userId);
					return result;
				case 10:
					_dbII.CRMspInsertCompanyJustAccessSubGroup(userId, centerId, itemId, userId2, value, value2, value3, registerDatePersian, appType, result2);
					result = GetListJustAccessUserSubGroup(userId);
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmCompanyJustAccessSubGroup", userId);
					return result;
				case 11:
					_dbII.CRMspInsertCompanyJustAccessGroupIV(userId, centerId, itemId, userId2, value, value2, value3, registerDatePersian, appType, result2);
					result = GetListJustAccessUserGroupIv(userId);
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmCompanyJustAccessGroupIV", userId);
					return result;
				case 12:
					_dbII.CRMspInsertCompanyJustAccessCompany(userId, centerId, itemId, userId2, value, value2, value3, registerDatePersian, appType, result2);
					result = GetListJustAccessUserCmpName(userId);
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmCompanyJustAccessCompany", userId);
					return result;
				default:
					result = "-1";
					break;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public ActionResult LinkedUsersAndDataAddItems(int mode, int userId)
	{
		base.ViewBag.mode = mode;
		base.ViewBag.userId = userId;
		return View();
	}

	[AjaxOnly]
	public ActionResult _PartialLinkedUsersAndDataAddItems(int mode, int userId)
	{
		base.ViewBag.mode = mode;
		base.ViewBag.userId = userId;
		return PartialView();
	}

	[AjaxOnly]
	public ActionResult LinkedUsersAndDataAddItems_Read([DataSourceRequest] DataSourceRequest request, int mode, int userId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<LinkUserAndDateListItemViewModel> list = new List<LinkUserAndDateListItemViewModel>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			userId = ((userId != 0) ? userId : UserLogin.CurrentUser.UserId);
			switch (mode)
			{
			case 1:
			{
				List<CRMspLUADSelectNotForbiddenUserProvince_Result> list10 = Enumerable.ToList<CRMspLUADSelectNotForbiddenUserProvince_Result>((IEnumerable<CRMspLUADSelectNotForbiddenUserProvince_Result>)db.CRMspLUADSelectNotForbiddenUserProvince(userId, lCID, result, result2));
				list.AddRange(Enumerable.Select<CRMspLUADSelectNotForbiddenUserProvince_Result, LinkUserAndDateListItemViewModel>((IEnumerable<CRMspLUADSelectNotForbiddenUserProvince_Result>)list10, (Func<CRMspLUADSelectNotForbiddenUserProvince_Result, LinkUserAndDateListItemViewModel>)((CRMspLUADSelectNotForbiddenUserProvince_Result item) => new LinkUserAndDateListItemViewModel
				{
					ItemId = item.ProvinceID,
					ItemName = item.Province,
					ParentName = ""
				})));
				break;
			}
			case 2:
			{
				List<CRMspLUADSelectNotForbiddenUserCity_Result> list12 = Enumerable.ToList<CRMspLUADSelectNotForbiddenUserCity_Result>((IEnumerable<CRMspLUADSelectNotForbiddenUserCity_Result>)db.CRMspLUADSelectNotForbiddenUserCity(userId, lCID, result, result2));
				list.AddRange(Enumerable.Select<CRMspLUADSelectNotForbiddenUserCity_Result, LinkUserAndDateListItemViewModel>((IEnumerable<CRMspLUADSelectNotForbiddenUserCity_Result>)list12, (Func<CRMspLUADSelectNotForbiddenUserCity_Result, LinkUserAndDateListItemViewModel>)((CRMspLUADSelectNotForbiddenUserCity_Result item) => new LinkUserAndDateListItemViewModel
				{
					ItemId = item.CityID,
					ItemName = item.City,
					ParentName = item.Province
				})));
				break;
			}
			case 3:
			{
				List<CRMspLUADSelectNotForbiddenCompanyGroup_Result> list9 = Enumerable.ToList<CRMspLUADSelectNotForbiddenCompanyGroup_Result>((IEnumerable<CRMspLUADSelectNotForbiddenCompanyGroup_Result>)db.CRMspLUADSelectNotForbiddenCompanyGroup(userId, lCID, result, result2));
				list.AddRange(Enumerable.Select<CRMspLUADSelectNotForbiddenCompanyGroup_Result, LinkUserAndDateListItemViewModel>((IEnumerable<CRMspLUADSelectNotForbiddenCompanyGroup_Result>)list9, (Func<CRMspLUADSelectNotForbiddenCompanyGroup_Result, LinkUserAndDateListItemViewModel>)((CRMspLUADSelectNotForbiddenCompanyGroup_Result item) => new LinkUserAndDateListItemViewModel
				{
					ItemId = item.CompanyGroupID,
					ItemName = item.GroupName,
					ParentName = ""
				})));
				break;
			}
			case 4:
			{
				List<CRMspLUADSelectNotForbiddenCompanySubGroup_Result> list7 = Enumerable.ToList<CRMspLUADSelectNotForbiddenCompanySubGroup_Result>((IEnumerable<CRMspLUADSelectNotForbiddenCompanySubGroup_Result>)db.CRMspLUADSelectNotForbiddenCompanySubGroup(userId, lCID, result, result2));
				list.AddRange(Enumerable.Select<CRMspLUADSelectNotForbiddenCompanySubGroup_Result, LinkUserAndDateListItemViewModel>((IEnumerable<CRMspLUADSelectNotForbiddenCompanySubGroup_Result>)list7, (Func<CRMspLUADSelectNotForbiddenCompanySubGroup_Result, LinkUserAndDateListItemViewModel>)((CRMspLUADSelectNotForbiddenCompanySubGroup_Result item) => new LinkUserAndDateListItemViewModel
				{
					ItemId = item.CompanySubGroupID,
					ItemName = item.SubGroupName,
					ParentName = item.GroupName
				})));
				break;
			}
			case 5:
			{
				List<CRMspLUADSelectNotForbiddenCompanyGroupIV_Result> list3 = Enumerable.ToList<CRMspLUADSelectNotForbiddenCompanyGroupIV_Result>((IEnumerable<CRMspLUADSelectNotForbiddenCompanyGroupIV_Result>)db.CRMspLUADSelectNotForbiddenCompanyGroupIV(userId, lCID, result, result2));
				list.AddRange(Enumerable.Select<CRMspLUADSelectNotForbiddenCompanyGroupIV_Result, LinkUserAndDateListItemViewModel>((IEnumerable<CRMspLUADSelectNotForbiddenCompanyGroupIV_Result>)list3, (Func<CRMspLUADSelectNotForbiddenCompanyGroupIV_Result, LinkUserAndDateListItemViewModel>)((CRMspLUADSelectNotForbiddenCompanyGroupIV_Result item) => new LinkUserAndDateListItemViewModel
				{
					ItemId = item.CompanyGroupIVID,
					ItemName = item.GroupIVName,
					ParentName = ""
				})));
				break;
			}
			case 6:
			{
				List<CRMspLUADSelectNotForbiddenCompany_Result> list13 = Enumerable.ToList<CRMspLUADSelectNotForbiddenCompany_Result>((IEnumerable<CRMspLUADSelectNotForbiddenCompany_Result>)db.CRMspLUADSelectNotForbiddenCompany(userId, lCID, result, result2));
				list.AddRange(Enumerable.Select<CRMspLUADSelectNotForbiddenCompany_Result, LinkUserAndDateListItemViewModel>((IEnumerable<CRMspLUADSelectNotForbiddenCompany_Result>)list13, (Func<CRMspLUADSelectNotForbiddenCompany_Result, LinkUserAndDateListItemViewModel>)((CRMspLUADSelectNotForbiddenCompany_Result item) => new LinkUserAndDateListItemViewModel
				{
					ItemId = item.CompanyID,
					ItemName = item.cmpName,
					ParentName = ""
				})));
				break;
			}
			case 7:
			{
				List<CRMspLUADSelectNotJustAccessProvince_Result> list6 = Enumerable.ToList<CRMspLUADSelectNotJustAccessProvince_Result>((IEnumerable<CRMspLUADSelectNotJustAccessProvince_Result>)db.CRMspLUADSelectNotJustAccessProvince(userId, lCID, result, result2));
				list.AddRange(Enumerable.Select<CRMspLUADSelectNotJustAccessProvince_Result, LinkUserAndDateListItemViewModel>((IEnumerable<CRMspLUADSelectNotJustAccessProvince_Result>)list6, (Func<CRMspLUADSelectNotJustAccessProvince_Result, LinkUserAndDateListItemViewModel>)((CRMspLUADSelectNotJustAccessProvince_Result item) => new LinkUserAndDateListItemViewModel
				{
					ItemId = item.ProvinceID,
					ItemName = item.Province,
					ParentName = ""
				})));
				break;
			}
			case 8:
			{
				List<CRMspLUADSelectNotJustAccessCity_Result> list4 = Enumerable.ToList<CRMspLUADSelectNotJustAccessCity_Result>((IEnumerable<CRMspLUADSelectNotJustAccessCity_Result>)db.CRMspLUADSelectNotJustAccessCity(userId, lCID, result, result2));
				list.AddRange(Enumerable.Select<CRMspLUADSelectNotJustAccessCity_Result, LinkUserAndDateListItemViewModel>((IEnumerable<CRMspLUADSelectNotJustAccessCity_Result>)list4, (Func<CRMspLUADSelectNotJustAccessCity_Result, LinkUserAndDateListItemViewModel>)((CRMspLUADSelectNotJustAccessCity_Result item) => new LinkUserAndDateListItemViewModel
				{
					ItemId = item.CityID,
					ItemName = item.City,
					ParentName = item.Province
				})));
				break;
			}
			case 9:
			{
				List<CRMspLUADSelectNotJustAccessGroup_Result> list11 = Enumerable.ToList<CRMspLUADSelectNotJustAccessGroup_Result>((IEnumerable<CRMspLUADSelectNotJustAccessGroup_Result>)db.CRMspLUADSelectNotJustAccessGroup(userId, lCID, result, result2));
				list.AddRange(Enumerable.Select<CRMspLUADSelectNotJustAccessGroup_Result, LinkUserAndDateListItemViewModel>((IEnumerable<CRMspLUADSelectNotJustAccessGroup_Result>)list11, (Func<CRMspLUADSelectNotJustAccessGroup_Result, LinkUserAndDateListItemViewModel>)((CRMspLUADSelectNotJustAccessGroup_Result item) => new LinkUserAndDateListItemViewModel
				{
					ItemId = item.CompanyGroupID,
					ItemName = item.GroupName,
					ParentName = ""
				})));
				break;
			}
			case 10:
			{
				List<CRMspLUADSelectNotJustAccessSubGroup_Result> list8 = Enumerable.ToList<CRMspLUADSelectNotJustAccessSubGroup_Result>((IEnumerable<CRMspLUADSelectNotJustAccessSubGroup_Result>)db.CRMspLUADSelectNotJustAccessSubGroup(userId, lCID, result, result2));
				list.AddRange(Enumerable.Select<CRMspLUADSelectNotJustAccessSubGroup_Result, LinkUserAndDateListItemViewModel>((IEnumerable<CRMspLUADSelectNotJustAccessSubGroup_Result>)list8, (Func<CRMspLUADSelectNotJustAccessSubGroup_Result, LinkUserAndDateListItemViewModel>)((CRMspLUADSelectNotJustAccessSubGroup_Result item) => new LinkUserAndDateListItemViewModel
				{
					ItemId = item.CompanySubGroupID,
					ItemName = item.SubGroupName,
					ParentName = item.GroupName
				})));
				break;
			}
			case 11:
			{
				List<CRMspLUADSelectNotJustAccessGroupIV_Result> list5 = Enumerable.ToList<CRMspLUADSelectNotJustAccessGroupIV_Result>((IEnumerable<CRMspLUADSelectNotJustAccessGroupIV_Result>)db.CRMspLUADSelectNotJustAccessGroupIV(userId, lCID, result, result2));
				list.AddRange(Enumerable.Select<CRMspLUADSelectNotJustAccessGroupIV_Result, LinkUserAndDateListItemViewModel>((IEnumerable<CRMspLUADSelectNotJustAccessGroupIV_Result>)list5, (Func<CRMspLUADSelectNotJustAccessGroupIV_Result, LinkUserAndDateListItemViewModel>)((CRMspLUADSelectNotJustAccessGroupIV_Result item) => new LinkUserAndDateListItemViewModel
				{
					ItemId = item.CompanyGroupIVID,
					ItemName = item.GroupIVName,
					ParentName = ""
				})));
				break;
			}
			case 12:
			{
				List<CRMspLUADSelectNotJustAccessCompany_Result> list2 = Enumerable.ToList<CRMspLUADSelectNotJustAccessCompany_Result>((IEnumerable<CRMspLUADSelectNotJustAccessCompany_Result>)db.CRMspLUADSelectNotJustAccessCompany(userId, lCID, result, result2));
				list.AddRange(Enumerable.Select<CRMspLUADSelectNotJustAccessCompany_Result, LinkUserAndDateListItemViewModel>((IEnumerable<CRMspLUADSelectNotJustAccessCompany_Result>)list2, (Func<CRMspLUADSelectNotJustAccessCompany_Result, LinkUserAndDateListItemViewModel>)((CRMspLUADSelectNotJustAccessCompany_Result item) => new LinkUserAndDateListItemViewModel
				{
					ItemId = item.CompanyID,
					ItemName = item.cmpName,
					ParentName = ""
				})));
				break;
			}
			default:
				list = null;
				break;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	public FileResult GetUserPicture(int uId)
	{
		byte[] array = null;
		try
		{
			CRMspSelectUserPicturesByUserId_Result cRMspSelectUserPicturesByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserPicturesByUserId_Result>((IEnumerable<CRMspSelectUserPicturesByUserId_Result>)db.CRMspSelectUserPicturesByUserId(uId));
			if (cRMspSelectUserPicturesByUserId_Result != null)
			{
				array = cRMspSelectUserPicturesByUserId_Result.UserPicture;
				new MemoryStream();
				Image.FromStream((Stream)new MemoryStream(array, writable: false));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return File(array, "image/png");
	}

	public string GetUserPictureI(int uId)
	{
		string text = "";
		try
		{
			CRMspSelectUserPicturesByUserId_Result cRMspSelectUserPicturesByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserPicturesByUserId_Result>((IEnumerable<CRMspSelectUserPicturesByUserId_Result>)db.CRMspSelectUserPicturesByUserId(uId));
			if (cRMspSelectUserPicturesByUserId_Result != null)
			{
				byte[] userPicture = cRMspSelectUserPicturesByUserId_Result.UserPicture;
				new MemoryStream();
				text = Convert.ToBase64String(new MemoryStream(userPicture, writable: false).ToArray());
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return "data:image/jpg;base64," + text;
	}

	[AjaxOnly]
	public ActionResult _PartialUserPicture(int userId)
	{
		base.ViewBag.CurrUserId = userId;
		return PartialView();
	}

	[AjaxOnly]
	public JsonResult GetUserMoreInfo(int currUserId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		CurrentUserMoreInfoViewModel currentUserMoreInfoViewModel = new CurrentUserMoreInfoViewModel();
		currentUserMoreInfoViewModel.CurrUser = new CRMspSelectUsers_Result();
		try
		{
			List<CRMspSelectUsers_Result> list = CRMIdeal.Classes.Helper.User.SelectUsers();
			if (list != null && Enumerable.Any<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)list))
			{
				list = Enumerable.ToList<CRMspSelectUsers_Result>(Enumerable.Where<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)list, (Func<CRMspSelectUsers_Result, bool>)((CRMspSelectUsers_Result m) => m.UserId > 0)));
			}
			if (Enumerable.Any<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)list))
			{
				currentUserMoreInfoViewModel.IsFind = true;
				currentUserMoreInfoViewModel.Message = "";
				currentUserMoreInfoViewModel.PreviousUserId = -1;
				currentUserMoreInfoViewModel.NextUserId = -1;
				currentUserMoreInfoViewModel.FirstUserId = -1;
				currentUserMoreInfoViewModel.LastUserId = -1;
				if (list.Count == 1)
				{
					currentUserMoreInfoViewModel.FirstUserId = -1;
					currentUserMoreInfoViewModel.LastUserId = -1;
				}
				else
				{
					currentUserMoreInfoViewModel.FirstUserId = Enumerable.FirstOrDefault<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)list).UserId;
					currentUserMoreInfoViewModel.LastUserId = Enumerable.LastOrDefault<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)list).UserId;
				}
				CRMspSelectUsers_Result cRMspSelectUsers_Result = ((currUserId <= 0) ? Enumerable.LastOrDefault<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)list) : list.Find((CRMspSelectUsers_Result c) => c.UserId == currUserId));
				if (cRMspSelectUsers_Result != null)
				{
					cRMspSelectUsers_Result.FirstRegisterDatePersian = (cRMspSelectUsers_Result.FirstRegisterDate.HasValue ? cRMspSelectUsers_Result.FirstRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : null);
					cRMspSelectUsers_Result.RegisterDatePersian = (cRMspSelectUsers_Result.RegisterDate.HasValue ? cRMspSelectUsers_Result.RegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : null);
					if (string.IsNullOrEmpty(cRMspSelectUsers_Result.AppType))
					{
						cRMspSelectUsers_Result.AppType = Configuration.AppType;
					}
					cRMspSelectUsers_Result.AppType = Configuration.GetAppType(cRMspSelectUsers_Result.AppType);
					currentUserMoreInfoViewModel.CurrUser = cRMspSelectUsers_Result;
					currentUserMoreInfoViewModel.CurrentUserId = cRMspSelectUsers_Result.UserId;
					if (list.Count == 1)
					{
						currentUserMoreInfoViewModel.NextUserId = -1;
						currentUserMoreInfoViewModel.PreviousUserId = -1;
					}
					else
					{
						CRMspSelectUsers_Result next = Lists.GetNext(list, cRMspSelectUsers_Result);
						if (next != null)
						{
							currentUserMoreInfoViewModel.NextUserId = next.UserId;
						}
						CRMspSelectUsers_Result previous = Lists.GetPrevious(list, cRMspSelectUsers_Result);
						if (previous != null)
						{
							currentUserMoreInfoViewModel.PreviousUserId = previous.UserId;
						}
					}
				}
				else
				{
					currentUserMoreInfoViewModel.IsFind = false;
					currentUserMoreInfoViewModel.Message = Messages.ErrorNotFound;
					currentUserMoreInfoViewModel.CurrUser = null;
					currentUserMoreInfoViewModel.CurrentUserId = -1;
					currentUserMoreInfoViewModel.NextUserId = -1;
					currentUserMoreInfoViewModel.PreviousUserId = -1;
					currentUserMoreInfoViewModel.FirstUserId = -1;
					currentUserMoreInfoViewModel.LastUserId = -1;
				}
			}
			else
			{
				currentUserMoreInfoViewModel.IsFind = false;
				currentUserMoreInfoViewModel.Message = Messages.ErrorNotFound;
				currentUserMoreInfoViewModel.CurrUser = null;
				currentUserMoreInfoViewModel.CurrentUserId = -1;
				currentUserMoreInfoViewModel.NextUserId = -1;
				currentUserMoreInfoViewModel.PreviousUserId = -1;
				currentUserMoreInfoViewModel.FirstUserId = -1;
				currentUserMoreInfoViewModel.LastUserId = -1;
			}
		}
		catch (DbEntityValidationException ex)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)ex);
			currentUserMoreInfoViewModel.Message = Messages.frmErrorMessage + "<br />" + ((Exception)(object)ex).Message;
		}
		catch (Exception ex2)
		{
			ErrorSignal.FromCurrentContext().Raise(ex2);
			currentUserMoreInfoViewModel.Message = Messages.frmErrorMessage + "<br />" + ex2.Message;
		}
		JsonResult jsonResult = Json(currentUserMoreInfoViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[DynamicAuthorize(ControllerName = "frmDefineUsers", ActionName = "actEditMoreInfo")]
	public ActionResult UserMoreInfo(int userId = 0)
	{
		_003C_003Ec__DisplayClass121_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass121_0();
		CS_0024_003C_003E8__locals0.userId = userId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		UserMoreInfoLanguageViewModel model = new UserMoreInfoLanguageViewModel();
		try
		{
			if (CS_0024_003C_003E8__locals0.userId > 0)
			{
				DbSet<Users_Lang> users_Lang = _dbTbl.Users_Lang;
				ParameterExpression val = Expression.Parameter(typeof(Users_Lang), "c");
				List<Users_Lang> list = Enumerable.ToList<Users_Lang>((IEnumerable<Users_Lang>)Queryable.Where<Users_Lang>((IQueryable<Users_Lang>)users_Lang, Expression.Lambda<Func<Users_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass121_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
				DbSet<Users> users = _dbTbl.Users;
				val = Expression.Parameter(typeof(Users), "c");
				Users users2 = Queryable.FirstOrDefault<Users>((IQueryable<Users>)users, Expression.Lambda<Func<Users, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass121_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (users2 == null)
				{
					base.ViewBag.Error = Messages.ErrorNotFound;
					return null;
				}
				List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<Users_Lang, CommonMultiLanguageViewModel>((IEnumerable<Users_Lang>)list, (Func<Users_Lang, CommonMultiLanguageViewModel>)((Users_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.FName,
					LanguageId = item.LanguageID
				})));
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = users2.FName,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<Users_Lang, CommonMultiLanguageViewModel>((IEnumerable<Users_Lang>)list, (Func<Users_Lang, CommonMultiLanguageViewModel>)((Users_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.LName,
					LanguageId = item.LanguageID
				})));
				list3.Add(new CommonMultiLanguageViewModel
				{
					Value = users2.LName,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<Users_Lang, CommonMultiLanguageViewModel>((IEnumerable<Users_Lang>)list, (Func<Users_Lang, CommonMultiLanguageViewModel>)((Users_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.TelDesc,
					LanguageId = item.LanguageID
				})));
				list4.Add(new CommonMultiLanguageViewModel
				{
					Value = users2.TelDesc,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list5 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<Users_Lang, CommonMultiLanguageViewModel>((IEnumerable<Users_Lang>)list, (Func<Users_Lang, CommonMultiLanguageViewModel>)((Users_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.Address,
					LanguageId = item.LanguageID
				})));
				list5.Add(new CommonMultiLanguageViewModel
				{
					Value = users2.Address,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list6 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<Users_Lang, CommonMultiLanguageViewModel>((IEnumerable<Users_Lang>)list, (Func<Users_Lang, CommonMultiLanguageViewModel>)((Users_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.FatherName,
					LanguageId = item.LanguageID
				})));
				list6.Add(new CommonMultiLanguageViewModel
				{
					Value = users2.FatherName,
					LanguageId = result
				});
				model = new UserMoreInfoLanguageViewModel
				{
					UserId = users2.UserId,
					FName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					FName_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					LName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					LName_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					Tel = users2.Tel,
					TelDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					TelDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					Mobile = users2.Mobile,
					MobileII = users2.MobileII,
					Address = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					Address_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					FatherName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					FatherName_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					NationalCode = users2.NationalCode,
					IdentityNumber = users2.IdentityNumber,
					InsuranceCode = users2.InsuranceCode
				};
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			base.ViewBag.Error = Messages.msgErrorRunFunction;
		}
		return View(model);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmDefineUsers", ActionName = "actEditMoreInfo")]
	[ValidateAntiForgeryToken]
	public ActionResult UserMoreInfo(UserMoreInfoLanguageViewModel vm)
	{
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass122_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass122_0();
		CS_0024_003C_003E8__locals0.vm = vm;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.FName_Lang))
		{
			list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.FName_Lang);
		}
		list.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.FName,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.LName_Lang))
		{
			list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.LName_Lang);
		}
		list2.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.LName,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.TelDesc_Lang))
		{
			list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.TelDesc_Lang);
		}
		list3.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.TelDesc,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.Address_Lang))
		{
			list4 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.Address_Lang);
		}
		list4.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.Address,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list5 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.FatherName_Lang))
		{
			list5 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.FatherName_Lang);
		}
		list5.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.FatherName,
			LanguageId = lCID
		});
		string text = "";
		if (text != "")
		{
			base.ViewBag.Error = text;
			return View(CS_0024_003C_003E8__locals0.vm);
		}
		try
		{
			if (!base.ModelState.IsValid)
			{
				base.ViewBag.Error = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
			else
			{
				_003C_003Ec__DisplayClass122_1 _003C_003Ec__DisplayClass122_ = new _003C_003Ec__DisplayClass122_1();
				DateTime now = DateTime.Now;
				DateTime value = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				_ = Financial.Get().Id;
				int userId = UserLogin.CurrentUser.UserId;
				_003C_003Ec__DisplayClass122_.model = new Users();
				if (CS_0024_003C_003E8__locals0.vm.UserId > 0)
				{
					DbSet<Users> users = _dbTbl.Users;
					ParameterExpression val = Expression.Parameter(typeof(Users), "c");
					_003C_003Ec__DisplayClass122_.model = Queryable.FirstOrDefault<Users>((IQueryable<Users>)users, Expression.Lambda<Func<Users, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass122_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				}
				_003C_003Ec__DisplayClass122_.model.Tel = CS_0024_003C_003E8__locals0.vm.Tel;
				_003C_003Ec__DisplayClass122_.model.TelDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass122_.model.Mobile = CS_0024_003C_003E8__locals0.vm.Mobile;
				_003C_003Ec__DisplayClass122_.model.MobileII = CS_0024_003C_003E8__locals0.vm.MobileII;
				_003C_003Ec__DisplayClass122_.model.Address = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass122_.model.FatherName = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass122_.model.NationalCode = CS_0024_003C_003E8__locals0.vm.NationalCode;
				_003C_003Ec__DisplayClass122_.model.IdentityNumber = CS_0024_003C_003E8__locals0.vm.IdentityNumber;
				_003C_003Ec__DisplayClass122_.model.InsuranceCode = CS_0024_003C_003E8__locals0.vm.InsuranceCode;
				_003C_003Ec__DisplayClass122_.model.UserId1 = userId;
				_003C_003Ec__DisplayClass122_.model.Month1 = value2;
				_003C_003Ec__DisplayClass122_.model.RegisterDate = value;
				_003C_003Ec__DisplayClass122_.model.RegisterDatePersian = registerDatePersian;
				_003C_003Ec__DisplayClass122_.model.AppType = appType;
				if (_003C_003Ec__DisplayClass122_.model.UserId > 0)
				{
					_dbTbl.Entry(_003C_003Ec__DisplayClass122_.model).State = EntityState.Modified;
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							_003C_003Ec__DisplayClass122_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass122_2();
							CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass122_;
							CS_0024_003C_003E8__locals1.lang = enumerator.Current;
							DbSet<Users_Lang> users_Lang = _dbTbl.Users_Lang;
							ParameterExpression val = Expression.Parameter(typeof(Users_Lang), "c");
							Users_Lang users_Lang2 = Queryable.FirstOrDefault<Users_Lang>((IQueryable<Users_Lang>)users_Lang, Expression.Lambda<Func<Users_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass122_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass122_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (users_Lang2 != null)
							{
								users_Lang2.TelDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								users_Lang2.Address = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								users_Lang2.FatherName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								_dbTbl.Entry(users_Lang2).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							users_Lang2 = new Users_Lang();
							users_Lang2.LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID;
							users_Lang2.UserId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.UserId;
							users_Lang2.TelDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							users_Lang2.Address = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							users_Lang2.FatherName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							_dbTbl.Users_Lang.Add(users_Lang2);
							_dbTbl.SaveChanges();
						}
					}
					base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
				}
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
			base.ViewBag.Error = Messages.msgErrorRunFunction;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			base.ViewBag.Error = Messages.msgErrorRunFunction;
		}
		return View(CS_0024_003C_003E8__locals0.vm);
	}

	public void SetRegisterInfoForUserPicture(UserPicturesViewModel model)
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
			CRMspSelectUsersById_Result cRMspSelectUsersById_Result = CRMIdeal.Classes.Helper.User.SelectUsersById(model.FirstRegisterUserId);
			if (cRMspSelectUsersById_Result != null)
			{
				text3 = cRMspSelectUsersById_Result.FullName ?? "";
			}
			CRMspSelectUsersById_Result cRMspSelectUsersById_Result2 = CRMIdeal.Classes.Helper.User.SelectUsersById(model.UserId);
			if (cRMspSelectUsersById_Result2 != null)
			{
				text4 = cRMspSelectUsersById_Result2.FullName ?? "";
			}
			_ = model.FirstRegisterDate;
			string text5 = model.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
			_ = model.RegisterDate;
			string text6 = model.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
			if (string.IsNullOrEmpty(model.AppType))
			{
				model.AppType = Configuration.AppType;
			}
			string text7 = Labels.AppType + ": " + Configuration.GetAppType(model.AppType);
			if (model.AppType != "new")
			{
				text = Labels.frmFirstRegisterUser + ": " + text3 + " (" + text5 + ")";
				text2 = Labels.frmRegisterUser + ": " + text4 + " (" + text7 + ") (" + text6 + ")";
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

	[DynamicAuthorize(ControllerName = "frmDefineUsers", ActionName = "actInsertUserPicture")]
	public ActionResult UserPictureUpload(int userId)
	{
		UserPicturesViewModel userPicturesViewModel = new UserPicturesViewModel();
		try
		{
			DateTime now = DateTime.Now;
			if (userId > 0)
			{
				CRMspSelectUserPicturesByUserId_Result cRMspSelectUserPicturesByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserPicturesByUserId_Result>((IEnumerable<CRMspSelectUserPicturesByUserId_Result>)db.CRMspSelectUserPicturesByUserId(userId));
				if (cRMspSelectUserPicturesByUserId_Result != null)
				{
					userPicturesViewModel.UserPictureId = cRMspSelectUserPicturesByUserId_Result.UserPictureId;
					userPicturesViewModel.UserId = cRMspSelectUserPicturesByUserId_Result.UserId;
					userPicturesViewModel.FirstRegisterUserId = cRMspSelectUserPicturesByUserId_Result.FirstRegisterUserId;
					userPicturesViewModel.RegisterDate = cRMspSelectUserPicturesByUserId_Result.RegisterDate;
					userPicturesViewModel.FirstRegisterDate = cRMspSelectUserPicturesByUserId_Result.FirstRegisterDate;
					userPicturesViewModel.FirstRegisterDatePersian = cRMspSelectUserPicturesByUserId_Result.FirstRegisterDatePersian;
					userPicturesViewModel.RegisterDatePersian = cRMspSelectUserPicturesByUserId_Result.RegisterDatePersian;
					userPicturesViewModel.AppType = cRMspSelectUserPicturesByUserId_Result.AppType;
					userPicturesViewModel.CrmUserId = cRMspSelectUserPicturesByUserId_Result.CrmUserId;
				}
				else
				{
					userPicturesViewModel.UserId = UserLogin.CurrentUser.UserId;
					userPicturesViewModel.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
					userPicturesViewModel.RegisterDate = now;
					userPicturesViewModel.FirstRegisterDate = now;
					userPicturesViewModel.AppType = "new";
					userPicturesViewModel.CrmUserId = userId;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			base.ViewBag.Error = Messages.msgErrorRunFunction;
		}
		base.ViewBag.Update = false;
		SetRegisterInfoForUserPicture(userPicturesViewModel);
		return View(userPicturesViewModel);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	[DynamicAuthorize(ControllerName = "frmDefineUsers", ActionName = "actInsertUserPicture")]
	public ActionResult UserPictureUpload(UserPicturesViewModel vm, HttpPostedFileBase UserPictureUrlUpload)
	{
		_003C_003Ec__DisplayClass125_0 _003C_003Ec__DisplayClass125_ = new _003C_003Ec__DisplayClass125_0();
		_003C_003Ec__DisplayClass125_.vm = vm;
		if (base.ModelState.IsValid)
		{
			try
			{
				SetRegisterInfoForUserPicture(_003C_003Ec__DisplayClass125_.vm);
				if (UserPictureUrlUpload == null)
				{
					base.ModelState.AddModelError("error", Messages.frmErrorNotFileSelected);
					return View(_003C_003Ec__DisplayClass125_.vm);
				}
				string text = UserPictureUrlUpload.ContentType.ToLower();
				string text2 = Path.GetExtension(UserPictureUrlUpload.FileName).ToLower();
				if ((text != "image/jpg" && text != "image/jpeg" && text != "image/pjpeg" && text != "image/gif" && text != "image/x-png" && text != "image/png") || (text2 != ".jpg" && text2 != ".png" && text2 != ".gif" && text2 != ".jpeg"))
				{
					base.ModelState.AddModelError("error", Messages.frmErrorNotImageFile);
					return View(_003C_003Ec__DisplayClass125_.vm);
				}
				if (UserPictureUrlUpload.ContentLength / 1024 > Configuration.MaxImageSizeForUploadKb)
				{
					base.ModelState.AddModelError("error", string.Format(Messages.frmErrorMaxImageSizeForUpload, Configuration.MaxImageSizeForUploadKb));
					return View(_003C_003Ec__DisplayClass125_.vm);
				}
				DateTime now = DateTime.Now;
				DateTime dateTime = now;
				string text3 = now.ToString("yyyyMMdd", new PersianCulture());
				short month = short.Parse(now.ToString("MM", new PersianCulture()));
				_ = Configuration.AppType;
				short year = short.Parse(Financial.Get().Id.ToString());
				int userId = UserLogin.CurrentUser.UserId;
				DbSet<UserPictures> userPictures = _dbTbl.UserPictures;
				ParameterExpression val = Expression.Parameter(typeof(UserPictures), "c");
				UserPictures userPictures2 = Queryable.FirstOrDefault<UserPictures>((IQueryable<UserPictures>)userPictures, Expression.Lambda<Func<UserPictures, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass125_, typeof(_003C_003Ec__DisplayClass125_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				bool flag = false;
				if (userPictures2 == null)
				{
					userPictures2 = new UserPictures();
					flag = true;
					userPictures2.GUId = System.Guid.NewGuid();
				}
				userPictures2.CrmUserId = _003C_003Ec__DisplayClass125_.vm.CrmUserId;
				userPictures2.RegisterDate = dateTime;
				userPictures2.RegisterDatePersian = text3;
				userPictures2.UserId = userId;
				userPictures2.Year1 = year;
				userPictures2.Month1 = month;
				_ = string.Empty;
				_ = string.Empty;
				if (UserPictureUrlUpload != null)
				{
					userPictures2.UserPicture = ImageManager.CompressHttpPostedFileBase(new ImageManager.ImageParam
					{
						HttpPostedFileBase_Var = UserPictureUrlUpload
					});
				}
				else
				{
					userPictures2.UserPicture = null;
				}
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				userPictures2.AppType = Configuration.AppType;
				if (flag)
				{
					userPictures2.FirstRegisterUserId = userId;
					userPictures2.FirstRegisterDate = dateTime;
					userPictures2.FirstRegisterDatePersian = text3;
					userPictures2.LanguageID = result;
					_dbTbl.UserPictures.Add(userPictures2);
				}
				else
				{
					_dbTbl.Entry(userPictures2).State = EntityState.Modified;
				}
				_dbTbl.SaveChanges();
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("UserPictures", _003C_003Ec__DisplayClass125_.vm.UserPictureId);
				_003C_003Ec__DisplayClass125_.vm.UserPictureId = userPictures2.UserPictureId;
				base.ViewBag.Update = true;
				_003C_003Ec__DisplayClass125_.vm.UserId = userPictures2.UserId;
				_003C_003Ec__DisplayClass125_.vm.FirstRegisterUserId = userPictures2.FirstRegisterUserId;
				_003C_003Ec__DisplayClass125_.vm.RegisterDate = userPictures2.RegisterDate;
				_003C_003Ec__DisplayClass125_.vm.FirstRegisterDate = userPictures2.FirstRegisterDate;
				_003C_003Ec__DisplayClass125_.vm.AppType = userPictures2.AppType;
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				base.ModelState.AddModelError("error", Messages.frmErrorInSendingFile);
			}
		}
		SetRegisterInfoForUserPicture(_003C_003Ec__DisplayClass125_.vm);
		return View(_003C_003Ec__DisplayClass125_.vm);
	}

	public string DeleteUserPicture(int userId)
	{
		string result = "0";
		try
		{
			_ = DateTime.Now;
			if (userId > 0)
			{
				CRMspSelectUserPicturesByUserId_Result cRMspSelectUserPicturesByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserPicturesByUserId_Result>((IEnumerable<CRMspSelectUserPicturesByUserId_Result>)db.CRMspSelectUserPicturesByUserId(userId));
				if (cRMspSelectUserPicturesByUserId_Result != null)
				{
					mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)db.CRMspDeleteUserPictures(cRMspSelectUserPicturesByUserId_Result.UserPictureId));
					if (mct_Result != null && mct_Result.Result == 1)
					{
						result = "1";
					}
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("UserPictures", userId);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public ActionResult UserFiles_Read([DataSourceRequest] DataSourceRequest request, int userId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectFilesDirectory_Result> list = new List<CRMspSelectFilesDirectory_Result>();
		try
		{
			list = Files.SelectFilesDirectory("", "", "", "80", userId.ToString(), "0", "0", false);
			if (list != null && Enumerable.Any<CRMspSelectFilesDirectory_Result>((IEnumerable<CRMspSelectFilesDirectory_Result>)list))
			{
				foreach (CRMspSelectFilesDirectory_Result item in list)
				{
					DateTime now = DateTime.Now;
					if (item.DocDateTime.HasValue)
					{
						item.DocDate = DateTime.Parse(item.DocDateTime.ToString()).ToString("yyyy/MM/dd");
					}
					else if (!string.IsNullOrEmpty(item.DocDate))
					{
						item.DocDate = PersianDate.GetFormatetdDate(item.DocDate);
					}
					if (!string.IsNullOrEmpty(item.DocDay))
					{
						item.DocDay = DateTimeClass.ConvertNumToDayeOfWeek(int.Parse(item.DocDay));
					}
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

	public void SetRegisterInfoFile(CrmFilesDirectoryLanguageViewModel model, ref string firstRegInfo, ref string regInfo)
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
			CRMspSelectUsersById_Result cRMspSelectUsersById_Result = CRMIdeal.Classes.Helper.User.SelectUsersById(model.FirstRegisterUserId);
			if (cRMspSelectUsersById_Result != null)
			{
				firstRegInfo = ((!string.IsNullOrEmpty(cRMspSelectUsersById_Result.LName)) ? cRMspSelectUsersById_Result.LName : "") + ((!string.IsNullOrEmpty(cRMspSelectUsersById_Result.FName)) ? (" " + cRMspSelectUsersById_Result.FName) : "");
				string text = (model.FirstRegisterDate.HasValue ? model.FirstRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
				firstRegInfo += ((!string.IsNullOrEmpty(text)) ? (" (" + text + ")") : "");
			}
			CRMspSelectUsersById_Result cRMspSelectUsersById_Result2 = CRMIdeal.Classes.Helper.User.SelectUsersById(model.UserId);
			if (cRMspSelectUsersById_Result2 != null)
			{
				regInfo = ((!string.IsNullOrEmpty(cRMspSelectUsersById_Result2.LName)) ? cRMspSelectUsersById_Result2.LName : "") + ((!string.IsNullOrEmpty(cRMspSelectUsersById_Result2.FName)) ? (" " + cRMspSelectUsersById_Result2.FName) : "");
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

	[DynamicAuthorize(ControllerName = "frmDefineUsers", ActionName = "actInsertFile,actEditFile")]
	public ActionResult FileInsertEdit(int userId, int fileId = 0)
	{
		_003C_003Ec__DisplayClass129_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass129_0();
		CS_0024_003C_003E8__locals0.fileId = fileId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = Configuration.HostTempFilesPath + "/" + Configuration.TmpFileDirectoryPath + "/" + UserLogin.CurrentUser.UserId;
		string path = base.Server.MapPath(text);
		if (System.IO.Directory.Exists(path))
		{
			try
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
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
		}
		CrmFilesDirectoryLanguageViewModel crmFilesDirectoryLanguageViewModel;
		ParameterExpression val;
		try
		{
			GetFileType(80);
			if (CS_0024_003C_003E8__locals0.fileId > 0)
			{
				if (!UserLogin.IsUserAccess("frmDefineUsers", "actEditFile"))
				{
					base.ViewBag.Error = Messages.NotAccessToPage;
					return null;
				}
				DbSet<CrmFilesDirectory> crmFilesDirectory = _dbTbl.CrmFilesDirectory;
				val = Expression.Parameter(typeof(CrmFilesDirectory), "c");
				CrmFilesDirectory crmFilesDirectory2 = Queryable.FirstOrDefault<CrmFilesDirectory>((IQueryable<CrmFilesDirectory>)crmFilesDirectory, Expression.Lambda<Func<CrmFilesDirectory, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass129_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (crmFilesDirectory2 == null)
				{
					DateTime now = DateTime.Now;
					crmFilesDirectoryLanguageViewModel = new CrmFilesDirectoryLanguageViewModel
					{
						UserId = UserLogin.CurrentUser.UserId,
						Year1 = short.Parse(Financial.Get().Id.ToString()),
						Month1 = short.Parse(now.ToString("MM", new PersianCulture())),
						RegisterDate = now,
						RegisterDatePersian = now.ToString("yyyyMMdd"),
						DocDate = now.ToString("yyyyMMdd"),
						DocTime = now.ToString("HH:mm:ss"),
						DocDay = DefineDayeOfWeek(),
						FirstRegisterUserId = UserLogin.CurrentUser.UserId,
						FirstRegisterDate = now,
						AppTypeHelp = Configuration.AppType
					};
					base.ViewBag.Error = Messages.ErrorNotFound;
				}
				else
				{
					DbSet<CrmFilesDirectory_Lang> crmFilesDirectory_Lang = _dbTbl.CrmFilesDirectory_Lang;
					val = Expression.Parameter(typeof(CrmFilesDirectory_Lang), "c");
					List<CrmFilesDirectory_Lang> list = Enumerable.ToList<CrmFilesDirectory_Lang>((IEnumerable<CrmFilesDirectory_Lang>)Queryable.Where<CrmFilesDirectory_Lang>((IQueryable<CrmFilesDirectory_Lang>)crmFilesDirectory_Lang, Expression.Lambda<Func<CrmFilesDirectory_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass129_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
					List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFilesDirectory_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmFilesDirectory_Lang>)list, (Func<CrmFilesDirectory_Lang, CommonMultiLanguageViewModel>)((CrmFilesDirectory_Lang item) => new CommonMultiLanguageViewModel
					{
						Value = item.Title,
						LanguageId = item.LanguageID
					})));
					list2.Add(new CommonMultiLanguageViewModel
					{
						Value = crmFilesDirectory2.Title,
						LanguageId = result
					});
					List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFilesDirectory_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmFilesDirectory_Lang>)list, (Func<CrmFilesDirectory_Lang, CommonMultiLanguageViewModel>)((CrmFilesDirectory_Lang item) => new CommonMultiLanguageViewModel
					{
						Value = item.FileDesc,
						LanguageId = item.LanguageID
					})));
					list3.Add(new CommonMultiLanguageViewModel
					{
						Value = crmFilesDirectory2.FileDesc,
						LanguageId = result
					});
					crmFilesDirectoryLanguageViewModel = new CrmFilesDirectoryLanguageViewModel
					{
						MasterId = crmFilesDirectory2.MasterId,
						SubDetailId = crmFilesDirectory2.SubDetailId,
						LanguageID = crmFilesDirectory2.LanguageID,
						UserId = crmFilesDirectory2.UserId,
						AppType = crmFilesDirectory2.AppType,
						GUId = crmFilesDirectory2.GUId,
						RegisterDate = crmFilesDirectory2.RegisterDate,
						Month1 = crmFilesDirectory2.Month1,
						RegisterDatePersian = crmFilesDirectory2.RegisterDatePersian,
						Year1 = crmFilesDirectory2.Year1,
						FileDirectoryID = crmFilesDirectory2.FileDirectoryID,
						FileName = crmFilesDirectory2.FileName,
						DocDateTime = crmFilesDirectory2.DocDateTime,
						FilePath = crmFilesDirectory2.FilePath,
						TypeOprObjectId = crmFilesDirectory2.TypeOprObjectId,
						DocDate = crmFilesDirectory2.DocDate,
						DetailId = crmFilesDirectory2.DetailId,
						FileDirectoryTypeId = crmFilesDirectory2.FileDirectoryTypeId,
						FolderName = crmFilesDirectory2.FolderName,
						DocDay = crmFilesDirectory2.DocDay,
						CopyFromPath = crmFilesDirectory2.CopyFromPath,
						DocTime = crmFilesDirectory2.DocTime,
						Title = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
						Title_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
						Desc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
						Desc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
						FirstRegisterUserId = (crmFilesDirectory2.FirstRegisterUserId ?? UserLogin.CurrentUser.UserId),
						FirstRegisterDate = crmFilesDirectory2.FirstRegisterDate,
						AppTypeHelp = crmFilesDirectory2.AppType,
						MobHRMVisible = crmFilesDirectory2.MobHRMVisible
					};
				}
			}
			else
			{
				if (!UserLogin.IsUserAccess("frmDefineUsers", "actInsertFile"))
				{
					base.ViewBag.Error = Messages.NotAccessToPage;
					return null;
				}
				_ = DateTime.Now;
				crmFilesDirectoryLanguageViewModel = new CrmFilesDirectoryLanguageViewModel();
				DateTime now2 = DateTime.Now;
				crmFilesDirectoryLanguageViewModel.UserId = UserLogin.CurrentUser.UserId;
				crmFilesDirectoryLanguageViewModel.Year1 = short.Parse(Financial.Get().Id.ToString());
				crmFilesDirectoryLanguageViewModel.Month1 = short.Parse(now2.ToString("MM", new PersianCulture()));
				crmFilesDirectoryLanguageViewModel.RegisterDate = now2;
				crmFilesDirectoryLanguageViewModel.RegisterDatePersian = now2.ToString("yyyyMMdd");
				crmFilesDirectoryLanguageViewModel.DocDate = now2.ToString("yyyyMMdd");
				crmFilesDirectoryLanguageViewModel.DocTime = now2.ToString("HH:mm:ss");
				crmFilesDirectoryLanguageViewModel.DocDateTime = now2;
				crmFilesDirectoryLanguageViewModel.DocDay = DefineDayeOfWeek();
				crmFilesDirectoryLanguageViewModel.TypeOprObjectId = userId;
				crmFilesDirectoryLanguageViewModel.FileDirectoryTypeOprId = 80;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			base.ViewBag.Error = ex.Message;
			return null;
		}
		GetDayList();
		string firstRegInfo = "";
		string regInfo = "";
		SetRegisterInfoFile(crmFilesDirectoryLanguageViewModel, ref firstRegInfo, ref regInfo);
		base.ViewBag.FirstRegisterUser = firstRegInfo;
		base.ViewBag.EditUser = regInfo;
		base.ViewBag.IsBuying = VersionBuyer.AttachFiles;
		dynamic viewBag = base.ViewBag;
		DbSet<CrmFilesDirectory> crmFilesDirectory3 = _dbTbl.CrmFilesDirectory;
		val = Expression.Parameter(typeof(CrmFilesDirectory), "c");
		viewBag.CntFileId = Queryable.Any<CrmFilesDirectory>((IQueryable<CrmFilesDirectory>)crmFilesDirectory3, Expression.Lambda<Func<CrmFilesDirectory, bool>>((Expression)(object)Expression.GreaterThan((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)10, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
		dynamic viewBag2 = base.ViewBag;
		DbSet<CrmFilesDirectory> crmFilesDirectory4 = _dbTbl.CrmFilesDirectory;
		val = Expression.Parameter(typeof(CrmFilesDirectory), "c");
		viewBag2.CountFile = Queryable.Any<CrmFilesDirectory>((IQueryable<CrmFilesDirectory>)crmFilesDirectory4, Expression.Lambda<Func<CrmFilesDirectory, bool>>((Expression)(object)Expression.GreaterThan((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)10, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
		return View(crmFilesDirectoryLanguageViewModel);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	[DynamicAuthorize(ControllerName = "frmFileDataEntry", ActionName = "actPost")]
	public ActionResult FileInsertEdit(CrmFilesDirectoryLanguageViewModel model, HttpPostedFileBase[] FileUrlUpload)
	{
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_024f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0755: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass130_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass130_0();
		CS_0024_003C_003E8__locals0.model = model;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		string text2 = "";
		string text3 = "";
		int countError = 0;
		GetDayList();
		GetFileType(80);
		dynamic viewBag = base.ViewBag;
		DbSet<CrmFilesDirectory> crmFilesDirectory = _dbTbl.CrmFilesDirectory;
		ParameterExpression val = Expression.Parameter(typeof(CrmFilesDirectory), "c");
		viewBag.CntFileId = Queryable.Any<CrmFilesDirectory>((IQueryable<CrmFilesDirectory>)crmFilesDirectory, Expression.Lambda<Func<CrmFilesDirectory, bool>>((Expression)(object)Expression.GreaterThan((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)10, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
		try
		{
			int? num = null;
			if (UserLogin.CurrentUser != null)
			{
				num = UserLogin.CurrentUser.UserLastCId;
			}
			if (VersionBuyer.AttachFiles)
			{
				goto IL_01e2;
			}
			DbSet<CrmFilesDirectory> crmFilesDirectory2 = _dbTbl.CrmFilesDirectory;
			val = Expression.Parameter(typeof(CrmFilesDirectory), "c");
			if (!Queryable.Any<CrmFilesDirectory>((IQueryable<CrmFilesDirectory>)crmFilesDirectory2, Expression.Lambda<Func<CrmFilesDirectory, bool>>((Expression)(object)Expression.GreaterThan((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)10, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val })))
			{
				goto IL_01e2;
			}
			text = "BV|" + Messages.VersionBuy;
			goto end_IL_0142;
			IL_01e2:
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.Title_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.Title_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.model.Title,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.Desc_Lang))
			{
				list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.Desc_Lang);
			}
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.model.Desc,
				LanguageId = lCID
			});
			text = ChkBeforeSubmitFile(CS_0024_003C_003E8__locals0.model, list, list2, ref countError);
			DateTime dateTime = default(DateTime);
			string text4 = "";
			if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.DocTime))
			{
				CS_0024_003C_003E8__locals0.model.DocTime = DateTime.Now.ToString("HH:mm:ss");
			}
			try
			{
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.DocDate))
				{
					text4 = PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.model.DocDate.Replace("/", ""));
					switch (lCID)
					{
					case 1065:
						dateTime = DateTime.Parse(text4 + " " + CS_0024_003C_003E8__locals0.model.DocTime, new PersianCulture());
						CS_0024_003C_003E8__locals0.model.DocDate = dateTime.ToString("yyyyMMdd");
						break;
					case 1025:
						dateTime = DateTime.Parse(text4 + " " + CS_0024_003C_003E8__locals0.model.DocTime, new CultureInfo("ar-SA"));
						CS_0024_003C_003E8__locals0.model.DocDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					default:
						dateTime = DateTime.Parse(text4 + " " + CS_0024_003C_003E8__locals0.model.DocTime, new CultureInfo("en-US"));
						CS_0024_003C_003E8__locals0.model.DocDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					}
					CS_0024_003C_003E8__locals0.model.DocDateTime = dateTime;
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				text = Messages.msgErrorEnterCorrectDateFormat;
				countError++;
			}
			if (CS_0024_003C_003E8__locals0.model.DocDate != null)
			{
				CS_0024_003C_003E8__locals0.model.DocDate = CS_0024_003C_003E8__locals0.model.DocDate.Replace("/", "").Replace("-", "").Replace("_", "")
					.Replace(".", "")
					.Replace(",", "")
					.Replace("\\", "");
			}
			DateTime now;
			string text5;
			int userId;
			if (countError == 0)
			{
				if (!base.ModelState.IsValid)
				{
					base.ViewBag.Error = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
				}
				else
				{
					_003C_003Ec__DisplayClass130_1 _003C_003Ec__DisplayClass130_ = new _003C_003Ec__DisplayClass130_1();
					now = DateTime.Now;
					text5 = now.ToString("yyyyMMdd", new PersianCulture());
					short month = short.Parse(now.ToString("MM", new PersianCulture()));
					userId = UserLogin.CurrentUser.UserId;
					string appType = Configuration.AppType;
					short year = short.Parse(Financial.Get().Id.ToString());
					_003C_003Ec__DisplayClass130_.fileDir = new CrmFilesDirectory();
					if (CS_0024_003C_003E8__locals0.model.FileDirectoryID > 0)
					{
						DbSet<CrmFilesDirectory> crmFilesDirectory3 = _dbTbl.CrmFilesDirectory;
						val = Expression.Parameter(typeof(CrmFilesDirectory), "c");
						_003C_003Ec__DisplayClass130_.fileDir = Queryable.FirstOrDefault<CrmFilesDirectory>((IQueryable<CrmFilesDirectory>)crmFilesDirectory3, Expression.Lambda<Func<CrmFilesDirectory, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass130_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
					}
					_003C_003Ec__DisplayClass130_.fileDir.FileDirectoryTypeId = CS_0024_003C_003E8__locals0.model.FileDirectoryTypeId;
					_003C_003Ec__DisplayClass130_.fileDir.Title = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					_003C_003Ec__DisplayClass130_.fileDir.FileDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					_003C_003Ec__DisplayClass130_.fileDir.UserId = userId;
					_003C_003Ec__DisplayClass130_.fileDir.Year1 = year;
					_003C_003Ec__DisplayClass130_.fileDir.Month1 = month;
					_003C_003Ec__DisplayClass130_.fileDir.Month1 = month;
					_003C_003Ec__DisplayClass130_.fileDir.RegisterDate = now;
					_003C_003Ec__DisplayClass130_.fileDir.RegisterDatePersian = text5;
					_003C_003Ec__DisplayClass130_.fileDir.AppType = appType;
					_003C_003Ec__DisplayClass130_.fileDir.DocDate = CS_0024_003C_003E8__locals0.model.DocDate;
					_003C_003Ec__DisplayClass130_.fileDir.DocDay = CS_0024_003C_003E8__locals0.model.DocDay;
					_003C_003Ec__DisplayClass130_.fileDir.DocTime = CS_0024_003C_003E8__locals0.model.DocTime;
					_003C_003Ec__DisplayClass130_.fileDir.DocDateTime = CS_0024_003C_003E8__locals0.model.DocDateTime;
					_003C_003Ec__DisplayClass130_.fileDir.MobHRMVisible = CS_0024_003C_003E8__locals0.model.MobHRMVisible;
					if (CS_0024_003C_003E8__locals0.model.FileDirectoryID != 0)
					{
						_dbTbl.Entry(_003C_003Ec__DisplayClass130_.fileDir).State = EntityState.Modified;
						_dbTbl.Configuration.ValidateOnSaveEnabled = false;
						_dbTbl.SaveChanges();
						_dbTbl.Configuration.ValidateOnSaveEnabled = true;
						using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								_003C_003Ec__DisplayClass130_3 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass130_3();
								CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass130_;
								CS_0024_003C_003E8__locals2.lang = enumerator.Current;
								DbSet<CrmFilesDirectory_Lang> crmFilesDirectory_Lang = _dbTbl.CrmFilesDirectory_Lang;
								val = Expression.Parameter(typeof(CrmFilesDirectory_Lang), "c");
								CrmFilesDirectory_Lang crmFilesDirectory_Lang2 = Queryable.FirstOrDefault<CrmFilesDirectory_Lang>((IQueryable<CrmFilesDirectory_Lang>)crmFilesDirectory_Lang, Expression.Lambda<Func<CrmFilesDirectory_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals2, typeof(_003C_003Ec__DisplayClass130_3)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals2, typeof(_003C_003Ec__DisplayClass130_3)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
								if (crmFilesDirectory_Lang2 != null)
								{
									crmFilesDirectory_Lang2.Title = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
									crmFilesDirectory_Lang2.FileDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
									_dbTbl.Entry(crmFilesDirectory_Lang2).State = EntityState.Modified;
									_dbTbl.SaveChanges();
									continue;
								}
								crmFilesDirectory_Lang2 = new CrmFilesDirectory_Lang
								{
									Title = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null),
									FileDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null),
									LanguageID = CS_0024_003C_003E8__locals2.lang.LanguageID,
									FileDirectoryID = CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.fileDir.FileDirectoryID
								};
								_dbTbl.CrmFilesDirectory_Lang.Add(crmFilesDirectory_Lang2);
								_dbTbl.SaveChanges();
							}
						}
						base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
						goto IL_175f;
					}
					List<CrmFilesDirectoryTemplate> list3 = new List<CrmFilesDirectoryTemplate>();
					if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.model.FilesPath))
					{
						list3 = new JavaScriptSerializer().Deserialize<List<CrmFilesDirectoryTemplate>>(CS_0024_003C_003E8__locals0.model.FilesPath);
						if (list3.Count > 0)
						{
							list3 = Enumerable.ToList<CrmFilesDirectoryTemplate>(Enumerable.Where<CrmFilesDirectoryTemplate>((IEnumerable<CrmFilesDirectoryTemplate>)list3, (Func<CrmFilesDirectoryTemplate, bool>)((CrmFilesDirectoryTemplate x) => x.FileDirectoryTemplateID > 0)));
						}
					}
					if (list3 == null || Enumerable.Count<CrmFilesDirectoryTemplate>((IEnumerable<CrmFilesDirectoryTemplate>)list3) <= 0)
					{
						text = Messages.msgErrorNoFileInNotSelect;
					}
					else
					{
						bool flag = false;
						int maxFileCount = Configuration.MaxFileCount;
						if (Enumerable.Count<CrmFilesDirectoryTemplate>((IEnumerable<CrmFilesDirectoryTemplate>)list3) > maxFileCount)
						{
							string msgErrorMessageMaxSizeFile = Messages.msgErrorMessageMaxSizeFile;
							base.ModelState.AddModelError("error", string.Format(msgErrorMessageMaxSizeFile, maxFileCount));
							flag = true;
							text = string.Format(msgErrorMessageMaxSizeFile, maxFileCount) + "<br>";
						}
						foreach (CrmFilesDirectoryTemplate item3 in list3)
						{
							if (string.IsNullOrEmpty(item3.CopyFromPath))
							{
								continue;
							}
							string value = "";
							string text6 = ((item3.Title != null) ? Path.GetExtension(item3.Title).ToLower() : "");
							RegistryKey val2 = Registry.ClassesRoot.OpenSubKey(text6);
							if (val2 != null && val2.GetValue("Content Type") != null)
							{
								value = val2.GetValue("Content Type").ToString();
							}
							if (string.IsNullOrWhiteSpace(value))
							{
								value = Files.GetMimeType(text6);
							}
							string arg = item3.Title ?? "";
							if (!System.IO.File.Exists(item3.CopyFromPath))
							{
								string msgErrorFileDoesNotExist = Messages.msgErrorFileDoesNotExist;
								base.ModelState.AddModelError("error", string.Format(msgErrorFileDoesNotExist, arg));
								flag = true;
								text = text + string.Format(msgErrorFileDoesNotExist, arg) + "<br>";
								continue;
							}
							string text7 = (text6 ?? "").ToLower();
							text7 = text7.Replace(".", "");
							if (Configuration.MaliciousFileExtensions.Contains(text7))
							{
								base.ModelState.AddModelError("error", Messages.msgErrorFileIsExecuted);
								flag = true;
								text = text + string.Format(Messages.msgErrorNotUploadFileByDue, arg) + Messages.msgErrorFileIsExecuted + "<br>";
							}
							int num2 = Configuration.MaxFileSizeForUploadMb * 1024 * 1024;
							long length = new FileInfo(item3.CopyFromPath).Length;
							if (length > num2)
							{
								string fileFormatByteSize = CRM.General.IO.File.GetFileFormatByteSize(length);
								string fileFormatByteSize2 = CRM.General.IO.File.GetFileFormatByteSize(num2);
								string msgErrorMessageMaxSizeFile2 = Messages.msgErrorMessageMaxSizeFile;
								base.ModelState.AddModelError("error", string.Format(msgErrorMessageMaxSizeFile2, fileFormatByteSize, fileFormatByteSize2));
								flag = true;
								text = text + string.Format(Messages.msgErrorNotUploadFileByDue, arg) + string.Format(msgErrorMessageMaxSizeFile2, fileFormatByteSize, fileFormatByteSize2) + "<br>";
							}
						}
						if (!flag)
						{
							CRMspSelectUsersById_Result cRMspSelectUsersById_Result = CRMIdeal.Classes.Helper.User.SelectUsersById(CS_0024_003C_003E8__locals0.model.TypeOprObjectId.GetValueOrDefault());
							if (cRMspSelectUsersById_Result != null)
							{
								int? fileCId = null;
								if (num.GetValueOrDefault() != 0)
								{
									fileCId = num;
								}
								if (list3 != null)
								{
									FacadeFTP facadeFTP = new FacadeFTP(Configuration.FacadeFtp);
									string pathFtp = Configuration.PathFtp;
									string userNameFtp = Configuration.UserNameFtp;
									string passwordFtp = Configuration.PasswordFtp;
									bool usePassiveFtp = Configuration.UsePassiveFtp;
									bool flag2 = true;
									foreach (CrmFilesDirectoryTemplate item4 in list3)
									{
										string text8 = "";
										string title = item4.Title;
										string text9 = cRMspSelectUsersById_Result.UserId.ToString();
										string text10 = Configuration.UserDirectoryPath + text9;
										List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
										bool result = false;
										bool.TryParse(CS_0024_003C_003E8__locals0.model.IsUseSameTitle.ToString(), out result);
										if (list3 != null && !result && list3.Count > 1)
										{
											string title2 = item4.Title;
											if (!string.IsNullOrWhiteSpace(title2) && list != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list))
											{
												foreach (CommonMultiLanguageViewModel item5 in list)
												{
													CommonMultiLanguageViewModel item = new CommonMultiLanguageViewModel
													{
														LanguageId = item5.LanguageId,
														Value = title2
													};
													list4.Add(item);
												}
											}
										}
										if ((list4 == null || !Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4)) && list != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list))
										{
											foreach (CommonMultiLanguageViewModel item6 in list)
											{
												CommonMultiLanguageViewModel item2 = new CommonMultiLanguageViewModel
												{
													LanguageId = item6.LanguageId,
													Value = item6.Value
												};
												list4.Add(item2);
											}
										}
										_003C_003Ec__DisplayClass130_.fileDir = new CrmFilesDirectory();
										_003C_003Ec__DisplayClass130_.fileDir.FileDirectoryTypeId = CS_0024_003C_003E8__locals0.model.FileDirectoryTypeId;
										_003C_003Ec__DisplayClass130_.fileDir.Title = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
										_003C_003Ec__DisplayClass130_.fileDir.UserId = userId;
										_003C_003Ec__DisplayClass130_.fileDir.Year1 = year;
										_003C_003Ec__DisplayClass130_.fileDir.Month1 = month;
										_003C_003Ec__DisplayClass130_.fileDir.Month1 = month;
										_003C_003Ec__DisplayClass130_.fileDir.RegisterDate = now;
										_003C_003Ec__DisplayClass130_.fileDir.RegisterDatePersian = text5;
										_003C_003Ec__DisplayClass130_.fileDir.AppType = appType;
										_003C_003Ec__DisplayClass130_.fileDir.DocDate = CS_0024_003C_003E8__locals0.model.DocDate;
										_003C_003Ec__DisplayClass130_.fileDir.DocDay = CS_0024_003C_003E8__locals0.model.DocDay;
										_003C_003Ec__DisplayClass130_.fileDir.DocTime = CS_0024_003C_003E8__locals0.model.DocTime;
										_003C_003Ec__DisplayClass130_.fileDir.DocDateTime = CS_0024_003C_003E8__locals0.model.DocDateTime;
										_003C_003Ec__DisplayClass130_.fileDir.TypeOprObjectId = CS_0024_003C_003E8__locals0.model.TypeOprObjectId;
										_003C_003Ec__DisplayClass130_.fileDir.FolderName = text9;
										_003C_003Ec__DisplayClass130_.fileDir.FileName = title;
										_003C_003Ec__DisplayClass130_.fileDir.GUId = System.Guid.NewGuid();
										_003C_003Ec__DisplayClass130_.fileDir.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
										_003C_003Ec__DisplayClass130_.fileDir.FirstRegisterUserId = userId;
										_003C_003Ec__DisplayClass130_.fileDir.FirstRegisterDatePersian = text5;
										_003C_003Ec__DisplayClass130_.fileDir.FirstRegisterDate = now;
										_003C_003Ec__DisplayClass130_.fileDir.MobHRMVisible = CS_0024_003C_003E8__locals0.model.MobHRMVisible;
										_003C_003Ec__DisplayClass130_.fileDir.FileCId = fileCId;
										_003C_003Ec__DisplayClass130_.fileDir.FileDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
										_dbTbl.CrmFilesDirectory.Add(_003C_003Ec__DisplayClass130_.fileDir);
										_dbTbl.SaveChanges();
										string[] array = title.Split(new char[1] { '.' });
										text8 = Configuration.MainDirectoryPath + text10 + "/";
										string text11 = text8 + (text8.EndsWith("/") ? "" : "/");
										string text12 = text11.Split(new char[1] { '/' })[^2];
										string text13 = text11.Replace(text12 + "/", "");
										bool flag3 = facadeFTP.ExistsDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, Configuration.MainDirectoryPath, Configuration.UserDirectoryPath, usePassiveFtp);
										if (!flag3)
										{
											flag3 = facadeFTP.CreateDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, Configuration.MainDirectoryPath, Configuration.UserDirectoryPath, usePassiveFtp);
										}
										bool flag4 = facadeFTP.ExistsDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, text13, text12, usePassiveFtp);
										if (!flag4)
										{
											flag4 = facadeFTP.CreateDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, text13, text12, usePassiveFtp);
										}
										if (flag4 && flag3)
										{
											string text14 = "";
											text14 = _003C_003Ec__DisplayClass130_.fileDir.TypeOprObjectId + "-" + _003C_003Ec__DisplayClass130_.fileDir.FileDirectoryID + "." + array[^1];
											string text15 = "";
											if (facadeFTP.UploadFtpFormTable(pathFtp, userNameFtp, passwordFtp, text11 + text14, item4.CopyFromPath, usePassiveFtp))
											{
												text8 = pathFtp + text11 + text14;
												text15 = text14;
												text8 = text8.Trim().Replace(pathFtp, "");
												_003C_003Ec__DisplayClass130_.fileDir.FilePath = text8;
												_003C_003Ec__DisplayClass130_.fileDir.FileName = text15;
												_003C_003Ec__DisplayClass130_.fileDir.UserId = userId;
												_003C_003Ec__DisplayClass130_.fileDir.Year1 = year;
												_003C_003Ec__DisplayClass130_.fileDir.Month1 = month;
												_003C_003Ec__DisplayClass130_.fileDir.RegisterDate = now;
												_003C_003Ec__DisplayClass130_.fileDir.RegisterDatePersian = text5;
												_dbTbl.Entry(_003C_003Ec__DisplayClass130_.fileDir).State = EntityState.Modified;
												_dbTbl.SaveChanges();
												foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
												{
													CrmFilesDirectory_Lang crmFilesDirectory_Lang3 = new CrmFilesDirectory_Lang();
													crmFilesDirectory_Lang3.LanguageID = lang.LanguageID;
													crmFilesDirectory_Lang3.FileDirectoryID = _003C_003Ec__DisplayClass130_.fileDir.FileDirectoryID;
													crmFilesDirectory_Lang3.Title = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
													crmFilesDirectory_Lang3.FileDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
													_dbTbl.CrmFilesDirectory_Lang.Add(crmFilesDirectory_Lang3);
													_dbTbl.SaveChanges();
												}
												try
												{
													if (System.IO.File.Exists(item4.CopyFromPath))
													{
														System.IO.File.Delete(item4.CopyFromPath);
													}
												}
												catch (Exception e2)
												{
													ErrorSignal.FromCurrentContext().Raise(e2);
												}
												continue;
											}
											flag2 = false;
											Exception e3 = new Exception(Messages.msgErrorUploadingFileInFtp + "  -  hostname: " + Configuration.PathFtp + " ,username: " + Configuration.UserNameFtp + " ,destination: " + text13 + " ,directoryName: " + text12);
											ErrorSignal.FromCurrentContext().Raise(e3);
											base.ModelState.AddModelError("error", Messages.frmErrorInSendingFile);
											text = Messages.frmErrorInSendingFile;
											try
											{
												db.CRMspDeleteCrmFilesDirectory(_003C_003Ec__DisplayClass130_.fileDir.FileDirectoryID);
											}
											catch (Exception e4)
											{
												ErrorSignal.FromCurrentContext().Raise(e4);
											}
										}
										else
										{
											flag2 = false;
											Exception e5 = new Exception(Messages.msgErrorCreateFolderInFtp + " -  hostname: " + Configuration.PathFtp + " ,username: " + Configuration.UserNameFtp + " ,destination: " + text13 + " ,directoryName: " + text12);
											ErrorSignal.FromCurrentContext().Raise(e5);
											base.ModelState.AddModelError("error", Messages.frmErrorInSendingFile);
											text = Messages.frmErrorInSendingFile;
											try
											{
												db.CRMspDeleteCrmFilesDirectory(_003C_003Ec__DisplayClass130_.fileDir.FileDirectoryID);
											}
											catch (Exception e6)
											{
												ErrorSignal.FromCurrentContext().Raise(e6);
											}
										}
										goto end_IL_0142;
									}
									if (flag2)
									{
										base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
									}
								}
								goto IL_175f;
							}
							text = Messages.ErrorNotFound;
						}
					}
				}
			}
			goto end_IL_0142;
			IL_175f:
			CS_0024_003C_003E8__locals0.model.UserId = userId;
			CS_0024_003C_003E8__locals0.model.RegisterDate = now;
			CS_0024_003C_003E8__locals0.model.RegisterDatePersian = text5;
			end_IL_0142:;
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
		text2 = "";
		text3 = "";
		SetRegisterInfoFile(CS_0024_003C_003E8__locals0.model, ref text2, ref text3);
		base.ViewBag.FirstRegisterUser = text2;
		base.ViewBag.EditUser = text3;
		return View(CS_0024_003C_003E8__locals0.model);
	}

	[AjaxOnly]
	public JsonResult GetFileType(int? id = null)
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
			foreach (CRMspSelectFileDirectoryTypeByOprId_Result item in id.HasValue ? Enumerable.ToList<CRMspSelectFileDirectoryTypeByOprId_Result>((IEnumerable<CRMspSelectFileDirectoryTypeByOprId_Result>)db.CRMspSelectFileDirectoryTypeByOprId(id, lCID, result)) : Enumerable.ToList<CRMspSelectFileDirectoryTypeByOprId_Result>((IEnumerable<CRMspSelectFileDirectoryTypeByOprId_Result>)Enumerable.OrderBy<CRMspSelectFileDirectoryTypeByOprId_Result, string>((IEnumerable<CRMspSelectFileDirectoryTypeByOprId_Result>)Enumerable.ToList<CRMspSelectFileDirectoryTypeByOprId_Result>((IEnumerable<CRMspSelectFileDirectoryTypeByOprId_Result>)db.CRMspSelectFileDirectoryType(lCID, result)), (Func<CRMspSelectFileDirectoryTypeByOprId_Result, string>)((CRMspSelectFileDirectoryTypeByOprId_Result c) => c.FileDirectoryType))))
			{
				list.Add(new SelectListItem
				{
					Text = item.FileDirectoryType,
					Value = item.FileDirectoryTypeID.ToString()
				});
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.Typelist = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public string DefineDayeOfWeek()
	{
		return DateTime.Now.DayOfWeek.ToString() switch
		{
			"Saturday" => "7", 
			"Sunday" => "1", 
			"Monday" => "2", 
			"Tuesday" => "3", 
			"Wednesday" => "4", 
			"Thursday" => "5", 
			"Friday" => "6", 
			_ => null, 
		};
	}

	public void GetDayList()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		list.Add(new SelectListItem
		{
			Text = Labels.Saturday,
			Value = "7",
			Selected = false
		});
		list.Add(new SelectListItem
		{
			Text = Labels.Sunday,
			Value = "1",
			Selected = false
		});
		list.Add(new SelectListItem
		{
			Text = Labels.Monday,
			Value = "2",
			Selected = false
		});
		list.Add(new SelectListItem
		{
			Text = Labels.Tuesday,
			Value = "3",
			Selected = false
		});
		list.Add(new SelectListItem
		{
			Text = Labels.Wednesday,
			Value = "4",
			Selected = false
		});
		list.Add(new SelectListItem
		{
			Text = Labels.Thursday,
			Value = "5",
			Selected = false
		});
		list.Add(new SelectListItem
		{
			Text = Labels.Friday,
			Value = "6",
			Selected = false
		});
		base.ViewBag.Dayslist = list;
	}

	public string ChkBeforeSubmitFile(CrmFilesDirectoryLanguageViewModel fileDir, List<CommonMultiLanguageViewModel> listModelObj_Title_Lang, List<CommonMultiLanguageViewModel> listModelObj_Desc_Lang, ref int countError)
	{
		string text = "";
		if (string.IsNullOrEmpty(fileDir.DocDate))
		{
			text += Messages.CheckFileEmptyDocDate;
			countError++;
		}
		if (string.IsNullOrEmpty(fileDir.DocDay))
		{
			text += Messages.CheckFileEmptyDocDay;
			countError++;
		}
		if (string.IsNullOrEmpty(fileDir.DocTime))
		{
			text += Messages.CheckFileEmptyDocTime;
			countError++;
		}
		if (fileDir.Title == null && fileDir.Title == "")
		{
			text = text + Messages.CheckTitle + "<br/>";
			countError++;
		}
		else if (!checkMultiLanguage(fileDir.Title, listModelObj_Title_Lang))
		{
			text = text + Messages.CheckTitleLang + "<br>";
			countError++;
		}
		if (!string.IsNullOrEmpty(fileDir.Desc) && !checkMultiLanguage(fileDir.Desc, listModelObj_Desc_Lang))
		{
			text = text + Messages.CheckTitleLang + "<br>";
			countError++;
		}
		if (!fileDir.FileDirectoryTypeId.HasValue || fileDir.FileDirectoryTypeId == 0)
		{
			text += Messages.CheckFileEmptyFileDirectoryTypeId;
			countError++;
		}
		return text;
	}

	public ActionResult UserPictureChange()
	{
		UserPicturesViewModel userPicturesViewModel = new UserPicturesViewModel();
		try
		{
			DateTime now = DateTime.Now;
			int userId = UserLogin.CurrentUser.UserId;
			CRMspSelectUserPicturesByUserId_Result cRMspSelectUserPicturesByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserPicturesByUserId_Result>((IEnumerable<CRMspSelectUserPicturesByUserId_Result>)db.CRMspSelectUserPicturesByUserId(userId));
			if (cRMspSelectUserPicturesByUserId_Result != null)
			{
				userPicturesViewModel.UserPictureId = cRMspSelectUserPicturesByUserId_Result.UserPictureId;
				userPicturesViewModel.UserId = cRMspSelectUserPicturesByUserId_Result.UserId;
				userPicturesViewModel.FirstRegisterUserId = cRMspSelectUserPicturesByUserId_Result.FirstRegisterUserId;
				userPicturesViewModel.RegisterDate = cRMspSelectUserPicturesByUserId_Result.RegisterDate;
				userPicturesViewModel.FirstRegisterDate = cRMspSelectUserPicturesByUserId_Result.FirstRegisterDate;
				userPicturesViewModel.FirstRegisterDatePersian = cRMspSelectUserPicturesByUserId_Result.FirstRegisterDatePersian;
				userPicturesViewModel.RegisterDatePersian = cRMspSelectUserPicturesByUserId_Result.RegisterDatePersian;
				userPicturesViewModel.AppType = cRMspSelectUserPicturesByUserId_Result.AppType;
				userPicturesViewModel.CrmUserId = cRMspSelectUserPicturesByUserId_Result.CrmUserId;
			}
			else
			{
				userPicturesViewModel.UserId = UserLogin.CurrentUser.UserId;
				userPicturesViewModel.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
				userPicturesViewModel.RegisterDate = now;
				userPicturesViewModel.FirstRegisterDate = now;
				userPicturesViewModel.AppType = "new";
				userPicturesViewModel.CrmUserId = userId;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			base.ViewBag.Error = Messages.msgErrorRunFunction;
		}
		return View(userPicturesViewModel);
	}

	public ActionResult ActAttachFile(HttpPostedFileBase UserPictureUrlUpload)
	{
		string text = "";
		bool flag = false;
		try
		{
			_003C_003Ec__DisplayClass136_0 _003C_003Ec__DisplayClass136_ = new _003C_003Ec__DisplayClass136_0();
			if (UserPictureUrlUpload != null)
			{
				string text2 = UserPictureUrlUpload.ContentType.ToLower();
				string text3 = Path.GetExtension(UserPictureUrlUpload.FileName).ToLower();
				if ((text2 != "image/jpg" && text2 != "image/jpeg" && text2 != "image/pjpeg" && text2 != "image/gif" && text2 != "image/x-png" && text2 != "image/png") || (text3 != ".jpg" && text3 != ".png" && text3 != ".gif" && text3 != ".jpeg"))
				{
					text = text + Messages.frmErrorNotImageFile + "<br>";
					flag = true;
				}
				if (UserPictureUrlUpload.ContentLength / 1024 > Configuration.MaxImageSizeForUploadKb)
				{
					text = text + string.Format(Messages.frmErrorMaxImageSizeForUpload, Configuration.MaxImageSizeForUploadKb) + "<br>";
					flag = true;
				}
			}
			else
			{
				text = text + Messages.frmErrorNotFileSelected + "<br>";
				flag = true;
			}
			if (flag)
			{
				return Content(text);
			}
			DateTime now = DateTime.Now;
			DateTime dateTime = now;
			string text4 = now.ToString("yyyyMMdd", new PersianCulture());
			short month = short.Parse(now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			short year = short.Parse(Financial.Get().Id.ToString());
			_003C_003Ec__DisplayClass136_.userId = UserLogin.CurrentUser.UserId;
			DbSet<UserPictures> userPictures = _dbTbl.UserPictures;
			ParameterExpression val = Expression.Parameter(typeof(UserPictures), "c");
			UserPictures userPictures2 = Queryable.FirstOrDefault<UserPictures>((IQueryable<UserPictures>)userPictures, Expression.Lambda<Func<UserPictures, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass136_, typeof(_003C_003Ec__DisplayClass136_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			bool flag2 = false;
			if (userPictures2 == null)
			{
				userPictures2 = new UserPictures();
				flag2 = true;
				userPictures2.GUId = System.Guid.NewGuid();
			}
			userPictures2.CrmUserId = _003C_003Ec__DisplayClass136_.userId;
			userPictures2.RegisterDate = dateTime;
			userPictures2.RegisterDatePersian = text4;
			userPictures2.UserId = _003C_003Ec__DisplayClass136_.userId;
			userPictures2.Year1 = year;
			userPictures2.Month1 = month;
			_ = string.Empty;
			_ = string.Empty;
			if (UserPictureUrlUpload != null)
			{
				userPictures2.UserPicture = ImageManager.CompressHttpPostedFileBase(new ImageManager.ImageParam
				{
					HttpPostedFileBase_Var = UserPictureUrlUpload
				});
			}
			else
			{
				userPictures2.UserPicture = null;
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			userPictures2.AppType = Configuration.AppType;
			if (flag2)
			{
				userPictures2.FirstRegisterUserId = _003C_003Ec__DisplayClass136_.userId;
				userPictures2.FirstRegisterDate = dateTime;
				userPictures2.FirstRegisterDatePersian = text4;
				userPictures2.LanguageID = result;
				_dbTbl.UserPictures.Add(userPictures2);
			}
			else
			{
				_dbTbl.Entry(userPictures2).State = EntityState.Modified;
			}
			_dbTbl.SaveChanges();
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("UserPictures", _003C_003Ec__DisplayClass136_.userId);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			text += Messages.msgErrorOperationFailed;
		}
		return Content(text);
	}

	[HttpPost]
	[LoginAuthorize]
	public string UpdateUserLastCId(int cId)
	{
		string text = "";
		try
		{
			CRMIdeal.Classes.Helper.User.UpdateUserLastCId(UserLogin.CurrentUser.UserId, cId);
			bool? fromLoginPage = true;
			Info.Update(null, fromLoginPage);
			Permissions.Update();
			Alarms.Update();
			CRMIdeal.Cache.User.Language.Update();
			Manager.UpdateAllSettingCach();
		}
		catch (Exception ex)
		{
			text = text + "Error: " + ex.Message;
		}
		return text;
	}

	[HttpGet]
	[AjaxOnly]
	public JsonResult GetEmailUserInfoPasswordWithInput(int emailUsersInfoId, string inputPassword, int mode)
	{
		_003C_003Ec__DisplayClass138_0 _003C_003Ec__DisplayClass138_ = new _003C_003Ec__DisplayClass138_0();
		_003C_003Ec__DisplayClass138_.emailUsersInfoId = emailUsersInfoId;
		if (!UserLogin.IsUserAccess("frmDefineCompany", "actShowCmpPassword"))
		{
			return Json(new
			{
				message = Messages.ErrorNotAccess,
				data = string.Empty
			}, JsonRequestBehavior.AllowGet);
		}
		DbSet<EmailUsersInfo> emailUsersInfo = _dbTbl.EmailUsersInfo;
		ParameterExpression val = Expression.Parameter(typeof(EmailUsersInfo), "c");
		EmailUsersInfo emailUsersInfo2 = Queryable.FirstOrDefault<EmailUsersInfo>((IQueryable<EmailUsersInfo>)emailUsersInfo, Expression.Lambda<Func<EmailUsersInfo, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass138_, typeof(_003C_003Ec__DisplayClass138_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
		if (emailUsersInfo2 == null || string.IsNullOrEmpty(emailUsersInfo2.euPassword))
		{
			return Json(new
			{
				data = string.Empty
			}, JsonRequestBehavior.AllowGet);
		}
		string obj = ((!string.IsNullOrEmpty(inputPassword)) ? XorCipher.EncryptByPrivateKey(inputPassword) : null);
		string text = ((!string.IsNullOrEmpty(emailUsersInfo2.euPassword)) ? XorCipher.DecryptByPrivateKey(emailUsersInfo2.euPassword) : null);
		bool num = obj == emailUsersInfo2.euPassword;
		bool flag = inputPassword == emailUsersInfo2.euPassword;
		if (!num && !flag)
		{
			return Json(new
			{
				data = inputPassword
			}, JsonRequestBehavior.AllowGet);
		}
		return Json(new
		{
			data = ((mode == 1) ? text : emailUsersInfo2.euPassword)
		}, JsonRequestBehavior.AllowGet);
	}

	[HttpGet]
	[AjaxOnly]
	public JsonResult GetEmailUserInfoPassword(int emailUsersInfoId, int mode)
	{
		_003C_003Ec__DisplayClass139_0 _003C_003Ec__DisplayClass139_ = new _003C_003Ec__DisplayClass139_0();
		_003C_003Ec__DisplayClass139_.emailUsersInfoId = emailUsersInfoId;
		if (!UserLogin.IsUserAccess("frmCompanyFoLoginInfo", "actShowCmpPassword"))
		{
			return Json(new
			{
				message = Messages.ErrorNotAccess,
				data = string.Empty
			}, JsonRequestBehavior.AllowGet);
		}
		DbSet<EmailUsersInfo> emailUsersInfo = _dbTbl.EmailUsersInfo;
		ParameterExpression val = Expression.Parameter(typeof(EmailUsersInfo), "c");
		EmailUsersInfo emailUsersInfo2 = Queryable.FirstOrDefault<EmailUsersInfo>((IQueryable<EmailUsersInfo>)emailUsersInfo, Expression.Lambda<Func<EmailUsersInfo, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass139_, typeof(_003C_003Ec__DisplayClass139_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
		if (emailUsersInfo2 == null || string.IsNullOrEmpty(emailUsersInfo2.euPassword))
		{
			return Json(new
			{
				data = string.Empty
			}, JsonRequestBehavior.AllowGet);
		}
		return Json(new
		{
			data = ((mode == 1) ? XorCipher.DecryptByPrivateKey(emailUsersInfo2.euPassword) : emailUsersInfo2.euPassword)
		}, JsonRequestBehavior.AllowGet);
	}

	protected override void Dispose(bool disposing)
	{
		db.Dispose();
		_dbTbl.Dispose();
		dbI.Dispose();
		_dbII.Dispose();
		base.Dispose(disposing);
	}

	[DynamicAuthorize(ControllerName = "frmDefineUsers", ActionName = "actAllowAccessLanguage")]
	public ActionResult UserLanguage(int uId)
	{
		base.ViewBag.UserId = uId;
		GetLanguageList(uId);
		return View();
	}

	[AjaxOnly]
	public JsonResult GetLanguageList(int uId)
	{
		List<UserLanguageViewModel> list = new List<UserLanguageViewModel>();
		try
		{
			DbSet<Languages> languages = _dbTbl.Languages;
			ParameterExpression val = Expression.Parameter(typeof(Languages), "c");
			IQueryable<Languages> obj = Queryable.Where<Languages>((IQueryable<Languages>)languages, Expression.Lambda<Func<Languages, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Convert((Expression)(object)Expression.Constant((object)true, typeof(bool)), typeof(bool?))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			val = Expression.Parameter(typeof(Languages), "model");
			foreach (Languages lang in Enumerable.ToList<Languages>((IEnumerable<Languages>)Queryable.OrderBy<Languages, int?>(obj, Expression.Lambda<Func<Languages, int?>>((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (ParameterExpression[])(object)new ParameterExpression[1] { val }))))
			{
				UserLanguageViewModel userLanguageViewModel = new UserLanguageViewModel();
				UserLanguages userLanguages = Enumerable.FirstOrDefault<UserLanguages>((IEnumerable<UserLanguages>)Enumerable.ToList<UserLanguages>(Enumerable.Where<UserLanguages>((IEnumerable<UserLanguages>)Enumerable.ToList<UserLanguages>((IEnumerable<UserLanguages>)_dbTbl.UserLanguages), (Func<UserLanguages, bool>)((UserLanguages model) => model.IsActive && model.UserId == uId))), (Func<UserLanguages, bool>)((UserLanguages model) => model.LanguageID == lang.LanguageID));
				if (userLanguages != null)
				{
					userLanguageViewModel.Title = lang.LanguageName;
					userLanguageViewModel.Ischeck = true;
					userLanguageViewModel.Id = lang.LanguageID;
					userLanguageViewModel.Direction = userLanguages.LanguageDirection;
					userLanguageViewModel.UserLangId = userLanguages.UserLanguageID;
				}
				else
				{
					userLanguageViewModel.Title = lang.LanguageName;
					userLanguageViewModel.Ischeck = false;
					userLanguageViewModel.Id = lang.LanguageID;
					userLanguageViewModel.Direction = lang.LanguageDirection.ToUpper();
					userLanguageViewModel.UserLangId = 0;
				}
				list.Add(userLanguageViewModel);
			}
			base.ViewBag.LangList = list;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public string UpdateUserLanguage(int mode, int lId, string direct, int userId, int uLangId)
	{
		string text = "";
		try
		{
			if (lId > 0 && userId > 0)
			{
				int userId2 = UserLogin.CurrentUser.UserId;
				short year = short.Parse(Financial.Get().Id.ToString());
				short month = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
				DateTime now = DateTime.Now;
				string text2 = now.ToString("yyyyMMdd", new PersianCulture());
				string appType = Configuration.AppType;
				if (mode == 1)
				{
					UserLanguages userLanguages = new UserLanguages();
					userLanguages.UserId = userId;
					userLanguages.LanguageID = lId;
					userLanguages.LanguageDirection = direct.ToLower();
					userLanguages.IsActive = true;
					userLanguages.GUId = System.Guid.NewGuid();
					userLanguages.AppType = appType;
					userLanguages.UserId1 = userId2;
					userLanguages.Year1 = year;
					userLanguages.Month1 = month;
					userLanguages.RegisterDate = now;
					userLanguages.RegisterDatePersian = text2;
					userLanguages.FirstRegisterUserId = userId2;
					userLanguages.FirstRegisterDate = now;
					userLanguages.FirstRegisterDatePersian = text2;
					_dbTbl.UserLanguages.Add(userLanguages);
					_dbTbl.SaveChanges();
					CRMIdeal.Cache.User.Language.Update(userId);
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("UserLanguages", userId);
					return "1|" + Messages.msgSuccessAction;
				}
				if (uLangId > 0)
				{
					UserLanguages userLanguages2 = _dbTbl.UserLanguages.Find(uLangId);
					if (userLanguages2 != null)
					{
						_dbTbl.UserLanguages.Remove(userLanguages2);
						_dbTbl.SaveChanges();
						CRMIdeal.Cache.User.Language.Update(userId);
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("UserLanguages", userId);
						return "1|" + Messages.msgSuccessAction;
					}
					return "-1|" + Messages.ErrorNotFound;
				}
				return "-1|" + Messages.ErrorNotFound;
			}
			return "-1|" + Messages.ErrorNotFound;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return "-1|" + Messages.msgErrorRunFunction;
		}
	}

	public JsonResult GetUserEmailInfo(int userCurrentId, int mode, string textSearch = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CurrentEmailUserInfoViewModel currentEmailUserInfoViewModel = new CurrentEmailUserInfoViewModel();
		if (userCurrentId == 0)
		{
			userCurrentId = UserLogin.CurrentUser.UserId;
		}
		try
		{
			int? userLastCId = UserLogin.CurrentUser.UserLastCId;
			List<CRMspSelectUsersInMode_Result> list = Enumerable.ToList<CRMspSelectUsersInMode_Result>(Enumerable.Where<CRMspSelectUsersInMode_Result>((IEnumerable<CRMspSelectUsersInMode_Result>)dbI.CRMspSelectUsersInMode(mode, textSearch, lCID, result, userLastCId, UserLogin.CurrentUser.UserCIds), (Func<CRMspSelectUsersInMode_Result, bool>)((CRMspSelectUsersInMode_Result m) => m.UserId > 0)));
			if (Enumerable.Any<CRMspSelectUsersInMode_Result>((IEnumerable<CRMspSelectUsersInMode_Result>)list))
			{
				currentEmailUserInfoViewModel.IsFind = true;
				currentEmailUserInfoViewModel.Message = "";
				currentEmailUserInfoViewModel.UserNextId = -1;
				currentEmailUserInfoViewModel.UserPreviousId = -1;
				currentEmailUserInfoViewModel.UserFirstId = -1;
				currentEmailUserInfoViewModel.UserLastId = -1;
				if (list.Count == 1)
				{
					currentEmailUserInfoViewModel.UserFirstId = -1;
					currentEmailUserInfoViewModel.UserLastId = -1;
				}
				else
				{
					currentEmailUserInfoViewModel.UserFirstId = Enumerable.FirstOrDefault<CRMspSelectUsersInMode_Result>((IEnumerable<CRMspSelectUsersInMode_Result>)list).UserId;
					currentEmailUserInfoViewModel.UserLastId = Enumerable.LastOrDefault<CRMspSelectUsersInMode_Result>((IEnumerable<CRMspSelectUsersInMode_Result>)list).UserId;
				}
				CRMspSelectUsersInMode_Result cRMspSelectUsersInMode_Result = new CRMspSelectUsersInMode_Result();
				if (userCurrentId > 0)
				{
					cRMspSelectUsersInMode_Result = list.Find((CRMspSelectUsersInMode_Result c) => c.UserId == userCurrentId);
				}
				else
				{
					cRMspSelectUsersInMode_Result = Enumerable.LastOrDefault<CRMspSelectUsersInMode_Result>((IEnumerable<CRMspSelectUsersInMode_Result>)list);
				}
				cRMspSelectUsersInMode_Result = ((userCurrentId <= 0) ? Enumerable.LastOrDefault<CRMspSelectUsersInMode_Result>((IEnumerable<CRMspSelectUsersInMode_Result>)list) : list.Find((CRMspSelectUsersInMode_Result c) => c.UserId == userCurrentId));
				if (cRMspSelectUsersInMode_Result != null)
				{
					currentEmailUserInfoViewModel.CurrUser = cRMspSelectUsersInMode_Result;
					currentEmailUserInfoViewModel.UserCurrentId = cRMspSelectUsersInMode_Result.UserId;
					if (list.Count == 1)
					{
						currentEmailUserInfoViewModel.UserNextId = -1;
						currentEmailUserInfoViewModel.UserPreviousId = -1;
					}
					else
					{
						CRMspSelectUsersInMode_Result next = Lists.GetNext(list, cRMspSelectUsersInMode_Result);
						if (next != null)
						{
							currentEmailUserInfoViewModel.UserNextId = next.UserId;
						}
						CRMspSelectUsersInMode_Result previous = Lists.GetPrevious(list, cRMspSelectUsersInMode_Result);
						if (previous != null)
						{
							currentEmailUserInfoViewModel.UserPreviousId = previous.UserId;
						}
					}
					currentEmailUserInfoViewModel.EmailUselList = GetEmailUser(cRMspSelectUsersInMode_Result.UserId);
				}
				else
				{
					currentEmailUserInfoViewModel.IsFind = false;
					currentEmailUserInfoViewModel.Message = Messages.ErrorNotFound;
					currentEmailUserInfoViewModel.CurrUser = null;
					currentEmailUserInfoViewModel.UserCurrentId = -1;
					currentEmailUserInfoViewModel.UserNextId = -1;
					currentEmailUserInfoViewModel.UserPreviousId = -1;
					currentEmailUserInfoViewModel.UserFirstId = -1;
					currentEmailUserInfoViewModel.UserLastId = -1;
					currentEmailUserInfoViewModel.EmailUselList = null;
				}
			}
			else
			{
				currentEmailUserInfoViewModel.IsFind = false;
				currentEmailUserInfoViewModel.Message = Messages.ErrorNotFound;
				currentEmailUserInfoViewModel.CurrUser = null;
				currentEmailUserInfoViewModel.UserCurrentId = -1;
				currentEmailUserInfoViewModel.UserNextId = -1;
				currentEmailUserInfoViewModel.UserPreviousId = -1;
				currentEmailUserInfoViewModel.UserFirstId = -1;
				currentEmailUserInfoViewModel.UserLastId = -1;
				currentEmailUserInfoViewModel.EmailUselList = null;
			}
		}
		catch (DbEntityValidationException ex)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)ex);
			currentEmailUserInfoViewModel.Message = Messages.frmErrorMessage + "<br />" + ((Exception)(object)ex).Message;
		}
		catch (Exception ex2)
		{
			ErrorSignal.FromCurrentContext().Raise(ex2);
			currentEmailUserInfoViewModel.Message = Messages.frmErrorMessage + "<br />" + ex2.Message;
		}
		return Json(currentEmailUserInfoViewModel, JsonRequestBehavior.AllowGet);
	}

	public List<EmailspSelectEmailUsersInfoByUser_Result> GetEmailUser(int usid)
	{
		List<EmailspSelectEmailUsersInfoByUser_Result> list = new List<EmailspSelectEmailUsersInfoByUser_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			list = Enumerable.ToList<EmailspSelectEmailUsersInfoByUser_Result>((IEnumerable<EmailspSelectEmailUsersInfoByUser_Result>)db.EmailspSelectEmailUsersInfoByUser(usid));
			List<CRMspSelectUsers_Result> list2 = CRMIdeal.Classes.Helper.User.SelectUsers();
			if (list2 != null && Enumerable.Any<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)list2))
			{
				foreach (EmailspSelectEmailUsersInfoByUser_Result item in list)
				{
					if (string.IsNullOrEmpty(item.AppType))
					{
						item.AppType = Configuration.AppType;
					}
					item.AppType = Configuration.GetAppType(item.AppType);
					string text = "";
					string text2 = "";
					if (Enumerable.Any<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)list2))
					{
						CRMspSelectUsers_Result cRMspSelectUsers_Result = Enumerable.FirstOrDefault<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)list2, (Func<CRMspSelectUsers_Result, bool>)((CRMspSelectUsers_Result c) => c.UserId == item.FirstRegisterUserId));
						text = ((cRMspSelectUsers_Result != null) ? (cRMspSelectUsers_Result.LName + ((cRMspSelectUsers_Result.FName != null) ? (" " + cRMspSelectUsers_Result.FName) : "")) : "");
						CRMspSelectUsers_Result cRMspSelectUsers_Result2 = Enumerable.FirstOrDefault<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)list2, (Func<CRMspSelectUsers_Result, bool>)((CRMspSelectUsers_Result c) => c.UserId == item.UserId));
						text2 = ((cRMspSelectUsers_Result2 != null) ? (cRMspSelectUsers_Result2.LName + ((cRMspSelectUsers_Result2.FName != null) ? (" " + cRMspSelectUsers_Result2.FName) : "")) : "");
					}
					string text3 = (item.FirstRegisterDate.HasValue ? item.FirstRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
					item.FirstRegisterDatePersian = text + " (" + text3 + ")";
					_ = item.RegisterDate;
					string text4 = item.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
					item.RegisterDatePersian = text2 + " (" + Labels.AppType + ":" + item.AppType + ")  (" + text4 + ")";
				}
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return list;
	}

	[DynamicAuthorize(ControllerName = "frmDefineUsers", ActionName = "actInsertEmail,actEditEmail")]
	public ActionResult EmailUserInsertEdit(int usId, int id = 0)
	{
		_003C_003Ec__DisplayClass146_0 _003C_003Ec__DisplayClass146_ = new _003C_003Ec__DisplayClass146_0();
		_003C_003Ec__DisplayClass146_.id = id;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		EmailUsersInfoViewModel emailUsersInfoViewModel = new EmailUsersInfoViewModel();
		if (usId == 0)
		{
			base.ViewBag.Error = Messages.msgErrorNotSelectUser;
			return null;
		}
		if (_003C_003Ec__DisplayClass146_.id > 0)
		{
			if (!UserLogin.IsUserAccess("frmDefineUsers", "actEditEmail"))
			{
				base.ViewBag.Error = Messages.NotAccessToPage;
				return null;
			}
			DbSet<EmailUsersInfo> emailUsersInfo = _dbTbl.EmailUsersInfo;
			ParameterExpression val = Expression.Parameter(typeof(EmailUsersInfo), "c");
			EmailUsersInfo emailUsersInfo2 = Queryable.FirstOrDefault<EmailUsersInfo>((IQueryable<EmailUsersInfo>)emailUsersInfo, Expression.Lambda<Func<EmailUsersInfo, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass146_, typeof(_003C_003Ec__DisplayClass146_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (emailUsersInfo2 == null)
			{
				base.ViewBag.Error = Messages.ErrorNotFound;
				return null;
			}
			emailUsersInfoViewModel = new EmailUsersInfoViewModel
			{
				EmailUsersInfoId = emailUsersInfo2.EmailUsersInfoId,
				euUserId = emailUsersInfo2.euUserId,
				euNikeName = emailUsersInfo2.euNikeName,
				euNikeEmail = emailUsersInfo2.euNikeEmail,
				euPOP3Server = emailUsersInfo2.euPOP3Server,
				euSMTPServer = emailUsersInfo2.euSMTPServer,
				euUserName = emailUsersInfo2.euUserName,
				euPassword = emailUsersInfo2.euPassword,
				euIsActive = emailUsersInfo2.euIsActive,
				euAutoDeleteReceivedEmail = emailUsersInfo2.euAutoDeleteReceivedEmail,
				euPOP3Port = emailUsersInfo2.euPOP3Port,
				euPOP3UseSsl = emailUsersInfo2.euPOP3UseSsl,
				euReceiveServerType = emailUsersInfo2.euReceiveServerType,
				euIMAPServer = emailUsersInfo2.euIMAPServer,
				euIMAPPort = emailUsersInfo2.euIMAPPort,
				euIMAPUseSsl = emailUsersInfo2.euIMAPUseSsl,
				euDeleteFromSrvrAfterDay = emailUsersInfo2.euDeleteFromSrvrAfterDay,
				euDeleteSrvrAfterDelDb = emailUsersInfo2.euDeleteSrvrAfterDelDb,
				euSMTPPort = emailUsersInfo2.euSMTPPort.GetValueOrDefault(25),
				euSMTPUseSsl = emailUsersInfo2.euSMTPUseSsl,
				euSMTPUseDefCredentials = emailUsersInfo2.euSMTPUseDefCredentials
			};
		}
		else
		{
			if (!UserLogin.IsUserAccess("frmDefineUsers", "actInsertEmail"))
			{
				base.ViewBag.Error = Messages.NotAccessToPage;
				return null;
			}
			emailUsersInfoViewModel = new EmailUsersInfoViewModel
			{
				euUserId = usId
			};
		}
		GetReceiveServerTypes();
		return View(emailUsersInfoViewModel);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmDefineUsers", ActionName = "actInsertEmail,actEditEmail")]
	[ValidateAntiForgeryToken]
	public ActionResult EmailUserInsertEdit(EmailUsersInfoViewModel vm)
	{
		_003C_003Ec__DisplayClass147_0 _003C_003Ec__DisplayClass147_ = new _003C_003Ec__DisplayClass147_0();
		_003C_003Ec__DisplayClass147_.vm = vm;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		DateTime now = DateTime.Now;
		DateTime value = now;
		string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
		int userId = UserLogin.CurrentUser.UserId;
		short value2 = short.Parse(Financial.Get().Id.ToString());
		short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
		string appType = Configuration.AppType;
		string text = "";
		int countError = 0;
		try
		{
			text = ChkBeforeSubmitUserEmail(_003C_003Ec__DisplayClass147_.vm, ref countError);
			if (countError > 0)
			{
				base.ViewBag.Error = text;
				GetReceiveServerTypes();
				return View(_003C_003Ec__DisplayClass147_.vm);
			}
			if (!base.ModelState.IsValid)
			{
				base.ViewBag.Error = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
			else
			{
				EmailUsersInfo emailUsersInfo = new EmailUsersInfo();
				if (_003C_003Ec__DisplayClass147_.vm.EmailUsersInfoId > 0)
				{
					DbSet<EmailUsersInfo> emailUsersInfo2 = _dbTbl.EmailUsersInfo;
					ParameterExpression val = Expression.Parameter(typeof(EmailUsersInfo), "c");
					emailUsersInfo = Queryable.FirstOrDefault<EmailUsersInfo>((IQueryable<EmailUsersInfo>)emailUsersInfo2, Expression.Lambda<Func<EmailUsersInfo, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass147_, typeof(_003C_003Ec__DisplayClass147_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				}
				emailUsersInfo.UserId = UserLogin.CurrentUser.UserId;
				emailUsersInfo.RegisterDate = now;
				emailUsersInfo.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				emailUsersInfo.AppType = Configuration.AppType;
				emailUsersInfo.euUserId = _003C_003Ec__DisplayClass147_.vm.euUserId;
				emailUsersInfo.euNikeName = _003C_003Ec__DisplayClass147_.vm.euNikeName;
				emailUsersInfo.euNikeEmail = _003C_003Ec__DisplayClass147_.vm.euNikeEmail;
				emailUsersInfo.euPOP3Server = _003C_003Ec__DisplayClass147_.vm.euPOP3Server;
				emailUsersInfo.euSMTPServer = _003C_003Ec__DisplayClass147_.vm.euSMTPServer;
				emailUsersInfo.euUserName = _003C_003Ec__DisplayClass147_.vm.euUserName;
				if (emailUsersInfo.EmailUsersInfoId <= 0)
				{
					emailUsersInfo.euPassword = XorCipher.EncryptByPrivateKey(_003C_003Ec__DisplayClass147_.vm.euPassword);
				}
				else
				{
					_003C_003Ec__DisplayClass147_.vm.euPassword = ((!string.IsNullOrEmpty(_003C_003Ec__DisplayClass147_.vm.euPassword)) ? _003C_003Ec__DisplayClass147_.vm.euPassword : null);
					string text2 = ((!string.IsNullOrEmpty(_003C_003Ec__DisplayClass147_.vm.euPassword)) ? XorCipher.EncryptByPrivateKey(_003C_003Ec__DisplayClass147_.vm.euPassword) : null);
					if (!string.IsNullOrEmpty(emailUsersInfo.euPassword))
					{
						XorCipher.DecryptByPrivateKey(emailUsersInfo.euPassword);
					}
					bool num = text2 == emailUsersInfo.euPassword;
					bool flag = _003C_003Ec__DisplayClass147_.vm.euPassword == emailUsersInfo.euPassword;
					if (!num && !flag)
					{
						emailUsersInfo.euPassword = text2;
					}
				}
				emailUsersInfo.euIsActive = _003C_003Ec__DisplayClass147_.vm.euIsActive;
				emailUsersInfo.euAutoDeleteReceivedEmail = _003C_003Ec__DisplayClass147_.vm.euAutoDeleteReceivedEmail;
				emailUsersInfo.euPOP3Port = _003C_003Ec__DisplayClass147_.vm.euPOP3Port;
				emailUsersInfo.euPOP3UseSsl = _003C_003Ec__DisplayClass147_.vm.euPOP3UseSsl;
				emailUsersInfo.euReceiveServerType = _003C_003Ec__DisplayClass147_.vm.euReceiveServerType;
				emailUsersInfo.euIMAPServer = _003C_003Ec__DisplayClass147_.vm.euIMAPServer;
				emailUsersInfo.euIMAPPort = _003C_003Ec__DisplayClass147_.vm.euIMAPPort;
				emailUsersInfo.euIMAPUseSsl = _003C_003Ec__DisplayClass147_.vm.euIMAPUseSsl;
				emailUsersInfo.euDeleteSrvrAfterDelDb = _003C_003Ec__DisplayClass147_.vm.euDeleteSrvrAfterDelDb;
				emailUsersInfo.euDeleteFromSrvrAfterDay = _003C_003Ec__DisplayClass147_.vm.euDeleteFromSrvrAfterDay;
				emailUsersInfo.euSMTPPort = _003C_003Ec__DisplayClass147_.vm.euSMTPPort;
				emailUsersInfo.euSMTPUseSsl = _003C_003Ec__DisplayClass147_.vm.euSMTPUseSsl;
				emailUsersInfo.euSMTPUseDefCredentials = _003C_003Ec__DisplayClass147_.vm.euSMTPUseDefCredentials;
				if (emailUsersInfo.EmailUsersInfoId > 0)
				{
					_dbTbl.Entry(emailUsersInfo).State = EntityState.Modified;
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("EmailUsersInfo");
					base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
				}
				else
				{
					DateTime now2 = DateTime.Now;
					emailUsersInfo.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
					emailUsersInfo.FirstRegisterDate = now2;
					emailUsersInfo.FirstRegisterDatePersian = now2.ToString("yyyyMMdd", new PersianCulture());
					emailUsersInfo.LanguageID = result;
					emailUsersInfo.GUId = System.Guid.NewGuid();
					_dbTbl.EmailUsersInfo.Add(emailUsersInfo);
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("EmailUsersInfo");
					base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
				}
				if (emailUsersInfo.euReceiveServerType.GetValueOrDefault() == 1)
				{
					ObjectParameter insertedId = new ObjectParameter("insertedId", typeof(int));
					db.EmailspInsertEmailReceiveFolders("Inbox", emailUsersInfo.EmailUsersInfoId, userId, value, registerDatePersian, value2, value3, appType, result, null, insertedId);
					ObjectParameter insertedId2 = new ObjectParameter("insertedId", typeof(int));
					db.EmailspInsertEmailReceiveFolders("Sent", emailUsersInfo.EmailUsersInfoId, userId, value, registerDatePersian, value2, value3, appType, result, null, insertedId2);
					ObjectParameter insertedId3 = new ObjectParameter("insertedId", typeof(int));
					db.EmailspInsertEmailReceiveFolders("Junk", emailUsersInfo.EmailUsersInfoId, userId, value, registerDatePersian, value2, value3, appType, result, null, insertedId3);
					ObjectParameter insertedId4 = new ObjectParameter("insertedId", typeof(int));
					db.EmailspInsertEmailReceiveFolders("Trash", emailUsersInfo.EmailUsersInfoId, userId, value, registerDatePersian, value2, value3, appType, result, null, insertedId4);
				}
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
			base.ViewBag.Error = Messages.frmErrorMessage;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			base.ViewBag.Error = Messages.frmErrorMessage;
		}
		GetReceiveServerTypes();
		return View(_003C_003Ec__DisplayClass147_.vm);
	}

	public List<SelectListItem> GetReceiveServerTypes()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		list.Add(new SelectListItem
		{
			Text = "POP3",
			Value = "1",
			Selected = true
		});
		list.Add(new SelectListItem
		{
			Text = "IMAP",
			Value = "2",
			Selected = false
		});
		base.ViewBag.lstReceiveServerTypes = list;
		return list;
	}

	public string ChkBeforeSubmitUserEmail(EmailUsersInfoViewModel eUser, ref int countError)
	{
		string text = "";
		if (string.IsNullOrEmpty(eUser.euNikeName))
		{
			text = text + Messages.CheckEmailUserNikeName + "<br>";
			countError++;
		}
		if (string.IsNullOrEmpty(eUser.euNikeEmail))
		{
			text = text + Messages.CheckEmailUserNikeEmail + "<br>";
			countError++;
		}
		if (eUser.euReceiveServerType.GetValueOrDefault() == 1)
		{
			if (string.IsNullOrWhiteSpace(eUser.euPOP3Server))
			{
				text = text + Messages.CheckEmailUserPOP3Server + "<br>";
				countError++;
			}
			if (eUser.euPOP3UseSsl.GetValueOrDefault() && (eUser.euPOP3Port <= 0 || !eUser.euPOP3Port.HasValue))
			{
				text = Messages.msgErrorSslNotWorkWithoutPort + "<br>";
				countError++;
			}
		}
		else if (eUser.euReceiveServerType.GetValueOrDefault() == 2)
		{
			if (string.IsNullOrWhiteSpace(eUser.euIMAPServer))
			{
				text = text + Messages.CheckEmailUserIMAPServer + "<br>";
				countError++;
			}
			if (eUser.euIMAPUseSsl.GetValueOrDefault() && (eUser.euIMAPPort <= 0 || !eUser.euIMAPPort.HasValue))
			{
				text = Messages.msgErrorSslNotWorkWithoutPort + "<br>";
				countError++;
			}
		}
		if (string.IsNullOrEmpty(eUser.euSMTPServer))
		{
			text = text + Messages.CheckEmailUserSMTPServer + "<br>";
			countError++;
		}
		if (string.IsNullOrEmpty(eUser.euUserName))
		{
			text = text + Messages.CheckEmailUserName + "<br>";
			countError++;
		}
		if (string.IsNullOrEmpty(eUser.euPassword))
		{
			text = text + Messages.CheckEmailUserPassword + "<br>";
			countError++;
		}
		return text;
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmDefineUsers", ActionName = "actDeleteEmail")]
	public string EmailUserDelete(int euId)
	{
		_003C_003Ec__DisplayClass150_0 _003C_003Ec__DisplayClass150_ = new _003C_003Ec__DisplayClass150_0();
		_003C_003Ec__DisplayClass150_.euId = euId;
		string result = "-1";
		try
		{
			DbSet<EmailUsersInfo> emailUsersInfo = _dbTbl.EmailUsersInfo;
			ParameterExpression val = Expression.Parameter(typeof(EmailUsersInfo), "c");
			if (Queryable.FirstOrDefault<EmailUsersInfo>((IQueryable<EmailUsersInfo>)emailUsersInfo, Expression.Lambda<Func<EmailUsersInfo, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass150_, typeof(_003C_003Ec__DisplayClass150_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) != null)
			{
				try
				{
					mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)Enumerable.ToList<mct_Result>((IEnumerable<mct_Result>)db.CRMspDeleteEmailUsersInfo(_003C_003Ec__DisplayClass150_.euId)));
					if (mct_Result != null && mct_Result.Result > 0)
					{
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("EmailUsersInfo");
						result = "1";
					}
					else if (mct_Result != null && mct_Result.Result == 0)
					{
						result = Messages.RedundancyMessage;
					}
				}
				catch (DbEntityValidationException e)
				{
					ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
					result = Messages.RedundancyMessage;
				}
				catch (Exception ex)
				{
					ErrorSignal.FromCurrentContext().Raise(ex);
					result = Messages.msgErrorCommunicateWithServer + "<br><p style=text-align:left;>" + ex.Message + "</p>";
				}
			}
			else
			{
				result = Messages.ErrorNotFound;
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			result = Messages.frmErrorMessage;
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actuLinkedDyFormAccessForUser")]
	public ActionResult LinkedDyFormAccessForUser()
	{
		GetActiveUsers();
		return View();
	}

	private void GetActiveUsers()
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
			List<CRMspSelectActiveUsers_Result> list2 = Enumerable.ToList<CRMspSelectActiveUsers_Result>((IEnumerable<CRMspSelectActiveUsers_Result>)db.CRMspSelectActiveUsers(lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspSelectActiveUsers_Result, SelectListItem>((IEnumerable<CRMspSelectActiveUsers_Result>)list2, (Func<CRMspSelectActiveUsers_Result, SelectListItem>)((CRMspSelectActiveUsers_Result item) => new SelectListItem
			{
				Text = item.Name,
				Value = item.UserId.ToString(),
				Selected = false
			})));
			foreach (SelectListItem item in Enumerable.Where<SelectListItem>((IEnumerable<SelectListItem>)list, (Func<SelectListItem, bool>)((SelectListItem item) => item.Value == UserLogin.CurrentUser.UserId.ToString())))
			{
				item.Selected = true;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.UsersList = list;
	}

	public List<TreeViewItemModel> GetNotFormUserAccess(int userId)
	{
		List<TreeViewItemModel> list = new List<TreeViewItemModel>();
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
			List<CRMspDySelectNotFormUserAccess_Result> list2 = Enumerable.ToList<CRMspDySelectNotFormUserAccess_Result>((IEnumerable<CRMspDySelectNotFormUserAccess_Result>)db.CRMspDySelectNotFormUserAccess(userId, lCID, result, result2));
			if (list2 != null && Enumerable.Any<CRMspDySelectNotFormUserAccess_Result>((IEnumerable<CRMspDySelectNotFormUserAccess_Result>)list2))
			{
				foreach (CRMspDySelectNotFormUserAccess_Result item4 in list2)
				{
					if (string.IsNullOrWhiteSpace(item4.FOSysPartShow))
					{
						item4.FOSysPartId = null;
					}
				}
			}
			List<CRMspDySelectNotFormUserAccess_Result> list3 = Enumerable.ToList<CRMspDySelectNotFormUserAccess_Result>(Enumerable.Where<CRMspDySelectNotFormUserAccess_Result>((IEnumerable<CRMspDySelectNotFormUserAccess_Result>)list2, (Func<CRMspDySelectNotFormUserAccess_Result, bool>)((CRMspDySelectNotFormUserAccess_Result c) => c.ParentFormId == 0)));
			List<CRMspDySelectNotFormUserAccess_Result> list4 = Enumerable.ToList<CRMspDySelectNotFormUserAccess_Result>(Enumerable.Where<CRMspDySelectNotFormUserAccess_Result>((IEnumerable<CRMspDySelectNotFormUserAccess_Result>)list3, (Func<CRMspDySelectNotFormUserAccess_Result, bool>)((CRMspDySelectNotFormUserAccess_Result m) => m.CrmSysPartId.HasValue && !m.FOSysPartId.HasValue)));
			if (Enumerable.Any<CRMspDySelectNotFormUserAccess_Result>((IEnumerable<CRMspDySelectNotFormUserAccess_Result>)list4))
			{
				List<TreeViewItemModel> list5 = new List<TreeViewItemModel>();
				TreeViewItemModel treeViewItemModel = new TreeViewItemModel();
				treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", "-2|0|-2|-2"));
				treeViewItemModel.Id = "-2|0|-2|-2";
				treeViewItemModel.Text = Labels.DyFrmCrmSysPart;
				treeViewItemModel.ImageUrl = "";
				foreach (CRMspDySelectNotFormUserAccess_Result item3 in list4)
				{
					TreeViewItemModel mainTree3 = new TreeViewItemModel();
					mainTree3.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", (item3.CrmSysPartId.HasValue ? item3.CrmSysPartId.ToString() : "0") + "|0|-1|-1"));
					mainTree3.Id = (item3.CrmSysPartId.HasValue ? item3.CrmSysPartId.ToString() : "0") + "|0|-1|-1";
					mainTree3.Text = item3.CrmSysPartTitle;
					mainTree3.ImageUrl = "";
					if (Enumerable.FirstOrDefault<TreeViewItemModel>((IEnumerable<TreeViewItemModel>)list5, (Func<TreeViewItemModel, bool>)((TreeViewItemModel m) => m.Id == mainTree3.Id)) != null)
					{
						continue;
					}
					List<CRMspDySelectNotFormUserAccess_Result> list6 = Enumerable.ToList<CRMspDySelectNotFormUserAccess_Result>(Enumerable.Where<CRMspDySelectNotFormUserAccess_Result>((IEnumerable<CRMspDySelectNotFormUserAccess_Result>)list4, (Func<CRMspDySelectNotFormUserAccess_Result, bool>)((CRMspDySelectNotFormUserAccess_Result c) => c.CrmSysPartId == item3.CrmSysPartId)));
					List<TreeViewItemModel> list7 = new List<TreeViewItemModel>();
					foreach (CRMspDySelectNotFormUserAccess_Result subfrmIn3 in list6)
					{
						TreeViewItemModel treeViewItemModel2 = new TreeViewItemModel();
						treeViewItemModel2.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", (subfrmIn3.CrmSysPartId.HasValue ? subfrmIn3.CrmSysPartId.ToString() : "0") + "|" + (subfrmIn3.FOSysPartId.HasValue ? subfrmIn3.FOSysPartId.ToString() : "0") + "|" + subfrmIn3.ParentFormId + "|" + subfrmIn3.FormId));
						treeViewItemModel2.Id = (subfrmIn3.CrmSysPartId.HasValue ? subfrmIn3.CrmSysPartId.ToString() : "0") + "|" + (subfrmIn3.FOSysPartId.HasValue ? subfrmIn3.FOSysPartId.ToString() : "0") + "|" + subfrmIn3.ParentFormId + "|" + subfrmIn3.FormId;
						treeViewItemModel2.Text = subfrmIn3.FormName;
						treeViewItemModel2.ImageUrl = "";
						List<CRMspDySelectNotFormUserAccess_Result> list8 = Enumerable.ToList<CRMspDySelectNotFormUserAccess_Result>(Enumerable.Where<CRMspDySelectNotFormUserAccess_Result>((IEnumerable<CRMspDySelectNotFormUserAccess_Result>)list2, (Func<CRMspDySelectNotFormUserAccess_Result, bool>)((CRMspDySelectNotFormUserAccess_Result c) => c.ParentFormId == subfrmIn3.FormId)));
						List<TreeViewItemModel> list9 = new List<TreeViewItemModel>();
						foreach (CRMspDySelectNotFormUserAccess_Result item5 in list8)
						{
							TreeViewItemModel treeViewItemModel3 = new TreeViewItemModel();
							treeViewItemModel3.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", (item5.CrmSysPartId.HasValue ? item5.CrmSysPartId.ToString() : "0") + "|" + (item5.FOSysPartId.HasValue ? item5.FOSysPartId.ToString() : "0") + "|" + item5.ParentFormId + "|" + item5.FormId));
							treeViewItemModel3.Id = (item5.CrmSysPartId.HasValue ? item5.CrmSysPartId.ToString() : "0") + "|" + (item5.FOSysPartId.HasValue ? item5.FOSysPartId.ToString() : "0") + "|" + item5.ParentFormId + "|" + item5.FormId;
							treeViewItemModel3.Text = item5.FormName;
							treeViewItemModel3.ImageUrl = "";
							treeViewItemModel3.Items = null;
							list9.Add(treeViewItemModel3);
						}
						treeViewItemModel2.Items = new List<TreeViewItemModel>(list9);
						list7.Add(treeViewItemModel2);
					}
					mainTree3.Items = new List<TreeViewItemModel>(list7);
					list5.Add(mainTree3);
				}
				treeViewItemModel.Items = new List<TreeViewItemModel>(list5);
				list.Add(treeViewItemModel);
			}
			List<CRMspDySelectNotFormUserAccess_Result> list10 = Enumerable.ToList<CRMspDySelectNotFormUserAccess_Result>(Enumerable.Where<CRMspDySelectNotFormUserAccess_Result>((IEnumerable<CRMspDySelectNotFormUserAccess_Result>)list3, (Func<CRMspDySelectNotFormUserAccess_Result, bool>)((CRMspDySelectNotFormUserAccess_Result m) => !m.CrmSysPartId.HasValue && m.FOSysPartId.HasValue)));
			if (Enumerable.Any<CRMspDySelectNotFormUserAccess_Result>((IEnumerable<CRMspDySelectNotFormUserAccess_Result>)list10))
			{
				List<TreeViewItemModel> list11 = new List<TreeViewItemModel>();
				TreeViewItemModel treeViewItemModel4 = new TreeViewItemModel();
				treeViewItemModel4.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", "0|-2|-2|-2"));
				treeViewItemModel4.Id = "0|-2|-2|-2";
				treeViewItemModel4.Text = Labels.DyFrmFOSysPart;
				treeViewItemModel4.ImageUrl = "";
				foreach (CRMspDySelectNotFormUserAccess_Result item2 in list10)
				{
					TreeViewItemModel mainTree2 = new TreeViewItemModel();
					mainTree2.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", "0|" + (item2.FOSysPartId.HasValue ? item2.FOSysPartId.ToString() : "0") + "|-1|-1"));
					mainTree2.Id = "0|" + (item2.FOSysPartId.HasValue ? item2.FOSysPartId.ToString() : "0") + "|-1|-1";
					mainTree2.Text = item2.FOSysPartTitle;
					mainTree2.ImageUrl = "";
					if (Enumerable.FirstOrDefault<TreeViewItemModel>((IEnumerable<TreeViewItemModel>)list11, (Func<TreeViewItemModel, bool>)((TreeViewItemModel m) => m.Id == mainTree2.Id)) != null)
					{
						continue;
					}
					List<CRMspDySelectNotFormUserAccess_Result> list12 = Enumerable.ToList<CRMspDySelectNotFormUserAccess_Result>(Enumerable.Where<CRMspDySelectNotFormUserAccess_Result>((IEnumerable<CRMspDySelectNotFormUserAccess_Result>)list10, (Func<CRMspDySelectNotFormUserAccess_Result, bool>)((CRMspDySelectNotFormUserAccess_Result c) => c.FOSysPartId == item2.FOSysPartId)));
					List<TreeViewItemModel> list13 = new List<TreeViewItemModel>();
					foreach (CRMspDySelectNotFormUserAccess_Result subfrmIn2 in list12)
					{
						TreeViewItemModel treeViewItemModel5 = new TreeViewItemModel();
						treeViewItemModel5.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", (subfrmIn2.CrmSysPartId.HasValue ? subfrmIn2.CrmSysPartId.ToString() : "0") + "|" + (subfrmIn2.FOSysPartId.HasValue ? subfrmIn2.FOSysPartId.ToString() : "0") + "|" + subfrmIn2.ParentFormId + "|" + subfrmIn2.FormId));
						treeViewItemModel5.Id = (subfrmIn2.CrmSysPartId.HasValue ? subfrmIn2.CrmSysPartId.ToString() : "0") + "|" + (subfrmIn2.FOSysPartId.HasValue ? subfrmIn2.FOSysPartId.ToString() : "0") + "|" + subfrmIn2.ParentFormId + "|" + subfrmIn2.FormId;
						treeViewItemModel5.Text = subfrmIn2.FormName;
						treeViewItemModel5.ImageUrl = "";
						List<CRMspDySelectNotFormUserAccess_Result> list14 = Enumerable.ToList<CRMspDySelectNotFormUserAccess_Result>(Enumerable.Where<CRMspDySelectNotFormUserAccess_Result>((IEnumerable<CRMspDySelectNotFormUserAccess_Result>)list2, (Func<CRMspDySelectNotFormUserAccess_Result, bool>)((CRMspDySelectNotFormUserAccess_Result c) => c.ParentFormId == subfrmIn2.FormId)));
						List<TreeViewItemModel> list15 = new List<TreeViewItemModel>();
						foreach (CRMspDySelectNotFormUserAccess_Result item6 in list14)
						{
							TreeViewItemModel treeViewItemModel6 = new TreeViewItemModel();
							treeViewItemModel6.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", (item6.CrmSysPartId.HasValue ? item6.CrmSysPartId.ToString() : "0") + "|" + (item6.FOSysPartId.HasValue ? item6.FOSysPartId.ToString() : "0") + "|" + item6.ParentFormId + "|" + item6.FormId));
							treeViewItemModel6.Id = (item6.CrmSysPartId.HasValue ? item6.CrmSysPartId.ToString() : "0") + "|" + (item6.FOSysPartId.HasValue ? item6.FOSysPartId.ToString() : "0") + "|" + item6.ParentFormId + "|" + item6.FormId;
							treeViewItemModel6.Text = item6.FormName;
							treeViewItemModel6.ImageUrl = "";
							treeViewItemModel6.Items = null;
							list15.Add(treeViewItemModel6);
						}
						treeViewItemModel5.Items = new List<TreeViewItemModel>(list15);
						list13.Add(treeViewItemModel5);
					}
					mainTree2.Items = new List<TreeViewItemModel>(list13);
					list11.Add(mainTree2);
				}
				treeViewItemModel4.Items = new List<TreeViewItemModel>(list11);
				list.Add(treeViewItemModel4);
			}
			List<CRMspDySelectNotFormUserAccess_Result> list16 = Enumerable.ToList<CRMspDySelectNotFormUserAccess_Result>(Enumerable.Where<CRMspDySelectNotFormUserAccess_Result>((IEnumerable<CRMspDySelectNotFormUserAccess_Result>)list3, (Func<CRMspDySelectNotFormUserAccess_Result, bool>)((CRMspDySelectNotFormUserAccess_Result m) => m.CrmSysPartId.HasValue && m.FOSysPartId.HasValue)));
			if (Enumerable.Any<CRMspDySelectNotFormUserAccess_Result>((IEnumerable<CRMspDySelectNotFormUserAccess_Result>)list16))
			{
				List<TreeViewItemModel> list17 = new List<TreeViewItemModel>();
				TreeViewItemModel treeViewItemModel7 = new TreeViewItemModel();
				treeViewItemModel7.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", "-2|-2|-2|-2"));
				treeViewItemModel7.Id = "-2|-2|-2|-2";
				treeViewItemModel7.Text = Labels.DyFrmBothSysPart;
				treeViewItemModel7.ImageUrl = "";
				foreach (CRMspDySelectNotFormUserAccess_Result item in list16)
				{
					TreeViewItemModel mainTree = new TreeViewItemModel();
					mainTree.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", (item.CrmSysPartId.HasValue ? item.CrmSysPartId.ToString() : "0") + "|" + (item.FOSysPartId.HasValue ? item.FOSysPartId.ToString() : "0") + "|-1|-1"));
					mainTree.Id = (item.CrmSysPartId.HasValue ? item.CrmSysPartId.ToString() : "0") + "|" + (item.FOSysPartId.HasValue ? item.FOSysPartId.ToString() : "0") + "|-1|-1";
					mainTree.Text = item.CrmSysPartTitle + "-" + item.FOSysPartTitle;
					mainTree.ImageUrl = "";
					if (Enumerable.FirstOrDefault<TreeViewItemModel>((IEnumerable<TreeViewItemModel>)list17, (Func<TreeViewItemModel, bool>)((TreeViewItemModel m) => m.Id == mainTree.Id)) != null)
					{
						continue;
					}
					List<CRMspDySelectNotFormUserAccess_Result> list18 = Enumerable.ToList<CRMspDySelectNotFormUserAccess_Result>(Enumerable.Where<CRMspDySelectNotFormUserAccess_Result>((IEnumerable<CRMspDySelectNotFormUserAccess_Result>)list16, (Func<CRMspDySelectNotFormUserAccess_Result, bool>)((CRMspDySelectNotFormUserAccess_Result c) => c.FOSysPartId == item.FOSysPartId && c.CrmSysPartId == item.CrmSysPartId)));
					List<TreeViewItemModel> list19 = new List<TreeViewItemModel>();
					foreach (CRMspDySelectNotFormUserAccess_Result subfrmIn in list18)
					{
						TreeViewItemModel treeViewItemModel8 = new TreeViewItemModel();
						treeViewItemModel8.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", (subfrmIn.CrmSysPartId.HasValue ? subfrmIn.CrmSysPartId.ToString() : "0") + "|" + (subfrmIn.FOSysPartId.HasValue ? subfrmIn.FOSysPartId.ToString() : "0") + "|" + subfrmIn.ParentFormId + "|" + subfrmIn.FormId));
						treeViewItemModel8.Id = (subfrmIn.CrmSysPartId.HasValue ? subfrmIn.CrmSysPartId.ToString() : "0") + "|" + (subfrmIn.FOSysPartId.HasValue ? subfrmIn.FOSysPartId.ToString() : "0") + "|" + subfrmIn.ParentFormId + "|" + subfrmIn.FormId;
						treeViewItemModel8.Text = subfrmIn.FormName;
						treeViewItemModel8.ImageUrl = "";
						List<CRMspDySelectNotFormUserAccess_Result> list20 = Enumerable.ToList<CRMspDySelectNotFormUserAccess_Result>(Enumerable.Where<CRMspDySelectNotFormUserAccess_Result>((IEnumerable<CRMspDySelectNotFormUserAccess_Result>)list2, (Func<CRMspDySelectNotFormUserAccess_Result, bool>)((CRMspDySelectNotFormUserAccess_Result c) => c.ParentFormId == subfrmIn.FormId)));
						List<TreeViewItemModel> list21 = new List<TreeViewItemModel>();
						foreach (CRMspDySelectNotFormUserAccess_Result item7 in list20)
						{
							TreeViewItemModel treeViewItemModel9 = new TreeViewItemModel();
							treeViewItemModel9.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", (item7.CrmSysPartId.HasValue ? item7.CrmSysPartId.ToString() : "0") + "|" + (item7.FOSysPartId.HasValue ? item7.FOSysPartId.ToString() : "0") + "|" + item7.ParentFormId + "|" + item7.FormId));
							treeViewItemModel9.Id = (item7.CrmSysPartId.HasValue ? item7.CrmSysPartId.ToString() : "0") + "|" + (item7.FOSysPartId.HasValue ? item7.FOSysPartId.ToString() : "0") + "|" + item7.ParentFormId + "|" + item7.FormId;
							treeViewItemModel9.Text = item7.FormName;
							treeViewItemModel9.ImageUrl = "";
							treeViewItemModel9.Items = null;
							list21.Add(treeViewItemModel9);
						}
						treeViewItemModel8.Items = new List<TreeViewItemModel>(list21);
						list19.Add(treeViewItemModel8);
					}
					mainTree.Items = new List<TreeViewItemModel>(list19);
					list17.Add(mainTree);
				}
				treeViewItemModel7.Items = new List<TreeViewItemModel>(list17);
				list.Add(treeViewItemModel7);
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return list;
	}

	[AjaxOnly]
	public ActionResult _PartialLinkedDyFormNotAccessForUser(int userId)
	{
		try
		{
			base.ViewBag.FormUserNotAccessTree = GetNotFormUserAccess(userId);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return PartialView();
	}

	public List<TreeViewItemModel> GetFormUserAccess(int userId)
	{
		List<TreeViewItemModel> list = new List<TreeViewItemModel>();
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
			List<CRMspDySelectFormUserAccess_Result> list2 = Enumerable.ToList<CRMspDySelectFormUserAccess_Result>((IEnumerable<CRMspDySelectFormUserAccess_Result>)db.CRMspDySelectFormUserAccess(userId, lCID, result, result2));
			if (list2 != null && Enumerable.Any<CRMspDySelectFormUserAccess_Result>((IEnumerable<CRMspDySelectFormUserAccess_Result>)list2))
			{
				foreach (CRMspDySelectFormUserAccess_Result item4 in list2)
				{
					if (string.IsNullOrWhiteSpace(item4.FOSysPartShow))
					{
						item4.FOSysPartId = null;
					}
				}
			}
			List<CRMspDySelectFormUserAccess_Result> list3 = Enumerable.ToList<CRMspDySelectFormUserAccess_Result>(Enumerable.Where<CRMspDySelectFormUserAccess_Result>((IEnumerable<CRMspDySelectFormUserAccess_Result>)list2, (Func<CRMspDySelectFormUserAccess_Result, bool>)((CRMspDySelectFormUserAccess_Result c) => c.ParentFormId == 0)));
			List<CRMspDySelectFormUserAccess_Result> list4 = Enumerable.ToList<CRMspDySelectFormUserAccess_Result>(Enumerable.Where<CRMspDySelectFormUserAccess_Result>((IEnumerable<CRMspDySelectFormUserAccess_Result>)list3, (Func<CRMspDySelectFormUserAccess_Result, bool>)((CRMspDySelectFormUserAccess_Result m) => m.CrmSysPartId.HasValue && !m.FOSysPartId.HasValue)));
			if (Enumerable.Any<CRMspDySelectFormUserAccess_Result>((IEnumerable<CRMspDySelectFormUserAccess_Result>)list4))
			{
				List<TreeViewItemModel> list5 = new List<TreeViewItemModel>();
				TreeViewItemModel treeViewItemModel = new TreeViewItemModel();
				treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", "-2|0|-2|-2"));
				treeViewItemModel.Id = "-2|0|-2|-2";
				treeViewItemModel.Text = Labels.DyFrmCrmSysPart;
				treeViewItemModel.ImageUrl = "";
				foreach (CRMspDySelectFormUserAccess_Result item3 in list4)
				{
					TreeViewItemModel mainTree3 = new TreeViewItemModel();
					mainTree3.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", (item3.CrmSysPartId.HasValue ? item3.CrmSysPartId.ToString() : "0") + "|0|-1|-1"));
					mainTree3.Id = (item3.CrmSysPartId.HasValue ? item3.CrmSysPartId.ToString() : "0") + "|0|-1|-1";
					mainTree3.Text = item3.CrmSysPartTitle;
					mainTree3.ImageUrl = "";
					if (Enumerable.FirstOrDefault<TreeViewItemModel>((IEnumerable<TreeViewItemModel>)list5, (Func<TreeViewItemModel, bool>)((TreeViewItemModel m) => m.Id == mainTree3.Id)) != null)
					{
						continue;
					}
					List<CRMspDySelectFormUserAccess_Result> list6 = Enumerable.ToList<CRMspDySelectFormUserAccess_Result>(Enumerable.Where<CRMspDySelectFormUserAccess_Result>((IEnumerable<CRMspDySelectFormUserAccess_Result>)list4, (Func<CRMspDySelectFormUserAccess_Result, bool>)((CRMspDySelectFormUserAccess_Result c) => c.CrmSysPartId == item3.CrmSysPartId)));
					List<TreeViewItemModel> list7 = new List<TreeViewItemModel>();
					foreach (CRMspDySelectFormUserAccess_Result subfrmIn3 in list6)
					{
						TreeViewItemModel treeViewItemModel2 = new TreeViewItemModel();
						treeViewItemModel2.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", (subfrmIn3.CrmSysPartId.HasValue ? subfrmIn3.CrmSysPartId.ToString() : "0") + "|" + (subfrmIn3.FOSysPartId.HasValue ? subfrmIn3.FOSysPartId.ToString() : "0") + "|" + subfrmIn3.ParentFormId + "|" + subfrmIn3.FormId));
						treeViewItemModel2.Id = (subfrmIn3.CrmSysPartId.HasValue ? subfrmIn3.CrmSysPartId.ToString() : "0") + "|" + (subfrmIn3.FOSysPartId.HasValue ? subfrmIn3.FOSysPartId.ToString() : "0") + "|" + subfrmIn3.ParentFormId + "|" + subfrmIn3.FormId;
						treeViewItemModel2.Text = subfrmIn3.FormName;
						treeViewItemModel2.ImageUrl = "";
						List<CRMspDySelectFormUserAccess_Result> list8 = Enumerable.ToList<CRMspDySelectFormUserAccess_Result>(Enumerable.Where<CRMspDySelectFormUserAccess_Result>((IEnumerable<CRMspDySelectFormUserAccess_Result>)list2, (Func<CRMspDySelectFormUserAccess_Result, bool>)((CRMspDySelectFormUserAccess_Result c) => c.ParentFormId == subfrmIn3.FormId)));
						List<TreeViewItemModel> list9 = new List<TreeViewItemModel>();
						foreach (CRMspDySelectFormUserAccess_Result item5 in list8)
						{
							TreeViewItemModel treeViewItemModel3 = new TreeViewItemModel();
							treeViewItemModel3.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", (item5.CrmSysPartId.HasValue ? item5.CrmSysPartId.ToString() : "0") + "|" + (item5.FOSysPartId.HasValue ? item5.FOSysPartId.ToString() : "0") + "|" + item5.ParentFormId + "|" + item5.FormId));
							treeViewItemModel3.Id = (item5.CrmSysPartId.HasValue ? item5.CrmSysPartId.ToString() : "0") + "|" + (item5.FOSysPartId.HasValue ? item5.FOSysPartId.ToString() : "0") + "|" + item5.ParentFormId + "|" + item5.FormId;
							treeViewItemModel3.Text = item5.FormName;
							treeViewItemModel3.ImageUrl = "";
							treeViewItemModel3.Items = null;
							list9.Add(treeViewItemModel3);
						}
						treeViewItemModel2.Items = new List<TreeViewItemModel>(list9);
						list7.Add(treeViewItemModel2);
					}
					mainTree3.Items = new List<TreeViewItemModel>(list7);
					list5.Add(mainTree3);
				}
				treeViewItemModel.Items = new List<TreeViewItemModel>(list5);
				list.Add(treeViewItemModel);
			}
			List<CRMspDySelectFormUserAccess_Result> list10 = Enumerable.ToList<CRMspDySelectFormUserAccess_Result>(Enumerable.Where<CRMspDySelectFormUserAccess_Result>((IEnumerable<CRMspDySelectFormUserAccess_Result>)list3, (Func<CRMspDySelectFormUserAccess_Result, bool>)((CRMspDySelectFormUserAccess_Result m) => !m.CrmSysPartId.HasValue && m.FOSysPartId.HasValue)));
			if (Enumerable.Any<CRMspDySelectFormUserAccess_Result>((IEnumerable<CRMspDySelectFormUserAccess_Result>)list10))
			{
				List<TreeViewItemModel> list11 = new List<TreeViewItemModel>();
				TreeViewItemModel treeViewItemModel4 = new TreeViewItemModel();
				treeViewItemModel4.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", "0|-2|-2|-2"));
				treeViewItemModel4.Id = "0|-2|-2|-2";
				treeViewItemModel4.Text = Labels.DyFrmFOSysPart;
				treeViewItemModel4.ImageUrl = "";
				foreach (CRMspDySelectFormUserAccess_Result item2 in list10)
				{
					TreeViewItemModel mainTree2 = new TreeViewItemModel();
					mainTree2.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", "0|" + (item2.FOSysPartId.HasValue ? item2.FOSysPartId.ToString() : "0") + "|-1|-1"));
					mainTree2.Id = "0|" + (item2.FOSysPartId.HasValue ? item2.FOSysPartId.ToString() : "0") + "|-1|-1";
					mainTree2.Text = item2.FOSysPartTitle;
					mainTree2.ImageUrl = "";
					if (Enumerable.FirstOrDefault<TreeViewItemModel>((IEnumerable<TreeViewItemModel>)list11, (Func<TreeViewItemModel, bool>)((TreeViewItemModel m) => m.Id == mainTree2.Id)) != null)
					{
						continue;
					}
					List<CRMspDySelectFormUserAccess_Result> list12 = Enumerable.ToList<CRMspDySelectFormUserAccess_Result>(Enumerable.Where<CRMspDySelectFormUserAccess_Result>((IEnumerable<CRMspDySelectFormUserAccess_Result>)list10, (Func<CRMspDySelectFormUserAccess_Result, bool>)((CRMspDySelectFormUserAccess_Result c) => c.FOSysPartId == item2.FOSysPartId)));
					List<TreeViewItemModel> list13 = new List<TreeViewItemModel>();
					foreach (CRMspDySelectFormUserAccess_Result subfrmIn2 in list12)
					{
						TreeViewItemModel treeViewItemModel5 = new TreeViewItemModel();
						treeViewItemModel5.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", (subfrmIn2.CrmSysPartId.HasValue ? subfrmIn2.CrmSysPartId.ToString() : "0") + "|" + (subfrmIn2.FOSysPartId.HasValue ? subfrmIn2.FOSysPartId.ToString() : "0") + "|" + subfrmIn2.ParentFormId + "|" + subfrmIn2.FormId));
						treeViewItemModel5.Id = (subfrmIn2.CrmSysPartId.HasValue ? subfrmIn2.CrmSysPartId.ToString() : "0") + "|" + (subfrmIn2.FOSysPartId.HasValue ? subfrmIn2.FOSysPartId.ToString() : "0") + "|" + subfrmIn2.ParentFormId + "|" + subfrmIn2.FormId;
						treeViewItemModel5.Text = subfrmIn2.FormName;
						treeViewItemModel5.ImageUrl = "";
						List<CRMspDySelectFormUserAccess_Result> list14 = Enumerable.ToList<CRMspDySelectFormUserAccess_Result>(Enumerable.Where<CRMspDySelectFormUserAccess_Result>((IEnumerable<CRMspDySelectFormUserAccess_Result>)list2, (Func<CRMspDySelectFormUserAccess_Result, bool>)((CRMspDySelectFormUserAccess_Result c) => c.ParentFormId == subfrmIn2.FormId)));
						List<TreeViewItemModel> list15 = new List<TreeViewItemModel>();
						foreach (CRMspDySelectFormUserAccess_Result item6 in list14)
						{
							TreeViewItemModel treeViewItemModel6 = new TreeViewItemModel();
							treeViewItemModel6.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", (item6.CrmSysPartId.HasValue ? item6.CrmSysPartId.ToString() : "0") + "|" + (item6.FOSysPartId.HasValue ? item6.FOSysPartId.ToString() : "0") + "|" + item6.ParentFormId + "|" + item6.FormId));
							treeViewItemModel6.Id = (item6.CrmSysPartId.HasValue ? item6.CrmSysPartId.ToString() : "0") + "|" + (item6.FOSysPartId.HasValue ? item6.FOSysPartId.ToString() : "0") + "|" + item6.ParentFormId + "|" + item6.FormId;
							treeViewItemModel6.Text = item6.FormName;
							treeViewItemModel6.ImageUrl = "";
							treeViewItemModel6.Items = null;
							list15.Add(treeViewItemModel6);
						}
						treeViewItemModel5.Items = new List<TreeViewItemModel>(list15);
						list13.Add(treeViewItemModel5);
					}
					mainTree2.Items = new List<TreeViewItemModel>(list13);
					list11.Add(mainTree2);
				}
				treeViewItemModel4.Items = new List<TreeViewItemModel>(list11);
				list.Add(treeViewItemModel4);
			}
			List<CRMspDySelectFormUserAccess_Result> list16 = Enumerable.ToList<CRMspDySelectFormUserAccess_Result>(Enumerable.Where<CRMspDySelectFormUserAccess_Result>((IEnumerable<CRMspDySelectFormUserAccess_Result>)list3, (Func<CRMspDySelectFormUserAccess_Result, bool>)((CRMspDySelectFormUserAccess_Result m) => m.CrmSysPartId.HasValue && m.FOSysPartId.HasValue)));
			if (Enumerable.Any<CRMspDySelectFormUserAccess_Result>((IEnumerable<CRMspDySelectFormUserAccess_Result>)list16))
			{
				List<TreeViewItemModel> list17 = new List<TreeViewItemModel>();
				TreeViewItemModel treeViewItemModel7 = new TreeViewItemModel();
				treeViewItemModel7.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", "-2|-2|-2|-2"));
				treeViewItemModel7.Id = "-2|-2|-2|-2";
				treeViewItemModel7.Text = Labels.DyFrmBothSysPart;
				treeViewItemModel7.ImageUrl = "";
				foreach (CRMspDySelectFormUserAccess_Result item in list16)
				{
					TreeViewItemModel mainTree = new TreeViewItemModel();
					mainTree.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", (item.CrmSysPartId.HasValue ? item.CrmSysPartId.ToString() : "0") + "|" + (item.FOSysPartId.HasValue ? item.FOSysPartId.ToString() : "0") + "|-1|-1"));
					mainTree.Id = (item.CrmSysPartId.HasValue ? item.CrmSysPartId.ToString() : "0") + "|" + (item.FOSysPartId.HasValue ? item.FOSysPartId.ToString() : "0") + "|-1|-1";
					mainTree.Text = item.CrmSysPartTitle + "-" + item.FOSysPartTitle;
					mainTree.ImageUrl = "";
					if (Enumerable.FirstOrDefault<TreeViewItemModel>((IEnumerable<TreeViewItemModel>)list17, (Func<TreeViewItemModel, bool>)((TreeViewItemModel m) => m.Id == mainTree.Id)) != null)
					{
						continue;
					}
					List<CRMspDySelectFormUserAccess_Result> list18 = Enumerable.ToList<CRMspDySelectFormUserAccess_Result>(Enumerable.Where<CRMspDySelectFormUserAccess_Result>((IEnumerable<CRMspDySelectFormUserAccess_Result>)list16, (Func<CRMspDySelectFormUserAccess_Result, bool>)((CRMspDySelectFormUserAccess_Result c) => c.FOSysPartId == item.FOSysPartId && c.CrmSysPartId == item.CrmSysPartId)));
					List<TreeViewItemModel> list19 = new List<TreeViewItemModel>();
					foreach (CRMspDySelectFormUserAccess_Result subfrmIn in list18)
					{
						TreeViewItemModel treeViewItemModel8 = new TreeViewItemModel();
						treeViewItemModel8.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", (subfrmIn.CrmSysPartId.HasValue ? subfrmIn.CrmSysPartId.ToString() : "0") + "|" + (subfrmIn.FOSysPartId.HasValue ? subfrmIn.FOSysPartId.ToString() : "0") + "|" + subfrmIn.ParentFormId + "|" + subfrmIn.FormId));
						treeViewItemModel8.Id = (subfrmIn.CrmSysPartId.HasValue ? subfrmIn.CrmSysPartId.ToString() : "0") + "|" + (subfrmIn.FOSysPartId.HasValue ? subfrmIn.FOSysPartId.ToString() : "0") + "|" + subfrmIn.ParentFormId + "|" + subfrmIn.FormId;
						treeViewItemModel8.Text = subfrmIn.FormName;
						treeViewItemModel8.ImageUrl = "";
						List<CRMspDySelectFormUserAccess_Result> list20 = Enumerable.ToList<CRMspDySelectFormUserAccess_Result>(Enumerable.Where<CRMspDySelectFormUserAccess_Result>((IEnumerable<CRMspDySelectFormUserAccess_Result>)list2, (Func<CRMspDySelectFormUserAccess_Result, bool>)((CRMspDySelectFormUserAccess_Result c) => c.ParentFormId == subfrmIn.FormId)));
						List<TreeViewItemModel> list21 = new List<TreeViewItemModel>();
						foreach (CRMspDySelectFormUserAccess_Result item7 in list20)
						{
							TreeViewItemModel treeViewItemModel9 = new TreeViewItemModel();
							treeViewItemModel9.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", (item7.CrmSysPartId.HasValue ? item7.CrmSysPartId.ToString() : "0") + "|" + (item7.FOSysPartId.HasValue ? item7.FOSysPartId.ToString() : "0") + "|" + item7.ParentFormId + "|" + item7.FormId));
							treeViewItemModel9.Id = (item7.CrmSysPartId.HasValue ? item7.CrmSysPartId.ToString() : "0") + "|" + (item7.FOSysPartId.HasValue ? item7.FOSysPartId.ToString() : "0") + "|" + item7.ParentFormId + "|" + item7.FormId;
							treeViewItemModel9.Text = item7.FormName;
							treeViewItemModel9.ImageUrl = "";
							treeViewItemModel9.Items = null;
							list21.Add(treeViewItemModel9);
						}
						treeViewItemModel8.Items = new List<TreeViewItemModel>(list21);
						list19.Add(treeViewItemModel8);
					}
					mainTree.Items = new List<TreeViewItemModel>(list19);
					list17.Add(mainTree);
				}
				treeViewItemModel7.Items = new List<TreeViewItemModel>(list17);
				list.Add(treeViewItemModel7);
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return list;
	}

	[AjaxOnly]
	public ActionResult _PartialLinkedDyFormAccessForUser(int userId)
	{
		try
		{
			base.ViewBag.FormUserAccessTree = GetFormUserAccess(userId);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return PartialView();
	}

	public string InsertFormUserAccess(int crmUserId, int formId)
	{
		string result = "-1";
		try
		{
			int userId = UserLogin.CurrentUser.UserId;
			short value = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			short value2 = short.Parse(Financial.Get().Id.ToString());
			DateTime now = DateTime.Now;
			string registerDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			string appType = Configuration.AppType;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			if (crmUserId != 0 && formId != 0 && db.CRMspDyInsertFormUserAccess(crmUserId, formId, userId, value2, value, now, registerDatePersian, appType, result2) >= 0)
			{
				result = "1";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public string DeleteFormUserAccess(int crmUserId, int formId)
	{
		string result = "-1";
		try
		{
			if (crmUserId != 0 && formId != 0 && db.CRMspDyDeleteFormUserAccess(crmUserId, formId) >= 0)
			{
				result = "1";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public string InsertFormUserAccessAll(int crmUserId)
	{
		string result = "-1";
		try
		{
			int userId = UserLogin.CurrentUser.UserId;
			short value = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			short value2 = short.Parse(Financial.Get().Id.ToString());
			DateTime now = DateTime.Now;
			string registerDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			string appType = Configuration.AppType;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			if (crmUserId != 0 && db.CRMspDyInsertFormUserAccessAll(crmUserId, userId, value2, value, now, registerDatePersian, appType, result2, result3) >= 0)
			{
				result = "1";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public string DeleteFormUserAccessAll(int crmUserId)
	{
		string result = "-1";
		try
		{
			if (crmUserId != 0)
			{
				int result2 = 0;
				if (UserLogin.CurrentUser != null)
				{
					int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
				}
				if (db.CRMspDyDeleteFormUserAccessAll(crmUserId, result2) >= 0)
				{
					result = "1";
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public ActionResult UserBankingAccounts_Read([DataSourceRequest] DataSourceRequest request, int userId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectBankingAccountsByUserId_Result> list = new List<CRMspSelectBankingAccountsByUserId_Result>();
		try
		{
			list = Enumerable.ToList<CRMspSelectBankingAccountsByUserId_Result>((IEnumerable<CRMspSelectBankingAccountsByUserId_Result>)dbI.CRMspSelectBankingAccountsByUserId(userId, lCID, result));
			if (list != null && Enumerable.Any<CRMspSelectBankingAccountsByUserId_Result>((IEnumerable<CRMspSelectBankingAccountsByUserId_Result>)list))
			{
				foreach (CRMspSelectBankingAccountsByUserId_Result item in list)
				{
					if (string.IsNullOrEmpty(item.AppType))
					{
						item.AppType = Configuration.AppType;
					}
					item.AppType = Configuration.GetAppType(item.AppType);
					string text = item.FirstRegisterUser ?? "";
					string text2 = (item.FirstRegisterDate.HasValue ? item.FirstRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
					item.FirstRegisterUser = text + " (" + text2 + ")";
					string text3 = item.EditUser ?? "";
					_ = item.RegisterDate;
					string text4 = item.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
					item.EditUser = text3 + " (" + Labels.AppType + ":" + item.AppType + ")  (" + text4 + ")";
				}
			}
			else
			{
				list = new List<CRMspSelectBankingAccountsByUserId_Result>();
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
	[DynamicAuthorize(ControllerName = "frmDefineUsers", ActionName = "actDeleteBankingAccount")]
	public string BankingAccountDelete(int bankAccId)
	{
		string result = "-1";
		try
		{
			if (bankAccId != 0)
			{
				try
				{
					mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)dbI.CRMspDeleteBankingAccounts(bankAccId));
					int result2 = 0;
					if (mct_I_Result != null)
					{
						int.TryParse(mct_I_Result.Result.ToString(), out result2);
					}
					if (result2 > 0)
					{
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmBankingAccounts");
						result = "1";
					}
					else if (result2 == 0)
					{
						result = Messages.RedundancyMessage;
					}
				}
				catch (DbEntityValidationException e)
				{
					ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
					result = Messages.RedundancyMessage;
				}
				catch (Exception ex)
				{
					ErrorSignal.FromCurrentContext().Raise(ex);
					result = Messages.msgErrorCommunicateWithServer + "<br><p style=text-align:left;>" + ex.Message + "</p>";
				}
			}
			else
			{
				result = Messages.ErrorNotFound;
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			result = Messages.frmErrorMessage;
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "frmDefineUsers", ActionName = "actInsertBankingAccount,actEditBankingAccount")]
	public ActionResult BankingAccountInsertEdit(int crmUserId, int bankAccId = 0)
	{
		_003C_003Ec__DisplayClass163_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass163_0();
		CS_0024_003C_003E8__locals0.bankAccId = bankAccId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		CrmBankingAccountsLanguageViewModel model = new CrmBankingAccountsLanguageViewModel();
		_ = DateTime.Now;
		try
		{
			DbSet<CrmBankingAccounts_Lang> crmBankingAccounts_Lang = _dbTbl.CrmBankingAccounts_Lang;
			ParameterExpression val = Expression.Parameter(typeof(CrmBankingAccounts_Lang), "c");
			List<CrmBankingAccounts_Lang> list = Enumerable.ToList<CrmBankingAccounts_Lang>((IEnumerable<CrmBankingAccounts_Lang>)Queryable.Where<CrmBankingAccounts_Lang>((IQueryable<CrmBankingAccounts_Lang>)crmBankingAccounts_Lang, Expression.Lambda<Func<CrmBankingAccounts_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass163_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
			CrmBankingAccounts crmBankingAccounts = new CrmBankingAccounts();
			if (CS_0024_003C_003E8__locals0.bankAccId == 0)
			{
				if (!UserLogin.IsUserAccess("frmDefineUsers", "actInsertBankingAccount", UserLogin.CurrentUser))
				{
					return RedirectToAction("Login", "Account", (object)new
					{
						area = "",
						d = DateTime.Now
					});
				}
				crmBankingAccounts = new CrmBankingAccounts();
				crmBankingAccounts.BankingAccountID = 0;
				crmBankingAccounts.CrmUserId = crmUserId;
			}
			else
			{
				if (!UserLogin.IsUserAccess("frmDefineUsers", "actEditBankingAccount", UserLogin.CurrentUser))
				{
					return RedirectToAction("Login", "Account", (object)new
					{
						area = "",
						d = DateTime.Now
					});
				}
				DbSet<CrmBankingAccounts> crmBankingAccounts2 = _dbTbl.CrmBankingAccounts;
				val = Expression.Parameter(typeof(CrmBankingAccounts), "m");
				crmBankingAccounts = Queryable.FirstOrDefault<CrmBankingAccounts>((IQueryable<CrmBankingAccounts>)crmBankingAccounts2, Expression.Lambda<Func<CrmBankingAccounts, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass163_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (crmBankingAccounts == null)
				{
					crmBankingAccounts = new CrmBankingAccounts();
					crmBankingAccounts.BankingAccountID = 0;
					crmBankingAccounts.CrmUserId = crmUserId;
				}
			}
			List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmBankingAccounts_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmBankingAccounts_Lang>)list, (Func<CrmBankingAccounts_Lang, CommonMultiLanguageViewModel>)((CrmBankingAccounts_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.AccountTitle,
				LanguageId = item.LanguageID
			})));
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = crmBankingAccounts.AccountTitle,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmBankingAccounts_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmBankingAccounts_Lang>)list, (Func<CrmBankingAccounts_Lang, CommonMultiLanguageViewModel>)((CrmBankingAccounts_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.AccountDesc,
				LanguageId = item.LanguageID
			})));
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = crmBankingAccounts.AccountDesc,
				LanguageId = result
			});
			model = new CrmBankingAccountsLanguageViewModel
			{
				BankingAccountID = crmBankingAccounts.BankingAccountID,
				BranchId = crmBankingAccounts.BranchId,
				MasterId = crmBankingAccounts.MasterId,
				AccTypeId = crmBankingAccounts.AccTypeId,
				AccountNumber = crmBankingAccounts.AccountNumber,
				AccountType = crmBankingAccounts.AccountType,
				AccountOwner = crmBankingAccounts.AccountOwner,
				CrmUserId = crmBankingAccounts.CrmUserId,
				BankId = crmBankingAccounts.BankId,
				AccountShabaNumber = crmBankingAccounts.AccountShabaNumber,
				AccountCardNumber = crmBankingAccounts.AccountCardNumber,
				IsDefault = crmBankingAccounts.IsDefault,
				IsDefaultII = crmBankingAccounts.IsDefaultII,
				AccountTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				AccountTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				AccountDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				AccountDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				MobHRMVisible = crmBankingAccounts.MobHRMVisible
			};
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View(model);
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmDefineUsers", ActionName = "actInsertBankingAccount,actEditBankingAccount")]
	public ActionResult BankingAccountInsertEdit(CrmBankingAccountsLanguageViewModel model)
	{
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass164_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass164_0();
		CS_0024_003C_003E8__locals0.model = model;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int num = 0;
		if (base.ModelState.IsValid)
		{
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.AccountTitle_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.AccountTitle_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.model.AccountTitle,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.AccountDesc_Lang))
			{
				list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.AccountDesc_Lang);
			}
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.model.AccountDesc,
				LanguageId = lCID
			});
			if (string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.model.AccountTitle))
			{
				text = text + string.Format(Messages.ErrorEmpty, Labels.BankingAccountTitle) + "<br/>";
				num++;
			}
			else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.model.AccountTitle, list))
			{
				text = text + string.Format(Messages.CheckFieldInLang, Labels.BankingAccountTitle) + "<br>";
				num++;
			}
			bool result = false;
			bool.TryParse(CS_0024_003C_003E8__locals0.model.IsDefault.ToString(), out result);
			if (result)
			{
				CRMspSelectUserBankingAccountIsDefault_Result cRMspSelectUserBankingAccountIsDefault_Result = Enumerable.FirstOrDefault<CRMspSelectUserBankingAccountIsDefault_Result>((IEnumerable<CRMspSelectUserBankingAccountIsDefault_Result>)dbI.CRMspSelectUserBankingAccountIsDefault(CS_0024_003C_003E8__locals0.model.CrmUserId, lCID, CS_0024_003C_003E8__locals0.defLangID));
				if (cRMspSelectUserBankingAccountIsDefault_Result != null && cRMspSelectUserBankingAccountIsDefault_Result.BankingAccountID != CS_0024_003C_003E8__locals0.model.BankingAccountID)
				{
					string arg = cRMspSelectUserBankingAccountIsDefault_Result.AccountTitle ?? "";
					text = text + string.Format(Messages.msgErrorBankAccIsDefault, arg) + "<br>";
					num++;
				}
			}
			bool result2 = false;
			bool.TryParse(CS_0024_003C_003E8__locals0.model.IsDefaultII.ToString(), out result2);
			if (result2)
			{
				CRMspSelectUserBankingAccountIsDefaultII_Result cRMspSelectUserBankingAccountIsDefaultII_Result = Enumerable.FirstOrDefault<CRMspSelectUserBankingAccountIsDefaultII_Result>((IEnumerable<CRMspSelectUserBankingAccountIsDefaultII_Result>)dbI.CRMspSelectUserBankingAccountIsDefaultII(CS_0024_003C_003E8__locals0.model.CrmUserId, lCID, CS_0024_003C_003E8__locals0.defLangID));
				if (cRMspSelectUserBankingAccountIsDefaultII_Result != null && cRMspSelectUserBankingAccountIsDefaultII_Result.BankingAccountID != CS_0024_003C_003E8__locals0.model.BankingAccountID)
				{
					string arg2 = cRMspSelectUserBankingAccountIsDefaultII_Result.AccountTitle ?? "";
					text = text + string.Format(Messages.msgErrorBankAccIsDefaultII, arg2) + "<br>";
					num++;
				}
			}
			if (CS_0024_003C_003E8__locals0.model.BranchId == 0)
			{
				text = text + string.Format(Messages.msgErrorIsNotSelectedItem, Labels.BankingAccountBranch) + "<br>";
				num++;
			}
			if (CS_0024_003C_003E8__locals0.model.AccTypeId == 0)
			{
				text = text + string.Format(Messages.msgErrorIsNotSelectedItem, Labels.BankingAccountType) + "<br>";
				num++;
			}
			if (num == 0)
			{
				DateTime now = DateTime.Now;
				try
				{
					_003C_003Ec__DisplayClass164_1 _003C_003Ec__DisplayClass164_ = new _003C_003Ec__DisplayClass164_1();
					_003C_003Ec__DisplayClass164_.bankAcc = new CrmBankingAccounts();
					if (CS_0024_003C_003E8__locals0.model.BankingAccountID > 0)
					{
						DbSet<CrmBankingAccounts> crmBankingAccounts = _dbTbl.CrmBankingAccounts;
						ParameterExpression val = Expression.Parameter(typeof(CrmBankingAccounts), "m");
						_003C_003Ec__DisplayClass164_.bankAcc = Queryable.FirstOrDefault<CrmBankingAccounts>((IQueryable<CrmBankingAccounts>)crmBankingAccounts, Expression.Lambda<Func<CrmBankingAccounts, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass164_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
					}
					DateTime now2 = DateTime.Now;
					DateTime registerDate = now2;
					string registerDatePersian = now2.ToString("yyyyMMdd", new PersianCulture());
					short month = short.Parse(now2.ToString("MM", new PersianCulture()));
					string appType = Configuration.AppType;
					_ = Financial.Get().Id;
					int userId = UserLogin.CurrentUser.UserId;
					short year = short.Parse(Financial.Get().Id.ToString());
					_003C_003Ec__DisplayClass164_.bankAcc.UserId = userId;
					_003C_003Ec__DisplayClass164_.bankAcc.RegisterDate = registerDate;
					_003C_003Ec__DisplayClass164_.bankAcc.RegisterDatePersian = registerDatePersian;
					_003C_003Ec__DisplayClass164_.bankAcc.Month1 = month;
					_003C_003Ec__DisplayClass164_.bankAcc.Year1 = year;
					_003C_003Ec__DisplayClass164_.bankAcc.AppType = appType;
					_003C_003Ec__DisplayClass164_.bankAcc.BranchId = CS_0024_003C_003E8__locals0.model.BranchId;
					_003C_003Ec__DisplayClass164_.bankAcc.MasterId = CS_0024_003C_003E8__locals0.model.MasterId;
					_003C_003Ec__DisplayClass164_.bankAcc.AccTypeId = CS_0024_003C_003E8__locals0.model.AccTypeId;
					_003C_003Ec__DisplayClass164_.bankAcc.AccountNumber = CS_0024_003C_003E8__locals0.model.AccountNumber;
					_003C_003Ec__DisplayClass164_.bankAcc.AccountType = CS_0024_003C_003E8__locals0.model.AccountType;
					_003C_003Ec__DisplayClass164_.bankAcc.AccountOwner = CS_0024_003C_003E8__locals0.model.AccountOwner;
					_003C_003Ec__DisplayClass164_.bankAcc.CrmUserId = CS_0024_003C_003E8__locals0.model.CrmUserId;
					_003C_003Ec__DisplayClass164_.bankAcc.BankId = CS_0024_003C_003E8__locals0.model.BankId;
					_003C_003Ec__DisplayClass164_.bankAcc.AccountShabaNumber = CS_0024_003C_003E8__locals0.model.AccountShabaNumber;
					_003C_003Ec__DisplayClass164_.bankAcc.AccountCardNumber = CS_0024_003C_003E8__locals0.model.AccountCardNumber;
					_003C_003Ec__DisplayClass164_.bankAcc.IsDefault = CS_0024_003C_003E8__locals0.model.IsDefault;
					_003C_003Ec__DisplayClass164_.bankAcc.IsDefaultII = CS_0024_003C_003E8__locals0.model.IsDefaultII;
					_003C_003Ec__DisplayClass164_.bankAcc.AccountTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					_003C_003Ec__DisplayClass164_.bankAcc.AccountDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					_003C_003Ec__DisplayClass164_.bankAcc.MobHRMVisible = CS_0024_003C_003E8__locals0.model.MobHRMVisible;
					if (CS_0024_003C_003E8__locals0.model.BankingAccountID > 0)
					{
						_dbTbl.Entry(_003C_003Ec__DisplayClass164_.bankAcc).State = EntityState.Modified;
						_dbTbl.SaveChanges();
						using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								_003C_003Ec__DisplayClass164_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass164_2();
								CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass164_;
								CS_0024_003C_003E8__locals1.lang = enumerator.Current;
								DbSet<CrmBankingAccounts_Lang> crmBankingAccounts_Lang = _dbTbl.CrmBankingAccounts_Lang;
								ParameterExpression val = Expression.Parameter(typeof(CrmBankingAccounts_Lang), "c");
								CrmBankingAccounts_Lang crmBankingAccounts_Lang2 = Queryable.FirstOrDefault<CrmBankingAccounts_Lang>((IQueryable<CrmBankingAccounts_Lang>)crmBankingAccounts_Lang, Expression.Lambda<Func<CrmBankingAccounts_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass164_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass164_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
								if (crmBankingAccounts_Lang2 != null)
								{
									crmBankingAccounts_Lang2.AccountTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									crmBankingAccounts_Lang2.AccountDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									_dbTbl.Entry(crmBankingAccounts_Lang2).State = EntityState.Modified;
									_dbTbl.SaveChanges();
									continue;
								}
								crmBankingAccounts_Lang2 = new CrmBankingAccounts_Lang
								{
									LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID,
									BankingAccountID = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.bankAcc.BankingAccountID,
									AccountTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
									AccountDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null)
								};
								_dbTbl.CrmBankingAccounts_Lang.Add(crmBankingAccounts_Lang2);
								_dbTbl.SaveChanges();
							}
						}
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmBankingAccounts");
						base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
					}
					else
					{
						_003C_003Ec__DisplayClass164_.bankAcc.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
						_003C_003Ec__DisplayClass164_.bankAcc.FirstRegisterDate = now;
						_003C_003Ec__DisplayClass164_.bankAcc.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						_003C_003Ec__DisplayClass164_.bankAcc.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
						_003C_003Ec__DisplayClass164_.bankAcc.GUId = System.Guid.NewGuid();
						_dbTbl.CrmBankingAccounts.Add(_003C_003Ec__DisplayClass164_.bankAcc);
						_dbTbl.SaveChanges();
						if (_003C_003Ec__DisplayClass164_.bankAcc.BankingAccountID > 0)
						{
							foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
							{
								CrmBankingAccounts_Lang entity = new CrmBankingAccounts_Lang
								{
									LanguageID = lang.LanguageID,
									BankingAccountID = _003C_003Ec__DisplayClass164_.bankAcc.BankingAccountID,
									AccountTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
									AccountDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null)
								};
								_dbTbl.CrmBankingAccounts_Lang.Add(entity);
								_dbTbl.SaveChanges();
							}
						}
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmBankingAccounts");
						base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
					text = Messages.msgErrorRunFunction;
				}
			}
		}
		if (text != "")
		{
			base.ViewBag.Error = text;
		}
		return View(CS_0024_003C_003E8__locals0.model);
	}

	[AjaxOnly]
	public JsonResult GetBankingBankLists()
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
			List<CRMspSelectBankingBanks_Result> list2 = Enumerable.ToList<CRMspSelectBankingBanks_Result>((IEnumerable<CRMspSelectBankingBanks_Result>)dbI.CRMspSelectBankingBanks(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectBankingBanks_Result, SelectListItem>((IEnumerable<CRMspSelectBankingBanks_Result>)list2, (Func<CRMspSelectBankingBanks_Result, SelectListItem>)((CRMspSelectBankingBanks_Result item) => new SelectListItem
			{
				Text = (item.BankName ?? ""),
				Value = item.BankingBankID.ToString(),
				Selected = false
			})));
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
	public JsonResult GetBankingBrancheLists(int bankId)
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
			List<CRMspSelectBankingBranches_Result> list2 = Enumerable.ToList<CRMspSelectBankingBranches_Result>((IEnumerable<CRMspSelectBankingBranches_Result>)dbI.CRMspSelectBankingBranches(bankId, lCID, result));
			SelectListItem item2 = new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "0"
			};
			list.Add(item2);
			list.AddRange(Enumerable.Select<CRMspSelectBankingBranches_Result, SelectListItem>((IEnumerable<CRMspSelectBankingBranches_Result>)list2, (Func<CRMspSelectBankingBranches_Result, SelectListItem>)((CRMspSelectBankingBranches_Result item) => new SelectListItem
			{
				Text = (item.BranchName ?? ""),
				Value = item.BankingBranchID.ToString(),
				Selected = false
			})));
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
	public JsonResult GetBankingAccountTypeLists()
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
			List<CRMspSelectBankingAccountType_Result> list2 = Enumerable.ToList<CRMspSelectBankingAccountType_Result>((IEnumerable<CRMspSelectBankingAccountType_Result>)dbI.CRMspSelectBankingAccountType(lCID, result));
			SelectListItem item2 = new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "0"
			};
			list.Add(item2);
			list.AddRange(Enumerable.Select<CRMspSelectBankingAccountType_Result, SelectListItem>((IEnumerable<CRMspSelectBankingAccountType_Result>)list2, (Func<CRMspSelectBankingAccountType_Result, SelectListItem>)((CRMspSelectBankingAccountType_Result item) => new SelectListItem
			{
				Text = (item.AccountType ?? ""),
				Value = item.BankingAccountTypeID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[DynamicAuthorize(ControllerName = "frmDefineUsers", ActionName = "actManageMobDevices,actManageHRMDevices,actManageCICDevices")]
	public ActionResult UserAppDeviceInfoList(int userId = 0, string appName = "")
	{
		base.ViewBag.UserId = userId;
		base.ViewBag.AppName = appName;
		return View();
	}

	[AjaxOnly]
	public JsonResult UserAppDeviceInfoList_List(int? userId = 0, string appName = "")
	{
		List<CRMspSelectUserAppDeviceInfoByUserId_Result> list = new List<CRMspSelectUserAppDeviceInfoByUserId_Result>();
		try
		{
			appName = (((appName ?? "") == "") ? "Empty" : appName);
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			foreach (CRMspSelectUserAppDeviceInfoByUserId_Result item in Enumerable.ToList<CRMspSelectUserAppDeviceInfoByUserId_Result>((IEnumerable<CRMspSelectUserAppDeviceInfoByUserId_Result>)dbI.CRMspSelectUserAppDeviceInfoByUserId(userId, appName)))
			{
				item.RegisterDatePersian = ((!item.RegisterDate.HasValue) ? null : item.RegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss"));
				if (!string.IsNullOrEmpty(item.DeviceProperty))
				{
					UserAppDevicePropertyViewModel userAppDevicePropertyViewModel = JsonConvert.DeserializeObject<UserAppDevicePropertyViewModel>(item.DeviceProperty);
					string text = userAppDevicePropertyViewModel.devName;
					if (!string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(userAppDevicePropertyViewModel.devVer))
					{
						text = text + " - " + userAppDevicePropertyViewModel.devVer;
					}
					item.DeviceProperty = text;
				}
				list.Add(item);
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
	public JsonResult DeleteUserAppDeviceInfo(int uaId = 0)
	{
		CommonReturnResultViewModel commonReturnResultViewModel = new CommonReturnResultViewModel();
		commonReturnResultViewModel.IsDone = false;
		commonReturnResultViewModel.MessageExtra = "";
		int num = 0;
		try
		{
			CRMSpIEntities cRMSpIEntities = new CRMSpIEntities();
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMSpIEntities.CRMspDeleteUserAppDeviceInfoById(uaId)).GetValueOrDefault() == 1)
			{
				commonReturnResultViewModel.IsDone = true;
				commonReturnResultViewModel.Message = Messages.msgSuccessAction;
			}
			else
			{
				num++;
				commonReturnResultViewModel.IsDone = false;
				commonReturnResultViewModel.Message = Messages.msgErrorRunFunction;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			commonReturnResultViewModel.IsDone = false;
			commonReturnResultViewModel.Message = Messages.msgErrorRunFunction;
		}
		JsonResult jsonResult = Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult DeactiveUserAppDeviceInfo(int uaId = 0)
	{
		CommonReturnResultViewModel commonReturnResultViewModel = new CommonReturnResultViewModel();
		commonReturnResultViewModel.IsDone = false;
		commonReturnResultViewModel.MessageExtra = "";
		try
		{
			CRMSpIEntities cRMSpIEntities = new CRMSpIEntities();
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			DateTime value = now;
			cRMSpIEntities.CRMspDeactiveUserAppDeviceInfo(registerDatePersian: now.ToString("yyyyMMdd", new PersianCulture()), appType: Configuration.AppType, userAppDeviceInfoId: uaId, registerDate: value);
			commonReturnResultViewModel.IsDone = true;
			commonReturnResultViewModel.Message = Messages.msgSuccessAction;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			commonReturnResultViewModel.IsDone = false;
			commonReturnResultViewModel.Message = Messages.msgErrorRunFunction;
		}
		JsonResult jsonResult = Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}
}
