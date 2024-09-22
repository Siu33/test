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
	public abstract class State
	{
		#region Fields

		protected ContentManager _content;

		protected GraphicsDevice _graphicsDevice;

		protected Level _level;
		#endregion

		#region Methods
		public abstract void Draw(GameTime gameTime, SpriteBatch _spriteBatch);

		public State(Level level, GraphicsDevice graphicsDevice, ContentManager content)
		{
			_content = content;
			_level = level;
			_graphicsDevice = graphicsDevice;
		}

		public abstract void Update(GameTime gameTime);
		#endregion

	}
}
