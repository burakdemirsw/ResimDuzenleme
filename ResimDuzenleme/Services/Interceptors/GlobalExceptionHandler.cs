using System;
using System.Threading;
using System.Windows.Forms;

namespace ResimDuzenleme.Services.Interceptors
{
    public static class GlobalExceptionHandler
    {
        public static void HandleException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;
            ShowExceptionMessage(ex);
        }

        public static void HandleThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Exception ex = e.Exception;
            ShowExceptionMessage(ex);
        }

        private static void ShowExceptionMessage(Exception ex)
        {
            if (StaticVariables.errors.Count > 100)
            {
                StaticVariables.errors.Clear();
            }
            StaticVariables.errors.Add(ex.Message + " " + ex.StackTrace.ToString() + "\n\n\n");

        }
    }

}
