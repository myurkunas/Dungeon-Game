using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using System;

namespace Dungeon_Game
{
    public class Dungeon : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D background;
        Texture2D target;
        Texture2D crosshair;
        SpriteFont gameFont;
        Vector2 targetPos = new Vector2(300, 300);
        const int targetRadius = 45;
        Random rand = new Random();

        public Dungeon()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            target = Content.Load<Texture2D>("target");
            crosshair = Content.Load<Texture2D>("crosshairs");
            background = Content.Load<Texture2D>("background");
            gameFont = Content.Load<SpriteFont>("galleryFont");

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            //GraphicsDevice.Viewport.Bounds scales the background image to fit the window.
            _spriteBatch.Draw(background, GraphicsDevice.Viewport.Bounds, Color.White);

            _spriteBatch.Draw(target, targetPos, Color.White);

            _spriteBatch.DrawString(gameFont, "test", new Vector2(100, 100), Color.White);

            _spriteBatch.Draw(crosshair, new Vector2(Mouse.GetState().X - crosshair.Width / 2,
                Mouse.GetState().Y - crosshair.Height / 2), Color.White);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}