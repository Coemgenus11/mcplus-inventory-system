-- phpMyAdmin SQL Dump
-- version 5.2.3
-- https://www.phpmyadmin.net/
--
-- Host: db
-- Generation Time: Apr 14, 2026 at 05:31 AM
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
-- Database: `mcplus_inventory_db`
--

DELIMITER $$
--
-- Procedures
--
CREATE DEFINER=`bst1`@`%` PROCEDURE `sp_insert_itembal_all_stores` ()   BEGIN

  INSERT INTO `itembal` (
    `company_code`, `sku_code`, `item_qty`, `item_loc`, `store_code`,
    `create_date`, `create_time`, `create_by`, `replication_stat`
  )
  SELECT 
    v.company_code,
    CONCAT(v.parent_sku_code, v.var_code),
    0,
    'Q001',
    s.store_code,
    CURDATE(),
    CURTIME(),
    v.create_by,
    0
  FROM variation v
  JOIN store s 
    ON s.company_code = v.company_code
  WHERE NOT EXISTS (
    SELECT 1 
    FROM itembal b
    WHERE b.sku_code = CONCAT(v.parent_sku_code, v.var_code)
      AND b.company_code = v.company_code
      AND b.store_code = s.store_code
  );

END$$

CREATE DEFINER=`bst1`@`%` PROCEDURE `sp_insert_itemprice_all_stores` ()   BEGIN

  INSERT INTO `itemprice` (
    `company_code`, `store_code`, `sku_code`, `unit_price`, `retail_price`,
    `create_date`, `create_time`, `create_by`, `replication_stat`, `replication_tstamp`
  )
  SELECT 
    v.company_code,
    s.store_code,
    CONCAT(v.parent_sku_code, v.var_code),
    0.00,
    0.00,
    CURDATE(),
    CURTIME(),
    v.create_by,
    0,
    CURRENT_TIMESTAMP
  FROM variation v
  JOIN store s 
    ON s.company_code = v.company_code
  WHERE NOT EXISTS (
    SELECT 1
    FROM itemprice p
    WHERE p.sku_code = CONCAT(v.parent_sku_code, v.var_code)
      AND p.company_code = v.company_code
      AND p.store_code = s.store_code
  );

END$$

CREATE DEFINER=`bst1`@`%` PROCEDURE `sp_insert_items_from_variation` ()   BEGIN

    INSERT INTO `item` (
        `company_code`, `parent_sku_code`, `sku_code`, `sku_link`, 
        `gen_code`, `col_code`, `type_code`, `stylecat_code`, 
        `stylevar_code`, `color_code`, `var_code`, 
        `merchandise`, `status`, `printed`, 
        `create_date`, `create_time`, `create_by`, `replication_stat`
    )
    SELECT 
        v.company_code, 
        v.parent_sku_code,

        CONCAT(v.parent_sku_code, v.var_code) AS sku_code,
        CONCAT(c.company_url, CONCAT(v.parent_sku_code, v.var_code)) AS sku_link,

        ps.gen_code,
        ps.col_code,
        ps.type_code,
        ps.stylecat_code,
        ps.stylevar_code,
        ps.color_code,

        v.var_code,

        '0',   -- merchandise
        '1',   -- status
        0,     -- printed

        CURDATE(),
        CURTIME(),
        v.create_by,
        0      -- replication_stat

    FROM variation v
    JOIN parent_sku ps
        ON ps.parent_sku_code = v.parent_sku_code
        AND ps.company_code = v.company_code
    JOIN audit_db.company c
        ON c.company_code = v.company_code
    WHERE NOT EXISTS (
        SELECT 1 
        FROM item i 
        WHERE i.sku_code = CONCAT(v.parent_sku_code, v.var_code)
        AND i.company_code = v.company_code
    );

END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `item`
--

