using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    internal class AnimatedFixedSprite : ISprite
    {
        /* Properties of the sprite to be constructed */
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int lastFrame;
        private float threshold;
        private float timer;

        /* Constructor for the particular sprite */
        public AnimatedFixedSprite(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 3;
            lastFrame = -1;
            threshold = 200;
            timer = 0;
        }

        /* Motionless and animated sprite so must update the sprite image (next sprite) */
        public void Update(GameTime gameTime)
        {
            if (timer > threshold)
            {
                currentFrame--;
                if (currentFrame == lastFrame)
                    currentFrame = 3;
                timer = 0;
            }
            else
            {
                timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            }
        }

        /* The location and appearence of the sprite */
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
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
