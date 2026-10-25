using System.Collections.Generic;

namespace CRM.Models;

public class CrmLinkAccSettingOtherPartViewModel
{
	public CRMspSelectLinkAccSetting_Result CmpAccountRemainPart { get; set; }

	public List<CRMspSelectLinkAccSetting_Result> ExcSettingPart { get; set; }

	public CRMspSelectLinkAccSetting_Result ShowCmpAccountingSummaryPart { get; set; }

	public CRMspSelectLinkAccSetting_Result DefTspOrdSetmPart { get; set; }

	public List<CRMspSelectLinkAccSettingDetails_Result> DefTspOrdSetmSettingDetails { get; set; }

	public CRMspSelectCompanyLinkAccSetting_Result CompanyLinkAccSetting { get; set; }

	public bool? CmpAccFromLink { get; set; }

	public CRMspSelectLinkAccSetting_Result DefWarehouseLinkAccSetting { get; set; }

	public CRMspSelectLinkAccSetting_Result PordFieldLinkToSaleTypeSetting { get; set; }

	public List<CRMspSelectLinkAccSettingDetails_Result> PordFieldLinkToSaleTypeSettingDetails { get; set; }

	public CRMspSelectLinkAccSetting_Result DefOrdPayTypeSetting { get; set; }

	public CRMspSelectLinkAccSetting_Result DefSepReferUserLinkAccSetting { get; set; }

	public CRMspSelectLinkAccSetting_Result CmpAccountRemainingMoienAccCodePart { get; set; }

	public CRMspSelectLinkAccSetting_Result SepNotHavePordModulePart { get; set; }

	public CRMspSelectLinkAccSetting_Result SepNotHaveOrdModulePart { get; set; }

	public CRMspSelectLinkAccSetting_Result SepNotHaveBordModulePart { get; set; }

	public CRMspSelectLinkAccSetting_Result SepNotHaveDocModulePart { get; set; }

	public CRMspSelectLinkAccSetting_Result SepNotHavePayModulePart { get; set; }

	public List<CRMspSelectLinkAccSetting_Result> OrdCommSettingPart { get; set; }

	public CRMspSelectLinkAccSetting_Result SepNotHaveCommModulePart { get; set; }

	public CRMspSelectLinkAccSetting_Result IssueVoucherWithoutOrdDiscPart { get; set; }

	public List<CRMspSelectLinkAccSetting_Result> PrdCodeSettingPart { get; set; }

	public List<CRMspSelectLinkAccSetting_Result> CmpProjectSettingPart { get; set; }

	public List<CRMspSelectLinkAccSetting_Result> CmpCodeSettingPart { get; set; }
}
