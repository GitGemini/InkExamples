using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InkExamples
{
    /// <summary>
    /// InkPage.xaml 的交互逻辑
    /// </summary>
    public partial class InkPage : Page
    {
        public InkPage()
        {
            InitializeComponent();
        }

        public void Init(string tag, string fileName)
        {
            textBlock1.Text += tag;
            ink1.LoadInkFromFile(fileName);
            ChangeSelect("全部");
            ChangeSelect("线性渐变");
            ChangeSelect("12");
            ChangeSelect("红色");
            ChangeSelect("圆笔");
            ChangeSelect("球形");
            ink1.EditingMode = InkCanvasEditingMode.Ink;
            ink1.DefaultDrawingAttributes = new DrawingAttributes();
        }

        public void ChangeSelect(string type)
        {
            ink1.SetInkAttributes(type);
        }

        public void OnAppMenuItemSelected(string header)
        {
            if (header == "打开")
            {
                ink1.LoadInkFromFile();
            }
            else if (header == "另存为")
            {
                ink1.SaveInkToFile();
            }
        }
    }
}
