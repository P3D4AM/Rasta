using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using Newtonsoft.Json;

namespace CRMIdeal.Classes.Common;

public class PcPos
{
	public class TokenResponseData
	{
		public string access_token { get; set; }

		public int expires_in { get; set; }

		public string token_type { get; set; }
	}

	public class PCPOS_SettingJs
	{
		public string TokenUrl { get; set; }

		public string IdentifierUrl { get; set; }

		public string PayUrl { get; set; }

		public string Username { get; set; }

		public string Password { get; set; }
	}

	public class IdentifierResponseData
	{
		public bool IsSuccess { get; set; }

		public int ErrorCode { get; set; }

		public string ErrorDescription { get; set; }

		public IdentifierDataObj Data { get; set; }
	}

	public class IdentifierDataObj
	{
		public string Identifier { get; set; }
	}

	public class StartPaymentResponseData
	{
		public bool IsSuccess { get; set; }

		public int ErrorCode { get; set; }

		public string ErrorDescription { get; set; }

		public StartPaymentDataObj Data { get; set; }
	}

	public class StartPaymentDataObj
	{
		public string TerminalID { get; set; }

		public string Amount { get; set; }

		public int AccountType { get; set; }

		public string Additional { get; set; }

		public string ResNum { get; set; }

		public string Identifier { get; set; }

		public string TotalAmount { get; set; }

		public UserNotifiable userNotifiable { get; set; }

		public TransactionType TransactionType { get; set; }

		public string BillID { get; set; }

		public string PayID { get; set; }

		public string PurchaseID { get; set; }

		public string RefrenceData { get; set; }

		public string Amount_Iban { get; set; }

		public string PurchaseID_Amount_Iban { get; set; }
	}

	public class UserNotifiable
	{
		public string FooterMessage { get; set; }

		public List<PrintItem> PrintItem { get; set; }
	}

	public class PrintItem
	{
		public string Item { get; set; }

		public string Value { get; set; }

		public Alignment Alignment { get; set; }

		public ReceiptType ReceiptType { get; set; }

		public PrintItem(string item, string value, Alignment alignment, ReceiptType receiptType)
		{
			Item = item;
			Value = value;
			Alignment = alignment;
			ReceiptType = receiptType;
		}

		public PrintItem()
		{
		}
	}

	public enum ReceiptType
	{
		Customer,
		Merchant,
		Both
	}

	public enum TransactionType
	{
		Purchase,
		Bill,
		PurchaseID
	}

	public enum Alignment
	{
		Right,
		Left,
		Center
	}

	public class StartPaymentResponseResult
	{
		public bool IsSuccess { get; set; }

		public int ErrorCode { get; set; }

		public string ErrorDescription { get; set; }

		public StartPaymentResult Data { get; set; }
	}

	public class StartPaymentResult
	{
		public string Identifier { get; set; }

		public string TerminalID { get; set; }

		public string TransactionType { get; set; }

		public string AccountType { get; set; }

		public DateTime CreateOn { get; set; }

		public string CreateBy { get; set; }

		public string ResponseCode { get; set; }

		public string ResponseDescription { get; set; }

		public string TraceNumber { get; set; }

		public string ResNum { get; set; }

		public string RRN { get; set; }

		public int State { get; set; }

		public string StateDescription { get; set; }

		public string Amount { get; set; }

		public string AffectiveAmount { get; set; }

		public string PosAppVersion { get; set; }

		public string PosProtocolVersion { get; set; }

		public string CardHashNumber { get; set; }

		public string CardMaskNumber { get; set; }
	}

	private static string KEY_Token = "Token";

	private static string KEY_Identifier = "Identifier";

	private static string KEY_Payment = "Payment";

	private static string KEY_Verify = "Verify";

	private static string KEY_Cancel = "Cancel";

