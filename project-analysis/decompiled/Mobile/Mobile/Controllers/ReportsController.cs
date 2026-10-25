using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Objects;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using CRM.General.Calendar;
using CRM.General.IO;
using CRM.General.Security;
using CRM.Resources;
using Elmah;
using GSD.Globalization;
using Mobile.Cache.Setting;
using Mobile.Classes;
using Mobile.Classes.Helper;
using Mobile.DataType;
using Mobile.Models;
using Mobile.Models.ReportModel.BuyOrderPrintRpt;
using Mobile.Models.ReportModel.DocPrintRpt;
using Mobile.Models.ReportModel.DraftPrintRpt;
using Mobile.Models.ReportModel.OrderPaymentPrintRpt;
using Mobile.Models.ReportModel.OrderPrintRpt;
using Mobile.Models.ReportModel.PreOrderPaymentPrintRpt;
using Mobile.Models.ReportModel.PreOrderPrintRpt;
using Mobile.Models.ReportModel.PrintCompanyAccountingDetailsRpt;
using Mobile.Models.ReportModel.PrintCompanyMoneyBagRpt;
using Mobile.Models.ReportModel.PrintDyFormRpt;
using Mobile.Models.ReportModel.PrintFundRpt;
using Mobile.Models.ReportModel.PrintPayRollUserCycleRpt;
using Mobile.Models.ReportModel.PrintPaymentByIdAndTypeRpt;
using Mobile.Models.ReportModel.ReminderProjectCartableRpt;
using Mobile.Models.ReportModel.ReminderUserTaskCartable;
using Mobile.Models.ReportModel.SendLetterPrintRpt;
using Mobile.Models.ReportModel.WarehouseMovementPrintRpt;
using Newtonsoft.Json;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using Stimulsoft.Report;
using Stimulsoft.Report.Components;
using Stimulsoft.Report.Dictionary;
using Stimulsoft.Report.Export;

namespace Mobile.Controllers;

public class ReportsController : ApiController
{
	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> GetPdfPreOrder(ReportViewModel model)
	{
		//IL_1c5e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c63: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c65: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c68: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c86: Expected I4, but got Unknown
		//IL_1c86: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c8a: Invalid comparison between Unknown and I4
		//IL_03b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f5d: Unknown result type (might be due to invalid IL or missing references)
		//IL_176f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1966: Unknown result type (might be due to invalid IL or missing references)
		//IL_1984: Unknown result type (might be due to invalid IL or missing references)
		//IL_198b: Expected O, but got Unknown
		//IL_19b6: Unknown result type (might be due to invalid IL or missing references)
		int result = 1065;
		if (model.Ln.HasValue)
		{
			int.TryParse(model.Ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangId);
		CRMEntities _db = null;
		CRMSpEntities cRMSpEntities = null;
		string text = null;
		string text2 = "";
		ServiceResultStatus serviceResultStatus = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int currLangId = ((result > 0) ? result : defLangId);
		baseInfo.SetCulture(currLangId);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					try
					{
						_db = new CRMEntities();
						cRMSpEntities = new CRMSpEntities();
						StiReport stiReport = new StiReport();
						if (model.Id > 0)
						{
							string text3 = HttpContext.Current.Server.MapPath("~/Areas/Reports/ReportDatasets/");
							string text4 = HttpContext.Current.Server.MapPath("~/Areas/Reports/ReportFiles/");
							string text5 = "";
							Mobile.Models.ReportModel.PreOrderPrintRpt.Parameters parameters = new Mobile.Models.ReportModel.PreOrderPrintRpt.Parameters();
							int userId = token2.userId;
							DateTime now = DateTime.Now;
							string rptDate = now.ToString("yyyy/MM/dd");
							string rptDay = now.ToString("dddd");
							Reports reports = new Reports();
							parameters.SysSetting = reports.GetSysSetting();
							parameters.NotUsed_ListLinkAccData = new List<PordLinkAccDataViewModel>();
							parameters.NotUsed_ListPayLinkAccData = new List<PayLinkAccDataViewModel>();
							parameters.NotUsed_ListCmpAllPayRemainLinkAccData = new List<CmpAccountingLinkAccDataViewModel>();
							MobspSelectCrmsysSetting_Result mobspSelectCrmsysSetting_Result = SysSeting.Get();
							int result2 = 0;
							if (mobspSelectCrmsysSetting_Result != null)
							{
								int.TryParse(mobspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result2);
							}
							List<CRMspSelectLinkAccSettingDBIsActive_Result> list = new List<CRMspSelectLinkAccSettingDBIsActive_Result>();
							if (result2 == 1)
							{
								list = OtherSystems.GetLinkAccSettingDBList(1);
							}
							parameters.CmpLinkAccAllPayRemain = default(decimal);
							int cmpId = 0;
							decimal result3 = default(decimal);
							if (result2 > 0)
							{
								string text6 = "";
								MobspSelectPreOrderWithID_Result mobspSelectPreOrderWithID_Result = Enumerable.FirstOrDefault<MobspSelectPreOrderWithID_Result>((IEnumerable<MobspSelectPreOrderWithID_Result>)_db.MobspSelectPreOrderWithID(userId: token2.userId, preOrderId: model.Id, languageID: currLangId, defaultLanguageID: defLangId, centerId: model.PfCId));
								if (mobspSelectPreOrderWithID_Result != null)
								{
									cmpId = mobspSelectPreOrderWithID_Result.pordCompanyId.GetValueOrDefault();
								}
								switch (result2)
								{
								case 1:
								{
									decimal num = default(decimal);
									if (list == null || !Enumerable.Any<CRMspSelectLinkAccSettingDBIsActive_Result>((IEnumerable<CRMspSelectLinkAccSettingDBIsActive_Result>)list))
									{
										break;
									}
									foreach (CRMspSelectLinkAccSettingDBIsActive_Result item in list)
									{
										int result4 = 0;
										int.TryParse(item.LinkAccSettingDBId.ToString(), out result4);
										if (result4 != 0)
										{
											CmpAccountingLinkAccDataViewModel cmpAccountingLinkAccDataViewModel = new CmpAccountingLinkAccDataViewModel
											{
												DBId = result4,
												DbName = item.LinkAccSettingDbName,
												DbTitle = item.LinkAccSettingDbTitle
											};
											num = default(decimal);
											SepGetCmpAccountingDetail(cmpId, ref num, result4);
											text6 = $"{num:N2}";
											cmpAccountingLinkAccDataViewModel.AllPayRemain = decimal.Parse(text6 ?? "0");
											parameters.NotUsed_ListCmpAllPayRemainLinkAccData.Add(cmpAccountingLinkAccDataViewModel);
										}
									}
									break;
								}
								case 4:
									if (!string.IsNullOrWhiteSpace(model.CmpRemainAccLink ?? ""))
									{
										text6 = model.CmpRemainAccLink ?? "";
									}
									if (string.IsNullOrWhiteSpace(model.CmpRemainAccLinkjs ?? ""))
									{
										break;
									}
									try
									{
										parameters.NotUsed_ListCmpAllPayRemainLinkAccData = new JavaScriptSerializer().Deserialize<List<CmpAccountingLinkAccDataViewModel>>(model.CmpRemainAccLinkjs ?? "");
										if (parameters.NotUsed_ListCmpAllPayRemainLinkAccData == null)
										{
											parameters.NotUsed_ListCmpAllPayRemainLinkAccData = new List<CmpAccountingLinkAccDataViewModel>();
										}
									}
									catch (Exception e)
									{
										ErrorSignal.FromCurrentContext().Raise(e);
									}
									break;
								default:
									if (!string.IsNullOrWhiteSpace(model.CmpRemainAccLink))
									{
										text6 = model.CmpRemainAccLink;
									}
									break;
								}
								if (text6 == Labels.FOMsgErrorTitle)
								{
									text6 = "0.00";
								}
								if (!string.IsNullOrWhiteSpace(text6))
								{
									decimal.TryParse(text6, out result3);
								}
							}
							parameters.CmpLinkAccAllPayRemain = result3;
							parameters.PrintPreOrder = new WSspRpt_PrintPreOrderById_Result();
							parameters.PrintPreOrder = Enumerable.FirstOrDefault<WSspRpt_PrintPreOrderById_Result>((IEnumerable<WSspRpt_PrintPreOrderById_Result>)cRMSpEntities.WSspRpt_PrintPreOrderById(model.Id, currLangId, defLangId, userId, rptDate, rptDay, parameters.CmpLinkAccAllPayRemain));
							if (parameters.PrintPreOrder == null)
							{
								parameters.PrintPreOrder = new WSspRpt_PrintPreOrderById_Result();
							}
							else if (currLangId != 1065)
							{
								if (!string.IsNullOrEmpty(parameters.PrintPreOrder.pordDate))
								{
									parameters.PrintPreOrder.pordDate = PersianDate.GetShamsi2Miladi(parameters.PrintPreOrder.pordDate.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(parameters.PrintPreOrder.prsBirthDate))
								{
									parameters.PrintPreOrder.prsBirthDate = PersianDate.GetShamsi2Miladi(parameters.PrintPreOrder.prsBirthDate.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(parameters.PrintPreOrder.pordDeliveryDate))
								{
									parameters.PrintPreOrder.pordDeliveryDate = PersianDate.GetShamsi2Miladi(parameters.PrintPreOrder.pordDeliveryDate.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(parameters.PrintPreOrder.pordDeliveryEndDate))
								{
									parameters.PrintPreOrder.pordDeliveryEndDate = PersianDate.GetShamsi2Miladi(parameters.PrintPreOrder.pordDeliveryEndDate.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(parameters.PrintPreOrder.RegisterDatePersian))
								{
									parameters.PrintPreOrder.RegisterDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintPreOrder.RegisterDatePersian.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(parameters.PrintPreOrder.pordExpireDate))
								{
									parameters.PrintPreOrder.pordExpireDate = PersianDate.GetShamsi2Miladi(parameters.PrintPreOrder.pordExpireDate.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(parameters.PrintPreOrder.prjStartDate))
								{
									parameters.PrintPreOrder.prjStartDate = PersianDate.GetShamsi2Miladi(parameters.PrintPreOrder.prjStartDate.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(parameters.PrintPreOrder.pordDeadlineDatePersian))
								{
									parameters.PrintPreOrder.pordDeadlineDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintPreOrder.pordDeadlineDatePersian.Replace("/", "")).Replace("/", "");
								}
							}
							List<WSspRpt_PrintPreOrder_Result> list2 = Enumerable.ToList<WSspRpt_PrintPreOrder_Result>((IEnumerable<WSspRpt_PrintPreOrder_Result>)cRMSpEntities.WSspRpt_PrintPreOrder(model.Id, currLangId, defLangId, userId, rptDate, rptDay, parameters.CmpLinkAccAllPayRemain));
							foreach (WSspRpt_PrintPreOrder_Result item2 in list2)
							{
								if (currLangId != 1065)
								{
									if (!string.IsNullOrEmpty(item2.pordDate))
									{
										item2.pordDate = PersianDate.GetShamsi2Miladi(item2.pordDate.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item2.prsBirthDate))
									{
										item2.prsBirthDate = PersianDate.GetShamsi2Miladi(item2.prsBirthDate.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item2.pordDeliveryDate))
									{
										item2.pordDeliveryDate = PersianDate.GetShamsi2Miladi(item2.pordDeliveryDate.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item2.RegisterDatePersian))
									{
										item2.RegisterDatePersian = PersianDate.GetShamsi2Miladi(item2.RegisterDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item2.POIRegisterDatePersian))
									{
										item2.POIRegisterDatePersian = PersianDate.GetShamsi2Miladi(item2.POIRegisterDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item2.LastOrdDate))
									{
										item2.LastOrdDate = PersianDate.GetShamsi2Miladi(item2.LastOrdDate.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item2.pordIDeliveryDatePersian))
									{
										item2.pordIDeliveryDatePersian = PersianDate.GetShamsi2Miladi(item2.pordIDeliveryDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item2.pordDeliveryEndDate))
									{
										item2.pordDeliveryEndDate = PersianDate.GetShamsi2Miladi(item2.pordDeliveryEndDate.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item2.prjStartDate))
									{
										item2.prjStartDate = PersianDate.GetShamsi2Miladi(item2.prjStartDate.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item2.pordDeadlineDatePersian))
									{
										item2.pordDeadlineDatePersian = PersianDate.GetShamsi2Miladi(item2.pordDeadlineDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item2.pordIValidityExpireDatePersian))
									{
										item2.pordIValidityExpireDatePersian = PersianDate.GetShamsi2Miladi(item2.pordIValidityExpireDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item2.pordIDiscountCodeRegisterDatePersian))
									{
										item2.pordIDiscountCodeRegisterDatePersian = PersianDate.GetShamsi2Miladi(item2.pordIDiscountCodeRegisterDatePersian.Replace("/", "")).Replace("/", "");
									}
								}
							}
							byte[] coLoGo = SysSeting.Get().CoLoGo;
							if (coLoGo != null && coLoGo.Length != 0)
							{
								parameters.CoLogo = Convert.ToBase64String(coLoGo);
							}
							parameters.ReportDateTime = now;
							parameters.ReporterUserName = UserLogin.CurrentUser.FullName;
							WSspRpt_PrintPreOrder_Result wSspRpt_PrintPreOrder_Result = Enumerable.FirstOrDefault<WSspRpt_PrintPreOrder_Result>((IEnumerable<WSspRpt_PrintPreOrder_Result>)list2);
							if (wSspRpt_PrintPreOrder_Result == null)
							{
								wSspRpt_PrintPreOrder_Result = new WSspRpt_PrintPreOrder_Result();
								if (parameters.PrintPreOrder != null)
								{
									wSspRpt_PrintPreOrder_Result.PreOrderID = parameters.PrintPreOrder.PreOrderID;
									wSspRpt_PrintPreOrder_Result.pordCompanyId = parameters.PrintPreOrder.pordCompanyId;
									wSspRpt_PrintPreOrder_Result.pordCompanyPersonId = parameters.PrintPreOrder.pordCompanyPersonId;
									wSspRpt_PrintPreOrder_Result.pordProjectId = parameters.PrintPreOrder.pordProjectId;
									wSspRpt_PrintPreOrder_Result.pordReferUserId = parameters.PrintPreOrder.pordReferUserId;
									wSspRpt_PrintPreOrder_Result.pordFirstRegisterUserId = parameters.PrintPreOrder.pordFirstRegisterUserId;
									wSspRpt_PrintPreOrder_Result.UserId = parameters.PrintPreOrder.UserId;
									wSspRpt_PrintPreOrder_Result.pordVerifierId = parameters.PrintPreOrder.pordVerifierId;
									wSspRpt_PrintPreOrder_Result.pordVerificationWorkFlowId = parameters.PrintPreOrder.pordVerificationWorkFlowId;
								}
							}
							string text7 = "";
							if (wSspRpt_PrintPreOrder_Result != null)
							{
								text7 = wSspRpt_PrintPreOrder_Result.pordNumber.ToString();
							}
							parameters.ListPrintPreOrder = list2;
							List<WSspSelectPreOrderItemSpecificationByItemId_Result> list3 = new List<WSspSelectPreOrderItemSpecificationByItemId_Result>();
							foreach (List<WSspSelectPreOrderItemSpecificationByItemId_Result> item3 in Enumerable.Select<WSspRpt_PrintPreOrder_Result, List<WSspSelectPreOrderItemSpecificationByItemId_Result>>((IEnumerable<WSspRpt_PrintPreOrder_Result>)parameters.ListPrintPreOrder, (Func<WSspRpt_PrintPreOrder_Result, List<WSspSelectPreOrderItemSpecificationByItemId_Result>>)((WSspRpt_PrintPreOrder_Result itemSpe) => Enumerable.ToList<WSspSelectPreOrderItemSpecificationByItemId_Result>((IEnumerable<WSspSelectPreOrderItemSpecificationByItemId_Result>)_db.WSspSelectPreOrderItemSpecificationByItemId(itemSpe.PreOrderItemID, currLangId, defLangId)))))
							{
								list3.AddRange(item3);
							}
							foreach (WSspSelectPreOrderItemSpecificationByItemId_Result item4 in list3)
							{
								if (currLangId != 1065)
								{
									if (!string.IsNullOrEmpty(item4.RegisterDatePersian))
									{
										item4.RegisterDatePersian = PersianDate.GetShamsi2Miladi(item4.RegisterDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item4.FirstRegisterDatePersian))
									{
										item4.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(item4.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
									}
								}
							}
							parameters.ListPrintPreOrderItemSpecification = list3;
							List<WSspRpt_PrintPreOrderPayments_Result> list4 = new List<WSspRpt_PrintPreOrderPayments_Result>();
							foreach (List<WSspRpt_PrintPreOrderPayments_Result> item5 in Enumerable.Select<WSspRpt_PrintPreOrder_Result, List<WSspRpt_PrintPreOrderPayments_Result>>((IEnumerable<WSspRpt_PrintPreOrder_Result>)parameters.ListPrintPreOrder, (Func<WSspRpt_PrintPreOrder_Result, List<WSspRpt_PrintPreOrderPayments_Result>>)((WSspRpt_PrintPreOrder_Result itemSpe) => Enumerable.ToList<WSspRpt_PrintPreOrderPayments_Result>((IEnumerable<WSspRpt_PrintPreOrderPayments_Result>)_db.WSspRpt_PrintPreOrderPayments(itemSpe.PreOrderID, currLangId, defLangId)))))
							{
								list4.AddRange(item5);
							}
							foreach (WSspRpt_PrintPreOrderPayments_Result item6 in list4)
							{
								if (currLangId != 1065)
								{
									if (!string.IsNullOrEmpty(item6.RegisterDatePersian))
									{
										item6.RegisterDatePersian = PersianDate.GetShamsi2Miladi(item6.RegisterDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item6.ImportDate))
									{
										item6.ImportDate = PersianDate.GetShamsi2Miladi(item6.ImportDate.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item6.pordpayDocDate))
									{
										item6.pordpayDocDate = PersianDate.GetShamsi2Miladi(item6.pordpayDocDate.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item6.pordpayFirstRegisteDatePersian))
									{
										item6.pordpayFirstRegisteDatePersian = PersianDate.GetShamsi2Miladi(item6.pordpayFirstRegisteDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item6.FirstRegisterDatePersian))
									{
										item6.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(item6.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrWhiteSpace(item6.pordpayVerifiedRegisterDatePersian))
									{
										item6.pordpayVerifiedRegisterDatePersian = PersianDate.GetShamsi2Miladi(item6.pordpayVerifiedRegisterDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrWhiteSpace(item6.pordpayDocDateTemp))
									{
										item6.pordpayDocDateTemp = PersianDate.GetShamsi2Miladi(item6.pordpayDocDateTemp.Replace("/", "")).Replace("/", "");
									}
								}
								if (string.IsNullOrWhiteSpace(item6.pordpayLinkAccData))
								{
									continue;
								}
								List<PayLinkAccDataViewModel> list5 = new JavaScriptSerializer().Deserialize<List<PayLinkAccDataViewModel>>(item6.pordpayLinkAccData);
								if (list5 == null || !Enumerable.Any<PayLinkAccDataViewModel>((IEnumerable<PayLinkAccDataViewModel>)list5))
								{
									continue;
								}
								foreach (PayLinkAccDataViewModel vmLkAcc2 in list5)
								{
									vmLkAcc2.PayId = item6.PreOrderPaymentId;
									CRMspSelectLinkAccSettingDBIsActive_Result cRMspSelectLinkAccSettingDBIsActive_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDBIsActive_Result>((IEnumerable<CRMspSelectLinkAccSettingDBIsActive_Result>)list, (Func<CRMspSelectLinkAccSettingDBIsActive_Result, bool>)((CRMspSelectLinkAccSettingDBIsActive_Result m) => m.LinkAccSettingDBId == vmLkAcc2.DBId.GetValueOrDefault()));
									if (cRMspSelectLinkAccSettingDBIsActive_Result != null)
									{
										vmLkAcc2.DbName = cRMspSelectLinkAccSettingDBIsActive_Result.LinkAccSettingDbName ?? "";
										vmLkAcc2.DbTitle = cRMspSelectLinkAccSettingDBIsActive_Result.LinkAccSettingDbTitle ?? "";
									}
								}
								parameters.NotUsed_ListPayLinkAccData.AddRange(list5);
							}
							parameters.ListPrintPreOrderPayments = list4;
							parameters.ListDyPrintCmpForm = new List<CRMspDyPrintCmpForm_Result>();
							parameters.ListDyPrintPrsForm = new List<CRMspDyPrintPrsForm_Result>();
							parameters.ListDyPrintPrjForm = new List<CRMspDyPrintPrjForm_Result>();
							parameters.ListDyPrintPordForm = new List<CRMspDyPrintPordForm_Result>();
							parameters.ListPrintProjectInformationTree = new List<CRMspPrintProjectInformationTree_Result>();
							if (wSspRpt_PrintPreOrder_Result != null)
							{
								if (wSspRpt_PrintPreOrder_Result.pordCompanyId.HasValue)
								{
									parameters.ListDyPrintCmpForm = Enumerable.ToList<CRMspDyPrintCmpForm_Result>((IEnumerable<CRMspDyPrintCmpForm_Result>)_db.CRMspDyPrintCmpForm(wSspRpt_PrintPreOrder_Result.pordCompanyId, currLangId, defLangId, token2.userId, 0));
								}
								if (wSspRpt_PrintPreOrder_Result.pordCompanyPersonId.HasValue)
								{
									parameters.ListDyPrintPrsForm = Enumerable.ToList<CRMspDyPrintPrsForm_Result>((IEnumerable<CRMspDyPrintPrsForm_Result>)_db.CRMspDyPrintPrsForm(wSspRpt_PrintPreOrder_Result.pordCompanyPersonId, currLangId, defLangId, token2.userId, 0));
								}
								if (wSspRpt_PrintPreOrder_Result.pordProjectId.HasValue)
								{
									parameters.ListDyPrintPrjForm = Enumerable.ToList<CRMspDyPrintPrjForm_Result>((IEnumerable<CRMspDyPrintPrjForm_Result>)_db.CRMspDyPrintPrjForm(wSspRpt_PrintPreOrder_Result.pordProjectId, currLangId, defLangId, token2.userId, 0));
									parameters.ListPrintProjectInformationTree = Enumerable.ToList<CRMspPrintProjectInformationTree_Result>((IEnumerable<CRMspPrintProjectInformationTree_Result>)_db.CRMspPrintProjectInformationTree(wSspRpt_PrintPreOrder_Result.pordProjectId, currLangId, defLangId));
								}
								parameters.ListDyPrintPordForm = Enumerable.ToList<CRMspDyPrintPordForm_Result>((IEnumerable<CRMspDyPrintPordForm_Result>)_db.CRMspDyPrintPordForm(wSspRpt_PrintPreOrder_Result.PreOrderID, currLangId, defLangId, token2.userId, 0));
							}
							parameters.SignatureReferUser = null;
							parameters.SignatureFirstUser = null;
							parameters.SignatureLastEditUser = null;
							parameters.SignatureVerifierUser = null;
							if (wSspRpt_PrintPreOrder_Result != null)
							{
								MobspSelectUserSignatureByUserId_Result mobspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<MobspSelectUserSignatureByUserId_Result>((IEnumerable<MobspSelectUserSignatureByUserId_Result>)_db.MobspSelectUserSignatureByUserId(wSspRpt_PrintPreOrder_Result.pordReferUserId));
								if (mobspSelectUserSignatureByUserId_Result != null && mobspSelectUserSignatureByUserId_Result.Signature != null && mobspSelectUserSignatureByUserId_Result.Signature.Length != 0)
								{
									parameters.SignatureReferUser = mobspSelectUserSignatureByUserId_Result.Signature;
								}
								mobspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<MobspSelectUserSignatureByUserId_Result>((IEnumerable<MobspSelectUserSignatureByUserId_Result>)_db.MobspSelectUserSignatureByUserId(wSspRpt_PrintPreOrder_Result.pordFirstRegisterUserId));
								if (mobspSelectUserSignatureByUserId_Result != null && mobspSelectUserSignatureByUserId_Result.Signature != null && mobspSelectUserSignatureByUserId_Result.Signature.Length != 0)
								{
									parameters.SignatureFirstUser = mobspSelectUserSignatureByUserId_Result.Signature;
								}
								mobspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<MobspSelectUserSignatureByUserId_Result>((IEnumerable<MobspSelectUserSignatureByUserId_Result>)_db.MobspSelectUserSignatureByUserId(wSspRpt_PrintPreOrder_Result.UserId));
								if (mobspSelectUserSignatureByUserId_Result != null && mobspSelectUserSignatureByUserId_Result.Signature != null && mobspSelectUserSignatureByUserId_Result.Signature.Length != 0)
								{
									parameters.SignatureLastEditUser = mobspSelectUserSignatureByUserId_Result.Signature;
								}
								mobspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<MobspSelectUserSignatureByUserId_Result>((IEnumerable<MobspSelectUserSignatureByUserId_Result>)_db.MobspSelectUserSignatureByUserId(wSspRpt_PrintPreOrder_Result.pordVerifierId));
								if (mobspSelectUserSignatureByUserId_Result != null && mobspSelectUserSignatureByUserId_Result.Signature != null && mobspSelectUserSignatureByUserId_Result.Signature.Length != 0)
								{
									parameters.SignatureVerifierUser = mobspSelectUserSignatureByUserId_Result.Signature;
								}
							}
							parameters.NotUsed_ListPrintPreOrderOrderVerificationRequestDetails = new List<WSspRpt_PrintVerificationRequestDetails_Result>();
							if (wSspRpt_PrintPreOrder_Result != null && wSspRpt_PrintPreOrder_Result.pordVerificationWorkFlowId.HasValue)
							{
								parameters.NotUsed_ListPrintPreOrderOrderVerificationRequestDetails = Enumerable.ToList<WSspRpt_PrintVerificationRequestDetails_Result>((IEnumerable<WSspRpt_PrintVerificationRequestDetails_Result>)_db.WSspRpt_PrintVerificationRequestDetails(wSspRpt_PrintPreOrder_Result.PreOrderID, 10, wSspRpt_PrintPreOrder_Result.pordVerificationWorkFlowId, currLangId, defLangId));
								if (parameters.NotUsed_ListPrintPreOrderOrderVerificationRequestDetails != null && Enumerable.Any<WSspRpt_PrintVerificationRequestDetails_Result>((IEnumerable<WSspRpt_PrintVerificationRequestDetails_Result>)parameters.NotUsed_ListPrintPreOrderOrderVerificationRequestDetails))
								{
									foreach (WSspRpt_PrintVerificationRequestDetails_Result notUsed_ListPrintPreOrderOrderVerificationRequestDetail in parameters.NotUsed_ListPrintPreOrderOrderVerificationRequestDetails)
									{
										if (currLangId != 1065)
										{
											if (!string.IsNullOrEmpty(notUsed_ListPrintPreOrderOrderVerificationRequestDetail.VerifyDatePersian))
											{
												notUsed_ListPrintPreOrderOrderVerificationRequestDetail.VerifyDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintPreOrderOrderVerificationRequestDetail.VerifyDatePersian.Replace("/", "")).Replace("/", "");
											}
											if (!string.IsNullOrEmpty(notUsed_ListPrintPreOrderOrderVerificationRequestDetail.FirstRegisterDatePersian))
											{
												notUsed_ListPrintPreOrderOrderVerificationRequestDetail.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintPreOrderOrderVerificationRequestDetail.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
											}
											if (!string.IsNullOrEmpty(notUsed_ListPrintPreOrderOrderVerificationRequestDetail.RegisterDatePersian))
											{
												notUsed_ListPrintPreOrderOrderVerificationRequestDetail.RegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintPreOrderOrderVerificationRequestDetail.RegisterDatePersian.Replace("/", "")).Replace("/", "");
											}
											if (!string.IsNullOrEmpty(notUsed_ListPrintPreOrderOrderVerificationRequestDetail.VerificationReqDatePersian))
											{
												notUsed_ListPrintPreOrderOrderVerificationRequestDetail.VerificationReqDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintPreOrderOrderVerificationRequestDetail.VerificationReqDatePersian.Replace("/", "")).Replace("/", "");
											}
											if (!string.IsNullOrEmpty(notUsed_ListPrintPreOrderOrderVerificationRequestDetail.VerificationReqExpiredDatePersian))
											{
												notUsed_ListPrintPreOrderOrderVerificationRequestDetail.VerificationReqExpiredDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintPreOrderOrderVerificationRequestDetail.VerificationReqExpiredDatePersian.Replace("/", "")).Replace("/", "");
											}
										}
										if (notUsed_ListPrintPreOrderOrderVerificationRequestDetail.VerifyUserSignature != null)
										{
											notUsed_ListPrintPreOrderOrderVerificationRequestDetail.VerifyUserSignatureStr = Convert.ToBase64String(notUsed_ListPrintPreOrderOrderVerificationRequestDetail.VerifyUserSignature);
										}
									}
								}
							}
							if (parameters.NotUsed_ListPrintPreOrderOrderVerificationRequestDetails == null)
							{
								parameters.NotUsed_ListPrintPreOrderOrderVerificationRequestDetails = new List<WSspRpt_PrintVerificationRequestDetails_Result>();
							}
							parameters.NotUsed_ListPreOrderItemPrdPicture = new List<WSspRpt_PrintPreOrderItemPrdPicture_Result>();
							if (wSspRpt_PrintPreOrder_Result != null)
							{
								parameters.NotUsed_ListPreOrderItemPrdPicture = Enumerable.ToList<WSspRpt_PrintPreOrderItemPrdPicture_Result>((IEnumerable<WSspRpt_PrintPreOrderItemPrdPicture_Result>)_db.WSspRpt_PrintPreOrderItemPrdPicture(wSspRpt_PrintPreOrder_Result.PreOrderID, currLangId, defLangId));
							}
							if (parameters.NotUsed_ListPreOrderItemPrdPicture == null)
							{
								parameters.NotUsed_ListPreOrderItemPrdPicture = new List<WSspRpt_PrintPreOrderItemPrdPicture_Result>();
							}
							parameters.NotUsed_ListPreOrderDiscount = new List<WSspRpt_PrintPreOrderDiscounts_Result>();
							if (wSspRpt_PrintPreOrder_Result != null)
							{
								parameters.NotUsed_ListPreOrderDiscount = Enumerable.ToList<WSspRpt_PrintPreOrderDiscounts_Result>((IEnumerable<WSspRpt_PrintPreOrderDiscounts_Result>)cRMSpEntities.WSspRpt_PrintPreOrderDiscounts(wSspRpt_PrintPreOrder_Result.PreOrderID, currLangId, defLangId));
								if (parameters.NotUsed_ListPreOrderDiscount != null && Enumerable.Any<WSspRpt_PrintPreOrderDiscounts_Result>((IEnumerable<WSspRpt_PrintPreOrderDiscounts_Result>)parameters.NotUsed_ListPreOrderDiscount))
								{
									foreach (WSspRpt_PrintPreOrderDiscounts_Result item7 in parameters.NotUsed_ListPreOrderDiscount)
									{
										if (currLangId != 1065)
										{
											if (!string.IsNullOrEmpty(item7.FirstRegisterDatePersian))
											{
												item7.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(item7.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
											}
											if (!string.IsNullOrEmpty(item7.RegisterDatePersian))
											{
												item7.RegisterDatePersian = PersianDate.GetShamsi2Miladi(item7.RegisterDatePersian.Replace("/", "")).Replace("/", "");
											}
										}
									}
								}
							}
							if (parameters.NotUsed_ListPreOrderDiscount == null)
							{
								parameters.NotUsed_ListPreOrderDiscount = new List<WSspRpt_PrintPreOrderDiscounts_Result>();
							}
							string text8 = "";
							if (wSspRpt_PrintPreOrder_Result != null)
							{
								text8 = wSspRpt_PrintPreOrder_Result.pordLinkAccData ?? "";
							}
							else if (parameters.PrintPreOrder != null)
							{
								text8 = parameters.PrintPreOrder.pordLinkAccData ?? "";
							}
							if (!string.IsNullOrWhiteSpace(text8))
							{
								List<PordLinkAccDataViewModel> list6 = new JavaScriptSerializer().Deserialize<List<PordLinkAccDataViewModel>>(text8);
								if (list6 != null && Enumerable.Any<PordLinkAccDataViewModel>((IEnumerable<PordLinkAccDataViewModel>)list6))
								{
									foreach (PordLinkAccDataViewModel vmLkAcc in list6)
									{
										vmLkAcc.PordId = model.Id;
										CRMspSelectLinkAccSettingDBIsActive_Result cRMspSelectLinkAccSettingDBIsActive_Result2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDBIsActive_Result>((IEnumerable<CRMspSelectLinkAccSettingDBIsActive_Result>)list, (Func<CRMspSelectLinkAccSettingDBIsActive_Result, bool>)((CRMspSelectLinkAccSettingDBIsActive_Result m) => m.LinkAccSettingDBId == vmLkAcc.DBId.GetValueOrDefault()));
										if (cRMspSelectLinkAccSettingDBIsActive_Result2 != null)
										{
											vmLkAcc.DbName = cRMspSelectLinkAccSettingDBIsActive_Result2.LinkAccSettingDbName ?? "";
											vmLkAcc.DbTitle = cRMspSelectLinkAccSettingDBIsActive_Result2.LinkAccSettingDbTitle ?? "";
										}
									}
									parameters.NotUsed_ListLinkAccData.AddRange(list6);
								}
							}
							if (parameters.NotUsed_ListLinkAccData == null)
							{
								parameters.NotUsed_ListLinkAccData = new List<PordLinkAccDataViewModel>();
							}
							if (parameters.NotUsed_ListPayLinkAccData == null)
							{
								parameters.NotUsed_ListPayLinkAccData = new List<PayLinkAccDataViewModel>();
							}
							if (parameters.NotUsed_ListCmpAllPayRemainLinkAccData == null)
							{
								parameters.NotUsed_ListCmpAllPayRemainLinkAccData = new List<CmpAccountingLinkAccDataViewModel>();
							}
							int? printFormatID = ((wSspRpt_PrintPreOrder_Result != null && wSspRpt_PrintPreOrder_Result.pordPrintFormatId.HasValue) ? wSspRpt_PrintPreOrder_Result.pordPrintFormatId : new int?(0));
							MobspReturnPrintFormatFileNameById_Result mobspReturnPrintFormatFileNameById_Result = Enumerable.FirstOrDefault<MobspReturnPrintFormatFileNameById_Result>((IEnumerable<MobspReturnPrintFormatFileNameById_Result>)_db.MobspReturnPrintFormatFileNameById(printFormatID));
							if (mobspReturnPrintFormatFileNameById_Result != null)
							{
								text5 = mobspReturnPrintFormatFileNameById_Result.FileNameWeb;
							}
							if ((mobspReturnPrintFormatFileNameById_Result?.CId).GetValueOrDefault() != 0 && !string.IsNullOrWhiteSpace(text4))
							{
								if (!text4.EndsWith("\\"))
								{
									text4 += "\\";
								}
								text4 = text4 + mobspReturnPrintFormatFileNameById_Result.CId + "\\";
							}
							if (string.IsNullOrEmpty(text5))
							{
								text5 = "PreOrderPrint.mrt";
							}
							if (!System.IO.File.Exists(text4 + text5))
							{
								text5 = "PreOrderPrint.mrt";
							}
							XmlSerializer val = new XmlSerializer(typeof(Mobile.Models.ReportModel.PreOrderPrintRpt.Parameters));
							StringWriter stringWriter = new StringWriter();
							XmlWriter val2 = XmlWriter.Create((TextWriter)stringWriter);
							val.Serialize(val2, (object)parameters);
							DataSet val3 = new DataSet();
							val3.ReadXmlSchema(text3 + "PreOrderPrint.xsd");
							XElement val4 = XElement.Parse(stringWriter.ToString());
							val3.ReadXml(((XNode)val4).CreateReader((ReaderOptions)0));
							stiReport.Load(text4 + text5);
							string text9 = "Integrated Security=False;Data Source={DBServer};Initial Catalog={DBName};Password={DBPass};User ID={DBUser}";
							text9 = text9.Replace("{DBServer}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBServer"]));
							text9 = text9.Replace("{DBName}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBName"]));
							text9 = text9.Replace("{DBUser}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBUser"]));
							text9 = text9.Replace("{DBPass}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBPass"]));
							((CollectionBase)stiReport.Dictionary.Databases).Clear();
							stiReport.Dictionary.Databases.Add(new StiSqlDatabase("CRMIdealExtra", text9));
							stiReport.Compile();
							stiReport.RegData(val3);
							stiReport.Render();
							string text10 = HttpContext.Current.Server.MapPath("~/Download") + "\\Reports\\Files\\" + token2.userId;
							if (!System.IO.Directory.Exists(text10))
							{
								System.IO.Directory.CreateDirectory(text10);
								CRM.General.IO.Directory.SetFullControlForEveryOne(text10);
							}
							string path = text10 + "\\Pord-" + text7 + "-" + now.ToString("yyyyMMddHHmmssfff") + ".pdf";
							try
							{
								System.IO.File.Delete(path);
							}
							catch (Exception e2)
							{
								ErrorSignal.FromCurrentContext().Raise(e2);
								text2 = "خطا در یافت";
								text = null;
								serviceResultStatus = ServiceResultStatus.Error;
							}
							StiJpegExportSettings stiJpegExportSettings = new StiJpegExportSettings
							{
								ImageResolution = 300
							};
							int currentPage = Enumerable.Count<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
							string text11 = text10 + "\\Pord-" + text7 + "-" + now.ToString("yyyyMMddHHmmssfff") + ".pdf";
							string text12 = text10 + "\\Pro_Zip_" + text7;
							if (!System.IO.Directory.Exists(text12))
							{
								System.IO.Directory.CreateDirectory(text12);
								CRM.General.IO.Directory.SetFullControlForEveryOne(text12);
							}
							string file = text12 + "\\Pro_001.jpg";
							stiJpegExportSettings.PageRange = new StiPagesRange(currentPage);
							stiReport.ExportDocument(StiExportFormat.ImageJpeg, file, stiJpegExportSettings);
							string[] files = System.IO.Directory.GetFiles(text12);
							if (Enumerable.Any<string>((IEnumerable<string>)files))
							{
								PdfDocument pdfDocument = new PdfDocument();
								for (int i = 0; i < files.Length; i++)
								{
									PdfPage pdfPage = new PdfPage();
									StiPage stiPage = Enumerable.FirstOrDefault<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
									if (stiPage != null)
									{
										if (stiPage.Orientation == StiPageOrientation.Landscape)
										{
											pdfPage.Orientation = PageOrientation.Landscape;
										}
										try
										{
											PaperKind paperSize = stiPage.PaperSize;
											switch (paperSize - 8)
											{
											default:
												if ((int)paperSize != 66)
												{
													break;
												}
												pdfPage.Size = PageSize.A2;
												goto end_IL_1c5c;
											case 0:
												pdfPage.Size = PageSize.A3;
												goto end_IL_1c5c;
											case 1:
												pdfPage.Size = PageSize.A4;
												goto end_IL_1c5c;
											case 3:
												pdfPage.Size = PageSize.A5;
												goto end_IL_1c5c;
											case 4:
												pdfPage.Size = PageSize.B4;
												goto end_IL_1c5c;
											case 5:
												pdfPage.Size = PageSize.B5;
												goto end_IL_1c5c;
											case 2:
												break;
											}
											pdfPage.Size = PageSize.A4;
											end_IL_1c5c:;
										}
										catch (Exception e3)
										{
											ErrorSignal.FromCurrentContext().Raise(e3);
											pdfPage.Size = PageSize.A4;
										}
									}
									pdfDocument.Pages.Add(pdfPage);
									XGraphics xGraphics = XGraphics.FromPdfPage(pdfDocument.Pages[i]);
									XImage xImage = XImage.FromFile(files[i]);
									xGraphics.DrawImage(xImage, 0.0, 0.0);
									xImage.Dispose();
									xGraphics.Dispose();
								}
								pdfDocument.Save(text11);
								pdfDocument.Close();
							}
							try
							{
								DirectoryInfo directoryInfo = new DirectoryInfo(text12);
								FileInfo[] files2 = directoryInfo.GetFiles();
								for (int j = 0; j < files2.Length; j++)
								{
									files2[j].Delete();
								}
								DirectoryInfo[] directories = directoryInfo.GetDirectories();
								for (int j = 0; j < directories.Length; j++)
								{
									directories[j].Delete(recursive: true);
								}
								if (System.IO.Directory.Exists(text12))
								{
									System.IO.Directory.Delete(text12);
								}
							}
							catch (Exception e4)
							{
								ErrorSignal.FromCurrentContext().Raise(e4);
							}
							path = text11;
							string[] array = HttpContext.Current.Request.Url.AbsoluteUri.Split(new string[1] { "/api/" }, StringSplitOptions.None);
							string text13 = "";
							if (array != null)
							{
								string text14 = "/Download/Reports/Files/" + token2.userId + "/Pord-" + text7 + "-" + now.ToString("yyyyMMddHHmmssfff") + ".pdf";
								text13 = ((array[0] != null && array[0] != "") ? (array[0] + text14) : "");
							}
							PrintLog.InsertPrintLog(model.Id, 1, 3);
							text = (System.IO.File.Exists(path) ? text13 : "");
							text2 = Messages.MobMsgSuccessAction;
							serviceResultStatus = ServiceResultStatus.Success;
						}
						else
						{
							text2 = Messages.MobMsgErrorFileNotExist;
							text = null;
							serviceResultStatus = ServiceResultStatus.Error;
						}
					}
					catch (Exception e5)
					{
						text2 = Messages.MobMsgErrorDoneOperation;
						text = null;
						serviceResultStatus = ServiceResultStatus.Error;
						ErrorSignal.FromCurrentContext().Raise(e5);
					}
				}
				else
				{
					text2 = Messages.MobMsgErrorAccessingToken;
					text = null;
					serviceResultStatus = ServiceResultStatus.Error;
				}
			}
			else
			{
				text2 = Messages.MobMsgErrorAccessingToken;
				text = null;
				serviceResultStatus = ServiceResultStatus.Error;
			}
		}
		catch (Exception e6)
		{
			text2 = Messages.MobMsgErrorDoneOperation;
			text = null;
			serviceResultStatus = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e6);
		}
		return new ServiceResult<string>
		{
			Message = text2,
			Data = text,
			Status = serviceResultStatus
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> GetPdfOrder(ReportViewModel model)
	{
		//IL_1ba1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ba6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ba8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bab: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bc9: Expected I4, but got Unknown
		//IL_1bc9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bcd: Invalid comparison between Unknown and I4
		//IL_03b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dba: Unknown result type (might be due to invalid IL or missing references)
		//IL_16b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_18aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_18c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_18cf: Expected O, but got Unknown
		//IL_18fa: Unknown result type (might be due to invalid IL or missing references)
		int result = 1065;
		if (model.Ln.HasValue)
		{
			int.TryParse(model.Ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangId);
		CRMEntities _db = null;
		CRMSpEntities _dbI = null;
		string text = null;
		string text2 = "";
		ServiceResultStatus serviceResultStatus = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int currLangId = ((result > 0) ? result : defLangId);
		baseInfo.SetCulture(currLangId);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					try
					{
						_db = new CRMEntities();
						_dbI = new CRMSpEntities();
						StiReport stiReport = new StiReport();
						if (model.Id > 0)
						{
							string text3 = HttpContext.Current.Server.MapPath("~/Areas/Reports/ReportDatasets/");
							string text4 = HttpContext.Current.Server.MapPath("~/Areas/Reports/ReportFiles/");
							string text5 = "";
							Mobile.Models.ReportModel.OrderPrintRpt.Parameters parameters = new Mobile.Models.ReportModel.OrderPrintRpt.Parameters();
							int userId = token2.userId;
							DateTime now = DateTime.Now;
							string rptDate = now.ToString("yyyy/MM/dd");
							string rptDay = now.ToString("dddd");
							Reports reports = new Reports();
							parameters.SysSetting = reports.GetSysSetting();
							parameters.NotUsed_ListLinkAccData = new List<OrdLinkAccDataViewModel>();
							parameters.NotUsed_ListPayLinkAccData = new List<PayLinkAccDataViewModel>();
							parameters.NotUsed_ListCmpAllPayRemainLinkAccData = new List<CmpAccountingLinkAccDataViewModel>();
							MobspSelectCrmsysSetting_Result mobspSelectCrmsysSetting_Result = SysSeting.Get();
							int result2 = 0;
							if (mobspSelectCrmsysSetting_Result != null)
							{
								int.TryParse(mobspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result2);
							}
							List<CRMspSelectLinkAccSettingDBIsActive_Result> list = new List<CRMspSelectLinkAccSettingDBIsActive_Result>();
							if (result2 == 1)
							{
								list = OtherSystems.GetLinkAccSettingDBList(1);
							}
							parameters.CmpLinkAccAllPayRemain = default(decimal);
							int num = 0;
							decimal result3 = default(decimal);
							if (result2 > 0)
							{
								string text6 = "";
								MobspSelectOrderWithID_Result mobspSelectOrderWithID_Result = Enumerable.FirstOrDefault<MobspSelectOrderWithID_Result>((IEnumerable<MobspSelectOrderWithID_Result>)_db.MobspSelectOrderWithID(userId: token2.userId, orderId: model.Id, languageID: currLangId, defaultLanguageID: defLangId, centerId: model.PfCId));
								if (mobspSelectOrderWithID_Result != null)
								{
									num = mobspSelectOrderWithID_Result.ordCompanyId;
								}
								switch (result2)
								{
								case 1:
								{
									decimal num2 = default(decimal);
									if (list == null || !Enumerable.Any<CRMspSelectLinkAccSettingDBIsActive_Result>((IEnumerable<CRMspSelectLinkAccSettingDBIsActive_Result>)list))
									{
										break;
									}
									foreach (CRMspSelectLinkAccSettingDBIsActive_Result item in list)
									{
										int result4 = 0;
										int.TryParse(item.LinkAccSettingDBId.ToString(), out result4);
										if (result4 != 0)
										{
											CmpAccountingLinkAccDataViewModel cmpAccountingLinkAccDataViewModel = new CmpAccountingLinkAccDataViewModel
											{
												DBId = result4,
												DbName = item.LinkAccSettingDbName,
												DbTitle = item.LinkAccSettingDbTitle
											};
											num2 = default(decimal);
											SepGetCmpAccountingDetail(num, ref num2, result4);
											text6 = $"{num2:N2}";
											cmpAccountingLinkAccDataViewModel.AllPayRemain = decimal.Parse(text6 ?? "0");
											parameters.NotUsed_ListCmpAllPayRemainLinkAccData.Add(cmpAccountingLinkAccDataViewModel);
										}
									}
									break;
								}
								case 4:
									if (!string.IsNullOrWhiteSpace(model.CmpRemainAccLink ?? ""))
									{
										text6 = model.CmpRemainAccLink ?? "";
									}
									if (string.IsNullOrWhiteSpace(model.CmpRemainAccLinkjs ?? ""))
									{
										break;
									}
									try
									{
										parameters.NotUsed_ListCmpAllPayRemainLinkAccData = new JavaScriptSerializer().Deserialize<List<CmpAccountingLinkAccDataViewModel>>(model.CmpRemainAccLinkjs ?? "");
										if (parameters.NotUsed_ListCmpAllPayRemainLinkAccData == null)
										{
											parameters.NotUsed_ListCmpAllPayRemainLinkAccData = new List<CmpAccountingLinkAccDataViewModel>();
										}
									}
									catch (Exception e)
									{
										ErrorSignal.FromCurrentContext().Raise(e);
									}
									break;
								default:
									if (!string.IsNullOrWhiteSpace(model.CmpRemainAccLink))
									{
										text6 = model.CmpRemainAccLink;
									}
									break;
								}
								if (text6 == Labels.FOMsgErrorTitle)
								{
									text6 = "0.00";
								}
								if (!string.IsNullOrWhiteSpace(text6))
								{
									decimal.TryParse(text6, out result3);
								}
							}
							parameters.CmpLinkAccAllPayRemain = result3;
							List<WSspRpt_PrintOrder_Result> list2 = Enumerable.ToList<WSspRpt_PrintOrder_Result>((IEnumerable<WSspRpt_PrintOrder_Result>)_dbI.WSspRpt_PrintOrder(model.Id, currLangId, defLangId, userId, rptDate, rptDay, parameters.CmpLinkAccAllPayRemain));
							foreach (WSspRpt_PrintOrder_Result item2 in list2)
							{
								if (currLangId != 1065)
								{
									if (!string.IsNullOrEmpty(item2.ordDate))
									{
										item2.ordDate = PersianDate.GetShamsi2Miladi(item2.ordDate.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item2.prsBirthDate))
									{
										item2.prsBirthDate = PersianDate.GetShamsi2Miladi(item2.prsBirthDate.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item2.ordDeliveryDate))
									{
										item2.ordDeliveryDate = PersianDate.GetShamsi2Miladi(item2.ordDeliveryDate.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item2.RegisterDatePersian))
									{
										item2.RegisterDatePersian = PersianDate.GetShamsi2Miladi(item2.RegisterDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item2.OIRegisterDatePersian))
									{
										item2.OIRegisterDatePersian = PersianDate.GetShamsi2Miladi(item2.OIRegisterDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item2.LastOrdDate))
									{
										item2.LastOrdDate = PersianDate.GetShamsi2Miladi(item2.LastOrdDate.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item2.ordIDeliveryDatePersian))
									{
										item2.ordIDeliveryDatePersian = PersianDate.GetShamsi2Miladi(item2.ordIDeliveryDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item2.ordDeliveryEndDate))
									{
										item2.ordDeliveryEndDate = PersianDate.GetShamsi2Miladi(item2.ordDeliveryEndDate.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item2.ordDeadlineDatePersian))
									{
										item2.ordDeadlineDatePersian = PersianDate.GetShamsi2Miladi(item2.ordDeadlineDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item2.ordIValidityExpireDatePersian))
									{
										item2.ordIValidityExpireDatePersian = PersianDate.GetShamsi2Miladi(item2.ordIValidityExpireDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item2.ordIDiscountCodeRegisterDatePersian))
									{
										item2.ordIDiscountCodeRegisterDatePersian = PersianDate.GetShamsi2Miladi(item2.ordIDiscountCodeRegisterDatePersian.Replace("/", "")).Replace("/", "");
									}
								}
							}
							byte[] coLoGo = SysSeting.Get().CoLoGo;
							if (coLoGo != null && coLoGo.Length != 0)
							{
								parameters.CoLogo = Convert.ToBase64String(coLoGo);
							}
							parameters.ReportDateTime = now;
							parameters.ReporterUserName = UserLogin.CurrentUser.FullName;
							WSspRpt_PrintOrder_Result wSspRpt_PrintOrder_Result = Enumerable.FirstOrDefault<WSspRpt_PrintOrder_Result>((IEnumerable<WSspRpt_PrintOrder_Result>)list2);
							if (wSspRpt_PrintOrder_Result == null)
							{
								wSspRpt_PrintOrder_Result = new WSspRpt_PrintOrder_Result();
							}
							parameters.NotUsed_ListPrintOrder = list2;
							string text7 = "";
							if (wSspRpt_PrintOrder_Result != null)
							{
								text7 = wSspRpt_PrintOrder_Result.ordNumber.ToString();
							}
							List<WSspRpt_PrintOrderItemSerials_Result> list3 = new List<WSspRpt_PrintOrderItemSerials_Result>();
							foreach (WSspRpt_PrintOrder_Result item3 in parameters.NotUsed_ListPrintOrder)
							{
								List<WSspRpt_PrintOrderItemSerials_Result> collection = Enumerable.ToList<WSspRpt_PrintOrderItemSerials_Result>((IEnumerable<WSspRpt_PrintOrderItemSerials_Result>)_db.WSspRpt_PrintOrderItemSerials(item3.OrderItemID, currLangId, defLangId));
								list3.AddRange(collection);
							}
							foreach (WSspRpt_PrintOrderItemSerials_Result item4 in list3)
							{
								if (currLangId != 1065)
								{
									if (!string.IsNullOrEmpty(item4.RegisterDatePersian))
									{
										item4.RegisterDatePersian = PersianDate.GetShamsi2Miladi(item4.RegisterDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item4.FirstRegisterDatePersian))
									{
										item4.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(item4.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
									}
								}
							}
							parameters.NotUsed_ListPrintOrderItemSerials = list3;
							List<WSspRpt_PrintOrderItems_Result> list4 = new List<WSspRpt_PrintOrderItems_Result>();
							foreach (List<WSspRpt_PrintOrderItems_Result> item5 in Enumerable.Select<WSspRpt_PrintOrder_Result, List<WSspRpt_PrintOrderItems_Result>>((IEnumerable<WSspRpt_PrintOrder_Result>)parameters.NotUsed_ListPrintOrder, (Func<WSspRpt_PrintOrder_Result, List<WSspRpt_PrintOrderItems_Result>>)((WSspRpt_PrintOrder_Result itemSpe) => Enumerable.ToList<WSspRpt_PrintOrderItems_Result>((IEnumerable<WSspRpt_PrintOrderItems_Result>)_dbI.WSspRpt_PrintOrderItems(itemSpe.OrderID, currLangId, defLangId)))))
							{
								list4.AddRange(item5);
							}
							foreach (WSspRpt_PrintOrderItems_Result item6 in list4)
							{
								if (currLangId != 1065)
								{
									if (!string.IsNullOrEmpty(item6.OIRegisterDatePersian))
									{
										item6.OIRegisterDatePersian = PersianDate.GetShamsi2Miladi(item6.OIRegisterDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item6.ordIDeliveryDatePersian))
									{
										item6.ordIDeliveryDatePersian = PersianDate.GetShamsi2Miladi(item6.ordIDeliveryDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item6.ordIValidityExpireDatePersian))
									{
										item6.ordIValidityExpireDatePersian = PersianDate.GetShamsi2Miladi(item6.ordIValidityExpireDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item6.ordIDiscountCodeRegisterDatePersian))
									{
										item6.ordIDiscountCodeRegisterDatePersian = PersianDate.GetShamsi2Miladi(item6.ordIDiscountCodeRegisterDatePersian.Replace("/", "")).Replace("/", "");
									}
								}
							}
							parameters.NotUsed_ListPrintOrderItems = list4;
							List<WSspRpt_PrintOrderPayments_Result> list5 = new List<WSspRpt_PrintOrderPayments_Result>();
							foreach (List<WSspRpt_PrintOrderPayments_Result> item7 in Enumerable.Select<WSspRpt_PrintOrder_Result, List<WSspRpt_PrintOrderPayments_Result>>((IEnumerable<WSspRpt_PrintOrder_Result>)parameters.NotUsed_ListPrintOrder, (Func<WSspRpt_PrintOrder_Result, List<WSspRpt_PrintOrderPayments_Result>>)((WSspRpt_PrintOrder_Result itemSpe) => Enumerable.ToList<WSspRpt_PrintOrderPayments_Result>((IEnumerable<WSspRpt_PrintOrderPayments_Result>)_db.WSspRpt_PrintOrderPayments(itemSpe.OrderID, currLangId, defLangId)))))
							{
								list5.AddRange(item7);
							}
							foreach (WSspRpt_PrintOrderPayments_Result item8 in list5)
							{
								if (currLangId != 1065)
								{
									if (!string.IsNullOrEmpty(item8.RegisterDatePersian))
									{
										item8.RegisterDatePersian = PersianDate.GetShamsi2Miladi(item8.RegisterDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item8.ImportDate))
									{
										item8.ImportDate = PersianDate.GetShamsi2Miladi(item8.ImportDate.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item8.ordpayDocDate))
									{
										item8.ordpayDocDate = PersianDate.GetShamsi2Miladi(item8.ordpayDocDate.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item8.ordpayFirstRegisteDatePersian))
									{
										item8.ordpayFirstRegisteDatePersian = PersianDate.GetShamsi2Miladi(item8.ordpayFirstRegisteDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item8.FirstRegisterDatePersian))
									{
										item8.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(item8.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrWhiteSpace(item8.ordpayVerifiedRegisterDatePersian))
									{
										item8.ordpayVerifiedRegisterDatePersian = PersianDate.GetShamsi2Miladi(item8.ordpayVerifiedRegisterDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrWhiteSpace(item8.ordpayBankDocDatePersian))
									{
										item8.ordpayBankDocDatePersian = PersianDate.GetShamsi2Miladi(item8.ordpayBankDocDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrWhiteSpace(item8.ordpayBankDocRegisterDatePersian))
									{
										item8.ordpayBankDocRegisterDatePersian = PersianDate.GetShamsi2Miladi(item8.ordpayBankDocRegisterDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrWhiteSpace(item8.ordpayDocDateTemp))
									{
										item8.ordpayDocDateTemp = PersianDate.GetShamsi2Miladi(item8.ordpayDocDateTemp.Replace("/", "")).Replace("/", "");
									}
								}
								if (string.IsNullOrWhiteSpace(item8.ordpayLinkAccData))
								{
									continue;
								}
								List<PayLinkAccDataViewModel> list6 = new JavaScriptSerializer().Deserialize<List<PayLinkAccDataViewModel>>(item8.ordpayLinkAccData);
								if (list6 == null || !Enumerable.Any<PayLinkAccDataViewModel>((IEnumerable<PayLinkAccDataViewModel>)list6))
								{
									continue;
								}
								foreach (PayLinkAccDataViewModel vmLkAcc2 in list6)
								{
									vmLkAcc2.PayId = item8.OrderPaymentId;
									CRMspSelectLinkAccSettingDBIsActive_Result cRMspSelectLinkAccSettingDBIsActive_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDBIsActive_Result>((IEnumerable<CRMspSelectLinkAccSettingDBIsActive_Result>)list, (Func<CRMspSelectLinkAccSettingDBIsActive_Result, bool>)((CRMspSelectLinkAccSettingDBIsActive_Result m) => m.LinkAccSettingDBId == vmLkAcc2.DBId.GetValueOrDefault()));
									if (cRMspSelectLinkAccSettingDBIsActive_Result != null)
									{
										vmLkAcc2.DbName = cRMspSelectLinkAccSettingDBIsActive_Result.LinkAccSettingDbName ?? "";
										vmLkAcc2.DbTitle = cRMspSelectLinkAccSettingDBIsActive_Result.LinkAccSettingDbTitle ?? "";
									}
								}
								parameters.NotUsed_ListPayLinkAccData.AddRange(list6);
							}
							parameters.NotUsed_ListPrintOrderPayments = list5;
							CRMspReturnCmpAccountingSummary_Result cmpAccountingSummary = new CRMspReturnCmpAccountingSummary_Result();
							if (list2 != null)
							{
								WSspRpt_PrintOrder_Result wSspRpt_PrintOrder_Result2 = Enumerable.FirstOrDefault<WSspRpt_PrintOrder_Result>((IEnumerable<WSspRpt_PrintOrder_Result>)list2);
								if (wSspRpt_PrintOrder_Result2 != null)
								{
									cmpAccountingSummary = Enumerable.FirstOrDefault<CRMspReturnCmpAccountingSummary_Result>((IEnumerable<CRMspReturnCmpAccountingSummary_Result>)_db.CRMspReturnCmpAccountingSummary(wSspRpt_PrintOrder_Result2.ordCompanyId, null));
								}
							}
							parameters.CmpAccountingSummary = cmpAccountingSummary;
							parameters.ListDyPrintCmpForm = new List<CRMspDyPrintCmpForm_Result>();
							parameters.ListDyPrintPrsForm = new List<CRMspDyPrintPrsForm_Result>();
							parameters.ListDyPrintPrjForm = new List<CRMspDyPrintPrjForm_Result>();
							parameters.ListDyPrintPordForm = new List<CRMspDyPrintPordForm_Result>();
							parameters.ListDyPrintOrdForm = new List<CRMspDyPrintOrdForm_Result>();
							parameters.ListPrintProjectInformationTree = new List<CRMspPrintProjectInformationTree_Result>();
							if (wSspRpt_PrintOrder_Result != null)
							{
								_ = wSspRpt_PrintOrder_Result.ordCompanyId;
								parameters.ListDyPrintCmpForm = Enumerable.ToList<CRMspDyPrintCmpForm_Result>((IEnumerable<CRMspDyPrintCmpForm_Result>)_db.CRMspDyPrintCmpForm(wSspRpt_PrintOrder_Result.ordCompanyId, currLangId, defLangId, token2.userId, 0));
								if (wSspRpt_PrintOrder_Result.ordCompanyPersonId.HasValue)
								{
									parameters.ListDyPrintPrsForm = Enumerable.ToList<CRMspDyPrintPrsForm_Result>((IEnumerable<CRMspDyPrintPrsForm_Result>)_db.CRMspDyPrintPrsForm(wSspRpt_PrintOrder_Result.ordCompanyPersonId, currLangId, defLangId, token2.userId, 0));
								}
								if (wSspRpt_PrintOrder_Result.ordProjectId.HasValue)
								{
									parameters.ListDyPrintPrjForm = Enumerable.ToList<CRMspDyPrintPrjForm_Result>((IEnumerable<CRMspDyPrintPrjForm_Result>)_db.CRMspDyPrintPrjForm(wSspRpt_PrintOrder_Result.ordProjectId, currLangId, defLangId, token2.userId, 0));
									parameters.ListPrintProjectInformationTree = Enumerable.ToList<CRMspPrintProjectInformationTree_Result>((IEnumerable<CRMspPrintProjectInformationTree_Result>)_db.CRMspPrintProjectInformationTree(wSspRpt_PrintOrder_Result.ordProjectId, currLangId, defLangId));
								}
								if (wSspRpt_PrintOrder_Result.PreOrderId.HasValue)
								{
									parameters.ListDyPrintPordForm = Enumerable.ToList<CRMspDyPrintPordForm_Result>((IEnumerable<CRMspDyPrintPordForm_Result>)_db.CRMspDyPrintPordForm(wSspRpt_PrintOrder_Result.PreOrderId, currLangId, defLangId, token2.userId, 0));
								}
								parameters.ListDyPrintOrdForm = Enumerable.ToList<CRMspDyPrintOrdForm_Result>((IEnumerable<CRMspDyPrintOrdForm_Result>)_db.CRMspDyPrintOrdForm(wSspRpt_PrintOrder_Result.OrderID, currLangId, defLangId, token2.userId, 0));
							}
							parameters.Signature = "";
							MobspSelectUserSignatureByUserId_Result mobspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<MobspSelectUserSignatureByUserId_Result>((IEnumerable<MobspSelectUserSignatureByUserId_Result>)_db.MobspSelectUserSignatureByUserId(-10));
							if (mobspSelectUserSignatureByUserId_Result != null && mobspSelectUserSignatureByUserId_Result.Signature != null && mobspSelectUserSignatureByUserId_Result.Signature.Length != 0)
							{
								parameters.Signature = Convert.ToBase64String(mobspSelectUserSignatureByUserId_Result.Signature);
							}
							parameters.SignatureReferUser = null;
							parameters.SignatureLastEditUser = null;
							parameters.SignatureVerifierUser = null;
							if (wSspRpt_PrintOrder_Result != null)
							{
								mobspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<MobspSelectUserSignatureByUserId_Result>((IEnumerable<MobspSelectUserSignatureByUserId_Result>)_db.MobspSelectUserSignatureByUserId(wSspRpt_PrintOrder_Result.ordReferUserId));
								if (mobspSelectUserSignatureByUserId_Result != null && mobspSelectUserSignatureByUserId_Result.Signature != null && mobspSelectUserSignatureByUserId_Result.Signature.Length != 0)
								{
									parameters.SignatureReferUser = mobspSelectUserSignatureByUserId_Result.Signature;
								}
								mobspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<MobspSelectUserSignatureByUserId_Result>((IEnumerable<MobspSelectUserSignatureByUserId_Result>)_db.MobspSelectUserSignatureByUserId(wSspRpt_PrintOrder_Result.UserId));
								if (mobspSelectUserSignatureByUserId_Result != null && mobspSelectUserSignatureByUserId_Result.Signature != null && mobspSelectUserSignatureByUserId_Result.Signature.Length != 0)
								{
									parameters.SignatureLastEditUser = mobspSelectUserSignatureByUserId_Result.Signature;
								}
								mobspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<MobspSelectUserSignatureByUserId_Result>((IEnumerable<MobspSelectUserSignatureByUserId_Result>)_db.MobspSelectUserSignatureByUserId(wSspRpt_PrintOrder_Result.ordVerifierId));
								if (mobspSelectUserSignatureByUserId_Result != null && mobspSelectUserSignatureByUserId_Result.Signature != null && mobspSelectUserSignatureByUserId_Result.Signature.Length != 0)
								{
									parameters.SignatureVerifierUser = mobspSelectUserSignatureByUserId_Result.Signature;
								}
							}
							parameters.NotUsed_ListPrintOrderVerificationRequestDetails = new List<WSspRpt_PrintVerificationRequestDetails_Result>();
							if (wSspRpt_PrintOrder_Result != null && wSspRpt_PrintOrder_Result.ordVerificationWorkFlowId.HasValue)
							{
								parameters.NotUsed_ListPrintOrderVerificationRequestDetails = Enumerable.ToList<WSspRpt_PrintVerificationRequestDetails_Result>((IEnumerable<WSspRpt_PrintVerificationRequestDetails_Result>)_db.WSspRpt_PrintVerificationRequestDetails(wSspRpt_PrintOrder_Result.OrderID, 20, wSspRpt_PrintOrder_Result.ordVerificationWorkFlowId, currLangId, defLangId));
								if (parameters.NotUsed_ListPrintOrderVerificationRequestDetails != null && Enumerable.Any<WSspRpt_PrintVerificationRequestDetails_Result>((IEnumerable<WSspRpt_PrintVerificationRequestDetails_Result>)parameters.NotUsed_ListPrintOrderVerificationRequestDetails))
								{
									foreach (WSspRpt_PrintVerificationRequestDetails_Result notUsed_ListPrintOrderVerificationRequestDetail in parameters.NotUsed_ListPrintOrderVerificationRequestDetails)
									{
										if (currLangId != 1065)
										{
											if (!string.IsNullOrEmpty(notUsed_ListPrintOrderVerificationRequestDetail.VerifyDatePersian))
											{
												notUsed_ListPrintOrderVerificationRequestDetail.VerifyDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintOrderVerificationRequestDetail.VerifyDatePersian.Replace("/", "")).Replace("/", "");
											}
											if (!string.IsNullOrEmpty(notUsed_ListPrintOrderVerificationRequestDetail.FirstRegisterDatePersian))
											{
												notUsed_ListPrintOrderVerificationRequestDetail.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintOrderVerificationRequestDetail.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
											}
											if (!string.IsNullOrEmpty(notUsed_ListPrintOrderVerificationRequestDetail.RegisterDatePersian))
											{
												notUsed_ListPrintOrderVerificationRequestDetail.RegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintOrderVerificationRequestDetail.RegisterDatePersian.Replace("/", "")).Replace("/", "");
											}
											if (!string.IsNullOrEmpty(notUsed_ListPrintOrderVerificationRequestDetail.VerificationReqDatePersian))
											{
												notUsed_ListPrintOrderVerificationRequestDetail.VerificationReqDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintOrderVerificationRequestDetail.VerificationReqDatePersian.Replace("/", "")).Replace("/", "");
											}
											if (!string.IsNullOrEmpty(notUsed_ListPrintOrderVerificationRequestDetail.VerificationReqExpiredDatePersian))
											{
												notUsed_ListPrintOrderVerificationRequestDetail.VerificationReqExpiredDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintOrderVerificationRequestDetail.VerificationReqExpiredDatePersian.Replace("/", "")).Replace("/", "");
											}
										}
										if (notUsed_ListPrintOrderVerificationRequestDetail.VerifyUserSignature != null)
										{
											notUsed_ListPrintOrderVerificationRequestDetail.VerifyUserSignatureStr = Convert.ToBase64String(notUsed_ListPrintOrderVerificationRequestDetail.VerifyUserSignature);
										}
									}
								}
							}
							if (parameters.NotUsed_ListPrintOrderVerificationRequestDetails == null)
							{
								parameters.NotUsed_ListPrintOrderVerificationRequestDetails = new List<WSspRpt_PrintVerificationRequestDetails_Result>();
							}
							parameters.NotUsed_ListPrintOrderDoc = new List<WSspRpt_PrintOrderDoc_Result>();
							if (wSspRpt_PrintOrder_Result != null && wSspRpt_PrintOrder_Result.ordVerificationWorkFlowId.HasValue)
							{
								parameters.NotUsed_ListPrintOrderDoc = Enumerable.ToList<WSspRpt_PrintOrderDoc_Result>((IEnumerable<WSspRpt_PrintOrderDoc_Result>)_db.WSspRpt_PrintOrderDoc(wSspRpt_PrintOrder_Result.OrderID, currLangId, defLangId));
								if (parameters.NotUsed_ListPrintOrderDoc != null && Enumerable.Any<WSspRpt_PrintOrderDoc_Result>((IEnumerable<WSspRpt_PrintOrderDoc_Result>)parameters.NotUsed_ListPrintOrderDoc))
								{
									foreach (WSspRpt_PrintOrderDoc_Result item9 in parameters.NotUsed_ListPrintOrderDoc)
									{
										if (currLangId != 1065 && !string.IsNullOrEmpty(item9.DocDate))
										{
											item9.DocDate = PersianDate.GetShamsi2Miladi(item9.DocDate.Replace("/", "")).Replace("/", "");
										}
									}
								}
							}
							if (parameters.NotUsed_ListPrintOrderDoc == null)
							{
								parameters.NotUsed_ListPrintOrderDoc = new List<WSspRpt_PrintOrderDoc_Result>();
							}
							parameters.NotUsed_ListOrderItemPrdPicture = new List<WSspRpt_PrintOrderItemPrdPicture_Result>();
							if (wSspRpt_PrintOrder_Result != null)
							{
								parameters.NotUsed_ListOrderItemPrdPicture = Enumerable.ToList<WSspRpt_PrintOrderItemPrdPicture_Result>((IEnumerable<WSspRpt_PrintOrderItemPrdPicture_Result>)_db.WSspRpt_PrintOrderItemPrdPicture(wSspRpt_PrintOrder_Result.OrderID, currLangId, defLangId));
							}
							if (parameters.NotUsed_ListOrderItemPrdPicture == null)
							{
								parameters.NotUsed_ListOrderItemPrdPicture = new List<WSspRpt_PrintOrderItemPrdPicture_Result>();
							}
							MobspReturnSumCompanyScores_Result mobspReturnSumCompanyScores_Result = Enumerable.FirstOrDefault<MobspReturnSumCompanyScores_Result>((IEnumerable<MobspReturnSumCompanyScores_Result>)_dbI.MobspReturnSumCompanyScores(num, model.PfCId));
							if (mobspReturnSumCompanyScores_Result != null)
							{
								parameters.SumScores = mobspReturnSumCompanyScores_Result.SumScores;
								parameters.SumUsableScores = mobspReturnSumCompanyScores_Result.SumUsableScores;
							}
							List<ScorespSelectOrderScores_Result> list7 = Enumerable.ToList<ScorespSelectOrderScores_Result>((IEnumerable<ScorespSelectOrderScores_Result>)_dbI.ScorespSelectOrderScores(wSspRpt_PrintOrder_Result.OrderID, currLangId, defLangId, model.PfCId));
							if (list7 != null)
							{
								parameters.NotUsed_ScorespSelectOrderScores = list7;
							}
							string text8 = "";
							if (wSspRpt_PrintOrder_Result != null)
							{
								text8 = wSspRpt_PrintOrder_Result.ordLinkAccData ?? "";
							}
							if (!string.IsNullOrWhiteSpace(text8))
							{
								List<OrdLinkAccDataViewModel> list8 = new JavaScriptSerializer().Deserialize<List<OrdLinkAccDataViewModel>>(text8);
								if (list8 != null && Enumerable.Any<OrdLinkAccDataViewModel>((IEnumerable<OrdLinkAccDataViewModel>)list8))
								{
									foreach (OrdLinkAccDataViewModel vmLkAcc in list8)
									{
										vmLkAcc.OrdId = model.Id;
										CRMspSelectLinkAccSettingDBIsActive_Result cRMspSelectLinkAccSettingDBIsActive_Result2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDBIsActive_Result>((IEnumerable<CRMspSelectLinkAccSettingDBIsActive_Result>)list, (Func<CRMspSelectLinkAccSettingDBIsActive_Result, bool>)((CRMspSelectLinkAccSettingDBIsActive_Result m) => m.LinkAccSettingDBId == vmLkAcc.DBId.GetValueOrDefault()));
										if (cRMspSelectLinkAccSettingDBIsActive_Result2 != null)
										{
											vmLkAcc.DbName = cRMspSelectLinkAccSettingDBIsActive_Result2.LinkAccSettingDbName ?? "";
											vmLkAcc.DbTitle = cRMspSelectLinkAccSettingDBIsActive_Result2.LinkAccSettingDbTitle ?? "";
										}
									}
									parameters.NotUsed_ListLinkAccData.AddRange(list8);
								}
							}
							if (parameters.NotUsed_ListLinkAccData == null)
							{
								parameters.NotUsed_ListLinkAccData = new List<OrdLinkAccDataViewModel>();
							}
							if (parameters.NotUsed_ListPayLinkAccData == null)
							{
								parameters.NotUsed_ListPayLinkAccData = new List<PayLinkAccDataViewModel>();
							}
							if (parameters.NotUsed_ListCmpAllPayRemainLinkAccData == null)
							{
								parameters.NotUsed_ListCmpAllPayRemainLinkAccData = new List<CmpAccountingLinkAccDataViewModel>();
							}
							int? printFormatID = ((wSspRpt_PrintOrder_Result != null && wSspRpt_PrintOrder_Result.ordPrintFormatId.HasValue) ? wSspRpt_PrintOrder_Result.ordPrintFormatId : new int?(0));
							MobspReturnPrintFormatFileNameById_Result mobspReturnPrintFormatFileNameById_Result = Enumerable.FirstOrDefault<MobspReturnPrintFormatFileNameById_Result>((IEnumerable<MobspReturnPrintFormatFileNameById_Result>)_db.MobspReturnPrintFormatFileNameById(printFormatID));
							if (mobspReturnPrintFormatFileNameById_Result != null)
							{
								text5 = mobspReturnPrintFormatFileNameById_Result.FileNameWeb;
							}
							if ((mobspReturnPrintFormatFileNameById_Result?.CId).GetValueOrDefault() != 0 && !string.IsNullOrWhiteSpace(text4))
							{
								if (!text4.EndsWith("\\"))
								{
									text4 += "\\";
								}
								text4 = text4 + mobspReturnPrintFormatFileNameById_Result.CId + "\\";
							}
							if (string.IsNullOrEmpty(text5))
							{
								text5 = "OrderPrint.mrt";
							}
							if (!System.IO.File.Exists(text4 + text5))
							{
								text5 = "OrderPrint.mrt";
							}
							XmlSerializer val = new XmlSerializer(typeof(Mobile.Models.ReportModel.OrderPrintRpt.Parameters));
							StringWriter stringWriter = new StringWriter();
							XmlWriter val2 = XmlWriter.Create((TextWriter)stringWriter);
							val.Serialize(val2, (object)parameters);
							DataSet val3 = new DataSet();
							val3.ReadXmlSchema(text3 + "OrderPrint.xsd");
							XElement val4 = XElement.Parse(stringWriter.ToString());
							val3.ReadXml(((XNode)val4).CreateReader((ReaderOptions)0));
							stiReport.Load(text4 + text5);
							string text9 = "Integrated Security=False;Data Source={DBServer};Initial Catalog={DBName};Password={DBPass};User ID={DBUser}";
							text9 = text9.Replace("{DBServer}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBServer"]));
							text9 = text9.Replace("{DBName}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBName"]));
							text9 = text9.Replace("{DBUser}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBUser"]));
							text9 = text9.Replace("{DBPass}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBPass"]));
							((CollectionBase)stiReport.Dictionary.Databases).Clear();
							stiReport.Dictionary.Databases.Add(new StiSqlDatabase("CRMIdealExtra", text9));
							stiReport.Compile();
							stiReport.RegData(val3);
							stiReport.Render();
							string text10 = HttpContext.Current.Server.MapPath("~/Download") + "\\Reports\\Files\\" + token2.userId;
							if (!System.IO.Directory.Exists(text10))
							{
								System.IO.Directory.CreateDirectory(text10);
								CRM.General.IO.Directory.SetFullControlForEveryOne(text10);
							}
							string path = text10 + "\\Ord-" + text7 + "-" + now.ToString("yyyyMMddHHmmssfff") + ".pdf";
							try
							{
								System.IO.File.Delete(path);
							}
							catch (Exception e2)
							{
								ErrorSignal.FromCurrentContext().Raise(e2);
								text2 = "خطا در یافت";
								text = null;
								serviceResultStatus = ServiceResultStatus.Error;
							}
							StiJpegExportSettings stiJpegExportSettings = new StiJpegExportSettings
							{
								ImageResolution = 300
							};
							int currentPage = Enumerable.Count<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
							string text11 = text10 + "\\ORD-" + text7 + "-" + now.ToString("yyyyMMddHHmmssfff") + ".pdf";
							string text12 = text10 + "\\Ord_Zip_" + text7;
							if (!System.IO.Directory.Exists(text12))
							{
								System.IO.Directory.CreateDirectory(text12);
								CRM.General.IO.Directory.SetFullControlForEveryOne(text12);
							}
							string file = text12 + "\\Ord_001.jpg";
							stiJpegExportSettings.PageRange = new StiPagesRange(currentPage);
							stiReport.ExportDocument(StiExportFormat.ImageJpeg, file, stiJpegExportSettings);
							string[] files = System.IO.Directory.GetFiles(text12);
							if (Enumerable.Any<string>((IEnumerable<string>)files))
							{
								PdfDocument pdfDocument = new PdfDocument();
								for (int i = 0; i < files.Length; i++)
								{
									PdfPage pdfPage = new PdfPage();
									StiPage stiPage = Enumerable.FirstOrDefault<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
									if (stiPage != null)
									{
										if (stiPage.Orientation == StiPageOrientation.Landscape)
										{
											pdfPage.Orientation = PageOrientation.Landscape;
										}
										try
										{
											PaperKind paperSize = stiPage.PaperSize;
											switch (paperSize - 8)
											{
											default:
												if ((int)paperSize != 66)
												{
													break;
												}
												pdfPage.Size = PageSize.A2;
												goto end_IL_1b9f;
											case 0:
												pdfPage.Size = PageSize.A3;
												goto end_IL_1b9f;
											case 1:
												pdfPage.Size = PageSize.A4;
												goto end_IL_1b9f;
											case 3:
												pdfPage.Size = PageSize.A5;
												goto end_IL_1b9f;
											case 4:
												pdfPage.Size = PageSize.B4;
												goto end_IL_1b9f;
											case 5:
												pdfPage.Size = PageSize.B5;
												goto end_IL_1b9f;
											case 2:
												break;
											}
											pdfPage.Size = PageSize.A4;
											end_IL_1b9f:;
										}
										catch (Exception e3)
										{
											ErrorSignal.FromCurrentContext().Raise(e3);
											pdfPage.Size = PageSize.A4;
										}
									}
									pdfDocument.Pages.Add(pdfPage);
									XGraphics xGraphics = XGraphics.FromPdfPage(pdfDocument.Pages[i]);
									XImage xImage = XImage.FromFile(files[i]);
									xGraphics.DrawImage(xImage, 0.0, 0.0);
									xImage.Dispose();
									xGraphics.Dispose();
								}
								pdfDocument.Save(text11);
								pdfDocument.Close();
							}
							try
							{
								DirectoryInfo directoryInfo = new DirectoryInfo(text12);
								FileInfo[] files2 = directoryInfo.GetFiles();
								for (int j = 0; j < files2.Length; j++)
								{
									files2[j].Delete();
								}
								DirectoryInfo[] directories = directoryInfo.GetDirectories();
								for (int j = 0; j < directories.Length; j++)
								{
									directories[j].Delete(recursive: true);
								}
								if (System.IO.Directory.Exists(text12))
								{
									System.IO.Directory.Delete(text12);
								}
							}
							catch (Exception e4)
							{
								ErrorSignal.FromCurrentContext().Raise(e4);
							}
							path = text11;
							string[] array = HttpContext.Current.Request.Url.AbsoluteUri.Split(new string[1] { "/api/" }, StringSplitOptions.None);
							string text13 = "";
							if (array != null)
							{
								string text14 = "/Download/Reports/Files/" + token2.userId + "/Ord-" + text7 + "-" + now.ToString("yyyyMMddHHmmssfff") + ".pdf";
								text13 = ((array[0] != null && array[0] != "") ? (array[0] + text14) : "");
							}
							PrintLog.InsertPrintLog(model.Id, 2, 3);
							text = (System.IO.File.Exists(path) ? text13 : "");
							text2 = Messages.MobMsgSuccessAction;
							serviceResultStatus = ServiceResultStatus.Success;
						}
						else
						{
							text2 = Messages.MobMsgErrorFileNotExist;
							text = null;
							serviceResultStatus = ServiceResultStatus.Error;
						}
					}
					catch (Exception e5)
					{
						text2 = Messages.MobMsgErrorDoneOperation;
						text = null;
						serviceResultStatus = ServiceResultStatus.Error;
						ErrorSignal.FromCurrentContext().Raise(e5);
					}
				}
				else
				{
					text2 = Messages.MobMsgErrorAccessingToken;
					text = null;
					serviceResultStatus = ServiceResultStatus.Error;
				}
			}
			else
			{
				text2 = Messages.MobMsgErrorAccessingToken;
				text = null;
				serviceResultStatus = ServiceResultStatus.Error;
			}
		}
		catch (Exception e6)
		{
			text2 = Messages.MobMsgErrorDoneOperation;
			text = null;
			serviceResultStatus = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e6);
		}
		return new ServiceResult<string>
		{
			Message = text2,
			Data = text,
			Status = serviceResultStatus
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> GetPdfSendLetter(int letterId, int? ln = null, int? pfCId = null)
	{
		//IL_0bfe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c03: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c05: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c08: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c26: Expected I4, but got Unknown
		//IL_0c26: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c2a: Invalid comparison between Unknown and I4
		//IL_089b: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c0: Expected O, but got Unknown
		//IL_08eb: Unknown result type (might be due to invalid IL or missing references)
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		string text = null;
		string text2 = "";
		ServiceResultStatus serviceResultStatus = ServiceResultStatus.Fail;
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
					try
					{
						cRMEntities = new CRMEntities();
						StiReport stiReport = new StiReport();
						if (letterId > 0)
						{
							string text3 = HttpContext.Current.Server.MapPath("~/Areas/Reports/ReportDatasets/");
							string text4 = HttpContext.Current.Server.MapPath("~/Areas/Reports/ReportFiles/");
							string text5 = "";
							Mobile.Models.ReportModel.SendLetterPrintRpt.Parameters parameters = new Mobile.Models.ReportModel.SendLetterPrintRpt.Parameters();
							int userId = token2.userId;
							DateTime now = DateTime.Now;
							string rptDate = now.ToString("yyyy/MM/dd");
							string rptDay = now.ToString("dddd");
							Reports reports = new Reports();
							parameters.SysSetting = reports.GetSysSetting();
							List<SecspRpt_PrintSendLetter_Result> list = Enumerable.ToList<SecspRpt_PrintSendLetter_Result>((IEnumerable<SecspRpt_PrintSendLetter_Result>)cRMEntities.SecspRpt_PrintSendLetter(letterId, languageID: num, defaultLanguageID: result2, userId: userId, rptDate: rptDate, rptDay: rptDay));
							foreach (SecspRpt_PrintSendLetter_Result item in list)
							{
								if (num != 1065)
								{
									if (!string.IsNullOrEmpty(item.LetterDate))
									{
										item.LetterDate = PersianDate.GetShamsi2Miladi(item.LetterDate.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item.LetterLastPrintDate))
									{
										item.LetterLastPrintDate = PersianDate.GetShamsi2Miladi(item.LetterLastPrintDate.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item.RegisterDatePersian))
									{
										item.RegisterDatePersian = PersianDate.GetShamsi2Miladi(item.RegisterDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item.LetterVerifiedRegisterDatePersian))
									{
										item.LetterVerifiedRegisterDatePersian = PersianDate.GetShamsi2Miladi(item.LetterVerifiedRegisterDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item.FirstRegisterDatePersian))
									{
										item.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(item.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
									}
								}
							}
							byte[] coLoGo = SysSeting.Get().CoLoGo;
							if (coLoGo != null && coLoGo.Length != 0)
							{
								parameters.CoLogo = Convert.ToBase64String(coLoGo);
							}
							parameters.ReportDateTime = now;
							parameters.ReporterUserName = UserLogin.CurrentUser.FullName;
							SecspRpt_PrintSendLetter_Result secspRpt_PrintSendLetter_Result = Enumerable.FirstOrDefault<SecspRpt_PrintSendLetter_Result>((IEnumerable<SecspRpt_PrintSendLetter_Result>)list);
							if (secspRpt_PrintSendLetter_Result == null)
							{
								secspRpt_PrintSendLetter_Result = new SecspRpt_PrintSendLetter_Result();
							}
							parameters.PrintSendLetter = secspRpt_PrintSendLetter_Result;
							string text6 = "";
							if (secspRpt_PrintSendLetter_Result != null)
							{
								text6 = secspRpt_PrintSendLetter_Result.LetterNumber.ToString();
							}
							parameters.SignatureFirstUser = null;
							parameters.SignatureLastEditUser = null;
							parameters.SignatureVerifierRequestUser = null;
							parameters.SignatureVerifierUser = null;
							MobspSelectUserSignatureByUserId_Result mobspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<MobspSelectUserSignatureByUserId_Result>((IEnumerable<MobspSelectUserSignatureByUserId_Result>)cRMEntities.MobspSelectUserSignatureByUserId(secspRpt_PrintSendLetter_Result.FirstRegisterUserId));
							if (mobspSelectUserSignatureByUserId_Result != null && mobspSelectUserSignatureByUserId_Result.Signature != null && mobspSelectUserSignatureByUserId_Result.Signature.Length != 0)
							{
								parameters.SignatureFirstUser = mobspSelectUserSignatureByUserId_Result.Signature;
							}
							mobspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<MobspSelectUserSignatureByUserId_Result>((IEnumerable<MobspSelectUserSignatureByUserId_Result>)cRMEntities.MobspSelectUserSignatureByUserId(secspRpt_PrintSendLetter_Result.UserId));
							if (mobspSelectUserSignatureByUserId_Result != null && mobspSelectUserSignatureByUserId_Result.Signature != null && mobspSelectUserSignatureByUserId_Result.Signature.Length != 0)
							{
								parameters.SignatureLastEditUser = mobspSelectUserSignatureByUserId_Result.Signature;
							}
							mobspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<MobspSelectUserSignatureByUserId_Result>((IEnumerable<MobspSelectUserSignatureByUserId_Result>)cRMEntities.MobspSelectUserSignatureByUserId(secspRpt_PrintSendLetter_Result.LetterVerifierRequestId));
							if (mobspSelectUserSignatureByUserId_Result != null && mobspSelectUserSignatureByUserId_Result.Signature != null && mobspSelectUserSignatureByUserId_Result.Signature.Length != 0)
							{
								parameters.SignatureVerifierRequestUser = mobspSelectUserSignatureByUserId_Result.Signature;
							}
							mobspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<MobspSelectUserSignatureByUserId_Result>((IEnumerable<MobspSelectUserSignatureByUserId_Result>)cRMEntities.MobspSelectUserSignatureByUserId(secspRpt_PrintSendLetter_Result.LetterVerifierId));
							if (mobspSelectUserSignatureByUserId_Result != null && mobspSelectUserSignatureByUserId_Result.Signature != null && mobspSelectUserSignatureByUserId_Result.Signature.Length != 0)
							{
								parameters.SignatureVerifierUser = mobspSelectUserSignatureByUserId_Result.Signature;
							}
							parameters.ListDyPrintCmpForm = new List<CRMspDyPrintCmpForm_Result>();
							parameters.ListDyPrintPrsForm = new List<CRMspDyPrintPrsForm_Result>();
							parameters.ListDyPrintPrjForm = new List<CRMspDyPrintPrjForm_Result>();
							parameters.ListDyPrintLetterForm = new List<CRMspDyPrintSecLetterForm_Result>();
							parameters.ListPrintProjectInformationTree = new List<CRMspPrintProjectInformationTree_Result>();
							if (secspRpt_PrintSendLetter_Result != null)
							{
								if (secspRpt_PrintSendLetter_Result.LetterCompanyId.HasValue)
								{
									parameters.ListDyPrintCmpForm = Enumerable.ToList<CRMspDyPrintCmpForm_Result>((IEnumerable<CRMspDyPrintCmpForm_Result>)cRMEntities.CRMspDyPrintCmpForm(secspRpt_PrintSendLetter_Result.LetterCompanyId, num, result2, token2.userId, 0));
								}
								if (secspRpt_PrintSendLetter_Result.LettercmpPersonId.HasValue)
								{
									parameters.ListDyPrintPrsForm = Enumerable.ToList<CRMspDyPrintPrsForm_Result>((IEnumerable<CRMspDyPrintPrsForm_Result>)cRMEntities.CRMspDyPrintPrsForm(secspRpt_PrintSendLetter_Result.LettercmpPersonId, num, result2, token2.userId, 0));
								}
								if (secspRpt_PrintSendLetter_Result.LettercmpProjectId.HasValue)
								{
									parameters.ListDyPrintPrjForm = Enumerable.ToList<CRMspDyPrintPrjForm_Result>((IEnumerable<CRMspDyPrintPrjForm_Result>)cRMEntities.CRMspDyPrintPrjForm(secspRpt_PrintSendLetter_Result.LettercmpProjectId, num, result2, token2.userId, 0));
									parameters.ListPrintProjectInformationTree = Enumerable.ToList<CRMspPrintProjectInformationTree_Result>((IEnumerable<CRMspPrintProjectInformationTree_Result>)cRMEntities.CRMspPrintProjectInformationTree(secspRpt_PrintSendLetter_Result.LettercmpProjectId, num, result2));
								}
								parameters.ListDyPrintLetterForm = Enumerable.ToList<CRMspDyPrintSecLetterForm_Result>((IEnumerable<CRMspDyPrintSecLetterForm_Result>)cRMEntities.CRMspDyPrintSecLetterForm(secspRpt_PrintSendLetter_Result.LetterId, num, result2, token2.userId, 0));
							}
							parameters.NotUsed_ListPrintLetterVerificationRequestDetails = new List<WSspRpt_PrintVerificationRequestDetails_Result>();
							if (secspRpt_PrintSendLetter_Result != null && secspRpt_PrintSendLetter_Result.LetterVerificationWorkFlowId.HasValue)
							{
								parameters.NotUsed_ListPrintLetterVerificationRequestDetails = Enumerable.ToList<WSspRpt_PrintVerificationRequestDetails_Result>((IEnumerable<WSspRpt_PrintVerificationRequestDetails_Result>)cRMEntities.WSspRpt_PrintVerificationRequestDetails(secspRpt_PrintSendLetter_Result.LetterId, 110, secspRpt_PrintSendLetter_Result.LetterVerificationWorkFlowId, num, result2));
								if (parameters.NotUsed_ListPrintLetterVerificationRequestDetails != null && Enumerable.Any<WSspRpt_PrintVerificationRequestDetails_Result>((IEnumerable<WSspRpt_PrintVerificationRequestDetails_Result>)parameters.NotUsed_ListPrintLetterVerificationRequestDetails))
								{
									foreach (WSspRpt_PrintVerificationRequestDetails_Result notUsed_ListPrintLetterVerificationRequestDetail in parameters.NotUsed_ListPrintLetterVerificationRequestDetails)
									{
										if (num != 1065)
										{
											if (!string.IsNullOrEmpty(notUsed_ListPrintLetterVerificationRequestDetail.VerifyDatePersian))
											{
												notUsed_ListPrintLetterVerificationRequestDetail.VerifyDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintLetterVerificationRequestDetail.VerifyDatePersian.Replace("/", "")).Replace("/", "");
											}
											if (!string.IsNullOrEmpty(notUsed_ListPrintLetterVerificationRequestDetail.FirstRegisterDatePersian))
											{
												notUsed_ListPrintLetterVerificationRequestDetail.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintLetterVerificationRequestDetail.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
											}
											if (!string.IsNullOrEmpty(notUsed_ListPrintLetterVerificationRequestDetail.RegisterDatePersian))
											{
												notUsed_ListPrintLetterVerificationRequestDetail.RegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintLetterVerificationRequestDetail.RegisterDatePersian.Replace("/", "")).Replace("/", "");
											}
											if (!string.IsNullOrEmpty(notUsed_ListPrintLetterVerificationRequestDetail.VerificationReqDatePersian))
											{
												notUsed_ListPrintLetterVerificationRequestDetail.VerificationReqDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintLetterVerificationRequestDetail.VerificationReqDatePersian.Replace("/", "")).Replace("/", "");
											}
											if (!string.IsNullOrEmpty(notUsed_ListPrintLetterVerificationRequestDetail.VerificationReqExpiredDatePersian))
											{
												notUsed_ListPrintLetterVerificationRequestDetail.VerificationReqExpiredDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintLetterVerificationRequestDetail.VerificationReqExpiredDatePersian.Replace("/", "")).Replace("/", "");
											}
										}
										if (notUsed_ListPrintLetterVerificationRequestDetail.VerifyUserSignature != null)
										{
											notUsed_ListPrintLetterVerificationRequestDetail.VerifyUserSignatureStr = Convert.ToBase64String(notUsed_ListPrintLetterVerificationRequestDetail.VerifyUserSignature);
										}
									}
								}
							}
							if (parameters.NotUsed_ListPrintLetterVerificationRequestDetails == null)
							{
								parameters.NotUsed_ListPrintLetterVerificationRequestDetails = new List<WSspRpt_PrintVerificationRequestDetails_Result>();
							}
							int? printFormatID = ((secspRpt_PrintSendLetter_Result != null && secspRpt_PrintSendLetter_Result.LetterPrintFormatId.HasValue) ? secspRpt_PrintSendLetter_Result.LetterPrintFormatId : new int?(0));
							MobspReturnPrintFormatFileNameById_Result mobspReturnPrintFormatFileNameById_Result = Enumerable.FirstOrDefault<MobspReturnPrintFormatFileNameById_Result>((IEnumerable<MobspReturnPrintFormatFileNameById_Result>)cRMEntities.MobspReturnPrintFormatFileNameById(printFormatID));
							if (mobspReturnPrintFormatFileNameById_Result != null)
							{
								text5 = mobspReturnPrintFormatFileNameById_Result.FileNameWeb;
							}
							if (string.IsNullOrEmpty(text5))
							{
								text5 = "SendLetterPrint.mrt";
							}
							if (!System.IO.File.Exists(text4 + text5))
							{
								text5 = "SendLetterPrint.mrt";
							}
							XmlSerializer val = new XmlSerializer(typeof(Mobile.Models.ReportModel.SendLetterPrintRpt.Parameters));
							StringWriter stringWriter = new StringWriter();
							XmlWriter val2 = XmlWriter.Create((TextWriter)stringWriter);
							val.Serialize(val2, (object)parameters);
							DataSet val3 = new DataSet();
							val3.ReadXmlSchema(text3 + "SendLetterPrint.xsd");
							XElement val4 = XElement.Parse(stringWriter.ToString());
							val3.ReadXml(((XNode)val4).CreateReader((ReaderOptions)0));
							if ((mobspReturnPrintFormatFileNameById_Result?.CId).GetValueOrDefault() != 0 && !string.IsNullOrWhiteSpace(text4))
							{
								if (!text4.EndsWith("\\"))
								{
									text4 += "\\";
								}
								text4 = text4 + mobspReturnPrintFormatFileNameById_Result.CId + "\\";
							}
							stiReport.Load(text4 + text5);
							string text7 = "Integrated Security=False;Data Source={DBServer};Initial Catalog={DBName};Password={DBPass};User ID={DBUser}";
							text7 = text7.Replace("{DBServer}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBServer"]));
							text7 = text7.Replace("{DBName}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBName"]));
							text7 = text7.Replace("{DBUser}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBUser"]));
							text7 = text7.Replace("{DBPass}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBPass"]));
							((CollectionBase)stiReport.Dictionary.Databases).Clear();
							stiReport.Dictionary.Databases.Add(new StiSqlDatabase("CRMIdealExtra", text7));
							stiReport.Compile();
							stiReport.RegData(val3);
							stiReport.Render();
							string text8 = HttpContext.Current.Server.MapPath("~/Download") + "\\Reports\\Files\\" + token2.userId;
							if (!System.IO.Directory.Exists(text8))
							{
								System.IO.Directory.CreateDirectory(text8);
								CRM.General.IO.Directory.SetFullControlForEveryOne(text8);
							}
							string path = text8 + "\\Lett-" + text6 + "-" + now.ToString("yyyyMMddHHmmssfff") + ".pdf";
							try
							{
								System.IO.File.Delete(path);
							}
							catch (Exception e)
							{
								ErrorSignal.FromCurrentContext().Raise(e);
								text2 = "خطا در یافت";
								text = null;
								serviceResultStatus = ServiceResultStatus.Error;
							}
							StiJpegExportSettings stiJpegExportSettings = new StiJpegExportSettings
							{
								ImageResolution = 300
							};
							int currentPage = Enumerable.Count<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
							string text9 = text8 + "\\Lett-" + text6 + "-" + now.ToString("yyyyMMddHHmmssfff") + ".pdf";
							string text10 = text8 + "\\Lett_Zip_" + text6;
							if (!System.IO.Directory.Exists(text10))
							{
								System.IO.Directory.CreateDirectory(text10);
								CRM.General.IO.Directory.SetFullControlForEveryOne(text10);
							}
							string file = text10 + "\\Lett_001.jpg";
							stiJpegExportSettings.PageRange = new StiPagesRange(currentPage);
							stiReport.ExportDocument(StiExportFormat.ImageJpeg, file, stiJpegExportSettings);
							string[] files = System.IO.Directory.GetFiles(text10);
							if (Enumerable.Any<string>((IEnumerable<string>)files))
							{
								PdfDocument pdfDocument = new PdfDocument();
								for (int i = 0; i < files.Length; i++)
								{
									PdfPage pdfPage = new PdfPage();
									StiPage stiPage = Enumerable.FirstOrDefault<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
									if (stiPage != null)
									{
										if (stiPage.Orientation == StiPageOrientation.Landscape)
										{
											pdfPage.Orientation = PageOrientation.Landscape;
										}
										try
										{
											PaperKind paperSize = stiPage.PaperSize;
											switch (paperSize - 8)
											{
											default:
												if ((int)paperSize != 66)
												{
													break;
												}
												pdfPage.Size = PageSize.A2;
												goto end_IL_0bfc;
											case 0:
												pdfPage.Size = PageSize.A3;
												goto end_IL_0bfc;
											case 1:
												pdfPage.Size = PageSize.A4;
												goto end_IL_0bfc;
											case 3:
												pdfPage.Size = PageSize.A5;
												goto end_IL_0bfc;
											case 4:
												pdfPage.Size = PageSize.B4;
												goto end_IL_0bfc;
											case 5:
												pdfPage.Size = PageSize.B5;
												goto end_IL_0bfc;
											case 2:
												break;
											}
											pdfPage.Size = PageSize.A4;
											end_IL_0bfc:;
										}
										catch (Exception e2)
										{
											ErrorSignal.FromCurrentContext().Raise(e2);
											pdfPage.Size = PageSize.A4;
										}
									}
									pdfDocument.Pages.Add(pdfPage);
									XGraphics xGraphics = XGraphics.FromPdfPage(pdfDocument.Pages[i]);
									XImage xImage = XImage.FromFile(files[i]);
									xGraphics.DrawImage(xImage, 0.0, 0.0);
									xImage.Dispose();
									xGraphics.Dispose();
								}
								pdfDocument.Save(text9);
								pdfDocument.Close();
							}
							try
							{
								DirectoryInfo directoryInfo = new DirectoryInfo(text10);
								FileInfo[] files2 = directoryInfo.GetFiles();
								for (int j = 0; j < files2.Length; j++)
								{
									files2[j].Delete();
								}
								DirectoryInfo[] directories = directoryInfo.GetDirectories();
								for (int j = 0; j < directories.Length; j++)
								{
									directories[j].Delete(recursive: true);
								}
								if (System.IO.Directory.Exists(text10))
								{
									System.IO.Directory.Delete(text10);
								}
							}
							catch (Exception e3)
							{
								ErrorSignal.FromCurrentContext().Raise(e3);
							}
							path = text9;
							string[] array = HttpContext.Current.Request.Url.AbsoluteUri.Split(new string[1] { "/api/" }, StringSplitOptions.None);
							string text11 = "";
							if (array != null)
							{
								string text12 = "/Download/Reports/Files/" + token2.userId + "/Lett-" + text6 + "-" + now.ToString("yyyyMMddHHmmssfff") + ".pdf";
								text11 = ((array[0] != null && array[0] != "") ? (array[0] + text12) : "");
							}
							PrintLog.InsertPrintLog(letterId, 6, 3);
							text = (System.IO.File.Exists(path) ? text11 : "");
							text2 = Messages.MobMsgSuccessAction;
							serviceResultStatus = ServiceResultStatus.Success;
						}
						else
						{
							text2 = Messages.MobMsgErrorFileNotExist;
							text = null;
							serviceResultStatus = ServiceResultStatus.Error;
						}
					}
					catch (Exception e4)
					{
						text2 = Messages.MobMsgErrorDoneOperation;
						text = null;
						serviceResultStatus = ServiceResultStatus.Error;
						ErrorSignal.FromCurrentContext().Raise(e4);
					}
				}
				else
				{
					text2 = Messages.MobMsgErrorAccessingToken;
					text = null;
					serviceResultStatus = ServiceResultStatus.Error;
				}
			}
			else
			{
				text2 = Messages.MobMsgErrorAccessingToken;
				text = null;
				serviceResultStatus = ServiceResultStatus.Error;
			}
		}
		catch (Exception e5)
		{
			text2 = Messages.MobMsgErrorDoneOperation;
			text = null;
			serviceResultStatus = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e5);
		}
		return new ServiceResult<string>
		{
			Message = text2,
			Data = text,
			Status = serviceResultStatus
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> GetPdfDyForm(int masterValueId, int formId = 0, int masterValueDetailId = 0, int? ln = null, int? pfCId = null, string FileName = null)
	{
		//IL_28ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_28f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_28f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_28f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_2915: Expected I4, but got Unknown
		//IL_2915: Unknown result type (might be due to invalid IL or missing references)
		//IL_2919: Invalid comparison between Unknown and I4
		//IL_0ae1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae8: Expected O, but got Unknown
		//IL_25c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_25e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_25ee: Expected O, but got Unknown
		//IL_2619: Unknown result type (might be due to invalid IL or missing references)
		//IL_2623: Unknown result type (might be due to invalid IL or missing references)
		//IL_262a: Expected O, but got Unknown
		//IL_262e: Unknown result type (might be due to invalid IL or missing references)
		//IL_213f: Unknown result type (might be due to invalid IL or missing references)
		//IL_23a6: Unknown result type (might be due to invalid IL or missing references)
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangId);
		CRMEntities db = null;
		CRMSpEntities cRMSpEntities = null;
		string text = null;
		string text2 = "";
		ServiceResultStatus serviceResultStatus = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int currLangId = ((result > 0) ? result : defLangId);
		baseInfo.SetCulture(currLangId);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					db = new CRMEntities();
					cRMSpEntities = new CRMSpEntities();
					StiReport stiReport = new StiReport();
					if (masterValueId > 0)
					{
						string text3 = HttpContext.Current.Server.MapPath("~/Areas/Reports/ReportDatasets/");
						string text4 = HttpContext.Current.Server.MapPath("~/Areas/Reports/ReportFiles/");
						string text5 = "";
						Mobile.Models.ReportModel.PrintDyFormRpt.Parameters parameters = new Mobile.Models.ReportModel.PrintDyFormRpt.Parameters();
						int userId = token2.userId;
						DateTime now = DateTime.Now;
						string rptDate = now.ToString("yyyy/MM/dd");
						string rptDay = now.ToString("dddd");
						Reports reports = new Reports();
						parameters.SysSetting = reports.GetSysSetting();
						parameters.NotUsed_ListLinkAccData = new List<PordLinkAccDataViewModel>();
						parameters.NotUsed_ListPayLinkAccData = new List<PayLinkAccDataViewModel>();
						MobspSelectCrmsysSetting_Result mobspSelectCrmsysSetting_Result = SysSeting.Get();
						int result2 = 0;
						if (mobspSelectCrmsysSetting_Result != null)
						{
							int.TryParse(mobspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result2);
						}
						List<CRMspSelectLinkAccSettingDBIsActive_Result> list = new List<CRMspSelectLinkAccSettingDBIsActive_Result>();
						if (result2 == 1)
						{
							list = OtherSystems.GetLinkAccSettingDBList(1);
						}
						List<CRMspDyPrintForm_Result> list2 = Enumerable.ToList<CRMspDyPrintForm_Result>((IEnumerable<CRMspDyPrintForm_Result>)db.CRMspDyPrintForm(masterValueId, UserLogin.CurrentUser.UserId, rptDate, rptDay, currLangId, defLangId));
						foreach (CRMspDyPrintForm_Result item in list2)
						{
							if (currLangId != 1065)
							{
								if (!string.IsNullOrEmpty(item.FirstRegisterDatePersian))
								{
									item.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(item.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(item.RegisterDatePersian))
								{
									item.RegisterDatePersian = PersianDate.GetShamsi2Miladi(item.RegisterDatePersian.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(item.CheckedDatePersian))
								{
									item.CheckedDatePersian = PersianDate.GetShamsi2Miladi(item.CheckedDatePersian.Replace("/", "")).Replace("/", "");
								}
							}
						}
						byte[] coLoGo = SysSeting.Get().CoLoGo;
						if (coLoGo != null && coLoGo.Length != 0)
						{
							parameters.CoLogo = Convert.ToBase64String(coLoGo);
						}
						parameters.ReportDateTime = now;
						parameters.ReporterUserName = UserLogin.CurrentUser.FullName;
						CRMspDyPrintForm_Result cRMspDyPrintForm_Result = Enumerable.FirstOrDefault<CRMspDyPrintForm_Result>((IEnumerable<CRMspDyPrintForm_Result>)list2);
						if (cRMspDyPrintForm_Result == null)
						{
							cRMspDyPrintForm_Result = new CRMspDyPrintForm_Result();
						}
						parameters.NotUsed_ListPrintDyForm = new List<CRMspDyPrintFormViewModel>();
						foreach (CRMspDyPrintFormViewModel item2 in Enumerable.Select<CRMspDyPrintForm_Result, CRMspDyPrintFormViewModel>((IEnumerable<CRMspDyPrintForm_Result>)list2, (Func<CRMspDyPrintForm_Result, CRMspDyPrintFormViewModel>)((CRMspDyPrintForm_Result itm) => new CRMspDyPrintFormViewModel
						{
							FormFieldMasterValueId = itm.FormFieldMasterValueId,
							StrFormFieldMasterValueId = itm.FormFieldMasterValueId.ToString(),
							FormId = itm.FormId,
							FormName = itm.FormName,
							FormTitle = itm.FormTitle,
							CrmSysPartId = itm.CrmSysPartId,
							FOSysPartId = itm.FOSysPartId,
							CrmSysPartTitle = itm.CrmSysPartTitle,
							CrmSysPart = itm.CrmSysPart,
							CrmSysPartType = itm.CrmSysPartType,
							FOSysPartTitle = itm.FOSysPartTitle,
							FOSysPart = itm.FOSysPart,
							FOSysPartType = itm.FOSysPartType,
							CompanyId = itm.CompanyId,
							StrCompanyId = (itm.CompanyId.HasValue ? itm.CompanyId.ToString() : ""),
							CompanyNumber = itm.CompanyNumber,
							CompanyName = itm.CompanyName,
							CompanyTel = itm.CompanyTel,
							CompanyTelII = itm.CompanyTelII,
							CompanyFax = itm.CompanyFax,
							CompanyCountry = itm.CompanyCountry,
							CompanyProvince = itm.CompanyProvince,
							CompanyCity = itm.CompanyCity,
							CompanyAddress = itm.CompanyAddress,
							CompanyZipCode = itm.CompanyZipCode,
							CompanyPostBox = itm.CompanyPostBox,
							CompanyRegistrationNumber = itm.CompanyRegistrationNumber,
							CompanyEconomicCode = itm.CompanyEconomicCode,
							CompanyNationalCode = itm.CompanyNationalCode,
							CompanyCode = itm.CompanyCode,
							CompanyPersonId = itm.CompanyPersonId,
							StrCompanyPersonId = (itm.CompanyPersonId.HasValue ? itm.CompanyPersonId.ToString() : ""),
							PersonName = itm.PersonName,
							PersonMobile = itm.PersonMobile,
							PersonEmail = itm.PersonEmail,
							PersonEmailII = itm.PersonEmailII,
							ProjectId = itm.ProjectId,
							StrProjectId = (itm.ProjectId.HasValue ? itm.ProjectId.ToString() : ""),
							ProjectTitle = itm.ProjectTitle,
							ConversationId = itm.ConversationId,
							StrConversationId = (itm.ConversationId.HasValue ? itm.ConversationId.ToString() : ""),
							MasterObjectId = itm.MasterObjectId,
							StrMasterObjectId = (itm.MasterObjectId.HasValue ? itm.MasterObjectId.ToString() : ""),
							DetailObjectId = itm.DetailObjectId,
							StrDetailObjectId = (itm.DetailObjectId.HasValue ? itm.DetailObjectId.ToString() : ""),
							SubDetailObjectId = itm.SubDetailObjectId,
							StrSubDetailObjectId = (itm.SubDetailObjectId.HasValue ? itm.SubDetailObjectId.ToString() : ""),
							IsDeleted = itm.IsDeleted,
							FirstRegisterUserId = itm.FirstRegisterUserId,
							FirstRegisterUser = itm.FirstRegisterUser,
							FirstRegisterDate = itm.FirstRegisterDate,
							FirstRegisterDatePersian = itm.FirstRegisterDatePersian,
							UserId = itm.UserId,
							RegisterUser = itm.RegisterUser,
							RegisterDate = itm.RegisterDate,
							RegisterDatePersian = itm.RegisterDatePersian,
							Year1 = itm.Year1,
							Month1 = itm.Month1,
							GUId = itm.GUId,
							AppType = itm.AppType,
							LanguageID = itm.LanguageID,
							IsChecked = itm.IsChecked,
							CheckerUserId = itm.CheckerUserId,
							CheckerUser = itm.CheckerUser,
							CheckedDate = itm.CheckedDate,
							CheckedDatePersian = itm.CheckedDatePersian,
							rptUserName = itm.rptUserName,
							rptUserId = itm.rptUserId,
							rptDate = itm.rptDate,
							rptDay = itm.rptDay,
							FieldValue = itm.FieldValue,
							WorkflowId = itm.WorkflowId,
							WorkflowStepId = itm.WorkflowStepId,
							Workflow = itm.Workflow,
							WorkflowStep = itm.WorkflowStep,
							CompanyMobile = itm.CompanyMobile,
							CompanyEmail = itm.CompanyEmail,
							CompanyNameOfficial = itm.CompanyNameOfficial,
							CompanyMainPerson = itm.CompanyMainPerson,
							CompanyMainPersonMobile = itm.CompanyMainPersonMobile,
							CompanyMainPersonEmail = itm.CompanyMainPersonEmail,
							CompanyMainPersonEmailII = itm.CompanyMainPersonEmailII,
							CompanyMainPersonTel = itm.CompanyMainPersonTel,
							CompanyMainPersonTelII = itm.CompanyMainPersonTelII,
							CompanyMainPersonFax = itm.CompanyMainPersonFax,
							CompanyMainPersonNationalCode = itm.CompanyMainPersonNationalCode,
							PersonTel = itm.PersonTel,
							PersonTelII = itm.PersonTelII,
							PersonFax = itm.PersonFax,
							PersonNationalCode = itm.PersonNationalCode,
							ProjectInquiryNum = itm.ProjectInquiryNum,
							ProjectNumRef = itm.ProjectNumRef,
							ProjectNumR = itm.ProjectNumR,
							ProjectGroup = itm.ProjectGroup,
							ProjectCnvsStatusGroup = itm.ProjectCnvsStatusGroup,
							DyFormNumber = itm.DyFormNumber,
							VerificationWorkFlowId = itm.VerificationWorkFlowId,
							VerificationWorkFlow = itm.VerificationWorkFlow
						})))
						{
							parameters.NotUsed_ListPrintDyForm.Add(item2);
						}
						List<FieldValueItemViewModel> list3 = new List<FieldValueItemViewModel>();
						foreach (CRMspDyPrintFormViewModel item3 in parameters.NotUsed_ListPrintDyForm)
						{
							if (string.IsNullOrEmpty(item3.FieldValue))
							{
								continue;
							}
							string[] array = item3.FieldValue.Split(new string[1] { "|^,^|" }, StringSplitOptions.None);
							if (array == null)
							{
								continue;
							}
							int num = array.Length;
							for (int i = 0; i < num; i++)
							{
								if (array[i] == null || !(array[i] != ""))
								{
									continue;
								}
								string[] array2 = array[i].Split(new string[1] { "|^:^|" }, StringSplitOptions.None);
								if (array2 == null || !Enumerable.Any<string>((IEnumerable<string>)array2) || Enumerable.Count<string>((IEnumerable<string>)array2) <= 3)
								{
									continue;
								}
								FieldValueItemViewModel fieldValueItemViewModel = new FieldValueItemViewModel
								{
									FormId = item3.FormId,
									CompanyId = item3.CompanyId,
									CompanyPersonId = item3.CompanyPersonId,
									ProjectId = item3.ProjectId,
									ConversationId = item3.ConversationId,
									MasterObjectId = item3.MasterObjectId,
									DetailObjectId = item3.DetailObjectId,
									SubDetailObjectId = item3.SubDetailObjectId,
									MasterValueId = item3.FormFieldMasterValueId,
									FieldTitle = array2[0],
									Value = array2[1],
									FieldType = ((array2[2] != null) ? array2[2].Trim() : array2[2]),
									FieldRepeatId = ((!string.IsNullOrWhiteSpace(array2[3])) ? long.Parse(array2[3].Trim() ?? "0") : 0)
								};
								if (fieldValueItemViewModel.FieldType == "4" && !string.IsNullOrEmpty(fieldValueItemViewModel.Value))
								{
									fieldValueItemViewModel.Value = fieldValueItemViewModel.Value.Replace("/", "").Replace("-", "").Replace("\\", "")
										.Replace(" ", "")
										.Replace("_", "");
									if (fieldValueItemViewModel.Value != "" && fieldValueItemViewModel.Value != "")
									{
										string formatetdDate = PersianDate.GetFormatetdDate(fieldValueItemViewModel.Value.Replace("/", ""));
										if (currLangId == 1065)
										{
											fieldValueItemViewModel.Value = DateTime.Parse(formatetdDate + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()).ToString("yyyy/MM/dd");
										}
										else if (currLangId == 1025)
										{
											fieldValueItemViewModel.Value = DateTime.Parse(PersianDate.GetShamsi2Miladi(fieldValueItemViewModel.Value.Replace("/", ""))).ToString("yyyy/MM/dd", new CultureInfo("ar-SA"));
										}
										else
										{
											fieldValueItemViewModel.Value = DateTime.Parse(PersianDate.GetShamsi2Miladi(fieldValueItemViewModel.Value.Replace("/", ""))).ToString("yyyy/MM/dd", new CultureInfo("en-US"));
										}
									}
								}
								else if (fieldValueItemViewModel.FieldType == "8")
								{
									if (fieldValueItemViewModel.Value != "" && fieldValueItemViewModel.Value != "")
									{
										fieldValueItemViewModel.Value = fieldValueItemViewModel.Value.Replace("|", ",");
										fieldValueItemViewModel.Value = fieldValueItemViewModel.Value.TrimEnd(new char[1] { ',' });
									}
									fieldValueItemViewModel.Value.TrimEnd(new char[1] { ',' });
								}
								else if (fieldValueItemViewModel.FieldType == "13")
								{
									fieldValueItemViewModel.Value = fieldValueItemViewModel.Value.TrimStart(new char[1] { ' ' }).TrimEnd(new char[1] { ' ' });
									if (!string.IsNullOrWhiteSpace(fieldValueItemViewModel.Value))
									{
										byte[] inArray = BaseInfo.HexToByteArray(fieldValueItemViewModel.Value);
										fieldValueItemViewModel.Value = Convert.ToBase64String(inArray);
									}
								}
								list3.Add(fieldValueItemViewModel);
							}
						}
						parameters.NotUsed_ListFieldValue = list3;
						List<CRMspDyPrintFormDetails_Result> list4 = new List<CRMspDyPrintFormDetails_Result>();
						foreach (CRMspDyPrintForm_Result item4 in list2)
						{
							if (!item4.ConversationId.HasValue && !item4.MasterObjectId.HasValue && !item4.DetailObjectId.HasValue && !item4.SubDetailObjectId.HasValue)
							{
								continue;
							}
							if (item4.CrmSysPartId.HasValue)
							{
								List<CRMspDyPrintFormDetails_Result> list5 = Enumerable.ToList<CRMspDyPrintFormDetails_Result>((IEnumerable<CRMspDyPrintFormDetails_Result>)db.CRMspDyPrintFormDetails(item4.CrmSysPart, item4.ConversationId, item4.MasterObjectId, item4.DetailObjectId, item4.SubDetailObjectId, UserLogin.CurrentUser.UserId, currLangId, defLangId));
								if (list5 != null && Enumerable.Any<CRMspDyPrintFormDetails_Result>((IEnumerable<CRMspDyPrintFormDetails_Result>)list5))
								{
									list4.AddRange(list5);
								}
							}
							if (item4.FOSysPartId.HasValue)
							{
								List<CRMspDyPrintFormDetails_Result> list6 = Enumerable.ToList<CRMspDyPrintFormDetails_Result>((IEnumerable<CRMspDyPrintFormDetails_Result>)db.CRMspDyPrintFormDetails(item4.FOSysPart, item4.ConversationId, item4.MasterObjectId, item4.DetailObjectId, item4.SubDetailObjectId, UserLogin.CurrentUser.UserId, currLangId, defLangId));
								if (list6 != null && Enumerable.Any<CRMspDyPrintFormDetails_Result>((IEnumerable<CRMspDyPrintFormDetails_Result>)list6))
								{
									list4.AddRange(list6);
								}
							}
						}
						foreach (CRMspDyPrintFormDetails_Result item5 in list4)
						{
							if (currLangId != 1065)
							{
								if (!string.IsNullOrEmpty(item5.OprDate))
								{
									item5.OprDate = PersianDate.GetShamsi2Miladi(item5.OprDate.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(item5.OprRemindDate))
								{
									item5.OprRemindDate = PersianDate.GetShamsi2Miladi(item5.OprRemindDate.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(item5.OprRemindDateForAllarm))
								{
									item5.OprRemindDateForAllarm = PersianDate.GetShamsi2Miladi(item5.OprRemindDateForAllarm.Replace("/", "")).Replace("/", "");
								}
							}
						}
						parameters.NotUsed_ListPrintFormDetails = list4;
						MemoryStream memoryStream = new MemoryStream();
						XmlWriterSettings val = new XmlWriterSettings();
						val.OmitXmlDeclaration = true;
						val.Indent = true;
						if (parameters.NotUsed_ListFieldValue != null && Enumerable.Any<FieldValueItemViewModel>((IEnumerable<FieldValueItemViewModel>)parameters.NotUsed_ListFieldValue))
						{
							XmlWriter val2 = XmlWriter.Create((Stream)memoryStream, val);
							try
							{
								val2.WriteStartDocument();
								val2.WriteStartElement("Container");
								foreach (CRMspDyPrintForm_Result itm2 in list2)
								{
									List<FieldValueItemViewModel> list7 = Enumerable.ToList<FieldValueItemViewModel>(Enumerable.Where<FieldValueItemViewModel>((IEnumerable<FieldValueItemViewModel>)list3, (Func<FieldValueItemViewModel, bool>)((FieldValueItemViewModel m) => m.MasterValueId == itm2.FormFieldMasterValueId && m.FieldRepeatId == 0)));
									if (list7 == null || !Enumerable.Any<FieldValueItemViewModel>((IEnumerable<FieldValueItemViewModel>)list7))
									{
										continue;
									}
									FieldValueItemViewModel fieldValueItemViewModel2 = Enumerable.FirstOrDefault<FieldValueItemViewModel>((IEnumerable<FieldValueItemViewModel>)list7);
									if (fieldValueItemViewModel2 == null)
									{
										continue;
									}
									val2.WriteStartElement("Row");
									foreach (FieldValueItemViewModel item6 in list7)
									{
										if (!string.IsNullOrEmpty(item6.FieldTitle))
										{
											string text6 = item6.FieldTitle.Trim();
											text6 = text6.Replace(" ", "_");
											text6 = Common.RemoveSpecialCharactersWithoutDot(text6);
											val2.WriteElementString(text6, item6.Value ?? "");
										}
									}
									val2.WriteElementString("CompanyId", fieldValueItemViewModel2.CompanyId.ToString());
									val2.WriteElementString("CompanyPersonId", fieldValueItemViewModel2.CompanyPersonId.ToString());
									val2.WriteElementString("ProjectId", fieldValueItemViewModel2.ProjectId.ToString());
									val2.WriteElementString("ConversationId", fieldValueItemViewModel2.ConversationId.ToString());
									val2.WriteElementString("MasterObjectId", fieldValueItemViewModel2.MasterObjectId.ToString());
									val2.WriteElementString("DetailObjectId", fieldValueItemViewModel2.DetailObjectId.ToString());
									val2.WriteElementString("SubDetailObjectId", fieldValueItemViewModel2.SubDetailObjectId.ToString());
									val2.WriteElementString("MasterValueId", fieldValueItemViewModel2.MasterValueId.ToString());
									val2.WriteEndElement();
									List<FieldValueItemViewModel> list8 = new List<FieldValueItemViewModel>();
									List<FieldValueItemViewModel> list9 = Enumerable.ToList<FieldValueItemViewModel>(Enumerable.Where<FieldValueItemViewModel>((IEnumerable<FieldValueItemViewModel>)list3, (Func<FieldValueItemViewModel, bool>)((FieldValueItemViewModel m) => m.MasterValueId == itm2.FormFieldMasterValueId && m.FieldRepeatId != 0)));
									if (list9 == null || !Enumerable.Any<FieldValueItemViewModel>((IEnumerable<FieldValueItemViewModel>)list9))
									{
										continue;
									}
									foreach (FieldValueItemViewModel repeateItem in list9)
									{
										FieldValueItemViewModel fieldValueItemViewModel3 = null;
										if (list8 != null && Enumerable.Any<FieldValueItemViewModel>((IEnumerable<FieldValueItemViewModel>)list8))
										{
											fieldValueItemViewModel3 = Enumerable.FirstOrDefault<FieldValueItemViewModel>((IEnumerable<FieldValueItemViewModel>)list8, (Func<FieldValueItemViewModel, bool>)((FieldValueItemViewModel m) => m.MasterValueId == itm2.FormFieldMasterValueId && m.FieldRepeatId == repeateItem.FieldRepeatId));
										}
										if (fieldValueItemViewModel3 != null)
										{
											continue;
										}
										list7 = Enumerable.ToList<FieldValueItemViewModel>(Enumerable.Where<FieldValueItemViewModel>((IEnumerable<FieldValueItemViewModel>)list3, (Func<FieldValueItemViewModel, bool>)((FieldValueItemViewModel m) => m.MasterValueId == itm2.FormFieldMasterValueId && m.FieldRepeatId == repeateItem.FieldRepeatId)));
										val2.WriteStartElement("Row");
										foreach (FieldValueItemViewModel item7 in list7)
										{
											if (!string.IsNullOrEmpty(item7.FieldTitle))
											{
												string text7 = item7.FieldTitle.Trim();
												text7 = text7.Replace(" ", "_");
												text7 = Common.RemoveSpecialCharactersWithoutDot(text7);
												val2.WriteElementString(text7, item7.Value ?? "");
											}
										}
										val2.WriteElementString("CompanyId", fieldValueItemViewModel2.CompanyId.ToString());
										val2.WriteElementString("CompanyPersonId", fieldValueItemViewModel2.CompanyPersonId.ToString());
										val2.WriteElementString("ProjectId", fieldValueItemViewModel2.ProjectId.ToString());
										val2.WriteElementString("ConversationId", fieldValueItemViewModel2.ConversationId.ToString());
										val2.WriteElementString("MasterObjectId", fieldValueItemViewModel2.MasterObjectId.ToString());
										val2.WriteElementString("DetailObjectId", fieldValueItemViewModel2.DetailObjectId.ToString());
										val2.WriteElementString("SubDetailObjectId", fieldValueItemViewModel2.SubDetailObjectId.ToString());
										val2.WriteElementString("MasterValueId", fieldValueItemViewModel2.MasterValueId.ToString());
										val2.WriteEndElement();
										list8.Add(repeateItem);
									}
								}
								val2.WriteEndElement();
								val2.WriteEndDocument();
								val2.Flush();
								val2.Close();
							}
							finally
							{
								((IDisposable)val2)?.Dispose();
							}
							memoryStream.Position = 0L;
						}
						parameters.NotUsed_ListPrintFormFieldValues = new List<CRMspDyPrintFormFieldValues_Result>();
						parameters.NotUsed_ListPrintFormFieldValues = Enumerable.ToList<CRMspDyPrintFormFieldValues_Result>((IEnumerable<CRMspDyPrintFormFieldValues_Result>)db.CRMspDyPrintFormFieldValues(masterValueId, formId, UserLogin.CurrentUser.UserId, rptDate, rptDay, currLangId, defLangId));
						foreach (CRMspDyPrintFormFieldValues_Result notUsed_ListPrintFormFieldValue in parameters.NotUsed_ListPrintFormFieldValues)
						{
							if (currLangId != 1065)
							{
								if (!string.IsNullOrEmpty(notUsed_ListPrintFormFieldValue.FirstRegisterDatePersian))
								{
									notUsed_ListPrintFormFieldValue.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintFormFieldValue.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(notUsed_ListPrintFormFieldValue.RegisterDatePersian))
								{
									notUsed_ListPrintFormFieldValue.RegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintFormFieldValue.RegisterDatePersian.Replace("/", "")).Replace("/", "");
								}
							}
						}
						parameters.NotUsed_ListPrintFormFieldMasterValueDetails = new List<CRMspDyPrintFormFieldMasterValueDetails_Result>();
						parameters.NotUsed_ListPrintFormFieldMasterValueDetails = Enumerable.ToList<CRMspDyPrintFormFieldMasterValueDetails_Result>((IEnumerable<CRMspDyPrintFormFieldMasterValueDetails_Result>)db.CRMspDyPrintFormFieldMasterValueDetails(masterValueId, masterValueDetailId, UserLogin.CurrentUser.UserId, rptDate, rptDay, currLangId, defLangId));
						foreach (CRMspDyPrintFormFieldMasterValueDetails_Result notUsed_ListPrintFormFieldMasterValueDetail in parameters.NotUsed_ListPrintFormFieldMasterValueDetails)
						{
							if (currLangId != 1065)
							{
								if (!string.IsNullOrEmpty(notUsed_ListPrintFormFieldMasterValueDetail.FirstRegisterDatePersian))
								{
									notUsed_ListPrintFormFieldMasterValueDetail.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintFormFieldMasterValueDetail.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(notUsed_ListPrintFormFieldMasterValueDetail.RegisterDatePersian))
								{
									notUsed_ListPrintFormFieldMasterValueDetail.RegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintFormFieldMasterValueDetail.RegisterDatePersian.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(notUsed_ListPrintFormFieldMasterValueDetail.CheckedDatePersian))
								{
									notUsed_ListPrintFormFieldMasterValueDetail.CheckedDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintFormFieldMasterValueDetail.CheckedDatePersian.Replace("/", "")).Replace("/", "");
								}
							}
							if (notUsed_ListPrintFormFieldMasterValueDetail.RegisterUserSignature != null)
							{
								notUsed_ListPrintFormFieldMasterValueDetail.RegisterUserSignatureStr = Convert.ToBase64String(notUsed_ListPrintFormFieldMasterValueDetail.RegisterUserSignature);
							}
							if (notUsed_ListPrintFormFieldMasterValueDetail.FirstRegisterUserSignature != null)
							{
								notUsed_ListPrintFormFieldMasterValueDetail.FirstRegisterUserSignatureStr = Convert.ToBase64String(notUsed_ListPrintFormFieldMasterValueDetail.FirstRegisterUserSignature);
							}
							if (notUsed_ListPrintFormFieldMasterValueDetail.CheckerUserSignature != null)
							{
								notUsed_ListPrintFormFieldMasterValueDetail.CheckerUserSignatureStr = Convert.ToBase64String(notUsed_ListPrintFormFieldMasterValueDetail.CheckerUserSignature);
							}
						}
						parameters.NotUsed_ListPrintDyFormVerificationRequestDetails = new List<WSspRpt_PrintVerificationRequestDetails_Result>();
						if (cRMspDyPrintForm_Result != null && cRMspDyPrintForm_Result.VerificationWorkFlowId.HasValue)
						{
							parameters.NotUsed_ListPrintDyFormVerificationRequestDetails = Enumerable.ToList<WSspRpt_PrintVerificationRequestDetails_Result>((IEnumerable<WSspRpt_PrintVerificationRequestDetails_Result>)db.WSspRpt_PrintVerificationRequestDetails(cRMspDyPrintForm_Result.FormFieldMasterValueId, 80, cRMspDyPrintForm_Result.VerificationWorkFlowId, currLangId, defLangId));
							if (parameters.NotUsed_ListPrintDyFormVerificationRequestDetails != null && Enumerable.Any<WSspRpt_PrintVerificationRequestDetails_Result>((IEnumerable<WSspRpt_PrintVerificationRequestDetails_Result>)parameters.NotUsed_ListPrintDyFormVerificationRequestDetails))
							{
								foreach (WSspRpt_PrintVerificationRequestDetails_Result notUsed_ListPrintDyFormVerificationRequestDetail in parameters.NotUsed_ListPrintDyFormVerificationRequestDetails)
								{
									if (currLangId != 1065)
									{
										if (!string.IsNullOrEmpty(notUsed_ListPrintDyFormVerificationRequestDetail.VerifyDatePersian))
										{
											notUsed_ListPrintDyFormVerificationRequestDetail.VerifyDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintDyFormVerificationRequestDetail.VerifyDatePersian.Replace("/", "")).Replace("/", "");
										}
										if (!string.IsNullOrEmpty(notUsed_ListPrintDyFormVerificationRequestDetail.FirstRegisterDatePersian))
										{
											notUsed_ListPrintDyFormVerificationRequestDetail.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintDyFormVerificationRequestDetail.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
										}
										if (!string.IsNullOrEmpty(notUsed_ListPrintDyFormVerificationRequestDetail.RegisterDatePersian))
										{
											notUsed_ListPrintDyFormVerificationRequestDetail.RegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintDyFormVerificationRequestDetail.RegisterDatePersian.Replace("/", "")).Replace("/", "");
										}
										if (!string.IsNullOrEmpty(notUsed_ListPrintDyFormVerificationRequestDetail.VerificationReqDatePersian))
										{
											notUsed_ListPrintDyFormVerificationRequestDetail.VerificationReqDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintDyFormVerificationRequestDetail.VerificationReqDatePersian.Replace("/", "")).Replace("/", "");
										}
										if (!string.IsNullOrEmpty(notUsed_ListPrintDyFormVerificationRequestDetail.VerificationReqExpiredDatePersian))
										{
											notUsed_ListPrintDyFormVerificationRequestDetail.VerificationReqExpiredDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintDyFormVerificationRequestDetail.VerificationReqExpiredDatePersian.Replace("/", "")).Replace("/", "");
										}
									}
									if (notUsed_ListPrintDyFormVerificationRequestDetail.VerifyUserSignature != null)
									{
										notUsed_ListPrintDyFormVerificationRequestDetail.VerifyUserSignatureStr = Convert.ToBase64String(notUsed_ListPrintDyFormVerificationRequestDetail.VerifyUserSignature);
									}
								}
							}
						}
						if (parameters.NotUsed_ListPrintDyFormVerificationRequestDetails == null)
						{
							parameters.NotUsed_ListPrintDyFormVerificationRequestDetails = new List<WSspRpt_PrintVerificationRequestDetails_Result>();
						}
						parameters.SignatureFirstUser = null;
						parameters.SignatureLastEditUser = null;
						parameters.SignatureChekerUser = null;
						MobspSelectUserSignatureByUserId_Result mobspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<MobspSelectUserSignatureByUserId_Result>((IEnumerable<MobspSelectUserSignatureByUserId_Result>)db.MobspSelectUserSignatureByUserId(cRMspDyPrintForm_Result.FirstRegisterUserId));
						if (mobspSelectUserSignatureByUserId_Result != null && mobspSelectUserSignatureByUserId_Result.Signature != null && mobspSelectUserSignatureByUserId_Result.Signature.Length != 0)
						{
							parameters.SignatureFirstUser = mobspSelectUserSignatureByUserId_Result.Signature;
						}
						mobspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<MobspSelectUserSignatureByUserId_Result>((IEnumerable<MobspSelectUserSignatureByUserId_Result>)db.MobspSelectUserSignatureByUserId(cRMspDyPrintForm_Result.UserId));
						if (mobspSelectUserSignatureByUserId_Result != null && mobspSelectUserSignatureByUserId_Result.Signature != null && mobspSelectUserSignatureByUserId_Result.Signature.Length != 0)
						{
							parameters.SignatureLastEditUser = mobspSelectUserSignatureByUserId_Result.Signature;
						}
						mobspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<MobspSelectUserSignatureByUserId_Result>((IEnumerable<MobspSelectUserSignatureByUserId_Result>)db.MobspSelectUserSignatureByUserId(cRMspDyPrintForm_Result.CheckerUserId));
						if (mobspSelectUserSignatureByUserId_Result != null && mobspSelectUserSignatureByUserId_Result.Signature != null && mobspSelectUserSignatureByUserId_Result.Signature.Length != 0)
						{
							parameters.SignatureChekerUser = mobspSelectUserSignatureByUserId_Result.Signature;
						}
						int result3 = 0;
						int result4 = 0;
						int result5 = 0;
						if (cRMspDyPrintForm_Result != null)
						{
							int.TryParse(cRMspDyPrintForm_Result.MasterObjectId.ToString(), out result3);
							int.TryParse(cRMspDyPrintForm_Result.CrmSysPartId.ToString(), out result4);
							int.TryParse(cRMspDyPrintForm_Result.FOSysPartId.ToString(), out result5);
						}
						parameters.ListPrintPreOrder = new List<WSspRpt_PrintPreOrder_Result>();
						parameters.ListPrintPreOrderItemSpecification = new List<WSspSelectPreOrderItemSpecificationByItemId_Result>();
						parameters.ListPrintPreOrderPayments = new List<WSspRpt_PrintPreOrderPayments_Result>();
						parameters.PreOrderSignatureFirstUser = null;
						parameters.PreOrderSignatureLastEditUser = null;
						parameters.PreOrderSignatureReferUser = null;
						parameters.PreOrderSignatureVerifierUser = null;
						parameters.PrintPreOrder = new WSspRpt_PrintPreOrderById_Result();
						if (result3 != 0 && (result4 == 20 || result4 == 120 || result5 == 20 || result5 == 120))
						{
							parameters.PrintPreOrder = new WSspRpt_PrintPreOrderById_Result();
							parameters.PrintPreOrder = Enumerable.FirstOrDefault<WSspRpt_PrintPreOrderById_Result>((IEnumerable<WSspRpt_PrintPreOrderById_Result>)cRMSpEntities.WSspRpt_PrintPreOrderById(result3, currLangId, defLangId, userId, rptDate, rptDay, default(decimal)));
							if (parameters.PrintPreOrder == null)
							{
								parameters.PrintPreOrder = new WSspRpt_PrintPreOrderById_Result();
							}
							else if (currLangId != 1065)
							{
								if (!string.IsNullOrEmpty(parameters.PrintPreOrder.pordDate))
								{
									parameters.PrintPreOrder.pordDate = PersianDate.GetShamsi2Miladi(parameters.PrintPreOrder.pordDate.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(parameters.PrintPreOrder.prsBirthDate))
								{
									parameters.PrintPreOrder.prsBirthDate = PersianDate.GetShamsi2Miladi(parameters.PrintPreOrder.prsBirthDate.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(parameters.PrintPreOrder.pordDeliveryDate))
								{
									parameters.PrintPreOrder.pordDeliveryDate = PersianDate.GetShamsi2Miladi(parameters.PrintPreOrder.pordDeliveryDate.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(parameters.PrintPreOrder.pordDeliveryEndDate))
								{
									parameters.PrintPreOrder.pordDeliveryEndDate = PersianDate.GetShamsi2Miladi(parameters.PrintPreOrder.pordDeliveryEndDate.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(parameters.PrintPreOrder.RegisterDatePersian))
								{
									parameters.PrintPreOrder.RegisterDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintPreOrder.RegisterDatePersian.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(parameters.PrintPreOrder.pordExpireDate))
								{
									parameters.PrintPreOrder.pordExpireDate = PersianDate.GetShamsi2Miladi(parameters.PrintPreOrder.pordExpireDate.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(parameters.PrintPreOrder.prjStartDate))
								{
									parameters.PrintPreOrder.prjStartDate = PersianDate.GetShamsi2Miladi(parameters.PrintPreOrder.prjStartDate.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(parameters.PrintPreOrder.pordDeadlineDatePersian))
								{
									parameters.PrintPreOrder.pordDeadlineDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintPreOrder.pordDeadlineDatePersian.Replace("/", "")).Replace("/", "");
								}
							}
							List<WSspRpt_PrintPreOrder_Result> list10 = Enumerable.ToList<WSspRpt_PrintPreOrder_Result>((IEnumerable<WSspRpt_PrintPreOrder_Result>)cRMSpEntities.WSspRpt_PrintPreOrder(result3, currLangId, defLangId, userId, rptDate, rptDay, default(decimal)));
							foreach (WSspRpt_PrintPreOrder_Result item8 in list10)
							{
								if (currLangId != 1065)
								{
									if (!string.IsNullOrEmpty(item8.pordDate))
									{
										item8.pordDate = PersianDate.GetShamsi2Miladi(item8.pordDate.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item8.prsBirthDate))
									{
										item8.prsBirthDate = PersianDate.GetShamsi2Miladi(item8.prsBirthDate.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item8.pordDeliveryDate))
									{
										item8.pordDeliveryDate = PersianDate.GetShamsi2Miladi(item8.pordDeliveryDate.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item8.RegisterDatePersian))
									{
										item8.RegisterDatePersian = PersianDate.GetShamsi2Miladi(item8.RegisterDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item8.POIRegisterDatePersian))
									{
										item8.POIRegisterDatePersian = PersianDate.GetShamsi2Miladi(item8.POIRegisterDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item8.LastOrdDate))
									{
										item8.LastOrdDate = PersianDate.GetShamsi2Miladi(item8.LastOrdDate.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item8.pordIDeliveryDatePersian))
									{
										item8.pordIDeliveryDatePersian = PersianDate.GetShamsi2Miladi(item8.pordIDeliveryDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item8.prjStartDate))
									{
										item8.prjStartDate = PersianDate.GetShamsi2Miladi(item8.prjStartDate.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item8.pordDeadlineDatePersian))
									{
										item8.pordDeadlineDatePersian = PersianDate.GetShamsi2Miladi(item8.pordDeadlineDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item8.pordIValidityExpireDatePersian))
									{
										item8.pordIValidityExpireDatePersian = PersianDate.GetShamsi2Miladi(item8.pordIValidityExpireDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item8.pordIDiscountCodeRegisterDatePersian))
									{
										item8.pordIDiscountCodeRegisterDatePersian = PersianDate.GetShamsi2Miladi(item8.pordIDiscountCodeRegisterDatePersian.Replace("/", "")).Replace("/", "");
									}
								}
							}
							WSspRpt_PrintPreOrder_Result wSspRpt_PrintPreOrder_Result = Enumerable.FirstOrDefault<WSspRpt_PrintPreOrder_Result>((IEnumerable<WSspRpt_PrintPreOrder_Result>)list10);
							if (wSspRpt_PrintPreOrder_Result == null)
							{
								wSspRpt_PrintPreOrder_Result = new WSspRpt_PrintPreOrder_Result();
								if (parameters.PrintPreOrder != null)
								{
									wSspRpt_PrintPreOrder_Result.PreOrderID = parameters.PrintPreOrder.PreOrderID;
									wSspRpt_PrintPreOrder_Result.pordCompanyId = parameters.PrintPreOrder.pordCompanyId;
									wSspRpt_PrintPreOrder_Result.pordCompanyPersonId = parameters.PrintPreOrder.pordCompanyPersonId;
									wSspRpt_PrintPreOrder_Result.pordProjectId = parameters.PrintPreOrder.pordProjectId;
									wSspRpt_PrintPreOrder_Result.pordReferUserId = parameters.PrintPreOrder.pordReferUserId;
									wSspRpt_PrintPreOrder_Result.pordFirstRegisterUserId = parameters.PrintPreOrder.pordFirstRegisterUserId;
									wSspRpt_PrintPreOrder_Result.UserId = parameters.PrintPreOrder.UserId;
									wSspRpt_PrintPreOrder_Result.pordVerifierId = parameters.PrintPreOrder.pordVerifierId;
									wSspRpt_PrintPreOrder_Result.pordVerificationWorkFlowId = parameters.PrintPreOrder.pordVerificationWorkFlowId;
								}
							}
							parameters.ListPrintPreOrder = list10;
							List<WSspSelectPreOrderItemSpecificationByItemId_Result> list11 = new List<WSspSelectPreOrderItemSpecificationByItemId_Result>();
							foreach (List<WSspSelectPreOrderItemSpecificationByItemId_Result> item9 in Enumerable.Select<WSspRpt_PrintPreOrder_Result, List<WSspSelectPreOrderItemSpecificationByItemId_Result>>((IEnumerable<WSspRpt_PrintPreOrder_Result>)parameters.ListPrintPreOrder, (Func<WSspRpt_PrintPreOrder_Result, List<WSspSelectPreOrderItemSpecificationByItemId_Result>>)((WSspRpt_PrintPreOrder_Result itemSpe) => Enumerable.ToList<WSspSelectPreOrderItemSpecificationByItemId_Result>((IEnumerable<WSspSelectPreOrderItemSpecificationByItemId_Result>)db.WSspSelectPreOrderItemSpecificationByItemId(itemSpe.PreOrderItemID, currLangId, defLangId)))))
							{
								list11.AddRange(item9);
							}
							foreach (WSspSelectPreOrderItemSpecificationByItemId_Result item10 in list11)
							{
								if (currLangId != 1065)
								{
									if (!string.IsNullOrEmpty(item10.RegisterDatePersian))
									{
										item10.RegisterDatePersian = PersianDate.GetShamsi2Miladi(item10.RegisterDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item10.FirstRegisterDatePersian))
									{
										item10.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(item10.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
									}
								}
							}
							parameters.ListPrintPreOrderItemSpecification = list11;
							List<WSspRpt_PrintPreOrderPayments_Result> list12 = new List<WSspRpt_PrintPreOrderPayments_Result>();
							foreach (List<WSspRpt_PrintPreOrderPayments_Result> item11 in Enumerable.Select<WSspRpt_PrintPreOrder_Result, List<WSspRpt_PrintPreOrderPayments_Result>>((IEnumerable<WSspRpt_PrintPreOrder_Result>)parameters.ListPrintPreOrder, (Func<WSspRpt_PrintPreOrder_Result, List<WSspRpt_PrintPreOrderPayments_Result>>)((WSspRpt_PrintPreOrder_Result itemSpe) => Enumerable.ToList<WSspRpt_PrintPreOrderPayments_Result>((IEnumerable<WSspRpt_PrintPreOrderPayments_Result>)db.WSspRpt_PrintPreOrderPayments(itemSpe.PreOrderID, currLangId, defLangId)))))
							{
								list12.AddRange(item11);
							}
							foreach (WSspRpt_PrintPreOrderPayments_Result item12 in list12)
							{
								if (currLangId != 1065)
								{
									if (!string.IsNullOrEmpty(item12.RegisterDatePersian))
									{
										item12.RegisterDatePersian = PersianDate.GetShamsi2Miladi(item12.RegisterDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item12.ImportDate))
									{
										item12.ImportDate = PersianDate.GetShamsi2Miladi(item12.ImportDate.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item12.pordpayDocDate))
									{
										item12.pordpayDocDate = PersianDate.GetShamsi2Miladi(item12.pordpayDocDate.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item12.pordpayFirstRegisteDatePersian))
									{
										item12.pordpayFirstRegisteDatePersian = PersianDate.GetShamsi2Miladi(item12.pordpayFirstRegisteDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item12.FirstRegisterDatePersian))
									{
										item12.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(item12.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrWhiteSpace(item12.pordpayVerifiedRegisterDatePersian))
									{
										item12.pordpayVerifiedRegisterDatePersian = PersianDate.GetShamsi2Miladi(item12.pordpayVerifiedRegisterDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrWhiteSpace(item12.pordpayDocDateTemp))
									{
										item12.pordpayDocDateTemp = PersianDate.GetShamsi2Miladi(item12.pordpayDocDateTemp.Replace("/", "")).Replace("/", "");
									}
								}
								if (string.IsNullOrWhiteSpace(item12.pordpayLinkAccData))
								{
									continue;
								}
								List<PayLinkAccDataViewModel> list13 = new JavaScriptSerializer().Deserialize<List<PayLinkAccDataViewModel>>(item12.pordpayLinkAccData);
								if (list13 == null || !Enumerable.Any<PayLinkAccDataViewModel>((IEnumerable<PayLinkAccDataViewModel>)list13))
								{
									continue;
								}
								foreach (PayLinkAccDataViewModel vmLkAcc2 in list13)
								{
									vmLkAcc2.PayId = item12.PreOrderPaymentId;
									CRMspSelectLinkAccSettingDBIsActive_Result cRMspSelectLinkAccSettingDBIsActive_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDBIsActive_Result>((IEnumerable<CRMspSelectLinkAccSettingDBIsActive_Result>)list, (Func<CRMspSelectLinkAccSettingDBIsActive_Result, bool>)((CRMspSelectLinkAccSettingDBIsActive_Result m) => m.LinkAccSettingDBId == vmLkAcc2.DBId.GetValueOrDefault()));
									if (cRMspSelectLinkAccSettingDBIsActive_Result != null)
									{
										vmLkAcc2.DbName = cRMspSelectLinkAccSettingDBIsActive_Result.LinkAccSettingDbName ?? "";
										vmLkAcc2.DbTitle = cRMspSelectLinkAccSettingDBIsActive_Result.LinkAccSettingDbTitle ?? "";
									}
								}
								parameters.NotUsed_ListPayLinkAccData.AddRange(list13);
							}
							parameters.ListPrintPreOrderPayments = list12;
							parameters.PreOrderSignatureFirstUser = null;
							parameters.PreOrderSignatureLastEditUser = null;
							parameters.PreOrderSignatureReferUser = null;
							parameters.PreOrderSignatureVerifierUser = null;
							MobspSelectUserSignatureByUserId_Result mobspSelectUserSignatureByUserId_Result2 = Enumerable.FirstOrDefault<MobspSelectUserSignatureByUserId_Result>((IEnumerable<MobspSelectUserSignatureByUserId_Result>)db.MobspSelectUserSignatureByUserId(wSspRpt_PrintPreOrder_Result.pordFirstRegisterUserId));
							if (mobspSelectUserSignatureByUserId_Result2 != null && mobspSelectUserSignatureByUserId_Result2.Signature != null && mobspSelectUserSignatureByUserId_Result2.Signature.Length != 0)
							{
								parameters.PreOrderSignatureFirstUser = mobspSelectUserSignatureByUserId_Result2.Signature;
							}
							mobspSelectUserSignatureByUserId_Result2 = Enumerable.FirstOrDefault<MobspSelectUserSignatureByUserId_Result>((IEnumerable<MobspSelectUserSignatureByUserId_Result>)db.MobspSelectUserSignatureByUserId(wSspRpt_PrintPreOrder_Result.UserId));
							if (mobspSelectUserSignatureByUserId_Result2 != null && mobspSelectUserSignatureByUserId_Result2.Signature != null && mobspSelectUserSignatureByUserId_Result2.Signature.Length != 0)
							{
								parameters.PreOrderSignatureLastEditUser = mobspSelectUserSignatureByUserId_Result2.Signature;
							}
							mobspSelectUserSignatureByUserId_Result2 = Enumerable.FirstOrDefault<MobspSelectUserSignatureByUserId_Result>((IEnumerable<MobspSelectUserSignatureByUserId_Result>)db.MobspSelectUserSignatureByUserId(wSspRpt_PrintPreOrder_Result.pordReferUserId));
							if (mobspSelectUserSignatureByUserId_Result2 != null && mobspSelectUserSignatureByUserId_Result2.Signature != null && mobspSelectUserSignatureByUserId_Result2.Signature.Length != 0)
							{
								parameters.PreOrderSignatureReferUser = mobspSelectUserSignatureByUserId_Result2.Signature;
							}
							mobspSelectUserSignatureByUserId_Result2 = Enumerable.FirstOrDefault<MobspSelectUserSignatureByUserId_Result>((IEnumerable<MobspSelectUserSignatureByUserId_Result>)db.MobspSelectUserSignatureByUserId(wSspRpt_PrintPreOrder_Result.pordVerifierId));
							if (mobspSelectUserSignatureByUserId_Result2 != null && mobspSelectUserSignatureByUserId_Result2.Signature != null && mobspSelectUserSignatureByUserId_Result2.Signature.Length != 0)
							{
								parameters.PreOrderSignatureVerifierUser = mobspSelectUserSignatureByUserId_Result2.Signature;
							}
							string text8 = "";
							if (wSspRpt_PrintPreOrder_Result != null)
							{
								text8 = wSspRpt_PrintPreOrder_Result.pordLinkAccData ?? "";
							}
							else if (parameters.PrintPreOrder != null)
							{
								text8 = parameters.PrintPreOrder.pordLinkAccData ?? "";
							}
							if (!string.IsNullOrWhiteSpace(text8))
							{
								List<PordLinkAccDataViewModel> list14 = new JavaScriptSerializer().Deserialize<List<PordLinkAccDataViewModel>>(text8);
								if (list14 != null && Enumerable.Any<PordLinkAccDataViewModel>((IEnumerable<PordLinkAccDataViewModel>)list14))
								{
									foreach (PordLinkAccDataViewModel vmLkAcc in list14)
									{
										vmLkAcc.PordId = result3;
										CRMspSelectLinkAccSettingDBIsActive_Result cRMspSelectLinkAccSettingDBIsActive_Result2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDBIsActive_Result>((IEnumerable<CRMspSelectLinkAccSettingDBIsActive_Result>)list, (Func<CRMspSelectLinkAccSettingDBIsActive_Result, bool>)((CRMspSelectLinkAccSettingDBIsActive_Result m) => m.LinkAccSettingDBId == vmLkAcc.DBId.GetValueOrDefault()));
										if (cRMspSelectLinkAccSettingDBIsActive_Result2 != null)
										{
											vmLkAcc.DbName = cRMspSelectLinkAccSettingDBIsActive_Result2.LinkAccSettingDbName ?? "";
											vmLkAcc.DbTitle = cRMspSelectLinkAccSettingDBIsActive_Result2.LinkAccSettingDbTitle ?? "";
										}
									}
									parameters.NotUsed_ListLinkAccData.AddRange(list14);
								}
							}
							if (parameters.NotUsed_ListLinkAccData == null)
							{
								parameters.NotUsed_ListLinkAccData = new List<PordLinkAccDataViewModel>();
							}
							if (parameters.NotUsed_ListPayLinkAccData == null)
							{
								parameters.NotUsed_ListPayLinkAccData = new List<PayLinkAccDataViewModel>();
							}
						}
						string text9 = "";
						if (cRMspDyPrintForm_Result != null)
						{
							text9 = cRMspDyPrintForm_Result.DyFormNumber.ToString();
						}
						int? printFormatID = ((cRMspDyPrintForm_Result != null && cRMspDyPrintForm_Result.PrintFormatId.HasValue) ? cRMspDyPrintForm_Result.PrintFormatId : new int?(0));
						MobspReturnPrintFormatFileNameById_Result mobspReturnPrintFormatFileNameById_Result = Enumerable.FirstOrDefault<MobspReturnPrintFormatFileNameById_Result>((IEnumerable<MobspReturnPrintFormatFileNameById_Result>)db.MobspReturnPrintFormatFileNameById(printFormatID));
						if ((mobspReturnPrintFormatFileNameById_Result?.CId).GetValueOrDefault() != 0 && !string.IsNullOrWhiteSpace(text4))
						{
							if (!text4.EndsWith("\\"))
							{
								text4 += "\\";
							}
							text4 = text4 + mobspReturnPrintFormatFileNameById_Result.CId + "\\";
						}
						if (string.IsNullOrWhiteSpace(FileName) || FileName.ToLower() == "null")
						{
							if (mobspReturnPrintFormatFileNameById_Result != null)
							{
								text5 = mobspReturnPrintFormatFileNameById_Result.FileNameWeb;
							}
							if (string.IsNullOrEmpty(text5))
							{
								text5 = "PrintDyForm.mrt";
							}
							if (!System.IO.File.Exists(text4 + text5))
							{
								text5 = "PrintDyForm.mrt";
							}
						}
						else
						{
							text5 = FileName;
						}
						XmlSerializer val3 = new XmlSerializer(typeof(Mobile.Models.ReportModel.PrintDyFormRpt.Parameters));
						StringWriter stringWriter = new StringWriter();
						XmlWriter val4 = XmlWriter.Create((TextWriter)stringWriter);
						val3.Serialize(val4, (object)parameters);
						DataSet val5 = new DataSet();
						val5.ReadXmlSchema(text3 + "PrintDyForm.xsd");
						XElement val6 = XElement.Parse(stringWriter.ToString());
						val5.ReadXml(((XNode)val6).CreateReader((ReaderOptions)0));
						if (memoryStream != null)
						{
							DataSet val7 = new DataSet();
							val7.ReadXml((Stream)memoryStream);
							val5.Merge(val7);
							memoryStream.Dispose();
							((MarshalByValueComponent)val7).Dispose();
						}
						stiReport.Load(text4 + text5);
						string text10 = "Integrated Security=False;Data Source={DBServer};Initial Catalog={DBName};Password={DBPass};User ID={DBUser}";
						text10 = text10.Replace("{DBServer}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBServer"]));
						text10 = text10.Replace("{DBName}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBName"]));
						text10 = text10.Replace("{DBUser}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBUser"]));
						text10 = text10.Replace("{DBPass}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBPass"]));
						((CollectionBase)stiReport.Dictionary.Databases).Clear();
						stiReport.Dictionary.Databases.Add(new StiSqlDatabase("CRMIdealExtra", text10));
						stiReport.Compile();
						stiReport.RegData(val5);
						stiReport.Render();
						string text11 = HttpContext.Current.Server.MapPath("~/Download") + "\\Reports\\Files\\" + token2.userId;
						if (!System.IO.Directory.Exists(text11))
						{
							System.IO.Directory.CreateDirectory(text11);
							CRM.General.IO.Directory.SetFullControlForEveryOne(text11);
						}
						string path = text11 + "\\DyForm-" + text9 + "-" + now.ToString("yyyyMMddHHmmssfff") + ".pdf";
						try
						{
							System.IO.File.Delete(path);
						}
						catch (Exception e)
						{
							ErrorSignal.FromCurrentContext().Raise(e);
							text2 = "خطا در یافت";
							text = null;
							serviceResultStatus = ServiceResultStatus.Error;
						}
						StiJpegExportSettings stiJpegExportSettings = new StiJpegExportSettings
						{
							ImageResolution = 300
						};
						int currentPage = Enumerable.Count<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
						string text12 = text11 + "\\DyForm-" + text9 + "-" + now.ToString("yyyyMMddHHmmssfff") + ".pdf";
						string text13 = text11 + "\\DyForm_Zip_" + text9;
						if (!System.IO.Directory.Exists(text13))
						{
							System.IO.Directory.CreateDirectory(text13);
							CRM.General.IO.Directory.SetFullControlForEveryOne(text13);
						}
						string file = text13 + "\\DyForm_001.jpg";
						stiJpegExportSettings.PageRange = new StiPagesRange(currentPage);
						stiReport.ExportDocument(StiExportFormat.ImageJpeg, file, stiJpegExportSettings);
						string[] files = System.IO.Directory.GetFiles(text13);
						if (Enumerable.Any<string>((IEnumerable<string>)files))
						{
							PdfDocument pdfDocument = new PdfDocument();
							for (int j = 0; j < files.Length; j++)
							{
								PdfPage pdfPage = new PdfPage();
								StiPage stiPage = Enumerable.FirstOrDefault<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
								if (stiPage != null)
								{
									if (stiPage.Orientation == StiPageOrientation.Landscape)
									{
										pdfPage.Orientation = PageOrientation.Landscape;
									}
									try
									{
										PaperKind paperSize = stiPage.PaperSize;
										switch (paperSize - 8)
										{
										default:
											if ((int)paperSize != 66)
											{
												break;
											}
											pdfPage.Size = PageSize.A2;
											goto end_IL_28eb;
										case 0:
											pdfPage.Size = PageSize.A3;
											goto end_IL_28eb;
										case 1:
											pdfPage.Size = PageSize.A4;
											goto end_IL_28eb;
										case 3:
											pdfPage.Size = PageSize.A5;
											goto end_IL_28eb;
										case 4:
											pdfPage.Size = PageSize.B4;
											goto end_IL_28eb;
										case 5:
											pdfPage.Size = PageSize.B5;
											goto end_IL_28eb;
										case 2:
											break;
										}
										pdfPage.Size = PageSize.A4;
										end_IL_28eb:;
									}
									catch (Exception e2)
									{
										ErrorSignal.FromCurrentContext().Raise(e2);
										pdfPage.Size = PageSize.A4;
									}
								}
								pdfDocument.Pages.Add(pdfPage);
								XGraphics xGraphics = XGraphics.FromPdfPage(pdfDocument.Pages[j]);
								XImage xImage = XImage.FromFile(files[j]);
								xGraphics.DrawImage(xImage, 0.0, 0.0);
								xImage.Dispose();
								xGraphics.Dispose();
							}
							pdfDocument.Save(text12);
							pdfDocument.Close();
						}
						try
						{
							DirectoryInfo directoryInfo = new DirectoryInfo(text13);
							FileInfo[] files2 = directoryInfo.GetFiles();
							for (int k = 0; k < files2.Length; k++)
							{
								files2[k].Delete();
							}
							DirectoryInfo[] directories = directoryInfo.GetDirectories();
							for (int k = 0; k < directories.Length; k++)
							{
								directories[k].Delete(recursive: true);
							}
							if (System.IO.Directory.Exists(text13))
							{
								System.IO.Directory.Delete(text13);
							}
						}
						catch (Exception e3)
						{
							ErrorSignal.FromCurrentContext().Raise(e3);
						}
						path = text12;
						string[] array3 = HttpContext.Current.Request.Url.AbsoluteUri.Split(new string[1] { "/api/" }, StringSplitOptions.None);
						string text14 = "";
						if (array3 != null)
						{
							string text15 = "/Download/Reports/Files/" + token2.userId + "/DyForm-" + text9 + "-" + now.ToString("yyyyMMddHHmmssfff") + ".pdf";
							text14 = ((array3[0] != null && array3[0] != "") ? (array3[0] + text15) : "");
						}
						PrintLog.InsertPrintLog(masterValueId, 505, 3);
						text = (System.IO.File.Exists(path) ? text14 : "");
						text2 = Messages.MobMsgSuccessAction;
						serviceResultStatus = ServiceResultStatus.Success;
					}
					else
					{
						text2 = Messages.MobMsgErrorFileNotExist;
						text = null;
						serviceResultStatus = ServiceResultStatus.Error;
					}
				}
				else
				{
					text2 = Messages.MobMsgErrorAccessingToken;
					text = null;
					serviceResultStatus = ServiceResultStatus.Error;
				}
			}
			else
			{
				text2 = Messages.MobMsgErrorAccessingToken;
				text = null;
				serviceResultStatus = ServiceResultStatus.Error;
			}
		}
		catch (Exception e4)
		{
			text2 = Messages.MobMsgErrorDoneOperation;
			text = null;
			serviceResultStatus = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e4);
		}
		return new ServiceResult<string>
		{
			Message = text2,
			Data = text,
			Status = serviceResultStatus
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> GetPdfPayRollUserCycle(int cycleId, int? ln = null, int? pfCId = null)
	{
		//IL_0cfb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d00: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d02: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d05: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d23: Expected I4, but got Unknown
		//IL_0d23: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d27: Invalid comparison between Unknown and I4
		//IL_09f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a12: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a19: Expected O, but got Unknown
		//IL_0a44: Unknown result type (might be due to invalid IL or missing references)
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		string text = null;
		string text2 = "";
		ServiceResultStatus serviceResultStatus = ServiceResultStatus.Fail;
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
					try
					{
						cRMEntities = new CRMEntities();
						StiReport stiReport = new StiReport();
						if (cycleId > 0)
						{
							string text3 = HttpContext.Current.Server.MapPath("~/Areas/Reports/ReportDatasets/");
							string text4 = HttpContext.Current.Server.MapPath("~/Areas/Reports/ReportFiles/");
							string text5 = "";
							Mobile.Models.ReportModel.PrintPayRollUserCycleRpt.Parameters parameters = new Mobile.Models.ReportModel.PrintPayRollUserCycleRpt.Parameters();
							_ = token2.userId;
							DateTime now = DateTime.Now;
							string rptDate = now.ToString("yyyy/MM/dd");
							string rptDay = now.ToString("dddd");
							Reports reports = new Reports();
							parameters.SysSetting = reports.GetSysSetting();
							PayRollspPrintUserCycle_Result payRollspPrintUserCycle_Result = Enumerable.FirstOrDefault<PayRollspPrintUserCycle_Result>((IEnumerable<PayRollspPrintUserCycle_Result>)cRMEntities.PayRollspPrintUserCycle(cycleId, UserLogin.CurrentUser.UserId, rptDate, rptDay, num, result2));
							if (payRollspPrintUserCycle_Result != null && num != 1065)
							{
								if (!string.IsNullOrEmpty(payRollspPrintUserCycle_Result.FirstRegisterDatePersian))
								{
									payRollspPrintUserCycle_Result.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(payRollspPrintUserCycle_Result.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(payRollspPrintUserCycle_Result.RegisterDatePersian))
								{
									payRollspPrintUserCycle_Result.RegisterDatePersian = PersianDate.GetShamsi2Miladi(payRollspPrintUserCycle_Result.RegisterDatePersian.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(payRollspPrintUserCycle_Result.CycleVerifiedDatePersian))
								{
									payRollspPrintUserCycle_Result.CycleVerifiedDatePersian = PersianDate.GetShamsi2Miladi(payRollspPrintUserCycle_Result.CycleVerifiedDatePersian.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(payRollspPrintUserCycle_Result.CycleDatePersian))
								{
									payRollspPrintUserCycle_Result.CycleDatePersian = PersianDate.GetShamsi2Miladi(payRollspPrintUserCycle_Result.CycleDatePersian.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(payRollspPrintUserCycle_Result.CrmUserStartDatePersian))
								{
									payRollspPrintUserCycle_Result.CrmUserStartDatePersian = PersianDate.GetShamsi2Miladi(payRollspPrintUserCycle_Result.CrmUserStartDatePersian.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(payRollspPrintUserCycle_Result.CrmUserExpireDatePersian))
								{
									payRollspPrintUserCycle_Result.CrmUserExpireDatePersian = PersianDate.GetShamsi2Miladi(payRollspPrintUserCycle_Result.CrmUserExpireDatePersian.Replace("/", "")).Replace("/", "");
								}
							}
							parameters.PayRollspPrintUserCycle = payRollspPrintUserCycle_Result;
							byte[] coLoGo = SysSeting.Get().CoLoGo;
							if (coLoGo != null && coLoGo.Length != 0)
							{
								parameters.CoLogo = Convert.ToBase64String(coLoGo);
							}
							parameters.ReportDateTime = DateTime.Now;
							parameters.ReporterUserName = UserLogin.CurrentUser.FullName;
							parameters.NotUsed_ListUserCycleItems = new List<PayRollspPrintUserCycleItemValues_Result>();
							parameters.NotUsed_ListUserCycleItems = Enumerable.ToList<PayRollspPrintUserCycleItemValues_Result>((IEnumerable<PayRollspPrintUserCycleItemValues_Result>)cRMEntities.PayRollspPrintUserCycleItemValues(cycleId, num, result2));
							parameters.NotUsed_ListUserPayments = new List<PayRollspPrintUserPayments_Result>();
							parameters.NotUsed_ListUserPayments = Enumerable.ToList<PayRollspPrintUserPayments_Result>((IEnumerable<PayRollspPrintUserPayments_Result>)cRMEntities.PayRollspPrintUserPayments(cycleId, num, result2));
							foreach (PayRollspPrintUserPayments_Result notUsed_ListUserPayment in parameters.NotUsed_ListUserPayments)
							{
								if (num != 1065)
								{
									if (!string.IsNullOrEmpty(notUsed_ListUserPayment.FirstRegisterDatePersian))
									{
										notUsed_ListUserPayment.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListUserPayment.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(notUsed_ListUserPayment.RegisterDatePersian))
									{
										notUsed_ListUserPayment.RegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListUserPayment.RegisterDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(notUsed_ListUserPayment.PaymentDatePersian))
									{
										notUsed_ListUserPayment.PaymentDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListUserPayment.PaymentDatePersian.Replace("/", "")).Replace("/", "");
									}
								}
							}
							parameters.SignatureFirstUser = null;
							parameters.SignatureLastEditUser = null;
							parameters.SignatureVerifierUser = null;
							parameters.SignatureCrmUser = null;
							if (payRollspPrintUserCycle_Result != null)
							{
								_ = payRollspPrintUserCycle_Result.FirstRegisterUserId;
								MobspSelectUserSignatureByUserId_Result mobspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<MobspSelectUserSignatureByUserId_Result>((IEnumerable<MobspSelectUserSignatureByUserId_Result>)cRMEntities.MobspSelectUserSignatureByUserId(payRollspPrintUserCycle_Result.FirstRegisterUserId));
								if (mobspSelectUserSignatureByUserId_Result != null && mobspSelectUserSignatureByUserId_Result.Signature != null && mobspSelectUserSignatureByUserId_Result.Signature.Length != 0)
								{
									parameters.SignatureFirstUser = mobspSelectUserSignatureByUserId_Result.Signature;
								}
								_ = payRollspPrintUserCycle_Result.UserId;
								MobspSelectUserSignatureByUserId_Result mobspSelectUserSignatureByUserId_Result2 = Enumerable.FirstOrDefault<MobspSelectUserSignatureByUserId_Result>((IEnumerable<MobspSelectUserSignatureByUserId_Result>)cRMEntities.MobspSelectUserSignatureByUserId(payRollspPrintUserCycle_Result.UserId));
								if (mobspSelectUserSignatureByUserId_Result2 != null && mobspSelectUserSignatureByUserId_Result2.Signature != null && mobspSelectUserSignatureByUserId_Result2.Signature.Length != 0)
								{
									parameters.SignatureLastEditUser = mobspSelectUserSignatureByUserId_Result2.Signature;
								}
								if (payRollspPrintUserCycle_Result.CycleVerifierUserId.HasValue)
								{
									MobspSelectUserSignatureByUserId_Result mobspSelectUserSignatureByUserId_Result3 = Enumerable.FirstOrDefault<MobspSelectUserSignatureByUserId_Result>((IEnumerable<MobspSelectUserSignatureByUserId_Result>)cRMEntities.MobspSelectUserSignatureByUserId(payRollspPrintUserCycle_Result.CycleVerifierUserId));
									if (mobspSelectUserSignatureByUserId_Result3 != null && mobspSelectUserSignatureByUserId_Result3.Signature != null && mobspSelectUserSignatureByUserId_Result3.Signature.Length != 0)
									{
										parameters.SignatureVerifierUser = mobspSelectUserSignatureByUserId_Result3.Signature;
									}
								}
								_ = payRollspPrintUserCycle_Result.CrmUserId;
								MobspSelectUserSignatureByUserId_Result mobspSelectUserSignatureByUserId_Result4 = Enumerable.FirstOrDefault<MobspSelectUserSignatureByUserId_Result>((IEnumerable<MobspSelectUserSignatureByUserId_Result>)cRMEntities.MobspSelectUserSignatureByUserId(payRollspPrintUserCycle_Result.CrmUserId));
								if (mobspSelectUserSignatureByUserId_Result4 != null && mobspSelectUserSignatureByUserId_Result4.Signature != null && mobspSelectUserSignatureByUserId_Result4.Signature.Length != 0)
								{
									parameters.SignatureCrmUser = mobspSelectUserSignatureByUserId_Result4.Signature;
								}
							}
							parameters.NotUsed_ListOrderCommissions = new List<PayRollspPrintUserCycleOrderCommissions_Result>();
							parameters.NotUsed_ListOrderCommissions = Enumerable.ToList<PayRollspPrintUserCycleOrderCommissions_Result>((IEnumerable<PayRollspPrintUserCycleOrderCommissions_Result>)cRMEntities.PayRollspPrintUserCycleOrderCommissions(cycleId, UserLogin.CurrentUser.UserId, num, result2));
							if (parameters.NotUsed_ListOrderCommissions != null && Enumerable.Any<PayRollspPrintUserCycleOrderCommissions_Result>((IEnumerable<PayRollspPrintUserCycleOrderCommissions_Result>)parameters.NotUsed_ListOrderCommissions))
							{
								foreach (PayRollspPrintUserCycleOrderCommissions_Result notUsed_ListOrderCommission in parameters.NotUsed_ListOrderCommissions)
								{
									if (num != 1065)
									{
										if (!string.IsNullOrEmpty(notUsed_ListOrderCommission.CommDatePersian))
										{
											notUsed_ListOrderCommission.CommDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListOrderCommission.CommDatePersian.Replace("/", "")).Replace("/", "");
										}
										if (!string.IsNullOrEmpty(notUsed_ListOrderCommission.FirstRegisterDatePersian))
										{
											notUsed_ListOrderCommission.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListOrderCommission.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
										}
										if (!string.IsNullOrEmpty(notUsed_ListOrderCommission.RegisterDatePersian))
										{
											notUsed_ListOrderCommission.RegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListOrderCommission.RegisterDatePersian.Replace("/", "")).Replace("/", "");
										}
										if (!string.IsNullOrEmpty(notUsed_ListOrderCommission.CommEffectiveDatePersian))
										{
											notUsed_ListOrderCommission.CommEffectiveDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListOrderCommission.CommEffectiveDatePersian.Replace("/", "")).Replace("/", "");
										}
										if (!string.IsNullOrEmpty(notUsed_ListOrderCommission.CommVerifiedDatePersian))
										{
											notUsed_ListOrderCommission.CommVerifiedDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListOrderCommission.CommVerifiedDatePersian.Replace("/", "")).Replace("/", "");
										}
										if (!string.IsNullOrEmpty(notUsed_ListOrderCommission.CommIsPaidDatePersian))
										{
											notUsed_ListOrderCommission.CommIsPaidDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListOrderCommission.CommIsPaidDatePersian.Replace("/", "")).Replace("/", "");
										}
										if (!string.IsNullOrEmpty(notUsed_ListOrderCommission.CommOrderDate))
										{
											notUsed_ListOrderCommission.CommOrderDate = PersianDate.GetShamsi2Miladi(notUsed_ListOrderCommission.CommOrderDate.Replace("/", "")).Replace("/", "");
										}
									}
									if (notUsed_ListOrderCommission.CommUserSignature != null)
									{
										notUsed_ListOrderCommission.CommUserSignatureStr = Convert.ToBase64String(notUsed_ListOrderCommission.CommUserSignature);
									}
									if (notUsed_ListOrderCommission.FirstRegisterUserSignature != null)
									{
										notUsed_ListOrderCommission.FirstRegisterUserSignatureStr = Convert.ToBase64String(notUsed_ListOrderCommission.FirstRegisterUserSignature);
									}
									if (notUsed_ListOrderCommission.EditUserSignature != null)
									{
										notUsed_ListOrderCommission.EditUserSignatureStr = Convert.ToBase64String(notUsed_ListOrderCommission.EditUserSignature);
									}
									if (notUsed_ListOrderCommission.CommVerifierUserSignature != null)
									{
										notUsed_ListOrderCommission.CommVerifierUserSignatureStr = Convert.ToBase64String(notUsed_ListOrderCommission.CommVerifierUserSignature);
									}
									if (notUsed_ListOrderCommission.CommIsPaidUserSignature != null)
									{
										notUsed_ListOrderCommission.CommIsPaidUserSignatureStr = Convert.ToBase64String(notUsed_ListOrderCommission.CommIsPaidUserSignature);
									}
								}
							}
							else
							{
								parameters.NotUsed_ListOrderCommissions = new List<PayRollspPrintUserCycleOrderCommissions_Result>();
							}
							parameters.NotUsed_ListUserCycleItemsInfo = new List<PayRollspPrintUserCycleItemValuesInfo_Result>();
							parameters.NotUsed_ListUserCycleItemsInfo = Enumerable.ToList<PayRollspPrintUserCycleItemValuesInfo_Result>((IEnumerable<PayRollspPrintUserCycleItemValuesInfo_Result>)cRMEntities.PayRollspPrintUserCycleItemValuesInfo(cycleId, num, result2));
							int? printFormatID = ((payRollspPrintUserCycle_Result != null && payRollspPrintUserCycle_Result.CyclePrintFormatId.HasValue) ? payRollspPrintUserCycle_Result.CyclePrintFormatId : new int?(0));
							MobspReturnPrintFormatFileNameById_Result mobspReturnPrintFormatFileNameById_Result = Enumerable.FirstOrDefault<MobspReturnPrintFormatFileNameById_Result>((IEnumerable<MobspReturnPrintFormatFileNameById_Result>)cRMEntities.MobspReturnPrintFormatFileNameById(printFormatID));
							if ((mobspReturnPrintFormatFileNameById_Result?.CId).GetValueOrDefault() != 0 && !string.IsNullOrWhiteSpace(text4))
							{
								if (!text4.EndsWith("\\"))
								{
									text4 += "\\";
								}
								text4 = text4 + mobspReturnPrintFormatFileNameById_Result.CId + "\\";
							}
							if (mobspReturnPrintFormatFileNameById_Result != null)
							{
								text5 = mobspReturnPrintFormatFileNameById_Result.FileNameWeb;
							}
							if (string.IsNullOrEmpty(text5))
							{
								text5 = "PrintPayRollUserCycle.mrt";
							}
							if (!System.IO.File.Exists(text4 + text5))
							{
								text5 = "PrintPayRollUserCycle.mrt";
							}
							XmlSerializer val = new XmlSerializer(typeof(Mobile.Models.ReportModel.PrintPayRollUserCycleRpt.Parameters));
							StringWriter stringWriter = new StringWriter();
							XmlWriter val2 = XmlWriter.Create((TextWriter)stringWriter);
							val.Serialize(val2, (object)parameters);
							DataSet val3 = new DataSet();
							val3.ReadXmlSchema(text3 + "PrintPayRollUserCycle.xsd");
							XElement val4 = XElement.Parse(stringWriter.ToString());
							val3.ReadXml(((XNode)val4).CreateReader((ReaderOptions)0));
							stiReport.Load(text4 + text5);
							string text6 = "Integrated Security=False;Data Source={DBServer};Initial Catalog={DBName};Password={DBPass};User ID={DBUser}";
							text6 = text6.Replace("{DBServer}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBServer"]));
							text6 = text6.Replace("{DBName}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBName"]));
							text6 = text6.Replace("{DBUser}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBUser"]));
							text6 = text6.Replace("{DBPass}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBPass"]));
							((CollectionBase)stiReport.Dictionary.Databases).Clear();
							stiReport.Dictionary.Databases.Add(new StiSqlDatabase("CRMIdealExtra", text6));
							stiReport.Compile();
							stiReport.RegData(val3);
							stiReport.Render();
							string text7 = HttpContext.Current.Server.MapPath("~/Download") + "\\Reports\\Files\\" + token2.userId;
							if (!System.IO.Directory.Exists(text7))
							{
								System.IO.Directory.CreateDirectory(text7);
								CRM.General.IO.Directory.SetFullControlForEveryOne(text7);
							}
							string path = text7 + "\\PayRoll-" + cycleId + "-" + now.ToString("yyyyMMddHHmmssfff") + ".pdf";
							try
							{
								System.IO.File.Delete(path);
							}
							catch (Exception e)
							{
								ErrorSignal.FromCurrentContext().Raise(e);
								text2 = "خطا در یافت";
								text = null;
								serviceResultStatus = ServiceResultStatus.Error;
							}
							StiJpegExportSettings stiJpegExportSettings = new StiJpegExportSettings
							{
								ImageResolution = 300
							};
							int currentPage = Enumerable.Count<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
							string text8 = text7 + "\\PayRoll-" + cycleId + "-" + now.ToString("yyyyMMddHHmmssfff") + ".pdf";
							string text9 = text7 + "\\PayRoll_Zip_" + cycleId;
							if (!System.IO.Directory.Exists(text9))
							{
								System.IO.Directory.CreateDirectory(text9);
								CRM.General.IO.Directory.SetFullControlForEveryOne(text9);
							}
							string file = text9 + "\\PayRoll_001.jpg";
							stiJpegExportSettings.PageRange = new StiPagesRange(currentPage);
							stiReport.ExportDocument(StiExportFormat.ImageJpeg, file, stiJpegExportSettings);
							string[] files = System.IO.Directory.GetFiles(text9);
							if (Enumerable.Any<string>((IEnumerable<string>)files))
							{
								PdfDocument pdfDocument = new PdfDocument();
								for (int i = 0; i < files.Length; i++)
								{
									PdfPage pdfPage = new PdfPage();
									StiPage stiPage = Enumerable.FirstOrDefault<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
									if (stiPage != null)
									{
										if (stiPage.Orientation == StiPageOrientation.Landscape)
										{
											pdfPage.Orientation = PageOrientation.Landscape;
										}
										try
										{
											PaperKind paperSize = stiPage.PaperSize;
											switch (paperSize - 8)
											{
											default:
												if ((int)paperSize != 66)
												{
													break;
												}
												pdfPage.Size = PageSize.A2;
												goto end_IL_0cf9;
											case 0:
												pdfPage.Size = PageSize.A3;
												goto end_IL_0cf9;
											case 1:
												pdfPage.Size = PageSize.A4;
												goto end_IL_0cf9;
											case 3:
												pdfPage.Size = PageSize.A5;
												goto end_IL_0cf9;
											case 4:
												pdfPage.Size = PageSize.B4;
												goto end_IL_0cf9;
											case 5:
												pdfPage.Size = PageSize.B5;
												goto end_IL_0cf9;
											case 2:
												break;
											}
											pdfPage.Size = PageSize.A4;
											end_IL_0cf9:;
										}
										catch (Exception e2)
										{
											ErrorSignal.FromCurrentContext().Raise(e2);
											pdfPage.Size = PageSize.A4;
										}
									}
									pdfDocument.Pages.Add(pdfPage);
									XGraphics xGraphics = XGraphics.FromPdfPage(pdfDocument.Pages[i]);
									XImage xImage = XImage.FromFile(files[i]);
									xGraphics.DrawImage(xImage, 0.0, 0.0);
									xImage.Dispose();
									xGraphics.Dispose();
								}
								pdfDocument.Save(text8);
								pdfDocument.Close();
							}
							try
							{
								DirectoryInfo directoryInfo = new DirectoryInfo(text9);
								FileInfo[] files2 = directoryInfo.GetFiles();
								for (int j = 0; j < files2.Length; j++)
								{
									files2[j].Delete();
								}
								DirectoryInfo[] directories = directoryInfo.GetDirectories();
								for (int j = 0; j < directories.Length; j++)
								{
									directories[j].Delete(recursive: true);
								}
								if (System.IO.Directory.Exists(text9))
								{
									System.IO.Directory.Delete(text9);
								}
							}
							catch (Exception e3)
							{
								ErrorSignal.FromCurrentContext().Raise(e3);
							}
							path = text8;
							string[] array = HttpContext.Current.Request.Url.AbsoluteUri.Split(new string[1] { "/api/" }, StringSplitOptions.None);
							string text10 = "";
							if (array != null)
							{
								string text11 = "/Download/Reports/Files/" + token2.userId + "/PayRoll-" + cycleId + "-" + now.ToString("yyyyMMddHHmmssfff") + ".pdf";
								text10 = ((array[0] != null && array[0] != "") ? (array[0] + text11) : "");
							}
							text = (System.IO.File.Exists(path) ? text10 : "");
							text2 = Messages.MobMsgSuccessAction;
							serviceResultStatus = ServiceResultStatus.Success;
						}
						else
						{
							text2 = Messages.MobMsgErrorFileNotExist;
							text = null;
							serviceResultStatus = ServiceResultStatus.Error;
						}
					}
					catch (Exception e4)
					{
						text2 = Messages.MobMsgErrorDoneOperation;
						text = null;
						serviceResultStatus = ServiceResultStatus.Error;
						ErrorSignal.FromCurrentContext().Raise(e4);
					}
				}
				else
				{
					text2 = Messages.MobMsgErrorAccessingToken;
					text = null;
					serviceResultStatus = ServiceResultStatus.Error;
				}
			}
			else
			{
				text2 = Messages.MobMsgErrorAccessingToken;
				text = null;
				serviceResultStatus = ServiceResultStatus.Error;
			}
		}
		catch (Exception e5)
		{
			text2 = Messages.MobMsgErrorDoneOperation;
			text = null;
			serviceResultStatus = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e5);
		}
		return new ServiceResult<string>
		{
			Message = text2,
			Data = text,
			Status = serviceResultStatus
		};
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> GetPdfDoc(int docId, string printFormatFile, int? ln = null, int? pfCId = null)
	{
		//IL_1329: Unknown result type (might be due to invalid IL or missing references)
		//IL_132e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1330: Unknown result type (might be due to invalid IL or missing references)
		//IL_1333: Unknown result type (might be due to invalid IL or missing references)
		//IL_1351: Expected I4, but got Unknown
		//IL_1351: Unknown result type (might be due to invalid IL or missing references)
		//IL_1355: Invalid comparison between Unknown and I4
		//IL_0ebc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1021: Unknown result type (might be due to invalid IL or missing references)
		//IL_103f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1046: Expected O, but got Unknown
		//IL_1071: Unknown result type (might be due to invalid IL or missing references)
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
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
					try
					{
						cRMEntities = new CRMEntities();
						cRMSpEntities = new CRMSpEntities();
						StiReport stiReport = new StiReport();
						if (docId > 0)
						{
							cRMSpEntities.WSspDocSetToIsFix(docId);
							string manualIssuing = Labels.ManualIssuing;
							string systemIssuing = Labels.SystemIssuing;
							string text = HttpContext.Current.Server.MapPath("~/Areas/Reports/ReportDatasets/");
							string text2 = HttpContext.Current.Server.MapPath("~/Areas/Reports/ReportFiles/");
							string text3 = "";
							Mobile.Models.ReportModel.DocPrintRpt.Parameters parameters = new Mobile.Models.ReportModel.DocPrintRpt.Parameters();
							int userId = token2.userId;
							DateTime now = DateTime.Now;
							string rptDate = now.ToString("yyyy/MM/dd");
							string rptDay = now.ToString("dddd");
							Reports reports = new Reports();
							parameters.SysSetting = reports.GetSysSetting();
							parameters.NotUsed_ListLinkAccData = new List<DocLinkAccDataViewModel>();
							MobspSelectCrmsysSetting_Result mobspSelectCrmsysSetting_Result = SysSeting.Get();
							int result3 = 0;
							if (mobspSelectCrmsysSetting_Result != null)
							{
								int.TryParse(mobspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result3);
							}
							List<CRMspSelectLinkAccSettingDBIsActive_Result> list = new List<CRMspSelectLinkAccSettingDBIsActive_Result>();
							if (result3 == 1)
							{
								list = OtherSystems.GetLinkAccSettingDBList(1);
							}
							parameters.PrintDoc = Enumerable.FirstOrDefault<WSspRpt_PrintDoc_Result>((IEnumerable<WSspRpt_PrintDoc_Result>)Enumerable.ToList<WSspRpt_PrintDoc_Result>((IEnumerable<WSspRpt_PrintDoc_Result>)cRMSpEntities.WSspRpt_PrintDoc(docId, num, result2, manualIssuing, systemIssuing, userId, rptDate, rptDay)));
							if (parameters.PrintDoc != null && num != 1065)
							{
								if (!string.IsNullOrEmpty(parameters.PrintDoc.DocDate))
								{
									parameters.PrintDoc.DocDate = PersianDate.GetShamsi2Miladi(parameters.PrintDoc.DocDate.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(parameters.PrintDoc.RegisterDatePersian))
								{
									parameters.PrintDoc.RegisterDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintDoc.RegisterDatePersian.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(parameters.PrintDoc.FirstRegisterDatePersian))
								{
									parameters.PrintDoc.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintDoc.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(parameters.PrintDoc.ordDeliveryDate))
								{
									parameters.PrintDoc.ordDeliveryDate = PersianDate.GetShamsi2Miladi(parameters.PrintDoc.ordDeliveryDate.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(parameters.PrintDoc.ordDeliveryEndDate))
								{
									parameters.PrintDoc.ordDeliveryEndDate = PersianDate.GetShamsi2Miladi(parameters.PrintDoc.ordDeliveryEndDate.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(parameters.PrintDoc.bordDeliveryDatePersian))
								{
									parameters.PrintDoc.bordDeliveryDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintDoc.bordDeliveryDatePersian.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(parameters.PrintDoc.bordSupplierDeliveryDatePersian))
								{
									parameters.PrintDoc.bordSupplierDeliveryDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintDoc.bordSupplierDeliveryDatePersian.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(parameters.PrintDoc.bordFinalDeliveryDatePersian))
								{
									parameters.PrintDoc.bordFinalDeliveryDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintDoc.bordFinalDeliveryDatePersian.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(parameters.PrintDoc.VerifiedRegisterDatePersian))
								{
									parameters.PrintDoc.VerifiedRegisterDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintDoc.VerifiedRegisterDatePersian.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(parameters.PrintDoc.pordDate))
								{
									parameters.PrintDoc.pordDate = PersianDate.GetShamsi2Miladi(parameters.PrintDoc.pordDate.Replace("/", "")).Replace("/", "");
								}
							}
							parameters.NotUsed_ListPrintDocItems = Enumerable.ToList<WSspRpt_PrintDocItems_Result>((IEnumerable<WSspRpt_PrintDocItems_Result>)cRMSpEntities.WSspRpt_PrintDocItems(docId, num, result2));
							List<WSspRpt_PrintDocItemSerials_Result> list2 = new List<WSspRpt_PrintDocItemSerials_Result>();
							foreach (WSspRpt_PrintDocItems_Result notUsed_ListPrintDocItem in parameters.NotUsed_ListPrintDocItems)
							{
								List<WSspRpt_PrintDocItemSerials_Result> collection = Enumerable.ToList<WSspRpt_PrintDocItemSerials_Result>((IEnumerable<WSspRpt_PrintDocItemSerials_Result>)cRMSpEntities.WSspRpt_PrintDocItemSerials(notUsed_ListPrintDocItem.DocItemID, num, result2));
								list2.AddRange(collection);
							}
							foreach (WSspRpt_PrintDocItemSerials_Result item in list2)
							{
								if (num != 1065)
								{
									if (!string.IsNullOrEmpty(item.RegisterDatePersian))
									{
										item.RegisterDatePersian = PersianDate.GetShamsi2Miladi(item.RegisterDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item.FirstRegisterDatePersian))
									{
										item.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(item.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
									}
								}
							}
							parameters.NotUsed_ListPrintDocItemSerials = list2;
							parameters.ListDyPrintCmpForm = new List<CRMspDyPrintCmpForm_Result>();
							parameters.ListDyPrintPrsForm = new List<CRMspDyPrintPrsForm_Result>();
							parameters.ListDyPrintPrjForm = new List<CRMspDyPrintPrjForm_Result>();
							parameters.ListDyPrintDocForm = new List<CRMspDyPrintDocForm_Result>();
							parameters.ListPrintProjectInformationTree = new List<CRMspPrintProjectInformationTree_Result>();
							if (parameters.PrintDoc != null)
							{
								if (parameters.PrintDoc.CompanyId.HasValue)
								{
									parameters.ListDyPrintCmpForm = Enumerable.ToList<CRMspDyPrintCmpForm_Result>((IEnumerable<CRMspDyPrintCmpForm_Result>)cRMSpEntities.CRMspDyPrintCmpForm(parameters.PrintDoc.CompanyId, num, result2, token2.userId, 0));
								}
								if (parameters.PrintDoc.CompanyPersonId.HasValue)
								{
									parameters.ListDyPrintPrsForm = Enumerable.ToList<CRMspDyPrintPrsForm_Result>((IEnumerable<CRMspDyPrintPrsForm_Result>)cRMSpEntities.CRMspDyPrintPrsForm(parameters.PrintDoc.CompanyPersonId, num, result2, token2.userId, 0));
								}
								if (parameters.PrintDoc.ProjectId.HasValue)
								{
									parameters.ListDyPrintPrjForm = Enumerable.ToList<CRMspDyPrintPrjForm_Result>((IEnumerable<CRMspDyPrintPrjForm_Result>)cRMSpEntities.CRMspDyPrintPrjForm(parameters.PrintDoc.ProjectId, num, result2, token2.userId, 0));
									parameters.ListPrintProjectInformationTree = Enumerable.ToList<CRMspPrintProjectInformationTree_Result>((IEnumerable<CRMspPrintProjectInformationTree_Result>)cRMEntities.CRMspPrintProjectInformationTree(parameters.PrintDoc.ProjectId, num, result2));
								}
								parameters.ListDyPrintDocForm = Enumerable.ToList<CRMspDyPrintDocForm_Result>((IEnumerable<CRMspDyPrintDocForm_Result>)cRMSpEntities.CRMspDyPrintDocForm(parameters.PrintDoc.DocID, num, result2, token2.userId, 0));
							}
							parameters.NotUsed_ListPrintOrderVerificationRequestDetails = new List<WSspRpt_PrintVerificationRequestDetails_Result>();
							if (parameters.PrintDoc != null)
							{
								int result4 = 0;
								int.TryParse(parameters.PrintDoc.OrderId.ToString(), out result4);
								if (result4 > 0)
								{
									WSspSelectOrderById_Result wSspSelectOrderById_Result = Enumerable.FirstOrDefault<WSspSelectOrderById_Result>((IEnumerable<WSspSelectOrderById_Result>)cRMSpEntities.WSspSelectOrderById(result4, num, result2));
									if (wSspSelectOrderById_Result != null && wSspSelectOrderById_Result.ordVerificationWorkFlowId.HasValue)
									{
										parameters.NotUsed_ListPrintOrderVerificationRequestDetails = Enumerable.ToList<WSspRpt_PrintVerificationRequestDetails_Result>((IEnumerable<WSspRpt_PrintVerificationRequestDetails_Result>)cRMEntities.WSspRpt_PrintVerificationRequestDetails(wSspSelectOrderById_Result.OrderID, 20, wSspSelectOrderById_Result.ordVerificationWorkFlowId, num, result2));
										if (parameters.NotUsed_ListPrintOrderVerificationRequestDetails != null && Enumerable.Any<WSspRpt_PrintVerificationRequestDetails_Result>((IEnumerable<WSspRpt_PrintVerificationRequestDetails_Result>)parameters.NotUsed_ListPrintOrderVerificationRequestDetails))
										{
											foreach (WSspRpt_PrintVerificationRequestDetails_Result notUsed_ListPrintOrderVerificationRequestDetail in parameters.NotUsed_ListPrintOrderVerificationRequestDetails)
											{
												if (num != 1065)
												{
													if (!string.IsNullOrEmpty(notUsed_ListPrintOrderVerificationRequestDetail.VerifyDatePersian))
													{
														notUsed_ListPrintOrderVerificationRequestDetail.VerifyDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintOrderVerificationRequestDetail.VerifyDatePersian.Replace("/", "")).Replace("/", "");
													}
													if (!string.IsNullOrEmpty(notUsed_ListPrintOrderVerificationRequestDetail.FirstRegisterDatePersian))
													{
														notUsed_ListPrintOrderVerificationRequestDetail.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintOrderVerificationRequestDetail.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
													}
													if (!string.IsNullOrEmpty(notUsed_ListPrintOrderVerificationRequestDetail.RegisterDatePersian))
													{
														notUsed_ListPrintOrderVerificationRequestDetail.RegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintOrderVerificationRequestDetail.RegisterDatePersian.Replace("/", "")).Replace("/", "");
													}
													if (!string.IsNullOrEmpty(notUsed_ListPrintOrderVerificationRequestDetail.VerificationReqDatePersian))
													{
														notUsed_ListPrintOrderVerificationRequestDetail.VerificationReqDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintOrderVerificationRequestDetail.VerificationReqDatePersian.Replace("/", "")).Replace("/", "");
													}
													if (!string.IsNullOrEmpty(notUsed_ListPrintOrderVerificationRequestDetail.VerificationReqExpiredDatePersian))
													{
														notUsed_ListPrintOrderVerificationRequestDetail.VerificationReqExpiredDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintOrderVerificationRequestDetail.VerificationReqExpiredDatePersian.Replace("/", "")).Replace("/", "");
													}
												}
												if (notUsed_ListPrintOrderVerificationRequestDetail.VerifyUserSignature != null)
												{
													notUsed_ListPrintOrderVerificationRequestDetail.VerifyUserSignatureStr = Convert.ToBase64String(notUsed_ListPrintOrderVerificationRequestDetail.VerifyUserSignature);
												}
											}
										}
									}
								}
							}
							if (parameters.NotUsed_ListPrintOrderVerificationRequestDetails == null)
							{
								parameters.NotUsed_ListPrintOrderVerificationRequestDetails = new List<WSspRpt_PrintVerificationRequestDetails_Result>();
							}
							parameters.NotUsed_ListPrintDocVerificationRequestDetails = new List<WSspRpt_PrintDocVerificationRequestDetails_Result>();
							if (parameters.PrintDoc != null && parameters.PrintDoc.VerificationWorkFlowId.HasValue)
							{
								parameters.NotUsed_ListPrintDocVerificationRequestDetails = Enumerable.ToList<WSspRpt_PrintDocVerificationRequestDetails_Result>((IEnumerable<WSspRpt_PrintDocVerificationRequestDetails_Result>)cRMSpEntities.WSspRpt_PrintDocVerificationRequestDetails(parameters.PrintDoc.DocID, 60, parameters.PrintDoc.VerificationWorkFlowId, num, result2));
								if (parameters.NotUsed_ListPrintDocVerificationRequestDetails != null && Enumerable.Any<WSspRpt_PrintDocVerificationRequestDetails_Result>((IEnumerable<WSspRpt_PrintDocVerificationRequestDetails_Result>)parameters.NotUsed_ListPrintDocVerificationRequestDetails))
								{
									foreach (WSspRpt_PrintDocVerificationRequestDetails_Result notUsed_ListPrintDocVerificationRequestDetail in parameters.NotUsed_ListPrintDocVerificationRequestDetails)
									{
										if (num != 1065)
										{
											if (!string.IsNullOrEmpty(notUsed_ListPrintDocVerificationRequestDetail.VerifyDatePersian))
											{
												notUsed_ListPrintDocVerificationRequestDetail.VerifyDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintDocVerificationRequestDetail.VerifyDatePersian.Replace("/", "")).Replace("/", "");
											}
											if (!string.IsNullOrEmpty(notUsed_ListPrintDocVerificationRequestDetail.FirstRegisterDatePersian))
											{
												notUsed_ListPrintDocVerificationRequestDetail.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintDocVerificationRequestDetail.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
											}
											if (!string.IsNullOrEmpty(notUsed_ListPrintDocVerificationRequestDetail.RegisterDatePersian))
											{
												notUsed_ListPrintDocVerificationRequestDetail.RegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintDocVerificationRequestDetail.RegisterDatePersian.Replace("/", "")).Replace("/", "");
											}
											if (!string.IsNullOrEmpty(notUsed_ListPrintDocVerificationRequestDetail.VerificationReqDatePersian))
											{
												notUsed_ListPrintDocVerificationRequestDetail.VerificationReqDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintDocVerificationRequestDetail.VerificationReqDatePersian.Replace("/", "")).Replace("/", "");
											}
											if (!string.IsNullOrEmpty(notUsed_ListPrintDocVerificationRequestDetail.VerificationReqExpiredDatePersian))
											{
												notUsed_ListPrintDocVerificationRequestDetail.VerificationReqExpiredDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintDocVerificationRequestDetail.VerificationReqExpiredDatePersian.Replace("/", "")).Replace("/", "");
											}
										}
										if (notUsed_ListPrintDocVerificationRequestDetail.VerifyUserSignature != null)
										{
											notUsed_ListPrintDocVerificationRequestDetail.VerifyUserSignatureStr = Convert.ToBase64String(notUsed_ListPrintDocVerificationRequestDetail.VerifyUserSignature);
										}
									}
								}
							}
							if (parameters.NotUsed_ListPrintDocVerificationRequestDetails == null)
							{
								parameters.NotUsed_ListPrintDocVerificationRequestDetails = new List<WSspRpt_PrintDocVerificationRequestDetails_Result>();
							}
							parameters.NotUsed_ListDocItemPrdPicture = new List<WSspRpt_PrintDocItemPrdPicture_Result>();
							if (parameters.PrintDoc != null)
							{
								parameters.NotUsed_ListDocItemPrdPicture = Enumerable.ToList<WSspRpt_PrintDocItemPrdPicture_Result>((IEnumerable<WSspRpt_PrintDocItemPrdPicture_Result>)cRMSpEntities.WSspRpt_PrintDocItemPrdPicture(parameters.PrintDoc.DocID, num, result2));
							}
							if (parameters.NotUsed_ListDocItemPrdPicture == null)
							{
								parameters.NotUsed_ListDocItemPrdPicture = new List<WSspRpt_PrintDocItemPrdPicture_Result>();
							}
							byte[] coLoGo = SysSeting.Get().CoLoGo;
							if (coLoGo != null && coLoGo.Length != 0)
							{
								parameters.CoLogo = Convert.ToBase64String(coLoGo);
							}
							parameters.SignatureFirstRegisterUser = null;
							parameters.SignatureLastEditUser = null;
							parameters.SignatureVerifierUser = null;
							WSspRpt_PrintDoc_Result printDoc = parameters.PrintDoc;
							if (printDoc != null)
							{
								CRMspSelectUserSignatureByUserId_Result cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)cRMEntities.CRMspSelectUserSignatureByUserId(printDoc.FirstRegisterUserId));
								if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
								{
									parameters.SignatureFirstRegisterUser = cRMspSelectUserSignatureByUserId_Result.Signature;
								}
								cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)cRMEntities.CRMspSelectUserSignatureByUserId(printDoc.UserId));
								if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
								{
									parameters.SignatureLastEditUser = cRMspSelectUserSignatureByUserId_Result.Signature;
								}
								if (printDoc.VerifierId.HasValue)
								{
									cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)cRMEntities.CRMspSelectUserSignatureByUserId(printDoc.VerifierId));
									if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
									{
										parameters.SignatureVerifierUser = cRMspSelectUserSignatureByUserId_Result.Signature;
									}
								}
							}
							parameters.NotUsed_ListPrintDocItemsFromQuantity = new List<WSspRpt_PrintDocItemsFromQuantity_Result>();
							parameters.NotUsed_ListPrintDocItemsFromQuantity = Enumerable.ToList<WSspRpt_PrintDocItemsFromQuantity_Result>((IEnumerable<WSspRpt_PrintDocItemsFromQuantity_Result>)cRMSpEntities.WSspRpt_PrintDocItemsFromQuantity(docId, num, result2));
							if (parameters.NotUsed_ListPrintDocItemsFromQuantity == null)
							{
								parameters.NotUsed_ListPrintDocItemsFromQuantity = new List<WSspRpt_PrintDocItemsFromQuantity_Result>();
							}
							string text4 = "";
							if (parameters.PrintDoc != null)
							{
								text4 = parameters.PrintDoc.DocLinkAccData ?? "";
							}
							if (!string.IsNullOrWhiteSpace(text4))
							{
								List<DocLinkAccDataViewModel> list3 = new JavaScriptSerializer().Deserialize<List<DocLinkAccDataViewModel>>(text4);
								if (list3 != null && Enumerable.Any<DocLinkAccDataViewModel>((IEnumerable<DocLinkAccDataViewModel>)list3))
								{
									foreach (DocLinkAccDataViewModel vmLkAcc in list3)
									{
										vmLkAcc.DocId = docId;
										CRMspSelectLinkAccSettingDBIsActive_Result cRMspSelectLinkAccSettingDBIsActive_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDBIsActive_Result>((IEnumerable<CRMspSelectLinkAccSettingDBIsActive_Result>)list, (Func<CRMspSelectLinkAccSettingDBIsActive_Result, bool>)((CRMspSelectLinkAccSettingDBIsActive_Result m) => m.LinkAccSettingDBId == vmLkAcc.DBId.GetValueOrDefault()));
										if (cRMspSelectLinkAccSettingDBIsActive_Result != null)
										{
											vmLkAcc.DbName = cRMspSelectLinkAccSettingDBIsActive_Result.LinkAccSettingDbName ?? "";
											vmLkAcc.DbTitle = cRMspSelectLinkAccSettingDBIsActive_Result.LinkAccSettingDbTitle ?? "";
										}
									}
									parameters.NotUsed_ListLinkAccData.AddRange(list3);
								}
							}
							if (parameters.NotUsed_ListLinkAccData == null)
							{
								parameters.NotUsed_ListLinkAccData = new List<DocLinkAccDataViewModel>();
							}
							int printFormatCId = PrintFormat.GetPrintFormatCId(0, text3);
							if (printFormatCId != 0 && !string.IsNullOrWhiteSpace(text2))
							{
								if (!text2.EndsWith("\\"))
								{
									text2 += "\\";
								}
								text2 = text2 + printFormatCId + "\\";
							}
							if (printFormatFile != null)
							{
								text3 = printFormatFile;
							}
							if (string.IsNullOrEmpty(text3))
							{
								text3 = "DocPrint.mrt";
							}
							if (!System.IO.File.Exists(text2 + text3))
							{
								text3 = "DocPrint.mrt";
							}
							XmlSerializer val = new XmlSerializer(typeof(Mobile.Models.ReportModel.DocPrintRpt.Parameters));
							StringWriter stringWriter = new StringWriter();
							XmlWriter val2 = XmlWriter.Create((TextWriter)stringWriter);
							val.Serialize(val2, (object)parameters);
							DataSet val3 = new DataSet();
							val3.ReadXmlSchema(text + "DocPrint.xsd");
							XElement val4 = XElement.Parse(stringWriter.ToString());
							val3.ReadXml(((XNode)val4).CreateReader((ReaderOptions)0));
							stiReport.Load(text2 + text3);
							string text5 = "Integrated Security=False;Data Source={DBServer};Initial Catalog={DBName};Password={DBPass};User ID={DBUser}";
							text5 = text5.Replace("{DBServer}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBServer"]));
							text5 = text5.Replace("{DBName}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBName"]));
							text5 = text5.Replace("{DBUser}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBUser"]));
							text5 = text5.Replace("{DBPass}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBPass"]));
							((CollectionBase)stiReport.Dictionary.Databases).Clear();
							stiReport.Dictionary.Databases.Add(new StiSqlDatabase("CRMIdealExtra", text5));
							stiReport.Compile();
							stiReport.RegData(val3);
							stiReport.Render();
							string text6 = HttpContext.Current.Server.MapPath("~/Download") + "\\Reports\\Files\\" + token2.userId;
							if (!System.IO.Directory.Exists(text6))
							{
								System.IO.Directory.CreateDirectory(text6);
								CRM.General.IO.Directory.SetFullControlForEveryOne(text6);
							}
							string path = text6 + "\\Doc-" + docId + "-" + now.ToString("yyyyMMddHHmmssfff") + ".pdf";
							try
							{
								System.IO.File.Delete(path);
							}
							catch (Exception e)
							{
								ErrorSignal.FromCurrentContext().Raise(e);
								message = "خطا در یافت";
								data = null;
								status = ServiceResultStatus.Error;
							}
							StiJpegExportSettings stiJpegExportSettings = new StiJpegExportSettings
							{
								ImageResolution = 300
							};
							int currentPage = Enumerable.Count<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
							string text7 = text6 + "\\Doc-" + docId + "-" + now.ToString("yyyyMMddHHmmssfff") + ".pdf";
							string text8 = text6 + "\\Doc_Zip_" + docId;
							if (!System.IO.Directory.Exists(text8))
							{
								System.IO.Directory.CreateDirectory(text8);
								CRM.General.IO.Directory.SetFullControlForEveryOne(text8);
							}
							string file = text8 + "\\Doc_001.jpg";
							stiJpegExportSettings.PageRange = new StiPagesRange(currentPage);
							stiReport.ExportDocument(StiExportFormat.ImageJpeg, file, stiJpegExportSettings);
							string[] files = System.IO.Directory.GetFiles(text8);
							if (Enumerable.Any<string>((IEnumerable<string>)files))
							{
								PdfDocument pdfDocument = new PdfDocument();
								for (int i = 0; i < files.Length; i++)
								{
									PdfPage pdfPage = new PdfPage();
									StiPage stiPage = Enumerable.FirstOrDefault<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
									if (stiPage != null)
									{
										if (stiPage.Orientation == StiPageOrientation.Landscape)
										{
											pdfPage.Orientation = PageOrientation.Landscape;
										}
										try
										{
											PaperKind paperSize = stiPage.PaperSize;
											switch (paperSize - 8)
											{
											default:
												if ((int)paperSize != 66)
												{
													break;
												}
												pdfPage.Size = PageSize.A2;
												goto end_IL_1327;
											case 0:
												pdfPage.Size = PageSize.A3;
												goto end_IL_1327;
											case 1:
												pdfPage.Size = PageSize.A4;
												goto end_IL_1327;
											case 3:
												pdfPage.Size = PageSize.A5;
												goto end_IL_1327;
											case 4:
												pdfPage.Size = PageSize.B4;
												goto end_IL_1327;
											case 5:
												pdfPage.Size = PageSize.B5;
												goto end_IL_1327;
											case 2:
												break;
											}
											pdfPage.Size = PageSize.A4;
											end_IL_1327:;
										}
										catch (Exception e2)
										{
											ErrorSignal.FromCurrentContext().Raise(e2);
											pdfPage.Size = PageSize.A4;
										}
									}
									pdfDocument.Pages.Add(pdfPage);
									XGraphics xGraphics = XGraphics.FromPdfPage(pdfDocument.Pages[i]);
									XImage xImage = XImage.FromFile(files[i]);
									xGraphics.DrawImage(xImage, 0.0, 0.0);
									xImage.Dispose();
									xGraphics.Dispose();
								}
								pdfDocument.Save(text7);
								pdfDocument.Close();
							}
							try
							{
								DirectoryInfo directoryInfo = new DirectoryInfo(text8);
								FileInfo[] files2 = directoryInfo.GetFiles();
								for (int j = 0; j < files2.Length; j++)
								{
									files2[j].Delete();
								}
								DirectoryInfo[] directories = directoryInfo.GetDirectories();
								for (int j = 0; j < directories.Length; j++)
								{
									directories[j].Delete(recursive: true);
								}
								if (System.IO.Directory.Exists(text8))
								{
									System.IO.Directory.Delete(text8);
								}
							}
							catch (Exception e3)
							{
								ErrorSignal.FromCurrentContext().Raise(e3);
							}
							path = text7;
							string[] array = HttpContext.Current.Request.Url.AbsoluteUri.Split(new string[1] { "/api/" }, StringSplitOptions.None);
							string text9 = "";
							if (array != null)
							{
								string text10 = "/Download/Reports/Files/" + token2.userId + "/Doc-" + docId + "-" + now.ToString("yyyyMMddHHmmssfff") + ".pdf";
								text9 = ((array[0] != null && array[0] != "") ? (array[0] + text10) : "");
							}
							PrintLog.InsertPrintLog(docId, 11, 3);
							data = (System.IO.File.Exists(path) ? text9 : "");
							message = Messages.MobMsgSuccessAction;
							status = ServiceResultStatus.Success;
						}
						else
						{
							message = Messages.MobMsgErrorFileNotExist;
							data = null;
							status = ServiceResultStatus.Error;
						}
					}
					catch (Exception e4)
					{
						message = Messages.MobMsgErrorDoneOperation;
						data = null;
						status = ServiceResultStatus.Error;
						ErrorSignal.FromCurrentContext().Raise(e4);
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
		catch (Exception e5)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e5);
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

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> GetPdfDraft(int draftId, string printFormatFile, string CmpRemainAccLink, string CmpRemainAccLinkjs, int? ln = null, int? pfCId = null)
	{
		//IL_1572: Unknown result type (might be due to invalid IL or missing references)
		//IL_1577: Unknown result type (might be due to invalid IL or missing references)
		//IL_1579: Unknown result type (might be due to invalid IL or missing references)
		//IL_157c: Unknown result type (might be due to invalid IL or missing references)
		//IL_159a: Expected I4, but got Unknown
		//IL_126a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1288: Unknown result type (might be due to invalid IL or missing references)
		//IL_128f: Expected O, but got Unknown
		//IL_12ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_159a: Unknown result type (might be due to invalid IL or missing references)
		//IL_159e: Invalid comparison between Unknown and I4
		//IL_0ebc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1167: Unknown result type (might be due to invalid IL or missing references)
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
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
					try
					{
						cRMEntities = new CRMEntities();
						cRMSpEntities = new CRMSpEntities();
						StiReport stiReport = new StiReport();
						if (draftId > 0)
						{
							cRMSpEntities.WSspDocSetToIsFix(draftId);
							string manualIssuing = Labels.ManualIssuing;
							string systemIssuing = Labels.SystemIssuing;
							string text = HttpContext.Current.Server.MapPath("~/Areas/Reports/ReportDatasets/");
							string text2 = HttpContext.Current.Server.MapPath("~/Areas/Reports/ReportFiles/");
							string text3 = "";
							Mobile.Models.ReportModel.DraftPrintRpt.Parameters parameters = new Mobile.Models.ReportModel.DraftPrintRpt.Parameters();
							int userId = token2.userId;
							DateTime now = DateTime.Now;
							string rptDate = now.ToString("yyyy/MM/dd");
							string rptDay = now.ToString("dddd");
							Reports reports = new Reports();
							parameters.SysSetting = reports.GetSysSetting();
							parameters.NotUsed_ListLinkAccData = new List<DocLinkAccDataViewModel>();
							MobspSelectCrmsysSetting_Result mobspSelectCrmsysSetting_Result = SysSeting.Get();
							int result3 = 0;
							if (mobspSelectCrmsysSetting_Result != null)
							{
								int.TryParse(mobspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result3);
							}
							List<CRMspSelectLinkAccSettingDBIsActive_Result> list = new List<CRMspSelectLinkAccSettingDBIsActive_Result>();
							if (result3 == 1)
							{
								list = OtherSystems.GetLinkAccSettingDBList(1);
							}
							parameters.PrintDraft = Enumerable.FirstOrDefault<WSspRpt_PrintDoc_Result>((IEnumerable<WSspRpt_PrintDoc_Result>)Enumerable.ToList<WSspRpt_PrintDoc_Result>((IEnumerable<WSspRpt_PrintDoc_Result>)cRMSpEntities.WSspRpt_PrintDoc(draftId, num, result2, manualIssuing, systemIssuing, userId, rptDate, rptDay)));
							if (parameters.PrintDraft != null && num != 1065)
							{
								if (!string.IsNullOrEmpty(parameters.PrintDraft.DocDate))
								{
									parameters.PrintDraft.DocDate = PersianDate.GetShamsi2Miladi(parameters.PrintDraft.DocDate.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(parameters.PrintDraft.RegisterDatePersian))
								{
									parameters.PrintDraft.RegisterDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintDraft.RegisterDatePersian.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(parameters.PrintDraft.FirstRegisterDatePersian))
								{
									parameters.PrintDraft.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintDraft.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(parameters.PrintDraft.ordDeliveryDate))
								{
									parameters.PrintDraft.ordDeliveryDate = PersianDate.GetShamsi2Miladi(parameters.PrintDraft.ordDeliveryDate.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(parameters.PrintDraft.ordDeliveryEndDate))
								{
									parameters.PrintDraft.ordDeliveryEndDate = PersianDate.GetShamsi2Miladi(parameters.PrintDraft.ordDeliveryEndDate.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(parameters.PrintDraft.bordDeliveryDatePersian))
								{
									parameters.PrintDraft.bordDeliveryDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintDraft.bordDeliveryDatePersian.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(parameters.PrintDraft.bordSupplierDeliveryDatePersian))
								{
									parameters.PrintDraft.bordSupplierDeliveryDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintDraft.bordSupplierDeliveryDatePersian.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(parameters.PrintDraft.bordFinalDeliveryDatePersian))
								{
									parameters.PrintDraft.bordFinalDeliveryDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintDraft.bordFinalDeliveryDatePersian.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(parameters.PrintDraft.VerifiedRegisterDatePersian))
								{
									parameters.PrintDraft.VerifiedRegisterDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintDraft.VerifiedRegisterDatePersian.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(parameters.PrintDraft.pordDate))
								{
									parameters.PrintDraft.pordDate = PersianDate.GetShamsi2Miladi(parameters.PrintDraft.pordDate.Replace("/", "")).Replace("/", "");
								}
							}
							parameters.NotUsed_ListDraftItems = Enumerable.ToList<WSspRpt_PrintDocItems_Result>((IEnumerable<WSspRpt_PrintDocItems_Result>)cRMSpEntities.WSspRpt_PrintDocItems(draftId, num, result2));
							List<WSspRpt_PrintDocItemSerials_Result> list2 = new List<WSspRpt_PrintDocItemSerials_Result>();
							foreach (WSspRpt_PrintDocItems_Result notUsed_ListDraftItem in parameters.NotUsed_ListDraftItems)
							{
								List<WSspRpt_PrintDocItemSerials_Result> collection = Enumerable.ToList<WSspRpt_PrintDocItemSerials_Result>((IEnumerable<WSspRpt_PrintDocItemSerials_Result>)cRMSpEntities.WSspRpt_PrintDocItemSerials(notUsed_ListDraftItem.DocItemID, num, result2));
								list2.AddRange(collection);
							}
							foreach (WSspRpt_PrintDocItemSerials_Result item in list2)
							{
								if (num != 1065)
								{
									if (!string.IsNullOrEmpty(item.RegisterDatePersian))
									{
										item.RegisterDatePersian = PersianDate.GetShamsi2Miladi(item.RegisterDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item.FirstRegisterDatePersian))
									{
										item.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(item.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
									}
								}
							}
							parameters.NotUsed_ListDraftItemSerials = list2;
							parameters.ListDyPrintCmpForm = new List<CRMspDyPrintCmpForm_Result>();
							parameters.ListDyPrintPrsForm = new List<CRMspDyPrintPrsForm_Result>();
							parameters.ListDyPrintPrjForm = new List<CRMspDyPrintPrjForm_Result>();
							parameters.ListDyPrintDocForm = new List<CRMspDyPrintDocForm_Result>();
							parameters.ListPrintProjectInformationTree = new List<CRMspPrintProjectInformationTree_Result>();
							if (parameters.PrintDraft != null)
							{
								if (parameters.PrintDraft.CompanyId.HasValue)
								{
									parameters.ListDyPrintCmpForm = Enumerable.ToList<CRMspDyPrintCmpForm_Result>((IEnumerable<CRMspDyPrintCmpForm_Result>)cRMSpEntities.CRMspDyPrintCmpForm(parameters.PrintDraft.CompanyId, num, result2, token2.userId, 0));
								}
								if (parameters.PrintDraft.CompanyPersonId.HasValue)
								{
									parameters.ListDyPrintPrsForm = Enumerable.ToList<CRMspDyPrintPrsForm_Result>((IEnumerable<CRMspDyPrintPrsForm_Result>)cRMSpEntities.CRMspDyPrintPrsForm(parameters.PrintDraft.CompanyPersonId, num, result2, token2.userId, 0));
								}
								if (parameters.PrintDraft.ProjectId.HasValue)
								{
									parameters.ListDyPrintPrjForm = Enumerable.ToList<CRMspDyPrintPrjForm_Result>((IEnumerable<CRMspDyPrintPrjForm_Result>)cRMSpEntities.CRMspDyPrintPrjForm(parameters.PrintDraft.ProjectId, num, result2, token2.userId, 0));
									parameters.ListPrintProjectInformationTree = Enumerable.ToList<CRMspPrintProjectInformationTree_Result>((IEnumerable<CRMspPrintProjectInformationTree_Result>)cRMEntities.CRMspPrintProjectInformationTree(parameters.PrintDraft.ProjectId, num, result2));
								}
								parameters.ListDyPrintDocForm = Enumerable.ToList<CRMspDyPrintDocForm_Result>((IEnumerable<CRMspDyPrintDocForm_Result>)cRMSpEntities.CRMspDyPrintDocForm(parameters.PrintDraft.DocID, num, result2, token2.userId, 0));
							}
							parameters.NotUsed_ListPrintOrderVerificationRequestDetails = new List<WSspRpt_PrintVerificationRequestDetails_Result>();
							if (parameters.PrintDraft != null)
							{
								int result4 = 0;
								int.TryParse(parameters.PrintDraft.OrderId.ToString(), out result4);
								if (result4 > 0)
								{
									WSspSelectOrderById_Result wSspSelectOrderById_Result = Enumerable.FirstOrDefault<WSspSelectOrderById_Result>((IEnumerable<WSspSelectOrderById_Result>)cRMSpEntities.WSspSelectOrderById(result4, num, result2));
									if (wSspSelectOrderById_Result != null && wSspSelectOrderById_Result.ordVerificationWorkFlowId.HasValue)
									{
										parameters.NotUsed_ListPrintOrderVerificationRequestDetails = Enumerable.ToList<WSspRpt_PrintVerificationRequestDetails_Result>((IEnumerable<WSspRpt_PrintVerificationRequestDetails_Result>)cRMEntities.WSspRpt_PrintVerificationRequestDetails(wSspSelectOrderById_Result.OrderID, 20, wSspSelectOrderById_Result.ordVerificationWorkFlowId, num, result2));
										if (parameters.NotUsed_ListPrintOrderVerificationRequestDetails != null && Enumerable.Any<WSspRpt_PrintVerificationRequestDetails_Result>((IEnumerable<WSspRpt_PrintVerificationRequestDetails_Result>)parameters.NotUsed_ListPrintOrderVerificationRequestDetails))
										{
											foreach (WSspRpt_PrintVerificationRequestDetails_Result notUsed_ListPrintOrderVerificationRequestDetail in parameters.NotUsed_ListPrintOrderVerificationRequestDetails)
											{
												if (num != 1065)
												{
													if (!string.IsNullOrEmpty(notUsed_ListPrintOrderVerificationRequestDetail.VerifyDatePersian))
													{
														notUsed_ListPrintOrderVerificationRequestDetail.VerifyDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintOrderVerificationRequestDetail.VerifyDatePersian.Replace("/", "")).Replace("/", "");
													}
													if (!string.IsNullOrEmpty(notUsed_ListPrintOrderVerificationRequestDetail.FirstRegisterDatePersian))
													{
														notUsed_ListPrintOrderVerificationRequestDetail.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintOrderVerificationRequestDetail.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
													}
													if (!string.IsNullOrEmpty(notUsed_ListPrintOrderVerificationRequestDetail.RegisterDatePersian))
													{
														notUsed_ListPrintOrderVerificationRequestDetail.RegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintOrderVerificationRequestDetail.RegisterDatePersian.Replace("/", "")).Replace("/", "");
													}
													if (!string.IsNullOrEmpty(notUsed_ListPrintOrderVerificationRequestDetail.VerificationReqDatePersian))
													{
														notUsed_ListPrintOrderVerificationRequestDetail.VerificationReqDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintOrderVerificationRequestDetail.VerificationReqDatePersian.Replace("/", "")).Replace("/", "");
													}
													if (!string.IsNullOrEmpty(notUsed_ListPrintOrderVerificationRequestDetail.VerificationReqExpiredDatePersian))
													{
														notUsed_ListPrintOrderVerificationRequestDetail.VerificationReqExpiredDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintOrderVerificationRequestDetail.VerificationReqExpiredDatePersian.Replace("/", "")).Replace("/", "");
													}
												}
												if (notUsed_ListPrintOrderVerificationRequestDetail.VerifyUserSignature != null)
												{
													notUsed_ListPrintOrderVerificationRequestDetail.VerifyUserSignatureStr = Convert.ToBase64String(notUsed_ListPrintOrderVerificationRequestDetail.VerifyUserSignature);
												}
											}
										}
									}
								}
							}
							if (parameters.NotUsed_ListPrintOrderVerificationRequestDetails == null)
							{
								parameters.NotUsed_ListPrintOrderVerificationRequestDetails = new List<WSspRpt_PrintVerificationRequestDetails_Result>();
							}
							parameters.NotUsed_ListPrintDocVerificationRequestDetails = new List<WSspRpt_PrintDocVerificationRequestDetails_Result>();
							if (parameters.PrintDraft != null && parameters.PrintDraft.VerificationWorkFlowId.HasValue)
							{
								parameters.NotUsed_ListPrintDocVerificationRequestDetails = Enumerable.ToList<WSspRpt_PrintDocVerificationRequestDetails_Result>((IEnumerable<WSspRpt_PrintDocVerificationRequestDetails_Result>)cRMSpEntities.WSspRpt_PrintDocVerificationRequestDetails(parameters.PrintDraft.DocID, 60, parameters.PrintDraft.VerificationWorkFlowId, num, result2));
								if (parameters.NotUsed_ListPrintDocVerificationRequestDetails != null && Enumerable.Any<WSspRpt_PrintDocVerificationRequestDetails_Result>((IEnumerable<WSspRpt_PrintDocVerificationRequestDetails_Result>)parameters.NotUsed_ListPrintDocVerificationRequestDetails))
								{
									foreach (WSspRpt_PrintDocVerificationRequestDetails_Result notUsed_ListPrintDocVerificationRequestDetail in parameters.NotUsed_ListPrintDocVerificationRequestDetails)
									{
										if (num != 1065)
										{
											if (!string.IsNullOrEmpty(notUsed_ListPrintDocVerificationRequestDetail.VerifyDatePersian))
											{
												notUsed_ListPrintDocVerificationRequestDetail.VerifyDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintDocVerificationRequestDetail.VerifyDatePersian.Replace("/", "")).Replace("/", "");
											}
											if (!string.IsNullOrEmpty(notUsed_ListPrintDocVerificationRequestDetail.FirstRegisterDatePersian))
											{
												notUsed_ListPrintDocVerificationRequestDetail.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintDocVerificationRequestDetail.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
											}
											if (!string.IsNullOrEmpty(notUsed_ListPrintDocVerificationRequestDetail.RegisterDatePersian))
											{
												notUsed_ListPrintDocVerificationRequestDetail.RegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintDocVerificationRequestDetail.RegisterDatePersian.Replace("/", "")).Replace("/", "");
											}
											if (!string.IsNullOrEmpty(notUsed_ListPrintDocVerificationRequestDetail.VerificationReqDatePersian))
											{
												notUsed_ListPrintDocVerificationRequestDetail.VerificationReqDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintDocVerificationRequestDetail.VerificationReqDatePersian.Replace("/", "")).Replace("/", "");
											}
											if (!string.IsNullOrEmpty(notUsed_ListPrintDocVerificationRequestDetail.VerificationReqExpiredDatePersian))
											{
												notUsed_ListPrintDocVerificationRequestDetail.VerificationReqExpiredDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintDocVerificationRequestDetail.VerificationReqExpiredDatePersian.Replace("/", "")).Replace("/", "");
											}
										}
										if (notUsed_ListPrintDocVerificationRequestDetail.VerifyUserSignature != null)
										{
											notUsed_ListPrintDocVerificationRequestDetail.VerifyUserSignatureStr = Convert.ToBase64String(notUsed_ListPrintDocVerificationRequestDetail.VerifyUserSignature);
										}
									}
								}
							}
							if (parameters.NotUsed_ListPrintDocVerificationRequestDetails == null)
							{
								parameters.NotUsed_ListPrintDocVerificationRequestDetails = new List<WSspRpt_PrintDocVerificationRequestDetails_Result>();
							}
							parameters.NotUsed_ListDraftItemPrdPicture = new List<WSspRpt_PrintDocItemPrdPicture_Result>();
							if (parameters.PrintDraft != null)
							{
								parameters.NotUsed_ListDraftItemPrdPicture = Enumerable.ToList<WSspRpt_PrintDocItemPrdPicture_Result>((IEnumerable<WSspRpt_PrintDocItemPrdPicture_Result>)cRMSpEntities.WSspRpt_PrintDocItemPrdPicture(parameters.PrintDraft.DocID, num, result2));
							}
							if (parameters.NotUsed_ListDraftItemPrdPicture == null)
							{
								parameters.NotUsed_ListDraftItemPrdPicture = new List<WSspRpt_PrintDocItemPrdPicture_Result>();
							}
							byte[] coLoGo = SysSeting.Get().CoLoGo;
							if (coLoGo != null && coLoGo.Length != 0)
							{
								parameters.CoLogo = Convert.ToBase64String(coLoGo);
							}
							parameters.SignatureFirstRegisterUser = null;
							parameters.SignatureLastEditUser = null;
							parameters.SignatureVerifierUser = null;
							WSspRpt_PrintDoc_Result printDraft = parameters.PrintDraft;
							if (printDraft != null)
							{
								CRMspSelectUserSignatureByUserId_Result cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)cRMEntities.CRMspSelectUserSignatureByUserId(printDraft.FirstRegisterUserId));
								if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
								{
									parameters.SignatureFirstRegisterUser = cRMspSelectUserSignatureByUserId_Result.Signature;
								}
								cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)cRMEntities.CRMspSelectUserSignatureByUserId(printDraft.UserId));
								if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
								{
									parameters.SignatureLastEditUser = cRMspSelectUserSignatureByUserId_Result.Signature;
								}
								if (printDraft.VerifierId.HasValue)
								{
									cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)cRMEntities.CRMspSelectUserSignatureByUserId(printDraft.VerifierId));
									if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
									{
										parameters.SignatureVerifierUser = cRMspSelectUserSignatureByUserId_Result.Signature;
									}
								}
							}
							parameters.NotUsed_ListDraftItemsFromQuantity = new List<WSspRpt_PrintDocItemsFromQuantity_Result>();
							parameters.NotUsed_ListDraftItemsFromQuantity = Enumerable.ToList<WSspRpt_PrintDocItemsFromQuantity_Result>((IEnumerable<WSspRpt_PrintDocItemsFromQuantity_Result>)cRMSpEntities.WSspRpt_PrintDocItemsFromQuantity(draftId, num, result2));
							if (parameters.NotUsed_ListDraftItemsFromQuantity == null)
							{
								parameters.NotUsed_ListDraftItemsFromQuantity = new List<WSspRpt_PrintDocItemsFromQuantity_Result>();
							}
							string text4 = "";
							if (parameters.PrintDraft != null)
							{
								text4 = parameters.PrintDraft.DocLinkAccData ?? "";
							}
							if (!string.IsNullOrWhiteSpace(text4))
							{
								List<DocLinkAccDataViewModel> list3 = new JavaScriptSerializer().Deserialize<List<DocLinkAccDataViewModel>>(text4);
								if (list3 != null && Enumerable.Any<DocLinkAccDataViewModel>((IEnumerable<DocLinkAccDataViewModel>)list3))
								{
									foreach (DocLinkAccDataViewModel vmLkAcc in list3)
									{
										vmLkAcc.DocId = draftId;
										CRMspSelectLinkAccSettingDBIsActive_Result cRMspSelectLinkAccSettingDBIsActive_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDBIsActive_Result>((IEnumerable<CRMspSelectLinkAccSettingDBIsActive_Result>)list, (Func<CRMspSelectLinkAccSettingDBIsActive_Result, bool>)((CRMspSelectLinkAccSettingDBIsActive_Result m) => m.LinkAccSettingDBId == vmLkAcc.DBId.GetValueOrDefault()));
										if (cRMspSelectLinkAccSettingDBIsActive_Result != null)
										{
											vmLkAcc.DbName = cRMspSelectLinkAccSettingDBIsActive_Result.LinkAccSettingDbName ?? "";
											vmLkAcc.DbTitle = cRMspSelectLinkAccSettingDBIsActive_Result.LinkAccSettingDbTitle ?? "";
										}
									}
									parameters.NotUsed_ListLinkAccData.AddRange(list3);
								}
							}
							if (parameters.NotUsed_ListLinkAccData == null)
							{
								parameters.NotUsed_ListLinkAccData = new List<DocLinkAccDataViewModel>();
							}
							parameters.CmpLinkAccAllPayRemain = default(decimal);
							int cmpId = 0;
							decimal result5 = default(decimal);
							if (result3 > 0)
							{
								string text5 = "";
								if (parameters.PrintDraft.CompanyId.GetValueOrDefault() == 0)
								{
									MobspSelectDocById_Result mobspSelectDocById_Result = Enumerable.FirstOrDefault<MobspSelectDocById_Result>((IEnumerable<MobspSelectDocById_Result>)cRMSpEntities.MobspSelectDocById(draftId, num, result2));
									if (mobspSelectDocById_Result != null)
									{
										cmpId = mobspSelectDocById_Result.CompanyId.GetValueOrDefault();
									}
								}
								else
								{
									cmpId = parameters.PrintDraft.CompanyId.GetValueOrDefault();
								}
								switch (result3)
								{
								case 1:
								{
									decimal num2 = default(decimal);
									if (list == null || !Enumerable.Any<CRMspSelectLinkAccSettingDBIsActive_Result>((IEnumerable<CRMspSelectLinkAccSettingDBIsActive_Result>)list))
									{
										break;
									}
									foreach (CRMspSelectLinkAccSettingDBIsActive_Result item2 in list)
									{
										int result6 = 0;
										int.TryParse(item2.LinkAccSettingDBId.ToString(), out result6);
										if (result6 != 0)
										{
											CmpAccountingLinkAccDataViewModel cmpAccountingLinkAccDataViewModel = new CmpAccountingLinkAccDataViewModel
											{
												DBId = result6,
												DbName = item2.LinkAccSettingDbName,
												DbTitle = item2.LinkAccSettingDbTitle
											};
											num2 = default(decimal);
											SepGetCmpAccountingDetail(cmpId, ref num2, result6);
											text5 = $"{num2:N2}";
											cmpAccountingLinkAccDataViewModel.AllPayRemain = decimal.Parse(text5 ?? "0");
											parameters.NotUsed_ListCmpAllPayRemainLinkAccData.Add(cmpAccountingLinkAccDataViewModel);
										}
									}
									break;
								}
								case 4:
									if (!string.IsNullOrWhiteSpace(CmpRemainAccLink ?? ""))
									{
										text5 = CmpRemainAccLink ?? "";
									}
									if (string.IsNullOrWhiteSpace(CmpRemainAccLinkjs ?? ""))
									{
										break;
									}
									try
									{
										parameters.NotUsed_ListCmpAllPayRemainLinkAccData = new JavaScriptSerializer().Deserialize<List<CmpAccountingLinkAccDataViewModel>>(CmpRemainAccLinkjs ?? "");
										if (parameters.NotUsed_ListCmpAllPayRemainLinkAccData == null)
										{
											parameters.NotUsed_ListCmpAllPayRemainLinkAccData = new List<CmpAccountingLinkAccDataViewModel>();
										}
									}
									catch (Exception e)
									{
										ErrorSignal.FromCurrentContext().Raise(e);
									}
									break;
								default:
									if (!string.IsNullOrWhiteSpace(CmpRemainAccLink))
									{
										text5 = CmpRemainAccLink;
									}
									break;
								}
								if (text5 == Labels.FOMsgErrorTitle)
								{
									text5 = "0.00";
								}
								if (!string.IsNullOrWhiteSpace(text5))
								{
									decimal.TryParse(text5, out result5);
								}
							}
							parameters.CmpLinkAccAllPayRemain = result5;
							int printFormatCId = PrintFormat.GetPrintFormatCId(0, text3);
							if (printFormatCId != 0 && !string.IsNullOrWhiteSpace(text2))
							{
								if (!text2.EndsWith("\\"))
								{
									text2 += "\\";
								}
								text2 = text2 + printFormatCId + "\\";
							}
							if (printFormatFile != null)
							{
								text3 = printFormatFile;
							}
							if (string.IsNullOrEmpty(text3))
							{
								text3 = "DraftPrint.mrt";
							}
							if (!System.IO.File.Exists(text2 + text3))
							{
								text3 = "DraftPrint.mrt";
							}
							XmlSerializer val = new XmlSerializer(typeof(Mobile.Models.ReportModel.DraftPrintRpt.Parameters));
							StringWriter stringWriter = new StringWriter();
							XmlWriter val2 = XmlWriter.Create((TextWriter)stringWriter);
							val.Serialize(val2, (object)parameters);
							DataSet val3 = new DataSet();
							val3.ReadXmlSchema(text + "DraftPrint.xsd");
							XElement val4 = XElement.Parse(stringWriter.ToString());
							val3.ReadXml(((XNode)val4).CreateReader((ReaderOptions)0));
							stiReport.Load(text2 + text3);
							string text6 = "Integrated Security=False;Data Source={DBServer};Initial Catalog={DBName};Password={DBPass};User ID={DBUser}";
							text6 = text6.Replace("{DBServer}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBServer"]));
							text6 = text6.Replace("{DBName}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBName"]));
							text6 = text6.Replace("{DBUser}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBUser"]));
							text6 = text6.Replace("{DBPass}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBPass"]));
							((CollectionBase)stiReport.Dictionary.Databases).Clear();
							stiReport.Dictionary.Databases.Add(new StiSqlDatabase("CRMIdealExtra", text6));
							stiReport.Compile();
							stiReport.RegData(val3);
							stiReport.Render();
							string text7 = HttpContext.Current.Server.MapPath("~/Download") + "\\Reports\\Files\\" + token2.userId;
							if (!System.IO.Directory.Exists(text7))
							{
								System.IO.Directory.CreateDirectory(text7);
								CRM.General.IO.Directory.SetFullControlForEveryOne(text7);
							}
							string path = text7 + "\\Draft-" + draftId + "-" + now.ToString("yyyyMMddHHmmssfff") + ".pdf";
							try
							{
								System.IO.File.Delete(path);
							}
							catch (Exception e2)
							{
								ErrorSignal.FromCurrentContext().Raise(e2);
								message = "خطا در یافت";
								data = null;
								status = ServiceResultStatus.Error;
							}
							StiJpegExportSettings stiJpegExportSettings = new StiJpegExportSettings
							{
								ImageResolution = 300
							};
							int currentPage = Enumerable.Count<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
							string text8 = text7 + "\\Draft-" + draftId + "-" + now.ToString("yyyyMMddHHmmssfff") + ".pdf";
							string text9 = text7 + "\\Draft_Zip_" + draftId;
							if (!System.IO.Directory.Exists(text9))
							{
								System.IO.Directory.CreateDirectory(text9);
								CRM.General.IO.Directory.SetFullControlForEveryOne(text9);
							}
							string file = text9 + "\\Draft_001.jpg";
							stiJpegExportSettings.PageRange = new StiPagesRange(currentPage);
							stiReport.ExportDocument(StiExportFormat.ImageJpeg, file, stiJpegExportSettings);
							string[] files = System.IO.Directory.GetFiles(text9);
							if (Enumerable.Any<string>((IEnumerable<string>)files))
							{
								PdfDocument pdfDocument = new PdfDocument();
								for (int i = 0; i < files.Length; i++)
								{
									PdfPage pdfPage = new PdfPage();
									StiPage stiPage = Enumerable.FirstOrDefault<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
									if (stiPage != null)
									{
										if (stiPage.Orientation == StiPageOrientation.Landscape)
										{
											pdfPage.Orientation = PageOrientation.Landscape;
										}
										try
										{
											PaperKind paperSize = stiPage.PaperSize;
											switch (paperSize - 8)
											{
											default:
												if ((int)paperSize != 66)
												{
													break;
												}
												pdfPage.Size = PageSize.A2;
												goto end_IL_1570;
											case 0:
												pdfPage.Size = PageSize.A3;
												goto end_IL_1570;
											case 1:
												pdfPage.Size = PageSize.A4;
												goto end_IL_1570;
											case 3:
												pdfPage.Size = PageSize.A5;
												goto end_IL_1570;
											case 4:
												pdfPage.Size = PageSize.B4;
												goto end_IL_1570;
											case 5:
												pdfPage.Size = PageSize.B5;
												goto end_IL_1570;
											case 2:
												break;
											}
											pdfPage.Size = PageSize.A4;
											end_IL_1570:;
										}
										catch (Exception e3)
										{
											ErrorSignal.FromCurrentContext().Raise(e3);
											pdfPage.Size = PageSize.A4;
										}
									}
									pdfDocument.Pages.Add(pdfPage);
									XGraphics xGraphics = XGraphics.FromPdfPage(pdfDocument.Pages[i]);
									XImage xImage = XImage.FromFile(files[i]);
									xGraphics.DrawImage(xImage, 0.0, 0.0);
									xImage.Dispose();
									xGraphics.Dispose();
								}
								pdfDocument.Save(text8);
								pdfDocument.Close();
							}
							try
							{
								DirectoryInfo directoryInfo = new DirectoryInfo(text9);
								FileInfo[] files2 = directoryInfo.GetFiles();
								for (int j = 0; j < files2.Length; j++)
								{
									files2[j].Delete();
								}
								DirectoryInfo[] directories = directoryInfo.GetDirectories();
								for (int j = 0; j < directories.Length; j++)
								{
									directories[j].Delete(recursive: true);
								}
								if (System.IO.Directory.Exists(text9))
								{
									System.IO.Directory.Delete(text9);
								}
							}
							catch (Exception e4)
							{
								ErrorSignal.FromCurrentContext().Raise(e4);
							}
							path = text8;
							string[] array = HttpContext.Current.Request.Url.AbsoluteUri.Split(new string[1] { "/api/" }, StringSplitOptions.None);
							string text10 = "";
							if (array != null)
							{
								string text11 = "/Download/Reports/Files/" + token2.userId + "/Draft-" + draftId + "-" + now.ToString("yyyyMMddHHmmssfff") + ".pdf";
								text10 = ((array[0] != null && array[0] != "") ? (array[0] + text11) : "");
							}
							PrintLog.InsertPrintLog(draftId, 12, 3);
							data = (System.IO.File.Exists(path) ? text10 : "");
							message = Messages.MobMsgSuccessAction;
							status = ServiceResultStatus.Success;
						}
						else
						{
							message = Messages.MobMsgErrorFileNotExist;
							data = null;
							status = ServiceResultStatus.Error;
						}
					}
					catch (Exception e5)
					{
						message = Messages.MobMsgErrorDoneOperation;
						data = null;
						status = ServiceResultStatus.Error;
						ErrorSignal.FromCurrentContext().Raise(e5);
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
		catch (Exception e6)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e6);
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

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> GetPdfFund(FundPrintViewModel model)
	{
		//IL_0875: Unknown result type (might be due to invalid IL or missing references)
		//IL_087a: Unknown result type (might be due to invalid IL or missing references)
		//IL_087c: Unknown result type (might be due to invalid IL or missing references)
		//IL_087f: Unknown result type (might be due to invalid IL or missing references)
		//IL_089d: Expected I4, but got Unknown
		//IL_089d: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a1: Invalid comparison between Unknown and I4
		//IL_05b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_05de: Expected O, but got Unknown
		//IL_0609: Unknown result type (might be due to invalid IL or missing references)
		int result = 1065;
		if (model.langId.HasValue)
		{
			int.TryParse(model.langId.ToString(), out result);
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
					try
					{
						cRMEntities = new CRMEntities();
						cRMSpEntities = new CRMSpEntities();
						StiReport stiReport = new StiReport();
						string text = HttpContext.Current.Server.MapPath("~/Areas/Reports/ReportDatasets/");
						string text2 = HttpContext.Current.Server.MapPath("~/Areas/Reports/ReportFiles/");
						string text3 = model.fileName;
						Mobile.Models.ReportModel.PrintFundRpt.Parameters parameters = new Mobile.Models.ReportModel.PrintFundRpt.Parameters();
						int userId = token2.userId;
						DateTime now = DateTime.Now;
						string text4 = now.ToString("yyyy/MM/dd");
						string text5 = now.ToString("dddd");
						Reports reports = new Reports();
						parameters.SysSetting = reports.GetSysSetting();
						byte[] coLoGo = SysSeting.Get().CoLoGo;
						if (coLoGo != null && coLoGo.Length != 0)
						{
							parameters.CoLogo = Convert.ToBase64String(coLoGo);
						}
						parameters.ReportDateTime = now;
						parameters.ReporterUserName = UserLogin.CurrentUser.FullName;
						DateTime value = DateTime.Now;
						DateTime value2 = DateTime.Now;
						if (!string.IsNullOrEmpty(model.fDate))
						{
							model.fDate = model.fDate.Replace("/", "").Replace("-", "").Replace("\\", "")
								.Replace(" ", "")
								.Replace("_", "");
							value = num switch
							{
								1065 => DateTime.Parse(PersianDate.GetFormatetdDate(model.fDate) + " 00:00:00"), 
								1025 => DateTime.Parse(PersianDate.GetFormatetdDate(model.fDate) + " 00:00:00", new CultureInfo("ar-SA"), DateTimeStyles.None), 
								_ => DateTime.Parse(PersianDate.GetFormatetdDate(model.fDate) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None), 
							};
						}
						if (!string.IsNullOrEmpty(model.tDate))
						{
							model.tDate = model.tDate.Replace("/", "").Replace("-", "").Replace("\\", "")
								.Replace(" ", "")
								.Replace("_", "");
							value2 = num switch
							{
								1065 => DateTime.Parse(PersianDate.GetFormatetdDate(model.tDate) + " 23:59:59"), 
								1025 => DateTime.Parse(PersianDate.GetFormatetdDate(model.tDate) + " 23:59:59", new CultureInfo("ar-SA"), DateTimeStyles.None), 
								_ => DateTime.Parse(PersianDate.GetFormatetdDate(model.tDate) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None), 
							};
						}
						parameters.ReportDateTime.ToString("yyyy/MM/dd");
						parameters.NotUsed_ListPrintFund = new List<CRMspPrintFund_Result>();
						CRMSpEntities cRMSpEntities2 = cRMSpEntities;
						DateTime? dateTime = value;
						DateTime? dateTime2 = value2;
						List<CRMspPrintFund_Result> list = Enumerable.ToList<CRMspPrintFund_Result>((IEnumerable<CRMspPrintFund_Result>)cRMSpEntities2.CRMspPrintFund(model.crmUserId, dateTime, dateTime2, userId, text4, text5, languageID: num, defaultLanguageID: result2, fundGroupId: model.fundGroupId));
						if (list != null && Enumerable.Any<CRMspPrintFund_Result>((IEnumerable<CRMspPrintFund_Result>)list))
						{
							foreach (CRMspPrintFund_Result item in list)
							{
								if (num != 1065)
								{
									if (!string.IsNullOrEmpty(item.FirstRegisterDatePersian))
									{
										item.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(item.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item.RegisterDatePersian))
									{
										item.RegisterDatePersian = PersianDate.GetShamsi2Miladi(item.RegisterDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item.FundDatePersian))
									{
										item.FundDatePersian = PersianDate.GetShamsi2Miladi(item.FundDatePersian.Replace("/", "")).Replace("/", "");
									}
								}
							}
						}
						parameters.NotUsed_ListPrintFund = list;
						int printFormatCId = PrintFormat.GetPrintFormatCId(0, text3);
						if (printFormatCId != 0 && !string.IsNullOrWhiteSpace(text2))
						{
							if (!text2.EndsWith("\\"))
							{
								text2 += "\\";
							}
							text2 = text2 + printFormatCId + "\\";
						}
						if (string.IsNullOrEmpty(text3))
						{
							text3 = "PrintFund.mrt";
						}
						if (!System.IO.File.Exists(text2 + text3))
						{
							text3 = "PrintFund.mrt";
						}
						XmlSerializer val = new XmlSerializer(typeof(Mobile.Models.ReportModel.PrintFundRpt.Parameters));
						StringWriter stringWriter = new StringWriter();
						XmlWriter val2 = XmlWriter.Create((TextWriter)stringWriter);
						val.Serialize(val2, (object)parameters);
						DataSet val3 = new DataSet();
						val3.ReadXmlSchema(text + "PrintFund.xsd");
						XElement val4 = XElement.Parse(stringWriter.ToString());
						val3.ReadXml(((XNode)val4).CreateReader((ReaderOptions)0));
						stiReport.Load(text2 + text3);
						string text6 = "Integrated Security=False;Data Source={DBServer};Initial Catalog={DBName};Password={DBPass};User ID={DBUser}";
						text6 = text6.Replace("{DBServer}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBServer"]));
						text6 = text6.Replace("{DBName}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBName"]));
						text6 = text6.Replace("{DBUser}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBUser"]));
						text6 = text6.Replace("{DBPass}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBPass"]));
						((CollectionBase)stiReport.Dictionary.Databases).Clear();
						stiReport.Dictionary.Databases.Add(new StiSqlDatabase("CRMIdealExtra", text6));
						stiReport.Compile();
						stiReport.RegData(val3);
						stiReport.Render();
						string text7 = DateTime.Now.ToString("yyyyMMddHHmmss");
						string text8 = HttpContext.Current.Server.MapPath("~/Download") + "\\Reports\\Files\\" + token2.userId;
						if (!System.IO.Directory.Exists(text8))
						{
							System.IO.Directory.CreateDirectory(text8);
							CRM.General.IO.Directory.SetFullControlForEveryOne(text8);
						}
						string path = text8 + "\\Fund-" + text7 + ".pdf";
						try
						{
							System.IO.File.Delete(path);
						}
						catch (Exception e)
						{
							ErrorSignal.FromCurrentContext().Raise(e);
							message = "خطا در یافت";
							data = null;
							status = ServiceResultStatus.Error;
						}
						StiJpegExportSettings stiJpegExportSettings = new StiJpegExportSettings
						{
							ImageResolution = 300
						};
						int currentPage = Enumerable.Count<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
						string text9 = text8 + "\\Fund-" + text7 + ".pdf";
						string text10 = text8 + "\\Fund_Zip-" + text7;
						if (!System.IO.Directory.Exists(text10))
						{
							System.IO.Directory.CreateDirectory(text10);
							CRM.General.IO.Directory.SetFullControlForEveryOne(text10);
						}
						string file = text10 + "\\Fund_001.jpg";
						stiJpegExportSettings.PageRange = new StiPagesRange(currentPage);
						stiReport.ExportDocument(StiExportFormat.ImageJpeg, file, stiJpegExportSettings);
						string[] files = System.IO.Directory.GetFiles(text10);
						if (Enumerable.Any<string>((IEnumerable<string>)files))
						{
							PdfDocument pdfDocument = new PdfDocument();
							for (int i = 0; i < files.Length; i++)
							{
								PdfPage pdfPage = new PdfPage();
								StiPage stiPage = Enumerable.FirstOrDefault<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
								if (stiPage != null)
								{
									if (stiPage.Orientation == StiPageOrientation.Landscape)
									{
										pdfPage.Orientation = PageOrientation.Landscape;
									}
									try
									{
										PaperKind paperSize = stiPage.PaperSize;
										switch (paperSize - 8)
										{
										default:
											if ((int)paperSize != 66)
											{
												break;
											}
											pdfPage.Size = PageSize.A2;
											goto end_IL_0873;
										case 0:
											pdfPage.Size = PageSize.A3;
											goto end_IL_0873;
										case 1:
											pdfPage.Size = PageSize.A4;
											goto end_IL_0873;
										case 3:
											pdfPage.Size = PageSize.A5;
											goto end_IL_0873;
										case 4:
											pdfPage.Size = PageSize.B4;
											goto end_IL_0873;
										case 5:
											pdfPage.Size = PageSize.B5;
											goto end_IL_0873;
										case 2:
											break;
										}
										pdfPage.Size = PageSize.A4;
										end_IL_0873:;
									}
									catch (Exception e2)
									{
										ErrorSignal.FromCurrentContext().Raise(e2);
										pdfPage.Size = PageSize.A4;
									}
								}
								pdfDocument.Pages.Add(pdfPage);
								XGraphics xGraphics = XGraphics.FromPdfPage(pdfDocument.Pages[i]);
								XImage xImage = XImage.FromFile(files[i]);
								xGraphics.DrawImage(xImage, 0.0, 0.0);
								xImage.Dispose();
								xGraphics.Dispose();
							}
							pdfDocument.Save(text9);
							pdfDocument.Close();
						}
						try
						{
							DirectoryInfo directoryInfo = new DirectoryInfo(text10);
							FileInfo[] files2 = directoryInfo.GetFiles();
							for (int j = 0; j < files2.Length; j++)
							{
								files2[j].Delete();
							}
							DirectoryInfo[] directories = directoryInfo.GetDirectories();
							for (int j = 0; j < directories.Length; j++)
							{
								directories[j].Delete(recursive: true);
							}
							if (System.IO.Directory.Exists(text10))
							{
								System.IO.Directory.Delete(text10);
							}
						}
						catch (Exception e3)
						{
							ErrorSignal.FromCurrentContext().Raise(e3);
						}
						path = text9;
						string[] array = HttpContext.Current.Request.Url.AbsoluteUri.Split(new string[1] { "/api/" }, StringSplitOptions.None);
						string text11 = "";
						if (array != null)
						{
							string text12 = "/Download/Reports/Files/" + token2.userId + "/Fund-" + text7 + ".pdf";
							text11 = ((array[0] != null && array[0] != "") ? (array[0] + text12) : "");
						}
						data = (System.IO.File.Exists(path) ? text11 : "");
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					catch (Exception e4)
					{
						message = Messages.MobMsgErrorDoneOperation;
						data = null;
						status = ServiceResultStatus.Error;
						ErrorSignal.FromCurrentContext().Raise(e4);
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
		catch (Exception e5)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e5);
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

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> GetWarehouseMovement(int docId, string fileName, int pfCId = 0, int? ln = null)
	{
		//IL_10bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_10c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_10c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_10c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_10e5: Expected I4, but got Unknown
		//IL_10e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_10e9: Invalid comparison between Unknown and I4
		//IL_0c4a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d38: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d56: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d5d: Expected O, but got Unknown
		//IL_0d88: Unknown result type (might be due to invalid IL or missing references)
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
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
					try
					{
						cRMEntities = new CRMEntities();
						cRMSpEntities = new CRMSpEntities();
						if (docId > 0)
						{
							cRMSpEntities.WSspDocSetToIsFix(docId);
							string manualIssuing = Labels.ManualIssuing;
							string systemIssuing = Labels.SystemIssuing;
							string text = HttpContext.Current.Server.MapPath("~/Areas/Reports/ReportDatasets/");
							string text2 = HttpContext.Current.Server.MapPath("~/Areas/Reports/ReportFiles/");
							Mobile.Models.ReportModel.WarehouseMovementPrintRpt.Parameters parameters = new Mobile.Models.ReportModel.WarehouseMovementPrintRpt.Parameters();
							Reports reports = new Reports();
							parameters.SysSetting = reports.GetSysSetting();
							parameters.ReportDateTime = DateTime.Now;
							parameters.ReporterUserName = UserLogin.CurrentUser.FullName;
							int userId = token2.userId;
							DateTime now = DateTime.Now;
							string rptDate = now.ToString("yyyy/MM/dd");
							string rptDay = now.ToString("dddd");
							parameters.NotUsed_ListLinkAccData = new List<DocLinkAccDataViewModel>();
							MobspSelectCrmsysSetting_Result mobspSelectCrmsysSetting_Result = SysSeting.Get();
							int result3 = 0;
							if (mobspSelectCrmsysSetting_Result != null)
							{
								int.TryParse(mobspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result3);
							}
							List<CRMspSelectLinkAccSettingDBIsActive_Result> list = new List<CRMspSelectLinkAccSettingDBIsActive_Result>();
							if (result3 == 1)
							{
								list = OtherSystems.GetLinkAccSettingDBList(1);
							}
							parameters.PrintDoc = Enumerable.FirstOrDefault<WSspRpt_PrintDoc_Result>((IEnumerable<WSspRpt_PrintDoc_Result>)cRMSpEntities.WSspRpt_PrintDoc(docId, num, result2, manualIssuing, systemIssuing, userId, rptDate, rptDay));
							if (num != 1065)
							{
								if (!string.IsNullOrEmpty(parameters.PrintDoc.DocDate))
								{
									parameters.PrintDoc.DocDate = PersianDate.GetShamsi2Miladi(parameters.PrintDoc.DocDate.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(parameters.PrintDoc.RegisterDatePersian))
								{
									parameters.PrintDoc.RegisterDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintDoc.RegisterDatePersian.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(parameters.PrintDoc.FirstRegisterDatePersian))
								{
									parameters.PrintDoc.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintDoc.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(parameters.PrintDoc.ordDeliveryDate))
								{
									parameters.PrintDoc.ordDeliveryDate = PersianDate.GetShamsi2Miladi(parameters.PrintDoc.ordDeliveryDate.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(parameters.PrintDoc.ordDeliveryEndDate))
								{
									parameters.PrintDoc.ordDeliveryEndDate = PersianDate.GetShamsi2Miladi(parameters.PrintDoc.ordDeliveryEndDate.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(parameters.PrintDoc.bordDeliveryDatePersian))
								{
									parameters.PrintDoc.bordDeliveryDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintDoc.bordDeliveryDatePersian.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(parameters.PrintDoc.bordSupplierDeliveryDatePersian))
								{
									parameters.PrintDoc.bordSupplierDeliveryDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintDoc.bordSupplierDeliveryDatePersian.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(parameters.PrintDoc.bordFinalDeliveryDatePersian))
								{
									parameters.PrintDoc.bordFinalDeliveryDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintDoc.bordFinalDeliveryDatePersian.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(parameters.PrintDoc.VerifiedRegisterDatePersian))
								{
									parameters.PrintDoc.VerifiedRegisterDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintDoc.VerifiedRegisterDatePersian.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(parameters.PrintDoc.pordDate))
								{
									parameters.PrintDoc.pordDate = PersianDate.GetShamsi2Miladi(parameters.PrintDoc.pordDate.Replace("/", "")).Replace("/", "");
								}
							}
							parameters.NotUsed_ListPrintDocItems = Enumerable.ToList<WSspRpt_PrintDocItems_Result>((IEnumerable<WSspRpt_PrintDocItems_Result>)cRMSpEntities.WSspRpt_PrintDocItems(docId, num, result2));
							if (parameters.NotUsed_ListPrintDocItems == null)
							{
								parameters.NotUsed_ListPrintDocItems = new List<WSspRpt_PrintDocItems_Result>();
							}
							List<WSspRpt_PrintDocItemSerials_Result> list2 = new List<WSspRpt_PrintDocItemSerials_Result>();
							foreach (WSspRpt_PrintDocItems_Result notUsed_ListPrintDocItem in parameters.NotUsed_ListPrintDocItems)
							{
								List<WSspRpt_PrintDocItemSerials_Result> collection = Enumerable.ToList<WSspRpt_PrintDocItemSerials_Result>((IEnumerable<WSspRpt_PrintDocItemSerials_Result>)cRMSpEntities.WSspRpt_PrintDocItemSerials(notUsed_ListPrintDocItem.DocItemID, num, result2));
								list2.AddRange(collection);
							}
							foreach (WSspRpt_PrintDocItemSerials_Result item in list2)
							{
								if (num != 1065)
								{
									if (!string.IsNullOrEmpty(item.RegisterDatePersian))
									{
										item.RegisterDatePersian = PersianDate.GetShamsi2Miladi(item.RegisterDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item.FirstRegisterDatePersian))
									{
										item.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(item.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
									}
								}
							}
							parameters.NotUsed_ListPrintDocItemSerials = list2;
							parameters.ListDyPrintCmpForm = new List<CRMspDyPrintCmpForm_Result>();
							parameters.ListDyPrintPrsForm = new List<CRMspDyPrintPrsForm_Result>();
							parameters.ListDyPrintPrjForm = new List<CRMspDyPrintPrjForm_Result>();
							parameters.ListDyPrintDocForm = new List<CRMspDyPrintDocForm_Result>();
							parameters.ListPrintProjectInformationTree = new List<CRMspPrintProjectInformationTree_Result>();
							if (parameters.PrintDoc != null)
							{
								if (parameters.PrintDoc.CompanyId.HasValue)
								{
									parameters.ListDyPrintCmpForm = Enumerable.ToList<CRMspDyPrintCmpForm_Result>((IEnumerable<CRMspDyPrintCmpForm_Result>)cRMEntities.CRMspDyPrintCmpForm(parameters.PrintDoc.CompanyId, num, result2, userId, token2.userId));
								}
								if (parameters.PrintDoc.CompanyPersonId.HasValue)
								{
									parameters.ListDyPrintPrsForm = Enumerable.ToList<CRMspDyPrintPrsForm_Result>((IEnumerable<CRMspDyPrintPrsForm_Result>)cRMEntities.CRMspDyPrintPrsForm(parameters.PrintDoc.CompanyPersonId, num, result2, userId, token2.userId));
								}
								if (parameters.PrintDoc.ProjectId.HasValue)
								{
									parameters.ListDyPrintPrjForm = Enumerable.ToList<CRMspDyPrintPrjForm_Result>((IEnumerable<CRMspDyPrintPrjForm_Result>)cRMEntities.CRMspDyPrintPrjForm(parameters.PrintDoc.ProjectId, num, result2, userId, token2.userId));
									parameters.ListPrintProjectInformationTree = Enumerable.ToList<CRMspPrintProjectInformationTree_Result>((IEnumerable<CRMspPrintProjectInformationTree_Result>)cRMEntities.CRMspPrintProjectInformationTree(parameters.PrintDoc.ProjectId, num, result2));
								}
								parameters.ListDyPrintDocForm = Enumerable.ToList<CRMspDyPrintDocForm_Result>((IEnumerable<CRMspDyPrintDocForm_Result>)cRMSpEntities.CRMspDyPrintDocForm(parameters.PrintDoc.DocID, num, result2, userId, token2.userId));
							}
							parameters.NotUsed_ListPrintDocVerificationRequestDetails = new List<WSspRpt_PrintDocVerificationRequestDetails_Result>();
							if (parameters.PrintDoc != null && parameters.PrintDoc.VerificationWorkFlowId.HasValue)
							{
								parameters.NotUsed_ListPrintDocVerificationRequestDetails = Enumerable.ToList<WSspRpt_PrintDocVerificationRequestDetails_Result>((IEnumerable<WSspRpt_PrintDocVerificationRequestDetails_Result>)cRMSpEntities.WSspRpt_PrintDocVerificationRequestDetails(parameters.PrintDoc.DocID, 60, parameters.PrintDoc.VerificationWorkFlowId, num, result2));
								if (parameters.NotUsed_ListPrintDocVerificationRequestDetails != null && Enumerable.Any<WSspRpt_PrintDocVerificationRequestDetails_Result>((IEnumerable<WSspRpt_PrintDocVerificationRequestDetails_Result>)parameters.NotUsed_ListPrintDocVerificationRequestDetails))
								{
									foreach (WSspRpt_PrintDocVerificationRequestDetails_Result notUsed_ListPrintDocVerificationRequestDetail in parameters.NotUsed_ListPrintDocVerificationRequestDetails)
									{
										if (num != 1065)
										{
											if (!string.IsNullOrEmpty(notUsed_ListPrintDocVerificationRequestDetail.VerifyDatePersian))
											{
												notUsed_ListPrintDocVerificationRequestDetail.VerifyDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintDocVerificationRequestDetail.VerifyDatePersian.Replace("/", "")).Replace("/", "");
											}
											if (!string.IsNullOrEmpty(notUsed_ListPrintDocVerificationRequestDetail.FirstRegisterDatePersian))
											{
												notUsed_ListPrintDocVerificationRequestDetail.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintDocVerificationRequestDetail.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
											}
											if (!string.IsNullOrEmpty(notUsed_ListPrintDocVerificationRequestDetail.RegisterDatePersian))
											{
												notUsed_ListPrintDocVerificationRequestDetail.RegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintDocVerificationRequestDetail.RegisterDatePersian.Replace("/", "")).Replace("/", "");
											}
											if (!string.IsNullOrEmpty(notUsed_ListPrintDocVerificationRequestDetail.VerificationReqDatePersian))
											{
												notUsed_ListPrintDocVerificationRequestDetail.VerificationReqDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintDocVerificationRequestDetail.VerificationReqDatePersian.Replace("/", "")).Replace("/", "");
											}
											if (!string.IsNullOrEmpty(notUsed_ListPrintDocVerificationRequestDetail.VerificationReqExpiredDatePersian))
											{
												notUsed_ListPrintDocVerificationRequestDetail.VerificationReqExpiredDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintDocVerificationRequestDetail.VerificationReqExpiredDatePersian.Replace("/", "")).Replace("/", "");
											}
										}
										if (notUsed_ListPrintDocVerificationRequestDetail.VerifyUserSignature != null)
										{
											notUsed_ListPrintDocVerificationRequestDetail.VerifyUserSignatureStr = Convert.ToBase64String(notUsed_ListPrintDocVerificationRequestDetail.VerifyUserSignature);
										}
									}
								}
							}
							if (parameters.NotUsed_ListPrintDocVerificationRequestDetails == null)
							{
								parameters.NotUsed_ListPrintDocVerificationRequestDetails = new List<WSspRpt_PrintDocVerificationRequestDetails_Result>();
							}
							parameters.NotUsed_ListDocItemPrdPicture = new List<WSspRpt_PrintDocItemPrdPicture_Result>();
							if (parameters.PrintDoc != null)
							{
								parameters.NotUsed_ListDocItemPrdPicture = Enumerable.ToList<WSspRpt_PrintDocItemPrdPicture_Result>((IEnumerable<WSspRpt_PrintDocItemPrdPicture_Result>)cRMSpEntities.WSspRpt_PrintDocItemPrdPicture(parameters.PrintDoc.DocID, num, result2));
							}
							if (parameters.NotUsed_ListDocItemPrdPicture == null)
							{
								parameters.NotUsed_ListDocItemPrdPicture = new List<WSspRpt_PrintDocItemPrdPicture_Result>();
							}
							parameters.SignatureFirstRegisterUser = null;
							parameters.SignatureLastEditUser = null;
							parameters.SignatureVerifierUser = null;
							WSspRpt_PrintDoc_Result printDoc = parameters.PrintDoc;
							if (printDoc != null)
							{
								CRMspSelectUserSignatureByUserId_Result cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)cRMEntities.CRMspSelectUserSignatureByUserId(printDoc.FirstRegisterUserId));
								if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
								{
									parameters.SignatureFirstRegisterUser = cRMspSelectUserSignatureByUserId_Result.Signature;
								}
								cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)cRMEntities.CRMspSelectUserSignatureByUserId(printDoc.UserId));
								if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
								{
									parameters.SignatureLastEditUser = cRMspSelectUserSignatureByUserId_Result.Signature;
								}
								if (printDoc.VerifierId.HasValue)
								{
									cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)cRMEntities.CRMspSelectUserSignatureByUserId(printDoc.VerifierId));
									if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
									{
										parameters.SignatureVerifierUser = cRMspSelectUserSignatureByUserId_Result.Signature;
									}
								}
							}
							byte[] coLoGo = SysSeting.Get().CoLoGo;
							if (coLoGo != null && coLoGo.Length != 0)
							{
								parameters.CoLogo = Convert.ToBase64String(coLoGo);
							}
							parameters.NotUsed_ListPrintDocItemsFromQuantity = new List<WSspRpt_PrintDocItemsFromQuantity_Result>();
							parameters.NotUsed_ListPrintDocItemsFromQuantity = Enumerable.ToList<WSspRpt_PrintDocItemsFromQuantity_Result>((IEnumerable<WSspRpt_PrintDocItemsFromQuantity_Result>)cRMSpEntities.WSspRpt_PrintDocItemsFromQuantity(docId, num, result2));
							if (parameters.NotUsed_ListPrintDocItemsFromQuantity == null)
							{
								parameters.NotUsed_ListPrintDocItemsFromQuantity = new List<WSspRpt_PrintDocItemsFromQuantity_Result>();
							}
							string text3 = "";
							if (parameters.PrintDoc != null)
							{
								text3 = parameters.PrintDoc.DocLinkAccData ?? "";
							}
							if (!string.IsNullOrWhiteSpace(text3))
							{
								List<DocLinkAccDataViewModel> list3 = new JavaScriptSerializer().Deserialize<List<DocLinkAccDataViewModel>>(text3);
								if (list3 != null && Enumerable.Any<DocLinkAccDataViewModel>((IEnumerable<DocLinkAccDataViewModel>)list3))
								{
									foreach (DocLinkAccDataViewModel vmLkAcc in list3)
									{
										vmLkAcc.DocId = docId;
										CRMspSelectLinkAccSettingDBIsActive_Result cRMspSelectLinkAccSettingDBIsActive_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDBIsActive_Result>((IEnumerable<CRMspSelectLinkAccSettingDBIsActive_Result>)list, (Func<CRMspSelectLinkAccSettingDBIsActive_Result, bool>)((CRMspSelectLinkAccSettingDBIsActive_Result m) => m.LinkAccSettingDBId == vmLkAcc.DBId.GetValueOrDefault()));
										if (cRMspSelectLinkAccSettingDBIsActive_Result != null)
										{
											vmLkAcc.DbName = cRMspSelectLinkAccSettingDBIsActive_Result.LinkAccSettingDbName ?? "";
											vmLkAcc.DbTitle = cRMspSelectLinkAccSettingDBIsActive_Result.LinkAccSettingDbTitle ?? "";
										}
									}
									parameters.NotUsed_ListLinkAccData.AddRange(list3);
								}
							}
							if (parameters.NotUsed_ListLinkAccData == null)
							{
								parameters.NotUsed_ListLinkAccData = new List<DocLinkAccDataViewModel>();
							}
							XmlSerializer val = new XmlSerializer(typeof(Mobile.Models.ReportModel.WarehouseMovementPrintRpt.Parameters));
							StringWriter stringWriter = new StringWriter();
							XmlWriter val2 = XmlWriter.Create((TextWriter)stringWriter);
							val.Serialize(val2, (object)parameters);
							DataSet val3 = new DataSet();
							val3.ReadXmlSchema(text + "WareHouseMovementPrint.xsd");
							XElement val4 = XElement.Parse(stringWriter.ToString());
							val3.ReadXml(((XNode)val4).CreateReader((ReaderOptions)0));
							StiReport stiReport = new StiReport();
							int printFormatCId = PrintFormat.GetPrintFormatCId(0, fileName);
							if (printFormatCId != 0 && !string.IsNullOrWhiteSpace(text2))
							{
								if (!text2.EndsWith("/"))
								{
									text2 += "/";
								}
								text2 = text2 + printFormatCId + "/";
							}
							stiReport.Load(text2 + fileName);
							string text4 = "Integrated Security=False;Data Source={DBServer};Initial Catalog={DBName};Password={DBPass};User ID={DBUser}";
							text4 = text4.Replace("{DBServer}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBServer"]));
							text4 = text4.Replace("{DBName}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBName"]));
							text4 = text4.Replace("{DBUser}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBUser"]));
							text4 = text4.Replace("{DBPass}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBPass"]));
							((CollectionBase)stiReport.Dictionary.Databases).Clear();
							stiReport.Dictionary.Databases.Add(new StiSqlDatabase("CRMIdealExtra", text4));
							stiReport.Compile();
							stiReport.RegData(val3);
							stiReport.Render();
							string text5 = HttpContext.Current.Server.MapPath("~/Download") + "\\Reports\\Files\\" + token2.userId;
							if (!System.IO.Directory.Exists(text5))
							{
								System.IO.Directory.CreateDirectory(text5);
								CRM.General.IO.Directory.SetFullControlForEveryOne(text5);
							}
							string path = text5 + "\\Doc-" + docId + "-" + now.ToString("yyyyMMddHHmmssfff") + ".pdf";
							try
							{
								System.IO.File.Delete(path);
							}
							catch (Exception e)
							{
								ErrorSignal.FromCurrentContext().Raise(e);
								message = "خطا در یافت";
								data = null;
								status = ServiceResultStatus.Error;
							}
							StiJpegExportSettings stiJpegExportSettings = new StiJpegExportSettings
							{
								ImageResolution = 300
							};
							int currentPage = Enumerable.Count<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
							string text6 = text5 + "\\Doc_" + token2.userId + "_" + docId + ".pdf";
							string text7 = text5 + "\\Doc_Zip_" + token2.userId + "_" + docId;
							if (!System.IO.Directory.Exists(text7))
							{
								System.IO.Directory.CreateDirectory(text7);
								CRM.General.IO.Directory.SetFullControlForEveryOne(text7);
							}
							string file = text7 + "\\Doc_001.jpg";
							stiJpegExportSettings.PageRange = new StiPagesRange(currentPage);
							stiReport.ExportDocument(StiExportFormat.ImageJpeg, file, stiJpegExportSettings);
							string[] files = System.IO.Directory.GetFiles(text7);
							if (Enumerable.Any<string>((IEnumerable<string>)files))
							{
								PdfDocument pdfDocument = new PdfDocument();
								for (int i = 0; i < files.Length; i++)
								{
									PdfPage pdfPage = new PdfPage();
									StiPage stiPage = Enumerable.FirstOrDefault<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
									if (stiPage != null)
									{
										if (stiPage.Orientation == StiPageOrientation.Landscape)
										{
											pdfPage.Orientation = PageOrientation.Landscape;
										}
										try
										{
											PaperKind paperSize = stiPage.PaperSize;
											switch (paperSize - 8)
											{
											default:
												if ((int)paperSize != 66)
												{
													break;
												}
												pdfPage.Size = PageSize.A2;
												goto end_IL_10bb;
											case 0:
												pdfPage.Size = PageSize.A3;
												goto end_IL_10bb;
											case 1:
												pdfPage.Size = PageSize.A4;
												goto end_IL_10bb;
											case 3:
												pdfPage.Size = PageSize.A5;
												goto end_IL_10bb;
											case 4:
												pdfPage.Size = PageSize.B4;
												goto end_IL_10bb;
											case 5:
												pdfPage.Size = PageSize.B5;
												goto end_IL_10bb;
											case 2:
												break;
											}
											pdfPage.Size = PageSize.A4;
											end_IL_10bb:;
										}
										catch (Exception e2)
										{
											ErrorSignal.FromCurrentContext().Raise(e2);
											pdfPage.Size = PageSize.A4;
										}
									}
									pdfDocument.Pages.Add(pdfPage);
									XGraphics xGraphics = XGraphics.FromPdfPage(pdfDocument.Pages[i]);
									XImage xImage = XImage.FromFile(files[i]);
									xGraphics.DrawImage(xImage, 0.0, 0.0);
									xImage.Dispose();
									xGraphics.Dispose();
								}
								pdfDocument.Save(text6);
								pdfDocument.Close();
							}
							try
							{
								DirectoryInfo directoryInfo = new DirectoryInfo(text7);
								FileInfo[] files2 = directoryInfo.GetFiles();
								for (int j = 0; j < files2.Length; j++)
								{
									files2[j].Delete();
								}
								DirectoryInfo[] directories = directoryInfo.GetDirectories();
								for (int j = 0; j < directories.Length; j++)
								{
									directories[j].Delete(recursive: true);
								}
								if (System.IO.Directory.Exists(text7))
								{
									System.IO.Directory.Delete(text7);
								}
							}
							catch (Exception e3)
							{
								ErrorSignal.FromCurrentContext().Raise(e3);
							}
							path = text6;
							string[] array = HttpContext.Current.Request.Url.AbsoluteUri.Split(new string[1] { "/api/" }, StringSplitOptions.None);
							string text8 = "";
							if (array != null)
							{
								string text9 = "/Download/Reports/Files/" + token2.userId + "/Doc_" + token2.userId + "_" + docId + ".pdf";
								text8 = ((array[0] != null && array[0] != "") ? (array[0] + text9) : "");
							}
							PrintLog.InsertPrintLog(docId, 12, 3);
							data = (System.IO.File.Exists(path) ? text8 : "");
							message = Messages.MobMsgSuccessAction;
							status = ServiceResultStatus.Success;
						}
						else
						{
							message = Messages.MobMsgErrorFileNotExist;
							data = null;
							status = ServiceResultStatus.Error;
						}
					}
					catch (Exception e4)
					{
						message = Messages.MobMsgErrorDoneOperation;
						data = null;
						status = ServiceResultStatus.Error;
						ErrorSignal.FromCurrentContext().Raise(e4);
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
		catch (Exception e5)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e5);
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

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> GetPdfPaymentByIdAndType(int payId, int typeId, int? printformatId = 0, int? ln = null, int? pfCId = null)
	{
		//IL_0c92: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c97: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c99: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c9c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cba: Expected I4, but got Unknown
		//IL_098a: Unknown result type (might be due to invalid IL or missing references)
		//IL_09a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_09af: Expected O, but got Unknown
		//IL_09da: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cba: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cbe: Invalid comparison between Unknown and I4
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
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
					try
					{
						cRMEntities = new CRMEntities();
						cRMSpEntities = new CRMSpEntities();
						StiReport stiReport = new StiReport();
						if (payId > 0)
						{
							string text = HttpContext.Current.Server.MapPath("~/Areas/Reports/ReportDatasets/");
							string text2 = HttpContext.Current.Server.MapPath("~/Areas/Reports/ReportFiles/");
							string text3 = "";
							Mobile.Models.ReportModel.PrintPaymentByIdAndTypeRpt.Parameters parameters = new Mobile.Models.ReportModel.PrintPaymentByIdAndTypeRpt.Parameters();
							int userId = token2.userId;
							DateTime now = DateTime.Now;
							string rptDate = now.ToString("yyyy/MM/dd");
							string rptDay = now.ToString("dddd");
							Reports reports = new Reports();
							parameters.SysSetting = reports.GetSysSetting();
							parameters.ReportDateTime = now;
							parameters.ReporterUserName = UserLogin.CurrentUser.FullName;
							parameters.ReportDay = DateTimeClass.DefineDayeOfWeekPersian(parameters.ReportDateTime.DayOfWeek.ToString());
							parameters.ReportDateTime.ToString("yyyy/MM/dd");
							string rptBuyOrderTitle = Labels.RptBuyOrderTitle;
							string rptPreOrderTitle = Labels.RptPreOrderTitle;
							string rptSaleOrderTitle = Labels.RptSaleOrderTitle;
							byte[] coLoGo = SysSeting.Get().CoLoGo;
							if (coLoGo != null && coLoGo.Length != 0)
							{
								parameters.CoLogo = Convert.ToBase64String(coLoGo);
							}
							parameters.PaymentByIdAndType = Enumerable.FirstOrDefault<WSspRpt_PrintPaymentByIdAndType_Result>((IEnumerable<WSspRpt_PrintPaymentByIdAndType_Result>)cRMSpEntities.WSspRpt_PrintPaymentByIdAndType(payId, typeId, rptBuyOrderTitle, rptPreOrderTitle, rptSaleOrderTitle, num, result2, userId, rptDate, rptDay));
							if (parameters.PaymentByIdAndType != null)
							{
								DateTime dateTime = default(DateTime);
								string text4 = "";
								try
								{
									if (!string.IsNullOrEmpty(parameters.PaymentByIdAndType.payDocDatePerWithSlash))
									{
										parameters.PaymentByIdAndType.payDocDatePerWithSlash = parameters.PaymentByIdAndType.payDocDatePerWithSlash.Replace("/", "").Replace("-", "").Replace("_", "")
											.Replace(".", "")
											.Replace(",", "")
											.Replace("\\", "");
										text4 = PersianDate.GetFormatetdDate(parameters.PaymentByIdAndType.payDocDatePerWithSlash.Replace("/", ""));
										text4 = text4 + " " + DateTime.Now.ToString("HH:mm:ss");
										switch (num)
										{
										case 1065:
											dateTime = DateTime.Parse(text4, new PersianCulture());
											parameters.PaymentByIdAndType.payDocDatePerWithSlash = dateTime.ToString("yyyy/MM/dd");
											break;
										case 1025:
										{
											DateTime dateTime3 = DateTime.Parse(PersianDate.GetShamsi2Miladi(parameters.PaymentByIdAndType.payDocDatePerWithSlash.Replace("/", "")));
											parameters.PaymentByIdAndType.payDocDatePerWithSlash = dateTime3.ToString("yyyy/MM/dd", new CultureInfo("ar-SA"));
											break;
										}
										default:
										{
											DateTime dateTime2 = DateTime.Parse(PersianDate.GetShamsi2Miladi(parameters.PaymentByIdAndType.payDocDatePerWithSlash.Replace("/", "")));
											parameters.PaymentByIdAndType.payDocDatePerWithSlash = dateTime2.ToString("yyyy/MM/dd", new CultureInfo("en-US"));
											break;
										}
										}
									}
									if (!string.IsNullOrEmpty(parameters.PaymentByIdAndType.ImportDatePerWithSlash))
									{
										parameters.PaymentByIdAndType.ImportDatePerWithSlash = parameters.PaymentByIdAndType.ImportDatePerWithSlash.Replace("/", "").Replace("-", "").Replace("_", "")
											.Replace(".", "")
											.Replace(",", "")
											.Replace("\\", "");
										text4 = PersianDate.GetFormatetdDate(parameters.PaymentByIdAndType.ImportDatePerWithSlash.Replace("/", ""));
										text4 = text4 + " " + DateTime.Now.ToString("HH:mm:ss");
										switch (num)
										{
										case 1065:
											dateTime = DateTime.Parse(text4, new PersianCulture());
											parameters.PaymentByIdAndType.ImportDatePerWithSlash = dateTime.ToString("yyyy/MM/dd");
											break;
										case 1025:
										{
											DateTime dateTime5 = DateTime.Parse(PersianDate.GetShamsi2Miladi(parameters.PaymentByIdAndType.ImportDatePerWithSlash.Replace("/", "")));
											parameters.PaymentByIdAndType.ImportDatePerWithSlash = dateTime5.ToString("yyyy/MM/dd", new CultureInfo("ar-SA"));
											break;
										}
										default:
										{
											DateTime dateTime4 = DateTime.Parse(PersianDate.GetShamsi2Miladi(parameters.PaymentByIdAndType.ImportDatePerWithSlash.Replace("/", "")));
											parameters.PaymentByIdAndType.ImportDatePerWithSlash = dateTime4.ToString("yyyy/MM/dd", new CultureInfo("en-US"));
											break;
										}
										}
									}
									if (!string.IsNullOrEmpty(parameters.PaymentByIdAndType.FirstRegisteDatePerWithSlash))
									{
										parameters.PaymentByIdAndType.FirstRegisteDatePerWithSlash = parameters.PaymentByIdAndType.FirstRegisteDatePerWithSlash.Replace("/", "").Replace("-", "").Replace("_", "")
											.Replace(".", "")
											.Replace(",", "")
											.Replace("\\", "");
										text4 = PersianDate.GetFormatetdDate(parameters.PaymentByIdAndType.FirstRegisteDatePerWithSlash.Replace("/", ""));
										text4 = text4 + " " + DateTime.Now.ToString("HH:mm:ss");
										switch (num)
										{
										case 1065:
											dateTime = DateTime.Parse(text4, new PersianCulture());
											parameters.PaymentByIdAndType.FirstRegisteDatePerWithSlash = dateTime.ToString("yyyy/MM/dd");
											break;
										case 1025:
										{
											DateTime dateTime7 = DateTime.Parse(PersianDate.GetShamsi2Miladi(parameters.PaymentByIdAndType.FirstRegisteDatePerWithSlash.Replace("/", "")));
											parameters.PaymentByIdAndType.FirstRegisteDatePerWithSlash = dateTime7.ToString("yyyy/MM/dd", new CultureInfo("ar-SA"));
											break;
										}
										default:
										{
											DateTime dateTime6 = DateTime.Parse(PersianDate.GetShamsi2Miladi(parameters.PaymentByIdAndType.FirstRegisteDatePerWithSlash.Replace("/", "")));
											parameters.PaymentByIdAndType.FirstRegisteDatePerWithSlash = dateTime6.ToString("yyyy/MM/dd", new CultureInfo("en-US"));
											break;
										}
										}
									}
									if (!string.IsNullOrEmpty(parameters.PaymentByIdAndType.RegisteDatePerWithSlash))
									{
										parameters.PaymentByIdAndType.RegisteDatePerWithSlash = parameters.PaymentByIdAndType.RegisteDatePerWithSlash.Replace("/", "").Replace("-", "").Replace("_", "")
											.Replace(".", "")
											.Replace(",", "")
											.Replace("\\", "");
										text4 = PersianDate.GetFormatetdDate(parameters.PaymentByIdAndType.RegisteDatePerWithSlash.Replace("/", ""));
										text4 = text4 + " " + DateTime.Now.ToString("HH:mm:ss");
										switch (num)
										{
										case 1065:
											dateTime = DateTime.Parse(text4, new PersianCulture());
											parameters.PaymentByIdAndType.RegisteDatePerWithSlash = dateTime.ToString("yyyy/MM/dd");
											break;
										case 1025:
										{
											DateTime dateTime9 = DateTime.Parse(PersianDate.GetShamsi2Miladi(parameters.PaymentByIdAndType.RegisteDatePerWithSlash.Replace("/", "")));
											parameters.PaymentByIdAndType.RegisteDatePerWithSlash = dateTime9.ToString("yyyy/MM/dd", new CultureInfo("ar-SA"));
											break;
										}
										default:
										{
											DateTime dateTime8 = DateTime.Parse(PersianDate.GetShamsi2Miladi(parameters.PaymentByIdAndType.RegisteDatePerWithSlash.Replace("/", "")));
											parameters.PaymentByIdAndType.RegisteDatePerWithSlash = dateTime8.ToString("yyyy/MM/dd", new CultureInfo("en-US"));
											break;
										}
										}
									}
								}
								catch (Exception)
								{
								}
							}
							MobspReturnPrintFormatFileNameById_Result mobspReturnPrintFormatFileNameById_Result = Enumerable.FirstOrDefault<MobspReturnPrintFormatFileNameById_Result>((IEnumerable<MobspReturnPrintFormatFileNameById_Result>)cRMEntities.MobspReturnPrintFormatFileNameById(printformatId));
							if ((mobspReturnPrintFormatFileNameById_Result?.CId).GetValueOrDefault() != 0 && !string.IsNullOrWhiteSpace(text2))
							{
								if (!text2.EndsWith("\\"))
								{
									text2 += "\\";
								}
								text2 = text2 + mobspReturnPrintFormatFileNameById_Result.CId + "\\";
							}
							if (mobspReturnPrintFormatFileNameById_Result != null)
							{
								text3 = mobspReturnPrintFormatFileNameById_Result.FileNameWeb;
							}
							if (string.IsNullOrEmpty(text3))
							{
								text3 = "PrintPaymentByIdAndType.mrt";
							}
							if (!System.IO.File.Exists(text2 + text3))
							{
								text3 = "PrintPaymentByIdAndType.mrt";
							}
							XmlSerializer val = new XmlSerializer(typeof(Mobile.Models.ReportModel.PrintPaymentByIdAndTypeRpt.Parameters));
							StringWriter stringWriter = new StringWriter();
							XmlWriter val2 = XmlWriter.Create((TextWriter)stringWriter);
							val.Serialize(val2, (object)parameters);
							DataSet val3 = new DataSet();
							val3.ReadXmlSchema(text + "PrintPaymentByIdAndType.xsd");
							XElement val4 = XElement.Parse(stringWriter.ToString());
							val3.ReadXml(((XNode)val4).CreateReader((ReaderOptions)0));
							stiReport.Load(text2 + text3);
							string text5 = "Integrated Security=False;Data Source={DBServer};Initial Catalog={DBName};Password={DBPass};User ID={DBUser}";
							text5 = text5.Replace("{DBServer}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBServer"]));
							text5 = text5.Replace("{DBName}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBName"]));
							text5 = text5.Replace("{DBUser}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBUser"]));
							text5 = text5.Replace("{DBPass}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBPass"]));
							((CollectionBase)stiReport.Dictionary.Databases).Clear();
							stiReport.Dictionary.Databases.Add(new StiSqlDatabase("CRMIdealExtra", text5));
							stiReport.Compile();
							stiReport.RegData(val3);
							stiReport.Render();
							string text6 = HttpContext.Current.Server.MapPath("~/Download") + "\\Reports\\Files\\" + token2.userId;
							if (!System.IO.Directory.Exists(text6))
							{
								System.IO.Directory.CreateDirectory(text6);
								CRM.General.IO.Directory.SetFullControlForEveryOne(text6);
							}
							string path = text6 + "\\Pay-" + payId + "-" + now.ToString("yyyyMMddHHmmssfff") + ".pdf";
							try
							{
								System.IO.File.Delete(path);
							}
							catch (Exception e)
							{
								ErrorSignal.FromCurrentContext().Raise(e);
								message = "خطا در یافت";
								data = null;
								status = ServiceResultStatus.Error;
							}
							StiJpegExportSettings stiJpegExportSettings = new StiJpegExportSettings
							{
								ImageResolution = 300
							};
							int currentPage = Enumerable.Count<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
							string text7 = text6 + "\\Pay-" + payId + "-" + now.ToString("yyyyMMddHHmmssfff") + ".pdf";
							string text8 = text6 + "\\Pay_Zip_" + payId;
							if (!System.IO.Directory.Exists(text8))
							{
								System.IO.Directory.CreateDirectory(text8);
								CRM.General.IO.Directory.SetFullControlForEveryOne(text8);
							}
							string file = text8 + "\\pay_001.jpg";
							stiJpegExportSettings.PageRange = new StiPagesRange(currentPage);
							stiReport.ExportDocument(StiExportFormat.ImageJpeg, file, stiJpegExportSettings);
							string[] files = System.IO.Directory.GetFiles(text8);
							if (Enumerable.Any<string>((IEnumerable<string>)files))
							{
								PdfDocument pdfDocument = new PdfDocument();
								for (int i = 0; i < files.Length; i++)
								{
									PdfPage pdfPage = new PdfPage();
									StiPage stiPage = Enumerable.FirstOrDefault<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
									if (stiPage != null)
									{
										if (stiPage.Orientation == StiPageOrientation.Landscape)
										{
											pdfPage.Orientation = PageOrientation.Landscape;
										}
										try
										{
											PaperKind paperSize = stiPage.PaperSize;
											switch (paperSize - 8)
											{
											default:
												if ((int)paperSize != 66)
												{
													break;
												}
												pdfPage.Size = PageSize.A2;
												goto end_IL_0c90;
											case 0:
												pdfPage.Size = PageSize.A3;
												goto end_IL_0c90;
											case 1:
												pdfPage.Size = PageSize.A4;
												goto end_IL_0c90;
											case 3:
												pdfPage.Size = PageSize.A5;
												goto end_IL_0c90;
											case 4:
												pdfPage.Size = PageSize.B4;
												goto end_IL_0c90;
											case 5:
												pdfPage.Size = PageSize.B5;
												goto end_IL_0c90;
											case 2:
												break;
											}
											pdfPage.Size = PageSize.A4;
											end_IL_0c90:;
										}
										catch (Exception e2)
										{
											ErrorSignal.FromCurrentContext().Raise(e2);
											pdfPage.Size = PageSize.A4;
										}
									}
									pdfDocument.Pages.Add(pdfPage);
									XGraphics xGraphics = XGraphics.FromPdfPage(pdfDocument.Pages[i]);
									XImage xImage = XImage.FromFile(files[i]);
									xGraphics.DrawImage(xImage, 0.0, 0.0);
									xImage.Dispose();
									xGraphics.Dispose();
								}
								pdfDocument.Save(text7);
								pdfDocument.Close();
							}
							try
							{
								DirectoryInfo directoryInfo = new DirectoryInfo(text8);
								FileInfo[] files2 = directoryInfo.GetFiles();
								for (int j = 0; j < files2.Length; j++)
								{
									files2[j].Delete();
								}
								DirectoryInfo[] directories = directoryInfo.GetDirectories();
								for (int j = 0; j < directories.Length; j++)
								{
									directories[j].Delete(recursive: true);
								}
								if (System.IO.Directory.Exists(text8))
								{
									System.IO.Directory.Delete(text8);
								}
							}
							catch (Exception e3)
							{
								ErrorSignal.FromCurrentContext().Raise(e3);
							}
							path = text7;
							string[] array = HttpContext.Current.Request.Url.AbsoluteUri.Split(new string[1] { "/api/" }, StringSplitOptions.None);
							string text9 = "";
							if (array != null)
							{
								string text10 = "/Download/Reports/Files/" + token2.userId + "/Pay-" + payId + "-" + now.ToString("yyyyMMddHHmmssfff") + ".pdf";
								text9 = ((array[0] != null && array[0] != "") ? (array[0] + text10) : "");
							}
							data = (System.IO.File.Exists(path) ? text9 : "");
							message = Messages.MobMsgSuccessAction;
							status = ServiceResultStatus.Success;
						}
						else
						{
							message = Messages.MobMsgErrorFileNotExist;
							data = null;
							status = ServiceResultStatus.Error;
						}
					}
					catch (Exception e4)
					{
						message = Messages.MobMsgErrorDoneOperation;
						data = null;
						status = ServiceResultStatus.Error;
						ErrorSignal.FromCurrentContext().Raise(e4);
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
		catch (Exception e5)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e5);
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

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> GetPdfMonyBagById(int payId, int? printformatId = 0, int? ln = null, int? pfCId = null)
	{
		//IL_0abe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ac3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ac5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ac8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae6: Expected I4, but got Unknown
		//IL_0ae6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aea: Invalid comparison between Unknown and I4
		//IL_07b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_07db: Expected O, but got Unknown
		//IL_0806: Unknown result type (might be due to invalid IL or missing references)
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
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
					try
					{
						cRMEntities = new CRMEntities();
						cRMSpEntities = new CRMSpEntities();
						StiReport stiReport = new StiReport();
						if (payId > 0)
						{
							string text = HttpContext.Current.Server.MapPath("~/Areas/Reports/ReportDatasets/");
							string text2 = HttpContext.Current.Server.MapPath("~/Areas/Reports/ReportFiles/");
							string text3 = "";
							Mobile.Models.ReportModel.PrintCompanyMoneyBagRpt.Parameters parameters = new Mobile.Models.ReportModel.PrintCompanyMoneyBagRpt.Parameters();
							int userId = token2.userId;
							DateTime now = DateTime.Now;
							string rptDate = now.ToString("yyyy/MM/dd");
							string rptDay = now.ToString("dddd");
							Reports reports = new Reports();
							parameters.SysSetting = reports.GetSysSetting();
							parameters.ReportDateTime = now;
							parameters.ReporterUserName = UserLogin.CurrentUser.FullName;
							parameters.ReportDay = DateTimeClass.DefineDayeOfWeekPersian(parameters.ReportDateTime.DayOfWeek.ToString());
							parameters.ReportDateTime.ToString("yyyy/MM/dd");
							string cmpMnBgTextManual = Labels.CmpMnBgTextManual;
							string cmpMnBgTextSystemic = Labels.CmpMnBgTextSystemic;
							string rptPaymentTitle = Labels.RptPaymentTitle;
							parameters.CompanyMoneyBagById = Enumerable.FirstOrDefault<CRMspRpt_PrintCompanyMoneyBagById_Result>((IEnumerable<CRMspRpt_PrintCompanyMoneyBagById_Result>)cRMSpEntities.CRMspRpt_PrintCompanyMoneyBagById(payId, userId, rptDate, rptDay, cmpMnBgTextManual, cmpMnBgTextSystemic, rptPaymentTitle, num, result2));
							if (parameters.CompanyMoneyBagById != null)
							{
								DateTime dateTime = default(DateTime);
								string text4 = "";
								parameters.CompanyMoneyBagById.CmpMnBgDatePerWithSlash = parameters.CompanyMoneyBagById.CmpMnBgDatePerWithSlash.Replace("/", "").Replace("-", "").Replace("_", "")
									.Replace(".", "")
									.Replace(",", "")
									.Replace("\\", "");
								if (!string.IsNullOrEmpty(parameters.CompanyMoneyBagById.CmpMnBgDatePerWithSlash))
								{
									text4 = PersianDate.GetFormatetdDate(parameters.CompanyMoneyBagById.CmpMnBgDatePerWithSlash.Replace("/", ""));
									text4 = text4 + " " + DateTime.Now.ToString("HH:mm:ss");
									switch (num)
									{
									case 1065:
										dateTime = DateTime.Parse(text4, new PersianCulture());
										parameters.CompanyMoneyBagById.CmpMnBgDatePerWithSlash = dateTime.ToString("yyyy/MM/dd");
										break;
									case 1025:
									{
										DateTime dateTime3 = DateTime.Parse(PersianDate.GetShamsi2Miladi(parameters.CompanyMoneyBagById.CmpMnBgDatePerWithSlash.Replace("/", "")));
										parameters.CompanyMoneyBagById.CmpMnBgDatePerWithSlash = dateTime3.ToString("yyyy/MM/dd", new CultureInfo("ar-SA"));
										break;
									}
									default:
									{
										DateTime dateTime2 = DateTime.Parse(PersianDate.GetShamsi2Miladi(parameters.CompanyMoneyBagById.CmpMnBgDatePerWithSlash.Replace("/", "")));
										parameters.CompanyMoneyBagById.CmpMnBgDatePerWithSlash = dateTime2.ToString("yyyy/MM/dd", new CultureInfo("en-US"));
										break;
									}
									}
								}
								parameters.CompanyMoneyBagById.FirstRegisterDatePerWithSlash = parameters.CompanyMoneyBagById.FirstRegisterDatePerWithSlash.Replace("/", "").Replace("-", "").Replace("_", "")
									.Replace(".", "")
									.Replace(",", "")
									.Replace("\\", "");
								if (!string.IsNullOrEmpty(parameters.CompanyMoneyBagById.FirstRegisterDatePerWithSlash))
								{
									text4 = PersianDate.GetFormatetdDate(parameters.CompanyMoneyBagById.FirstRegisterDatePerWithSlash.Replace("/", ""));
									text4 = text4 + " " + DateTime.Now.ToString("HH:mm:ss");
									switch (num)
									{
									case 1065:
										dateTime = DateTime.Parse(text4, new PersianCulture());
										parameters.CompanyMoneyBagById.FirstRegisterDatePerWithSlash = dateTime.ToString("yyyy/MM/dd");
										break;
									case 1025:
									{
										DateTime dateTime5 = DateTime.Parse(PersianDate.GetShamsi2Miladi(parameters.CompanyMoneyBagById.FirstRegisterDatePerWithSlash.Replace("/", "")));
										parameters.CompanyMoneyBagById.FirstRegisterDatePerWithSlash = dateTime5.ToString("yyyy/MM/dd", new CultureInfo("ar-SA"));
										break;
									}
									default:
									{
										DateTime dateTime4 = DateTime.Parse(PersianDate.GetShamsi2Miladi(parameters.CompanyMoneyBagById.FirstRegisterDatePerWithSlash.Replace("/", "")));
										parameters.CompanyMoneyBagById.FirstRegisterDatePerWithSlash = dateTime4.ToString("yyyy/MM/dd", new CultureInfo("en-US"));
										break;
									}
									}
								}
								parameters.CompanyMoneyBagById.RegisterDatePerWithSlash = parameters.CompanyMoneyBagById.RegisterDatePerWithSlash.Replace("/", "").Replace("-", "").Replace("_", "")
									.Replace(".", "")
									.Replace(",", "")
									.Replace("\\", "");
								if (!string.IsNullOrEmpty(parameters.CompanyMoneyBagById.RegisterDatePerWithSlash))
								{
									text4 = PersianDate.GetFormatetdDate(parameters.CompanyMoneyBagById.RegisterDatePerWithSlash.Replace("/", ""));
									text4 = text4 + " " + DateTime.Now.ToString("HH:mm:ss");
									switch (num)
									{
									case 1065:
										dateTime = DateTime.Parse(text4, new PersianCulture());
										parameters.CompanyMoneyBagById.RegisterDatePerWithSlash = dateTime.ToString("yyyy/MM/dd");
										break;
									case 1025:
									{
										DateTime dateTime7 = DateTime.Parse(PersianDate.GetShamsi2Miladi(parameters.CompanyMoneyBagById.RegisterDatePerWithSlash.Replace("/", "")));
										parameters.CompanyMoneyBagById.RegisterDatePerWithSlash = dateTime7.ToString("yyyy/MM/dd", new CultureInfo("ar-SA"));
										break;
									}
									default:
									{
										DateTime dateTime6 = DateTime.Parse(PersianDate.GetShamsi2Miladi(parameters.CompanyMoneyBagById.RegisterDatePerWithSlash.Replace("/", "")));
										parameters.CompanyMoneyBagById.RegisterDatePerWithSlash = dateTime6.ToString("yyyy/MM/dd", new CultureInfo("en-US"));
										break;
									}
									}
								}
							}
							MobspReturnPrintFormatFileNameById_Result mobspReturnPrintFormatFileNameById_Result = Enumerable.FirstOrDefault<MobspReturnPrintFormatFileNameById_Result>((IEnumerable<MobspReturnPrintFormatFileNameById_Result>)cRMEntities.MobspReturnPrintFormatFileNameById(printformatId));
							if ((mobspReturnPrintFormatFileNameById_Result?.CId).GetValueOrDefault() != 0 && !string.IsNullOrWhiteSpace(text2))
							{
								if (!text2.EndsWith("\\"))
								{
									text2 += "\\";
								}
								text2 = text2 + mobspReturnPrintFormatFileNameById_Result.CId + "\\";
							}
							if (mobspReturnPrintFormatFileNameById_Result != null)
							{
								text3 = mobspReturnPrintFormatFileNameById_Result.FileNameWeb;
							}
							if (string.IsNullOrEmpty(text3))
							{
								text3 = "PrintCompanyMoneyBagById.mrt";
							}
							if (!System.IO.File.Exists(text2 + text3))
							{
								text3 = "PrintCompanyMoneyBagById.mrt";
							}
							XmlSerializer val = new XmlSerializer(typeof(Mobile.Models.ReportModel.PrintCompanyMoneyBagRpt.Parameters));
							StringWriter stringWriter = new StringWriter();
							XmlWriter val2 = XmlWriter.Create((TextWriter)stringWriter);
							val.Serialize(val2, (object)parameters);
							DataSet val3 = new DataSet();
							val3.ReadXmlSchema(text + "PrintCompanyMoneyBagById.xsd");
							XElement val4 = XElement.Parse(stringWriter.ToString());
							val3.ReadXml(((XNode)val4).CreateReader((ReaderOptions)0));
							stiReport.Load(text2 + text3);
							string text5 = "Integrated Security=False;Data Source={DBServer};Initial Catalog={DBName};Password={DBPass};User ID={DBUser}";
							text5 = text5.Replace("{DBServer}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBServer"]));
							text5 = text5.Replace("{DBName}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBName"]));
							text5 = text5.Replace("{DBUser}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBUser"]));
							text5 = text5.Replace("{DBPass}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBPass"]));
							((CollectionBase)stiReport.Dictionary.Databases).Clear();
							stiReport.Dictionary.Databases.Add(new StiSqlDatabase("CRMIdealExtra", text5));
							stiReport.Compile();
							stiReport.RegData(val3);
							stiReport.Render();
							string text6 = HttpContext.Current.Server.MapPath("~/Download") + "\\Reports\\Files\\" + token2.userId;
							if (!System.IO.Directory.Exists(text6))
							{
								System.IO.Directory.CreateDirectory(text6);
								CRM.General.IO.Directory.SetFullControlForEveryOne(text6);
							}
							string path = text6 + "\\CmpMonybag-" + payId + "-" + now.ToString("yyyyMMddHHmmssfff") + ".pdf";
							try
							{
								System.IO.File.Delete(path);
							}
							catch (Exception e)
							{
								ErrorSignal.FromCurrentContext().Raise(e);
								message = "خطا در یافت";
								data = null;
								status = ServiceResultStatus.Error;
							}
							StiJpegExportSettings stiJpegExportSettings = new StiJpegExportSettings
							{
								ImageResolution = 300
							};
							int currentPage = Enumerable.Count<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
							string text7 = text6 + "\\CmpMonybag-" + payId + "-" + now.ToString("yyyyMMddHHmmssfff") + ".pdf";
							string text8 = text6 + "\\CmpMonybag_Zip_" + payId;
							if (!System.IO.Directory.Exists(text8))
							{
								System.IO.Directory.CreateDirectory(text8);
								CRM.General.IO.Directory.SetFullControlForEveryOne(text8);
							}
							string file = text8 + "\\cmpMonybag_001.jpg";
							stiJpegExportSettings.PageRange = new StiPagesRange(currentPage);
							stiReport.ExportDocument(StiExportFormat.ImageJpeg, file, stiJpegExportSettings);
							string[] files = System.IO.Directory.GetFiles(text8);
							if (Enumerable.Any<string>((IEnumerable<string>)files))
							{
								PdfDocument pdfDocument = new PdfDocument();
								for (int i = 0; i < files.Length; i++)
								{
									PdfPage pdfPage = new PdfPage();
									StiPage stiPage = Enumerable.FirstOrDefault<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
									if (stiPage != null)
									{
										if (stiPage.Orientation == StiPageOrientation.Landscape)
										{
											pdfPage.Orientation = PageOrientation.Landscape;
										}
										try
										{
											PaperKind paperSize = stiPage.PaperSize;
											switch (paperSize - 8)
											{
											default:
												if ((int)paperSize != 66)
												{
													break;
												}
												pdfPage.Size = PageSize.A2;
												goto end_IL_0abc;
											case 0:
												pdfPage.Size = PageSize.A3;
												goto end_IL_0abc;
											case 1:
												pdfPage.Size = PageSize.A4;
												goto end_IL_0abc;
											case 3:
												pdfPage.Size = PageSize.A5;
												goto end_IL_0abc;
											case 4:
												pdfPage.Size = PageSize.B4;
												goto end_IL_0abc;
											case 5:
												pdfPage.Size = PageSize.B5;
												goto end_IL_0abc;
											case 2:
												break;
											}
											pdfPage.Size = PageSize.A4;
											end_IL_0abc:;
										}
										catch (Exception e2)
										{
											ErrorSignal.FromCurrentContext().Raise(e2);
											pdfPage.Size = PageSize.A4;
										}
									}
									pdfDocument.Pages.Add(pdfPage);
									XGraphics xGraphics = XGraphics.FromPdfPage(pdfDocument.Pages[i]);
									XImage xImage = XImage.FromFile(files[i]);
									xGraphics.DrawImage(xImage, 0.0, 0.0);
									xImage.Dispose();
									xGraphics.Dispose();
								}
								pdfDocument.Save(text7);
								pdfDocument.Close();
							}
							try
							{
								DirectoryInfo directoryInfo = new DirectoryInfo(text8);
								FileInfo[] files2 = directoryInfo.GetFiles();
								for (int j = 0; j < files2.Length; j++)
								{
									files2[j].Delete();
								}
								DirectoryInfo[] directories = directoryInfo.GetDirectories();
								for (int j = 0; j < directories.Length; j++)
								{
									directories[j].Delete(recursive: true);
								}
								if (System.IO.Directory.Exists(text8))
								{
									System.IO.Directory.Delete(text8);
								}
							}
							catch (Exception e3)
							{
								ErrorSignal.FromCurrentContext().Raise(e3);
							}
							path = text7;
							string[] array = HttpContext.Current.Request.Url.AbsoluteUri.Split(new string[1] { "/api/" }, StringSplitOptions.None);
							string text9 = "";
							if (array != null)
							{
								string text10 = "/Download/Reports/Files/" + token2.userId + "/cmpMonybag-" + payId + "-" + now.ToString("yyyyMMddHHmmssfff") + ".pdf";
								text9 = ((array[0] != null && array[0] != "") ? (array[0] + text10) : "");
							}
							data = (System.IO.File.Exists(path) ? text9 : "");
							message = Messages.MobMsgSuccessAction;
							status = ServiceResultStatus.Success;
						}
						else
						{
							message = Messages.MobMsgErrorFileNotExist;
							data = null;
							status = ServiceResultStatus.Error;
						}
					}
					catch (Exception e4)
					{
						message = Messages.MobMsgErrorDoneOperation;
						data = null;
						status = ServiceResultStatus.Error;
						ErrorSignal.FromCurrentContext().Raise(e4);
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
		catch (Exception e5)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e5);
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

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> GetPdfBuyOrder(int buyOrderId, int? ln = null, int? pfCId = null)
	{
		//IL_1667: Unknown result type (might be due to invalid IL or missing references)
		//IL_166c: Unknown result type (might be due to invalid IL or missing references)
		//IL_166e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1671: Unknown result type (might be due to invalid IL or missing references)
		//IL_168f: Expected I4, but got Unknown
		//IL_168f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1693: Invalid comparison between Unknown and I4
		//IL_0abb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1128: Unknown result type (might be due to invalid IL or missing references)
		//IL_1300: Unknown result type (might be due to invalid IL or missing references)
		//IL_131e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1325: Expected O, but got Unknown
		//IL_1350: Unknown result type (might be due to invalid IL or missing references)
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangId);
		CRMEntities cRMEntities = null;
		CRMSpEntities _dbI = null;
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
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					try
					{
						cRMEntities = new CRMEntities();
						_dbI = new CRMSpEntities();
						StiReport stiReport = new StiReport();
						int result2 = 0;
						if (UserLogin.CurrentUser != null)
						{
							int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
						}
						if (buyOrderId > 0)
						{
							string text = HttpContext.Current.Server.MapPath("~/Areas/Reports/ReportDatasets/");
							string text2 = HttpContext.Current.Server.MapPath("~/Areas/Reports/ReportFiles/");
							string text3 = "";
							Mobile.Models.ReportModel.BuyOrderPrintRpt.Parameters parameters = new Mobile.Models.ReportModel.BuyOrderPrintRpt.Parameters();
							int userId = token2.userId;
							DateTime now = DateTime.Now;
							string rptDate = now.ToString("yyyy/MM/dd");
							string rptDay = now.ToString("dddd");
							Reports reports = new Reports();
							parameters.NotUsed_ListLinkAccData = new List<BordLinkAccDataViewModel>();
							parameters.NotUsed_ListPayLinkAccData = new List<PayLinkAccDataViewModel>();
							MobspSelectCrmsysSetting_Result mobspSelectCrmsysSetting_Result = SysSeting.Get();
							int result3 = 0;
							if (mobspSelectCrmsysSetting_Result != null)
							{
								int.TryParse(mobspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result3);
							}
							List<CRMspSelectLinkAccSettingDBIsActive_Result> list = new List<CRMspSelectLinkAccSettingDBIsActive_Result>();
							if (result3 == 1)
							{
								list = OtherSystems.GetLinkAccSettingDBList(1);
							}
							parameters.ActNotShowFinancialInfo = UserLogin.IsUserAccess("frmBuyOrder", "actNotShowFinancialInfo", UserLogin.CurrentUser);
							parameters.ReportDateTime = now;
							parameters.ReporterUserName = UserLogin.CurrentUser.FullName;
							parameters.SysSetting = reports.GetSysSetting();
							parameters.ReportDay = DateTimeClass.DefineDayeOfWeekPersian(parameters.ReportDateTime.DayOfWeek.ToString());
							parameters.ReportDateTime.ToString("yyyy/MM/dd");
							_ = Labels.CmpMnBgTextManual;
							_ = Labels.CmpMnBgTextSystemic;
							_ = Labels.RptPaymentTitle;
							List<WSspRpt_PrintBuyOrder_Result> list2 = Enumerable.ToList<WSspRpt_PrintBuyOrder_Result>((IEnumerable<WSspRpt_PrintBuyOrder_Result>)_dbI.WSspRpt_PrintBuyOrder(buyOrderId, currLangId, defLangId, userId, rptDate, rptDay));
							foreach (WSspRpt_PrintBuyOrder_Result item in list2)
							{
								if (currLangId != 1065)
								{
									if (!string.IsNullOrEmpty(item.bordDate))
									{
										item.bordDate = PersianDate.GetShamsi2Miladi(item.bordDate.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item.prsBirthDate))
									{
										item.prsBirthDate = PersianDate.GetShamsi2Miladi(item.prsBirthDate.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item.RegisterDatePersian))
									{
										item.RegisterDatePersian = PersianDate.GetShamsi2Miladi(item.RegisterDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item.bOIRegisterDatePersian))
									{
										item.bOIRegisterDatePersian = PersianDate.GetShamsi2Miladi(item.bOIRegisterDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item.bordDeliveryDatePersian))
									{
										item.bordDeliveryDatePersian = PersianDate.GetShamsi2Miladi(item.bordDeliveryDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item.bordTaxClearedDatePersian))
									{
										item.bordTaxClearedDatePersian = PersianDate.GetShamsi2Miladi(item.bordTaxClearedDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item.bordSupplierDeliveryDatePersian))
									{
										item.bordSupplierDeliveryDatePersian = PersianDate.GetShamsi2Miladi(item.bordSupplierDeliveryDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item.bordFinalDeliveryDatePersian))
									{
										item.bordFinalDeliveryDatePersian = PersianDate.GetShamsi2Miladi(item.bordFinalDeliveryDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item.bordITaxClearedDatePersian))
									{
										item.bordITaxClearedDatePersian = PersianDate.GetShamsi2Miladi(item.bordITaxClearedDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item.bordOrderDate))
									{
										item.bordOrderDate = PersianDate.GetShamsi2Miladi(item.bordOrderDate.Replace("/", "")).Replace("/", "");
									}
								}
							}
							byte[] coLoGo = SysSeting.Get().CoLoGo;
							if (coLoGo != null && coLoGo.Length != 0)
							{
								parameters.CoLogo = Convert.ToBase64String(coLoGo);
							}
							WSspRpt_PrintBuyOrder_Result wSspRpt_PrintBuyOrder_Result = Enumerable.FirstOrDefault<WSspRpt_PrintBuyOrder_Result>((IEnumerable<WSspRpt_PrintBuyOrder_Result>)list2);
							if (wSspRpt_PrintBuyOrder_Result == null)
							{
								wSspRpt_PrintBuyOrder_Result = new WSspRpt_PrintBuyOrder_Result();
							}
							parameters.NotUsed_ListBuyOrder = list2;
							List<WSspRpt_PrintBuyOrderItemSerials_Result> list3 = new List<WSspRpt_PrintBuyOrderItemSerials_Result>();
							foreach (WSspRpt_PrintBuyOrder_Result item2 in parameters.NotUsed_ListBuyOrder)
							{
								List<WSspRpt_PrintBuyOrderItemSerials_Result> collection = Enumerable.ToList<WSspRpt_PrintBuyOrderItemSerials_Result>((IEnumerable<WSspRpt_PrintBuyOrderItemSerials_Result>)_dbI.WSspRpt_PrintBuyOrderItemSerials(item2.BuyOrderItemId, currLangId, defLangId));
								list3.AddRange(collection);
							}
							foreach (WSspRpt_PrintBuyOrderItemSerials_Result item3 in list3)
							{
								if (currLangId != 1065)
								{
									if (!string.IsNullOrEmpty(item3.RegisterDatePersian))
									{
										item3.RegisterDatePersian = PersianDate.GetShamsi2Miladi(item3.RegisterDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item3.FirstRegisterDatePersian))
									{
										item3.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(item3.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
									}
								}
							}
							parameters.NotUsed_ListBuyOrderItemSerials = list3;
							List<WSspRpt_PrintBuyOrderItems_Result> list4 = new List<WSspRpt_PrintBuyOrderItems_Result>();
							foreach (List<WSspRpt_PrintBuyOrderItems_Result> item4 in Enumerable.Select<WSspRpt_PrintBuyOrder_Result, List<WSspRpt_PrintBuyOrderItems_Result>>((IEnumerable<WSspRpt_PrintBuyOrder_Result>)parameters.NotUsed_ListBuyOrder, (Func<WSspRpt_PrintBuyOrder_Result, List<WSspRpt_PrintBuyOrderItems_Result>>)((WSspRpt_PrintBuyOrder_Result itemSpe) => Enumerable.ToList<WSspRpt_PrintBuyOrderItems_Result>((IEnumerable<WSspRpt_PrintBuyOrderItems_Result>)_dbI.WSspRpt_PrintBuyOrderItems(itemSpe.BuyOrderID, currLangId, defLangId)))))
							{
								list4.AddRange(item4);
							}
							foreach (WSspRpt_PrintBuyOrderItems_Result item5 in list4)
							{
								if (currLangId != 1065)
								{
									if (!string.IsNullOrEmpty(item5.RegisterDatePersian))
									{
										item5.RegisterDatePersian = PersianDate.GetShamsi2Miladi(item5.RegisterDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item5.FirstRegisterDatePersian))
									{
										item5.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(item5.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item5.bordITaxClearedDatePersian))
									{
										item5.bordITaxClearedDatePersian = PersianDate.GetShamsi2Miladi(item5.bordITaxClearedDatePersian.Replace("/", "")).Replace("/", "");
									}
								}
							}
							parameters.NotUsed_ListPrintBuyOrderItems = list4;
							List<WSspRpt_PrintBuyOrderPayments_Result> list5 = new List<WSspRpt_PrintBuyOrderPayments_Result>();
							foreach (List<WSspRpt_PrintBuyOrderPayments_Result> item6 in Enumerable.Select<WSspRpt_PrintBuyOrder_Result, List<WSspRpt_PrintBuyOrderPayments_Result>>((IEnumerable<WSspRpt_PrintBuyOrder_Result>)parameters.NotUsed_ListBuyOrder, (Func<WSspRpt_PrintBuyOrder_Result, List<WSspRpt_PrintBuyOrderPayments_Result>>)((WSspRpt_PrintBuyOrder_Result itemSpe) => Enumerable.ToList<WSspRpt_PrintBuyOrderPayments_Result>((IEnumerable<WSspRpt_PrintBuyOrderPayments_Result>)_dbI.WSspRpt_PrintBuyOrderPayments(itemSpe.BuyOrderID, currLangId, defLangId)))))
							{
								list5.AddRange(item6);
							}
							foreach (WSspRpt_PrintBuyOrderPayments_Result item7 in list5)
							{
								if (currLangId != 1065)
								{
									if (!string.IsNullOrEmpty(item7.RegisterDatePersian))
									{
										item7.RegisterDatePersian = PersianDate.GetShamsi2Miladi(item7.RegisterDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item7.ImportDate))
									{
										item7.ImportDate = PersianDate.GetShamsi2Miladi(item7.ImportDate.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item7.bordpayDocDate))
									{
										item7.bordpayDocDate = PersianDate.GetShamsi2Miladi(item7.bordpayDocDate.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item7.bordpayFirstRegisteDatePersian))
									{
										item7.bordpayFirstRegisteDatePersian = PersianDate.GetShamsi2Miladi(item7.bordpayFirstRegisteDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrEmpty(item7.FirstRegisterDatePersian))
									{
										item7.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(item7.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrWhiteSpace(item7.bordpayDocDateTemp))
									{
										item7.bordpayDocDateTemp = PersianDate.GetShamsi2Miladi(item7.bordpayDocDateTemp.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrWhiteSpace(item7.bordpayVerifiedRegisterDatePersian))
									{
										item7.bordpayVerifiedRegisterDatePersian = PersianDate.GetShamsi2Miladi(item7.bordpayVerifiedRegisterDatePersian.Replace("/", "")).Replace("/", "");
									}
								}
								if (string.IsNullOrWhiteSpace(item7.bordpayLinkAccData))
								{
									continue;
								}
								List<PayLinkAccDataViewModel> list6 = new JavaScriptSerializer().Deserialize<List<PayLinkAccDataViewModel>>(item7.bordpayLinkAccData);
								if (list6 == null || !Enumerable.Any<PayLinkAccDataViewModel>((IEnumerable<PayLinkAccDataViewModel>)list6))
								{
									continue;
								}
								foreach (PayLinkAccDataViewModel vmLkAcc2 in list6)
								{
									vmLkAcc2.PayId = item7.BuyOrderPaymentId;
									CRMspSelectLinkAccSettingDBIsActive_Result cRMspSelectLinkAccSettingDBIsActive_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDBIsActive_Result>((IEnumerable<CRMspSelectLinkAccSettingDBIsActive_Result>)list, (Func<CRMspSelectLinkAccSettingDBIsActive_Result, bool>)((CRMspSelectLinkAccSettingDBIsActive_Result m) => m.LinkAccSettingDBId == vmLkAcc2.DBId.GetValueOrDefault()));
									if (cRMspSelectLinkAccSettingDBIsActive_Result != null)
									{
										vmLkAcc2.DbName = cRMspSelectLinkAccSettingDBIsActive_Result.LinkAccSettingDbName ?? "";
										vmLkAcc2.DbTitle = cRMspSelectLinkAccSettingDBIsActive_Result.LinkAccSettingDbTitle ?? "";
									}
								}
								parameters.NotUsed_ListPayLinkAccData.AddRange(list6);
							}
							parameters.NotUsed_ListPrintBuyOrderPayments = list5;
							parameters.ListDyPrintCmpForm = new List<CRMspDyPrintCmpForm_Result>();
							parameters.ListDyPrintPrsForm = new List<CRMspDyPrintPrsForm_Result>();
							parameters.ListDyPrintPrjForm = new List<CRMspDyPrintPrjForm_Result>();
							parameters.ListDyPrintBordForm = new List<CRMspDyPrintBordForm_Result>();
							parameters.ListPrintProjectInformationTree = new List<CRMspPrintProjectInformationTree_Result>();
							if (wSspRpt_PrintBuyOrder_Result != null)
							{
								_ = wSspRpt_PrintBuyOrder_Result.bordCompanyId;
								parameters.ListDyPrintCmpForm = Enumerable.ToList<CRMspDyPrintCmpForm_Result>((IEnumerable<CRMspDyPrintCmpForm_Result>)cRMEntities.CRMspDyPrintCmpForm(wSspRpt_PrintBuyOrder_Result.bordCompanyId, currLangId, defLangId, userId, result2));
								if (wSspRpt_PrintBuyOrder_Result.bordCompanyPersonId.HasValue)
								{
									parameters.ListDyPrintPrsForm = Enumerable.ToList<CRMspDyPrintPrsForm_Result>((IEnumerable<CRMspDyPrintPrsForm_Result>)cRMEntities.CRMspDyPrintPrsForm(wSspRpt_PrintBuyOrder_Result.bordCompanyPersonId, currLangId, defLangId, userId, result2));
								}
								if (wSspRpt_PrintBuyOrder_Result.bordProjectId.HasValue)
								{
									parameters.ListDyPrintPrjForm = Enumerable.ToList<CRMspDyPrintPrjForm_Result>((IEnumerable<CRMspDyPrintPrjForm_Result>)cRMEntities.CRMspDyPrintPrjForm(wSspRpt_PrintBuyOrder_Result.bordProjectId, currLangId, defLangId, userId, result2));
									parameters.ListPrintProjectInformationTree = Enumerable.ToList<CRMspPrintProjectInformationTree_Result>((IEnumerable<CRMspPrintProjectInformationTree_Result>)cRMEntities.CRMspPrintProjectInformationTree(wSspRpt_PrintBuyOrder_Result.bordProjectId, currLangId, defLangId));
								}
								parameters.ListDyPrintBordForm = Enumerable.ToList<CRMspDyPrintBordForm_Result>((IEnumerable<CRMspDyPrintBordForm_Result>)_dbI.CRMspDyPrintBordForm(wSspRpt_PrintBuyOrder_Result.BuyOrderID, currLangId, defLangId, userId, result2));
							}
							parameters.Signature = "";
							MobspSelectUserSignatureByUserId_Result mobspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<MobspSelectUserSignatureByUserId_Result>((IEnumerable<MobspSelectUserSignatureByUserId_Result>)cRMEntities.MobspSelectUserSignatureByUserId(UserLogin.CurrentUser.UserId));
							if (mobspSelectUserSignatureByUserId_Result != null && mobspSelectUserSignatureByUserId_Result.Signature != null && mobspSelectUserSignatureByUserId_Result.Signature.Length != 0)
							{
								parameters.Signature = Convert.ToBase64String(mobspSelectUserSignatureByUserId_Result.Signature);
							}
							parameters.SignatureReferUser = null;
							parameters.SignatureFirstUser = null;
							parameters.SignatureLastEditUser = null;
							parameters.SignatureVerifierUser = null;
							mobspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<MobspSelectUserSignatureByUserId_Result>((IEnumerable<MobspSelectUserSignatureByUserId_Result>)cRMEntities.MobspSelectUserSignatureByUserId(wSspRpt_PrintBuyOrder_Result.bordReferUserId));
							if (mobspSelectUserSignatureByUserId_Result != null && mobspSelectUserSignatureByUserId_Result.Signature != null && mobspSelectUserSignatureByUserId_Result.Signature.Length != 0)
							{
								parameters.SignatureReferUser = mobspSelectUserSignatureByUserId_Result.Signature;
							}
							mobspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<MobspSelectUserSignatureByUserId_Result>((IEnumerable<MobspSelectUserSignatureByUserId_Result>)cRMEntities.MobspSelectUserSignatureByUserId(wSspRpt_PrintBuyOrder_Result.FirstRegisterUserId.GetValueOrDefault()));
							if (mobspSelectUserSignatureByUserId_Result != null && mobspSelectUserSignatureByUserId_Result.Signature != null && mobspSelectUserSignatureByUserId_Result.Signature.Length != 0)
							{
								parameters.SignatureFirstUser = mobspSelectUserSignatureByUserId_Result.Signature;
							}
							mobspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<MobspSelectUserSignatureByUserId_Result>((IEnumerable<MobspSelectUserSignatureByUserId_Result>)cRMEntities.MobspSelectUserSignatureByUserId(wSspRpt_PrintBuyOrder_Result.UserId));
							if (mobspSelectUserSignatureByUserId_Result != null && mobspSelectUserSignatureByUserId_Result.Signature != null && mobspSelectUserSignatureByUserId_Result.Signature.Length != 0)
							{
								parameters.SignatureLastEditUser = mobspSelectUserSignatureByUserId_Result.Signature;
							}
							mobspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<MobspSelectUserSignatureByUserId_Result>((IEnumerable<MobspSelectUserSignatureByUserId_Result>)cRMEntities.MobspSelectUserSignatureByUserId(wSspRpt_PrintBuyOrder_Result.bordVerifierId));
							if (mobspSelectUserSignatureByUserId_Result != null && mobspSelectUserSignatureByUserId_Result.Signature != null && mobspSelectUserSignatureByUserId_Result.Signature.Length != 0)
							{
								parameters.SignatureVerifierUser = mobspSelectUserSignatureByUserId_Result.Signature;
							}
							parameters.NotUsed_ListPrintBuyOrderVerificationRequestDetails = new List<WSspRpt_PrintVerificationRequestDetails_Result>();
							if (wSspRpt_PrintBuyOrder_Result != null && wSspRpt_PrintBuyOrder_Result.bordVerificationWorkFlowId.HasValue)
							{
								parameters.NotUsed_ListPrintBuyOrderVerificationRequestDetails = Enumerable.ToList<WSspRpt_PrintVerificationRequestDetails_Result>((IEnumerable<WSspRpt_PrintVerificationRequestDetails_Result>)cRMEntities.WSspRpt_PrintVerificationRequestDetails(wSspRpt_PrintBuyOrder_Result.BuyOrderID, 40, wSspRpt_PrintBuyOrder_Result.bordVerificationWorkFlowId, currLangId, defLangId));
								if (parameters.NotUsed_ListPrintBuyOrderVerificationRequestDetails != null && Enumerable.Any<WSspRpt_PrintVerificationRequestDetails_Result>((IEnumerable<WSspRpt_PrintVerificationRequestDetails_Result>)parameters.NotUsed_ListPrintBuyOrderVerificationRequestDetails))
								{
									foreach (WSspRpt_PrintVerificationRequestDetails_Result notUsed_ListPrintBuyOrderVerificationRequestDetail in parameters.NotUsed_ListPrintBuyOrderVerificationRequestDetails)
									{
										if (currLangId != 1065)
										{
											if (!string.IsNullOrEmpty(notUsed_ListPrintBuyOrderVerificationRequestDetail.VerifyDatePersian))
											{
												notUsed_ListPrintBuyOrderVerificationRequestDetail.VerifyDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintBuyOrderVerificationRequestDetail.VerifyDatePersian.Replace("/", "")).Replace("/", "");
											}
											if (!string.IsNullOrEmpty(notUsed_ListPrintBuyOrderVerificationRequestDetail.FirstRegisterDatePersian))
											{
												notUsed_ListPrintBuyOrderVerificationRequestDetail.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintBuyOrderVerificationRequestDetail.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
											}
											if (!string.IsNullOrEmpty(notUsed_ListPrintBuyOrderVerificationRequestDetail.RegisterDatePersian))
											{
												notUsed_ListPrintBuyOrderVerificationRequestDetail.RegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintBuyOrderVerificationRequestDetail.RegisterDatePersian.Replace("/", "")).Replace("/", "");
											}
											if (!string.IsNullOrEmpty(notUsed_ListPrintBuyOrderVerificationRequestDetail.VerificationReqDatePersian))
											{
												notUsed_ListPrintBuyOrderVerificationRequestDetail.VerificationReqDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintBuyOrderVerificationRequestDetail.VerificationReqDatePersian.Replace("/", "")).Replace("/", "");
											}
											if (!string.IsNullOrEmpty(notUsed_ListPrintBuyOrderVerificationRequestDetail.VerificationReqExpiredDatePersian))
											{
												notUsed_ListPrintBuyOrderVerificationRequestDetail.VerificationReqExpiredDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintBuyOrderVerificationRequestDetail.VerificationReqExpiredDatePersian.Replace("/", "")).Replace("/", "");
											}
										}
										if (notUsed_ListPrintBuyOrderVerificationRequestDetail.VerifyUserSignature != null)
										{
											notUsed_ListPrintBuyOrderVerificationRequestDetail.VerifyUserSignatureStr = Convert.ToBase64String(notUsed_ListPrintBuyOrderVerificationRequestDetail.VerifyUserSignature);
										}
									}
								}
							}
							if (parameters.NotUsed_ListPrintBuyOrderVerificationRequestDetails == null)
							{
								parameters.NotUsed_ListPrintBuyOrderVerificationRequestDetails = new List<WSspRpt_PrintVerificationRequestDetails_Result>();
							}
							string text4 = "";
							if (wSspRpt_PrintBuyOrder_Result != null)
							{
								text4 = wSspRpt_PrintBuyOrder_Result.bordLinkAccData ?? "";
							}
							if (!string.IsNullOrWhiteSpace(text4))
							{
								List<BordLinkAccDataViewModel> list7 = new JavaScriptSerializer().Deserialize<List<BordLinkAccDataViewModel>>(text4);
								if (list7 != null && Enumerable.Any<BordLinkAccDataViewModel>((IEnumerable<BordLinkAccDataViewModel>)list7))
								{
									foreach (BordLinkAccDataViewModel vmLkAcc in list7)
									{
										vmLkAcc.BordId = buyOrderId;
										CRMspSelectLinkAccSettingDBIsActive_Result cRMspSelectLinkAccSettingDBIsActive_Result2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDBIsActive_Result>((IEnumerable<CRMspSelectLinkAccSettingDBIsActive_Result>)list, (Func<CRMspSelectLinkAccSettingDBIsActive_Result, bool>)((CRMspSelectLinkAccSettingDBIsActive_Result m) => m.LinkAccSettingDBId == vmLkAcc.DBId.GetValueOrDefault()));
										if (cRMspSelectLinkAccSettingDBIsActive_Result2 != null)
										{
											vmLkAcc.DbName = cRMspSelectLinkAccSettingDBIsActive_Result2.LinkAccSettingDbName ?? "";
											vmLkAcc.DbTitle = cRMspSelectLinkAccSettingDBIsActive_Result2.LinkAccSettingDbTitle ?? "";
										}
									}
									parameters.NotUsed_ListLinkAccData.AddRange(list7);
								}
							}
							if (parameters.NotUsed_ListLinkAccData == null)
							{
								parameters.NotUsed_ListLinkAccData = new List<BordLinkAccDataViewModel>();
							}
							if (parameters.NotUsed_ListPayLinkAccData == null)
							{
								parameters.NotUsed_ListPayLinkAccData = new List<PayLinkAccDataViewModel>();
							}
							int? printFormatID = ((parameters != null && wSspRpt_PrintBuyOrder_Result.bordPrintFormatId.HasValue) ? wSspRpt_PrintBuyOrder_Result.bordPrintFormatId : new int?(0));
							MobspReturnPrintFormatFileNameById_Result mobspReturnPrintFormatFileNameById_Result = Enumerable.FirstOrDefault<MobspReturnPrintFormatFileNameById_Result>((IEnumerable<MobspReturnPrintFormatFileNameById_Result>)cRMEntities.MobspReturnPrintFormatFileNameById(printFormatID));
							if ((mobspReturnPrintFormatFileNameById_Result?.CId).GetValueOrDefault() != 0 && !string.IsNullOrWhiteSpace(text2))
							{
								if (!text2.EndsWith("\\"))
								{
									text2 += "\\";
								}
								text2 = text2 + mobspReturnPrintFormatFileNameById_Result.CId + "\\";
							}
							if (mobspReturnPrintFormatFileNameById_Result != null)
							{
								text3 = mobspReturnPrintFormatFileNameById_Result.FileNameWeb;
							}
							if (string.IsNullOrEmpty(text3))
							{
								text3 = "BuyOrderPrint.mrt";
							}
							if (!System.IO.File.Exists(text2 + text3))
							{
								text3 = "BuyOrderPrint.mrt";
							}
							XmlSerializer val = new XmlSerializer(typeof(Mobile.Models.ReportModel.BuyOrderPrintRpt.Parameters));
							StringWriter stringWriter = new StringWriter();
							XmlWriter val2 = XmlWriter.Create((TextWriter)stringWriter);
							val.Serialize(val2, (object)parameters);
							DataSet val3 = new DataSet();
							val3.ReadXmlSchema(text + "BuyOrderPrint.xsd");
							XElement val4 = XElement.Parse(stringWriter.ToString());
							val3.ReadXml(((XNode)val4).CreateReader((ReaderOptions)0));
							stiReport.Load(text2 + text3);
							string text5 = "Integrated Security=False;Data Source={DBServer};Initial Catalog={DBName};Password={DBPass};User ID={DBUser}";
							text5 = text5.Replace("{DBServer}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBServer"]));
							text5 = text5.Replace("{DBName}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBName"]));
							text5 = text5.Replace("{DBUser}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBUser"]));
							text5 = text5.Replace("{DBPass}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBPass"]));
							((CollectionBase)stiReport.Dictionary.Databases).Clear();
							stiReport.Dictionary.Databases.Add(new StiSqlDatabase("CRMIdealExtra", text5));
							stiReport.Compile();
							stiReport.RegData(val3);
							stiReport.Render();
							string text6 = HttpContext.Current.Server.MapPath("~/Download") + "\\Reports\\Files\\" + token2.userId;
							if (!System.IO.Directory.Exists(text6))
							{
								System.IO.Directory.CreateDirectory(text6);
								CRM.General.IO.Directory.SetFullControlForEveryOne(text6);
							}
							string path = text6 + "\\Bord-" + token2.userId + "_" + buyOrderId + "-" + now.ToString("yyyyMMddHHmmssfff") + ".pdf";
							try
							{
								System.IO.File.Delete(path);
							}
							catch (Exception e)
							{
								ErrorSignal.FromCurrentContext().Raise(e);
								message = "خطا در یافت";
								data = null;
								status = ServiceResultStatus.Error;
							}
							StiJpegExportSettings stiJpegExportSettings = new StiJpegExportSettings
							{
								ImageResolution = 300
							};
							int currentPage = Enumerable.Count<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
							string text7 = text6 + "\\Bord-" + token2.userId + "_" + buyOrderId + "-" + now.ToString("yyyyMMddHHmmssfff") + ".pdf";
							string text8 = text6 + "\\Bord_Zip_" + token2.userId + "_" + buyOrderId;
							if (!System.IO.Directory.Exists(text8))
							{
								System.IO.Directory.CreateDirectory(text8);
								CRM.General.IO.Directory.SetFullControlForEveryOne(text8);
							}
							string file = text8 + "\\Bord_001.jpg";
							stiJpegExportSettings.PageRange = new StiPagesRange(currentPage);
							stiReport.ExportDocument(StiExportFormat.ImageJpeg, file, stiJpegExportSettings);
							string[] files = System.IO.Directory.GetFiles(text8);
							if (Enumerable.Any<string>((IEnumerable<string>)files))
							{
								PdfDocument pdfDocument = new PdfDocument();
								for (int i = 0; i < files.Length; i++)
								{
									PdfPage pdfPage = new PdfPage();
									StiPage stiPage = Enumerable.FirstOrDefault<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
									if (stiPage != null)
									{
										if (stiPage.Orientation == StiPageOrientation.Landscape)
										{
											pdfPage.Orientation = PageOrientation.Landscape;
										}
										try
										{
											PaperKind paperSize = stiPage.PaperSize;
											switch (paperSize - 8)
											{
											default:
												if ((int)paperSize != 66)
												{
													break;
												}
												pdfPage.Size = PageSize.A2;
												goto end_IL_1665;
											case 0:
												pdfPage.Size = PageSize.A3;
												goto end_IL_1665;
											case 1:
												pdfPage.Size = PageSize.A4;
												goto end_IL_1665;
											case 3:
												pdfPage.Size = PageSize.A5;
												goto end_IL_1665;
											case 4:
												pdfPage.Size = PageSize.B4;
												goto end_IL_1665;
											case 5:
												pdfPage.Size = PageSize.B5;
												goto end_IL_1665;
											case 2:
												break;
											}
											pdfPage.Size = PageSize.A4;
											end_IL_1665:;
										}
										catch (Exception e2)
										{
											ErrorSignal.FromCurrentContext().Raise(e2);
											pdfPage.Size = PageSize.A4;
										}
									}
									pdfDocument.Pages.Add(pdfPage);
									XGraphics xGraphics = XGraphics.FromPdfPage(pdfDocument.Pages[i]);
									XImage xImage = XImage.FromFile(files[i]);
									xGraphics.DrawImage(xImage, 0.0, 0.0);
									xImage.Dispose();
									xGraphics.Dispose();
								}
								pdfDocument.Save(text7);
								pdfDocument.Close();
							}
							try
							{
								DirectoryInfo directoryInfo = new DirectoryInfo(text8);
								FileInfo[] files2 = directoryInfo.GetFiles();
								for (int j = 0; j < files2.Length; j++)
								{
									files2[j].Delete();
								}
								DirectoryInfo[] directories = directoryInfo.GetDirectories();
								for (int j = 0; j < directories.Length; j++)
								{
									directories[j].Delete(recursive: true);
								}
								if (System.IO.Directory.Exists(text8))
								{
									System.IO.Directory.Delete(text8);
								}
							}
							catch (Exception e3)
							{
								ErrorSignal.FromCurrentContext().Raise(e3);
							}
							path = text7;
							string[] array = HttpContext.Current.Request.Url.AbsoluteUri.Split(new string[1] { "/api/" }, StringSplitOptions.None);
							string text9 = "";
							if (array != null)
							{
								string text10 = "/Download/Reports/Files/" + token2.userId + "/Bord-" + token2.userId + "_" + buyOrderId + "-" + now.ToString("yyyyMMddHHmmssfff") + ".pdf";
								text9 = ((array[0] != null && array[0] != "") ? (array[0] + text10) : "");
							}
							data = (System.IO.File.Exists(path) ? text9 : "");
							message = Messages.MobMsgSuccessAction;
							status = ServiceResultStatus.Success;
						}
						else
						{
							message = Messages.MobMsgErrorFileNotExist;
							data = null;
							status = ServiceResultStatus.Error;
						}
					}
					catch (Exception e4)
					{
						message = Messages.MobMsgErrorDoneOperation;
						data = null;
						status = ServiceResultStatus.Error;
						ErrorSignal.FromCurrentContext().Raise(e4);
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
		catch (Exception e5)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e5);
		}
		finally
		{
			cRMEntities?.Dispose();
			if (_dbI != null)
			{
				_dbI.Dispose();
			}
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
	public ServiceResult<string> GetPdfCompanyAccountingDetail(int cmpId, int printFormatId, int? ln = null, int? pfCId = null)
	{
		//IL_0850: Unknown result type (might be due to invalid IL or missing references)
		//IL_0855: Unknown result type (might be due to invalid IL or missing references)
		//IL_0857: Unknown result type (might be due to invalid IL or missing references)
		//IL_085a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0878: Expected I4, but got Unknown
		//IL_0878: Unknown result type (might be due to invalid IL or missing references)
		//IL_087c: Invalid comparison between Unknown and I4
		//IL_04e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0506: Unknown result type (might be due to invalid IL or missing references)
		//IL_050d: Expected O, but got Unknown
		//IL_0538: Unknown result type (might be due to invalid IL or missing references)
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
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
					try
					{
						cRMEntities = new CRMEntities();
						cRMSpEntities = new CRMSpEntities();
						StiReport stiReport = new StiReport();
						if (cmpId > 0)
						{
							string text = HttpContext.Current.Server.MapPath("~/Areas/Reports/ReportDatasets/");
							string text2 = HttpContext.Current.Server.MapPath("~/Areas/Reports/ReportFiles/");
							string text3 = "";
							Mobile.Models.ReportModel.PrintCompanyAccountingDetailsRpt.Parameters parameters = new Mobile.Models.ReportModel.PrintCompanyAccountingDetailsRpt.Parameters();
							int userId = token2.userId;
							DateTime now = DateTime.Now;
							string rptDate = now.ToString("yyyy/MM/dd");
							string rptDay = now.ToString("dddd");
							Reports reports = new Reports();
							parameters.SysSetting = reports.GetSysSetting();
							parameters.ReportDateTime = now;
							parameters.ReporterUserName = UserLogin.CurrentUser.FullName;
							parameters.ReportDay = DateTimeClass.DefineDayeOfWeekPersian(parameters.ReportDateTime.DayOfWeek.ToString());
							parameters.ReportDateTime.ToString("yyyy/MM/dd");
							string rptOrderTitle = Labels.RptOrderTitle;
							string rptPaymentTitle = Labels.RptPaymentTitle;
							string rptWastedTitle = Labels.RptWastedTitle;
							string rptBuyOrderTitle = Labels.RptBuyOrderTitle;
							string rptPreOrderTitle = Labels.RptPreOrderTitle;
							string rptSaleOrderTitle = Labels.RptSaleOrderTitle;
							string rptCmpMoneyBagTitle = Labels.RptCmpMoneyBagTitle;
							int result3 = 0;
							if (UserLogin.CurrentUser != null)
							{
								int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
							}
							parameters.NotUsed_ListCRMspReturnCmpAccountingDetails = Enumerable.ToList<CRMspReturnCmpAccountingDetails_Result>((IEnumerable<CRMspReturnCmpAccountingDetails_Result>)cRMSpEntities.CRMspReturnCmpAccountingDetails(cmpId, num, result2, rptOrderTitle, rptPaymentTitle, rptWastedTitle, rptBuyOrderTitle, rptPreOrderTitle, rptSaleOrderTitle, now, now, userId, rptDate, rptDay, rptCmpMoneyBagTitle, result3));
							if (Enumerable.Any<CRMspReturnCmpAccountingDetails_Result>((IEnumerable<CRMspReturnCmpAccountingDetails_Result>)parameters.NotUsed_ListCRMspReturnCmpAccountingDetails))
							{
								DateTime dateTime = default(DateTime);
								string text4 = "";
								foreach (CRMspReturnCmpAccountingDetails_Result notUsed_ListCRMspReturnCmpAccountingDetail in parameters.NotUsed_ListCRMspReturnCmpAccountingDetails)
								{
									try
									{
										if (!string.IsNullOrEmpty(notUsed_ListCRMspReturnCmpAccountingDetail.DatePer))
										{
											notUsed_ListCRMspReturnCmpAccountingDetail.DatePer = notUsed_ListCRMspReturnCmpAccountingDetail.DatePer.Replace("/", "").Replace("-", "").Replace("_", "")
												.Replace(".", "")
												.Replace(",", "")
												.Replace("\\", "");
											text4 = PersianDate.GetFormatetdDate(notUsed_ListCRMspReturnCmpAccountingDetail.DatePer.Replace("/", ""));
											text4 = text4 + " " + DateTime.Now.ToString("HH:mm:ss");
											switch (num)
											{
											case 1065:
												notUsed_ListCRMspReturnCmpAccountingDetail.DatetimePerWithSlash = DateTime.Parse(text4, new PersianCulture()).ToString("yyyy/MM/dd");
												break;
											case 1025:
												notUsed_ListCRMspReturnCmpAccountingDetail.DatetimePerWithSlash = DateTime.Parse(PersianDate.GetShamsi2Miladi(notUsed_ListCRMspReturnCmpAccountingDetail.DatePer.Replace("/", ""))).ToString("yyyy/MM/dd", new CultureInfo("ar-SA"));
												break;
											default:
												notUsed_ListCRMspReturnCmpAccountingDetail.DatetimePerWithSlash = DateTime.Parse(PersianDate.GetShamsi2Miladi(notUsed_ListCRMspReturnCmpAccountingDetail.DatePer.Replace("/", ""))).ToString("yyyy/MM/dd", new CultureInfo("en-US"));
												break;
											}
										}
									}
									catch (Exception)
									{
									}
								}
							}
							MobspReturnPrintFormatFileNameById_Result mobspReturnPrintFormatFileNameById_Result = Enumerable.FirstOrDefault<MobspReturnPrintFormatFileNameById_Result>((IEnumerable<MobspReturnPrintFormatFileNameById_Result>)cRMEntities.MobspReturnPrintFormatFileNameById(printFormatId));
							if ((mobspReturnPrintFormatFileNameById_Result?.CId).GetValueOrDefault() != 0 && !string.IsNullOrWhiteSpace(text2))
							{
								if (!text2.EndsWith("\\"))
								{
									text2 += "\\";
								}
								text2 = text2 + mobspReturnPrintFormatFileNameById_Result.CId + "\\";
							}
							if (mobspReturnPrintFormatFileNameById_Result != null)
							{
								text3 = mobspReturnPrintFormatFileNameById_Result.FileNameWeb;
							}
							if (string.IsNullOrEmpty(text3))
							{
								text3 = "PrintCompanyAccountingDetails.mrt";
							}
							if (!System.IO.File.Exists(text2 + text3))
							{
								text3 = "PrintCompanyAccountingDetails.mrt";
							}
							XmlSerializer val = new XmlSerializer(typeof(Mobile.Models.ReportModel.PrintCompanyAccountingDetailsRpt.Parameters));
							StringWriter stringWriter = new StringWriter();
							XmlWriter val2 = XmlWriter.Create((TextWriter)stringWriter);
							val.Serialize(val2, (object)parameters);
							DataSet val3 = new DataSet();
							val3.ReadXmlSchema(text + "PrintCompanyAccountingDetails.xsd");
							XElement val4 = XElement.Parse(stringWriter.ToString());
							val3.ReadXml(((XNode)val4).CreateReader((ReaderOptions)0));
							stiReport.Load(text2 + text3);
							string text5 = "Integrated Security=False;Data Source={DBServer};Initial Catalog={DBName};Password={DBPass};User ID={DBUser}";
							text5 = text5.Replace("{DBServer}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBServer"]));
							text5 = text5.Replace("{DBName}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBName"]));
							text5 = text5.Replace("{DBUser}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBUser"]));
							text5 = text5.Replace("{DBPass}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBPass"]));
							((CollectionBase)stiReport.Dictionary.Databases).Clear();
							stiReport.Dictionary.Databases.Add(new StiSqlDatabase("CRMIdealExtra", text5));
							stiReport.Compile();
							stiReport.RegData(val3);
							stiReport.Render();
							string text6 = HttpContext.Current.Server.MapPath("~/Download") + "\\Reports\\Files\\" + token2.userId;
							if (!System.IO.Directory.Exists(text6))
							{
								System.IO.Directory.CreateDirectory(text6);
								CRM.General.IO.Directory.SetFullControlForEveryOne(text6);
							}
							string path = text6 + "\\Company-" + token2.userId + "-" + cmpId + "-" + now.ToString("yyyyMMddHHmmssfff") + ".pdf";
							try
							{
								System.IO.File.Delete(path);
							}
							catch (Exception e)
							{
								ErrorSignal.FromCurrentContext().Raise(e);
								message = "خطا در یافت";
								data = null;
								status = ServiceResultStatus.Error;
							}
							StiJpegExportSettings stiJpegExportSettings = new StiJpegExportSettings
							{
								ImageResolution = 300
							};
							int currentPage = Enumerable.Count<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
							string text7 = text6 + "\\Company-" + token2.userId + "-" + cmpId + "-" + now.ToString("yyyyMMddHHmmssfff") + ".pdf";
							string text8 = text6 + "\\Company_Zip_" + token2.userId + "-" + cmpId;
							if (!System.IO.Directory.Exists(text8))
							{
								System.IO.Directory.CreateDirectory(text8);
								CRM.General.IO.Directory.SetFullControlForEveryOne(text8);
							}
							string file = text8 + "\\Company_001.jpg";
							stiJpegExportSettings.PageRange = new StiPagesRange(currentPage);
							stiReport.ExportDocument(StiExportFormat.ImageJpeg, file, stiJpegExportSettings);
							string[] files = System.IO.Directory.GetFiles(text8);
							if (Enumerable.Any<string>((IEnumerable<string>)files))
							{
								PdfDocument pdfDocument = new PdfDocument();
								for (int i = 0; i < files.Length; i++)
								{
									PdfPage pdfPage = new PdfPage();
									StiPage stiPage = Enumerable.FirstOrDefault<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
									if (stiPage != null)
									{
										if (stiPage.Orientation == StiPageOrientation.Landscape)
										{
											pdfPage.Orientation = PageOrientation.Landscape;
										}
										try
										{
											PaperKind paperSize = stiPage.PaperSize;
											switch (paperSize - 8)
											{
											default:
												if ((int)paperSize != 66)
												{
													break;
												}
												pdfPage.Size = PageSize.A2;
												goto end_IL_084e;
											case 0:
												pdfPage.Size = PageSize.A3;
												goto end_IL_084e;
											case 1:
												pdfPage.Size = PageSize.A4;
												goto end_IL_084e;
											case 3:
												pdfPage.Size = PageSize.A5;
												goto end_IL_084e;
											case 4:
												pdfPage.Size = PageSize.B4;
												goto end_IL_084e;
											case 5:
												pdfPage.Size = PageSize.B5;
												goto end_IL_084e;
											case 2:
												break;
											}
											pdfPage.Size = PageSize.A4;
											end_IL_084e:;
										}
										catch (Exception e2)
										{
											ErrorSignal.FromCurrentContext().Raise(e2);
											pdfPage.Size = PageSize.A4;
										}
									}
									pdfDocument.Pages.Add(pdfPage);
									XGraphics xGraphics = XGraphics.FromPdfPage(pdfDocument.Pages[i]);
									XImage xImage = XImage.FromFile(files[i]);
									xGraphics.DrawImage(xImage, 0.0, 0.0);
									xImage.Dispose();
									xGraphics.Dispose();
								}
								pdfDocument.Save(text7);
								pdfDocument.Close();
							}
							try
							{
								DirectoryInfo directoryInfo = new DirectoryInfo(text8);
								FileInfo[] files2 = directoryInfo.GetFiles();
								for (int j = 0; j < files2.Length; j++)
								{
									files2[j].Delete();
								}
								DirectoryInfo[] directories = directoryInfo.GetDirectories();
								for (int j = 0; j < directories.Length; j++)
								{
									directories[j].Delete(recursive: true);
								}
								if (System.IO.Directory.Exists(text8))
								{
									System.IO.Directory.Delete(text8);
								}
							}
							catch (Exception e3)
							{
								ErrorSignal.FromCurrentContext().Raise(e3);
							}
							path = text7;
							string[] array = HttpContext.Current.Request.Url.AbsoluteUri.Split(new string[1] { "/api/" }, StringSplitOptions.None);
							string text9 = "";
							if (array != null)
							{
								string text10 = "/Download/Reports/Files/" + token2.userId + "/Company-" + token2.userId + "-" + cmpId + "-" + now.ToString("yyyyMMddHHmmssfff") + ".pdf";
								text9 = ((array[0] != null && array[0] != "") ? (array[0] + text10) : "");
							}
							data = (System.IO.File.Exists(path) ? text9 : "");
							message = Messages.MobMsgSuccessAction;
							status = ServiceResultStatus.Success;
						}
						else
						{
							message = Messages.MobMsgErrorFileNotExist;
							data = null;
							status = ServiceResultStatus.Error;
						}
					}
					catch (Exception e4)
					{
						message = Messages.MobMsgErrorDoneOperation;
						data = null;
						status = ServiceResultStatus.Error;
						ErrorSignal.FromCurrentContext().Raise(e4);
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
		catch (Exception e5)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e5);
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

	public string HolooGetCmpAccountingDetail(int cmpId, int countDecimal = 0)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			CRMEntities cRMEntities = null;
			if (cmpId > 0)
			{
				cRMEntities = new CRMEntities();
				MobspSelectCompanyAccLinkFields_Result mobspSelectCompanyAccLinkFields_Result = Enumerable.FirstOrDefault<MobspSelectCompanyAccLinkFields_Result>((IEnumerable<MobspSelectCompanyAccLinkFields_Result>)cRMEntities.MobspSelectCompanyAccLinkFields(cmpId, lCID, result2));
				if (mobspSelectCompanyAccLinkFields_Result != null)
				{
					if (!string.IsNullOrEmpty(mobspSelectCompanyAccLinkFields_Result.cmpLinkAccCode))
					{
						List<CRMspSelectLinkAccHolooSetting_Result> list = Enumerable.ToList<CRMspSelectLinkAccHolooSetting_Result>((IEnumerable<CRMspSelectLinkAccHolooSetting_Result>)cRMEntities.CRMspSelectLinkAccHolooSetting(0, "Setting", lCID, result2));
						if (list != null)
						{
							string text = "";
							CRMspSelectLinkAccHolooSetting_Result cRMspSelectLinkAccHolooSetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccHolooSetting_Result>((IEnumerable<CRMspSelectLinkAccHolooSetting_Result>)list, (Func<CRMspSelectLinkAccHolooSetting_Result, bool>)((CRMspSelectLinkAccHolooSetting_Result m) => m.LinkAccHolooSettingId == 1));
							if (cRMspSelectLinkAccHolooSetting_Result != null)
							{
								text = cRMspSelectLinkAccHolooSetting_Result.PartValue ?? "";
							}
							string text2 = "";
							CRMspSelectLinkAccHolooSetting_Result cRMspSelectLinkAccHolooSetting_Result2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHolooSetting_Result>((IEnumerable<CRMspSelectLinkAccHolooSetting_Result>)list, (Func<CRMspSelectLinkAccHolooSetting_Result, bool>)((CRMspSelectLinkAccHolooSetting_Result m) => m.LinkAccHolooSettingId == 2));
							if (cRMspSelectLinkAccHolooSetting_Result2 != null)
							{
								text2 = cRMspSelectLinkAccHolooSetting_Result2.PartValue ?? "";
							}
							string text3 = "";
							CRMspSelectLinkAccHolooSetting_Result cRMspSelectLinkAccHolooSetting_Result3 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHolooSetting_Result>((IEnumerable<CRMspSelectLinkAccHolooSetting_Result>)list, (Func<CRMspSelectLinkAccHolooSetting_Result, bool>)((CRMspSelectLinkAccHolooSetting_Result m) => m.LinkAccHolooSettingId == 3));
							if (cRMspSelectLinkAccHolooSetting_Result3 != null)
							{
								text3 = cRMspSelectLinkAccHolooSetting_Result3.PartValue ?? "";
							}
							string text4 = "";
							CRMspSelectLinkAccHolooSetting_Result cRMspSelectLinkAccHolooSetting_Result4 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHolooSetting_Result>((IEnumerable<CRMspSelectLinkAccHolooSetting_Result>)list, (Func<CRMspSelectLinkAccHolooSetting_Result, bool>)((CRMspSelectLinkAccHolooSetting_Result m) => m.LinkAccHolooSettingId == 4));
							if (cRMspSelectLinkAccHolooSetting_Result4 != null)
							{
								text4 = cRMspSelectLinkAccHolooSetting_Result4.PartValue ?? "";
							}
							string text5 = "";
							if (!string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(text2) && !string.IsNullOrWhiteSpace(text3) && !string.IsNullOrWhiteSpace(text4))
							{
								if (!text.EndsWith("/"))
								{
									text += "/";
								}
								HolooLoginViewModel holooLoginViewModel = new HolooLoginViewModel();
								holooLoginViewModel.userinfo = new HolooUserInfoViewModel
								{
									dbname = text2,
									username = text3,
									userpass = text4
								};
								string text6 = "api/Login";
								HttpResponseMessage result3 = new HttpClient
								{
									BaseAddress = new Uri(text + text6),
									DefaultRequestHeaders = 
									{
										Accept = 
										{
											new MediaTypeWithQualityHeaderValue("application/json")
										}
									}
								}.PostAsync(content: new StringContent(JsonConvert.SerializeObject(holooLoginViewModel), Encoding.UTF8, "application/json"), requestUri: text + text6).Result;
								if (!result3.IsSuccessStatusCode)
								{
									Exception e = new Exception(Messages.FOMsgErrorDoneOperation + "<br> Error in login");
									ErrorSignal.FromCurrentContext().Raise(e);
									return Labels.FOMsgErrorTitle;
								}
								HolooLoginResultViewModel holooLoginResultViewModel = JsonConvert.DeserializeObject<HolooLoginResultViewModel>(result3.Content.ReadAsStringAsync().Result);
								if (holooLoginResultViewModel == null)
								{
									Exception e2 = new Exception(Messages.FOMsgErrorDoneOperation + "<br> Error in login");
									ErrorSignal.FromCurrentContext().Raise(e2);
									return Labels.FOMsgErrorTitle;
								}
								if (holooLoginResultViewModel.Login == null)
								{
									Exception e3 = new Exception(Messages.FOMsgErrorDoneOperation + "<br> Error in login");
									ErrorSignal.FromCurrentContext().Raise(e3);
									return Labels.FOMsgErrorTitle;
								}
								if (!holooLoginResultViewModel.Login.State)
								{
									string fOMsgErrorDoneOperation = Messages.FOMsgErrorDoneOperation;
									string error = holooLoginResultViewModel.Login.Error;
									_ = holooLoginResultViewModel.Login.ErrorCode;
									Exception e4 = new Exception(string.Concat(fOMsgErrorDoneOperation, "<br>", error, " code:" + holooLoginResultViewModel.Login.ErrorCode));
									ErrorSignal.FromCurrentContext().Raise(e4);
									return Labels.FOMsgErrorTitle;
								}
								text5 = holooLoginResultViewModel.Login.Token ?? "";
								if (string.IsNullOrWhiteSpace(text5))
								{
									Exception e5 = new Exception(Messages.FOMsgErrorDoneOperation + "<br> Token is null");
									ErrorSignal.FromCurrentContext().Raise(e5);
									return Labels.FOMsgErrorTitle;
								}
								if (!string.IsNullOrWhiteSpace(text5))
								{
									string text7 = "?code=" + mobspSelectCompanyAccLinkFields_Result.cmpLinkAccCode;
									HttpClient httpClient = new HttpClient();
									httpClient.BaseAddress = new Uri(text);
									httpClient.DefaultRequestHeaders.Add("Authorization", text5);
									httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
									string requestUri = "api/Customer" + text7;
									HttpResponseMessage result4 = httpClient.GetAsync(requestUri).Result;
									if (!result4.IsSuccessStatusCode)
									{
										Exception e6 = new Exception(Messages.FOMsgErrorDoneOperation + " (get customer information from Holoo) ");
										ErrorSignal.FromCurrentContext().Raise(e6);
										return Labels.FOMsgErrorTitle;
									}
									HolooCustomerListViewModel holooCustomerListViewModel = JsonConvert.DeserializeObject<HolooCustomerListViewModel>(result4.Content.ReadAsStringAsync().Result);
									if (holooCustomerListViewModel != null && holooCustomerListViewModel.Customer != null)
									{
										if (holooCustomerListViewModel.Customer.Count != 1)
										{
											Exception e7 = new Exception(Messages.FOMsgErrorDoneOperation + " (not find customer information from Holoo or find more one than) ");
											ErrorSignal.FromCurrentContext().Raise(e7);
											return Labels.FOMsgErrorTitle;
										}
										decimal valueOrDefault = holooCustomerListViewModel.Customer[0].Mandeh.GetValueOrDefault();
										result = countDecimal switch
										{
											0 => $"{valueOrDefault:N0}", 
											-1 => valueOrDefault.ToString(), 
											_ => $"{valueOrDefault:N2}", 
										};
									}
								}
							}
							else
							{
								Exception e8 = new Exception(Messages.FOMsgErrorInReadingSetting);
								ErrorSignal.FromCurrentContext().Raise(e8);
								result = Labels.FOMsgErrorTitle;
							}
						}
						else
						{
							Exception e9 = new Exception(Messages.FOMsgErrorInReadingSetting);
							ErrorSignal.FromCurrentContext().Raise(e9);
							result = Labels.FOMsgErrorTitle;
						}
					}
					else
					{
						Exception e10 = new Exception(Messages.ErrorNotFound + "(This customer by name " + mobspSelectCompanyAccLinkFields_Result.cmpName + " not have code");
						ErrorSignal.FromCurrentContext().Raise(e10);
						result = Labels.FOMsgErrorTitle;
					}
				}
				else
				{
					Exception e11 = new Exception(Messages.ErrorNotFound + "(customer)");
					ErrorSignal.FromCurrentContext().Raise(e11);
					result = Labels.FOMsgErrorTitle;
				}
			}
			else
			{
				Exception e12 = new Exception(Messages.ErrorNotFound + "(customer)");
				ErrorSignal.FromCurrentContext().Raise(e12);
				result = Labels.FOMsgErrorTitle;
			}
		}
		catch (Exception e13)
		{
			ErrorSignal.FromCurrentContext().Raise(e13);
			result = Labels.FOMsgErrorTitle;
		}
		return result;
	}

	public string SepGetCmpAccountingDetail(int cmpId, ref decimal linkAccRemain, int linkAccSettingDBId = 0)
	{
		string text = "";
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		try
		{
			_ = UserLogin.CurrentUser;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			cRMEntities = new CRMEntities();
			cRMSpEntities = new CRMSpEntities();
			if (cmpId > 0)
			{
				if (Enumerable.FirstOrDefault<CRMspSelectCompanyById_Result>((IEnumerable<CRMspSelectCompanyById_Result>)cRMEntities.CRMspSelectCompanyById(cmpId, lCID, result)) != null)
				{
					ObjectParameter objectParameter = new ObjectParameter("payRemain", typeof(decimal));
					ObjectParameter debitBalance = new ObjectParameter("debitBalance", typeof(decimal));
					ObjectParameter creditBalance = new ObjectParameter("creditBalance", typeof(decimal));
					bool result2 = false;
					if (linkAccSettingDBId == 0)
					{
						List<CRMspSelectLinkAccSettingDBIsActive_Result> linkAccSettingDBList = OtherSystems.GetLinkAccSettingDBList(1);
						if (linkAccSettingDBList != null && Enumerable.Any<CRMspSelectLinkAccSettingDBIsActive_Result>((IEnumerable<CRMspSelectLinkAccSettingDBIsActive_Result>)linkAccSettingDBList))
						{
							CRMspSelectLinkAccSettingDBIsActive_Result cRMspSelectLinkAccSettingDBIsActive_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDBIsActive_Result>((IEnumerable<CRMspSelectLinkAccSettingDBIsActive_Result>)linkAccSettingDBList);
							if (cRMspSelectLinkAccSettingDBIsActive_Result != null)
							{
								linkAccSettingDBId = cRMspSelectLinkAccSettingDBIsActive_Result.LinkAccSettingDBId;
							}
						}
					}
					CRMspSelectLinkAccSetting_Result cRMspSelectLinkAccSetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)cRMSpEntities.CRMspSelectLinkAccSetting(0, "CmpAccountRemain", lCID, result, 1, linkAccSettingDBId, "ShowCmpAccountingSummary"));
					if (cRMspSelectLinkAccSetting_Result != null)
					{
						bool.TryParse(cRMspSelectLinkAccSetting_Result.PartValue, out result2);
					}
					if (result2)
					{
						CRMspLkSepReturnCmpAccountingSummary_Result cRMspLkSepReturnCmpAccountingSummary_Result = Enumerable.FirstOrDefault<CRMspLkSepReturnCmpAccountingSummary_Result>((IEnumerable<CRMspLkSepReturnCmpAccountingSummary_Result>)cRMSpEntities.CRMspLkSepReturnCmpAccountingSummary(cmpId, objectParameter, linkAccSettingDBId));
						if (cRMspLkSepReturnCmpAccountingSummary_Result != null)
						{
							decimal result3 = default(decimal);
							decimal.TryParse(cRMspLkSepReturnCmpAccountingSummary_Result.Remain.ToString(), out result3);
							linkAccRemain = result3;
							return "";
						}
						linkAccRemain = default(decimal);
						return "";
					}
					string value = "";
					CRMspSelectLinkAccSetting_Result cRMspSelectLinkAccSetting_Result2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)cRMSpEntities.CRMspSelectLinkAccSetting(0, "CmpAccountRemain", lCID, result, 1, linkAccSettingDBId, "CmpAccountRemainingAccCode"));
					if (cRMspSelectLinkAccSetting_Result2 != null)
					{
						value = cRMspSelectLinkAccSetting_Result2.PartValue ?? "";
					}
					if (!string.IsNullOrWhiteSpace(value))
					{
						cRMEntities.CRMspLkSepReturnCmpAccountRemaining(cmpId, objectParameter, linkAccSettingDBId);
					}
					else
					{
						cRMSpEntities.CRMspLkSepReturnCmpAccountRemainingInAccCode(cmpId, objectParameter, linkAccSettingDBId, debitBalance, creditBalance);
					}
					decimal result4 = default(decimal);
					if (objectParameter != null && objectParameter.Value != null)
					{
						decimal.TryParse(objectParameter.Value.ToString(), out result4);
					}
					linkAccRemain = result4;
					return "";
				}
				Exception e = new Exception(Messages.ErrorNotFound + "(customer)");
				ErrorSignal.FromCurrentContext().Raise(e);
				return Labels.frmError;
			}
			Exception e2 = new Exception(Messages.ErrorNotFound + "(customer)");
			ErrorSignal.FromCurrentContext().Raise(e2);
			return Labels.frmError;
		}
		catch (Exception e3)
		{
			ErrorSignal.FromCurrentContext().Raise(e3);
			return Labels.frmError;
		}
	}

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> GetPdfPreOrderPaymentById(int pordPayId, string printFormat, int? ln = null, int? pfCId = 0)
	{
		//IL_0976: Unknown result type (might be due to invalid IL or missing references)
		//IL_097b: Unknown result type (might be due to invalid IL or missing references)
		//IL_097d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0980: Unknown result type (might be due to invalid IL or missing references)
		//IL_099e: Expected I4, but got Unknown
		//IL_099e: Unknown result type (might be due to invalid IL or missing references)
		//IL_09a2: Invalid comparison between Unknown and I4
		//IL_0696: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_06bb: Expected O, but got Unknown
		//IL_06e6: Unknown result type (might be due to invalid IL or missing references)
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
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
					try
					{
						cRMEntities = new CRMEntities();
						cRMSpEntities = new CRMSpEntities();
						StiReport stiReport = new StiReport();
						if (pordPayId > 0)
						{
							string text = HttpContext.Current.Server.MapPath("~/Areas/Reports/ReportDatasets/");
							string text2 = HttpContext.Current.Server.MapPath("~/Areas/Reports/ReportFiles/");
							string text3 = "";
							Mobile.Models.ReportModel.PreOrderPaymentPrintRpt.Parameters parameters = new Mobile.Models.ReportModel.PreOrderPaymentPrintRpt.Parameters();
							int userId = token2.userId;
							DateTime now = DateTime.Now;
							string rptDate = now.ToString("yyyy/MM/dd");
							string rptDay = now.ToString("dddd");
							Reports reports = new Reports();
							parameters.SysSetting = reports.GetSysSetting();
							parameters.ReportDateTime = now;
							parameters.ReporterUserName = UserLogin.CurrentUser.FullName;
							parameters.ReportDay = DateTimeClass.DefineDayeOfWeekPersian(parameters.ReportDateTime.DayOfWeek.ToString());
							parameters.ReportDateTime.ToString("yyyy/MM/dd");
							_ = Labels.RptBuyOrderTitle;
							_ = Labels.RptPreOrderTitle;
							_ = Labels.RptSaleOrderTitle;
							byte[] coLoGo = SysSeting.Get().CoLoGo;
							if (coLoGo != null && coLoGo.Length != 0)
							{
								parameters.CoLogo = Convert.ToBase64String(coLoGo);
							}
							parameters.PreOrderPayment = new WSspRpt_PrintPreOrderPaymentById_Result();
							parameters.PreOrderPayment = Enumerable.FirstOrDefault<WSspRpt_PrintPreOrderPaymentById_Result>((IEnumerable<WSspRpt_PrintPreOrderPaymentById_Result>)cRMSpEntities.WSspRpt_PrintPreOrderPaymentById(pordPayId, userId, rptDate, rptDay, num, result2));
							if (parameters.PreOrderPayment != null)
							{
								if (num != 1065)
								{
									if (!string.IsNullOrWhiteSpace(parameters.PreOrderPayment.ImportDate))
									{
										parameters.PreOrderPayment.ImportDate = PersianDate.GetShamsi2Miladi(parameters.PreOrderPayment.ImportDate.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrWhiteSpace(parameters.PreOrderPayment.pordpayDocDate))
									{
										parameters.PreOrderPayment.pordpayDocDate = PersianDate.GetShamsi2Miladi(parameters.PreOrderPayment.pordpayDocDate.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrWhiteSpace(parameters.PreOrderPayment.pordpayFirstRegisteDatePersian))
									{
										parameters.PreOrderPayment.pordpayFirstRegisteDatePersian = PersianDate.GetShamsi2Miladi(parameters.PreOrderPayment.pordpayFirstRegisteDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrWhiteSpace(parameters.PreOrderPayment.RegisterDatePersian))
									{
										parameters.PreOrderPayment.RegisterDatePersian = PersianDate.GetShamsi2Miladi(parameters.PreOrderPayment.RegisterDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrWhiteSpace(parameters.PreOrderPayment.FirstRegisterDatePersian))
									{
										parameters.PreOrderPayment.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(parameters.PreOrderPayment.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrWhiteSpace(parameters.PreOrderPayment.pordpayVerifiedRegisterDatePersian))
									{
										parameters.PreOrderPayment.pordpayVerifiedRegisterDatePersian = PersianDate.GetShamsi2Miladi(parameters.PreOrderPayment.pordpayVerifiedRegisterDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrWhiteSpace(parameters.PreOrderPayment.pordpayDocDateTemp))
									{
										parameters.PreOrderPayment.pordpayDocDateTemp = PersianDate.GetShamsi2Miladi(parameters.PreOrderPayment.pordpayDocDateTemp.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrWhiteSpace(parameters.PreOrderPayment.pordDate))
									{
										parameters.PreOrderPayment.pordDate = PersianDate.GetShamsi2Miladi(parameters.PreOrderPayment.pordDate.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrWhiteSpace(parameters.PreOrderPayment.pordDeadlineDatePersian))
									{
										parameters.PreOrderPayment.pordDeadlineDatePersian = PersianDate.GetShamsi2Miladi(parameters.PreOrderPayment.pordDeadlineDatePersian.Replace("/", "")).Replace("/", "");
									}
								}
							}
							else
							{
								parameters.PreOrderPayment = new WSspRpt_PrintPreOrderPaymentById_Result();
							}
							parameters.SignatureFirstUser = null;
							parameters.SignatureLastEditUser = null;
							parameters.SignatureVerifierUser = null;
							if (parameters.PreOrderPayment != null)
							{
								if (parameters.PreOrderPayment.FirstRegisterUserId.GetValueOrDefault() != 0)
								{
									CRMspSelectUserSignatureByUserId_Result cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)cRMEntities.CRMspSelectUserSignatureByUserId(parameters.PreOrderPayment.FirstRegisterUserId));
									if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
									{
										parameters.SignatureFirstUser = cRMspSelectUserSignatureByUserId_Result.Signature;
									}
								}
								if (parameters.PreOrderPayment.UserId != 0)
								{
									CRMspSelectUserSignatureByUserId_Result cRMspSelectUserSignatureByUserId_Result2 = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)cRMEntities.CRMspSelectUserSignatureByUserId(parameters.PreOrderPayment.UserId));
									if (cRMspSelectUserSignatureByUserId_Result2 != null && cRMspSelectUserSignatureByUserId_Result2.Signature != null && cRMspSelectUserSignatureByUserId_Result2.Signature.Length != 0)
									{
										parameters.SignatureLastEditUser = cRMspSelectUserSignatureByUserId_Result2.Signature;
									}
								}
								if (parameters.PreOrderPayment.pordpayVerifierId.GetValueOrDefault() != 0)
								{
									CRMspSelectUserSignatureByUserId_Result cRMspSelectUserSignatureByUserId_Result3 = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)cRMEntities.CRMspSelectUserSignatureByUserId(parameters.PreOrderPayment.pordpayVerifierId));
									if (cRMspSelectUserSignatureByUserId_Result3 != null && cRMspSelectUserSignatureByUserId_Result3.Signature != null && cRMspSelectUserSignatureByUserId_Result3.Signature.Length != 0)
									{
										parameters.SignatureVerifierUser = cRMspSelectUserSignatureByUserId_Result3.Signature;
									}
								}
							}
							int printFormatCId = PrintFormat.GetPrintFormatCId(0, text3);
							if (printFormatCId != 0 && !string.IsNullOrWhiteSpace(text2))
							{
								if (!text2.EndsWith("\\"))
								{
									text2 += "\\";
								}
								text2 = text2 + printFormatCId + "\\";
							}
							if (string.IsNullOrEmpty(text3))
							{
								text3 = "PreOrderPaymentPrint.mrt";
							}
							if (!System.IO.File.Exists(text2 + text3))
							{
								text3 = "PreOrderPaymentPrint.mrt";
							}
							XmlSerializer val = new XmlSerializer(typeof(Mobile.Models.ReportModel.PreOrderPaymentPrintRpt.Parameters));
							StringWriter stringWriter = new StringWriter();
							XmlWriter val2 = XmlWriter.Create((TextWriter)stringWriter);
							val.Serialize(val2, (object)parameters);
							DataSet val3 = new DataSet();
							val3.ReadXmlSchema(text + "PreOrderPaymentPrint.xsd");
							XElement val4 = XElement.Parse(stringWriter.ToString());
							val3.ReadXml(((XNode)val4).CreateReader((ReaderOptions)0));
							stiReport.Load(text2 + text3);
							string text4 = "Integrated Security=False;Data Source={DBServer};Initial Catalog={DBName};Password={DBPass};User ID={DBUser}";
							text4 = text4.Replace("{DBServer}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBServer"]));
							text4 = text4.Replace("{DBName}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBName"]));
							text4 = text4.Replace("{DBUser}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBUser"]));
							text4 = text4.Replace("{DBPass}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBPass"]));
							((CollectionBase)stiReport.Dictionary.Databases).Clear();
							stiReport.Dictionary.Databases.Add(new StiSqlDatabase("CRMIdealExtra", text4));
							stiReport.Compile();
							stiReport.RegData(val3);
							stiReport.Render();
							string text5 = DateTime.Now.ToString("yyyyMMddHHmmss");
							string text6 = HttpContext.Current.Server.MapPath("~/Download") + "\\Reports\\Files\\" + token2.userId;
							if (!System.IO.Directory.Exists(text6))
							{
								System.IO.Directory.CreateDirectory(text6);
								CRM.General.IO.Directory.SetFullControlForEveryOne(text6);
							}
							string path = text6 + "\\PreOrderPayment-" + pordPayId + "-" + text5 + ".pdf";
							try
							{
								System.IO.File.Delete(path);
							}
							catch (Exception e)
							{
								ErrorSignal.FromCurrentContext().Raise(e);
								message = "خطا در یافت";
								data = null;
								status = ServiceResultStatus.Error;
							}
							StiJpegExportSettings stiJpegExportSettings = new StiJpegExportSettings
							{
								ImageResolution = 300
							};
							int currentPage = Enumerable.Count<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
							string text7 = text6 + "\\PreOrderPayment-" + text5 + ".pdf";
							string text8 = text6 + "\\PreOrderPayment_Zip-" + text5;
							if (!System.IO.Directory.Exists(text8))
							{
								System.IO.Directory.CreateDirectory(text8);
								CRM.General.IO.Directory.SetFullControlForEveryOne(text8);
							}
							string file = text8 + "\\PreOrderPayment_001.jpg";
							stiJpegExportSettings.PageRange = new StiPagesRange(currentPage);
							stiReport.ExportDocument(StiExportFormat.ImageJpeg, file, stiJpegExportSettings);
							string[] files = System.IO.Directory.GetFiles(text8);
							if (Enumerable.Any<string>((IEnumerable<string>)files))
							{
								PdfDocument pdfDocument = new PdfDocument();
								for (int i = 0; i < files.Length; i++)
								{
									PdfPage pdfPage = new PdfPage();
									StiPage stiPage = Enumerable.FirstOrDefault<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
									if (stiPage != null)
									{
										if (stiPage.Orientation == StiPageOrientation.Landscape)
										{
											pdfPage.Orientation = PageOrientation.Landscape;
										}
										try
										{
											PaperKind paperSize = stiPage.PaperSize;
											switch (paperSize - 8)
											{
											default:
												if ((int)paperSize != 66)
												{
													break;
												}
												pdfPage.Size = PageSize.A2;
												goto end_IL_0974;
											case 0:
												pdfPage.Size = PageSize.A3;
												goto end_IL_0974;
											case 1:
												pdfPage.Size = PageSize.A4;
												goto end_IL_0974;
											case 3:
												pdfPage.Size = PageSize.A5;
												goto end_IL_0974;
											case 4:
												pdfPage.Size = PageSize.B4;
												goto end_IL_0974;
											case 5:
												pdfPage.Size = PageSize.B5;
												goto end_IL_0974;
											case 2:
												break;
											}
											pdfPage.Size = PageSize.A4;
											end_IL_0974:;
										}
										catch (Exception e2)
										{
											ErrorSignal.FromCurrentContext().Raise(e2);
											pdfPage.Size = PageSize.A4;
										}
									}
									pdfDocument.Pages.Add(pdfPage);
									XGraphics xGraphics = XGraphics.FromPdfPage(pdfDocument.Pages[i]);
									XImage xImage = XImage.FromFile(files[i]);
									xGraphics.DrawImage(xImage, 0.0, 0.0);
									xImage.Dispose();
									xGraphics.Dispose();
								}
								pdfDocument.Save(text7);
								pdfDocument.Close();
							}
							try
							{
								DirectoryInfo directoryInfo = new DirectoryInfo(text8);
								FileInfo[] files2 = directoryInfo.GetFiles();
								for (int j = 0; j < files2.Length; j++)
								{
									files2[j].Delete();
								}
								DirectoryInfo[] directories = directoryInfo.GetDirectories();
								for (int j = 0; j < directories.Length; j++)
								{
									directories[j].Delete(recursive: true);
								}
								if (System.IO.Directory.Exists(text8))
								{
									System.IO.Directory.Delete(text8);
								}
							}
							catch (Exception e3)
							{
								ErrorSignal.FromCurrentContext().Raise(e3);
							}
							path = text7;
							string[] array = HttpContext.Current.Request.Url.AbsoluteUri.Split(new string[1] { "/api/" }, StringSplitOptions.None);
							string text9 = "";
							if (array != null)
							{
								string text10 = "/Download/Reports/Files/" + token2.userId + "/PreOrderPayment-" + text5 + ".pdf";
								text9 = ((array[0] != null && array[0] != "") ? (array[0] + text10) : "");
							}
							data = (System.IO.File.Exists(path) ? text9 : "");
							message = Messages.MobMsgSuccessAction;
							status = ServiceResultStatus.Success;
						}
						else
						{
							message = Messages.MobMsgErrorFileNotExist;
							data = null;
							status = ServiceResultStatus.Error;
						}
					}
					catch (Exception e4)
					{
						message = Messages.MobMsgErrorDoneOperation;
						data = null;
						status = ServiceResultStatus.Error;
						ErrorSignal.FromCurrentContext().Raise(e4);
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
		catch (Exception e5)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e5);
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

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> GetPdfOrderPaymentById(int ordPayId, string printFormat, int? ln = null, int? pfCId = 0)
	{
		//IL_0a12: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a17: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a19: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a1c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a3a: Expected I4, but got Unknown
		//IL_0a3a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a3e: Invalid comparison between Unknown and I4
		//IL_0732: Unknown result type (might be due to invalid IL or missing references)
		//IL_0750: Unknown result type (might be due to invalid IL or missing references)
		//IL_0757: Expected O, but got Unknown
		//IL_0782: Unknown result type (might be due to invalid IL or missing references)
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
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
					try
					{
						cRMEntities = new CRMEntities();
						cRMSpEntities = new CRMSpEntities();
						StiReport stiReport = new StiReport();
						if (ordPayId > 0)
						{
							string text = HttpContext.Current.Server.MapPath("~/Areas/Reports/ReportDatasets/");
							string text2 = HttpContext.Current.Server.MapPath("~/Areas/Reports/ReportFiles/");
							string text3 = "";
							Mobile.Models.ReportModel.OrderPaymentPrintRpt.Parameters parameters = new Mobile.Models.ReportModel.OrderPaymentPrintRpt.Parameters();
							int userId = token2.userId;
							DateTime now = DateTime.Now;
							string rptDate = now.ToString("yyyy/MM/dd");
							string rptDay = now.ToString("dddd");
							Reports reports = new Reports();
							parameters.SysSetting = reports.GetSysSetting();
							parameters.ReportDateTime = now;
							parameters.ReporterUserName = UserLogin.CurrentUser.FullName;
							parameters.ReportDay = DateTimeClass.DefineDayeOfWeekPersian(parameters.ReportDateTime.DayOfWeek.ToString());
							parameters.ReportDateTime.ToString("yyyy/MM/dd");
							_ = Labels.RptBuyOrderTitle;
							_ = Labels.RptPreOrderTitle;
							_ = Labels.RptSaleOrderTitle;
							byte[] coLoGo = SysSeting.Get().CoLoGo;
							if (coLoGo != null && coLoGo.Length != 0)
							{
								parameters.CoLogo = Convert.ToBase64String(coLoGo);
							}
							parameters.OrderPayment = new WSspRpt_PrintOrderPaymentById_Result();
							parameters.OrderPayment = Enumerable.FirstOrDefault<WSspRpt_PrintOrderPaymentById_Result>((IEnumerable<WSspRpt_PrintOrderPaymentById_Result>)cRMSpEntities.WSspRpt_PrintOrderPaymentById(ordPayId, userId, rptDate, rptDay, num, result2));
							if (parameters.OrderPayment != null)
							{
								if (num != 1065)
								{
									if (!string.IsNullOrWhiteSpace(parameters.OrderPayment.ImportDate))
									{
										parameters.OrderPayment.ImportDate = PersianDate.GetShamsi2Miladi(parameters.OrderPayment.ImportDate.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrWhiteSpace(parameters.OrderPayment.ordpayDocDate))
									{
										parameters.OrderPayment.ordpayDocDate = PersianDate.GetShamsi2Miladi(parameters.OrderPayment.ordpayDocDate.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrWhiteSpace(parameters.OrderPayment.ordpayFirstRegisteDatePersian))
									{
										parameters.OrderPayment.ordpayFirstRegisteDatePersian = PersianDate.GetShamsi2Miladi(parameters.OrderPayment.ordpayFirstRegisteDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrWhiteSpace(parameters.OrderPayment.RegisterDatePersian))
									{
										parameters.OrderPayment.RegisterDatePersian = PersianDate.GetShamsi2Miladi(parameters.OrderPayment.RegisterDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrWhiteSpace(parameters.OrderPayment.FirstRegisterDatePersian))
									{
										parameters.OrderPayment.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(parameters.OrderPayment.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrWhiteSpace(parameters.OrderPayment.ordpayVerifiedRegisterDatePersian))
									{
										parameters.OrderPayment.ordpayVerifiedRegisterDatePersian = PersianDate.GetShamsi2Miladi(parameters.OrderPayment.ordpayVerifiedRegisterDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrWhiteSpace(parameters.OrderPayment.ordpayBankDocDatePersian))
									{
										parameters.OrderPayment.ordpayBankDocDatePersian = PersianDate.GetShamsi2Miladi(parameters.OrderPayment.ordpayBankDocDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrWhiteSpace(parameters.OrderPayment.ordpayBankDocRegisterDatePersian))
									{
										parameters.OrderPayment.ordpayBankDocRegisterDatePersian = PersianDate.GetShamsi2Miladi(parameters.OrderPayment.ordpayBankDocRegisterDatePersian.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrWhiteSpace(parameters.OrderPayment.ordpayDocDateTemp))
									{
										parameters.OrderPayment.ordpayDocDateTemp = PersianDate.GetShamsi2Miladi(parameters.OrderPayment.ordpayDocDateTemp.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrWhiteSpace(parameters.OrderPayment.ordDate))
									{
										parameters.OrderPayment.ordDate = PersianDate.GetShamsi2Miladi(parameters.OrderPayment.ordDate.Replace("/", "")).Replace("/", "");
									}
									if (!string.IsNullOrWhiteSpace(parameters.OrderPayment.ordDeadlineDatePersian))
									{
										parameters.OrderPayment.ordDeadlineDatePersian = PersianDate.GetShamsi2Miladi(parameters.OrderPayment.ordDeadlineDatePersian.Replace("/", "")).Replace("/", "");
									}
								}
							}
							else
							{
								parameters.OrderPayment = new WSspRpt_PrintOrderPaymentById_Result();
							}
							parameters.SignatureFirstUser = null;
							parameters.SignatureLastEditUser = null;
							parameters.SignatureVerifierUser = null;
							if (parameters.OrderPayment != null)
							{
								if (parameters.OrderPayment.FirstRegisterUserId.GetValueOrDefault() != 0)
								{
									CRMspSelectUserSignatureByUserId_Result cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)cRMEntities.CRMspSelectUserSignatureByUserId(parameters.OrderPayment.FirstRegisterUserId));
									if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
									{
										parameters.SignatureFirstUser = cRMspSelectUserSignatureByUserId_Result.Signature;
									}
								}
								if (parameters.OrderPayment.UserId != 0)
								{
									CRMspSelectUserSignatureByUserId_Result cRMspSelectUserSignatureByUserId_Result2 = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)cRMEntities.CRMspSelectUserSignatureByUserId(parameters.OrderPayment.UserId));
									if (cRMspSelectUserSignatureByUserId_Result2 != null && cRMspSelectUserSignatureByUserId_Result2.Signature != null && cRMspSelectUserSignatureByUserId_Result2.Signature.Length != 0)
									{
										parameters.SignatureLastEditUser = cRMspSelectUserSignatureByUserId_Result2.Signature;
									}
								}
								if (parameters.OrderPayment.ordpayVerifierId.GetValueOrDefault() != 0)
								{
									CRMspSelectUserSignatureByUserId_Result cRMspSelectUserSignatureByUserId_Result3 = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)cRMEntities.CRMspSelectUserSignatureByUserId(parameters.OrderPayment.ordpayVerifierId));
									if (cRMspSelectUserSignatureByUserId_Result3 != null && cRMspSelectUserSignatureByUserId_Result3.Signature != null && cRMspSelectUserSignatureByUserId_Result3.Signature.Length != 0)
									{
										parameters.SignatureVerifierUser = cRMspSelectUserSignatureByUserId_Result3.Signature;
									}
								}
							}
							int printFormatCId = PrintFormat.GetPrintFormatCId(0, text3);
							if (printFormatCId != 0 && !string.IsNullOrWhiteSpace(text2))
							{
								if (!text2.EndsWith("\\"))
								{
									text2 += "\\";
								}
								text2 = text2 + printFormatCId + "\\";
							}
							if (string.IsNullOrEmpty(text3))
							{
								text3 = "OrderPaymentPrint.mrt";
							}
							if (!System.IO.File.Exists(text2 + text3))
							{
								text3 = "OrderPaymentPrint.mrt";
							}
							XmlSerializer val = new XmlSerializer(typeof(Mobile.Models.ReportModel.OrderPaymentPrintRpt.Parameters));
							StringWriter stringWriter = new StringWriter();
							XmlWriter val2 = XmlWriter.Create((TextWriter)stringWriter);
							val.Serialize(val2, (object)parameters);
							DataSet val3 = new DataSet();
							val3.ReadXmlSchema(text + "OrderPaymentPrint.xsd");
							XElement val4 = XElement.Parse(stringWriter.ToString());
							val3.ReadXml(((XNode)val4).CreateReader((ReaderOptions)0));
							stiReport.Load(text2 + text3);
							string text4 = "Integrated Security=False;Data Source={DBServer};Initial Catalog={DBName};Password={DBPass};User ID={DBUser}";
							text4 = text4.Replace("{DBServer}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBServer"]));
							text4 = text4.Replace("{DBName}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBName"]));
							text4 = text4.Replace("{DBUser}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBUser"]));
							text4 = text4.Replace("{DBPass}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBPass"]));
							((CollectionBase)stiReport.Dictionary.Databases).Clear();
							stiReport.Dictionary.Databases.Add(new StiSqlDatabase("CRMIdealExtra", text4));
							stiReport.Compile();
							stiReport.RegData(val3);
							stiReport.Render();
							string text5 = DateTime.Now.ToString("yyyyMMddHHmmss");
							string text6 = HttpContext.Current.Server.MapPath("~/Download") + "\\Reports\\Files\\" + token2.userId;
							if (!System.IO.Directory.Exists(text6))
							{
								System.IO.Directory.CreateDirectory(text6);
								CRM.General.IO.Directory.SetFullControlForEveryOne(text6);
							}
							string path = text6 + "\\OrderPaymentPrint-" + ordPayId + "-" + text5 + ".pdf";
							try
							{
								System.IO.File.Delete(path);
							}
							catch (Exception e)
							{
								ErrorSignal.FromCurrentContext().Raise(e);
								message = "خطا در یافت";
								data = null;
								status = ServiceResultStatus.Error;
							}
							StiJpegExportSettings stiJpegExportSettings = new StiJpegExportSettings
							{
								ImageResolution = 300
							};
							int currentPage = Enumerable.Count<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
							string text7 = text6 + "\\OrderPaymentPrint-" + text5 + ".pdf";
							string text8 = text6 + "\\OrderPaymentPrint_Zip-" + text5;
							if (!System.IO.Directory.Exists(text8))
							{
								System.IO.Directory.CreateDirectory(text8);
								CRM.General.IO.Directory.SetFullControlForEveryOne(text8);
							}
							string file = text8 + "\\OrderPaymentPrint_001.jpg";
							stiJpegExportSettings.PageRange = new StiPagesRange(currentPage);
							stiReport.ExportDocument(StiExportFormat.ImageJpeg, file, stiJpegExportSettings);
							string[] files = System.IO.Directory.GetFiles(text8);
							if (Enumerable.Any<string>((IEnumerable<string>)files))
							{
								PdfDocument pdfDocument = new PdfDocument();
								for (int i = 0; i < files.Length; i++)
								{
									PdfPage pdfPage = new PdfPage();
									StiPage stiPage = Enumerable.FirstOrDefault<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
									if (stiPage != null)
									{
										if (stiPage.Orientation == StiPageOrientation.Landscape)
										{
											pdfPage.Orientation = PageOrientation.Landscape;
										}
										try
										{
											PaperKind paperSize = stiPage.PaperSize;
											switch (paperSize - 8)
											{
											default:
												if ((int)paperSize != 66)
												{
													break;
												}
												pdfPage.Size = PageSize.A2;
												goto end_IL_0a10;
											case 0:
												pdfPage.Size = PageSize.A3;
												goto end_IL_0a10;
											case 1:
												pdfPage.Size = PageSize.A4;
												goto end_IL_0a10;
											case 3:
												pdfPage.Size = PageSize.A5;
												goto end_IL_0a10;
											case 4:
												pdfPage.Size = PageSize.B4;
												goto end_IL_0a10;
											case 5:
												pdfPage.Size = PageSize.B5;
												goto end_IL_0a10;
											case 2:
												break;
											}
											pdfPage.Size = PageSize.A4;
											end_IL_0a10:;
										}
										catch (Exception e2)
										{
											ErrorSignal.FromCurrentContext().Raise(e2);
											pdfPage.Size = PageSize.A4;
										}
									}
									pdfDocument.Pages.Add(pdfPage);
									XGraphics xGraphics = XGraphics.FromPdfPage(pdfDocument.Pages[i]);
									XImage xImage = XImage.FromFile(files[i]);
									xGraphics.DrawImage(xImage, 0.0, 0.0);
									xImage.Dispose();
									xGraphics.Dispose();
								}
								pdfDocument.Save(text7);
								pdfDocument.Close();
							}
							try
							{
								DirectoryInfo directoryInfo = new DirectoryInfo(text8);
								FileInfo[] files2 = directoryInfo.GetFiles();
								for (int j = 0; j < files2.Length; j++)
								{
									files2[j].Delete();
								}
								DirectoryInfo[] directories = directoryInfo.GetDirectories();
								for (int j = 0; j < directories.Length; j++)
								{
									directories[j].Delete(recursive: true);
								}
								if (System.IO.Directory.Exists(text8))
								{
									System.IO.Directory.Delete(text8);
								}
							}
							catch (Exception e3)
							{
								ErrorSignal.FromCurrentContext().Raise(e3);
							}
							path = text7;
							string[] array = HttpContext.Current.Request.Url.AbsoluteUri.Split(new string[1] { "/api/" }, StringSplitOptions.None);
							string text9 = "";
							if (array != null)
							{
								string text10 = "/Download/Reports/Files/" + token2.userId + "/OrderPaymentPrint-" + text5 + ".pdf";
								text9 = ((array[0] != null && array[0] != "") ? (array[0] + text10) : "");
							}
							data = (System.IO.File.Exists(path) ? text9 : "");
							message = Messages.MobMsgSuccessAction;
							status = ServiceResultStatus.Success;
						}
						else
						{
							message = Messages.MobMsgErrorFileNotExist;
							data = null;
							status = ServiceResultStatus.Error;
						}
					}
					catch (Exception e4)
					{
						message = Messages.MobMsgErrorDoneOperation;
						data = null;
						status = ServiceResultStatus.Error;
						ErrorSignal.FromCurrentContext().Raise(e4);
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
		catch (Exception e5)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e5);
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

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> GetPdfRemider(ReminderViewModel info)
	{
		//IL_1718: Unknown result type (might be due to invalid IL or missing references)
		//IL_171d: Unknown result type (might be due to invalid IL or missing references)
		//IL_171f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1722: Unknown result type (might be due to invalid IL or missing references)
		//IL_1740: Expected I4, but got Unknown
		//IL_1740: Unknown result type (might be due to invalid IL or missing references)
		//IL_1744: Invalid comparison between Unknown and I4
		//IL_1428: Unknown result type (might be due to invalid IL or missing references)
		//IL_1446: Unknown result type (might be due to invalid IL or missing references)
		//IL_144d: Expected O, but got Unknown
		//IL_1478: Unknown result type (might be due to invalid IL or missing references)
		int result = 1065;
		if (info.Ln.HasValue)
		{
			int.TryParse(info.Ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		string data = "";
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
					try
					{
						cRMEntities = new CRMEntities();
						cRMSpEntities = new CRMSpEntities();
						string text = HttpContext.Current.Server.MapPath("~/Areas/Reports/ReportDatasets/");
						string text2 = HttpContext.Current.Server.MapPath("~/Areas/Reports/ReportFiles/");
						string text3 = info.FileName ?? "";
						Mobile.Models.ReportModel.ReminderUserTaskCartable.Parameters parameters = new Mobile.Models.ReportModel.ReminderUserTaskCartable.Parameters();
						_ = token2.userId;
						DateTime now = DateTime.Now;
						now.ToString("yyyy/MM/dd HH:mm:ss");
						now.ToString("dddd");
						Reports reports = new Reports();
						parameters.SysSetting = reports.GetSysSetting();
						parameters.ReportDateTime = now;
						parameters.ReporterUserName = UserLogin.CurrentUser.FullName;
						parameters.ReportDay = DateTimeClass.DefineDayeOfWeekPersian(parameters.ReportDateTime.DayOfWeek.ToString());
						parameters.ReportDateTime.ToString("yyyy/MM/dd");
						_ = Labels.RptBuyOrderTitle;
						_ = Labels.RptPreOrderTitle;
						_ = Labels.RptSaleOrderTitle;
						byte[] coLoGo = SysSeting.Get().CoLoGo;
						if (coLoGo != null && coLoGo.Length != 0)
						{
							parameters.CoLogo = Convert.ToBase64String(coLoGo);
						}
						string text4 = info.Date;
						int userId = info.UserId;
						int groupId = info.GroupId;
						int priorityId = info.PriorityId;
						bool selectWithCnvs = info.SelectWithCnvs;
						int didItStatus = info.DidItStatus;
						List<CommonSelectListItemViewModel> list = new List<CommonSelectListItemViewModel>();
						List<SelectListItem> daysInWeek = DateTimeClass.GetDaysInWeek();
						if (!string.IsNullOrWhiteSpace(text4))
						{
							list = GetDatesOfWeekSelectListItemFromSp(text4);
							text4 = Enumerable.LastOrDefault<CommonSelectListItemViewModel>((IEnumerable<CommonSelectListItemViewModel>)list).Text;
						}
						DateTime value = DateTime.Now;
						if (!string.IsNullOrEmpty(text4))
						{
							text4 = text4.Replace("/", "").Replace("-", "").Replace("\\", "")
								.Replace(" ", "")
								.Replace("_", "");
							value = num switch
							{
								1065 => DateTime.Parse(PersianDate.GetFormatetdDate(text4) + " 00:00:00"), 
								1025 => DateTime.Parse(PersianDate.GetFormatetdDate(text4) + " 00:00:00", new CultureInfo("ar-SA"), DateTimeStyles.None), 
								_ => DateTime.Parse(PersianDate.GetFormatetdDate(text4) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None), 
							};
						}
						_ = DateTime.Now;
						int result3 = 0;
						if (UserLogin.CurrentUser != null)
						{
							int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
						}
						parameters.NotUsed_ListReminderUserTasks = new List<CRMspLoadUserTasksWeb_Result>();
						List<CRMspLoadUserTasksWeb_Result> list2 = new List<CRMspLoadUserTasksWeb_Result>();
						parameters.NotUsed_ListReminderUserTasks = new List<CRMspLoadUserTasksWeb_Result>();
						List<DateTime> list3 = new List<DateTime>();
						List<CRMspLoadUserTasksWeb_Result> list4 = new List<CRMspLoadUserTasksWeb_Result>();
						List<CRMspLoadUserTasksWeb_Result> list5 = new List<CRMspLoadUserTasksWeb_Result>();
						if (list != null)
						{
							foreach (CommonSelectListItemViewModel item2 in list)
							{
								if (!string.IsNullOrWhiteSpace(item2.Text))
								{
									string formatetdDate = PersianDate.GetFormatetdDate(item2.Text.Replace("/", "").Replace("-", "").Replace("\\", "")
										.Replace(" ", "")
										.Replace("_", ""));
									DateTime parsedDate;
									switch (num)
									{
									case 1065:
										parsedDate = DateTime.Parse(formatetdDate + " 00:00:00", new PersianCulture());
										break;
									case 1025:
										parsedDate = DateTime.Parse(formatetdDate + " 00:00:00", new CultureInfo("ar-SA"), DateTimeStyles.None);
										break;
									default:
										parsedDate = DateTime.Parse(formatetdDate + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None);
										break;
									}
									if (!Enumerable.Any<DateTime>((IEnumerable<DateTime>)list3, (Func<DateTime, bool>)((DateTime x) => x.Date == parsedDate.Date)))
									{
										list3.Add(parsedDate.Date);
									}
								}
							}
						}
						if (!Enumerable.Any<DateTime>((IEnumerable<DateTime>)list3))
						{
							list2 = list5;
						}
						else
						{
							foreach (DateTime item3 in list3)
							{
								List<CRMspLoadUserTasksWeb_Result> list6 = Enumerable.ToList<CRMspLoadUserTasksWeb_Result>((IEnumerable<CRMspLoadUserTasksWeb_Result>)cRMSpEntities.CRMspLoadUserTasksWeb(item3, userId, num, result2, selectWithCnvs, UserLogin.CurrentUser.UserId, userTaskGroupId: groupId, userTaskPriorityId: priorityId, userTaskDidItStatus: didItStatus, centerId: result3));
								if (list6 == null)
								{
									continue;
								}
								foreach (CRMspLoadUserTasksWeb_Result item in list6)
								{
									if (item != null && item.UserTaskDate.HasValue && (!item.UserTaskDate.HasValue || !(item.UserTaskDate.Value > item3)) && (!item.UserTaskDateEnd.HasValue || !(item.UserTaskDateEnd.Value < item3)))
									{
										if (string.IsNullOrEmpty(item.UserTaskCalendarDate))
										{
											item.UserTaskCalendarDate = item.UserTaskDate.Value.ToString("yyyy/MM/dd");
										}
										if (!Enumerable.Any<CRMspLoadUserTasksWeb_Result>((IEnumerable<CRMspLoadUserTasksWeb_Result>)list4, (Func<CRMspLoadUserTasksWeb_Result, bool>)((CRMspLoadUserTasksWeb_Result x) => x.UserTaskId == item.UserTaskId && x.UserTaskCalendarDate == item.UserTaskCalendarDate)))
										{
											list4.Add(item);
										}
									}
								}
							}
							List<MobspSelectUserTasksRepeats_Result> list7 = Enumerable.ToList<MobspSelectUserTasksRepeats_Result>((IEnumerable<MobspSelectUserTasksRepeats_Result>)cRMEntities.MobspSelectUserTasksRepeats(userId, value, num, result2, userTaskGroupId: groupId, userTaskPriorityId: priorityId, userTaskDidItStatus: didItStatus, centerId: result3, crmUserId: UserLogin.CurrentUser.UserId));
							if (list7 != null)
							{
								foreach (MobspSelectUserTasksRepeats_Result item4 in list7)
								{
									string value2 = JsonConvert.SerializeObject(item4);
									CRMspLoadUserTasksWeb_Result task2 = JsonConvert.DeserializeObject<CRMspLoadUserTasksWeb_Result>(value2);
									if (task2 != null && task2.UserTaskDate.HasValue)
									{
										task2.UserTaskCalendarDate = task2.UserTaskDate.Value.ToString("yyyy/MM/dd");
										if (!Enumerable.Any<CRMspLoadUserTasksWeb_Result>((IEnumerable<CRMspLoadUserTasksWeb_Result>)list4, (Func<CRMspLoadUserTasksWeb_Result, bool>)((CRMspLoadUserTasksWeb_Result x) => x.UserTaskId == task2.UserTaskId && x.UserTaskCalendarDate == task2.UserTaskCalendarDate)))
										{
											list4.Add(task2);
										}
									}
								}
							}
							foreach (CRMspLoadUserTasksWeb_Result task in list4)
							{
								if (task == null || !task.UserTaskDate.HasValue)
								{
									continue;
								}
								if (string.IsNullOrEmpty(task.UserTaskCalendarDate))
								{
									task.UserTaskCalendarDate = task.UserTaskDate.Value.ToString("yyyy/MM/dd");
								}
								if (!task.UserTaskRepeatDaily.GetValueOrDefault() && !task.UserTaskRepeatWeekly.GetValueOrDefault() && !task.UserTaskRepeatMonthly.GetValueOrDefault() && !task.UserTaskRepeatYearly.GetValueOrDefault())
								{
									if (Enumerable.Any<DateTime>((IEnumerable<DateTime>)list3, (Func<DateTime, bool>)((DateTime x) => x.Date == task.UserTaskDate.Value.Date)))
									{
										bool flag = Enumerable.Any<CRMspLoadUserTasksWeb_Result>((IEnumerable<CRMspLoadUserTasksWeb_Result>)list5, (Func<CRMspLoadUserTasksWeb_Result, bool>)((CRMspLoadUserTasksWeb_Result x) => x.UserTaskId == task.UserTaskId && x.UserTaskCalendarDate == task.UserTaskCalendarDate));
										if ((!task.UserTaskDateEnd.HasValue || !(task.UserTaskDateEnd.Value < task.UserTaskDate.Value.Date)) && !flag)
										{
											list5.Add(task);
										}
									}
									continue;
								}
								if (task.UserTaskRepeatDaily.GetValueOrDefault())
								{
									foreach (DateTime item5 in list3)
									{
										if ((!task.UserTaskDate.HasValue || !(task.UserTaskDate.Value > item5)) && (!task.UserTaskDateEnd.HasValue || !(task.UserTaskDateEnd.Value < item5)))
										{
											string value3 = JsonConvert.SerializeObject(task);
											CRMspLoadUserTasksWeb_Result dailyTask = JsonConvert.DeserializeObject<CRMspLoadUserTasksWeb_Result>(value3);
											dailyTask.UserTaskCalendarDate = item5.ToString("yyyy/MM/dd");
											dailyTask.WeekdayNum = (int)item5.DayOfWeek;
											if (!Enumerable.Any<CRMspLoadUserTasksWeb_Result>((IEnumerable<CRMspLoadUserTasksWeb_Result>)list5, (Func<CRMspLoadUserTasksWeb_Result, bool>)((CRMspLoadUserTasksWeb_Result x) => x.UserTaskId == dailyTask.UserTaskId && x.UserTaskCalendarDate == dailyTask.UserTaskCalendarDate)))
											{
												list5.Add(dailyTask);
											}
										}
									}
									continue;
								}
								DateTime dateTime = num switch
								{
									1065 => DateTime.Parse(task.UserTaskDate.Value.ToString("yyyy/MM/dd") + " 00:00:00", new PersianCulture()), 
									1025 => DateTime.Parse(task.UserTaskDate.Value.ToString("yyyy/MM/dd") + " 00:00:00", new CultureInfo("ar-SA"), DateTimeStyles.None), 
									_ => DateTime.Parse(task.UserTaskDate.Value.ToString("yyyy/MM/dd") + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None), 
								};
								foreach (DateTime item6 in list3)
								{
									DateTime dateTime2 = num switch
									{
										1065 => DateTime.Parse(item6.ToString("yyyy/MM/dd") + " 00:00:00", new PersianCulture()), 
										1025 => DateTime.Parse(item6.ToString("yyyy/MM/dd") + " 00:00:00", new CultureInfo("ar-SA"), DateTimeStyles.None), 
										_ => DateTime.Parse(item6.ToString("yyyy/MM/dd") + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None), 
									};
									bool flag2 = false;
									if (task.UserTaskRepeatWeekly.GetValueOrDefault() && task.UserTaskDate.Value.DayOfWeek == item6.DayOfWeek)
									{
										flag2 = true;
									}
									if (!flag2 && task.UserTaskRepeatMonthly.GetValueOrDefault() && dateTime.Day == dateTime2.Day)
									{
										flag2 = true;
									}
									if (!flag2 && task.UserTaskRepeatYearly.GetValueOrDefault() && dateTime.Month == dateTime2.Month && dateTime.Day == dateTime2.Day)
									{
										flag2 = true;
									}
									if (!flag2)
									{
										continue;
									}
									string value4 = JsonConvert.SerializeObject(task);
									CRMspLoadUserTasksWeb_Result recurringTask = JsonConvert.DeserializeObject<CRMspLoadUserTasksWeb_Result>(value4);
									recurringTask.UserTaskCalendarDate = item6.ToString("yyyy/MM/dd");
									recurringTask.WeekdayNum = (int)item6.DayOfWeek;
									bool flag3 = Enumerable.Any<CRMspLoadUserTasksWeb_Result>((IEnumerable<CRMspLoadUserTasksWeb_Result>)list5, (Func<CRMspLoadUserTasksWeb_Result, bool>)((CRMspLoadUserTasksWeb_Result x) => x.UserTaskId == recurringTask.UserTaskId && x.UserTaskCalendarDate == recurringTask.UserTaskCalendarDate));
									if ((!task.UserTaskDate.HasValue || !(task.UserTaskDate.Value > item6)) && (!task.UserTaskDateEnd.HasValue || !(task.UserTaskDateEnd.Value < item6)))
									{
										if (!flag3)
										{
											list5.Add(recurringTask);
										}
										break;
									}
								}
							}
							list2 = list5;
						}
						if (list2 != null && Enumerable.Any<CRMspLoadUserTasksWeb_Result>((IEnumerable<CRMspLoadUserTasksWeb_Result>)list2))
						{
							foreach (CRMspLoadUserTasksWeb_Result item7 in Enumerable.ToList<CRMspLoadUserTasksWeb_Result>((IEnumerable<CRMspLoadUserTasksWeb_Result>)list2))
							{
								item7.FirstRegisterDatePersian = item7.FirstRegisterDate?.ToString("yyyy/MM/dd");
								item7.RegisterDatePersian = item7.RegisterDate.ToString("yyyy/MM/dd");
								item7.UserTaskDatePersian = item7.UserTaskDate?.ToString("yyyy/MM/dd");
								item7.UserTaskDidItDatePersian = item7.UserTaskDidItDate?.ToString("yyyy/MM/dd");
								item7.UserTaskDateEndPersian = item7.UserTaskDateEnd?.ToString("yyyy/MM/dd");
								DateTime? calendarDateTime = null;
								switch (num)
								{
								case 1065:
									calendarDateTime = DateTime.Parse(item7.UserTaskCalendarDate + " 00:00:00", new PersianCulture());
									break;
								case 1025:
									calendarDateTime = DateTime.Parse(item7.UserTaskCalendarDate + " 00:00:00", new CultureInfo("ar-SA"), DateTimeStyles.None);
									break;
								default:
									calendarDateTime = DateTime.Parse(item7.UserTaskCalendarDate + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None);
									break;
								}
								item7.WeekdayName = Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)daysInWeek, (Func<SelectListItem, bool>)((SelectListItem x) => x.Value == ((int)calendarDateTime.Value.DayOfWeek).ToString()))?.Text ?? "";
								string text5 = "";
								if (!string.IsNullOrEmpty(item7.UserTaskCalendarDate))
								{
									string[] array = item7.UserTaskCalendarDate.Split(new char[1] { '/' });
									if (array.Length == 3)
									{
										text5 = array[0] + "/" + array[1] + "/" + array[2];
									}
								}
								item7.UserTaskDidItInPeriod = false;
								item7.UserTaskDidItTimeInPeriod = "";
								if (string.IsNullOrEmpty(item7.UserTaskDidItInfoJson) || string.IsNullOrEmpty(text5))
								{
									continue;
								}
								Dictionary<string, string> dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(item7.UserTaskDidItInfoJson);
								if (dictionary == null || !Enumerable.Any<KeyValuePair<string, string>>((IEnumerable<KeyValuePair<string, string>>)dictionary))
								{
									continue;
								}
								Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
								foreach (KeyValuePair<string, string> item8 in dictionary)
								{
									if (DateTime.TryParseExact(item8.Key, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var result4))
									{
										string key = result4.ToString("yyyy/MM/dd");
										dictionary2[key] = item8.Value;
									}
									else
									{
										dictionary2[item8.Key] = item8.Value;
									}
								}
								item7.UserTaskDidItInfoJson = JsonConvert.SerializeObject(dictionary2);
								if (!dictionary2.ContainsKey(text5))
								{
									continue;
								}
								item7.UserTaskDidItInPeriod = true;
								string text6 = dictionary2[text5];
								if (!string.IsNullOrEmpty(text6))
								{
									string[] array2 = text6.Split(new char[1] { ':' });
									if (array2.Length >= 2)
									{
										item7.UserTaskDidItTimeInPeriod = array2[0] + ":" + array2[1];
									}
									else
									{
										item7.UserTaskDidItTimeInPeriod = text6;
									}
								}
								else
								{
									item7.UserTaskDidItTimeInPeriod = "";
								}
							}
						}
						if (list2 != null && Enumerable.Any<CRMspLoadUserTasksWeb_Result>((IEnumerable<CRMspLoadUserTasksWeb_Result>)list2) && didItStatus != -1)
						{
							List<CRMspLoadUserTasksWeb_Result> list8 = new List<CRMspLoadUserTasksWeb_Result>();
							foreach (CRMspLoadUserTasksWeb_Result item9 in list2)
							{
								string text7 = "";
								if (!string.IsNullOrEmpty(item9.UserTaskCalendarDate))
								{
									string[] array3 = item9.UserTaskCalendarDate.Split(new char[1] { '/' });
									if (array3.Length == 3)
									{
										text7 = array3[0] + "/" + array3[1] + "/" + array3[2];
									}
								}
								bool flag4 = false;
								if (!string.IsNullOrEmpty(item9.UserTaskDidItInfoJson) && !string.IsNullOrEmpty(text7))
								{
									flag4 = JsonConvert.DeserializeObject<Dictionary<string, string>>(item9.UserTaskDidItInfoJson).ContainsKey(text7);
								}
								if (didItStatus == 1 && (flag4 || (item9.UserTaskDidIt.HasValue && item9.UserTaskDidIt.GetValueOrDefault())))
								{
									list8.Add(item9);
								}
								else if (didItStatus == 0 && !flag4 && (!item9.UserTaskDidIt.HasValue || item9.UserTaskDidIt == false))
								{
									list8.Add(item9);
								}
							}
							list2 = list8;
						}
						list2 = Enumerable.ToList<CRMspLoadUserTasksWeb_Result>((IEnumerable<CRMspLoadUserTasksWeb_Result>)Enumerable.ThenBy<CRMspLoadUserTasksWeb_Result, string>(Enumerable.OrderBy<CRMspLoadUserTasksWeb_Result, string>((IEnumerable<CRMspLoadUserTasksWeb_Result>)list2, (Func<CRMspLoadUserTasksWeb_Result, string>)((CRMspLoadUserTasksWeb_Result t) => t.UserTaskCalendarDate)), (Func<CRMspLoadUserTasksWeb_Result, string>)((CRMspLoadUserTasksWeb_Result t) => t.UserTaskTime)));
						parameters.NotUsed_ListReminderUserTasks = list2;
						int printFormatCId = PrintFormat.GetPrintFormatCId(0, text3);
						if (printFormatCId != 0 && !string.IsNullOrWhiteSpace(text2))
						{
							if (!text2.EndsWith("\\"))
							{
								text2 += "\\";
							}
							text2 = text2 + printFormatCId + "\\";
						}
						if (string.IsNullOrEmpty(text3))
						{
							text3 = "ReminderUserTaskCartable.mrt";
						}
						if (!System.IO.File.Exists(text2 + text3))
						{
							text3 = "ReminderUserTaskCartable.mrt";
						}
						XmlSerializer val = new XmlSerializer(typeof(Mobile.Models.ReportModel.ReminderUserTaskCartable.Parameters));
						StringWriter stringWriter = new StringWriter();
						XmlWriter val2 = XmlWriter.Create((TextWriter)stringWriter);
						val.Serialize(val2, (object)parameters);
						DataSet val3 = new DataSet();
						val3.ReadXmlSchema(text + "ReminderUserTaskCartable.xsd");
						XElement val4 = XElement.Parse(stringWriter.ToString());
						val3.ReadXml(((XNode)val4).CreateReader((ReaderOptions)0));
						StiReport stiReport = new StiReport();
						stiReport.Load(text2 + text3);
						string text8 = "Integrated Security=False;Data Source={DBServer};Initial Catalog={DBName};Password={DBPass};User ID={DBUser}";
						text8 = text8.Replace("{DBServer}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBServer"]));
						text8 = text8.Replace("{DBName}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBName"]));
						text8 = text8.Replace("{DBUser}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBUser"]));
						text8 = text8.Replace("{DBPass}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBPass"]));
						((CollectionBase)stiReport.Dictionary.Databases).Clear();
						stiReport.Dictionary.Databases.Add(new StiSqlDatabase("CRMIdealExtra", text8));
						stiReport.Compile();
						stiReport.RegData(val3);
						stiReport.Render();
						string text9 = DateTime.Now.ToString("yyyyMMddHHmmss");
						string text10 = HttpContext.Current.Server.MapPath("~/Download") + "\\Reports\\Files\\" + token2.userId;
						if (!System.IO.Directory.Exists(text10))
						{
							System.IO.Directory.CreateDirectory(text10);
							CRM.General.IO.Directory.SetFullControlForEveryOne(text10);
						}
						string path = text10 + "\\ReminderUserTask-" + parameters.ReportDateTime.ToString() + "-" + text9 + ".pdf";
						try
						{
							System.IO.File.Delete(path);
						}
						catch (Exception e)
						{
							ErrorSignal.FromCurrentContext().Raise(e);
							message = "خطا در یافت";
							data = null;
							status = ServiceResultStatus.Error;
						}
						StiJpegExportSettings stiJpegExportSettings = new StiJpegExportSettings
						{
							ImageResolution = 300
						};
						int currentPage = Enumerable.Count<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
						string text11 = text10 + "\\ReminderUserTask-" + text9 + ".pdf";
						string text12 = text10 + "\\ReminderUserTask_Zip-" + text9;
						if (!System.IO.Directory.Exists(text12))
						{
							System.IO.Directory.CreateDirectory(text12);
							CRM.General.IO.Directory.SetFullControlForEveryOne(text12);
						}
						string file = text12 + "\\ReminderUserTask_001.jpg";
						stiJpegExportSettings.PageRange = new StiPagesRange(currentPage);
						stiReport.ExportDocument(StiExportFormat.ImageJpeg, file, stiJpegExportSettings);
						string[] files = System.IO.Directory.GetFiles(text12);
						if (Enumerable.Any<string>((IEnumerable<string>)files))
						{
							PdfDocument pdfDocument = new PdfDocument();
							for (int i = 0; i < files.Length; i++)
							{
								PdfPage pdfPage = new PdfPage();
								StiPage stiPage = Enumerable.FirstOrDefault<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
								if (stiPage != null)
								{
									if (stiPage.Orientation == StiPageOrientation.Landscape)
									{
										pdfPage.Orientation = PageOrientation.Landscape;
									}
									try
									{
										PaperKind paperSize = stiPage.PaperSize;
										switch (paperSize - 8)
										{
										default:
											if ((int)paperSize != 66)
											{
												break;
											}
											pdfPage.Size = PageSize.A2;
											goto end_IL_1716;
										case 0:
											pdfPage.Size = PageSize.A3;
											goto end_IL_1716;
										case 1:
											pdfPage.Size = PageSize.A4;
											goto end_IL_1716;
										case 3:
											pdfPage.Size = PageSize.A5;
											goto end_IL_1716;
										case 4:
											pdfPage.Size = PageSize.B4;
											goto end_IL_1716;
										case 5:
											pdfPage.Size = PageSize.B5;
											goto end_IL_1716;
										case 2:
											break;
										}
										pdfPage.Size = PageSize.A4;
										end_IL_1716:;
									}
									catch (Exception e2)
									{
										ErrorSignal.FromCurrentContext().Raise(e2);
										pdfPage.Size = PageSize.A4;
									}
								}
								pdfDocument.Pages.Add(pdfPage);
								XGraphics xGraphics = XGraphics.FromPdfPage(pdfDocument.Pages[i]);
								XImage xImage = XImage.FromFile(files[i]);
								xGraphics.DrawImage(xImage, 0.0, 0.0);
								xImage.Dispose();
								xGraphics.Dispose();
							}
							pdfDocument.Save(text11);
							pdfDocument.Close();
						}
						try
						{
							DirectoryInfo directoryInfo = new DirectoryInfo(text12);
							FileInfo[] files2 = directoryInfo.GetFiles();
							for (int j = 0; j < files2.Length; j++)
							{
								files2[j].Delete();
							}
							DirectoryInfo[] directories = directoryInfo.GetDirectories();
							for (int j = 0; j < directories.Length; j++)
							{
								directories[j].Delete(recursive: true);
							}
							if (System.IO.Directory.Exists(text12))
							{
								System.IO.Directory.Delete(text12);
							}
						}
						catch (Exception e3)
						{
							ErrorSignal.FromCurrentContext().Raise(e3);
						}
						path = text11;
						string[] array4 = HttpContext.Current.Request.Url.AbsoluteUri.Split(new string[1] { "/api/" }, StringSplitOptions.None);
						string text13 = "";
						if (array4 != null)
						{
							string text14 = "/Download/Reports/Files/" + token2.userId + "/ReminderUserTask-" + text9 + ".pdf";
							text13 = ((array4[0] != null && array4[0] != "") ? (array4[0] + text14) : "");
						}
						data = (System.IO.File.Exists(path) ? text13 : "");
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					catch (Exception e4)
					{
						message = Messages.MobMsgErrorDoneOperation;
						data = null;
						status = ServiceResultStatus.Error;
						ErrorSignal.FromCurrentContext().Raise(e4);
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
		catch (Exception e5)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e5);
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

	[System.Web.Http.HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> GetPdfProjectReminderCartable(ReminderProjectPrint info)
	{
		//IL_0750: Unknown result type (might be due to invalid IL or missing references)
		//IL_0755: Unknown result type (might be due to invalid IL or missing references)
		//IL_0757: Unknown result type (might be due to invalid IL or missing references)
		//IL_075a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0778: Expected I4, but got Unknown
		//IL_0778: Unknown result type (might be due to invalid IL or missing references)
		//IL_077c: Invalid comparison between Unknown and I4
		//IL_045d: Unknown result type (might be due to invalid IL or missing references)
		//IL_047b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0482: Expected O, but got Unknown
		//IL_04ad: Unknown result type (might be due to invalid IL or missing references)
		int result = 1065;
		if (info.Ln.HasValue)
		{
			int.TryParse(info.Ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		string data = "";
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
					try
					{
						cRMEntities = new CRMEntities();
						cRMSpEntities = new CRMSpEntities();
						string text = HttpContext.Current.Server.MapPath("~/Areas/Reports/ReportDatasets/");
						string text2 = HttpContext.Current.Server.MapPath("~/Areas/Reports/ReportFiles/");
						Mobile.Models.ReportModel.ReminderProjectCartableRpt.Parameters parameters = new Mobile.Models.ReportModel.ReminderProjectCartableRpt.Parameters();
						parameters.ReporterUserName = UserLogin.CurrentUser.FullName;
						parameters.ReportDateTime = DateTime.Now;
						parameters.ReportDay = DateTimeClass.DefineDayeOfWeekPersian(DateTime.Now.DayOfWeek.ToString());
						Reports reports = new Reports();
						parameters.SysSetting = reports.GetSysSetting();
						byte[] coLoGo = SysSeting.Get().CoLoGo;
						if (coLoGo != null && coLoGo.Length != 0)
						{
							parameters.CoLogo = Convert.ToBase64String(coLoGo);
						}
						string fromDate = info.FromDate;
						string toDate = info.ToDate;
						int prjcnvsStatusGroupId = info.PrjcnvsStatusGroupId;
						bool prjIsFinished = info.PrjIsFinished;
						List<CRMspSelectCompanyProjectFromRemindDate_Result> list = new List<CRMspSelectCompanyProjectFromRemindDate_Result>();
						if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate) && prjcnvsStatusGroupId > 0)
						{
							int result3 = 0;
							if (UserLogin.CurrentUser != null)
							{
								int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
							}
							string text3 = fromDate.Replace("/", "").Replace("-", "").Replace("\\", "")
								.Replace(" ", "")
								.Replace("_", "");
							string text4 = toDate.Replace("/", "").Replace("-", "").Replace("\\", "")
								.Replace(" ", "")
								.Replace("_", "");
							DateTime value = DateTime.Now;
							DateTime value2 = DateTime.Now;
							if (!string.IsNullOrEmpty(text3))
							{
								value = DateTime.Parse(PersianDate.GetFormatetdDate(text3.Replace("/", "")) + " 00:00:00", num switch
								{
									1025 => new CultureInfo("ar-SA"), 
									1065 => new PersianCulture(), 
									_ => new CultureInfo("en-US"), 
								});
							}
							if (!string.IsNullOrEmpty(text4))
							{
								value2 = DateTime.Parse(PersianDate.GetFormatetdDate(text4.Replace("/", "")) + " 23:59:59", num switch
								{
									1025 => new CultureInfo("ar-SA"), 
									1065 => new PersianCulture(), 
									_ => new CultureInfo("en-US"), 
								});
							}
							int userId = UserLogin.CurrentUser.UserId;
							list = Enumerable.ToList<CRMspSelectCompanyProjectFromRemindDate_Result>((IEnumerable<CRMspSelectCompanyProjectFromRemindDate_Result>)cRMSpEntities.CRMspSelectCompanyProjectFromRemindDate(text3, text4, value, value2, prjIsFinished, prjcnvsStatusGroupId, num, result2, userId, result3));
							foreach (CRMspSelectCompanyProjectFromRemindDate_Result item in list)
							{
								item.prjRemindDate = ((!string.IsNullOrEmpty(item.prjRemindDate) && num != 1065) ? PersianDate.GetShamsi2Miladi(item.prjRemindDate.Replace("/", "")).Replace("/", "") : item.prjRemindDate);
							}
						}
						parameters.NotUsed_ListProjectFromRemindDate = list;
						XmlSerializer val = new XmlSerializer(typeof(Mobile.Models.ReportModel.ReminderProjectCartableRpt.Parameters));
						StringWriter stringWriter = new StringWriter();
						XmlWriter val2 = XmlWriter.Create((TextWriter)stringWriter);
						val.Serialize(val2, (object)parameters);
						DataSet val3 = new DataSet();
						val3.ReadXmlSchema(text + "ReminderProjectCartable.xsd");
						XElement val4 = XElement.Parse(stringWriter.ToString());
						val3.ReadXml(((XNode)val4).CreateReader((ReaderOptions)0));
						StiReport stiReport = new StiReport();
						stiReport.Load(text2 + "ReminderProjectCartable.mrt");
						string text5 = "Integrated Security=False;Data Source={DBServer};Initial Catalog={DBName};Password={DBPass};User ID={DBUser}";
						text5 = text5.Replace("{DBServer}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBServer"]));
						text5 = text5.Replace("{DBName}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBName"]));
						text5 = text5.Replace("{DBUser}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBUser"]));
						text5 = text5.Replace("{DBPass}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBPass"]));
						((CollectionBase)stiReport.Dictionary.Databases).Clear();
						stiReport.Dictionary.Databases.Add(new StiSqlDatabase("CRMIdealExtra", text5));
						stiReport.Compile();
						stiReport.RegData(val3);
						stiReport.Render();
						string text6 = DateTime.Now.ToString("yyyyMMddHHmmss");
						string text7 = HttpContext.Current.Server.MapPath("~/Download") + "\\Reports\\Files\\" + token2.userId;
						if (!System.IO.Directory.Exists(text7))
						{
							System.IO.Directory.CreateDirectory(text7);
							CRM.General.IO.Directory.SetFullControlForEveryOne(text7);
						}
						string path = text7 + "\\ReminderProject-" + parameters.ReportDateTime.ToString() + "-" + text6 + ".pdf";
						try
						{
							System.IO.File.Delete(path);
						}
						catch (Exception e)
						{
							ErrorSignal.FromCurrentContext().Raise(e);
							message = "خطا در یافت";
							data = null;
							status = ServiceResultStatus.Error;
						}
						StiJpegExportSettings stiJpegExportSettings = new StiJpegExportSettings
						{
							ImageResolution = 300
						};
						int currentPage = Enumerable.Count<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
						string text8 = text7 + "\\ReminderProject-" + text6 + ".pdf";
						string text9 = text7 + "\\ReminderProject-" + text6;
						if (!System.IO.Directory.Exists(text9))
						{
							System.IO.Directory.CreateDirectory(text9);
							CRM.General.IO.Directory.SetFullControlForEveryOne(text9);
						}
						string file = text9 + "\\ReminderProject_001.jpg";
						stiJpegExportSettings.PageRange = new StiPagesRange(currentPage);
						stiReport.ExportDocument(StiExportFormat.ImageJpeg, file, stiJpegExportSettings);
						string[] files = System.IO.Directory.GetFiles(text9);
						if (Enumerable.Any<string>((IEnumerable<string>)files))
						{
							PdfDocument pdfDocument = new PdfDocument();
							for (int i = 0; i < files.Length; i++)
							{
								PdfPage pdfPage = new PdfPage();
								StiPage stiPage = Enumerable.FirstOrDefault<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
								if (stiPage != null)
								{
									if (stiPage.Orientation == StiPageOrientation.Landscape)
									{
										pdfPage.Orientation = PageOrientation.Landscape;
									}
									try
									{
										PaperKind paperSize = stiPage.PaperSize;
										switch (paperSize - 8)
										{
										default:
											if ((int)paperSize != 66)
											{
												break;
											}
											pdfPage.Size = PageSize.A2;
											goto end_IL_074e;
										case 0:
											pdfPage.Size = PageSize.A3;
											goto end_IL_074e;
										case 1:
											pdfPage.Size = PageSize.A4;
											goto end_IL_074e;
										case 3:
											pdfPage.Size = PageSize.A5;
											goto end_IL_074e;
										case 4:
											pdfPage.Size = PageSize.B4;
											goto end_IL_074e;
										case 5:
											pdfPage.Size = PageSize.B5;
											goto end_IL_074e;
										case 2:
											break;
										}
										pdfPage.Size = PageSize.A4;
										end_IL_074e:;
									}
									catch (Exception e2)
									{
										ErrorSignal.FromCurrentContext().Raise(e2);
										pdfPage.Size = PageSize.A4;
									}
								}
								pdfDocument.Pages.Add(pdfPage);
								XGraphics xGraphics = XGraphics.FromPdfPage(pdfDocument.Pages[i]);
								XImage xImage = XImage.FromFile(files[i]);
								xGraphics.DrawImage(xImage, 0.0, 0.0);
								xImage.Dispose();
								xGraphics.Dispose();
							}
							pdfDocument.Save(text8);
							pdfDocument.Close();
						}
						try
						{
							DirectoryInfo directoryInfo = new DirectoryInfo(text9);
							FileInfo[] files2 = directoryInfo.GetFiles();
							for (int j = 0; j < files2.Length; j++)
							{
								files2[j].Delete();
							}
							DirectoryInfo[] directories = directoryInfo.GetDirectories();
							for (int j = 0; j < directories.Length; j++)
							{
								directories[j].Delete(recursive: true);
							}
							if (System.IO.Directory.Exists(text9))
							{
								System.IO.Directory.Delete(text9);
							}
						}
						catch (Exception e3)
						{
							ErrorSignal.FromCurrentContext().Raise(e3);
						}
						path = text8;
						string[] array = HttpContext.Current.Request.Url.AbsoluteUri.Split(new string[1] { "/api/" }, StringSplitOptions.None);
						string text10 = "";
						if (array != null)
						{
							string text11 = "/Download/Reports/Files/" + token2.userId + "/ReminderProject-" + text6 + ".pdf";
							text10 = ((array[0] != null && array[0] != "") ? (array[0] + text11) : "");
						}
						data = (System.IO.File.Exists(path) ? text10 : "");
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					catch (Exception e4)
					{
						message = Messages.MobMsgErrorDoneOperation;
						data = null;
						status = ServiceResultStatus.Error;
						ErrorSignal.FromCurrentContext().Raise(e4);
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
		catch (Exception e5)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e5);
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

	private static List<CommonSelectListItemViewModel> GetDatesOfWeekSelectListItemFromSp(string date = "", int? ln = null)
	{
		CRMSpEntities cRMSpEntities = null;
		List<CommonSelectListItemViewModel> list = new List<CommonSelectListItemViewModel>();
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		int value = ((num != 1065 && num != 1025) ? 1 : 7);
		if (string.IsNullOrWhiteSpace(date))
		{
			date = DateTime.Now.ToString("yyyy/MM/dd");
		}
		DateTime value2 = default(DateTime);
		string text = "";
		try
		{
			if (!string.IsNullOrEmpty(date))
			{
				text = PersianDate.GetFormatetdDate(date.Replace("/", ""));
				value2 = num switch
				{
					1065 => DateTime.Parse(text, new PersianCulture()), 
					1025 => DateTime.Parse(text, new CultureInfo("ar-SA")), 
					_ => DateTime.Parse(text, new CultureInfo("en-US")), 
				};
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		try
		{
			cRMSpEntities = new CRMSpEntities();
			List<MobspSelectCalendarEventWeekDates_Result> list2 = Enumerable.ToList<MobspSelectCalendarEventWeekDates_Result>((IEnumerable<MobspSelectCalendarEventWeekDates_Result>)cRMSpEntities.MobspSelectCalendarEventWeekDates(value2, value, 7));
			if (list2.Count > 0)
			{
				foreach (MobspSelectCalendarEventWeekDates_Result item in list2)
				{
					if (item.MiladiDate.HasValue)
					{
						list.Add(new CommonSelectListItemViewModel
						{
							Text = item.MiladiDate.Value.ToString("yyyy/MM/dd"),
							Value = ((int)item.MiladiDate.Value.DayOfWeek).ToString(),
							Id = item.CalendarEventID,
							Extra = JsonConvert.SerializeObject(new
							{
								IsClosed = item.IsClosed,
								Desc = item.Description
							})
						});
					}
				}
			}
			return list;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			return list;
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
	}
}
