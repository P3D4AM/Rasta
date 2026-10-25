using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Web.Http;
using System.Web.Mvc;
using CRM.General.Utilities;
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

public class VerificationWorkFlowController : ApiController
{
	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectVerificationRequests_Result>> SelectVerificationRequests(int reqId, int objId, int objType, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspSelectVerificationRequests_Result> data = null;
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
					data = Enumerable.ToList<MobspSelectVerificationRequests_Result>((IEnumerable<MobspSelectVerificationRequests_Result>)cRMEntities.MobspSelectVerificationRequests(reqId, objId, objType, result, result2));
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
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<MobspSelectVerificationRequests_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectVerificationRequestDetails_Result>> SelectVerificationRequestDetails(int reqDetailId, int reqId, int workFlowId, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspSelectVerificationRequestDetails_Result> data = null;
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
					data = Enumerable.ToList<MobspSelectVerificationRequestDetails_Result>((IEnumerable<MobspSelectVerificationRequestDetails_Result>)cRMEntities.MobspSelectVerificationRequestDetails(reqDetailId, reqId, workFlowId, result, result2, cId));
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
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<MobspSelectVerificationRequestDetails_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectVerificationRequestDetails_Result>> VerifyRequest(VerificationWorkFlowViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangId);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		List<MobspSelectVerificationRequestDetails_Result> data = null;
		string text = "";
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
					List<MobspSelectLanguages_Result> list = Enumerable.ToList<MobspSelectLanguages_Result>(Enumerable.Where<MobspSelectLanguages_Result>((IEnumerable<MobspSelectLanguages_Result>)cRMEntities.MobspSelectLanguages(), (Func<MobspSelectLanguages_Result, bool>)((MobspSelectLanguages_Result m) => m.LanguageID != defLangId)));
					string verifyText = model.MessageText ?? "";
					string resourceString = MyResource.GetResourceString("MobVerifiedRequestSubject", "fa-IR", "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
					string resourceString2 = MyResource.GetResourceString("MobVerifiedRequestVerify", "fa-IR", "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
					string text2 = "";
					foreach (MobspSelectLanguages_Result item in list)
					{
						string text3 = "";
						string text4 = "";
						string text5 = "";
						text3 = MyResource.GetResourceString("MobVerifiedRequestSubject", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
						text5 = MyResource.GetResourceString("MobVerifiedRequestVerify", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
						text4 = model.MessageText ?? "";
						text2 = text2 + "[LangId=" + item.LanguageID + "|,|Txt=" + text4 + "|,|Subj=" + text3 + "|,|VerifiedSubj=" + text5 + "|,|]@";
					}
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(now.ToString("yyyy", new PersianCulture()));
					short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					string appType = Mobile.Classes.Configuration.AppType;
					int value4 = int.Parse(Financial.Get().Id.ToString());
					ObjectParameter objectParameter = new ObjectParameter("result", "");
					ObjectParameter internalMessageId = new ObjectParameter("InternalMessageId", 0);
					ObjectParameter objectParameter2 = new ObjectParameter("maxDiscountPercent", typeof(decimal));
					cRMEntities.MobspVerificationRequestVerify(model.VerificationWorkFlowId, model.ObjectId, model.VerificationRequestId, model.VerificationWorkFlowStepId, verifyText, text2, resourceString, resourceString2, token2.RollId, value, registerDatePersian, token2.userId, value4, value2, value3, appType, result, defLangId, objectParameter2, objectParameter, 1, internalMessageId, model.CenterId);
					string text6 = "";
					if (objectParameter.Value != null && !string.IsNullOrEmpty(objectParameter.Value.ToString()))
					{
						string arg = "";
						if (objectParameter2.Value != null && !string.IsNullOrEmpty(objectParameter2.Value.ToString()))
						{
							arg = objectParameter2.Value.ToString();
						}
						string text7 = objectParameter.Value.ToString();
						if (text7 == "-6")
						{
							List<MobspDySelectFormWorkflowStepsNotCheckedForMasterValue_Result> list2 = Enumerable.ToList<MobspDySelectFormWorkflowStepsNotCheckedForMasterValue_Result>((IEnumerable<MobspDySelectFormWorkflowStepsNotCheckedForMasterValue_Result>)cRMEntities.MobspDySelectFormWorkflowStepsNotCheckedForMasterValue(model.ObjectId, result, defLangId));
							if (list2 != null && Enumerable.Any<MobspDySelectFormWorkflowStepsNotCheckedForMasterValue_Result>((IEnumerable<MobspDySelectFormWorkflowStepsNotCheckedForMasterValue_Result>)list2))
							{
								string text8 = "";
								foreach (MobspDySelectFormWorkflowStepsNotCheckedForMasterValue_Result item2 in list2)
								{
									if (!string.IsNullOrWhiteSpace(item2.WorkflowStepTitle))
									{
										text8 = text8 + item2.WorkflowStepTitle + "<br>";
									}
								}
								text6 = text6 + Messages.MobMsgErrorDyFrmNotConfirmSteps + "<br>" + text8;
							}
						}
						else if (text7 == "-5")
						{
							text6 += Messages.MobMsgErrorDoneOperation;
						}
						else if (text7.IndexOf("-4|", StringComparison.Ordinal) >= 0)
						{
							text6 = text6 + string.Format(Messages.MobMsgErrorCheckVerificationWorkflowStepBFCurr, text7.Replace("-4|", "") ?? "") + "<br>";
						}
						else
						{
							switch (text7)
							{
							case "-3":
								if (!string.IsNullOrEmpty(model.FormName))
								{
									if (model.FormName == "PORD")
									{
										text6 += string.Format(Messages.MobMsgErrorMaxDiscountPercentInPordDiscount, arg);
									}
									else if (model.FormName == "ORD")
									{
										text6 += string.Format(Messages.MobMsgErrorMaxDiscountPercentInOrdDiscount, arg);
									}
								}
								break;
							case "-2":
								if (!string.IsNullOrEmpty(model.FormName))
								{
									if (model.FormName == "PORD")
									{
										text6 += string.Format(Messages.MobMsgErrorMaxDiscountPercentInItemDiscount, arg);
									}
									else if (model.FormName == "ORD")
									{
										text6 += string.Format(Messages.MobMsgErrorMaxDiscountPercentInItemDiscount, arg);
									}
								}
								break;
							case "-1":
								text6 += Messages.MobMsgErrorDivisionByZero;
								break;
							case "-101":
								text6 += string.Format(Messages.msgErrorIsNotSpecified, Labels.VerificationWorkFlowStepResponsibleUser);
								break;
							case "-102":
								text6 += string.Format(Messages.msgErrorIsNotSpecified, Labels.VerificationWorkFlowStepCmpReferUser);
								break;
							case "-103":
								text6 += string.Format(Messages.msgErrorIsNotSpecified, Labels.VerificationWorkFlowStepCmpSuppUser);
								break;
							}
						}
					}
					string text9 = "";
					if (string.IsNullOrEmpty(text6))
					{
						if (model.ObjectType == 20)
						{
							MobspSelectOrderWithID_Result mobspSelectOrderWithID_Result = Enumerable.FirstOrDefault<MobspSelectOrderWithID_Result>((IEnumerable<MobspSelectOrderWithID_Result>)cRMEntities.MobspSelectOrderWithID(model.ObjectId, token2.userId, result, defLangId, model.CenterId));
							if (mobspSelectOrderWithID_Result != null)
							{
								bool result2 = false;
								bool.TryParse(mobspSelectOrderWithID_Result.ordIsVerified.ToString(), out result2);
								if (result2)
								{
									int objectId = model.ObjectId;
									DateTime now2 = DateTime.Now;
									DateTime value5 = now2;
									string registerDatePersian2 = now2.ToString("yyyyMMdd", new PersianCulture());
									short value6 = short.Parse(now2.ToString("MM", new PersianCulture()));
									short value7 = short.Parse(Financial.Get().Id.ToString());
									int userId = UserLogin.CurrentUser.UserId;
									cRMEntities.MobScorespInsertAndCalcOrderScores(null, objectId, null, null, null, null, true, DateTime.Now, userId, value7, value6, value5, registerDatePersian2, appType, result, defLangId, null, true, model.CenterId, false);
									if (UserLogin.IsUserAccess("frmOrder", "actAutoReferOrderToWrhsUserAfterVerify", UserLogin.CurrentUser, model.CenterId))
									{
										Order.ReferOrderToWrhsUser(objectId, model.CenterId);
									}
									if (objectId > 0)
									{
										string msg = "";
										Order.AddProjectProductHistoryFromOrder(objectId, addPrdValidity: false, "", ref msg);
										if (!string.IsNullOrWhiteSpace(msg))
										{
											Common.InsTextToElmah(msg);
										}
									}
									bool? sendSMSOrdFOLinkAfterVerify = SysSeting.Get().SendSMSOrdFOLinkAfterVerify;
									int? sendSMSOrdFOLinkAfterVerifyType = SysSeting.Get().SendSMSOrdFOLinkAfterVerifyType;
									string text10 = "";
									string text11 = "";
									string text12 = "";
									string text13 = "";
									if (sendSMSOrdFOLinkAfterVerify.GetValueOrDefault())
									{
										List<SelectListItem> ordFoShortLinks = Order.GetOrdFoShortLinks(objectId);
										text11 = ordFoShortLinks[1].Value;
										text12 = ordFoShortLinks[2].Value;
										text13 = ordFoShortLinks[3].Value;
										if (sendSMSOrdFOLinkAfterVerifyType.GetValueOrDefault() == 1)
										{
											text10 = text11;
										}
										else if (sendSMSOrdFOLinkAfterVerifyType.GetValueOrDefault() == 2)
										{
											text10 = text12;
										}
										else if (sendSMSOrdFOLinkAfterVerifyType.GetValueOrDefault() == 3)
										{
											text10 = text13;
										}
									}
									if (!string.IsNullOrWhiteSpace(text10))
									{
										ObjectParameter result3 = new ObjectParameter("Result", 0);
										CRMSpEntities cRMSpEntities2 = cRMSpEntities;
										int? orderId = objectId;
										string foLink = text10;
										string foLinkWithLogin = text11;
										string foLinkWithoutLogin = text12;
										string crmLinkWithoutLogin = text13;
										cRMSpEntities2.MobspSendSmsOrdFOLinkAfterVerify(orderId, foLink, foLinkWithLogin, foLinkWithoutLogin, token2.userId, value2, value3, registerDatePersian, appType, num, defLangId, result3, crmLinkWithoutLogin, model.CenterId);
									}
									int ordCompanyId = mobspSelectOrderWithID_Result.ordCompanyId;
									if (ordCompanyId > 0)
									{
										Dictionary<string, string> dictionary = new Dictionary<string, string>();
										dictionary.Add("Title", "تایید فاکتور");
										dictionary.Add("Message", "فاکتور شما تایید شد");
										dictionary.Add("MessageType", "VerifyOrd");
										PushNotif.NewIntMsgNotifyToCompany(int.Parse(ordCompanyId.ToString()), dictionary);
									}
									Order.SendSmsFoSettingOrdAfterVerify(objectId, model.CenterId);
								}
								else
								{
									Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.MobScorespDeleteOrderScores(model.ObjectId, UserLogin.CurrentUser.UserId, value2, value3, value, registerDatePersian, appType, defLangId, model.CenterId));
								}
								if (!string.IsNullOrWhiteSpace((mobspSelectOrderWithID_Result.ordEditAfterFixInfoJs ?? "").Replace("[]", "")))
								{
									List<EditAfterFixInfoViewModel> list3 = JsonConvert.DeserializeObject<List<EditAfterFixInfoViewModel>>(mobspSelectOrderWithID_Result.ordEditAfterFixInfoJs);
									if (list3 != null)
									{
										foreach (EditAfterFixInfoViewModel item3 in list3)
										{
											if (item3.eafUserId == UserLogin.CurrentUser.UserId && item3.eafWorkflowReqId == model.VerificationRequestId && item3.eafWorkflowStepId == model.VerificationWorkFlowStepId)
											{
												item3.eafIsDone = true;
												item3.eafDoneDate = DateTime.Now;
											}
										}
										UpdateObject(model.ObjectType, model.ObjectId, JsonConvert.SerializeObject(list3));
									}
								}
							}
						}
						if (model.ObjectType == 10)
						{
							MobspSelectPreOrderWithID_Result mobspSelectPreOrderWithID_Result = Enumerable.FirstOrDefault<MobspSelectPreOrderWithID_Result>((IEnumerable<MobspSelectPreOrderWithID_Result>)cRMEntities.MobspSelectPreOrderWithID(model.ObjectId, token2.userId, result, defLangId, model.CenterId));
							if (mobspSelectPreOrderWithID_Result != null)
							{
								bool result4 = false;
								bool.TryParse(mobspSelectPreOrderWithID_Result.pordIsVerified.ToString(), out result4);
								if (result4)
								{
									int objectId2 = model.ObjectId;
									bool? sendSMSPordFOLinkAfterVerify = SysSeting.Get().SendSMSPordFOLinkAfterVerify;
									int? sendSMSPordFOLinkAfterVerifyType = SysSeting.Get().SendSMSPordFOLinkAfterVerifyType;
									string text14 = "";
									string text15 = "";
									string text16 = "";
									string text17 = "";
									if (sendSMSPordFOLinkAfterVerify.GetValueOrDefault())
									{
										List<SelectListItem> pordFoShortLinks = PreOrder.GetPordFoShortLinks(objectId2, model.CenterId);
										text15 = pordFoShortLinks[1].Value;
										text16 = pordFoShortLinks[2].Value;
										text17 = pordFoShortLinks[3].Value;
										if (sendSMSPordFOLinkAfterVerifyType.GetValueOrDefault() == 1)
										{
											text14 = text15;
										}
										else if (sendSMSPordFOLinkAfterVerifyType.GetValueOrDefault() == 2)
										{
											text14 = text16;
										}
										else if (sendSMSPordFOLinkAfterVerifyType.GetValueOrDefault() == 3)
										{
											text14 = text17;
										}
									}
									if (!string.IsNullOrWhiteSpace(text14))
									{
										ObjectParameter result5 = new ObjectParameter("Result", 0);
										cRMSpEntities.MobspSendSmsPordFOLinkAfterVerify(objectId2, text14, text15, text16, text17, token2.userId, value2, value3, registerDatePersian, appType, num, defLangId, result5, model.CenterId);
									}
									PreOrder.SendSmsFoSettingPordAfterVerify(objectId2, model.CenterId);
									CRMspSelectCompanyById_Result cRMspSelectCompanyById_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyById_Result>((IEnumerable<CRMspSelectCompanyById_Result>)cRMEntities.CRMspSelectCompanyById(mobspSelectPreOrderWithID_Result.pordCompanyId, result, defLangId));
									if (cRMspSelectCompanyById_Result != null && cRMspSelectCompanyById_Result.cmpCRMShopIsActive.GetValueOrDefault())
									{
										int? pordCompanyId = mobspSelectPreOrderWithID_Result.pordCompanyId;
										int retId = 0;
										new InternalMessage().SendInternalmsgSingle(token2.userId, 0, Labels.ShopVerifyPreOrderTitle, string.Format(Labels.ShopVerifyPreOrderMsg, mobspSelectPreOrderWithID_Result.pordNumber, now.ToString("yyyy/MM/dd")).Replace("<br>", "\n"), 5, token2.userId, -20, now.ToString("yyyyMMdd", new PersianCulture()), now.ToString("HH:mm:ss"), 0, "", objectId2, Messages.ConversationErjaShow, 0, out retId, defLangId, model.CenterId);
										if (pordCompanyId.HasValue && pordCompanyId > 0)
										{
											Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
											dictionary2.Add("Title", Labels.ShopVerifyPreOrderTitle);
											dictionary2.Add("Message", string.Format(Labels.ShopVerifyPreOrderMsg, mobspSelectPreOrderWithID_Result.pordNumber, now.ToString("yyyy/MM/dd")).Replace("<br>", "\n"));
											dictionary2.Add("MessageType", "VerifyPreOrd");
											dictionary2.Add("InternalMessageId", retId.ToString());
											dictionary2.Add("preOrderID", objectId2.ToString());
											PushNotif.NewIntMsgNotifyToCompany(int.Parse(pordCompanyId.ToString()), dictionary2);
										}
									}
								}
								if (!string.IsNullOrWhiteSpace((mobspSelectPreOrderWithID_Result.pordEditAfterFixInfoJs ?? "").Replace("[]", "")))
								{
									List<EditAfterFixInfoViewModel> list4 = JsonConvert.DeserializeObject<List<EditAfterFixInfoViewModel>>(mobspSelectPreOrderWithID_Result.pordEditAfterFixInfoJs);
									if (list4 != null)
									{
										foreach (EditAfterFixInfoViewModel item4 in list4)
										{
											if (item4.eafUserId == UserLogin.CurrentUser.UserId && item4.eafWorkflowReqId == model.VerificationRequestId && item4.eafWorkflowStepId == model.VerificationWorkFlowStepId)
											{
												item4.eafIsDone = true;
												item4.eafDoneDate = DateTime.Now;
											}
										}
										UpdateObject(model.ObjectType, model.ObjectId, JsonConvert.SerializeObject(list4));
									}
								}
							}
						}
						if (model.ObjectType == 60)
						{
							MobspSelectDocById_Result mobspSelectDocById_Result = Enumerable.FirstOrDefault<MobspSelectDocById_Result>((IEnumerable<MobspSelectDocById_Result>)cRMSpEntities.MobspSelectDocById(model.ObjectId, num, defLangId));
							if (mobspSelectDocById_Result != null)
							{
								bool result6 = false;
								bool.TryParse(mobspSelectDocById_Result.IsVerified.ToString(), out result6);
								int result7 = 0;
								int.TryParse(mobspSelectDocById_Result.OprType.ToString(), out result7);
								if (result6)
								{
									bool flag = false;
									switch (result7)
									{
									case 1:
										flag = UserLogin.IsUserAccess("frmDoc", "actAutoReferDocToOrdReferUserAfterVerify", UserLogin.CurrentUser, model.CenterId);
										break;
									case 2:
										flag = UserLogin.IsUserAccess("frmDraft", "actAutoReferDocToOrdReferUserAfterVerify", UserLogin.CurrentUser, model.CenterId);
										break;
									}
									if (flag)
									{
										Doc.ReferDocToOrdReferUser(model.ObjectId.ToString(), model.CenterId);
									}
								}
								if (!string.IsNullOrWhiteSpace((mobspSelectDocById_Result.EditAfterFixInfoJs ?? "").Replace("[]", "")))
								{
									List<EditAfterFixInfoViewModel> list5 = JsonConvert.DeserializeObject<List<EditAfterFixInfoViewModel>>(mobspSelectDocById_Result.EditAfterFixInfoJs);
									if (list5 != null)
									{
										foreach (EditAfterFixInfoViewModel item5 in list5)
										{
											if (item5.eafUserId == UserLogin.CurrentUser.UserId && item5.eafWorkflowReqId == model.VerificationRequestId && item5.eafWorkflowStepId == model.VerificationWorkFlowStepId)
											{
												item5.eafIsDone = true;
												item5.eafDoneDate = DateTime.Now;
											}
										}
										UpdateObject(model.ObjectType, model.ObjectId, JsonConvert.SerializeObject(list5), mobspSelectDocById_Result.OprType.GetValueOrDefault());
									}
								}
							}
						}
						if (model.ObjectType == 80)
						{
							MobspDySelectFormFieldMasterValueWithId_Result mobspDySelectFormFieldMasterValueWithId_Result = Enumerable.FirstOrDefault<MobspDySelectFormFieldMasterValueWithId_Result>((IEnumerable<MobspDySelectFormFieldMasterValueWithId_Result>)cRMEntities.MobspDySelectFormFieldMasterValueWithId(model.ObjectId, num, defLangId));
							if (mobspDySelectFormFieldMasterValueWithId_Result != null && !string.IsNullOrWhiteSpace((mobspDySelectFormFieldMasterValueWithId_Result.EditAfterFixInfoJs ?? "").Replace("[]", "")))
							{
								List<EditAfterFixInfoViewModel> list6 = JsonConvert.DeserializeObject<List<EditAfterFixInfoViewModel>>(mobspDySelectFormFieldMasterValueWithId_Result.EditAfterFixInfoJs);
								if (list6 != null)
								{
									foreach (EditAfterFixInfoViewModel item6 in list6)
									{
										if (item6.eafUserId == UserLogin.CurrentUser.UserId && item6.eafWorkflowReqId == model.VerificationRequestId && item6.eafWorkflowStepId == model.VerificationWorkFlowStepId)
										{
											item6.eafIsDone = true;
											item6.eafDoneDate = DateTime.Now;
										}
									}
									UpdateObject(model.ObjectType, model.ObjectId, JsonConvert.SerializeObject(list6));
								}
							}
						}
						PushNotif.NewIntMsgNotify(withthread: true, model.CenterId);
						if (model.ObjectType == 90 || model.ObjectType == 100)
						{
							if (model.MsgId.GetValueOrDefault() > 0)
							{
								SetMessageRead(model.MsgId.Value, model.MsgTypeId, model.CenterId);
							}
							CRMEntities cRMEntities2 = cRMEntities;
							int? crmUserId = 0;
							int? leaveId = model.ObjectId;
							int? leaveTypeId = 0;
							int? userId2 = 0;
							int? languageID = num;
							int? defaultLanguageID = defLangId;
							MobspSelectLeave_Result mobspSelectLeave_Result = Enumerable.FirstOrDefault<MobspSelectLeave_Result>((IEnumerable<MobspSelectLeave_Result>)cRMEntities2.MobspSelectLeave(crmUserId, leaveId, leaveTypeId, userId2, null, null, null, null, languageID, defaultLanguageID, null, model.CenterId));
							if (mobspSelectLeave_Result != null && mobspSelectLeave_Result.LeaveStatusId.GetValueOrDefault() == 2)
							{
								cRMSpEntities.MobspCalcAndUpdateTimeAttendanceLeave(mobspSelectLeave_Result.FromDateTime, mobspSelectLeave_Result.RequestUserId, value3, DateTime.Now, registerDatePersian, appType, num);
								DateTime now3 = DateTime.Now;
								DateTime? fromDateTime = mobspSelectLeave_Result.FromDateTime;
								DateTime? toDateTime = mobspSelectLeave_Result.ToDateTime;
								if (fromDateTime.HasValue && toDateTime.HasValue)
								{
									DateTime? dateTime = fromDateTime;
									DateTime dateTime2 = now3;
									if (dateTime.HasValue && dateTime.GetValueOrDefault() <= dateTime2 && toDateTime <= now3)
									{
										int leaveId2 = mobspSelectLeave_Result.LeaveId;
										int valueOrDefault = mobspSelectLeave_Result.LeaveTypeId.GetValueOrDefault();
										string arg2 = "";
										switch (valueOrDefault)
										{
										case 1:
										case 2:
											arg2 = Labels.lblLeave;
											break;
										case 3:
										case 4:
											arg2 = Labels.lblMission;
											break;
										}
										CommonReturnResultViewModel commonReturnResultViewModel = new LeaveController().ActExecuteLeave(leaveId2, valueOrDefault, defLangId, num);
										if (commonReturnResultViewModel != null)
										{
											if (!commonReturnResultViewModel.IsDone)
											{
												text9 = (string.IsNullOrWhiteSpace(commonReturnResultViewModel.Message) ? string.Format(Messages.msgErrorNotEexcuteLeave, arg2) : commonReturnResultViewModel.Message);
											}
										}
										else
										{
											text9 = string.Format(Messages.msgErrorNotEexcuteLeave, arg2);
										}
									}
								}
							}
						}
						text = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
						if (!string.IsNullOrEmpty(text9))
						{
							text = text + "<br>" + text9;
						}
					}
					else
					{
						text = text6;
						status = ServiceResultStatus.Error;
					}
				}
				else
				{
					text = Messages.MobMsgErrorAccessingToken;
					data = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				text = Messages.MobMsgErrorAccessingToken;
				data = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			text = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<List<MobspSelectVerificationRequestDetails_Result>>
		{
			Message = text,
			Data = data,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectVerificationRequestDetails_Result>> ExpireVerifyRequest(VerificationWorkFlowViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangId);
		CRMEntities cRMEntities = null;
		List<MobspSelectVerificationRequestDetails_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : defLangId);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					List<MobspSelectLanguages_Result> list = Enumerable.ToList<MobspSelectLanguages_Result>(Enumerable.Where<MobspSelectLanguages_Result>((IEnumerable<MobspSelectLanguages_Result>)cRMEntities.MobspSelectLanguages(), (Func<MobspSelectLanguages_Result, bool>)((MobspSelectLanguages_Result m) => m.LanguageID != defLangId)));
					string messageText = model.MessageText ?? "";
					string resourceString = MyResource.GetResourceString("MobIsNotVerifiedSubject", "fa-IR", "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
					string text = "";
					List<CrmInternalMessage_Lang> list2 = new List<CrmInternalMessage_Lang>();
					foreach (MobspSelectLanguages_Result item in list)
					{
						string text2 = "";
						string text3 = "";
						text2 = MyResource.GetResourceString("MobIsNotVerifiedSubject", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
						text3 = model.MessageText ?? "";
						text = text + "[LangId=" + item.LanguageID + "|,|Txt=" + text3 + "|,|Subj=" + text2 + "|,|]@";
						list2.Add(new CrmInternalMessage_Lang
						{
							LanguageID = item.LanguageID,
							msgSubject = text2,
							msgBody = text3
						});
					}
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(now.ToString("yyyy", new PersianCulture()));
					short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					string appType = Mobile.Classes.Configuration.AppType;
					int value4 = int.Parse(Financial.Get().Id.ToString());
					ObjectParameter objectParameter = new ObjectParameter("result", "");
					ObjectParameter internalMessageId = new ObjectParameter("InternalMessageId", 0);
					CRMEntities cRMEntities2 = cRMEntities;
					int? verificationRequestId = model.VerificationRequestId;
					int? verificationWorkFlowId = model.VerificationWorkFlowId;
					int? objectId = model.ObjectId;
					string messageTextLang = JsonConvert.SerializeObject(list2);
					DateTime? registerDate = value;
					int? userId = token2.userId;
					int? fPId = value4;
					short? year = value2;
					short? month = value3;
					int? languageID = result;
					int? defaultLanguageID = defLangId;
					int? cancellationStepId = model.CancellationStepId;
					string reasonCancellation = model.ReasonCancellation;
					cRMEntities2.MobspVerificationRequestExpired(verificationRequestId, verificationWorkFlowId, objectId, messageText, messageTextLang, resourceString, registerDate, registerDatePersian, userId, fPId, year, month, appType, languageID, defaultLanguageID, objectParameter, cancellationStepId, reasonCancellation, token2.RollId, 2, internalMessageId, model.CenterId);
					string text4 = "";
					if (objectParameter.Value != null && !string.IsNullOrEmpty(objectParameter.Value.ToString()) && objectParameter.Value.ToString() != "1")
					{
						text4 += Messages.MobMsgErrorDoneOperation;
					}
					if (string.IsNullOrEmpty(text4))
					{
						if ((model.ObjectType == 90 || model.ObjectType == 100) && model.MsgId.GetValueOrDefault() > 0)
						{
							SetMessageRead(model.MsgId.Value, model.MsgTypeId, model.CenterId);
						}
						PushNotif.NewIntMsgNotify(withthread: true, model.CenterId);
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					else
					{
						message = text4;
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
		return new ServiceResult<List<MobspSelectVerificationRequestDetails_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectVerificationRequestDetails_Result>> SendVerificationRequestToVerifyUser(VerificationWorkFlowViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangId);
		CRMEntities cRMEntities = null;
		List<MobspSelectVerificationRequestDetails_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : defLangId);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					List<MobspSelectLanguages_Result> list = Enumerable.ToList<MobspSelectLanguages_Result>(Enumerable.Where<MobspSelectLanguages_Result>((IEnumerable<MobspSelectLanguages_Result>)cRMEntities.MobspSelectLanguages(), (Func<MobspSelectLanguages_Result, bool>)((MobspSelectLanguages_Result m) => m.LanguageID != defLangId)));
					string verificationReqText = model.MessageText ?? "";
					string resourceString = MyResource.GetResourceString("MobVerifiedRequestSubject", "fa-IR", "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
					string text = "";
					foreach (MobspSelectLanguages_Result item in list)
					{
						string text2 = "";
						string text3 = "";
						text2 = MyResource.GetResourceString("MobVerifiedRequestSubject", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
						text3 = model.MessageText ?? "";
						text = text + "[LangId=" + item.LanguageID + "|,|Txt=" + text3 + "|,|Subj=" + text2 + "|,|]@";
					}
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(now.ToString("yyyy", new PersianCulture()));
					short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					string appType = Mobile.Classes.Configuration.AppType;
					int value4 = int.Parse(Financial.Get().Id.ToString());
					int userId = token2.userId;
					if (model.VerificationReqUserId == 0)
					{
						model.VerificationReqUserId = userId;
					}
					ObjectParameter objectParameter = new ObjectParameter("result", 0);
					ObjectParameter internalMessageId = new ObjectParameter("internalMessageId", 0);
					cRMEntities.MobspSendVerificationRequest(model.VerificationWorkFlowId, model.ObjectId, verificationReqText, text, resourceString, value, registerDatePersian, userId, value4, value2, value3, appType, defLangId, objectParameter, model.VerificationReqUserId, internalMessageId, model.CenterId);
					string text4 = "";
					if (objectParameter.Value != null && !string.IsNullOrEmpty(objectParameter.Value.ToString()))
					{
						string text5 = objectParameter.Value.ToString();
						if (text5 == "-2")
						{
							text4 += Messages.msgErrorErrorSendingMessages;
						}
						else if (text5 == "-1")
						{
							text4 += Messages.MobMsgErrorDoneOperation;
						}
					}
					if (string.IsNullOrEmpty(text4))
					{
						if ((model.ObjectType == 90 || model.ObjectType == 100) && model.MsgId.GetValueOrDefault() > 0)
						{
							SetMessageRead(model.MsgId.Value, model.MsgTypeId, model.CenterId);
						}
						PushNotif.NewIntMsgNotify(withthread: true, model.CenterId);
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					else
					{
						message = text4;
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
		return new ServiceResult<List<MobspSelectVerificationRequestDetails_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectVerificationRequestDetails_Result>> SendVerificationRequestToAlternateUser(VerificationWorkFlowViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangId);
		CRMEntities cRMEntities = null;
		List<MobspSelectVerificationRequestDetails_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : defLangId);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					List<MobspSelectLanguages_Result> list = Enumerable.ToList<MobspSelectLanguages_Result>(Enumerable.Where<MobspSelectLanguages_Result>((IEnumerable<MobspSelectLanguages_Result>)cRMEntities.MobspSelectLanguages(), (Func<MobspSelectLanguages_Result, bool>)((MobspSelectLanguages_Result m) => m.LanguageID != defLangId)));
					string verificationReqText = model.MessageText ?? "";
					string resourceString = MyResource.GetResourceString("MobVerifiedRequestSubject", "fa-IR", "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
					string text = "";
					foreach (MobspSelectLanguages_Result item in list)
					{
						string text2 = "";
						string text3 = "";
						text2 = MyResource.GetResourceString("MobVerifiedRequestSubject", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
						text3 = model.MessageText ?? "";
						text = text + "[LangId=" + item.LanguageID + "|,|Txt=" + text3 + "|,|Subj=" + text2 + "|,|]@";
					}
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(now.ToString("yyyy", new PersianCulture()));
					short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					string appType = Mobile.Classes.Configuration.AppType;
					int value4 = int.Parse(Financial.Get().Id.ToString());
					int userId = token2.userId;
					if (model.VerificationReqUserId == 0)
					{
						model.VerificationReqUserId = userId;
					}
					ObjectParameter objectParameter = new ObjectParameter("result", 0);
					cRMEntities.MobspSendVerificationRequestToAlternateUser(model.VerificationWorkFlowId, model.ObjectId, verificationReqText, text, resourceString, value, registerDatePersian, userId, value4, value2, value3, appType, defLangId, objectParameter, model.VerificationReqUserId, model.CenterId);
					string text4 = "";
					if (objectParameter.Value != null && !string.IsNullOrEmpty(objectParameter.Value.ToString()) && objectParameter.Value.ToString() != "1")
					{
						text4 += Messages.MobMsgErrorDoneOperation;
					}
					if (string.IsNullOrEmpty(text4))
					{
						if ((model.ObjectType == 90 || model.ObjectType == 100) && model.MsgId.GetValueOrDefault() > 0)
						{
							SetMessageRead(model.MsgId.Value, model.MsgTypeId, model.CenterId);
						}
						PushNotif.NewIntMsgNotify(withthread: true, model.CenterId);
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					else
					{
						message = text4;
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
		return new ServiceResult<List<MobspSelectVerificationRequestDetails_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectVerificationRequestDetails_Result>> SendVerificationRequestToAlternateUserInStep(VerificationWorkFlowViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		List<MobspSelectVerificationRequestDetails_Result> data = null;
		string text = "";
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
					cRMEntities = new CRMEntities();
					cRMSpEntities = new CRMSpEntities();
					List<MobspSelectLanguages_Result> list = Enumerable.ToList<MobspSelectLanguages_Result>((IEnumerable<MobspSelectLanguages_Result>)cRMEntities.MobspSelectLanguages());
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					now.ToString("HH:mm:ss", new PersianCulture());
					short value2 = short.Parse(now.ToString("yyyy", new PersianCulture()));
					short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					string appType = Mobile.Classes.Configuration.AppType;
					int value4 = int.Parse(Financial.Get().Id.ToString());
					List<CrmInternalMessage_Lang> list2 = new List<CrmInternalMessage_Lang>();
					foreach (MobspSelectLanguages_Result item in list)
					{
						string resourceString = MyResource.GetResourceString("VerifiedRequestSubject", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
						string msgBody = model.MessageText ?? "";
						list2.Add(new CrmInternalMessage_Lang
						{
							LanguageID = item.LanguageID,
							msgSubject = resourceString,
							msgBody = msgBody
						});
					}
					int result3 = 0;
					int.TryParse(model.VerificationReqUserId.ToString(), out result3);
					int result4 = 0;
					int.TryParse(model.AlternateVerifyUserId.ToString(), out result4);
					string resourceString2 = MyResource.GetResourceString("VerifiedRequestSubject", "fa-IR", "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
					if (result4 > 0 && result3 > 0)
					{
						ObjectParameter internalMessageId = new ObjectParameter("InternalMessageId", 0);
						cRMSpEntities.MobspVerificationRequestSendToAltUser(model.VerificationRequestId, model.VerificationWorkFlowId, model.VerificationWorkFlowStepId, model.ObjectId, model.ObjectType, model.VerifyText, JsonConvert.SerializeObject(list2), resourceString2, model.VerifyText, null, 8, model.AlternateVerifyUserId, value, registerDatePersian, token2.userId, value4, value2, value3, appType, result, result2, internalMessageId, model.CenterId);
						text = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					else
					{
						text += Messages.msgErrorHaveNotAlternateVerifyUser;
					}
				}
				else
				{
					text = Messages.MobMsgErrorAccessingToken;
					data = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				text = Messages.MobMsgErrorAccessingToken;
				data = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			text = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<List<MobspSelectVerificationRequestDetails_Result>>
		{
			Message = text,
			Data = data,
			Status = status
		};
	}

	public bool SendMessage(int fromUserId, int toUserId, int msgTypeId, string message, int userId, int objectId, int? workflowStepId = null, int? centerId = null, int? langId = 1065)
	{
		bool result = true;
		try
		{
			int result2 = 1065;
			if (langId.HasValue)
			{
				int.TryParse(langId.ToString(), out result2);
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result3);
			CRMEntities cRMEntities = new CRMEntities();
			DateTime now = DateTime.Now;
			DateTime value = now;
			string text = now.ToString("yyyyMMdd", new PersianCulture());
			string msgdSendTime = now.ToString("HH:mm:ss", new PersianCulture());
			short value2 = short.Parse(now.ToString("yyyy", new PersianCulture()));
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Mobile.Classes.Configuration.AppType;
			int.Parse(Financial.Get().Id.ToString());
			ObjectParameter internalMessageID = new ObjectParameter("InternalMessageID", 0);
			int? msgdTypeId = msgTypeId;
			int? msgdFromUserId = fromUserId;
			int? msgdToUserId = toUserId;
			DateTime? msgdSendDateTime = value;
			int? msgdAttachRecId = objectId;
			int? userId2 = userId;
			short? year = value2;
			short? month = value3;
			DateTime? registerDate = value;
			int? languageID = result3;
			int? firstRegisterUserId = userId;
			DateTime? firstRegisterDate = value;
			int? msgdAttachRecIdI = workflowStepId;
			cRMEntities.MobspInsertInternalMessageSingle(null, null, message, null, msgdTypeId, msgdFromUserId, msgdToUserId, text, msgdSendTime, msgdSendDateTime, null, null, msgdAttachRecId, null, null, userId2, year, month, registerDate, text, appType, languageID, firstRegisterUserId, firstRegisterDate, text, null, internalMessageID, msgdAttachRecIdI, null, null, centerId);
			PushNotif.NewIntMsgNotify(withthread: true, centerId);
		}
		catch
		{
			result = false;
		}
		return result;
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> LeaveSendRequestToReplaceUser(LeaveReplaceUserVerificationRequestLanguageViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
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
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					List<MobspSelectLanguages_Result> list = Enumerable.ToList<MobspSelectLanguages_Result>((IEnumerable<MobspSelectLanguages_Result>)cRMEntities.MobspSelectLanguages());
					MobspSelectLeave_Result mobspSelectLeave_Result = Enumerable.FirstOrDefault<MobspSelectLeave_Result>((IEnumerable<MobspSelectLeave_Result>)cRMEntities.MobspSelectLeave(null, model.LeaveId, null, null, null, null, null, null, result2, result2, null, model.CenterId));
					if (mobspSelectLeave_Result != null)
					{
						int? workflowStepId = null;
						int msgTypeId = 0;
						if (mobspSelectLeave_Result.LeaveTypeOpr.GetValueOrDefault() == 1)
						{
							msgTypeId = 6;
							workflowStepId = mobspSelectLeave_Result.VerificationWorkFlowId ?? mobspSelectLeave_Result.UserDepartmentLeaveVerificationWorkFlowId;
						}
						else if (mobspSelectLeave_Result.LeaveTypeOpr.GetValueOrDefault() == 2)
						{
							msgTypeId = 7;
							workflowStepId = mobspSelectLeave_Result.VerificationWorkFlowId ?? mobspSelectLeave_Result.UserDepartmentMissionVerificationWorkFlowId;
						}
						string text = "";
						foreach (MobspSelectLanguages_Result item in list)
						{
							string text2 = "";
							string text3 = "";
							text2 = MyResource.GetResourceString("MobVerifiedRequestSubject", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
							text3 = model.VerifyText ?? "";
							text = text + "MsgSubj=" + text2 + "|@#@|MsgBody=" + text3 + "|@#@|LangId=" + item.LanguageID + "|@#@||^#^|";
						}
						int userId = UserLogin.CurrentUser.UserId;
						int result3 = 0;
						int.TryParse(mobspSelectLeave_Result.ReplaceUserId.ToString(), out result3);
						if (userId > 0 && result3 > 0)
						{
							SendMessage(userId, result3, msgTypeId, text, token2.userId, model.LeaveId, workflowStepId, model.CenterId, result);
							if (model.MsgId.GetValueOrDefault() > 0)
							{
								SetMessageRead(model.MsgId.Value, model.MsgTypeId, model.CenterId);
							}
							message = Messages.MobMsgSuccessAction;
							status = ServiceResultStatus.Success;
						}
						else
						{
							message = Messages.msgErrorHaveNotAlternateVerifyUser;
							status = ServiceResultStatus.Fail;
						}
					}
					else
					{
						message = Messages.MobMsgErrorDoneOperation;
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
			cRMEntities?.Dispose();
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> LeaveReplaceUserVerificationAction(LeaveReplaceUserVerificationActionViewModel model)
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
		int culture = ((result > 0) ? result : defLangId);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					List<MobspSelectLanguages_Result> list = Enumerable.ToList<MobspSelectLanguages_Result>((IEnumerable<MobspSelectLanguages_Result>)cRMEntities.MobspSelectLanguages());
					CRMEntities cRMEntities2 = cRMEntities;
					int? leaveId = model.LeaveId;
					int? languageID = defLangId;
					int? defaultLanguageID = defLangId;
					MobspSelectLeave_Result mobspSelectLeave_Result = Enumerable.FirstOrDefault<MobspSelectLeave_Result>((IEnumerable<MobspSelectLeave_Result>)cRMEntities2.MobspSelectLeave(null, leaveId, null, null, null, null, null, null, languageID, defaultLanguageID, null, model.CenterId));
					if (mobspSelectLeave_Result != null)
					{
						DateTime now = DateTime.Now;
						string verifiedRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						_ = UserLogin.CurrentUser.UserId;
						int msgTypeId = 0;
						if (mobspSelectLeave_Result.LeaveTypeOpr.GetValueOrDefault() == 1)
						{
							msgTypeId = 6;
						}
						else if (mobspSelectLeave_Result.LeaveTypeOpr.GetValueOrDefault() == 2)
						{
							msgTypeId = 7;
						}
						if (model.Status == 1)
						{
							cRMEntities.MobspLeaveReplaceUserVerify(mobspSelectLeave_Result.LeaveId, now, verifiedRegisterDatePersian);
							if ((mobspSelectLeave_Result.VerificationWorkFlowId ?? mobspSelectLeave_Result.UserDepartmentLeaveVerificationWorkFlowId.GetValueOrDefault()) != 0)
							{
								VerificationWorkFlowViewModel verificationWorkFlowViewModel = new VerificationWorkFlowViewModel();
								verificationWorkFlowViewModel.ObjectId = mobspSelectLeave_Result.LeaveId;
								if (mobspSelectLeave_Result.LeaveTypeOpr.GetValueOrDefault() == 1)
								{
									verificationWorkFlowViewModel.ObjectType = 90;
									verificationWorkFlowViewModel.FormName = "LEAVE";
									verificationWorkFlowViewModel.VerificationWorkFlowId = mobspSelectLeave_Result.VerificationWorkFlowId ?? mobspSelectLeave_Result.UserDepartmentLeaveVerificationWorkFlowId.GetValueOrDefault();
								}
								else if (mobspSelectLeave_Result.LeaveTypeOpr.GetValueOrDefault() == 2)
								{
									verificationWorkFlowViewModel.ObjectType = 100;
									verificationWorkFlowViewModel.FormName = "MISSION";
									verificationWorkFlowViewModel.VerificationWorkFlowId = mobspSelectLeave_Result.VerificationWorkFlowId ?? mobspSelectLeave_Result.UserDepartmentMissionVerificationWorkFlowId.GetValueOrDefault();
								}
								verificationWorkFlowViewModel.VerificationReqUserId = mobspSelectLeave_Result.RequestUserId.GetValueOrDefault();
								List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
								foreach (MobspSelectLanguages_Result item in list)
								{
									CommonMultiLanguageViewModel commonMultiLanguageViewModel = new CommonMultiLanguageViewModel();
									string value = "";
									if (mobspSelectLeave_Result.LeaveTypeId.GetValueOrDefault() == 1)
									{
										string text = ((!mobspSelectLeave_Result.FromDateTime.HasValue) ? "" : mobspSelectLeave_Result.FromDateTime.Value.ToString("dddd dd MMMM yyyy", new CultureInfo(item.LanguageCollation)));
										value = MyResource.GetResourceString("HourlyLeaveRequestFullDateTimeForUserStr", item.LanguageCollation, "CRM.Resources.Messages", typeof(Labels).GetTypeInfo().Assembly);
										string userName = Mobile.Classes.Helper.User.GetUserName(mobspSelectLeave_Result.RequestUserId.GetValueOrDefault(), item.LanguageID, defLangId);
										value = string.Format(value, userName ?? "", text, mobspSelectLeave_Result.FromTime ?? "", mobspSelectLeave_Result.ToTime ?? "", mobspSelectLeave_Result.HourCount ?? "");
									}
									else if (mobspSelectLeave_Result.LeaveTypeId.GetValueOrDefault() == 2)
									{
										string text2 = ((!mobspSelectLeave_Result.FromDateTime.HasValue) ? "" : mobspSelectLeave_Result.FromDateTime.Value.ToString("dddd yyyy/MM/dd", new CultureInfo(item.LanguageCollation)));
										string text3 = ((!mobspSelectLeave_Result.ToDateTime.HasValue) ? "" : mobspSelectLeave_Result.ToDateTime.Value.ToString("dddd yyyy/MM/dd"));
										value = MyResource.GetResourceString("DailyLeaveRequestFullDateTimeForUserStr", item.LanguageCollation, "CRM.Resources.Messages", typeof(Labels).GetTypeInfo().Assembly);
										string userName2 = Mobile.Classes.Helper.User.GetUserName(mobspSelectLeave_Result.RequestUserId.GetValueOrDefault(), item.LanguageID, defLangId);
										value = string.Format(value, userName2 ?? "", text2, text3, mobspSelectLeave_Result.DayCount.GetValueOrDefault());
									}
									else if (mobspSelectLeave_Result.LeaveTypeId.GetValueOrDefault() == 3)
									{
										string text4 = ((!mobspSelectLeave_Result.FromDateTime.HasValue) ? "" : mobspSelectLeave_Result.FromDateTime.Value.ToString("dddd yyyy/MM/dd", new CultureInfo(item.LanguageCollation)));
										value = MyResource.GetResourceString("HourlyMissionRequestFullDateTimeForUserStr", item.LanguageCollation, "CRM.Resources.Messages", typeof(Labels).GetTypeInfo().Assembly);
										string userName3 = Mobile.Classes.Helper.User.GetUserName(mobspSelectLeave_Result.RequestUserId.GetValueOrDefault(), item.LanguageID, defLangId);
										value = string.Format(value, userName3 ?? "", text4, mobspSelectLeave_Result.FromTime ?? "", mobspSelectLeave_Result.ToTime ?? "", mobspSelectLeave_Result.HourCount ?? "");
									}
									else if (mobspSelectLeave_Result.LeaveTypeId.GetValueOrDefault() == 4)
									{
										string text5 = ((!mobspSelectLeave_Result.FromDateTime.HasValue) ? "" : mobspSelectLeave_Result.FromDateTime.Value.ToString("dddd yyyy/MM/dd", new CultureInfo(item.LanguageCollation)));
										string text6 = ((!mobspSelectLeave_Result.ToDateTime.HasValue) ? "" : mobspSelectLeave_Result.ToDateTime.Value.ToString("dddd yyyy/MM/dd"));
										value = MyResource.GetResourceString("DailyMissionRequestFullDateTimeForUserStr", item.LanguageCollation, "CRM.Resources.Messages", typeof(Labels).GetTypeInfo().Assembly);
										string userName4 = Mobile.Classes.Helper.User.GetUserName(mobspSelectLeave_Result.RequestUserId.GetValueOrDefault(), item.LanguageID, defLangId);
										value = string.Format(value, userName4 ?? "", text5, text6, mobspSelectLeave_Result.DayCount.GetValueOrDefault());
									}
									commonMultiLanguageViewModel.LanguageId = item.LanguageID;
									commonMultiLanguageViewModel.Value = value;
									list2.Add(commonMultiLanguageViewModel);
								}
								if (list2 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2))
								{
									verificationWorkFlowViewModel.MessageText = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)).Value : "");
									verificationWorkFlowViewModel.MessageText_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != defLangId))));
								}
								SendVerificationRequestToVerifyUser(verificationWorkFlowViewModel);
							}
						}
						else if (model.Status == 2)
						{
							cRMEntities.MobspLeaveReplaceUserVerifyExit(mobspSelectLeave_Result.LeaveId);
							string text7 = "";
							foreach (MobspSelectLanguages_Result item2 in list)
							{
								string resourceString = MyResource.GetResourceString("IsNotVerifiedSubject", item2.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
								string format = "";
								if (mobspSelectLeave_Result.LeaveTypeOpr.GetValueOrDefault(1) == 1)
								{
									format = MyResource.GetResourceString("msgLeaveRejectedWithNumber", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Labels).GetTypeInfo().Assembly);
								}
								else if (mobspSelectLeave_Result.LeaveTypeOpr.GetValueOrDefault(1) == 2)
								{
									format = MyResource.GetResourceString("msgMissionRejectedWithNumber", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Labels).GetTypeInfo().Assembly);
								}
								format = string.Format(format, mobspSelectLeave_Result.LeaveId);
								text7 = text7 + "MsgSubj=" + resourceString + "|@#@|MsgBody=" + format + "|@#@|LangId=" + item2.LanguageID + "|@#@||^#^|";
							}
							int userId = UserLogin.CurrentUser.UserId;
							int result2 = 0;
							int.TryParse(mobspSelectLeave_Result.RequestUserId.ToString(), out result2);
							int num = 0;
							if (mobspSelectLeave_Result.LeaveTypeOpr.GetValueOrDefault() == 1)
							{
								num = (mobspSelectLeave_Result.VerificationWorkFlowId ?? mobspSelectLeave_Result.UserDepartmentLeaveVerificationWorkFlowId).GetValueOrDefault();
							}
							else if (mobspSelectLeave_Result.LeaveTypeOpr.GetValueOrDefault() == 2)
							{
								num = (mobspSelectLeave_Result.VerificationWorkFlowId ?? mobspSelectLeave_Result.UserDepartmentMissionVerificationWorkFlowId).GetValueOrDefault();
							}
							if (userId > 0 && result2 > 0 && num > 0)
							{
								SendMessage(userId, result2, msgTypeId, text7, token2.userId, model.LeaveId, num, model.CenterId, result);
								message = Messages.MobMsgSuccessAction;
								status = ServiceResultStatus.Success;
							}
							else
							{
								message = Messages.MobMsgErrorDoneOperation;
								status = ServiceResultStatus.Fail;
							}
						}
						if (model.MsgId.GetValueOrDefault() > 0)
						{
							SetMessageRead(model.MsgId.Value, msgTypeId, model.CenterId);
						}
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					else
					{
						message = Messages.MobMsgErrorDoneOperation;
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
			cRMEntities?.Dispose();
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	public bool SetMessageRead(int msgId, int msgTypeId, int? cId = null)
	{
		new InternalTaskCartableController().UpdateInternalMessage("Read", msgId, msgTypeId, cId);
		return true;
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<MobspSelectVerificationRequestObjectInfo_Result> getVerificationRequestObjectInfo(int objId, int objType, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		MobspSelectVerificationRequestObjectInfo_Result data = null;
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
					data = Enumerable.FirstOrDefault<MobspSelectVerificationRequestObjectInfo_Result>((IEnumerable<MobspSelectVerificationRequestObjectInfo_Result>)cRMSpEntities.MobspSelectVerificationRequestObjectInfo(objId, objType, result, result2, cId));
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
		return new ServiceResult<MobspSelectVerificationRequestObjectInfo_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<VerificationWorkflowViewModelNew> GetVerificationWorkflow(int objectType, int objectId, int verificationRequestId, int workflowId = 0, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		VerificationWorkflowViewModelNew verificationWorkflowViewModelNew = null;
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
					verificationWorkflowViewModelNew = new VerificationWorkflowViewModelNew();
					cRMEntities = new CRMEntities();
					cRMSpEntities = new CRMSpEntities();
					if (verificationRequestId == 0)
					{
						MobspSelectVerificationRequests_Result mobspSelectVerificationRequests_Result = Enumerable.FirstOrDefault<MobspSelectVerificationRequests_Result>((IEnumerable<MobspSelectVerificationRequests_Result>)cRMEntities.MobspSelectVerificationRequests(0, objectId, objectType, num, result2));
						if (mobspSelectVerificationRequests_Result != null)
						{
							if (verificationRequestId == 0)
							{
								verificationRequestId = mobspSelectVerificationRequests_Result.VerificationRequestId;
							}
							if (workflowId == 0)
							{
								workflowId = mobspSelectVerificationRequests_Result.VerificationWorkFlowId;
							}
						}
					}
					verificationWorkflowViewModelNew.ObjectId = objectId;
					verificationWorkflowViewModelNew.ObjectTypeId = objectType;
					verificationWorkflowViewModelNew.Workflow = GetVerificationWorkFlowWithId(workflowId);
					verificationWorkflowViewModelNew.WorkFlowSteps = GetVerificationWorkFlowSteps(workflowId);
					verificationWorkflowViewModelNew.VerificationRequest = Enumerable.FirstOrDefault<MobspSelectVerificationRequests_Result>((IEnumerable<MobspSelectVerificationRequests_Result>)GetVerificationRequest(verificationRequestId));
					verificationWorkflowViewModelNew.VerificationRequestDetails = GetVerificationRequestsByReqId(verificationRequestId, 0);
					int? userId = 0;
					int? companyId = 0;
					switch (objectType)
					{
					case 90:
					case 100:
					{
						CRMEntities cRMEntities2 = cRMEntities;
						int? crmUserId = 0;
						int? leaveId = objectId;
						int? languageID = num;
						int? defaultLanguageID = result2;
						MobspSelectLeave_Result mobspSelectLeave_Result = Enumerable.FirstOrDefault<MobspSelectLeave_Result>((IEnumerable<MobspSelectLeave_Result>)cRMEntities2.MobspSelectLeave(crmUserId, leaveId, null, null, null, null, null, null, languageID, defaultLanguageID, null, cId));
						if (mobspSelectLeave_Result != null)
						{
							mobspSelectLeave_Result.ReplaceUserVerifiedDatePersian = mobspSelectLeave_Result.ReplaceUserVerifiedDate?.ToString("yyyy/MM/dd HH:mm");
							mobspSelectLeave_Result.CanceledDatePersian = mobspSelectLeave_Result.CanceledDate?.ToString("yyyy/MM/dd HH:mm");
							mobspSelectLeave_Result.FirstRegisterDatePersian = mobspSelectLeave_Result.FirstRegisterDate?.ToString("yyyy/MM/dd HH:mm");
							mobspSelectLeave_Result.FromDate = mobspSelectLeave_Result.FromDateTime?.ToString("yyyy/MM/dd HH:mm");
							mobspSelectLeave_Result.ToDate = mobspSelectLeave_Result.ToDateTime?.ToString("yyyy/MM/dd HH:mm");
							mobspSelectLeave_Result.VerifiedRegisterDatePersian = mobspSelectLeave_Result.VerifiedRegisterDate?.ToString("yyyy/MM/dd HH:mm");
							verificationWorkflowViewModelNew.FirstRegisterUserId = mobspSelectLeave_Result.FirstRegisterUserId;
							verificationWorkflowViewModelNew.FirstRegisterUserName = mobspSelectLeave_Result.FirstRegisterUser;
							verificationWorkflowViewModelNew.ReplaceUserId = mobspSelectLeave_Result.ReplaceUserId;
							verificationWorkflowViewModelNew.ReplaceUser = mobspSelectLeave_Result.ReplaceUser;
							verificationWorkflowViewModelNew.ReplaceUserIsVerified = mobspSelectLeave_Result.ReplaceUserIsVerified;
							verificationWorkflowViewModelNew.ReplaceUserIsVerifiedDate = mobspSelectLeave_Result.ReplaceUserVerifiedDatePersian;
							verificationWorkflowViewModelNew.FirstRegisterDate = mobspSelectLeave_Result.FirstRegisterDate ?? DateTime.Now;
							verificationWorkflowViewModelNew.ReplaceUserIntMsgId = mobspSelectLeave_Result.ReplaceUserIntMsgId;
							userId = mobspSelectLeave_Result.RequestUserId;
							verificationWorkflowViewModelNew.IsCanceled = mobspSelectLeave_Result.IsCanceled;
							verificationWorkflowViewModelNew.CancelerUserId = mobspSelectLeave_Result.CancelerUserId;
							verificationWorkflowViewModelNew.CancelerUser = mobspSelectLeave_Result.CancelerUser;
							verificationWorkflowViewModelNew.CanceledDate = mobspSelectLeave_Result.CanceledDate;
							verificationWorkflowViewModelNew.CanceledDatePersian = mobspSelectLeave_Result.CanceledDate?.ToString("yyyy/MM/dd HH:mm");
						}
						break;
					}
					case 10:
					{
						MobspSelectPreOrderWithID_Result mobspSelectPreOrderWithID_Result = Enumerable.FirstOrDefault<MobspSelectPreOrderWithID_Result>((IEnumerable<MobspSelectPreOrderWithID_Result>)cRMEntities.MobspSelectPreOrderWithID(objectId, token2.userId, num, result2, cId));
						if (mobspSelectPreOrderWithID_Result != null)
						{
							verificationWorkflowViewModelNew.SellerUserId = mobspSelectPreOrderWithID_Result.pordSellerId;
							verificationWorkflowViewModelNew.SellerUserName = mobspSelectPreOrderWithID_Result.pordSeller;
							verificationWorkflowViewModelNew.ReferUserId = mobspSelectPreOrderWithID_Result.pordReferUserId;
							verificationWorkflowViewModelNew.ReferUserName = mobspSelectPreOrderWithID_Result.pordReferUser;
							verificationWorkflowViewModelNew.FirstRegisterUserId = mobspSelectPreOrderWithID_Result.FirstRegisterUserId;
							verificationWorkflowViewModelNew.FirstRegisterUserName = mobspSelectPreOrderWithID_Result.FirstRegisterUser;
							userId = mobspSelectPreOrderWithID_Result.FirstRegisterUserId;
							companyId = mobspSelectPreOrderWithID_Result.pordCompanyId;
							verificationWorkflowViewModelNew.FirstRegisterDate = mobspSelectPreOrderWithID_Result.FirstRegisterDate ?? DateTime.Now;
							verificationWorkflowViewModelNew.FirstRegisterDatePersian = mobspSelectPreOrderWithID_Result.FirstRegisterDate?.ToString("yyyy/MM/dd HH:mm");
							if (!UserLogin.IsUserAccess("frmPreOrder", "actVerifyAfterExp", UserLogin.CurrentUser, cId) && ((mobspSelectPreOrderWithID_Result.pordExpireDateTime.HasValue && mobspSelectPreOrderWithID_Result.pordExpireDateTime?.Date < DateTime.Now.Date) || mobspSelectPreOrderWithID_Result.pordStatusId.GetValueOrDefault() == 4))
							{
								verificationWorkflowViewModelNew.UnableToStart = true;
								verificationWorkflowViewModelNew.UnableToStartReason = Messages.msgUnableStartVerificationWorkflowCausePreOrderExpired;
							}
						}
						break;
					}
					case 20:
					{
						MobspSelectOrderById_Result mobspSelectOrderById_Result = Enumerable.FirstOrDefault<MobspSelectOrderById_Result>((IEnumerable<MobspSelectOrderById_Result>)cRMSpEntities.MobspSelectOrderById(objectId, num, result2));
						if (mobspSelectOrderById_Result != null)
						{
							verificationWorkflowViewModelNew.SellerUserId = mobspSelectOrderById_Result.ordSellerId;
							verificationWorkflowViewModelNew.SellerUserName = mobspSelectOrderById_Result.ordSeller;
							verificationWorkflowViewModelNew.ReferUserId = mobspSelectOrderById_Result.ordReferUserId;
							verificationWorkflowViewModelNew.ReferUserName = mobspSelectOrderById_Result.ordReferUser;
							verificationWorkflowViewModelNew.FirstRegisterUserId = mobspSelectOrderById_Result.FirstRegisterUserId;
							verificationWorkflowViewModelNew.FirstRegisterUserName = mobspSelectOrderById_Result.FirstRegisterUser;
							verificationWorkflowViewModelNew.FirstRegisterDate = mobspSelectOrderById_Result.FirstRegisterDate ?? DateTime.Now;
							verificationWorkflowViewModelNew.FirstRegisterDatePersian = mobspSelectOrderById_Result.FirstRegisterDate?.ToString("yyyy/MM/dd HH:mm");
							userId = mobspSelectOrderById_Result.FirstRegisterUserId;
							companyId = mobspSelectOrderById_Result.ordCompanyId;
							if (!UserLogin.IsUserAccess("frmOrder", "actVerifyAfterCancel", UserLogin.CurrentUser, cId) && mobspSelectOrderById_Result.ordStatusId.GetValueOrDefault() == 4)
							{
								verificationWorkflowViewModelNew.UnableToStart = true;
								verificationWorkflowViewModelNew.UnableToStartReason = Messages.msgUnableStartVerificationWorkflowCauseOrderCanceled;
							}
						}
						break;
					}
					case 60:
					{
						MobspSelectDocById_Result mobspSelectDocById_Result = Enumerable.FirstOrDefault<MobspSelectDocById_Result>((IEnumerable<MobspSelectDocById_Result>)cRMSpEntities.MobspSelectDocById(objectId, num, result2));
						if (mobspSelectDocById_Result != null)
						{
							verificationWorkflowViewModelNew.FirstRegisterUserId = mobspSelectDocById_Result.FirstRegisterUserId;
							verificationWorkflowViewModelNew.FirstRegisterUserName = mobspSelectDocById_Result.FirstRegisterUser;
							verificationWorkflowViewModelNew.FirstRegisterDate = mobspSelectDocById_Result.FirstRegisterDate ?? DateTime.Now;
							verificationWorkflowViewModelNew.FirstRegisterDatePersian = mobspSelectDocById_Result.FirstRegisterDate?.ToString("yyyy/MM/dd HH:mm");
						}
						break;
					}
					case 80:
					{
						MobspDySelectFormFieldMasterValueWithId_Result mobspDySelectFormFieldMasterValueWithId_Result = Enumerable.FirstOrDefault<MobspDySelectFormFieldMasterValueWithId_Result>((IEnumerable<MobspDySelectFormFieldMasterValueWithId_Result>)cRMEntities.MobspDySelectFormFieldMasterValueWithId(objectId, num, result2));
						if (mobspDySelectFormFieldMasterValueWithId_Result != null)
						{
							verificationWorkflowViewModelNew.FirstRegisterUserId = mobspDySelectFormFieldMasterValueWithId_Result.FirstRegisterUserId;
							verificationWorkflowViewModelNew.FirstRegisterUserName = mobspDySelectFormFieldMasterValueWithId_Result.FirstRegisterUser;
							userId = mobspDySelectFormFieldMasterValueWithId_Result.FirstRegisterUserId;
							verificationWorkflowViewModelNew.FirstRegisterDate = mobspDySelectFormFieldMasterValueWithId_Result.FirstRegisterDate;
							verificationWorkflowViewModelNew.FirstRegisterDatePersian = mobspDySelectFormFieldMasterValueWithId_Result.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm");
						}
						break;
					}
					}
					if (userId.GetValueOrDefault() != 0)
					{
						MobspSelectUsersById_Result mobspSelectUsersById_Result = Enumerable.FirstOrDefault<MobspSelectUsersById_Result>((IEnumerable<MobspSelectUsersById_Result>)cRMEntities.MobspSelectUsersById(userId, result, result2, cId));
						if (mobspSelectUsersById_Result != null)
						{
							verificationWorkflowViewModelNew.ResponsibleUserId = mobspSelectUsersById_Result.ResponsibleUserId;
							verificationWorkflowViewModelNew.ResponsibleUserName = mobspSelectUsersById_Result.ResponsibleUser;
						}
					}
					if (companyId.GetValueOrDefault() != 0)
					{
						MobspSelectCompanyById_Result mobspSelectCompanyById_Result = Enumerable.FirstOrDefault<MobspSelectCompanyById_Result>((IEnumerable<MobspSelectCompanyById_Result>)cRMSpEntities.MobspSelectCompanyById(companyId, result, result2, cId));
						if (mobspSelectCompanyById_Result != null)
						{
							verificationWorkflowViewModelNew.CmpReferUserId = mobspSelectCompanyById_Result.cmpReferUserId;
							verificationWorkflowViewModelNew.CmpReferUserName = mobspSelectCompanyById_Result.ReferUser;
							verificationWorkflowViewModelNew.CmpSuppUserId = mobspSelectCompanyById_Result.cmpSuppUserId;
							verificationWorkflowViewModelNew.CmpSuppUserName = mobspSelectCompanyById_Result.cmpSuppUser;
						}
					}
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					verificationWorkflowViewModelNew = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				verificationWorkflowViewModelNew = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			verificationWorkflowViewModelNew = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<VerificationWorkflowViewModelNew>
		{
			Message = message,
			Data = verificationWorkflowViewModelNew,
			Status = status
		};
	}

	public MobspSelectVerificationWorkFlowWithId_Result GetVerificationWorkFlowWithId(int workflowId = 0, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		MobspSelectVerificationWorkFlowWithId_Result result3 = null;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		try
		{
			cRMSpEntities = new CRMSpEntities();
			MobspSelectVerificationWorkFlowWithId_Result mobspSelectVerificationWorkFlowWithId_Result = Enumerable.FirstOrDefault<MobspSelectVerificationWorkFlowWithId_Result>((IEnumerable<MobspSelectVerificationWorkFlowWithId_Result>)cRMSpEntities.MobspSelectVerificationWorkFlowWithId(workflowId, num, result2));
			if (mobspSelectVerificationWorkFlowWithId_Result != null)
			{
				mobspSelectVerificationWorkFlowWithId_Result.FirstRegisterDatePersian = mobspSelectVerificationWorkFlowWithId_Result.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm");
				mobspSelectVerificationWorkFlowWithId_Result.RegisterDatePersian = mobspSelectVerificationWorkFlowWithId_Result.RegisterDate.ToString("yyyy/MM/dd HH:mm");
				result3 = mobspSelectVerificationWorkFlowWithId_Result;
			}
		}
		catch (Exception)
		{
			result3 = null;
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return result3;
	}

	public List<MobspSelectVerificationWorkFlowSteps_Result> GetVerificationWorkFlowSteps(int workflowId = 0, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspSelectVerificationWorkFlowSteps_Result> result3 = null;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		try
		{
			cRMEntities = new CRMEntities();
			List<MobspSelectVerificationWorkFlowSteps_Result> list = Enumerable.ToList<MobspSelectVerificationWorkFlowSteps_Result>((IEnumerable<MobspSelectVerificationWorkFlowSteps_Result>)cRMEntities.MobspSelectVerificationWorkFlowSteps(workflowId, num, result2));
			if (list != null)
			{
				foreach (MobspSelectVerificationWorkFlowSteps_Result item in list)
				{
					item.FirstRegisterDatePersian = item.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm");
					item.RegisterDatePersian = item.RegisterDate.ToString("yyyy/MM/dd HH:mm");
				}
				result3 = list;
			}
		}
		catch (Exception)
		{
			result3 = null;
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return result3;
	}

	public List<MobspSelectVerificationRequests_Result> GetVerificationRequest(int verificationRequestId = 0, int objectType = 0, int objectId = 0, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspSelectVerificationRequests_Result> result3 = null;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		try
		{
			cRMEntities = new CRMEntities();
			List<MobspSelectVerificationRequests_Result> list = Enumerable.ToList<MobspSelectVerificationRequests_Result>((IEnumerable<MobspSelectVerificationRequests_Result>)cRMEntities.MobspSelectVerificationRequests(verificationRequestId, objectId, objectType, num, result2));
			if (list != null)
			{
				foreach (MobspSelectVerificationRequests_Result item in list)
				{
					item.FirstRegisterDatePersian = item.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm");
					item.RegisterDatePersian = item.RegisterDate.ToString("yyyy/MM/dd HH:mm");
					item.ReplaceUserVerifiedDatePersian = item.ReplaceUserVerifiedDate?.ToString("yyyy/MM/dd HH:mm");
					item.VerificationReqExpiredDatePersian = item.VerificationReqExpiredDateTime?.ToString("yyyy/MM/dd HH:mm");
				}
				result3 = list;
			}
		}
		catch (Exception)
		{
			result3 = null;
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return result3;
	}

	public List<MobspSelectVerificationRequestsByReqId_Result> GetVerificationRequestsByReqId(int requestId = 0, int? ln = 0)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<MobspSelectVerificationRequestsByReqId_Result> result3 = null;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		try
		{
			cRMSpEntities = new CRMSpEntities();
			List<MobspSelectVerificationRequestsByReqId_Result> list = Enumerable.ToList<MobspSelectVerificationRequestsByReqId_Result>((IEnumerable<MobspSelectVerificationRequestsByReqId_Result>)cRMSpEntities.MobspSelectVerificationRequestsByReqId(requestId, num, result2));
			if (list != null)
			{
				foreach (MobspSelectVerificationRequestsByReqId_Result item in list)
				{
					item.FirstRegisterDatePersian = item.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm");
					item.RegisterDatePersian = item.RegisterDate.ToString("yyyy/MM/dd HH:mm");
					item.VerifyDateTimePersian = item.VerifyDateTime?.ToString("yyyy/MM/dd HH:mm");
				}
				result3 = list;
			}
		}
		catch (Exception)
		{
			result3 = null;
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return result3;
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<MobspVerificationRequestBack_Result> BackWorkFloeStep(VerificationRequestsLanguageViewModel vm)
	{
		int result = 1065;
		if (vm.LanguageId.HasValue)
		{
			int.TryParse(vm.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		MobspVerificationRequestBack_Result data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		string text = "";
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
					Enumerable.ToList<MobspSelectLanguages_Result>((IEnumerable<MobspSelectLanguages_Result>)cRMEntities.MobspSelectLanguages());
					DateTime now = DateTime.Now;
					DateTime value = now;
					string text2 = now.ToString("yyyyMMdd", new PersianCulture());
					now.ToString("HH:mm:ss", new PersianCulture());
					short value2 = short.Parse(now.ToString("yyyy", new PersianCulture()));
					short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					string appType = Mobile.Classes.Configuration.AppType;
					int value4 = int.Parse(Financial.Get().Id.ToString());
					text = "";
					string @string = Labels.ResourceManager.GetString("VerifiedRequestSubject", new CultureInfo(result2));
					Labels.ResourceManager.GetString("VerifiedRequestVerify", new CultureInfo(result2));
					List<CrmInternalMessage_Lang> value5 = new List<CrmInternalMessage_Lang>();
					ObjectParameter internalMessageId = new ObjectParameter("InternalMessageId", 0);
					new ObjectParameter("result", "");
					MobspVerificationRequestBack_Result mobspVerificationRequestBack_Result = Enumerable.FirstOrDefault<MobspVerificationRequestBack_Result>((IEnumerable<MobspVerificationRequestBack_Result>)cRMSpEntities.MobspVerificationRequestBack(vm.VerificationRequestId, vm.VerificationWorkFlowId, vm.ObjectId, vm.ObjectType, vm.VerifyText, JsonConvert.SerializeObject(value5), @string, registerDate: value, registerDatePersian: text2, userId: token2.userId, fPId: value4, year1: value2, month1: value3, appType: appType, languageID: num, defaultLanguageID: result2, backToStepId: vm.CancellationStepId, verifyText: vm.ReasonCancellation, verifyReqResultId: 7, internalMessageId: internalMessageId, centerId: vm.CenterId));
					if (mobspVerificationRequestBack_Result != null)
					{
						if (mobspVerificationRequestBack_Result.InsertedRequestDetailId.GetValueOrDefault() == 0)
						{
							text += Messages.msgErrorRunFunction;
						}
						else if (mobspVerificationRequestBack_Result.InternalMessageId.GetValueOrDefault() == 0)
						{
							text += Messages.msgErrorRunFunction;
						}
						status = ServiceResultStatus.Success;
						data = mobspVerificationRequestBack_Result;
						message = text;
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<MobspVerificationRequestBack_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> EditObjectOrder(int objId = 0, int? wfReqId = null, int? wfId = null, int? wfStepId = null, int? modeId = null, int? ln = null)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		modeId = modeId.GetValueOrDefault(1);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			cRMEntities = new CRMEntities();
			cRMSpEntities = new CRMSpEntities();
			int result = 1065;
			if (ln.HasValue)
			{
				int.TryParse(ln.ToString(), out result);
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			int UserId = UserLogin.CurrentUser.UserId;
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					List<EditAfterFixInfoViewModel> list2 = new List<EditAfterFixInfoViewModel>();
					MobspSelectOrderById_Result mobspSelectOrderById_Result = Enumerable.FirstOrDefault<MobspSelectOrderById_Result>((IEnumerable<MobspSelectOrderById_Result>)cRMSpEntities.MobspSelectOrderById(objId, result, result2));
					if (mobspSelectOrderById_Result != null)
					{
						if (!string.IsNullOrWhiteSpace((mobspSelectOrderById_Result.ordEditAfterFixInfoJs ?? "").Replace("[]", "")))
						{
							list2 = JsonConvert.DeserializeObject<List<EditAfterFixInfoViewModel>>(mobspSelectOrderById_Result.ordEditAfterFixInfoJs);
						}
						int num = Enumerable.ToList<EditAfterFixInfoViewModel>(Enumerable.Where<EditAfterFixInfoViewModel>((IEnumerable<EditAfterFixInfoViewModel>)list2, (Func<EditAfterFixInfoViewModel, bool>)((EditAfterFixInfoViewModel x) => !x.eafEndDate.HasValue || x.eafEndDate <= DateTime.Now))).FindIndex((EditAfterFixInfoViewModel x) => x.eafUserId == UserId && x.eafModeId == modeId && x.eafWorkflowReqId == wfReqId && x.eafWorkflowStepId == wfStepId);
						if (num == -1)
						{
							string eafID = System.Guid.NewGuid().ToString();
							EditAfterFixInfoViewModel editAfterFixInfoViewModel = new EditAfterFixInfoViewModel();
							editAfterFixInfoViewModel.eafID = eafID;
							editAfterFixInfoViewModel.eafModeId = modeId.GetValueOrDefault();
							editAfterFixInfoViewModel.eafUserId = UserId;
							editAfterFixInfoViewModel.eafWorkflowId = wfId;
							editAfterFixInfoViewModel.eafWorkflowReqId = wfReqId;
							editAfterFixInfoViewModel.eafWorkflowStepId = wfStepId;
							editAfterFixInfoViewModel.eafRequestDate = DateTime.Now;
							list2.Add(editAfterFixInfoViewModel);
							if (UpdateObject(20, objId, JsonConvert.SerializeObject(list2)))
							{
								message = "";
								status = ServiceResultStatus.Success;
							}
							list.Add(new SelectListItem
							{
								Text = "Data",
								Value = JsonConvert.SerializeObject(editAfterFixInfoViewModel)
							});
							status = ServiceResultStatus.Success;
							message = "";
						}
						else
						{
							list.Add(new SelectListItem
							{
								Text = "Data",
								Value = JsonConvert.SerializeObject(list2[num])
							});
							status = ServiceResultStatus.Success;
							message = "";
						}
					}
					else
					{
						list.Add(new SelectListItem
						{
							Text = "Error",
							Value = Messages.msgErrorOrderNotFound
						});
						status = ServiceResultStatus.Success;
						message = "";
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			list.Add(new SelectListItem
			{
				Text = "Error",
				Value = "Error: " + ex.Message
			});
			status = ServiceResultStatus.Success;
			message = "";
		}
		finally
		{
			cRMEntities?.Dispose();
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = JsonConvert.SerializeObject(list),
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> EditObjectPreOrder(int objId = 0, int? wfReqId = null, int? wfId = null, int? wfStepId = null, int? modeId = null, int? ln = null, int? cId = null)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		modeId = modeId.GetValueOrDefault(1);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			cRMEntities = new CRMEntities();
			cRMSpEntities = new CRMSpEntities();
			int result = 1065;
			if (ln.HasValue)
			{
				int.TryParse(ln.ToString(), out result);
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (base.Request.Headers.Contains("token"))
			{
				string token2 = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token = new Common().GetToken(token2);
				if (token != null)
				{
					List<EditAfterFixInfoViewModel> list2 = new List<EditAfterFixInfoViewModel>();
					MobspSelectPreOrderWithID_Result mobspSelectPreOrderWithID_Result = Enumerable.FirstOrDefault<MobspSelectPreOrderWithID_Result>((IEnumerable<MobspSelectPreOrderWithID_Result>)cRMEntities.MobspSelectPreOrderWithID(objId, token.userId, result, result2, cId));
					if (mobspSelectPreOrderWithID_Result != null)
					{
						if (!string.IsNullOrWhiteSpace((mobspSelectPreOrderWithID_Result.pordEditAfterFixInfoJs ?? "").Replace("[]", "")))
						{
							list2 = JsonConvert.DeserializeObject<List<EditAfterFixInfoViewModel>>(mobspSelectPreOrderWithID_Result.pordEditAfterFixInfoJs);
						}
						int num = Enumerable.ToList<EditAfterFixInfoViewModel>(Enumerable.Where<EditAfterFixInfoViewModel>((IEnumerable<EditAfterFixInfoViewModel>)list2, (Func<EditAfterFixInfoViewModel, bool>)((EditAfterFixInfoViewModel x) => !x.eafEndDate.HasValue || x.eafEndDate <= DateTime.Now))).FindIndex((EditAfterFixInfoViewModel x) => x.eafUserId == token.userId && x.eafModeId == modeId && x.eafWorkflowReqId == wfReqId && x.eafWorkflowStepId == wfStepId);
						if (num == -1)
						{
							string eafID = System.Guid.NewGuid().ToString();
							EditAfterFixInfoViewModel editAfterFixInfoViewModel = new EditAfterFixInfoViewModel();
							editAfterFixInfoViewModel.eafID = eafID;
							editAfterFixInfoViewModel.eafModeId = modeId.GetValueOrDefault();
							editAfterFixInfoViewModel.eafUserId = token.userId;
							editAfterFixInfoViewModel.eafWorkflowId = wfId;
							editAfterFixInfoViewModel.eafWorkflowReqId = wfReqId;
							editAfterFixInfoViewModel.eafWorkflowStepId = wfStepId;
							editAfterFixInfoViewModel.eafRequestDate = DateTime.Now;
							list2.Add(editAfterFixInfoViewModel);
							if (UpdateObject(10, objId, JsonConvert.SerializeObject(list2)))
							{
								message = "";
								status = ServiceResultStatus.Success;
							}
							list.Add(new SelectListItem
							{
								Text = "Data",
								Value = JsonConvert.SerializeObject(editAfterFixInfoViewModel)
							});
							status = ServiceResultStatus.Success;
							message = "";
						}
						else
						{
							list.Add(new SelectListItem
							{
								Text = "Data",
								Value = JsonConvert.SerializeObject(list2[num])
							});
							status = ServiceResultStatus.Success;
							message = "";
						}
					}
					else
					{
						list.Add(new SelectListItem
						{
							Text = "Error",
							Value = Messages.msgErrorPreOrderNotFound
						});
						status = ServiceResultStatus.Success;
						message = "";
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			list.Add(new SelectListItem
			{
				Text = "Error",
				Value = "Error: " + ex.Message
			});
			status = ServiceResultStatus.Success;
			message = "";
		}
		finally
		{
			cRMEntities?.Dispose();
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = JsonConvert.SerializeObject(list),
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> EditObjectBuyOrder(int objId = 0, int? wfReqId = null, int? wfId = null, int? wfStepId = null, int? modeId = null, int? ln = null)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		modeId = modeId.GetValueOrDefault(1);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			cRMEntities = new CRMEntities();
			cRMSpEntities = new CRMSpEntities();
			int result = 1065;
			if (ln.HasValue)
			{
				int.TryParse(ln.ToString(), out result);
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					int lCID = Thread.CurrentThread.CurrentCulture.LCID;
					int UserId = UserLogin.CurrentUser.UserId;
					List<EditAfterFixInfoViewModel> list2 = new List<EditAfterFixInfoViewModel>();
					MobspSelectBuyOrderWithID_Result mobspSelectBuyOrderWithID_Result = Enumerable.FirstOrDefault<MobspSelectBuyOrderWithID_Result>((IEnumerable<MobspSelectBuyOrderWithID_Result>)cRMEntities.MobspSelectBuyOrderWithID(objId, token2.userId, lCID, result2));
					if (mobspSelectBuyOrderWithID_Result != null)
					{
						if (!string.IsNullOrWhiteSpace((mobspSelectBuyOrderWithID_Result.bordEditAfterFixInfoJs ?? "").Replace("[]", "")))
						{
							list2 = JsonConvert.DeserializeObject<List<EditAfterFixInfoViewModel>>(mobspSelectBuyOrderWithID_Result.bordEditAfterFixInfoJs);
						}
						int num = Enumerable.ToList<EditAfterFixInfoViewModel>(Enumerable.Where<EditAfterFixInfoViewModel>((IEnumerable<EditAfterFixInfoViewModel>)list2, (Func<EditAfterFixInfoViewModel, bool>)((EditAfterFixInfoViewModel x) => !x.eafEndDate.HasValue || x.eafEndDate <= DateTime.Now))).FindIndex((EditAfterFixInfoViewModel x) => x.eafUserId == UserId && x.eafModeId == modeId && x.eafWorkflowReqId == wfReqId && x.eafWorkflowStepId == wfStepId);
						if (num == -1)
						{
							string eafID = System.Guid.NewGuid().ToString();
							EditAfterFixInfoViewModel editAfterFixInfoViewModel = new EditAfterFixInfoViewModel();
							editAfterFixInfoViewModel.eafID = eafID;
							editAfterFixInfoViewModel.eafModeId = modeId.GetValueOrDefault();
							editAfterFixInfoViewModel.eafUserId = UserId;
							editAfterFixInfoViewModel.eafWorkflowId = wfId;
							editAfterFixInfoViewModel.eafWorkflowReqId = wfReqId;
							editAfterFixInfoViewModel.eafWorkflowStepId = wfStepId;
							editAfterFixInfoViewModel.eafRequestDate = DateTime.Now;
							list2.Add(editAfterFixInfoViewModel);
							if (UpdateObject(60, objId, JsonConvert.SerializeObject(list2)))
							{
								message = "";
								status = ServiceResultStatus.Success;
							}
							list.Add(new SelectListItem
							{
								Text = "Data",
								Value = JsonConvert.SerializeObject(editAfterFixInfoViewModel)
							});
							status = ServiceResultStatus.Success;
							message = "";
						}
						else
						{
							list.Add(new SelectListItem
							{
								Text = "Data",
								Value = JsonConvert.SerializeObject(list2[num])
							});
							status = ServiceResultStatus.Success;
							message = "";
						}
					}
					else
					{
						list.Add(new SelectListItem
						{
							Text = "Error",
							Value = Messages.msgErrorDocNotFound
						});
						status = ServiceResultStatus.Success;
						message = "";
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			list.Add(new SelectListItem
			{
				Text = "Error",
				Value = "Error: " + ex.Message
			});
			status = ServiceResultStatus.Success;
			message = "";
		}
		finally
		{
			cRMEntities?.Dispose();
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = JsonConvert.SerializeObject(list),
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> EditObjectDoc(int objId = 0, int? wfReqId = null, int? wfId = null, int? wfStepId = null, int? modeId = null, int? ln = null)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		modeId = modeId.GetValueOrDefault(1);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			cRMEntities = new CRMEntities();
			cRMSpEntities = new CRMSpEntities();
			int result = 1065;
			if (ln.HasValue)
			{
				int.TryParse(ln.ToString(), out result);
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					int lCID = Thread.CurrentThread.CurrentCulture.LCID;
					int UserId = UserLogin.CurrentUser.UserId;
					List<EditAfterFixInfoViewModel> list2 = new List<EditAfterFixInfoViewModel>();
					MobspSelectDocById_Result mobspSelectDocById_Result = Enumerable.FirstOrDefault<MobspSelectDocById_Result>((IEnumerable<MobspSelectDocById_Result>)cRMSpEntities.MobspSelectDocById(objId, lCID, result2));
					if (mobspSelectDocById_Result != null)
					{
						if (!string.IsNullOrWhiteSpace((mobspSelectDocById_Result.EditAfterFixInfoJs ?? "").Replace("[]", "")))
						{
							list2 = JsonConvert.DeserializeObject<List<EditAfterFixInfoViewModel>>(mobspSelectDocById_Result.EditAfterFixInfoJs);
						}
						int num = Enumerable.ToList<EditAfterFixInfoViewModel>(Enumerable.Where<EditAfterFixInfoViewModel>((IEnumerable<EditAfterFixInfoViewModel>)list2, (Func<EditAfterFixInfoViewModel, bool>)((EditAfterFixInfoViewModel x) => !x.eafEndDate.HasValue || x.eafEndDate <= DateTime.Now))).FindIndex((EditAfterFixInfoViewModel x) => x.eafUserId == UserId && x.eafModeId == modeId && x.eafWorkflowReqId == wfReqId && x.eafWorkflowStepId == wfStepId);
						if (num == -1)
						{
							string eafID = System.Guid.NewGuid().ToString();
							EditAfterFixInfoViewModel editAfterFixInfoViewModel = new EditAfterFixInfoViewModel();
							editAfterFixInfoViewModel.eafID = eafID;
							editAfterFixInfoViewModel.eafModeId = modeId.GetValueOrDefault();
							editAfterFixInfoViewModel.eafUserId = UserId;
							editAfterFixInfoViewModel.eafWorkflowId = wfId;
							editAfterFixInfoViewModel.eafWorkflowReqId = wfReqId;
							editAfterFixInfoViewModel.eafWorkflowStepId = wfStepId;
							editAfterFixInfoViewModel.eafRequestDate = DateTime.Now;
							list2.Add(editAfterFixInfoViewModel);
							if (UpdateObject(60, objId, JsonConvert.SerializeObject(list2), mobspSelectDocById_Result.OprType.GetValueOrDefault()))
							{
								message = "";
								status = ServiceResultStatus.Success;
							}
							list.Add(new SelectListItem
							{
								Text = "Data",
								Value = JsonConvert.SerializeObject(editAfterFixInfoViewModel)
							});
							status = ServiceResultStatus.Success;
							message = "";
						}
						else
						{
							list.Add(new SelectListItem
							{
								Text = "Data",
								Value = JsonConvert.SerializeObject(list2[num])
							});
							status = ServiceResultStatus.Success;
							message = "";
						}
					}
					else
					{
						list.Add(new SelectListItem
						{
							Text = "Error",
							Value = Messages.msgErrorDocNotFound
						});
						status = ServiceResultStatus.Success;
						message = "";
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			list.Add(new SelectListItem
			{
				Text = "Error",
				Value = "Error: " + ex.Message
			});
			status = ServiceResultStatus.Success;
			message = "";
		}
		finally
		{
			cRMEntities?.Dispose();
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = JsonConvert.SerializeObject(list),
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> EditObjectDraft(int objId = 0, int? wfReqId = null, int? wfId = null, int? wfStepId = null, int? modeId = null, int? ln = null)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		modeId = modeId.GetValueOrDefault(1);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			cRMEntities = new CRMEntities();
			cRMSpEntities = new CRMSpEntities();
			int result = 1065;
			if (ln.HasValue)
			{
				int.TryParse(ln.ToString(), out result);
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					int lCID = Thread.CurrentThread.CurrentCulture.LCID;
					int UserId = UserLogin.CurrentUser.UserId;
					List<EditAfterFixInfoViewModel> list2 = new List<EditAfterFixInfoViewModel>();
					MobspSelectDocById_Result mobspSelectDocById_Result = Enumerable.FirstOrDefault<MobspSelectDocById_Result>((IEnumerable<MobspSelectDocById_Result>)cRMSpEntities.MobspSelectDocById(objId, lCID, result2));
					if (mobspSelectDocById_Result != null)
					{
						if (!string.IsNullOrWhiteSpace((mobspSelectDocById_Result.EditAfterFixInfoJs ?? "").Replace("[]", "")))
						{
							list2 = JsonConvert.DeserializeObject<List<EditAfterFixInfoViewModel>>(mobspSelectDocById_Result.EditAfterFixInfoJs);
						}
						int num = Enumerable.ToList<EditAfterFixInfoViewModel>(Enumerable.Where<EditAfterFixInfoViewModel>((IEnumerable<EditAfterFixInfoViewModel>)list2, (Func<EditAfterFixInfoViewModel, bool>)((EditAfterFixInfoViewModel x) => !x.eafEndDate.HasValue || x.eafEndDate <= DateTime.Now))).FindIndex((EditAfterFixInfoViewModel x) => x.eafUserId == UserId && x.eafModeId == modeId && x.eafWorkflowReqId == wfReqId && x.eafWorkflowStepId == wfStepId);
						if (num == -1)
						{
							string eafID = System.Guid.NewGuid().ToString();
							EditAfterFixInfoViewModel editAfterFixInfoViewModel = new EditAfterFixInfoViewModel();
							editAfterFixInfoViewModel.eafID = eafID;
							editAfterFixInfoViewModel.eafModeId = modeId.GetValueOrDefault();
							editAfterFixInfoViewModel.eafUserId = UserId;
							editAfterFixInfoViewModel.eafWorkflowId = wfId;
							editAfterFixInfoViewModel.eafWorkflowReqId = wfReqId;
							editAfterFixInfoViewModel.eafWorkflowStepId = wfStepId;
							editAfterFixInfoViewModel.eafRequestDate = DateTime.Now;
							list2.Add(editAfterFixInfoViewModel);
							if (UpdateObject(60, objId, JsonConvert.SerializeObject(list2), mobspSelectDocById_Result.OprType.GetValueOrDefault()))
							{
								message = "";
								status = ServiceResultStatus.Success;
							}
							list.Add(new SelectListItem
							{
								Text = "Data",
								Value = JsonConvert.SerializeObject(editAfterFixInfoViewModel)
							});
							status = ServiceResultStatus.Success;
							message = "";
						}
						else
						{
							list.Add(new SelectListItem
							{
								Text = "Data",
								Value = JsonConvert.SerializeObject(list2[num])
							});
							status = ServiceResultStatus.Success;
							message = "";
						}
					}
					else
					{
						list.Add(new SelectListItem
						{
							Text = "Error",
							Value = Messages.msgErrorDocNotFound
						});
						status = ServiceResultStatus.Success;
						message = "";
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			list.Add(new SelectListItem
			{
				Text = "Error",
				Value = "Error: " + ex.Message
			});
			status = ServiceResultStatus.Success;
			message = "";
		}
		finally
		{
			cRMEntities?.Dispose();
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = JsonConvert.SerializeObject(list),
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> EditObjectMovement(int objId = 0, int? wfReqId = null, int? wfId = null, int? wfStepId = null, int? modeId = null, int? ln = null)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		modeId = modeId.GetValueOrDefault(1);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			cRMEntities = new CRMEntities();
			cRMSpEntities = new CRMSpEntities();
			int result = 1065;
			if (ln.HasValue)
			{
				int.TryParse(ln.ToString(), out result);
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					int lCID = Thread.CurrentThread.CurrentCulture.LCID;
					int UserId = UserLogin.CurrentUser.UserId;
					List<EditAfterFixInfoViewModel> list2 = new List<EditAfterFixInfoViewModel>();
					MobspSelectDocById_Result mobspSelectDocById_Result = Enumerable.FirstOrDefault<MobspSelectDocById_Result>((IEnumerable<MobspSelectDocById_Result>)cRMSpEntities.MobspSelectDocById(objId, lCID, result2));
					if (mobspSelectDocById_Result != null)
					{
						if (!string.IsNullOrWhiteSpace((mobspSelectDocById_Result.EditAfterFixInfoJs ?? "").Replace("[]", "")))
						{
							list2 = JsonConvert.DeserializeObject<List<EditAfterFixInfoViewModel>>(mobspSelectDocById_Result.EditAfterFixInfoJs);
						}
						int num = Enumerable.ToList<EditAfterFixInfoViewModel>(Enumerable.Where<EditAfterFixInfoViewModel>((IEnumerable<EditAfterFixInfoViewModel>)list2, (Func<EditAfterFixInfoViewModel, bool>)((EditAfterFixInfoViewModel x) => !x.eafEndDate.HasValue || x.eafEndDate <= DateTime.Now))).FindIndex((EditAfterFixInfoViewModel x) => x.eafUserId == UserId && x.eafModeId == modeId && x.eafWorkflowReqId == wfReqId && x.eafWorkflowStepId == wfStepId);
						if (num == -1)
						{
							string eafID = System.Guid.NewGuid().ToString();
							EditAfterFixInfoViewModel editAfterFixInfoViewModel = new EditAfterFixInfoViewModel();
							editAfterFixInfoViewModel.eafID = eafID;
							editAfterFixInfoViewModel.eafModeId = modeId.GetValueOrDefault();
							editAfterFixInfoViewModel.eafUserId = UserId;
							editAfterFixInfoViewModel.eafWorkflowId = wfId;
							editAfterFixInfoViewModel.eafWorkflowReqId = wfReqId;
							editAfterFixInfoViewModel.eafWorkflowStepId = wfStepId;
							editAfterFixInfoViewModel.eafRequestDate = DateTime.Now;
							list2.Add(editAfterFixInfoViewModel);
							if (UpdateObject(60, objId, JsonConvert.SerializeObject(list2), mobspSelectDocById_Result.OprType.GetValueOrDefault()))
							{
								message = "";
								status = ServiceResultStatus.Success;
							}
							list.Add(new SelectListItem
							{
								Text = "Data",
								Value = JsonConvert.SerializeObject(editAfterFixInfoViewModel)
							});
							status = ServiceResultStatus.Success;
							message = "";
						}
						else
						{
							list.Add(new SelectListItem
							{
								Text = "Data",
								Value = JsonConvert.SerializeObject(list2[num])
							});
							status = ServiceResultStatus.Success;
							message = "";
						}
					}
					else
					{
						list.Add(new SelectListItem
						{
							Text = "Error",
							Value = Messages.msgErrorDocNotFound
						});
						status = ServiceResultStatus.Success;
						message = "";
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			list.Add(new SelectListItem
			{
				Text = "Error",
				Value = "Error: " + ex.Message
			});
			status = ServiceResultStatus.Success;
			message = "";
		}
		finally
		{
			cRMEntities?.Dispose();
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = JsonConvert.SerializeObject(list),
			Status = status
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> EditObjectDyForm(int objId = 0, int? wfReqId = null, int? wfId = null, int? wfStepId = null, int? modeId = null, int? ln = null)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		modeId = modeId.GetValueOrDefault(1);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			cRMEntities = new CRMEntities();
			cRMSpEntities = new CRMSpEntities();
			int result = 1065;
			if (ln.HasValue)
			{
				int.TryParse(ln.ToString(), out result);
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (base.Request.Headers.Contains("token"))
			{
				string token2 = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token = new Common().GetToken(token2);
				if (token != null)
				{
					List<EditAfterFixInfoViewModel> list2 = new List<EditAfterFixInfoViewModel>();
					MobspDySelectFormFieldMasterValueWithId_Result mobspDySelectFormFieldMasterValueWithId_Result = Enumerable.FirstOrDefault<MobspDySelectFormFieldMasterValueWithId_Result>((IEnumerable<MobspDySelectFormFieldMasterValueWithId_Result>)cRMEntities.MobspDySelectFormFieldMasterValueWithId(objId, result, result2));
					if (mobspDySelectFormFieldMasterValueWithId_Result != null)
					{
						if (!string.IsNullOrWhiteSpace((mobspDySelectFormFieldMasterValueWithId_Result.EditAfterFixInfoJs ?? "").Replace("[]", "")))
						{
							list2 = JsonConvert.DeserializeObject<List<EditAfterFixInfoViewModel>>(mobspDySelectFormFieldMasterValueWithId_Result.EditAfterFixInfoJs);
						}
						int num = Enumerable.ToList<EditAfterFixInfoViewModel>(Enumerable.Where<EditAfterFixInfoViewModel>((IEnumerable<EditAfterFixInfoViewModel>)list2, (Func<EditAfterFixInfoViewModel, bool>)((EditAfterFixInfoViewModel x) => !x.eafEndDate.HasValue || x.eafEndDate <= DateTime.Now))).FindIndex((EditAfterFixInfoViewModel x) => x.eafUserId == token.userId && x.eafModeId == modeId && x.eafWorkflowReqId == wfReqId && x.eafWorkflowStepId == wfStepId);
						if (num == -1)
						{
							string eafID = System.Guid.NewGuid().ToString();
							EditAfterFixInfoViewModel editAfterFixInfoViewModel = new EditAfterFixInfoViewModel();
							editAfterFixInfoViewModel.eafID = eafID;
							editAfterFixInfoViewModel.eafModeId = modeId.GetValueOrDefault();
							editAfterFixInfoViewModel.eafUserId = token.userId;
							editAfterFixInfoViewModel.eafWorkflowId = wfId;
							editAfterFixInfoViewModel.eafWorkflowReqId = wfReqId;
							editAfterFixInfoViewModel.eafWorkflowStepId = wfStepId;
							editAfterFixInfoViewModel.eafRequestDate = DateTime.Now;
							list2.Add(editAfterFixInfoViewModel);
							if (UpdateObject(80, objId, JsonConvert.SerializeObject(list2)))
							{
								message = "";
								status = ServiceResultStatus.Success;
							}
							list.Add(new SelectListItem
							{
								Text = "Data",
								Value = JsonConvert.SerializeObject(editAfterFixInfoViewModel)
							});
							status = ServiceResultStatus.Success;
							message = "";
						}
						else
						{
							list.Add(new SelectListItem
							{
								Text = "Data",
								Value = JsonConvert.SerializeObject(list2[num])
							});
							status = ServiceResultStatus.Success;
							message = "";
						}
					}
					else
					{
						list.Add(new SelectListItem
						{
							Text = "Error",
							Value = Messages.msgErrorDocNotFound
						});
						status = ServiceResultStatus.Success;
						message = "";
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			list.Add(new SelectListItem
			{
				Text = "Error",
				Value = "Error: " + ex.Message
			});
			status = ServiceResultStatus.Success;
			message = "";
		}
		finally
		{
			cRMEntities?.Dispose();
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = JsonConvert.SerializeObject(list),
			Status = status
		};
	}

	public bool UpdateObject(int objectTypeId, int objectId, string EditAfterFixInfoJs, int exId = 0)
	{
		bool result = false;
		CRMSpEntities cRMSpEntities = null;
		try
		{
			cRMSpEntities = new CRMSpEntities();
			if (objectId != 0)
			{
				switch (objectTypeId)
				{
				case 10:
					cRMSpEntities.MobspUpdatePreOrderEditAfterFixInfoJs(objectId, EditAfterFixInfoJs);
					result = true;
					break;
				case 20:
					cRMSpEntities.MobspUpdateOrderEditAfterFixInfoJs(objectId, EditAfterFixInfoJs);
					result = true;
					break;
				case 40:
					cRMSpEntities.MobspUpdateBuyOrderEditAfterFixInfoJs(objectId, EditAfterFixInfoJs);
					result = true;
					break;
				case 60:
					switch (exId)
					{
					case 1:
						cRMSpEntities.MobspUpdateDocEditAfterFixInfoJs(objectId, EditAfterFixInfoJs);
						break;
					case 2:
						cRMSpEntities.MobspUpdateDocEditAfterFixInfoJs(objectId, EditAfterFixInfoJs);
						break;
					case 3:
						cRMSpEntities.MobspUpdateDocEditAfterFixInfoJs(objectId, EditAfterFixInfoJs);
						break;
					}
					result = true;
					break;
				case 80:
					cRMSpEntities.MobspUpdateDyFormEditAfterFixInfoJs(objectId, EditAfterFixInfoJs);
					result = true;
					break;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = false;
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return result;
	}
}
