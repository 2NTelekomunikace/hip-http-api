using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace HIPHttpApi
{
    public class PhoneCallService : IPhoneCallService
    {
        public PhoneCallService(IHttpClient client)
        {
            _client = client;
        }

        public IResponse PhoneStatus(uint? account = null)
        {
            string result = _client.Get(new Uri(PhoneCallEndpoint.PhoneStatus(account), UriKind.Relative));
            PhoneStatusResponseJson statusResponse = JsonConvert.DeserializeObject<PhoneStatusResponseJson>(result);

            IResponse response = null;

            if (statusResponse.Success)
            {
                List<AccountEntity> accounts = new List<AccountEntity>();
                statusResponse.Result.Accounts.ForEach(acc =>
                {
                    accounts.Add(new AccountEntity()
                    {
                        Id = acc.Id,
                        SipNumber = acc.SipNumber,
                        Registered = acc.Registered,
                        RegisterTime = acc.RegisterTime
                    });
                });

                response = new PhoneStatusResponse(accounts);
            }
            else
            {
                response = Utils.ErrorResponse(result);
            }

            return response;
        }

        public IResponse CallStatus(uint? session = null)
        {
            try
            {
                string result = _client.Get(new Uri(PhoneCallEndpoint.Callstatus(session), UriKind.Relative));
                CallStatusResponseJson statusResponse = JsonConvert.DeserializeObject<CallStatusResponseJson>(result);

                IResponse response = null;

                if (statusResponse.Success)
                {
                    List<SessionEntity> sessions = new List<SessionEntity>();
                    statusResponse.Result.Sessions.ForEach(se =>
                    {
                        sessions.Add(new SessionEntity()
                        {
                            Id = se.Id,
                            Direction = Utils.ParseEnum<SessionDirection>(se.Direction),
                            State = Utils.ParseEnum<SessionState>(se.State)
                        });
                    });

                    response = new CallStatusResponse(sessions);
                }
                else
                {
                    response = Utils.ErrorResponse(result);
                }

                return response;
            }
            catch
            {
                throw;
            }
        }

        public IResponse CallDial(string number)
        {
            try
            {
                string result = _client.Post(new Uri(PhoneCallEndpoint.CallDial(number), UriKind.Relative), null);
                CallDialResponseJson callResponse = JsonConvert.DeserializeObject<CallDialResponseJson>(result);

                IResponse response = null;

                if (callResponse.Success)
                {
                    response = new CallDialResponse(callResponse.Result.Session);
                }
                else
                {
                    response = Utils.ErrorResponse(result);
                }

                return response;
            }
            catch
            {
                throw;
            }
        }

        public IResponse CallAnswer(uint session)
        {
            try
            {
                string result = _client.Post(new Uri(PhoneCallEndpoint.CallAnswer(session), UriKind.Relative), null);
                CallAnswerResponseJson callResponse = JsonConvert.DeserializeObject<CallAnswerResponseJson>(result);

                IResponse response = null;

                if (callResponse.Success)
                {
                    response = new CallAnswerResponse();
                }
                else
                {
                    response = Utils.ErrorResponse(result);
                }

                return response;
            }
            catch
            {
                throw;
            }
        }

        public IResponse CallHangup(uint session, HangupReason reason = HangupReason.Normal)
        {
            try
            {
                string result = _client.Post(new Uri(PhoneCallEndpoint.CallHangup(session, reason), UriKind.Relative), null);
                CallHangupResponseJson callResponse = JsonConvert.DeserializeObject<CallHangupResponseJson>(result);

                IResponse respone = null;

                if (callResponse.Success)
                {
                    respone = new CallHangupResponse();
                }
                else
                {
                    respone = Utils.ErrorResponse(result);
                }

                return respone;
            }
            catch
            {
                throw;
            }
        }

        IHttpClient _client;
        public IHttpClient Client
        {
            get { return _client; }
        }
    }
}
