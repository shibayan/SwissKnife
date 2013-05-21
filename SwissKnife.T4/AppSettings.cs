using System.Configuration;

namespace SwissKnife.T4
{
    [System.Diagnostics.DebuggerNonUserCodeAttribute]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute]
    internal static class AppSettings
    {
        internal static string ClientValidationEnabled
        {
            get { return ConfigurationManager.AppSettings["ClientValidationEnabled"]; }
        }

        internal static class Facebook
        {
            internal static string AppId
            {
                get { return ConfigurationManager.AppSettings["Facebook:AppId"]; }
            }

            internal static string AppNamespace
            {
                get { return ConfigurationManager.AppSettings["Facebook:AppNamespace"]; }
            }

            internal static string AppSecret
            {
                get { return ConfigurationManager.AppSettings["Facebook:AppSecret"]; }
            }

            internal static string AuthorizationRedirectPath
            {
                get { return ConfigurationManager.AppSettings["Facebook:AuthorizationRedirectPath"]; }
            }

            internal static class VerifyToken
            {
                internal static string User
                {
                    get { return ConfigurationManager.AppSettings["Facebook:VerifyToken:User"]; }
                }
            }
        }

        internal static string PreserveLoginUrl
        {
            get { return ConfigurationManager.AppSettings["PreserveLoginUrl"]; }
        }

        internal static string UnobtrusiveJavaScriptEnabled
        {
            get { return ConfigurationManager.AppSettings["UnobtrusiveJavaScriptEnabled"]; }
        }

        internal static class Webpages
        {
            internal static string Enabled
            {
                get { return ConfigurationManager.AppSettings["webpages:Enabled"]; }
            }

            internal static string Version
            {
                get { return ConfigurationManager.AppSettings["webpages:Version"]; }
            }
        }
    }
}

