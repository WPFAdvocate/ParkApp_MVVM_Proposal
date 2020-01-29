-- MySQL dump 10.16  Distrib 10.1.26-MariaDB, for debian-linux-gnu (x86_64)
--
-- Host: localhost    Database: db
-- ------------------------------------------------------
-- Server version	10.1.26-MariaDB-0+deb9u1

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `Parking`
--

DROP TABLE IF EXISTS `Parking`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Parking` (
  `ID` smallint(6) DEFAULT NULL,
  `Name` varchar(31) DEFAULT NULL,
  `ParkedVehicle` varchar(1) DEFAULT NULL,
  `SlotType` varchar(1) DEFAULT NULL,
  `Number` tinyint(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Parking`
--

LOCK TABLES `Parking` WRITE;
/*!40000 ALTER TABLE `Parking` DISABLE KEYS */;
INSERT INTO `Parking` VALUES (1,'Reman Trailer','','D',1),(2,'Catalyst Divider Trailer','','D',2),(3,'Scrap Metal Trailer','','D',3),(4,'YDM Torque Converter','1','D',4),(5,'YDM Torque Converter','2','D',5),(6,'YDM Torque Converter','3','D',6),(7,'Trash Compactor','','D',7),(8,'Cardboard Compactor','','D',8),(9,'Big Overhead Door','','D',9),(10,'ELP 2DU Shipping','','D',10),(11,'ELP 2DU Shipping','','D',11),(12,'ELP 2DU Empty Rack Storage','1','D',12),(13,'ELP 2DU Empty Rack Storage','2','D',13),(14,'ELP 2TN Empty Rack Storage','3','D',14),(15,'ELP 2TN Empty Rack Storage','','D',15),(16,'ELP 2TN Shipping','','D',16),(17,'ELP 2TN Shipping','','D',17),(18,'MAP Shipping','','D',18),(19,'MAP Shipping','','D',19),(20,'MAP Empty Rack Storage','1','D',20),(21,'Silencer Storage','2','D',21),(22,'Big Overhead Door Expansion','3','D',22),(23,'AEP Shipping','','D',23),(24,'AEP Shipping','','D',24),(25,'AEP Shipping','1','D',25),(26,'ELP Shipping','1','D',26),(27,'ELP Shipping','1','D',27),(28,'ELP Shipping','1','D',28),(29,'HCM Shipping','1','D',29),(30,'HCM Shipping','1','D',30),(31,'HMIN Shipping','1','D',31),(32,'HMIN Shipping','','D',32),(33,'Service Part Shipping','','D',33),(34,'YDM/ACYT/HSC/New Model Shipping','','D',34),(35,'Receiving','1','D',35),(36,'Receiving','2','D',36),(37,'Receiving','3','D',37),(38,'Receiving','','D',38),(39,'Receiving','','D',39),(40,'Receiving','','D',40),(41,'YDM Receiving','','D',41),(42,'YDM Receiving','','D',42),(43,'Percision Stamping Metal','1','D',43),(44,'Expedite Receiving','2','D',44),(45,'Expedite Receiving','3','D',45),(46,'Big Overhead Door MRO/Stamping','','D',46),(47,'Parking','','P',1),(48,'Parking','1','P',2),(49,'Parking','1','P',3),(50,'Parking','','P',4),(51,'Parking','','P',5),(52,'Parking','','P',6),(53,'Parking','1','P',7),(54,'Parking','2','P',8),(55,'Parking','3','P',9),(56,'Parking','','P',10),(57,'Parking','','P',11),(58,'Parking','','P',12),(59,'Parking','','P',13),(60,'Parking','','P',14),(61,'Parking','1','P',15),(62,'Parking','2','P',16),(63,'Parking','3','P',17),(64,'Parking','','P',18),(65,'Parking','','P',19),(66,'Parking','1','P',20),(67,'Parking','1','P',21),(68,'Parking','1','P',22),(69,'Parking','1','P',23),(70,'Parking','','P',24),(71,'Parking','','P',25),(72,'Parking','','P',26),(73,'Parking','1','P',27),(74,'Parking','2','P',28),(75,'Parking','3','P',29),(76,'Parking','','P',30),(77,'Parking','','P',31),(78,'Parking','1','P',32),(79,'Parking','1','P',33),(80,'Parking','','P',34),(81,'Parking','','P',35),(82,'Parking','','P',36),(83,'Parking','1','P',37),(84,'Parking','2','P',38),(85,'Parking','3','P',39),(86,'Parking','0','P',40),(87,'Parking','','P',41),(88,'Parking','','P',42),(89,'Parking','','P',43),(90,'Parking','','P',44),(91,'Parking','1','P',45),(92,'Parking','2','P',46),(93,'Parking','3','P',47),(94,'Parking','','P',48),(95,'Parking','','P',49),(96,'Parking','1','P',50),(97,'Parking','1','P',51),(98,'Parking','','P',52),(99,'Parking','','P',53),(100,'Parking','','P',54);
/*!40000 ALTER TABLE `Parking` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `TruckLog`
--

DROP TABLE IF EXISTS `TruckLog`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `TruckLog` (
  `ID` tinyint(4) DEFAULT NULL,
  `Company` tinyint(4) DEFAULT NULL,
  `DriverName` varchar(12) DEFAULT NULL,
  `DLicenseNum` varchar(0) DEFAULT NULL,
  `DLicenseState` varchar(8) DEFAULT NULL,
  `TractorNum` smallint(6) DEFAULT NULL,
  `TrailerNum` varchar(6) DEFAULT NULL,
  `SealNum` mediumint(9) DEFAULT NULL,
  `RemovedTrailerNum` varchar(0) DEFAULT NULL,
  `BoxTruck` tinyint(4) DEFAULT NULL,
  `status` varchar(1) DEFAULT NULL,
  `TimeArrived` varchar(23) DEFAULT NULL,
  `TimeDeparted` varchar(0) DEFAULT NULL,
  `ContainerNum` smallint(6) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `TruckLog`
--

LOCK TABLES `TruckLog` WRITE;
/*!40000 ALTER TABLE `TruckLog` DISABLE KEYS */;
INSERT INTO `TruckLog` VALUES (0,3,'Blake Whitt','','Arkansas',1234,'123456',12345,'',0,'A','2020-01-20 11:03:05.077','',123),(1,4,'Buck Jhonson','','Ohio',1234,'123456',12345,'',1,'D','2020-01-20 11:40:17.547','',123),(2,4,'Buck Jhonson','','Ohio',1234,'123456',12345,'',1,'D','2020-01-20 11:40:41.403','',123),(3,4,'Buck Jhonson','','Ohio',1234,'123456',12345,'',1,'D','2020-01-20 11:40:41.940','',123),(4,4,'Buck Jhonson','','Ohio',1234,'123456',12345,'',1,'D','2020-01-20 11:40:42.153','',123),(5,4,'Buck Jhonson','','Ohio',1234,'123456',12345,'',1,'A','2020-01-20 11:40:42.360','',123),(6,4,'Buck Jhonson','','Ohio',1234,'123456',12345,'',1,'A','2020-01-20 11:40:42.547','',123),(7,4,'Buck Jhonson','','Ohio',1234,'123456',12345,'',1,'A','2020-01-20 11:40:42.733','',123),(8,4,'Buck Jhonson','','Ohio',1234,'123456',12345,'',1,'A','2020-01-20 11:40:42.917','',123),(9,4,'Buck Jhonson','','Ohio',1234,'123456',12345,'',1,'D','2020-01-20 11:40:43.097','',123),(10,4,'Buck Jhonson','','Ohio',1234,'123456',12345,'',1,'D','2020-01-20 11:40:43.293','',123),(11,4,'Buck Jhonson','','Ohio',1234,'123456',12345,'',1,'D','2020-01-20 11:40:43.490','',123),(12,4,'Buck Jhonson','','Ohio',1234,'123456',12345,'',1,'D','2020-01-20 11:40:43.657','',123),(13,4,'Buck Jhonson','','Ohio',1234,'123456',12345,'',1,'A','2020-01-20 11:40:43.823','',123),(14,4,'Buck Jhonson','','Ohio',1234,'123456',12345,'',1,'D','2020-01-20 11:40:44.000','',123),(15,4,'Buck Jhonson','','Ohio',1234,'',12345,'',1,'D','2020-01-20 11:40:44.177','',123),(16,4,'Buck Jhonson','','Ohio',1234,'',12345,'',1,'D','2020-01-20 11:40:44.363','',123),(17,4,'Buck Jhonson','','Ohio',1234,'',12345,'',1,'D','2020-01-20 11:40:44.540','',123);
/*!40000 ALTER TABLE `TruckLog` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sqlite_sequence`
--

DROP TABLE IF EXISTS `sqlite_sequence`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sqlite_sequence` (
  `name` varchar(8) DEFAULT NULL,
  `seq` smallint(6) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sqlite_sequence`
--

LOCK TABLES `sqlite_sequence` WRITE;
/*!40000 ALTER TABLE `sqlite_sequence` DISABLE KEYS */;
INSERT INTO `sqlite_sequence` VALUES ('Parking',107),('TruckLog',17);
/*!40000 ALTER TABLE `sqlite_sequence` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-08-22 15:20:25
