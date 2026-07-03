CREATE TABLE IF NOT EXISTS `principios_activos` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(150) NOT NULL,
  `descripcion` text DEFAULT NULL,
  `activo` tinyint(1) DEFAULT '1',
  `anulado` tinyint(1) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS `presentaciones` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) NOT NULL,
  `descripcion` text DEFAULT NULL,
  `activo` tinyint(1) DEFAULT '1',
  `anulado` tinyint(1) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Agregar campos a la tabla productos
ALTER TABLE `productos` 
ADD COLUMN IF NOT EXISTS `idPrincipioActivo` int DEFAULT NULL,
ADD COLUMN IF NOT EXISTS `idPresentacion` int DEFAULT NULL;
