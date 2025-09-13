-- Tabla laboratorios
CREATE TABLE IF NOT EXISTS laboratorios (
  id INT AUTO_INCREMENT PRIMARY KEY,
  codigo VARCHAR(20) NOT NULL,
  nombre VARCHAR(150) NOT NULL,
  contacto VARCHAR(100) NULL,
  telefono VARCHAR(50) NULL,
  email VARCHAR(120) NULL,
  direccion VARCHAR(255) NULL,
  activo TINYINT(1) NOT NULL DEFAULT 1,
  UNIQUE KEY uk_laboratorios_codigo (codigo),
  KEY idx_laboratorios_nombre (nombre)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

INSERT INTO laboratorios (codigo, nombre, contacto, telefono, email, direccion, activo)
VALUES ('LABGEN', 'Laboratorio Genérico', 'Contacto Demo', '0999999999', 'demo@lab.com', 'Calle Falsa 123', 1);
