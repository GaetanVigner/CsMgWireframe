using InputMgr;
using InputMgr.Abstract;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
        InputManager<Map> inputManager;
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

            //init of the keys
            var kdico = new Dictionary<Keys, Command<Map>>
            {
                { Keys.Q, new CommandLeft<Map>() },
                { Keys.D, new CommandRight<Map>() },
                { Keys.Z, new CommandUp<Map>() },
                { Keys.S, new CommandDown<Map>() },
                { Keys.A, new CommandRotateLeft<Map>() },
                { Keys.E, new CommandRotateRight<Map>() }
            };
            var gdico = new Dictionary<Buttons, Command<Map>>();
            inputManager = new InputManager<Map>(kdico, gdico);
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

            var sb = new StringBuilder();
            string tmp;
            using (StreamReader sr = new StreamReader("map.json"))
            {
                while ((tmp = sr.ReadLine()) != null)
                {
                    sb.Append(tmp);
                }
            }

            maps = JsonConvert.DeserializeObject<List<Map>>(sb.ToString());
            if (maps == null || (maps != null && maps.Count == 0))
            {
                maps = new List<Map>
                {
                    new Map(20, 20)
                };
            }
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            string output = JsonConvert.SerializeObject(maps);
            using (StreamWriter sw = new StreamWriter("map.json"))
            {
                sw.WriteLine(output);
            }
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
            inputManager.HandleInput(maps.FirstOrDefault());
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
