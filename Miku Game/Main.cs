using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Linq;

namespace Miku_Game;

public class Main : Game
{

    public static float Gravity;
    public Player Miku;
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;



    public Main()
    {
        Miku = new();
        Gravity = 300f;
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        
    }

    protected override void Initialize()
    {
        _graphics.PreferredBackBufferWidth = (int)(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width * 0.95);
        _graphics.PreferredBackBufferHeight = (int)(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height * 0.9);
        _graphics.HardwareModeSwitch = false;
        _graphics.IsFullScreen = false;
        _graphics.ApplyChanges();
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
            Miku.Velocity.Y -= Gravity * 1.5f;
            Miku.IsAffectedByGravity = true;
        }

        if (kstate.IsKeyDown(Keys.A) && !(Miku.Position.X == Miku.Texture.Width / 2))
            Miku.Velocity.X = -Miku.StandartSpeed;

        if (kstate.IsKeyDown(Keys.D) && !(Miku.Position.X == _graphics.PreferredBackBufferWidth - Miku.Texture.Width / 2))
            Miku.Velocity.X = Miku.StandartSpeed;

        if (!kstate.IsKeyDown(Keys.D) && !kstate.IsKeyDown(Keys.A))
            Miku.Velocity.X = 0;


        if (Miku.Position.X > _graphics.PreferredBackBufferWidth - Miku.Texture.Width / 2)
        {
            Miku.Velocity.X = 0;
            Miku.Position.X = _graphics.PreferredBackBufferWidth - Miku.Texture.Width / 2;
        }

        else if (Miku.Position.X < Miku.Texture.Width / 2)
        {
            Miku.Position.X = Miku.Texture.Width / 2;
            Miku.Velocity.X = 0;
        }

        if (Miku.Position.Y > _graphics.PreferredBackBufferHeight - Miku.Texture.Height / 2 && Miku.IsAffectedByGravity)
        {
            Miku.Position.Y = _graphics.PreferredBackBufferHeight - Miku.Texture.Height / 2;
            Miku.IsAffectedByGravity = false;
            Miku.Velocity.Y = 0;
        }

        else if (Miku.Position.Y < Miku.Texture.Height / 2)
        {
            Miku.Position.Y = Miku.Texture.Height / 2;
            Miku.Velocity.Y = 0;
        }

        Miku.Update(gameTime);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.BlueViolet);

        _spriteBatch.Begin();
        _spriteBatch.Draw(
            Miku.Texture,
            Miku.Position,
            null,
            Color.White,
            0f,
            new Vector2(Miku.Texture.Width / 2, Miku.Texture.Height / 2),
            Vector2.One,
            SpriteEffects.None,
            0f
        );
        _spriteBatch.End();


        base.Draw(gameTime);
    }
}