CREATE TABLE `item` (
  `iditem` int NOT NULL COMMENT 'record unique id',
  `company_code` varchar(2) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'company code',
  `parent_sku_code` varchar(9) COLLATE utf8mb4_general_ci NOT NULL,
  `sku_code` varchar(12) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'sku code',
  `sku_link` varchar(299) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'SKU Link',
  `gen_code` varchar(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'gender code',
  `col_code` varchar(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'collection code',
  `type_code` varchar(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'type code',
  `stylecat_code` varchar(2) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'style category code',
  `stylevar_code` varchar(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'style variant code',
  `color_code` varchar(3) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'color code',
  `var_code` varchar(3) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'variation code',
  `merchandise` varchar(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'merchandise item indicator',
  `status` varchar(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'item status',
  `printed` int NOT NULL,
  `create_date` date NOT NULL COMMENT 'record creation date',
  `create_time` time(6) NOT NULL COMMENT 'record creation time',
  `create_by` varchar(25) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'record created by',
  `replication_stat` int NOT NULL COMMENT 'replication status',
  `replication_tstamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'replication timestamp'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `itembal`
--

CREATE TABLE `itembal` (
  `iditembal` int NOT NULL COMMENT 'record unique id',
  `company_code` varchar(2) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'company code',
  `item_code` varchar(6) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT 'item code',
  `color_code` varchar(3) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT 'color code',
  `size_code` varchar(3) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT 'size code',
  `sku_code` varchar(12) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'sku code',
  `item_desc` varchar(25) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT 'item description',
  `item_qty` int NOT NULL COMMENT 'item stock quantity',
  `item_loc` varchar(6) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'item stock location',
  `store_code` varchar(6) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `create_date` date NOT NULL COMMENT 'record creation date',
  `create_time` time(6) NOT NULL COMMENT 'record creation time',
  `create_by` varchar(25) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'record created by',
  `replication_stat` int NOT NULL COMMENT 'replication status',
  `replication_tstamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'replication timestamp'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='item balance table';

-- --------------------------------------------------------

--
-- Table structure for table `itemcat`
--

CREATE TABLE `itemcat` (
  `iditemcat` int NOT NULL,
  `company_code` varchar(2) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `category_code` varchar(2) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `category_desc` varchar(299) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `examples` varchar(299) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `remarks` varchar(99) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `status` int NOT NULL,
  `create_date` date NOT NULL,
  `create_time` time(6) NOT NULL,
  `create_by` varchar(25) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `replication_stat` int NOT NULL,
  `replication_tstamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `itemcat`
--

INSERT INTO `itemcat` (`iditemcat`, `company_code`, `category_code`, `category_desc`, `examples`, `remarks`, `status`, `create_date`, `create_time`, `create_by`, `replication_stat`, `replication_tstamp`) VALUES
(1, 'M2', 'EN', 'Engine Parts', 'Pistons, gaskets, cylinder kits, top gaskets, valves, valves seal,  connecting rod kit,', 'Moderate margin; OEM can command more.', 1, '2025-08-19', '14:43:00.000000', 'admin', 1, '2025-04-24 06:43:23'),
(2, 'M2', 'TC', 'Transmission and cvt', 'Chains, sprockets, clutches, gear sets, cvt assembly, oil seals, change pedal, kicker ', 'High demand but price-sensitive.', 1, '2025-08-19', '14:43:00.000001', 'admin', 1, '2025-04-24 06:43:24'),
(3, 'M2', 'EL', 'Electrical Parts', 'E.C.U, CDI, regulator, stator, ignition coils, spark plug, injector, fuel pump, t.p.s, relays, battery, carbon brush, starter motor, harnes, sockets', 'Allow buffer for returns/failure risk.', 1, '2025-08-19', '14:43:00.000002', 'admin', 1, '2025-04-24 06:43:25'),
(4, 'M2', 'LI', 'Lighting & Indicators', 'Headlights assembly, bulbs, LED strips, signal lights, break light, volt meter, handle switch', 'Design-focused parts can get higher margins.', 1, '2025-08-19', '14:43:00.000003', 'admin', 1, '2025-04-24 06:43:26'),
(5, 'M2', 'CL', 'Control & Levers', 'Brake/clutch levers, handle grips,handle switches, handle bars, break/clutch cables, ball race, trottle cable', 'Small but high-margin accessories.', 1, '2025-08-19', '14:43:00.000004', 'admin', 1, '2025-04-24 06:43:27'),
(6, 'M2', 'WT', 'Wheels & Tires', 'Rims, tires, tubes, wheel bearings, wheel shafting and nut, speed gear box, speed cable, seralant, inflator valve', 'Lower margin but high transaction value.', 1, '2025-08-19', '14:43:00.000005', 'admin', 1, '2025-04-24 06:43:28'),
(7, 'M2', 'BS', 'Braking System', 'Brake pads, calipers, rotors, brake fluid, break hose,', 'Fast-moving; brake fluid has shelf life.', 1, '2025-08-19', '14:43:00.000006', 'admin', 1, '2025-04-24 06:43:29'),
(8, 'M2', 'SU', 'Suspension', 'Forks, shocks, bushings, linkages, swing arms,', 'High-ticket parts; aim for volume.', 1, '2025-08-19', '14:43:00.000007', 'admin', 1, '2025-04-24 06:43:30'),
(9, 'M2', 'FE', 'Fairings and emblem', 'decals, panels, fenders, ', 'High styling value = higher margin.', 1, '2025-08-19', '14:43:00.000008', 'admin', 1, '2025-04-24 06:43:31'),
(10, 'M2', 'ML', 'Maintinance Oil and lubricants', 'Oil, oil filter, collant, carbon cleaner,', 'Low margin but frequent sales.', 1, '2025-08-19', '14:43:00.000009', 'admin', 1, '2025-04-24 06:43:32'),
(11, 'M2', 'AC', 'Accessories', 'side mirors, Phone mounts, horns, USB chargers, bags, racks and brackets, body bolts, foot rest, seat', 'Impulse-buy accessories = big margins.', 1, '2025-08-19', '14:43:00.000010', 'admin', 1, '2025-04-24 06:43:33'),
(12, 'M2', 'HG', 'Helmets & Gear', 'Helmets, gloves, jackets, raincoats', 'Brand-driven pricing; certification matters.', 1, '2025-08-19', '14:43:00.000011', 'admin', 1, '2025-04-24 06:43:34'),
(13, 'M2', 'ES', 'Exhaust system', 'pipe, gasket, heat guard, oxygen sesors', 'Gears and Helmets', 1, '2025-08-19', '14:43:00.000012', 'admin', 1, '2025-04-24 06:43:35'),
(14, 'M2', 'IS', 'Intake system', 'carburator, repair kits, trottle body, manifods, airfilter, fuel filter,  air box, spark plug, gas tank, floater', 'Engine Systems', 1, '2025-08-19', '14:43:00.000013', 'admin', 1, '2025-04-24 06:43:36');

-- --------------------------------------------------------

--
-- Table structure for table `itemcol`
--

CREATE TABLE `itemcol` (
  `iditemcol` int NOT NULL COMMENT 'record unique id',
  `company_code` varchar(2) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'company code',
  `col_code` varchar(3) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'type code',
  `col_desc` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'location description\r\n',
  `status` tinyint(1) NOT NULL COMMENT 'status',
  `create_date` date NOT NULL COMMENT 'record creation date',
  `create_time` time(6) NOT NULL COMMENT 'record creation time',
  `create_by` varchar(25) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'record created by',
  `replication_stat` int NOT NULL COMMENT 'replication status',
  `replication_tstamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'replication timestamp'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `itemcol`
--

INSERT INTO `itemcol` (`iditemcol`, `company_code`, `col_code`, `col_desc`, `status`, `create_date`, `create_time`, `create_by`, `replication_stat`, `replication_tstamp`) VALUES
(1, 'MC', 'F', 'FlexMove', 1, '2026-04-14', '13:11:19.000000', '45', 1, '2026-04-14 05:11:35'),
(2, 'MC', 'C', 'CoreComfort', 1, '2026-04-14', '13:11:31.000000', '45', 1, '2026-04-14 05:11:47');

-- --------------------------------------------------------

--
-- Table structure for table `itemcolor`
--

CREATE TABLE `itemcolor` (
  `idbrand` int NOT NULL,
  `company_code` varchar(3) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `color_code` varchar(5) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `color_desc` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `status` tinyint(1) NOT NULL,
  `create_date` date DEFAULT NULL,
  `create_time` time(6) DEFAULT NULL,
  `create_by` varchar(25) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `replication_stat` int DEFAULT NULL,
  `replication_tstamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `itemcolor`
--

INSERT INTO `itemcolor` (`idbrand`, `company_code`, `color_code`, `color_desc`, `status`, `create_date`, `create_time`, `create_by`, `replication_stat`, `replication_tstamp`) VALUES
(1, 'MC', '001', 'Olive Grove', 1, '2026-04-14', '13:12:12.000000', '45', 1, '2026-04-14 05:12:28'),
(2, 'MC', '002', 'Arctic White', 1, '2026-04-14', '13:12:26.000000', '45', 1, '2026-04-14 05:12:42'),
(3, 'MC', '003', 'Blush Peach', 1, '2026-04-14', '13:12:36.000000', '45', 1, '2026-04-14 05:12:52'),
(4, 'MC', '004', 'Mocha Espresso', 1, '2026-04-14', '13:12:53.000000', '45', 1, '2026-04-14 05:13:10'),
(5, 'MC', '005', 'Copper Clay', 1, '2026-04-14', '13:13:05.000000', '45', 1, '2026-04-14 05:13:22'),
(6, 'MC', '006', 'Gunmetal', 1, '2026-04-14', '13:13:14.000000', '45', 1, '2026-04-14 05:13:31'),
(7, 'MC', '007', 'Jade Luxe', 1, '2026-04-14', '13:13:22.000000', '45', 1, '2026-04-14 05:13:38'),
(8, 'MC', '008', 'Combat Green', 1, '2026-04-14', '13:13:32.000000', '45', 1, '2026-04-14 05:13:48'),
(9, 'MC', '009', 'Rosewood', 1, '2026-04-14', '13:13:42.000000', '45', 1, '2026-04-14 05:13:58'),
(10, 'MC', '010', 'Midnight Navy', 1, '2026-04-14', '13:13:53.000000', '45', 1, '2026-04-14 05:14:09'),
(11, 'MC', '011', 'Golden Honey', 1, '2026-04-14', '13:14:05.000000', '45', 1, '2026-04-14 05:14:21'),
(12, 'MC', '012', 'Mocha Brown', 1, '2026-04-14', '13:14:14.000000', '45', 1, '2026-04-14 05:14:30'),
(13, 'MC', '013', 'Dayglow', 1, '2026-04-14', '13:14:23.000000', '45', 1, '2026-04-14 05:14:39'),
(14, 'MC', '014', 'Onyx', 1, '2026-04-14', '13:14:32.000000', '45', 1, '2026-04-14 05:14:48'),
(15, 'MC', '015', 'Urban Steel', 1, '2026-04-14', '13:14:41.000000', '45', 1, '2026-04-14 05:14:58'),
(16, 'MC', '016', 'Sapphire', 1, '2026-04-14', '13:14:51.000000', '45', 1, '2026-04-14 05:15:08'),
(17, 'MC', '017', 'Sunflare', 1, '2026-04-14', '13:15:06.000000', '45', 1, '2026-04-14 05:15:23'),
(18, 'MC', '018', 'Wine Red', 1, '2026-04-14', '13:15:16.000000', '45', 1, '2026-04-14 05:15:32'),
(19, 'MC', '019', 'Eucalyptus', 1, '2026-04-14', '13:15:24.000000', '45', 1, '2026-04-14 05:15:40'),
(20, 'MC', '020', 'Sandstone', 1, '2026-04-14', '13:15:31.000000', '45', 1, '2026-04-14 05:15:48'),
(21, 'MC', '021', 'Deep Blue', 1, '2026-04-14', '13:27:38.000000', '45', 1, '2026-04-14 05:27:54'),
(22, 'MC', '022', 'Taupe', 1, '2026-04-14', '13:28:05.000000', '45', 1, '2026-04-14 05:28:21');

-- --------------------------------------------------------

--
-- Table structure for table `itemgen`
--

CREATE TABLE `itemgen` (
  `iditemgen` int NOT NULL COMMENT 'record unique id',
  `company_code` varchar(2) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'company code',
  `gen_code` varchar(3) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'type code',
  `gen_desc` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'location description\r\n',
  `status` tinyint(1) NOT NULL COMMENT 'status',
  `create_date` date NOT NULL COMMENT 'record creation date',
  `create_time` time(6) NOT NULL COMMENT 'record creation time',
  `create_by` varchar(25) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'record created by',
  `replication_stat` int NOT NULL COMMENT 'replication status',
  `replication_tstamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'replication timestamp'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `itemgen`
--

INSERT INTO `itemgen` (`iditemgen`, `company_code`, `gen_code`, `gen_desc`, `status`, `create_date`, `create_time`, `create_by`, `replication_stat`, `replication_tstamp`) VALUES
(1, 'MC', 'M', 'Men', 1, '2026-04-14', '13:10:39.000000', '45', 1, '2026-04-14 05:10:55'),
(2, 'MC', 'W', 'Women', 1, '2026-04-14', '13:10:49.000000', '45', 1, '2026-04-14 05:11:05');

-- --------------------------------------------------------

--
-- Table structure for table `itemloc`
--

CREATE TABLE `itemloc` (
  `iditemloc` int NOT NULL,
  `company_code` varchar(2) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `loc_code` varchar(4) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `loc_desc` varchar(25) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `status` varchar(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT '1',
  `create_datetime` datetime DEFAULT CURRENT_TIMESTAMP,
  `create_by` varchar(25) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `replication_stat` datetime DEFAULT CURRENT_TIMESTAMP,
  `replication_tstamp` datetime DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `item_location` varchar(25) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `store_code` varchar(25) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `itemmvt`
--

CREATE TABLE `itemmvt` (
  `iditemmvt` int NOT NULL COMMENT 'record unique id',
  `company` varchar(2) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'company code',
  `store_code` varchar(4) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `location` varchar(4) COLLATE utf8mb4_general_ci NOT NULL,
  `item_code` varchar(6) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT 'item code',
  `color_code` varchar(3) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT 'color code',
  `size_code` varchar(3) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT 'size code',
  `sku_code` varchar(12) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'sku code',
  `item_qty` int NOT NULL COMMENT 'item stock quantity',
  `origin` varchar(4) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `destination` varchar(4) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `itemloc_origin` varchar(6) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'location_code',
  `itemloc_dest` varchar(6) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `mvt_code` varchar(3) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'movement_code',
  `doc_no` varchar(25) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'document number',
  `create_date` date NOT NULL COMMENT 'record creation date',
  `create_time` time(6) NOT NULL COMMENT 'record creation time',
  `create_by` varchar(25) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'record created by',
  `replication_stat` int NOT NULL COMMENT 'replication status',
  `replication_tstamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'replication timestamp',
  `user_id` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='item movement table';

-- --------------------------------------------------------

--
-- Table structure for table `itemprice`
--

CREATE TABLE `itemprice` (
  `iditemprice` int NOT NULL,
  `company_code` varchar(2) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `store_code` varchar(4) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `sku_code` varchar(12) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `unit_price` decimal(10,2) NOT NULL,
  `retail_price` decimal(10,2) NOT NULL,
  `create_date` date NOT NULL,
  `create_time` time(6) NOT NULL,
  `create_by` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `replication_stat` int NOT NULL,
  `replication_tstamp` timestamp NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `itemstylecat`
--

CREATE TABLE `itemstylecat` (
  `idstylecat` int NOT NULL,
  `company_code` varchar(3) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `stylecat_code` varchar(2) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `stylecat_desc` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `wear_code` varchar(2) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `type_code` varchar(2) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `create_date` date DEFAULT NULL,
  `create_time` time(6) DEFAULT NULL,
  `create_by` varchar(25) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `replication_stat` int DEFAULT NULL,
  `replication_tstamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `itemstylecat`
--

INSERT INTO `itemstylecat` (`idstylecat`, `company_code`, `stylecat_code`, `stylecat_desc`, `wear_code`, `type_code`, `create_date`, `create_time`, `create_by`, `replication_stat`, `replication_tstamp`) VALUES
(1, 'MC', 'MA', 'Mandarin', 'TO', 'S', '2026-04-14', '13:18:14.000000', '45', 1, '2026-04-14 05:18:30'),
(2, 'MC', 'VN', 'V-Neck', 'TO', 'S', '2026-04-14', '13:18:38.000000', '45', 1, '2026-04-14 05:18:54'),
(3, 'MC', 'JO', 'Jogger', 'PA', 'S', '2026-04-14', '13:18:59.000000', '45', 1, '2026-04-14 05:19:15'),
(4, 'MC', 'SC', 'Straight Cut', 'PA', 'S', '2026-04-14', '13:19:18.000000', '45', 1, '2026-04-14 05:19:34');

-- --------------------------------------------------------

--
-- Table structure for table `itemstylevar`
--

CREATE TABLE `itemstylevar` (
  `idstylevar` int NOT NULL,
  `company_code` varchar(3) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `stylecat_code` varchar(2) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `stylevar_code` varchar(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `stylevar_desc` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `create_date` date DEFAULT NULL,
  `create_time` time(6) DEFAULT NULL,
  `create_by` varchar(25) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `replication_stat` int DEFAULT NULL,
  `replication_tstamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `itemstylevar`
--

INSERT INTO `itemstylevar` (`idstylevar`, `company_code`, `stylecat_code`, `stylevar_code`, `stylevar_desc`, `create_date`, `create_time`, `create_by`, `replication_stat`, `replication_tstamp`) VALUES
(1, 'MC', 'JO', '1', 'Style 1', '2026-04-14', '13:22:19.000000', '45', 1, '2026-04-14 05:22:35'),
(2, 'MC', 'MA', '1', 'Style 1', '2026-04-14', '13:22:30.000000', '45', 1, '2026-04-14 05:22:46'),
(3, 'MC', 'SC', '1', 'Style 1', '2026-04-14', '13:22:35.000000', '45', 1, '2026-04-14 05:22:51'),
(4, 'MC', 'VN', '1', 'Style 1', '2026-04-14', '13:22:46.000000', '45', 1, '2026-04-14 05:23:02');

-- --------------------------------------------------------

--
-- Table structure for table `itemtype`
--

CREATE TABLE `itemtype` (
  `iditemtype` int NOT NULL COMMENT 'record unique id',
  `company_code` varchar(2) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'company code',
  `type_code` varchar(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'type code',
  `type_desc` varchar(25) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'location description',
  `create_date` date NOT NULL COMMENT 'record creation date',
  `create_time` time(6) NOT NULL COMMENT 'record creation time',
  `create_by` varchar(25) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'record created by',
  `replication_stat` int NOT NULL COMMENT 'replication status',
  `replication_tstamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'replication timestamp'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='item type table';

--
-- Dumping data for table `itemtype`
--

INSERT INTO `itemtype` (`iditemtype`, `company_code`, `type_code`, `type_desc`, `create_date`, `create_time`, `create_by`, `replication_stat`, `replication_tstamp`) VALUES
(1, 'MC', 'S', 'Scrub Suits', '2026-04-14', '13:16:30.000000', '45', 1, '2026-04-14 05:16:46');

-- --------------------------------------------------------

--
-- Table structure for table `itemwear`
--

CREATE TABLE `itemwear` (
  `iditemwear` int NOT NULL,
  `company_code` varchar(3) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `wear_code` varchar(5) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `wear_desc` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `create_date` date DEFAULT NULL,
  `create_time` time(6) DEFAULT NULL,
  `create_by` varchar(25) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `replication_stat` int DEFAULT NULL,
  `replication_tstamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `itemwear`
--

INSERT INTO `itemwear` (`iditemwear`, `company_code`, `wear_code`, `wear_desc`, `create_date`, `create_time`, `create_by`, `replication_stat`, `replication_tstamp`) VALUES
(1, 'MC', 'PA', 'Pants', '2026-04-14', '13:16:44.000000', '45', 1, '2026-04-14 05:17:01'),
(2, 'MC', 'TO', 'Tops', '2026-04-14', '13:16:52.000000', '45', 1, '2026-04-14 05:17:08');

-- --------------------------------------------------------

--
-- Table structure for table `machine`
--

CREATE TABLE `machine` (
  `idmachine` int NOT NULL COMMENT 'record unique id',
  `company_code` varchar(2) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'company code',
  `model_code` varchar(99) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'model code',
  `mac_code` varchar(3) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'machine code',
  `model_desc` varchar(25) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'model description',
  `status` varchar(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'status',
  `create_date` date NOT NULL COMMENT 'record creation date',
  `create_time` time(6) NOT NULL COMMENT 'record creation time',
  `create_by` varchar(25) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'record created by',
  `replication_stat` int NOT NULL COMMENT 'replication status',
  `replication_tstamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'replication timestamp'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='machine table';

-- --------------------------------------------------------

--
-- Table structure for table `mpurchase_h`
--

CREATE TABLE `mpurchase_h` (
  `id` int NOT NULL,
  `company_code` varchar(2) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `mpurchase_id` int NOT NULL,
  `supplier_code` varchar(4) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `store_code` varchar(4) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `reference_no` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `dr_date` date NOT NULL,
  `delivery_date` date NOT NULL,
  `status` int NOT NULL,
  `remarks` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `create_date` date NOT NULL,
  `create_time` time(6) NOT NULL,
  `create_by` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `replication_stat` int NOT NULL,
  `replication_tstamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `mpurchase_l`
--

CREATE TABLE `mpurchase_l` (
  `id` int NOT NULL,
  `company_code` varchar(2) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `mpurchase_id` int NOT NULL,
  `row_count` int NOT NULL,
  `supplier_code` varchar(4) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `store_code` varchar(4) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `sku_code` varchar(12) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `qty` int NOT NULL,
  `unit_cost` decimal(10,2) NOT NULL,
  `printed` int NOT NULL,
  `create_date` date NOT NULL,
  `create_time` time(6) NOT NULL,
  `create_by` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `replication_stat` int NOT NULL,
  `replication_tstamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `parent_sku`
--

CREATE TABLE `parent_sku` (
  `idparent_sku` int NOT NULL,
  `company_code` varchar(2) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `parent_sku_code` varchar(9) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `gen_code` varchar(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `col_code` varchar(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `type_code` varchar(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `stylecat_code` varchar(2) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `stylevar_code` varchar(1) COLLATE utf8mb4_general_ci NOT NULL,
  `color_code` varchar(3) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `status` tinyint(1) DEFAULT NULL COMMENT 'status',
  `create_date` date NOT NULL COMMENT 'record creation date',
  `create_time` time(6) NOT NULL COMMENT 'record creation time',
  `create_by` varchar(25) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'record created by',
  `replication_stat` int NOT NULL COMMENT 'replication status',
  `replication_tstamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'replication timestamp'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `picklist`
--

CREATE TABLE `picklist` (
  `id` int NOT NULL,
  `company_code` varchar(2) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `store_code` varchar(4) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `reference_id` int NOT NULL,
  `sku_code` varchar(12) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `qty_picked` int NOT NULL,
  `item_loc` varchar(4) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `status` int NOT NULL,
  `create_date` date NOT NULL,
  `create_time` time(6) NOT NULL,
  `create_by` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `replication_stat` int NOT NULL,
  `replication_tstamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `po_receiving_h`
--

CREATE TABLE `po_receiving_h` (
  `id` int NOT NULL,
  `company_code` varchar(2) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `store_code` varchar(4) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `supplier_code` varchar(4) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `po_num` int NOT NULL,
  `dr_reference_no` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `delivery_date` date DEFAULT NULL,
  `remarks` varchar(299) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `create_date` date NOT NULL,
  `create_time` time(6) NOT NULL,
  `create_by` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `replication_stat` int NOT NULL,
  `replication_tstamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `po_receiving_l`
--

CREATE TABLE `po_receiving_l` (
  `id` int NOT NULL,
  `receiving_id` int NOT NULL,
  `company_code` varchar(2) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `store_code` varchar(4) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `supplier_code` varchar(4) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `po_num` int NOT NULL,
  `dr_reference_no` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `delivery_date` date DEFAULT NULL,
  `sku_code` varchar(12) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `received_qty` int DEFAULT NULL,
  `printed` int NOT NULL,
  `create_date` date NOT NULL,
  `create_time` time(6) NOT NULL,
  `create_by` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `replication_stat` int NOT NULL,
  `replication_tstamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `purchase_order_h`
--

CREATE TABLE `purchase_order_h` (
  `id` int NOT NULL,
  `company_code` varchar(2) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `store_code` varchar(4) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `supplier_code` varchar(4) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `po_num` int NOT NULL,
  `is_received` int NOT NULL,
  `first_date_delivered` date DEFAULT NULL,
  `status` int NOT NULL,
  `is_paid` int NOT NULL,
  `prepared_by` int NOT NULL,
  `approved_by` int DEFAULT NULL,
  `create_date` date NOT NULL COMMENT 'po creation date',
  `create_time` time(6) NOT NULL,
  `create_by` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `replication_stat` int NOT NULL,
  `replication_tstamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `purchase_order_l`
--

CREATE TABLE `purchase_order_l` (
  `id` int NOT NULL,
  `company_code` varchar(2) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `store_code` varchar(4) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `supplier_code` varchar(4) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `po_num` int NOT NULL,
  `row_count` int NOT NULL,
  `sku_code` varchar(12) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `qty` int NOT NULL,
  `received_qty` int DEFAULT NULL,
  `po_unit_cost` decimal(10,2) NOT NULL,
  `unit_cost` decimal(10,2) DEFAULT NULL,
  `status` int NOT NULL,
  `is_in_po` int NOT NULL,
  `printed` int NOT NULL,
  `create_date` date NOT NULL,
  `create_time` time(6) NOT NULL,
  `create_by` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `replication_stat` int NOT NULL,
  `replication_tstamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `season`
--

CREATE TABLE `season` (
  `idseason` int NOT NULL COMMENT 'record unique id',
  `company_code` varchar(2) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'company code',
  `season_code` varchar(3) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'season code',
  `season description` varchar(25) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'season description',
  `status` varchar(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'status',
  `create_date` date NOT NULL COMMENT 'record creation date',
  `create_time` time(6) NOT NULL COMMENT 'record creation time',
  `create_by` varchar(25) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'record created by',
  `replication_stat` int NOT NULL COMMENT 'replication status',
  `replication_tstamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'replication timestamp'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='season table';

-- --------------------------------------------------------

--
-- Table structure for table `size`
--

CREATE TABLE `size` (
  `idsize` int NOT NULL COMMENT 'record unique id',
  `company_code` varchar(2) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'company code',
  `size_code` varchar(3) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'size code',
  `size_desc` varchar(25) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'size description',
  `create_date` date NOT NULL COMMENT 'record creation date',
  `create_time` time(6) NOT NULL COMMENT 'record creation time',
  `create_by` varchar(25) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'record created by',
  `replication_stat` int NOT NULL COMMENT 'replication status',
  `replication_tstamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'replication timestamp'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='size table';

-- --------------------------------------------------------

--
-- Table structure for table `store`
--

CREATE TABLE `store` (
  `id` int NOT NULL,
  `company_code` varchar(2) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `store_code` varchar(6) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `store_desc` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `store_addr` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `store_email` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `store_ip_addr` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `store_contact_no` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `create_date` date NOT NULL,
  `create_time` time(6) NOT NULL,
  `create_by` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `replication_stat` int NOT NULL,
  `replication_tstamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `store`
--

INSERT INTO `store` (`id`, `company_code`, `store_code`, `store_desc`, `store_addr`, `store_email`, `store_ip_addr`, `store_contact_no`, `create_date`, `create_time`, `create_by`, `replication_stat`, `replication_tstamp`) VALUES
(1, 'M2', 'MAIN', 'M28 Main (Tagapo, Santa Rosa)', '#23 Brgy. Tagapo, Santa Rosa, Laguna, Philippines 4026', 'm28main@email.com', '192.168.70.201', '+63 946 063 7192', '2025-07-01', '13:28:23.346000', '36', 1, '2025-10-28 00:21:47'),
(2, 'M2', 'ECOM', 'M28 Ecom', '#23 Brgy. Tagapo, Santa Rosa, Laguna, Philippines 4026', 'm28ecom@email.com', '192.168.70.201', '+63 946 063 7192', '2025-07-01', '13:28:23.346000', '36', 1, '2025-09-22 07:43:14'),
(3, 'M2', 'SUB1', 'Nasugbu Branch', 'Nasugbu Batangas', 'm28nasugbu@email.com', '192.168.70.201', '09123456789', '2025-07-01', '13:28:23.346000', '36', 1, '2025-08-05 06:14:26'),
(4, 'MC', 'ECOM', 'Medical Coat Plus Ecom', '#23 Brgy. Tagapo, Santa Rosa, Laguna, Philippines 4026', 'm28ecom@email.com', '192.168.70.201', '+63 946 063 7192', '2025-07-01', '13:28:23.346000', '36', 1, '2026-03-26 23:20:27'),
(5, 'MC', 'MAIN', 'Medical Coat Plus Main (Tagapo, Santa Rosa)', '#23 Brgy. Tagapo, Santa Rosa, Laguna, Philippines 4026', 'm28main@email.com', '192.168.70.201', '+63 946 063 7192', '2025-07-01', '13:28:23.346000', '36', 1, '2025-10-28 00:21:47');

-- --------------------------------------------------------

--
-- Table structure for table `supplier`
--

CREATE TABLE `supplier` (
  `id` int NOT NULL,
  `company_code` varchar(2) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `supplier_code` varchar(4) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `supplier_desc` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `supplier_tin` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `supplier_addr` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `supplier_contact` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `supplier_email` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `payment_terms` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `create_date` date NOT NULL,
  `create_time` time(6) NOT NULL,
  `create_by` varchar(25) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `replication_stat` int NOT NULL,
  `replication_tstamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `supplier`
--

INSERT INTO `supplier` (`id`, `company_code`, `supplier_code`, `supplier_desc`, `supplier_tin`, `supplier_addr`, `supplier_contact`, `supplier_email`, `payment_terms`, `create_date`, `create_time`, `create_by`, `replication_stat`, `replication_tstamp`) VALUES
(1, 'MC', 'MC', 'Michael Capul', '0000', 'Tagapo', '0234234234', '234234', '60', '2026-04-08', '13:07:56.000000', '45', 1, '2026-04-08 05:08:00');

-- --------------------------------------------------------

--
-- Table structure for table `tranauth`
--

CREATE TABLE `tranauth` (
  `idtranauth` int NOT NULL COMMENT 'record unique id',
  `company_code` varchar(2) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'company code',
  `authority_code` varchar(3) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'authority code',
  `mvt_code` varchar(3) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'movement code\r\n',
  `status` varchar(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'status',
  `create_date` date NOT NULL COMMENT 'record creation date',
  `create_time` time(6) NOT NULL COMMENT 'record creation time',
  `create_by` varchar(25) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'record created by',
  `replication_stat` int NOT NULL COMMENT 'replication status',
  `replication_tstamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'replication timestamp'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='transaction authorization table';

--
-- Dumping data for table `tranauth`
--

INSERT INTO `tranauth` (`idtranauth`, `company_code`, `authority_code`, `mvt_code`, `status`, `create_date`, `create_time`, `create_by`, `replication_stat`, `replication_tstamp`) VALUES
(1, 'M2', 'STK', 'D00', '1', '2025-01-20', '09:28:38.000069', 'admin', 0, '2025-01-20 01:29:24'),
(2, 'M2', 'STK', 'D11', '1', '2025-01-20', '09:30:54.000040', 'admin', 0, '2025-01-20 01:32:16'),
(3, 'M2', 'STK', 'D33', '1', '2025-01-20', '09:32:39.000069', 'admin', 0, '2025-01-20 01:33:19'),
(4, 'M2', 'ADM', 'D00', '1', '2025-01-20', '09:33:25.000128', 'admin', 0, '2025-01-20 01:34:20'),
(5, 'M2', 'ADM', 'D11', '1', '2025-01-20', '09:34:22.000040', 'admin', 0, '2025-01-20 01:34:49'),
(6, 'M2', 'ADM', 'D22', '1', '2025-01-20', '09:34:51.000040', 'admin', 0, '2025-01-20 01:35:28'),
(7, 'M2', 'ADM', 'D33', '1', '2025-01-20', '09:35:33.000059', 'admin', 0, '2025-01-20 01:36:05'),
(8, 'M2', 'ADM', 'D88', '1', '2025-01-20', '09:36:09.000089', 'admin', 0, '2025-01-20 01:36:27'),
(9, 'M2', 'CAS', 'D22', '1', '2025-01-20', '10:29:54.000158', 'admin', 0, '2025-01-20 02:30:33'),
(10, 'M2', 'CAS', 'D88', '1', '2025-01-20', '10:30:35.000040', 'admin', 0, '2025-01-20 02:30:55');

-- --------------------------------------------------------

--
-- Table structure for table `tranmvt`
--

CREATE TABLE `tranmvt` (
  `idtranmvt` int NOT NULL COMMENT 'record unique id',
  `company_code` varchar(2) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'company code',
  `mvt_code` varchar(3) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'movement code',
  `stk_from` varchar(3) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'stockpoint from',
  `stk_to` varchar(3) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'stockpoint to',
  `mvt_desc` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'movement description',
  `status` varchar(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'status',
  `create_date` date NOT NULL COMMENT 'record creation date',
  `create_time` time(6) NOT NULL COMMENT 'record creation time',
  `create_by` varchar(25) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'record created by',
  `replication_stat` int NOT NULL COMMENT 'replication status',
  `replication_tstamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'replication timestamp'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='transaction movement table';

--
-- Dumping data for table `tranmvt`
--

INSERT INTO `tranmvt` (`idtranmvt`, `company_code`, `mvt_code`, `stk_from`, `stk_to`, `mvt_desc`, `status`, `create_date`, `create_time`, `create_by`, `replication_stat`, `replication_tstamp`) VALUES
(1, 'M2', 'D00', 'SUP', 'INV', 'supplier to inventory movement', '1', '2025-01-20', '09:08:19.000049', 'admin', 0, '2025-01-20 01:13:33'),
(2, 'M2', 'D11', 'WHS', 'WHS', 'warehouse to warehouse movement', '1', '2025-01-20', '09:13:58.000059', 'admin', 0, '2025-01-20 01:18:14'),
(3, 'M2', 'D22', 'INV', 'SAL', 'inventory to sales movement', '1', '2025-01-20', '09:18:48.000030', 'admin', 0, '2025-01-20 01:19:51'),
(4, 'M2', 'D33', 'RAK', 'RAK', 'rack to rack movement', '1', '2025-01-20', '09:19:55.000040', 'admin', 0, '2025-01-20 01:21:23'),
(5, 'M2', 'D88', 'SAL', 'RET', 'return movement', '1', '2025-01-20', '09:21:28.000040', 'admin', 0, '2025-01-20 01:22:57');

-- --------------------------------------------------------

--
-- Table structure for table `transfer_h`
--

CREATE TABLE `transfer_h` (
  `id` int NOT NULL,
  `company_code` varchar(2) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `store_code_origin` varchar(4) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `store_code_dest` varchar(4) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `dr` int NOT NULL,
  `status` int NOT NULL,
  `remarks` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `approved_timestamp` timestamp NULL DEFAULT NULL,
  `received_timestamp` timestamp NULL DEFAULT NULL,
  `create_date` date NOT NULL,
  `create_time` time(6) NOT NULL,
  `create_by` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `replication_stat` int NOT NULL,
  `replication_tstamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `transfer_l`
--

CREATE TABLE `transfer_l` (
  `id` int NOT NULL,
  `company_code` varchar(2) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `store_code_origin` varchar(4) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `store_code_dest` varchar(4) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `dr` int NOT NULL,
  `itemloc_origin` varchar(6) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `itemloc_dest` varchar(6) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `row_count` int NOT NULL,
  `sku_code` varchar(12) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `qty` int NOT NULL,
  `approved_qty` int NOT NULL,
  `received_qty` int DEFAULT NULL,
  `status` varchar(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `received_timestamp` timestamp NULL DEFAULT NULL,
  `create_date` date NOT NULL,
  `create_time` time(6) NOT NULL,
  `create_by` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `replication_stat` int NOT NULL,
  `replication_tstamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `variation`
--

CREATE TABLE `variation` (
  `idvar` int NOT NULL,
  `company_code` varchar(2) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `parent_sku_code` varchar(9) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `var_code` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `variant` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `img_url` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `create_date` date DEFAULT NULL,
  `create_time` time(6) DEFAULT NULL,
  `create_by` varchar(25) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `replication_stat` int DEFAULT NULL,
  `replication_tstamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `item`
--
ALTER TABLE `item`
  ADD PRIMARY KEY (`iditem`),
  ADD KEY `fk_item_brand` (`company_code`);

--
-- Indexes for table `itembal`
--
ALTER TABLE `itembal`
  ADD PRIMARY KEY (`iditembal`);

--
-- Indexes for table `itemcat`
--
ALTER TABLE `itemcat`
  ADD PRIMARY KEY (`iditemcat`);

--
-- Indexes for table `itemcol`
--
ALTER TABLE `itemcol`
  ADD PRIMARY KEY (`iditemcol`);

--
-- Indexes for table `itemcolor`
--
ALTER TABLE `itemcolor`
  ADD PRIMARY KEY (`idbrand`),
  ADD UNIQUE KEY `uq_idbrand` (`idbrand`),
  ADD UNIQUE KEY `uq_brand` (`company_code`,`color_code`);

--
-- Indexes for table `itemgen`
--
ALTER TABLE `itemgen`
  ADD PRIMARY KEY (`iditemgen`);

--
-- Indexes for table `itemloc`
--
ALTER TABLE `itemloc`
  ADD PRIMARY KEY (`iditemloc`),
  ADD UNIQUE KEY `unique_location` (`company_code`,`loc_code`);

--
-- Indexes for table `itemmvt`
--
ALTER TABLE `itemmvt`
  ADD PRIMARY KEY (`iditemmvt`);

--
-- Indexes for table `itemprice`
--
ALTER TABLE `itemprice`
  ADD PRIMARY KEY (`iditemprice`);

--
-- Indexes for table `itemstylecat`
--
ALTER TABLE `itemstylecat`
  ADD PRIMARY KEY (`idstylecat`);

--
-- Indexes for table `itemstylevar`
--
ALTER TABLE `itemstylevar`
  ADD PRIMARY KEY (`idstylevar`);

--
-- Indexes for table `itemtype`
--
ALTER TABLE `itemtype`
  ADD PRIMARY KEY (`iditemtype`);

--
-- Indexes for table `itemwear`
--
ALTER TABLE `itemwear`
  ADD PRIMARY KEY (`iditemwear`);

--
-- Indexes for table `machine`
--
ALTER TABLE `machine`
  ADD PRIMARY KEY (`idmachine`);

--
-- Indexes for table `mpurchase_h`
--
ALTER TABLE `mpurchase_h`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `mpurchase_l`
--
ALTER TABLE `mpurchase_l`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `parent_sku`
--
ALTER TABLE `parent_sku`
  ADD PRIMARY KEY (`idparent_sku`);

--
-- Indexes for table `picklist`
--
ALTER TABLE `picklist`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `po_receiving_h`
--
ALTER TABLE `po_receiving_h`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `po_receiving_l`
--
ALTER TABLE `po_receiving_l`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `purchase_order_h`
--
ALTER TABLE `purchase_order_h`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `purchase_order_l`
--
ALTER TABLE `purchase_order_l`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `season`
--
ALTER TABLE `season`
  ADD PRIMARY KEY (`idseason`);

--
-- Indexes for table `size`
--
ALTER TABLE `size`
  ADD PRIMARY KEY (`idsize`);

--
-- Indexes for table `store`
--
ALTER TABLE `store`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `supplier`
--
ALTER TABLE `supplier`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `tranauth`
--
ALTER TABLE `tranauth`
  ADD PRIMARY KEY (`idtranauth`);

--
-- Indexes for table `tranmvt`
--
ALTER TABLE `tranmvt`
  ADD PRIMARY KEY (`idtranmvt`);

--
-- Indexes for table `transfer_h`
--
ALTER TABLE `transfer_h`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `transfer_l`
--
ALTER TABLE `transfer_l`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `variation`
--
ALTER TABLE `variation`
  ADD PRIMARY KEY (`idvar`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `item`
--
ALTER TABLE `item`
  MODIFY `iditem` int NOT NULL AUTO_INCREMENT COMMENT 'record unique id';

--
-- AUTO_INCREMENT for table `itembal`
--
ALTER TABLE `itembal`
  MODIFY `iditembal` int NOT NULL AUTO_INCREMENT COMMENT 'record unique id';

--
-- AUTO_INCREMENT for table `itemcat`
--
ALTER TABLE `itemcat`
  MODIFY `iditemcat` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT for table `itemcol`
--
ALTER TABLE `itemcol`
  MODIFY `iditemcol` int NOT NULL AUTO_INCREMENT COMMENT 'record unique id', AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `itemcolor`
--
ALTER TABLE `itemcolor`
  MODIFY `idbrand` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=23;

--
-- AUTO_INCREMENT for table `itemgen`
--
ALTER TABLE `itemgen`
  MODIFY `iditemgen` int NOT NULL AUTO_INCREMENT COMMENT 'record unique id', AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `itemloc`
--
ALTER TABLE `itemloc`
  MODIFY `iditemloc` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `itemmvt`
--
ALTER TABLE `itemmvt`
  MODIFY `iditemmvt` int NOT NULL AUTO_INCREMENT COMMENT 'record unique id';

--
-- AUTO_INCREMENT for table `itemprice`
--
ALTER TABLE `itemprice`
  MODIFY `iditemprice` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `itemstylecat`
--
ALTER TABLE `itemstylecat`
  MODIFY `idstylecat` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `itemstylevar`
--
ALTER TABLE `itemstylevar`
  MODIFY `idstylevar` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `itemtype`
--
ALTER TABLE `itemtype`
  MODIFY `iditemtype` int NOT NULL AUTO_INCREMENT COMMENT 'record unique id', AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `itemwear`
--
ALTER TABLE `itemwear`
  MODIFY `iditemwear` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `machine`
--
ALTER TABLE `machine`
  MODIFY `idmachine` int NOT NULL AUTO_INCREMENT COMMENT 'record unique id';

--
-- AUTO_INCREMENT for table `mpurchase_h`
--
ALTER TABLE `mpurchase_h`
  MODIFY `id` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `mpurchase_l`
--
ALTER TABLE `mpurchase_l`
  MODIFY `id` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `parent_sku`
--
ALTER TABLE `parent_sku`
  MODIFY `idparent_sku` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `picklist`
--
ALTER TABLE `picklist`
  MODIFY `id` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `po_receiving_l`
--
ALTER TABLE `po_receiving_l`
  MODIFY `id` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `purchase_order_h`
--
ALTER TABLE `purchase_order_h`
  MODIFY `id` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `purchase_order_l`
--
ALTER TABLE `purchase_order_l`
  MODIFY `id` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `season`
--
ALTER TABLE `season`
  MODIFY `idseason` int NOT NULL AUTO_INCREMENT COMMENT 'record unique id';

--
-- AUTO_INCREMENT for table `size`
--
ALTER TABLE `size`
  MODIFY `idsize` int NOT NULL AUTO_INCREMENT COMMENT 'record unique id';

--
-- AUTO_INCREMENT for table `store`
--
ALTER TABLE `store`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `supplier`
--
ALTER TABLE `supplier`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `tranauth`
--
ALTER TABLE `tranauth`
  MODIFY `idtranauth` int NOT NULL AUTO_INCREMENT COMMENT 'record unique id', AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `tranmvt`
--
ALTER TABLE `tranmvt`
  MODIFY `idtranmvt` int NOT NULL AUTO_INCREMENT COMMENT 'record unique id', AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `transfer_h`
--
ALTER TABLE `transfer_h`
  MODIFY `id` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `transfer_l`
--
ALTER TABLE `transfer_l`
  MODIFY `id` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `variation`
--
ALTER TABLE `variation`
  MODIFY `idvar` int NOT NULL AUTO_INCREMENT;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `item`
--
ALTER TABLE `item`
  ADD CONSTRAINT `fk_item_company` FOREIGN KEY (`company_code`) REFERENCES `audit_db`.`company` (`company_code`);

--
-- Constraints for table `itemcolor`
--
ALTER TABLE `itemcolor`
  ADD CONSTRAINT `fk_brand_company` FOREIGN KEY (`company_code`) REFERENCES `audit_db`.`company` (`company_code`);

DELIMITER $$
--
-- Events
--
CREATE DEFINER=`bst1`@`%` EVENT `ev_insert_itembal_0020` ON SCHEDULE EVERY 1 DAY STARTS '2026-03-18 00:20:00' ON COMPLETION NOT PRESERVE ENABLE DO BEGIN
    CALL sp_insert_itembal_all_stores();
END$$

CREATE DEFINER=`bst1`@`%` EVENT `ev_insert_itemprice_0010` ON SCHEDULE EVERY 1 DAY STARTS '2026-03-18 00:10:00' ON COMPLETION NOT PRESERVE ENABLE DO BEGIN
    CALL sp_insert_itemprice_all_stores();
END$$

CREATE DEFINER=`bst1`@`%` EVENT `ev_insert_items_midnight` ON SCHEDULE EVERY 1 DAY STARTS '2026-03-18 00:00:00' ON COMPLETION NOT PRESERVE ENABLE DO BEGIN
    CALL sp_insert_items_from_variation();
END$$

DELIMITER ;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
