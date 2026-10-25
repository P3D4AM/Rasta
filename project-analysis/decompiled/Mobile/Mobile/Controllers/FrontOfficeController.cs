using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CRM.Resources;
using Elmah;
using Mobile.Cache.Setting;
using Mobile.Classes;
using Mobile.Classes.Helper;
using Mobile.DataType;
using Mobile.Models;
using Mobile.Models.ViewModel.FrontOffice;

namespace Mobile.Controllers;

public class FrontOfficeController : ApiController
{
	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<LoadGalleryViewModel>> GetGallery(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<LoadGalleryViewModel> list = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					list = new List<LoadGalleryViewModel>();
					MobspSelectHomePageSetting_Result mobspSelectHomePageSetting_Result = Enumerable.FirstOrDefault<MobspSelectHomePageSetting_Result>((IEnumerable<MobspSelectHomePageSetting_Result>)cRMEntities.MobspSelectHomePageSetting(result, result2));
					if (mobspSelectHomePageSetting_Result.ShpHomeGalleryIdI.HasValue)
					{
						LoadGalleryViewModel gallery = CmsGallery.GetGallery1(mobspSelectHomePageSetting_Result.ShpHomeGalleryIdI.GetValueOrDefault());
						list.Add(gallery);
					}
					if (mobspSelectHomePageSetting_Result.ShpHomeGalleryIdII.HasValue)
					{
						LoadGalleryViewModel gallery2 = CmsGallery.GetGallery1(mobspSelectHomePageSetting_Result.ShpHomeGalleryIdII.GetValueOrDefault());
						list.Add(gallery2);
					}
					if (mobspSelectHomePageSetting_Result.ShpHomeGalleryIdIII.HasValue)
					{
						LoadGalleryViewModel gallery3 = CmsGallery.GetGallery1(mobspSelectHomePageSetting_Result.ShpHomeGalleryIdIII.GetValueOrDefault());
						list.Add(gallery3);
					}
					message = "";
					status = ServiceResultStatus.Success;
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
			message = Messages.MobMsgErrorDoneOperation;
			list = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<LoadGalleryViewModel>>
		{
			Message = message,
			Data = list,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectCmsNews_Result>> SelectNews(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspSelectCmsNews_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					data = Enumerable.ToList<MobspSelectCmsNews_Result>((IEnumerable<MobspSelectCmsNews_Result>)cRMEntities.MobspSelectCmsNews(result, result2));
					message = "";
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<MobspSelectCmsNews_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}
}
