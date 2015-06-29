using System;
using System.Configuration;

namespace PeculiarTuitionBase.Database
{
    [CLSCompliant(true)]
    internal static class DBase
    {
        private static string ConStr;

        public static string DataBaseName()
        {
            DBase.ConStr = ConfigurationSettings.AppSettings["Database"];
            return DBase.ConStr;
        }
    }
}
