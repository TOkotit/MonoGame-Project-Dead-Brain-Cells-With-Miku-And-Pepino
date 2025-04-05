using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Miku_Game.SystemComponents;
using Miku_Game.States;

namespace Miku_Game.InGameObjects
{

    public class InteractiveObject : GameObject
    {
        public Vector2 Velocity = new Vector2(0, 0);
        public float StandartSpeed { get; set; } = 900f;
        public bool IsAffectedByGravity { get; set; } = false;

        public virtual void Update(GameTime gameTime, GraphicsDeviceManager graphic)
        {
            if (IsAffectedByGravity && Velocity.Y < 0)
                Velocity.Y += GameState.Gravity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            else if (IsAffectedByGravity)
                Velocity.Y += GameState.Gravity * (float)gameTime.ElapsedGameTime.TotalSeconds * 1.5f;

            Position += Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
