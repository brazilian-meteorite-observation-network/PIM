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
        /// <summary>
        /// Method to set a new background worker to run asynchronously without freezing the main thread.
        /// </summary>
        /// <param name="DoWork">Event that will run the code asynchronously</param>
        /// <param name="RunWorkerCompleted">Event that will be executed after "DoWork" event has finished.</param>
        public static void SetBackgroundWorker(DoWorkEventHandler DoWork, RunWorkerCompletedEventHandler RunWorkerCompleted)
        {
            BackgroundWorker worker = new BackgroundWorker();

            worker.DoWork += DoWork;
            worker.RunWorkerCompleted += RunWorkerCompleted;

            worker.RunWorkerAsync();
        }
    }
}
