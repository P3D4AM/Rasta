using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Objects;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.General.Calendar;
using CRM.General.IO.FTP;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Areas.OtherSystems.Controllers;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes.Common;
using CRMIdeal.GSD.Globalization;
using CRMIdeal.Hubs;
using CRMIdeal.LinkPayvast;
using Elmah;
using Microsoft.Ajax.Utilities;
using NR.Shygun.WS.ClientModel;
using NR.Shygun.WS.ClientModel.GeneralModels;
using NR.Shygun.WS.ClientModel.Models.Invoice;
using NR.Shygun.WS.FilterDomains;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace CRMIdeal.Classes.Helper;

public class OtherSystems
{
	public class SepidarHaveModulesViewModel
	{
		public bool SepNotHavePordModule { get; set; }

		public bool SepNotHaveOrdModule { get; set; }

		public bool SepNotHaveBordModule { get; set; }

		public bool SepNotHaveDocModule { get; set; }

		public bool SepNotHavePayModule { get; set; }

		public bool SepNotHaveCommModule { get; set; }

		public string SepNotHavePordModulePartLabelTitle { get; set; }

		public string SepNotHaveOrdModulePartLabelTitle { get; set; }

		public string SepNotHaveBordModulePartLabelTitle { get; set; }

		public string SepNotHaveDocModulePartLabelTitle { get; set; }

		public string SepNotHavePayModulePartLabelTitle { get; set; }

		public string SepNotHaveCommModulePartLabelTitle { get; set; }
	}

	public class ShygunSettingViewModel
	{
		public bool AllowRowSecurity { get; set; }

		public string AuthUser { get; set; }

		public string AuthPassword { get; set; }

		public string DataBaseName { get; set; }

		public string DBUserName { get; set; }

		public string DBPassword { get; set; }

		public int Language { get; set; }

		public int Level { get; set; }

		public string Server { get; set; }

		public int From { get; set; }

		public int To { get; set; }

		public string IP { get; set; }

		public Config conf { get; set; }

		public string CmpMoeinAccCode { get; set; }

		public string PrdPriceGroup { get; set; }

		public string OrdTax { get; set; }

		public string OrdTaxFieldTitle { get; set; }

		public string OrdRound { get; set; }

		public string OrdRoundFieldTitle { get; set; }

		public string OrdTransportation { get; set; }

		public string OrdTransportationFieldTitle { get; set; }

		public string OrdCurrencyUnit { get; set; }

		public int DefPrjCvnsStatusGroupId { get; set; }

		public string DefPrjTitle { get; set; }

		public int WrhsSyncTypeId { get; set; }

		public int PrdGroupSyncTypeId { get; set; }

		public string PrdLinkedField { get; set; }

		public string DocMovementAccountNumber { get; set; }

		public string DocMovementAccountNumber_PartLabelTitle { get; set; }

		public string DocMovementAccountGUId { get; set; }

		public int DocMovementAccountGUId_Id { get; set; }
	}

	public class ShygunApiGetInvParamViewModel
	{
		public string StartVersion { get; set; }

		public string EndVersion { get; set; }

		public Config Config { get; set; }

		public DomainInvoiceHeader Domain { get; set; }
	}

	public class ShygunInvoiceViewModel
	{
		public DateTime? CreatedDate { get; set; }

		public string GeneralRef { get; set; }

		public decimal? DiscountPercent { get; set; }

		public decimal? DiscAmount { get; set; }

		public string DepartmentNumber { get; set; }

		public bool? DeleteAllExpenses { get; set; }

		public string ST1Number { get; set; }

		public Guid? ST1GuId { get; set; }

		public string ST2Number { get; set; }

		public Guid? ST2GuId { get; set; }

		public string AtfNumber { get; set; }

		public Guid? AtfGuId { get; set; }

		public string DeviceSerialNumber { get; set; }

		public int RelatedInvHeaderId { get; set; }

		public int InvHeaderIdRoot { get; set; }

		public Guid? RelatedInvHeaderGuid { get; set; }

		public Guid? InvHeaderRootGuid { get; set; }

		public Guid? ProjectGuid { get; set; }

		public bool ControlCheck { get; set; }

		public bool Printed { get; set; }

		public string AccountSubscriptionCode { get; set; }

		public string bijak { get; set; }

		public string SJob2Number { get; set; }

		public Guid? SJob2GuId { get; set; }

		public string SAccount2Number { get; set; }

		public List<InvoiceBody> Body { get; set; }

		public List<InvoiceExpense> Expense { get; set; }

		public List<InvoiceBasket> InvoiceBaskets { get; set; }

		public List<TMultiDiscountModel> MultiDiscounts { get; set; }

		public int InvTyp { get; set; }

		public int? InvHeaderId { get; set; }

		public int? InvNo { get; set; }

		public Guid? AccountGuId { get; set; }

		public Guid? JobCostingGuId { get; set; }

		public string InvDescription { get; set; }

		public string FirstIssuerUsername { get; set; }

		public string InvDate { get; set; }

		public string AccountNumber { get; set; }

		public string AccountName { get; set; }

		public string JobCostingNumber { get; set; }

		public string JobCostingName { get; set; }

		public string CurrencyAbb1 { get; set; }

		public Guid? SAccountGuId { get; set; }

		public Guid? SJobGuId { get; set; }

		public string SAccountNumber { get; set; }

		public string SJobNumber { get; set; }

		public Guid? SAccount2GuId { get; set; }

		public string InvPayDue { get; set; }

		public string LastIssuerUsername { get; set; }

		public Guid? GuId { get; set; }
	}

	public class ShygunApiGetInvResultViewModel
	{
		public List<ShygunInvoiceViewModel> Result { get; set; }
	}

	public class ShygunApiParamViewModel<T>
	{
		public string StartVersion { get; set; }

		public string EndVersion { get; set; }

		public Config Config { get; set; }

		public T Domain { get; set; }
	}

	public class ShygunApiGetItemGetRemainResultViewModel
	{
		public List<ShygunItemGetRemainViewModel> Result { get; set; }
	}

	public class ShygunItemGetRemainViewModel
	{
		public decimal? RemainCost { get; set; }

		public decimal? RemainUnit1Price { get; set; }

		public decimal? RemainUnit2Price { get; set; }

		public string StoreNumber { get; set; }

		public string StoreName { get; set; }

		public string ItemCode { get; set; }

		public string ItemDescription { get; set; }

		public string Unit1Name { get; set; }

		public double? Quantity1 { get; set; }

		public double? Quantity2 { get; set; }

		public string ItemGuId { get; set; }

		public string StockGuId { get; set; }
	}

	public class ShygunApiVoucherPutParamViewModel
	{
		public string StartVersion { get; set; }

		public string EndVersion { get; set; }

		public Config Config { get; set; }

		public List<Voucher> PutObject { get; set; }
	}

	public class ShygunApiParamNoDomainViewModel
	{
		public string StartVersion { get; set; }

		public string EndVersion { get; set; }

		public Config Config { get; set; }
	}

	public class ShygunApiGetPayTypeResultViewModel
	{
		public List<ShygunPayTypeViewModel> Result { get; set; }
	}

	public class ShygunPayTypeViewModel
	{
		public int? TypeId { get; set; }

		public string Name { get; set; }

		public string GuId { get; set; }
	}

	public class ShygunApiGetDepartmentResultViewModel
	{
		public List<ShygunDepartmentViewModel> Result { get; set; }
	}

	public class ShygunDepartmentViewModel
	{
		public string DepartmentNumber { get; set; }

		public string DepartmentName { get; set; }

		public long? UpdateKind { get; set; }

		public string GuId { get; set; }
	}

	public class ShygunSettingDetailsViewModel
	{
		public int OrdPayVouchType { get; set; }

		public int OrdPayVouchDateType { get; set; }

		public string OrdPayCurrencyAbb1 { get; set; }

		public double OrdPayRate { get; set; }

		public string OrdPayDepartmentNumber { get; set; }

		public int OrdPayType { get; set; }

		public int OrdPayDueDateType { get; set; }
	}

	public class ShygunIISettingViewModel
	{
		public string IP { get; set; }

		public string AuthUser { get; set; }

		public string AuthPassword { get; set; }

		public string Server { get; set; }

		public string DataBaseName { get; set; }

		public string DBUserName { get; set; }

		public string DBPassword { get; set; }

		public int Language { get; set; }

		public int Level { get; set; }

		public bool AllowRowSecurity { get; set; }

		public int StartRowNumber { get; set; }

		public int CountRowInEveryReport { get; set; }

		public string ShygunSaleMoinNumber { get; set; }

		public string ShygunSaleMoinNumberFieldTitle { get; set; }

		public Config conf { get; set; }

		public string CmpTypeJobGroupNumber { get; set; }

		public int PrdGroupSyncTypeId { get; set; }

		public string PrdLinkedField { get; set; }

		public int WrhsSyncTypeId { get; set; }

		public string DefTax { get; set; }

		public string DefTaxFieldTitle { get; set; }

		public string DefRound { get; set; }

		public string DefRoundFieldTitle { get; set; }

		public string DefTransportation { get; set; }

		public string DefTransportationFieldTitle { get; set; }

		public string DefCurrencyUnit { get; set; }

		public string PordAccountGuId { get; set; }

		public string PordAccountNumber { get; set; }

		public string PordAccountNumberFieldTitle { get; set; }

		public string OrdAccountGuId { get; set; }

		public string OrdAccountNumber { get; set; }

		public string OrdAccountNumberFieldTitle { get; set; }

		public int DefPrjCvnsStatusGroupId { get; set; }

		public string DefPrjTitle { get; set; }

		public string DocAccountGuId { get; set; }

		public string DocAccountNumber { get; set; }

		public string DocAccountNumberFieldTitle { get; set; }

		public string DraftAccountGuId { get; set; }

		public string DraftAccountNumber { get; set; }

		public string DraftAccountNumberFieldTitle { get; set; }

		public string WrhsMovementAccountGuId { get; set; }

		public string WrhsMovementAccountNumber { get; set; }

		public string WrhsMovementAccountNumberFieldTitle { get; set; }
	}

	public class ShygunIIApiGetJobParamViewModel
	{
		public string StartVersion { get; set; }

		public string EndVersion { get; set; }

		public Config Config { get; set; }

		public DomainJob Domain { get; set; }
	}

	public class ShygunIIApiGetJobResultViewModel
	{
		public List<ShygunIICompanyInfoViewModel> Result { get; set; }
	}

	public class ShygunIIApiGetInvParamViewModel
	{
		public string StartVersion { get; set; }

		public string EndVersion { get; set; }

		public Config Config { get; set; }

		public DomainInvoiceHeader Domain { get; set; }
	}

	public class ShygunIIInvoiceViewModel
	{
		public DateTime? CreatedDate { get; set; }

		public string GeneralRef { get; set; }

		public decimal? DiscountPercent { get; set; }

		public decimal? DiscAmount { get; set; }

		public string DepartmentNumber { get; set; }

		public bool? DeleteAllExpenses { get; set; }

		public string ST1Number { get; set; }

		public Guid? ST1GuId { get; set; }

		public string ST2Number { get; set; }

		public Guid? ST2GuId { get; set; }

		public string AtfNumber { get; set; }

		public Guid? AtfGuId { get; set; }

		public string DeviceSerialNumber { get; set; }

		public int RelatedInvHeaderId { get; set; }

		public int InvHeaderIdRoot { get; set; }

		public Guid? RelatedInvHeaderGuid { get; set; }

		public Guid? InvHeaderRootGuid { get; set; }

		public Guid? ProjectGuid { get; set; }

		public bool ControlCheck { get; set; }

		public bool Printed { get; set; }

		public string AccountSubscriptionCode { get; set; }

		public string bijak { get; set; }

		public string SJob2Number { get; set; }

		public Guid? SJob2GuId { get; set; }

		public string SAccount2Number { get; set; }

		public List<InvoiceBody> Body { get; set; }

		public List<InvoiceExpense> Expense { get; set; }

		public List<InvoiceBasket> InvoiceBaskets { get; set; }

		public List<TMultiDiscountModel> MultiDiscounts { get; set; }

		public int InvTyp { get; set; }

		public int? InvHeaderId { get; set; }

		public int? InvNo { get; set; }

		public Guid? AccountGuId { get; set; }

		public Guid? JobCostingGuId { get; set; }

		public string InvDescription { get; set; }

		public string FirstIssuerUsername { get; set; }

		public string InvDate { get; set; }

		public string AccountNumber { get; set; }

		public string AccountName { get; set; }

		public string JobCostingNumber { get; set; }

		public string JobCostingName { get; set; }

		public string CurrencyAbb1 { get; set; }

		public Guid? SAccountGuId { get; set; }

		public Guid? SJobGuId { get; set; }

		public string SAccountNumber { get; set; }

		public string SJobNumber { get; set; }

		public Guid? SAccount2GuId { get; set; }

		public string InvPayDue { get; set; }

		public string LastIssuerUsername { get; set; }

		public Guid? GuId { get; set; }
	}

	public class ShygunIIApiGetInvResultViewModel
	{
		public List<ShygunIIInvoiceViewModel> Result { get; set; }
	}

	public class ShygunIIApiPutVoucherParamViewModel
	{
		public Config Config { get; set; }

		public List<Voucher> PutObject { get; set; }
	}

	public class ShygunIIApiPutVoucherResultViewModel
	{
		public List<ShygunIIApiPutVoucherResultIViewModel> Result { get; set; }
	}

	public class ShygunIIApiPutVoucherResultIViewModel
	{
		public string ErrorMessage { get; set; }

		public string Number { get; set; }

		public Guid? GuId { get; set; }
	}

	public class ShomaranSettingViewModel
	{
		public string PrdLinkedField { get; set; }

		public int WrhsSyncTypeId { get; set; }
	}

	public class ArpaSettingViewModel
	{
		public string ArpaServerAddress { get; set; }

		public string ArpaUserName { get; set; }

		public string ArpaPassword { get; set; }

		public string ArpaFiscalYearId { get; set; }

		public string DefUserGroupId { get; set; }

		public string PrdLinkedField { get; set; }

		public int WrhsSyncTypeId { get; set; }

		public decimal OrdTaxIndex { get; set; }

		public decimal OrdDutyIndex { get; set; }

		public string OrdRoundId { get; set; }

		public string OrdRoundPlusId { get; set; }
	}

	public class HamrahanSettingViewModel
	{
		public string HamrahanApiAddress { get; set; }

		public string HamrahanApiVersion { get; set; }

		public string HamrahanApiVersionDefineCmp { get; set; }

		public string HamrahanApiKey { get; set; }

		public string HamrahanCompanyId { get; set; }

		public string HamrahanCurrentFiscalYear { get; set; }

		public string HamrahanApiUserId { get; set; }

		public string HamrahanCurrencyUnit { get; set; }

		public string PrdLinkedField { get; set; }

		public string LegalStateFormal { get; set; }

		public string RealStateFormal { get; set; }

		public string LegalCompanyType { get; set; }

		public string RealIndexOwner { get; set; }

		public string RealIndexState { get; set; }

		public string RealIndexClass { get; set; }

		public string RealIndexKind { get; set; }

		public string RealIndexCredit { get; set; }

		public string LegalIndexOwner { get; set; }

		public string LegalIndexState { get; set; }

		public string LegalIndexClass { get; set; }

		public string LegalIndexKind { get; set; }

		public string LegalIndexCredit { get; set; }

		public int WrhsSyncTypeId { get; set; }

		public int OrdRefBelongDeductPrdDisPercent { get; set; }

		public int OrdRefBelongDeductPrdDisAmount { get; set; }

		public int OrdRefBelongDeductServiceDisPercent { get; set; }

		public int OrdRefBelongDeductServiceDisAmount { get; set; }

		public int OrdRefBelongAddPrdTax { get; set; }

		public int OrdRefBelongAddServiceTax { get; set; }
	}

	public class HamrahanSettingDetailsViewModel
	{
		public int OrdIndexDocument { get; set; }

		public int OrdRefProcess { get; set; }

		public int OrdRefForm { get; set; }

		public int OrdRefSaleMethod { get; set; }

		public int OrdIndexStatus { get; set; }

		public int OrdIndexBelong { get; set; }

		public int OrdRnProject { get; set; }

		public int OrdIndexDeliveryStatus { get; set; }

		public int OrdRecieptStatusIndex { get; set; }

		public int OrdPayIndexDocument { get; set; }

		public int OrdPayIndexKind { get; set; }

		public int OrdPayIndexKind1 { get; set; }

		public int OrdPayDRNAccountBank { get; set; }

		public int OrdPayDocumentDateType { get; set; }
	}

	public class NoAvaranCapillarySettingViewModel
	{
		public string ApiUserId { get; set; }

		public string ApiUserName { get; set; }

		public int DefCurrencyUnitId { get; set; }

		public string DefPrjTitle { get; set; }

		public int DefPrjCvnsStatusGroupId { get; set; }

		public int WrhsSyncTypeId { get; set; }

		public int WrhsSyncTypeLinkAccSettingId { get; set; }

		public string PrdLinkedField { get; set; }

		public int PordOprFieldLinkTokindFactor { get; set; }
	}

	public class NoAvaranCapillarySettingDetailsViewModel
	{
		public int PordPayDateType { get; set; }

		public int PordPayDateFirstType { get; set; }

		public int PordPayDateRasType { get; set; }

		public int PordPayCheckDateType { get; set; }

		public string PordPayKindSabt { get; set; }

		public int PordOprkindFactor { get; set; }
	}

	public class RahkaranRetailSettingViewModel
	{
		public string ApiAddress { get; set; }

		public string ApiUsername { get; set; }

		public string ApiPassword { get; set; }

		public string ApiMachineName { get; set; }

		public string ApiCookieName { get; set; }

		public string ApiCookie { get; set; }

		public int ApiCookieLinkAccSettingId { get; set; }

		public int CurrencyRef { get; set; }

		public int WrhsSyncTypeId { get; set; }

		public int WrhsSyncTypeLinkAccSettingId { get; set; }

		public string PrdLinkedField { get; set; }
	}

	public class NilramSettingViewModel
	{
		public string ApiAddress { get; set; }

		public string ApiToken { get; set; }

		public int DefCurrencyUnitId { get; set; }

		public string DefPrjTitle { get; set; }

		public int DefPrjCvnsStatusGroupId { get; set; }

		public int WrhsSyncTypeId { get; set; }

		public int WrhsSyncTypeLinkAccSettingId { get; set; }

		public string PrdLinkedField { get; set; }
	}

	public class HamyarProvider
	{
		public class SendPordFiles
		{
			public class HamyarFileTypeFormatViewModel
			{
				public int Id { get; set; }

				public string Title { get; set; }

				public string[] Formats { get; set; }

				public bool IsDef { get; set; }
			}

			public class SendNotificationViewModel
			{
				public string Key { get; set; }

				public int UserId { get; set; }

				public string ReceiverName { get; set; }

				public int ObjId { get; set; }

				public string ObjNumber { get; set; }

				public dynamic ObjJs { get; set; }

				public CRMspSelectFilesDirectory_Result FileJs { get; set; }

				public SendNotificationProgressViewModel Value { get; set; }

				public string Message { get; set; }

				public bool IsDone { get; set; }
			}

			public class SendNotificationProgressViewModel
			{
				public int Per { get; set; }

				public int TotalSteps { get; set; }

				public int CurrStep { get; set; }
			}

			[CompilerGenerated]
			private sealed class _003C_003Ec__DisplayClass7_0
			{
				public SendPordFiles _003C_003E4__this;

				public CRMspSelectFilesDirectory_Result fileRec;

				internal bool _003CSendFile_003Eb__0(LinkAccDataViewModel x)
				{
					return x.CId == _003C_003E4__this._Pord.pordCId;
				}
			}

			private CRMSpEntities _db = new CRMSpEntities();

			private CRMTabelEntities _dbTbl = new CRMTabelEntities();

			private HamyarProvider _Hamyar = new HamyarProvider(false);

			private int? _PordId;

			private WSspSelectPreOrderWithId_Result _Pord;

			private int? _UserId = UserLogin.CurrentUser.UserId;

			public static int _HamyarFileType_pic = 1;

			public static int _HamyarFileType_pdf = 2;

			public static int _HamyarFileType_rar = 3;

			public static int _HamyarFileType_zip = 4;

			public static int _HamyarFileType_other = 5;

			private static List<HamyarFileTypeFormatViewModel> _FileTypesList = null;

			public static string _SendNotification_Key_MngOtherSystemSndFile = "MngOtherSystemSndFile";

			public static string _SendNotification_Key_Pord = "Pord";

			public static string _SendNotification_Key_Ord = "Ord";

			public static List<HamyarFileTypeFormatViewModel> FileTypesList
			{
				get
				{
					if (_FileTypesList == null)
					{
						_FileTypesList = new List<HamyarFileTypeFormatViewModel>();
						_FileTypesList.Add(new HamyarFileTypeFormatViewModel
						{
							Id = _HamyarFileType_pic,
							Title = Labels.Picture,
							Formats = new string[6] { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".tiff" }
						});
						_FileTypesList.Add(new HamyarFileTypeFormatViewModel
						{
							Id = _HamyarFileType_pdf,
							Title = "pdf",
							Formats = new string[1] { ".pdf" }
						});
						_FileTypesList.Add(new HamyarFileTypeFormatViewModel
						{
							Id = _HamyarFileType_rar,
							Title = "rar",
							Formats = new string[1] { ".rar" }
						});
						_FileTypesList.Add(new HamyarFileTypeFormatViewModel
						{
							Id = _HamyarFileType_zip,
							Title = "zip",
							Formats = new string[5] { ".zip", ".7z", ".tar", ".gzip", ".gz" }
						});
						_FileTypesList.Add(new HamyarFileTypeFormatViewModel
						{
							Id = _HamyarFileType_other,
							Title = "Other",
							Formats = new string[0],
							IsDef = true
						});
					}
					return _FileTypesList;
				}
			}

			public SendPordFiles(int? pordId = null, WSspSelectPreOrderWithId_Result pord = null)
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				if (pord != null)
				{
					_Pord = pord;
					_PordId = pord.PreOrderID;
					return;
				}
				try
				{
					_Pord = Enumerable.FirstOrDefault<WSspSelectPreOrderWithId_Result>((IEnumerable<WSspSelectPreOrderWithId_Result>)_db.WSspSelectPreOrderWithId(pordId, lCID, result));
					if (_Pord != null)
					{
						_PordId = _Pord.PreOrderID;
					}
				}
				catch (Exception ex)
				{
					Public.InsExceptToElmah(ex);
				}
			}

			private string SendFile(CRMspSelectFilesDirectory_Result fileRec)
			{
				_003C_003Ec__DisplayClass7_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass7_0();
				CS_0024_003C_003E8__locals0._003C_003E4__this = this;
				CS_0024_003C_003E8__locals0.fileRec = fileRec;
				string text = "";
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				_ = Thread.CurrentThread.CurrentCulture.LCID;
				DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
				_ = Financial.Get().Id;
				short.Parse(Financial.Get().Id.ToString());
				short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
				_ = Configuration.AppType;
				int num = 5;
				SendNotif(CS_0024_003C_003E8__locals0.fileRec, num);
				if (VersionBuyer.AttachFiles && CS_0024_003C_003E8__locals0.fileRec != null)
				{
					FilesManager filesManager = new FilesManager();
					SendNotif(CS_0024_003C_003E8__locals0.fileRec, num, 1);
					string text2 = $"/Download/LinkAcc/tmp/usr-{_UserId.ToString()}/";
					filesManager.CreateDirectory(text2);
					string path = HostingEnvironment.MapPath(text2);
					string text3 = Path.Combine(text2, CS_0024_003C_003E8__locals0.fileRec.FileName);
					string text4 = Path.Combine(path, CS_0024_003C_003E8__locals0.fileRec.FileName);
					Path.GetExtension(text3);
					Path.GetFileNameWithoutExtension(text3);
					SendNotif(CS_0024_003C_003E8__locals0.fileRec, num, 2);
					try
					{
						FacadeFTP facadeFTP = new FacadeFTP(Configuration.FacadeFtp);
						string pathFtp = Configuration.PathFtp;
						string userNameFtp = Configuration.UserNameFtp;
						string passwordFtp = Configuration.PasswordFtp;
						bool usePassiveFtp = Configuration.UsePassiveFtp;
						if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.fileRec.FilePath) && !string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.fileRec.FileName))
						{
							string text5 = CS_0024_003C_003E8__locals0.fileRec.FilePath.ToLower().Replace(Configuration.PathFtp.ToLower(), "");
							text5 = Configuration.MainDirectoryPath + CS_0024_003C_003E8__locals0.fileRec.FolderName + "/" + CS_0024_003C_003E8__locals0.fileRec.FileName;
							if (text5 != "")
							{
								SendNotif(CS_0024_003C_003E8__locals0.fileRec, num, 3);
								if (facadeFTP.Download(pathFtp, userNameFtp, passwordFtp, text4, text5, overwrite: true, usePassiveFtp))
								{
									SendNotif(CS_0024_003C_003E8__locals0.fileRec, num, 4);
									CRMspSelectCentersWithIds_Result cRMspSelectCentersWithIds_Result = Enumerable.FirstOrDefault<CRMspSelectCentersWithIds_Result>((IEnumerable<CRMspSelectCentersWithIds_Result>)Center.GetWithIds_Actives(_Pord.pordCId.ToString()));
									if (cRMspSelectCentersWithIds_Result == null)
									{
										text = Messages.msgErrorCenterNotFound;
									}
									else
									{
										string requestUri = _Hamyar.ApiAddress + "AddAttachmentToSefaresh";
										HttpClient obj = new HttpClient
										{
											DefaultRequestHeaders = 
											{
												{ "X-API-KEY", _Hamyar.ApiKey },
												{
													"Authorization",
													_Hamyar.GetToken()
												}
											}
										};
										HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, requestUri);
										MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent
										{
											{
												new StringContent(cRMspSelectCentersWithIds_Result.LinkAccCenterCode),
												"CenterCode"
											},
											{
												new StringContent(_Pord.pordLinkAccPreOrderNumber ?? ""),
												"ShomarehSefaresh"
											},
											{
												new StringContent(_Pord.PreOrderID.ToString()),
												"SefareshCrmId"
											},
											{
												new StringContent(""),
												"Tozihat"
											},
											{
												new StringContent(GetHamyarFileType(text3).Id.ToString()),
												"NoeFile"
											}
										};
										StreamContent streamContent = new StreamContent(File.OpenRead(text4));
										streamContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
										{
											Name = "\"File\"",
											FileName = "\"" + Path.GetFileName(text4) + "\""
										};
										streamContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
										multipartFormDataContent.Add(streamContent, "File", Path.GetFileName(text4));
										httpRequestMessage.Content = multipartFormDataContent;
										string result2 = obj.PostAsync(requestUri, multipartFormDataContent).Result.Content.ReadAsStringAsync().Result;
										if (!string.IsNullOrWhiteSpace(result2))
										{
											result2 = result2.ClearHiddenCharacters();
											HamyarAPIResponseViewModel<string> hamyarAPIResponseViewModel = JsonConvert.DeserializeObject<HamyarAPIResponseViewModel<string>>(result2);
											if (hamyarAPIResponseViewModel != null)
											{
												if (hamyarAPIResponseViewModel.isSuccess.GetValueOrDefault())
												{
													if (!string.IsNullOrWhiteSpace(hamyarAPIResponseViewModel.data))
													{
														List<LinkAccDataViewModel> list = new List<LinkAccDataViewModel>();
														if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.fileRec.FileLinkAccData))
														{
															list = JsonConvert.DeserializeObject<List<LinkAccDataViewModel>>(CS_0024_003C_003E8__locals0.fileRec.FileLinkAccData);
														}
														int num2 = list.FindIndex((LinkAccDataViewModel x) => x.CId == CS_0024_003C_003E8__locals0._003C_003E4__this._Pord.pordCId);
														if (num2 != -1)
														{
															list[num2].LTDate = DateTime.Now;
														}
														else
														{
															list.Add(new LinkAccDataViewModel
															{
																CId = _Pord.pordCId,
																FTDate = DateTime.Now,
																LTDate = DateTime.Now,
																DBId = 0,
																Id = hamyarAPIResponseViewModel.data,
																Code = ""
															});
														}
														DbSet<CrmFilesDirectory> crmFilesDirectory = _dbTbl.CrmFilesDirectory;
														ParameterExpression val = Expression.Parameter(typeof(CrmFilesDirectory), "x");
														CrmFilesDirectory crmFilesDirectory2 = Queryable.FirstOrDefault<CrmFilesDirectory>((IQueryable<CrmFilesDirectory>)crmFilesDirectory, Expression.Lambda<Func<CrmFilesDirectory, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass7_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
														crmFilesDirectory2.FileLinkAccData = JsonConvert.SerializeObject(list);
														_dbTbl.Entry(crmFilesDirectory2).State = EntityState.Modified;
														_dbTbl.SaveChanges();
														text = "";
													}
												}
												else if (Enumerable.Count<string>((IEnumerable<string>)hamyarAPIResponseViewModel.errors) > 0)
												{
													for (int i = 0; i < Enumerable.Count<string>((IEnumerable<string>)hamyarAPIResponseViewModel.errors); i++)
													{
														text = text + hamyarAPIResponseViewModel.errors[i] + "|";
													}
												}
												else
												{
													text = Messages.ErrorEmptyServerResult + "|";
												}
											}
										}
									}
								}
								else
								{
									text = text + Messages.frmFtpErrorDownloadFile + "\n";
								}
							}
						}
					}
					catch (Exception ex)
					{
						Public.InsExceptToElmah(ex);
						text = text + Messages.MsgErrorDoneOperation + "\n" + ex.Message;
					}
					finally
					{
						if (File.Exists(text4))
						{
							File.Delete(text4);
						}
					}
				}
				SendNotif(CS_0024_003C_003E8__locals0.fileRec, num, num, text, isDone: true);
				return text;
			}

			public static HamyarFileTypeFormatViewModel GetHamyarFileType(string fileName)
			{
				List<HamyarFileTypeFormatViewModel> fileTypesList = FileTypesList;
				HamyarFileTypeFormatViewModel result = Enumerable.FirstOrDefault<HamyarFileTypeFormatViewModel>((IEnumerable<HamyarFileTypeFormatViewModel>)fileTypesList, (Func<HamyarFileTypeFormatViewModel, bool>)((HamyarFileTypeFormatViewModel x) => x.IsDef));
				if (!string.IsNullOrWhiteSpace(fileName))
				{
					string ext = Path.GetExtension(fileName);
					HamyarFileTypeFormatViewModel hamyarFileTypeFormatViewModel = Enumerable.FirstOrDefault<HamyarFileTypeFormatViewModel>((IEnumerable<HamyarFileTypeFormatViewModel>)fileTypesList, (Func<HamyarFileTypeFormatViewModel, bool>)((HamyarFileTypeFormatViewModel x) => Enumerable.Contains<string>((IEnumerable<string>)x.Formats, ext.ToLower())));
					if (hamyarFileTypeFormatViewModel != null)
					{
						result = hamyarFileTypeFormatViewModel;
					}
				}
				return result;
			}

			private void SendNotif(CRMspSelectFilesDirectory_Result fileRec, int totalSteps = 1, int currStep = 0, string msg = "", bool isDone = false)
			{
				SendNotificationViewModel value = new SendNotificationViewModel
				{
					Key = _SendNotification_Key_Pord,
					UserId = _UserId.GetValueOrDefault(),
					ReceiverName = Labels.Hamyar,
					ObjId = _PordId.GetValueOrDefault(),
					ObjNumber = _Pord.pordNumber.ToString(),
					ObjJs = _Pord,
					FileJs = fileRec,
					Value = new SendNotificationProgressViewModel
					{
						Per = 100 / totalSteps * currStep,
						TotalSteps = totalSteps,
						CurrStep = currStep
					},
					Message = msg,
					IsDone = isDone
				};
				ChatHub.SendData(_SendNotification_Key_MngOtherSystemSndFile, JsonConvert.SerializeObject(value));
			}

			public string SendAll(int fileId = 0, bool? withThread = false)
			{
				string text = "";
				List<CRMspSelectFilesDirectory_Result> allFiles = PreOrder.GetAllFiles(_PordId.GetValueOrDefault());
				if (allFiles.Count > 0)
				{
					for (int i = 0; i < allFiles.Count; i++)
					{
						CRMspSelectFilesDirectory_Result itm = allFiles[i];
						if (fileId != 0 && fileId != itm.FileDirectoryID)
						{
							continue;
						}
						if (!string.IsNullOrWhiteSpace(itm.FileLinkAccData))
						{
							List<LinkAccDataViewModel> list = JsonConvert.DeserializeObject<List<LinkAccDataViewModel>>(itm.FileLinkAccData);
							if (list != null)
							{
								LinkAccDataViewModel linkAccDataViewModel = Enumerable.FirstOrDefault<LinkAccDataViewModel>((IEnumerable<LinkAccDataViewModel>)list, (Func<LinkAccDataViewModel, bool>)((LinkAccDataViewModel x) => x.CId == _Pord.pordCId));
								if (linkAccDataViewModel != null && !string.IsNullOrWhiteSpace(linkAccDataViewModel.Id))
								{
									continue;
								}
							}
						}
						SendNotif(itm);
						if (withThread.GetValueOrDefault())
						{
							Thread thread = new Thread((ThreadStart)delegate
							{
								SendFile(itm);
							});
							thread.IsBackground = true;
							thread.Start();
						}
						else if (!string.IsNullOrWhiteSpace(SendFile(itm)))
						{
							if (text != "")
							{
								text += "\n";
							}
							text = text + Messages.MsgErrorDoneOperation + "[ " + Labels.Title + ": " + itm.Title + " ]";
						}
					}
				}
				else
				{
					text = Messages.ErrorNotFindRecord;
				}
				return text;
			}
		}

		public class SendCompany
		{
			[CompilerGenerated]
			private sealed class _003C_003Ec__DisplayClass5_0
			{
				public CRMspSelectCompanyById_Result cmp;

				internal bool _003CSendCompanyMain_003Eb__2(LkCrmCompanyGroupsIIIViewModel x)
				{
					return x.CompanyGroupIIIID == cmp.cmpGroupIdIII;
				}

				internal bool _003CSendCompanyMain_003Eb__3(CRMspSelectCompanyGroupsWithAccLinkField_Result x)
				{
					return x.CompanyGroupID == cmp.cmpGroupId;
				}
			}

			private int _LastCId;

			private int _CmpId;

			private bool? _IsSendingToOtherCenters = false;

			private HamyarProvider _Hamyar;

			public SendCompany(int cmpId, HamyarProvider hamyarProvider = null)
			{
				_CmpId = cmpId;
				if (UserLogin.CurrentUser != null)
				{
					int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out _LastCId);
				}
				if (hamyarProvider != null)
				{
					_Hamyar = hamyarProvider;
				}
				else
				{
					_Hamyar = new HamyarProvider(true);
				}
			}

			private List<AdvanceResultViewModel> SendCompanyMain(int? centerId = 0, bool? isSendingToOtherCenters = false)
			{
				CRMSpEntities cRMSpEntities = new CRMSpEntities();
				CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
				CRMTabelEntities cRMTabelEntities = new CRMTabelEntities();
				List<AdvanceResultViewModel> list = new List<AdvanceResultViewModel>();
				list.Add(new AdvanceResultViewModel());
				try
				{
					_003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass5_0();
					int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
					if (result <= 0)
					{
						result = 1065;
					}
					int lCID = Thread.CurrentThread.CurrentCulture.LCID;
					CS_0024_003C_003E8__locals0.cmp = Company.GetCompanyById(_CmpId);
					if (CS_0024_003C_003E8__locals0.cmp != null)
					{
						list[0].Id = CS_0024_003C_003E8__locals0.cmp.CompanyID;
						list[0].Title = CS_0024_003C_003E8__locals0.cmp.CompanyName;
						list[0].Code = CS_0024_003C_003E8__locals0.cmp.cmpNumber.ToString();
						list[0].Obj = CS_0024_003C_003E8__locals0.cmp;
						CRMspSelectCompanyPersonsByID_Result companyPerson = GetCompanyPerson(CS_0024_003C_003E8__locals0.cmp.CompanyID, CS_0024_003C_003E8__locals0.cmp.cmpMainPersonId);
						string cId = (centerId ?? _LastCId).ToString();
						if (string.IsNullOrWhiteSpace(cId) || cId == "0")
						{
							list[0].Errors.Add(Messages.msgErrorCenterNotFound);
							return list;
						}
						list[0].Centers.Add(new AdvanceResultItemViewModel
						{
							Id = int.Parse(cId)
						});
						if (!isSendingToOtherCenters.GetValueOrDefault() && !string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.cmp.cmpLinkAccData))
						{
							List<LinkAccDataViewModel> list2 = JsonConvert.DeserializeObject<List<LinkAccDataViewModel>>(CS_0024_003C_003E8__locals0.cmp.cmpLinkAccData);
							if (list2 != null)
							{
								for (int i = 0; i < Enumerable.Count<LinkAccDataViewModel>((IEnumerable<LinkAccDataViewModel>)list2); i++)
								{
									string text = list2[i].CId.GetValueOrDefault().ToString();
									string code = list2[i].Code;
									CRMspSelectCentersWithIds_Result cRMspSelectCentersWithIds_Result = Enumerable.FirstOrDefault<CRMspSelectCentersWithIds_Result>((IEnumerable<CRMspSelectCentersWithIds_Result>)Center.GetWithIds(text));
									if (!string.IsNullOrWhiteSpace(text) && !(text == cId) && !string.IsNullOrWhiteSpace(code))
									{
										int result2 = 0;
										int.TryParse(text, out result2);
										if (cRMspSelectCentersWithIds_Result != null && result2 != 0 && !cRMspSelectCentersWithIds_Result.CenterInActive.GetValueOrDefault())
										{
											List<AdvanceResultViewModel> list3 = SendCompanyMain(result2, true);
											list[0].Centers.AddRange(list3[0].Centers);
										}
									}
								}
							}
						}
						CRMspSelectCentersWithIds_Result cRMspSelectCentersWithIds_Result2 = new CRMspSelectCentersWithIds_Result();
						List<CRMspSelectCentersWithIds_Result> withIds = Center.GetWithIds(cId);
						if (withIds.Count <= 0)
						{
							list[0].Errors.Add(Messages.msgErrorCenterNotFound);
							return list;
						}
						cRMspSelectCentersWithIds_Result2 = withIds[0];
						list[0].Centers[0].Id = cRMspSelectCentersWithIds_Result2.CenterID;
						list[0].Centers[0].Title = cRMspSelectCentersWithIds_Result2.CenterName;
						list[0].Centers[0].Code = cRMspSelectCentersWithIds_Result2.CenterCode;
						list[0].Centers[0].Obj = cRMspSelectCentersWithIds_Result2;
						if (string.IsNullOrWhiteSpace(cRMspSelectCentersWithIds_Result2.LinkAccCenterCode))
						{
							list[0].Centers[0].Errors.Add(string.Format(Messages.msgErrorOtherSystemsNotFindCenter, cRMspSelectCentersWithIds_Result2.CenterName, CS_0024_003C_003E8__locals0.cmp.CompanyName, CS_0024_003C_003E8__locals0.cmp.cmpNumber, Labels.Hamyar));
							return list;
						}
						string value = CS_0024_003C_003E8__locals0.cmp.cmpLinkAccData ?? "";
						List<LinkAccDataViewModel> list4 = new List<LinkAccDataViewModel>();
						if (!string.IsNullOrWhiteSpace(value))
						{
							list4 = JsonConvert.DeserializeObject<List<LinkAccDataViewModel>>(value);
							if (list4 == null)
							{
								list4 = new List<LinkAccDataViewModel>();
							}
						}
						HamyarCustomerDefineViewModel hamyarCustomerDefineViewModel = new HamyarCustomerDefineViewModel();
						hamyarCustomerDefineViewModel.centerCode = long.Parse(cRMspSelectCentersWithIds_Result2.LinkAccCenterCode);
						hamyarCustomerDefineViewModel.bankCode = 0L;
						hamyarCustomerDefineViewModel.shobehBankCode = 0L;
						hamyarCustomerDefineViewModel.address2 = null;
						hamyarCustomerDefineViewModel.shomarehParvande = "";
						hamyarCustomerDefineViewModel.codeKargah = "";
						hamyarCustomerDefineViewModel.codeOstanKargah = 0L;
						hamyarCustomerDefineViewModel.codeShahrKargah = 0L;
						hamyarCustomerDefineViewModel.codeNaghshTejari = "";
						hamyarCustomerDefineViewModel.codeShobehKharidar = "";
						hamyarCustomerDefineViewModel.noeVahed = 0L;
						List<LkCrmCompanyGroupsIIIViewModel> crmGroupsIII = _Hamyar.GetCrmGroupsIII();
						if (crmGroupsIII != null)
						{
							LkCrmCompanyGroupsIIIViewModel lkCrmCompanyGroupsIIIViewModel = Enumerable.FirstOrDefault<LkCrmCompanyGroupsIIIViewModel>((IEnumerable<LkCrmCompanyGroupsIIIViewModel>)crmGroupsIII, (Func<LkCrmCompanyGroupsIIIViewModel, bool>)((LkCrmCompanyGroupsIIIViewModel x) => x.CompanyGroupIIIID == CS_0024_003C_003E8__locals0.cmp.cmpGroupIdIII));
							if (lkCrmCompanyGroupsIIIViewModel != null)
							{
								hamyarCustomerDefineViewModel.noeVahed = long.Parse(lkCrmCompanyGroupsIIIViewModel.LinkAccId);
							}
						}
						hamyarCustomerDefineViewModel.phone1 = CS_0024_003C_003E8__locals0.cmp.cmpPreTel + CS_0024_003C_003E8__locals0.cmp.cmpTel + CS_0024_003C_003E8__locals0.cmp.cmpTelUpTo;
						hamyarCustomerDefineViewModel.phone2 = CS_0024_003C_003E8__locals0.cmp.cmpPreTelII + CS_0024_003C_003E8__locals0.cmp.cmpTelII + CS_0024_003C_003E8__locals0.cmp.cmpTelUpToII;
						if (string.IsNullOrWhiteSpace(hamyarCustomerDefineViewModel.phone2))
						{
							hamyarCustomerDefineViewModel.phone2 = null;
						}
						hamyarCustomerDefineViewModel.address1 = CS_0024_003C_003E8__locals0.cmp.cmpAddress;
						hamyarCustomerDefineViewModel.codePosti = CS_0024_003C_003E8__locals0.cmp.cmpZipCode;
						hamyarCustomerDefineViewModel.fax = CS_0024_003C_003E8__locals0.cmp.cmpFax;
						hamyarCustomerDefineViewModel.siteAddress = CS_0024_003C_003E8__locals0.cmp.cmpWebSite;
						hamyarCustomerDefineViewModel.shomarehEghtesadi = CS_0024_003C_003E8__locals0.cmp.cmpEconomicCode;
						hamyarCustomerDefineViewModel.tarikhJazbMoshtari = CS_0024_003C_003E8__locals0.cmp.FirstRegisterDate?.ToString("yyyy/MM/dd", new CultureInfo("fa-IR"));
						hamyarCustomerDefineViewModel.mahaiatFaliatTafsili = 0L;
						List<CRMspSelectCompanyGroupsWithAccLinkField_Result> list5 = Enumerable.ToList<CRMspSelectCompanyGroupsWithAccLinkField_Result>((IEnumerable<CRMspSelectCompanyGroupsWithAccLinkField_Result>)cRMLinkSpEntities.CRMspSelectCompanyGroupsWithAccLinkField(lCID, result, true, false));
						if (list5 != null)
						{
							CRMspSelectCompanyGroupsWithAccLinkField_Result cRMspSelectCompanyGroupsWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyGroupsWithAccLinkField_Result>((IEnumerable<CRMspSelectCompanyGroupsWithAccLinkField_Result>)list5, (Func<CRMspSelectCompanyGroupsWithAccLinkField_Result, bool>)((CRMspSelectCompanyGroupsWithAccLinkField_Result x) => x.CompanyGroupID == CS_0024_003C_003E8__locals0.cmp.cmpGroupId));
							if (cRMspSelectCompanyGroupsWithAccLinkField_Result != null && !string.IsNullOrWhiteSpace(cRMspSelectCompanyGroupsWithAccLinkField_Result.LinkAccGroupIdStr))
							{
								hamyarCustomerDefineViewModel.mahaiatFaliatTafsili = long.Parse(cRMspSelectCompanyGroupsWithAccLinkField_Result.LinkAccGroupIdStr);
							}
						}
						List<CRMspSelectLinkAccSetting_Result> crmSetting = _Hamyar.GetCrmSetting(false);
						if (CS_0024_003C_003E8__locals0.cmp.cmpKind == 0)
						{
							hamyarCustomerDefineViewModel.moadiTypeEnum = long.Parse(Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)crmSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "LegalMoadiType")).PartValue);
							hamyarCustomerDefineViewModel.companyName = CS_0024_003C_003E8__locals0.cmp.CompanyName;
							hamyarCustomerDefineViewModel.shomarehSabt = CS_0024_003C_003E8__locals0.cmp.cmpRegistrationNumber;
							hamyarCustomerDefineViewModel.namayandehKharid = CS_0024_003C_003E8__locals0.cmp.cmpMainPerson;
							hamyarCustomerDefineViewModel.modirAmelName = CS_0024_003C_003E8__locals0.cmp.cmpMainPerson;
							hamyarCustomerDefineViewModel.mobileNumber = CS_0024_003C_003E8__locals0.cmp.cmpMobile;
							hamyarCustomerDefineViewModel.codeMeli = CS_0024_003C_003E8__locals0.cmp.cmpNationalCode;
							hamyarCustomerDefineViewModel.email = CS_0024_003C_003E8__locals0.cmp.cmpEmail;
						}
						else if (CS_0024_003C_003E8__locals0.cmp.cmpKind.GetValueOrDefault() == 1)
						{
							hamyarCustomerDefineViewModel.moadiTypeEnum = long.Parse(Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)crmSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "RealMoadiType")).PartValue);
							if (companyPerson == null)
							{
								list[0].Centers[0].Errors.Add(Messages.PersonNotFound);
							}
							else
							{
								hamyarCustomerDefineViewModel.firstName = companyPerson.prsFName;
								hamyarCustomerDefineViewModel.lastName = companyPerson.prsLName;
								hamyarCustomerDefineViewModel.tarikhTavalod = companyPerson.prsBirthDateTime?.ToString("yyyy/MM/dd", new CultureInfo("fa-IR"));
								hamyarCustomerDefineViewModel.mobileNumber = companyPerson.prsMobile;
								hamyarCustomerDefineViewModel.codeMeli = companyPerson.prsNationalCode;
								hamyarCustomerDefineViewModel.email = companyPerson.prsEmail;
							}
						}
						if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.cmp.LinkAccCityIdStr))
						{
							hamyarCustomerDefineViewModel.cityCode = long.Parse(CS_0024_003C_003E8__locals0.cmp.LinkAccCityIdStr);
							hamyarCustomerDefineViewModel.codeShahrKargah = hamyarCustomerDefineViewModel.cityCode;
						}
						if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.cmp.LinkAccProvinceIdStr))
						{
							hamyarCustomerDefineViewModel.codeOstanKargah = long.Parse(CS_0024_003C_003E8__locals0.cmp.LinkAccProvinceIdStr);
						}
						if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.cmp.LinkAccCountryIdStr))
						{
							hamyarCustomerDefineViewModel.countryCode = long.Parse(CS_0024_003C_003E8__locals0.cmp.LinkAccCountryIdStr);
						}
						if (AdvanceResultViewModel.GetErrorsCnt(list) == 0)
						{
							string text2 = _Hamyar.ApiAddress + "addCustomer";
							HttpClient httpClient = new HttpClient();
							httpClient.BaseAddress = new Uri(text2);
							httpClient.DefaultRequestHeaders.Add("X-API-KEY", _Hamyar.ApiKey);
							httpClient.DefaultRequestHeaders.Add("Authorization", _Hamyar.GetToken());
							httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
							HttpContent content = new StringContent(JsonConvert.SerializeObject(hamyarCustomerDefineViewModel), Encoding.UTF8, "application/json");
							new HttpResponseMessage();
							string result3 = httpClient.PostAsync(text2, content).Result.Content.ReadAsStringAsync().Result;
							if (!string.IsNullOrWhiteSpace(result3))
							{
								result3 = result3.ClearHiddenCharacters();
								HamyarAPIResponseViewModel<HamyarInsertCompanyResponseViewModel> hamyarAPIResponseViewModel = JsonConvert.DeserializeObject<HamyarAPIResponseViewModel<HamyarInsertCompanyResponseViewModel>>(result3);
								if (hamyarAPIResponseViewModel != null)
								{
									if (hamyarAPIResponseViewModel.isSuccess.GetValueOrDefault() || hamyarAPIResponseViewModel.data != null)
									{
										DbSet<CrmCompany> crmCompany = cRMTabelEntities.CrmCompany;
										ParameterExpression val = Expression.Parameter(typeof(CrmCompany), "m");
										CrmCompany crmCompany2 = Queryable.FirstOrDefault<CrmCompany>((IQueryable<CrmCompany>)crmCompany, Expression.Lambda<Func<CrmCompany, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass5_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
										if (crmCompany2 != null)
										{
											int num = list4.FindIndex((LinkAccDataViewModel x) => x.CId == int.Parse(cId));
											if (num == -1)
											{
												list4.Add(new LinkAccDataViewModel
												{
													CId = int.Parse(cId),
													FTDate = DateTime.Now,
													LTDate = DateTime.Now,
													DBId = 0,
													Id = "0",
													Code = hamyarAPIResponseViewModel.data.tafsiliCode.ToString()
												});
												crmCompany2.cmpLinkAccFirstTransferDate = DateTime.Now;
												list[0].Success = "Link";
											}
											else
											{
												list4[num].LTDate = DateTime.Now;
												list4[num].Code = hamyarAPIResponseViewModel.data.tafsiliCode.ToString();
												list[0].Success = "Update";
											}
											crmCompany2.cmpLinkAccLastTransferDate = DateTime.Now;
											crmCompany2.cmpLinkAccData = JsonConvert.SerializeObject(list4);
											cRMTabelEntities.Entry(crmCompany2).State = EntityState.Modified;
											cRMTabelEntities.SaveChanges();
											list[0].Status = CommonResultStatusViewModel.Success;
										}
									}
									else if (hamyarAPIResponseViewModel.errors != null && Enumerable.Count<string>((IEnumerable<string>)hamyarAPIResponseViewModel.errors) > 0)
									{
										for (int j = 0; j < Enumerable.Count<string>((IEnumerable<string>)hamyarAPIResponseViewModel.errors); j++)
										{
											list[0].Centers[0].Errors.Add(hamyarAPIResponseViewModel.errors[j]);
										}
									}
									else
									{
										list[0].Centers[0].Errors.Add(hamyarAPIResponseViewModel.message ?? Messages.ErrorEmptyServerResult);
									}
								}
							}
							else
							{
								list[0].Centers[0].Errors.Add(Messages.ErrorEmptyServerResult);
							}
						}
					}
					else
					{
						list[0].Errors.Add(Messages.CompanyNotFound);
					}
				}
				catch (Exception ex)
				{
					Public.InsExceptToElmah(ex);
					list[0].Errors.Add(Messages.MsgErrorDoneOperation + ": " + ex.Message);
				}
				finally
				{
					cRMSpEntities.Dispose();
					cRMLinkSpEntities.Dispose();
					cRMTabelEntities.Dispose();
				}
				return list;
			}

			public string GetStringResult(int? centerId = 0)
			{
				string text = "";
				try
				{
					foreach (AdvanceResultViewModel item in SendCompanyMain(centerId, false))
					{
						if (item.Errors == null)
						{
							continue;
						}
						foreach (string error in item.Errors)
						{
							text = text + error + "|";
						}
					}
				}
				catch (Exception ex)
				{
					Public.InsExceptToElmah(ex);
					text = text + "Error|" + ex.Message;
				}
				return text;
			}

			public List<AdvanceResultViewModel> GetFullResult(int? centerId = 0)
			{
				return SendCompanyMain(centerId, false);
			}
		}

		public const int LinkAccSystemId = 21;

		public const string _KeyName_Address = "ApiAddress";

		public const string _KeyName_Key = "ApiKey";

		public const string _KeyName_Username = "ApiUsername";

		public const string _KeyName_Password = "ApiPassword";

		public const string _KeyName_LegalMoadiType = "LegalMoadiType";

		public const string _KeyName_RealMoadiType = "RealMoadiType";

		private static string _ApiAddress = "";

		private static string _ApiKey = "";

		private static string _ApiUsername = "";

		private static string _ApiPassword = "";

		private static List<CRMspSelectLinkAccSetting_Result> _CrmSetting = null;

		private static string _Access_Token = "";

		private static string _Refresh_Token = "";

		private List<LkCrmCompanyGroupsIIIViewModel> _Vaheds;

		public string _LinkAccName => Labels.Hamyar;

		public string ApiAddress
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_ApiAddress))
				{
					_ApiAddress = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)GetCrmSetting(false), (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "ApiAddress")).PartValue ?? "";
				}
				return _ApiAddress;
			}
		}

		public string ApiKey
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_ApiKey))
				{
					_ApiKey = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)GetCrmSetting(false), (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "ApiKey")).PartValue ?? "";
				}
				return _ApiKey;
			}
		}

		public string ApiUsername
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_ApiUsername))
				{
					_ApiUsername = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)GetCrmSetting(false), (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "ApiUsername")).PartValue ?? "";
				}
				return _ApiUsername;
			}
		}

		public string ApiPassword
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_ApiPassword))
				{
					_ApiPassword = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)GetCrmSetting(false), (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "ApiPassword")).PartValue ?? "";
				}
				return _ApiPassword;
			}
		}

		public HamyarProvider(bool? getVahed = false)
		{
			GetCrmSetting(false);
			GetToken();
			GetVahed(getVahed.GetValueOrDefault());
		}

		public List<CRMspSelectLinkAccSetting_Result> GetCrmSetting(bool? readAgain = false)
		{
			if (!readAgain.GetValueOrDefault() && _CrmSetting != null)
			{
				return _CrmSetting;
			}
			List<CRMspSelectLinkAccSetting_Result> result = new List<CRMspSelectLinkAccSetting_Result>();
			CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
			try
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
				if (result2 <= 0)
				{
					result2 = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				int value = 21;
				int value2 = -1;
				List<CRMspSelectLinkAccSetting_Result> list = Enumerable.ToList<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)cRMLinkSpEntities.CRMspSelectLinkAccSetting(0, "", lCID, result2, value, value2, null));
				if (list != null)
				{
					if (!(Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "ApiAddress")).PartValue ?? "").EndsWith("/"))
					{
						Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "ApiAddress")).PartValue += "/";
					}
					result = list;
				}
			}
			catch (Exception ex)
			{
				Public.InsExceptToElmah(ex);
			}
			cRMLinkSpEntities.Dispose();
			return result;
		}

		public static CRMspSelectLinkAccSettingDetails_Result GetCrmSettingDetails(int settingDetailId = 0, int objId = 0, string objectType = "", string partTitle = "")
		{
			CRMspSelectLinkAccSettingDetails_Result result = new CRMspSelectLinkAccSettingDetails_Result();
			CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
			try
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
				if (result2 <= 0)
				{
					result2 = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				int value = 21;
				int value2 = -1;
				if (settingDetailId < 0)
				{
					settingDetailId = 0;
				}
				List<CRMspSelectLinkAccSettingDetails_Result> list = Enumerable.ToList<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)cRMLinkSpEntities.CRMspSelectLinkAccSettingDetails(settingDetailId, objId, objectType, lCID, result2, value, value2));
				if (list != null)
				{
					result = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == partTitle));
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
			finally
			{
				cRMLinkSpEntities.Dispose();
			}
			return result;
		}

		public string GetToken(bool getNew = false)
		{
			try
			{
				string apiAddress = ApiAddress;
				HamyarTokenViewModel value = new HamyarTokenViewModel
				{
					username = ApiUsername,
					password = ApiPassword
				};
				apiAddress += "api/Auth/login";
				if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)GetCrmSetting(false), (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "CRMActiveTls12")).PartValue.ToLower().Trim() == "true")
				{
					ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
				}
				HttpClient httpClient = new HttpClient();
				httpClient.BaseAddress = new Uri(apiAddress);
				httpClient.DefaultRequestHeaders.Add("X-API-KEY", ApiKey);
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				HttpContent content = new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8, "application/json");
				new HttpResponseMessage();
				string value2 = httpClient.PostAsync(apiAddress, content).Result.Content.ReadAsStringAsync().Result;
				if (!string.IsNullOrWhiteSpace(value2))
				{
					value2 = value2.ClearHiddenCharacters();
				}
				if (!string.IsNullOrWhiteSpace(value2))
				{
					HamyarAPIResponseViewModel<HamyarTokenResponseViewModel> hamyarAPIResponseViewModel = JsonConvert.DeserializeObject<HamyarAPIResponseViewModel<HamyarTokenResponseViewModel>>(value2);
					if (hamyarAPIResponseViewModel != null && hamyarAPIResponseViewModel.data != null && hamyarAPIResponseViewModel.isSuccess.GetValueOrDefault())
					{
						_Access_Token = hamyarAPIResponseViewModel.data.accessToken ?? "";
						_Refresh_Token = hamyarAPIResponseViewModel.data.refreshToken ?? "";
						if (!string.IsNullOrWhiteSpace(_Access_Token))
						{
							_Access_Token = "Bearer " + _Access_Token;
						}
					}
				}
			}
			catch (Exception ex)
			{
				Public.InsExceptToElmah(ex);
			}
			return _Access_Token;
		}

		public List<LkProvinceInfoViewModel> GetProvinces(string countryCode, bool secRead = false, long? pageSize = 1L)
		{
			List<LkProvinceInfoViewModel> list = new List<LkProvinceInfoViewModel>();
			CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
			try
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				string text = ApiAddress + "getAllProvinces";
				HttpClient httpClient = new HttpClient();
				httpClient.BaseAddress = new Uri(text);
				httpClient.DefaultRequestHeaders.Add("X-API-KEY", ApiKey);
				httpClient.DefaultRequestHeaders.Add("Authorization", GetToken());
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
				httpResponseMessage = httpClient.GetAsync(text + "?countryCode=" + countryCode + "&pageIndex=1&pageSize=" + pageSize.GetValueOrDefault(1L)).Result;
				if (httpResponseMessage.IsSuccessStatusCode)
				{
					string result2 = httpResponseMessage.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(result2))
					{
						result2 = result2.ClearHiddenCharacters();
						HamyarAPIResponseViewModel<List<HamyarProvinceInfoViewModel>> hamyarAPIResponseViewModel = JsonConvert.DeserializeObject<HamyarAPIResponseViewModel<List<HamyarProvinceInfoViewModel>>>(result2);
						if (hamyarAPIResponseViewModel != null && hamyarAPIResponseViewModel.data != null && hamyarAPIResponseViewModel.isSuccess.GetValueOrDefault())
						{
							if (secRead)
							{
								List<CRMspSelectProvinceWithAccLinkField_Result> list2 = Enumerable.ToList<CRMspSelectProvinceWithAccLinkField_Result>((IEnumerable<CRMspSelectProvinceWithAccLinkField_Result>)cRMLinkSpEntities.CRMspSelectProvinceWithAccLinkField(true, lCID, result, false));
								int num = 1;
								foreach (HamyarProvinceInfoViewModel p in hamyarAPIResponseViewModel.data)
								{
									LkProvinceInfoViewModel lkProvinceInfoViewModel = new LkProvinceInfoViewModel();
									lkProvinceInfoViewModel.LinkAccProvinceIdStr = p.codeProvince.ToString();
									lkProvinceInfoViewModel.Province = p.provinceName;
									lkProvinceInfoViewModel.Selected = true;
									if (list2 != null)
									{
										CRMspSelectProvinceWithAccLinkField_Result cRMspSelectProvinceWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectProvinceWithAccLinkField_Result>((IEnumerable<CRMspSelectProvinceWithAccLinkField_Result>)list2, (Func<CRMspSelectProvinceWithAccLinkField_Result, bool>)((CRMspSelectProvinceWithAccLinkField_Result x) => x.LinkAccProvinceIdStr == p.codeProvince.ToString()));
										if (cRMspSelectProvinceWithAccLinkField_Result != null)
										{
											lkProvinceInfoViewModel.ProvinceID = cRMspSelectProvinceWithAccLinkField_Result.ProvinceID;
											lkProvinceInfoViewModel.CountryId = cRMspSelectProvinceWithAccLinkField_Result.CountryID;
											lkProvinceInfoViewModel.ProvinceCode = cRMspSelectProvinceWithAccLinkField_Result.ProvinceCode;
											lkProvinceInfoViewModel.Province = cRMspSelectProvinceWithAccLinkField_Result.Province;
											lkProvinceInfoViewModel.Description = cRMspSelectProvinceWithAccLinkField_Result.Description;
											lkProvinceInfoViewModel.LinkAccProvinceIdStr = cRMspSelectProvinceWithAccLinkField_Result.LinkAccProvinceIdStr;
											lkProvinceInfoViewModel.CountryName = cRMspSelectProvinceWithAccLinkField_Result.CountryName;
											lkProvinceInfoViewModel.RowNumber = num++;
											lkProvinceInfoViewModel.Selected = false;
											lkProvinceInfoViewModel.GUId = Guid.NewGuid();
										}
									}
									list.Add(lkProvinceInfoViewModel);
								}
							}
							else
							{
								list.AddRange(GetProvinces(countryCode, secRead: true, hamyarAPIResponseViewModel.totalItems));
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				Public.InsExceptToElmah(ex);
			}
			cRMLinkSpEntities.Dispose();
			return list;
		}

		public List<LkProvinceInfoViewModel> GetProvinces(bool readAllDbCountries)
		{
			List<LkProvinceInfoViewModel> list = new List<LkProvinceInfoViewModel>();
			CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
			try
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				List<CRMspSelectCountryWithAccLinkField_Result> list2 = Enumerable.ToList<CRMspSelectCountryWithAccLinkField_Result>((IEnumerable<CRMspSelectCountryWithAccLinkField_Result>)cRMLinkSpEntities.CRMspSelectCountryWithAccLinkField(true, lCID, result, false));
				if (list2 != null)
				{
					for (int i = 0; i < Enumerable.Count<CRMspSelectCountryWithAccLinkField_Result>((IEnumerable<CRMspSelectCountryWithAccLinkField_Result>)list2); i++)
					{
						if (string.IsNullOrWhiteSpace(list2[i].LinkAccCountryIdStr))
						{
							continue;
						}
						List<LkProvinceInfoViewModel> provinces = GetProvinces(list2[i].LinkAccCountryIdStr, secRead: false, 1L);
						foreach (LkProvinceInfoViewModel item in provinces)
						{
							item.CountryId = list2[i].CountryID;
							item.CountryName = list2[i].Country;
						}
						list.AddRange(provinces);
					}
				}
			}
			catch (Exception ex)
			{
				Public.InsExceptToElmah(ex);
			}
			return list;
		}

		public List<LkCityInfoViewModel> GetCities(string provinceCode, bool secRead = false, long? pageSize = 1L)
		{
			List<LkCityInfoViewModel> list = new List<LkCityInfoViewModel>();
			CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
			try
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				int countryId = 0;
				string text = "";
				List<CRMspSelectProvinceWithAccLinkField_Result> list2 = Enumerable.ToList<CRMspSelectProvinceWithAccLinkField_Result>((IEnumerable<CRMspSelectProvinceWithAccLinkField_Result>)cRMLinkSpEntities.CRMspSelectProvinceWithAccLinkField(true, lCID, result, false));
				if (list2 != null)
				{
					CRMspSelectProvinceWithAccLinkField_Result cRMspSelectProvinceWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectProvinceWithAccLinkField_Result>((IEnumerable<CRMspSelectProvinceWithAccLinkField_Result>)list2, (Func<CRMspSelectProvinceWithAccLinkField_Result, bool>)((CRMspSelectProvinceWithAccLinkField_Result x) => x.LinkAccProvinceIdStr == provinceCode));
					if (cRMspSelectProvinceWithAccLinkField_Result != null)
					{
						countryId = cRMspSelectProvinceWithAccLinkField_Result.CountryID;
						List<CRMspSelectCountryWithAccLinkField_Result> list3 = Enumerable.ToList<CRMspSelectCountryWithAccLinkField_Result>((IEnumerable<CRMspSelectCountryWithAccLinkField_Result>)cRMLinkSpEntities.CRMspSelectCountryWithAccLinkField(true, lCID, result, false));
						if (list3 != null)
						{
							CRMspSelectCountryWithAccLinkField_Result cRMspSelectCountryWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectCountryWithAccLinkField_Result>((IEnumerable<CRMspSelectCountryWithAccLinkField_Result>)list3, (Func<CRMspSelectCountryWithAccLinkField_Result, bool>)((CRMspSelectCountryWithAccLinkField_Result x) => x.CountryID == countryId));
							if (cRMspSelectCountryWithAccLinkField_Result != null)
							{
								text = cRMspSelectCountryWithAccLinkField_Result.LinkAccCountryIdStr;
							}
						}
					}
				}
				string text2 = ApiAddress + "getAllCities";
				HttpClient httpClient = new HttpClient();
				httpClient.BaseAddress = new Uri(text2);
				httpClient.DefaultRequestHeaders.Add("X-API-KEY", ApiKey);
				httpClient.DefaultRequestHeaders.Add("Authorization", GetToken());
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
				httpResponseMessage = httpClient.GetAsync(text2 + "?countryCode=" + text + "&provinceCode=" + provinceCode + "&pageIndex=1&pageSize=" + pageSize.GetValueOrDefault(1L)).Result;
				if (httpResponseMessage.IsSuccessStatusCode)
				{
					string result2 = httpResponseMessage.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(result2))
					{
						result2 = result2.ClearHiddenCharacters();
						HamyarAPIResponseViewModel<List<HamyarCityInfoViewModel>> hamyarAPIResponseViewModel = JsonConvert.DeserializeObject<HamyarAPIResponseViewModel<List<HamyarCityInfoViewModel>>>(result2);
						if (hamyarAPIResponseViewModel != null && hamyarAPIResponseViewModel.data != null && hamyarAPIResponseViewModel.isSuccess.GetValueOrDefault())
						{
							if (secRead)
							{
								List<CRMspSelectCityWithAccLinkField_Result> list4 = Enumerable.ToList<CRMspSelectCityWithAccLinkField_Result>((IEnumerable<CRMspSelectCityWithAccLinkField_Result>)cRMLinkSpEntities.CRMspSelectCityWithAccLinkField(true, lCID, result, false));
								int num = 1;
								foreach (HamyarCityInfoViewModel p in hamyarAPIResponseViewModel.data)
								{
									LkCityInfoViewModel lkCityInfoViewModel = new LkCityInfoViewModel();
									lkCityInfoViewModel.LinkAccCityIdStr = p.codeCity.ToString();
									lkCityInfoViewModel.City = p.cityName;
									lkCityInfoViewModel.Selected = true;
									if (list4 != null)
									{
										CRMspSelectCityWithAccLinkField_Result cRMspSelectCityWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectCityWithAccLinkField_Result>((IEnumerable<CRMspSelectCityWithAccLinkField_Result>)list4, (Func<CRMspSelectCityWithAccLinkField_Result, bool>)((CRMspSelectCityWithAccLinkField_Result x) => x.LinkAccCityIdStr == p.codeCity.ToString()));
										if (cRMspSelectCityWithAccLinkField_Result != null)
										{
											lkCityInfoViewModel.CityID = cRMspSelectCityWithAccLinkField_Result.CityID;
											lkCityInfoViewModel.ProvinceId = cRMspSelectCityWithAccLinkField_Result.ProvinceId;
											lkCityInfoViewModel.CityCode = cRMspSelectCityWithAccLinkField_Result.CityCode;
											lkCityInfoViewModel.City = cRMspSelectCityWithAccLinkField_Result.City;
											lkCityInfoViewModel.Description = cRMspSelectCityWithAccLinkField_Result.Description;
											lkCityInfoViewModel.LinkAccCityIdStr = cRMspSelectCityWithAccLinkField_Result.LinkAccCityIdStr;
											lkCityInfoViewModel.ProvinceName = cRMspSelectCityWithAccLinkField_Result.ProvinceName;
											lkCityInfoViewModel.RowNumber = num++;
											lkCityInfoViewModel.Selected = false;
											lkCityInfoViewModel.GUId = Guid.NewGuid();
										}
									}
									list.Add(lkCityInfoViewModel);
								}
							}
							else
							{
								list.AddRange(GetCities(provinceCode, secRead: true, hamyarAPIResponseViewModel.totalItems));
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				Public.InsExceptToElmah(ex);
			}
			cRMLinkSpEntities.Dispose();
			return list;
		}

		public List<LkCityInfoViewModel> GetCities(bool readAllDbProvinces)
		{
			List<LkCityInfoViewModel> list = new List<LkCityInfoViewModel>();
			CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
			try
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				List<CRMspSelectProvinceWithAccLinkField_Result> list2 = Enumerable.ToList<CRMspSelectProvinceWithAccLinkField_Result>((IEnumerable<CRMspSelectProvinceWithAccLinkField_Result>)cRMLinkSpEntities.CRMspSelectProvinceWithAccLinkField(true, lCID, result, false));
				if (list2 != null)
				{
					for (int i = 0; i < Enumerable.Count<CRMspSelectProvinceWithAccLinkField_Result>((IEnumerable<CRMspSelectProvinceWithAccLinkField_Result>)list2); i++)
					{
						if (string.IsNullOrWhiteSpace(list2[i].LinkAccProvinceIdStr))
						{
							continue;
						}
						List<LkCityInfoViewModel> cities = GetCities(list2[i].LinkAccProvinceIdStr, secRead: false, 1L);
						foreach (LkCityInfoViewModel item in cities)
						{
							item.ProvinceId = list2[i].ProvinceID;
							item.ProvinceName = list2[i].Province;
						}
						list.AddRange(cities);
					}
				}
			}
			catch (Exception ex)
			{
				Public.InsExceptToElmah(ex);
			}
			return list;
		}

		public List<LkCenterInfoViewModel> GetCenters()
		{
			List<LkCenterInfoViewModel> list = new List<LkCenterInfoViewModel>();
			try
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				_ = Thread.CurrentThread.CurrentCulture.LCID;
				string text = ApiAddress + "getAllCenters";
				HttpClient httpClient = new HttpClient();
				httpClient.BaseAddress = new Uri(text);
				httpClient.DefaultRequestHeaders.Add("X-API-KEY", ApiKey);
				httpClient.DefaultRequestHeaders.Add("Authorization", GetToken());
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
				httpResponseMessage = httpClient.GetAsync(text).Result;
				if (httpResponseMessage.IsSuccessStatusCode)
				{
					string result2 = httpResponseMessage.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(result2))
					{
						result2 = result2.ClearHiddenCharacters();
						HamyarAPIResponseViewModel<List<HamyarCenterInfoViewModel>> hamyarAPIResponseViewModel = JsonConvert.DeserializeObject<HamyarAPIResponseViewModel<List<HamyarCenterInfoViewModel>>>(result2);
						if (hamyarAPIResponseViewModel != null && hamyarAPIResponseViewModel.data != null && hamyarAPIResponseViewModel.isSuccess.GetValueOrDefault())
						{
							foreach (HamyarCenterInfoViewModel datum in hamyarAPIResponseViewModel.data)
							{
								LkCenterInfoViewModel lkCenterInfoViewModel = new LkCenterInfoViewModel();
								lkCenterInfoViewModel.LinkAccCenterCode = datum.code;
								lkCenterInfoViewModel.CenterName = datum.centerName;
								list.Add(lkCenterInfoViewModel);
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				Public.InsExceptToElmah(ex);
			}
			return list;
		}

		public List<SelectListItem> GetMoadiType()
		{
			List<SelectListItem> list = new List<SelectListItem>();
			try
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				_ = Thread.CurrentThread.CurrentCulture.LCID;
				string text = ApiAddress + "Customer/Moadi-Type";
				HttpClient httpClient = new HttpClient();
				httpClient.BaseAddress = new Uri(text);
				httpClient.DefaultRequestHeaders.Add("X-API-KEY", ApiKey);
				httpClient.DefaultRequestHeaders.Add("Authorization", GetToken());
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
				httpResponseMessage = httpClient.GetAsync(text).Result;
				if (httpResponseMessage.IsSuccessStatusCode)
				{
					string result2 = httpResponseMessage.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(result2))
					{
						result2 = result2.ClearHiddenCharacters();
						HamyarAPIResponseViewModel<List<object>> hamyarAPIResponseViewModel = JsonConvert.DeserializeObject<HamyarAPIResponseViewModel<List<object>>>(result2);
						if (hamyarAPIResponseViewModel != null && hamyarAPIResponseViewModel.data != null && hamyarAPIResponseViewModel.isSuccess.GetValueOrDefault())
						{
							foreach (dynamic datum in hamyarAPIResponseViewModel.data)
							{
								SelectListItem selectListItem = new SelectListItem();
								selectListItem.Text = datum.name;
								selectListItem.Value = datum.value;
								list.Add(selectListItem);
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				Public.InsExceptToElmah(ex);
			}
			return list;
		}

		public List<LkCrmCompanyGroupsViewModel> GetAllMahiatFaliatTafsili(string centerCode = "", int crmCenterId = 0)
		{
			List<LkCrmCompanyGroupsViewModel> list = new List<LkCrmCompanyGroupsViewModel>();
			CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
			try
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				if (string.IsNullOrWhiteSpace(centerCode) && crmCenterId != 0)
				{
					List<CRMspSelectCenterWithAccLinkField_Result> list2 = Enumerable.ToList<CRMspSelectCenterWithAccLinkField_Result>((IEnumerable<CRMspSelectCenterWithAccLinkField_Result>)cRMLinkSpEntities.CRMspSelectCenterWithAccLinkField(lCID, result, false, true, false));
					if (list2 != null)
					{
						CRMspSelectCenterWithAccLinkField_Result cRMspSelectCenterWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectCenterWithAccLinkField_Result>((IEnumerable<CRMspSelectCenterWithAccLinkField_Result>)list2, (Func<CRMspSelectCenterWithAccLinkField_Result, bool>)((CRMspSelectCenterWithAccLinkField_Result x) => x.CenterID == crmCenterId));
						if (cRMspSelectCenterWithAccLinkField_Result != null)
						{
							centerCode = cRMspSelectCenterWithAccLinkField_Result.LinkAccCenterCode ?? "";
						}
					}
				}
				string text = ApiAddress + "getAllMahiatFaliatTafsili";
				HttpClient httpClient = new HttpClient();
				httpClient.BaseAddress = new Uri(text);
				httpClient.DefaultRequestHeaders.Add("X-API-KEY", ApiKey);
				httpClient.DefaultRequestHeaders.Add("Authorization", GetToken());
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
				httpResponseMessage = httpClient.GetAsync(text + "?CenterCode=" + centerCode).Result;
				if (httpResponseMessage.IsSuccessStatusCode)
				{
					string result2 = httpResponseMessage.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(result2))
					{
						result2 = result2.ClearHiddenCharacters();
						HamyarAPIResponseViewModel<List<HamyarCrmCompanyGroupInfoViewModel>> hamyarAPIResponseViewModel = JsonConvert.DeserializeObject<HamyarAPIResponseViewModel<List<HamyarCrmCompanyGroupInfoViewModel>>>(result2);
						if (hamyarAPIResponseViewModel != null && hamyarAPIResponseViewModel.data != null && hamyarAPIResponseViewModel.isSuccess.GetValueOrDefault())
						{
							foreach (HamyarCrmCompanyGroupInfoViewModel datum in hamyarAPIResponseViewModel.data)
							{
								LkCrmCompanyGroupsViewModel lkCrmCompanyGroupsViewModel = new LkCrmCompanyGroupsViewModel();
								lkCrmCompanyGroupsViewModel.LinkAccGroupIdStr = datum.code.ToString();
								lkCrmCompanyGroupsViewModel.GroupName = datum.title;
								list.Add(lkCrmCompanyGroupsViewModel);
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				Public.InsExceptToElmah(ex);
			}
			finally
			{
				cRMLinkSpEntities.Dispose();
			}
			return list;
		}

		public List<LkCrmCompanyGroupsViewModel> GetAllMahiatFaliatTafsili(bool getAllCenters)
		{
			List<LkCrmCompanyGroupsViewModel> list = new List<LkCrmCompanyGroupsViewModel>();
			CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
			try
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				ObjectResult<CRMspSelectCenterWithAccLinkField_Result> objectResult = cRMLinkSpEntities.CRMspSelectCenterWithAccLinkField(lCID, result, false, true, false);
				if (objectResult != null)
				{
					foreach (CRMspSelectCenterWithAccLinkField_Result item in objectResult)
					{
						list.AddRange(GetAllMahiatFaliatTafsili(item.LinkAccCenterCode));
					}
				}
			}
			catch (Exception ex)
			{
				Public.InsExceptToElmah(ex);
			}
			finally
			{
				cRMLinkSpEntities.Dispose();
			}
			return list;
		}

		public List<LkCrmCompanyGroupsIIIViewModel> GetCrmGroupsIII()
		{
			List<LkCrmCompanyGroupsIIIViewModel> list = new List<LkCrmCompanyGroupsIIIViewModel>();
			List<CRMspSelectCompanyGroupsIII_Result> companyGroupsIII = Company.GetCompanyGroupsIII();
			list.AddRange(Enumerable.Select<CRMspSelectCompanyGroupsIII_Result, LkCrmCompanyGroupsIIIViewModel>((IEnumerable<CRMspSelectCompanyGroupsIII_Result>)companyGroupsIII, (Func<CRMspSelectCompanyGroupsIII_Result, LkCrmCompanyGroupsIIIViewModel>)((CRMspSelectCompanyGroupsIII_Result x) => new LkCrmCompanyGroupsIIIViewModel
			{
				CmpGroupIIIId = x.CompanyGroupIIIID,
				CompanyGroupIIIID = x.CompanyGroupIIIID,
				GroupIIIName = x.GroupIIIName
			})));
			foreach (CRMspSelectCompanyGroupsIII_Result itm in companyGroupsIII)
			{
				CRMspSelectLinkAccSettingDetails_Result crmSettingDetails = GetCrmSettingDetails(0, itm.CompanyGroupIIIID, "Company", "NoeVahed");
				if (crmSettingDetails != null && !string.IsNullOrWhiteSpace(crmSettingDetails.PartValue))
				{
					Enumerable.FirstOrDefault<LkCrmCompanyGroupsIIIViewModel>((IEnumerable<LkCrmCompanyGroupsIIIViewModel>)list, (Func<LkCrmCompanyGroupsIIIViewModel, bool>)((LkCrmCompanyGroupsIIIViewModel x) => x.CompanyGroupIIIID == itm.CompanyGroupIIIID)).LinkAccId = crmSettingDetails.PartValue;
					Enumerable.FirstOrDefault<LkCrmCompanyGroupsIIIViewModel>((IEnumerable<LkCrmCompanyGroupsIIIViewModel>)list, (Func<LkCrmCompanyGroupsIIIViewModel, bool>)((LkCrmCompanyGroupsIIIViewModel x) => x.CompanyGroupIIIID == itm.CompanyGroupIIIID)).LinkAccName = itm.GroupIIIName;
				}
			}
			return list;
		}

		public List<LkCrmCompanyGroupsIIIViewModel> GetVahed(bool readAgain = false)
		{
			if (_Vaheds != null && _Vaheds.Count > 0 && !readAgain)
			{
				return _Vaheds;
			}
			List<LkCrmCompanyGroupsIIIViewModel> list = new List<LkCrmCompanyGroupsIIIViewModel>();
			try
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				_ = Thread.CurrentThread.CurrentCulture.LCID;
				string text = ApiAddress + "Customer/Vahed-Type";
				HttpClient httpClient = new HttpClient();
				httpClient.BaseAddress = new Uri(text);
				httpClient.DefaultRequestHeaders.Add("X-API-KEY", ApiKey);
				httpClient.DefaultRequestHeaders.Add("Authorization", GetToken());
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				new HttpResponseMessage();
				string result2 = httpClient.GetAsync(text).Result.Content.ReadAsStringAsync().Result;
				if (!string.IsNullOrWhiteSpace(result2))
				{
					result2 = result2.ClearHiddenCharacters();
					List<CRMspSelectCompanyGroupsIII_Result> companyGroupsIII = Company.GetCompanyGroupsIII();
					HamyarAPIResponseViewModel<List<HamyarVahedInfoViewModel>> hamyarAPIResponseViewModel = JsonConvert.DeserializeObject<HamyarAPIResponseViewModel<List<HamyarVahedInfoViewModel>>>(result2);
					if (hamyarAPIResponseViewModel != null && hamyarAPIResponseViewModel.data != null && hamyarAPIResponseViewModel.isSuccess.GetValueOrDefault())
					{
						foreach (HamyarVahedInfoViewModel datum in hamyarAPIResponseViewModel.data)
						{
							LkCrmCompanyGroupsIIIViewModel vm = new LkCrmCompanyGroupsIIIViewModel();
							vm.LinkAccName = datum.name;
							vm.LinkAccId = datum.value.ToString();
							CRMspSelectLinkAccSettingDetails_Result crmSettingDetails = GetCrmSettingDetails(0, (int)datum.value, "Company", "NoeVahed");
							if (crmSettingDetails != null && crmSettingDetails.PartValue != null)
							{
								vm.CmpGroupIIIId = int.Parse(crmSettingDetails.PartValue);
								if (companyGroupsIII != null)
								{
									CRMspSelectCompanyGroupsIII_Result cRMspSelectCompanyGroupsIII_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyGroupsIII_Result>((IEnumerable<CRMspSelectCompanyGroupsIII_Result>)companyGroupsIII, (Func<CRMspSelectCompanyGroupsIII_Result, bool>)((CRMspSelectCompanyGroupsIII_Result x) => x.CompanyGroupIIIID == vm.CmpGroupIIIId));
									if (cRMspSelectCompanyGroupsIII_Result != null)
									{
										vm.CmpGroupIIIName = cRMspSelectCompanyGroupsIII_Result.GroupIIIName;
									}
								}
							}
							list.Add(vm);
						}
					}
				}
			}
			catch (Exception ex)
			{
				Public.InsExceptToElmah(ex);
			}
			_Vaheds = list;
			return list;
		}

		public List<SelectListItem> GetVahed_SelectListItem(bool readAgain = false, string selectedValue = "")
		{
			List<SelectListItem> list = new List<SelectListItem>();
			List<LkCrmCompanyGroupsIIIViewModel> vahed = GetVahed(readAgain);
			if (vahed != null)
			{
				list.AddRange(Enumerable.ToList<SelectListItem>(Enumerable.Select<LkCrmCompanyGroupsIIIViewModel, SelectListItem>((IEnumerable<LkCrmCompanyGroupsIIIViewModel>)vahed, (Func<LkCrmCompanyGroupsIIIViewModel, SelectListItem>)((LkCrmCompanyGroupsIIIViewModel x) => new SelectListItem
				{
					Text = x.LinkAccName,
					Value = x.LinkAccId,
					Selected = (x.LinkAccId == selectedValue)
				}))));
			}
			return list;
		}

		public List<AdvanceResultViewModel> SendPord(int pordId, bool? sendPordPayToAcc = false, bool? sendPordFilesToAcc = null)
		{
			List<AdvanceResultViewModel> list = new List<AdvanceResultViewModel>();
			list.Add(new AdvanceResultViewModel());
			CRMSpEntities cRMSpEntities = new CRMSpEntities();
			CRMTabelEntities cRMTabelEntities = new CRMTabelEntities();
			CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
			try
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				DateTime now = DateTime.Now;
				DateTime value = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				_ = Financial.Get().Id;
				short.Parse(Financial.Get().Id.ToString());
				short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				int userId = UserLogin.CurrentUser.UserId;
				CRMspSelectCenterWithAccLinkField_Result cRMspSelectCenterWithAccLinkField_Result = null;
				WSspSelectPreOrderWithId_Result pord = Enumerable.FirstOrDefault<WSspSelectPreOrderWithId_Result>((IEnumerable<WSspSelectPreOrderWithId_Result>)cRMSpEntities.WSspSelectPreOrderWithId(pordId, lCID, result));
				if (pord != null)
				{
					list[0].Id = pord.PreOrderID;
					list[0].Code = pord.pordNumber.ToString();
					list[0].Title = pord.pordDateTime?.ToString("yyyy/MM/dd HH:mm:ss");
					string errorMessage = "";
					if (!PreOrder.SendToLinkAccNeedVerify(pordId, ref errorMessage))
					{
						list[0].Errors.Add(errorMessage);
					}
					else
					{
						List<CRMspLkWSSelectPreOrderItems_Result> list2 = Enumerable.ToList<CRMspLkWSSelectPreOrderItems_Result>((IEnumerable<CRMspLkWSSelectPreOrderItems_Result>)cRMLinkSpEntities.CRMspLkWSSelectPreOrderItems(pordId, lCID, result));
						if (list2 == null || !Enumerable.Any<CRMspLkWSSelectPreOrderItems_Result>((IEnumerable<CRMspLkWSSelectPreOrderItems_Result>)list2))
						{
							list[0].Errors.Add(Messages.ErrorNotFound);
						}
						else
						{
							CRMspSelectCompanyById_Result companyById = Company.GetCompanyById(pord.pordCompanyId.GetValueOrDefault());
							List<CRMspSelectCenterWithAccLinkField_Result> list3 = Enumerable.ToList<CRMspSelectCenterWithAccLinkField_Result>((IEnumerable<CRMspSelectCenterWithAccLinkField_Result>)cRMLinkSpEntities.CRMspSelectCenterWithAccLinkField(lCID, result, true, true, true));
							if (companyById == null)
							{
								list[0].Errors.Add(Messages.CompanyNotFound);
							}
							else if (string.IsNullOrWhiteSpace(companyById.cmpLinkAccData))
							{
								list[0].Errors.Add(string.Format(Messages.msgErrorOtherSysCompanyNotLinked, companyById.CompanyName));
							}
							else
							{
								List<LinkAccDataViewModel> list4 = JsonConvert.DeserializeObject<List<LinkAccDataViewModel>>(companyById.cmpLinkAccData);
								if (list4.Count <= 0)
								{
									list[0].Errors.Add(string.Format(Messages.msgErrorOtherSysCompanyNotLinked, companyById.CompanyName));
								}
								else if (Enumerable.FirstOrDefault<LinkAccDataViewModel>((IEnumerable<LinkAccDataViewModel>)list4, (Func<LinkAccDataViewModel, bool>)((LinkAccDataViewModel x) => x.CId == pord.pordCId)) == null)
								{
									list[0].Errors.Add(string.Format(Messages.msgErrorOtherSysCompanyNotLinked, companyById.CompanyName));
								}
								else if (list3 == null)
								{
									list[0].Errors.Add(Messages.msgErrorCenterNotFound);
								}
								else
								{
									cRMspSelectCenterWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectCenterWithAccLinkField_Result>((IEnumerable<CRMspSelectCenterWithAccLinkField_Result>)list3, (Func<CRMspSelectCenterWithAccLinkField_Result, bool>)((CRMspSelectCenterWithAccLinkField_Result x) => x.CenterID == pord.pordCId));
									if (cRMspSelectCenterWithAccLinkField_Result == null)
									{
										list[0].Errors.Add(Messages.msgErrorCenterNotFound);
									}
									else if (string.IsNullOrWhiteSpace(cRMspSelectCenterWithAccLinkField_Result.LinkAccCenterCode))
									{
										list[0].Errors.Add(string.Format(Messages.msgErrorOtherSysCenterNotLinked, pord.pordCenterName));
									}
									else
									{
										HamyarPreOrderViewModel hamyarPreOrderViewModel = new HamyarPreOrderViewModel();
										hamyarPreOrderViewModel.centerCode = long.Parse(cRMspSelectCenterWithAccLinkField_Result.LinkAccCenterCode);
										hamyarPreOrderViewModel.tarikhSefaresh = pord.pordDateTime?.ToString("yyyy/MM/dd", new CultureInfo("fa-IR"));
										hamyarPreOrderViewModel.tarikhEtebarSefaresh = pord.pordExpireDateTime?.ToString("yyyy/MM/dd", new CultureInfo("fa-IR"));
										hamyarPreOrderViewModel.tarikhTahvilSefaresh = pord.pordDeliveryDateTime?.ToString("yyyy/MM/dd", new CultureInfo("fa-IR"));
										hamyarPreOrderViewModel.onvanSefareh = (string.IsNullOrWhiteSpace(pord.pordTitle) ? "" : pord.pordTitle);
										hamyarPreOrderViewModel.tozihat = (string.IsNullOrWhiteSpace(pord.pordDescriptionI) ? "" : pord.pordDescriptionI);
										hamyarPreOrderViewModel.shomarehSefareshCrm = pord.pordNumber.ToString();
										hamyarPreOrderViewModel.sefareshIdCrm = pord.PreOrderID.ToString();
										if (companyById.cmpKind == 0)
										{
											hamyarPreOrderViewModel.codeMeliMoshtari = companyById.cmpNationalCode;
										}
										else if (companyById.cmpKind.GetValueOrDefault() == 1)
										{
											CRMspSelectCompanyPersonsByID_Result companyPerson = GetCompanyPerson(companyById.CompanyID, null);
											if (companyPerson == null)
											{
												list[0].Errors.Add(Messages.msgErrorOtherSysCompanyNotLinked);
											}
											else
											{
												hamyarPreOrderViewModel.codeMeliMoshtari = companyPerson.prsNationalCode;
											}
										}
										int num = 1;
										int result2 = num;
										int num2 = 0;
										string tarikhSarResid = "";
										List<WSspSelectPreOrderPayments_Result> list5 = Enumerable.ToList<WSspSelectPreOrderPayments_Result>((IEnumerable<WSspSelectPreOrderPayments_Result>)cRMSpEntities.WSspSelectPreOrderPayments(pord.PreOrderID, lCID, result));
										if (list5 != null)
										{
											WSspSelectPreOrderPayments_Result wSspSelectPreOrderPayments_Result = Enumerable.FirstOrDefault<WSspSelectPreOrderPayments_Result>((IEnumerable<WSspSelectPreOrderPayments_Result>)Enumerable.OrderByDescending<WSspSelectPreOrderPayments_Result, decimal>((IEnumerable<WSspSelectPreOrderPayments_Result>)list5, (Func<WSspSelectPreOrderPayments_Result, decimal>)((WSspSelectPreOrderPayments_Result x) => x.pordpayAmount)));
											if (wSspSelectPreOrderPayments_Result != null)
											{
												CRMspSelectLinkAccSettingDetails_Result crmSettingDetails = GetCrmSettingDetails(0, wSspSelectPreOrderPayments_Result.pordpayTypeId, "PordPayType", "PaymentType");
												if (crmSettingDetails != null)
												{
													int.TryParse(crmSettingDetails.PartValue, out result2);
												}
												if (result2 <= 0)
												{
													result2 = num;
												}
												tarikhSarResid = wSspSelectPreOrderPayments_Result.pordpayDocDateTimeTemp?.ToString("yyyy/MM/dd", new CultureInfo("fa-IR")) ?? "";
												num2 = wSspSelectPreOrderPayments_Result.pordpayDocDayTemp.GetValueOrDefault();
											}
										}
										hamyarPreOrderViewModel.sefareshItems = new List<HamyarPreOrderItemViewModel>();
										foreach (CRMspLkWSSelectPreOrderItems_Result item in list2)
										{
											HamyarPreOrderItemViewModel hamyarPreOrderItemViewModel = new HamyarPreOrderItemViewModel();
											hamyarPreOrderItemViewModel.centerCode = long.Parse(cRMspSelectCenterWithAccLinkField_Result.LinkAccCenterCode);
											hamyarPreOrderItemViewModel.codeKala = ((!string.IsNullOrWhiteSpace(item.pordITracing)) ? item.pordITracing : "");
											hamyarPreOrderItemViewModel.tedad = (float)(item.pordIQuantity.GetValueOrDefault(1.0) * item.pordIFCR.GetValueOrDefault(1.0) * item.pordIFCRI.GetValueOrDefault(1.0));
											hamyarPreOrderItemViewModel.nerkhVahed = (float?)item.pordIPrice;
											hamyarPreOrderItemViewModel.mashmolMaliat = item.pordICalculateTax;
											hamyarPreOrderItemViewModel.tozihat = item.pordIDescription ?? "";
											hamyarPreOrderItemViewModel.onvarRadifSefaresh = "";
											hamyarPreOrderItemViewModel.tarikhSarResid = tarikhSarResid;
											hamyarPreOrderItemViewModel.darsadMaliat = ((float?)item.pordITaxIndex).GetValueOrDefault();
											hamyarPreOrderItemViewModel.mablaghMaliat = ((long?)item.pordITaxSum).GetValueOrDefault();
											hamyarPreOrderItemViewModel.mablaghMahsol = ((long?)item.pordIPriceSum).GetValueOrDefault();
											hamyarPreOrderItemViewModel.codeKalaMaster = item.PrdCode;
											hamyarPreOrderItemViewModel.raveshPardakht = result2;
											hamyarPreOrderItemViewModel.modatRozSarResid = num2;
											if (item.PrdKind.GetValueOrDefault() == 2)
											{
												hamyarPreOrderItemViewModel.codeAnbar = null;
											}
											else
											{
												hamyarPreOrderItemViewModel.codeAnbar = (string.IsNullOrWhiteSpace(item.pordITracing) ? 602 : 600);
											}
											hamyarPreOrderViewModel.sefareshItems.Add(hamyarPreOrderItemViewModel);
										}
										if (AdvanceResultViewModel.GetErrorsCnt(list) <= 0)
										{
											string text = ApiAddress + "AddOrUpdateSefareshFull";
											HttpClient httpClient = new HttpClient();
											httpClient.BaseAddress = new Uri(text);
											httpClient.DefaultRequestHeaders.Add("X-API-KEY", ApiKey);
											httpClient.DefaultRequestHeaders.Add("Authorization", GetToken());
											httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
											HttpContent content = new StringContent(JsonConvert.SerializeObject(hamyarPreOrderViewModel), Encoding.UTF8, "application/json");
											new HttpResponseMessage();
											string result3 = httpClient.PostAsync(text, content).Result.Content.ReadAsStringAsync().Result;
											if (!string.IsNullOrWhiteSpace(result3))
											{
												result3 = result3.ClearHiddenCharacters();
												HamyarAPIResponseViewModel<HamyarInsertPreOrderResponseViewModel> hamyarAPIResponseViewModel = JsonConvert.DeserializeObject<HamyarAPIResponseViewModel<HamyarInsertPreOrderResponseViewModel>>(result3);
												if (hamyarAPIResponseViewModel != null)
												{
													if (hamyarAPIResponseViewModel.isSuccess.GetValueOrDefault())
													{
														if (hamyarAPIResponseViewModel.data != null)
														{
															cRMLinkSpEntities.WSspUpdatePreOrderAndItemWithAccLinkField(pord.PreOrderID, null, hamyarAPIResponseViewModel.data.shomarehSefaresh, hamyarAPIResponseViewModel.data.shomarehSefaresh, null, null, null, userId, value2, value, registerDatePersian, appType);
															pord.pordLinkAccPreOrderNumber = hamyarAPIResponseViewModel.data.shomarehSefaresh;
															pord.pordLinkAccPreOrderIdStr = hamyarAPIResponseViewModel.data.shomarehSefaresh;
															if (sendPordPayToAcc.GetValueOrDefault())
															{
																List<AdvanceResultViewModel> list6 = SendPreOrderPay(null, pord, companyById, cRMspSelectCenterWithAccLinkField_Result, 0);
																list[0].Errors.AddRange(list6[0].Errors);
																list[0].Warnings.AddRange(list6[0].Warnings);
															}
															if (sendPordFilesToAcc.GetValueOrDefault())
															{
																WSspSelectPreOrderWithId_Result pord2 = pord;
																new SendPordFiles(null, pord2).SendAll(0, true);
															}
															if (AdvanceResultViewModel.GetErrorsCnt(list) <= 0)
															{
																if (string.IsNullOrWhiteSpace(pord.pordLinkAccPreOrderNumber))
																{
																	list[0].Success = "Link";
																}
																else
																{
																	list[0].Success = "Update";
																}
																list[0].Status = CommonResultStatusViewModel.Success;
															}
														}
													}
													else if (Enumerable.Count<string>((IEnumerable<string>)hamyarAPIResponseViewModel.errors) > 0)
													{
														for (int i = 0; i < Enumerable.Count<string>((IEnumerable<string>)hamyarAPIResponseViewModel.errors); i++)
														{
															list[0].Errors.Add(hamyarAPIResponseViewModel.errors[i]);
														}
													}
													else
													{
														list[0].Errors.Add(hamyarAPIResponseViewModel.message ?? Messages.ErrorEmptyServerResult);
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
				else
				{
					list[0].Errors.Add(Messages.ErrorNotFound);
				}
			}
			catch (OverflowException ex)
			{
				Public.InsExceptToElmah(ex);
				list[0].Errors.Add(Messages.ErrorOverflowNumber + ": " + ex.Message);
			}
			catch (Exception ex2)
			{
				Public.InsExceptToElmah(ex2);
				list[0].Errors.Add(Messages.MsgErrorDoneOperation + ": " + ex2.Message);
			}
			finally
			{
				cRMSpEntities?.Dispose();
				cRMTabelEntities?.Dispose();
				cRMLinkSpEntities?.Dispose();
			}
			return list;
		}

		public List<AdvanceResultViewModel> SendPreOrderPay(int? pordId = null, WSspSelectPreOrderWithId_Result pord = null, CRMspSelectCompanyById_Result cmp = null, CRMspSelectCenterWithAccLinkField_Result center = null, int? paymentId = 0)
		{
			List<AdvanceResultViewModel> list = new List<AdvanceResultViewModel>();
			list.Add(new AdvanceResultViewModel());
			if (!pordId.HasValue && pord == null)
			{
				list[0].Errors.Add(Messages.ErrorNotFound);
			}
			else
			{
				CRMSpEntities cRMSpEntities = new CRMSpEntities();
				CRMTabelEntities cRMTabelEntities = new CRMTabelEntities();
				CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				DateTime now = DateTime.Now;
				DateTime value = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				_ = Financial.Get().Id;
				short.Parse(Financial.Get().Id.ToString());
				short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				int userId = UserLogin.CurrentUser.UserId;
				try
				{
					if (pordId.GetValueOrDefault() == 0)
					{
						pordId = pord.PreOrderID;
						goto IL_01c0;
					}
					pord = Enumerable.FirstOrDefault<WSspSelectPreOrderWithId_Result>((IEnumerable<WSspSelectPreOrderWithId_Result>)cRMSpEntities.WSspSelectPreOrderWithId(pordId, lCID, result));
					if (pord == null)
					{
						list[0].Errors.Add(Messages.msgErrorPreOrderNotFound);
					}
					else
					{
						if (!string.IsNullOrWhiteSpace(pord.pordLinkAccPreOrderNumber))
						{
							goto IL_01c0;
						}
						list[0].Errors.Add(string.Format(Messages.msgErrorPordIsNotLinkedWithOtherSystem, pord.pordNumber, _LinkAccName));
					}
					goto end_IL_0117;
					IL_0312:
					string codeMeli = "";
					if (cmp.cmpKind == 0)
					{
						codeMeli = cmp.cmpNationalCode;
						goto IL_0399;
					}
					if (cmp.cmpKind.GetValueOrDefault() != 1)
					{
						goto IL_0399;
					}
					CRMspSelectCompanyPersonsByID_Result companyPerson = GetCompanyPerson(cmp.CompanyID, null);
					if (companyPerson != null)
					{
						codeMeli = companyPerson.prsNationalCode;
						goto IL_0399;
					}
					list[0].Errors.Add(Messages.msgErrorOtherSysCompanyNotLinked);
					goto end_IL_0117;
					IL_0399:
					List<WSspSelectPreOrderPayments_Result> list2 = Enumerable.ToList<WSspSelectPreOrderPayments_Result>((IEnumerable<WSspSelectPreOrderPayments_Result>)cRMSpEntities.WSspSelectPreOrderPayments(pord.PreOrderID, lCID, result));
					if (list2 != null && paymentId.GetValueOrDefault() != 0)
					{
						list2 = Enumerable.ToList<WSspSelectPreOrderPayments_Result>(Enumerable.Where<WSspSelectPreOrderPayments_Result>((IEnumerable<WSspSelectPreOrderPayments_Result>)list2, (Func<WSspSelectPreOrderPayments_Result, bool>)((WSspSelectPreOrderPayments_Result x) => x.PreOrderPaymentId == paymentId)));
					}
					if (list2 != null)
					{
						if (list2.Count <= 0)
						{
							list[0].Errors.Add(string.Format(Messages.msgErrorPordPaymentsEmpty, pord.pordNumber));
						}
						else
						{
							for (int i = 0; i < list2.Count; i++)
							{
								list.Add(new AdvanceResultViewModel());
								WSspSelectPreOrderPayments_Result wSspSelectPreOrderPayments_Result = list2[i];
								Enumerable.LastOrDefault<AdvanceResultViewModel>((IEnumerable<AdvanceResultViewModel>)list).Id = wSspSelectPreOrderPayments_Result.PreOrderPaymentId;
								Enumerable.LastOrDefault<AdvanceResultViewModel>((IEnumerable<AdvanceResultViewModel>)list).Code = wSspSelectPreOrderPayments_Result.pordpayDocNumber;
								Enumerable.LastOrDefault<AdvanceResultViewModel>((IEnumerable<AdvanceResultViewModel>)list).Title = wSspSelectPreOrderPayments_Result.PayTypeTitle;
								CRMspLkWSCheckDuplicatePreOrderPayment_Result cRMspLkWSCheckDuplicatePreOrderPayment_Result = Enumerable.FirstOrDefault<CRMspLkWSCheckDuplicatePreOrderPayment_Result>((IEnumerable<CRMspLkWSCheckDuplicatePreOrderPayment_Result>)cRMLinkSpEntities.CRMspLkWSCheckDuplicatePreOrderPayment(wSspSelectPreOrderPayments_Result.PreOrderPaymentId));
								if (cRMspLkWSCheckDuplicatePreOrderPayment_Result != null)
								{
									int result2 = 0;
									int.TryParse(cRMspLkWSCheckDuplicatePreOrderPayment_Result.AlreadySendPreOrderPaymentId.ToString(), out result2);
									if (result2 != 0 && !string.IsNullOrWhiteSpace(cRMspLkWSCheckDuplicatePreOrderPayment_Result.AlreadyPordpayLinkAccHeaderNumber))
									{
										cRMLinkSpEntities.WSspUpdatePreOrderPaymentWithAccLinkField(wSspSelectPreOrderPayments_Result.PreOrderPaymentId, cRMspLkWSCheckDuplicatePreOrderPayment_Result.AlreadyPordpayLinkAccHeaderId, cRMspLkWSCheckDuplicatePreOrderPayment_Result.AlreadyPordpayLinkAccHeaderNumber, cRMspLkWSCheckDuplicatePreOrderPayment_Result.AlreadyPordpayLinkAccDetailId, cRMspLkWSCheckDuplicatePreOrderPayment_Result.AlreadyPordpayLinkAccVoucherId, cRMspLkWSCheckDuplicatePreOrderPayment_Result.AlreadyPordpayLinkAccVoucherNumber, cRMspLkWSCheckDuplicatePreOrderPayment_Result.AlreadyPordpayLinkAccHeaderIdStr, cRMspLkWSCheckDuplicatePreOrderPayment_Result.AlreadyPordpayLinkAccDetailIdStr, cRMspLkWSCheckDuplicatePreOrderPayment_Result.AlreadyPordpayLinkAccVoucherIdStr, "dup", cRMspLkWSCheckDuplicatePreOrderPayment_Result.AlreadySendPordpayLinkAccData, false, userId, value2, value, registerDatePersian, appType);
										Enumerable.LastOrDefault<AdvanceResultViewModel>((IEnumerable<AdvanceResultViewModel>)list).Status = CommonResultStatusViewModel.Success;
										Enumerable.LastOrDefault<AdvanceResultViewModel>((IEnumerable<AdvanceResultViewModel>)list).Success = cRMspLkWSCheckDuplicatePreOrderPayment_Result.AlreadyPordpayLinkAccHeaderNumber;
										continue;
									}
								}
								if (!string.IsNullOrWhiteSpace(wSspSelectPreOrderPayments_Result.pordpayLinkAccHeaderNumber))
								{
									string text = wSspSelectPreOrderPayments_Result.pordpayAmount.ToString().FormatForPrice();
									Enumerable.LastOrDefault<AdvanceResultViewModel>((IEnumerable<AdvanceResultViewModel>)list).Errors.Add(string.Format(Messages.msgErrorPordPaymentLinkedToOtherSystemBefore, wSspSelectPreOrderPayments_Result.PayTypeTitle, text, pord.pordNumber.ToString(), _LinkAccName));
									break;
								}
								HamyarPreOrderPaymentViewModel hamyarPreOrderPaymentViewModel = new HamyarPreOrderPaymentViewModel();
								hamyarPreOrderPaymentViewModel.centerCode = long.Parse(center.LinkAccCenterCode);
								hamyarPreOrderPaymentViewModel.shomarehSefaresh = long.Parse(pord.pordLinkAccPreOrderNumber);
								hamyarPreOrderPaymentViewModel.codeMeli = codeMeli;
								hamyarPreOrderPaymentViewModel.shomarehSanadBanki = wSspSelectPreOrderPayments_Result.pordpayDocNumber;
								hamyarPreOrderPaymentViewModel.mablagh = new long?((long)wSspSelectPreOrderPayments_Result.pordpayAmount).GetValueOrDefault();
								if (!wSspSelectPreOrderPayments_Result.pordpayDocDateTime.HasValue)
								{
									wSspSelectPreOrderPayments_Result.pordpayDocDateTime = wSspSelectPreOrderPayments_Result.ImportDateTime;
								}
								int result3 = 0;
								CRMspSelectLinkAccSettingDetails_Result crmSettingDetails = GetCrmSettingDetails(0, wSspSelectPreOrderPayments_Result.pordpayTypeId, "PordPayType", "PaymentDateType");
								if (crmSettingDetails != null)
								{
									int.TryParse(crmSettingDetails.PartValue, out result3);
								}
								DateTime dateTime = wSspSelectPreOrderPayments_Result.ImportDateTime ?? DateTime.Now;
								if (result3 == 2)
								{
									dateTime = wSspSelectPreOrderPayments_Result.pordpayDocDateTime ?? DateTime.Now;
								}
								hamyarPreOrderPaymentViewModel.tarikhPardakht = dateTime.ToString("yyyy/MM/dd", new CultureInfo("fa-IR"));
								if (AdvanceResultViewModel.GetErrorsCnt(list) > 0)
								{
									continue;
								}
								string text2 = ApiAddress + "addPardhkhtSefaresh";
								HttpClient httpClient = new HttpClient();
								httpClient.BaseAddress = new Uri(text2);
								httpClient.DefaultRequestHeaders.Add("X-API-KEY", ApiKey);
								httpClient.DefaultRequestHeaders.Add("Authorization", GetToken());
								httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
								HttpContent content = new StringContent(JsonConvert.SerializeObject(hamyarPreOrderPaymentViewModel), Encoding.UTF8, "application/json");
								new HttpResponseMessage();
								string result4 = httpClient.PostAsync(text2, content).Result.Content.ReadAsStringAsync().Result;
								if (string.IsNullOrWhiteSpace(result4))
								{
									continue;
								}
								result4 = result4.ClearHiddenCharacters();
								HamyarAPIResponseViewModel<string> hamyarAPIResponseViewModel = JsonConvert.DeserializeObject<HamyarAPIResponseViewModel<string>>(result4);
								if (hamyarAPIResponseViewModel == null)
								{
									continue;
								}
								if (hamyarAPIResponseViewModel.isSuccess.GetValueOrDefault())
								{
									cRMLinkSpEntities.WSspUpdatePreOrderPaymentWithAccLinkField(wSspSelectPreOrderPayments_Result.PreOrderPaymentId, null, hamyarAPIResponseViewModel.data, null, null, null, null, null, null, null, null, null, userId, value2, value, registerDatePersian, appType);
									Enumerable.LastOrDefault<AdvanceResultViewModel>((IEnumerable<AdvanceResultViewModel>)list).Status = CommonResultStatusViewModel.Success;
									Enumerable.LastOrDefault<AdvanceResultViewModel>((IEnumerable<AdvanceResultViewModel>)list).Success = "Link";
								}
								else if (Enumerable.Count<string>((IEnumerable<string>)hamyarAPIResponseViewModel.errors) > 0)
								{
									for (int j = 0; j < Enumerable.Count<string>((IEnumerable<string>)hamyarAPIResponseViewModel.errors); j++)
									{
										Enumerable.LastOrDefault<AdvanceResultViewModel>((IEnumerable<AdvanceResultViewModel>)list).Errors.Add(hamyarAPIResponseViewModel.errors[j]);
									}
								}
								else
								{
									Enumerable.LastOrDefault<AdvanceResultViewModel>((IEnumerable<AdvanceResultViewModel>)list).Errors.Add(hamyarAPIResponseViewModel.message ?? Messages.ErrorEmptyServerResult);
								}
							}
						}
					}
					else
					{
						list[0].Errors.Add(Messages.ErrorNotFound);
					}
					goto end_IL_0117;
					IL_026c:
					if (center != null)
					{
						goto IL_0312;
					}
					List<CRMspSelectCenterWithAccLinkField_Result> list3 = Enumerable.ToList<CRMspSelectCenterWithAccLinkField_Result>((IEnumerable<CRMspSelectCenterWithAccLinkField_Result>)cRMLinkSpEntities.CRMspSelectCenterWithAccLinkField(lCID, result, true, true, true));
					if (list3 == null)
					{
						goto IL_0312;
					}
					center = Enumerable.FirstOrDefault<CRMspSelectCenterWithAccLinkField_Result>((IEnumerable<CRMspSelectCenterWithAccLinkField_Result>)list3, (Func<CRMspSelectCenterWithAccLinkField_Result, bool>)((CRMspSelectCenterWithAccLinkField_Result x) => x.CenterID == pord.pordCId));
					if (center == null)
					{
						list[0].Errors.Add(Messages.msgErrorCenterNotFound);
					}
					else
					{
						if (!string.IsNullOrWhiteSpace(center.LinkAccCenterCode))
						{
							goto IL_0312;
						}
						list[0].Errors.Add(string.Format(Messages.msgErrorOtherSysCenterNotLinked, pord.pordCenterName));
					}
					goto end_IL_0117;
					IL_01c0:
					if (cmp != null)
					{
						goto IL_026c;
					}
					cmp = Company.GetCompanyById(pord.pordCompanyId.GetValueOrDefault());
					if (cmp == null)
					{
						list[0].Errors.Add(Messages.CompanyNotFound);
					}
					else if (string.IsNullOrWhiteSpace(cmp.cmpLinkAccData))
					{
						list[0].Errors.Add(string.Format(Messages.msgErrorOtherSysCompanyNotLinked, cmp.CompanyName));
					}
					else
					{
						if (JsonConvert.DeserializeObject<List<LinkAccDataViewModel>>(cmp.cmpLinkAccData).Count > 0)
						{
							goto IL_026c;
						}
						list[0].Errors.Add(string.Format(Messages.msgErrorOtherSysCompanyNotLinked, cmp.CompanyName));
					}
					end_IL_0117:;
				}
				catch (Exception ex)
				{
					Public.InsExceptToElmah(ex);
					list[0].Errors.Add(Messages.MsgErrorDoneOperation + ": " + ex.Message);
				}
				finally
				{
					cRMSpEntities.Dispose();
					cRMTabelEntities.Dispose();
					cRMLinkSpEntities.Dispose();
				}
			}
			return list;
		}

		public List<AdvanceResultViewModel> EbtalSefareshInHamyar(int? pordId = null, WSspSelectPreOrderWithId_Result pord = null, CRMspSelectCompanyById_Result cmp = null, CRMspSelectCenterWithAccLinkField_Result center = null)
		{
			List<AdvanceResultViewModel> list = new List<AdvanceResultViewModel>();
			list.Add(new AdvanceResultViewModel());
			if (!pordId.HasValue && pord == null)
			{
				list[0].Errors.Add(Messages.ErrorNotFound);
			}
			else
			{
				CRMSpEntities cRMSpEntities = new CRMSpEntities();
				CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
				_ = Financial.Get().Id;
				short.Parse(Financial.Get().Id.ToString());
				short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
				_ = Configuration.AppType;
				try
				{
					if (pordId.GetValueOrDefault() == 0)
					{
						pordId = pord.PreOrderID;
						goto IL_019e;
					}
					pord = Enumerable.FirstOrDefault<WSspSelectPreOrderWithId_Result>((IEnumerable<WSspSelectPreOrderWithId_Result>)cRMSpEntities.WSspSelectPreOrderWithId(pordId, lCID, result));
					if (pord == null)
					{
						list[0].Errors.Add(Messages.msgErrorPreOrderNotFound);
					}
					else
					{
						if (!string.IsNullOrWhiteSpace(pord.pordLinkAccPreOrderNumber))
						{
							goto IL_019e;
						}
						list[0].Errors.Add(string.Format(Messages.msgErrorPordIsNotLinkedWithOtherSystem, pord.pordNumber, _LinkAccName));
					}
					goto end_IL_00f5;
					IL_02ef:
					string codeOrShenasehMeliMoshtari = "";
					if (cmp.cmpKind == 0)
					{
						codeOrShenasehMeliMoshtari = cmp.cmpNationalCode;
						goto IL_0376;
					}
					if (cmp.cmpKind.GetValueOrDefault() != 1)
					{
						goto IL_0376;
					}
					CRMspSelectCompanyPersonsByID_Result companyPerson = GetCompanyPerson(cmp.CompanyID, null);
					if (companyPerson != null)
					{
						codeOrShenasehMeliMoshtari = companyPerson.prsNationalCode;
						goto IL_0376;
					}
					list[0].Errors.Add(Messages.msgErrorOtherSysCompanyNotLinked);
					goto end_IL_00f5;
					IL_0376:
					HamyarEbtalPreOrderViewModel hamyarEbtalPreOrderViewModel = new HamyarEbtalPreOrderViewModel();
					hamyarEbtalPreOrderViewModel.centerCode = long.Parse(center.LinkAccCenterCode);
					hamyarEbtalPreOrderViewModel.shomarehSefareshCrm = pord.pordNumber.ToString();
					hamyarEbtalPreOrderViewModel.shomarehSefareshHamyar = long.Parse(pord.pordLinkAccPreOrderNumber);
					hamyarEbtalPreOrderViewModel.codeOrShenasehMeliMoshtari = codeOrShenasehMeliMoshtari;
					if (AdvanceResultViewModel.GetErrorsCnt(list) <= 0)
					{
						string text = ApiAddress + "EbtalSefareshInHamyar";
						HttpClient httpClient = new HttpClient();
						httpClient.BaseAddress = new Uri(text);
						httpClient.DefaultRequestHeaders.Add("X-API-KEY", ApiKey);
						httpClient.DefaultRequestHeaders.Add("Authorization", GetToken());
						httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
						HttpContent content = new StringContent(JsonConvert.SerializeObject(hamyarEbtalPreOrderViewModel), Encoding.UTF8, "application/json");
						new HttpResponseMessage();
						string result2 = httpClient.PostAsync(text, content).Result.Content.ReadAsStringAsync().Result;
						if (!string.IsNullOrWhiteSpace(result2))
						{
							result2 = result2.ClearHiddenCharacters();
							HamyarAPIResponseViewModel<HamyarInsertPreOrderResponseViewModel> hamyarAPIResponseViewModel = JsonConvert.DeserializeObject<HamyarAPIResponseViewModel<HamyarInsertPreOrderResponseViewModel>>(result2);
							if (hamyarAPIResponseViewModel != null)
							{
								if (hamyarAPIResponseViewModel.isSuccess.GetValueOrDefault())
								{
									if (hamyarAPIResponseViewModel.data == null)
									{
									}
								}
								else if (Enumerable.Count<string>((IEnumerable<string>)hamyarAPIResponseViewModel.errors) > 0)
								{
									for (int i = 0; i < Enumerable.Count<string>((IEnumerable<string>)hamyarAPIResponseViewModel.errors); i++)
									{
										list[0].Errors.Add(hamyarAPIResponseViewModel.errors[i]);
									}
								}
								else
								{
									list[0].Errors.Add(hamyarAPIResponseViewModel.message ?? Messages.ErrorEmptyServerResult);
								}
							}
						}
					}
					goto end_IL_00f5;
					IL_024a:
					if (center != null)
					{
						goto IL_02ef;
					}
					List<CRMspSelectCenterWithAccLinkField_Result> list2 = Enumerable.ToList<CRMspSelectCenterWithAccLinkField_Result>((IEnumerable<CRMspSelectCenterWithAccLinkField_Result>)cRMLinkSpEntities.CRMspSelectCenterWithAccLinkField(lCID, result, true, true, true));
					if (list2 == null)
					{
						goto IL_02ef;
					}
					center = Enumerable.FirstOrDefault<CRMspSelectCenterWithAccLinkField_Result>((IEnumerable<CRMspSelectCenterWithAccLinkField_Result>)list2, (Func<CRMspSelectCenterWithAccLinkField_Result, bool>)((CRMspSelectCenterWithAccLinkField_Result x) => x.CenterID == pord.pordCId));
					if (center == null)
					{
						list[0].Errors.Add(Messages.msgErrorCenterNotFound);
					}
					else
					{
						if (!string.IsNullOrWhiteSpace(center.LinkAccCenterCode))
						{
							goto IL_02ef;
						}
						list[0].Errors.Add(string.Format(Messages.msgErrorOtherSysCenterNotLinked, pord.pordCenterName));
					}
					goto end_IL_00f5;
					IL_019e:
					if (cmp != null)
					{
						goto IL_024a;
					}
					cmp = Company.GetCompanyById(pord.pordCompanyId.GetValueOrDefault());
					if (cmp == null)
					{
						list[0].Errors.Add(Messages.CompanyNotFound);
					}
					else if (string.IsNullOrWhiteSpace(cmp.cmpLinkAccData))
					{
						list[0].Errors.Add(string.Format(Messages.msgErrorOtherSysCompanyNotLinked, cmp.CompanyName));
					}
					else
					{
						if (JsonConvert.DeserializeObject<List<LinkAccDataViewModel>>(cmp.cmpLinkAccData).Count > 0)
						{
							goto IL_024a;
						}
						list[0].Errors.Add(string.Format(Messages.msgErrorOtherSysCompanyNotLinked, cmp.CompanyName));
					}
					end_IL_00f5:;
				}
				catch (Exception ex)
				{
					Public.InsExceptToElmah(ex);
					list[0].Errors.Add(Messages.MsgErrorDoneOperation + ": " + ex.Message);
				}
			}
			return list;
		}

		public List<AdvanceResultViewModel> EbtalSefareshInHamyar(List<WSspUpdateExpiredPreOrderStatus_Result> expiredPreOrderlst = null)
		{
			List<AdvanceResultViewModel> list = new List<AdvanceResultViewModel>();
			if (expiredPreOrderlst != null)
			{
				for (int i = 0; i < expiredPreOrderlst.Count; i++)
				{
					if (!string.IsNullOrWhiteSpace(expiredPreOrderlst[i].pordLinkAccPreOrderNumber))
					{
						list.AddRange(EbtalSefareshInHamyar(expiredPreOrderlst[i].PreOrderID));
					}
				}
			}
			return list;
		}

		public async Task<List<HamyarReportsViewModel.GozareshFactorha>> GozareshFactorha(int cmpId = 0, int crmCenterId = 0, string fDatePer = "", string tDatePer = "", int pageIndex = 1, int pageSize = 200)
		{
			List<HamyarReportsViewModel.GozareshFactorha> res = new List<HamyarReportsViewModel.GozareshFactorha>();
			try
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
				}
				_ = Thread.CurrentThread.CurrentCulture.LCID;
				string text = "";
				LinkAccDataViewModel cmpCenterInfo = Company.GetCmpCenterInfo(cmpId, crmCenterId);
				if (cmpCenterInfo != null)
				{
					text = cmpCenterInfo.Code;
				}
				string text2 = "";
				CRMspSelectCentersWithIds_Result cRMspSelectCentersWithIds_Result = Enumerable.FirstOrDefault<CRMspSelectCentersWithIds_Result>((IEnumerable<CRMspSelectCentersWithIds_Result>)Center.GetWithIds(crmCenterId.ToString()));
				if (cRMspSelectCentersWithIds_Result != null)
				{
					text2 = cRMspSelectCentersWithIds_Result.LinkAccCenterCode;
				}
				string text3 = ApiAddress + "GozareshFactorha";
				HttpClient httpClient = new HttpClient();
				httpClient.BaseAddress = new Uri(text3);
				httpClient.DefaultRequestHeaders.Add("X-API-KEY", ApiKey);
				httpClient.DefaultRequestHeaders.Add("Authorization", GetToken());
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				new HttpResponseMessage();
				string result2 = (await httpClient.GetAsync(text3 + "?FromDate=" + fDatePer + "&ToDate=" + tDatePer + "&TafNatiolaCode=" + text + "&ExcelOutPut=false&CenterCode=" + text2 + "&pageIndex=" + pageIndex + "&pageSize=" + pageSize)).Content.ReadAsStringAsync().Result;
				if (!string.IsNullOrWhiteSpace(result2))
				{
					result2 = result2.ClearHiddenCharacters();
					HamyarAPIResponseViewModel<List<HamyarReportsViewModel.GozareshFactorha>> hamyarAPIResponseViewModel = JsonConvert.DeserializeObject<HamyarAPIResponseViewModel<List<HamyarReportsViewModel.GozareshFactorha>>>(result2);
					if (hamyarAPIResponseViewModel.data != null)
					{
						res.AddRange(hamyarAPIResponseViewModel.data);
					}
				}
			}
			catch (Exception ex)
			{
				Public.InsExceptToElmah(ex);
			}
			return res;
		}

		public async Task<List<HamyarReportsViewModel.GozareshVaredeSadereBetafkikTaf>> GozareshVaredeSadereBetafkikTaf(int cmpId = 0, int crmCenterId = 0, string fDatePer = "", string tDatePer = "", int pageIndex = 1, int pageSize = 200)
		{
			List<HamyarReportsViewModel.GozareshVaredeSadereBetafkikTaf> res = new List<HamyarReportsViewModel.GozareshVaredeSadereBetafkikTaf>();
			try
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
				}
				_ = Thread.CurrentThread.CurrentCulture.LCID;
				string text = "";
				LinkAccDataViewModel cmpCenterInfo = Company.GetCmpCenterInfo(cmpId, crmCenterId);
				if (cmpCenterInfo != null)
				{
					text = cmpCenterInfo.Code;
				}
				string text2 = "";
				CRMspSelectCentersWithIds_Result cRMspSelectCentersWithIds_Result = Enumerable.FirstOrDefault<CRMspSelectCentersWithIds_Result>((IEnumerable<CRMspSelectCentersWithIds_Result>)Center.GetWithIds(crmCenterId.ToString()));
				if (cRMspSelectCentersWithIds_Result != null)
				{
					text2 = cRMspSelectCentersWithIds_Result.LinkAccCenterCode;
				}
				string text3 = ApiAddress + "GozareshVaredeSadereBetafkikTaf";
				HttpClient httpClient = new HttpClient();
				httpClient.BaseAddress = new Uri(text3);
				httpClient.DefaultRequestHeaders.Add("X-API-KEY", ApiKey);
				httpClient.DefaultRequestHeaders.Add("Authorization", GetToken());
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				new HttpResponseMessage();
				string result2 = (await httpClient.GetAsync(text3 + "?FromDate=" + fDatePer + "&ToDate=" + tDatePer + "&TafNatiolaCode=" + text + "&ExcelOutPut=false&CenterCode=" + text2 + "&pageIndex=" + pageIndex + "&pageSize=" + pageSize)).Content.ReadAsStringAsync().Result;
				if (!string.IsNullOrWhiteSpace(result2))
				{
					result2 = result2.ClearHiddenCharacters();
					HamyarAPIResponseViewModel<List<HamyarReportsViewModel.GozareshVaredeSadereBetafkikTaf>> hamyarAPIResponseViewModel = JsonConvert.DeserializeObject<HamyarAPIResponseViewModel<List<HamyarReportsViewModel.GozareshVaredeSadereBetafkikTaf>>>(result2);
					if (hamyarAPIResponseViewModel.data != null)
					{
						res.AddRange(hamyarAPIResponseViewModel.data);
					}
				}
			}
			catch (Exception ex)
			{
				Public.InsExceptToElmah(ex);
			}
			return res;
		}

		public async Task<List<HamyarReportsViewModel.GozareshVaredeSadereBetafkikTaf2>> GozareshVaredeSadereBetafkikTaf2(int cmpId = 0, int crmCenterId = 0, string fDatePer = "", string tDatePer = "", int pageIndex = 1, int pageSize = 200)
		{
			List<HamyarReportsViewModel.GozareshVaredeSadereBetafkikTaf2> res = new List<HamyarReportsViewModel.GozareshVaredeSadereBetafkikTaf2>();
			try
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
				}
				_ = Thread.CurrentThread.CurrentCulture.LCID;
				string text = "";
				LinkAccDataViewModel cmpCenterInfo = Company.GetCmpCenterInfo(cmpId, crmCenterId);
				if (cmpCenterInfo != null)
				{
					text = cmpCenterInfo.Code;
				}
				string text2 = "";
				CRMspSelectCentersWithIds_Result cRMspSelectCentersWithIds_Result = Enumerable.FirstOrDefault<CRMspSelectCentersWithIds_Result>((IEnumerable<CRMspSelectCentersWithIds_Result>)Center.GetWithIds(crmCenterId.ToString()));
				if (cRMspSelectCentersWithIds_Result != null)
				{
					text2 = cRMspSelectCentersWithIds_Result.LinkAccCenterCode;
				}
				string text3 = ApiAddress + "GozareshVaredeSadereBetafkikTaf2";
				HttpClient httpClient = new HttpClient();
				httpClient.BaseAddress = new Uri(text3);
				httpClient.DefaultRequestHeaders.Add("X-API-KEY", ApiKey);
				httpClient.DefaultRequestHeaders.Add("Authorization", GetToken());
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				new HttpResponseMessage();
				string result2 = (await httpClient.GetAsync(text3 + "?FromDate=" + fDatePer + "&ToDate=" + tDatePer + "&TafNatiolaCode=" + text + "&ExcelOutPut=false&CenterCode=" + text2 + "&pageIndex=" + pageIndex + "&pageSize=" + pageSize)).Content.ReadAsStringAsync().Result;
				if (!string.IsNullOrWhiteSpace(result2))
				{
					result2 = result2.ClearHiddenCharacters();
					HamyarAPIResponseViewModel<List<HamyarReportsViewModel.GozareshVaredeSadereBetafkikTaf2>> hamyarAPIResponseViewModel = JsonConvert.DeserializeObject<HamyarAPIResponseViewModel<List<HamyarReportsViewModel.GozareshVaredeSadereBetafkikTaf2>>>(result2);
					if (hamyarAPIResponseViewModel.data != null)
					{
						res.AddRange(hamyarAPIResponseViewModel.data);
					}
				}
			}
			catch (Exception ex)
			{
				Public.InsExceptToElmah(ex);
			}
			return res;
		}

		public async Task<List<HamyarReportsViewModel.MojudiAvalDore>> MojudiAvalDore(int cmpId = 0, int crmCenterId = 0, int pageIndex = 1, int pageSize = 200)
		{
			List<HamyarReportsViewModel.MojudiAvalDore> res = new List<HamyarReportsViewModel.MojudiAvalDore>();
			try
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
				}
				_ = Thread.CurrentThread.CurrentCulture.LCID;
				string text = "";
				LinkAccDataViewModel cmpCenterInfo = Company.GetCmpCenterInfo(cmpId, crmCenterId);
				if (cmpCenterInfo != null)
				{
					text = cmpCenterInfo.Code;
				}
				string text2 = "";
				CRMspSelectCentersWithIds_Result cRMspSelectCentersWithIds_Result = Enumerable.FirstOrDefault<CRMspSelectCentersWithIds_Result>((IEnumerable<CRMspSelectCentersWithIds_Result>)Center.GetWithIds(crmCenterId.ToString()));
				if (cRMspSelectCentersWithIds_Result != null)
				{
					text2 = cRMspSelectCentersWithIds_Result.LinkAccCenterCode;
				}
				string text3 = ApiAddress + "MojudiAvalDore";
				HttpClient httpClient = new HttpClient();
				httpClient.BaseAddress = new Uri(text3);
				httpClient.DefaultRequestHeaders.Add("X-API-KEY", ApiKey);
				httpClient.DefaultRequestHeaders.Add("Authorization", GetToken());
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				new HttpResponseMessage();
				string result2 = (await httpClient.GetAsync(text3 + "?TafNatiolaCode=" + text + "&ExcelOutPut=false&CenterCode=" + text2 + "&pageIndex=" + pageIndex + "&pageSize=" + pageSize)).Content.ReadAsStringAsync().Result;
				if (!string.IsNullOrWhiteSpace(result2))
				{
					result2 = result2.ClearHiddenCharacters();
					HamyarAPIResponseViewModel<List<HamyarReportsViewModel.MojudiAvalDore>> hamyarAPIResponseViewModel = JsonConvert.DeserializeObject<HamyarAPIResponseViewModel<List<HamyarReportsViewModel.MojudiAvalDore>>>(result2);
					if (hamyarAPIResponseViewModel.data != null)
					{
						res.AddRange(hamyarAPIResponseViewModel.data);
					}
				}
			}
			catch (Exception ex)
			{
				Public.InsExceptToElmah(ex);
			}
			return res;
		}

		public async Task<List<HamyarReportsViewModel.MojudiMeghdariKala>> MojudiMeghdariKala(int cmpId = 0, int crmCenterId = 0, string tDatePer = "", int pageIndex = 1, int pageSize = 200)
		{
			List<HamyarReportsViewModel.MojudiMeghdariKala> res = new List<HamyarReportsViewModel.MojudiMeghdariKala>();
			try
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
				}
				_ = Thread.CurrentThread.CurrentCulture.LCID;
				string text = "";
				LinkAccDataViewModel cmpCenterInfo = Company.GetCmpCenterInfo(cmpId, crmCenterId);
				if (cmpCenterInfo != null)
				{
					text = cmpCenterInfo.Code;
				}
				string text2 = "";
				CRMspSelectCentersWithIds_Result cRMspSelectCentersWithIds_Result = Enumerable.FirstOrDefault<CRMspSelectCentersWithIds_Result>((IEnumerable<CRMspSelectCentersWithIds_Result>)Center.GetWithIds(crmCenterId.ToString()));
				if (cRMspSelectCentersWithIds_Result != null)
				{
					text2 = cRMspSelectCentersWithIds_Result.LinkAccCenterCode;
				}
				string text3 = ApiAddress + "MojudiMeghdariKala";
				HttpClient httpClient = new HttpClient();
				httpClient.BaseAddress = new Uri(text3);
				httpClient.DefaultRequestHeaders.Add("X-API-KEY", ApiKey);
				httpClient.DefaultRequestHeaders.Add("Authorization", GetToken());
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				new HttpResponseMessage();
				string result2 = (await httpClient.GetAsync(text3 + "?ToDate=" + tDatePer + "&TafNatiolaCode=" + text + "&ExcelOutPut=false&CenterCode=" + text2 + "&pageIndex=" + pageIndex + "&pageSize=" + pageSize)).Content.ReadAsStringAsync().Result;
				if (!string.IsNullOrWhiteSpace(result2))
				{
					result2 = result2.ClearHiddenCharacters();
					HamyarAPIResponseViewModel<List<HamyarReportsViewModel.MojudiMeghdariKala>> hamyarAPIResponseViewModel = JsonConvert.DeserializeObject<HamyarAPIResponseViewModel<List<HamyarReportsViewModel.MojudiMeghdariKala>>>(result2);
					if (hamyarAPIResponseViewModel.data != null)
					{
						res.AddRange(hamyarAPIResponseViewModel.data);
					}
				}
			}
			catch (Exception ex)
			{
				Public.InsExceptToElmah(ex);
			}
			return res;
		}
	}

	public class HamyarSettingViewModel
	{
		public string ApiAddress { get; set; }

		public string ApiKey { get; set; }

		public string ApiUsername { get; set; }

		public string ApiPassword { get; set; }

		public string LegalMoadiType { get; set; }

		public string RealMoadiType { get; set; }
	}

	public class RahkaranInternalSalesProvider
	{
		public class SettingDetailsViewModel
		{
			public int PordPayHeaderDateType { get; set; }

			public int PordPayDetailDateType { get; set; }

			public int OrdPayHeaderDateType { get; set; }

			public int OrdPayDetailDateType { get; set; }

			public string PordPayAgreementId { get; set; }

			public string OrdPayAgreementId { get; set; }
		}

		private const string authAddressPath = "Framework/Services/AuthenticationService.svc";

		public HttpClient client = new HttpClient();

		public const string _KeyName_Address = "ApiAddress";

		public const string _KeyName_Username = "ApiUsername";

		public const string _KeyName_Password = "ApiPassword";

		public const string _KeyName_CurrencyRef = "CurrencyRef";

		public const string _KeyName_AddressTypeSendPrd = "AddressTypeSendPrd";

		public const string _KeyName_AddressTypeSendOrd = "AddressTypeSendOrd";

		public const string _KeyName_PrdLinkedField = "PrdLinkedField";

		public const string _KeyName_WrhsSyncTypeId = "WrhsSyncTypeId";

		public const string _KeyName_DefCurrencyUnitId = "DefCurrencyUnitId";

		public const string _KeyName_DefPrjTitle = "DefPrjTitle";

		public const string _KeyName_DefPrjCvnsStatusGroupId = "DefPrjCvnsStatusGroupId";

		public const string _KeyName_PordTaxPolicyId = "PordTaxPolicyId";

		public const string _KeyName_PordTaxPolicyName = "PordTaxPolicyName";

		public const string _KeyName_PordTaxConditionId = "PordTaxConditionId";

		public const string _KeyName_PordTaxConditionRowId = "PordTaxConditionRowId";

		public const string _KeyName_PordDiscountPolicyId = "PordDiscountPolicyId";

		public const string _KeyName_PordDiscountPolicyName = "PordDiscountPolicyName";

		public const string _KeyName_PordDiscountConditionId = "PordDiscountConditionId";

		public const string _KeyName_PordDiscountConditionRowId = "PordDiscountConditionRowId";

		public const string _KeyName_OrdTaxPolicyId = "OrdTaxPolicyId";

		public const string _KeyName_OrdTaxPolicyName = "OrdTaxPolicyName";

		public const string _KeyName_OrdTaxConditionId = "OrdTaxConditionId";

		public const string _KeyName_OrdTaxConditionRowId = "OrdTaxConditionRowId";

		public const string _KeyName_OrdDiscountPolicyId = "OrdDiscountPolicyId";

		public const string _KeyName_OrdDiscountPolicyName = "OrdDiscountPolicyName";

		public const string _KeyName_OrdDiscountConditionId = "OrdDiscountConditionId";

		public const string _KeyName_OrdDiscountConditionRowId = "OrdDiscountConditionRowId";

		public const string _KeyName_PordPayTypeHeaderDateType = "HeaderDateType";

		public const string _KeyName_PordPayTypeDetailDateType = "DetailDateType";

		public const string _KeyName_OrdPayTypeHeaderDateType = "HeaderDateType";

		public const string _KeyName_OrdPayTypeDetailDateType = "DetailDateType";

		public const string _KeyName_PordPayAgreement = "PayAgreement";

		public const string _KeyName_OrdPayAgreement = "PayAgreement";

		private static string _ApiAddress = "";

		private static string _ApiUsername = "";

		private static string _ApiPassword = "";

		private static long _CurrencyRef = 0L;

		private static int _AddressTypeSendPrd = 0;

		private static int _AddressTypeSendOrd = 0;

		private static string _PrdLinkedField = "";

		private static int _WrhsSyncTypeId = 0;

		private static int _WrhsSyncTypeLinkAccSettingId = 0;

		private static int _DefCurrencyUnitId = 0;

		private static string _DefPrjTitle = "";

		private static int _DefPrjCvnsStatusGroupId = 0;

		private static string _PordTaxPolicyId = "";

		private static string _PordTaxPolicyName = "";

		private static string _PordTaxConditionId = "";

		private static string _PordTaxConditionRowId = "";

		private static string _PordDiscountPolicyId = "";

		private static string _PordDiscountPolicyName = "";

		private static string _PordDiscountConditionId = "";

		private static string _PordDiscountConditionRowId = "";

		private static string _PordPayAgreementId = "";

		private static string _OrdTaxPolicyId = "";

		private static string _OrdTaxPolicyName = "";

		private static string _OrdTaxConditionId = "";

		private static string _OrdTaxConditionRowId = "";

		private static string _OrdDiscountPolicyId = "";

		private static string _OrdDiscountPolicyName = "";

		private static string _OrdDiscountConditionId = "";

		private static string _OrdDiscountConditionRowId = "";

		private static string _OrdPayAgreementId = "";

		private static List<CRMspSelectLinkAccSetting_Result> _LinkAccSetting = null;

		private static List<LkCompanyAndPersonViewModel> _ListCompany = null;

		private static List<LkProductInfoViewModel> _ListProduct = null;

		public string seesionID { get; set; }

		public bool loginResult { get; set; }

		public string ApiAddress
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_ApiAddress))
				{
					_ApiAddress = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "ApiAddress")).PartValue ?? "";
				}
				if (!string.IsNullOrWhiteSpace(_ApiAddress) && !_ApiAddress.EndsWith("/"))
				{
					_ApiAddress += "/";
				}
				return _ApiAddress;
			}
			set
			{
				_ApiAddress = "";
			}
		}

		public string ApiUsername
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_ApiUsername))
				{
					_ApiUsername = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "ApiUsername")).PartValue ?? "";
				}
				return _ApiUsername;
			}
			set
			{
				_ApiUsername = "";
			}
		}

		public string ApiPassword
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_ApiPassword))
				{
					_ApiPassword = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "ApiPassword")).PartValue ?? "";
				}
				return _ApiPassword;
			}
			set
			{
				_ApiPassword = "";
			}
		}

		public long CurrencyRef
		{
			get
			{
				if (_CurrencyRef == 0L)
				{
					long.TryParse(Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "CurrencyRef")).PartValue ?? "0", out _CurrencyRef);
				}
				return _CurrencyRef;
			}
			set
			{
				_CurrencyRef = 0L;
			}
		}

		public int AddressTypeSendPrd
		{
			get
			{
				if (_AddressTypeSendPrd == 0)
				{
					int.TryParse(Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "AddressTypeSendPrd")).PartValue ?? "0", out _AddressTypeSendPrd);
				}
				return _AddressTypeSendPrd;
			}
			set
			{
				_AddressTypeSendPrd = 0;
			}
		}

		public int AddressTypeSendOrd
		{
			get
			{
				if (_AddressTypeSendOrd == 0)
				{
					int.TryParse(Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "AddressTypeSendOrd")).PartValue ?? "0", out _AddressTypeSendOrd);
				}
				return _AddressTypeSendOrd;
			}
			set
			{
				_AddressTypeSendOrd = 0;
			}
		}

		public string PrdLinkedField
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_PrdLinkedField))
				{
					_PrdLinkedField = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "PrdLinkedField")).PartValue ?? "";
				}
				return _PrdLinkedField;
			}
			set
			{
				_PrdLinkedField = "";
			}
		}

		public int WrhsSyncTypeId
		{
			get
			{
				if (_WrhsSyncTypeId == 0)
				{
					int.TryParse(Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "WrhsSyncTypeId")).PartValue ?? "0", out _WrhsSyncTypeId);
				}
				return _WrhsSyncTypeId;
			}
			set
			{
				_WrhsSyncTypeId = 0;
			}
		}

		public int WrhsSyncTypeLinkAccSettingId
		{
			get
			{
				if (_WrhsSyncTypeLinkAccSettingId == 0)
				{
					int.TryParse(Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "WrhsSyncTypeId")).LinkAccSettingId.ToString(), out _WrhsSyncTypeLinkAccSettingId);
				}
				return _WrhsSyncTypeLinkAccSettingId;
			}
			set
			{
				_WrhsSyncTypeLinkAccSettingId = 0;
			}
		}

		public int DefCurrencyUnitId
		{
			get
			{
				if (_DefCurrencyUnitId == 0)
				{
					int.TryParse(Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "DefCurrencyUnitId")).PartValue ?? "0", out _DefCurrencyUnitId);
				}
				return _DefCurrencyUnitId;
			}
			set
			{
				_DefCurrencyUnitId = 0;
			}
		}

		public string DefPrjTitle
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_DefPrjTitle))
				{
					_DefPrjTitle = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "DefPrjTitle")).PartValue ?? "";
				}
				return _DefPrjTitle;
			}
			set
			{
				_DefPrjTitle = "";
			}
		}

		public int DefPrjCvnsStatusGroupId
		{
			get
			{
				if (_DefPrjCvnsStatusGroupId == 0)
				{
					int.TryParse(Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "DefPrjCvnsStatusGroupId")).PartValue ?? "0", out _DefPrjCvnsStatusGroupId);
				}
				return _DefPrjCvnsStatusGroupId;
			}
			set
			{
				_DefPrjCvnsStatusGroupId = 0;
			}
		}

		public string PordTaxPolicyId
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_PordTaxPolicyId))
				{
					_PordTaxPolicyId = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "PordTaxPolicyId")).PartValue ?? "";
				}
				return _PordTaxPolicyId;
			}
			set
			{
				_PordTaxPolicyId = "";
			}
		}

		public string PordTaxPolicyName
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_PordTaxPolicyName))
				{
					_PordTaxPolicyName = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "PordTaxPolicyName")).PartValue ?? "";
				}
				return _PordTaxPolicyName;
			}
			set
			{
				_PordTaxPolicyName = "";
			}
		}

		public string PordTaxConditionId
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_PordTaxConditionId))
				{
					_PordTaxConditionId = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "PordTaxConditionId")).PartValue ?? "";
				}
				return _PordTaxConditionId;
			}
			set
			{
				_PordTaxConditionId = "";
			}
		}

		public string PordTaxConditionRowId
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_PordTaxConditionRowId))
				{
					_PordTaxConditionRowId = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "PordTaxConditionRowId")).PartValue ?? "";
				}
				return _PordTaxConditionRowId;
			}
			set
			{
				_PordTaxConditionRowId = "";
			}
		}

		public string PordDiscountPolicyId
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_PordDiscountPolicyId))
				{
					_PordDiscountPolicyId = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "PordDiscountPolicyId")).PartValue ?? "";
				}
				return _PordDiscountPolicyId;
			}
			set
			{
				_PordDiscountPolicyId = "";
			}
		}

		public string PordDiscountPolicyName
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_PordDiscountPolicyName))
				{
					_PordDiscountPolicyName = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "PordDiscountPolicyName")).PartValue ?? "";
				}
				return _PordDiscountPolicyName;
			}
			set
			{
				_PordDiscountPolicyName = "";
			}
		}

		public string PordDiscountConditionId
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_PordDiscountConditionId))
				{
					_PordDiscountConditionId = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "PordDiscountConditionId")).PartValue ?? "";
				}
				return _PordDiscountConditionId;
			}
			set
			{
				_PordDiscountConditionId = "";
			}
		}

		public string PordDiscountConditionRowId
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_PordDiscountConditionRowId))
				{
					_PordDiscountConditionRowId = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "PordDiscountConditionRowId")).PartValue ?? "";
				}
				return _PordDiscountConditionRowId;
			}
			set
			{
				_PordDiscountConditionRowId = "";
			}
		}

		public string PordPayAgreementId
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_PordPayAgreementId))
				{
					_PordPayAgreementId = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "PayAgreement")).PartValue ?? "";
				}
				return _PordPayAgreementId;
			}
			set
			{
				_PordPayAgreementId = "";
			}
		}

		public string OrdTaxPolicyId
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_OrdTaxPolicyId))
				{
					_OrdTaxPolicyId = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "OrdTaxPolicyId")).PartValue ?? "";
				}
				return _OrdTaxPolicyId;
			}
			set
			{
				_OrdTaxPolicyId = "";
			}
		}

		public string OrdTaxPolicyName
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_OrdTaxPolicyName))
				{
					_OrdTaxPolicyName = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "OrdTaxPolicyName")).PartValue ?? "";
				}
				return _OrdTaxPolicyName;
			}
			set
			{
				_OrdTaxPolicyName = "";
			}
		}

		public string OrdTaxConditionId
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_OrdTaxConditionId))
				{
					_OrdTaxConditionId = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "OrdTaxConditionId")).PartValue ?? "";
				}
				return _OrdTaxConditionId;
			}
			set
			{
				_OrdTaxConditionId = "";
			}
		}

		public string OrdTaxConditionRowId
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_OrdTaxConditionRowId))
				{
					_OrdTaxConditionRowId = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "OrdTaxConditionRowId")).PartValue ?? "";
				}
				return _OrdTaxConditionRowId;
			}
			set
			{
				_OrdTaxConditionRowId = "";
			}
		}

		public string OrdDiscountPolicyId
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_OrdDiscountPolicyId))
				{
					_OrdDiscountPolicyId = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "OrdDiscountPolicyId")).PartValue ?? "";
				}
				return _OrdDiscountPolicyId;
			}
			set
			{
				_OrdDiscountPolicyId = "";
			}
		}

		public string OrdDiscountPolicyName
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_OrdDiscountPolicyName))
				{
					_OrdDiscountPolicyName = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "OrdDiscountPolicyName")).PartValue ?? "";
				}
				return _OrdDiscountPolicyName;
			}
			set
			{
				_OrdDiscountPolicyName = "";
			}
		}

		public string OrdDiscountConditionId
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_OrdDiscountConditionId))
				{
					_OrdDiscountConditionId = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "OrdDiscountConditionId")).PartValue ?? "";
				}
				return _OrdDiscountConditionId;
			}
			set
			{
				_OrdDiscountConditionId = "";
			}
		}

		public string OrdDiscountConditionRowId
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_OrdDiscountConditionRowId))
				{
					_OrdDiscountConditionRowId = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "OrdDiscountConditionRowId")).PartValue ?? "";
				}
				return _OrdDiscountConditionRowId;
			}
			set
			{
				_OrdDiscountConditionRowId = "";
			}
		}

		public string OrdPayAgreementId
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_OrdPayAgreementId))
				{
					_OrdPayAgreementId = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "PayAgreement")).PartValue ?? "";
				}
				return _OrdPayAgreementId;
			}
			set
			{
				_OrdPayAgreementId = "";
			}
		}

		public void ClearFields()
		{
			ApiAddress = "";
			ApiUsername = "";
			ApiPassword = "";
			CurrencyRef = 0L;
			AddressTypeSendPrd = 0;
			AddressTypeSendOrd = 0;
			PrdLinkedField = "";
			WrhsSyncTypeId = 0;
			WrhsSyncTypeLinkAccSettingId = 0;
			DefCurrencyUnitId = 0;
			DefPrjTitle = "";
			DefPrjCvnsStatusGroupId = 0;
			PordTaxPolicyId = "";
			PordTaxPolicyName = "";
			PordTaxConditionId = "";
			PordTaxConditionRowId = "";
			PordDiscountPolicyId = "";
			PordDiscountPolicyName = "";
			PordDiscountConditionId = "";
			PordDiscountConditionRowId = "";
			OrdTaxPolicyId = "";
			OrdTaxPolicyName = "";
			OrdTaxConditionId = "";
			OrdTaxConditionRowId = "";
			OrdDiscountPolicyId = "";
			OrdDiscountPolicyName = "";
			OrdDiscountConditionId = "";
			OrdDiscountConditionRowId = "";
			PordPayAgreementId = "";
			OrdPayAgreementId = "";
		}

		public List<CRMspSelectLinkAccSetting_Result> GetLinkAccSetting(bool? readAgain = false)
		{
			if (!readAgain.GetValueOrDefault() && _LinkAccSetting != null)
			{
				return _LinkAccSetting;
			}
			List<CRMspSelectLinkAccSetting_Result> list = new List<CRMspSelectLinkAccSetting_Result>();
			CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
			try
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				int value = 22;
				int value2 = -1;
				list = Enumerable.ToList<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)cRMLinkSpEntities.CRMspSelectLinkAccSetting(0, "", lCID, result, value, value2, null));
				if (list == null)
				{
					list = new List<CRMspSelectLinkAccSetting_Result>();
				}
			}
			catch (Exception ex)
			{
				Public.InsExceptToElmah(ex);
			}
			cRMLinkSpEntities.Dispose();
			return list;
		}

		public SettingDetailsViewModel GetSettingDetails(int settingDetailId = 0, int objId = 0, string objectType = "")
		{
			SettingDetailsViewModel settingDetailsViewModel = new SettingDetailsViewModel();
			CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
			try
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				int value = 22;
				int value2 = -1;
				if (settingDetailId < 0)
				{
					settingDetailId = 0;
				}
				List<CRMspSelectLinkAccSettingDetails_Result> list = Enumerable.ToList<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)cRMLinkSpEntities.CRMspSelectLinkAccSettingDetails(settingDetailId, objId, objectType, lCID, result, value, value2));
				if (list != null)
				{
					if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "HeaderDateType")) != null)
					{
						string partValue = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "HeaderDateType")).PartValue;
						settingDetailsViewModel.PordPayHeaderDateType = ((!string.IsNullOrWhiteSpace(partValue)) ? int.Parse(partValue) : 0);
					}
					if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "DetailDateType")) != null)
					{
						string partValue2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "DetailDateType")).PartValue;
						settingDetailsViewModel.PordPayDetailDateType = ((!string.IsNullOrWhiteSpace(partValue2)) ? int.Parse(partValue2) : 0);
					}
					if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "HeaderDateType")) != null)
					{
						string partValue3 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "HeaderDateType")).PartValue;
						settingDetailsViewModel.OrdPayHeaderDateType = ((!string.IsNullOrWhiteSpace(partValue3)) ? int.Parse(partValue3) : 0);
					}
					if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "DetailDateType")) != null)
					{
						string partValue4 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "DetailDateType")).PartValue;
						settingDetailsViewModel.OrdPayDetailDateType = ((!string.IsNullOrWhiteSpace(partValue4)) ? int.Parse(partValue4) : 0);
					}
					if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "PayAgreement")) != null)
					{
						string partValue5 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "PayAgreement")).PartValue;
						settingDetailsViewModel.PordPayAgreementId = ((!string.IsNullOrWhiteSpace(partValue5)) ? partValue5 : "");
					}
					if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "PayAgreement")) != null)
					{
						string partValue6 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "PayAgreement")).PartValue;
						settingDetailsViewModel.OrdPayAgreementId = ((!string.IsNullOrWhiteSpace(partValue6)) ? partValue6 : "");
					}
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
			finally
			{
				cRMLinkSpEntities.Dispose();
			}
			return settingDetailsViewModel;
		}

		public List<LkCompanyAndPersonViewModel> GetListCompany(bool? isUpdateList = false)
		{
			if (!isUpdateList.GetValueOrDefault() && _ListCompany != null && Enumerable.Any<LkCompanyAndPersonViewModel>((IEnumerable<LkCompanyAndPersonViewModel>)_ListCompany))
			{
				return _ListCompany;
			}
			List<LkCompanyAndPersonViewModel> list = new List<LkCompanyAndPersonViewModel>();
			string value = GetCompanyList("", "", 0L);
			if (!string.IsNullOrWhiteSpace(value))
			{
				if (!string.IsNullOrWhiteSpace(value))
				{
					value = value.ClearHiddenCharacters();
				}
				if (!string.IsNullOrWhiteSpace(value))
				{
					List<RahkaranInternalSalesCustomerResponseViewModel> list2 = JsonConvert.DeserializeObject<List<RahkaranInternalSalesCustomerResponseViewModel>>(value);
					if (list2 != null && Enumerable.Any<RahkaranInternalSalesCustomerResponseViewModel>((IEnumerable<RahkaranInternalSalesCustomerResponseViewModel>)list2))
					{
						int num = 1;
						foreach (RahkaranInternalSalesCustomerResponseViewModel item in list2)
						{
							LkCompanyAndPersonViewModel lkCompanyAndPersonViewModel = new LkCompanyAndPersonViewModel();
							lkCompanyAndPersonViewModel.cmpLinkAccCustomerIdStr = item.ID.GetValueOrDefault().ToString();
							lkCompanyAndPersonViewModel.cmpName = item.CompanyName;
							lkCompanyAndPersonViewModel.cmpLinkAccCode = item.Number;
							lkCompanyAndPersonViewModel.cmpCode = item.DLCode ?? "";
							if (item.PartyRef.GetValueOrDefault() != 0L)
							{
								lkCompanyAndPersonViewModel.cmpLinkAccCodeId = int.Parse(item.PartyRef.GetValueOrDefault().ToString());
								if (lkCompanyAndPersonViewModel.cmpLinkAccCodeId == 0)
								{
									lkCompanyAndPersonViewModel.cmpLinkAccCodeId = null;
								}
							}
							lkCompanyAndPersonViewModel.cmpKind = 0;
							if (item.PartyType.GetValueOrDefault() == 0)
							{
								lkCompanyAndPersonViewModel.cmpKind = 1;
							}
							if (lkCompanyAndPersonViewModel.cmpKind.GetValueOrDefault() == 1)
							{
								lkCompanyAndPersonViewModel.prsFName = item.FirstName;
							}
							lkCompanyAndPersonViewModel.prsLName = item.LastName;
							lkCompanyAndPersonViewModel.RowNumber = num;
							list.Add(lkCompanyAndPersonViewModel);
							num++;
						}
					}
				}
			}
			return list;
		}

		public List<LkProductInfoViewModel> GetListProduct(bool? isUpdateList = false)
		{
			if (!isUpdateList.GetValueOrDefault() && _ListProduct != null && Enumerable.Any<LkProductInfoViewModel>((IEnumerable<LkProductInfoViewModel>)_ListProduct))
			{
				return _ListProduct;
			}
			List<LkProductInfoViewModel> list = new List<LkProductInfoViewModel>();
			string value = GetProductList("", "", 0L);
			if (!string.IsNullOrWhiteSpace(value))
			{
				if (!string.IsNullOrWhiteSpace(value))
				{
					value = value.ClearHiddenCharacters();
				}
				if (!string.IsNullOrWhiteSpace(value))
				{
					List<RahkaranInternalSalesProductResponseViewModel> list2 = JsonConvert.DeserializeObject<List<RahkaranInternalSalesProductResponseViewModel>>(value);
					if (list2 != null && Enumerable.Any<RahkaranInternalSalesProductResponseViewModel>((IEnumerable<RahkaranInternalSalesProductResponseViewModel>)list2))
					{
						int num = 1;
						foreach (RahkaranInternalSalesProductResponseViewModel item in list2)
						{
							if (item != null)
							{
								LkProductInfoViewModel lkProductInfoViewModel = new LkProductInfoViewModel();
								lkProductInfoViewModel.PrdLinkAccPrdIdStr = item.id ?? "";
								lkProductInfoViewModel.PrdLinkAccPrdId = int.Parse(item.partRef ?? "0");
								lkProductInfoViewModel.PrdLinkAccPrdCode = item.number;
								lkProductInfoViewModel.PrdName = item.name;
								list.Add(lkProductInfoViewModel);
								num++;
							}
						}
					}
				}
			}
			return list;
		}

		public RahkaranInternalSalesProvider(bool isUpdateList = false, bool isLogin = true)
		{
			_LinkAccSetting = GetLinkAccSetting(true);
			ClearFields();
			string apiUsername = ApiUsername;
			string apiPassword = ApiPassword;
			try
			{
				client.BaseAddress = new Uri(ApiAddress);
				if (isUpdateList)
				{
					_ListCompany = GetListCompany(isUpdateList);
					_ListProduct = GetListProduct(isUpdateList);
				}
				if (isLogin)
				{
					apiPassword = GeneratePassword(client, apiPassword);
					loginResult = PostAsyncLogin(client, apiUsername, apiPassword, seesionID);
				}
			}
			catch (Exception)
			{
				Public.InsTextToElmah("خطا در ارتباط با سیستم حسابداری، لطفا تنظیمات حسابداری را بررسی کنید.");
			}
		}

		private static byte[] HexStringToBytes(string hex)
		{
			if (hex.Length == 0)
			{
				return new byte[1];
			}
			if (hex.Length % 2 == 1)
			{
				hex = "0" + hex;
			}
			byte[] array = new byte[hex.Length / 2];
			for (int i = 0; i < hex.Length / 2; i++)
			{
				array[i] = byte.Parse(hex.Substring(2 * i, 2), NumberStyles.AllowHexSpecifier);
			}
			return array;
		}

		private static string BytesToHexString(byte[] input)
		{
			StringBuilder stringBuilder = new StringBuilder(64);
			for (int i = 0; i < input.Length; i++)
			{
				stringBuilder.Append($"{input[i]:X2}");
			}
			return stringBuilder.ToString();
		}

		private static string GetAsyncSession(HttpClient client)
		{
			HttpResponseMessage result = client.GetAsync("Framework/Services/AuthenticationService.svc/session").Result;
			string result2 = "";
			if (result.IsSuccessStatusCode)
			{
				result2 = result.Content.ReadAsStringAsync().Result;
			}
			return result2;
		}

		public string GeneratePassword(HttpClient client, string password)
		{
			JObject jObject = JObject.Parse(GetAsyncSession(client));
			string hex = jObject["rsa"]["M"].ToString();
			string hex2 = jObject["rsa"]["E"].ToString();
			string text2 = (seesionID = jObject["id"].ToString());
			RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider();
			rSACryptoServiceProvider.ImportParameters(new RSAParameters
			{
				Exponent = HexStringToBytes(hex2),
				Modulus = HexStringToBytes(hex)
			});
			password = BytesToHexString(rSACryptoServiceProvider.Encrypt(Encoding.UTF8.GetBytes(text2 + "**" + password), fOAEP: false));
			return password;
		}

		private static bool PostAsyncLogin(HttpClient client, string username, string password, string seesionId)
		{
			client.DefaultRequestHeaders.Add("ContentType", "application/json");
			client.DefaultRequestHeaders.Add("Accept", "application/json");
			StringContent content = new StringContent("{\"password\": \"" + password + "\",\"username\": \"" + username + "\",\"sessionId\": \"" + seesionId + "\"}", Encoding.UTF8, "application/json");
			HttpResponseMessage result = client.PostAsync("Framework/Services/AuthenticationService.svc/login", content).Result;
			_ = result.Content.ReadAsStringAsync().Result;
			if (result.IsSuccessStatusCode)
			{
				string value = Enumerable.ToArray<string>(result.Headers.GetValues("Set-Cookie"))[1].Split(new char[1] { ';' })[0] + "; path=/; HttpOnly";
				client.DefaultRequestHeaders.Add("Set-Cookie", value);
				return true;
			}
			return false;
		}

		public string GetCompanyList(string fromDate = "", string toDate = "", long cmpId = 0L)
		{
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
			httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
			string requestUri = "Sales/PartyManagement/Services/PartyManagementService.svc/GetCustomerList";
			string result = "";
			if (loginResult)
			{
				int num = int.MaxValue;
				string text = "{" + $"\"PageSize\": \"{num}\"";
				if (!string.IsNullOrWhiteSpace(fromDate))
				{
					text = text + ",\"FromDate\": \"" + fromDate + "\"";
				}
				if (cmpId != 0L)
				{
					text += $",\"MasterEntityID\": {cmpId}";
				}
				if (!string.IsNullOrWhiteSpace(toDate))
				{
					text = text + ",\"ToDate\": \"" + toDate + "\"";
				}
				text += "}";
				StringContent content = new StringContent(text, Encoding.UTF8, "application/json");
				HttpResponseMessage result2 = httpClient.PostAsync(requestUri, content).Result;
				if (result2.IsSuccessStatusCode)
				{
					result = result2.Content.ReadAsStringAsync().Result;
				}
			}
			return result;
		}

		public string SendCompany(RahkaranInternalSalesCustomerDefineViewModel cmpInfo, ref bool isDone, bool isEdit = false, RahkaranInternalSalesCustomerEditViewModel cmpInfoEdit = null, RahkaranInternalSalesCustomerPartyEditViewModel partyInfoEdit = null)
		{
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
			httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
			string requestUri = "Sales/PartyManagement/Services/PartyManagementService.svc/PlaceCustomer";
			string text = "";
			if (loginResult)
			{
				if (!isEdit)
				{
					StringContent content = new StringContent(JsonConvert.SerializeObject(cmpInfo), Encoding.UTF8, "application/json");
					HttpResponseMessage result = httpClient.PostAsync(requestUri, content).Result;
					text = result.Content.ReadAsStringAsync().Result;
					if (result.IsSuccessStatusCode)
					{
						isDone = true;
					}
				}
				else if (cmpInfoEdit != null && partyInfoEdit != null)
				{
					requestUri = "Sales/PartyManagement/Services/PartyManagementService.svc/UpdateCustomer";
					StringContent content2 = new StringContent(JsonConvert.SerializeObject(cmpInfoEdit), Encoding.UTF8, "application/json");
					HttpResponseMessage result2 = httpClient.PostAsync(requestUri, content2).Result;
					text = result2.Content.ReadAsStringAsync().Result;
					if (result2.IsSuccessStatusCode)
					{
						if (!string.IsNullOrWhiteSpace(text))
						{
							text = text.ClearHiddenCharacters();
						}
						if (!string.IsNullOrWhiteSpace(text) && JsonConvert.DeserializeObject<RahkaranInternalSalesCustomerEditResponseViewModel>(text) != null)
						{
							requestUri = "Sales/PartyManagement/Services/PartyManagementService.svc/UpdateParty";
							content2 = new StringContent(JsonConvert.SerializeObject(partyInfoEdit).Replace("\\\\/", "\\/"), Encoding.UTF8, "application/json");
							result2 = httpClient.PostAsync(requestUri, content2).Result;
							if (result2.IsSuccessStatusCode)
							{
								text = result2.Content.ReadAsStringAsync().Result;
								if (!string.IsNullOrWhiteSpace(text))
								{
									text = text.ClearHiddenCharacters();
								}
								if (string.IsNullOrWhiteSpace(text))
								{
									isDone = true;
									text = "true";
								}
							}
						}
					}
				}
			}
			return text;
		}

		public string SetCompanyGroup(long cmpId, long grouping, long group)
		{
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
			httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
			string requestUri = "System/BusinessRuleEngine/Service.svc/call";
			string text = "";
			if (loginResult && cmpId != 0L && grouping != 0L && group != 0L)
			{
				StringContent content = new StringContent("{\"Name\": \"EraCustomer\",\"Parameters\": \"{'grouping':" + grouping + ",'group':" + group + ",'customer':" + cmpId + "}\"}", Encoding.UTF8, "application/json");
				HttpResponseMessage result = httpClient.PostAsync(requestUri, content).Result;
				text = result.Content.ReadAsStringAsync().Result;
				if (result.IsSuccessStatusCode && text.IndexOf("sys_SerializeUID", StringComparison.Ordinal) >= 0)
				{
					text = "";
				}
			}
			return text;
		}

		public RahkaranInternalSalesBrokerResponseViewModel GetCustomerBrokers(long customerId, long? relatedEntityId = null)
		{
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
			httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
			string requestUri = "Sales/PartyManagement/Services/PartyManagementService.svc/GetCustomerBrokers";
			RahkaranInternalSalesBrokerResponseViewModel rahkaranInternalSalesBrokerResponseViewModel = new RahkaranInternalSalesBrokerResponseViewModel();
			string text = "";
			if (loginResult)
			{
				string text2 = "{" + $"\"CustomerID\": {customerId}";
				if (relatedEntityId.GetValueOrDefault() != 0L)
				{
					text2 += $",\"RelatedEntityID\": {relatedEntityId}";
				}
				text2 += "}";
				StringContent content = new StringContent(text2, Encoding.UTF8, "application/json");
				HttpResponseMessage result = httpClient.PostAsync(requestUri, content).Result;
				if (result.IsSuccessStatusCode)
				{
					text = result.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(text))
					{
						text = text.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(text))
					{
						List<RahkaranInternalSalesBrokerResponseViewModel> list = JsonConvert.DeserializeObject<List<RahkaranInternalSalesBrokerResponseViewModel>>(text);
						if (list != null && Enumerable.Any<RahkaranInternalSalesBrokerResponseViewModel>((IEnumerable<RahkaranInternalSalesBrokerResponseViewModel>)list))
						{
							rahkaranInternalSalesBrokerResponseViewModel = Enumerable.FirstOrDefault<RahkaranInternalSalesBrokerResponseViewModel>((IEnumerable<RahkaranInternalSalesBrokerResponseViewModel>)list, (Func<RahkaranInternalSalesBrokerResponseViewModel, bool>)((RahkaranInternalSalesBrokerResponseViewModel m) => m.IsDefault.GetValueOrDefault()));
							if (rahkaranInternalSalesBrokerResponseViewModel == null)
							{
								rahkaranInternalSalesBrokerResponseViewModel = Enumerable.FirstOrDefault<RahkaranInternalSalesBrokerResponseViewModel>((IEnumerable<RahkaranInternalSalesBrokerResponseViewModel>)list);
							}
							if (rahkaranInternalSalesBrokerResponseViewModel == null)
							{
								rahkaranInternalSalesBrokerResponseViewModel = new RahkaranInternalSalesBrokerResponseViewModel();
							}
						}
					}
				}
			}
			return rahkaranInternalSalesBrokerResponseViewModel;
		}

		public List<LkCrmCompanyGroupsViewModel> GetCustomerGroup()
		{
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
			httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
			string requestUri = "Framework/Services/DataService.svc/fetch";
			List<LkCrmCompanyGroupsViewModel> list = new List<LkCrmCompanyGroupsViewModel>();
			string text = "";
			if (loginResult)
			{
				StringContent content = new StringContent("{\"ComponentName\": \"SystemGroup.General.Grouping\",\"EntityName\": \"EntityGrouping\",\"ViewName\": \"AllEntityGroupings\"}", Encoding.UTF8, "application/json");
				HttpResponseMessage result = httpClient.PostAsync(requestUri, content).Result;
				if (result.IsSuccessStatusCode)
				{
					text = result.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(text))
					{
						text = text.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(text))
					{
						text = text.Replace("\"[", "[").Replace("]\"", "]").Replace("\\\"", "\"");
						List<RahkaranInternalSalesCustomerGroupResponseViewModel> list2 = JsonConvert.DeserializeObject<List<RahkaranInternalSalesCustomerGroupResponseViewModel>>(text);
						if (list2 != null && Enumerable.Any<RahkaranInternalSalesCustomerGroupResponseViewModel>((IEnumerable<RahkaranInternalSalesCustomerGroupResponseViewModel>)list2))
						{
							foreach (RahkaranInternalSalesCustomerGroupResponseViewModel item2 in list2)
							{
								LkCrmCompanyGroupsViewModel item = new LkCrmCompanyGroupsViewModel
								{
									GroupName = item2.Name,
									LinkAccGroupIdStr = item2.ID.GetValueOrDefault().ToString()
								};
								list.Add(item);
							}
						}
					}
				}
				if (list == null)
				{
					list = new List<LkCrmCompanyGroupsViewModel>();
				}
			}
			return list;
		}

		public List<LkCrmCompanySubGroupsViewModel> GetCustomerSubGroup()
		{
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
			httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
			string requestUri = "Framework/Services/DataService.svc/fetch";
			List<LkCrmCompanySubGroupsViewModel> list = new List<LkCrmCompanySubGroupsViewModel>();
			string text = "";
			if (loginResult)
			{
				List<LkCrmCompanyGroupsViewModel> customerGroup = GetCustomerGroup();
				if (customerGroup != null && Enumerable.Any<LkCrmCompanyGroupsViewModel>((IEnumerable<LkCrmCompanyGroupsViewModel>)customerGroup))
				{
					foreach (LkCrmCompanyGroupsViewModel item2 in customerGroup)
					{
						long result = 0L;
						long.TryParse(item2.LinkAccGroupIdStr, out result);
						if (result == 0L)
						{
							continue;
						}
						StringContent content = new StringContent("{\"ComponentName\": \"SystemGroup.General.Grouping\",\"EntityName\": \"EntityGroup\",\"ViewName\": \"EntityGroupsByGrouping\",\"Parameters\":[{\"Name\":\"entityGroupingID\",\"SerializedValue\":" + result + "}]}", Encoding.UTF8, "application/json");
						HttpResponseMessage result2 = httpClient.PostAsync(requestUri, content).Result;
						if (!result2.IsSuccessStatusCode)
						{
							continue;
						}
						text = result2.Content.ReadAsStringAsync().Result;
						if (!string.IsNullOrWhiteSpace(text))
						{
							text = text.ClearHiddenCharacters();
						}
						if (string.IsNullOrWhiteSpace(text))
						{
							continue;
						}
						text = text.Replace("\"[", "[").Replace("]\"", "]").Replace("\\\"", "\"");
						List<RahkaranInternalSalesCustomerSubGroupResponseViewModel> list2 = JsonConvert.DeserializeObject<List<RahkaranInternalSalesCustomerSubGroupResponseViewModel>>(text);
						if (list2 == null || !Enumerable.Any<RahkaranInternalSalesCustomerSubGroupResponseViewModel>((IEnumerable<RahkaranInternalSalesCustomerSubGroupResponseViewModel>)list2))
						{
							continue;
						}
						foreach (RahkaranInternalSalesCustomerSubGroupResponseViewModel item3 in list2)
						{
							LkCrmCompanySubGroupsViewModel item = new LkCrmCompanySubGroupsViewModel
							{
								SubGroupName = item3.Name,
								LinkAccSubGroupIdStr = item3.ID.GetValueOrDefault().ToString(),
								GroupName = item3.Name,
								LinkAccGroupIdStr = result.ToString()
							};
							list.Add(item);
						}
					}
				}
				if (list == null)
				{
					list = new List<LkCrmCompanySubGroupsViewModel>();
				}
			}
			return list;
		}

		public List<RahkaranInternalSalesCustomerGroupAssignedCmpResponseViewModel> GetCustomerGroupAssignedToCmp()
		{
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
			httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
			string requestUri = "Framework/Services/DataService.svc/fetch";
			List<RahkaranInternalSalesCustomerGroupAssignedCmpResponseViewModel> list = new List<RahkaranInternalSalesCustomerGroupAssignedCmpResponseViewModel>();
			string text = "";
			if (loginResult)
			{
				StringContent content = new StringContent("{\"ComponentName\": \"SystemGroup.Sales.PartyManagement\",\"EntityName\": \"CustomerGroupMember\",\"ViewName\": \"CustomerGroupingView\"}", Encoding.UTF8, "application/json");
				HttpResponseMessage result = httpClient.PostAsync(requestUri, content).Result;
				if (result.IsSuccessStatusCode)
				{
					text = result.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(text))
					{
						text = text.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(text))
					{
						text = text.Replace("\"[", "[").Replace("]\"", "]").Replace("\\\"", "\"");
						List<RahkaranInternalSalesCustomerGroupAssignedCmpResponseViewModel> list2 = JsonConvert.DeserializeObject<List<RahkaranInternalSalesCustomerGroupAssignedCmpResponseViewModel>>(text);
						if (list2 != null && Enumerable.Any<RahkaranInternalSalesCustomerGroupAssignedCmpResponseViewModel>((IEnumerable<RahkaranInternalSalesCustomerGroupAssignedCmpResponseViewModel>)list2))
						{
							foreach (RahkaranInternalSalesCustomerGroupAssignedCmpResponseViewModel item in list2)
							{
								list.Add(item);
							}
						}
					}
				}
				if (list == null)
				{
					list = new List<RahkaranInternalSalesCustomerGroupAssignedCmpResponseViewModel>();
				}
			}
			return list;
		}

		public decimal GetCustomerAccounts(long cmpId)
		{
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
			httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
			string text = "Sales/PartyManagement/Services/PartyManagementService.svc/GetCustomerAccounts/";
			decimal result = default(decimal);
			string text2 = "";
			if (loginResult)
			{
				text += cmpId;
				HttpResponseMessage result2 = httpClient.GetAsync(text).Result;
				text2 = result2.Content.ReadAsStringAsync().Result;
				if (result2.IsSuccessStatusCode)
				{
					if (!string.IsNullOrWhiteSpace(text2))
					{
						text2 = text2.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(text2))
					{
						List<RahkaranInternalSalesCustomerAccountsResponseViewModel> list = JsonConvert.DeserializeObject<List<RahkaranInternalSalesCustomerAccountsResponseViewModel>>(text2);
						if (list != null && Enumerable.Any<RahkaranInternalSalesCustomerAccountsResponseViewModel>((IEnumerable<RahkaranInternalSalesCustomerAccountsResponseViewModel>)list))
						{
							RahkaranInternalSalesCustomerAccountsResponseViewModel rahkaranInternalSalesCustomerAccountsResponseViewModel = Enumerable.FirstOrDefault<RahkaranInternalSalesCustomerAccountsResponseViewModel>((IEnumerable<RahkaranInternalSalesCustomerAccountsResponseViewModel>)list);
							if (rahkaranInternalSalesCustomerAccountsResponseViewModel != null)
							{
								decimal result3 = default(decimal);
								decimal.TryParse(rahkaranInternalSalesCustomerAccountsResponseViewModel.balance.ToString(), out result3);
								return result3;
							}
						}
					}
				}
			}
			return result;
		}

		public string GetProductList(string fromDate = "", string toDate = "", long whId = 0L)
		{
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
			httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
			string requestUri = "Sales/ProductManagement/Services/ProductManagementService.svc/GetProducts";
			string result = "";
			if (loginResult)
			{
				int num = int.MaxValue;
				string text = "{" + $"\"PageSize\": \"{num}\"";
				if (!string.IsNullOrWhiteSpace(fromDate))
				{
					text = text + ",\"FromDate\": \"" + fromDate + "\"";
				}
				if (whId != 0L)
				{
					text += $",\"InventoryID\": {whId}";
				}
				text += "}";
				StringContent content = new StringContent(text, Encoding.UTF8, "application/json");
				HttpResponseMessage result2 = httpClient.PostAsync(requestUri, content).Result;
				if (result2.IsSuccessStatusCode)
				{
					result = result2.Content.ReadAsStringAsync().Result;
				}
			}
			return result;
		}

		public double GetPrdQuqntity(long prdId, long whId)
		{
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
			httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
			string requestUri = "Sales/SalesDocument/Services/SalesDocumentService.svc/productInventoryRemainingValue";
			double result = 0.0;
			string text = "";
			if (loginResult)
			{
				int num = 0;
				StringContent content = new StringContent("{" + $"\"ProductID\": \"{prdId}\"" + $",\"InventoryID\": {whId}" + $",\"PlantID\": {num}" + "}", Encoding.UTF8, "application/json");
				HttpResponseMessage result2 = httpClient.PostAsync(requestUri, content).Result;
				if (result2.IsSuccessStatusCode)
				{
					text = result2.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(text))
					{
						text = text.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(text))
					{
						RahkaranInternalSalesProductRemainingResponseViewModel rahkaranInternalSalesProductRemainingResponseViewModel = JsonConvert.DeserializeObject<RahkaranInternalSalesProductRemainingResponseViewModel>(text);
						if (rahkaranInternalSalesProductRemainingResponseViewModel != null)
						{
							result = rahkaranInternalSalesProductRemainingResponseViewModel.ActualRemainingValue ?? rahkaranInternalSalesProductRemainingResponseViewModel.physicalRemainingValue.GetValueOrDefault();
						}
					}
				}
			}
			return result;
		}

		public List<LkWSProductUnitInfoViewModel> GetProductUnits()
		{
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
			httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
			string requestUri = "General/UnitManagement/WebServices/UnitManagementService.svc/GetUnits";
			List<LkWSProductUnitInfoViewModel> list = new List<LkWSProductUnitInfoViewModel>();
			string text = "";
			if (loginResult)
			{
				HttpResponseMessage result = httpClient.GetAsync(requestUri).Result;
				if (result.IsSuccessStatusCode)
				{
					text = result.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(text))
					{
						text = text.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(text))
					{
						List<RahkaranInternalSalesProductUnitResponseViewModel> list2 = JsonConvert.DeserializeObject<List<RahkaranInternalSalesProductUnitResponseViewModel>>(text);
						if (list2 != null && Enumerable.Any<RahkaranInternalSalesProductUnitResponseViewModel>((IEnumerable<RahkaranInternalSalesProductUnitResponseViewModel>)list2))
						{
							foreach (RahkaranInternalSalesProductUnitResponseViewModel item2 in list2)
							{
								LkWSProductUnitInfoViewModel item = new LkWSProductUnitInfoViewModel
								{
									Unit = (item2.Name ?? ""),
									UnitLinkAccUnitIdStr = item2.ID.GetValueOrDefault().ToString()
								};
								list.Add(item);
							}
						}
					}
				}
				if (list == null)
				{
					list = new List<LkWSProductUnitInfoViewModel>();
				}
			}
			return list;
		}

		public string GetStoresList()
		{
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
			httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
			string requestUri = "Logistics/InventoryManagement/WebServices/AnonymousServices/InventoryManagementService.svc/Stores";
			string result = "";
			if (loginResult)
			{
				HttpResponseMessage result2 = httpClient.GetAsync(requestUri).Result;
				if (result2.IsSuccessStatusCode)
				{
					result = result2.Content.ReadAsStringAsync().Result;
				}
			}
			return result;
		}

		public List<RahkaranInternalSalesRegionalDivisionResponseViewModel> GetRegionalDivisionList(int type, long parentId = 0L)
		{
			List<RahkaranInternalSalesRegionalDivisionResponseViewModel> list = new List<RahkaranInternalSalesRegionalDivisionResponseViewModel>();
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
			httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
			string requestUri = "General/AddressManagement/Services/AddressManagementWebService.svc/GetRegionalDivisionList";
			string text = "";
			string content = "";
			if (loginResult)
			{
				new StringContent(content, Encoding.UTF8, "application/json");
				HttpResponseMessage result = httpClient.GetAsync(requestUri).Result;
				if (result.IsSuccessStatusCode)
				{
					text = result.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(text))
					{
						text = text.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(text))
					{
						List<RahkaranInternalSalesRegionalDivisionResponseViewModel> list2 = JsonConvert.DeserializeObject<List<RahkaranInternalSalesRegionalDivisionResponseViewModel>>(text);
						if (list2 != null && Enumerable.Any<RahkaranInternalSalesRegionalDivisionResponseViewModel>((IEnumerable<RahkaranInternalSalesRegionalDivisionResponseViewModel>)list2))
						{
							list = Enumerable.ToList<RahkaranInternalSalesRegionalDivisionResponseViewModel>(Enumerable.Where<RahkaranInternalSalesRegionalDivisionResponseViewModel>((IEnumerable<RahkaranInternalSalesRegionalDivisionResponseViewModel>)list2, (Func<RahkaranInternalSalesRegionalDivisionResponseViewModel, bool>)((RahkaranInternalSalesRegionalDivisionResponseViewModel m) => m.Type.GetValueOrDefault() == type)));
							if (parentId != 0L && list != null && Enumerable.Any<RahkaranInternalSalesRegionalDivisionResponseViewModel>((IEnumerable<RahkaranInternalSalesRegionalDivisionResponseViewModel>)list))
							{
								list = Enumerable.ToList<RahkaranInternalSalesRegionalDivisionResponseViewModel>(Enumerable.Where<RahkaranInternalSalesRegionalDivisionResponseViewModel>((IEnumerable<RahkaranInternalSalesRegionalDivisionResponseViewModel>)list, (Func<RahkaranInternalSalesRegionalDivisionResponseViewModel, bool>)((RahkaranInternalSalesRegionalDivisionResponseViewModel m) => m.ParentID.GetValueOrDefault() == parentId)));
							}
						}
					}
				}
				if (list == null)
				{
					list = new List<RahkaranInternalSalesRegionalDivisionResponseViewModel>();
				}
			}
			return list;
		}

		public string GetBrokers()
		{
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
			httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
			string requestUri = "Sales/PartyManagement/Services/PartyManagementService.svc/GetBrokers";
			string result = "";
			if (loginResult)
			{
				HttpResponseMessage result2 = httpClient.GetAsync(requestUri).Result;
				if (result2.IsSuccessStatusCode)
				{
					result = result2.Content.ReadAsStringAsync().Result;
				}
			}
			return result;
		}

		public List<LkWSCurrencyUnitInfoViewModel> GetAllCurrencies()
		{
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
			httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
			string requestUri = "General/CurrencyManagement/Services/CurrencyWebService.svc/GetAllCurrencies";
			List<LkWSCurrencyUnitInfoViewModel> list = new List<LkWSCurrencyUnitInfoViewModel>();
			string text = "";
			if (loginResult)
			{
				HttpResponseMessage result = httpClient.GetAsync(requestUri).Result;
				if (result.IsSuccessStatusCode)
				{
					text = result.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(text))
					{
						text = text.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(text))
					{
						List<RahkaranInternalSalesCurrencyUnitResponseViewModel> list2 = JsonConvert.DeserializeObject<List<RahkaranInternalSalesCurrencyUnitResponseViewModel>>(text);
						if (list2 != null && Enumerable.Any<RahkaranInternalSalesCurrencyUnitResponseViewModel>((IEnumerable<RahkaranInternalSalesCurrencyUnitResponseViewModel>)list2))
						{
							foreach (RahkaranInternalSalesCurrencyUnitResponseViewModel item2 in list2)
							{
								LkWSCurrencyUnitInfoViewModel item = new LkWSCurrencyUnitInfoViewModel
								{
									CurrencyUnit = (item2.Title ?? ""),
									LinkAccCurrencyUnitIdStr = item2.ID.GetValueOrDefault().ToString()
								};
								list.Add(item);
							}
						}
					}
				}
				if (list == null)
				{
					list = new List<LkWSCurrencyUnitInfoViewModel>();
				}
			}
			return list;
		}

		public List<LkWSSaleCenterInfoViewModel> GetSalesOffices()
		{
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
			httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
			string requestUri = "Sales/SalesStructure/Services/SalesStructureService.svc/GetSalesOffices";
			List<LkWSSaleCenterInfoViewModel> list = new List<LkWSSaleCenterInfoViewModel>();
			string text = "";
			if (loginResult)
			{
				HttpResponseMessage result = httpClient.GetAsync(requestUri).Result;
				if (result.IsSuccessStatusCode)
				{
					text = result.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(text))
					{
						text = text.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(text))
					{
						List<RahkaranInternalSalesSalesOfficeResponseViewModel> list2 = JsonConvert.DeserializeObject<List<RahkaranInternalSalesSalesOfficeResponseViewModel>>(text);
						if (list2 != null && Enumerable.Any<RahkaranInternalSalesSalesOfficeResponseViewModel>((IEnumerable<RahkaranInternalSalesSalesOfficeResponseViewModel>)list2))
						{
							foreach (RahkaranInternalSalesSalesOfficeResponseViewModel item2 in list2)
							{
								LkWSSaleCenterInfoViewModel item = new LkWSSaleCenterInfoViewModel
								{
									SaleCenterName = (item2.name ?? ""),
									LinkAccSaleCenterIdStr = item2.id
								};
								list.Add(item);
							}
						}
					}
				}
				if (list == null)
				{
					list = new List<LkWSSaleCenterInfoViewModel>();
				}
			}
			return list;
		}

		public List<LkWSSaleAreaInfoViewModel> GetSalesAreas()
		{
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
			httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
			string requestUri = "Sales/SalesStructure/Services/SalesStructureService.svc/GetSalesAreas";
			List<LkWSSaleAreaInfoViewModel> list = new List<LkWSSaleAreaInfoViewModel>();
			string text = "";
			if (loginResult)
			{
				HttpResponseMessage result = httpClient.GetAsync(requestUri).Result;
				if (result.IsSuccessStatusCode)
				{
					text = result.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(text))
					{
						text = text.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(text))
					{
						List<RahkaranInternalSalesSaleAreaResponseViewModel> list2 = JsonConvert.DeserializeObject<List<RahkaranInternalSalesSaleAreaResponseViewModel>>(text);
						if (list2 != null && Enumerable.Any<RahkaranInternalSalesSaleAreaResponseViewModel>((IEnumerable<RahkaranInternalSalesSaleAreaResponseViewModel>)list2))
						{
							foreach (RahkaranInternalSalesSaleAreaResponseViewModel item2 in list2)
							{
								LkWSSaleAreaInfoViewModel item = new LkWSSaleAreaInfoViewModel
								{
									SaleAreaName = (item2.name ?? ""),
									LinkAccSaleAreaIdStr = item2.id
								};
								list.Add(item);
							}
						}
					}
				}
				if (list == null)
				{
					list = new List<LkWSSaleAreaInfoViewModel>();
				}
			}
			return list;
		}

		public List<LkWSPreOrderTypesInfoViewModel> GetSalesTypes()
		{
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
			httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
			string requestUri = "Sales/SalesStructure/Services/SalesStructureService.svc/GetSalesTypes";
			List<LkWSPreOrderTypesInfoViewModel> list = new List<LkWSPreOrderTypesInfoViewModel>();
			string text = "";
			if (loginResult)
			{
				HttpResponseMessage result = httpClient.GetAsync(requestUri).Result;
				if (result.IsSuccessStatusCode)
				{
					text = result.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(text))
					{
						text = text.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(text))
					{
						List<RahkaranInternalSalesTypeResponseViewModel> list2 = JsonConvert.DeserializeObject<List<RahkaranInternalSalesTypeResponseViewModel>>(text);
						if (list2 != null && Enumerable.Any<RahkaranInternalSalesTypeResponseViewModel>((IEnumerable<RahkaranInternalSalesTypeResponseViewModel>)list2))
						{
							foreach (RahkaranInternalSalesTypeResponseViewModel item2 in list2)
							{
								LkWSPreOrderTypesInfoViewModel item = new LkWSPreOrderTypesInfoViewModel
								{
									PreOrderType = (item2.name ?? ""),
									LinkAccPreOrderTypeIdStr = item2.id
								};
								list.Add(item);
							}
						}
					}
				}
				if (list == null)
				{
					list = new List<LkWSPreOrderTypesInfoViewModel>();
				}
			}
			return list;
		}

		public List<LkWSPreOrderOprInfoViewModel> GetSPlants()
		{
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
			httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
			string requestUri = "Logistics/InventoryManagement/WebServices/AnonymousServices/InventoryManagementService.svc/Stores";
			List<LkWSPreOrderOprInfoViewModel> list = new List<LkWSPreOrderOprInfoViewModel>();
			string text = "";
			if (loginResult)
			{
				HttpResponseMessage result = httpClient.GetAsync(requestUri).Result;
				if (result.IsSuccessStatusCode)
				{
					text = result.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(text))
					{
						text = text.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(text))
					{
						List<RahkaranInternalSalesStoresResponseViewModel> list2 = JsonConvert.DeserializeObject<List<RahkaranInternalSalesStoresResponseViewModel>>(text);
						if (list2 != null && Enumerable.Any<RahkaranInternalSalesStoresResponseViewModel>((IEnumerable<RahkaranInternalSalesStoresResponseViewModel>)list2))
						{
							foreach (RahkaranInternalSalesStoresResponseViewModel item2 in list2)
							{
								LkWSPreOrderOprInfoViewModel item = new LkWSPreOrderOprInfoViewModel
								{
									PreOrderOpr = (item2.PlantName ?? ""),
									LinkAccPreOrderOprIdStr = item2.PlantRef.GetValueOrDefault().ToString()
								};
								list.Add(item);
							}
						}
					}
				}
				if (list == null)
				{
					list = new List<LkWSPreOrderOprInfoViewModel>();
				}
			}
			return list;
		}

		public string SendCalculatePolicies(RahkaranInternalSalesCalculatePoliciesDefineResponseViewModel calculatePoliciesInfo, ref bool isDone)
		{
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
			httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
			string requestUri = "Sales/OrderManagement/Services/OrderManagementService.svc/CalculatePolicies";
			string result = "";
			if (loginResult && calculatePoliciesInfo != null)
			{
				StringContent content = new StringContent(JsonConvert.SerializeObject(calculatePoliciesInfo).Replace("\\\\/Date(", "\\/Date(").Replace(")\\\\/", ")\\/"), Encoding.UTF8, "application/json");
				HttpResponseMessage result2 = httpClient.PostAsync(requestUri, content).Result;
				result = result2.Content.ReadAsStringAsync().Result;
				if (result2.IsSuccessStatusCode)
				{
					isDone = true;
				}
			}
			return result;
		}

		public string GetQuotationsList(string fromDate = "", string toDate = "", long linkAccId = 0L)
		{
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
			httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
			string requestUri = "Sales/OrderManagement/Services/OrderManagementService.svc/GetQuotations";
			string result = "";
			if (loginResult)
			{
				int num = int.MaxValue;
				string text = "{" + $"\"PageSize\": \"{num}\"";
				if (!string.IsNullOrWhiteSpace(fromDate))
				{
					text = text + ",\"FromDate\": \"" + fromDate + "\"";
				}
				if (linkAccId != 0L)
				{
					text += $",\"MasterEntityID\": {linkAccId}";
				}
				if (!string.IsNullOrWhiteSpace(toDate))
				{
					text = text + ",\"ToDate\": \"" + toDate + "\"";
				}
				text += "}";
				StringContent content = new StringContent(text, Encoding.UTF8, "application/json");
				HttpResponseMessage result2 = httpClient.PostAsync(requestUri, content).Result;
				if (result2.IsSuccessStatusCode)
				{
					result = result2.Content.ReadAsStringAsync().Result;
				}
			}
			return result;
		}

		public string SendPreOrder(RahkaranInternalSalesQuotationDefineResponseViewModel pordInfo, ref long linkAccId)
		{
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
			httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
			string requestUri = "Sales/OrderManagement/Services/OrderManagementService.svc/PlaceQuotation";
			string text = "";
			if (loginResult && pordInfo != null)
			{
				StringContent content = new StringContent(JsonConvert.SerializeObject(pordInfo).Replace("\\\\/Date(", "\\/Date(").Replace(")\\\\/", ")\\/"), Encoding.UTF8, "application/json");
				HttpResponseMessage result = httpClient.PostAsync(requestUri, content).Result;
				text = result.Content.ReadAsStringAsync().Result;
				if (result.IsSuccessStatusCode)
				{
					long.TryParse(text, out linkAccId);
				}
			}
			return text;
		}

		public string GetInvoicesList(string fromDate = "", string toDate = "", int oprType = 1, long linkAccId = 0L)
		{
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
			httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
			string requestUri = "Sales/InvoiceManagement/Services/InvoiceManagementService.svc/GetInvoices";
			if (oprType == 2)
			{
				requestUri = "Sales/InvoiceManagement/Services/InvoiceManagementService.svc/GetReturnInvoices";
			}
			string result = "";
			if (loginResult)
			{
				int num = int.MaxValue;
				string text = "{" + $"\"PageSize\": \"{num}\"";
				if (!string.IsNullOrWhiteSpace(fromDate))
				{
					text = text + ",\"FromDate\": \"" + fromDate + "\"";
				}
				if (linkAccId != 0L)
				{
					text += $",\"MasterEntityID\": {linkAccId}";
				}
				if (!string.IsNullOrWhiteSpace(toDate))
				{
					text = text + ",\"ToDate\": \"" + toDate + "\"";
				}
				text += "}";
				StringContent content = new StringContent(text, Encoding.UTF8, "application/json");
				HttpResponseMessage result2 = httpClient.PostAsync(requestUri, content).Result;
				if (result2.IsSuccessStatusCode)
				{
					result = result2.Content.ReadAsStringAsync().Result;
				}
			}
			return result;
		}

		public string SendCalculateInvoicePolicies(RahkaranInternalSalesCalculatePoliciesDefineResponseViewModel calculatePoliciesInfo, int oprType, ref bool isDone)
		{
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
			httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
			string requestUri = "Sales/InvoiceManagement/Services/InvoiceManagementService.svc/CalculateInvoicePolicies";
			string result = "";
			if (loginResult && calculatePoliciesInfo != null)
			{
				StringContent content = new StringContent(JsonConvert.SerializeObject(calculatePoliciesInfo).Replace("\\\\/Date(", "\\/Date(").Replace(")\\\\/", ")\\/"), Encoding.UTF8, "application/json");
				HttpResponseMessage result2 = httpClient.PostAsync(requestUri, content).Result;
				result = result2.Content.ReadAsStringAsync().Result;
				if (result2.IsSuccessStatusCode)
				{
					isDone = true;
				}
			}
			return result;
		}

		public string SendOrder(RahkaranInternalSalesInvoiceDefineResponseViewModel ordInfo, int oprType, ref long linkAccId)
		{
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
			httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
			string requestUri = "Sales/InvoiceManagement/Services/InvoiceManagementService.svc/PlaceInvoice";
			string text = "";
			if (loginResult && ordInfo != null)
			{
				StringContent content = new StringContent(JsonConvert.SerializeObject(ordInfo).Replace("\\\\/Date(", "\\/Date(").Replace(")\\\\/", ")\\/"), Encoding.UTF8, "application/json");
				HttpResponseMessage result = httpClient.PostAsync(requestUri, content).Result;
				text = result.Content.ReadAsStringAsync().Result;
				if (result.IsSuccessStatusCode)
				{
					long.TryParse(text, out linkAccId);
				}
			}
			return text;
		}

		public List<LKCrmCashesViewModel> GetAllCashes()
		{
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
			httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
			string requestUri = "ReceiptAndPayment/TreasuryStructure/Services/TreasuryStructureService.svc/GetAllCashes";
			List<LKCrmCashesViewModel> list = new List<LKCrmCashesViewModel>();
			string text = "";
			if (loginResult)
			{
				HttpResponseMessage result = httpClient.GetAsync(requestUri).Result;
				if (result.IsSuccessStatusCode)
				{
					text = result.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(text))
					{
						text = text.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(text))
					{
						List<RahkaranInternalSalesCashResponseViewModel> list2 = JsonConvert.DeserializeObject<List<RahkaranInternalSalesCashResponseViewModel>>(text);
						if (list2 != null && Enumerable.Any<RahkaranInternalSalesCashResponseViewModel>((IEnumerable<RahkaranInternalSalesCashResponseViewModel>)list2))
						{
							foreach (RahkaranInternalSalesCashResponseViewModel item2 in list2)
							{
								LKCrmCashesViewModel item = new LKCrmCashesViewModel
								{
									CashTitle = (item2.Title ?? ""),
									LinkAccIdStr = item2.ID.GetValueOrDefault().ToString()
								};
								list.Add(item);
							}
						}
					}
				}
				if (list == null)
				{
					list = new List<LKCrmCashesViewModel>();
				}
			}
			return list;
		}

		public List<LKCrmBankingBanksViewModel> GetAllBanks()
		{
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
			httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
			string requestUri = "ReceiptAndPayment/TreasuryStructure/Services/TreasuryStructureService.svc/GetAllBanks";
			List<LKCrmBankingBanksViewModel> list = new List<LKCrmBankingBanksViewModel>();
			string text = "";
			if (loginResult)
			{
				HttpResponseMessage result = httpClient.GetAsync(requestUri).Result;
				if (result.IsSuccessStatusCode)
				{
					text = result.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(text))
					{
						text = text.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(text))
					{
						List<RahkaranInternalSalesBankResponseViewModel> list2 = JsonConvert.DeserializeObject<List<RahkaranInternalSalesBankResponseViewModel>>(text);
						if (list2 != null && Enumerable.Any<RahkaranInternalSalesBankResponseViewModel>((IEnumerable<RahkaranInternalSalesBankResponseViewModel>)list2))
						{
							foreach (RahkaranInternalSalesBankResponseViewModel item2 in list2)
							{
								LKCrmBankingBanksViewModel item = new LKCrmBankingBanksViewModel
								{
									BankName = (item2.Title ?? ""),
									LinkAccIdStr = item2.ID.GetValueOrDefault().ToString(),
									LinkAccCode = (item2.Code ?? "")
								};
								list.Add(item);
							}
						}
					}
				}
				if (list == null)
				{
					list = new List<LKCrmBankingBanksViewModel>();
				}
			}
			return list;
		}

		public List<LKCrmBankingBranchesViewModel> GetAllBankBranches()
		{
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
			httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
			string requestUri = "ReceiptAndPayment/TreasuryStructure/Services/TreasuryStructureService.svc/GetAllBankBranches";
			List<LKCrmBankingBranchesViewModel> list = new List<LKCrmBankingBranchesViewModel>();
			string text = "";
			if (loginResult)
			{
				HttpResponseMessage result = httpClient.GetAsync(requestUri).Result;
				if (result.IsSuccessStatusCode)
				{
					text = result.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(text))
					{
						text = text.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(text))
					{
						List<RahkaranInternalSalesBankBranchResponseViewModel> list2 = JsonConvert.DeserializeObject<List<RahkaranInternalSalesBankBranchResponseViewModel>>(text);
						if (list2 != null && Enumerable.Any<RahkaranInternalSalesBankBranchResponseViewModel>((IEnumerable<RahkaranInternalSalesBankBranchResponseViewModel>)list2))
						{
							foreach (RahkaranInternalSalesBankBranchResponseViewModel item2 in list2)
							{
								LKCrmBankingBranchesViewModel item = new LKCrmBankingBranchesViewModel
								{
									BranchName = (item2.Name ?? ""),
									LinkAccIdStr = item2.BankBranchID.GetValueOrDefault().ToString(),
									LinkAccCode = (item2.Code ?? ""),
									LinkAccBnkIdStr = item2.BankRef.GetValueOrDefault().ToString()
								};
								list.Add(item);
							}
						}
					}
				}
				if (list == null)
				{
					list = new List<LKCrmBankingBranchesViewModel>();
				}
			}
			return list;
		}

		public List<LKCrmBankingAccountsViewModel> GetAllBankAccounts()
		{
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
			httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
			string requestUri = "ReceiptAndPayment/TreasuryStructure/Services/TreasuryStructureService.svc/GetAllBankAccounts";
			List<LKCrmBankingAccountsViewModel> list = new List<LKCrmBankingAccountsViewModel>();
			string text = "";
			if (loginResult)
			{
				HttpResponseMessage result = httpClient.GetAsync(requestUri).Result;
				if (result.IsSuccessStatusCode)
				{
					text = result.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(text))
					{
						text = text.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(text))
					{
						List<RahkaranInternalSalesBankAccountResponseViewModel> list2 = JsonConvert.DeserializeObject<List<RahkaranInternalSalesBankAccountResponseViewModel>>(text);
						if (list2 != null && Enumerable.Any<RahkaranInternalSalesBankAccountResponseViewModel>((IEnumerable<RahkaranInternalSalesBankAccountResponseViewModel>)list2))
						{
							foreach (RahkaranInternalSalesBankAccountResponseViewModel item2 in list2)
							{
								LKCrmBankingAccountsViewModel item = new LKCrmBankingAccountsViewModel
								{
									AccountNumber = (item2.AccountNumber ?? ""),
									AccountTitle = (item2.AccountNumber ?? ""),
									LinkAccIdStr = item2.ID.GetValueOrDefault().ToString(),
									BranchName = (item2.BankBranchTitle ?? ""),
									LinkAccCode = (item2.BankBranchCode ?? ""),
									BankName = (item2.BankName ?? ""),
									LinkAccBnkCode = (item2.BankCode ?? "")
								};
								list.Add(item);
							}
						}
					}
				}
				if (list == null)
				{
					list = new List<LKCrmBankingAccountsViewModel>();
				}
			}
			return list;
		}

		public List<LKWSOrderPaymentGroupsIViewModel> GetAllAccountingOperations()
		{
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
			httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
			string requestUri = "ReceiptAndPayment/FinancialOperation/Services/FinancialOperationService.svc/GetAllAccountingOperations";
			List<LKWSOrderPaymentGroupsIViewModel> list = new List<LKWSOrderPaymentGroupsIViewModel>();
			string text = "";
			if (loginResult)
			{
				HttpResponseMessage result = httpClient.GetAsync(requestUri).Result;
				if (result.IsSuccessStatusCode)
				{
					text = result.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(text))
					{
						text = text.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(text))
					{
						List<RahkaranInternalSalesAccountingOperationResponseViewModel> list2 = JsonConvert.DeserializeObject<List<RahkaranInternalSalesAccountingOperationResponseViewModel>>(text);
						if (list2 != null && Enumerable.Any<RahkaranInternalSalesAccountingOperationResponseViewModel>((IEnumerable<RahkaranInternalSalesAccountingOperationResponseViewModel>)list2))
						{
							foreach (RahkaranInternalSalesAccountingOperationResponseViewModel item2 in list2)
							{
								LKWSOrderPaymentGroupsIViewModel item = new LKWSOrderPaymentGroupsIViewModel
								{
									GroupName = (item2.Title ?? ""),
									LinkAccCode = (item2.Code ?? ""),
									LinkAccIdStr = item2.ID.GetValueOrDefault().ToString()
								};
								list.Add(item);
							}
						}
					}
				}
				if (list == null)
				{
					list = new List<LKWSOrderPaymentGroupsIViewModel>();
				}
			}
			return list;
		}

		public List<LKWSOrderPaymentGroupsIIViewModel> GetAllCashFlowFactors()
		{
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
			httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
			string requestUri = "ReceiptAndPayment/FinancialOperation/Services/FinancialOperationService.svc/GetAllCashFlowFactors";
			List<LKWSOrderPaymentGroupsIIViewModel> list = new List<LKWSOrderPaymentGroupsIIViewModel>();
			string text = "";
			if (loginResult)
			{
				HttpResponseMessage result = httpClient.GetAsync(requestUri).Result;
				if (result.IsSuccessStatusCode)
				{
					text = result.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(text))
					{
						text = text.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(text))
					{
						List<RahkaranInternalSalesCashFlowFactorResponseViewModel> list2 = JsonConvert.DeserializeObject<List<RahkaranInternalSalesCashFlowFactorResponseViewModel>>(text);
						if (list2 != null && Enumerable.Any<RahkaranInternalSalesCashFlowFactorResponseViewModel>((IEnumerable<RahkaranInternalSalesCashFlowFactorResponseViewModel>)list2))
						{
							foreach (RahkaranInternalSalesCashFlowFactorResponseViewModel item2 in list2)
							{
								LKWSOrderPaymentGroupsIIViewModel item = new LKWSOrderPaymentGroupsIIViewModel
								{
									GroupName = (item2.Title ?? ""),
									LinkAccCode = (item2.Code ?? ""),
									LinkAccIdStr = item2.ID.GetValueOrDefault().ToString()
								};
								list.Add(item);
							}
						}
					}
				}
				if (list == null)
				{
					list = new List<LKWSOrderPaymentGroupsIIViewModel>();
				}
			}
			return list;
		}

		public string SendPayment(int mode, RahkaranInternalSalesReceiptViewModel receipt, RahkaranInternalSalesPaymentViewModel payment, ref long linkAccId, ref string linkAccNumber, ref string errorMsg)
		{
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
			httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
			string requestUri = "ReceiptAndPayment/ReceiptManagement/Services/ReceiptManagementService.svc/RegisterReceipt";
			if (mode == 2)
			{
				requestUri = "ReceiptAndPayment/PaymentManagement/Services/PaymentManagementService.svc/RegisterPayment";
			}
			string text = "";
			if (loginResult)
			{
				string text2 = "";
				if (mode == 1)
				{
					if (receipt != null)
					{
						text2 = JsonConvert.SerializeObject(receipt);
					}
				}
				else if (payment != null)
				{
					text2 = JsonConvert.SerializeObject(payment);
				}
				text2 = text2.Replace("\\\\/Date(", "\\/Date(").Replace(")\\\\/", ")\\/");
				StringContent content = new StringContent(text2, Encoding.UTF8, "application/json");
				HttpResponseMessage result = httpClient.PostAsync(requestUri, content).Result;
				text = result.Content.ReadAsStringAsync().Result;
				if (result.IsSuccessStatusCode)
				{
					if (!string.IsNullOrWhiteSpace(text))
					{
						text = text.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(text))
					{
						RahkaranInternalSalesReceiptAndPaymentResultViewModel rahkaranInternalSalesReceiptAndPaymentResultViewModel = JsonConvert.DeserializeObject<RahkaranInternalSalesReceiptAndPaymentResultViewModel>(text);
						if (rahkaranInternalSalesReceiptAndPaymentResultViewModel != null)
						{
							linkAccId = rahkaranInternalSalesReceiptAndPaymentResultViewModel.ID.GetValueOrDefault();
							linkAccNumber = rahkaranInternalSalesReceiptAndPaymentResultViewModel.Number ?? "";
							if (linkAccId <= 0 && rahkaranInternalSalesReceiptAndPaymentResultViewModel.ValidationErrors != null && rahkaranInternalSalesReceiptAndPaymentResultViewModel.ValidationErrors.Length != 0)
							{
								string[] validationErrors = rahkaranInternalSalesReceiptAndPaymentResultViewModel.ValidationErrors;
								foreach (string text3 in validationErrors)
								{
									if (!string.IsNullOrWhiteSpace(text3))
									{
										if (!string.IsNullOrWhiteSpace(errorMsg))
										{
											errorMsg += ",";
										}
										errorMsg += text3;
									}
								}
							}
						}
					}
				}
			}
			return text;
		}

		public List<SelectListItem> GetPaymentAgreement()
		{
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
			httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
			string requestUri = "Framework/Services/DataService.svc/fetch";
			List<SelectListItem> list = new List<SelectListItem>();
			string text = "";
			if (loginResult)
			{
				StringContent content = new StringContent("{\"ComponentName\": \"SystemGroup.Sales.PaymentAgreementManagement\",\"EntityName\": \"PaymentAgreement\",\"ViewName\": \"AllActivePaymentAgreements\"}", Encoding.UTF8, "application/json");
				HttpResponseMessage result = httpClient.PostAsync(requestUri, content).Result;
				if (result.IsSuccessStatusCode)
				{
					text = result.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(text))
					{
						text = text.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(text))
					{
						text = text.Replace("\"[", "[").Replace("]\"", "]").Replace("\\\"", "\"");
						List<RahkaranInternalSalesPaymentAgreementResponseViewModel> list2 = JsonConvert.DeserializeObject<List<RahkaranInternalSalesPaymentAgreementResponseViewModel>>(text);
						if (list2 != null && Enumerable.Any<RahkaranInternalSalesPaymentAgreementResponseViewModel>((IEnumerable<RahkaranInternalSalesPaymentAgreementResponseViewModel>)list2))
						{
							foreach (RahkaranInternalSalesPaymentAgreementResponseViewModel item2 in list2)
							{
								SelectListItem item = new SelectListItem
								{
									Text = item2.Title,
									Value = item2.ID.GetValueOrDefault().ToString()
								};
								list.Add(item);
							}
						}
					}
				}
				if (list == null)
				{
					list = new List<SelectListItem>();
				}
			}
			return list;
		}
	}

	public class RayvarzProvider
	{
		public class RayvarzSettingDetailsViewModel
		{
			public long OrdWebDocTypeId { get; set; }

			public long OrdSalesTypeId { get; set; }

			public long OrdReceiveTypeId { get; set; }

			public string OrdUserId { get; set; }

			public string OrdCurrencyId { get; set; }

			public long OrdDiscountTypeId { get; set; }

			public long OrdSalesDocTypeId { get; set; }

			public long OrdReturnReasonId { get; set; }

			public long OrdSalesDocProduceTypeId { get; set; }

			public long OrdPayCashTypeId { get; set; }

			public long OrdPayFundId { get; set; }

			public long OrdPaySubjectId { get; set; }

			public long OrdPayCenter1Id { get; set; }

			public long OrdPaySeries { get; set; }

			public int OrdPayHeaderDateType { get; set; }

			public int OrdPayDetailDateType { get; set; }

			public string OrdPayShopName { get; set; }

			public long PordWebDocTypeId { get; set; }

			public long PordSalesTypeId { get; set; }

			public long PordReceiveTypeId { get; set; }

			public string PordUserId { get; set; }

			public string PordCurrencyId { get; set; }

			public long PordDiscountTypeId { get; set; }

			public long PordSalesDocTypeId { get; set; }

			public long PordReturnReasonId { get; set; }

			public long PordSalesDocProduceTypeId { get; set; }

			public string SaleCenterAccCode { get; set; }
		}

		private const string authAddressPath = "RayvarzApi/Core/Sso/Authenticate";

		public HttpClient client = new HttpClient();

		private string _AccessToken = "";

		public const string _KeyName_Address = "ApiAddress";

		public const string _KeyName_Username = "ApiUsername";

		public const string _KeyName_Password = "ApiPassword";

		public const string _KeyName_BranchId = "ApiBranchId";

		public const string _KeyName_FiscalYear = "FiscalYear";

		public const string _KeyName_PrdLinkedField = "PrdLinkedField";

		public const string _KeyName_WrhsSyncTypeId = "WrhsSyncTypeId";

		public const string _KeyName_DefCurrencyUnitId = "DefCurrencyUnitId";

		public const string _KeyName_DefPrjTitle = "DefPrjTitle";

		public const string _KeyName_DefPrjCvnsStatusGroupId = "DefPrjCvnsStatusGroupId";

		public const string _KeyName_LegalCenterGroupId = "LegalCenterGroupId";

		public const string _KeyName_LegalParentCenterId = "LegalParentCenterId";

		public const string _KeyName_RealCenterGroupId = "RealCenterGroupId";

		public const string _KeyName_RealParentCenterId = "RealParentCenterId";

		public const string _KeyName_CmpAccountRemainMode = "CmpAccountRemainMode";

		public const string _KeyName_CmpDiscountTypeId = "CmpDiscountTypeId";

		public const string _KeyName_OrdPayTypeCashTypeId = "CashTypeId";

		public const string _KeyName_OrdPayTypeFundId = "FundId";

		public const string _KeyName_OrdPayTypeSubjectId = "SubjectId";

		public const string _KeyName_OrdPayTypeCenter1Id = "Center1Id";

		public const string _KeyName_OrdPayTypeSeries = "Series";

		public const string _KeyName_OrdPayTypeHeaderDateType = "HeaderDateType";

		public const string _KeyName_OrdPayTypeDetailDateType = "DetailDateType";

		public const string _KeyName_OrdPayTypeShopName = "ShopName";

		public const string _KeyName_CmpAccountRemainCriterion = "CmpAccountRemainCriterion";

		public const string _KeyName_PordFieldLinkedToAcc = "PordFieldLinkedToAcc";

		public const string _KeyName_LegalTaxSubId = "LegalTaxSubId";

		public const string _KeyName_RealTaxSubId = "RealTaxSubId";

		public const string _KeyName_PordLinkedToAccApiMode = "PordLinkedToAccApiMode";

		public const string _KeyName_OrdLinkedToAccApiMode = "OrdLinkedToAccApiMode";

		private static string _ApiAddress = "";

		private static string _ApiUsername = "";

		private static string _ApiPassword = "";

		private static string _ApiBranchId = "";

		private static string _FiscalYear = "";

		private static long _FiscalYearId = 0L;

		private static string _PrdLinkedField = "";

		private static int _WrhsSyncTypeId = 0;

		private static int _WrhsSyncTypeLinkAccSettingId = 0;

		private static int _DefCurrencyUnitId = 0;

		private static string _DefPrjTitle = "";

		private static int _DefPrjCvnsStatusGroupId = 0;

		private static long _LegalCenterGroupId = 0L;

		private static long _LegalParentCenterId = 0L;

		private static long _RealCenterGroupId = 0L;

		private static long _RealParentCenterId = 0L;

		private static string _CmpAccountRemainMode = "";

		private static string _CmpAccountRemainCriterion = "";

		private static long _CmpDiscountTypeId = 0L;

		private static string _PordFieldLinkedToAcc = "";

		private static int _LegalTaxSubId = 0;

		private static int _RealTaxSubId = 0;

		private static int _PordLinkedToAccApiMode = 0;

		private static int _OrdLinkedToAccApiMode = 0;

		private static List<CRMspSelectLinkAccSetting_Result> _LinkAccSetting = null;

		private static List<LkProductInfoViewModel> _ListProduct = null;

		public bool loginResult { get; set; }

		public string AccessToken
		{
			get
			{
				return _AccessToken;
			}
			set
			{
				_AccessToken = value;
			}
		}

		public string ApiAddress
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_ApiAddress))
				{
					_ApiAddress = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "ApiAddress")).PartValue ?? "";
				}
				if (!string.IsNullOrWhiteSpace(_ApiAddress) && !_ApiAddress.EndsWith("/"))
				{
					_ApiAddress += "/";
				}
				return _ApiAddress;
			}
			set
			{
				_ApiAddress = "";
			}
		}

		public string ApiUsername
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_ApiUsername))
				{
					_ApiUsername = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "ApiUsername")).PartValue ?? "";
				}
				return _ApiUsername;
			}
			set
			{
				_ApiUsername = "";
			}
		}

		public string ApiPassword
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_ApiPassword))
				{
					_ApiPassword = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "ApiPassword")).PartValue ?? "";
				}
				return _ApiPassword;
			}
			set
			{
				_ApiPassword = "";
			}
		}

		public string ApiBranchId
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_ApiBranchId))
				{
					_ApiBranchId = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "ApiBranchId")).PartValue ?? "";
				}
				return _ApiBranchId;
			}
			set
			{
				_ApiBranchId = "";
			}
		}

		public string FiscalYear
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_FiscalYear))
				{
					_FiscalYear = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "FiscalYear")).PartValue ?? "";
					if (string.IsNullOrWhiteSpace(_FiscalYear))
					{
						_FiscalYear = DateTime.Now.ToString("yyyy", new PersianCulture());
					}
				}
				return _FiscalYear;
			}
			set
			{
				_FiscalYear = "";
			}
		}

		public long FiscalYearId
		{
			get
			{
				return _FiscalYearId;
			}
			set
			{
				_FiscalYearId = 0L;
			}
		}

		public string PrdLinkedField
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_PrdLinkedField))
				{
					_PrdLinkedField = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "PrdLinkedField")).PartValue ?? "";
				}
				return _PrdLinkedField;
			}
			set
			{
				_PrdLinkedField = "";
			}
		}

		public int WrhsSyncTypeId
		{
			get
			{
				if (_WrhsSyncTypeId == 0)
				{
					int.TryParse(Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "WrhsSyncTypeId")).PartValue ?? "0", out _WrhsSyncTypeId);
				}
				return _WrhsSyncTypeId;
			}
			set
			{
				_WrhsSyncTypeId = 0;
			}
		}

		public int WrhsSyncTypeLinkAccSettingId
		{
			get
			{
				if (_WrhsSyncTypeLinkAccSettingId == 0)
				{
					int.TryParse(Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "WrhsSyncTypeId")).LinkAccSettingId.ToString(), out _WrhsSyncTypeLinkAccSettingId);
				}
				return _WrhsSyncTypeLinkAccSettingId;
			}
			set
			{
				_WrhsSyncTypeLinkAccSettingId = 0;
			}
		}

		public int DefCurrencyUnitId
		{
			get
			{
				if (_DefCurrencyUnitId == 0)
				{
					int.TryParse(Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "DefCurrencyUnitId")).PartValue ?? "0", out _DefCurrencyUnitId);
				}
				return _DefCurrencyUnitId;
			}
			set
			{
				_DefCurrencyUnitId = 0;
			}
		}

		public string DefPrjTitle
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_DefPrjTitle))
				{
					_DefPrjTitle = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "DefPrjTitle")).PartValue ?? "";
				}
				return _DefPrjTitle;
			}
			set
			{
				_DefPrjTitle = "";
			}
		}

		public int DefPrjCvnsStatusGroupId
		{
			get
			{
				if (_DefPrjCvnsStatusGroupId == 0)
				{
					int.TryParse(Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "DefPrjCvnsStatusGroupId")).PartValue ?? "0", out _DefPrjCvnsStatusGroupId);
				}
				return _DefPrjCvnsStatusGroupId;
			}
			set
			{
				_DefPrjCvnsStatusGroupId = 0;
			}
		}

		public long LegalCenterGroupId
		{
			get
			{
				if (_LegalCenterGroupId == 0L)
				{
					long.TryParse(Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "LegalCenterGroupId")).PartValue ?? "0", out _LegalCenterGroupId);
				}
				return _LegalCenterGroupId;
			}
			set
			{
				_LegalCenterGroupId = 0L;
			}
		}

		public long LegalParentCenterId
		{
			get
			{
				if (_LegalParentCenterId == 0L)
				{
					long.TryParse(Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "LegalParentCenterId")).PartValue ?? "0", out _LegalParentCenterId);
				}
				return _LegalParentCenterId;
			}
			set
			{
				_LegalParentCenterId = 0L;
			}
		}

		public long RealCenterGroupId
		{
			get
			{
				if (_RealCenterGroupId == 0L)
				{
					long.TryParse(Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "RealCenterGroupId")).PartValue ?? "0", out _RealCenterGroupId);
				}
				return _RealCenterGroupId;
			}
			set
			{
				_RealCenterGroupId = 0L;
			}
		}

		public long RealParentCenterId
		{
			get
			{
				if (_RealParentCenterId == 0L)
				{
					long.TryParse(Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "RealParentCenterId")).PartValue ?? "0", out _RealParentCenterId);
				}
				return _RealParentCenterId;
			}
			set
			{
				_RealParentCenterId = 0L;
			}
		}

		public string CmpAccountRemainMode
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_CmpAccountRemainMode))
				{
					_CmpAccountRemainMode = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "CmpAccountRemainMode")).PartValue ?? "";
				}
				return _CmpAccountRemainMode;
			}
			set
			{
				_CmpAccountRemainMode = "";
			}
		}

		public string CmpAccountRemainCriterion
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_CmpAccountRemainCriterion))
				{
					_CmpAccountRemainCriterion = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "CmpAccountRemainCriterion")).PartValue ?? "";
				}
				return _CmpAccountRemainCriterion;
			}
			set
			{
				_CmpAccountRemainCriterion = "";
			}
		}

		public long CmpDiscountTypeId
		{
			get
			{
				if (_CmpDiscountTypeId == 0L)
				{
					long.TryParse(Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "CmpDiscountTypeId")).PartValue ?? "0", out _CmpDiscountTypeId);
				}
				return _CmpDiscountTypeId;
			}
			set
			{
				_CmpDiscountTypeId = 0L;
			}
		}

		public string PordFieldLinkedToAcc
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_PordFieldLinkedToAcc))
				{
					_PordFieldLinkedToAcc = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "PordFieldLinkedToAcc")).PartValue ?? "";
				}
				return _PordFieldLinkedToAcc;
			}
			set
			{
				_PordFieldLinkedToAcc = "";
			}
		}

		public int LegalTaxSubId
		{
			get
			{
				if (_LegalTaxSubId == 0)
				{
					int.TryParse(Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "LegalTaxSubId")).PartValue ?? "0", out _LegalTaxSubId);
				}
				return _LegalTaxSubId;
			}
			set
			{
				_LegalTaxSubId = 0;
			}
		}

		public int RealTaxSubId
		{
			get
			{
				if (_RealTaxSubId == 0)
				{
					int.TryParse(Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "RealTaxSubId")).PartValue ?? "0", out _RealTaxSubId);
				}
				return _RealTaxSubId;
			}
			set
			{
				_RealTaxSubId = 0;
			}
		}

		public int PordLinkedToAccApiMode
		{
			get
			{
				if (_PordLinkedToAccApiMode == 0)
				{
					int.TryParse(Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "PordLinkedToAccApiMode")).PartValue ?? "0", out _PordLinkedToAccApiMode);
				}
				return _PordLinkedToAccApiMode;
			}
			set
			{
				_PordLinkedToAccApiMode = 0;
			}
		}

		public int OrdLinkedToAccApiMode
		{
			get
			{
				if (_OrdLinkedToAccApiMode == 0)
				{
					int.TryParse(Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "OrdLinkedToAccApiMode")).PartValue ?? "0", out _OrdLinkedToAccApiMode);
				}
				return _OrdLinkedToAccApiMode;
			}
			set
			{
				_OrdLinkedToAccApiMode = 0;
			}
		}

		public void ClearFields()
		{
			ApiAddress = "";
			ApiUsername = "";
			ApiPassword = "";
			ApiBranchId = "";
			FiscalYear = "";
			PrdLinkedField = "";
			WrhsSyncTypeId = 0;
			WrhsSyncTypeLinkAccSettingId = 0;
			DefCurrencyUnitId = 0;
			DefPrjTitle = "";
			DefPrjCvnsStatusGroupId = 0;
			LegalCenterGroupId = 0L;
			LegalParentCenterId = 0L;
			RealCenterGroupId = 0L;
			RealParentCenterId = 0L;
			CmpAccountRemainMode = "";
			CmpAccountRemainCriterion = "";
			CmpDiscountTypeId = 0L;
			FiscalYearId = 0L;
			CmpAccountRemainCriterion = "";
			LegalTaxSubId = 0;
			RealTaxSubId = 0;
			PordLinkedToAccApiMode = 0;
			OrdLinkedToAccApiMode = 0;
		}

		public List<CRMspSelectLinkAccSetting_Result> GetLinkAccSetting(bool? readAgain = false)
		{
			if (!readAgain.GetValueOrDefault() && _LinkAccSetting != null)
			{
				return _LinkAccSetting;
			}
			List<CRMspSelectLinkAccSetting_Result> list = new List<CRMspSelectLinkAccSetting_Result>();
			CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
			try
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				int value = 23;
				int value2 = -1;
				list = Enumerable.ToList<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)cRMLinkSpEntities.CRMspSelectLinkAccSetting(0, "", lCID, result, value, value2, null));
				if (list == null)
				{
					list = new List<CRMspSelectLinkAccSetting_Result>();
				}
			}
			catch (Exception ex)
			{
				Public.InsExceptToElmah(ex);
			}
			cRMLinkSpEntities.Dispose();
			return list;
		}

		public RayvarzSettingDetailsViewModel GetSettingDetails(int settingDetailId = 0, int objId = 0, string objectType = "")
		{
			RayvarzSettingDetailsViewModel rayvarzSettingDetailsViewModel = new RayvarzSettingDetailsViewModel();
			CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
			try
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				int value = 23;
				int value2 = -1;
				if (settingDetailId < 0)
				{
					settingDetailId = 0;
				}
				List<CRMspSelectLinkAccSettingDetails_Result> list = Enumerable.ToList<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)cRMLinkSpEntities.CRMspSelectLinkAccSettingDetails(settingDetailId, objId, objectType, lCID, result, value, value2));
				if (list != null)
				{
					if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "OrdWebDocTypeId")) != null)
					{
						string partValue = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "OrdWebDocTypeId")).PartValue;
						rayvarzSettingDetailsViewModel.OrdWebDocTypeId = ((!string.IsNullOrWhiteSpace(partValue)) ? long.Parse(partValue) : 0);
					}
					if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "OrdSalesTypeId")) != null)
					{
						string partValue2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "OrdSalesTypeId")).PartValue;
						rayvarzSettingDetailsViewModel.OrdSalesTypeId = ((!string.IsNullOrWhiteSpace(partValue2)) ? long.Parse(partValue2) : 0);
					}
					if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "OrdReceiveTypeId")) != null)
					{
						string partValue3 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "OrdReceiveTypeId")).PartValue;
						rayvarzSettingDetailsViewModel.OrdReceiveTypeId = ((!string.IsNullOrWhiteSpace(partValue3)) ? long.Parse(partValue3) : 0);
					}
					if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "OrdUserId")) != null)
					{
						string partValue4 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "OrdUserId")).PartValue;
						rayvarzSettingDetailsViewModel.OrdUserId = ((!string.IsNullOrWhiteSpace(partValue4)) ? partValue4 : "");
					}
					if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "OrdCurrencyId")) != null)
					{
						string partValue5 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "OrdCurrencyId")).PartValue;
						rayvarzSettingDetailsViewModel.OrdCurrencyId = ((!string.IsNullOrWhiteSpace(partValue5)) ? partValue5 : "RLS");
					}
					if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "OrdDiscountTypeId")) != null)
					{
						string partValue6 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "OrdDiscountTypeId")).PartValue;
						rayvarzSettingDetailsViewModel.OrdDiscountTypeId = ((!string.IsNullOrWhiteSpace(partValue6)) ? long.Parse(partValue6) : 0);
					}
					if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "OrdSalesDocTypeId")) != null)
					{
						string partValue7 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "OrdSalesDocTypeId")).PartValue;
						rayvarzSettingDetailsViewModel.OrdSalesDocTypeId = ((!string.IsNullOrWhiteSpace(partValue7)) ? long.Parse(partValue7) : 0);
					}
					if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "OrdReturnReasonId")) != null)
					{
						string partValue8 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "OrdReturnReasonId")).PartValue;
						rayvarzSettingDetailsViewModel.OrdReturnReasonId = ((!string.IsNullOrWhiteSpace(partValue8)) ? long.Parse(partValue8) : 0);
					}
					if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "OrdSalesDocProduceTypeId")) != null)
					{
						string partValue9 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "OrdSalesDocProduceTypeId")).PartValue;
						rayvarzSettingDetailsViewModel.OrdSalesDocProduceTypeId = ((!string.IsNullOrWhiteSpace(partValue9)) ? long.Parse(partValue9) : 0);
					}
					if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "CashTypeId")) != null)
					{
						string partValue10 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "CashTypeId")).PartValue;
						rayvarzSettingDetailsViewModel.OrdPayCashTypeId = ((!string.IsNullOrWhiteSpace(partValue10)) ? long.Parse(partValue10) : 0);
					}
					if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "FundId")) != null)
					{
						string partValue11 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "FundId")).PartValue;
						rayvarzSettingDetailsViewModel.OrdPayFundId = ((!string.IsNullOrWhiteSpace(partValue11)) ? long.Parse(partValue11) : 0);
					}
					if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "SubjectId")) != null)
					{
						string partValue12 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "SubjectId")).PartValue;
						rayvarzSettingDetailsViewModel.OrdPaySubjectId = ((!string.IsNullOrWhiteSpace(partValue12)) ? long.Parse(partValue12) : 0);
					}
					if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "Center1Id")) != null)
					{
						string partValue13 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "Center1Id")).PartValue;
						rayvarzSettingDetailsViewModel.OrdPayCenter1Id = ((!string.IsNullOrWhiteSpace(partValue13)) ? long.Parse(partValue13) : 0);
					}
					if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "Series")) != null)
					{
						string partValue14 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "Series")).PartValue;
						rayvarzSettingDetailsViewModel.OrdPaySeries = ((!string.IsNullOrWhiteSpace(partValue14)) ? long.Parse(partValue14) : 0);
					}
					if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "HeaderDateType")) != null)
					{
						string partValue15 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "HeaderDateType")).PartValue;
						rayvarzSettingDetailsViewModel.OrdPayHeaderDateType = ((!string.IsNullOrWhiteSpace(partValue15)) ? int.Parse(partValue15) : 0);
					}
					if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "DetailDateType")) != null)
					{
						string partValue16 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "DetailDateType")).PartValue;
						rayvarzSettingDetailsViewModel.OrdPayDetailDateType = ((!string.IsNullOrWhiteSpace(partValue16)) ? int.Parse(partValue16) : 0);
					}
					if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "ShopName")) != null)
					{
						string partValue17 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "ShopName")).PartValue;
						rayvarzSettingDetailsViewModel.OrdPayShopName = ((!string.IsNullOrWhiteSpace(partValue17)) ? partValue17 : "");
					}
					if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "PordWebDocTypeId")) != null)
					{
						string partValue18 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "PordWebDocTypeId")).PartValue;
						rayvarzSettingDetailsViewModel.PordWebDocTypeId = ((!string.IsNullOrWhiteSpace(partValue18)) ? long.Parse(partValue18) : 0);
					}
					if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "PordSalesTypeId")) != null)
					{
						string partValue19 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "PordSalesTypeId")).PartValue;
						rayvarzSettingDetailsViewModel.PordSalesTypeId = ((!string.IsNullOrWhiteSpace(partValue19)) ? long.Parse(partValue19) : 0);
					}
					if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "PordReceiveTypeId")) != null)
					{
						string partValue20 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "PordReceiveTypeId")).PartValue;
						rayvarzSettingDetailsViewModel.PordReceiveTypeId = ((!string.IsNullOrWhiteSpace(partValue20)) ? long.Parse(partValue20) : 0);
					}
					if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "PordUserId")) != null)
					{
						string partValue21 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "PordUserId")).PartValue;
						rayvarzSettingDetailsViewModel.PordUserId = ((!string.IsNullOrWhiteSpace(partValue21)) ? partValue21 : "");
					}
					if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "PordCurrencyId")) != null)
					{
						string partValue22 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "PordCurrencyId")).PartValue;
						rayvarzSettingDetailsViewModel.PordCurrencyId = ((!string.IsNullOrWhiteSpace(partValue22)) ? partValue22 : "RLS");
					}
					if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "PordDiscountTypeId")) != null)
					{
						string partValue23 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "PordDiscountTypeId")).PartValue;
						rayvarzSettingDetailsViewModel.PordDiscountTypeId = ((!string.IsNullOrWhiteSpace(partValue23)) ? long.Parse(partValue23) : 0);
					}
					if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "PordSalesDocTypeId")) != null)
					{
						string partValue24 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "PordSalesDocTypeId")).PartValue;
						rayvarzSettingDetailsViewModel.PordSalesDocTypeId = ((!string.IsNullOrWhiteSpace(partValue24)) ? long.Parse(partValue24) : 0);
					}
					if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "PordReturnReasonId")) != null)
					{
						string partValue25 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "PordReturnReasonId")).PartValue;
						rayvarzSettingDetailsViewModel.PordReturnReasonId = ((!string.IsNullOrWhiteSpace(partValue25)) ? long.Parse(partValue25) : 0);
					}
					if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "PordSalesDocProduceTypeId")) != null)
					{
						string partValue26 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "PordSalesDocProduceTypeId")).PartValue;
						rayvarzSettingDetailsViewModel.PordSalesDocProduceTypeId = ((!string.IsNullOrWhiteSpace(partValue26)) ? long.Parse(partValue26) : 0);
					}
					if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "SaleCenterAccCode")) != null)
					{
						string partValue27 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "SaleCenterAccCode")).PartValue;
						rayvarzSettingDetailsViewModel.SaleCenterAccCode = ((!string.IsNullOrWhiteSpace(partValue27)) ? partValue27 : "");
					}
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
			finally
			{
				cRMLinkSpEntities.Dispose();
			}
			return rayvarzSettingDetailsViewModel;
		}

		public RayvarzProvider(bool isUpdateList = false, bool isLogin = true)
		{
			_LinkAccSetting = GetLinkAccSetting(true);
			ClearFields();
			string apiUsername = ApiUsername;
			string apiPassword = ApiPassword;
			try
			{
				client.BaseAddress = new Uri(ApiAddress);
				if (isUpdateList)
				{
					_ListProduct = GetListProduct(isUpdateList);
				}
				if (isLogin)
				{
					apiPassword = GeneratePasswordHash(apiPassword);
					string token = "";
					loginResult = PostAsyncAuthenticate(client, apiUsername, apiPassword, ref token);
					AccessToken = token;
					_FiscalYearId = GetSalesFiscalYearId();
				}
			}
			catch (Exception)
			{
				Public.InsTextToElmah("خطا در ارتباط با سیستم حسابداری، لطفا تنظیمات حسابداری را بررسی کنید.");
			}
		}

		public List<LkProductInfoViewModel> GetListProduct(bool? isUpdateList = false)
		{
			if (!isUpdateList.GetValueOrDefault() && _ListProduct != null && Enumerable.Any<LkProductInfoViewModel>((IEnumerable<LkProductInfoViewModel>)_ListProduct))
			{
				return _ListProduct;
			}
			List<LkProductInfoViewModel> list = new List<LkProductInfoViewModel>();
			int num = 0;
			while (num >= 0)
			{
				string value = GetProductList("", "", num);
				if (!string.IsNullOrWhiteSpace(value))
				{
					if (!string.IsNullOrWhiteSpace(value))
					{
						value = value.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(value))
					{
						List<RayvarzProductResponseViewModel> list2 = JsonConvert.DeserializeObject<List<RayvarzProductResponseViewModel>>(value);
						if (list2 != null)
						{
							if (Enumerable.Any<RayvarzProductResponseViewModel>((IEnumerable<RayvarzProductResponseViewModel>)list2))
							{
								int num2 = 1;
								foreach (RayvarzProductResponseViewModel item in list2)
								{
									if (item != null)
									{
										LkProductInfoViewModel lkProductInfoViewModel = new LkProductInfoViewModel();
										lkProductInfoViewModel.PrdLinkAccPrdIdStr = item.itemDataId ?? "";
										lkProductInfoViewModel.PrdLinkAccPrdCode = item.itemDataId ?? "";
										lkProductInfoViewModel.PrdName = item.name;
										list.Add(lkProductInfoViewModel);
										num2++;
									}
								}
							}
							else
							{
								num = -1;
							}
						}
						else
						{
							num = -1;
						}
					}
					else
					{
						num = -1;
					}
				}
				else
				{
					num = -1;
				}
			}
			return list;
		}

		public string GeneratePasswordHash(string password)
		{
			if (!string.IsNullOrWhiteSpace(password))
			{
				password = BaseInfo.ConverSHA256(password);
			}
			return password;
		}

		private static bool PostAsyncAuthenticate(HttpClient client, string username, string password, ref string token)
		{
			client.DefaultRequestHeaders.Add("ContentType", "application/json");
			client.DefaultRequestHeaders.Add("Accept", "application/json");
			StringContent content = new StringContent("[\"" + username + "\",\"" + password + "\"]", Encoding.UTF8, "application/json");
			HttpResponseMessage result = client.PostAsync("RayvarzApi/Core/Sso/Authenticate", content).Result;
			string text = "";
			text = result.Content.ReadAsStringAsync().Result;
			if (result.IsSuccessStatusCode)
			{
				token = text;
				if (!string.IsNullOrWhiteSpace(token))
				{
					token = token.Replace("\"", "");
				}
				return true;
			}
			return false;
		}

		public List<RayvarzSalesFiscalYearResponseViewModel> GetSalesFiscalYear()
		{
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
			httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
			httpClient.DefaultRequestHeaders.Add("Access_Token", AccessToken);
			httpClient.DefaultRequestHeaders.Add("BranchId", ApiBranchId);
			string requestUri = "RayvarzApi/Sales/SalesFiscalYear/List";
			List<RayvarzSalesFiscalYearResponseViewModel> list = new List<RayvarzSalesFiscalYearResponseViewModel>();
			string text = "";
			if (loginResult)
			{
				StringContent content = new StringContent("", Encoding.UTF8, "application/json");
				HttpResponseMessage result = httpClient.PostAsync(requestUri, content).Result;
				if (result.IsSuccessStatusCode)
				{
					text = result.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(text))
					{
						text = text.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(text))
					{
						text = text.Replace("\"[", "[").Replace("]\"", "]").Replace("\\\"", "\"");
						List<RayvarzSalesFiscalYearResponseViewModel> list2 = JsonConvert.DeserializeObject<List<RayvarzSalesFiscalYearResponseViewModel>>(text);
						if (list2 != null && Enumerable.Any<RayvarzSalesFiscalYearResponseViewModel>((IEnumerable<RayvarzSalesFiscalYearResponseViewModel>)list2))
						{
							list.AddRange(list2);
						}
					}
				}
				if (list == null)
				{
					list = new List<RayvarzSalesFiscalYearResponseViewModel>();
				}
			}
			return list;
		}

		public long GetSalesFiscalYearId()
		{
			long result = 0L;
			List<RayvarzSalesFiscalYearResponseViewModel> salesFiscalYear = GetSalesFiscalYear();
			if (salesFiscalYear != null && Enumerable.Any<RayvarzSalesFiscalYearResponseViewModel>((IEnumerable<RayvarzSalesFiscalYearResponseViewModel>)salesFiscalYear))
			{
				RayvarzSalesFiscalYearResponseViewModel rayvarzSalesFiscalYearResponseViewModel = Enumerable.FirstOrDefault<RayvarzSalesFiscalYearResponseViewModel>((IEnumerable<RayvarzSalesFiscalYearResponseViewModel>)salesFiscalYear, (Func<RayvarzSalesFiscalYearResponseViewModel, bool>)((RayvarzSalesFiscalYearResponseViewModel m) => m.fiscalYear.GetValueOrDefault().ToString() == FiscalYear));
				if (rayvarzSalesFiscalYearResponseViewModel != null)
				{
					result = rayvarzSalesFiscalYearResponseViewModel.salesFiscalYearId.GetValueOrDefault();
				}
			}
			return result;
		}

		public string InsertCenter(RayvarzCustomerCenterInsertViewModel centerInfo, ref long centerId, ref bool isDone)
		{
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
			httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
			string text = "RayvarzApi/ControlPanel/Centers/Insert";
			string text2 = "";
			string text3 = "";
			if (loginResult)
			{
				StringContent content = new StringContent(JsonConvert.SerializeObject(centerInfo), Encoding.UTF8, "application/json");
				text = ApiAddress + text;
				new HttpRequestMessage(HttpMethod.Post, text)
				{
					Headers = 
					{
						{ "access_token", AccessToken },
						{ "BranchId", ApiBranchId }
					}
				};
				text3 = httpClient.PostAsync(text, content).Result.Content.ReadAsStringAsync().Result;
				if (!string.IsNullOrWhiteSpace(text3))
				{
					text3 = text3.ClearHiddenCharacters();
				}
				if (!string.IsNullOrWhiteSpace(text3))
				{
					text3 = text3.Replace("\"[", "[").Replace("]\"", "]").Replace("\\\"", "\"");
					RayvarzCustomerCenterInsertResponseViewModel rayvarzCustomerCenterInsertResponseViewModel = JsonConvert.DeserializeObject<RayvarzCustomerCenterInsertResponseViewModel>(text3);
					if (rayvarzCustomerCenterInsertResponseViewModel != null)
					{
						bool result = false;
						bool.TryParse(rayvarzCustomerCenterInsertResponseViewModel.isSaved.ToString(), out result);
						if (result && rayvarzCustomerCenterInsertResponseViewModel.entities != null && Enumerable.Any<RayvarzCustomerCenterInsertEntitiesResponseViewModel>((IEnumerable<RayvarzCustomerCenterInsertEntitiesResponseViewModel>)rayvarzCustomerCenterInsertResponseViewModel.entities))
						{
							RayvarzCustomerCenterInsertEntitiesResponseViewModel rayvarzCustomerCenterInsertEntitiesResponseViewModel = Enumerable.FirstOrDefault<RayvarzCustomerCenterInsertEntitiesResponseViewModel>((IEnumerable<RayvarzCustomerCenterInsertEntitiesResponseViewModel>)rayvarzCustomerCenterInsertResponseViewModel.entities);
							if (rayvarzCustomerCenterInsertEntitiesResponseViewModel != null)
							{
								centerId = rayvarzCustomerCenterInsertEntitiesResponseViewModel.centerId.GetValueOrDefault();
								if (centerId != 0L)
								{
									isDone = true;
								}
							}
						}
						if (!isDone && rayvarzCustomerCenterInsertResponseViewModel.validationResults != null && Enumerable.Any<RayvarzAPIValidationResultsViewModel>((IEnumerable<RayvarzAPIValidationResultsViewModel>)rayvarzCustomerCenterInsertResponseViewModel.validationResults))
						{
							foreach (RayvarzAPIValidationResultsViewModel validationResult in rayvarzCustomerCenterInsertResponseViewModel.validationResults)
							{
								if (!string.IsNullOrWhiteSpace(validationResult.message))
								{
									if (!string.IsNullOrWhiteSpace(text2))
									{
										text2 += " , ";
									}
									text2 += validationResult.message;
								}
							}
						}
					}
					else
					{
						isDone = false;
						text2 = string.Format(Messages.msgErrorNoResponseReceivedWebservice, Labels.Rayvarz);
					}
				}
				else
				{
					isDone = false;
					text2 = string.Format(Messages.msgErrorNoResponseReceivedWebservice, Labels.Rayvarz);
				}
			}
			else
			{
				isDone = false;
				text2 = Messages.msgErrorReceivingToken;
			}
			return text2;
		}

		public string SendCompany(RayvarzCustomerDefineViewModel cmpInfo, ref bool isDone, ref long customerId)
		{
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
			httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
			string text = "RayvarzApi/Sales/Customer/";
			string text2 = "";
			string text3 = "";
			if (loginResult)
			{
				StringContent content = new StringContent(JsonConvert.SerializeObject(cmpInfo), Encoding.UTF8, "application/json");
				text = ApiAddress + text;
				new HttpRequestMessage(HttpMethod.Post, text)
				{
					Headers = 
					{
						{ "access_token", AccessToken },
						{ "BranchId", ApiBranchId }
					}
				};
				text3 = httpClient.PostAsync(text, content).Result.Content.ReadAsStringAsync().Result;
				if (!string.IsNullOrWhiteSpace(text3))
				{
					text3 = text3.ClearHiddenCharacters();
				}
				if (!string.IsNullOrWhiteSpace(text3))
				{
					text3 = text3.Replace("\"[", "[").Replace("]\"", "]").Replace("\\\"", "\"");
					RayvarzCustomerInsertResponseViewModel rayvarzCustomerInsertResponseViewModel = JsonConvert.DeserializeObject<RayvarzCustomerInsertResponseViewModel>(text3);
					if (rayvarzCustomerInsertResponseViewModel != null)
					{
						bool result = false;
						bool.TryParse(rayvarzCustomerInsertResponseViewModel.isSaved.ToString(), out result);
						if (result && rayvarzCustomerInsertResponseViewModel.entities != null && Enumerable.Any<RayvarzCustomerEntitiesResponseViewModel>((IEnumerable<RayvarzCustomerEntitiesResponseViewModel>)rayvarzCustomerInsertResponseViewModel.entities))
						{
							RayvarzCustomerEntitiesResponseViewModel rayvarzCustomerEntitiesResponseViewModel = Enumerable.FirstOrDefault<RayvarzCustomerEntitiesResponseViewModel>((IEnumerable<RayvarzCustomerEntitiesResponseViewModel>)rayvarzCustomerInsertResponseViewModel.entities);
							if (rayvarzCustomerEntitiesResponseViewModel != null)
							{
								customerId = rayvarzCustomerEntitiesResponseViewModel.customerId.GetValueOrDefault();
								if (customerId != 0L)
								{
									isDone = true;
								}
							}
						}
						if (!isDone && rayvarzCustomerInsertResponseViewModel.validationResults != null && Enumerable.Any<RayvarzAPIValidationResultsViewModel>((IEnumerable<RayvarzAPIValidationResultsViewModel>)rayvarzCustomerInsertResponseViewModel.validationResults))
						{
							foreach (RayvarzAPIValidationResultsViewModel validationResult in rayvarzCustomerInsertResponseViewModel.validationResults)
							{
								if (!string.IsNullOrWhiteSpace(validationResult.message))
								{
									if (!string.IsNullOrWhiteSpace(text2))
									{
										text2 += " , ";
									}
									text2 += validationResult.message;
								}
							}
						}
					}
					else
					{
						isDone = false;
						text2 = string.Format(Messages.msgErrorNoResponseReceivedWebservice, Labels.Rayvarz);
					}
				}
				else
				{
					isDone = false;
					text2 = string.Format(Messages.msgErrorNoResponseReceivedWebservice, Labels.Rayvarz);
				}
			}
			else
			{
				isDone = false;
				text2 = Messages.msgErrorReceivingToken;
			}
			return text2;
		}

		public List<LkCrmCompanyGroupsViewModel> GetCustomerGroup()
		{
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
			httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
			string text = "RayvarzApi/Sales/CustomerGroup/list";
			List<LkCrmCompanyGroupsViewModel> list = new List<LkCrmCompanyGroupsViewModel>();
			string text2 = "";
			if (loginResult)
			{
				text = ApiAddress + text;
				new HttpRequestMessage(HttpMethod.Post, text)
				{
					Headers = 
					{
						{ "access_token", AccessToken },
						{ "BranchId", ApiBranchId }
					}
				};
				StringContent content = new StringContent("", Encoding.UTF8, "application/json");
				HttpResponseMessage result = httpClient.PostAsync(text, content).Result;
				if (result.IsSuccessStatusCode)
				{
					text2 = result.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(text2))
					{
						text2 = text2.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(text2))
					{
						text2 = text2.Replace("\"[", "[").Replace("]\"", "]").Replace("\\\"", "\"");
						List<RayvarzCustomerGroupResponseViewModel> list2 = JsonConvert.DeserializeObject<List<RayvarzCustomerGroupResponseViewModel>>(text2);
						if (list2 != null && Enumerable.Any<RayvarzCustomerGroupResponseViewModel>((IEnumerable<RayvarzCustomerGroupResponseViewModel>)list2))
						{
							foreach (RayvarzCustomerGroupResponseViewModel item2 in list2)
							{
								LkCrmCompanyGroupsViewModel item = new LkCrmCompanyGroupsViewModel
								{
									GroupName = item2.name,
									LinkAccGroupIdStr = item2.customerGroupId.GetValueOrDefault().ToString()
								};
								list.Add(item);
							}
						}
					}
				}
				if (list == null)
				{
					list = new List<LkCrmCompanyGroupsViewModel>();
				}
			}
			return list;
		}

		public List<LkCompanyTypeInfoViewModel> GetSalesType()
		{
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
			httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
			string text = "RayvarzApi/Sales/SalesType/List";
			List<LkCompanyTypeInfoViewModel> list = new List<LkCompanyTypeInfoViewModel>();
			string text2 = "";
			if (loginResult)
			{
				StringContent content = new StringContent("", Encoding.UTF8, "application/json");
				text = ApiAddress + text;
				new HttpRequestMessage(HttpMethod.Post, text)
				{
					Headers = 
					{
						{ "access_token", AccessToken },
						{ "BranchId", ApiBranchId }
					}
				};
				HttpResponseMessage result = httpClient.PostAsync(text, content).Result;
				if (result.IsSuccessStatusCode)
				{
					text2 = result.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(text2))
					{
						text2 = text2.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(text2))
					{
						text2 = text2.Replace("\"[", "[").Replace("]\"", "]").Replace("\\\"", "\"");
						List<RayvarzSaleTypesResponseViewModel> list2 = JsonConvert.DeserializeObject<List<RayvarzSaleTypesResponseViewModel>>(text2);
						if (list2 != null && Enumerable.Any<RayvarzSaleTypesResponseViewModel>((IEnumerable<RayvarzSaleTypesResponseViewModel>)list2))
						{
							foreach (RayvarzSaleTypesResponseViewModel item2 in list2)
							{
								LkCompanyTypeInfoViewModel item = new LkCompanyTypeInfoViewModel
								{
									CompanyTypeName = item2.name,
									LinkAccCmpTypeIdStr = item2.salesTypeId.GetValueOrDefault().ToString()
								};
								list.Add(item);
							}
						}
					}
				}
				if (list == null)
				{
					list = new List<LkCompanyTypeInfoViewModel>();
				}
			}
			return list;
		}

		public decimal GetCustomerAccounts(string cmpId, ref decimal remainDebit, ref decimal remainCredit)
		{
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
			httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
			string text = "RayvarzApi/Sales/customerCredit/CustomerBalance";
			decimal result = default(decimal);
			string text2 = "";
			if (loginResult)
			{
				string text3 = "?maxDocDate=" + DateTime.Now.ToString("yyyy1229", new PersianCulture()) + "&customerId=" + cmpId;
				if (!string.IsNullOrWhiteSpace(CmpAccountRemainMode))
				{
					string[] array = CmpAccountRemainMode.Split(new char[1] { '-' });
					if (array != null && array.Length != 0)
					{
						string[] array2 = array;
						foreach (string text4 in array2)
						{
							if (!string.IsNullOrWhiteSpace(text4))
							{
								text3 = text3 + "&" + text4 + "=TRUE";
							}
						}
					}
				}
				if (string.IsNullOrWhiteSpace(CmpAccountRemainCriterion))
				{
					CmpAccountRemainCriterion = "1";
				}
				int result2 = 0;
				int.TryParse(CmpAccountRemainCriterion, out result2);
				if (result2 == 0)
				{
					result2 = 1;
				}
				text += text3;
				text = ApiAddress + text;
				new HttpRequestMessage(HttpMethod.Get, text)
				{
					Headers = 
					{
						{ "access_token", AccessToken },
						{ "BranchId", ApiBranchId },
						{ "fiscalYearId", FiscalYear }
					}
				};
				HttpResponseMessage result3 = httpClient.GetAsync(text).Result;
				if (result3.IsSuccessStatusCode)
				{
					text2 = result3.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(text2))
					{
						text2 = text2.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(text2))
					{
						List<RayvarzCustomerBalanceResponseViewModel> list = JsonConvert.DeserializeObject<List<RayvarzCustomerBalanceResponseViewModel>>(text2);
						if (list != null && Enumerable.Any<RayvarzCustomerBalanceResponseViewModel>((IEnumerable<RayvarzCustomerBalanceResponseViewModel>)list))
						{
							RayvarzCustomerBalanceResponseViewModel rayvarzCustomerBalanceResponseViewModel = Enumerable.FirstOrDefault<RayvarzCustomerBalanceResponseViewModel>((IEnumerable<RayvarzCustomerBalanceResponseViewModel>)list);
							if (rayvarzCustomerBalanceResponseViewModel != null)
							{
								switch (result2)
								{
								case 1:
									result = rayvarzCustomerBalanceResponseViewModel.totalCreditRemain.GetValueOrDefault();
									break;
								case 2:
									result = rayvarzCustomerBalanceResponseViewModel.debtRemain.GetValueOrDefault() + rayvarzCustomerBalanceResponseViewModel.creditRemain.GetValueOrDefault();
									break;
								case 3:
									result = rayvarzCustomerBalanceResponseViewModel.debtRemain.GetValueOrDefault();
									break;
								case 4:
									result = rayvarzCustomerBalanceResponseViewModel.creditRemain.GetValueOrDefault();
									break;
								}
								remainDebit = rayvarzCustomerBalanceResponseViewModel.debtRemain.GetValueOrDefault();
								remainCredit = rayvarzCustomerBalanceResponseViewModel.creditRemain.GetValueOrDefault();
							}
						}
					}
				}
			}
			return result;
		}

		public decimal GetCustomerBalanceDetails(string cmpId)
		{
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
			httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
			httpClient.DefaultRequestHeaders.Add("Access_Token", AccessToken);
			httpClient.DefaultRequestHeaders.Add("BranchId", ApiBranchId);
			httpClient.DefaultRequestHeaders.Add("fiscalYearId", FiscalYear);
			string text = "RayvarzApi/Sales/CustomerCredit/CustomerBalanceDetails";
			decimal result = default(decimal);
			string text2 = "";
			if (loginResult)
			{
				string text3 = "?maxDocDate=" + DateTime.Now.ToString("yyyy1229", new PersianCulture()) + "&customerId=" + cmpId;
				if (!string.IsNullOrWhiteSpace(CmpAccountRemainMode))
				{
					string[] array = CmpAccountRemainMode.Split(new char[1] { '-' });
					if (array != null && array.Length != 0)
					{
						string[] array2 = array;
						foreach (string text4 in array2)
						{
							if (!string.IsNullOrWhiteSpace(text4))
							{
								text3 = text3 + "&" + text4 + "=TRUE";
							}
						}
					}
				}
				text += text3;
				HttpResponseMessage result2 = httpClient.GetAsync(text).Result;
				if (result2.IsSuccessStatusCode)
				{
					text2 = result2.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(text2))
					{
						text2 = text2.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(text2))
					{
						List<RayvarzCustomerBalanceResponseViewModel> list = JsonConvert.DeserializeObject<List<RayvarzCustomerBalanceResponseViewModel>>(text2);
						if (list != null)
						{
							Enumerable.Any<RayvarzCustomerBalanceResponseViewModel>((IEnumerable<RayvarzCustomerBalanceResponseViewModel>)list);
						}
					}
				}
			}
			return result;
		}

		public string GetCustomerList(string fromDate = "", string toDate = "", int pageNumber = 0)
		{
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
			httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
			string text = "RayvarzApi/Sales/Customer/List";
			string result = "";
			if (loginResult)
			{
				string text2 = "{" + $"\"index\": \"{pageNumber}\"";
				if (!string.IsNullOrWhiteSpace(fromDate) && !string.IsNullOrWhiteSpace(toDate))
				{
					text2 = text2 + ",\"WhereClause\": \"FirstContactDate>=\\\"" + fromDate + "\\\" && FirstContactDate<=  \\\"" + toDate + "\\\" \" ";
				}
				text2 += "}";
				StringContent content = new StringContent(text2, Encoding.UTF8, "application/json");
				text = ApiAddress + text;
				new HttpRequestMessage(HttpMethod.Post, text)
				{
					Headers = 
					{
						{ "access_token", AccessToken },
						{ "BranchId", ApiBranchId }
					}
				};
				HttpResponseMessage result2 = httpClient.PostAsync(text, content).Result;
				if (result2.IsSuccessStatusCode)
				{
					result = result2.Content.ReadAsStringAsync().Result;
				}
			}
			return result;
		}

		public string GetProductList(string fromDate = "", string toDate = "", int pageNumber = 0, string linkAccPrdGroupId = "", string itemCode = "", string itemKind = "")
		{
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
			httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
			string text = "RayvarzApi/Inventory/Product/list";
			string result = "";
			if (loginResult)
			{
				string text2 = "{" + $"\"index\": \"{pageNumber}\"";
				string text3 = "";
				if (!string.IsNullOrWhiteSpace(fromDate))
				{
					if (!string.IsNullOrWhiteSpace(text3))
					{
						text3 += " && ";
					}
					text3 = text3 + " creationDate=\\\"" + fromDate + "\\\" ";
				}
				if (!string.IsNullOrWhiteSpace(linkAccPrdGroupId))
				{
					if (!string.IsNullOrWhiteSpace(text3))
					{
						text3 += " && ";
					}
					text3 = text3 + " itemGroupId=\\\"" + linkAccPrdGroupId + "\\\" ";
				}
				if (!string.IsNullOrWhiteSpace(itemCode))
				{
					if (!string.IsNullOrWhiteSpace(text3))
					{
						text3 += " && ";
					}
					text3 = text3 + " itemDataId=\\\"" + itemCode + "\\\" ";
				}
				if (!string.IsNullOrWhiteSpace(itemKind))
				{
					if (itemKind == "1")
					{
						if (!string.IsNullOrWhiteSpace(text3))
						{
							text3 += " && ";
						}
						text3 += " isproduct=1 ";
					}
					else if (itemKind == "2")
					{
						if (!string.IsNullOrWhiteSpace(text3))
						{
							text3 += " && ";
						}
						text3 += " isservice=1 ";
					}
				}
				if (!string.IsNullOrWhiteSpace(text3))
				{
					text2 = text2 + ",\"whereclause\": \"" + text3 + "\"";
				}
				text2 += "}";
				text = ApiAddress + text;
				new HttpRequestMessage(HttpMethod.Post, text)
				{
					Headers = 
					{
						{ "access_token", AccessToken },
						{ "BranchId", ApiBranchId }
					}
				};
				StringContent content = new StringContent(text2, Encoding.UTF8, "application/json");
				HttpResponseMessage result2 = httpClient.PostAsync(text, content).Result;
				if (result2.IsSuccessStatusCode)
				{
					result = result2.Content.ReadAsStringAsync().Result;
				}
			}
			return result;
		}

		public double GetPrdQuqntity(string prdId, string whId)
		{
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
			httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
			string text = "RayvarzApi/Sales/SalesInventoryInterop/StockList";
			double result = 0.0;
			string text2 = "";
			if (loginResult)
			{
				string text3 = "?itemDataId=" + prdId + "&warehouseId=" + whId;
				text = ApiAddress + text + text3;
				new HttpRequestMessage(HttpMethod.Get, text)
				{
					Headers = 
					{
						{ "access_token", AccessToken },
						{ "BranchId", ApiBranchId }
					}
				};
				new StringContent("", Encoding.UTF8, "application/json");
				HttpResponseMessage result2 = httpClient.GetAsync(text).Result;
				if (result2.IsSuccessStatusCode)
				{
					text2 = result2.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(text2))
					{
						text2 = text2.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(text2))
					{
						List<RayvarzProductRemainingResponseViewModel> list = JsonConvert.DeserializeObject<List<RayvarzProductRemainingResponseViewModel>>(text2);
						if (list != null && Enumerable.Any<RayvarzProductRemainingResponseViewModel>((IEnumerable<RayvarzProductRemainingResponseViewModel>)list))
						{
							RayvarzProductRemainingResponseViewModel rayvarzProductRemainingResponseViewModel = Enumerable.FirstOrDefault<RayvarzProductRemainingResponseViewModel>((IEnumerable<RayvarzProductRemainingResponseViewModel>)list, (Func<RayvarzProductRemainingResponseViewModel, bool>)((RayvarzProductRemainingResponseViewModel m) => (m.warehouseId ?? "") == whId && (m.itemDataId ?? "") == prdId));
							if (rayvarzProductRemainingResponseViewModel != null)
							{
								decimal valueOrDefault = rayvarzProductRemainingResponseViewModel.remainedStockPartialQtySum.GetValueOrDefault();
								decimal num = default(decimal);
								if (rayvarzProductRemainingResponseViewModel.itemData != null)
								{
									num = rayvarzProductRemainingResponseViewModel.itemData.salesBulkToPieceConvertRate.GetValueOrDefault(1m);
								}
								if (num == 0m)
								{
									num = 1m;
								}
								double.TryParse((valueOrDefault / num).ToString(), out result);
							}
						}
					}
				}
			}
			return result;
		}

		public List<LkWSProductUnitInfoViewModel> GetProductUnits()
		{
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
			httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
			string text = "RayvarzApi/Inventory/unit/list";
			List<LkWSProductUnitInfoViewModel> list = new List<LkWSProductUnitInfoViewModel>();
			string text2 = "";
			if (loginResult)
			{
				text = ApiAddress + text;
				new HttpRequestMessage(HttpMethod.Post, text)
				{
					Headers = 
					{
						{ "access_token", AccessToken },
						{ "BranchId", ApiBranchId }
					}
				};
				StringContent content = new StringContent("", Encoding.UTF8, "application/json");
				HttpResponseMessage result = httpClient.PostAsync(text, content).Result;
				if (result.IsSuccessStatusCode)
				{
					text2 = result.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(text2))
					{
						text2 = text2.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(text2))
					{
						List<RayvarzProductUnitResponseViewModel> list2 = JsonConvert.DeserializeObject<List<RayvarzProductUnitResponseViewModel>>(text2);
						if (list2 != null && Enumerable.Any<RayvarzProductUnitResponseViewModel>((IEnumerable<RayvarzProductUnitResponseViewModel>)list2))
						{
							foreach (RayvarzProductUnitResponseViewModel item2 in list2)
							{
								LkWSProductUnitInfoViewModel item = new LkWSProductUnitInfoViewModel
								{
									Unit = (item2.name ?? ""),
									UnitLinkAccUnitIdStr = item2.unitId.GetValueOrDefault().ToString()
								};
								list.Add(item);
							}
						}
					}
				}
				if (list == null)
				{
					list = new List<LkWSProductUnitInfoViewModel>();
				}
			}
			return list;
		}

		public List<LkProductPriceInfoViewModel> GetPrdPrice(string prdId)
		{
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
			httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
			string text = "RayvarzApi/Sales/UnitPriceTemplate/list";
			List<LkProductPriceInfoViewModel> list = new List<LkProductPriceInfoViewModel>();
			string text2 = "";
			if (loginResult)
			{
				string content = string.Concat("{" + "\"WhereClause\": \"itemDataId=\\\"" + prdId + "\\\" \"", "}");
				text = ApiAddress + text;
				new HttpRequestMessage(HttpMethod.Post, text)
				{
					Headers = 
					{
						{ "access_token", AccessToken },
						{ "BranchId", ApiBranchId }
					}
				};
				StringContent content2 = new StringContent(content, Encoding.UTF8, "application/json");
				HttpResponseMessage result = httpClient.PostAsync(text, content2).Result;
				if (result.IsSuccessStatusCode)
				{
					text2 = result.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(text2))
					{
						text2 = text2.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(text2))
					{
						List<RayvarzProductPriceResponseViewModel> list2 = JsonConvert.DeserializeObject<List<RayvarzProductPriceResponseViewModel>>(text2);
						if (list2 != null && Enumerable.Any<RayvarzProductPriceResponseViewModel>((IEnumerable<RayvarzProductPriceResponseViewModel>)list2))
						{
							int num = 1;
							foreach (RayvarzProductPriceResponseViewModel item in list2)
							{
								LkProductPriceInfoViewModel lkProductPriceInfoViewModel = new LkProductPriceInfoViewModel();
								lkProductPriceInfoViewModel.Price = item.totalUnitPrice.GetValueOrDefault();
								lkProductPriceInfoViewModel.PrdLinkAccPrdCode = prdId;
								lkProductPriceInfoViewModel.PrdLinkAccPrdIdStr = prdId;
								lkProductPriceInfoViewModel.PrdId = 0;
								if (!string.IsNullOrWhiteSpace(item.fromDate))
								{
									item.fromDate = item.fromDate.Replace("/", "").Replace("-", "").Replace("\\", "")
										.Replace(" ", "")
										.Replace("_", "");
									DateTime dateTime = DateTime.Parse(PersianDate.GetFormatetdDate(item.fromDate) + " 00:00:00");
									DateTime dateTime2 = dateTime;
									lkProductPriceInfoViewModel.DocDate = dateTime2.ToString("yyyyMMdd", new PersianCulture());
									lkProductPriceInfoViewModel.DocDateTime = dateTime;
								}
								list.Add(lkProductPriceInfoViewModel);
								num++;
							}
						}
					}
				}
			}
			return list;
		}

		public string GetWarehouseList(int pageNumber = 0)
		{
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
			httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
			string text = "RayvarzApi/Sales/SalesWarehouse/List";
			string result = "";
			if (loginResult)
			{
				string content = "{" + $"\"index\": \"{pageNumber}\"" + ",\"WhereClause\": \"isproduct=1\"}";
				text = ApiAddress + text;
				new HttpRequestMessage(HttpMethod.Post, text)
				{
					Headers = 
					{
						{ "access_token", AccessToken },
						{ "BranchId", ApiBranchId }
					}
				};
				StringContent content2 = new StringContent(content, Encoding.UTF8, "application/json");
				HttpResponseMessage result2 = httpClient.PostAsync(text, content2).Result;
				if (result2.IsSuccessStatusCode)
				{
					result = result2.Content.ReadAsStringAsync().Result;
				}
			}
			return result;
		}

		public List<RayvarzWarehouseResponseViewModel> GetAllWarehouseList()
		{
			List<RayvarzWarehouseResponseViewModel> list = new List<RayvarzWarehouseResponseViewModel>();
			if (loginResult)
			{
				int num = 0;
				while (num >= 0)
				{
					string value = GetWarehouseList(num);
					if (!string.IsNullOrWhiteSpace(value))
					{
						value = value.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(value))
					{
						List<RayvarzWarehouseResponseViewModel> list2 = JsonConvert.DeserializeObject<List<RayvarzWarehouseResponseViewModel>>(value);
						if (list2 != null)
						{
							if (Enumerable.Any<RayvarzWarehouseResponseViewModel>((IEnumerable<RayvarzWarehouseResponseViewModel>)list2))
							{
								list.AddRange(list2);
								num++;
							}
							else
							{
								num = -1;
							}
						}
						else
						{
							num = -1;
						}
					}
					else
					{
						num = -1;
					}
				}
			}
			return list;
		}

		public string GetSalesIssueList(string fromDate = "", string toDate = "", int pageNumber = 0, int oprType = 1, int linkedToAccApiMode = 0)
		{
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
			httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
			string text = "RayvarzApi/Sales/Issue/list/";
			string result = "";
			if (loginResult)
			{
				if (oprType == 2)
				{
					text = "RayvarzApi/Sales/ReturnFromSales/List";
				}
				string text2 = "";
				if (linkedToAccApiMode == 2)
				{
					text = "RayvarzApi/Sales/Proforma/list";
					text2 = ",\"IncludeDetails\": true";
				}
				string text3 = "{" + $"\"index\": \"{pageNumber}\"";
				text3 += text2;
				if (!string.IsNullOrWhiteSpace(fromDate) && !string.IsNullOrWhiteSpace(toDate))
				{
					text3 = text3 + ",\"WhereClause\": \"DocDate>=\\\"" + fromDate + "\\\" && DocDate<=  \\\"" + toDate + "\\\" \" ";
				}
				text3 += "}";
				StringContent content = new StringContent(text3, Encoding.UTF8, "application/json");
				text = ApiAddress + text;
				new HttpRequestMessage(HttpMethod.Post, text)
				{
					Headers = 
					{
						{ "access_token", AccessToken },
						{ "BranchId", ApiBranchId }
					}
				};
				HttpResponseMessage result2 = httpClient.PostAsync(text, content).Result;
				if (result2.IsSuccessStatusCode)
				{
					result = result2.Content.ReadAsStringAsync().Result;
				}
			}
			return result;
		}

		public RayvarzSalesIssueListResponseViewModel GetSalesIssue(long linkAccId, int oprType = 1, int linkedToAccApiMode = 0)
		{
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
			httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
			RayvarzSalesIssueListResponseViewModel result = new RayvarzSalesIssueListResponseViewModel();
			string text = "RayvarzApi/Sales/Issue/";
			string text2 = "";
			if (loginResult)
			{
				if (oprType == 2)
				{
					text = "RayvarzApi/Sales/ReturnFromSales/";
				}
				if (linkedToAccApiMode == 2)
				{
					text = "RayvarzApi/Sales/proforma/";
				}
				new StringContent("", Encoding.UTF8, "application/json");
				text = ApiAddress + text + linkAccId;
				new HttpRequestMessage(HttpMethod.Get, text)
				{
					Headers = 
					{
						{ "access_token", AccessToken },
						{ "BranchId", ApiBranchId }
					}
				};
				HttpResponseMessage result2 = httpClient.GetAsync(text).Result;
				if (result2.IsSuccessStatusCode)
				{
					text2 = result2.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(text2))
					{
						text2 = text2.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(text2))
					{
						text2 = text2.Replace("\"[", "[").Replace("]\"", "]").Replace("\\\"", "\"");
						result = JsonConvert.DeserializeObject<RayvarzSalesIssueListResponseViewModel>(text2);
					}
				}
			}
			return result;
		}

		public string SendSalesIssue(RayvarzSalesIssueDefineViewModel ordInfo, int oprType, ref long linkAccId, ref RayvarzSalesIssueDefineResponseViewModel resultSendOrd, ref bool isDone, int linkedToAccApiMode = 0, RayvarzProformaDefineViewModel proformaInfo = null)
		{
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
			httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
			string text = "RayvarzApi/Sales/Issue";
			string text2 = "";
			string text3 = "";
			if (loginResult)
			{
				if (oprType == 2)
				{
					text = "RayvarzApi/Sales/ReturnFromSales";
				}
				string content = JsonConvert.SerializeObject(ordInfo);
				if (linkedToAccApiMode == 2)
				{
					text = "RayvarzApi/Sales/Proforma";
					content = JsonConvert.SerializeObject(proformaInfo);
				}
				StringContent content2 = new StringContent(content, Encoding.UTF8, "application/json");
				text = ApiAddress + text;
				new HttpRequestMessage(HttpMethod.Post, text)
				{
					Headers = 
					{
						{ "access_token", AccessToken },
						{ "BranchId", ApiBranchId },
						{ "FiscalYearId", FiscalYear }
					}
				};
				text3 = httpClient.PostAsync(text, content2).Result.Content.ReadAsStringAsync().Result;
				if (!string.IsNullOrWhiteSpace(text3))
				{
					text3 = text3.ClearHiddenCharacters();
				}
				if (!string.IsNullOrWhiteSpace(text3))
				{
					text3 = text3.Replace("\"[", "[").Replace("]\"", "]").Replace("\\\"", "\"");
					if (text3.IndexOf("isSaved", StringComparison.Ordinal) >= 0)
					{
						RayvarzSalesIssueDefineResponseViewModel rayvarzSalesIssueDefineResponseViewModel = JsonConvert.DeserializeObject<RayvarzSalesIssueDefineResponseViewModel>(text3);
						if (rayvarzSalesIssueDefineResponseViewModel != null)
						{
							bool result = false;
							bool.TryParse(rayvarzSalesIssueDefineResponseViewModel.isSaved.ToString(), out result);
							if (result && rayvarzSalesIssueDefineResponseViewModel.entities != null && Enumerable.Any<RayvarzSalesIssueEntitiesResponseViewModel>((IEnumerable<RayvarzSalesIssueEntitiesResponseViewModel>)rayvarzSalesIssueDefineResponseViewModel.entities))
							{
								RayvarzSalesIssueEntitiesResponseViewModel rayvarzSalesIssueEntitiesResponseViewModel = Enumerable.FirstOrDefault<RayvarzSalesIssueEntitiesResponseViewModel>((IEnumerable<RayvarzSalesIssueEntitiesResponseViewModel>)rayvarzSalesIssueDefineResponseViewModel.entities);
								if (rayvarzSalesIssueEntitiesResponseViewModel != null)
								{
									linkAccId = rayvarzSalesIssueEntitiesResponseViewModel.salesJournalId.GetValueOrDefault();
									if (linkAccId != 0L)
									{
										isDone = true;
										resultSendOrd = rayvarzSalesIssueDefineResponseViewModel;
									}
								}
							}
							if (!isDone && rayvarzSalesIssueDefineResponseViewModel.validationResults != null && Enumerable.Any<RayvarzAPIValidationResultsViewModel>((IEnumerable<RayvarzAPIValidationResultsViewModel>)rayvarzSalesIssueDefineResponseViewModel.validationResults))
							{
								foreach (RayvarzAPIValidationResultsViewModel validationResult in rayvarzSalesIssueDefineResponseViewModel.validationResults)
								{
									if (!string.IsNullOrWhiteSpace(validationResult.message))
									{
										if (!string.IsNullOrWhiteSpace(text2))
										{
											text2 += " , ";
										}
										text2 += validationResult.message;
									}
								}
							}
						}
						else
						{
							isDone = false;
							text2 = string.Format(Messages.msgErrorNoResponseReceivedWebservice, Labels.Rayvarz);
						}
					}
					else
					{
						text2 = text3;
					}
				}
				else
				{
					isDone = false;
					text2 = string.Format(Messages.msgErrorNoResponseReceivedWebservice, Labels.Rayvarz);
				}
			}
			else
			{
				isDone = false;
				text2 = Messages.msgErrorReceivingToken;
			}
			return text2;
		}

		public List<SelectListItem> GetSalesTypeList()
		{
			_ = client;
			List<SelectListItem> list = new List<SelectListItem>();
			if (loginResult)
			{
				List<LkCompanyTypeInfoViewModel> salesType = GetSalesType();
				if (salesType != null && Enumerable.Any<LkCompanyTypeInfoViewModel>((IEnumerable<LkCompanyTypeInfoViewModel>)salesType))
				{
					foreach (LkCompanyTypeInfoViewModel item2 in salesType)
					{
						SelectListItem item = new SelectListItem
						{
							Text = (item2.CompanyTypeName ?? ""),
							Value = item2.LinkAccCmpTypeIdStr
						};
						list.Add(item);
					}
				}
				if (list == null)
				{
					list = new List<SelectListItem>();
				}
			}
			return list;
		}

		public string DeleteSales(long linkAccId, ref bool isDone, int linkedToAccApiMode = 0)
		{
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
			httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
			string text = "RayvarzApi/Sales/Issue/";
			string text2 = "";
			string text3 = "";
			if (loginResult)
			{
				if (linkedToAccApiMode == 2)
				{
					text = "RayvarzApi/Sales/Proforma/";
				}
				text = ApiAddress + text + linkAccId;
				new HttpRequestMessage(HttpMethod.Post, text).Headers.Add("access_token", AccessToken);
				text3 = httpClient.DeleteAsync(text).Result.Content.ReadAsStringAsync().Result;
				if (!string.IsNullOrWhiteSpace(text3))
				{
					text3 = text3.ClearHiddenCharacters();
				}
				if (!string.IsNullOrWhiteSpace(text3))
				{
					text3 = text3.Replace("\"[", "[").Replace("]\"", "]").Replace("\\\"", "\"");
					if (text3.IndexOf("isSaved", StringComparison.Ordinal) >= 0)
					{
						RayvarzSalesIssueDeleteResponseViewModel rayvarzSalesIssueDeleteResponseViewModel = JsonConvert.DeserializeObject<RayvarzSalesIssueDeleteResponseViewModel>(text3);
						if (rayvarzSalesIssueDeleteResponseViewModel != null)
						{
							bool result = false;
							bool.TryParse(rayvarzSalesIssueDeleteResponseViewModel.isSaved.ToString(), out result);
							if (result)
							{
								isDone = true;
							}
							if (!isDone && rayvarzSalesIssueDeleteResponseViewModel.validationResults != null && Enumerable.Any<RayvarzAPIValidationResultsViewModel>((IEnumerable<RayvarzAPIValidationResultsViewModel>)rayvarzSalesIssueDeleteResponseViewModel.validationResults))
							{
								rayvarzSalesIssueDeleteResponseViewModel.validationResults = Enumerable.ToList<RayvarzAPIValidationResultsViewModel>(rayvarzSalesIssueDeleteResponseViewModel.validationResults.DistinctBy((RayvarzAPIValidationResultsViewModel m) => m.message ?? ""));
								foreach (RayvarzAPIValidationResultsViewModel validationResult in rayvarzSalesIssueDeleteResponseViewModel.validationResults)
								{
									if (!string.IsNullOrWhiteSpace(validationResult.message))
									{
										if (!string.IsNullOrWhiteSpace(text2))
										{
											text2 += " , ";
										}
										text2 += validationResult.message;
									}
								}
							}
						}
						else
						{
							isDone = false;
							text2 = string.Format(Messages.msgErrorNoResponseReceivedWebservice, Labels.Rayvarz);
						}
					}
					else
					{
						text2 = text3;
					}
				}
				else
				{
					isDone = false;
					text2 = string.Format(Messages.msgErrorNoResponseReceivedWebservice, Labels.Rayvarz);
				}
			}
			else
			{
				isDone = false;
				text2 = Messages.msgErrorReceivingToken;
			}
			return text2;
		}

		public string SendPayment(RayvarzJournalMainDefineViewModel pay, ref long linkAccHeaderNumber, ref long linkAccVoucherNumber, ref bool isDone)
		{
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
			httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
			string text = "rayvarzapi/Cash/SystemVoucher/SaveList";
			string text2 = "";
			string text3 = "";
			if (loginResult)
			{
				StringContent content = new StringContent(JsonConvert.SerializeObject(pay), Encoding.UTF8, "application/json");
				text = ApiAddress + text;
				new HttpRequestMessage(HttpMethod.Post, text)
				{
					Headers = 
					{
						{ "access_token", AccessToken },
						{ "BranchId", ApiBranchId },
						{ "FiscalYearId", FiscalYear }
					}
				};
				text3 = httpClient.PostAsync(text, content).Result.Content.ReadAsStringAsync().Result;
				if (!string.IsNullOrWhiteSpace(text3))
				{
					text3 = text3.ClearHiddenCharacters();
				}
				if (!string.IsNullOrWhiteSpace(text3))
				{
					text3 = text3.Replace("\"[", "[").Replace("]\"", "]").Replace("\\\"", "\"");
					if (text3.IndexOf("isSaved", StringComparison.Ordinal) >= 0)
					{
						RayvarzJournalDefineResponseViewModel rayvarzJournalDefineResponseViewModel = JsonConvert.DeserializeObject<RayvarzJournalDefineResponseViewModel>(text3);
						if (rayvarzJournalDefineResponseViewModel != null)
						{
							bool result = false;
							bool.TryParse(rayvarzJournalDefineResponseViewModel.isSaved.ToString(), out result);
							if (result && rayvarzJournalDefineResponseViewModel.entities != null && Enumerable.Any<RayvarzJournalEntitiesResponseViewModel>((IEnumerable<RayvarzJournalEntitiesResponseViewModel>)rayvarzJournalDefineResponseViewModel.entities))
							{
								RayvarzJournalEntitiesResponseViewModel rayvarzJournalEntitiesResponseViewModel = Enumerable.FirstOrDefault<RayvarzJournalEntitiesResponseViewModel>((IEnumerable<RayvarzJournalEntitiesResponseViewModel>)rayvarzJournalDefineResponseViewModel.entities, (Func<RayvarzJournalEntitiesResponseViewModel, bool>)((RayvarzJournalEntitiesResponseViewModel m) => m.systemVoucherItemNo.GetValueOrDefault() != 0));
								if (rayvarzJournalEntitiesResponseViewModel != null)
								{
									linkAccVoucherNumber = rayvarzJournalEntitiesResponseViewModel.systemVoucherItemNo.GetValueOrDefault();
								}
								RayvarzJournalEntitiesResponseViewModel rayvarzJournalEntitiesResponseViewModel2 = Enumerable.FirstOrDefault<RayvarzJournalEntitiesResponseViewModel>((IEnumerable<RayvarzJournalEntitiesResponseViewModel>)rayvarzJournalDefineResponseViewModel.entities, (Func<RayvarzJournalEntitiesResponseViewModel, bool>)((RayvarzJournalEntitiesResponseViewModel m) => m.journalNo.GetValueOrDefault() != 0));
								if (rayvarzJournalEntitiesResponseViewModel2 != null)
								{
									linkAccHeaderNumber = rayvarzJournalEntitiesResponseViewModel2.journalNo.GetValueOrDefault();
								}
								if (linkAccVoucherNumber != 0L || linkAccHeaderNumber != 0L)
								{
									isDone = true;
								}
							}
							if (!isDone && rayvarzJournalDefineResponseViewModel.validationResults != null && Enumerable.Any<RayvarzAPIValidationResultsViewModel>((IEnumerable<RayvarzAPIValidationResultsViewModel>)rayvarzJournalDefineResponseViewModel.validationResults))
							{
								foreach (RayvarzAPIValidationResultsViewModel validationResult in rayvarzJournalDefineResponseViewModel.validationResults)
								{
									if (!string.IsNullOrWhiteSpace(validationResult.message))
									{
										if (!string.IsNullOrWhiteSpace(text2))
										{
											text2 += " , ";
										}
										text2 += validationResult.message;
									}
								}
							}
						}
						else
						{
							isDone = false;
							text2 = string.Format(Messages.msgErrorNoResponseReceivedWebservice, Labels.Rayvarz);
						}
					}
					else
					{
						text2 = text3;
					}
				}
				else
				{
					isDone = false;
					text2 = string.Format(Messages.msgErrorNoResponseReceivedWebservice, Labels.Rayvarz);
				}
			}
			else
			{
				isDone = false;
				text2 = Messages.msgErrorReceivingToken;
			}
			return text2;
		}

		public string DeletePayment(long branchId, long fiscalYearId, long linkAccVoucherNumber, ref bool isDone)
		{
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
			httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
			string text = "RayvarzApi/Cash/SystemVoucher/Delete";
			string text2 = "";
			string text3 = "";
			if (loginResult)
			{
				StringContent content = new StringContent($"{{\"BranchId\":{branchId},\"FiscalYearId\":{fiscalYearId},\"DocNo\":{linkAccVoucherNumber},\"RaySystemId\":\"cash\",\"SystemVoucheritemTypeId\":0}}", Encoding.UTF8, "application/json");
				text = ApiAddress + text;
				new HttpRequestMessage(HttpMethod.Post, text).Headers.Add("access_token", AccessToken);
				text3 = httpClient.PostAsync(text, content).Result.Content.ReadAsStringAsync().Result;
				if (!string.IsNullOrWhiteSpace(text3))
				{
					text3 = text3.ClearHiddenCharacters();
				}
				if (!string.IsNullOrWhiteSpace(text3))
				{
					text3 = text3.Replace("\"[", "[").Replace("]\"", "]").Replace("\\\"", "\"");
					if (text3.IndexOf("isSaved", StringComparison.Ordinal) >= 0)
					{
						RayvarzJournalDeleteResponseViewModel rayvarzJournalDeleteResponseViewModel = JsonConvert.DeserializeObject<RayvarzJournalDeleteResponseViewModel>(text3);
						if (rayvarzJournalDeleteResponseViewModel != null)
						{
							bool result = false;
							bool.TryParse(rayvarzJournalDeleteResponseViewModel.isSaved.ToString(), out result);
							if (result)
							{
								isDone = true;
							}
							if (!isDone && rayvarzJournalDeleteResponseViewModel.validationResults != null && Enumerable.Any<RayvarzAPIValidationResultsViewModel>((IEnumerable<RayvarzAPIValidationResultsViewModel>)rayvarzJournalDeleteResponseViewModel.validationResults))
							{
								foreach (RayvarzAPIValidationResultsViewModel validationResult in rayvarzJournalDeleteResponseViewModel.validationResults)
								{
									if (!string.IsNullOrWhiteSpace(validationResult.message))
									{
										if (!string.IsNullOrWhiteSpace(text2))
										{
											text2 += " , ";
										}
										text2 += validationResult.message;
									}
								}
							}
						}
						else
						{
							isDone = false;
							text2 = string.Format(Messages.msgErrorNoResponseReceivedWebservice, Labels.Rayvarz);
						}
					}
					else
					{
						text2 = text3;
					}
				}
				else
				{
					isDone = false;
					text2 = string.Format(Messages.msgErrorNoResponseReceivedWebservice, Labels.Rayvarz);
				}
			}
			else
			{
				isDone = false;
				text2 = Messages.msgErrorReceivingToken;
			}
			return text2;
		}
	}

	public class ArianSystemProvider
	{
		public class ArianSystemSettingDetailsViewModel
		{
			public long PersonTypeAcc { get; set; }
		}

		public HttpClient client = new HttpClient();

		private string _AccessToken = "";

		public const string _KeyName_Address = "ApiAddress";

		public const string _KeyName_Username = "ApiUsername";

		public const string _KeyName_Password = "ApiPassword";

		public const string _KeyName_Place = "ApiPlace";

		public const string _KeyName_PersonTypeAcc = "PersonTypeAcc";

		public const string _KeyName_PrdLinkedField = "PrdLinkedField";

		public const string _KeyName_WrhsSyncTypeId = "WrhsSyncTypeId";

		private static string _ApiAddress = "";

		private static string _ApiUsername = "";

		private static string _ApiPassword = "";

		private static string _ApiPlace = "";

		private static string _PrdLinkedField = "";

		private static int _WrhsSyncTypeId = 0;

		private static int _WrhsSyncTypeLinkAccSettingId = 0;

		private static List<CRMspSelectLinkAccSetting_Result> _LinkAccSetting = null;

		public bool loginResult { get; set; }

		public string AccessToken
		{
			get
			{
				return _AccessToken;
			}
			set
			{
				_AccessToken = value;
			}
		}

		public string ApiAddress
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_ApiAddress))
				{
					_ApiAddress = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "ApiAddress")).PartValue ?? "";
				}
				if (!string.IsNullOrWhiteSpace(_ApiAddress) && !_ApiAddress.EndsWith("/"))
				{
					_ApiAddress += "/";
				}
				return _ApiAddress;
			}
			set
			{
				_ApiAddress = "";
			}
		}

		public string ApiUsername
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_ApiUsername))
				{
					_ApiUsername = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "ApiUsername")).PartValue ?? "";
				}
				return _ApiUsername;
			}
			set
			{
				_ApiUsername = "";
			}
		}

		public string ApiPassword
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_ApiPassword))
				{
					_ApiPassword = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "ApiPassword")).PartValue ?? "";
				}
				return _ApiPassword;
			}
			set
			{
				_ApiPassword = "";
			}
		}

		public string ApiPlace
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_ApiPlace))
				{
					_ApiPlace = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "ApiPlace")).PartValue ?? "";
				}
				return _ApiPlace;
			}
			set
			{
				_ApiPlace = "";
			}
		}

		public string PrdLinkedField
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_PrdLinkedField))
				{
					_PrdLinkedField = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "PrdLinkedField")).PartValue ?? "";
				}
				return _PrdLinkedField;
			}
			set
			{
				_PrdLinkedField = "";
			}
		}

		public int WrhsSyncTypeId
		{
			get
			{
				if (_WrhsSyncTypeId == 0)
				{
					int.TryParse(Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "WrhsSyncTypeId")).PartValue ?? "0", out _WrhsSyncTypeId);
				}
				return _WrhsSyncTypeId;
			}
			set
			{
				_WrhsSyncTypeId = 0;
			}
		}

		public int WrhsSyncTypeLinkAccSettingId
		{
			get
			{
				if (_WrhsSyncTypeLinkAccSettingId == 0)
				{
					int.TryParse(Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "WrhsSyncTypeId")).LinkAccSettingId.ToString(), out _WrhsSyncTypeLinkAccSettingId);
				}
				return _WrhsSyncTypeLinkAccSettingId;
			}
			set
			{
				_WrhsSyncTypeLinkAccSettingId = 0;
			}
		}

		public void ClearFields()
		{
			ApiAddress = "";
			ApiUsername = "";
			ApiPassword = "";
			ApiPlace = "";
			PrdLinkedField = "";
			WrhsSyncTypeId = 0;
			WrhsSyncTypeLinkAccSettingId = 0;
		}

		public List<CRMspSelectLinkAccSetting_Result> GetLinkAccSetting(bool? readAgain = false)
		{
			if (!readAgain.GetValueOrDefault() && _LinkAccSetting != null)
			{
				return _LinkAccSetting;
			}
			List<CRMspSelectLinkAccSetting_Result> list = new List<CRMspSelectLinkAccSetting_Result>();
			CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
			try
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				int value = 25;
				int value2 = -1;
				list = Enumerable.ToList<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)cRMLinkSpEntities.CRMspSelectLinkAccSetting(0, "", lCID, result, value, value2, null));
				if (list == null)
				{
					list = new List<CRMspSelectLinkAccSetting_Result>();
				}
			}
			catch (Exception ex)
			{
				Public.InsExceptToElmah(ex);
			}
			cRMLinkSpEntities.Dispose();
			return list;
		}

		public ArianSystemSettingDetailsViewModel GetSettingDetails(int settingDetailId = 0, int objId = 0, string objectType = "")
		{
			ArianSystemSettingDetailsViewModel arianSystemSettingDetailsViewModel = new ArianSystemSettingDetailsViewModel();
			CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
			try
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				int value = 25;
				int value2 = -1;
				if (settingDetailId < 0)
				{
					settingDetailId = 0;
				}
				List<CRMspSelectLinkAccSettingDetails_Result> list = Enumerable.ToList<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)cRMLinkSpEntities.CRMspSelectLinkAccSettingDetails(settingDetailId, objId, objectType, lCID, result, value, value2));
				if (list != null && Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "PersonTypeAcc")) != null)
				{
					string partValue = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "PersonTypeAcc")).PartValue;
					arianSystemSettingDetailsViewModel.PersonTypeAcc = ((!string.IsNullOrWhiteSpace(partValue)) ? long.Parse(partValue) : 0);
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
			finally
			{
				cRMLinkSpEntities.Dispose();
			}
			return arianSystemSettingDetailsViewModel;
		}

		public ArianSystemProvider(bool isUpdateList = false, bool isLogin = true)
		{
			_LinkAccSetting = GetLinkAccSetting(true);
			ClearFields();
			string apiUsername = ApiUsername;
			string apiPassword = ApiPassword;
			string apiPlace = ApiPlace;
			try
			{
				client.BaseAddress = new Uri(ApiAddress);
				if (isLogin)
				{
					string token = "";
					loginResult = PostAsyncAuthenticate(client, apiUsername, apiPassword, apiPlace, ref token);
					AccessToken = token;
				}
			}
			catch (Exception)
			{
				Public.InsTextToElmah("خطا در ارتباط با سیستم حسابداری، لطفا تنظیمات حسابداری را بررسی کنید.");
			}
		}

		private static bool PostAsyncAuthenticate(HttpClient client, string username, string password, string place, ref string token)
		{
			client.DefaultRequestHeaders.Add("ContentType", "application/json");
			string text = "api/Login";
			text = _ApiAddress + text;
			StringContent content = new StringContent(JsonConvert.SerializeObject(new ArianSystemLoginViewModel
			{
				User = username,
				Pass = password,
				Place = place
			}), Encoding.UTF8, "application/json");
			HttpResponseMessage result = client.PostAsync(text, content).Result;
			string text2 = "";
			text2 = result.Content.ReadAsStringAsync().Result;
			if (result.IsSuccessStatusCode)
			{
				if (!string.IsNullOrWhiteSpace(text2))
				{
					text2 = text2.ClearHiddenCharacters();
				}
				if (!string.IsNullOrWhiteSpace(text2))
				{
					ArianSystemLoginResponseViewModel arianSystemLoginResponseViewModel = JsonConvert.DeserializeObject<ArianSystemLoginResponseViewModel>(text2);
					if (arianSystemLoginResponseViewModel != null)
					{
						token = arianSystemLoginResponseViewModel.Token ?? "";
						if (!string.IsNullOrWhiteSpace(token))
						{
							token = token.Replace("\"", "");
							return true;
						}
					}
				}
			}
			return false;
		}

		public List<ArianSystemLocationListResponseViewModel> GetLocationList(long parentId = 0L)
		{
			List<ArianSystemLocationListResponseViewModel> list = new List<ArianSystemLocationListResponseViewModel>();
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Remove("autt");
			httpClient.DefaultRequestHeaders.TryAddWithoutValidation("autt", AccessToken);
			string text = "api/select";
			string text2 = "";
			if (loginResult)
			{
				int num = int.MaxValue;
				ArianSystemSelectApiRequestViewModel arianSystemSelectApiRequestViewModel = new ArianSystemSelectApiRequestViewModel();
				arianSystemSelectApiRequestViewModel.id = "Location";
				arianSystemSelectApiRequestViewModel.Params = new List<ArianSystemSelectApiRequestParamViewModel>();
				arianSystemSelectApiRequestViewModel.Params.Add(new ArianSystemSelectApiRequestParamViewModel
				{
					Name = "RowsCount",
					Value = num.ToString()
				});
				arianSystemSelectApiRequestViewModel.Params.Add(new ArianSystemSelectApiRequestParamViewModel
				{
					Name = "IsStruct",
					Value = "1"
				});
				arianSystemSelectApiRequestViewModel.Params.Add(new ArianSystemSelectApiRequestParamViewModel
				{
					Type = "__Query__",
					Name = "FatherLocationID",
					FilterType = 0,
					Value = parentId.ToString()
				});
				StringContent content = new StringContent(JsonConvert.SerializeObject(arianSystemSelectApiRequestViewModel).Replace("\"Type\":null,", "").Replace("\"Type\":null", "")
					.Replace("\"FilterType\":null,", "")
					.Replace("\"FilterType\":null", "")
					.Replace("\"Array_Value\":null,", "")
					.Replace("\"Array_Value\":null", ""), Encoding.UTF8, "application/json");
				text = ApiAddress + text;
				new HttpRequestMessage(HttpMethod.Post, text);
				HttpResponseMessage result = httpClient.PostAsync(text, content).Result;
				if (result.IsSuccessStatusCode)
				{
					text2 = result.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(text2))
					{
						text2 = text2.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(text2))
					{
						ArianSystemSelectApiResponseViewModel arianSystemSelectApiResponseViewModel = JsonConvert.DeserializeObject<ArianSystemSelectApiResponseViewModel>(text2);
						if (arianSystemSelectApiResponseViewModel != null && arianSystemSelectApiResponseViewModel.rows != null && Enumerable.Any<List<object>>((IEnumerable<List<object>>)arianSystemSelectApiResponseViewModel.rows))
						{
							list = Enumerable.ToList<ArianSystemLocationListResponseViewModel>(Enumerable.Select<List<object>, ArianSystemLocationListResponseViewModel>((IEnumerable<List<object>>)arianSystemSelectApiResponseViewModel.rows, (Func<List<object>, ArianSystemLocationListResponseViewModel>)((List<object> x) => new ArianSystemLocationListResponseViewModel
							{
								LocationID = ((x.Count >= 1) ? Convert.ToInt32((!string.IsNullOrWhiteSpace(x[0]?.ToString())) ? x[0] : "0") : 0),
								FatherLocationID = ((x.Count >= 2) ? Convert.ToInt32((!string.IsNullOrWhiteSpace(x[1]?.ToString())) ? x[1] : "0") : 0),
								LocationCode = ((x.Count < 3) ? "" : x[2]?.ToString()),
								FatherName = ((x.Count < 4) ? "" : x[3]?.ToString()),
								LocationDesc = ((x.Count < 5) ? "" : x[4]?.ToString()),
								PreNumber = ((x.Count < 6) ? "" : x[5]?.ToString())
							})));
						}
						if (list == null)
						{
							list = new List<ArianSystemLocationListResponseViewModel>();
						}
					}
				}
			}
			return list;
		}

		public List<ArianSystemWarehouseResponseViewModel> GetWarehouseList()
		{
			List<ArianSystemWarehouseResponseViewModel> list = new List<ArianSystemWarehouseResponseViewModel>();
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Remove("autt");
			httpClient.DefaultRequestHeaders.TryAddWithoutValidation("autt", AccessToken);
			string text = "api/select";
			string text2 = "";
			if (loginResult)
			{
				int num = int.MaxValue;
				ArianSystemSelectApiRequestViewModel arianSystemSelectApiRequestViewModel = new ArianSystemSelectApiRequestViewModel();
				arianSystemSelectApiRequestViewModel.id = "Stock";
				arianSystemSelectApiRequestViewModel.Params = new List<ArianSystemSelectApiRequestParamViewModel>();
				arianSystemSelectApiRequestViewModel.Params.Add(new ArianSystemSelectApiRequestParamViewModel
				{
					Name = "RowsCount",
					Value = num.ToString()
				});
				arianSystemSelectApiRequestViewModel.Params.Add(new ArianSystemSelectApiRequestParamViewModel
				{
					Name = "PageNum",
					Value = "1"
				});
				arianSystemSelectApiRequestViewModel.Params.Add(new ArianSystemSelectApiRequestParamViewModel
				{
					Name = "GridName",
					Value = "fr37MainGrid"
				});
				arianSystemSelectApiRequestViewModel.Params.Add(new ArianSystemSelectApiRequestParamViewModel
				{
					Name = "IsStruct",
					Value = "1"
				});
				StringContent content = new StringContent(JsonConvert.SerializeObject(arianSystemSelectApiRequestViewModel).Replace("\"Type\":null,", "").Replace("\"Type\":null", "")
					.Replace("\"FilterType\":null,", "")
					.Replace("\"FilterType\":null", "")
					.Replace("\"Array_Value\":null,", "")
					.Replace("\"Array_Value\":null", ""), Encoding.UTF8, "application/json");
				text = ApiAddress + text;
				new HttpRequestMessage(HttpMethod.Post, text);
				HttpResponseMessage result = httpClient.PostAsync(text, content).Result;
				if (result.IsSuccessStatusCode)
				{
					text2 = result.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(text2))
					{
						text2 = text2.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(text2))
					{
						ArianSystemSelectApiResponseViewModel arianSystemSelectApiResponseViewModel = JsonConvert.DeserializeObject<ArianSystemSelectApiResponseViewModel>(text2);
						if (arianSystemSelectApiResponseViewModel != null && arianSystemSelectApiResponseViewModel.rows != null && Enumerable.Any<List<object>>((IEnumerable<List<object>>)arianSystemSelectApiResponseViewModel.rows))
						{
							list = Enumerable.ToList<ArianSystemWarehouseResponseViewModel>(Enumerable.Select<List<object>, ArianSystemWarehouseResponseViewModel>((IEnumerable<List<object>>)arianSystemSelectApiResponseViewModel.rows, (Func<List<object>, ArianSystemWarehouseResponseViewModel>)((List<object> x) => new ArianSystemWarehouseResponseViewModel
							{
								StockCode = ((x.Count < 6) ? "" : x[5]?.ToString()),
								StockDesc = ((x.Count < 8) ? "" : x[7]?.ToString()),
								StockDescL = ((x.Count < 9) ? "" : x[8]?.ToString()),
								StockID = ((x.Count >= 10) ? Convert.ToInt32((!string.IsNullOrWhiteSpace(x[9]?.ToString())) ? x[9] : "0") : 0),
								TafsiliCode = ((x.Count < 12) ? "" : x[11]?.ToString())
							})));
							if (list != null && Enumerable.Any<ArianSystemWarehouseResponseViewModel>((IEnumerable<ArianSystemWarehouseResponseViewModel>)list))
							{
								ArianSystemWarehouseResponseViewModel arianSystemWarehouseResponseViewModel = Enumerable.FirstOrDefault<ArianSystemWarehouseResponseViewModel>((IEnumerable<ArianSystemWarehouseResponseViewModel>)list);
								if (arianSystemWarehouseResponseViewModel != null && arianSystemWarehouseResponseViewModel.StockID.GetValueOrDefault() == 0)
								{
									list = new List<ArianSystemWarehouseResponseViewModel>();
									list = Enumerable.ToList<ArianSystemWarehouseResponseViewModel>(Enumerable.Select<List<object>, ArianSystemWarehouseResponseViewModel>((IEnumerable<List<object>>)arianSystemSelectApiResponseViewModel.rows, (Func<List<object>, ArianSystemWarehouseResponseViewModel>)((List<object> x) => new ArianSystemWarehouseResponseViewModel
									{
										StockID = ((x.Count >= 1) ? Convert.ToInt32((!string.IsNullOrWhiteSpace(x[0]?.ToString())) ? x[0] : "0") : 0),
										StockCode = ((x.Count < 2) ? "" : x[1]?.ToString()),
										TafsiliCode = ((x.Count < 3) ? "" : x[2]?.ToString()),
										StockDesc = ((x.Count < 4) ? "" : x[3]?.ToString())
									})));
								}
							}
						}
						if (list == null)
						{
							list = new List<ArianSystemWarehouseResponseViewModel>();
						}
					}
				}
			}
			return list;
		}

		public List<ArianSystemUserResponseViewModel> GetSellerVisitors()
		{
			List<ArianSystemUserResponseViewModel> list = new List<ArianSystemUserResponseViewModel>();
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Remove("autt");
			httpClient.DefaultRequestHeaders.TryAddWithoutValidation("autt", AccessToken);
			string text = "api/select";
			string text2 = "";
			if (loginResult)
			{
				int num = int.MaxValue;
				ArianSystemSelectApiRequestViewModel arianSystemSelectApiRequestViewModel = new ArianSystemSelectApiRequestViewModel();
				arianSystemSelectApiRequestViewModel.id = "SellerVisitor";
				arianSystemSelectApiRequestViewModel.Params = new List<ArianSystemSelectApiRequestParamViewModel>();
				arianSystemSelectApiRequestViewModel.Params.Add(new ArianSystemSelectApiRequestParamViewModel
				{
					Name = "RowsCount",
					Value = num.ToString()
				});
				arianSystemSelectApiRequestViewModel.Params.Add(new ArianSystemSelectApiRequestParamViewModel
				{
					Name = "IsStruct",
					Value = "1"
				});
				StringContent content = new StringContent(JsonConvert.SerializeObject(arianSystemSelectApiRequestViewModel).Replace("\"Type\":null,", "").Replace("\"Type\":null", "")
					.Replace("\"FilterType\":null,", "")
					.Replace("\"FilterType\":null", "")
					.Replace("\"Array_Value\":null,", "")
					.Replace("\"Array_Value\":null", ""), Encoding.UTF8, "application/json");
				text = ApiAddress + text;
				new HttpRequestMessage(HttpMethod.Post, text);
				HttpResponseMessage result = httpClient.PostAsync(text, content).Result;
				if (result.IsSuccessStatusCode)
				{
					text2 = result.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(text2))
					{
						text2 = text2.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(text2))
					{
						ArianSystemSelectApiResponseViewModel arianSystemSelectApiResponseViewModel = JsonConvert.DeserializeObject<ArianSystemSelectApiResponseViewModel>(text2);
						if (arianSystemSelectApiResponseViewModel != null && arianSystemSelectApiResponseViewModel.rows != null && Enumerable.Any<List<object>>((IEnumerable<List<object>>)arianSystemSelectApiResponseViewModel.rows))
						{
							list = Enumerable.ToList<ArianSystemUserResponseViewModel>(Enumerable.Select<List<object>, ArianSystemUserResponseViewModel>((IEnumerable<List<object>>)arianSystemSelectApiResponseViewModel.rows, (Func<List<object>, ArianSystemUserResponseViewModel>)((List<object> x) => new ArianSystemUserResponseViewModel
							{
								SellerVisitorID = ((x.Count >= 1) ? Convert.ToInt32((!string.IsNullOrWhiteSpace(x[0]?.ToString())) ? x[0] : "0") : 0),
								PersonID = ((x.Count >= 2) ? Convert.ToInt32((!string.IsNullOrWhiteSpace(x[1]?.ToString())) ? x[1] : "0") : 0),
								PersonCode = ((x.Count < 3) ? "" : x[2]?.ToString()),
								SellerVisitorDesc = ((x.Count < 4) ? "" : x[3]?.ToString()),
								PersonTypeDesc = ((x.Count < 5) ? "" : x[4]?.ToString())
							})));
						}
						if (list == null)
						{
							list = new List<ArianSystemUserResponseViewModel>();
						}
					}
				}
			}
			return list;
		}

		public string SendCompany(ArianSystemCustomerReqestViewModel cmpInfo, ref bool isDone, ref long customerId, ref string customerCode, ref string cmpLinkAccData)
		{
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Remove("autt");
			httpClient.DefaultRequestHeaders.TryAddWithoutValidation("autt", AccessToken);
			string result = "";
			string text = "api/Insert";
			string text2 = "";
			if (loginResult)
			{
				string linkAccSystemTitle = Setting.GetLinkAccSystemTitle();
				ArianSystemInsertApiRequestViewModel arianSystemInsertApiRequestViewModel = new ArianSystemInsertApiRequestViewModel();
				arianSystemInsertApiRequestViewModel.id = "SaleCustomer";
				arianSystemInsertApiRequestViewModel.Params = new List<ArianSystemInsertApiRequestParamViewModel>();
				arianSystemInsertApiRequestViewModel.Params.Add(new ArianSystemInsertApiRequestParamViewModel
				{
					Name = "PersonFName",
					Value = (cmpInfo.PersonFName ?? "")
				});
				arianSystemInsertApiRequestViewModel.Params.Add(new ArianSystemInsertApiRequestParamViewModel
				{
					Name = "PersonTitle",
					Value = (cmpInfo.PersonTitle ?? "")
				});
				arianSystemInsertApiRequestViewModel.Params.Add(new ArianSystemInsertApiRequestParamViewModel
				{
					Name = "PersonTypeId",
					Value = cmpInfo.PersonTypeId.ToString()
				});
				arianSystemInsertApiRequestViewModel.Params.Add(new ArianSystemInsertApiRequestParamViewModel
				{
					Name = "InActive",
					Value = cmpInfo.InActive.ToString()
				});
				arianSystemInsertApiRequestViewModel.Params.Add(new ArianSystemInsertApiRequestParamViewModel
				{
					Name = "IsPerson",
					Value = cmpInfo.IsPerson.ToString()
				});
				arianSystemInsertApiRequestViewModel.Params.Add(new ArianSystemInsertApiRequestParamViewModel
				{
					Name = "FatherName",
					Value = (cmpInfo.FatherName ?? "")
				});
				arianSystemInsertApiRequestViewModel.Params.Add(new ArianSystemInsertApiRequestParamViewModel
				{
					Name = "NationalCode",
					Value = (cmpInfo.NationalCode ?? "")
				});
				arianSystemInsertApiRequestViewModel.Params.Add(new ArianSystemInsertApiRequestParamViewModel
				{
					Name = "NationalIdentity",
					Value = (cmpInfo.NationalIdentity ?? "")
				});
				arianSystemInsertApiRequestViewModel.Params.Add(new ArianSystemInsertApiRequestParamViewModel
				{
					Name = "Phone",
					Value = (cmpInfo.Phone ?? "")
				});
				arianSystemInsertApiRequestViewModel.Params.Add(new ArianSystemInsertApiRequestParamViewModel
				{
					Name = "Address",
					Value = (cmpInfo.Address ?? "")
				});
				arianSystemInsertApiRequestViewModel.Params.Add(new ArianSystemInsertApiRequestParamViewModel
				{
					Name = "CodePosti",
					Value = (cmpInfo.CodePosti ?? "")
				});
				arianSystemInsertApiRequestViewModel.Params.Add(new ArianSystemInsertApiRequestParamViewModel
				{
					Name = "Mobile",
					Value = (cmpInfo.Mobile ?? "")
				});
				arianSystemInsertApiRequestViewModel.Params.Add(new ArianSystemInsertApiRequestParamViewModel
				{
					Name = "Email",
					Value = (cmpInfo.Email ?? "")
				});
				arianSystemInsertApiRequestViewModel.Params.Add(new ArianSystemInsertApiRequestParamViewModel
				{
					Name = "RegisterLocationId",
					Value = cmpInfo.RegisterLocationId.ToString()
				});
				StringContent content = new StringContent(JsonConvert.SerializeObject(arianSystemInsertApiRequestViewModel).Replace("\"Type\":null,", "").Replace("\"Type\":null", "")
					.Replace("\"FilterType\":null,", "")
					.Replace("\"FilterType\":null", "")
					.Replace("\"Value\":null,", "")
					.Replace("\"Value\":null", "")
					.Replace("\"Array_Value\":null,", "")
					.Replace("\"Array_Value\":null", ""), Encoding.UTF8, "application/json");
				text = ApiAddress + text;
				new HttpRequestMessage(HttpMethod.Post, text);
				HttpResponseMessage result2 = httpClient.PostAsync(text, content).Result;
				if (result2.IsSuccessStatusCode)
				{
					text2 = result2.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(text2))
					{
						text2 = text2.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(text2))
					{
						ArianSystemInsertApiResponseViewModel arianSystemInsertApiResponseViewModel = JsonConvert.DeserializeObject<ArianSystemInsertApiResponseViewModel>(text2);
						if (arianSystemInsertApiResponseViewModel != null)
						{
							customerId = arianSystemInsertApiResponseViewModel.Id.GetValueOrDefault();
							if (customerId != 0L)
							{
								isDone = true;
								ArianSystemCustomerListResponseViewModel arianSystemCustomerListResponseViewModel = Enumerable.FirstOrDefault<ArianSystemCustomerListResponseViewModel>((IEnumerable<ArianSystemCustomerListResponseViewModel>)GetCustomerList(0, 1, "", "", "", "", customerId.ToString()));
								if (arianSystemCustomerListResponseViewModel != null)
								{
									string id = arianSystemCustomerListResponseViewModel.CustomerID.GetValueOrDefault().ToString();
									customerCode = arianSystemCustomerListResponseViewModel.CustomerCode ?? "";
									int valueOrDefault = arianSystemCustomerListResponseViewModel.PersonID.GetValueOrDefault();
									DateTime value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
									LinkAccDataByExtraFieldsViewModel value2 = new LinkAccDataByExtraFieldsViewModel
									{
										CId = 0,
										DBId = -1,
										Code = customerCode,
										Id = id,
										FTDate = value,
										LTDate = value,
										LACId = "0",
										ExtraI = valueOrDefault.ToString(),
										ExtraII = (arianSystemCustomerListResponseViewModel.TafsiliCode ?? ""),
										ExtraIII = ""
									};
									cmpLinkAccData = "[" + JsonConvert.SerializeObject(value2) + "]";
								}
							}
							else
							{
								isDone = false;
								result = arianSystemInsertApiResponseViewModel.Err ?? "";
							}
						}
						else
						{
							isDone = false;
							result = string.Format(Messages.msgErrorNoResponseReceivedWebservice, linkAccSystemTitle);
						}
					}
					else
					{
						isDone = false;
						result = string.Format(Messages.msgErrorNoResponseReceivedWebservice, linkAccSystemTitle);
					}
				}
				else
				{
					isDone = false;
					result = string.Format(Messages.msgErrorNoResponseReceivedWebservice, linkAccSystemTitle);
				}
			}
			else
			{
				isDone = false;
				result = Messages.msgErrorReceivingToken;
			}
			return result;
		}

		public List<ArianSystemCustomerListResponseViewModel> GetCustomerList(int recCount = 0, int linkAccPageNum = 0, string cmpName = "", string cmpCode = "", string cmpNationalCode = "", string mobileNo = "", string linkAccIdStr = "")
		{
			List<ArianSystemCustomerListResponseViewModel> list = new List<ArianSystemCustomerListResponseViewModel>();
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Remove("autt");
			httpClient.DefaultRequestHeaders.TryAddWithoutValidation("autt", AccessToken);
			string text = "api/select";
			string text2 = "";
			if (loginResult)
			{
				if (recCount <= 0)
				{
					recCount = int.MaxValue;
				}
				if (linkAccPageNum <= 0)
				{
					linkAccPageNum = 1;
				}
				ArianSystemSelectApiRequestViewModel arianSystemSelectApiRequestViewModel = new ArianSystemSelectApiRequestViewModel();
				arianSystemSelectApiRequestViewModel.id = "SaleCustomer";
				arianSystemSelectApiRequestViewModel.Params = new List<ArianSystemSelectApiRequestParamViewModel>();
				arianSystemSelectApiRequestViewModel.Params.Add(new ArianSystemSelectApiRequestParamViewModel
				{
					Name = "RowsCount",
					Value = recCount.ToString()
				});
				arianSystemSelectApiRequestViewModel.Params.Add(new ArianSystemSelectApiRequestParamViewModel
				{
					Name = "PageNum",
					Value = linkAccPageNum.ToString()
				});
				arianSystemSelectApiRequestViewModel.Params.Add(new ArianSystemSelectApiRequestParamViewModel
				{
					Name = "IsStruct",
					Value = "1"
				});
				if (!string.IsNullOrWhiteSpace(cmpName))
				{
					arianSystemSelectApiRequestViewModel.Params.Add(new ArianSystemSelectApiRequestParamViewModel
					{
						Type = "__Query__",
						Name = "PersonFullName",
						FilterType = 6,
						Value = "%" + cmpName
					});
				}
				if (!string.IsNullOrWhiteSpace(cmpCode))
				{
					arianSystemSelectApiRequestViewModel.Params.Add(new ArianSystemSelectApiRequestParamViewModel
					{
						Type = "__Query__",
						Name = "CustomerCode",
						FilterType = 6,
						Value = cmpCode
					});
				}
				if (!string.IsNullOrWhiteSpace(cmpNationalCode))
				{
					arianSystemSelectApiRequestViewModel.Params.Add(new ArianSystemSelectApiRequestParamViewModel
					{
						Type = "__Query__",
						Name = "NationalCode",
						FilterType = 6,
						Value = cmpNationalCode
					});
				}
				if (!string.IsNullOrWhiteSpace(mobileNo))
				{
					arianSystemSelectApiRequestViewModel.Params.Add(new ArianSystemSelectApiRequestParamViewModel
					{
						Type = "__Query__",
						Name = "Mobile",
						FilterType = 6,
						Value = mobileNo
					});
				}
				if (!string.IsNullOrWhiteSpace(linkAccIdStr))
				{
					arianSystemSelectApiRequestViewModel.Params.Add(new ArianSystemSelectApiRequestParamViewModel
					{
						Type = "__Query__",
						Name = "CustomerID",
						FilterType = 6,
						Value = linkAccIdStr
					});
				}
				StringContent content = new StringContent(JsonConvert.SerializeObject(arianSystemSelectApiRequestViewModel).Replace("\"Type\":null,", "").Replace("\"Type\":null", "")
					.Replace("\"FilterType\":null,", "")
					.Replace("\"FilterType\":null", "")
					.Replace("\"Array_Value\":null,", "")
					.Replace("\"Array_Value\":null", ""), Encoding.UTF8, "application/json");
				text = ApiAddress + text;
				new HttpRequestMessage(HttpMethod.Post, text);
				HttpResponseMessage result = httpClient.PostAsync(text, content).Result;
				if (result.IsSuccessStatusCode)
				{
					text2 = result.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(text2))
					{
						text2 = text2.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(text2))
					{
						ArianSystemSelectApiResponseViewModel arianSystemSelectApiResponseViewModel = JsonConvert.DeserializeObject<ArianSystemSelectApiResponseViewModel>(text2);
						if (arianSystemSelectApiResponseViewModel != null && arianSystemSelectApiResponseViewModel.rows != null && Enumerable.Any<List<object>>((IEnumerable<List<object>>)arianSystemSelectApiResponseViewModel.rows))
						{
							list = Enumerable.ToList<ArianSystemCustomerListResponseViewModel>(Enumerable.Select<List<object>, ArianSystemCustomerListResponseViewModel>((IEnumerable<List<object>>)arianSystemSelectApiResponseViewModel.rows, (Func<List<object>, ArianSystemCustomerListResponseViewModel>)((List<object> x) => new ArianSystemCustomerListResponseViewModel
							{
								CustomerClassID = ((x.Count >= 1) ? Convert.ToInt32((!string.IsNullOrWhiteSpace(x[0]?.ToString())) ? x[0] : "0") : 0),
								CustomerCode = ((x.Count < 2) ? "" : x[1]?.ToString()),
								CustomerID = ((x.Count >= 3) ? Convert.ToInt32((!string.IsNullOrWhiteSpace(x[2]?.ToString())) ? x[2] : "0") : 0),
								InActive = (x.Count >= 4 && Convert.ToBoolean((!string.IsNullOrWhiteSpace(x[3]?.ToString())) ? x[3] : "false")),
								BuyerBranchCode = ((x.Count < 5) ? "" : x[4]?.ToString()),
								PersonID = ((x.Count >= 6) ? Convert.ToInt32((!string.IsNullOrWhiteSpace(x[5]?.ToString())) ? x[5] : "0") : 0),
								PersonFullName = ((x.Count < 7) ? "" : x[6]?.ToString()),
								CustomerClassDesc = ((x.Count < 8) ? "" : x[7]?.ToString()),
								VisitorID = ((x.Count >= 9) ? Convert.ToInt32((!string.IsNullOrWhiteSpace(x[8]?.ToString())) ? x[8] : "0") : 0),
								CustomerTafsiliId = ((x.Count >= 10) ? Convert.ToInt32((!string.IsNullOrWhiteSpace(x[9]?.ToString())) ? x[9] : "0") : 0),
								CustomerTypeId = ((x.Count >= 11) ? Convert.ToInt32((!string.IsNullOrWhiteSpace(x[10]?.ToString())) ? x[10] : "0") : 0),
								IsPerson = (x.Count >= 12 && Convert.ToBoolean((!string.IsNullOrWhiteSpace(x[11]?.ToString())) ? x[11] : "false")),
								Addrs = ((x.Count < 13) ? "" : x[12]?.ToString()),
								Phone = ((x.Count < 14) ? "" : x[13]?.ToString()),
								Mobile = ((x.Count < 15) ? "" : x[14]?.ToString()),
								TafsiliCode = ((x.Count < 16) ? "" : x[15]?.ToString()),
								NationalCode = ((x.Count < 17) ? "" : x[16]?.ToString()),
								Fathername = ((x.Count < 18) ? "" : x[17]?.ToString())
							})));
						}
						if (list == null)
						{
							list = new List<ArianSystemCustomerListResponseViewModel>();
						}
					}
				}
			}
			return list;
		}

		public List<ArianSystemProductResponseViewModel> GetProductList(int pageNumber = 0, int rowCount = 0)
		{
			List<ArianSystemProductResponseViewModel> list = new List<ArianSystemProductResponseViewModel>();
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Remove("autt");
			httpClient.DefaultRequestHeaders.TryAddWithoutValidation("autt", AccessToken);
			string text = "api/select";
			string text2 = "";
			if (loginResult)
			{
				if (rowCount <= 0)
				{
					rowCount = int.MaxValue;
				}
				ArianSystemSelectApiRequestViewModel arianSystemSelectApiRequestViewModel = new ArianSystemSelectApiRequestViewModel();
				arianSystemSelectApiRequestViewModel.id = "Goods";
				arianSystemSelectApiRequestViewModel.Params = new List<ArianSystemSelectApiRequestParamViewModel>();
				arianSystemSelectApiRequestViewModel.Params.Add(new ArianSystemSelectApiRequestParamViewModel
				{
					Name = "RowsCount",
					Value = rowCount.ToString()
				});
				arianSystemSelectApiRequestViewModel.Params.Add(new ArianSystemSelectApiRequestParamViewModel
				{
					Name = "PageNum",
					Value = pageNumber.ToString()
				});
				arianSystemSelectApiRequestViewModel.Params.Add(new ArianSystemSelectApiRequestParamViewModel
				{
					Name = "IsStruct",
					Value = "1"
				});
				StringContent content = new StringContent(JsonConvert.SerializeObject(arianSystemSelectApiRequestViewModel).Replace("\"Type\":null,", "").Replace("\"Type\":null", "")
					.Replace("\"FilterType\":null,", "")
					.Replace("\"FilterType\":null", "")
					.Replace("\"Array_Value\":null,", "")
					.Replace("\"Array_Value\":null", ""), Encoding.UTF8, "application/json");
				text = ApiAddress + text;
				new HttpRequestMessage(HttpMethod.Post, text);
				HttpResponseMessage result = httpClient.PostAsync(text, content).Result;
				if (result.IsSuccessStatusCode)
				{
					text2 = result.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(text2))
					{
						text2 = text2.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(text2))
					{
						ArianSystemSelectApiResponseViewModel arianSystemSelectApiResponseViewModel = JsonConvert.DeserializeObject<ArianSystemSelectApiResponseViewModel>(text2);
						if (arianSystemSelectApiResponseViewModel != null && arianSystemSelectApiResponseViewModel.rows != null && Enumerable.Any<List<object>>((IEnumerable<List<object>>)arianSystemSelectApiResponseViewModel.rows))
						{
							list = Enumerable.ToList<ArianSystemProductResponseViewModel>(Enumerable.Select<List<object>, ArianSystemProductResponseViewModel>((IEnumerable<List<object>>)arianSystemSelectApiResponseViewModel.rows, (Func<List<object>, ArianSystemProductResponseViewModel>)((List<object> x) => new ArianSystemProductResponseViewModel
							{
								ServiceGoodsId = ((x.Count >= 1) ? Convert.ToInt32((!string.IsNullOrWhiteSpace(x[0]?.ToString())) ? x[0] : "0") : 0),
								ServiceGoodsCode = ((x.Count < 2) ? "" : x[1]?.ToString()),
								ServiceGoodsDesc = ((x.Count < 3) ? "" : x[2]?.ToString()),
								UnitID = ((x.Count >= 4) ? Convert.ToInt32((!string.IsNullOrWhiteSpace(x[3]?.ToString())) ? x[3] : "0") : 0),
								UnitDesc = ((x.Count < 5) ? "" : x[4]?.ToString())
							})));
						}
						if (list == null)
						{
							list = new List<ArianSystemProductResponseViewModel>();
						}
					}
				}
			}
			return list;
		}

		public double GetPrdQuqntity(string prdCode, string wrhsCode)
		{
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Remove("autt");
			httpClient.DefaultRequestHeaders.TryAddWithoutValidation("autt", AccessToken);
			string text = "api/select";
			double result = 0.0;
			string text2 = "";
			if (loginResult)
			{
				int num = int.MaxValue;
				PersianCalendar persianCalendar = new PersianCalendar();
				DateTime now = DateTime.Now;
				int year = persianCalendar.GetYear(now);
				int daysInMonth = persianCalendar.GetDaysInMonth(year, 12);
				string[] array_Value = new string[2]
				{
					$"{year:0000}/01/01",
					$"{year:0000}/12/{daysInMonth:29}"
				};
				string[] array_Value2 = new string[2]
				{
					wrhsCode ?? "",
					""
				};
				ArianSystemSelectApiRequestViewModel arianSystemSelectApiRequestViewModel = new ArianSystemSelectApiRequestViewModel();
				arianSystemSelectApiRequestViewModel.id = "InvGoodsCount";
				arianSystemSelectApiRequestViewModel.Params = new List<ArianSystemSelectApiRequestParamViewModel>();
				arianSystemSelectApiRequestViewModel.Params.Add(new ArianSystemSelectApiRequestParamViewModel
				{
					Name = "RowsCount",
					Value = num.ToString()
				});
				arianSystemSelectApiRequestViewModel.Params.Add(new ArianSystemSelectApiRequestParamViewModel
				{
					Type = "__Query__",
					Name = "GroupCode1",
					FilterType = 6,
					Value = prdCode
				});
				arianSystemSelectApiRequestViewModel.Params.Add(new ArianSystemSelectApiRequestParamViewModel
				{
					Name = "GridName",
					Value = "fr437MainGrid"
				});
				arianSystemSelectApiRequestViewModel.Params.Add(new ArianSystemSelectApiRequestParamViewModel
				{
					Name = "RightLv",
					Value = "1"
				});
				arianSystemSelectApiRequestViewModel.Params.Add(new ArianSystemSelectApiRequestParamViewModel
				{
					Type = "_vf_",
					Name = "VoucherDate",
					FilterType = 2,
					Array_Value = array_Value
				});
				arianSystemSelectApiRequestViewModel.Params.Add(new ArianSystemSelectApiRequestParamViewModel
				{
					Type = "_vf_",
					Name = "StockCode",
					FilterType = 3,
					Array_Value = array_Value2
				});
				arianSystemSelectApiRequestViewModel.Params.Add(new ArianSystemSelectApiRequestParamViewModel
				{
					Name = "ShowAll",
					Value = "0"
				});
				arianSystemSelectApiRequestViewModel.Params.Add(new ArianSystemSelectApiRequestParamViewModel
				{
					Name = "IsSecQuantity",
					Value = "0"
				});
				arianSystemSelectApiRequestViewModel.Params.Add(new ArianSystemSelectApiRequestParamViewModel
				{
					Name = "stockMode",
					Value = "0"
				});
				arianSystemSelectApiRequestViewModel.Params.Add(new ArianSystemSelectApiRequestParamViewModel
				{
					Name = "ShowDetectionCount",
					Value = "0"
				});
				arianSystemSelectApiRequestViewModel.Params.Add(new ArianSystemSelectApiRequestParamViewModel
				{
					Name = "IsByStock",
					Value = "0"
				});
				arianSystemSelectApiRequestViewModel.Params.Add(new ArianSystemSelectApiRequestParamViewModel
				{
					Name = "OrderShowType",
					Value = "0"
				});
				arianSystemSelectApiRequestViewModel.Params.Add(new ArianSystemSelectApiRequestParamViewModel
				{
					Name = "InfoTag",
					Value = "0"
				});
				arianSystemSelectApiRequestViewModel.Params.Add(new ArianSystemSelectApiRequestParamViewModel
				{
					Name = "VoucherIdentityId",
					Value = "-1"
				});
				arianSystemSelectApiRequestViewModel.Params.Add(new ArianSystemSelectApiRequestParamViewModel
				{
					Name = "GoodsType",
					Value = "0"
				});
				arianSystemSelectApiRequestViewModel.Params.Add(new ArianSystemSelectApiRequestParamViewModel
				{
					Name = "IsStruct",
					Value = "1"
				});
				StringContent content = new StringContent(JsonConvert.SerializeObject(arianSystemSelectApiRequestViewModel).Replace("\"Type\":null,", "").Replace("\"Type\":null", "")
					.Replace("\"FilterType\":null,", "")
					.Replace("\"FilterType\":null", "")
					.Replace("\"Array_Value\":null,", "")
					.Replace("\"Array_Value\":null", "")
					.Replace(",\"Value\":null", "")
					.Replace("\"Value\":null,", "")
					.Replace("\"Value\":null", ""), Encoding.UTF8, "application/json");
				text = ApiAddress + text;
				new HttpRequestMessage(HttpMethod.Post, text);
				HttpResponseMessage result2 = httpClient.PostAsync(text, content).Result;
				if (result2.IsSuccessStatusCode)
				{
					text2 = result2.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(text2))
					{
						text2 = text2.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(text2))
					{
						ArianSystemSelectApiResponseViewModel arianSystemSelectApiResponseViewModel = JsonConvert.DeserializeObject<ArianSystemSelectApiResponseViewModel>(text2);
						if (arianSystemSelectApiResponseViewModel != null && arianSystemSelectApiResponseViewModel.rows != null && Enumerable.Any<List<object>>((IEnumerable<List<object>>)arianSystemSelectApiResponseViewModel.rows))
						{
							List<ArianSystemProductRemainingResponseViewModel> list = Enumerable.ToList<ArianSystemProductRemainingResponseViewModel>(Enumerable.Select<List<object>, ArianSystemProductRemainingResponseViewModel>((IEnumerable<List<object>>)arianSystemSelectApiResponseViewModel.rows, (Func<List<object>, ArianSystemProductRemainingResponseViewModel>)((List<object> x) => new ArianSystemProductRemainingResponseViewModel
							{
								FirstPeriod = ((x.Count >= 1) ? Convert.ToDecimal((!string.IsNullOrWhiteSpace(x[0]?.ToString())) ? x[0] : "0") : 0m),
								Import = ((x.Count >= 2) ? Convert.ToDecimal((!string.IsNullOrWhiteSpace(x[1]?.ToString())) ? x[1] : "0") : 0m),
								Export = ((x.Count >= 3) ? Convert.ToDecimal((!string.IsNullOrWhiteSpace(x[2]?.ToString())) ? x[2] : "0") : 0m),
								Remain = ((x.Count >= 4) ? Convert.ToDecimal((!string.IsNullOrWhiteSpace(x[3]?.ToString())) ? x[3] : "0") : 0m),
								HasDetectionInv = (x.Count >= 5 && Convert.ToBoolean((!string.IsNullOrWhiteSpace(x[4]?.ToString())) ? x[4] : "false")),
								GroupCode1 = ((x.Count < 6) ? "" : x[5]?.ToString())
							})));
							if (list != null && Enumerable.Any<ArianSystemProductRemainingResponseViewModel>((IEnumerable<ArianSystemProductRemainingResponseViewModel>)list))
							{
								ArianSystemProductRemainingResponseViewModel arianSystemProductRemainingResponseViewModel = Enumerable.FirstOrDefault<ArianSystemProductRemainingResponseViewModel>((IEnumerable<ArianSystemProductRemainingResponseViewModel>)list);
								if (arianSystemProductRemainingResponseViewModel != null)
								{
									double.TryParse(arianSystemProductRemainingResponseViewModel.Remain.ToString(), out result);
								}
							}
						}
					}
				}
			}
			return result;
		}

		public List<ArianSystemSalePaymentWayResponseViewModel> GetSalePaymentWay()
		{
			List<ArianSystemSalePaymentWayResponseViewModel> list = new List<ArianSystemSalePaymentWayResponseViewModel>();
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Remove("autt");
			httpClient.DefaultRequestHeaders.TryAddWithoutValidation("autt", AccessToken);
			string text = "api/select";
			string text2 = "";
			if (loginResult)
			{
				int num = int.MaxValue;
				ArianSystemSelectApiRequestViewModel arianSystemSelectApiRequestViewModel = new ArianSystemSelectApiRequestViewModel();
				arianSystemSelectApiRequestViewModel.id = "SalePaymentWay";
				arianSystemSelectApiRequestViewModel.Params = new List<ArianSystemSelectApiRequestParamViewModel>();
				arianSystemSelectApiRequestViewModel.Params.Add(new ArianSystemSelectApiRequestParamViewModel
				{
					Name = "RowsCount",
					Value = num.ToString()
				});
				arianSystemSelectApiRequestViewModel.Params.Add(new ArianSystemSelectApiRequestParamViewModel
				{
					Name = "GridName",
					Value = "fr29MainGrid"
				});
				arianSystemSelectApiRequestViewModel.Params.Add(new ArianSystemSelectApiRequestParamViewModel
				{
					Name = "IsStruct",
					Value = "1"
				});
				StringContent content = new StringContent(JsonConvert.SerializeObject(arianSystemSelectApiRequestViewModel).Replace("\"Type\":null,", "").Replace("\"Type\":null", "")
					.Replace("\"FilterType\":null,", "")
					.Replace("\"FilterType\":null", "")
					.Replace("\"Array_Value\":null,", "")
					.Replace("\"Array_Value\":null", ""), Encoding.UTF8, "application/json");
				text = ApiAddress + text;
				new HttpRequestMessage(HttpMethod.Post, text);
				HttpResponseMessage result = httpClient.PostAsync(text, content).Result;
				if (result.IsSuccessStatusCode)
				{
					text2 = result.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(text2))
					{
						text2 = text2.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(text2))
					{
						ArianSystemSelectApiResponseViewModel arianSystemSelectApiResponseViewModel = JsonConvert.DeserializeObject<ArianSystemSelectApiResponseViewModel>(text2);
						if (arianSystemSelectApiResponseViewModel != null && arianSystemSelectApiResponseViewModel.rows != null && Enumerable.Any<List<object>>((IEnumerable<List<object>>)arianSystemSelectApiResponseViewModel.rows))
						{
							list = Enumerable.ToList<ArianSystemSalePaymentWayResponseViewModel>(Enumerable.Select<List<object>, ArianSystemSalePaymentWayResponseViewModel>((IEnumerable<List<object>>)arianSystemSelectApiResponseViewModel.rows, (Func<List<object>, ArianSystemSalePaymentWayResponseViewModel>)((List<object> x) => new ArianSystemSalePaymentWayResponseViewModel
							{
								PaymentWayID = ((x.Count >= 1) ? Convert.ToInt32((!string.IsNullOrWhiteSpace(x[0]?.ToString())) ? x[0] : "0") : 0),
								PaymentWayDesc = ((x.Count < 2) ? "" : x[1]?.ToString()),
								PaymentWayCode = ((x.Count < 3) ? "" : x[2]?.ToString()),
								DurationPayDays = ((x.Count >= 4) ? Convert.ToInt32((!string.IsNullOrWhiteSpace(x[3]?.ToString())) ? x[3] : "0") : 0),
								IsBuy = (x.Count >= 5 && Convert.ToBoolean((!string.IsNullOrWhiteSpace(x[4]?.ToString())) ? x[4] : "false"))
							})));
						}
						if (list == null)
						{
							list = new List<ArianSystemSalePaymentWayResponseViewModel>();
						}
					}
				}
			}
			return list;
		}

		public List<LkWSPayConditionInfoViewModel> GetPayCondition()
		{
			List<LkWSPayConditionInfoViewModel> list = new List<LkWSPayConditionInfoViewModel>();
			List<ArianSystemSalePaymentWayResponseViewModel> salePaymentWay = GetSalePaymentWay();
			if (salePaymentWay != null && Enumerable.Any<ArianSystemSalePaymentWayResponseViewModel>((IEnumerable<ArianSystemSalePaymentWayResponseViewModel>)salePaymentWay))
			{
				foreach (ArianSystemSalePaymentWayResponseViewModel item2 in salePaymentWay)
				{
					LkWSPayConditionInfoViewModel item = new LkWSPayConditionInfoViewModel
					{
						PayCondition = (item2.PaymentWayDesc ?? ""),
						LinkAccPayConditionIdStr = item2.PaymentWayID.GetValueOrDefault().ToString()
					};
					list.Add(item);
				}
			}
			if (list == null)
			{
				list = new List<LkWSPayConditionInfoViewModel>();
			}
			return list;
		}

		public List<LkWSSettlementTypeInfoViewModel> GetSettlementType()
		{
			List<LkWSSettlementTypeInfoViewModel> list = new List<LkWSSettlementTypeInfoViewModel>();
			List<ArianSystemSalePaymentWayResponseViewModel> salePaymentWay = GetSalePaymentWay();
			if (salePaymentWay != null && Enumerable.Any<ArianSystemSalePaymentWayResponseViewModel>((IEnumerable<ArianSystemSalePaymentWayResponseViewModel>)salePaymentWay))
			{
				foreach (ArianSystemSalePaymentWayResponseViewModel item2 in salePaymentWay)
				{
					LkWSSettlementTypeInfoViewModel item = new LkWSSettlementTypeInfoViewModel
					{
						Name = (item2.PaymentWayDesc ?? ""),
						LinkAccSettlementTypeIdStr = item2.PaymentWayID.GetValueOrDefault().ToString()
					};
					list.Add(item);
				}
			}
			if (list == null)
			{
				list = new List<LkWSSettlementTypeInfoViewModel>();
			}
			return list;
		}

		public List<ArianSystemComCentersResponseViewModel> GetComCenters(int mode)
		{
			List<ArianSystemComCentersResponseViewModel> list = new List<ArianSystemComCentersResponseViewModel>();
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Remove("autt");
			httpClient.DefaultRequestHeaders.TryAddWithoutValidation("autt", AccessToken);
			string text = "api/select";
			string text2 = "";
			if (loginResult)
			{
				string value = "فروش";
				if (mode == 2)
				{
					value = "تحویل";
				}
				int num = int.MaxValue;
				ArianSystemSelectApiRequestViewModel arianSystemSelectApiRequestViewModel = new ArianSystemSelectApiRequestViewModel();
				arianSystemSelectApiRequestViewModel.id = "ComCenters";
				arianSystemSelectApiRequestViewModel.Params = new List<ArianSystemSelectApiRequestParamViewModel>();
				arianSystemSelectApiRequestViewModel.Params.Add(new ArianSystemSelectApiRequestParamViewModel
				{
					Name = "RowsCount",
					Value = num.ToString()
				});
				arianSystemSelectApiRequestViewModel.Params.Add(new ArianSystemSelectApiRequestParamViewModel
				{
					Type = "__Query__",
					Name = "CentersTypeDesc",
					FilterType = 6,
					Value = value
				});
				arianSystemSelectApiRequestViewModel.Params.Add(new ArianSystemSelectApiRequestParamViewModel
				{
					Name = "GridName",
					Value = "fr19MainGrid"
				});
				arianSystemSelectApiRequestViewModel.Params.Add(new ArianSystemSelectApiRequestParamViewModel
				{
					Name = "IsStruct",
					Value = "1"
				});
				StringContent content = new StringContent(JsonConvert.SerializeObject(arianSystemSelectApiRequestViewModel).Replace("\"Type\":null,", "").Replace("\"Type\":null", "")
					.Replace("\"FilterType\":null,", "")
					.Replace("\"FilterType\":null", "")
					.Replace("\"Array_Value\":null,", "")
					.Replace("\"Array_Value\":null", ""), Encoding.UTF8, "application/json");
				text = ApiAddress + text;
				new HttpRequestMessage(HttpMethod.Post, text);
				HttpResponseMessage result = httpClient.PostAsync(text, content).Result;
				if (result.IsSuccessStatusCode)
				{
					text2 = result.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(text2))
					{
						text2 = text2.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(text2))
					{
						ArianSystemSelectApiResponseViewModel arianSystemSelectApiResponseViewModel = JsonConvert.DeserializeObject<ArianSystemSelectApiResponseViewModel>(text2);
						if (arianSystemSelectApiResponseViewModel != null && arianSystemSelectApiResponseViewModel.rows != null && Enumerable.Any<List<object>>((IEnumerable<List<object>>)arianSystemSelectApiResponseViewModel.rows))
						{
							list = Enumerable.ToList<ArianSystemComCentersResponseViewModel>(Enumerable.Select<List<object>, ArianSystemComCentersResponseViewModel>((IEnumerable<List<object>>)arianSystemSelectApiResponseViewModel.rows, (Func<List<object>, ArianSystemComCentersResponseViewModel>)((List<object> x) => new ArianSystemComCentersResponseViewModel
							{
								CentersID = ((x.Count >= 1) ? Convert.ToInt32((!string.IsNullOrWhiteSpace(x[0]?.ToString())) ? x[0] : "0") : 0),
								CentersDesc = ((x.Count < 2) ? "" : x[1]?.ToString()),
								CentersType = ((x.Count >= 3) ? Convert.ToInt32((!string.IsNullOrWhiteSpace(x[2]?.ToString())) ? x[2] : "0") : 0),
								CentersCode = ((x.Count < 4) ? "" : x[3]?.ToString())
							})));
						}
						if (list == null)
						{
							list = new List<ArianSystemComCentersResponseViewModel>();
						}
					}
				}
			}
			return list;
		}

		public List<LkWSSaleCenterInfoViewModel> GetSaleCenter()
		{
			List<LkWSSaleCenterInfoViewModel> list = new List<LkWSSaleCenterInfoViewModel>();
			List<ArianSystemComCentersResponseViewModel> comCenters = GetComCenters(1);
			if (comCenters != null && Enumerable.Any<ArianSystemComCentersResponseViewModel>((IEnumerable<ArianSystemComCentersResponseViewModel>)comCenters))
			{
				foreach (ArianSystemComCentersResponseViewModel item2 in comCenters)
				{
					LkWSSaleCenterInfoViewModel item = new LkWSSaleCenterInfoViewModel
					{
						SaleCenterName = (item2.CentersDesc ?? ""),
						LinkAccSaleCenterIdStr = item2.CentersID.GetValueOrDefault().ToString()
					};
					list.Add(item);
				}
			}
			if (list == null)
			{
				list = new List<LkWSSaleCenterInfoViewModel>();
			}
			return list;
		}

		public List<LkWSDeliveryTermInfoViewModel> GetDeliveryTerm()
		{
			List<LkWSDeliveryTermInfoViewModel> list = new List<LkWSDeliveryTermInfoViewModel>();
			List<ArianSystemComCentersResponseViewModel> comCenters = GetComCenters(2);
			if (comCenters != null && Enumerable.Any<ArianSystemComCentersResponseViewModel>((IEnumerable<ArianSystemComCentersResponseViewModel>)comCenters))
			{
				foreach (ArianSystemComCentersResponseViewModel item2 in comCenters)
				{
					LkWSDeliveryTermInfoViewModel item = new LkWSDeliveryTermInfoViewModel
					{
						DeliveryTerm = (item2.CentersDesc ?? ""),
						LinkAccDeliveryTermIdStr = item2.CentersID.GetValueOrDefault().ToString()
					};
					list.Add(item);
				}
			}
			if (list == null)
			{
				list = new List<LkWSDeliveryTermInfoViewModel>();
			}
			return list;
		}

		public List<ArianSystemComSaleTypeResponseViewModel> GetComSaleType()
		{
			List<ArianSystemComSaleTypeResponseViewModel> list = new List<ArianSystemComSaleTypeResponseViewModel>();
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Remove("autt");
			httpClient.DefaultRequestHeaders.TryAddWithoutValidation("autt", AccessToken);
			string text = "api/select";
			string text2 = "";
			if (loginResult)
			{
				int num = int.MaxValue;
				ArianSystemSelectApiRequestViewModel arianSystemSelectApiRequestViewModel = new ArianSystemSelectApiRequestViewModel();
				arianSystemSelectApiRequestViewModel.id = "ComSaleType";
				arianSystemSelectApiRequestViewModel.Params = new List<ArianSystemSelectApiRequestParamViewModel>();
				arianSystemSelectApiRequestViewModel.Params.Add(new ArianSystemSelectApiRequestParamViewModel
				{
					Name = "RowsCount",
					Value = num.ToString()
				});
				arianSystemSelectApiRequestViewModel.Params.Add(new ArianSystemSelectApiRequestParamViewModel
				{
					Name = "GridName",
					Value = "fr20MainGrid"
				});
				arianSystemSelectApiRequestViewModel.Params.Add(new ArianSystemSelectApiRequestParamViewModel
				{
					Name = "IsStruct",
					Value = "1"
				});
				StringContent content = new StringContent(JsonConvert.SerializeObject(arianSystemSelectApiRequestViewModel).Replace("\"Type\":null,", "").Replace("\"Type\":null", "")
					.Replace("\"FilterType\":null,", "")
					.Replace("\"FilterType\":null", "")
					.Replace("\"Array_Value\":null,", "")
					.Replace("\"Array_Value\":null", ""), Encoding.UTF8, "application/json");
				text = ApiAddress + text;
				new HttpRequestMessage(HttpMethod.Post, text);
				HttpResponseMessage result = httpClient.PostAsync(text, content).Result;
				if (result.IsSuccessStatusCode)
				{
					text2 = result.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(text2))
					{
						text2 = text2.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(text2))
					{
						ArianSystemSelectApiResponseViewModel arianSystemSelectApiResponseViewModel = JsonConvert.DeserializeObject<ArianSystemSelectApiResponseViewModel>(text2);
						if (arianSystemSelectApiResponseViewModel != null && arianSystemSelectApiResponseViewModel.rows != null && Enumerable.Any<List<object>>((IEnumerable<List<object>>)arianSystemSelectApiResponseViewModel.rows))
						{
							list = Enumerable.ToList<ArianSystemComSaleTypeResponseViewModel>(Enumerable.Select<List<object>, ArianSystemComSaleTypeResponseViewModel>((IEnumerable<List<object>>)arianSystemSelectApiResponseViewModel.rows, (Func<List<object>, ArianSystemComSaleTypeResponseViewModel>)((List<object> x) => new ArianSystemComSaleTypeResponseViewModel
							{
								BuySaleTypeID = ((x.Count >= 1) ? Convert.ToInt32((!string.IsNullOrWhiteSpace(x[0]?.ToString())) ? x[0] : "0") : 0),
								BuySaleTypeCode = ((x.Count < 2) ? "" : x[1]?.ToString()),
								BuySaleTypeDesc = ((x.Count < 3) ? "" : x[2]?.ToString()),
								BuySaleType = ((x.Count >= 4) ? Convert.ToInt32((!string.IsNullOrWhiteSpace(x[3]?.ToString())) ? x[3] : "0") : 0)
							})));
						}
						if (list == null)
						{
							list = new List<ArianSystemComSaleTypeResponseViewModel>();
						}
					}
				}
			}
			return list;
		}

		public ArianSystemSaleFactorResponseViewModel GetSaleFactor(int mode, string headId)
		{
			ArianSystemSaleFactorResponseViewModel arianSystemSaleFactorResponseViewModel = new ArianSystemSaleFactorResponseViewModel();
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Remove("autt");
			httpClient.DefaultRequestHeaders.TryAddWithoutValidation("autt", AccessToken);
			string text = "api/select";
			string text2 = "";
			if (loginResult)
			{
				string id = "";
				switch (mode)
				{
				case 1:
					id = "SaleFactor";
					break;
				case 2:
					id = "SaleRetFactor";
					break;
				case 3:
					id = "SaleProforma";
					break;
				}
				int num = int.MaxValue;
				ArianSystemSelectApiRequestViewModel arianSystemSelectApiRequestViewModel = new ArianSystemSelectApiRequestViewModel();
				arianSystemSelectApiRequestViewModel.id = id;
				arianSystemSelectApiRequestViewModel.Params = new List<ArianSystemSelectApiRequestParamViewModel>();
				arianSystemSelectApiRequestViewModel.Params.Add(new ArianSystemSelectApiRequestParamViewModel
				{
					Name = "RowsCount",
					Value = num.ToString()
				});
				arianSystemSelectApiRequestViewModel.Params.Add(new ArianSystemSelectApiRequestParamViewModel
				{
					Name = "PageNum",
					Value = "1"
				});
				arianSystemSelectApiRequestViewModel.Params.Add(new ArianSystemSelectApiRequestParamViewModel
				{
					Name = "GridName",
					Value = "fr254MainGrid"
				});
				arianSystemSelectApiRequestViewModel.Params.Add(new ArianSystemSelectApiRequestParamViewModel
				{
					Name = "IsStruct",
					Value = "1"
				});
				arianSystemSelectApiRequestViewModel.Params.Add(new ArianSystemSelectApiRequestParamViewModel
				{
					Type = "__Query__",
					Name = "SaleHeaderID",
					FilterType = 6,
					Value = headId
				});
				StringContent content = new StringContent(JsonConvert.SerializeObject(arianSystemSelectApiRequestViewModel).Replace("\"Type\":null,", "").Replace("\"Type\":null", "")
					.Replace("\"FilterType\":null,", "")
					.Replace("\"FilterType\":null", "")
					.Replace("\"Array_Value\":null,", "")
					.Replace("\"Array_Value\":null", ""), Encoding.UTF8, "application/json");
				text = ApiAddress + text;
				new HttpRequestMessage(HttpMethod.Post, text);
				HttpResponseMessage result = httpClient.PostAsync(text, content).Result;
				if (result.IsSuccessStatusCode)
				{
					text2 = result.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(text2))
					{
						text2 = text2.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(text2))
					{
						ArianSystemSelectApiResponseViewModel arianSystemSelectApiResponseViewModel = JsonConvert.DeserializeObject<ArianSystemSelectApiResponseViewModel>(text2);
						if (arianSystemSelectApiResponseViewModel != null && arianSystemSelectApiResponseViewModel.rows != null && Enumerable.Any<List<object>>((IEnumerable<List<object>>)arianSystemSelectApiResponseViewModel.rows))
						{
							arianSystemSaleFactorResponseViewModel = Enumerable.FirstOrDefault<ArianSystemSaleFactorResponseViewModel>(Enumerable.Select<List<object>, ArianSystemSaleFactorResponseViewModel>((IEnumerable<List<object>>)arianSystemSelectApiResponseViewModel.rows, (Func<List<object>, ArianSystemSaleFactorResponseViewModel>)((List<object> x) => new ArianSystemSaleFactorResponseViewModel
							{
								SaleHeaderID = ((x.Count >= 1) ? Convert.ToInt32((!string.IsNullOrWhiteSpace(x[0]?.ToString())) ? x[0] : "0") : 0),
								VoucherNumber = ((x.Count >= 2) ? Convert.ToInt32((!string.IsNullOrWhiteSpace(x[1]?.ToString())) ? x[1] : "0") : 0),
								VoucherDate = ((x.Count < 3) ? "" : x[2]?.ToString()),
								CustomerName = ((x.Count < 4) ? "" : x[3]?.ToString())
							})));
						}
						if (arianSystemSaleFactorResponseViewModel == null)
						{
							arianSystemSaleFactorResponseViewModel = new ArianSystemSaleFactorResponseViewModel();
						}
					}
				}
			}
			return arianSystemSaleFactorResponseViewModel;
		}

		public List<ArianSystemSaleFactorListResponseViewModel> GetSaleFactorList(string fromDate = "", string toDate = "", int pageNumber = 0, int mode = 0)
		{
			List<ArianSystemSaleFactorListResponseViewModel> list = new List<ArianSystemSaleFactorListResponseViewModel>();
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Remove("autt");
			httpClient.DefaultRequestHeaders.TryAddWithoutValidation("autt", AccessToken);
			string text = "api/select";
			string text2 = "";
			if (loginResult)
			{
				string id = "";
				switch (mode)
				{
				case 1:
					id = "SaleFactorHeaderDetail";
					break;
				case 2:
					id = "SaleRetFactorHeaderDetail";
					break;
				case 3:
					id = "SaleProformaHeaderDetail";
					break;
				}
				new PersianCalendar();
				_ = DateTime.Now;
				string[] array_Value = new string[2]
				{
					fromDate ?? "",
					toDate ?? ""
				};
				int num = int.MaxValue;
				ArianSystemSelectApiRequestViewModel arianSystemSelectApiRequestViewModel = new ArianSystemSelectApiRequestViewModel();
				arianSystemSelectApiRequestViewModel.id = id;
				arianSystemSelectApiRequestViewModel.Params = new List<ArianSystemSelectApiRequestParamViewModel>();
				arianSystemSelectApiRequestViewModel.Params.Add(new ArianSystemSelectApiRequestParamViewModel
				{
					Name = "RowsCount",
					Value = num.ToString()
				});
				arianSystemSelectApiRequestViewModel.Params.Add(new ArianSystemSelectApiRequestParamViewModel
				{
					Name = "PageNum",
					Value = pageNumber.ToString()
				});
				arianSystemSelectApiRequestViewModel.Params.Add(new ArianSystemSelectApiRequestParamViewModel
				{
					Name = "IsStruct",
					Value = "1"
				});
				arianSystemSelectApiRequestViewModel.Params.Add(new ArianSystemSelectApiRequestParamViewModel
				{
					Name = "VoucherStatMode",
					Value = "-1"
				});
				if (!string.IsNullOrWhiteSpace(fromDate) && !string.IsNullOrWhiteSpace(toDate))
				{
					arianSystemSelectApiRequestViewModel.Params.Add(new ArianSystemSelectApiRequestParamViewModel
					{
						Type = "_vf_",
						Name = "VoucherDate",
						FilterType = 2,
						Array_Value = array_Value
					});
				}
				StringContent content = new StringContent(JsonConvert.SerializeObject(arianSystemSelectApiRequestViewModel).Replace("\"Type\":null,", "").Replace("\"Type\":null", "")
					.Replace("\"FilterType\":null,", "")
					.Replace("\"FilterType\":null", "")
					.Replace("\"Array_Value\":null,", "")
					.Replace("\"Array_Value\":null", ""), Encoding.UTF8, "application/json");
				text = ApiAddress + text;
				new HttpRequestMessage(HttpMethod.Post, text);
				HttpResponseMessage result = httpClient.PostAsync(text, content).Result;
				if (result.IsSuccessStatusCode)
				{
					text2 = result.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(text2))
					{
						text2 = text2.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(text2))
					{
						ArianSystemSelectApiResponseViewModel arianSystemSelectApiResponseViewModel = JsonConvert.DeserializeObject<ArianSystemSelectApiResponseViewModel>(text2);
						if (arianSystemSelectApiResponseViewModel != null && arianSystemSelectApiResponseViewModel.rows != null && Enumerable.Any<List<object>>((IEnumerable<List<object>>)arianSystemSelectApiResponseViewModel.rows))
						{
							list = Enumerable.ToList<ArianSystemSaleFactorListResponseViewModel>(Enumerable.Select<List<object>, ArianSystemSaleFactorListResponseViewModel>((IEnumerable<List<object>>)arianSystemSelectApiResponseViewModel.rows, (Func<List<object>, ArianSystemSaleFactorListResponseViewModel>)((List<object> x) => new ArianSystemSaleFactorListResponseViewModel
							{
								SaleHeaderID = ((x.Count < 1) ? "" : x[0]?.ToString()),
								VoucherNumber = ((x.Count >= 2) ? Convert.ToInt32((!string.IsNullOrWhiteSpace(x[1]?.ToString())) ? x[1] : "0") : 0),
								VoucherDate = ((x.Count < 3) ? "" : x[2]?.ToString()),
								StockID = ((x.Count >= 4) ? Convert.ToInt32((!string.IsNullOrWhiteSpace(x[3]?.ToString())) ? x[3] : "0") : 0),
								ServiceGoodsID = ((x.Count >= 5) ? Convert.ToInt32((!string.IsNullOrWhiteSpace(x[4]?.ToString())) ? x[4] : "0") : 0),
								ServiceGoodsCode = ((x.Count < 6) ? "" : x[5]?.ToString()),
								ServiceGoodsDesc = ((x.Count < 7) ? "" : x[6]?.ToString()),
								UnitDesc = ((x.Count < 8) ? "" : x[7]?.ToString()),
								Fee = ((x.Count >= 9) ? Convert.ToDecimal((!string.IsNullOrWhiteSpace(x[8]?.ToString())) ? x[8] : "0") : 0m),
								Quantity = ((x.Count >= 10) ? Convert.ToDecimal((!string.IsNullOrWhiteSpace(x[9]?.ToString())) ? x[9] : "0") : 0m),
								RowMab = ((x.Count >= 11) ? Convert.ToDecimal((!string.IsNullOrWhiteSpace(x[10]?.ToString())) ? x[10] : "0") : 0m),
								DetailDesc = ((x.Count < 12) ? "" : x[11]?.ToString()),
								RowGhabel = ((x.Count >= 13) ? Convert.ToDecimal((!string.IsNullOrWhiteSpace(x[12]?.ToString())) ? x[12] : "0") : 0m),
								RowKosorat = ((x.Count >= 14) ? Convert.ToDecimal((!string.IsNullOrWhiteSpace(x[13]?.ToString())) ? x[13] : "0") : 0m),
								RowEzafat = ((x.Count >= 15) ? Convert.ToDecimal((!string.IsNullOrWhiteSpace(x[14]?.ToString())) ? x[14] : "0") : 0m),
								Ghabel = ((x.Count >= 16) ? Convert.ToDecimal((!string.IsNullOrWhiteSpace(x[15]?.ToString())) ? x[15] : "0") : 0m)
							})));
						}
						if (list == null)
						{
							list = new List<ArianSystemSaleFactorListResponseViewModel>();
						}
					}
				}
			}
			return list;
		}

		public string SendSaleFactor(ArianSystemSaleFactorRequestViewModel headInfo, ref bool isDone, ref long linkAccId, ref string linkAccNumber, ref string linkAccVocherNumber, int mode = 0)
		{
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Remove("autt");
			httpClient.DefaultRequestHeaders.TryAddWithoutValidation("autt", AccessToken);
			string result = "";
			string text = "api/Insert";
			string text2 = "";
			if (loginResult)
			{
				string linkAccSystemTitle = Setting.GetLinkAccSystemTitle();
				string id = "";
				switch (mode)
				{
				case 1:
					id = "SaleFactor";
					break;
				case 2:
					id = "SaleRetFactor";
					break;
				case 3:
					id = "SaleProforma";
					break;
				}
				ArianSystemInsertApiRequestViewModel arianSystemInsertApiRequestViewModel = new ArianSystemInsertApiRequestViewModel();
				arianSystemInsertApiRequestViewModel.id = id;
				arianSystemInsertApiRequestViewModel.Params = new List<ArianSystemInsertApiRequestParamViewModel>();
				arianSystemInsertApiRequestViewModel.Params.Add(new ArianSystemInsertApiRequestParamViewModel
				{
					Name = "CustomerId",
					Value = (headInfo.CustomerId ?? "")
				});
				if (headInfo.SecCustomerId != null)
				{
					arianSystemInsertApiRequestViewModel.Params.Add(new ArianSystemInsertApiRequestParamViewModel
					{
						Name = "SecCustomerId",
						Value = (headInfo.SecCustomerId ?? "")
					});
				}
				arianSystemInsertApiRequestViewModel.Params.Add(new ArianSystemInsertApiRequestParamViewModel
				{
					Name = "SaleTypeID",
					Value = (headInfo.SaleTypeID ?? "")
				});
				arianSystemInsertApiRequestViewModel.Params.Add(new ArianSystemInsertApiRequestParamViewModel
				{
					Name = "StockID",
					Value = (headInfo.StockID ?? "")
				});
				arianSystemInsertApiRequestViewModel.Params.Add(new ArianSystemInsertApiRequestParamViewModel
				{
					Name = "SaleCenterID",
					Value = (headInfo.SaleCenterID ?? "")
				});
				arianSystemInsertApiRequestViewModel.Params.Add(new ArianSystemInsertApiRequestParamViewModel
				{
					Name = "DeliveryCenterID",
					Value = (headInfo.DeliveryCenterID ?? "")
				});
				arianSystemInsertApiRequestViewModel.Params.Add(new ArianSystemInsertApiRequestParamViewModel
				{
					Name = "SellerID",
					Value = (headInfo.SellerID ?? "")
				});
				arianSystemInsertApiRequestViewModel.Params.Add(new ArianSystemInsertApiRequestParamViewModel
				{
					Name = "SaleManID",
					Value = (headInfo.SaleManID ?? "")
				});
				arianSystemInsertApiRequestViewModel.Params.Add(new ArianSystemInsertApiRequestParamViewModel
				{
					Name = "PaymentWayID",
					Value = (headInfo.PaymentWayID ?? "")
				});
				arianSystemInsertApiRequestViewModel.Params.Add(new ArianSystemInsertApiRequestParamViewModel
				{
					Name = "PayWayDays",
					Value = (headInfo.PayWayDays ?? "")
				});
				arianSystemInsertApiRequestViewModel.Params.Add(new ArianSystemInsertApiRequestParamViewModel
				{
					Name = "VoucherDesc",
					Value = (headInfo.VoucherDesc ?? "")
				});
				if (headInfo.DistributerId != null)
				{
					arianSystemInsertApiRequestViewModel.Params.Add(new ArianSystemInsertApiRequestParamViewModel
					{
						Name = "DistributerId",
						Value = (headInfo.DistributerId ?? "")
					});
				}
				if (headInfo.SecondNumber != null)
				{
					arianSystemInsertApiRequestViewModel.Params.Add(new ArianSystemInsertApiRequestParamViewModel
					{
						Name = "SecondNumber",
						Value = (headInfo.SecondNumber ?? "")
					});
				}
				arianSystemInsertApiRequestViewModel.Params.Add(new ArianSystemInsertApiRequestParamViewModel
				{
					Name = "VoucherNumber",
					Value = (headInfo.VoucherNumber ?? "")
				});
				arianSystemInsertApiRequestViewModel.Params.Add(new ArianSystemInsertApiRequestParamViewModel
				{
					Name = "VoucherDate",
					Value = (headInfo.VoucherDate ?? "")
				});
				arianSystemInsertApiRequestViewModel.Params.Add(new ArianSystemInsertApiRequestParamViewModel
				{
					Name = "isrow",
					Value = headInfo.isrow.ToString()
				});
				arianSystemInsertApiRequestViewModel.Params.Add(new ArianSystemInsertApiRequestParamViewModel
				{
					Name = "VoucherDesc",
					Value = (headInfo.VoucherDesc ?? "")
				});
				arianSystemInsertApiRequestViewModel.Params.Add(new ArianSystemInsertApiRequestParamViewModel
				{
					Name = "__IsTemp__",
					Value = headInfo.__IsTemp__.ToString()
				});
				if (headInfo.Items != null && Enumerable.Any<ArianSystemSaleFactorItemsRequestViewModel>((IEnumerable<ArianSystemSaleFactorItemsRequestViewModel>)headInfo.Items))
				{
					foreach (ArianSystemSaleFactorItemsRequestViewModel item in headInfo.Items)
					{
						string[] array_Value = new string[4]
						{
							(item.RowNum ?? "") ?? "",
							(item.ServiceGoodsID ?? "") ?? "",
							(item.Quantity ?? "") ?? "",
							(item.Fee ?? "") ?? ""
						};
						arianSystemInsertApiRequestViewModel.Params.Add(new ArianSystemInsertApiRequestParamViewModel
						{
							Name = "[Inserted]",
							Array_Value = array_Value
						});
					}
				}
				StringContent content = new StringContent(JsonConvert.SerializeObject(arianSystemInsertApiRequestViewModel).Replace("\"Type\":null,", "").Replace("\"Type\":null", "")
					.Replace("\"FilterType\":null,", "")
					.Replace("\"FilterType\":null", "")
					.Replace("\"Value\":null,", "")
					.Replace("\"Value\":null", "")
					.Replace("\"Array_Value\":null,", "")
					.Replace("\"Array_Value\":null", ""), Encoding.UTF8, "application/json");
				text = ApiAddress + text;
				new HttpRequestMessage(HttpMethod.Post, text);
				HttpResponseMessage result2 = httpClient.PostAsync(text, content).Result;
				if (result2.IsSuccessStatusCode)
				{
					text2 = result2.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(text2))
					{
						text2 = text2.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(text2))
					{
						ArianSystemInsertApiResponseViewModel arianSystemInsertApiResponseViewModel = JsonConvert.DeserializeObject<ArianSystemInsertApiResponseViewModel>(text2);
						if (arianSystemInsertApiResponseViewModel != null)
						{
							linkAccId = arianSystemInsertApiResponseViewModel.Id.GetValueOrDefault();
							if (linkAccId != 0L)
							{
								isDone = true;
								ArianSystemSaleFactorResponseViewModel saleFactor = GetSaleFactor(mode, linkAccId.ToString());
								if (saleFactor != null)
								{
									linkAccVocherNumber = saleFactor.VoucherNumber.GetValueOrDefault().ToString();
								}
								linkAccNumber = linkAccVocherNumber;
							}
							else
							{
								isDone = false;
								result = arianSystemInsertApiResponseViewModel.Err ?? "";
							}
						}
						else
						{
							isDone = false;
							result = string.Format(Messages.msgErrorNoResponseReceivedWebservice, linkAccSystemTitle);
						}
					}
					else
					{
						isDone = false;
						result = string.Format(Messages.msgErrorNoResponseReceivedWebservice, linkAccSystemTitle);
					}
				}
				else
				{
					isDone = false;
					result = string.Format(Messages.msgErrorNoResponseReceivedWebservice, linkAccSystemTitle);
				}
			}
			else
			{
				isDone = false;
				result = Messages.msgErrorReceivingToken;
			}
			return result;
		}

		public string SendRPBank(ArianSystemRPBankRequestViewModel payInfo, ref bool isDone, ref long linkAccId)
		{
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Remove("autt");
			httpClient.DefaultRequestHeaders.TryAddWithoutValidation("autt", AccessToken);
			string result = "";
			string text = "api/Insert";
			string text2 = "";
			if (loginResult)
			{
				string linkAccSystemTitle = Setting.GetLinkAccSystemTitle();
				ArianSystemInsertApiRequestViewModel arianSystemInsertApiRequestViewModel = new ArianSystemInsertApiRequestViewModel();
				arianSystemInsertApiRequestViewModel.id = "RPBank";
				arianSystemInsertApiRequestViewModel.Params = new List<ArianSystemInsertApiRequestParamViewModel>();
				arianSystemInsertApiRequestViewModel.Params.Add(new ArianSystemInsertApiRequestParamViewModel
				{
					Name = "VoucherTypeId",
					Value = (payInfo.VoucherTypeId ?? "")
				});
				arianSystemInsertApiRequestViewModel.Params.Add(new ArianSystemInsertApiRequestParamViewModel
				{
					Name = "BankAccountId",
					Value = (payInfo.BankAccountId ?? "")
				});
				arianSystemInsertApiRequestViewModel.Params.Add(new ArianSystemInsertApiRequestParamViewModel
				{
					Name = "RPWayId",
					Value = (payInfo.RPWayId ?? "")
				});
				arianSystemInsertApiRequestViewModel.Params.Add(new ArianSystemInsertApiRequestParamViewModel
				{
					Name = "VoucherDesc",
					Value = (payInfo.VoucherDesc ?? "")
				});
				arianSystemInsertApiRequestViewModel.Params.Add(new ArianSystemInsertApiRequestParamViewModel
				{
					Name = "TafsiliId",
					Value = (payInfo.TafsiliId ?? "")
				});
				arianSystemInsertApiRequestViewModel.Params.Add(new ArianSystemInsertApiRequestParamViewModel
				{
					Name = "Price",
					Value = (payInfo.Price ?? "")
				});
				arianSystemInsertApiRequestViewModel.Params.Add(new ArianSystemInsertApiRequestParamViewModel
				{
					Name = "BankCurrencyDesc",
					Value = (payInfo.BankCurrencyDesc ?? "")
				});
				arianSystemInsertApiRequestViewModel.Params.Add(new ArianSystemInsertApiRequestParamViewModel
				{
					Name = "FifthId",
					Value = (payInfo.FifthId ?? "")
				});
				arianSystemInsertApiRequestViewModel.Params.Add(new ArianSystemInsertApiRequestParamViewModel
				{
					Name = "SixthId",
					Value = (payInfo.SixthId ?? "")
				});
				arianSystemInsertApiRequestViewModel.Params.Add(new ArianSystemInsertApiRequestParamViewModel
				{
					Name = "SeventhId",
					Value = (payInfo.SeventhId ?? "")
				});
				arianSystemInsertApiRequestViewModel.Params.Add(new ArianSystemInsertApiRequestParamViewModel
				{
					Name = "CurrencyPrice",
					Value = (payInfo.CurrencyPrice ?? "")
				});
				arianSystemInsertApiRequestViewModel.Params.Add(new ArianSystemInsertApiRequestParamViewModel
				{
					Name = "EightId",
					Value = (payInfo.EightId ?? "")
				});
				arianSystemInsertApiRequestViewModel.Params.Add(new ArianSystemInsertApiRequestParamViewModel
				{
					Name = "NineId",
					Value = (payInfo.NineId ?? "")
				});
				arianSystemInsertApiRequestViewModel.Params.Add(new ArianSystemInsertApiRequestParamViewModel
				{
					Name = "TenId",
					Value = (payInfo.TenId ?? "")
				});
				arianSystemInsertApiRequestViewModel.Params.Add(new ArianSystemInsertApiRequestParamViewModel
				{
					Name = "FishNumber",
					Value = (payInfo.FishNumber ?? "")
				});
				arianSystemInsertApiRequestViewModel.Params.Add(new ArianSystemInsertApiRequestParamViewModel
				{
					Name = "VoucherNumber",
					Value = (payInfo.VoucherNumber ?? "")
				});
				arianSystemInsertApiRequestViewModel.Params.Add(new ArianSystemInsertApiRequestParamViewModel
				{
					Name = "VoucherDate",
					Value = (payInfo.VoucherDate ?? "")
				});
				arianSystemInsertApiRequestViewModel.Params.Add(new ArianSystemInsertApiRequestParamViewModel
				{
					Name = "isrow",
					Value = payInfo.isrow.ToString()
				});
				arianSystemInsertApiRequestViewModel.Params.Add(new ArianSystemInsertApiRequestParamViewModel
				{
					Name = "ShowMode",
					Value = (payInfo.ShowMode ?? "")
				});
				StringContent content = new StringContent(JsonConvert.SerializeObject(arianSystemInsertApiRequestViewModel).Replace("\"Type\":null,", "").Replace("\"Type\":null", "")
					.Replace("\"FilterType\":null,", "")
					.Replace("\"FilterType\":null", "")
					.Replace("\"Value\":null,", "")
					.Replace("\"Value\":null", "")
					.Replace("\"Array_Value\":null,", "")
					.Replace("\"Array_Value\":null", ""), Encoding.UTF8, "application/json");
				text = ApiAddress + text;
				new HttpRequestMessage(HttpMethod.Post, text);
				HttpResponseMessage result2 = httpClient.PostAsync(text, content).Result;
				if (result2.IsSuccessStatusCode)
				{
					text2 = result2.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(text2))
					{
						text2 = text2.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(text2))
					{
						ArianSystemInsertApiResponseViewModel arianSystemInsertApiResponseViewModel = JsonConvert.DeserializeObject<ArianSystemInsertApiResponseViewModel>(text2);
						if (arianSystemInsertApiResponseViewModel != null)
						{
							linkAccId = arianSystemInsertApiResponseViewModel.Id.GetValueOrDefault();
							if (linkAccId != 0L)
							{
								isDone = true;
							}
							else
							{
								isDone = false;
								result = arianSystemInsertApiResponseViewModel.Err ?? "";
							}
						}
						else
						{
							isDone = false;
							result = string.Format(Messages.msgErrorNoResponseReceivedWebservice, linkAccSystemTitle);
						}
					}
					else
					{
						isDone = false;
						result = string.Format(Messages.msgErrorNoResponseReceivedWebservice, linkAccSystemTitle);
					}
				}
				else
				{
					isDone = false;
					result = string.Format(Messages.msgErrorNoResponseReceivedWebservice, linkAccSystemTitle);
				}
			}
			else
			{
				isDone = false;
				result = Messages.msgErrorReceivingToken;
			}
			return result;
		}
	}

	public class ShygunDetailedAPIProvider
	{
		public class ArianSystemSettingDetailsViewModel
		{
			public string CmpMoeinAccCode { get; set; }
		}

		public HttpClient client = new HttpClient();

		public const string _KeyName_ApiAddress = "ApiAddress";

		public const string _KeyName_ApiConnectionName = "ApiConnectionName";

		public const string _KeyName_ApiKey = "ApiKey";

		public const string _KeyName_RowStart = "RowStart";

		public const string _KeyName_RowCount = "RowCount";

		public const string _KeyName_CmpMoeinAccCode = "CmpMoeinAccCode";

		public const string _KeyName_PrdLinkedField = "PrdLinkedField";

		public const string _KeyName_WrhsSyncTypeId = "WrhsSyncTypeId";

		public const string _KeyName_PrdGroupSyncTypeId = "PrdGroupSyncTypeId";

		private static string _ApiAddress = "";

		private static string _ApiConnectionName = "";

		private static string _ApiKey = "";

		private static int _RowStart = 0;

		private static int _RowCount = 0;

		private static string _PrdLinkedField = "";

		private static int _WrhsSyncTypeId = 0;

		private static int _WrhsSyncTypeLinkAccSettingId = 0;

		private static int _PrdGroupSyncTypeId = 0;

		private static int _PrdGroupSyncTypeLinkAccSettingId = 0;

		private static List<CRMspSelectLinkAccSetting_Result> _LinkAccSetting = null;

		public bool loginResult { get; set; }

		public string ApiAddress
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_ApiAddress))
				{
					_ApiAddress = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "ApiAddress")).PartValue ?? "";
				}
				if (!string.IsNullOrWhiteSpace(_ApiAddress) && !_ApiAddress.EndsWith("/"))
				{
					_ApiAddress += "/";
				}
				return _ApiAddress;
			}
			set
			{
				_ApiAddress = "";
			}
		}

		public string ApiConnectionName
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_ApiConnectionName))
				{
					_ApiConnectionName = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "ApiConnectionName")).PartValue ?? "";
				}
				return _ApiConnectionName;
			}
			set
			{
				_ApiConnectionName = "";
			}
		}

		public string ApiKey
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_ApiKey))
				{
					_ApiKey = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "ApiKey")).PartValue ?? "";
					if (!string.IsNullOrWhiteSpace(_ApiKey))
					{
						_ApiKey = XorCipher.DecryptByMode(_ApiKey, 1);
					}
				}
				return _ApiKey;
			}
			set
			{
				_ApiKey = "";
			}
		}

		public int RowStart
		{
			get
			{
				if (_RowStart == 0)
				{
					int.TryParse(Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "RowStart")).PartValue ?? "0", out _RowStart);
				}
				return _RowStart;
			}
			set
			{
				_RowStart = 0;
			}
		}

		public int RowCount
		{
			get
			{
				if (_RowCount == 0)
				{
					int.TryParse(Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "RowCount")).PartValue ?? "0", out _RowCount);
				}
				return _RowCount;
			}
			set
			{
				_RowCount = 0;
			}
		}

		public string PrdLinkedField
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_PrdLinkedField))
				{
					_PrdLinkedField = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "PrdLinkedField")).PartValue ?? "";
				}
				return _PrdLinkedField;
			}
			set
			{
				_PrdLinkedField = "";
			}
		}

		public int WrhsSyncTypeId
		{
			get
			{
				if (_WrhsSyncTypeId == 0)
				{
					int.TryParse(Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "WrhsSyncTypeId")).PartValue ?? "0", out _WrhsSyncTypeId);
				}
				return _WrhsSyncTypeId;
			}
			set
			{
				_WrhsSyncTypeId = 0;
			}
		}

		public int WrhsSyncTypeLinkAccSettingId
		{
			get
			{
				if (_WrhsSyncTypeLinkAccSettingId == 0)
				{
					int.TryParse(Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "WrhsSyncTypeId")).LinkAccSettingId.ToString(), out _WrhsSyncTypeLinkAccSettingId);
				}
				return _WrhsSyncTypeLinkAccSettingId;
			}
			set
			{
				_WrhsSyncTypeLinkAccSettingId = 0;
			}
		}

		public int PrdGroupSyncTypeId
		{
			get
			{
				if (_PrdGroupSyncTypeId == 0)
				{
					int.TryParse(Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "PrdGroupSyncTypeId")).PartValue ?? "0", out _PrdGroupSyncTypeId);
				}
				return _PrdGroupSyncTypeId;
			}
			set
			{
				_PrdGroupSyncTypeId = 0;
			}
		}

		public int PrdGroupSyncTypeLinkAccSettingId
		{
			get
			{
				if (_PrdGroupSyncTypeLinkAccSettingId == 0)
				{
					int.TryParse(Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "PrdGroupSyncTypeId")).LinkAccSettingId.ToString(), out _PrdGroupSyncTypeLinkAccSettingId);
				}
				return _PrdGroupSyncTypeLinkAccSettingId;
			}
			set
			{
				_PrdGroupSyncTypeLinkAccSettingId = 0;
			}
		}

		public void ClearFields()
		{
			ApiAddress = "";
			ApiConnectionName = "";
			ApiKey = "";
			RowStart = 0;
			RowCount = 0;
			PrdLinkedField = "";
			WrhsSyncTypeId = 0;
			WrhsSyncTypeLinkAccSettingId = 0;
			PrdGroupSyncTypeId = 0;
			PrdGroupSyncTypeLinkAccSettingId = 0;
		}

		public List<CRMspSelectLinkAccSetting_Result> GetLinkAccSetting(bool? readAgain = false)
		{
			if (!readAgain.GetValueOrDefault() && _LinkAccSetting != null)
			{
				return _LinkAccSetting;
			}
			List<CRMspSelectLinkAccSetting_Result> list = new List<CRMspSelectLinkAccSetting_Result>();
			CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
			try
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				int value = 26;
				int value2 = -1;
				list = Enumerable.ToList<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)cRMLinkSpEntities.CRMspSelectLinkAccSetting(0, "", lCID, result, value, value2, null));
				if (list == null)
				{
					list = new List<CRMspSelectLinkAccSetting_Result>();
				}
			}
			catch (Exception ex)
			{
				Public.InsExceptToElmah(ex);
			}
			cRMLinkSpEntities.Dispose();
			return list;
		}

		public ArianSystemSettingDetailsViewModel GetSettingDetails(int settingDetailId = 0, int objId = 0, string objectType = "")
		{
			ArianSystemSettingDetailsViewModel arianSystemSettingDetailsViewModel = new ArianSystemSettingDetailsViewModel();
			CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
			try
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				int value = 26;
				int value2 = -1;
				if (settingDetailId < 0)
				{
					settingDetailId = 0;
				}
				List<CRMspSelectLinkAccSettingDetails_Result> list = Enumerable.ToList<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)cRMLinkSpEntities.CRMspSelectLinkAccSettingDetails(settingDetailId, objId, objectType, lCID, result, value, value2));
				if (list != null && Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "CmpMoeinAccCode")) != null)
				{
					string partValue = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "CmpMoeinAccCode")).PartValue;
					arianSystemSettingDetailsViewModel.CmpMoeinAccCode = ((!string.IsNullOrWhiteSpace(partValue)) ? partValue : "");
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
			finally
			{
				cRMLinkSpEntities.Dispose();
			}
			return arianSystemSettingDetailsViewModel;
		}

		public ShygunDetailedAPIProvider(bool isUpdateList = false, bool isLogin = true)
		{
			_LinkAccSetting = GetLinkAccSetting(true);
			ClearFields();
			try
			{
				client.BaseAddress = new Uri(ApiAddress);
				if (isLogin && !string.IsNullOrWhiteSpace(ApiKey))
				{
					loginResult = true;
				}
			}
			catch (Exception)
			{
				Public.InsTextToElmah("خطا در ارتباط با سیستم حسابداری، لطفا تنظیمات حسابداری را بررسی کنید.");
			}
		}

		private ShygunDetailedAPIConfigViewModel CreateConnectionConfig()
		{
			ShygunDetailedAPIConfigViewModel result = new ShygunDetailedAPIConfigViewModel();
			if (!string.IsNullOrWhiteSpace(ApiKey) && !string.IsNullOrWhiteSpace(ApiConnectionName))
			{
				result = new ShygunDetailedAPIConfigViewModel
				{
					ConnectionName = ApiConnectionName
				};
			}
			return result;
		}

		public List<ShygunDetailedAPIWarehouseInfoViewModel> GetWarehouseList()
		{
			List<ShygunDetailedAPIWarehouseInfoViewModel> list = new List<ShygunDetailedAPIWarehouseInfoViewModel>();
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Remove("api-key");
			httpClient.DefaultRequestHeaders.TryAddWithoutValidation("api-key", _ApiKey);
			string text = "api/Stock/Get";
			string text2 = "";
			if (loginResult)
			{
				int num = RowStart;
				int num2 = RowCount;
				if (num2 == 0)
				{
					num2 = 100;
				}
				bool flag = true;
				int num3 = 0;
				while (flag)
				{
					if (num3 > 0)
					{
						num = num2 * num3;
					}
					StringContent content = new StringContent(JsonConvert.SerializeObject(new ShygunDetailedAPIRequestViewModel<string>
					{
						Config = CreateConnectionConfig()
					}).Replace(",\"Domain\":null", "").Replace("\"Domain\":null,", "")
						.Replace("\"Domain\":null", ""), Encoding.UTF8, "application/json");
					string text3 = text + "?RowStart=" + num + "&RowCount=" + num2;
					text3 = ApiAddress + text3;
					new HttpRequestMessage(HttpMethod.Post, text3);
					HttpResponseMessage result = httpClient.PostAsync(text3, content).Result;
					if (result.IsSuccessStatusCode)
					{
						text2 = result.Content.ReadAsStringAsync().Result;
						if (!string.IsNullOrWhiteSpace(text2))
						{
							text2 = text2.ClearHiddenCharacters();
						}
						if (!string.IsNullOrWhiteSpace(text2))
						{
							ShygunDetailedAPIWarehouseResponseViewModel shygunDetailedAPIWarehouseResponseViewModel = JsonConvert.DeserializeObject<ShygunDetailedAPIWarehouseResponseViewModel>(text2);
							if (shygunDetailedAPIWarehouseResponseViewModel != null)
							{
								if (shygunDetailedAPIWarehouseResponseViewModel.Result != null)
								{
									if (Enumerable.Any<ShygunDetailedAPIWarehouseInfoViewModel>((IEnumerable<ShygunDetailedAPIWarehouseInfoViewModel>)shygunDetailedAPIWarehouseResponseViewModel.Result))
									{
										list.AddRange(shygunDetailedAPIWarehouseResponseViewModel.Result);
									}
									else
									{
										flag = false;
									}
								}
								else
								{
									flag = false;
								}
							}
						}
					}
					else
					{
						flag = false;
					}
					num3++;
				}
				if (list == null)
				{
					list = new List<ShygunDetailedAPIWarehouseInfoViewModel>();
				}
			}
			return list;
		}

		public string SendCompany(ShygunDetailedAPIAccountRequestDefineInfoViewModel cmpInfo, ref bool isDone, ref string customerId, ref string customerCode, ref string cmpLinkAccData)
		{
			new List<ShygunDetailedAPIAccountInfoViewModel>();
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Remove("api-key");
			httpClient.DefaultRequestHeaders.TryAddWithoutValidation("api-key", _ApiKey);
			string text = "api/Account/Put";
			string result = "";
			string text2 = "";
			if (loginResult)
			{
				string linkAccSystemTitle = Setting.GetLinkAccSystemTitle();
				ShygunDetailedAPIPuRequestViewModel<List<ShygunDetailedAPIAccountRequestDefineInfoViewModel>> shygunDetailedAPIPuRequestViewModel = new ShygunDetailedAPIPuRequestViewModel<List<ShygunDetailedAPIAccountRequestDefineInfoViewModel>>();
				shygunDetailedAPIPuRequestViewModel.Config = CreateConnectionConfig();
				shygunDetailedAPIPuRequestViewModel.PutObject = new List<ShygunDetailedAPIAccountRequestDefineInfoViewModel>();
				shygunDetailedAPIPuRequestViewModel.PutObject.Add(cmpInfo);
				StringContent content = new StringContent(JsonConvert.SerializeObject(shygunDetailedAPIPuRequestViewModel).Replace(",\"GuId\":null", "").Replace("\"GuId\":null,", "")
					.Replace("\"GuId\":null", ""), Encoding.UTF8, "application/json");
				text = ApiAddress + text;
				new HttpRequestMessage(HttpMethod.Post, text);
				HttpResponseMessage result2 = httpClient.PostAsync(text, content).Result;
				if (result2.IsSuccessStatusCode)
				{
					text2 = result2.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(text2))
					{
						text2 = text2.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(text2))
					{
						ShygunDetailedAPIAccountDefineResponseViewModel shygunDetailedAPIAccountDefineResponseViewModel = JsonConvert.DeserializeObject<ShygunDetailedAPIAccountDefineResponseViewModel>(text2);
						if (shygunDetailedAPIAccountDefineResponseViewModel != null)
						{
							if (!string.IsNullOrWhiteSpace(shygunDetailedAPIAccountDefineResponseViewModel.ErrorMessage))
							{
								result = shygunDetailedAPIAccountDefineResponseViewModel.ErrorMessage ?? "";
								isDone = false;
							}
							else if (shygunDetailedAPIAccountDefineResponseViewModel.Result != null && Enumerable.Any<ShygunDetailedAPIAccountDefineInfoResponseViewModel>((IEnumerable<ShygunDetailedAPIAccountDefineInfoResponseViewModel>)shygunDetailedAPIAccountDefineResponseViewModel.Result))
							{
								customerId = shygunDetailedAPIAccountDefineResponseViewModel.Result[0].GuId ?? "";
								if (!string.IsNullOrWhiteSpace(customerId))
								{
									isDone = true;
									string id = customerId;
									customerCode = shygunDetailedAPIAccountDefineResponseViewModel.Result[0].Number ?? "";
									if (string.IsNullOrWhiteSpace(customerCode))
									{
										customerCode = customerId;
									}
									DateTime value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
									LinkAccDataByExtraFieldsViewModel value2 = new LinkAccDataByExtraFieldsViewModel
									{
										CId = 0,
										DBId = -1,
										Code = customerCode,
										Id = id,
										FTDate = value,
										LTDate = value,
										LACId = "0",
										ExtraI = "",
										ExtraII = "",
										ExtraIII = ""
									};
									cmpLinkAccData = "[" + JsonConvert.SerializeObject(value2) + "]";
								}
							}
						}
						else
						{
							isDone = false;
							result = string.Format(Messages.msgErrorNoResponseReceivedWebservice, linkAccSystemTitle);
						}
					}
					else
					{
						isDone = false;
						result = string.Format(Messages.msgErrorNoResponseReceivedWebservice, linkAccSystemTitle);
					}
				}
				else
				{
					isDone = false;
					result = string.Format(Messages.msgErrorNoResponseReceivedWebservice, linkAccSystemTitle);
				}
			}
			else
			{
				isDone = false;
				result = Messages.msgErrorReceivingToken;
			}
			return result;
		}

		public List<ShygunDetailedAPIAccountInfoViewModel> GetCustomerList(int fromRec = 0, int recCount = 0, string fromLinkAccCmpCode = "", string toLinkAccCmpCode = "", string linkAccIdStr = "")
		{
			List<ShygunDetailedAPIAccountInfoViewModel> list = new List<ShygunDetailedAPIAccountInfoViewModel>();
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Remove("api-key");
			httpClient.DefaultRequestHeaders.TryAddWithoutValidation("api-key", _ApiKey);
			string text = "api/Account/Get";
			string text2 = "";
			if (loginResult)
			{
				int num = RowStart;
				int num2 = RowCount;
				if (fromRec > 0)
				{
					num = fromRec;
				}
				if (recCount >= 100)
				{
					num2 = recCount;
				}
				if (num2 == 0)
				{
					num2 = 100;
				}
				ShygunDetailedAPIRequestViewModel<DomainAccount> shygunDetailedAPIRequestViewModel = new ShygunDetailedAPIRequestViewModel<DomainAccount>();
				shygunDetailedAPIRequestViewModel.Config = CreateConnectionConfig();
				shygunDetailedAPIRequestViewModel.Domain = new DomainAccount();
				shygunDetailedAPIRequestViewModel.Domain.AccountNumber.From = fromLinkAccCmpCode;
				shygunDetailedAPIRequestViewModel.Domain.AccountNumber.To = toLinkAccCmpCode;
				StringContent content = new StringContent(JsonConvert.SerializeObject(shygunDetailedAPIRequestViewModel).Replace(",\"Domain\":null", "").Replace("\"Domain\":null,", "")
					.Replace("\"Domain\":null", ""), Encoding.UTF8, "application/json");
				text = text + "?RowStart=" + num + "&RowCount=" + num2;
				text = ApiAddress + text;
				new HttpRequestMessage(HttpMethod.Post, text);
				HttpResponseMessage result = httpClient.PostAsync(text, content).Result;
				if (result.IsSuccessStatusCode)
				{
					text2 = result.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(text2))
					{
						text2 = text2.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(text2))
					{
						ShygunDetailedAPIAccountResponseViewModel shygunDetailedAPIAccountResponseViewModel = JsonConvert.DeserializeObject<ShygunDetailedAPIAccountResponseViewModel>(text2);
						if (shygunDetailedAPIAccountResponseViewModel != null && shygunDetailedAPIAccountResponseViewModel.Result != null && Enumerable.Any<ShygunDetailedAPIAccountInfoViewModel>((IEnumerable<ShygunDetailedAPIAccountInfoViewModel>)shygunDetailedAPIAccountResponseViewModel.Result))
						{
							list.AddRange(shygunDetailedAPIAccountResponseViewModel.Result);
						}
					}
				}
				if (list == null)
				{
					list = new List<ShygunDetailedAPIAccountInfoViewModel>();
				}
			}
			return list;
		}

		public decimal GetCustomerClosingBalance(string cmpId, ref decimal linkAccDebitBalance, ref decimal linkAccCreditBalance)
		{
			decimal result = default(decimal);
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Remove("api-key");
			httpClient.DefaultRequestHeaders.TryAddWithoutValidation("api-key", _ApiKey);
			string text = "api/StatementDetail/GetClosingBalance";
			string text2 = "";
			if (loginResult)
			{
				int rowStart = RowStart;
				int num = RowCount;
				if (num == 0)
				{
					num = 100;
				}
				ShygunDetailedAPIRequestViewModel<DomainStatementDetail> shygunDetailedAPIRequestViewModel = new ShygunDetailedAPIRequestViewModel<DomainStatementDetail>();
				shygunDetailedAPIRequestViewModel.Config = CreateConnectionConfig();
				shygunDetailedAPIRequestViewModel.Domain = new DomainStatementDetail();
				shygunDetailedAPIRequestViewModel.Domain.AccountGuId.From = cmpId;
				shygunDetailedAPIRequestViewModel.Domain.AccountGuId.To = cmpId;
				string from = DateTime.Now.ToString("yyyy-MM-dd", new CultureInfo("en-US"));
				shygunDetailedAPIRequestViewModel.Domain.Date.From = from;
				StringContent content = new StringContent(JsonConvert.SerializeObject(shygunDetailedAPIRequestViewModel).Replace(",\"Domain\":null", "").Replace("\"Domain\":null,", "")
					.Replace("\"Domain\":null", ""), Encoding.UTF8, "application/json");
				text = text + "?RowStart=" + rowStart + "&RowCount=" + num;
				text = ApiAddress + text;
				new HttpRequestMessage(HttpMethod.Post, text);
				HttpResponseMessage result2 = httpClient.PostAsync(text, content).Result;
				if (result2.IsSuccessStatusCode)
				{
					text2 = result2.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(text2))
					{
						text2 = text2.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(text2))
					{
						ShygunDetailedAPIAccountClosingBalanceResponseViewModel shygunDetailedAPIAccountClosingBalanceResponseViewModel = JsonConvert.DeserializeObject<ShygunDetailedAPIAccountClosingBalanceResponseViewModel>(text2);
						if (shygunDetailedAPIAccountClosingBalanceResponseViewModel != null && shygunDetailedAPIAccountClosingBalanceResponseViewModel.Result != null && Enumerable.Any<ShygunDetailedAPIAccountClosingBalanceInfoViewModel>((IEnumerable<ShygunDetailedAPIAccountClosingBalanceInfoViewModel>)shygunDetailedAPIAccountClosingBalanceResponseViewModel.Result))
						{
							ShygunDetailedAPIAccountClosingBalanceInfoViewModel shygunDetailedAPIAccountClosingBalanceInfoViewModel = shygunDetailedAPIAccountClosingBalanceResponseViewModel.Result[0];
							if (shygunDetailedAPIAccountClosingBalanceInfoViewModel != null)
							{
								decimal result3 = default(decimal);
								decimal.TryParse(shygunDetailedAPIAccountClosingBalanceInfoViewModel.AmountDebit.ToString(), out result3);
								decimal result4 = default(decimal);
								decimal.TryParse(shygunDetailedAPIAccountClosingBalanceInfoViewModel.AmountCredit.ToString(), out result4);
								linkAccDebitBalance = result3;
								linkAccCreditBalance = result4;
								return result4 - result3;
							}
						}
					}
				}
			}
			return result;
		}

		public List<ShygunDetailedAPIItemGroupInfoViewModel> GetItemGroupList()
		{
			List<ShygunDetailedAPIItemGroupInfoViewModel> list = new List<ShygunDetailedAPIItemGroupInfoViewModel>();
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Remove("api-key");
			httpClient.DefaultRequestHeaders.TryAddWithoutValidation("api-key", _ApiKey);
			string text = "api/ItemGroup/GetList";
			string text2 = "";
			if (loginResult)
			{
				int num = RowStart;
				int num2 = RowCount;
				if (num2 == 0)
				{
					num2 = 100;
				}
				bool flag = true;
				int num3 = 0;
				while (flag)
				{
					if (num3 > 0)
					{
						num = num2 * num3;
					}
					StringContent content = new StringContent(JsonConvert.SerializeObject(new ShygunDetailedAPIRequestViewModel<string>
					{
						Config = CreateConnectionConfig()
					}).Replace(",\"Domain\":null", "").Replace("\"Domain\":null,", "")
						.Replace("\"Domain\":null", ""), Encoding.UTF8, "application/json");
					string text3 = text + "?RowStart=" + num + "&RowCount=" + num2;
					text3 = ApiAddress + text3;
					new HttpRequestMessage(HttpMethod.Post, text3);
					HttpResponseMessage result = httpClient.PostAsync(text3, content).Result;
					if (result.IsSuccessStatusCode)
					{
						text2 = result.Content.ReadAsStringAsync().Result;
						if (!string.IsNullOrWhiteSpace(text2))
						{
							text2 = text2.ClearHiddenCharacters();
						}
						if (!string.IsNullOrWhiteSpace(text2))
						{
							ShygunDetailedAPIItemGroupResponseViewModel shygunDetailedAPIItemGroupResponseViewModel = JsonConvert.DeserializeObject<ShygunDetailedAPIItemGroupResponseViewModel>(text2);
							if (shygunDetailedAPIItemGroupResponseViewModel != null)
							{
								if (shygunDetailedAPIItemGroupResponseViewModel.Result != null)
								{
									if (Enumerable.Any<ShygunDetailedAPIItemGroupInfoViewModel>((IEnumerable<ShygunDetailedAPIItemGroupInfoViewModel>)shygunDetailedAPIItemGroupResponseViewModel.Result))
									{
										list.AddRange(shygunDetailedAPIItemGroupResponseViewModel.Result);
									}
									else
									{
										flag = false;
									}
								}
								else
								{
									flag = false;
								}
							}
						}
					}
					else
					{
						flag = false;
					}
					num3++;
				}
				if (list == null)
				{
					list = new List<ShygunDetailedAPIItemGroupInfoViewModel>();
				}
			}
			return list;
		}

		public List<ShygunDetailedAPIItemGroupInfoViewModel> GetItemList()
		{
			List<ShygunDetailedAPIItemGroupInfoViewModel> result = new List<ShygunDetailedAPIItemGroupInfoViewModel>();
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Remove("api-key");
			httpClient.DefaultRequestHeaders.TryAddWithoutValidation("api-key", _ApiKey);
			return result;
		}
	}

	public class KaramadProvider
	{
		public class Company
		{
			private int _LastCId;

			private int _CompanyId;

			private string _CompanyNationalCode = "";

			public Company(int cmpId = 0)
			{
				_CompanyId = cmpId;
				if (UserLogin.CurrentUser != null)
				{
					int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out _LastCId);
				}
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				CRMSpEntities cRMSpEntities = new CRMSpEntities();
				CRMspSelectCompanyById_Result cRMspSelectCompanyById_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyById_Result>((IEnumerable<CRMspSelectCompanyById_Result>)cRMSpEntities.CRMspSelectCompanyById(_CompanyId, lCID, result, _LastCId));
				if (cRMspSelectCompanyById_Result == null)
				{
					return;
				}
				if (cRMspSelectCompanyById_Result.cmpKind == 0)
				{
					_CompanyNationalCode = cRMspSelectCompanyById_Result.cmpNationalCode ?? "";
				}
				else
				{
					if (cRMspSelectCompanyById_Result.cmpKind.GetValueOrDefault() != 1)
					{
						return;
					}
					int valueOrDefault = cRMspSelectCompanyById_Result.cmpMainPersonId.GetValueOrDefault();
					if (valueOrDefault != 0)
					{
						CRMspSelectCompanyPersonsByID_Result cRMspSelectCompanyPersonsByID_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyPersonsByID_Result>((IEnumerable<CRMspSelectCompanyPersonsByID_Result>)cRMSpEntities.CRMspSelectCompanyPersonsByID(valueOrDefault, lCID, result));
						if (cRMspSelectCompanyPersonsByID_Result != null)
						{
							_CompanyNationalCode = cRMspSelectCompanyPersonsByID_Result.prsNationalCode ?? "";
						}
					}
				}
			}

			public List<KaramadCompanyResultViewModel> GetInfoJson()
			{
				List<KaramadCompanyResultViewModel> result = new List<KaramadCompanyResultViewModel>();
				try
				{
					string result2 = new HttpClient().SendAsync(new HttpRequestMessage(HttpMethod.Get, new KaramadProvider().GetCrmSettings.ApiBaseUrl + "GetInfo?nationalCode=" + _CompanyNationalCode)
					{
						Headers = { 
						{
							"Authorization",
							new KaramadProvider().GetToken()
						} }
					}).Result.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(result2))
					{
						List<KaramadCompanyResultViewModel> list = JsonConvert.DeserializeObject<List<KaramadCompanyResultViewModel>>(result2);
						if (list != null)
						{
							result = list;
						}
					}
				}
				catch (Exception ex)
				{
					Public.InsExceptToElmah(ex);
				}
				return result;
			}

			public string GetInfoHtmlUrl()
			{
				string result = "";
				try
				{
					result = new HttpClient().SendAsync(new HttpRequestMessage(HttpMethod.Get, new KaramadProvider().GetCrmSettings.ApiBaseUrl + "GetInfoContent?nationalCode=" + _CompanyNationalCode)
					{
						Headers = { 
						{
							"Authorization",
							new KaramadProvider().GetToken()
						} }
					}).Result.Content.ReadAsStringAsync().Result;
				}
				catch (Exception ex)
				{
					Public.InsExceptToElmah(ex);
				}
				return result;
			}
		}

		public const string _TypeName = "KaramadSSO";

		public const int LinkAccSystemId = 24;

		private static string _Access_Token = "";

		private static string _Refresh_Token = "";

		private static bool? _IsActive = null;

		private static string _BaseUrl = "";

		private static string _ClientId = "";

		private static string _ClientSecret = "";

		private static string _RedirectCallBack = "";

		private static string _RedirectLogout = "";

		public static string LoginURL = "/OtherSystemsLogin/KaramadLogin";

		private KaramadSettingsViewModel _GetCrmSettings;

		public static bool IsActive
		{
			get
			{
				if (!_IsActive.HasValue)
				{
					SetKaramadSysSettings();
				}
				return _IsActive.GetValueOrDefault();
			}
			set
			{
				_IsActive = value;
			}
		}

		public static string BaseUrl
		{
			get
			{
				if (string.IsNullOrEmpty(_BaseUrl))
				{
					SetKaramadSysSettings();
				}
				return _BaseUrl;
			}
			set
			{
				_BaseUrl = value;
			}
		}

		public static string ClientId
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_ClientId))
				{
					SetKaramadSysSettings();
				}
				return _ClientId;
			}
			set
			{
				_ClientId = value;
			}
		}

		public static string ClientSecret
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_ClientSecret))
				{
					SetKaramadSysSettings();
				}
				return _ClientSecret;
			}
			set
			{
				_ClientSecret = value;
			}
		}

		public static string RedirectCallBack
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_RedirectCallBack))
				{
					SetKaramadSysSettings();
				}
				return _RedirectCallBack;
			}
			set
			{
				_RedirectCallBack = value;
			}
		}

		public static string RedirectLogout
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_RedirectLogout))
				{
					SetKaramadSysSettings();
				}
				return _RedirectLogout;
			}
			set
			{
				_RedirectLogout = value;
			}
		}

		public KaramadSettingsViewModel GetCrmSettings
		{
			get
			{
				if (_GetCrmSettings == null)
				{
					CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
					try
					{
						int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
						if (result <= 0)
						{
							result = 1065;
						}
						int lCID = Thread.CurrentThread.CurrentCulture.LCID;
						int value = -1;
						List<CRMspSelectLinkAccSetting_Result> list = Enumerable.ToList<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)cRMLinkSpEntities.CRMspSelectLinkAccSetting(0, "", lCID, result, 24, value, null));
						if (list != null)
						{
							_GetCrmSettings = new KaramadSettingsViewModel();
							for (int i = 0; i < list.Count; i++)
							{
								if (list[i].PartTitle == "ApiTokenUrl")
								{
									_GetCrmSettings.ApiTokenUrl = list[i].PartValue;
								}
								if (list[i].PartTitle == "ApiUsername")
								{
									_GetCrmSettings.ApiUsername = list[i].PartValue;
								}
								if (list[i].PartTitle == "ApiPassword")
								{
									_GetCrmSettings.ApiPassword = list[i].PartValue;
								}
								if (list[i].PartTitle == "ApiGrantType")
								{
									_GetCrmSettings.ApiGrantType = list[i].PartValue;
								}
								if (list[i].PartTitle == "ApiClientId")
								{
									_GetCrmSettings.ApiClientId = list[i].PartValue;
								}
								if (list[i].PartTitle == "ApiClientSecret")
								{
									_GetCrmSettings.ApiClientSecret = list[i].PartValue;
								}
								if (list[i].PartTitle == "ApiBaseUrl")
								{
									_GetCrmSettings.ApiBaseUrl = list[i].PartValue;
									if (!_GetCrmSettings.ApiBaseUrl.EndsWith("/"))
									{
										_GetCrmSettings.ApiBaseUrl += "/";
									}
								}
							}
						}
					}
					catch (Exception ex)
					{
						Public.InsExceptToElmah(ex);
					}
					finally
					{
						cRMLinkSpEntities?.Dispose();
					}
				}
				return _GetCrmSettings;
			}
		}

		private static void SetKaramadSysSettings()
		{
			CRMSpEntities cRMSpEntities = new CRMSpEntities();
			try
			{
				CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<CRMspSelectCrmsysSetting_Result>((IEnumerable<CRMspSelectCrmsysSetting_Result>)cRMSpEntities.CRMspSelectCrmsysSetting(1065, 1065));
				if (cRMspSelectCrmsysSetting_Result == null)
				{
					return;
				}
				if (!string.IsNullOrWhiteSpace(cRMspSelectCrmsysSetting_Result.LoginAuthTypes))
				{
					string[] array = cRMspSelectCrmsysSetting_Result.LoginAuthTypes.Split(new char[1] { ',' });
					if (array.Length != 0)
					{
						IsActive = Enumerable.Contains<string>((IEnumerable<string>)array, 3.ToString());
					}
				}
				if (!string.IsNullOrWhiteSpace(cRMspSelectCrmsysSetting_Result.LoginAuthTypesInfoJson))
				{
					List<OtherSystemsLoginJsonViewModel> list = JsonConvert.DeserializeObject<List<OtherSystemsLoginJsonViewModel>>(cRMspSelectCrmsysSetting_Result.LoginAuthTypesInfoJson);
					if (list != null && list.Count > 0)
					{
						for (int i = 0; i < list.Count; i++)
						{
							if (list[i].Type == 3.ToString())
							{
								string text = list[i].Text;
								string value = list[i].Value;
								switch (text)
								{
								case "BaseURL":
									BaseUrl = value;
									break;
								case "ClientId":
									ClientId = value;
									break;
								case "ClientSecret":
									ClientSecret = value;
									break;
								}
							}
						}
					}
				}
				string text2 = cRMspSelectCrmsysSetting_Result.CrmIPStatic ?? "";
				if (!text2.EndsWith("/"))
				{
					text2 += "/";
				}
				RedirectLogout = text2 + "OtherSystemsLogin/KaramadLogout";
				RedirectCallBack = text2 + "OtherSystemsLogin/KaramadLoginCallback";
			}
			catch (Exception ex)
			{
				Public.InsExceptToElmah(ex);
			}
			finally
			{
				cRMSpEntities?.Dispose();
			}
		}

		public string GetToken()
		{
			_Access_Token = "";
			try
			{
				RestClient restClient = new RestClient(GetCrmSettings.ApiTokenUrl);
				RestRequest restRequest = new RestRequest(Method.POST);
				restRequest.AddHeader("cache-control", "no-cache");
				restRequest.AddHeader("Connection", "keep-alive");
				restRequest.AddHeader("Content-Length", "135");
				restRequest.AddHeader("Accept-Encoding", "gzip, deflate");
				restRequest.AddHeader("Cache-Control", "no-cache");
				restRequest.AddHeader("Accept", "*/*");
				restRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
				restRequest.AddParameter("undefined", "grant_type=" + GetCrmSettings.ApiGrantType + "&username=" + GetCrmSettings.ApiUsername + "&password=" + GetCrmSettings.ApiPassword + "&client_id=" + GetCrmSettings.ApiClientId + "&client_secret=" + GetCrmSettings.ApiClientSecret, ParameterType.RequestBody);
				string text = restClient.Execute(restRequest).Content;
				if (!string.IsNullOrWhiteSpace(text))
				{
					text = text.ClearHiddenCharacters();
				}
				if (!string.IsNullOrWhiteSpace(text))
				{
					KaramadTokenResponseViewModel karamadTokenResponseViewModel = JsonConvert.DeserializeObject<KaramadTokenResponseViewModel>(text);
					if (karamadTokenResponseViewModel != null)
					{
						if (!string.IsNullOrWhiteSpace(karamadTokenResponseViewModel.error))
						{
							Public.InsTextToElmah("Error Taking Karamad Token: " + text);
						}
						else
						{
							_Access_Token = karamadTokenResponseViewModel.access_token ?? "";
							_Refresh_Token = karamadTokenResponseViewModel.refresh_token ?? "";
							if (!string.IsNullOrWhiteSpace(_Access_Token))
							{
								_Access_Token = "Bearer " + _Access_Token;
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				Public.InsExceptToElmah(ex);
			}
			return _Access_Token;
		}
	}

	public class HolooProvider
	{
		public class HolooSettingDetailsViewModel
		{
			public string CashAccCode { get; set; }

			public int? PrdInvStockDisplayType { get; set; }

			public int? TaxCalculateType { get; set; }

			public int? TaxPercent { get; set; }

			public int? DutyPercent { get; set; }

			public bool? AllowDuplicateEco { get; set; }

			public bool? AllowDuplicateNatCode { get; set; }

			public bool? AllowDuplicateMobile { get; set; }

			public bool? SendTaxAndDutyPercentToApi { get; set; }

			public int? CmpMnBgRate { get; set; }

			public int? CmpMnBgExpireDay { get; set; }

			public bool? SendPrdUnitToApi { get; set; }

			public bool? DoneActionsAfterOrdVerify { get; set; }

			public int? OrderTimeOut { get; set; }

			public int? ProductTimeOut { get; set; }

			public int? CompanyTimeOut { get; set; }
		}

		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass131_0
		{
			public CRMspLkHolooWSSelectOrderByOrdIds_Result ord;
		}

		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass135_0
		{
			public CRMspLkHolooWSSelectOrderByOrdIds_Result ord;
		}

		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass144_0
		{
			public int companyId;
		}

		public HttpClient client = new HttpClient();

		private readonly CRMLinkSpEntities _dbLink = new CRMLinkSpEntities();

		private readonly CRMSpEntities _db = new CRMSpEntities();

		private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

		private string _AccessToken = "";

		public const string _KeyName_Address = "ApiAddress";

		public const string _KeyName_Username = "UserName";

		public const string _KeyName_Password = "Password";

		public const string _KeyName_CashAccCode = "CashAccCode";

		public const string _KeyName_PrdInvStockDisplayType = "PrdInvStockDisplayType";

		public const string _KeyName_TaxCalculateType = "TaxCalculateType";

		public const string _KeyName_TaxPercent = "TaxPercent";

		public const string _KeyName_DutyPercent = "DutyPercent";

		public const string _KeyName_AllowDuplicateEco = "AllowDuplicateEco";

		public const string _KeyName_AllowDuplicateNatCode = "AllowDuplicateNatCode";

		public const string _KeyName_AllowDuplicateMobile = "AllowDuplicateMobile";

		public const string _KeyName_SendTaxAndDutyPercentToApi = "SendTaxAndDutyPercentToApi";

		public const string _KeyName_CmpMnBgRate = "CmpMnBgRate";

		public const string _KeyName_CmpMnBgExpireDay = "CmpMnBgExpireDay";

		public const string _KeyName_SendPrdUnitToApi = "SendPrdUnitToApi";

		public const string _KeyName_DoneActionsAfterOrdVerify = "DoneActionsAfterOrdVerify";

		public const string _KeyName_OrderTimeOut = "OrderTimeOut";

		public const string _KeyName_PreOrderTimeOut = "PreOrderTimeOut";

		public const string _KeyName_ProductTimeOut = "ProductTimeOut";

		public const string _KeyName_CompanyTimeOut = "CompanyTimeOut";

		public const string _KeyName_CmpLinkedField = "_CmpLinkedField";

		private string _Token = "";

		private string _ApiAddress = "";

		private string _ApiUsername = "";

		private string _ApiPassword = "";

		private string _CashAccCode = "";

		private int? _PrdInvStockDisplayType;

		private int? _TaxCalculateType;

		private int? _TaxPercent;

		private int? _DutyPercent;

		private bool? _AllowDuplicateEco;

		private bool? _AllowDuplicateNatCode;

		private bool? _AllowDuplicateMobile;

		private bool? _SendTaxAndDutyPercentToApi;

		private int? _CmpMnBgRate;

		private int? _CmpMnBgExpireDay;

		private bool? _SendPrdUnitToApi;

		private bool? _DoneActionsAfterOrdVerify;

		private int _OrderTimeOut;

		private int _PreOrderTimeOut;

		private int _CompanyTimeOut;

		private int _ProductTimeOut;

		private int _CmpLinkedField;

		private List<CRMspSelectLinkAccSetting_Result> _LinkAccSetting;

		private List<CRMspSelectLinkAccSetting_Result> _LinkAccOrderSetting;

		private List<CRMspSelectLinkAccSetting_Result> _LinkAccPreOrderSetting;

		private CRMspSelectLinkAccSettingDB_Result _LinkAccSettingDB;

		public bool loginResult { get; set; }

		public string AccessToken
		{
			get
			{
				return _AccessToken;
			}
			set
			{
				_AccessToken = value;
			}
		}

		public string Token => _Token;

		public string ApiAddress
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_ApiAddress))
				{
					_ApiAddress = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "ApiAddress"))?.PartValue ?? "";
				}
				if (!string.IsNullOrWhiteSpace(_ApiAddress) && !_ApiAddress.EndsWith("/"))
				{
					_ApiAddress += "/";
				}
				return _ApiAddress;
			}
			set
			{
				_ApiAddress = "";
			}
		}

		public string ApiUsername
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_ApiUsername))
				{
					_ApiUsername = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "UserName"))?.PartValue ?? "";
				}
				return _ApiUsername;
			}
			set
			{
				_ApiUsername = "";
			}
		}

		public string ApiPassword
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_ApiPassword))
				{
					_ApiPassword = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "Password"))?.PartValue ?? "";
				}
				return _ApiPassword;
			}
			set
			{
				_ApiPassword = "";
			}
		}

		public string CashAccCode
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_CashAccCode))
				{
					_CashAccCode = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "CashAccCode"))?.PartValue ?? "";
				}
				return _CashAccCode;
			}
			set
			{
				_CashAccCode = "";
			}
		}

		public int PrdInvStockDisplayType
		{
			get
			{
				if (_PrdInvStockDisplayType.GetValueOrDefault() == 0)
				{
					_PrdInvStockDisplayType = int.Parse(Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "PrdInvStockDisplayType"))?.PartValue ?? "0");
				}
				return _PrdInvStockDisplayType.Value;
			}
			set
			{
				_PrdInvStockDisplayType = 0;
			}
		}

		public int TaxCalculateType
		{
			get
			{
				if (_TaxCalculateType.GetValueOrDefault() == 0)
				{
					_TaxCalculateType = int.Parse(Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "TaxCalculateType"))?.PartValue ?? "0");
				}
				return _TaxCalculateType.Value;
			}
			set
			{
				_TaxCalculateType = 0;
			}
		}

		public int TaxPercent
		{
			get
			{
				if (_TaxPercent.GetValueOrDefault() == 0)
				{
					_TaxPercent = int.Parse(Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "TaxPercent"))?.PartValue ?? "0");
				}
				return _TaxPercent.Value;
			}
			set
			{
				_TaxPercent = 0;
			}
		}

		public int DutyPercent
		{
			get
			{
				if (_DutyPercent.GetValueOrDefault() == 0)
				{
					_DutyPercent = int.Parse(Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "DutyPercent"))?.PartValue ?? "0");
				}
				return _DutyPercent.Value;
			}
			set
			{
				_DutyPercent = 0;
			}
		}

		public bool AllowDuplicateEco
		{
			get
			{
				if (!_AllowDuplicateEco.GetValueOrDefault())
				{
					string text = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "AllowDuplicateEco"))?.PartValue ?? "false";
					_AllowDuplicateEco = text.ToLower() == bool.TrueString.ToLower();
				}
				return _AllowDuplicateEco.Value;
			}
			set
			{
				_AllowDuplicateEco = false;
			}
		}

		public bool AllowDuplicateNatCode
		{
			get
			{
				if (!_AllowDuplicateNatCode.GetValueOrDefault())
				{
					string text = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "AllowDuplicateNatCode"))?.PartValue ?? "false";
					_AllowDuplicateNatCode = text.ToLower() == bool.TrueString.ToLower();
				}
				return _AllowDuplicateNatCode.Value;
			}
			set
			{
				_AllowDuplicateNatCode = false;
			}
		}

		public bool AllowDuplicateMobile
		{
			get
			{
				if (!_AllowDuplicateMobile.GetValueOrDefault())
				{
					string text = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "AllowDuplicateMobile"))?.PartValue ?? "false";
					_AllowDuplicateMobile = text.ToLower() == bool.TrueString.ToLower();
				}
				return _AllowDuplicateMobile.Value;
			}
			set
			{
				_AllowDuplicateMobile = false;
			}
		}

		public bool SendTaxAndDutyPercentToApi
		{
			get
			{
				if (!_SendTaxAndDutyPercentToApi.GetValueOrDefault())
				{
					string text = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "SendTaxAndDutyPercentToApi"))?.PartValue ?? "false";
					_SendTaxAndDutyPercentToApi = text.ToLower() == bool.TrueString.ToLower();
				}
				return _SendTaxAndDutyPercentToApi.Value;
			}
			set
			{
				_SendTaxAndDutyPercentToApi = false;
			}
		}

		public int CmpMnBgRate
		{
			get
			{
				if (_CmpMnBgRate.GetValueOrDefault() == 0)
				{
					_CmpMnBgRate = int.Parse(Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "CmpMnBgRate"))?.PartValue ?? "0");
				}
				return _CmpMnBgRate.Value;
			}
			set
			{
				_CmpMnBgRate = 0;
			}
		}

		public int? CmpMnBgExpireDay
		{
			get
			{
				if (_CmpMnBgExpireDay.GetValueOrDefault() == 0)
				{
					_CmpMnBgExpireDay = int.Parse(Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "CmpMnBgExpireDay"))?.PartValue ?? "0");
				}
				return _CmpMnBgExpireDay.Value;
			}
			set
			{
				_CmpMnBgExpireDay = 0;
			}
		}

		public bool SendPrdUnitToApi
		{
			get
			{
				if (!_SendPrdUnitToApi.GetValueOrDefault())
				{
					string text = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "SendPrdUnitToApi"))?.PartValue ?? "false";
					_SendPrdUnitToApi = text.ToLower() == bool.TrueString.ToLower();
				}
				return _SendPrdUnitToApi.Value;
			}
			set
			{
				_SendPrdUnitToApi = false;
			}
		}

		public bool DoneActionsAfterOrdVerify
		{
			get
			{
				if (!_DoneActionsAfterOrdVerify.GetValueOrDefault())
				{
					string text = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "DoneActionsAfterOrdVerify"))?.PartValue ?? "false";
					_DoneActionsAfterOrdVerify = text.ToLower() == bool.TrueString.ToLower();
				}
				return _DoneActionsAfterOrdVerify.Value;
			}
			set
			{
				_DoneActionsAfterOrdVerify = false;
			}
		}

		public int OrderTimeOut
		{
			get
			{
				if (_OrderTimeOut == 0)
				{
					_OrderTimeOut = int.Parse(Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "OrderTimeOut"))?.PartValue ?? "20");
				}
				return _OrderTimeOut;
			}
			set
			{
				_OrderTimeOut = 0;
			}
		}

		public int PreOrderTimeOut
		{
			get
			{
				if (_PreOrderTimeOut == 0)
				{
					_PreOrderTimeOut = int.Parse(Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "PreOrderTimeOut"))?.PartValue ?? "20");
				}
				return _PreOrderTimeOut;
			}
			set
			{
				_PreOrderTimeOut = 0;
			}
		}

		public int CompanyTimeOut
		{
			get
			{
				if (_CompanyTimeOut == 0)
				{
					_CompanyTimeOut = int.Parse(Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "CompanyTimeOut"))?.PartValue ?? "20");
				}
				return _CompanyTimeOut;
			}
			set
			{
				_CompanyTimeOut = 0;
			}
		}

		public int ProductTimeOut
		{
			get
			{
				if (_ProductTimeOut == 0)
				{
					_ProductTimeOut = int.Parse(Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "ProductTimeOut"))?.PartValue ?? "20");
				}
				return _ProductTimeOut;
			}
			set
			{
				_ProductTimeOut = 0;
			}
		}

		public int CmpLinkedField
		{
			get
			{
				if (_CmpLinkedField == 0)
				{
					_CmpLinkedField = int.Parse(Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_LinkAccSetting, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "_CmpLinkedField"))?.PartValue ?? "1");
				}
				return _CmpLinkedField;
			}
			set
			{
				_CmpLinkedField = 0;
			}
		}

		public void ClearFields()
		{
			ApiAddress = "";
			ApiUsername = "";
			ApiPassword = "";
			CashAccCode = "";
			PrdInvStockDisplayType = 0;
			TaxCalculateType = 0;
			TaxPercent = 0;
			DutyPercent = 0;
			AllowDuplicateEco = false;
			AllowDuplicateNatCode = false;
			AllowDuplicateMobile = false;
			SendTaxAndDutyPercentToApi = false;
			CmpMnBgRate = 0;
			CmpMnBgExpireDay = 0;
			SendPrdUnitToApi = false;
			DoneActionsAfterOrdVerify = false;
			OrderTimeOut = 20;
			ProductTimeOut = 20;
			CompanyTimeOut = 20;
			CmpLinkedField = 1;
		}

		public List<CRMspSelectLinkAccSetting_Result> GetLinkAccSetting(int linkAccSettingDBId, bool? readAgain = false)
		{
			if (!readAgain.GetValueOrDefault() && _LinkAccSetting != null && _LinkAccSettingDB != null && _LinkAccSettingDB.LinkAccSettingDBId == linkAccSettingDBId)
			{
				return _LinkAccSetting;
			}
			List<CRMspSelectLinkAccSetting_Result> list = new List<CRMspSelectLinkAccSetting_Result>();
			CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
			try
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				int value = 4;
				list = Enumerable.ToList<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)cRMLinkSpEntities.CRMspSelectLinkAccSetting(0, "", lCID, result, value, linkAccSettingDBId, null));
				if (list == null)
				{
					list = new List<CRMspSelectLinkAccSetting_Result>();
				}
			}
			catch (Exception ex)
			{
				Public.InsExceptToElmah(ex);
			}
			cRMLinkSpEntities.Dispose();
			return list;
		}

		public CRMspSelectLinkAccSettingDB_Result GetLinkAccSettingDB(int linkAccSettingDBId)
		{
			if (_LinkAccSettingDB != null && _LinkAccSettingDB.LinkAccSettingDBId == linkAccSettingDBId)
			{
				return _LinkAccSettingDB;
			}
			CRMspSelectLinkAccSettingDB_Result cRMspSelectLinkAccSettingDB_Result = new CRMspSelectLinkAccSettingDB_Result();
			CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
			try
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				int value = 4;
				cRMspSelectLinkAccSettingDB_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDB_Result>((IEnumerable<CRMspSelectLinkAccSettingDB_Result>)cRMLinkSpEntities.CRMspSelectLinkAccSettingDB(value, linkAccSettingDBId, lCID, result));
				if (cRMspSelectLinkAccSettingDB_Result == null)
				{
					cRMspSelectLinkAccSettingDB_Result = new CRMspSelectLinkAccSettingDB_Result();
				}
			}
			catch (Exception ex)
			{
				Public.InsExceptToElmah(ex);
			}
			cRMLinkSpEntities.Dispose();
			return cRMspSelectLinkAccSettingDB_Result;
		}

		public HolooSettingDetailsViewModel GetSettingDetails(int linkAccSettingDBId, int settingDetailId = 0, int objId = 0, string objectType = "")
		{
			HolooSettingDetailsViewModel holooSettingDetailsViewModel = new HolooSettingDetailsViewModel();
			CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
			try
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				int value = 23;
				if (settingDetailId < 0)
				{
					settingDetailId = 0;
				}
				List<CRMspSelectLinkAccSettingDetails_Result> list = Enumerable.ToList<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)cRMLinkSpEntities.CRMspSelectLinkAccSettingDetails(settingDetailId, objId, objectType, lCID, result, value, linkAccSettingDBId));
				if (list != null)
				{
					if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "CashAccCode")) != null)
					{
						string partValue = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "CashAccCode")).PartValue;
						holooSettingDetailsViewModel.CashAccCode = ((!string.IsNullOrWhiteSpace(partValue)) ? partValue : "");
					}
					if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "PrdInvStockDisplayType")) != null)
					{
						string partValue2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "PrdInvStockDisplayType")).PartValue;
						holooSettingDetailsViewModel.PrdInvStockDisplayType = ((!string.IsNullOrWhiteSpace(partValue2)) ? new int?(int.Parse(partValue2)) : null);
					}
					if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "TaxCalculateType")) != null)
					{
						string partValue3 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "TaxCalculateType")).PartValue;
						holooSettingDetailsViewModel.TaxCalculateType = ((!string.IsNullOrWhiteSpace(partValue3)) ? new int?(int.Parse(partValue3)) : null);
					}
					if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "TaxPercent")) != null)
					{
						string partValue4 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "TaxPercent")).PartValue;
						holooSettingDetailsViewModel.TaxPercent = ((!string.IsNullOrWhiteSpace(partValue4)) ? new int?(int.Parse(partValue4)) : null);
					}
					if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "DutyPercent")) != null)
					{
						string partValue5 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "DutyPercent")).PartValue;
						holooSettingDetailsViewModel.DutyPercent = ((!string.IsNullOrWhiteSpace(partValue5)) ? new int?(int.Parse(partValue5)) : null);
					}
					if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "AllowDuplicateEco")) != null)
					{
						string partValue6 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "AllowDuplicateEco")).PartValue;
						bool? allowDuplicateEco = null;
						if (!string.IsNullOrWhiteSpace(partValue6))
						{
							allowDuplicateEco = partValue6 == bool.TrueString;
						}
						holooSettingDetailsViewModel.AllowDuplicateEco = allowDuplicateEco;
					}
					if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "AllowDuplicateNatCode")) != null)
					{
						string partValue7 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "AllowDuplicateNatCode")).PartValue;
						bool? allowDuplicateNatCode = null;
						if (!string.IsNullOrWhiteSpace(partValue7))
						{
							allowDuplicateNatCode = partValue7 == bool.TrueString;
						}
						holooSettingDetailsViewModel.AllowDuplicateNatCode = allowDuplicateNatCode;
					}
					if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "AllowDuplicateMobile")) != null)
					{
						string partValue8 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "AllowDuplicateMobile")).PartValue;
						bool? allowDuplicateMobile = null;
						if (!string.IsNullOrWhiteSpace(partValue8))
						{
							allowDuplicateMobile = partValue8 == bool.TrueString;
						}
						holooSettingDetailsViewModel.AllowDuplicateMobile = allowDuplicateMobile;
					}
					if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "SendTaxAndDutyPercentToApi")) != null)
					{
						string partValue9 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "SendTaxAndDutyPercentToApi")).PartValue;
						bool? sendTaxAndDutyPercentToApi = null;
						if (!string.IsNullOrWhiteSpace(partValue9))
						{
							sendTaxAndDutyPercentToApi = partValue9 == bool.TrueString;
						}
						holooSettingDetailsViewModel.SendTaxAndDutyPercentToApi = sendTaxAndDutyPercentToApi;
					}
					if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "CmpMnBgRate")) != null)
					{
						string partValue10 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "CmpMnBgRate")).PartValue;
						holooSettingDetailsViewModel.CmpMnBgRate = ((!string.IsNullOrWhiteSpace(partValue10)) ? new int?(int.Parse(partValue10)) : null);
					}
					if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "CmpMnBgExpireDay")) != null)
					{
						string partValue11 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "CmpMnBgExpireDay")).PartValue;
						holooSettingDetailsViewModel.CmpMnBgExpireDay = ((!string.IsNullOrWhiteSpace(partValue11)) ? new int?(int.Parse(partValue11)) : null);
					}
					if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "SendPrdUnitToApi")) != null)
					{
						string partValue12 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "SendPrdUnitToApi")).PartValue;
						bool? sendPrdUnitToApi = null;
						if (!string.IsNullOrWhiteSpace(partValue12))
						{
							sendPrdUnitToApi = partValue12 == bool.TrueString;
						}
						holooSettingDetailsViewModel.SendPrdUnitToApi = sendPrdUnitToApi;
					}
					if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "DoneActionsAfterOrdVerify")) != null)
					{
						string partValue13 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "DoneActionsAfterOrdVerify")).PartValue;
						bool? sendPrdUnitToApi2 = null;
						if (!string.IsNullOrWhiteSpace(partValue13))
						{
							sendPrdUnitToApi2 = partValue13 == bool.TrueString;
						}
						holooSettingDetailsViewModel.SendPrdUnitToApi = sendPrdUnitToApi2;
					}
					if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "OrderTimeOut")) != null)
					{
						string partValue14 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "OrderTimeOut")).PartValue;
						holooSettingDetailsViewModel.OrderTimeOut = ((!string.IsNullOrWhiteSpace(partValue14)) ? new int?(int.Parse(partValue14)) : null);
					}
					if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "CompanyTimeOut")) != null)
					{
						string partValue15 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "CompanyTimeOut")).PartValue;
						holooSettingDetailsViewModel.CompanyTimeOut = ((!string.IsNullOrWhiteSpace(partValue15)) ? new int?(int.Parse(partValue15)) : null);
					}
					if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "ProductTimeOut")) != null)
					{
						string partValue16 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "ProductTimeOut")).PartValue;
						holooSettingDetailsViewModel.ProductTimeOut = ((!string.IsNullOrWhiteSpace(partValue16)) ? new int?(int.Parse(partValue16)) : null);
					}
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
			finally
			{
				cRMLinkSpEntities.Dispose();
			}
			return holooSettingDetailsViewModel;
		}

		public HolooProvider(int linkAccSettingDBId, string timeOutMode = "", bool isUpdateList = false, bool isLogin = true)
		{
			_LinkAccSetting = GetLinkAccSetting(linkAccSettingDBId, true);
			_LinkAccSettingDB = GetLinkAccSettingDB(linkAccSettingDBId);
			ClearFields();
		}

		public string Authenticate(string timeOutMode = "", string userName = "", string password = "", bool isReferUser = false)
		{
			_Token = "";
			string text = _LinkAccSettingDB.LinkAccSettingDbName ?? "";
			if (!isReferUser)
			{
				if (string.IsNullOrEmpty(userName))
				{
					userName = ApiUsername;
				}
				if (string.IsNullOrEmpty(password))
				{
					password = ApiPassword;
				}
			}
			if (!string.IsNullOrWhiteSpace(ApiAddress) && !string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(userName) && !string.IsNullOrWhiteSpace(password))
			{
				if (!ApiAddress.EndsWith("/"))
				{
					ApiAddress += "/";
				}
				HolooLoginViewModel holooLoginViewModel = new HolooLoginViewModel();
				holooLoginViewModel.userinfo = new HolooUserInfoViewModel
				{
					dbname = text,
					username = userName,
					userpass = password
				};
				string text2 = "api/Login";
				HttpClient httpClient = new HttpClient();
				int? num = null;
				if (!string.IsNullOrWhiteSpace(timeOutMode))
				{
					num = timeOutMode.ToLower() switch
					{
						"order" => _OrderTimeOut, 
						"product" => _ProductTimeOut, 
						"company" => _CompanyTimeOut, 
						_ => 20, 
					};
					if (num.HasValue)
					{
						httpClient.Timeout = TimeSpan.FromMinutes(num.Value);
					}
				}
				httpClient.BaseAddress = new Uri(ApiAddress + text2);
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				HttpContent content = new StringContent(JsonConvert.SerializeObject(holooLoginViewModel), Encoding.UTF8, "application/json");
				HttpResponseMessage result = httpClient.PostAsync(ApiAddress + text2, content).Result;
				if (result.IsSuccessStatusCode)
				{
					HolooLoginResultViewModel holooLoginResultViewModel = JsonConvert.DeserializeObject<HolooLoginResultViewModel>(result.Content.ReadAsStringAsync().Result);
					if (holooLoginResultViewModel != null)
					{
						if (holooLoginResultViewModel.Login != null)
						{
							if (holooLoginResultViewModel.Login.State)
							{
								_Token = holooLoginResultViewModel.Login.Token ?? "";
								if (string.IsNullOrWhiteSpace(_Token))
								{
									Exception ex = new Exception(Messages.msgErrorRunFunction + "<br> Token is null");
									ErrorSignal.FromCurrentContext().Raise(ex);
									return ex.Message + "|";
								}
								return "";
							}
							string msgErrorRunFunction = Messages.msgErrorRunFunction;
							string error = holooLoginResultViewModel.Login.Error;
							_ = holooLoginResultViewModel.Login.ErrorCode;
							Exception ex2 = new Exception(string.Concat(msgErrorRunFunction, "<br>", error, " code:" + holooLoginResultViewModel.Login.ErrorCode));
							ErrorSignal.FromCurrentContext().Raise(ex2);
							return ex2.Message + "|";
						}
						Exception ex3 = new Exception(Messages.msgErrorRunFunction + "<br> Error in login");
						ErrorSignal.FromCurrentContext().Raise(ex3);
						return ex3.Message + "|";
					}
					Exception ex4 = new Exception(Messages.msgErrorRunFunction + "<br> Error in login");
					ErrorSignal.FromCurrentContext().Raise(ex4);
					return ex4.Message + "|";
				}
				Exception ex5 = new Exception(Messages.msgErrorRunFunction + "<br> Error in login");
				ErrorSignal.FromCurrentContext().Raise(ex5);
				return ex5.Message + "|";
			}
			string errorInReadingSetting = Messages.errorInReadingSetting;
			Exception e = new Exception(errorInReadingSetting);
			ErrorSignal.FromCurrentContext().Raise(e);
			return errorInReadingSetting + "|";
		}

		public void SendOrderToAcc(HolooInvoiceIEViewModel invoice, CRMspLkHolooWSSelectOrderByOrdIds_Result ord, ref string ordLinkAccTransferKey, ref bool isReCheckSent, ref string errorMessage, ref string code)
		{
			//IL_0579: Unknown result type (might be due to invalid IL or missing references)
			//IL_0586: Unknown result type (might be due to invalid IL or missing references)
			//IL_058b: Unknown result type (might be due to invalid IL or missing references)
			_003C_003Ec__DisplayClass131_0 _003C_003Ec__DisplayClass131_ = new _003C_003Ec__DisplayClass131_0();
			_003C_003Ec__DisplayClass131_.ord = ord;
			if (string.IsNullOrEmpty(Token))
			{
				return;
			}
			HttpClient httpClient = new HttpClient();
			if (OrderTimeOut != 0)
			{
				httpClient.Timeout = TimeSpan.FromMinutes(OrderTimeOut);
			}
			httpClient.BaseAddress = new Uri(ApiAddress);
			httpClient.DefaultRequestHeaders.Add("Authorization", Token);
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			string requestUri = "api/Invoice/Invoice";
			string text = JsonConvert.SerializeObject(invoice);
			text = " " + text;
			text = text.Replace(",\"midManErpCode\":null,", "").Replace("\"midManErpCode\":null", "");
			text = text.Replace("\"commission\":null,", "").Replace("\"commission\":null", "");
			text = text.Replace(",\"unitid\":null,", "").Replace(",\"unitid\":null", "").Replace("\"unitid\":null", "");
			HttpContent content = new StringContent(text, Encoding.UTF8, "application/json");
			HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
			httpResponseMessage = httpClient.PostAsync(requestUri, content).Result;
			int linkAccSettingDBId = _LinkAccSettingDB.LinkAccSettingDBId;
			if (httpResponseMessage.IsSuccessStatusCode)
			{
				HolooInvoiceInfoIEResultViewModel holooInvoiceInfoIEResultViewModel = JsonConvert.DeserializeObject<HolooInvoiceInfoIEResultViewModel>(httpResponseMessage.Content.ReadAsStringAsync().Result);
				if (holooInvoiceInfoIEResultViewModel != null)
				{
					if (holooInvoiceInfoIEResultViewModel.Success != null)
					{
						if (string.IsNullOrEmpty(holooInvoiceInfoIEResultViewModel.Success.ErpCode))
						{
							errorMessage = string.Format(Messages.msgErrorOtherSystemsNotRegistered, Labels.OtherSystemsOrder, Labels.Holoo) + "|";
						}
						string text2 = "";
						text2 = holooInvoiceInfoIEResultViewModel.Success.Code;
						string text3 = "";
						text3 = holooInvoiceInfoIEResultViewModel.Success.SanadCode;
						string erpCode = holooInvoiceInfoIEResultViewModel.Success.ErpCode;
						DbSet<WSOrder> wSOrder = _dbTbl.WSOrder;
						ParameterExpression val = Expression.Parameter(typeof(WSOrder), "c");
						if (Queryable.FirstOrDefault<WSOrder>((IQueryable<WSOrder>)wSOrder, Expression.Lambda<Func<WSOrder, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass131_, typeof(_003C_003Ec__DisplayClass131_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) != null)
						{
							string message = "Ok";
							string text4 = JsonConvert.SerializeObject(new HolooInvoiceInfoIETransferResultViewModel
							{
								DBId = linkAccSettingDBId,
								Message = message
							});
							if (!string.IsNullOrWhiteSpace(text4))
							{
								if (!text4.StartsWith("["))
								{
									text4 = "[" + text4;
								}
								if (!text4.EndsWith("]"))
								{
									text4 += "]";
								}
							}
							string text5 = "[OrdId=" + _003C_003Ec__DisplayClass131_.ord.OrderID + "|,|LinkAccOrdNumber =" + ((!string.IsNullOrWhiteSpace(text2)) ? text2 : "") + "|,|LinkAccVoucherNumber =" + ((!string.IsNullOrWhiteSpace(text3)) ? text3 : "") + "|,|LinkAccOrdIdStr=" + ((!string.IsNullOrWhiteSpace(erpCode)) ? erpCode : "") + "|,|LinkAccTransferKey=" + ((!string.IsNullOrWhiteSpace(ordLinkAccTransferKey)) ? ordLinkAccTransferKey : "") + "|,|LinkAccTransferResult=" + text4 + "|,|]@";
							if (!string.IsNullOrEmpty(text5))
							{
								mct_Link_Result mct_Link_Result = Enumerable.FirstOrDefault<mct_Link_Result>((IEnumerable<mct_Link_Result>)_dbLink.CRMspLkHolooWSUpdateOrderLinkAccFields(text5, linkAccSettingDBId));
								if (mct_Link_Result != null && mct_Link_Result.Result > 0)
								{
									code = text3 ?? "";
									isReCheckSent = false;
								}
								else
								{
									errorMessage = Messages.ErrorNotFound + Labels.OtherSystemsOrder + "|";
								}
							}
							else
							{
								errorMessage = Messages.ErrorNotFound + Labels.OtherSystemsOrder + "|";
							}
						}
						else
						{
							errorMessage = Messages.ErrorNotFound + Labels.OtherSystemsOrder + "|";
						}
						code = text3 ?? "";
					}
					else if (holooInvoiceInfoIEResultViewModel.Failure != null)
					{
						string[] obj = new string[10]
						{
							Messages.msgErrorRunFunction,
							"<br>",
							Messages.msgErrorInSendToOtherSystem,
							" ",
							Labels.OtherSystemsOrder,
							"<br>",
							holooInvoiceInfoIEResultViewModel.Failure.Error,
							"<br>",
							null,
							null
						};
						_ = holooInvoiceInfoIEResultViewModel.Failure.ErrorCode;
						obj[8] = " code:" + holooInvoiceInfoIEResultViewModel.Failure.ErrorCode;
						obj[9] = "|";
						errorMessage = string.Concat(obj);
					}
					else
					{
						errorMessage = Messages.msgErrorRunFunction + "<br>" + Messages.msgErrorInSendToOtherSystem + " " + Labels.OtherSystemsOrder + "|";
					}
				}
				else
				{
					errorMessage = Messages.msgErrorRunFunction + "<br>" + Messages.msgErrorInSendToOtherSystem + " " + Labels.OtherSystemsOrder + "|";
				}
			}
			else
			{
				string[] obj2 = new string[8]
				{
					Messages.msgErrorRunFunction,
					"<br>",
					Messages.msgErrorEditInfo,
					" ",
					Labels.OtherSystemsOrder,
					"<br>",
					null,
					null
				};
				_ = httpResponseMessage.StatusCode;
				HttpStatusCode statusCode = httpResponseMessage.StatusCode;
				obj2[6] = " code:" + ((object)(HttpStatusCode)(ref statusCode)).ToString();
				obj2[7] = "|";
				errorMessage = string.Concat(obj2);
			}
		}

		public void OrderExportInfo(ref HolooInvoiceIEViewModel invoice, ref List<HolooInvoiceInfoListTransferKeyViewModel> transferkeys, ref string errorMessage)
		{
			//IL_199b: Unknown result type (might be due to invalid IL or missing references)
			//IL_19a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_19ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_1ab0: Unknown result type (might be due to invalid IL or missing references)
			//IL_1abd: Unknown result type (might be due to invalid IL or missing references)
			//IL_1ac2: Unknown result type (might be due to invalid IL or missing references)
			if (string.IsNullOrEmpty(Token))
			{
				return;
			}
			HttpClient httpClient = new HttpClient();
			if (OrderTimeOut != 0)
			{
				httpClient.Timeout = TimeSpan.FromMinutes(OrderTimeOut);
			}
			httpClient.BaseAddress = new Uri(ApiAddress);
			httpClient.DefaultRequestHeaders.Add("Authorization", Token);
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			string requestUri = "api/Invoice/Invoice";
			string text = JsonConvert.SerializeObject(invoice);
			text = " " + text;
			text = text.Replace(",\"midManErpCode\":null,", "").Replace("\"midManErpCode\":null", "");
			text = text.Replace("\"commission\":null,", "").Replace("\"commission\":null", "");
			text = text.Replace(",\"unitid\":null,", "").Replace(",\"unitid\":null", "").Replace("\"unitid\":null", "");
			HttpContent content = new StringContent(text, Encoding.UTF8, "application/json");
			HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
			httpResponseMessage = httpClient.PostAsync(requestUri, content).Result;
			int linkAccSettingDBId = _LinkAccSettingDB.LinkAccSettingDBId;
			if (httpResponseMessage.IsSuccessStatusCode)
			{
				string result = httpResponseMessage.Content.ReadAsStringAsync().Result;
				if (Enumerable.Count<HolooInvoiceInfoIEViewModel>((IEnumerable<HolooInvoiceInfoIEViewModel>)invoice.invoiceinfo) > 1)
				{
					HolooInvoicesInfoIEResultViewModel holooInvoicesInfoIEResultViewModel = new HolooInvoicesInfoIEResultViewModel();
					string text2 = result;
					text2 = text2.Replace(" ", "").Replace("\n", "").Replace("\r", "")
						.ToLower();
					string value = "\"Success\": [{".Replace(" ", "").Replace("\n", "").Replace("\r", "")
						.ToLower();
					string value2 = "\"Failure\": [{".Replace(" ", "").Replace("\n", "").Replace("\r", "")
						.ToLower();
					string value3 = "\"Success\": {".Replace(" ", "").Replace("\n", "").Replace("\r", "")
						.ToLower();
					string value4 = "\"Failure\": {".Replace(" ", "").Replace("\n", "").Replace("\r", "")
						.ToLower();
					if (text2.IndexOf(value) >= 0 && text2.IndexOf(value2) >= 0)
					{
						holooInvoicesInfoIEResultViewModel = JsonConvert.DeserializeObject<HolooInvoicesInfoIEResultViewModel>(result);
					}
					else if (text2.IndexOf(value) >= 0 && text2.IndexOf(value4) >= 0)
					{
						HolooInvoicesInfoIEResult_IViewModel holooInvoicesInfoIEResult_IViewModel = JsonConvert.DeserializeObject<HolooInvoicesInfoIEResult_IViewModel>(result);
						if (holooInvoicesInfoIEResult_IViewModel != null)
						{
							holooInvoicesInfoIEResultViewModel.Header = holooInvoicesInfoIEResult_IViewModel.Header;
							holooInvoicesInfoIEResultViewModel.Success = new List<HolooInvoiceInfoIESuccessResultViewModel>();
							holooInvoicesInfoIEResultViewModel.Failure = new List<HolooInvoiceInfoIEFailureResultViewModel>();
							if (holooInvoicesInfoIEResult_IViewModel.Success != null && Enumerable.Any<HolooInvoiceInfoIESuccessResultViewModel>((IEnumerable<HolooInvoiceInfoIESuccessResultViewModel>)holooInvoicesInfoIEResult_IViewModel.Success))
							{
								holooInvoicesInfoIEResultViewModel.Success.AddRange(holooInvoicesInfoIEResult_IViewModel.Success);
							}
							if (holooInvoicesInfoIEResult_IViewModel.Failure != null)
							{
								holooInvoicesInfoIEResultViewModel.Failure.Add(holooInvoicesInfoIEResult_IViewModel.Failure);
							}
						}
					}
					else if (text2.IndexOf(value3) >= 0 && text2.IndexOf(value2) >= 0)
					{
						HolooInvoicesInfoIEResult_IIViewModel holooInvoicesInfoIEResult_IIViewModel = JsonConvert.DeserializeObject<HolooInvoicesInfoIEResult_IIViewModel>(result);
						if (holooInvoicesInfoIEResult_IIViewModel != null)
						{
							holooInvoicesInfoIEResultViewModel.Header = holooInvoicesInfoIEResult_IIViewModel.Header;
							holooInvoicesInfoIEResultViewModel.Success = new List<HolooInvoiceInfoIESuccessResultViewModel>();
							holooInvoicesInfoIEResultViewModel.Failure = new List<HolooInvoiceInfoIEFailureResultViewModel>();
							if (holooInvoicesInfoIEResult_IIViewModel.Success != null)
							{
								holooInvoicesInfoIEResultViewModel.Success.Add(holooInvoicesInfoIEResult_IIViewModel.Success);
							}
							if (holooInvoicesInfoIEResult_IIViewModel.Failure != null && Enumerable.Any<HolooInvoiceInfoIEFailureResultViewModel>((IEnumerable<HolooInvoiceInfoIEFailureResultViewModel>)holooInvoicesInfoIEResult_IIViewModel.Failure))
							{
								holooInvoicesInfoIEResultViewModel.Failure.AddRange(holooInvoicesInfoIEResult_IIViewModel.Failure);
							}
						}
					}
					else if (text2.IndexOf(value3) >= 0 && text2.IndexOf(value4) >= 0)
					{
						HolooInvoiceInfoIEResultViewModel holooInvoiceInfoIEResultViewModel = JsonConvert.DeserializeObject<HolooInvoiceInfoIEResultViewModel>(result);
						if (holooInvoiceInfoIEResultViewModel != null)
						{
							holooInvoicesInfoIEResultViewModel.Header = holooInvoiceInfoIEResultViewModel.Header;
							holooInvoicesInfoIEResultViewModel.Success = new List<HolooInvoiceInfoIESuccessResultViewModel>();
							holooInvoicesInfoIEResultViewModel.Failure = new List<HolooInvoiceInfoIEFailureResultViewModel>();
							if (holooInvoiceInfoIEResultViewModel.Success != null)
							{
								holooInvoicesInfoIEResultViewModel.Success.Add(holooInvoiceInfoIEResultViewModel.Success);
							}
							if (holooInvoiceInfoIEResultViewModel.Failure != null)
							{
								holooInvoicesInfoIEResultViewModel.Failure.Add(holooInvoiceInfoIEResultViewModel.Failure);
							}
						}
					}
					else
					{
						holooInvoicesInfoIEResultViewModel = JsonConvert.DeserializeObject<HolooInvoicesInfoIEResultViewModel>(result);
					}
					if (holooInvoicesInfoIEResultViewModel != null)
					{
						string text3 = "";
						if (holooInvoicesInfoIEResultViewModel.Success != null)
						{
							foreach (HolooInvoiceInfoIESuccessResultViewModel item in holooInvoicesInfoIEResultViewModel.Success)
							{
								string text4 = "";
								string text5 = "";
								if (transferkeys != null && Enumerable.Any<HolooInvoiceInfoListTransferKeyViewModel>((IEnumerable<HolooInvoiceInfoListTransferKeyViewModel>)transferkeys))
								{
									int oId8 = 0;
									int.TryParse((!string.IsNullOrEmpty(item.Id)) ? item.Id : "0", out oId8);
									HolooInvoiceInfoListTransferKeyViewModel holooInvoiceInfoListTransferKeyViewModel = Enumerable.FirstOrDefault<HolooInvoiceInfoListTransferKeyViewModel>((IEnumerable<HolooInvoiceInfoListTransferKeyViewModel>)transferkeys, (Func<HolooInvoiceInfoListTransferKeyViewModel, bool>)((HolooInvoiceInfoListTransferKeyViewModel m) => m.OrderId == oId8));
									if (holooInvoiceInfoListTransferKeyViewModel != null)
									{
										text4 = holooInvoiceInfoListTransferKeyViewModel.TransferKey ?? "";
									}
								}
								if (string.IsNullOrEmpty(item.ErpCode))
								{
									errorMessage = errorMessage + string.Format(Messages.msgErrorOtherSystemsNotRegistered, Labels.OtherSystemsOrder, Labels.Holoo) + "<br>";
									string message = string.Format(Messages.msgErrorOtherSystemsNotRegistered, Labels.OtherSystemsOrder, Labels.Holoo) + "<br>";
									text5 = JsonConvert.SerializeObject(new HolooInvoiceInfoIETransferResultViewModel
									{
										DBId = linkAccSettingDBId,
										Message = message
									});
									if (!string.IsNullOrWhiteSpace(text5))
									{
										if (!text5.StartsWith("["))
										{
											text5 = "[" + text5;
										}
										if (!text5.EndsWith("]"))
										{
											text5 += "]";
										}
									}
									text3 = text3 + "[OrdId=" + ((!string.IsNullOrEmpty(item.Id)) ? item.Id : "0") + "|,|LinkAccTransferKey=" + ((!string.IsNullOrWhiteSpace(text4)) ? text4 : "") + "|,|LinkAccTransferResult=" + text5 + "|,|]@";
									continue;
								}
								string message2 = "Ok";
								text5 = JsonConvert.SerializeObject(new HolooInvoiceInfoIETransferResultViewModel
								{
									DBId = linkAccSettingDBId,
									Message = message2
								});
								if (!string.IsNullOrWhiteSpace(text5))
								{
									if (!text5.StartsWith("["))
									{
										text5 = "[" + text5;
									}
									if (!text5.EndsWith("]"))
									{
										text5 += "]";
									}
								}
								text3 = text3 + "[OrdId=" + ((!string.IsNullOrEmpty(item.Id)) ? item.Id : "0") + "|,|LinkAccOrdNumber =" + ((!string.IsNullOrEmpty(item.Code)) ? item.Code : "") + "|,|LinkAccVoucherNumber =" + ((!string.IsNullOrEmpty(item.SanadCode)) ? item.SanadCode : "") + "|,|LinkAccOrdIdStr=" + ((!string.IsNullOrEmpty(item.ErpCode)) ? item.ErpCode : "") + "|,|LinkAccTransferKey=" + ((!string.IsNullOrWhiteSpace(text4)) ? text4 : "") + "|,|LinkAccTransferResult=" + text5 + "|,|]@";
							}
							if (!string.IsNullOrEmpty(text3))
							{
								mct_Link_Result mct_Link_Result = Enumerable.FirstOrDefault<mct_Link_Result>((IEnumerable<mct_Link_Result>)_dbLink.CRMspLkHolooWSUpdateOrderLinkAccFields(text3, linkAccSettingDBId));
								if (mct_Link_Result != null && mct_Link_Result.Result <= 0)
								{
								}
							}
							else
							{
								errorMessage = errorMessage + string.Format(Messages.msgErrorOtherSystemsNotRegistered, Labels.OtherSystemsOrder, Labels.Holoo) + "<br>";
							}
						}
						if (holooInvoicesInfoIEResultViewModel.Failure != null)
						{
							text3 = "";
							foreach (HolooInvoiceInfoIEFailureResultViewModel item2 in holooInvoicesInfoIEResultViewModel.Failure)
							{
								string[] obj = new string[11]
								{
									errorMessage,
									Messages.msgErrorRunFunction,
									"<br>",
									Messages.msgErrorInSendToOtherSystem,
									" ",
									Labels.OtherSystemsOrder,
									"<br>",
									item2.Error,
									"<br>",
									null,
									null
								};
								_ = item2.ErrorCode;
								obj[9] = " code:" + item2.ErrorCode;
								obj[10] = "<br>";
								errorMessage = string.Concat(obj);
								string text6 = "";
								string text7 = "";
								if (transferkeys != null && Enumerable.Any<HolooInvoiceInfoListTransferKeyViewModel>((IEnumerable<HolooInvoiceInfoListTransferKeyViewModel>)transferkeys))
								{
									int oId7 = 0;
									int.TryParse((!string.IsNullOrEmpty(item2.Id)) ? item2.Id : "0", out oId7);
									HolooInvoiceInfoListTransferKeyViewModel holooInvoiceInfoListTransferKeyViewModel2 = Enumerable.FirstOrDefault<HolooInvoiceInfoListTransferKeyViewModel>((IEnumerable<HolooInvoiceInfoListTransferKeyViewModel>)transferkeys, (Func<HolooInvoiceInfoListTransferKeyViewModel, bool>)((HolooInvoiceInfoListTransferKeyViewModel m) => m.OrderId == oId7));
									if (holooInvoiceInfoListTransferKeyViewModel2 != null)
									{
										text6 = holooInvoiceInfoListTransferKeyViewModel2.TransferKey ?? "";
									}
								}
								string[] obj2 = new string[9]
								{
									Messages.msgErrorRunFunction,
									"<br>",
									Messages.msgErrorInSendToOtherSystem,
									" ",
									Labels.OtherSystemsOrder,
									"<br>",
									item2.Error,
									"<br>",
									null
								};
								_ = item2.ErrorCode;
								obj2[8] = " code:" + item2.ErrorCode;
								string message3 = string.Concat(obj2);
								text7 = JsonConvert.SerializeObject(new HolooInvoiceInfoIETransferResultViewModel
								{
									DBId = linkAccSettingDBId,
									Message = message3
								});
								if (!string.IsNullOrWhiteSpace(text7))
								{
									if (!text7.StartsWith("["))
									{
										text7 = "[" + text7;
									}
									if (!text7.EndsWith("]"))
									{
										text7 += "]";
									}
								}
								text3 = text3 + "[OrdId=" + ((!string.IsNullOrEmpty(item2.Id)) ? item2.Id : "0") + "|,|LinkAccTransferKey=" + ((!string.IsNullOrWhiteSpace(text6)) ? text6 : "") + "|,|LinkAccTransferResult=" + text7 + "|,|]@";
								if (!string.IsNullOrEmpty(text3))
								{
									Enumerable.FirstOrDefault<mct_Link_Result>((IEnumerable<mct_Link_Result>)_dbLink.CRMspLkHolooWSUpdateOrderLinkAccFields(text3, linkAccSettingDBId));
								}
							}
						}
						if (holooInvoicesInfoIEResultViewModel.Success != null || holooInvoicesInfoIEResultViewModel.Failure != null)
						{
							return;
						}
						text3 = "";
						errorMessage = errorMessage + Messages.msgErrorRunFunction + "<br>" + Messages.msgErrorInSendToOtherSystem + " " + Labels.OtherSystemsOrder;
						{
							foreach (HolooInvoiceInfoIEViewModel item3 in invoice.invoiceinfo)
							{
								string text8 = "";
								string text9 = "";
								if (transferkeys != null && Enumerable.Any<HolooInvoiceInfoListTransferKeyViewModel>((IEnumerable<HolooInvoiceInfoListTransferKeyViewModel>)transferkeys))
								{
									int oId6 = 0;
									int.TryParse((!string.IsNullOrEmpty(item3.id)) ? item3.id : "0", out oId6);
									HolooInvoiceInfoListTransferKeyViewModel holooInvoiceInfoListTransferKeyViewModel3 = Enumerable.FirstOrDefault<HolooInvoiceInfoListTransferKeyViewModel>((IEnumerable<HolooInvoiceInfoListTransferKeyViewModel>)transferkeys, (Func<HolooInvoiceInfoListTransferKeyViewModel, bool>)((HolooInvoiceInfoListTransferKeyViewModel m) => m.OrderId == oId6));
									if (holooInvoiceInfoListTransferKeyViewModel3 != null)
									{
										text8 = holooInvoiceInfoListTransferKeyViewModel3.TransferKey ?? "";
									}
								}
								string message4 = Messages.msgErrorRunFunction + "<br>" + Messages.msgErrorInSendToOtherSystem + " " + Labels.OtherSystemsOrder;
								text9 = JsonConvert.SerializeObject(new HolooInvoiceInfoIETransferResultViewModel
								{
									DBId = linkAccSettingDBId,
									Message = message4
								});
								if (!string.IsNullOrWhiteSpace(text9))
								{
									if (!text9.StartsWith("["))
									{
										text9 = "[" + text9;
									}
									if (!text9.EndsWith("]"))
									{
										text9 += "]";
									}
								}
								text3 = text3 + "[OrdId=" + ((!string.IsNullOrEmpty(item3.id)) ? item3.id : "0") + "|,|LinkAccTransferKey=" + ((!string.IsNullOrWhiteSpace(text8)) ? text8 : "") + "|,|LinkAccTransferResult=" + text9 + "|,|]@";
								if (!string.IsNullOrEmpty(text3))
								{
									Enumerable.FirstOrDefault<mct_Link_Result>((IEnumerable<mct_Link_Result>)_dbLink.CRMspLkHolooWSUpdateOrderLinkAccFields(text3, linkAccSettingDBId));
								}
							}
							return;
						}
					}
					string text10 = "";
					errorMessage = errorMessage + Messages.msgErrorRunFunction + "<br>" + Messages.msgErrorInSendToOtherSystem + " " + Labels.OtherSystemsOrder;
					{
						foreach (HolooInvoiceInfoIEViewModel item4 in invoice.invoiceinfo)
						{
							string text11 = "";
							string text12 = "";
							if (transferkeys != null && Enumerable.Any<HolooInvoiceInfoListTransferKeyViewModel>((IEnumerable<HolooInvoiceInfoListTransferKeyViewModel>)transferkeys))
							{
								int oId9 = 0;
								int.TryParse((!string.IsNullOrEmpty(item4.id)) ? item4.id : "0", out oId9);
								HolooInvoiceInfoListTransferKeyViewModel holooInvoiceInfoListTransferKeyViewModel4 = Enumerable.FirstOrDefault<HolooInvoiceInfoListTransferKeyViewModel>((IEnumerable<HolooInvoiceInfoListTransferKeyViewModel>)transferkeys, (Func<HolooInvoiceInfoListTransferKeyViewModel, bool>)((HolooInvoiceInfoListTransferKeyViewModel m) => m.OrderId == oId9));
								if (holooInvoiceInfoListTransferKeyViewModel4 != null)
								{
									text11 = holooInvoiceInfoListTransferKeyViewModel4.TransferKey ?? "";
								}
							}
							string message5 = Messages.msgErrorRunFunction + "<br>" + Messages.msgErrorInSendToOtherSystem + " " + Labels.OtherSystemsOrder;
							text12 = JsonConvert.SerializeObject(new HolooInvoiceInfoIETransferResultViewModel
							{
								DBId = linkAccSettingDBId,
								Message = message5
							});
							if (!string.IsNullOrWhiteSpace(text12))
							{
								if (!text12.StartsWith("["))
								{
									text12 = "[" + text12;
								}
								if (!text12.EndsWith("]"))
								{
									text12 += "]";
								}
							}
							text10 = text10 + "[OrdId=" + ((!string.IsNullOrEmpty(item4.id)) ? item4.id : "0") + "|,|LinkAccTransferKey=" + ((!string.IsNullOrWhiteSpace(text11)) ? text11 : "") + "|,|LinkAccTransferResult=" + text12 + "|,|]@";
							if (!string.IsNullOrEmpty(text10))
							{
								Enumerable.FirstOrDefault<mct_Link_Result>((IEnumerable<mct_Link_Result>)_dbLink.CRMspLkHolooWSUpdateOrderLinkAccFields(text10, linkAccSettingDBId));
							}
						}
						return;
					}
				}
				HolooInvoiceInfoIEResultViewModel holooInvoiceInfoIEResultViewModel2 = JsonConvert.DeserializeObject<HolooInvoiceInfoIEResultViewModel>(result);
				if (holooInvoiceInfoIEResultViewModel2 != null)
				{
					string text13 = "";
					if (holooInvoiceInfoIEResultViewModel2.Success != null)
					{
						string text14 = "";
						string text15 = "";
						if (transferkeys != null && Enumerable.Any<HolooInvoiceInfoListTransferKeyViewModel>((IEnumerable<HolooInvoiceInfoListTransferKeyViewModel>)transferkeys))
						{
							int oId5 = 0;
							int.TryParse((!string.IsNullOrEmpty(holooInvoiceInfoIEResultViewModel2.Success.Id)) ? holooInvoiceInfoIEResultViewModel2.Success.Id : "0", out oId5);
							HolooInvoiceInfoListTransferKeyViewModel holooInvoiceInfoListTransferKeyViewModel5 = Enumerable.FirstOrDefault<HolooInvoiceInfoListTransferKeyViewModel>((IEnumerable<HolooInvoiceInfoListTransferKeyViewModel>)transferkeys, (Func<HolooInvoiceInfoListTransferKeyViewModel, bool>)((HolooInvoiceInfoListTransferKeyViewModel m) => m.OrderId == oId5));
							if (holooInvoiceInfoListTransferKeyViewModel5 != null)
							{
								text14 = holooInvoiceInfoListTransferKeyViewModel5.TransferKey ?? "";
							}
						}
						if (string.IsNullOrEmpty(holooInvoiceInfoIEResultViewModel2.Success.ErpCode))
						{
							errorMessage = errorMessage + string.Format(Messages.msgErrorOtherSystemsNotRegistered, Labels.OtherSystemsOrder, Labels.Holoo) + "<br>";
							string message6 = string.Format(Messages.msgErrorOtherSystemsNotRegistered, Labels.OtherSystemsOrder, Labels.Holoo) + "<br>";
							text15 = JsonConvert.SerializeObject(new HolooInvoiceInfoIETransferResultViewModel
							{
								DBId = linkAccSettingDBId,
								Message = message6
							});
							if (!string.IsNullOrWhiteSpace(text15))
							{
								if (!text15.StartsWith("["))
								{
									text15 = "[" + text15;
								}
								if (!text15.EndsWith("]"))
								{
									text15 += "]";
								}
							}
							text13 = text13 + "[OrdId=" + ((!string.IsNullOrEmpty(holooInvoiceInfoIEResultViewModel2.Success.Id)) ? holooInvoiceInfoIEResultViewModel2.Success.Id : "0") + "|,|LinkAccTransferKey=" + ((!string.IsNullOrWhiteSpace(text14)) ? text14 : "") + "|,|LinkAccTransferResult=" + text15 + "|,|]@";
						}
						else
						{
							string message7 = "Ok";
							text15 = JsonConvert.SerializeObject(new HolooInvoiceInfoIETransferResultViewModel
							{
								DBId = linkAccSettingDBId,
								Message = message7
							});
							if (!string.IsNullOrWhiteSpace(text15))
							{
								if (!text15.StartsWith("["))
								{
									text15 = "[" + text15;
								}
								if (!text15.EndsWith("]"))
								{
									text15 += "]";
								}
							}
							text13 = text13 + "[OrdId=" + ((!string.IsNullOrEmpty(holooInvoiceInfoIEResultViewModel2.Success.Id)) ? holooInvoiceInfoIEResultViewModel2.Success.Id : "0") + "|,|LinkAccOrdNumber =" + ((!string.IsNullOrEmpty(holooInvoiceInfoIEResultViewModel2.Success.Code)) ? holooInvoiceInfoIEResultViewModel2.Success.Code : "") + "|,|LinkAccVoucherNumber =" + ((!string.IsNullOrEmpty(holooInvoiceInfoIEResultViewModel2.Success.SanadCode)) ? holooInvoiceInfoIEResultViewModel2.Success.SanadCode : "") + "|,|LinkAccOrdIdStr=" + ((!string.IsNullOrEmpty(holooInvoiceInfoIEResultViewModel2.Success.ErpCode)) ? holooInvoiceInfoIEResultViewModel2.Success.ErpCode : "") + "|,|LinkAccTransferKey=" + ((!string.IsNullOrWhiteSpace(text14)) ? text14 : "") + "|,|LinkAccTransferResult=" + text15 + "|,|]@";
						}
						if (!string.IsNullOrEmpty(text13))
						{
							mct_Link_Result mct_Link_Result2 = Enumerable.FirstOrDefault<mct_Link_Result>((IEnumerable<mct_Link_Result>)_dbLink.CRMspLkHolooWSUpdateOrderLinkAccFields(text13, linkAccSettingDBId));
							if (mct_Link_Result2 != null)
							{
								_ = mct_Link_Result2.Result;
								_ = 0;
							}
						}
						else
						{
							errorMessage = errorMessage + string.Format(Messages.msgErrorOtherSystemsNotRegistered, Labels.OtherSystemsOrder, Labels.Holoo) + "<br>";
						}
						return;
					}
					if (holooInvoiceInfoIEResultViewModel2.Failure != null)
					{
						text13 = "";
						string[] obj3 = new string[11]
						{
							errorMessage,
							Messages.msgErrorRunFunction,
							"<br>",
							Messages.msgErrorInSendToOtherSystem,
							" ",
							Labels.OtherSystemsOrder,
							"<br>",
							holooInvoiceInfoIEResultViewModel2.Failure.Error,
							"<br>",
							null,
							null
						};
						_ = holooInvoiceInfoIEResultViewModel2.Failure.ErrorCode;
						obj3[9] = " code:" + holooInvoiceInfoIEResultViewModel2.Failure.ErrorCode;
						obj3[10] = "<br>";
						errorMessage = string.Concat(obj3);
						string text16 = "";
						string text17 = "";
						if (transferkeys != null && Enumerable.Any<HolooInvoiceInfoListTransferKeyViewModel>((IEnumerable<HolooInvoiceInfoListTransferKeyViewModel>)transferkeys))
						{
							int oId4 = 0;
							int.TryParse((!string.IsNullOrEmpty(holooInvoiceInfoIEResultViewModel2.Success.Id)) ? holooInvoiceInfoIEResultViewModel2.Success.Id : "0", out oId4);
							HolooInvoiceInfoListTransferKeyViewModel holooInvoiceInfoListTransferKeyViewModel6 = Enumerable.FirstOrDefault<HolooInvoiceInfoListTransferKeyViewModel>((IEnumerable<HolooInvoiceInfoListTransferKeyViewModel>)transferkeys, (Func<HolooInvoiceInfoListTransferKeyViewModel, bool>)((HolooInvoiceInfoListTransferKeyViewModel m) => m.OrderId == oId4));
							if (holooInvoiceInfoListTransferKeyViewModel6 != null)
							{
								text16 = holooInvoiceInfoListTransferKeyViewModel6.TransferKey ?? "";
							}
						}
						string[] obj4 = new string[9]
						{
							Messages.msgErrorRunFunction,
							"<br>",
							Messages.msgErrorInSendToOtherSystem,
							" ",
							Labels.OtherSystemsOrder,
							"<br>",
							holooInvoiceInfoIEResultViewModel2.Failure.Error,
							"<br>",
							null
						};
						_ = holooInvoiceInfoIEResultViewModel2.Failure.ErrorCode;
						obj4[8] = " code:" + holooInvoiceInfoIEResultViewModel2.Failure.ErrorCode;
						string message8 = string.Concat(obj4);
						text17 = JsonConvert.SerializeObject(new HolooInvoiceInfoIETransferResultViewModel
						{
							DBId = linkAccSettingDBId,
							Message = message8
						});
						if (!string.IsNullOrWhiteSpace(text17))
						{
							if (!text17.StartsWith("["))
							{
								text17 = "[" + text17;
							}
							if (!text17.EndsWith("]"))
							{
								text17 += "]";
							}
						}
						text13 = text13 + "[OrdId=" + ((!string.IsNullOrEmpty(holooInvoiceInfoIEResultViewModel2.Success.Id)) ? holooInvoiceInfoIEResultViewModel2.Success.Id : "0") + "|,|LinkAccTransferKey=" + ((!string.IsNullOrWhiteSpace(text16)) ? text16 : "") + "|,|LinkAccTransferResult=" + text17 + "|,|]@";
						if (!string.IsNullOrEmpty(text13))
						{
							Enumerable.FirstOrDefault<mct_Link_Result>((IEnumerable<mct_Link_Result>)_dbLink.CRMspLkHolooWSUpdateOrderLinkAccFields(text13, linkAccSettingDBId));
						}
						return;
					}
					text13 = "";
					errorMessage = errorMessage + Messages.msgErrorRunFunction + "<br>" + Messages.msgErrorInSendToOtherSystem + " " + Labels.OtherSystemsOrder;
					string text18 = "";
					string text19 = "";
					if (transferkeys != null && Enumerable.Any<HolooInvoiceInfoListTransferKeyViewModel>((IEnumerable<HolooInvoiceInfoListTransferKeyViewModel>)transferkeys))
					{
						int oId3 = 0;
						int.TryParse((!string.IsNullOrEmpty(holooInvoiceInfoIEResultViewModel2.Success.Id)) ? holooInvoiceInfoIEResultViewModel2.Success.Id : "0", out oId3);
						HolooInvoiceInfoListTransferKeyViewModel holooInvoiceInfoListTransferKeyViewModel7 = Enumerable.FirstOrDefault<HolooInvoiceInfoListTransferKeyViewModel>((IEnumerable<HolooInvoiceInfoListTransferKeyViewModel>)transferkeys, (Func<HolooInvoiceInfoListTransferKeyViewModel, bool>)((HolooInvoiceInfoListTransferKeyViewModel m) => m.OrderId == oId3));
						if (holooInvoiceInfoListTransferKeyViewModel7 != null)
						{
							text18 = holooInvoiceInfoListTransferKeyViewModel7.TransferKey ?? "";
						}
					}
					string message9 = Messages.msgErrorRunFunction + "<br>" + Messages.msgErrorInSendToOtherSystem + " " + Labels.OtherSystemsOrder;
					text19 = JsonConvert.SerializeObject(new HolooInvoiceInfoIETransferResultViewModel
					{
						DBId = linkAccSettingDBId,
						Message = message9
					});
					if (!string.IsNullOrWhiteSpace(text19))
					{
						if (!text19.StartsWith("["))
						{
							text19 = "[" + text19;
						}
						if (!text19.EndsWith("]"))
						{
							text19 += "]";
						}
					}
					text13 = text13 + "[OrdId=" + ((!string.IsNullOrEmpty(holooInvoiceInfoIEResultViewModel2.Success.Id)) ? holooInvoiceInfoIEResultViewModel2.Success.Id : "0") + "|,|LinkAccTransferKey=" + ((!string.IsNullOrWhiteSpace(text18)) ? text18 : "") + "|,|LinkAccTransferResult=" + text19 + "|,|]@";
					if (!string.IsNullOrEmpty(text13))
					{
						Enumerable.FirstOrDefault<mct_Link_Result>((IEnumerable<mct_Link_Result>)_dbLink.CRMspLkHolooWSUpdateOrderLinkAccFields(text13, linkAccSettingDBId));
					}
					return;
				}
				string text20 = "";
				errorMessage = errorMessage + Messages.msgErrorRunFunction + "<br>" + Messages.msgErrorInSendToOtherSystem + " " + Labels.OtherSystemsOrder;
				if (invoice.invoiceinfo == null)
				{
					return;
				}
				HolooInvoiceInfoIEViewModel holooInvoiceInfoIEViewModel = Enumerable.FirstOrDefault<HolooInvoiceInfoIEViewModel>((IEnumerable<HolooInvoiceInfoIEViewModel>)invoice.invoiceinfo);
				if (holooInvoiceInfoIEViewModel == null)
				{
					return;
				}
				string text21 = "";
				string text22 = "";
				if (transferkeys != null && Enumerable.Any<HolooInvoiceInfoListTransferKeyViewModel>((IEnumerable<HolooInvoiceInfoListTransferKeyViewModel>)transferkeys))
				{
					int oId2 = 0;
					int.TryParse((!string.IsNullOrEmpty(holooInvoiceInfoIEViewModel.id)) ? holooInvoiceInfoIEViewModel.id : "0", out oId2);
					HolooInvoiceInfoListTransferKeyViewModel holooInvoiceInfoListTransferKeyViewModel8 = Enumerable.FirstOrDefault<HolooInvoiceInfoListTransferKeyViewModel>((IEnumerable<HolooInvoiceInfoListTransferKeyViewModel>)transferkeys, (Func<HolooInvoiceInfoListTransferKeyViewModel, bool>)((HolooInvoiceInfoListTransferKeyViewModel m) => m.OrderId == oId2));
					if (holooInvoiceInfoListTransferKeyViewModel8 != null)
					{
						text21 = holooInvoiceInfoListTransferKeyViewModel8.TransferKey ?? "";
					}
				}
				string message10 = Messages.msgErrorRunFunction + "<br>" + Messages.msgErrorInSendToOtherSystem + " " + Labels.OtherSystemsOrder;
				text22 = JsonConvert.SerializeObject(new HolooInvoiceInfoIETransferResultViewModel
				{
					DBId = linkAccSettingDBId,
					Message = message10
				});
				if (!string.IsNullOrWhiteSpace(text22))
				{
					if (!text22.StartsWith("["))
					{
						text22 = "[" + text22;
					}
					if (!text22.EndsWith("]"))
					{
						text22 += "]";
					}
				}
				text20 = text20 + "[OrdId=" + ((!string.IsNullOrEmpty(holooInvoiceInfoIEViewModel.id)) ? holooInvoiceInfoIEViewModel.id : "0") + "|,|LinkAccTransferKey=" + ((!string.IsNullOrWhiteSpace(text21)) ? text21 : "") + "|,|LinkAccTransferResult=" + text22 + "|,|]@";
				if (!string.IsNullOrEmpty(text20))
				{
					Enumerable.FirstOrDefault<mct_Link_Result>((IEnumerable<mct_Link_Result>)_dbLink.CRMspLkHolooWSUpdateOrderLinkAccFields(text20, linkAccSettingDBId));
				}
				return;
			}
			string[] obj5 = new string[8]
			{
				errorMessage,
				Messages.msgErrorRunFunction,
				"<br>",
				Messages.msgErrorEditInfo,
				" ",
				Labels.OtherSystemsOrder,
				"<br>",
				null
			};
			_ = httpResponseMessage.StatusCode;
			HttpStatusCode statusCode = httpResponseMessage.StatusCode;
			obj5[7] = " code:" + ((object)(HttpStatusCode)(ref statusCode)).ToString();
			errorMessage = string.Concat(obj5);
			if (invoice.invoiceinfo == null)
			{
				return;
			}
			string text23 = "";
			foreach (HolooInvoiceInfoIEViewModel item5 in invoice.invoiceinfo)
			{
				string text24 = "";
				string text25 = "";
				if (transferkeys != null && Enumerable.Any<HolooInvoiceInfoListTransferKeyViewModel>((IEnumerable<HolooInvoiceInfoListTransferKeyViewModel>)transferkeys))
				{
					int oId = 0;
					int.TryParse((!string.IsNullOrEmpty(item5.id)) ? item5.id : "0", out oId);
					HolooInvoiceInfoListTransferKeyViewModel holooInvoiceInfoListTransferKeyViewModel9 = Enumerable.FirstOrDefault<HolooInvoiceInfoListTransferKeyViewModel>((IEnumerable<HolooInvoiceInfoListTransferKeyViewModel>)transferkeys, (Func<HolooInvoiceInfoListTransferKeyViewModel, bool>)((HolooInvoiceInfoListTransferKeyViewModel m) => m.OrderId == oId));
					if (holooInvoiceInfoListTransferKeyViewModel9 != null)
					{
						text24 = holooInvoiceInfoListTransferKeyViewModel9.TransferKey ?? "";
					}
				}
				string[] obj6 = new string[7]
				{
					Messages.msgErrorRunFunction,
					"<br>",
					Messages.msgErrorEditInfo,
					" ",
					Labels.OtherSystemsOrder,
					"<br>",
					null
				};
				_ = httpResponseMessage.StatusCode;
				statusCode = httpResponseMessage.StatusCode;
				obj6[6] = " code:" + ((object)(HttpStatusCode)(ref statusCode)).ToString();
				string message11 = string.Concat(obj6);
				text25 = JsonConvert.SerializeObject(new HolooInvoiceInfoIETransferResultViewModel
				{
					DBId = linkAccSettingDBId,
					Message = message11
				});
				if (!string.IsNullOrWhiteSpace(text25))
				{
					if (!text25.StartsWith("["))
					{
						text25 = "[" + text25;
					}
					if (!text25.EndsWith("]"))
					{
						text25 += "]";
					}
				}
				text23 = text23 + "[OrdId=" + ((!string.IsNullOrEmpty(item5.id)) ? item5.id : "0") + "|,|LinkAccTransferKey=" + ((!string.IsNullOrWhiteSpace(text24)) ? text24 : "") + "|,|LinkAccTransferResult=" + text25 + "|,|]@";
				if (!string.IsNullOrEmpty(text23))
				{
					Enumerable.FirstOrDefault<mct_Link_Result>((IEnumerable<mct_Link_Result>)_dbLink.CRMspLkHolooWSUpdateOrderLinkAccFields(text23, linkAccSettingDBId));
				}
			}
		}

		public void GetOrderList(int ordType, int currLangId, int defLangId, ref HolooInvoiceViewModel model, string strParam, ref string errorMessage, string ordNumber = "")
		{
			if (string.IsNullOrWhiteSpace(Token))
			{
				return;
			}
			HttpClient httpClient = new HttpClient();
			if (OrderTimeOut != 0)
			{
				httpClient.Timeout = TimeSpan.FromMinutes(OrderTimeOut);
			}
			httpClient.BaseAddress = new Uri(ApiAddress);
			httpClient.DefaultRequestHeaders.Add("Authorization", Token);
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			string requestUri = "api/Invoice/Invoice" + strParam;
			HttpResponseMessage result = httpClient.GetAsync(requestUri).Result;
			if (result.IsSuccessStatusCode)
			{
				HolooInvoiceViewModel holooInvoiceViewModel = JsonConvert.DeserializeObject<HolooInvoiceViewModel>(result.Content.ReadAsStringAsync().Result);
				if (holooInvoiceViewModel != null)
				{
					List<WSspSelectOrderWithAccLinkField_Result> list = Enumerable.ToList<WSspSelectOrderWithAccLinkField_Result>((IEnumerable<WSspSelectOrderWithAccLinkField_Result>)_dbLink.WSspSelectOrderWithAccLinkField(withOrdLinkAccCode: false, withOrdLinkAccCodeId: false, withOrdLinkAccOrderId: false, withOrdLinkAccOrderIdStr: true, withOrdLinkAccOrderNumber: false, withOrdLinkAccVoucherId: false, withOrdLinkAccVoucherNumber: false, languageID: currLangId, defaultLanguageID: defLangId, linkAccSettingDBId: _LinkAccSettingDB.LinkAccSettingDBId));
					int num = 1;
					if (holooInvoiceViewModel.invoice == null)
					{
						return;
					}
					{
						foreach (HolooInvoiceListViewModel item in holooInvoiceViewModel.invoice)
						{
							HolooInvoiceListViewModel ord = new HolooInvoiceListViewModel();
							ord.Code = item.Code;
							ord.Type = item.Type;
							ord.SanadCode = item.SanadCode;
							ord.CustomerName = item.CustomerName;
							ord.CustomerErpCode = item.CustomerErpCode;
							ord.customerCodeC = item.customerCodeC;
							ord.Date = item.Date;
							ord.Time = item.Time;
							ord.SumNaghd = item.SumNaghd;
							ord.SumCard = item.SumCard;
							ord.SumNesiyeh = item.SumNesiyeh;
							ord.SumDiscount = item.SumDiscount;
							ord.SumCheck = item.SumCheck;
							ord.SumLevy = item.SumLevy;
							ord.SumScot = item.SumScot;
							ord.SumPrice = item.SumPrice;
							ord.ErpCode = item.ErpCode;
							ord.comment = item.comment;
							ord.tasviehdate = item.tasviehdate;
							ord.Detail = new List<HolooInvoiceDetailListViewModel>();
							if (item.Detail != null)
							{
								foreach (HolooInvoiceDetailListViewModel item2 in item.Detail)
								{
									HolooInvoiceDetailListViewModel holooInvoiceDetailListViewModel = new HolooInvoiceDetailListViewModel();
									holooInvoiceDetailListViewModel.Row = item2.Row;
									holooInvoiceDetailListViewModel.ProductCode = item2.ProductCode;
									holooInvoiceDetailListViewModel.ProductName = item2.ProductName;
									holooInvoiceDetailListViewModel.ProductErpCode = item2.ProductErpCode;
									holooInvoiceDetailListViewModel.Few = item2.Few;
									holooInvoiceDetailListViewModel.Karton = item2.Karton;
									holooInvoiceDetailListViewModel.Price = item2.Price;
									holooInvoiceDetailListViewModel.SumPrice = item2.SumPrice;
									holooInvoiceDetailListViewModel.Levy = item2.Levy;
									holooInvoiceDetailListViewModel.Scot = item2.Scot;
									holooInvoiceDetailListViewModel.PersentDiscount = item2.PersentDiscount;
									holooInvoiceDetailListViewModel.Discount = item2.Discount;
									ord.Detail.Add(holooInvoiceDetailListViewModel);
								}
							}
							if (!string.IsNullOrEmpty(ord.Date))
							{
								DateTime dateTime = DateTime.Parse(PersianDate.GetFormatetdDate(ord.Date.Replace("/", "")) + " 00:00:00", new CultureInfo("en-US"));
								ord.DatePersian = dateTime.ToString("yyyy/MM/dd");
							}
							if (list != null && Enumerable.Any<WSspSelectOrderWithAccLinkField_Result>((IEnumerable<WSspSelectOrderWithAccLinkField_Result>)list))
							{
								WSspSelectOrderWithAccLinkField_Result wSspSelectOrderWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectOrderWithAccLinkField_Result>((IEnumerable<WSspSelectOrderWithAccLinkField_Result>)list, (Func<WSspSelectOrderWithAccLinkField_Result, bool>)((WSspSelectOrderWithAccLinkField_Result m) => m.ordLinkAccOrderIdStr == ord.ErpCode));
								if (wSspSelectOrderWithAccLinkField_Result != null)
								{
									ord.OrderId = wSspSelectOrderWithAccLinkField_Result.OrderID;
								}
							}
							ord.RowNumber = num;
							model.invoice.Add(ord);
							num++;
						}
						return;
					}
				}
				Exception e = new Exception(Messages.msgErrorRunFunction + " (get order information from Holoo) ");
				ErrorSignal.FromCurrentContext().Raise(e);
			}
			else
			{
				Exception e2 = new Exception(Messages.msgErrorRunFunction + " (get order information from Holoo) ");
				ErrorSignal.FromCurrentContext().Raise(e2);
			}
		}

		public void CheckOrder(string strParam, int ordType, ref HolooInvoiceViewModel model, ref string errorMessage)
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (string.IsNullOrEmpty(Token))
			{
				return;
			}
			switch (ordType)
			{
			case 1:
				ordType = 2;
				break;
			case 2:
				ordType = 4;
				break;
			}
			HttpClient httpClient = new HttpClient();
			if (OrderTimeOut != 0)
			{
				httpClient.Timeout = TimeSpan.FromMinutes(OrderTimeOut);
			}
			httpClient.BaseAddress = new Uri(ApiAddress);
			httpClient.DefaultRequestHeaders.Add("Authorization", Token);
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			string requestUri = "api/Invoice/Invoice" + strParam;
			HttpResponseMessage result2 = httpClient.GetAsync(requestUri).Result;
			if (result2.IsSuccessStatusCode)
			{
				HolooInvoiceViewModel holooInvoiceViewModel = JsonConvert.DeserializeObject<HolooInvoiceViewModel>(result2.Content.ReadAsStringAsync().Result);
				if (holooInvoiceViewModel != null)
				{
					List<WSspSelectOrderWithAccLinkField_Result> list = Enumerable.ToList<WSspSelectOrderWithAccLinkField_Result>((IEnumerable<WSspSelectOrderWithAccLinkField_Result>)_dbLink.WSspSelectOrderWithAccLinkField(withOrdLinkAccCode: false, withOrdLinkAccCodeId: false, withOrdLinkAccOrderId: false, withOrdLinkAccOrderIdStr: true, withOrdLinkAccOrderNumber: false, withOrdLinkAccVoucherId: false, withOrdLinkAccVoucherNumber: false, languageID: lCID, defaultLanguageID: result, linkAccSettingDBId: null));
					int num = 1;
					if (holooInvoiceViewModel.invoice == null)
					{
						return;
					}
					{
						foreach (HolooInvoiceListViewModel item in holooInvoiceViewModel.invoice)
						{
							HolooInvoiceListViewModel ord = new HolooInvoiceListViewModel();
							ord.Code = item.Code;
							ord.Type = item.Type;
							ord.SanadCode = item.SanadCode;
							ord.CustomerName = item.CustomerName;
							ord.CustomerErpCode = item.CustomerErpCode;
							ord.Date = item.Date;
							ord.Time = item.Time;
							ord.SumNaghd = item.SumNaghd;
							ord.SumCard = item.SumCard;
							ord.SumNesiyeh = item.SumNesiyeh;
							ord.SumDiscount = item.SumDiscount;
							ord.SumCheck = item.SumCheck;
							ord.SumLevy = item.SumLevy;
							ord.SumScot = item.SumScot;
							ord.SumPrice = item.SumPrice;
							ord.ErpCode = item.ErpCode;
							ord.Detail = new List<HolooInvoiceDetailListViewModel>();
							if (item.Detail != null)
							{
								foreach (HolooInvoiceDetailListViewModel item2 in item.Detail)
								{
									HolooInvoiceDetailListViewModel holooInvoiceDetailListViewModel = new HolooInvoiceDetailListViewModel();
									holooInvoiceDetailListViewModel.Row = item2.Row;
									holooInvoiceDetailListViewModel.ProductCode = item2.ProductCode;
									holooInvoiceDetailListViewModel.ProductName = item2.ProductName;
									holooInvoiceDetailListViewModel.ProductErpCode = item2.ProductErpCode;
									holooInvoiceDetailListViewModel.Few = item2.Few;
									holooInvoiceDetailListViewModel.Karton = item2.Karton;
									holooInvoiceDetailListViewModel.Price = item2.Price;
									holooInvoiceDetailListViewModel.SumPrice = item2.SumPrice;
									holooInvoiceDetailListViewModel.Levy = item2.Levy;
									holooInvoiceDetailListViewModel.Scot = item2.Scot;
									holooInvoiceDetailListViewModel.PersentDiscount = item2.PersentDiscount;
									holooInvoiceDetailListViewModel.Discount = item2.Discount;
									ord.Detail.Add(holooInvoiceDetailListViewModel);
								}
							}
							if (!string.IsNullOrEmpty(ord.Date))
							{
								DateTime dateTime = DateTime.Parse(PersianDate.GetFormatetdDate(ord.Date.Replace("/", "")) + " 00:00:00", new CultureInfo("en-US"));
								ord.DatePersian = dateTime.ToString("yyyy/MM/dd");
							}
							if (list != null && Enumerable.Any<WSspSelectOrderWithAccLinkField_Result>((IEnumerable<WSspSelectOrderWithAccLinkField_Result>)list))
							{
								WSspSelectOrderWithAccLinkField_Result wSspSelectOrderWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectOrderWithAccLinkField_Result>((IEnumerable<WSspSelectOrderWithAccLinkField_Result>)list, (Func<WSspSelectOrderWithAccLinkField_Result, bool>)((WSspSelectOrderWithAccLinkField_Result m) => m.ordLinkAccOrderIdStr == ord.ErpCode));
								if (wSspSelectOrderWithAccLinkField_Result != null)
								{
									ord.OrderId = wSspSelectOrderWithAccLinkField_Result.OrderID;
								}
							}
							ord.RowNumber = num;
							model.invoice.Add(ord);
							num++;
						}
						return;
					}
				}
				Exception e = new Exception(Messages.msgErrorRunFunction + " (get order information from Holoo) ");
				ErrorSignal.FromCurrentContext().Raise(e);
				errorMessage = "Error";
			}
			else
			{
				Exception e2 = new Exception(Messages.msgErrorRunFunction + " (get order information from Holoo) ");
				ErrorSignal.FromCurrentContext().Raise(e2);
				errorMessage = "Error";
			}
		}

		public void SendPreOrderToAcc(HolooInvoiceIEViewModel invoice, CRMspLkHolooWSSelectOrderByOrdIds_Result ord, ref string ordLinkAccTransferKey, ref bool isReCheckSent, ref string errorMessage, ref string code)
		{
			//IL_0579: Unknown result type (might be due to invalid IL or missing references)
			//IL_0586: Unknown result type (might be due to invalid IL or missing references)
			//IL_058b: Unknown result type (might be due to invalid IL or missing references)
			_003C_003Ec__DisplayClass135_0 _003C_003Ec__DisplayClass135_ = new _003C_003Ec__DisplayClass135_0();
			_003C_003Ec__DisplayClass135_.ord = ord;
			if (string.IsNullOrEmpty(Token))
			{
				return;
			}
			HttpClient httpClient = new HttpClient();
			if (PreOrderTimeOut != 0)
			{
				httpClient.Timeout = TimeSpan.FromMinutes(PreOrderTimeOut);
			}
			httpClient.BaseAddress = new Uri(ApiAddress);
			httpClient.DefaultRequestHeaders.Add("Authorization", Token);
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			string requestUri = "api/Invoice/PreInvoice";
			string text = JsonConvert.SerializeObject(invoice);
			text = " " + text;
			text = text.Replace(",\"midManErpCode\":null,", "").Replace("\"midManErpCode\":null", "");
			text = text.Replace("\"commission\":null,", "").Replace("\"commission\":null", "");
			text = text.Replace(",\"unitid\":null,", "").Replace(",\"unitid\":null", "").Replace("\"unitid\":null", "");
			HttpContent content = new StringContent(text, Encoding.UTF8, "application/json");
			HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
			httpResponseMessage = httpClient.PostAsync(requestUri, content).Result;
			int linkAccSettingDBId = _LinkAccSettingDB.LinkAccSettingDBId;
			if (httpResponseMessage.IsSuccessStatusCode)
			{
				HolooInvoiceInfoIEResultViewModel holooInvoiceInfoIEResultViewModel = JsonConvert.DeserializeObject<HolooInvoiceInfoIEResultViewModel>(httpResponseMessage.Content.ReadAsStringAsync().Result);
				if (holooInvoiceInfoIEResultViewModel != null)
				{
					if (holooInvoiceInfoIEResultViewModel.Success != null)
					{
						if (string.IsNullOrEmpty(holooInvoiceInfoIEResultViewModel.Success.ErpCode))
						{
							errorMessage = string.Format(Messages.msgErrorOtherSystemsNotRegistered, Labels.OtherSystemsOrder, Labels.Holoo) + "|";
						}
						string text2 = "";
						text2 = holooInvoiceInfoIEResultViewModel.Success.Code;
						string text3 = "";
						text3 = holooInvoiceInfoIEResultViewModel.Success.SanadCode;
						string erpCode = holooInvoiceInfoIEResultViewModel.Success.ErpCode;
						DbSet<WSOrder> wSOrder = _dbTbl.WSOrder;
						ParameterExpression val = Expression.Parameter(typeof(WSOrder), "c");
						if (Queryable.FirstOrDefault<WSOrder>((IQueryable<WSOrder>)wSOrder, Expression.Lambda<Func<WSOrder, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass135_, typeof(_003C_003Ec__DisplayClass135_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) != null)
						{
							string message = "Ok";
							string text4 = JsonConvert.SerializeObject(new HolooInvoiceInfoIETransferResultViewModel
							{
								DBId = linkAccSettingDBId,
								Message = message
							});
							if (!string.IsNullOrWhiteSpace(text4))
							{
								if (!text4.StartsWith("["))
								{
									text4 = "[" + text4;
								}
								if (!text4.EndsWith("]"))
								{
									text4 += "]";
								}
							}
							string text5 = "[PordId=" + _003C_003Ec__DisplayClass135_.ord.OrderID + "|,|LinkAccPordNumber =" + ((!string.IsNullOrWhiteSpace(text2)) ? text2 : "") + "|,|LinkAccVoucherNumber =" + ((!string.IsNullOrWhiteSpace(text3)) ? text3 : "") + "|,|LinkAccPordIdStr=" + ((!string.IsNullOrWhiteSpace(erpCode)) ? erpCode : "") + "|,|LinkAccTransferKey=" + ((!string.IsNullOrWhiteSpace(ordLinkAccTransferKey)) ? ordLinkAccTransferKey : "") + "|,|LinkAccTransferResult=" + text4 + "|,|]@";
							if (!string.IsNullOrEmpty(text5))
							{
								mct_Link_Result mct_Link_Result = Enumerable.FirstOrDefault<mct_Link_Result>((IEnumerable<mct_Link_Result>)_dbLink.CRMspLkHolooWSUpdateOrderLinkAccFields(text5, linkAccSettingDBId));
								if (mct_Link_Result != null && mct_Link_Result.Result > 0)
								{
									code = text3 ?? "";
									isReCheckSent = false;
								}
								else
								{
									errorMessage = Messages.ErrorNotFound + Labels.OtherSystemsOrder + "|";
								}
							}
							else
							{
								errorMessage = Messages.ErrorNotFound + Labels.OtherSystemsOrder + "|";
							}
						}
						else
						{
							errorMessage = Messages.ErrorNotFound + Labels.OtherSystemsOrder + "|";
						}
						code = text3 ?? "";
					}
					else if (holooInvoiceInfoIEResultViewModel.Failure != null)
					{
						string[] obj = new string[10]
						{
							Messages.msgErrorRunFunction,
							"<br>",
							Messages.msgErrorInSendToOtherSystem,
							" ",
							Labels.OtherSystemsOrder,
							"<br>",
							holooInvoiceInfoIEResultViewModel.Failure.Error,
							"<br>",
							null,
							null
						};
						_ = holooInvoiceInfoIEResultViewModel.Failure.ErrorCode;
						obj[8] = " code:" + holooInvoiceInfoIEResultViewModel.Failure.ErrorCode;
						obj[9] = "|";
						errorMessage = string.Concat(obj);
					}
					else
					{
						errorMessage = Messages.msgErrorRunFunction + "<br>" + Messages.msgErrorInSendToOtherSystem + " " + Labels.OtherSystemsOrder + "|";
					}
				}
				else
				{
					errorMessage = Messages.msgErrorRunFunction + "<br>" + Messages.msgErrorInSendToOtherSystem + " " + Labels.OtherSystemsOrder + "|";
				}
			}
			else
			{
				string[] obj2 = new string[8]
				{
					Messages.msgErrorRunFunction,
					"<br>",
					Messages.msgErrorEditInfo,
					" ",
					Labels.OtherSystemsOrder,
					"<br>",
					null,
					null
				};
				_ = httpResponseMessage.StatusCode;
				HttpStatusCode statusCode = httpResponseMessage.StatusCode;
				obj2[6] = " code:" + ((object)(HttpStatusCode)(ref statusCode)).ToString();
				obj2[7] = "|";
				errorMessage = string.Concat(obj2);
			}
		}

		public void ImportProduct(string strParam, int currLangId, int defLangId, ref string errorMessage, ref List<HolooProductInfoViewModel> list)
		{
			if (string.IsNullOrWhiteSpace(Token))
			{
				return;
			}
			HttpClient httpClient = new HttpClient();
			if (ProductTimeOut != 0)
			{
				httpClient.Timeout = TimeSpan.FromMinutes(ProductTimeOut);
			}
			httpClient.BaseAddress = new Uri(ApiAddress);
			httpClient.DefaultRequestHeaders.Add("Authorization", Token);
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			string requestUri = "api/Product" + strParam;
			HttpResponseMessage result = httpClient.GetAsync(requestUri).Result;
			if (result.IsSuccessStatusCode)
			{
				HolooProductListViewModel holooProductListViewModel = JsonConvert.DeserializeObject<HolooProductListViewModel>(result.Content.ReadAsStringAsync().Result);
				if (holooProductListViewModel != null)
				{
					List<CRMspSelectProductWithAccLinkField_Result> list2 = Enumerable.ToList<CRMspSelectProductWithAccLinkField_Result>((IEnumerable<CRMspSelectProductWithAccLinkField_Result>)_dbLink.CRMspSelectProductWithAccLinkField(false, false, true, currLangId, defLangId, _LinkAccSettingDB.LinkAccSettingDBId));
					int num = 1;
					if (holooProductListViewModel.product == null)
					{
						return;
					}
					{
						foreach (HolooProductInfoViewModel item in holooProductListViewModel.product)
						{
							HolooProductInfoViewModel prd = new HolooProductInfoViewModel();
							prd.Code = item.Code;
							prd.Name = item.Name;
							prd.ErpCode = item.ErpCode;
							if (list2 != null && Enumerable.Any<CRMspSelectProductWithAccLinkField_Result>((IEnumerable<CRMspSelectProductWithAccLinkField_Result>)list2))
							{
								CRMspSelectProductWithAccLinkField_Result cRMspSelectProductWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectProductWithAccLinkField_Result>((IEnumerable<CRMspSelectProductWithAccLinkField_Result>)list2, (Func<CRMspSelectProductWithAccLinkField_Result, bool>)((CRMspSelectProductWithAccLinkField_Result m) => m.PrdLinkAccPrdIdStr == prd.ErpCode));
								if (cRMspSelectProductWithAccLinkField_Result != null)
								{
									prd.ProductId = cRMspSelectProductWithAccLinkField_Result.ProductID;
								}
							}
							prd.RowNumber = num;
							list.Add(prd);
							num++;
						}
						return;
					}
				}
				Exception e = new Exception(Messages.msgErrorRunFunction + " (get list from Holoo) ");
				ErrorSignal.FromCurrentContext().Raise(e);
				errorMessage = "Error";
			}
			else
			{
				Exception e2 = new Exception(Messages.msgErrorRunFunction + " (get list from Holoo) ");
				ErrorSignal.FromCurrentContext().Raise(e2);
				errorMessage = "Error";
			}
		}

		public void ImportProductInfo(string strParam, int currLangId, int defLangId, List<OtherSystemSelectedVIiewModel> selectedRow, ref string errorMessage, ref List<HolooProductInfoViewModel> list)
		{
			//IL_01df: Unknown result type (might be due to invalid IL or missing references)
			//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
			if (string.IsNullOrWhiteSpace(Token))
			{
				return;
			}
			HttpClient httpClient = new HttpClient();
			if (ProductTimeOut != 0)
			{
				httpClient.Timeout = TimeSpan.FromMinutes(ProductTimeOut);
			}
			httpClient.BaseAddress = new Uri(ApiAddress);
			httpClient.DefaultRequestHeaders.Add("Authorization", Token);
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			string requestUri = "api/Product" + strParam;
			HttpResponseMessage result = httpClient.GetAsync(requestUri).Result;
			if (result.IsSuccessStatusCode)
			{
				HolooProductListViewModel holooProductListViewModel = JsonConvert.DeserializeObject<HolooProductListViewModel>(result.Content.ReadAsStringAsync().Result);
				if (holooProductListViewModel != null)
				{
					List<CRMspSelectProductWithAccLinkField_Result> list2 = Enumerable.ToList<CRMspSelectProductWithAccLinkField_Result>((IEnumerable<CRMspSelectProductWithAccLinkField_Result>)_dbLink.CRMspSelectProductWithAccLinkField(false, false, true, currLangId, defLangId, _LinkAccSettingDB.LinkAccSettingDBId));
					if (holooProductListViewModel.product == null)
					{
						return;
					}
					{
						foreach (HolooProductInfoViewModel item in holooProductListViewModel.product)
						{
							if (selectedRow == null || Enumerable.FirstOrDefault<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)selectedRow, (Func<OtherSystemSelectedVIiewModel, bool>)((OtherSystemSelectedVIiewModel m) => m.Id == item.ErpCode)) == null)
							{
								continue;
							}
							if (list2 != null && Enumerable.Any<CRMspSelectProductWithAccLinkField_Result>((IEnumerable<CRMspSelectProductWithAccLinkField_Result>)list2))
							{
								CRMspSelectProductWithAccLinkField_Result cRMspSelectProductWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectProductWithAccLinkField_Result>((IEnumerable<CRMspSelectProductWithAccLinkField_Result>)list2, (Func<CRMspSelectProductWithAccLinkField_Result, bool>)((CRMspSelectProductWithAccLinkField_Result m) => m.PrdLinkAccPrdIdStr == item.ErpCode));
								if (cRMspSelectProductWithAccLinkField_Result != null)
								{
									item.ProductId = cRMspSelectProductWithAccLinkField_Result.ProductID;
								}
							}
							list.Add(item);
						}
						return;
					}
				}
				string text = Messages.msgErrorRunFunction + " (get list from Holoo) ";
				Exception e = new Exception(text);
				ErrorSignal.FromCurrentContext().Raise(e);
				errorMessage = text;
			}
			else
			{
				string msgErrorRunFunction = Messages.msgErrorRunFunction;
				_ = result.StatusCode;
				HttpStatusCode statusCode = result.StatusCode;
				string text2 = string.Concat(msgErrorRunFunction, " (get list from Holoo) ", " code:" + ((object)(HttpStatusCode)(ref statusCode)).ToString());
				Exception e2 = new Exception(text2);
				ErrorSignal.FromCurrentContext().Raise(e2);
				errorMessage = text2;
			}
		}

		public void GetHolooImportProductList(string strParam, int currLangId, int defLangId, ref string errorMessage, ref List<HolooProductInfoViewModel> list)
		{
			//IL_0224: Unknown result type (might be due to invalid IL or missing references)
			//IL_0230: Unknown result type (might be due to invalid IL or missing references)
			//IL_0235: Unknown result type (might be due to invalid IL or missing references)
			if (string.IsNullOrWhiteSpace(Token))
			{
				return;
			}
			HttpClient httpClient = new HttpClient();
			httpClient.BaseAddress = new Uri(ApiAddress);
			httpClient.DefaultRequestHeaders.Add("Authorization", Token);
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			string requestUri = "api/Product" + strParam;
			if (ProductTimeOut != 0)
			{
				httpClient.Timeout = TimeSpan.FromMinutes(ProductTimeOut);
			}
			HttpResponseMessage result = httpClient.GetAsync(requestUri).Result;
			if (result.IsSuccessStatusCode)
			{
				HolooProductListViewModel holooProductListViewModel = JsonConvert.DeserializeObject<HolooProductListViewModel>(result.Content.ReadAsStringAsync().Result);
				if (holooProductListViewModel != null)
				{
					List<CRMspSelectProductWithAccLinkField_Result> list2 = Enumerable.ToList<CRMspSelectProductWithAccLinkField_Result>((IEnumerable<CRMspSelectProductWithAccLinkField_Result>)_dbLink.CRMspSelectProductWithAccLinkField(false, false, true, currLangId, defLangId, _LinkAccSettingDB.LinkAccSettingDBId));
					int num = 1;
					if (holooProductListViewModel.product == null)
					{
						return;
					}
					{
						foreach (HolooProductInfoViewModel item in holooProductListViewModel.product)
						{
							HolooProductInfoViewModel prd = new HolooProductInfoViewModel();
							prd.Code = item.Code;
							prd.Name = item.Name;
							prd.ErpCode = item.ErpCode;
							if (list2 != null && Enumerable.Any<CRMspSelectProductWithAccLinkField_Result>((IEnumerable<CRMspSelectProductWithAccLinkField_Result>)list2))
							{
								CRMspSelectProductWithAccLinkField_Result cRMspSelectProductWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectProductWithAccLinkField_Result>((IEnumerable<CRMspSelectProductWithAccLinkField_Result>)list2, (Func<CRMspSelectProductWithAccLinkField_Result, bool>)((CRMspSelectProductWithAccLinkField_Result m) => m.PrdLinkAccPrdIdStr == prd.ErpCode));
								if (cRMspSelectProductWithAccLinkField_Result != null)
								{
									prd.ProductId = cRMspSelectProductWithAccLinkField_Result.ProductID;
								}
							}
							prd.RowNumber = num;
							list.Add(prd);
							num++;
						}
						return;
					}
				}
				Exception e = new Exception(Messages.msgErrorRunFunction + " (get list from Holoo) ");
				ErrorSignal.FromCurrentContext().Raise(e);
				errorMessage = "Error";
			}
			else
			{
				string msgErrorRunFunction = Messages.msgErrorRunFunction;
				_ = result.StatusCode;
				HttpStatusCode statusCode = result.StatusCode;
				Exception e2 = new Exception(string.Concat(msgErrorRunFunction, " (get list from Holoo) ", " code:" + ((object)(HttpStatusCode)(ref statusCode)).ToString()));
				ErrorSignal.FromCurrentContext().Raise(e2);
				errorMessage = "Error";
			}
		}

		public void GetPrdMainGroup(ref List<SelectListItem> listItems, ref string errorMessage)
		{
			if (string.IsNullOrWhiteSpace(Token))
			{
				return;
			}
			HttpClient httpClient = new HttpClient();
			if (ProductTimeOut != 0)
			{
				httpClient.Timeout = TimeSpan.FromMinutes(ProductTimeOut);
			}
			httpClient.BaseAddress = new Uri(ApiAddress);
			httpClient.DefaultRequestHeaders.Add("Authorization", Token);
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			string requestUri = "api/MainGroup";
			HttpResponseMessage result = httpClient.GetAsync(requestUri).Result;
			if (result.IsSuccessStatusCode)
			{
				HolooProductMainGroupViewModel holooProductMainGroupViewModel = JsonConvert.DeserializeObject<HolooProductMainGroupViewModel>(result.Content.ReadAsStringAsync().Result);
				if (holooProductMainGroupViewModel != null)
				{
					if (holooProductMainGroupViewModel.mainGroup != null)
					{
						foreach (HolooProductMainGroupListViewModel item in holooProductMainGroupViewModel.mainGroup)
						{
							SelectListItem selectListItem = new SelectListItem();
							selectListItem.Text = item.Name ?? "";
							selectListItem.Value = item.ErpCode;
							selectListItem.Selected = false;
							listItems.Add(selectListItem);
						}
						return;
					}
					Exception e = new Exception(Messages.msgErrorRunFunction + " (list is empty) ");
					ErrorSignal.FromCurrentContext().Raise(e);
					errorMessage = "Error";
				}
				else
				{
					Exception e2 = new Exception(Messages.msgErrorRunFunction + " (list is empty) ");
					ErrorSignal.FromCurrentContext().Raise(e2);
					errorMessage = "Error";
				}
			}
			else
			{
				Exception e3 = new Exception(Messages.msgErrorRunFunction + " (get list from Holoo) ");
				ErrorSignal.FromCurrentContext().Raise(e3);
				errorMessage = "Error";
			}
		}

		public void GetHolooPrdSideGroup(string mGroupErpCode, ref List<SelectListItem> listItems, ref string errorMessage)
		{
			if (string.IsNullOrWhiteSpace(Token))
			{
				return;
			}
			HttpClient httpClient = new HttpClient();
			if (ProductTimeOut != 0)
			{
				httpClient.Timeout = TimeSpan.FromMinutes(ProductTimeOut);
			}
			httpClient.BaseAddress = new Uri(ApiAddress);
			httpClient.DefaultRequestHeaders.Add("Authorization", Token);
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			string requestUri = "api/SideGroup";
			HttpResponseMessage result = httpClient.GetAsync(requestUri).Result;
			if (result.IsSuccessStatusCode)
			{
				HolooProductSideGroupViewModel holooProductSideGroupViewModel = JsonConvert.DeserializeObject<HolooProductSideGroupViewModel>(result.Content.ReadAsStringAsync().Result);
				if (holooProductSideGroupViewModel != null)
				{
					if (holooProductSideGroupViewModel.sideGroup != null)
					{
						List<HolooProductSideGroupListViewModel> list = Enumerable.ToList<HolooProductSideGroupListViewModel>(Enumerable.Where<HolooProductSideGroupListViewModel>((IEnumerable<HolooProductSideGroupListViewModel>)holooProductSideGroupViewModel.sideGroup, (Func<HolooProductSideGroupListViewModel, bool>)((HolooProductSideGroupListViewModel m) => m.MainErpCode == mGroupErpCode)));
						if (list == null)
						{
							return;
						}
						{
							foreach (HolooProductSideGroupListViewModel item in list)
							{
								SelectListItem selectListItem = new SelectListItem();
								selectListItem.Text = item.Name ?? "";
								selectListItem.Value = item.ErpCode;
								selectListItem.Selected = false;
								listItems.Add(selectListItem);
							}
							return;
						}
					}
					Exception e = new Exception(Messages.msgErrorRunFunction + " (list is empty) ");
					ErrorSignal.FromCurrentContext().Raise(e);
					errorMessage = "Error";
				}
				else
				{
					Exception e2 = new Exception(Messages.msgErrorRunFunction + " (list is empty) ");
					ErrorSignal.FromCurrentContext().Raise(e2);
					errorMessage = "Error";
				}
			}
			else
			{
				Exception e3 = new Exception(Messages.msgErrorRunFunction + " (get list from Holoo) ");
				ErrorSignal.FromCurrentContext().Raise(e3);
				errorMessage = "Error";
			}
		}

		public string GetPrdQuantity(CRMspLkHolooSelectProductWithLinkAccFields_Result prd, string prdInvStockDisplayType, ref string errorMessage)
		{
			string result = "";
			if (!string.IsNullOrWhiteSpace(Token))
			{
				string text = "?code=" + prd.Code;
				if (!string.IsNullOrWhiteSpace(prd.FGLinkAccGroupIdStr))
				{
					text = text + "&maingrouperpcode=" + prd.FGLinkAccGroupIdStr;
				}
				if (!string.IsNullOrWhiteSpace(prd.SGLinkAccGroupIdStr))
				{
					text = text + "&sidegrouperpcode=" + prd.SGLinkAccGroupIdStr;
				}
				HttpClient httpClient = new HttpClient();
				if (ProductTimeOut != 0)
				{
					httpClient.Timeout = TimeSpan.FromMinutes(ProductTimeOut);
				}
				httpClient.BaseAddress = new Uri(ApiAddress);
				httpClient.DefaultRequestHeaders.Add("Authorization", Token);
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				string requestUri = "api/Product" + text;
				HttpResponseMessage result2 = httpClient.GetAsync(requestUri).Result;
				if (result2.IsSuccessStatusCode)
				{
					HolooProductListViewModel holooProductListViewModel = JsonConvert.DeserializeObject<HolooProductListViewModel>(result2.Content.ReadAsStringAsync().Result);
					if (holooProductListViewModel != null)
					{
						if (holooProductListViewModel.product != null)
						{
							if (holooProductListViewModel.product.Count != 1)
							{
								Exception e = new Exception(Messages.msgErrorRunFunction + " (not find prodcut information from Holoo or find more one than) ");
								ErrorSignal.FromCurrentContext().Raise(e);
								errorMessage = Labels.frmError;
							}
							else
							{
								double valueOrDefault = holooProductListViewModel.product[0].Few.GetValueOrDefault();
								double valueOrDefault2 = holooProductListViewModel.product[0].fewspd.GetValueOrDefault();
								int result3 = 0;
								int.TryParse(prdInvStockDisplayType, out result3);
								result = ((result3 != 1) ? valueOrDefault.ToString() : valueOrDefault2.ToString());
							}
						}
					}
					else
					{
						Exception e2 = new Exception(Messages.msgErrorRunFunction + " (get product information from Holoo) ");
						ErrorSignal.FromCurrentContext().Raise(e2);
						errorMessage = Labels.frmError;
					}
				}
				else
				{
					Exception e3 = new Exception(Messages.msgErrorRunFunction + " (get product information from Holoo) ");
					ErrorSignal.FromCurrentContext().Raise(e3);
					errorMessage = Labels.frmError;
				}
			}
			return result;
		}

		public List<ProductQuantityLinkAccDataViewModel> GetPrdQuantityList(int prdId)
		{
			List<CRMspSelectLinkAccSettingDBIsActive_Result> linkAccSettingDBList = GetLinkAccSettingDBList(4);
			List<ProductQuantityLinkAccDataViewModel> list = new List<ProductQuantityLinkAccDataViewModel>();
			if (linkAccSettingDBList != null && Enumerable.Any<CRMspSelectLinkAccSettingDBIsActive_Result>((IEnumerable<CRMspSelectLinkAccSettingDBIsActive_Result>)linkAccSettingDBList))
			{
				int num = 0;
				foreach (CRMspSelectLinkAccSettingDBIsActive_Result item in linkAccSettingDBList)
				{
					ProductQuantityLinkAccDataViewModel productQuantityLinkAccDataViewModel = new ProductQuantityLinkAccDataViewModel
					{
						DBId = item.LinkAccSettingDBId,
						DbName = (item.LinkAccSettingDbName ?? ""),
						DbTitle = (item.LinkAccSettingDbTitle ?? "")
					};
					if (item.LinkAccSettingDBId != 0)
					{
						ProductController productController = new ProductController();
						int linkAccSettingDBId = item.LinkAccSettingDBId;
						string text = productController.HolooGetPrdQuantity(prdId, linkAccSettingDBId);
						if (Labels.frmError != text)
						{
							decimal result = default(decimal);
							decimal.TryParse(text, out result);
							productQuantityLinkAccDataViewModel.Quantity = decimal.Parse(text);
						}
						else
						{
							productQuantityLinkAccDataViewModel.Quantity = 0m;
						}
						list.Add(productQuantityLinkAccDataViewModel);
					}
					num++;
				}
			}
			return list;
		}

		public string GetPrdUnit(int linkAccSettingDBId = 0)
		{
			string text = "";
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int id = Financial.Get().Id;
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (!string.IsNullOrWhiteSpace(Token))
			{
				HttpClient httpClient = new HttpClient();
				if (ProductTimeOut != 0)
				{
					httpClient.Timeout = TimeSpan.FromMinutes(ProductTimeOut);
				}
				httpClient.BaseAddress = new Uri(ApiAddress);
				httpClient.DefaultRequestHeaders.Add("Authorization", Token);
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				string requestUri = "api/Unit";
				HttpResponseMessage result2 = httpClient.GetAsync(requestUri).Result;
				if (!result2.IsSuccessStatusCode)
				{
					return Messages.msgErrorRunFunction + " (get list from Holoo) ";
				}
				string result3 = result2.Content.ReadAsStringAsync().Result;
				if (string.IsNullOrEmpty(result3))
				{
					return Messages.msgErrorRunFunction + " (list is empty) ";
				}
				ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
				_dbLink.CRMspLkHolooWSInsertUpdateProductUnitsFromHoloo(result3, userId, value2, id, value, registerDatePersian, appType, result, objectParameter, linkAccSettingDBId);
				if (objectParameter.Value != null && !string.IsNullOrEmpty(objectParameter.Value.ToString()))
				{
					text = text + "<br>" + objectParameter.Value.ToString();
				}
				User.UpdateUsersMobBaseInfo("WSProductUnits");
				text = "1";
			}
			return text;
		}

		public void SendCmpToAcc(string urlParam, ref string errorMessage, ref string code, ref HolooCustInfoIEViewModel custinfo, CRMspLkHolooSelectCompanyByCmpIds_Result cmp, ref HolooCustomerInsertEditIViewModel<HolooCustInfoInsertViewModel> customerInfoReq_I, ref HolooCustomerInsertEditViewModel customerInfoReq, bool checkAction = true)
		{
			//IL_049f: Unknown result type (might be due to invalid IL or missing references)
			//IL_04ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_04b1: Unknown result type (might be due to invalid IL or missing references)
			if (string.IsNullOrEmpty(Token))
			{
				return;
			}
			HttpClient httpClient = new HttpClient();
			if (CompanyTimeOut != 0)
			{
				httpClient.Timeout = TimeSpan.FromMinutes(CompanyTimeOut);
			}
			httpClient.BaseAddress = new Uri(ApiAddress);
			httpClient.DefaultRequestHeaders.Add("Authorization", Token);
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			string text = "api/Customer";
			text += urlParam;
			string text2 = JsonConvert.SerializeObject(customerInfoReq);
			if (string.IsNullOrWhiteSpace(cmp.cmpLinkAccCustomerIdStr))
			{
				text2 = JsonConvert.SerializeObject(customerInfoReq_I);
			}
			if (!string.IsNullOrEmpty(custinfo.erpcode))
			{
				text2 = text2.Replace(",\"name\":\"-1\"", "");
			}
			HttpContent content = new StringContent(text2, Encoding.UTF8, "application/json");
			HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
			httpResponseMessage = (string.IsNullOrEmpty(custinfo.erpcode) ? httpClient.PostAsync(text, content).Result : httpClient.PutAsync(text, content).Result);
			if (httpResponseMessage.IsSuccessStatusCode)
			{
				HolooCustomerInsertEditResultViewModel holooCustomerInsertEditResultViewModel = JsonConvert.DeserializeObject<HolooCustomerInsertEditResultViewModel>(httpResponseMessage.Content.ReadAsStringAsync().Result);
				if (holooCustomerInsertEditResultViewModel != null)
				{
					if (holooCustomerInsertEditResultViewModel.Success != null)
					{
						_003C_003Ec__DisplayClass144_0 _003C_003Ec__DisplayClass144_ = new _003C_003Ec__DisplayClass144_0();
						if (string.IsNullOrEmpty(custinfo.erpcode))
						{
							if (string.IsNullOrEmpty(holooCustomerInsertEditResultViewModel.Success.ErpCode))
							{
								errorMessage = string.Format(Messages.msgErrorOtherSystemsNotRegistered, Labels.OtherSystemsCompany, Labels.Holoo) + "|";
							}
							else
							{
								custinfo.erpcode = holooCustomerInsertEditResultViewModel.Success.ErpCode;
							}
						}
						_003C_003Ec__DisplayClass144_.companyId = cmp.CompanyID;
						DbSet<CrmCompany> crmCompany = _dbTbl.CrmCompany;
						ParameterExpression val = Expression.Parameter(typeof(CrmCompany), "m");
						CrmCompany crmCompany2 = Queryable.FirstOrDefault<CrmCompany>((IQueryable<CrmCompany>)crmCompany, Expression.Lambda<Func<CrmCompany, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass144_, typeof(_003C_003Ec__DisplayClass144_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
						if (crmCompany2 != null)
						{
							string code2 = holooCustomerInsertEditResultViewModel.Success.Code;
							code2 = (string.IsNullOrWhiteSpace(holooCustomerInsertEditResultViewModel.Success.Code) ? crmCompany2.cmpLinkAccCode : Regex.Replace(holooCustomerInsertEditResultViewModel.Success.Code, "\\s+", ""));
							string linkAccFields = "[CmpId=" + ((!string.IsNullOrEmpty(_003C_003Ec__DisplayClass144_.companyId.ToString())) ? _003C_003Ec__DisplayClass144_.companyId.ToString() : "0") + "|,|LinkAccCode =" + ((!string.IsNullOrEmpty(code2)) ? code2 : "") + "|,|LinkAccId=" + ((!string.IsNullOrEmpty(holooCustomerInsertEditResultViewModel.Success.ErpCode)) ? holooCustomerInsertEditResultViewModel.Success.ErpCode : "") + "|,|]@";
							Enumerable.FirstOrDefault<mct_Link_Result>((IEnumerable<mct_Link_Result>)_dbLink.CRMspLkHolooUpdateCompanyLinkAccFields(linkAccFields, _LinkAccSettingDB.LinkAccSettingDBId));
							code = code2 ?? "";
						}
						else
						{
							errorMessage = Messages.msgErrorInSendToOtherSystem + " " + Labels.OtherSystemsCompany + "|";
						}
					}
					else if (holooCustomerInsertEditResultViewModel.Failure != null)
					{
						string[] obj = new string[10]
						{
							Messages.msgErrorRunFunction,
							"<br>",
							Messages.msgErrorInSendToOtherSystem,
							" ",
							Labels.OtherSystemsCompany,
							"<br>",
							holooCustomerInsertEditResultViewModel.Failure.Error,
							"<br>",
							null,
							null
						};
						_ = holooCustomerInsertEditResultViewModel.Failure.ErrorCode;
						obj[8] = " code:" + holooCustomerInsertEditResultViewModel.Failure.ErrorCode;
						obj[9] = "|";
						errorMessage = string.Concat(obj);
					}
					else
					{
						errorMessage = Messages.msgErrorRunFunction + "<br>" + Messages.msgErrorInSendToOtherSystem + " " + Labels.OtherSystemsCompany + "|";
					}
				}
				else
				{
					errorMessage = Messages.msgErrorRunFunction + "<br>" + Messages.msgErrorInSendToOtherSystem + " " + Labels.OtherSystemsCompany + "|";
				}
			}
			else
			{
				string[] obj2 = new string[8]
				{
					Messages.msgErrorRunFunction,
					"<br>",
					Messages.msgErrorEditInfo,
					" ",
					Labels.OtherSystemsCompany,
					"<br>",
					null,
					null
				};
				_ = httpResponseMessage.StatusCode;
				HttpStatusCode statusCode = httpResponseMessage.StatusCode;
				obj2[6] = " code:" + ((object)(HttpStatusCode)(ref statusCode)).ToString();
				obj2[7] = "|";
				errorMessage = string.Concat(obj2);
			}
		}

		public void CompanyExportInfoInsert(string urlParam, ref HolooCustomerInsertEditIViewModel<HolooCustInfoInsertViewModel> customerInfoReq, ref string errorMessage)
		{
			//IL_065c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0668: Unknown result type (might be due to invalid IL or missing references)
			//IL_066d: Unknown result type (might be due to invalid IL or missing references)
			if (string.IsNullOrEmpty(Token))
			{
				return;
			}
			HttpClient httpClient = new HttpClient();
			if (CompanyTimeOut != 0)
			{
				httpClient.Timeout = TimeSpan.FromMinutes(CompanyTimeOut);
			}
			httpClient.BaseAddress = new Uri(ApiAddress);
			httpClient.DefaultRequestHeaders.Add("Authorization", Token);
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			string text = "api/Customer";
			text += urlParam;
			HttpContent content = new StringContent(JsonConvert.SerializeObject(customerInfoReq), Encoding.UTF8, "application/json");
			HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
			httpResponseMessage = httpClient.PostAsync(text, content).Result;
			if (httpResponseMessage.IsSuccessStatusCode)
			{
				string result = httpResponseMessage.Content.ReadAsStringAsync().Result;
				if (Enumerable.Count<HolooCustInfoInsertViewModel>((IEnumerable<HolooCustInfoInsertViewModel>)customerInfoReq.custinfo) > 1)
				{
					HolooCustomersInsertEditResultViewModel holooCustomersInsertEditResultViewModel = JsonConvert.DeserializeObject<HolooCustomersInsertEditResultViewModel>(result);
					if (holooCustomersInsertEditResultViewModel != null)
					{
						string text2 = "";
						if (holooCustomersInsertEditResultViewModel.Success != null)
						{
							foreach (HolooCustomerInsertEditSuccessResultViewModel item in holooCustomersInsertEditResultViewModel.Success)
							{
								if (string.IsNullOrEmpty(item.ErpCode))
								{
									errorMessage = errorMessage + string.Format(Messages.msgErrorOtherSystemsNotRegistered, Labels.OtherSystemsCompany, Labels.Holoo) + "<br>";
									continue;
								}
								text2 = text2 + "[CmpId=" + ((!string.IsNullOrEmpty(item.Id)) ? item.Id : "0") + "|,|LinkAccCode =" + ((!string.IsNullOrEmpty(item.Code)) ? item.Code : "") + "|,|LinkAccId=" + ((!string.IsNullOrEmpty(item.ErpCode)) ? item.ErpCode : "") + "|,|]@";
							}
							if (!string.IsNullOrEmpty(text2))
							{
								mct_Link_Result mct_Link_Result = Enumerable.FirstOrDefault<mct_Link_Result>((IEnumerable<mct_Link_Result>)_dbLink.CRMspLkHolooUpdateCompanyLinkAccFields(text2, _LinkAccSettingDB.LinkAccSettingDBId));
								if (mct_Link_Result != null)
								{
									_ = mct_Link_Result.Result;
									_ = 0;
								}
							}
							else
							{
								errorMessage = errorMessage + string.Format(Messages.msgErrorOtherSystemsNotRegistered, Labels.OtherSystemsCompany, Labels.Holoo) + "<br>";
							}
							return;
						}
						if (holooCustomersInsertEditResultViewModel.Failure != null)
						{
							foreach (HolooCustomerInsertEditFailureResultViewModel item2 in holooCustomersInsertEditResultViewModel.Failure)
							{
								string[] obj = new string[11]
								{
									errorMessage,
									Messages.msgErrorRunFunction,
									"<br>",
									Messages.msgErrorInSendToOtherSystem,
									" ",
									Labels.OtherSystemsCompany,
									"<br>",
									item2.Error,
									"<br>",
									null,
									null
								};
								_ = item2.ErrorCode;
								obj[9] = " code:" + item2.ErrorCode;
								obj[10] = "<br>";
								errorMessage = string.Concat(obj);
							}
							return;
						}
						errorMessage = errorMessage + Messages.msgErrorRunFunction + "<br>" + Messages.msgErrorInSendToOtherSystem + " " + Labels.OtherSystemsCompany;
					}
					else
					{
						errorMessage = errorMessage + Messages.msgErrorRunFunction + "<br>" + Messages.msgErrorInSendToOtherSystem + " " + Labels.OtherSystemsCompany;
					}
					return;
				}
				HolooCustomerInsertEditResultViewModel holooCustomerInsertEditResultViewModel = JsonConvert.DeserializeObject<HolooCustomerInsertEditResultViewModel>(result);
				if (holooCustomerInsertEditResultViewModel != null)
				{
					string text3 = "";
					if (holooCustomerInsertEditResultViewModel.Success != null)
					{
						if (string.IsNullOrEmpty(holooCustomerInsertEditResultViewModel.Success.ErpCode))
						{
							errorMessage = errorMessage + string.Format(Messages.msgErrorOtherSystemsNotRegistered, Labels.OtherSystemsCompany, Labels.Holoo) + "<br>";
						}
						else
						{
							text3 = text3 + "[CmpId=" + ((!string.IsNullOrEmpty(holooCustomerInsertEditResultViewModel.Success.Id)) ? holooCustomerInsertEditResultViewModel.Success.Id : "0") + "|,|LinkAccCode =" + ((!string.IsNullOrEmpty(holooCustomerInsertEditResultViewModel.Success.Code)) ? holooCustomerInsertEditResultViewModel.Success.Code : "") + "|,|LinkAccId=" + ((!string.IsNullOrEmpty(holooCustomerInsertEditResultViewModel.Success.ErpCode)) ? holooCustomerInsertEditResultViewModel.Success.ErpCode : "") + "|,|]@";
						}
						if (!string.IsNullOrEmpty(text3))
						{
							mct_Link_Result mct_Link_Result2 = Enumerable.FirstOrDefault<mct_Link_Result>((IEnumerable<mct_Link_Result>)_dbLink.CRMspLkHolooUpdateCompanyLinkAccFields(text3, _LinkAccSettingDB.LinkAccSettingDBId));
							if (mct_Link_Result2 != null)
							{
								_ = mct_Link_Result2.Result;
								_ = 0;
							}
						}
						else
						{
							errorMessage = errorMessage + string.Format(Messages.msgErrorOtherSystemsNotRegistered, Labels.OtherSystemsCompany, Labels.Holoo) + "<br>";
						}
					}
					else if (holooCustomerInsertEditResultViewModel.Failure != null)
					{
						string[] obj2 = new string[11]
						{
							errorMessage,
							Messages.msgErrorRunFunction,
							"<br>",
							Messages.msgErrorInSendToOtherSystem,
							" ",
							Labels.OtherSystemsCompany,
							"<br>",
							holooCustomerInsertEditResultViewModel.Failure.Error,
							"<br>",
							null,
							null
						};
						_ = holooCustomerInsertEditResultViewModel.Failure.ErrorCode;
						obj2[9] = " code:" + holooCustomerInsertEditResultViewModel.Failure.ErrorCode;
						obj2[10] = "<br>";
						errorMessage = string.Concat(obj2);
					}
					else
					{
						errorMessage = errorMessage + Messages.msgErrorRunFunction + "<br>" + Messages.msgErrorInSendToOtherSystem + " " + Labels.OtherSystemsCompany;
					}
				}
				else
				{
					errorMessage = errorMessage + Messages.msgErrorRunFunction + "<br>" + Messages.msgErrorInSendToOtherSystem + " " + Labels.OtherSystemsCompany;
				}
			}
			else
			{
				string[] obj3 = new string[8]
				{
					errorMessage,
					Messages.msgErrorRunFunction,
					"<br>",
					Messages.msgErrorEditInfo,
					" ",
					Labels.OtherSystemsCompany,
					"<br>",
					null
				};
				_ = httpResponseMessage.StatusCode;
				HttpStatusCode statusCode = httpResponseMessage.StatusCode;
				obj3[7] = " code:" + ((object)(HttpStatusCode)(ref statusCode)).ToString();
				errorMessage = string.Concat(obj3);
			}
		}

		public void CompanyExportInfoEdit(string urlParam, ref HolooCustomerInsertEditViewModel customerInfoReq, ref string errorMessage)
		{
			//IL_03b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c7: Unknown result type (might be due to invalid IL or missing references)
			if (string.IsNullOrEmpty(Token))
			{
				return;
			}
			HttpClient httpClient = new HttpClient();
			if (CompanyTimeOut != 0)
			{
				httpClient.Timeout = TimeSpan.FromMinutes(CompanyTimeOut);
			}
			httpClient.BaseAddress = new Uri(ApiAddress);
			httpClient.DefaultRequestHeaders.Add("Authorization", Token);
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			string text = "api/Customer";
			text += urlParam;
			HttpContent content = new StringContent(JsonConvert.SerializeObject(customerInfoReq).Replace(",\"name\":\"-1\"", ""), Encoding.UTF8, "application/json");
			HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
			httpResponseMessage = httpClient.PutAsync(text, content).Result;
			if (httpResponseMessage.IsSuccessStatusCode)
			{
				string result = httpResponseMessage.Content.ReadAsStringAsync().Result;
				if (Enumerable.Count<HolooCustInfoIEViewModel>((IEnumerable<HolooCustInfoIEViewModel>)customerInfoReq.custinfo) > 1)
				{
					HolooCustomersInsertEditResultViewModel holooCustomersInsertEditResultViewModel = JsonConvert.DeserializeObject<HolooCustomersInsertEditResultViewModel>(result);
					if (holooCustomersInsertEditResultViewModel != null)
					{
						if (holooCustomersInsertEditResultViewModel.Failure != null)
						{
							foreach (HolooCustomerInsertEditFailureResultViewModel item in holooCustomersInsertEditResultViewModel.Failure)
							{
								string[] obj = new string[11]
								{
									errorMessage,
									Messages.msgErrorRunFunction,
									"<br>",
									Messages.msgErrorInSendToOtherSystem,
									" ",
									Labels.OtherSystemsCompany,
									"<br>",
									item.Error,
									"<br>",
									null,
									null
								};
								_ = item.ErrorCode;
								obj[9] = " code:" + item.ErrorCode;
								obj[10] = "<br>";
								errorMessage = string.Concat(obj);
							}
							return;
						}
						if (holooCustomersInsertEditResultViewModel.Failure == null && holooCustomersInsertEditResultViewModel.Success == null)
						{
							errorMessage = errorMessage + Messages.msgErrorRunFunction + "<br>" + Messages.msgErrorInSendToOtherSystem + " " + Labels.OtherSystemsCompany;
						}
					}
					else
					{
						errorMessage = errorMessage + Messages.msgErrorRunFunction + "<br>" + Messages.msgErrorInSendToOtherSystem + " " + Labels.OtherSystemsCompany;
					}
					return;
				}
				HolooCustomerInsertEditResultViewModel holooCustomerInsertEditResultViewModel = JsonConvert.DeserializeObject<HolooCustomerInsertEditResultViewModel>(result);
				if (holooCustomerInsertEditResultViewModel != null)
				{
					if (holooCustomerInsertEditResultViewModel.Failure != null)
					{
						string[] obj2 = new string[11]
						{
							errorMessage,
							Messages.msgErrorRunFunction,
							"<br>",
							Messages.msgErrorInSendToOtherSystem,
							" ",
							Labels.OtherSystemsCompany,
							"<br>",
							holooCustomerInsertEditResultViewModel.Failure.Error,
							"<br>",
							null,
							null
						};
						_ = holooCustomerInsertEditResultViewModel.Failure.ErrorCode;
						obj2[9] = " code:" + holooCustomerInsertEditResultViewModel.Failure.ErrorCode;
						obj2[10] = "<br>";
						errorMessage = string.Concat(obj2);
					}
					else
					{
						errorMessage = errorMessage + Messages.msgErrorRunFunction + "<br>" + Messages.msgErrorInSendToOtherSystem + " " + Labels.OtherSystemsCompany;
					}
				}
				else
				{
					errorMessage = errorMessage + Messages.msgErrorRunFunction + "<br>" + Messages.msgErrorInSendToOtherSystem + " " + Labels.OtherSystemsCompany;
				}
			}
			else
			{
				string[] obj3 = new string[8]
				{
					errorMessage,
					Messages.msgErrorRunFunction,
					"<br>",
					Messages.msgErrorEditInfo,
					" ",
					Labels.OtherSystemsCompany,
					"<br>",
					null
				};
				_ = httpResponseMessage.StatusCode;
				HttpStatusCode statusCode = httpResponseMessage.StatusCode;
				obj3[7] = " code:" + ((object)(HttpStatusCode)(ref statusCode)).ToString();
				errorMessage = string.Concat(obj3);
			}
		}

		public void HolooCompanyList(string parameters, ref List<LkCompanyAndPersonViewModel> listItems, string fDate = "", string tDate = "", string code = "", string fCode = "", string tCode = "", string nationalid = "", string fEditDate = "", string tEditDate = "")
		{
			if (string.IsNullOrWhiteSpace(Token))
			{
				return;
			}
			HttpClient httpClient = new HttpClient();
			if (CompanyTimeOut != 0)
			{
				httpClient.Timeout = TimeSpan.FromMinutes(CompanyTimeOut);
			}
			httpClient.BaseAddress = new Uri(ApiAddress);
			httpClient.DefaultRequestHeaders.Add("Authorization", Token);
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			string requestUri = "api/Customer" + parameters;
			HttpResponseMessage result = httpClient.GetAsync(requestUri).Result;
			if (result.IsSuccessStatusCode)
			{
				HolooCustomerListViewModel holooCustomerListViewModel = JsonConvert.DeserializeObject<HolooCustomerListViewModel>(result.Content.ReadAsStringAsync().Result);
				if (holooCustomerListViewModel == null || holooCustomerListViewModel.Customer == null || !Enumerable.Any<HolooCustomerInfoViewModel>((IEnumerable<HolooCustomerInfoViewModel>)holooCustomerListViewModel.Customer))
				{
					return;
				}
				List<CRMspSelectCompanyWithAccLinkField_Result> list = SelectCompanyWithAccLinkField(withLinkAccCode: false, withLinkAccCodeId: false, withLinkCustomerId: false, withLinkCustomerIdStr: true);
				int num = 1;
				{
					foreach (HolooCustomerInfoViewModel item in holooCustomerListViewModel.Customer)
					{
						LkCompanyAndPersonViewModel lkCompanyAndPersonViewModel = new LkCompanyAndPersonViewModel();
						lkCompanyAndPersonViewModel.cmpName = item.Name;
						lkCompanyAndPersonViewModel.cmpTel = item.Tel;
						lkCompanyAndPersonViewModel.cmpFax = item.Fax;
						lkCompanyAndPersonViewModel.cmpAddress = item.Address;
						lkCompanyAndPersonViewModel.cmpZipCode = item.ZipCode;
						lkCompanyAndPersonViewModel.cmpEconomicCode = item.EconomicId;
						lkCompanyAndPersonViewModel.cmpNationalCode = item.NationalId;
						lkCompanyAndPersonViewModel.cmpLinkAccCode = item.Code;
						lkCompanyAndPersonViewModel.cmpLinkAccCustomerIdStr = item.ErpCode;
						lkCompanyAndPersonViewModel.CityName = item.City;
						lkCompanyAndPersonViewModel.ProvinceName = item.Ostan;
						int result2 = 0;
						int.TryParse(item.type.ToString(), out result2);
						if (result2 != 1)
						{
							lkCompanyAndPersonViewModel.cmpKind = 0;
						}
						else
						{
							lkCompanyAndPersonViewModel.cmpKind = 1;
						}
						lkCompanyAndPersonViewModel.prsMobile = item.Mobile;
						lkCompanyAndPersonViewModel.prsEmail = item.Email;
						lkCompanyAndPersonViewModel.RowNumber = num;
						CRMspSelectCompanyWithAccLinkField_Result cRMspSelectCompanyWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyWithAccLinkField_Result>((IEnumerable<CRMspSelectCompanyWithAccLinkField_Result>)list, (Func<CRMspSelectCompanyWithAccLinkField_Result, bool>)((CRMspSelectCompanyWithAccLinkField_Result x) => x.cmpLinkAccCustomerIdStr == item.ErpCode));
						if (cRMspSelectCompanyWithAccLinkField_Result != null && !string.IsNullOrWhiteSpace(cRMspSelectCompanyWithAccLinkField_Result.cmpLinkAccCustomerIdStr))
						{
							lkCompanyAndPersonViewModel.CompanyId = cRMspSelectCompanyWithAccLinkField_Result.CompanyID;
						}
						else
						{
							lkCompanyAndPersonViewModel.CompanyId = 0;
						}
						listItems.Add(lkCompanyAndPersonViewModel);
						num++;
					}
					return;
				}
			}
			Exception e = new Exception(Messages.msgErrorRunFunction + " (get customer information from Holoo) ");
			ErrorSignal.FromCurrentContext().Raise(e);
		}

		public void GetCmpAccountingDetail(string strParam, int countDecimal, ref string errorMessage, ref string result)
		{
			if (string.IsNullOrWhiteSpace(Token))
			{
				return;
			}
			HttpClient httpClient = new HttpClient();
			if (CompanyTimeOut != 0)
			{
				httpClient.Timeout = TimeSpan.FromMinutes(CompanyTimeOut);
			}
			httpClient.BaseAddress = new Uri(ApiAddress);
			httpClient.DefaultRequestHeaders.Add("Authorization", Token);
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			string requestUri = "api/Customer" + strParam;
			HttpResponseMessage result2 = httpClient.GetAsync(requestUri).Result;
			if (result2.IsSuccessStatusCode)
			{
				HolooCustomerListViewModel holooCustomerListViewModel = JsonConvert.DeserializeObject<HolooCustomerListViewModel>(result2.Content.ReadAsStringAsync().Result);
				if (holooCustomerListViewModel == null)
				{
					return;
				}
				if (holooCustomerListViewModel.Customer != null)
				{
					if (holooCustomerListViewModel.Customer.Count != 1)
					{
						Exception e = new Exception(Messages.msgErrorRunFunction + " (not find customer information from Holoo or find more one than) ");
						ErrorSignal.FromCurrentContext().Raise(e);
						errorMessage = Labels.frmError;
						return;
					}
					decimal valueOrDefault = holooCustomerListViewModel.Customer[0].Mandeh.GetValueOrDefault();
					switch (countDecimal)
					{
					case 0:
						result = $"{valueOrDefault:N0}";
						break;
					case -1:
						result = valueOrDefault.ToString();
						break;
					default:
						result = $"{valueOrDefault:N2}";
						break;
					}
				}
				else
				{
					result = "0";
				}
			}
			else
			{
				Exception e2 = new Exception(Messages.msgErrorRunFunction + " (get customer information from Holoo) ");
				ErrorSignal.FromCurrentContext().Raise(e2);
				errorMessage = Labels.frmError;
			}
		}

		public List<CRMspSelectCompanyWithAccLinkField_Result> SelectCompanyWithAccLinkField(bool withLinkAccCode = false, bool withLinkAccCodeId = false, bool withLinkCustomerId = false, bool withLinkCustomerIdStr = false)
		{
			List<CRMspSelectCompanyWithAccLinkField_Result> result = new List<CRMspSelectCompanyWithAccLinkField_Result>();
			try
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
				if (result2 <= 0)
				{
					result2 = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				result = Enumerable.ToList<CRMspSelectCompanyWithAccLinkField_Result>((IEnumerable<CRMspSelectCompanyWithAccLinkField_Result>)_dbLink.CRMspSelectCompanyWithAccLinkField(withLinkAccCode, withLinkAccCodeId, withLinkCustomerId, withLinkCustomerIdStr, lCID, result2, _LinkAccSettingDB.LinkAccSettingDBId));
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
			return result;
		}
	}

	public static bool UpdateLinkAccSettingPartValue(int linkAccSettingId, string partValue = "")
	{
		bool result = false;
		CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
		try
		{
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			_ = Financial.Get().Id;
			short value2 = short.Parse(Financial.Get().Id.ToString());
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			if (linkAccSettingId != 0)
			{
				cRMLinkSpEntities.CRMspUpdateLinkAccSettingPartValue(linkAccSettingId, partValue, userId, value2, value3, value, registerDatePersian, appType);
				result = true;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMLinkSpEntities.Dispose();
		}
		return result;
	}

	public static string GetLinkAccSettingPartValue(int linkAccSystemId, int linkAccSettingDBId, string partTitle, string objectType = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string result2 = "";
		CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
		try
		{
			if (string.IsNullOrWhiteSpace(objectType))
			{
				objectType = "Setting";
			}
			CRMspSelectLinkAccSetting_Result cRMspSelectLinkAccSetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)cRMLinkSpEntities.CRMspSelectLinkAccSetting(0, objectType, lCID, result, linkAccSystemId, linkAccSettingDBId, partTitle));
			if (cRMspSelectLinkAccSetting_Result != null)
			{
				result2 = cRMspSelectLinkAccSetting_Result.PartValue ?? "";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMLinkSpEntities.Dispose();
		}
		return result2;
	}

	public static CRMspSelectCompanyPersonsByID_Result GetCompanyPerson(int? cmpId = 0, int? prsId = 0)
	{
		CRMspSelectCompanyPersonsByID_Result cRMspSelectCompanyPersonsByID_Result = null;
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (cRMspSelectCompanyPersonsByID_Result == null && prsId.GetValueOrDefault() != 0)
			{
				cRMspSelectCompanyPersonsByID_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyPersonsByID_Result>((IEnumerable<CRMspSelectCompanyPersonsByID_Result>)cRMSpEntities.CRMspSelectCompanyPersonsByID(prsId, lCID, result));
			}
			if (cRMspSelectCompanyPersonsByID_Result == null && cmpId.GetValueOrDefault() != 0)
			{
				CRMspSelectCompanyPersonTop1ByOrderView_Result cRMspSelectCompanyPersonTop1ByOrderView_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyPersonTop1ByOrderView_Result>((IEnumerable<CRMspSelectCompanyPersonTop1ByOrderView_Result>)cRMSpEntities.CRMspSelectCompanyPersonTop1ByOrderView(cmpId, lCID, result));
				if (cRMspSelectCompanyPersonTop1ByOrderView_Result != null)
				{
					cRMspSelectCompanyPersonsByID_Result = new CRMspSelectCompanyPersonsByID_Result
					{
						CompanyPersonID = cRMspSelectCompanyPersonTop1ByOrderView_Result.CompanyPersonID,
						prsCompanyId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsCompanyId,
						prsLName = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsLName,
						prsFName = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsFName,
						prsTitleId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsTitleId,
						prsJobId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsJobId,
						prsTypeId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsTypeId,
						prsGroupId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsGroupId,
						prsSexId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsSexId,
						prsEducationId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsEducationId,
						prsPreTel = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsPreTel,
						prsTel = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsTel,
						prsTelUpTo = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsTelUpTo,
						prsTelDesc = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsTelDesc,
						prsTelII = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsTelII,
						prsFax = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsFax,
						prsFaxDesc = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsFaxDesc,
						prsMobile = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsMobile,
						prsWebSite = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsWebSite,
						prsEmail = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsEmail,
						prsEmailII = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsEmailII,
						prsCountryId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsCountryId,
						prsProvinceId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsProvinceId,
						prsCityId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsCityId,
						prsAddress = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsAddress,
						prsAddressDesc = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsAddressDesc,
						prsZipCode = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsZipCode,
						prsPostBox = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsPostBox,
						prsNationalCode = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsNationalCode,
						prsIdentityNumber = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsIdentityNumber,
						prsFatherName = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsFatherName,
						prsBirthDate = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsBirthDate,
						prsBirthDateTime = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsBirthDateTime,
						prsBirthPlace = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsBirthPlace,
						prsIsMarried = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsIsMarried,
						prsMarriageDate = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsMarriageDate,
						prsMarriageDateTime = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsMarriageDateTime,
						prsEducationField = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsEducationField,
						prsSkill = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsSkill,
						prsStudyField = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsStudyField,
						prsInteresting = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsInteresting,
						prsSpecialPoint = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsSpecialPoint,
						prsDescription = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsDescription,
						UserId = cRMspSelectCompanyPersonTop1ByOrderView_Result.UserId,
						Year1 = cRMspSelectCompanyPersonTop1ByOrderView_Result.Year1,
						Month1 = cRMspSelectCompanyPersonTop1ByOrderView_Result.Month1,
						RegisterDate = cRMspSelectCompanyPersonTop1ByOrderView_Result.RegisterDate,
						RegisterDatePersian = cRMspSelectCompanyPersonTop1ByOrderView_Result.RegisterDatePersian,
						AddType = cRMspSelectCompanyPersonTop1ByOrderView_Result.AddType,
						ImportDate = cRMspSelectCompanyPersonTop1ByOrderView_Result.ImportDate,
						ImportDateTime = cRMspSelectCompanyPersonTop1ByOrderView_Result.ImportDateTime,
						prsFirstRegisterUserId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsFirstRegisterUserId,
						prsDepartmentId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsDepartmentId,
						prsStopSendSms = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsStopSendSms,
						prsOrderView = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsOrderView,
						prsWorkingOut = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsWorkingOut,
						GUId = cRMspSelectCompanyPersonTop1ByOrderView_Result.GUId,
						CompanyPersonTemplateID = cRMspSelectCompanyPersonTop1ByOrderView_Result.CompanyPersonTemplateID,
						LanguageID = cRMspSelectCompanyPersonTop1ByOrderView_Result.LanguageID,
						FirstRegisterUserId = cRMspSelectCompanyPersonTop1ByOrderView_Result.FirstRegisterUserId,
						FirstRegisterDatePersian = cRMspSelectCompanyPersonTop1ByOrderView_Result.FirstRegisterDatePersian,
						FirstRegisterDate = cRMspSelectCompanyPersonTop1ByOrderView_Result.FirstRegisterDate,
						prsTelegramId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsTelegramId,
						PersonName = cRMspSelectCompanyPersonTop1ByOrderView_Result.PersonTitleName,
						prsTitle = cRMspSelectCompanyPersonTop1ByOrderView_Result.PersonTitle
					};
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		finally
		{
			cRMSpEntities.Dispose();
		}
		return cRMspSelectCompanyPersonsByID_Result;
	}

	public static string SyncCenters(List<LkCenterInfoViewModel> centers)
	{
		string result = "";
		CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
		try
		{
			if (centers.Count <= 0)
			{
				result = Messages.ErrorNotFound;
				return result;
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			_ = Financial.Get().Id;
			short value2 = short.Parse(Financial.Get().Id.ToString());
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspLkInsertUpdateCenter_Result> list = Enumerable.ToList<CRMspLkInsertUpdateCenter_Result>((IEnumerable<CRMspLkInsertUpdateCenter_Result>)cRMLinkSpEntities.CRMspLkInsertUpdateCenter(JsonConvert.SerializeObject(centers), userId, value3, value2, value, registerDatePersian, appType, lCID, result2));
			if (list != null)
			{
				List<CRMspLkInsertUpdateCenter_Result> list2 = Enumerable.ToList<CRMspLkInsertUpdateCenter_Result>(Enumerable.Where<CRMspLkInsertUpdateCenter_Result>((IEnumerable<CRMspLkInsertUpdateCenter_Result>)list, (Func<CRMspLkInsertUpdateCenter_Result, bool>)((CRMspLkInsertUpdateCenter_Result x) => !string.IsNullOrWhiteSpace(x.ErrorMessage))));
				if (list2 != null)
				{
					result = string.Join(", ", Enumerable.Select<CRMspLkInsertUpdateCenter_Result, string>((IEnumerable<CRMspLkInsertUpdateCenter_Result>)list2, (Func<CRMspLkInsertUpdateCenter_Result, string>)((CRMspLkInsertUpdateCenter_Result x) => x.ErrorMessage)));
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		finally
		{
			cRMLinkSpEntities.Dispose();
		}
		return result;
	}

	public static string SyncCrmCompanyGroups(List<LkCrmCompanyGroupsViewModel> groups)
	{
		string result = "";
		CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
		try
		{
			if (groups.Count <= 0)
			{
				result = Messages.ErrorNotFound;
				return result;
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			_ = Financial.Get().Id;
			short value2 = short.Parse(Financial.Get().Id.ToString());
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspLkInsertUpdateCompanyGroups_Result> list = Enumerable.ToList<CRMspLkInsertUpdateCompanyGroups_Result>((IEnumerable<CRMspLkInsertUpdateCompanyGroups_Result>)cRMLinkSpEntities.CRMspLkInsertUpdateCompanyGroups(JsonConvert.SerializeObject(groups), userId, value3, value2, value, registerDatePersian, appType, lCID, result2));
			if (list != null)
			{
				List<CRMspLkInsertUpdateCompanyGroups_Result> list2 = Enumerable.ToList<CRMspLkInsertUpdateCompanyGroups_Result>(Enumerable.Where<CRMspLkInsertUpdateCompanyGroups_Result>((IEnumerable<CRMspLkInsertUpdateCompanyGroups_Result>)list, (Func<CRMspLkInsertUpdateCompanyGroups_Result, bool>)((CRMspLkInsertUpdateCompanyGroups_Result x) => !string.IsNullOrWhiteSpace(x.ErrorMessage))));
				if (list2 != null)
				{
					result = string.Join(", ", Enumerable.Select<CRMspLkInsertUpdateCompanyGroups_Result, string>((IEnumerable<CRMspLkInsertUpdateCompanyGroups_Result>)list2, (Func<CRMspLkInsertUpdateCompanyGroups_Result, string>)((CRMspLkInsertUpdateCompanyGroups_Result x) => x.ErrorMessage)));
				}
			}
			User.UpdateUsersMobBaseInfo("CrmCompanyGroups");
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		finally
		{
			cRMLinkSpEntities.Dispose();
		}
		return result;
	}

	public static string SyncCrmCompanySubGroups(List<LkCrmCompanySubGroupsViewModel> groups)
	{
		string text = "";
		CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
		try
		{
			if (groups.Count <= 0)
			{
				text = Messages.ErrorNotFound;
				return text;
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			_ = Financial.Get().Id;
			short value2 = short.Parse(Financial.Get().Id.ToString());
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
			cRMLinkSpEntities.CRMspLkInsertUpdateCompanySubGroupsByJson(JsonConvert.SerializeObject(groups), userId, value3, value2, value, registerDatePersian, appType, result, objectParameter);
			if (objectParameter.Value != null && !string.IsNullOrEmpty(objectParameter.Value.ToString()))
			{
				text = text + "<br>" + objectParameter.Value.ToString();
			}
			User.UpdateUsersMobBaseInfo("CrmCompanySubGroups");
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		finally
		{
			cRMLinkSpEntities.Dispose();
		}
		return text;
	}

	public static string SyncCrmCompanyTypes(List<LkCompanyTypeInfoViewModel> types)
	{
		string result = "";
		CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
		try
		{
			if (types.Count <= 0)
			{
				result = Messages.ErrorNotFound;
				return result;
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			_ = Financial.Get().Id;
			short value2 = short.Parse(Financial.Get().Id.ToString());
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
			string cmpTypeJson = JsonConvert.SerializeObject(types);
			cRMLinkSpEntities.CRMspLkInsertUpdateCompanyTypeByJson(cmpTypeJson, userId, value3, value2, value, registerDatePersian, appType, result2, objectParameter);
			if (objectParameter.Value != null && !string.IsNullOrEmpty(objectParameter.Value.ToString()))
			{
				result = "<br>" + objectParameter.Value.ToString();
			}
			User.UpdateUsersMobBaseInfo("CrmCompanyType");
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		finally
		{
			cRMLinkSpEntities.Dispose();
		}
		return result;
	}

	public static string SyncWsProductUnits(List<LkWSProductUnitInfoViewModel> units)
	{
		string text = "";
		CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
		try
		{
			if (units.Count <= 0)
			{
				text = Messages.ErrorNotFound;
				return text;
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int id = Financial.Get().Id;
			short.Parse(Financial.Get().Id.ToString());
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
			string unitJson = JsonConvert.SerializeObject(units);
			cRMLinkSpEntities.CRMspLkWSInsertUpdateProductUnitByJson(unitJson, userId, value2, id, value, registerDatePersian, appType, result, objectParameter);
			if (objectParameter.Value != null && !string.IsNullOrEmpty(objectParameter.Value.ToString()))
			{
				text = text + "<br>" + objectParameter.Value.ToString();
			}
			User.UpdateUsersMobBaseInfo("WSProductUnits");
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		finally
		{
			cRMLinkSpEntities.Dispose();
		}
		return text;
	}

	public static string SyncWSCurrencyUnits(List<LkWSCurrencyUnitInfoViewModel> currencyUnits)
	{
		string text = "";
		CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
		try
		{
			if (currencyUnits.Count <= 0)
			{
				text = Messages.ErrorNotFound;
				return text;
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int id = Financial.Get().Id;
			short.Parse(Financial.Get().Id.ToString());
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
			string currencyUnitJson = JsonConvert.SerializeObject(currencyUnits);
			cRMLinkSpEntities.CRMspLkWSInsertUpdateCurrencyUnitByJson(currencyUnitJson, userId, value2, id, value, registerDatePersian, appType, result, objectParameter);
			if (objectParameter.Value != null && !string.IsNullOrEmpty(objectParameter.Value.ToString()))
			{
				text = text + "<br>" + objectParameter.Value.ToString();
			}
			User.UpdateUsersMobBaseInfo("WSCurrencyUnits");
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		finally
		{
			cRMLinkSpEntities.Dispose();
		}
		return text;
	}

	public static string SyncWSSaleCenters(List<LkWSSaleCenterInfoViewModel> saleCenters)
	{
		string text = "";
		CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
		try
		{
			if (saleCenters.Count <= 0)
			{
				text = Messages.ErrorNotFound;
				return text;
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int id = Financial.Get().Id;
			short.Parse(Financial.Get().Id.ToString());
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
			string saleCenterJson = JsonConvert.SerializeObject(saleCenters);
			cRMLinkSpEntities.CRMspLkWSInsertUpdateSaleCenterByJson(saleCenterJson, userId, value2, id, value, registerDatePersian, appType, result, objectParameter);
			if (objectParameter.Value != null && !string.IsNullOrEmpty(objectParameter.Value.ToString()))
			{
				text = text + "<br>" + objectParameter.Value.ToString();
			}
			User.UpdateUsersMobBaseInfo("WSSaleCenters");
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		finally
		{
			cRMLinkSpEntities.Dispose();
		}
		return text;
	}

	public static string SyncWSSaleAreas(List<LkWSSaleAreaInfoViewModel> saleAreas)
	{
		string text = "";
		CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
		try
		{
			if (saleAreas.Count <= 0)
			{
				text = Messages.ErrorNotFound;
				return text;
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int id = Financial.Get().Id;
			short.Parse(Financial.Get().Id.ToString());
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
			string saleAreaJson = JsonConvert.SerializeObject(saleAreas);
			cRMLinkSpEntities.CRMspLkWSInsertUpdateSaleAreasByJson(saleAreaJson, userId, value2, id, value, registerDatePersian, appType, result, objectParameter);
			if (objectParameter.Value != null && !string.IsNullOrEmpty(objectParameter.Value.ToString()))
			{
				text = text + "<br>" + objectParameter.Value.ToString();
			}
			User.UpdateUsersMobBaseInfo("WSSaleAreas");
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		finally
		{
			cRMLinkSpEntities.Dispose();
		}
		return text;
	}

	public static string SyncWSPreOrderTypes(List<LkWSPreOrderTypesInfoViewModel> preOrderTypes)
	{
		string text = "";
		CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
		try
		{
			if (preOrderTypes.Count <= 0)
			{
				text = Messages.ErrorNotFound;
				return text;
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int id = Financial.Get().Id;
			short.Parse(Financial.Get().Id.ToString());
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
			string preOrderTypeJson = JsonConvert.SerializeObject(preOrderTypes);
			cRMLinkSpEntities.CRMspLkWSInsertUpdatePreOrderTypeByJson(preOrderTypeJson, userId, value2, id, value, registerDatePersian, appType, result, objectParameter);
			if (objectParameter.Value != null && !string.IsNullOrEmpty(objectParameter.Value.ToString()))
			{
				text = text + "<br>" + objectParameter.Value.ToString();
			}
			User.UpdateUsersMobBaseInfo("WSPreOrderTypes");
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		finally
		{
			cRMLinkSpEntities.Dispose();
		}
		return text;
	}

	public static string SyncWSPreOrderOpr(List<LkWSPreOrderOprInfoViewModel> preOrderOpr)
	{
		string text = "";
		CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
		try
		{
			if (preOrderOpr.Count <= 0)
			{
				text = Messages.ErrorNotFound;
				return text;
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int id = Financial.Get().Id;
			short.Parse(Financial.Get().Id.ToString());
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
			string preOrderOprJson = JsonConvert.SerializeObject(preOrderOpr);
			cRMLinkSpEntities.CRMspLkWSInsertUpdatePreOrderOprByJson(preOrderOprJson, userId, value2, id, value, registerDatePersian, appType, result, objectParameter);
			if (objectParameter.Value != null && !string.IsNullOrEmpty(objectParameter.Value.ToString()))
			{
				text = text + "<br>" + objectParameter.Value.ToString();
			}
			User.UpdateUsersMobBaseInfo("WSPreOrderOpr");
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		finally
		{
			cRMLinkSpEntities.Dispose();
		}
		return text;
	}

	public static string SyncWSOrderOpr(List<LkWSOrderOprInfoViewModel> orderOpr)
	{
		string text = "";
		CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
		try
		{
			if (orderOpr.Count <= 0)
			{
				text = Messages.ErrorNotFound;
				return text;
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int id = Financial.Get().Id;
			short.Parse(Financial.Get().Id.ToString());
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
			string orderOprJson = JsonConvert.SerializeObject(orderOpr);
			cRMLinkSpEntities.CRMspLkWSInsertUpdateOrderOprByJson(orderOprJson, userId, value2, id, value, registerDatePersian, appType, result, objectParameter);
			if (objectParameter.Value != null && !string.IsNullOrEmpty(objectParameter.Value.ToString()))
			{
				text = text + "<br>" + objectParameter.Value.ToString();
			}
			User.UpdateUsersMobBaseInfo("WSOrderOpr");
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		finally
		{
			cRMLinkSpEntities.Dispose();
		}
		return text;
	}

	public static string SyncWSOrderGroups(List<LkWSOrderGroupInfoViewModel> orderGroups)
	{
		string text = "";
		CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
		try
		{
			if (orderGroups.Count <= 0)
			{
				text = Messages.ErrorNotFound;
				return text;
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int id = Financial.Get().Id;
			short.Parse(Financial.Get().Id.ToString());
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
			string orderGroupJson = JsonConvert.SerializeObject(orderGroups);
			cRMLinkSpEntities.CRMspLkWSInsertUpdateOrderGroupsByJson(orderGroupJson, userId, value2, id, value, registerDatePersian, appType, result, objectParameter);
			if (objectParameter.Value != null && !string.IsNullOrEmpty(objectParameter.Value.ToString()))
			{
				text = text + "<br>" + objectParameter.Value.ToString();
			}
			User.UpdateUsersMobBaseInfo("WSOrderGroups");
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		finally
		{
			cRMLinkSpEntities.Dispose();
		}
		return text;
	}

	public static string SyncProvince(List<LkProvinceInfoViewModel> provices)
	{
		string result = "";
		CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
		try
		{
			if (provices.Count <= 0)
			{
				result = Messages.ErrorNotFound;
				return result;
			}
			int result2 = 0;
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result2);
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			_ = Financial.Get().Id;
			short value2 = short.Parse(Financial.Get().Id.ToString());
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result3);
			if (result3 <= 0)
			{
				result3 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			string text = JsonConvert.SerializeObject(provices);
			if (!string.IsNullOrWhiteSpace(text))
			{
				mct_Link_Result mct_Link_Result = Enumerable.FirstOrDefault<mct_Link_Result>((IEnumerable<mct_Link_Result>)cRMLinkSpEntities.CRMspLkLinkedProvince(result2, text, userId, value3, value2, value, registerDatePersian, appType));
				if (mct_Link_Result != null)
				{
					int result4 = 0;
					int.TryParse(mct_Link_Result.Result.ToString(), out result4);
					if (result4 <= 0)
					{
						result = "<br>" + Messages.msgErrorRunFunction;
					}
				}
			}
			User.UpdateUsersMobBaseInfo("Province");
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		finally
		{
			cRMLinkSpEntities.Dispose();
		}
		return result;
	}

	public static string SyncCity(List<LkCityInfoViewModel> cites)
	{
		string result = "";
		CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
		try
		{
			if (cites.Count <= 0)
			{
				result = Messages.ErrorNotFound;
				return result;
			}
			int result2 = 0;
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result2);
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			_ = Financial.Get().Id;
			short value2 = short.Parse(Financial.Get().Id.ToString());
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result3);
			if (result3 <= 0)
			{
				result3 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			string text = JsonConvert.SerializeObject(cites);
			if (!string.IsNullOrWhiteSpace(text))
			{
				mct_Link_Result mct_Link_Result = Enumerable.FirstOrDefault<mct_Link_Result>((IEnumerable<mct_Link_Result>)cRMLinkSpEntities.CRMspLkLinkedCity(result2, text, userId, value3, value2, value, registerDatePersian, appType));
				if (mct_Link_Result != null)
				{
					int result4 = 0;
					int.TryParse(mct_Link_Result.Result.ToString(), out result4);
					if (result4 <= 0)
					{
						result = "<br>" + Messages.msgErrorRunFunction;
					}
				}
			}
			User.UpdateUsersMobBaseInfo("City");
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		finally
		{
			cRMLinkSpEntities.Dispose();
		}
		return result;
	}

	public static string SyncCrmCompanyGroupsIII(List<LkCrmCompanyGroupsIIIViewModel> groups)
	{
		string text = "";
		CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
		try
		{
			if (groups.Count <= 0)
			{
				text = Messages.ErrorNotFound;
				return text;
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			_ = Financial.Get().Id;
			short value2 = short.Parse(Financial.Get().Id.ToString());
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
			string companyGroupsIIIJson = JsonConvert.SerializeObject(groups);
			cRMLinkSpEntities.CRMspLkInsertUpdateCompanyGroupsIIIByJson(companyGroupsIIIJson, userId, value3, value2, value, registerDatePersian, appType, result, objectParameter);
			if (objectParameter.Value != null && !string.IsNullOrEmpty(objectParameter.Value.ToString()))
			{
				text = text + "<br>" + objectParameter.Value.ToString();
			}
			User.UpdateUsersMobBaseInfo("CrmCompanyGroupsIII");
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		finally
		{
			cRMLinkSpEntities.Dispose();
		}
		return text;
	}

	public static string SyncCrmCashes(List<LKCrmCashesViewModel> items)
	{
		string text = "";
		CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
		try
		{
			if (items.Count <= 0)
			{
				text = Messages.ErrorNotFound;
				return text;
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			_ = Financial.Get().Id;
			short value2 = short.Parse(Financial.Get().Id.ToString());
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
			string itemJson = JsonConvert.SerializeObject(items);
			cRMLinkSpEntities.CRMspLkInsertUpdateCashesByJson(itemJson, userId, value3, value2, value, registerDatePersian, appType, result, objectParameter);
			if (objectParameter.Value != null && !string.IsNullOrEmpty(objectParameter.Value.ToString()))
			{
				text = text + "<br>" + objectParameter.Value.ToString();
			}
			User.UpdateUsersMobBaseInfo("CrmCashes");
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		finally
		{
			cRMLinkSpEntities.Dispose();
		}
		return text;
	}

	public static string SyncWSOrderPaymentGroupsI(List<LKWSOrderPaymentGroupsIViewModel> items)
	{
		string text = "";
		CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
		try
		{
			if (items.Count <= 0)
			{
				text = Messages.ErrorNotFound;
				return text;
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int id = Financial.Get().Id;
			short.Parse(Financial.Get().Id.ToString());
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
			string itemJson = JsonConvert.SerializeObject(items);
			cRMLinkSpEntities.CRMspLkWSInsertUpdateOrderPaymentGroupsIByJson(itemJson, userId, value2, id, value, registerDatePersian, appType, result, objectParameter);
			if (objectParameter.Value != null && !string.IsNullOrEmpty(objectParameter.Value.ToString()))
			{
				text = text + "<br>" + objectParameter.Value.ToString();
			}
			User.UpdateUsersMobBaseInfo("WSOrderPaymentGroupsI");
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		finally
		{
			cRMLinkSpEntities.Dispose();
		}
		return text;
	}

	public static string SyncWSOrderPaymentGroupsII(List<LKWSOrderPaymentGroupsIIViewModel> items)
	{
		string text = "";
		CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
		try
		{
			if (items.Count <= 0)
			{
				text = Messages.ErrorNotFound;
				return text;
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int id = Financial.Get().Id;
			short.Parse(Financial.Get().Id.ToString());
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
			string itemJson = JsonConvert.SerializeObject(items);
			cRMLinkSpEntities.CRMspLkWSInsertUpdateOrderPaymentGroupsIIByJson(itemJson, userId, value2, id, value, registerDatePersian, appType, result, objectParameter);
			if (objectParameter.Value != null && !string.IsNullOrEmpty(objectParameter.Value.ToString()))
			{
				text = text + "<br>" + objectParameter.Value.ToString();
			}
			User.UpdateUsersMobBaseInfo("WSOrderPaymentGroupsII");
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		finally
		{
			cRMLinkSpEntities.Dispose();
		}
		return text;
	}

	public static string SyncCrmBankingBanks(List<LKCrmBankingBanksViewModel> items)
	{
		string text = "";
		CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
		try
		{
			if (items.Count <= 0)
			{
				text = Messages.ErrorNotFound;
				return text;
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			_ = Financial.Get().Id;
			short value2 = short.Parse(Financial.Get().Id.ToString());
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
			string itemJson = JsonConvert.SerializeObject(items);
			cRMLinkSpEntities.CRMspLkInsertUpdateBankingBanksByJson(itemJson, userId, value3, value2, value, registerDatePersian, appType, result, objectParameter);
			if (objectParameter.Value != null && !string.IsNullOrEmpty(objectParameter.Value.ToString()))
			{
				text = text + "<br>" + objectParameter.Value.ToString();
			}
			User.UpdateUsersMobBaseInfo("CrmBankingBanks");
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		finally
		{
			cRMLinkSpEntities.Dispose();
		}
		return text;
	}

	public static string SyncCrmBankingBranches(List<LKCrmBankingBranchesViewModel> items)
	{
		string text = "";
		CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
		try
		{
			if (items.Count <= 0)
			{
				text = Messages.ErrorNotFound;
				return text;
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			_ = Financial.Get().Id;
			short value2 = short.Parse(Financial.Get().Id.ToString());
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
			string itemJson = JsonConvert.SerializeObject(items);
			cRMLinkSpEntities.CRMspLkInsertUpdateBankingBranchesByJson(itemJson, userId, value3, value2, value, registerDatePersian, appType, result, objectParameter);
			if (objectParameter.Value != null && !string.IsNullOrEmpty(objectParameter.Value.ToString()))
			{
				text = text + "<br>" + objectParameter.Value.ToString();
			}
			User.UpdateUsersMobBaseInfo("CrmBankingBranches");
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		finally
		{
			cRMLinkSpEntities.Dispose();
		}
		return text;
	}

	public static string SyncCrmBankingAccounts(List<LKCrmBankingAccountsViewModel> items)
	{
		string text = "";
		CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
		try
		{
			if (items.Count <= 0)
			{
				text = Messages.ErrorNotFound;
				return text;
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			_ = Financial.Get().Id;
			short value2 = short.Parse(Financial.Get().Id.ToString());
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
			string itemJson = JsonConvert.SerializeObject(items);
			cRMLinkSpEntities.CRMspLkInsertUpdateBankingAccountsByJson(itemJson, null, userId, value3, value2, value, registerDatePersian, appType, result, objectParameter);
			if (objectParameter.Value != null && !string.IsNullOrEmpty(objectParameter.Value.ToString()))
			{
				text = text + "<br>" + objectParameter.Value.ToString();
			}
			User.UpdateUsersMobBaseInfo("CrmBankingAccounts");
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		finally
		{
			cRMLinkSpEntities.Dispose();
		}
		return text;
	}

	public static List<CRMspSelectLinkAccSettingDBAll_Result> SelectLinkAccSettingDBAll()
	{
		List<CRMspSelectLinkAccSettingDBAll_Result> result = new List<CRMspSelectLinkAccSettingDBAll_Result>();
		CRMSpIIEntities cRMSpIIEntities = new CRMSpIIEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectLinkAccSettingDBAll_Result> list = Enumerable.ToList<CRMspSelectLinkAccSettingDBAll_Result>((IEnumerable<CRMspSelectLinkAccSettingDBAll_Result>)cRMSpIIEntities.CRMspSelectLinkAccSettingDBAll(lCID, result2));
			if (list != null)
			{
				result = list;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		finally
		{
			cRMSpIIEntities?.Dispose();
		}
		return result;
	}

	public static string SyncWsPayCondition(List<LkWSPayConditionInfoViewModel> payCondition)
	{
		string text = "";
		CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
		try
		{
			if (payCondition.Count <= 0)
			{
				text = Messages.ErrorNotFound;
				return text;
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int id = Financial.Get().Id;
			short.Parse(Financial.Get().Id.ToString());
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
			string payConditionJson = JsonConvert.SerializeObject(payCondition);
			cRMLinkSpEntities.CRMspLkWSInsertUpdatePayConditionByJson(payConditionJson, userId, value2, id, value, registerDatePersian, appType, result, objectParameter);
			if (objectParameter.Value != null && !string.IsNullOrEmpty(objectParameter.Value.ToString()))
			{
				text = text + "<br>" + objectParameter.Value.ToString();
			}
			User.UpdateUsersMobBaseInfo("WSPayCondition");
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		finally
		{
			cRMLinkSpEntities.Dispose();
		}
		return text;
	}

	public static string SyncWSSettlementType(List<LkWSSettlementTypeInfoViewModel> settlementType)
	{
		string text = "";
		CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
		try
		{
			if (settlementType.Count <= 0)
			{
				text = Messages.ErrorNotFound;
				return text;
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			_ = Financial.Get().Id;
			short value2 = short.Parse(Financial.Get().Id.ToString());
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
			string settlementTypeJson = JsonConvert.SerializeObject(settlementType);
			cRMLinkSpEntities.CRMspLkWSInsertUpdateSettlementTypeByJson(settlementTypeJson, userId, value3, value2, value, registerDatePersian, appType, result, objectParameter);
			if (objectParameter.Value != null && !string.IsNullOrEmpty(objectParameter.Value.ToString()))
			{
				text = text + "<br>" + objectParameter.Value.ToString();
			}
			User.UpdateUsersMobBaseInfo("WSSettlementType");
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		finally
		{
			cRMLinkSpEntities.Dispose();
		}
		return text;
	}

	public static string SyncWSDeliveryTerms(List<LkWSDeliveryTermInfoViewModel> deliveryTerms)
	{
		string text = "";
		CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
		try
		{
			if (deliveryTerms.Count <= 0)
			{
				text = Messages.ErrorNotFound;
				return text;
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int id = Financial.Get().Id;
			short.Parse(Financial.Get().Id.ToString());
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
			string deliveryTermJson = JsonConvert.SerializeObject(deliveryTerms);
			cRMLinkSpEntities.CRMspLkWSInsertUpdateDeliveryTermByJson(deliveryTermJson, userId, value2, id, value, registerDatePersian, appType, result, objectParameter);
			if (objectParameter.Value != null && !string.IsNullOrEmpty(objectParameter.Value.ToString()))
			{
				text = text + "<br>" + objectParameter.Value.ToString();
			}
			User.UpdateUsersMobBaseInfo("WSDeliveryTerms");
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		finally
		{
			cRMLinkSpEntities.Dispose();
		}
		return text;
	}

	public static List<CRMspSelectLinkAccSettingBySystemId_Result> SelectLinkAccSettingBySystemId(int linkAccSystemId, int linkAccSettingDBId, int linkAccSettingId, string objectType, string partTitle)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectLinkAccSettingBySystemId_Result> list = new List<CRMspSelectLinkAccSettingBySystemId_Result>();
		CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
		try
		{
			list = Enumerable.ToList<CRMspSelectLinkAccSettingBySystemId_Result>((IEnumerable<CRMspSelectLinkAccSettingBySystemId_Result>)cRMLinkSpEntities.CRMspSelectLinkAccSettingBySystemId(linkAccSystemId, linkAccSettingId, linkAccSettingDBId, objectType, partTitle, lCID, result));
			if (list == null)
			{
				list = new List<CRMspSelectLinkAccSettingBySystemId_Result>();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMLinkSpEntities.Dispose();
		}
		return list;
	}

	public static bool GetCanNotVerifyNoCmpCredit(int linkAccSettingDBId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		bool result2 = false;
		try
		{
			int result3 = 0;
			int linkAccSettingId = 0;
			string objectType = "";
			string partTitle = "";
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result3);
			}
			if (result3 == 12)
			{
				objectType = "Setting";
				partTitle = "CanNotVerifyNoCmpCredit";
			}
			List<CRMspSelectLinkAccSettingBySystemId_Result> list = SelectLinkAccSettingBySystemId(result3, linkAccSettingDBId, linkAccSettingId, objectType, partTitle);
			if (list != null && Enumerable.Any<CRMspSelectLinkAccSettingBySystemId_Result>((IEnumerable<CRMspSelectLinkAccSettingBySystemId_Result>)list))
			{
				CRMspSelectLinkAccSettingBySystemId_Result cRMspSelectLinkAccSettingBySystemId_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingBySystemId_Result>((IEnumerable<CRMspSelectLinkAccSettingBySystemId_Result>)list, (Func<CRMspSelectLinkAccSettingBySystemId_Result, bool>)((CRMspSelectLinkAccSettingBySystemId_Result m) => m.PartTitle == partTitle && m.ObjectType == objectType));
				if (cRMspSelectLinkAccSettingBySystemId_Result != null && !string.IsNullOrWhiteSpace(cRMspSelectLinkAccSettingBySystemId_Result.PartValue))
				{
					bool.TryParse(cRMspSelectLinkAccSettingBySystemId_Result.PartValue, out result2);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result2;
	}

	public static bool CheckCmpCreditByAmount(int linkAccSettingDBId, int cmpId, decimal amount)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		bool result2 = true;
		try
		{
			if (amount > 0m && cmpId != 0)
			{
				int result3 = 0;
				CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
				if (cRMspSelectCrmsysSetting_Result != null)
				{
					int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result3);
				}
				if (result3 == 12 && GetCanNotVerifyNoCmpCredit(linkAccSettingDBId))
				{
					CompanyController companyController = new CompanyController();
					decimal creditAccount = default(decimal);
					companyController.LinkAccGetCmpCredit(result3, 0, cmpId, ref creditAccount);
					if (creditAccount < amount)
					{
						result2 = false;
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result2;
	}

	public static List<SelectListItem> GetLinkAccSettingDB(int linkAccSystemId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
		try
		{
			List<CRMspSelectLinkAccSettingDBIsActive_Result> list2 = Enumerable.ToList<CRMspSelectLinkAccSettingDBIsActive_Result>((IEnumerable<CRMspSelectLinkAccSettingDBIsActive_Result>)cRMLinkSpEntities.CRMspSelectLinkAccSettingDBIsActive(linkAccSystemId));
			if (list2 != null && Enumerable.Any<CRMspSelectLinkAccSettingDBIsActive_Result>((IEnumerable<CRMspSelectLinkAccSettingDBIsActive_Result>)list2))
			{
				list.AddRange(Enumerable.Select<CRMspSelectLinkAccSettingDBIsActive_Result, SelectListItem>((IEnumerable<CRMspSelectLinkAccSettingDBIsActive_Result>)list2, (Func<CRMspSelectLinkAccSettingDBIsActive_Result, SelectListItem>)((CRMspSelectLinkAccSettingDBIsActive_Result item) => new SelectListItem
				{
					Text = item.LinkAccSettingDbTitle + "(" + item.LinkAccSettingDbName + ")",
					Value = item.LinkAccSettingDBId.ToString(),
					Selected = false
				})));
			}
			if (list == null)
			{
				list = new List<SelectListItem>();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMLinkSpEntities.Dispose();
		}
		return list;
	}

	public static List<CRMspSelectLinkAccSettingDBIsActive_Result> GetLinkAccSettingDBList(int linkAccSystemId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectLinkAccSettingDBIsActive_Result> list = new List<CRMspSelectLinkAccSettingDBIsActive_Result>();
		CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
		try
		{
			list = Enumerable.ToList<CRMspSelectLinkAccSettingDBIsActive_Result>((IEnumerable<CRMspSelectLinkAccSettingDBIsActive_Result>)cRMLinkSpEntities.CRMspSelectLinkAccSettingDBIsActive(linkAccSystemId));
			if (list == null)
			{
				list = new List<CRMspSelectLinkAccSettingDBIsActive_Result>();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMLinkSpEntities.Dispose();
		}
		return list;
	}

	public static int GetDefSepReferUserId(int linkAccSettingDBId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int result2 = 0;
		CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
		try
		{
			CRMspSelectLinkAccSetting_Result cRMspSelectLinkAccSetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)cRMLinkSpEntities.CRMspSelectLinkAccSetting(0, "DefSepReferUser", lCID, result, 1, linkAccSettingDBId, "DefSepReferUserId"));
			if (cRMspSelectLinkAccSetting_Result != null)
			{
				int.TryParse(cRMspSelectLinkAccSetting_Result.PartValue, out result2);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMLinkSpEntities.Dispose();
		}
		return result2;
	}

	public static string GetLinkAccCodeWithComa(int mode, string linkAccCode)
	{
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		try
		{
			text = linkAccCode ?? "";
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			int result2 = 0;
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result2);
			}
			if ((result2 == 1 || result2 == 4) && !string.IsNullOrWhiteSpace(linkAccCode) && linkAccCode.IndexOf("DBId") > 0)
			{
				switch (mode)
				{
				case 0:
					text = linkAccCode;
					break;
				case 1:
				case 2:
				case 3:
				{
					List<LinkAccCodeViewModel> list = new JavaScriptSerializer().Deserialize<List<LinkAccCodeViewModel>>(linkAccCode);
					if (list == null || !Enumerable.Any<LinkAccCodeViewModel>((IEnumerable<LinkAccCodeViewModel>)list))
					{
						break;
					}
					text = "";
					foreach (LinkAccCodeViewModel item in list)
					{
						if (!string.IsNullOrWhiteSpace(item.Code))
						{
							if (!string.IsNullOrWhiteSpace(text))
							{
								text += ",";
							}
							text += item.Code;
						}
					}
					break;
				}
				}
			}
			if (text == "[]")
			{
				text = "";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return text;
	}

	public static SepidarHaveModulesViewModel GetSepidarModules(int linkAccSettingDBId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		SepidarHaveModulesViewModel sepidarHaveModulesViewModel = new SepidarHaveModulesViewModel
		{
			SepNotHavePordModule = false,
			SepNotHaveOrdModule = false,
			SepNotHaveBordModule = false,
			SepNotHaveDocModule = false,
			SepNotHavePayModule = false,
			SepNotHaveCommModule = false
		};
		CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
		try
		{
			List<CRMspSelectLinkAccSetting_Result> list = Enumerable.ToList<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)cRMLinkSpEntities.CRMspSelectLinkAccSetting(0, null, lCID, result, 1, linkAccSettingDBId, null));
			if (list != null && Enumerable.Any<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list))
			{
				CRMspSelectLinkAccSetting_Result cRMspSelectLinkAccSetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>(Enumerable.Where<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result m) => (m.ObjectType ?? "") == "PreOrder" && (m.PartTitle ?? "") == "SepNotHavePordModule")));
				if (cRMspSelectLinkAccSetting_Result != null && !string.IsNullOrWhiteSpace(cRMspSelectLinkAccSetting_Result.PartValue))
				{
					bool result2 = false;
					bool.TryParse(cRMspSelectLinkAccSetting_Result.PartValue, out result2);
					sepidarHaveModulesViewModel.SepNotHavePordModule = result2;
					sepidarHaveModulesViewModel.SepNotHavePordModulePartLabelTitle = cRMspSelectLinkAccSetting_Result.PartLabelTitle ?? "";
				}
				CRMspSelectLinkAccSetting_Result cRMspSelectLinkAccSetting_Result2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>(Enumerable.Where<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result m) => (m.ObjectType ?? "") == "Order" && (m.PartTitle ?? "") == "SepNotHaveOrdModule")));
				if (cRMspSelectLinkAccSetting_Result2 != null && !string.IsNullOrWhiteSpace(cRMspSelectLinkAccSetting_Result2.PartValue))
				{
					bool result3 = false;
					bool.TryParse(cRMspSelectLinkAccSetting_Result2.PartValue, out result3);
					sepidarHaveModulesViewModel.SepNotHaveOrdModule = result3;
					sepidarHaveModulesViewModel.SepNotHaveOrdModulePartLabelTitle = cRMspSelectLinkAccSetting_Result2.PartLabelTitle ?? "";
				}
				CRMspSelectLinkAccSetting_Result cRMspSelectLinkAccSetting_Result3 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>(Enumerable.Where<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result m) => (m.ObjectType ?? "") == "BuyOrder" && (m.PartTitle ?? "") == "SepNotHaveBordModule")));
				if (cRMspSelectLinkAccSetting_Result3 != null && !string.IsNullOrWhiteSpace(cRMspSelectLinkAccSetting_Result3.PartValue))
				{
					bool result4 = false;
					bool.TryParse(cRMspSelectLinkAccSetting_Result3.PartValue, out result4);
					sepidarHaveModulesViewModel.SepNotHaveBordModule = result4;
					sepidarHaveModulesViewModel.SepNotHaveBordModulePartLabelTitle = cRMspSelectLinkAccSetting_Result3.PartLabelTitle ?? "";
				}
				CRMspSelectLinkAccSetting_Result cRMspSelectLinkAccSetting_Result4 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>(Enumerable.Where<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result m) => (m.ObjectType ?? "") == "Doc" && (m.PartTitle ?? "") == "SepNotHaveDocModule")));
				if (cRMspSelectLinkAccSetting_Result4 != null && !string.IsNullOrWhiteSpace(cRMspSelectLinkAccSetting_Result4.PartValue))
				{
					bool result5 = false;
					bool.TryParse(cRMspSelectLinkAccSetting_Result4.PartValue, out result5);
					sepidarHaveModulesViewModel.SepNotHaveDocModule = result5;
					sepidarHaveModulesViewModel.SepNotHaveDocModulePartLabelTitle = cRMspSelectLinkAccSetting_Result4.PartLabelTitle ?? "";
				}
				CRMspSelectLinkAccSetting_Result cRMspSelectLinkAccSetting_Result5 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>(Enumerable.Where<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result m) => (m.ObjectType ?? "") == "Payment" && (m.PartTitle ?? "") == "SepNotHavePayModule")));
				if (cRMspSelectLinkAccSetting_Result5 != null && !string.IsNullOrWhiteSpace(cRMspSelectLinkAccSetting_Result5.PartValue))
				{
					bool result6 = false;
					bool.TryParse(cRMspSelectLinkAccSetting_Result5.PartValue, out result6);
					sepidarHaveModulesViewModel.SepNotHavePayModule = result6;
					sepidarHaveModulesViewModel.SepNotHavePayModulePartLabelTitle = cRMspSelectLinkAccSetting_Result5.PartLabelTitle ?? "";
				}
				CRMspSelectLinkAccSetting_Result cRMspSelectLinkAccSetting_Result6 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>(Enumerable.Where<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result m) => (m.ObjectType ?? "") == "Commission" && (m.PartTitle ?? "") == "SepNotHaveCommModule")));
				if (cRMspSelectLinkAccSetting_Result6 != null && !string.IsNullOrWhiteSpace(cRMspSelectLinkAccSetting_Result6.PartValue))
				{
					bool result7 = false;
					bool.TryParse(cRMspSelectLinkAccSetting_Result6.PartValue, out result7);
					sepidarHaveModulesViewModel.SepNotHaveCommModule = result7;
					sepidarHaveModulesViewModel.SepNotHaveCommModulePartLabelTitle = cRMspSelectLinkAccSetting_Result6.PartLabelTitle ?? "";
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMLinkSpEntities.Dispose();
		}
		return sepidarHaveModulesViewModel;
	}

	public static PayvastSettingViewModel GetPayvastSetting(int settingId = 0, string objectType = "")
	{
		PayvastSettingViewModel payvastSettingViewModel = new PayvastSettingViewModel();
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (settingId < 0)
			{
				settingId = 0;
			}
			if (string.IsNullOrWhiteSpace(objectType))
			{
				objectType = "Setting";
			}
			List<CRMspSelectLinkAccPayvastSetting_Result> list = Enumerable.ToList<CRMspSelectLinkAccPayvastSetting_Result>((IEnumerable<CRMspSelectLinkAccPayvastSetting_Result>)cRMLinkSpEntities.CRMspSelectLinkAccPayvastSetting(settingId, objectType, lCID, result));
			if (list != null)
			{
				payvastSettingViewModel.PayvastUsername = Enumerable.FirstOrDefault<CRMspSelectLinkAccPayvastSetting_Result>((IEnumerable<CRMspSelectLinkAccPayvastSetting_Result>)list, (Func<CRMspSelectLinkAccPayvastSetting_Result, bool>)((CRMspSelectLinkAccPayvastSetting_Result x) => x.PartTitle == "PayvastUsername")).PartValue ?? "";
				payvastSettingViewModel.PayvastPassword = Enumerable.FirstOrDefault<CRMspSelectLinkAccPayvastSetting_Result>((IEnumerable<CRMspSelectLinkAccPayvastSetting_Result>)list, (Func<CRMspSelectLinkAccPayvastSetting_Result, bool>)((CRMspSelectLinkAccPayvastSetting_Result x) => x.PartTitle == "PayvastPassword")).PartValue ?? "";
				payvastSettingViewModel.PayvastAccountId = Enumerable.FirstOrDefault<CRMspSelectLinkAccPayvastSetting_Result>((IEnumerable<CRMspSelectLinkAccPayvastSetting_Result>)list, (Func<CRMspSelectLinkAccPayvastSetting_Result, bool>)((CRMspSelectLinkAccPayvastSetting_Result x) => x.PartTitle == "PayvastAccountId")).PartValue ?? "";
				payvastSettingViewModel.PayvastACC = Enumerable.FirstOrDefault<CRMspSelectLinkAccPayvastSetting_Result>((IEnumerable<CRMspSelectLinkAccPayvastSetting_Result>)list, (Func<CRMspSelectLinkAccPayvastSetting_Result, bool>)((CRMspSelectLinkAccPayvastSetting_Result x) => x.PartTitle == "PayvastACC")).PartValue ?? "";
				if (string.IsNullOrWhiteSpace(Enumerable.FirstOrDefault<CRMspSelectLinkAccPayvastSetting_Result>((IEnumerable<CRMspSelectLinkAccPayvastSetting_Result>)list, (Func<CRMspSelectLinkAccPayvastSetting_Result, bool>)((CRMspSelectLinkAccPayvastSetting_Result x) => x.PartTitle == "PayvastEKTypeCodeAdditions")).PartValue))
				{
					payvastSettingViewModel.PayvastEKTypeCodeAdditions = -1;
				}
				else
				{
					payvastSettingViewModel.PayvastEKTypeCodeAdditions = int.Parse(Enumerable.FirstOrDefault<CRMspSelectLinkAccPayvastSetting_Result>((IEnumerable<CRMspSelectLinkAccPayvastSetting_Result>)list, (Func<CRMspSelectLinkAccPayvastSetting_Result, bool>)((CRMspSelectLinkAccPayvastSetting_Result x) => x.PartTitle == "PayvastEKTypeCodeAdditions")).PartValue);
				}
				if (string.IsNullOrWhiteSpace(Enumerable.FirstOrDefault<CRMspSelectLinkAccPayvastSetting_Result>((IEnumerable<CRMspSelectLinkAccPayvastSetting_Result>)list, (Func<CRMspSelectLinkAccPayvastSetting_Result, bool>)((CRMspSelectLinkAccPayvastSetting_Result x) => x.PartTitle == "PayvastEKTypeCodeDeductions")).PartValue))
				{
					payvastSettingViewModel.PayvastEKTypeCodeDeductions = -1;
				}
				else
				{
					payvastSettingViewModel.PayvastEKTypeCodeDeductions = int.Parse(Enumerable.FirstOrDefault<CRMspSelectLinkAccPayvastSetting_Result>((IEnumerable<CRMspSelectLinkAccPayvastSetting_Result>)list, (Func<CRMspSelectLinkAccPayvastSetting_Result, bool>)((CRMspSelectLinkAccPayvastSetting_Result x) => x.PartTitle == "PayvastPrdCodeLength")).PartValue);
				}
				if (string.IsNullOrWhiteSpace(Enumerable.FirstOrDefault<CRMspSelectLinkAccPayvastSetting_Result>((IEnumerable<CRMspSelectLinkAccPayvastSetting_Result>)list, (Func<CRMspSelectLinkAccPayvastSetting_Result, bool>)((CRMspSelectLinkAccPayvastSetting_Result x) => x.PartTitle == "PayvastPrdCodeLength")).PartValue))
				{
					payvastSettingViewModel.PayvastPrdCodeLength = -1;
				}
				else
				{
					payvastSettingViewModel.PayvastPrdCodeLength = int.Parse(Enumerable.FirstOrDefault<CRMspSelectLinkAccPayvastSetting_Result>((IEnumerable<CRMspSelectLinkAccPayvastSetting_Result>)list, (Func<CRMspSelectLinkAccPayvastSetting_Result, bool>)((CRMspSelectLinkAccPayvastSetting_Result x) => x.PartTitle == "PayvastPrdCodeLength")).PartValue);
				}
				payvastSettingViewModel.PayvastCustomerAccountId = Enumerable.FirstOrDefault<CRMspSelectLinkAccPayvastSetting_Result>((IEnumerable<CRMspSelectLinkAccPayvastSetting_Result>)list, (Func<CRMspSelectLinkAccPayvastSetting_Result, bool>)((CRMspSelectLinkAccPayvastSetting_Result x) => x.PartTitle == "PayvastCustomerAccountId")).PartValue ?? "";
				payvastSettingViewModel.PayvastCustomerFloatingAccountId = Enumerable.FirstOrDefault<CRMspSelectLinkAccPayvastSetting_Result>((IEnumerable<CRMspSelectLinkAccPayvastSetting_Result>)list, (Func<CRMspSelectLinkAccPayvastSetting_Result, bool>)((CRMspSelectLinkAccPayvastSetting_Result x) => x.PartTitle == "PayvastCustomerFloatingAccountId")).PartValue ?? "";
				payvastSettingViewModel.PayvastPreOrderFloatingAccountII = Enumerable.FirstOrDefault<CRMspSelectLinkAccPayvastSetting_Result>((IEnumerable<CRMspSelectLinkAccPayvastSetting_Result>)list, (Func<CRMspSelectLinkAccPayvastSetting_Result, bool>)((CRMspSelectLinkAccPayvastSetting_Result x) => x.PartTitle == "PayvastPreOrderFloatingAccountII")).PartValue ?? "";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities.Dispose();
			cRMLinkSpEntities.Dispose();
		}
		return payvastSettingViewModel;
	}

	public static int GetPayvastFPId(DateTime selectedDate)
	{
		int result = 0;
		try
		{
			result = new AccountingServiceSoapClient().GetFiscalPeriodId(selectedDate).Value;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public static ShygunSettingViewModel GetShygunSetting(int settingId = 0, string objectType = "")
	{
		ShygunSettingViewModel shygunSettingViewModel = new ShygunSettingViewModel();
		CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (settingId < 0)
			{
				settingId = 0;
			}
			if (string.IsNullOrWhiteSpace(objectType))
			{
				objectType = "Setting";
			}
			List<CRMspSelectLinkAccShygunSetting_Result> list = Enumerable.ToList<CRMspSelectLinkAccShygunSetting_Result>((IEnumerable<CRMspSelectLinkAccShygunSetting_Result>)cRMLinkSpEntities.CRMspSelectLinkAccShygunSetting(settingId, objectType, lCID, result));
			if (list != null)
			{
				string partValue = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunSetting_Result>((IEnumerable<CRMspSelectLinkAccShygunSetting_Result>)list, (Func<CRMspSelectLinkAccShygunSetting_Result, bool>)((CRMspSelectLinkAccShygunSetting_Result x) => x.PartTitle == "ShygunAllowRowSecurity")).PartValue;
				if (!string.IsNullOrWhiteSpace(partValue) && partValue == "1")
				{
					shygunSettingViewModel.AllowRowSecurity = true;
				}
				else
				{
					shygunSettingViewModel.AllowRowSecurity = false;
				}
				shygunSettingViewModel.AuthUser = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunSetting_Result>((IEnumerable<CRMspSelectLinkAccShygunSetting_Result>)list, (Func<CRMspSelectLinkAccShygunSetting_Result, bool>)((CRMspSelectLinkAccShygunSetting_Result x) => x.PartTitle == "ShygunAuthUser")).PartValue;
				shygunSettingViewModel.AuthPassword = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunSetting_Result>((IEnumerable<CRMspSelectLinkAccShygunSetting_Result>)list, (Func<CRMspSelectLinkAccShygunSetting_Result, bool>)((CRMspSelectLinkAccShygunSetting_Result x) => x.PartTitle == "ShygunAuthPassword")).PartValue;
				shygunSettingViewModel.DataBaseName = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunSetting_Result>((IEnumerable<CRMspSelectLinkAccShygunSetting_Result>)list, (Func<CRMspSelectLinkAccShygunSetting_Result, bool>)((CRMspSelectLinkAccShygunSetting_Result x) => x.PartTitle == "ShygunDataBaseName")).PartValue;
				shygunSettingViewModel.DBUserName = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunSetting_Result>((IEnumerable<CRMspSelectLinkAccShygunSetting_Result>)list, (Func<CRMspSelectLinkAccShygunSetting_Result, bool>)((CRMspSelectLinkAccShygunSetting_Result x) => x.PartTitle == "ShygunDBUserName")).PartValue;
				shygunSettingViewModel.DBPassword = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunSetting_Result>((IEnumerable<CRMspSelectLinkAccShygunSetting_Result>)list, (Func<CRMspSelectLinkAccShygunSetting_Result, bool>)((CRMspSelectLinkAccShygunSetting_Result x) => x.PartTitle == "ShygunDBPassword")).PartValue;
				partValue = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunSetting_Result>((IEnumerable<CRMspSelectLinkAccShygunSetting_Result>)list, (Func<CRMspSelectLinkAccShygunSetting_Result, bool>)((CRMspSelectLinkAccShygunSetting_Result x) => x.PartTitle == "ShygunLanguage")).PartValue;
				if (!string.IsNullOrWhiteSpace(partValue))
				{
					shygunSettingViewModel.Language = int.Parse(Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunSetting_Result>((IEnumerable<CRMspSelectLinkAccShygunSetting_Result>)list, (Func<CRMspSelectLinkAccShygunSetting_Result, bool>)((CRMspSelectLinkAccShygunSetting_Result x) => x.PartTitle == "ShygunLanguage")).PartValue);
				}
				else
				{
					shygunSettingViewModel.Language = 3;
				}
				partValue = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunSetting_Result>((IEnumerable<CRMspSelectLinkAccShygunSetting_Result>)list, (Func<CRMspSelectLinkAccShygunSetting_Result, bool>)((CRMspSelectLinkAccShygunSetting_Result x) => x.PartTitle == "ShygunLevel")).PartValue;
				if (!string.IsNullOrWhiteSpace(partValue))
				{
					shygunSettingViewModel.Level = int.Parse(Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunSetting_Result>((IEnumerable<CRMspSelectLinkAccShygunSetting_Result>)list, (Func<CRMspSelectLinkAccShygunSetting_Result, bool>)((CRMspSelectLinkAccShygunSetting_Result x) => x.PartTitle == "ShygunLevel")).PartValue);
				}
				else
				{
					shygunSettingViewModel.Level = 0;
				}
				shygunSettingViewModel.Server = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunSetting_Result>((IEnumerable<CRMspSelectLinkAccShygunSetting_Result>)list, (Func<CRMspSelectLinkAccShygunSetting_Result, bool>)((CRMspSelectLinkAccShygunSetting_Result x) => x.PartTitle == "ShygunServer")).PartValue;
				partValue = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunSetting_Result>((IEnumerable<CRMspSelectLinkAccShygunSetting_Result>)list, (Func<CRMspSelectLinkAccShygunSetting_Result, bool>)((CRMspSelectLinkAccShygunSetting_Result x) => x.PartTitle == "ShygunFrom")).PartValue;
				if (!string.IsNullOrWhiteSpace(partValue))
				{
					shygunSettingViewModel.From = int.Parse(Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunSetting_Result>((IEnumerable<CRMspSelectLinkAccShygunSetting_Result>)list, (Func<CRMspSelectLinkAccShygunSetting_Result, bool>)((CRMspSelectLinkAccShygunSetting_Result x) => x.PartTitle == "ShygunFrom")).PartValue);
				}
				else
				{
					shygunSettingViewModel.From = 0;
				}
				partValue = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunSetting_Result>((IEnumerable<CRMspSelectLinkAccShygunSetting_Result>)list, (Func<CRMspSelectLinkAccShygunSetting_Result, bool>)((CRMspSelectLinkAccShygunSetting_Result x) => x.PartTitle == "ShygunTo")).PartValue;
				if (!string.IsNullOrWhiteSpace(partValue))
				{
					shygunSettingViewModel.To = int.Parse(Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunSetting_Result>((IEnumerable<CRMspSelectLinkAccShygunSetting_Result>)list, (Func<CRMspSelectLinkAccShygunSetting_Result, bool>)((CRMspSelectLinkAccShygunSetting_Result x) => x.PartTitle == "ShygunTo")).PartValue);
				}
				else
				{
					shygunSettingViewModel.To = 0;
				}
				shygunSettingViewModel.IP = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunSetting_Result>((IEnumerable<CRMspSelectLinkAccShygunSetting_Result>)list, (Func<CRMspSelectLinkAccShygunSetting_Result, bool>)((CRMspSelectLinkAccShygunSetting_Result x) => x.PartTitle == "ShygunIP")).PartValue;
				Config config = new Config();
				config.AllowRowSecurity = shygunSettingViewModel.AllowRowSecurity;
				config.AuthUser = shygunSettingViewModel.AuthUser;
				config.AuthPassword = shygunSettingViewModel.AuthPassword;
				config.DataBaseName = shygunSettingViewModel.DataBaseName;
				config.DBUserName = shygunSettingViewModel.DBUserName;
				config.DBPassword = shygunSettingViewModel.DBPassword;
				config.Language = shygunSettingViewModel.Language;
				config.Level = shygunSettingViewModel.Level;
				config.Server = shygunSettingViewModel.Server;
				shygunSettingViewModel.conf = config;
				shygunSettingViewModel.OrdTax = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunSetting_Result>((IEnumerable<CRMspSelectLinkAccShygunSetting_Result>)list, (Func<CRMspSelectLinkAccShygunSetting_Result, bool>)((CRMspSelectLinkAccShygunSetting_Result x) => x.PartTitle == "DefTaxAccLink")).PartValue ?? "";
				shygunSettingViewModel.OrdTaxFieldTitle = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunSetting_Result>((IEnumerable<CRMspSelectLinkAccShygunSetting_Result>)list, (Func<CRMspSelectLinkAccShygunSetting_Result, bool>)((CRMspSelectLinkAccShygunSetting_Result x) => x.PartTitle == "DefTaxAccLink")).PartLabelTitle;
				shygunSettingViewModel.OrdCurrencyUnit = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunSetting_Result>((IEnumerable<CRMspSelectLinkAccShygunSetting_Result>)list, (Func<CRMspSelectLinkAccShygunSetting_Result, bool>)((CRMspSelectLinkAccShygunSetting_Result x) => x.PartTitle == "DefCurrencyUnitId")).PartValue ?? "";
			}
			objectType = "CompanyType";
			list = Enumerable.ToList<CRMspSelectLinkAccShygunSetting_Result>((IEnumerable<CRMspSelectLinkAccShygunSetting_Result>)cRMLinkSpEntities.CRMspSelectLinkAccShygunSetting(settingId, objectType, lCID, result));
			if (list != null)
			{
				shygunSettingViewModel.CmpMoeinAccCode = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunSetting_Result>((IEnumerable<CRMspSelectLinkAccShygunSetting_Result>)list, (Func<CRMspSelectLinkAccShygunSetting_Result, bool>)((CRMspSelectLinkAccShygunSetting_Result x) => x.PartTitle == "CmpMoeinAccCode")).PartValue;
			}
			objectType = "ProductPrice";
			list = Enumerable.ToList<CRMspSelectLinkAccShygunSetting_Result>((IEnumerable<CRMspSelectLinkAccShygunSetting_Result>)cRMLinkSpEntities.CRMspSelectLinkAccShygunSetting(settingId, objectType, lCID, result));
			if (list != null)
			{
				shygunSettingViewModel.PrdPriceGroup = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunSetting_Result>((IEnumerable<CRMspSelectLinkAccShygunSetting_Result>)list, (Func<CRMspSelectLinkAccShygunSetting_Result, bool>)((CRMspSelectLinkAccShygunSetting_Result x) => x.PartTitle == "PrdPriceGroup")).PartValue ?? "";
			}
			objectType = "Order";
			list = Enumerable.ToList<CRMspSelectLinkAccShygunSetting_Result>((IEnumerable<CRMspSelectLinkAccShygunSetting_Result>)cRMLinkSpEntities.CRMspSelectLinkAccShygunSetting(settingId, objectType, lCID, result));
			if (list != null)
			{
				shygunSettingViewModel.OrdRound = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunSetting_Result>((IEnumerable<CRMspSelectLinkAccShygunSetting_Result>)list, (Func<CRMspSelectLinkAccShygunSetting_Result, bool>)((CRMspSelectLinkAccShygunSetting_Result x) => x.PartTitle == "OrdRound")).PartValue ?? "";
				shygunSettingViewModel.OrdRoundFieldTitle = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunSetting_Result>((IEnumerable<CRMspSelectLinkAccShygunSetting_Result>)list, (Func<CRMspSelectLinkAccShygunSetting_Result, bool>)((CRMspSelectLinkAccShygunSetting_Result x) => x.PartTitle == "OrdRound")).PartLabelTitle;
				shygunSettingViewModel.OrdTransportation = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunSetting_Result>((IEnumerable<CRMspSelectLinkAccShygunSetting_Result>)list, (Func<CRMspSelectLinkAccShygunSetting_Result, bool>)((CRMspSelectLinkAccShygunSetting_Result x) => x.PartTitle == "OrdTransportation")).PartValue ?? "";
				shygunSettingViewModel.OrdTransportationFieldTitle = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunSetting_Result>((IEnumerable<CRMspSelectLinkAccShygunSetting_Result>)list, (Func<CRMspSelectLinkAccShygunSetting_Result, bool>)((CRMspSelectLinkAccShygunSetting_Result x) => x.PartTitle == "OrdTransportation")).PartLabelTitle;
			}
			objectType = "CmpProject";
			list = Enumerable.ToList<CRMspSelectLinkAccShygunSetting_Result>((IEnumerable<CRMspSelectLinkAccShygunSetting_Result>)cRMLinkSpEntities.CRMspSelectLinkAccShygunSetting(settingId, objectType, lCID, result));
			if (list != null)
			{
				string partValue2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunSetting_Result>((IEnumerable<CRMspSelectLinkAccShygunSetting_Result>)list, (Func<CRMspSelectLinkAccShygunSetting_Result, bool>)((CRMspSelectLinkAccShygunSetting_Result x) => x.PartTitle == "DefPrjCvnsStatusGroupId")).PartValue;
				shygunSettingViewModel.DefPrjCvnsStatusGroupId = ((!string.IsNullOrWhiteSpace(partValue2)) ? int.Parse(partValue2) : 0);
				shygunSettingViewModel.DefPrjTitle = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunSetting_Result>((IEnumerable<CRMspSelectLinkAccShygunSetting_Result>)list, (Func<CRMspSelectLinkAccShygunSetting_Result, bool>)((CRMspSelectLinkAccShygunSetting_Result x) => x.PartTitle == "DefPrjTitle")).PartValue ?? "";
			}
			objectType = "Wrhs";
			list = Enumerable.ToList<CRMspSelectLinkAccShygunSetting_Result>((IEnumerable<CRMspSelectLinkAccShygunSetting_Result>)cRMLinkSpEntities.CRMspSelectLinkAccShygunSetting(settingId, objectType, lCID, result));
			if (list != null)
			{
				string partValue3 = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunSetting_Result>((IEnumerable<CRMspSelectLinkAccShygunSetting_Result>)list, (Func<CRMspSelectLinkAccShygunSetting_Result, bool>)((CRMspSelectLinkAccShygunSetting_Result x) => x.PartTitle == "WrhsSyncTypeId")).PartValue;
				shygunSettingViewModel.WrhsSyncTypeId = ((!string.IsNullOrWhiteSpace(partValue3)) ? int.Parse(partValue3) : 0);
			}
			objectType = "PrdGroup";
			list = Enumerable.ToList<CRMspSelectLinkAccShygunSetting_Result>((IEnumerable<CRMspSelectLinkAccShygunSetting_Result>)cRMLinkSpEntities.CRMspSelectLinkAccShygunSetting(settingId, objectType, lCID, result));
			if (list != null)
			{
				string partValue4 = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunSetting_Result>((IEnumerable<CRMspSelectLinkAccShygunSetting_Result>)list, (Func<CRMspSelectLinkAccShygunSetting_Result, bool>)((CRMspSelectLinkAccShygunSetting_Result x) => x.PartTitle == "PrdGroupSyncTypeId")).PartValue;
				shygunSettingViewModel.PrdGroupSyncTypeId = ((!string.IsNullOrWhiteSpace(partValue4)) ? int.Parse(partValue4) : 0);
			}
			objectType = "Prd";
			list = Enumerable.ToList<CRMspSelectLinkAccShygunSetting_Result>((IEnumerable<CRMspSelectLinkAccShygunSetting_Result>)cRMLinkSpEntities.CRMspSelectLinkAccShygunSetting(settingId, objectType, lCID, result));
			if (list != null)
			{
				string partValue5 = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunSetting_Result>((IEnumerable<CRMspSelectLinkAccShygunSetting_Result>)list, (Func<CRMspSelectLinkAccShygunSetting_Result, bool>)((CRMspSelectLinkAccShygunSetting_Result x) => x.PartTitle == "PrdLinkedField")).PartValue;
				shygunSettingViewModel.PrdLinkedField = ((!string.IsNullOrWhiteSpace(partValue5)) ? partValue5 : "");
			}
			objectType = "Doc";
			list = Enumerable.ToList<CRMspSelectLinkAccShygunSetting_Result>((IEnumerable<CRMspSelectLinkAccShygunSetting_Result>)cRMLinkSpEntities.CRMspSelectLinkAccShygunSetting(settingId, objectType, lCID, result));
			if (list != null)
			{
				shygunSettingViewModel.DocMovementAccountNumber = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunSetting_Result>((IEnumerable<CRMspSelectLinkAccShygunSetting_Result>)list, (Func<CRMspSelectLinkAccShygunSetting_Result, bool>)((CRMspSelectLinkAccShygunSetting_Result x) => x.PartTitle == "DocMovementAccountNumber")).PartValue;
				shygunSettingViewModel.DocMovementAccountNumber_PartLabelTitle = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunSetting_Result>((IEnumerable<CRMspSelectLinkAccShygunSetting_Result>)list, (Func<CRMspSelectLinkAccShygunSetting_Result, bool>)((CRMspSelectLinkAccShygunSetting_Result x) => x.PartTitle == "DocMovementAccountNumber")).PartLabelTitle;
				shygunSettingViewModel.DocMovementAccountGUId = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunSetting_Result>((IEnumerable<CRMspSelectLinkAccShygunSetting_Result>)list, (Func<CRMspSelectLinkAccShygunSetting_Result, bool>)((CRMspSelectLinkAccShygunSetting_Result x) => x.PartTitle == "DocMovementAccountGUId")).PartValue;
				shygunSettingViewModel.DocMovementAccountGUId_Id = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunSetting_Result>((IEnumerable<CRMspSelectLinkAccShygunSetting_Result>)list, (Func<CRMspSelectLinkAccShygunSetting_Result, bool>)((CRMspSelectLinkAccShygunSetting_Result x) => x.PartTitle == "DocMovementAccountGUId")).LinkAccShygunSettingId;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMLinkSpEntities.Dispose();
		}
		return shygunSettingViewModel;
	}

	public static ShygunSettingDetailsViewModel GetShygunSettingDetails(int settingDetailId = 0, int objId = 0, string objectType = "")
	{
		ShygunSettingDetailsViewModel shygunSettingDetailsViewModel = new ShygunSettingDetailsViewModel();
		CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (settingDetailId < 0)
			{
				settingDetailId = 0;
			}
			List<CRMspSelectLinkAccShygunSettingDetails_Result> list = Enumerable.ToList<CRMspSelectLinkAccShygunSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccShygunSettingDetails_Result>)cRMLinkSpEntities.CRMspSelectLinkAccShygunSettingDetails(settingDetailId, objId, objectType, lCID, result));
			if (list != null && Enumerable.Any<CRMspSelectLinkAccShygunSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccShygunSettingDetails_Result>)list))
			{
				if (Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccShygunSettingDetails_Result>)list, (Func<CRMspSelectLinkAccShygunSettingDetails_Result, bool>)((CRMspSelectLinkAccShygunSettingDetails_Result x) => x.PartTitle == "VouchType")) != null)
				{
					string partValue = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccShygunSettingDetails_Result>)list, (Func<CRMspSelectLinkAccShygunSettingDetails_Result, bool>)((CRMspSelectLinkAccShygunSettingDetails_Result x) => x.PartTitle == "VouchType")).PartValue;
					shygunSettingDetailsViewModel.OrdPayVouchType = ((!string.IsNullOrWhiteSpace(partValue)) ? int.Parse(partValue) : 0);
				}
				if (Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccShygunSettingDetails_Result>)list, (Func<CRMspSelectLinkAccShygunSettingDetails_Result, bool>)((CRMspSelectLinkAccShygunSettingDetails_Result x) => x.PartTitle == "VouchDateType")) != null)
				{
					string partValue2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccShygunSettingDetails_Result>)list, (Func<CRMspSelectLinkAccShygunSettingDetails_Result, bool>)((CRMspSelectLinkAccShygunSettingDetails_Result x) => x.PartTitle == "VouchDateType")).PartValue;
					shygunSettingDetailsViewModel.OrdPayVouchDateType = ((!string.IsNullOrWhiteSpace(partValue2)) ? int.Parse(partValue2) : 0);
				}
				if (Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccShygunSettingDetails_Result>)list, (Func<CRMspSelectLinkAccShygunSettingDetails_Result, bool>)((CRMspSelectLinkAccShygunSettingDetails_Result x) => x.PartTitle == "CurrencyAbb1")) != null)
				{
					string partValue3 = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccShygunSettingDetails_Result>)list, (Func<CRMspSelectLinkAccShygunSettingDetails_Result, bool>)((CRMspSelectLinkAccShygunSettingDetails_Result x) => x.PartTitle == "CurrencyAbb1")).PartValue;
					shygunSettingDetailsViewModel.OrdPayCurrencyAbb1 = ((!string.IsNullOrWhiteSpace(partValue3)) ? partValue3 : "IRR");
				}
				if (Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccShygunSettingDetails_Result>)list, (Func<CRMspSelectLinkAccShygunSettingDetails_Result, bool>)((CRMspSelectLinkAccShygunSettingDetails_Result x) => x.PartTitle == "Rate")) != null)
				{
					string partValue4 = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccShygunSettingDetails_Result>)list, (Func<CRMspSelectLinkAccShygunSettingDetails_Result, bool>)((CRMspSelectLinkAccShygunSettingDetails_Result x) => x.PartTitle == "Rate")).PartValue;
					shygunSettingDetailsViewModel.OrdPayRate = ((!string.IsNullOrWhiteSpace(partValue4)) ? int.Parse(partValue4) : 0);
					if (shygunSettingDetailsViewModel.OrdPayRate == 0.0)
					{
						shygunSettingDetailsViewModel.OrdPayRate = 1.0;
					}
				}
				if (Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccShygunSettingDetails_Result>)list, (Func<CRMspSelectLinkAccShygunSettingDetails_Result, bool>)((CRMspSelectLinkAccShygunSettingDetails_Result x) => x.PartTitle == "DepartmentNumber")) != null)
				{
					string partValue5 = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccShygunSettingDetails_Result>)list, (Func<CRMspSelectLinkAccShygunSettingDetails_Result, bool>)((CRMspSelectLinkAccShygunSettingDetails_Result x) => x.PartTitle == "DepartmentNumber")).PartValue;
					shygunSettingDetailsViewModel.OrdPayDepartmentNumber = ((!string.IsNullOrWhiteSpace(partValue5)) ? partValue5 : "");
				}
				if (Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccShygunSettingDetails_Result>)list, (Func<CRMspSelectLinkAccShygunSettingDetails_Result, bool>)((CRMspSelectLinkAccShygunSettingDetails_Result x) => x.PartTitle == "PayType")) != null)
				{
					string partValue6 = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccShygunSettingDetails_Result>)list, (Func<CRMspSelectLinkAccShygunSettingDetails_Result, bool>)((CRMspSelectLinkAccShygunSettingDetails_Result x) => x.PartTitle == "PayType")).PartValue;
					shygunSettingDetailsViewModel.OrdPayType = ((!string.IsNullOrWhiteSpace(partValue6)) ? int.Parse(partValue6) : 0);
				}
				if (Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccShygunSettingDetails_Result>)list, (Func<CRMspSelectLinkAccShygunSettingDetails_Result, bool>)((CRMspSelectLinkAccShygunSettingDetails_Result x) => x.PartTitle == "DueDateType")) != null)
				{
					string partValue7 = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccShygunSettingDetails_Result>)list, (Func<CRMspSelectLinkAccShygunSettingDetails_Result, bool>)((CRMspSelectLinkAccShygunSettingDetails_Result x) => x.PartTitle == "DueDateType")).PartValue;
					shygunSettingDetailsViewModel.OrdPayDueDateType = ((!string.IsNullOrWhiteSpace(partValue7)) ? int.Parse(partValue7) : 0);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMLinkSpEntities.Dispose();
		}
		return shygunSettingDetailsViewModel;
	}

	public static int GetPrdGroupSyncTypeId()
	{
		int result = 0;
		CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			if (cRMspSelectCrmsysSetting_Result != null && cRMspSelectCrmsysSetting_Result.LinkAccSystemId.HasValue)
			{
				int result3 = 0;
				int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result3);
				switch (result3)
				{
				case 8:
				{
					List<CRMspSelectLinkAccShygunSetting_Result> list2 = Enumerable.ToList<CRMspSelectLinkAccShygunSetting_Result>((IEnumerable<CRMspSelectLinkAccShygunSetting_Result>)cRMLinkSpEntities.CRMspSelectLinkAccShygunSetting(0, "PrdGroup", lCID, result2));
					if (list2 != null && Enumerable.Any<CRMspSelectLinkAccShygunSetting_Result>((IEnumerable<CRMspSelectLinkAccShygunSetting_Result>)list2))
					{
						CRMspSelectLinkAccShygunSetting_Result cRMspSelectLinkAccShygunSetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunSetting_Result>((IEnumerable<CRMspSelectLinkAccShygunSetting_Result>)list2, (Func<CRMspSelectLinkAccShygunSetting_Result, bool>)((CRMspSelectLinkAccShygunSetting_Result x) => x.PartTitle == "PrdGroupSyncTypeId"));
						if (cRMspSelectLinkAccShygunSetting_Result != null)
						{
							result = ((!string.IsNullOrWhiteSpace(cRMspSelectLinkAccShygunSetting_Result.PartValue)) ? int.Parse(cRMspSelectLinkAccShygunSetting_Result.PartValue) : 0);
						}
					}
					break;
				}
				case 9:
				{
					List<CRMspSelectLinkAccShygunIISetting_Result> list = Enumerable.ToList<CRMspSelectLinkAccShygunIISetting_Result>((IEnumerable<CRMspSelectLinkAccShygunIISetting_Result>)cRMLinkSpEntities.CRMspSelectLinkAccShygunIISetting(0, "ProductGroup", lCID, result2));
					if (list != null && Enumerable.Any<CRMspSelectLinkAccShygunIISetting_Result>((IEnumerable<CRMspSelectLinkAccShygunIISetting_Result>)list))
					{
						CRMspSelectLinkAccShygunIISetting_Result cRMspSelectLinkAccShygunIISetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunIISetting_Result>((IEnumerable<CRMspSelectLinkAccShygunIISetting_Result>)list, (Func<CRMspSelectLinkAccShygunIISetting_Result, bool>)((CRMspSelectLinkAccShygunIISetting_Result x) => x.PartTitle == "PrdGroupSyncTypeId"));
						if (cRMspSelectLinkAccShygunIISetting_Result != null)
						{
							result = ((!string.IsNullOrWhiteSpace(cRMspSelectLinkAccShygunIISetting_Result.PartValue)) ? int.Parse(cRMspSelectLinkAccShygunIISetting_Result.PartValue) : 0);
						}
					}
					break;
				}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMLinkSpEntities.Dispose();
		}
		return result;
	}

	public static ShygunIISettingViewModel GetShygunIISetting(int settingId = 0, string objectType = "")
	{
		ShygunIISettingViewModel shygunIISettingViewModel = new ShygunIISettingViewModel();
		CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (settingId < 0)
			{
				settingId = 0;
			}
			if (string.IsNullOrWhiteSpace(objectType))
			{
				objectType = "Setting";
			}
			List<CRMspSelectLinkAccShygunIISetting_Result> list = Enumerable.ToList<CRMspSelectLinkAccShygunIISetting_Result>((IEnumerable<CRMspSelectLinkAccShygunIISetting_Result>)cRMLinkSpEntities.CRMspSelectLinkAccShygunIISetting(settingId, objectType, lCID, result));
			if (list != null)
			{
				string partValue = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunIISetting_Result>((IEnumerable<CRMspSelectLinkAccShygunIISetting_Result>)list, (Func<CRMspSelectLinkAccShygunIISetting_Result, bool>)((CRMspSelectLinkAccShygunIISetting_Result x) => x.PartTitle == "ShygunAllowRowSecurity")).PartValue;
				if (!string.IsNullOrWhiteSpace(partValue) && partValue == "1")
				{
					shygunIISettingViewModel.AllowRowSecurity = true;
				}
				else
				{
					shygunIISettingViewModel.AllowRowSecurity = false;
				}
				shygunIISettingViewModel.AuthUser = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunIISetting_Result>((IEnumerable<CRMspSelectLinkAccShygunIISetting_Result>)list, (Func<CRMspSelectLinkAccShygunIISetting_Result, bool>)((CRMspSelectLinkAccShygunIISetting_Result x) => x.PartTitle == "ShygunAuthUser")).PartValue;
				shygunIISettingViewModel.AuthPassword = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunIISetting_Result>((IEnumerable<CRMspSelectLinkAccShygunIISetting_Result>)list, (Func<CRMspSelectLinkAccShygunIISetting_Result, bool>)((CRMspSelectLinkAccShygunIISetting_Result x) => x.PartTitle == "ShygunAuthPassword")).PartValue;
				shygunIISettingViewModel.DataBaseName = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunIISetting_Result>((IEnumerable<CRMspSelectLinkAccShygunIISetting_Result>)list, (Func<CRMspSelectLinkAccShygunIISetting_Result, bool>)((CRMspSelectLinkAccShygunIISetting_Result x) => x.PartTitle == "ShygunDataBaseName")).PartValue;
				shygunIISettingViewModel.DBUserName = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunIISetting_Result>((IEnumerable<CRMspSelectLinkAccShygunIISetting_Result>)list, (Func<CRMspSelectLinkAccShygunIISetting_Result, bool>)((CRMspSelectLinkAccShygunIISetting_Result x) => x.PartTitle == "ShygunDBUserName")).PartValue;
				shygunIISettingViewModel.DBPassword = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunIISetting_Result>((IEnumerable<CRMspSelectLinkAccShygunIISetting_Result>)list, (Func<CRMspSelectLinkAccShygunIISetting_Result, bool>)((CRMspSelectLinkAccShygunIISetting_Result x) => x.PartTitle == "ShygunDBPassword")).PartValue;
				partValue = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunIISetting_Result>((IEnumerable<CRMspSelectLinkAccShygunIISetting_Result>)list, (Func<CRMspSelectLinkAccShygunIISetting_Result, bool>)((CRMspSelectLinkAccShygunIISetting_Result x) => x.PartTitle == "ShygunLanguage")).PartValue;
				if (!string.IsNullOrWhiteSpace(partValue))
				{
					shygunIISettingViewModel.Language = int.Parse(Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunIISetting_Result>((IEnumerable<CRMspSelectLinkAccShygunIISetting_Result>)list, (Func<CRMspSelectLinkAccShygunIISetting_Result, bool>)((CRMspSelectLinkAccShygunIISetting_Result x) => x.PartTitle == "ShygunLanguage")).PartValue);
				}
				else
				{
					shygunIISettingViewModel.Language = 3;
				}
				partValue = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunIISetting_Result>((IEnumerable<CRMspSelectLinkAccShygunIISetting_Result>)list, (Func<CRMspSelectLinkAccShygunIISetting_Result, bool>)((CRMspSelectLinkAccShygunIISetting_Result x) => x.PartTitle == "ShygunLevel")).PartValue;
				if (!string.IsNullOrWhiteSpace(partValue))
				{
					shygunIISettingViewModel.Level = int.Parse(Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunIISetting_Result>((IEnumerable<CRMspSelectLinkAccShygunIISetting_Result>)list, (Func<CRMspSelectLinkAccShygunIISetting_Result, bool>)((CRMspSelectLinkAccShygunIISetting_Result x) => x.PartTitle == "ShygunLevel")).PartValue);
				}
				else
				{
					shygunIISettingViewModel.Level = 0;
				}
				shygunIISettingViewModel.Server = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunIISetting_Result>((IEnumerable<CRMspSelectLinkAccShygunIISetting_Result>)list, (Func<CRMspSelectLinkAccShygunIISetting_Result, bool>)((CRMspSelectLinkAccShygunIISetting_Result x) => x.PartTitle == "ShygunServerName")).PartValue;
				partValue = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunIISetting_Result>((IEnumerable<CRMspSelectLinkAccShygunIISetting_Result>)list, (Func<CRMspSelectLinkAccShygunIISetting_Result, bool>)((CRMspSelectLinkAccShygunIISetting_Result x) => x.PartTitle == "ShygunStartRowNumber")).PartValue;
				if (!string.IsNullOrWhiteSpace(partValue))
				{
					shygunIISettingViewModel.StartRowNumber = int.Parse(Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunIISetting_Result>((IEnumerable<CRMspSelectLinkAccShygunIISetting_Result>)list, (Func<CRMspSelectLinkAccShygunIISetting_Result, bool>)((CRMspSelectLinkAccShygunIISetting_Result x) => x.PartTitle == "ShygunStartRowNumber")).PartValue);
				}
				else
				{
					shygunIISettingViewModel.StartRowNumber = 0;
				}
				partValue = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunIISetting_Result>((IEnumerable<CRMspSelectLinkAccShygunIISetting_Result>)list, (Func<CRMspSelectLinkAccShygunIISetting_Result, bool>)((CRMspSelectLinkAccShygunIISetting_Result x) => x.PartTitle == "ShygunCountRowInEveryReport")).PartValue;
				if (!string.IsNullOrWhiteSpace(partValue))
				{
					shygunIISettingViewModel.CountRowInEveryReport = int.Parse(Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunIISetting_Result>((IEnumerable<CRMspSelectLinkAccShygunIISetting_Result>)list, (Func<CRMspSelectLinkAccShygunIISetting_Result, bool>)((CRMspSelectLinkAccShygunIISetting_Result x) => x.PartTitle == "ShygunCountRowInEveryReport")).PartValue);
				}
				else
				{
					shygunIISettingViewModel.CountRowInEveryReport = 0;
				}
				shygunIISettingViewModel.IP = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunIISetting_Result>((IEnumerable<CRMspSelectLinkAccShygunIISetting_Result>)list, (Func<CRMspSelectLinkAccShygunIISetting_Result, bool>)((CRMspSelectLinkAccShygunIISetting_Result x) => x.PartTitle == "ShygunIP")).PartValue;
				CRMspSelectLinkAccShygunIISetting_Result cRMspSelectLinkAccShygunIISetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunIISetting_Result>((IEnumerable<CRMspSelectLinkAccShygunIISetting_Result>)list, (Func<CRMspSelectLinkAccShygunIISetting_Result, bool>)((CRMspSelectLinkAccShygunIISetting_Result x) => x.PartTitle == "ShygunSaleMoinNumber"));
				if (cRMspSelectLinkAccShygunIISetting_Result != null)
				{
					shygunIISettingViewModel.ShygunSaleMoinNumber = cRMspSelectLinkAccShygunIISetting_Result.PartValue ?? "";
					shygunIISettingViewModel.ShygunSaleMoinNumberFieldTitle = cRMspSelectLinkAccShygunIISetting_Result.PartLabelTitle ?? "";
				}
				Config config = new Config();
				config.AllowRowSecurity = shygunIISettingViewModel.AllowRowSecurity;
				config.AuthUser = shygunIISettingViewModel.AuthUser;
				config.AuthPassword = shygunIISettingViewModel.AuthPassword;
				config.DataBaseName = shygunIISettingViewModel.DataBaseName;
				config.DBUserName = shygunIISettingViewModel.DBUserName;
				config.DBPassword = shygunIISettingViewModel.DBPassword;
				config.Language = shygunIISettingViewModel.Language;
				config.Level = shygunIISettingViewModel.Level;
				config.Server = shygunIISettingViewModel.Server;
				shygunIISettingViewModel.conf = config;
			}
			list = Enumerable.ToList<CRMspSelectLinkAccShygunIISetting_Result>((IEnumerable<CRMspSelectLinkAccShygunIISetting_Result>)cRMLinkSpEntities.CRMspSelectLinkAccShygunIISetting(settingId, "ProductGroup", lCID, result));
			if (list != null && Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunIISetting_Result>((IEnumerable<CRMspSelectLinkAccShygunIISetting_Result>)list, (Func<CRMspSelectLinkAccShygunIISetting_Result, bool>)((CRMspSelectLinkAccShygunIISetting_Result x) => x.PartTitle == "PrdGroupSyncTypeId")) != null)
			{
				string partValue2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunIISetting_Result>((IEnumerable<CRMspSelectLinkAccShygunIISetting_Result>)list, (Func<CRMspSelectLinkAccShygunIISetting_Result, bool>)((CRMspSelectLinkAccShygunIISetting_Result x) => x.PartTitle == "PrdGroupSyncTypeId")).PartValue;
				shygunIISettingViewModel.PrdGroupSyncTypeId = ((!string.IsNullOrWhiteSpace(partValue2)) ? int.Parse(partValue2) : 0);
			}
			list = Enumerable.ToList<CRMspSelectLinkAccShygunIISetting_Result>((IEnumerable<CRMspSelectLinkAccShygunIISetting_Result>)cRMLinkSpEntities.CRMspSelectLinkAccShygunIISetting(settingId, "Product", lCID, result));
			if (list != null && Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunIISetting_Result>((IEnumerable<CRMspSelectLinkAccShygunIISetting_Result>)list, (Func<CRMspSelectLinkAccShygunIISetting_Result, bool>)((CRMspSelectLinkAccShygunIISetting_Result x) => x.PartTitle == "PrdLinkedField")) != null)
			{
				string partValue3 = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunIISetting_Result>((IEnumerable<CRMspSelectLinkAccShygunIISetting_Result>)list, (Func<CRMspSelectLinkAccShygunIISetting_Result, bool>)((CRMspSelectLinkAccShygunIISetting_Result x) => x.PartTitle == "PrdLinkedField")).PartValue;
				shygunIISettingViewModel.PrdLinkedField = ((!string.IsNullOrWhiteSpace(partValue3)) ? partValue3 : "");
			}
			list = Enumerable.ToList<CRMspSelectLinkAccShygunIISetting_Result>((IEnumerable<CRMspSelectLinkAccShygunIISetting_Result>)cRMLinkSpEntities.CRMspSelectLinkAccShygunIISetting(settingId, "Warehouse", lCID, result));
			if (list != null && Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunIISetting_Result>((IEnumerable<CRMspSelectLinkAccShygunIISetting_Result>)list, (Func<CRMspSelectLinkAccShygunIISetting_Result, bool>)((CRMspSelectLinkAccShygunIISetting_Result x) => x.PartTitle == "WrhsSyncTypeId")) != null)
			{
				string partValue4 = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunIISetting_Result>((IEnumerable<CRMspSelectLinkAccShygunIISetting_Result>)list, (Func<CRMspSelectLinkAccShygunIISetting_Result, bool>)((CRMspSelectLinkAccShygunIISetting_Result x) => x.PartTitle == "WrhsSyncTypeId")).PartValue;
				shygunIISettingViewModel.WrhsSyncTypeId = ((!string.IsNullOrWhiteSpace(partValue4)) ? int.Parse(partValue4) : 0);
			}
			list = Enumerable.ToList<CRMspSelectLinkAccShygunIISetting_Result>((IEnumerable<CRMspSelectLinkAccShygunIISetting_Result>)cRMLinkSpEntities.CRMspSelectLinkAccShygunIISetting(settingId, "Order", lCID, result));
			if (list != null)
			{
				CRMspSelectLinkAccShygunIISetting_Result cRMspSelectLinkAccShygunIISetting_Result2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunIISetting_Result>((IEnumerable<CRMspSelectLinkAccShygunIISetting_Result>)list, (Func<CRMspSelectLinkAccShygunIISetting_Result, bool>)((CRMspSelectLinkAccShygunIISetting_Result x) => x.PartTitle == "DefTaxAccCode"));
				if (cRMspSelectLinkAccShygunIISetting_Result2 != null)
				{
					shygunIISettingViewModel.DefTax = cRMspSelectLinkAccShygunIISetting_Result2.PartValue ?? "";
					shygunIISettingViewModel.DefTaxFieldTitle = cRMspSelectLinkAccShygunIISetting_Result2.PartLabelTitle ?? "";
				}
				CRMspSelectLinkAccShygunIISetting_Result cRMspSelectLinkAccShygunIISetting_Result3 = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunIISetting_Result>((IEnumerable<CRMspSelectLinkAccShygunIISetting_Result>)list, (Func<CRMspSelectLinkAccShygunIISetting_Result, bool>)((CRMspSelectLinkAccShygunIISetting_Result x) => x.PartTitle == "DefRoundAccCode"));
				if (cRMspSelectLinkAccShygunIISetting_Result3 != null)
				{
					shygunIISettingViewModel.DefRound = cRMspSelectLinkAccShygunIISetting_Result3.PartValue ?? "";
					shygunIISettingViewModel.DefRoundFieldTitle = cRMspSelectLinkAccShygunIISetting_Result3.PartLabelTitle ?? "";
				}
				CRMspSelectLinkAccShygunIISetting_Result cRMspSelectLinkAccShygunIISetting_Result4 = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunIISetting_Result>((IEnumerable<CRMspSelectLinkAccShygunIISetting_Result>)list, (Func<CRMspSelectLinkAccShygunIISetting_Result, bool>)((CRMspSelectLinkAccShygunIISetting_Result x) => x.PartTitle == "DefTransportationAccCode"));
				if (cRMspSelectLinkAccShygunIISetting_Result4 != null)
				{
					shygunIISettingViewModel.DefTransportation = cRMspSelectLinkAccShygunIISetting_Result4.PartValue ?? "";
					shygunIISettingViewModel.DefTransportationFieldTitle = cRMspSelectLinkAccShygunIISetting_Result4.PartLabelTitle ?? "";
				}
				CRMspSelectLinkAccShygunIISetting_Result cRMspSelectLinkAccShygunIISetting_Result5 = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunIISetting_Result>((IEnumerable<CRMspSelectLinkAccShygunIISetting_Result>)list, (Func<CRMspSelectLinkAccShygunIISetting_Result, bool>)((CRMspSelectLinkAccShygunIISetting_Result x) => x.PartTitle == "DefCurrencyUnitId"));
				if (cRMspSelectLinkAccShygunIISetting_Result5 != null)
				{
					shygunIISettingViewModel.DefCurrencyUnit = cRMspSelectLinkAccShygunIISetting_Result5.PartValue ?? "";
				}
				CRMspSelectLinkAccShygunIISetting_Result cRMspSelectLinkAccShygunIISetting_Result6 = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunIISetting_Result>((IEnumerable<CRMspSelectLinkAccShygunIISetting_Result>)list, (Func<CRMspSelectLinkAccShygunIISetting_Result, bool>)((CRMspSelectLinkAccShygunIISetting_Result x) => x.PartTitle == "PordAccountGuId"));
				if (cRMspSelectLinkAccShygunIISetting_Result6 != null)
				{
					shygunIISettingViewModel.PordAccountGuId = cRMspSelectLinkAccShygunIISetting_Result6.PartValue ?? "";
				}
				CRMspSelectLinkAccShygunIISetting_Result cRMspSelectLinkAccShygunIISetting_Result7 = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunIISetting_Result>((IEnumerable<CRMspSelectLinkAccShygunIISetting_Result>)list, (Func<CRMspSelectLinkAccShygunIISetting_Result, bool>)((CRMspSelectLinkAccShygunIISetting_Result x) => x.PartTitle == "PordAccountNumber"));
				if (cRMspSelectLinkAccShygunIISetting_Result7 != null)
				{
					shygunIISettingViewModel.PordAccountNumber = cRMspSelectLinkAccShygunIISetting_Result7.PartValue ?? "";
					shygunIISettingViewModel.PordAccountNumberFieldTitle = cRMspSelectLinkAccShygunIISetting_Result7.PartLabelTitle ?? "";
				}
				CRMspSelectLinkAccShygunIISetting_Result cRMspSelectLinkAccShygunIISetting_Result8 = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunIISetting_Result>((IEnumerable<CRMspSelectLinkAccShygunIISetting_Result>)list, (Func<CRMspSelectLinkAccShygunIISetting_Result, bool>)((CRMspSelectLinkAccShygunIISetting_Result x) => x.PartTitle == "OrdAccountGuId"));
				if (cRMspSelectLinkAccShygunIISetting_Result8 != null)
				{
					shygunIISettingViewModel.OrdAccountGuId = cRMspSelectLinkAccShygunIISetting_Result8.PartValue ?? "";
				}
				CRMspSelectLinkAccShygunIISetting_Result cRMspSelectLinkAccShygunIISetting_Result9 = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunIISetting_Result>((IEnumerable<CRMspSelectLinkAccShygunIISetting_Result>)list, (Func<CRMspSelectLinkAccShygunIISetting_Result, bool>)((CRMspSelectLinkAccShygunIISetting_Result x) => x.PartTitle == "OrdAccountNumber"));
				if (cRMspSelectLinkAccShygunIISetting_Result9 != null)
				{
					shygunIISettingViewModel.OrdAccountNumber = cRMspSelectLinkAccShygunIISetting_Result9.PartValue ?? "";
					shygunIISettingViewModel.OrdAccountNumberFieldTitle = cRMspSelectLinkAccShygunIISetting_Result9.PartLabelTitle ?? "";
				}
			}
			list = Enumerable.ToList<CRMspSelectLinkAccShygunIISetting_Result>((IEnumerable<CRMspSelectLinkAccShygunIISetting_Result>)cRMLinkSpEntities.CRMspSelectLinkAccShygunIISetting(settingId, "CmpProject", lCID, result));
			if (list != null)
			{
				CRMspSelectLinkAccShygunIISetting_Result cRMspSelectLinkAccShygunIISetting_Result10 = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunIISetting_Result>((IEnumerable<CRMspSelectLinkAccShygunIISetting_Result>)list, (Func<CRMspSelectLinkAccShygunIISetting_Result, bool>)((CRMspSelectLinkAccShygunIISetting_Result x) => x.PartTitle == "DefPrjTitle"));
				if (cRMspSelectLinkAccShygunIISetting_Result10 != null)
				{
					shygunIISettingViewModel.DefPrjTitle = cRMspSelectLinkAccShygunIISetting_Result10.PartValue ?? "";
				}
				CRMspSelectLinkAccShygunIISetting_Result cRMspSelectLinkAccShygunIISetting_Result11 = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunIISetting_Result>((IEnumerable<CRMspSelectLinkAccShygunIISetting_Result>)list, (Func<CRMspSelectLinkAccShygunIISetting_Result, bool>)((CRMspSelectLinkAccShygunIISetting_Result x) => x.PartTitle == "DefPrjCvnsStatusGroupId"));
				if (cRMspSelectLinkAccShygunIISetting_Result11 != null)
				{
					shygunIISettingViewModel.DefPrjCvnsStatusGroupId = int.Parse(cRMspSelectLinkAccShygunIISetting_Result11.PartValue ?? "0");
				}
			}
			list = Enumerable.ToList<CRMspSelectLinkAccShygunIISetting_Result>((IEnumerable<CRMspSelectLinkAccShygunIISetting_Result>)cRMLinkSpEntities.CRMspSelectLinkAccShygunIISetting(settingId, "Doc", lCID, result));
			if (list != null)
			{
				CRMspSelectLinkAccShygunIISetting_Result cRMspSelectLinkAccShygunIISetting_Result12 = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunIISetting_Result>((IEnumerable<CRMspSelectLinkAccShygunIISetting_Result>)list, (Func<CRMspSelectLinkAccShygunIISetting_Result, bool>)((CRMspSelectLinkAccShygunIISetting_Result x) => x.PartTitle == "DocAccountGuId"));
				if (cRMspSelectLinkAccShygunIISetting_Result12 != null)
				{
					shygunIISettingViewModel.DocAccountGuId = cRMspSelectLinkAccShygunIISetting_Result12.PartValue ?? "";
				}
				CRMspSelectLinkAccShygunIISetting_Result cRMspSelectLinkAccShygunIISetting_Result13 = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunIISetting_Result>((IEnumerable<CRMspSelectLinkAccShygunIISetting_Result>)list, (Func<CRMspSelectLinkAccShygunIISetting_Result, bool>)((CRMspSelectLinkAccShygunIISetting_Result x) => x.PartTitle == "DocAccountNumber"));
				if (cRMspSelectLinkAccShygunIISetting_Result13 != null)
				{
					shygunIISettingViewModel.DocAccountNumber = cRMspSelectLinkAccShygunIISetting_Result13.PartValue ?? "";
					shygunIISettingViewModel.DocAccountNumberFieldTitle = cRMspSelectLinkAccShygunIISetting_Result13.PartLabelTitle ?? "";
				}
				CRMspSelectLinkAccShygunIISetting_Result cRMspSelectLinkAccShygunIISetting_Result14 = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunIISetting_Result>((IEnumerable<CRMspSelectLinkAccShygunIISetting_Result>)list, (Func<CRMspSelectLinkAccShygunIISetting_Result, bool>)((CRMspSelectLinkAccShygunIISetting_Result x) => x.PartTitle == "DraftAccountGuId"));
				if (cRMspSelectLinkAccShygunIISetting_Result14 != null)
				{
					shygunIISettingViewModel.DraftAccountGuId = cRMspSelectLinkAccShygunIISetting_Result14.PartValue ?? "";
				}
				CRMspSelectLinkAccShygunIISetting_Result cRMspSelectLinkAccShygunIISetting_Result15 = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunIISetting_Result>((IEnumerable<CRMspSelectLinkAccShygunIISetting_Result>)list, (Func<CRMspSelectLinkAccShygunIISetting_Result, bool>)((CRMspSelectLinkAccShygunIISetting_Result x) => x.PartTitle == "DraftAccountNumber"));
				if (cRMspSelectLinkAccShygunIISetting_Result15 != null)
				{
					shygunIISettingViewModel.DraftAccountNumber = cRMspSelectLinkAccShygunIISetting_Result15.PartValue ?? "";
					shygunIISettingViewModel.DraftAccountNumberFieldTitle = cRMspSelectLinkAccShygunIISetting_Result15.PartLabelTitle ?? "";
				}
				CRMspSelectLinkAccShygunIISetting_Result cRMspSelectLinkAccShygunIISetting_Result16 = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunIISetting_Result>((IEnumerable<CRMspSelectLinkAccShygunIISetting_Result>)list, (Func<CRMspSelectLinkAccShygunIISetting_Result, bool>)((CRMspSelectLinkAccShygunIISetting_Result x) => x.PartTitle == "WrhsMovementAccountGuId"));
				if (cRMspSelectLinkAccShygunIISetting_Result16 != null)
				{
					shygunIISettingViewModel.WrhsMovementAccountGuId = cRMspSelectLinkAccShygunIISetting_Result16.PartValue ?? "";
				}
				CRMspSelectLinkAccShygunIISetting_Result cRMspSelectLinkAccShygunIISetting_Result17 = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunIISetting_Result>((IEnumerable<CRMspSelectLinkAccShygunIISetting_Result>)list, (Func<CRMspSelectLinkAccShygunIISetting_Result, bool>)((CRMspSelectLinkAccShygunIISetting_Result x) => x.PartTitle == "WrhsMovementAccountNumber"));
				if (cRMspSelectLinkAccShygunIISetting_Result17 != null)
				{
					shygunIISettingViewModel.WrhsMovementAccountNumber = cRMspSelectLinkAccShygunIISetting_Result17.PartValue ?? "";
					shygunIISettingViewModel.WrhsMovementAccountNumberFieldTitle = cRMspSelectLinkAccShygunIISetting_Result17.PartLabelTitle ?? "";
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMLinkSpEntities.Dispose();
		}
		return shygunIISettingViewModel;
	}

	public static ShomaranSettingViewModel GetShomaranSetting(int settingId = 0, string objectType = "")
	{
		ShomaranSettingViewModel shomaranSettingViewModel = new ShomaranSettingViewModel();
		CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (settingId < 0)
			{
				settingId = 0;
			}
			if (string.IsNullOrWhiteSpace(objectType))
			{
				objectType = "Setting";
			}
			List<CRMspSelectLinkAccShomaranSetting_Result> list = Enumerable.ToList<CRMspSelectLinkAccShomaranSetting_Result>((IEnumerable<CRMspSelectLinkAccShomaranSetting_Result>)cRMLinkSpEntities.CRMspSelectLinkAccShomaranSetting(settingId, "Product", lCID, result));
			if (list != null && Enumerable.FirstOrDefault<CRMspSelectLinkAccShomaranSetting_Result>((IEnumerable<CRMspSelectLinkAccShomaranSetting_Result>)list, (Func<CRMspSelectLinkAccShomaranSetting_Result, bool>)((CRMspSelectLinkAccShomaranSetting_Result x) => x.PartTitle == "PrdLinkedField")) != null)
			{
				string partValue = Enumerable.FirstOrDefault<CRMspSelectLinkAccShomaranSetting_Result>((IEnumerable<CRMspSelectLinkAccShomaranSetting_Result>)list, (Func<CRMspSelectLinkAccShomaranSetting_Result, bool>)((CRMspSelectLinkAccShomaranSetting_Result x) => x.PartTitle == "PrdLinkedField")).PartValue;
				shomaranSettingViewModel.PrdLinkedField = ((!string.IsNullOrWhiteSpace(partValue)) ? partValue : "");
			}
			list = Enumerable.ToList<CRMspSelectLinkAccShomaranSetting_Result>((IEnumerable<CRMspSelectLinkAccShomaranSetting_Result>)cRMLinkSpEntities.CRMspSelectLinkAccShomaranSetting(settingId, "Warehouse", lCID, result));
			if (list != null && Enumerable.FirstOrDefault<CRMspSelectLinkAccShomaranSetting_Result>((IEnumerable<CRMspSelectLinkAccShomaranSetting_Result>)list, (Func<CRMspSelectLinkAccShomaranSetting_Result, bool>)((CRMspSelectLinkAccShomaranSetting_Result x) => x.PartTitle == "WrhsSyncTypeId")) != null)
			{
				string partValue2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccShomaranSetting_Result>((IEnumerable<CRMspSelectLinkAccShomaranSetting_Result>)list, (Func<CRMspSelectLinkAccShomaranSetting_Result, bool>)((CRMspSelectLinkAccShomaranSetting_Result x) => x.PartTitle == "WrhsSyncTypeId")).PartValue;
				shomaranSettingViewModel.WrhsSyncTypeId = ((!string.IsNullOrWhiteSpace(partValue2)) ? int.Parse(partValue2) : 0);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMLinkSpEntities.Dispose();
		}
		return shomaranSettingViewModel;
	}

	public static ArpaSettingViewModel GetArpaSetting(int settingId = 0, string objectType = "")
	{
		ArpaSettingViewModel arpaSettingViewModel = new ArpaSettingViewModel();
		CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (settingId < 0)
			{
				settingId = 0;
			}
			if (string.IsNullOrWhiteSpace(objectType))
			{
				objectType = "Setting";
			}
			List<CRMspSelectLinkAccArpaSetting_Result> list = Enumerable.ToList<CRMspSelectLinkAccArpaSetting_Result>((IEnumerable<CRMspSelectLinkAccArpaSetting_Result>)cRMLinkSpEntities.CRMspSelectLinkAccArpaSetting(settingId, objectType, lCID, result));
			if (list != null)
			{
				arpaSettingViewModel.ArpaServerAddress = Enumerable.FirstOrDefault<CRMspSelectLinkAccArpaSetting_Result>((IEnumerable<CRMspSelectLinkAccArpaSetting_Result>)list, (Func<CRMspSelectLinkAccArpaSetting_Result, bool>)((CRMspSelectLinkAccArpaSetting_Result x) => x.PartTitle == "ArpaServerAddress")).PartValue;
				arpaSettingViewModel.ArpaUserName = Enumerable.FirstOrDefault<CRMspSelectLinkAccArpaSetting_Result>((IEnumerable<CRMspSelectLinkAccArpaSetting_Result>)list, (Func<CRMspSelectLinkAccArpaSetting_Result, bool>)((CRMspSelectLinkAccArpaSetting_Result x) => x.PartTitle == "ArpaUserName")).PartValue;
				arpaSettingViewModel.ArpaPassword = Enumerable.FirstOrDefault<CRMspSelectLinkAccArpaSetting_Result>((IEnumerable<CRMspSelectLinkAccArpaSetting_Result>)list, (Func<CRMspSelectLinkAccArpaSetting_Result, bool>)((CRMspSelectLinkAccArpaSetting_Result x) => x.PartTitle == "ArpaPassword")).PartValue;
				arpaSettingViewModel.ArpaFiscalYearId = Enumerable.FirstOrDefault<CRMspSelectLinkAccArpaSetting_Result>((IEnumerable<CRMspSelectLinkAccArpaSetting_Result>)list, (Func<CRMspSelectLinkAccArpaSetting_Result, bool>)((CRMspSelectLinkAccArpaSetting_Result x) => x.PartTitle == "ArpaFiscalYearId")).PartValue;
				arpaSettingViewModel.DefUserGroupId = Enumerable.FirstOrDefault<CRMspSelectLinkAccArpaSetting_Result>((IEnumerable<CRMspSelectLinkAccArpaSetting_Result>)list, (Func<CRMspSelectLinkAccArpaSetting_Result, bool>)((CRMspSelectLinkAccArpaSetting_Result x) => x.PartTitle == "DefUserGroupId")).PartValue;
			}
			list = Enumerable.ToList<CRMspSelectLinkAccArpaSetting_Result>((IEnumerable<CRMspSelectLinkAccArpaSetting_Result>)cRMLinkSpEntities.CRMspSelectLinkAccArpaSetting(settingId, "Product", lCID, result));
			if (list != null && Enumerable.FirstOrDefault<CRMspSelectLinkAccArpaSetting_Result>((IEnumerable<CRMspSelectLinkAccArpaSetting_Result>)list, (Func<CRMspSelectLinkAccArpaSetting_Result, bool>)((CRMspSelectLinkAccArpaSetting_Result x) => x.PartTitle == "PrdLinkedField")) != null)
			{
				string partValue = Enumerable.FirstOrDefault<CRMspSelectLinkAccArpaSetting_Result>((IEnumerable<CRMspSelectLinkAccArpaSetting_Result>)list, (Func<CRMspSelectLinkAccArpaSetting_Result, bool>)((CRMspSelectLinkAccArpaSetting_Result x) => x.PartTitle == "PrdLinkedField")).PartValue;
				arpaSettingViewModel.PrdLinkedField = ((!string.IsNullOrWhiteSpace(partValue)) ? partValue : "");
			}
			list = Enumerable.ToList<CRMspSelectLinkAccArpaSetting_Result>((IEnumerable<CRMspSelectLinkAccArpaSetting_Result>)cRMLinkSpEntities.CRMspSelectLinkAccArpaSetting(settingId, "Warehouse", lCID, result));
			if (list != null && Enumerable.FirstOrDefault<CRMspSelectLinkAccArpaSetting_Result>((IEnumerable<CRMspSelectLinkAccArpaSetting_Result>)list, (Func<CRMspSelectLinkAccArpaSetting_Result, bool>)((CRMspSelectLinkAccArpaSetting_Result x) => x.PartTitle == "WrhsSyncTypeId")) != null)
			{
				string partValue2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccArpaSetting_Result>((IEnumerable<CRMspSelectLinkAccArpaSetting_Result>)list, (Func<CRMspSelectLinkAccArpaSetting_Result, bool>)((CRMspSelectLinkAccArpaSetting_Result x) => x.PartTitle == "WrhsSyncTypeId")).PartValue;
				arpaSettingViewModel.WrhsSyncTypeId = ((!string.IsNullOrWhiteSpace(partValue2)) ? int.Parse(partValue2) : 0);
			}
			list = Enumerable.ToList<CRMspSelectLinkAccArpaSetting_Result>((IEnumerable<CRMspSelectLinkAccArpaSetting_Result>)cRMLinkSpEntities.CRMspSelectLinkAccArpaSetting(settingId, "Order", lCID, result));
			if (list != null)
			{
				CRMspSelectLinkAccArpaSetting_Result cRMspSelectLinkAccArpaSetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccArpaSetting_Result>((IEnumerable<CRMspSelectLinkAccArpaSetting_Result>)list, (Func<CRMspSelectLinkAccArpaSetting_Result, bool>)((CRMspSelectLinkAccArpaSetting_Result x) => x.PartTitle == "OrdTaxIndex"));
				if (cRMspSelectLinkAccArpaSetting_Result != null)
				{
					decimal result2 = default(decimal);
					decimal.TryParse(cRMspSelectLinkAccArpaSetting_Result.PartValue ?? "0", out result2);
					arpaSettingViewModel.OrdTaxIndex = result2;
				}
				CRMspSelectLinkAccArpaSetting_Result cRMspSelectLinkAccArpaSetting_Result2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccArpaSetting_Result>((IEnumerable<CRMspSelectLinkAccArpaSetting_Result>)list, (Func<CRMspSelectLinkAccArpaSetting_Result, bool>)((CRMspSelectLinkAccArpaSetting_Result x) => x.PartTitle == "OrdDutyIndex"));
				if (cRMspSelectLinkAccArpaSetting_Result2 != null)
				{
					decimal result3 = default(decimal);
					decimal.TryParse(cRMspSelectLinkAccArpaSetting_Result2.PartValue ?? "0", out result3);
					arpaSettingViewModel.OrdDutyIndex = result3;
				}
				CRMspSelectLinkAccArpaSetting_Result cRMspSelectLinkAccArpaSetting_Result3 = Enumerable.FirstOrDefault<CRMspSelectLinkAccArpaSetting_Result>((IEnumerable<CRMspSelectLinkAccArpaSetting_Result>)list, (Func<CRMspSelectLinkAccArpaSetting_Result, bool>)((CRMspSelectLinkAccArpaSetting_Result x) => x.PartTitle == "OrdRoundId"));
				if (cRMspSelectLinkAccArpaSetting_Result3 != null)
				{
					arpaSettingViewModel.OrdRoundId = cRMspSelectLinkAccArpaSetting_Result3.PartValue ?? "";
				}
				CRMspSelectLinkAccArpaSetting_Result cRMspSelectLinkAccArpaSetting_Result4 = Enumerable.FirstOrDefault<CRMspSelectLinkAccArpaSetting_Result>((IEnumerable<CRMspSelectLinkAccArpaSetting_Result>)list, (Func<CRMspSelectLinkAccArpaSetting_Result, bool>)((CRMspSelectLinkAccArpaSetting_Result x) => x.PartTitle == "OrdRoundPlusId"));
				if (cRMspSelectLinkAccArpaSetting_Result4 != null)
				{
					arpaSettingViewModel.OrdRoundPlusId = cRMspSelectLinkAccArpaSetting_Result4.PartValue ?? "";
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMLinkSpEntities.Dispose();
		}
		return arpaSettingViewModel;
	}

	public static HamrahanSettingViewModel GetHamrahanSetting(int settingId = 0, string objectType = "")
	{
		HamrahanSettingViewModel hamrahanSettingViewModel = new HamrahanSettingViewModel();
		CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (settingId < 0)
			{
				settingId = 0;
			}
			if (string.IsNullOrWhiteSpace(objectType))
			{
				objectType = "Setting";
			}
			List<CRMspSelectLinkAccHamrahanSetting_Result> list = Enumerable.ToList<CRMspSelectLinkAccHamrahanSetting_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSetting_Result>)cRMLinkSpEntities.CRMspSelectLinkAccHamrahanSetting(settingId, objectType, lCID, result));
			if (list != null)
			{
				hamrahanSettingViewModel.HamrahanApiAddress = Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSetting_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSetting_Result>)list, (Func<CRMspSelectLinkAccHamrahanSetting_Result, bool>)((CRMspSelectLinkAccHamrahanSetting_Result x) => x.PartTitle == "ApiAddress")).PartValue;
				hamrahanSettingViewModel.HamrahanApiVersion = Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSetting_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSetting_Result>)list, (Func<CRMspSelectLinkAccHamrahanSetting_Result, bool>)((CRMspSelectLinkAccHamrahanSetting_Result x) => x.PartTitle == "ApiVersion")).PartValue;
				hamrahanSettingViewModel.HamrahanApiVersionDefineCmp = Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSetting_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSetting_Result>)list, (Func<CRMspSelectLinkAccHamrahanSetting_Result, bool>)((CRMspSelectLinkAccHamrahanSetting_Result x) => x.PartTitle == "ApiVersionDefineCmp")).PartValue;
				hamrahanSettingViewModel.HamrahanApiKey = Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSetting_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSetting_Result>)list, (Func<CRMspSelectLinkAccHamrahanSetting_Result, bool>)((CRMspSelectLinkAccHamrahanSetting_Result x) => x.PartTitle == "ApiKey")).PartValue;
				hamrahanSettingViewModel.HamrahanCompanyId = Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSetting_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSetting_Result>)list, (Func<CRMspSelectLinkAccHamrahanSetting_Result, bool>)((CRMspSelectLinkAccHamrahanSetting_Result x) => x.PartTitle == "CompanyId")).PartValue;
				hamrahanSettingViewModel.HamrahanCurrentFiscalYear = Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSetting_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSetting_Result>)list, (Func<CRMspSelectLinkAccHamrahanSetting_Result, bool>)((CRMspSelectLinkAccHamrahanSetting_Result x) => x.PartTitle == "CurrentFiscalYear")).PartValue;
				hamrahanSettingViewModel.HamrahanApiUserId = Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSetting_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSetting_Result>)list, (Func<CRMspSelectLinkAccHamrahanSetting_Result, bool>)((CRMspSelectLinkAccHamrahanSetting_Result x) => x.PartTitle == "ApiUserId")).PartValue;
				hamrahanSettingViewModel.HamrahanCurrencyUnit = Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSetting_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSetting_Result>)list, (Func<CRMspSelectLinkAccHamrahanSetting_Result, bool>)((CRMspSelectLinkAccHamrahanSetting_Result x) => x.PartTitle == "CurrencyUnit")).PartValue;
			}
			list = Enumerable.ToList<CRMspSelectLinkAccHamrahanSetting_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSetting_Result>)cRMLinkSpEntities.CRMspSelectLinkAccHamrahanSetting(settingId, "Product", lCID, result));
			if (list != null && Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSetting_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSetting_Result>)list, (Func<CRMspSelectLinkAccHamrahanSetting_Result, bool>)((CRMspSelectLinkAccHamrahanSetting_Result x) => x.PartTitle == "PrdLinkedField")) != null)
			{
				string partValue = Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSetting_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSetting_Result>)list, (Func<CRMspSelectLinkAccHamrahanSetting_Result, bool>)((CRMspSelectLinkAccHamrahanSetting_Result x) => x.PartTitle == "PrdLinkedField")).PartValue;
				hamrahanSettingViewModel.PrdLinkedField = ((!string.IsNullOrWhiteSpace(partValue)) ? partValue : "");
			}
			list = Enumerable.ToList<CRMspSelectLinkAccHamrahanSetting_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSetting_Result>)cRMLinkSpEntities.CRMspSelectLinkAccHamrahanSetting(settingId, "Company", lCID, result));
			if (list != null)
			{
				if (Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSetting_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSetting_Result>)list, (Func<CRMspSelectLinkAccHamrahanSetting_Result, bool>)((CRMspSelectLinkAccHamrahanSetting_Result x) => x.PartTitle == "LegalStateFormal")) != null)
				{
					string partValue2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSetting_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSetting_Result>)list, (Func<CRMspSelectLinkAccHamrahanSetting_Result, bool>)((CRMspSelectLinkAccHamrahanSetting_Result x) => x.PartTitle == "LegalStateFormal")).PartValue;
					hamrahanSettingViewModel.LegalStateFormal = ((!string.IsNullOrWhiteSpace(partValue2)) ? partValue2 : "");
				}
				if (Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSetting_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSetting_Result>)list, (Func<CRMspSelectLinkAccHamrahanSetting_Result, bool>)((CRMspSelectLinkAccHamrahanSetting_Result x) => x.PartTitle == "RealStateFormal")) != null)
				{
					string partValue3 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSetting_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSetting_Result>)list, (Func<CRMspSelectLinkAccHamrahanSetting_Result, bool>)((CRMspSelectLinkAccHamrahanSetting_Result x) => x.PartTitle == "RealStateFormal")).PartValue;
					hamrahanSettingViewModel.RealStateFormal = ((!string.IsNullOrWhiteSpace(partValue3)) ? partValue3 : "");
				}
				if (Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSetting_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSetting_Result>)list, (Func<CRMspSelectLinkAccHamrahanSetting_Result, bool>)((CRMspSelectLinkAccHamrahanSetting_Result x) => x.PartTitle == "LegalCompanyType")) != null)
				{
					string partValue4 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSetting_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSetting_Result>)list, (Func<CRMspSelectLinkAccHamrahanSetting_Result, bool>)((CRMspSelectLinkAccHamrahanSetting_Result x) => x.PartTitle == "LegalCompanyType")).PartValue;
					hamrahanSettingViewModel.LegalCompanyType = ((!string.IsNullOrWhiteSpace(partValue4)) ? partValue4 : "");
				}
				if (Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSetting_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSetting_Result>)list, (Func<CRMspSelectLinkAccHamrahanSetting_Result, bool>)((CRMspSelectLinkAccHamrahanSetting_Result x) => x.PartTitle == "RealIndexOwner")) != null)
				{
					string partValue5 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSetting_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSetting_Result>)list, (Func<CRMspSelectLinkAccHamrahanSetting_Result, bool>)((CRMspSelectLinkAccHamrahanSetting_Result x) => x.PartTitle == "RealIndexOwner")).PartValue;
					hamrahanSettingViewModel.RealIndexOwner = ((!string.IsNullOrWhiteSpace(partValue5)) ? partValue5 : "");
				}
				if (Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSetting_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSetting_Result>)list, (Func<CRMspSelectLinkAccHamrahanSetting_Result, bool>)((CRMspSelectLinkAccHamrahanSetting_Result x) => x.PartTitle == "RealIndexState")) != null)
				{
					string partValue6 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSetting_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSetting_Result>)list, (Func<CRMspSelectLinkAccHamrahanSetting_Result, bool>)((CRMspSelectLinkAccHamrahanSetting_Result x) => x.PartTitle == "RealIndexState")).PartValue;
					hamrahanSettingViewModel.RealIndexState = ((!string.IsNullOrWhiteSpace(partValue6)) ? partValue6 : "");
				}
				if (Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSetting_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSetting_Result>)list, (Func<CRMspSelectLinkAccHamrahanSetting_Result, bool>)((CRMspSelectLinkAccHamrahanSetting_Result x) => x.PartTitle == "RealIndexClass")) != null)
				{
					string partValue7 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSetting_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSetting_Result>)list, (Func<CRMspSelectLinkAccHamrahanSetting_Result, bool>)((CRMspSelectLinkAccHamrahanSetting_Result x) => x.PartTitle == "RealIndexClass")).PartValue;
					hamrahanSettingViewModel.RealIndexClass = ((!string.IsNullOrWhiteSpace(partValue7)) ? partValue7 : "");
				}
				if (Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSetting_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSetting_Result>)list, (Func<CRMspSelectLinkAccHamrahanSetting_Result, bool>)((CRMspSelectLinkAccHamrahanSetting_Result x) => x.PartTitle == "RealIndexKind")) != null)
				{
					string partValue8 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSetting_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSetting_Result>)list, (Func<CRMspSelectLinkAccHamrahanSetting_Result, bool>)((CRMspSelectLinkAccHamrahanSetting_Result x) => x.PartTitle == "RealIndexKind")).PartValue;
					hamrahanSettingViewModel.RealIndexKind = ((!string.IsNullOrWhiteSpace(partValue8)) ? partValue8 : "");
				}
				if (Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSetting_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSetting_Result>)list, (Func<CRMspSelectLinkAccHamrahanSetting_Result, bool>)((CRMspSelectLinkAccHamrahanSetting_Result x) => x.PartTitle == "RealIndexCredit")) != null)
				{
					string partValue9 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSetting_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSetting_Result>)list, (Func<CRMspSelectLinkAccHamrahanSetting_Result, bool>)((CRMspSelectLinkAccHamrahanSetting_Result x) => x.PartTitle == "RealIndexCredit")).PartValue;
					hamrahanSettingViewModel.RealIndexCredit = ((!string.IsNullOrWhiteSpace(partValue9)) ? partValue9 : "");
				}
				if (Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSetting_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSetting_Result>)list, (Func<CRMspSelectLinkAccHamrahanSetting_Result, bool>)((CRMspSelectLinkAccHamrahanSetting_Result x) => x.PartTitle == "LegalIndexOwner")) != null)
				{
					string partValue10 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSetting_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSetting_Result>)list, (Func<CRMspSelectLinkAccHamrahanSetting_Result, bool>)((CRMspSelectLinkAccHamrahanSetting_Result x) => x.PartTitle == "LegalIndexOwner")).PartValue;
					hamrahanSettingViewModel.LegalIndexOwner = ((!string.IsNullOrWhiteSpace(partValue10)) ? partValue10 : "");
				}
				if (Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSetting_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSetting_Result>)list, (Func<CRMspSelectLinkAccHamrahanSetting_Result, bool>)((CRMspSelectLinkAccHamrahanSetting_Result x) => x.PartTitle == "LegalIndexState")) != null)
				{
					string partValue11 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSetting_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSetting_Result>)list, (Func<CRMspSelectLinkAccHamrahanSetting_Result, bool>)((CRMspSelectLinkAccHamrahanSetting_Result x) => x.PartTitle == "LegalIndexState")).PartValue;
					hamrahanSettingViewModel.LegalIndexState = ((!string.IsNullOrWhiteSpace(partValue11)) ? partValue11 : "");
				}
				if (Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSetting_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSetting_Result>)list, (Func<CRMspSelectLinkAccHamrahanSetting_Result, bool>)((CRMspSelectLinkAccHamrahanSetting_Result x) => x.PartTitle == "LegalIndexClass")) != null)
				{
					string partValue12 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSetting_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSetting_Result>)list, (Func<CRMspSelectLinkAccHamrahanSetting_Result, bool>)((CRMspSelectLinkAccHamrahanSetting_Result x) => x.PartTitle == "LegalIndexClass")).PartValue;
					hamrahanSettingViewModel.LegalIndexClass = ((!string.IsNullOrWhiteSpace(partValue12)) ? partValue12 : "");
				}
				if (Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSetting_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSetting_Result>)list, (Func<CRMspSelectLinkAccHamrahanSetting_Result, bool>)((CRMspSelectLinkAccHamrahanSetting_Result x) => x.PartTitle == "LegalIndexKind")) != null)
				{
					string partValue13 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSetting_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSetting_Result>)list, (Func<CRMspSelectLinkAccHamrahanSetting_Result, bool>)((CRMspSelectLinkAccHamrahanSetting_Result x) => x.PartTitle == "LegalIndexKind")).PartValue;
					hamrahanSettingViewModel.LegalIndexKind = ((!string.IsNullOrWhiteSpace(partValue13)) ? partValue13 : "");
				}
				if (Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSetting_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSetting_Result>)list, (Func<CRMspSelectLinkAccHamrahanSetting_Result, bool>)((CRMspSelectLinkAccHamrahanSetting_Result x) => x.PartTitle == "LegalIndexCredit")) != null)
				{
					string partValue14 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSetting_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSetting_Result>)list, (Func<CRMspSelectLinkAccHamrahanSetting_Result, bool>)((CRMspSelectLinkAccHamrahanSetting_Result x) => x.PartTitle == "LegalIndexCredit")).PartValue;
					hamrahanSettingViewModel.LegalIndexCredit = ((!string.IsNullOrWhiteSpace(partValue14)) ? partValue14 : "");
				}
			}
			list = Enumerable.ToList<CRMspSelectLinkAccHamrahanSetting_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSetting_Result>)cRMLinkSpEntities.CRMspSelectLinkAccHamrahanSetting(settingId, "Warehouse", lCID, result));
			if (list != null && Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSetting_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSetting_Result>)list, (Func<CRMspSelectLinkAccHamrahanSetting_Result, bool>)((CRMspSelectLinkAccHamrahanSetting_Result x) => x.PartTitle == "WrhsSyncTypeId")) != null)
			{
				string partValue15 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSetting_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSetting_Result>)list, (Func<CRMspSelectLinkAccHamrahanSetting_Result, bool>)((CRMspSelectLinkAccHamrahanSetting_Result x) => x.PartTitle == "WrhsSyncTypeId")).PartValue;
				hamrahanSettingViewModel.WrhsSyncTypeId = ((!string.IsNullOrWhiteSpace(partValue15)) ? int.Parse(partValue15) : 0);
			}
			list = Enumerable.ToList<CRMspSelectLinkAccHamrahanSetting_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSetting_Result>)cRMLinkSpEntities.CRMspSelectLinkAccHamrahanSetting(settingId, "Order", lCID, result));
			if (list != null)
			{
				if (Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSetting_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSetting_Result>)list, (Func<CRMspSelectLinkAccHamrahanSetting_Result, bool>)((CRMspSelectLinkAccHamrahanSetting_Result x) => x.PartTitle == "RefBelongDeductPrdDisPercent")) != null)
				{
					string partValue16 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSetting_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSetting_Result>)list, (Func<CRMspSelectLinkAccHamrahanSetting_Result, bool>)((CRMspSelectLinkAccHamrahanSetting_Result x) => x.PartTitle == "RefBelongDeductPrdDisPercent")).PartValue;
					hamrahanSettingViewModel.OrdRefBelongDeductPrdDisPercent = ((!string.IsNullOrWhiteSpace(partValue16)) ? int.Parse(partValue16) : 0);
				}
				if (Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSetting_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSetting_Result>)list, (Func<CRMspSelectLinkAccHamrahanSetting_Result, bool>)((CRMspSelectLinkAccHamrahanSetting_Result x) => x.PartTitle == "RefBelongDeductPrdDisAmount")) != null)
				{
					string partValue17 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSetting_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSetting_Result>)list, (Func<CRMspSelectLinkAccHamrahanSetting_Result, bool>)((CRMspSelectLinkAccHamrahanSetting_Result x) => x.PartTitle == "RefBelongDeductPrdDisAmount")).PartValue;
					hamrahanSettingViewModel.OrdRefBelongDeductPrdDisAmount = ((!string.IsNullOrWhiteSpace(partValue17)) ? int.Parse(partValue17) : 0);
				}
				if (Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSetting_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSetting_Result>)list, (Func<CRMspSelectLinkAccHamrahanSetting_Result, bool>)((CRMspSelectLinkAccHamrahanSetting_Result x) => x.PartTitle == "RefBelongDeductServiceDisPercent")) != null)
				{
					string partValue18 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSetting_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSetting_Result>)list, (Func<CRMspSelectLinkAccHamrahanSetting_Result, bool>)((CRMspSelectLinkAccHamrahanSetting_Result x) => x.PartTitle == "RefBelongDeductServiceDisPercent")).PartValue;
					hamrahanSettingViewModel.OrdRefBelongDeductServiceDisPercent = ((!string.IsNullOrWhiteSpace(partValue18)) ? int.Parse(partValue18) : 0);
				}
				if (Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSetting_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSetting_Result>)list, (Func<CRMspSelectLinkAccHamrahanSetting_Result, bool>)((CRMspSelectLinkAccHamrahanSetting_Result x) => x.PartTitle == "RefBelongDeductServiceDisAmount")) != null)
				{
					string partValue19 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSetting_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSetting_Result>)list, (Func<CRMspSelectLinkAccHamrahanSetting_Result, bool>)((CRMspSelectLinkAccHamrahanSetting_Result x) => x.PartTitle == "RefBelongDeductServiceDisAmount")).PartValue;
					hamrahanSettingViewModel.OrdRefBelongDeductServiceDisAmount = ((!string.IsNullOrWhiteSpace(partValue19)) ? int.Parse(partValue19) : 0);
				}
				if (Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSetting_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSetting_Result>)list, (Func<CRMspSelectLinkAccHamrahanSetting_Result, bool>)((CRMspSelectLinkAccHamrahanSetting_Result x) => x.PartTitle == "RefBelongAddPrdTax")) != null)
				{
					string partValue20 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSetting_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSetting_Result>)list, (Func<CRMspSelectLinkAccHamrahanSetting_Result, bool>)((CRMspSelectLinkAccHamrahanSetting_Result x) => x.PartTitle == "RefBelongAddPrdTax")).PartValue;
					hamrahanSettingViewModel.OrdRefBelongAddPrdTax = ((!string.IsNullOrWhiteSpace(partValue20)) ? int.Parse(partValue20) : 0);
				}
				if (Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSetting_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSetting_Result>)list, (Func<CRMspSelectLinkAccHamrahanSetting_Result, bool>)((CRMspSelectLinkAccHamrahanSetting_Result x) => x.PartTitle == "RefBelongAddServiceTax")) != null)
				{
					string partValue21 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSetting_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSetting_Result>)list, (Func<CRMspSelectLinkAccHamrahanSetting_Result, bool>)((CRMspSelectLinkAccHamrahanSetting_Result x) => x.PartTitle == "RefBelongAddServiceTax")).PartValue;
					hamrahanSettingViewModel.OrdRefBelongAddServiceTax = ((!string.IsNullOrWhiteSpace(partValue21)) ? int.Parse(partValue21) : 0);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMLinkSpEntities.Dispose();
		}
		return hamrahanSettingViewModel;
	}

	public static HamrahanSettingDetailsViewModel GetHamrahanSettingDetails(int settingDetailId = 0, int objId = 0, string objectType = "")
	{
		HamrahanSettingDetailsViewModel hamrahanSettingDetailsViewModel = new HamrahanSettingDetailsViewModel();
		CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (settingDetailId < 0)
			{
				settingDetailId = 0;
			}
			List<CRMspSelectLinkAccHamrahanSettingDetails_Result> list = Enumerable.ToList<CRMspSelectLinkAccHamrahanSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSettingDetails_Result>)cRMLinkSpEntities.CRMspSelectLinkAccHamrahanSettingDetails(settingDetailId, objId, objectType, lCID, result));
			if (list != null)
			{
				if (Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSettingDetails_Result>)list, (Func<CRMspSelectLinkAccHamrahanSettingDetails_Result, bool>)((CRMspSelectLinkAccHamrahanSettingDetails_Result x) => x.PartTitle == "IndexDocument")) != null)
				{
					string partValue = Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSettingDetails_Result>)list, (Func<CRMspSelectLinkAccHamrahanSettingDetails_Result, bool>)((CRMspSelectLinkAccHamrahanSettingDetails_Result x) => x.PartTitle == "IndexDocument")).PartValue;
					hamrahanSettingDetailsViewModel.OrdIndexDocument = ((!string.IsNullOrWhiteSpace(partValue)) ? int.Parse(partValue) : 0);
				}
				if (Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSettingDetails_Result>)list, (Func<CRMspSelectLinkAccHamrahanSettingDetails_Result, bool>)((CRMspSelectLinkAccHamrahanSettingDetails_Result x) => x.PartTitle == "RefProcess")) != null)
				{
					string partValue2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSettingDetails_Result>)list, (Func<CRMspSelectLinkAccHamrahanSettingDetails_Result, bool>)((CRMspSelectLinkAccHamrahanSettingDetails_Result x) => x.PartTitle == "RefProcess")).PartValue;
					hamrahanSettingDetailsViewModel.OrdRefProcess = ((!string.IsNullOrWhiteSpace(partValue2)) ? int.Parse(partValue2) : 0);
				}
				if (Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSettingDetails_Result>)list, (Func<CRMspSelectLinkAccHamrahanSettingDetails_Result, bool>)((CRMspSelectLinkAccHamrahanSettingDetails_Result x) => x.PartTitle == "RefForm")) != null)
				{
					string partValue3 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSettingDetails_Result>)list, (Func<CRMspSelectLinkAccHamrahanSettingDetails_Result, bool>)((CRMspSelectLinkAccHamrahanSettingDetails_Result x) => x.PartTitle == "RefForm")).PartValue;
					hamrahanSettingDetailsViewModel.OrdRefForm = ((!string.IsNullOrWhiteSpace(partValue3)) ? int.Parse(partValue3) : 0);
				}
				if (Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSettingDetails_Result>)list, (Func<CRMspSelectLinkAccHamrahanSettingDetails_Result, bool>)((CRMspSelectLinkAccHamrahanSettingDetails_Result x) => x.PartTitle == "RefSaleMethod")) != null)
				{
					string partValue4 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSettingDetails_Result>)list, (Func<CRMspSelectLinkAccHamrahanSettingDetails_Result, bool>)((CRMspSelectLinkAccHamrahanSettingDetails_Result x) => x.PartTitle == "RefSaleMethod")).PartValue;
					hamrahanSettingDetailsViewModel.OrdRefSaleMethod = ((!string.IsNullOrWhiteSpace(partValue4)) ? int.Parse(partValue4) : 0);
				}
				if (Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSettingDetails_Result>)list, (Func<CRMspSelectLinkAccHamrahanSettingDetails_Result, bool>)((CRMspSelectLinkAccHamrahanSettingDetails_Result x) => x.PartTitle == "IndexStatus")) != null)
				{
					string partValue5 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSettingDetails_Result>)list, (Func<CRMspSelectLinkAccHamrahanSettingDetails_Result, bool>)((CRMspSelectLinkAccHamrahanSettingDetails_Result x) => x.PartTitle == "IndexStatus")).PartValue;
					hamrahanSettingDetailsViewModel.OrdIndexStatus = ((!string.IsNullOrWhiteSpace(partValue5)) ? int.Parse(partValue5) : 0);
				}
				if (Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSettingDetails_Result>)list, (Func<CRMspSelectLinkAccHamrahanSettingDetails_Result, bool>)((CRMspSelectLinkAccHamrahanSettingDetails_Result x) => x.PartTitle == "IndexBelong")) != null)
				{
					string partValue6 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSettingDetails_Result>)list, (Func<CRMspSelectLinkAccHamrahanSettingDetails_Result, bool>)((CRMspSelectLinkAccHamrahanSettingDetails_Result x) => x.PartTitle == "IndexBelong")).PartValue;
					hamrahanSettingDetailsViewModel.OrdIndexBelong = ((!string.IsNullOrWhiteSpace(partValue6)) ? int.Parse(partValue6) : 0);
				}
				if (Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSettingDetails_Result>)list, (Func<CRMspSelectLinkAccHamrahanSettingDetails_Result, bool>)((CRMspSelectLinkAccHamrahanSettingDetails_Result x) => x.PartTitle == "RnProject")) != null)
				{
					string partValue7 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSettingDetails_Result>)list, (Func<CRMspSelectLinkAccHamrahanSettingDetails_Result, bool>)((CRMspSelectLinkAccHamrahanSettingDetails_Result x) => x.PartTitle == "RnProject")).PartValue;
					hamrahanSettingDetailsViewModel.OrdRnProject = ((!string.IsNullOrWhiteSpace(partValue7)) ? int.Parse(partValue7) : 0);
				}
				if (Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSettingDetails_Result>)list, (Func<CRMspSelectLinkAccHamrahanSettingDetails_Result, bool>)((CRMspSelectLinkAccHamrahanSettingDetails_Result x) => x.PartTitle == "IndexDeliveryStatus")) != null)
				{
					string partValue8 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSettingDetails_Result>)list, (Func<CRMspSelectLinkAccHamrahanSettingDetails_Result, bool>)((CRMspSelectLinkAccHamrahanSettingDetails_Result x) => x.PartTitle == "IndexDeliveryStatus")).PartValue;
					hamrahanSettingDetailsViewModel.OrdIndexDeliveryStatus = ((!string.IsNullOrWhiteSpace(partValue8)) ? int.Parse(partValue8) : 0);
				}
				if (Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSettingDetails_Result>)list, (Func<CRMspSelectLinkAccHamrahanSettingDetails_Result, bool>)((CRMspSelectLinkAccHamrahanSettingDetails_Result x) => x.PartTitle == "RecieptStatusIndex")) != null)
				{
					string partValue9 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSettingDetails_Result>)list, (Func<CRMspSelectLinkAccHamrahanSettingDetails_Result, bool>)((CRMspSelectLinkAccHamrahanSettingDetails_Result x) => x.PartTitle == "RecieptStatusIndex")).PartValue;
					hamrahanSettingDetailsViewModel.OrdRecieptStatusIndex = ((!string.IsNullOrWhiteSpace(partValue9)) ? int.Parse(partValue9) : 0);
				}
				if (Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSettingDetails_Result>)list, (Func<CRMspSelectLinkAccHamrahanSettingDetails_Result, bool>)((CRMspSelectLinkAccHamrahanSettingDetails_Result x) => x.PartTitle == "IndexDocument")) != null)
				{
					string partValue10 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSettingDetails_Result>)list, (Func<CRMspSelectLinkAccHamrahanSettingDetails_Result, bool>)((CRMspSelectLinkAccHamrahanSettingDetails_Result x) => x.PartTitle == "IndexDocument")).PartValue;
					hamrahanSettingDetailsViewModel.OrdPayIndexDocument = ((!string.IsNullOrWhiteSpace(partValue10)) ? int.Parse(partValue10) : 0);
				}
				if (Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSettingDetails_Result>)list, (Func<CRMspSelectLinkAccHamrahanSettingDetails_Result, bool>)((CRMspSelectLinkAccHamrahanSettingDetails_Result x) => x.PartTitle == "IndexKind")) != null)
				{
					string partValue11 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSettingDetails_Result>)list, (Func<CRMspSelectLinkAccHamrahanSettingDetails_Result, bool>)((CRMspSelectLinkAccHamrahanSettingDetails_Result x) => x.PartTitle == "IndexKind")).PartValue;
					hamrahanSettingDetailsViewModel.OrdPayIndexKind = ((!string.IsNullOrWhiteSpace(partValue11)) ? int.Parse(partValue11) : 0);
				}
				if (Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSettingDetails_Result>)list, (Func<CRMspSelectLinkAccHamrahanSettingDetails_Result, bool>)((CRMspSelectLinkAccHamrahanSettingDetails_Result x) => x.PartTitle == "IndexKind1")) != null)
				{
					string partValue12 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSettingDetails_Result>)list, (Func<CRMspSelectLinkAccHamrahanSettingDetails_Result, bool>)((CRMspSelectLinkAccHamrahanSettingDetails_Result x) => x.PartTitle == "IndexKind1")).PartValue;
					hamrahanSettingDetailsViewModel.OrdPayIndexKind1 = ((!string.IsNullOrWhiteSpace(partValue12)) ? int.Parse(partValue12) : 0);
				}
				if (Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSettingDetails_Result>)list, (Func<CRMspSelectLinkAccHamrahanSettingDetails_Result, bool>)((CRMspSelectLinkAccHamrahanSettingDetails_Result x) => x.PartTitle == "DRNAccountBank")) != null)
				{
					string partValue13 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSettingDetails_Result>)list, (Func<CRMspSelectLinkAccHamrahanSettingDetails_Result, bool>)((CRMspSelectLinkAccHamrahanSettingDetails_Result x) => x.PartTitle == "DRNAccountBank")).PartValue;
					hamrahanSettingDetailsViewModel.OrdPayDRNAccountBank = ((!string.IsNullOrWhiteSpace(partValue13)) ? int.Parse(partValue13) : 0);
				}
				if (Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSettingDetails_Result>)list, (Func<CRMspSelectLinkAccHamrahanSettingDetails_Result, bool>)((CRMspSelectLinkAccHamrahanSettingDetails_Result x) => x.PartTitle == "DocumentDateType")) != null)
				{
					string partValue14 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHamrahanSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSettingDetails_Result>)list, (Func<CRMspSelectLinkAccHamrahanSettingDetails_Result, bool>)((CRMspSelectLinkAccHamrahanSettingDetails_Result x) => x.PartTitle == "DocumentDateType")).PartValue;
					hamrahanSettingDetailsViewModel.OrdPayDocumentDateType = ((!string.IsNullOrWhiteSpace(partValue14)) ? int.Parse(partValue14) : 0);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMLinkSpEntities.Dispose();
		}
		return hamrahanSettingDetailsViewModel;
	}

	public static NoAvaranCapillarySettingViewModel GetNoAvaranCapillarySetting(int settingId = 0, string objectType = "")
	{
		NoAvaranCapillarySettingViewModel noAvaranCapillarySettingViewModel = new NoAvaranCapillarySettingViewModel();
		CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int value = 18;
			int value2 = -1;
			if (settingId < 0)
			{
				settingId = 0;
			}
			if (string.IsNullOrWhiteSpace(objectType))
			{
				objectType = "Setting";
			}
			List<CRMspSelectLinkAccSetting_Result> list = Enumerable.ToList<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)cRMLinkSpEntities.CRMspSelectLinkAccSetting(settingId, objectType, lCID, result, value, value2, null));
			if (list != null)
			{
				noAvaranCapillarySettingViewModel.ApiUserId = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "ApiUserId")).PartValue;
				noAvaranCapillarySettingViewModel.ApiUserName = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "ApiUserName")).PartValue;
				CRMspSelectLinkAccSetting_Result cRMspSelectLinkAccSetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "DefCurrencyUnitId"));
				if (cRMspSelectLinkAccSetting_Result != null)
				{
					string partValue = cRMspSelectLinkAccSetting_Result.PartValue;
					noAvaranCapillarySettingViewModel.DefCurrencyUnitId = ((!string.IsNullOrWhiteSpace(partValue)) ? int.Parse(partValue) : 0);
				}
			}
			list = Enumerable.ToList<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)cRMLinkSpEntities.CRMspSelectLinkAccSetting(settingId, "Product", lCID, result, value, value2, null));
			if (list != null && Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "PrdLinkedField")) != null)
			{
				string partValue2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "PrdLinkedField")).PartValue;
				noAvaranCapillarySettingViewModel.PrdLinkedField = ((!string.IsNullOrWhiteSpace(partValue2)) ? partValue2 : "");
			}
			list = Enumerable.ToList<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)cRMLinkSpEntities.CRMspSelectLinkAccSetting(settingId, "Warehouse", lCID, result, value, value2, null));
			if (list != null)
			{
				CRMspSelectLinkAccSetting_Result cRMspSelectLinkAccSetting_Result2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "WrhsSyncTypeId"));
				if (cRMspSelectLinkAccSetting_Result2 != null)
				{
					string partValue3 = cRMspSelectLinkAccSetting_Result2.PartValue;
					noAvaranCapillarySettingViewModel.WrhsSyncTypeId = ((!string.IsNullOrWhiteSpace(partValue3)) ? int.Parse(partValue3) : 0);
					noAvaranCapillarySettingViewModel.WrhsSyncTypeLinkAccSettingId = cRMspSelectLinkAccSetting_Result2.LinkAccSettingId;
				}
			}
			list = Enumerable.ToList<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)cRMLinkSpEntities.CRMspSelectLinkAccSetting(settingId, "CmpProject", lCID, result, value, value2, null));
			if (list != null)
			{
				noAvaranCapillarySettingViewModel.DefPrjTitle = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "DefPrjTitle")).PartValue;
				CRMspSelectLinkAccSetting_Result cRMspSelectLinkAccSetting_Result3 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "DefPrjCvnsStatusGroupId"));
				if (cRMspSelectLinkAccSetting_Result3 != null)
				{
					string partValue4 = cRMspSelectLinkAccSetting_Result3.PartValue;
					noAvaranCapillarySettingViewModel.DefPrjCvnsStatusGroupId = ((!string.IsNullOrWhiteSpace(partValue4)) ? int.Parse(partValue4) : 0);
				}
			}
			list = Enumerable.ToList<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)cRMLinkSpEntities.CRMspSelectLinkAccSetting(settingId, "PreOrderOpr", lCID, result, value, value2, null));
			if (list != null)
			{
				CRMspSelectLinkAccSetting_Result cRMspSelectLinkAccSetting_Result4 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "PordOprFieldLinkTokindFactor"));
				if (cRMspSelectLinkAccSetting_Result4 != null)
				{
					string partValue5 = cRMspSelectLinkAccSetting_Result4.PartValue;
					noAvaranCapillarySettingViewModel.PordOprFieldLinkTokindFactor = ((!string.IsNullOrWhiteSpace(partValue5)) ? int.Parse(partValue5) : 0);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMLinkSpEntities.Dispose();
		}
		return noAvaranCapillarySettingViewModel;
	}

	public static NoAvaranCapillarySettingDetailsViewModel GetNoAvaranCapillarySettingDetails(int settingDetailId = 0, int objId = 0, string objectType = "")
	{
		NoAvaranCapillarySettingDetailsViewModel noAvaranCapillarySettingDetailsViewModel = new NoAvaranCapillarySettingDetailsViewModel();
		CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int value = 18;
			int value2 = -1;
			if (settingDetailId < 0)
			{
				settingDetailId = 0;
			}
			List<CRMspSelectLinkAccSettingDetails_Result> list = Enumerable.ToList<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)cRMLinkSpEntities.CRMspSelectLinkAccSettingDetails(settingDetailId, objId, objectType, lCID, result, value, value2));
			if (list != null)
			{
				if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "PayDateType")) != null)
				{
					string partValue = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "PayDateType")).PartValue;
					noAvaranCapillarySettingDetailsViewModel.PordPayDateType = ((!string.IsNullOrWhiteSpace(partValue)) ? int.Parse(partValue) : 0);
				}
				if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "PayDateFirstType")) != null)
				{
					string partValue2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "PayDateFirstType")).PartValue;
					noAvaranCapillarySettingDetailsViewModel.PordPayDateFirstType = ((!string.IsNullOrWhiteSpace(partValue2)) ? int.Parse(partValue2) : 0);
				}
				if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "DateRasType")) != null)
				{
					string partValue3 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "DateRasType")).PartValue;
					noAvaranCapillarySettingDetailsViewModel.PordPayDateRasType = ((!string.IsNullOrWhiteSpace(partValue3)) ? int.Parse(partValue3) : 0);
				}
				if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "PayCheckDateType")) != null)
				{
					string partValue4 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "PayCheckDateType")).PartValue;
					noAvaranCapillarySettingDetailsViewModel.PordPayCheckDateType = ((!string.IsNullOrWhiteSpace(partValue4)) ? int.Parse(partValue4) : 0);
				}
				if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "PayKindSabt")) != null)
				{
					noAvaranCapillarySettingDetailsViewModel.PordPayKindSabt = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "PayKindSabt")).PartValue;
				}
				if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "PordOprkindFactor")) != null)
				{
					string partValue5 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result x) => x.PartTitle == "PordOprkindFactor")).PartValue;
					noAvaranCapillarySettingDetailsViewModel.PordOprkindFactor = ((!string.IsNullOrWhiteSpace(partValue5)) ? int.Parse(partValue5) : 0);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMLinkSpEntities.Dispose();
		}
		return noAvaranCapillarySettingDetailsViewModel;
	}

	public static RahkaranRetailSettingViewModel GetRahkaranRetailSetting(int settingId = 0, string objectType = "")
	{
		RahkaranRetailSettingViewModel rahkaranRetailSettingViewModel = new RahkaranRetailSettingViewModel();
		CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int value = 19;
			int value2 = -1;
			if (settingId < 0)
			{
				settingId = 0;
			}
			if (string.IsNullOrWhiteSpace(objectType))
			{
				objectType = "Setting";
			}
			List<CRMspSelectLinkAccSetting_Result> list = Enumerable.ToList<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)cRMLinkSpEntities.CRMspSelectLinkAccSetting(settingId, objectType, lCID, result, value, value2, null));
			if (list != null)
			{
				rahkaranRetailSettingViewModel.ApiAddress = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "ApiAddress")).PartValue;
				rahkaranRetailSettingViewModel.ApiUsername = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "ApiUsername")).PartValue;
				rahkaranRetailSettingViewModel.ApiPassword = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "ApiPassword")).PartValue;
				rahkaranRetailSettingViewModel.ApiMachineName = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "ApiMachineName")).PartValue;
				rahkaranRetailSettingViewModel.ApiCookieName = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "ApiCookieName")).PartValue;
				CRMspSelectLinkAccSetting_Result cRMspSelectLinkAccSetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "ApiCookie"));
				if (cRMspSelectLinkAccSetting_Result != null)
				{
					rahkaranRetailSettingViewModel.ApiCookie = cRMspSelectLinkAccSetting_Result.PartValue;
					rahkaranRetailSettingViewModel.ApiCookieLinkAccSettingId = cRMspSelectLinkAccSetting_Result.LinkAccSettingId;
				}
				if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "CurrencyRef")) != null)
				{
					string partValue = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "CurrencyRef")).PartValue;
					rahkaranRetailSettingViewModel.CurrencyRef = ((!string.IsNullOrWhiteSpace(partValue)) ? int.Parse(partValue) : 0);
				}
			}
			list = Enumerable.ToList<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)cRMLinkSpEntities.CRMspSelectLinkAccSetting(settingId, "Product", lCID, result, value, value2, null));
			if (list != null && Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "PrdLinkedField")) != null)
			{
				string partValue2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "PrdLinkedField")).PartValue;
				rahkaranRetailSettingViewModel.PrdLinkedField = ((!string.IsNullOrWhiteSpace(partValue2)) ? partValue2 : "");
			}
			list = Enumerable.ToList<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)cRMLinkSpEntities.CRMspSelectLinkAccSetting(settingId, "Warehouse", lCID, result, value, value2, null));
			if (list != null)
			{
				CRMspSelectLinkAccSetting_Result cRMspSelectLinkAccSetting_Result2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "WrhsSyncTypeId"));
				if (cRMspSelectLinkAccSetting_Result2 != null)
				{
					string partValue3 = cRMspSelectLinkAccSetting_Result2.PartValue;
					rahkaranRetailSettingViewModel.WrhsSyncTypeId = ((!string.IsNullOrWhiteSpace(partValue3)) ? int.Parse(partValue3) : 0);
					rahkaranRetailSettingViewModel.WrhsSyncTypeLinkAccSettingId = cRMspSelectLinkAccSetting_Result2.LinkAccSettingId;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMLinkSpEntities.Dispose();
		}
		return rahkaranRetailSettingViewModel;
	}

	public static string CreateRahkaranCookie(string cookieValue)
	{
		string result = "";
		try
		{
			if (!string.IsNullOrWhiteSpace(cookieValue))
			{
				result = "sg-auth-sg=" + cookieValue + "; Path=/; Expires=" + DateTime.Now.AddYears(1).ToString("r");
				RahkaranRetailSettingViewModel rahkaranRetailSetting = GetRahkaranRetailSetting();
				if (rahkaranRetailSetting != null)
				{
					string text = rahkaranRetailSetting.ApiCookieName ?? "";
					if (!string.IsNullOrWhiteSpace(text))
					{
						result = text + "=" + cookieValue + "; Path=/; Expires=" + DateTime.Now.AddYears(1).ToString("r");
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public static NilramSettingViewModel GetNilramSetting(int settingId = 0, string objectType = "")
	{
		NilramSettingViewModel nilramSettingViewModel = new NilramSettingViewModel();
		CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int value = 20;
			int value2 = -1;
			if (settingId < 0)
			{
				settingId = 0;
			}
			if (string.IsNullOrWhiteSpace(objectType))
			{
				objectType = "Setting";
			}
			List<CRMspSelectLinkAccSetting_Result> list = Enumerable.ToList<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)cRMLinkSpEntities.CRMspSelectLinkAccSetting(settingId, objectType, lCID, result, value, value2, null));
			if (list != null)
			{
				nilramSettingViewModel.ApiAddress = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "ApiAddress")).PartValue;
				nilramSettingViewModel.ApiToken = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "ApiToken")).PartValue;
				CRMspSelectLinkAccSetting_Result cRMspSelectLinkAccSetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "DefCurrencyUnitId"));
				if (cRMspSelectLinkAccSetting_Result != null)
				{
					string partValue = cRMspSelectLinkAccSetting_Result.PartValue;
					nilramSettingViewModel.DefCurrencyUnitId = ((!string.IsNullOrWhiteSpace(partValue)) ? int.Parse(partValue) : 0);
				}
			}
			list = Enumerable.ToList<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)cRMLinkSpEntities.CRMspSelectLinkAccSetting(settingId, "Product", lCID, result, value, value2, null));
			if (list != null && Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "PrdLinkedField")) != null)
			{
				string partValue2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "PrdLinkedField")).PartValue;
				nilramSettingViewModel.PrdLinkedField = ((!string.IsNullOrWhiteSpace(partValue2)) ? partValue2 : "");
			}
			list = Enumerable.ToList<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)cRMLinkSpEntities.CRMspSelectLinkAccSetting(settingId, "Warehouse", lCID, result, value, value2, null));
			if (list != null)
			{
				CRMspSelectLinkAccSetting_Result cRMspSelectLinkAccSetting_Result2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "WrhsSyncTypeId"));
				if (cRMspSelectLinkAccSetting_Result2 != null)
				{
					string partValue3 = cRMspSelectLinkAccSetting_Result2.PartValue;
					nilramSettingViewModel.WrhsSyncTypeId = ((!string.IsNullOrWhiteSpace(partValue3)) ? int.Parse(partValue3) : 0);
					nilramSettingViewModel.WrhsSyncTypeLinkAccSettingId = cRMspSelectLinkAccSetting_Result2.LinkAccSettingId;
				}
			}
			list = Enumerable.ToList<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)cRMLinkSpEntities.CRMspSelectLinkAccSetting(settingId, "CmpProject", lCID, result, value, value2, null));
			if (list != null)
			{
				nilramSettingViewModel.DefPrjTitle = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "DefPrjTitle")).PartValue;
				CRMspSelectLinkAccSetting_Result cRMspSelectLinkAccSetting_Result3 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "DefPrjCvnsStatusGroupId"));
				if (cRMspSelectLinkAccSetting_Result3 != null)
				{
					string partValue4 = cRMspSelectLinkAccSetting_Result3.PartValue;
					nilramSettingViewModel.DefPrjCvnsStatusGroupId = ((!string.IsNullOrWhiteSpace(partValue4)) ? int.Parse(partValue4) : 0);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMLinkSpEntities.Dispose();
		}
		return nilramSettingViewModel;
	}

	public static HamyarSettingViewModel GetHamyarSetting(int settingId = 0, string objectType = "")
	{
		HamyarSettingViewModel hamyarSettingViewModel = new HamyarSettingViewModel();
		CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int value = 21;
			int value2 = -1;
			if (settingId < 0)
			{
				settingId = 0;
			}
			if (string.IsNullOrWhiteSpace(objectType))
			{
				objectType = "Setting";
			}
			List<CRMspSelectLinkAccSetting_Result> list = Enumerable.ToList<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)cRMLinkSpEntities.CRMspSelectLinkAccSetting(settingId, objectType, lCID, result, value, value2, null));
			if (list != null)
			{
				hamyarSettingViewModel.ApiAddress = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "ApiAddress")).PartValue;
				hamyarSettingViewModel.ApiKey = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "ApiKey")).PartValue;
				hamyarSettingViewModel.ApiUsername = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "ApiUsername")).PartValue;
				hamyarSettingViewModel.ApiPassword = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "ApiPassword")).PartValue;
				hamyarSettingViewModel.LegalMoadiType = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "LegalMoadiType")).PartValue;
				hamyarSettingViewModel.RealMoadiType = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result x) => x.PartTitle == "RealMoadiType")).PartValue;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMLinkSpEntities.Dispose();
		}
		return hamyarSettingViewModel;
	}

	public static string GetPrdQuantity(int currUserId, int prdId = 0, int whId = 0, string linkAccWhId = "", string tracing = "", int cmpId = 0, string sefareshCode = "", int linkAccSettingDBId = 0)
	{
		string result = "";
		try
		{
			ProductController productController = new ProductController();
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			int num = 0;
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				num = cRMspSelectCrmsysSetting_Result.LinkAccSystemId.GetValueOrDefault();
			}
			switch (num)
			{
			case 3:
			{
				decimal prdPrice = default(decimal);
				double prdQuantity = 0.0;
				productController.TarazGetPrdQuantityAndPrice(prdId, cmpId, whId, 0, ref prdPrice, ref prdQuantity, "pord", currUserId);
				result = prdQuantity.ToString();
				break;
			}
			case 4:
				result = productController.HolooGetPrdQuantity(prdId, linkAccSettingDBId);
				break;
			case 6:
				result = productController.KyanGetPrdQuantity(prdId, whId);
				break;
			case 7:
				result = productController.PayvastGetPrdQuantity(prdId, whId);
				break;
			case 11:
				result = productController.ShomaranGetPrdQuantity(prdId, whId, linkAccWhId, tracing, sefareshCode);
				break;
			case 12:
				result = productController.LinkAccGetPrdQuantity(num, prdId, whId, linkAccWhId, tracing);
				break;
			default:
				result = productController.LinkAccGetPrdQuantity(num, prdId, whId, linkAccWhId, tracing, "", 0, currUserId);
				break;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public static TimeSpan RestApiTimeout(int day = 0, int hour = 0, int min = 0, int sec = 0, int milisec = 0)
	{
		if (day <= 0 && hour <= 0 && min <= 0 && sec <= 0 && milisec <= 0)
		{
			min = 20;
		}
		return new TimeSpan(day, hour, min, sec, milisec);
	}

	public static string CheckCountrtProvinceCityLinkAcc()
	{
		string result = "";
		CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectCountryWithAccLinkField_Result> list = Enumerable.ToList<CRMspSelectCountryWithAccLinkField_Result>((IEnumerable<CRMspSelectCountryWithAccLinkField_Result>)cRMLinkSpEntities.CRMspSelectCountryWithAccLinkField(true, lCID, result2, true));
			if (list == null)
			{
				result = Messages.msgErrorCountryNotLinkedInLinkAcc;
				return result;
			}
			if (!Enumerable.Any<CRMspSelectCountryWithAccLinkField_Result>((IEnumerable<CRMspSelectCountryWithAccLinkField_Result>)list))
			{
				result = Messages.msgErrorCountryNotLinkedInLinkAcc;
				return result;
			}
			List<CRMspSelectProvinceWithAccLinkField_Result> list2 = Enumerable.ToList<CRMspSelectProvinceWithAccLinkField_Result>((IEnumerable<CRMspSelectProvinceWithAccLinkField_Result>)cRMLinkSpEntities.CRMspSelectProvinceWithAccLinkField(true, lCID, result2, true));
			if (list2 == null)
			{
				result = Messages.msgErrorProvinceNotLinkedInLinkAcc;
				return result;
			}
			if (!Enumerable.Any<CRMspSelectProvinceWithAccLinkField_Result>((IEnumerable<CRMspSelectProvinceWithAccLinkField_Result>)list2))
			{
				result = Messages.msgErrorProvinceNotLinkedInLinkAcc;
				return result;
			}
			List<CRMspSelectCityWithAccLinkField_Result> list3 = Enumerable.ToList<CRMspSelectCityWithAccLinkField_Result>((IEnumerable<CRMspSelectCityWithAccLinkField_Result>)cRMLinkSpEntities.CRMspSelectCityWithAccLinkField(true, lCID, result2, true));
			if (list3 == null)
			{
				result = Messages.msgErrorCityNotLinkedInLinkAcc;
				return result;
			}
			if (!Enumerable.Any<CRMspSelectCityWithAccLinkField_Result>((IEnumerable<CRMspSelectCityWithAccLinkField_Result>)list3))
			{
				result = Messages.msgErrorCityNotLinkedInLinkAcc;
				return result;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMLinkSpEntities.Dispose();
		}
		return result;
	}

	public static bool SendCmpToLinkAccByShpIsActive(int cmpId, int userLastCId, ref string errorMsg)
	{
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		bool result = true;
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			if (UserLogin.CurrentUser != null && userLastCId == 0)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out userLastCId);
			}
			if (userLastCId == 0)
			{
				result = true;
				return result;
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			int result3 = 0;
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result3);
			}
			if (result3 != 21)
			{
				result = true;
				return result;
			}
			CRMspSelectCompanyById_Result companyById = Company.GetCompanyById(cmpId);
			if (companyById != null)
			{
				List<CommonFoInfoByNameViewModel> list = new List<CommonFoInfoByNameViewModel>();
				string foInfoJsonByName = Company.GetFoInfoJsonByName(companyById.cmpFOInfo ?? "", companyById.cmpCIds ?? "");
				bool flag = false;
				if (!string.IsNullOrWhiteSpace(foInfoJsonByName))
				{
					list = new JavaScriptSerializer().Deserialize<List<CommonFoInfoByNameViewModel>>(foInfoJsonByName);
					if (list != null && Enumerable.Any<CommonFoInfoByNameViewModel>((IEnumerable<CommonFoInfoByNameViewModel>)list))
					{
						foreach (CommonFoInfoByNameViewModel item in list)
						{
							int result4 = 0;
							int.TryParse(item.CId, out result4);
							int result5 = 0;
							int.TryParse(item.ShpAct, out result5);
							if (result4 != 0 && result4 == userLastCId && result5 == 1)
							{
								flag = true;
							}
						}
					}
				}
				if (flag)
				{
					string cmpLinkAccData = companyById.cmpLinkAccData;
					bool flag2 = false;
					if (!string.IsNullOrWhiteSpace(cmpLinkAccData))
					{
						List<LinkAccDataViewModel> list2 = new JavaScriptSerializer().Deserialize<List<LinkAccDataViewModel>>(cmpLinkAccData);
						if (list2 != null && Enumerable.Any<LinkAccDataViewModel>((IEnumerable<LinkAccDataViewModel>)list2))
						{
							foreach (LinkAccDataViewModel item2 in list2)
							{
								int valueOrDefault = item2.CId.GetValueOrDefault();
								if (valueOrDefault != 0 && valueOrDefault == userLastCId && !flag2)
								{
									flag2 = true;
								}
							}
						}
					}
					if (flag2)
					{
						result = true;
					}
					else
					{
						string stringResult = new HamyarProvider.SendCompany(cmpId).GetStringResult(userLastCId);
						if (!string.IsNullOrEmpty(stringResult))
						{
							string[] array = stringResult.Split(new char[1] { '|' });
							if (array != null)
							{
								if (array[0] == "1")
								{
									if (!string.IsNullOrWhiteSpace(array[1]))
									{
										result = true;
										errorMsg = "";
									}
									else
									{
										result = false;
										errorMsg = Messages.msgErrorRunFunction;
									}
								}
								else
								{
									result = false;
									errorMsg = array[0];
								}
							}
							else
							{
								result = false;
								errorMsg = Messages.msgErrorRunFunction;
							}
						}
						else
						{
							result = false;
							errorMsg = Messages.msgErrorRunFunction;
						}
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return result;
	}

	public static CRMspSelectCompanyPersonsByID_Result GetCompanyPerson(int cmpId, int cmpMainPersonId = 0)
	{
		CRMspSelectCompanyPersonsByID_Result result = new CRMspSelectCompanyPersonsByID_Result();
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (cmpMainPersonId != 0)
			{
				result = Enumerable.FirstOrDefault<CRMspSelectCompanyPersonsByID_Result>((IEnumerable<CRMspSelectCompanyPersonsByID_Result>)cRMSpEntities.CRMspSelectCompanyPersonsByID(cmpMainPersonId, lCID, result2));
			}
			else
			{
				CRMspSelectCompanyPersonTop1ByOrderView_Result cRMspSelectCompanyPersonTop1ByOrderView_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyPersonTop1ByOrderView_Result>((IEnumerable<CRMspSelectCompanyPersonTop1ByOrderView_Result>)cRMSpEntities.CRMspSelectCompanyPersonTop1ByOrderView(cmpId, lCID, result2));
				if (cRMspSelectCompanyPersonTop1ByOrderView_Result != null)
				{
					result = new CRMspSelectCompanyPersonsByID_Result
					{
						CompanyPersonID = cRMspSelectCompanyPersonTop1ByOrderView_Result.CompanyPersonID,
						prsCompanyId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsCompanyId,
						prsLName = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsLName,
						prsFName = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsFName,
						prsTitleId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsTitleId,
						prsJobId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsJobId,
						prsTypeId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsTypeId,
						prsGroupId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsGroupId,
						prsSexId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsSexId,
						prsEducationId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsEducationId,
						prsPreTel = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsPreTel,
						prsTel = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsTel,
						prsTelUpTo = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsTelUpTo,
						prsTelDesc = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsTelDesc,
						prsTelII = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsTelII,
						prsFax = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsFax,
						prsFaxDesc = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsFaxDesc,
						prsMobile = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsMobile,
						prsWebSite = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsWebSite,
						prsEmail = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsEmail,
						prsEmailII = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsEmailII,
						prsCountryId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsCountryId,
						prsProvinceId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsProvinceId,
						prsCityId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsCityId,
						prsAddress = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsAddress,
						prsAddressDesc = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsAddressDesc,
						prsZipCode = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsZipCode,
						prsPostBox = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsPostBox,
						prsNationalCode = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsNationalCode,
						prsIdentityNumber = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsIdentityNumber,
						prsFatherName = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsFatherName,
						prsBirthDate = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsBirthDate,
						prsBirthDateTime = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsBirthDateTime,
						prsBirthPlace = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsBirthPlace,
						prsIsMarried = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsIsMarried,
						prsMarriageDate = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsMarriageDate,
						prsMarriageDateTime = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsMarriageDateTime,
						prsEducationField = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsEducationField,
						prsSkill = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsSkill,
						prsStudyField = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsStudyField,
						prsInteresting = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsInteresting,
						prsSpecialPoint = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsSpecialPoint,
						prsDescription = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsDescription,
						UserId = cRMspSelectCompanyPersonTop1ByOrderView_Result.UserId,
						Year1 = cRMspSelectCompanyPersonTop1ByOrderView_Result.Year1,
						Month1 = cRMspSelectCompanyPersonTop1ByOrderView_Result.Month1,
						RegisterDate = cRMspSelectCompanyPersonTop1ByOrderView_Result.RegisterDate,
						RegisterDatePersian = cRMspSelectCompanyPersonTop1ByOrderView_Result.RegisterDatePersian,
						AddType = cRMspSelectCompanyPersonTop1ByOrderView_Result.AddType,
						ImportDate = cRMspSelectCompanyPersonTop1ByOrderView_Result.ImportDate,
						ImportDateTime = cRMspSelectCompanyPersonTop1ByOrderView_Result.ImportDateTime,
						prsFirstRegisterUserId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsFirstRegisterUserId,
						prsDepartmentId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsDepartmentId,
						prsStopSendSms = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsStopSendSms,
						prsOrderView = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsOrderView,
						prsWorkingOut = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsWorkingOut,
						GUId = cRMspSelectCompanyPersonTop1ByOrderView_Result.GUId,
						CompanyPersonTemplateID = cRMspSelectCompanyPersonTop1ByOrderView_Result.CompanyPersonTemplateID,
						LanguageID = cRMspSelectCompanyPersonTop1ByOrderView_Result.LanguageID,
						FirstRegisterUserId = cRMspSelectCompanyPersonTop1ByOrderView_Result.FirstRegisterUserId,
						FirstRegisterDatePersian = cRMspSelectCompanyPersonTop1ByOrderView_Result.FirstRegisterDatePersian,
						FirstRegisterDate = cRMspSelectCompanyPersonTop1ByOrderView_Result.FirstRegisterDate,
						prsTelegramId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsTelegramId,
						PersonName = cRMspSelectCompanyPersonTop1ByOrderView_Result.PersonTitleName,
						prsTitle = cRMspSelectCompanyPersonTop1ByOrderView_Result.PersonTitle
					};
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return result;
	}
}
