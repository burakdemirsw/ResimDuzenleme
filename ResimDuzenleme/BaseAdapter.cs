using ResimDuzenleme.AuthenticationWS;
using System;
using System.Collections.Generic;
using ResimDuzenleme.EArchiveInvoiceWS;
using ResimDuzenleme.EIrsaliyeWS;
using ResimDuzenleme.SmmWs;
using ResimDuzenleme.Operations;


namespace ResimDuzenleme
{
    public static class BaseAdapter
    {
        private static String _sessionId;
        public static EInvoiceWS.INVOICE[] invoiceToMarkInvoice;//GetInvoice ile çekilen faturaları markinvoice ile alındı alınmadı olarak işaretlemek için

        public static String SessionId
        {
            get
            {
                if (_sessionId == null)
                {
                    AuthenticationServicePortClient authenticationPortClient = new AuthenticationServicePortClient();
                    LoginRequest loginRequest = new LoginRequest();
                    loginRequest.USER_NAME = "misigostore";
                    loginRequest.PASSWORD = "Ehil1524";
                    LoginResponse loginResponse = authenticationPortClient.Login(loginRequest);
                    _sessionId = loginResponse.SESSION_ID;
                }
                return _sessionId;
            }
        }

        public static EArchiveInvoiceWS.REQUEST_HEADERType EArchiveRequestHeaderType()
        {
            return new EArchiveInvoiceWS.REQUEST_HEADERType
            {
                SESSION_ID = BaseAdapter.SessionId,
                COMPRESSED = nameof(EI.YesNo.Y),
                APPLICATION_NAME = "Izibiz_dotnet_soap_client.Application"
            };
        }

        public static AuthenticationWS.REQUEST_HEADERType AuntWSRequestHeaderType()
        {
            return new AuthenticationWS.REQUEST_HEADERType
            {
                SESSION_ID = BaseAdapter.SessionId,
                COMPRESSED = nameof(EI.YesNo.Y),
                APPLICATION_NAME = "Izibiz_dotnet_soap_client.Application"
            };
        }

        public static EInvoiceWS.REQUEST_HEADERType EInvoiceWSRequestHeaderType()
        {
            return new EInvoiceWS.REQUEST_HEADERType
            {
                SESSION_ID = BaseAdapter.SessionId,
                COMPRESSED = nameof(EI.YesNo.Y),
                APPLICATION_NAME = "Izibiz_dotnet_soap_client.Application"

            };
        }

        public static EIrsaliyeWS.REQUEST_HEADERType EDespatchWSRequestHeaderType()
        {
            return new EIrsaliyeWS.REQUEST_HEADERType
            {
                SESSION_ID = BaseAdapter.SessionId,
                COMPRESSED = nameof(EI.YesNo.Y),
                APPLICATION_NAME = "Izibiz_dotnet_soap_client.Application"
            };
        }

        public static CreditNoteWS.REQUEST_HEADERType CreditNoteWSRequestHeaderType()
        {
            return new CreditNoteWS.REQUEST_HEADERType
            {
                SESSION_ID = BaseAdapter.SessionId,
                COMPRESSED = nameof(EI.YesNo.Y),
                APPLICATION_NAME = "Izibiz_dotnet_soap_client.Application"
            };
        }

        public static SmmWs.REQUEST_HEADERType SmmWSRequestHeaderType()
        {
            return new SmmWs.REQUEST_HEADERType
            {
                SESSION_ID = BaseAdapter.SessionId,
                COMPRESSED = nameof(EI.YesNo.Y),
                APPLICATION_NAME = "Izibiz_dotnet_soap_client.Application"
            };
        }
    }
}