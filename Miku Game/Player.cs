using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Miku_Game 
{   


    public class Player : GameObject 
    {
        public override void Update(GameTime gameTime)
        {
            if (Velocity.X != 0)
                Velocity.X -= 10f * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (Math.Abs(Velocity.X) < 1)
                Velocity.X = 0;
            base.Update(gameTime);
        }
    }
}
