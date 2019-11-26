using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Final_Taller2
{
    public static class HelperImagen
    {
        /// <summary>
        /// Lo que hace este metodo es, al hacer click se abre un cuadro para seleccionar imagen; se usan unos parametros para especificar 
        /// que tipo de imagenes se pueden subir
        /// despues se obtiene el nombre del archivo, la ruta + el nombre, a donde se quiere copiar el archivo y destFile que va a ser la nueva ruta + el nombre dek archivo
        /// luego se copia la imagen en la carpeta de imagenes del proyecto.
        /// </summary>
        public static string GuardarImagen()
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Seleccionar imagen";
            op.Filter = "Tipos de archivo|*.jpg;*.jpeg;*.png|" + "JPEG (*.jpg)|*.jpg;*.jpeg|" + "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                //imgPhoto.Source = new BitmapImage(new Uri(op.FileName));
                string fileName = op.SafeFileName;
                string source = op.FileName;
                string target = @"img";
                int strLength = fileName.Length;
                int extLength = fileName.Split('.')[1].Length;

                var fecha = DateTime.Now.ToString("yyyy-MM-dd / HH:mm:ss:ms zzz");
                var fechaMod = fecha.Replace("-", "").Replace(" ", "").Replace("/", "").Replace(":", "").Replace("+", "");

                string newName = fileName.Insert(strLength - extLength - 1, fechaMod);

                //MessageBox.Show(newName);
                string destFile = System.IO.Path.Combine(target, newName);

                System.IO.File.Copy(source, destFile, true);
                //destFile es lo que hay que guardar en la DB
                return destFile;
                //MessageBox.Show(destFile);
            }
            else
            {
                return null;
            }
        }
    }
}
