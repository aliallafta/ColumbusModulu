using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ColumbusModulu
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D snakeTexture;
        Rectangle snakeRect;
        Vector2 snakeSpeed;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {
            snakeSpeed = new Vector2(10, 0);

            base.Initialize();
        }

        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);
            snakeTexture = Content.Load<Texture2D>("Body2");
            snakeRect = new Rectangle(200, 20, 20, 20);
        }


        protected override void UnloadContent()
        {

        }


        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            snakeRect.X = (Window.ClientBounds.Width - ((snakeRect.X + (int)(snakeSpeed.X)) * -1)) % Window.ClientBounds.Width;
            snakeRect.Y = (Window.ClientBounds.Height - ((snakeRect.Y + (int)(snakeSpeed.Y)) * -1)) % Window.ClientBounds.Height;

            KeyboardState kbs = Keyboard.GetState();
            if (kbs.IsKeyDown(Keys.Down))
                snakeSpeed = new Vector2(0, 10);
            else if (kbs.IsKeyDown(Keys.Up))
                snakeSpeed = new Vector2(0, -10);
            else if (kbs.IsKeyDown(Keys.Left))
                snakeSpeed = new Vector2(-10, 0);
            else if (kbs.IsKeyDown(Keys.Right))
                snakeSpeed = new Vector2(10, 0);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(snakeTexture, snakeRect, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
