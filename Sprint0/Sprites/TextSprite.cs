using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    class TextSprite : ISprite
    {
        private SpriteFont font;
        public TextSprite(SpriteFont texture)
        {
            font = texture;
        }
        public void Update(GameTime gameTime)
        {
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            spriteBatch.DrawString(font, "Credits\nProgram Made By: Tina Wang\nSprites From: https://www.spriters-resource.com/snes/\nkirbysuperstarkirbysfunpak/sheet/2898/",
            location, Color.Black);
        }

    }
}
