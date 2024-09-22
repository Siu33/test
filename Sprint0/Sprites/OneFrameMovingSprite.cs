using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public class OneFrameMovingSprite : ISprite
    {
        /* Properties of a one-frame, moving sprite */
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int yPos;
        private bool movingUp;

        /* Constructor for the one-frame, moving sprite */
        public OneFrameMovingSprite(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            yPos = 0; movingUp = true;
        }

        /* Updates the y position of the sprite */
        public void Update(GameTime gameTime)
        {
            if (movingUp)
            {
                yPos -= 1;
                if (yPos == -100)
                    movingUp = false;
            }
            else
            {
                yPos += 1;
                if (yPos == 100)
                    movingUp = true;
            }
        }

        /* Draws the location and appearence of the sprite one-frame, moving sprite */
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = currentFrame / Columns;
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y + yPos, width, height);
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
