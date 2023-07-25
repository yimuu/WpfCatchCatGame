using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfCatchCatGame.Sprites
{
    public class Sprite : UserControl
    {
        public const double GridSize = MainViewModel.GridSize;

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
                    "X",
            typeof(double),
            typeof(Block),
            new FrameworkPropertyMetadata(
                 (double)0,
                 FrameworkPropertyMetadataOptions.None,
                 null,
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

     
    }
}
