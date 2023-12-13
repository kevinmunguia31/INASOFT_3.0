SELECT * FROM abono

-- OBTENER FACTURAS REALIZADAS HOY
SELECT 
    DATE(Fecha)     AS FECHA,
    CONCAT('FACT-', Codigo_Fac) AS CONCEPTO,
    Total_Final 
FROM facturas
WHERE   Tipo_Factura = 'Al Contado'
    AND DATE(Fecha) = DATE(NOW()) 
UNION
-- OBTENER ABONOS DEL DIA DE HOY
SELECT 
    DATE(Fecha)     AS FECHA,
    CONCAT('Abono#', ID) AS ABONOS,
    Monto 
FROM abono
WHERE  DATE(Fecha) = DATE(NOW()) 

-- Total Facturado Hoy + Abonos
SELECT 
    CONCAT('C$', FORMAT(SUM(Total), 0)) AS TotalGeneral
FROM (
    SELECT 
        DATE(Fecha) AS FECHA,
        SUM(Total_Final) AS Total
    FROM facturas
    WHERE Tipo_Factura = 'Al Contado'
        AND DATE(Fecha) = DATE(NOW())
    GROUP BY DATE(Fecha)

    UNION ALL

    SELECT 
        DATE(Fecha) AS FECHA,
        SUM(monto) AS Total
    FROM abono
    WHERE DATE(Fecha) = DATE(NOW())
    GROUP BY DATE(Fecha)
) AS subconsulta
GROUP BY FECHA;

-- Cantidad de Facturas Anuladas
SELECT COUNT(a.ID) AS 'Cant. Facturas Anuladas'FROM Facturas_Anuladas AS a INNER JOIN Facturas b ON a.ID_Factura = b.ID WHERE DATE(b.Fecha) = CURDATE();