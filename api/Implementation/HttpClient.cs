using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HIPHttpApi
{
	public class HttpClient : IHttpClient
	{
        IHttpClientConfiguration _configuration;
        Uri _baseAddress = null;
		
		public HttpClient(IHttpClientConfiguration configuration)
        {
            if (configuration == null)
                throw new NullReferenceException("Configuration cannot be null.");

            _configuration = configuration;
            _baseAddress = new Uri(string.Format("https://{0}:{1}", _configuration.Address, _configuration.Port));
            IgnoreBadCertificates();
		}

        public string Get(Uri endpoint)
        {
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(new Uri(_baseAddress, endpoint));
                req.ContentType = "application/json";
                req.Method = "GET";
                req.Timeout = _configuration.Timeout;
                
                if (_configuration.NetworCredential != null)
                    req.Credentials = _configuration.NetworCredential;

                return GetResponse(req.GetResponse());
            }
            catch
            {
                throw;
            }
        }

        public string Post(Uri endpoint, string payload)
        {
			try
			{
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(new Uri(_baseAddress, endpoint));
				req.ContentType = "application/json";
				req.Method = "POST";
                req.Timeout = _configuration.Timeout;

                if (_configuration.NetworCredential != null)
                    req.Credentials = _configuration.NetworCredential;

				if (!string.IsNullOrEmpty(payload))
				{
					Stream s = req.GetRequestStream();
					byte[] data = Encoding.UTF8.GetBytes(payload);
					s.Write(data, 0, data.Length);
					s.Close();
				}

                return GetResponse(req.GetResponse());
			}
			catch
			{
				throw;
			}
        }

        public string Put(Uri endpoint, string payload)
		{
			try
			{
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(new Uri(_baseAddress, endpoint));
				req.ContentType = "application/json";
				req.Method = "PUT";
                req.Timeout = _configuration.Timeout;

                if (_configuration.NetworCredential != null)
                    req.Credentials = _configuration.NetworCredential;

				if (!string.IsNullOrEmpty(payload))
				{
					Stream s = req.GetRequestStream();
					byte[] data = Encoding.UTF8.GetBytes(payload);
					s.Write(data, 0, data.Length);
					s.Close();
				}

                return GetResponse(req.GetResponse());
			}
			catch
			{
				throw;
			}
		}

        public string Delete(Uri endpoint, string payload)
        {
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(new Uri(_baseAddress, endpoint));
                req.ContentType = "application/json";
                req.Method = "DELETE";
                req.Timeout = _configuration.Timeout;

                if (_configuration.NetworCredential != null)
                    req.Credentials = _configuration.NetworCredential;

                if (!string.IsNullOrEmpty(payload))
                {
                    Stream s = req.GetRequestStream();
                    byte[] data = Encoding.UTF8.GetBytes(payload);
                    s.Write(data, 0, data.Length);
                    s.Close();
                }

                return GetResponse(req.GetResponse());
            }
            catch
            {
                throw;
            }
        }

        private string GetResponse(WebResponse response)
        {
            string result = null;
            using (StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                result = sr.ReadToEnd();
                response.Close();
            }

            return result;
        }

		private static byte[] Decompress(byte[] gzip)
		{
			if (gzip.Length >= 3 && gzip[0] == 31 && gzip[1] == 139 && gzip[2] == 8)
			{
				using (GZipStream stream = new GZipStream(new MemoryStream(gzip), CompressionMode.Decompress))
				{
					const int size = 4096;
					byte[] buffer = new byte[size];
					using (MemoryStream memory = new MemoryStream())
					{
						int count = 0;
						do
						{
							count = stream.Read(buffer, 0, size);
							if (count > 0)
							{
								memory.Write(buffer, 0, count);
							}
						}
						while (count > 0);
						return memory.ToArray();
					}
				}
			}
			return gzip;
		}

		/// <summary>
		/// Together with the AcceptAllCertifications method right
		/// below this causes to bypass errors caused by SLL-Errors.
		/// </summary>
		private void IgnoreBadCertificates()
		{
			System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
		}

		/// <summary>
		/// In Short: the Method solves the Problem of broken Certificates.
		/// Sometime when requesting Data and the sending Webserverconnection
		/// is based on a SSL Connection, an Error is caused by Servers whoes
		/// Certificate(s) have Errors. Like when the Cert is out of date
		/// and much more... So at this point when calling the method,
		/// this behaviour is prevented
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="certification"></param>
		/// <param name="chain"></param>
		/// <param name="sslPolicyErrors"></param>
		/// <returns>true</returns>
		private bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
		{
			return true;
		}
    }
}