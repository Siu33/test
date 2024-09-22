using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;


// Author:Bladen Siu
//this will produce singular projectiles
namespace Sprint0
{
    public class Projectile : ISprite
    {
        private float timer;
        private Texture2D texture;
        private Vector2 velocity;
        public Vector2 position;
        private float lifespan;
        public bool projectileVisible { get; set; }
        private Animations animation;

        public Projectile(Texture2D texture, Vector2 position, Vector2 velocity, float lifespan)
        {
            this.texture = texture;
            this.position = position;
            this.velocity = velocity;
            this.lifespan = lifespan;
            this.timer = 0f;
            this.projectileVisible = true;
            animation = new Animations(texture, 1, 8, 0.1f);
        }

        /* May update the frame or position of a sprite */
        public void Update(GameTime gameTime)
        {
            if (this.projectileVisible)
            {
                /* this updates the time*/
                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                /* check if its still alive*/
                if (timer >= lifespan)
                {
                    projectileVisible = false;
                }
                /* make the projectile go forward*/
                position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

                animation.Update(gameTime);
            }



        }
        /* Draws the sprite at a specified location */
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            if (projectileVisible)
            {
                animation.Draw(spriteBatch, position);
            }
        }



    }
}