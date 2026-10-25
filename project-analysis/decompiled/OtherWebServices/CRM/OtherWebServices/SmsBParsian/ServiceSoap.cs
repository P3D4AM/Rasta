using System.CodeDom.Compiler;
using System.ServiceModel;
using System.Threading.Tasks;

namespace CRM.OtherWebServices.SmsBParsian;

[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[ServiceContract(Namespace = "http://www.SMS.parsianInsurance.ir/", ConfigurationName = "SmsBParsian.ServiceSoap")]
public interface ServiceSoap
{
	[OperationContract(Action = "http://www.SMS.parsianInsurance.ir/InsertSMS", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string InsertSMS(string UserName, string Passwrd, string FirstName, string LastName, string CellPhone, string SMSText, string Description, string PolicyID, int AppName);

	[OperationContract(Action = "http://www.SMS.parsianInsurance.ir/InsertSMS", ReplyAction = "*")]
	Task<string> InsertSMSAsync(string UserName, string Passwrd, string FirstName, string LastName, string CellPhone, string SMSText, string Description, string PolicyID, int AppName);

	[OperationContract(Action = "http://www.SMS.parsianInsurance.ir/Insert_Saiboon", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	string Insert_Saiboon(string UserName, string Passwrd, string FirstName, string LastName, string CellPhone, string SMSText, string Description, string PolicyID, int AppName, string ReservedField3);

	[OperationContract(Action = "http://www.SMS.parsianInsurance.ir/Insert_Saiboon", ReplyAction = "*")]
	Task<string> Insert_SaiboonAsync(string UserName, string Passwrd, string FirstName, string LastName, string CellPhone, string SMSText, string Description, string PolicyID, int AppName, string ReservedField3);
}
