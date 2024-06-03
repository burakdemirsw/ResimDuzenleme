using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using ResimDuzenleme.Adapter;
using ResimDuzenleme.AuthenticationWS;
using ResimDuzenleme.Operations;


namespace ResimDuzenleme
{

    class AuthenticationSample
    {
        private readonly ResimDuzenlemeClient _ResimDuzenlemeClient = new ResimDuzenlemeClient();
        string User = Properties.Settings.Default.DEUser;
        string sifre = Properties.Settings.Default.DESifre;
        [Test, Order(1)]
        public void Loginn()
        {
            var request = new LoginRequest
            {

                REQUEST_HEADER = new REQUEST_HEADERType
                {
                    SESSION_ID = "-1",
                    APPLICATION_NAME = "nebimv3erp"
                },
                USER_NAME = User,
                PASSWORD = sifre

            };

            LoginResponse response = _ResimDuzenlemeClient.Auth().Login(request);
            Assert.NotNull(response.SESSION_ID);


        }

        [Test, Order(2)]
        public void CheckUserInvoice()
        {   //e-fatura mükellefi mi kontrol etme 
            var request = new CheckUserRequest
            {

                REQUEST_HEADER = new REQUEST_HEADERType
                {
                    SESSION_ID = BaseAdapter.SessionId,
                    APPLICATION_NAME = "nebimv3erp"
                },
                USER = new GIBUSER
                {
                    IDENTIFIER = "4840847211"
                },
                DOCUMENT_TYPE = "INVOICE"
            };

            CheckUserResponse response = _ResimDuzenlemeClient.Auth().CheckUserInvoice(request);
            Assert.AreEqual(response.USER.Length, 7);
        }

        [Test, Order(3)]
        public void CheckUserDespatchadvice()
        {   //e-irsaliye mükellefi mi kontrol etme 
            var request = new CheckUserRequest
            {

                REQUEST_HEADER = new REQUEST_HEADERType
                {
                    SESSION_ID = BaseAdapter.SessionId,
                    APPLICATION_NAME = "nebimv3erp"
                },
                USER = new GIBUSER
                {
                    IDENTIFIER = "4840847211"
                },
                DOCUMENT_TYPE = "DESPATCHADVICE"
            };

            CheckUserResponse response = _ResimDuzenlemeClient.Auth().CheckUserDespatchadvice(request);
            Assert.AreEqual(response.USER.Length, 6);
        }



        //    [Test,Order(5)]
        public void Logout()
        {
            var request = new LogoutRequest
            {

                REQUEST_HEADER = new REQUEST_HEADERType
                {
                    SESSION_ID = BaseAdapter.SessionId,
                    APPLICATION_NAME = "nebimv3erp"
                }

            };
            LogoutResponse response = _ResimDuzenlemeClient.Auth().Logout(request);
            Assert.Null(response.ERROR_TYPE);

        }

    }
}
