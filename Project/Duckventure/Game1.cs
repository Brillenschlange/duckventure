using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

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
        Texture2D space;
        Texture2D sharkjump;
        Texture2D copyright;
        Texture2D howtoplay;
        Texture2D howtoplaystart;
        Texture2D lifelost;
		List<Texture2D> numbers;
//        Texture2D zero;
//        Texture2D one;
//        Texture2D two;
//        Texture2D three;
//        Texture2D four;
//        Texture2D five;
//        Texture2D six;
//        Texture2D seven;
//        Texture2D eight;
//        Texture2D nine;
		Texture2D sharkifin;
		Texture2D shark;
        Texture2D keyA;
        Texture2D keyD;
        Texture2D keyS;
        Texture2D keyW;
        Texture2D water1;
        Texture2D water2;
        Texture2D platform1;
        Texture2D platform2;
        Texture2D platform3;

        int DisplaySizeX = 920;
		int DisplaySizeY = 720;

        int CellSizeX = 20;
        int CellSizeY = 20;

        int MAPWIDTH = 138;
        int MAPHEIGHT = 36;

		int intro = 0;
		int JumpCounter = 1;
        int LifeLostCounter = 0;
        int howtoplayCounter = 0;
        int pCounter = 0;
        int sharkAktion = 0;
		float sharktimer = 0;
			
		KeyboardState formerkState;

		Vector2 weltVector = new Vector2(0,0);

		//Position relative to World
		Vector2 entiRealPosition = new Vector2(-800,500);
		Vector2 sharkiRealPosition = new Vector2 ();
		Vector2 sharkRealPosition = new Vector2 (0, 720);

		//Postion relative to Window
		Vector2 entiDisplayPosition = new Vector2(-800, 500);
		Vector2 entiVelocity = new Vector2();
		Vector2 entiScale = new Vector2(0.7f,0.7f);
		SpriteEffects entiMirror = SpriteEffects.None;

		SpriteEffects sharkiMirror = SpriteEffects.None;


		Vector2 sharkiDisplayPosition = new Vector2 ();
		Vector2 sharkiVelocity = new Vector2 ();

		Vector2 sharkDisplayPosition = new Vector2 ();
        Vector2 sharkJump = new Vector2();


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
            space = Content.Load<Texture2D>("Textures/start-space");
            sharkjump = Content.Load<Texture2D>("Textures/shark");
            howtoplay = Content.Load<Texture2D>("Textures/howtoplay");
            howtoplaystart = Content.Load<Texture2D>("Textures/howtoplaystart");
            copyright = Content.Load<Texture2D>("Textures/copyright");
            lifelost = Content.Load<Texture2D>("Textures/lifelost");

			numbers = new List<Texture2D> ();
			for (int i = 0; i <= 9; i++)
				numbers.Add (Content.Load<Texture2D> ("Textures/" + i));
            
			sharkifin = Content.Load<Texture2D> ("Textures/sharkfin");
			shark = Content.Load<Texture2D> ("Textures/shark");
            keyA = Content.Load<Texture2D>("Textures/keyA");
            keyD = Content.Load<Texture2D>("Textures/keyD");
            keyS = Content.Load<Texture2D>("Textures/keyS");
            keyW = Content.Load<Texture2D>("Textures/keyW");
            water1 = Content.Load<Texture2D>("Textures/water1");
            water2 = Content.Load<Texture2D>("Textures/water2");
            platform1 = Content.Load<Texture2D>("Textures/platform1");
            platform2 = Content.Load<Texture2D>("Textures/platform2");
            platform3 = Content.Load<Texture2D>("Textures/platform3");


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

			
            //Keys
			KeyboardState kState = Keyboard.GetState ();

			if (intro == 0)
            {
                if (kState.IsKeyDown(Keys.Space))
                {
                    entiScale = new Vector2(0.07f, 0.07f);
                    intro = 2;
                }
                if (kState.IsKeyDown(Keys.P) && formerkState.IsKeyUp(Keys.P))
                {
                    if (pCounter == 0)
                    {
                        intro = 1;
                        howtoplayCounter = 1;
                        entiScale = new Vector2(0.07f, 0.07f);
                        entiRealPosition = new Vector2(200, 465);
                        pCounter += 1;
                    }
                }   
            }
            
            if (intro == 2)
            {
			    if (kState.IsKeyDown (Keys.W) && formerkState.IsKeyUp (Keys.W))
                {
				    if (entiRealPosition.Y >= DisplaySizeY + ((enti.Height * entiScale.Y)))
                    {
					    entiVelocity.Y = -60;
					    JumpCounter = 1;
				    }
                    else if (JumpCounter < 2)
                    {
					    entiVelocity.Y = -60;
					    JumpCounter += 1;
				    }
			    }
                if (kState.IsKeyDown(Keys.A))
                {
                    entiVelocity += new Vector2(-800f, 0f) * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
                if (kState.IsKeyDown(Keys.S))
                {
                    entiVelocity += new Vector2(0, 150f) * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
                if (kState.IsKeyDown(Keys.D))
                {
                    entiVelocity += new Vector2(800f, 0f) * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
			}

            formerkState = kState;

            //Startanimation (for Enti)
			if (gameTime.TotalGameTime.TotalSeconds < 2)
				entiVelocity.X = 40f; 	

            //HowToPlay (for Enti)
            if (intro == 1)
            {
                if (howtoplayCounter == 1)
                {
                    entiVelocity.X = 0;
                    entiVelocity += new Vector2(10, 0);
                }
                if (howtoplayCounter == 1)
                {
                    if (entiDisplayPosition.X >= DisplaySizeX / 4 * 3)
                    {
                        entiVelocity.X = 0;
                        howtoplayCounter = 2;
                    }
                }
                if (howtoplayCounter == 2)
                {
                    entiVelocity += new Vector2(-10, 0);
                    entiMirror = SpriteEffects.FlipHorizontally;
                }
                if (howtoplayCounter == 2)
                {
                    if (entiDisplayPosition.X <= DisplaySizeX / 2)
                    {
                        entiVelocity.X = 0;
                        howtoplayCounter = 3;
                    }
                }
                if (howtoplayCounter == 3)
                {
                    entiRealPosition += new Vector2(0f, -10f);
                }

                if (howtoplayCounter == 3)
                {
                    if (entiRealPosition.Y <= 300)
                    {
                        entiRealPosition.Y = 300;
                        howtoplayCounter = 4;
                    }
                }
                if (howtoplayCounter == 4)
                {
                    if (entiRealPosition.Y >= 465)
                    {
                        entiVelocity = new Vector2(0, 0);
                        entiRealPosition.Y = 465;
                        howtoplayCounter = 5;
                    }
                }
                if (howtoplayCounter == 5)
                {
                    entiRealPosition += new Vector2(0f, -10f);
                }

                if (howtoplayCounter == 5)
                {
                    if (entiRealPosition.Y <= 300)
                    {
                        entiRealPosition.Y = 300;
                        howtoplayCounter = 6;
                    }
                }
                if (howtoplayCounter == 6)
                {
                    if (entiRealPosition.Y >= 465)
                    {
                        entiVelocity = new Vector2(0, 0);
                        entiRealPosition.Y = 465;
                        howtoplayCounter = 7;
                    }
                }
                if (howtoplayCounter == 7)
                { 
                    intro = 0;
                    entiRealPosition = new Vector2(80, 500);
                    entiScale = new Vector2(0.7f,0.7f);
                    entiMirror = SpriteEffects.None;
                    pCounter -= 1;
                    howtoplayCounter = 8;      
                }
             }

            //Enti

                //Gravity
		
			if (entiRealPosition.Y <= 650)
            {
                if (intro == 2)
                {
                    entiVelocity += new Vector2(0f, 110f * (float)gameTime.ElapsedGameTime.TotalSeconds);
                }
                if (intro == 1)
                {
                    if (howtoplayCounter == 3)
                    {
                        entiVelocity += new Vector2(0f, 110f * (float)gameTime.ElapsedGameTime.TotalSeconds);
                    }
                    if (howtoplayCounter == 5)
                    {
                        entiVelocity += new Vector2(0f, 110f * (float)gameTime.ElapsedGameTime.TotalSeconds);
                    }
                }

            }

            entiRealPosition += (10 * entiVelocity * (float)gameTime.ElapsedGameTime.TotalSeconds);
			sharkiRealPosition += (5 * sharkiVelocity * (float)gameTime.ElapsedGameTime.TotalSeconds);
			sharkRealPosition += (10 * sharkJump * (float)gameTime.ElapsedGameTime.TotalSeconds);

                //Inertia

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
			if (sharkiVelocity.X > 160f)
				sharkiVelocity.X = 160f;
			if (sharkiVelocity.X < -160f)
				sharkiVelocity.X = -160f;

                //Rotation on Display

			if (entiVelocity.X < 0)
				entiMirror = SpriteEffects.FlipHorizontally;
			if (entiVelocity.X > 0)
				entiMirror = SpriteEffects.None;

				//Sharki Rotation
			if (sharkiVelocity.X < 0)
				sharkiMirror = SpriteEffects.FlipHorizontally;
			if (sharkiVelocity.X > 0)
				sharkiMirror = SpriteEffects.None;

                //LifeLostCounter +1

            if (intro == 2)
                if (entiRealPosition.Y >= DisplaySizeY + ((enti.Height * entiScale.Y))) {
                    entiRealPosition = new Vector2(0, 500);
                    LifeLostCounter += 1;
            }

                //Border left

            if (intro == 2)
                if (entiRealPosition.X < 0 + enti.Width*entiScale.X/2)
                    entiRealPosition.X = 0 + enti.Width*entiScale.X/2;

                //Border right

            if (intro == 2)
                if (entiRealPosition.X > MAPWIDTH * CellSizeX - enti.Width * entiScale.X / 2)
                    entiRealPosition.X = MAPWIDTH * CellSizeX - enti.Width * entiScale.X / 2;
		

            //Sharkifin

                //Shark-idy

            if (intro == 2) {
				if (sharkiRealPosition.X < entiRealPosition.X)
					sharkiVelocity += new Vector2 (400f, 0f) * (float)gameTime.ElapsedGameTime.TotalSeconds;
				if (sharkiRealPosition.X > entiRealPosition.X)
					sharkiVelocity += new Vector2 (-400f, 0f) * (float)gameTime.ElapsedGameTime.TotalSeconds;
				}


            //Shark


				


                //Shark-Jump
                   	
			if (intro == 2)
			{
				if (sharkAktion == 0)
				{
					sharktimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
					if (sharktimer >= 8)
					{
						sharkAktion += 1;
						sharktimer = 0;
					}
					}
				if (sharkAktion == 1) 
				{	
					sharkRealPosition.X = entiRealPosition.X;
					sharkAktion = 2;
				}
				if (sharkAktion == 2)
				{
                    sharkRealPosition += new Vector2(0, -200f) * (float)gameTime.ElapsedGameTime.TotalSeconds;
					if (sharkRealPosition.Y < DisplaySizeY/2)
                    {
						sharkRealPosition.Y = DisplaySizeY/2;
                        
                        sharkAktion = 3;
                    } 
                }
                if (sharkAktion == 3)
                {
                    sharkRealPosition += new Vector2(0f, 200f) * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    if (sharkRealPosition.Y > DisplaySizeY)
                    {
                        sharkRealPosition = new Vector2(0,720 + weltVector.X);
                        sharkAktion = 0;
                    }
                }
            }
			
		    //Scrolling

            entiDisplayPosition.X = entiRealPosition.X - weltVector.X;
			entiDisplayPosition.Y = entiRealPosition.Y - weltVector.Y;

			if (intro == 2)
            {
				if (entiDisplayPosition.X > DisplaySizeX)
                { 
					weltVector += new Vector2 (DisplaySizeX, 0);
				}
                else if (entiDisplayPosition.X < 0)
                {
					weltVector -= new Vector2 (DisplaySizeX, 0);
				}
			}

			sharkiDisplayPosition.X = sharkiRealPosition.X - weltVector.X;
			sharkiDisplayPosition.Y = sharkiRealPosition.Y - weltVector.Y;

			sharkDisplayPosition.X = sharkRealPosition.X - weltVector.X;
			sharkDisplayPosition.Y = sharkRealPosition.Y - weltVector.Y;


            //Kollision

            Rectangle entibox = new Rectangle(
                (int)(entiRealPosition.X - enti.Width * entiScale.X /2 + CellSizeX/2), 
                (int)(entiRealPosition.Y + enti.Height * entiScale.Y /2), 
                (int)(enti.Height*entiScale.Y/2), 
                (int)(enti.Width*entiScale.X/2));

//            Rectangle sharkbox = new Rectangle(
//                (int)(sharkRealPosition.X),
//                (int)(sharkRealPosition.Y + shark.Height/2),
//                (int)(shark.Height),
//                (int)(shark.Width));

//            if (sharkbox.Intersects(entibox))
//            {
//                if (intro == 2)
//                {
//                    LifeLostCounter += 1;
//                    entiRealPosition = new Vector2(0, 500);
//                }

//            }

            for (int y = 0; y < Map.MAPHEIGHT; y++)
            {
                for (int x = 0; x < Map.MAPWIDTH; x++)
                {
                    if (level.Cells[x, y] == CellType.Platform1)
                    {
                        Rectangle box = new Rectangle(x * 20 - CellSizeX, y * 20 + CellSizeY, 20, 20);
                            if (box.Intersects(entibox))
                            {
                                if (intro == 2)
                                {
                                    if (entiVelocity.Y > 1)
                                    {
                                        entiVelocity.Y = 0;
                                        entiRealPosition.Y = y * 20 - ((enti.Height * entiScale.Y)/2);
                                        JumpCounter = 0;
                                    }
                                }
                            }
                    }
                    if (level.Cells[x, y] == CellType.Platform2)
                    {
                        Rectangle box = new Rectangle(x * 20 - CellSizeX, y * 20 + CellSizeY, 20, 20);
                        if (box.Intersects(entibox))
                        {
                            if (intro == 2)
                            {
                                if (entiVelocity.Y > 1)
                                {
                                    entiVelocity.Y = 0;
                                    entiRealPosition.Y = y * 20 - ((enti.Height * entiScale.Y) / 2);
                                    JumpCounter = 0;
                                }
                            }
                        }
                    }
                    if (level.Cells[x, y] == CellType.Platform3)
                    {
                        Rectangle box = new Rectangle(x * 20 - CellSizeX, y * 20 + CellSizeY, 20, 20);
                        if (box.Intersects(entibox))
                        {
                            if (intro == 2)
                            {
                                if (entiVelocity.Y > 1)
                                {
                                    entiVelocity.Y = 0;
                                    entiRealPosition.Y = y * 20 - ((enti.Height * entiScale.Y) / 2);
                                    JumpCounter = 0;
                                }
                            }
                        }
                    }
                }
            }

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

			spriteBatch.Begin();

            // Draw Space in Start-Screen
            if (intro == 0)
            {
                spriteBatch.Draw(space, new Vector2(
                    (int)550,
                    (int)200));
            }

            // Draw Copyright in Start-Screen
            if (intro == 0)
            {
                spriteBatch.Draw(copyright, new Vector2(
                    (int) DisplaySizeX - 250,
                    (int) DisplaySizeY - 30));
            }

            // Draw HowToPlay in Start-Screen
            if (intro == 0)
            {
                spriteBatch.Draw(howtoplaystart, new Vector2(
                    (int)10,
                    (int)10));
            }

            // Draw HowToPlayAnimation

            if (intro == 1)
            {
                if (howtoplayCounter == 1)
                {
                    spriteBatch.Draw(keyD, new Vector2(
                    (int)0,
                    (int)0));
                }
                if (howtoplayCounter == 2)
                {
                    spriteBatch.Draw(keyA, new Vector2(
                    (int)0,
                    (int)0));
                }
                if (howtoplayCounter == 3)
                {
                    spriteBatch.Draw(keyW, new Vector2(
                    (int)0,
                    (int)0));
                } 
                if (howtoplayCounter == 4)
                {
                    spriteBatch.Draw(howtoplay, new Vector2(
                        (int)0,
                        (int)0));
                }
                if (howtoplayCounter == 5)
                {
                    spriteBatch.Draw(keyW, new Vector2(
                    (int)0,
                    (int)0));
                }
                if (howtoplayCounter == 6)
                {
                    spriteBatch.Draw(howtoplay, new Vector2(
                        (int)0,
                        (int)0));
                }
            }

            // Draw LifeLostCounter

            if (intro == 2)
            {
                spriteBatch.Draw(lifelost, new Vector2(
                    (int)10,
					(int)10));
				if (LifeLostCounter < numbers.Count) {
					
					spriteBatch.Draw (numbers [LifeLostCounter], new Vector2 (
						(int)220,
						(int)10));
				}
            }

			// Draw Map (Plattform)
			if (intro == 2) {
				for (int y = 0; y < Map.MAPHEIGHT; y++) {
					for (int x = 0; x < Map.MAPWIDTH; x++) {
						if (level.Cells [x, y] == CellType.Platform1) {
							spriteBatch.Draw (platform1, new Rectangle (x * 20 - (int)weltVector.X, y * 20 - (int)weltVector.Y, 20, 20), Color.White);
						}
						if (level.Cells [x, y] == CellType.Platform2) {
							spriteBatch.Draw (platform2, new Rectangle (x * 20 - (int)weltVector.X, y * 20 - (int)weltVector.Y, 20, 20), Color.White);
						}
						if (level.Cells [x, y] == CellType.Platform3) {
							spriteBatch.Draw (platform3, new Rectangle (x * 20 - (int)weltVector.X, y * 20 - (int)weltVector.Y, 20, 20), Color.White);
						}
					}
				}
			}

			// Draw Enti
			spriteBatch.Draw(enti, new Vector2(
				(int)(entiDisplayPosition.X),
				(int)(entiDisplayPosition.Y)
			), null,
				Color.White,
				0,
				new Vector2(enti.Width / 2,enti.Height / 2),
				entiScale,
				entiMirror,
				0);
			
            // Draw Sharki
            if (intro == 2)
            {
				if (sharkAktion == 0)
                spriteBatch.Draw(sharkifin, new Vector2(
                    (int)(sharkiDisplayPosition.X),
                    (int)(DisplaySizeY - 20)
                    ), null,
                    Color.White,
                    0,
                    new Vector2(sharkifin.Width / 2, sharkifin.Height / 2),
						(float)0.4 ,
                    sharkiMirror,
                    0);
            }

            // Draw Shark
            if (intro == 2)
            {
                spriteBatch.Draw(shark, new Vector2(
                    (int)(sharkDisplayPosition.X),
                    (int)(sharkDisplayPosition.Y)), null,
                    Color.White,
                    0,
                    new Vector2(0 , 0),
					(float)0.3,
                    SpriteEffects.None,
                    0
                    );
            }

            // Draw Map (Water)
            if (intro == 2)
            {
                for (int y = 0; y < Map.MAPHEIGHT; y++)
                {
                    for (int x = 0; x < Map.MAPWIDTH; x++)
                    {
                        if (level.Cells[x, y] == CellType.Water1)
                        {
                            spriteBatch.Draw(water1, new Rectangle(x * 20 - (int)weltVector.X, y * 20 - (int)weltVector.Y, 20, 20), Color.White);
                        }
                        if (level.Cells[x, y] == CellType.Water2)
                        {
                            spriteBatch.Draw(water2, new Rectangle(x * 20 - (int)weltVector.X, y * 20 - (int)weltVector.Y, 20, 20), Color.White);
                        }
                    }
                }
            }

            

			spriteBatch.End();

			base.Draw (gameTime);
		}
	}
}

