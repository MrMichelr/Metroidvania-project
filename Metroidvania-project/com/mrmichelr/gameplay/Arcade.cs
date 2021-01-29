using System;
using com.mrmichelr.inputs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace com.mrmichelr.gameplay
{
    /// <summary>
    /// All you need to begin a little Game
    /// </summary>
    public class Arcade : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Vector2 baseScreenSize;

        public Matrix globalTransformation;
        int backbufferWidth, backbufferHeight;

        public Arcade()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            baseScreenSize = new Vector2(1600, 900);
        }


        protected override void Initialize()
        {
            Globals.screenWidth = (int)baseScreenSize.X; //1600
            Globals.screenHeight = (int)baseScreenSize.Y; //900

            graphics.IsFullScreen = false;

            graphics.PreferredBackBufferWidth = Globals.screenWidth;
            graphics.PreferredBackBufferHeight = Globals.screenHeight;

            graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            Globals.content = this.Content;
            Globals.spriteBatch = new SpriteBatch(GraphicsDevice);

            Globals.keyboard = new Keyboard();
            Globals.mouse = new MouseControl();

            ScalePresentationArea();

            base.LoadContent();
        }

        protected override void UnloadContent() { }

        protected override void Update(GameTime gameTime)
        {
            Globals.gameTime = gameTime;


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            


            base.Draw(gameTime);
        }

        public virtual void ExitGame(object INFO)
        {
            System.Environment.Exit(0);
        }

        public virtual void ChangeGameState(object INFO)
        {
            Globals.gameState = Convert.ToInt32(INFO, Globals.culture);
        }

        /// <summary>
        /// Work out how much we need to scale our graphics to fill the screen
        /// </summary>
        public virtual void ScalePresentationArea()
        {
            backbufferWidth = GraphicsDevice.PresentationParameters.BackBufferWidth;
            backbufferHeight = GraphicsDevice.PresentationParameters.BackBufferHeight;

            float horScaling = backbufferWidth / baseScreenSize.X;
            float verScaling = backbufferHeight / baseScreenSize.Y;

            Vector3 screenScalingFactor = new Vector3(horScaling, verScaling, 1);

            globalTransformation = Matrix.CreateScale(screenScalingFactor);

            Globals.debug("Screen Size - Width[" + GraphicsDevice.PresentationParameters.BackBufferWidth + "] — Height[" + GraphicsDevice.PresentationParameters.BackBufferHeight + "]", ConsoleColor.DarkGreen);

        }

    }
}
