using System.Configuration;

namespace SwissKnife.T4
{
    public static class AppSettings
    {
        public static class Foo
        {
            public static string Bar
            {
                get { return ConfigurationManager.AppSettings["Foo.Bar"]; }
            }
        }

        public static string Sample
        {
            get { return ConfigurationManager.AppSettings["Sample"]; }
        }
    }
}

