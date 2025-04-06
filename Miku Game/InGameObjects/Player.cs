using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Miku_Game.SystemComponents;


namespace Miku_Game.InGameObjects
{   
    public class Player : InteractiveObject 
    {
        public Player(string filePath, ContentManager content) : base(filePath, content)
        {
        }

        public override void Update(GameTime gameTime, GraphicsDeviceManager graphic)
        {
            var kstate = Keyboard.GetState();
            var goDuration = new Vector2(0, 0);


            //if (kstate.IsKeyDown(Keys.Space) && !Miku.IsAffectedByGravity)
            //{
            //    Miku.Position.Y -= 100f;
            //    Miku.IsAffectedByGravity = false;
            //}
            if (kstate.IsKeyDown(Keys.W) && !(Position.X == Texture.Width / 2))
                goDuration.Y -= StandartSpeed;
            if (kstate.IsKeyDown(Keys.S) && !(Position.X == Texture.Width / 2))
                goDuration.Y += StandartSpeed;

            if (kstate.IsKeyDown(Keys.A) && !(Position.X == Texture.Width / 2))
                goDuration.X -= StandartSpeed;

            if (kstate.IsKeyDown(Keys.D) && !(Position.X == Main._graphics.PreferredBackBufferWidth - Texture.Width / 2))
                goDuration.X += StandartSpeed;

            if (!kstate.IsKeyDown(Keys.D) && !kstate.IsKeyDown(Keys.A))
                goDuration.X = 0;

            if (!kstate.IsKeyDown(Keys.W) && !kstate.IsKeyDown(Keys.S))
                goDuration.Y = 0;

            Velocity = goDuration;

            base.Update(gameTime, graphic);
        }
    }
}
