using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using CRM.General.Calendar;
using CRM.General.IO;
using CRM.General.Security;
using CRM.Resources;
using Elmah;
using Mobile.Cache.Setting;
using Mobile.Classes;
using Mobile.Classes.Helper;
using Mobile.DataType;
using Mobile.Models;
using Mobile.Models.ReportModel.OrderPrintRpt;
using Mobile.Models.ReportModel.PreOrderPrintRpt;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using Stimulsoft.Report;
using Stimulsoft.Report.Components;
using Stimulsoft.Report.Dictionary;
using Stimulsoft.Report.Export;

namespace Mobile.Controllers;

public class FOReportsController : ApiController
{
	[HttpPost]
	[FoMobileAuthorize]
	public ServiceResult<string> GetPdfPreOrder(int pordId, string cmpRemainAccLink = "", int? ln = null, int? cId = null)
	{
		//IL_1bf5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bfa: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bfc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bff: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c1d: Expected I4, but got Unknown
		//IL_1c1d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c21: Invalid comparison between Unknown and I4
		//IL_0ecd: Unknown result type (might be due to invalid IL or missing references)
		//IL_16c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_18fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_191b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1922: Expected O, but got Unknown
		//IL_194d: Unknown result type (might be due to invalid IL or missing references)
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
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
				FoToken token2 = new FoCommon().GetToken(token);
				if (token2 != null)
				{
					try
					{
						_db = new CRMEntities();
						cRMSpEntities = new CRMSpEntities();
						StiReport stiReport = new StiReport();
						if (pordId > 0)
						{
							string text3 = HttpContext.Current.Server.MapPath("~/Areas/Reports/ReportDatasets/");
							string text4 = HttpContext.Current.Server.MapPath("~/Areas/Reports/ReportFiles/");
							string text5 = "";
							Mobile.Models.ReportModel.PreOrderPrintRpt.Parameters parameters = new Mobile.Models.ReportModel.PreOrderPrintRpt.Parameters();
							int num = -20;
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
								ReportsController reportsController = new ReportsController();
								string text6 = "";
								MobspSelectPreOrderWithID_Result mobspSelectPreOrderWithID_Result = Enumerable.FirstOrDefault<MobspSelectPreOrderWithID_Result>((IEnumerable<MobspSelectPreOrderWithID_Result>)_db.MobspSelectPreOrderWithID(userId: num, preOrderId: pordId, languageID: currLangId, defaultLanguageID: defLangId, centerId: cId));
								if (mobspSelectPreOrderWithID_Result != null)
								{
									cmpId = mobspSelectPreOrderWithID_Result.pordCompanyId.GetValueOrDefault();
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
											reportsController.SepGetCmpAccountingDetail(cmpId, ref num2, result4);
											text6 = $"{num2:N2}";
											cmpAccountingLinkAccDataViewModel.AllPayRemain = decimal.Parse(text6 ?? "0");
											parameters.NotUsed_ListCmpAllPayRemainLinkAccData.Add(cmpAccountingLinkAccDataViewModel);
										}
									}
									break;
								}
								case 4:
									text6 = (string.IsNullOrWhiteSpace(cmpRemainAccLink) ? reportsController.HolooGetCmpAccountingDetail(cmpId, -1) : cmpRemainAccLink);
									break;
								default:
									if (!string.IsNullOrWhiteSpace(cmpRemainAccLink))
									{
										text6 = cmpRemainAccLink;
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
							parameters.PrintPreOrder = Enumerable.FirstOrDefault<WSspRpt_PrintPreOrderById_Result>((IEnumerable<WSspRpt_PrintPreOrderById_Result>)cRMSpEntities.WSspRpt_PrintPreOrderById(pordId, currLangId, defLangId, num, rptDate, rptDay, parameters.CmpLinkAccAllPayRemain));
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
							List<WSspRpt_PrintPreOrder_Result> list2 = Enumerable.ToList<WSspRpt_PrintPreOrder_Result>((IEnumerable<WSspRpt_PrintPreOrder_Result>)cRMSpEntities.WSspRpt_PrintPreOrder(pordId, currLangId, defLangId, num, rptDate, rptDay, parameters.CmpLinkAccAllPayRemain));
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
							parameters.ReporterUserName = Mobile.Classes.Helper.User.GetUserName(num, defLangId, currLangId);
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
									parameters.ListDyPrintCmpForm = Enumerable.ToList<CRMspDyPrintCmpForm_Result>((IEnumerable<CRMspDyPrintCmpForm_Result>)_db.CRMspDyPrintCmpForm(wSspRpt_PrintPreOrder_Result.pordCompanyId, currLangId, defLangId, 0, 0));
								}
								if (wSspRpt_PrintPreOrder_Result.pordCompanyPersonId.HasValue)
								{
									parameters.ListDyPrintPrsForm = Enumerable.ToList<CRMspDyPrintPrsForm_Result>((IEnumerable<CRMspDyPrintPrsForm_Result>)_db.CRMspDyPrintPrsForm(wSspRpt_PrintPreOrder_Result.pordCompanyPersonId, currLangId, defLangId, 0, 0));
								}
								if (wSspRpt_PrintPreOrder_Result.pordProjectId.HasValue)
								{
									parameters.ListDyPrintPrjForm = Enumerable.ToList<CRMspDyPrintPrjForm_Result>((IEnumerable<CRMspDyPrintPrjForm_Result>)_db.CRMspDyPrintPrjForm(wSspRpt_PrintPreOrder_Result.pordProjectId, currLangId, defLangId, 0, 0));
									parameters.ListPrintProjectInformationTree = Enumerable.ToList<CRMspPrintProjectInformationTree_Result>((IEnumerable<CRMspPrintProjectInformationTree_Result>)_db.CRMspPrintProjectInformationTree(wSspRpt_PrintPreOrder_Result.pordProjectId, currLangId, defLangId));
								}
								parameters.ListDyPrintPordForm = Enumerable.ToList<CRMspDyPrintPordForm_Result>((IEnumerable<CRMspDyPrintPordForm_Result>)_db.CRMspDyPrintPordForm(wSspRpt_PrintPreOrder_Result.PreOrderID, currLangId, defLangId, 0, 0));
							}
							parameters.SignatureReferUser = null;
							parameters.SignatureFirstUser = null;
							parameters.SignatureLastEditUser = null;
							parameters.SignatureVerifierUser = null;
							if (wSspRpt_PrintPreOrder_Result != null)
							{
								CRMspSelectUserSignatureByUserId_Result cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)_db.CRMspSelectUserSignatureByUserId(wSspRpt_PrintPreOrder_Result.pordReferUserId));
								if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
								{
									parameters.SignatureReferUser = cRMspSelectUserSignatureByUserId_Result.Signature;
								}
								cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)_db.CRMspSelectUserSignatureByUserId(wSspRpt_PrintPreOrder_Result.pordFirstRegisterUserId));
								if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
								{
									parameters.SignatureFirstUser = cRMspSelectUserSignatureByUserId_Result.Signature;
								}
								cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)_db.CRMspSelectUserSignatureByUserId(wSspRpt_PrintPreOrder_Result.UserId));
								if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
								{
									parameters.SignatureLastEditUser = cRMspSelectUserSignatureByUserId_Result.Signature;
								}
								cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)_db.CRMspSelectUserSignatureByUserId(wSspRpt_PrintPreOrder_Result.pordVerifierId));
								if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
								{
									parameters.SignatureVerifierUser = cRMspSelectUserSignatureByUserId_Result.Signature;
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
										vmLkAcc.PordId = pordId;
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
							if (cId != 0 && cId.HasValue && !string.IsNullOrWhiteSpace(text4))
							{
								if (!text4.EndsWith("\\"))
								{
									text4 += "\\";
								}
								text4 = text4 + cId + "\\";
							}
							if (mobspReturnPrintFormatFileNameById_Result != null)
							{
								text5 = mobspReturnPrintFormatFileNameById_Result.FileNameWeb;
							}
							if (string.IsNullOrEmpty(text5))
							{
								text5 = "PreOrderPrint.mrt";
							}
							if (!System.IO.File.Exists(text4 + text5))
							{
								text5 = "PreOrderPrint.mrt";
								if (cId != 0 && cId.HasValue)
								{
									text4 = text4.Replace(cId + "\\", "");
								}
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
							string text10 = HttpContext.Current.Server.MapPath("~/Download") + "\\Reports\\Files\\" + token2.CompanyId;
							if (!System.IO.Directory.Exists(text10))
							{
								System.IO.Directory.CreateDirectory(text10);
								CRM.General.IO.Directory.SetFullControlForEveryOne(text10);
							}
							string path = text10 + "\\Pord-" + text7 + "-" + now.ToString("yyyyMMdd") + ".pdf";
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
							string text11 = text10 + "\\Pord-" + text7 + "-" + now.ToString("yyyyMMdd") + ".pdf";
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
												goto end_IL_1bf3;
											case 0:
												pdfPage.Size = PageSize.A3;
												goto end_IL_1bf3;
											case 1:
												pdfPage.Size = PageSize.A4;
												goto end_IL_1bf3;
											case 3:
												pdfPage.Size = PageSize.A5;
												goto end_IL_1bf3;
											case 4:
												pdfPage.Size = PageSize.B4;
												goto end_IL_1bf3;
											case 5:
												pdfPage.Size = PageSize.B5;
												goto end_IL_1bf3;
											case 2:
												break;
											}
											pdfPage.Size = PageSize.A4;
											end_IL_1bf3:;
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
							string[] array = HttpContext.Current.Request.Url.AbsoluteUri.Split(new string[1] { "/api/" }, StringSplitOptions.None);
							string text13 = "";
							if (array != null)
							{
								string text14 = "/Download/Reports/Files/" + token2.CompanyId + "/Pord-" + text7 + "-" + now.ToString("yyyyMMdd") + ".pdf";
								text13 = ((array[0] != null && array[0] != "") ? (array[0] + text14) : "");
							}
							FoPrintLog.InsertPrintLog(token2.CompanyId, pordId, 1, 3);
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

	[HttpPost]
	[FoMobileAuthorize]
	public ServiceResult<string> GetPdfOrder(int ordId, string cmpRemainAccLink = "", int? ln = null, int? cId = null)
	{
		//IL_1b29: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b2e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b30: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b33: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b51: Expected I4, but got Unknown
		//IL_1b51: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b55: Invalid comparison between Unknown and I4
		//IL_0d2f: Unknown result type (might be due to invalid IL or missing references)
		//IL_15fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1832: Unknown result type (might be due to invalid IL or missing references)
		//IL_1850: Unknown result type (might be due to invalid IL or missing references)
		//IL_1857: Expected O, but got Unknown
		//IL_1882: Unknown result type (might be due to invalid IL or missing references)
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
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
				FoToken token2 = new FoCommon().GetToken(token);
				if (token2 != null)
				{
					try
					{
						_db = new CRMEntities();
						_dbI = new CRMSpEntities();
						StiReport stiReport = new StiReport();
						if (ordId > 0)
						{
							string text3 = HttpContext.Current.Server.MapPath("~/Areas/Reports/ReportDatasets/");
							string text4 = HttpContext.Current.Server.MapPath("~/Areas/Reports/ReportFiles/");
							string text5 = "";
							Mobile.Models.ReportModel.OrderPrintRpt.Parameters parameters = new Mobile.Models.ReportModel.OrderPrintRpt.Parameters();
							int num = -20;
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
							int num2 = 0;
							decimal result3 = default(decimal);
							if (result2 > 0)
							{
								ReportsController reportsController = new ReportsController();
								string text6 = "";
								MobspSelectOrderWithID_Result mobspSelectOrderWithID_Result = Enumerable.FirstOrDefault<MobspSelectOrderWithID_Result>((IEnumerable<MobspSelectOrderWithID_Result>)_db.MobspSelectOrderWithID(userId: num, orderId: ordId, languageID: currLangId, defaultLanguageID: defLangId, centerId: cId));
								if (mobspSelectOrderWithID_Result != null)
								{
									num2 = mobspSelectOrderWithID_Result.ordCompanyId;
								}
								switch (result2)
								{
								case 1:
								{
									decimal num3 = default(decimal);
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
											num3 = default(decimal);
											reportsController.SepGetCmpAccountingDetail(num2, ref num3, result4);
											text6 = $"{num3:N2}";
											cmpAccountingLinkAccDataViewModel.AllPayRemain = decimal.Parse(text6 ?? "0");
											parameters.NotUsed_ListCmpAllPayRemainLinkAccData.Add(cmpAccountingLinkAccDataViewModel);
										}
									}
									break;
								}
								case 4:
									text6 = (string.IsNullOrWhiteSpace(cmpRemainAccLink) ? reportsController.HolooGetCmpAccountingDetail(num2, -1) : cmpRemainAccLink);
									break;
								default:
									if (!string.IsNullOrWhiteSpace(cmpRemainAccLink))
									{
										text6 = cmpRemainAccLink;
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
							List<WSspRpt_PrintOrder_Result> list2 = Enumerable.ToList<WSspRpt_PrintOrder_Result>((IEnumerable<WSspRpt_PrintOrder_Result>)_dbI.WSspRpt_PrintOrder(ordId, currLangId, defLangId, num, rptDate, rptDay, parameters.CmpLinkAccAllPayRemain));
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
							parameters.ReporterUserName = Mobile.Classes.Helper.User.GetUserName(num, defLangId, currLangId);
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
								parameters.ListDyPrintCmpForm = Enumerable.ToList<CRMspDyPrintCmpForm_Result>((IEnumerable<CRMspDyPrintCmpForm_Result>)_db.CRMspDyPrintCmpForm(wSspRpt_PrintOrder_Result.ordCompanyId, currLangId, defLangId, 0, 0));
								if (wSspRpt_PrintOrder_Result.ordCompanyPersonId.HasValue)
								{
									parameters.ListDyPrintPrsForm = Enumerable.ToList<CRMspDyPrintPrsForm_Result>((IEnumerable<CRMspDyPrintPrsForm_Result>)_db.CRMspDyPrintPrsForm(wSspRpt_PrintOrder_Result.ordCompanyPersonId, currLangId, defLangId, 0, 0));
								}
								if (wSspRpt_PrintOrder_Result.ordProjectId.HasValue)
								{
									parameters.ListDyPrintPrjForm = Enumerable.ToList<CRMspDyPrintPrjForm_Result>((IEnumerable<CRMspDyPrintPrjForm_Result>)_db.CRMspDyPrintPrjForm(wSspRpt_PrintOrder_Result.ordProjectId, currLangId, defLangId, 0, 0));
									parameters.ListPrintProjectInformationTree = Enumerable.ToList<CRMspPrintProjectInformationTree_Result>((IEnumerable<CRMspPrintProjectInformationTree_Result>)_db.CRMspPrintProjectInformationTree(wSspRpt_PrintOrder_Result.ordProjectId, currLangId, defLangId));
								}
								if (wSspRpt_PrintOrder_Result.PreOrderId.HasValue)
								{
									parameters.ListDyPrintPordForm = Enumerable.ToList<CRMspDyPrintPordForm_Result>((IEnumerable<CRMspDyPrintPordForm_Result>)_db.CRMspDyPrintPordForm(wSspRpt_PrintOrder_Result.PreOrderId, currLangId, defLangId, 0, 0));
								}
								parameters.ListDyPrintOrdForm = Enumerable.ToList<CRMspDyPrintOrdForm_Result>((IEnumerable<CRMspDyPrintOrdForm_Result>)_db.CRMspDyPrintOrdForm(wSspRpt_PrintOrder_Result.OrderID, currLangId, defLangId, 0, 0));
							}
							parameters.Signature = "";
							CRMspSelectUserSignatureByUserId_Result cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)_db.CRMspSelectUserSignatureByUserId(-20));
							if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
							{
								parameters.Signature = Convert.ToBase64String(cRMspSelectUserSignatureByUserId_Result.Signature);
							}
							parameters.SignatureReferUser = null;
							parameters.SignatureLastEditUser = null;
							parameters.SignatureVerifierUser = null;
							if (wSspRpt_PrintOrder_Result != null)
							{
								cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)_db.CRMspSelectUserSignatureByUserId(wSspRpt_PrintOrder_Result.ordReferUserId));
								if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
								{
									parameters.SignatureReferUser = cRMspSelectUserSignatureByUserId_Result.Signature;
								}
								cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)_db.CRMspSelectUserSignatureByUserId(wSspRpt_PrintOrder_Result.UserId));
								if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
								{
									parameters.SignatureLastEditUser = cRMspSelectUserSignatureByUserId_Result.Signature;
								}
								cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)_db.CRMspSelectUserSignatureByUserId(wSspRpt_PrintOrder_Result.ordVerifierId));
								if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
								{
									parameters.SignatureVerifierUser = cRMspSelectUserSignatureByUserId_Result.Signature;
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
							FOMobspReturnSumCompanyScores_Result fOMobspReturnSumCompanyScores_Result = Enumerable.FirstOrDefault<FOMobspReturnSumCompanyScores_Result>((IEnumerable<FOMobspReturnSumCompanyScores_Result>)_dbI.FOMobspReturnSumCompanyScores(num2, cId));
							if (fOMobspReturnSumCompanyScores_Result != null)
							{
								parameters.SumScores = fOMobspReturnSumCompanyScores_Result.SumScores;
								parameters.SumUsableScores = fOMobspReturnSumCompanyScores_Result.SumUsableScores;
							}
							List<ScorespSelectOrderScores_Result> list7 = Enumerable.ToList<ScorespSelectOrderScores_Result>((IEnumerable<ScorespSelectOrderScores_Result>)_dbI.ScorespSelectOrderScores(ordId, currLangId, defLangId, cId));
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
										vmLkAcc.OrdId = ordId;
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
							if (cId != 0 && cId.HasValue && !string.IsNullOrWhiteSpace(text4))
							{
								if (!text4.EndsWith("\\"))
								{
									text4 += "\\";
								}
								text4 = text4 + cId + "\\";
							}
							if (mobspReturnPrintFormatFileNameById_Result != null)
							{
								text5 = mobspReturnPrintFormatFileNameById_Result.FileNameWeb;
							}
							if (string.IsNullOrEmpty(text5))
							{
								text5 = "OrderPrint.mrt";
							}
							if (!System.IO.File.Exists(text4 + text5))
							{
								text5 = "OrderPrint.mrt";
								if (cId != 0 && cId.HasValue)
								{
									text4 = text4.Replace(cId + "\\", "");
								}
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
							string text10 = HttpContext.Current.Server.MapPath("~/Download") + "\\Reports\\Files\\" + token2.CompanyId;
							if (!System.IO.Directory.Exists(text10))
							{
								System.IO.Directory.CreateDirectory(text10);
								CRM.General.IO.Directory.SetFullControlForEveryOne(text10);
							}
							string path = text10 + "\\Ord-" + text7 + "-" + now.ToString("yyyyMMdd") + ".pdf";
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
							string text11 = text10 + "\\ORD-" + text7 + "-" + now.ToString("yyyyMMdd") + ".pdf";
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
												goto end_IL_1b27;
											case 0:
												pdfPage.Size = PageSize.A3;
												goto end_IL_1b27;
											case 1:
												pdfPage.Size = PageSize.A4;
												goto end_IL_1b27;
											case 3:
												pdfPage.Size = PageSize.A5;
												goto end_IL_1b27;
											case 4:
												pdfPage.Size = PageSize.B4;
												goto end_IL_1b27;
											case 5:
												pdfPage.Size = PageSize.B5;
												goto end_IL_1b27;
											case 2:
												break;
											}
											pdfPage.Size = PageSize.A4;
											end_IL_1b27:;
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
							string[] array = HttpContext.Current.Request.Url.AbsoluteUri.Split(new string[1] { "/api/" }, StringSplitOptions.None);
							string text13 = "";
							if (array != null)
							{
								string text14 = "/Download/Reports/Files/" + token2.CompanyId + "/Ord-" + text7 + "-" + now.ToString("yyyyMMdd") + ".pdf";
								text13 = ((array[0] != null && array[0] != "") ? (array[0] + text14) : "");
							}
							FoPrintLog.InsertPrintLog(token2.CompanyId, ordId, 2, 3);
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
}
