using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace JeuVaisseau
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        Random de = new Random();
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Rectangle fenetre;
        GameObject[] tableauProjectile;
        GameObject vaisseau;
        GameObject background;
        int k = 0;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            GameObject.Content = Content;    //Accès du Content dans le gameobject.

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

            base.Initialize();
            this.graphics.PreferredBackBufferWidth = graphics.GraphicsDevice.DisplayMode.Width;
            this.graphics.PreferredBackBufferHeight = graphics.GraphicsDevice.DisplayMode.Height;
            this.graphics.ToggleFullScreen();

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {


            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            GameObject.Spritebatch = spriteBatch;

            fenetre = graphics.GraphicsDevice.Viewport.Bounds;
            fenetre.Width = graphics.GraphicsDevice.DisplayMode.Width;
            fenetre.Height = graphics.GraphicsDevice.DisplayMode.Height;
            GameObject.Fenetre = fenetre;

            // TODO: use this.Content to load your game content here

            vaisseau = new Vaisseau(3, new Rectangle(800, 600, 150, 150), 10);

            background = new Background(new Rectangle(0, 0, fenetre.Width, fenetre.Height));

            tableauProjectile = new GameObject[2000];

            for (int i = 0; i < tableauProjectile.Length; i++)
            {
                tableauProjectile[i] = new Projectile(new Rectangle(de.Next(0, fenetre.Width), -500, de.Next(150, 500), de.Next(150, 500)));
            }
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

            // TODO: Add your update logic here
            vaisseau.Actualiser();

            for (int j = 0; j <= k; j++)
            {
                tableauProjectile[j].Actualiser();
            }

            if (tableauProjectile[k].Position.Y > fenetre.Height / 3)
            {
                vaisseau.DetecterCollision(tableauProjectile[k]);
                k++;
            }
        

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Yellow);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            background.Dessiner();

            if (vaisseau.DetecterCollision(tableauProjectile[k]) == false)
            {
                vaisseau.Dessiner();
                
            }

            for (int i = 0; i < tableauProjectile.Length; i++)
            {
                tableauProjectile[i].Dessiner();
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
