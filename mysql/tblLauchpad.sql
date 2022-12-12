-- phpMyAdmin SQL Dump
-- version 4.9.5
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Nov 02, 2020 at 11:25 PM
-- Server version: 5.7.30
-- PHP Version: 7.4.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `sean_dotnetcoreSamples`
--

-- --------------------------------------------------------

--
-- Table structure for table `tblCategory`
--

CREATE TABLE `tblCategory` (
  `categoryId` int NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `categoryName` varchar(100) NOT NULL
);



CREATE TABLE `tblLink` (
  `linkId` int NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `link` varchar(100) NOT NULL,
  `href` varchar(200) NOT NULL,
  `categoryId` int NOT NULL,
  `pinned` varchar(6) NOT NULL
);



CREATE TABLE `tblLogin` (
  `username` varchar(20) NOT NULL,
  `userId` int NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `password` varchar(200) NOT NULL,
  `salt` varchar(200) NOT NULL
);

--admin admin
INSERT INTO `tblLogin` (`username`, `password`, `salt`)
VALUES ('admin', '2tlSd6XfoK+WNPL1zqCxuBsG/4GH4PScLEdRCw3i/mk=', 'Sw+nPGWtmw5WdAghX6+1ug==');

INSERT INTO `tblCategory` (`categoryName`)
VALUES ('Technology');
INSERT INTO `tblCategory` (`categoryName`)
VALUES ('Data');
INSERT INTO `tblCategory` (`categoryName`)
VALUES ('Data');
INSERT INTO `tblCategory` (`categoryName`)
VALUES ('Data');


--
-- Indexes for dumped tables
--


-- AUTO_INCREMENT for dumped tables
--

--
