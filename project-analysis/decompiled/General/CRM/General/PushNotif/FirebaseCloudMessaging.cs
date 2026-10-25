using System;
using System.Collections.Generic;
using System.Linq;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using Newtonsoft.Json;

namespace CRM.General.PushNotif;

public class FirebaseCloudMessaging
{
	private class FcmPrivateKeyViewModel
	{
		public string type { get; set; }

		public string project_id { get; set; }

		public string private_key_id { get; set; }

		public string private_key { get; set; }

		public string client_email { get; set; }

		public string client_id { get; set; }

		public string auth_uri { get; set; }

		public string token_uri { get; set; }

		public string auth_provider_x509_cert_url { get; set; }

		public string client_x509_cert_url { get; set; }
	}

	public void SetupFirebaseApp()
	{
		if (FirebaseApp.DefaultInstance == null)
		{
			string json = JsonConvert.SerializeObject(new FcmPrivateKeyViewModel
			{
				type = "service_account",
				project_id = "karaafzarideal-4dd7b",
				private_key_id = "1c904fd2519f4cf8fddbf4d54803c8cfd4f4e6a1",
				private_key = "-----BEGIN PRIVATE KEY-----\nMIIEvQIBADANBgkqhkiG9w0BAQEFAASCBKcwggSjAgEAAoIBAQDVY1URv5X4/SkD\ngalOanjAEMSnpOczUf0jc9UHF7gG7lbX8vdBaLl63q0R6BpTFgrygiXkulgQaHVB\ntBFtqhznjU7d3WsticqQg/1I7m1Y6DZ6zhXt/XqR18qWdHUTFRDEBfHycBDEM7YH\nbZ6VKS5BHu0t8Y/ktjAReYPbwXwQCsjBcBd9ZTmHWkxewg85h1K/cqWB4xFlqxCf\njUm/K1HyUi2fFAoVKRd5XTpEYdHio9S/4mIsQa6RcSS3d1JyOTRWGLHETSOc5Ppy\nnE1LFt4eUV35fX83MmsAv3Pqbc3U4S45xfnlS1OIKjb+h7E+nyiULsLo3kBeNLNZ\nUrNRbbfJAgMBAAECggEABq2yoMIl/p3UoVqbh1meTUtv6e4nmtvffKDal/upxfSd\n+FchgxdrtGkMTaLiUlI+k8EJ4pMILf2SYn4MjHL4iufb3XiimKzXD5dozR9CXW7X\nHs8c+k6466AvWrfYp+bO4YX/QNXL6/gaWqZOOSjlE7VCp6iZzb3XI94DvsHbNZiy\nJIE3J44Ozt4Tupa3vpl1l6PWqgGyMlUG4OLvpJGnc7MgbFe9+EQgu1tMoHw188Jo\n4AvnXgz5pDwGX4XX4t41NNEYLGOnRdAme8bkCHx1lri/JR1oeHZmLUw/BG59D1qX\n21e2V9cOBCf9/AaafGOCVZNTjmaOzDEso8ff8DfEaQKBgQD64ZrmWUrcFErv2Isa\ntelLNUeHo3EEwyqlABrLlpMhD+GdSsGWdjW11INdkFgj6DZWGwDcN9340NCRFG3X\nzYuw06KNp+wvdm724RN5TZiNQUXgkKEuHJ6Q4s0/sOM0ZX9eP/qbDwtkd93LIkuQ\nO4wfgvM2u7Za7jW49k1hibw8qwKBgQDZveTINK0PD6xeC71Zn3W10D06vKGFxEv+\nDUQkAGwvN8Wq9kRl/3gNll6NrEQ2s2JljdrJElYgXb/PWgzwxBUGLla1WGpWtWKd\nIK3Cap8dAnsxOO+7UGwDBUnHvDA669dx4NCv8my0XAnTzkEX1KVvRl8+gh5MAf1g\nZYYoJ151WwKBgQDiXMTiqhZ9VGH43q1EQHZqwXv0ymejIGVN0zZaE1ZVMnsi7NyW\n4bm8gi61MRQV8eN09ZBlIpNJeT92Z7RkTrWHqqy0m5rjiDy+zH5BqN3INejSoiyL\n6o63s6v1l6ipEhtF8vwvA/gHgo/ARQVg8hmQJRtFe0Eh8mTOqo1PQHNzWQKBgAr1\nFWhFzletsDzjVloGPkQyAILOL0quACz+uekd5FPT+KyLzBFd88qrQILcomomSNNX\neiUYOSFT1m022OPc2jn/ZvmlQ2StqBLELDpWZz9seoqVlOrWNzlHsNjOTZcJe0QN\nzjKsfm/tGcmA3aG3X8PjxLM+lQu6JegN89xdbtF1AoGABI5VCdqQLIXufOzX7Knf\nc30QNKVwLCN+2UTioRf+RksRN+zhf27udxN22gaHVeDyRixPulMBq1PCJiUWBFZL\nhPWJJzkZQ4Iu10vt7tanvOi3R6s2FK3ITaqTvxb1ZQMkAhG7oZBh/gx+91xzww5V\ntSnwNuFDVvQACx28i8DvdwQ=\n-----END PRIVATE KEY-----\n",
				client_email = "firebase-adminsdk-ujeyf@karaafzarideal-4dd7b.iam.gserviceaccount.com",
				client_id = "108574783759347238955",
				auth_uri = "https://accounts.google.com/o/oauth2/auth",
				token_uri = "https://oauth2.googleapis.com/token",
				auth_provider_x509_cert_url = "https://www.googleapis.com/oauth2/v1/certs",
				client_x509_cert_url = "https://www.googleapis.com/robot/v1/metadata/x509/firebase-adminsdk-ujeyf%40karaafzarideal-4dd7b.iam.gserviceaccount.com"
			});
			FirebaseApp.Create(new AppOptions
			{
				Credential = GoogleCredential.FromJson(json)
			});
		}
	}

