using System;
using System.Collections.Generic;
using System.Linq;
using CRM.Models;
using CRM.Resources;
using Elmah;

namespace CRMIdeal.Classes.Helper;

public class DiscountCode
{
	public static CommonResultViewModel<WSspSelectDiscountCodeByDisCode_Result> CheckDiscountCodeToUse(string disCode = "", int companyId = 0, int currLangId = 1065, int defLangId = 1065)
	{
		CommonResultViewModel<WSspSelectDiscountCodeByDisCode_Result> commonResultViewModel = new CommonResultViewModel<WSspSelectDiscountCodeByDisCode_Result>();
		commonResultViewModel.Status = CommonResultStatusViewModel.Fail;
		CRMSpIEntities cRMSpIEntities = new CRMSpIEntities();
		CRMSpIIEntities cRMSpIIEntities = new CRMSpIIEntities();
		int result = 0;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result);
		}
		try
		{
			if (string.IsNullOrWhiteSpace(disCode))
			{
				commonResultViewModel.Status = CommonResultStatusViewModel.Error;
				commonResultViewModel.Message = string.Format(Messages.FOMsgErrorIsNotEnteredItem, Labels.FOShpCartDisCode);
				return commonResultViewModel;
			}
			WSspSelectDiscountCodeByDisCode_Result wSspSelectDiscountCodeByDisCode_Result = Enumerable.FirstOrDefault<WSspSelectDiscountCodeByDisCode_Result>((IEnumerable<WSspSelectDiscountCodeByDisCode_Result>)cRMSpIEntities.WSspSelectDiscountCodeByDisCode(disCode, currLangId, 0));
			if (wSspSelectDiscountCodeByDisCode_Result == null)
			{
				commonResultViewModel.Status = CommonResultStatusViewModel.Error;
				commonResultViewModel.Message = string.Format(Messages.FOMsgErrorIsNotEnteredItem, Labels.FOShpCartDisCode);
				return commonResultViewModel;
			}
			if (wSspSelectDiscountCodeByDisCode_Result.DisExpDate.Date < DateTime.Now.Date)
			{
				commonResultViewModel.Status = CommonResultStatusViewModel.Error;
				commonResultViewModel.Message = Messages.FOMsgErrorDisCodeExpired;
				return commonResultViewModel;
			}
			if (wSspSelectDiscountCodeByDisCode_Result.DisCmpId.GetValueOrDefault() != 0 && wSspSelectDiscountCodeByDisCode_Result.DisCmpId.GetValueOrDefault() != companyId)
			{
				commonResultViewModel.Status = CommonResultStatusViewModel.Error;
				commonResultViewModel.Message = Messages.FOMsgErrorDisCodeUnUsableForYou;
				return commonResultViewModel;
			}
			int? num = ((wSspSelectDiscountCodeByDisCode_Result.DisUseCntPerCmp.GetValueOrDefault() == 0) ? new int?(1) : wSspSelectDiscountCodeByDisCode_Result.DisUseCntPerCmp);
			List<WSspSelectDiscountCodeHistoryWithDisCodeId_Result> list = Enumerable.ToList<WSspSelectDiscountCodeHistoryWithDisCodeId_Result>((IEnumerable<WSspSelectDiscountCodeHistoryWithDisCodeId_Result>)cRMSpIIEntities.WSspSelectDiscountCodeHistoryWithDisCodeId(wSspSelectDiscountCodeByDisCode_Result.DiscountCodeId, currLangId, defLangId));
			if (list != null && list.Count >= wSspSelectDiscountCodeByDisCode_Result.DisUseCnt)
			{
				commonResultViewModel.Status = CommonResultStatusViewModel.Error;
				commonResultViewModel.Message = Messages.FOMsgErrorDisCodeUseCntExpired;
				return commonResultViewModel;
			}
			if (wSspSelectDiscountCodeByDisCode_Result.DisCmpId == 0 && Enumerable.ToList<WSspSelectDiscountCodeHistoryWithDisCodeId_Result>(Enumerable.Where<WSspSelectDiscountCodeHistoryWithDisCodeId_Result>((IEnumerable<WSspSelectDiscountCodeHistoryWithDisCodeId_Result>)list, (Func<WSspSelectDiscountCodeHistoryWithDisCodeId_Result, bool>)((WSspSelectDiscountCodeHistoryWithDisCodeId_Result x) => x.DisCmpId == companyId))).Count >= num)
			{
				commonResultViewModel.Status = CommonResultStatusViewModel.Error;
				commonResultViewModel.Message = Messages.FODiscountCodeUsedBefore;
				return commonResultViewModel;
			}
			if (wSspSelectDiscountCodeByDisCode_Result.ScoreRate.GetValueOrDefault() != 0.0 && wSspSelectDiscountCodeByDisCode_Result.DisSingleCmpScoreId.GetValueOrDefault() == 0)
			{
				double result2 = 0.0;
				CRMspReturnSumCompanyScores_Result cRMspReturnSumCompanyScores_Result = Enumerable.FirstOrDefault<CRMspReturnSumCompanyScores_Result>((IEnumerable<CRMspReturnSumCompanyScores_Result>)cRMSpIEntities.CRMspReturnSumCompanyScores(companyId, result));
				if (cRMspReturnSumCompanyScores_Result != null)
				{
					double.TryParse(cRMspReturnSumCompanyScores_Result.SumUsableScores.ToString(), out result2);
				}
				if (wSspSelectDiscountCodeByDisCode_Result.ScoreRate.GetValueOrDefault() > result2)
				{
					commonResultViewModel.Status = CommonResultStatusViewModel.Error;
					commonResultViewModel.Message = string.Format(Messages.FOMsgErrorDisCodeNoScoreMin, wSspSelectDiscountCodeByDisCode_Result.ScoreRate.GetValueOrDefault().ToString());
					return commonResultViewModel;
				}
			}
			commonResultViewModel.Status = CommonResultStatusViewModel.Success;
			commonResultViewModel.Message = "";
			commonResultViewModel.Data = wSspSelectDiscountCodeByDisCode_Result;
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			commonResultViewModel.Status = CommonResultStatusViewModel.Error;
			commonResultViewModel.Message = ex.Message;
		}
		finally
		{
			cRMSpIEntities?.Dispose();
			cRMSpIIEntities?.Dispose();
		}
		return commonResultViewModel;
	}
}
