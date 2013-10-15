using System.Configuration;

namespace SwissKnife.T4
{
    [System.Diagnostics.DebuggerNonUserCodeAttribute]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute]
    public static class AppSettings
    {
        public static string ClientValidationEnabled
        {
            get { return ConfigurationManager.AppSettings["ClientValidationEnabled"]; }
        }

        public static class Facebook
        {
            public static string AppId
            {
                get { return ConfigurationManager.AppSettings["Facebook:AppId"]; }
            }

            public static string AppNamespace
            {
                get { return ConfigurationManager.AppSettings["Facebook:AppNamespace"]; }
            }

            public static string AppSecret
            {
                get { return ConfigurationManager.AppSettings["Facebook:AppSecret"]; }
            }

            public static string AuthorizationRedirectPath
            {
                get { return ConfigurationManager.AppSettings["Facebook:AuthorizationRedirectPath"]; }
            }

            public static class VerifyToken
            {
                public static string Token
                {
                    get { return ConfigurationManager.AppSettings["Facebook:VerifyToken:Token"]; }
                }

                public static string User
                {
                    get { return ConfigurationManager.AppSettings["Facebook:VerifyToken:User"]; }
                }
            }
        }

        public static string PreserveLoginUrl
        {
            get { return ConfigurationManager.AppSettings["PreserveLoginUrl"]; }
        }

        public static string UnobtrusiveJavaScriptEnabled
        {
            get { return ConfigurationManager.AppSettings["UnobtrusiveJavaScriptEnabled"]; }
        }

        public static class Webpages
        {
            public static string Enabled
            {
                get { return ConfigurationManager.AppSettings["webpages:Enabled"]; }
            }

            public static string Version
            {
                get { return ConfigurationManager.AppSettings["webpages:Version"]; }
            }
        }
    }
}

