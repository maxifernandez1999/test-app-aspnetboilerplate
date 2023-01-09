using myTestProject.Debugging;

namespace myTestProject
{
    public class myTestProjectConsts
    {
        public const string LocalizationSourceName = "myTestProject";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "d70f84145f2a41d9a8069f0c48b856b5";
    }
}
