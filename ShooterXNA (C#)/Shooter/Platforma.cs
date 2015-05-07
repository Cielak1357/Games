using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shooter
{
    class Platforma : ObjektStal
    {
        public Platforma (Texture2D Textura, int wysokosc, int szerokosc, Vector2 pozycja)
            : base(Textura, wysokosc, szerokosc, pozycja)
        {

        }

    }
}
