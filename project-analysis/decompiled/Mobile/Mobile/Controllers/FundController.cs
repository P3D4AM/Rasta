using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Web.Http;
using System.Web.Script.Serialization;
using CRM.General.Calendar;
using CRM.General.IO.FTP;
using CRM.Resources;
using Elmah;
using GSD.Globalization;
using Mobile.Cache.Setting;
using Mobile.Classes;
using Mobile.Classes.Helper;
using Mobile.DataType;
using Mobile.Models;

namespace Mobile.Controllers;

public class FundController : ApiController
{
	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<FundResultViewModel> GetFundList(FundViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		FundResultViewModel fundResultViewModel = new FundResultViewModel();
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
					cRMSpEntities = new CRMSpEntities();
					DateTime now = DateTime.Now;
					now.ToString("yyyy/MM/dd HH:mm:ss");
					now.ToString("dddd");
					DateTime? dateTime = null;
					DateTime? dateTime2 = null;
					try
					{
						if (string.IsNullOrEmpty(model.fromDate))
						{
							ServiceResult<FundResultViewModel> result3 = new ServiceResult<FundResultViewModel>
							{
								Message = Messages.MobMsgErrorDateNotEntered,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
							cRMSpEntities?.Dispose();
							return result3;
						}
						model.fromDate = model.fromDate.Replace("/", "").Replace("-", "").Replace("\\", "")
							.Replace(" ", "")
							.Replace("_", "");
						dateTime = ((result != 1065) ? new DateTime?(DateTime.Parse(PersianDate.GetFormatetdDate(model.fromDate) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None)) : new DateTime?(DateTime.Parse(PersianDate.GetFormatetdDate(model.fromDate) + " 00:00:00")));
						if (string.IsNullOrEmpty(model.toDate))
						{
							ServiceResult<FundResultViewModel> result4 = new ServiceResult<FundResultViewModel>
							{
								Message = Messages.MobMsgErrorDateNotEntered,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
							cRMSpEntities?.Dispose();
							return result4;
						}
						model.toDate = model.toDate.Replace("/", "").Replace("-", "").Replace("\\", "")
							.Replace(" ", "")
							.Replace("_", "");
						dateTime2 = ((result != 1065) ? new DateTime?(DateTime.Parse(PersianDate.GetFormatetdDate(model.toDate) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None)) : new DateTime?(DateTime.Parse(PersianDate.GetFormatetdDate(model.toDate) + " 23:59:59")));
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						ServiceResult<FundResultViewModel> result5 = new ServiceResult<FundResultViewModel>
						{
							Message = Messages.MobMsgErrorDateFormatIncorrect,
							Data = null,
							Status = ServiceResultStatus.Error
						};
						cRMSpEntities?.Dispose();
						return result5;
					}
					fundResultViewModel.FundList = Enumerable.ToList<MobspSelectFund_Result>((IEnumerable<MobspSelectFund_Result>)cRMSpEntities.MobspSelectFund(model.CrmUserId, model.FundId, model.UserId, dateTime, dateTime2, model.FundGroupId, result, result2, model.PageNumber, model.PageSize));
					fundResultViewModel.FundFooter = Enumerable.FirstOrDefault<MobspReturnFundSumFooter_Result>((IEnumerable<MobspReturnFundSumFooter_Result>)cRMSpEntities.MobspReturnFundSumFooter(model.CrmUserId, model.FundGroupId, model.UserId, dateTime, dateTime2));
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					fundResultViewModel = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				fundResultViewModel = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e2)
		{
			message = Messages.MobMsgErrorDoneOperation;
			fundResultViewModel = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<FundResultViewModel>
		{
			Message = message,
			Data = fundResultViewModel,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectFilesDirectory_Result>> GetFundFileList(int fundId, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspSelectFilesDirectory_Result> data = null;
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
					List<MobspSelectFilesDirectory_Result> list = Enumerable.ToList<MobspSelectFilesDirectory_Result>((IEnumerable<MobspSelectFilesDirectory_Result>)cRMEntities.MobspSelectFilesDirectory("", "", "", "70", fundId.ToString(), isShowAllCmpFile: false, languageID: result, defaultLanguageID: result2, centerId: cId));
					if (list != null && Enumerable.Any<MobspSelectFilesDirectory_Result>((IEnumerable<MobspSelectFilesDirectory_Result>)list))
					{
						foreach (MobspSelectFilesDirectory_Result item in list)
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
								item.DocDay = DateTimeClass.ConvertNumToDayName(int.Parse(item.DocDay));
							}
						}
						data = list;
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
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
		return new ServiceResult<List<MobspSelectFilesDirectory_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<int?> InsertEditFund(FundInsertEditeViewModel model)
	{
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		int? data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		string appType = Mobile.Classes.Configuration.AppType;
		DateTime now = DateTime.Now;
		DateTime value = now;
		string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
		short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
		short value3 = short.Parse(Financial.Get().Id.ToString());
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMSpEntities = new CRMSpEntities();
					if (model.FundId <= 0 && !VersionBuyer.Fund && Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMSpEntities.MobspSelectFundCnt()).GetValueOrDefault() > 10)
					{
						ServiceResult<int?> result3 = new ServiceResult<int?>
						{
							Message = Messages.MobMsgSimpleVersionBuy,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
						cRMSpEntities?.Dispose();
						return result3;
					}
					List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
					if (!string.IsNullOrEmpty(model.FundDesc_Lang))
					{
						list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.FundDesc_Lang);
					}
					list.Add(new CommonMultiLanguageViewModel
					{
						Value = model.FundDesc,
						LanguageId = result
					});
					DateTime now2 = DateTime.Now;
					try
					{
						if (string.IsNullOrEmpty(model.FundDatePersian))
						{
							ServiceResult<int?> result4 = new ServiceResult<int?>
							{
								Message = Messages.MobMsgErrorDateNotEntered,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
							cRMSpEntities?.Dispose();
							return result4;
						}
						model.FundDatePersian = model.FundDatePersian.Replace("/", "").Replace("-", "").Replace("\\", "")
							.Replace(" ", "")
							.Replace("_", "");
						now2 = ((result != 1065) ? DateTime.Parse(PersianDate.GetFormatetdDate(model.FundDatePersian) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None) : DateTime.Parse(PersianDate.GetFormatetdDate(model.FundDatePersian) + " 00:00:00"));
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						ServiceResult<int?> result5 = new ServiceResult<int?>
						{
							Message = Messages.MobMsgErrorDateFormatIncorrect,
							Data = null,
							Status = ServiceResultStatus.Error
						};
						cRMSpEntities?.Dispose();
						return result5;
					}
					if (model.FundDatePersian != null)
					{
						model.FundDatePersian = model.FundDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
							.Replace(".", "")
							.Replace(",", "")
							.Replace("\\", "");
					}
					decimal num = default(decimal);
					decimal result6 = default(decimal);
					decimal result7 = default(decimal);
					decimal.TryParse(model.FundCredit.ToString(), out result6);
					decimal.TryParse(model.FundDebit.ToString(), out result7);
					decimal num2 = result7 - result6;
					decimal result8 = default(decimal);
					MobspSelectPriorFund_Result mobspSelectPriorFund_Result = Enumerable.FirstOrDefault<MobspSelectPriorFund_Result>((IEnumerable<MobspSelectPriorFund_Result>)cRMSpEntities.MobspSelectPriorFund(model.CrmUserId, model.FundId));
					if (mobspSelectPriorFund_Result != null)
					{
						decimal.TryParse(mobspSelectPriorFund_Result.FundRemain.ToString(), out result8);
					}
					num = result8 + num2;
					model.FundRemain = num;
					if (model.FundId > 0)
					{
						int? num3 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMSpEntities.MobspUpdateFundWithId(model.FundId, model.FundGroupId, model.CrmUserId, now2, model.FundDatePersian, model.FundNumber, model.FundCredit, model.FundDebit, model.FundRemain, model.FundDesc, model.FundDesc_Lang, model.FundOrderView, result2, appType));
						if (num3.GetValueOrDefault() == 1)
						{
							cRMSpEntities.MobspReUpdateFundRemain(model.CrmUserId);
							message = Messages.frmFormBaseEditSuccessFulMessage;
							data = num3;
							status = ServiceResultStatus.Success;
						}
						else
						{
							message = Messages.msgErrorEditInfo;
							data = null;
							status = ServiceResultStatus.Fail;
						}
					}
					else
					{
						ObjectParameter objectParameter = new ObjectParameter("insertedFundId", 0);
						Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMSpEntities.MobSpInsertFund(model.FundGroupId, model.CrmUserId, now2, model.FundDatePersian, model.FundCredit, model.FundDebit, model.FundRemain, model.FundDesc, model.FundDesc_Lang, model.FundOrderView, appType, token2.userId, value3, value2, value, registerDatePersian, result2, objectParameter));
						int result9 = 0;
						if (objectParameter.Value != null)
						{
							int.TryParse(objectParameter.Value.ToString(), out result9);
						}
						if (result9 > 0)
						{
							cRMSpEntities.MobspReUpdateFundRemain(model.CrmUserId);
							message = Messages.frmFormBaseEditSuccessFulMessage;
							data = result9;
							status = ServiceResultStatus.Success;
						}
						else
						{
							message = Messages.msgErrorRunFunction;
							data = null;
							status = ServiceResultStatus.Error;
						}
					}
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
		catch (Exception e2)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<int?>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<int?> DeleteFund(int fundId, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		int? data = null;
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
					cRMSpEntities = new CRMSpEntities();
					if (!UserLogin.IsUserAccess("frmFund", "actDelete", UserLogin.CurrentUser, cId))
					{
						return new ServiceResult<int?>
						{
							Message = Messages.ErrorNotAccess,
							Data = null,
							Status = ServiceResultStatus.Error
						};
					}
					int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMSpEntities.MobspDeleteFund(fundId));
					if (num.HasValue)
					{
						data = num;
						status = ServiceResultStatus.Success;
						message = "";
					}
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<int?>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<bool> DeleteAllFile(int fundId, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		bool data = false;
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
					List<MobspSelectFilesDirectory_Result> list = Enumerable.ToList<MobspSelectFilesDirectory_Result>((IEnumerable<MobspSelectFilesDirectory_Result>)cRMEntities.MobspSelectFilesDirectory("", "", "", "70", fundId.ToString(), isShowAllCmpFile: false, languageID: result, defaultLanguageID: result2, centerId: cId));
					if (Enumerable.Any<MobspSelectFilesDirectory_Result>((IEnumerable<MobspSelectFilesDirectory_Result>)list))
					{
						foreach (MobspSelectFilesDirectory_Result item in list)
						{
							MobspSelectCrmFilesDirectory_Result mobspSelectCrmFilesDirectory_Result = Enumerable.FirstOrDefault<MobspSelectCrmFilesDirectory_Result>((IEnumerable<MobspSelectCrmFilesDirectory_Result>)cRMEntities.MobspSelectCrmFilesDirectory(item.FileDirectoryID));
							string text = mobspSelectCrmFilesDirectory_Result.FilePath.ToLower().Replace(Mobile.Classes.Configuration.PathFtp.ToLower(), "");
							text = ((!text.Contains("/" + Mobile.Classes.Configuration.IntmsgDirectoryPath.ToLower().Replace("/", "") + "/") && !text.Contains("\\" + Mobile.Classes.Configuration.IntmsgDirectoryPath.ToLower().Replace("/", "") + "\\")) ? ((!text.Contains("/" + Mobile.Classes.Configuration.KnlgTDirectoryPath.ToLower().Replace("/", "") + "/") && !text.Contains("\\" + Mobile.Classes.Configuration.KnlgTDirectoryPath.ToLower().Replace("/", "") + "\\")) ? ((!text.Contains("/" + Mobile.Classes.Configuration.DyDirectoryPath.ToLower().Replace("/", "") + "/") && !text.Contains("\\" + Mobile.Classes.Configuration.DyDirectoryPath.ToLower().Replace("/", "") + "\\")) ? (Mobile.Classes.Configuration.MainDirectoryPath + mobspSelectCrmFilesDirectory_Result.FolderName + "/" + mobspSelectCrmFilesDirectory_Result.FileName) : (Mobile.Classes.Configuration.MainDirectoryPath + Mobile.Classes.Configuration.DyDirectoryPath + mobspSelectCrmFilesDirectory_Result.FolderName + "/" + mobspSelectCrmFilesDirectory_Result.FileName)) : (Mobile.Classes.Configuration.MainDirectoryPath + Mobile.Classes.Configuration.KnlgTDirectoryPath + mobspSelectCrmFilesDirectory_Result.FolderName + "/" + mobspSelectCrmFilesDirectory_Result.FileName)) : (Mobile.Classes.Configuration.MainDirectoryPath + Mobile.Classes.Configuration.IntmsgDirectoryPath + mobspSelectCrmFilesDirectory_Result.FolderName + "/" + mobspSelectCrmFilesDirectory_Result.FileName));
							FacadeFTP facadeFTP = new FacadeFTP(Mobile.Classes.Configuration.FacadeFtp);
							string destination = text;
							if (facadeFTP.Delete(Mobile.Classes.Configuration.PathFtp, Mobile.Classes.Configuration.UserNameFtp, Mobile.Classes.Configuration.PasswordFtp, mobspSelectCrmFilesDirectory_Result.FileName, destination, Mobile.Classes.Configuration.UsePassiveFtp))
							{
								int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.MobspDeleteCrmFilesDirectory(item.FileDirectoryID));
								int result3 = 0;
								int.TryParse(num.ToString(), out result3);
								if (result3 == 1)
								{
									data = true;
									message = Messages.MobMsgSuccessAction;
									status = ServiceResultStatus.Success;
								}
								else
								{
									data = false;
									message = Messages.MobMsgErrorDoneOperation;
									status = ServiceResultStatus.Fail;
								}
							}
							else
							{
								data = false;
								message = Messages.MobMsgErrorInDeleteFileFromFtp;
								status = ServiceResultStatus.Fail;
							}
						}
					}
					list = Enumerable.ToList<MobspSelectFilesDirectory_Result>((IEnumerable<MobspSelectFilesDirectory_Result>)cRMEntities.MobspSelectFilesDirectory("", "", "", "70", fundId.ToString(), isShowAllCmpFile: false, languageID: result, defaultLanguageID: result2, centerId: cId));
					if (!Enumerable.Any<MobspSelectFilesDirectory_Result>((IEnumerable<MobspSelectFilesDirectory_Result>)list))
					{
						message = Messages.frmDeleteSuccessMessage;
						status = ServiceResultStatus.Success;
						data = true;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = false;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = false;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = false;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<bool>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}
}
