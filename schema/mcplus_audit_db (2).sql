-- phpMyAdmin SQL Dump
-- version 5.2.3
-- https://www.phpmyadmin.net/
--
-- Host: db
-- Generation Time: Jun 29, 2026 at 02:33 AM
-- Server version: 9.6.0
-- PHP Version: 8.3.26

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `mcplus_audit_db`
--

-- --------------------------------------------------------

--
-- Table structure for table `authority`
--

CREATE TABLE `authority` (
  `idauthority` int NOT NULL COMMENT 'record unique id',
  `company_code` varchar(2) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'company code',
  `authority_code` varchar(3) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'authority code',
  `authority_desc` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'authority description',
  `create_date` date NOT NULL COMMENT 'record creation date',
  `create_time` time(6) NOT NULL COMMENT 'record creation time',
  `create_by` varchar(25) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'record created by',
  `replication_stat` varchar(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'replication status',
  `replication_tstamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'replication timestamp'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='authority table';

--
-- Dumping data for table `authority`
--

INSERT INTO `authority` (`idauthority`, `company_code`, `authority_code`, `authority_desc`, `create_date`, `create_time`, `create_by`, `replication_stat`, `replication_tstamp`) VALUES
(1, 'M2', 'STK', 'Stock Clerk', '2025-01-15', '08:49:45.000049', 'test', '', '2025-01-15 00:51:18'),
(2, 'M2', 'RPT', 'Report', '2025-01-15', '08:51:39.000109', 'test', '', '2026-04-21 03:35:13'),
(3, 'M2', 'ADM', 'Administrator', '2025-01-15', '08:52:39.000059', 'test', '', '2025-01-15 00:53:10'),
(4, 'M2', 'OPE', 'Operator - System Maintenance', '2025-01-15', '08:53:14.000089', 'test', '', '2025-01-15 00:55:06'),
(5, 'M2', 'CAS', 'Cashier', '2025-01-20', '10:29:10.000148', 'admin', '0', '2025-01-20 02:29:46'),
(6, 'MC', 'STK', 'Stock Clerk', '2026-04-08', '16:33:39.000000', '45', '1', '2026-04-08 08:34:20'),
(7, 'MC', 'RPT', 'Reporter', '2026-04-08', '16:34:47.000000', '45', '1', '2026-04-08 08:34:50'),
(8, 'MC', 'ADM', 'Administrator', '2026-04-08', '16:35:00.000000', '45', '1', '2026-04-08 08:35:04'),
(9, 'MC', 'OPE', 'Operator - System Maintenance', '2026-04-08', '16:35:09.000000', '45', '1', '2026-04-08 08:35:13'),
(10, 'MC', 'CAS', 'Cashier', '2026-04-08', '16:35:21.000000', '45', '1', '2026-04-08 08:35:25');

-- --------------------------------------------------------

--
-- Table structure for table `company`
--

CREATE TABLE `company` (
  `idcompany` int NOT NULL COMMENT 'record unique id',
  `company_code` varchar(2) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'company code',
  `company_desc` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'company description',
  `company_addr` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'company address',
  `tin_num` varchar(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'tin number',
  `contact_num` varchar(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'contact_num',
  `email_addr` varchar(25) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'email address',
  `company_url` varchar(199) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'company url and Concat to QR Code SKU link ',
  `com_banner` varchar(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'company banner',
  `status` varchar(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'company status',
  `create_date` date NOT NULL COMMENT 'record creation date',
  `create_time` time(6) NOT NULL COMMENT 'record creation time',
  `create_by` varchar(25) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'record created by',
  `replication_stat` int NOT NULL COMMENT 'replication status',
  `replication_tstamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'replication timestamp'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='audit table';

--
-- Dumping data for table `company`
--

INSERT INTO `company` (`idcompany`, `company_code`, `company_desc`, `company_addr`, `tin_num`, `contact_num`, `email_addr`, `company_url`, `com_banner`, `status`, `create_date`, `create_time`, `create_by`, `replication_stat`, `replication_tstamp`) VALUES
(1, 'QS', 'QStitch', 'Cabuyao Laguna', '101-101-101', '09123456789', '@qstitch.com', 'https://link.qstitchclothing.com/', 'D:\\Project\\Visual Studio\\source\\repos\\Inventory System\\Inventory System\\bin\\Release\\net9.0-windows7.0\\images\\company\\QS.jpg', '1', '2025-01-13', '09:29:38.000000', 'test', 1, '2025-05-07 05:55:56'),
(2, 'M2', 'M28 Motorparts', 'Sta. Rosa Laguna', '202-202-202', '09460637192', 'sales@m28corp.com', 'https://link.m28corp.com/', 'D:\\Project\\Visual Studio\\source\\repos\\Inventory System\\Inventory System\\bin\\Release\\net9.0-windows7.0\\images\\company\\M2.jpg', '1', '2025-01-13', '09:40:06.000040', 'test', 1, '2026-04-08 08:46:55'),
(4, 'MC', 'MC+', 'Brgy. Tagapo, Sta. Rosa Laguna 4026', '303-303-303', '09460637192', 'sales@m28corp.com', 'https://link.medicalcoatplus.com/', 'D:\\Project\\Visual Studio\\source\\repos\\Inventory System\\Inventory System\\bin\\Release\\net9.0-windows7.0\\images\\company\\M2.jpg', '1', '2025-01-13', '09:40:06.000040', 'test', 1, '2026-04-08 08:47:07');

-- --------------------------------------------------------

--
-- Table structure for table `log`
--

CREATE TABLE `log` (
  `idlog` int NOT NULL COMMENT 'record unique id',
  `company_code` varchar(2) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'company code',
  `module_id` varchar(6) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'program module identification',
  `transaction_type` varchar(3) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'transaction type',
  `field` varchar(25) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'affected field',
  `from_value` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'value before transaction',
  `to_value` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'value after transaction',
  `create_date` date NOT NULL COMMENT 'record creation date',
  `create_time` time(6) NOT NULL COMMENT 'record creation time',
  `create_by` varchar(25) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'record created by',
  `replication_stat` int NOT NULL COMMENT 'replication status',
  `replication_tstamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'replication timestamp'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `iduser` int NOT NULL COMMENT 'record unique id',
  `company_code` varchar(2) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'company code',
  `user_name` varchar(25) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'user name',
  `user_pass` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'user password',
  `user_desc` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'user description',
  `full_name` varchar(299) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `authority_code` varchar(3) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'authority code',
  `user_img` varchar(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'user image',
  `user_stat` varchar(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'user status',
  `create_date` date NOT NULL COMMENT 'record creation date',
  `create_time` time(6) NOT NULL COMMENT 'record creation time',
  `create_by` varchar(25) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'record created by',
  `replication_stat` int NOT NULL COMMENT 'replication status',
  `replication_tstamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'replication timestamp'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='user table';

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`iduser`, `company_code`, `user_name`, `user_pass`, `user_desc`, `full_name`, `authority_code`, `user_img`, `user_stat`, `create_date`, `create_time`, `create_by`, `replication_stat`, `replication_tstamp`) VALUES
(1, 'MC', 'mc+admin', 'eSoQsYobTXa6o9BL9y9/Bw==', 'system administrator', 'Administrator', 'ADM', '', '1', '2026-04-27', '08:31:36.000000', '1', 1, '2026-04-27 00:35:45'),
(2, 'MC', 'dencina', 'AIrU9joFNq1LezG04Ofztw==', 'hello', 'dennis encina', 'ADM', 'test', '1', '2026-05-11', '10:28:42.000000', '1', 1, '2026-05-11 02:28:42');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `authority`
--
ALTER TABLE `authority`
  ADD PRIMARY KEY (`idauthority`),
  ADD KEY `fk_authority_company_code` (`company_code`);

--
-- Indexes for table `company`
--
ALTER TABLE `company`
  ADD PRIMARY KEY (`idcompany`),
  ADD UNIQUE KEY `uq_company_code` (`company_code`);

--
-- Indexes for table `log`
--
ALTER TABLE `log`
  ADD PRIMARY KEY (`idlog`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`iduser`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `authority`
--
ALTER TABLE `authority`
  MODIFY `idauthority` int NOT NULL AUTO_INCREMENT COMMENT 'record unique id', AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `company`
--
ALTER TABLE `company`
  MODIFY `idcompany` int NOT NULL AUTO_INCREMENT COMMENT 'record unique id', AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `log`
--
ALTER TABLE `log`
  MODIFY `idlog` int NOT NULL AUTO_INCREMENT COMMENT 'record unique id';

--
-- AUTO_INCREMENT for table `user`
--
ALTER TABLE `user`
  MODIFY `iduser` int NOT NULL AUTO_INCREMENT COMMENT 'record unique id', AUTO_INCREMENT=3;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `authority`
--
ALTER TABLE `authority`
  ADD CONSTRAINT `fk_authority_company_code` FOREIGN KEY (`company_code`) REFERENCES `company` (`company_code`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
