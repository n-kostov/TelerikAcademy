CREATE DATABASE  IF NOT EXISTS `bookdb` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `bookdb`;
-- MySQL dump 10.13  Distrib 5.6.12, for Win64 (x86_64)
--
-- Host: localhost    Database: bookdb
-- ------------------------------------------------------
-- Server version	5.6.12

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `books`
--

DROP TABLE IF EXISTS `books`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `books` (
  `BookId` int(11) NOT NULL AUTO_INCREMENT,
  `Title` varchar(45) NOT NULL,
  `Author` varchar(45) DEFAULT NULL,
  `PublishDate` datetime DEFAULT NULL,
  `ISBN` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`BookId`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `books`
--

INSERT INTO `books` VALUES (1,'The sun also rises','Hemingway ','1926-01-01 00:00:00',NULL),(2,'For whom the bell tolls','Hemingway ','1940-06-06 00:00:00','afwfda6d6af'),(3,'The sun also rises','Copy machine','2001-07-05 00:00:00',NULL),(4,'Qwerty','Qwertyson','2013-07-15 22:10:33','saddf234d'),(5,'Qwerty','Qwertyson','2001-12-14 14:00:00','saddf234d'),(6,'Qwerty','Qwertyson','2001-12-14 14:00:00','saddf234d'),(7,'Ot zapada',NULL,NULL,NULL);

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed
