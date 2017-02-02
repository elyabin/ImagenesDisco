using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImagenesDisco
{
    public class AdministradorArchivosSeleccionados
    {

        private static List<string> _archivos = new List<string>();

        public static void Agregar(string pArchivo) 
        {
            if (_archivos.Contains(pArchivo) == false) 
            {
                _archivos.Add(pArchivo);
            }
        }
        public static void Eliminar(string pArchivo) 
        {
            _archivos.Remove(pArchivo);
        }

        public static List<string> ListadoArchivos 
        {
            get 
            {
                return _archivos;
            }
        }
    }
}
