using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    internal class OneFrameFixedSprite : ISprite
    {
        /* Properties of the one-frame, fixed sprite */
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        /* Private fields */
        private int currentFrame;

        /* Constructor for the one-farme, fixed sprite */
        public OneFrameFixedSprite(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 3;
        }

        /* Do not have to update the sprite since it is one frame and fixed (standing still) */
        public void Update(GameTime gameTime)
        {
        }

        /* Draws the fixed, single frame sprite at the specified location */
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            /* Gets necessary dimensions */
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = currentFrame / Columns;
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
