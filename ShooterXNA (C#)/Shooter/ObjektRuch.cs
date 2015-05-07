using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shooter
{
    abstract class ObjektRuch
    {
        public Vector2 Pozycja { get; set; }
        public Vector2 Predkosc { get; set; }
        public Texture2D textura;
        protected int maxpredkosc;


        public ObjektRuch(Texture2D Textura, Vector2 pozycja, Vector2 predkosc)
        {
            this.textura = Textura;
            this.Pozycja = pozycja;
            this.Predkosc = predkosc;
        }
        
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            
            spriteBatch.Draw(this.textura, this.Pozycja, new Rectangle(0, 0, this.textura.Width, this.textura.Height), Color.White);
            
        }

        public virtual void Ruch()
        {
            Pozycja += Predkosc;
        }
    }
}
