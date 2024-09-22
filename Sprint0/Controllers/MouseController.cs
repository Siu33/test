using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace Sprint0
{
    public class MouseController : IController
    {
        private Game1 myGame;
        public ICommand currentCommand { get; private set; }
        public MouseController(Game1 game)
        {
            myGame = game;
        }

        public void Update()
        {
            currentCommand = new NoCommand();
            /* Get state of the mouse clicks (right or left) and its position on the screen */
            MouseState currentMouseState = Mouse.GetState();
            Rectangle screenDimensions = myGame.GraphicsDevice.Viewport.Bounds;
            int half_screen_width = screenDimensions.Width / 2;
            int half_screen_height = screenDimensions.Height / 2;

            /* If-else statements to determine what command to execute based on button pressed and mouse position */
            if (currentMouseState.RightButton == ButtonState.Pressed)
            {
                currentCommand = new ExitCommand(myGame);
            }
            else if (currentMouseState.LeftButton == ButtonState.Pressed)
            {
                /* Look at x and y positions of the mouse */
                if ((currentMouseState.X < half_screen_width) && (currentMouseState.Y < half_screen_height))
                {
                    currentCommand = new OneFrameFixedSpriteCommand(myGame);
                }
                else if ((currentMouseState.X > half_screen_width) && (currentMouseState.Y < half_screen_height))
                {
                    currentCommand = new AnimatedFixedSpriteCommand(myGame);
                }
                else if ((currentMouseState.X < half_screen_width) && (currentMouseState.Y > half_screen_height))
                {
                    currentCommand = new OneFrameMovingSpriteCommand(myGame);
                }
                else if ((currentMouseState.X > half_screen_width) && (currentMouseState.Y > half_screen_height))
                {
                    currentCommand = new AnimatedMovingSpriteCommand(myGame);
                }
            }
            currentCommand.Execute();
        }
    }
}
