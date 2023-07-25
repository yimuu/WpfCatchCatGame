using SharpVectors.Converters;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
using System.Windows.Threading;

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

            timer.Interval = TimeSpan.FromMilliseconds(150);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        

        private DispatcherTimer timer = new();

        private int count = 1;

        private void Timer_Tick(object? sender, EventArgs e)
        {
            Uri uri = new Uri($"/Assets/Images/left/{count}.svg", UriKind.Relative);
            //SvgBitmap svgBitmap = new SvgBitmap();
            //svgBitmap.BeginInit();
            //svgBitmap.UriSource = uri;
            //svgBitmap.EndInit();
            cat.UriSource = uri;
            cat.RenderTransformOrigin = new Point(0.5, 0.5);
            X += 1;
            count = count == 5 ? 2 : count + 1;
        }
    }
}
