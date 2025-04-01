using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Miku_Game;

public class Main : Game
{
    public static float Gravity;
    private Player Miku;
    private Camera Camera;
    public GraphicsDeviceManager _graphics;
    private  SpriteBatch _spriteBatch;



    public Main()
    {
        Gravity = 900f;
        _graphics = new GraphicsDeviceManager(this);
       

        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        
    }

    protected override void Initialize()
    {
        Miku = new();
        

        _graphics.PreferredBackBufferWidth = (int)(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width * 0.95);
        _graphics.PreferredBackBufferHeight = (int)(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height * 0.9);

        _graphics.HardwareModeSwitch = false;
        _graphics.IsFullScreen = false;

        _graphics.ApplyChanges();

        Miku.Position = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);
        Camera = new Camera(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);

        base.Initialize();


    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        Miku.Texture = Content.Load<Texture2D>("Player textures/miku_test_texture");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                             Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        var kstate = Keyboard.GetState();



        if (kstate.IsKeyDown(Keys.Space) && !Miku.IsAffectedByGravity)
        {
            Miku.Position.Y -= 100f;
            Miku.IsAffectedByGravity = false;
        }

        if (kstate.IsKeyDown(Keys.A) && !(Miku.Position.X == Miku.Texture.Width / 2))
            Miku.Velocity.X = -Miku.StandartSpeed;

        if (kstate.IsKeyDown(Keys.D) && !(Miku.Position.X == _graphics.PreferredBackBufferWidth - Miku.Texture.Width / 2))
            Miku.Velocity.X = Miku.StandartSpeed;

        if (!kstate.IsKeyDown(Keys.D) && !kstate.IsKeyDown(Keys.A))
            Miku.Velocity.X = 0;

        Miku.Update(gameTime, _graphics);
        Camera.Follow(Miku.Position);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.BlueViolet);

        _spriteBatch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: Camera.TransformMatrix);

        _spriteBatch.Draw(
           Content.Load<Texture2D>("backgrounds/test_bg"),
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

        base.Draw(gameTime);
    }
}
