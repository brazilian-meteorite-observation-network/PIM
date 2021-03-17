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

namespace WindowsClient._Data._Items
{
    /// <summary>
    /// Interaction logic for TextBoxPlaceHolder.xaml
    /// </summary>
    public partial class TextBoxPlaceHolder : UserControl
    {
        public string PlaceHolderText { get; set; }
        public string ToolTipTitle { get; set; }
        public string ToolTipText { get; set; }

        public TextBoxPlaceHolder()
        {
            InitializeComponent();
        }

        public void InsertValues(string PlaceHolder, string Title, string Text)
        {
            PlaceHolderText = PlaceHolder;
            ToolTipTitle = Title;
            ToolTipText = Text;

            LblPlaceHolder.Content = PlaceHolderText;
            L1ToolTip.Text = Title;
            L2ToolTip.Text = Text;
        }

        public void InsertValues(string PlaceHolder, string Title, string Text, double Value)
        {
            PlaceHolderText = PlaceHolder;
            ToolTipTitle = Title;
            ToolTipText = Text;

            LblPlaceHolder.Content = PlaceHolderText;
            L1ToolTip.Text = Title;
            L2ToolTip.Text = Text;

            TxtText.Text = Value.ToString();
            Behavior();
        }

        public void Behavior()
        {
            if (TxtText.Text != "")
            {
                LblPlaceHolder.Content = "";
            }
            else
            {
                LblPlaceHolder.Content = PlaceHolderText;
            }
        }

        private void Content_TextChanged(object sender, TextChangedEventArgs e)
        {
            Behavior();
        }
    }
}
