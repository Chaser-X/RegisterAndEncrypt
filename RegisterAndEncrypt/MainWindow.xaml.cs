using MahApps.Metro.Controls;
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

namespace RegisterAndEncrypt
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SoftRegister.RegisterID();
            MessageBox.Show("软件注册成功！");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SoftRegister.UnLoadID();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (SoftRegister.VerifyID())
                MessageBox.Show("软件已注册！");
            else
                MessageBox.Show("软件未注册！");
        }
    }
}
