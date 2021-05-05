﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace Clases_MT
{
    public class Class1
    {
        bool proceso = true;
        //List<char> Cinta = new List<char>();
        int EstadoActual = 1;
        //char SimboloLeido = ' ';
        int EstadoFinal = 1;
        char SimboloEscribir = ' ';
        char MovimientoCabezal = ' ';
        int posicion = 0;
        string UltimaTransicion = "";

        private void Movimiento(string alfabeto, Dictionary<string, string> Diccionario)
        {
            alfabeto = "_" + alfabeto;
            char[] cinta = alfabeto.ToCharArray();
            int cantidad = cinta.Count();
            do
            {
                string llave = Convert.ToString(cinta[posicion]) + Convert.ToString(EstadoActual);
                string datos = Diccionario[llave];
                string[] valores = datos.Split('°');
                EstadoFinal = int.Parse(valores[0]);
                SimboloEscribir = Convert.ToChar(valores[1]);
                MovimientoCabezal = Convert.ToChar(valores[2]);
                MovimientoCabezal = char.ToUpper(MovimientoCabezal);
                cinta[posicion] = SimboloEscribir;
                if (MovimientoCabezal=='I')
                {
                    if ((posicion - 1) > 0)
                    {
                        posicion--;
                        EstadoActual = EstadoFinal;
                    }
                    else
                    {
                        //mensaje error 
                    }
                }
                else if (MovimientoCabezal == 'D')
                {
                    if ((posicion + 1) < cantidad)
                    {
                        posicion++;
                        EstadoActual = EstadoFinal;
                    }
                    else
                    {
                        //mensaje error        
                    }
                }
                else if (MovimientoCabezal == 'P')
                {
                    EstadoActual = EstadoFinal;
                    proceso = false;
                }
                else
                {
                    EstadoActual = EstadoFinal;
                }

                string CintaActual = Convert.ToString(cinta);
                //posicion
                //Estado actual
                UltimaTransicion = Convert.ToString(cinta[posicion]) + "," + Convert.ToString(EstadoActual) + "," + valores[0] + "," + valores[1] + "," + valores[2];
                //return (cinta, posicion, EstadoActual, UltimaTransicion);
            } while (proceso);
        }
        
    }

}
