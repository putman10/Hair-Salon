-- phpMyAdmin SQL Dump
-- version 4.7.7
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Generation Time: Jul 13, 2018 at 11:59 PM
-- Server version: 5.6.38
-- PHP Version: 7.2.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `ryan_putman`
--
CREATE DATABASE IF NOT EXISTS `ryan_putman` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `ryan_putman`;

-- --------------------------------------------------------

--
-- Table structure for table `clients`
--

CREATE TABLE `clients` (
  `Id` bigint(20) UNSIGNED NOT NULL,
  `Stylist_Id` int(11) NOT NULL,
  `Name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `clients`
--

INSERT INTO `clients` (`Id`, `Stylist_Id`, `Name`) VALUES
(15, 8, 'Jennifer Lopez'),
(16, 11, 'Redmond Local'),
(17, 12, 'Volk Sinyo'),
(18, 10, 'Belkin Long'),
(19, 12, 'Dependent Ben'),
(20, 11, 'Nom Mante'),
(21, 10, 'Beer Mac'),
(22, 10, 'Selena Gomez'),
(23, 9, 'Taylor Swift'),
(24, 8, 'Gizmo Putman');

-- --------------------------------------------------------

--
-- Table structure for table `stylists`
--

CREATE TABLE `stylists` (
  `Id` bigint(20) UNSIGNED NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Description` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `stylists`
--

INSERT INTO `stylists` (`Id`, `Name`, `Description`) VALUES
(8, 'Jonathon Grimes', 'Jonathon Grimes'),
(9, 'Steven Sideran', 'Test Description for all Stylists.'),
(10, 'Kevin Red', 'Test Description for all Stylists.'),
(11, 'Emma Porter', 'Test Description for all Stylists.'),
(12, 'Stephanie Smith', 'Test Description for all Stylists.'),
(13, 'Apple', 'This is a time for me to shine'),
(14, 'fasdfasdfasf', 'fasdfasdfasf');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `clients`
--
ALTER TABLE `clients`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `Id` (`Id`);

--
-- Indexes for table `stylists`
--
ALTER TABLE `stylists`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `Id` (`Id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `clients`
--
ALTER TABLE `clients`
  MODIFY `Id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=25;

--
-- AUTO_INCREMENT for table `stylists`
--
ALTER TABLE `stylists`
  MODIFY `Id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
