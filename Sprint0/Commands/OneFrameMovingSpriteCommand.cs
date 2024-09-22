using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public class OneFrameMovingSpriteCommand : ICommand
    {
        private Game1 myGame;

        /* Constructor */
        public OneFrameMovingSpriteCommand(Game1 game)
        {
            myGame = game;
        }
        /* Sets the character sprite to the moving, one-frame sprite */
        public void Execute()
        {
            myGame.SetSprite(new OneFrameMovingSprite(myGame.CharacterTexture, myGame.Rows, myGame.Columns));
        }
    }
}
