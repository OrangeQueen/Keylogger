using System;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Windows.Forms;

namespace KeyLogger.Display
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        [HandleProcessCorruptedStateExceptions]
        private static void Main()
        {
            Application.ThreadException += ApplicationOnThreadException;

#if DEBUG
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.ThrowException);
#else
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
#endif

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Overview());
        }

        private static void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs unhandledExceptionEventArgs)
        {
            try
            {
                var exception = (Exception) unhandledExceptionEventArgs.ExceptionObject;

                MessageBox.Show("An fatal application error occurred.\n\n Information:\n\n" + exception.Message +
                                    "\n\n" + exception.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally 
            {
                Application.Exit();
            }
        }

        private static void ApplicationOnThreadException(object sender, ThreadExceptionEventArgs threadExceptionEventArgs)
        {
            var dialogresult = DialogResult.Cancel;

            try
            {
                dialogresult =
                    MessageBox.Show("An application error occurred.\n\n Information:\n\n" + threadExceptionEventArgs.Exception.Message +
                                    "\n\n" + threadExceptionEventArgs.Exception.StackTrace, "Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);
            }
            catch
            {
                Application.Exit();
            }

            if(dialogresult == DialogResult.Abort)
                Application.Exit();
        }
    }
}