using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;
using Mobile.Properties;

namespace Mobile.SmsFor;

[GeneratedCode("System.Web.Services", "4.8.4084.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[WebServiceBinding(Name = "SmsPanelWebserviceBinding", Namespace = "urn:sms_webservice_wsdl")]
[SoapInclude(typeof(array_user_packageid))]
[SoapInclude(typeof(array_tree))]
[SoapInclude(typeof(array_receive))]
[SoapInclude(typeof(array_sent))]
[SoapInclude(typeof(array_number_state))]
[SoapInclude(typeof(array_number))]
[SoapInclude(typeof(array_cat_list))]
[SoapInclude(typeof(array_number_in_cat))]
public class SmsPanelWebservice : SoapHttpClientProtocol
{
	private SendOrPostCallback sms_get_number_in_catOperationCompleted;

	private SendOrPostCallback sms_get_cat_listOperationCompleted;

	private SendOrPostCallback send_smsOperationCompleted;

	private SendOrPostCallback get_numberOperationCompleted;

	private SendOrPostCallback sms_deliverOperationCompleted;

	private SendOrPostCallback sms_deliver_onlineOperationCompleted;

	private SendOrPostCallback is_number_in_blacklistOperationCompleted;

	private SendOrPostCallback add_userOperationCompleted;

	private SendOrPostCallback sms_user_infoOperationCompleted;

	private SendOrPostCallback sms_creditOperationCompleted;

	private SendOrPostCallback sms_add_numberOperationCompleted;

	private SendOrPostCallback sms_sentOperationCompleted;

	private SendOrPostCallback sms_receiveOperationCompleted;

	private SendOrPostCallback sms_receive_change_readOperationCompleted;

	private SendOrPostCallback sms_count_bulk_genderOperationCompleted;

	private SendOrPostCallback sms_send_bulk_genderOperationCompleted;

	private SendOrPostCallback sms_count_bank_genderOperationCompleted;

	private SendOrPostCallback user_add_catOperationCompleted;

	private SendOrPostCallback convert_unixtime_to_jalaliOperationCompleted;

	private SendOrPostCallback number_queryOperationCompleted;

	private SendOrPostCallback convert_jalali_to_unixtimestampOperationCompleted;

	private SendOrPostCallback admin_allow_number_newOperationCompleted;

	private SendOrPostCallback admin_get_user_packageidOperationCompleted;

	private bool useDefaultCredentialsSetExplicitly;

	public string Url
	{
		get
		{
			return ((WebClientProtocol)this).Url;
		}
		set
		{
			if (IsLocalFileSystemWebService(((WebClientProtocol)this).Url) && !useDefaultCredentialsSetExplicitly && !IsLocalFileSystemWebService(value))
			{
				((WebClientProtocol)this).UseDefaultCredentials = false;
			}
			((WebClientProtocol)this).Url = value;
		}
	}

	public bool UseDefaultCredentials
	{
		get
		{
			return ((WebClientProtocol)this).UseDefaultCredentials;
		}
		set
		{
			((WebClientProtocol)this).UseDefaultCredentials = value;
			useDefaultCredentialsSetExplicitly = true;
		}
	}

	public event sms_get_number_in_catCompletedEventHandler sms_get_number_in_catCompleted;

	public event sms_get_cat_listCompletedEventHandler sms_get_cat_listCompleted;

	public event send_smsCompletedEventHandler send_smsCompleted;

	public event get_numberCompletedEventHandler get_numberCompleted;

	public event sms_deliverCompletedEventHandler sms_deliverCompleted;

	public event sms_deliver_onlineCompletedEventHandler sms_deliver_onlineCompleted;

	public event is_number_in_blacklistCompletedEventHandler is_number_in_blacklistCompleted;

	public event add_userCompletedEventHandler add_userCompleted;

	public event sms_user_infoCompletedEventHandler sms_user_infoCompleted;

	public event sms_creditCompletedEventHandler sms_creditCompleted;

	public event sms_add_numberCompletedEventHandler sms_add_numberCompleted;

	public event sms_sentCompletedEventHandler sms_sentCompleted;

	public event sms_receiveCompletedEventHandler sms_receiveCompleted;

	public event sms_receive_change_readCompletedEventHandler sms_receive_change_readCompleted;

	public event sms_count_bulk_genderCompletedEventHandler sms_count_bulk_genderCompleted;

	public event sms_send_bulk_genderCompletedEventHandler sms_send_bulk_genderCompleted;

	public event sms_count_bank_genderCompletedEventHandler sms_count_bank_genderCompleted;

	public event user_add_catCompletedEventHandler user_add_catCompleted;

	public event convert_unixtime_to_jalaliCompletedEventHandler convert_unixtime_to_jalaliCompleted;

	public event number_queryCompletedEventHandler number_queryCompleted;

	public event convert_jalali_to_unixtimestampCompletedEventHandler convert_jalali_to_unixtimestampCompleted;

	public event admin_allow_number_newCompletedEventHandler admin_allow_number_newCompleted;

	public event admin_get_user_packageidCompletedEventHandler admin_get_user_packageidCompleted;

	public SmsPanelWebservice()
	{
		Url = Settings.Default.Mobile_SmsFor_SmsPanelWebservice;
		if (IsLocalFileSystemWebService(Url))
		{
			UseDefaultCredentials = true;
			useDefaultCredentialsSetExplicitly = false;
		}
		else
		{
			useDefaultCredentialsSetExplicitly = true;
		}
	}

	[SoapRpcMethod("sms_webservice_wsdl#sms_get_number_in_cat", RequestNamespace = "sms_webservice_wsdl", ResponseNamespace = "sms_webservice_wsdl")]
	[return: SoapElement("return")]
	public array_number_in_cat[] sms_get_number_in_cat(string username, string password, int catid, int start, int perpage, string order)
	{
		return (array_number_in_cat[])((SoapHttpClientProtocol)this).Invoke("sms_get_number_in_cat", new object[6] { username, password, catid, start, perpage, order })[0];
	}

	public void sms_get_number_in_catAsync(string username, string password, int catid, int start, int perpage, string order)
	{
		sms_get_number_in_catAsync(username, password, catid, start, perpage, order, null);
	}

	public void sms_get_number_in_catAsync(string username, string password, int catid, int start, int perpage, string order, object userState)
	{
		if (sms_get_number_in_catOperationCompleted == null)
		{
			sms_get_number_in_catOperationCompleted = Onsms_get_number_in_catOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("sms_get_number_in_cat", new object[6] { username, password, catid, start, perpage, order }, sms_get_number_in_catOperationCompleted, userState);
	}

	private void Onsms_get_number_in_catOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.sms_get_number_in_catCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.sms_get_number_in_catCompleted(this, new sms_get_number_in_catCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapRpcMethod("sms_webservice_wsdl#sms_get_cat_list", RequestNamespace = "sms_webservice_wsdl", ResponseNamespace = "sms_webservice_wsdl")]
	[return: SoapElement("return")]
	public array_cat_list[] sms_get_cat_list(string username, string password)
	{
		return (array_cat_list[])((SoapHttpClientProtocol)this).Invoke("sms_get_cat_list", new object[2] { username, password })[0];
	}

	public void sms_get_cat_listAsync(string username, string password)
	{
		sms_get_cat_listAsync(username, password, null);
	}

	public void sms_get_cat_listAsync(string username, string password, object userState)
	{
		if (sms_get_cat_listOperationCompleted == null)
		{
			sms_get_cat_listOperationCompleted = Onsms_get_cat_listOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("sms_get_cat_list", new object[2] { username, password }, sms_get_cat_listOperationCompleted, userState);
	}

	private void Onsms_get_cat_listOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.sms_get_cat_listCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.sms_get_cat_listCompleted(this, new sms_get_cat_listCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapRpcMethod("sms_webservice_wsdl#send_sms", RequestNamespace = "sms_webservice_wsdl", ResponseNamespace = "sms_webservice_wsdl")]
	[return: SoapElement("return")]
	public string[] send_sms(string username, string password, string[] sender_number, string[] receiver_number, string[] note, string[] date, string[] request_uniqueid, string[] flash, string onlysend)
	{
		return (string[])((SoapHttpClientProtocol)this).Invoke("send_sms", new object[9] { username, password, sender_number, receiver_number, note, date, request_uniqueid, flash, onlysend })[0];
	}

	public void send_smsAsync(string username, string password, string[] sender_number, string[] receiver_number, string[] note, string[] date, string[] request_uniqueid, string[] flash, string onlysend)
	{
		send_smsAsync(username, password, sender_number, receiver_number, note, date, request_uniqueid, flash, onlysend, null);
	}

	public void send_smsAsync(string username, string password, string[] sender_number, string[] receiver_number, string[] note, string[] date, string[] request_uniqueid, string[] flash, string onlysend, object userState)
	{
		if (send_smsOperationCompleted == null)
		{
			send_smsOperationCompleted = Onsend_smsOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("send_sms", new object[9] { username, password, sender_number, receiver_number, note, date, request_uniqueid, flash, onlysend }, send_smsOperationCompleted, userState);
	}

	private void Onsend_smsOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.send_smsCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.send_smsCompleted(this, new send_smsCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapRpcMethod("sms_webservice_wsdl#get_number", RequestNamespace = "sms_webservice_wsdl", ResponseNamespace = "sms_webservice_wsdl")]
	[return: SoapElement("return")]
	public array_number[] get_number(string username, string password)
	{
		return (array_number[])((SoapHttpClientProtocol)this).Invoke("get_number", new object[2] { username, password })[0];
	}

	public void get_numberAsync(string username, string password)
	{
		get_numberAsync(username, password, null);
	}

	public void get_numberAsync(string username, string password, object userState)
	{
		if (get_numberOperationCompleted == null)
		{
			get_numberOperationCompleted = Onget_numberOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("get_number", new object[2] { username, password }, get_numberOperationCompleted, userState);
	}

	private void Onget_numberOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.get_numberCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.get_numberCompleted(this, new get_numberCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapRpcMethod("sms_webservice_wsdl#sms_deliver", RequestNamespace = "sms_webservice_wsdl", ResponseNamespace = "sms_webservice_wsdl")]
	[return: SoapElement("return")]
	public long[] sms_deliver(string[] smsid_arr, int dargah)
	{
		return (long[])((SoapHttpClientProtocol)this).Invoke("sms_deliver", new object[2] { smsid_arr, dargah })[0];
	}

	public void sms_deliverAsync(string[] smsid_arr, int dargah)
	{
		sms_deliverAsync(smsid_arr, dargah, null);
	}

	public void sms_deliverAsync(string[] smsid_arr, int dargah, object userState)
	{
		if (sms_deliverOperationCompleted == null)
		{
			sms_deliverOperationCompleted = Onsms_deliverOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("sms_deliver", new object[2] { smsid_arr, dargah }, sms_deliverOperationCompleted, userState);
	}

	private void Onsms_deliverOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.sms_deliverCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.sms_deliverCompleted(this, new sms_deliverCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapRpcMethod("sms_webservice_wsdl#sms_deliver", RequestNamespace = "sms_webservice_wsdl", ResponseNamespace = "sms_webservice_wsdl")]
	[return: SoapElement("return")]
	public long[] sms_deliver_online(string[] smsid_arr, int dargah)
	{
		return (long[])((SoapHttpClientProtocol)this).Invoke("sms_deliver_online", new object[2] { smsid_arr, dargah })[0];
	}

	public void sms_deliver_onlineAsync(string[] smsid_arr, int dargah)
	{
		sms_deliver_onlineAsync(smsid_arr, dargah, null);
	}

	public void sms_deliver_onlineAsync(string[] smsid_arr, int dargah, object userState)
	{
		if (sms_deliver_onlineOperationCompleted == null)
		{
			sms_deliver_onlineOperationCompleted = Onsms_deliver_onlineOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("sms_deliver_online", new object[2] { smsid_arr, dargah }, sms_deliver_onlineOperationCompleted, userState);
	}

	private void Onsms_deliver_onlineOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.sms_deliver_onlineCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.sms_deliver_onlineCompleted(this, new sms_deliver_onlineCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapRpcMethod("sms_webservice_wsdl#is_number_in_blacklist", RequestNamespace = "sms_webservice_wsdl", ResponseNamespace = "sms_webservice_wsdl")]
	[return: SoapElement("return")]
	public array_number_state[] is_number_in_blacklist(string[] number)
	{
		return (array_number_state[])((SoapHttpClientProtocol)this).Invoke("is_number_in_blacklist", new object[1] { number })[0];
	}

	public void is_number_in_blacklistAsync(string[] number)
	{
		is_number_in_blacklistAsync(number, null);
	}

	public void is_number_in_blacklistAsync(string[] number, object userState)
	{
		if (is_number_in_blacklistOperationCompleted == null)
		{
			is_number_in_blacklistOperationCompleted = Onis_number_in_blacklistOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("is_number_in_blacklist", new object[1] { number }, is_number_in_blacklistOperationCompleted, userState);
	}

	private void Onis_number_in_blacklistOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.is_number_in_blacklistCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.is_number_in_blacklistCompleted(this, new is_number_in_blacklistCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapRpcMethod("sms_webservice_wsdl#add_user", RequestNamespace = "sms_webservice_wsdl", ResponseNamespace = "sms_webservice_wsdl")]
	[return: SoapElement("return")]
	public string add_user(string admin_username, string admin_password, string username, string password, string email, string fullname, string mobile, int catid, int cash, int user_packageid)
	{
		return (string)((SoapHttpClientProtocol)this).Invoke("add_user", new object[10] { admin_username, admin_password, username, password, email, fullname, mobile, catid, cash, user_packageid })[0];
	}

	public void add_userAsync(string admin_username, string admin_password, string username, string password, string email, string fullname, string mobile, int catid, int cash, int user_packageid)
	{
		add_userAsync(admin_username, admin_password, username, password, email, fullname, mobile, catid, cash, user_packageid, null);
	}

	public void add_userAsync(string admin_username, string admin_password, string username, string password, string email, string fullname, string mobile, int catid, int cash, int user_packageid, object userState)
	{
		if (add_userOperationCompleted == null)
		{
			add_userOperationCompleted = Onadd_userOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("add_user", new object[10] { admin_username, admin_password, username, password, email, fullname, mobile, catid, cash, user_packageid }, add_userOperationCompleted, userState);
	}

	private void Onadd_userOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.add_userCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.add_userCompleted(this, new add_userCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapRpcMethod("sms_webservice_wsdl#sms_user_info", RequestNamespace = "sms_webservice_wsdl", ResponseNamespace = "sms_webservice_wsdl")]
	[return: SoapElement("return")]
	public return_array_user_info sms_user_info(string username, string password)
	{
		return (return_array_user_info)((SoapHttpClientProtocol)this).Invoke("sms_user_info", new object[2] { username, password })[0];
	}

	public void sms_user_infoAsync(string username, string password)
	{
		sms_user_infoAsync(username, password, null);
	}

	public void sms_user_infoAsync(string username, string password, object userState)
	{
		if (sms_user_infoOperationCompleted == null)
		{
			sms_user_infoOperationCompleted = Onsms_user_infoOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("sms_user_info", new object[2] { username, password }, sms_user_infoOperationCompleted, userState);
	}

	private void Onsms_user_infoOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.sms_user_infoCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.sms_user_infoCompleted(this, new sms_user_infoCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapRpcMethod("sms_webservice_wsdl#sms_credit", RequestNamespace = "sms_webservice_wsdl", ResponseNamespace = "sms_webservice_wsdl")]
	[return: SoapElement("return")]
	public int sms_credit(string username, string password)
	{
		return (int)((SoapHttpClientProtocol)this).Invoke("sms_credit", new object[2] { username, password })[0];
	}

	public void sms_creditAsync(string username, string password)
	{
		sms_creditAsync(username, password, null);
	}

	public void sms_creditAsync(string username, string password, object userState)
	{
		if (sms_creditOperationCompleted == null)
		{
			sms_creditOperationCompleted = Onsms_creditOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("sms_credit", new object[2] { username, password }, sms_creditOperationCompleted, userState);
	}

	private void Onsms_creditOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.sms_creditCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.sms_creditCompleted(this, new sms_creditCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapRpcMethod("sms_webservice_wsdl#sms_add_number", RequestNamespace = "sms_webservice_wsdl", ResponseNamespace = "sms_webservice_wsdl")]
	[return: SoapElement("return")]
	public string sms_add_number(string username, string password, string fullname, string number, int catid, string gender, string fullname_en, string gender_en)
	{
		return (string)((SoapHttpClientProtocol)this).Invoke("sms_add_number", new object[8] { username, password, fullname, number, catid, gender, fullname_en, gender_en })[0];
	}

	public void sms_add_numberAsync(string username, string password, string fullname, string number, int catid, string gender, string fullname_en, string gender_en)
	{
		sms_add_numberAsync(username, password, fullname, number, catid, gender, fullname_en, gender_en, null);
	}

	public void sms_add_numberAsync(string username, string password, string fullname, string number, int catid, string gender, string fullname_en, string gender_en, object userState)
	{
		if (sms_add_numberOperationCompleted == null)
		{
			sms_add_numberOperationCompleted = Onsms_add_numberOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("sms_add_number", new object[8] { username, password, fullname, number, catid, gender, fullname_en, gender_en }, sms_add_numberOperationCompleted, userState);
	}

	private void Onsms_add_numberOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.sms_add_numberCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.sms_add_numberCompleted(this, new sms_add_numberCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapRpcMethod("sms_webservice_wsdl#sms_sent", RequestNamespace = "sms_webservice_wsdl", ResponseNamespace = "sms_webservice_wsdl")]
	[return: SoapElement("return")]
	public array_sent[] sms_sent(string username, string password, string dargah, int archive_year, int archive_month, int start, int perpage, string order)
	{
		return (array_sent[])((SoapHttpClientProtocol)this).Invoke("sms_sent", new object[8] { username, password, dargah, archive_year, archive_month, start, perpage, order })[0];
	}

	public void sms_sentAsync(string username, string password, string dargah, int archive_year, int archive_month, int start, int perpage, string order)
	{
		sms_sentAsync(username, password, dargah, archive_year, archive_month, start, perpage, order, null);
	}

	public void sms_sentAsync(string username, string password, string dargah, int archive_year, int archive_month, int start, int perpage, string order, object userState)
	{
		if (sms_sentOperationCompleted == null)
		{
			sms_sentOperationCompleted = Onsms_sentOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("sms_sent", new object[8] { username, password, dargah, archive_year, archive_month, start, perpage, order }, sms_sentOperationCompleted, userState);
	}

	private void Onsms_sentOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.sms_sentCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.sms_sentCompleted(this, new sms_sentCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapRpcMethod("sms_webservice_wsdl#sms_receive", RequestNamespace = "sms_webservice_wsdl", ResponseNamespace = "sms_webservice_wsdl")]
	[return: SoapElement("return")]
	public array_receive[] sms_receive(string username, string password, string number, int catid, int start, int perpage, int read, string order)
	{
		return (array_receive[])((SoapHttpClientProtocol)this).Invoke("sms_receive", new object[8] { username, password, number, catid, start, perpage, read, order })[0];
	}

	public void sms_receiveAsync(string username, string password, string number, int catid, int start, int perpage, int read, string order)
	{
		sms_receiveAsync(username, password, number, catid, start, perpage, read, order, null);
	}

	public void sms_receiveAsync(string username, string password, string number, int catid, int start, int perpage, int read, string order, object userState)
	{
		if (sms_receiveOperationCompleted == null)
		{
			sms_receiveOperationCompleted = Onsms_receiveOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("sms_receive", new object[8] { username, password, number, catid, start, perpage, read, order }, sms_receiveOperationCompleted, userState);
	}

	private void Onsms_receiveOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.sms_receiveCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.sms_receiveCompleted(this, new sms_receiveCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapRpcMethod("sms_webservice_wsdl#sms_receive_change_read", RequestNamespace = "sms_webservice_wsdl", ResponseNamespace = "sms_webservice_wsdl")]
	[return: SoapElement("return")]
	public string sms_receive_change_read(string username, string password, long[] id, int read)
	{
		return (string)((SoapHttpClientProtocol)this).Invoke("sms_receive_change_read", new object[4] { username, password, id, read })[0];
	}

	public void sms_receive_change_readAsync(string username, string password, long[] id, int read)
	{
		sms_receive_change_readAsync(username, password, id, read, null);
	}

	public void sms_receive_change_readAsync(string username, string password, long[] id, int read, object userState)
	{
		if (sms_receive_change_readOperationCompleted == null)
		{
			sms_receive_change_readOperationCompleted = Onsms_receive_change_readOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("sms_receive_change_read", new object[4] { username, password, id, read }, sms_receive_change_readOperationCompleted, userState);
	}

	private void Onsms_receive_change_readOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.sms_receive_change_readCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.sms_receive_change_readCompleted(this, new sms_receive_change_readCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapRpcMethod("sms_webservice_wsdl#sms_count_bulk_gender", RequestNamespace = "sms_webservice_wsdl", ResponseNamespace = "sms_webservice_wsdl")]
	[return: SoapElement("return")]
	public string sms_count_bulk_gender(string bankid, int gender, string receiver_number_kind, int age_start, int age_end, int receiver_number_perfix, int dargah)
	{
		return (string)((SoapHttpClientProtocol)this).Invoke("sms_count_bulk_gender", new object[7] { bankid, gender, receiver_number_kind, age_start, age_end, receiver_number_perfix, dargah })[0];
	}

	public void sms_count_bulk_genderAsync(string bankid, int gender, string receiver_number_kind, int age_start, int age_end, int receiver_number_perfix, int dargah)
	{
		sms_count_bulk_genderAsync(bankid, gender, receiver_number_kind, age_start, age_end, receiver_number_perfix, dargah, null);
	}

	public void sms_count_bulk_genderAsync(string bankid, int gender, string receiver_number_kind, int age_start, int age_end, int receiver_number_perfix, int dargah, object userState)
	{
		if (sms_count_bulk_genderOperationCompleted == null)
		{
			sms_count_bulk_genderOperationCompleted = Onsms_count_bulk_genderOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("sms_count_bulk_gender", new object[7] { bankid, gender, receiver_number_kind, age_start, age_end, receiver_number_perfix, dargah }, sms_count_bulk_genderOperationCompleted, userState);
	}

	private void Onsms_count_bulk_genderOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.sms_count_bulk_genderCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.sms_count_bulk_genderCompleted(this, new sms_count_bulk_genderCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapRpcMethod("sms_webservice_wsdl#sms_send_bulk_gender", RequestNamespace = "sms_webservice_wsdl", ResponseNamespace = "sms_webservice_wsdl")]
	[return: SoapElement("return")]
	public string sms_send_bulk_gender(string username, string password, string sender_number, string bankid, string note, int date, int record_start, int receiver_count, int gender, string receiver_number_kind, int age_start, int age_end, int receiver_number_perfix, string billing_title, string request_uniqueid, int dargah)
	{
		return (string)((SoapHttpClientProtocol)this).Invoke("sms_send_bulk_gender", new object[16]
		{
			username, password, sender_number, bankid, note, date, record_start, receiver_count, gender, receiver_number_kind,
			age_start, age_end, receiver_number_perfix, billing_title, request_uniqueid, dargah
		})[0];
	}

	public void sms_send_bulk_genderAsync(string username, string password, string sender_number, string bankid, string note, int date, int record_start, int receiver_count, int gender, string receiver_number_kind, int age_start, int age_end, int receiver_number_perfix, string billing_title, string request_uniqueid, int dargah)
	{
		sms_send_bulk_genderAsync(username, password, sender_number, bankid, note, date, record_start, receiver_count, gender, receiver_number_kind, age_start, age_end, receiver_number_perfix, billing_title, request_uniqueid, dargah, null);
	}

	public void sms_send_bulk_genderAsync(string username, string password, string sender_number, string bankid, string note, int date, int record_start, int receiver_count, int gender, string receiver_number_kind, int age_start, int age_end, int receiver_number_perfix, string billing_title, string request_uniqueid, int dargah, object userState)
	{
		if (sms_send_bulk_genderOperationCompleted == null)
		{
			sms_send_bulk_genderOperationCompleted = Onsms_send_bulk_genderOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("sms_send_bulk_gender", new object[16]
		{
			username, password, sender_number, bankid, note, date, record_start, receiver_count, gender, receiver_number_kind,
			age_start, age_end, receiver_number_perfix, billing_title, request_uniqueid, dargah
		}, sms_send_bulk_genderOperationCompleted, userState);
	}

	private void Onsms_send_bulk_genderOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.sms_send_bulk_genderCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.sms_send_bulk_genderCompleted(this, new sms_send_bulk_genderCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapRpcMethod("sms_webservice_wsdl#sms_count_bank_gender", RequestNamespace = "sms_webservice_wsdl", ResponseNamespace = "sms_webservice_wsdl")]
	[return: SoapElement("return")]
	public array_tree[] sms_count_bank_gender(int parentid, int dargah)
	{
		return (array_tree[])((SoapHttpClientProtocol)this).Invoke("sms_count_bank_gender", new object[2] { parentid, dargah })[0];
	}

	public void sms_count_bank_genderAsync(int parentid, int dargah)
	{
		sms_count_bank_genderAsync(parentid, dargah, null);
	}

	public void sms_count_bank_genderAsync(int parentid, int dargah, object userState)
	{
		if (sms_count_bank_genderOperationCompleted == null)
		{
			sms_count_bank_genderOperationCompleted = Onsms_count_bank_genderOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("sms_count_bank_gender", new object[2] { parentid, dargah }, sms_count_bank_genderOperationCompleted, userState);
	}

	private void Onsms_count_bank_genderOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.sms_count_bank_genderCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.sms_count_bank_genderCompleted(this, new sms_count_bank_genderCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapRpcMethod("sms_webservice_wsdl#user_add_cat", RequestNamespace = "sms_webservice_wsdl", ResponseNamespace = "sms_webservice_wsdl")]
	[return: SoapElement("return")]
	public long[] user_add_cat(string username, string password, string[] title)
	{
		return (long[])((SoapHttpClientProtocol)this).Invoke("user_add_cat", new object[3] { username, password, title })[0];
	}

	public void user_add_catAsync(string username, string password, string[] title)
	{
		user_add_catAsync(username, password, title, null);
	}

	public void user_add_catAsync(string username, string password, string[] title, object userState)
	{
		if (user_add_catOperationCompleted == null)
		{
			user_add_catOperationCompleted = Onuser_add_catOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("user_add_cat", new object[3] { username, password, title }, user_add_catOperationCompleted, userState);
	}

	private void Onuser_add_catOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.user_add_catCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.user_add_catCompleted(this, new user_add_catCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapRpcMethod("sms_webservice_wsdl#convert_unixtime_to_jalali", RequestNamespace = "sms_webservice_wsdl", ResponseNamespace = "sms_webservice_wsdl")]
	[return: SoapElement("return")]
	public string convert_unixtime_to_jalali(int date)
	{
		return (string)((SoapHttpClientProtocol)this).Invoke("convert_unixtime_to_jalali", new object[1] { date })[0];
	}

	public void convert_unixtime_to_jalaliAsync(int date)
	{
		convert_unixtime_to_jalaliAsync(date, null);
	}

	public void convert_unixtime_to_jalaliAsync(int date, object userState)
	{
		if (convert_unixtime_to_jalaliOperationCompleted == null)
		{
			convert_unixtime_to_jalaliOperationCompleted = Onconvert_unixtime_to_jalaliOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("convert_unixtime_to_jalali", new object[1] { date }, convert_unixtime_to_jalaliOperationCompleted, userState);
	}

	private void Onconvert_unixtime_to_jalaliOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.convert_unixtime_to_jalaliCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.convert_unixtime_to_jalaliCompleted(this, new convert_unixtime_to_jalaliCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapRpcMethod("sms_webservice_wsdl#number_query", RequestNamespace = "sms_webservice_wsdl", ResponseNamespace = "sms_webservice_wsdl")]
	[return: SoapElement("return")]
	public string number_query(string number)
	{
		return (string)((SoapHttpClientProtocol)this).Invoke("number_query", new object[1] { number })[0];
	}

	public void number_queryAsync(string number)
	{
		number_queryAsync(number, null);
	}

	public void number_queryAsync(string number, object userState)
	{
		if (number_queryOperationCompleted == null)
		{
			number_queryOperationCompleted = Onnumber_queryOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("number_query", new object[1] { number }, number_queryOperationCompleted, userState);
	}

	private void Onnumber_queryOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.number_queryCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.number_queryCompleted(this, new number_queryCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapRpcMethod("sms_webservice_wsdl#convert_jalali_to_unixtimestamp", RequestNamespace = "sms_webservice_wsdl", ResponseNamespace = "sms_webservice_wsdl")]
	[return: SoapElement("return")]
	public string convert_jalali_to_unixtimestamp(int year, int month, int day, int hour, int minute)
	{
		return (string)((SoapHttpClientProtocol)this).Invoke("convert_jalali_to_unixtimestamp", new object[5] { year, month, day, hour, minute })[0];
	}

	public void convert_jalali_to_unixtimestampAsync(int year, int month, int day, int hour, int minute)
	{
		convert_jalali_to_unixtimestampAsync(year, month, day, hour, minute, null);
	}

	public void convert_jalali_to_unixtimestampAsync(int year, int month, int day, int hour, int minute, object userState)
	{
		if (convert_jalali_to_unixtimestampOperationCompleted == null)
		{
			convert_jalali_to_unixtimestampOperationCompleted = Onconvert_jalali_to_unixtimestampOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("convert_jalali_to_unixtimestamp", new object[5] { year, month, day, hour, minute }, convert_jalali_to_unixtimestampOperationCompleted, userState);
	}

	private void Onconvert_jalali_to_unixtimestampOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.convert_jalali_to_unixtimestampCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.convert_jalali_to_unixtimestampCompleted(this, new convert_jalali_to_unixtimestampCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapRpcMethod("sms_webservice_wsdl#admin_allow_number_new", RequestNamespace = "sms_webservice_wsdl", ResponseNamespace = "sms_webservice_wsdl")]
	[return: SoapElement("return")]
	public array_number_state[] admin_allow_number_new(string username, string password, string[] adminid, string[] number, string[] dargah)
	{
		return (array_number_state[])((SoapHttpClientProtocol)this).Invoke("admin_allow_number_new", new object[5] { username, password, adminid, number, dargah })[0];
	}

	public void admin_allow_number_newAsync(string username, string password, string[] adminid, string[] number, string[] dargah)
	{
		admin_allow_number_newAsync(username, password, adminid, number, dargah, null);
	}

	public void admin_allow_number_newAsync(string username, string password, string[] adminid, string[] number, string[] dargah, object userState)
	{
		if (admin_allow_number_newOperationCompleted == null)
		{
			admin_allow_number_newOperationCompleted = Onadmin_allow_number_newOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("admin_allow_number_new", new object[5] { username, password, adminid, number, dargah }, admin_allow_number_newOperationCompleted, userState);
	}

	private void Onadmin_allow_number_newOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.admin_allow_number_newCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.admin_allow_number_newCompleted(this, new admin_allow_number_newCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	[SoapRpcMethod("sms_webservice_wsdl#admin_get_user_packageid", RequestNamespace = "sms_webservice_wsdl", ResponseNamespace = "sms_webservice_wsdl")]
	[return: SoapElement("return")]
	public array_user_packageid[] admin_get_user_packageid()
	{
		return (array_user_packageid[])((SoapHttpClientProtocol)this).Invoke("admin_get_user_packageid", new object[0])[0];
	}

	public void admin_get_user_packageidAsync()
	{
		admin_get_user_packageidAsync(null);
	}

	public void admin_get_user_packageidAsync(object userState)
	{
		if (admin_get_user_packageidOperationCompleted == null)
		{
			admin_get_user_packageidOperationCompleted = Onadmin_get_user_packageidOperationCompleted;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("admin_get_user_packageid", new object[0], admin_get_user_packageidOperationCompleted, userState);
	}

	private void Onadmin_get_user_packageidOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (this.admin_get_user_packageidCompleted != null)
		{
			InvokeCompletedEventArgs val = (InvokeCompletedEventArgs)arg;
			this.admin_get_user_packageidCompleted(this, new admin_get_user_packageidCompletedEventArgs(val.Results, ((AsyncCompletedEventArgs)val).Error, ((AsyncCompletedEventArgs)val).Cancelled, ((AsyncCompletedEventArgs)val).UserState));
		}
	}

	public void CancelAsync(object userState)
	{
		((HttpWebClientProtocol)this).CancelAsync(userState);
	}

	private bool IsLocalFileSystemWebService(string url)
	{
		if (url == null || url == string.Empty)
		{
			return false;
		}
		Uri uri = new Uri(url);
		if (uri.Port >= 1024 && string.Compare(uri.Host, "localHost", StringComparison.OrdinalIgnoreCase) == 0)
		{
			return true;
		}
		return false;
	}
}
