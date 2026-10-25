using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Web.Http;
using System.Web.Script.Serialization;
using CRM.General.Calendar;
using CRM.Resources;
using Elmah;
using GSD.Globalization;
using Mobile.Cache.Setting;
using Mobile.Classes;
using Mobile.Classes.Helper;
using Mobile.DataType;
using Mobile.Models;
using Mobile.Models.ViewModel.VerificationWorkFlow;
using Newtonsoft.Json;

namespace Mobile.Controllers;

public class WareHouseController : ApiController
{
	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectOrdersByCmpIdAndDocOprId_Result>> SelectOrdersByCmpIdAndDocOprId(int cmpId, int oprId, int docId, string val, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<MobspSelectOrdersByCmpIdAndDocOprId_Result> data = null;
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
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMSpEntities = new CRMSpEntities();
					data = Enumerable.ToList<MobspSelectOrdersByCmpIdAndDocOprId_Result>((IEnumerable<MobspSelectOrdersByCmpIdAndDocOprId_Result>)cRMSpEntities.MobspSelectOrdersByCmpIdAndDocOprId(cmpId, oprId, currDocId: docId, userId: token2.userId, val: val, languageID: result, defaultLanguageID: result2, centerId: cId));
					message = Messages.MobMsgSuccessAction;
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<List<MobspSelectOrdersByCmpIdAndDocOprId_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<MobspReturnOrdItemQuantityByDocItemId_Result> GetOrdItemQuantityByDocItemId(int docId, int docItemId, int prdId, int ordId, int bordId, int pordId, int whId, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		MobspReturnOrdItemQuantityByDocItemId_Result data = null;
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
					data = Enumerable.FirstOrDefault<MobspReturnOrdItemQuantityByDocItemId_Result>((IEnumerable<MobspReturnOrdItemQuantityByDocItemId_Result>)cRMSpEntities.MobspReturnOrdItemQuantityByDocItemId(docId, docItemId, prdId, ordId, bordId, preOrderId: pordId, wHId: whId));
					message = Messages.MobMsgSuccessAction;
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<MobspReturnOrdItemQuantityByDocItemId_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> CheckDuplicateDocItemTracing(int docItemId, int prdId, string tracing, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		string data = null;
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
					if (string.IsNullOrEmpty(tracing))
					{
						return new ServiceResult<string>
						{
							Data = null,
							Message = Messages.MobMsgSuccessAction,
							Status = ServiceResultStatus.Success
						};
					}
					bool flag = false;
					MobspSelectCrmsysSetting_Result mobspSelectCrmsysSetting_Result = SysSeting.Get();
					if (mobspSelectCrmsysSetting_Result != null)
					{
						flag = ((mobspSelectCrmsysSetting_Result.CanUseDupTracing.HasValue && mobspSelectCrmsysSetting_Result.CanUseDupTracing != false) ? true : false);
					}
					if (!flag)
					{
						MobspCheckDuplicateDocItemTracing_Result mobspCheckDuplicateDocItemTracing_Result = Enumerable.FirstOrDefault<MobspCheckDuplicateDocItemTracing_Result>((IEnumerable<MobspCheckDuplicateDocItemTracing_Result>)cRMSpEntities.MobspCheckDuplicateDocItemTracing(prdId, docItemId, tracing, result, result2));
						if (mobspCheckDuplicateDocItemTracing_Result != null)
						{
							data = string.Format(Messages.msgErrorDocItemTracingDuplicate, mobspCheckDuplicateDocItemTracing_Result.docNumber);
						}
					}
					message = Messages.MobMsgSuccessAction;
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSearchTracingInDoc_Result>> SearchTracingInDoc(int prdId, string tracing, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<MobspSearchTracingInDoc_Result> data = null;
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
					data = Enumerable.ToList<MobspSearchTracingInDoc_Result>((IEnumerable<MobspSearchTracingInDoc_Result>)cRMSpEntities.MobspSearchTracingInDoc(tracing, prdId));
					message = Messages.MobMsgSuccessAction;
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<List<MobspSearchTracingInDoc_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<MobspReturnPrdQuantity_Result> GetPrdQuantity(int prdId, int currItemId, int whId, double? fcr = null, double? fcrI = null, string tracing = null, int? cId = null, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		MobspReturnPrdQuantity_Result data = null;
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
					ObjectParameter quantityRemain = new ObjectParameter("quantityRemain", 0);
					int id = Financial.Get().Id;
					CRMSpEntities cRMSpEntities2 = cRMSpEntities;
					int? prdId2 = prdId;
					int? currId = currItemId;
					data = Enumerable.FirstOrDefault<MobspReturnPrdQuantity_Result>((IEnumerable<MobspReturnPrdQuantity_Result>)cRMSpEntities2.MobspReturnPrdQuantity(prdId2, id, whId, currId, result, result2, fcr, fcrI, tracing, quantityRemain, cId));
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<MobspReturnPrdQuantity_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspReturnPrdQuantityByIds_Result>> GetPrdQuantityByIds(string prdIds, int currItemId, int whId, double? fcr = null, double? fcrI = null, string tracing = null, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<MobspReturnPrdQuantityByIds_Result> data = null;
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
					new ObjectParameter("quantityRemain", 0);
					int id = Financial.Get().Id;
					CRMSpEntities cRMSpEntities2 = cRMSpEntities;
					int? currId = currItemId;
					data = Enumerable.ToList<MobspReturnPrdQuantityByIds_Result>((IEnumerable<MobspReturnPrdQuantityByIds_Result>)cRMSpEntities2.MobspReturnPrdQuantityByIds(prdIds, id, whId, currId, result, result2, fcr, fcrI, tracing, cId));
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<List<MobspReturnPrdQuantityByIds_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<int> GetMobDocCnt(int? cId = null)
	{
		int num = 1065;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		CRMSpEntities cRMSpEntities = null;
		int data = 0;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((num > 0) ? num : result);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMSpEntities = new CRMSpEntities();
					data = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMSpEntities.MobspReturnMobDocCnt(cId)).GetValueOrDefault();
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = 0;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = 0;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = 0;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<int>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<MobspCheckDuplicatePrdSerial_Result> CheckDuplicateSerial(int oprId, int whId, int prdId, string serial, int? currId, int? docItemSerialID, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		MobspCheckDuplicatePrdSerial_Result data = null;
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
					int id = Financial.Get().Id;
					CRMSpEntities cRMSpEntities2 = cRMSpEntities;
					int? oprId2 = oprId;
					int? fPId = id;
					int? wHID = whId;
					int? prdId2 = prdId;
					int? docItemSerialID2 = docItemSerialID;
					data = Enumerable.FirstOrDefault<MobspCheckDuplicatePrdSerial_Result>((IEnumerable<MobspCheckDuplicatePrdSerial_Result>)cRMSpEntities2.MobspCheckDuplicatePrdSerial(oprId2, fPId, wHID, prdId2, serial, currId, result, result2, docItemSerialID2));
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<MobspCheckDuplicatePrdSerial_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> GenerateDocItemSerial(GenerateDocItemSerialViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		string data = null;
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
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					cRMSpEntities = new CRMSpEntities();
					DateTime now = DateTime.Now;
					int id = Financial.Get().Id;
					short value = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					string appType = Mobile.Classes.Configuration.AppType;
					DateTime dateTime = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					int userId = token2.userId;
					List<MobspSelectLanguages_Result> list = Enumerable.ToList<MobspSelectLanguages_Result>((IEnumerable<MobspSelectLanguages_Result>)cRMEntities.MobspSelectLanguages());
					DateTime dateTime2 = default(DateTime);
					string text = "";
					if (!string.IsNullOrEmpty(model.ExpDatePersian))
					{
						try
						{
							text = PersianDate.GetFormatetdDate(model.ExpDatePersian.Replace("/", ""));
							if (num == 1065)
							{
								dateTime2 = DateTime.Parse(text + " 00:00:00", new PersianCulture());
								model.ExpDatePersian = dateTime2.ToString("yyyyMMdd");
							}
							else
							{
								dateTime2 = DateTime.Parse(PersianDate.GetShamsi2Miladi(text.Replace("/", "")));
								model.ExpDatePersian = dateTime2.ToString("yyyyMMdd", new PersianCulture());
							}
							model.ExpDate = dateTime2;
						}
						catch (Exception e)
						{
							ErrorSignal.FromCurrentContext().Raise(e);
							new ServiceResult<string>
							{
								Message = Messages.MobMsgErrorDateFormatIncorrect,
								Data = null,
								Status = ServiceResultStatus.Error
							};
							cRMEntities?.Dispose();
						}
					}
					List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
					foreach (MobspSelectLanguages_Result item in list)
					{
						list2.Add(new CommonMultiLanguageViewModel
						{
							Value = model.Description,
							LanguageId = item.LanguageID
						});
					}
					model.Description_Lang = Enumerable.Aggregate<CommonMultiLanguageViewModel, string>((IEnumerable<CommonMultiLanguageViewModel>)list2, model.Description_Lang, (Func<string, CommonMultiLanguageViewModel, string>)((string current, CommonMultiLanguageViewModel item) => current + "@LangID=" + item.LanguageId + ",%," + item.Value + "|"));
					if (cRMSpEntities.MobspGenerateDocItemSerial(model.Count, model.ItemId, model.PreFixSerial, model.Serial, model.IncSerial, model.Description, model.WHId, userId, value, id, dateTime.ToString(), registerDatePersian, model.ExpDate, model.ExpDatePersian, appType, model.PreFixInfoI, model.InfoI, model.IncInfoI, model.PreFixInfoII, model.InfoII, model.IncInfoII, model.PreFixInfoIII, model.InfoIII, model.IncInfoIII, model.PreFixInfoIV, model.InfoIV, model.IncInfoIV, model.PreFixInfoV, model.InfoV, model.IncInfoV, model.PreFixInfoVI, model.InfoVI, model.IncInfoVI, result2, model.Description_Lang) > 0)
					{
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					else
					{
						message = Messages.msgNotCompeleteSuccessAction + "<br>" + Messages.msgErrorDupSerialInGenerateSerialInDoc;
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
			cRMEntities?.Dispose();
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspGenerateDocItemSerialAndSelect_Result>> GenerateDocItemSerialAndSelect(GenerateDocItemSerialAndSelectViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<MobspGenerateDocItemSerialAndSelect_Result> data = null;
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
					data = Enumerable.ToList<MobspGenerateDocItemSerialAndSelect_Result>((IEnumerable<MobspGenerateDocItemSerialAndSelect_Result>)cRMSpEntities.MobspGenerateDocItemSerialAndSelect(model.Count, model.PreFixSerial, model.Serial, model.IncSerial, model.WHId, model.PreFixInfoI, model.InfoI, model.IncInfoI, model.PreFixInfoII, model.InfoII, model.IncInfoII, model.PreFixInfoIII, model.InfoIII, model.IncInfoIII, model.PreFixInfoIV, model.InfoIV, model.IncInfoIV, model.PreFixInfoV, model.InfoV, model.IncInfoV, model.PreFixInfoVI, model.InfoVI, model.IncInfoVI, model.PrdId, model.OprId, model.ItemCount, model.PrdQuantity));
					message = Messages.MobMsgSuccessAction;
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<List<MobspGenerateDocItemSerialAndSelect_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<InsertDocFullResultViewModel> InsertDocFull(InsertDocFullViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		InsertDocFullResultViewModel insertDocFullResultViewModel = new InsertDocFullResultViewModel();
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
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMSpEntities = new CRMSpEntities();
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					int id = Financial.Get().Id;
					short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					string appType = Mobile.Classes.Configuration.AppType;
					int userId = token2.userId;
					ObjectParameter objectParameter = new ObjectParameter("ResErrorMessage", "");
					ObjectParameter objectParameter2 = new ObjectParameter("ResInsertedDocId", 0);
					ObjectParameter objectParameter3 = new ObjectParameter("ResInsertedDocItemIds", "");
					ObjectParameter objectParameter4 = new ObjectParameter("ResInsertedDocItemSerialIds", "");
					Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMSpEntities.MobspInsertDocFull(model.DocParams, model.DocItemParams, model.DocItemSerialParams, userId, month1: value2, fPId: id, registerDate: value, registerDatePersian: registerDatePersian, appType: appType, languageID: num, defaultLanguageID: result2, resErrorMessage: objectParameter, resInsertedDocId: objectParameter2, resInsertedDocItemIds: objectParameter3, resInsertedDocItemSerialIds: objectParameter4, centerId: model.CenterId));
					if (!string.IsNullOrEmpty(objectParameter.Value?.ToString()))
					{
						string text = "";
						string[] array = objectParameter.Value.ToString().Split(new string[1] { "#|^|#" }, StringSplitOptions.None);
						string[] array2 = array;
						foreach (string text2 in array2)
						{
							if (string.IsNullOrEmpty(text2))
							{
								continue;
							}
							string[] array3 = text2.Split(new string[1] { "|^|" }, StringSplitOptions.None);
							switch (array3[0])
							{
							case "ParseData=Error":
								text = Messages.MobMsgErrorInSentData;
								break;
							case "DocNumber=Dup":
								text = Messages.MobMsgDraftNumberIsRepeated;
								break;
							case "DocNumRef=Dup":
							{
								string arg3 = "";
								if (array3.Length > 1)
								{
									arg3 = array3[1].Replace("DupDocNumber=", "") ?? "";
								}
								text = string.Format(Messages.MobMsgDocNumRefIsRepeated, arg3);
								break;
							}
							case "Tracing=Force":
							{
								text = Messages.MobMsgErrorTracingIsNotSpecified;
								string text4 = "";
								if (array3.Length > 1)
								{
									string s = array3[1].Replace("PrdId=", "") ?? "";
									int result3 = 0;
									int.TryParse(s, out result3);
									if (result3 > 0)
									{
										MobspSelectProductsWithId_Result mobspSelectProductsWithId_Result = Enumerable.FirstOrDefault<MobspSelectProductsWithId_Result>((IEnumerable<MobspSelectProductsWithId_Result>)cRMSpEntities.MobspSelectProductsWithId(result3, result, result2));
										if (mobspSelectProductsWithId_Result != null)
										{
											text4 = mobspSelectProductsWithId_Result.PrdName ?? "";
										}
									}
								}
								if (!string.IsNullOrEmpty(text4))
								{
									text = text + Labels.lblProduct + ": " + text4;
								}
								break;
							}
							case "Tracing=New":
							{
								string arg2 = "";
								if (array3.Length > 1)
								{
									arg2 = array3[1].Replace("NewTracing=", "") ?? "";
								}
								text = string.Format(Messages.MobMsgErrorCanNotAddNewTracingCode, arg2);
								string text6 = "";
								if (array3.Length > 2)
								{
									string s3 = array3[2].Replace("PrdId=", "") ?? "";
									int result5 = 0;
									int.TryParse(s3, out result5);
									if (result5 > 0)
									{
										MobspSelectProductsWithId_Result mobspSelectProductsWithId_Result3 = Enumerable.FirstOrDefault<MobspSelectProductsWithId_Result>((IEnumerable<MobspSelectProductsWithId_Result>)cRMSpEntities.MobspSelectProductsWithId(result5, result, result2));
										if (mobspSelectProductsWithId_Result3 != null)
										{
											text6 = mobspSelectProductsWithId_Result3.PrdName ?? "";
										}
									}
								}
								if (!string.IsNullOrEmpty(text6))
								{
									text = text + Labels.lblProduct + ": " + text6;
								}
								break;
							}
							case "QtyRemainLimit":
							{
								string text5 = "";
								if (array3.Length > 1)
								{
									string s2 = array3[1].Replace("PrdId=", "") ?? "";
									int result4 = 0;
									int.TryParse(s2, out result4);
									if (result4 > 0)
									{
										MobspSelectProductsWithId_Result mobspSelectProductsWithId_Result2 = Enumerable.FirstOrDefault<MobspSelectProductsWithId_Result>((IEnumerable<MobspSelectProductsWithId_Result>)cRMSpEntities.MobspSelectProductsWithId(result4, result, result2));
										if (mobspSelectProductsWithId_Result2 != null)
										{
											text5 = mobspSelectProductsWithId_Result2.PrdName ?? "";
										}
									}
								}
								if (string.IsNullOrEmpty(text5))
								{
									text5 = Labels.lblSelected;
								}
								text = string.Format(Messages.MobMsgDraftQuantityRemainLimitExceededI, text5);
								break;
							}
							case "Serial=Dup":
							{
								string arg = "";
								if (array3.Length > 1)
								{
									arg = array3[1].Replace("DocNumber=", "") ?? "";
								}
								text = string.Format(Messages.msgSerialNumberDuplicateInDraft, arg);
								string text3 = "";
								if (array3.Length > 2)
								{
									text3 = array3[2].Replace("Serial=", "") ?? "";
								}
								if (!string.IsNullOrEmpty(text3))
								{
									text = text + Labels.lblSerialNumber + ": " + text3;
								}
								break;
							}
							case "Error":
								text = Messages.MobMsgErrorSubmitDraft;
								break;
							}
						}
						if (string.IsNullOrEmpty(text))
						{
							text = array[0];
						}
						message = text;
						status = ServiceResultStatus.Fail;
					}
					else
					{
						insertDocFullResultViewModel.InsertDocId = objectParameter2.Value.ToString() ?? "0";
						insertDocFullResultViewModel.InsertedDocItemIds = objectParameter3.Value.ToString() ?? "0";
						insertDocFullResultViewModel.InsertedDocItemSerialIds = objectParameter4.ToString() ?? "0";
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					insertDocFullResultViewModel = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				insertDocFullResultViewModel = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			insertDocFullResultViewModel = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<InsertDocFullResultViewModel>
		{
			Message = message,
			Data = insertDocFullResultViewModel,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> DocVerify(int docId, int? cId = null, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		string data = null;
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
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMSpEntities = new CRMSpEntities();
					if (docId <= 0)
					{
						return new ServiceResult<string>
						{
							Message = Messages.MobMsgErorrDocNotFound,
							Data = null,
							Status = ServiceResultStatus.Error
						};
					}
					MobspSelectDocById_Result mobspSelectDocById_Result = Enumerable.FirstOrDefault<MobspSelectDocById_Result>((IEnumerable<MobspSelectDocById_Result>)cRMSpEntities.MobspSelectDocById(docId, num, result2));
					if (mobspSelectDocById_Result != null)
					{
						int result3 = 0;
						int.TryParse(mobspSelectDocById_Result.OprType.ToString(), out result3);
						bool flag = false;
						switch (result3)
						{
						case 1:
							flag = UserLogin.IsUserAccess("frmDoc", "actVerifyDoc", UserLogin.CurrentUser, cId);
							break;
						case 2:
							flag = UserLogin.IsUserAccess("frmDraft", "actVerifyDraft", UserLogin.CurrentUser, cId);
							break;
						case 3:
							flag = UserLogin.IsUserAccess("frmWareHouseMovement", "actVerifyDoc", UserLogin.CurrentUser, cId);
							break;
						}
						if (!flag)
						{
							return new ServiceResult<string>
							{
								Message = Messages.MobMsgErrorAccessLimited,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
						}
						DateTime now = DateTime.Now;
						DateTime value = now;
						string verifiedRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						int userId = token2.userId;
						cRMSpEntities.MobspDocVerify(docId, userId, value, verifiedRegisterDatePersian);
						bool flag2 = false;
						switch (result3)
						{
						case 1:
							flag2 = UserLogin.IsUserAccess("frmDoc", "actAutoReferDocToOrdReferUserAfterVerify", UserLogin.CurrentUser, cId);
							break;
						case 2:
							flag2 = UserLogin.IsUserAccess("frmDraft", "actAutoReferDocToOrdReferUserAfterVerify", UserLogin.CurrentUser, cId);
							break;
						}
						if (flag2)
						{
							Doc.ReferDocToOrdReferUser(docId.ToString(), cId);
						}
						message = Messages.MobMsgSuccessAction;
						data = null;
						status = ServiceResultStatus.Success;
					}
					else
					{
						message = Messages.MobMsgErorrDocNotFound;
						data = null;
						status = ServiceResultStatus.Fail;
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
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> DocVerifyExit(int docId, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		string data = null;
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
				if (new Common().GetToken(token) != null)
				{
					cRMSpEntities = new CRMSpEntities();
					if (docId <= 0)
					{
						return new ServiceResult<string>
						{
							Message = Messages.MobMsgErorrDocNotFound,
							Data = null,
							Status = ServiceResultStatus.Error
						};
					}
					MobspSelectDocById_Result mobspSelectDocById_Result = Enumerable.FirstOrDefault<MobspSelectDocById_Result>((IEnumerable<MobspSelectDocById_Result>)cRMSpEntities.MobspSelectDocById(docId, num, result2));
					if (mobspSelectDocById_Result != null)
					{
						int result3 = 0;
						int.TryParse(mobspSelectDocById_Result.OprType.ToString(), out result3);
						bool flag = false;
						switch (result3)
						{
						case 1:
							flag = UserLogin.IsUserAccess("frmDoc", "actExitFromIsFix", UserLogin.CurrentUser, cId);
							break;
						case 2:
							flag = UserLogin.IsUserAccess("frmDraft", "actExitFromIsFix", UserLogin.CurrentUser, cId);
							break;
						case 3:
							flag = UserLogin.IsUserAccess("frmWareHouseMovement", "actExitFromIsFix", UserLogin.CurrentUser, cId);
							break;
						}
						if (!flag)
						{
							return new ServiceResult<string>
							{
								Message = Messages.MobMsgErrorAccessLimited,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
						}
						cRMSpEntities.MobspDocVerifyExit(docId);
						data = null;
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					else
					{
						message = Messages.MobMsgErorrDocNotFound;
						data = null;
						status = ServiceResultStatus.Fail;
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
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<DocListAndIntMsgViewModel> GetDocList(DateTime? fDateTime, DateTime? tDateTime, int? pageNumber = 1, int? pageSize = 10, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		DocListAndIntMsgViewModel docListAndIntMsgViewModel = null;
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
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					if (base.Request.Headers.TryGetValues("imeiCode", out var _) && !Common.CheckUserImeiCode(token2.userId, Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("imeiCode")), Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("appName"))))
					{
						return new ServiceResult<DocListAndIntMsgViewModel>
						{
							Message = Messages.MobMsgUserImeiNotPreDefined,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					docListAndIntMsgViewModel = new DocListAndIntMsgViewModel();
					docListAndIntMsgViewModel.Docs = new List<MobspSelectDocs_Result>();
					docListAndIntMsgViewModel.InternalMessages = new List<MobspIntMsgGetByTypeAndAttachRecId_Result>();
					string manualIssuing = Labels.ManualIssuing;
					string systemIssuing = Labels.SystemIssuing;
					cRMEntities = new CRMEntities();
					cRMSpEntities = new CRMSpEntities();
					DocListAndIntMsgViewModel docListAndIntMsgViewModel2 = docListAndIntMsgViewModel;
					CRMSpEntities cRMSpEntities2 = cRMSpEntities;
					int? userId = token2.userId;
					int? oprType = 1;
					int? docId = 0;
					string manualIssuing2 = manualIssuing;
					string systemIssuing2 = systemIssuing;
					int? pageNumber2 = pageNumber;
					docListAndIntMsgViewModel2.Docs = Enumerable.ToList<MobspSelectDocs_Result>((IEnumerable<MobspSelectDocs_Result>)cRMSpEntities2.MobspSelectDocs(userId, oprType, docId, result, result2, fDateTime, tDateTime, manualIssuing2, systemIssuing2, pageNumber2, pageSize, cId));
					if (!VersionBuyer.WareHouse)
					{
						docListAndIntMsgViewModel.Docs = Enumerable.ToList<MobspSelectDocs_Result>(Enumerable.Take<MobspSelectDocs_Result>((IEnumerable<MobspSelectDocs_Result>)docListAndIntMsgViewModel.Docs, 2));
					}
					foreach (MobspSelectDocs_Result doc in docListAndIntMsgViewModel.Docs)
					{
						List<MobspIntMsgGetByTypeAndAttachRecId_Result> list = Enumerable.ToList<MobspIntMsgGetByTypeAndAttachRecId_Result>((IEnumerable<MobspIntMsgGetByTypeAndAttachRecId_Result>)cRMEntities.MobspIntMsgGetByTypeAndAttachRecId(token2.userId, 20, doc.DocID, result, result2));
						if (Enumerable.Any<MobspIntMsgGetByTypeAndAttachRecId_Result>((IEnumerable<MobspIntMsgGetByTypeAndAttachRecId_Result>)list))
						{
							docListAndIntMsgViewModel.InternalMessages.AddRange(list);
						}
					}
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					docListAndIntMsgViewModel = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				docListAndIntMsgViewModel = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			docListAndIntMsgViewModel = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
			cRMEntities?.Dispose();
		}
		return new ServiceResult<DocListAndIntMsgViewModel>
		{
			Message = message,
			Data = docListAndIntMsgViewModel,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<DocDetailsViewModel> GetDocDetails(int docId, int? cId = null, int? ln = null)
	{
		//IL_03a3: Unknown result type (might be due to invalid IL or missing references)
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		DocDetailsViewModel docDetailsViewModel = null;
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
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					if (!UserLogin.IsUserAccess("frmMain", "actwhDoc", UserLogin.CurrentUser, cId))
					{
						return new ServiceResult<DocDetailsViewModel>
						{
							Message = Messages.MobMsgErrorAccessLimited,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					int id = Financial.Get().Id;
					string manualIssuing = Labels.ManualIssuing;
					string systemIssuing = Labels.SystemIssuing;
					cRMEntities = new CRMEntities();
					cRMSpEntities = new CRMSpEntities();
					CRMSpEntities cRMSpEntities2 = cRMSpEntities;
					int? userId = token2.userId;
					int? oprType = 1;
					int? docId2 = docId;
					DateTime? fDateTime = null;
					DateTime? tDateTime = null;
					string manualIssuing2 = manualIssuing;
					string systemIssuing2 = systemIssuing;
					MobspSelectDocs_Result mobspSelectDocs_Result = Enumerable.FirstOrDefault<MobspSelectDocs_Result>((IEnumerable<MobspSelectDocs_Result>)cRMSpEntities2.MobspSelectDocs(userId, oprType, docId2, result, result2, fDateTime, tDateTime, manualIssuing2, systemIssuing2, null, null, cId));
					if (mobspSelectDocs_Result != null)
					{
						docDetailsViewModel = new DocDetailsViewModel();
						docDetailsViewModel.DocItems = new List<MobspSelectDocItems_Result>();
						docDetailsViewModel.DocItemSerials = new List<MobspSelectDocItemSerials_Result>();
						docDetailsViewModel.InternalMsg = new List<MobspIntMsgGetByTypeAndAttachRecId_Result>();
						docDetailsViewModel.ItemsPrdQuantity = new List<DocItemPrdQuantityViewModel>();
						if (Doc.IsEditAfterFix(mobspSelectDocs_Result.EditAfterFixInfoJs, mobspSelectDocs_Result.DocID, 1, token2.userId))
						{
							mobspSelectDocs_Result.IsFix = 0;
						}
						if (!string.IsNullOrWhiteSpace((mobspSelectDocs_Result.EditAfterFixInfoJs ?? "").Replace("[]", "")))
						{
							List<EditAfterFixInfoViewModel> list = JsonConvert.DeserializeObject<List<EditAfterFixInfoViewModel>>(mobspSelectDocs_Result.EditAfterFixInfoJs);
							if (list != null)
							{
								foreach (EditAfterFixInfoViewModel item in list)
								{
									MobspSelectUsersById_Result mobspSelectUsersById_Result = Enumerable.FirstOrDefault<MobspSelectUsersById_Result>((IEnumerable<MobspSelectUsersById_Result>)cRMEntities.MobspSelectUsersById(item.eafUserId, result, result2, cId));
									if (mobspSelectUsersById_Result != null)
									{
										item.eafUserName = mobspSelectUsersById_Result.FullName;
									}
									item.eafRequestDatePersian = item.eafRequestDate.ToString("yyyy/MM/dd HH:mm");
									item.eafEndDatePersian = item.eafEndDate?.ToString("yyyy/MM/dd HH:mm");
									item.eafDoneDatePersian = item.eafDoneDate?.ToString("yyyy/MM/dd HH:mm");
								}
								mobspSelectDocs_Result.EditAfterFixInfoJs = JsonConvert.SerializeObject(list);
							}
						}
						mobspSelectDocs_Result.IsSentToLinkAcc = false;
						MobspSelectCrmsysSetting_Result mobspSelectCrmsysSetting_Result = SysSeting.Get();
						int num2 = 0;
						if (mobspSelectCrmsysSetting_Result != null)
						{
							num2 = mobspSelectCrmsysSetting_Result.LinkAccSystemId.GetValueOrDefault();
						}
						mobspSelectDocs_Result.DocLinkAccData = mobspSelectDocs_Result.DocLinkAccData ?? "";
						if (num2 == 1)
						{
							List<MobspSelectLinkAccSettingDBIsActive_Result> list2 = Enumerable.ToList<MobspSelectLinkAccSettingDBIsActive_Result>((IEnumerable<MobspSelectLinkAccSettingDBIsActive_Result>)cRMSpEntities.MobspSelectLinkAccSettingDBIsActive(num2));
							List<DocLinkAccDataViewModel> list3 = new List<DocLinkAccDataViewModel>();
							if (!string.IsNullOrWhiteSpace(mobspSelectDocs_Result.DocLinkAccData))
							{
								foreach (DocLinkAccDataViewModel item2 in new JavaScriptSerializer().Deserialize<List<DocLinkAccDataViewModel>>(mobspSelectDocs_Result.DocLinkAccData))
								{
									int dbId = 0;
									int.TryParse(item2.DBId.ToString(), out dbId);
									if (dbId != 0 && list2 != null && Enumerable.Any<MobspSelectLinkAccSettingDBIsActive_Result>((IEnumerable<MobspSelectLinkAccSettingDBIsActive_Result>)list2))
									{
										MobspSelectLinkAccSettingDBIsActive_Result mobspSelectLinkAccSettingDBIsActive_Result = Enumerable.FirstOrDefault<MobspSelectLinkAccSettingDBIsActive_Result>((IEnumerable<MobspSelectLinkAccSettingDBIsActive_Result>)list2, (Func<MobspSelectLinkAccSettingDBIsActive_Result, bool>)((MobspSelectLinkAccSettingDBIsActive_Result m) => m.LinkAccSettingDBId == dbId));
										if (mobspSelectLinkAccSettingDBIsActive_Result != null)
										{
											item2.DbName = mobspSelectLinkAccSettingDBIsActive_Result.LinkAccSettingDbName ?? "";
											item2.DbTitle = mobspSelectLinkAccSettingDBIsActive_Result.LinkAccSettingDbTitle ?? "";
											item2.NumberWithLbl = Labels.DocShowLinkAccDocNumber + ": " + item2.Number;
											item2.IdWithLbl = Labels.DocShowLinkAccDocIdStr + ": " + item2.Id;
											item2.VoucherNumberWithLbl = Labels.DocShowLinkAccVoucherNumber + ": " + item2.VoucherNumber;
											item2.FTDateWithLbl = Labels.lblLinkAccFirstTransferDate + ":" + (item2.FTDate.HasValue ? ("<span class='span-transfer-date-to-acc'>" + item2.FTDate.Value.ToString("yyyy/MM/dd HH:mm:ss") + "</span>") : "");
											item2.LTDateWithLbl = Labels.lblLinkAccLastTransferDate + ":" + (item2.LTDate.HasValue ? ("<span class='span-transfer-date-to-acc'>" + item2.LTDate.Value.ToString("yyyy/MM/dd HH:mm:ss") + "</span>") : "");
											list3.Add(item2);
										}
									}
								}
							}
							mobspSelectDocs_Result.DocLinkAccData = "";
							if (list3 != null && Enumerable.Any<DocLinkAccDataViewModel>((IEnumerable<DocLinkAccDataViewModel>)list3))
							{
								mobspSelectDocs_Result.DocLinkAccData = JsonConvert.SerializeObject(Enumerable.ToList<DocLinkAccDataViewModel>((IEnumerable<DocLinkAccDataViewModel>)list3));
							}
						}
						if (mobspSelectDocs_Result.DocLinkAccCodeId.GetValueOrDefault() != 0 || !string.IsNullOrWhiteSpace(mobspSelectDocs_Result.DocLinkAccCode) || mobspSelectDocs_Result.DocLinkAccDocId.GetValueOrDefault() != 0 || !string.IsNullOrWhiteSpace(mobspSelectDocs_Result.DocLinkAccDocNumber) || mobspSelectDocs_Result.DocLinkAccVoucherId.GetValueOrDefault() != 0 || !string.IsNullOrWhiteSpace(mobspSelectDocs_Result.DocLinkAccVoucherNumber) || !string.IsNullOrWhiteSpace(mobspSelectDocs_Result.DocLinkAccDocIdStr) || (!string.IsNullOrWhiteSpace(mobspSelectDocs_Result.DocLinkAccData) && mobspSelectDocs_Result.DocLinkAccData != "[]"))
						{
							mobspSelectDocs_Result.IsSentToLinkAcc = true;
						}
						docDetailsViewModel.Doc = mobspSelectDocs_Result;
						List<MobspSelectDocItems_Result> list4 = Enumerable.ToList<MobspSelectDocItems_Result>((IEnumerable<MobspSelectDocItems_Result>)cRMSpEntities.MobspSelectDocItems(docId, result, result2));
						if (Enumerable.Any<MobspSelectDocItems_Result>((IEnumerable<MobspSelectDocItems_Result>)list4))
						{
							docDetailsViewModel.DocItems = list4;
							foreach (MobspSelectDocItems_Result item3 in list4)
							{
								List<MobspSelectDocItemSerials_Result> collection = Enumerable.ToList<MobspSelectDocItemSerials_Result>((IEnumerable<MobspSelectDocItemSerials_Result>)cRMSpEntities.MobspSelectDocItemSerials(item3.DocItemID, result, result2));
								docDetailsViewModel.DocItemSerials.AddRange(collection);
								ObjectParameter objectParameter = new ObjectParameter("quantityRemain", 0);
								CRMSpEntities cRMSpEntities3 = cRMSpEntities;
								int? prdId = item3.PrdId;
								int? fPId = id;
								int? wHId = mobspSelectDocs_Result.WHId;
								int? currId = 0;
								double? fCR = item3.FCR;
								double? fCRI = item3.FCRI;
								systemIssuing2 = item3.Tracing;
								ObjectParameter quantityRemain = objectParameter;
								MobspReturnPrdQuantity_Result mobspReturnPrdQuantity_Result = Enumerable.FirstOrDefault<MobspReturnPrdQuantity_Result>((IEnumerable<MobspReturnPrdQuantity_Result>)cRMSpEntities3.MobspReturnPrdQuantity(prdId, fPId, wHId, currId, num, result2, fCR, fCRI, systemIssuing2, quantityRemain, cId));
								if (mobspReturnPrdQuantity_Result != null)
								{
									DocItemPrdQuantityViewModel docItemPrdQuantityViewModel = new DocItemPrdQuantityViewModel();
									docItemPrdQuantityViewModel.DocItemID = item3.DocItemID;
									docItemPrdQuantityViewModel.PrdQuantity = mobspReturnPrdQuantity_Result;
									docDetailsViewModel.ItemsPrdQuantity.Add(docItemPrdQuantityViewModel);
								}
							}
						}
						List<MobspIntMsgGetByTypeAndAttachRecId_Result> list5 = Enumerable.ToList<MobspIntMsgGetByTypeAndAttachRecId_Result>((IEnumerable<MobspIntMsgGetByTypeAndAttachRecId_Result>)cRMEntities.MobspIntMsgGetByTypeAndAttachRecId(token2.userId, 20, docId, result, result2));
						if (Enumerable.Any<MobspIntMsgGetByTypeAndAttachRecId_Result>((IEnumerable<MobspIntMsgGetByTypeAndAttachRecId_Result>)list5))
						{
							docDetailsViewModel.InternalMsg = list5;
						}
						List<MobspReturnOrderFromDoc_Result> list6 = Enumerable.ToList<MobspReturnOrderFromDoc_Result>((IEnumerable<MobspReturnOrderFromDoc_Result>)cRMSpEntities.MobspReturnOrderFromDoc(docId, num, result2));
						if (Enumerable.Any<MobspReturnOrderFromDoc_Result>((IEnumerable<MobspReturnOrderFromDoc_Result>)list6))
						{
							docDetailsViewModel.OrderList = list6;
						}
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					else
					{
						message = Messages.MobMsgErorrDocNotFound;
						docDetailsViewModel = null;
						status = ServiceResultStatus.Error;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					docDetailsViewModel = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				docDetailsViewModel = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			docDetailsViewModel = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
			cRMEntities?.Dispose();
		}
		return new ServiceResult<DocDetailsViewModel>
		{
			Message = message,
			Data = docDetailsViewModel,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<DocDetailsViewModel> GetDraftDetails(int docId, int? cId = null, int? ln = null)
	{
		//IL_03a3: Unknown result type (might be due to invalid IL or missing references)
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		DocDetailsViewModel docDetailsViewModel = null;
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
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					if (!UserLogin.IsUserAccess("frmMain", "actwhDraft", UserLogin.CurrentUser, cId))
					{
						return new ServiceResult<DocDetailsViewModel>
						{
							Message = Messages.MobMsgErrorAccessLimited,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					int id = Financial.Get().Id;
					string manualIssuing = Labels.ManualIssuing;
					string systemIssuing = Labels.SystemIssuing;
					cRMEntities = new CRMEntities();
					cRMSpEntities = new CRMSpEntities();
					CRMSpEntities cRMSpEntities2 = cRMSpEntities;
					int? userId = token2.userId;
					int? oprType = 2;
					int? docId2 = docId;
					DateTime? fDateTime = null;
					DateTime? tDateTime = null;
					string manualIssuing2 = manualIssuing;
					string systemIssuing2 = systemIssuing;
					MobspSelectDocs_Result mobspSelectDocs_Result = Enumerable.FirstOrDefault<MobspSelectDocs_Result>((IEnumerable<MobspSelectDocs_Result>)cRMSpEntities2.MobspSelectDocs(userId, oprType, docId2, result, result2, fDateTime, tDateTime, manualIssuing2, systemIssuing2, null, null, cId));
					if (mobspSelectDocs_Result != null)
					{
						docDetailsViewModel = new DocDetailsViewModel();
						docDetailsViewModel.DocItems = new List<MobspSelectDocItems_Result>();
						docDetailsViewModel.DocItemSerials = new List<MobspSelectDocItemSerials_Result>();
						docDetailsViewModel.InternalMsg = new List<MobspIntMsgGetByTypeAndAttachRecId_Result>();
						docDetailsViewModel.ItemsPrdQuantity = new List<DocItemPrdQuantityViewModel>();
						if (Doc.IsEditAfterFix(mobspSelectDocs_Result.EditAfterFixInfoJs, mobspSelectDocs_Result.DocID, 1, token2.userId))
						{
							mobspSelectDocs_Result.IsFix = 0;
						}
						if (!string.IsNullOrWhiteSpace((mobspSelectDocs_Result.EditAfterFixInfoJs ?? "").Replace("[]", "")))
						{
							List<EditAfterFixInfoViewModel> list = JsonConvert.DeserializeObject<List<EditAfterFixInfoViewModel>>(mobspSelectDocs_Result.EditAfterFixInfoJs);
							if (list != null)
							{
								foreach (EditAfterFixInfoViewModel item in list)
								{
									MobspSelectUsersById_Result mobspSelectUsersById_Result = Enumerable.FirstOrDefault<MobspSelectUsersById_Result>((IEnumerable<MobspSelectUsersById_Result>)cRMEntities.MobspSelectUsersById(item.eafUserId, result, result2, cId));
									if (mobspSelectUsersById_Result != null)
									{
										item.eafUserName = mobspSelectUsersById_Result.FullName;
									}
									item.eafRequestDatePersian = item.eafRequestDate.ToString("yyyy/MM/dd HH:mm");
									item.eafEndDatePersian = item.eafEndDate?.ToString("yyyy/MM/dd HH:mm");
									item.eafDoneDatePersian = item.eafDoneDate?.ToString("yyyy/MM/dd HH:mm");
								}
								mobspSelectDocs_Result.EditAfterFixInfoJs = JsonConvert.SerializeObject(list);
							}
						}
						mobspSelectDocs_Result.IsSentToLinkAcc = false;
						MobspSelectCrmsysSetting_Result mobspSelectCrmsysSetting_Result = SysSeting.Get();
						int num2 = 0;
						if (mobspSelectCrmsysSetting_Result != null)
						{
							num2 = mobspSelectCrmsysSetting_Result.LinkAccSystemId.GetValueOrDefault();
						}
						mobspSelectDocs_Result.DocLinkAccData = mobspSelectDocs_Result.DocLinkAccData ?? "";
						if (num2 == 1)
						{
							List<MobspSelectLinkAccSettingDBIsActive_Result> list2 = Enumerable.ToList<MobspSelectLinkAccSettingDBIsActive_Result>((IEnumerable<MobspSelectLinkAccSettingDBIsActive_Result>)cRMSpEntities.MobspSelectLinkAccSettingDBIsActive(num2));
							List<DocLinkAccDataViewModel> list3 = new List<DocLinkAccDataViewModel>();
							if (!string.IsNullOrWhiteSpace(mobspSelectDocs_Result.DocLinkAccData))
							{
								foreach (DocLinkAccDataViewModel item2 in new JavaScriptSerializer().Deserialize<List<DocLinkAccDataViewModel>>(mobspSelectDocs_Result.DocLinkAccData))
								{
									int dbId = 0;
									int.TryParse(item2.DBId.ToString(), out dbId);
									if (dbId != 0 && list2 != null && Enumerable.Any<MobspSelectLinkAccSettingDBIsActive_Result>((IEnumerable<MobspSelectLinkAccSettingDBIsActive_Result>)list2))
									{
										MobspSelectLinkAccSettingDBIsActive_Result mobspSelectLinkAccSettingDBIsActive_Result = Enumerable.FirstOrDefault<MobspSelectLinkAccSettingDBIsActive_Result>((IEnumerable<MobspSelectLinkAccSettingDBIsActive_Result>)list2, (Func<MobspSelectLinkAccSettingDBIsActive_Result, bool>)((MobspSelectLinkAccSettingDBIsActive_Result m) => m.LinkAccSettingDBId == dbId));
										if (mobspSelectLinkAccSettingDBIsActive_Result != null)
										{
											item2.DbName = mobspSelectLinkAccSettingDBIsActive_Result.LinkAccSettingDbName ?? "";
											item2.DbTitle = mobspSelectLinkAccSettingDBIsActive_Result.LinkAccSettingDbTitle ?? "";
											item2.NumberWithLbl = Labels.DocShowLinkAccDocNumber + ": " + item2.Number;
											item2.IdWithLbl = Labels.DocShowLinkAccDocIdStr + ": " + item2.Id;
											item2.VoucherNumberWithLbl = Labels.DocShowLinkAccVoucherNumber + ": " + item2.VoucherNumber;
											item2.FTDateWithLbl = Labels.lblLinkAccFirstTransferDate + ":" + (item2.FTDate.HasValue ? ("<span class='span-transfer-date-to-acc'>" + item2.FTDate.Value.ToString("yyyy/MM/dd HH:mm:ss") + "</span>") : "");
											item2.LTDateWithLbl = Labels.lblLinkAccLastTransferDate + ":" + (item2.LTDate.HasValue ? ("<span class='span-transfer-date-to-acc'>" + item2.LTDate.Value.ToString("yyyy/MM/dd HH:mm:ss") + "</span>") : "");
											list3.Add(item2);
										}
									}
								}
							}
							mobspSelectDocs_Result.DocLinkAccData = "";
							if (list3 != null && Enumerable.Any<DocLinkAccDataViewModel>((IEnumerable<DocLinkAccDataViewModel>)list3))
							{
								mobspSelectDocs_Result.DocLinkAccData = JsonConvert.SerializeObject(Enumerable.ToList<DocLinkAccDataViewModel>((IEnumerable<DocLinkAccDataViewModel>)list3));
							}
						}
						if (mobspSelectDocs_Result.DocLinkAccCodeId.GetValueOrDefault() != 0 || !string.IsNullOrWhiteSpace(mobspSelectDocs_Result.DocLinkAccCode) || mobspSelectDocs_Result.DocLinkAccDocId.GetValueOrDefault() != 0 || !string.IsNullOrWhiteSpace(mobspSelectDocs_Result.DocLinkAccDocNumber) || mobspSelectDocs_Result.DocLinkAccVoucherId.GetValueOrDefault() != 0 || !string.IsNullOrWhiteSpace(mobspSelectDocs_Result.DocLinkAccVoucherNumber) || !string.IsNullOrWhiteSpace(mobspSelectDocs_Result.DocLinkAccDocIdStr) || (!string.IsNullOrWhiteSpace(mobspSelectDocs_Result.DocLinkAccData) && mobspSelectDocs_Result.DocLinkAccData != "[]"))
						{
							mobspSelectDocs_Result.IsSentToLinkAcc = true;
						}
						docDetailsViewModel.Doc = mobspSelectDocs_Result;
						List<MobspSelectDocItems_Result> list4 = Enumerable.ToList<MobspSelectDocItems_Result>((IEnumerable<MobspSelectDocItems_Result>)cRMSpEntities.MobspSelectDocItems(docId, result, result2));
						if (Enumerable.Any<MobspSelectDocItems_Result>((IEnumerable<MobspSelectDocItems_Result>)list4))
						{
							docDetailsViewModel.DocItems = list4;
							foreach (MobspSelectDocItems_Result item3 in list4)
							{
								List<MobspSelectDocItemSerials_Result> collection = Enumerable.ToList<MobspSelectDocItemSerials_Result>((IEnumerable<MobspSelectDocItemSerials_Result>)cRMSpEntities.MobspSelectDocItemSerials(item3.DocItemID, result, result2));
								docDetailsViewModel.DocItemSerials.AddRange(collection);
								ObjectParameter objectParameter = new ObjectParameter("quantityRemain", 0);
								CRMSpEntities cRMSpEntities3 = cRMSpEntities;
								int? prdId = item3.PrdId;
								int? fPId = id;
								int? wHId = mobspSelectDocs_Result.WHId;
								int? currId = 0;
								double? fCR = item3.FCR;
								double? fCRI = item3.FCRI;
								systemIssuing2 = item3.Tracing;
								ObjectParameter quantityRemain = objectParameter;
								MobspReturnPrdQuantity_Result mobspReturnPrdQuantity_Result = Enumerable.FirstOrDefault<MobspReturnPrdQuantity_Result>((IEnumerable<MobspReturnPrdQuantity_Result>)cRMSpEntities3.MobspReturnPrdQuantity(prdId, fPId, wHId, currId, num, result2, fCR, fCRI, systemIssuing2, quantityRemain, cId));
								if (mobspReturnPrdQuantity_Result != null)
								{
									DocItemPrdQuantityViewModel docItemPrdQuantityViewModel = new DocItemPrdQuantityViewModel();
									docItemPrdQuantityViewModel.DocItemID = item3.DocItemID;
									docItemPrdQuantityViewModel.PrdQuantity = mobspReturnPrdQuantity_Result;
									docDetailsViewModel.ItemsPrdQuantity.Add(docItemPrdQuantityViewModel);
								}
							}
						}
						List<MobspIntMsgGetByTypeAndAttachRecId_Result> list5 = Enumerable.ToList<MobspIntMsgGetByTypeAndAttachRecId_Result>((IEnumerable<MobspIntMsgGetByTypeAndAttachRecId_Result>)cRMEntities.MobspIntMsgGetByTypeAndAttachRecId(token2.userId, 20, docId, result, result2));
						if (Enumerable.Any<MobspIntMsgGetByTypeAndAttachRecId_Result>((IEnumerable<MobspIntMsgGetByTypeAndAttachRecId_Result>)list5))
						{
							docDetailsViewModel.InternalMsg = list5;
						}
						List<MobspReturnOrderFromDoc_Result> list6 = Enumerable.ToList<MobspReturnOrderFromDoc_Result>((IEnumerable<MobspReturnOrderFromDoc_Result>)cRMSpEntities.MobspReturnOrderFromDoc(docId, num, result2));
						if (Enumerable.Any<MobspReturnOrderFromDoc_Result>((IEnumerable<MobspReturnOrderFromDoc_Result>)list6))
						{
							docDetailsViewModel.OrderList = list6;
						}
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					else
					{
						message = Messages.MobMsgErorrDocNotFound;
						docDetailsViewModel = null;
						status = ServiceResultStatus.Error;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					docDetailsViewModel = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				docDetailsViewModel = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			docDetailsViewModel = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
			cRMEntities?.Dispose();
		}
		return new ServiceResult<DocDetailsViewModel>
		{
			Message = message,
			Data = docDetailsViewModel,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<DocDetailsViewModel> GetWarehouseMovementDetails(int docId, int? cId = null, int? ln = null)
	{
		//IL_03a3: Unknown result type (might be due to invalid IL or missing references)
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		DocDetailsViewModel docDetailsViewModel = null;
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
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					if (!UserLogin.IsUserAccess("frmMain", "actwhWareHouseMovement", UserLogin.CurrentUser, cId))
					{
						return new ServiceResult<DocDetailsViewModel>
						{
							Message = Messages.MobMsgErrorAccessLimited,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					int id = Financial.Get().Id;
					string manualIssuing = Labels.ManualIssuing;
					string systemIssuing = Labels.SystemIssuing;
					cRMEntities = new CRMEntities();
					cRMSpEntities = new CRMSpEntities();
					CRMSpEntities cRMSpEntities2 = cRMSpEntities;
					int? userId = token2.userId;
					int? oprType = 3;
					int? docId2 = docId;
					DateTime? fDateTime = null;
					DateTime? tDateTime = null;
					string manualIssuing2 = manualIssuing;
					string systemIssuing2 = systemIssuing;
					MobspSelectDocs_Result mobspSelectDocs_Result = Enumerable.FirstOrDefault<MobspSelectDocs_Result>((IEnumerable<MobspSelectDocs_Result>)cRMSpEntities2.MobspSelectDocs(userId, oprType, docId2, result, result2, fDateTime, tDateTime, manualIssuing2, systemIssuing2, null, null, cId));
					if (mobspSelectDocs_Result != null)
					{
						docDetailsViewModel = new DocDetailsViewModel();
						docDetailsViewModel.DocItems = new List<MobspSelectDocItems_Result>();
						docDetailsViewModel.DocItemSerials = new List<MobspSelectDocItemSerials_Result>();
						docDetailsViewModel.InternalMsg = new List<MobspIntMsgGetByTypeAndAttachRecId_Result>();
						docDetailsViewModel.ItemsPrdQuantity = new List<DocItemPrdQuantityViewModel>();
						if (Doc.IsEditAfterFix(mobspSelectDocs_Result.EditAfterFixInfoJs, mobspSelectDocs_Result.DocID, 1, token2.userId))
						{
							mobspSelectDocs_Result.IsFix = 0;
						}
						if (!string.IsNullOrWhiteSpace((mobspSelectDocs_Result.EditAfterFixInfoJs ?? "").Replace("[]", "")))
						{
							List<EditAfterFixInfoViewModel> list = JsonConvert.DeserializeObject<List<EditAfterFixInfoViewModel>>(mobspSelectDocs_Result.EditAfterFixInfoJs);
							if (list != null)
							{
								foreach (EditAfterFixInfoViewModel item in list)
								{
									MobspSelectUsersById_Result mobspSelectUsersById_Result = Enumerable.FirstOrDefault<MobspSelectUsersById_Result>((IEnumerable<MobspSelectUsersById_Result>)cRMEntities.MobspSelectUsersById(item.eafUserId, result, result2, cId));
									if (mobspSelectUsersById_Result != null)
									{
										item.eafUserName = mobspSelectUsersById_Result.FullName;
									}
									item.eafRequestDatePersian = item.eafRequestDate.ToString("yyyy/MM/dd HH:mm");
									item.eafEndDatePersian = item.eafEndDate?.ToString("yyyy/MM/dd HH:mm");
									item.eafDoneDatePersian = item.eafDoneDate?.ToString("yyyy/MM/dd HH:mm");
								}
								mobspSelectDocs_Result.EditAfterFixInfoJs = JsonConvert.SerializeObject(list);
							}
						}
						mobspSelectDocs_Result.IsSentToLinkAcc = false;
						MobspSelectCrmsysSetting_Result mobspSelectCrmsysSetting_Result = SysSeting.Get();
						int num2 = 0;
						if (mobspSelectCrmsysSetting_Result != null)
						{
							num2 = mobspSelectCrmsysSetting_Result.LinkAccSystemId.GetValueOrDefault();
						}
						mobspSelectDocs_Result.DocLinkAccData = mobspSelectDocs_Result.DocLinkAccData ?? "";
						if (num2 == 1)
						{
							List<MobspSelectLinkAccSettingDBIsActive_Result> list2 = Enumerable.ToList<MobspSelectLinkAccSettingDBIsActive_Result>((IEnumerable<MobspSelectLinkAccSettingDBIsActive_Result>)cRMSpEntities.MobspSelectLinkAccSettingDBIsActive(num2));
							List<DocLinkAccDataViewModel> list3 = new List<DocLinkAccDataViewModel>();
							if (!string.IsNullOrWhiteSpace(mobspSelectDocs_Result.DocLinkAccData))
							{
								foreach (DocLinkAccDataViewModel item2 in new JavaScriptSerializer().Deserialize<List<DocLinkAccDataViewModel>>(mobspSelectDocs_Result.DocLinkAccData))
								{
									int dbId = 0;
									int.TryParse(item2.DBId.ToString(), out dbId);
									if (dbId != 0 && list2 != null && Enumerable.Any<MobspSelectLinkAccSettingDBIsActive_Result>((IEnumerable<MobspSelectLinkAccSettingDBIsActive_Result>)list2))
									{
										MobspSelectLinkAccSettingDBIsActive_Result mobspSelectLinkAccSettingDBIsActive_Result = Enumerable.FirstOrDefault<MobspSelectLinkAccSettingDBIsActive_Result>((IEnumerable<MobspSelectLinkAccSettingDBIsActive_Result>)list2, (Func<MobspSelectLinkAccSettingDBIsActive_Result, bool>)((MobspSelectLinkAccSettingDBIsActive_Result m) => m.LinkAccSettingDBId == dbId));
										if (mobspSelectLinkAccSettingDBIsActive_Result != null)
										{
											item2.DbName = mobspSelectLinkAccSettingDBIsActive_Result.LinkAccSettingDbName ?? "";
											item2.DbTitle = mobspSelectLinkAccSettingDBIsActive_Result.LinkAccSettingDbTitle ?? "";
											item2.NumberWithLbl = Labels.DocShowLinkAccDocNumber + ": " + item2.Number;
											item2.IdWithLbl = Labels.DocShowLinkAccDocIdStr + ": " + item2.Id;
											item2.VoucherNumberWithLbl = Labels.DocShowLinkAccVoucherNumber + ": " + item2.VoucherNumber;
											item2.FTDateWithLbl = Labels.lblLinkAccFirstTransferDate + ":" + (item2.FTDate.HasValue ? ("<span class='span-transfer-date-to-acc'>" + item2.FTDate.Value.ToString("yyyy/MM/dd HH:mm:ss") + "</span>") : "");
											item2.LTDateWithLbl = Labels.lblLinkAccLastTransferDate + ":" + (item2.LTDate.HasValue ? ("<span class='span-transfer-date-to-acc'>" + item2.LTDate.Value.ToString("yyyy/MM/dd HH:mm:ss") + "</span>") : "");
											list3.Add(item2);
										}
									}
								}
							}
							mobspSelectDocs_Result.DocLinkAccData = "";
							if (list3 != null && Enumerable.Any<DocLinkAccDataViewModel>((IEnumerable<DocLinkAccDataViewModel>)list3))
							{
								mobspSelectDocs_Result.DocLinkAccData = JsonConvert.SerializeObject(Enumerable.ToList<DocLinkAccDataViewModel>((IEnumerable<DocLinkAccDataViewModel>)list3));
							}
						}
						if (mobspSelectDocs_Result.DocLinkAccCodeId.GetValueOrDefault() != 0 || !string.IsNullOrWhiteSpace(mobspSelectDocs_Result.DocLinkAccCode) || mobspSelectDocs_Result.DocLinkAccDocId.GetValueOrDefault() != 0 || !string.IsNullOrWhiteSpace(mobspSelectDocs_Result.DocLinkAccDocNumber) || mobspSelectDocs_Result.DocLinkAccVoucherId.GetValueOrDefault() != 0 || !string.IsNullOrWhiteSpace(mobspSelectDocs_Result.DocLinkAccVoucherNumber) || !string.IsNullOrWhiteSpace(mobspSelectDocs_Result.DocLinkAccDocIdStr) || (!string.IsNullOrWhiteSpace(mobspSelectDocs_Result.DocLinkAccData) && mobspSelectDocs_Result.DocLinkAccData != "[]"))
						{
							mobspSelectDocs_Result.IsSentToLinkAcc = true;
						}
						docDetailsViewModel.Doc = mobspSelectDocs_Result;
						List<MobspSelectDocItems_Result> list4 = Enumerable.ToList<MobspSelectDocItems_Result>((IEnumerable<MobspSelectDocItems_Result>)cRMSpEntities.MobspSelectDocItems(docId, result, result2));
						if (Enumerable.Any<MobspSelectDocItems_Result>((IEnumerable<MobspSelectDocItems_Result>)list4))
						{
							docDetailsViewModel.DocItems = list4;
							foreach (MobspSelectDocItems_Result item3 in list4)
							{
								List<MobspSelectDocItemSerials_Result> collection = Enumerable.ToList<MobspSelectDocItemSerials_Result>((IEnumerable<MobspSelectDocItemSerials_Result>)cRMSpEntities.MobspSelectDocItemSerials(item3.DocItemID, result, result2));
								docDetailsViewModel.DocItemSerials.AddRange(collection);
								ObjectParameter objectParameter = new ObjectParameter("quantityRemain", 0);
								CRMSpEntities cRMSpEntities3 = cRMSpEntities;
								int? prdId = item3.PrdId;
								int? fPId = id;
								int? wHId = mobspSelectDocs_Result.WHId;
								int? currId = 0;
								double? fCR = item3.FCR;
								double? fCRI = item3.FCRI;
								systemIssuing2 = item3.Tracing;
								ObjectParameter quantityRemain = objectParameter;
								MobspReturnPrdQuantity_Result mobspReturnPrdQuantity_Result = Enumerable.FirstOrDefault<MobspReturnPrdQuantity_Result>((IEnumerable<MobspReturnPrdQuantity_Result>)cRMSpEntities3.MobspReturnPrdQuantity(prdId, fPId, wHId, currId, num, result2, fCR, fCRI, systemIssuing2, quantityRemain, cId));
								if (mobspReturnPrdQuantity_Result != null)
								{
									DocItemPrdQuantityViewModel docItemPrdQuantityViewModel = new DocItemPrdQuantityViewModel();
									docItemPrdQuantityViewModel.DocItemID = item3.DocItemID;
									docItemPrdQuantityViewModel.PrdQuantity = mobspReturnPrdQuantity_Result;
									docDetailsViewModel.ItemsPrdQuantity.Add(docItemPrdQuantityViewModel);
								}
							}
						}
						List<MobspIntMsgGetByTypeAndAttachRecId_Result> list5 = Enumerable.ToList<MobspIntMsgGetByTypeAndAttachRecId_Result>((IEnumerable<MobspIntMsgGetByTypeAndAttachRecId_Result>)cRMEntities.MobspIntMsgGetByTypeAndAttachRecId(token2.userId, 20, docId, result, result2));
						if (Enumerable.Any<MobspIntMsgGetByTypeAndAttachRecId_Result>((IEnumerable<MobspIntMsgGetByTypeAndAttachRecId_Result>)list5))
						{
							docDetailsViewModel.InternalMsg = list5;
						}
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					else
					{
						message = Messages.MobMsgErorrDocNotFound;
						docDetailsViewModel = null;
						status = ServiceResultStatus.Error;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					docDetailsViewModel = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				docDetailsViewModel = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			docDetailsViewModel = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
			cRMEntities?.Dispose();
		}
		return new ServiceResult<DocDetailsViewModel>
		{
			Message = message,
			Data = docDetailsViewModel,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectDocItemSerials_Result>> GetDocItemSerials(int docItemId, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		List<MobspSelectDocItemSerials_Result> data = null;
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
					data = Enumerable.ToList<MobspSelectDocItemSerials_Result>((IEnumerable<MobspSelectDocItemSerials_Result>)cRMSpEntities.MobspSelectDocItemSerials(docItemId, result, result2));
					message = Messages.MobMsgSuccessAction;
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
			cRMSpEntities?.Dispose();
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<MobspSelectDocItemSerials_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<DraftListAndIntMsgViewModel> GetDraftList(DateTime? fDateTime, DateTime? tDateTime, int? pageNumber = 1, int? pageSize = 10, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		DraftListAndIntMsgViewModel draftListAndIntMsgViewModel = null;
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
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					if (base.Request.Headers.TryGetValues("imeiCode", out var _) && !Common.CheckUserImeiCode(token2.userId, Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("imeiCode")), Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("appName"))))
					{
						return new ServiceResult<DraftListAndIntMsgViewModel>
						{
							Message = Messages.MobMsgUserImeiNotPreDefined,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					draftListAndIntMsgViewModel = new DraftListAndIntMsgViewModel();
					draftListAndIntMsgViewModel.Drafts = new List<MobspSelectDocs_Result>();
					draftListAndIntMsgViewModel.InternalMessages = new List<MobspIntMsgGetByTypeAndAttachRecId_Result>();
					string manualIssuing = Labels.ManualIssuing;
					string systemIssuing = Labels.SystemIssuing;
					cRMEntities = new CRMEntities();
					cRMSpEntities = new CRMSpEntities();
					DraftListAndIntMsgViewModel draftListAndIntMsgViewModel2 = draftListAndIntMsgViewModel;
					CRMSpEntities cRMSpEntities2 = cRMSpEntities;
					int? userId = token2.userId;
					int? oprType = 2;
					int? docId = 0;
					string manualIssuing2 = manualIssuing;
					string systemIssuing2 = systemIssuing;
					int? pageNumber2 = pageNumber;
					draftListAndIntMsgViewModel2.Drafts = Enumerable.ToList<MobspSelectDocs_Result>((IEnumerable<MobspSelectDocs_Result>)cRMSpEntities2.MobspSelectDocs(userId, oprType, docId, result, result2, fDateTime, tDateTime, manualIssuing2, systemIssuing2, pageNumber2, pageSize, cId));
					if (!VersionBuyer.WareHouse)
					{
						draftListAndIntMsgViewModel.Drafts = Enumerable.ToList<MobspSelectDocs_Result>(Enumerable.Take<MobspSelectDocs_Result>((IEnumerable<MobspSelectDocs_Result>)draftListAndIntMsgViewModel.Drafts, 2));
					}
					foreach (MobspSelectDocs_Result draft in draftListAndIntMsgViewModel.Drafts)
					{
						List<MobspIntMsgGetByTypeAndAttachRecId_Result> list = Enumerable.ToList<MobspIntMsgGetByTypeAndAttachRecId_Result>((IEnumerable<MobspIntMsgGetByTypeAndAttachRecId_Result>)cRMEntities.MobspIntMsgGetByTypeAndAttachRecId(token2.userId, 20, draft.DocID, result, result2));
						if (Enumerable.Any<MobspIntMsgGetByTypeAndAttachRecId_Result>((IEnumerable<MobspIntMsgGetByTypeAndAttachRecId_Result>)list))
						{
							draftListAndIntMsgViewModel.InternalMessages.AddRange(list);
						}
					}
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					draftListAndIntMsgViewModel = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				draftListAndIntMsgViewModel = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			draftListAndIntMsgViewModel = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
			cRMEntities?.Dispose();
		}
		return new ServiceResult<DraftListAndIntMsgViewModel>
		{
			Message = message,
			Data = draftListAndIntMsgViewModel,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<int> GetDocType(int docId, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		int data = 0;
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
					MobspReturnDocOprTypeFromDocId_Result mobspReturnDocOprTypeFromDocId_Result = Enumerable.FirstOrDefault<MobspReturnDocOprTypeFromDocId_Result>((IEnumerable<MobspReturnDocOprTypeFromDocId_Result>)cRMSpEntities.MobspReturnDocOprTypeFromDocId(docId));
					if (mobspReturnDocOprTypeFromDocId_Result != null)
					{
						data = mobspReturnDocOprTypeFromDocId_Result.OprType.GetValueOrDefault();
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					else
					{
						message = Messages.MobMsgErorrNotFound;
						data = 0;
						status = ServiceResultStatus.Fail;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = 0;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = 0;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = 0;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<int>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> InsertAutoDocItemSerial(int docId, int docItemId, int whId, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		string data = null;
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
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMSpEntities = new CRMSpEntities();
					if (!UserLogin.IsUserAccess("frmDraft", "actInsertAutoItemSerial", UserLogin.CurrentUser, cId))
					{
						return new ServiceResult<string>
						{
							Message = Messages.MobMsgErrorAccessLimited,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					if (Doc.IsFixed(docId))
					{
						return new ServiceResult<string>
						{
							Message = Messages.msgErrorNotActiveDoc,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					int userId = token2.userId;
					int id = Financial.Get().Id;
					string appType = Mobile.Classes.Configuration.AppType;
					short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					cRMSpEntities.MobspInsertAutoDocItemSerial(docItemId, whId, userId, value2, id, value, registerDatePersian, appType, num);
					message = Messages.MobMsgSuccessAction;
					data = null;
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectAutoDocItemSerial_Result>> GetAutoDocItemSerial(int prdId, float quantity, int whId, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<MobspSelectAutoDocItemSerial_Result> data = null;
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
					if (!UserLogin.IsUserAccess("frmDraft", "actInsertAutoItemSerial", UserLogin.CurrentUser, cId))
					{
						return new ServiceResult<List<MobspSelectAutoDocItemSerial_Result>>
						{
							Message = Messages.MobMsgErrorAccessLimited,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					data = Enumerable.ToList<MobspSelectAutoDocItemSerial_Result>((IEnumerable<MobspSelectAutoDocItemSerial_Result>)cRMSpEntities.MobspSelectAutoDocItemSerial(prdId, quantity, whId));
					message = Messages.MobMsgSuccessAction;
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<List<MobspSelectAutoDocItemSerial_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspReturnDocPrdSerial_Result>> GetDocPrdSerial(string val, int whId, int prdId, int serialId, int orderId, string OrderIds, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<MobspReturnDocPrdSerial_Result> data = null;
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
				if (new Common().GetToken(token) != null)
				{
					cRMSpEntities = new CRMSpEntities();
					int id = Financial.Get().Id;
					List<MobspReturnDocPrdSerial_Result> list = Enumerable.ToList<MobspReturnDocPrdSerial_Result>((IEnumerable<MobspReturnDocPrdSerial_Result>)cRMSpEntities.MobspReturnDocPrdSerial(id, whId, prdId, serialId, num, result2, orderId, cId, OrderIds));
					data = new List<MobspReturnDocPrdSerial_Result>();
					data = (string.IsNullOrWhiteSpace(val) ? Enumerable.ToList<MobspReturnDocPrdSerial_Result>(Enumerable.Take<MobspReturnDocPrdSerial_Result>((IEnumerable<MobspReturnDocPrdSerial_Result>)list, 500)) : Enumerable.ToList<MobspReturnDocPrdSerial_Result>(Enumerable.Take<MobspReturnDocPrdSerial_Result>(Enumerable.Where<MobspReturnDocPrdSerial_Result>((IEnumerable<MobspReturnDocPrdSerial_Result>)list, (Func<MobspReturnDocPrdSerial_Result, bool>)((MobspReturnDocPrdSerial_Result x) => (x.Serial ?? "").ToLower().Contains(val.ToLower()))), 500)));
					message = Messages.MobMsgSuccessAction;
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<List<MobspReturnDocPrdSerial_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspReturnDocPrdSerialByPaging_Result>> GetDocPrdSerialWithPaging(string val, int whId, int prdId, int serialId, int orderId, string OrderIds, int? ln = null, int? cId = null, int? pageSize = null, int? lastRowNumber = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<MobspReturnDocPrdSerialByPaging_Result> data = null;
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
				if (new Common().GetToken(token) != null)
				{
					cRMSpEntities = new CRMSpEntities();
					int id = Financial.Get().Id;
					List<MobspReturnDocPrdSerialByPaging_Result> list = Enumerable.ToList<MobspReturnDocPrdSerialByPaging_Result>((IEnumerable<MobspReturnDocPrdSerialByPaging_Result>)cRMSpEntities.MobspReturnDocPrdSerialByPaging(val, id, whId, prdId, serialId, num, result2, orderId, cId, pageSize, lastRowNumber, OrderIds));
					data = new List<MobspReturnDocPrdSerialByPaging_Result>();
					data = (string.IsNullOrWhiteSpace(val) ? Enumerable.ToList<MobspReturnDocPrdSerialByPaging_Result>(Enumerable.Take<MobspReturnDocPrdSerialByPaging_Result>((IEnumerable<MobspReturnDocPrdSerialByPaging_Result>)list, 500)) : Enumerable.ToList<MobspReturnDocPrdSerialByPaging_Result>(Enumerable.Take<MobspReturnDocPrdSerialByPaging_Result>(Enumerable.Where<MobspReturnDocPrdSerialByPaging_Result>((IEnumerable<MobspReturnDocPrdSerialByPaging_Result>)list, (Func<MobspReturnDocPrdSerialByPaging_Result, bool>)((MobspReturnDocPrdSerialByPaging_Result x) => (x.Serial ?? "").ToLower().Contains(val.ToLower()))), 500)));
					message = Messages.MobMsgSuccessAction;
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<List<MobspReturnDocPrdSerialByPaging_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> InsertDocItemFromLinkedPrd(int prdId, int docId, int whId, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		string data = null;
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
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMSpEntities = new CRMSpEntities();
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					int id = Financial.Get().Id;
					short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					string appType = Mobile.Classes.Configuration.AppType;
					int userId = token2.userId;
					string prdStockTxt = Labels.PrdStockTxt;
					MobspInsertDocItemFromLinkedPrd_Result mobspInsertDocItemFromLinkedPrd_Result = Enumerable.FirstOrDefault<MobspInsertDocItemFromLinkedPrd_Result>((IEnumerable<MobspInsertDocItemFromLinkedPrd_Result>)cRMSpEntities.MobspInsertDocItemFromLinkedPrd(prdId, docId, whId, userId, id, value2, value, registerDatePersian, appType, num, result2, prdStockTxt, cId));
					if (mobspInsertDocItemFromLinkedPrd_Result != null)
					{
						int result3 = 0;
						int.TryParse(mobspInsertDocItemFromLinkedPrd_Result.Result.ToString(), out result3);
						if (result3 == 1 && !string.IsNullOrWhiteSpace(mobspInsertDocItemFromLinkedPrd_Result.ErrorMessage))
						{
							string[] array = mobspInsertDocItemFromLinkedPrd_Result.ErrorMessage.Split(new char[1] { '|' });
							if (array != null)
							{
								string text = "";
								string[] array2 = array;
								foreach (string text2 in array2)
								{
									if (!string.IsNullOrWhiteSpace(text2))
									{
										text = text + text2 + "<br>";
									}
								}
								if (!string.IsNullOrWhiteSpace(text))
								{
									data = Messages.frmFormBaseInsertSuccessFulMessage + "<br>" + Messages.msgErrorNotAddedLinkedPrdWithoutStockToDocItem + "<br>" + text + "<br>" + Messages.msgAddPrdWithMinStockInDoc;
								}
							}
						}
					}
					message = Messages.MobMsgSuccessAction;
					data = null;
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> InsertDocItemFromLinkedPrdWithMinStock(int docItemId, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		string data = null;
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
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMSpEntities = new CRMSpEntities();
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					int id = Financial.Get().Id;
					short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					string appType = Mobile.Classes.Configuration.AppType;
					int userId = token2.userId;
					_ = Labels.PrdStockTxt;
					mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)cRMSpEntities.MobspInsertDocItemFromLinkedPrdWithMinStock(docItemId, userId, id, value2, value, registerDatePersian, appType, result2, cId));
					int result3 = 0;
					if (mct_I_Result != null)
					{
						result3 = 0;
						int.TryParse(mct_I_Result.Result.ToString(), out result3);
					}
					if (result3 > 0)
					{
						message = Messages.MobMsgSuccessAction;
						data = null;
						status = ServiceResultStatus.Success;
					}
					else
					{
						message = Messages.msgErrorInAddLinkedPrd;
						data = null;
						status = ServiceResultStatus.Fail;
					}
					message = Messages.MobMsgSuccessAction;
					data = null;
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<WarehouseMovementListAndIntMsgViewModel> GetWarehouseMovementList(DateTime fDateTime, DateTime tDateTime, int? pageNumber = 1, int? pageSize = 10, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		WarehouseMovementListAndIntMsgViewModel warehouseMovementListAndIntMsgViewModel = null;
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
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					if (base.Request.Headers.TryGetValues("imeiCode", out var _) && !Common.CheckUserImeiCode(token2.userId, Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("imeiCode")), Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("appName"))))
					{
						return new ServiceResult<WarehouseMovementListAndIntMsgViewModel>
						{
							Message = Messages.MobMsgUserImeiNotPreDefined,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					warehouseMovementListAndIntMsgViewModel = new WarehouseMovementListAndIntMsgViewModel();
					warehouseMovementListAndIntMsgViewModel.Movements = new List<MobspSelectDocs_Result>();
					warehouseMovementListAndIntMsgViewModel.InternalMessages = new List<MobspIntMsgGetByTypeAndAttachRecId_Result>();
					string manualIssuing = Labels.ManualIssuing;
					string systemIssuing = Labels.SystemIssuing;
					cRMEntities = new CRMEntities();
					cRMSpEntities = new CRMSpEntities();
					WarehouseMovementListAndIntMsgViewModel warehouseMovementListAndIntMsgViewModel2 = warehouseMovementListAndIntMsgViewModel;
					CRMSpEntities cRMSpEntities2 = cRMSpEntities;
					int? userId = token2.userId;
					int? oprType = 3;
					int? docId = 0;
					DateTime? fDateTime2 = fDateTime;
					DateTime? tDateTime2 = tDateTime;
					string manualIssuing2 = manualIssuing;
					string systemIssuing2 = systemIssuing;
					int? pageNumber2 = pageNumber;
					warehouseMovementListAndIntMsgViewModel2.Movements = Enumerable.ToList<MobspSelectDocs_Result>((IEnumerable<MobspSelectDocs_Result>)cRMSpEntities2.MobspSelectDocs(userId, oprType, docId, result, result2, fDateTime2, tDateTime2, manualIssuing2, systemIssuing2, pageNumber2, pageSize, cId));
					if (!VersionBuyer.WareHouse)
					{
						warehouseMovementListAndIntMsgViewModel.Movements = Enumerable.ToList<MobspSelectDocs_Result>(Enumerable.Take<MobspSelectDocs_Result>((IEnumerable<MobspSelectDocs_Result>)warehouseMovementListAndIntMsgViewModel.Movements, 2));
					}
					foreach (MobspSelectDocs_Result movement in warehouseMovementListAndIntMsgViewModel.Movements)
					{
						List<MobspIntMsgGetByTypeAndAttachRecId_Result> list = Enumerable.ToList<MobspIntMsgGetByTypeAndAttachRecId_Result>((IEnumerable<MobspIntMsgGetByTypeAndAttachRecId_Result>)cRMEntities.MobspIntMsgGetByTypeAndAttachRecId(token2.userId, 20, movement.DocID, result, result2));
						if (Enumerable.Any<MobspIntMsgGetByTypeAndAttachRecId_Result>((IEnumerable<MobspIntMsgGetByTypeAndAttachRecId_Result>)list))
						{
							warehouseMovementListAndIntMsgViewModel.InternalMessages.AddRange(list);
						}
					}
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					warehouseMovementListAndIntMsgViewModel = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				warehouseMovementListAndIntMsgViewModel = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			warehouseMovementListAndIntMsgViewModel = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
			cRMEntities?.Dispose();
		}
		return new ServiceResult<WarehouseMovementListAndIntMsgViewModel>
		{
			Message = message,
			Data = warehouseMovementListAndIntMsgViewModel,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DocItemImportExcelViewModel>> CheckDocItemsBeforeImportExcel(DocItemImportExcelParamsViewModel model)
	{
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		List<DocItemImportExcelViewModel> data = new List<DocItemImportExcelViewModel>();
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
				if (new Common().GetToken(token) != null)
				{
					cRMSpEntities = new CRMSpEntities();
					if (!string.IsNullOrEmpty(model.DocItemJson))
					{
						ObjectParameter objectParameter = new ObjectParameter("result", "");
						cRMSpEntities.MobspCheckDocItemsBeforeImportExcel(model.DocItemJson, model.DocId, model.WHId, (model.WHIdI == 0) ? null : new int?(model.WHIdI), model.Position, UserLogin.CurrentUser.UserId, objectParameter, num, result2, model.OrderId, model.BuyOrderId, model.CenterId);
						List<DocItemImportExcelViewModel> list = new List<DocItemImportExcelViewModel>();
						if (objectParameter.Value != null)
						{
							string text = objectParameter.Value.ToString();
							if (!string.IsNullOrWhiteSpace(text))
							{
								list = new JavaScriptSerializer().Deserialize<List<DocItemImportExcelViewModel>>(text);
								if (list != null && Enumerable.Any<DocItemImportExcelViewModel>((IEnumerable<DocItemImportExcelViewModel>)list))
								{
									foreach (DocItemImportExcelViewModel item in list)
									{
										string text2 = item.ConflictErrorDb ?? "";
										if (string.IsNullOrWhiteSpace(text2))
										{
											continue;
										}
										string[] array = text2.Split(new char[1] { '|' });
										if (!((array != null) & (array.Length != 0)))
										{
											continue;
										}
										string[] array2 = array;
										foreach (string text3 in array2)
										{
											if (string.IsNullOrWhiteSpace(text3))
											{
												continue;
											}
											if (text3 == "1")
											{
												item.HasConflict = true;
												item.ConflictDesc = item.ConflictDesc + string.Format(Messages.msgErrorIsNotFound, Labels.DocItemImportExcelPrdCode) + "|";
											}
											if (text3 == "2")
											{
												item.HasConflict = true;
												item.ConflictDesc = item.ConflictDesc + string.Format(Messages.msgErrorIsNotSpecified, Labels.DocItemImportExcelTracing) + "|";
											}
											if (text3 == "3")
											{
												item.HasConflict = true;
												item.ConflictDesc = item.ConflictDesc + Messages.DraftQuantityRemainLimitExceeded + "|";
											}
											if (text3.IndexOf("4,", StringComparison.Ordinal) >= 0)
											{
												string[] array3 = text3.Split(new char[1] { ',' });
												string arg = "";
												if (array3 != null && array3.Length == 2)
												{
													arg = array3[1];
												}
												item.HasConflict = true;
												item.ConflictDesc = item.ConflictDesc + string.Format(Messages.msgErrorQtyCanNotMoreWithoutDocItemQty, arg) + "|";
											}
											if (text3 == "5")
											{
												item.HasConflict = true;
												item.ConflictDesc = item.ConflictDesc + string.Format(Messages.msgErrorCanNotAddNewTracingCode, item.Tracing ?? "") + "|";
											}
											if (text3.IndexOf("6,", StringComparison.Ordinal) >= 0)
											{
												string[] array4 = text3.Split(new char[1] { ',' });
												string arg2 = "";
												if (array4 != null && array4.Length == 2)
												{
													arg2 = array4[1];
												}
												item.HasConflict = true;
												item.ConflictDesc = item.ConflictDesc + string.Format(Messages.msgErrorDocItemTracingDuplicate, arg2) + "|";
											}
											if (text3 == "7")
											{
												item.HasConflict = true;
												item.ConflictDesc = item.ConflictDesc + string.Format(Messages.msgErrorIsNotFound, Labels.DocItemImportExcelTracing) + "|";
											}
											if (!string.IsNullOrWhiteSpace(item.ConflictDesc))
											{
												item.ConflictDesc = item.ConflictDesc.Replace("<br>", "").Replace("</br>", "").Replace("<br />", "")
													.Replace("<br/>", "");
											}
										}
									}
								}
							}
						}
						data = list;
					}
					message = Messages.MobMsgSuccessAction;
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
			cRMSpEntities?.Dispose();
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<DocItemImportExcelViewModel>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> IssueOrderControlOrder(int docId, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		string data = null;
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
				if (new Common().GetToken(token) != null)
				{
					cRMSpEntities = new CRMSpEntities();
					MobspReturnOrderFromDoc_Result mobspReturnOrderFromDoc_Result = Enumerable.FirstOrDefault<MobspReturnOrderFromDoc_Result>((IEnumerable<MobspReturnOrderFromDoc_Result>)cRMSpEntities.MobspReturnOrderFromDoc(docId, num, result2));
					if (mobspReturnOrderFromDoc_Result != null)
					{
						mobspReturnOrderFromDoc_Result.ordDate = (mobspReturnOrderFromDoc_Result.ordDateTime.HasValue ? mobspReturnOrderFromDoc_Result.ordDateTime.Value.ToString("yyyyMMdd") : mobspReturnOrderFromDoc_Result.ordDate);
						_ = mobspReturnOrderFromDoc_Result.RegisterDate;
						mobspReturnOrderFromDoc_Result.RegisterDatePersian = mobspReturnOrderFromDoc_Result.RegisterDate.ToString("yyyyMMdd");
						string text = mobspReturnOrderFromDoc_Result.ordNumber.ToString();
						data = Labels.Error + " !\r\n" + "msgIssueOrderFormDocWithNumber".OrderMessages() + " " + text + "\r\n" + Messages.msgIssueOrderFormDocDate + " " + PersianDate.GetFormatetdDate(mobspReturnOrderFromDoc_Result.ordDate) + "\r\n" + Messages.msgIssueOrderFormDocInDate + " " + PersianDate.GetFormatetdDate(mobspReturnOrderFromDoc_Result.RegisterDatePersian) + "\r\n" + Messages.msgIssueOrderFormDocByUser + " " + mobspReturnOrderFromDoc_Result.UserName + "\r\n" + Messages.msgIssueOrderFormDocBeenIssued + "|" + mobspReturnOrderFromDoc_Result.OrderID;
					}
					else
					{
						data = "msgErrorNotFindOrderForDoc".OrderMessages();
					}
					message = Messages.MobMsgSuccessAction;
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspReturnOrderFromDoc_Result>> GetOrderFromDoc(int docId, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<MobspReturnOrderFromDoc_Result> data = null;
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
				if (new Common().GetToken(token) != null)
				{
					cRMSpEntities = new CRMSpEntities();
					data = Enumerable.ToList<MobspReturnOrderFromDoc_Result>((IEnumerable<MobspReturnOrderFromDoc_Result>)cRMSpEntities.MobspReturnOrderFromDoc(docId, num, result2));
					message = Messages.MobMsgSuccessAction;
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<List<MobspReturnOrderFromDoc_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<IssueOrderFromDocResultViewModel> IssueOrderFromDoc(IssueOrderFromDocViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangId);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		IssueOrderFromDocResultViewModel issueOrderFromDocResultViewModel = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : defLangId);
		baseInfo.SetCulture(num);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					cRMSpEntities = new CRMSpEntities();
					if (!VersionBuyer.Order)
					{
						return new ServiceResult<IssueOrderFromDocResultViewModel>
						{
							Message = Messages.VersionBuy,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					DateTime dateTime = default(DateTime);
					string text = "";
					if (string.IsNullOrWhiteSpace(model.OrderDate))
					{
						return new ServiceResult<IssueOrderFromDocResultViewModel>
						{
							Message = string.Format(Messages.msgErrorIsNotEnteredItem, "IssueOrderFromDocOrdDate".OrderLabels()),
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					model.OrderDate = model.OrderDate.Replace("/", "").Replace("-", "").Replace("_", "")
						.Replace(".", "")
						.Replace(",", "")
						.Replace("\\", "");
					try
					{
						if (!string.IsNullOrEmpty(model.OrderDate))
						{
							text = PersianDate.GetFormatetdDate(model.OrderDate.Replace("/", ""));
							switch (num)
							{
							case 1065:
								dateTime = DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
								model.OrderDate = dateTime.ToString("yyyyMMdd");
								break;
							case 1025:
								dateTime = DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
								model.OrderDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
								break;
							default:
								dateTime = DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
								model.OrderDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
								break;
							}
							model.OrderDateTime = dateTime;
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						return new ServiceResult<IssueOrderFromDocResultViewModel>
						{
							Message = string.Format(Messages.ErrorInFormat, "IssueOrderFromDocOrdDate".OrderLabels()),
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					MobspReturnOrderFromDoc_Result mobspReturnOrderFromDoc_Result = new MobspReturnOrderFromDoc_Result();
					string text2 = "";
					List<MobspReturnOrderFromDoc_Result> list = Enumerable.ToList<MobspReturnOrderFromDoc_Result>((IEnumerable<MobspReturnOrderFromDoc_Result>)cRMSpEntities.MobspReturnOrderFromDoc(model.DocId, num, defLangId));
					if (list != null && Enumerable.Any<MobspReturnOrderFromDoc_Result>((IEnumerable<MobspReturnOrderFromDoc_Result>)list))
					{
						mobspReturnOrderFromDoc_Result = Enumerable.LastOrDefault<MobspReturnOrderFromDoc_Result>((IEnumerable<MobspReturnOrderFromDoc_Result>)list);
						if (list.Count > 1)
						{
							foreach (MobspReturnOrderFromDoc_Result item in list)
							{
								text2 = text2 + item.ordNumber + ",";
							}
							if (!string.IsNullOrWhiteSpace(text2) && text2.EndsWith(","))
							{
								text2 = text2.TrimEnd(new char[1] { ',' });
							}
						}
					}
					else
					{
						mobspReturnOrderFromDoc_Result = null;
					}
					int? num2 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMSpEntities.MobspCheckDocHaveOrder(model.DocId));
					int result2 = 0;
					if (num2.HasValue)
					{
						int.TryParse(num2.GetValueOrDefault().ToString(), out result2);
						if (result2 == 0)
						{
							mobspReturnOrderFromDoc_Result = null;
						}
					}
					if (mobspReturnOrderFromDoc_Result != null && result2 == 1)
					{
						mobspReturnOrderFromDoc_Result.ordDate = (mobspReturnOrderFromDoc_Result.ordDateTime.HasValue ? mobspReturnOrderFromDoc_Result.ordDateTime.Value.ToString("yyyyMMdd") : mobspReturnOrderFromDoc_Result.ordDate);
						MobspReturnOrderFromDoc_Result mobspReturnOrderFromDoc_Result2 = mobspReturnOrderFromDoc_Result;
						_ = mobspReturnOrderFromDoc_Result.RegisterDate;
						mobspReturnOrderFromDoc_Result2.RegisterDatePersian = mobspReturnOrderFromDoc_Result.RegisterDate.ToString("yyyyMMdd");
						if (string.IsNullOrEmpty(text2))
						{
							text2 = mobspReturnOrderFromDoc_Result.ordNumber.ToString();
						}
						string message2 = Labels.Error + " !\r\n" + "msgIssueOrderFormDocWithNumber".OrderMessages() + " " + text2 + "\r\n" + Messages.msgIssueOrderFormDocDate + " " + PersianDate.GetFormatetdDate(mobspReturnOrderFromDoc_Result.ordDate) + "\r\n" + Messages.msgIssueOrderFormDocInDate + " " + PersianDate.GetFormatetdDate(mobspReturnOrderFromDoc_Result.RegisterDatePersian) + "\r\n" + Messages.msgIssueOrderFormDocByUser + " " + mobspReturnOrderFromDoc_Result.UserName + "\r\n" + Messages.msgIssueOrderFormDocBeenIssued + "|" + mobspReturnOrderFromDoc_Result.OrderID;
						return new ServiceResult<IssueOrderFromDocResultViewModel>
						{
							Message = message2,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(Financial.Get().Id.ToString());
					short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					string appType = Mobile.Classes.Configuration.AppType;
					List<MobspSelectLanguages_Result> list2 = Enumerable.ToList<MobspSelectLanguages_Result>((IEnumerable<MobspSelectLanguages_Result>)cRMEntities.MobspSelectLanguages());
					int userId = token2.userId;
					short value4 = short.Parse(Financial.Get().Id.ToString());
					List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
					foreach (MobspSelectLanguages_Result item2 in list2)
					{
						list3.Add(new CommonMultiLanguageViewModel
						{
							Value = model.OrderNote,
							LanguageId = item2.LanguageID
						});
					}
					if (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3))
					{
						model.OrderNote = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)).Value : null);
						model.OrderNote_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != defLangId))));
					}
					else
					{
						model.OrderNote = null;
						model.OrderNote_Lang = null;
					}
					if (model.OrderDefaultSettingId == 0)
					{
						model.OrderDefaultSettingId = null;
					}
					if (model.OrderSettlementTypeId == 0)
					{
						model.OrderSettlementTypeId = null;
					}
					ObjectParameter objectParameter = new ObjectParameter("InsertedOrderID", 0);
					ObjectParameter objectParameter2 = new ObjectParameter("InsertedOrderNumber", typeof(long));
					int? num3 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMSpEntities.MobspIssueOrderFromDoc(model.DocId, model.OrderDate, model.OrderDateTime, model.OrderOprId, model.OrderReferUserId, model.OrderPrintFormatID, model.OrderDefaultSettingId, model.OrderSettlementTypeId, model.OrderNote, model.OrderNote_Lang, model.OrderProjectId, model.DocItemList, userId, value3, value4, value, registerDatePersian, appType, defLangId, objectParameter, objectParameter2, model.CenterId));
					int result3 = 0;
					int.TryParse(num3.ToString(), out result3);
					int result4 = 0;
					if (objectParameter.Value != null)
					{
						int.TryParse(objectParameter.Value.ToString(), out result4);
					}
					long result5 = 0L;
					if (objectParameter2.Value != null)
					{
						long.TryParse(objectParameter2.Value.ToString(), out result5);
					}
					switch (result3)
					{
					case -1:
						issueOrderFromDocResultViewModel = null;
						message = string.Format("msgErrorIssueOrdFromDocHasOrd".OrderMessages(), result5.ToString());
						status = ServiceResultStatus.Success;
						break;
					case -2:
						issueOrderFromDocResultViewModel = null;
						message = string.Format(Messages.msgErrorIssueOrdFromDocHasBord, result5.ToString());
						status = ServiceResultStatus.Success;
						break;
					case -3:
						issueOrderFromDocResultViewModel = null;
						message = Messages.msgErrorIssueOrdFromDocNoItem;
						status = ServiceResultStatus.Success;
						break;
					case 1:
						if (result4 > 0)
						{
							string text3 = "";
							MobspReturnOrderFromDoc_Result mobspReturnOrderFromDoc_Result3 = new MobspReturnOrderFromDoc_Result();
							List<MobspReturnOrderFromDoc_Result> list4 = Enumerable.ToList<MobspReturnOrderFromDoc_Result>((IEnumerable<MobspReturnOrderFromDoc_Result>)cRMSpEntities.MobspReturnOrderFromDoc(model.DocId, num, defLangId));
							text2 = "";
							if (list4 != null && Enumerable.Any<MobspReturnOrderFromDoc_Result>((IEnumerable<MobspReturnOrderFromDoc_Result>)list4))
							{
								mobspReturnOrderFromDoc_Result3 = Enumerable.LastOrDefault<MobspReturnOrderFromDoc_Result>((IEnumerable<MobspReturnOrderFromDoc_Result>)list4);
								if (list4.Count > 1)
								{
									foreach (MobspReturnOrderFromDoc_Result item3 in list4)
									{
										text2 = text2 + item3.ordNumber + ",";
										text3 = text3 + item3.OrderID + ",";
										CRMEntities cRMEntities2 = cRMEntities;
										int? orderId = item3.OrderID;
										bool? calcAutoScoreInIssue = true;
										bool? calcAutoScoreInVerify = false;
										cRMEntities2.MobScorespInsertAndCalcOrderScores(null, orderId, null, null, null, calcAutoScoreInIssue, calcAutoScoreInVerify, DateTime.Now, userId, value2, value3, value, registerDatePersian, appType, result, defLangId, null, true, model.CenterId, false);
									}
									if (!string.IsNullOrEmpty(text2) && text2.EndsWith(","))
									{
										text2 = text2.TrimEnd(new char[1] { ',' });
									}
									if (!string.IsNullOrEmpty(text3) && text3.EndsWith(","))
									{
										text3 = text3.TrimEnd(new char[1] { ',' });
									}
								}
							}
							else
							{
								mobspReturnOrderFromDoc_Result3 = null;
							}
							if (mobspReturnOrderFromDoc_Result3 != null)
							{
								if (string.IsNullOrWhiteSpace(text2))
								{
									text2 = mobspReturnOrderFromDoc_Result3.ordNumber.ToString();
								}
								issueOrderFromDocResultViewModel = new IssueOrderFromDocResultViewModel();
								issueOrderFromDocResultViewModel.Message = "1|" + result4 + "|" + text2.ToString();
								issueOrderFromDocResultViewModel.OrderList = list4;
								issueOrderFromDocResultViewModel.DocItemList = Enumerable.ToList<MobspSelectDocItems_Result>((IEnumerable<MobspSelectDocItems_Result>)cRMSpEntities.MobspSelectDocItems(model.DocId, result, defLangId));
							}
							else
							{
								issueOrderFromDocResultViewModel = new IssueOrderFromDocResultViewModel();
								issueOrderFromDocResultViewModel.Message = "1|" + result4 + "|" + result5;
								issueOrderFromDocResultViewModel.OrderList = list4;
								issueOrderFromDocResultViewModel.DocItemList = Enumerable.ToList<MobspSelectDocItems_Result>((IEnumerable<MobspSelectDocItems_Result>)cRMSpEntities.MobspSelectDocItems(model.DocId, result, defLangId));
								CRMEntities cRMEntities3 = cRMEntities;
								int? orderId2 = result4;
								bool? calcAutoScoreInVerify = true;
								bool? calcAutoScoreInIssue = false;
								cRMEntities3.MobScorespInsertAndCalcOrderScores(null, orderId2, null, null, null, calcAutoScoreInVerify, calcAutoScoreInIssue, DateTime.Now, userId, value2, value3, value, registerDatePersian, appType, result, defLangId, null, true, model.CenterId, false);
							}
							message = Messages.MobMsgSuccessAction;
							status = ServiceResultStatus.Success;
						}
						else
						{
							issueOrderFromDocResultViewModel = null;
							message = Messages.msgErrorRunFunction;
							status = ServiceResultStatus.Success;
						}
						break;
					default:
						issueOrderFromDocResultViewModel = null;
						message = Messages.msgErrorRunFunction;
						status = ServiceResultStatus.Success;
						break;
					}
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					issueOrderFromDocResultViewModel = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				issueOrderFromDocResultViewModel = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e2)
		{
			message = Messages.MobMsgErrorDoneOperation;
			issueOrderFromDocResultViewModel = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		finally
		{
			cRMEntities?.Dispose();
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<IssueOrderFromDocResultViewModel>
		{
			Message = message,
			Data = issueOrderFromDocResultViewModel,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectDocItemsWithPordIPrice_Result>> GetDocItemsWithPordIPrice(int docId, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<MobspSelectDocItemsWithPordIPrice_Result> data = null;
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
				if (new Common().GetToken(token) != null)
				{
					cRMSpEntities = new CRMSpEntities();
					data = Enumerable.ToList<MobspSelectDocItemsWithPordIPrice_Result>((IEnumerable<MobspSelectDocItemsWithPordIPrice_Result>)cRMSpEntities.MobspSelectDocItemsWithPordIPrice(docId, num, result2));
					message = Messages.MobMsgSuccessAction;
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<List<MobspSelectDocItemsWithPordIPrice_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<CompanyDocListAndIntMsgViewModel> GetCompanyDocList(int companyId, int? pageNumber = 1, int? pageSize = 10, int? cId = null, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		CompanyDocListAndIntMsgViewModel companyDocListAndIntMsgViewModel = null;
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
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					if (base.Request.Headers.TryGetValues("imeiCode", out var _) && !Common.CheckUserImeiCode(token2.userId, Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("imeiCode")), Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("appName"))))
					{
						return new ServiceResult<CompanyDocListAndIntMsgViewModel>
						{
							Message = Messages.MobMsgUserImeiNotPreDefined,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					companyDocListAndIntMsgViewModel = new CompanyDocListAndIntMsgViewModel();
					companyDocListAndIntMsgViewModel.Docs = new List<MobspSelectCompanyDocs_Result>();
					companyDocListAndIntMsgViewModel.InternalMessages = new List<MobspIntMsgGetByTypeAndAttachRecId_Result>();
					string manualIssuing = Labels.ManualIssuing;
					string systemIssuing = Labels.SystemIssuing;
					cRMEntities = new CRMEntities();
					cRMSpEntities = new CRMSpEntities();
					companyDocListAndIntMsgViewModel.Docs = Enumerable.ToList<MobspSelectCompanyDocs_Result>((IEnumerable<MobspSelectCompanyDocs_Result>)cRMSpEntities.MobspSelectCompanyDocs(token2.userId, 1, companyId, manualIssuing, systemIssuing, pageNumber, pageSize, result, result2, cId));
					if (!VersionBuyer.WareHouse)
					{
						companyDocListAndIntMsgViewModel.Docs = Enumerable.ToList<MobspSelectCompanyDocs_Result>(Enumerable.Take<MobspSelectCompanyDocs_Result>((IEnumerable<MobspSelectCompanyDocs_Result>)companyDocListAndIntMsgViewModel.Docs, 2));
					}
					foreach (MobspSelectCompanyDocs_Result doc in companyDocListAndIntMsgViewModel.Docs)
					{
						List<MobspIntMsgGetByTypeAndAttachRecId_Result> list = Enumerable.ToList<MobspIntMsgGetByTypeAndAttachRecId_Result>((IEnumerable<MobspIntMsgGetByTypeAndAttachRecId_Result>)cRMEntities.MobspIntMsgGetByTypeAndAttachRecId(token2.userId, 20, doc.DocID, result, result2));
						if (Enumerable.Any<MobspIntMsgGetByTypeAndAttachRecId_Result>((IEnumerable<MobspIntMsgGetByTypeAndAttachRecId_Result>)list))
						{
							companyDocListAndIntMsgViewModel.InternalMessages.AddRange(list);
						}
					}
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					companyDocListAndIntMsgViewModel = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				companyDocListAndIntMsgViewModel = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			companyDocListAndIntMsgViewModel = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
			cRMEntities?.Dispose();
		}
		return new ServiceResult<CompanyDocListAndIntMsgViewModel>
		{
			Message = message,
			Data = companyDocListAndIntMsgViewModel,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<CompanyDraftListAndIntMsgViewModel> GetCompanyDraftList(int companyId, int? pageNumber = 1, int? pageSize = 10, int? cId = null, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		CompanyDraftListAndIntMsgViewModel companyDraftListAndIntMsgViewModel = null;
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
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					if (base.Request.Headers.TryGetValues("imeiCode", out var _) && !Common.CheckUserImeiCode(token2.userId, Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("imeiCode")), Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("appName"))))
					{
						return new ServiceResult<CompanyDraftListAndIntMsgViewModel>
						{
							Message = Messages.MobMsgUserImeiNotPreDefined,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					companyDraftListAndIntMsgViewModel = new CompanyDraftListAndIntMsgViewModel();
					companyDraftListAndIntMsgViewModel.Drafts = new List<MobspSelectCompanyDocs_Result>();
					companyDraftListAndIntMsgViewModel.InternalMessages = new List<MobspIntMsgGetByTypeAndAttachRecId_Result>();
					string manualIssuing = Labels.ManualIssuing;
					string systemIssuing = Labels.SystemIssuing;
					cRMEntities = new CRMEntities();
					cRMSpEntities = new CRMSpEntities();
					companyDraftListAndIntMsgViewModel.Drafts = Enumerable.ToList<MobspSelectCompanyDocs_Result>((IEnumerable<MobspSelectCompanyDocs_Result>)cRMSpEntities.MobspSelectCompanyDocs(token2.userId, 2, companyId, manualIssuing, systemIssuing, pageNumber, pageSize, result, result2, cId));
					if (!VersionBuyer.WareHouse)
					{
						companyDraftListAndIntMsgViewModel.Drafts = Enumerable.ToList<MobspSelectCompanyDocs_Result>(Enumerable.Take<MobspSelectCompanyDocs_Result>((IEnumerable<MobspSelectCompanyDocs_Result>)companyDraftListAndIntMsgViewModel.Drafts, 2));
					}
					foreach (MobspSelectCompanyDocs_Result draft in companyDraftListAndIntMsgViewModel.Drafts)
					{
						List<MobspIntMsgGetByTypeAndAttachRecId_Result> list = Enumerable.ToList<MobspIntMsgGetByTypeAndAttachRecId_Result>((IEnumerable<MobspIntMsgGetByTypeAndAttachRecId_Result>)cRMEntities.MobspIntMsgGetByTypeAndAttachRecId(token2.userId, 20, draft.DocID, result, result2));
						if (Enumerable.Any<MobspIntMsgGetByTypeAndAttachRecId_Result>((IEnumerable<MobspIntMsgGetByTypeAndAttachRecId_Result>)list))
						{
							companyDraftListAndIntMsgViewModel.InternalMessages.AddRange(list);
						}
					}
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					companyDraftListAndIntMsgViewModel = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				companyDraftListAndIntMsgViewModel = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			companyDraftListAndIntMsgViewModel = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
			cRMEntities?.Dispose();
		}
		return new ServiceResult<CompanyDraftListAndIntMsgViewModel>
		{
			Message = message,
			Data = companyDraftListAndIntMsgViewModel,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> DocIsFixed(int docId, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		string data = null;
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
				if (new Common().GetToken(token) != null)
				{
					cRMSpEntities = new CRMSpEntities();
					if (docId <= 0)
					{
						return new ServiceResult<string>
						{
							Message = Messages.MobMsgErorrDocNotFound,
							Data = null,
							Status = ServiceResultStatus.Error
						};
					}
					MobspSelectDocById_Result mobspSelectDocById_Result = Enumerable.FirstOrDefault<MobspSelectDocById_Result>((IEnumerable<MobspSelectDocById_Result>)cRMSpEntities.MobspSelectDocById(docId, num, result2));
					if (mobspSelectDocById_Result != null)
					{
						int result3 = 0;
						int.TryParse(mobspSelectDocById_Result.OprType.ToString(), out result3);
						bool flag = false;
						switch (result3)
						{
						case 1:
							flag = UserLogin.IsUserAccess("frmDoc", "actIsFixed", UserLogin.CurrentUser, cId);
							break;
						case 2:
							flag = UserLogin.IsUserAccess("frmDraft", "actIsFixed", UserLogin.CurrentUser, cId);
							break;
						case 3:
							flag = UserLogin.IsUserAccess("frmWareHouseMovement", "actIsFixed", UserLogin.CurrentUser, cId);
							break;
						}
						if (!flag)
						{
							return new ServiceResult<string>
							{
								Message = Messages.MobMsgErrorAccessLimited,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
						}
						cRMSpEntities.MobspDocIsFixed(docId);
						message = Messages.MobMsgSuccessAction;
						data = null;
						status = ServiceResultStatus.Success;
					}
					else
					{
						message = Messages.MobMsgErorrDocNotFound;
						data = null;
						status = ServiceResultStatus.Fail;
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
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> RegisterBarcode(int docId, int whId, string prdCode, string prdSerial, int docItemId = 0, int? ln = null, int? cId = null)
	{
		int result = 1056;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		string data = null;
		string message = null;
		ServiceResultStatus status = ServiceResultStatus.Fail;
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
				}
				int userId = token2.userId;
				DateTime now = DateTime.Now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short value = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Mobile.Classes.Configuration.AppType;
				short value2 = short.Parse(Financial.Get().Id.ToString());
				if (docId <= 0)
				{
					return new ServiceResult<string>
					{
						Message = Messages.MobMsgErorrDocNotFound,
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				ObjectParameter objectParameter = new ObjectParameter("Result", typeof(int));
				cRMSpEntities.MobspInsertDocItemWithBarcode(docId, prdCode, prdSerial, whId, userId, value2, value, now, registerDatePersian, appType, result2, docItemId, objectParameter, cId);
				int result3 = 0;
				if (objectParameter != null && objectParameter.Value != null)
				{
					int.TryParse(objectParameter.Value.ToString(), out result3);
				}
				if (result3 > 0)
				{
					message = Messages.MobMsgSuccessAction;
					data = null;
					status = ServiceResultStatus.Success;
				}
				else
				{
					switch (result3)
					{
					case 0:
						message = Messages.msgErrorRunProcedure;
						status = ServiceResultStatus.Fail;
						data = null;
						break;
					case -1:
						message = Messages.msgErrorPrdAndSerialIsDup;
						status = ServiceResultStatus.Fail;
						data = null;
						break;
					case -2:
						message = Messages.msgErrorSerialNotFoundAndInsert;
						status = ServiceResultStatus.Fail;
						data = null;
						break;
					case -3:
						message = Messages.msgErrorNoPrdWithCode;
						status = ServiceResultStatus.Fail;
						data = null;
						break;
					case -4:
						message = Messages.msgErrorSerialIsOnDraft;
						status = ServiceResultStatus.Fail;
						data = null;
						break;
					case -5:
						message = Messages.DraftQuantityRemainLimitExceeded;
						status = ServiceResultStatus.Fail;
						data = null;
						break;
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
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspDocItemSerialSearch_Result>> SerialSearch(string val = "", string objJson = "", int? lastRowNumber = 0, int? pageSize = 10, int? mode = 0, int? ln = null, int? cId = null)
	{
		int result = 1056;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<MobspDocItemSerialSearch_Result> data = null;
		string message = null;
		ServiceResultStatus status = ServiceResultStatus.Fail;
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
				}
				if (val == null)
				{
					val = "";
				}
				new ObjectParameter("result", 0);
				data = Enumerable.ToList<MobspDocItemSerialSearch_Result>((IEnumerable<MobspDocItemSerialSearch_Result>)cRMSpEntities.MobspDocItemSerialSearch(val, token2.userId, pageSize, result, result2, cId, lastRowNumber, mode, objJson));
				message = Messages.MobMsgSuccessAction;
				status = ServiceResultStatus.Success;
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
		return new ServiceResult<List<MobspDocItemSerialSearch_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}
}
