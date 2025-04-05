using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Miku_Game.States
{
    public abstract class Component
    {
        public abstract void Draw(GameTime gametime, SpriteBatch spriteBatch);

        public abstract void Update(GameTime gameTime);
    }
}
