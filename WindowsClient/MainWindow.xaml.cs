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
using WindowsClient._Data;
using WindowsClient._Data._Actions;
using WindowsClient._Data._Helpers;
using System.Data;
using System.IO;

namespace WindowsClient
{
    /// <summary>
    ///     All actions to verify this aplication integrity.
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SQLite.CreateSQLiteDB();
            SQLite.CreateSQLiteTable();

            DirectoryChecker();
            
            SetBackgroundWorker
            (
                (object sender, DoWorkEventArgs e) => { Thread.Sleep(2000); }, // Freezes the main thread for x seconds.
                (object sender, RunWorkerCompletedEventArgs e) =>
                {
                    // Opens the Default form after x seconds.
                    Default frmDefault = new Default();
                    frmDefault.Show();
                    this.Close();
                }
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

        // [ToDo.MoveToOwnClass] - temporarily this directory is here.
        private void DirectoryChecker()
        {
            bool directory = Directory.Exists(@"C:\program files\PIM");
            bool model3d = File.Exists(@"C:\program files\PIM\model3d_newdens.for");
            bool kepler2 = File.Exists(@"C:\program files\PIM\kepler2.for");

            if (directory != true)
                Directory.CreateDirectory(@"C:\program files\PIM");
            if (model3d != true)
                File.Copy(Actions.PIMFolder+ "/Model3d_newdens.for", @"C:\program files\PIM\model3d_newdens.for");
            if (kepler2 != true)
                File.Copy(Actions.PIMFolder + "/kepler2.for", @"C:\program files\PIM\kepler2.for");
        }
    }
}
