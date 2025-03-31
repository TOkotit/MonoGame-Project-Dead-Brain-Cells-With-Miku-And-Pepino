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
    public Player Miku;
    public GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;



    public Main()
    {
        Gravity = 900f;
        _graphics = new GraphicsDeviceManager(this);
        Miku = new();

        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        
    }

    protected override void Initialize()
    {
        base.Initialize();

        _graphics.PreferredBackBufferWidth = (int)(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width * 0.95);
        _graphics.PreferredBackBufferHeight = (int)(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height * 0.9);

        _graphics.HardwareModeSwitch = false;
        _graphics.IsFullScreen = false;

        _graphics.ApplyChanges();

        Miku.Position = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);


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
            Miku.Velocity.Y -= 600f;
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

        // Отладочная информация
        string debugText = $"Player position: {Miku.Position}\n" +
                         $"Texture size: {Miku.Texture?.Width}x{Miku.Texture?.Height}\n" +
                         $"Window size: {_graphics.PreferredBackBufferWidth}x{_graphics.PreferredBackBufferHeight}";

        _spriteBatch.Begin();
        Miku.Draw(_spriteBatch);

        // Для вывода текста нужно загрузить шрифт в LoadContent()
        // _spriteBatch.DrawString(_font, debugText, new Vector2(10, 10), Color.White);

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
