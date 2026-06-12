-- Tabla para los procesos o tipos de análisis de cada laboratorio
CREATE TABLE `lab_procesos` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `laboratorio_id` int(11) NOT NULL,
  `nombre` varchar(255) NOT NULL,
  `metodo` varchar(255) DEFAULT NULL,
  `activo` tinyint(1) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`),
  KEY `fk_proceso_laboratorio_idx` (`laboratorio_id`),
  CONSTRAINT `fk_proceso_laboratorio` FOREIGN KEY (`laboratorio_id`) REFERENCES `laboratorios` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB;

-- Tabla para los parámetros o plantilla de cada proceso
CREATE TABLE `lab_parametros` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `proceso_id` int(11) NOT NULL,
  `nombre` varchar(255) NOT NULL,
  `unidad` varchar(50) DEFAULT NULL,
  `ref_min` varchar(50) DEFAULT NULL,
  `ref_max` varchar(50) DEFAULT NULL,
  `orden` int(11) NOT NULL DEFAULT '0',
  `notas` text,
  `activo` tinyint(1) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`),
  KEY `fk_parametro_proceso_idx` (`proceso_id`),
  CONSTRAINT `fk_parametro_proceso` FOREIGN KEY (`proceso_id`) REFERENCES `lab_procesos` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB;

-- Tabla para la cabecera de un resultado emitido
CREATE TABLE `lab_resultados` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `proceso_id` int(11) NOT NULL,
  `fecha_emision` datetime NOT NULL,
  `paciente_nombre` varchar(255) NOT NULL,
  `paciente_id` varchar(100) DEFAULT NULL,
  `medico_solicitante` varchar(255) DEFAULT NULL,
  `observaciones` text,
  PRIMARY KEY (`id`),
  KEY `fk_resultado_proceso_idx` (`proceso_id`),
  CONSTRAINT `fk_resultado_proceso` FOREIGN KEY (`proceso_id`) REFERENCES `lab_procesos` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB;

-- Tabla para el detalle de un resultado emitido
CREATE TABLE `lab_resultado_detalles` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `resultado_id` int(11) NOT NULL,
  `parametro_nombre` varchar(255) NOT NULL,
  `valor` varchar(255) NOT NULL,
  `unidad` varchar(50) DEFAULT NULL,
  `rango_referencia` varchar(100) DEFAULT NULL,
  `fuera_de_rango` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `fk_detalle_resultado_idx` (`resultado_id`),
  CONSTRAINT `fk_detalle_resultado` FOREIGN KEY (`resultado_id`) REFERENCES `lab_resultados` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB;
