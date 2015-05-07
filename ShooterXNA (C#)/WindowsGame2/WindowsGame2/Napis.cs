using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using System;

namespace Shooter
{
    class Napis
    {
        private SpriteFont font;
        public Vector2 Pozycja;
        private string napis;
        private Color kolor;

        public Napis(SpriteFont Font, Vector2 pozycja, string Napis, Color Color)
        {
            this.font = Font;
            this.Pozycja = pozycja;
            this.napis = Napis;
            this.kolor = Color;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(this.font, this.napis, this.Pozycja, this.kolor);
        }   
        
    }
}
