using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Miku_Game.SystemComponents;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;
using SharpDX.Direct2D1.Effects;


namespace Miku_Game.InGameObjects
{
    public class GameObject
    {
        public Rectangle Rectangle;
        public Vector2 Position = new Vector2(0, 0);
        public Vector2 Origin { get; set; }
        public Vector2 Scale { get; set; } = Vector2.One;
        public Texture2D Texture { get; set; }
        public Color Color { get; set; } = Color.White;

        public GameObject(string filePath, ContentManager content)
        {
            Console.WriteLine(content.RootDirectory);
            LoadSprite(filePath, content);
            Origin = new Vector2(Texture.Width / 2, Texture.Height / 2);

        }


        //public GameObject(string path)
        //{
        //    Texture = Content.Load.

        //    Rectangle = new Rectangle(
        //    (int)Position.X,
        //    (int)Position.Y,
        //    Texture.Width,
        //    Texture.Height);
        //}   

        public virtual void LoadSprite(string filePath, ContentManager content) => Texture = content.Load<Texture2D>(filePath);

        public virtual void Draw(SpriteBatch spriteBatch)
        {
           spriteBatch.Draw(
           Texture,
           Position,
           null,
           Color.White,
           0f,
           Origin,
           Vector2.One,
           SpriteEffects.None,
           0f);
        }

        public Rectangle Bounds
        {
            get
            {
                return new Rectangle(
                    (int)(Position.X - Origin.X * Scale.X),
                    (int)(Position.Y - Origin.Y * Scale.Y),
                    (int)(Texture.Width * Scale.X),
                    (int)(Texture.Height * Scale.Y)
                );
            }
        }

        public bool CollidesWith(GameObject other)
        {
            return Bounds.Intersects(other.Bounds);
        }
    }
}
