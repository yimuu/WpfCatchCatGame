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
            new FrameworkPropertyMetadata(new PropertyChangedCallback(OnXYChanged)));

        public static readonly DependencyProperty YProperty = DependencyProperty.Register(
                    "Y",
            typeof(double),
            typeof(Block),
            new FrameworkPropertyMetadata(new PropertyChangedCallback(OnXYChanged)));

        public static readonly DependencyProperty ActualXProperty = DependencyProperty.Register(
                    "ActualX",
            typeof(double),
            typeof(Block),
            new FrameworkPropertyMetadata(
                 (double)0,
                 FrameworkPropertyMetadataOptions.None,
                 null,
                 null
                 )
            );

        public static readonly DependencyProperty ActualYProperty = DependencyProperty.Register(
                    "ActualY",
            typeof(double),
            typeof(Block),
            new FrameworkPropertyMetadata(
                 (double)0,
                 FrameworkPropertyMetadataOptions.None,
                 null,
                 null
                 )
            );

        private static void OnXYChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Sprite sprite = (Sprite)d;
            if (e.Property == XProperty)
            {
                sprite.ActualX = sprite.X * GridSize + (((int)sprite.Y & 1) == 0 ? 0 : GridSize / 2);
            }
            if (e.Property == YProperty)
            {
                sprite.ActualY = sprite.Y * GridSize - sprite.Y * 6;
            }
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

        public double ActualX
        {
            get => (double)GetValue(ActualXProperty);
            set => SetValue(ActualXProperty, value);
        }

        public double ActualY
        {
            get => (double)(GetValue(ActualYProperty));
            set => SetValue(ActualYProperty, value);
        }
     
    }
}
