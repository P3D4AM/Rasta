using System;
using System.Collections.Generic;
using System.Linq;
using CRM.Resources;
using Elmah;
using Mobile.DataType;
using Mobile.Models;

namespace Mobile.Classes.Helper;

public class DiscountCode
{
	public static ServiceResult<MobspSelectDiscountCodeByDisCode_Result> CheckDiscountCodeToUse(string disCode = "", int companyId = 0, int currLangId = 1065, int defLangId = 1065, int? cId = null)
	{
		ServiceResult<MobspSelectDiscountCodeByDisCode_Result> serviceResult = new ServiceResult<MobspSelectDiscountCodeByDisCode_Result>();
		serviceResult.Status = ServiceResultStatus.Fail;
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		try
		{
			cRMEntities = new CRMEntities();
			cRMSpEntities = new CRMSpEntities();
			if (string.IsNullOrWhiteSpace(disCode))
			{
				serviceResult.Status = ServiceResultStatus.Error;
				serviceResult.Message = string.Format(Messages.FOMsgErrorIsNotEnteredItem, Labels.FOShpCartDisCode);
				return serviceResult;
			}
			MobspSelectDiscountCodeByDisCode_Result mobspSelectDiscountCodeByDisCode_Result = Enumerable.FirstOrDefault<MobspSelectDiscountCodeByDisCode_Result>((IEnumerable<MobspSelectDiscountCodeByDisCode_Result>)cRMEntities.MobspSelectDiscountCodeByDisCode(disCode, currLangId, 0));
			if (mobspSelectDiscountCodeByDisCode_Result == null)
			{
				serviceResult.Status = ServiceResultStatus.Error;
				serviceResult.Message = string.Format(Messages.FOMsgErrorIsNotEnteredItem, Labels.FOShpCartDisCode);
				return serviceResult;
			}
			if (mobspSelectDiscountCodeByDisCode_Result.DisExpDate.Date < DateTime.Now.Date)
			{
				serviceResult.Status = ServiceResultStatus.Error;
				serviceResult.Message = Messages.FOMsgErrorDisCodeExpired;
				return serviceResult;
			}
			if (mobspSelectDiscountCodeByDisCode_Result.DisCmpId.GetValueOrDefault() != 0 && mobspSelectDiscountCodeByDisCode_Result.DisCmpId.GetValueOrDefault() != companyId)
			{
				serviceResult.Status = ServiceResultStatus.Error;
				serviceResult.Message = Messages.FOMsgErrorDisCodeUnUsableForYou;
				return serviceResult;
			}
			int? num = ((mobspSelectDiscountCodeByDisCode_Result.DisUseCntPerCmp.GetValueOrDefault() == 0) ? new int?(1) : mobspSelectDiscountCodeByDisCode_Result.DisUseCntPerCmp);
			List<MobspSelectDiscountCodeHistoryWithDisCodeId_Result> list = Enumerable.ToList<MobspSelectDiscountCodeHistoryWithDisCodeId_Result>((IEnumerable<MobspSelectDiscountCodeHistoryWithDisCodeId_Result>)cRMSpEntities.MobspSelectDiscountCodeHistoryWithDisCodeId(mobspSelectDiscountCodeByDisCode_Result.DiscountCodeId, currLangId, defLangId));
			if (list != null && list.Count >= mobspSelectDiscountCodeByDisCode_Result.DisUseCnt)
			{
				serviceResult.Status = ServiceResultStatus.Error;
				serviceResult.Message = Messages.FOMsgErrorDisCodeUseCntExpired;
				return serviceResult;
			}
			if (mobspSelectDiscountCodeByDisCode_Result.DisCmpId == 0 && Enumerable.ToList<MobspSelectDiscountCodeHistoryWithDisCodeId_Result>(Enumerable.Where<MobspSelectDiscountCodeHistoryWithDisCodeId_Result>((IEnumerable<MobspSelectDiscountCodeHistoryWithDisCodeId_Result>)list, (Func<MobspSelectDiscountCodeHistoryWithDisCodeId_Result, bool>)((MobspSelectDiscountCodeHistoryWithDisCodeId_Result x) => x.DisCmpId == companyId))).Count >= num)
			{
				serviceResult.Status = ServiceResultStatus.Error;
				serviceResult.Message = Messages.FODiscountCodeUsedBefore;
				return serviceResult;
			}
			if (mobspSelectDiscountCodeByDisCode_Result.ScoreRate.GetValueOrDefault() != 0.0 && mobspSelectDiscountCodeByDisCode_Result.DisSingleCmpScoreId.GetValueOrDefault() == 0)
			{
				double result = 0.0;
				MobspReturnSumCompanyScores_Result mobspReturnSumCompanyScores_Result = Enumerable.FirstOrDefault<MobspReturnSumCompanyScores_Result>((IEnumerable<MobspReturnSumCompanyScores_Result>)cRMSpEntities.MobspReturnSumCompanyScores(companyId, cId));
				if (mobspReturnSumCompanyScores_Result != null)
				{
					double.TryParse(mobspReturnSumCompanyScores_Result.SumUsableScores.ToString(), out result);
				}
				if (mobspSelectDiscountCodeByDisCode_Result.ScoreRate.GetValueOrDefault() > result)
				{
					serviceResult.Status = ServiceResultStatus.Error;
					serviceResult.Message = string.Format(Messages.FOMsgErrorDisCodeNoScoreMin, mobspSelectDiscountCodeByDisCode_Result.ScoreRate.GetValueOrDefault().ToString());
					return serviceResult;
				}
			}
			serviceResult.Status = ServiceResultStatus.Success;
			serviceResult.Message = "";
			serviceResult.Data = mobspSelectDiscountCodeByDisCode_Result;
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			serviceResult.Status = ServiceResultStatus.Error;
			serviceResult.Message = ex.Message;
		}
		finally
		{
			cRMEntities?.Dispose();
			cRMSpEntities?.Dispose();
		}
		return serviceResult;
	}
}