	public static WSspSelectOrderPaymentTypesById_Result GetPayType(int id = 0)
	{
		WSspSelectOrderPaymentTypesById_Result wSspSelectOrderPaymentTypesById_Result = new WSspSelectOrderPaymentTypesById_Result();
		CRMSpIEntities cRMSpIEntities = new CRMSpIEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (id != 0)
			{
				WSspSelectOrderPaymentTypesById_Result wSspSelectOrderPaymentTypesById_Result2 = Enumerable.FirstOrDefault<WSspSelectOrderPaymentTypesById_Result>((IEnumerable<WSspSelectOrderPaymentTypesById_Result>)cRMSpIEntities.WSspSelectOrderPaymentTypesById(id, lCID, result));
				if (wSspSelectOrderPaymentTypesById_Result2 != null)
				{
					wSspSelectOrderPaymentTypesById_Result = wSspSelectOrderPaymentTypesById_Result2;
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		finally
		{
			cRMSpIEntities.Dispose();
		}
		wSspSelectOrderPaymentTypesById_Result.ordPayTypePosPassword = ((!string.IsNullOrEmpty(wSspSelectOrderPaymentTypesById_Result.ordPayTypePosPassword)) ? XorCipher.DecryptByPrivateKey(wSspSelectOrderPaymentTypesById_Result.ordPayTypePosPassword) : null);
		return wSspSelectOrderPaymentTypesById_Result;
	}

	public static SelectListItem GetUrl(int payTypeId = 0, string key = "")
	{
		SelectListItem result = new SelectListItem();
		WSspSelectOrderPaymentTypesById_Result payType = GetPayType(payTypeId);
		if (payType != null && !string.IsNullOrWhiteSpace(payType.ordPayTypePosURL))
		{
			List<SelectListItem> list = JsonConvert.DeserializeObject<List<SelectListItem>>(payType.ordPayTypePosURL);
			if (!string.IsNullOrWhiteSpace(key))
			{
				SelectListItem selectListItem = Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == key));
				if (selectListItem != null)
				{
					result = selectListItem;
				}
			}
		}
		return result;
	}

