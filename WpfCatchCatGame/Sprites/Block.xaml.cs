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
    public partial class Block : UserControl
    {
        public Block()
        {
            InitializeComponent();
        }

        public const double GridSize = 50;

        private static readonly DependencyProperty RadiusProperty = DependencyProperty.Register(
                    nameof(Radius),
            typeof(double),
            typeof(Block),
            new FrameworkPropertyMetadata(
                 GridSize * 0.9,
                 FrameworkPropertyMetadataOptions.None,
                 null,
                 null
                 )
            );

        public static readonly DependencyProperty XProperty = DependencyProperty.Register(
                    "X", //属性名
            typeof(double),
            typeof(Block),
            new FrameworkPropertyMetadata(
                 (double)0,
                 FrameworkPropertyMetadataOptions.None, //不特定界面修改
                                                        //不需要属性改变回调
                 null,//new PropertyChangedCallback(QXSpiritInvalidated),
                      //不使用强制回调
                 null
                 )
            );

        public static readonly DependencyProperty YProperty = DependencyProperty.Register(
                    "Y",
            typeof(double),
            typeof(Block),
            new FrameworkPropertyMetadata(
                 (double)0,
                 FrameworkPropertyMetadataOptions.None,
                 null,
                 null
                 )
            );

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

        public double Radius
        {
            get => (double)GetValue(RadiusProperty);
            set => SetValue(RadiusProperty, value);
        }
        /// <summary>
        /// 精灵X坐标(关联属性)
        /// </summary>
        public double X
        {
            get => (double)GetValue(XProperty);
            set => SetValue(XProperty, value);
        }
        /// <summary>
        /// 精灵Y坐标(关联属性)
        /// </summary>
        public double Y
        {
            get => (double)GetValue(YProperty);
            set => SetValue(YProperty, value);
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
