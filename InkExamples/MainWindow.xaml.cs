using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InkExamples
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        private InkPage p;
        private string header = "例2";

        public MainWindow()
        {
            InitializeComponent();

            this.Closing += MainWindow_Closing;
            p = new InkPage();
            frame1.Content = p.Content;
            p.Init("球形", "ink2.ink");

        }

        void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void RibbonRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RibbonRadioButton rrb = e.Source as RibbonRadioButton;
            string parent = (rrb.Parent as RibbonGroup).Header.ToString();
            p.ChangeSelect(rrb.Label);
            if (parent == "墨迹类型")
            {
                switch (header)
                {
                    case "例2": rt2.rrbEllipseStylus.IsChecked = true; break;
                    case "例3": rt3.rrbEllipseStylus.IsChecked = true; break;
                    case "例4": rt4.rrbEllipseStylus.IsChecked = true; break;
                    case "例5": rt5.rrbEllipseStylus.IsChecked = true; break;
                    case "例6": rt6.rrbEllipseStylus.IsChecked = true; break;
                    case "例7": rt7.rrbEllipseStylus.IsChecked = true; break;
                }
            }
        }

        private void RibbonApplicationMenuItem_Click(object sender, RoutedEventArgs e)
        {
            RibbonApplicationMenuItem item = e.Source as RibbonApplicationMenuItem;
            string header = item.Header.ToString();
            if (header == "退出")
            {
                App.Current.Shutdown();
            }
            else
            {
                p.OnAppMenuItemSelected(header);
            }
        }

        private void ribbon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RibbonTab tab = ribbon.SelectedItem as RibbonTab;
            header = tab.Header.ToString();
            p = new InkPage();
            frame1.Content = p.Content;
            switch (header)
            {
                case "例2": p.Init("球形", "ink2.ink"); break;
                case "例3": p.Init("球形序列", "ink3.ink"); break;
                case "例4": p.Init("矩形和矩形序列", "ink4.ink"); break;
                case "例5": p.Init("图像和图像序列", "ink5.ink"); break;
                case "例6": p.Init("渐变直线", "ink6.ink"); break;
                case "例7": p.Init("曲线和文字", "ink7.ink"); break;
            }

        }
    }
}
