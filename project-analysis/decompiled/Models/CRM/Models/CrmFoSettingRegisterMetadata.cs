using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmFoSettingRegisterMetadata
{
	[Key]
	public int FoSettingRegisterId { get; set; }

	public int FoSettingId { get; set; }

	public int CId { get; set; }

	public int CmpKind { get; set; }

	public int? CmpDefaultGroupId { get; set; }

	public int? CmpDefaultSubGroupId { get; set; }

	public int? CmpDefaultGroupIdII { get; set; }

	public int? CmpDefaultGroupIdIII { get; set; }

	public int? CmpDefaultGroupIdIV { get; set; }

	public int? CmpDefaultTypeId { get; set; }

	public int? CmpDefaultPresentationId { get; set; }

	public int CmpDefaultReferUserId { get; set; }

	public string PrjDefaultTitle { get; set; }

	public int PrjDefaultStarterUserId { get; set; }

	public int? PrjDefaultGradeId { get; set; }

	public int? PrjDefaultPriorityId { get; set; }

	public int? PrjDefaultGroupId { get; set; }

	public int PrjDefaultCnvsStatusGroupId { get; set; }

	public string PrjDefaultPostFix { get; set; }

	public bool? PrjDefaultFOCmpCanSee { get; set; }

	public bool? PrjInsertCrmProjectsForbiddenFUFDPActive { get; set; }

	public bool? PrjInsertProjectInformationsDefualtFieldActive { get; set; }

	public int CnvsDefaultTopicId { get; set; }

	public string CnvsDefaultDesc { get; set; }

	public int CnvsDefaultUserId { get; set; }

	public int CnvsDefaultReferUserId { get; set; }

	public string CnvsDefaultReferDesc { get; set; }

	public int CnvsDefaultStatusId { get; set; }

	public int? CnvsDefaultPriorityId { get; set; }

	public int? CmpDefUsernameType { get; set; }

	public int? CmpDefPasswordType { get; set; }

	public int? CmpDefFOActiveType { get; set; }

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
}
