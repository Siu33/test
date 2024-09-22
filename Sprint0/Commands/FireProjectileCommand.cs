using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace Sprint0
{
    public class FireProjectileCommand : ICommand
    {
        private Game1 myGame;
        public FireProjectileCommand(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            Vector2 position = new Vector2(400, 200); 
            Vector2 velocity = new Vector2(50, 0); 
            myGame.projectileManager.AddProjectile(myGame.fireball, position, velocity);
        }
    }
}