	public static async Task<CommonSelectListItemViewModel> GetToken(int payTypeId = 0)
	{
		string _Token = "";
		string msgError = "";
		try
		{
			WSspSelectOrderPaymentTypesById_Result payType = GetPayType(payTypeId);
			if (payType == null)
			{
				msgError = Messages.msgErrorNotFoundedPayType;
			}
			if (string.IsNullOrWhiteSpace(payType.ordPayTypePosURL))
			{
				msgError = string.Format(Messages.ErrorEmpty, "URL");
			}
			string value = GetUrl(payTypeId, KEY_Token).Value;
			if (string.IsNullOrWhiteSpace(value))
			{
				msgError = string.Format(Messages.ErrorEmpty, KEY_Token + " URL");
			}
			if (msgError == "")
			{
				HttpClient httpClient = new HttpClient();
				HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, value);
				httpRequestMessage.Headers.Add("Authorization", "Basic cm9jbGllbnQ6c2VjcmV0");
				StringContent content = new StringContent("grant_type=password&username=" + payType.ordPayTypePosUserName + "&password=" + XorCipher.DecryptByPrivateKey(payType.ordPayTypePosPassword) + "&scope=SepCentralPcPos openid", null, "application/x-www-form-urlencoded");
				httpRequestMessage.Content = content;
				HttpResponseMessage obj = await httpClient.SendAsync(httpRequestMessage);
				obj.EnsureSuccessStatusCode();
				string value2 = await obj.Content.ReadAsStringAsync();
				if (string.IsNullOrWhiteSpace(value2))
				{
					msgError = Messages.msgErrorEmptyResultFromServer;
				}
				else
				{
					TokenResponseData tokenResponseData = JsonConvert.DeserializeObject<TokenResponseData>(value2);
					if (string.IsNullOrWhiteSpace(tokenResponseData.access_token))
					{
						msgError = Messages.msgErrorEmptyResultFromServer;
					}
					else
					{
						_Token = tokenResponseData.access_token;
					}
				}
			}
		}
		catch (Exception)
		{
		}
		return new CommonSelectListItemViewModel
		{
			Message = msgError,
			Value = _Token
		};
	}

	public static async Task<CommonSelectListItemViewModel> GetIdentifier(string token = "", int payTypeId = 0)
	{
		string _Identifier = "";
		string msgError = "";
		try
		{
			WSspSelectOrderPaymentTypesById_Result payType = GetPayType(payTypeId);
			if (payType == null)
			{
				msgError = Messages.msgErrorNotFoundedPayType;
			}
			if (string.IsNullOrWhiteSpace(payType.ordPayTypePosURL))
			{
				msgError = string.Format(Messages.ErrorEmpty, "URL");
			}
			string value = GetUrl(payTypeId, KEY_Identifier).Value;
			if (string.IsNullOrWhiteSpace(value))
			{
				msgError = string.Format(Messages.ErrorEmpty, KEY_Identifier + " URL");
			}
			if (msgError == "")
			{
				HttpClient httpClient = new HttpClient();
				HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, value)
				{
					Headers = 
					{
						{
							"Authorization",
							"bearer " + token
						},
						{ "Cookie", "SEP013d8551=017cb00b0020ae656bcff1c3af0dae7298df1d74023413574bef386a3309b8c6a7f1b34c9cdb0d78f338f10650849add5b28adddde" }
					}
				};
				StringContent content = new StringContent("", null, "application/json");
				httpRequestMessage.Content = content;
				HttpResponseMessage obj = await httpClient.SendAsync(httpRequestMessage);
				obj.EnsureSuccessStatusCode();
				string value2 = await obj.Content.ReadAsStringAsync();
				if (string.IsNullOrWhiteSpace(value2))
				{
					msgError = Messages.msgErrorEmptyResultFromServer;
				}
				IdentifierResponseData identifierResponseData = JsonConvert.DeserializeObject<IdentifierResponseData>(value2);
				if (!identifierResponseData.IsSuccess)
				{
					msgError = identifierResponseData.ErrorDescription;
				}
				else
				{
					_Identifier = identifierResponseData.Data.Identifier;
				}
			}
		}
		catch (Exception ex)
		{
			msgError = ex.Message;
		}
		return new CommonSelectListItemViewModel
		{
			Message = msgError,
			Value = _Identifier
		};
	}

	public static async Task<CommonSelectListItemViewModel> SendPaymentRequest(string token = "", string identifier = "", string objId = "", int payTypeId = 0, string itemsJs = "", string selectedPrdJs = "", string totalPrice = "")
	{
		string _SendPaymentResponse = "";
		string msgError = "";
		CRMSpIEntities _dbI = new CRMSpIEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (string.IsNullOrWhiteSpace(token))
			{
				msgError = string.Format(Messages.ErrorEmpty, KEY_Token + " URL");
			}
			if (string.IsNullOrWhiteSpace(identifier))
			{
				msgError = string.Format(Messages.ErrorEmpty, KEY_Identifier + " URL");
			}
			WSspSelectOrderPaymentTypesById_Result payType = GetPayType(payTypeId);
			if (payType == null)
			{
				msgError = Messages.msgErrorNotFoundedPayType;
			}
			if (payType.ordPayTypePosTerminal == "")
			{
				msgError = string.Format(Messages.ErrorEmpty, "Terminal");
			}
			if (string.IsNullOrWhiteSpace(payType.ordPayTypePosURL))
			{
				msgError = string.Format(Messages.ErrorEmpty, "URL");
			}
			string value = GetUrl(payTypeId, KEY_Payment).Value;
			if (string.IsNullOrWhiteSpace(value))
			{
				msgError = string.Format(Messages.ErrorEmpty, KEY_Payment + " URL");
			}
			if (!string.IsNullOrWhiteSpace(selectedPrdJs))
			{
				string text = "";
				List<CommonSelectListItemViewModel> list = JsonConvert.DeserializeObject<List<CommonSelectListItemViewModel>>(selectedPrdJs);
				if (list != null)
				{
					foreach (CommonSelectListItemViewModel item in list)
					{
						if (text != "")
						{
							text += ",";
						}
						text += item.Id;
					}
				}
				List<WSspSelectProductsWithIds_Result> Prds = Enumerable.ToList<WSspSelectProductsWithIds_Result>((IEnumerable<WSspSelectProductsWithIds_Result>)_dbI.WSspSelectProductsWithIds(text, ",", lCID, result));
				if (Prds != null)
				{
					string text2 = "{\"Item\":\"{0}\",\r\n\"Value\":\"{1}\",\r\n\"Alignment\":0,\r\n\"ReceiptType\":2}";
					decimal result2 = default(decimal);
					if (Enumerable.FirstOrDefault<CommonSelectListItemViewModel>((IEnumerable<CommonSelectListItemViewModel>)list, (Func<CommonSelectListItemViewModel, bool>)((CommonSelectListItemViewModel x) => x.Id == Prds[0].ProductID)) != null)
					{
						decimal.TryParse(Enumerable.FirstOrDefault<CommonSelectListItemViewModel>((IEnumerable<CommonSelectListItemViewModel>)list, (Func<CommonSelectListItemViewModel, bool>)((CommonSelectListItemViewModel x) => x.Id == Prds[0].ProductID)).Value, out result2);
					}
					string text3 = Prds[0].PrdName;
					if (text3.Length > 20)
					{
						text3 = text3.Substring(0, 20);
					}
					if (itemsJs != "")
					{
						itemsJs += ",";
					}
					itemsJs += text2.Replace("{0}", text3).Replace("{1}", result2.ToString());
				}
			}
			if (msgError == "")
			{
				HttpClient httpClient = new HttpClient();
				HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, value);
				httpRequestMessage.Headers.Add("Authorization", "bearer " + token);
				httpRequestMessage.Headers.Add("Cookie", "SEP013d8551=017cb00b0020ae656bcff1c3af0dae7298df1d74023413574bef386a3309b8c6a7f1b34c9cdb0d78f338f10650849add5b28adddde");
				StringContent content = new StringContent(("{\"TerminalID\":\"" + payType.ordPayTypePosTerminal + "\",\r\n\"Amount\":\"" + totalPrice + "\",\r\n\"AccountType\":0,\r\n\"Additional\":\"\",\r\n\"ResNum\":\"" + objId + "\",\r\n\"Identifier\":\"" + identifier + "\",\r\n\"TotalAmount\":\"" + totalPrice + "\",\r\n\"userNotifiable\":{\"FooterMessage\":null,\r\n\"PrintItems\":[[PrintItems]]},\r\n\"TransactionType\":0,\r\n\"BillID\":null,\r\n\"PayID\":null,\r\n\"PurchaseID\":null,\r\n\"RefrenceData\":null,\r\n\"Amount_Iban\":null,\r\n\"PurchaseID_Amount_Iban\":null\r\n}\r\n").Replace("[PrintItems]", itemsJs), null, "application/json");
				httpRequestMessage.Content = content;
				HttpResponseMessage obj = await httpClient.SendAsync(httpRequestMessage);
				obj.EnsureSuccessStatusCode();
				string value2 = await obj.Content.ReadAsStringAsync();
				if (string.IsNullOrWhiteSpace(value2))
				{
					msgError = Messages.msgErrorEmptyResultFromServer;
				}
				StartPaymentResponseResult startPaymentResponseResult = JsonConvert.DeserializeObject<StartPaymentResponseResult>(value2);
				if (!startPaymentResponseResult.IsSuccess)
				{
					msgError = startPaymentResponseResult.ErrorDescription;
				}
				else
				{
					_SendPaymentResponse = JsonConvert.SerializeObject(startPaymentResponseResult.Data);
				}
			}
		}
		catch (Exception ex)
		{
			msgError = ex.Message;
		}
		finally
		{
			_dbI.Dispose();
		}
		return new CommonSelectListItemViewModel
		{
			Message = msgError,
			Value = _SendPaymentResponse
		};
	}
}
