using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web.Mvc;
using CRM.General.Security;
using CRM.General.Utilities;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;

namespace CRMIdeal.Areas.Telegram.Controllers;

public class ContactController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public int contactId;

		public int prsId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_1
	{
		public CrmCompanyPersons prs;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_3
	{
		public CrmCompanyPersons prs;
	}

	private CRMSpEntities _db = new CRMSpEntities();

	private CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	[DynamicAuthorize(ControllerName = "frmTelegram", ActionName = "actAddContactToCompanyPerson,actEditContactFromCompanyPerson")]
	public ActionResult TelegAddEditPersonToCompany(int contactId, int cmpId, int prsId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		if (cmpId > 0 && prsId > 0)
		{
			if (!UserLogin.IsUserAccess("frmTelegram", "actEditContactFromCompanyPerson"))
			{
				base.ViewBag.Error = Messages.NotAccessToPage;
				return null;
			}
			base.ViewBag.CmpName = CRMIdeal.Classes.Helper.Company.GetCompanyNameWithTitle(cmpId);
			base.ViewBag.PrsName = CRMIdeal.Classes.Helper.Company.GetCmpPersonFullName(prsId);
			base.ViewBag.Mode = "Edit";
		}
		else if (!UserLogin.IsUserAccess("frmTelegram", "actAddContactToCompanyPerson"))
		{
			base.ViewBag.Error = Messages.NotAccessToPage;
			return null;
		}
		base.ViewBag.Mode = "Add";
		base.ViewBag.CmpId = cmpId;
		base.ViewBag.PrsId = prsId;
		base.ViewBag.ContactId = contactId;
		return View();
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmTelegram", ActionName = "actAddContactToCompanyPerson,actEditContactFromCompanyPerson")]
	public JsonResult AddEditPersonToCompany(int contactId, int cmpId, int prsId, bool isAddPicture, bool isNewPerson, bool isCheckMobile, int isBot = 0)
	{
		_003C_003Ec__DisplayClass4_0 _003C_003Ec__DisplayClass4_ = new _003C_003Ec__DisplayClass4_0();
		_003C_003Ec__DisplayClass4_.contactId = contactId;
		_003C_003Ec__DisplayClass4_.prsId = prsId;
		new List<CRMspMainSearchWeb_Result>();
		CommonReturnResultViewModel commonReturnResultViewModel = new CommonReturnResultViewModel();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			if (_003C_003Ec__DisplayClass4_.contactId > 0 && cmpId > 0 && _003C_003Ec__DisplayClass4_.prsId > 0)
			{
				switch (isBot)
				{
				case 0:
				{
					DbSet<CrmTelegContacts> crmTelegContacts = _dbTbl.CrmTelegContacts;
					ParameterExpression val = Expression.Parameter(typeof(CrmTelegContacts), "m");
					CrmTelegContacts crmTelegContacts2 = Queryable.FirstOrDefault<CrmTelegContacts>((IQueryable<CrmTelegContacts>)crmTelegContacts, Expression.Lambda<Func<CrmTelegContacts, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass4_, typeof(_003C_003Ec__DisplayClass4_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
					if (crmTelegContacts2 != null)
					{
						_003C_003Ec__DisplayClass4_1 _003C_003Ec__DisplayClass4_3 = new _003C_003Ec__DisplayClass4_1();
						string text2 = (string.IsNullOrEmpty(crmTelegContacts2.PhoneNumber) ? null : (crmTelegContacts2.PhoneNumber.StartsWith("98") ? ("0" + crmTelegContacts2.PhoneNumber.Substring(2)) : crmTelegContacts2.PhoneNumber));
						DbSet<CrmCompanyPersons> crmCompanyPersons3 = _dbTbl.CrmCompanyPersons;
						val = Expression.Parameter(typeof(CrmCompanyPersons), "c");
						_003C_003Ec__DisplayClass4_3.prs = Queryable.FirstOrDefault<CrmCompanyPersons>((IQueryable<CrmCompanyPersons>)crmCompanyPersons3, Expression.Lambda<Func<CrmCompanyPersons, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass4_, typeof(_003C_003Ec__DisplayClass4_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
						if (_003C_003Ec__DisplayClass4_3.prs != null && isCheckMobile && text2 != null && !string.IsNullOrEmpty(_003C_003Ec__DisplayClass4_3.prs.prsMobile) && _003C_003Ec__DisplayClass4_3.prs.prsMobile != text2)
						{
							commonReturnResultViewModel.Message = Messages.msgTelegramPrsMobileNotSameContactPhone;
							commonReturnResultViewModel.IsDone = true;
							commonReturnResultViewModel.Tag = 1;
							return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
						}
						if (isNewPerson && _003C_003Ec__DisplayClass4_3.prs != null)
						{
							CrmCompanyPersons crmCompanyPersons4 = new CrmCompanyPersons
							{
								prsTelegramId = (int?)crmTelegContacts2.ChatId,
								LanguageID = result,
								prsCompanyId = cmpId,
								UserId = UserLogin.CurrentUser.UserId,
								prsFirstRegisterUserId = UserLogin.CurrentUser.UserId,
								Year1 = short.Parse(Financial.Get().Id.ToString()),
								Month1 = short.Parse(now.ToString("MM", new PersianCulture())),
								GUId = System.Guid.NewGuid(),
								RegisterDate = now,
								RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
								ImportDate = now.ToString("yyyyMMdd", new PersianCulture()),
								ImportDateTime = now,
								AddType = 2,
								AppType = Configuration.AppType,
								prsTitleId = _003C_003Ec__DisplayClass4_3.prs.prsTitleId,
								prsLName = _003C_003Ec__DisplayClass4_3.prs.prsLName,
								prsFName = _003C_003Ec__DisplayClass4_3.prs.prsFName,
								prsMobile = text2,
								prsDescription = Labels.TelegramForPrsDescription,
								FirstRegisterDate = now,
								FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
								FirstRegisterUserId = UserLogin.CurrentUser.UserId
							};
							crmCompanyPersons4.prsFName = crmCompanyPersons4.prsFName.ArabicToPersian();
							crmCompanyPersons4.prsLName = crmCompanyPersons4.prsLName.ArabicToPersian();
							_dbTbl.CrmCompanyPersons.Add(crmCompanyPersons4);
							_dbTbl.SaveChanges();
							if (crmCompanyPersons4.CompanyPersonID > 0)
							{
								_003C_003Ec__DisplayClass4_.prsId = crmCompanyPersons4.CompanyPersonID;
								DbSet<CrmCompanyPersons_Lang> crmCompanyPersons_Lang2 = _dbTbl.CrmCompanyPersons_Lang;
								val = Expression.Parameter(typeof(CrmCompanyPersons_Lang), "m");
								foreach (CrmCompanyPersons_Lang prsItem in Enumerable.ToList<CrmCompanyPersons_Lang>((IEnumerable<CrmCompanyPersons_Lang>)Queryable.Where<CrmCompanyPersons_Lang>((IQueryable<CrmCompanyPersons_Lang>)crmCompanyPersons_Lang2, Expression.Lambda<Func<CrmCompanyPersons_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass4_3, typeof(_003C_003Ec__DisplayClass4_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }))))
								{
									Languages languages2 = Enumerable.FirstOrDefault<Languages>((IEnumerable<Languages>)Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID == prsItem.LanguageID));
									if (languages2 != null)
									{
										CrmCompanyPersons_Lang entity2 = new CrmCompanyPersons_Lang
										{
											LanguageID = prsItem.LanguageID,
											CompanyPersonID = _003C_003Ec__DisplayClass4_.prsId,
											prsLName = prsItem.prsLName,
											prsFName = prsItem.prsFName,
											prsDescription = MyResource.GetResourceString("TelegramForPrsDescription", languages2.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly)
										};
										_dbTbl.CrmCompanyPersons_Lang.Add(entity2);
										_dbTbl.SaveChanges();
									}
								}
							}
						}
						else if (_003C_003Ec__DisplayClass4_3.prs != null)
						{
							_003C_003Ec__DisplayClass4_3.prs.prsTelegramId = (int?)crmTelegContacts2.ChatId;
							_003C_003Ec__DisplayClass4_3.prs.UserId = UserLogin.CurrentUser.UserId;
							_003C_003Ec__DisplayClass4_3.prs.prsMobile = text2 ?? _003C_003Ec__DisplayClass4_3.prs.prsMobile;
							_003C_003Ec__DisplayClass4_3.prs.Year1 = short.Parse(Financial.Get().Id.ToString());
							_003C_003Ec__DisplayClass4_3.prs.RegisterDate = now;
							_003C_003Ec__DisplayClass4_3.prs.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
							_003C_003Ec__DisplayClass4_3.prs.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
							_003C_003Ec__DisplayClass4_3.prs.AppType = Configuration.AppType;
							_dbTbl.Entry(_003C_003Ec__DisplayClass4_3.prs).State = EntityState.Modified;
							_dbTbl.SaveChanges();
						}
						crmTelegContacts2.UserId = UserLogin.CurrentUser.UserId;
						crmTelegContacts2.RegisterDate = now;
						crmTelegContacts2.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						crmTelegContacts2.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
						crmTelegContacts2.AppType = Configuration.AppType;
						crmTelegContacts2.Year1 = short.Parse(now.ToString("yyyy", new PersianCulture()));
						crmTelegContacts2.CompanyId = cmpId;
						crmTelegContacts2.CompanyPersonId = _003C_003Ec__DisplayClass4_.prsId;
						string companyNameWithTitle2 = CRMIdeal.Classes.Helper.Company.GetCompanyNameWithTitle(cmpId);
						string cmpPersonFullName2 = CRMIdeal.Classes.Helper.Company.GetCmpPersonFullName(_003C_003Ec__DisplayClass4_.prsId);
						crmTelegContacts2.Title = ((!string.IsNullOrEmpty(companyNameWithTitle2)) ? (companyNameWithTitle2 + ((!string.IsNullOrEmpty(cmpPersonFullName2)) ? (" - " + cmpPersonFullName2) : "")) : "");
						_dbTbl.Entry(crmTelegContacts2).State = EntityState.Modified;
						_dbTbl.SaveChanges();
						if (crmTelegContacts2.Picture != null && isAddPicture)
						{
							DbSet<CrmPersonPicture> crmPersonPicture3 = _dbTbl.CrmPersonPicture;
							val = Expression.Parameter(typeof(CrmPersonPicture), "c");
							CrmPersonPicture crmPersonPicture4 = Queryable.FirstOrDefault<CrmPersonPicture>((IQueryable<CrmPersonPicture>)crmPersonPicture3, Expression.Lambda<Func<CrmPersonPicture, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Convert((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass4_, typeof(_003C_003Ec__DisplayClass4_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), typeof(int?))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							bool flag2 = false;
							if (crmPersonPicture4 == null)
							{
								crmPersonPicture4 = new CrmPersonPicture();
								flag2 = true;
							}
							crmPersonPicture4.AppType = Configuration.AppType;
							crmPersonPicture4.Year1 = short.Parse(Financial.Get().Id.ToString());
							crmPersonPicture4.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
							crmPersonPicture4.RegisterDate = now;
							crmPersonPicture4.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
							crmPersonPicture4.UserId = UserLogin.CurrentUser.UserId;
							crmPersonPicture4.PersonPicture = crmTelegContacts2.Picture;
							if (flag2)
							{
								crmPersonPicture4.CompanyPersonId = _003C_003Ec__DisplayClass4_.prsId;
								crmPersonPicture4.GUId = System.Guid.NewGuid();
								crmPersonPicture4.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
								crmPersonPicture4.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
								crmPersonPicture4.FirstRegisterDate = now;
								crmPersonPicture4.LanguageID = result;
								_dbTbl.CrmPersonPicture.Add(crmPersonPicture4);
							}
							else
							{
								_dbTbl.Entry(crmPersonPicture4).State = EntityState.Modified;
							}
							_dbTbl.SaveChanges();
						}
						commonReturnResultViewModel.Message = Messages.msgSuccessAction;
						commonReturnResultViewModel.IsDone = true;
					}
					else
					{
						commonReturnResultViewModel.Message = Messages.msgErrorRunFunction;
						commonReturnResultViewModel.IsDone = false;
					}
					break;
				}
				case 1:
				{
					DbSet<CrmTelegBotContacts> crmTelegBotContacts = _dbTbl.CrmTelegBotContacts;
					ParameterExpression val = Expression.Parameter(typeof(CrmTelegBotContacts), "m");
					CrmTelegBotContacts crmTelegBotContacts2 = Queryable.FirstOrDefault<CrmTelegBotContacts>((IQueryable<CrmTelegBotContacts>)crmTelegBotContacts, Expression.Lambda<Func<CrmTelegBotContacts, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass4_, typeof(_003C_003Ec__DisplayClass4_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
					if (crmTelegBotContacts2 != null)
					{
						_003C_003Ec__DisplayClass4_3 _003C_003Ec__DisplayClass4_2 = new _003C_003Ec__DisplayClass4_3();
						string text = (string.IsNullOrEmpty(crmTelegBotContacts2.PhoneNumber) ? null : (crmTelegBotContacts2.PhoneNumber.StartsWith("98") ? ("0" + crmTelegBotContacts2.PhoneNumber.Substring(2)) : crmTelegBotContacts2.PhoneNumber));
						DbSet<CrmCompanyPersons> crmCompanyPersons = _dbTbl.CrmCompanyPersons;
						val = Expression.Parameter(typeof(CrmCompanyPersons), "c");
						_003C_003Ec__DisplayClass4_2.prs = Queryable.FirstOrDefault<CrmCompanyPersons>((IQueryable<CrmCompanyPersons>)crmCompanyPersons, Expression.Lambda<Func<CrmCompanyPersons, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass4_, typeof(_003C_003Ec__DisplayClass4_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
						if (_003C_003Ec__DisplayClass4_2.prs != null && isCheckMobile && text != null && !string.IsNullOrEmpty(_003C_003Ec__DisplayClass4_2.prs.prsMobile) && _003C_003Ec__DisplayClass4_2.prs.prsMobile != text)
						{
							commonReturnResultViewModel.Message = Messages.msgTelegramPrsMobileNotSameContactPhone;
							commonReturnResultViewModel.IsDone = true;
							commonReturnResultViewModel.Tag = 1;
							return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
						}
						if (isNewPerson && _003C_003Ec__DisplayClass4_2.prs != null)
						{
							CrmCompanyPersons crmCompanyPersons2 = new CrmCompanyPersons
							{
								prsTelegramId = (int?)crmTelegBotContacts2.ChatId,
								LanguageID = result,
								prsCompanyId = cmpId,
								UserId = UserLogin.CurrentUser.UserId,
								prsFirstRegisterUserId = UserLogin.CurrentUser.UserId,
								Year1 = short.Parse(Financial.Get().Id.ToString()),
								Month1 = short.Parse(now.ToString("MM", new PersianCulture())),
								GUId = System.Guid.NewGuid(),
								RegisterDate = now,
								RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
								ImportDate = now.ToString("yyyyMMdd", new PersianCulture()),
								ImportDateTime = now,
								AddType = 2,
								AppType = Configuration.AppType,
								prsTitleId = _003C_003Ec__DisplayClass4_2.prs.prsTitleId,
								prsLName = _003C_003Ec__DisplayClass4_2.prs.prsLName,
								prsFName = _003C_003Ec__DisplayClass4_2.prs.prsFName,
								prsMobile = text,
								prsDescription = Labels.TelegramForPrsDescription,
								FirstRegisterDate = now,
								FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
								FirstRegisterUserId = UserLogin.CurrentUser.UserId
							};
							crmCompanyPersons2.prsFName = crmCompanyPersons2.prsFName.ArabicToPersian();
							crmCompanyPersons2.prsLName = crmCompanyPersons2.prsLName.ArabicToPersian();
							_dbTbl.CrmCompanyPersons.Add(crmCompanyPersons2);
							_dbTbl.SaveChanges();
							if (crmCompanyPersons2.CompanyPersonID > 0)
							{
								_003C_003Ec__DisplayClass4_.prsId = crmCompanyPersons2.CompanyPersonID;
								DbSet<CrmCompanyPersons_Lang> crmCompanyPersons_Lang = _dbTbl.CrmCompanyPersons_Lang;
								val = Expression.Parameter(typeof(CrmCompanyPersons_Lang), "m");
								foreach (CrmCompanyPersons_Lang prsItem2 in Enumerable.ToList<CrmCompanyPersons_Lang>((IEnumerable<CrmCompanyPersons_Lang>)Queryable.Where<CrmCompanyPersons_Lang>((IQueryable<CrmCompanyPersons_Lang>)crmCompanyPersons_Lang, Expression.Lambda<Func<CrmCompanyPersons_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass4_2, typeof(_003C_003Ec__DisplayClass4_3)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }))))
								{
									Languages languages = Enumerable.FirstOrDefault<Languages>((IEnumerable<Languages>)Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID == prsItem2.LanguageID));
									if (languages != null)
									{
										CrmCompanyPersons_Lang entity = new CrmCompanyPersons_Lang
										{
											LanguageID = prsItem2.LanguageID,
											CompanyPersonID = _003C_003Ec__DisplayClass4_.prsId,
											prsLName = prsItem2.prsLName,
											prsFName = prsItem2.prsFName,
											prsDescription = MyResource.GetResourceString("TelegramForPrsDescription", languages.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly)
										};
										_dbTbl.CrmCompanyPersons_Lang.Add(entity);
										_dbTbl.SaveChanges();
									}
								}
							}
						}
						else if (_003C_003Ec__DisplayClass4_2.prs != null)
						{
							_003C_003Ec__DisplayClass4_2.prs.prsTelegramId = (int?)crmTelegBotContacts2.ChatId;
							_003C_003Ec__DisplayClass4_2.prs.UserId = UserLogin.CurrentUser.UserId;
							_003C_003Ec__DisplayClass4_2.prs.prsMobile = text ?? _003C_003Ec__DisplayClass4_2.prs.prsMobile;
							_003C_003Ec__DisplayClass4_2.prs.Year1 = short.Parse(Financial.Get().Id.ToString());
							_003C_003Ec__DisplayClass4_2.prs.RegisterDate = now;
							_003C_003Ec__DisplayClass4_2.prs.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
							_003C_003Ec__DisplayClass4_2.prs.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
							_003C_003Ec__DisplayClass4_2.prs.AppType = Configuration.AppType;
							_dbTbl.Entry(_003C_003Ec__DisplayClass4_2.prs).State = EntityState.Modified;
							_dbTbl.SaveChanges();
						}
						crmTelegBotContacts2.UserId = UserLogin.CurrentUser.UserId;
						crmTelegBotContacts2.RegisterDate = now;
						crmTelegBotContacts2.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						crmTelegBotContacts2.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
						crmTelegBotContacts2.AppType = Configuration.AppType;
						crmTelegBotContacts2.Year1 = short.Parse(now.ToString("yyyy", new PersianCulture()));
						crmTelegBotContacts2.CompanyId = cmpId;
						crmTelegBotContacts2.CompanyPersonId = _003C_003Ec__DisplayClass4_.prsId;
						string companyNameWithTitle = CRMIdeal.Classes.Helper.Company.GetCompanyNameWithTitle(cmpId);
						string cmpPersonFullName = CRMIdeal.Classes.Helper.Company.GetCmpPersonFullName(_003C_003Ec__DisplayClass4_.prsId);
						crmTelegBotContacts2.Title = ((!string.IsNullOrEmpty(companyNameWithTitle)) ? (companyNameWithTitle + ((!string.IsNullOrEmpty(cmpPersonFullName)) ? (" - " + cmpPersonFullName) : "")) : "");
						_dbTbl.Entry(crmTelegBotContacts2).State = EntityState.Modified;
						_dbTbl.SaveChanges();
						if (crmTelegBotContacts2.Picture != null && isAddPicture)
						{
							DbSet<CrmPersonPicture> crmPersonPicture = _dbTbl.CrmPersonPicture;
							val = Expression.Parameter(typeof(CrmPersonPicture), "c");
							CrmPersonPicture crmPersonPicture2 = Queryable.FirstOrDefault<CrmPersonPicture>((IQueryable<CrmPersonPicture>)crmPersonPicture, Expression.Lambda<Func<CrmPersonPicture, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Convert((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass4_, typeof(_003C_003Ec__DisplayClass4_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), typeof(int?))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							bool flag = false;
							if (crmPersonPicture2 == null)
							{
								crmPersonPicture2 = new CrmPersonPicture();
								flag = true;
							}
							crmPersonPicture2.AppType = Configuration.AppType;
							crmPersonPicture2.Year1 = short.Parse(Financial.Get().Id.ToString());
							crmPersonPicture2.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
							crmPersonPicture2.RegisterDate = now;
							crmPersonPicture2.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
							crmPersonPicture2.UserId = UserLogin.CurrentUser.UserId;
							crmPersonPicture2.PersonPicture = crmTelegBotContacts2.Picture;
							if (flag)
							{
								crmPersonPicture2.CompanyPersonId = _003C_003Ec__DisplayClass4_.prsId;
								crmPersonPicture2.GUId = System.Guid.NewGuid();
								crmPersonPicture2.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
								crmPersonPicture2.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
								crmPersonPicture2.FirstRegisterDate = now;
								crmPersonPicture2.LanguageID = result;
								_dbTbl.CrmPersonPicture.Add(crmPersonPicture2);
							}
							else
							{
								_dbTbl.Entry(crmPersonPicture2).State = EntityState.Modified;
							}
							_dbTbl.SaveChanges();
						}
						commonReturnResultViewModel.Message = Messages.msgSuccessAction;
						commonReturnResultViewModel.IsDone = true;
					}
					else
					{
						commonReturnResultViewModel.Message = Messages.msgErrorRunFunction;
						commonReturnResultViewModel.IsDone = false;
					}
					break;
				}
				}
			}
			else
			{
				commonReturnResultViewModel.Message = Messages.msgErrorRunFunction;
				commonReturnResultViewModel.IsDone = false;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			commonReturnResultViewModel.Message = ex.Message;
			commonReturnResultViewModel.IsDone = false;
		}
		return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetCompany(string value = "")
	{
		List<CRMspMainSearchWeb_Result> data = new List<CRMspMainSearchWeb_Result>();
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
			data = Enumerable.ToList<CRMspMainSearchWeb_Result>((IEnumerable<CRMspMainSearchWeb_Result>)_dbI.CRMspMainSearchWeb(value, UserLogin.CurrentUser.UserId, 1, lCID, result, ",1000,1,2,3,8,9,11,12,14,17,20,21,22,", result2));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetCompanyPerson(int cmpId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectCompanyPersons_Result> list = new List<CRMspSelectCompanyPersons_Result>();
		try
		{
			List<CRMspSelectCompanyPersons_Result> list2 = CRMIdeal.Classes.Helper.Company.SelectCompanyPersons(cmpId);
			list.Add(new CRMspSelectCompanyPersons_Result
			{
				CompanyPersonID = -1,
				PersonName = Labels.SelectedListDefValue
			});
			list.AddRange(Enumerable.Select<CRMspSelectCompanyPersons_Result, CRMspSelectCompanyPersons_Result>((IEnumerable<CRMspSelectCompanyPersons_Result>)list2, (Func<CRMspSelectCompanyPersons_Result, CRMspSelectCompanyPersons_Result>)((CRMspSelectCompanyPersons_Result item) => new CRMspSelectCompanyPersons_Result
			{
				CompanyPersonID = item.CompanyPersonID,
				PersonName = item.PersonTitleName
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmTelegram", ActionName = "actAddTelegramContact")]
	public ActionResult TelegAddContact()
	{
		return View();
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		base.Dispose(disposing);
	}
}
