using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class cola : objeto
    {
        cola siguiente;
        public cola(int x, int y)
        {
            this.x = x;
            this.y = y;
            siguiente = null;
        }

        public void dibujar(Graphics g)
        {
            if(siguiente != null)
                {
                siguiente.dibujar(g);
            }
            g.FillRectangle(new SolidBrush(Color.Black), this.x, this.y, this.ancho, this.ancho);
        }
        public void setxy(int x, int y)
        {
            if (siguiente != null)
            {
                siguiente.setxy(this.x, this.y);
            }
            this.x = x;
            this.y = y;
        }

        public void metieron()
        {
            if(siguiente == null)
            {
                siguiente = new cola(this.x, this.y);
            }
            else
            {
                siguiente.metieron();
            }
        }

        public  int verX()
        {
            return this.x;
        }
        public int very()
        {
            return this.y;
        }

        public cola verSig()
        {
            return siguiente;
        }
    }
}