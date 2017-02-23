using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;

namespace Duckventure
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

		Texture2D wurmi;

		Vector2 wurmiDimensions = new Vector2(60, 100);
		Vector2 wurmiPosition = new Vector2(100, 100);
		Vector2 wurmiVelocity = new Vector2();



		public Game1 ()
		{
			graphics = new GraphicsDeviceManager (this);

			graphics.PreferredBackBufferWidth = 960;
			graphics.PreferredBackBufferHeight = 720;

			Content.RootDirectory = "Content";

			IsMouseVisible = true;
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize ()
		{
			// TODO: Add your initialization logic here

			base.Initialize ();
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent ()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch (GraphicsDevice);

			//TODO: use this.Content to load your game content here 
			wurmi = Content.Load<Texture2D>("Textures/wurmi");

			}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update (GameTime gameTime)
		{
			// For Mobile devices, this logic will close the Game when the Back button is pressed
			// Exit() is obsolete on iOS
			
			//if (GamePad.GetState (PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState ().IsKeyDown (Keys.Escape))
			//	Exit ();
			KeyboardState kState = Keyboard.GetState();

			if (kState.IsKeyDown (Keys.W))
				wurmiVelocity.Y = -60;
			if (kState.IsKeyDown (Keys.A))
				wurmiVelocity += new Vector2(-800f, 0f) * (float)gameTime.ElapsedGameTime.TotalSeconds;
			if (kState.IsKeyDown (Keys.S))
				wurmiVelocity += new Vector2(0f, 50f) * (float)gameTime.ElapsedGameTime.TotalSeconds;
			if (kState.IsKeyDown (Keys.D))
				wurmiVelocity += new Vector2(800f, 0f) * (float)gameTime.ElapsedGameTime.TotalSeconds;



			//Gravity:
			if (wurmiPosition.Y <= 650)
			wurmiVelocity += new Vector2(0f, 110f * (float)gameTime.ElapsedGameTime.TotalSeconds);


			wurmiPosition += (10 * wurmiVelocity * (float)gameTime.ElapsedGameTime.TotalSeconds);

			//Träg-idy
			if (wurmiVelocity.X > 0) 
			{
				if (wurmiVelocity.X > 10f)
				{
				wurmiVelocity += new Vector2 (-80f, 0f) * (float)gameTime.ElapsedGameTime.TotalSeconds;
				}
				else 
					wurmiVelocity.X = 0;
			}
			if (wurmiVelocity.X < 0) 
			{
				if (wurmiVelocity.X < -10f) {
					wurmiVelocity += new Vector2 (80f, 0f) * (float)gameTime.ElapsedGameTime.TotalSeconds;
				} else
					wurmiVelocity.X = 0;
			}

			//Maximum Velocity X
			if (wurmiVelocity.X > 40f)
				wurmiVelocity.X = 40f;
			if (wurmiVelocity.X < -40f)
				wurmiVelocity.X = -40f;
			

			if (wurmiPosition.Y >= 650)
			//{
				wurmiVelocity.Y = 0;
			//	if (wurmiVelocity.X > 0)
			//		wurmiVelocity += new Vector2(0f, -10f * (float)gameTime.ElapsedGameTime.TotalSeconds);
			//	if (wurmiVelocity.X < 0)
			//		wurmiVelocity += new Vector2(0f, +10f * (float)gameTime.ElapsedGameTime.TotalSeconds);
				
			//}


			base.Update (gameTime);

		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw (GameTime gameTime)
		{
			graphics.GraphicsDevice.Clear (Color.Brown);
            
			//TODO: Add your drawing code here

			Vector2 wurmiCenter = wurmiDimensions / 2;


			spriteBatch.Begin();
			spriteBatch.Draw(wurmi, new Rectangle(
				(int)(wurmiPosition.X - wurmiCenter.X),
				(int)(wurmiPosition.Y - wurmiCenter.Y),
				(int)(wurmiDimensions.X),
				(int)(wurmiDimensions.Y)
			), 
				Color.White);
			spriteBatch.End();


			base.Draw (gameTime);
		}
	}
}

