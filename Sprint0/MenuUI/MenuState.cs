using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections;
using System.ComponentModel.Design;
using Microsoft.Xna.Framework.Content;


namespace Sprint0
{
    public class MenuState : State
    {
        private List<ISprite> components;
        private Game1 _game;
        private bool menuVisible;

        public MenuState(Level level, GraphicsDevice graphicsDevice, ContentManager content, Game1 game) : base(level, graphicsDevice, content)
        {
            _game = game;
            var buttonTexture = content.Load<Texture2D>("Button");

            var buttonFont = content.Load<SpriteFont>("Menu");

            var startButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 200),
                Text = "Start Game",
            };
            startButton.Click += startGamebutton_Click; 
            

            var quitButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 250),
                Text = "Quit Game",
            };
            quitButton.Click += QuitGameButton_Click;
            

            this.components = new List<ISprite>()
            {
                startButton,
                quitButton,
            };

            menuVisible = true;
        }

        public override void Draw(GameTime gameTime, SpriteBatch _spriteBatch)
        {
            if (menuVisible)
            {
                foreach (var component in components)
                {
                    component.Draw(_spriteBatch, Vector2.Zero);
                }
            }
            
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in components)
            {
                component.Update(gameTime);
            }
        }



        private void startGamebutton_Click(object sender, EventArgs e)
        {
            menuVisible = false;
            _game.ShowKirby();

        }

        private void QuitGameButton_Click(object sender, EventArgs e)
        {
            _game.Exit();
        }


    }
}