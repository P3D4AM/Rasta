using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Validation;
using System.Data.Objects;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using CRM.General.Calendar;
using CRM.General.IO;
using CRM.General.IO.FTP;
using CRM.General.Security;
using CRMIdealApi.ApiModels;
using CRMIdealApi.Classes;
using CRMIdealApi.Classes.Common;
using CRMIdealApi.Classes.Helper;
using CRMIdealApi.DataType;
using CRMIdealApi.Resources;
using Elmah;
using GSD.Globalization;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;

namespace CRMIdealApi.Controllers;

public class ApiDyFormController : ApiController
{
	public class CustomMultipartFormDataStreamProvider : MultipartFormDataStreamProvider
	{
		public CustomMultipartFormDataStreamProvider(string path)
			: base(path)
		{
		}

		public override string GetLocalFileName(HttpContentHeaders headers)
		{
			return headers.ContentDisposition.FileName.Replace("\"", string.Empty);
		}
	}

	[CompilerGenerated]
	private static class _003C_003Eo__16
	{
		public static CallSite<Func<CallSite, object, object, object>> _003C_003Ep__0;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__1;

		public static CallSite<Func<CallSite, object, int, object>> _003C_003Ep__2;

		public static CallSite<Func<CallSite, object, MultipartFileData>> _003C_003Ep__3;

		public static CallSite<Func<CallSite, object, object, object>> _003C_003Ep__4;

		public static CallSite<Func<CallSite, bool, object, object>> _003C_003Ep__5;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__6;

		public static CallSite<Func<CallSite, object, int, object>> _003C_003Ep__7;

		public static CallSite<Func<CallSite, object, MultipartFileData>> _003C_003Ep__8;

		public static CallSite<Func<CallSite, object, object, object>> _003C_003Ep__9;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__10;

		public static CallSite<Func<CallSite, object, int, object>> _003C_003Ep__11;

		public static CallSite<Func<CallSite, object, MultipartFileData>> _003C_003Ep__12;
	}

	private DateTime registerDate = DateTime.Now;

	private DateTime dt = DateTime.Now;

