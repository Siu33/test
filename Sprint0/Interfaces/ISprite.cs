using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public interface ISprite
    {
        /* May update the frame or position of a sprite */
        public void Update(GameTime gameTime);
        /* Draws the sprite at a specified location */
        public void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}
