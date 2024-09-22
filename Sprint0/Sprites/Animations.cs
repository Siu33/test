using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//used this quick class from my own sprint 0, just animates frames for fireball
namespace Sprint0
{
    public class Animations : ISprite
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int totalFrames;
        private double timePerFrame;
        private double timer;

        public Animations(Texture2D texture, int rows, int columns, double timePerFrame)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            this.currentFrame = 0;
            this.totalFrames = Rows * Columns;
            this.timePerFrame = timePerFrame;
            this.timer = 0;

        }

        public void Update(GameTime gameTime)
        {
            timer += gameTime.ElapsedGameTime.TotalSeconds;
            if(timer > timePerFrame)
            {
                currentFrame++;
                timer -= timePerFrame;
                if(currentFrame >= totalFrames)
                {
                    currentFrame = 0;
                }
            }
        }
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
