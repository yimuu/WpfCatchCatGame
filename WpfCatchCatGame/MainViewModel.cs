using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
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

        public MainViewModel()
        {
            InitBlocks();
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
        }
    }
}
