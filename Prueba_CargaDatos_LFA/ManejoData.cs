using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_CargaDatos_LFA
{
    public class ManejoData
    {
        Dictionary<string, string> Transiciones = new Dictionary<string, string>();

        public void ObtenerValores(string Contenido)
        {
            string[] Datos;

            Datos = Contenido.Split("\r\n".ToCharArray(),StringSplitOptions.RemoveEmptyEntries);

            int NumEstados;
            int EstadoInicial;
            string Alfabeto;
            string Transiciones;

            NumEstados = Convert.ToInt32(Datos[0]);
            EstadoInicial = Convert.ToInt32(Datos[1]);
            Alfabeto = Datos[2];

            for (int i = 3; i < Datos.Length; i++)
            {
                Transiciones = Datos[i];
                ObtenerTransiciones(Transiciones);

            }
        }
        public void ObtenerTransiciones(string Contenido)
        {
            string[] Datos = Contenido.Split(',');

            int EstadoInicial;
            string Leer;
            string EstadoFinal;
            string Escribir;
            string Movimiento;

            EstadoInicial = Convert.ToInt32(Datos[0]);
            Leer = Datos[1];
            EstadoFinal = Datos[2];
            Escribir = Datos[3];
            Movimiento = Datos[4];

            string Llave = EstadoInicial + Leer;
            string Valor = EstadoFinal+'°'+Escribir+'°'+Movimiento;

            Transiciones.Add(Llave, Valor);
        
        }

    }
}
