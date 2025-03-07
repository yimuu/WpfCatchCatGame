using SharpVectors.Converters;
using SharpVectors.Renderers;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;


namespace WpfCatchCatGame.Sprites
{
    public enum CatDirection
    {
        BottomLeft,
        Left,
        TopLeft,
        BottomRight,
        Right,
        TopRight
    }
    public partial class Cat : Sprite
    {
        private Dictionary<CatDirection, List<Uri>> animationUris = null!;
        private double duration = 1;

        public Cat()
        {
            InitializeComponent();
            InitializeAnimationUris();
        }

        private void InitializeAnimationUris()
        {
            animationUris = new Dictionary<CatDirection, List<Uri>>()
                    {
                        { CatDirection.BottomLeft, LoadAnimationUris("bottom_left") },
                        { CatDirection.Left, LoadAnimationUris("left") },
                        { CatDirection.TopLeft, LoadAnimationUris("top_left") },
                    };

            // 其余三个方向通过翻转已有的方向得到，不需要单独的图像
            animationUris[CatDirection.BottomRight] = animationUris[CatDirection.BottomLeft];
            animationUris[CatDirection.Right] = animationUris[CatDirection.Left];
            animationUris[CatDirection.TopRight] = animationUris[CatDirection.TopLeft];
            cat.UriSource = animationUris[CatDirection.Left][0];
        }

        private List<Uri> LoadAnimationUris(string direction)
        {
            List<Uri> uris = new List<Uri>();
            for (int i = 1; i <= 5; i++)
            {
                uris.Add(new Uri($"/Assets/Images/{direction}/{i}.svg", UriKind.Relative));
            }
            return uris;
        }

        public static readonly DependencyProperty IsJumpingProperty = DependencyProperty.Register(
            nameof(IsJumping),
            typeof(bool),
            typeof(Cat),
            new PropertyMetadata(false));

        public static readonly DependencyProperty CatDirectionProperty = DependencyProperty.Register( // 使用枚举类型
            nameof(Direction),
            typeof(CatDirection),
            typeof(Cat),
            new PropertyMetadata(CatDirection.Left));

        public CatDirection Direction // 使用枚举类型
        {
            get { return (CatDirection)GetValue(CatDirectionProperty); }
            set { SetValue(CatDirectionProperty, value); }
        }

        public bool IsJumping
        {
            get { return (bool)GetValue(IsJumpingProperty); }
            set { SetValue(IsJumpingProperty, value); }
        }

        public void AnimateTo(double newX, double newY)
        {
            if (IsJumping)
            {
                return;
            }
            UpdateDirection(newX, newY);
            Storyboard storyboard = new Storyboard();
            storyboard.Completed += Storyboard_Completed;
            IsJumping = true;

            DoubleAnimation xAnimation = new DoubleAnimation
            {
                From = X,
                To = newX,
                Duration = TimeSpan.FromSeconds(duration)
            };
            DoubleAnimation yAnimation = new DoubleAnimation
            {
                From = Y,
                To = newY,
                Duration = TimeSpan.FromSeconds(duration)
            };
            Storyboard.SetTarget(xAnimation, this);
            Storyboard.SetTarget(yAnimation, this);
            Storyboard.SetTargetProperty(xAnimation, new PropertyPath("(local:Cat.X)"));
            Storyboard.SetTargetProperty(yAnimation, new PropertyPath("(local:Cat.Y)"));

            storyboard.Children.Add(xAnimation);
            storyboard.Children.Add(yAnimation);

            ObjectAnimationUsingKeyFrames jumpAnimation = new ObjectAnimationUsingKeyFrames();
            jumpAnimation.Duration = TimeSpan.FromSeconds(duration);
            List<Uri> currentAnimationSequence = animationUris[Direction];
            currentAnimationSequence.Add(animationUris[CatDirection.Left][0]);
            TimeSpan frameDuration = TimeSpan.FromSeconds(duration / currentAnimationSequence.Count);
            for (int i = 0; i < currentAnimationSequence.Count; i++)
            {
                DiscreteObjectKeyFrame keyFrame = new DiscreteObjectKeyFrame
                {
                    KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromTicks(frameDuration.Ticks * i)),
                    Value = currentAnimationSequence[i]
                };
                jumpAnimation.KeyFrames.Add(keyFrame);
            }

            Storyboard.SetTarget(jumpAnimation, cat);
            Storyboard.SetTargetProperty(jumpAnimation, new PropertyPath(SvgBitmap.UriSourceProperty));
            storyboard.Children.Add(jumpAnimation);

            storyboard.Begin();
        }
        

        private void UpdateDirection(double newX, double newY)
        {
            if (newY > Y && newY % 2 == 0)
            {
                Direction = CatDirection.BottomLeft;
            }
            else if (newY > Y && newY % 2 == 1)
            {
                Direction = CatDirection.BottomRight;
            } 
            else if (newY < Y && newY % 2 == 0)
            {
                Direction = CatDirection.TopLeft;
            }
            else if (newY < Y && newY % 2 == 1)
            {
                Direction = CatDirection.TopRight;
            }
            if (newX > X)
            {
                Direction = CatDirection.Right;
            }
            else if (newX < X)
            {
                Direction = CatDirection.Left;
            }
        }

        private void Storyboard_Completed(object? sender, EventArgs e)
        {
            IsJumping = false;
        }
    }
}