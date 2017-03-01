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

		Texture2D enti;

		//Vector2 entiDimensions = new Vector2(1440, 1387);
		Vector2 entiPosition = new Vector2(100, 100);
		Vector2 entiVelocity = new Vector2();
		Vector2 entiScale = new Vector2(1,1);
		SpriteEffects entiMirror = SpriteEffects.None;


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
			enti = Content.Load<Texture2D>("Textures/enti");

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
				entiVelocity.Y = -60;
			if (kState.IsKeyDown (Keys.A))
				entiVelocity += new Vector2(-800f, 0f) * (float)gameTime.ElapsedGameTime.TotalSeconds;
			if (kState.IsKeyDown (Keys.S))
				entiVelocity += new Vector2(0f, 50f) * (float)gameTime.ElapsedGameTime.TotalSeconds;
			if (kState.IsKeyDown (Keys.D))
				entiVelocity += new Vector2(800f, 0f) * (float)gameTime.ElapsedGameTime.TotalSeconds;
			if (kState.IsKeyDown (Keys.Space))
				//entiDimensions = new Vector2 (103, 99);
				entiScale = new Vector2 (0.07f, 0.07f);
			


			//Gravity:
			if (entiPosition.Y <= 650)
			entiVelocity += new Vector2(0f, 110f * (float)gameTime.ElapsedGameTime.TotalSeconds);


			entiPosition += (10 * entiVelocity * (float)gameTime.ElapsedGameTime.TotalSeconds);

			//Träg-idy
			if (entiVelocity.X > 0) 
			{
				if (entiVelocity.X > 10f)
				{
				entiVelocity += new Vector2 (-80f, 0f) * (float)gameTime.ElapsedGameTime.TotalSeconds;
				}
				else 
					entiVelocity.X = 0;
			}
			if (entiVelocity.X < 0) 
			{
				if (entiVelocity.X < -10f) {
					entiVelocity += new Vector2 (80f, 0f) * (float)gameTime.ElapsedGameTime.TotalSeconds;
				} else
					entiVelocity.X = 0;
			}

			//Maximum Velocity X
			if (entiVelocity.X > 40f)
				entiVelocity.X = 40f;
			if (entiVelocity.X < -40f)
				entiVelocity.X = -40f;
			

			if (entiPosition.Y >= 650)
			//{
				entiVelocity.Y = 0;
			//	if (entiVelocity.X > 0)
			//		entiVelocity += new Vector2(0f, -10f * (float)gameTime.ElapsedGameTime.TotalSeconds);
			//	if (entiVelocity.X < 0)
			//		entiVelocity += new Vector2(0f, +10f * (float)gameTime.ElapsedGameTime.TotalSeconds);
				
			//}

			if (entiVelocity.X < 0)
				entiMirror = SpriteEffects.FlipHorizontally;
			if (entiVelocity.X > 0)
				entiMirror = SpriteEffects.None;


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

			//Vector2 entiCenter = entiDimensions / 2;


			spriteBatch.Begin();
			spriteBatch.Draw(enti, new Vector2(
				(int)(entiPosition.X),
				(int)(entiPosition.Y)
				//(int)(entiDimensions.X),
				//(int)(entiDimensions.Y)
			), null,
				Color.White,
			0,
				new Vector2(enti.Width / 2,enti.Height / 2),
				entiScale,
				entiMirror,
			0);
			spriteBatch.End();


			base.Draw (gameTime);
		}
	}
}

