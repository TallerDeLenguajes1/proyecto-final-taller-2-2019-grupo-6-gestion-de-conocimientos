using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using NLog;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace HelperArchivos
{
    public static class HelperReportes
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static string GenerarReportePreguntas(List<Pregunta> preguntas)
        {
            try
            {
                using (var package = new ExcelPackage())
                {
                    // Add a new worksheet to the empty workbook
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Reporte Usuario");
                    //Add the headers
                    worksheet.Cells[1, 1].Value = "Usuario";
                    worksheet.Cells[1, 2].Value = "Pregunta";
                    worksheet.Cells[1, 3].Value = "Cantidad de respuestas";
                    worksheet.Cells[1, 4].Value = "Estado de la pregunta";
                    worksheet.Cells[1, 5].Value = "Fecha de la pregunta";

                    //Add some items...
                    int row = 2;
                    foreach (Pregunta preg in preguntas)
                    {
                        worksheet.Cells[row, 1].Value = preg.UserPregunta.ToString();
                        worksheet.Cells[row, 2].Value = preg.ToString();
                        worksheet.Cells[row, 3].Value = preg.Respuestas.Count;
                        worksheet.Cells[row, 4].Value = preg.Estado;
                        worksheet.Cells[row, 5].Value = preg.Fecha.ToShortDateString() + " " + preg.Fecha.ToShortTimeString();

                        // Aplicar estilo a la celda de Estado
                        worksheet.Cells[row, 4].Style.Font.Bold = true;

                        var color = System.Drawing.Color.Black; // Color por defecto
                        if (preg.Estado == "Activa")
                        {
                            color = System.Drawing.Color.Blue;
                        }
                        else if (preg.Estado == "Inactiva")
                        {
                            color = System.Drawing.Color.PaleVioletRed;
                        }
                        else if (preg.Estado == "Suspendida")
                        {
                            color = System.Drawing.Color.Red;
                        }
                        else if (preg.Estado == "Solucionada")
                        {
                            color = System.Drawing.Color.Green;
                        }
                        worksheet.Cells[row, 4].Style.Font.Color.SetColor(color);

                        row++;
                    }

                    //Ok now format the values
                    using (var range = worksheet.Cells[1, 1, 1, 5])
                    {
                        range.Style.Font.Bold = true;
                        range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.DarkBlue);
                        range.Style.Font.Color.SetColor(System.Drawing.Color.White);
                    }

                    worksheet.Cells.AutoFitColumns(0);  //Autofit columns for all cells

                    // set some document properties
                    package.Workbook.Properties.Title = "Reporte de preguntas";

                    string fechaActual = DateTime.Now.ToString("yyyy-MM-dd / HH:mm:ss:ms");
                    fechaActual = fechaActual.Replace(" ", "");
                    fechaActual = fechaActual.Replace("/", "-");
                    fechaActual = fechaActual.Replace(":", "-");
                    fechaActual = fechaActual.Replace("+", "");
                    string fileName = "ReportePreguntas_" + fechaActual;

                    var xlFile = new FileInfo(fileName + ".xlsx");
                    // save our new workbook in the output directory and we are done!
                    package.SaveAs(xlFile);

                    return xlFile.ToString();
                }

            }
            catch (Exception ex)
            {
                // Log del error
                string error = "Error en generacion de reporte de preguntas";
                error += "\n--------------------\n";
                error += ex.ToString();
                error += "\n--------------------\n";
                logger.Error(error);

                return string.Empty;
            }
        }

        public static string GenerarReporteRespuestas(List<Respuesta> respuestas)
        {
            try
            {
                using (var package = new ExcelPackage())
                {
                    // Add a new worksheet to the empty workbook
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Reporte Usuario");
                    //Add the headers
                    worksheet.Cells[1, 1].Value = "Usuario";
                    worksheet.Cells[1, 2].Value = "Respuesta";
                    worksheet.Cells[1, 3].Value = "Cantidad de likes";
                    worksheet.Cells[1, 4].Value = "Fecha de la respuesta";

                    //Add some items...
                    int row = 2;
                    foreach (Respuesta resp in respuestas)
                    {
                        worksheet.Cells[row, 1].Value = resp.UserRespuesta.ToString();
                        worksheet.Cells[row, 2].Value = resp.Titulo;
                        worksheet.Cells[row, 3].Value = resp.GetCantidadLikes();
                        worksheet.Cells[row, 4].Value = resp.Fecha.ToShortDateString() + " " + resp.Fecha.ToShortTimeString();

                        row++;
                    }

                    //Ok now format the values
                    using (var range = worksheet.Cells[1, 1, 1, 4])
                    {
                        range.Style.Font.Bold = true;
                        range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.DarkBlue);
                        range.Style.Font.Color.SetColor(System.Drawing.Color.White);
                    }

                    worksheet.Cells.AutoFitColumns(0);  //Autofit columns for all cells

                    // set some document properties
                    package.Workbook.Properties.Title = "Reporte de respuestas";

                    string fechaActual = DateTime.Now.ToString("yyyy-MM-dd / HH:mm:ss:ms");
                    fechaActual = fechaActual.Replace(" ", "");
                    fechaActual = fechaActual.Replace("/", "-");
                    fechaActual = fechaActual.Replace(":", "-");
                    fechaActual = fechaActual.Replace("+", "");
                    string fileName = "ReporteRespuestas_" + fechaActual;

                    var xlFile = new FileInfo(fileName + ".xlsx");
                    // save our new workbook in the output directory and we are done!
                    package.SaveAs(xlFile);

                    return xlFile.ToString();
                }

            }
            catch (Exception ex)
            {
                // Log del error
                string error = "Error en generacion de reporte de respuestas";
                error += "\n--------------------\n";
                error += ex.ToString();
                error += "\n--------------------\n";
                logger.Error(error);

                return string.Empty;
            }
        }

    }
}
