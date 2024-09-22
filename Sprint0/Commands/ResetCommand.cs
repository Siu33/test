using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    internal class ResetCommand : ICommand
    {
        private Game1 _game;
        
        public ResetCommand (Game1 game)
        {
            _game = game;
        }
        public void Execute()
        {
            _game.CurrentSprite = null;
            _game.kirbyVisible = false;
            _game.ChangeState(new MenuState(new Level(), _game.GraphicsDevice, _game.Content, _game));

        }
    }
}
