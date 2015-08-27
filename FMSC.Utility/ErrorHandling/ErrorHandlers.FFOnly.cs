using System;
using System.Windows.Threading;
using System.Threading;
using System.Reflection;

namespace FMSC.Utility.ErrorHandling
{
    public static partial class ErrorHandlers
    {
       

        #region FF only
        /// <summary>
        /// Used for handling WinForms exceptions bound to the UI thread.
        /// Handles the <see cref="Application.ThreadException"/> events in <see cref="System.Windows.Forms"/> namespace.
        /// </summary>
        public static ThreadExceptionEventHandler ThreadException
        {
            get
            {
                return ThreadExceptionHandler;
            }
        }



        /// <summary>
        /// Used for handling WPF exceptions bound to the UI thread.
        /// Handles the <see cref="Application.DispatcherUnhandledException"/> events in <see cref="System.Windows"/> namespace.
        /// </summary>
        public static DispatcherUnhandledExceptionEventHandler DispatcherUnhandledException
        {
            get
            {
                return DispatcherUnhandledExceptionHandler;
            }
        }



        ///// <summary>
        ///// Used for handling System.Threading.Tasks bound to a background worker thread.
        ///// Handles the <see cref="UnobservedTaskException"/> event in <see cref="System.Threading.Tasks"/> namespace.
        ///// </summary>
        //public static EventHandler<UnobservedTaskExceptionEventArgs> UnobservedTaskException
        //{
        //    get
        //    {
        //    }
        //}

        /// <summary>
        /// Used for handling WinForms exceptions bound to the UI thread.
        /// Handles the <see cref="Application.ThreadException"/> events in <see cref="System.Windows.Forms"/> namespace.
        /// </summary>
        /// <param name="sender">Exception sender object.</param>
        /// <param name="e">Real exception is in: e.Exception</param>
        private static void ThreadExceptionHandler(object sender, ThreadExceptionEventArgs e)
        {
            //regular exception handling logic...


            InitializeReport(e.Exception, Assembly.GetCallingAssembly());
        }



        
        private static void CorruptThreadExceptionHandler(object sender, ThreadExceptionEventArgs e)
        {
        }

 

        /// <summary>
        /// Used for handling WPF exceptions bound to the UI thread.
        /// Handles the <see cref="Application.DispatcherUnhandledException"/> events in <see cref="System.Windows"/> namespace.
        /// </summary>
        /// <param name="sender">Exception sender object</param>
        /// <param name="e">Real exception is in: e.Exception</param>
        
        private static void DispatcherUnhandledExceptionHandler(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            InitializeReport(e.Exception, Assembly.GetCallingAssembly());
        }


        private static void CorruptDispatcherUnhandledExceptionHandler(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
        }

        ///// <summary>
        ///// Used for handling System.Threading.Tasks bound to a background worker thread.
        ///// Handles the <see cref="UnobservedTaskException"/> event in <see cref="System.Threading.Tasks"/> namespace.
        ///// </summary>
        ///// <param name="sender">Exception sender object.</param>
        ///// <param name="e">Real exception is in: e.Exception.</param>
        //private static void UnobservedTaskExceptionHandler(object sender, UnobservedTaskExceptionEventArgs e)
        //{
        //}

        //private static void CorruptUnobservedTaskExceptionHandler(object sender, UnobservedTaskExceptionEventArgs e)
        //{
        //}

        #endregion
    }
}
