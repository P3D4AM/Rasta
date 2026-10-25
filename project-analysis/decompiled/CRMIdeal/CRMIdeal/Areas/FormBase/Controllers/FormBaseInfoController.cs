using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Cache.User;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.FormBase.Controllers;

public class FormBaseInfoController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass14_0
	{
		public int id;
	}

	private CRMSpEntities db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private CRMSpIEntities _dbI = new CRMSpIEntities();

	private CRMSpIIEntities _dbII = new CRMSpIIEntities();

	protected override void Dispose(bool disposing)
	{
		db.Dispose();
		_dbTbl.Dispose();
		_dbI.Dispose();
		_dbII.Dispose();
		base.Dispose(disposing);
	}

	public ActionResult Index()
	{
		return View();
	}

	[LoginAuthorize]
	public ActionResult FormBaseInfo(string Position)
	{
		string TypeAction = "";
		string FormName = "";
		FindPosition(Position, ref TypeAction, ref FormName);
		if (FormName != "" && TypeAction != "" && FormName != "PordPay1" && FormName != "BordPay1" && FormName != "PayRollPay1" && FormName != "BankAccType" && !UserLogin.IsUserAccess(FormName, TypeAction, UserLogin.CurrentUser))
		{
			return RedirectToAction("Login", "Account", (object)new
			{
				area = "",
				d = DateTime.Now
			});
		}
		if (FormName == "" && TypeAction == "")
		{
			return RedirectToAction("Login", "Account", (object)new
			{
				area = "",
				d = DateTime.Now
			});
		}
		FormFullBaseInfoViewModel formFullBaseInfoViewModel = FullForm(TypeAction);
		GetItemListForFo(formFullBaseInfoViewModel.TypeAction);
		return View(formFullBaseInfoViewModel);
	}

	public void FindPosition(string Position, ref string TypeAction, ref string FormName)
	{
		switch (Position)
		{
		case "TMBI15":
			TypeAction = "actDefinecmpTitle";
			FormName = "frmMain";
			break;
		case "CMP1":
			TypeAction = "actDefinecmpTitle";
			FormName = "frmCompanyI";
			break;
		case "TMBI16":
			TypeAction = "actDefinecmpPresentation";
			FormName = "frmMain";
			break;
		case "CMP2":
			TypeAction = "actDefinecmpPresentation";
			FormName = "frmCompanyI";
			break;
		case "TMBI17":
			TypeAction = "actDefinecmpType";
			FormName = "frmMain";
			break;
		case "CMP3":
			TypeAction = "actDefinecmpType";
			FormName = "frmCompanyI";
			break;
		case "TMBI11":
			TypeAction = "actDefinecmpGroups";
			FormName = "frmMain";
			break;
		case "CMP4":
			TypeAction = "actDefinecmpGroup";
			FormName = "frmCompanyI";
			break;
		case "TMBI12":
			TypeAction = "actDefinecmpGroupsII";
			FormName = "frmMain";
			break;
		case "CMP5":
			TypeAction = "actDefinecmpGroupII";
			FormName = "frmCompanyI";
			break;
		case "TMBI13":
			TypeAction = "actDefinecmpGroupsIII";
			FormName = "frmMain";
			break;
		case "CMP6":
			TypeAction = "actDefinecmpGroupIII";
			FormName = "frmCompanyI";
			break;
		case "TMBI14":
			TypeAction = "actDefinecmpGroupsIV";
			FormName = "frmMain";
			break;
		case "CMP7":
			TypeAction = "actDefinecmpGroupIV";
			FormName = "frmCompanyI";
			break;
		case "CMP8":
			TypeAction = "actDefinecmpGroupMulti";
			FormName = "frmCompanyI";
			break;
		case "TMBICMP8":
			TypeAction = "actDefinecmpGroupsMulti";
			FormName = "frmMain";
			break;
		case "PRS1":
			TypeAction = "actDefineprsTitle";
			FormName = "frmCompanyI";
			break;
		case "PRS10":
			TypeAction = "actDefineprsTitle";
			FormName = "frmDefineCompanyPersonTemplate";
			break;
		case "PRS4":
			TypeAction = "actDefineprsTitle";
			FormName = "frmDefineCompanyPerson";
			break;
		case "PRS2":
			TypeAction = "actDefineprsJobs";
			FormName = "frmCompanyI";
			break;
		case "PRS5":
			TypeAction = "actDefineprsJobs";
			FormName = "frmDefineCompanyPerson";
			break;
		case "PRS11":
			TypeAction = "actDefineprsJobs";
			FormName = "frmDefineCompanyPersonTemplate";
			break;
		case "TMBI22":
			TypeAction = "actDefinePrsTitle";
			FormName = "frmMain";
			break;
		case "TMBI23":
			TypeAction = "actDefinePrsJobs";
			FormName = "frmMain";
			break;
		case "PRS3":
			TypeAction = "actDefineprsDepartment";
			FormName = "frmCompanyI";
			break;
		case "PRS12":
			TypeAction = "actDefineprsDepartment";
			FormName = "frmDefineCompanyPersonTemplate";
			break;
		case "PRS6":
			TypeAction = "actDefineprsDepartment";
			FormName = "frmDefineCompanyPerson";
			break;
		case "TMBI24":
			TypeAction = "actDefineprsType";
			FormName = "frmMain";
			break;
		case "PRS7":
			TypeAction = "actDefineprsType";
			FormName = "frmDefineCompanyPerson";
			break;
		case "PRS13":
			TypeAction = "actDefineprsType";
			FormName = "frmDefineCompanyPersonTemplate";
			break;
		case "TMBI21":
			TypeAction = "actDefineprsGroups";
			FormName = "frmMain";
			break;
		case "PRS8":
			TypeAction = "actDefineprsGroup";
			FormName = "frmDefineCompanyPerson";
			break;
		case "PRS14":
			TypeAction = "actDefineprsGroup";
			FormName = "frmDefineCompanyPersonTemplate";
			break;
		case "TMBI6":
			TypeAction = "actDefineEducation";
			FormName = "frmMain";
			break;
		case "PRS9":
			TypeAction = "actDefineEducation";
			FormName = "frmDefineCompanyPerson";
			break;
		case "PRS15":
			TypeAction = "actDefineEducation";
			FormName = "frmDefineCompanyPersonTemplate";
			break;
		case "TMBI33":
			TypeAction = "actDefinecnvsStatusGroups";
			FormName = "frmMain";
			break;
		case "DCnvsS1":
			TypeAction = "actDefineGroups";
			FormName = "frmDefinecnvsStatusDataEntry";
			break;
		case "TMBI31":
			TypeAction = "actDefinePrjGroup";
			FormName = "frmMain";
			break;
		case "TMBI32":
			TypeAction = "actDefinePrjGrade";
			FormName = "frmMain";
			break;
		case "TMBI41":
			TypeAction = "actDefinecnvsTopics";
			FormName = "frmMain";
			break;
		case "CNVS1":
			TypeAction = "actDefineTopic";
			FormName = "frmDefineConversation";
			break;
		case "CRP1":
			TypeAction = "actUTDefineGroup";
			FormName = "";
			break;
		case "KT1":
			TypeAction = "actDefineKnowledgeTankGroup";
			FormName = "frmKnowledgeTankDataEntry";
			break;
		case "KT2":
			TypeAction = "actDefineKnowledgeTankPriority";
			FormName = "frmKnowledgeTankDataEntry";
			break;
		case "TMS1":
			TypeAction = "actluDepartment";
			FormName = "frmMain";
			break;
		case "TMBI18":
			TypeAction = "actDefinecmpFileType";
			FormName = "frmMain";
			break;
		case "TMBI7":
			TypeAction = "actDefineSex";
			FormName = "frmMain";
			break;
		case "TMBI51":
			TypeAction = "actDefineInternalMessagePriority";
			FormName = "frmMain";
			break;
		case "TMBI52":
			TypeAction = "actDefineInternalMessageGroup";
			FormName = "frmMain";
			break;
		case "DSms1":
			TypeAction = "actDefinewdblkpcmbDefaultBodyTextGroups";
			FormName = "frmsmsDefaultBodyText";
			break;
		case "TMBPOrd1":
			TypeAction = "actGuaranty";
			FormName = "frmMain";
			break;
		case "PRDCG1":
			TypeAction = "actDefineCostGroups";
			FormName = "frmProductsCost";
			break;
		case "PRDPG1":
			TypeAction = "actDefinePriceGroups";
			FormName = "frmProductsPrice";
			break;
		case "FType":
			TypeAction = "actDefineFileType";
			FormName = "frmFileDataEntry";
			break;
		case "Pord1":
			TypeAction = "actDefinePreOrderOpr";
			FormName = "frmPreOrderDataEntry";
			break;
		case "TMPO6":
			TypeAction = "actpordPreOrderOpr";
			FormName = "frmMain";
			break;
		case "PordDS5":
			TypeAction = "actDefinePreOrderOpr";
			FormName = "frmPreOrderDefultSetting";
			break;
		case "Pord2":
			TypeAction = "actDefineGuaranty";
			FormName = "frmPreOrderDataEntry";
			break;
		case "TMPO1":
			TypeAction = "actGuaranty";
			FormName = "frmMain";
			break;
		case "PordDS1":
			TypeAction = "actDefineGuaranty";
			FormName = "frmPreOrderDefultSetting";
			break;
		case "Pord3":
			TypeAction = "actDefineDeliveryTime";
			FormName = "frmPreOrderDataEntry";
			break;
		case "TMPO2":
			TypeAction = "actpordDeliveryTime";
			FormName = "frmMain";
			break;
		case "PordDS2":
			TypeAction = "actDefineDeliveryTime";
			FormName = "frmPreOrderDefultSetting";
			break;
		case "Pord4":
			TypeAction = "actDefinePayCondition";
			FormName = "frmPreOrderDataEntry";
			break;
		case "TMPO3":
			TypeAction = "actpordPayCondition";
			FormName = "frmMain";
			break;
		case "PordDS3":
			TypeAction = "actDefinePayCondition";
			FormName = "frmPreOrderDefultSetting";
			break;
		case "Pord5":
			TypeAction = "actDefineCreditDuration";
			FormName = "frmPreOrderDataEntry";
			break;
		case "PORD6":
			TypeAction = "actDefineReasonGroup";
			FormName = "frmPreOrder";
			break;
		case "TMPO4":
			TypeAction = "actpordCreditDuration";
			FormName = "frmMain";
			break;
		case "PordDS4":
			TypeAction = "actDefineCreditDuration";
			FormName = "frmPreOrderDefultSetting";
			break;
		case "TMPO5":
			TypeAction = "actpordDefinePreOrderStatus";
			FormName = "frmMain";
			break;
		case "PordPay1":
		case "OrdPay1":
			TypeAction = "PordPay1";
			FormName = "PordPay1";
			break;
		case "BordPay1":
			TypeAction = "BordPay1";
			FormName = "BordPay1";
			break;
		case "Ord1":
			TypeAction = "actDefineGuaranty";
			FormName = "frmOrderDataEntry";
			break;
		case "Ord2":
			TypeAction = "actDefineSettlementType";
			FormName = "frmOrderDataEntry";
			break;
		case "TMSO1":
			TypeAction = "actordDefineSettlementType";
			FormName = "frmMain";
			break;
		case "OrdDS1":
			TypeAction = "actDefineGuaranty";
			FormName = "frmOrderDefultSetting";
			break;
		case "PrjInfoTree1":
			TypeAction = "actDefinePrjGroupsMulti";
			FormName = "frmProjectInformationTree";
			break;
		case "PrjInfoTree2":
			TypeAction = "actDefinePrjGroupsMultiI";
			FormName = "frmProjectInformationTree";
			break;
		case "PayRollPay1":
			TypeAction = "PayRollPay1";
			FormName = "PayRollPay1";
			break;
		case "CommPay":
			TypeAction = "actDefinePayType";
			FormName = "frmCommissionDataEntry";
			break;
		case "Ctsh1":
			TypeAction = "actDefineDyFieldGroup";
			FormName = "frmCostsheetDyFieldTitleDataEntry";
			break;
		case "UserGp1":
			TypeAction = "actDefineUserGroups";
			FormName = "frmMain";
			break;
		case "DTerm":
			TypeAction = "actDefineDeliveryTerm";
			FormName = "frmMain";
			break;
		case "PordType":
			TypeAction = "actpordDefinePreOrderType";
			FormName = "frmMain";
			break;
		case "SaleCenter":
			TypeAction = "actDefineSaleCenter";
			FormName = "frmMain";
			break;
		case "SaleArea":
			TypeAction = "actDefineSaleArea";
			FormName = "frmMain";
			break;
		case "CmpAddType":
			TypeAction = "actDefineCmpAddType";
			FormName = "frmCompanyAddressDataEntry";
			break;
		case "LeaveKind":
			TypeAction = "acthrDefineLeaveKind";
			FormName = "frmMain";
			break;
		case "LeaveStayType":
			TypeAction = "acthrDefineLeaveStayType";
			FormName = "frmMain";
			break;
		case "LeaveVehicleType":
			TypeAction = "acthrDefineLeaveVehicleType";
			FormName = "frmMain";
			break;
		case "PayRollListGroup":
			TypeAction = "actPayRollDefineListGroup";
			FormName = "frmMain";
			break;
		case "BankAccType":
			TypeAction = "BankAccType";
			FormName = "BankAccType";
			break;
		case "OrdGroup":
			TypeAction = "actordDefineOrderGroup";
			FormName = "frmMain";
			break;
		case "Cash":
			TypeAction = "actDefineCash";
			FormName = "frmMain";
			break;
		case "PordPayGroupI":
			TypeAction = "actpordDefinePayGroupI";
			FormName = "frmMain";
			break;
		case "PordPayGroupII":
			TypeAction = "actpordDefinePayGroupII";
			FormName = "frmMain";
			break;
		case "OrdPayGroupI":
			TypeAction = "actordDefinePayGroupI";
			FormName = "frmMain";
			break;
		case "OrdPayGroupII":
			TypeAction = "actordDefinePayGroupII";
			FormName = "frmMain";
			break;
		default:
			TypeAction = "";
			FormName = "";
			break;
		}
	}

	public FormFullBaseInfoViewModel FullForm(string TypeAction)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int num = 0;
		if (UserLogin.CurrentUser != null)
		{
			num = UserLogin.CurrentUser.UserId;
		}
		FormFullBaseInfoViewModel formFullBaseInfoViewModel = new FormFullBaseInfoViewModel();
		switch (TypeAction)
		{
		case "actDefineCountry":
			formFullBaseInfoViewModel.TitlePage = Labels.frmCountryTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineCountry";
			formFullBaseInfoViewModel.TypeAction = "actDefineCountry";
			formFullBaseInfoViewModel.NameTabel = "Country";
			formFullBaseInfoViewModel.NamefieldID = "CountryID";
			formFullBaseInfoViewModel.NamefieldI = "Country";
			formFullBaseInfoViewModel.NamefieldII = "";
			formFullBaseInfoViewModel.NamefieldIII = "CountryCode";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "actDefinecmpTitle":
			formFullBaseInfoViewModel.TitlePage = Labels.frmCompanyTitleTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfo";
			formFullBaseInfoViewModel.TypeAction = "actDefinecmpTitle";
			formFullBaseInfoViewModel.NameTabel = "CrmCompanyTitle";
			formFullBaseInfoViewModel.NameTabel_Lang = "CRMspSelectCompanyTitle";
			formFullBaseInfoViewModel.NameTabel_Delete = "CRMspDeleteCrmCompanyTitle";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.NamefieldID = "CompanyTitleID";
			formFullBaseInfoViewModel.NamefieldI = "CompanyTitle";
			formFullBaseInfoViewModel.NamefieldII = "";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "actDefinecmpPresentation":
			formFullBaseInfoViewModel.TitlePage = Labels.frmCompanyPresentationTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfo";
			formFullBaseInfoViewModel.TypeAction = "actDefinecmpPresentation";
			formFullBaseInfoViewModel.NameTabel = "CrmCompanyPresentation";
			formFullBaseInfoViewModel.NameTabel_Lang = "CRMspSelectCompanyPresentation";
			formFullBaseInfoViewModel.NameTabel_Delete = "CRMspDeleteCrmCompanyPresentation";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.NamefieldID = "CompanyPresentationID";
			formFullBaseInfoViewModel.NamefieldI = "Presentation";
			formFullBaseInfoViewModel.NamefieldII = "";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "actDefinecmpType":
			formFullBaseInfoViewModel.TitlePage = Labels.frmCompanyTypeTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfo";
			formFullBaseInfoViewModel.TypeAction = "actDefinecmpType";
			formFullBaseInfoViewModel.NameTabel = "CrmCompanyType";
			formFullBaseInfoViewModel.NameTabel_Lang = "CRMspSelectCompanyType";
			formFullBaseInfoViewModel.NameTabel_Delete = "CRMspDeleteCrmCompanyType";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.NamefieldID = "CompanyTypeID";
			formFullBaseInfoViewModel.NamefieldI = "CompanyTypeName";
			formFullBaseInfoViewModel.NamefieldII = "";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "actDefineCmpAddType":
			formFullBaseInfoViewModel.TitlePage = Labels.frmCompanyAddressTypeTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfo";
			formFullBaseInfoViewModel.TypeAction = "actDefineCmpAddType";
			formFullBaseInfoViewModel.NameTabel = "CrmCompanyAddressType";
			formFullBaseInfoViewModel.NameTabel_Lang = "CRMspSelectCompanyAddressType";
			formFullBaseInfoViewModel.NameTabel_Delete = "CRMspDeleteCompanyAddressType";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.NamefieldID = "CompanyAddressTypeId";
			formFullBaseInfoViewModel.NamefieldI = "CompanyAddressTypeName";
			formFullBaseInfoViewModel.NamefieldII = "";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "actDefinecmpGroup":
		case "actDefinecmpGroups":
			formFullBaseInfoViewModel.TitlePage = Labels.frmCompanyGroupTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfoI";
			formFullBaseInfoViewModel.TypeAction = "actDefinecmpGroups";
			formFullBaseInfoViewModel.NameTabel = "CrmCompanyGroups";
			formFullBaseInfoViewModel.NamefieldID = "CompanyGroupID";
			formFullBaseInfoViewModel.NameTabel_Lang = "CRMspSelectCompanyGroup";
			formFullBaseInfoViewModel.NameTabel_Delete = "CRMspDeleteCrmCompanyGroups";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.Parametes = $"{UserLogin.CurrentUser.UserId}, {lCID}, {result}";
			formFullBaseInfoViewModel.NamefieldI = "GroupName";
			formFullBaseInfoViewModel.NamefieldII = "GroupDesc";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "visible";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "ScoreRate";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "visible";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "actDefinecmpGroupII":
		case "actDefinecmpGroupsII":
			formFullBaseInfoViewModel.TitlePage = Labels.frmCompanyGroupIITitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfoI";
			formFullBaseInfoViewModel.TypeAction = "actDefinecmpGroupsII";
			formFullBaseInfoViewModel.NameTabel = "CrmCompanyGroupsII";
			formFullBaseInfoViewModel.NameTabel_Lang = "CRMspSelectCompanyGroupsII";
			formFullBaseInfoViewModel.NameTabel_Delete = "CRMspDeleteCrmCompanyGroupsII";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.NamefieldID = "CompanyGroupIIID";
			formFullBaseInfoViewModel.NamefieldI = "GroupIIName";
			formFullBaseInfoViewModel.NamefieldII = "GroupIIDesc";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "visible";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVII = "Rate";
			formFullBaseInfoViewModel.ItemRateVisibale = "visible";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "ScoreRate";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "visible";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "actDefinecmpGroupIII":
		case "actDefinecmpGroupsIII":
			formFullBaseInfoViewModel.TitlePage = Labels.frmCompanyGroupIIITitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfoI";
			formFullBaseInfoViewModel.TypeAction = "actDefinecmpGroupsIII";
			formFullBaseInfoViewModel.NameTabel = "CrmCompanyGroupsIII";
			formFullBaseInfoViewModel.NameTabel_Lang = "CRMspSelectCompanyGroupsIII";
			formFullBaseInfoViewModel.NameTabel_Delete = "CRMspDeleteCRMCompanyGroupsIII";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.NamefieldID = "CompanyGroupIIIID";
			formFullBaseInfoViewModel.NamefieldI = "GroupIIIName";
			formFullBaseInfoViewModel.NamefieldII = "GroupIIIDesc";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "visible";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "ScoreRate";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "visible";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "actDefinecmpGroupIV":
		case "actDefinecmpGroupsIV":
			formFullBaseInfoViewModel.TitlePage = Labels.frmCompanyGroupIVTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfoI";
			formFullBaseInfoViewModel.TypeAction = "actDefinecmpGroupsIV";
			formFullBaseInfoViewModel.NameTabel = "CrmCompanyGroupsIV";
			formFullBaseInfoViewModel.NameTabel_Lang = "CRMspSelectCompanyGroupsIV";
			formFullBaseInfoViewModel.NameTabel_Delete = "CRMspDeleteCrmCompanyGroupsIV";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.Parametes = $"{UserLogin.CurrentUser.UserId}, {lCID}, {result}";
			formFullBaseInfoViewModel.NamefieldID = "CompanyGroupIVID";
			formFullBaseInfoViewModel.NamefieldI = "GroupIVName";
			formFullBaseInfoViewModel.NamefieldII = "GroupIVDesc";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "visible";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "ScoreRate";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "visible";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "actDefinecmpGroupsMulti":
		case "actDefinecmpGroupMulti":
			formFullBaseInfoViewModel.TitlePage = Labels.frmCompanyGroupsMultiTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfoI";
			formFullBaseInfoViewModel.TypeAction = "actDefinecmpGroupsMulti";
			formFullBaseInfoViewModel.NameTabel = "CrmCompanyGroupsMulti";
			formFullBaseInfoViewModel.NameTabel_Lang = "CRMspSelectCompanyGroupsMulti";
			formFullBaseInfoViewModel.NameTabel_Delete = "CRMspDeleteCrmCompanyGroupsMulti";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.NamefieldID = "CompanyGroupsMultiID";
			formFullBaseInfoViewModel.NamefieldI = "CompanyGroupsMultiName";
			formFullBaseInfoViewModel.NamefieldII = "CompanyGroupsMultiDesc";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "visible";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "actDefinePrsTitle":
			formFullBaseInfoViewModel.TitlePage = Labels.frmPersonTitleTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfo";
			formFullBaseInfoViewModel.TypeAction = "actDefinePrsTitle";
			formFullBaseInfoViewModel.NameTabel = "CrmPersonTitle";
			formFullBaseInfoViewModel.NameTabel_Lang = "CRMspSelectPersonTitle";
			formFullBaseInfoViewModel.NameTabel_Delete = "CRMspDeleteCrmPersonTitle";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.NamefieldID = "PersonTitleID";
			formFullBaseInfoViewModel.NamefieldI = "PersonTitle";
			formFullBaseInfoViewModel.NamefieldII = "";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "actDefineprsTitle":
			formFullBaseInfoViewModel.TitlePage = Labels.frmPersonTitleTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfo";
			formFullBaseInfoViewModel.TypeAction = "actDefineprsTitle";
			formFullBaseInfoViewModel.NameTabel = "CrmPersonTitle";
			formFullBaseInfoViewModel.NameTabel_Lang = "CRMspSelectPersonTitle";
			formFullBaseInfoViewModel.NameTabel_Delete = "CRMspDeleteCrmPersonTitle";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.NamefieldID = "PersonTitleID";
			formFullBaseInfoViewModel.NamefieldI = "PersonTitle";
			formFullBaseInfoViewModel.NamefieldII = "";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "actDefinePrsJobs":
			formFullBaseInfoViewModel.TitlePage = Labels.frmPersonJobTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfo";
			formFullBaseInfoViewModel.TypeAction = "actDefinePrsJobs";
			formFullBaseInfoViewModel.NameTabel = "CrmPersonJobs";
			formFullBaseInfoViewModel.NameTabel_Lang = "CRMspSelectPersonJobs";
			formFullBaseInfoViewModel.NameTabel_Delete = "CRMspDeleteCrmPersonJobs";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.NamefieldID = "PersonJobID";
			formFullBaseInfoViewModel.NamefieldI = "Jobs";
			formFullBaseInfoViewModel.NamefieldII = "";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "actDefineprsJobs":
			formFullBaseInfoViewModel.TitlePage = Labels.frmPersonJobTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfo";
			formFullBaseInfoViewModel.TypeAction = "actDefineprsJobs";
			formFullBaseInfoViewModel.NameTabel = "CrmPersonJobs";
			formFullBaseInfoViewModel.NameTabel_Lang = "CRMspSelectPersonJobs";
			formFullBaseInfoViewModel.NameTabel_Delete = "CRMspDeleteCrmPersonJobs";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.NamefieldID = "PersonJobID";
			formFullBaseInfoViewModel.NamefieldI = "Jobs";
			formFullBaseInfoViewModel.NamefieldII = "";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "actDefineprsDepartment":
			formFullBaseInfoViewModel.TitlePage = Labels.frmPersonDepartmentTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfo";
			formFullBaseInfoViewModel.TypeAction = "actDefineprsDepartment";
			formFullBaseInfoViewModel.NameTabel = "CrmPersonDepartments";
			formFullBaseInfoViewModel.NameTabel_Lang = "CRMspSelectPersonDepartments";
			formFullBaseInfoViewModel.NameTabel_Delete = "CRMspDeleteCrmPersonDepartments";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.NamefieldID = "PersonDepartmentId";
			formFullBaseInfoViewModel.NamefieldI = "PersonDepartment";
			formFullBaseInfoViewModel.NamefieldII = "";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "actDefineprsType":
			formFullBaseInfoViewModel.TitlePage = Labels.frmPersonTypeTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfo";
			formFullBaseInfoViewModel.TypeAction = "actDefineprsType";
			formFullBaseInfoViewModel.NameTabel = "CrmPersonType";
			formFullBaseInfoViewModel.NameTabel_Lang = "CRMspSelectPersonType";
			formFullBaseInfoViewModel.NameTabel_Delete = "CRMspDeleteCrmPersonType";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.NamefieldID = "PersonTypeID";
			formFullBaseInfoViewModel.NamefieldI = "PersonType";
			formFullBaseInfoViewModel.NamefieldII = "";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "actDefineprsGroups":
			formFullBaseInfoViewModel.TitlePage = Labels.frmPersonGroupTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfo";
			formFullBaseInfoViewModel.TypeAction = "actDefineprsGroups";
			formFullBaseInfoViewModel.NameTabel = "CrmPersonGroups";
			formFullBaseInfoViewModel.NameTabel_Lang = "CRMspSelectPersonGroups";
			formFullBaseInfoViewModel.NameTabel_Delete = "CRMspDeleteCrmPersonGroups";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.NamefieldID = "PersonGroupID";
			formFullBaseInfoViewModel.NamefieldI = "PersonGroup";
			formFullBaseInfoViewModel.NamefieldII = "";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "actDefineprsGroup":
			formFullBaseInfoViewModel.TitlePage = Labels.frmPersonGroupTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfo";
			formFullBaseInfoViewModel.TypeAction = "actDefineprsGroup";
			formFullBaseInfoViewModel.NameTabel = "CrmPersonGroups";
			formFullBaseInfoViewModel.NameTabel_Lang = "CRMspSelectPersonGroups";
			formFullBaseInfoViewModel.NameTabel_Delete = "CRMspDeleteCrmPersonGroups";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.NamefieldID = "PersonGroupID";
			formFullBaseInfoViewModel.NamefieldI = "PersonGroup";
			formFullBaseInfoViewModel.NamefieldII = "";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "actDefineEducation":
			formFullBaseInfoViewModel.TitlePage = Labels.frmPersonEducationTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfo";
			formFullBaseInfoViewModel.TypeAction = "actDefineEducation";
			formFullBaseInfoViewModel.NameTabel = "Education";
			formFullBaseInfoViewModel.NameTabel_Lang = "CRMspSelectEducation";
			formFullBaseInfoViewModel.NameTabel_Delete = "CRMspDeleteEducation";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.NamefieldID = "EducationID";
			formFullBaseInfoViewModel.NamefieldI = "Education";
			formFullBaseInfoViewModel.NamefieldII = "";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "actDefinecnvsStatusGroups":
			formFullBaseInfoViewModel.TitlePage = Labels.frmConversationStatusGroupsTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfoI";
			formFullBaseInfoViewModel.TypeAction = "actDefinecnvsStatusGroups";
			formFullBaseInfoViewModel.NameTabel = "CrmConversationStatusGroups";
			formFullBaseInfoViewModel.NameTabel_Lang = "CRMspSelectConversationStatusGroups";
			formFullBaseInfoViewModel.NameTabel_Delete = "CRMspDeleteCrmConversationStatusGroups";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.NamefieldID = "ConversationStatusGroupID";
			formFullBaseInfoViewModel.NamefieldI = "ConversationStatusGroup";
			formFullBaseInfoViewModel.NamefieldII = "ConversationStatusGroupDesc";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "visible";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "actDefineGroups":
			formFullBaseInfoViewModel.TitlePage = Labels.frmConversationStatusGroupsTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfoI";
			formFullBaseInfoViewModel.TypeAction = "actDefineGroups";
			formFullBaseInfoViewModel.NameTabel = "CrmConversationStatusGroups";
			formFullBaseInfoViewModel.NameTabel_Lang = "CRMspSelectConversationStatusGroups";
			formFullBaseInfoViewModel.NameTabel_Delete = "CRMspDeleteCrmConversationStatusGroups";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.NamefieldID = "ConversationStatusGroupID";
			formFullBaseInfoViewModel.NamefieldI = "ConversationStatusGroup";
			formFullBaseInfoViewModel.NamefieldII = "ConversationStatusGroupDesc";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "visible";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "actDefinePrjGroup":
			formFullBaseInfoViewModel.TitlePage = Labels.frmProjectGroupsTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfo";
			formFullBaseInfoViewModel.TypeAction = "actDefinePrjGroup";
			formFullBaseInfoViewModel.NameTabel = "CrmProjectGroups";
			formFullBaseInfoViewModel.NameTabel_Lang = "CRMspSelectProjectGroups";
			formFullBaseInfoViewModel.NameTabel_Delete = "CRMspDeleteCrmProjectGroups";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.NamefieldID = "ProjectGroupID";
			formFullBaseInfoViewModel.NamefieldI = "ProjectGroup";
			formFullBaseInfoViewModel.NamefieldII = "";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "actDefinePrjGrade":
			formFullBaseInfoViewModel.TitlePage = Labels.frmProjectGradeTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfo";
			formFullBaseInfoViewModel.TypeAction = "actDefinePrjGrade";
			formFullBaseInfoViewModel.NameTabel = "CrmProjectGrade";
			formFullBaseInfoViewModel.NameTabel_Lang = "CRMspSelectProjectGrade";
			formFullBaseInfoViewModel.NameTabel_Delete = "CRMspDeleteCrmProjectGrade";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.NamefieldID = "ProjectGradeID";
			formFullBaseInfoViewModel.NamefieldI = "ProjectGrade";
			formFullBaseInfoViewModel.NamefieldII = "";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "actDefinecnvsTopics":
			formFullBaseInfoViewModel.TitlePage = Labels.frmConversationTopicTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfoI";
			formFullBaseInfoViewModel.TypeAction = "actDefinecnvsTopics";
			formFullBaseInfoViewModel.NameTabel = "CrmConversationTopics";
			formFullBaseInfoViewModel.NameTabel_Lang = "CRMspSelectConversationTopics";
			formFullBaseInfoViewModel.NameTabel_Delete = "CRMspDeleteCrmConversationTopics";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.NamefieldID = "ConversationTopicsID";
			formFullBaseInfoViewModel.NamefieldI = "Topic";
			formFullBaseInfoViewModel.NamefieldII = "TopicDesc";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "visible";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "visible";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "visible";
			formFullBaseInfoViewModel.NamefieldIX = "CheckUserDistanceCmp";
			formFullBaseInfoViewModel.NamefieldX = "UserDistanceCmpVal";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "actDefineTopic":
			formFullBaseInfoViewModel.TitlePage = Labels.frmConversationTopicTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfoI";
			formFullBaseInfoViewModel.TypeAction = "actDefineTopic";
			formFullBaseInfoViewModel.NameTabel = "CrmConversationTopics";
			formFullBaseInfoViewModel.NameTabel_Lang = "CRMspSelectConversationTopics";
			formFullBaseInfoViewModel.NameTabel_Delete = "CRMspDeleteCrmConversationTopics";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.NamefieldID = "ConversationTopicsID";
			formFullBaseInfoViewModel.NamefieldI = "Topic";
			formFullBaseInfoViewModel.NamefieldII = "TopicDesc";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "visible";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "visible";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "visible";
			formFullBaseInfoViewModel.NamefieldIX = "CheckUserDistanceCmp";
			formFullBaseInfoViewModel.NamefieldX = "UserDistanceCmpVal";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "actUTDefineGroup":
			formFullBaseInfoViewModel.TitlePage = Labels.frmUTaskGroupTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfo";
			formFullBaseInfoViewModel.TypeAction = "actUTDefineGroup";
			formFullBaseInfoViewModel.NameTabel = "CrmUserTaskGroups";
			formFullBaseInfoViewModel.Parametes = $"{UserLogin.CurrentUser.UserId}, {lCID}, {result}";
			formFullBaseInfoViewModel.NameTabel_Lang = "CRMspSelectUserTaskGroupsByUserId";
			formFullBaseInfoViewModel.NameTabel_Delete = "CRMspDeleteCrmUserTaskGroups";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.NamefieldID = "UserTaskGroupId";
			formFullBaseInfoViewModel.NamefieldI = "UserTaskGroup";
			formFullBaseInfoViewModel.NamefieldII = "";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "actDefineKnowledgeTankGroup":
			formFullBaseInfoViewModel.TitlePage = Labels.frmUTaskGroupTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfo";
			formFullBaseInfoViewModel.TypeAction = "actDefineKnowledgeTankGroup";
			formFullBaseInfoViewModel.NameTabel = "CrmKnowledgeTankGroup";
			formFullBaseInfoViewModel.NameTabel_Lang = "CRMspknlgSelectKnowledgeTankGroup";
			formFullBaseInfoViewModel.NameTabel_Delete = "CRMspDeleteCrmKnowledgeTankGroup";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.Parametes = $"{0}, {lCID}, {result}";
			formFullBaseInfoViewModel.NamefieldID = "KnowledgeTankGroupId";
			formFullBaseInfoViewModel.NamefieldI = "KnowledgeTankGroupTitle";
			formFullBaseInfoViewModel.NamefieldII = "";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "actDefineKnowledgeTankPriority":
			formFullBaseInfoViewModel.TitlePage = Labels.UserTaskDefinePriorityTitle;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfo";
			formFullBaseInfoViewModel.TypeAction = "actDefineKnowledgeTankPriority";
			formFullBaseInfoViewModel.NameTabel = "CrmKnowledgeTankPriority";
			formFullBaseInfoViewModel.NameTabel_Lang = "CRMspknlgSelectKnowledgeTankPriority";
			formFullBaseInfoViewModel.NameTabel_Delete = "CRMspDeleteCrmKnowledgeTankPriority";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.NamefieldID = "KnowledgeTankPriorityId";
			formFullBaseInfoViewModel.NamefieldI = "KnowledgeTankPriorityTitle";
			formFullBaseInfoViewModel.NamefieldII = "";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "actluDepartment":
			formFullBaseInfoViewModel.TitlePage = Labels.frmLuDepartmentTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfo";
			formFullBaseInfoViewModel.TypeAction = "actluDepartment";
			formFullBaseInfoViewModel.NameTabel = "UserDepartments";
			formFullBaseInfoViewModel.NameTabel_Lang = "CRMspSelectUserDepartments";
			formFullBaseInfoViewModel.NameTabel_Delete = "CRMspDeleteUserDepartments";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.NamefieldID = "DepartmentID";
			formFullBaseInfoViewModel.NamefieldI = "Department";
			formFullBaseInfoViewModel.NamefieldII = "";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "actDefinecmpFileType":
			formFullBaseInfoViewModel.TitlePage = Labels.frmDefinecmpFileTypeTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfo";
			formFullBaseInfoViewModel.TypeAction = "actDefinecmpFileType";
			formFullBaseInfoViewModel.NameTabel = "CrmFileDirectoryType";
			formFullBaseInfoViewModel.NamefieldID = "FileDirectoryTypeID";
			formFullBaseInfoViewModel.NamefieldI = "FileDirectoryType";
			formFullBaseInfoViewModel.NamefieldII = "";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "actDefineFileType":
			formFullBaseInfoViewModel.TitlePage = Labels.frmDefinecmpFileTypeTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfo";
			formFullBaseInfoViewModel.TypeAction = "actDefineFileType";
			formFullBaseInfoViewModel.NameTabel = "CrmFileDirectoryType";
			formFullBaseInfoViewModel.NamefieldID = "FileDirectoryTypeID";
			formFullBaseInfoViewModel.NamefieldI = "FileDirectoryType";
			formFullBaseInfoViewModel.NamefieldII = "";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "actDefineInternalMessagePriority":
			formFullBaseInfoViewModel.TitlePage = Labels.frmDefineInternalMessagePriorityTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfo";
			formFullBaseInfoViewModel.TypeAction = "actDefineInternalMessagePriority";
			formFullBaseInfoViewModel.NameTabel = "CrmInternalMessagePriority";
			formFullBaseInfoViewModel.NameTabel_Lang = "CRMspSelectInternalMessagePriority";
			formFullBaseInfoViewModel.NameTabel_Delete = "CRMspDeleteCrmInternalMessagePriority";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.NamefieldID = "InternalMessagePriorityID";
			formFullBaseInfoViewModel.NamefieldI = "InternalMessagePriority";
			formFullBaseInfoViewModel.NamefieldII = "";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "actDefineInternalMessageGroup":
			formFullBaseInfoViewModel.TitlePage = Labels.frmDefineInternalMessageGroupTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfo";
			formFullBaseInfoViewModel.TypeAction = "actDefineInternalMessageGroup";
			formFullBaseInfoViewModel.NameTabel = "CrmInternalMessageGroup";
			formFullBaseInfoViewModel.NameTabel_Lang = "CRMspSelectInternalMessageGroup";
			formFullBaseInfoViewModel.NameTabel_Delete = "CRMspDeleteCrmInternalMessageGroup";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.NamefieldID = "InternalMessageGroupID";
			formFullBaseInfoViewModel.NamefieldI = "InternalMessageGroup";
			formFullBaseInfoViewModel.NamefieldII = "";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldIV = "InternalMessageGroupOrder";
			formFullBaseInfoViewModel.ItemOrderVisibale = "visible";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "actDefineSex":
			formFullBaseInfoViewModel.TitlePage = Labels.frmDefineSexTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfoI";
			formFullBaseInfoViewModel.TypeAction = "actDefineSex";
			formFullBaseInfoViewModel.NameTabel = "Sex";
			formFullBaseInfoViewModel.NameTabel_Lang = "CRMspSelectSex";
			formFullBaseInfoViewModel.NameTabel_Delete = "CRMspDeleteSex";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.NamefieldID = "SexID";
			formFullBaseInfoViewModel.NamefieldI = "SexType";
			formFullBaseInfoViewModel.NamefieldII = "";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "actDefinewdblkpcmbDefaultBodyTextGroups":
			formFullBaseInfoViewModel.TitlePage = Labels.frmDefineBodyTextGroupsTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfoI";
			formFullBaseInfoViewModel.TypeAction = "actDefinewdblkpcmbDefaultBodyTextGroups";
			formFullBaseInfoViewModel.NameTabel = "SmsDefaultBodyTextGroups";
			formFullBaseInfoViewModel.NameTabel_Lang = "SmsspSelectDefaultBodyTextGroups";
			formFullBaseInfoViewModel.NameTabel_Delete = "SmsspDeleteSmsDefaultBodyTextGroups";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.NamefieldID = "Id";
			formFullBaseInfoViewModel.NamefieldI = "Name";
			formFullBaseInfoViewModel.NamefieldII = "";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "actDefineCostGroups":
			formFullBaseInfoViewModel.TitlePage = Labels.frmProductCostGroupTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfo";
			formFullBaseInfoViewModel.TypeAction = "actDefineCostGroups";
			formFullBaseInfoViewModel.NameTabel = "WSProductCostGroup";
			formFullBaseInfoViewModel.NamefieldID = "ProductCostGroupID";
			formFullBaseInfoViewModel.NamefieldI = "ProductCostGroupName";
			formFullBaseInfoViewModel.NamefieldII = "";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "actDefinePriceGroups":
			formFullBaseInfoViewModel.TitlePage = Labels.frmProductPriceGroupTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfo";
			formFullBaseInfoViewModel.TypeAction = "actDefinePriceGroups";
			formFullBaseInfoViewModel.NameTabel = "WSProductPriceGroup";
			formFullBaseInfoViewModel.NamefieldID = "ProductPriceGroupID";
			formFullBaseInfoViewModel.NamefieldI = "ProductPriceGroupName";
			formFullBaseInfoViewModel.NamefieldII = "";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "actDefinePreOrderOpr":
			formFullBaseInfoViewModel.TitlePage = Labels.WSPreOrderOprTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfo";
			formFullBaseInfoViewModel.TypeAction = "actDefinePreOrderOpr";
			formFullBaseInfoViewModel.NameTabel = "WSPreOrderOpr";
			formFullBaseInfoViewModel.NameTabel_Lang = "WSspSelectPreOrderOpr";
			formFullBaseInfoViewModel.NameTabel_Delete = "WSspDeleteWSPreOrderOpr";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.NamefieldID = "PreOrderOprID";
			formFullBaseInfoViewModel.NamefieldI = "PreOrderOpr";
			formFullBaseInfoViewModel.NamefieldII = "";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "actpordPreOrderOpr":
			formFullBaseInfoViewModel.TitlePage = Labels.WSPreOrderOprTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfo";
			formFullBaseInfoViewModel.TypeAction = "actpordPreOrderOpr";
			formFullBaseInfoViewModel.NameTabel = "WSPreOrderOpr";
			formFullBaseInfoViewModel.NameTabel_Lang = "WSspSelectPreOrderOpr";
			formFullBaseInfoViewModel.NameTabel_Delete = "WSspDeleteWSPreOrderOpr";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.NamefieldID = "PreOrderOprID";
			formFullBaseInfoViewModel.NamefieldI = "PreOrderOpr";
			formFullBaseInfoViewModel.NamefieldII = "";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "actDefineGuaranty":
			formFullBaseInfoViewModel.TitlePage = Labels.WSGuarantyTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfo";
			formFullBaseInfoViewModel.TypeAction = "actDefineGuaranty";
			formFullBaseInfoViewModel.NameTabel = "WSGuaranty";
			formFullBaseInfoViewModel.NameTabel_Lang = "WSspSelectGuaranty";
			formFullBaseInfoViewModel.NameTabel_Delete = "WSspDeleteWSGuaranty";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.NamefieldID = "GuarantyID";
			formFullBaseInfoViewModel.NamefieldI = "Guaranty";
			formFullBaseInfoViewModel.NamefieldII = "";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "actGuaranty":
			formFullBaseInfoViewModel.TitlePage = Labels.WSGuarantyTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfo";
			formFullBaseInfoViewModel.TypeAction = "actGuaranty";
			formFullBaseInfoViewModel.NameTabel = "WSGuaranty";
			formFullBaseInfoViewModel.NameTabel_Lang = "WSspSelectGuaranty";
			formFullBaseInfoViewModel.NameTabel_Delete = "WSspDeleteWSGuaranty";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.NamefieldID = "GuarantyID";
			formFullBaseInfoViewModel.NamefieldI = "Guaranty";
			formFullBaseInfoViewModel.NamefieldII = "";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "actDefineDeliveryTime":
			formFullBaseInfoViewModel.TitlePage = Labels.WSDefineDeliveryTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfo";
			formFullBaseInfoViewModel.TypeAction = "actDefineDeliveryTime";
			formFullBaseInfoViewModel.NameTabel = "WSDeliveryTime";
			formFullBaseInfoViewModel.NameTabel_Lang = "WSspSelectDeliveryTime";
			formFullBaseInfoViewModel.NameTabel_Delete = "WSspDeleteWSDeliveryTime";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.NamefieldID = "DeliveryTimeID";
			formFullBaseInfoViewModel.NamefieldI = "DeliveryTime";
			formFullBaseInfoViewModel.NamefieldII = "";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "actpordDeliveryTime":
			formFullBaseInfoViewModel.TitlePage = Labels.WSDefineDeliveryTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfo";
			formFullBaseInfoViewModel.TypeAction = "actpordDeliveryTime";
			formFullBaseInfoViewModel.NameTabel = "WSDeliveryTime";
			formFullBaseInfoViewModel.NameTabel_Lang = "WSspSelectDeliveryTime";
			formFullBaseInfoViewModel.NameTabel_Delete = "WSspDeleteWSDeliveryTime";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.NamefieldID = "DeliveryTimeID";
			formFullBaseInfoViewModel.NamefieldI = "DeliveryTime";
			formFullBaseInfoViewModel.NamefieldII = "";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "actDefinePayCondition":
			formFullBaseInfoViewModel.TitlePage = Labels.WSPayConditionTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfo";
			formFullBaseInfoViewModel.TypeAction = "actDefinePayCondition";
			formFullBaseInfoViewModel.NameTabel = "WSPayCondition";
			formFullBaseInfoViewModel.NameTabel_Lang = "WSspSelectPayCondition";
			formFullBaseInfoViewModel.NameTabel_Delete = "WSspDeleteWSPayCondition";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.NamefieldID = "PayConditionID";
			formFullBaseInfoViewModel.NamefieldI = "PayCondition";
			formFullBaseInfoViewModel.NamefieldII = "";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "actpordPayCondition":
			formFullBaseInfoViewModel.TitlePage = Labels.WSPayConditionTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfo";
			formFullBaseInfoViewModel.TypeAction = "actpordPayCondition";
			formFullBaseInfoViewModel.NameTabel = "WSPayCondition";
			formFullBaseInfoViewModel.NameTabel_Lang = "WSspSelectPayCondition";
			formFullBaseInfoViewModel.NameTabel_Delete = "WSspDeleteWSPayCondition";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.NamefieldID = "PayConditionID";
			formFullBaseInfoViewModel.NamefieldI = "PayCondition";
			formFullBaseInfoViewModel.NamefieldII = "";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "actDefineCreditDuration":
			formFullBaseInfoViewModel.TitlePage = Labels.WSCreditDurationTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfo";
			formFullBaseInfoViewModel.TypeAction = "actDefineCreditDuration";
			formFullBaseInfoViewModel.NameTabel = "WSCreditDuration";
			formFullBaseInfoViewModel.NameTabel_Lang = "WSspSelectCreditDuration";
			formFullBaseInfoViewModel.NameTabel_Delete = "WSspDeleteWSCreditDuration";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.NamefieldID = "CreditDurationID";
			formFullBaseInfoViewModel.NamefieldI = "CreditDuration";
			formFullBaseInfoViewModel.NamefieldII = "";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVII = "CreditDurationHours";
			formFullBaseInfoViewModel.ItemRateVisibale = "visible";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "actpordCreditDuration":
			formFullBaseInfoViewModel.TitlePage = Labels.WSCreditDurationTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfo";
			formFullBaseInfoViewModel.TypeAction = "actpordCreditDuration";
			formFullBaseInfoViewModel.NameTabel = "WSCreditDuration";
			formFullBaseInfoViewModel.NameTabel_Lang = "WSspSelectCreditDuration";
			formFullBaseInfoViewModel.NameTabel_Delete = "WSspDeleteWSCreditDuration";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.NamefieldID = "CreditDurationID";
			formFullBaseInfoViewModel.NamefieldI = "CreditDuration";
			formFullBaseInfoViewModel.NamefieldII = "";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVII = "CreditDurationHours";
			formFullBaseInfoViewModel.ItemRateVisibale = "visible";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "actpordDefinePreOrderStatus":
			formFullBaseInfoViewModel.TitlePage = Labels.WSPreOrderStatusTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineStatus";
			formFullBaseInfoViewModel.TypeAction = "actpordDefinePreOrderStatus";
			formFullBaseInfoViewModel.NameTabel = "WSPreOrderStatus";
			formFullBaseInfoViewModel.NameTabel_Lang = "WSspSelectPreOrderStatus";
			formFullBaseInfoViewModel.NameTabel_Delete = "WSspDeleteWSPreOrderStatus";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.NamefieldID = "PreOrderStatusId";
			formFullBaseInfoViewModel.NamefieldI = "PreOrderStatus";
			formFullBaseInfoViewModel.NamefieldII = "";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "PordPay1":
			formFullBaseInfoViewModel.TitlePage = Labels.WSOrderPaymentTypesTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfo";
			formFullBaseInfoViewModel.TypeAction = "PordPay1";
			formFullBaseInfoViewModel.NameTabel = "WSOrderPaymentTypes";
			formFullBaseInfoViewModel.NameTabel_Lang = "WSspSelectOrderPaymentTypes";
			formFullBaseInfoViewModel.NameTabel_Delete = "WSspDeleteWSOrderPaymentTypes";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.NamefieldID = "OrderPaymentTypeId";
			formFullBaseInfoViewModel.NamefieldI = "ordpayType";
			formFullBaseInfoViewModel.NamefieldII = "";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldIV = "OrderView";
			formFullBaseInfoViewModel.ItemOrderVisibale = "visible";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVIII = "DeActive";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "visible";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "BordPay1":
			formFullBaseInfoViewModel.TitlePage = Labels.WSBuyOrderPaymentTypesTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfo";
			formFullBaseInfoViewModel.TypeAction = "BordPay1";
			formFullBaseInfoViewModel.NameTabel = "WSBuyOrderPaymentTypes";
			formFullBaseInfoViewModel.NameTabel_Lang = "WSspSelectBuyOrderPaymentTypes";
			formFullBaseInfoViewModel.NameTabel_Delete = "WSspDeleteWSBuyOrderPaymentTypes";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.NamefieldID = "BuyOrderPaymentTypeId";
			formFullBaseInfoViewModel.NamefieldI = "bordpayType";
			formFullBaseInfoViewModel.NamefieldII = "";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "actDefineSettlementType":
			formFullBaseInfoViewModel.TitlePage = Labels.WSSettlementTypeTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfo";
			formFullBaseInfoViewModel.TypeAction = "actDefineSettlementType";
			formFullBaseInfoViewModel.NameTabel = "WSSettlementType";
			formFullBaseInfoViewModel.NameTabel_Lang = "WSspSettlementType";
			formFullBaseInfoViewModel.NameTabel_Delete = "WSspDeleteWSSettlementType";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.NamefieldID = "Id";
			formFullBaseInfoViewModel.NamefieldI = "Name";
			formFullBaseInfoViewModel.NamefieldII = "";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "actordDefineSettlementType":
			formFullBaseInfoViewModel.TitlePage = Labels.WSSettlementTypeTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfo";
			formFullBaseInfoViewModel.TypeAction = "actordDefineSettlementType";
			formFullBaseInfoViewModel.NameTabel = "WSSettlementType";
			formFullBaseInfoViewModel.NameTabel_Lang = "WSspSettlementType";
			formFullBaseInfoViewModel.NameTabel_Delete = "WSspDeleteWSSettlementType";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.NamefieldID = "Id";
			formFullBaseInfoViewModel.NamefieldI = "Name";
			formFullBaseInfoViewModel.NamefieldII = "";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "actDefinePrjGroupsMulti":
			formFullBaseInfoViewModel.TitlePage = Labels.frmProjectGroupsMultiTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfoI";
			formFullBaseInfoViewModel.TypeAction = "actDefinePrjGroupsMulti";
			formFullBaseInfoViewModel.NameTabel = "CrmProjectGroupsMulti";
			formFullBaseInfoViewModel.NameTabel_Lang = "CRMspSelectProjectGroupsMulti";
			formFullBaseInfoViewModel.NameTabel_Delete = "CRMspDeleteCrmProjectGroupsMulti";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.NamefieldID = "ProjectGroupsMultiId";
			formFullBaseInfoViewModel.NamefieldI = "ProjectGroupsMultiName";
			formFullBaseInfoViewModel.NamefieldII = "ProjectGroupsMultiDesc";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldIV = "SortCode";
			formFullBaseInfoViewModel.ItemOrderVisibale = "visible";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "actDefinePrjGroupsMultiI":
			formFullBaseInfoViewModel.TitlePage = Labels.frmProjectGroupsMultiITitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfoI";
			formFullBaseInfoViewModel.TypeAction = "actDefinePrjGroupsMultiI";
			formFullBaseInfoViewModel.NameTabel = "CrmProjectGroupsMultiI";
			formFullBaseInfoViewModel.NameTabel_Lang = "CRMspSelectProjectGroupsMultiI";
			formFullBaseInfoViewModel.NameTabel_Delete = "CRMspDeleteCrmProjectGroupsMultiI";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.NamefieldID = "ProjectGroupsMultiIId";
			formFullBaseInfoViewModel.NamefieldI = "ProjectGroupsMultiIName";
			formFullBaseInfoViewModel.NamefieldII = "ProjectGroupsMultiIDesc";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldIV = "SortCode";
			formFullBaseInfoViewModel.ItemOrderVisibale = "visible";
			formFullBaseInfoViewModel.NamefieldVI = "IsDefualtField";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "visible";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "actDefineReasonGroup":
			formFullBaseInfoViewModel.TitlePage = Labels.frmDefineReasonGroupTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfoI";
			formFullBaseInfoViewModel.TypeAction = "actDefineReasonGroup";
			formFullBaseInfoViewModel.NameTabel = "WSPreOrderPrdGroupMustExistReasonGroups";
			formFullBaseInfoViewModel.NameTabel_Lang = "WSspSelectPreOrderPrdGroupMustExistReasonGroups";
			formFullBaseInfoViewModel.NameTabel_Delete = "WSspDeleteWSPreOrderPrdGroupMustExistReasonGroups";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.NamefieldID = "PrdGroupMustExistReasonGroupId";
			formFullBaseInfoViewModel.NamefieldI = "PrdGroupMustExistReasonGroupTitle";
			formFullBaseInfoViewModel.NamefieldII = "";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "NeedReasonTxt";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "visible";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "PayRollPay1":
			formFullBaseInfoViewModel.TitlePage = Labels.PayRollUserPaymentTypesTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfo";
			formFullBaseInfoViewModel.TypeAction = "PayRollPay1";
			formFullBaseInfoViewModel.NameTabel = "PayRollUserPaymentTypes";
			formFullBaseInfoViewModel.NameTabel_Lang = "PayRollspSelectUserPaymentTypes";
			formFullBaseInfoViewModel.NameTabel_Delete = "PayRollspDeleteUserPaymentType";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.NamefieldID = "PayRollUserPaymentTypeId";
			formFullBaseInfoViewModel.NamefieldI = "PaymentType";
			formFullBaseInfoViewModel.NamefieldII = "";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "actDefinePayType":
			formFullBaseInfoViewModel.TitlePage = Labels.WSOrderCommissionPayTypesTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfo";
			formFullBaseInfoViewModel.TypeAction = "actDefinePayType";
			formFullBaseInfoViewModel.NameTabel = "WSOrderCommissionPayTypes";
			formFullBaseInfoViewModel.NameTabel_Lang = "WSspSelectOrderCommissionPayTypes";
			formFullBaseInfoViewModel.NameTabel_Delete = "WSspDeleteOrderCommissionPayType";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.NamefieldID = "OrderCommissionPayTypeId";
			formFullBaseInfoViewModel.NamefieldI = "CommPayTypeTitle";
			formFullBaseInfoViewModel.NamefieldII = "";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "actDefineDyFieldGroup":
			formFullBaseInfoViewModel.TitlePage = Labels.WSCostSheetDyFieldGroupsTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfo";
			formFullBaseInfoViewModel.TypeAction = "actDefineDyFieldGroup";
			formFullBaseInfoViewModel.NameTabel = "WSCostSheetDyFieldGroups";
			formFullBaseInfoViewModel.NameTabel_Lang = "WSspSelectCostSheetDyFieldGroups";
			formFullBaseInfoViewModel.NameTabel_Delete = "WSspDeleteCostSheetDyFieldGroups";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.NamefieldID = "CostSheetDyFieldGroupId";
			formFullBaseInfoViewModel.NamefieldI = "ctshDyFieldGroupName";
			formFullBaseInfoViewModel.NamefieldII = "";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "actDefineUserGroups":
			formFullBaseInfoViewModel.TitlePage = Labels.UserGroupsTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfo";
			formFullBaseInfoViewModel.TypeAction = "actDefineUserGroups";
			formFullBaseInfoViewModel.NameTabel = "UserGroups";
			formFullBaseInfoViewModel.NameTabel_Lang = "CRMspSelectUserGroups";
			formFullBaseInfoViewModel.NameTabel_Delete = "CRMspDeleteUserGroups";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.NamefieldID = "UserGroupId";
			formFullBaseInfoViewModel.NamefieldI = "GroupName";
			formFullBaseInfoViewModel.NamefieldII = "";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "actDefineDeliveryTerm":
			formFullBaseInfoViewModel.TitlePage = Labels.WSDeliveryTermsTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfo";
			formFullBaseInfoViewModel.TypeAction = "actDefineDeliveryTerm";
			formFullBaseInfoViewModel.NameTabel = "WSDeliveryTerms";
			formFullBaseInfoViewModel.NameTabel_Lang = "WSspSelectDeliveryTerms";
			formFullBaseInfoViewModel.NameTabel_Delete = "WSspDeleteDeliveryTerm";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.NamefieldID = "DeliveryTermId";
			formFullBaseInfoViewModel.NamefieldI = "DeliveryTerm";
			formFullBaseInfoViewModel.NamefieldII = "";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "visible";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "SHPVisible";
			formFullBaseInfoViewModel.SHPDefaultVisible = "visible";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "SHPDefault";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "visible";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "SHPNeedAddress";
			break;
		case "actpordDefinePreOrderType":
			formFullBaseInfoViewModel.TitlePage = Labels.WSPreOrderTypesTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfo";
			formFullBaseInfoViewModel.TypeAction = "actpordDefinePreOrderType";
			formFullBaseInfoViewModel.NameTabel = "WSPreOrderTypes";
			formFullBaseInfoViewModel.NameTabel_Lang = "WSspSelectPreOrderTypes";
			formFullBaseInfoViewModel.NameTabel_Delete = "WSspDeletePreOrderType";
			formFullBaseInfoViewModel.Parametes = $"{lCID}, {result}, {num}";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.NamefieldID = "PreOrderTypeId";
			formFullBaseInfoViewModel.NamefieldI = "PreOrderType";
			formFullBaseInfoViewModel.NamefieldII = "";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "actDefineSaleCenter":
			formFullBaseInfoViewModel.TitlePage = Labels.WSSaleCentersTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfo";
			formFullBaseInfoViewModel.TypeAction = "actDefineSaleCenter";
			formFullBaseInfoViewModel.NameTabel = "WSSaleCenters";
			formFullBaseInfoViewModel.NameTabel_Lang = "WSspSelectSaleCenters";
			formFullBaseInfoViewModel.NameTabel_Delete = "WSspDeleteSaleCenter";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.NamefieldID = "SaleCenterId";
			formFullBaseInfoViewModel.NamefieldI = "SaleCenterName";
			formFullBaseInfoViewModel.NamefieldII = "";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "actDefineSaleArea":
			formFullBaseInfoViewModel.TitlePage = Labels.WSSaleAreasTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfo";
			formFullBaseInfoViewModel.TypeAction = "actDefineSaleArea";
			formFullBaseInfoViewModel.NameTabel = "WSSaleAreas";
			formFullBaseInfoViewModel.NameTabel_Lang = "WSspSelectSaleAreas";
			formFullBaseInfoViewModel.NameTabel_Delete = "WSspDeleteSaleArea";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.NamefieldID = "SaleAreaId";
			formFullBaseInfoViewModel.NamefieldI = "SaleAreaName";
			formFullBaseInfoViewModel.NamefieldII = "";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "acthrDefineLeaveKind":
			formFullBaseInfoViewModel.TitlePage = Labels.frmLeaveKindTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfo";
			formFullBaseInfoViewModel.TypeAction = "acthrDefineLeaveKind";
			formFullBaseInfoViewModel.NameTabel = "CrmLeaveKinds";
			formFullBaseInfoViewModel.NameTabel_Lang = "CRMspSelectLeaveKinds";
			formFullBaseInfoViewModel.NameTabel_Delete = "CRMspDeleteLeaveKind";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.NamefieldID = "LeaveKindID";
			formFullBaseInfoViewModel.NamefieldI = "LeaveKind";
			formFullBaseInfoViewModel.NamefieldII = "";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "acthrDefineLeaveStayType":
			formFullBaseInfoViewModel.TitlePage = Labels.frmLeaveStayTypeTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfo";
			formFullBaseInfoViewModel.TypeAction = "acthrDefineLeaveStayType";
			formFullBaseInfoViewModel.NameTabel = "CrmLeaveStayType";
			formFullBaseInfoViewModel.NameTabel_Lang = "CRMspSelectLeaveStayType";
			formFullBaseInfoViewModel.NameTabel_Delete = "CRMspDeleteLeaveStayType";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.NamefieldID = "LeaveStayTypeID";
			formFullBaseInfoViewModel.NamefieldI = "LeaveStayType";
			formFullBaseInfoViewModel.NamefieldII = "";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "acthrDefineLeaveVehicleType":
			formFullBaseInfoViewModel.TitlePage = Labels.frmLeaveVehicleTypeTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfo";
			formFullBaseInfoViewModel.TypeAction = "acthrDefineLeaveVehicleType";
			formFullBaseInfoViewModel.NameTabel = "CrmLeaveVehicleType";
			formFullBaseInfoViewModel.NameTabel_Lang = "CRMspSelectLeaveVehicleType";
			formFullBaseInfoViewModel.NameTabel_Delete = "CRMspDeleteLeaveVehicleType";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.NamefieldID = "LeavdVehicleTypeID";
			formFullBaseInfoViewModel.NamefieldI = "LeaveVehicleType";
			formFullBaseInfoViewModel.NamefieldII = "";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "actPayRollDefineListGroup":
			formFullBaseInfoViewModel.TitlePage = Labels.PayRollListGroupsTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfo";
			formFullBaseInfoViewModel.TypeAction = "actPayRollDefineListGroup";
			formFullBaseInfoViewModel.NameTabel = "PayRollListGroups";
			formFullBaseInfoViewModel.NameTabel_Lang = "PayRollspSelectListGroups";
			formFullBaseInfoViewModel.NameTabel_Delete = "PayRollspDeleteListGroup";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.NamefieldID = "PayRollListGroupId";
			formFullBaseInfoViewModel.NamefieldI = "ListGroupName";
			formFullBaseInfoViewModel.NamefieldII = "";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldIV = "OrderView";
			formFullBaseInfoViewModel.ItemOrderVisibale = "visible";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVIII = "";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "BankAccType":
			formFullBaseInfoViewModel.TitlePage = Labels.BankingAccountTypeTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfo";
			formFullBaseInfoViewModel.TypeAction = "BankAccType";
			formFullBaseInfoViewModel.NameTabel = "CrmBankingAccountType";
			formFullBaseInfoViewModel.NameTabel_Lang = "CRMspSelectBankingAccountType";
			formFullBaseInfoViewModel.NameTabel_Delete = "CRMspDeleteBankingAccountType";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.NamefieldID = "BankingAccountTypeID";
			formFullBaseInfoViewModel.NamefieldI = "AccountType";
			formFullBaseInfoViewModel.NamefieldII = "";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "actordDefineOrderGroup":
			formFullBaseInfoViewModel.TitlePage = Labels.frmOrderGroupTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfo";
			formFullBaseInfoViewModel.TypeAction = "actordDefineOrderGroup";
			formFullBaseInfoViewModel.NameTabel = "WSOrderGroups";
			formFullBaseInfoViewModel.NameTabel_Lang = "WSspSelectOrderGroups";
			formFullBaseInfoViewModel.NameTabel_Delete = "WSspDeleteOrderGroup";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.NamefieldID = "OrderGroupId";
			formFullBaseInfoViewModel.NamefieldI = "OrderGroupName";
			formFullBaseInfoViewModel.NamefieldII = "";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.NamefieldCode = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "actDefineCash":
			formFullBaseInfoViewModel.TitlePage = Labels.frmCashTitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfo";
			formFullBaseInfoViewModel.TypeAction = "actDefineCash";
			formFullBaseInfoViewModel.NameTabel = "CrmCashes";
			formFullBaseInfoViewModel.NameTabel_Lang = "CRMspSelectCashes";
			formFullBaseInfoViewModel.NameTabel_Delete = "CRMspDeleteCashes";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.NamefieldID = "CashId";
			formFullBaseInfoViewModel.NamefieldI = "CashTitle";
			formFullBaseInfoViewModel.NamefieldII = "";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.NamefieldCode = "CashCode";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "visible";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "actDefinePayGroupI":
		case "actordDefinePayGroupI":
		case "actpordDefinePayGroupI":
			formFullBaseInfoViewModel.TitlePage = Labels.frmOrderPaymentGroupITitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfo";
			formFullBaseInfoViewModel.TypeAction = "actDefinePayGroupI";
			formFullBaseInfoViewModel.NameTabel = "WSOrderPaymentGroupsI";
			formFullBaseInfoViewModel.NameTabel_Lang = "WSspSelectOrderPaymentGroupsI";
			formFullBaseInfoViewModel.NameTabel_Delete = "WSspDeleteOrderPaymentGroupsI";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.NamefieldID = "OrderPaymentGroupIId";
			formFullBaseInfoViewModel.NamefieldI = "ordpayGroupIName";
			formFullBaseInfoViewModel.NamefieldII = "";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.NamefieldCode = "ordpayGroupICode";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "visible";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		case "actDefinePayGroupII":
		case "actpordDefinePayGroupII":
		case "actordDefinePayGroupII":
			formFullBaseInfoViewModel.TitlePage = Labels.frmOrderPaymentGroupIITitlePage;
			formFullBaseInfoViewModel.TypeAccess = "frmDefineBaseInfo";
			formFullBaseInfoViewModel.TypeAction = "actDefinePayGroupII";
			formFullBaseInfoViewModel.NameTabel = "WSOrderPaymentGroupsII";
			formFullBaseInfoViewModel.NameTabel_Lang = "WSspSelectOrderPaymentGroupsII";
			formFullBaseInfoViewModel.NameTabel_Delete = "WSspDeleteOrderPaymentGroupsII";
			formFullBaseInfoViewModel.isLanguage = true;
			formFullBaseInfoViewModel.NamefieldID = "OrderPaymentGroupIIId";
			formFullBaseInfoViewModel.NamefieldI = "ordpayGroupIIName";
			formFullBaseInfoViewModel.NamefieldII = "";
			formFullBaseInfoViewModel.NamefieldIII = "";
			formFullBaseInfoViewModel.NamefieldCode = "ordpayGroupIICode";
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "visible";
			formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldIV = "";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.NamefieldVI = "";
			formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
			formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
			formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
			formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldIX = "";
			formFullBaseInfoViewModel.NamefieldX = "";
			formFullBaseInfoViewModel.NamefieldScoreRate = "";
			formFullBaseInfoViewModel.ItemScoreRateVisibale = "hidden";
			formFullBaseInfoViewModel.FODefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldFODefault = "";
			formFullBaseInfoViewModel.SHPVisible_Visible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPVisible = "";
			formFullBaseInfoViewModel.SHPDefaultVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPDefault = "";
			formFullBaseInfoViewModel.ItemCodeVisibale = "visible";
			formFullBaseInfoViewModel.SHPNeedAddressVisible = "hidden";
			formFullBaseInfoViewModel.NamefieldSHPNeedAddress = "";
			break;
		default:
			formFullBaseInfoViewModel = null;
			break;
		}
		return formFullBaseInfoViewModel;
	}

	[LoginAuthorize]
	public ActionResult FormBaseInsert(string FormName, string TypeAction)
	{
		if (!UserLogin.IsUserAccess(FormName, "actInsert", UserLogin.CurrentUser))
		{
			return RedirectToAction("Login", "Account", (object)new
			{
				area = "",
				d = DateTime.Now
			});
		}
		FormFullBaseInfoViewModel formFullBaseInfoViewModel = FullForm(TypeAction);
		if (formFullBaseInfoViewModel != null && (formFullBaseInfoViewModel.NameTabel ?? "") == "WSPreOrderTypes")
		{
			formFullBaseInfoViewModel.ItemUserAccessAll = true;
		}
		return View(formFullBaseInfoViewModel);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	[LoginAuthorize]
	public ActionResult FormBaseInsert(FormFullBaseInfoViewModel formbase)
	{
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int num = 0;
		if (formbase.TypeAction == "actDefineCountry")
		{
			if (!UserLogin.IsUserAccess(formbase.TypeAccess, "actPost", UserLogin.CurrentUser))
			{
				return RedirectToAction("Login", "Account", (object)new
				{
					area = "",
					d = DateTime.Now
				});
			}
		}
		else if (!UserLogin.IsUserAccess("frmDefineBaseInfoIDataEntry", "actPost", UserLogin.CurrentUser))
		{
			base.ViewBag.Error = Messages.NotAccessToPage;
			return View(formbase);
		}
		try
		{
			if (base.ModelState.IsValid)
			{
				List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(formbase.ItemTitle_Lang))
				{
					list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(formbase.ItemTitle_Lang);
				}
				list.Add(new CommonMultiLanguageViewModel
				{
					Value = formbase.ItemTitle,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(formbase.ItemDesc_Lang))
				{
					list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(formbase.ItemDesc_Lang);
				}
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = formbase.ItemDesc,
					LanguageId = lCID
				});
				if (formbase.ItemTitle == null)
				{
					text = text + Messages.CheckEmptyFormBaseTitle + "|";
					num++;
				}
				else if (!checkMultiLanguage(formbase.ItemTitle, list))
				{
					text = text + Messages.CheckFormBaseTitleLang + "<br>";
					num++;
				}
				if (formbase.NameTabel == "WSDeliveryTerms" && formbase.SHPDefault.GetValueOrDefault())
				{
					WSspSelectDeliveryTermSHPDefault_Result wSspSelectDeliveryTermSHPDefault_Result = Enumerable.FirstOrDefault<WSspSelectDeliveryTermSHPDefault_Result>((IEnumerable<WSspSelectDeliveryTermSHPDefault_Result>)_dbI.WSspSelectDeliveryTermSHPDefault(lCID, defLangID));
					if (wSspSelectDeliveryTermSHPDefault_Result != null)
					{
						text = text + string.Format(Messages.msgErrorNoRegisterItemAlreadySelected, wSspSelectDeliveryTermSHPDefault_Result.DeliveryTerm ?? "", Labels.FullbaseInfoSHPDefault) + "<br>";
						num++;
					}
				}
				if (num == 0)
				{
					formbase.UserId = UserLogin.CurrentUser.UserId;
					DateTime dateTime = (formbase.RegisterDate = DateTime.Now);
					formbase.RegisterDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
					formbase.Month1 = short.Parse(dateTime.ToString("MM", new PersianCulture()));
					formbase.Year1 = short.Parse(Financial.Get().Id.ToString());
					formbase.ItemTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
					formbase.ItemDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
					int result = 0;
					string text2 = "";
					if (formbase.ItemDescVisibale == "hidden" && formbase.ItemOrderVisibale == "hidden" && formbase.ItemRateVisibale == "hidden" && formbase.ItemDeActiveVisibale == "hidden" && formbase.SHPDefaultVisible == "visible" && formbase.SHPVisible_Visible == "visible" && formbase.SHPNeedAddressVisible == "visible")
					{
						if (formbase.NameTabel == "WSDeliveryTerms")
						{
							int num2 = ((Financial.Get() != null) ? Financial.Get().Id : 0);
							text2 = "INSERT INTO " + formbase.NameTabel + "([" + formbase.NamefieldI + "],[" + formbase.NamefieldSHPDefault + "],[" + formbase.NamefieldSHPVisible + "],[" + formbase.NamefieldSHPNeedAddress + "],[UserId],[Month1],[RegisterDate],[RegisterDatePersian],[FPId],[AppType],[GUId],[FirstRegisterUserId],[FirstRegisterDate],[FirstRegisterDatePersian],[LanguageID])VALUES ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14})  SELECT SCOPE_IDENTITY()";
							int.TryParse(Enumerable.FirstOrDefault<decimal>(db.Database.SqlQuery<decimal>(text2, new object[15]
							{
								formbase.ItemTitle,
								formbase.SHPDefault.GetValueOrDefault(),
								formbase.SHPVisible.GetValueOrDefault(),
								formbase.SHPNeedAddress.GetValueOrDefault(),
								formbase.UserId,
								formbase.Month1,
								formbase.RegisterDate,
								formbase.RegisterDatePersian,
								num2,
								Configuration.AppType,
								Guid.NewGuid(),
								formbase.UserId,
								formbase.RegisterDate,
								formbase.RegisterDatePersian,
								defLangID
							})).ToString(), out result);
						}
					}
					else if (formbase.ItemDescVisibale == "hidden" && formbase.ItemOrderVisibale == "hidden" && formbase.ItemRateVisibale == "hidden" && formbase.ItemDeActiveVisibale == "hidden" && formbase.SHPDefaultVisible == "hidden" && formbase.SHPVisible_Visible == "hidden" && formbase.ItemCodeVisibale == "visible" && formbase.SHPNeedAddressVisible == "hidden")
					{
						switch (formbase.NameTabel)
						{
						case "WSOrderPaymentGroupsI":
						case "WSOrderPaymentGroupsII":
						{
							int num3 = ((Financial.Get() != null) ? Financial.Get().Id : 0);
							text2 = "INSERT INTO " + formbase.NameTabel + "([" + formbase.NamefieldI + "],[" + formbase.NamefieldCode + "],[UserId],[Month1],[RegisterDate],[RegisterDatePersian],[FPId],[AppType],[GUId],[FirstRegisterUserId],[FirstRegisterDate],[FirstRegisterDatePersian],[LanguageID])VALUES ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12})  SELECT SCOPE_IDENTITY()";
							int.TryParse(Enumerable.FirstOrDefault<decimal>(db.Database.SqlQuery<decimal>(text2, new object[13]
							{
								formbase.ItemTitle,
								formbase.ItemCode,
								formbase.UserId,
								formbase.Month1,
								formbase.RegisterDate,
								formbase.RegisterDatePersian,
								num3,
								Configuration.AppType,
								Guid.NewGuid(),
								formbase.UserId,
								formbase.RegisterDate,
								formbase.RegisterDatePersian,
								defLangID
							})).ToString(), out result);
							break;
						}
						case "CrmCashes":
							text2 = "INSERT INTO " + formbase.NameTabel + "([" + formbase.NamefieldI + "],[" + formbase.NamefieldCode + "],[UserId],[Year1],[Month1],[RegisterDate],[RegisterDatePersian],[AppType],[GUId],[FirstRegisterUserId],[FirstRegisterDatePersian],[FirstRegisterDate],[LanguageID]) VALUES ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}) SELECT SCOPE_IDENTITY() SELECT SCOPE_IDENTITY()";
							int.TryParse(Enumerable.FirstOrDefault<decimal>(db.Database.SqlQuery<decimal>(text2, new object[13]
							{
								formbase.ItemTitle,
								formbase.ItemCode,
								formbase.UserId,
								formbase.Year1,
								formbase.Month1,
								formbase.RegisterDate,
								formbase.RegisterDatePersian,
								Configuration.AppType,
								Guid.NewGuid(),
								formbase.UserId,
								formbase.RegisterDatePersian,
								formbase.RegisterDate,
								defLangID
							})).ToString(), out result);
							break;
						}
					}
					else if (formbase.ItemDescVisibale == "hidden" && formbase.ItemOrderVisibale == "hidden" && formbase.ItemRateVisibale == "hidden" && formbase.ItemDeActiveVisibale == "hidden")
					{
						switch (formbase.NameTabel)
						{
						case "CrmKnowledgeTankPriority":
						case "CrmKnowledgeTankGroup":
							text2 = "INSERT INTO " + formbase.NameTabel + "([" + formbase.NamefieldI + "],[UserId],[Year1],[Month1],[RegisterDate],[RegisterDatePersian],[FirstRegisterUserId],[FirstRegisterDate],[FirstRegisterDatePersian],[AppType],[GUId],[LanguageID])VALUES ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}) SELECT SCOPE_IDENTITY()";
							int.TryParse(Enumerable.FirstOrDefault<decimal>(db.Database.SqlQuery<decimal>(text2, new object[12]
							{
								formbase.ItemTitle,
								formbase.UserId,
								formbase.Year1,
								formbase.Month1,
								formbase.RegisterDate,
								formbase.RegisterDatePersian,
								formbase.UserId,
								formbase.RegisterDate,
								formbase.RegisterDatePersian,
								Configuration.AppType,
								Guid.NewGuid(),
								defLangID
							})).ToString(), out result);
							break;
						case "WSCostSheetDyFieldGroups":
						case "WSPreOrderOpr":
						case "WSOrderGroups":
						case "WSSaleCenters":
						case "WSDeliveryTime":
						case "WSPayCondition":
						case "actordDefineSettlementType":
						case "WSGuaranty":
						case "WSPreOrderStatus":
						case "actDefineSettlementType":
						case "WSBuyOrderPaymentTypes":
						case "WSPreOrderTypes":
						case "WSSaleAreas":
						{
							int num4 = ((Financial.Get() != null) ? Financial.Get().Id : 0);
							text2 = "INSERT INTO " + formbase.NameTabel + "([" + formbase.NamefieldI + "],[UserId],[Month1],[RegisterDate],[RegisterDatePersian],[FPId],[AppType],[GUId],[FirstRegisterUserId],[FirstRegisterDate],[FirstRegisterDatePersian],[LanguageID])VALUES ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11})  SELECT SCOPE_IDENTITY()";
							int.TryParse(Enumerable.FirstOrDefault<decimal>(db.Database.SqlQuery<decimal>(text2, new object[12]
							{
								formbase.ItemTitle,
								formbase.UserId,
								formbase.Month1,
								formbase.RegisterDate,
								formbase.RegisterDatePersian,
								num4,
								Configuration.AppType,
								Guid.NewGuid(),
								formbase.UserId,
								formbase.RegisterDate,
								formbase.RegisterDatePersian,
								defLangID
							})).ToString(), out result);
							break;
						}
						case "CrmInternalMessagePriority":
							text2 = "INSERT INTO " + formbase.NameTabel + "([" + formbase.NamefieldI + "],[UserId],[Year1],[Month1],[RegisterDate],[RegisterDatePersian],[AppType],[GUId],[FirstRegisterUserId],[FirstRegisterDatePersian],[FirstRegisterDate],[LanguageID])VALUES ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}) SELECT SCOPE_IDENTITY()";
							int.TryParse(Enumerable.FirstOrDefault<decimal>(db.Database.SqlQuery<decimal>(text2, new object[12]
							{
								formbase.ItemTitle,
								formbase.UserId,
								formbase.Year1,
								formbase.Month1,
								formbase.RegisterDate,
								formbase.RegisterDatePersian,
								Configuration.AppType,
								Guid.NewGuid(),
								formbase.UserId,
								formbase.RegisterDatePersian,
								formbase.RegisterDate,
								defLangID
							})).ToString(), out result);
							break;
						case "WSPreOrderPrdGroupMustExistReasonGroups":
							text2 = "INSERT INTO " + formbase.NameTabel + "([" + formbase.NamefieldI + "],[" + formbase.NamefieldVI + "],[UserId],[FPId],[Month1],[RegisterDate],[RegisterDatePersian],[AppType],[GUId],[FirstRegisterUserId],[FirstRegisterDatePersian],[FirstRegisterDate],[LanguageID])VALUES ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}) SELECT SCOPE_IDENTITY()";
							int.TryParse(Enumerable.FirstOrDefault<decimal>(db.Database.SqlQuery<decimal>(text2, new object[13]
							{
								formbase.ItemTitle,
								formbase.ItemDefault,
								formbase.UserId,
								formbase.Year1,
								formbase.Month1,
								formbase.RegisterDate,
								formbase.RegisterDatePersian,
								Configuration.AppType,
								Guid.NewGuid(),
								formbase.UserId,
								formbase.RegisterDatePersian,
								formbase.RegisterDate,
								defLangID
							})).ToString(), out result);
							break;
						default:
							text2 = "INSERT INTO " + formbase.NameTabel + "([" + formbase.NamefieldI + "],[UserId],[Year1],[Month1],[RegisterDate],[RegisterDatePersian],[AppType],[GUId],[FirstRegisterUserId],[FirstRegisterDatePersian],[FirstRegisterDate],[LanguageID])VALUES ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}) SELECT SCOPE_IDENTITY()";
							int.TryParse(Enumerable.FirstOrDefault<decimal>(db.Database.SqlQuery<decimal>(text2, new object[12]
							{
								formbase.ItemTitle,
								formbase.UserId,
								formbase.Year1,
								formbase.Month1,
								formbase.RegisterDate,
								formbase.RegisterDatePersian,
								Configuration.AppType,
								Guid.NewGuid(),
								formbase.UserId,
								formbase.RegisterDatePersian,
								formbase.RegisterDate,
								defLangID
							})).ToString(), out result);
							break;
						}
					}
					else if (formbase.ItemDescVisibale == "hidden" && formbase.ItemOrderVisibale == "visible" && formbase.ItemDeActiveVisibale == "hidden")
					{
						switch (formbase.NameTabel)
						{
						case "CrmInternalMessageGroup":
						case "CrmProjectGroupsMulti":
						case "PayRollListGroups":
							text2 = "INSERT INTO " + formbase.NameTabel + "([" + formbase.NamefieldI + "],[" + formbase.NamefieldIV + "],[UserId],[Year1],[Month1],[RegisterDate],[RegisterDatePersian],[AppType],[GUId],[FirstRegisterUserId],[FirstRegisterDatePersian],[FirstRegisterDate],[LanguageID])VALUES ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}) SELECT SCOPE_IDENTITY()";
							int.TryParse(Enumerable.FirstOrDefault<decimal>(db.Database.SqlQuery<decimal>(text2, new object[13]
							{
								formbase.ItemTitle,
								formbase.ItemOrder,
								formbase.UserId,
								formbase.Year1,
								formbase.Month1,
								formbase.RegisterDate,
								formbase.RegisterDatePersian,
								Configuration.AppType,
								Guid.NewGuid(),
								formbase.UserId,
								formbase.RegisterDatePersian,
								formbase.RegisterDate,
								defLangID
							})).ToString(), out result);
							break;
						case "CrmProjectGroupsMultiI":
							text2 = "INSERT INTO " + formbase.NameTabel + "([" + formbase.NamefieldI + "],[" + formbase.NamefieldIV + "],[" + formbase.NamefieldVI + "],[UserId],[Year1],[Month1],[RegisterDate],[RegisterDatePersian],[AppType],[GUId],[FirstRegisterUserId],[FirstRegisterDatePersian],[FirstRegisterDate],[LanguageID])VALUES ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13}) SELECT SCOPE_IDENTITY()";
							int.TryParse(Enumerable.FirstOrDefault<decimal>(db.Database.SqlQuery<decimal>(text2, new object[14]
							{
								formbase.ItemTitle,
								formbase.ItemOrder,
								formbase.ItemDefault,
								formbase.UserId,
								formbase.Year1,
								formbase.Month1,
								formbase.RegisterDate,
								formbase.RegisterDatePersian,
								Configuration.AppType,
								Guid.NewGuid(),
								formbase.UserId,
								formbase.RegisterDatePersian,
								formbase.RegisterDate,
								defLangID
							})).ToString(), out result);
							break;
						}
					}
					else if (formbase.ItemOrderVisibale == "visible" && formbase.ItemDeActiveVisibale == "visible" && formbase.ItemRateVisibale == "hidden")
					{
						if (formbase.NameTabel == "WSOrderPaymentTypes")
						{
							int num5 = ((Financial.Get() != null) ? Financial.Get().Id : 0);
							text2 = "INSERT INTO " + formbase.NameTabel + "([" + formbase.NamefieldI + "],[UserId],[Month1],[RegisterDate],[RegisterDatePersian],[FPId],[AppType],[GUId],[FirstRegisterUserId],[FirstRegisterDate],[FirstRegisterDatePersian],[LanguageID],[" + formbase.NamefieldIV + "],[" + formbase.NamefieldVIII + "])VALUES ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13})  SELECT SCOPE_IDENTITY()";
							int.TryParse(Enumerable.FirstOrDefault<decimal>(db.Database.SqlQuery<decimal>(text2, new object[14]
							{
								formbase.ItemTitle,
								formbase.UserId,
								formbase.Month1,
								formbase.RegisterDate,
								formbase.RegisterDatePersian,
								num5,
								Configuration.AppType,
								Guid.NewGuid(),
								formbase.UserId,
								formbase.RegisterDate,
								formbase.RegisterDatePersian,
								defLangID,
								formbase.ItemOrder,
								formbase.ItemDeActive
							})).ToString(), out result);
						}
						else
						{
							text2 = "INSERT INTO " + formbase.NameTabel + "([" + formbase.NamefieldI + "],[" + formbase.NamefieldII + "],[" + formbase.NamefieldVII + "],[UserId],[Year1],[Month1],[RegisterDate],[RegisterDatePersian],[AppType],[GUId],[FirstRegisterUserId],[FirstRegisterDatePersian],[FirstRegisterDate],[LanguageID]) VALUES ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13}) SELECT SCOPE_IDENTITY() SELECT SCOPE_IDENTITY()";
							int.TryParse(Enumerable.FirstOrDefault<decimal>(db.Database.SqlQuery<decimal>(text2, new object[14]
							{
								formbase.ItemTitle,
								formbase.ItemDesc,
								formbase.ItemRate,
								formbase.UserId,
								formbase.Year1,
								formbase.Month1,
								formbase.RegisterDate,
								formbase.RegisterDatePersian,
								Configuration.AppType,
								Guid.NewGuid(),
								formbase.UserId,
								formbase.RegisterDatePersian,
								formbase.RegisterDate,
								defLangID
							})).ToString(), out result);
						}
					}
					else if (formbase.CheckUserDistanceCmpVisible == "visible" && formbase.UserDistanceCmpValVisible == "visible")
					{
						if (formbase.NameTabel == "CrmConversationTopics")
						{
							text2 = "INSERT INTO " + formbase.NameTabel + "([" + formbase.NamefieldI + "],[" + formbase.NamefieldII + "],[" + formbase.NamefieldIX + "],[" + formbase.NamefieldX + "],[UserId],[Year1],[Month1],[RegisterDate],[RegisterDatePersian],[AppType],[GUId],[FirstRegisterUserId],[FirstRegisterDatePersian],[FirstRegisterDate],[LanguageID]) VALUES ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14}) SELECT SCOPE_IDENTITY() SELECT SCOPE_IDENTITY()";
							int.TryParse(Enumerable.FirstOrDefault<decimal>(db.Database.SqlQuery<decimal>(text2, new object[15]
							{
								formbase.ItemTitle,
								formbase.ItemDesc,
								(!formbase.CheckUserDistanceCmp.GetValueOrDefault()) ? null : formbase.CheckUserDistanceCmp,
								formbase.UserDistanceCmpVal,
								formbase.UserId,
								formbase.Year1,
								formbase.Month1,
								formbase.RegisterDate,
								formbase.RegisterDatePersian,
								Configuration.AppType,
								Guid.NewGuid(),
								formbase.UserId,
								formbase.RegisterDatePersian,
								formbase.RegisterDate,
								defLangID
							})).ToString(), out result);
						}
						else
						{
							text2 = "INSERT INTO " + formbase.NameTabel + "([" + formbase.NamefieldI + "],[" + formbase.NamefieldII + "],[" + formbase.NamefieldVII + "],[UserId],[Year1],[Month1],[RegisterDate],[RegisterDatePersian],[AppType],[GUId],[FirstRegisterUserId],[FirstRegisterDatePersian],[FirstRegisterDate],[LanguageID]) VALUES ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13}) SELECT SCOPE_IDENTITY() SELECT SCOPE_IDENTITY()";
							int.TryParse(Enumerable.FirstOrDefault<decimal>(db.Database.SqlQuery<decimal>(text2, new object[14]
							{
								formbase.ItemTitle,
								formbase.ItemDesc,
								formbase.ItemRate,
								formbase.UserId,
								formbase.Year1,
								formbase.Month1,
								formbase.RegisterDate,
								formbase.RegisterDatePersian,
								Configuration.AppType,
								Guid.NewGuid(),
								formbase.UserId,
								formbase.RegisterDatePersian,
								formbase.RegisterDate,
								defLangID
							})).ToString(), out result);
						}
					}
					else if (formbase.ItemScoreRateVisibale == "visible")
					{
						if (formbase.NameTabel == "CrmCompanyGroupsII")
						{
							text2 = "INSERT INTO " + formbase.NameTabel + "([" + formbase.NamefieldI + "],[" + formbase.NamefieldII + "],[" + formbase.NamefieldVII + "],[" + formbase.NamefieldScoreRate + "],[UserId],[Year1],[Month1],[RegisterDate],[RegisterDatePersian],[AppType],[GUId],[FirstRegisterUserId],[FirstRegisterDatePersian],[FirstRegisterDate],[LanguageID]) VALUES ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14}) SELECT SCOPE_IDENTITY() SELECT SCOPE_IDENTITY()";
							int.TryParse(Enumerable.FirstOrDefault<decimal>(db.Database.SqlQuery<decimal>(text2, new object[15]
							{
								formbase.ItemTitle,
								formbase.ItemDesc,
								formbase.ItemRate,
								formbase.ItemScoreRate,
								formbase.UserId,
								formbase.Year1,
								formbase.Month1,
								formbase.RegisterDate,
								formbase.RegisterDatePersian,
								Configuration.AppType,
								Guid.NewGuid(),
								formbase.UserId,
								formbase.RegisterDatePersian,
								formbase.RegisterDate,
								defLangID
							})).ToString(), out result);
						}
						else
						{
							text2 = "INSERT INTO " + formbase.NameTabel + "([" + formbase.NamefieldI + "],[" + formbase.NamefieldII + "],[" + formbase.NamefieldScoreRate + "],[UserId],[Year1],[Month1],[RegisterDate],[RegisterDatePersian],[AppType],[GUId],[FirstRegisterUserId],[FirstRegisterDatePersian],[FirstRegisterDate],[LanguageID]) VALUES ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13}) SELECT SCOPE_IDENTITY() SELECT SCOPE_IDENTITY()";
							int.TryParse(Enumerable.FirstOrDefault<decimal>(db.Database.SqlQuery<decimal>(text2, new object[14]
							{
								formbase.ItemTitle,
								formbase.ItemDesc,
								formbase.ItemScoreRate,
								formbase.UserId,
								formbase.Year1,
								formbase.Month1,
								formbase.RegisterDate,
								formbase.RegisterDatePersian,
								Configuration.AppType,
								Guid.NewGuid(),
								formbase.UserId,
								formbase.RegisterDatePersian,
								formbase.RegisterDate,
								defLangID
							})).ToString(), out result);
						}
					}
					else if (formbase.ItemRateVisibale == "visible")
					{
						string nameTabel = formbase.NameTabel;
						if (!(nameTabel == "CrmCompanyGroupsII"))
						{
							if (nameTabel == "WSCreditDuration")
							{
								int num6 = ((Financial.Get() != null) ? Financial.Get().Id : 0);
								text2 = "INSERT INTO " + formbase.NameTabel + "([" + formbase.NamefieldI + "],[" + formbase.NamefieldVII + "],[UserId],[Month1],[RegisterDate],[RegisterDatePersian],[FPId],[AppType],[GUId],[FirstRegisterUserId],[FirstRegisterDate],[FirstRegisterDatePersian],[LanguageID])VALUES ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12})  SELECT SCOPE_IDENTITY()";
								int.TryParse(Enumerable.FirstOrDefault<decimal>(db.Database.SqlQuery<decimal>(text2, new object[13]
								{
									formbase.ItemTitle,
									formbase.ItemRate,
									formbase.UserId,
									formbase.Month1,
									formbase.RegisterDate,
									formbase.RegisterDatePersian,
									num6,
									Configuration.AppType,
									Guid.NewGuid(),
									formbase.UserId,
									formbase.RegisterDate,
									formbase.RegisterDatePersian,
									defLangID
								})).ToString(), out result);
							}
							else
							{
								text2 = "INSERT INTO " + formbase.NameTabel + "([" + formbase.NamefieldI + "],[" + formbase.NamefieldII + "],[" + formbase.NamefieldVII + "],[UserId],[Year1],[Month1],[RegisterDate],[RegisterDatePersian],[AppType],[GUId],[FirstRegisterUserId],[FirstRegisterDatePersian],[FirstRegisterDate],[LanguageID]) VALUES ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13}) SELECT SCOPE_IDENTITY() SELECT SCOPE_IDENTITY()";
								int.TryParse(Enumerable.FirstOrDefault<decimal>(db.Database.SqlQuery<decimal>(text2, new object[14]
								{
									formbase.ItemTitle,
									formbase.ItemDesc,
									formbase.ItemRate,
									formbase.UserId,
									formbase.Year1,
									formbase.Month1,
									formbase.RegisterDate,
									formbase.RegisterDatePersian,
									Configuration.AppType,
									Guid.NewGuid(),
									formbase.UserId,
									formbase.RegisterDatePersian,
									formbase.RegisterDate,
									defLangID
								})).ToString(), out result);
							}
						}
						else
						{
							text2 = "INSERT INTO " + formbase.NameTabel + "([" + formbase.NamefieldI + "],[" + formbase.NamefieldII + "],[" + formbase.NamefieldVII + "],[UserId],[Year1],[Month1],[RegisterDate],[RegisterDatePersian],[AppType],[GUId],[FirstRegisterUserId],[FirstRegisterDatePersian],[FirstRegisterDate],[LanguageID]) VALUES ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13}) SELECT SCOPE_IDENTITY() SELECT SCOPE_IDENTITY()";
							int.TryParse(Enumerable.FirstOrDefault<decimal>(db.Database.SqlQuery<decimal>(text2, new object[14]
							{
								formbase.ItemTitle,
								formbase.ItemDesc,
								formbase.ItemRate,
								formbase.UserId,
								formbase.Year1,
								formbase.Month1,
								formbase.RegisterDate,
								formbase.RegisterDatePersian,
								Configuration.AppType,
								Guid.NewGuid(),
								formbase.UserId,
								formbase.RegisterDatePersian,
								formbase.RegisterDate,
								defLangID
							})).ToString(), out result);
						}
					}
					else
					{
						text2 = "INSERT INTO " + formbase.NameTabel + "([" + formbase.NamefieldI + "],[" + formbase.NamefieldII + "],[UserId],[Year1],[Month1],[RegisterDate],[RegisterDatePersian],[AppType],[GUId],[FirstRegisterUserId],[FirstRegisterDatePersian],[FirstRegisterDate],[LanguageID]) VALUES ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}) SELECT SCOPE_IDENTITY() SELECT SCOPE_IDENTITY()";
						int.TryParse(Enumerable.FirstOrDefault<decimal>(db.Database.SqlQuery<decimal>(text2, new object[13]
						{
							formbase.ItemTitle,
							formbase.ItemDesc,
							formbase.UserId,
							formbase.Year1,
							formbase.Month1,
							formbase.RegisterDate,
							formbase.RegisterDatePersian,
							Configuration.AppType,
							Guid.NewGuid(),
							formbase.UserId,
							formbase.RegisterDatePersian,
							formbase.RegisterDate,
							defLangID
						})).ToString(), out result);
					}
					if (result > 0)
					{
						if (formbase.isLanguage)
						{
							foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))))
							{
								string text3 = "";
								string text4 = null;
								string text5 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
								if (string.IsNullOrEmpty(formbase.NamefieldII))
								{
									text3 = "INSERT INTO " + formbase.NameTabel + "_Lang ([LanguageID], [" + formbase.NamefieldID + "], [" + formbase.NamefieldI + "]) VALUES ({0},{1},{2})";
									if (db.Database.ExecuteSqlCommand(text3, lang.LanguageID, result, text5) <= 0)
									{
										text = Messages.frmErrorMessage;
										break;
									}
									continue;
								}
								text3 = "INSERT INTO " + formbase.NameTabel + "_Lang ([LanguageID], [" + formbase.NamefieldID + "], [" + formbase.NamefieldI + "], [" + formbase.NamefieldII + "]) VALUES ({0},{1},{2},{3})";
								text4 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
								if (db.Database.ExecuteSqlCommand(text3, lang.LanguageID, result, text5, text4) <= 0)
								{
									text = Messages.frmErrorMessage;
									break;
								}
							}
						}
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo(formbase.NameTabel);
						int userId = UserLogin.CurrentUser.UserId;
						short value = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
						short.Parse(Financial.Get().Id.ToString());
						int id = Financial.Get().Id;
						DateTime now2 = DateTime.Now;
						string registerDatePersian = now2.ToString("yyyyMMdd", new PersianCulture());
						string appType = Configuration.AppType;
						bool result2 = false;
						bool.TryParse(formbase.ItemUserAccessAll.ToString(), out result2);
						if (formbase.NameTabel == "WSPreOrderTypes")
						{
							if (result2)
							{
								_dbII.WSspInsertPreOrderTypeUserAccessToAllUsers(result, userId, id, value, now2, registerDatePersian, appType, defLangID);
							}
							else
							{
								_dbII.WSspInsertPreOrderTypeUserAccess(userId.ToString(), result, userId, id, value, now2, registerDatePersian, appType, defLangID);
							}
							CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSPreOrderTypeUserAccess");
						}
						if (text.Trim() == "")
						{
							base.ViewBag.SuccessfullFormBaseInsert = Messages.frmFormBaseInsertSuccessFulMessage;
						}
					}
					else
					{
						text += Messages.frmErrorMessage;
					}
				}
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
			text = Messages.frmErrorMessage;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			text = Messages.frmErrorMessage;
		}
		base.ViewBag.Error = text;
		return View(formbase);
	}

	[LoginAuthorize]
	public ActionResult FormBaseEdit(int id, string FormName, string TypeAction)
	{
		if (!UserLogin.IsUserAccess(FormName, "actEdit", UserLogin.CurrentUser))
		{
			return RedirectToAction("Login", "Account", (object)new
			{
				area = "",
				d = DateTime.Now
			});
		}
		FormFullBaseInfoViewModel formFullBaseInfoViewModel = new FormFullBaseInfoViewModel();
		FormFullBaseInfoViewModel formFullBaseInfoViewModel2 = new FormFullBaseInfoViewModel();
		formFullBaseInfoViewModel2 = FullForm(TypeAction);
		formFullBaseInfoViewModel = FindFormBaseInfo(id, formFullBaseInfoViewModel2);
		if (formFullBaseInfoViewModel == null)
		{
			formFullBaseInfoViewModel = new FormFullBaseInfoViewModel();
			formFullBaseInfoViewModel.UserId = UserLogin.CurrentUser.UserId;
			formFullBaseInfoViewModel.Year1 = short.Parse(Financial.Get().Id.ToString());
			formFullBaseInfoViewModel.Month1 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			formFullBaseInfoViewModel.RegisterDate = DateTime.Now;
			formFullBaseInfoViewModel.RegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			formFullBaseInfoViewModel.ItemId = id;
		}
		return View(formFullBaseInfoViewModel);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	[LoginAuthorize]
	public ActionResult FormBaseEdit(FormFullBaseInfoViewModel formbase)
	{
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int num = 0;
		if (formbase.TypeAction == "actDefineCountry")
		{
			if (!UserLogin.IsUserAccess(formbase.TypeAccess, "actPost", UserLogin.CurrentUser))
			{
				return RedirectToAction("Login", "Account", (object)new
				{
					area = "",
					d = DateTime.Now
				});
			}
		}
		else if (!UserLogin.IsUserAccess("frmDefineBaseInfoIDataEntry", "actPost", UserLogin.CurrentUser))
		{
			return RedirectToAction("Login", "Account", (object)new
			{
				area = "",
				d = DateTime.Now
			});
		}
		new FormFullBaseInfoViewModel();
		try
		{
			if (base.ModelState.IsValid)
			{
				List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(formbase.ItemTitle_Lang))
				{
					list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(formbase.ItemTitle_Lang);
				}
				list.Add(new CommonMultiLanguageViewModel
				{
					Value = formbase.ItemTitle,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(formbase.ItemDesc_Lang))
				{
					list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(formbase.ItemDesc_Lang);
				}
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = formbase.ItemDesc,
					LanguageId = lCID
				});
				if (formbase.ItemTitle == null)
				{
					text = text + Messages.CheckEmptyFormBaseTitle + "|";
					num++;
				}
				else if (!checkMultiLanguage(formbase.ItemTitle, list))
				{
					text = text + Messages.CheckFormBaseTitleLang + "<br>";
					num++;
				}
				if (formbase.NameTabel == "WSDeliveryTerms" && formbase.SHPDefault.GetValueOrDefault())
				{
					WSspSelectDeliveryTermSHPDefault_Result wSspSelectDeliveryTermSHPDefault_Result = Enumerable.FirstOrDefault<WSspSelectDeliveryTermSHPDefault_Result>((IEnumerable<WSspSelectDeliveryTermSHPDefault_Result>)_dbI.WSspSelectDeliveryTermSHPDefault(lCID, defLangID));
					if (wSspSelectDeliveryTermSHPDefault_Result != null && formbase.ItemId != wSspSelectDeliveryTermSHPDefault_Result.DeliveryTermId)
					{
						text = text + string.Format(Messages.msgErrorNoRegisterItemAlreadySelected, wSspSelectDeliveryTermSHPDefault_Result.DeliveryTerm ?? "", Labels.FullbaseInfoSHPDefault) + "<br>";
						num++;
					}
				}
				if (num == 0)
				{
					formbase.UserId = UserLogin.CurrentUser.UserId;
					DateTime dateTime = (formbase.RegisterDate = DateTime.Now);
					formbase.RegisterDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
					formbase.Month1 = short.Parse(dateTime.ToString("MM", new PersianCulture()));
					formbase.Year1 = short.Parse(Financial.Get().Id.ToString());
					formbase.ItemTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
					formbase.ItemDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
					int num2 = 0;
					string text2 = "";
					if (formbase.ItemDescVisibale == "hidden" && formbase.ItemOrderVisibale == "hidden" && formbase.ItemRateVisibale == "hidden" && formbase.ItemDeActiveVisibale == "hidden" && formbase.SHPDefaultVisible == "visible" && formbase.SHPVisible_Visible == "visible" && formbase.SHPNeedAddressVisible == "visible")
					{
						if (formbase.NameTabel == "WSDeliveryTerms")
						{
							text2 = "UPDATE " + formbase.NameTabel + " SET [" + formbase.NamefieldI + "] = {0},[UserId]={1},[Month1]={2},[RegisterDate]={3},[RegisterDatePersian]={4},[AppType]={5},[" + formbase.NamefieldSHPDefault + "]={6},[" + formbase.NamefieldSHPVisible + "]={7},[" + formbase.NamefieldSHPNeedAddress + "]={9} WHERE [" + formbase.NamefieldID + "] = {8}";
							num2 = db.Database.ExecuteSqlCommand(text2, formbase.ItemTitle, formbase.UserId, formbase.Month1, formbase.RegisterDate, formbase.RegisterDatePersian, Configuration.AppType, formbase.SHPDefault.GetValueOrDefault(), formbase.SHPVisible.GetValueOrDefault(), formbase.ItemId, formbase.SHPNeedAddress.GetValueOrDefault());
						}
					}
					else if (formbase.ItemDescVisibale == "hidden" && formbase.ItemOrderVisibale == "hidden" && formbase.ItemRateVisibale == "hidden" && formbase.ItemDeActiveVisibale == "hidden" && formbase.SHPDefaultVisible == "hidden" && formbase.SHPVisible_Visible == "hidden" && formbase.ItemCodeVisibale == "visible" && formbase.SHPNeedAddressVisible == "hidden")
					{
						switch (formbase.NameTabel)
						{
						case "WSOrderPaymentGroupsI":
						case "WSOrderPaymentGroupsII":
							text2 = "UPDATE " + formbase.NameTabel + " SET [" + formbase.NamefieldI + "] = {0},[UserId]={1},[Month1]={2},[RegisterDate]={3},[RegisterDatePersian]={4},[AppType]={5},[" + formbase.NamefieldCode + "]={6} WHERE [" + formbase.NamefieldID + "] = {7}";
							num2 = db.Database.ExecuteSqlCommand(text2, formbase.ItemTitle, formbase.UserId, formbase.Month1, formbase.RegisterDate, formbase.RegisterDatePersian, Configuration.AppType, formbase.ItemCode, formbase.ItemId);
							break;
						case "CrmCashes":
							text2 = "UPDATE " + formbase.NameTabel + " SET [" + formbase.NamefieldI + "] = {0}, [" + formbase.NamefieldCode + "] = {1},[UserId]={2},[Year1]={3},[Month1]={4},[RegisterDate]={5},[RegisterDatePersian]={6},[AppType]={7} WHERE [" + formbase.NamefieldID + "] = {8}";
							num2 = db.Database.ExecuteSqlCommand(text2, formbase.ItemTitle, formbase.ItemCode, formbase.UserId, formbase.Year1, formbase.Month1, formbase.RegisterDate, formbase.RegisterDatePersian, Configuration.AppType, formbase.ItemId);
							break;
						}
					}
					else if (formbase.ItemDescVisibale == "hidden" && formbase.ItemOrderVisibale == "hidden" && formbase.ItemRateVisibale == "hidden" && formbase.ItemDeActiveVisibale == "hidden")
					{
						switch (formbase.NameTabel)
						{
						case "WSPreOrderStatus":
							text2 = "UPDATE " + formbase.NameTabel + " SET [" + formbase.NamefieldI + "] = {0},[AppType]={1} WHERE [" + formbase.NamefieldID + "] = {2}";
							num2 = db.Database.ExecuteSqlCommand(text2, formbase.ItemTitle, Configuration.AppType, formbase.ItemId);
							break;
						case "CrmKnowledgeTankPriority":
						case "CrmKnowledgeTankGroup":
							text2 = "UPDATE " + formbase.NameTabel + " SET [" + formbase.NamefieldI + "] = {0},[UserId]={1},[Year1]={2},[Month1]={3},[RegisterDate]={4},[RegisterDatePersian]={5},[AppType]={6} WHERE [" + formbase.NamefieldID + "] = {7}";
							num2 = db.Database.ExecuteSqlCommand(text2, formbase.ItemTitle, formbase.UserId, formbase.Year1, formbase.Month1, formbase.RegisterDate, formbase.RegisterDatePersian, Configuration.AppType, formbase.ItemId);
							break;
						case "WSCostSheetDyFieldGroups":
						case "WSPreOrderOpr":
						case "WSOrderGroups":
						case "WSSaleCenters":
						case "WSDeliveryTime":
						case "WSPayCondition":
						case "WSGuaranty":
						case "actDefineSettlementType":
						case "actordDefineSettlementType":
						case "WSBuyOrderPaymentTypes":
						case "WSPreOrderTypes":
						case "WSSaleAreas":
							text2 = "UPDATE " + formbase.NameTabel + " SET [" + formbase.NamefieldI + "] = {0},[UserId]={1},[Month1]={2},[RegisterDate]={3},[RegisterDatePersian]={4},[AppType]={5} WHERE [" + formbase.NamefieldID + "] = {6}";
							num2 = db.Database.ExecuteSqlCommand(text2, formbase.ItemTitle, formbase.UserId, formbase.Month1, formbase.RegisterDate, formbase.RegisterDatePersian, Configuration.AppType, formbase.ItemId);
							break;
						case "WSPreOrderPrdGroupMustExistReasonGroups":
							text2 = "UPDATE " + formbase.NameTabel + " SET [" + formbase.NamefieldI + "] = {0},[UserId]={1},[FPId]={2},[Month1]={3},[RegisterDate]={4},[RegisterDatePersian]={5},[AppType]={6}, [" + formbase.NamefieldVI + "] = {7} WHERE [" + formbase.NamefieldID + "] = {8}";
							num2 = db.Database.ExecuteSqlCommand(text2, formbase.ItemTitle, formbase.UserId, formbase.Year1, formbase.Month1, formbase.RegisterDate, formbase.RegisterDatePersian, Configuration.AppType, formbase.ItemDefault, formbase.ItemId);
							break;
						default:
							text2 = "UPDATE " + formbase.NameTabel + " SET [" + formbase.NamefieldI + "] = {0},[UserId]={1},[Year1]={2},[Month1]={3},[RegisterDate]={4},[RegisterDatePersian]={5},[AppType]={6} WHERE [" + formbase.NamefieldID + "] = {7}";
							num2 = db.Database.ExecuteSqlCommand(text2, formbase.ItemTitle, formbase.UserId, formbase.Year1, formbase.Month1, formbase.RegisterDate, formbase.RegisterDatePersian, Configuration.AppType, formbase.ItemId);
							break;
						}
					}
					else if (formbase.ItemDescVisibale == "hidden" && formbase.ItemOrderVisibale == "visible" && formbase.ItemDeActiveVisibale == "hidden")
					{
						switch (formbase.NameTabel)
						{
						case "CrmInternalMessageGroup":
						case "CrmProjectGroupsMulti":
						case "PayRollListGroups":
							text2 = "UPDATE " + formbase.NameTabel + " SET [" + formbase.NamefieldI + "] = {0}, [" + formbase.NamefieldIV + "] = {1},[UserId]={2},[Year1]={3},[Month1]={4},[RegisterDate]={5},[RegisterDatePersian]={6},[AppType]={7} WHERE [" + formbase.NamefieldID + "] = {8}";
							num2 = db.Database.ExecuteSqlCommand(text2, formbase.ItemTitle, formbase.ItemOrder, formbase.UserId, formbase.Year1, formbase.Month1, formbase.RegisterDate, formbase.RegisterDatePersian, Configuration.AppType, formbase.ItemId);
							break;
						case "CrmProjectGroupsMultiI":
							text2 = "UPDATE " + formbase.NameTabel + " SET [" + formbase.NamefieldI + "] = {0}, [" + formbase.NamefieldIV + "] = {1},[UserId]={2},[Year1]={3},[Month1]={4},[RegisterDate]={5},[RegisterDatePersian]={6},[AppType]={7}, [" + formbase.NamefieldVI + "] = {8} WHERE [" + formbase.NamefieldID + "] = {9}";
							num2 = db.Database.ExecuteSqlCommand(text2, formbase.ItemTitle, formbase.ItemOrder, formbase.UserId, formbase.Year1, formbase.Month1, formbase.RegisterDate, formbase.RegisterDatePersian, Configuration.AppType, formbase.ItemDefault, formbase.ItemId);
							break;
						}
					}
					else if (formbase.ItemOrderVisibale == "visible" && formbase.ItemDeActiveVisibale == "visible" && formbase.ItemRateVisibale == "hidden")
					{
						if (formbase.NameTabel == "WSOrderPaymentTypes")
						{
							text2 = "UPDATE " + formbase.NameTabel + " SET [" + formbase.NamefieldI + "] = {0},[UserId]={1},[Month1]={2},[RegisterDate]={3},[RegisterDatePersian]={4},[AppType]={5},[" + formbase.NamefieldIV + "] = {6},[" + formbase.NamefieldVIII + "] = {7} WHERE [" + formbase.NamefieldID + "] = {8}";
							num2 = db.Database.ExecuteSqlCommand(text2, formbase.ItemTitle, formbase.UserId, formbase.Month1, formbase.RegisterDate, formbase.RegisterDatePersian, Configuration.AppType, formbase.ItemOrder, formbase.ItemDeActive, formbase.ItemId);
						}
						else
						{
							text2 = "UPDATE " + formbase.NameTabel + " SET [" + formbase.NamefieldI + "] = {0}, [" + formbase.NamefieldII + "] = {1},[UserId]={2},[Year1]={3},[Month1]={4},[RegisterDate]={5},[RegisterDatePersian]={6},[AppType]={7},[" + formbase.NamefieldVII + "]={8} WHERE [" + formbase.NamefieldID + "] = {9}";
							num2 = db.Database.ExecuteSqlCommand(text2, formbase.ItemTitle, formbase.ItemDesc, formbase.UserId, formbase.Year1, formbase.Month1, formbase.RegisterDate, formbase.RegisterDatePersian, Configuration.AppType, formbase.ItemRate, formbase.ItemId);
						}
					}
					else if (formbase.CheckUserDistanceCmpVisible == "visible" && formbase.UserDistanceCmpValVisible == "visible")
					{
						if (formbase.NameTabel == "CrmConversationTopics")
						{
							text2 = "UPDATE " + formbase.NameTabel + " SET [" + formbase.NamefieldI + "] = {0}, [" + formbase.NamefieldII + "] = {1},[UserId]={2},[Year1]={3},[Month1]={4},[RegisterDate]={5},[RegisterDatePersian]={6},[AppType]={7},[" + formbase.NamefieldIX + "]={8},[" + formbase.NamefieldX + "]={9} WHERE [" + formbase.NamefieldID + "] = {10}";
							num2 = db.Database.ExecuteSqlCommand(text2, formbase.ItemTitle, formbase.ItemDesc, formbase.UserId, formbase.Year1, formbase.Month1, formbase.RegisterDate, formbase.RegisterDatePersian, Configuration.AppType, (!formbase.CheckUserDistanceCmp.GetValueOrDefault()) ? null : formbase.CheckUserDistanceCmp, formbase.UserDistanceCmpVal, formbase.ItemId);
						}
						else
						{
							text2 = "UPDATE " + formbase.NameTabel + " SET [" + formbase.NamefieldI + "] = {0}, [" + formbase.NamefieldII + "] = {1},[UserId]={2},[Year1]={3},[Month1]={4},[RegisterDate]={5},[RegisterDatePersian]={6},[AppType]={7},[" + formbase.NamefieldVII + "]={8} WHERE [" + formbase.NamefieldID + "] = {9}";
							num2 = db.Database.ExecuteSqlCommand(text2, formbase.ItemTitle, formbase.ItemDesc, formbase.UserId, formbase.Year1, formbase.Month1, formbase.RegisterDate, formbase.RegisterDatePersian, Configuration.AppType, formbase.ItemRate, formbase.ItemId);
						}
					}
					else if (formbase.ItemScoreRateVisibale == "visible")
					{
						if (formbase.NameTabel == "CrmCompanyGroupsII")
						{
							text2 = "UPDATE " + formbase.NameTabel + " SET [" + formbase.NamefieldI + "] = {0}, [" + formbase.NamefieldII + "] = {1},[UserId]={2},[Year1]={3},[Month1]={4},[RegisterDate]={5},[RegisterDatePersian]={6},[AppType]={7},[" + formbase.NamefieldVII + "]={8},[" + formbase.NamefieldScoreRate + "]={9} WHERE [" + formbase.NamefieldID + "] = {10}";
							num2 = db.Database.ExecuteSqlCommand(text2, formbase.ItemTitle, formbase.ItemDesc, formbase.UserId, formbase.Year1, formbase.Month1, formbase.RegisterDate, formbase.RegisterDatePersian, Configuration.AppType, formbase.ItemRate, formbase.ItemScoreRate, formbase.ItemId);
						}
						else
						{
							text2 = "UPDATE " + formbase.NameTabel + " SET [" + formbase.NamefieldI + "] = {0}, [" + formbase.NamefieldII + "] = {1},[UserId]={2},[Year1]={3},[Month1]={4},[RegisterDate]={5},[RegisterDatePersian]={6},[AppType]={7},[" + formbase.NamefieldScoreRate + "]={8} WHERE [" + formbase.NamefieldID + "] = {9}";
							num2 = db.Database.ExecuteSqlCommand(text2, formbase.ItemTitle, formbase.ItemDesc, formbase.UserId, formbase.Year1, formbase.Month1, formbase.RegisterDate, formbase.RegisterDatePersian, Configuration.AppType, formbase.ItemScoreRate, formbase.ItemId);
						}
					}
					else if (formbase.ItemRateVisibale == "visible")
					{
						string nameTabel = formbase.NameTabel;
						if (!(nameTabel == "CrmCompanyGroupsII"))
						{
							if (nameTabel == "WSCreditDuration")
							{
								text2 = "UPDATE " + formbase.NameTabel + " SET [" + formbase.NamefieldI + "] = {0},[UserId]={1},[Month1]={2},[RegisterDate]={3},[RegisterDatePersian]={4},[AppType]={5},[" + formbase.NamefieldVII + "]={6} WHERE [" + formbase.NamefieldID + "] = {7}";
								num2 = db.Database.ExecuteSqlCommand(text2, formbase.ItemTitle, formbase.UserId, formbase.Month1, formbase.RegisterDate, formbase.RegisterDatePersian, Configuration.AppType, formbase.ItemRate, formbase.ItemId);
							}
							else
							{
								text2 = "UPDATE " + formbase.NameTabel + " SET [" + formbase.NamefieldI + "] = {0}, [" + formbase.NamefieldII + "] = {1},[UserId]={2},[Year1]={3},[Month1]={4},[RegisterDate]={5},[RegisterDatePersian]={6},[AppType]={7},[" + formbase.NamefieldVII + "]={8} WHERE [" + formbase.NamefieldID + "] = {9}";
								num2 = db.Database.ExecuteSqlCommand(text2, formbase.ItemTitle, formbase.ItemDesc, formbase.UserId, formbase.Year1, formbase.Month1, formbase.RegisterDate, formbase.RegisterDatePersian, Configuration.AppType, formbase.ItemRate, formbase.ItemId);
							}
						}
						else
						{
							text2 = "UPDATE " + formbase.NameTabel + " SET [" + formbase.NamefieldI + "] = {0}, [" + formbase.NamefieldII + "] = {1},[UserId]={2},[Year1]={3},[Month1]={4},[RegisterDate]={5},[RegisterDatePersian]={6},[AppType]={7},[" + formbase.NamefieldVII + "]={8} WHERE [" + formbase.NamefieldID + "] = {9}";
							num2 = db.Database.ExecuteSqlCommand(text2, formbase.ItemTitle, formbase.ItemDesc, formbase.UserId, formbase.Year1, formbase.Month1, formbase.RegisterDate, formbase.RegisterDatePersian, Configuration.AppType, formbase.ItemRate, formbase.ItemId);
						}
					}
					else
					{
						text2 = "UPDATE " + formbase.NameTabel + " SET [" + formbase.NamefieldI + "] = {0}, [" + formbase.NamefieldII + "] = {1},[UserId]={2},[Year1]={3},[Month1]={4},[RegisterDate]={5},[RegisterDatePersian]={6},[AppType]={7} WHERE [" + formbase.NamefieldID + "] = {8}";
						num2 = db.Database.ExecuteSqlCommand(text2, formbase.ItemTitle, formbase.ItemDesc, formbase.UserId, formbase.Year1, formbase.Month1, formbase.RegisterDate, formbase.RegisterDatePersian, Configuration.AppType, formbase.ItemId);
					}
					if (num2 != 0)
					{
						if (formbase.isLanguage)
						{
							foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangID))))
							{
								string text3 = "";
								string text4 = null;
								string text5 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
								if (string.IsNullOrEmpty(formbase.NamefieldII))
								{
									text3 = "UPDATE " + formbase.NameTabel + "_Lang SET  [" + formbase.NamefieldI + "] = {0} WHERE [" + formbase.NamefieldID + "] = {1} AND [LanguageID]= {2}";
									if (db.Database.ExecuteSqlCommand(text3, text5, formbase.ItemId, lang.LanguageID) <= 0)
									{
										text3 = "INSERT INTO " + formbase.NameTabel + "_Lang ([LanguageID], [" + formbase.NamefieldID + "], [" + formbase.NamefieldI + "]) VALUES ({0},{1},{2})";
										db.Database.ExecuteSqlCommand(text3, lang.LanguageID, formbase.ItemId, text5);
									}
									continue;
								}
								text3 = "UPDATE " + formbase.NameTabel + "_Lang SET  [" + formbase.NamefieldI + "] = {0},  [" + formbase.NamefieldII + "] = {1}  WHERE [" + formbase.NamefieldID + "] = {2} AND [LanguageID]= {3}";
								text4 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
								if (db.Database.ExecuteSqlCommand(text3, text5, text4, formbase.ItemId, lang.LanguageID) <= 0)
								{
									text3 = "INSERT INTO " + formbase.NameTabel + "_Lang ([LanguageID], [" + formbase.NamefieldID + "], [" + formbase.NamefieldI + "], [" + formbase.NamefieldII + "]) VALUES ({0},{1},{2},{3})";
									db.Database.ExecuteSqlCommand(text3, lang.LanguageID, formbase.ItemId, text5, text4);
								}
							}
						}
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo(formbase.NameTabel);
						if (text.Trim() == "")
						{
							base.ViewBag.SuccessfullFormBaseEdit = Messages.frmFormBaseEditSuccessFulMessage;
						}
					}
					else
					{
						text += Messages.frmErrorMessage;
					}
				}
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
			text = Messages.frmErrorMessage;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			text = Messages.frmErrorMessage;
		}
		base.ViewBag.Error = text;
		return View(formbase);
	}

	[LoginAuthorize]
	public string FormBaseDelete(int id, string FormName, string TypeAction)
	{
		string result = "-1";
		if (!UserLogin.IsUserAccess(FormName, "actDelete", UserLogin.CurrentUser))
		{
			return result;
		}
		FormFullBaseInfoViewModel formFullBaseInfoViewModel = new FormFullBaseInfoViewModel();
		formFullBaseInfoViewModel = FullForm(TypeAction);
		return RecordDelete(id, formFullBaseInfoViewModel);
	}

	public string RecordDelete(int id, FormFullBaseInfoViewModel formbaseInfo)
	{
		//IL_1c27: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c2e: Expected O, but got Unknown
		//IL_1c2e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c33: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c39: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c41: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass14_0 _003C_003Ec__DisplayClass14_ = new _003C_003Ec__DisplayClass14_0();
		_003C_003Ec__DisplayClass14_.id = id;
		string text = "";
		try
		{
			if (formbaseInfo != null)
			{
				switch (formbaseInfo.TypeAction)
				{
				case "actDefineCountry":
				{
					Country country = _dbTbl.Country.Find(_003C_003Ec__DisplayClass14_.id);
					if (country != null && (country.Province.Count > 0 || country.CrmCompany.Count > 0 || country.CrmCompanyPersons.Count > 0))
					{
						text = "-1";
					}
					break;
				}
				case "actDefinecmpTitle":
				{
					CrmCompanyTitle crmCompanyTitle = _dbTbl.CrmCompanyTitle.Find(_003C_003Ec__DisplayClass14_.id);
					if (crmCompanyTitle != null && crmCompanyTitle.CrmCompany.Count > 0)
					{
						text = "-1";
					}
					break;
				}
				case "actDefinecmpPresentation":
				{
					CrmCompanyPresentation crmCompanyPresentation = _dbTbl.CrmCompanyPresentation.Find(_003C_003Ec__DisplayClass14_.id);
					if (crmCompanyPresentation != null && crmCompanyPresentation.CrmCompany.Count > 0)
					{
						text = "-1";
					}
					break;
				}
				case "actDefinecmpType":
				{
					CrmCompanyType crmCompanyType = _dbTbl.CrmCompanyType.Find(_003C_003Ec__DisplayClass14_.id);
					if (crmCompanyType != null && crmCompanyType.CrmCompany.Count > 0)
					{
						text = "-1";
					}
					break;
				}
				case "actDefineCmpAddType":
				{
					CrmCompanyAddressType crmCompanyAddressType = _dbTbl.CrmCompanyAddressType.Find(_003C_003Ec__DisplayClass14_.id);
					if (crmCompanyAddressType != null && crmCompanyAddressType.CrmCompanyAddresses.Count > 0)
					{
						text = "-1";
					}
					break;
				}
				case "actDefinecmpGroups":
				{
					CrmCompanyGroups crmCompanyGroups = _dbTbl.CrmCompanyGroups.Find(_003C_003Ec__DisplayClass14_.id);
					if (crmCompanyGroups != null && (crmCompanyGroups.CrmCompany.Count > 0 || crmCompanyGroups.CrmCompanySubGroups.Count > 0))
					{
						text = "-1";
					}
					break;
				}
				case "actDefinecmpGroupsII":
				{
					CrmCompanyGroupsII crmCompanyGroupsII = _dbTbl.CrmCompanyGroupsII.Find(_003C_003Ec__DisplayClass14_.id);
					if (crmCompanyGroupsII != null && crmCompanyGroupsII.CrmCompany.Count > 0)
					{
						text = "-1";
					}
					break;
				}
				case "actDefinecmpGroupsIII":
				{
					CrmCompanyGroupsIII crmCompanyGroupsIII = _dbTbl.CrmCompanyGroupsIII.Find(_003C_003Ec__DisplayClass14_.id);
					if (crmCompanyGroupsIII != null && crmCompanyGroupsIII.CrmCompany.Count > 0)
					{
						text = "-1";
					}
					break;
				}
				case "actDefinecmpGroupsIV":
				{
					CrmCompanyGroupsIV crmCompanyGroupsIV = _dbTbl.CrmCompanyGroupsIV.Find(_003C_003Ec__DisplayClass14_.id);
					if (crmCompanyGroupsIV != null && crmCompanyGroupsIV.CrmCompany.Count > 0)
					{
						text = "-1";
					}
					break;
				}
				case "actDefinecmpGroupsMulti":
				{
					CrmCompanyGroupsMulti crmCompanyGroupsMulti = _dbTbl.CrmCompanyGroupsMulti.Find(_003C_003Ec__DisplayClass14_.id);
					if (crmCompanyGroupsMulti != null && crmCompanyGroupsMulti.CrmCompanyMultiGroups.Count > 0)
					{
						text = "-1";
					}
					break;
				}
				case "actDefineprsTitle":
				case "actDefinePrsTitle":
				{
					CrmPersonTitle crmPersonTitle = _dbTbl.CrmPersonTitle.Find(_003C_003Ec__DisplayClass14_.id);
					if (crmPersonTitle != null && crmPersonTitle.CrmCompanyPersons.Count > 0)
					{
						text = "-1";
					}
					break;
				}
				case "actDefinePrsJobs":
				case "actDefineprsJobs":
				{
					CrmPersonJobs crmPersonJobs = _dbTbl.CrmPersonJobs.Find(_003C_003Ec__DisplayClass14_.id);
					if (crmPersonJobs != null && crmPersonJobs.CrmCompanyPersons.Count > 0)
					{
						text = "-1";
					}
					break;
				}
				case "actDefineprsDepartment":
				{
					CrmPersonDepartments crmPersonDepartments = _dbTbl.CrmPersonDepartments.Find(_003C_003Ec__DisplayClass14_.id);
					if (crmPersonDepartments != null && crmPersonDepartments.CrmCompanyPersons.Count > 0)
					{
						text = "-1";
					}
					break;
				}
				case "actDefineprsType":
				{
					CrmPersonType crmPersonType = _dbTbl.CrmPersonType.Find(_003C_003Ec__DisplayClass14_.id);
					if (crmPersonType != null && crmPersonType.CrmCompanyPersons.Count > 0)
					{
						text = "-1";
					}
					break;
				}
				case "actDefineprsGroup":
				case "actDefineprsGroups":
				{
					CrmPersonGroups crmPersonGroups = _dbTbl.CrmPersonGroups.Find(_003C_003Ec__DisplayClass14_.id);
					if (crmPersonGroups != null && crmPersonGroups.CrmCompanyPersons.Count > 0)
					{
						text = "-1";
					}
					break;
				}
				case "actDefineEducation":
				{
					Education education = _dbTbl.Education.Find(_003C_003Ec__DisplayClass14_.id);
					if (education != null && education.CrmCompanyPersons.Count > 0)
					{
						text = "-1";
					}
					break;
				}
				case "actDefinecnvsStatusGroups":
				case "actDefineGroups":
					if (_dbTbl.CrmConversationStatusGroups.Find(_003C_003Ec__DisplayClass14_.id) == null)
					{
					}
					break;
				case "actDefinePrjGroup":
					if (_dbTbl.CrmProjectGroups.Find(_003C_003Ec__DisplayClass14_.id) == null)
					{
					}
					break;
				case "actDefinePrjGrade":
				{
					CrmProjectGrade crmProjectGrade = _dbTbl.CrmProjectGrade.Find(_003C_003Ec__DisplayClass14_.id);
					if (crmProjectGrade != null && crmProjectGrade.CrmProjects.Count > 0)
					{
						text = "-1";
					}
					break;
				}
				case "actDefinecnvsTopics":
				case "actDefineTopic":
				{
					CrmConversationTopics crmConversationTopics = _dbTbl.CrmConversationTopics.Find(_003C_003Ec__DisplayClass14_.id);
					if (crmConversationTopics != null && crmConversationTopics.CrmConversation.Count > 0)
					{
						text = "-1";
					}
					break;
				}
				case "actUTDefineGroup":
				{
					CrmUserTaskGroups crmUserTaskGroups = _dbTbl.CrmUserTaskGroups.Find(_003C_003Ec__DisplayClass14_.id);
					if (crmUserTaskGroups != null && crmUserTaskGroups.CrmUserTasks.Count > 0)
					{
						text = "-1";
					}
					break;
				}
				case "actDefineKnowledgeTankGroup":
				{
					CrmKnowledgeTankGroup crmKnowledgeTankGroup = _dbTbl.CrmKnowledgeTankGroup.Find(_003C_003Ec__DisplayClass14_.id);
					_ = crmKnowledgeTankGroup.CrmKnowledgeTank.Count;
					if (crmKnowledgeTankGroup.CrmKnowledgeTank.Count > 0)
					{
						text = "-1";
					}
					break;
				}
				case "actDefineKnowledgeTankPriority":
				{
					CrmKnowledgeTankPriority crmKnowledgeTankPriority = _dbTbl.CrmKnowledgeTankPriority.Find(_003C_003Ec__DisplayClass14_.id);
					_ = crmKnowledgeTankPriority.CrmKnowledgeTank.Count;
					if (crmKnowledgeTankPriority.CrmKnowledgeTank.Count > 0)
					{
						text = "-1";
					}
					break;
				}
				case "actluDepartment":
					if (_dbTbl.UserDepartments.Find(_003C_003Ec__DisplayClass14_.id) == null)
					{
					}
					break;
				case "actDefineFileType":
				case "actDefinecmpFileType":
				{
					CrmFileDirectoryType crmFileDirectoryType = _dbTbl.CrmFileDirectoryType.Find(_003C_003Ec__DisplayClass14_.id);
					_ = crmFileDirectoryType.CrmFilesDirectory.Count;
					if (crmFileDirectoryType.CrmFilesDirectory.Count > 0)
					{
						text = "-1";
					}
					break;
				}
				case "actDefineSex":
				{
					Sex sex = _dbTbl.Sex.Find(_003C_003Ec__DisplayClass14_.id);
					_ = sex.CrmCompanyPersons.Count;
					if (sex.CrmCompanyPersons.Count > 0)
					{
						text = "-1";
					}
					break;
				}
				case "actDefineInternalMessagePriority":
					_dbTbl.CrmInternalMessagePriority.Find(_003C_003Ec__DisplayClass14_.id);
					break;
				case "actDefineInternalMessageGroup":
				{
					CrmInternalMessageGroup crmInternalMessageGroup = _dbTbl.CrmInternalMessageGroup.Find(_003C_003Ec__DisplayClass14_.id);
					_ = crmInternalMessageGroup.CrmInternalMessageDetails.Count;
					if (crmInternalMessageGroup.CrmInternalMessageDetails.Count > 0)
					{
						text = "-1";
					}
					break;
				}
				case "actDefinewdblkpcmbDefaultBodyTextGroups":
					_dbTbl.SmsDefaultBodyTextGroups.Find(_003C_003Ec__DisplayClass14_.id);
					break;
				case "actDefineCostGroups":
					_dbTbl.WSProductCostGroup.Find(_003C_003Ec__DisplayClass14_.id);
					break;
				case "actDefinePriceGroups":
					_dbTbl.WSProductPriceGroup.Find(_003C_003Ec__DisplayClass14_.id);
					break;
				case "actpordPreOrderOpr":
				case "actDefinePreOrderOpr":
					_dbTbl.WSPreOrderOpr.Find(_003C_003Ec__DisplayClass14_.id);
					break;
				case "actDefineGuaranty":
				case "actGuaranty":
				{
					WSGuaranty wSGuaranty = _dbTbl.WSGuaranty.Find(_003C_003Ec__DisplayClass14_.id);
					if (wSGuaranty != null && (wSGuaranty.WSPreOrder.Count > 0 || wSGuaranty.WSOrder.Count > 0 || wSGuaranty.WSOrderDefaultSetting.Count > 0 || wSGuaranty.WSPreOrderDefaultSetting.Count > 0))
					{
						text = "-1";
					}
					break;
				}
				case "actpordDeliveryTime":
				case "actDefineDeliveryTime":
				{
					WSDeliveryTime wSDeliveryTime = _dbTbl.WSDeliveryTime.Find(_003C_003Ec__DisplayClass14_.id);
					if (wSDeliveryTime != null && (wSDeliveryTime.WSPreOrder.Count > 0 || wSDeliveryTime.WSPreOrderDefaultSetting.Count > 0))
					{
						text = "-1";
					}
					break;
				}
				case "actpordPayCondition":
				case "actDefinePayCondition":
				{
					WSPayCondition wSPayCondition = _dbTbl.WSPayCondition.Find(_003C_003Ec__DisplayClass14_.id);
					if (wSPayCondition != null && (wSPayCondition.WSPreOrder.Count > 0 || wSPayCondition.WSPreOrderDefaultSetting.Count > 0))
					{
						text = "-1";
					}
					break;
				}
				case "actpordCreditDuration":
				case "actDefineCreditDuration":
				{
					WSCreditDuration wSCreditDuration = _dbTbl.WSCreditDuration.Find(_003C_003Ec__DisplayClass14_.id);
					if (wSCreditDuration != null && (wSCreditDuration.WSPreOrder.Count > 0 || wSCreditDuration.WSPreOrderDefaultSetting.Count > 0))
					{
						text = "-1";
					}
					break;
				}
				case "actpordDefinePreOrderStatus":
				{
					WSPreOrderStatus wSPreOrderStatus = _dbTbl.WSPreOrderStatus.Find(_003C_003Ec__DisplayClass14_.id);
					if (wSPreOrderStatus != null && wSPreOrderStatus.WSPreOrder.Count > 0)
					{
						text = "-1";
					}
					break;
				}
				case "PordPay1":
				{
					WSOrderPaymentTypes wSOrderPaymentTypes = _dbTbl.WSOrderPaymentTypes.Find(_003C_003Ec__DisplayClass14_.id);
					if (wSOrderPaymentTypes != null && (wSOrderPaymentTypes.WSOrderPayments.Count > 0 || wSOrderPaymentTypes.WSPreOrderPayments.Count > 0))
					{
						text = "-1";
					}
					break;
				}
				case "BordPay1":
				{
					WSBuyOrderPaymentTypes wSBuyOrderPaymentTypes = _dbTbl.WSBuyOrderPaymentTypes.Find(_003C_003Ec__DisplayClass14_.id);
					if (wSBuyOrderPaymentTypes != null && (wSBuyOrderPaymentTypes.WSBuyOrderPayments.Count > 0 || wSBuyOrderPaymentTypes.WSBuyOrderPayments.Count > 0))
					{
						text = "-1";
					}
					break;
				}
				case "actDefineSettlementType":
				case "actordDefineSettlementType":
					if (_dbTbl.WSSettlementType.Find(_003C_003Ec__DisplayClass14_.id) == null)
					{
					}
					break;
				case "actDefinePrjGroupsMulti":
					if (_dbTbl.CrmProjectGroupsMulti.Find(_003C_003Ec__DisplayClass14_.id) == null)
					{
					}
					break;
				case "actDefinePrjGroupsMultiI":
					if (_dbTbl.CrmProjectGroupsMultiI.Find(_003C_003Ec__DisplayClass14_.id) == null)
					{
					}
					break;
				case "actDefineReasonGroup":
				{
					DbSet<WSPreOrderPrdGroupMustExistReasonGroups> wSPreOrderPrdGroupMustExistReasonGroups = _dbTbl.WSPreOrderPrdGroupMustExistReasonGroups;
					ParameterExpression val = Expression.Parameter(typeof(WSPreOrderPrdGroupMustExistReasonGroups), "c");
					WSPreOrderPrdGroupMustExistReasonGroups wSPreOrderPrdGroupMustExistReasonGroups2 = Queryable.FirstOrDefault<WSPreOrderPrdGroupMustExistReasonGroups>((IQueryable<WSPreOrderPrdGroupMustExistReasonGroups>)wSPreOrderPrdGroupMustExistReasonGroups, Expression.Lambda<Func<WSPreOrderPrdGroupMustExistReasonGroups, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass14_, typeof(_003C_003Ec__DisplayClass14_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
					if (wSPreOrderPrdGroupMustExistReasonGroups2 != null && wSPreOrderPrdGroupMustExistReasonGroups2.WSPreOrderPrdGroupMustExistReasons.Count > 0)
					{
						text = "-1";
					}
					break;
				}
				case "actDefinePayType":
				{
					WSOrderCommissionPayTypes wSOrderCommissionPayTypes = _dbTbl.WSOrderCommissionPayTypes.Find(_003C_003Ec__DisplayClass14_.id);
					if (wSOrderCommissionPayTypes != null && wSOrderCommissionPayTypes.WSOrderCommissions.Count > 0)
					{
						text = "-1";
					}
					break;
				}
				case "actDefineDyFieldGroup":
				{
					WSCostSheetDyFieldGroups wSCostSheetDyFieldGroups = _dbTbl.WSCostSheetDyFieldGroups.Find(_003C_003Ec__DisplayClass14_.id);
					if (wSCostSheetDyFieldGroups != null && wSCostSheetDyFieldGroups.WSCostSheetDyFieldTitle.Count > 0)
					{
						text = "-1";
					}
					break;
				}
				case "actDefineUserGroups":
					_dbTbl.UserGroups.Find(_003C_003Ec__DisplayClass14_.id);
					break;
				case "actDefineDeliveryTerm":
				{
					WSDeliveryTerms wSDeliveryTerms = _dbTbl.WSDeliveryTerms.Find(_003C_003Ec__DisplayClass14_.id);
					if (wSDeliveryTerms != null && (wSDeliveryTerms.WSPreOrder.Count > 0 || wSDeliveryTerms.WSOrder.Count > 0 || wSDeliveryTerms.WSPreOrderItems.Count > 0 || wSDeliveryTerms.WSOrderItems.Count > 0))
					{
						text = "-1";
					}
					break;
				}
				case "actpordDefinePreOrderType":
				{
					WSPreOrderTypes wSPreOrderTypes = _dbTbl.WSPreOrderTypes.Find(_003C_003Ec__DisplayClass14_.id);
					if (wSPreOrderTypes != null && (wSPreOrderTypes.WSPreOrder.Count > 0 || wSPreOrderTypes.WSPreOrderDefaultSetting.Count > 0))
					{
						text = "-1";
					}
					break;
				}
				case "actDefineSaleCenter":
				{
					WSSaleCenters wSSaleCenters = _dbTbl.WSSaleCenters.Find(_003C_003Ec__DisplayClass14_.id);
					if (wSSaleCenters != null && (wSSaleCenters.WSOrder.Count > 0 || wSSaleCenters.WSOrderDefaultSetting.Count > 0))
					{
						text = "-1";
					}
					break;
				}
				case "actDefineSaleArea":
				{
					WSSaleAreas wSSaleAreas = _dbTbl.WSSaleAreas.Find(_003C_003Ec__DisplayClass14_.id);
					if (wSSaleAreas != null && (wSSaleAreas.WSOrder.Count > 0 || wSSaleAreas.WSOrderDefaultSetting.Count > 0 || wSSaleAreas.WSPreOrder.Count > 0 || wSSaleAreas.WSPreOrderDefaultSetting.Count > 0))
					{
						text = "-1";
					}
					break;
				}
				case "acthrDefineLeaveKind":
				{
					CrmLeaveKinds crmLeaveKinds = _dbTbl.CrmLeaveKinds.Find(_003C_003Ec__DisplayClass14_.id);
					if (crmLeaveKinds != null && crmLeaveKinds.CrmLeave.Count > 0)
					{
						text = "-1";
					}
					break;
				}
				case "acthrDefineLeaveStayType":
				{
					CrmLeaveStayType crmLeaveStayType = _dbTbl.CrmLeaveStayType.Find(_003C_003Ec__DisplayClass14_.id);
					if (crmLeaveStayType != null && crmLeaveStayType.CrmLeave.Count > 0)
					{
						text = "-1";
					}
					break;
				}
				case "acthrDefineLeaveVehicleType":
				{
					CrmLeaveVehicleType crmLeaveVehicleType = _dbTbl.CrmLeaveVehicleType.Find(_003C_003Ec__DisplayClass14_.id);
					if (crmLeaveVehicleType != null && crmLeaveVehicleType.CrmLeave.Count > 0)
					{
						text = "-1";
					}
					break;
				}
				case "actPayRollDefineListGroup":
				{
					PayRollListGroups payRollListGroups = _dbTbl.PayRollListGroups.Find(_003C_003Ec__DisplayClass14_.id);
					if (payRollListGroups != null && payRollListGroups.PayRollList.Count > 0)
					{
						text = "-1";
					}
					break;
				}
				case "BankAccType":
				{
					CrmBankingAccountType crmBankingAccountType = _dbTbl.CrmBankingAccountType.Find(_003C_003Ec__DisplayClass14_.id);
					if (crmBankingAccountType != null && crmBankingAccountType.CrmBankingAccounts.Count > 0)
					{
						text = "-1";
					}
					break;
				}
				case "actordDefineOrderGroup":
					if (_dbTbl.WSOrderGroups.Find(_003C_003Ec__DisplayClass14_.id) == null)
					{
					}
					break;
				case "actDefineCash":
				{
					CrmCashes crmCashes = _dbTbl.CrmCashes.Find(_003C_003Ec__DisplayClass14_.id);
					if (crmCashes != null && (crmCashes.WSOrderPaymentTypes.Count > 0 || crmCashes.WSOrderPayments.Count > 0 || crmCashes.WSPreOrderPayments.Count > 0))
					{
						text = "-1";
					}
					break;
				}
				case "actDefinePayGroupI":
				{
					WSOrderPaymentGroupsI wSOrderPaymentGroupsI = _dbTbl.WSOrderPaymentGroupsI.Find(_003C_003Ec__DisplayClass14_.id);
					if (wSOrderPaymentGroupsI != null && (wSOrderPaymentGroupsI.WSOrderPaymentTypes.Count > 0 || wSOrderPaymentGroupsI.WSOrderPayments.Count > 0 || wSOrderPaymentGroupsI.WSPreOrderPayments.Count > 0))
					{
						text = "-1";
					}
					break;
				}
				case "actDefinePayGroupII":
				{
					WSOrderPaymentGroupsII wSOrderPaymentGroupsII = _dbTbl.WSOrderPaymentGroupsII.Find(_003C_003Ec__DisplayClass14_.id);
					if (wSOrderPaymentGroupsII != null && (wSOrderPaymentGroupsII.WSOrderPaymentTypes.Count > 0 || wSOrderPaymentGroupsII.WSOrderPayments.Count > 0 || wSOrderPaymentGroupsII.WSPreOrderPayments.Count > 0))
					{
						text = "-1";
					}
					break;
				}
				}
				if (text != "-1")
				{
					try
					{
						string text2 = "";
						text2 = (formbaseInfo.isLanguage ? ("exec " + formbaseInfo.NameTabel_Delete + " " + _003C_003Ec__DisplayClass14_.id) : ("DELETE FROM " + formbaseInfo.NameTabel + " WHERE " + formbaseInfo.NamefieldID + " = " + _003C_003Ec__DisplayClass14_.id));
						if (db.Database.ExecuteSqlCommand(text2) != 0)
						{
							text2 = "select * FROM " + formbaseInfo.NameTabel + " WHERE " + formbaseInfo.NamefieldID + " = " + _003C_003Ec__DisplayClass14_.id;
							SqlConnection val2 = new SqlConnection(db.Database.Connection.ConnectionString);
							SqlCommand val3 = new SqlCommand();
							new DataTable();
							val3.Connection = val2;
							((DbCommand)val3).CommandText = text2;
							((DbConnection)val2).Open();
							if (!((DbDataReader)val3.ExecuteReader()).HasRows)
							{
								CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo(formbaseInfo.NameTabel);
								text = Messages.frmDeleteSuccessMessage;
							}
							else
							{
								text += "-1";
							}
							((DbConnection)val2).Close();
							((Component)val2).Dispose();
						}
						else
						{
							text += "-1";
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						text += "-1";
					}
				}
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			text += "-1";
		}
		return text;
	}

	public ActionResult _PartialFormBaseInfo(int id, string kind, string TypeAction, string FormName)
	{
		FormFullBaseInfoViewModel formFullBaseInfoViewModel = new FormFullBaseInfoViewModel();
		formFullBaseInfoViewModel = GetFormBaseInfo(id, kind, TypeAction, FormName);
		if (formFullBaseInfoViewModel == null)
		{
			formFullBaseInfoViewModel = new FormFullBaseInfoViewModel();
			formFullBaseInfoViewModel.ItemId = 0;
			formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			formFullBaseInfoViewModel.ItemTitleVisibale = "hidden";
			formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
			formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
			formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			base.ViewBag.Visibale = "visible visible hidden hidden hidden";
		}
		return PartialView(formFullBaseInfoViewModel);
	}

	public FormFullBaseInfoViewModel GetFormBaseInfo(int id, string kind, string TypeAction, string FormName)
	{
		new FormFullBaseInfoViewModel();
		FormFullBaseInfoViewModel formFullBaseInfoViewModel = new FormFullBaseInfoViewModel();
		formFullBaseInfoViewModel = FullForm(TypeAction);
		return RecordFind(id, kind, FormName, formFullBaseInfoViewModel);
	}

	public FormFullBaseInfoViewModel RecordFind(int id, string kind, string FormName, FormFullBaseInfoViewModel formbaseInfo)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Expected O, but got Unknown
		//IL_022a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Expected O, but got Unknown
		//IL_02b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bf: Expected O, but got Unknown
		//IL_043a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0441: Expected O, but got Unknown
		string connectionString = db.Database.Connection.ConnectionString;
		FormFullBaseInfoViewModel formFullBaseInfoViewModel = new FormFullBaseInfoViewModel();
		SqlConnection val = new SqlConnection(connectionString);
		SqlCommand val2 = new SqlCommand();
		DataTable val3 = new DataTable();
		val2.Connection = val;
		string commandText = "";
		SqlDataReader val6;
		if (id == 0)
		{
			commandText = string.Format("select top 1 * from " + formbaseInfo.NameTabel + " order by " + formbaseInfo.NamefieldID + " desc");
		}
		else
		{
			switch (kind)
			{
			case "next":
				if (UserLogin.IsUserAccess(FormName, "actNext", UserLogin.CurrentUser))
				{
					commandText = string.Format("select top 1 * from " + formbaseInfo.NameTabel + " where " + formbaseInfo.NamefieldID + ">" + id);
					DataTable val9 = new DataTable();
					((DbCommand)val2).CommandText = commandText;
					((DbConnection)val).Open();
					val6 = val2.ExecuteReader();
					if (((DbDataReader)val6).HasRows)
					{
						val9.Load((IDataReader)(object)val6);
					}
					else
					{
						commandText = string.Format("select top 1 * from " + formbaseInfo.NameTabel + " order by " + formbaseInfo.NamefieldID + " desc");
					}
					((DbConnection)val).Close();
					((DbDataReader)val6).Close();
				}
				break;
			case "prev":
				if (UserLogin.IsUserAccess(FormName, "actPrior", UserLogin.CurrentUser))
				{
					commandText = string.Format("select top 1 * from " + formbaseInfo.NameTabel + " where " + formbaseInfo.NamefieldID + "<" + id + " order by " + formbaseInfo.NamefieldID + " desc");
					DataTable val7 = new DataTable();
					((DbCommand)val2).CommandText = commandText;
					((DbConnection)val).Open();
					val6 = val2.ExecuteReader();
					if (((DbDataReader)val6).HasRows)
					{
						val7.Load((IDataReader)(object)val6);
					}
					else
					{
						commandText = string.Format("select top 1 * from " + formbaseInfo.NameTabel);
					}
					((DbConnection)val).Close();
					((DbDataReader)val6).Close();
				}
				break;
			case "first":
				if (UserLogin.IsUserAccess(FormName, "actFirst", UserLogin.CurrentUser))
				{
					commandText = string.Format("select top 1 * from " + formbaseInfo.NameTabel);
					DataTable val8 = new DataTable();
					((DbCommand)val2).CommandText = commandText;
					((DbConnection)val).Open();
					val6 = val2.ExecuteReader();
					if (((DbDataReader)val6).HasRows)
					{
						val8.Load((IDataReader)(object)val6);
					}
					((DbConnection)val).Close();
					((DbDataReader)val6).Close();
					commandText = ((id != int.Parse(val8.Rows[0][formbaseInfo.NamefieldID].ToString())) ? string.Format("select top 1 * from " + formbaseInfo.NameTabel + " where " + formbaseInfo.NamefieldID + "<" + id) : string.Format("select top 1 * from " + formbaseInfo.NameTabel));
				}
				break;
			case "last":
				if (UserLogin.IsUserAccess(FormName, "actLast", UserLogin.CurrentUser))
				{
					DbSet<Country> country = _dbTbl.Country;
					ParameterExpression val4 = Expression.Parameter(typeof(Country), "c");
					Queryable.First<Country>(Queryable.Take<Country>((IQueryable<Country>)(object)Queryable.OrderByDescending<Country, int>((IQueryable<Country>)country, Expression.Lambda<Func<Country, int>>((Expression)(object)Expression.Property((Expression)(object)val4, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (ParameterExpression[])(object)new ParameterExpression[1] { val4 })), 1));
					commandText = string.Format("select top 1 * from " + formbaseInfo.NameTabel + " order by " + formbaseInfo.NamefieldID + " desc");
					DataTable val5 = new DataTable();
					((DbCommand)val2).CommandText = commandText;
					((DbConnection)val).Open();
					val6 = val2.ExecuteReader();
					if (((DbDataReader)val6).HasRows)
					{
						val5.Load((IDataReader)(object)val6);
					}
					((DbConnection)val).Close();
					((DbDataReader)val6).Close();
					commandText = ((id != int.Parse(val5.Rows[0][formbaseInfo.NamefieldID].ToString())) ? string.Format("select top 1 * from " + formbaseInfo.NameTabel + " where " + formbaseInfo.NamefieldID + ">" + id + " order by " + formbaseInfo.NamefieldID + " desc") : string.Format("select top 1 * from " + formbaseInfo.NameTabel + " order by " + formbaseInfo.NamefieldID + " desc"));
				}
				break;
			default:
				commandText = string.Format("select * from " + formbaseInfo.NameTabel + " where " + formbaseInfo.NamefieldID + "=" + id);
				break;
			}
		}
		((DbCommand)val2).CommandText = commandText;
		((DbConnection)val).Open();
		val6 = val2.ExecuteReader();
		if (((DbDataReader)val6).HasRows)
		{
			val3.Load((IDataReader)(object)val6);
		}
		((DbConnection)val).Close();
		((DbDataReader)val6).Close();
		if (val3 != null)
		{
			formFullBaseInfoViewModel.ItemId = int.Parse(val3.Rows[0][formbaseInfo.NamefieldID].ToString());
			if (formbaseInfo.TypeAccess == "frmDefineCountry")
			{
				formFullBaseInfoViewModel.ItemCountryCode = ((val3.Rows[0]["CountryCode"] == null || val3.Rows[0]["CountryCode"].ToString() == "") ? "" : val3.Rows[0]["CountryCode"].ToString());
				formFullBaseInfoViewModel.ItemCountryCodeVisibale = "visible";
			}
			else
			{
				formFullBaseInfoViewModel.ItemCountryCode = "";
				formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
			}
			formFullBaseInfoViewModel.ItemTitle = ((val3.Rows[0][formbaseInfo.NamefieldI] == null || val3.Rows[0][formbaseInfo.NamefieldI].ToString() == "") ? "" : val3.Rows[0][formbaseInfo.NamefieldI].ToString());
			formFullBaseInfoViewModel.ItemTitleVisibale = formbaseInfo.ItemTitleVisibale;
			if (formbaseInfo.ItemDescVisibale == "hidden")
			{
				formFullBaseInfoViewModel.ItemDesc = "";
			}
			else
			{
				formFullBaseInfoViewModel.ItemDesc = ((val3.Rows[0][formbaseInfo.NamefieldII] == null || val3.Rows[0][formbaseInfo.NamefieldII].ToString() == "") ? "" : val3.Rows[0][formbaseInfo.NamefieldII].ToString());
			}
			if (formbaseInfo.ItemOrderVisibale == "hidden")
			{
				formFullBaseInfoViewModel.ItemOrder = "";
			}
			else
			{
				formFullBaseInfoViewModel.ItemOrder = ((val3.Rows[0][formbaseInfo.NamefieldIV] == null || val3.Rows[0][formbaseInfo.NamefieldIV].ToString() == "") ? "" : val3.Rows[0][formbaseInfo.NamefieldIV].ToString());
			}
			formFullBaseInfoViewModel.ItemOrderVisibale = formbaseInfo.ItemOrderVisibale;
			formFullBaseInfoViewModel.ItemDescVisibale = formbaseInfo.ItemDescVisibale;
		}
		return formFullBaseInfoViewModel;
	}

	public ActionResult _PartialFrmFormBase(string TypeAction)
	{
		base.ViewBag.TypeAction = TypeAction;
		switch (TypeAction)
		{
		case "actDefineCountry":
			base.ViewBag.Visibale = "visible visible hidden hidden hidden hidden hidden";
			break;
		case "actDefinecmpType":
		case "actDefinePrsJobs":
		case "actDefineprsJobs":
		case "actDefineprsType":
		case "actDefinePayType":
		case "actUTDefineGroup":
		case "actDefineSaleArea":
		case "actDefinecmpTitle":
		case "actDefineprsTitle":
		case "actDefineprsGroup":
		case "actDefineFileType":
		case "actDefineGuaranty":
		case "actDefinePrsTitle":
		case "actDefinePrjGroup":
		case "actDefinePrjGrade":
		case "actDefinecmpPresentation":
		case "acthrDefineLeaveStayType":
		case "actpordDeliveryTime":
		case "actpordPayCondition":
		case "actDefineUserGroups":
		case "actDefineCmpAddType":
		case "actDefineCostGroups":
		case "actDefineSaleCenter":
		case "actDefinePrsDepartment":
		case "actordDefineOrderGroup":
		case "actDefineprsDepartment":
		case "actpordPreOrderOpr":
		case "actDefineprsGroups":
		case "actDefineEducation":
		case "actDefineKnowledgeTankGroup":
		case "acthrDefineLeaveVehicleType":
		case "actpordDefinePreOrderStatus":
		case "actluDepartment":
		case "actDefinecmpFileType":
		case "actDefinePriceGroups":
		case "actDefinePreOrderOpr":
		case "acthrDefineLeaveKind":
		case "BankAccType":
		case "PayRollPay1":
		case "actGuaranty":
		case "actDefineDeliveryTime":
		case "actDefinePayCondition":
		case "actDefineDyFieldGroup":
		case "BordPay1":
		case "actDefineSettlementType":
		case "actpordDefinePreOrderType":
		case "actDefineKnowledgeTankPriority":
		case "actDefineInternalMessagePriority":
		case "actDefineSex":
		case "actDefinewdblkpcmbDefaultBodyTextGroups":
		case "actordDefineSettlementType":
			base.ViewBag.Visibale = "hidden visible hidden hidden hidden hidden hidden hidden hidden hidden hidden hidden hidden hidden hidden";
			break;
		case "actDefineInternalMessageGroup":
			base.ViewBag.Visibale = "hidden visible hidden visible hidden hidden hidden hidden hidden hidden hidden hidden hidden hidden hidden";
			break;
		case "PordPay1":
			base.ViewBag.Visibale = "hidden visible hidden visible hidden hidden visible hidden hidden hidden hidden hidden hidden hidden hidden";
			break;
		case "actPayRollDefineListGroup":
			base.ViewBag.Visibale = "hidden visible hidden visible hidden hidden hidden hidden hidden hidden hidden hidden hidden hidden hidden";
			break;
		case "actDefineReasonGroup":
			base.ViewBag.Visibale = "hidden visible hidden hidden visible hidden hidden hidden hidden hidden hidden hidden hidden hidden hidden";
			break;
		case "actDefinePrjGroupsMulti":
			base.ViewBag.Visibale = "hidden visible visible visible hidden hidden hidden hidden hidden hidden hidden hidden hidden hidden hidden";
			break;
		case "actDefinePrjGroupsMultiI":
			base.ViewBag.Visibale = "hidden visible visible visible visible hidden hidden hidden hidden hidden hidden hidden hidden hidden hidden";
			break;
		case "actpordCreditDuration":
		case "actDefineCreditDuration":
			base.ViewBag.Visibale = "hidden visible visible hidden hidden visible hidden hidden hidden hidden hidden hidden hidden hidden hidden";
			break;
		case "actDefinecmpGroupsII":
			base.ViewBag.Visibale = "hidden visible visible hidden hidden visible hidden hidden hidden visible hidden hidden hidden hidden hidden";
			break;
		case "actDefinecmpGroups":
		case "actDefinecmpGroupsIV":
		case "actDefinecmpGroupsIII":
			base.ViewBag.Visibale = "hidden visible visible hidden hidden hidden hidden hidden hidden visible hidden hidden hidden hidden hidden";
			break;
		case "actDefineGroups":
		case "actDefinecmpGroupsMulti":
		case "actDefinecnvsStatusGroups":
			base.ViewBag.Visibale = "hidden visible visible hidden hidden hidden hidden hidden hidden hidden hidden hidden hidden hidden hidden";
			break;
		case "actDefinecnvsTopics":
		case "actDefineTopic":
			base.ViewBag.Visibale = "hidden visible visible hidden hidden hidden hidden visible visible hidden hidden hidden hidden hidden hidden";
			break;
		case "actDefineDeliveryTerm":
			base.ViewBag.Visibale = "hidden visible hidden hidden hidden hidden hidden hidden hidden hidden hidden visible visible hidden visible";
			break;
		case "actDefinePayGroupII":
		case "actDefinePayGroupI":
		case "actDefineCash":
			base.ViewBag.Visibale = "hidden visible hidden hidden hidden hidden hidden hidden hidden hidden hidden hidden hidden visible hidden";
			break;
		default:
			base.ViewBag.Visibale = "visible visible visible hidden hidden hidden hidden hidden hidden hidden hidden hidden hidden hidden hidden";
			break;
		}
		bool flag = false;
		try
		{
			FormFullBaseInfoViewModel formFullBaseInfoViewModel = new FormFullBaseInfoViewModel();
			formFullBaseInfoViewModel = FullForm(TypeAction);
			if (formFullBaseInfoViewModel != null)
			{
				string typeAction = formFullBaseInfoViewModel.TypeAction;
				flag = ((typeAction == "actDefinecnvsTopics" || typeAction == "actDefineTopic") ? true : false);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ShowFoBox = flag;
		return PartialView();
	}

	public ActionResult _PartialFrmFormBase_Read([DataSourceRequest] DataSourceRequest request, string typeAction)
	{
		List<FormFullBaseInfoViewModel> list = new List<FormFullBaseInfoViewModel>();
		FormFullBaseInfoViewModel formFullBaseInfoViewModel = new FormFullBaseInfoViewModel();
		formFullBaseInfoViewModel = FullForm(typeAction);
		list = RecordList(formFullBaseInfoViewModel);
		return Json(((IEnumerable)list).ToDataSourceResult(request));
	}

	public List<FormFullBaseInfoViewModel> RecordList(FormFullBaseInfoViewModel formbaseInfo)
	{
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Expected O, but got Unknown
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Expected O, but got Unknown
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<FormFullBaseInfoViewModel> list = new List<FormFullBaseInfoViewModel>();
		try
		{
			string connectionString = db.Database.Connection.ConnectionString;
			if (formbaseInfo != null)
			{
				DbSet<Country> country = _dbTbl.Country;
				ParameterExpression val = Expression.Parameter(typeof(Country), "c");
				Enumerable.ToList<Country>((IEnumerable<Country>)Queryable.OrderByDescending<Country, int>((IQueryable<Country>)country, Expression.Lambda<Func<Country, int>>((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
				SqlConnection val2 = new SqlConnection(connectionString);
				SqlCommand val3 = new SqlCommand();
				DataTable val4 = new DataTable();
				val3.Connection = val2;
				string text = "";
				text = ((!formbaseInfo.isLanguage) ? string.Format("select * from " + formbaseInfo.NameTabel + " order by " + formbaseInfo.NamefieldID) : ((!string.IsNullOrEmpty(formbaseInfo.Parametes)) ? ("exec " + formbaseInfo.NameTabel_Lang + " " + formbaseInfo.Parametes) : string.Format("exec " + formbaseInfo.NameTabel_Lang + " {0},{1}", lCID, result)));
				((DbCommand)val3).CommandText = text;
				((DbConnection)val2).Open();
				SqlDataReader val5 = val3.ExecuteReader();
				if (((DbDataReader)val5).HasRows)
				{
					val4.Load((IDataReader)(object)val5);
				}
				((DbConnection)val2).Close();
				((DbDataReader)val5).Close();
				if (val4 != null)
				{
					for (int i = 0; i < ((InternalDataCollectionBase)val4.Rows).Count; i++)
					{
						FormFullBaseInfoViewModel formFullBaseInfoViewModel = new FormFullBaseInfoViewModel();
						formFullBaseInfoViewModel.ItemId = int.Parse(val4.Rows[i][formbaseInfo.NamefieldID].ToString());
						if (formFullBaseInfoViewModel.ItemId < 0)
						{
							continue;
						}
						formFullBaseInfoViewModel.ItemTitle = ((val4.Rows[i][formbaseInfo.NamefieldI] == null || val4.Rows[i][formbaseInfo.NamefieldI].ToString() == "") ? "" : val4.Rows[i][formbaseInfo.NamefieldI].ToString());
						formFullBaseInfoViewModel.ItemTitleVisibale = formbaseInfo.ItemTitleVisibale;
						if (formbaseInfo.ItemDescVisibale == "hidden")
						{
							formFullBaseInfoViewModel.ItemDesc = "";
						}
						else
						{
							formFullBaseInfoViewModel.ItemDesc = ((val4.Rows[i][formbaseInfo.NamefieldII] == null || val4.Rows[i][formbaseInfo.NamefieldII].ToString() == "") ? "" : val4.Rows[i][formbaseInfo.NamefieldII].ToString());
						}
						formFullBaseInfoViewModel.ItemDescVisibale = formbaseInfo.ItemDescVisibale;
						if (formbaseInfo.ItemCodeVisibale == "hidden")
						{
							formFullBaseInfoViewModel.ItemCode = "";
						}
						else
						{
							formFullBaseInfoViewModel.ItemCode = ((val4.Rows[i][formbaseInfo.NamefieldCode] == null || val4.Rows[i][formbaseInfo.NamefieldCode].ToString() == "") ? "" : val4.Rows[i][formbaseInfo.NamefieldCode].ToString());
						}
						if (formbaseInfo.ItemOrderVisibale == "hidden")
						{
							formFullBaseInfoViewModel.ItemOrder = null;
						}
						else
						{
							formFullBaseInfoViewModel.ItemOrder = ((val4.Rows[i][formbaseInfo.NamefieldIV] == null || val4.Rows[i][formbaseInfo.NamefieldIV].ToString() == "") ? null : val4.Rows[i][formbaseInfo.NamefieldIV].ToString());
						}
						formFullBaseInfoViewModel.ItemOrderVisibale = formbaseInfo.ItemOrderVisibale;
						if (formbaseInfo.ItemDefaultVisibale == "hidden")
						{
							formFullBaseInfoViewModel.ItemDefault = null;
						}
						else
						{
							bool.TryParse(val4.Rows[i][formbaseInfo.NamefieldVI].ToString(), out var result2);
							formFullBaseInfoViewModel.ItemDefault = result2;
						}
						formFullBaseInfoViewModel.ItemDefaultVisibale = formbaseInfo.ItemDefaultVisibale;
						if (formbaseInfo.ItemRateVisibale == "hidden")
						{
							formFullBaseInfoViewModel.ItemRate = null;
						}
						else
						{
							string? text2 = val4.Rows[i][formbaseInfo.NamefieldVII].ToString();
							double.TryParse(text2, out var result3);
							if (!string.IsNullOrWhiteSpace(text2))
							{
								formFullBaseInfoViewModel.ItemRate = result3;
							}
						}
						formFullBaseInfoViewModel.ItemRateVisibale = formbaseInfo.ItemRateVisibale;
						if (formbaseInfo.ItemDeActiveVisibale == "hidden")
						{
							formFullBaseInfoViewModel.ItemDeActive = null;
						}
						else
						{
							string? value = val4.Rows[i][formbaseInfo.NamefieldVIII].ToString();
							bool result4 = false;
							bool.TryParse(value, out result4);
							formFullBaseInfoViewModel.ItemDeActive = result4;
						}
						formFullBaseInfoViewModel.ItemDeActiveVisibale = formbaseInfo.ItemDeActiveVisibale;
						if (formbaseInfo.CheckUserDistanceCmpVisible == "hidden")
						{
							formFullBaseInfoViewModel.CheckUserDistanceCmp = null;
						}
						else
						{
							string? value2 = val4.Rows[i][formbaseInfo.NamefieldIX].ToString();
							bool result5 = false;
							bool.TryParse(value2, out result5);
							formFullBaseInfoViewModel.CheckUserDistanceCmp = result5;
						}
						formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = formbaseInfo.CheckUserDistanceCmpVisible;
						if (formbaseInfo.UserDistanceCmpValVisible == "hidden")
						{
							formFullBaseInfoViewModel.UserDistanceCmpVal = null;
						}
						else
						{
							double.TryParse(val4.Rows[i][formbaseInfo.NamefieldX].ToString(), out var result6);
							formFullBaseInfoViewModel.UserDistanceCmpVal = result6;
						}
						formFullBaseInfoViewModel.UserDistanceCmpValVisible = formbaseInfo.UserDistanceCmpValVisible;
						if (formbaseInfo.ItemScoreRateVisibale == "hidden")
						{
							formFullBaseInfoViewModel.ItemScoreRate = null;
						}
						else
						{
							string? text3 = val4.Rows[i][formbaseInfo.NamefieldScoreRate].ToString();
							double.TryParse(text3, out var result7);
							if (!string.IsNullOrWhiteSpace(text3))
							{
								formFullBaseInfoViewModel.ItemScoreRate = result7;
							}
						}
						formFullBaseInfoViewModel.ItemScoreRateVisibale = formbaseInfo.ItemScoreRateVisibale;
						string text4 = val4.Rows[i]["AppType"].ToString();
						if (string.IsNullOrEmpty(text4))
						{
							text4 = Configuration.AppType;
						}
						formFullBaseInfoViewModel.AppType = Configuration.GetAppType(text4);
						int.Parse(val4.Rows[i]["FirstRegisterUserId"].ToString());
						string text5 = "";
						try
						{
							text5 = val4.Rows[i]["FirstRegisterUser"].ToString();
						}
						catch (Exception e)
						{
							ErrorSignal.FromCurrentContext().Raise(e);
						}
						string text6 = DateTime.Parse(val4.Rows[i]["FirstRegisterDate"].ToString()).ToString("yyyy/MM/dd HH:mm:ss");
						formFullBaseInfoViewModel.FirstRegisterDatePersian = text5 + " (" + text6 + ")";
						int.Parse(val4.Rows[i]["UserId"].ToString());
						string text7 = "";
						try
						{
							text7 = val4.Rows[i]["EditUser"].ToString();
						}
						catch (Exception e2)
						{
							ErrorSignal.FromCurrentContext().Raise(e2);
						}
						string text8 = DateTime.Parse(val4.Rows[i]["RegisterDate"].ToString()).ToString("yyyy/MM/dd HH:mm:ss");
						formFullBaseInfoViewModel.RegisterDatePersian = text7 + " (" + Labels.AppType + ":" + formFullBaseInfoViewModel.AppType + ")  (" + text8 + ")";
						bool result8 = false;
						try
						{
							DataColumnCollection columns = val4.Columns;
							if (columns != null && columns.Contains("FODefault") && !string.IsNullOrEmpty(val4.Rows[i]["FODefault"].ToString()))
							{
								result8 = bool.Parse(val4.Rows[i]["FODefault"].ToString());
							}
						}
						catch (Exception e3)
						{
							ErrorSignal.FromCurrentContext().Raise(e3);
						}
						if (formbaseInfo.FODefaultVisible == "visible")
						{
							bool.TryParse(val4.Rows[i][formbaseInfo.NamefieldFODefault].ToString(), out result8);
						}
						formFullBaseInfoViewModel.FODefault = result8;
						bool result9 = false;
						if (formbaseInfo.SHPDefaultVisible == "visible")
						{
							bool.TryParse(val4.Rows[i][formbaseInfo.NamefieldSHPDefault].ToString(), out result9);
						}
						formFullBaseInfoViewModel.SHPDefault = result9;
						bool result10 = false;
						if (formbaseInfo.SHPVisible_Visible == "visible")
						{
							bool.TryParse(val4.Rows[i][formbaseInfo.NamefieldSHPVisible].ToString(), out result10);
						}
						formFullBaseInfoViewModel.SHPVisible = result10;
						bool result11 = false;
						if (formbaseInfo.SHPNeedAddressVisible == "visible")
						{
							bool.TryParse(val4.Rows[i][formbaseInfo.NamefieldSHPNeedAddress].ToString(), out result11);
						}
						formFullBaseInfoViewModel.SHPNeedAddress = result11;
						list.Add(formFullBaseInfoViewModel);
					}
				}
			}
		}
		catch (Exception e4)
		{
			ErrorSignal.FromCurrentContext().Raise(e4);
		}
		return list;
	}

	public FormFullBaseInfoViewModel FindFormBaseInfo(int id, FormFullBaseInfoViewModel formbaseInfo)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected O, but got Unknown
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0d74: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d7a: Expected O, but got Unknown
		//IL_0d7a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d80: Expected O, but got Unknown
		//IL_0d80: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d87: Expected O, but got Unknown
		FormFullBaseInfoViewModel formFullBaseInfoViewModel = new FormFullBaseInfoViewModel();
		try
		{
			string connectionString = db.Database.Connection.ConnectionString;
			SqlConnection val = new SqlConnection(connectionString);
			SqlCommand val2 = new SqlCommand();
			DataTable val3 = new DataTable();
			val2.Connection = val;
			string commandText = string.Format("select * from " + formbaseInfo.NameTabel + " where " + formbaseInfo.NamefieldID + "=" + id);
			((DbCommand)val2).CommandText = commandText;
			((DbConnection)val).Open();
			SqlDataReader val4 = val2.ExecuteReader();
			if (((DbDataReader)val4).HasRows)
			{
				val3.Load((IDataReader)(object)val4);
				if (val3 != null)
				{
					formFullBaseInfoViewModel.ItemId = int.Parse(val3.Rows[0][formbaseInfo.NamefieldID].ToString());
					if (formbaseInfo.TypeAccess == "frmDefineCountry")
					{
						formFullBaseInfoViewModel.ItemCountryCode = ((val3.Rows[0]["CountryCode"] == null || val3.Rows[0]["CountryCode"].ToString() == "") ? "" : val3.Rows[0]["CountryCode"].ToString());
						formFullBaseInfoViewModel.ItemCountryCodeVisibale = "visible";
					}
					else
					{
						formFullBaseInfoViewModel.ItemCountryCode = "";
						formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
					}
					formFullBaseInfoViewModel.ItemTitle = ((val3.Rows[0][formbaseInfo.NamefieldI] == null || val3.Rows[0][formbaseInfo.NamefieldI].ToString() == "") ? "" : val3.Rows[0][formbaseInfo.NamefieldI].ToString());
					formFullBaseInfoViewModel.ItemTitleVisibale = formbaseInfo.ItemTitleVisibale;
					if (formbaseInfo.ItemDescVisibale == "hidden")
					{
						formFullBaseInfoViewModel.ItemDesc = "";
					}
					else
					{
						formFullBaseInfoViewModel.ItemDesc = ((val3.Rows[0][formbaseInfo.NamefieldII] == null || val3.Rows[0][formbaseInfo.NamefieldII].ToString() == "") ? "" : val3.Rows[0][formbaseInfo.NamefieldII].ToString());
					}
					if (formbaseInfo.ItemOrderVisibale == "hidden")
					{
						formFullBaseInfoViewModel.ItemOrder = null;
					}
					else
					{
						formFullBaseInfoViewModel.ItemOrder = ((val3.Rows[0][formbaseInfo.NamefieldIV] == null || val3.Rows[0][formbaseInfo.NamefieldIV].ToString() == "") ? null : val3.Rows[0][formbaseInfo.NamefieldIV].ToString());
					}
					formFullBaseInfoViewModel.ItemOrderVisibale = formbaseInfo.ItemOrderVisibale;
					if (formbaseInfo.ItemDefaultVisibale == "hidden")
					{
						formFullBaseInfoViewModel.ItemDefault = null;
					}
					else
					{
						bool.TryParse(val3.Rows[0][formbaseInfo.NamefieldVI].ToString(), out var result);
						formFullBaseInfoViewModel.ItemDefault = result;
					}
					formFullBaseInfoViewModel.ItemDefaultVisibale = formbaseInfo.ItemDefaultVisibale;
					if (formbaseInfo.ItemRateVisibale == "hidden")
					{
						formFullBaseInfoViewModel.ItemRate = null;
					}
					else
					{
						string? text = val3.Rows[0][formbaseInfo.NamefieldVII].ToString();
						double.TryParse(text, out var result2);
						if (!string.IsNullOrWhiteSpace(text))
						{
							formFullBaseInfoViewModel.ItemRate = result2;
						}
					}
					formFullBaseInfoViewModel.ItemRateVisibale = formbaseInfo.ItemRateVisibale;
					if (formbaseInfo.ItemDeActiveVisibale == "hidden")
					{
						formFullBaseInfoViewModel.ItemDeActive = null;
					}
					else
					{
						string? value = val3.Rows[0][formbaseInfo.NamefieldVIII].ToString();
						bool result3 = false;
						bool.TryParse(value, out result3);
						formFullBaseInfoViewModel.ItemDeActive = result3;
					}
					formFullBaseInfoViewModel.ItemDeActiveVisibale = formbaseInfo.ItemDeActiveVisibale;
					if (formbaseInfo.ItemScoreRateVisibale == "hidden")
					{
						formFullBaseInfoViewModel.ItemScoreRate = null;
					}
					else
					{
						string? text2 = val3.Rows[0][formbaseInfo.NamefieldScoreRate].ToString();
						double.TryParse(text2, out var result4);
						if (!string.IsNullOrWhiteSpace(text2))
						{
							formFullBaseInfoViewModel.ItemScoreRate = result4;
						}
					}
					formFullBaseInfoViewModel.ItemScoreRateVisibale = formbaseInfo.ItemScoreRateVisibale;
					if (formbaseInfo.CheckUserDistanceCmpVisible == "hidden")
					{
						formFullBaseInfoViewModel.CheckUserDistanceCmp = null;
					}
					else
					{
						string? value2 = val3.Rows[0][formbaseInfo.NamefieldIX].ToString();
						bool result5 = false;
						bool.TryParse(value2, out result5);
						formFullBaseInfoViewModel.CheckUserDistanceCmp = result5;
					}
					formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = formbaseInfo.CheckUserDistanceCmpVisible;
					if (formbaseInfo.UserDistanceCmpValVisible == "hidden")
					{
						formFullBaseInfoViewModel.UserDistanceCmpVal = null;
					}
					else
					{
						double.TryParse(val3.Rows[0][formbaseInfo.NamefieldX].ToString(), out var result6);
						formFullBaseInfoViewModel.UserDistanceCmpVal = result6;
					}
					formFullBaseInfoViewModel.UserDistanceCmpValVisible = formbaseInfo.UserDistanceCmpValVisible;
					bool result7 = false;
					if (formbaseInfo.FODefaultVisible == "visible")
					{
						bool.TryParse(val3.Rows[0][formbaseInfo.NamefieldFODefault].ToString(), out result7);
					}
					formFullBaseInfoViewModel.FODefault = result7;
					bool result8 = false;
					if (formbaseInfo.SHPDefaultVisible == "visible")
					{
						bool.TryParse(val3.Rows[0][formbaseInfo.NamefieldSHPDefault].ToString(), out result8);
					}
					formFullBaseInfoViewModel.SHPDefault = result8;
					bool result9 = false;
					if (formbaseInfo.SHPVisible_Visible == "visible")
					{
						bool.TryParse(val3.Rows[0][formbaseInfo.NamefieldSHPVisible].ToString(), out result9);
					}
					formFullBaseInfoViewModel.SHPVisible = result9;
					if (formbaseInfo.ItemCodeVisibale == "hidden")
					{
						formFullBaseInfoViewModel.ItemCode = "";
					}
					else
					{
						formFullBaseInfoViewModel.ItemCode = ((val3.Rows[0][formbaseInfo.NamefieldCode] == null || val3.Rows[0][formbaseInfo.NamefieldCode].ToString() == "") ? "" : val3.Rows[0][formbaseInfo.NamefieldCode].ToString());
					}
					formFullBaseInfoViewModel.ItemCodeVisibale = formbaseInfo.ItemCodeVisibale;
					formFullBaseInfoViewModel.NamefieldCode = formbaseInfo.NamefieldCode;
					bool result10 = false;
					if (formbaseInfo.SHPNeedAddressVisible == "visible")
					{
						bool.TryParse(val3.Rows[0][formbaseInfo.NamefieldSHPNeedAddress].ToString(), out result10);
					}
					formFullBaseInfoViewModel.SHPNeedAddress = result10;
					formFullBaseInfoViewModel.UserId = int.Parse(val3.Rows[0]["UserId"].ToString());
					switch (formbaseInfo.NameTabel)
					{
					case "WSPreOrderOpr":
					case "WSOrderGroups":
					case "WSSaleCenters":
					case "WSDeliveryTime":
					case "WSPayCondition":
					case "WSCreditDuration":
					case "WSPreOrderStatus":
					case "WSBuyOrderPaymentTypes":
					case "WSOrderPaymentGroupsII":
					case "WSDeliveryTerms":
					case "WSPreOrderTypes":
					case "WSGuaranty":
					case "WSOrderPaymentTypes":
					case "WSPreOrderPrdGroupMustExistReasonGroups":
					case "WSCostSheetDyFieldGroups":
					case "WSSaleAreas":
					case "WSOrderPaymentGroupsI":
						formFullBaseInfoViewModel.Year1 = 0;
						break;
					default:
						formFullBaseInfoViewModel.Year1 = short.Parse(val3.Rows[0]["Year1"].ToString());
						break;
					}
					formFullBaseInfoViewModel.Month1 = short.Parse(val3.Rows[0]["Month1"].ToString());
					formFullBaseInfoViewModel.RegisterDate = DateTime.Parse(val3.Rows[0]["RegisterDate"].ToString());
					formFullBaseInfoViewModel.RegisterDatePersian = val3.Rows[0]["RegisterDatePersian"].ToString();
					formFullBaseInfoViewModel.ItemDescVisibale = formbaseInfo.ItemDescVisibale;
					formFullBaseInfoViewModel.ItemOrderVisibale = formbaseInfo.ItemOrderVisibale;
					formFullBaseInfoViewModel.ItemCountryCodeVisibale = formbaseInfo.ItemCountryCodeVisibale;
					formFullBaseInfoViewModel.ItemTitleVisibale = formbaseInfo.ItemTitleVisibale;
					formFullBaseInfoViewModel.TypeAccess = formbaseInfo.TypeAccess;
					formFullBaseInfoViewModel.TypeAction = formbaseInfo.TypeAction;
					formFullBaseInfoViewModel.NameTabel = formbaseInfo.NameTabel;
					formFullBaseInfoViewModel.NamefieldI = formbaseInfo.NamefieldI;
					formFullBaseInfoViewModel.NamefieldII = formbaseInfo.NamefieldII;
					formFullBaseInfoViewModel.NamefieldIII = formbaseInfo.NamefieldIII;
					formFullBaseInfoViewModel.NamefieldIV = formbaseInfo.NamefieldIV;
					formFullBaseInfoViewModel.NamefieldID = formbaseInfo.NamefieldID;
					formFullBaseInfoViewModel.ItemDefaultVisibale = formbaseInfo.ItemDefaultVisibale;
					formFullBaseInfoViewModel.NamefieldVI = formbaseInfo.NamefieldVI;
					formFullBaseInfoViewModel.ItemRateVisibale = formbaseInfo.ItemRateVisibale;
					formFullBaseInfoViewModel.NamefieldVII = formbaseInfo.NamefieldVII;
					formFullBaseInfoViewModel.ItemDeActiveVisibale = formbaseInfo.ItemDeActiveVisibale;
					formFullBaseInfoViewModel.NamefieldVIII = formbaseInfo.NamefieldVIII;
					formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = formbaseInfo.CheckUserDistanceCmpVisible;
					formFullBaseInfoViewModel.NamefieldIX = formbaseInfo.NamefieldIX;
					formFullBaseInfoViewModel.UserDistanceCmpValVisible = formbaseInfo.UserDistanceCmpValVisible;
					formFullBaseInfoViewModel.NamefieldX = formbaseInfo.NamefieldX;
					formFullBaseInfoViewModel.ItemScoreRateVisibale = formbaseInfo.ItemScoreRateVisibale;
					formFullBaseInfoViewModel.NamefieldScoreRate = formbaseInfo.NamefieldScoreRate;
					formFullBaseInfoViewModel.FODefaultVisible = formbaseInfo.FODefaultVisible;
					formFullBaseInfoViewModel.NamefieldFODefault = formbaseInfo.NamefieldFODefault;
					formFullBaseInfoViewModel.SHPDefaultVisible = formbaseInfo.SHPDefaultVisible;
					formFullBaseInfoViewModel.NamefieldSHPDefault = formbaseInfo.NamefieldSHPDefault;
					formFullBaseInfoViewModel.SHPVisible_Visible = formbaseInfo.SHPVisible_Visible;
					formFullBaseInfoViewModel.NamefieldSHPVisible = formbaseInfo.NamefieldSHPVisible;
					formFullBaseInfoViewModel.SHPNeedAddressVisible = formbaseInfo.SHPNeedAddressVisible;
					formFullBaseInfoViewModel.NamefieldSHPNeedAddress = formbaseInfo.NamefieldSHPNeedAddress;
				}
			}
			else
			{
				formFullBaseInfoViewModel.ItemDesc = "";
				formFullBaseInfoViewModel.ItemCountryCodeVisibale = "hidden";
				formFullBaseInfoViewModel.ItemTitleVisibale = "hidden";
				formFullBaseInfoViewModel.ItemDescVisibale = "hidden";
				formFullBaseInfoViewModel.TypeAccess = formbaseInfo.TypeAccess;
				formFullBaseInfoViewModel.TypeAction = formbaseInfo.TypeAction;
				formFullBaseInfoViewModel.NameTabel = formbaseInfo.NameTabel;
				formFullBaseInfoViewModel.UserId = formbaseInfo.UserId;
				formFullBaseInfoViewModel.Year1 = formbaseInfo.Year1;
				formFullBaseInfoViewModel.Month1 = formbaseInfo.Month1;
				formFullBaseInfoViewModel.RegisterDate = formbaseInfo.RegisterDate;
				formFullBaseInfoViewModel.RegisterDatePersian = formbaseInfo.RegisterDatePersian;
				formFullBaseInfoViewModel.ItemDefaultVisibale = "hidden";
				formFullBaseInfoViewModel.ItemOrderVisibale = "hidden";
				formFullBaseInfoViewModel.ItemRateVisibale = "hidden";
				formFullBaseInfoViewModel.ItemDeActiveVisibale = "hidden";
				formFullBaseInfoViewModel.CheckUserDistanceCmpVisible = "hidden";
				formFullBaseInfoViewModel.UserDistanceCmpValVisible = "hidden";
				formFullBaseInfoViewModel.ItemCode = "";
				formFullBaseInfoViewModel.ItemCodeVisibale = "hidden";
			}
			((DbConnection)val).Close();
			((DbDataReader)val4).Close();
			if (formbaseInfo.isLanguage)
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result11);
				if (result11 <= 0)
				{
					result11 = 1065;
				}
				int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
				List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
				List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
				list.Add(new CommonMultiLanguageViewModel
				{
					LanguageId = result11,
					Value = formFullBaseInfoViewModel.ItemTitle
				});
				list2.Add(new CommonMultiLanguageViewModel
				{
					LanguageId = result11,
					Value = formFullBaseInfoViewModel.ItemDesc
				});
				val = new SqlConnection(connectionString);
				val2 = new SqlCommand();
				val3 = new DataTable();
				val2.Connection = val;
				commandText = string.Format("select * from " + formbaseInfo.NameTabel + "_Lang where " + formbaseInfo.NamefieldID + "=" + id);
				((DbCommand)val2).CommandText = commandText;
				((DbConnection)val).Open();
				val4 = val2.ExecuteReader();
				if (((DbDataReader)val4).HasRows)
				{
					val3.Load((IDataReader)(object)val4);
					((DbConnection)val).Close();
					((DbDataReader)val4).Close();
					if (val3 != null)
					{
						for (int i = 0; i < ((InternalDataCollectionBase)val3.Rows).Count; i++)
						{
							int.TryParse(val3.Rows[i]["LanguageId"].ToString(), out var result12);
							string value3 = val3.Rows[i][formbaseInfo.NamefieldI].ToString();
							list.Add(new CommonMultiLanguageViewModel
							{
								LanguageId = result12,
								Value = value3
							});
							string value4 = "";
							try
							{
								value4 = val3.Rows[i][formbaseInfo.NamefieldII].ToString();
							}
							catch
							{
							}
							list2.Add(new CommonMultiLanguageViewModel
							{
								LanguageId = result12,
								Value = value4
							});
						}
					}
				}
				formFullBaseInfoViewModel.ItemTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : "");
				formFullBaseInfoViewModel.ItemDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : "");
				formFullBaseInfoViewModel.ItemTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))));
				formFullBaseInfoViewModel.ItemDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))));
			}
			formFullBaseInfoViewModel.isLanguage = formbaseInfo.isLanguage;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return formFullBaseInfoViewModel;
	}

	public bool checkMultiLanguage(string defaultValue, List<CommonMultiLanguageViewModel> list)
	{
		bool result = true;
		List<CRMspSelectUserLanguages_Result> list2 = CRMIdeal.Cache.User.Language.Get();
		bool isCurrentUserAllowCopyOtherLanguage = UserLogin.IsCurrentUserAllowCopyOtherLanguage;
		foreach (Languages itemLang in CRMIdeal.Cache.Setting.Language.Get())
		{
			CommonMultiLanguageViewModel commonMultiLanguageViewModel = Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == itemLang.LanguageID));
			if (commonMultiLanguageViewModel == null)
			{
				if (Enumerable.Any<CRMspSelectUserLanguages_Result>((IEnumerable<CRMspSelectUserLanguages_Result>)list2, (Func<CRMspSelectUserLanguages_Result, bool>)((CRMspSelectUserLanguages_Result c) => c.LanguageID == itemLang.LanguageID)))
				{
					if (isCurrentUserAllowCopyOtherLanguage)
					{
						list.Add(new CommonMultiLanguageViewModel
						{
							LanguageId = itemLang.LanguageID,
							Value = defaultValue
						});
					}
					else
					{
						result = false;
					}
				}
				else
				{
					list.Add(new CommonMultiLanguageViewModel
					{
						LanguageId = itemLang.LanguageID,
						Value = defaultValue
					});
				}
			}
			else
			{
				if (!string.IsNullOrEmpty(commonMultiLanguageViewModel.Value))
				{
					continue;
				}
				if (Enumerable.Any<CRMspSelectUserLanguages_Result>((IEnumerable<CRMspSelectUserLanguages_Result>)list2, (Func<CRMspSelectUserLanguages_Result, bool>)((CRMspSelectUserLanguages_Result c) => c.LanguageID == itemLang.LanguageID)))
				{
					if (isCurrentUserAllowCopyOtherLanguage)
					{
						commonMultiLanguageViewModel.Value = defaultValue;
					}
					else
					{
						result = false;
					}
				}
				else
				{
					commonMultiLanguageViewModel.Value = defaultValue;
				}
			}
		}
		return result;
	}

	[AjaxOnly]
	public JsonResult GetItemListForFo(string typeAction)
	{
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected O, but got Unknown
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Expected O, but got Unknown
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		bool flag = false;
		try
		{
			FormFullBaseInfoViewModel formFullBaseInfoViewModel = new FormFullBaseInfoViewModel();
			formFullBaseInfoViewModel = FullForm(typeAction);
			if (formFullBaseInfoViewModel != null)
			{
				string typeAction2 = formFullBaseInfoViewModel.TypeAction;
				flag = ((typeAction2 == "actDefinecnvsTopics" || typeAction2 == "actDefineTopic") ? true : false);
				if (flag)
				{
					SqlConnection val = new SqlConnection(db.Database.Connection.ConnectionString);
					SqlCommand val2 = new SqlCommand();
					DataTable val3 = new DataTable();
					val2.Connection = val;
					string text = "";
					text = ((!formFullBaseInfoViewModel.isLanguage) ? string.Format("select * from " + formFullBaseInfoViewModel.NameTabel + " order by " + formFullBaseInfoViewModel.NamefieldID) : ((!string.IsNullOrEmpty(formFullBaseInfoViewModel.Parametes)) ? ("exec " + formFullBaseInfoViewModel.NameTabel_Lang + " " + formFullBaseInfoViewModel.Parametes) : string.Format("exec " + formFullBaseInfoViewModel.NameTabel_Lang + " {0},{1}", lCID, result)));
					((DbCommand)val2).CommandText = text;
					((DbConnection)val).Open();
					SqlDataReader val4 = val2.ExecuteReader();
					if (((DbDataReader)val4).HasRows)
					{
						val3.Load((IDataReader)(object)val4);
					}
					((DbConnection)val).Close();
					((DbDataReader)val4).Close();
					if (val3 != null)
					{
						for (int i = 0; i < ((InternalDataCollectionBase)val3.Rows).Count; i++)
						{
							SelectListItem selectListItem = new SelectListItem();
							int num = int.Parse(val3.Rows[i][formFullBaseInfoViewModel.NamefieldID].ToString());
							if (num < 0)
							{
								continue;
							}
							selectListItem.Value = num.ToString();
							selectListItem.Text = ((val3.Rows[i][formFullBaseInfoViewModel.NamefieldI] == null || val3.Rows[i][formFullBaseInfoViewModel.NamefieldI].ToString() == "") ? "" : val3.Rows[i][formFullBaseInfoViewModel.NamefieldI].ToString());
							bool selected = false;
							try
							{
								DataColumnCollection columns = val3.Columns;
								if (columns != null && columns.Contains("FODefault") && !string.IsNullOrEmpty(val3.Rows[i]["FODefault"].ToString()))
								{
									selected = bool.Parse(val3.Rows[i]["FODefault"].ToString());
								}
							}
							catch (Exception e)
							{
								ErrorSignal.FromCurrentContext().Raise(e);
							}
							selectListItem.Selected = selected;
							list.Add(selectListItem);
						}
					}
				}
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		base.ViewBag.ShowFoBox = flag;
		base.ViewBag.FODefaultList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public int ChangeFoDefaultItems(string typeAction, int itemId)
	{
		int num = 0;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			FormFullBaseInfoViewModel formFullBaseInfoViewModel = new FormFullBaseInfoViewModel();
			formFullBaseInfoViewModel = FullForm(typeAction);
			if (formFullBaseInfoViewModel != null)
			{
				string typeAction2 = formFullBaseInfoViewModel.TypeAction;
				if (typeAction2 == "actDefinecnvsTopics" || typeAction2 == "actDefineTopic")
				{
					db.CRMspUpdateConversationTopicsFODefault(itemId);
					num = 1;
				}
				if (num == 1)
				{
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo(formFullBaseInfoViewModel.NameTabel);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return num;
	}

	[AjaxOnly]
	public string ActUpdateFullDiscountPerWithRateInAdd(bool fullDiscountPerWithRateInAdd = false)
	{
		string text = "";
		try
		{
			CrmsysSetting crmsysSetting = Queryable.FirstOrDefault<CrmsysSetting>((IQueryable<CrmsysSetting>)_dbTbl.CrmsysSetting);
			if (crmsysSetting != null)
			{
				DateTime now = DateTime.Now;
				crmsysSetting.UserId = UserLogin.CurrentUser.UserId;
				crmsysSetting.RegisterDate = now;
				crmsysSetting.Year1 = short.Parse(Financial.Get().Id.ToString());
				crmsysSetting.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
				crmsysSetting.AppType = Configuration.AppType;
				crmsysSetting.FullDiscountPerWithRateInAdd = fullDiscountPerWithRateInAdd;
				_dbTbl.Entry(crmsysSetting).State = EntityState.Modified;
				_dbTbl.SaveChanges();
				if (!SysSeting.Update())
				{
					return Messages.ErrorInCacheUpdate;
				}
				return "1";
			}
			return Messages.ErrorNotFound;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return Messages.frmErrorMessage;
		}
	}
}
