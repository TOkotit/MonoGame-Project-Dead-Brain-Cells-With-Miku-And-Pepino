using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;


namespace Miku_Game
{
    public class GameObject
    {

        public Vector2 Position;
        public Vector2 Velocity; // Скорость по X и Y
        public Texture2D Texture { get; set; }

        public float CurrentSpeed { get; set; }
        public float StandartSpeed { get; set; }
        public float MaxSpeed { get; set; }
        public Color Color { get; set; } = Color.White;
        public bool IsAffectedByGravity { get; set; } = true;

        public GameObject()
        {
            StandartSpeed = 100f;
            MaxSpeed = 400f;
            Position = new Vector2(0, 0);
            Velocity = new Vector2(0, 0);
        }
        public virtual void Update(GameTime gameTime)
        {
            if (IsAffectedByGravity)
                Velocity.Y += Main.Gravity * (float)gameTime.ElapsedGameTime.TotalSeconds;

            Position += Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }
    }
}
