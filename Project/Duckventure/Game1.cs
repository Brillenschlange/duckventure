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

		int DisplaySizeX = 920;
		int DisplaySizeY = 720;

		int intro = 0;
		int JumpCounter = 1;
		KeyboardState formerkState;
		//enti.Height / 2

		Vector2 weltVector = new Vector2(0,0);

		//Position relative to World
		Vector2 entiRealPosition = new Vector2(-800,500);

		//Postion relative to Window
		Vector2 entiDisplayPosition = new Vector2(-800, 500);
		Vector2 entiVelocity = new Vector2();
		Vector2 entiScale = new Vector2(0.7f,0.7f);
		SpriteEffects entiMirror = SpriteEffects.None;
		Map level;


		public Game1 ()
		{
			graphics = new GraphicsDeviceManager (this);

			graphics.PreferredBackBufferWidth = DisplaySizeX;
			graphics.PreferredBackBufferHeight = DisplaySizeY;

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

			level = Map.Load("Content/Map/Map");

			}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update (GameTime gameTime)
		{
			// For Mobile devices, this logic will close the Gamae when the Back button is pressed
			// Exit() is obsolete on iOS
			
			//if (GamePad.GetState (PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState ().IsKeyDown (Keys.Escape))
			//	Exit ();
			KeyboardState kState = Keyboard.GetState ();
			if (intro == 1){
			if (kState.IsKeyDown (Keys.W) && formerkState.IsKeyUp (Keys.W)) {
				if (entiRealPosition.Y >= DisplaySizeY - ((enti.Height * entiScale.Y) / 2)) {
					entiVelocity.Y = -60;
					JumpCounter = 0;
				} else if (JumpCounter < 2) {
					entiVelocity.Y = -60;
					JumpCounter += 1;
				}
			}
			if (kState.IsKeyDown (Keys.A))
				entiVelocity += new Vector2 (-800f, 0f) * (float)gameTime.ElapsedGameTime.TotalSeconds;
			if (kState.IsKeyDown (Keys.S))
				entiVelocity += new Vector2 (0, 150f) * (float)gameTime.ElapsedGameTime.TotalSeconds;
			if (kState.IsKeyDown (Keys.D))
				entiVelocity += new Vector2 (800f, 0f) * (float)gameTime.ElapsedGameTime.TotalSeconds;
			}
			if (kState.IsKeyDown (Keys.Space)) {
				//entiDimensions = new Vector2 (103, 99);
				entiScale = new Vector2 (0.07f, 0.07f);
				intro = 1;
			}
//			if (kState.IsKeyDown (Keys.Right)) {
//				//entiDimensions = new Vector2 (103, 99);
//				weltVector.X += 20;
//
//			}
//
//			if (kState.IsKeyDown (Keys.Left)) {
//				//entiDimensions = new Vector2 (103, 99);
//				weltVector.X -= 20;
//
//			}



			//Gravity:
		
			if (entiRealPosition.Y <= 650) {
				if (intro == 1)
				entiVelocity += new Vector2 (0f, 110f * (float)gameTime.ElapsedGameTime.TotalSeconds);
			}

			entiRealPosition += (10 * entiVelocity * (float)gameTime.ElapsedGameTime.TotalSeconds);

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


			//BODEN
			if (entiRealPosition.Y >= DisplaySizeY - ((enti.Height * entiScale.Y) / 2)) {
				entiVelocity.Y = 0;
				if (intro == 1) {
					entiRealPosition.Y = (float)DisplaySizeY - ((enti.Height * entiScale.Y) / 2);
				}
			}
			
			//	if (entiVelocity.X > 0)
			//		entiVelocity += new Vector2(0f, -10f * (float)gameTime.ElapsedGameTime.TotalSeconds);
			//	if (entiVelocity.X < 0)
			//		entiVelocity += new Vector2(0f, +10f * (float)gameTime.ElapsedGameTime.TotalSeconds);
				
			//}

			if (entiVelocity.X < 0)
				entiMirror = SpriteEffects.FlipHorizontally;
			if (entiVelocity.X > 0)
				entiMirror = SpriteEffects.None;


			//Scrolling
			entiDisplayPosition.X = entiRealPosition.X - weltVector.X;
			entiDisplayPosition.Y = entiRealPosition.Y - weltVector.Y;

			if (intro == 1) {
				if (entiDisplayPosition.X > DisplaySizeX) { 
					weltVector += new Vector2 (DisplaySizeX, 0);
				} else if (entiDisplayPosition.X < 0) {
					weltVector -= new Vector2 (DisplaySizeX, 0);
				}
			}






			//Startanimation
			if (gameTime.TotalGameTime.TotalSeconds < 2)
				entiVelocity.X = 40f;
				

			formerkState = kState;


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

			for (int y = 0; y < Map.MAPHEIGHT; y++) 
			{
				for (int x = 0; x < Map.MAPWIDTH; x++) 
				{
					if (level.Cells [x, y] == CellType.Platform)
						spriteBatch.Draw(enti, new Rectangle(x* 20 - (int)weltVector.X,y* 20 - (int)weltVector.Y, 20, 20), Color.White);
					
				}
			}

			spriteBatch.Draw(enti, new Vector2(
				(int)(entiDisplayPosition.X),
				(int)(entiDisplayPosition.Y)
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

