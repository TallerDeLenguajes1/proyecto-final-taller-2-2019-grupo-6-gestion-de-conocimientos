using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 
namespace helperArchivos
{
    public class HelperImagen
    {
        OpenFileDialog op = new OpenFileDialog();
        op.Title = "Seleccionar imagen";
            op.Filter = "Tipos de archivo|*.jpg;*png|" + "JPEG (*.jpg)|*.jpg;|" + "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                //imgPhoto.Source = new BitmapImage(new Uri(op.FileName));
                string fileName = op.SafeFileName;
        string source = op.FileName;
        string target = @"img";
        int strLength = fileName.Length;

        var fecha = DateTime.Now.ToString("yyyy-MM-dd / HH:mm:ss:ms zzz");
        Console.WriteLine(fecha);
                var fechaMod = fecha.Replace("-", "").Replace(" ", "").Replace("/", "").Replace(":", "").Replace("+", "");
        Console.WriteLine(fechaMod);

                string newName = fileName.Insert(strLength - 4, fechaMod);

        //MessageBox.Show(newName);
        string destFile = System.IO.Path.Combine(target, newName);

        System.IO.File.Copy(source, destFile, true);
                //destFile es lo que hay que guardar en la DB
                imagenFinal = destFile;
               //MessageBox.Show(destFile);
            }
}
}
