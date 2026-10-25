using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmConversationDefaultContextLanguageViewModel
{
	[Key]
	public int ID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextColOne")]
	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ColOne { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextColTwo")]
	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ColTwo { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextColThree")]
	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ColThree { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextColFour")]
	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ColFour { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextColFive")]
	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ColFive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextColSix")]
	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ColSix { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextColSeven")]
	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ColSeven { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ColEight { get; set; }

	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ColNine { get; set; }

	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ColTen { get; set; }

	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col11 { get; set; }

	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col12 { get; set; }

	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col13 { get; set; }

	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col14 { get; set; }

	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col15 { get; set; }

	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col16 { get; set; }

	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col17 { get; set; }

	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col18 { get; set; }

	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col19 { get; set; }

	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col20 { get; set; }

	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col21 { get; set; }

	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col22 { get; set; }

	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col23 { get; set; }

	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col24 { get; set; }

	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col25 { get; set; }

	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col26 { get; set; }

	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col27 { get; set; }

	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col28 { get; set; }

	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col29 { get; set; }

	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col30 { get; set; }

	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col31 { get; set; }

	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col32 { get; set; }

	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col33 { get; set; }

	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col34 { get; set; }

	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col35 { get; set; }

	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col36 { get; set; }

	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col37 { get; set; }

	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col38 { get; set; }

	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col39 { get; set; }

	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col40 { get; set; }

	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col41 { get; set; }

	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col42 { get; set; }

	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col43 { get; set; }

	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col44 { get; set; }

	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col45 { get; set; }

	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col46 { get; set; }

	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col47 { get; set; }

	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col48 { get; set; }

	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col49 { get; set; }

	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col50 { get; set; }

	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col51 { get; set; }

	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col52 { get; set; }

	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col53 { get; set; }

	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col54 { get; set; }

	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col55 { get; set; }

	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col56 { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsTopic")]
	public int? ColOneDefCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferUser")]
	public int? ColOneDefCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsStatus")]
	public int? ColOneDefCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsRemindDay")]
	public int? ColOneDefCnvsRemindDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ColOneDefCnvsReferDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsTopic")]
	public int? ColTwoDefCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferUser")]
	public int? ColTwoDefCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsStatus")]
	public int? ColTwoDefCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsRemindDay")]
	public int? ColTwoDefCnvsRemindDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ColTwoDefCnvsReferDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsTopic")]
	public int? ColThreeDefCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferUser")]
	public int? ColThreeDefCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsStatus")]
	public int? ColThreeDefCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsRemindDay")]
	public int? ColThreeDefCnvsRemindDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ColThreeDefCnvsReferDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsTopic")]
	public int? ColFourDefCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferUser")]
	public int? ColFourDefCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsStatus")]
	public int? ColFourDefCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsRemindDay")]
	public int? ColFourDefCnvsRemindDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ColFourDefCnvsReferDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsTopic")]
	public int? ColFiveDefCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferUser")]
	public int? ColFiveDefCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsStatus")]
	public int? ColFiveDefCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsRemindDay")]
	public int? ColFiveDefCnvsRemindDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ColFiveDefCnvsReferDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsTopic")]
	public int? ColSixDefCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferUser")]
	public int? ColSixDefCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsStatus")]
	public int? ColSixDefCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsRemindDay")]
	public int? ColSixDefCnvsRemindDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ColSixDefCnvsReferDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsTopic")]
	public int? ColSevenDefCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferUser")]
	public int? ColSevenDefCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsStatus")]
	public int? ColSevenDefCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsRemindDay")]
	public int? ColSevenDefCnvsRemindDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ColSevenDefCnvsReferDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsTopic")]
	public int? ColEightDefCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferUser")]
	public int? ColEightDefCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsStatus")]
	public int? ColEightDefCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsRemindDay")]
	public int? ColEightDefCnvsRemindDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ColEightDefCnvsReferDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsTopic")]
	public int? ColNineDefCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferUser")]
	public int? ColNineDefCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsStatus")]
	public int? ColNineDefCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsRemindDay")]
	public int? ColNineDefCnvsRemindDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ColNineDefCnvsReferDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsTopic")]
	public int? ColTenDefCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferUser")]
	public int? ColTenDefCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsStatus")]
	public int? ColTenDefCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsRemindDay")]
	public int? ColTenDefCnvsRemindDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ColTenDefCnvsReferDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsTopic")]
	public int? Col11DefCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferUser")]
	public int? Col11DefCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsStatus")]
	public int? Col11DefCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsRemindDay")]
	public int? Col11DefCnvsRemindDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col11DefCnvsReferDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsTopic")]
	public int? Col12DefCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferUser")]
	public int? Col12DefCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsStatus")]
	public int? Col12DefCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsRemindDay")]
	public int? Col12DefCnvsRemindDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col12DefCnvsReferDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsTopic")]
	public int? Col13DefCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferUser")]
	public int? Col13DefCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsStatus")]
	public int? Col13DefCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsRemindDay")]
	public int? Col13DefCnvsRemindDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col13DefCnvsReferDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsTopic")]
	public int? Col14DefCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferUser")]
	public int? Col14DefCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsStatus")]
	public int? Col14DefCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsRemindDay")]
	public int? Col14DefCnvsRemindDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col14DefCnvsReferDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsTopic")]
	public int? Col15DefCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferUser")]
	public int? Col15DefCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsStatus")]
	public int? Col15DefCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsRemindDay")]
	public int? Col15DefCnvsRemindDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col15DefCnvsReferDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsTopic")]
	public int? Col16DefCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferUser")]
	public int? Col16DefCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsStatus")]
	public int? Col16DefCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsRemindDay")]
	public int? Col16DefCnvsRemindDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col16DefCnvsReferDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsTopic")]
	public int? Col17DefCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferUser")]
	public int? Col17DefCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsStatus")]
	public int? Col17DefCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsRemindDay")]
	public int? Col17DefCnvsRemindDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col17DefCnvsReferDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsTopic")]
	public int? Col18DefCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferUser")]
	public int? Col18DefCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsStatus")]
	public int? Col18DefCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsRemindDay")]
	public int? Col18DefCnvsRemindDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col18DefCnvsReferDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsTopic")]
	public int? Col19DefCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferUser")]
	public int? Col19DefCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsStatus")]
	public int? Col19DefCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsRemindDay")]
	public int? Col19DefCnvsRemindDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col19DefCnvsReferDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsTopic")]
	public int? Col20DefCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferUser")]
	public int? Col20DefCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsStatus")]
	public int? Col20DefCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsRemindDay")]
	public int? Col20DefCnvsRemindDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col20DefCnvsReferDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsTopic")]
	public int? Col21DefCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferUser")]
	public int? Col21DefCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsStatus")]
	public int? Col21DefCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsRemindDay")]
	public int? Col21DefCnvsRemindDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col21DefCnvsReferDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsTopic")]
	public int? Col22DefCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferUser")]
	public int? Col22DefCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsStatus")]
	public int? Col22DefCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsRemindDay")]
	public int? Col22DefCnvsRemindDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col22DefCnvsReferDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsTopic")]
	public int? Col23DefCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferUser")]
	public int? Col23DefCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsStatus")]
	public int? Col23DefCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsRemindDay")]
	public int? Col23DefCnvsRemindDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col23DefCnvsReferDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsTopic")]
	public int? Col24DefCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferUser")]
	public int? Col24DefCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsStatus")]
	public int? Col24DefCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsRemindDay")]
	public int? Col24DefCnvsRemindDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col24DefCnvsReferDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsTopic")]
	public int? Col25DefCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferUser")]
	public int? Col25DefCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsStatus")]
	public int? Col25DefCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsRemindDay")]
	public int? Col25DefCnvsRemindDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col25DefCnvsReferDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsTopic")]
	public int? Col26DefCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferUser")]
	public int? Col26DefCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsStatus")]
	public int? Col26DefCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsRemindDay")]
	public int? Col26DefCnvsRemindDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col26DefCnvsReferDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsTopic")]
	public int? Col27DefCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferUser")]
	public int? Col27DefCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsStatus")]
	public int? Col27DefCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsRemindDay")]
	public int? Col27DefCnvsRemindDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col27DefCnvsReferDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsTopic")]
	public int? Col28DefCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferUser")]
	public int? Col28DefCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsStatus")]
	public int? Col28DefCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsRemindDay")]
	public int? Col28DefCnvsRemindDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col28DefCnvsReferDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsTopic")]
	public int? Col29DefCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferUser")]
	public int? Col29DefCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsStatus")]
	public int? Col29DefCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsRemindDay")]
	public int? Col29DefCnvsRemindDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col29DefCnvsReferDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsTopic")]
	public int? Col30DefCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferUser")]
	public int? Col30DefCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsStatus")]
	public int? Col30DefCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsRemindDay")]
	public int? Col30DefCnvsRemindDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col30DefCnvsReferDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsTopic")]
	public int? Col31DefCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferUser")]
	public int? Col31DefCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsStatus")]
	public int? Col31DefCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsRemindDay")]
	public int? Col31DefCnvsRemindDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col31DefCnvsReferDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsTopic")]
	public int? Col32DefCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferUser")]
	public int? Col32DefCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsStatus")]
	public int? Col32DefCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsRemindDay")]
	public int? Col32DefCnvsRemindDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col32DefCnvsReferDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsTopic")]
	public int? Col33DefCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferUser")]
	public int? Col33DefCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsStatus")]
	public int? Col33DefCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsRemindDay")]
	public int? Col33DefCnvsRemindDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col33DefCnvsReferDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsTopic")]
	public int? Col34DefCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferUser")]
	public int? Col34DefCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsStatus")]
	public int? Col34DefCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsRemindDay")]
	public int? Col34DefCnvsRemindDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col34DefCnvsReferDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsTopic")]
	public int? Col35DefCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferUser")]
	public int? Col35DefCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsStatus")]
	public int? Col35DefCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsRemindDay")]
	public int? Col35DefCnvsRemindDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col35DefCnvsReferDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsTopic")]
	public int? Col36DefCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferUser")]
	public int? Col36DefCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsStatus")]
	public int? Col36DefCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsRemindDay")]
	public int? Col36DefCnvsRemindDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col36DefCnvsReferDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsTopic")]
	public int? Col37DefCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferUser")]
	public int? Col37DefCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsStatus")]
	public int? Col37DefCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsRemindDay")]
	public int? Col37DefCnvsRemindDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col37DefCnvsReferDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsTopic")]
	public int? Col38DefCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferUser")]
	public int? Col38DefCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsStatus")]
	public int? Col38DefCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsRemindDay")]
	public int? Col38DefCnvsRemindDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col38DefCnvsReferDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsTopic")]
	public int? Col39DefCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferUser")]
	public int? Col39DefCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsStatus")]
	public int? Col39DefCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsRemindDay")]
	public int? Col39DefCnvsRemindDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col39DefCnvsReferDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsTopic")]
	public int? Col40DefCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferUser")]
	public int? Col40DefCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsStatus")]
	public int? Col40DefCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsRemindDay")]
	public int? Col40DefCnvsRemindDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col40DefCnvsReferDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsTopic")]
	public int? Col41DefCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferUser")]
	public int? Col41DefCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsStatus")]
	public int? Col41DefCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsRemindDay")]
	public int? Col41DefCnvsRemindDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col41DefCnvsReferDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsTopic")]
	public int? Col42DefCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferUser")]
	public int? Col42DefCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsStatus")]
	public int? Col42DefCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsRemindDay")]
	public int? Col42DefCnvsRemindDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col42DefCnvsReferDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsTopic")]
	public int? Col43DefCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferUser")]
	public int? Col43DefCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsStatus")]
	public int? Col43DefCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsRemindDay")]
	public int? Col43DefCnvsRemindDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col43DefCnvsReferDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsTopic")]
	public int? Col44DefCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferUser")]
	public int? Col44DefCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsStatus")]
	public int? Col44DefCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsRemindDay")]
	public int? Col44DefCnvsRemindDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col44DefCnvsReferDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsTopic")]
	public int? Col45DefCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferUser")]
	public int? Col45DefCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsStatus")]
	public int? Col45DefCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsRemindDay")]
	public int? Col45DefCnvsRemindDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col45DefCnvsReferDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsTopic")]
	public int? Col46DefCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferUser")]
	public int? Col46DefCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsStatus")]
	public int? Col46DefCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsRemindDay")]
	public int? Col46DefCnvsRemindDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col46DefCnvsReferDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsTopic")]
	public int? Col47DefCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferUser")]
	public int? Col47DefCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsStatus")]
	public int? Col47DefCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsRemindDay")]
	public int? Col47DefCnvsRemindDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col47DefCnvsReferDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsTopic")]
	public int? Col48DefCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferUser")]
	public int? Col48DefCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsStatus")]
	public int? Col48DefCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsRemindDay")]
	public int? Col48DefCnvsRemindDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col48DefCnvsReferDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsTopic")]
	public int? Col49DefCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferUser")]
	public int? Col49DefCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsStatus")]
	public int? Col49DefCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsRemindDay")]
	public int? Col49DefCnvsRemindDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col49DefCnvsReferDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsTopic")]
	public int? Col50DefCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferUser")]
	public int? Col50DefCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsStatus")]
	public int? Col50DefCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsRemindDay")]
	public int? Col50DefCnvsRemindDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col50DefCnvsReferDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsTopic")]
	public int? Col51DefCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferUser")]
	public int? Col51DefCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsStatus")]
	public int? Col51DefCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsRemindDay")]
	public int? Col51DefCnvsRemindDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col51DefCnvsReferDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsTopic")]
	public int? Col52DefCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferUser")]
	public int? Col52DefCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsStatus")]
	public int? Col52DefCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsRemindDay")]
	public int? Col52DefCnvsRemindDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col52DefCnvsReferDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsTopic")]
	public int? Col53DefCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferUser")]
	public int? Col53DefCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsStatus")]
	public int? Col53DefCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsRemindDay")]
	public int? Col53DefCnvsRemindDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col53DefCnvsReferDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsTopic")]
	public int? Col54DefCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferUser")]
	public int? Col54DefCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsStatus")]
	public int? Col54DefCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsRemindDay")]
	public int? Col54DefCnvsRemindDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col54DefCnvsReferDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsTopic")]
	public int? Col55DefCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferUser")]
	public int? Col55DefCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsStatus")]
	public int? Col55DefCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsRemindDay")]
	public int? Col55DefCnvsRemindDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col55DefCnvsReferDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsTopic")]
	public int? Col56DefCnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferUser")]
	public int? Col56DefCnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsStatus")]
	public int? Col56DefCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsRemindDay")]
	public int? Col56DefCnvsRemindDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefCnvsReferDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col56DefCnvsReferDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefKnowledgeTank")]
	public int? ColOneDefKnowledgeTankId { get; set; }

	public string ColOneDefKnowledgeTank { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefKnowledgeTank")]
	public int? ColTwoDefKnowledgeTankId { get; set; }

	public string ColTwoDefKnowledgeTank { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefKnowledgeTank")]
	public int? ColThreeDefKnowledgeTankId { get; set; }

	public string ColThreeDefKnowledgeTank { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefKnowledgeTank")]
	public int? ColFourDefKnowledgeTankId { get; set; }

	public string ColFourDefKnowledgeTank { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefKnowledgeTank")]
	public int? ColFiveDefKnowledgeTankId { get; set; }

	public string ColFiveDefKnowledgeTank { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefKnowledgeTank")]
	public int? ColSixDefKnowledgeTankId { get; set; }

	public string ColSixDefKnowledgeTank { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefKnowledgeTank")]
	public int? ColSevenDefKnowledgeTankId { get; set; }

	public string ColSevenDefKnowledgeTank { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefKnowledgeTank")]
	public int? ColEightDefKnowledgeTankId { get; set; }

	public string ColEightDefKnowledgeTank { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefKnowledgeTank")]
	public int? ColNineDefKnowledgeTankId { get; set; }

	public string ColNineDefKnowledgeTank { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefKnowledgeTank")]
	public int? ColTenDefKnowledgeTankId { get; set; }

	public string ColTenDefKnowledgeTank { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefKnowledgeTank")]
	public int? Col11DefKnowledgeTankId { get; set; }

	public string Col11DefKnowledgeTank { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefKnowledgeTank")]
	public int? Col12DefKnowledgeTankId { get; set; }

	public string Col12DefKnowledgeTank { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefKnowledgeTank")]
	public int? Col13DefKnowledgeTankId { get; set; }

	public string Col13DefKnowledgeTank { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefKnowledgeTank")]
	public int? Col14DefKnowledgeTankId { get; set; }

	public string Col14DefKnowledgeTank { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefKnowledgeTank")]
	public int? Col15DefKnowledgeTankId { get; set; }

	public string Col15DefKnowledgeTank { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefKnowledgeTank")]
	public int? Col16DefKnowledgeTankId { get; set; }

	public string Col16DefKnowledgeTank { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefKnowledgeTank")]
	public int? Col17DefKnowledgeTankId { get; set; }

	public string Col17DefKnowledgeTank { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefKnowledgeTank")]
	public int? Col18DefKnowledgeTankId { get; set; }

	public string Col18DefKnowledgeTank { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefKnowledgeTank")]
	public int? Col19DefKnowledgeTankId { get; set; }

	public string Col19DefKnowledgeTank { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefKnowledgeTank")]
	public int? Col20DefKnowledgeTankId { get; set; }

	public string Col20DefKnowledgeTank { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefKnowledgeTank")]
	public int? Col21DefKnowledgeTankId { get; set; }

	public string Col21DefKnowledgeTank { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefKnowledgeTank")]
	public int? Col22DefKnowledgeTankId { get; set; }

	public string Col22DefKnowledgeTank { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefKnowledgeTank")]
	public int? Col23DefKnowledgeTankId { get; set; }

	public string Col23DefKnowledgeTank { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefKnowledgeTank")]
	public int? Col24DefKnowledgeTankId { get; set; }

	public string Col24DefKnowledgeTank { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefKnowledgeTank")]
	public int? Col25DefKnowledgeTankId { get; set; }

	public string Col25DefKnowledgeTank { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefKnowledgeTank")]
	public int? Col26DefKnowledgeTankId { get; set; }

	public string Col26DefKnowledgeTank { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefKnowledgeTank")]
	public int? Col27DefKnowledgeTankId { get; set; }

	public string Col27DefKnowledgeTank { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefKnowledgeTank")]
	public int? Col28DefKnowledgeTankId { get; set; }

	public string Col28DefKnowledgeTank { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefKnowledgeTank")]
	public int? Col29DefKnowledgeTankId { get; set; }

	public string Col29DefKnowledgeTank { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefKnowledgeTank")]
	public int? Col30DefKnowledgeTankId { get; set; }

	public string Col30DefKnowledgeTank { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefKnowledgeTank")]
	public int? Col31DefKnowledgeTankId { get; set; }

	public string Col31DefKnowledgeTank { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefKnowledgeTank")]
	public int? Col32DefKnowledgeTankId { get; set; }

	public string Col32DefKnowledgeTank { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefKnowledgeTank")]
	public int? Col33DefKnowledgeTankId { get; set; }

	public string Col33DefKnowledgeTank { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefKnowledgeTank")]
	public int? Col34DefKnowledgeTankId { get; set; }

	public string Col34DefKnowledgeTank { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefKnowledgeTank")]
	public int? Col35DefKnowledgeTankId { get; set; }

	public string Col35DefKnowledgeTank { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefKnowledgeTank")]
	public int? Col36DefKnowledgeTankId { get; set; }

	public string Col36DefKnowledgeTank { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefKnowledgeTank")]
	public int? Col37DefKnowledgeTankId { get; set; }

	public string Col37DefKnowledgeTank { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefKnowledgeTank")]
	public int? Col38DefKnowledgeTankId { get; set; }

	public string Col38DefKnowledgeTank { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefKnowledgeTank")]
	public int? Col39DefKnowledgeTankId { get; set; }

	public string Col39DefKnowledgeTank { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefKnowledgeTank")]
	public int? Col40DefKnowledgeTankId { get; set; }

	public string Col40DefKnowledgeTank { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefKnowledgeTank")]
	public int? Col41DefKnowledgeTankId { get; set; }

	public string Col41DefKnowledgeTank { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefKnowledgeTank")]
	public int? Col42DefKnowledgeTankId { get; set; }

	public string Col42DefKnowledgeTank { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefKnowledgeTank")]
	public int? Col43DefKnowledgeTankId { get; set; }

	public string Col43DefKnowledgeTank { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefKnowledgeTank")]
	public int? Col44DefKnowledgeTankId { get; set; }

	public string Col44DefKnowledgeTank { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefKnowledgeTank")]
	public int? Col45DefKnowledgeTankId { get; set; }

	public string Col45DefKnowledgeTank { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefKnowledgeTank")]
	public int? Col46DefKnowledgeTankId { get; set; }

	public string Col46DefKnowledgeTank { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefKnowledgeTank")]
	public int? Col47DefKnowledgeTankId { get; set; }

	public string Col47DefKnowledgeTank { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefKnowledgeTank")]
	public int? Col48DefKnowledgeTankId { get; set; }

	public string Col48DefKnowledgeTank { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefKnowledgeTank")]
	public int? Col49DefKnowledgeTankId { get; set; }

	public string Col49DefKnowledgeTank { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefKnowledgeTank")]
	public int? Col50DefKnowledgeTankId { get; set; }

	public string Col50DefKnowledgeTank { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefKnowledgeTank")]
	public int? Col51DefKnowledgeTankId { get; set; }

	public string Col51DefKnowledgeTank { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefKnowledgeTank")]
	public int? Col52DefKnowledgeTankId { get; set; }

	public string Col52DefKnowledgeTank { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefKnowledgeTank")]
	public int? Col53DefKnowledgeTankId { get; set; }

	public string Col53DefKnowledgeTank { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefKnowledgeTank")]
	public int? Col54DefKnowledgeTankId { get; set; }

	public string Col54DefKnowledgeTank { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefKnowledgeTank")]
	public int? Col55DefKnowledgeTankId { get; set; }

	public string Col55DefKnowledgeTank { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDefContextDefKnowledgeTank")]
	public int? Col56DefKnowledgeTankId { get; set; }

	public string Col56DefKnowledgeTank { get; set; }

	public string ColOne_Lang { get; set; }

	public string ColTwo_Lang { get; set; }

	public string ColThree_Lang { get; set; }

	public string ColFour_Lang { get; set; }

	public string ColFive_Lang { get; set; }

	public string ColSix_Lang { get; set; }

	public string ColSeven_Lang { get; set; }

	public string ColEight_Lang { get; set; }

	public string ColNine_Lang { get; set; }

	public string ColTen_Lang { get; set; }

	public string Col11_Lang { get; set; }

	public string Col12_Lang { get; set; }

	public string Col13_Lang { get; set; }

	public string Col14_Lang { get; set; }

	public string Col15_Lang { get; set; }

	public string Col16_Lang { get; set; }

	public string Col17_Lang { get; set; }

	public string Col18_Lang { get; set; }

	public string Col19_Lang { get; set; }

	public string Col20_Lang { get; set; }

	public string Col21_Lang { get; set; }

	public string Col22_Lang { get; set; }

	public string Col23_Lang { get; set; }

	public string Col24_Lang { get; set; }

	public string Col25_Lang { get; set; }

	public string Col26_Lang { get; set; }

	public string Col27_Lang { get; set; }

	public string Col28_Lang { get; set; }

	public string Col29_Lang { get; set; }

	public string Col30_Lang { get; set; }

	public string Col31_Lang { get; set; }

	public string Col32_Lang { get; set; }

	public string Col33_Lang { get; set; }

	public string Col34_Lang { get; set; }

	public string Col35_Lang { get; set; }

	public string Col36_Lang { get; set; }

	public string Col37_Lang { get; set; }

	public string Col38_Lang { get; set; }

	public string Col39_Lang { get; set; }

	public string Col40_Lang { get; set; }

	public string Col41_Lang { get; set; }

	public string Col42_Lang { get; set; }

	public string Col43_Lang { get; set; }

	public string Col44_Lang { get; set; }

	public string Col45_Lang { get; set; }

	public string Col46_Lang { get; set; }

	public string Col47_Lang { get; set; }

	public string Col48_Lang { get; set; }

	public string Col49_Lang { get; set; }

	public string Col50_Lang { get; set; }

	public string Col51_Lang { get; set; }

	public string Col52_Lang { get; set; }

	public string Col53_Lang { get; set; }

	public string Col54_Lang { get; set; }

	public string Col55_Lang { get; set; }

	public string Col56_Lang { get; set; }

	public string ColOneDefCnvsReferDesc_Lang { get; set; }

	public string ColTwoDefCnvsReferDesc_Lang { get; set; }

	public string ColThreeDefCnvsReferDesc_Lang { get; set; }

	public string ColFourDefCnvsReferDesc_Lang { get; set; }

	public string ColFiveDefCnvsReferDesc_Lang { get; set; }

	public string ColSixDefCnvsReferDesc_Lang { get; set; }

	public string ColSevenDefCnvsReferDesc_Lang { get; set; }

	public string ColEightDefCnvsReferDesc_Lang { get; set; }

	public string ColNineDefCnvsReferDesc_Lang { get; set; }

	public string ColTenDefCnvsReferDesc_Lang { get; set; }

	public string Col11DefCnvsReferDesc_Lang { get; set; }

	public string Col12DefCnvsReferDesc_Lang { get; set; }

	public string Col13DefCnvsReferDesc_Lang { get; set; }

	public string Col14DefCnvsReferDesc_Lang { get; set; }

	public string Col15DefCnvsReferDesc_Lang { get; set; }

	public string Col16DefCnvsReferDesc_Lang { get; set; }

	public string Col17DefCnvsReferDesc_Lang { get; set; }

	public string Col18DefCnvsReferDesc_Lang { get; set; }

	public string Col19DefCnvsReferDesc_Lang { get; set; }

	public string Col20DefCnvsReferDesc_Lang { get; set; }

	public string Col21DefCnvsReferDesc_Lang { get; set; }

	public string Col22DefCnvsReferDesc_Lang { get; set; }

	public string Col23DefCnvsReferDesc_Lang { get; set; }

	public string Col24DefCnvsReferDesc_Lang { get; set; }

	public string Col25DefCnvsReferDesc_Lang { get; set; }

	public string Col26DefCnvsReferDesc_Lang { get; set; }

	public string Col27DefCnvsReferDesc_Lang { get; set; }

	public string Col28DefCnvsReferDesc_Lang { get; set; }

	public string Col29DefCnvsReferDesc_Lang { get; set; }

	public string Col30DefCnvsReferDesc_Lang { get; set; }

	public string Col31DefCnvsReferDesc_Lang { get; set; }

	public string Col32DefCnvsReferDesc_Lang { get; set; }

	public string Col33DefCnvsReferDesc_Lang { get; set; }

	public string Col34DefCnvsReferDesc_Lang { get; set; }

	public string Col35DefCnvsReferDesc_Lang { get; set; }

	public string Col36DefCnvsReferDesc_Lang { get; set; }

	public string Col37DefCnvsReferDesc_Lang { get; set; }

	public string Col38DefCnvsReferDesc_Lang { get; set; }

	public string Col39DefCnvsReferDesc_Lang { get; set; }

	public string Col40DefCnvsReferDesc_Lang { get; set; }

	public string Col41DefCnvsReferDesc_Lang { get; set; }

	public string Col42DefCnvsReferDesc_Lang { get; set; }

	public string Col43DefCnvsReferDesc_Lang { get; set; }

	public string Col44DefCnvsReferDesc_Lang { get; set; }

	public string Col45DefCnvsReferDesc_Lang { get; set; }

	public string Col46DefCnvsReferDesc_Lang { get; set; }

	public string Col47DefCnvsReferDesc_Lang { get; set; }

	public string Col48DefCnvsReferDesc_Lang { get; set; }

	public string Col49DefCnvsReferDesc_Lang { get; set; }

	public string Col50DefCnvsReferDesc_Lang { get; set; }

	public string Col51DefCnvsReferDesc_Lang { get; set; }

	public string Col52DefCnvsReferDesc_Lang { get; set; }

	public string Col53DefCnvsReferDesc_Lang { get; set; }

	public string Col54DefCnvsReferDesc_Lang { get; set; }

	public string Col55DefCnvsReferDesc_Lang { get; set; }

	public string Col56DefCnvsReferDesc_Lang { get; set; }
}
