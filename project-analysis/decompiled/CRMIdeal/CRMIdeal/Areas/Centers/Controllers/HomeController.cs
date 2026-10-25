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
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Centers.Controllers;

public class HomeController : Controller
{
	private readonly CRMSpIIEntities _db_spII = new CRMSpIIEntities();

	[LoginAuthorize]
	public ActionResult Index()
	{
		return View();
	}

	[LoginAuthorize]
	public ActionResult InsertEdit(int centerId = 0)
	{
		CRMspSelectCenterWithId_Result cRMspSelectCenterWithId_Result = SelectCenterWithId(centerId);
		if (cRMspSelectCenterWithId_Result != null && cRMspSelectCenterWithId_Result.OrderView.GetValueOrDefault() <= 0)
		{
			List<CRMspSelectCenters_Result> list = Center.Get();
			cRMspSelectCenterWithId_Result.OrderView = Enumerable.Max<CRMspSelectCenters_Result>((IEnumerable<CRMspSelectCenters_Result>)list, (Func<CRMspSelectCenters_Result, int?>)((CRMspSelectCenters_Result m) => m.OrderView)).GetValueOrDefault() + 10;
		}
		return View(cRMspSelectCenterWithId_Result);
	}

	[HttpPost]
	[LoginAuthorize]
	public string InsertEdit(int centerId = 0, string centerName = null, string centerName_Lang = null, string centerDesc = null, string centerDesc_Lang = null, bool? centerInActive = null, int? orderView = null, int updateCenterPictureMode = -1, HttpPostedFileBase centerPicture = null, int parentId = 0, string centerCode = "", string centerSeoTitle = null, string centerSeoTitle_Lang = null, string centerSeoDescription = null, string centerSeoDescription_Lang = null, string centerSeoHttpEquiv = null, string centerSeoExpires = null, bool? centerSeoGoogleNotranslate = null, string centerSeoDistribution = null, string centerSeoRobots = null, string centerSeoRating = null, string centerSeoAuthor = null, string centerSeoAuthor_Lang = null, bool? centerSeoIsUseSocialNetwork = null, int? centerSeoMobileOptimized = null, string centerSeoCopyright = null, string centerSeoCopyright_Lang = null, bool? centerSeoUseDefault = null, string centerSeoKeywords = null, string centerSeoKeywords_Lang = null, string centerSeoFAQ = null, string centerSeoFAQ_Lang = null, bool? centerSeoIsActive = null)
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
			string text = now.ToString("yyyyMMdd", new PersianCulture());
			int userId = UserLogin.CurrentUser.UserId;
			int.Parse(Financial.Get().Id.ToString());
			short value2 = short.Parse(Financial.Get().Id.ToString());
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			if (centerId != 0 && !VersionBuyer.Center)
			{
				return string.Format(Messages.VersionBuyModuleName, Labels.Center);
			}
			if (centerId == 0)
			{
				if (!centerInActive.GetValueOrDefault() && Center.ActiveCnt(centerId) >= Center.MaxAllowedCnt)
				{
					return string.Format(Messages.msgErrorCenterActiveCount, Center.MaxAllowedCnt);
				}
			}
			else
			{
				CRMspSelectCenterWithId_Result cRMspSelectCenterWithId_Result = SelectCenterWithId(centerId);
				if (cRMspSelectCenterWithId_Result != null)
				{
					bool result3 = false;
					bool.TryParse(cRMspSelectCenterWithId_Result.CenterInActive.ToString(), out result3);
					if (result3 && !centerInActive.GetValueOrDefault() && Center.ActiveCnt(centerId) >= Center.MaxAllowedCnt)
					{
						return string.Format(Messages.msgErrorCenterActiveCount, Center.MaxAllowedCnt);
					}
				}
			}
			if (orderView.GetValueOrDefault() == 0)
			{
				List<CRMspSelectCenters_Result> list = Center.Get();
				orderView = Enumerable.Max<CRMspSelectCenters_Result>((IEnumerable<CRMspSelectCenters_Result>)list, (Func<CRMspSelectCenters_Result, int?>)((CRMspSelectCenters_Result m) => m.OrderView)).GetValueOrDefault() + 10;
			}
			if (!string.IsNullOrWhiteSpace(centerCode))
			{
				CRMspCheckDuplicateCenterCode_Result cRMspCheckDuplicateCenterCode_Result = Enumerable.FirstOrDefault<CRMspCheckDuplicateCenterCode_Result>((IEnumerable<CRMspCheckDuplicateCenterCode_Result>)_db_spII.CRMspCheckDuplicateCenterCode(centerId, centerCode, lCID, result2));
				if (cRMspCheckDuplicateCenterCode_Result != null)
				{
					return string.Format(Messages.msgErrorCheckDuplicateCenterCode, cRMspCheckDuplicateCenterCode_Result.CenterName ?? "");
				}
			}
			byte[] centerPicture2 = null;
			if (centerPicture != null)
			{
				centerPicture2 = ImageManager.CompressHttpPostedFileBase(new ImageManager.ImageParam
				{
					HttpPostedFileBase_Var = centerPicture
				});
			}
			if (centerId != 0)
			{
				_db_spII.CRMspUpdateCenter(centerId, centerName, centerName_Lang, centerDesc, centerDesc_Lang, centerInActive, orderView, userId: userId, year1: value2, month1: value3, registerDate: value, registerDatePersian: text, appType: appType, languageID: lCID, defaultLanguageID: result2, updateCenterPictureMode: updateCenterPictureMode, centerPicture: centerPicture2, parentId: parentId, centerCode: centerCode, centerSeoIsActive: centerSeoIsActive, centerSeoTitle: centerSeoTitle, centerSeoTitle_Lang: centerSeoTitle_Lang, centerSeoDescription: centerSeoDescription, centerSeoDescription_Lang: centerSeoDescription_Lang, centerSeoHttpEquiv: centerSeoHttpEquiv, centerSeoExpires: centerSeoExpires, centerSeoGoogleNotranslate: centerSeoGoogleNotranslate, centerSeoDistribution: centerSeoDistribution, centerSeoRobots: centerSeoRobots, centerSeoRating: centerSeoRating, centerSeoAuthor: centerSeoAuthor, centerSeoAuthor_Lang: centerSeoAuthor_Lang, centerSeoIsUseSocialNetwork: centerSeoIsUseSocialNetwork, centerSeoMobileOptimized: centerSeoMobileOptimized, centerSeoCopyright: centerSeoCopyright, centerSeoCopyright_Lang: centerSeoCopyright_Lang, centerSeoUseDefault: centerSeoUseDefault, centerSeoKeywords: centerSeoKeywords, centerSeoKeywords_Lang: centerSeoKeywords_Lang, centerSeoFAQ: centerSeoFAQ, centerSeoFAQ_Lang: centerSeoFAQ_Lang);
			}
			else
			{
				ObjectParameter objectParameter = new ObjectParameter("InsertedId", 0);
				CRMSpIIEntities db_spII = _db_spII;
				bool? centerInActive3 = centerInActive;
				int? orderView3 = orderView;
				int? userId3 = userId;
				short? year2 = value2;
				short? month2 = value3;
				DateTime? registerDate2 = value;
				string registerDatePersian2 = text;
				string appType3 = appType;
				int? languageID2 = lCID;
				int? defaultLanguageID2 = result2;
				ObjectParameter insertedId = objectParameter;
				db_spII.CRMspInsertCenter(centerName, centerName_Lang, centerDesc, centerDesc_Lang, centerInActive3, orderView3, centerPicture2, parentId, centerCode, userId3, year2, month2, registerDate2, registerDatePersian2, appType3, languageID2, defaultLanguageID2, insertedId, centerSeoIsActive, centerSeoTitle, centerSeoTitle_Lang, centerSeoDescription, centerSeoDescription_Lang, centerSeoHttpEquiv, centerSeoExpires, centerSeoGoogleNotranslate, centerSeoDistribution, centerSeoRobots, centerSeoRating, centerSeoAuthor, centerSeoAuthor_Lang, centerSeoIsUseSocialNetwork, centerSeoMobileOptimized, centerSeoCopyright, centerSeoCopyright_Lang, centerSeoUseDefault, centerSeoKeywords, centerSeoKeywords_Lang, centerSeoFAQ, centerSeoFAQ_Lang);
				if (objectParameter != null)
				{
					result = (string.IsNullOrWhiteSpace(objectParameter.Value.ToString()) ? Messages.MsgErrorDoneOperation : objectParameter.Value.ToString());
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			result = "Error: " + ex.Message;
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string Delete(int id = 0)
	{
		string result = "";
		try
		{
			mct_II_Result mct_II_Result = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_db_spII.CRMspDeleteCenter(id));
			if (mct_II_Result != null)
			{
				if (mct_II_Result.Result == 1)
				{
					result = "";
				}
				else if (mct_II_Result.Result == 0)
				{
					result = Messages.msgErrorOperationFailed;
				}
				else if (mct_II_Result.Result == -1)
				{
					result = Messages.RedundancyMessage;
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			result = "Error: " + ex.Message;
		}
		return result;
	}

	public string GetTreeCenterParent(int currCId = 0)
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
			List<CRMspSelectCentersTree_Result> list = Enumerable.ToList<CRMspSelectCentersTree_Result>((IEnumerable<CRMspSelectCentersTree_Result>)_db_spII.CRMspSelectCentersTree(lCID, result2));
			if (list != null && Enumerable.Any<CRMspSelectCentersTree_Result>((IEnumerable<CRMspSelectCentersTree_Result>)list))
			{
				foreach (CRMspSelectCentersTree_Result item in list)
				{
					if (!string.IsNullOrWhiteSpace(item.CenterCode))
					{
						item.CenterName = item.CenterName + " (" + item.CenterCode + ")";
					}
				}
			}
			if (list != null)
			{
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
	[LoginAuthorize]
	public List<CRMspSelectCenters_Result> SelectCenters()
	{
		List<CRMspSelectCenters_Result> result = new List<CRMspSelectCenters_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectCenters_Result> list = Enumerable.ToList<CRMspSelectCenters_Result>((IEnumerable<CRMspSelectCenters_Result>)_db_spII.CRMspSelectCenters(lCID, result2));
			if (list != null && Enumerable.Any<CRMspSelectCenters_Result>((IEnumerable<CRMspSelectCenters_Result>)list))
			{
				foreach (CRMspSelectCenters_Result item in list)
				{
					if (!string.IsNullOrWhiteSpace(item.CenterCode))
					{
						item.CenterName = item.CenterName + " (" + item.CenterCode + ")";
					}
				}
				result = list;
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
	public string GetCenters()
	{
		return JsonConvert.SerializeObject(SelectCenters());
	}

	[HttpPost]
	[LoginAuthorize]
	public CRMspSelectCenterWithId_Result SelectCenterWithId(int centerId = 0)
	{
		CRMspSelectCenterWithId_Result result = new CRMspSelectCenterWithId_Result();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			CRMspSelectCenterWithId_Result cRMspSelectCenterWithId_Result = Enumerable.FirstOrDefault<CRMspSelectCenterWithId_Result>((IEnumerable<CRMspSelectCenterWithId_Result>)_db_spII.CRMspSelectCenterWithId(centerId, lCID, result2));
			if (cRMspSelectCenterWithId_Result != null)
			{
				result = cRMspSelectCenterWithId_Result;
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
	public string GetCenterWithId(int centerId = 0)
	{
		return JsonConvert.SerializeObject(SelectCenterWithId(centerId));
	}
}
