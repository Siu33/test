using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata;

namespace Sprint0
{
    public class OneFrameFixedSpriteCommand : ICommand
    {
        private Game1 myGame;

        /* Constructor */
        public OneFrameFixedSpriteCommand(Game1 game)
        {
            myGame = game;
        }

        /* Sets the character sprite to the fixed, one-frame sprite */
        public void Execute()
        {
            myGame.SetSprite(new OneFrameFixedSprite(myGame.CharacterTexture, myGame.Rows, myGame.Columns));
        }
    }
}
