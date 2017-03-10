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
        Texture2D space;
        Texture2D wurmi;
        Texture2D copyright;
        Texture2D howtoplay;
        Texture2D howtoplaystart;
        Texture2D lifelost;
        Texture2D zero;
        Texture2D one;
        Texture2D two;
        Texture2D three;
        Texture2D four;
        Texture2D five;
        Texture2D six;
        Texture2D seven;
        Texture2D eight;
        Texture2D nine;
		Texture2D sharkifin;
		Texture2D shark;
<<<<<<< HEAD
        Texture2D keyA;
        Texture2D keyD;
        Texture2D keyS;
        Texture2D keyW;
=======
>>>>>>> origin/master

        //Vector2 entiDimensions = new Vector2(1440, 1387);

        int DisplaySizeX = 920;
		int DisplaySizeY = 720;

        int CellSizeX = 20;
        int CellSizeY = 20;

        int MAPWIDTH = 138;
        int MAPHEIGHT = 36;

		float sinusangle = 0;

		int intro = 0;
		int JumpCounter = 1;
        int LifeLostCounter = 0;
        int howtoplayCounter = 0;
        int pCounter = 0;
 
		KeyboardState formerkState;
		//enti.Height / 2

		Vector2 weltVector = new Vector2(0,0);

		//Position relative to World
		Vector2 entiRealPosition = new Vector2(-800,500);
		Vector2 sharkiRealPosition = new Vector2 ();
		Vector2 sharkRealPosition = new Vector2 ();

		//Postion relative to Window
		Vector2 entiDisplayPosition = new Vector2(-800, 500);
		Vector2 entiVelocity = new Vector2();
		Vector2 entiScale = new Vector2(0.7f,0.7f);
		SpriteEffects entiMirror = SpriteEffects.None;

		Vector2 sharkiDisplayPosition = new Vector2 ();
		Vector2 sharkiVelocity = new Vector2 ();

		Vector2 sharkDisplayPosition = new Vector2 ();
<<<<<<< HEAD
=======
		Vector2 sharkJump = new Vector2 ();
>>>>>>> origin/master


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
            wurmi = Content.Load<Texture2D>("Textures/wurmi");
            howtoplay = Content.Load<Texture2D>("Textures/howtoplay");
            howtoplaystart = Content.Load<Texture2D>("Textures/howtoplaystart");
            copyright = Content.Load<Texture2D>("Textures/copyright");
            lifelost = Content.Load<Texture2D>("Textures/lifelost");
            zero = Content.Load<Texture2D>("Textures/0");
            one = Content.Load<Texture2D>("Textures/1");
            two = Content.Load<Texture2D>("Textures/2");
            three = Content.Load<Texture2D>("Textures/3");
            four = Content.Load<Texture2D>("Textures/4");
            five = Content.Load<Texture2D>("Textures/5");
            six = Content.Load<Texture2D>("Textures/6");
            seven = Content.Load<Texture2D>("Textures/7");
            eight = Content.Load<Texture2D>("Textures/8");
            nine = Content.Load<Texture2D>("Textures/9");
			sharkifin = Content.Load<Texture2D> ("Textures/sharkfin");
			shark = Content.Load<Texture2D> ("Textures/wurmi");
<<<<<<< HEAD
            keyA = Content.Load<Texture2D>("Textures/keyA");
            keyD = Content.Load<Texture2D>("Textures/keyD");
            keyS = Content.Load<Texture2D>("Textures/keyS");
            keyW = Content.Load<Texture2D>("Textures/keyW");
=======
>>>>>>> origin/master


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
<<<<<<< HEAD

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
=======
			if (intro == 1){
			if (kState.IsKeyDown (Keys.W) && formerkState.IsKeyUp (Keys.W)) {
				if (entiRealPosition.Y >= DisplaySizeY - ((enti.Height * entiScale.Y) / 2)) {
					entiVelocity.Y = -60;
					JumpCounter = 1;
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
            if (kState.IsKeyDown(Keys.Space)) {
                //entiDimensions = new Vector2 (103, 99);
                entiScale = new Vector2(0.07f, 0.07f);
                intro = 1;
>>>>>>> origin/master
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
                    entiRealPosition += new Vector2(0f, -10);
                }

<<<<<<< HEAD
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
                    intro = 0;
                    entiRealPosition = new Vector2(80, 500);
                    entiScale = new Vector2(0.7f,0.7f);
                    entiMirror = SpriteEffects.None;
                    pCounter -= 1;
                    howtoplayCounter = 6;      
                }
             }

            //Enti
=======
			//Shark-idy
			if (intro == 1) {
				if (sharkiRealPosition.X < entiRealPosition.X)
					sharkiVelocity += new Vector2 (400f, 0f) * (float)gameTime.ElapsedGameTime.TotalSeconds;
				if (sharkiRealPosition.X > entiRealPosition.X)
					sharkiVelocity += new Vector2 (-400f, 0f) * (float)gameTime.ElapsedGameTime.TotalSeconds;
				}

			//Shark-Jump
			if (intro == 1)
				if (sharkiRealPosition.X - entiRealPosition.X < 10)
				sharkJump += new Vector2 (0f, 200f);

			//Sinus-angle-update
			sinusangle +=1 * (float)1.5 * (float)gameTime.ElapsedGameTime.TotalSeconds;
			if (sinusangle == 361)
				sinusangle = 0;
				
>>>>>>> origin/master

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
                }

