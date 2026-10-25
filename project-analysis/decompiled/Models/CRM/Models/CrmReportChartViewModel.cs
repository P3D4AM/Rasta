using System.Collections.Generic;

namespace CRM.Models;

public class CrmReportChartViewModel
{
	public List<CrmReportCmpCountRegInWsOrderViewModel> ChrtCmpCountWithRegInWsOrder { get; set; }

	public List<CrmReportCmpCountWithCityViewModel> ChrtCmpCountWithCity { get; set; }

	public List<CrmReportCmpCountWithCmpGroupIViewModel> ChrtCmpCountWithGroupI { get; set; }

	public List<CrmReportCmpCountWithCmpGroupIIViewModel> ChrtCmpCountWithGroupII { get; set; }

	public List<CrmReportCmpCountWithCmpGroupIIIViewModel> ChrtCmpCountWithGroupIII { get; set; }

	public List<CrmReportCmpCountWithCmpGroupIVViewModel> ChrtCmpCountWithGroupIV { get; set; }

	public List<CrmReportCmpCountWithMultiGroupsViewModel> ChrtCmpCountWithMultiGroups { get; set; }

	public List<CrmReportCmpCountWithCmpTitleViewModel> ChrtCmpCountWithTitle { get; set; }

	public List<CrmReportCmpCountWithCmpTypeViewModel> ChrtCmpCountWithType { get; set; }

	public List<CrmReportCmpCountWithCountryViewModel> ChrtCmpCountWithCountry { get; set; }

	public List<CrmReportCmpCountWithPresentationViewModel> ChrtCmpCountWithPresentation { get; set; }

	public List<CrmReportCmpCountWithProvinceViewModel> ChrtCmpCountWithProvince { get; set; }

	public List<CrmReportCmpPrsCountWithBirthdayViewModel> ChrtCmpPrsCountWithBirthday { get; set; }

	public List<CrmReportCmpPrsCountWithDepartemantViewModel> ChrtPrsCountWithDepartemant { get; set; }

	public List<CrmReportCmpPrsCountWithEducationViewModel> ChrtCmpPrsCountWithEducation { get; set; }

	public List<CrmReportCmpPrsCountWithJobViewModel> ChrtCmpPrsCountWithJob { get; set; }

	public List<CrmReportCmpPrsCountSexWithMarriageViewModel> ChrtCmpPrsCountWithSexAndMarriage { get; set; }

	public List<CrmReportCmpPrsCountWithTitleViewModel> ChrtCmpPrsCountWithTitle { get; set; }

	public List<CrmReportCmpPrsCountWithTypeViewModel> ChrtCmpPrsCountWithType { get; set; }

	public List<CrmReportCmpProjectCountWithGradeViewModel> ChrtCmpPrjCountWithGrade { get; set; }

	public List<CrmReportCmpProjectCountWithGroupViewModel> ChrtCmpPrjCountWithGroup { get; set; }

	public List<CrmReportCmpProjectCountWithPriorityViewModel> ChrtCmpPrjCountWithPriority { get; set; }

	public List<CrmReportCmpProjectCountWithCnvsStatusGroupViewModel> ChrtCmpPrjCountWithCnvsStatusGroup { get; set; }

	public List<CrmReportCmpPrjCountWithTitleViewModel> ChrtCmpPrjCountWithTitle { get; set; }

	public List<CrmReportCmpConversationCountWithStatusAndGroupViewModel> ChrtCnvsCountWithStatusAndGroup { get; set; }

	public List<CrmReportCmpConversationCountWithTopicViewModel> ChrtCnvsCountWithTopic { get; set; }

	public ChartsWidthViewModel ChrtWidth { get; set; }
}
