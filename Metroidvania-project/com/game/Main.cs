using com.mrmichelr;
using com.mrmichelr.gameplay;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace com.game
{
    public class Main : Arcade
    {

        protected override void Initialize()
        {
            Globals.DEBUGGING = true;
            setConsoleInfo();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }

        protected override void UnloadContent()
        {
            base.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            Globals.keyboard.Update();
            Globals.mouse.Update();

            //All the update here


            Globals.keyboard.UpdateOld();
            Globals.mouse.UpdateOld();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.CornflowerBlue);
            Globals.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, globalTransformation);



            Globals.spriteBatch.End();

            base.Draw(gameTime);
        }

        public void setConsoleInfo()
        {
            Globals.debug("MrMichelr Engine - code version:0.0.01", System.ConsoleColor.Green);
            Globals.debug("Monogame : Net Core 5.0", System.ConsoleColor.Green);
            

            Globals.debug("----------------------------------", System.ConsoleColor.Green);
        }


    }

    public static class Program
    {
        //[STAThread]
        static void Main()
        {
            using (var game = new Main())
                game.Run();
        }
    }

}
