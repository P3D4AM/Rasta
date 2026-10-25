using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using Elmah;

namespace CRMIdeal.Areas.OtherSystems.Controllers;

public class ProductQuantityApiController : ApiController
{
	public class MobLinkAccPrdQuantityViewModel
	{
		public int PrdId { get; set; }

		public double PrdQuantity { get; set; }
	}

	private readonly CRMEntities _db = new CRMEntities();

	[MobileApiAuthorize]
	public ServiceResult<List<MobLinkAccPrdQuantityViewModel>> GetLinkAccProductQuantityByIds(string prdIds, int cmpId, int whId, int? ln = null, string linkAccWhId = "", string tracing = "", string sefareshCode = "", int linkAccSettingDBId = 0)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		int culture = ((result > 0) ? result : result2);
		List<MobLinkAccPrdQuantityViewModel> list = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		new BaseInfo().SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				MobileApiTokenViewModel token2 = new MobileApi().GetToken(token);
				if (token2 != null)
				{
					list = new List<MobLinkAccPrdQuantityViewModel>();
					double result3 = 0.0;
					foreach (string item in Enumerable.ToList<string>((IEnumerable<string>)prdIds.Split(new char[1] { ',' })))
					{
						int result4 = 0;
						int.TryParse(item, out result4);
						string text = CRMIdeal.Classes.Helper.OtherSystems.GetPrdQuantity(token2.userId, result4, whId, linkAccWhId, tracing, cmpId, sefareshCode, linkAccSettingDBId);
						if (!string.IsNullOrEmpty(text))
						{
							if (text == Labels.frmError)
							{
								text = "0";
							}
							double.TryParse(text, out result3);
						}
						MobLinkAccPrdQuantityViewModel mobLinkAccPrdQuantityViewModel = new MobLinkAccPrdQuantityViewModel();
						mobLinkAccPrdQuantityViewModel.PrdId = result4;
						mobLinkAccPrdQuantityViewModel.PrdQuantity = result3;
						list.Add(mobLinkAccPrdQuantityViewModel);
					}
					if (Enumerable.Any<MobLinkAccPrdQuantityViewModel>((IEnumerable<MobLinkAccPrdQuantityViewModel>)list))
					{
						message = "";
						status = ServiceResultStatus.Success;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					list = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				list = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return new ServiceResult<List<MobLinkAccPrdQuantityViewModel>>
		{
			Message = message,
			Data = list,
			Status = status
		};
	}

	[MobileApiAuthorize]
	public ServiceResult<MobLinkAccPrdQuantityViewModel> GetLinkAccProductQuantityById(int prdId, int cmpId, int whId, int? ln = null, string linkAccWhId = "", string tracing = "", string sefareshCode = "", int linkAccSettingDBId = 0)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		int culture = ((result > 0) ? result : result2);
		MobLinkAccPrdQuantityViewModel mobLinkAccPrdQuantityViewModel = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		new BaseInfo().SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				MobileApiTokenViewModel token2 = new MobileApi().GetToken(token);
				if (token2 != null)
				{
					mobLinkAccPrdQuantityViewModel = new MobLinkAccPrdQuantityViewModel();
					double result3 = 0.0;
					string text = CRMIdeal.Classes.Helper.OtherSystems.GetPrdQuantity(token2.userId, prdId, whId, linkAccWhId, tracing, cmpId, sefareshCode, linkAccSettingDBId);
					if (!string.IsNullOrEmpty(text))
					{
						if (text == Labels.frmError)
						{
							text = "0";
						}
						double.TryParse(text, out result3);
					}
					mobLinkAccPrdQuantityViewModel.PrdId = prdId;
					mobLinkAccPrdQuantityViewModel.PrdQuantity = result3;
					message = "";
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					mobLinkAccPrdQuantityViewModel = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				mobLinkAccPrdQuantityViewModel = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return new ServiceResult<MobLinkAccPrdQuantityViewModel>
		{
			Message = message,
			Data = mobLinkAccPrdQuantityViewModel,
			Status = status
		};
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		base.Dispose(disposing);
	}
}