	public bool SendTopicMessage(string topic, Dictionary<string, string> extraData, ref Exception ex)
	{
		try
		{
			if (FirebaseApp.DefaultInstance == null)
			{
				SetupFirebaseApp();
			}
			Message message = new Message
			{
				Data = extraData,
				Topic = topic
			};
			_ = FirebaseMessaging.DefaultInstance.SendAsync(message).Result;
		}
		catch (Exception ex2)
		{
			ex = ex2;
		}
		return true;
	}

	public bool SendTokenMessage(List<string> tokens, Dictionary<string, string> extraData, ref Exception ex)
	{
		try
		{
			if (FirebaseApp.DefaultInstance == null)
			{
				SetupFirebaseApp();
			}
			if (Enumerable.Count<string>((IEnumerable<string>)tokens) > 0)
			{
				MulticastMessage message = new MulticastMessage
				{
					Tokens = tokens,
					Data = extraData
				};
				_ = FirebaseMessaging.DefaultInstance.SendEachForMulticastAsync(message).Result;
			}
		}
		catch (Exception ex2)
		{
			ex = ex2;
		}
		return true;
	}

	public bool SendTokenNotificationMessage(List<string> tokens, string title, string body, Dictionary<string, string> extraData, ref Exception ex)
	{
		try
		{
			if (FirebaseApp.DefaultInstance == null)
			{
				SetupFirebaseApp();
			}
			if (Enumerable.Count<string>((IEnumerable<string>)tokens) > 0)
			{
				extraData.Add("Title", title);
				extraData.Add("Message", body);
				MulticastMessage message = new MulticastMessage
				{
					Tokens = tokens,
					Data = extraData
				};
				_ = FirebaseMessaging.DefaultInstance.SendEachForMulticastAsync(message).Result;
			}
		}
		catch (Exception ex2)
		{
			ex = ex2;
		}
		return true;
	}

	public bool SendCallerIdNotificationMessage(List<string> tokens, Dictionary<string, string> extraData, ref Exception ex)
	{
		try
		{
			if (FirebaseApp.DefaultInstance == null)
			{
				SetupFirebaseApp();
			}
			if (Enumerable.Count<string>((IEnumerable<string>)tokens) > 0)
			{
				ApnsConfig apnsConfig = new ApnsConfig();
				apnsConfig.Aps = new Aps();
				apnsConfig.Aps.ContentAvailable = true;
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary.Add("apns-priority", "5");
				dictionary.Add("apns-push-type", "background");
				apnsConfig.Headers = dictionary;
				AndroidConfig androidConfig = new AndroidConfig();
				androidConfig.Priority = Priority.High;
				MulticastMessage message = new MulticastMessage
				{
					Tokens = tokens,
					Data = extraData,
					Apns = apnsConfig,
					Android = androidConfig
				};
				_ = FirebaseMessaging.DefaultInstance.SendEachForMulticastAsync(message).Result;
			}
		}
		catch (Exception ex2)
		{
			ex = ex2;
		}
		return true;
	}

	public bool SendNewIntMsgNotificationMessage(List<string> tokens, Dictionary<string, string> extraData, ref Exception ex)
	{
		try
		{
			if (FirebaseApp.DefaultInstance == null)
			{
				SetupFirebaseApp();
			}
			if (Enumerable.Count<string>((IEnumerable<string>)tokens) > 0)
			{
				ApnsConfig apnsConfig = new ApnsConfig();
				apnsConfig.Aps = new Aps();
				apnsConfig.Aps.ContentAvailable = true;
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary.Add("apns-priority", "5");
				dictionary.Add("apns-push-type", "background");
				apnsConfig.Headers = dictionary;
				AndroidConfig androidConfig = new AndroidConfig();
				androidConfig.Priority = Priority.High;
				MulticastMessage message = new MulticastMessage
				{
					Tokens = tokens,
					Data = extraData,
					Apns = apnsConfig,
					Android = androidConfig
				};
				_ = FirebaseMessaging.DefaultInstance.SendEachForMulticastAsync(message).Result;
			}
		}
		catch (Exception ex2)
		{
			ex = ex2;
		}
		return true;
	}

	public bool SendNewPayRollUserPaymentNotificationMessage(List<string> tokens, Dictionary<string, string> extraData, ref Exception ex)
	{
		try
		{
			if (FirebaseApp.DefaultInstance == null)
			{
				SetupFirebaseApp();
			}
			if (Enumerable.Count<string>((IEnumerable<string>)tokens) > 0)
			{
				ApnsConfig apnsConfig = new ApnsConfig();
				apnsConfig.Aps = new Aps();
				apnsConfig.Aps.ContentAvailable = true;
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary.Add("apns-priority", "5");
				dictionary.Add("apns-push-type", "background");
				apnsConfig.Headers = dictionary;
				AndroidConfig androidConfig = new AndroidConfig();
				androidConfig.Priority = Priority.High;
				MulticastMessage message = new MulticastMessage
				{
					Tokens = tokens,
					Data = extraData,
					Apns = apnsConfig,
					Android = androidConfig
				};
				_ = FirebaseMessaging.DefaultInstance.SendEachForMulticastAsync(message).Result;
			}
		}
		catch (Exception ex2)
		{
			ex = ex2;
		}
		return true;
	}
}
