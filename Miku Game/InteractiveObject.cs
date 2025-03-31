using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Miku_Game
{

    public class InteractiveObject : GameObject
    {
        public Vector2 Velocity;
        public float CurrentSpeed { get; set; }
        public float StandartSpeed { get; set; }
        public bool IsAffectedByGravity { get; set; } = true;

        public InteractiveObject()
        {
            StandartSpeed = 700f;
            Velocity = new Vector2(0, 0);
        }

        public virtual void Update(GameTime gameTime)
        {
            if (IsAffectedByGravity && Velocity.Y < 0)
                Velocity.Y += Main.Gravity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            else if (IsAffectedByGravity)
                Velocity.Y += Main.Gravity * (float)gameTime.ElapsedGameTime.TotalSeconds * 1.5f;

            Position += Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
