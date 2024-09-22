using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public class AnimatedMovingSprite : ISprite
    {
        /* Properties of the sprite to be constructed */
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        /* Keep track of time and movement */
        private float threshold;
        private float timer;
        private float velocity;
        float xPos;
        bool movingLeft;
        bool changeDir;

        /* Constructor for the particular sprite */
        public AnimatedMovingSprite(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 3;
            threshold = 200; timer = 0;
            velocity = (float)0.04;
            xPos = 0; 
            movingLeft = true; changeDir = false;
        }

        /* Moving and animated sprite so must update the sprite image (spritesheet) */
        public void Update(GameTime gameTime)
        {
            /* Changes frames to start and end at in the spritesheet based on what direction the character is moving */
            int framesToStart = 3;
            int framesToEnd = -1;
            if (!movingLeft)
            {
                framesToStart = 4;
                framesToEnd = 8;
            }

            /* Updates frame */
            if (timer > threshold || changeDir)
            {
                if (movingLeft) currentFrame--;
                else currentFrame++;
                if (currentFrame == framesToEnd)
                    currentFrame = framesToStart;
                timer = 0;
            }
            else
            {
                timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            }

            /* Updates position */
            if (movingLeft)
            {
                xPos = (xPos - (velocity * (float)gameTime.ElapsedGameTime.TotalMilliseconds));
                if (xPos <= -120)
                {
                    movingLeft = false;
                    currentFrame = 4;
                }
            }
            else
            {
                xPos = (xPos + (velocity * (float)gameTime.ElapsedGameTime.TotalMilliseconds));
                if (xPos >= 120)
                {
                    movingLeft = true;
                    currentFrame = 3;
                }   
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
            Rectangle destinationRectangle = new Rectangle((int)(location.X + xPos), (int)location.Y, width, height);
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
