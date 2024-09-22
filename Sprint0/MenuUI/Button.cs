using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;


// Author:Bladen Siu
namespace Sprint0
{
    public class Button : ISprite
    {
        #region Fields

        private MouseState currentMouse;
        private SpriteFont font;
        private bool isHovering;
        private MouseState previousMouse;
        private Texture2D texture;
        #endregion

        #region Properties
        public event EventHandler Click;
        public string Text { get; set; }
        public bool Clicked { get; private set; }
        public Color penColor { get; set; }
        public Vector2 Position { get; set; }
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, texture.Width, texture.Height);
            }
        }

        #endregion

        #region Methods
        public Button(Texture2D texture, SpriteFont font)
        {
            this.texture = texture;
            this.font = font;
            penColor = Color.Black;
        }
        
        public void Draw(SpriteBatch _spriteBatch, Vector2 location)
        {
            var color = Color.White;

            if (isHovering)
                color = Color.Gray;

            _spriteBatch.Draw(texture, Rectangle, color);

            if (!string.IsNullOrEmpty(Text))
            {
                var x = (Rectangle.X + (Rectangle.Width / 2)) - (font.MeasureString(Text).X / 2);
                var y = (Rectangle.Y + (Rectangle.Height / 2)) - (font.MeasureString(Text).Y / 2);

                _spriteBatch.DrawString(font, Text, new Vector2(x, y), penColor);
            }
        }

        public void Update(GameTime gameTime)
        {
            previousMouse = currentMouse;
            currentMouse = Mouse.GetState();
            var mouseRectangle = new Rectangle(currentMouse.X, currentMouse.Y, 1, 1);
            isHovering = false;

            if (mouseRectangle.Intersects(Rectangle))
            {
                isHovering = true;
                if(currentMouse.LeftButton == ButtonState.Released && previousMouse.LeftButton == ButtonState.Pressed)
                {
                    Click?.Invoke(this, new EventArgs());
                }
            }
        }
        #endregion
    }
}