<<<<<<< HEAD
            }

            entiRealPosition += (10 * entiVelocity * (float)gameTime.ElapsedGameTime.TotalSeconds);
			sharkiRealPosition += (5 * sharkiVelocity * (float)gameTime.ElapsedGameTime.TotalSeconds);
//			sharkRealPosition += (100 * sharkJump * (float)gameTime.ElapsedGameTime.TotalSeconds);

                //Inertia
=======
			entiRealPosition += (10 * entiVelocity * (float)gameTime.ElapsedGameTime.TotalSeconds);
			sharkiRealPosition += (5 * sharkiVelocity * (float)gameTime.ElapsedGameTime.TotalSeconds);
			sharkRealPosition += (5 * sharkJump* (float)gameTime.ElapsedGameTime.TotalSeconds);

>>>>>>> origin/master

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
<<<<<<< HEAD

                //Rotation on Display
=======
			
>>>>>>> origin/master

            if (entiVelocity.X < 0)
				entiMirror = SpriteEffects.FlipHorizontally;
			if (entiVelocity.X > 0)
				entiMirror = SpriteEffects.None;

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

                //Sinus-angle-update

			sinusangle +=1 * (float)1.5 * (float)gameTime.ElapsedGameTime.TotalSeconds;
			if (sinusangle == 361)
				sinusangle = 0;


            //Shark

            //Shark-Jump

//            if (intro == 2)
//            {
//                if (entiRealPosition.X - sharkiRealPosition.X > (float)0.00000000001)
//                {
//                    sharkRealPosition.X = (int)sharkiRealPosition.X;
//                    sharkRealPosition.Y = (int)sharkiRealPosition.Y;
//                    sharkRealPosition.Y += -1;
//                }
//                if (sharkRealPosition.Y < entiRealPosition.Y)
//                {
//                    sharkRealPosition = new Vector2(0, 0);
//                }
//                if (sharkRealPosition.Y > DisplaySizeY)
//                {
//                    sharkRealPosition.Y = DisplaySizeY;
//                }
//                sharkRealPosition += new Vector2(0, 1);
//            }
			
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

<<<<<<< HEAD
			sharkDisplayPosition.X = sharkRealPosition.X - weltVector.X;
			sharkDisplayPosition.Y = sharkRealPosition.Y - weltVector.Y;

=======
			sharkiDisplayPosition.X = sharkiRealPosition.X - weltVector.X;
			sharkiDisplayPosition.Y = sharkiRealPosition.Y - weltVector.Y;

			sharkDisplayPosition.X = sharkRealPosition.X - weltVector.X;
			sharkDisplayPosition.Y = sharkRealPosition.Y - weltVector.Y;

			//Startanimation
			if (gameTime.TotalGameTime.TotalSeconds < 2)
				entiVelocity.X = 40f;	

			formerkState = kState;
