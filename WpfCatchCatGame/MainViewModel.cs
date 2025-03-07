using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfCatchCatGame.Sprites;

namespace WpfCatchCatGame
{
    public partial class MainViewModel : ObservableObject
    {
        public const double GridSize = 50;
        public int W { get; } = 11;
        public int H { get; } = 11;

        public double Width => GridSize * W;
        public double Height => GridSize * (H - 1);

        [ObservableProperty]
        public string statusText = "点击小圆点，围住猫";

        public List<Block> Blocks { get; } = new List<Block>();

        [ObservableProperty]
        public Cat cat = new Cat();

        public MainViewModel()
        {
            InitBlocks();
            cat.X = 5;
            cat.Y = 5;
            cat.Direction = CatDirection.Right;
        }

        private void InitBlocks()
        {
            for (int i = 0; i < W; i++)
            {
                for (int j = 0; j < H; j++)
                {
                    Block block = new Block
                    {
                        X = j,
                        Y = i
                    };
                    block.MouseLeftButtonDown += PlayerClick;
                    Blocks.Add(block);
                }          
            }
        }

        private void PlayerClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is not Block block)
            {
                return;
            }
            if (block.IsWall)
            {
                StatusText = "点击位置已经是墙了，禁止点击";
                return;
            }
            block.IsWall = true;
            StatusText = $"您点击了 ({(int)block.X}, {(int)block.Y})";

            MoveCat(Cat.X - 1, Cat.Y);
        }

        private void MoveCat(double targetX, double targetY)
        {
            // 这里可以添加更复杂的移动逻辑, 例如寻路算法
            // 简单起见，直接移动到目标位置
            Cat.AnimateTo(targetX, targetY);
        }
    }
}
