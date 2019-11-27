using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using IronXL;
using Microsoft.Win32;

namespace HelperArchivos
{
    public static class HelperReportes
    {
        public static void GenerarReporteUsuario(Usuario usuario)
        {
            var fecha = DateTime.Now.ToString("yyyy-MM-dd / HH:mm:ss:ms");
            var fechaMod = fecha.Replace(" ", "").Replace("/", "-").Replace(":", "-").Replace("+", "");
            string fileName = usuario.Nombre + "" + usuario.Apellido + fechaMod;
            //crea el documento
            WorkBook xlsxWorkbook = WorkBook.Create(ExcelFileFormat.XLSX);
            xlsxWorkbook.Metadata.Author = "IronXL";
            //Add a blank WorkSheet
            WorkSheet xlsSheet = xlsxWorkbook.CreateWorkSheet("main_sheet");
            //Add data and styles to the new worksheet
            xlsSheet["A1"].Value = "Usuario";
            xlsSheet["B1"].Value = "Preguntas";
            xlsSheet["C1"].Value = "Cantidad de respuestas";
            xlsSheet["D1"].Value = "Estado de la pregunta";
            xlsSheet["E1"].Value = "Fecha";
            int row = 2;
            foreach (var preg in usuario.Preguntas)
            {

                xlsSheet["A" + row].Value = usuario.Nombre + " " + usuario.Apellido;
                xlsSheet["B" + row].Value = preg.Titulo;
                xlsSheet["C" + row].Value = preg.Respuestas.Count;
                xlsSheet["D" + row].Value = preg.Estado;
                xlsSheet["E" + row].Value = preg.Fecha;
                row++;

            }
            //Save the excel file
            xlsxWorkbook.SaveAs(fileName + ".xlsx");

        }


    }
}
