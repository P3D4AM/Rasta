using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace CRM.OtherWebServices.SmsBParsian;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
public class ServiceSoapClient : ClientBase<ServiceSoap>, ServiceSoap
{
	public ServiceSoapClient()
	{
	}

	public ServiceSoapClient(string endpointConfigurationName)
		: base(endpointConfigurationName)
	{
	}

	public ServiceSoapClient(string endpointConfigurationName, string remoteAddress)
		: base(endpointConfigurationName, remoteAddress)
	{
	}

	public ServiceSoapClient(string endpointConfigurationName, EndpointAddress remoteAddress)
		: base(endpointConfigurationName, remoteAddress)
	{
	}

	public ServiceSoapClient(Binding binding, EndpointAddress remoteAddress)
		: base(binding, remoteAddress)
	{
	}

	public string InsertSMS(string UserName, string Passwrd, string FirstName, string LastName, string CellPhone, string SMSText, string Description, string PolicyID, int AppName)
	{
		return base.Channel.InsertSMS(UserName, Passwrd, FirstName, LastName, CellPhone, SMSText, Description, PolicyID, AppName);
	}

	public Task<string> InsertSMSAsync(string UserName, string Passwrd, string FirstName, string LastName, string CellPhone, string SMSText, string Description, string PolicyID, int AppName)
	{
		return base.Channel.InsertSMSAsync(UserName, Passwrd, FirstName, LastName, CellPhone, SMSText, Description, PolicyID, AppName);
	}

	public string Insert_Saiboon(string UserName, string Passwrd, string FirstName, string LastName, string CellPhone, string SMSText, string Description, string PolicyID, int AppName, string ReservedField3)
	{
		return base.Channel.Insert_Saiboon(UserName, Passwrd, FirstName, LastName, CellPhone, SMSText, Description, PolicyID, AppName, ReservedField3);
	}

	public Task<string> Insert_SaiboonAsync(string UserName, string Passwrd, string FirstName, string LastName, string CellPhone, string SMSText, string Description, string PolicyID, int AppName, string ReservedField3)
	{
		return base.Channel.Insert_SaiboonAsync(UserName, Passwrd, FirstName, LastName, CellPhone, SMSText, Description, PolicyID, AppName, ReservedField3);
	}
}
