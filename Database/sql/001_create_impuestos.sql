-- MySQL script: crear tabla `impuestos` e insertar IVA 15%
-- Ejecuta este archivo en tu base de datos LogiPharm

CREATE TABLE IF NOT EXISTS `impuestos` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `codigo` VARCHAR(20) NOT NULL,
  `nombre` VARCHAR(100) NOT NULL,
  `porcentaje` DECIMAL(6,4) NOT NULL,   -- 0.1500 = 15%
  `vigenteDesde` DATE NULL,
  `vigenteHasta` DATE NULL,
  `activo` TINYINT(1) NOT NULL DEFAULT 1,
  `descripcion` VARCHAR(255) NULL,
  PRIMARY KEY (`id`),
  KEY `idx_codigo_vigencia` (`codigo`, `activo`, `vigenteDesde`, `vigenteHasta`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Registro inicial: IVA 15%
INSERT INTO `impuestos` (`codigo`, `nombre`, `porcentaje`, `vigenteDesde`, `vigenteHasta`, `activo`, `descripcion`)
VALUES ('IVA', 'Impuesto al Valor Agregado', 0.1500, NULL, NULL, 1, 'Tasa general vigente');
