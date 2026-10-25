using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using CRM.General.Calendar;
using CRM.General.Text;
using CRM.General.Utilities;
using CRM.Resources;
using Elmah;
using GSD.Globalization;
using Mobile.Cache.Setting;
using Mobile.Classes;
using Mobile.Classes.Helper;
using Mobile.DataType;
using Mobile.Models;
using Newtonsoft.Json;

namespace Mobile.Controllers;

public class FODyFormsController : ApiController
{
	[HttpPost]
	[FoMobileAuthorize]
	public ServiceResult<List<FOMobspDySelectFormsMenuWithSysPartId_Result>> SelectFormsMenuWithSysPartId(int sysPartId, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<FOMobspDySelectFormsMenuWithSysPartId_Result> data = null;
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
				if (new FoCommon().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					data = Enumerable.ToList<FOMobspDySelectFormsMenuWithSysPartId_Result>((IEnumerable<FOMobspDySelectFormsMenuWithSysPartId_Result>)cRMEntities.FOMobspDySelectFormsMenuWithSysPartId(sysPartId, result, result2, cId));
					message = Messages.MobMsgErrorCompanyNotFound;
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
		return new ServiceResult<List<FOMobspDySelectFormsMenuWithSysPartId_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[FoMobileAuthorize]
	public ServiceResult<FOMobspDySelectForms_Result> SelectForms(int formId, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		FOMobspDySelectForms_Result fOMobspDySelectForms_Result = null;
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
				if (new FoCommon().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					fOMobspDySelectForms_Result = Enumerable.FirstOrDefault<FOMobspDySelectForms_Result>((IEnumerable<FOMobspDySelectForms_Result>)cRMEntities.FOMobspDySelectForms(formId, 0, result, result2, cId));
					if (fOMobspDySelectForms_Result != null)
					{
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					else
					{
						message = Messages.MobFoMsgNoResultFound;
						status = ServiceResultStatus.Error;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					fOMobspDySelectForms_Result = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				fOMobspDySelectForms_Result = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			fOMobspDySelectForms_Result = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<FOMobspDySelectForms_Result>
		{
			Message = message,
			Data = fOMobspDySelectForms_Result,
			Status = status
		};
	}

	[HttpPost]
	[FoMobileAuthorize]
	public ServiceResult<List<FOMobspDySelectFormFieldMasterValuesTree_Result>> SelectFormFieldMasterValuesTree(FoGetFormFieldMasterValuesTree model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<FOMobspDySelectFormFieldMasterValuesTree_Result> list = null;
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
				FoToken token2 = new FoCommon().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					list = Enumerable.ToList<FOMobspDySelectFormFieldMasterValuesTree_Result>((IEnumerable<FOMobspDySelectFormFieldMasterValuesTree_Result>)cRMEntities.FOMobspDySelectFormFieldMasterValuesTree(model.FDateTime, model.TDateTime, model.FormId, token2.CompanyId, model.CompanyPersonId, model.ProjectId, model.ConversationId, model.MasterObjectId, model.DetailObjectId, model.SubDetailObjectId, -20, result, result2, model.CenterId));
					if (list != null)
					{
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					else
					{
						message = Messages.MobFoMsgNoResultFound;
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
		return new ServiceResult<List<FOMobspDySelectFormFieldMasterValuesTree_Result>>
		{
			Message = message,
			Data = list,
			Status = status
		};
	}

	[HttpPost]
	[FoMobileAuthorize]
	public ServiceResult<FoLoadFullFormResult> LoadFullForm(int formId, int? ln = 1065, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		FoLoadFullFormResult foLoadFullFormResult = null;
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
				if (new FoCommon().GetToken(token) != null)
				{
					int value = -20;
					cRMEntities = new CRMEntities();
					foLoadFullFormResult = new FoLoadFullFormResult();
					foLoadFullFormResult.Forms = Enumerable.ToList<FOMobspDySelectFormAndSubForms_Result>((IEnumerable<FOMobspDySelectFormAndSubForms_Result>)cRMEntities.FOMobspDySelectFormAndSubForms(formId, value, result, result2, cId));
					foLoadFullFormResult.Fields = Enumerable.ToList<FOMobspDySelectFormFieldsByParentFormId_Result>((IEnumerable<FOMobspDySelectFormFieldsByParentFormId_Result>)cRMEntities.FOMobspDySelectFormFieldsByParentFormId(formId, result, result2));
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					foLoadFullFormResult = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				foLoadFullFormResult = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			foLoadFullFormResult = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<FoLoadFullFormResult>
		{
			Message = message,
			Data = foLoadFullFormResult,
			Status = status
		};
	}

	[HttpPost]
	[FoMobileAuthorize]
	public ServiceResult<List<FOMobspDySelectFormFieldValuesByMasterValueId_Result>> SelectFormFieldValuesByMasterValueId(int valId, int? ln = 1065)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<FOMobspDySelectFormFieldValuesByMasterValueId_Result> list = null;
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
				if (new FoCommon().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					list = Enumerable.ToList<FOMobspDySelectFormFieldValuesByMasterValueId_Result>((IEnumerable<FOMobspDySelectFormFieldValuesByMasterValueId_Result>)cRMEntities.FOMobspDySelectFormFieldValuesByMasterValueId(valId, result, result2));
					if (list != null)
					{
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					else
					{
						message = Messages.MobFoMsgNoResultFound;
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
		return new ServiceResult<List<FOMobspDySelectFormFieldValuesByMasterValueId_Result>>
		{
			Message = message,
			Data = list,
			Status = status
		};
	}

	[HttpPost]
	[FoMobileAuthorize]
	public ServiceResult<List<FOMobspDySelectFilesDirectory_Result>> SelectFilesDirectory(FoSelectFilesDirectoryViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<FOMobspDySelectFilesDirectory_Result> list = null;
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
				FoToken token2 = new FoCommon().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					list = Enumerable.ToList<FOMobspDySelectFilesDirectory_Result>((IEnumerable<FOMobspDySelectFilesDirectory_Result>)cRMEntities.FOMobspDySelectFilesDirectory(token2.CompanyId.ToString(), model.CompanyPersonId.GetValueOrDefault().ToString(), model.ProjectId.GetValueOrDefault().ToString(), "60", model.MasterValueId.GetValueOrDefault().ToString(), model.FormId.GetValueOrDefault().ToString(), "", num, result2, model.CenterId));
					if (list != null)
					{
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					else
					{
						message = Messages.MobFoMsgNoResultFound;
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
		return new ServiceResult<List<FOMobspDySelectFilesDirectory_Result>>
		{
			Message = message,
			Data = list,
			Status = status
		};
	}

	[HttpPost]
	[FoMobileAuthorize]
	public ServiceResult<string> InsertFormFieldValues(FoSubmitFormFieldValuesViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangId);
		CRMEntities cRMEntities = null;
		string data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int currLangId = ((result > 0) ? result : defLangId);
		baseInfo.SetCulture(currLangId);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				FoToken token2 = new FoCommon().GetToken(token);
				if (token2 != null)
				{
					int value = -20;
					DateTime now = DateTime.Now;
					DateTime value2 = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value3 = short.Parse(now.ToString("MM", new PersianCulture()));
					string appType = Mobile.Classes.Configuration.AppType;
					short value4 = short.Parse(Financial.Get().Id.ToString());
					int companyId = token2.CompanyId;
					cRMEntities = new CRMEntities();
					List<FOMobspSelectLanguages_Result> list = Enumerable.ToList<FOMobspSelectLanguages_Result>((IEnumerable<FOMobspSelectLanguages_Result>)cRMEntities.FOMobspSelectLanguages());
					List<FOMobspDySelectFormFieldsByParentFormId_Result> list2 = new List<FOMobspDySelectFormFieldsByParentFormId_Result>();
					List<FOMobspDySelectFormAndSubForms_Result> list3 = new List<FOMobspDySelectFormAndSubForms_Result>();
					FOMobspDySelectFormAndSubForms_Result mainForm = new FOMobspDySelectFormAndSubForms_Result();
					list3 = Enumerable.ToList<FOMobspDySelectFormAndSubForms_Result>((IEnumerable<FOMobspDySelectFormAndSubForms_Result>)cRMEntities.FOMobspDySelectFormAndSubForms(model.FormId, value, currLangId, defLangId, model.CenterId));
					if (list3 != null && Enumerable.Any<FOMobspDySelectFormAndSubForms_Result>((IEnumerable<FOMobspDySelectFormAndSubForms_Result>)list3))
					{
						mainForm = Enumerable.FirstOrDefault<FOMobspDySelectFormAndSubForms_Result>((IEnumerable<FOMobspDySelectFormAndSubForms_Result>)list3, (Func<FOMobspDySelectFormAndSubForms_Result, bool>)((FOMobspDySelectFormAndSubForms_Result m) => m.FormId == model.FormId));
						if (mainForm != null)
						{
							list2 = Enumerable.ToList<FOMobspDySelectFormFieldsByParentFormId_Result>((IEnumerable<FOMobspDySelectFormFieldsByParentFormId_Result>)cRMEntities.FOMobspDySelectFormFieldsByParentFormId(model.FormId, currLangId, defLangId));
						}
					}
					if (!mainForm.FOCanInsertMulti.GetValueOrDefault() && Enumerable.FirstOrDefault<FOMobspDySelectFormsWithSysPartId_Result>(Enumerable.Where<FOMobspDySelectFormsWithSysPartId_Result>((IEnumerable<FOMobspDySelectFormsWithSysPartId_Result>)cRMEntities.FOMobspDySelectFormsWithSysPartId(model.SysPartId, companyId, value, result, defLangId, model.CompanyPersonId, model.CenterId), (Func<FOMobspDySelectFormsWithSysPartId_Result, bool>)((FOMobspDySelectFormsWithSysPartId_Result c) => c.FormId == mainForm.FormId))).MasterValueId.HasValue)
					{
						ServiceResult<string> result2 = new ServiceResult<string>
						{
							Message = Messages.FOMobMsgErrorFOCanNotInsertMulti,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
						cRMEntities?.Dispose();
						return result2;
					}
					int result3 = 0;
					int.TryParse(Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.FOMobspDyInsertFormFieldMasterValues(model.FormId, companyId, model.CompanyPersonId, model.ProjectId, model.ConversationId, model.MasterObjectId, model.DetailObjectId, model.SubDetailObjectId, value, value2, registerDatePersian, value4, value3, appType, defLangId, model.CenterId)).ToString(), out result3);
					if (result3 > 0)
					{
						cRMEntities.FOMobspDyInsertUpdateFormFieldMasterValueDetails(1, result3, model.FormId, value, now, registerDatePersian, value4, value3, appType, defLangId);
					}
					foreach (FoSubmitFormValueViewModel obj in JsonConvert.DeserializeObject<List<FoSubmitFormValueViewModel>>(model.Values))
					{
						FOMobspDySelectFormFieldsByParentFormId_Result fOMobspDySelectFormFieldsByParentFormId_Result = Enumerable.FirstOrDefault<FOMobspDySelectFormFieldsByParentFormId_Result>((IEnumerable<FOMobspDySelectFormFieldsByParentFormId_Result>)list2, (Func<FOMobspDySelectFormFieldsByParentFormId_Result, bool>)((FOMobspDySelectFormFieldsByParentFormId_Result m) => m.FormFieldId == obj.FieldId));
						if (fOMobspDySelectFormFieldsByParentFormId_Result != null && !string.IsNullOrEmpty(obj.Value) && fOMobspDySelectFormFieldsByParentFormId_Result.FieldTypeId.GetValueOrDefault() == 4)
						{
							try
							{
								obj.Value = obj.Value.Replace("/", "").Replace("-", "").Replace("\\", "")
									.Replace(" ", "")
									.Replace("_", "");
								obj.Value = CRM.General.Text.String.CleanString(obj.Value, allTrue: true);
								string formatetdDate = PersianDate.GetFormatetdDate(obj.Value.Replace("/", ""));
								if (currLangId == 1065)
								{
									DateTime dateTime = DateTime.Parse(formatetdDate + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
									obj.Value = dateTime.ToString("yyyyMMdd");
								}
								else if (currLangId == 1025)
								{
									DateTime dateTime2 = DateTime.Parse(formatetdDate + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
									obj.Value = dateTime2.ToString("yyyyMMdd", new PersianCulture());
								}
								else
								{
									DateTime dateTime3 = DateTime.Parse(formatetdDate + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
									obj.Value = dateTime3.ToString("yyyyMMdd", new PersianCulture());
								}
							}
							catch (Exception e)
							{
								ErrorSignal.FromCurrentContext().Raise(e);
							}
						}
						List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
						foreach (FOMobspSelectLanguages_Result item in Enumerable.ToList<FOMobspSelectLanguages_Result>(Enumerable.Where<FOMobspSelectLanguages_Result>((IEnumerable<FOMobspSelectLanguages_Result>)list, (Func<FOMobspSelectLanguages_Result, bool>)((FOMobspSelectLanguages_Result c) => c.LanguageID != currLangId))))
						{
							string text = "";
							if (fOMobspDySelectFormFieldsByParentFormId_Result != null)
							{
								text = obj.Value;
								list4.Add(new CommonMultiLanguageViewModel
								{
									Value = CRM.General.Text.String.CleanString(text, allTrue: true),
									LanguageId = item.LanguageID
								});
							}
						}
						list4.Add(new CommonMultiLanguageViewModel
						{
							Value = obj.Value,
							LanguageId = currLangId
						});
						string text2 = "";
						foreach (CommonMultiLanguageViewModel item2 in list4)
						{
							if (item2.LanguageId != defLangId)
							{
								text2 = text2 + "LangId=" + item2.LanguageId + "|V|Val=" + item2.Value + "|V||^V^|";
							}
						}
						cRMEntities.FOMobspDyInsertFormFieldValues(result3, obj.FormId, companyId: companyId, companyPersonId: model.CompanyPersonId, fieldId: obj.FieldId, projectId: model.ProjectId, conversationId: model.ConversationId, masterObjectId: model.MasterObjectId, detailObjectId: model.DetailObjectId, subDetailObjectId: model.SubDetailObjectId, value: (Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)).Value : null, valueLang: text2, userId: value, registerDate: value2, registerDatePersian: registerDatePersian, year1: value4, month1: value3, appType: appType, languageID: defLangId);
					}
					if (mainForm != null && !string.IsNullOrEmpty(mainForm.CheckerUsersId))
					{
						string checkerUsersId = mainForm.CheckerUsersId;
						short value5 = short.Parse(now.ToString("yyyy", new PersianCulture()));
						string registerTime = now.ToString("HH:mm:ss");
						int value6 = 55;
						string text3 = ((!string.IsNullOrEmpty(mainForm.FormName)) ? mainForm.FormName : "");
						string text4 = "";
						foreach (FOMobspSelectLanguages_Result item3 in list)
						{
							string text5 = "";
							string text6 = "";
							text5 = MyResource.GetResourceString("FOFormsCheckRequestSubject", item3.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
							text5 = text5 + " (" + FoDyForm.GetFromName(mainForm.FormId, defLangId, item3.LanguageID, model.CenterId) + ")";
							text6 = MyResource.GetResourceString("DyFrmReqCheckByName", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ":" + text3;
							text6 = text6 + "<BR><BR>" + MyResource.GetResourceString("FOFormsCheckRequestDbClickOnOtherInfo", item3.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
							text4 = text4 + "MsgSubj=" + text5 + "|@#@|MsgBody=" + text6 + "|@#@|LangId=" + item3.LanguageID + "|@#@||^#^|";
						}
						try
						{
							Enumerable.FirstOrDefault<string>((IEnumerable<string>)cRMEntities.FOMobspDyInternalMessageSendToCheckerUsers(result3, text4, value6, checkerUsersId, value, value2, registerDatePersian, registerTime, text3, value5, value3, appType, defLangId));
							PushNotif.NewIntMsgNotify(withthread: true, model.CenterId);
						}
						catch (Exception e2)
						{
							ErrorSignal.FromCurrentContext().Raise(e2);
						}
					}
					message = Messages.MobMsgSuccessAction;
					data = result3.ToString();
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
		catch (Exception e3)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e3);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[FoMobileAuthorize]
	public ServiceResult<string> UpdateFormFieldValues(FoSubmitFormFieldValuesViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangId);
		CRMEntities cRMEntities = null;
		string data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int currLangId = ((result > 0) ? result : defLangId);
		baseInfo.SetCulture(currLangId);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				FoToken token2 = new FoCommon().GetToken(token);
				if (token2 != null)
				{
					int value = -20;
					DateTime now = DateTime.Now;
					DateTime value2 = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value3 = short.Parse(now.ToString("MM", new PersianCulture()));
					string appType = Mobile.Classes.Configuration.AppType;
					short value4 = short.Parse(Financial.Get().Id.ToString());
					int companyId = token2.CompanyId;
					cRMEntities = new CRMEntities();
					List<FOMobspSelectLanguages_Result> list = Enumerable.ToList<FOMobspSelectLanguages_Result>((IEnumerable<FOMobspSelectLanguages_Result>)cRMEntities.FOMobspSelectLanguages());
					if (model.MasterValueId > 0)
					{
						string msg = "";
						if (FoDyForm.IsChecked(model.MasterValueId.GetValueOrDefault(), ref msg))
						{
							ServiceResult<string> result2 = new ServiceResult<string>
							{
								Message = msg,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
							cRMEntities?.Dispose();
							return result2;
						}
					}
					List<FOMobspDySelectFormFieldsByParentFormId_Result> list2 = new List<FOMobspDySelectFormFieldsByParentFormId_Result>();
					List<FOMobspDySelectFormAndSubForms_Result> list3 = new List<FOMobspDySelectFormAndSubForms_Result>();
					FOMobspDySelectFormAndSubForms_Result fOMobspDySelectFormAndSubForms_Result = new FOMobspDySelectFormAndSubForms_Result();
					list3 = Enumerable.ToList<FOMobspDySelectFormAndSubForms_Result>((IEnumerable<FOMobspDySelectFormAndSubForms_Result>)cRMEntities.FOMobspDySelectFormAndSubForms(model.FormId, value, currLangId, defLangId, model.CenterId));
					if (list3 != null && Enumerable.Any<FOMobspDySelectFormAndSubForms_Result>((IEnumerable<FOMobspDySelectFormAndSubForms_Result>)list3))
					{
						fOMobspDySelectFormAndSubForms_Result = Enumerable.FirstOrDefault<FOMobspDySelectFormAndSubForms_Result>((IEnumerable<FOMobspDySelectFormAndSubForms_Result>)list3, (Func<FOMobspDySelectFormAndSubForms_Result, bool>)((FOMobspDySelectFormAndSubForms_Result m) => m.FormId == model.FormId));
						if (fOMobspDySelectFormAndSubForms_Result != null)
						{
							list2 = Enumerable.ToList<FOMobspDySelectFormFieldsByParentFormId_Result>((IEnumerable<FOMobspDySelectFormFieldsByParentFormId_Result>)cRMEntities.FOMobspDySelectFormFieldsByParentFormId(model.FormId, currLangId, defLangId));
						}
					}
					int num = 0;
					num = model.MasterValueId.GetValueOrDefault();
					cRMEntities.FOMobspDyUpdateFormFieldMasterValues(model.MasterValueId, value, value2, registerDatePersian, value4, value3, appType);
					cRMEntities.FOMobspDyInsertUpdateFormFieldMasterValueDetails(2, model.MasterValueId, model.FormId, value, now, registerDatePersian, value4, value3, appType, defLangId);
					List<FOMobspDySelectFormFieldValuesByMasterValueId_Result> list4 = Enumerable.ToList<FOMobspDySelectFormFieldValuesByMasterValueId_Result>((IEnumerable<FOMobspDySelectFormFieldValuesByMasterValueId_Result>)cRMEntities.FOMobspDySelectFormFieldValuesByMasterValueId(num, currLangId, defLangId));
					foreach (FoSubmitFormValueViewModel obj in JsonConvert.DeserializeObject<List<FoSubmitFormValueViewModel>>(model.Values))
					{
						FOMobspDySelectFormFieldsByParentFormId_Result fld = Enumerable.FirstOrDefault<FOMobspDySelectFormFieldsByParentFormId_Result>((IEnumerable<FOMobspDySelectFormFieldsByParentFormId_Result>)list2, (Func<FOMobspDySelectFormFieldsByParentFormId_Result, bool>)((FOMobspDySelectFormFieldsByParentFormId_Result m) => m.FormFieldId == obj.FieldId));
						if (fld != null && !string.IsNullOrEmpty(obj.Value) && fld.FieldTypeId.GetValueOrDefault() == 4)
						{
							obj.Value = obj.Value.Replace("/", "").Replace("-", "").Replace("\\", "")
								.Replace(" ", "")
								.Replace("_", "");
							obj.Value = CRM.General.Text.String.CleanString(obj.Value, allTrue: true);
							string formatetdDate = PersianDate.GetFormatetdDate(obj.Value.Replace("/", ""));
							if (currLangId == 1065)
							{
								DateTime dateTime = DateTime.Parse(formatetdDate + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
								obj.Value = dateTime.ToString("yyyyMMdd");
							}
							else if (currLangId == 1025)
							{
								DateTime dateTime2 = DateTime.Parse(formatetdDate + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
								obj.Value = dateTime2.ToString("yyyyMMdd", new PersianCulture());
							}
							else
							{
								DateTime dateTime3 = DateTime.Parse(formatetdDate + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
								obj.Value = dateTime3.ToString("yyyyMMdd", new PersianCulture());
							}
						}
						List<CommonMultiLanguageViewModel> list5 = new List<CommonMultiLanguageViewModel>();
						foreach (FOMobspSelectLanguages_Result item in Enumerable.ToList<FOMobspSelectLanguages_Result>(Enumerable.Where<FOMobspSelectLanguages_Result>((IEnumerable<FOMobspSelectLanguages_Result>)list, (Func<FOMobspSelectLanguages_Result, bool>)((FOMobspSelectLanguages_Result c) => c.LanguageID != currLangId))))
						{
							string text = "";
							if (fld != null)
							{
								text = obj.Value;
								list5.Add(new CommonMultiLanguageViewModel
								{
									Value = CRM.General.Text.String.CleanString(text, allTrue: true),
									LanguageId = item.LanguageID
								});
							}
						}
						list5.Add(new CommonMultiLanguageViewModel
						{
							Value = obj.Value,
							LanguageId = currLangId
						});
						string text2 = "";
						foreach (CommonMultiLanguageViewModel item2 in list5)
						{
							if (item2.LanguageId != defLangId)
							{
								text2 = text2 + "LangId=" + item2.LanguageId + "|V|Val=" + item2.Value + "|V||^V^|";
							}
						}
						if (list4 == null || list4.Count <= 0)
						{
							cRMEntities.FOMobspDyInsertFormFieldValues(num, fld.FormId, companyId: companyId, companyPersonId: model.CompanyPersonId, fieldId: fld.FormFieldId, projectId: model.ProjectId, conversationId: model.ConversationId, masterObjectId: model.MasterObjectId, detailObjectId: model.DetailObjectId, subDetailObjectId: model.SubDetailObjectId, value: (Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)).Value : null, valueLang: text2, userId: value, registerDate: value2, registerDatePersian: registerDatePersian, year1: value4, month1: value3, appType: appType, languageID: defLangId);
							continue;
						}
						FOMobspDySelectFormFieldValuesByMasterValueId_Result val = Enumerable.FirstOrDefault<FOMobspDySelectFormFieldValuesByMasterValueId_Result>((IEnumerable<FOMobspDySelectFormFieldValuesByMasterValueId_Result>)list4, (Func<FOMobspDySelectFormFieldValuesByMasterValueId_Result, bool>)((FOMobspDySelectFormFieldValuesByMasterValueId_Result m) => m.FormId == fld.FormId && m.FieldId == fld.FormFieldId));
						if (val != null)
						{
							FOMobspDySelectFormAndSubForms_Result fOMobspDySelectFormAndSubForms_Result2 = Enumerable.FirstOrDefault<FOMobspDySelectFormAndSubForms_Result>((IEnumerable<FOMobspDySelectFormAndSubForms_Result>)list3, (Func<FOMobspDySelectFormAndSubForms_Result, bool>)((FOMobspDySelectFormAndSubForms_Result m) => m.FormId == val.FormId));
							if (fOMobspDySelectFormAndSubForms_Result2 != null)
							{
								bool valueOrDefault = fOMobspDySelectFormAndSubForms_Result2.FOIsVisible.GetValueOrDefault();
								bool valueOrDefault2 = fOMobspDySelectFormAndSubForms_Result2.FOIsEnable.GetValueOrDefault();
								if (!valueOrDefault || !valueOrDefault2)
								{
									continue;
								}
							}
							cRMEntities.FOMobspDyUpdateFormFieldValues(val.FormFieldValueId, (Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)).Value : null, text2, value, value2, registerDatePersian, value4, value3, appType, defLangId);
						}
						else
						{
							cRMEntities.FOMobspDyInsertFormFieldValues(num, fld.FormId, companyId: companyId, companyPersonId: model.CompanyPersonId, fieldId: fld.FormFieldId, projectId: model.ProjectId, conversationId: model.ConversationId, masterObjectId: model.MasterObjectId, detailObjectId: model.DetailObjectId, subDetailObjectId: model.SubDetailObjectId, value: (Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)).Value : null, valueLang: text2, userId: value, registerDate: value2, registerDatePersian: registerDatePersian, year1: value4, month1: value3, appType: appType, languageID: defLangId);
						}
					}
					if (fOMobspDySelectFormAndSubForms_Result != null && !string.IsNullOrEmpty(fOMobspDySelectFormAndSubForms_Result.CheckerUsersId))
					{
						string checkerUsersId = fOMobspDySelectFormAndSubForms_Result.CheckerUsersId;
						short value5 = short.Parse(now.ToString("yyyy", new PersianCulture()));
						string registerTime = now.ToString("HH:mm:ss");
						int value6 = 55;
						string text3 = ((!string.IsNullOrEmpty(fOMobspDySelectFormAndSubForms_Result.FormName)) ? fOMobspDySelectFormAndSubForms_Result.FormName : "");
						string text4 = "";
						foreach (FOMobspSelectLanguages_Result item3 in list)
						{
							string text5 = "";
							string text6 = "";
							text5 = MyResource.GetResourceString("FOFormsCheckRequestSubject", item3.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
							text5 = text5 + " (" + FoDyForm.GetFromName(fOMobspDySelectFormAndSubForms_Result.FormId, defLangId, item3.LanguageID, model.CenterId) + ")";
							text6 = MyResource.GetResourceString("DyFrmReqCheckByName", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ":" + text3;
							text6 = text6 + "<BR><BR>" + MyResource.GetResourceString("FOFormsCheckRequestDbClickOnOtherInfo", item3.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
							text4 = text4 + "MsgSubj=" + text5 + "|@#@|MsgBody=" + text6 + "|@#@|LangId=" + item3.LanguageID + "|@#@||^#^|";
						}
						try
						{
							Enumerable.FirstOrDefault<string>((IEnumerable<string>)cRMEntities.FOMobspDyInternalMessageSendToCheckerUsers(num, text4, value6, checkerUsersId, value, value2, registerDatePersian, registerTime, text3, value5, value3, appType, defLangId));
							PushNotif.NewIntMsgNotify(withthread: true, model.CenterId);
						}
						catch (Exception e)
						{
							ErrorSignal.FromCurrentContext().Raise(e);
						}
					}
					message = Messages.MobMsgSuccessAction;
					data = num.ToString();
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
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[FoMobileAuthorize]
	public ServiceResult<string> UpdateToDeleteFormFieldMasterValue(int masterValueId, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
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
				if (new FoCommon().GetToken(token) != null)
				{
					DateTime now = DateTime.Now;
					string deletedDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					int value = -20;
					string msg = "";
					if (FoDyForm.IsChecked(masterValueId, ref msg))
					{
						ServiceResult<string> result3 = new ServiceResult<string>
						{
							Message = msg,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
						cRMEntities?.Dispose();
						return result3;
					}
					string text = "";
					cRMEntities = new CRMEntities();
					mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)cRMEntities.FOMobspDyUpdateToDeleteFormFieldMasterValue(masterValueId, value, now, deletedDatePersian));
					if (mct_Result != null && mct_Result.Result > 0)
					{
						text = "";
					}
					else if (mct_Result != null && mct_Result.Result == 0)
					{
						text = Messages.FOMobMsgErrorRedundancy;
					}
					if (string.IsNullOrEmpty(text))
					{
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					else
					{
						message = text;
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
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[FoMobileAuthorize]
	public ServiceResult<List<FOMobspDySelectFormsWithSysPartId_Result>> SelectFormsWithSysPartId(int sysPartId, int? compnayPersonId, int? ln = 1065, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<FOMobspDySelectFormsWithSysPartId_Result> list = null;
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
				FoToken token2 = new FoCommon().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					list = Enumerable.ToList<FOMobspDySelectFormsWithSysPartId_Result>((IEnumerable<FOMobspDySelectFormsWithSysPartId_Result>)cRMEntities.FOMobspDySelectFormsWithSysPartId(sysPartId, token2.CompanyId, -20, result, result2, compnayPersonId, cId));
					if (list != null)
					{
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					else
					{
						message = Messages.MobFoMsgNoResultFound;
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
		return new ServiceResult<List<FOMobspDySelectFormsWithSysPartId_Result>>
		{
			Message = message,
			Data = list,
			Status = status
		};
	}
}
