using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WindowsClient._Data._Actions
{
    public static class BackgroundWorkers
    {
        private static BackgroundWorker worker = new BackgroundWorker(); // object that will work on the background asynchronously.

        /// <summary>
        /// Method to set a new background worker to run asynchronously without freezing the main thread.
        /// </summary>
        /// <param name="DoWork">Event that will run the code asynchronously</param>
        /// <param name="RunWorkerCompleted">Event that will be executed after "DoWork" event has finished.</param>
        public static void SetBackgroundWorker(DoWorkEventHandler DoWork, RunWorkerCompletedEventHandler RunWorkerCompleted)
        {
            if (!worker.IsBusy)
            {
                worker.DoWork += DoWork;
                worker.RunWorkerCompleted += delegate (object sender, RunWorkerCompletedEventArgs e)
                {
                    RunWorkerCompleted(sender, e);

                    worker.Dispose();
                    worker = new BackgroundWorker();
                };

                worker.RunWorkerAsync();
            }
        }

        public static void RemoveBackgroundWorker()
        {
            if (worker.IsBusy)
            {
                if (worker.WorkerSupportsCancellation) worker.CancelAsync();
                else
                {
                    worker.Dispose();
                    worker = new BackgroundWorker();
                }
            }
        }
    }
}
