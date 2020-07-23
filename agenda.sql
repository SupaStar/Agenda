-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 24-10-2019 a las 09:17:15
-- Versión del servidor: 10.3.16-MariaDB
-- Versión de PHP: 7.3.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `agenda`
--
CREATE DATABASE IF NOT EXISTS `agenda` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `agenda`;

DELIMITER $$
--
-- Procedimientos
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `agregarRecordatorio` (IN `idE` INT, IN `fechaR` DATE, IN `horaR` TIME)  BEGIN
INSERT into recordatorio VALUES(null,idE,0,fechaR,horaR);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `cambiarEvento` (IN `id` INT, IN `nomb` VARCHAR(100), IN `fechai` DATE)  BEGIN
UPDATE evento set nombre=nomb,fechaInicio=fechai where idE=id;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `cambiarRecortadorio` (IN `id` INT, IN `fecha` DATE, IN `hora` TIME)  BEGIN
UPDATE recordatorio set fechaR=fecha,horaR=hora where idR=id;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `desactivarR` (IN `idre` INT)  BEGIN
UPDATE recordatorio set estado=0 WHERE idR=idre;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `eliminarEvento` (IN `id` INT)  BEGIN
DELETE FROM recordatorio WHERE idE=id;
DELETE FROM evento WHERE idE=id;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `eliminarRecordatorio` (IN `idr` INT)  BEGIN
DELETE FROM recordatorio WHERE idR=idr;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `eventoRecordatorio` (IN `id` INT)  BEGIN
    SELECT
        evento.`nombre`,
        evento.estado,
        evento.fechaInicio
    FROM
        evento
    INNER JOIN recordatorio ON evento.idE = recordatorio.idE
    WHERE
        recordatorio.idR = id ;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `insertarEvento` (IN `nom` VARCHAR(100), IN `fechaI` DATE)  BEGIN
 INSERT INTO evento VALUES(null,nom,fechaI);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `insertarEventoRespaldo` (IN `idE` INT, IN `nombre` VARCHAR(100), IN `fechaI` DATE)  BEGIN
SET FOREIGN_KEY_CHECKS=0;
INSERT INTO evento VALUES(idE,nombre,fechaI);
SET FOREIGN_KEY_CHECKS=1;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `insertarParent` (IN `par` VARCHAR(100))  BEGIN
INSERT INTO parent VALUES(par);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `recordatoriosEvento` (IN `id` INT)  BEGIN
    SELECT
    recordatorio.`fechaRecordatorio`,recordatorio.`horaRecordatorio`
FROM
    recordatorio
INNER JOIN evento ON recordatorio.idE = evento.idE
WHERE
    evento.idE = id;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `registroRecordatorioRespaldo` (IN `idR` INT, IN `ide` INT, IN `fechar` DATE, IN `horar` TIME, IN `estado` INT)  BEGIN
SET FOREIGN_KEY_CHECKS=0;
INSERT INTO recordatorio VALUES(idR,ide,estado,fechar,horar);
SET FOREIGN_KEY_CHECKS=1;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `reiniciar` ()  BEGIN
SET FOREIGN_KEY_CHECKS=0;
    TRUNCATE TABLE evento;
    TRUNCATE TABLE recordatorio;
    SET FOREIGN_KEY_CHECKS=1;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `verEvento` (IN `fecha` DATE)  BEGIN
SELECT evento.idE,evento.nombre from evento INNER JOIN recordatorio on evento.idE=recordatorio.idE WHERE recordatorio.fechaRecordatorio=fecha;
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `evento`
--

CREATE TABLE `evento` (
  `idE` int(11) NOT NULL,
  `nombre` varchar(100) NOT NULL,
  `fechaInicio` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `evento`
--

INSERT INTO `evento` (`idE`, `nombre`, `fechaInicio`) VALUES
(1, 'Evento', '2019-10-31'),
(2, 'Pepito', '2020-01-31'),
(3, 'Pepote', '2020-01-31'),
(4, 'jejjaja', '2020-01-31'),
(5, 'Jojoxdxd', '2020-04-30'),
(6, 'jejkasdjksad', '2020-04-30');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `parent`
--

CREATE TABLE `parent` (
  `idparent` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `parent`
--

INSERT INTO `parent` (`idparent`) VALUES
('1-WWz9yE26ylhp4Dr4vpgbul9yH9enQe-'),
('11OXcjh96W__AGNSvzhJNrZtp_1enSBxK'),
('1veg_F-xtyEGSVO92CkUvdaU9caApYGCz'),
('1veg_F-xtyEGSVO92CkUvdaU9caApYGCz'),
('1veg_F-xtyEGSVO92CkUvdaU9caApYGCz'),
('1veg_F-xtyEGSVO92CkUvdaU9caApYGCz'),
('1veg_F-xtyEGSVO92CkUvdaU9caApYGCz'),
('1veg_F-xtyEGSVO92CkUvdaU9caApYGCz'),
('1veg_F-xtyEGSVO92CkUvdaU9caApYGCz'),
('1veg_F-xtyEGSVO92CkUvdaU9caApYGCz'),
('1veg_F-xtyEGSVO92CkUvdaU9caApYGCz'),
('1veg_F-xtyEGSVO92CkUvdaU9caApYGCz'),
('1veg_F-xtyEGSVO92CkUvdaU9caApYGCz'),
('1veg_F-xtyEGSVO92CkUvdaU9caApYGCz'),
('1dXeAITQbRFqUyWCE5f29ibvnVwwhMJyJ');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `recordatorio`
--

CREATE TABLE `recordatorio` (
  `idR` int(11) NOT NULL,
  `idE` int(11) NOT NULL,
  `estado` int(11) NOT NULL,
  `fechaRecordatorio` date NOT NULL,
  `horaRecordatorio` time NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `recordatorio`
--

INSERT INTO `recordatorio` (`idR`, `idE`, `estado`, `fechaRecordatorio`, `horaRecordatorio`) VALUES
(1, 1, 1, '0000-00-00', '09:00:00'),
(2, 1, 1, '0000-00-00', '19:38:00'),
(3, 2, 0, '0000-00-00', '09:00:00'),
(4, 3, 1, '0000-00-00', '09:00:00'),
(5, 3, 1, '2020-01-24', '01:56:00'),
(6, 4, 1, '0000-00-00', '09:00:00'),
(7, 6, 1, '0000-00-00', '09:00:00'),
(8, 6, 1, '0000-00-00', '02:07:00');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `evento`
--
ALTER TABLE `evento`
  ADD PRIMARY KEY (`idE`);

--
-- Indices de la tabla `recordatorio`
--
ALTER TABLE `recordatorio`
  ADD PRIMARY KEY (`idR`),
  ADD KEY `idE` (`idE`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `evento`
--
ALTER TABLE `evento`
  MODIFY `idE` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT de la tabla `recordatorio`
--
ALTER TABLE `recordatorio`
  MODIFY `idR` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `recordatorio`
--
ALTER TABLE `recordatorio`
  ADD CONSTRAINT `recordatorio_ibfk_1` FOREIGN KEY (`idE`) REFERENCES `evento` (`idE`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
