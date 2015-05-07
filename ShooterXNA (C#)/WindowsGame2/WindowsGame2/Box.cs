using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Shooter
{
    class Box : ObjektStal
    {
        public string Przedmiot;
        private int[] pozycjeY = new int[4];

        public Box(Texture2D Textura, int wysokosc, int szerokosc, Vector2 pozycja, int[] PozycjeY)
            : base(Textura, wysokosc, szerokosc, pozycja)
        {
            this.Przedmiot = "";
            this.pozycjeY = PozycjeY;
        }

        public void Reset()
        {
            Random random = new Random((int)DateTime.Now.Millisecond);
            int los = random.Next(0, 8);
            string poprzedni = this.Przedmiot;
            switch (los)
            {
                case 0:
                    Przedmiot = "HP";
                    break;
                case 1:
                    Przedmiot = "Karabin";
                    break;
                case 2:
                    Przedmiot = "Pistolet";
                    break;
                case 3:
                    Przedmiot = "Minigun";
                    break;
                case 4:
                    Przedmiot = "Niesmiertelnosc";
                    break;
                case 5:
                    Przedmiot = "Laser";
                    break;
                case 6:
                    Przedmiot = "Strzelba";
                    break;
                case 7:
                    Przedmiot = "Snajpa";
                    break;
            }
            
            if(poprzedni==this.Przedmiot)
            {
                Reset();
                return;
            }

            los = random.Next(0, 400);
            Pozycja.X = los;
            los = random.Next(0, 4);
            switch (los)
            {
                case 0:
                    Pozycja.Y = pozycjeY[0];
                    break;
                case 1:
                    Pozycja.Y = pozycjeY[1];
                    break;
                case 2:
                    Pozycja.Y = pozycjeY[2];
                    break;
                case 3:
                    Pozycja.Y = pozycjeY[3];
                    break;
            }
        }
    }
}

