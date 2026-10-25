using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using CRM.Resources;

namespace CRM.Models;

public class CrmConversationPreviewViewModel
{
	[Key]
	[Display(ResourceType = typeof(Labels), Name = "cnvsConversationID")]
	public int ConversationID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsProjectId")]
	public int? cnvsProjectId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsProjectId")]
	public string cnvsProjectIdTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsCompanyId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int cnvsCompanyId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsCompanyId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public string cnvsCompanyIdTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDate")]
	[MaxLength(8, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(8, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cnvsDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDay")]
	[MaxLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cnvsDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsTime")]
	[MaxLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cnvsTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsTopicId")]
	public int? cnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsTopicId")]
	public string cnvsTopicIdTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsSubject")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cnvsSubject { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDesc")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cnvsDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsPersonId")]
	public int? cnvsPersonId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsPersonId")]
	public string cnvsPersonIdTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsUserId")]
	public int? cnvsUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsUserId")]
	public string cnvsUserIdTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsReferUserId")]
	public int? cnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsReferUserId")]
	public string cnvsReferUserIdTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsReferDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cnvsReferDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusId")]
	public int? cnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusId")]
	public string cnvsStatusIdTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsPriorityId")]
	public int? cnvsPriorityId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsPriorityId")]
	public string cnvsPriorityIdTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsRemindDate")]
	[MaxLength(8, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(8, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cnvsRemindDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsRemindTime")]
	[MaxLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cnvsRemindTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsRemindOk")]
	public bool? cnvsRemindOk { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsIsBookMark")]
	public bool? cnvsIsBookMark { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsFirstRegisterUserId")]
	public int? cnvsFirstRegisterUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsFirstRegisterUserId")]
	public string cnvsFirstRegisterUserIdTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsFirstRegisterDate")]
	[MaxLength(8, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(8, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cnvsFirstRegisterDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsRemindDateForAllarm")]
	[MaxLength(8, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(8, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cnvsRemindDateForAllarm { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsFirstRegisterDate")]
	public DateTime? FirstRegisterDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsUserId")]
	public int UserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsUserId")]
	public string UserIdTitle { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public List<CRMspSelectFilesDirectory_Result> ListFiles { get; set; }

	public string AppType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsPreViewFOCmpCanSee")]
	public bool? cnvsFOCmpCanSee { get; set; }

	public string cnvsDoingTime { get; set; }

	public string cnvsCoordinateLatitude { get; set; }

	public string cnvsCoordinateLongitude { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsHappyVote")]
	public int? cnvsHappyVote { get; set; }

	public List<SelectListItem> KnowledgeTankList { get; set; }
}
