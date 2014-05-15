using System;
using System.Text;
using System.Windows.Forms;
using SharpDX;
using SharpDX.Direct3D11;
using SharpDX.DXGI;
using Device = SharpDX.DXGI.Device;

namespace Sharpdx1
{
    // Use these namespaces here to override SharpDX.Direct3D11
    using SharpDX.Toolkit;
    using SharpDX.Toolkit.Graphics;
    using SharpDX.Toolkit.Input;

    /// <summary>
    /// Simple Sharpdx1 game using SharpDX.Toolkit.
    /// </summary>
    public class Sharpdx1 : Game
    {
        private GraphicsDeviceManager graphicsDeviceManager;
        private SpriteBatch spriteBatch;
        private Form _form;
        int Width;
        int Height;
        SwapChain _swapChain;
        private KeyboardManager keyboard;
        private KeyboardState keyboardState;

        /// <summary>
        /// Initializes a new instance of the <see cref="Sharpdx1" /> class.
        /// </summary>
        public Sharpdx1()
        {
            // Creates a graphics manager. This is mandatory.
            graphicsDeviceManager = new GraphicsDeviceManager(this);
            // Setup the relative directory to the executable directory
            // for loading contents with the ContentManager
            Content.RootDirectory = "Content";
            
            // Initialize input keyboard system
            keyboard = new KeyboardManager(this);
        }

        protected override void Initialize()
        {
            // Modify the title of the window
            Window.Title = "Sharpdx1";         
            GraphicsDevice.Clear(Color.Black);
          //  Window.AllowUserResizing = true;
            Window.IsMouseVisible = true;
            Width = graphicsDeviceManager.PreferredBackBufferWidth;
            Height = graphicsDeviceManager.PreferredBackBufferHeight;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Instantiate a SpriteBatch
            spriteBatch = ToDisposeContent(new SpriteBatch(GraphicsDevice));
            
            // Loads a sprite font
            // The [Arial16.xml] file is defined with the build action [ToolkitFont] in the project
            
            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);


            // Get the current state of the keyboard
            keyboardState = keyboard.GetState();
        }

        protected override void Draw(GameTime gameTime)
        {
            // Use time in seconds directly
            var time = (float)gameTime.TotalGameTime.TotalSeconds;
           
          
            spriteBatch.Begin();
            
            // Display pressed keys
            var newState = keyboard.GetState();
            if (newState.IsKeyDown(Keys.C))
            {         
                GraphicsDevice.Clear(new Random().NextColor());
              
            }
            if (graphicsDeviceManager.IsFullScreen == false)
            {
            if (newState.IsKeyDown(Keys.Up))
            {
                graphicsDeviceManager.PreferredBackBufferHeight -=10;
                Height = graphicsDeviceManager.PreferredBackBufferHeight;
                graphicsDeviceManager.ApplyChanges();
            }
                if (newState.IsKeyDown(Keys.Down))
                {
                    graphicsDeviceManager.PreferredBackBufferHeight += 10;
                    Height = graphicsDeviceManager.PreferredBackBufferHeight;
                    graphicsDeviceManager.ApplyChanges();
                }
                if (newState.IsKeyDown(Keys.Left))
                {
                    graphicsDeviceManager.PreferredBackBufferWidth -= 10;
                    Width = graphicsDeviceManager.PreferredBackBufferWidth;
                    graphicsDeviceManager.ApplyChanges();
                }
                if (newState.IsKeyDown(Keys.Right))
                {
                    graphicsDeviceManager.PreferredBackBufferWidth += 10;
                    Width = graphicsDeviceManager.PreferredBackBufferWidth;
                    graphicsDeviceManager.ApplyChanges();
                }
            }
            if (newState.IsKeyDown(Keys.F4))
            {
               // GraphicsDevice.Presenter.IsFullScreen = true;
                //GraphicsDevice.Presenter.Resize(1366, 768, Format.B8G8R8A8_UNorm);
                if (graphicsDeviceManager.IsFullScreen == false)
                {
                    
                    graphicsDeviceManager.PreferredBackBufferHeight = 768;
                    graphicsDeviceManager.PreferredBackBufferWidth = 1366;
                    graphicsDeviceManager.IsFullScreen = true;
                    graphicsDeviceManager.ApplyChanges();                
                }
            }
            if (newState.IsKeyDown(Keys.F5))
            {
                //GraphicsDevice.Presenter.IsFullScreen = false;
                //GraphicsDevice.Presenter.Resize(500, 300, Format.B8G8R8A8_UNorm);
                if (graphicsDeviceManager.IsFullScreen == true)
                {
                    graphicsDeviceManager.PreferredBackBufferHeight = Height;
                    graphicsDeviceManager.PreferredBackBufferWidth = Width;
                    graphicsDeviceManager.IsFullScreen = false;
                    graphicsDeviceManager.ApplyChanges();
                }            
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }

       /* public void Resize()
        {
            this.Resize(0,0);
        }

        public void Resize(int w, int h)
        {

        }*/
       
    }
}
