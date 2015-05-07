using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shooter
{
    class Gracz : Istota
    {
        public Texture2D textura2;
        public Texture2D[] Zycie = new Texture2D[2];
        public Texture2D[] Bronie = new Texture2D[6];
        public Texture2D[] Pociski = new Texture2D[2];
        public int Punkty;
        public int Niesmiertelnosc;
        public bool CzyNiesm;
        public Bron Bron;

        public Gracz(Texture2D textura, Texture2D textura2, Texture2D[] zycie, Texture2D[] bronie, Texture2D[] pociski, Vector2 pozycja, Vector2 predkosc) : base(textura, pozycja, predkosc)
        {
            var temp = this.Pozycja;
            temp.Y -= this.textura.Height;
            this.Pozycja = temp;
            this.maxpredkosc = 6;
            this.HP = 1;
            this.textura2 = textura2;
            this.Bronie = bronie;
            this.Pociski = pociski;
            this.Zycie = zycie;
            this.Niesmiertelnosc = 0;
            this.CzyNiesm = false;
            this.Punkty = 0;
            this.Bron = new Bron("Pistolet", bronie[0], pociski);
            
        }

        public override void Ruch()
        {
            var predkosc = this.Predkosc;
            var pozycja = this.Pozycja;
            if(Predkosc.X<maxpredkosc)
                if (Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    predkosc.X += (float)0.5;
                    Zwrot = "prawo";
                }
            if(Predkosc.X*(-1)<maxpredkosc)
                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                {   
                    predkosc.X-=(float)0.5;
                    Zwrot = "lewo";
                }
            if (Keyboard.GetState().IsKeyDown(Keys.Up) && this.Pozycja.Y==podporaY)
                predkosc.Y = -16;
            if(Keyboard.GetState().IsKeyUp(Keys.None))
            {
                if (this.Pozycja.Y != podporaY)
                    predkosc.Y++;

                if (predkosc.X < 0)
                    predkosc.X+=(float)0.25;
                if (predkosc.X > 0)
                    predkosc.X-=(float)0.25;

            }
            //if (Keyboard.GetState().IsKeyDown(Keys.Down))


            this.Predkosc = predkosc;
            base.Ruch();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if(Zwrot=="lewo")
                spriteBatch.Draw(this.textura2, this.Pozycja, new Rectangle(0, 0, this.textura.Width, this.textura.Height), Color.White);
            else
                spriteBatch.Draw(this.textura, this.Pozycja, new Rectangle(0, 0, this.textura.Width, this.textura.Height), Color.White);

            for (int i = 0; i < HP; i++)
            {
                if(!CzyNiesm)
                    spriteBatch.Draw(this.Zycie[0], new Vector2(i * this.Zycie[0].Width, 450), new Rectangle(0, 0, this.Zycie[0].Width, this.Zycie[0].Height), Color.White);
                else
                    spriteBatch.Draw(this.Zycie[1], new Vector2(i * this.Zycie[1].Width, 450), new Rectangle(0, 0, this.Zycie[1].Width, this.Zycie[1].Height), Color.White);
            }

            this.Bron.Draw(spriteBatch);

        }
    }
}
