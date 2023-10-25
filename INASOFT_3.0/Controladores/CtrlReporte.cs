using DocumentFormat.OpenXml.Spreadsheet;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using DevExpress.Utils.CommonDialogs;


namespace INASOFT_3._0.Controladores
{
    class CtrlReporte
    {
        public void Reporte_Credito(DataGridView dt)
        {
            try
            {
                // Crear un nuevo documento Excel
                SLDocument sl = new SLDocument();
                CultureInfo culturaLocal = CultureInfo.CurrentCulture;

                sl.SetCellValue("F6", "Reporte de Créditos");
                SLStyle estilo_T = sl.CreateStyle();
                estilo_T.Font.FontName = "Arial";
                estilo_T.Font.FontSize = 14;
                estilo_T.Font.Bold = true;
                sl.SetCellStyle("F6", estilo_T);
                sl.MergeWorksheetCells("F6", "G6");

                SLStyle estilo_celda = sl.CreateStyle();
                estilo_celda.Font.FontName = "Arial";
                estilo_celda.Font.FontSize = 12;

                SLStyle estilo_Ca = sl.CreateStyle();
                estilo_Ca.Font.FontName = "Arial";
                estilo_Ca.Font.FontSize = 12;
                estilo_Ca.Font.Bold = true;
                estilo_Ca.Font.FontColor = System.Drawing.Color.Orange;
                estilo_Ca.Fill.SetPattern(PatternValues.Solid, System.Drawing.Color.Bisque, System.Drawing.Color.Bisque);
                sl.SetCellStyle("B9", "K9", estilo_Ca);

                sl.RenameWorksheet(SLDocument.DefaultFirstSheetName, "Reporte de crédito");

                sl.SetCellValue("B9", "ID Crédito");
                sl.SetCellValue("C9", "Cod. Factura");
                sl.SetCellValue("D9", "Cliente");
                sl.SetCellValue("E9", "Estado");
                sl.SetCellValue("F9", "Inicio del crédito");
                sl.SetCellValue("G9", "Fin del crédito");
                sl.SetCellValue("H9", "Días vencidos");
                sl.SetCellValue("I9", "Cargo");
                sl.SetCellValue("J9", "Pendiente");
                sl.SetCellValue("K9", "Total del monto");

                for (int fila = 0; fila < dt.Rows.Count; fila++)
                {
                    int cabecera = 10 + fila;
                    sl.SetCellValue("B" + cabecera, int.Parse(dt.Rows[fila].Cells[0].Value.ToString()));
                    sl.SetCellValue("C" + cabecera, dt.Rows[fila].Cells[1].Value.ToString());
                    sl.SetCellValue("D" + cabecera, dt.Rows[fila].Cells[2].Value.ToString());
                    sl.SetCellValue("E" + cabecera, dt.Rows[fila].Cells[3].Value.ToString());
                    sl.SetCellValue("F" + cabecera, dt.Rows[fila].Cells[4].Value.ToString());
                    sl.SetCellValue("G" + cabecera, dt.Rows[fila].Cells[5].Value.ToString());
                    sl.SetCellValue("H" + cabecera, int.Parse(dt.Rows[fila].Cells[6].Value.ToString()));

                    string aux1 = dt.Rows[fila].Cells[7].Value.ToString();
                    string[] words1 = aux1.Split(' ');
                    double aux_1 = Double.Parse(words1[1]);
                    sl.SetCellValue("I" + cabecera, aux_1);

                    string aux2 = dt.Rows[fila].Cells[8].Value.ToString();
                    string[] words2 = aux2.Split(' ');
                    double aux_2 = Double.Parse(words2[1]);
                    sl.SetCellValue("J" + cabecera, aux_2);

                    string aux3 = dt.Rows[fila].Cells[9].Value.ToString();
                    string[] words3 = aux3.Split(' ');
                    double aux_3 = Double.Parse(words3[1]);
                    sl.SetCellValue("K" + cabecera, aux_3);
                }

                // Borde de las celdas
                SLStyle estiloB = sl.CreateStyle();
                estiloB.Border.LeftBorder.BorderStyle = BorderStyleValues.Thin;
                estiloB.Border.LeftBorder.Color = System.Drawing.Color.Black;
                estiloB.Border.RightBorder.BorderStyle = BorderStyleValues.Thin;
                estiloB.Border.RightBorder.Color = System.Drawing.Color.Black;
                estiloB.Border.TopBorder.BorderStyle = BorderStyleValues.Thin;
                estiloB.Border.TopBorder.Color = System.Drawing.Color.Black;
                estiloB.Border.BottomBorder.BorderStyle = BorderStyleValues.Thin;
                estiloB.Border.BottomBorder.Color = System.Drawing.Color.Black;
                sl.SetCellStyle("B10", "K" + (dt.Rows.Count + 10), estiloB);
                sl.SetCellStyle("B10", "K" + (dt.Rows.Count + 10), estilo_celda);
                sl.AutoFitColumn("B", "K");

                SLStyle cellStyle = sl.CreateStyle();
                cellStyle.FormatCode = "#,##0.00";
                sl.SetCellStyle("A", cellStyle);

                // Genera un nombre de archivo temporal sin la extensión .tmp
                string tempFileName = Path.GetTempFileName();

                // Cambia la extensión del archivo temporal a .xlsx
                tempFileName = Path.ChangeExtension(tempFileName, ".xlsx");

                try
                {
                    // Guarda el documento Excel en el archivo temporal
                    sl.SaveAs(tempFileName);

                    // Abre el archivo con la aplicación predeterminada (Excel)
                    System.Diagnostics.Process.Start(tempFileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al exportar o abrir el archivo en Excel: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar: " + ex.Message);
            }
        }
        public void Reporte_Facturas(DataGridView dt)
        {
            int cabecera = 9, celda_ini = 9;

            SLDocument sl = new SLDocument();
            CultureInfo culturaLocal = CultureInfo.CurrentCulture;

            sl.SetCellValue("F6", "Reporte de las facturas");
            SLStyle estilo_T = sl.CreateStyle();
            estilo_T.Font.FontName = "Arial";
            estilo_T.Font.FontSize = 16;
            estilo_T.Font.Bold = true;
            sl.SetCellStyle("F6", estilo_T);
            sl.MergeWorksheetCells("F6", "G6");

            SLStyle estilo_celda = sl.CreateStyle();
            estilo_celda.Font.FontName = "Arial";
            estilo_celda.Font.FontSize = 12;

            SLStyle estilo_Ca = sl.CreateStyle();
            estilo_Ca.Font.FontName = "Arial";
            estilo_Ca.Font.FontSize = 12;
            estilo_Ca.Font.Bold = true;
            estilo_Ca.Font.FontColor = System.Drawing.Color.Orange;
            estilo_Ca.Fill.SetPattern(PatternValues.Solid, System.Drawing.Color.Bisque, System.Drawing.Color.Bisque);
            sl.SetCellStyle("B9", "O9", estilo_Ca);


            sl.RenameWorksheet(SLDocument.DefaultFirstSheetName, "Reporte de facturas");

            sl.SetCellValue("B9", "ID de la Factura");

            sl.SetCellValue("C9", "Cod. Factura");

            sl.SetCellValue("D9", "Estado");

            sl.SetCellValue("E9", "Fecha");

            sl.SetCellValue("F9", "Nombre del cliente");

            sl.SetCellValue("G9", "Cantidad de prod. comprados");

            sl.SetCellValue("H9", "Tipo de pago");

            sl.SetCellValue("I9", "Subtotal en C$");

            sl.SetCellValue("J9", "Descuento en C$");

            sl.SetCellValue("K9", "Total en C$");

            sl.SetCellValue("L9", "Efectivo en C$");

            sl.SetCellValue("M9", "Devolución en C$");

            sl.SetCellValue("N9", "Dinero pendiente");

            sl.SetCellValue("O9", "Nombre del empleado");

            for (int fila = 0; fila < dt.Rows.Count; fila++)
            {
                cabecera++;
                sl.SetCellValue("B" + cabecera, int.Parse(dt.Rows[fila].Cells[0].Value.ToString()));

                sl.SetCellValue("C" + cabecera, dt.Rows[fila].Cells[1].Value.ToString());

                sl.SetCellValue("D" + cabecera, dt.Rows[fila].Cells[2].Value.ToString());

                sl.SetCellValue("E" + cabecera, dt.Rows[fila].Cells[3].Value.ToString());

                sl.SetCellValue("F" + cabecera, dt.Rows[fila].Cells[4].Value.ToString());

                sl.SetCellValue("G" + cabecera, int.Parse(dt.Rows[fila].Cells[5].Value.ToString()));

                sl.SetCellValue("H" + cabecera, dt.Rows[fila].Cells[6].Value.ToString());

                string aux1 = dt.Rows[fila].Cells[7].Value.ToString();
                string[] words1 = aux1.Split(' ');
                double aux_1 = Double.Parse(words1[1]);

                sl.SetCellValue("I" + cabecera, aux_1);

                string aux2 = dt.Rows[fila].Cells[8].Value.ToString();
                string[] words2 = aux2.Split(' ');
                double aux_2 = Double.Parse(words2[1]);

                sl.SetCellValue("J" + cabecera, aux_2);

                string aux3 = dt.Rows[fila].Cells[9].Value.ToString();
                string[] words3 = aux3.Split(' ');
                double aux_3 = Double.Parse(words3[1]);

                sl.SetCellValue("K" + cabecera, aux_3);

                string aux4 = dt.Rows[fila].Cells[10].Value.ToString();
                string[] words4 = aux4.Split(' ');
                double aux_4 = Double.Parse(words4[1]);

                sl.SetCellValue("L" + cabecera, aux_4);

                string aux5 = dt.Rows[fila].Cells[11].Value.ToString();
                string[] words5 = aux5.Split(' ');
                double aux_5 = Double.Parse(words5[1]);

                sl.SetCellValue("M" + cabecera, aux_5);

                string aux6 = dt.Rows[fila].Cells[12].Value.ToString();
                string[] words6 = aux6.Split(' ');
                double aux_6 = Double.Parse(words6[1]);

                sl.SetCellValue("N" + cabecera, aux_6);

                sl.SetCellValue("O" + cabecera, dt.Rows[fila].Cells[13].Value.ToString());
            }

            //Borde de las celdas
            SLStyle estiloB = sl.CreateStyle();
            estiloB.Border.LeftBorder.BorderStyle = BorderStyleValues.Thin;
            estiloB.Border.LeftBorder.Color = System.Drawing.Color.Black;

            estiloB.Border.RightBorder.BorderStyle = BorderStyleValues.Thin;
            estiloB.Border.RightBorder.Color = System.Drawing.Color.Black;

            estiloB.Border.TopBorder.BorderStyle = BorderStyleValues.Thin;
            estiloB.Border.TopBorder.Color = System.Drawing.Color.Black;

            estiloB.Border.BottomBorder.BorderStyle = BorderStyleValues.Thin;
            estiloB.Border.BottomBorder.Color = System.Drawing.Color.Black;

            sl.SetCellStyle("B" + celda_ini, "O" + cabecera, estiloB);
            sl.SetCellStyle("B" + celda_ini, "O" + cabecera, estilo_celda);
            sl.AutoFitColumn("B", "O");

            SLStyle cellStyle = sl.CreateStyle();
            cellStyle.FormatCode = "#,##0.00";
            sl.SetCellStyle("I" + celda_ini, "N" + cabecera, cellStyle);

            // Genera un nombre de archivo temporal sin la extensión .tmp
            string tempFileName = Path.GetTempFileName();

            // Cambia la extensión del archivo temporal a .xlsx
            tempFileName = Path.ChangeExtension(tempFileName, ".xlsx");

            try
            {
                // Guarda el documento Excel en el archivo temporal
                sl.SaveAs(tempFileName);

                // Abre el archivo con la aplicación predeterminada (Excel)
                System.Diagnostics.Process.Start(tempFileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar o abrir el archivo en Excel: " + ex.Message);
            }
        }

        public void Reporte_Devolucion(DataGridView dt)
        {
            int cabecera = 9, celda_ini = 9;

            SLDocument sl = new SLDocument();
            CultureInfo culturaLocal = CultureInfo.CurrentCulture;

            sl.SetCellValue("F6", "Reporte de Devoluciones");
            SLStyle estilo_T = sl.CreateStyle();
            estilo_T.Font.FontName = "Arial";
            estilo_T.Font.FontSize = 14;
            estilo_T.Font.Bold = true;
            sl.SetCellStyle("F6", estilo_T);
            sl.MergeWorksheetCells("F6", "G6");

            SLStyle estilo_celda = sl.CreateStyle();
            estilo_celda.Font.FontName = "Arial";
            estilo_celda.Font.FontSize = 12;

            SLStyle estilo_Ca = sl.CreateStyle();
            estilo_Ca.Font.FontName = "Arial";
            estilo_Ca.Font.FontSize = 12;
            estilo_Ca.Font.Bold = true;
            estilo_Ca.Font.FontColor = System.Drawing.Color.Orange;
            estilo_Ca.Fill.SetPattern(PatternValues.Solid, System.Drawing.Color.Bisque, System.Drawing.Color.Bisque);
            sl.SetCellStyle("B9", "k9", estilo_Ca);


            sl.RenameWorksheet(SLDocument.DefaultFirstSheetName, "Reporte de devoluciones");

            sl.SetCellValue("B9", "ID Devolución");

            sl.SetCellValue("C9", "Cod. Factura");

            sl.SetCellValue("D9", "Fecha");

            sl.SetCellValue("E9", "Estado");

            sl.SetCellValue("F9", "Descripción");

            sl.SetCellValue("G9", "Cantidad de prod. devuelto");

            sl.SetCellValue("H9", "Total");

            sl.SetCellValue("I9", "Cliente");

            sl.SetCellValue("J9", "Trabajador");

            for (int fila = 0; fila < dt.Rows.Count; fila++)
            {
                cabecera++;
                sl.SetCellValue("B" + cabecera, int.Parse(dt.Rows[fila].Cells[0].Value.ToString()));

                sl.SetCellValue("C" + cabecera, dt.Rows[fila].Cells[1].Value.ToString());

                sl.SetCellValue("D" + cabecera, dt.Rows[fila].Cells[2].Value.ToString());

                sl.SetCellValue("E" + cabecera, dt.Rows[fila].Cells[3].Value.ToString());

                sl.SetCellValue("F" + cabecera, dt.Rows[fila].Cells[4].Value.ToString());

                sl.SetCellValue("G" + cabecera, int.Parse(dt.Rows[fila].Cells[5].Value.ToString()));

                string aux1 = dt.Rows[fila].Cells[6].Value.ToString();
                string[] words1 = aux1.Split(' ');
                double aux_1 = Double.Parse(words1[1]);

                sl.SetCellValue("H" + cabecera, aux_1);

                sl.SetCellValue("I" + cabecera, dt.Rows[fila].Cells[7].Value.ToString());

                sl.SetCellValue("J" + cabecera, dt.Rows[fila].Cells[8].Value.ToString());
            }

            //Borde de las celdas
            SLStyle estiloB = sl.CreateStyle();
            estiloB.Border.LeftBorder.BorderStyle = BorderStyleValues.Thin;
            estiloB.Border.LeftBorder.Color = System.Drawing.Color.Black;

            estiloB.Border.RightBorder.BorderStyle = BorderStyleValues.Thin;
            estiloB.Border.RightBorder.Color = System.Drawing.Color.Black;

            estiloB.Border.TopBorder.BorderStyle = BorderStyleValues.Thin;
            estiloB.Border.TopBorder.Color = System.Drawing.Color.Black;

            estiloB.Border.BottomBorder.BorderStyle = BorderStyleValues.Thin;
            estiloB.Border.BottomBorder.Color = System.Drawing.Color.Black;

            sl.SetCellStyle("B" + celda_ini, "J" + cabecera, estiloB);
            sl.SetCellStyle("B" + celda_ini, "J" + cabecera, estilo_celda);
            sl.AutoFitColumn("B", "J");

            SLStyle cellStyle = sl.CreateStyle();
            cellStyle.FormatCode = "#,##0.00";
            sl.SetCellStyle("A", cellStyle);

            // Genera un nombre de archivo temporal sin la extensión .tmp
            string tempFileName = Path.GetTempFileName();

            // Cambia la extensión del archivo temporal a .xlsx
            tempFileName = Path.ChangeExtension(tempFileName, ".xlsx");

            try
            {
                // Guarda el documento Excel en el archivo temporal
                sl.SaveAs(tempFileName);

                // Abre el archivo con la aplicación predeterminada (Excel)
                System.Diagnostics.Process.Start(tempFileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar o abrir el archivo en Excel: " + ex.Message);
            }
        }
        public void Reporte_Productos(DataGridView dt)
        {
            int cabecera = 9, celda_ini = 9;

            SLDocument sl = new SLDocument();
            CultureInfo culturaLocal = CultureInfo.CurrentCulture;

            sl.SetCellValue("F6", "Reporte de inventario");
            SLStyle estilo_T = sl.CreateStyle();
            estilo_T.Font.FontName = "Arial";
            estilo_T.Font.FontSize = 16;
            estilo_T.Font.Bold = true;
            sl.SetCellStyle("F6", estilo_T);
            sl.MergeWorksheetCells("F6", "G6");

            SLStyle estilo_celda = sl.CreateStyle();
            estilo_celda.Font.FontName = "Arial";
            estilo_celda.Font.FontSize = 12;

            SLStyle estilo_Ca = sl.CreateStyle();
            estilo_Ca.Font.FontName = "Arial";
            estilo_Ca.Font.FontSize = 12;
            estilo_Ca.Font.Bold = true;
            estilo_Ca.Font.FontColor = System.Drawing.Color.Orange;
            estilo_Ca.Fill.SetPattern(PatternValues.Solid, System.Drawing.Color.Bisque, System.Drawing.Color.Bisque);
            sl.SetCellStyle("B9", "M9", estilo_Ca);


            sl.RenameWorksheet(SLDocument.DefaultFirstSheetName, "Reporte del inventario");

            sl.SetCellValue("B9", "ID del producto");

            sl.SetCellValue("C9", "Cod. del producto");

            sl.SetCellValue("D9", "Nombre producto");

            sl.SetCellValue("E9", "Estado");

            sl.SetCellValue("F9", "Exsistencias");

            sl.SetCellValue("G9", "Existencia minimas");

            sl.SetCellValue("H9", "Precio compra");

            sl.SetCellValue("I9", "Precio venta");

            sl.SetCellValue("J9", "Precio Total");

            sl.SetCellValue("K9", "Observaciones");

            sl.SetCellValue("L9", "Tipo de entrada");

            sl.SetCellValue("M9", "Entrada especifica");

            for (int fila = 0; fila < dt.Rows.Count; fila++)
            {
                cabecera++;
                sl.SetCellValue("B" + cabecera, int.Parse(dt.Rows[fila].Cells[0].Value.ToString()));

                sl.SetCellValue("C" + cabecera, dt.Rows[fila].Cells[1].Value.ToString());

                sl.SetCellValue("D" + cabecera, dt.Rows[fila].Cells[2].Value.ToString());

                sl.SetCellValue("E" + cabecera, dt.Rows[fila].Cells[3].Value.ToString());

                sl.SetCellValue("F" + cabecera, int.Parse(dt.Rows[fila].Cells[4].Value.ToString()));

                sl.SetCellValue("G" + cabecera, int.Parse(dt.Rows[fila].Cells[5].Value.ToString()));
                
                string aux1 = dt.Rows[fila].Cells[6].Value.ToString();
                string[] words1 = aux1.Split(' ');
                double aux_1 = Double.Parse(words1[1]);

                sl.SetCellValue("H" + cabecera, aux_1);

                string aux2 = dt.Rows[fila].Cells[7].Value.ToString();
                string[] words2 = aux2.Split(' ');
                double aux_2 = Double.Parse(words2[1]);

                sl.SetCellValue("I" + cabecera, aux_2);

                string aux3 = dt.Rows[fila].Cells[8].Value.ToString();
                string[] words3 = aux3.Split(' ');
                double aux_3 = Double.Parse(words3[1]);

                sl.SetCellValue("J" + cabecera, aux_3);

                sl.SetCellValue("K" + cabecera, dt.Rows[fila].Cells[9].Value.ToString());

                sl.SetCellValue("L" + cabecera, dt.Rows[fila].Cells[10].Value.ToString());

                sl.SetCellValue("M" + cabecera, dt.Rows[fila].Cells[11].Value.ToString());
            }

            //Borde de las celdas
            SLStyle estiloB = sl.CreateStyle();
            estiloB.Border.LeftBorder.BorderStyle = BorderStyleValues.Thin;
            estiloB.Border.LeftBorder.Color = System.Drawing.Color.Black;

            estiloB.Border.RightBorder.BorderStyle = BorderStyleValues.Thin;
            estiloB.Border.RightBorder.Color = System.Drawing.Color.Black;

            estiloB.Border.TopBorder.BorderStyle = BorderStyleValues.Thin;
            estiloB.Border.TopBorder.Color = System.Drawing.Color.Black;

            estiloB.Border.BottomBorder.BorderStyle = BorderStyleValues.Thin;
            estiloB.Border.BottomBorder.Color = System.Drawing.Color.Black;

            sl.SetCellStyle("B" + celda_ini, "M" + cabecera, estiloB);
            sl.SetCellStyle("B" + celda_ini, "M" + cabecera, estilo_celda);
            sl.AutoFitColumn("B", "M");

            SLStyle cellStyle = sl.CreateStyle();
            cellStyle.FormatCode = "#,##0.00";
            sl.SetCellStyle("H" + celda_ini, "J" + cabecera, cellStyle);

            // Genera un nombre de archivo temporal sin la extensión .tmp
            string tempFileName = Path.GetTempFileName();

            // Cambia la extensión del archivo temporal a .xlsx
            tempFileName = Path.ChangeExtension(tempFileName, ".xlsx");

            try
            {
                // Guarda el documento Excel en el archivo temporal
                sl.SaveAs(tempFileName);

                // Abre el archivo con la aplicación predeterminada (Excel)
                System.Diagnostics.Process.Start(tempFileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar o abrir el archivo en Excel: " + ex.Message);
            }
        }

        //Reporte de las ganancias
        public void ReporteGanancias(DataGridView dt)
        {
            int cabecera = 2, celda_ini = 2;

            SLDocument sl = new SLDocument();
            CultureInfo culturaLocal = CultureInfo.CurrentCulture;

            sl.SetCellValue("A1", "Reporte de Devoluciones");
            SLStyle estilo_T = sl.CreateStyle();
            estilo_T.Font.FontName = "Arial";
            estilo_T.Font.FontSize = 14;
            estilo_T.Font.Bold = true;
            sl.SetCellStyle("A1", estilo_T);
            sl.MergeWorksheetCells("A1", "D1");

            SLStyle estilo_celda = sl.CreateStyle();
            estilo_celda.Font.FontName = "Arial";
            estilo_celda.Font.FontSize = 12;

            SLStyle estilo_Ca = sl.CreateStyle();
            estilo_Ca.Font.FontName = "Arial";
            estilo_Ca.Font.FontSize = 12;
            estilo_Ca.Font.Bold = true;
            estilo_Ca.Font.FontColor = System.Drawing.Color.Orange;
            estilo_Ca.Fill.SetPattern(PatternValues.Solid, System.Drawing.Color.Bisque, System.Drawing.Color.Bisque);
            sl.SetCellStyle("A2", "B2", estilo_Ca);


            sl.RenameWorksheet(SLDocument.DefaultFirstSheetName, "Reporte de devoluciones");

            sl.SetCellValue("A2", "Fecha");

            sl.SetCellValue("B2", "Ingresos");

            for (int fila = 0; fila < dt.Rows.Count; fila++)
            {
                cabecera++;
                var valorCelda0 = dt.Rows[fila].Cells[0].Value;
                if (valorCelda0 != null)
                {
                    sl.SetCellValue("A" + cabecera, valorCelda0.ToString());
                }
                else
                {
                    sl.SetCellValue("A" + cabecera, ""); // Otra opción podría ser establecer un valor predeterminado
                }

                var valorCelda1 = dt.Rows[fila].Cells[1].Value;
                if (valorCelda1 != null)
                {
                    sl.SetCellValue("B" + cabecera, double.Parse(valorCelda1.ToString()));
                }
                else
                {
                    sl.SetCellValue("B" + cabecera, ""); // Otra opción podría ser establecer un valor predeterminado
                }
            }

            //Borde de las celdas
            SLStyle estiloB = sl.CreateStyle();
            estiloB.Border.LeftBorder.BorderStyle = BorderStyleValues.Thin;
            estiloB.Border.LeftBorder.Color = System.Drawing.Color.Black;

            estiloB.Border.RightBorder.BorderStyle = BorderStyleValues.Thin;
            estiloB.Border.RightBorder.Color = System.Drawing.Color.Black;

            estiloB.Border.TopBorder.BorderStyle = BorderStyleValues.Thin;
            estiloB.Border.TopBorder.Color = System.Drawing.Color.Black;

            estiloB.Border.BottomBorder.BorderStyle = BorderStyleValues.Thin;
            estiloB.Border.BottomBorder.Color = System.Drawing.Color.Black;

            sl.SetCellStyle("A" + celda_ini, "B" + cabecera, estiloB);
            sl.SetCellStyle("A" + celda_ini, "B" + cabecera, estilo_celda);
            sl.AutoFitColumn("A", "B");

            SLStyle cellStyle = sl.CreateStyle();
            cellStyle.FormatCode = "#,##0.00";
            sl.SetCellStyle("B", cellStyle);

            // Genera un nombre de archivo temporal sin la extensión .tmp
            string tempFileName = Path.GetTempFileName();

            // Cambia la extensión del archivo temporal a .xlsx
            tempFileName = Path.ChangeExtension(tempFileName, ".xlsx");

            try
            {
                // Guarda el documento Excel en el archivo temporal
                sl.SaveAs(tempFileName);

                // Abre el archivo con la aplicación predeterminada (Excel)
                System.Diagnostics.Process.Start(tempFileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar o abrir el archivo en Excel: " + ex.Message);
            }
        }

        //Reporte producto màs y menos vendidos
        public void ReporteProductosMasMenosVendidos(DataGridView dt, DataGridView dt2)
        {
            int cabecera = 3, celda_ini = 3;
            int cabecera1 = 3, celda_ini1 = 3;

            SLDocument sl = new SLDocument();
            CultureInfo culturaLocal = CultureInfo.CurrentCulture;

            sl.SetCellValue("B1", "Reporte de Prodcutos más y menos vendidos");
            SLStyle estilo_T = sl.CreateStyle();
            estilo_T.Font.FontName = "Arial";
            estilo_T.Font.FontSize = 14;
            estilo_T.Font.Bold = true;

            sl.SetCellStyle("B1", estilo_T);
            sl.MergeWorksheetCells("B1", "G1");

            SLStyle estilo_celda = sl.CreateStyle();
            estilo_celda.Font.FontName = "Arial";
            estilo_celda.Font.FontSize = 12;

            SLStyle estilo_Ca = sl.CreateStyle();
            estilo_Ca.Font.FontName = "Arial";
            estilo_Ca.Font.FontSize = 12;
            estilo_Ca.Font.Bold = true;
            estilo_Ca.Font.FontColor = System.Drawing.Color.Orange;
            estilo_Ca.Fill.SetPattern(PatternValues.Solid, System.Drawing.Color.Bisque, System.Drawing.Color.Bisque);
            sl.SetCellValue("A2", "Prodcutos más vendidos");
            sl.SetCellStyle("A2", estilo_Ca);
            sl.SetCellStyle("A3", "B3", estilo_Ca);


            sl.RenameWorksheet(SLDocument.DefaultFirstSheetName, "Reporte de productos con más y menos demanda");

            sl.SetCellValue("A3", "Nombre del producto");

            sl.SetCellValue("B3", "Cant. de ventas");

            for (int fila = 0; fila < dt.Rows.Count; fila++)
            {
                cabecera++;
                var valorCelda0 = dt.Rows[fila].Cells[0].Value;
                if (valorCelda0 != null)
                {
                    sl.SetCellValue("A" + cabecera, valorCelda0.ToString());
                }
                else
                {
                    sl.SetCellValue("A" + cabecera, ""); // Otra opción podría ser establecer un valor predeterminado
                }

                var valorCelda1 = dt.Rows[fila].Cells[1].Value;
                if (valorCelda1 != null)
                {
                    sl.SetCellValue("B" + cabecera, int.Parse(valorCelda1.ToString()));
                }
                else
                {
                    sl.SetCellValue("B" + cabecera, ""); // Otra opción podría ser establecer un valor predeterminado
                }
            }

            sl.SetCellValue("D2", "Prodcutos menos vendidos");
            sl.SetCellStyle("D2", estilo_Ca);
            sl.SetCellStyle("D3", "E3", estilo_Ca);

            sl.SetCellValue("D3", "Nombre del producto");

            sl.SetCellValue("E3", "Cant. de ventas");

            for (int fila = 0; fila < dt2.Rows.Count; fila++)
            {
                cabecera1++;
                var valorCelda0 = dt2.Rows[fila].Cells[0].Value;
                if (valorCelda0 != null)
                {
                    sl.SetCellValue("D" + cabecera1, valorCelda0.ToString());
                }
                else
                {
                    sl.SetCellValue("D" + cabecera1, ""); // Otra opción podría ser establecer un valor predeterminado
                }

                var valorCelda1 = dt2.Rows[fila].Cells[1].Value;
                if (valorCelda1 != null)
                {
                    sl.SetCellValue("E" + cabecera1, int.Parse(valorCelda1.ToString()));
                }
                else
                {
                    sl.SetCellValue("E" + cabecera1, ""); // Otra opción podría ser establecer un valor predeterminado
                }
            }


            //Borde de las celdas
            SLStyle estiloB = sl.CreateStyle();
            estiloB.Border.LeftBorder.BorderStyle = BorderStyleValues.Thin;
            estiloB.Border.LeftBorder.Color = System.Drawing.Color.Black;

            estiloB.Border.RightBorder.BorderStyle = BorderStyleValues.Thin;
            estiloB.Border.RightBorder.Color = System.Drawing.Color.Black;

            estiloB.Border.TopBorder.BorderStyle = BorderStyleValues.Thin;
            estiloB.Border.TopBorder.Color = System.Drawing.Color.Black;

            estiloB.Border.BottomBorder.BorderStyle = BorderStyleValues.Thin;
            estiloB.Border.BottomBorder.Color = System.Drawing.Color.Black;

            sl.SetCellStyle("A" + celda_ini, "B" + cabecera, estiloB);
            sl.SetCellStyle("A" + celda_ini, "B" + cabecera, estilo_celda);

            sl.SetCellStyle("D" + celda_ini1, "E" + cabecera, estiloB);
            sl.SetCellStyle("D" + celda_ini1, "E" + cabecera, estilo_celda);

            sl.AutoFitColumn("A", "B");
            sl.AutoFitColumn("D", "E");

            SLStyle cellStyle = sl.CreateStyle();
            cellStyle.FormatCode = "#,##0.00";
            sl.SetCellStyle("B", cellStyle);
            sl.SetCellStyle("E", cellStyle);


            // Genera un nombre de archivo temporal sin la extensión .tmp
            string tempFileName = Path.GetTempFileName();

            // Cambia la extensión del archivo temporal a .xlsx
            tempFileName = Path.ChangeExtension(tempFileName, ".xlsx");

            try
            {
                // Guarda el documento Excel en el archivo temporal
                sl.SaveAs(tempFileName);

                // Abre el archivo con la aplicación predeterminada (Excel)
                System.Diagnostics.Process.Start(tempFileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar o abrir el archivo en Excel: " + ex.Message);
            }
        }

        //Reporte kardex de invenatario
        public void ReporteKardexInventario(DataGridView dt, DataGridView dt2, DataGridView dt3)
        {
            int cabecera = 3, celda_ini = 3;
            int cabecera1 = 3, celda_ini1 = 3;
            int cabecera2 = 3, celda_ini2 = 3;

            SLDocument sl = new SLDocument();
            CultureInfo culturaLocal = CultureInfo.CurrentCulture;

            sl.SetCellValue("F1", "Reporte Kardex del inventario");
            SLStyle estilo_T = sl.CreateStyle();
            estilo_T.Font.FontName = "Arial";
            estilo_T.Font.FontSize = 14;
            estilo_T.Font.Bold = true;

            sl.SetCellStyle("F1", estilo_T);
            sl.MergeWorksheetCells("F1", "H1");

            SLStyle estilo_celda = sl.CreateStyle();
            estilo_celda.Font.FontName = "Arial";
            estilo_celda.Font.FontSize = 12;

            SLStyle estilo_Ca = sl.CreateStyle();
            estilo_Ca.Font.FontName = "Arial";
            estilo_Ca.Font.FontSize = 12;
            estilo_Ca.Font.Bold = true;
            estilo_Ca.Font.FontColor = System.Drawing.Color.Orange;
            estilo_Ca.Fill.SetPattern(PatternValues.Solid, System.Drawing.Color.Bisque, System.Drawing.Color.Bisque);
            sl.SetCellValue("A2", "Productos en stocks");
            sl.SetCellStyle("A2", estilo_Ca);
            sl.SetCellStyle("A3", "C3", estilo_Ca);


            sl.RenameWorksheet(SLDocument.DefaultFirstSheetName, "Reporte Kardex de inventario");

            sl.SetCellValue("A3", "Estado del producto");

            sl.SetCellValue("B3", "Nombre del producto");

            sl.SetCellValue("C3", "Existencias acutales");

            for (int fila = 0; fila < dt.Rows.Count; fila++)
            {
                cabecera++;
                var valorCelda0 = dt.Rows[fila].Cells[0].Value;
                if (valorCelda0 != null)
                {
                    sl.SetCellValue("A" + cabecera, valorCelda0.ToString());
                }
                else
                {
                    sl.SetCellValue("A" + cabecera, ""); // Otra opción podría ser establecer un valor predeterminado
                }

                var valorCelda1 = dt.Rows[fila].Cells[1].Value;
                if (valorCelda1 != null)
                {
                    sl.SetCellValue("B" + cabecera, valorCelda1.ToString());
                }
                else
                {
                    sl.SetCellValue("B" + cabecera, ""); // Otra opción podría ser establecer un valor predeterminado
                }

                var valorCelda2 = dt.Rows[fila].Cells[2].Value;
                if (valorCelda2 != null)
                {
                    sl.SetCellValue("C" + cabecera, valorCelda2.ToString());
                }
                else
                {
                    sl.SetCellValue("C" + cabecera, ""); // Otra opción podría ser establecer un valor predeterminado
                }
            }

            sl.SetCellValue("E2", "Cambio de precio de los producto");
            sl.SetCellStyle("E2", estilo_Ca);
            sl.SetCellStyle("E3", "H3", estilo_Ca);

            sl.SetCellValue("E3", "Nombre del producto");

            sl.SetCellValue("F3", "Fecha del cambio");

            sl.SetCellValue("G3", "Precio Antiguo");

            sl.SetCellValue("H3", "Precio Nuevo");

            for (int fila = 0; fila < dt2.Rows.Count; fila++)
            {
                cabecera1++;
                var valorCelda0 = dt2.Rows[fila].Cells[0].Value;
                if (valorCelda0 != null)
                {
                    sl.SetCellValue("E" + cabecera1, valorCelda0.ToString());
                }
                else
                {
                    sl.SetCellValue("E" + cabecera1, ""); // Otra opción podría ser establecer un valor predeterminado
                }

                var valorCelda1 = dt2.Rows[fila].Cells[1].Value;
                if (valorCelda1 != null)
                {
                    sl.SetCellValue("F" + cabecera1, valorCelda1.ToString());
                }
                else
                {
                    sl.SetCellValue("F" + cabecera1, ""); // Otra opción podría ser establecer un valor predeterminado
                }

                var valorCelda2 = dt2.Rows[fila].Cells[2].Value;
                if (valorCelda2 != null)
                {
                    string aux1 = valorCelda2.ToString();
                    string[] words1 = aux1.Split(' ');
                    double aux_1 = Double.Parse(words1[1]);

                    sl.SetCellValue("G" + cabecera1, aux_1);
                }
                else
                {
                    sl.SetCellValue("G" + cabecera1, ""); // Otra opción podría ser establecer un valor predeterminado
                }

                var valorCelda3 = dt2.Rows[fila].Cells[3].Value;
                if (valorCelda3 != null)
                {
                    string aux1 = valorCelda3.ToString();
                    string[] words1 = aux1.Split(' ');
                    double aux_1 = Double.Parse(words1[1]);
                    sl.SetCellValue("H" + cabecera1, aux_1);
                }
                else
                {
                    sl.SetCellValue("H" + cabecera1, ""); // Otra opción podría ser establecer un valor predeterminado
                }
            }

            sl.SetCellValue("J2", "Prodcutos sin vender");
            sl.SetCellStyle("J2", estilo_Ca);
            sl.SetCellStyle("J3", "K3", estilo_Ca);

            sl.SetCellValue("J3", "Nombre del producto");

            sl.SetCellValue("K3", "Cant. en stock");

            for (int fila = 0; fila < dt3.Rows.Count; fila++)
            {
                cabecera2++;
                var valorCelda0 = dt3.Rows[fila].Cells[0].Value;
                if (valorCelda0 != null)
                {
                    sl.SetCellValue("J" + cabecera2, valorCelda0.ToString());
                }
                else
                {
                    sl.SetCellValue("J" + cabecera2, ""); // Otra opción podría ser establecer un valor predeterminado
                }

                var valorCelda1 = dt3.Rows[fila].Cells[1].Value;
                if (valorCelda1 != null)
                {
                    sl.SetCellValue("K" + cabecera2, int.Parse(valorCelda1.ToString()));
                }
                else
                {
                    sl.SetCellValue("K" + cabecera2, ""); // Otra opción podría ser establecer un valor predeterminado
                }
            }

            //Borde de las celdas
            SLStyle estiloB = sl.CreateStyle();
            estiloB.Border.LeftBorder.BorderStyle = BorderStyleValues.Thin;
            estiloB.Border.LeftBorder.Color = System.Drawing.Color.Black;

            estiloB.Border.RightBorder.BorderStyle = BorderStyleValues.Thin;
            estiloB.Border.RightBorder.Color = System.Drawing.Color.Black;

            estiloB.Border.TopBorder.BorderStyle = BorderStyleValues.Thin;
            estiloB.Border.TopBorder.Color = System.Drawing.Color.Black;

            estiloB.Border.BottomBorder.BorderStyle = BorderStyleValues.Thin;
            estiloB.Border.BottomBorder.Color = System.Drawing.Color.Black;

            sl.SetCellStyle("A" + celda_ini, "C" + cabecera, estiloB);
            sl.SetCellStyle("A" + celda_ini, "C" + cabecera, estilo_celda);

            sl.SetCellStyle("E" + celda_ini1, "H" + cabecera, estiloB);
            sl.SetCellStyle("E" + celda_ini1, "H" + cabecera, estilo_celda);
            
            sl.SetCellStyle("J" + celda_ini1, "K" + cabecera, estiloB);
            sl.SetCellStyle("J" + celda_ini1, "K" + cabecera, estilo_celda);

            sl.AutoFitColumn("A", "C");
            sl.AutoFitColumn("E", "H");
            sl.AutoFitColumn("J", "K");

            SLStyle cellStyle = sl.CreateStyle();
            cellStyle.FormatCode = "#,##0.00";
            sl.SetCellStyle("G", cellStyle);
            sl.SetCellStyle("H", cellStyle);


            // Genera un nombre de archivo temporal sin la extensión .tmp
            string tempFileName = Path.GetTempFileName();

            // Cambia la extensión del archivo temporal a .xlsx
            tempFileName = Path.ChangeExtension(tempFileName, ".xlsx");

            try
            {
                // Guarda el documento Excel en el archivo temporal
                sl.SaveAs(tempFileName);

                // Abre el archivo con la aplicación predeterminada (Excel)
                System.Diagnostics.Process.Start(tempFileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar o abrir el archivo en Excel: " + ex.Message);
            }
        }

        public void ReporteSalidasEntradas(DataGridView dt)
        {
            int cabecera = 2, celda_ini = 2;

            SLDocument sl = new SLDocument();
            CultureInfo culturaLocal = CultureInfo.CurrentCulture;

            sl.SetCellValue("A1", "Reporte de Salidas y Entradas");
            SLStyle estilo_T = sl.CreateStyle();
            estilo_T.Font.FontName = "Arial";
            estilo_T.Font.FontSize = 14;
            estilo_T.Font.Bold = true;
            sl.SetCellStyle("A1", estilo_T);
            sl.MergeWorksheetCells("A1", "D1");

            SLStyle estilo_celda = sl.CreateStyle();
            estilo_celda.Font.FontName = "Arial";
            estilo_celda.Font.FontSize = 12;

            SLStyle estilo_Ca = sl.CreateStyle();
            estilo_Ca.Font.FontName = "Arial";
            estilo_Ca.Font.FontSize = 12;
            estilo_Ca.Font.Bold = true;
            estilo_Ca.Font.FontColor = System.Drawing.Color.Orange;
            estilo_Ca.Fill.SetPattern(PatternValues.Solid, System.Drawing.Color.Bisque, System.Drawing.Color.Bisque);
            sl.SetCellStyle("A2", "D2", estilo_Ca);


            sl.RenameWorksheet(SLDocument.DefaultFirstSheetName, "Reporte de salidas y entradas");

            sl.SetCellValue("A2", "ID");

            sl.SetCellValue("B2", "Tipo de transacción");

            sl.SetCellValue("C2", "Fecha");

            sl.SetCellValue("D2", "Descripción");

            for (int fila = 0; fila < dt.Rows.Count; fila++)
            {
                cabecera++;
                var valorCelda0 = dt.Rows[fila].Cells[0].Value;
                if (valorCelda0 != null)
                {
                    sl.SetCellValue("A" + cabecera, valorCelda0.ToString());
                }
                else
                {
                    sl.SetCellValue("A" + cabecera, ""); // Otra opción podría ser establecer un valor predeterminado
                }

                var valorCelda1 = dt.Rows[fila].Cells[1].Value;
                if (valorCelda1 != null)
                {
                    sl.SetCellValue("B" + cabecera, valorCelda1.ToString());
                }
                else
                {
                    sl.SetCellValue("B" + cabecera, ""); // Otra opción podría ser establecer un valor predeterminado
                }

                var valorCelda2 = dt.Rows[fila].Cells[2].Value;
                if (valorCelda2 != null)
                {
                    sl.SetCellValue("C" + cabecera, valorCelda2.ToString());
                }
                else
                {
                    sl.SetCellValue("C" + cabecera, ""); // Otra opción podría ser establecer un valor predeterminado
                }

                var valorCelda3 = dt.Rows[fila].Cells[3].Value;
                if (valorCelda3 != null)
                {
                    sl.SetCellValue("D" + cabecera, valorCelda3.ToString());
                }
                else
                {
                    sl.SetCellValue("D" + cabecera, ""); // Otra opción podría ser establecer un valor predeterminado
                }
            }

            //Borde de las celdas
            SLStyle estiloB = sl.CreateStyle();
            estiloB.Border.LeftBorder.BorderStyle = BorderStyleValues.Thin;
            estiloB.Border.LeftBorder.Color = System.Drawing.Color.Black;

            estiloB.Border.RightBorder.BorderStyle = BorderStyleValues.Thin;
            estiloB.Border.RightBorder.Color = System.Drawing.Color.Black;

            estiloB.Border.TopBorder.BorderStyle = BorderStyleValues.Thin;
            estiloB.Border.TopBorder.Color = System.Drawing.Color.Black;

            estiloB.Border.BottomBorder.BorderStyle = BorderStyleValues.Thin;
            estiloB.Border.BottomBorder.Color = System.Drawing.Color.Black;

            sl.SetCellStyle("A" + celda_ini, "D" + cabecera, estiloB);
            sl.SetCellStyle("A" + celda_ini, "D" + cabecera, estilo_celda);
            sl.AutoFitColumn("A", "D");

            // Genera un nombre de archivo temporal sin la extensión .tmp
            string tempFileName = Path.GetTempFileName();

            // Cambia la extensión del archivo temporal a .xlsx
            tempFileName = Path.ChangeExtension(tempFileName, ".xlsx");

            try
            {
                // Guarda el documento Excel en el archivo temporal
                sl.SaveAs(tempFileName);

                // Abre el archivo con la aplicación predeterminada (Excel)
                System.Diagnostics.Process.Start(tempFileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar o abrir el archivo en Excel: " + ex.Message);
            }
        }
    }
}
