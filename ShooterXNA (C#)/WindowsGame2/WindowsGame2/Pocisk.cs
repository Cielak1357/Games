using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shooter
{
    class Pocisk : ObjektRuch
    {
        public string Typ;
        public int HP;
        public int Obrazenia;
        public bool Aktywny;
        private double czasStrzalu;

        public Pocisk (Texture2D textura, Vector2 pozycja, Vector2 predkosc, bool aktywny, int obrazenia, int hp, double CzasStrzalu, string typ)
            :base(textura, pozycja, predkosc)
        {
            this.Typ = typ;
            this.HP = hp;
            this.Obrazenia = obrazenia;
            this.Aktywny = aktywny;
            this.czasStrzalu = CzasStrzalu;

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            var predkosc = this.Predkosc;
            if(this.Typ=="Laser")
            {
                if(predkosc.X >= 0)
                    spriteBatch.Draw(this.textura, this.Pozycja, new Rectangle(0, 0, this.textura.Width, this.textura.Height), Color.White);
                else
                    spriteBatch.Draw(this.textura, new Vector2(this.Pozycja.X-this.textura.Width, this.Pozycja.Y), new Rectangle(0, 0, this.textura.Width, this.textura.Height), Color.White);
            }
            else //Typ == "Zwykly"
                base.Draw(spriteBatch);
        }

        public override void Ruch()
        {
            if(Typ=="Zwykly")
                base.Ruch();
        }

        public void Update(double gameTime, Gracz gracz)
        {
            var pozycja = this.Pozycja;
            if (Typ == "Laser")
            {
                if (czasStrzalu + 250 < gameTime)
                    Aktywny = false;

                pozycja.X = gracz.Pozycja.X;
                pozycja.Y = gracz.Pozycja.Y + gracz.textura.Height/2;
            }
            this.Pozycja = pozycja;
        }

    }
}
