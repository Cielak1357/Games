using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework;

namespace Shooter
{
    class Bron
    {
        public string Rodzaj;
        public string TypPocisku;
        public int Szybkostrzelnosc;
        private double czasStrzalu;
        public Texture2D Textura;
        public Texture2D[] PociskiText = new Texture2D[2];

        public Bron(string rodzaj, Texture2D textura, Texture2D[] pociskiText)
        {
            this.PociskiText = pociskiText;
            this.Textura = textura;
            this.Rodzaj = rodzaj;
            this.TypPocisku = "Zwykly";
            switch(rodzaj)
            {
                case "Pistolet":
                    this.Szybkostrzelnosc = 300;
                    break;
                case "Karabin":
                    this.Szybkostrzelnosc = 150;
                    break;
                case "Minigun":
                    this.Szybkostrzelnosc = 75;
                    break;
                case "Strzelba":
                    this.Szybkostrzelnosc = 500;
                    break;
                case "Laser":
                    this.Szybkostrzelnosc = 1000;
                    this.TypPocisku = "Laser";
                    break;
                case "Snajpa":
                    this.Szybkostrzelnosc = 600;
                    break;
            }
        }

        public void Strzal(Pocisk[] pociski, double gameTime, Istota istota)
        {
            int zwrot;
            int ilosc = 0; 
            if (gameTime - this.Szybkostrzelnosc > this.czasStrzalu)
            {
                if (istota.Zwrot == "lewo")
                    zwrot = -1;
                else
                    zwrot = 1;
                for (int i = 0; i < pociski.Length; i++)
                {
                    if (!pociski[i].Aktywny)
                    {
                        if (Rodzaj == "Strzelba")
                        {
                            pociski[i] = new Pocisk(PociskiText[0], new Vector2(istota.Pozycja.X, istota.Pozycja.Y + (ilosc + 1) * istota.textura.Height / 4), new Vector2(15 * zwrot, 0), true, 1, 1, gameTime, this.TypPocisku);
                            ilosc++;
                            if (ilosc >= 3)
                                break;
                        }
                        else if (Rodzaj == "Snajpa")
                        {
                            pociski[i] = new Pocisk(PociskiText[0], new Vector2(istota.Pozycja.X, istota.Pozycja.Y + istota.textura.Height / 2), new Vector2(15 * zwrot, 0), true, 3, 1, gameTime, this.TypPocisku);
                            break;
                        }
                        else if (Rodzaj == "Laser")
                        {
                            pociski[i] = new Pocisk(PociskiText[1], new Vector2(istota.Pozycja.X, istota.Pozycja.Y + istota.textura.Height / 2), new Vector2(zwrot, 0), true, 3, 1000, gameTime, this.TypPocisku);
                            break;
                        }
                        else
                        {
                            pociski[i] = new Pocisk(PociskiText[0], new Vector2(istota.Pozycja.X, istota.Pozycja.Y + istota.textura.Height / 2), new Vector2(15 * zwrot, 0), true, 1, 1, gameTime, this.TypPocisku);
                            break;
                        }
                    }
                }
                czasStrzalu = gameTime;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
                    spriteBatch.Draw(this.Textura, new Vector2(300, 450), new Rectangle(0, 0, this.Textura.Width, this.Textura.Height), Color.White);
        }
    }
}
