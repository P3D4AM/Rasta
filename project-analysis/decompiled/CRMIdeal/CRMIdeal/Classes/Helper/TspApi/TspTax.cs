using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Web.Script.Serialization;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes.Common;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Newtonsoft.Json;

namespace CRMIdeal.Classes.Helper.TspApi;

public class TspTax
{
	public static string _MainUrl = "https://tp.tax.gov.ir/req/";

	public static string _GetTokenUrl = "api/self-tsp/sync/GET_TOKEN";

	public static string _SendInvoice = "api/self-tsp/async/normal-enqueue";

	public static string _InquiryInvoice = "api/self-tsp/sync/INQUIRY_BY_REFERENCE_NUMBER";

	public static string _TspToken = "";

	public static long _TspExpiresIn = 0L;

	public static string _TspTokenErrMessage = "";

	public static int TspSettingId { get; set; }

	public static string _TspTaxId { get; set; }

	public static string TspTaxId
	{
		get
		{
			try
			{
				if (string.IsNullOrWhiteSpace(_TspTaxId))
				{
					TSPspSelectSettingById_Result tspSetting = GetTspSetting(TspSettingId);
					if (tspSetting != null)
					{
						_TspTaxId = tspSetting.TspIdentify ?? "";
					}
					else
					{
						_TspTaxId = "";
					}
				}
				return _TspTaxId;
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				return "";
			}
		}
	}

	public static string _TspPrivateKey { get; set; }

	public static string TspPrivateKey
	{
		get
		{
			try
			{
				if (string.IsNullOrWhiteSpace(_TspPrivateKey))
				{
					TSPspSelectSettingById_Result tspSetting = GetTspSetting(TspSettingId);
					if (tspSetting != null)
					{
						_TspPrivateKey = tspSetting.TspPrivateKey ?? "";
					}
					else
					{
						_TspPrivateKey = "";
					}
				}
				return _TspPrivateKey;
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				return "";
			}
		}
	}

	public static string _TspPublicKey { get; set; }

	public static string TspPublicKey
	{
		get
		{
			try
			{
				if (string.IsNullOrWhiteSpace(_TspPublicKey) && GetTspSetting(TspSettingId) == null)
				{
					_TspPublicKey = "";
				}
				return _TspPublicKey;
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				return "";
			}
		}
	}

	public static string _TspPublicKeyIdentify { get; set; }

	public static string TspPublicKeyIdentify
	{
		get
		{
			try
			{
				if (string.IsNullOrWhiteSpace(_TspPublicKeyIdentify) && GetTspSetting(TspSettingId) == null)
				{
					_TspPublicKeyIdentify = "";
				}
				return _TspPublicKeyIdentify;
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				return "";
			}
		}
	}

	public static string _TspEconomic { get; set; }

	public static string TspEconomic
	{
		get
		{
			try
			{
				CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
				if (SysSeting.Get() != null)
				{
					_TspEconomic = cRMspSelectCrmsysSetting_Result.EconomicCode ?? "";
					_TspEconomic = "10320871920";
				}
				return _TspEconomic;
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				return "";
			}
		}
	}

	public static int GetTspSettingId(int tspSettingId)
	{
		try
		{
			if (TspSettingId == 0 || TspSettingId != tspSettingId)
			{
				_TspToken = "";
				_TspTaxId = "";
				_TspPrivateKey = "";
				_TspPublicKey = "";
				_TspPublicKeyIdentify = "";
				TSPspSelectSettingById_Result tspSetting = GetTspSetting(tspSettingId);
				if (tspSetting != null)
				{
					TspSettingId = tspSetting.TspSettingId;
				}
				else
				{
					TspSettingId = 0;
				}
			}
			return TspSettingId;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return 0;
		}
	}

