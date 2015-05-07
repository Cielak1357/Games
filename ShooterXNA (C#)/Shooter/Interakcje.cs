using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Shooter
{
    class Interakcje
    {
        //public bool GraczObjektStal(Gracz gracz, ObjektStal objekt)
        //{
        //    var pozycja = gracz.Pozycja;
        //    var predkosc = gracz.Predkosc;
        //    bool czystoi = false;

        //    if (pozycja.X + gracz.textura.Width > objekt.Pozycja.X && pozycja.X < objekt.Pozycja.X + objekt.Szerokosc)
        //    {
        //        if (pozycja.Y + gracz.textura.Height > objekt.Pozycja.Y && pozycja.Y + gracz.textura.Height < objekt.Pozycja.Y + (objekt.Wysokosc / 2))
        //        {
        //            pozycja.Y = objekt.Pozycja.Y - gracz.textura.Height;
        //            gracz.podporaY = pozycja.Y;
        //            predkosc.Y = 0;
        //            czystoi = true;
        //        }
        //        else if (pozycja.Y > objekt.Pozycja.Y + (objekt.Wysokosc / 2) && pozycja.Y < objekt.Pozycja.Y + objekt.Wysokosc)
        //        {
        //            if (predkosc.Y < 1)
        //                predkosc.Y = 1;
        //            else
        //                predkosc.Y++;
                   
        //            pozycja.Y = objekt.Pozycja.Y + objekt.Wysokosc;
        //            gracz.podporaY = pozycja.Y;

        //        }

        //        gracz.podporaY = objekt.Pozycja.Y - gracz.textura.Height;
        //    }

        //    if (pozycja.Y < objekt.Pozycja.Y + objekt.Wysokosc && pozycja.Y + gracz.textura.Height > objekt.Pozycja.Y)
        //    {
        //        if (pozycja.X + gracz.textura.Width  > objekt.Pozycja.X && pozycja.X < objekt.Pozycja.X + (objekt.Szerokosc / 2))
        //        {
        //            predkosc.X = 0;
        //            pozycja.X = objekt.Pozycja.X - gracz.textura.Width;
        //            if (predkosc.Y < 0)
        //                predkosc.Y++;
        //            else if (predkosc.Y > 0)
        //                predkosc.Y -= (float)0.25;
        //        }
        //        else if (pozycja.X + gracz.textura.Width > objekt.Pozycja.X + (objekt.Szerokosc / 2) && pozycja.X < objekt.Pozycja.X + objekt.Szerokosc)
        //        {
        //            predkosc.X = 0;
        //            pozycja.X = objekt.Pozycja.X + objekt.Szerokosc;
        //            if (predkosc.Y < 0)
        //                predkosc.Y++;
        //            else if (predkosc.Y > 0)
        //                predkosc.Y-=(float)0.25;
        //        }
        //    }

        //    gracz.Pozycja = pozycja;
        //    gracz.Predkosc = predkosc;
        //    return czystoi;

        //}

        public void GraczBox (Box box, Gracz gracz)
        {
            if(gracz.Pozycja.X + gracz.textura.Width > box.Pozycja.X && gracz.Pozycja.X < box.Pozycja.X + box.Szerokosc
                && gracz.Pozycja.Y + gracz.textura.Height > box.Pozycja.Y && gracz.Pozycja.Y < box.Pozycja.Y + box.Wysokosc)
            {
                switch (box.Przedmiot)
                {
                    case "HP":
                        gracz.HP++;
                        break;
                    case "Niesmiertelnosc":
                        gracz.CzyNiesm = true;
                        gracz.Niesmiertelnosc = 5000;
                        break;
                    case "Pistolet":
                        gracz.Bron = new Bron(box.Przedmiot, gracz.Bronie[0], gracz.Pociski);
                        break;
                    case "Karabin":
                        gracz.Bron = new Bron(box.Przedmiot, gracz.Bronie[1], gracz.Pociski);
                        break;
                    case "Minigun":
                        gracz.Bron = new Bron(box.Przedmiot, gracz.Bronie[2], gracz.Pociski);
                        break;
                    case "Strzelba":
                        gracz.Bron = new Bron(box.Przedmiot, gracz.Bronie[3], gracz.Pociski);
                        break;
                    case "Snajpa":
                        gracz.Bron = new Bron(box.Przedmiot, gracz.Bronie[4], gracz.Pociski);
                        break;
                    case "Laser":
                        gracz.Bron = new Bron(box.Przedmiot, gracz.Bronie[5], gracz.Pociski);
                        break;
                }
                gracz.Punkty++;
                box.Reset();
            }
        }
        
        public bool IstotaObjektStal(Istota istota, ObjektStal objekt)
        {
            var pozycja = istota.Pozycja;
            var predkosc = istota.Predkosc;
            bool czystoi = false;

            if (pozycja.X + istota.textura.Width > objekt.Pozycja.X && pozycja.X < objekt.Pozycja.X + objekt.Szerokosc)
            {
                if (pozycja.Y + istota.textura.Height > objekt.Pozycja.Y && pozycja.Y + istota.textura.Height < objekt.Pozycja.Y + (objekt.Wysokosc / 2))
                {
                    pozycja.Y = objekt.Pozycja.Y - istota.textura.Height;
                    istota.podporaY = pozycja.Y;
                    predkosc.Y = 0;
                    czystoi = true;
                }
                else if (pozycja.Y > objekt.Pozycja.Y + (objekt.Wysokosc / 2) && pozycja.Y < objekt.Pozycja.Y + objekt.Wysokosc)
                {
                    if (predkosc.Y < 1)
                        predkosc.Y = 1;
                    else
                        predkosc.Y++;

                    pozycja.Y = objekt.Pozycja.Y + objekt.Wysokosc;
                    istota.podporaY = pozycja.Y;

                }

                istota.podporaY = objekt.Pozycja.Y - istota.textura.Height;
            }

            if (pozycja.Y < objekt.Pozycja.Y + objekt.Wysokosc && pozycja.Y + istota.textura.Height > objekt.Pozycja.Y)
            {
                if (pozycja.X + istota.textura.Width > objekt.Pozycja.X && pozycja.X < objekt.Pozycja.X + (objekt.Szerokosc / 2))
                {
                    predkosc.X = 0;
                    pozycja.X = objekt.Pozycja.X - istota.textura.Width;
                    if (predkosc.Y < 0)
                        predkosc.Y++;
                    else if (predkosc.Y > 0)
                        predkosc.Y -= (float)0.25;
                }
                else if (pozycja.X + istota.textura.Width > objekt.Pozycja.X + (objekt.Szerokosc / 2) && pozycja.X < objekt.Pozycja.X + objekt.Szerokosc)
                {
                    predkosc.X = 0;
                    pozycja.X = objekt.Pozycja.X + objekt.Szerokosc;
                    if (predkosc.Y < 0)
                        predkosc.Y++;
                    else if (predkosc.Y > 0)
                        predkosc.Y -= (float)0.25;
                }
            }

            istota.Pozycja = pozycja;
            istota.Predkosc = predkosc;
            return czystoi;

        }

        public void PociskChodzacy(Pocisk[] pociski, Chodzacy[] istoty)
        {
           
            for(int i = 0; i < pociski.Length; i++)
            {
                for (int j = 0; j < istoty.Length; j++)
                {
                    if (pociski[i].Aktywny == true && istoty[j].Aktywny == true)
                    {
                        if (pociski[i].Typ == "Laser" && pociski[i].Predkosc.X < 0)
                        {
                            if (pociski[i].Pozycja.X > istoty[j].Pozycja.X && pociski[i].Pozycja.X - pociski[i].textura.Width < istoty[j].Pozycja.X + istoty[j].textura.Width
                            && pociski[i].Pozycja.Y + pociski[i].textura.Height >= istoty[j].Pozycja.Y && pociski[i].Pozycja.Y <= istoty[j].Pozycja.Y + istoty[j].textura.Height)
                            {
                                istoty[j].HP -= pociski[i].Obrazenia;
                                pociski[i].HP--;

                                if (pociski[i].HP <= 0)
                                    pociski[i].Aktywny = false;

                                if (istoty[j].HP <= 0)
                                    istoty[j].Aktywny = false;
                            }
                        }
                        else
                        {
                            if (pociski[i].Pozycja.X + pociski[i].textura.Width > istoty[j].Pozycja.X && pociski[i].Pozycja.X < istoty[j].Pozycja.X + istoty[j].textura.Width
                            && pociski[i].Pozycja.Y + pociski[i].textura.Height >= istoty[j].Pozycja.Y && pociski[i].Pozycja.Y <= istoty[j].Pozycja.Y + istoty[j].textura.Height)
                            {
                                istoty[j].HP -= pociski[i].Obrazenia;
                                pociski[i].HP--;

                                if (pociski[i].HP <= 0)
                                    pociski[i].Aktywny = false;

                                if (istoty[j].HP <= 0)
                                    istoty[j].Aktywny = false;

                            }
                        }
                    }
                }

             }

         }

        public void GraczIstota(Gracz gracz, Chodzacy[] istoty)
        {

            for (int i=0; i<istoty.Length; i++)
            {
                if (istoty[i].Aktywny == true
                && gracz.Pozycja.Y + gracz.textura.Height >= istoty[i].Pozycja.Y && gracz.Pozycja.Y <= istoty[i].Pozycja.Y + istoty[i].textura.Height
                && gracz.Pozycja.X + gracz.textura.Width > istoty[i].Pozycja.X && gracz.Pozycja.X < istoty[i].Pozycja.X + istoty[i].textura.Width)
                {
                    gracz.HP--;
                    gracz.CzyNiesm = true;
                    gracz.Niesmiertelnosc = 1000;
                }
            }
        }

        public void ScenaGracz(Gracz objekt, Scena scena)
        {
            var pozycja = objekt.Pozycja;

            if (pozycja.X < (float)0)
                pozycja.X = (float)scena.Szerokosc;
            if (pozycja.X > (float)scena.Szerokosc)
                pozycja.X = (float)0;
            //if (pozycja.Y < (float)0)
            //    pozycja.Y = 0;
            if (pozycja.Y > (float)scena.Wysokosc)
                pozycja.Y = (float)0;

            objekt.Pozycja = pozycja;
        }

        public void ScenaChodzacy(Chodzacy objekt, Scena scena)
        {
            var pozycja = objekt.Pozycja;
            var predkosc = objekt.Predkosc;

            if (pozycja.Y + objekt.textura.Height < (float)440)
            {
                if (pozycja.X < (float)0)
                    pozycja.X = (float)scena.Szerokosc;
                    
                if (pozycja.X > (float)scena.Szerokosc)
                    pozycja.X = (float)0;
            }
            else
            {
                if (pozycja.X < (float)0)
                {
                    pozycja.X = (float)0;
                    pozycja.Y = (float)scena.Wysokosc / 5 - objekt.textura.Height;
                    predkosc.X = 10;
                    objekt.isRage = true;
                }
                if (pozycja.X > (float)scena.Szerokosc)
                {
                    pozycja.X = (float)scena.Szerokosc;
                    pozycja.Y = (float)scena.Wysokosc / 5 - objekt.textura.Height;
                    predkosc.X = -10;
                    objekt.isRage = true;
                }
            }
            
            if (pozycja.Y < (float)0)
                pozycja.Y = 0;
            if (pozycja.Y > (float)scena.Wysokosc)
                pozycja.Y = (float)0;

            objekt.Predkosc = predkosc;
            objekt.Pozycja = pozycja;
        }

        public void ScenaPocisk(Pocisk objekt, Scena scena)
        {
            if (objekt.Pozycja.X < (float)0 || objekt.Pozycja.X > (float)scena.Szerokosc)
                objekt.Aktywny = false;
        }
    }
}
