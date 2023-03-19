CREATE DATABASE  IF NOT EXISTS `standauto` /*!40100 DEFAULT CHARACTER SET utf8 */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `standauto`;
-- MySQL dump 10.13  Distrib 8.0.28, for Win64 (x86_64)
--
-- Host: localhost    Database: standauto
-- ------------------------------------------------------
-- Server version	8.0.28

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `compras`
--

DROP TABLE IF EXISTS `compras`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `compras` (
  `idCompras` int NOT NULL AUTO_INCREMENT,
  `marca` varchar(45) DEFAULT NULL,
  `modelo` varchar(45) DEFAULT NULL,
  `ano` int DEFAULT NULL,
  `cor` varchar(45) DEFAULT NULL,
  `fonte_energia` varchar(45) DEFAULT NULL,
  `matricula` varchar(45) DEFAULT NULL,
  `quilometros` int DEFAULT NULL,
  `preco` decimal(9,2) DEFAULT NULL,
  PRIMARY KEY (`idCompras`),
  UNIQUE KEY `matricula_UNIQUE` (`matricula`)
) ENGINE=InnoDB AUTO_INCREMENT=30 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `compras`
--

LOCK TABLES `compras` WRITE;
/*!40000 ALTER TABLE `compras` DISABLE KEYS */;
INSERT INTO `compras` VALUES (1,'Opel','Corsa 1.2',1998,'Vermelha','Gasolina','PG-33-44',189654,520.00),(3,'Citroen','C5 AIR CROSS',2019,'Branca','Gasóleo','87-ZE-78',57654,19650.00),(4,'Telsla','Y',2020,'Azul','Eléctrica','74-GB-17',36987,26950.00),(5,'Audi','A5',2010,'Cinza','Gasóleo','54-SA-45',90123,18560.00),(10,'Ferrari','F8 Spide',2019,'Amarela','Gasolina','12-EG-34',23987,25550.00),(11,'BMW','Z3',2003,'Branca','Gasolina','68-XS-29',101233,12550.00),(12,'Alfa Romeo','Giulia',2019,'Branca','Gasolina','98-KL.89',89321,15550.00),(14,'Porsche','Panamera',2009,'Preta','Gasolina','59-HD-64',85456,36550.00),(15,'Renault','Scenic',1996,'Cinza','Gasoléo','MB-89-91',145897,399.00),(16,'Renault','MEGANE E-TECH',2023,'Cinza','Eléctrico','41-PL-64',5546,29990.00),(17,'Tesla','Model 3',2021,'Branca','Eléctrico','AO-31-VN',49650,31600.00),(18,'Renault','Zoe',2019,'Preta','Eléctrica','AD-41-NB',14000,19990.00),(19,'Mercedes','CLK 220',2007,'Preta','Diesel','36-DA-02',239000,13200.00),(20,'Mini','1000',1984,'Branca','Gasolina','EJ-49-50',52000,5220.00),(22,'BMW','M6 Coupé',2013,'Preta','Gasolina','12-NI-78',141900,74100.00),(23,'Fiat','500',2008,'Amarela','Gasolina','54_LA-89',154000,5100.00),(24,'Mercedes','GLA 200',2016,'Cizento','Diesel','55-LL-44',150000,24500.00),(25,'BMW','X6',2012,'Preta','Diesel','99-NB-79',99700,35100.00),(26,'Peugeot','208',2018,'Azul','Diesel','11-QW-33',104123,14200.00),(27,'Audi','A3',2015,'Cinzento','Gasolina','43-SD-35',158000,14900.00),(29,'Hyundai','Accent',2001,'Cinza','Gasolina','PE-94-79',145000,950.00);
/*!40000 ALTER TABLE `compras` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `contabilidade`
--

DROP TABLE IF EXISTS `contabilidade`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `contabilidade` (
  `idc` int NOT NULL AUTO_INCREMENT,
  `Marca` varchar(45) DEFAULT NULL,
  `modelo` varchar(45) DEFAULT NULL,
  `ano` int DEFAULT NULL,
  `cor` varchar(45) DEFAULT NULL,
  `fonte_energia` varchar(45) DEFAULT NULL,
  `matricula` varchar(45) DEFAULT NULL,
  `quilometros` int DEFAULT NULL,
  `preco_compra` decimal(9,2) DEFAULT NULL,
  `preco_venda` decimal(9,2) DEFAULT NULL,
  `lucro_carro` decimal(9,2) DEFAULT NULL,
  `data_compra` date DEFAULT NULL,
  `data_venda` date DEFAULT NULL,
  `tempo_stand` double DEFAULT NULL,
  PRIMARY KEY (`idc`),
  UNIQUE KEY `matricula_UNIQUE` (`matricula`),
  KEY `fk1_idx` (`matricula`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `contabilidade`
--

LOCK TABLES `contabilidade` WRITE;
/*!40000 ALTER TABLE `contabilidade` DISABLE KEYS */;
INSERT INTO `contabilidade` VALUES (5,'Opel','Corsa',1998,'vermelha','Gasolina','87-ZE-78',165231,255.00,850.00,595.00,'2023-03-09','2023-03-09',0),(6,'Seat','Leon',2001,'Preta','Gasóleo','74-KL-47',56321,4500.00,11500.00,7000.00,'2023-03-07','2023-03-11',4),(10,'Ford','Focus',2000,NULL,'Gasolina','XP-32-12',0,530.00,1030.00,500.00,'2023-03-16','2023-03-16',0),(14,'Hyundai','Accent',2003,NULL,NULL,'PG-66-77',0,750.00,1350.00,600.00,'2023-03-17','2023-03-19',2),(15,'Hyundai','Accent',2001,NULL,NULL,'PG-66-45',0,450.00,1350.00,900.00,'2023-03-17','2023-03-19',2);
/*!40000 ALTER TABLE `contabilidade` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stand`
--

DROP TABLE IF EXISTS `stand`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `stand` (
  `idCarros` int NOT NULL AUTO_INCREMENT,
  `marca` varchar(45) DEFAULT NULL,
  `modelo` varchar(45) DEFAULT NULL,
  `ano` int DEFAULT NULL,
  `cor` varchar(45) DEFAULT NULL,
  `fonte_energia` varchar(45) DEFAULT NULL,
  `matricula` varchar(45) DEFAULT NULL,
  `preco_compra` decimal(9,2) DEFAULT NULL,
  `data_compra` datetime DEFAULT NULL,
  `quilometros` int DEFAULT NULL,
  `preco_venda` decimal(9,2) DEFAULT NULL,
  PRIMARY KEY (`idCarros`),
  UNIQUE KEY `matricula_UNIQUE` (`matricula`)
) ENGINE=InnoDB AUTO_INCREMENT=49 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stand`
--

LOCK TABLES `stand` WRITE;
/*!40000 ALTER TABLE `stand` DISABLE KEYS */;
INSERT INTO `stand` VALUES (25,'Telsla','Y',2021,'Preta','Eléctrica','44-ZW-11',29500.00,'2023-01-10 01:35:22',36987,27950.00),(26,'Seat','Leon',2001,'Preta','Gasóleo','74-KL-47',4500.00,'2023-03-07 00:00:00',56321,11500.00),(28,'Audi','TT',2010,'Cinza','Gasóleo','44-BB-44',9990.00,'2023-03-09 00:00:00',101123,19500.00),(33,'BMW','Z3',2003,'Azul','Gasóleo','47-PE-22',28550.00,'2023-03-11 00:00:00',141233,326800.00),(35,'Jaguar','X-Type',2009,'verde','Gasóleo','21-FA-32',23550.00,'2023-03-11 00:00:00',150123,29990.00),(36,'Madza','MX5',2020,'Azul','Gasolina','74-KL-91',22550.00,'2023-03-11 00:00:00',45698,25550.00),(38,'Honda ','Civic',2002,'Preta','Gasolina','XX-78-89',650.00,'2023-03-16 00:00:00',98741,1350.00),(43,'Hyundai','Accent',1999,'Cinzento','Gasolina','PE-96-81',850.00,'2023-03-18 00:00:00',170556,1450.00),(44,'Hyundai','Accent',2001,'Cinza','Gasolina','PE-94-79',890.00,'2023-03-18 00:00:00',165000,15000.00),(46,'Hyundai','Accent',2001,'Cinza','Gasolina','PD-76-68',450.00,'2023-03-19 00:00:00',165231,1350.00),(47,'Opel','Corsa 1.2 Enjoy',2013,'Preta','Gasolina','32-NU-81',8500.00,'2023-03-19 00:00:00',123000,12550.00),(48,'Hyundai','Accent',2002,'Cinza','Gasolina','PG-66-14',450.00,'2023-03-19 00:00:00',165231,1350.00);
/*!40000 ALTER TABLE `stand` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `vendas`
--

DROP TABLE IF EXISTS `vendas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `vendas` (
  `idVendas` int NOT NULL AUTO_INCREMENT,
  `marca` varchar(45) DEFAULT NULL,
  `modelo` varchar(45) DEFAULT NULL,
  `ano` int DEFAULT NULL,
  `cor` varchar(45) DEFAULT NULL,
  `fonte_energia` varchar(45) DEFAULT NULL,
  `matricula` varchar(45) DEFAULT NULL,
  `quilometros` int DEFAULT NULL,
  `preco_compra` decimal(9,2) DEFAULT NULL,
  `preco_venda` decimal(9,2) DEFAULT NULL,
  `data_compra` datetime DEFAULT NULL,
  `data_venda` datetime DEFAULT NULL,
  PRIMARY KEY (`idVendas`),
  UNIQUE KEY `idVendas_UNIQUE` (`idVendas`),
  UNIQUE KEY `matricula_UNIQUE` (`matricula`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vendas`
--

LOCK TABLES `vendas` WRITE;
/*!40000 ALTER TABLE `vendas` DISABLE KEYS */;
INSERT INTO `vendas` VALUES (5,'Opel','Corsa',1998,'vermelha','Gasolina','87-ZE-78',165231,255.00,850.00,'2023-03-09 00:00:00','2023-03-09 00:00:00'),(7,'Seat','Leon',2001,'Preta','Gasóleo','74-KL-47',56321,4500.00,11500.00,'2023-03-07 00:00:00','2023-03-11 00:00:00'),(11,'Ford','Focus',2000,'Cinza','Gasolina','XP-32-12',102654,530.00,1030.00,'2023-03-16 00:00:00','2023-03-16 00:00:00'),(15,'Hyundai','Accent',2003,'Cinza','Gasolina','PG-66-77',156321,750.00,1350.00,'2023-03-17 00:00:00','2023-03-19 00:00:00'),(16,'Hyundai','Accent',2001,'Cinza','Gasolina','PG-66-45',165231,450.00,1350.00,'2023-03-17 00:00:00','2023-03-19 00:00:00');
/*!40000 ALTER TABLE `vendas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'standauto'
--

--
-- Dumping routines for database 'standauto'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-03-19 16:02:12
