using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using System;
//TODO (teraz) punktacja na koniec, punktacja pokazana podczas gry
//TODO (kiedys) Wiecej itemow, pomniejszyc postac i zwykle potwory, dodac wielkie potwory z 2x tyle zycia, to ze niesmiertelny slabo widoczne 

namespace Shooter
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Tryb tryb;

        SpriteFont font;
        Napis napisKoncowy;
        Texture2D[] przyciskiText = new Texture2D[2];
        Texture2D[] textury = new Texture2D[12];
        Texture2D[] bronieText = new Texture2D[6];
        Texture2D[] pociskiText = new Texture2D[2];
        Texture2D[] zycieGracz = new Texture2D[2];
        Interakcje interakcja;
        Scena scena;
        
        Przycisk[] przyciski = new Przycisk[2];
        Podloga podloga;
        Platforma[] platformy = new Platforma[5];
        Gracz gracz;
        Chodzacy[] chodzace = new Chodzacy[20];
        Pocisk[] pociski = new Pocisk[500];
        Box box;
        
        Random random;
        double czasGen;
        double czasNiesm;
        int ScreenHeight;
        int ScreenWidth;

        public Game1()
            : base()
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

            base.Initialize();
            base.Window.Title = "Shooter";
            base.Window.AllowUserResizing = false;
            this.IsMouseVisible = true;
            tryb = Tryb.Menu;

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            ScreenWidth = GraphicsDevice.PresentationParameters.BackBufferWidth;
            ScreenHeight = GraphicsDevice.PresentationParameters.BackBufferHeight;
            interakcja = new Interakcje();

            przyciskiText[0] = Content.Load<Texture2D>("Graj");
            przyciskiText[1] = Content.Load<Texture2D>("Wyjdz");

            bronieText[0] = Content.Load<Texture2D>("Pistolet");
            bronieText[1] = Content.Load<Texture2D>("Karabin");
            bronieText[2] = Content.Load<Texture2D>("Minigun");
            bronieText[3] = Content.Load<Texture2D>("Strzelba");
            bronieText[4] = Content.Load<Texture2D>("Snajpa");
            bronieText[5] = Content.Load<Texture2D>("Laser");

            pociskiText[0] = Content.Load<Texture2D>("PociskZwykly");
            pociskiText[1] = Content.Load<Texture2D>("PociskLaser");

            zycieGracz[0] = Content.Load<Texture2D>("Serce");
            zycieGracz[1] = Content.Load<Texture2D>("Niesmiertelnosc");

            textury[0] = Content.Load<Texture2D>("Tlo");
            textury[1] = Content.Load<Texture2D>("GraczPrawo");
            textury[2] = Content.Load<Texture2D>("GraczLewo");
            textury[3] = Content.Load<Texture2D>("Platforma");
            textury[4] = Content.Load<Texture2D>("Chodzacy");
            textury[5] = Content.Load<Texture2D>("Rage");
            textury[6] = Content.Load<Texture2D>("HP3");
            textury[7] = Content.Load<Texture2D>("HP2");
            textury[8] = Content.Load<Texture2D>("HP1");
            textury[9] = Content.Load<Texture2D>("Box");

            font = Content.Load<SpriteFont>("SpriteFont1");

            przyciski[0] = new Przycisk(przyciskiText[0], 0, 0, new Vector2((ScreenWidth - przyciskiText[0].Width) / 2, ScreenHeight / 3));
            przyciski[1] = new Przycisk(przyciskiText[1], 0, 0, new Vector2((ScreenWidth - przyciskiText[1].Width)/2, 2*ScreenHeight/3));

            scena = new Scena(textury[0], ScreenWidth, ScreenHeight);
            podloga = new Podloga(textury[3], 50, ScreenWidth*2, new Vector2(-10, 450));
            gracz = new Gracz(textury[1], textury[2], zycieGracz, bronieText, pociskiText, new Vector2(0, podloga.Pozycja.Y), new Vector2(0, 0));

            for (int i = 0; i < pociski.Length; i++)
            {
                pociski[i] = new Pocisk(pociskiText[0], new Vector2(0, 0), new Vector2(0, 0), false, 0, 0, 0, " ");
            }

            for(int i=0; i<chodzace.Length; i++)   
                    chodzace[i] = new Chodzacy(textury[4], textury[5], textury[6], textury[7], textury[8], new Vector2(0, 0), new Vector2(0, 0), false);


            platformy[0] = new Platforma(textury[3], 40, ScreenWidth / 3, new Vector2(ScreenWidth / 3, 2 * ScreenHeight / 5 + 25));
            platformy[1] = new Platforma(textury[3], 40, ScreenWidth / 3, new Vector2(0, 3 * ScreenHeight / 5 + 50));
            platformy[2] = new Platforma(textury[3], 40, ScreenWidth / 3, new Vector2(2 * ScreenWidth / 3, 3 * ScreenHeight / 5 + 50));
            platformy[3] = new Platforma(textury[3], 40, ScreenWidth / 3, new Vector2(0, 1 * ScreenHeight / 5));
            platformy[4] = new Platforma(textury[3], 40, ScreenWidth / 3, new Vector2(2 * ScreenWidth / 3, 1 * ScreenHeight / 5));

            int[] pozycjeBoxowY = { 450 - textury[9].Height, 3 * ScreenHeight / 5 + 50 - textury[9].Height, 
                                    2 * ScreenHeight / 5 + 25 - textury[9].Height, 1 * ScreenHeight / 5 - textury[9].Height };
            box = new Box(textury[9], 30, 30, new Vector2(0, 0), pozycjeBoxowY);
            box.Reset();

            czasGen = 0;
            czasNiesm = 0;
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            Content.Unload();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
             if(tryb == Tryb.Menu)
             {
                if(przyciski[0].CzyWcisniety(Mouse.GetState()))
                {
                    tryb = Tryb.Gra;
                    this.IsMouseVisible=false;
                }
                if(przyciski[1].CzyWcisniety(Mouse.GetState()))
                {
                    Exit();
                }
             }
            if(tryb==Tryb.Gra)
            { 
                random  = new Random((int)gameTime.TotalGameTime.TotalMilliseconds); 
                int los = random.Next();

                if(los%50==0 && gameTime.TotalGameTime.TotalMilliseconds - 300.0 > czasGen)
                {
                    if (los % 100 == 0)
                    {
                        for (int i = 0; i < chodzace.Length; i++)
                            if (!chodzace[i].Aktywny)
                            {
                                chodzace[i] = new Chodzacy(textury[4], textury[5], textury[6], textury[7], textury[8], new Vector2(0, 1 * ScreenHeight / 5 - textury[3].Height), new Vector2(5, 0), true);
                                break;
                            }
                    }
                    else
                    {
                        for (int i = 0; i < chodzace.Length; i++)
                            if (!chodzace[i].Aktywny)
                            {
                                chodzace[i] = new Chodzacy(textury[4], textury[5], textury[6], textury[7], textury[8], new Vector2(ScreenWidth - textury[3].Width, 1 * ScreenHeight / 5 - textury[3].Height), new Vector2(-5, 0), true);
                                break;
                            }
                    }
                    czasGen = gameTime.TotalGameTime.TotalMilliseconds;
                }
            
                gracz.Ruch();
                if (Keyboard.GetState().IsKeyDown(Keys.F))
                    gracz.Bron.Strzal(pociski, gameTime.TotalGameTime.TotalMilliseconds, gracz);

                interakcja.ScenaGracz(gracz, scena);
                interakcja.GraczBox(box, gracz);
            
                if (!interakcja.IstotaObjektStal(gracz, podloga))
                    for (int i = 0; i < platformy.Length; i++)
                        if (interakcja.IstotaObjektStal(gracz, platformy[i]))
                            break;

                for (int i = 0; i < chodzace.Length; i++)
                {
                    if (chodzace[i].Aktywny == true)
                    {
                        chodzace[i].Ruch();
                        interakcja.ScenaChodzacy(chodzace[i], scena);
                        if (!interakcja.IstotaObjektStal(chodzace[i], podloga))
                            for (int j = 0; j < platformy.Length; j++)
                                if (interakcja.IstotaObjektStal(chodzace[i], platformy[j]))
                                    break;
                    }
                }

                foreach (Pocisk o in pociski)
                {
                    o.Ruch();
                    o.Update(gameTime.TotalGameTime.TotalMilliseconds, gracz);
                    interakcja.ScenaPocisk(o, scena);
                }

                interakcja.PociskChodzacy(pociski, chodzace);
                if (czasNiesm + gracz.Niesmiertelnosc <= gameTime.TotalGameTime.TotalMilliseconds)
                    interakcja.GraczIstota(gracz, chodzace);
                if (gracz.CzyNiesm)
                {
                    czasNiesm = gameTime.TotalGameTime.TotalMilliseconds;
                    gracz.CzyNiesm = false;
                }

                if (gracz.HP <= 0 )
                {
                    tryb = Tryb.Koniec;
                    this.IsMouseVisible = true;
                    napisKoncowy = new Napis(font, new Vector2((ScreenWidth - przyciskiText[0].Width) / 2, ScreenHeight / 8), "Twoj wynik to: " + gracz.Punkty.ToString(), Color.Yellow);
            
                }
                
            }
            if (tryb == Tryb.Koniec)
            {
                if (przyciski[0].CzyWcisniety(Mouse.GetState()) || Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    UnloadContent();
                    LoadContent();
                    tryb = Tryb.Gra;
                    this.IsMouseVisible = false;
                }
                if (przyciski[1].CzyWcisniety(Mouse.GetState()) || Keyboard.GetState().IsKeyDown(Keys.Escape))
                {
                    Exit();
                }
            }
            //if(tryb==Tryb.Koniec)
            //  pokazanie wyniku itp.

            base.Update(gameTime);
        }

            // TODO: Add your update logic here

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            if(tryb == Tryb.Menu)
            {
                spriteBatch.Begin();
                    scena.Draw(spriteBatch);
                    przyciski[0].Draw(spriteBatch);
                    przyciski[1].Draw(spriteBatch);
                spriteBatch.End();
            }
            if (tryb == Tryb.Gra)
            {
                if (czasNiesm + gracz.Niesmiertelnosc > gameTime.TotalGameTime.TotalMilliseconds)
                    gracz.CzyNiesm = true;

                spriteBatch.Begin();
                    scena.Draw(spriteBatch);
                    box.Draw(spriteBatch);

                    foreach (Chodzacy o in chodzace)
                        if (o.Aktywny == true)
                            o.Draw(spriteBatch);

                    foreach (Pocisk o in pociski)
                        if (o.Aktywny == true)
                            o.Draw(spriteBatch);

                    for (int i = 0; i < platformy.Length; i++)
                        platformy[i].Draw(spriteBatch);
                    
                    podloga.Draw(spriteBatch);
                    gracz.Draw(spriteBatch);
                spriteBatch.End();

                gracz.CzyNiesm = false;
            }
            if (tryb == Tryb.Koniec)
            {
                spriteBatch.Begin();
                    scena.Draw(spriteBatch);
                    przyciski[0].Draw(spriteBatch);
                    przyciski[1].Draw(spriteBatch);
                    napisKoncowy.Draw(spriteBatch);
                spriteBatch.End();
            }
            // TODO: Add your drawing code here

            base.Draw(gameTime);

        }
    }
}
