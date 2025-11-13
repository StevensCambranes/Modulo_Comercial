-- ===========================================
-- BD COMPLETA DEL MÓDULO CUENTAS POR COBRAR
-- ===========================================

-- Borra y crea la BD (opcional si quieres re-ejecutar el script)
DROP DATABASE IF EXISTS bd_cxc;
CREATE DATABASE bd_cxc
  CHARACTER SET utf8mb4
  COLLATE utf8mb4_general_ci;

USE bd_cxc;

SET FOREIGN_KEY_CHECKS = 0;

-- ===========================
-- 1) CLIENTES
-- ===========================
CREATE TABLE tbl_cliente (
    Id_Cliente          INT AUTO_INCREMENT PRIMARY KEY,
    Cmp_Nombre_Cliente  VARCHAR(150) NOT NULL,
    Cmp_Direccion       VARCHAR(200),
    Cmp_Telefono        VARCHAR(50),
    Cmp_Nit             VARCHAR(20)
);

-- ===========================
-- 2) TIPOS DE DOCUMENTO
-- ===========================
CREATE TABLE tbl_tipo_documento (
    Id_Tipo_Documento    INT AUTO_INCREMENT PRIMARY KEY,
    Cmp_Nombre_Documento VARCHAR(50) NOT NULL
);

INSERT INTO tbl_tipo_documento (Cmp_Nombre_Documento) VALUES
('FACTURA'),
('NOTA DE CREDITO');

-- ===========================
-- 3) DOCUMENTOS POR COBRAR
-- ===========================
CREATE TABLE tbl_documento_cxc (
    Id_Documento         INT AUTO_INCREMENT PRIMARY KEY,
    Id_Cliente           INT NOT NULL,
    Id_Tipo_Documento    INT NULL,
    Cmp_Numero           VARCHAR(30) NOT NULL,
    Cmp_Fecha            DATE NOT NULL,
    Cmp_Total_Documento  DECIMAL(12,2) NOT NULL,
    Cmp_Saldo_Actual     DECIMAL(12,2) NOT NULL,
    Cmp_Es_Credito       TINYINT(1) NOT NULL DEFAULT 1,
    Cmp_Fecha_Venc       DATE NULL,

    CONSTRAINT fk_doc_cliente
      FOREIGN KEY (Id_Cliente) REFERENCES tbl_cliente(Id_Cliente),
    CONSTRAINT fk_doc_tipodoc
      FOREIGN KEY (Id_Tipo_Documento) REFERENCES tbl_tipo_documento(Id_Tipo_Documento)
);

-- ===========================
-- 4) PAGOS DIRECTOS A DOC (no usados aún, pero útiles)
-- ===========================
CREATE TABLE tbl_pago_cxc (
    Id_Pago         INT AUTO_INCREMENT PRIMARY KEY,
    Id_Documento    INT NOT NULL,
    Cmp_Fecha_Pago  DATE NOT NULL,
    Cmp_Monto_Pago  DECIMAL(12,2) NOT NULL,
    Cmp_Descripcion VARCHAR(200),

    CONSTRAINT fk_pago_doc
      FOREIGN KEY (Id_Documento) REFERENCES tbl_documento_cxc(Id_Documento)
);

-- ===========================
-- 5) MÉTODOS DE PAGO
-- ===========================
CREATE TABLE tbl_metodo_pago (
    Id_Metodo_Pago   INT AUTO_INCREMENT PRIMARY KEY,
    Cmp_Nombre_Metodo VARCHAR(100) NOT NULL
);

INSERT INTO tbl_metodo_pago (Cmp_Nombre_Metodo) VALUES
('EFECTIVO'),
('CHEQUE'),
('TRANSFERENCIA'),
('TARJETA');

-- ===========================
-- 6) RECIBO (ENCABEZADO)
-- ===========================
CREATE TABLE tbl_recibo (
    Cmp_Id_Recibo     INT AUTO_INCREMENT PRIMARY KEY,
    Cmp_Fecha_Recibo  DATE NOT NULL,
    Cmp_Id_Cliente    INT NOT NULL,
    Cmp_Total_Recibo  DECIMAL(12,2) NOT NULL,
    Cmp_Observaciones VARCHAR(300),
    Cmp_Id_Usuario    INT NOT NULL,

    CONSTRAINT fk_rec_cliente
      FOREIGN KEY (Cmp_Id_Cliente) REFERENCES tbl_cliente(Id_Cliente)
);

-- ===========================
-- 7) DETALLE DE RECIBO (MÉTODOS DE PAGO)
-- ===========================
CREATE TABLE tbl_recibo_det (
    Id_Detalle        INT AUTO_INCREMENT PRIMARY KEY,
    Cmp_Id_Recibo     INT NOT NULL,
    Cmp_Id_Metodo_Pago INT NOT NULL,
    Cmp_Monto_Pago    DECIMAL(12,2) NOT NULL,

    CONSTRAINT fk_recdet_rec
      FOREIGN KEY (Cmp_Id_Recibo) REFERENCES tbl_recibo(Cmp_Id_Recibo),
    CONSTRAINT fk_recdet_met
      FOREIGN KEY (Cmp_Id_Metodo_Pago) REFERENCES tbl_metodo_pago(Id_Metodo_Pago)
);

