using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Miku_Game
{

    public class InteractiveObject : GameObject
    {
        public Vector2 Velocity = new Vector2(0, 0);
        public float StandartSpeed { get; set; } = 900f;
        public bool IsAffectedByGravity { get; set; } = false;

        public virtual void Update(GameTime gameTime, GraphicsDeviceManager graphic)
        {
            if (IsAffectedByGravity && Velocity.Y < 0)
                Velocity.Y += Main.Gravity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            else if (IsAffectedByGravity)
                Velocity.Y += Main.Gravity * (float)gameTime.ElapsedGameTime.TotalSeconds * 1.5f;

            Position += Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

            //CheckBorders(graphic);
        }

        private void CheckBorders(GraphicsDeviceManager graphic)
        {
            if (Position.X > graphic.PreferredBackBufferWidth - Texture.Width / 2)
            {
                Velocity.X = 0;
                Position.X = graphic.PreferredBackBufferWidth - Texture.Width / 2;
            }

            else if (Position.X < Texture.Width / 2)
            {
                Position.X = Texture.Width / 2;
                Velocity.X = 0;
            }

            if (Position.Y > graphic.PreferredBackBufferHeight - Texture.Height / 2 && IsAffectedByGravity)
            {
                Position.Y = graphic.PreferredBackBufferHeight - Texture.Height / 2;
                IsAffectedByGravity = false;
                Velocity.Y = 0;
            }

            else if (Position.Y < Texture.Height / 2)
            {
                Position.Y = Texture.Height / 2;
                Velocity.Y = 0;
            }
        }
    }
}
