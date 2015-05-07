using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shooter
{
    class Scena
    {
        private Texture2D tlo;
        public int Szerokosc;
        public int Wysokosc;

        public Scena(Texture2D Tlo, int szerokosc, int wysokosc)
        {
            this.tlo = Tlo;
            this.Szerokosc = szerokosc;
            this.Wysokosc = wysokosc;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tlo, new Rectangle(0, 0, Szerokosc, Wysokosc), Color.White);
        }


    }
}
