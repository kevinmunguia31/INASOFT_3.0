using DocumentFormat.OpenXml.Spreadsheet;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INASOFT_3._0.Controladores
{
    class CtrlReporte
    {
        public SLDocument Reporte_Credito(DataGridView dt)
        {
            int cabecera = 9, celda_ini = 9;

            SLDocument sl = new SLDocument();
            CultureInfo culturaLocal = CultureInfo.CurrentCulture;

            sl.SetCellValue("F6", "Reporte de Credtios");
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

            
            sl.RenameWorksheet(SLDocument.DefaultFirstSheetName, "Reporte de crédito");

            sl.SetCellValue("B9", "ID Crédtio");

            sl.SetCellValue("C9", "Cod. Factura");

            sl.SetCellValue("D9", "Cliente");

            sl.SetCellValue("E9", "Estado");

            sl.SetCellValue("F9", "Inicio del crédito");

            sl.SetCellValue("G9", "Fin del crédtio");

            sl.SetCellValue("H9", "Días vencidos");

            sl.SetCellValue("I9", "Cargo");

            sl.SetCellValue("J9", "Pendiente");

            sl.SetCellValue("K9", "Total del monto");

            for (int fila = 0; fila < dt.Rows.Count; fila++)
            {
                cabecera++;
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

            sl.SetCellStyle("B" + celda_ini, "k" + cabecera, estiloB);
            sl.SetCellStyle("B" + celda_ini, "k" + cabecera, estilo_celda);
            sl.AutoFitColumn("B", "k");

            SLStyle cellStyle = sl.CreateStyle();
            cellStyle.FormatCode = "#,##0.00";
            sl.SetCellStyle("A", cellStyle);

            return sl;
        }

        public SLDocument Reporte_Facturas(DataGridView dt)
        {
            int cabecera = 9, celda_ini = 9;

            SLDocument sl = new SLDocument();
            CultureInfo culturaLocal = CultureInfo.CurrentCulture;

            sl.SetCellValue("F6", "Reporte de las facturas");
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
            

            return sl;
        }

        public SLDocument Reporte_Devolucion(DataGridView dt)
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

            return sl;
        }
    }
}
