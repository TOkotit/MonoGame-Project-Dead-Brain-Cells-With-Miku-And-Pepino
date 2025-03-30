using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
        Gravity = 200f;
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



        if (kstate.IsKeyDown(Keys.Up))
            Miku.Velocity.Y -= Gravity * 0.9f;

        if (kstate.IsKeyDown(Keys.Left))
            Miku.Velocity.X -= Miku.StandartSpeed;

        if (kstate.IsKeyDown(Keys.Right))
            Miku.Velocity.X += Miku.StandartSpeed;





        if (Miku.Position.X > _graphics.PreferredBackBufferWidth - Miku.Texture.Width / 2)
            Miku.Position.X = _graphics.PreferredBackBufferWidth - Miku.Texture.Width / 2;

        else if (Miku.Position.X < Miku.Texture.Width / 2)
            Miku.Position.X = Miku.Texture.Width / 2;

        if (Miku.Position.Y > _graphics.PreferredBackBufferHeight - Miku.Texture.Height / 2)
            Miku.Position.Y = _graphics.PreferredBackBufferHeight - Miku.Texture.Height / 2;

        else if (Miku.Position.Y < Miku.Texture.Height / 2)
            Miku.Position.Y = Miku.Texture.Height / 2;

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
