using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.GSD.Globalization;
using Elmah;

namespace CRMIdeal.Areas.Setting.Controllers;

public class TelegSettingController : Controller
{
	public static HttpServerUtilityBase CurrServer = null;

	private static readonly string facadeFtp = Configuration.FacadeFtp;

	private static readonly string userNameFtp = Configuration.UserNameFtp;

	private static readonly string passwordFtp = Configuration.PasswordFtp;

	private static readonly bool usePassiveFtp = Configuration.UsePassiveFtp;

	private static readonly string pathFtp = Configuration.PathFtp;

	private CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private CRMSpIEntities _dbI = new CRMSpIEntities();

	private CRMSpIIEntities _dbII = new CRMSpIIEntities();

	private static int _settingId = 0;

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actSetting")]
	public ActionResult Index(int settingId = 0)
	{
		TelegramSeting.Update();
		CrmTelegSettingViewModel model = new CrmTelegSettingViewModel();
		base.ViewBag.SelectSettingId = settingId;
		return View(model);
	}

	private int InsertTelegContact(InsertTelegContactViewModel model)
	{
		int result = 0;
		if (model != null)
		{
			CRMSpEntities cRMSpEntities = null;
			try
			{
				cRMSpEntities = new CRMSpEntities();
				_dbI = new CRMSpIEntities();
				ObjectParameter objectParameter = new ObjectParameter("Result", 0);
				DateTime now = DateTime.Now;
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
				if (result2 <= 0)
				{
					result2 = 1065;
				}
				_ = Thread.CurrentThread.CurrentCulture.LCID;
				string text = now.ToString("yyyyMMdd", new PersianCulture());
				short value = short.Parse(now.ToString("MM", new PersianCulture()));
				short value2 = short.Parse(now.ToString("yyyy", new PersianCulture()));
				_ = UserLogin.CurrentUser.UserId;
				int? companyId = null;
				int? companyPersonId = null;
				string text2 = model.PhoneNumber;
				if (text2.StartsWith("+98"))
				{
					text2 = text2.Substring(4);
				}
				else if (text2.StartsWith("0098"))
				{
					text2 = text2.Substring(5);
				}
				else if (text2.StartsWith("098"))
				{
					text2 = text2.Substring(4);
				}
				else if (text2.StartsWith("98"))
				{
					text2 = text2.Substring(3);
				}
				else if (text2.StartsWith("0"))
				{
					text2 = text2.Substring(1);
				}
				List<CRMspSelectCompanyPersonsByMobile_Result> list = Enumerable.ToList<CRMspSelectCompanyPersonsByMobile_Result>((IEnumerable<CRMspSelectCompanyPersonsByMobile_Result>)_dbII.CRMspSelectCompanyPersonsByMobile(text2, model.LanguageId, result2));
				if (list != null && list.Count == 1)
				{
					companyId = Enumerable.FirstOrDefault<CRMspSelectCompanyPersonsByMobile_Result>((IEnumerable<CRMspSelectCompanyPersonsByMobile_Result>)list).prsCompanyId;
					companyPersonId = Enumerable.FirstOrDefault<CRMspSelectCompanyPersonsByMobile_Result>((IEnumerable<CRMspSelectCompanyPersonsByMobile_Result>)list).CompanyPersonID;
				}
				_dbI.CRMspInsertTelegContact(model.ChatId, model.FirstName, model.LastName, model.UserName, model.PhoneNumber, model.Type, Labels.TelegramBotUnknown, model.Picture, model.IsActive, model.UnReadMessageCount, model.LastMessageDate, model.UserId, text, month1: value, year1: value2, appType: model.AppType, languageID: model.LanguageId, settingId: model.SettingId, result: objectParameter, telegUserId: null, companyId: companyId, companyPersonId: companyPersonId);
				result = int.Parse(objectParameter.Value.ToString());
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				result = -1;
			}
			finally
			{
				cRMSpEntities?.Dispose();
			}
		}
		return result;
	}
}
