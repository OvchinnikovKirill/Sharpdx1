using System;
using System.Text;
using System.Windows.Forms;
using SharpDX;
using SharpDX.Direct3D11;
using SharpDX.Direct3D9;
using SharpDX.DXGI;
using Device = SharpDX.DXGI.Device;
using SwapChain = SharpDX.DXGI.SwapChain;

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
        Color color= Color.Black;
        SwapChain _swapChain;
        private KeyboardManager keyboard;
        private KeyboardState keyboardState;
        FrameStatistics FPS;
        SpriteFont font;

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
            GraphicsDevice.Clear(color);
            
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
            font = Content.Load<SpriteFont>("Arial16");
            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
           

            // Get the current state of the keyboard
            
            keyboardState = keyboard.GetState();
            GraphicsDevice.Clear(color);
           
        }

        protected override void Draw(GameTime gameTime)
        {
           
            // Use time in seconds directly
            var time = (float)gameTime.TotalGameTime.TotalSeconds;
           
          
           
              // Display pressed keys
            var newState = keyboard.GetState();
            if (newState.IsKeyDown(Keys.C))
            {
                color = new Random().NextColor();
               GraphicsDevice.Clear(color);
               
            }
            if (newState.IsKeyDown(Keys.D1))
            {
                graphicsDeviceManager.PreferredRefreshRate = new Rational(60, 1);
              //  graphicsDeviceManager.ApplyChanges();
                
            }
            if (newState.IsKeyDown(Keys.D2))
            {
                graphicsDeviceManager.PreferredRefreshRate = new Rational(80, 1);
             //   graphicsDeviceManager.ApplyChanges();
            }
            if (newState.IsKeyDown(Keys.D3))
            {
                graphicsDeviceManager.PreferredRefreshRate = new Rational(60, 5);
              //  graphicsDeviceManager.ApplyChanges();
            }
            if (graphicsDeviceManager.IsFullScreen == false)
            {
            if (newState.IsKeyDown(Keys.Up))
            {
                graphicsDeviceManager.PreferredBackBufferHeight -=10;
                Height = graphicsDeviceManager.PreferredBackBufferHeight;
               // graphicsDeviceManager.ApplyChanges();
            }
                if (newState.IsKeyDown(Keys.Down))
                {
                    graphicsDeviceManager.PreferredBackBufferHeight += 10;
                    Height = graphicsDeviceManager.PreferredBackBufferHeight;
              //      graphicsDeviceManager.ApplyChanges();
                }
                if (newState.IsKeyDown(Keys.Left))
                {
                    graphicsDeviceManager.PreferredBackBufferWidth -= 10;
                    Width = graphicsDeviceManager.PreferredBackBufferWidth;
               //     graphicsDeviceManager.ApplyChanges();
                }
                if (newState.IsKeyDown(Keys.Right))
                {
                    graphicsDeviceManager.PreferredBackBufferWidth += 10;
                    Width = graphicsDeviceManager.PreferredBackBufferWidth;
               //     graphicsDeviceManager.ApplyChanges();
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
                 //   graphicsDeviceManager.ApplyChanges();                
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
                 //   graphicsDeviceManager.ApplyChanges();
                }            
            }
            graphicsDeviceManager.ApplyChanges();
            spriteBatch.Begin();
            spriteBatch.DrawString(font, graphicsDeviceManager.PreferredRefreshRate.ToString(), new Vector2(0, 0), Color.White);
          
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
