using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shooter
{
    abstract class ObjektStal
    {
           //private Texture2D tlo;
        public int Szerokosc;
        public int Wysokosc;
        public Vector2 Pozycja; 
        public Texture2D textura;

        public ObjektStal(Texture2D Textura, int wysokosc, int szerokosc, Vector2 pozycja)
        {
            this.textura = Textura;
            this.Szerokosc = szerokosc;
            this.Wysokosc = wysokosc;
            this.Pozycja = pozycja;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.textura, this.Pozycja, new Rectangle(0, 0, this.Szerokosc, this.Wysokosc), Color.White);
        }      
    }
}
