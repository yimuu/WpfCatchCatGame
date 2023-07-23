using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfCatchCatGame.Sprites;

namespace WpfCatchCatGame
{
    public class MainViewModel
    {
        
        public int Width { get; } = 11;
        public int Height { get; } = 11;

        public List<Block> Blocks { get; } = new List<Block>();

        public MainViewModel()
        {
            InitBlocks();
        }

        private void InitBlocks()
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    Blocks.Add(new Block
                    {
                        X = i,
                        Y = j
                    });
                }
            }
        }
    }
}