	public static TSPspSelectSettingById_Result GetTspSetting(int tspSettingId)
	{
		TSPspSelectSettingById_Result result = new TSPspSelectSettingById_Result();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		if (result2 <= 0)
		{
			result2 = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CRMSpIEntities cRMSpIEntities = new CRMSpIEntities();
		try
		{
			result = Enumerable.FirstOrDefault<TSPspSelectSettingById_Result>((IEnumerable<TSPspSelectSettingById_Result>)cRMSpIEntities.TSPspSelectSettingById(tspSettingId, lCID, result2));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpIEntities.Dispose();
		}
		return result;
	}

	public static CommonResultViewModel<TSPTokenResult> GetToken()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		TSPTokenResult data = new TSPTokenResult();
		string text = "";
		CommonResultStatusViewModel commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		try
		{
			_TspToken = "";
			_TspExpiresIn = 0L;
			_TspTokenErrMessage = "";
			DateTime now = DateTime.Now;
			now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(Financial.Get().Id.ToString());
			short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			_ = UserLogin.CurrentUser.UserId;
			long ticks = now.Ticks;
			string text2 = "";
			long num = 0L;
			if (!string.IsNullOrWhiteSpace(TspTaxId) && !string.IsNullOrWhiteSpace(TspPrivateKey))
			{
				string text3 = ticks.ToString();
				string value = text3;
				HttpClient httpClient = new HttpClient();
				httpClient.BaseAddress = new Uri(_MainUrl);
				httpClient.DefaultRequestHeaders.Add("requestTraceId", value);
				httpClient.DefaultRequestHeaders.Add("timestamp", text3);
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				TSPTokenRequest tSPTokenRequest = new TSPTokenRequest
				{
					username = TspTaxId
				};
				JsonConvert.SerializeObject(tSPTokenRequest);
				TSPPacket<TSPTokenRequest> tSPPacket = new TSPPacket<TSPTokenRequest>
				{
					uid = null,
					packetType = "GET_TOKEN",
					retry = false,
					data = tSPTokenRequest,
					encryptionKeyId = "",
					symmetrickey = "",
					iv = "",
					fiscalId = "",
					dataSignature = ""
				};
				string signature = SigntureData.SignData(CryptoUtils.NormalJson(tSPPacket, new Dictionary<string, string>
				{
					{ "requestTraceId", value },
					{ "timestamp", text3 }
				}), TspPrivateKey);
				TSPBodyRequest<TSPTokenRequest> value2 = new TSPBodyRequest<TSPTokenRequest>
				{
					packet = tSPPacket,
					signature = signature,
					signatureKeyId = null
				};
				string getTokenUrl = _GetTokenUrl;
				HttpContent content = new StringContent(JsonConvert.SerializeObject(value2), Encoding.UTF8, "application/json");
				HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
				httpResponseMessage = httpClient.PostAsync(getTokenUrl, content).Result;
				if (httpResponseMessage.IsSuccessStatusCode)
				{
					TSPResultRequest<TSPTokenResult> tSPResultRequest = JsonConvert.DeserializeObject<TSPResultRequest<TSPTokenResult>>(httpResponseMessage.Content.ReadAsStringAsync().Result);
					if (tSPResultRequest != null && tSPResultRequest.result != null && tSPResultRequest.result.data != null && !string.IsNullOrWhiteSpace(tSPResultRequest.result.data.token))
					{
						text2 = tSPResultRequest.result.data.token;
						num = tSPResultRequest.result.data.expiresIn.GetValueOrDefault();
					}
				}
				else
				{
					TSPResultRequest<TSPTokenResult> tSPResultRequest2 = JsonConvert.DeserializeObject<TSPResultRequest<TSPTokenResult>>(httpResponseMessage.Content.ReadAsStringAsync().Result);
					if (tSPResultRequest2 != null && tSPResultRequest2.errors != null && tSPResultRequest2.errors[0] != null)
					{
						text = ((!string.IsNullOrWhiteSpace(tSPResultRequest2.errors[0].detail)) ? tSPResultRequest2.errors[0].detail : (string.IsNullOrWhiteSpace(tSPResultRequest2.errors[0].errorDetail) ? Messages.msgErrorReceivingToken : tSPResultRequest2.errors[0].errorDetail));
						text = text + " <br>" + tSPResultRequest2.errors[0].errorCode;
					}
				}
			}
			else
			{
				data = null;
				commonResultStatusViewModel = CommonResultStatusViewModel.Error;
				text = Messages.errorInReadingSetting;
			}
			if (!string.IsNullOrWhiteSpace(text))
			{
				data = null;
				return new CommonResultViewModel<TSPTokenResult>
				{
					Data = data,
					Message = text,
					Status = CommonResultStatusViewModel.Error
				};
			}
			if (!string.IsNullOrWhiteSpace(text2))
			{
				data = new TSPTokenResult
				{
					token = text2,
					expiresIn = num
				};
				_TspToken = text2;
				_TspExpiresIn = num;
				text = "";
				commonResultStatusViewModel = CommonResultStatusViewModel.Success;
			}
			else
			{
				text = Messages.msgErrorReceivingToken;
				commonResultStatusViewModel = CommonResultStatusViewModel.Error;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			data = null;
			return new CommonResultViewModel<TSPTokenResult>
			{
				Data = data,
				Message = Messages.msgErrorRunFunction,
				Status = CommonResultStatusViewModel.Error
			};
		}
		return new CommonResultViewModel<TSPTokenResult>
		{
			Data = data,
			Message = text,
			Status = commonResultStatusViewModel
		};
	}

	public static bool CheckToken()
	{
		bool result = true;
		_TspTokenErrMessage = "";
		bool flag = false;
		DateTime now = DateTime.Now;
		if (string.IsNullOrWhiteSpace(_TspToken) || _TspExpiresIn == 0L)
		{
			flag = true;
		}
		else if (_TspExpiresIn != 0L)
		{
			_ = _TspExpiresIn;
			if (new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(_TspExpiresIn).ToLocalTime() <= now.AddMinutes(5.0))
			{
				flag = true;
			}
		}
		if (flag)
		{
			CommonResultViewModel<TSPTokenResult> token = GetToken();
			if (token == null)
			{
				_TspTokenErrMessage = Messages.msgErrorReceivingToken;
				return false;
			}
			if (token.Status == CommonResultStatusViewModel.Error || token.Status == CommonResultStatusViewModel.Fail)
			{
				if (!string.IsNullOrWhiteSpace(token.Message))
				{
					_TspTokenErrMessage = token.Message;
					return false;
				}
				_TspTokenErrMessage = Messages.msgErrorReceivingToken;
				return false;
			}
		}
		return result;
	}

	public static CommonResultViewModel<TSPInvoiceInfo> GetInvoiceIdentify(DateTime tspOrdSendDate, int ordId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		TSPInvoiceInfo data = new TSPInvoiceInfo();
		string text = "";
		CommonResultStatusViewModel status = CommonResultStatusViewModel.Success;
		CRMSpIEntities cRMSpIEntities = new CRMSpIEntities();
		try
		{
			DateTime now = DateTime.Now;
			now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(Financial.Get().Id.ToString());
			short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			_ = UserLogin.CurrentUser.UserId;
			_ = now.Ticks;
			string text2 = "";
			string tspOrdInno = "";
			if (!string.IsNullOrWhiteSpace(TspTaxId))
			{
				string tspTaxId = TspTaxId;
				string text3 = "";
				Encoding uTF = Encoding.UTF8;
				if (!string.IsNullOrWhiteSpace(tspTaxId))
				{
					for (int i = 0; i < tspTaxId.Length; i++)
					{
						if (!char.IsDigit(tspTaxId, i))
						{
							byte[] bytes = uTF.GetBytes(tspTaxId[i].ToString());
							if (bytes != null)
							{
								text3 += bytes[0];
							}
						}
						else
						{
							text3 += tspTaxId[i];
						}
					}
				}
				DateTime value = new DateTime(1970, 1, 1);
				DateTime dateTime = tspOrdSendDate;
				int num = (int)dateTime.Subtract(value).TotalDays;
				string text4 = num.ToString();
				string text5 = num.ToString("X2");
				if (text5.Length == 4)
				{
					text5 = "0" + text5;
				}
				if (text4.Length < 5)
				{
					int num2 = 5 - text4.Length;
					for (int j = 0; j < num2; j++)
					{
						text4 = "0" + text4;
					}
				}
				string text6 = "";
				string text7 = "";
				TSPspReturnOrderInno_Result tSPspReturnOrderInno_Result = Enumerable.FirstOrDefault<TSPspReturnOrderInno_Result>((IEnumerable<TSPspReturnOrderInno_Result>)cRMSpIEntities.TSPspReturnOrderInno(ordId));
				if (tSPspReturnOrderInno_Result != null)
				{
					text6 = tSPspReturnOrderInno_Result.TspOrdInno ?? "";
					text7 = tSPspReturnOrderInno_Result.TspOrdInnoDecimal ?? "";
				}
				if (string.IsNullOrWhiteSpace(text6))
				{
					text = Messages.msgErrorCreateTspOrdInno;
				}
				if (text6.Length < 10)
				{
					int num3 = 10 - text6.Length;
					for (int k = 0; k < num3; k++)
					{
						text6 = "0" + text6;
					}
				}
				if (text7.Length < 10)
				{
					int num4 = 10 - text7.Length;
					for (int l = 0; l < num4; l++)
					{
						text7 = "0" + text7;
					}
				}
				tspOrdInno = text6;
				string text8 = VerhoeffAlgorithm.CheckSum(text3 + text4 + text7).ToString();
				text2 = tspTaxId + text5 + text6 + text8;
			}
			else
			{
				text = Messages.errorInReadingSetting;
			}
			if (!string.IsNullOrWhiteSpace(text))
			{
				data = null;
				return new CommonResultViewModel<TSPInvoiceInfo>
				{
					Data = data,
					Message = text,
					Status = CommonResultStatusViewModel.Error
				};
			}
			if (!string.IsNullOrWhiteSpace(text2))
			{
				data = new TSPInvoiceInfo
				{
					TspOrdIdentify = text2,
					TspOrdInno = tspOrdInno
				};
				text = "";
				status = CommonResultStatusViewModel.Success;
			}
			else
			{
				text = Messages.msgErrorCreateOrdTaxId;
				status = CommonResultStatusViewModel.Error;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			data = null;
			return new CommonResultViewModel<TSPInvoiceInfo>
			{
				Data = data,
				Message = Messages.msgErrorRunFunction,
				Status = CommonResultStatusViewModel.Error
			};
		}
		finally
		{
			cRMSpIEntities.Dispose();
		}
		return new CommonResultViewModel<TSPInvoiceInfo>
		{
			Data = data,
			Message = text,
			Status = status
		};
	}

	public static string CreateTspOrdMessage(string tspOrdMessage, string errorCode, string errorDetail, bool isError)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		string result = "";
		try
		{
			DateTime now = DateTime.Now;
			string msgDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			List<TspOrdMessageViewModel> list = new List<TspOrdMessageViewModel>();
			if (!string.IsNullOrWhiteSpace(tspOrdMessage))
			{
				list = new JavaScriptSerializer().Deserialize<List<TspOrdMessageViewModel>>(tspOrdMessage);
			}
			if (list == null)
			{
				list = new List<TspOrdMessageViewModel>();
			}
			TspOrdMessageViewModel item = new TspOrdMessageViewModel
			{
				ErrorCode = errorCode,
				Message = errorDetail,
				IsError = isError,
				MsgDate = now,
				MsgDatePersian = msgDatePersian
			};
			list.Add(item);
			if (list != null)
			{
				tspOrdMessage = JsonConvert.SerializeObject(Enumerable.ToList<TspOrdMessageViewModel>((IEnumerable<TspOrdMessageViewModel>)list));
			}
			result = tspOrdMessage;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public static void UpdateOrder(int ordId, string tspOrdIdentify, string tspOrdInno, int? tspOrdIns, DateTime? tspOrdSendDate, string tspOrdSendDatePersian, DateTime? tspOrdLastEditDate, string tspOrdLastEditDatePersian, string tspOrdUID, string tspOrdReferenceNumber, string tspOrdStatus, string tspOrdMessage)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		CRMSpIEntities cRMSpIEntities = new CRMSpIEntities();
		try
		{
			DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(Financial.Get().Id.ToString());
			short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			_ = UserLogin.CurrentUser.UserId;
			if (ordId != 0)
			{
				cRMSpIEntities.TSPspUpdateOrder(ordId, tspOrdIdentify, tspOrdInno, tspOrdIns, tspOrdSendDate, tspOrdSendDatePersian, tspOrdLastEditDate, tspOrdLastEditDatePersian, tspOrdUID, tspOrdReferenceNumber, tspOrdStatus, tspOrdMessage, appType, null, null);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpIEntities.Dispose();
		}
	}

	public static CommonResultViewModel<int> SendOrder(int ordId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		int data = 0;
		string message = "";
		CommonResultStatusViewModel status = CommonResultStatusViewModel.Success;
		return new CommonResultViewModel<int>
		{
			Data = data,
			Message = message,
			Status = status
		};
	}

	public static CommonResultViewModel<int> InquiryOrder(int ordId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int data = 0;
		string text = "";
		CommonResultStatusViewModel status = CommonResultStatusViewModel.Success;
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		CRMSpIEntities cRMSpIEntities = new CRMSpIEntities();
		try
		{
			DateTime now = DateTime.Now;
			string tspOrdLastEditDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(Financial.Get().Id.ToString());
			short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			_ = UserLogin.CurrentUser.UserId;
			long ticks = now.Ticks;
			if (ordId != 0)
			{
				int num = 0;
				TSPspSelectOrderById_Result tSPspSelectOrderById_Result = Enumerable.FirstOrDefault<TSPspSelectOrderById_Result>((IEnumerable<TSPspSelectOrderById_Result>)cRMSpIEntities.TSPspSelectOrderById(ordId, lCID, result));
				if (tSPspSelectOrderById_Result != null)
				{
					int result2 = 0;
					int.TryParse(tSPspSelectOrderById_Result.ordTspSettingId.ToString(), out result2);
					if (result2 != 0)
					{
						if (TspSettingId != result2)
						{
							GetTspSettingId(result2);
						}
						if (CheckToken())
						{
							if (tSPspSelectOrderById_Result != null)
							{
								string.Format(Labels.lbItemByNumber, tSPspSelectOrderById_Result.OrderOpr ?? Labels.lblOrd, tSPspSelectOrderById_Result.ordNumber.ToString());
								string tspOrdReferenceNumber = tSPspSelectOrderById_Result.TspOrdReferenceNumber;
								if (string.IsNullOrWhiteSpace(tspOrdReferenceNumber))
								{
									num++;
									text = text + string.Format(Messages.msgErrorItemNoValue, Labels.TspTransferListOrdReferenceNumber) + "<br>";
								}
								if (num == 0)
								{
									string text2 = ticks.ToString();
									string value = text2;
									HttpClient httpClient = new HttpClient();
									httpClient.BaseAddress = new Uri(_MainUrl);
									string value2 = "Bearer " + _TspToken;
									httpClient.DefaultRequestHeaders.Add("Authorization", value2);
									httpClient.DefaultRequestHeaders.Add("requestTraceId", value);
									httpClient.DefaultRequestHeaders.Add("timestamp", text2);
									httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
									string[] referenceNumber = new string[1] { tspOrdReferenceNumber };
									TSPInquiryRefNumRequest data2 = new TSPInquiryRefNumRequest
									{
										referenceNumber = referenceNumber
									};
									TSPPacket<TSPInquiryRefNumRequest> tSPPacket = new TSPPacket<TSPInquiryRefNumRequest>
									{
										uid = null,
										packetType = "INQUIRY_BY_REFERENCE_NUMBER",
										retry = false,
										data = data2,
										encryptionKeyId = "",
										symmetrickey = "",
										iv = "",
										fiscalId = "",
										dataSignature = ""
									};
									Dictionary<string, string> dictionary = new Dictionary<string, string>();
									httpClient.DefaultRequestHeaders.Add("Authorization", value2);
									dictionary.Add("requestTraceId", value);
									dictionary.Add("timestamp", text2);
									string signature = SigntureData.SignData(CryptoUtils.NormalJson(tSPPacket, dictionary), TspPrivateKey);
									TSPBodyRequest<TSPInquiryRefNumRequest> value3 = new TSPBodyRequest<TSPInquiryRefNumRequest>
									{
										packet = tSPPacket,
										signature = signature,
										signatureKeyId = null
									};
									string inquiryInvoice = _InquiryInvoice;
									HttpContent content = new StringContent(JsonConvert.SerializeObject(value3), Encoding.UTF8, "application/json");
									HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
									httpResponseMessage = httpClient.PostAsync(inquiryInvoice, content).Result;
									if (httpResponseMessage.IsSuccessStatusCode)
									{
										TSPResultRequest<List<TSPInquiryRefNumResult>> tSPResultRequest = JsonConvert.DeserializeObject<TSPResultRequest<List<TSPInquiryRefNumResult>>>(httpResponseMessage.Content.ReadAsStringAsync().Result);
										if (tSPResultRequest != null && tSPResultRequest.result != null && tSPResultRequest.result.data != null)
										{
											string text3 = "";
											string tspOrdMessage = "";
											if (tSPResultRequest.result.data[0] != null)
											{
												text3 = tSPResultRequest.result.data[0].status ?? "";
											}
											_ = tSPResultRequest.result.uid;
											_ = tSPResultRequest.result.referenceNumber;
											_ = tSPResultRequest.result.errorCode;
											_ = tSPResultRequest.result.errorDetail;
											if (string.IsNullOrWhiteSpace(text3))
											{
												text3 = null;
												tspOrdMessage = CreateTspOrdMessage(tSPspSelectOrderById_Result.TspOrdMessage, "", Messages.ErrorInformation, isError: true);
											}
											else if (!string.IsNullOrWhiteSpace(text3))
											{
												tspOrdMessage = CreateTspOrdMessage(tSPspSelectOrderById_Result.TspOrdMessage, "", Messages.msgTspInquirySuccess, isError: false);
											}
											UpdateOrder(tSPspSelectOrderById_Result.OrderID, null, null, null, null, null, now, tspOrdLastEditDatePersian, null, null, text3, tspOrdMessage);
										}
									}
									else
									{
										TSPResultRequest<TSPInvoiceResult> tSPResultRequest2 = JsonConvert.DeserializeObject<TSPResultRequest<TSPInvoiceResult>>(httpResponseMessage.Content.ReadAsStringAsync().Result);
										if (tSPResultRequest2 != null)
										{
											if (tSPResultRequest2.errors != null)
											{
												if (tSPResultRequest2.errors[0] != null)
												{
													text = ((!string.IsNullOrWhiteSpace(tSPResultRequest2.errors[0].detail)) ? tSPResultRequest2.errors[0].detail : (string.IsNullOrWhiteSpace(tSPResultRequest2.errors[0].errorDetail) ? Messages.msgErrorReceivingToken : tSPResultRequest2.errors[0].errorDetail));
													string tspOrdMessage2 = CreateTspOrdMessage(tSPspSelectOrderById_Result.TspOrdMessage, tSPResultRequest2.errors[0].errorCode ?? "-100", text, isError: true);
													text = text + " <br>" + tSPResultRequest2.errors[0].errorCode;
													cRMSpIEntities.TSPspUpdateOrder(tSPspSelectOrderById_Result.OrderID, null, null, null, null, null, null, null, null, null, null, tspOrdMessage2, appType, null, null);
												}
											}
											else if (tSPResultRequest2.result != null)
											{
												text = ((!string.IsNullOrWhiteSpace(tSPResultRequest2.result.data.detail)) ? tSPResultRequest2.result.data.detail : (string.IsNullOrWhiteSpace(tSPResultRequest2.result.data.msg) ? Messages.msgErrorRunFunction : tSPResultRequest2.result.data.msg));
												string tspOrdMessage3 = CreateTspOrdMessage(tSPspSelectOrderById_Result.TspOrdMessage, tSPResultRequest2.result.data.code ?? "-100", text, isError: true);
												text = text + " <br>" + tSPResultRequest2.result.data.code;
												cRMSpIEntities.TSPspUpdateOrder(tSPspSelectOrderById_Result.OrderID, null, null, null, null, null, null, null, null, null, null, tspOrdMessage3, appType, null, null);
											}
											else if (tSPResultRequest2.error != null)
											{
												text = ((!string.IsNullOrWhiteSpace(tSPResultRequest2.error.detail)) ? tSPResultRequest2.error.detail : (string.IsNullOrWhiteSpace(tSPResultRequest2.error.msg) ? Messages.msgErrorRunFunction : tSPResultRequest2.error.msg));
												string tspOrdMessage4 = CreateTspOrdMessage(tSPspSelectOrderById_Result.TspOrdMessage, tSPResultRequest2.error.code ?? "-100", text, isError: true);
												text = text + " <br>" + tSPResultRequest2.error.code;
												cRMSpIEntities.TSPspUpdateOrder(tSPspSelectOrderById_Result.OrderID, null, null, null, null, null, null, null, null, null, null, tspOrdMessage4, appType, null, null);
											}
										}
										else
										{
											text = Messages.msgErrorRunFunction;
										}
									}
								}
							}
							else
							{
								text = Messages.ErrorNotFound;
							}
						}
						else if (!string.IsNullOrWhiteSpace(_TspTokenErrMessage))
						{
							text = _TspTokenErrMessage + " <br> (GetToken)";
							num++;
						}
						else
						{
							text = Messages.msgErrorReceivingToken;
							num++;
						}
					}
					else
					{
						text = Messages.errorInReadingSetting;
					}
				}
				else
				{
					text = Messages.ErrorNotFound;
				}
			}
			else
			{
				text = Messages.ErrorNotFound;
			}
			if (!string.IsNullOrWhiteSpace(text))
			{
				data = 0;
				return new CommonResultViewModel<int>
				{
					Data = data,
					Message = text,
					Status = CommonResultStatusViewModel.Error
				};
			}
			data = 1;
			text = "";
			status = CommonResultStatusViewModel.Success;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			data = 0;
			return new CommonResultViewModel<int>
			{
				Data = data,
				Message = Messages.msgErrorRunFunction,
				Status = CommonResultStatusViewModel.Error
			};
		}
		finally
		{
			cRMSpEntities.Dispose();
			cRMSpIEntities.Dispose();
		}
		return new CommonResultViewModel<int>
		{
			Data = data,
			Message = text,
			Status = status
		};
	}
}
