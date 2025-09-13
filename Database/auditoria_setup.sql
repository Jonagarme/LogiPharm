-- LogiPharm - Auditoría (Bitácora)
-- Motor: MySQL 5.7+/8.0+, Charset UTF8MB4

-- 1) Tabla principal: auditoria
CREATE TABLE IF NOT EXISTS auditoria (
  id           BIGINT UNSIGNED NOT NULL AUTO_INCREMENT,
  fecha        DATETIME        NOT NULL DEFAULT CURRENT_TIMESTAMP,
  idUsuario    INT             NOT NULL,
  usuario      VARCHAR(100)    NOT NULL,
  modulo       VARCHAR(100)    NOT NULL,          -- Ej: "Cotizaciones", "Login", "Productos"
  accion       VARCHAR(30)     NOT NULL,          -- Ej: LOGIN, LOGOUT, CREAR, EDITAR, ANULAR, IMPRIMIR, VISUALIZAR
  entidad      VARCHAR(100)    NULL,              -- Ej: "cotizaciones", "usuarios"
  idEntidad    BIGINT          NULL,              -- Id relacionado (si aplica)
  descripcion  TEXT            NULL,              -- Detalle legible del evento
  ip           VARCHAR(45)     NULL,              -- IPv4/IPv6
  host         VARCHAR(100)    NULL,              -- Nombre de equipo
  origen       VARCHAR(50)     NULL,              -- Ej: "UI", "API", "JOB"
  extra        TEXT            NULL,              -- JSON o texto adicional
  PRIMARY KEY (id),
  KEY idx_auditoria_fecha (fecha),
  KEY idx_auditoria_usuario_fecha (idUsuario, fecha),
  KEY idx_auditoria_modulo_accion_fecha (modulo, accion, fecha),
  KEY idx_auditoria_entidad (entidad, idEntidad)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;


-- 2) Procedimiento para registrar eventos
DELIMITER //
CREATE PROCEDURE sp_registrar_auditoria (
  IN pIdUsuario   INT,
  IN pUsuario     VARCHAR(100),
  IN pModulo      VARCHAR(100),
  IN pAccion      VARCHAR(30),
  IN pEntidad     VARCHAR(100),
  IN pIdEntidad   BIGINT,
  IN pDescripcion TEXT,
  IN pIp          VARCHAR(45),
  IN pHost        VARCHAR(100),
  IN pOrigen      VARCHAR(50),
  IN pExtra       TEXT
)
BEGIN
  INSERT INTO auditoria
    (fecha, idUsuario, usuario, modulo, accion, entidad, idEntidad, descripcion, ip, host, origen, extra)
  VALUES
    (NOW(), pIdUsuario, pUsuario, pModulo, UPPER(pAccion), pEntidad, pIdEntidad, pDescripcion, pIp, pHost, pOrigen, pExtra);
END//
DELIMITER ;


-- 3) Procedimiento para consultar auditoría con filtros
--    Nota: Si pUsuario = 'TODOS' o vacío, no filtra por usuario.
--          Si pAccion  = 'TODAS' o vacío, no filtra por acción.
DELIMITER //
DROP PROCEDURE IF EXISTS sp_consultar_auditoria;//
CREATE PROCEDURE sp_consultar_auditoria (
  IN pFechaDesde DATETIME,
  IN pFechaHasta DATETIME,
  IN pUsuario    VARCHAR(100),
  IN pAccion     VARCHAR(30)
)
BEGIN
  SELECT 
    a.fecha      AS `Fecha`,
    a.usuario    AS `Usuario`,
    a.modulo     AS `Modulo`,
    a.accion     AS `Accion`,
    a.descripcion AS `Detalle`,
    a.entidad,
    a.idEntidad,
    a.ip,
    a.host,
    a.origen
  FROM auditoria a
  WHERE a.fecha >= pFechaDesde
    AND a.fecha <  DATE_ADD(DATE(pFechaHasta), INTERVAL 1 DAY)
    AND (
      COALESCE(pUsuario, '') = ''
      OR UPPER(pUsuario COLLATE utf8mb4_unicode_ci) = 'TODOS' COLLATE utf8mb4_unicode_ci
      OR a.usuario COLLATE utf8mb4_unicode_ci = pUsuario COLLATE utf8mb4_unicode_ci
    )
    AND (
      COALESCE(pAccion, '') = ''
      OR UPPER(pAccion COLLATE utf8mb4_unicode_ci) = 'TODAS' COLLATE utf8mb4_unicode_ci
      OR a.accion COLLATE utf8mb4_unicode_ci = UPPER(pAccion) COLLATE utf8mb4_unicode_ci
    )
  ORDER BY a.fecha DESC;
END//
DELIMITER ;


-- 4) Procedimiento para listar usuarios disponibles en auditoría (para combos de filtro)
DELIMITER //
DROP PROCEDURE IF EXISTS sp_listar_usuarios_auditoria;//
CREATE PROCEDURE sp_listar_usuarios_auditoria ()
BEGIN
  SELECT DISTINCT a.idUsuario AS `id`, a.usuario AS `nombreUsuario`
  FROM auditoria a
  ORDER BY a.usuario;
END//
DELIMITER ;


-- 5) Ejemplos de uso
-- Registrar inicio de sesión
-- CALL sp_registrar_auditoria(1, 'admin', 'Login', 'LOGIN', NULL, NULL, 'Inicio de sesión exitoso', '192.168.1.10', 'PC-01', 'UI', NULL);

-- Registrar acción en Cotizaciones
-- CALL sp_registrar_auditoria(1, 'admin', 'Cotizaciones', 'ANULAR', 'cotizaciones', 123, 'Cotización 000123 anulada', NULL, NULL, 'UI', NULL);

-- Consultar auditoría (todo el día de hoy, todos los usuarios, todas las acciones)
-- CALL sp_consultar_auditoria(CURDATE(), CURDATE(), 'TODOS', 'TODAS');
