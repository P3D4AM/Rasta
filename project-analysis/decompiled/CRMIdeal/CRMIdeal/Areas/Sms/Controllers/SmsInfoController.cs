using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
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
using CRM.OtherWebServices.SmsNimadd;
using CRM.OtherWebServices.SmsSunWay;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Cache.User;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using CRMIdeal.SmsAfzar;
using CRMIdeal.SmsFaraPayamak;
using CRMIdeal.SmsFor;
using CRMIdeal.SmsKaveNegar;
using CRMIdeal.SmsTehranPayamak;
using CRMIdeal.SmsWebOne;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Sms.Controllers;

public class SmsInfoController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass13_0
	{
		public int smsProviderId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass23_0
	{
		public int treeKeyid;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass40_0
	{
		public int creditId;

		public int currLangID;

		internal bool _003CSmsUserSendCreditEdit_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CSmsUserSendCreditEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CSmsUserSendCreditEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass41_0
	{
		public SmsUserSendCreditLanguageViewModel vm;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__3;

		internal bool _003CSmsUserSendCreditEdit_003Eb__1(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CSmsUserSendCreditEdit_003Eb__2(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CSmsUserSendCreditEdit_003Eb__3(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass41_1
	{
		public SmsUserSendCredit model;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass41_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass41_1 CS_0024_003C_003E8__locals1;

		internal bool _003CSmsUserSendCreditEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSmsUserSendCreditEdit_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSmsUserSendCreditEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSmsUserSendCreditEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass42_0
	{
		public int creditId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass48_0
	{
		public int smsDetTextId;

		public int currLangID;

		internal bool _003CSmsDefaultBodyTextEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CSmsDefaultBodyTextEdit_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CSmsDefaultBodyTextEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CSmsDefaultBodyTextEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CSmsDefaultBodyTextEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CSmsDefaultBodyTextEdit_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CSmsDefaultBodyTextEdit_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CSmsDefaultBodyTextEdit_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CSmsDefaultBodyTextEdit_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass49_0
	{
		public SmsDefaultBodyTextLanguageViewModel vm;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__7;

		internal bool _003CSmsDefaultBodyTextEdit_003Eb__1(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CSmsDefaultBodyTextEdit_003Eb__2(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CSmsDefaultBodyTextEdit_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CSmsDefaultBodyTextEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CSmsDefaultBodyTextEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CSmsDefaultBodyTextEdit_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CSmsDefaultBodyTextEdit_003Eb__7(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass49_1
	{
		public SmsDefaultBodyText model;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass49_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass49_1 CS_0024_003C_003E8__locals1;

		internal bool _003CSmsDefaultBodyTextEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSmsDefaultBodyTextEdit_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSmsDefaultBodyTextEdit_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSmsDefaultBodyTextEdit_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSmsDefaultBodyTextEdit_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSmsDefaultBodyTextEdit_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSmsDefaultBodyTextEdit_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSmsDefaultBodyTextEdit_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSmsDefaultBodyTextEdit_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSmsDefaultBodyTextEdit_003Eb__18(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSmsDefaultBodyTextEdit_003Eb__19(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSmsDefaultBodyTextEdit_003Eb__20(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass50_0
	{
		public int smsDetTextId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass67_0
	{
		public int smsDetId;
	}

	private readonly object _objLock = "";

	private CRMSpEntities db = new CRMSpEntities();

	private CRMSpIEntities dbI = new CRMSpIEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[HttpGet]
	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actSendSms")]
	public ActionResult Index()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		lock (_objLock)
		{
			if (base.TempData["mydata"] != null && base.TempData["mydata"].ToString() != "")
			{
				text = base.TempData["mydata"].ToString();
				base.TempData["mydata"] = "";
			}
		}
		string text2 = "";
		SmsSendViewModel smsSendViewModel = new SmsSendViewModel();
		if (!string.IsNullOrEmpty(text))
		{
			text = text.Replace("\n", "%!%").Replace("\r", "%@%");
			List<SelectListItem> list = JsonConvert.DeserializeObject<List<SelectListItem>>(text);
			bool.TryParse(Enumerable.FirstOrDefault<SelectListItem>(Enumerable.Where<SelectListItem>((IEnumerable<SelectListItem>)list, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "SendWithName"))).Value, out var result2);
			smsSendViewModel.SendWithName = result2;
			int.TryParse(Enumerable.FirstOrDefault<SelectListItem>(Enumerable.Where<SelectListItem>((IEnumerable<SelectListItem>)list, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "SmsBodyCount"))).Value, out var result3);
			smsSendViewModel.SmsBodyCount = result3;
			int.TryParse(Enumerable.FirstOrDefault<SelectListItem>(Enumerable.Where<SelectListItem>((IEnumerable<SelectListItem>)list, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "SmsbodyCost"))).Value, out var result4);
			smsSendViewModel.SmsbodyCost = result4;
			string text3 = Enumerable.FirstOrDefault<SelectListItem>(Enumerable.Where<SelectListItem>((IEnumerable<SelectListItem>)list, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "SmsSendBody"))).Value;
			string[] array = ((!string.IsNullOrEmpty(text3)) ? text3.Split(new char[1] { '-' }) : null);
			if (array != null)
			{
				if (Enumerable.Any<string>((IEnumerable<string>)array))
				{
					for (int i = 0; i < array.Length; i++)
					{
						if (!string.IsNullOrEmpty(array[i]))
						{
							array[i] = array[i].Replace("_pordNum_", "-");
							array[i] = array[i].Replace("_DASH_", "-");
						}
					}
				}
				text3 = "";
				text3 = Enumerable.Aggregate<string, string>((IEnumerable<string>)array, text3, (Func<string, string, string>)((string current, string item) => current + item + Environment.NewLine));
			}
			if (!string.IsNullOrEmpty(text3))
			{
				text3 = text3.Replace("%!%", "\n").Replace("%@%", "\r").Replace("%_%", "-");
			}
			smsSendViewModel.SmsSendBody = text3;
			bool.TryParse(Enumerable.FirstOrDefault<SelectListItem>(Enumerable.Where<SelectListItem>((IEnumerable<SelectListItem>)list, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "SmsReadOnlyBody"))).Value, out var result5);
			smsSendViewModel.SmsReadOnlyBody = result5;
			int.TryParse(Enumerable.FirstOrDefault<SelectListItem>(Enumerable.Where<SelectListItem>((IEnumerable<SelectListItem>)list, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "AllWnBodyCount"))).Value, out var result6);
			smsSendViewModel.AllWnBodyCount = result6;
			decimal result7 = default(decimal);
			decimal.TryParse(Enumerable.FirstOrDefault<SelectListItem>(Enumerable.Where<SelectListItem>((IEnumerable<SelectListItem>)list, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "AllWnBodyCost"))).Value, out result7);
			smsSendViewModel.AllWnBodyCost = result7;
			smsSendViewModel.SmsSendTopic = Enumerable.FirstOrDefault<SelectListItem>(Enumerable.Where<SelectListItem>((IEnumerable<SelectListItem>)list, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "SmsSendTopic"))).Value;
			int.TryParse(Enumerable.FirstOrDefault<SelectListItem>(Enumerable.Where<SelectListItem>((IEnumerable<SelectListItem>)list, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "SmsNumberCount"))).Value, out var result8);
			smsSendViewModel.SmsNumberCount = result8;
			smsSendViewModel.Numbers = Enumerable.FirstOrDefault<SelectListItem>(Enumerable.Where<SelectListItem>((IEnumerable<SelectListItem>)list, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "Numbers"))).Value;
			if (!smsSendViewModel.Numbers.Contains(","))
			{
				smsSendViewModel.SmsToNumber = smsSendViewModel.Numbers;
			}
			smsSendViewModel.CompaniesId = Enumerable.FirstOrDefault<SelectListItem>(Enumerable.Where<SelectListItem>((IEnumerable<SelectListItem>)list, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "CompaniesId"))).Value;
			smsSendViewModel.CompanyPersonsId = Enumerable.FirstOrDefault<SelectListItem>(Enumerable.Where<SelectListItem>((IEnumerable<SelectListItem>)list, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "CompanyPersonsId"))).Value;
			int.TryParse(Enumerable.FirstOrDefault<SelectListItem>(Enumerable.Where<SelectListItem>((IEnumerable<SelectListItem>)list, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "SmsMode"))).Value, out var result9);
			smsSendViewModel.SmsMode = result9;
			text2 = Enumerable.FirstOrDefault<SelectListItem>(Enumerable.Where<SelectListItem>((IEnumerable<SelectListItem>)list, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "FirstTemplateBody"))).Value;
			if (Enumerable.Count<SelectListItem>((IEnumerable<SelectListItem>)list) >= 14)
			{
				bool result10 = false;
				bool.TryParse(Enumerable.FirstOrDefault<SelectListItem>(Enumerable.Where<SelectListItem>((IEnumerable<SelectListItem>)list, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "HavePassword"))).Value, out result10);
				smsSendViewModel.HavePassword = result10;
				int result11 = 0;
				int.TryParse(smsSendViewModel.CompaniesId, out result11);
				CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(result11);
				if (companyById != null && !string.IsNullOrEmpty(companyById.cmpPassword))
				{
					smsSendViewModel.Password = companyById.cmpPassword;
				}
				else
				{
					smsSendViewModel.Password = Enumerable.FirstOrDefault<SelectListItem>(Enumerable.Where<SelectListItem>((IEnumerable<SelectListItem>)list, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "Password"))).Value;
				}
			}
			else
			{
				smsSendViewModel.HavePassword = false;
				smsSendViewModel.Password = "";
			}
			if (Enumerable.Count<SelectListItem>((IEnumerable<SelectListItem>)list) >= 17)
			{
				int result12 = 0;
				int.TryParse(Enumerable.FirstOrDefault<SelectListItem>(Enumerable.Where<SelectListItem>((IEnumerable<SelectListItem>)list, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "FromPage"))).Value, out result12);
				if (result12 == 1)
				{
					smsSendViewModel.FromPage = result12;
					int result13 = 0;
					int.TryParse(smsSendViewModel.CompaniesId, out result13);
					if (result13 > 0)
					{
						List<CRMspSelectCompanyPersonsMobile_Result> list2 = Enumerable.ToList<CRMspSelectCompanyPersonsMobile_Result>(Enumerable.Where<CRMspSelectCompanyPersonsMobile_Result>((IEnumerable<CRMspSelectCompanyPersonsMobile_Result>)dbI.CRMspSelectCompanyPersonsMobile(result13, UserLogin.CurrentUser.UserId, lCID, result), (Func<CRMspSelectCompanyPersonsMobile_Result, bool>)((CRMspSelectCompanyPersonsMobile_Result x) => !string.IsNullOrWhiteSpace(x.prsMobile))));
						List<SelectListItem> list3 = new List<SelectListItem>();
						if (list2 != null && list2.Count > 0)
						{
							foreach (CRMspSelectCompanyPersonsMobile_Result item in list2)
							{
								list3.Add(new SelectListItem
								{
									Text = item.PrsNameWithCompany + ((!string.IsNullOrWhiteSpace(item.prsMobile)) ? ("(" + item.prsMobile + ")") : ""),
									Value = item.CompanyPersonID.ToString(),
									Selected = ((!string.IsNullOrWhiteSpace(item.prsMobile) && item.prsMobile == smsSendViewModel.Numbers) ? true : false)
								});
							}
						}
						base.ViewBag.CompanyPersonsNumbersListJs = JsonConvert.SerializeObject(list2);
						base.ViewBag.CompanyPersonsNumbersList = list3;
					}
				}
				else
				{
					_ = 2;
				}
			}
			if (Enumerable.Count<SelectListItem>((IEnumerable<SelectListItem>)list) >= 18)
			{
				bool result14 = false;
				bool.TryParse(Enumerable.FirstOrDefault<SelectListItem>(Enumerable.Where<SelectListItem>((IEnumerable<SelectListItem>)list, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "SmsNumberReadOnly"))).Value, out result14);
				smsSendViewModel.SmsNumberReadOnly = result14;
			}
			else
			{
				smsSendViewModel.SmsNumberReadOnly = false;
			}
		}
		base.ViewBag.PrString = text;
		base.ViewBag.FirstBodyTemp = text2;
		FillDropdownSmsSend();
		base.ViewBag.IsBuying = VersionBuyer.SMS;
		dynamic viewBag = base.ViewBag;
		DbSet<SmsSendDetail> smsSendDetail = _dbTbl.SmsSendDetail;
		ParameterExpression val = Expression.Parameter(typeof(SmsSendDetail), "c");
		viewBag.IsBuyingCount = Queryable.Any<SmsSendDetail>((IQueryable<SmsSendDetail>)smsSendDetail, Expression.Lambda<Func<SmsSendDetail, bool>>((Expression)(object)Expression.GreaterThan((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)50, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
		return View(smsSendViewModel);
	}

	[HttpGet]
	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actSendSms")]
	public ActionResult Index_Old()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		lock (_objLock)
		{
			if (base.TempData["mydata"] != null && base.TempData["mydata"].ToString() != "")
			{
				text = base.TempData["mydata"].ToString();
				base.TempData["mydata"] = "";
			}
		}
		string text2 = "";
		SmsSendViewModel smsSendViewModel = new SmsSendViewModel();
		if (!string.IsNullOrEmpty(text))
		{
			text = text.Replace("\n", "%!%").Replace("\r", "%@%");
			string[] array = text.Split(new char[1] { '|' });
			bool.TryParse(array[0], out var result2);
			smsSendViewModel.SendWithName = result2;
			int.TryParse(array[1], out var result3);
			smsSendViewModel.SmsBodyCount = result3;
			int.TryParse(array[2], out result3);
			smsSendViewModel.SmsbodyCost = result3;
			string text3 = array[3];
			string[] array2 = ((!string.IsNullOrEmpty(text3)) ? text3.Split(new char[1] { '-' }) : null);
			if (array2 != null)
			{
				if (Enumerable.Any<string>((IEnumerable<string>)array2))
				{
					for (int i = 0; i < array2.Length; i++)
					{
						if (!string.IsNullOrEmpty(array2[i]))
						{
							array2[i] = array2[i].Replace("_pordNum_", "-");
						}
					}
				}
				text3 = "";
				text3 = Enumerable.Aggregate<string, string>((IEnumerable<string>)array2, text3, (Func<string, string, string>)((string current, string item) => current + item + Environment.NewLine));
			}
			if (!string.IsNullOrEmpty(text3))
			{
				text3 = text3.Replace("%!%", "\n").Replace("%@%", "\r");
			}
			smsSendViewModel.SmsSendBody = text3;
			bool.TryParse(array[4], out result2);
			smsSendViewModel.SmsReadOnlyBody = result2;
			int.TryParse(array[5], out result3);
			smsSendViewModel.AllWnBodyCount = result3;
			decimal result4 = default(decimal);
			decimal.TryParse(array[6], out result4);
			smsSendViewModel.AllWnBodyCost = result4;
			smsSendViewModel.SmsSendTopic = array[7];
			int.TryParse(array[8], out result3);
			smsSendViewModel.SmsNumberCount = result3;
			smsSendViewModel.Numbers = array[9];
			smsSendViewModel.CompaniesId = array[10];
			smsSendViewModel.CompanyPersonsId = array[11];
			int.TryParse(array[12], out result3);
			smsSendViewModel.SmsMode = result3;
			text2 = array[13];
			if (Enumerable.Count<string>((IEnumerable<string>)array) >= 14)
			{
				bool result5 = false;
				bool.TryParse(array[14], out result5);
				smsSendViewModel.HavePassword = result5;
				smsSendViewModel.Password = array[15];
			}
			else
			{
				smsSendViewModel.HavePassword = false;
				smsSendViewModel.Password = "";
			}
			if (Enumerable.Count<string>((IEnumerable<string>)array) >= 17)
			{
				int result6 = 0;
				int.TryParse(array[16], out result6);
				if (result6 == 1)
				{
					smsSendViewModel.FromPage = result6;
					int result7 = 0;
					int.TryParse(smsSendViewModel.CompaniesId, out result7);
					if (result7 > 0)
					{
						List<CRMspSelectCompanyPersonsMobile_Result> list = Enumerable.ToList<CRMspSelectCompanyPersonsMobile_Result>(Enumerable.Where<CRMspSelectCompanyPersonsMobile_Result>((IEnumerable<CRMspSelectCompanyPersonsMobile_Result>)dbI.CRMspSelectCompanyPersonsMobile(result7, UserLogin.CurrentUser.UserId, lCID, result), (Func<CRMspSelectCompanyPersonsMobile_Result, bool>)((CRMspSelectCompanyPersonsMobile_Result x) => !string.IsNullOrWhiteSpace(x.prsMobile))));
						List<SelectListItem> list2 = new List<SelectListItem>();
						if (list != null && list.Count > 0)
						{
							foreach (CRMspSelectCompanyPersonsMobile_Result item in list)
							{
								list2.Add(new SelectListItem
								{
									Text = item.PrsNameWithCompany + ((!string.IsNullOrWhiteSpace(item.prsMobile)) ? ("(" + item.prsMobile + ")") : ""),
									Value = item.CompanyPersonID.ToString(),
									Selected = ((!string.IsNullOrWhiteSpace(item.prsMobile) && item.prsMobile == smsSendViewModel.Numbers) ? true : false)
								});
							}
						}
						base.ViewBag.CompanyPersonsNumbersListJs = JsonConvert.SerializeObject(list);
						base.ViewBag.CompanyPersonsNumbersList = list2;
					}
				}
				else
				{
					_ = 2;
				}
			}
			if (Enumerable.Count<string>((IEnumerable<string>)array) >= 18)
			{
				bool result8 = false;
				bool.TryParse(array[17], out result8);
				smsSendViewModel.SmsNumberReadOnly = result8;
			}
			else
			{
				smsSendViewModel.SmsNumberReadOnly = false;
			}
		}
		base.ViewBag.PrString = text;
		base.ViewBag.FirstBodyTemp = text2;
		FillDropdownSmsSend();
		base.ViewBag.IsBuying = VersionBuyer.SMS;
		dynamic viewBag = base.ViewBag;
		DbSet<SmsSendDetail> smsSendDetail = _dbTbl.SmsSendDetail;
		ParameterExpression val = Expression.Parameter(typeof(SmsSendDetail), "c");
		viewBag.IsBuyingCount = Queryable.Any<SmsSendDetail>((IQueryable<SmsSendDetail>)smsSendDetail, Expression.Lambda<Func<SmsSendDetail, bool>>((Expression)(object)Expression.GreaterThan((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)50, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
		return View(smsSendViewModel);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actSendSms")]
	public string Index(string prList = "")
	{
		lock (_objLock)
		{
			base.TempData["mydata"] = prList;
		}
		return "";
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actsmsSendedSms")]
	public ActionResult SendedSms()
	{
		FillDropdownSendedSms();
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actsmsUserSendCredit")]
	public ActionResult SmsUserSendCredit()
	{
		FillDropdownUserSendCredit();
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actsmsAddNewDefaultBodyText")]
	public ActionResult SmsDefaultBodyText(int groupId = 0)
	{
		base.ViewBag.groupId = groupId;
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actsmsWSSetting")]
	public void SetRegisterInfoForSmssetting(SmsSetting model)
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
				SmsSetting smsSetting = model;
				_ = model.UserId;
				smsSetting.UserId = model.UserId;
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

	public ActionResult SmsWebServiceSetting()
	{
		SmsSetting smsSetting = new SmsSetting();
		try
		{
			DateTime now = DateTime.Now;
			smsSetting = Queryable.FirstOrDefault<SmsSetting>((IQueryable<SmsSetting>)_dbTbl.SmsSetting) ?? new SmsSetting
			{
				RegisterDate = now,
				FirstRegisterDate = now,
				Id = 0,
				UserId = UserLogin.CurrentUser.UserId,
				RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
				Year1 = short.Parse(Financial.Get().Id.ToString()),
				Month1 = short.Parse(now.ToString("MM", new PersianCulture())),
				AppType = Configuration.AppType,
				FirstRegisterUserId = UserLogin.CurrentUser.UserId,
				FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture())
			};
			if (smsSetting != null)
			{
				smsSetting.SendStartDatePersian = (smsSetting.SendStartDate.HasValue ? smsSetting.SendStartDate.Value.ToString("yyyy/MM/dd") : "");
				smsSetting.SendEndDatePersian = (smsSetting.SendEndDate.HasValue ? smsSetting.SendEndDate.Value.ToString("yyyy/MM/dd") : "");
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		SetRegisterInfoForSmssetting(smsSetting);
		return View(smsSetting);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmsmsWebServiceSetting", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult SmsWebServiceSetting(SmsSetting smsSet)
	{
		string text = "";
		int countError = 0;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			DateTime now = DateTime.Now;
			smsSet.UserId = UserLogin.CurrentUser.UserId;
			smsSet.RegisterDate = now;
			smsSet.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			smsSet.Year1 = short.Parse(Financial.Get().Id.ToString());
			smsSet.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
			smsSet.AppType = Configuration.AppType;
			if (base.ModelState.IsValid)
			{
				text = ChkBeforeSubmitSmsSetting(smsSet, ref countError);
				DateTime dateTime = default(DateTime);
				string text2 = "";
				try
				{
					if (!string.IsNullOrWhiteSpace(smsSet.SendStartDatePersian))
					{
						text2 = PersianDate.GetFormatetdDate(smsSet.SendStartDatePersian.Replace("/", ""));
						switch (lCID)
						{
						case 1065:
							dateTime = DateTime.Parse(text2 + " 00:00:00", new PersianCulture());
							smsSet.SendStartDatePersian = dateTime.ToString("yyyyMMdd");
							break;
						case 1025:
							dateTime = DateTime.Parse(text2 + " 00:00:00", new CultureInfo("ar-SA"));
							smsSet.SendStartDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
							break;
						default:
							dateTime = DateTime.Parse(text2 + " 00:00:00", new CultureInfo("en-US"));
							smsSet.SendStartDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
							break;
						}
						smsSet.SendStartDate = dateTime;
						if (smsSet.SendStartDatePersian != null)
						{
							smsSet.SendStartDatePersian = smsSet.SendStartDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
								.Replace(".", "")
								.Replace(",", "")
								.Replace("\\", "");
						}
					}
					else
					{
						smsSet.SendStartDate = null;
						smsSet.SendStartDatePersian = null;
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
					base.ViewBag.Error = string.Format(Messages.ErrorInFormat, Labels.SmsSetSendStartDate);
					countError++;
					return View(smsSet);
				}
				try
				{
					if (!string.IsNullOrWhiteSpace(smsSet.SendEndDatePersian))
					{
						text2 = PersianDate.GetFormatetdDate(smsSet.SendEndDatePersian.Replace("/", ""));
						switch (lCID)
						{
						case 1065:
							dateTime = DateTime.Parse(text2 + " 23:59:59", new PersianCulture());
							smsSet.SendEndDatePersian = dateTime.ToString("yyyyMMdd");
							break;
						case 1025:
							dateTime = DateTime.Parse(text2 + " 23:59:59", new CultureInfo("ar-SA"));
							smsSet.SendEndDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
							break;
						default:
							dateTime = DateTime.Parse(text2 + " 23:59:59", new CultureInfo("en-US"));
							smsSet.SendEndDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
							break;
						}
						smsSet.SendEndDate = dateTime;
						if (smsSet.SendEndDatePersian != null)
						{
							smsSet.SendEndDatePersian = smsSet.SendEndDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
								.Replace(".", "")
								.Replace(",", "")
								.Replace("\\", "");
						}
					}
					else
					{
						smsSet.SendEndDate = null;
						smsSet.SendEndDatePersian = null;
					}
				}
				catch (Exception e2)
				{
					ErrorSignal.FromCurrentContext().Raise(e2);
					base.ViewBag.Error = string.Format(Messages.ErrorInFormat, Labels.SmsSetSendEndDate);
					countError++;
					return View(smsSet);
				}
				if (countError == 0)
				{
					_003C_003Ec__DisplayClass13_0 _003C_003Ec__DisplayClass13_ = new _003C_003Ec__DisplayClass13_0();
					string text3 = smsSet.Password ?? "";
					string text4 = "";
					string text5 = "";
					SmsSetting smsSetting = Queryable.FirstOrDefault<SmsSetting>((IQueryable<SmsSetting>)_dbTbl.SmsSetting.AsNoTracking());
					if (smsSetting != null)
					{
						text4 = smsSetting.Password ?? "";
					}
					string text6 = ((!string.IsNullOrWhiteSpace(text3)) ? XorCipher.EncryptByPrivateKey(text3) : "");
					string text7 = "";
					try
					{
						text7 = ((!string.IsNullOrWhiteSpace(text4)) ? XorCipher.DecryptByPrivateKey(text4) : "");
					}
					catch (Exception e3)
					{
						ErrorSignal.FromCurrentContext().Raise(e3);
					}
					if (!string.IsNullOrWhiteSpace(text3) && !string.IsNullOrWhiteSpace(text4))
					{
						if (!(text3 == text4))
						{
							text5 = (string.IsNullOrWhiteSpace(text7) ? text6 : ((!(text7 == text3)) ? text6 : text4));
						}
						else
						{
							string text8 = ((!string.IsNullOrWhiteSpace(text4)) ? XorCipher.EncryptByPrivateKey(text4) : "");
							text5 = ((!(text6 == text8)) ? text6 : (string.IsNullOrWhiteSpace(text7) ? text8 : ((!(text7 == text3) && !(text4 != text6)) ? text6 : text4)));
						}
					}
					else
					{
						text5 = text6;
					}
					smsSet.Password = text5;
					if (smsSet.Id == 0)
					{
						smsSet.GUId = Guid.NewGuid();
						smsSet.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
						smsSet.FirstRegisterDate = now;
						smsSet.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						_dbTbl.SmsSetting.Add(smsSet);
						_dbTbl.SaveChanges();
					}
					else
					{
						_dbTbl.Entry(smsSet).State = EntityState.Modified;
						_dbTbl.SaveChanges();
					}
					_003C_003Ec__DisplayClass13_.smsProviderId = 0;
					if (smsSet != null && smsSet.ProviderId.HasValue)
					{
						int.TryParse(smsSet.ProviderId.ToString(), out _003C_003Ec__DisplayClass13_.smsProviderId);
					}
					if (_003C_003Ec__DisplayClass13_.smsProviderId != 0)
					{
						DbSet<SmsProviders> smsProviders = _dbTbl.SmsProviders;
						ParameterExpression val = Expression.Parameter(typeof(SmsProviders), "m");
						SmsProviders smsProviders2 = Queryable.FirstOrDefault<SmsProviders>((IQueryable<SmsProviders>)smsProviders, Expression.Lambda<Func<SmsProviders, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass13_, typeof(_003C_003Ec__DisplayClass13_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
						if (smsProviders2 != null)
						{
							smsProviders2.IsActive = true;
							smsProviders2.Number = smsSet.Number;
							smsProviders2.UserName = smsSet.UserName;
							smsProviders2.Password = smsSet.Password;
							smsProviders2.RegisterDate = now;
							smsProviders2.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
							smsProviders2.UserId = UserLogin.CurrentUser.UserId;
							smsProviders2.Year1 = short.Parse(Financial.Get().Id.ToString());
							smsProviders2.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
							smsProviders2.AppType = Configuration.AppType;
							smsProviders2.TokenUserName = smsSet.TokenUserName;
							smsProviders2.SmsCustomer = smsSet.SmsCustomer;
							smsProviders2.ProviderUrl = smsSet.ProviderUrl;
							_dbTbl.Entry(smsProviders2).State = EntityState.Modified;
							_dbTbl.SaveChanges();
						}
					}
					SmsSeting.Update();
					if (smsSet != null)
					{
						smsSet.SendStartDatePersian = (smsSet.SendStartDate.HasValue ? smsSet.SendStartDate.Value.ToString("yyyy/MM/dd") : "");
						smsSet.SendEndDatePersian = (smsSet.SendEndDate.HasValue ? smsSet.SendEndDate.Value.ToString("yyyy/MM/dd") : "");
					}
					base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
				}
			}
		}
		catch (Exception e4)
		{
			ErrorSignal.FromCurrentContext().Raise(e4);
		}
		base.ViewBag.Error = text;
		SetRegisterInfoForSmssetting(smsSet);
		return View(smsSet);
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actsmsShowGSMSendTank")]
	public ActionResult SmsShowGsmSendTank()
	{
		CrmCompanyReportViewModel model = new CrmCompanyReportViewModel();
		base.ViewBag.IsBuying = VersionBuyer.GSM;
		return View(model);
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actsmsReceiveSms")]
	public ActionResult ReceiveSms()
	{
		CrmCompanyReportViewModel model = new CrmCompanyReportViewModel();
		return View(model);
	}

	[LoginAuthorize]
	public ActionResult SmsSelectDefaultBodyText(int position = 0)
	{
		FillDropdownSmsDefaultBodyText();
		string text = "";
		string text2 = "";
		switch (position)
		{
		case 0:
			text = "frmSendSMS";
			text2 = "actSelectDefaultBodyText";
			break;
		case 1:
			text = "frmGenerateAutoCmpUP";
			text2 = "actSelectDefaultBodyText";
			break;
		case -1:
			return View();
		default:
			return RedirectToAction("Login", "Account", (object)new
			{
				area = "",
				d = DateTime.Now
			});
		}
		if (!UserLogin.IsUserAccess(text, text2, UserLogin.CurrentUser))
		{
			return RedirectToAction("Login", "Account", (object)new
			{
				area = "",
				d = DateTime.Now
			});
		}
		return View();
	}

	private void FillDropdownSendedSms()
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
		List<CRMspSelectUserForLinkedType_Result> list = Enumerable.ToList<CRMspSelectUserForLinkedType_Result>((IEnumerable<CRMspSelectUserForLinkedType_Result>)db.CRMspSelectUserForLinkedType(UserLogin.CurrentUser.UserId, 2, lCID, result, result2));
		List<SelectListItem> list2 = new List<SelectListItem>();
		list2.AddRange(Enumerable.Select<CRMspSelectUserForLinkedType_Result, SelectListItem>((IEnumerable<CRMspSelectUserForLinkedType_Result>)list, (Func<CRMspSelectUserForLinkedType_Result, SelectListItem>)((CRMspSelectUserForLinkedType_Result item) => new SelectListItem
		{
			Text = item.UserName,
			Value = item.LinkedUserId.ToString(),
			Selected = false
		})));
		base.ViewBag.smsUserList = list2;
		List<SmsspSelectSmsDeliveryStatus_Result> list3 = Enumerable.ToList<SmsspSelectSmsDeliveryStatus_Result>((IEnumerable<SmsspSelectSmsDeliveryStatus_Result>)db.SmsspSelectSmsDeliveryStatus(lCID, result));
		List<SelectListItem> list4 = new List<SelectListItem>();
		list4.Add(new SelectListItem
		{
			Text = Labels.ddlWithOutFilter,
			Value = "-1",
			Selected = false
		});
		list4.AddRange(Enumerable.Select<SmsspSelectSmsDeliveryStatus_Result, SelectListItem>((IEnumerable<SmsspSelectSmsDeliveryStatus_Result>)list3, (Func<SmsspSelectSmsDeliveryStatus_Result, SelectListItem>)((SmsspSelectSmsDeliveryStatus_Result item) => new SelectListItem
		{
			Text = item.DeliveryStatus,
			Value = item.ID.ToString(),
			Selected = false
		})));
		base.ViewBag.smsStatusFilter = list4;
	}

	private void FillDropdownUserSendCredit()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectActiveUsers_Result> list = Enumerable.ToList<CRMspSelectActiveUsers_Result>((IEnumerable<CRMspSelectActiveUsers_Result>)db.CRMspSelectActiveUsers(lCID, result, 0));
		List<SelectListItem> list2 = new List<SelectListItem>();
		list2.AddRange(Enumerable.Select<CRMspSelectActiveUsers_Result, SelectListItem>((IEnumerable<CRMspSelectActiveUsers_Result>)list, (Func<CRMspSelectActiveUsers_Result, SelectListItem>)((CRMspSelectActiveUsers_Result item) => new SelectListItem
		{
			Text = item.Name,
			Value = item.UserId.ToString(),
			Selected = false
		})));
		base.ViewBag.smsUserList = list2;
	}

	private void FillDropdownSmsDefaultBodyText()
	{
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<SmsspSelectDefaultBodyTextGroups_Result> list = Enumerable.ToList<SmsspSelectDefaultBodyTextGroups_Result>((IEnumerable<SmsspSelectDefaultBodyTextGroups_Result>)db.SmsspSelectDefaultBodyTextGroups(lCID, result));
			List<SelectListItem> list2 = new List<SelectListItem>();
			list2.AddRange(Enumerable.Select<SmsspSelectDefaultBodyTextGroups_Result, SelectListItem>((IEnumerable<SmsspSelectDefaultBodyTextGroups_Result>)list, (Func<SmsspSelectDefaultBodyTextGroups_Result, SelectListItem>)((SmsspSelectDefaultBodyTextGroups_Result item) => new SelectListItem
			{
				Text = item.Name,
				Value = item.Id.ToString(),
				Selected = false
			})));
			base.ViewBag.smsDefTextGroupList = list2;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}

	[AjaxOnly]
	public JsonResult GetSmsDefaultBodyGroup()
	{
		List<CrmDroupDownItem> list = new List<CrmDroupDownItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			list = Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<SmsspSelectDefaultBodyTextGroups_Result, CrmDroupDownItem>((IEnumerable<SmsspSelectDefaultBodyTextGroups_Result>)Enumerable.ToList<SmsspSelectDefaultBodyTextGroups_Result>((IEnumerable<SmsspSelectDefaultBodyTextGroups_Result>)db.SmsspSelectDefaultBodyTextGroups(lCID, result)), (Func<SmsspSelectDefaultBodyTextGroups_Result, CrmDroupDownItem>)((SmsspSelectDefaultBodyTextGroups_Result item) => new CrmDroupDownItem
			{
				text = item.Name,
				value = item.Id.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.smsDefTextGroupList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	private void FillDropdownSmsSend()
	{
		List<SelectListItem> list = new List<SelectListItem>
		{
			new SelectListItem
			{
				Text = Labels.SmsSaveToMobile,
				Value = "1",
				Selected = false
			},
			new SelectListItem
			{
				Text = Labels.SmsSaveToCard,
				Value = "2",
				Selected = false
			},
			new SelectListItem
			{
				Text = Labels.SmsSaveToFlash,
				Value = "3",
				Selected = false
			}
		};
		base.ViewBag.smslistItems = list;
	}

	public ActionResult _PartialCBookMarkGrid(int bookmarkId)
	{
		if (bookmarkId == 0)
		{
			bookmarkId = UserLogin.CurrentUser.UserId;
		}
		string text = DateTime.Now.ToString("yyyy/MM/dd");
		text = text.Replace("/", "");
		base.ViewBag.BookmarkIdDate = bookmarkId + "|" + text;
		return PartialView();
	}

	public ActionResult CBookMark_Read([DataSourceRequest] DataSourceRequest request, string bookmarkIdDate)
	{
		string[] array = bookmarkIdDate.Split(new char[1] { '|' });
		List<CRMResultsBookMarksCartable_Result> list = new List<CRMResultsBookMarksCartable_Result>();
		List<CRMResultsReminderCartableViewModel> list2 = new List<CRMResultsReminderCartableViewModel>();
		int result = 0;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result);
		}
		if (int.Parse(array[0]) != 0)
		{
			_003C_003Ec__DisplayClass23_0 _003C_003Ec__DisplayClass23_ = new _003C_003Ec__DisplayClass23_0();
			_003C_003Ec__DisplayClass23_.treeKeyid = int.Parse(array[0]);
			if (_003C_003Ec__DisplayClass23_.treeKeyid == -1)
			{
				IQueryable<CRMResultsBookMarksCartable_Result> obj = db.CRMResultsBookMarksCartable(UserLogin.CurrentUser.UserId, result);
				ParameterExpression val = Expression.Parameter(typeof(CRMResultsBookMarksCartable_Result), "c");
				list = Enumerable.ToList<CRMResultsBookMarksCartable_Result>((IEnumerable<CRMResultsBookMarksCartable_Result>)Queryable.OrderBy<CRMResultsBookMarksCartable_Result, string>(obj, Expression.Lambda<Func<CRMResultsBookMarksCartable_Result, string>>((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
			}
			else
			{
				IQueryable<CRMResultsBookMarksCartable_Result> obj2 = db.CRMResultsBookMarksCartable(UserLogin.CurrentUser.UserId, result);
				ParameterExpression val = Expression.Parameter(typeof(CRMResultsBookMarksCartable_Result), "c");
				IQueryable<CRMResultsBookMarksCartable_Result> obj3 = Queryable.Where<CRMResultsBookMarksCartable_Result>(obj2, Expression.Lambda<Func<CRMResultsBookMarksCartable_Result, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Convert((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass23_, typeof(_003C_003Ec__DisplayClass23_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), typeof(int?))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				val = Expression.Parameter(typeof(CRMResultsBookMarksCartable_Result), "c");
				list = Enumerable.ToList<CRMResultsBookMarksCartable_Result>((IEnumerable<CRMResultsBookMarksCartable_Result>)Queryable.OrderBy<CRMResultsBookMarksCartable_Result, string>(obj3, Expression.Lambda<Func<CRMResultsBookMarksCartable_Result, string>>((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
			}
			foreach (CRMResultsBookMarksCartable_Result item in list)
			{
				CRMResultsReminderCartableViewModel cRMResultsReminderCartableViewModel = new CRMResultsReminderCartableViewModel();
				cRMResultsReminderCartableViewModel.CompanyID = item.CompanyID;
				cRMResultsReminderCartableViewModel.CompanyName = item.CompanyName;
				cRMResultsReminderCartableViewModel.Person = item.Person;
				cRMResultsReminderCartableViewModel.prsPreTel = item.prsPreTel;
				cRMResultsReminderCartableViewModel.prsTel = item.prsTel;
				cRMResultsReminderCartableViewModel.prsTelUpTo = item.prsTelUpTo;
				cRMResultsReminderCartableViewModel.prsTelDesc = item.prsTelDesc;
				cRMResultsReminderCartableViewModel.prsMobile = item.prsMobile;
				cRMResultsReminderCartableViewModel.prjTitle = item.prjTitle;
				cRMResultsReminderCartableViewModel.ProjectID = item.ProjectID;
				cRMResultsReminderCartableViewModel.ConversationId = item.ConversationId;
				cRMResultsReminderCartableViewModel.cnvsDesc = item.cnvsDesc;
				cRMResultsReminderCartableViewModel.cnvsStatusId = item.cnvsStatusId;
				cRMResultsReminderCartableViewModel.cnvsStatus = item.cnvsStatus;
				cRMResultsReminderCartableViewModel.ProgressPercent = item.ProgressPercent;
				cRMResultsReminderCartableViewModel.ProgressPercentWD = item.ProgressPercentWD;
				cRMResultsReminderCartableViewModel.RemindDate = item.RemindDate;
				cRMResultsReminderCartableViewModel.cnvsDay = item.cnvsDay;
				cRMResultsReminderCartableViewModel.cnvsDate = item.cnvsDate;
				cRMResultsReminderCartableViewModel.RegisterDatePersian = item.RegisterDatePersian;
				cRMResultsReminderCartableViewModel.Priority = item.Priority;
				cRMResultsReminderCartableViewModel.PriorityColor = item.PriorityColor;
				cRMResultsReminderCartableViewModel.PriorityId = item.PriorityId;
				cRMResultsReminderCartableViewModel.cnvsUserName = item.cnvsUserName;
				cRMResultsReminderCartableViewModel.cnvsReferName = item.cnvsReferName;
				cRMResultsReminderCartableViewModel.UserId = item.UserId;
				cRMResultsReminderCartableViewModel.cnvsReferUserId = item.cnvsReferUserId;
				cRMResultsReminderCartableViewModel.cmpPreTel = item.cmpPreTel;
				cRMResultsReminderCartableViewModel.cmpTel = item.cmpTel;
				cRMResultsReminderCartableViewModel.cmpTelUpTo = item.cmpTelUpTo;
				cRMResultsReminderCartableViewModel.cmpTelDesc = item.cmpTelDesc;
				cRMResultsReminderCartableViewModel.cmpPreTelII = item.cmpPreTelII;
				cRMResultsReminderCartableViewModel.cmpTelII = item.cmpTelII;
				cRMResultsReminderCartableViewModel.cmpTelUpToII = item.cmpTelUpToII;
				cRMResultsReminderCartableViewModel.cmpTelIIDesc = item.cmpTelIIDesc;
				cRMResultsReminderCartableViewModel.cmpFax = item.cmpFax;
				cRMResultsReminderCartableViewModel.cmpFaxDesc = item.cmpFaxDesc;
				cRMResultsReminderCartableViewModel.cmpCountryId = item.cmpCountryId;
				cRMResultsReminderCartableViewModel.Country = item.Country;
				cRMResultsReminderCartableViewModel.cmpProvinceId = item.cmpProvinceId;
				cRMResultsReminderCartableViewModel.Province = item.Province;
				cRMResultsReminderCartableViewModel.cmpCityId = item.cmpCityId;
				cRMResultsReminderCartableViewModel.City = item.City;
				cRMResultsReminderCartableViewModel.cmpAddress = item.cmpAddress;
				cRMResultsReminderCartableViewModel.cnvsPersonId = item.cnvsPersonId;
				cRMResultsReminderCartableViewModel.cnvsTime = item.cnvsTime;
				if (cRMResultsReminderCartableViewModel.RemindDate != "" && cRMResultsReminderCartableViewModel.RemindDate != null)
				{
					cRMResultsReminderCartableViewModel.RemindDate = cRMResultsReminderCartableViewModel.RemindDate.Insert(4, "/");
					cRMResultsReminderCartableViewModel.RemindDate = cRMResultsReminderCartableViewModel.RemindDate.Insert(7, "/");
				}
				if (cRMResultsReminderCartableViewModel.cnvsDate != "" && cRMResultsReminderCartableViewModel.cnvsDate != null)
				{
					cRMResultsReminderCartableViewModel.cnvsDate = cRMResultsReminderCartableViewModel.cnvsDate.Insert(4, "/");
					cRMResultsReminderCartableViewModel.cnvsDate = cRMResultsReminderCartableViewModel.cnvsDate.Insert(7, "/");
				}
				if (cRMResultsReminderCartableViewModel.RegisterDatePersian != "" && cRMResultsReminderCartableViewModel.RegisterDatePersian != null)
				{
					cRMResultsReminderCartableViewModel.RegisterDatePersian = cRMResultsReminderCartableViewModel.RegisterDatePersian.Insert(4, "/");
					cRMResultsReminderCartableViewModel.RegisterDatePersian = cRMResultsReminderCartableViewModel.RegisterDatePersian.Insert(7, "/");
				}
				if (cRMResultsReminderCartableViewModel.cnvsRemindDateForAllarm != "" && cRMResultsReminderCartableViewModel.cnvsRemindDateForAllarm != null)
				{
					cRMResultsReminderCartableViewModel.cnvsRemindDateForAllarm = cRMResultsReminderCartableViewModel.cnvsRemindDateForAllarm.Insert(4, "/");
					cRMResultsReminderCartableViewModel.cnvsRemindDateForAllarm = cRMResultsReminderCartableViewModel.cnvsRemindDateForAllarm.Insert(7, "/");
				}
				list2.Add(cRMResultsReminderCartableViewModel);
			}
		}
		return Json(((IEnumerable)list2).ToDataSourceResult(request));
	}

	public ActionResult _PartialSmsUserSendCredit(int userId = 0)
	{
		base.ViewBag.CreditUserId = userId;
		return PartialView();
	}

	public ActionResult _PartialSmsUserSendCredit_Read([DataSourceRequest] DataSourceRequest request, int userId)
	{
		List<SmsspSelectSmsUserSendCredit_Result> list = new List<SmsspSelectSmsUserSendCredit_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			list = Enumerable.ToList<SmsspSelectSmsUserSendCredit_Result>((IEnumerable<SmsspSelectSmsUserSendCredit_Result>)db.SmsspSelectSmsUserSendCredit(userId, lCID, result));
			foreach (SmsspSelectSmsUserSendCredit_Result item in list)
			{
				item.ImportDate = (item.ImportDateTime.HasValue ? item.ImportDateTime.Value.ToString("yyyy/MM/dd") : DateTimeClass.ConvertDateWOSlashToSlash(item.ImportDate));
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

	public ActionResult _PartialSmsDefaultBodyText(int groupId = 0)
	{
		base.ViewBag.groupId = groupId;
		return PartialView();
	}

	public ActionResult _PartialSmsDefaultBodyText_Read([DataSourceRequest] DataSourceRequest request, int groupId)
	{
		List<SmsspSelectDefaultBodyTextInMode_Result> list = new List<SmsspSelectDefaultBodyTextInMode_Result>();
		try
		{
			string mode = ((groupId == 0) ? "User" : "UserGroup");
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			list = Enumerable.ToList<SmsspSelectDefaultBodyTextInMode_Result>((IEnumerable<SmsspSelectDefaultBodyTextInMode_Result>)db.SmsspSelectDefaultBodyTextInMode(mode, UserLogin.CurrentUser.UserId, groupId, lCID, result));
			foreach (SmsspSelectDefaultBodyTextInMode_Result item in list)
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

	public ActionResult _PartialSmsSelectDefaultBodyText(int groupId)
	{
		base.ViewBag.groupId = groupId;
		return PartialView();
	}

	public ActionResult _PartialSmsSelectDefaultBodyText_Read([DataSourceRequest] DataSourceRequest request, int groupId)
	{
		List<SmsspSelectDefaultBodyTextInMode_Result> enumerable = new List<SmsspSelectDefaultBodyTextInMode_Result>();
		try
		{
			string mode = ((groupId == 0) ? "User" : "UserGroup");
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			enumerable = Enumerable.ToList<SmsspSelectDefaultBodyTextInMode_Result>((IEnumerable<SmsspSelectDefaultBodyTextInMode_Result>)db.SmsspSelectDefaultBodyTextInMode(mode, UserLogin.CurrentUser.UserId, groupId, lCID, result));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)enumerable).ToDataSourceResult(request));
	}

	[AjaxOnly]
	public ActionResult _PartialGSMNotSendItem()
	{
		return PartialView();
	}

	[AjaxOnly]
	public ActionResult _PartialGSMNotSendItem_Read([DataSourceRequest] DataSourceRequest request, int mode)
	{
		List<SmsspSelectSMSTankItems_Result> list = new List<SmsspSelectSMSTankItems_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			list = Enumerable.ToList<SmsspSelectSMSTankItems_Result>((IEnumerable<SmsspSelectSMSTankItems_Result>)db.SmsspSelectSMSTankItems(lCID, result, now, mode, UserLogin.CurrentUser.UserId));
			foreach (SmsspSelectSMSTankItems_Result item in list)
			{
				item.FirstRegisterDatePersian = (item.FirstRegisterDate.HasValue ? item.FirstRegisterDate.Value.ToString("dddd HH:mm:ss yyyy/MM/dd") : "");
				item.SendDate = (item.SendDateTime.HasValue ? item.SendDateTime.Value.ToString("yyyy/MM/dd") : "");
				item.SendTime = (item.SendDateTime.HasValue ? item.SendDateTime.Value.ToString("HH:mm:ss") : "");
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
		return Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult _PartialSmsSendedHeader(string fromDate, string toDate, int userId)
	{
		string text = DateTime.Now.ToString("yyyyMMdd");
		fromDate = ((!string.IsNullOrEmpty(fromDate)) ? fromDate : text);
		toDate = ((!string.IsNullOrEmpty(toDate)) ? toDate : text);
		base.ViewBag.fromDate = fromDate;
		base.ViewBag.toDate = toDate;
		base.ViewBag.userId = userId;
		return PartialView();
	}

	[AjaxOnly]
	public ActionResult _PartialSmsSendedHeader_Read([DataSourceRequest] DataSourceRequest request, string fromDate, string toDate, int userId)
	{
		List<SmsspSelectSendedHeader_Result> list = new List<SmsspSelectSendedHeader_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate) && userId != 0)
			{
				toDate = toDate.Replace("/", "").Replace("-", "").Replace("\\", "")
					.Replace(" ", "")
					.Replace("_", "");
				fromDate = fromDate.Replace("/", "").Replace("-", "").Replace("\\", "")
					.Replace(" ", "")
					.Replace("_", "");
				DateTime value = DateTime.Now;
				DateTime value2 = DateTime.Now;
				if (!string.IsNullOrEmpty(fromDate))
				{
					value = DateTime.Parse(PersianDate.GetFormatetdDate(fromDate.Replace("/", "")) + " 00:00:00", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(toDate))
				{
					value2 = DateTime.Parse(PersianDate.GetFormatetdDate(toDate.Replace("/", "")) + " 23:59:59", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				string msgSmsSentFromWeb = Messages.msgSmsSentFromWeb;
				string msgSmsSentFromGsm = Messages.msgSmsSentFromGsm;
				string sentWithBirthWebText = Labels.SentWithBirthWebText;
				string sentWithBirthGsmText = Labels.SentWithBirthGsmText;
				string sentWithMarriageWebText = Labels.SentWithMarriageWebText;
				string sentWithMarriageGsmText = Labels.SentWithMarriageGsmText;
				string sentWithAutoAnswerWebText = Labels.SentWithAutoAnswerWebText;
				string sentWithAutoAnswerGsmText = Labels.SentWithAutoAnswerGsmText;
				list = Enumerable.ToList<SmsspSelectSendedHeader_Result>((IEnumerable<SmsspSelectSendedHeader_Result>)db.SmsspSelectSendedHeader(fromDate, toDate, userId, value, value2, msgSmsSentFromWeb, msgSmsSentFromGsm, sentWithBirthWebText, sentWithBirthGsmText, sentWithMarriageWebText, sentWithMarriageGsmText, sentWithAutoAnswerWebText, sentWithAutoAnswerGsmText));
			}
			foreach (SmsspSelectSendedHeader_Result item in list)
			{
				item.SendDate = ((!string.IsNullOrEmpty(item.SendDate) && lCID != 1065) ? PersianDate.GetShamsi2Miladi(item.SendDate.Replace("/", "")).Replace("/", "") : item.SendDate);
				item.SendDay = DateTimeClass.ConvertNumToDayeOfWeek(item.SendDay) ?? item.SendDay;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request));
	}

	public ActionResult _PartialSmsSendedDetail(string fromDate, string toDate, int userId, int smsHeadId, int statusId)
	{
		string text = DateTime.Now.ToString("yyyyMMdd");
		fromDate = ((!string.IsNullOrEmpty(fromDate)) ? fromDate : text);
		toDate = ((!string.IsNullOrEmpty(toDate)) ? toDate : text);
		base.ViewBag.fromDate = fromDate;
		base.ViewBag.toDate = toDate;
		base.ViewBag.userId = userId;
		base.ViewBag.smsHeadId = smsHeadId;
		base.ViewBag.statusId = statusId;
		return PartialView();
	}

	[AjaxOnly]
	public ActionResult _PartialSmsSendedDetail_Read([DataSourceRequest] DataSourceRequest request, string fromDate, string toDate, int userId, int smsHeadId, int statusId)
	{
		List<mct_SmsspSelectSendedDetail_Result> list = new List<mct_SmsspSelectSendedDetail_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int result2 = 0;
			int value = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
				value = UserLogin.CurrentUser.UserId;
			}
			if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate) && userId != 0 && smsHeadId != 0)
			{
				toDate = toDate.Replace("/", "").Replace("-", "").Replace("\\", "")
					.Replace(" ", "")
					.Replace("_", "");
				fromDate = fromDate.Replace("/", "").Replace("-", "").Replace("\\", "")
					.Replace(" ", "")
					.Replace("_", "");
				DateTime value2 = DateTime.Now;
				DateTime value3 = DateTime.Now;
				if (!string.IsNullOrEmpty(fromDate))
				{
					value2 = DateTime.Parse(PersianDate.GetFormatetdDate(fromDate.Replace("/", "")) + " 00:00:00", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(toDate))
				{
					value3 = DateTime.Parse(PersianDate.GetFormatetdDate(toDate.Replace("/", "")) + " 23:59:59", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				string unspecify = Labels.Unspecify;
				list = Enumerable.ToList<mct_SmsspSelectSendedDetail_Result>((IEnumerable<mct_SmsspSelectSendedDetail_Result>)db.mfi_SmsspSelectSendedDetail(smsHeadId.ToString(), fromDate, toDate, userId.ToString(), statusId.ToString(), value2, value3, lCID, result, unspecify, result2, value));
			}
			foreach (mct_SmsspSelectSendedDetail_Result item in list)
			{
				if (string.IsNullOrEmpty(item.SendDateTime))
				{
					continue;
				}
				string[] array = item.SendDateTime.Split();
				if (array[0] != null && array[0] != "" && array[0].Length == 1)
				{
					int.TryParse(array[0], out var result3);
					array[0] = DateTimeClass.ConvertNumToDayeOfWeek(result3) ?? array[0];
					if (!string.IsNullOrEmpty(array[1]) && lCID == 1025)
					{
						array[1] = DateTime.Parse(PersianDate.GetFormatetdDate(array[1].Replace("/", "")) + " 00:00:00", new CultureInfo("en-US")).ToString("yyyy/MM/dd", new CultureInfo("ar-SA"));
					}
					item.SendDateTime = array[0] + " " + array[1] + " " + array[2];
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
	public ActionResult _PartialReceiveSms(string fromDate, string toDate, bool isLike, string likeVal)
	{
		string text = DateTime.Now.ToString("yyyy/MM/dd");
		fromDate = ((!string.IsNullOrEmpty(fromDate)) ? fromDate : text);
		toDate = ((!string.IsNullOrEmpty(toDate)) ? toDate : text);
		base.ViewBag.fromDate = fromDate;
		base.ViewBag.toDate = toDate;
		base.ViewBag.isLike = isLike;
		base.ViewBag.likeVal = likeVal;
		return PartialView();
	}

	[AjaxOnly]
	public ActionResult _PartialReceiveSms_Read([DataSourceRequest] DataSourceRequest request, string fromDate, string toDate, bool isLike, string likeVal)
	{
		List<CRMspSmsSelectReceiveSMS_Result> list = new List<CRMspSmsSelectReceiveSMS_Result>();
		try
		{
			if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate))
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				likeVal = likeVal ?? "";
				toDate = toDate.Replace("/", "").Replace("-", "").Replace("\\", "")
					.Replace(" ", "")
					.Replace("_", "");
				fromDate = fromDate.Replace("/", "").Replace("-", "").Replace("\\", "")
					.Replace(" ", "")
					.Replace("_", "");
				DateTime value = DateTime.Now;
				DateTime value2 = DateTime.Now;
				if (!string.IsNullOrEmpty(fromDate))
				{
					value = DateTime.Parse(PersianDate.GetFormatetdDate(fromDate.Replace("/", "")) + " 00:00:00", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(toDate))
				{
					value2 = DateTime.Parse(PersianDate.GetFormatetdDate(toDate.Replace("/", "")) + " 23:59:59", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				int userId = UserLogin.CurrentUser.UserId;
				DateTime now = DateTime.Now;
				string rptDate = now.ToString("yyyy/MM/dd");
				string rptDay = DateTimeClass.DefineDayeOfWeekFaWithoutNull(now.DayOfWeek.ToString());
				string fDateFa = value.ToString("yyyyMMdd", new PersianCulture());
				string tDateFa = value2.ToString("yyyyMMdd", new PersianCulture());
				list = Enumerable.ToList<CRMspSmsSelectReceiveSMS_Result>((IEnumerable<CRMspSmsSelectReceiveSMS_Result>)db.CRMspSmsSelectReceiveSMS(value, value2, likeVal, isLike, lCID, result, userId, rptDate, rptDay, fDateFa, tDateFa));
				foreach (CRMspSmsSelectReceiveSMS_Result item in list)
				{
					item.ReceiveDatePersianPreview = (item.ReceiveDate.HasValue ? (item.ReceiveDate.Value.ToString("yyyy/MM/dd") + " " + item.ReceiveDate.Value.ToString("hh:mm:ss tt")) : "");
					item.ReceiveDatePersian = (item.ReceiveDate.HasValue ? item.ReceiveDate.Value.ToString("yyyy/MM/dd") : "");
					item.SendDatePersian = (item.SendDate.HasValue ? item.SendDate.Value.ToString("yyyy/MM/dd") : "");
					item.SendDatePersianPreview = (item.SendDate.HasValue ? (item.SendDate.Value.ToString("yyyy/MM/dd") + " " + item.SendDate.Value.ToString("HH:mm:ss") + " " + DateTimeClass.DefineDayeOfWeekFa(item.SendDate.Value.ToString("dddd", new CultureInfo("en-US")))) : "");
					item.RegisterDatePersian = (item.RegisterDate.HasValue ? item.RegisterDate.Value.ToString("yyyy/MM/dd") : "");
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmsmsUserSendCredit", ActionName = "actInsert")]
	public ActionResult SmsUserSendCreditInsert(int userId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		SmsUserSendCreditLanguageViewModel model = new SmsUserSendCreditLanguageViewModel
		{
			UserID = UserLogin.CurrentUser.UserId,
			Year1 = short.Parse(Financial.Get().Id.ToString()),
			Month1 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture())),
			RegisterDate = DateTime.Now,
			RegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture()),
			ImportDate = DateTime.Now.ToString("yyyyMMdd", new PersianCulture()),
			CreditUserId = userId,
			Amount = 0m,
			ImportDateTime = DateTime.Now
		};
		return View(model);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmsmsUserSendCreditDataEntry", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult SmsUserSendCreditInsert(SmsUserSendCreditLanguageViewModel vm)
	{
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int countError = 0;
		try
		{
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(vm.Description_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(vm.Description_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = vm.Description,
				LanguageId = lCID
			});
			DateTime dateTime = default(DateTime);
			string text2 = "";
			try
			{
				if (!string.IsNullOrEmpty(vm.ImportDate))
				{
					vm.ImportDate = vm.ImportDate.Replace("/", "").Replace("-", "").Replace("\\", "")
						.Replace(" ", "")
						.Replace("_", "");
					text2 = PersianDate.GetFormatetdDate(vm.ImportDate.Replace("/", ""));
					switch (lCID)
					{
					case 1065:
						dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
						vm.ImportDate = dateTime.ToString("yyyyMMdd");
						break;
					case 1025:
						dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
						vm.ImportDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					default:
						dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
						vm.ImportDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					}
					vm.ImportDateTime = dateTime;
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				base.ViewBag.Error = Messages.ErrorFormatDatePersian;
				return View(vm);
			}
			DateTime now = DateTime.Now;
			vm.UserID = UserLogin.CurrentUser.UserId;
			vm.RegisterDate = now;
			vm.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			vm.Year1 = short.Parse(Financial.Get().Id.ToString());
			vm.Month1 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			vm.GUId = Guid.NewGuid();
			vm.AppType = Configuration.AppType;
			vm.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
			vm.FirstRegisterDate = now;
			vm.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			vm.LanguageID = defLangID;
			SmsUserSendCredit smsUserSendCredit = new SmsUserSendCredit();
			smsUserSendCredit.CreditUserId = vm.CreditUserId;
			smsUserSendCredit.ImportDate = vm.ImportDate;
			smsUserSendCredit.Amount = vm.Amount;
			smsUserSendCredit.UserID = vm.UserID;
			smsUserSendCredit.Year1 = vm.Year1;
			smsUserSendCredit.Month1 = vm.Month1;
			smsUserSendCredit.RegisterDate = vm.RegisterDate;
			smsUserSendCredit.RegisterDatePersian = vm.RegisterDatePersian;
			smsUserSendCredit.ImportDateTime = vm.ImportDateTime;
			smsUserSendCredit.GUId = vm.GUId;
			smsUserSendCredit.AppType = vm.AppType;
			smsUserSendCredit.LanguageID = vm.LanguageID;
			smsUserSendCredit.FirstRegisterUserId = vm.FirstRegisterUserId;
			smsUserSendCredit.FirstRegisterDatePersian = vm.FirstRegisterDatePersian;
			smsUserSendCredit.FirstRegisterDate = vm.FirstRegisterDate;
			smsUserSendCredit.Description = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
			if (base.ModelState.IsValid)
			{
				text = ChkBeforeSubmitUserCreditSms(smsUserSendCredit, ref countError);
				if (countError == 0)
				{
					_dbTbl.SmsUserSendCredit.Add(smsUserSendCredit);
					_dbTbl.SaveChanges();
					foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))))
					{
						SmsUserSendCredit_Lang smsUserSendCredit_Lang = new SmsUserSendCredit_Lang();
						smsUserSendCredit_Lang.LanguageID = lang.LanguageID;
						smsUserSendCredit_Lang.ID = smsUserSendCredit.ID;
						smsUserSendCredit_Lang.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						_dbTbl.SmsUserSendCredit_Lang.Add(smsUserSendCredit_Lang);
						_dbTbl.SaveChanges();
					}
					base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
				}
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			text = Messages.frmErrorMessage + "<br />" + ex.Message;
		}
		base.ViewBag.Error = text;
		return View(vm);
	}

	[DynamicAuthorize(ControllerName = "frmsmsUserSendCredit", ActionName = "actEdit")]
	public ActionResult SmsUserSendCreditEdit(int creditId)
	{
		_003C_003Ec__DisplayClass40_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass40_0();
		CS_0024_003C_003E8__locals0.creditId = creditId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		SmsUserSendCreditLanguageViewModel smsUserSendCreditLanguageViewModel = new SmsUserSendCreditLanguageViewModel();
		try
		{
			if (CS_0024_003C_003E8__locals0.creditId == 0)
			{
				smsUserSendCreditLanguageViewModel = new SmsUserSendCreditLanguageViewModel();
				smsUserSendCreditLanguageViewModel.ID = Convert.ToInt32(CS_0024_003C_003E8__locals0.creditId);
				smsUserSendCreditLanguageViewModel.UserID = UserLogin.CurrentUser.UserId;
				smsUserSendCreditLanguageViewModel.Year1 = short.Parse(Financial.Get().Id.ToString());
				smsUserSendCreditLanguageViewModel.Month1 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
				smsUserSendCreditLanguageViewModel.RegisterDate = DateTime.Now;
				smsUserSendCreditLanguageViewModel.RegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
				smsUserSendCreditLanguageViewModel.ImportDate = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
				smsUserSendCreditLanguageViewModel.Amount = 0m;
				smsUserSendCreditLanguageViewModel.ImportDateTime = DateTime.Now;
			}
			else
			{
				DbSet<SmsUserSendCredit_Lang> smsUserSendCredit_Lang = _dbTbl.SmsUserSendCredit_Lang;
				ParameterExpression val = Expression.Parameter(typeof(SmsUserSendCredit_Lang), "c");
				List<SmsUserSendCredit_Lang> list = Enumerable.ToList<SmsUserSendCredit_Lang>((IEnumerable<SmsUserSendCredit_Lang>)Queryable.Where<SmsUserSendCredit_Lang>((IQueryable<SmsUserSendCredit_Lang>)smsUserSendCredit_Lang, Expression.Lambda<Func<SmsUserSendCredit_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass40_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
				DbSet<SmsUserSendCredit> smsUserSendCredit = _dbTbl.SmsUserSendCredit;
				val = Expression.Parameter(typeof(SmsUserSendCredit), "m");
				SmsUserSendCredit smsUserSendCredit2 = Queryable.FirstOrDefault<SmsUserSendCredit>((IQueryable<SmsUserSendCredit>)smsUserSendCredit, Expression.Lambda<Func<SmsUserSendCredit, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass40_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) ?? new SmsUserSendCredit();
				List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<SmsUserSendCredit_Lang, CommonMultiLanguageViewModel>((IEnumerable<SmsUserSendCredit_Lang>)list, (Func<SmsUserSendCredit_Lang, CommonMultiLanguageViewModel>)((SmsUserSendCredit_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.Description,
					LanguageId = item.LanguageID
				})));
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = smsUserSendCredit2.Description,
					LanguageId = result
				});
				smsUserSendCreditLanguageViewModel = new SmsUserSendCreditLanguageViewModel
				{
					ID = smsUserSendCredit2.ID,
					CreditUserId = smsUserSendCredit2.CreditUserId,
					ImportDateTime = smsUserSendCredit2.ImportDateTime,
					ImportDate = (smsUserSendCredit2.ImportDateTime.HasValue ? smsUserSendCredit2.ImportDateTime.Value.ToString("yyyy/MM/dd") : ""),
					Amount = smsUserSendCredit2.Amount,
					UserID = smsUserSendCredit2.UserID,
					Year1 = smsUserSendCredit2.Year1,
					Month1 = smsUserSendCredit2.Month1,
					RegisterDate = smsUserSendCredit2.RegisterDate,
					RegisterDatePersian = smsUserSendCredit2.RegisterDatePersian,
					GUId = smsUserSendCredit2.GUId,
					AppType = smsUserSendCredit2.AppType,
					LanguageID = smsUserSendCredit2.LanguageID,
					FirstRegisterUserId = smsUserSendCredit2.FirstRegisterUserId,
					FirstRegisterDatePersian = smsUserSendCredit2.FirstRegisterDatePersian,
					FirstRegisterDate = smsUserSendCredit2.FirstRegisterDate,
					Description_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "")
				};
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View(smsUserSendCreditLanguageViewModel);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmsmsUserSendCreditDataEntry", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult SmsUserSendCreditEdit(SmsUserSendCreditLanguageViewModel vm)
	{
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass41_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass41_0();
		CS_0024_003C_003E8__locals0.vm = vm;
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
			_003C_003Ec__DisplayClass41_1 _003C_003Ec__DisplayClass41_ = new _003C_003Ec__DisplayClass41_1();
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.Description_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.Description_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.Description,
				LanguageId = lCID
			});
			DateTime dateTime = default(DateTime);
			string text2 = "";
			try
			{
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.ImportDate))
				{
					CS_0024_003C_003E8__locals0.vm.ImportDate = CS_0024_003C_003E8__locals0.vm.ImportDate.Replace("/", "").Replace("-", "").Replace("\\", "")
						.Replace(" ", "")
						.Replace("_", "");
					text2 = PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.vm.ImportDate.Replace("/", ""));
					switch (lCID)
					{
					case 1065:
						dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
						CS_0024_003C_003E8__locals0.vm.ImportDate = dateTime.ToString("yyyyMMdd");
						break;
					case 1025:
						dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
						CS_0024_003C_003E8__locals0.vm.ImportDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					default:
						dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
						CS_0024_003C_003E8__locals0.vm.ImportDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					}
					CS_0024_003C_003E8__locals0.vm.ImportDateTime = dateTime;
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				base.ViewBag.Error = Messages.ErrorFormatDatePersian;
				return View(CS_0024_003C_003E8__locals0.vm);
			}
			DateTime now = DateTime.Now;
			CS_0024_003C_003E8__locals0.vm.UserID = UserLogin.CurrentUser.UserId;
			CS_0024_003C_003E8__locals0.vm.RegisterDate = now;
			CS_0024_003C_003E8__locals0.vm.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			CS_0024_003C_003E8__locals0.vm.Year1 = short.Parse(Financial.Get().Id.ToString());
			CS_0024_003C_003E8__locals0.vm.Month1 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			CS_0024_003C_003E8__locals0.vm.AppType = Configuration.AppType;
			_003C_003Ec__DisplayClass41_.model = new SmsUserSendCredit();
			if (CS_0024_003C_003E8__locals0.vm.ID > 0)
			{
				DbSet<SmsUserSendCredit> smsUserSendCredit = _dbTbl.SmsUserSendCredit;
				ParameterExpression val = Expression.Parameter(typeof(SmsUserSendCredit), "c");
				_003C_003Ec__DisplayClass41_.model = Queryable.FirstOrDefault<SmsUserSendCredit>((IQueryable<SmsUserSendCredit>)smsUserSendCredit, Expression.Lambda<Func<SmsUserSendCredit, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass41_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			}
			_003C_003Ec__DisplayClass41_.model.CreditUserId = CS_0024_003C_003E8__locals0.vm.CreditUserId;
			_003C_003Ec__DisplayClass41_.model.ImportDate = CS_0024_003C_003E8__locals0.vm.ImportDate;
			_003C_003Ec__DisplayClass41_.model.Amount = CS_0024_003C_003E8__locals0.vm.Amount;
			_003C_003Ec__DisplayClass41_.model.UserID = CS_0024_003C_003E8__locals0.vm.UserID;
			_003C_003Ec__DisplayClass41_.model.Year1 = CS_0024_003C_003E8__locals0.vm.Year1;
			_003C_003Ec__DisplayClass41_.model.Month1 = CS_0024_003C_003E8__locals0.vm.Month1;
			_003C_003Ec__DisplayClass41_.model.RegisterDate = CS_0024_003C_003E8__locals0.vm.RegisterDate;
			_003C_003Ec__DisplayClass41_.model.RegisterDatePersian = CS_0024_003C_003E8__locals0.vm.RegisterDatePersian;
			_003C_003Ec__DisplayClass41_.model.ImportDateTime = CS_0024_003C_003E8__locals0.vm.ImportDateTime;
			_003C_003Ec__DisplayClass41_.model.AppType = CS_0024_003C_003E8__locals0.vm.AppType;
			_003C_003Ec__DisplayClass41_.model.Description = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
			if (base.ModelState.IsValid)
			{
				text = ChkBeforeSubmitUserCreditSms(_003C_003Ec__DisplayClass41_.model, ref countError);
				if (countError == 0)
				{
					_dbTbl.Entry(_003C_003Ec__DisplayClass41_.model).State = EntityState.Modified;
					_dbTbl.SaveChanges();
					using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							_003C_003Ec__DisplayClass41_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass41_2();
							CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass41_;
							CS_0024_003C_003E8__locals1.lang = enumerator.Current;
							DbSet<SmsUserSendCredit_Lang> smsUserSendCredit_Lang = _dbTbl.SmsUserSendCredit_Lang;
							ParameterExpression val = Expression.Parameter(typeof(SmsUserSendCredit_Lang), "c");
							SmsUserSendCredit_Lang smsUserSendCredit_Lang2 = Queryable.FirstOrDefault<SmsUserSendCredit_Lang>((IQueryable<SmsUserSendCredit_Lang>)smsUserSendCredit_Lang, Expression.Lambda<Func<SmsUserSendCredit_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass41_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass41_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (smsUserSendCredit_Lang2 != null)
							{
								smsUserSendCredit_Lang2.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								_dbTbl.Entry(smsUserSendCredit_Lang2).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							smsUserSendCredit_Lang2 = new SmsUserSendCredit_Lang();
							smsUserSendCredit_Lang2.LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID;
							smsUserSendCredit_Lang2.ID = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.ID;
							smsUserSendCredit_Lang2.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							_dbTbl.SmsUserSendCredit_Lang.Add(smsUserSendCredit_Lang2);
							_dbTbl.SaveChanges();
						}
					}
					base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
				}
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		base.ViewBag.Error = text;
		return View(CS_0024_003C_003E8__locals0.vm);
	}

	[DynamicAuthorize(ControllerName = "frmsmsUserSendCredit", ActionName = "actDelete")]
	public string SmsUserSendCreditDelete(int creditId)
	{
		_003C_003Ec__DisplayClass42_0 _003C_003Ec__DisplayClass42_ = new _003C_003Ec__DisplayClass42_0();
		_003C_003Ec__DisplayClass42_.creditId = creditId;
		string result = "";
		try
		{
			DbSet<SmsUserSendCredit> smsUserSendCredit = _dbTbl.SmsUserSendCredit;
			ParameterExpression val = Expression.Parameter(typeof(SmsUserSendCredit), "m");
			if (Queryable.FirstOrDefault<SmsUserSendCredit>((IQueryable<SmsUserSendCredit>)smsUserSendCredit, Expression.Lambda<Func<SmsUserSendCredit, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass42_, typeof(_003C_003Ec__DisplayClass42_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) != null)
			{
				try
				{
					mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)Enumerable.ToList<mct_Result>((IEnumerable<mct_Result>)db.SmsspDeleteSmsUserSendCredit(_003C_003Ec__DisplayClass42_.creditId)));
					if (mct_Result != null && mct_Result.Result > 0)
					{
						result = "";
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

	[AjaxOnly]
	public string SmsUserSendCreditSum(int creditUserId)
	{
		string result = "-1";
		try
		{
			creditUserId = ((creditUserId == 0) ? UserLogin.CurrentUser.UserId : creditUserId);
			decimal.TryParse(Enumerable.FirstOrDefault<decimal?>((IEnumerable<decimal?>)db.SmsspSelectSmsUserSendCreditSum(creditUserId)).ToString(), out var result2);
			result = result2.ToString("#,0");
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[AjaxOnly]
	public string ReturnUserSendCreditAndSendedCc(int creditUserId)
	{
		string result = "-1";
		try
		{
			creditUserId = ((creditUserId == 0) ? UserLogin.CurrentUser.UserId : creditUserId);
			SmsReturnUserSendCreditAndSendedCC_Result smsReturnUserSendCreditAndSendedCC_Result = Queryable.FirstOrDefault<SmsReturnUserSendCreditAndSendedCC_Result>(db.SmsReturnUserSendCreditAndSendedCC(creditUserId));
			if (smsReturnUserSendCreditAndSendedCC_Result != null)
			{
				decimal.TryParse(smsReturnUserSendCreditAndSendedCC_Result.AllSendedsmsCost.ToString(), out var result2);
				decimal.TryParse(smsReturnUserSendCreditAndSendedCC_Result.RemainCredit.ToString(), out var result3);
				result = result2.ToString("#,0") + "|" + result3.ToString("#,0");
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public string ChkBeforeSubmitUserCreditSms(SmsUserSendCredit smsCredit, ref int countError)
	{
		string text = "";
		if (string.IsNullOrEmpty(smsCredit.ImportDate))
		{
			text = text + Messages.msgErrorUserSendCreditDateNotEnter + "<br>";
			countError++;
		}
		if (smsCredit.Amount != 0m)
		{
			return text;
		}
		text = text + Messages.msgErrorUserSendCreditAmountNotEnter + "<br>";
		countError++;
		return text;
	}

	[DynamicAuthorize(ControllerName = "frmsmsDefaultBodyText", ActionName = "actInsert")]
	public ActionResult SmsDefaultBodyTextInsert()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		SmsDefaultBodyTextLanguageViewModel model = new SmsDefaultBodyTextLanguageViewModel
		{
			UserId = UserLogin.CurrentUser.UserId,
			Year1 = short.Parse(Financial.Get().Id.ToString()),
			Month1 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture())),
			RegisterDate = DateTime.Now,
			RegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture())
		};
		FillDropdownSmsDefaultBodyText();
		return View(model);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmsmsDefaultBodyText", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult SmsDefaultBodyTextInsert(SmsDefaultBodyTextLanguageViewModel vm)
	{
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int countError = 0;
		FillDropdownSmsDefaultBodyText();
		try
		{
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(vm.Title_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(vm.Title_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = vm.Title,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(vm.Text_Lang))
			{
				list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(vm.Text_Lang);
			}
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = vm.Text,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(vm.Description_Lang))
			{
				list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(vm.Description_Lang);
			}
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = vm.Description,
				LanguageId = lCID
			});
			if (vm.Text == null && vm.Text == "")
			{
				text = text + Messages.CheckSmsDefaultBodyText + "<br/>";
			}
			else if (!checkMultiLanguage(vm.Text, list2))
			{
				text = text + Messages.CheckSmsDefaultBodyTextLang + "<br>";
			}
			if (text != "")
			{
				base.ViewBag.Error = text;
				return View(vm);
			}
			DateTime now = DateTime.Now;
			vm.UserId = UserLogin.CurrentUser.UserId;
			vm.RegisterDate = now;
			vm.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			vm.Year1 = short.Parse(Financial.Get().Id.ToString());
			vm.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
			vm.GUId = Guid.NewGuid();
			vm.AppType = Configuration.AppType;
			vm.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
			vm.FirstRegisterDate = now;
			vm.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			vm.LanguageID = defLangID;
			SmsDefaultBodyText smsDefaultBodyText = new SmsDefaultBodyText();
			smsDefaultBodyText.UserId = vm.UserId;
			smsDefaultBodyText.Year1 = vm.Year1;
			smsDefaultBodyText.Month1 = vm.Month1;
			smsDefaultBodyText.RegisterDate = vm.RegisterDate;
			smsDefaultBodyText.RegisterDatePersian = vm.RegisterDatePersian;
			smsDefaultBodyText.GroupId = vm.GroupId;
			smsDefaultBodyText.GUId = vm.GUId;
			smsDefaultBodyText.AppType = vm.AppType;
			smsDefaultBodyText.LanguageID = vm.LanguageID;
			smsDefaultBodyText.FirstRegisterUserId = vm.FirstRegisterUserId;
			smsDefaultBodyText.FirstRegisterDatePersian = vm.FirstRegisterDatePersian;
			smsDefaultBodyText.FirstRegisterDate = vm.FirstRegisterDate;
			smsDefaultBodyText.Title = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
			smsDefaultBodyText.Text = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
			smsDefaultBodyText.Description = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
			if (base.ModelState.IsValid)
			{
				text = ChkBeforeSubmitsmsDefaultBody(smsDefaultBodyText, ref countError);
				if (countError == 0)
				{
					_dbTbl.SmsDefaultBodyText.Add(smsDefaultBodyText);
					_dbTbl.SaveChanges();
					foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))))
					{
						SmsDefaultBodyText_Lang smsDefaultBodyText_Lang = new SmsDefaultBodyText_Lang();
						smsDefaultBodyText_Lang.LanguageID = lang.LanguageID;
						smsDefaultBodyText_Lang.Id = smsDefaultBodyText.Id;
						smsDefaultBodyText_Lang.Title = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						smsDefaultBodyText_Lang.Text = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						smsDefaultBodyText_Lang.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						_dbTbl.SmsDefaultBodyText_Lang.Add(smsDefaultBodyText_Lang);
						_dbTbl.SaveChanges();
					}
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("SmsDefaultBodyText");
					base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.Error = text;
		return View(vm);
	}

	[DynamicAuthorize(ControllerName = "frmsmsDefaultBodyText", ActionName = "actEdit")]
	public ActionResult SmsDefaultBodyTextEdit(int smsDetTextId)
	{
		_003C_003Ec__DisplayClass48_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass48_0();
		CS_0024_003C_003E8__locals0.smsDetTextId = smsDetTextId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		SmsDefaultBodyTextLanguageViewModel smsDefaultBodyTextLanguageViewModel = new SmsDefaultBodyTextLanguageViewModel();
		try
		{
			if (CS_0024_003C_003E8__locals0.smsDetTextId == 0)
			{
				smsDefaultBodyTextLanguageViewModel = new SmsDefaultBodyTextLanguageViewModel();
				smsDefaultBodyTextLanguageViewModel.Id = Convert.ToInt32(CS_0024_003C_003E8__locals0.smsDetTextId);
				smsDefaultBodyTextLanguageViewModel.UserId = UserLogin.CurrentUser.UserId;
				smsDefaultBodyTextLanguageViewModel.Year1 = short.Parse(Financial.Get().Id.ToString());
				smsDefaultBodyTextLanguageViewModel.Month1 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
				smsDefaultBodyTextLanguageViewModel.RegisterDate = DateTime.Now;
				smsDefaultBodyTextLanguageViewModel.RegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			}
			else
			{
				DbSet<SmsDefaultBodyText_Lang> smsDefaultBodyText_Lang = _dbTbl.SmsDefaultBodyText_Lang;
				ParameterExpression val = Expression.Parameter(typeof(SmsDefaultBodyText_Lang), "c");
				List<SmsDefaultBodyText_Lang> list = Enumerable.ToList<SmsDefaultBodyText_Lang>((IEnumerable<SmsDefaultBodyText_Lang>)Queryable.Where<SmsDefaultBodyText_Lang>((IQueryable<SmsDefaultBodyText_Lang>)smsDefaultBodyText_Lang, Expression.Lambda<Func<SmsDefaultBodyText_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass48_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
				DbSet<SmsDefaultBodyText> smsDefaultBodyText = _dbTbl.SmsDefaultBodyText;
				val = Expression.Parameter(typeof(SmsDefaultBodyText), "m");
				SmsDefaultBodyText smsDefaultBodyText2 = Queryable.FirstOrDefault<SmsDefaultBodyText>((IQueryable<SmsDefaultBodyText>)smsDefaultBodyText, Expression.Lambda<Func<SmsDefaultBodyText, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass48_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) ?? new SmsDefaultBodyText();
				List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<SmsDefaultBodyText_Lang, CommonMultiLanguageViewModel>((IEnumerable<SmsDefaultBodyText_Lang>)list, (Func<SmsDefaultBodyText_Lang, CommonMultiLanguageViewModel>)((SmsDefaultBodyText_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.Title,
					LanguageId = item.LanguageID
				})));
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = smsDefaultBodyText2.Title,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<SmsDefaultBodyText_Lang, CommonMultiLanguageViewModel>((IEnumerable<SmsDefaultBodyText_Lang>)list, (Func<SmsDefaultBodyText_Lang, CommonMultiLanguageViewModel>)((SmsDefaultBodyText_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.Text,
					LanguageId = item.LanguageID
				})));
				list3.Add(new CommonMultiLanguageViewModel
				{
					Value = smsDefaultBodyText2.Text,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<SmsDefaultBodyText_Lang, CommonMultiLanguageViewModel>((IEnumerable<SmsDefaultBodyText_Lang>)list, (Func<SmsDefaultBodyText_Lang, CommonMultiLanguageViewModel>)((SmsDefaultBodyText_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.Description,
					LanguageId = item.LanguageID
				})));
				list4.Add(new CommonMultiLanguageViewModel
				{
					Value = smsDefaultBodyText2.Description,
					LanguageId = result
				});
				smsDefaultBodyTextLanguageViewModel = new SmsDefaultBodyTextLanguageViewModel
				{
					Id = smsDefaultBodyText2.Id,
					UserId = smsDefaultBodyText2.UserId,
					Year1 = smsDefaultBodyText2.Year1,
					Month1 = smsDefaultBodyText2.Month1,
					RegisterDate = smsDefaultBodyText2.RegisterDate,
					RegisterDatePersian = smsDefaultBodyText2.RegisterDatePersian,
					GroupId = smsDefaultBodyText2.GroupId,
					GUId = smsDefaultBodyText2.GUId,
					AppType = smsDefaultBodyText2.AppType,
					LanguageID = smsDefaultBodyText2.LanguageID,
					FirstRegisterUserId = smsDefaultBodyText2.FirstRegisterUserId,
					FirstRegisterDatePersian = smsDefaultBodyText2.FirstRegisterDatePersian,
					FirstRegisterDate = smsDefaultBodyText2.FirstRegisterDate,
					Title_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					Title = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					Text_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					Text = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					Description_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "")
				};
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		FillDropdownSmsDefaultBodyText();
		return View(smsDefaultBodyTextLanguageViewModel);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmsmsDefaultBodyText", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult SmsDefaultBodyTextEdit(SmsDefaultBodyTextLanguageViewModel vm)
	{
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass49_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass49_0();
		CS_0024_003C_003E8__locals0.vm = vm;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int countError = 0;
		FillDropdownSmsDefaultBodyText();
		try
		{
			_003C_003Ec__DisplayClass49_1 _003C_003Ec__DisplayClass49_ = new _003C_003Ec__DisplayClass49_1();
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.Title_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.Title_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.Title,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.Text_Lang))
			{
				list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.Text_Lang);
			}
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.Text,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.Description_Lang))
			{
				list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.Description_Lang);
			}
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.Description,
				LanguageId = lCID
			});
			if (CS_0024_003C_003E8__locals0.vm.Text == null && CS_0024_003C_003E8__locals0.vm.Text == "")
			{
				text = text + Messages.CheckSmsDefaultBodyText + "<br/>";
			}
			else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.vm.Text, list2))
			{
				text = text + Messages.CheckSmsDefaultBodyTextLang + "<br>";
			}
			if (text != "")
			{
				base.ViewBag.Error = text;
				return View(CS_0024_003C_003E8__locals0.vm);
			}
			DateTime now = DateTime.Now;
			CS_0024_003C_003E8__locals0.vm.UserId = UserLogin.CurrentUser.UserId;
			CS_0024_003C_003E8__locals0.vm.RegisterDate = now;
			CS_0024_003C_003E8__locals0.vm.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			CS_0024_003C_003E8__locals0.vm.Year1 = short.Parse(Financial.Get().Id.ToString());
			CS_0024_003C_003E8__locals0.vm.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
			CS_0024_003C_003E8__locals0.vm.AppType = Configuration.AppType;
			_003C_003Ec__DisplayClass49_.model = new SmsDefaultBodyText();
			if (CS_0024_003C_003E8__locals0.vm.Id > 0)
			{
				DbSet<SmsDefaultBodyText> smsDefaultBodyText = _dbTbl.SmsDefaultBodyText;
				ParameterExpression val = Expression.Parameter(typeof(SmsDefaultBodyText), "c");
				_003C_003Ec__DisplayClass49_.model = Queryable.FirstOrDefault<SmsDefaultBodyText>((IQueryable<SmsDefaultBodyText>)smsDefaultBodyText, Expression.Lambda<Func<SmsDefaultBodyText, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass49_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			}
			_003C_003Ec__DisplayClass49_.model.UserId = CS_0024_003C_003E8__locals0.vm.UserId;
			_003C_003Ec__DisplayClass49_.model.Year1 = CS_0024_003C_003E8__locals0.vm.Year1;
			_003C_003Ec__DisplayClass49_.model.Month1 = CS_0024_003C_003E8__locals0.vm.Month1;
			_003C_003Ec__DisplayClass49_.model.RegisterDate = CS_0024_003C_003E8__locals0.vm.RegisterDate;
			_003C_003Ec__DisplayClass49_.model.RegisterDatePersian = CS_0024_003C_003E8__locals0.vm.RegisterDatePersian;
			_003C_003Ec__DisplayClass49_.model.GroupId = CS_0024_003C_003E8__locals0.vm.GroupId;
			_003C_003Ec__DisplayClass49_.model.AppType = CS_0024_003C_003E8__locals0.vm.AppType;
			_003C_003Ec__DisplayClass49_.model.Title = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
			_003C_003Ec__DisplayClass49_.model.Text = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
			_003C_003Ec__DisplayClass49_.model.Description = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
			if (base.ModelState.IsValid)
			{
				text = ChkBeforeSubmitsmsDefaultBody(_003C_003Ec__DisplayClass49_.model, ref countError);
				if (countError == 0)
				{
					_dbTbl.Entry(_003C_003Ec__DisplayClass49_.model).State = EntityState.Modified;
					_dbTbl.SaveChanges();
					using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							_003C_003Ec__DisplayClass49_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass49_2();
							CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass49_;
							CS_0024_003C_003E8__locals1.lang = enumerator.Current;
							DbSet<SmsDefaultBodyText_Lang> smsDefaultBodyText_Lang = _dbTbl.SmsDefaultBodyText_Lang;
							ParameterExpression val = Expression.Parameter(typeof(SmsDefaultBodyText_Lang), "c");
							SmsDefaultBodyText_Lang smsDefaultBodyText_Lang2 = Queryable.FirstOrDefault<SmsDefaultBodyText_Lang>((IQueryable<SmsDefaultBodyText_Lang>)smsDefaultBodyText_Lang, Expression.Lambda<Func<SmsDefaultBodyText_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass49_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass49_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (smsDefaultBodyText_Lang2 != null)
							{
								smsDefaultBodyText_Lang2.Title = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								smsDefaultBodyText_Lang2.Text = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								smsDefaultBodyText_Lang2.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								_dbTbl.Entry(smsDefaultBodyText_Lang2).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							smsDefaultBodyText_Lang2 = new SmsDefaultBodyText_Lang();
							smsDefaultBodyText_Lang2.LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID;
							smsDefaultBodyText_Lang2.Id = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.Id;
							smsDefaultBodyText_Lang2.Title = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							smsDefaultBodyText_Lang2.Text = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							smsDefaultBodyText_Lang2.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							_dbTbl.SmsDefaultBodyText_Lang.Add(smsDefaultBodyText_Lang2);
							_dbTbl.SaveChanges();
						}
					}
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("SmsDefaultBodyText");
					base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.Error = text;
		return View(CS_0024_003C_003E8__locals0.vm);
	}

	[DynamicAuthorize(ControllerName = "frmsmsDefaultBodyText", ActionName = "actDelete")]
	public string SmsDefaultBodyTextDelete(int smsDetTextId)
	{
		_003C_003Ec__DisplayClass50_0 _003C_003Ec__DisplayClass50_ = new _003C_003Ec__DisplayClass50_0();
		_003C_003Ec__DisplayClass50_.smsDetTextId = smsDetTextId;
		string result = "";
		try
		{
			DbSet<SmsDefaultBodyText> smsDefaultBodyText = _dbTbl.SmsDefaultBodyText;
			ParameterExpression val = Expression.Parameter(typeof(SmsDefaultBodyText), "m");
			if (Queryable.FirstOrDefault<SmsDefaultBodyText>((IQueryable<SmsDefaultBodyText>)smsDefaultBodyText, Expression.Lambda<Func<SmsDefaultBodyText, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass50_, typeof(_003C_003Ec__DisplayClass50_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) != null)
			{
				try
				{
					mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)Enumerable.ToList<mct_Result>((IEnumerable<mct_Result>)db.SmsspDeleteSmsDefaultBodyText(_003C_003Ec__DisplayClass50_.smsDetTextId)));
					if (mct_Result != null && mct_Result.Result > 0)
					{
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("SmsDefaultBodyText");
						result = "";
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

	public string ChkBeforeSubmitsmsDefaultBody(SmsDefaultBodyText smsDefText, ref int countError)
	{
		string text = "";
		if (!smsDefText.GroupId.HasValue || smsDefText.GroupId == 0)
		{
			text = text + Messages.msgErrorSmsDefaultBodyGroupNotEnter + "<br>";
			countError++;
		}
		if (!string.IsNullOrEmpty(smsDefText.Text))
		{
			return text;
		}
		text = text + Messages.msgErrorSmsDefaultBodyTextNotEnter + "<br>";
		countError++;
		return text;
	}

	public string ChkBeforeSubmitSmsSetting(SmsSetting smsSet, ref int countError)
	{
		string text = "";
		if (string.IsNullOrEmpty(smsSet.UserName))
		{
			text = text + Messages.msgErrorSmsWebSettingUsernameNotEnter + "<br>";
			countError++;
		}
		if (string.IsNullOrEmpty(smsSet.Number))
		{
			text = text + Messages.msgErrorSmsWebSettingNumberNotEnter + "<br>";
			countError++;
		}
		if (string.IsNullOrEmpty(smsSet.Password))
		{
			text = text + Messages.msgErrorSmsWebSettingPasswordNotEnter + "<br>";
			countError++;
		}
		int result = 0;
		if (smsSet != null && smsSet.ProviderId.HasValue)
		{
			int.TryParse(smsSet.ProviderId.ToString(), out result);
		}
		switch (result)
		{
		case 25:
			if (string.IsNullOrWhiteSpace(smsSet.TokenUserName))
			{
				text = text + string.Format(Messages.msgErrorIsNotEntered, Labels.SmsSetTokenUserName) + "<br>";
				countError++;
			}
			if (string.IsNullOrWhiteSpace(smsSet.SmsCustomer))
			{
				text = text + string.Format(Messages.msgErrorIsNotEntered, Labels.SmsSetCustomer) + "<br>";
				countError++;
			}
			break;
		case 20:
			if (string.IsNullOrWhiteSpace(smsSet.ProviderUrl))
			{
				text = text + string.Format(Messages.msgErrorIsNotEntered, Labels.SmsSetProviderUrl) + "<br>";
				countError++;
			}
			else if (!smsSet.ProviderUrl.StartsWith("http"))
			{
				text = text + string.Format(Messages.msgErrorHttpRequired, Labels.SmsSetProviderUrl) + "<br>";
				countError++;
			}
			break;
		}
		return text;
	}

	[AjaxOnly]
	public string GetWsInfo()
	{
		string msgError = "";
		try
		{
			CRMIdeal.Classes.Helper.Sms sms = new CRMIdeal.Classes.Helper.Sms();
			SysSeting.Get();
			if (!VersionBuyer.SMS)
			{
				return "-1";
			}
			int freeSmsCount;
			SmsSettingInfoViewModel smsSetting = CRMIdeal.Classes.Helper.Sms.GetSmsSetting(out freeSmsCount);
			decimal num = default(decimal);
			if (smsSetting.SmsProviderId == 1)
			{
				string[] array = sms.MehrAfraz_GetUserInfo(ref msgError);
				if (array.Length < 3)
				{
					return "-3|" + msgError;
				}
				decimal.TryParse(array[5], out var result);
				decimal.TryParse(array[6], out var result2);
				decimal.TryParse(array[1], out var result3);
				decimal.TryParse(array[2], out var result4);
				string text = array[0];
				text = SmsSeting.Get().SmsWsFromNumber;
				decimal.TryParse(result3.ToString(), out var result5);
				decimal.TryParse(result4.ToString(), out var result6);
				db.SmsspUpdateWebSMSCost(result, result2, Configuration.AppType, result5);
				msgError = "1|" + smsSetting.SmsWsUserName + "|" + result5.ToString("#,0") + "|" + result6.ToString("#,0") + "|" + text + "|" + result + "|" + result2 + "|" + num;
			}
			else if (smsSetting.SmsProviderId == 2)
			{
				decimal credit = default(decimal);
				sms.SMSLine_GetCredit(ref credit, ref msgError);
				if (credit == 0m && !string.IsNullOrEmpty(msgError))
				{
					return "-3|" + Messages.ErrorInformation + "<br>" + msgError;
				}
				long countSms = 0L;
				sms.SMSLine_AllSendedSms(ref countSms, ref msgError);
				if (countSms == 0L && !string.IsNullOrEmpty(msgError))
				{
					return "-3|" + Messages.ErrorInformation + "<br>" + msgError;
				}
				decimal.TryParse(smsSetting.SmsWsFaCost, out var result7);
				decimal.TryParse(smsSetting.SmsWsEnCost, out var result8);
				decimal.TryParse(credit.ToString(), out var result9);
				decimal.TryParse(countSms.ToString(), out var result10);
				string smsWsFromNumber = smsSetting.SmsWsFromNumber;
				smsWsFromNumber = SmsSeting.Get().SmsWsFromNumber;
				decimal.TryParse(result9.ToString(), out var result11);
				decimal result12 = default(decimal);
				decimal.TryParse(result10.ToString(), out result12);
				SmsSetting smsSetting2 = Queryable.FirstOrDefault<SmsSetting>((IQueryable<SmsSetting>)_dbTbl.SmsSetting);
				if (smsSetting2 != null)
				{
					smsSetting2.LastCreditAmount = result11;
					_dbTbl.Entry(smsSetting2).State = EntityState.Modified;
					_dbTbl.SaveChanges();
				}
				msgError = "1|" + smsSetting.SmsWsUserName + "|" + result11.ToString("#,0") + "|" + result12.ToString("#,0") + "|" + smsWsFromNumber + "|" + result7 + "|" + result8 + "|" + num;
			}
			else if (smsSetting.SmsProviderId == 3)
			{
				decimal credit2 = default(decimal);
				sms.FaraPayamak_GetCredit(ref credit2, ref msgError);
				if (credit2 == 0m && !string.IsNullOrEmpty(msgError))
				{
					return "-3|" + msgError;
				}
				decimal.TryParse(smsSetting.SmsWsFaCost, out var result13);
				decimal.TryParse(smsSetting.SmsWsEnCost, out var result14);
				decimal.TryParse(credit2.ToString(), out var result15);
				string smsWsFromNumber2 = smsSetting.SmsWsFromNumber;
				smsWsFromNumber2 = SmsSeting.Get().SmsWsFromNumber;
				decimal.TryParse(result15.ToString(), out var result16);
				decimal num2 = default(decimal);
				SmsSetting smsSetting3 = Queryable.FirstOrDefault<SmsSetting>((IQueryable<SmsSetting>)_dbTbl.SmsSetting);
				if (smsSetting3 != null)
				{
					smsSetting3.LastCreditAmount = result16;
					_dbTbl.Entry(smsSetting3).State = EntityState.Modified;
					_dbTbl.SaveChanges();
				}
				msgError = "1|" + smsSetting.SmsWsUserName + "|" + result16.ToString("#,0") + "|" + num2.ToString("#,0") + "|" + smsWsFromNumber2 + "|" + result13 + "|" + result14 + "|" + num;
			}
			else if (smsSetting.SmsProviderId == 4)
			{
				decimal credit3 = default(decimal);
				sms.Asanak_GetCredit(ref credit3, ref msgError);
				if (credit3 == 0m && !string.IsNullOrEmpty(msgError))
				{
					return "-3|" + Messages.ErrorInformation + "<br>" + msgError;
				}
				decimal.TryParse(smsSetting.SmsWsFaCost, out var result17);
				decimal.TryParse(smsSetting.SmsWsEnCost, out var result18);
				decimal.TryParse(credit3.ToString(), out var result19);
				string smsWsFromNumber3 = smsSetting.SmsWsFromNumber;
				smsWsFromNumber3 = SmsSeting.Get().SmsWsFromNumber;
				decimal.TryParse(result19.ToString(), out var result20);
				decimal num3 = default(decimal);
				SmsSetting smsSetting4 = Queryable.FirstOrDefault<SmsSetting>((IQueryable<SmsSetting>)_dbTbl.SmsSetting);
				if (smsSetting4 != null)
				{
					smsSetting4.LastCreditAmount = result20;
					_dbTbl.Entry(smsSetting4).State = EntityState.Modified;
					_dbTbl.SaveChanges();
				}
				msgError = "1|" + smsSetting.SmsWsUserName + "|" + result20.ToString("#,0") + "|" + num3.ToString("#,0") + "|" + smsWsFromNumber3 + "|" + result17 + "|" + result18 + "|" + num;
			}
			else if (smsSetting.SmsProviderId == 5)
			{
				decimal credit4 = default(decimal);
				sms.PayamResan_GetCredit(ref credit4, ref msgError);
				if (credit4 == 0m && !string.IsNullOrEmpty(msgError))
				{
					return "-3|" + Messages.ErrorInformation + "<br>" + msgError;
				}
				decimal.TryParse(smsSetting.SmsWsFaCost, out var result21);
				decimal.TryParse(smsSetting.SmsWsEnCost, out var result22);
				decimal.TryParse(credit4.ToString(), out var result23);
				string smsWsFromNumber4 = smsSetting.SmsWsFromNumber;
				smsWsFromNumber4 = SmsSeting.Get().SmsWsFromNumber;
				decimal.TryParse(result23.ToString(), out var result24);
				decimal num4 = default(decimal);
				SmsSetting smsSetting5 = Queryable.FirstOrDefault<SmsSetting>((IQueryable<SmsSetting>)_dbTbl.SmsSetting);
				if (smsSetting5 != null)
				{
					smsSetting5.LastCreditAmount = result24;
					_dbTbl.Entry(smsSetting5).State = EntityState.Modified;
					_dbTbl.SaveChanges();
				}
				msgError = "1|" + smsSetting.SmsWsUserName + "|" + result24.ToString("#,0") + "|" + num4.ToString("#,0") + "|" + smsWsFromNumber4 + "|" + result21 + "|" + result22 + "|" + num;
			}
			else if (smsSetting.SmsProviderId == 6)
			{
				decimal credit5 = default(decimal);
				sms.KaveNegar_GetCredit(ref credit5, ref msgError);
				if (credit5 == 0m && !string.IsNullOrEmpty(msgError))
				{
					return "-3|" + Messages.ErrorInformation + "<br>" + msgError;
				}
				decimal.TryParse(smsSetting.SmsWsFaCost, out var result25);
				decimal.TryParse(smsSetting.SmsWsEnCost, out var result26);
				decimal.TryParse(credit5.ToString(), out var result27);
				string smsWsFromNumber5 = smsSetting.SmsWsFromNumber;
				smsWsFromNumber5 = SmsSeting.Get().SmsWsFromNumber;
				decimal.TryParse(result27.ToString(), out var result28);
				decimal num5 = default(decimal);
				SmsSetting smsSetting6 = Queryable.FirstOrDefault<SmsSetting>((IQueryable<SmsSetting>)_dbTbl.SmsSetting);
				if (smsSetting6 != null)
				{
					smsSetting6.LastCreditAmount = result28;
					_dbTbl.Entry(smsSetting6).State = EntityState.Modified;
					_dbTbl.SaveChanges();
				}
				msgError = "1|" + smsSetting.SmsWsUserName + "|" + result28.ToString("#,0") + "|" + num5.ToString("#,0") + "|" + smsWsFromNumber5 + "|" + result25 + "|" + result26 + "|" + num;
			}
			else if (smsSetting.SmsProviderId == 7)
			{
				decimal credit6 = default(decimal);
				sms.TehranPayamak_GetUserInfo(ref credit6, ref msgError);
				if (credit6 == 0m && !string.IsNullOrEmpty(msgError))
				{
					return "-3|" + msgError;
				}
				decimal.TryParse(smsSetting.SmsWsFaCost, out var result29);
				decimal.TryParse(smsSetting.SmsWsEnCost, out var result30);
				decimal.TryParse(credit6.ToString(), out var result31);
				string smsWsFromNumber6 = smsSetting.SmsWsFromNumber;
				smsWsFromNumber6 = SmsSeting.Get().SmsWsFromNumber;
				decimal.TryParse(result31.ToString(), out var result32);
				decimal num6 = default(decimal);
				SmsSetting smsSetting7 = Queryable.FirstOrDefault<SmsSetting>((IQueryable<SmsSetting>)_dbTbl.SmsSetting);
				if (smsSetting7 != null)
				{
					smsSetting7.LastCreditAmount = result32;
					_dbTbl.Entry(smsSetting7).State = EntityState.Modified;
					_dbTbl.SaveChanges();
				}
				msgError = "1|" + smsSetting.SmsWsUserName + "|" + result32.ToString("#,0") + "|" + num6.ToString("#,0") + "|" + smsWsFromNumber6 + "|" + result29 + "|" + result30 + "|" + num;
			}
			else if (smsSetting.SmsProviderId == 8)
			{
				decimal credit7 = default(decimal);
				sms.SmsFor_GetCredit(ref credit7, ref msgError);
				if (credit7 == 0m && !string.IsNullOrEmpty(msgError))
				{
					return "-3|" + msgError;
				}
				decimal.TryParse(smsSetting.SmsWsFaCost, out var result33);
				decimal.TryParse(smsSetting.SmsWsEnCost, out var result34);
				decimal.TryParse(credit7.ToString(), out var result35);
				string smsWsFromNumber7 = smsSetting.SmsWsFromNumber;
				smsWsFromNumber7 = SmsSeting.Get().SmsWsFromNumber;
				decimal.TryParse(result35.ToString(), out var result36);
				decimal num7 = default(decimal);
				SmsSetting smsSetting8 = Queryable.FirstOrDefault<SmsSetting>((IQueryable<SmsSetting>)_dbTbl.SmsSetting);
				if (smsSetting8 != null)
				{
					smsSetting8.LastCreditAmount = result36;
					_dbTbl.Entry(smsSetting8).State = EntityState.Modified;
					_dbTbl.SaveChanges();
				}
				msgError = "1|" + smsSetting.SmsWsUserName + "|" + result36.ToString("#,0") + "|" + num7.ToString("#,0") + "|" + smsWsFromNumber7 + "|" + result33 + "|" + result34 + "|" + num;
			}
			else if (smsSetting.SmsProviderId == 9)
			{
				decimal credit8 = default(decimal);
				sms.SmsAfzar_GetCredit(ref credit8, ref msgError);
				if (credit8 == 0m && !string.IsNullOrEmpty(msgError))
				{
					return "-3|" + msgError;
				}
				decimal.TryParse(smsSetting.SmsWsFaCost, out var result37);
				decimal.TryParse(smsSetting.SmsWsEnCost, out var result38);
				decimal.TryParse(credit8.ToString(), out var result39);
				string smsWsFromNumber8 = smsSetting.SmsWsFromNumber;
				smsWsFromNumber8 = SmsSeting.Get().SmsWsFromNumber;
				decimal.TryParse(result39.ToString(), out var result40);
				decimal num8 = default(decimal);
				SmsSetting smsSetting9 = Queryable.FirstOrDefault<SmsSetting>((IQueryable<SmsSetting>)_dbTbl.SmsSetting);
				if (smsSetting9 != null)
				{
					smsSetting9.LastCreditAmount = result40;
					_dbTbl.Entry(smsSetting9).State = EntityState.Modified;
					_dbTbl.SaveChanges();
				}
				msgError = "1|" + smsSetting.SmsWsUserName + "|" + result40.ToString("#,0") + "|" + num8.ToString("#,0") + "|" + smsWsFromNumber8 + "|" + result37 + "|" + result38 + "|" + num;
			}
			else if (smsSetting.SmsProviderId == 10)
			{
				decimal num9 = default(decimal);
				num = default(decimal);
				sms.GetCreditSmsCount(ref num, ref msgError, 0);
				if (num == 0m && !string.IsNullOrWhiteSpace(msgError))
				{
					return "-3|" + msgError;
				}
				decimal.TryParse(smsSetting.SmsWsFaCost, out var result41);
				decimal.TryParse(smsSetting.SmsWsEnCost, out var result42);
				decimal num10 = default(decimal);
				num10 = ((!(result41 < result42)) ? result41 : result42);
				decimal.TryParse((num * num10).ToString(), out var result43);
				string smsWsFromNumber9 = smsSetting.SmsWsFromNumber;
				smsWsFromNumber9 = SmsSeting.Get().SmsWsFromNumber;
				decimal.TryParse(result43.ToString(), out var result44);
				decimal num11 = default(decimal);
				SmsSetting smsSetting10 = Queryable.FirstOrDefault<SmsSetting>((IQueryable<SmsSetting>)_dbTbl.SmsSetting);
				if (smsSetting10 != null)
				{
					smsSetting10.LastCreditAmount = result44;
					smsSetting10.LastCreditCount = num;
					_dbTbl.Entry(smsSetting10).State = EntityState.Modified;
					_dbTbl.SaveChanges();
				}
				msgError = "1|" + smsSetting.SmsWsUserName + "|" + result44.ToString("#,0") + "|" + num11.ToString("#,0") + "|" + smsWsFromNumber9 + "|" + result41 + "|" + result42 + "|" + num;
			}
			else if (smsSetting.SmsProviderId == 11)
			{
				decimal credit9 = default(decimal);
				sms.WebOne_GetCredit(ref credit9, ref msgError);
				if (credit9 == 0m && !string.IsNullOrEmpty(msgError))
				{
					return "-3|" + msgError;
				}
				decimal.TryParse(smsSetting.SmsWsFaCost, out var result45);
				decimal.TryParse(smsSetting.SmsWsEnCost, out var result46);
				decimal.TryParse(credit9.ToString(), out var result47);
				string smsWsFromNumber10 = smsSetting.SmsWsFromNumber;
				smsWsFromNumber10 = SmsSeting.Get().SmsWsFromNumber;
				decimal.TryParse(result47.ToString(), out var result48);
				decimal num12 = default(decimal);
				SmsSetting smsSetting11 = Queryable.FirstOrDefault<SmsSetting>((IQueryable<SmsSetting>)_dbTbl.SmsSetting);
				if (smsSetting11 != null)
				{
					result48 *= result45;
					smsSetting11.LastCreditAmount = result48;
					_dbTbl.Entry(smsSetting11).State = EntityState.Modified;
					_dbTbl.SaveChanges();
				}
				msgError = "1|" + smsSetting.SmsWsUserName + "|" + result48.ToString("#,0") + "|" + num12.ToString("#,0") + "|" + smsWsFromNumber10 + "|" + result45 + "|" + result46 + "|" + num;
			}
			else if (smsSetting.SmsProviderId == 12)
			{
				decimal credit10 = default(decimal);
				decimal basePrice = default(decimal);
				sms.MeliPayamak_GetCredit(ref credit10, ref msgError, ref basePrice);
				if (credit10 == 0m && !string.IsNullOrEmpty(msgError))
				{
					return "-3|" + msgError;
				}
				decimal.TryParse(smsSetting.SmsWsFaCost, out var result49);
				if (basePrice > 0m)
				{
					result49 = basePrice;
				}
				decimal.TryParse(smsSetting.SmsWsEnCost, out var result50);
				decimal.TryParse(credit10.ToString(), out var result51);
				string smsWsFromNumber11 = smsSetting.SmsWsFromNumber;
				smsWsFromNumber11 = SmsSeting.Get().SmsWsFromNumber;
				decimal.TryParse(result51.ToString(), out var result52);
				decimal num13 = default(decimal);
				SmsSetting smsSetting12 = Queryable.FirstOrDefault<SmsSetting>((IQueryable<SmsSetting>)_dbTbl.SmsSetting);
				if (smsSetting12 != null)
				{
					smsSetting12.LastCreditAmount = result52;
					smsSetting12.FaCost = result49;
					_dbTbl.Entry(smsSetting12).State = EntityState.Modified;
					_dbTbl.SaveChanges();
				}
				msgError = "1|" + smsSetting.SmsWsUserName + "|" + result52.ToString("#,0") + "|" + num13.ToString("#,0") + "|" + smsWsFromNumber11 + "|" + result49 + "|" + result50 + "|" + num;
			}
			else if (smsSetting.SmsProviderId == 13)
			{
				decimal credit11 = default(decimal);
				decimal num14 = default(decimal);
				sms.SmsPlus_GetCredit(ref credit11, ref msgError);
				if (credit11 == 0m && !string.IsNullOrEmpty(msgError))
				{
					return "-3|" + msgError;
				}
				decimal.TryParse(smsSetting.SmsWsFaCost, out var result53);
				if (num14 > 0m)
				{
					result53 = num14;
				}
				decimal.TryParse(smsSetting.SmsWsEnCost, out var result54);
				decimal.TryParse(credit11.ToString(), out var result55);
				string smsWsFromNumber12 = smsSetting.SmsWsFromNumber;
				smsWsFromNumber12 = SmsSeting.Get().SmsWsFromNumber;
				decimal.TryParse(result55.ToString(), out var result56);
				decimal num15 = default(decimal);
				SmsSetting smsSetting13 = Queryable.FirstOrDefault<SmsSetting>((IQueryable<SmsSetting>)_dbTbl.SmsSetting);
				if (smsSetting13 != null)
				{
					smsSetting13.LastCreditAmount = result56;
					smsSetting13.FaCost = result53;
					_dbTbl.Entry(smsSetting13).State = EntityState.Modified;
					_dbTbl.SaveChanges();
				}
				msgError = "1|" + smsSetting.SmsWsUserName + "|" + result56.ToString("#,0") + "|" + num15.ToString("#,0") + "|" + smsWsFromNumber12 + "|" + result53 + "|" + result54 + "|" + num;
			}
			else if (smsSetting.SmsProviderId == 15)
			{
				decimal credit12 = default(decimal);
				decimal num16 = default(decimal);
				sms.ISms_GetCredit(ref credit12, ref msgError);
				if (credit12 == 0m && !string.IsNullOrEmpty(msgError))
				{
					return "-3|" + msgError;
				}
				decimal.TryParse(smsSetting.SmsWsFaCost, out var result57);
				if (num16 > 0m)
				{
					result57 = num16;
				}
				decimal.TryParse(smsSetting.SmsWsEnCost, out var result58);
				decimal.TryParse(credit12.ToString(), out var result59);
				string smsWsFromNumber13 = smsSetting.SmsWsFromNumber;
				smsWsFromNumber13 = SmsSeting.Get().SmsWsFromNumber;
				decimal.TryParse(result59.ToString(), out var result60);
				decimal num17 = default(decimal);
				SmsSetting smsSetting14 = Queryable.FirstOrDefault<SmsSetting>((IQueryable<SmsSetting>)_dbTbl.SmsSetting);
				if (smsSetting14 != null)
				{
					smsSetting14.LastCreditAmount = result60;
					smsSetting14.FaCost = result57;
					_dbTbl.Entry(smsSetting14).State = EntityState.Modified;
					_dbTbl.SaveChanges();
				}
				msgError = "1|" + smsSetting.SmsWsUserName + "|" + result60.ToString("#,0") + "|" + num17.ToString("#,0") + "|" + smsWsFromNumber13 + "|" + result57 + "|" + result58 + "|" + num;
			}
			else if (smsSetting.SmsProviderId == 16)
			{
				decimal credit13 = default(decimal);
				decimal num18 = default(decimal);
				sms.Nimaad_GetCredit(ref credit13, ref msgError);
				if (credit13 == 0m && !string.IsNullOrEmpty(msgError))
				{
					return "-3|" + msgError;
				}
				decimal.TryParse(smsSetting.SmsWsFaCost, out var result61);
				if (num18 > 0m)
				{
					result61 = num18;
				}
				decimal.TryParse(smsSetting.SmsWsEnCost, out var result62);
				decimal.TryParse(credit13.ToString(), out var result63);
				string smsWsFromNumber14 = smsSetting.SmsWsFromNumber;
				smsWsFromNumber14 = SmsSeting.Get().SmsWsFromNumber;
				decimal.TryParse(result63.ToString(), out var result64);
				decimal num19 = default(decimal);
				SmsSetting smsSetting15 = Queryable.FirstOrDefault<SmsSetting>((IQueryable<SmsSetting>)_dbTbl.SmsSetting);
				if (smsSetting15 != null)
				{
					smsSetting15.LastCreditAmount = result64;
					smsSetting15.FaCost = result61;
					_dbTbl.Entry(smsSetting15).State = EntityState.Modified;
					_dbTbl.SaveChanges();
				}
				msgError = "1|" + smsSetting.SmsWsUserName + "|" + result64.ToString("#,0") + "|" + num19.ToString("#,0") + "|" + smsWsFromNumber14 + "|" + result61 + "|" + result62 + "|" + num;
			}
			else if (smsSetting.SmsProviderId == 17)
			{
				decimal credit14 = default(decimal);
				decimal num20 = default(decimal);
				sms.FarazSms_GetCredit(ref credit14, ref msgError);
				if (credit14 == 0m && !string.IsNullOrEmpty(msgError))
				{
					return "-3|" + msgError;
				}
				decimal.TryParse(smsSetting.SmsWsFaCost, out var result65);
				if (num20 > 0m)
				{
					result65 = num20;
				}
				decimal.TryParse(smsSetting.SmsWsEnCost, out var result66);
				decimal.TryParse(credit14.ToString(), out var result67);
				string smsWsFromNumber15 = smsSetting.SmsWsFromNumber;
				smsWsFromNumber15 = SmsSeting.Get().SmsWsFromNumber;
				decimal.TryParse(result67.ToString(), out var result68);
				decimal num21 = default(decimal);
				SmsSetting smsSetting16 = Queryable.FirstOrDefault<SmsSetting>((IQueryable<SmsSetting>)_dbTbl.SmsSetting);
				if (smsSetting16 != null)
				{
					smsSetting16.LastCreditAmount = result68;
					smsSetting16.FaCost = result65;
					_dbTbl.Entry(smsSetting16).State = EntityState.Modified;
					_dbTbl.SaveChanges();
				}
				msgError = "1|" + smsSetting.SmsWsUserName + "|" + result68.ToString("#,0") + "|" + num21.ToString("#,0") + "|" + smsWsFromNumber15 + "|" + result65 + "|" + result66 + "|" + num;
			}
			else if (smsSetting.SmsProviderId == 18)
			{
				decimal credit15 = default(decimal);
				decimal num22 = default(decimal);
				sms.Sharif_GetCredit(ref credit15, ref msgError);
				if (credit15 == 0m && !string.IsNullOrEmpty(msgError))
				{
					return "-3|" + msgError;
				}
				decimal.TryParse(smsSetting.SmsWsFaCost, out var result69);
				if (num22 > 0m)
				{
					result69 = num22;
				}
				decimal.TryParse(smsSetting.SmsWsEnCost, out var result70);
				decimal.TryParse(credit15.ToString(), out var result71);
				string smsWsFromNumber16 = smsSetting.SmsWsFromNumber;
				smsWsFromNumber16 = SmsSeting.Get().SmsWsFromNumber;
				decimal.TryParse(result71.ToString(), out var result72);
				decimal num23 = default(decimal);
				SmsSetting smsSetting17 = Queryable.FirstOrDefault<SmsSetting>((IQueryable<SmsSetting>)_dbTbl.SmsSetting);
				if (smsSetting17 != null)
				{
					smsSetting17.LastCreditAmount = result72;
					smsSetting17.FaCost = result69;
					_dbTbl.Entry(smsSetting17).State = EntityState.Modified;
					_dbTbl.SaveChanges();
				}
				msgError = "1|" + smsSetting.SmsWsUserName + "|" + result72.ToString("#,0") + "|" + num23.ToString("#,0") + "|" + smsWsFromNumber16 + "|" + result69 + "|" + result70 + "|" + num;
			}
			else if (smsSetting.SmsProviderId == 19)
			{
				decimal credit16 = default(decimal);
				decimal num24 = default(decimal);
				sms.SunWay_GetCredit(ref credit16, ref msgError);
				if (credit16 == 0m && !string.IsNullOrEmpty(msgError))
				{
					return "-3|" + msgError;
				}
				decimal.TryParse(smsSetting.SmsWsFaCost, out var result73);
				if (num24 > 0m)
				{
					result73 = num24;
				}
				decimal.TryParse(smsSetting.SmsWsEnCost, out var result74);
				decimal.TryParse(credit16.ToString(), out var result75);
				string smsWsFromNumber17 = smsSetting.SmsWsFromNumber;
				smsWsFromNumber17 = SmsSeting.Get().SmsWsFromNumber;
				decimal.TryParse(result75.ToString(), out var result76);
				decimal num25 = default(decimal);
				SmsSetting smsSetting18 = Queryable.FirstOrDefault<SmsSetting>((IQueryable<SmsSetting>)_dbTbl.SmsSetting);
				if (smsSetting18 != null)
				{
					smsSetting18.LastCreditAmount = result76;
					smsSetting18.FaCost = result73;
					_dbTbl.Entry(smsSetting18).State = EntityState.Modified;
					_dbTbl.SaveChanges();
				}
				msgError = "1|" + smsSetting.SmsWsUserName + "|" + result76.ToString("#,0") + "|" + num25.ToString("#,0") + "|" + smsWsFromNumber17 + "|" + result73 + "|" + result74 + "|" + num;
			}
			else if (smsSetting.SmsProviderId == 20)
			{
				decimal credit17 = default(decimal);
				decimal num26 = default(decimal);
				sms.CandooSms_GetCredit(ref credit17, ref msgError);
				if (credit17 == 0m && !string.IsNullOrEmpty(msgError))
				{
					return "-3|" + msgError;
				}
				decimal.TryParse(smsSetting.SmsWsFaCost, out var result77);
				if (num26 > 0m)
				{
					result77 = num26;
				}
				decimal.TryParse(smsSetting.SmsWsEnCost, out var result78);
				decimal.TryParse(credit17.ToString(), out var result79);
				string smsWsFromNumber18 = smsSetting.SmsWsFromNumber;
				smsWsFromNumber18 = SmsSeting.Get().SmsWsFromNumber;
				decimal.TryParse(result79.ToString(), out var result80);
				decimal num27 = default(decimal);
				SmsSetting smsSetting19 = Queryable.FirstOrDefault<SmsSetting>((IQueryable<SmsSetting>)_dbTbl.SmsSetting);
				if (smsSetting19 != null)
				{
					smsSetting19.LastCreditAmount = result80;
					smsSetting19.FaCost = result77;
					_dbTbl.Entry(smsSetting19).State = EntityState.Modified;
					_dbTbl.SaveChanges();
				}
				msgError = "1|" + smsSetting.SmsWsUserName + "|" + result80.ToString("#,0") + "|" + num27.ToString("#,0") + "|" + smsWsFromNumber18 + "|" + result77 + "|" + result78 + "|" + num;
			}
			else if (smsSetting.SmsProviderId == 21)
			{
				decimal credit18 = default(decimal);
				decimal num28 = default(decimal);
				sms.ParmisSms_GetCredit(ref credit18, ref msgError);
				if (credit18 == 0m && !string.IsNullOrEmpty(msgError))
				{
					return "-3|" + msgError;
				}
				decimal.TryParse(smsSetting.SmsWsFaCost, out var result81);
				if (num28 > 0m)
				{
					result81 = num28;
				}
				decimal.TryParse(smsSetting.SmsWsEnCost, out var result82);
				decimal.TryParse(credit18.ToString(), out var result83);
				string smsWsFromNumber19 = smsSetting.SmsWsFromNumber;
				smsWsFromNumber19 = SmsSeting.Get().SmsWsFromNumber;
				decimal.TryParse(result83.ToString(), out var result84);
				decimal num29 = default(decimal);
				SmsSetting smsSetting20 = Queryable.FirstOrDefault<SmsSetting>((IQueryable<SmsSetting>)_dbTbl.SmsSetting);
				if (smsSetting20 != null)
				{
					smsSetting20.LastCreditAmount = result84;
					smsSetting20.FaCost = result81;
					_dbTbl.Entry(smsSetting20).State = EntityState.Modified;
					_dbTbl.SaveChanges();
				}
				msgError = "1|" + smsSetting.SmsWsUserName + "|" + result84.ToString("#,0") + "|" + num29.ToString("#,0") + "|" + smsWsFromNumber19 + "|" + result81 + "|" + result82 + "|" + num;
			}
			else if (smsSetting.SmsProviderId == 22)
			{
				decimal credit19 = default(decimal);
				decimal num30 = default(decimal);
				sms.SmsMelli_GetCredit(ref credit19, ref msgError);
				if (credit19 == 0m && !string.IsNullOrEmpty(msgError))
				{
					return "-3|" + msgError;
				}
				decimal.TryParse(smsSetting.SmsWsFaCost, out var result85);
				if (num30 > 0m)
				{
					result85 = num30;
				}
				decimal.TryParse(smsSetting.SmsWsEnCost, out var result86);
				decimal.TryParse(credit19.ToString(), out var result87);
				string smsWsFromNumber20 = smsSetting.SmsWsFromNumber;
				smsWsFromNumber20 = SmsSeting.Get().SmsWsFromNumber;
				decimal.TryParse(result87.ToString(), out var result88);
				decimal num31 = default(decimal);
				SmsSetting smsSetting21 = Queryable.FirstOrDefault<SmsSetting>((IQueryable<SmsSetting>)_dbTbl.SmsSetting);
				if (smsSetting21 != null)
				{
					smsSetting21.LastCreditAmount = result88;
					smsSetting21.FaCost = result85;
					_dbTbl.Entry(smsSetting21).State = EntityState.Modified;
					_dbTbl.SaveChanges();
				}
				msgError = "1|" + smsSetting.SmsWsUserName + "|" + result88.ToString("#,0") + "|" + num31.ToString("#,0") + "|" + smsWsFromNumber20 + "|" + result85 + "|" + result86 + "|" + num;
			}
			else if (smsSetting.SmsProviderId == 23)
			{
				decimal credit20 = default(decimal);
				decimal num32 = default(decimal);
				sms.ParsGreen_GetCredit(ref credit20, ref msgError);
				if (credit20 == 0m && !string.IsNullOrEmpty(msgError))
				{
					return "-3|" + msgError;
				}
				decimal.TryParse(smsSetting.SmsWsFaCost, out var result89);
				if (num32 > 0m)
				{
					result89 = num32;
				}
				decimal.TryParse(smsSetting.SmsWsEnCost, out var result90);
				decimal.TryParse(credit20.ToString(), out var result91);
				string smsWsFromNumber21 = smsSetting.SmsWsFromNumber;
				smsWsFromNumber21 = SmsSeting.Get().SmsWsFromNumber;
				decimal.TryParse(result91.ToString(), out var result92);
				decimal num33 = default(decimal);
				SmsSetting smsSetting22 = Queryable.FirstOrDefault<SmsSetting>((IQueryable<SmsSetting>)_dbTbl.SmsSetting);
				if (smsSetting22 != null)
				{
					smsSetting22.LastCreditAmount = result92;
					smsSetting22.FaCost = result89;
					_dbTbl.Entry(smsSetting22).State = EntityState.Modified;
					_dbTbl.SaveChanges();
				}
				msgError = "1|" + smsSetting.SmsWsUserName + "|" + result92.ToString("#,0") + "|" + num33.ToString("#,0") + "|" + smsWsFromNumber21 + "|" + result89 + "|" + result90 + "|" + num;
			}
			else if (smsSetting.SmsProviderId == 24)
			{
				decimal credit21 = default(decimal);
				decimal num34 = default(decimal);
				sms.Armaghan_GetCredit(ref credit21, ref msgError);
				if (credit21 == 0m && !string.IsNullOrEmpty(msgError))
				{
					return "-3|" + msgError;
				}
				decimal.TryParse(smsSetting.SmsWsFaCost, out var result93);
				if (num34 > 0m)
				{
					result93 = num34;
				}
				decimal.TryParse(smsSetting.SmsWsEnCost, out var result94);
				decimal.TryParse(credit21.ToString(), out var result95);
				string smsWsFromNumber22 = smsSetting.SmsWsFromNumber;
				smsWsFromNumber22 = SmsSeting.Get().SmsWsFromNumber;
				decimal.TryParse(result95.ToString(), out var result96);
				decimal num35 = default(decimal);
				SmsSetting smsSetting23 = Queryable.FirstOrDefault<SmsSetting>((IQueryable<SmsSetting>)_dbTbl.SmsSetting);
				if (smsSetting23 != null)
				{
					smsSetting23.LastCreditAmount = result96;
					smsSetting23.FaCost = result93;
					_dbTbl.Entry(smsSetting23).State = EntityState.Modified;
					_dbTbl.SaveChanges();
				}
				msgError = "1|" + smsSetting.SmsWsUserName + "|" + result96.ToString("#,0") + "|" + num35.ToString("#,0") + "|" + smsWsFromNumber22 + "|" + result93 + "|" + result94 + "|" + num;
			}
			else if (smsSetting.SmsProviderId == 25)
			{
				decimal credit22 = default(decimal);
				decimal num36 = default(decimal);
				sms.Rahyab_GetCredit(ref credit22, ref msgError);
				if (credit22 == 0m && !string.IsNullOrEmpty(msgError))
				{
					return "-3|" + msgError;
				}
				decimal.TryParse(smsSetting.SmsWsFaCost, out var result97);
				if (num36 > 0m)
				{
					result97 = num36;
				}
				decimal.TryParse(smsSetting.SmsWsEnCost, out var result98);
				decimal.TryParse(credit22.ToString(), out var result99);
				string smsWsFromNumber23 = smsSetting.SmsWsFromNumber;
				smsWsFromNumber23 = SmsSeting.Get().SmsWsFromNumber;
				decimal.TryParse(result99.ToString(), out var result100);
				decimal num37 = default(decimal);
				SmsSetting smsSetting24 = Queryable.FirstOrDefault<SmsSetting>((IQueryable<SmsSetting>)_dbTbl.SmsSetting);
				if (smsSetting24 != null)
				{
					smsSetting24.LastCreditAmount = result100;
					smsSetting24.FaCost = result97;
					_dbTbl.Entry(smsSetting24).State = EntityState.Modified;
					_dbTbl.SaveChanges();
				}
				msgError = "1|" + smsSetting.SmsWsUserName + "|" + result100.ToString("#,0") + "|" + num37.ToString("#,0") + "|" + smsWsFromNumber23 + "|" + result97 + "|" + result98 + "|" + num;
			}
			else if (smsSetting.SmsProviderId == 26)
			{
				decimal credit23 = default(decimal);
				decimal num38 = default(decimal);
				sms.IPPanel_GetCredit(ref credit23, ref msgError);
				if (credit23 == 0m && !string.IsNullOrEmpty(msgError))
				{
					return "-3|" + msgError;
				}
				decimal.TryParse(smsSetting.SmsWsFaCost, out var result101);
				if (num38 > 0m)
				{
					result101 = num38;
				}
				decimal.TryParse(smsSetting.SmsWsEnCost, out var result102);
				decimal.TryParse(credit23.ToString(), out var result103);
				string smsWsFromNumber24 = smsSetting.SmsWsFromNumber;
				smsWsFromNumber24 = SmsSeting.Get().SmsWsFromNumber;
				decimal.TryParse(result103.ToString(), out var result104);
				decimal num39 = default(decimal);
				SmsSetting smsSetting25 = Queryable.FirstOrDefault<SmsSetting>((IQueryable<SmsSetting>)_dbTbl.SmsSetting);
				if (smsSetting25 != null)
				{
					smsSetting25.LastCreditAmount = result104;
					smsSetting25.FaCost = result101;
					_dbTbl.Entry(smsSetting25).State = EntityState.Modified;
					_dbTbl.SaveChanges();
				}
				msgError = "1|" + smsSetting.SmsWsUserName + "|" + result104.ToString("#,0") + "|" + num39.ToString("#,0") + "|" + smsWsFromNumber24 + "|" + result101 + "|" + result102 + "|" + num;
			}
			SmsSeting.Update();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			msgError = "-2";
		}
		return msgError;
	}

	[AjaxOnly]
	public string SendsmsCreditCheck(SmsSendViewModel newSms, string actionName, string sendtype, int single, string smsModelStr = "")
	{
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		string result = "-1";
		try
		{
			int freeSmsCount;
			SmsSettingInfoViewModel smsSetting = CRMIdeal.Classes.Helper.Sms.GetSmsSetting(out freeSmsCount);
			CRMIdeal.Classes.Helper.Sms sms = new CRMIdeal.Classes.Helper.Sms();
			int num = 0;
			bool flag = false;
			int num2 = 0;
			int num3 = 0;
			int num4 = 1;
			long num5 = ReturnRemainCredit();
			decimal result2 = default(decimal);
			decimal.TryParse(num5.ToString(), out result2);
			decimal num6 = default(decimal);
			decimal num7 = default(decimal);
			decimal num8 = default(decimal);
			string text = "";
			if (!string.IsNullOrWhiteSpace(smsModelStr) && newSms == null)
			{
				newSms = new JavaScriptSerializer().Deserialize<SmsSendViewModel>(smsModelStr);
			}
			if (newSms != null)
			{
				flag = newSms.SendWithName;
				num2 = newSms.SmsNumberCount;
				num3 = newSms.SmsBodyCount;
				num4 = newSms.SmsbodyCost;
				_ = newSms.UserCost;
				num7 = newSms.AllWnBodyCost;
				text = newSms.SmsSendBody ?? "";
				if (newSms.HavePassword.HasValue && newSms.HavePassword.Value && !string.IsNullOrWhiteSpace(newSms.Password))
				{
					text = text.Replace("[******]", newSms.Password);
				}
			}
			if (!flag)
			{
				if (single == 1)
				{
					int num9 = 0;
					num9 = sms.ReturnSmsBodyLength(text);
					if (num9 > 0)
					{
						num3 = sms.ReturnSmsBodyCountLatin(num9);
						num4 = int.Parse(smsSetting.SmsWsEnCost);
					}
					else if (num9 < 0)
					{
						num9 *= -1;
						num3 = sms.ReturnSmsBodyCountFarsi(num9);
						num4 = int.Parse(smsSetting.SmsWsFaCost);
					}
					num6 = num3 * num4;
					num8 += (decimal)num3;
				}
				else
				{
					if (num3 == 0 && num4 == 0)
					{
						int num10 = 0;
						num10 = sms.ReturnSmsBodyLength(text);
						if (num10 > 0)
						{
							num3 = sms.ReturnSmsBodyCountLatin(num10);
							num4 = int.Parse(smsSetting.SmsWsEnCost);
						}
						else if (num10 < 0)
						{
							num10 *= -1;
							num3 = sms.ReturnSmsBodyCountFarsi(num10);
							num4 = int.Parse(smsSetting.SmsWsFaCost);
						}
					}
					num6 = num2 * num3 * num4;
					num8 += (decimal)(num2 * num3);
				}
			}
			else
			{
				num6 = num7;
				num8 = newSms.AllWnBodyCount;
			}
			if (!string.IsNullOrWhiteSpace(sendtype) && single == 0)
			{
				int result3 = 0;
				int.TryParse(smsSetting.SmsProviderId.ToString(), out result3);
				if (result3 != 0 && result3 != 14 && result3 != 3)
				{
					string text2 = sendtype.ToLower();
					bool flag2 = false;
					if (text2 == "webservice")
					{
						flag2 = true;
					}
					if (freeSmsCount <= 0 && flag2)
					{
						string wsInfo = GetWsInfo();
						if (!string.IsNullOrWhiteSpace(wsInfo))
						{
							if (wsInfo == "-1")
							{
								return "False|||" + Messages.msgNotAccessWebServiceSms + "|" + actionName + "|" + sendtype + "|" + single;
							}
							if (wsInfo == "-2")
							{
								return "False|||" + Messages.msgErrorNotAccessInternet + "|" + actionName + "|" + sendtype + "|" + single;
							}
							string[] array = wsInfo.Split(new char[1] { '|' });
							if (array != null && array.Length != 0)
							{
								string text3 = array[0];
								string text4 = "";
								if (array.Length > 1)
								{
									text4 = array[1];
								}
								if (!string.IsNullOrWhiteSpace(text3))
								{
									if (text3 == "-3")
									{
										if (!string.IsNullOrWhiteSpace(text4))
										{
											return "False|||" + text4 + "|" + actionName + "|" + sendtype + "|" + single;
										}
										return "False|||" + Messages.ErrorInformation + "|" + actionName + "|" + sendtype + "|" + single;
									}
									decimal result4 = default(decimal);
									string text5 = "";
									if (array.Length > 2)
									{
										text5 = array[2];
										text5 = text5.Replace(",", "");
										decimal.TryParse(text5, out result4);
									}
									decimal result5 = default(decimal);
									if (array.Length >= 7)
									{
										decimal.TryParse(array[7].Replace(",", ""), out result5);
									}
									if (result5 != 0m)
									{
										decimal num11 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)_dbII.SmsspReturnSumSMSTankRequestBodyCount(DateTime.Now)).GetValueOrDefault();
										if (result5 - num11 < num8)
										{
											return "False|||" + Messages.msgErrorEndSmsSendAllCredit + "|" + actionName + "|" + sendtype + "|" + single;
										}
									}
									else if (!string.IsNullOrWhiteSpace(text5))
									{
										decimal valueOrDefault = Enumerable.FirstOrDefault<decimal?>((IEnumerable<decimal?>)_dbII.SmsspReturnSumSMSTankRequestBodyCost(DateTime.Now)).GetValueOrDefault();
										if (result4 - valueOrDefault < num6)
										{
											return "False|||" + Messages.msgErrorEndSmsSendAllCredit + "|" + actionName + "|" + sendtype + "|" + single;
										}
									}
								}
							}
						}
					}
				}
			}
			decimal num12 = result2 - num6;
			if (result2 > 0m && result2 >= num6)
			{
				return UserLogin.IsUserAccess("frmSendSMS", actionName, UserLogin.CurrentUser) + "||||" + actionName + "|" + sendtype + "|" + single;
			}
			if (freeSmsCount <= 0 && num12 < 0m)
			{
				decimal.TryParse(num12.ToString(), out var _);
				return "False|" + num12.ToString("#,0") + Labels.CurrencyFa + "|Red|" + Messages.msgErrorEndSmsSendUserCredit + "|" + actionName + "|" + sendtype + "|" + single;
			}
			if ((decimal)CRMIdeal.Classes.Helper.Sms.GetSmsLastCreditAmount() < num6)
			{
				return "False|||" + Messages.msgErrorEndSmsSendAllCredit + "|" + actionName + "|" + sendtype + "|" + single;
			}
			if (sendtype == "webService")
			{
				num = CRMIdeal.Classes.Helper.Sms.GetFreeSmsCount();
				if (num > 0)
				{
					int.TryParse(smsSetting.SmsWsFaCost, out var result7);
					if (num6 > (decimal)(num * result7))
					{
						return "|||" + Messages.msgErrorFreeSendSms;
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = "|||" + Messages.msgErrorRunFunction;
		}
		return result;
	}

	[AjaxOnly]
	public JsonResult ReturnCompanyInfoFromMobileNumber(string mobile)
	{
		SmsspReturnCompanyInfoFromMobileNumber_Result data = new SmsspReturnCompanyInfoFromMobileNumber_Result();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (!string.IsNullOrEmpty(mobile))
			{
				data = Enumerable.FirstOrDefault<SmsspReturnCompanyInfoFromMobileNumber_Result>((IEnumerable<SmsspReturnCompanyInfoFromMobileNumber_Result>)db.SmsspReturnCompanyInfoFromMobileNumber(mobile, lCID, result)) ?? new SmsspReturnCompanyInfoFromMobileNumber_Result();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	public JsonResult ReturnCmpPersenInfo(int prsId)
	{
		SmsspReturnCompanyPersonInfo_Result data = new SmsspReturnCompanyPersonInfo_Result();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (prsId > 0)
			{
				data = Enumerable.FirstOrDefault<SmsspReturnCompanyPersonInfo_Result>((IEnumerable<SmsspReturnCompanyPersonInfo_Result>)dbI.SmsspReturnCompanyPersonInfo(prsId, lCID, result)) ?? new SmsspReturnCompanyPersonInfo_Result();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public string SendSmsGroupWeb(SmsSendViewModel newSms)
	{
		string result = "-1";
		int countError = 0;
		try
		{
			CRMIdeal.Classes.Helper.Sms.GetSmsSetting(out var _);
			if (newSms != null)
			{
				result = ChkBeforeSendSmSSingle(newSms, ref countError, 0);
				if (countError == 0)
				{
					CRMIdeal.Classes.Helper.Sms sms = new CRMIdeal.Classes.Helper.Sms();
					if (!newSms.SendWithName)
					{
						newSms.SendType = 2;
						newSms.Sid = -1;
						result = sms.SendSms(newSms);
						return result;
					}
					newSms.SendType = 3;
					newSms.Sid = -1;
					result = sms.SendSmsOneToOne(newSms);
					return result;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[AjaxOnly]
	public string SendSmsGroupToWebTank(SmsSendViewModel newSms)
	{
		string result = "-1";
		int countError = 0;
		try
		{
			CRMIdeal.Classes.Helper.Sms.GetSmsSetting(out var _);
			if (newSms != null)
			{
				result = ChkBeforeSendSmSSingle(newSms, ref countError, 0);
				if (countError == 0)
				{
					CRMIdeal.Classes.Helper.Sms sms = new CRMIdeal.Classes.Helper.Sms();
					if (!newSms.SendWithName)
					{
						newSms.SendType = 2;
						newSms.Sid = -1;
						result = sms.SendSmsWebTank(newSms);
						return result;
					}
					newSms.SendType = 3;
					newSms.Sid = -1;
					result = sms.SendSmsOneToOneWebTank(newSms);
					return result;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[AjaxOnly]
	public string SendSmsSingleWeb(SmsSendViewModel newSms)
	{
		string result = "-1";
		int countError = 0;
		try
		{
			CRMIdeal.Classes.Helper.Sms.GetSmsSetting(out var _);
			if (newSms != null)
			{
				result = ChkBeforeSendSmSSingle(newSms, ref countError, 1);
				if (countError == 0)
				{
					CRMIdeal.Classes.Helper.Sms sms = new CRMIdeal.Classes.Helper.Sms();
					newSms.SendType = 1;
					newSms.Sid = -1;
					newSms.SmsNumberCount = 1;
					newSms.Password = ((!string.IsNullOrEmpty(newSms.Password)) ? XorCipher.DecryptByPublicKey(newSms.Password) : string.Empty);
					result = sms.SendSmsSingle(newSms);
					return result;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[AjaxOnly]
	public string SendSmsSingleToWebTank(SmsSendViewModel newSms)
	{
		string result = "-1";
		int countError = 0;
		try
		{
			CRMIdeal.Classes.Helper.Sms.GetSmsSetting(out var _);
			if (newSms != null)
			{
				result = ChkBeforeSendSmSSingle(newSms, ref countError, 1);
				if (countError == 0)
				{
					CRMIdeal.Classes.Helper.Sms sms = new CRMIdeal.Classes.Helper.Sms();
					newSms.SendType = 1;
					newSms.Sid = -1;
					newSms.SmsNumberCount = 1;
					newSms.Password = ((!string.IsNullOrEmpty(newSms.Password)) ? XorCipher.DecryptByPublicKey(newSms.Password) : string.Empty);
					result = sms.SendSmsSingleWebTank(newSms);
					return result;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[AjaxOnly]
	public string SendSmsSingleGsm(SmsSendViewModel newSms)
	{
		string result = "-1";
		int countError = 0;
		try
		{
			CRMIdeal.Classes.Helper.Sms.GetSmsSetting(out var _);
			if (newSms != null)
			{
				result = ChkBeforeSendSmSSingle(newSms, ref countError, 1);
				if (countError == 0)
				{
					CRMIdeal.Classes.Helper.Sms sms = new CRMIdeal.Classes.Helper.Sms();
					newSms.SendType = 21;
					newSms.Sid = -1;
					newSms.SmsNumberCount = 1;
					newSms.Password = ((!string.IsNullOrEmpty(newSms.Password)) ? XorCipher.DecryptByPublicKey(newSms.Password) : string.Empty);
					result = sms.SendSmsToGsmServer(newSms);
					return result;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[AjaxOnly]
	public string SendSmsGroupGsm(SmsSendViewModel newSms)
	{
		string result = "-1";
		int countError = 0;
		try
		{
			CRMIdeal.Classes.Helper.Sms.GetSmsSetting(out var _);
			if (newSms != null)
			{
				result = ChkBeforeSendSmSSingle(newSms, ref countError, 0);
				if (countError == 0)
				{
					CRMIdeal.Classes.Helper.Sms sms = new CRMIdeal.Classes.Helper.Sms();
					if (!newSms.SendWithName)
					{
						newSms.SendType = 22;
						newSms.Sid = -1;
						newSms.Password = ((!string.IsNullOrEmpty(newSms.Password)) ? XorCipher.DecryptByPublicKey(newSms.Password) : string.Empty);
						result = sms.SendSmsToGsmServer(newSms);
						return result;
					}
					newSms.SendType = 23;
					result = sms.SendSmsToGsmServerOneToOne(newSms);
					return result;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public string ChkBeforeSendSmSSingle(SmsSendViewModel newSms, ref int countError, int sendType)
	{
		string text = "";
		if (string.IsNullOrEmpty(newSms.SmsSendBody))
		{
			text = text + Messages.msgNotInsertSmsBody + "<br>";
			countError++;
		}
		if (sendType == 1)
		{
			if (!string.IsNullOrEmpty(newSms.SmsToNumber))
			{
				return text;
			}
			text = text + Messages.msgNotInsertSmsToNumber + "<br>";
			countError++;
		}
		return text;
	}

	public long ReturnRemainCredit()
	{
		long result = 0L;
		try
		{
			SmsReturnUserSendCreditAndSendedCC_Result smsReturnUserSendCreditAndSendedCC_Result = Queryable.FirstOrDefault<SmsReturnUserSendCreditAndSendedCC_Result>(db.SmsReturnUserSendCreditAndSendedCC(UserLogin.CurrentUser.UserId));
			if (smsReturnUserSendCreditAndSendedCC_Result != null)
			{
				long.TryParse(smsReturnUserSendCreditAndSendedCC_Result.RemainCredit.ToString(), out result);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public ActionResult ShowSmsSendedBody(string bodyText)
	{
		base.ViewBag.Body = bodyText;
		return View();
	}

	[AjaxOnly]
	public string ReSendSmsGroup(string fromDate, string toDate, int userId, int smsHeadId, int statusId)
	{
		string result = "-1";
		bool flag = false;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int result3 = 0;
			int value = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
				value = UserLogin.CurrentUser.UserId;
			}
			db.SmsspDeleteSmsTempMobileNumbers(UserLogin.CurrentUser.UserId);
			List<mct_SmsspSelectSendedDetail_Result> list = new List<mct_SmsspSelectSendedDetail_Result>();
			if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate) && userId != 0 && smsHeadId != 0)
			{
				toDate = toDate.Replace("/", "").Replace("-", "").Replace("\\", "")
					.Replace(" ", "")
					.Replace("_", "");
				fromDate = fromDate.Replace("/", "").Replace("-", "").Replace("\\", "")
					.Replace(" ", "")
					.Replace("_", "");
				DateTime value2 = DateTime.Now;
				DateTime value3 = DateTime.Now;
				if (!string.IsNullOrEmpty(fromDate))
				{
					value2 = DateTime.Parse(PersianDate.GetFormatetdDate(fromDate.Replace("/", "")) + " 00:00:00", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(toDate))
				{
					value3 = DateTime.Parse(PersianDate.GetFormatetdDate(toDate.Replace("/", "")) + " 23:59:59", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				string unspecify = Labels.Unspecify;
				list = Enumerable.ToList<mct_SmsspSelectSendedDetail_Result>((IEnumerable<mct_SmsspSelectSendedDetail_Result>)db.mfi_SmsspSelectSendedDetail(smsHeadId.ToString(), fromDate, toDate, userId.ToString(), statusId.ToString(), value2, value3, lCID, result2, unspecify, result3, value));
			}
			DateTime now = DateTime.Now;
			foreach (mct_SmsspSelectSendedDetail_Result item in list)
			{
				SmsTempMobileNumbers smsTempMobileNumbers = new SmsTempMobileNumbers
				{
					Selector = true,
					Mobile = item.Number,
					CompanyName = ((item.CompanyName != null) ? item.CompanyName : ""),
					PersonName = item.PersonName
				};
				int.TryParse(item.CompanyId.ToString(), out var result4);
				smsTempMobileNumbers.CompanyId = result4;
				int.TryParse(item.CompanyPersonId.ToString(), out var result5);
				smsTempMobileNumbers.CompanyPersonId = result5;
				smsTempMobileNumbers.MobileLength = item.Number.Length;
				smsTempMobileNumbers.MobilePreNum = item.Number.Substring(0, 2);
				smsTempMobileNumbers.UserId = userId;
				smsTempMobileNumbers.Body = item.Body;
				smsTempMobileNumbers.BodyLangType = item.BodyLangType;
				smsTempMobileNumbers.BodyCount = item.BodyCount;
				smsTempMobileNumbers.BodyCost = item.BodyCost;
				int.TryParse(item.SID.ToString(), out var result6);
				smsTempMobileNumbers.SID = result6;
				smsTempMobileNumbers.AppType = Configuration.AppType;
				smsTempMobileNumbers.GUId = Guid.NewGuid();
				smsTempMobileNumbers.LanguageID = result2;
				smsTempMobileNumbers.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
				smsTempMobileNumbers.FirstRegisterDate = now;
				smsTempMobileNumbers.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				_dbTbl.SmsTempMobileNumbers.Add(smsTempMobileNumbers);
				_dbTbl.SaveChanges();
				flag = true;
			}
			if (flag)
			{
				result = "1";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = "-2";
		}
		return result;
	}

	[AjaxOnly]
	public string GetDelivery(string fromDate, string toDate, int userId, int smsHeadId, int statusId, int sendType, int? smsDetailId = 0)
	{
		string result = "-1";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int result3 = 0;
			int value = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
				value = UserLogin.CurrentUser.UserId;
			}
			List<mct_SmsspSelectSendedDetail_Result> list = new List<mct_SmsspSelectSendedDetail_Result>();
			_ = CRMIdeal.Classes.Helper.Sms.GetSmsSetting(out var _)?.SmsProviderId;
			if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate) && userId != 0 && smsHeadId != 0)
			{
				toDate = toDate.Replace("/", "").Replace("-", "").Replace("\\", "")
					.Replace(" ", "")
					.Replace("_", "");
				fromDate = fromDate.Replace("/", "").Replace("-", "").Replace("\\", "")
					.Replace(" ", "")
					.Replace("_", "");
				DateTime value2 = DateTime.Now;
				DateTime value3 = DateTime.Now;
				if (!string.IsNullOrEmpty(fromDate))
				{
					value2 = DateTime.Parse(PersianDate.GetFormatetdDate(fromDate.Replace("/", "")) + " 00:00:00", (lCID == 1065) ? new PersianCulture() : new CultureInfo("en-US"));
				}
				if (!string.IsNullOrEmpty(toDate))
				{
					value3 = DateTime.Parse(PersianDate.GetFormatetdDate(toDate.Replace("/", "")) + " 23:59:59", (lCID == 1065) ? new PersianCulture() : new CultureInfo("en-US"));
				}
				string unspecify = Labels.Unspecify;
				if (sendType != 0 && sendType.ToString().Length <= 1)
				{
					list = Enumerable.ToList<mct_SmsspSelectSendedDetail_Result>((IEnumerable<mct_SmsspSelectSendedDetail_Result>)db.mfi_SmsspSelectSendedDetail(smsHeadId.ToString(), fromDate, toDate, userId.ToString(), statusId.ToString(), value2, value3, lCID, result2, unspecify, result3, value));
				}
			}
			if (list != null && Enumerable.Any<mct_SmsspSelectSendedDetail_Result>((IEnumerable<mct_SmsspSelectSendedDetail_Result>)list))
			{
				list = Enumerable.ToList<mct_SmsspSelectSendedDetail_Result>(Enumerable.Where<mct_SmsspSelectSendedDetail_Result>((IEnumerable<mct_SmsspSelectSendedDetail_Result>)list, (Func<mct_SmsspSelectSendedDetail_Result, bool>)((mct_SmsspSelectSendedDetail_Result m) => (m.RefID ?? "0") != "0")));
			}
			if (list.Count > 0)
			{
				string[] array = new string[list.Count];
				_ = new long[list.Count];
				DateTime smsSendDate = DateTime.Now;
				mct_SmsspSelectSendedDetail_Result mct_SmsspSelectSendedDetail_Result = Enumerable.FirstOrDefault<mct_SmsspSelectSendedDetail_Result>((IEnumerable<mct_SmsspSelectSendedDetail_Result>)list);
				if (mct_SmsspSelectSendedDetail_Result != null)
				{
					_003C_003Ec__DisplayClass67_0 _003C_003Ec__DisplayClass67_ = new _003C_003Ec__DisplayClass67_0();
					_003C_003Ec__DisplayClass67_.smsDetId = mct_SmsspSelectSendedDetail_Result.ID.GetValueOrDefault();
					if (_003C_003Ec__DisplayClass67_.smsDetId != 0)
					{
						DbSet<SmsSendDetail> smsSendDetail = _dbTbl.SmsSendDetail;
						ParameterExpression val = Expression.Parameter(typeof(SmsSendDetail), "m");
						SmsSendDetail smsSendDetail2 = Queryable.FirstOrDefault<SmsSendDetail>((IQueryable<SmsSendDetail>)smsSendDetail, Expression.Lambda<Func<SmsSendDetail, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass67_, typeof(_003C_003Ec__DisplayClass67_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
						if (smsSendDetail2 != null)
						{
							smsSendDate = smsSendDetail2.SendDateTime ?? DateTime.Now;
						}
					}
				}
				string[] array2 = new string[list.Count];
				int num = 0;
				foreach (mct_SmsspSelectSendedDetail_Result item in list)
				{
					array[num] = item.RefID ?? "0";
					array2[num] = item.Number ?? "";
					num++;
				}
				int[] messageDeliveryOneToOne = GetMessageDeliveryOneToOne(array, array2, sendType, smsSendDate, ref result);
				for (int i = 0; i < Enumerable.Count<int>((IEnumerable<int>)messageDeliveryOneToOne); i++)
				{
					if (messageDeliveryOneToOne[i] != 0 && messageDeliveryOneToOne[i] != -7 && list[i].StatusId.GetValueOrDefault() != 2 && list[i].StatusId.GetValueOrDefault() != 4)
					{
						DateTime now = DateTime.Now;
						string text = now.ToString("yyyyMMdd", new PersianCulture());
						string text2 = now.ToString("HH:mm:ss");
						text = text.Replace("/", "").Replace("-", "").Replace("\\", "")
							.Replace(" ", "")
							.Replace("_", "");
						DateTime value4 = DateTime.Now;
						if (!string.IsNullOrEmpty(text))
						{
							value4 = DateTime.Parse(PersianDate.GetFormatetdDate(text.Replace("/", "")) + " " + text2, (lCID == 1065) ? new PersianCulture() : new CultureInfo("en-US"));
						}
						db.SmsspUpdateSendedDetailStatus(list[i].ID, messageDeliveryOneToOne[i], text, text2, Configuration.AppType, value4);
					}
				}
				result = "1";
				return result;
			}
			result = "0";
			return result;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return result;
		}
	}

	public int[] GetMessageDeliveryOneToOne(string[] refIdArrStr, string[] mobArr, int sendType, DateTime smsSendDate, ref string result)
	{
		int[] result2 = new int[Enumerable.Count<string>((IEnumerable<string>)refIdArrStr)];
		result2[0] = -7;
		try
		{
			long[] array = new long[Enumerable.Count<string>((IEnumerable<string>)refIdArrStr)];
			try
			{
				for (int i = 0; i < Enumerable.Count<string>((IEnumerable<string>)refIdArrStr); i++)
				{
					long result3 = 0L;
					long.TryParse(refIdArrStr[i], out result3);
					array[i] = result3;
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
			int freeSmsCount;
			SmsSettingInfoViewModel smsSetting = CRMIdeal.Classes.Helper.Sms.GetSmsSetting(out freeSmsCount);
			CRMIdeal.Classes.Helper.Sms sms = new CRMIdeal.Classes.Helper.Sms();
			if (array != null && !string.IsNullOrEmpty(smsSetting.SmsWsUserName) && !string.IsNullOrEmpty(smsSetting.SmsWsPassword) && !string.IsNullOrEmpty(smsSetting.SmsWsDomainNamed))
			{
				if (smsSetting.SmsProviderId == 1)
				{
					sms.MehrAfraz_GetMessageDelivery(array, ref result2, ref result);
				}
				else if (smsSetting.SmsProviderId == 2)
				{
					sms.SMSLine_GetMessageDelivery(array, ref result2, ref result);
				}
				else if (smsSetting.SmsProviderId == 3)
				{
					sms.FaraPayamak_GetMessageDelivery(array, ref result2, ref result);
				}
				else if (smsSetting.SmsProviderId == 4)
				{
					sms.Asanak_GetMessageDelivery(array, ref result2, ref result);
				}
				else if (smsSetting.SmsProviderId == 5)
				{
					sms.PayamResan_GetMessageDelivery(array, ref result2, ref result);
				}
				else if (smsSetting.SmsProviderId == 6)
				{
					sms.KaveNegar_GetMessageDelivery(array, ref result2, ref result);
				}
				else if (smsSetting.SmsProviderId == 7)
				{
					sms.TehranPayamak_GetDelivery(sendType, array, ref result2, ref result);
				}
				else if (smsSetting.SmsProviderId == 8)
				{
					sms.SmsFor_GetDelivery(array, ref result2, ref result);
				}
				else if (smsSetting.SmsProviderId == 9)
				{
					sms.SmsAfzar_GetDelivery(array, ref result2, ref result);
				}
				else if (smsSetting.SmsProviderId == 10)
				{
					sms.SmsIr_GetDelivery(array, ref result2, ref result);
				}
				else if (smsSetting.SmsProviderId == 11)
				{
					sms.WebOne_GetDelivery(array, ref result2, ref result);
				}
				else if (smsSetting.SmsProviderId == 12)
				{
					sms.MeliPayamak_GetDelivery(array, ref result2, ref result);
				}
				else if (smsSetting.SmsProviderId == 13)
				{
					sms.SmsPlus_GetDelivery(array, ref result2, ref result);
				}
				else if (smsSetting.SmsProviderId == 15)
				{
					sms.ISms_GetDelivery(array, ref result2, ref result);
				}
				else if (smsSetting.SmsProviderId == 16)
				{
					sms.Nimaad_GetDelivery(array, mobArr, ref result2, ref result);
				}
				else if (smsSetting.SmsProviderId == 17)
				{
					sms.FarazSms_GetDelivery(array, mobArr, ref result2, ref result);
				}
				else if (smsSetting.SmsProviderId == 18)
				{
					sms.Sharif_GetDelivery(array, ref result2, ref result);
				}
				else if (smsSetting.SmsProviderId == 19)
				{
					sms.SunWay_GetDelivery(array, ref result2, ref result);
				}
				else if (smsSetting.SmsProviderId == 20)
				{
					sms.CandooSms_GetDelivery(array, ref result2, ref result, smsSendDate);
				}
				else if (smsSetting.SmsProviderId == 21)
				{
					sms.ParmisSms_GetDelivery(array, ref result2, ref result);
				}
				else if (smsSetting.SmsProviderId == 22)
				{
					sms.SmsMelli_GetDelivery(array, ref result2, ref result);
				}
				else if (smsSetting.SmsProviderId == 23)
				{
					sms.ParsGreen_GetDelivery(array, ref result2, ref result);
				}
				else if (smsSetting.SmsProviderId == 24)
				{
					sms.Armaghan_GetDelivery(array, ref result2, ref result);
				}
				else if (smsSetting.SmsProviderId == 25)
				{
					sms.Rahyab_GetDelivery(refIdArrStr, mobArr, ref result2, ref result);
				}
				else if (smsSetting.SmsProviderId == 26)
				{
					sms.IPPanel_GetDelivery(refIdArrStr, mobArr, ref result2, ref result);
				}
				return result2;
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return result2;
	}

	[AjaxOnly]
	public string UpdateReceiveSmsFromWSdl()
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
			_ = DateTime.Now;
			DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			DateTime now = DateTime.Now;
			int value = int.Parse(now.ToString("MM", new PersianCulture()));
			int value2 = int.Parse(now.ToString("yyyy", new PersianCulture()));
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			result = ((_dbII.SmsspUpdateReceiveSmsIsRead(userId, value2, value, appType, now, registerDatePersian) > 0) ? "1" : "0");
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[AjaxOnly]
	public string DeleteReceiveSms(int receiveId)
	{
		string result = "-1";
		try
		{
			if (receiveId > 0)
			{
				result = ((db.SmsspDeleteReceiveSMS(receiveId) > 0) ? "1" : "0");
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[AjaxOnly]
	public string SendReply(string fromDate, string toDate, bool isLike, string likeVal)
	{
		string result = "-1";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate))
			{
				string text = toDate.Replace("/", "").Replace("-", "").Replace("\\", "")
					.Replace(" ", "")
					.Replace("_", "");
				string text2 = fromDate.Replace("/", "").Replace("-", "").Replace("\\", "")
					.Replace(" ", "")
					.Replace("_", "");
				DateTime value = DateTime.Now;
				DateTime value2 = DateTime.Now;
				if (!string.IsNullOrEmpty(text2))
				{
					value = DateTime.Parse(PersianDate.GetFormatetdDate(text2.Replace("/", "")) + " 00:00:00", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(text))
				{
					value2 = DateTime.Parse(PersianDate.GetFormatetdDate(text.Replace("/", "")) + " 23:59:59", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				fromDate = DateTimeClass.ConvertPerToEnWithLine(fromDate);
				toDate = DateTimeClass.ConvertPerToEnWithLine(toDate);
				string isLike2 = ((!isLike) ? "0" : "1");
				likeVal = likeVal ?? "";
				string firstRegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
				db.SmsspDeleteSmsTempMobileNumbers(UserLogin.CurrentUser.UserId);
				result = ((db.CRMspInsertSmsTempMobileNumbersFromReceiveSMS(UserLogin.CurrentUser.UserId, likeVal, fromDate, toDate, isLike2, Configuration.AppType, firstRegisterDatePersian, value, value2, lCID, result2) > 0) ? "1" : "0");
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[AjaxOnly]
	public string GetAllReceivedSms(int userId = 3)
	{
		string result = "";
		try
		{
			if (UserLogin.CurrentUser != null)
			{
				userId = UserLogin.CurrentUser.UserId;
			}
			if (userId == 0)
			{
				userId = 3;
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			CRMIdeal.Classes.Helper.Sms sms = new CRMIdeal.Classes.Helper.Sms();
			DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss");
			int freeSmsCount;
			SmsSettingInfoViewModel smsSetting = CRMIdeal.Classes.Helper.Sms.GetSmsSetting(out freeSmsCount);
			if (smsSetting != null)
			{
				List<SmsReceiveViewModel> list = new List<SmsReceiveViewModel>();
				if (smsSetting.SmsProviderId == 1)
				{
					DataTable val = sms.MehrAfraz_ReceiveSms();
					if (val != null && ((InternalDataCollectionBase)val.Rows).Count > 0)
					{
						for (int i = 0; i < ((InternalDataCollectionBase)val.Rows).Count; i++)
						{
							int num = int.Parse(val.Rows[i]["order"].ToString());
							string smsNumber = val.Rows[i]["SmsNumberMemo"].ToString();
							string smsDesc = val.Rows[i]["SmsDes"].ToString();
							string getId = val.Rows[i]["GetId"].ToString();
							string fromNumber = val.Rows[i]["fromnumber"].ToString();
							DateTime now = DateTime.Now;
							DateTime dateTime = now;
							DateTime value = now;
							string text = "";
							string text2 = "";
							string receiveDay = "";
							string receiveTime = "";
							try
							{
								dateTime = DateTime.Parse(val.Rows[i]["m_receiveDate"].ToString(), new CultureInfo("en-US"));
								value = dateTime;
								text = dateTime.ToString("yyyyMMdd", new PersianCulture());
								text2 = dateTime.ToString(new PersianCulture());
								receiveDay = DateTimeClass.DefineDayeOfWeekStartWith7(dateTime.DayOfWeek.ToString());
								receiveTime = dateTime.ToString("HH:mm:ss");
							}
							catch (Exception e)
							{
								ErrorSignal.FromCurrentContext().Raise(e);
								text = now.ToString("yyyyMMdd", new PersianCulture());
								text2 = "";
							}
							DateTime dateTime2 = now;
							DateTime value2 = now;
							string text3 = "";
							string text4 = "";
							try
							{
								dateTime2 = DateTime.Parse(val.Rows[i]["m_SrDate"].ToString(), new CultureInfo("en-US"));
								value2 = dateTime2;
								text3 = dateTime2.ToString("yyyyMMdd", new PersianCulture());
								text4 = dateTime2.ToString(new PersianCulture());
							}
							catch (Exception e2)
							{
								ErrorSignal.FromCurrentContext().Raise(e2);
								text3 = now.ToString("yyyyMMdd", new PersianCulture());
								text4 = "";
							}
							DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
							SmsReceiveViewModel item = new SmsReceiveViewModel
							{
								OrderNum = num,
								SmsNumber = smsNumber,
								SmsDesc = smsDesc,
								GetId = getId,
								FromNumber = fromNumber,
								ReceiveDate = value,
								ReceiveDatePersian = text,
								ReceiveDatePersianPreview = text2,
								SendDate = value2,
								SendDatePersian = text3,
								SendDatePersianPreview = text4,
								ReceiveDay = receiveDay,
								ReceiveTime = receiveTime
							};
							list.Add(item);
						}
					}
				}
				else if (smsSetting.SmsProviderId != 2)
				{
					if (smsSetting.SmsProviderId == 3)
					{
						MessagesBL[] array = sms.FaraPayamak_GetMessages();
						if (array != null && Enumerable.Any<MessagesBL>((IEnumerable<MessagesBL>)array))
						{
							for (int j = 0; j < array.Length; j++)
							{
								int num2 = int.Parse(array[j].MsgID.ToString());
								string text5 = array[j].Sender ?? "";
								string smsDesc2 = array[j].Body ?? "";
								string getId2 = array[j].MsgID.ToString();
								string fromNumber2 = array[j].Sender ?? "";
								DateTime now2 = DateTime.Now;
								string receiveDatePersian = "";
								string receiveDatePersianPreview = "";
								string receiveDay2 = "";
								string receiveTime2 = "";
								DateTime dateTime3 = now2;
								string text6 = "";
								string text7 = "";
								try
								{
									dateTime3 = array[j].SendDate;
									DateTimeClass.ConvertEnToPerWithLine(dateTime3);
									text6 = dateTime3.ToString("yyyyMMdd", new PersianCulture());
									text7 = dateTime3.ToString(new PersianCulture());
								}
								catch (Exception e3)
								{
									ErrorSignal.FromCurrentContext().Raise(e3);
									text6 = now2.ToString("yyyyMMdd", new PersianCulture());
									text7 = "";
								}
								if (!string.IsNullOrEmpty(text5) && text5.StartsWith("9"))
								{
									text5 = "0" + text5;
								}
								DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
								SmsReceiveViewModel item2 = new SmsReceiveViewModel
								{
									OrderNum = num2,
									SmsNumber = text5,
									SmsDesc = smsDesc2,
									GetId = getId2,
									FromNumber = fromNumber2,
									ReceiveDate = null,
									ReceiveDatePersian = receiveDatePersian,
									ReceiveDatePersianPreview = receiveDatePersianPreview,
									SendDate = dateTime3,
									SendDatePersian = text6,
									SendDatePersianPreview = text7,
									ReceiveDay = receiveDay2,
									ReceiveTime = receiveTime2
								};
								list.Add(item2);
							}
						}
					}
					else if (smsSetting.SmsProviderId != 4)
					{
						if (smsSetting.SmsProviderId == 5)
						{
							int errNum = 0;
							string msgError = "'";
							string[][] array2 = new string[100][];
							array2 = sms.PayamResan_GetMessages(ref errNum, ref msgError);
							if (array2 != null && Enumerable.Any<string[]>((IEnumerable<string[]>)array2) && errNum != 0)
							{
								string[][] array3 = array2;
								foreach (string[] obj in array3)
								{
									int num3 = int.Parse(obj[0].ToString());
									string smsNumber2 = obj[2] ?? "";
									string smsDesc3 = obj[3] ?? "";
									string getId3 = obj[0].ToString();
									string fromNumber3 = obj[2] ?? "";
									string text8 = obj[4] ?? "";
									DateTime now3 = DateTime.Now;
									DateTime dateTime4 = now3;
									string receiveDatePersian2 = "";
									string receiveDatePersianPreview2 = "";
									string receiveDay3 = "";
									string receiveTime3 = "";
									DateTime dateTime5 = now3;
									string sendDatePersian = "";
									string sendDatePersianPreview = "";
									try
									{
										if (!string.IsNullOrEmpty(text8))
										{
											dateTime4 = DateTime.Parse(text8);
											DateTimeClass.ConvertEnToPerWithLine(dateTime4);
											receiveDatePersian2 = dateTime4.ToString("yyyyMMdd", new PersianCulture());
											receiveDatePersianPreview2 = dateTime4.ToString(new PersianCulture());
											receiveDay3 = DateTimeClass.DefineDayeOfWeekStartWith7(dateTime4.DayOfWeek.ToString());
											receiveTime3 = dateTime4.ToString("HH:mm:ss");
										}
									}
									catch (Exception e4)
									{
										ErrorSignal.FromCurrentContext().Raise(e4);
										receiveDatePersian2 = now3.ToString("yyyyMMdd", new PersianCulture());
										receiveDatePersianPreview2 = "";
									}
									try
									{
										if (!string.IsNullOrEmpty(text8))
										{
											dateTime5 = DateTime.Parse(text8);
											DateTimeClass.ConvertEnToPerWithLine(dateTime5);
											sendDatePersian = dateTime5.ToString("yyyyMMdd", new PersianCulture());
											sendDatePersianPreview = dateTime5.ToString(new PersianCulture());
										}
									}
									catch (Exception e5)
									{
										ErrorSignal.FromCurrentContext().Raise(e5);
										sendDatePersian = now3.ToString("yyyyMMdd", new PersianCulture());
										sendDatePersianPreview = "";
									}
									DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
									SmsReceiveViewModel item3 = new SmsReceiveViewModel
									{
										OrderNum = num3,
										SmsNumber = smsNumber2,
										SmsDesc = smsDesc3,
										GetId = getId3,
										FromNumber = fromNumber3,
										ReceiveDate = null,
										ReceiveDatePersian = receiveDatePersian2,
										ReceiveDatePersianPreview = receiveDatePersianPreview2,
										SendDate = dateTime5,
										SendDatePersian = sendDatePersian,
										SendDatePersianPreview = sendDatePersianPreview,
										ReceiveDay = receiveDay3,
										ReceiveTime = receiveTime3
									};
									list.Add(item3);
								}
							}
							else
							{
								result = msgError;
							}
						}
						else if (smsSetting.SmsProviderId == 6)
						{
							int status_code = 0;
							string status_message = "";
							ApiReceive[] array4 = sms.KaveNegar_GetMessages(ref status_code, ref status_message);
							if (array4 != null && Enumerable.Any<ApiReceive>((IEnumerable<ApiReceive>)array4) && status_code == 200)
							{
								ApiReceive[] array5 = array4;
								foreach (ApiReceive obj2 in array5)
								{
									int num4 = int.Parse(obj2.messageid.ToString());
									string smsNumber3 = obj2.sender ?? "";
									string smsDesc4 = obj2.message ?? "";
									string getId4 = obj2.messageid.ToString();
									string fromNumber4 = obj2.receptor ?? "";
									long date = obj2.date;
									DateTime dateTime6 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(date).ToLocalTime();
									DateTime now4 = DateTime.Now;
									dateTime6 = dateTime6;
									DateTime dateTime7 = now4;
									string text9 = "";
									string text10 = "";
									string receiveDay4 = "";
									string receiveTime4 = "";
									DateTime dateTime8 = now4;
									string text11 = "";
									string text12 = "";
									try
									{
										dateTime7 = dateTime6;
										DateTimeClass.ConvertEnToPerWithLine(dateTime7);
										text9 = dateTime7.ToString("yyyyMMdd", new PersianCulture());
										text10 = dateTime7.ToString(new PersianCulture());
										receiveDay4 = DateTimeClass.DefineDayeOfWeekStartWith7(dateTime7.DayOfWeek.ToString());
										receiveTime4 = dateTime7.ToString("HH:mm:ss");
									}
									catch (Exception e6)
									{
										ErrorSignal.FromCurrentContext().Raise(e6);
										text9 = now4.ToString("yyyyMMdd", new PersianCulture());
										text10 = "";
									}
									try
									{
										dateTime8 = dateTime6;
										DateTimeClass.ConvertEnToPerWithLine(dateTime8);
										text11 = dateTime8.ToString("yyyyMMdd", new PersianCulture());
										text12 = dateTime8.ToString(new PersianCulture());
									}
									catch (Exception e7)
									{
										ErrorSignal.FromCurrentContext().Raise(e7);
										text11 = now4.ToString("yyyyMMdd", new PersianCulture());
										text12 = "";
									}
									DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
									SmsReceiveViewModel item4 = new SmsReceiveViewModel
									{
										OrderNum = num4,
										SmsNumber = smsNumber3,
										SmsDesc = smsDesc4,
										GetId = getId4,
										FromNumber = fromNumber4,
										ReceiveDate = null,
										ReceiveDatePersian = text9,
										ReceiveDatePersianPreview = text10,
										SendDate = dateTime8,
										SendDatePersian = text11,
										SendDatePersianPreview = text12,
										ReceiveDay = receiveDay4,
										ReceiveTime = receiveTime4
									};
									list.Add(item4);
								}
							}
							else
							{
								result = status_message;
							}
						}
						else if (smsSetting.SmsProviderId == 7)
						{
							CRMIdeal.SmsTehranPayamak.message[] array6 = sms.TehranPayamak_ReceiveSms();
							if (array6 != null && Enumerable.Any<CRMIdeal.SmsTehranPayamak.message>((IEnumerable<CRMIdeal.SmsTehranPayamak.message>)array6))
							{
								for (int l = 0; l < array6.Length; l++)
								{
									int num5 = int.Parse(array6[l].sms_id.ToString());
									string text13 = array6[l].mobile_no ?? "";
									string smsDesc5 = array6[l].text ?? "";
									string getId5 = array6[l].sms_id.ToString();
									string fromNumber5 = array6[l].mobile_no ?? "";
									DateTime now5 = DateTime.Now;
									string receiveDatePersian3 = "";
									string receiveDatePersianPreview3 = "";
									string receiveDay5 = "";
									string receiveTime5 = "";
									DateTime dateTime9 = now5;
									string text14 = "";
									string text15 = "";
									try
									{
										dateTime9 = DateTime.Parse(array6[l].send_date);
										DateTimeClass.ConvertEnToPerWithLine(dateTime9);
										text14 = dateTime9.ToString("yyyyMMdd", new PersianCulture());
										text15 = dateTime9.ToString(new PersianCulture());
									}
									catch (Exception e8)
									{
										ErrorSignal.FromCurrentContext().Raise(e8);
										text14 = now5.ToString("yyyyMMdd", new PersianCulture());
										text15 = "";
									}
									if (!string.IsNullOrEmpty(text13) && text13.StartsWith("9"))
									{
										text13 = "0" + text13;
									}
									DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
									SmsReceiveViewModel item5 = new SmsReceiveViewModel
									{
										OrderNum = num5,
										SmsNumber = text13,
										SmsDesc = smsDesc5,
										GetId = getId5,
										FromNumber = fromNumber5,
										ReceiveDate = null,
										ReceiveDatePersian = receiveDatePersian3,
										ReceiveDatePersianPreview = receiveDatePersianPreview3,
										SendDate = dateTime9,
										SendDatePersian = text14,
										SendDatePersianPreview = text15,
										ReceiveDay = receiveDay5,
										ReceiveTime = receiveTime5
									};
									list.Add(item5);
								}
							}
						}
						else if (smsSetting.SmsProviderId == 8)
						{
							array_receive[] array7 = sms.SmsFor_ReceiveSms();
							if (array7 != null && Enumerable.Any<array_receive>((IEnumerable<array_receive>)array7))
							{
								for (int m = 0; m < array7.Length; m++)
								{
									int num6 = int.Parse(array7[m].id.ToString());
									string text16 = array7[m].sender_number ?? "";
									string smsDesc6 = array7[m].note ?? "";
									string getId6 = array7[m].id.ToString();
									string text17 = array7[m].receiver_number ?? "";
									DateTime now6 = DateTime.Now;
									string receiveDatePersian4 = "";
									string receiveDatePersianPreview4 = "";
									string receiveDay6 = "";
									string receiveTime6 = "";
									DateTime date2 = now6;
									string text18 = "";
									string text19 = "";
									try
									{
										double value3 = double.Parse(array7[m].date);
										date2 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(value3).ToLocalTime();
										DateTimeClass.ConvertEnToPerWithLine(date2);
										text18 = date2.ToString("yyyyMMdd", new PersianCulture());
										text19 = date2.ToString(new PersianCulture());
									}
									catch (Exception e9)
									{
										ErrorSignal.FromCurrentContext().Raise(e9);
										text18 = now6.ToString("yyyyMMdd", new PersianCulture());
										text19 = "";
									}
									if (!string.IsNullOrEmpty(text16) && text16.StartsWith("9"))
									{
										text16 = "0" + text16;
									}
									if (!string.IsNullOrEmpty(text17) && text17.StartsWith("9"))
									{
										text17 = "0" + text17;
									}
									DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
									date2 = DateTime.Parse(date2.ToString("yyyy/MM/dd HH:mm:ss"));
									SmsReceiveViewModel item6 = new SmsReceiveViewModel
									{
										OrderNum = num6,
										SmsNumber = text16,
										SmsDesc = smsDesc6,
										GetId = getId6,
										FromNumber = text17,
										ReceiveDate = null,
										ReceiveDatePersian = receiveDatePersian4,
										ReceiveDatePersianPreview = receiveDatePersianPreview4,
										SendDate = date2,
										SendDatePersian = text18,
										SendDatePersianPreview = text19,
										ReceiveDay = receiveDay6,
										ReceiveTime = receiveTime6
									};
									list.Add(item6);
								}
							}
						}
						else if (smsSetting.SmsProviderId == 9)
						{
							reciveInfo[] array8 = sms.SmsAfzar_ReceiveSms();
							if (array8 != null && Enumerable.Any<reciveInfo>((IEnumerable<reciveInfo>)array8))
							{
								for (int n = 0; n < array8.Length; n++)
								{
									int num7 = int.Parse(array8[n].reciveID.ToString());
									string text20 = array8[n].senderNumber ?? "";
									string smsDesc7 = array8[n].text ?? "";
									string getId7 = array8[n].reciveID.ToString();
									string text21 = array8[n].reciverNumber ?? "";
									DateTime now7 = DateTime.Now;
									string receiveDatePersian5 = "";
									string receiveDatePersianPreview5 = "";
									string receiveDay7 = "";
									string receiveTime7 = "";
									DateTime dateTime10 = now7;
									string text22 = "";
									string text23 = "";
									try
									{
										string text24 = ((!string.IsNullOrEmpty(array8[n].date)) ? array8[n].date : "");
										if (!string.IsNullOrEmpty(text24))
										{
											text24 = text24.Replace("/", "").Replace("-", "").Replace("\\", "")
												.Replace(" ", "")
												.Replace("_", "");
											dateTime10 = DateTime.Parse(PersianDate.GetFormatetdDate(text24) + ((!string.IsNullOrEmpty(array8[n].time)) ? (" " + array8[n].time) : " 00:00:00"));
										}
										else
										{
											dateTime10 = now7;
										}
										DateTimeClass.ConvertEnToPerWithLine(dateTime10);
										text22 = dateTime10.ToString("yyyyMMdd", new PersianCulture());
										text23 = dateTime10.ToString(new PersianCulture());
									}
									catch (Exception e10)
									{
										ErrorSignal.FromCurrentContext().Raise(e10);
										text22 = now7.ToString("yyyyMMdd", new PersianCulture());
										text23 = "";
									}
									if (!string.IsNullOrEmpty(text20) && text20.StartsWith("9"))
									{
										text20 = "0" + text20;
									}
									if (!string.IsNullOrEmpty(text21) && text21.StartsWith("9"))
									{
										text21 = "0" + text21;
									}
									DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
									SmsReceiveViewModel item7 = new SmsReceiveViewModel
									{
										OrderNum = num7,
										SmsNumber = text20,
										SmsDesc = smsDesc7,
										GetId = getId7,
										FromNumber = text21,
										ReceiveDate = null,
										ReceiveDatePersian = receiveDatePersian5,
										ReceiveDatePersianPreview = receiveDatePersianPreview5,
										SendDate = dateTime10,
										SendDatePersian = text22,
										SendDatePersianPreview = text23,
										ReceiveDay = receiveDay7,
										ReceiveTime = receiveTime7
									};
									list.Add(item7);
								}
							}
						}
						else if (smsSetting.SmsProviderId == 10)
						{
							SMSIrReceiveMessageDataResponseViewModel[] array9 = sms.SmsIr_ReceiveSms();
							if (array9 != null && Enumerable.Any<SMSIrReceiveMessageDataResponseViewModel>((IEnumerable<SMSIrReceiveMessageDataResponseViewModel>)array9))
							{
								for (int num8 = 0; num8 < array9.Length; num8++)
								{
									long value4 = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss"), new CultureInfo("en-US"));
									string text25 = array9[num8].Number.ToString();
									string smsDesc8 = array9[num8].messageText ?? "";
									string getId8 = value4.ToString();
									string text26 = array9[num8].mobile ?? "";
									DateTime now8 = DateTime.Now;
									string receiveDay8 = "";
									string receiveTime8 = "";
									DateTime date3 = now8;
									string text27 = "";
									string text28 = "";
									try
									{
										if (array9[num8].ReceivedDateTime != 0)
										{
											double value5 = double.Parse(array9[num8].ReceivedDateTime.ToString());
											date3 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(value5).ToLocalTime();
										}
										else
										{
											date3 = now8;
										}
										DateTimeClass.ConvertEnToPerWithLine(date3);
										text27 = date3.ToString("yyyyMMdd", new PersianCulture());
										text28 = date3.ToString(new PersianCulture());
									}
									catch (Exception e11)
									{
										ErrorSignal.FromCurrentContext().Raise(e11);
										text27 = now8.ToString("yyyyMMdd", new PersianCulture());
										text28 = "";
									}
									if (!string.IsNullOrEmpty(text25) && text25.StartsWith("9"))
									{
										text25 = "0" + text25;
									}
									if (!string.IsNullOrEmpty(text26) && text26.StartsWith("9"))
									{
										text26 = "0" + text26;
									}
									string receiveDatePersian6 = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
									date3 = DateTime.Parse(date3.ToString("yyyy/MM/dd HH:mm:ss"));
									SmsReceiveViewModel item8 = new SmsReceiveViewModel
									{
										OrderNum = value4,
										SmsNumber = text25,
										SmsDesc = smsDesc8,
										GetId = getId8,
										FromNumber = text26,
										ReceiveDate = date3,
										ReceiveDatePersian = receiveDatePersian6,
										ReceiveDatePersianPreview = text28,
										SendDate = date3,
										SendDatePersian = text27,
										SendDatePersianPreview = text28,
										ReceiveDay = receiveDay8,
										ReceiveTime = receiveTime8
									};
									list.Add(item8);
								}
							}
						}
						else if (smsSetting.SmsProviderId == 11)
						{
							MessageInfo[] array10 = sms.WebOne_ReceiveSms();
							if (array10 != null && Enumerable.Any<MessageInfo>((IEnumerable<MessageInfo>)array10))
							{
								for (int num9 = 0; num9 < array10.Length; num9++)
								{
									int num10 = int.Parse(array10[num9].MessageId.ToString());
									string text29 = array10[num9].Sender ?? "";
									string smsDesc9 = array10[num9].Content ?? "";
									string getId9 = array10[num9].MessageId.ToString();
									string text30 = array10[num9].Receiver ?? "";
									DateTime now9 = DateTime.Now;
									string receiveDay9 = "";
									string receiveTime9 = "";
									DateTime dateTime11 = now9;
									string text31 = "";
									string text32 = "";
									try
									{
										DateTime actionDateTime = array10[num9].ActionDateTime;
										dateTime11 = actionDateTime;
										DateTimeClass.ConvertEnToPerWithLine(dateTime11);
										text31 = dateTime11.ToString("yyyyMMdd", new PersianCulture());
										text32 = dateTime11.ToString(new PersianCulture());
									}
									catch (Exception e12)
									{
										ErrorSignal.FromCurrentContext().Raise(e12);
										text31 = now9.ToString("yyyyMMdd", new PersianCulture());
										text32 = "";
									}
									if (!string.IsNullOrEmpty(text29) && text29.StartsWith("9"))
									{
										text29 = "0" + text29;
									}
									if (!string.IsNullOrEmpty(text30) && text30.StartsWith("9"))
									{
										text30 = "0" + text30;
									}
									string receiveDatePersian7 = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
									SmsReceiveViewModel item9 = new SmsReceiveViewModel
									{
										OrderNum = num10,
										SmsNumber = text29,
										SmsDesc = smsDesc9,
										GetId = getId9,
										FromNumber = text30,
										ReceiveDate = dateTime11,
										ReceiveDatePersian = receiveDatePersian7,
										ReceiveDatePersianPreview = text32,
										SendDate = dateTime11,
										SendDatePersian = text31,
										SendDatePersianPreview = text32,
										ReceiveDay = receiveDay9,
										ReceiveTime = receiveTime9
									};
									list.Add(item9);
								}
							}
						}
						else if (smsSetting.SmsProviderId == 12)
						{
							List<SmsMeliPayamakGetMessagesDataResultViewModel> list2 = sms.MeliPayamak_ReceiveSms();
							if (list2 != null && Enumerable.Any<SmsMeliPayamakGetMessagesDataResultViewModel>((IEnumerable<SmsMeliPayamakGetMessagesDataResultViewModel>)list2))
							{
								foreach (SmsMeliPayamakGetMessagesDataResultViewModel item21 in list2)
								{
									long value6 = long.Parse(item21.MsgID.ToString());
									string text33 = item21.Sender ?? "";
									string smsDesc10 = item21.Body ?? "";
									string getId10 = item21.MsgID.ToString();
									string text34 = item21.Receiver ?? "";
									DateTime now10 = DateTime.Now;
									string receiveDay10 = "";
									string receiveTime10 = "";
									DateTime dateTime12 = now10;
									string text35 = "";
									string text36 = "";
									try
									{
										DateTime sendDate = item21.SendDate;
										dateTime12 = sendDate;
										DateTimeClass.ConvertEnToPerWithLine(dateTime12);
										text35 = dateTime12.ToString("yyyyMMdd", new PersianCulture());
										text36 = dateTime12.ToString(new PersianCulture());
									}
									catch (Exception e13)
									{
										ErrorSignal.FromCurrentContext().Raise(e13);
										text35 = now10.ToString("yyyyMMdd", new PersianCulture());
										text36 = "";
									}
									if (!string.IsNullOrEmpty(text33) && text33.StartsWith("9"))
									{
										text33 = "0" + text33;
									}
									if (!string.IsNullOrEmpty(text34) && text34.StartsWith("9"))
									{
										text34 = "0" + text34;
									}
									string receiveDatePersian8 = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
									SmsReceiveViewModel item10 = new SmsReceiveViewModel
									{
										OrderNum = value6,
										SmsNumber = text33,
										SmsDesc = smsDesc10,
										GetId = getId10,
										FromNumber = text34,
										ReceiveDate = dateTime12,
										ReceiveDatePersian = receiveDatePersian8,
										ReceiveDatePersianPreview = text36,
										SendDate = dateTime12,
										SendDatePersian = text35,
										SendDatePersianPreview = text36,
										ReceiveDay = receiveDay10,
										ReceiveTime = receiveTime10
									};
									list.Add(item10);
								}
							}
						}
						else if (smsSetting.SmsProviderId == 13)
						{
							List<SmsPlusReceiveObjSMSInResponseViewModel> list3 = sms.SmsPlus_ReceiveSms();
							if (list3 != null && Enumerable.Any<SmsPlusReceiveObjSMSInResponseViewModel>((IEnumerable<SmsPlusReceiveObjSMSInResponseViewModel>)list3))
							{
								foreach (SmsPlusReceiveObjSMSInResponseViewModel item22 in list3)
								{
									int num11 = int.Parse(item22.Id.ToString());
									string text37 = item22.Mobile ?? "";
									string smsDesc11 = item22.Text ?? "";
									string getId11 = item22.Id.ToString();
									string text38 = smsSetting.SmsWsFromNumber ?? "";
									DateTime now11 = DateTime.Now;
									string text39 = "";
									string text40 = "";
									DateTime dateTime13 = now11;
									string text41 = "";
									string text42 = "";
									try
									{
										DateTime? dateTime14 = item22.DateTime;
										dateTime13 = ((!dateTime14.HasValue) ? now11 : dateTime14.GetValueOrDefault(now11));
										DateTimeClass.ConvertEnToPerWithLine(dateTime13);
										text41 = dateTime13.ToString("yyyyMMdd", new PersianCulture());
										text42 = dateTime13.ToString(new PersianCulture());
									}
									catch (Exception e14)
									{
										ErrorSignal.FromCurrentContext().Raise(e14);
										text41 = now11.ToString("yyyyMMdd", new PersianCulture());
										text42 = now11.ToString(new PersianCulture());
									}
									if (!string.IsNullOrEmpty(text37) && text37.StartsWith("9"))
									{
										text37 = "0" + text37;
									}
									if (!string.IsNullOrEmpty(text38) && text38.StartsWith("9"))
									{
										text38 = "0" + text38;
									}
									text40 = dateTime13.ToString("HH:mm:ss");
									text39 = DateTimeClass.DefineDayeOfWeekStartWith7(dateTime13.DayOfWeek.ToString());
									DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
									SmsReceiveViewModel item11 = new SmsReceiveViewModel
									{
										OrderNum = num11,
										SmsNumber = text37,
										SmsDesc = smsDesc11,
										GetId = getId11,
										FromNumber = text38,
										ReceiveDate = dateTime13,
										ReceiveDatePersian = text41,
										ReceiveDatePersianPreview = text42,
										SendDate = dateTime13,
										SendDatePersian = text41,
										SendDatePersianPreview = text42,
										ReceiveDay = text39,
										ReceiveTime = text40
									};
									list.Add(item11);
								}
							}
						}
						else if (smsSetting.SmsProviderId == 15)
						{
							List<ISmsGetReceiveResponseViewModel> list4 = sms.ISms_ReceiveSms();
							if (list4 != null && Enumerable.Any<ISmsGetReceiveResponseViewModel>((IEnumerable<ISmsGetReceiveResponseViewModel>)list4))
							{
								foreach (ISmsGetReceiveResponseViewModel item23 in list4)
								{
									long? orderNum = null;
									string text43 = item23.srcaddress ?? "";
									string smsDesc12 = item23.msgbody ?? "";
									string text44 = "";
									string text45 = smsSetting.SmsWsFromNumber ?? "";
									long num12 = long.Parse(item23.receivedtime ?? "0");
									DateTime dateTime15 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(num12).ToLocalTime();
									if (!string.IsNullOrEmpty(text45) && text45.StartsWith("9"))
									{
										text45 = "0" + text45;
									}
									if (!string.IsNullOrEmpty(text43) && text43.StartsWith("9"))
									{
										text43 = "0" + text43;
									}
									DateTime now12 = DateTime.Now;
									dateTime15 = ((!string.IsNullOrWhiteSpace(item23.receivedtime)) ? dateTime15 : now12);
									DateTime date4 = now12;
									string text46 = "";
									string text47 = "";
									string text48 = "";
									string text49 = "";
									DateTime date5 = now12;
									string text50 = "";
									string text51 = "";
									try
									{
										date4 = dateTime15;
										DateTimeClass.ConvertEnToPerWithLine(date4);
										text46 = date4.ToString("yyyyMMdd", new PersianCulture());
										text47 = date4.ToString(new PersianCulture());
										text48 = DateTimeClass.DefineDayeOfWeekStartWith7(date4.DayOfWeek.ToString());
										text49 = date4.ToString("HH:mm:ss");
									}
									catch (Exception e15)
									{
										ErrorSignal.FromCurrentContext().Raise(e15);
										text46 = now12.ToString("yyyyMMdd", new PersianCulture());
										text47 = "";
									}
									try
									{
										date5 = dateTime15;
										DateTimeClass.ConvertEnToPerWithLine(date5);
										text50 = date5.ToString("yyyyMMdd", new PersianCulture());
										text51 = date5.ToString(new PersianCulture());
									}
									catch (Exception e16)
									{
										ErrorSignal.FromCurrentContext().Raise(e16);
										text50 = now12.ToString("yyyyMMdd", new PersianCulture());
										text51 = "";
									}
									text44 = date4.ToString("yyyyMMddHHmmss");
									text49 = date5.ToString("HH:mm:ss");
									text48 = DateTimeClass.DefineDayeOfWeekStartWith7(date5.DayOfWeek.ToString());
									DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
									date4 = DateTime.Parse(date4.ToString("yyyy/MM/dd HH:mm:ss"));
									date5 = DateTime.Parse(date5.ToString("yyyy/MM/dd HH:mm:ss"));
									SmsReceiveViewModel item12 = new SmsReceiveViewModel
									{
										OrderNum = orderNum,
										SmsNumber = text43,
										SmsDesc = smsDesc12,
										GetId = text44,
										FromNumber = text45,
										ReceiveDate = date4,
										ReceiveDatePersian = text46,
										ReceiveDatePersianPreview = text47,
										SendDate = date5,
										SendDatePersian = text50,
										SendDatePersianPreview = text51,
										ReceiveDay = text48,
										ReceiveTime = text49
									};
									list.Add(item12);
								}
							}
						}
						else if (smsSetting.SmsProviderId == 16)
						{
							CRM.OtherWebServices.SmsNimadd.message[] array11 = sms.Nimaad_GetMessage();
							if (array11 != null && Enumerable.Any<CRM.OtherWebServices.SmsNimadd.message>((IEnumerable<CRM.OtherWebServices.SmsNimadd.message>)array11))
							{
								CRM.OtherWebServices.SmsNimadd.message[] array12 = array11;
								foreach (CRM.OtherWebServices.SmsNimadd.message obj3 in array12)
								{
									long? orderNum2 = null;
									string text52 = obj3.mobile_no ?? "";
									string smsDesc13 = obj3.text ?? "";
									string text53 = obj3.sms_id.ToString();
									string text54 = obj3.line_no ?? "";
									DateTime dateTime16 = DateTime.Now;
									string text55 = obj3.send_date ?? "";
									if (!string.IsNullOrWhiteSpace(text55))
									{
										string[] array13 = text55.Split(new char[1] { ' ' });
										if (array13 != null && array13.Length == 2)
										{
											string text56 = array13[0];
											string text57 = array13[1] ?? "00:00:00";
											if (!string.IsNullOrWhiteSpace(text56))
											{
												dateTime16 = DateTime.Parse(PersianDate.GetFormatetdDate(text56.Replace("/", "")) + " " + text57, new PersianCulture());
											}
										}
									}
									if (!string.IsNullOrEmpty(text54) && text54.StartsWith("9"))
									{
										text54 = "0" + text54;
									}
									if (!string.IsNullOrEmpty(text52) && text52.StartsWith("9"))
									{
										text52 = "0" + text52;
									}
									DateTime now13 = DateTime.Now;
									DateTime dateTime17 = now13;
									string text58 = "";
									string text59 = "";
									string text60 = "";
									string text61 = "";
									DateTime dateTime18 = now13;
									string text62 = "";
									string text63 = "";
									try
									{
										dateTime17 = dateTime16;
										DateTimeClass.ConvertEnToPerWithLine(dateTime17);
										text58 = dateTime17.ToString("yyyyMMdd", new PersianCulture());
										text59 = dateTime17.ToString(new PersianCulture());
										text60 = DateTimeClass.DefineDayeOfWeekStartWith7(dateTime17.DayOfWeek.ToString());
										text61 = dateTime17.ToString("HH:mm:ss");
									}
									catch (Exception)
									{
										text58 = now13.ToString("yyyyMMdd", new PersianCulture());
										text59 = "";
									}
									try
									{
										dateTime18 = dateTime16;
										DateTimeClass.ConvertEnToPerWithLine(dateTime18);
										text62 = dateTime18.ToString("yyyyMMdd", new PersianCulture());
										text63 = dateTime18.ToString(new PersianCulture());
									}
									catch (Exception)
									{
										text62 = now13.ToString("yyyyMMdd", new PersianCulture());
										text63 = "";
									}
									text53 = dateTime17.ToString("yyyyMMddHHmmss");
									text61 = dateTime18.ToString("HH:mm:ss");
									text60 = DateTimeClass.DefineDayeOfWeekStartWith7(dateTime18.DayOfWeek.ToString());
									DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
									SmsReceiveViewModel item13 = new SmsReceiveViewModel
									{
										OrderNum = orderNum2,
										SmsNumber = text52,
										SmsDesc = smsDesc13,
										GetId = text53,
										FromNumber = text54,
										ReceiveDate = dateTime17,
										ReceiveDatePersian = text58,
										ReceiveDatePersianPreview = text59,
										SendDate = dateTime18,
										SendDatePersian = text62,
										SendDatePersianPreview = text63,
										ReceiveDay = text60,
										ReceiveTime = text61
									};
									list.Add(item13);
								}
							}
						}
						else if (smsSetting.SmsProviderId == 17)
						{
							List<FarazSmsGetReceiveResponseViewModel> list5 = sms.FarazSms_ReceiveSms();
							if (list5 != null && Enumerable.Any<FarazSmsGetReceiveResponseViewModel>((IEnumerable<FarazSmsGetReceiveResponseViewModel>)list5))
							{
								foreach (FarazSmsGetReceiveResponseViewModel item24 in list5)
								{
									long? orderNum3 = null;
									string text64 = item24.from ?? "";
									string smsDesc14 = item24.message ?? "";
									string text65 = "";
									string text66 = item24.to ?? smsSetting.SmsWsFromNumber ?? "";
									DateTime dateTime19 = item24.time ?? DateTime.Now;
									if (!string.IsNullOrEmpty(text64))
									{
										text64 = text64.Replace("+98", "");
										if (text64.StartsWith("9") && text64.Length == 10)
										{
											text64 = "0" + text64;
										}
									}
									if (!string.IsNullOrEmpty(text66))
									{
										text66 = text66.Replace("+98", "");
										if (text66.StartsWith("9") && text66.Length == 10)
										{
											text66 = "0" + text66;
										}
									}
									DateTime now14 = DateTime.Now;
									dateTime19 = dateTime19;
									DateTime dateTime20 = now14;
									string text67 = "";
									string text68 = "";
									string text69 = "";
									string text70 = "";
									DateTime dateTime21 = now14;
									string text71 = "";
									string text72 = "";
									try
									{
										dateTime20 = dateTime19;
										DateTimeClass.ConvertEnToPerWithLine(dateTime20);
										text67 = dateTime20.ToString("yyyyMMdd", new PersianCulture());
										text68 = dateTime20.ToString(new PersianCulture());
										text69 = DateTimeClass.DefineDayeOfWeekStartWith7(dateTime20.DayOfWeek.ToString());
										text70 = dateTime20.ToString("HH:mm:ss");
									}
									catch (Exception e17)
									{
										ErrorSignal.FromCurrentContext().Raise(e17);
										text67 = now14.ToString("yyyyMMdd", new PersianCulture());
										text68 = "";
									}
									try
									{
										dateTime21 = dateTime19;
										DateTimeClass.ConvertEnToPerWithLine(dateTime21);
										text71 = dateTime21.ToString("yyyyMMdd", new PersianCulture());
										text72 = dateTime21.ToString(new PersianCulture());
									}
									catch (Exception e18)
									{
										ErrorSignal.FromCurrentContext().Raise(e18);
										text71 = now14.ToString("yyyyMMdd", new PersianCulture());
										text72 = "";
									}
									text65 = dateTime20.ToString("yyyyMMddHHmmss");
									text70 = dateTime21.ToString("HH:mm:ss");
									text69 = DateTimeClass.DefineDayeOfWeekStartWith7(dateTime21.DayOfWeek.ToString());
									DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
									SmsReceiveViewModel item14 = new SmsReceiveViewModel
									{
										OrderNum = orderNum3,
										SmsNumber = text64,
										SmsDesc = smsDesc14,
										GetId = text65,
										FromNumber = text66,
										ReceiveDate = dateTime20,
										ReceiveDatePersian = text67,
										ReceiveDatePersianPreview = text68,
										SendDate = dateTime21,
										SendDatePersian = text71,
										SendDatePersianPreview = text72,
										ReceiveDay = text69,
										ReceiveTime = text70
									};
									list.Add(item14);
								}
							}
						}
						else if (smsSetting.SmsProviderId == 19)
						{
							InboxItem[] array14 = sms.SunWay_GetMessage();
							if (array14 != null && Enumerable.Any<InboxItem>((IEnumerable<InboxItem>)array14))
							{
								InboxItem[] array15 = array14;
								foreach (InboxItem obj4 in array15)
								{
									long inboxID = obj4.InboxID;
									string smsNumber4 = obj4.SenderNumber ?? "";
									string smsDesc15 = obj4.MessageBody ?? "";
									string text73 = obj4.InboxID.ToString();
									string text74 = obj4.SpecialNumber ?? "";
									DateTime dateTime22 = DateTime.Now;
									string text75 = obj4.ReceiveDate ?? "";
									if (!string.IsNullOrWhiteSpace(text75))
									{
										dateTime22 = DateTime.Parse(text75, new CultureInfo("en-US"));
									}
									if (!string.IsNullOrEmpty(text74) && text74.StartsWith("9"))
									{
										text74 = "0" + text74;
									}
									DateTime now15 = DateTime.Now;
									DateTime dateTime23 = now15;
									string text76 = "";
									string text77 = "";
									string text78 = "";
									string text79 = "";
									DateTime dateTime24 = now15;
									string text80 = "";
									string text81 = "";
									try
									{
										dateTime23 = dateTime22;
										DateTimeClass.ConvertEnToPerWithLine(dateTime23);
										text76 = dateTime23.ToString("yyyyMMdd", new PersianCulture());
										text77 = dateTime23.ToString(new PersianCulture());
										text78 = DateTimeClass.DefineDayeOfWeekStartWith7(dateTime23.DayOfWeek.ToString());
										text79 = dateTime23.ToString("HH:mm:ss");
									}
									catch (Exception)
									{
										text76 = now15.ToString("yyyyMMdd", new PersianCulture());
										text77 = "";
									}
									try
									{
										dateTime24 = dateTime22;
										DateTimeClass.ConvertEnToPerWithLine(dateTime24);
										text80 = dateTime24.ToString("yyyyMMdd", new PersianCulture());
										text81 = dateTime24.ToString(new PersianCulture());
									}
									catch (Exception)
									{
										text80 = now15.ToString("yyyyMMdd", new PersianCulture());
										text81 = "";
									}
									text73 = dateTime23.ToString("yyyyMMddHHmmss");
									text79 = dateTime24.ToString("HH:mm:ss");
									text78 = DateTimeClass.DefineDayeOfWeekStartWith7(dateTime24.DayOfWeek.ToString());
									DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
									SmsReceiveViewModel item15 = new SmsReceiveViewModel
									{
										OrderNum = inboxID,
										SmsNumber = smsNumber4,
										SmsDesc = smsDesc15,
										GetId = text73,
										FromNumber = text74,
										ReceiveDate = dateTime23,
										ReceiveDatePersian = text76,
										ReceiveDatePersianPreview = text77,
										SendDate = dateTime24,
										SendDatePersian = text80,
										SendDatePersianPreview = text81,
										ReceiveDay = text78,
										ReceiveTime = text79
									};
									list.Add(item15);
								}
							}
						}
						else if (smsSetting.SmsProviderId == 20)
						{
							List<CandooGetMessageInfoResponseViewModel> list6 = sms.CandooSms_GetMessage();
							if (list6 != null && (Enumerable.Any<CandooGetMessageInfoResponseViewModel>((IEnumerable<CandooGetMessageInfoResponseViewModel>)list6) ? true : false))
							{
								foreach (CandooGetMessageInfoResponseViewModel item25 in list6)
								{
									long result3 = 0L;
									long.TryParse(item25.messageId.ToString(), out result3);
									string text82 = item25.mobileNumber ?? "";
									string smsDesc16 = item25.message ?? "";
									string getId12 = item25.messageId.ToString();
									string text83 = item25.serviceNumber ?? "";
									DateTime now16 = DateTime.Now;
									item25.receivedDate.GetValueOrDefault(now16);
									if (!string.IsNullOrEmpty(text83))
									{
										if (text83.StartsWith("98"))
										{
											text83 = text83.Substring(2);
										}
										if (text83.StartsWith("9"))
										{
											text83 = "0" + text83;
										}
										if (text83.StartsWith("21"))
										{
											text83 = "0" + text83;
										}
									}
									if (!string.IsNullOrEmpty(text82))
									{
										if (text82.StartsWith("98"))
										{
											text82 = text82.Substring(2);
										}
										if (text82.StartsWith("9"))
										{
											text82 = "0" + text82;
										}
										if (text82.StartsWith("21"))
										{
											text82 = "0" + text82;
										}
									}
									DateTime now17 = DateTime.Now;
									DateTime date6 = now17;
									string text84 = "";
									string text85 = "";
									string text86 = "";
									string text87 = "";
									DateTime date7 = now17;
									string text88 = "";
									string text89 = "";
									try
									{
										date6 = now16;
										DateTimeClass.ConvertEnToPerWithLine(date6);
										text84 = date6.ToString("yyyyMMdd", new PersianCulture());
										text85 = date6.ToString(new PersianCulture());
										text86 = DateTimeClass.DefineDayeOfWeekStartWith7(date6.DayOfWeek.ToString());
										text87 = date6.ToString("HH:mm:ss");
									}
									catch (Exception)
									{
										text84 = now17.ToString("yyyyMMdd", new PersianCulture());
										text85 = "";
									}
									try
									{
										date7 = now16;
										DateTimeClass.ConvertEnToPerWithLine(date7);
										text88 = date7.ToString("yyyyMMdd", new PersianCulture());
										text89 = date7.ToString(new PersianCulture());
									}
									catch (Exception)
									{
										text88 = now17.ToString("yyyyMMdd", new PersianCulture());
										text89 = "";
									}
									text87 = date7.ToString("HH:mm:ss");
									text86 = DateTimeClass.DefineDayeOfWeekStartWith7(date7.DayOfWeek.ToString());
									DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
									date6 = DateTime.Parse(date6.ToString("yyyy-MM-dd HH:mm:ss"));
									date7 = DateTime.Parse(date7.ToString("yyyy-MM-dd HH:mm:ss"));
									SmsReceiveViewModel item16 = new SmsReceiveViewModel
									{
										OrderNum = result3,
										SmsNumber = text82,
										SmsDesc = smsDesc16,
										GetId = getId12,
										FromNumber = text83,
										ReceiveDate = date6,
										ReceiveDatePersian = text84,
										ReceiveDatePersianPreview = text85,
										SendDate = date7,
										SendDatePersian = text88,
										SendDatePersianPreview = text89,
										ReceiveDay = text86,
										ReceiveTime = text87
									};
									list.Add(item16);
								}
							}
						}
						else if (smsSetting.SmsProviderId == 21)
						{
							List<ParmisSmsGetMessageInfoResponseViewModel> list7 = sms.ParmisSms_ReceiveSms();
							if (list7 != null && Enumerable.Any<ParmisSmsGetMessageInfoResponseViewModel>((IEnumerable<ParmisSmsGetMessageInfoResponseViewModel>)list7))
							{
								foreach (ParmisSmsGetMessageInfoResponseViewModel item26 in list7)
								{
									long result4 = 0L;
									long.TryParse(item26.MsgID.ToString(), out result4);
									string text90 = item26.Sender ?? "";
									string smsDesc17 = item26.Body ?? "";
									string getId13 = item26.MsgID.ToString();
									string fromNumber6 = item26.Receiver ?? "";
									DateTime now18 = DateTime.Now;
									item26.SendDate.GetValueOrDefault(now18);
									if (!string.IsNullOrWhiteSpace(text90) && text90.StartsWith("9"))
									{
										text90 = "0" + text90;
									}
									DateTime now19 = DateTime.Now;
									DateTime date8 = now19;
									string text91 = "";
									string text92 = "";
									string text93 = "";
									string text94 = "";
									DateTime date9 = now19;
									string text95 = "";
									string text96 = "";
									try
									{
										date8 = now18;
										DateTimeClass.ConvertEnToPerWithLine(date8);
										text91 = date8.ToString("yyyyMMdd", new PersianCulture());
										text92 = date8.ToString(new PersianCulture());
										text93 = DateTimeClass.DefineDayeOfWeekStartWith7(date8.DayOfWeek.ToString());
										text94 = date8.ToString("HH:mm:ss");
									}
									catch (Exception)
									{
										text91 = now19.ToString("yyyyMMdd", new PersianCulture());
										text92 = "";
									}
									try
									{
										date9 = now18;
										DateTimeClass.ConvertEnToPerWithLine(date9);
										text95 = date9.ToString("yyyyMMdd", new PersianCulture());
										text96 = date9.ToString(new PersianCulture());
									}
									catch (Exception)
									{
										text95 = now19.ToString("yyyyMMdd", new PersianCulture());
										text96 = "";
									}
									text94 = date9.ToString("HH:mm:ss");
									text93 = DateTimeClass.DefineDayeOfWeekStartWith7(date9.DayOfWeek.ToString());
									DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
									date8 = DateTime.Parse(date8.ToString("yyyy-MM-dd HH:mm:ss"));
									date9 = DateTime.Parse(date9.ToString("yyyy-MM-dd HH:mm:ss"));
									SmsReceiveViewModel item17 = new SmsReceiveViewModel
									{
										OrderNum = result4,
										SmsNumber = text90,
										SmsDesc = smsDesc17,
										GetId = getId13,
										FromNumber = fromNumber6,
										ReceiveDate = date8,
										ReceiveDatePersian = text91,
										ReceiveDatePersianPreview = text92,
										SendDate = date9,
										SendDatePersian = text95,
										SendDatePersianPreview = text96,
										ReceiveDay = text93,
										ReceiveTime = text94
									};
									list.Add(item17);
								}
							}
						}
						else if (smsSetting.SmsProviderId == 22)
						{
							List<SmsMelliGetMessageInfoResponseViewModel> list8 = sms.SmsMelli_ReceiveSms();
							if (list8 != null && Enumerable.Any<SmsMelliGetMessageInfoResponseViewModel>((IEnumerable<SmsMelliGetMessageInfoResponseViewModel>)list8))
							{
								foreach (SmsMelliGetMessageInfoResponseViewModel item27 in list8)
								{
									long? orderNum4 = null;
									string text97 = item27.from ?? "";
									string smsDesc18 = item27.msg ?? "";
									string getId14 = DateTime.Now.ToString("yyyyMMddHHmmssffff", new CultureInfo("en-US"));
									string text98 = item27.to ?? "";
									DateTime now20 = DateTime.Now;
									long num13 = long.Parse(item27.time ?? "0");
									now20 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(num13).ToLocalTime();
									if (!string.IsNullOrWhiteSpace(text97))
									{
										text97 = text97.Replace("+98", "");
										if (text97.StartsWith("9") && text97.Length == 10)
										{
											text97 = "0" + text97;
										}
									}
									if (!string.IsNullOrWhiteSpace(text98))
									{
										text98 = text98.Replace("+98", "");
									}
									DateTime now21 = DateTime.Now;
									DateTime date10 = now21;
									string text99 = "";
									string text100 = "";
									string text101 = "";
									string text102 = "";
									DateTime date11 = now21;
									string text103 = "";
									string text104 = "";
									try
									{
										date10 = now20;
										DateTimeClass.ConvertEnToPerWithLine(date10);
										text99 = date10.ToString("yyyyMMdd", new PersianCulture());
										text100 = date10.ToString(new PersianCulture());
										text101 = DateTimeClass.DefineDayeOfWeekStartWith7(date10.DayOfWeek.ToString());
										text102 = date10.ToString("HH:mm:ss");
									}
									catch (Exception)
									{
										text99 = now21.ToString("yyyyMMdd", new PersianCulture());
										text100 = "";
									}
									try
									{
										date11 = now20;
										DateTimeClass.ConvertEnToPerWithLine(date11);
										text103 = date11.ToString("yyyyMMdd", new PersianCulture());
										text104 = date11.ToString(new PersianCulture());
									}
									catch (Exception)
									{
										text103 = now21.ToString("yyyyMMdd", new PersianCulture());
										text104 = "";
									}
									text102 = date11.ToString("HH:mm:ss");
									text101 = DateTimeClass.DefineDayeOfWeekStartWith7(date11.DayOfWeek.ToString());
									DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
									date10 = DateTime.Parse(date10.ToString("yyyy-MM-dd HH:mm:ss"));
									date11 = DateTime.Parse(date11.ToString("yyyy-MM-dd HH:mm:ss"));
									SmsReceiveViewModel item18 = new SmsReceiveViewModel
									{
										OrderNum = orderNum4,
										SmsNumber = text97,
										SmsDesc = smsDesc18,
										GetId = getId14,
										FromNumber = text98,
										ReceiveDate = date10,
										ReceiveDatePersian = text99,
										ReceiveDatePersianPreview = text100,
										SendDate = date11,
										SendDatePersian = text103,
										SendDatePersianPreview = text104,
										ReceiveDay = text101,
										ReceiveTime = text102
									};
									list.Add(item18);
								}
							}
						}
						else if (smsSetting.SmsProviderId != 23)
						{
							if (smsSetting.SmsProviderId == 24)
							{
								List<ArmaghanGetMessageInfoResponseViewModel> list9 = sms.Armaghan_ReceiveSms();
								if (list9 != null && Enumerable.Any<ArmaghanGetMessageInfoResponseViewModel>((IEnumerable<ArmaghanGetMessageInfoResponseViewModel>)list9))
								{
									foreach (ArmaghanGetMessageInfoResponseViewModel item28 in list9)
									{
										long? orderNum5 = null;
										string text105 = item28.originator ?? "";
										string smsDesc19 = item28.content ?? "";
										string getId15 = item28.id.GetValueOrDefault().ToString();
										string text106 = item28.destination ?? "";
										DateTime now22 = DateTime.Now;
										long valueOrDefault = item28.insertDate.GetValueOrDefault();
										now22 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(valueOrDefault).ToLocalTime();
										if (!string.IsNullOrWhiteSpace(text105))
										{
											text105 = text105.Replace("+98", "");
											if (text105.StartsWith("98"))
											{
												text105 = text105.Substring(2, text105.Length - 2);
											}
											if (text105.StartsWith("9") && text105.Length == 10)
											{
												text105 = "0" + text105;
											}
										}
										if (!string.IsNullOrWhiteSpace(text106))
										{
											text106 = text106.Replace("+98", "");
											if (text106.StartsWith("98"))
											{
												text106 = text106.Substring(2, text106.Length - 2);
											}
										}
										DateTime now23 = DateTime.Now;
										DateTime date12 = now23;
										string text107 = "";
										string text108 = "";
										string text109 = "";
										string text110 = "";
										DateTime date13 = now23;
										string text111 = "";
										string text112 = "";
										try
										{
											date12 = now22;
											DateTimeClass.ConvertEnToPerWithLine(date12);
											text107 = date12.ToString("yyyyMMdd", new PersianCulture());
											text108 = date12.ToString(new PersianCulture());
											text109 = DateTimeClass.DefineDayeOfWeekStartWith7(date12.DayOfWeek.ToString());
											text110 = date12.ToString("HH:mm:ss");
										}
										catch (Exception)
										{
											text107 = now23.ToString("yyyyMMdd", new PersianCulture());
											text108 = "";
										}
										try
										{
											date13 = now22;
											DateTimeClass.ConvertEnToPerWithLine(date13);
											text111 = date13.ToString("yyyyMMdd", new PersianCulture());
											text112 = date13.ToString(new PersianCulture());
										}
										catch (Exception)
										{
											text111 = now23.ToString("yyyyMMdd", new PersianCulture());
											text112 = "";
										}
										text110 = date13.ToString("HH:mm:ss");
										text109 = DateTimeClass.DefineDayeOfWeekStartWith7(date13.DayOfWeek.ToString());
										DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
										date12 = DateTime.Parse(date12.ToString("yyyy-MM-dd HH:mm:ss"));
										date13 = DateTime.Parse(date13.ToString("yyyy-MM-dd HH:mm:ss"));
										SmsReceiveViewModel item19 = new SmsReceiveViewModel
										{
											OrderNum = orderNum5,
											SmsNumber = text105,
											SmsDesc = smsDesc19,
											GetId = getId15,
											FromNumber = text106,
											ReceiveDate = date12,
											ReceiveDatePersian = text107,
											ReceiveDatePersianPreview = text108,
											SendDate = date13,
											SendDatePersian = text111,
											SendDatePersianPreview = text112,
											ReceiveDay = text109,
											ReceiveTime = text110
										};
										list.Add(item19);
									}
								}
							}
							else if (smsSetting.SmsProviderId != 25 && smsSetting.SmsProviderId == 26)
							{
								List<IPPanelGetMessageViewModel> list10 = sms.IPPanel_ReceiveSms();
								if (list10 != null && Enumerable.Any<IPPanelGetMessageViewModel>((IEnumerable<IPPanelGetMessageViewModel>)list10))
								{
									foreach (IPPanelGetMessageViewModel item29 in list10)
									{
										long valueOrDefault2 = item29.messages_inbox_id.GetValueOrDefault();
										string text113 = item29.from ?? "";
										string smsDesc20 = item29.message ?? "";
										string getId16 = item29.messages_inbox_id.GetValueOrDefault().ToString();
										string text114 = item29.number ?? "";
										DateTime now24 = DateTime.Now;
										long valueOrDefault3 = item29.time.GetValueOrDefault();
										now24 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(valueOrDefault3).ToLocalTime();
										if (!string.IsNullOrWhiteSpace(text113))
										{
											text113 = text113.Replace("+98", "");
											if (text113.StartsWith("98"))
											{
												text113 = text113.Substring(2, text113.Length - 2);
											}
											if (text113.StartsWith("9") && text113.Length == 10)
											{
												text113 = "0" + text113;
											}
										}
										if (!string.IsNullOrWhiteSpace(text114))
										{
											text114 = text114.Replace("+98", "");
											if (text114.StartsWith("98"))
											{
												text114 = text114.Substring(2, text114.Length - 2);
											}
										}
										DateTime now25 = DateTime.Now;
										DateTime date14 = now25;
										string text115 = "";
										string text116 = "";
										string text117 = "";
										string text118 = "";
										DateTime date15 = now25;
										string text119 = "";
										string text120 = "";
										try
										{
											date14 = now24;
											DateTimeClass.ConvertEnToPerWithLine(date14);
											text115 = date14.ToString("yyyyMMdd", new PersianCulture());
											text116 = date14.ToString(new PersianCulture());
											text117 = DateTimeClass.DefineDayeOfWeekStartWith7(date14.DayOfWeek.ToString());
											text118 = date14.ToString("HH:mm:ss");
										}
										catch (Exception)
										{
											text115 = now25.ToString("yyyyMMdd", new PersianCulture());
											text116 = "";
										}
										try
										{
											date15 = now24;
											DateTimeClass.ConvertEnToPerWithLine(date15);
											text119 = date15.ToString("yyyyMMdd", new PersianCulture());
											text120 = date15.ToString(new PersianCulture());
										}
										catch (Exception)
										{
											text119 = now25.ToString("yyyyMMdd", new PersianCulture());
											text120 = "";
										}
										text118 = date15.ToString("HH:mm:ss");
										text117 = DateTimeClass.DefineDayeOfWeekStartWith7(date15.DayOfWeek.ToString());
										DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
										date14 = DateTime.Parse(date14.ToString("yyyy-MM-dd HH:mm:ss"));
										date15 = DateTime.Parse(date15.ToString("yyyy-MM-dd HH:mm:ss"));
										SmsReceiveViewModel item20 = new SmsReceiveViewModel
										{
											OrderNum = valueOrDefault2,
											SmsNumber = text113,
											SmsDesc = smsDesc20,
											GetId = getId16,
											FromNumber = text114,
											ReceiveDate = date14,
											ReceiveDatePersian = text115,
											ReceiveDatePersianPreview = text116,
											SendDate = date15,
											SendDatePersian = text119,
											SendDatePersianPreview = text120,
											ReceiveDay = text117,
											ReceiveTime = text118
										};
										list.Add(item20);
									}
								}
							}
						}
					}
				}
				if (list != null && Enumerable.Any<SmsReceiveViewModel>((IEnumerable<SmsReceiveViewModel>)list))
				{
					DateTime now26 = DateTime.Now;
					int value7 = int.Parse(now26.ToString("MM", new PersianCulture()));
					int value8 = int.Parse(now26.ToString("yyyy", new PersianCulture()));
					string registerDatePersian = now26.ToString("yyyyMMdd", new PersianCulture());
					string appType = Configuration.AppType;
					string smsReceiveJson = JsonConvert.SerializeObject(Enumerable.ToList<SmsReceiveViewModel>((IEnumerable<SmsReceiveViewModel>)list));
					_dbII.SmsspInsertReceiveSmsWeb(smsReceiveJson, userId, value8, value7, appType, now26, registerDatePersian, result2);
					SmsSettingInfoViewModel smsSettingInfoViewModel = SmsSeting.Get();
					if (smsSettingInfoViewModel != null)
					{
						bool result5 = false;
						bool.TryParse(smsSettingInfoViewModel.ActiveSendSMSAfterReceive.ToString(), out result5);
						string value9 = smsSettingInfoViewModel.SendSMSAfterReceiveText ?? "";
						DateTime now27 = DateTime.Now;
						now27.ToString("yyyyMMdd", new PersianCulture());
						if (result5 && !string.IsNullOrWhiteSpace(value9))
						{
							dbI.CRMspAutoSendSMSReceiveAnswer(now27, appType, lCID, result2);
						}
					}
				}
				int valueOrDefault4 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)_dbII.CRMspGetUnReadSmsReceiveCnt()).GetValueOrDefault();
				if (valueOrDefault4 > 0)
				{
					SmsSeting.Update();
					return valueOrDefault4.ToString();
				}
			}
		}
		catch (Exception ex15)
		{
			ErrorSignal.FromCurrentContext().Raise(ex15);
			result = ex15.Message;
		}
		return result;
	}

	public void GetAasanakSms(string Destination = "", string Source = "", string ReceiveTime = "", string MsgBody = "")
	{
		try
		{
			int value = -15;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			new CRMIdeal.Classes.Helper.Sms();
			DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss");
			int freeSmsCount;
			SmsSettingInfoViewModel smsSetting = CRMIdeal.Classes.Helper.Sms.GetSmsSetting(out freeSmsCount);
			string appType = Configuration.AppType;
			if (smsSetting == null)
			{
				return;
			}
			List<SmsReceiveViewModel> list = new List<SmsReceiveViewModel>();
			if (smsSetting.SmsProviderId != 4 || string.IsNullOrWhiteSpace(Destination) || string.IsNullOrWhiteSpace(Source) || string.IsNullOrWhiteSpace(ReceiveTime) || string.IsNullOrWhiteSpace(MsgBody))
			{
				return;
			}
			Destination = Destination.TrimStart(new char[1] { ' ' }).TrimEnd(new char[1] { ' ' });
			if (Destination.StartsWith("$"))
			{
				Destination = Destination.TrimStart(new char[1] { '$' });
			}
			Source = Source.TrimStart(new char[1] { ' ' }).TrimEnd(new char[1] { ' ' });
			if (Source.StartsWith("$"))
			{
				Source = Source.TrimStart(new char[1] { '$' });
			}
			ReceiveTime = ReceiveTime.TrimStart(new char[1] { ' ' }).TrimEnd(new char[1] { ' ' });
			if (ReceiveTime.StartsWith("$"))
			{
				ReceiveTime = ReceiveTime.TrimStart(new char[1] { '$' });
			}
			MsgBody = MsgBody.TrimStart(new char[1] { ' ' }).TrimEnd(new char[1] { ' ' });
			if (MsgBody.StartsWith("$"))
			{
				MsgBody = MsgBody.TrimStart(new char[1] { '$' });
			}
			long value2 = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss"), new CultureInfo("en-US"));
			string text = Source ?? "";
			string text2 = MsgBody ?? "";
			string getId = value2.ToString();
			string text3 = Destination ?? "";
			if (!string.IsNullOrWhiteSpace(text2))
			{
				text2 = HttpUtility.UrlDecode(text2);
			}
			DateTime dateTime = DateTime.Now;
			string value3 = ReceiveTime ?? "";
			double result2 = 0.0;
			if (!string.IsNullOrWhiteSpace(value3))
			{
				double.TryParse(ReceiveTime, out result2);
				double value4 = result2;
				dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(value4).ToLocalTime();
			}
			if (!string.IsNullOrWhiteSpace(text))
			{
				if (text.StartsWith("98"))
				{
					text = text.Substring(2, text.Length - 2);
				}
				if (text.StartsWith("9") && text.Length == 10)
				{
					text = "0" + text;
				}
			}
			if (!string.IsNullOrWhiteSpace(text3))
			{
				if (text3.StartsWith("98"))
				{
					text3 = text3.Substring(2, text3.Length - 2);
				}
				if (text3.StartsWith("9") && text3.Length == 10)
				{
					text3 = "0" + text3;
				}
			}
			DateTime now = DateTime.Now;
			DateTime date = now;
			string text4 = "";
			string text5 = "";
			string text6 = "";
			string text7 = "";
			DateTime date2 = now;
			string text8 = "";
			string text9 = "";
			try
			{
				date = dateTime;
				DateTimeClass.ConvertEnToPerWithLine(date);
				text4 = date.ToString("yyyyMMdd", new PersianCulture());
				text5 = date.ToString(new PersianCulture());
				text6 = DateTimeClass.DefineDayeOfWeekStartWith7(date.DayOfWeek.ToString());
				text7 = date.ToString("HH:mm:ss");
			}
			catch (Exception)
			{
				text4 = now.ToString("yyyyMMdd", new PersianCulture());
				text5 = "";
			}
			try
			{
				date2 = dateTime;
				DateTimeClass.ConvertEnToPerWithLine(date2);
				text8 = date2.ToString("yyyyMMdd", new PersianCulture());
				text9 = date2.ToString(new PersianCulture());
			}
			catch (Exception)
			{
				text8 = now.ToString("yyyyMMdd", new PersianCulture());
				text9 = "";
			}
			text7 = date2.ToString("HH:mm:ss");
			text6 = DateTimeClass.DefineDayeOfWeekStartWith7(date2.DayOfWeek.ToString());
			DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			date = DateTime.Parse(date.ToString("yyyy/MM/dd HH:mm:ss"));
			date2 = DateTime.Parse(date2.ToString("yyyy/MM/dd HH:mm:ss"));
			SmsReceiveViewModel item = new SmsReceiveViewModel
			{
				OrderNum = value2,
				SmsNumber = text,
				SmsDesc = text2,
				GetId = getId,
				FromNumber = text3,
				ReceiveDate = date,
				ReceiveDatePersian = text4,
				ReceiveDatePersianPreview = text5,
				SendDate = date2,
				SendDatePersian = text8,
				SendDatePersianPreview = text9,
				ReceiveDay = text6,
				ReceiveTime = text7
			};
			list.Add(item);
			if (list != null && Enumerable.Any<SmsReceiveViewModel>((IEnumerable<SmsReceiveViewModel>)list))
			{
				DateTime now2 = DateTime.Now;
				int value5 = int.Parse(now2.ToString("MM", new PersianCulture()));
				int value6 = int.Parse(now2.ToString("yyyy", new PersianCulture()));
				string registerDatePersian = now2.ToString("yyyyMMdd", new PersianCulture());
				string smsReceiveJson = JsonConvert.SerializeObject(Enumerable.ToList<SmsReceiveViewModel>((IEnumerable<SmsReceiveViewModel>)list));
				_dbII.SmsspInsertReceiveSmsWeb(smsReceiveJson, value, value6, value5, appType, now2, registerDatePersian, result);
				SmsSettingInfoViewModel smsSettingInfoViewModel = SmsSeting.Get();
				if (smsSettingInfoViewModel != null)
				{
					bool result3 = false;
					bool.TryParse(smsSettingInfoViewModel.ActiveSendSMSAfterReceive.ToString(), out result3);
					string value7 = smsSettingInfoViewModel.SendSMSAfterReceiveText ?? "";
					DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
					if (result3 && !string.IsNullOrWhiteSpace(value7))
					{
						dbI.CRMspAutoSendSMSReceiveAnswer(now, appType, lCID, result);
					}
				}
			}
			SmsSeting.Update();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}

	public void GetParsGreenSms(string Key1 = "", string FROM = "", string TO = "", string BODY = "")
	{
		try
		{
			int value = -15;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			new CRMIdeal.Classes.Helper.Sms();
			DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss");
			int freeSmsCount;
			SmsSettingInfoViewModel smsSetting = CRMIdeal.Classes.Helper.Sms.GetSmsSetting(out freeSmsCount);
			string appType = Configuration.AppType;
			if (smsSetting == null)
			{
				return;
			}
			List<SmsReceiveViewModel> list = new List<SmsReceiveViewModel>();
			if (smsSetting.SmsProviderId != 23 || string.IsNullOrWhiteSpace(FROM) || string.IsNullOrWhiteSpace(TO) || string.IsNullOrWhiteSpace(BODY))
			{
				return;
			}
			FROM = FROM.TrimStart(new char[1] { ' ' }).TrimEnd(new char[1] { ' ' });
			if (FROM.StartsWith("$"))
			{
				FROM = FROM.TrimStart(new char[1] { '$' });
			}
			TO = TO.TrimStart(new char[1] { ' ' }).TrimEnd(new char[1] { ' ' });
			if (TO.StartsWith("$"))
			{
				TO = TO.TrimStart(new char[1] { '$' });
			}
			BODY = BODY.TrimStart(new char[1] { ' ' }).TrimEnd(new char[1] { ' ' });
			if (BODY.StartsWith("$"))
			{
				BODY = BODY.TrimStart(new char[1] { '$' });
			}
			long? orderNum = null;
			string text = FROM ?? "";
			string text2 = BODY ?? "";
			string getId = DateTime.Now.ToString("yyyyMMddHHmmssffff", new CultureInfo("en-US"));
			string text3 = TO ?? "";
			if (!string.IsNullOrWhiteSpace(text))
			{
				text = text.Replace("+98", "");
				if (text.StartsWith("9") && text.Length == 10)
				{
					text = "0" + text;
				}
			}
			if (!string.IsNullOrWhiteSpace(text3))
			{
				text3 = text3.Replace("+98", "");
			}
			if (!string.IsNullOrWhiteSpace(text2))
			{
				text2 = HttpUtility.UrlDecode(text2);
			}
			DateTime now = DateTime.Now;
			DateTime now2 = DateTime.Now;
			DateTime date = now2;
			string text4 = "";
			string text5 = "";
			string text6 = "";
			string text7 = "";
			DateTime date2 = now2;
			string text8 = "";
			string text9 = "";
			try
			{
				date = now;
				DateTimeClass.ConvertEnToPerWithLine(date);
				text4 = date.ToString("yyyyMMdd", new PersianCulture());
				text5 = date.ToString(new PersianCulture());
				text6 = DateTimeClass.DefineDayeOfWeekStartWith7(date.DayOfWeek.ToString());
				text7 = date.ToString("HH:mm:ss");
			}
			catch (Exception)
			{
				text4 = now2.ToString("yyyyMMdd", new PersianCulture());
				text5 = "";
			}
			try
			{
				date2 = now;
				DateTimeClass.ConvertEnToPerWithLine(date2);
				text8 = date2.ToString("yyyyMMdd", new PersianCulture());
				text9 = date2.ToString(new PersianCulture());
			}
			catch (Exception)
			{
				text8 = now2.ToString("yyyyMMdd", new PersianCulture());
				text9 = "";
			}
			text7 = date2.ToString("HH:mm:ss");
			text6 = DateTimeClass.DefineDayeOfWeekStartWith7(date2.DayOfWeek.ToString());
			DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			date = DateTime.Parse(date.ToString("yyyy/MM/dd HH:mm:ss"));
			date2 = DateTime.Parse(date2.ToString("yyyy/MM/dd HH:mm:ss"));
			SmsReceiveViewModel item = new SmsReceiveViewModel
			{
				OrderNum = orderNum,
				SmsNumber = text,
				SmsDesc = text2,
				GetId = getId,
				FromNumber = text3,
				ReceiveDate = date,
				ReceiveDatePersian = text4,
				ReceiveDatePersianPreview = text5,
				SendDate = date2,
				SendDatePersian = text8,
				SendDatePersianPreview = text9,
				ReceiveDay = text6,
				ReceiveTime = text7
			};
			list.Add(item);
			if (list != null && Enumerable.Any<SmsReceiveViewModel>((IEnumerable<SmsReceiveViewModel>)list))
			{
				DateTime now3 = DateTime.Now;
				int value2 = int.Parse(now3.ToString("MM", new PersianCulture()));
				int value3 = int.Parse(now3.ToString("yyyy", new PersianCulture()));
				string registerDatePersian = now3.ToString("yyyyMMdd", new PersianCulture());
				string smsReceiveJson = JsonConvert.SerializeObject(Enumerable.ToList<SmsReceiveViewModel>((IEnumerable<SmsReceiveViewModel>)list));
				_dbII.SmsspInsertReceiveSmsWeb(smsReceiveJson, value, value3, value2, appType, now3, registerDatePersian, result);
				SmsSettingInfoViewModel smsSettingInfoViewModel = SmsSeting.Get();
				if (smsSettingInfoViewModel != null)
				{
					bool result2 = false;
					bool.TryParse(smsSettingInfoViewModel.ActiveSendSMSAfterReceive.ToString(), out result2);
					string value4 = smsSettingInfoViewModel.SendSMSAfterReceiveText ?? "";
					DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
					if (result2 && !string.IsNullOrWhiteSpace(value4))
					{
						dbI.CRMspAutoSendSMSReceiveAnswer(now2, appType, lCID, result);
					}
				}
			}
			SmsSeting.Update();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}

	[AjaxOnly]
	public string UpdateReceiveSmsCmpPrs()
	{
		string text = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			int value = int.Parse(now.ToString("MM", new PersianCulture()));
			int value2 = int.Parse(now.ToString("yyyy", new PersianCulture()));
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			_dbII.SmsspUpdateReceiveSmsCmpPrs(userId, value2, value, appType, now, registerDatePersian);
			return "1";
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			return ex.Message;
		}
	}

	[AjaxOnly]
	public string DeleteTempMobileNumber()
	{
		string text = "";
		try
		{
			return (db.SmsspDeleteSmsTempMobileNumbers(UserLogin.CurrentUser.UserId) > 0) ? "1" : "0";
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return Messages.frmErrorMessage;
		}
	}

	[AjaxOnly]
	[HttpPost]
	public JsonResult DeleteGSMNotSendItem(int id)
	{
		CommonReturnResultViewModel commonReturnResultViewModel = new CommonReturnResultViewModel();
		try
		{
			db.SmsspDeleteGSMNotSendItem(id);
			commonReturnResultViewModel.Message = "";
			commonReturnResultViewModel.IsDone = true;
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
			commonReturnResultViewModel.Message = Messages.cmpErrorDelete;
			commonReturnResultViewModel.IsDone = false;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			commonReturnResultViewModel.Message = Messages.cmpErrorDelete;
			commonReturnResultViewModel.IsDone = false;
		}
		return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	[HttpPost]
	public JsonResult DeleteGSMNotSendItems(int mode)
	{
		CommonReturnResultViewModel commonReturnResultViewModel = new CommonReturnResultViewModel();
		try
		{
			db.SmsspDeleteSMSTankNotSendItems(DateTime.Now, mode);
			commonReturnResultViewModel.Message = "";
			commonReturnResultViewModel.IsDone = true;
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
			commonReturnResultViewModel.Message = Messages.cmpErrorDelete;
			commonReturnResultViewModel.IsDone = false;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			commonReturnResultViewModel.Message = Messages.cmpErrorDelete;
			commonReturnResultViewModel.IsDone = false;
		}
		return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
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

	[HttpGet]
	[AjaxOnly]
	public JsonResult GetSmsWebServicePassword(string inputPassword, int mode)
	{
		if (!UserLogin.IsUserAccess("frmsmsWebServiceSetting", "actShowPassword"))
		{
			return Json(new
			{
				message = Messages.ErrorNotAccess,
				data = inputPassword
			}, JsonRequestBehavior.AllowGet);
		}
		SmsSetting smsSetting = Queryable.FirstOrDefault<SmsSetting>((IQueryable<SmsSetting>)_dbTbl.SmsSetting);
		string obj = ((!string.IsNullOrEmpty(inputPassword)) ? XorCipher.EncryptByPrivateKey(inputPassword) : null);
		string text = ((!string.IsNullOrEmpty(smsSetting.Password)) ? XorCipher.DecryptByPrivateKey(smsSetting.Password) : null);
		bool num = obj == smsSetting.Password;
		bool flag = inputPassword == smsSetting.Password;
		if (!num && !flag)
		{
			return Json(new
			{
				data = inputPassword
			}, JsonRequestBehavior.AllowGet);
		}
		return Json(new
		{
			data = ((mode == 1) ? text : smsSetting.Password)
		}, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult ChargeSmsPanel(int cmpId, int ordId, int ordItemId)
	{
		string text = "";
		CommonResultStatusViewModel status = CommonResultStatusViewModel.Success;
		string data = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (cmpId != 0 && ordId != 0 && ordItemId != 0)
			{
				DateTime now = DateTime.Now;
				DateTime value = now;
				string text2 = now.ToString("yyyyMMdd", new PersianCulture());
				string ordIDeliveryDay = DateTimeClass.DefineDayeOfWeekStartWith7(now.DayOfWeek.ToString());
				string ordIDeliveryTime = now.ToString("HH:mm");
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				_ = Financial.Get().Id;
				short.Parse(now.ToString("yyyy", new PersianCulture()));
				int userId = UserLogin.CurrentUser.UserId;
				string text3 = "";
				string text4 = "";
				string text5 = "";
				int num = 0;
				if (ordItemId <= 0)
				{
					num++;
					text = text + Messages.msgErrorNotSelectedItem + "<br>";
				}
				if (ordId <= 0)
				{
					num++;
					text = text + string.Format(Messages.msgErrorIsNotSelectedItem, Labels.lblOrd) + "<br>";
				}
				if (cmpId <= 0)
				{
					num++;
					text = text + Messages.msgErrorNotSelectCompany + "<br>";
				}
				WSspSelectOrderItemsByCmpIdAndManufacturerName_Result wSspSelectOrderItemsByCmpIdAndManufacturerName_Result = Enumerable.FirstOrDefault<WSspSelectOrderItemsByCmpIdAndManufacturerName_Result>((IEnumerable<WSspSelectOrderItemsByCmpIdAndManufacturerName_Result>)dbI.WSspSelectOrderItemsByCmpIdAndManufacturerName(cmpId, "SMSMehrAfraz", lCID, result, false, ""));
				if (wSspSelectOrderItemsByCmpIdAndManufacturerName_Result == null)
				{
					num++;
					text = text + Messages.msgErrorOrderNotHavePrdModuleSms + "<br>";
				}
				else
				{
					if (string.IsNullOrWhiteSpace(wSspSelectOrderItemsByCmpIdAndManufacturerName_Result.PrdManufacturerName) || string.IsNullOrWhiteSpace(wSspSelectOrderItemsByCmpIdAndManufacturerName_Result.PrdManufacturerCode) || wSspSelectOrderItemsByCmpIdAndManufacturerName_Result.PrdManufacturerName != "SMSMehrAfraz")
					{
						num++;
						text = text + string.Format(Messages.msgErrorOrderNotHavePrdModuleSmsInfo, wSspSelectOrderItemsByCmpIdAndManufacturerName_Result.PrdName ?? "") + "<br>";
					}
					text3 = wSspSelectOrderItemsByCmpIdAndManufacturerName_Result.ordIDescriptionI ?? "";
					text4 = wSspSelectOrderItemsByCmpIdAndManufacturerName_Result.PrdManufacturerCode ?? "";
				}
				WSspSelectOrderItemsById_Result wSspSelectOrderItemsById_Result = Enumerable.FirstOrDefault<WSspSelectOrderItemsById_Result>((IEnumerable<WSspSelectOrderItemsById_Result>)dbI.WSspSelectOrderItemsById(ordItemId, lCID, result));
				if (num == 0)
				{
					if (wSspSelectOrderItemsById_Result == null)
					{
						num++;
						text = text + Messages.msgErrorNotSelectedItem + "<br>";
					}
					else
					{
						if (string.IsNullOrWhiteSpace(wSspSelectOrderItemsById_Result.PrdManufacturerName) || wSspSelectOrderItemsById_Result.PrdManufacturerName != "SMSMehrAfrazCharge")
						{
							num++;
							text = text + Messages.msgErrorOrderNotHavePrdChargeSms + "<br>";
						}
						if (wSspSelectOrderItemsById_Result.ordIDeliveryDate.HasValue && wSspSelectOrderItemsById_Result.ordIDeliveryUserId.GetValueOrDefault() != 0)
						{
							string text6 = $"{wSspSelectOrderItemsById_Result.ordIPriceSum.GetValueOrDefault():N2}";
							text6 = text6.Replace(".00", "");
							if (!string.IsNullOrWhiteSpace(wSspSelectOrderItemsById_Result.ordICurrencyUnit))
							{
								text6 = text6 + " " + wSspSelectOrderItemsById_Result.ordICurrencyUnit;
							}
							string arg = (wSspSelectOrderItemsById_Result.ordIDeliveryDate.HasValue ? wSspSelectOrderItemsById_Result.ordIDeliveryDate.Value.ToString("yyyy/MM/dd") : "");
							text = text + string.Format(Messages.msgErrorChargeSmsAlreadyByUser, text6, wSspSelectOrderItemsById_Result.ordIDeliveryUser ?? "", arg) + "<br>";
							num++;
						}
						if (string.IsNullOrWhiteSpace(text4))
						{
							text = text + string.Format(Messages.msgErrorChargeSmsNotDefineApiKey, wSspSelectOrderItemsByCmpIdAndManufacturerName_Result.PrdName ?? "") + "<br>";
							num++;
						}
						if (string.IsNullOrWhiteSpace(text3))
						{
							text = text + string.Format(Messages.msgErrorChargeSmsNotDefineUserName, wSspSelectOrderItemsByCmpIdAndManufacturerName_Result.PrdName ?? "") + "<br>";
							num++;
						}
						else
						{
							int num2 = text3.IndexOf("UserName:", StringComparison.Ordinal);
							int num3 = text3.IndexOf("\n", StringComparison.Ordinal) - num2;
							if (num3 > 0)
							{
								text5 = text3.Substring(num2, num3);
							}
							text5 = text5.Replace("UserName:", "");
							if (!string.IsNullOrWhiteSpace(text5))
							{
								if (text5.StartsWith(" "))
								{
									text5 = text5.TrimStart(new char[1] { ' ' });
								}
								if (text5.EndsWith(" "))
								{
									text5 = text5.TrimEnd(new char[1] { ' ' });
								}
							}
							if (string.IsNullOrWhiteSpace(text5))
							{
								text = text + string.Format(Messages.msgErrorChargeSmsNotDefineUserName, wSspSelectOrderItemsByCmpIdAndManufacturerName_Result.PrdName ?? "") + "<br>";
								num++;
							}
							string text7 = "";
							string[] array = text3.Split(new string[1] { "\n" }, StringSplitOptions.None);
							if (array != null && array.Length >= 3)
							{
								text7 = array[2];
							}
							text7 = text7.Replace("Num:", "");
							if (!string.IsNullOrWhiteSpace(text7))
							{
								text7 = text7.Replace("\r", "");
								if (text7.StartsWith(" "))
								{
									text7 = text7.TrimStart(new char[1] { ' ' });
								}
								if (text7.EndsWith(" "))
								{
									text7 = text7.TrimEnd(new char[1] { ' ' });
								}
							}
							if (string.IsNullOrWhiteSpace(text7))
							{
								text = text + Messages.msgErrorChargeSmsNotDefineNumber + "<br>";
								num++;
							}
						}
					}
				}
				if (num == 0)
				{
					long result2 = 0L;
					long.TryParse(wSspSelectOrderItemsById_Result.ordIPriceSum.GetValueOrDefault().ToString().Replace(".00", ""), out result2);
					CRMIdeal.Classes.Helper.Sms sms = new CRMIdeal.Classes.Helper.Sms();
					string msgError = "";
					string text8 = sms.MehrAfraz_Chargeuser(text4, text5, result2, ref msgError);
					if (text8 != "0")
					{
						text = text + string.Format(Messages.msgErrorChargeSmsErrorCode, text8) + "<br>" + msgError;
						num++;
					}
					else
					{
						dbI.WSspUpdateOrderItemDeliveryUserAndDate(wSspSelectOrderItemsById_Result.OrderItemID, value, text2, ordIDeliveryTime, ordIDeliveryDay, userId, appType, value2, userId, value, text2, result);
						data = "1";
						text = Messages.msgSuccessAction;
						status = CommonResultStatusViewModel.Success;
					}
				}
				else
				{
					data = "";
					if (string.IsNullOrWhiteSpace(text))
					{
						text = Messages.msgErrorRunFunction;
					}
					status = CommonResultStatusViewModel.Error;
				}
			}
			else
			{
				data = "";
				text = Messages.msgErrorRunFunction;
				status = CommonResultStatusViewModel.Error;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			data = "";
			text = Messages.msgErrorRunFunction + " " + ex.Message;
			status = CommonResultStatusViewModel.Error;
		}
		CommonResultViewModel<string> data2 = new CommonResultViewModel<string>
		{
			Data = data,
			Message = text,
			Status = status
		};
		return Json(data2, JsonRequestBehavior.AllowGet);
	}

	protected override void Dispose(bool disposing)
	{
		db.Dispose();
		_dbTbl.Dispose();
		dbI.Dispose();
		_dbII.Dispose();
		base.Dispose(disposing);
	}
}
