-- Transferencias internas (inventario)
-- Ejecutar en la misma base de datos usada por LogiPharm.

-- 1) (Opcional) Agregar totales al encabezado de transferencia
-- Si tu tabla ya tiene estas columnas, omite este ALTER.
ALTER TABLE inventario_transferenciastock
  ADD COLUMN total_productos INT NOT NULL DEFAULT 0,
  ADD COLUMN total_unidades DECIMAL(18,2) NOT NULL DEFAULT 0;

-- 2) Tabla de detalle (productos/lotes por transferencia)
CREATE TABLE IF NOT EXISTS inventario_transferenciastockdetalle (
  id BIGINT NOT NULL AUTO_INCREMENT,
  transferencia_id BIGINT NOT NULL,
  producto_id BIGINT NOT NULL,
  lote_origen_id INT NOT NULL,
  numero_lote VARCHAR(80) NOT NULL,
  fecha_caducidad DATE NULL,
  cantidad_solicitada DECIMAL(18,2) NOT NULL,
  cantidad_recibida DECIMAL(18,2) NOT NULL DEFAULT 0,
  estado VARCHAR(30) NOT NULL DEFAULT 'PENDIENTE',
  creadoDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (id),
  INDEX ix_transferencia (transferencia_id),
  INDEX ix_producto (producto_id),
  CONSTRAINT fk_trf_det_header FOREIGN KEY (transferencia_id) REFERENCES inventario_transferenciastock(id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
