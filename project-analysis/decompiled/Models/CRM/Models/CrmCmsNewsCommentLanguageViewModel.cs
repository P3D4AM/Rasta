using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmCmsNewsCommentLanguageViewModel
{
	[Key]
	public int CommentId { get; set; }

	public int ObjectTypeId { get; set; }

	public int ObjectId { get; set; }

	public int? ParentId { get; set; }

	public int? CrmCompanyId { get; set; }

	public string IPAddress { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsNewsCommentFName")]
	[MaxLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string FName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsNewsCommentLName")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string LName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsNewsCommentMobile")]
	[MaxLength(11, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(11, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	[RegularExpression("09([0-9])\\d{8}", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorInFormat")]
	public string Mobile { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsNewsCommentTel")]
	[MaxLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	[RegularExpression("^[0-9]*$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorInFormat")]
	public string Tel { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsNewsCommentEmail")]
	[MaxLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	[RegularExpression("\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorInFormat")]
	public string Email { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsNewsCommentDesc")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public string Description { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsNewsCommentIsVerified")]
	public bool? IsVerified { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsNewsCommentVerifiedUser")]
	public int? VerifiedUserId { get; set; }

	public DateTime? VerifiedDateTime { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }

	public string VerifiedUser { get; set; }

	public string CrmCompany { get; set; }

	public string FName_Lang { get; set; }

	public string LName_Lang { get; set; }

	public string Description_Lang { get; set; }
}
