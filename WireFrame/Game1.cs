using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using WireFrame.Abstract;
using WireFrame.Commands;

namespace WireFrame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        readonly GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        InputManager inputManager;
        List<Map> maps;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            maps = new List<Map>
            {
                new Map(20, 20)
            };

            //init of the keys
            var kdico = new Dictionary<Keys, Command>
            {
                { Keys.Q, new CommandLeft() },
                { Keys.D, new CommandRight() },
                { Keys.Z, new CommandUp() },
                { Keys.S, new CommandDown() },
                { Keys.A, new CommandRotateLeft() },
                { Keys.E, new CommandRotateRight() }
            };
            var gdico = new Dictionary<Buttons, Command>();
            inputManager = new InputManager(kdico, gdico);
            graphics.HardwareModeSwitch = true;
            //end of the key init
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            inputManager.HandleInput(maps);
            foreach(var map in maps)
            {
                map.Update();
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            GraphicsDevice.Clear(Color.Black);

            foreach (var map in maps)
            {
                Color[] data = new Color[1];
                Texture2D rectTexture = new Texture2D(GraphicsDevice, 1, 1);

                for (int i = 0; i < data.Length; ++i)
                    data[i] = Color.White;

                rectTexture.SetData(data);
                map.Draw(spriteBatch);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
