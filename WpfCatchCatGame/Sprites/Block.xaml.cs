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
    /// Interaction logic for Block.xaml
    /// </summary>
    public partial class Block : Sprite
    {
        public Block()
        {
            InitializeComponent();
        }

        

        private static readonly DependencyProperty ColorProperty = DependencyProperty.Register(
            nameof(Color),
            typeof(Color),
            typeof(Block),
            new PropertyMetadata((Color)ColorConverter.ConvertFromString("#b3d9ff")));

        private static readonly DependencyProperty IsWallProperty = DependencyProperty.Register(
            nameof(IsWall),
            typeof(bool),
            typeof(Block),
            new PropertyMetadata(false));

        public bool IsWall
        {
            get => (bool)GetValue(IsWallProperty);
            set => SetValue(IsWallProperty, value);
        }

        
        public Color Color
        {
            get => (Color)GetValue(ColorProperty);
            set => SetValue(ColorProperty, value);
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
