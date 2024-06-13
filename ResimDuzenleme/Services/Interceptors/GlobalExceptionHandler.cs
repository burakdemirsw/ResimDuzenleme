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
            MessageBox.Show(ex.Message + " " + ex.StackTrace, "An Error Occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

}
