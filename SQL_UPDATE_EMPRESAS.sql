-- =============================================
-- Script SQL para Actualizar Tabla empresas
-- =============================================
-- Ejecuta este script en tu base de datos MySQL/MariaDB
-- antes de usar las nuevas funcionalidades

USE logipharm_db;

-- Agregar nuevas columnas si no existen
ALTER TABLE empresas 
ADD COLUMN IF NOT EXISTS numero_resolucion VARCHAR(100) NULL COMMENT 'Número de resolución si es contribuyente especial',
ADD COLUMN IF NOT EXISTS ambiente_sri VARCHAR(20) DEFAULT 'Pruebas' COMMENT 'Ambiente SRI: Pruebas o Producción',
ADD COLUMN IF NOT EXISTS certificado_path VARCHAR(500) NULL COMMENT 'Ruta del archivo .p12',
ADD COLUMN IF NOT EXISTS certificado_password VARCHAR(500) NULL COMMENT 'Contraseña encriptada del certificado',
ADD COLUMN IF NOT EXISTS certificado_fecha_expiracion DATE NULL COMMENT 'Fecha de expiración del certificado';

-- Verificar que las columnas se crearon correctamente
DESCRIBE empresas;

-- Si necesitas modificar alguna columna existente (opcional):
-- ALTER TABLE empresas MODIFY COLUMN contribuyente_especial VARCHAR(100) NULL;

SELECT 'Script ejecutado exitosamente. Columnas agregadas a la tabla empresas.' AS mensaje;