	private string registerDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());

	private string registerTime = DateTime.Now.ToString("HH:mm:ss");

	private short month1 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));

	private string appType = CRMIdealApi.Classes.Configuration.AppType;

	[HttpPost]
	public ServiceResult<List<TreeDyFormViewModel>> SelectFormsTree(DyFormViewModel model)
	{
		CRMEntities cRMEntities = null;
		ResourceManager resourceManager = new ResourceManager();
		List<TreeDyFormViewModel> list = new List<TreeDyFormViewModel>();
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<List<TreeDyFormViewModel>>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			CommonClass commonClass = new CommonClass();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<List<TreeDyFormViewModel>>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int.TryParse(model.LanguageId.ToString(), out var currLangId);
			if (currLangId <= 0)
			{
				currLangId = result;
			}
			List<ApispSelectLanguages_Result> list2 = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)cRMEntities.ApispSelectLanguages());
			string rsCollation = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list2, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				rsCollation = apispSelectLanguages_Result.LanguageCollation;
			}
			if (!string.IsNullOrEmpty(model.Password))
			{
				model.Password = CodeDecode.DeCodding(model.Password);
			}
			if (!string.IsNullOrEmpty(model.UserName))
			{
				model.UserName = CodeDecode.DeCodding(model.UserName);
			}
			int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispCheckUserAllowed(model.UserName, model.Password));
			int result2 = 0;
			int.TryParse(num.ToString(), out result2);
			if (result2 == 0)
			{
				return new ServiceResult<List<TreeDyFormViewModel>>
				{
					Message = resourceManager.Get("ErrorUsernamePasswordIncorrect", rsCollation, resourceManager.TypeMsg) + "\r\n" + resourceManager.Get("ErrorTryAgain", rsCollation, resourceManager.TypeMsg),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			List<ApispDySelectFormsTree_Result> list3 = Enumerable.ToList<ApispDySelectFormsTree_Result>((IEnumerable<ApispDySelectFormsTree_Result>)cRMEntities.ApispDySelectFormsTree(model.UserId, model.LanguageId, result));
			if (list3 != null)
			{
				foreach (ApispDySelectFormsTree_Result item in list3)
				{
					List<TreeSysPartsDyFormViewModel> list4 = new List<TreeSysPartsDyFormViewModel>();
					if (item.Items != null)
					{
						list4 = JsonConvert.DeserializeObject<List<TreeSysPartsDyFormViewModel>>(item.Items);
						foreach (TreeSysPartsDyFormViewModel item2 in list4)
						{
							if (item2 == null || item2.Items == null)
							{
								continue;
							}
							foreach (TreeParentDyFormViewModel item3 in item2.Items)
							{
								if (!string.IsNullOrWhiteSpace(item3.ApiFormBgColor))
								{
									item3.ApiFormBgColor = Public.TColorToHex(item3.ApiFormBgColor);
								}
								if (!string.IsNullOrWhiteSpace(item3.ApiFormTitleColor))
								{
									item3.ApiFormTitleColor = Public.TColorToHex(item3.ApiFormTitleColor);
								}
								if (item3 == null || item3.Items == null)
								{
									continue;
								}
								foreach (TreeChildDyFormViewModel item4 in item3.Items)
								{
									if (!string.IsNullOrWhiteSpace(item4.ApiFormBgColor))
									{
										item4.ApiFormBgColor = Public.TColorToHex(item4.ApiFormBgColor);
									}
									if (!string.IsNullOrWhiteSpace(item4.ApiFormTitleColor))
									{
										item4.ApiFormTitleColor = Public.TColorToHex(item4.ApiFormTitleColor);
									}
								}
							}
						}
					}
					list.Add(new TreeDyFormViewModel
					{
						Id = item.Id,
						Text = item.Text,
						Items = list4
					});
				}
				status = ServiceResultStatus.Success;
			}
			else
			{
				list = null;
			}
		}
		catch (Exception ex)
		{
			string text = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text = text + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text)) ? (" (" + text + ")") : "");
			list = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		cRMEntities?.Dispose();
		return new ServiceResult<List<TreeDyFormViewModel>>
		{
			Message = message,
			Data = list,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<List<ApispDySelectFormWithId_Result>> SelectFormWithId(DyFormWithIdViewModel model)
	{
		CRMEntities cRMEntities = null;
		ResourceManager resourceManager = new ResourceManager();
		List<ApispDySelectFormWithId_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<List<ApispDySelectFormWithId_Result>>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			CommonClass commonClass = new CommonClass();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<List<ApispDySelectFormWithId_Result>>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int.TryParse(model.LanguageId.ToString(), out var currLangId);
			if (currLangId <= 0)
			{
				currLangId = result;
			}
			List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)cRMEntities.ApispSelectLanguages());
			string rsCollation = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				rsCollation = apispSelectLanguages_Result.LanguageCollation;
			}
			if (!string.IsNullOrEmpty(model.Password))
			{
				model.Password = CodeDecode.DeCodding(model.Password);
			}
			if (!string.IsNullOrEmpty(model.UserName))
			{
				model.UserName = CodeDecode.DeCodding(model.UserName);
			}
			int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispCheckUserAllowed(model.UserName, model.Password));
			int result2 = 0;
			int.TryParse(num.ToString(), out result2);
			if (result2 == 0)
			{
				return new ServiceResult<List<ApispDySelectFormWithId_Result>>
				{
					Message = resourceManager.Get("ErrorUsernamePasswordIncorrect", rsCollation, resourceManager.TypeMsg) + "\r\n" + resourceManager.Get("ErrorTryAgain", rsCollation, resourceManager.TypeMsg),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			List<ApispDySelectFormWithId_Result> list2 = Enumerable.ToList<ApispDySelectFormWithId_Result>((IEnumerable<ApispDySelectFormWithId_Result>)cRMEntities.ApispDySelectFormWithId(model.UserId, model.FormId, currLangId, result));
			if (list2 != null)
			{
				foreach (ApispDySelectFormWithId_Result item in list2)
				{
					item.ApiFormBgColor = Public.TColorToHex(item.ApiFormBgColor);
					item.ApiFormTitleColor = Public.TColorToHex(item.ApiFormTitleColor);
				}
				data = list2;
				status = ServiceResultStatus.Success;
			}
		}
		catch (Exception ex)
		{
			string text = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text = text + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text)) ? (" (" + text + ")") : "");
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		cRMEntities?.Dispose();
		return new ServiceResult<List<ApispDySelectFormWithId_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<List<ApispDySelectForms_Result>> SelectForms(SelectDyFormsViewModel model)
	{
		CRMEntities cRMEntities = null;
		ResourceManager resourceManager = new ResourceManager();
		List<ApispDySelectForms_Result> list = new List<ApispDySelectForms_Result>();
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<List<ApispDySelectForms_Result>>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			CommonClass commonClass = new CommonClass();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<List<ApispDySelectForms_Result>>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int.TryParse(model.LanguageId.ToString(), out var currLangId);
			if (currLangId <= 0)
			{
				currLangId = result;
			}
			List<ApispSelectLanguages_Result> list2 = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)cRMEntities.ApispSelectLanguages());
			string rsCollation = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list2, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				rsCollation = apispSelectLanguages_Result.LanguageCollation;
			}
			if (!string.IsNullOrEmpty(model.Password))
			{
				model.Password = CodeDecode.DeCodding(model.Password);
			}
			if (!string.IsNullOrEmpty(model.UserName))
			{
				model.UserName = CodeDecode.DeCodding(model.UserName);
			}
			int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispCheckUserAllowed(model.UserName, model.Password));
			int result2 = 0;
			int.TryParse(num.ToString(), out result2);
			if (result2 == 0)
			{
				return new ServiceResult<List<ApispDySelectForms_Result>>
				{
					Message = resourceManager.Get("ErrorUsernamePasswordIncorrect", rsCollation, resourceManager.TypeMsg) + "\r\n" + resourceManager.Get("ErrorTryAgain", rsCollation, resourceManager.TypeMsg),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			List<ApispDySelectForms_Result> list3 = Enumerable.ToList<ApispDySelectForms_Result>((IEnumerable<ApispDySelectForms_Result>)cRMEntities.ApispDySelectForms(model.ApiFormId, model.ApiParentFormId, currLangId, result, model.CenterId.GetValueOrDefault(), model.CenterCode ?? ""));
			if (list3 != null)
			{
				foreach (ApispDySelectForms_Result item in list3)
				{
					if (!string.IsNullOrWhiteSpace(item.ApiFormBgColor))
					{
						item.ApiFormBgColor = Public.TColorToHex(item.ApiFormBgColor);
					}
					if (!string.IsNullOrWhiteSpace(item.ApiFormTitleColor))
					{
						item.ApiFormTitleColor = Public.TColorToHex(item.ApiFormTitleColor);
					}
					list.Add(item);
				}
				status = ServiceResultStatus.Success;
			}
			else
			{
				list = null;
			}
		}
		catch (Exception ex)
		{
			string text = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text = text + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text)) ? (" (" + text + ")") : "");
			list = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		cRMEntities?.Dispose();
		return new ServiceResult<List<ApispDySelectForms_Result>>
		{
			Message = message,
			Data = list,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<List<ApispDySelectFormFields_Result>> SelectFormFields(DyFormFieldsViewModel model)
	{
		CRMEntities cRMEntities = null;
		ResourceManager resourceManager = new ResourceManager();
		List<ApispDySelectFormFields_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<List<ApispDySelectFormFields_Result>>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			CommonClass commonClass = new CommonClass();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<List<ApispDySelectFormFields_Result>>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int.TryParse(model.LanguageId.ToString(), out var currLangId);
			if (currLangId <= 0)
			{
				currLangId = result;
			}
			List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)cRMEntities.ApispSelectLanguages());
			string rsCollation = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				rsCollation = apispSelectLanguages_Result.LanguageCollation;
			}
			if (!string.IsNullOrEmpty(model.Password))
			{
				model.Password = CodeDecode.DeCodding(model.Password);
			}
			if (!string.IsNullOrEmpty(model.UserName))
			{
				model.UserName = CodeDecode.DeCodding(model.UserName);
			}
			int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispCheckUserAllowed(model.UserName, model.Password));
			int result2 = 0;
			int.TryParse(num.ToString(), out result2);
			if (result2 == 0)
			{
				return new ServiceResult<List<ApispDySelectFormFields_Result>>
				{
					Message = resourceManager.Get("ErrorUsernamePasswordIncorrect", rsCollation, resourceManager.TypeMsg) + "\r\n" + resourceManager.Get("ErrorTryAgain", rsCollation, resourceManager.TypeMsg),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			List<ApispDySelectFormFields_Result> list2 = Enumerable.ToList<ApispDySelectFormFields_Result>((IEnumerable<ApispDySelectFormFields_Result>)cRMEntities.ApispDySelectFormFields(model.FormId, currLangId, result));
			if (list2 != null)
			{
				foreach (ApispDySelectFormFields_Result item in list2)
				{
					item.ApiParentFieldBgColor = Public.TColorToHex(item.ApiParentFieldBgColor);
					item.ApiParentFieldColor = Public.TColorToHex(item.ApiParentFieldColor);
				}
				data = list2;
				status = ServiceResultStatus.Success;
			}
		}
		catch (Exception ex)
		{
			string text = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text = text + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text)) ? (" (" + text + ")") : "");
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		cRMEntities?.Dispose();
		return new ServiceResult<List<ApispDySelectFormFields_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<List<ApispDySelectFormFieldMasterValues_Result>> SelectFormFieldMasterValues(SelectFormFieldMasterValuesViewModel model)
	{
		CRMEntities cRMEntities = null;
		ResourceManager resourceManager = new ResourceManager();
		List<ApispDySelectFormFieldMasterValues_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<List<ApispDySelectFormFieldMasterValues_Result>>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			CommonClass commonClass = new CommonClass();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<List<ApispDySelectFormFieldMasterValues_Result>>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int.TryParse(model.LanguageId.ToString(), out var currLangId);
			if (currLangId <= 0)
			{
				currLangId = result;
			}
			List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)cRMEntities.ApispSelectLanguages());
			string rsCollation = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				rsCollation = apispSelectLanguages_Result.LanguageCollation;
			}
			if (!string.IsNullOrEmpty(model.Password))
			{
				model.Password = CodeDecode.DeCodding(model.Password);
			}
			if (!string.IsNullOrEmpty(model.UserName))
			{
				model.UserName = CodeDecode.DeCodding(model.UserName);
			}
			int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispCheckUserAllowed(model.UserName, model.Password));
			int result2 = 0;
			int.TryParse(num.ToString(), out result2);
			if (result2 == 0)
			{
				return new ServiceResult<List<ApispDySelectFormFieldMasterValues_Result>>
				{
					Message = resourceManager.Get("ErrorUsernamePasswordIncorrect", rsCollation, resourceManager.TypeMsg) + "\r\n" + resourceManager.Get("ErrorTryAgain", rsCollation, resourceManager.TypeMsg),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			List<ApispDySelectFormFieldMasterValues_Result> list2 = Enumerable.ToList<ApispDySelectFormFieldMasterValues_Result>((IEnumerable<ApispDySelectFormFieldMasterValues_Result>)cRMEntities.ApispDySelectFormFieldMasterValues(model.FormId, model.CompanyId, model.CompanyPersonId, model.ProjectId, model.ConversationId, model.MasterObjectId, model.DetailObjectId, model.SubDetailObjectId, currLangId, result, model.UserId));
			if (list2 != null)
			{
				data = list2;
				status = ServiceResultStatus.Success;
			}
		}
		catch (Exception ex)
		{
			string text = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text = text + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text)) ? (" (" + text + ")") : "");
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		cRMEntities?.Dispose();
		return new ServiceResult<List<ApispDySelectFormFieldMasterValues_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<List<ApispDySelectFormFieldMasterValueDetails_Result>> SelectMasterValueDetails(DyFormMastetValueDetailsViewModel model)
	{
		CRMEntities cRMEntities = null;
		ResourceManager resourceManager = new ResourceManager();
		List<ApispDySelectFormFieldMasterValueDetails_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<List<ApispDySelectFormFieldMasterValueDetails_Result>>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			CommonClass commonClass = new CommonClass();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<List<ApispDySelectFormFieldMasterValueDetails_Result>>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int.TryParse(model.LanguageId.ToString(), out var currLangId);
			if (currLangId <= 0)
			{
				currLangId = result;
			}
			List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)cRMEntities.ApispSelectLanguages());
			string rsCollation = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				rsCollation = apispSelectLanguages_Result.LanguageCollation;
			}
			if (!string.IsNullOrEmpty(model.Password))
			{
				model.Password = CodeDecode.DeCodding(model.Password);
			}
			if (!string.IsNullOrEmpty(model.UserName))
			{
				model.UserName = CodeDecode.DeCodding(model.UserName);
			}
			int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispCheckUserAllowed(model.UserName, model.Password));
			int result2 = 0;
			int.TryParse(num.ToString(), out result2);
			if (result2 == 0)
			{
				return new ServiceResult<List<ApispDySelectFormFieldMasterValueDetails_Result>>
				{
					Message = resourceManager.Get("ErrorUsernamePasswordIncorrect", rsCollation, resourceManager.TypeMsg) + "\r\n" + resourceManager.Get("ErrorTryAgain", rsCollation, resourceManager.TypeMsg),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			List<ApispDySelectFormFieldMasterValueDetails_Result> list2 = Enumerable.ToList<ApispDySelectFormFieldMasterValueDetails_Result>((IEnumerable<ApispDySelectFormFieldMasterValueDetails_Result>)cRMEntities.ApispDySelectFormFieldMasterValueDetails(model.ApiFormId, model.ApiCompanyId, model.ApiPrsId, model.ApiProjectId, model.ApiConversationId, model.ApiMasterId, model.APIDetailObjectId, model.ApiSubDetailObjectId, currLangId, result));
			if (list2 != null)
			{
				data = list2;
				status = ServiceResultStatus.Success;
			}
		}
		catch (Exception ex)
		{
			string text = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text = text + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text)) ? (" (" + text + ")") : "");
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		cRMEntities?.Dispose();
		return new ServiceResult<List<ApispDySelectFormFieldMasterValueDetails_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	public ServiceResult<List<ApispDySelectFormWorkflows_Result>> SelectFormWorkflows(SelectFormWorkflowsViewModel model)
	{
		CRMEntities cRMEntities = null;
		ResourceManager resourceManager = new ResourceManager();
		List<ApispDySelectFormWorkflows_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<List<ApispDySelectFormWorkflows_Result>>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			CommonClass commonClass = new CommonClass();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<List<ApispDySelectFormWorkflows_Result>>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int.TryParse(model.LanguageId.ToString(), out var currLangId);
			if (currLangId <= 0)
			{
				currLangId = result;
			}
			List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)cRMEntities.ApispSelectLanguages());
			string rsCollation = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				rsCollation = apispSelectLanguages_Result.LanguageCollation;
			}
			if (!string.IsNullOrEmpty(model.Password))
			{
				model.Password = CodeDecode.DeCodding(model.Password);
			}
			if (!string.IsNullOrEmpty(model.UserName))
			{
				model.UserName = CodeDecode.DeCodding(model.UserName);
			}
			int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispCheckUserAllowed(model.UserName, model.Password));
			int result2 = 0;
			int.TryParse(num.ToString(), out result2);
			if (result2 == 0)
			{
				return new ServiceResult<List<ApispDySelectFormWorkflows_Result>>
				{
					Message = resourceManager.Get("ErrorUsernamePasswordIncorrect", rsCollation, resourceManager.TypeMsg) + "\r\n" + resourceManager.Get("ErrorTryAgain", rsCollation, resourceManager.TypeMsg),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			List<ApispDySelectFormWorkflows_Result> list2 = Enumerable.ToList<ApispDySelectFormWorkflows_Result>((IEnumerable<ApispDySelectFormWorkflows_Result>)cRMEntities.ApispDySelectFormWorkflows(currLangId, result));
			if (list2 != null)
			{
				foreach (ApispDySelectFormWorkflows_Result item in list2)
				{
					item.RegisterDatePersian = item.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss", new CultureInfo(currLangId));
					item.FirstRegisterDatePersian = item.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss", new CultureInfo(currLangId));
				}
				data = list2;
				status = ServiceResultStatus.Success;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			string text = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text = text + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text)) ? (" (" + text + ")") : "");
			data = null;
			status = ServiceResultStatus.Error;
		}
		cRMEntities?.Dispose();
		return new ServiceResult<List<ApispDySelectFormWorkflows_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	public ServiceResult<List<ApispDySelectFormWorkflowSteps_Result>> SelectFormWorkflowSteps(SelectFormWorkflowStepsViewModel model)
	{
		CRMEntities cRMEntities = null;
		ResourceManager resourceManager = new ResourceManager();
		List<ApispDySelectFormWorkflowSteps_Result> data = null;
		string message = "";
		ServiceResultStatus serviceResultStatus = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<List<ApispDySelectFormWorkflowSteps_Result>>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			CommonClass commonClass = new CommonClass();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<List<ApispDySelectFormWorkflowSteps_Result>>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int.TryParse(model.LanguageId.ToString(), out var currLangId);
			if (currLangId <= 0)
			{
				currLangId = result;
			}
			List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)cRMEntities.ApispSelectLanguages());
			string rsCollation = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				rsCollation = apispSelectLanguages_Result.LanguageCollation;
			}
			if (!string.IsNullOrEmpty(model.Password))
			{
				model.Password = CodeDecode.DeCodding(model.Password);
			}
			if (!string.IsNullOrEmpty(model.UserName))
			{
				model.UserName = CodeDecode.DeCodding(model.UserName);
			}
			int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispCheckUserAllowed(model.UserName, model.Password));
			int result2 = 0;
			int.TryParse(num.ToString(), out result2);
			if (result2 == 0)
			{
				return new ServiceResult<List<ApispDySelectFormWorkflowSteps_Result>>
				{
					Message = resourceManager.Get("ErrorUsernamePasswordIncorrect", rsCollation, resourceManager.TypeMsg) + "\r\n" + resourceManager.Get("ErrorTryAgain", rsCollation, resourceManager.TypeMsg),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			List<ApispDySelectFormWorkflowSteps_Result> list2 = Enumerable.ToList<ApispDySelectFormWorkflowSteps_Result>((IEnumerable<ApispDySelectFormWorkflowSteps_Result>)cRMEntities.ApispDySelectFormWorkflowSteps(model.WorkflowId, currLangId, result));
			if (list2 != null)
			{
				foreach (ApispDySelectFormWorkflowSteps_Result item in list2)
				{
					item.RegisterDatePersian = item.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss", new CultureInfo(currLangId));
					item.FirstRegisterDatePersian = item.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss", new CultureInfo(currLangId));
				}
				data = list2;
				serviceResultStatus = ServiceResultStatus.Success;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			string text = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text = text + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text)) ? (" (" + text + ")") : "");
			data = null;
			serviceResultStatus = ServiceResultStatus.Error;
		}
		cRMEntities?.Dispose();
		return new ServiceResult<List<ApispDySelectFormWorkflowSteps_Result>>
		{
			Message = message,
			Data = data,
			Status = ServiceResultStatus.Success
		};
	}

	[HttpPost]
	public ServiceResult<List<ApispDySelectFormFieldValuesByMasterValueId_Result>> SelectFormFieldValuesByMasterValueId(SelectFormFieldValuesByMasterValueIdViewModel model)
	{
		CRMEntities cRMEntities = null;
		ResourceManager resourceManager = new ResourceManager();
		List<ApispDySelectFormFieldValuesByMasterValueId_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<List<ApispDySelectFormFieldValuesByMasterValueId_Result>>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			CommonClass commonClass = new CommonClass();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<List<ApispDySelectFormFieldValuesByMasterValueId_Result>>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int.TryParse(model.LanguageId.ToString(), out var currLangId);
			if (currLangId <= 0)
			{
				currLangId = result;
			}
			List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)cRMEntities.ApispSelectLanguages());
			string rsCollation = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				rsCollation = apispSelectLanguages_Result.LanguageCollation;
			}
			if (!string.IsNullOrEmpty(model.Password))
			{
				model.Password = CodeDecode.DeCodding(model.Password);
			}
			if (!string.IsNullOrEmpty(model.UserName))
			{
				model.UserName = CodeDecode.DeCodding(model.UserName);
			}
			int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispCheckUserAllowed(model.UserName, model.Password));
			int result2 = 0;
			int.TryParse(num.ToString(), out result2);
			if (result2 == 0)
			{
				return new ServiceResult<List<ApispDySelectFormFieldValuesByMasterValueId_Result>>
				{
					Message = resourceManager.Get("ErrorUsernamePasswordIncorrect", rsCollation, resourceManager.TypeMsg) + "\r\n" + resourceManager.Get("ErrorTryAgain", rsCollation, resourceManager.TypeMsg),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			List<ApispDySelectFormFieldValuesByMasterValueId_Result> list2 = Enumerable.ToList<ApispDySelectFormFieldValuesByMasterValueId_Result>((IEnumerable<ApispDySelectFormFieldValuesByMasterValueId_Result>)cRMEntities.ApispDySelectFormFieldValuesByMasterValueId(model.MasterValueId, currLangId, result));
			if (list2 != null)
			{
				data = list2;
				status = ServiceResultStatus.Success;
			}
		}
		catch (Exception ex)
		{
			string text = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text = text + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text)) ? (" (" + text + ")") : "");
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		return new ServiceResult<List<ApispDySelectFormFieldValuesByMasterValueId_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<List<SelectFormFieldValuesResultViewModel>> SelectFormFieldValues(SelectFormFieldValuesViewModel model)
	{
		CRMEntities cRMEntities = null;
		ResourceManager resourceManager = new ResourceManager();
		List<SelectFormFieldValuesResultViewModel> list = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<List<SelectFormFieldValuesResultViewModel>>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			CommonClass commonClass = new CommonClass();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<List<SelectFormFieldValuesResultViewModel>>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int.TryParse(model.LanguageId.ToString(), out var currLangId);
			if (currLangId <= 0)
			{
				currLangId = result;
			}
			List<ApispSelectLanguages_Result> list2 = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)cRMEntities.ApispSelectLanguages());
			string rsCollation = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list2, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				rsCollation = apispSelectLanguages_Result.LanguageCollation;
			}
			if (!string.IsNullOrEmpty(model.Password))
			{
				model.Password = CodeDecode.DeCodding(model.Password);
			}
			if (!string.IsNullOrEmpty(model.UserName))
			{
				model.UserName = CodeDecode.DeCodding(model.UserName);
			}
			int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispCheckUserAllowed(model.UserName, model.Password));
			int result2 = 0;
			int.TryParse(num.ToString(), out result2);
			if (result2 == 0)
			{
				return new ServiceResult<List<SelectFormFieldValuesResultViewModel>>
				{
					Message = resourceManager.Get("ErrorUsernamePasswordIncorrect", rsCollation, resourceManager.TypeMsg) + "\r\n" + resourceManager.Get("ErrorTryAgain", rsCollation, resourceManager.TypeMsg),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			List<ApispDySelectFormFieldValues_Result> list3 = Enumerable.ToList<ApispDySelectFormFieldValues_Result>((IEnumerable<ApispDySelectFormFieldValues_Result>)cRMEntities.ApispDySelectFormFieldValues(model.FormId, model.MasterValueId, model.CompanyId, model.CompanyPersonId, model.ProjectId, model.ConversationId, model.MasterObjectId, model.DetailObjectId, model.SubDetailObjectId, currLangId, result));
			if (list3 != null)
			{
				foreach (ApispDySelectFormFieldValues_Result item in list3)
				{
					SelectFormFieldValuesResultViewModel selectFormFieldValuesResultViewModel = new SelectFormFieldValuesResultViewModel();
					selectFormFieldValuesResultViewModel.RegisterDate = item.RegisterDate;
					selectFormFieldValuesResultViewModel.RegisterDatePersian = item.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss", new CultureInfo(model.LanguageId.GetValueOrDefault(1065)));
					selectFormFieldValuesResultViewModel.FirstRegisterDate = item.FirstRegisterDate;
					selectFormFieldValuesResultViewModel.FirstRegisterDatePersian = item.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss", new CultureInfo(model.LanguageId.GetValueOrDefault(1065)));
					selectFormFieldValuesResultViewModel.FormFieldValueId = item.FormFieldValueId;
					selectFormFieldValuesResultViewModel.FormId = item.FormId;
					selectFormFieldValuesResultViewModel.FieldId = item.FieldId;
					selectFormFieldValuesResultViewModel.Values = new List<SelectFormFieldValueItemssResultViewModel>();
					if (!string.IsNullOrWhiteSpace(item.Value))
					{
						selectFormFieldValuesResultViewModel.Values = JsonConvert.DeserializeObject<List<SelectFormFieldValueItemssResultViewModel>>(item.Value);
					}
					selectFormFieldValuesResultViewModel.IsDeleted = item.IsDeleted;
					selectFormFieldValuesResultViewModel.CompanyId = item.CompanyId;
					selectFormFieldValuesResultViewModel.CompanyPersonId = item.CompanyPersonId;
					selectFormFieldValuesResultViewModel.ProjectId = item.ProjectId;
					selectFormFieldValuesResultViewModel.ConversationId = item.ConversationId;
					selectFormFieldValuesResultViewModel.MasterObjectId = item.MasterObjectId;
					selectFormFieldValuesResultViewModel.DetailObjectId = item.DetailObjectId;
					selectFormFieldValuesResultViewModel.SubDetailObjectId = item.SubDetailObjectId;
					selectFormFieldValuesResultViewModel.MasterValueId = item.MasterValueId;
					selectFormFieldValuesResultViewModel.FirstRegisterUserId = item.FirstRegisterUserId;
					selectFormFieldValuesResultViewModel.UserId = item.UserId;
					selectFormFieldValuesResultViewModel.EditUser = item.EditUser;
					selectFormFieldValuesResultViewModel.FirstRegisterUser = item.FirstRegisterUser;
					selectFormFieldValuesResultViewModel.FormName = item.FormName;
					selectFormFieldValuesResultViewModel.FieldTitle = item.FieldTitle;
					selectFormFieldValuesResultViewModel.RegularExpressionErrorTxt = item.RegularExpressionErrorTxt;
					selectFormFieldValuesResultViewModel.FieldTypeId = item.FieldTypeId;
					selectFormFieldValuesResultViewModel.FieldType = item.FieldType;
					selectFormFieldValuesResultViewModel.TypeInWeb = item.TypeInWeb;
					selectFormFieldValuesResultViewModel.TypeInWindows = item.TypeInWindows;
					selectFormFieldValuesResultViewModel.RegularExpressionTitle = item.RegularExpressionTitle;
					selectFormFieldValuesResultViewModel.RegularExpression = item.RegularExpression;
					selectFormFieldValuesResultViewModel.RegularExpressionOther = item.RegularExpressionOther;
					list.Add(selectFormFieldValuesResultViewModel);
				}
				status = ServiceResultStatus.Success;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			string text = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text = text + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text)) ? (" (" + text + ")") : "");
			list = null;
			status = ServiceResultStatus.Error;
		}
		return new ServiceResult<List<SelectFormFieldValuesResultViewModel>>
		{
			Message = message,
			Data = list,
			Status = status
		};
	}

	[HttpPost]
	public async Task<ServiceResult<string>> InsertUpdateDyForm()
	{
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		string result = "";
		DyFormFieldValuesViewModel model = new DyFormFieldValuesViewModel();
		List<DyFormFieldFilesViewModel> filesInfo = new List<DyFormFieldFilesViewModel>();
		dynamic formFileSending = null;
		CRMEntities db = new CRMEntities();
		ResourceManager RS = new ResourceManager();
		ServiceResult<string> serviceResult;
		try
		{
			int countError = 0;
			DateTime dt = DateTime.Now;
			_ = CRMIdealApi.Classes.Configuration.FacadeFtp;
			_ = CRMIdealApi.Classes.Configuration.PathFtp;
			_ = CRMIdealApi.Classes.Configuration.UserNameFtp;
			_ = CRMIdealApi.Classes.Configuration.PasswordFtp;
			_ = CRMIdealApi.Classes.Configuration.UsePassiveFtp;
			string text = CRMIdealApi.Classes.Configuration.HostTempFilesPath + "/" + CRMIdealApi.Classes.Configuration.UploadFileDirectoryPath;
			string text2 = HttpContext.Current.Server.MapPath(text);
			if (!System.IO.Directory.Exists(text2))
			{
				System.IO.Directory.CreateDirectory(text2);
				CRM.General.IO.Directory.SetFullControlForEveryOne(text2);
			}
			string text3 = HttpContext.Current.Server.MapPath(text + model.UserId + "/");
			if (!System.IO.Directory.Exists(text3))
			{
				System.IO.Directory.CreateDirectory(text3);
				CRM.General.IO.Directory.SetFullControlForEveryOne(text3);
			}
			text3 = HttpContext.Current.Server.MapPath(text + model.UserId + "/" + dt.ToString("yyyyMMddHHmmss", new CultureInfo("en-US")) + "/");
			if (!System.IO.Directory.Exists(text3))
			{
				System.IO.Directory.CreateDirectory(text3);
				CRM.General.IO.Directory.SetFullControlForEveryOne(text3);
			}
			string path = text3;
			CustomMultipartFormDataStreamProvider provider = new CustomMultipartFormDataStreamProvider(path);
			try
			{
				await base.Request.Content.ReadAsMultipartAsync(provider);
				Collection<MultipartFileData> fileData = provider.FileData;
				if (fileData != null)
				{
					formFileSending = fileData;
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
			try
			{
				string text4 = provider.FormData.Get("model");
				if (!string.IsNullOrWhiteSpace(text4))
				{
					model = JsonConvert.DeserializeObject<DyFormFieldValuesViewModel>(text4.Trim());
				}
			}
			catch (Exception e2)
			{
				ErrorSignal.FromCurrentContext().Raise(e2);
			}
			try
			{
				string text5 = provider.FormData.Get("filesInfo");
				if (!string.IsNullOrWhiteSpace(text5))
				{
					filesInfo = JsonConvert.DeserializeObject<List<DyFormFieldFilesViewModel>>(text5.Trim());
				}
			}
			catch (Exception e3)
			{
				ErrorSignal.FromCurrentContext().Raise(e3);
			}
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)db.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				serviceResult = new ServiceResult<string>();
				serviceResult.Message = Messages.ErrorInReadingSysSetting;
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var defLangId);
			if (defLangId <= 0)
			{
				defLangId = 1065;
			}
			int.TryParse(model.LanguageId.ToString(), out var currLangId);
			if (currLangId <= 0)
			{
				currLangId = defLangId;
			}
			List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)db.ApispSelectLanguages());
			string text6 = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				text6 = apispSelectLanguages_Result.LanguageCollation;
			}
			if (!VersionBuyer.DyForm)
			{
				serviceResult = new ServiceResult<string>();
				serviceResult.Message = string.Format(Messages.ResourceManager.GetString("ErrorMsgBuyModule", new CultureInfo(currLangId)), Labels.ResourceManager.GetString("lblDyForm", new CultureInfo(currLangId)));
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (!string.IsNullOrEmpty(model.Password))
			{
				model.Password = CodeDecode.DeCodding(model.Password);
			}
			if (!string.IsNullOrEmpty(model.UserName))
			{
				model.UserName = CodeDecode.DeCodding(model.UserName);
			}
			int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)db.ApispCheckUserAllowed(model.UserName, model.Password));
			int result2 = 0;
			int.TryParse(num.ToString(), out result2);
			if (result2 == 0)
			{
				serviceResult = new ServiceResult<string>();
				serviceResult.Message = RS.Get("ErrorUsernamePasswordIncorrect", text6, RS.TypeMsg) + "\r\n" + RS.Get("ErrorTryAgain", text6, RS.TypeMsg);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			int result3 = 0;
			new List<ApispDySelectFormFieldsByParentFormId_Result>();
			new List<ApispDySelectFormAndSubForms_Result>();
			if (!VersionBuyer.CRMApi)
			{
				serviceResult = new ServiceResult<string>();
				serviceResult.Message = Messages.ErrorAccessAPILimited;
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			bool result4 = false;
			bool.TryParse(model.CanSave.ToString(), out result4);
			List<ApispDySelectFormAndSubForms_Result> list2;
			ApispDySelectFormAndSubForms_Result apispDySelectFormAndSubForms_Result;
			bool flag;
			List<ApispDySelectFormFieldsByParentFormId_Result> list3;
			List<IdKeyValueItemViewModel> list4;
			List<IdKeyValueItemViewModel> list5;
			if (result4)
			{
				list2 = Enumerable.ToList<ApispDySelectFormAndSubForms_Result>((IEnumerable<ApispDySelectFormAndSubForms_Result>)db.ApispDySelectFormAndSubForms(model.FormId, model.UserId, currLangId, defLangId));
				new ApispDySelectFormAndSubForms_Result();
				if (list2 != null && Enumerable.Any<ApispDySelectFormAndSubForms_Result>((IEnumerable<ApispDySelectFormAndSubForms_Result>)list2))
				{
					apispDySelectFormAndSubForms_Result = Enumerable.FirstOrDefault<ApispDySelectFormAndSubForms_Result>((IEnumerable<ApispDySelectFormAndSubForms_Result>)list2, (Func<ApispDySelectFormAndSubForms_Result, bool>)((ApispDySelectFormAndSubForms_Result m) => m.FormId == model.FormId));
					if (apispDySelectFormAndSubForms_Result != null)
					{
						int.TryParse(apispDySelectFormAndSubForms_Result.WorkflowId.ToString(), out result3);
						flag = result3 > 0;
						if (!string.IsNullOrEmpty(apispDySelectFormAndSubForms_Result.FormName))
						{
							_ = apispDySelectFormAndSubForms_Result.FormName;
						}
						if (apispDySelectFormAndSubForms_Result.CrmSysPartId.GetValueOrDefault() != 1)
						{
							_ = apispDySelectFormAndSubForms_Result.FOSysPartId.GetValueOrDefault() == 100;
						}
						list3 = Enumerable.ToList<ApispDySelectFormFieldsByParentFormId_Result>((IEnumerable<ApispDySelectFormFieldsByParentFormId_Result>)db.ApispDySelectFormFieldsByParentFormId(model.FormId, currLangId, defLangId));
						list4 = new List<IdKeyValueItemViewModel>();
						list5 = new List<IdKeyValueItemViewModel>();
						if (!string.IsNullOrWhiteSpace(model.ValueDetails))
						{
							list4 = JsonConvert.DeserializeObject<List<IdKeyValueItemViewModel>>(model.ValueDetails);
						}
						if (!string.IsNullOrWhiteSpace(model.ValueDetails_Lang))
						{
							list5 = JsonConvert.DeserializeObject<List<IdKeyValueItemViewModel>>(model.ValueDetails_Lang);
						}
						if (DyForm.IsChecked(model.MasterValueId, currLangId, defLangId))
						{
							message = RS.Get("msgFormIsChecked", text6, RS.TypeMsg);
							status = ServiceResultStatus.Fail;
						}
						else
						{
							if (model.MasterValueId <= 0 || !(model.MasterValueDetailId > 0))
							{
								goto IL_098c;
							}
							int result5 = 0;
							int.TryParse(model.MasterValueDetailId.ToString(), out result5);
							if (!DyForm.SubFormIsChecked(result5, currLangId, defLangId))
							{
								goto IL_098c;
							}
							message = RS.Get("msgFormIsChecked", text6, RS.TypeMsg);
							status = ServiceResultStatus.Fail;
						}
					}
					else
					{
						message = RS.Get("MsgFormNotDefined", text6, RS.TypeMsg);
						status = ServiceResultStatus.Fail;
					}
				}
				else
				{
					message = RS.Get("MsgFormNotDefined", text6, RS.TypeMsg);
					status = ServiceResultStatus.Fail;
				}
			}
			goto end_IL_007e;
			IL_098c:
			if (model.WdSubFormId > 0 && model.WorkflowStepId > 0)
			{
				ApispDySelectFormWorkflowStepWithId_Result apispDySelectFormWorkflowStepWithId_Result = Enumerable.FirstOrDefault<ApispDySelectFormWorkflowStepWithId_Result>((IEnumerable<ApispDySelectFormWorkflowStepWithId_Result>)db.ApispDySelectFormWorkflowStepWithId(model.WorkflowStepId, currLangId, defLangId));
				if (apispDySelectFormWorkflowStepWithId_Result == null)
				{
					goto IL_0cab;
				}
				string text7 = apispDySelectFormWorkflowStepWithId_Result.ReferUserIds ?? "";
				if (string.IsNullOrEmpty(text7))
				{
					goto IL_0cab;
				}
				bool flag2 = false;
				string[] array = text7.Split(new char[1] { '|' });
				if (array != null)
				{
					string[] array2 = array;
					foreach (string text8 in array2)
					{
						if (!string.IsNullOrEmpty(text8))
						{
							int num2 = int.Parse(text8);
							if (num2 == model.UserId)
							{
								flag2 = true;
								break;
							}
						}
					}
				}
				if (flag2 || CRMIdealApi.Classes.Helper.User.IsUserAccess("frmDyForm", "actAllowChangeOtherFieldValue", model.UserId))
				{
					goto IL_0cab;
				}
				string text9 = string.Format(RS.Get("msgErrorYouNotDyFormReferUsers", text6, RS.TypeMsg), apispDySelectFormWorkflowStepWithId_Result.SubForm);
				message = RS.Get("DyFrmUserNotAccess", text6, RS.TypeMsg) + "\n" + text9;
				status = ServiceResultStatus.Fail;
			}
			else
			{
				if (result3 <= 0 || apispDySelectFormAndSubForms_Result == null)
				{
					goto IL_0cab;
				}
				bool flag3 = false;
				int? enableForRollId = apispDySelectFormAndSubForms_Result.EnableForRollId;
				string text10 = apispDySelectFormAndSubForms_Result.EnableForUsersId ?? "";
				if (enableForRollId.HasValue)
				{
					flag3 = enableForRollId == model.RollId;
				}
				else if (!string.IsNullOrEmpty(text10))
				{
					string[] array3 = text10.Split(new char[1] { '|' });
					if (array3 != null)
					{
						string[] array4 = array3;
						foreach (string text11 in array4)
						{
							if (!string.IsNullOrEmpty(text11))
							{
								int num3 = int.Parse(text11);
								if (num3 == model.UserId)
								{
									flag3 = true;
									break;
								}
							}
						}
					}
				}
				else
				{
					flag3 = true;
				}
				if (flag3 || CRMIdealApi.Classes.Helper.User.IsUserAccess("frmDyForm", "actAllowChangeOtherFieldValue", model.UserId))
				{
					goto IL_0cab;
				}
				string text12 = string.Format(RS.Get("msgErrorYouNotDyFormReferUsers", text6, RS.TypeMsg), apispDySelectFormAndSubForms_Result.FormName ?? "");
				message = RS.Get("DyFrmUserNotAccess", text6, RS.TypeMsg) + "\n" + text12;
				status = ServiceResultStatus.Fail;
			}
			goto end_IL_007e;
			IL_14c0:
			List<ApispDySelectFormFieldValuesByMasterValueId_Result> list6 = new List<ApispDySelectFormFieldValuesByMasterValueId_Result>();
			int result6;
			if (result6 > 0)
			{
				list6 = Enumerable.ToList<ApispDySelectFormFieldValuesByMasterValueId_Result>((IEnumerable<ApispDySelectFormFieldValuesByMasterValueId_Result>)db.ApispDySelectFormFieldValuesByMasterValueId(result6, currLangId, defLangId));
			}
			if (list3 == null || !Enumerable.Any<ApispDySelectFormFieldsByParentFormId_Result>((IEnumerable<ApispDySelectFormFieldsByParentFormId_Result>)list3))
			{
				goto IL_1fb0;
			}
			string text13 = "";
			new List<ApispDySelectFormFieldsByParentFormId_Result>();
			List<ApispDySelectFormFieldsByParentFormId_Result> list7;
			if (!(model.WdSubFormId > 0) || !(model.WorkflowStepId > 0))
			{
				list7 = ((result3 <= 0) ? Enumerable.ToList<ApispDySelectFormFieldsByParentFormId_Result>(Enumerable.Where<ApispDySelectFormFieldsByParentFormId_Result>((IEnumerable<ApispDySelectFormFieldsByParentFormId_Result>)list3, (Func<ApispDySelectFormFieldsByParentFormId_Result, bool>)((ApispDySelectFormFieldsByParentFormId_Result m) => m.IsRequired.GetValueOrDefault()))) : Enumerable.ToList<ApispDySelectFormFieldsByParentFormId_Result>(Enumerable.Where<ApispDySelectFormFieldsByParentFormId_Result>((IEnumerable<ApispDySelectFormFieldsByParentFormId_Result>)list3, (Func<ApispDySelectFormFieldsByParentFormId_Result, bool>)((ApispDySelectFormFieldsByParentFormId_Result m) => m.FormId == model.FormId && m.IsRequired.GetValueOrDefault()))));
			}
			else
			{
				ApispDySelectFormWorkflowStepBFCurr_Result wdetail = Enumerable.FirstOrDefault<ApispDySelectFormWorkflowStepBFCurr_Result>((IEnumerable<ApispDySelectFormWorkflowStepBFCurr_Result>)db.ApispDySelectFormWorkflowStepBFCurr(result3, model.WorkflowStepId, result6, model.WdSubFormId, currLangId, defLangId));
				list7 = ((wdetail == null) ? Enumerable.ToList<ApispDySelectFormFieldsByParentFormId_Result>(Enumerable.Where<ApispDySelectFormFieldsByParentFormId_Result>((IEnumerable<ApispDySelectFormFieldsByParentFormId_Result>)list3, (Func<ApispDySelectFormFieldsByParentFormId_Result, bool>)((ApispDySelectFormFieldsByParentFormId_Result m) => m.FormId == model.WdSubFormId && m.IsRequired.GetValueOrDefault()))) : Enumerable.ToList<ApispDySelectFormFieldsByParentFormId_Result>(Enumerable.Where<ApispDySelectFormFieldsByParentFormId_Result>((IEnumerable<ApispDySelectFormFieldsByParentFormId_Result>)list3, (Func<ApispDySelectFormFieldsByParentFormId_Result, bool>)((ApispDySelectFormFieldsByParentFormId_Result m) => m.FormId == wdetail.SubFormId && m.IsRequired.GetValueOrDefault()))));
			}
			if (list7 == null || !Enumerable.Any<ApispDySelectFormFieldsByParentFormId_Result>((IEnumerable<ApispDySelectFormFieldsByParentFormId_Result>)list7))
			{
				goto IL_1fb0;
			}
			bool flag6;
			foreach (IdKeyValueItemViewModel obj2 in list4)
			{
				string ids2 = obj2.Id ?? "";
				int formId2 = 0;
				int fieldId2 = 0;
				long fieldRepeatId2 = 0L;
				if (ids2 != "")
				{
					ids2 = ids2.Replace("_Rep", "");
					string[] array5 = ids2.Split(new char[1] { '_' });
					if (array5 != null)
					{
						formId2 = int.Parse(array5[0]);
						fieldId2 = int.Parse(array5[1]);
						if (array5.Length > 2)
						{
							fieldRepeatId2 = long.Parse(array5[2]);
						}
					}
				}
				ApispDySelectFormFieldsByParentFormId_Result apispDySelectFormFieldsByParentFormId_Result = Enumerable.FirstOrDefault<ApispDySelectFormFieldsByParentFormId_Result>((IEnumerable<ApispDySelectFormFieldsByParentFormId_Result>)list7, (Func<ApispDySelectFormFieldsByParentFormId_Result, bool>)((ApispDySelectFormFieldsByParentFormId_Result m) => m.FormFieldId == fieldId2));
				if (apispDySelectFormFieldsByParentFormId_Result == null)
				{
					continue;
				}
				if (result3 == 0)
				{
					ApispDySelectFormAndSubForms_Result apispDySelectFormAndSubForms_Result2 = Enumerable.FirstOrDefault<ApispDySelectFormAndSubForms_Result>((IEnumerable<ApispDySelectFormAndSubForms_Result>)list2, (Func<ApispDySelectFormAndSubForms_Result, bool>)((ApispDySelectFormAndSubForms_Result m) => m.FormId == formId2));
					if (apispDySelectFormAndSubForms_Result2 != null)
					{
						bool flag4 = true;
						bool flag5 = false;
						if (apispDySelectFormAndSubForms_Result2.EnableForRollId.HasValue)
						{
							flag4 = apispDySelectFormAndSubForms_Result2.EnableForRollId == model.RollId || CRMIdealApi.Classes.Helper.User.IsUserAccess("frmDyForm", "actAllowChangeOtherFieldValue", model.UserId);
						}
						else if (!string.IsNullOrEmpty(apispDySelectFormAndSubForms_Result2.EnableForUsersId))
						{
							string[] array6 = apispDySelectFormAndSubForms_Result2.EnableForUsersId.Split(new char[1] { '|' });
							if (Enumerable.Any<string>((IEnumerable<string>)array6))
							{
								foreach (string item3 in Enumerable.Where<string>((IEnumerable<string>)array6, (Func<string, bool>)((string x) => !string.IsNullOrEmpty(x))))
								{
									if (!flag5)
									{
										if (item3 == model.UserId.ToString() || CRMIdealApi.Classes.Helper.User.IsUserAccess("frmDyForm", "actAllowChangeOtherFieldValue", model.UserId))
										{
											flag4 = true;
											flag5 = true;
										}
										else
										{
											flag4 = false;
										}
									}
								}
							}
						}
						if (!flag4)
						{
							continue;
						}
					}
				}
				ApispDySelectFormFieldsByParentFormId_Result apispDySelectFormFieldsByParentFormId_Result2 = Enumerable.FirstOrDefault<ApispDySelectFormFieldsByParentFormId_Result>((IEnumerable<ApispDySelectFormFieldsByParentFormId_Result>)list3, (Func<ApispDySelectFormFieldsByParentFormId_Result, bool>)((ApispDySelectFormFieldsByParentFormId_Result m) => m.FormFieldId == fieldId2));
				if (apispDySelectFormFieldsByParentFormId_Result2 != null && !string.IsNullOrWhiteSpace(obj2.Value) && apispDySelectFormFieldsByParentFormId_Result2.FieldTypeId.GetValueOrDefault() == 4)
				{
					obj2.Value = obj2.Value.Replace("/", "").Replace("-", "").Replace("\\", "")
						.Replace(" ", "")
						.Replace("_", "");
					string formatetdDate = PersianDate.GetFormatetdDate(obj2.Value.Replace("/", ""));
					if (currLangId == 1065)
					{
						DateTime dateTime = DateTime.Parse(formatetdDate + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
						obj2.Value = dateTime.ToString("yyyyMMdd");
					}
					else if (currLangId == 1025)
					{
						DateTime dateTime2 = DateTime.Parse(formatetdDate + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
						obj2.Value = dateTime2.ToString("yyyyMMdd", new PersianCulture());
					}
					else
					{
						DateTime dateTime3 = DateTime.Parse(formatetdDate + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
						obj2.Value = dateTime3.ToString("yyyyMMdd", new PersianCulture());
					}
				}
				IdKeyValueItemViewModel idKeyValueItemViewModel = Enumerable.FirstOrDefault<IdKeyValueItemViewModel>((IEnumerable<IdKeyValueItemViewModel>)list5, (Func<IdKeyValueItemViewModel, bool>)((IdKeyValueItemViewModel m) => m.Id == ids2));
				List<CommonMultiLanguageViewModel> list8 = new List<CommonMultiLanguageViewModel>();
				if (idKeyValueItemViewModel != null && (apispDySelectFormFieldsByParentFormId_Result2.FieldTypeId.GetValueOrDefault() == 1 || apispDySelectFormFieldsByParentFormId_Result2.FieldTypeId.GetValueOrDefault() == 3))
				{
					if (!string.IsNullOrWhiteSpace(idKeyValueItemViewModel.Value))
					{
						list8 = JsonConvert.DeserializeObject<List<CommonMultiLanguageViewModel>>(idKeyValueItemViewModel.Value);
					}
				}
				else
				{
					list8 = new List<CommonMultiLanguageViewModel>();
					foreach (ApispSelectLanguages_Result lang4 in Enumerable.ToList<ApispSelectLanguages_Result>(Enumerable.Where<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result c) => c.LanguageID != currLangId))))
					{
						string value = "";
						if (apispDySelectFormFieldsByParentFormId_Result2 == null)
						{
							continue;
						}
						switch (apispDySelectFormFieldsByParentFormId_Result2.FieldTypeId)
						{
						case 2:
						case 4:
						case 5:
						case 9:
						case 10:
						case 11:
						case 12:
							value = obj2.Value;
							break;
						case 6:
						case 7:
						case 8:
							if (list6 != null && Enumerable.Any<ApispDySelectFormFieldValuesByMasterValueId_Result>((IEnumerable<ApispDySelectFormFieldValuesByMasterValueId_Result>)list6))
							{
								ApispDySelectFormFieldValuesByMasterValueId_Result apispDySelectFormFieldValuesByMasterValueId_Result = Enumerable.FirstOrDefault<ApispDySelectFormFieldValuesByMasterValueId_Result>((IEnumerable<ApispDySelectFormFieldValuesByMasterValueId_Result>)list6, (Func<ApispDySelectFormFieldValuesByMasterValueId_Result, bool>)((ApispDySelectFormFieldValuesByMasterValueId_Result m) => m.FormId == formId2 && m.FieldId == fieldId2 && m.FieldRepeatId.GetValueOrDefault() == fieldRepeatId2));
								if (apispDySelectFormFieldValuesByMasterValueId_Result == null)
								{
									break;
								}
								new List<CommonMultiLanguageViewModel>();
								if (string.IsNullOrWhiteSpace(apispDySelectFormFieldValuesByMasterValueId_Result.Value_Lang))
								{
									break;
								}
								List<CommonMultiLanguageViewModel> list9 = JsonConvert.DeserializeObject<List<CommonMultiLanguageViewModel>>(apispDySelectFormFieldValuesByMasterValueId_Result.Value_Lang);
								if (list9 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9))
								{
									CommonMultiLanguageViewModel commonMultiLanguageViewModel = Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel m) => m.LanguageId == lang4.LanguageID));
									if (commonMultiLanguageViewModel != null)
									{
										value = ((commonMultiLanguageViewModel.Value == null) ? null : (commonMultiLanguageViewModel.Value ?? ""));
									}
								}
							}
							else
							{
								if (!flag6 || list7 == null || !string.IsNullOrWhiteSpace(value))
								{
									break;
								}
								ApispDySelectFormFieldsByParentFormId_Result apispDySelectFormFieldsByParentFormId_Result3 = Enumerable.FirstOrDefault<ApispDySelectFormFieldsByParentFormId_Result>((IEnumerable<ApispDySelectFormFieldsByParentFormId_Result>)list7, (Func<ApispDySelectFormFieldsByParentFormId_Result, bool>)((ApispDySelectFormFieldsByParentFormId_Result x) => x.FormFieldId == int.Parse(obj2.Id.Split(new char[1] { '_' })[1])));
								if (apispDySelectFormFieldsByParentFormId_Result3 == null || string.IsNullOrWhiteSpace(apispDySelectFormFieldsByParentFormId_Result3.MultiItems))
								{
									break;
								}
								string[] array7 = apispDySelectFormFieldsByParentFormId_Result3.MultiItems.Split(new char[1] { '|' });
								for (int k = 0; k < array7.Length; k++)
								{
									if (!string.IsNullOrWhiteSpace(array7[k]))
									{
										string[] array8 = array7[k].Split(new char[1] { ':' });
										if (array8[1] == obj2.Value)
										{
											value = obj2.Value ?? "";
										}
									}
								}
							}
							break;
						}
						list8.Add(new CommonMultiLanguageViewModel
						{
							Value = value,
							LanguageId = lang4.LanguageID
						});
					}
				}
				list8.Add(new CommonMultiLanguageViewModel
				{
					Value = obj2.Value,
					LanguageId = currLangId
				});
				string value2 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangId)).Value : null);
				if (string.IsNullOrEmpty(value2))
				{
					text13 = text13 + string.Format(RS.Get("ErrorEmpty", text6, RS.TypeMsg), apispDySelectFormFieldsByParentFormId_Result.FieldTitle ?? "") + "\n";
					countError++;
				}
			}
			if (countError <= 0)
			{
				goto IL_1fb0;
			}
			base.ModelState.AddModelError("error", text13);
			message = text13;
			status = ServiceResultStatus.Fail;
			if (flag6)
			{
				try
				{
					Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)db.ApispDyDeleteFormFieldMasterValue(result6));
				}
				catch (Exception e4)
				{
					ErrorSignal.FromCurrentContext().Raise(e4);
				}
			}
			goto end_IL_007e;
			IL_0cab:
			ApispDySelectFormFieldMasterValueWithId_Result apispDySelectFormFieldMasterValueWithId_Result;
			if (!base.ModelState.IsValid)
			{
				message = RS.Get("msgErrorRunFunction", text6, RS.TypeMsg);
				status = ServiceResultStatus.Fail;
			}
			else
			{
				string text14 = "*";
				if (apispDySelectFormAndSubForms_Result != null)
				{
					text14 = ((!string.IsNullOrEmpty(apispDySelectFormAndSubForms_Result.UploadFileExtension)) ? apispDySelectFormAndSubForms_Result.UploadFileExtension : "*");
				}
				if (_003C_003Eo__16._003C_003Ep__1 == null)
				{
					_003C_003Eo__16._003C_003Ep__1 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)83, typeof(ApiDyFormController), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				Func<CallSite, object, bool> target = _003C_003Eo__16._003C_003Ep__1.Target;
				CallSite<Func<CallSite, object, bool>> _003C_003Ep__ = _003C_003Eo__16._003C_003Ep__1;
				if (_003C_003Eo__16._003C_003Ep__0 == null)
				{
					_003C_003Eo__16._003C_003Ep__0 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, (ExpressionType)35, typeof(ApiDyFormController), new CSharpArgumentInfo[2]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.Constant, null)
					}));
				}
				if (target((CallSite)(object)_003C_003Ep__, _003C_003Eo__16._003C_003Ep__0.Target((CallSite)(object)_003C_003Eo__16._003C_003Ep__0, (object)formFileSending, null)))
				{
					foreach (DyFormFieldFilesViewModel item4 in filesInfo)
					{
						MultipartFileData multipartFileData = (MultipartFileData)formFileSending[item4.IndexNumber];
						string text15 = multipartFileData.Headers.ContentDisposition.FileName.Replace("\"", "");
						string dispositionType = multipartFileData.Headers.ContentDisposition.DispositionType;
						long? size = multipartFileData.Headers.ContentDisposition.Size;
						dispositionType.ToLower();
						string text16 = ((text15 != null) ? Path.GetExtension(text15).ToLower() : "");
						if (text14 != "*" && !string.IsNullOrWhiteSpace(text14) && text14.IndexOf(text16, StringComparison.Ordinal) < 0)
						{
							message = string.Format(RS.Get("msgErrorMessageFileExtension", text6, RS.TypeMsg), text14);
							status = ServiceResultStatus.Fail;
						}
						else
						{
							string text17 = (text16 ?? "").ToLower();
							text17 = text17.Replace(".", "");
							if (CRMIdealApi.Classes.Configuration.MaliciousFileExtensions.Contains(text17))
							{
								message = RS.Get("msgErrorFileIsExecuted", text6, RS.TypeMsg);
								status = ServiceResultStatus.Fail;
							}
							else
							{
								int num4 = apispDySelectFormAndSubForms_Result.UploadFileMaxSize.GetValueOrDefault() * 1024;
								if (!(size > num4))
								{
									continue;
								}
								string fileFormatByteSize = CRM.General.IO.File.GetFileFormatByteSize(size.Value);
								string fileFormatByteSize2 = CRM.General.IO.File.GetFileFormatByteSize(num4);
								string format = RS.Get("msgErrorMessageMaxSizeFile", text6, RS.TypeMsg);
								message = string.Format(format, fileFormatByteSize, fileFormatByteSize2);
								status = ServiceResultStatus.Fail;
							}
						}
						goto end_IL_007e;
					}
				}
				result6 = 0;
				apispDySelectFormFieldMasterValueWithId_Result = new ApispDySelectFormFieldMasterValueWithId_Result();
				flag6 = false;
				if (model.MasterValueId > 0)
				{
					apispDySelectFormFieldMasterValueWithId_Result = Enumerable.FirstOrDefault<ApispDySelectFormFieldMasterValueWithId_Result>((IEnumerable<ApispDySelectFormFieldMasterValueWithId_Result>)db.ApispDySelectFormFieldMasterValueWithId(model.MasterValueId, currLangId, defLangId));
				}
				if (!CRMIdealApi.Classes.Helper.User.IsUserAccess("frmDyForm", "actCanEditDyFormNumber", model.UserId))
				{
					model.DyFormNumber = null;
				}
				if (apispDySelectFormFieldMasterValueWithId_Result.FormFieldMasterValueId <= 0)
				{
					flag6 = true;
					mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)db.ApispDyInsertFormFieldMasterValues(model.FormId, model.CompanyId, model.CompanyPersonId, model.ProjectId, model.ConversationId, model.MasterObjectId, model.DetailObjectId, model.SubDetailObjectId, (result3 > 0) ? new int?(result3) : null, model.WorkflowStepId, model.UserId, dt, registerDatePersian, 0, month1, appType, defLangId, VersionConfig.CurrentDyFormFieldMasterValuesTableVersion, model.CenterId, model.CenterCode));
					if (mct_Result != null)
					{
						int.TryParse(mct_Result.Result.ToString(), out result6);
					}
					if (result3 == 0 && result6 > 0)
					{
						db.ApispDyInsertUpdateFormFieldMasterValueDetails(1, result6, model.FormId, model.UserId, dt, registerDatePersian, 0, month1, appType, defLangId);
					}
					goto IL_14c0;
				}
				if (!model.DyFormNumber.HasValue)
				{
					goto IL_11bd;
				}
				ApispDyCheckDuplicateDyFormNumber_Result apispDyCheckDuplicateDyFormNumber_Result = Enumerable.FirstOrDefault<ApispDyCheckDuplicateDyFormNumber_Result>((IEnumerable<ApispDyCheckDuplicateDyFormNumber_Result>)db.ApispDyCheckDuplicateDyFormNumber(model.DyFormNumber.GetValueOrDefault(), apispDySelectFormFieldMasterValueWithId_Result.FormFieldMasterValueId, model.FormId, model.CenterId.GetValueOrDefault(), model.CenterCode));
				if (apispDyCheckDuplicateDyFormNumber_Result == null)
				{
					goto IL_11bd;
				}
				message = RS.Get("DyFormNumberIsRepeated", text6, RS.TypeMsg);
				status = ServiceResultStatus.Fail;
			}
			goto end_IL_007e;
			IL_246d:
			List<FieldValueViewModel> list10 = new List<FieldValueViewModel>();
			List<CommonMultiLanguageViewModel> list11 = new List<CommonMultiLanguageViewModel>();
			foreach (IdKeyValueItemViewModel obj in list4)
			{
				string ids = obj.Id ?? "";
				int formId = 0;
				int fieldId = 0;
				long fieldRepeatId = 0L;
				if (ids != "")
				{
					ids = ids.Replace("_Rep", "");
					string[] array9 = ids.Split(new char[1] { '_' });
					if (array9 != null)
					{
						formId = int.Parse(array9[0]);
						fieldId = int.Parse(array9[1]);
						if (array9.Length > 2)
						{
							fieldRepeatId = long.Parse(array9[2]);
						}
					}
				}
				ApispDySelectFormFieldsByParentFormId_Result fld = Enumerable.FirstOrDefault<ApispDySelectFormFieldsByParentFormId_Result>((IEnumerable<ApispDySelectFormFieldsByParentFormId_Result>)list3, (Func<ApispDySelectFormFieldsByParentFormId_Result, bool>)((ApispDySelectFormFieldsByParentFormId_Result m) => m.FormFieldId == fieldId));
				if (fld != null && !string.IsNullOrEmpty(obj.Value) && fld.FieldTypeId.GetValueOrDefault() == 4)
				{
					obj.Value = obj.Value.Replace("/", "").Replace("-", "").Replace("\\", "")
						.Replace(" ", "")
						.Replace("_", "");
					string formatetdDate2 = PersianDate.GetFormatetdDate(obj.Value.Replace("/", ""));
					if (currLangId == 1065)
					{
						DateTime dateTime4 = DateTime.Parse(formatetdDate2 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
						obj.Value = dateTime4.ToString("yyyyMMdd");
					}
					else if (currLangId == 1025)
					{
						DateTime dateTime5 = DateTime.Parse(formatetdDate2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
						obj.Value = dateTime5.ToString("yyyyMMdd", new PersianCulture());
					}
					else
					{
						DateTime dateTime6 = DateTime.Parse(formatetdDate2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
						obj.Value = dateTime6.ToString("yyyyMMdd", new PersianCulture());
					}
				}
				if (_003C_003Eo__16._003C_003Ep__6 == null)
				{
					_003C_003Eo__16._003C_003Ep__6 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)83, typeof(ApiDyFormController), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				Func<CallSite, object, bool> target2 = _003C_003Eo__16._003C_003Ep__6.Target;
				CallSite<Func<CallSite, object, bool>> _003C_003Ep__2 = _003C_003Eo__16._003C_003Ep__6;
				bool flag7 = fld != null;
				object arg;
				if (flag7)
				{
					if (_003C_003Eo__16._003C_003Ep__5 == null)
					{
						_003C_003Eo__16._003C_003Ep__5 = CallSite<Func<CallSite, bool, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.BinaryOperationLogical, (ExpressionType)2, typeof(ApiDyFormController), new CSharpArgumentInfo[2]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
						}));
					}
					Func<CallSite, bool, object, object> target3 = _003C_003Eo__16._003C_003Ep__5.Target;
					CallSite<Func<CallSite, bool, object, object>> _003C_003Ep__3 = _003C_003Eo__16._003C_003Ep__5;
					if (_003C_003Eo__16._003C_003Ep__4 == null)
					{
						_003C_003Eo__16._003C_003Ep__4 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, (ExpressionType)35, typeof(ApiDyFormController), new CSharpArgumentInfo[2]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.Constant, null)
						}));
					}
					arg = target3((CallSite)(object)_003C_003Ep__3, flag7, _003C_003Eo__16._003C_003Ep__4.Target((CallSite)(object)_003C_003Eo__16._003C_003Ep__4, (object)formFileSending, null));
				}
				else
				{
					arg = flag7;
				}
				if (target2((CallSite)(object)_003C_003Ep__2, arg))
				{
					DyFormFieldFilesViewModel dyFormFieldFilesViewModel = Enumerable.FirstOrDefault<DyFormFieldFilesViewModel>((IEnumerable<DyFormFieldFilesViewModel>)filesInfo, (Func<DyFormFieldFilesViewModel, bool>)((DyFormFieldFilesViewModel x) => x.FormId == fld.FormId && x.FieldId == fld.FormFieldId));
					if (dyFormFieldFilesViewModel != null)
					{
						try
						{
							MultipartFileData multipartFileData2 = formFileSending[dyFormFieldFilesViewModel.IndexNumber];
							if (!string.IsNullOrWhiteSpace(obj.Value) && fld.FieldTypeId.GetValueOrDefault() == 12 && multipartFileData2 != null)
							{
								string docTime = dt.ToString("HH:mm:ss");
								int result7 = 0;
								FacadeFTP facadeFTP = new FacadeFTP(CRMIdealApi.Classes.Configuration.FacadeFtp);
								string text18 = (model.CompanyId.HasValue ? model.CompanyId.ToString() : (CRMIdealApi.Classes.Configuration.DyDirectoryPath + fld.FormId));
								string folderName = (model.CompanyId.HasValue ? model.CompanyId.ToString() : fld.FormId.ToString());
								string title = dyFormFieldFilesViewModel.Title;
								string title_Lang = "";
								List<CommonMultiLanguageViewModel> list12 = new List<CommonMultiLanguageViewModel>();
								foreach (ApispSelectLanguages_Result item5 in Enumerable.ToList<ApispSelectLanguages_Result>(Enumerable.Where<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result c) => c.LanguageID != defLangId))))
								{
									list12.Add(new CommonMultiLanguageViewModel
									{
										Value = title,
										LanguageId = item5.LanguageID
									});
								}
								if (list12 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12))
								{
									title_Lang = JsonConvert.SerializeObject(list12);
								}
								ApispInsertFilesDirectory_Result apispInsertFilesDirectory_Result = Enumerable.FirstOrDefault<ApispInsertFilesDirectory_Result>((IEnumerable<ApispInsertFilesDirectory_Result>)db.ApispInsertFilesDirectory(0, -65, model.CompanyId, model.CompanyPersonId, model.ProjectId, title, title_Lang, folderName, "", "", "", model.UserId, 0, month1, dt, registerDatePersian, dt, registerDatePersian, PersianDate.GetNumberWeekOfDay(dt.ToString("yyyy/MM/dd", new PersianCulture())).ToString(), docTime, result6, appType, defLangId, null, formId, fieldId, "", null, null));
								if (apispInsertFilesDirectory_Result != null)
								{
									int.TryParse(apispInsertFilesDirectory_Result.FileId.ToString(), out result7);
								}
								if (result7 > 0)
								{
									string pathFtp = CRMIdealApi.Classes.Configuration.PathFtp;
									string userNameFtp = CRMIdealApi.Classes.Configuration.UserNameFtp;
									string passwordFtp = CRMIdealApi.Classes.Configuration.PasswordFtp;
									bool usePassiveFtp = CRMIdealApi.Classes.Configuration.UsePassiveFtp;
									string[] array10 = title.Split(new char[1] { '.' });
									string text19 = CRMIdealApi.Classes.Configuration.MainDirectoryPath + text18 + "/";
									string text20 = text19 + (text19.EndsWith("/") ? "" : "/");
									string text21 = text20.Split(new char[1] { '/' })[^2];
									string destination = text20.Replace(text21 + "/", "");
									bool flag8;
									if (!model.CompanyId.HasValue)
									{
										flag8 = facadeFTP.ExistsDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, CRMIdealApi.Classes.Configuration.MainDirectoryPath, CRMIdealApi.Classes.Configuration.DyDirectoryPath, usePassiveFtp);
										if (!flag8)
										{
											flag8 = facadeFTP.CreateDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, CRMIdealApi.Classes.Configuration.MainDirectoryPath, CRMIdealApi.Classes.Configuration.DyDirectoryPath, usePassiveFtp);
										}
									}
									else
									{
										flag8 = true;
									}
									bool flag9 = facadeFTP.ExistsDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, destination, text21, usePassiveFtp);
									if (!flag9)
									{
										flag9 = facadeFTP.CreateDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, destination, text21, usePassiveFtp);
									}
									if (flag9 && flag8)
									{
										int num5 = result6;
										string text22 = num5 + "-" + result7 + "." + array10[^1];
										string localFileName = multipartFileData2.LocalFileName;
										if (!string.IsNullOrWhiteSpace(localFileName))
										{
											facadeFTP.UploadFtpFormTable(pathFtp, userNameFtp, passwordFtp, text20 + text22, localFileName, usePassiveFtp);
											text19 = pathFtp + text20 + text22;
											string fileName = text22;
											text19 = text19.Trim().Replace(pathFtp, "");
											Enumerable.FirstOrDefault<ApispInsertFilesDirectory_Result>((IEnumerable<ApispInsertFilesDirectory_Result>)db.ApispInsertFilesDirectory(result7, -65, model.CompanyId, model.CompanyPersonId, model.ProjectId, title, title_Lang, folderName, fileName, text19, "", model.UserId, 0, month1, dt, registerDatePersian, dt, registerDatePersian, PersianDate.GetNumberWeekOfDay(dt.ToString("yyyy/MM/dd", new PersianCulture())).ToString(), docTime, result6, appType, defLangId, null, formId, fieldId, "", null, null));
											obj.Value = result7.ToString();
										}
										else
										{
											try
											{
												db.ApispDeleteCrmFilesDirectory(result7);
											}
											catch (Exception e5)
											{
												ErrorSignal.FromCurrentContext().Raise(e5);
											}
											obj.Value = "";
										}
									}
									else
									{
										try
										{
											db.ApispDeleteCrmFilesDirectory(result7);
										}
										catch (Exception e6)
										{
											ErrorSignal.FromCurrentContext().Raise(e6);
										}
										obj.Value = "";
									}
								}
								else
								{
									obj.Value = "";
								}
							}
						}
						catch (Exception)
						{
						}
					}
				}
				IdKeyValueItemViewModel idKeyValueItemViewModel2 = Enumerable.FirstOrDefault<IdKeyValueItemViewModel>((IEnumerable<IdKeyValueItemViewModel>)list5, (Func<IdKeyValueItemViewModel, bool>)((IdKeyValueItemViewModel m) => m.Id == ids));
				List<CommonMultiLanguageViewModel> list13 = new List<CommonMultiLanguageViewModel>();
				if (idKeyValueItemViewModel2 != null && (fld.FieldTypeId.GetValueOrDefault() == 1 || fld.FieldTypeId.GetValueOrDefault() == 3))
				{
					if (!string.IsNullOrEmpty(idKeyValueItemViewModel2.Value))
					{
						list13 = JsonConvert.DeserializeObject<List<CommonMultiLanguageViewModel>>(idKeyValueItemViewModel2.Value);
					}
				}
				else
				{
					list13 = new List<CommonMultiLanguageViewModel>();
					foreach (ApispSelectLanguages_Result lang3 in Enumerable.ToList<ApispSelectLanguages_Result>(Enumerable.Where<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result c) => c.LanguageID != currLangId))))
					{
						string value3 = "";
						if (fld == null)
						{
							continue;
						}
						switch (fld.FieldTypeId)
						{
						case 2:
						case 4:
						case 5:
						case 9:
						case 10:
						case 11:
						case 12:
							value3 = obj.Value;
							break;
						case 6:
						case 7:
						case 8:
							if (list6 != null && Enumerable.Any<ApispDySelectFormFieldValuesByMasterValueId_Result>((IEnumerable<ApispDySelectFormFieldValuesByMasterValueId_Result>)list6))
							{
								ApispDySelectFormFieldValuesByMasterValueId_Result apispDySelectFormFieldValuesByMasterValueId_Result2 = Enumerable.FirstOrDefault<ApispDySelectFormFieldValuesByMasterValueId_Result>((IEnumerable<ApispDySelectFormFieldValuesByMasterValueId_Result>)list6, (Func<ApispDySelectFormFieldValuesByMasterValueId_Result, bool>)((ApispDySelectFormFieldValuesByMasterValueId_Result m) => m.FormId == formId && m.FieldId == fieldId && m.FieldRepeatId.GetValueOrDefault() == fieldRepeatId));
								if (apispDySelectFormFieldValuesByMasterValueId_Result2 == null)
								{
									break;
								}
								new List<CommonMultiLanguageViewModel>();
								if (string.IsNullOrWhiteSpace(apispDySelectFormFieldValuesByMasterValueId_Result2.Value_Lang))
								{
									break;
								}
								List<CommonMultiLanguageViewModel> list14 = JsonConvert.DeserializeObject<List<CommonMultiLanguageViewModel>>(apispDySelectFormFieldValuesByMasterValueId_Result2.Value_Lang);
								if (list14 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14))
								{
									CommonMultiLanguageViewModel commonMultiLanguageViewModel2 = Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel m) => m.LanguageId == lang3.LanguageID));
									if (commonMultiLanguageViewModel2 != null)
									{
										value3 = ((commonMultiLanguageViewModel2.Value == null) ? null : (commonMultiLanguageViewModel2.Value ?? ""));
									}
								}
							}
							else
							{
								if (!flag6 || list3 == null || !string.IsNullOrWhiteSpace(value3))
								{
									break;
								}
								ApispDySelectFormFieldsByParentFormId_Result apispDySelectFormFieldsByParentFormId_Result4 = Enumerable.FirstOrDefault<ApispDySelectFormFieldsByParentFormId_Result>((IEnumerable<ApispDySelectFormFieldsByParentFormId_Result>)list3, (Func<ApispDySelectFormFieldsByParentFormId_Result, bool>)((ApispDySelectFormFieldsByParentFormId_Result x) => x.FormFieldId == int.Parse(obj.Id.Split(new char[1] { '_' })[1])));
								if (apispDySelectFormFieldsByParentFormId_Result4 == null || string.IsNullOrWhiteSpace(apispDySelectFormFieldsByParentFormId_Result4.MultiItems))
								{
									break;
								}
								string[] array11 = apispDySelectFormFieldsByParentFormId_Result4.MultiItems.Split(new char[1] { '|' });
								for (int l = 0; l < array11.Length; l++)
								{
									if (!string.IsNullOrWhiteSpace(array11[l]))
									{
										string[] array12 = array11[l].Split(new char[1] { ':' });
										if (array12[1] == obj.Value)
										{
											value3 = obj.Value ?? "";
										}
									}
								}
							}
							break;
						}
						list13.Add(new CommonMultiLanguageViewModel
						{
							Value = value3,
							LanguageId = lang3.LanguageID
						});
					}
				}
				list13.Add(new CommonMultiLanguageViewModel
				{
					Value = obj.Value,
					LanguageId = currLangId
				});
				string value4 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangId)).Value : null);
				if (!string.IsNullOrEmpty(value4) && fld.FieldTypeId.GetValueOrDefault() != 1)
				{
					fld.FieldTypeId.GetValueOrDefault();
					_ = 3;
				}
				if (result6 <= 0)
				{
					continue;
				}
				string value5 = "";
				if (list6 != null && list6.Count > 0)
				{
					ApispDySelectFormFieldValuesByMasterValueId_Result val = Enumerable.FirstOrDefault<ApispDySelectFormFieldValuesByMasterValueId_Result>((IEnumerable<ApispDySelectFormFieldValuesByMasterValueId_Result>)list6, (Func<ApispDySelectFormFieldValuesByMasterValueId_Result, bool>)((ApispDySelectFormFieldValuesByMasterValueId_Result m) => m.FormId == formId && m.FieldId == fieldId && m.FieldRepeatId.GetValueOrDefault() == fieldRepeatId));
					if (val != null)
					{
						ApispDySelectFormAndSubForms_Result apispDySelectFormAndSubForms_Result3 = Enumerable.FirstOrDefault<ApispDySelectFormAndSubForms_Result>((IEnumerable<ApispDySelectFormAndSubForms_Result>)list2, (Func<ApispDySelectFormAndSubForms_Result, bool>)((ApispDySelectFormAndSubForms_Result m) => m.FormId == val.FormId));
						if (apispDySelectFormAndSubForms_Result3 != null)
						{
							bool flag10 = true;
							bool flag11 = false;
							if (result3 == 0 || (model.WorkflowStepId.GetValueOrDefault() == 0 && model.WdSubFormId.GetValueOrDefault() == 0 && model.FormId == apispDySelectFormAndSubForms_Result3.FormId))
							{
								if (apispDySelectFormAndSubForms_Result3.EnableForRollId.HasValue)
								{
									flag10 = apispDySelectFormAndSubForms_Result3.EnableForRollId == model.RollId || CRMIdealApi.Classes.Helper.User.IsUserAccess("frmDyForm", "actAllowChangeOtherFieldValue", model.UserId);
								}
								else if (!string.IsNullOrWhiteSpace(apispDySelectFormAndSubForms_Result3.EnableForUsersId))
								{
									string[] array13 = apispDySelectFormAndSubForms_Result3.EnableForUsersId.Split(new char[1] { '|' });
									if (Enumerable.Any<string>((IEnumerable<string>)array13))
									{
										foreach (string item6 in Enumerable.Where<string>((IEnumerable<string>)array13, (Func<string, bool>)((string x) => !string.IsNullOrEmpty(x))))
										{
											if (!flag11)
											{
												if (item6 == model.UserId.ToString() || CRMIdealApi.Classes.Helper.User.IsUserAccess("frmDyForm", "actAllowChangeOtherFieldValue", model.UserId))
												{
													flag10 = true;
													flag11 = true;
												}
												else
												{
													flag10 = false;
												}
											}
										}
									}
								}
							}
							else if (model.WorkflowStepId > 0 && model.WdSubFormId > 0 && model.WdSubFormId == apispDySelectFormAndSubForms_Result3.FormId)
							{
								ApispDySelectFormWorkflowStepWithId_Result apispDySelectFormWorkflowStepWithId_Result2 = Enumerable.FirstOrDefault<ApispDySelectFormWorkflowStepWithId_Result>((IEnumerable<ApispDySelectFormWorkflowStepWithId_Result>)db.ApispDySelectFormWorkflowStepWithId(model.WorkflowStepId, currLangId, defLangId));
								if (apispDySelectFormWorkflowStepWithId_Result2 != null)
								{
									string text23 = apispDySelectFormWorkflowStepWithId_Result2.ReferUserIds ?? "";
									if (!string.IsNullOrEmpty(text23))
									{
										bool flag12 = false;
										string[] array14 = text23.Split(new char[1] { '|' });
										if (array14 != null)
										{
											string[] array15 = array14;
											foreach (string text24 in array15)
											{
												if (!string.IsNullOrEmpty(text24))
												{
													int num6 = int.Parse(text24);
													if (num6 == model.UserId)
													{
														flag12 = true;
														break;
													}
												}
											}
										}
										if (!flag12 && !CRMIdealApi.Classes.Helper.User.IsUserAccess("frmDyForm", "actAllowChangeOtherFieldValue", model.UserId))
										{
											flag10 = false;
										}
									}
								}
							}
							else
							{
								flag10 = false;
							}
							if (!flag10)
							{
								List<CommonMultiLanguageViewModel> list15 = new List<CommonMultiLanguageViewModel>();
								list15.Add(new CommonMultiLanguageViewModel
								{
									Value = (val.Value ?? ""),
									LanguageId = currLangId
								});
								if (!string.IsNullOrWhiteSpace(val.Value_Lang))
								{
									List<CommonMultiLanguageViewModel> collection = JsonConvert.DeserializeObject<List<CommonMultiLanguageViewModel>>(val.Value_Lang);
									list15.AddRange(collection);
								}
								List<CommonMultiLanguageViewModel> list16 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list15, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel m) => m.LanguageId != defLangId)));
								if (list16 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list16))
								{
									JsonConvert.SerializeObject(list16);
								}
								value5 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list15, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list15, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)).Value : null);
							}
							else
							{
								List<CommonMultiLanguageViewModel> list17 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel m) => m.LanguageId != defLangId)));
								if (list17 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list17))
								{
									JsonConvert.SerializeObject(list17);
								}
								value5 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)).Value : null);
							}
						}
					}
					else
					{
						List<CommonMultiLanguageViewModel> list18 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel m) => m.LanguageId != defLangId)));
						if (list18 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list18))
						{
							JsonConvert.SerializeObject(list18);
						}
						value5 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)).Value : null);
					}
				}
				else
				{
					List<CommonMultiLanguageViewModel> list19 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel m) => m.LanguageId != defLangId)));
					if (list19 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list19))
					{
						JsonConvert.SerializeObject(list19);
					}
					value5 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)).Value : null);
				}
				FieldValueViewModel fieldValueViewModel = new FieldValueViewModel();
				fieldValueViewModel.FormId = formId;
				fieldValueViewModel.FieldId = fieldId;
				fieldValueViewModel.FieldRepeatId = fieldRepeatId;
				fieldValueViewModel.Value = value5;
				FieldValueViewModel item = fieldValueViewModel;
				list10.Add(item);
				new List<CommonMultiLanguageViewModel>();
				if (list13 == null || !Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13))
				{
					continue;
				}
				foreach (ApispSelectLanguages_Result lang2 in Enumerable.ToList<ApispSelectLanguages_Result>(Enumerable.Where<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result c) => c.LanguageID != defLangId))))
				{
					CommonMultiLanguageViewModel commonMultiLanguageViewModel3 = new CommonMultiLanguageViewModel();
					commonMultiLanguageViewModel3.LanguageId = lang2.LanguageID;
					fieldValueViewModel = new FieldValueViewModel();
					fieldValueViewModel.FormId = formId;
					fieldValueViewModel.FieldId = fieldId;
					fieldValueViewModel.FieldRepeatId = fieldRepeatId;
					fieldValueViewModel.Value = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang2.LanguageID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang2.LanguageID)).Value : "");
					FieldValueViewModel value6 = fieldValueViewModel;
					commonMultiLanguageViewModel3.Value = JsonConvert.SerializeObject(value6);
					list11.Add(commonMultiLanguageViewModel3);
				}
			}
			string value7 = "";
			string valueLang = "";
			if (list10 != null && Enumerable.Any<FieldValueViewModel>((IEnumerable<FieldValueViewModel>)list10))
			{
				value7 = JsonConvert.SerializeObject(Enumerable.ToList<FieldValueViewModel>((IEnumerable<FieldValueViewModel>)list10));
			}
			if (list11 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11))
			{
				List<CommonMultiLanguageViewModel> list20 = new List<CommonMultiLanguageViewModel>();
				foreach (ApispSelectLanguages_Result lang in Enumerable.ToList<ApispSelectLanguages_Result>(Enumerable.Where<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result c) => c.LanguageID != defLangId))))
				{
					CommonMultiLanguageViewModel commonMultiLanguageViewModel4 = new CommonMultiLanguageViewModel();
					commonMultiLanguageViewModel4.LanguageId = lang.LanguageID;
					List<FieldValueViewModel> list21 = new List<FieldValueViewModel>();
					List<CommonMultiLanguageViewModel> list22 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel m) => m.LanguageId == lang.LanguageID)));
					if (list22 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list22))
					{
						foreach (CommonMultiLanguageViewModel item7 in list22)
						{
							if (!string.IsNullOrWhiteSpace(item7.Value))
							{
								FieldValueViewModel fieldValueViewModel2 = JsonConvert.DeserializeObject<FieldValueViewModel>(item7.Value);
								if (fieldValueViewModel2 != null)
								{
									FieldValueViewModel fieldValueViewModel = new FieldValueViewModel();
									fieldValueViewModel.FormId = fieldValueViewModel2.FormId;
									fieldValueViewModel.FieldId = fieldValueViewModel2.FieldId;
									fieldValueViewModel.FieldRepeatId = fieldValueViewModel2.FieldRepeatId;
									fieldValueViewModel.Value = fieldValueViewModel2.Value;
									FieldValueViewModel item2 = fieldValueViewModel;
									list21.Add(item2);
								}
							}
						}
					}
					commonMultiLanguageViewModel4.Value = JsonConvert.SerializeObject(Enumerable.ToList<FieldValueViewModel>((IEnumerable<FieldValueViewModel>)list21));
					list20.Add(commonMultiLanguageViewModel4);
				}
				valueLang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list20));
			}
			bool flag15;
			int num10;
			string mainFormReferUserIs;
			if (list6 != null && Enumerable.Any<ApispDySelectFormFieldValuesByMasterValueId_Result>((IEnumerable<ApispDySelectFormFieldValuesByMasterValueId_Result>)list6))
			{
				int result8 = 0;
				ApispDySelectFormFieldValuesByMasterValueId_Result apispDySelectFormFieldValuesByMasterValueId_Result3 = Enumerable.FirstOrDefault<ApispDySelectFormFieldValuesByMasterValueId_Result>((IEnumerable<ApispDySelectFormFieldValuesByMasterValueId_Result>)list6);
				if (apispDySelectFormFieldValuesByMasterValueId_Result3 != null)
				{
					int.TryParse(apispDySelectFormFieldValuesByMasterValueId_Result3.FormFieldValueId.ToString(), out result8);
				}
				mct_Result mct_Result2 = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)db.ApispDyUpdateFormFieldValues(result8, value7, valueLang, model.UserId, dt, registerDatePersian, 0, month1, appType, defLangId));
				int result9 = 0;
				if (mct_Result2 != null)
				{
					int.TryParse(mct_Result2.Result.ToString(), out result9);
				}
				if (result9 == -1)
				{
					message = string.Format(Messages.ResourceManager.GetString("ErrorEmpty", new CultureInfo(text6)), Labels.ResourceManager.GetString("JsonValue", new CultureInfo(text6)));
					status = ServiceResultStatus.Error;
				}
				else
				{
					_ = 0;
					message = RS.Get("msgErrorInSaveInfo", text6, RS.TypeMsg);
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				mct_Result mct_Result3 = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)db.ApispDyInsertFormFieldValues(result6, model.FormId, null, model.CompanyId, model.CompanyPersonId, model.ProjectId, model.ConversationId, model.MasterObjectId, model.DetailObjectId, model.SubDetailObjectId, value7, valueLang, model.UserId, dt, registerDatePersian, 0, month1, appType, defLangId));
				int result10 = 0;
				if (mct_Result3 != null)
				{
					int.TryParse(mct_Result3.Result.ToString(), out result10);
				}
				if (result10 <= 0)
				{
					message = RS.Get("msgErrorInSaveInfo", text6, RS.TypeMsg);
					status = ServiceResultStatus.Error;
					db.ApispDyDeleteFormFieldMasterValue(result6);
				}
				else
				{
					if (result6 > 0)
					{
						if (_003C_003Eo__16._003C_003Ep__10 == null)
						{
							_003C_003Eo__16._003C_003Ep__10 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)83, typeof(ApiDyFormController), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						Func<CallSite, object, bool> target4 = _003C_003Eo__16._003C_003Ep__10.Target;
						CallSite<Func<CallSite, object, bool>> _003C_003Ep__4 = _003C_003Eo__16._003C_003Ep__10;
						if (_003C_003Eo__16._003C_003Ep__9 == null)
						{
							_003C_003Eo__16._003C_003Ep__9 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, (ExpressionType)35, typeof(ApiDyFormController), new CSharpArgumentInfo[2]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.Constant, null)
							}));
						}
						if (target4((CallSite)(object)_003C_003Ep__4, _003C_003Eo__16._003C_003Ep__9.Target((CallSite)(object)_003C_003Eo__16._003C_003Ep__9, (object)formFileSending, null)))
						{
							int num7 = 1;
							int num8 = 0;
							foreach (DyFormFieldFilesViewModel item8 in filesInfo)
							{
								MultipartFileData multipartFileData3 = (MultipartFileData)formFileSending[item8.IndexNumber];
								string fileName2 = Path.GetFileName(multipartFileData3.LocalFileName);
								FacadeFTP facadeFTP2 = new FacadeFTP(CRMIdealApi.Classes.Configuration.FacadeFtp);
								string text25 = (model.CompanyId.HasValue ? model.CompanyId.ToString() : (CRMIdealApi.Classes.Configuration.DyDirectoryPath + item8.FormId));
								string folderName2 = (model.CompanyId.HasValue ? model.CompanyId.ToString() : item8.FormId.ToString());
								num8 += 5;
								num7++;
								string title_Lang2 = "";
								List<CommonMultiLanguageViewModel> list23 = new List<CommonMultiLanguageViewModel>();
								foreach (ApispSelectLanguages_Result item9 in Enumerable.ToList<ApispSelectLanguages_Result>(Enumerable.Where<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result c) => c.LanguageID != defLangId))))
								{
									list23.Add(new CommonMultiLanguageViewModel
									{
										Value = fileName2,
										LanguageId = item9.LanguageID
									});
								}
								if (list23 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list23))
								{
									title_Lang2 = JsonConvert.SerializeObject(list23);
								}
								string docTime2 = dt.ToString("HH:mm:ss");
								int result11 = 0;
								ApispInsertFilesDirectory_Result apispInsertFilesDirectory_Result2 = Enumerable.FirstOrDefault<ApispInsertFilesDirectory_Result>((IEnumerable<ApispInsertFilesDirectory_Result>)db.ApispInsertFilesDirectory(0, -60, model.CompanyId, model.CompanyPersonId, model.ProjectId, fileName2, title_Lang2, folderName2, "", "", "", model.UserId, 0, month1, dt, registerDatePersian, dt, registerDatePersian, PersianDate.GetNumberWeekOfDay(dt.ToString("yyyy/MM/dd", new PersianCulture())).ToString(), docTime2, result6, appType, defLangId, num8, item8.FormId, null, "", null, null));
								if (apispInsertFilesDirectory_Result2 != null)
								{
									int.TryParse(apispInsertFilesDirectory_Result2.FileId.ToString(), out result11);
								}
								if (result11 <= 0)
								{
									continue;
								}
								string[] array16 = fileName2.Split(new char[1] { '.' });
								string text26 = CRMIdealApi.Classes.Configuration.MainDirectoryPath + text25 + "/";
								string text27 = text26 + (text26.EndsWith("/") ? "" : "/");
								string text28 = text27.Split(new char[1] { '/' })[^2];
								string text29 = text27.Replace(text28 + "/", "");
								string pathFtp2 = CRMIdealApi.Classes.Configuration.PathFtp;
								string userNameFtp2 = CRMIdealApi.Classes.Configuration.UserNameFtp;
								string passwordFtp2 = CRMIdealApi.Classes.Configuration.PasswordFtp;
								bool usePassiveFtp2 = CRMIdealApi.Classes.Configuration.UsePassiveFtp;
								bool flag13;
								if (!model.CompanyId.HasValue)
								{
									flag13 = facadeFTP2.ExistsDirectoryInFtp(pathFtp2, userNameFtp2, passwordFtp2, CRMIdealApi.Classes.Configuration.MainDirectoryPath, CRMIdealApi.Classes.Configuration.DyDirectoryPath, usePassiveFtp2);
									if (!flag13)
									{
										flag13 = facadeFTP2.CreateDirectoryInFtp(pathFtp2, userNameFtp2, passwordFtp2, CRMIdealApi.Classes.Configuration.MainDirectoryPath, CRMIdealApi.Classes.Configuration.DyDirectoryPath, usePassiveFtp2);
									}
								}
								else
								{
									flag13 = true;
								}
								bool flag14 = facadeFTP2.ExistsDirectoryInFtp(pathFtp2, userNameFtp2, passwordFtp2, text29, text28, usePassiveFtp2);
								if (!flag14)
								{
									flag14 = facadeFTP2.CreateDirectoryInFtp(pathFtp2, userNameFtp2, passwordFtp2, text29, text28, usePassiveFtp2);
								}
								if (flag14 && flag13)
								{
									int num9 = result6;
									string text30 = num9 + "-" + result11 + "." + array16[^1];
									if (facadeFTP2.UploadFtpFormTable(pathFtp2, userNameFtp2, passwordFtp2, text27 + text30, multipartFileData3.LocalFileName, usePassiveFtp2))
									{
										text26 = pathFtp2 + text27 + text30;
										string fileName3 = text30;
										text26 = text26.Trim().Replace(pathFtp2, "");
										Enumerable.FirstOrDefault<ApispInsertFilesDirectory_Result>((IEnumerable<ApispInsertFilesDirectory_Result>)db.ApispInsertFilesDirectory(result11, -60, model.CompanyId, model.CompanyPersonId, model.ProjectId, fileName2, title_Lang2, folderName2, fileName3, text26, "", model.UserId, 0, month1, dt, registerDatePersian, dt, registerDatePersian, PersianDate.GetNumberWeekOfDay(dt.ToString("yyyy/MM/dd", new PersianCulture())).ToString(), docTime2, result6, appType, defLangId, num8, item8.FormId, null, "", null, null));
										continue;
									}
									string message2 = RS.Get("msgErrorUploadingFileInFtp", text6, RS.TypeMsg) + "  -  hostname: " + pathFtp2 + " ,username: " + userNameFtp2 + " ,destination: " + text29 + " ,directoryName: " + text28;
									Exception e7 = new Exception(message2);
									ErrorSignal.FromCurrentContext().Raise(e7);
									base.ModelState.AddModelError("error", RS.Get("frmErrorInSendingFile", text6, RS.TypeMsg));
									try
									{
										db.ApispDeleteCrmFilesDirectory(result11);
									}
									catch (Exception e8)
									{
										ErrorSignal.FromCurrentContext().Raise(e8);
									}
									message = RS.Get("frmErrorInSendingFile", text6, RS.TypeMsg);
									status = ServiceResultStatus.Fail;
								}
								else
								{
									string message3 = RS.Get("msgErrorCreateFolderInFtp", text6, RS.TypeMsg) + " -  hostname: " + pathFtp2 + " ,username: " + userNameFtp2 + " ,destination: " + text29 + " ,directoryName: " + text28;
									Exception e9 = new Exception(message3);
									ErrorSignal.FromCurrentContext().Raise(e9);
									try
									{
										db.ApispDeleteCrmFilesDirectory(result11);
									}
									catch (Exception e10)
									{
										ErrorSignal.FromCurrentContext().Raise(e10);
									}
									message = RS.Get("frmErrorInSendingFile", text6, RS.TypeMsg);
									status = ServiceResultStatus.Fail;
								}
								goto end_IL_007e;
							}
						}
					}
					message = ((list6 == null || list6.Count <= 0 || result6 <= 0) ? RS.Get("frmFormBaseInsertSuccessFulMessage", text6, RS.TypeMsg) : RS.Get("frmFormBaseEditSuccessFulMessage", text6, RS.TypeMsg));
					model.MasterValueId = result6;
					result6.ToString();
					status = ServiceResultStatus.Success;
					if (flag15 || num10 > 0)
					{
						new ApispDySelectFormWorkflowStepWithId_Result();
						ApispDySelectFormWorkflowStepWithId_Result apispDySelectFormWorkflowStepWithId_Result3 = ((num10 <= 0) ? Enumerable.FirstOrDefault<ApispDySelectFormWorkflowStepWithId_Result>((IEnumerable<ApispDySelectFormWorkflowStepWithId_Result>)db.ApispDySelectFormWorkflowStepWithId(model.WorkflowStepId, currLangId, defLangId)) : Enumerable.FirstOrDefault<ApispDySelectFormWorkflowStepWithId_Result>((IEnumerable<ApispDySelectFormWorkflowStepWithId_Result>)db.ApispDySelectFormWorkflowStepWithId(num10, currLangId, defLangId)));
						if (apispDySelectFormWorkflowStepWithId_Result3 != null)
						{
							string referUserIds = apispDySelectFormWorkflowStepWithId_Result3.ReferUserIds ?? "";
							string multiReferUserIds = apispDySelectFormWorkflowStepWithId_Result3.MultiReferUserIds ?? "";
							string checkerUserIds = apispDySelectFormWorkflowStepWithId_Result3.CheckerUserIds ?? "";
							ServiceResult<string> serviceResult2 = SendIntMsg(model.FormId, result6, result3, apispDySelectFormWorkflowStepWithId_Result3.FormWorkflowStepId, referUserIds, multiReferUserIds, checkerUserIds, model.SendIntMsgForMultiReferUsers, model.SendIntMsgForCheckerUsers, model.MasterValueDetailId.GetValueOrDefault(), num10, mainFormReferUserIs);
							if (serviceResult2 != null)
							{
								if (serviceResult2.Data != null)
								{
									string value8 = JsonConvert.SerializeObject(serviceResult2.Data);
									ServiceResult<string> serviceResult3 = JsonConvert.DeserializeObject<ServiceResult<string>>(value8);
									if (serviceResult3.Status != ServiceResultStatus.Success)
									{
										string message4 = serviceResult3.Message;
										base.ModelState.AddModelError("error", message4);
										message = message4;
										status = ServiceResultStatus.Fail;
									}
								}
								else
								{
									string text31 = RS.Get("msgErrorErrorSendingMessages", text6, RS.TypeMsg);
									base.ModelState.AddModelError("error", text31);
									message = text31;
									status = ServiceResultStatus.Fail;
								}
							}
							else
							{
								string text32 = RS.Get("msgErrorErrorSendingMessages", text6, RS.TypeMsg);
								base.ModelState.AddModelError("error", text32);
								message = text32;
								status = ServiceResultStatus.Fail;
							}
						}
					}
					if (flag)
					{
						model.SendIntMsgForMultiReferUsers = true;
						model.SendIntMsgForCheckerUsers = true;
					}
					else
					{
						model.SendIntMsgForMultiReferUsers = false;
						model.SendIntMsgForCheckerUsers = false;
					}
					model.CanSave = false;
				}
			}
			goto end_IL_007e;
			IL_1fb0:
			flag15 = false;
			num10 = 0;
			mainFormReferUserIs = "";
			if (result6 <= 0 || result3 <= 0)
			{
				goto IL_246d;
			}
			bool flag16 = false;
			new ApispDySelectFormFieldMasterValueDetailWithFormAndMasterValueId_Result();
			ApispDySelectFormFieldMasterValueDetailWithFormAndMasterValueId_Result apispDySelectFormFieldMasterValueDetailWithFormAndMasterValueId_Result = Enumerable.FirstOrDefault<ApispDySelectFormFieldMasterValueDetailWithFormAndMasterValueId_Result>((IEnumerable<ApispDySelectFormFieldMasterValueDetailWithFormAndMasterValueId_Result>)db.ApispDySelectFormFieldMasterValueDetailWithFormAndMasterValueId(model.FormId, result6));
			if (apispDySelectFormFieldMasterValueDetailWithFormAndMasterValueId_Result != null)
			{
				if (!model.WdSubFormId.HasValue && !model.WorkflowStepId.HasValue)
				{
					db.ApispDyUpdateFormFieldMasterValueDetails(apispDySelectFormFieldMasterValueDetailWithFormAndMasterValueId_Result.FormFieldMasterValueDetailId, model.UserId, dt, registerDatePersian, 0, month1, appType);
				}
			}
			else
			{
				flag16 = true;
				mct_Result mct_Result4 = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)db.ApispDyInsertFormFieldMasterValueDetails(result6, model.FormId, model.UserId, dt, registerDatePersian, 0, month1, appType, defLangId));
				if (mct_Result4 != null)
				{
					int result12 = 0;
					int.TryParse(mct_Result4.Result.ToString(), out result12);
				}
				ApispDySelectFormWorkflowStepsForMasterValue_Result apispDySelectFormWorkflowStepsForMasterValue_Result = Enumerable.FirstOrDefault<ApispDySelectFormWorkflowStepsForMasterValue_Result>((IEnumerable<ApispDySelectFormWorkflowStepsForMasterValue_Result>)db.ApispDySelectFormWorkflowStepsForMasterValue(result3, result6, currLangId, defLangId));
				if (apispDySelectFormWorkflowStepsForMasterValue_Result != null)
				{
					num10 = apispDySelectFormWorkflowStepsForMasterValue_Result.FormWorkflowStepId;
				}
				mainFormReferUserIs = apispDySelectFormAndSubForms_Result.ReferUserIds ?? "";
			}
			if (!(model.WdSubFormId > 0) || !(model.WorkflowStepId > 0))
			{
				goto IL_246d;
			}
			ApispDySelectFormWorkflowStepBFCurr_Result apispDySelectFormWorkflowStepBFCurr_Result = Enumerable.FirstOrDefault<ApispDySelectFormWorkflowStepBFCurr_Result>((IEnumerable<ApispDySelectFormWorkflowStepBFCurr_Result>)db.ApispDySelectFormWorkflowStepBFCurr(result3, model.WorkflowStepId, result6, model.WdSubFormId, currLangId, defLangId));
			if (apispDySelectFormWorkflowStepBFCurr_Result != null)
			{
				string text33 = string.Format(RS.Get("msgErrorCheckFormWorkflowDetailBFCurr", text6, RS.TypeMsg), apispDySelectFormWorkflowStepBFCurr_Result.WorkflowStepTitle ?? "") + "\n";
				message = text33;
				status = ServiceResultStatus.Fail;
				if (flag16)
				{
					try
					{
						db.ApispDyDeleteFormFieldMasterValue(result6);
					}
					catch (Exception e11)
					{
						ErrorSignal.FromCurrentContext().Raise(e11);
					}
				}
			}
			else
			{
				new ApispDySelectFormFieldMasterValueDetailWithId_Result();
				ApispDySelectFormFieldMasterValueDetailWithId_Result apispDySelectFormFieldMasterValueDetailWithId_Result = Enumerable.FirstOrDefault<ApispDySelectFormFieldMasterValueDetailWithId_Result>((IEnumerable<ApispDySelectFormFieldMasterValueDetailWithId_Result>)db.ApispDySelectFormFieldMasterValueDetailWithId(model.MasterValueDetailId, currLangId, defLangId));
				if (apispDySelectFormFieldMasterValueDetailWithId_Result != null)
				{
					db.ApispDyUpdateFormFieldMasterValueDetails(apispDySelectFormFieldMasterValueDetailWithId_Result.FormFieldMasterValueDetailId, model.UserId, dt, registerDatePersian, 0, month1, appType);
					goto IL_246d;
				}
				flag15 = true;
				mct_Result mct_Result5 = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)db.ApispDyInsertFormFieldMasterValueDetails(result6, model.WdSubFormId.GetValueOrDefault(), model.UserId, dt, registerDatePersian, 0, month1, appType, defLangId));
				if (mct_Result5 != null)
				{
					int result13 = 0;
					int.TryParse(mct_Result5.Result.ToString(), out result13);
					model.MasterValueDetailId = result13;
					goto IL_246d;
				}
				message = RS.Get("msgErrorRunFunction", text6, RS.TypeMsg);
				status = ServiceResultStatus.Fail;
			}
			goto end_IL_007e;
			IL_11bd:
			result6 = apispDySelectFormFieldMasterValueWithId_Result.FormFieldMasterValueId;
			if (!model.WdSubFormId.HasValue && !model.WorkflowStepId.HasValue)
			{
				db.ApispDyUpdateFormFieldMasterValues(result6, model.DyFormNumber, model.UserId, dt, registerDatePersian, 0, month1, appType);
			}
			if (result3 == 0)
			{
				db.ApispDyInsertUpdateFormFieldMasterValueDetails(2, result6, model.FormId, model.UserId, dt, registerDatePersian, 0, month1, appType, defLangId);
			}
			goto IL_14c0;
			end_IL_007e:;
		}
		catch (Exception ex2)
		{
			ErrorSignal.FromCurrentContext().Raise(ex2);
			message = RS.Get("msgErrorRunFunction", "fa-IR", RS.TypeMsg) + "\n" + ex2.Message;
			status = ServiceResultStatus.Error;
		}
		db?.Dispose();
		serviceResult = new ServiceResult<string>();
		serviceResult.Data = result;
		serviceResult.Message = message;
		serviceResult.Status = status;
		return serviceResult;
	}

	[HttpPost]
	public ServiceResult<string> DeleteDyForm(DeleteMasterValueViewModel model)
	{
		CRMEntities cRMEntities = null;
		ResourceManager resourceManager = new ResourceManager();
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<string>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			CommonClass commonClass = new CommonClass();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<string>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int.TryParse(model.LanguageId.ToString(), out var currLangId);
			if (currLangId <= 0)
			{
				currLangId = result;
			}
			List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)cRMEntities.ApispSelectLanguages());
			string rsCollation = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				rsCollation = apispSelectLanguages_Result.LanguageCollation;
			}
			if (!string.IsNullOrEmpty(model.Password))
			{
				model.Password = CodeDecode.DeCodding(model.Password);
			}
			if (!string.IsNullOrEmpty(model.UserName))
			{
				model.UserName = CodeDecode.DeCodding(model.UserName);
			}
			int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispCheckUserAllowed(model.UserName, model.Password));
			int result2 = 0;
			int.TryParse(num.ToString(), out result2);
			if (result2 == 0)
			{
				return new ServiceResult<string>
				{
					Message = resourceManager.Get("ErrorUsernamePasswordIncorrect", rsCollation, resourceManager.TypeMsg) + "\r\n" + resourceManager.Get("ErrorTryAgain", rsCollation, resourceManager.TypeMsg),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			ApispDySelectFormFieldMasterValueWithId_Result apispDySelectFormFieldMasterValueWithId_Result = Enumerable.FirstOrDefault<ApispDySelectFormFieldMasterValueWithId_Result>((IEnumerable<ApispDySelectFormFieldMasterValueWithId_Result>)cRMEntities.ApispDySelectFormFieldMasterValueWithId(model.MasterValueId, currLangId, result));
			if (apispDySelectFormFieldMasterValueWithId_Result != null)
			{
				try
				{
					if (DyForm.IsChecked(model.MasterValueId, currLangId, result))
					{
						return new ServiceResult<string>
						{
							Message = resourceManager.Get("msgFormIsChecked", rsCollation, resourceManager.TypeMsg),
							Data = null,
							Status = ServiceResultStatus.Error
						};
					}
					List<ApispSelectFilesDirectory_Result> list2 = Enumerable.ToList<ApispSelectFilesDirectory_Result>((IEnumerable<ApispSelectFilesDirectory_Result>)cRMEntities.ApispSelectFilesDirectory(apispDySelectFormFieldMasterValueWithId_Result.CompanyId.HasValue ? apispDySelectFormFieldMasterValueWithId_Result.CompanyId.ToString() : "0", apispDySelectFormFieldMasterValueWithId_Result.CompanyPersonId.HasValue ? apispDySelectFormFieldMasterValueWithId_Result.CompanyPersonId.ToString() : "0", apispDySelectFormFieldMasterValueWithId_Result.ProjectId.HasValue ? apispDySelectFormFieldMasterValueWithId_Result.ProjectId.ToString() : "0", "60", model.MasterValueId.ToString(), currLangId, result, false, "0", "0"));
					if (list2 != null && Enumerable.Any<ApispSelectFilesDirectory_Result>((IEnumerable<ApispSelectFilesDirectory_Result>)list2))
					{
						message = resourceManager.Get("RedundancyMessage", rsCollation, resourceManager.TypeMsg);
					}
					else
					{
						DateTime now = DateTime.Now;
						string deletedDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						int valueOrDefault = model.UserId.GetValueOrDefault(-15);
						mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)cRMEntities.ApispDyUpdateToDeleteFormFieldMasterValue(model.MasterValueId, valueOrDefault, now, deletedDatePersian));
						if (mct_Result != null && mct_Result.Result > 0)
						{
							message = "";
							status = ServiceResultStatus.Success;
						}
						else if (mct_Result != null && mct_Result.Result == 0)
						{
							message = resourceManager.Get("RedundancyMessage", rsCollation, resourceManager.TypeMsg);
							status = ServiceResultStatus.Fail;
						}
					}
				}
				catch (DbEntityValidationException e)
				{
					ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
					message = resourceManager.Get("RedundancyMessage", rsCollation, resourceManager.TypeMsg);
					status = ServiceResultStatus.Error;
				}
				catch (Exception ex)
				{
					ErrorSignal.FromCurrentContext().Raise(ex);
					message = resourceManager.Get("msgErrorCommunicateWithServer", rsCollation, resourceManager.TypeMsg) + "<br><p style=text-align:left;>" + ex.Message + "</p>";
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = resourceManager.Get("ErrorNotFound", rsCollation, resourceManager.TypeMsg);
				status = ServiceResultStatus.Fail;
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			message = resourceManager.Get("frmErrorMessage", "en-US", resourceManager.TypeMsg);
			status = ServiceResultStatus.Error;
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = null,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<string> GetDownloadLink(DyFormDownloadFileViewModel model)
	{
		CRMEntities cRMEntities = null;
		ResourceManager resourceManager = new ResourceManager();
		string text = "";
		string text2 = "";
		ServiceResultStatus serviceResultStatus = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<string>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			CommonClass commonClass = new CommonClass();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<string>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int.TryParse(model.LanguageId.ToString(), out var currLangId);
			if (currLangId <= 0)
			{
				currLangId = result;
			}
			List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)cRMEntities.ApispSelectLanguages());
			string rsCollation = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				rsCollation = apispSelectLanguages_Result.LanguageCollation;
			}
			if (!string.IsNullOrEmpty(model.Password))
			{
				model.Password = CodeDecode.DeCodding(model.Password);
			}
			if (!string.IsNullOrEmpty(model.UserName))
			{
				model.UserName = CodeDecode.DeCodding(model.UserName);
			}
			int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispCheckUserAllowed(model.UserName, model.Password));
			int result2 = 0;
			int.TryParse(num.ToString(), out result2);
			if (result2 == 0)
			{
				return new ServiceResult<string>
				{
					Message = resourceManager.Get("ErrorUsernamePasswordIncorrect", rsCollation, resourceManager.TypeMsg) + "\r\n" + resourceManager.Get("ErrorTryAgain", rsCollation, resourceManager.TypeMsg),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			if (model.FileId > 0)
			{
				Files files = new Files();
				string text3 = ((model.FileId > 0) ? files.GetFilePath(model.FileId, model.UserId) : "");
				if (string.IsNullOrEmpty(text3))
				{
					text2 = resourceManager.Get("msgErrorFileNotExist", rsCollation, resourceManager.TypeMsg);
					text = null;
					serviceResultStatus = ServiceResultStatus.Error;
				}
				else
				{
					PrintLog.InsertPrintLog(model.FileId, 550, 3, model.UserId, currLangId, result);
					text = text3;
					text2 = resourceManager.Get("msgSuccessAction", rsCollation, resourceManager.TypeMsg);
					serviceResultStatus = ServiceResultStatus.Success;
				}
			}
			else
			{
				text2 = resourceManager.Get("msgErrorFileNotExist", rsCollation, resourceManager.TypeMsg);
				text = null;
				serviceResultStatus = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			text2 = resourceManager.Get("msgErrorDoneOperation", "en-US");
			text = null;
			serviceResultStatus = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return new ServiceResult<string>
		{
			Message = text2,
			Data = text,
			Status = serviceResultStatus
		};
	}

	[HttpPost]
	public ServiceResult<string> DeleteDownloadFileTemp(DyFormDeleteFileViewModel model)
	{
		CRMEntities cRMEntities = null;
		ResourceManager resourceManager = new ResourceManager();
		string data = "";
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<string>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			CommonClass commonClass = new CommonClass();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<string>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int.TryParse(model.LanguageId.ToString(), out var currLangId);
			if (currLangId <= 0)
			{
				currLangId = result;
			}
			List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)cRMEntities.ApispSelectLanguages());
			string rsCollation = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				rsCollation = apispSelectLanguages_Result.LanguageCollation;
			}
			if (!string.IsNullOrEmpty(model.Password))
			{
				model.Password = CodeDecode.DeCodding(model.Password);
			}
			if (!string.IsNullOrEmpty(model.UserName))
			{
				model.UserName = CodeDecode.DeCodding(model.UserName);
			}
			int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispCheckUserAllowed(model.UserName, model.Password));
			int result2 = 0;
			int.TryParse(num.ToString(), out result2);
			if (result2 == 0)
			{
				return new ServiceResult<string>
				{
					Message = resourceManager.Get("ErrorUsernamePasswordIncorrect", rsCollation, resourceManager.TypeMsg) + "\r\n" + resourceManager.Get("ErrorTryAgain", rsCollation, resourceManager.TypeMsg),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			if (!string.IsNullOrEmpty(model.FileDownloadLink))
			{
				string absoluteUri = HttpContext.Current.Request.Url.AbsoluteUri;
				string[] array = absoluteUri.Split(new string[1] { "/Api/" }, StringSplitOptions.None);
				string text = "";
				if (array != null)
				{
					if (array[0] != null && array[0] != "")
					{
						model.FileDownloadLink = model.FileDownloadLink.Replace(array[0], "");
						string path = HttpContext.Current.Server.MapPath(model.FileDownloadLink);
						if (System.IO.File.Exists(path))
						{
							DirectoryInfo parent = System.IO.Directory.GetParent(path);
							if (System.IO.Directory.Exists(parent.FullName))
							{
								FileInfo[] files = parent.GetFiles();
								foreach (FileInfo fileInfo in files)
								{
									fileInfo.Delete();
								}
								DirectoryInfo[] directories = parent.GetDirectories();
								foreach (DirectoryInfo directoryInfo in directories)
								{
									directoryInfo.Delete(recursive: true);
								}
								if (System.IO.Directory.Exists(parent.FullName))
								{
									System.IO.Directory.Delete(parent.FullName);
								}
								if (!System.IO.Directory.Exists(parent.FullName))
								{
									data = "Ok";
									message = resourceManager.Get("msgSuccessAction", rsCollation, resourceManager.TypeMsg);
									status = ServiceResultStatus.Success;
								}
								else
								{
									message = resourceManager.Get("ErrorDoneOperation", rsCollation, resourceManager.TypeMsg);
									data = null;
									status = ServiceResultStatus.Error;
								}
							}
							else
							{
								message = resourceManager.Get("ErrorDoneOperation", rsCollation, resourceManager.TypeMsg);
								data = null;
								status = ServiceResultStatus.Error;
							}
						}
					}
					else
					{
						message = resourceManager.Get("ErrorDoneOperation", rsCollation, resourceManager.TypeMsg);
						data = null;
						status = ServiceResultStatus.Error;
					}
				}
				else
				{
					message = resourceManager.Get("msgErrorFilePathIsEmpty", rsCollation, resourceManager.TypeMsg);
					data = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = resourceManager.Get("msgErrorFilePathIsEmpty", rsCollation, resourceManager.TypeMsg);
				data = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = resourceManager.Get("ErrorDoneOperation", "en-US", resourceManager.TypeMsg);
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<string> SendIntMsg(int formId, int mValId, int workflowId, int workflowStepId, string referUserIds, string multiReferUserIds, string checkerUserIds, bool sendAutoMsgToMultiReferUsers, bool sendAutoMsgToCheckerUsers, int masterValueDetailId = 0, int firstWorkflowStepId = 0, string mainFormReferUserIs = "", int userId = 0, int languageId = 0, int deFaultLanguageId = 0)
	{
		string text = "";
		string text2 = "";
		ServiceResultStatus serviceResultStatus = ServiceResultStatus.Success;
		CRMEntities cRMEntities = null;
		ResourceManager resourceManager = new ResourceManager();
		try
		{
			List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)cRMEntities.ApispSelectLanguages());
			string rsCollation = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == deFaultLanguageId));
			if (apispSelectLanguages_Result != null)
			{
				rsCollation = apispSelectLanguages_Result.LanguageCollation;
			}
			DateTime now = DateTime.Now;
			string text3 = now.ToString("yyyyMMdd", new PersianCulture());
			short value = short.Parse(now.ToString("MM", new PersianCulture()));
			string text4 = CRMIdealApi.Classes.Configuration.AppType;
			short value2 = short.Parse(now.ToString("yyyy", new PersianCulture()));
			string text5 = now.ToString("HH:mm:ss");
			string formName = DyForm.GetFormName(formId, deFaultLanguageId, deFaultLanguageId);
			string workflowStepTitle = DyForm.GetWorkflowStepTitle(workflowStepId, deFaultLanguageId, deFaultLanguageId);
			bool flag = true;
			bool flag2 = true;
			bool flag3 = true;
			bool flag4 = true;
			bool flag5 = true;
			string text6 = "";
			ApispDySelectFormFieldMasterValueWithId_Result apispDySelectFormFieldMasterValueWithId_Result = Enumerable.FirstOrDefault<ApispDySelectFormFieldMasterValueWithId_Result>((IEnumerable<ApispDySelectFormFieldMasterValueWithId_Result>)cRMEntities.ApispDySelectFormFieldMasterValueWithId(mValId, languageId, deFaultLanguageId));
			if (apispDySelectFormFieldMasterValueWithId_Result != null)
			{
				if (apispDySelectFormFieldMasterValueWithId_Result.DyFormNumber.HasValue)
				{
					text6 = apispDySelectFormFieldMasterValueWithId_Result.DyFormNumber.ToString();
				}
				else
				{
					text6 = mValId.ToString();
				}
			}
			else
			{
				text6 = mValId.ToString();
			}
			bool flag6 = false;
			if (!string.IsNullOrEmpty(mainFormReferUserIs) && firstWorkflowStepId > 0 && flag6)
			{
				if (!string.IsNullOrEmpty(mainFormReferUserIs))
				{
					string[] array = mainFormReferUserIs.Split(new char[1] { '|' });
					if (Enumerable.Any<string>((IEnumerable<string>)array))
					{
						string text7 = "";
						string[] array2 = array;
						foreach (string text8 in array2)
						{
							if (!string.IsNullOrEmpty(text8))
							{
								int num = int.Parse(text8);
								if (num != userId)
								{
									text7 = text7 + text8 + "|";
								}
							}
						}
						mainFormReferUserIs = text7;
					}
				}
				if (!string.IsNullOrEmpty(mainFormReferUserIs))
				{
					string text9 = "";
					string text10 = "";
					string text11 = "";
					foreach (ApispSelectLanguages_Result item in Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list))
					{
						string formName2 = DyForm.GetFormName(formId, deFaultLanguageId, item.LanguageID);
						string workflowStepTitle2 = DyForm.GetWorkflowStepTitle(workflowStepId, deFaultLanguageId, item.LanguageID);
						text9 = "";
						text10 = "";
						text9 = string.Format(resourceManager.Get("DyFrmRefreUsersMsgSub", rsCollation, resourceManager.TypeMsg), formName2);
						text10 = "**" + resourceManager.Get("DyFrmErjaAutomatically", rsCollation, resourceManager.TypeMsg) + "<BR><BR>" + string.Format(resourceManager.Get("DyFrmErjaAttentionForMainForm", rsCollation, resourceManager.TypeMsg), formName2) + "<BR>";
						string[] array3 = mainFormReferUserIs.TrimEnd(new char[1] { '|' }).Split(new char[1] { '|' });
						if (array3 != null && Enumerable.Count<string>((IEnumerable<string>)array3) > 1)
						{
							text10 = text10 + "<BR>" + resourceManager.Get("DyFrmErjaMultiUser", rsCollation, resourceManager.TypeMsg) + ": " + DyForm.GetUsersForSendMsg(formId, mainFormReferUserIs, deFaultLanguageId, item.LanguageID, item.LanguageCollation);
						}
						text10 = text10 + "<BR><BR>" + resourceManager.Get("DyFrmErjaDetails", rsCollation, resourceManager.TypeMsg);
						text11 = text11 + "MsgSubj=" + text9 + "|@#@|MsgBody=" + text10 + "|@#@|LangId=" + item.LanguageID + "|@#@||^#^|";
					}
					ObjectParameter objectParameter = new ObjectParameter("InsertedIntMsgId", 0);
					int num2 = cRMEntities.ApispDySendFormInternalMessages(mValId, firstWorkflowStepId, mainFormReferUserIs, text11, formName, workflowStepTitle, 17, userId, now, text3, text5, value2, value, text4, deFaultLanguageId, objectParameter, null, null);
					if (objectParameter.Value != null)
					{
						string text12 = objectParameter.Value.ToString() ?? "0";
						flag = text12 != "-1";
					}
					else
					{
						flag = false;
					}
				}
			}
			if (!string.IsNullOrEmpty(referUserIds))
			{
				string[] array4 = referUserIds.Split(new char[1] { '|' });
				if (Enumerable.Any<string>((IEnumerable<string>)array4))
				{
					string text13 = "";
					string[] array5 = array4;
					foreach (string text14 in array5)
					{
						if (!string.IsNullOrEmpty(text14))
						{
							int num3 = int.Parse(text14);
							if (num3 != userId)
							{
								text13 = text13 + text14 + "|";
							}
						}
					}
					referUserIds = text13;
				}
			}
			if (!string.IsNullOrEmpty(referUserIds) && flag6)
			{
				string text15 = "";
				string text16 = "";
				string text17 = "";
				foreach (ApispSelectLanguages_Result item2 in Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list))
				{
					string formName3 = DyForm.GetFormName(formId, deFaultLanguageId, item2.LanguageID);
					string workflowStepTitle3 = DyForm.GetWorkflowStepTitle(workflowStepId, deFaultLanguageId, item2.LanguageID);
					text15 = "";
					text16 = "";
					text15 = string.Format(resourceManager.Get("DyFrmRefreUsersMsgSub", rsCollation, resourceManager.TypeMsg), formName3);
					text16 = "**" + resourceManager.Get("DyFrmErjaAutomatically", rsCollation, resourceManager.TypeMsg) + "<BR><BR>" + string.Format(resourceManager.Get("DyFrmErjaAttention", rsCollation, resourceManager.TypeMsg), workflowStepTitle3, formName3) + "<BR>";
					string[] array6 = referUserIds.TrimEnd(new char[1] { '|' }).Split(new char[1] { '|' });
					if (array6 != null && Enumerable.Count<string>((IEnumerable<string>)array6) > 1)
					{
						text16 = text16 + "<BR>" + resourceManager.Get("DyFrmErjaMultiUser", rsCollation, resourceManager.TypeMsg) + ": " + DyForm.GetUsersForSendMsg(formId, referUserIds, deFaultLanguageId, item2.LanguageID, item2.LanguageCollation);
					}
					text16 = text16 + "<BR><BR>" + resourceManager.Get("DyFrmErjaDetails", rsCollation, resourceManager.TypeMsg);
					text17 = text17 + "MsgSubj=" + text15 + "|@#@|MsgBody=" + text16 + "|@#@|LangId=" + item2.LanguageID + "|@#@||^#^|";
				}
				ObjectParameter objectParameter2 = new ObjectParameter("InsertedIntMsgId", 0);
				int num4 = cRMEntities.ApispDySendFormInternalMessages(mValId, workflowStepId, referUserIds, text17, formName, workflowStepTitle, 17, userId, now, text3, text5, value2, value, text4, deFaultLanguageId, objectParameter2, null, null);
				if (objectParameter2.Value != null)
				{
					string text18 = objectParameter2.Value.ToString() ?? "0";
					flag2 = text18 != "-1";
				}
				else
				{
					flag2 = false;
				}
			}
			if (!string.IsNullOrEmpty(multiReferUserIds) && sendAutoMsgToMultiReferUsers)
			{
				string text19 = "";
				string text20 = "";
				string text21 = "";
				foreach (ApispSelectLanguages_Result item3 in Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list))
				{
					string formName4 = DyForm.GetFormName(formId, deFaultLanguageId, item3.LanguageID);
					text19 = "";
					text20 = "";
					text19 = string.Format(resourceManager.Get("DyFrmErjaRonevesht", rsCollation, resourceManager.TypeMsg), formName4) + " " + CRMIdealApi.Classes.Helper.User.GetUserName(userId, deFaultLanguageId, item3.LanguageID);
					text20 = resourceManager.Get("DyFrmErjaFrom", rsCollation, resourceManager.TypeMsg) + ":" + formName4;
					text20 = text20 + "<BR><BR>" + resourceManager.Get("DyFrmErjaDetails", rsCollation, resourceManager.TypeMsg);
					text21 = text21 + "MsgSubj=" + text19 + "|@#@|MsgBody=" + text20 + "|@#@|LangId=" + item3.LanguageID + "|@#@||^#^|";
				}
				ObjectParameter objectParameter3 = new ObjectParameter("InsertedIntMsgId", 0);
				int num5 = cRMEntities.ApispDySendFormInternalMessages(mValId, workflowStepId, multiReferUserIds, text21, formName, workflowStepTitle, 17, userId, now, text3, text5, value2, value, text4, deFaultLanguageId, objectParameter3, null, null);
				if (objectParameter3.Value != null)
				{
					string text22 = objectParameter3.Value.ToString() ?? "0";
					flag3 = text22 != "-1";
				}
				else
				{
					flag3 = false;
				}
			}
			if (firstWorkflowStepId == 0)
			{
				if (!string.IsNullOrEmpty(checkerUserIds) && sendAutoMsgToCheckerUsers)
				{
					string text23 = "";
					string text24 = "";
					string text25 = "";
					foreach (ApispSelectLanguages_Result item4 in Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list))
					{
						string formName5 = DyForm.GetFormName(formId, deFaultLanguageId, item4.LanguageID);
						text23 = "";
						text24 = "";
						text23 = string.Format(resourceManager.Get("DyfrmCheckRequestSubject", rsCollation, resourceManager.TypeLbl), formName5);
						text24 = resourceManager.Get("DyFrmReqCheckByName", rsCollation, resourceManager.TypeMsg) + ":" + formName5;
						text24 = text24 + "<BR><BR>" + resourceManager.Get("DyfrmCheckRequestDbClickOnOtherInfo", rsCollation, resourceManager.TypeLbl);
						text25 = text25 + "MsgSubj=" + text23 + "|@#@|MsgBody=" + text24 + "|@#@|LangId=" + item4.LanguageID + "|@#@||^#^|";
					}
					ObjectParameter objectParameter4 = new ObjectParameter("InsertedIntMsgId", 0);
					int num6 = cRMEntities.ApispDySendFormInternalMessages(mValId, workflowStepId, checkerUserIds, text25, formName, workflowStepTitle, 16, userId, now, text3, text5, value2, value, text4, deFaultLanguageId, objectParameter4, null, null);
					if (objectParameter4.Value != null)
					{
						string text26 = objectParameter4.Value.ToString() ?? "0";
						flag4 = text26 != "-1";
					}
					else
					{
						flag4 = false;
					}
				}
				if (string.IsNullOrEmpty(checkerUserIds) && flag6)
				{
					ApispDySelectFormWorkflowStepNext_Result apispDySelectFormWorkflowStepNext_Result = Enumerable.FirstOrDefault<ApispDySelectFormWorkflowStepNext_Result>((IEnumerable<ApispDySelectFormWorkflowStepNext_Result>)cRMEntities.ApispDySelectFormWorkflowStepNext(workflowId, workflowStepId, languageId, deFaultLanguageId));
					if (apispDySelectFormWorkflowStepNext_Result != null)
					{
						if (!string.IsNullOrEmpty(apispDySelectFormWorkflowStepNext_Result.ReferUserIds) && flag6)
						{
							string text27 = "";
							string text28 = "";
							string text29 = "";
							foreach (ApispSelectLanguages_Result item5 in Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list))
							{
								string workflowStepTitle4 = DyForm.GetWorkflowStepTitle(workflowStepId, deFaultLanguageId, item5.LanguageID);
								string formName6 = DyForm.GetFormName(formId, deFaultLanguageId, item5.LanguageID);
								text27 = "";
								text28 = "";
								text27 = string.Format(resourceManager.Get("DyFrmNextStepRefreUsersMsgSub", rsCollation, resourceManager.TypeMsg), workflowStepTitle4, formName6);
								text28 = "**" + resourceManager.Get("DyFrmErjaAutomatically", rsCollation, resourceManager.TypeMsg) + "<BR><BR>" + string.Format(resourceManager.Get("DyFrmNextStepErjaAttention", rsCollation, resourceManager.TypeMsg), formName6, workflowStepTitle4) + "<BR>";
								string[] array7 = apispDySelectFormWorkflowStepNext_Result.ReferUserIds.TrimEnd(new char[1] { '|' }).Split(new char[1] { '|' });
								if (array7 != null && Enumerable.Count<string>((IEnumerable<string>)array7) > 1)
								{
									text28 = text28 + "<BR>" + resourceManager.Get("DyFrmErjaMultiUser", rsCollation, resourceManager.TypeMsg) + ": " + DyForm.GetUsersForSendMsg(formId, apispDySelectFormWorkflowStepNext_Result.ReferUserIds, deFaultLanguageId, item5.LanguageID, item5.LanguageCollation);
								}
								text28 = text28 + "<BR><BR>" + resourceManager.Get("DyFrmErjaDetails", rsCollation, resourceManager.TypeMsg);
								text29 = text29 + "MsgSubj=" + text27 + "|@#@|MsgBody=" + text28 + "|@#@|LangId=" + item5.LanguageID + "|@#@||^#^|";
							}
							string workflowStepTitle5 = DyForm.GetWorkflowStepTitle(apispDySelectFormWorkflowStepNext_Result.FormWorkflowStepId, deFaultLanguageId, deFaultLanguageId);
							ObjectParameter objectParameter5 = new ObjectParameter("InsertedIntMsgId", 0);
							int num7 = cRMEntities.ApispDySendFormInternalMessages(mValId, apispDySelectFormWorkflowStepNext_Result.FormWorkflowStepId, apispDySelectFormWorkflowStepNext_Result.ReferUserIds, text29, formName, workflowStepTitle5, 17, userId, now, text3, text5, value2, value, text4, deFaultLanguageId, objectParameter5, null, null);
							if (objectParameter5.Value != null)
							{
								string text30 = objectParameter5.Value.ToString() ?? "0";
								flag5 = text30 != "-1";
							}
							else
							{
								flag5 = false;
							}
						}
					}
					else
					{
						ApispDySelectFormFieldMasterValueWithId_Result apispDySelectFormFieldMasterValueWithId_Result2 = Enumerable.FirstOrDefault<ApispDySelectFormFieldMasterValueWithId_Result>((IEnumerable<ApispDySelectFormFieldMasterValueWithId_Result>)cRMEntities.ApispDySelectFormFieldMasterValueWithId(mValId, languageId, deFaultLanguageId));
						if (apispDySelectFormFieldMasterValueWithId_Result2.FirstRegisterUserId > 0)
						{
							string text31 = "";
							string text32 = "";
							string text33 = "";
							foreach (ApispSelectLanguages_Result item6 in list)
							{
								string formName7 = DyForm.GetFormName(apispDySelectFormFieldMasterValueWithId_Result2.FormId, deFaultLanguageId, item6.LanguageID);
								string workflowStepTitle6 = DyForm.GetWorkflowStepTitle(workflowStepId, deFaultLanguageId, item6.LanguageID);
								text31 = "";
								text32 = "";
								text31 = string.Format(resourceManager.Get("DyFrmNextStepRefreUsersMsgSub", rsCollation, resourceManager.TypeMsg), workflowStepTitle6, formName7);
								text32 = "**" + resourceManager.Get("DyFrmFirstStepErjaAttention", rsCollation, resourceManager.TypeMsg) + "<BR><BR>" + string.Format(resourceManager.Get("DyFrmFirstStepErjaAttention", rsCollation, resourceManager.TypeMsg), formName7, workflowStepTitle6, formName7) + "<BR>";
								text32 = text32 + "<BR><BR>" + resourceManager.Get("DyFrmErjaDetails", rsCollation, resourceManager.TypeMsg);
								text33 = text33 + "MsgSubj=" + text31 + "|@#@|MsgBody=" + text32 + "|@#@|LangId=" + item6.LanguageID + "|@#@||^#^|";
							}
							ObjectParameter objectParameter6 = new ObjectParameter("InsertedIntMsgId", 0);
							int num8 = cRMEntities.ApispDySendFormInternalMessages(mValId, workflowStepId, apispDySelectFormFieldMasterValueWithId_Result2.FirstRegisterUserId.ToString(), text33, formName, workflowStepTitle, 17, userId, now, text3, text5, value2, value, text4, deFaultLanguageId, objectParameter6, null, null);
							if (objectParameter6.Value != null)
							{
								string text34 = objectParameter6.Value.ToString() ?? "0";
								flag5 = text34 != "-1";
							}
							else
							{
								flag5 = false;
							}
						}
					}
				}
			}
			if (flag2 && flag3 && flag4 && flag5 && flag)
			{
				PushNotif.NewIntMsgNotify(languageId, deFaultLanguageId);
				text2 = "";
				text = "ok";
				serviceResultStatus = ServiceResultStatus.Success;
			}
			else
			{
				text2 = resourceManager.Get("msgErrorErrorSendingMessages", rsCollation, resourceManager.TypeMsg);
				text = "";
				serviceResultStatus = ServiceResultStatus.Fail;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			text2 = resourceManager.Get("msgErrorRunFunction", "fa-IR", resourceManager.TypeMsg) + "\n" + ex.Message;
			serviceResultStatus = ServiceResultStatus.Error;
			text = "";
		}
		cRMEntities?.Dispose();
		return new ServiceResult<string>
		{
			Data = text,
			Message = text2,
			Status = serviceResultStatus
		};
	}
}
