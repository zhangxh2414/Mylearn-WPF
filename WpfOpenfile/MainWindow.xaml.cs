using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Xbim.Ifc4;
using Xbim.Ifc2x3;
using Xbim.Ifc;
using Xbim.Ifc4.Interfaces;
using System.ComponentModel;
using System.Collections;
using WpfOpenfile.ViewModle;


namespace WpfOpenfile
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow:Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ClsViewModel();//这句代码很重要,如果没有这句绑定将不能实现。
           
        }

      



       
    }
}
