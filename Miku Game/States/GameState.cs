using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Miku_Game.SystemComponents;
using Miku_Game.InGameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Miku_Game.States
{

    class GameState : State
    {
        public static float Gravity;
        private Player Miku = new();
        private Camera Camera;
        public Texture2D bg;


        public GameState(Main game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            var _graphics = Main._graphics;
            Gravity = 900f;
            Miku.Position = new Vector2(Main._graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);
            Camera = new Camera(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            Miku.Texture = content.Load<Texture2D>("Player textures/miku_test_texture");
            bg = content.Load<Texture2D>("backgrounds/test_bg");

        }

        public override void Draw(GameTime gameTime, SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: Camera.TransformMatrix);
            _spriteBatch.Draw(
               bg,
               new Vector2(0, 0),
               null,
               Color.White,
               0f,
               new Vector2(3200, 1331),
               Vector2.One,
            SpriteEffects.None,
            0f);


            Miku.Draw(_spriteBatch);

            _spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {
        }

        public override void Update(GameTime gameTime)
        {
            var kstate = Keyboard.GetState();
            var goDuration = new Vector2(0, 0);


            //if (kstate.IsKeyDown(Keys.Space) && !Miku.IsAffectedByGravity)
            //{
            //    Miku.Position.Y -= 100f;
            //    Miku.IsAffectedByGravity = false;
            //}
            if (kstate.IsKeyDown(Keys.W) && !(Miku.Position.X == Miku.Texture.Width / 2))
                goDuration.Y -= Miku.StandartSpeed;
            if (kstate.IsKeyDown(Keys.S) && !(Miku.Position.X == Miku.Texture.Width / 2))
                goDuration.Y += Miku.StandartSpeed;

            if (kstate.IsKeyDown(Keys.A) && !(Miku.Position.X == Miku.Texture.Width / 2))
                goDuration.X -= Miku.StandartSpeed;

            if (kstate.IsKeyDown(Keys.D) && !(Miku.Position.X == Main._graphics.PreferredBackBufferWidth - Miku.Texture.Width / 2))
                goDuration.X += Miku.StandartSpeed;

            if (!kstate.IsKeyDown(Keys.D) && !kstate.IsKeyDown(Keys.A))
                goDuration.X = 0;

            if (!kstate.IsKeyDown(Keys.W) && !kstate.IsKeyDown(Keys.S))
                goDuration.Y = 0;

            Miku.Velocity = goDuration;
            Miku.Update(gameTime, Main._graphics);
            Camera.Follow(Miku.Position);

        }
    }
}