>>>>>>> origin/master

            //Kollision

            Rectangle entibox = new Rectangle(
                (int)(entiRealPosition.X - enti.Width * entiScale.X /2 + CellSizeX/2), 
                (int)(entiRealPosition.Y + enti.Height * entiScale.Y /2), 
                (int)(enti.Height*entiScale.Y/2), 
                (int)(enti.Width*entiScale.X/2));

            for (int y = 0; y < Map.MAPHEIGHT; y++)
            {
                for (int x = 0; x < Map.MAPWIDTH; x++)
                {
                    if (level.Cells[x, y] == CellType.Platform)
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
                    if (level.Cells[x, y] == CellType.Ground)
                    {
                        Rectangle box = new Rectangle(x * 20 - CellSizeX, y * 20 + CellSizeY, 20, 20);
                        if (box.Intersects(entibox))
                        {
                            if (intro == 2)
                            {
                                if (entiVelocity.Y > 0)
                                {
                                    entiVelocity.Y = 0;
                                    entiRealPosition.Y = y * 20 - ((enti.Height * entiScale.Y) / 2);
                                    JumpCounter = 0;
                                }
                            }
                        }
                    }
                    if (level.Cells[x, y] == CellType.Water)
                    {
                        Rectangle box = new Rectangle(x * 20 - CellSizeX, y * 20 + CellSizeY, 20, 20);
                        if (box.Intersects(entibox))
                        {
                            if (intro == 2)
                            {
                                if (entiVelocity.Y > 0)
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
            }

            // Draw LifeLostCounter

            if (intro == 2)
            {
                spriteBatch.Draw(lifelost, new Vector2(
                    (int)10,
                    (int)10));
                if (LifeLostCounter == 0)
                {
                    spriteBatch.Draw(zero, new Vector2(
                        (int)220,
                        (int)10));
                }
                if (LifeLostCounter == 1)
                {
                    spriteBatch.Draw(one, new Vector2(
                        (int)220,
                        (int)10));
                }
                if (LifeLostCounter == 2)
                {
                    spriteBatch.Draw(two, new Vector2(
                        (int)220,
                        (int)10));
                }
                if (LifeLostCounter == 3)
                {
                    spriteBatch.Draw(three, new Vector2(
                        (int)220,
                        (int)10));
                }
                if (LifeLostCounter == 4)
                {
                    spriteBatch.Draw(four, new Vector2(
                        (int)220,
                        (int)10));
                }
                if (LifeLostCounter == 5)
                {
                    spriteBatch.Draw(five, new Vector2(
                        (int)220,
                        (int)10));
                }
                if (LifeLostCounter == 6)
                {
                    spriteBatch.Draw(six, new Vector2(
                        (int)220,
                        (int)10));
                }
                if (LifeLostCounter == 7)
                {
                    spriteBatch.Draw(seven, new Vector2(
                        (int)220,
                        (int)10));
                }
                if (LifeLostCounter == 8)
                {
                    spriteBatch.Draw(eight, new Vector2(
                        (int)220,
                        (int)10));
                }
                if (LifeLostCounter == 9)
                {
                    spriteBatch.Draw(nine, new Vector2(
                        (int)220,
                        (int)10));
                }
            }


            // Draw Map
            if (intro == 2)
            {
                for (int y = 0; y < Map.MAPHEIGHT; y++)
                {
                    for (int x = 0; x < Map.MAPWIDTH; x++)
                    {
                        if (level.Cells[x, y] == CellType.Platform)
                        {
                            spriteBatch.Draw(enti, new Rectangle(x * 20 - (int)weltVector.X, y * 20 - (int)weltVector.Y, 20, 20), Color.White);
                        }
                        if (level.Cells[x, y] == CellType.Water)
                        {
                            spriteBatch.Draw(wurmi, new Rectangle(x * 20 - (int)weltVector.X, y * 20 - (int)weltVector.Y, 20, 20), Color.White);
                        }
                        if (level.Cells[x, y] == CellType.Ground)
                        {
                            spriteBatch.Draw(enti, new Rectangle(x * 20 - (int)weltVector.X, y * 20 - (int)weltVector.Y, 20, 20), Color.White);
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
<<<<<<< HEAD
=======

			// Draw Sharki
			if (intro ==1)
			spriteBatch.Draw(sharkifin, new Vector2(
				(int)(sharkiDisplayPosition.X),
				(int)(DisplaySizeY - 20)
//				(int)(200),
//				(int)(200)
				//(int)(entiDimensions.X),
				//(int)(entiDimensions.Y)
			), null,
				Color.White,
				0,
				new Vector2(sharkifin.Width / 2,sharkifin.Height / 2),
				1,
				SpriteEffects.None,
				0);
			
			// Draw Shark
			if (intro == 1)
				spriteBatch.Draw(shark, new Vector2(
					(int)(sharkDisplayPosition.X),
					(int)(DisplaySizeY)), 
					null,
					Color.White,
					0,
					new Vector2(sharkifin.Width / 2,sharkifin.Height / 2),
					1,
					SpriteEffects.None,
					0);
>>>>>>> origin/master

            // Draw Sharki
            if (intro == 2)
            {
                spriteBatch.Draw(sharkifin, new Vector2(
                    (int)(sharkiDisplayPosition.X),
                    (int)(DisplaySizeY - 20)
                    ), null,
                    Color.White,
                    0,
                    new Vector2(sharkifin.Width / 2, sharkifin.Height / 2),
                    1,
                    SpriteEffects.None,
                    0);
            }

            // Draw Shark
//            if (intro == 2)
//            {
//                spriteBatch.Draw(shark, new Vector2(
//                    (int)(sharkDisplayPosition.X),
//                    (int)(sharkDisplayPosition.Y)
//                    ));
//            }

			spriteBatch.End();

			spriteBatch.End();

			base.Draw (gameTime);
		}
	}
}

