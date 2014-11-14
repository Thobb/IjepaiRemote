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
using MSTSCLib;

namespace IjepaiRemote
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string[] arg = Environment.GetCommandLineArgs();
            string[] components = arg[1].Split('/');
            System.Windows.Forms.Integration.WindowsFormsHost host = new System.Windows.Forms.Integration.WindowsFormsHost();
            AxMSTSCLib.AxMsTscAxNotSafeForScripting rdpWindow = new AxMSTSCLib.AxMsTscAxNotSafeForScripting();
            host.Child = rdpWindow;
            this.gridBody.Children.Add(host);
            rdpWindow.CreateControl();
            rdpWindow.Server = components[3].Replace("?", "");
            rdpWindow.UserName = components[4];
            IMsTscNonScriptable secured = (IMsTscNonScriptable)rdpWindow.GetOcx();
            secured.ClearTextPassword = components[5];
            rdpWindow.Connect();
        }
    }
}
