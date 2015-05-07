using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shooter
{
    class Przycisk : ObjektStal
    {

        private MouseState oldState;

        public Przycisk(Texture2D Textura, int wysokosc, int szerokosc, Vector2 pozycja)
            : base(Textura, wysokosc, szerokosc, pozycja)
        {
            this.Wysokosc = Textura.Height;
            this.Szerokosc = Textura.Width;
        }

        public bool CzyWcisniety(MouseState newState)
        {
            if (newState.X > this.Pozycja.X && newState.X < this.Pozycja.X + this.Szerokosc
            && newState.Y > this.Pozycja.Y && newState.Y < this.Pozycja.Y + this.Wysokosc
            && newState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released)
                return true;
            else
                return false;

            oldState = newState;
        }
    }
}
