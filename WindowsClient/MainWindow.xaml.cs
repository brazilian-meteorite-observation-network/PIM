using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.ComponentModel;
using WindowsClient._Data._Helpers;

namespace WindowsClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            SQLite.CreateSQLiteDB();
            SQLite.CreateSQLiteTable();

            SetBackgroundWorker
            (
                (object sender, DoWorkEventArgs e) => { Thread.Sleep(5000); }, // Freezes the main thread for 5 seconds.
                (object sender, RunWorkerCompletedEventArgs e) =>
                {
                    Default frmDefault = new Default();

                    frmDefault.Show();

                    this.Close();
                } // Opens the Default form after 5 seconds.
            );
        }

        /// <summary>
        /// Method to set a new background worker to run asynchronously without freezing the main thread.
        /// </summary>
        /// <param name="DoWork">Event that will run the code asynchronously</param>
        /// <param name="RunWorkerCompleted">Event that will be executed after "DoWork" event has finished.</param>
        private void SetBackgroundWorker(DoWorkEventHandler DoWork, RunWorkerCompletedEventHandler RunWorkerCompleted)
        {
            BackgroundWorker worker = new BackgroundWorker();

            worker.DoWork += DoWork;
            worker.RunWorkerCompleted += RunWorkerCompleted;

            worker.RunWorkerAsync();
        }
    }
}