-- ===========================
-- 8) APLICACIONES DE RECIBO A DOCUMENTOS
-- ===========================
CREATE TABLE tbl_recibo_aplicacion (
    Id_Aplicacion      INT AUTO_INCREMENT PRIMARY KEY,
    Cmp_Id_Recibo      INT NOT NULL,
    Cmp_Id_CxC_Documento INT NOT NULL,
    Cmp_Monto_Aplicado DECIMAL(12,2) NOT NULL,

    CONSTRAINT fk_recapp_rec
      FOREIGN KEY (Cmp_Id_Recibo) REFERENCES tbl_recibo(Cmp_Id_Recibo),
    CONSTRAINT fk_recapp_doc
      FOREIGN KEY (Cmp_Id_CxC_Documento) REFERENCES tbl_documento_cxc(Id_Documento)
);

-- ===========================
-- 9) CAJA – INGRESOS POR RECIBOS
-- ===========================
CREATE TABLE tbl_caja_ingreso (
    Id_Caja_Ingreso   INT AUTO_INCREMENT PRIMARY KEY,
    Cmp_Id_Recibo     INT NOT NULL,
    Cmp_Fecha_Ingreso DATE NOT NULL,
    Cmp_Monto_Ingreso DECIMAL(12,2) NOT NULL,

    CONSTRAINT fk_caja_rec
      FOREIGN KEY (Cmp_Id_Recibo) REFERENCES tbl_recibo(Cmp_Id_Recibo)
);

SET FOREIGN_KEY_CHECKS = 1;

-- ===========================================
--   DATOS DE PRUEBA
-- ===========================================

-- CLIENTES
INSERT INTO tbl_cliente (Cmp_Nombre_Cliente, Cmp_Direccion, Cmp_Telefono, Cmp_Nit) VALUES
('Anacleto Barajas Rojas', '34 Ave 15-45 Zona 5', '2517689', '1234567-8'),
('Hilario Moreno Colocho', '21 Calle 22-78 Zona 1', '2535624', '9876543-2');

-- DOCUMENTOS POR COBRAR (FACTURAS AL CRÉDITO)
INSERT INTO tbl_documento_cxc
(Id_Cliente, Id_Tipo_Documento, Cmp_Numero, Cmp_Fecha, Cmp_Total_Documento, Cmp_Saldo_Actual, Cmp_Es_Credito, Cmp_Fecha_Venc)
VALUES
-- Cliente 1: Anacleto
(1, 1, '8540', '2024-03-01', 9895.00, 9895.00, 1, '2024-03-31'),
(1, 1, '0047', '2024-03-22', 3540.00, 3540.00, 1, '2024-04-15'),
-- Cliente 2: Hilario
(2, 1, '8548', '2024-03-01', 8540.00, 8540.00, 1, '2024-03-31'),
(2, 1, '0048', '2024-03-22', 2911.00, 2911.00, 1, '2024-04-15');

-- Guardar los Id_Documento para usar en aplicaciones
-- (En la práctica tu código C# los obtiene con SELECT; aquí asumimos IDs 1..4)

-- ===========================
-- RECIBO 1 – ANACLETO (Q 5,000)
-- ===========================
INSERT INTO tbl_recibo
(Cmp_Fecha_Recibo, Cmp_Id_Cliente, Cmp_Total_Recibo, Cmp_Observaciones, Cmp_Id_Usuario)
VALUES
('2024-03-16', 1, 5000.00, 'Abono parcial factura 8540', 1);

SET @idrec1 = LAST_INSERT_ID();

INSERT INTO tbl_recibo_det
(Cmp_Id_Recibo, Cmp_Id_Metodo_Pago, Cmp_Monto_Pago)
VALUES
(@idrec1, 2, 5000.00);   -- CHEQUE

INSERT INTO tbl_recibo_aplicacion
(Cmp_Id_Recibo, Cmp_Id_CxC_Documento, Cmp_Monto_Aplicado)
VALUES
(@idrec1, 1, 5000.00);   -- Factura 8540

UPDATE tbl_documento_cxc
SET Cmp_Saldo_Actual = Cmp_Saldo_Actual - 5000.00
WHERE Id_Documento = 1;

INSERT INTO tbl_caja_ingreso
(Cmp_Id_Recibo, Cmp_Fecha_Ingreso, Cmp_Monto_Ingreso)
VALUES
(@idrec1, '2024-03-16', 5000.00);

-- ===========================
-- RECIBO 2 – HILARIO (Q 4,581.60)
-- ===========================
INSERT INTO tbl_recibo
(Cmp_Fecha_Recibo, Cmp_Id_Cliente, Cmp_Total_Recibo, Cmp_Observaciones, Cmp_Id_Usuario)
VALUES
('2024-03-28', 2, 4581.60, 'Abono parcial factura 8548', 1);

SET @idrec2 = LAST_INSERT_ID();

INSERT INTO tbl_recibo_det
(Cmp_Id_Recibo, Cmp_Id_Metodo_Pago, Cmp_Monto_Pago)
VALUES
(@idrec2, 1, 4581.60);   -- EFECTIVO

INSERT INTO tbl_recibo_aplicacion
(Cmp_Id_Recibo, Cmp_Id_CxC_Documento, Cmp_Monto_Aplicado)
VALUES
(@idrec2, 3, 4581.60);   -- Factura 8548

UPDATE tbl_documento_cxc
SET Cmp_Saldo_Actual = Cmp_Saldo_Actual - 4581.60
WHERE Id_Documento = 3;

INSERT INTO tbl_caja_ingreso
(Cmp_Id_Recibo, Cmp_Fecha_Ingreso, Cmp_Monto_Ingreso)
VALUES
(@idrec2, '2024-03-28', 4581.60);

-- ===========================================
-- FIN DEL SCRIPT BD_CXC
-- ===========================================
