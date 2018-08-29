﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form1 : Form

    {
        cola cabeza;
        Comida comida;
        Graphics g;
        int xdir = 0;
        int ydir = 0;
        Boolean ejex = true;
        Boolean ejey = true;
        int cuadro = 10;
        int punto = 0 ;
        public Form1()
        {
            InitializeComponent();
            cabeza = new cola(10, 10);
            comida = new Comida();
            g = canvas.CreateGraphics();
        }

        public void movimiento()
        {
            cabeza.setxy(cabeza.verX() + xdir, cabeza.very() + ydir);
        }

        public void choquepared()
        {
            if(cabeza.verX()<0 || cabeza.verX() > 800 || cabeza.very() < 0 || cabeza.very() > 430)
            {
                fin_del_juego();
            }
        }

        public void fin_del_juego()
        {
            punto = 0;
            puntos.Text = "0";
            ejex = true;
            ejey = true;
            xdir = 0;
            ydir = 0;
            cabeza = new cola(10, 10);
            comida = new Comida();
            MessageBox.Show("Game Over");

       

        }

        public void choquecuerpo()
        {
            cola temp;
            try
            {
                temp = cabeza.verSig().verSig();
            }
            catch(Exception err)
            {
                temp = null;
            }
            while(temp != null)
            {
                if (cabeza.interseccion(temp))
                {
                    fin_del_juego();

                }
                else
                {
                    temp = temp.verSig();
                }
            }
        }

        private void Bucle_Tick(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            cabeza.dibujar(g);
            comida.dibujar(g);
            movimiento();
            choquecuerpo();
            choquepared();
            if (cabeza.interseccion(comida))
            {
                comida.colocar();
                cabeza.metieron();
                punto++;
                puntos.Text = punto.ToString();

            }
        }
            private void Form1_KeyDown(object sender, KeyEventArgs e)
            {
                if (ejex)
                {
                    if (e.KeyCode == Keys.Up)
                    {
                        ydir = -cuadro;
                        xdir = 0;
                        ejex = false;
                        ejey = true;
                    }
                    if (e.KeyCode == Keys.Down)
                    {
                        ydir = cuadro;
                        xdir = 0;
                        ejex = false;
                        ejey = true;
                    }
                }
                if (ejey)
                {
                    if (e.KeyCode == Keys.Right)
                    {
                        ydir = 0;
                        xdir = cuadro;
                        ejex = true;
                        ejey = false;
                    }
                    if (e.KeyCode == Keys.Left)
                    {
                        ydir = 0;
                        xdir = -cuadro;
                        ejex = true;
                        ejey = false;


                    }
                }
            }
        }
    }
