using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Miku_Game.InGameObjects;
using Miku_Game.States;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Miku_Game.SystemComponents;

public class Main : Game
{
    public static GraphicsDeviceManager _graphics;
    private  SpriteBatch _spriteBatch;

    private State _currentState;

    private State _nextState;

    public void ChangeState(State state)
    {
        _nextState = state;
    }



    public Main()
    {
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

        _currentState = new MenuState(this, _graphics.GraphicsDevice, Content);


    }

    protected override void Update(GameTime gameTime)
    {
            if (_nextState != null)
        {
            _currentState = _nextState;
            _nextState = null;
        }
        _currentState.Update(gameTime);

        _currentState.PostUpdate(gameTime);
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                             Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        base.Update(gameTime);
    }
    
    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.BlueViolet);

        _currentState.Draw(gameTime, _spriteBatch);

        base.Draw(gameTime);
    }
}
