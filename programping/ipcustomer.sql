-- phpMyAdmin SQL Dump
-- version 4.4.14
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Dec 11, 2017 at 07:32 AM
-- Server version: 5.6.26
-- PHP Version: 5.6.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `ipcustomer`
--

-- --------------------------------------------------------

--
-- Table structure for table `customer`
--

CREATE TABLE IF NOT EXISTS `customer` (
  `Id_cust` int(20) NOT NULL,
  `Nama` varchar(100) NOT NULL,
  `Ip` varchar(15) NOT NULL,
  `Status` varchar(20) NOT NULL,
  `kategori` int(10) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=91 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `customer`
--

INSERT INTO `customer` (`Id_cust`, `Nama`, `Ip`, `Status`, `kategori`) VALUES
(1, 'Bentoel Pamekasan', 'google.com', 'lancar', 1),
(2, 'Bentoel Secang Magelang', '192.168.107.46', 'putus', 1),
(3, 'Bentoel Bypass Baru Pauh Padang', '192.168.107.50', 'putus', 1),
(4, 'Samsat Bangil, Jl.Kartini 34 Bangil', '172.26.69.99', 'putus', 2),
(5, 'Samsat Probolinggo Kraksan Jl. Dr. Saleh', '172.243.54.158', 'putus', 2),
(6, 'Kantor Bersama Samsat Mojokerto, Jl. Jayanegara 98 Mojokerto', '172.243.54.110', 'putus', 2),
(7, 'Kantor Bersama Samsat Malang Kota, Jl.S.Supriadi/ Jl.Kebonsari 80 Malang', '172.243.54.54', 'putus', 2),
(8, 'Samsat Probolinggo, Jl. Basuki Rahmat 11 Probolinggo', '172.243.54.150', 'putus', 2),
(9, 'Kantor Bersama Samsat Malang Selatan', '172.243.54.50', 'intermittent', 2),
(10, 'Kantor Bersama Samsat Banyuwangi Kota', '172.243.54.10', 'lancar', 2),
(11, 'Samsat Pasuruan Kota Jl.Sultan Agung 80', '172.26.64.11', 'lancar', 2),
(12, 'Samsat Tulungagung', '172.243.54.122', 'lancar', 2),
(13, 'Kantor Bersama Samsat Malang Batu', '172.243.54.162', 'lancar', 2),
(14, 'Karntor Bersama Samsat Madiun Kabupaten', '172.243.54.90', 'lancar', 2),
(15, 'Samsat Madiun Kota, Jl. Serayu Madiun', '172.243.54.86', 'lancar', 2),
(16, 'Samsat Surabaya Selatan Jl. Ketintang Seraten', '172.243.54.70', 'lancar', 2),
(17, 'Kantor Bersama Samsat Gresik, Jl. Dr. Wahidin 460 Gresik', '172.243.54.78', 'lancar', 2),
(18, 'Kantor Samsat Jombang', '172.243.54.14', 'lancar', 2),
(19, 'Meratus Teluk Kumai Surabaya', '172.15.0.6', 'lancar', 3),
(20, 'Meratus Depo Medan', '172.15.0.38', 'intermittent', 3),
(21, 'Bentoel Jember', '172.15.20.14', 'lancar', 1),
(22, 'Bentoel Bondowoso', '192.168.107.194', 'lancar', 1),
(23, 'Bentoel Probolinggo', '192.168.107.74', 'lancar', 1),
(24, 'Bentoel Kepanjen', '172.15.20.6', 'lancar', 1),
(25, 'Bentoel RanduAgung Malang', '172.15.21.6', 'lancar', 1),
(26, 'Bentoel Yonkaf Malang', '172.15.21.6', 'lancar', 1),
(27, 'Bentoel KebonAgung Malang', '192.168.107.186', 'lancar', 1),
(28, 'Bentoel Genengan Malang', '192.168.107.222', 'lancar', 1),
(29, 'Bentoel Kacapiring', '192.168.107.126', 'lancar', 1),
(30, 'Bentoel Kalianyar Bojonegoro', '192.168.107.190', 'lancar', 1),
(31, 'Bentoel Asmo Jombang', '172.15.20.38', 'lancar', 1),
(32, 'Bentoel Satya Dharma Lamongan', '192.168.200.14', 'lancar', 1),
(33, 'Bentoel Asmo Samarinda', '192.168.109.14', 'lancar', 1),
(34, 'Bentoel Banyumas', '10.170.193.174', 'lancar', 1),
(35, 'Bentoel Semarang', '172.15.20.2', 'lancar', 1),
(36, 'Bentoel Bandung Rajawali', '172.15.20.42', 'lancar', 1),
(37, 'Bentoel Tasikmalaya', '172.15.20.25', 'lancar', 1),
(38, 'Bentoel Cirebon', '172.50.12.2', 'lancar', 1),
(39, 'Bentoel Sukabumi', '192.168.107.22', 'lancar', 1),
(40, 'Bentoel Tanjung Api2 Palembang', '192.168.107.82', 'lancar', 1),
(41, 'Bentoel Pasar Minggu', '192.168.107.26', 'lancar', 1),
(42, 'Bentoel Cimanggis', '192.168.12.9', 'lancar', 1),
(43, 'Bentoel Serang', '192.168.107.34', 'lancar', 1),
(44, 'Bentoel Imam Bonjol Denpasar', '192.168.107.54', 'lancar', 1),
(45, 'Bentoel ASMO Manado', '192.168.107.118', 'lancar', 1),
(46, 'Bentoel Palu', '192.168.107.106', 'lancar', 1),
(47, 'Bentoel Gagak Hitam Medan', '192.168.6.238', 'lancar', 1),
(48, 'Bentoel Asmo Pematang Siantar', '192.168.107.18', 'lancar', 1),
(49, 'Bentoel Cakranegara', '172.15.20.34', 'lancar', 1),
(50, 'Bentoel Bandar Lampung', '192.168.107.30', 'lancar', 1),
(51, 'Bentoel Bojonegoro', '172.115.20.18', 'lancar', 1),
(52, 'Bentoel Sujono Malang', '192.168.107.150', 'lancar', 1),
(53, 'Bentoel Sunter', '192.168.107.38', 'lancar', 1),
(54, 'Bentoel Padang Sidempuan', '192.168.107.90', 'lancar', 1),
(55, 'Bentoel Pekanbaru', '192.168.107.6', 'lancar', 1),
(56, 'Bentoel Jl.Agus Salim No.8 Banyuwangi', '192.168.107.66', 'lancar', 1),
(57, 'Bentoel Cipondoh', '192.168.107.122', 'lancar', 1),
(58, 'Bentoel Lhokseumawe', '192.168.107.174', 'lancar', 1),
(59, 'Bentoel Bambu Kuning Selatan Bekasi', '192.168.12.5', 'lancar', 1),
(60, 'Bentoel Hok Jambi', '192.168.107.114', 'putus', 1),
(61, 'Dispenda Jatim Jalan Ahmad Yani No. 116 Surabaya (Ruang BPKB Polda Jawa Timur)', '172.243.54.6', 'lancar', 2),
(62, 'Kantor Bersama Samsat Blitar Kota, Jl.Melati 17 Blitar', '172.243.54.38', 'putus', 2),
(63, 'Kantor Bersama Samsat Blitar Kabupaten, Jl.Kenongo 43 Wlingi Blitar', '172.26.58.4', 'putus', 2),
(64, 'Corner Grand City Mall, Lantai 2 No. 46 Surabaya', '172.27.14.131', 'putus', 2),
(65, 'Kantor Bersama Samsat Malang Karang Ploso', '172.243.54.30', 'putus', 2),
(66, 'Dispenda Jatim Malang Kota Jl.S.Supriyadi 80 malang', '172.27.61.116', 'putus', 2),
(67, 'Payment point Srengat, Jl.Raya Srengat Blitar', '172.27.53.138', 'putus', 2),
(68, 'Kantor Bersama Samsat Payment Point Alun-Alun Banyuwangi', '172.27.75.130', 'putus', 2),
(69, 'Payment Point Kanigoro, Jl.Manokwari 22 Kanigoro Blitar', '172.27.53.130', 'putus', 2),
(70, 'Payment Point Caruban, Jalan Madiun-Surabaya Balerejo Caruban', '172.27.42.130', 'putus', 2),
(71, 'Drive Thru Bunder Gresik', '172.27.21.130', 'putus', 2),
(72, 'Corner Royal Royal Plaza CS', '172.27.15.130', 'lancar', 2),
(73, 'Samsat Corner MOG Mall Olympic Garden Lt.2 Kawi Malang', '172.27.61.130', 'lancar', 2),
(74, 'Kantor Bersama Samsat Malang Kota, Jl.S.Supriyadi / Jl.Kebonsari 80 Malang', '172.243.54.54', 'lancar', 2),
(75, 'Meratus Padang', '172.15.0.42', 'lancar', 3),
(76, 'Meratus Teluk Kumai Surabaya', '172.15.0.6', 'lancar', 3),
(77, 'Meratus Office Jl.Nusantara No.26 Ujung Pandang', '172.19.0.2', 'lancar', 3),
(78, 'Meratus Masakasar Depo Soekarno Jl. Soekarno Hatta', '172.19.0.6', 'lancar', 3),
(79, 'Depo Tanjung Batu Surabaya', '172.15.0.14', 'lancar', 3),
(80, 'Meratus Line Komp. Wildan Banjarmasin', '172.18.0.2', 'lancar', 3),
(81, 'Meratus Depo Medan', '172.15.0.38', 'lancar', 3),
(82, 'Meratus Line Depo Prapat Kurung Surabaya', '172.15.0.10', 'lancar', 3),
(83, 'MIF Ikan Dorang Surabaya', '172.15.0.22', 'lancar', 3),
(84, 'Meratus Jl. Enggano Raya No.5. O/N Jakarta Utara', '172.20.0.2', 'lancar', 3),
(85, 'Meratus Depo Banjarmasin', '172.18.0.10', 'lancar', 3),
(86, 'Meratus Line Jl. Raya Cilincing Kel Semper Barat Jakarta Utara', '172.18.40.2', 'lancar', 3),
(87, 'Meratus Depo Bali', '172.17.0.6', 'lancar', 3),
(88, 'Meratus Jl. RE. Martadinata No.100 Komplek Martadinata Megah Blok D No.11', '172.20.0.6', 'lancar', 3),
(89, 'Meratus Jl. Tol Ir.Sutami Sungai Tallo Makasar', '172.18.0.18', 'lancar', 3),
(90, 'Meratus Tanjung Tembaga Surabaya', '172.15.0.30', 'lancar', 3);

-- --------------------------------------------------------

--
-- Table structure for table `history`
--

CREATE TABLE IF NOT EXISTS `history` (
  `Id_hist` int(20) NOT NULL,
  `Id_cust` varchar(100) NOT NULL,
  `Status_Network` varchar(30) NOT NULL,
  `Tanggal_Waktu` datetime NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `history`
--

INSERT INTO `history` (`Id_hist`, `Id_cust`, `Status_Network`, `Tanggal_Waktu`) VALUES
(1, 'Bentoel Pamekasan', '41ms telah diperbaiki', '2017-09-11 14:00:15'),
(2, 'Bentoel Pamekasan', '101ms telah diperbaiki', '2017-09-11 14:02:00'),
(3, 'Bentoel Secang Magelang', '47ms telah diperbaiki', '2017-09-11 14:02:19'),
(4, 'Bentoel Secang Magelang', 'menjadi putus', '2017-09-11 14:02:26'),
(5, 'Bentoel Pamekasan', '36ms telah diperbaiki', '2017-09-11 14:04:09'),
(6, 'Bentoel Pamekasan', '40ms telah diperbaiki', '2017-09-11 14:05:14'),
(7, 'Bentoel Pamekasan', '31ms telah diperbaiki', '2017-09-11 14:14:22'),
(8, 'Bentoel Pamekasan', '31ms telah diperbaiki', '2017-09-11 14:15:46'),
(9, 'Bentoel Pamekasan', '31ms telah diperbaiki', '2017-09-11 14:17:34'),
(10, 'Bentoel Pamekasan', '33ms telah diperbaiki', '2017-09-11 14:18:12'),
(11, 'Bentoel Pamekasan', '29ms telah diperbaiki', '2017-09-11 14:19:05'),
(12, 'Bentoel Pamekasan', 'menjadi putus', '2017-09-11 14:20:14'),
(13, 'Bentoel Pamekasan', 'menjadi putus', '2017-09-11 14:40:53'),
(14, 'Bentoel Pamekasan', 'menjadi putus', '2017-09-11 14:45:03'),
(15, 'Bentoel Bypass Baru Pauh Padang', 'menjadi putus', '2017-09-11 14:45:19'),
(16, 'Bentoel Pamekasan', 'menjadi putus', '2017-09-11 14:48:35'),
(17, 'Bentoel Pamekasan', 'menjadi putus', '2017-09-11 14:49:58'),
(18, 'Bentoel Pamekasan', 'menjadi putus', '2017-09-11 14:52:08'),
(19, 'Bentoel Pamekasan', 'menjadi putus', '2017-09-11 14:53:57'),
(20, 'Bentoel Pamekasan', 'menjadi putus', '2017-09-11 15:06:07'),
(21, 'Bentoel Pamekasan', 'menjadi putus', '2017-09-11 15:09:28'),
(22, 'Bentoel Pamekasan', 'menjadi putus', '2017-09-11 15:39:43'),
(23, 'Kantor Bersama Samsat Malang Kota, Jl.S.Supriadi/ Jl.Kebonsari 80 Malang', 'menjadi putus', '2017-09-11 15:40:24'),
(24, 'Bentoel Pamekasan', 'menjadi putus', '2017-09-11 15:48:07'),
(25, 'Bentoel Pamekasan', 'menjadi putus', '2017-09-11 16:04:04'),
(26, 'Samsat Bangil, Jl.Kartini 34 Bangil', 'menjadi putus', '2017-09-11 16:04:41'),
(27, 'Samsat Probolinggo, Jl. Basuki Rahmat 11 Probolinggo', 'menjadi putus', '2017-09-11 16:05:24');

-- --------------------------------------------------------

--
-- Table structure for table `teknisi`
--

CREATE TABLE IF NOT EXISTS `teknisi` (
  `id_teknisi` int(20) NOT NULL,
  `Nama` varchar(30) NOT NULL,
  `No_telepon` varchar(13) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `teknisi`
--

INSERT INTO `teknisi` (`id_teknisi`, `Nama`, `No_telepon`) VALUES
(1, 'Adi', '089648890123'),
(2, 'Rangga', '089648890111'),
(3, 'Buyung', '089648890111'),
(4, 'Manajer 2', '089648890111'),
(5, 'Teknisi 5', '089648890111'),
(6, 'Teknisi 11', '089648890111'),
(7, 'asd', '089648890111'),
(8, 'dfg', '082245332242'),
(9, '', ''),
(10, '', ''),
(11, '', ''),
(12, '', ''),
(13, '', ''),
(14, '', ''),
(15, '', ''),
(16, '', ''),
(17, '', ''),
(18, '', ''),
(19, '', ''),
(20, '', '');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `customer`
--
ALTER TABLE `customer`
  ADD PRIMARY KEY (`Id_cust`),
  ADD KEY `Id_cust` (`Id_cust`);

--
-- Indexes for table `history`
--
ALTER TABLE `history`
  ADD PRIMARY KEY (`Id_hist`);

--
-- Indexes for table `teknisi`
--
ALTER TABLE `teknisi`
  ADD PRIMARY KEY (`id_teknisi`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `customer`
--
ALTER TABLE `customer`
  MODIFY `Id_cust` int(20) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=91;
--
-- AUTO_INCREMENT for table `history`
--
ALTER TABLE `history`
  MODIFY `Id_hist` int(20) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=28;
--
-- AUTO_INCREMENT for table `teknisi`
--
ALTER TABLE `teknisi`
  MODIFY `id_teknisi` int(20) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=21;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
