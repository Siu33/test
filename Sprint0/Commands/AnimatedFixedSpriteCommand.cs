using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public class AnimatedFixedSpriteCommand : ICommand
    {
        private Game1 myGame;

        /* Constructor */
        public AnimatedFixedSpriteCommand(Game1 game)
        {
            myGame = game;
        }
        /* Sets the character sprite to the fixed, animated sprite */
        public void Execute()
        {
            myGame.SetSprite(new AnimatedFixedSprite(myGame.CharacterTexture, myGame.Rows, myGame.Columns));
        }
    }
}
