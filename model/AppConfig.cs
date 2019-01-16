using System;

namespace cmp
{
    public static class AppConfig
    {
        public static string GetCurrentDirectory()
        {
            string file;

            file = AppDomain.CurrentDomain.BaseDirectory;
            if (file.IndexOf(@"\bin") > 0)
            {
                file = file.Substring(0, file.LastIndexOf(@"\bin"));
            }

            return file;
        }

    }
}
