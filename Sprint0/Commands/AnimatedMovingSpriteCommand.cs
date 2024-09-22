using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public class AnimatedMovingSpriteCommand : ICommand
    {
        private Game1 myGame;

        /* Constructor */
        public AnimatedMovingSpriteCommand(Game1 game)
        {
            myGame = game;
        }
        /* Sets the character sprite to the moving, animated sprite */  
        public void Execute()
        {
            myGame.SetSprite(new AnimatedMovingSprite(myGame.CharacterTexture, myGame.Rows, myGame.Columns));
        }
    }
}
