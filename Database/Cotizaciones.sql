-- SQL DDL para módulo de Cotizaciones
-- Motor: MySQL 5.7/8.0

-- 1) Secuencia genérica para cotizaciones
CREATE TABLE IF NOT EXISTS secuencias (
  nombre VARCHAR(50) PRIMARY KEY,
  valor INT NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

INSERT INTO secuencias (nombre, valor)
SELECT 'COTIZACION', 0
WHERE NOT EXISTS (SELECT 1 FROM secuencias WHERE nombre = 'COTIZACION');

-- 2) Encabezado de cotización
CREATE TABLE IF NOT EXISTS cotizaciones (
  id BIGINT AUTO_INCREMENT PRIMARY KEY,
  numero INT NOT NULL UNIQUE,
  fecha DATE NOT NULL,
  validezDias INT NOT NULL DEFAULT 15,
  idCliente INT NOT NULL,
  observaciones VARCHAR(500) NULL,
  subtotal DECIMAL(18,2) NOT NULL DEFAULT 0,
  descuento DECIMAL(18,2) NOT NULL DEFAULT 0,
  iva DECIMAL(18,2) NOT NULL DEFAULT 0,
  total DECIMAL(18,2) NOT NULL DEFAULT 0,
  estado VARCHAR(20) NOT NULL DEFAULT 'VIGENTE',
  creadoPor INT NOT NULL,
  creadoDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  anulado TINYINT(1) NOT NULL DEFAULT 0,
  anuladoPor INT NULL,
  anuladoDate DATETIME NULL,
  CONSTRAINT fk_cotizaciones_cliente FOREIGN KEY (idCliente) REFERENCES clientes(id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- 3) Detalle de cotización
CREATE TABLE IF NOT EXISTS cotizaciones_detalle (
  id BIGINT AUTO_INCREMENT PRIMARY KEY,
  idCotizacion BIGINT NOT NULL,
  idProducto INT NOT NULL,
  codigo VARCHAR(50) NULL,
  productoNombre VARCHAR(300) NOT NULL,
  cantidad DECIMAL(18,4) NOT NULL DEFAULT 0,
  precioUnitario DECIMAL(18,6) NOT NULL DEFAULT 0,
  precioFinal DECIMAL(18,6) NOT NULL DEFAULT 0,
  descuentoPorc DECIMAL(9,4) NOT NULL DEFAULT 0,
  descuentoValor DECIMAL(18,6) NOT NULL DEFAULT 0,
  ivaValor DECIMAL(18,6) NOT NULL DEFAULT 0,
  subtotal DECIMAL(18,6) NOT NULL DEFAULT 0,
  total DECIMAL(18,6) NOT NULL DEFAULT 0,
  CONSTRAINT fk_cotizaciones_det_enc FOREIGN KEY (idCotizacion) REFERENCES cotizaciones(id) ON DELETE CASCADE,
  CONSTRAINT fk_cotizaciones_det_prod FOREIGN KEY (idProducto) REFERENCES productos(id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
