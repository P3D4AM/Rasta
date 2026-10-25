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

namespace Mobile.Controllers;

public class FOKnowledgeTankController : ApiController
{
	[HttpPost]
	[FoMobileAuthorize]
	public ServiceResult<FoKnowledgeTankInfoViewModel> GetKnowledgeTankInfo(int knowledgeTankId, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		FoKnowledgeTankInfoViewModel foKnowledgeTankInfoViewModel = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new FoCommon().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					cRMSpEntities = new CRMSpEntities();
					FOMobspknlgSelectKnowledgeTankById_Result fOMobspknlgSelectKnowledgeTankById_Result = Enumerable.FirstOrDefault<FOMobspknlgSelectKnowledgeTankById_Result>((IEnumerable<FOMobspknlgSelectKnowledgeTankById_Result>)cRMSpEntities.FOMobspknlgSelectKnowledgeTankById(knowledgeTankId, num, result2));
					if (fOMobspknlgSelectKnowledgeTankById_Result != null)
					{
						foKnowledgeTankInfoViewModel = new FoKnowledgeTankInfoViewModel();
						foKnowledgeTankInfoViewModel.KnowledgeTank = fOMobspknlgSelectKnowledgeTankById_Result;
						foKnowledgeTankInfoViewModel.ListKnlgFiles = new List<FOMobspSelectFilesDirectory_Result>();
						List<FOMobspSelectFilesDirectory_Result> list = Enumerable.ToList<FOMobspSelectFilesDirectory_Result>((IEnumerable<FOMobspSelectFilesDirectory_Result>)cRMEntities.FOMobspSelectFilesDirectory("0", "0", "0", "40", knowledgeTankId.ToString(), num, result2, true, cId));
						if (list != null && Enumerable.Any<FOMobspSelectFilesDirectory_Result>((IEnumerable<FOMobspSelectFilesDirectory_Result>)list))
						{
							foKnowledgeTankInfoViewModel.ListKnlgFiles = list;
						}
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					else
					{
						message = Messages.MobMsgErrorProjectNotFound;
						status = ServiceResultStatus.Fail;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					foKnowledgeTankInfoViewModel = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				foKnowledgeTankInfoViewModel = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			foKnowledgeTankInfoViewModel = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<FoKnowledgeTankInfoViewModel>
		{
			Message = message,
			Data = foKnowledgeTankInfoViewModel,
			Status = status
		};
	}
}
