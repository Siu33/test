using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;


// Author:Bladen Siu
//this will manage multiple projectiles 
namespace Sprint0
{
    public class ProjectileManager : ISprite
    {
        private List<Projectile> projectiles;
        private Texture2D projectileTexture;
        /*just a temp lifespan for now, can change later*/
        private const float lifespan = 3f;

        public ProjectileManager(Texture2D texture)
        {
            projectileTexture = texture;
            projectiles = new List<Projectile>();
        }


        public void AddProjectile(Texture2D texture, Vector2 position, Vector2 velocity)
        {
            var projectile = new Projectile(texture, position, velocity, lifespan);
            projectiles.Add(projectile);
        }


        public void Update(GameTime gameTime)
        {
            for (int i = projectiles.Count - 1; i >= 0; i--)
            {
                projectiles[i].Update(gameTime);
                /*check each projectile and see if theyre visible, if not, just remove them from list*/
                if (!projectiles[i].projectileVisible)
                {
                    projectiles.RemoveAt(i);
                }
            }
        }

        /* Draws the sprite at a specified location */
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            foreach (var projectile in projectiles)
            {
                projectile.Draw(spriteBatch, projectile.position);
            }
        }



    }
}