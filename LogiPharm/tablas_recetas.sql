-- Tabla de cabecera de Recetas Médicas
CREATE TABLE IF NOT EXISTS `recetas` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `numero_receta` varchar(50) DEFAULT NULL,
  `id_cliente` int(11) DEFAULT NULL,
  `paciente_nombre` varchar(255) NOT NULL,
  `medico_nombre` varchar(255) NOT NULL,
  `medico_registro` varchar(100) DEFAULT NULL,
  `medico_especialidad` varchar(150) DEFAULT NULL,
  `fecha_emision` date NOT NULL,
  `fecha_vencimiento` date DEFAULT NULL,
  `estado` varchar(50) NOT NULL DEFAULT 'Ingresada', -- Estados: Ingresada, Surtida parcial, Surtida total, Vencida
  `observaciones` text,
  `activo` tinyint(1) NOT NULL DEFAULT 1,
  `creado_en` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  KEY `idx_recetas_numero` (`numero_receta`),
  KEY `idx_recetas_paciente` (`paciente_nombre`),
  KEY `idx_recetas_medico` (`medico_nombre`),
  KEY `idx_recetas_fecha_emision` (`fecha_emision`),
  KEY `idx_recetas_estado` (`estado`),
  KEY `idx_recetas_activo` (`activo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Tabla de detalle (medicamentos en la receta)
CREATE TABLE IF NOT EXISTS `receta_detalles` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_receta` int(11) NOT NULL,
  `id_producto` int(11) DEFAULT NULL,
  `producto_nombre` varchar(255) NOT NULL,
  `cantidad` decimal(10,2) NOT NULL,
  `indicaciones` text,
  PRIMARY KEY (`id`),
  KEY `fk_receta_detalle_idx` (`id_receta`),
  KEY `idx_receta_detalles_producto` (`id_producto`),
  KEY `idx_receta_detalles_producto_nombre` (`producto_nombre`),
  CONSTRAINT `fk_receta_detalle` FOREIGN KEY (`id_receta`) REFERENCES `recetas` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;