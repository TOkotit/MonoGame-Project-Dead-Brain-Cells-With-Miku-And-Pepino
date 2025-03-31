﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Miku_Game
{
    public class GameObject
    {

        public Vector2 Position = new Vector2(0, 0);
        public Texture2D Texture { get; set; }
        public Color Color { get; set; } = Color.White;

        public virtual void Draw(SpriteBatch spriteBatch)
        {
           spriteBatch.Draw(
           Texture,
           Position,
           null,
           Color.White,
           0f,
           new Vector2(Texture.Width / 2, Texture.Height / 2),
           Vector2.One,
           SpriteEffects.None,
           0f);
        }
    }
}
