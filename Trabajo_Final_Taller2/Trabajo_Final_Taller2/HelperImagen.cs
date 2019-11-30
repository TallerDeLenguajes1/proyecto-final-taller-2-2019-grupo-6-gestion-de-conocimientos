using Microsoft.Win32;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Final_Taller2
{
    public static class HelperImagen
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        // Carpeta de destino donde se guardan las imagenes
        static readonly string CarpetaImagenes = "img";
        static readonly string ImagenDefault = "ImageNotFound.jpg";

        /// <summary>
        /// Guarda la imagen seleccionada en la carpeta de destino y retorna el nombre del nuevo archivo
        /// <para>Si la ruta es vacia no guarda nada y devuelve un string vacio</para>
        /// </summary>
        /// <param name="rutaImagen"></param>
        /// <returns></returns>
        public static string GuardarImagen(string rutaImagen)
        {
            if (string.IsNullOrWhiteSpace(rutaImagen) == false)
            {
                string extension = rutaImagen.Split('.')[1]; // La extension del archivo
                
                string fechaActual = DateTime.Now.ToString("yyyy-MM-dd / HH:mm:ss:ms zzz");

                // Se modifica la fecha para eliminar caracteres invalidos
                fechaActual = fechaActual.Replace("-", "");
                fechaActual = fechaActual.Replace(" ", "");
                fechaActual = fechaActual.Replace("/", "");
                fechaActual = fechaActual.Replace(":", "");
                fechaActual = fechaActual.Replace("+", "");

                // Se arma el string con el nombre de la imagen
                string nombreArchivo = fechaActual + "." + extension;

                try
                {
                    // Se arma el string de la ruta del archivo a guardar
                    string rutaDestino = System.IO.Path.Combine(CarpetaImagenes, nombreArchivo);

                    // Se copia la imagen al destino
                    System.IO.File.Copy(rutaImagen, rutaDestino, true);

                    // Se retorna el nombre de la imagen para guardar en la base de datos
                    return nombreArchivo;
                }
                catch (Exception ex)
                {
                    // Log del error
                    string error = "Error en HelperImagen GuardarImagen";
                    error += "\n--------------------\n";
                    error += ex.ToString();
                    error += "\n--------------------\n";
                    logger.Error(error);

                    return string.Empty;
                }
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Retorna la ruta a la imagen seleccionada, o un string vacio si no se selecciona una imagen
        /// </summary>
        /// <returns></returns>
        public static string SeleccionarImagen()
        {
            try
            {
                OpenFileDialog op = new OpenFileDialog();
                op.Title = "Seleccionar imagen";
                op.Filter = "Tipos de archivo|*.jpg;*.jpeg;*.png|" + "JPEG (*.jpg)|*.jpg;*.jpeg|" + "Portable Network Graphic (*.png)|*.png";

                if (op.ShowDialog() == true)
                {
                    string source = op.FileName;
                    return source;
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                // Log del error
                string error = "Error en HelperImagen SeleccionarImagen";
                error += "\n--------------------\n";
                error += ex.ToString();
                error += "\n--------------------\n";
                logger.Error(error);

                return string.Empty;
            }
        }

        /// <summary>
        /// Determina si la imagen existe en la carpeta de imagenes y devuelve la ruta absoluta a ella
        /// <para>Si no encuentra la imagen retorna la ruta absoluta a una imagen por defecto</para>
        /// <para>Si no existe la imagen por defecto devuelve un string vacio</para>
        /// </summary>
        /// <param name="nombreImagen"></param>
        /// <returns></returns>
        public static string BuscarImagen(string nombreImagen)
        {
            string rutaImagen;
            try
            {
                rutaImagen = System.IO.Path.Combine(CarpetaImagenes, nombreImagen);

                if (File.Exists(rutaImagen))
                {
                    return Ruta_Relativa_a_Absoluta(rutaImagen);
                }
                else
                {
                    // Busca la imagen por defecto
                    rutaImagen = System.IO.Path.Combine(CarpetaImagenes, ImagenDefault);

                    if (File.Exists(rutaImagen))
                    {
                        return Ruta_Relativa_a_Absoluta(rutaImagen);
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                // Log del error
                string error = "Error en HelperImagen BuscarImagen";
                error += "\n--------------------\n";
                error += ex.ToString();
                error += "\n--------------------\n";
                logger.Error(error);

                return string.Empty;
            }
        }

        /// <summary>
        /// Convierte una ruta de imagen relativa a absoluta
        /// <para>Devuelve un string vacio si no se pudo realizar la conversion</para>
        /// </summary>
        /// <returns></returns>
        private static string Ruta_Relativa_a_Absoluta(string rutaRelativa)
        {
            try
            {
                string rutaAbsoluta = AppDomain.CurrentDomain.BaseDirectory + rutaRelativa;
                return rutaAbsoluta;
            }
            catch (Exception ex)
            {
                // Log del error
                string error = "Error en HelperImagen Ruta_Relativa_a_Absoluta";
                error += "\n--------------------\n";
                error += ex.ToString();
                error += "\n--------------------\n";
                logger.Error(error);
                
                return string.Empty;
            }
        }
    }
}
