using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CRMspResultsForgetCompanyCartableViewModel
{
	public int FDate { get; set; }

	public int TDate { get; set; }

	public string rptUser { get; set; }

	public string rptDate { get; set; }

	public string rptDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpName")]
	public string Company { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cKartablProjectTitle")]
	public string prjTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDate")]
	public string cnvsDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsPersonId")]
	public string cnvsPerson { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsUserId")]
	public string cnvsUser { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsReferUserId")]
	public string cnvsReferUser { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusLast")]
	public string cnvsStatus { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDesc")]
	public string cnvsDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpPresentationId")]
	public string CompanyPresentation { get; set; }

	public int? CompanyId { get; set; }

	public int? cnvsPersonId { get; set; }

	public int? cnvsProjectId { get; set; }

	public int? ConversationId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpImportDate")]
	public string ImportDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsRemindDate")]
	public string cnvsRemindDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsRemindOk")]
	public bool? cnvsRemindOk { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsRemindOk")]
	public bool RemindOk
	{
		get
		{
			if (cnvsRemindOk.HasValue)
			{
				return cnvsRemindOk != false;
			}
			return false;
		}
	}

	[Display(ResourceType = typeof(Labels), Name = "cmpProvinceId")]
	public string cmpProvince { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpCityId")]
	public string cmpCity { get; set; }
}
