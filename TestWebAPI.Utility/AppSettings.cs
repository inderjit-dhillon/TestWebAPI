using System;

namespace TestWebAPI.Utility
{
    public class AppSettings
    {

        public ConnectionString ConnectionStrings { get; set; }
     

    }
    public class ConnectionString
    {
        public string DefaultConnection { get; set; }
    }
}
