    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using System;
    using System.Collections;
    using System.Diagnostics;
    using static System.Formats.Asn1.AsnWriter;
    using System.Collections.Generic;


    namespace Sprint0
    {
        public class Game1 : Game
        {
            private GraphicsDeviceManager _graphics;
            private SpriteBatch _spriteBatch;
            /* Sprite fields */
            public ISprite CurrentSprite { get; set; }
            public Texture2D CharacterTexture { get; set; }
            public int Rows { get; set; }
            public int Columns { get; set; }
            public ISprite TextSprite { get; set; }
            private SpriteFont font;
            private Vector2 centerSpriteLocation;
            private Vector2 textSpriteLocation;
            /* Stores the allowable controllers for a player */
            private ArrayList controllerList;

            /* STATES, useless for now */
            private State _nextState; 
            private State _currentState;

            /* Make public so that ResetCommand can access */
            public bool kirbyVisible;

            private ICommand resetCommand;

            /*Projectiles*/
            public ProjectileManager projectileManager;
            public Texture2D fireball;
            public ISprite fireballSprite { get; set; }
            public int fireballRows { get; set; }
            public int fireballColumns { get; set; }
            
            public Texture2D star;
            public ISprite starSprite { get; set; }
            public int starRows { get; set; }
            public int starColumns { get; set; }

            public void ShowKirby()
            {
                kirbyVisible = true;
            }

            /*useless for now*/
            public void ChangeState(State state)
            {
                _nextState = state;
            }


            public Game1()
            {
                _graphics = new GraphicsDeviceManager(this);
                Content.RootDirectory = "Content";
                IsMouseVisible = true;
                kirbyVisible = false;
            }

            public void SetSprite(ISprite sprite)
            {
                CurrentSprite = sprite;
            }

            protected override void Initialize()
            {
                // TODO: Add your initialization logic here

                /* Add the possible controllers that can interact with the program */
                controllerList = new ArrayList
                {
                    new KeyboardController(this),
                    new MouseController(this)
                };
                /* Initialize location fields for the sprites as they will not change */
                centerSpriteLocation = new Vector2(400, 200);
                textSpriteLocation = new Vector2(100, 350);
                base.Initialize();
            }

            protected override void LoadContent()
            {
                _spriteBatch = new SpriteBatch(GraphicsDevice);

                Level level = new Level();

                _currentState = new MenuState(level, GraphicsDevice, Content, this);

                resetCommand = new ResetCommand(this);

                /*projectiles*/

                fireball = Content.Load<Texture2D>("fireball");
                fireballRows = 1;
                fireballColumns = 8;
                fireballSprite = new Animations(fireball, fireballRows, fireballColumns, 0.2f);
                projectileManager = new ProjectileManager(fireball);



            /* Loads the character spritesheet into the program */
            CharacterTexture = Content.Load<Texture2D>("Kirby_edited");
                /* The one frame fixed character sprite should be the initial center display */
                Rows = 1;
                Columns = 8;
                CurrentSprite = new OneFrameFixedSprite(CharacterTexture, Rows, Columns);

                /* Loads the font for the text into the program */
                font = Content.Load<SpriteFont>("Menu");
                TextSprite = new TextSprite(font);
            }

            protected override void Update(GameTime gameTime)
            {
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Microsoft.Xna.Framework.Input.Keyboard.GetState().IsKeyDown(Keys.Escape))
                {
                    Exit();
                }



                /*useless for now*/
                if (_nextState != null)
                {
                    _currentState = _nextState;
                    _nextState = null;
                }

                /* Updates game state based on user inputs for each controller */
                foreach (IController controller in controllerList)
                {
                    controller.Update();
                }
                _currentState.Update(gameTime);

                /*check if kirby is visible or not first*/
                if (kirbyVisible)
                {
                    /* Updates the appropriate sprite as set by a command (execute) */
                    CurrentSprite.Update(gameTime);
                }

                projectileManager.Update(gameTime);

                base.Update(gameTime);
            }

            protected override void Draw(GameTime gameTime)
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);

                // TODO: Add your drawing code here

                _spriteBatch.Begin();

                _currentState.Draw(gameTime, _spriteBatch);

                if (kirbyVisible)
                {
                    /* Draws the center character sprite and the textual information (credits, name) */
                    CurrentSprite.Draw(_spriteBatch, centerSpriteLocation);
                    TextSprite.Draw(_spriteBatch, textSpriteLocation);
                }

                projectileManager.Draw(_spriteBatch, centerSpriteLocation);


                _spriteBatch.End();

                base.Draw(gameTime);
            }

        }
    }
