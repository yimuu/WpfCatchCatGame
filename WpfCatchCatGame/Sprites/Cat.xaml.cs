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

namespace WpfCatchCatGame.Sprites
{
    /// <summary>
    /// Interaction logic for Cat.xaml
    /// </summary>
    public partial class Cat : Sprite
    {
        public Cat()
        {
            InitializeComponent();

             
        }

        /// <summary>
        /// 实际在画板上的 X 坐标
        /// </summary>
        public double ActualX => X * GridSize + (((int)Y & 1) == 0 ? 0 : GridSize / 2);
        /// <summary>
        /// 实际在画板上的 Y 坐标
        /// </summary>
        public double ActualY => Y * GridSize - Y * 6;
    }
}
