-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Máy chủ: 127.0.0.1
-- Thời gian đã tạo: Th6 18, 2022 lúc 07:03 AM
-- Phiên bản máy phục vụ: 10.4.24-MariaDB
-- Phiên bản PHP: 8.1.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Cơ sở dữ liệu: `railway`
--
CREATE DATABASE IF NOT EXISTS `railway` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `railway`;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `disprice`
--

CREATE TABLE `disprice` (
  `id` int(11) NOT NULL,
  `Source` varchar(20) NOT NULL,
  `Destination` varchar(20) NOT NULL,
  `Price` decimal(15,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Đang đổ dữ liệu cho bảng `disprice`
--

INSERT INTO `disprice` (`id`, `Source`, `Destination`, `Price`) VALUES
(1, 'HOCHIMINH', 'HUE', '10050.00'),
(2, 'HOCHIMINH', 'HANOI', '17190.00'),
(3, 'HUE', 'HANOI', '6680.00'),
(4, 'HUE', 'HOCHIMINH', '10050.00'),
(5, 'HANOI', 'HOCHIMINH', '17190.00'),
(6, 'HANOI', 'HUE', '6680.00');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `logindetails`
--

CREATE TABLE `logindetails` (
  `UserID` int(11) NOT NULL,
  `Email` varchar(40) NOT NULL,
  `Username` varchar(30) NOT NULL,
  `Password` varchar(20) NOT NULL,
  `Name` varchar(30) NOT NULL,
  `DateOfBirth` datetime NOT NULL,
  `Gender` bit(1) NOT NULL,
  `PhoneNo` varchar(15) NOT NULL,
  `Role` bit(1) NOT NULL DEFAULT b'0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Đang đổ dữ liệu cho bảng `logindetails`
--

INSERT INTO `logindetails` (`UserID`, `Email`, `Username`, `Password`, `Name`, `DateOfBirth`, `Gender`, `PhoneNo`, `Role`) VALUES
(20220001, 'ngotranhunganh08@gmail.com', 'ADMIN', 'PY2W7IqpQDo=', 'Administrator', '2022-06-03 00:00:00', b'1', '0908013547', b'1'),
(20220002, 'anhthuhunganh@gmail.com', 'hunganh', 'PY2W7IqpQDo=', 'Ngô Trần Hùng Anh', '2022-11-06 00:00:00', b'1', '0903688560', b'1'),
(20220003, 'ngothanhyen57@gmail.com', 'client', 'PY2W7IqpQDo=', 'client', '2022-06-12 00:00:00', b'1', '0908013547', b'1'),
(20220004, 'ngotranhunganh75@gmail.com', 'user', 'X/hQeogZmc4=', 'Ngô Trần Hùng Anh', '2008-11-10 00:00:00', b'1', '0908013547', b'0'),
(20220005, 'ytranmedia@gmail.com', 'minhy', 'PY2W7IqpQDo=', 'minh', '2020-11-11 00:00:00', b'1', '0908013547', b'1'),
(20220007, 'anhthu278@gmail.com', 'AnhThu', 'PY2W7IqpQDo=', 'Ngô Ngọc Anh Thư', '2004-08-27 00:00:00', b'0', '0903541292', b'0'),
(20220008, 'gdfgsdf@gmail.com', 'anhthu321', 'PY2W7IqpQDo=', 'thu', '2004-08-27 00:00:00', b'0', '0909152611', b'0'),
(20220009, 'dsad@gmail.com', '1234', 'Yg5b8x265Gk=', 'd', '0011-11-11 00:00:00', b'1', 'áda', b'0'),
(20220010, 'tien74.tiachop.thienkhoihcm@gmail.com', 'thuytien', 'PY2W7IqpQDo=', 'tien', '2022-10-06 00:00:00', b'0', '0908038165', b'0');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `passengerdetails`
--

CREATE TABLE `passengerdetails` (
  `PNR` int(11) NOT NULL,
  `UserID` int(11) NOT NULL,
  `Name` varchar(30) NOT NULL,
  `Gender` bit(1) NOT NULL,
  `PhoneNo` varchar(15) NOT NULL,
  `Email` varchar(40) DEFAULT NULL,
  `Source` varchar(30) NOT NULL,
  `Destination` varchar(30) NOT NULL,
  `Departure` datetime NOT NULL,
  `TrainNo` int(11) NOT NULL,
  `Compartment` int(11) NOT NULL,
  `SeatCode` varchar(4) NOT NULL,
  `Price` decimal(15,2) NOT NULL,
  `BookingDate` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Đang đổ dữ liệu cho bảng `passengerdetails`
--

INSERT INTO `passengerdetails` (`PNR`, `UserID`, `Name`, `Gender`, `PhoneNo`, `Email`, `Source`, `Destination`, `Departure`, `TrainNo`, `Compartment`, `SeatCode`, `Price`, `BookingDate`) VALUES
(20220001, 20220003, 'client', b'1', '0908013547', 'ngothanhyen57@gmail.com', 'HANOI', 'HOCHIMINH', '2022-06-14 22:31:00', 20220001, 1, '1AC3', '17690.00', '2022-06-14 12:33:33'),
(20220002, 20220003, 'client', b'1', '0908013547', 'ngothanhyen57@gmail.com', 'HANOI', 'HOCHIMINH', '2022-06-14 22:31:00', 20220001, 1, '2AC4', '17590.00', '2022-06-14 12:33:33'),
(20220003, 20220002, 'Ngô Trần Hùng Anh', b'0', '0908013547', 'anhthuhunganh@gmail.com', 'HANOI', 'HOCHIMINH', '2022-06-14 22:31:00', 20220001, 1, '1AC1', '17690.00', '2022-06-14 17:53:38'),
(20220004, 20220002, 'Ngô Trần Hùng Anh', b'0', '0908013547', 'anhthuhunganh@gmail.com', 'HANOI', 'HOCHIMINH', '2022-06-14 22:31:00', 20220001, 1, '1AC2', '17690.00', '2022-06-14 17:53:39'),
(20220005, 20220002, 'Ngô Trần Hùng Anh', b'0', '0908013547', 'anhthuhunganh@gmail.com', 'HOCHIMINH', 'HANOI', '2022-06-15 18:32:00', 20220002, 1, '1AC1', '17690.00', '2022-06-15 00:17:17'),
(20220006, 20220002, 'Ngô Trần Hùng Anh', b'0', '0908013547', 'anhthuhunganh@gmail.com', 'HOCHIMINH', 'HANOI', '2022-06-15 18:32:00', 20220002, 1, '1AC2', '17690.00', '2022-06-15 00:18:07'),
(20220009, 20220003, 'client', b'1', '0908013547', 'ngothanhyen57@gmail.com', 'HOCHIMINH', 'HUE', '2022-06-16 17:32:00', 20220003, 1, '1AC1', '10550.00', '2022-06-15 22:00:12'),
(20220010, 20220003, 'client', b'1', '0908013547', 'ngothanhyen57@gmail.com', 'HOCHIMINH', 'HUE', '2022-06-16 17:32:00', 20220003, 1, '1AC2', '10550.00', '2022-06-15 22:00:12'),
(20220013, 20220002, 'Ngô Trần Hùng Anh', b'0', '0908013547', 'anhthuhunganh@gmail.com', 'HANOI', 'HOCHIMINH', '2022-06-19 05:15:00', 20220007, 1, '3AC5', '17490.00', '2022-06-17 12:19:53'),
(20220014, 20220002, 'Ngô Trần Hùng Anh', b'0', '0908013547', 'anhthuhunganh@gmail.com', 'HANOI', 'HOCHIMINH', '2022-06-19 05:15:00', 20220007, 1, 'GNE3', '17290.00', '2022-06-17 12:19:53'),
(20220015, 20220002, 'Ngô Trần Hùng Anh', b'0', '0908013547', 'anhthuhunganh@gmail.com', 'HANOI', 'HOCHIMINH', '2022-06-19 05:15:00', 20220007, 1, 'GNE5', '17290.00', '2022-06-17 12:19:53'),
(20220016, 20220002, 'Ngô Trần Hùng Anh', b'0', '0908013547', 'anhthuhunganh@gmail.com', 'HANOI', 'HOCHIMINH', '2022-06-19 05:15:00', 20220007, 1, 'SLE3', '17390.00', '2022-06-17 12:19:53'),
(20220017, 20220003, 'client', b'1', '0908013547', 'ngothanhyen57@gmail.com', 'HANOI', 'HOCHIMINH', '2022-06-30 22:09:00', 20220006, 1, '3AC1', '17490.00', '2022-06-17 13:01:27'),
(20220018, 20220003, 'client', b'1', '0908013547', 'ngothanhyen57@gmail.com', 'HANOI', 'HOCHIMINH', '2022-06-30 22:09:00', 20220006, 1, 'SLE1', '17390.00', '2022-06-17 13:01:27'),
(20220019, 20220003, 'client', b'1', '0908013547', 'ngothanhyen57@gmail.com', 'HANOI', 'HOCHIMINH', '2022-06-19 05:15:00', 20220007, 1, '2AC1', '17590.00', '2022-06-17 13:01:50'),
(20220020, 20220003, 'client', b'1', '0908013547', 'ngothanhyen57@gmail.com', 'HANOI', 'HOCHIMINH', '2022-06-19 05:15:00', 20220007, 1, '2AC3', '17590.00', '2022-06-17 13:01:50'),
(20220021, 20220003, 'client', b'1', '0908013547', 'ngothanhyen57@gmail.com', 'HANOI', 'HOCHIMINH', '2022-06-19 05:15:00', 20220007, 1, '3AC1', '17490.00', '2022-06-17 13:01:50'),
(20220022, 20220005, 'minh', b'1', '0908013547', 'ytranmedia@gmail.com', 'HANOI', 'HUE', '2022-06-19 04:16:00', 20220008, 1, '3AC1', '6980.00', '2022-06-17 16:13:13'),
(20220023, 20220005, 'minh', b'1', '0908013547', 'ytranmedia@gmail.com', 'HANOI', 'HUE', '2022-06-19 04:16:00', 20220008, 1, 'GNE3', '6780.00', '2022-06-17 16:13:13'),
(20220024, 20220005, 'minh', b'1', '0908013547', 'ytranmedia@gmail.com', 'HANOI', 'HUE', '2022-06-19 04:16:00', 20220008, 1, 'SLE2', '6880.00', '2022-06-17 16:13:13'),
(20220025, 20220007, 'Ngô Ngọc Anh Thư', b'0', '0903541292', 'anhthu278@gmail.com', 'HOCHIMINH', 'HANOI', '2022-06-18 11:17:00', 20220009, 1, '2AC1', '17590.00', '2022-06-17 23:25:49'),
(20220026, 20220007, 'Ngô Ngọc Anh Thư', b'0', '0903541292', 'anhthu278@gmail.com', 'HOCHIMINH', 'HANOI', '2022-06-18 11:17:00', 20220009, 1, '3AC1', '17490.00', '2022-06-17 23:25:49');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `pricedetails`
--

CREATE TABLE `pricedetails` (
  `SeatCode` varchar(3) NOT NULL,
  `ClassName` varchar(20) NOT NULL,
  `Price` decimal(15,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Đang đổ dữ liệu cho bảng `pricedetails`
--

INSERT INTO `pricedetails` (`SeatCode`, `ClassName`, `Price`) VALUES
('1AC', 'FirstClass', '500.00'),
('2AC', 'SecondClass', '400.00'),
('3AC', 'ThirdClass', '300.00'),
('GNE', 'Generral', '100.00'),
('SLE', 'SleepRoom', '200.00');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `resetpass`
--

CREATE TABLE `resetpass` (
  `id` int(11) NOT NULL,
  `m_Email` varchar(50) DEFAULT NULL,
  `m_Token` varchar(250) DEFAULT NULL,
  `m_Time` datetime DEFAULT NULL,
  `m_Numcheck` int(11) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Đang đổ dữ liệu cho bảng `resetpass`
--

INSERT INTO `resetpass` (`id`, `m_Email`, `m_Token`, `m_Time`, `m_Numcheck`) VALUES
(19, 'YR4MLucJKpsCIsYFyvG1DYXrR/b56MYH0UFTb2v8JdI=', 'UGJVOIWKCTZJJTPUDOPUUKDFTIQYDXZG', '2022-06-18 09:13:19', 0);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `seatdiagram`
--

CREATE TABLE `seatdiagram` (
  `Id` int(11) NOT NULL,
  `TrainNo` int(11) DEFAULT NULL,
  `Compartment` int(11) DEFAULT NULL,
  `SeatCode` varchar(3) DEFAULT NULL,
  `Seatorder` int(11) DEFAULT NULL,
  `Price` decimal(15,2) DEFAULT NULL,
  `UserID` int(11) DEFAULT NULL,
  `Status` bit(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Đang đổ dữ liệu cho bảng `seatdiagram`
--

INSERT INTO `seatdiagram` (`Id`, `TrainNo`, `Compartment`, `SeatCode`, `Seatorder`, `Price`, `UserID`, `Status`) VALUES
(1, 20220001, 1, '1AC', 1, '17690.00', 20220002, b'0'),
(2, 20220001, 1, '1AC', 2, '17690.00', 20220002, b'0'),
(3, 20220001, 1, '1AC', 3, '17690.00', 20220003, b'0'),
(4, 20220001, 1, '2AC', 1, '17590.00', 0, b'1'),
(5, 20220001, 1, '2AC', 2, '17590.00', 0, b'1'),
(6, 20220001, 1, '2AC', 3, '17590.00', 0, b'1'),
(7, 20220001, 1, '2AC', 4, '17590.00', 20220003, b'0'),
(8, 20220001, 1, '3AC', 1, '17490.00', 0, b'1'),
(9, 20220001, 1, '3AC', 2, '17490.00', 0, b'1'),
(10, 20220001, 1, '3AC', 3, '17490.00', 0, b'1'),
(11, 20220001, 1, '3AC', 4, '17490.00', 0, b'1'),
(12, 20220001, 1, '3AC', 5, '17490.00', 0, b'1'),
(13, 20220001, 1, 'GNE', 1, '17290.00', 0, b'1'),
(14, 20220001, 1, 'GNE', 2, '17290.00', 0, b'1'),
(15, 20220001, 1, 'GNE', 3, '17290.00', 0, b'1'),
(16, 20220001, 1, 'GNE', 4, '17290.00', 0, b'1'),
(17, 20220001, 1, 'GNE', 5, '17290.00', 0, b'1'),
(18, 20220001, 1, 'GNE', 6, '17290.00', 0, b'1'),
(19, 20220001, 1, 'GNE', 7, '17290.00', 0, b'1'),
(20, 20220001, 1, 'SLE', 1, '17390.00', 0, b'1'),
(21, 20220001, 1, 'SLE', 2, '17390.00', 0, b'1'),
(22, 20220001, 1, 'SLE', 3, '17390.00', 0, b'1'),
(23, 20220001, 1, 'SLE', 4, '17390.00', 0, b'1'),
(24, 20220001, 1, 'SLE', 5, '17390.00', 0, b'1'),
(25, 20220001, 1, 'SLE', 6, '17390.00', 0, b'1'),
(26, 20220001, 2, '1AC', 1, '17690.00', 0, b'1'),
(27, 20220001, 2, '1AC', 2, '17690.00', 0, b'1'),
(28, 20220001, 2, '1AC', 3, '17690.00', 0, b'1'),
(29, 20220001, 2, '2AC', 1, '17590.00', 0, b'1'),
(30, 20220001, 2, '2AC', 2, '17590.00', 0, b'1'),
(31, 20220001, 2, '2AC', 3, '17590.00', 0, b'1'),
(32, 20220001, 2, '2AC', 4, '17590.00', 0, b'1'),
(33, 20220001, 2, '3AC', 1, '17490.00', 0, b'1'),
(34, 20220001, 2, '3AC', 2, '17490.00', 0, b'1'),
(35, 20220001, 2, '3AC', 3, '17490.00', 0, b'1'),
(36, 20220001, 2, '3AC', 4, '17490.00', 0, b'1'),
(37, 20220001, 2, '3AC', 5, '17490.00', 0, b'1'),
(38, 20220001, 2, 'GNE', 1, '17290.00', 0, b'1'),
(39, 20220001, 2, 'GNE', 2, '17290.00', 0, b'1'),
(40, 20220001, 2, 'GNE', 3, '17290.00', 0, b'1'),
(41, 20220001, 2, 'GNE', 4, '17290.00', 0, b'1'),
(42, 20220001, 2, 'GNE', 5, '17290.00', 0, b'1'),
(43, 20220001, 2, 'GNE', 6, '17290.00', 0, b'1'),
(44, 20220001, 2, 'GNE', 7, '17290.00', 0, b'1'),
(45, 20220001, 2, 'SLE', 1, '17390.00', 0, b'1'),
(46, 20220001, 2, 'SLE', 2, '17390.00', 0, b'1'),
(47, 20220001, 2, 'SLE', 3, '17390.00', 0, b'1'),
(48, 20220001, 2, 'SLE', 4, '17390.00', 0, b'1'),
(49, 20220001, 2, 'SLE', 5, '17390.00', 0, b'1'),
(50, 20220001, 2, 'SLE', 6, '17390.00', 0, b'1'),
(51, 20220002, 1, '1AC', 1, '17690.00', 20220002, b'0'),
(52, 20220002, 1, '1AC', 2, '17690.00', 20220002, b'0'),
(53, 20220002, 1, '1AC', 3, '17690.00', 0, b'1'),
(54, 20220002, 1, '1AC', 4, '17690.00', 0, b'1'),
(55, 20220002, 1, '1AC', 5, '17690.00', 0, b'1'),
(56, 20220002, 1, '2AC', 1, '17590.00', 0, b'1'),
(57, 20220002, 1, '2AC', 2, '17590.00', 0, b'1'),
(58, 20220002, 1, '2AC', 3, '17590.00', 0, b'1'),
(59, 20220002, 1, '2AC', 4, '17590.00', 0, b'1'),
(60, 20220002, 1, '3AC', 1, '17490.00', 0, b'1'),
(61, 20220002, 1, '3AC', 2, '17490.00', 0, b'1'),
(62, 20220002, 1, '3AC', 3, '17490.00', 0, b'1'),
(63, 20220002, 1, '3AC', 4, '17490.00', 0, b'1'),
(64, 20220002, 1, '3AC', 5, '17490.00', 0, b'1'),
(65, 20220002, 1, '3AC', 6, '17490.00', 0, b'1'),
(66, 20220002, 1, 'GNE', 1, '17290.00', 0, b'1'),
(67, 20220002, 1, 'GNE', 2, '17290.00', 0, b'1'),
(68, 20220002, 1, 'GNE', 3, '17290.00', 0, b'1'),
(69, 20220002, 1, 'GNE', 4, '17290.00', 0, b'1'),
(70, 20220002, 1, 'GNE', 5, '17290.00', 0, b'1'),
(71, 20220002, 1, 'GNE', 6, '17290.00', 0, b'1'),
(72, 20220002, 1, 'GNE', 7, '17290.00', 0, b'1'),
(73, 20220002, 1, 'GNE', 8, '17290.00', 0, b'1'),
(74, 20220002, 1, 'SLE', 1, '17390.00', 0, b'1'),
(75, 20220002, 1, 'SLE', 2, '17390.00', 0, b'1'),
(76, 20220002, 1, 'SLE', 3, '17390.00', 0, b'1'),
(77, 20220002, 1, 'SLE', 4, '17390.00', 0, b'1'),
(78, 20220002, 1, 'SLE', 5, '17390.00', 0, b'1'),
(79, 20220002, 1, 'SLE', 6, '17390.00', 0, b'1'),
(80, 20220002, 1, 'SLE', 7, '17390.00', 0, b'1'),
(81, 20220002, 2, '1AC', 1, '17690.00', 0, b'1'),
(82, 20220002, 2, '1AC', 2, '17690.00', 0, b'1'),
(83, 20220002, 2, '1AC', 3, '17690.00', 0, b'1'),
(84, 20220002, 2, '1AC', 4, '17690.00', 0, b'1'),
(85, 20220002, 2, '1AC', 5, '17690.00', 0, b'1'),
(86, 20220002, 2, '2AC', 1, '17590.00', 0, b'1'),
(87, 20220002, 2, '2AC', 2, '17590.00', 0, b'1'),
(88, 20220002, 2, '2AC', 3, '17590.00', 0, b'1'),
(89, 20220002, 2, '2AC', 4, '17590.00', 0, b'1'),
(90, 20220002, 2, '3AC', 1, '17490.00', 0, b'1'),
(91, 20220002, 2, '3AC', 2, '17490.00', 0, b'1'),
(92, 20220002, 2, '3AC', 3, '17490.00', 0, b'1'),
(93, 20220002, 2, '3AC', 4, '17490.00', 0, b'1'),
(94, 20220002, 2, '3AC', 5, '17490.00', 0, b'1'),
(95, 20220002, 2, '3AC', 6, '17490.00', 0, b'1'),
(96, 20220002, 2, 'GNE', 1, '17290.00', 0, b'1'),
(97, 20220002, 2, 'GNE', 2, '17290.00', 0, b'1'),
(98, 20220002, 2, 'GNE', 3, '17290.00', 0, b'1'),
(99, 20220002, 2, 'GNE', 4, '17290.00', 0, b'1'),
(100, 20220002, 2, 'GNE', 5, '17290.00', 0, b'1'),
(101, 20220002, 2, 'GNE', 6, '17290.00', 0, b'1'),
(102, 20220002, 2, 'GNE', 7, '17290.00', 0, b'1'),
(103, 20220002, 2, 'GNE', 8, '17290.00', 0, b'1'),
(104, 20220002, 2, 'SLE', 1, '17390.00', 0, b'1'),
(105, 20220002, 2, 'SLE', 2, '17390.00', 0, b'1'),
(106, 20220002, 2, 'SLE', 3, '17390.00', 0, b'1'),
(107, 20220002, 2, 'SLE', 4, '17390.00', 0, b'1'),
(108, 20220002, 2, 'SLE', 5, '17390.00', 0, b'1'),
(109, 20220002, 2, 'SLE', 6, '17390.00', 0, b'1'),
(110, 20220002, 2, 'SLE', 7, '17390.00', 0, b'1'),
(111, 20220003, 1, '1AC', 1, '10550.00', 20220003, b'0'),
(112, 20220003, 1, '1AC', 2, '10550.00', 20220003, b'0'),
(113, 20220003, 1, '1AC', 3, '10550.00', 0, b'1'),
(114, 20220003, 1, '2AC', 1, '10450.00', 0, b'1'),
(115, 20220003, 1, '2AC', 2, '10450.00', 0, b'1'),
(116, 20220003, 1, '2AC', 3, '10450.00', 0, b'1'),
(117, 20220003, 1, '2AC', 4, '10450.00', 0, b'1'),
(118, 20220003, 1, '3AC', 1, '10350.00', 0, b'1'),
(119, 20220003, 1, '3AC', 2, '10350.00', 0, b'1'),
(120, 20220003, 1, '3AC', 3, '10350.00', 0, b'1'),
(121, 20220003, 1, '3AC', 4, '10350.00', 0, b'1'),
(122, 20220003, 1, '3AC', 5, '10350.00', 0, b'1'),
(123, 20220003, 1, 'GNE', 1, '10150.00', 0, b'1'),
(124, 20220003, 1, 'GNE', 2, '10150.00', 0, b'1'),
(125, 20220003, 1, 'GNE', 3, '10150.00', 0, b'1'),
(126, 20220003, 1, 'GNE', 4, '10150.00', 0, b'1'),
(127, 20220003, 1, 'GNE', 5, '10150.00', 0, b'1'),
(128, 20220003, 1, 'GNE', 6, '10150.00', 0, b'1'),
(129, 20220003, 1, 'GNE', 7, '10150.00', 0, b'1'),
(130, 20220003, 1, 'SLE', 1, '10250.00', 0, b'1'),
(131, 20220003, 1, 'SLE', 2, '10250.00', 0, b'1'),
(132, 20220003, 1, 'SLE', 3, '10250.00', 0, b'1'),
(133, 20220003, 1, 'SLE', 4, '10250.00', 0, b'1'),
(134, 20220003, 1, 'SLE', 5, '10250.00', 0, b'1'),
(135, 20220003, 1, 'SLE', 6, '10250.00', 0, b'1'),
(136, 20220003, 2, '1AC', 1, '10550.00', 0, b'1'),
(137, 20220003, 2, '1AC', 2, '10550.00', 0, b'1'),
(138, 20220003, 2, '1AC', 3, '10550.00', 0, b'1'),
(139, 20220003, 2, '2AC', 1, '10450.00', 0, b'1'),
(140, 20220003, 2, '2AC', 2, '10450.00', 0, b'1'),
(141, 20220003, 2, '2AC', 3, '10450.00', 0, b'1'),
(142, 20220003, 2, '2AC', 4, '10450.00', 0, b'1'),
(143, 20220003, 2, '3AC', 1, '10350.00', 0, b'1'),
(144, 20220003, 2, '3AC', 2, '10350.00', 0, b'1'),
(145, 20220003, 2, '3AC', 3, '10350.00', 0, b'1'),
(146, 20220003, 2, '3AC', 4, '10350.00', 0, b'1'),
(147, 20220003, 2, '3AC', 5, '10350.00', 0, b'1'),
(148, 20220003, 2, 'GNE', 1, '10150.00', 0, b'1'),
(149, 20220003, 2, 'GNE', 2, '10150.00', 0, b'1'),
(150, 20220003, 2, 'GNE', 3, '10150.00', 0, b'1'),
(151, 20220003, 2, 'GNE', 4, '10150.00', 0, b'1'),
(152, 20220003, 2, 'GNE', 5, '10150.00', 0, b'1'),
(153, 20220003, 2, 'GNE', 6, '10150.00', 0, b'1'),
(154, 20220003, 2, 'GNE', 7, '10150.00', 0, b'1'),
(155, 20220003, 2, 'SLE', 1, '10250.00', 0, b'1'),
(156, 20220003, 2, 'SLE', 2, '10250.00', 0, b'1'),
(157, 20220003, 2, 'SLE', 3, '10250.00', 0, b'1'),
(158, 20220003, 2, 'SLE', 4, '10250.00', 0, b'1'),
(159, 20220003, 2, 'SLE', 5, '10250.00', 0, b'1'),
(160, 20220003, 2, 'SLE', 6, '10250.00', 0, b'1'),
(161, 20220004, 1, '1AC', 1, '17690.00', 0, b'1'),
(162, 20220004, 1, '2AC', 1, '17590.00', 0, b'1'),
(163, 20220004, 1, '3AC', 1, '17490.00', 0, b'1'),
(164, 20220004, 1, 'GNE', 1, '17290.00', 0, b'1'),
(165, 20220004, 1, 'SLE', 1, '17390.00', 0, b'1'),
(166, 20220005, 1, '1AC', 1, '17690.00', 0, b'1'),
(167, 20220006, 1, '1AC', 1, '17690.00', 20220002, b'1'),
(168, 20220006, 1, '2AC', 1, '17590.00', 20220003, b'1'),
(169, 20220006, 1, '3AC', 1, '17490.00', 20220003, b'0'),
(170, 20220006, 1, 'GNE', 1, '17290.00', 0, b'1'),
(171, 20220006, 1, 'SLE', 1, '17390.00', 20220003, b'0'),
(172, 20220007, 1, '1AC', 1, '17690.00', 0, b'1'),
(173, 20220007, 1, '1AC', 2, '17690.00', 0, b'1'),
(174, 20220007, 1, '1AC', 3, '17690.00', 20220003, b'1'),
(175, 20220007, 1, '1AC', 4, '17690.00', 0, b'1'),
(176, 20220007, 1, '1AC', 5, '17690.00', 0, b'1'),
(177, 20220007, 1, '2AC', 1, '17590.00', 20220003, b'0'),
(178, 20220007, 1, '2AC', 2, '17590.00', 0, b'1'),
(179, 20220007, 1, '2AC', 3, '17590.00', 20220003, b'0'),
(180, 20220007, 1, '2AC', 4, '17590.00', 0, b'1'),
(181, 20220007, 1, '2AC', 5, '17590.00', 0, b'1'),
(182, 20220007, 1, '2AC', 6, '17590.00', 0, b'1'),
(183, 20220007, 1, '3AC', 1, '17490.00', 20220003, b'0'),
(184, 20220007, 1, '3AC', 2, '17490.00', 0, b'1'),
(185, 20220007, 1, '3AC', 3, '17490.00', 0, b'1'),
(186, 20220007, 1, '3AC', 4, '17490.00', 0, b'1'),
(187, 20220007, 1, '3AC', 5, '17490.00', 20220002, b'0'),
(188, 20220007, 1, 'GNE', 1, '17290.00', 0, b'1'),
(189, 20220007, 1, 'GNE', 2, '17290.00', 0, b'1'),
(190, 20220007, 1, 'GNE', 3, '17290.00', 20220002, b'0'),
(191, 20220007, 1, 'GNE', 4, '17290.00', 0, b'1'),
(192, 20220007, 1, 'GNE', 5, '17290.00', 20220002, b'0'),
(193, 20220007, 1, 'SLE', 1, '17390.00', 0, b'1'),
(194, 20220007, 1, 'SLE', 2, '17390.00', 0, b'1'),
(195, 20220007, 1, 'SLE', 3, '17390.00', 20220002, b'0'),
(196, 20220007, 1, 'SLE', 4, '17390.00', 0, b'1'),
(197, 20220007, 1, 'SLE', 5, '17390.00', 0, b'1'),
(198, 20220007, 2, '1AC', 1, '17690.00', 0, b'1'),
(199, 20220007, 2, '1AC', 2, '17690.00', 0, b'1'),
(200, 20220007, 2, '1AC', 3, '17690.00', 0, b'1'),
(201, 20220007, 2, '1AC', 4, '17690.00', 0, b'1'),
(202, 20220007, 2, '1AC', 5, '17690.00', 0, b'1'),
(203, 20220007, 2, '2AC', 1, '17590.00', 0, b'1'),
(204, 20220007, 2, '2AC', 2, '17590.00', 0, b'1'),
(205, 20220007, 2, '2AC', 3, '17590.00', 0, b'1'),
(206, 20220007, 2, '2AC', 4, '17590.00', 0, b'1'),
(207, 20220007, 2, '2AC', 5, '17590.00', 0, b'1'),
(208, 20220007, 2, '2AC', 6, '17590.00', 0, b'1'),
(209, 20220007, 2, '3AC', 1, '17490.00', 0, b'1'),
(210, 20220007, 2, '3AC', 2, '17490.00', 0, b'1'),
(211, 20220007, 2, '3AC', 3, '17490.00', 0, b'1'),
(212, 20220007, 2, '3AC', 4, '17490.00', 0, b'1'),
(213, 20220007, 2, '3AC', 5, '17490.00', 0, b'1'),
(214, 20220007, 2, 'GNE', 1, '17290.00', 0, b'1'),
(215, 20220007, 2, 'GNE', 2, '17290.00', 0, b'1'),
(216, 20220007, 2, 'GNE', 3, '17290.00', 0, b'1'),
(217, 20220007, 2, 'GNE', 4, '17290.00', 0, b'1'),
(218, 20220007, 2, 'GNE', 5, '17290.00', 0, b'1'),
(219, 20220007, 2, 'SLE', 1, '17390.00', 0, b'1'),
(220, 20220007, 2, 'SLE', 2, '17390.00', 0, b'1'),
(221, 20220007, 2, 'SLE', 3, '17390.00', 0, b'1'),
(222, 20220007, 2, 'SLE', 4, '17390.00', 0, b'1'),
(223, 20220007, 2, 'SLE', 5, '17390.00', 0, b'1'),
(224, 20220008, 1, '1AC', 1, '7180.00', 0, b'1'),
(225, 20220008, 1, '1AC', 2, '7180.00', 0, b'1'),
(226, 20220008, 1, '1AC', 3, '7180.00', 0, b'1'),
(227, 20220008, 1, '1AC', 4, '7180.00', 0, b'1'),
(228, 20220008, 1, '1AC', 5, '7180.00', 0, b'1'),
(229, 20220008, 1, '2AC', 1, '7080.00', 0, b'1'),
(230, 20220008, 1, '2AC', 2, '7080.00', 0, b'1'),
(231, 20220008, 1, '2AC', 3, '7080.00', 0, b'1'),
(232, 20220008, 1, '3AC', 1, '6980.00', 20220005, b'0'),
(233, 20220008, 1, '3AC', 2, '6980.00', 0, b'1'),
(234, 20220008, 1, '3AC', 3, '6980.00', 0, b'1'),
(235, 20220008, 1, '3AC', 4, '6980.00', 0, b'1'),
(236, 20220008, 1, '3AC', 5, '6980.00', 0, b'1'),
(237, 20220008, 1, '3AC', 6, '6980.00', 0, b'1'),
(238, 20220008, 1, 'GNE', 1, '6780.00', 0, b'1'),
(239, 20220008, 1, 'GNE', 2, '6780.00', 0, b'1'),
(240, 20220008, 1, 'GNE', 3, '6780.00', 20220005, b'0'),
(241, 20220008, 1, 'GNE', 4, '6780.00', 0, b'1'),
(242, 20220008, 1, 'GNE', 5, '6780.00', 0, b'1'),
(243, 20220008, 1, 'GNE', 6, '6780.00', 0, b'1'),
(244, 20220008, 1, 'SLE', 1, '6880.00', 0, b'1'),
(245, 20220008, 1, 'SLE', 2, '6880.00', 20220005, b'0'),
(246, 20220008, 1, 'SLE', 3, '6880.00', 0, b'1'),
(247, 20220008, 1, 'SLE', 4, '6880.00', 0, b'1'),
(248, 20220008, 2, '1AC', 1, '7180.00', 0, b'1'),
(249, 20220008, 2, '1AC', 2, '7180.00', 0, b'1'),
(250, 20220008, 2, '1AC', 3, '7180.00', 0, b'1'),
(251, 20220008, 2, '1AC', 4, '7180.00', 0, b'1'),
(252, 20220008, 2, '1AC', 5, '7180.00', 0, b'1'),
(253, 20220008, 2, '2AC', 1, '7080.00', 0, b'1'),
(254, 20220008, 2, '2AC', 2, '7080.00', 0, b'1'),
(255, 20220008, 2, '2AC', 3, '7080.00', 0, b'1'),
(256, 20220008, 2, '3AC', 1, '6980.00', 0, b'1'),
(257, 20220008, 2, '3AC', 2, '6980.00', 0, b'1'),
(258, 20220008, 2, '3AC', 3, '6980.00', 0, b'1'),
(259, 20220008, 2, '3AC', 4, '6980.00', 0, b'1'),
(260, 20220008, 2, '3AC', 5, '6980.00', 0, b'1'),
(261, 20220008, 2, '3AC', 6, '6980.00', 0, b'1'),
(262, 20220008, 2, 'GNE', 1, '6780.00', 0, b'1'),
(263, 20220008, 2, 'GNE', 2, '6780.00', 0, b'1'),
(264, 20220008, 2, 'GNE', 3, '6780.00', 0, b'1'),
(265, 20220008, 2, 'GNE', 4, '6780.00', 0, b'1'),
(266, 20220008, 2, 'GNE', 5, '6780.00', 0, b'1'),
(267, 20220008, 2, 'GNE', 6, '6780.00', 0, b'1'),
(268, 20220008, 2, 'SLE', 1, '6880.00', 0, b'1'),
(269, 20220008, 2, 'SLE', 2, '6880.00', 0, b'1'),
(270, 20220008, 2, 'SLE', 3, '6880.00', 0, b'1'),
(271, 20220008, 2, 'SLE', 4, '6880.00', 0, b'1'),
(272, 20220009, 1, '1AC', 1, '17690.00', 0, b'1'),
(273, 20220009, 1, '1AC', 2, '17690.00', 0, b'1'),
(274, 20220009, 1, '1AC', 3, '17690.00', 0, b'1'),
(275, 20220009, 1, '1AC', 4, '17690.00', 0, b'1'),
(276, 20220009, 1, '1AC', 5, '17690.00', 0, b'1'),
(277, 20220009, 1, '1AC', 6, '17690.00', 0, b'1'),
(278, 20220009, 1, '2AC', 1, '17590.00', 20220007, b'0'),
(279, 20220009, 1, '2AC', 2, '17590.00', 0, b'1'),
(280, 20220009, 1, '2AC', 3, '17590.00', 0, b'1'),
(281, 20220009, 1, '2AC', 4, '17590.00', 0, b'1'),
(282, 20220009, 1, '3AC', 1, '17490.00', 20220007, b'0'),
(283, 20220009, 1, '3AC', 2, '17490.00', 0, b'1'),
(284, 20220009, 1, '3AC', 3, '17490.00', 0, b'1'),
(285, 20220009, 1, 'GNE', 1, '17290.00', 0, b'1'),
(286, 20220009, 1, 'GNE', 2, '17290.00', 0, b'1'),
(287, 20220009, 1, 'GNE', 3, '17290.00', 0, b'1'),
(288, 20220009, 1, 'GNE', 4, '17290.00', 0, b'1'),
(289, 20220009, 1, 'GNE', 5, '17290.00', 0, b'1'),
(290, 20220009, 1, 'SLE', 1, '17390.00', 0, b'1'),
(291, 20220009, 1, 'SLE', 2, '17390.00', 0, b'1'),
(292, 20220009, 1, 'SLE', 3, '17390.00', 0, b'1'),
(293, 20220009, 1, 'SLE', 4, '17390.00', 0, b'1'),
(294, 20220009, 1, 'SLE', 5, '17390.00', 0, b'1'),
(295, 20220009, 2, '1AC', 1, '17690.00', 0, b'1'),
(296, 20220009, 2, '1AC', 2, '17690.00', 0, b'1'),
(297, 20220009, 2, '1AC', 3, '17690.00', 0, b'1'),
(298, 20220009, 2, '1AC', 4, '17690.00', 0, b'1'),
(299, 20220009, 2, '1AC', 5, '17690.00', 0, b'1'),
(300, 20220009, 2, '1AC', 6, '17690.00', 0, b'1'),
(301, 20220009, 2, '2AC', 1, '17590.00', 0, b'1'),
(302, 20220009, 2, '2AC', 2, '17590.00', 0, b'1'),
(303, 20220009, 2, '2AC', 3, '17590.00', 0, b'1'),
(304, 20220009, 2, '2AC', 4, '17590.00', 0, b'1'),
(305, 20220009, 2, '3AC', 1, '17490.00', 0, b'1'),
(306, 20220009, 2, '3AC', 2, '17490.00', 0, b'1'),
(307, 20220009, 2, '3AC', 3, '17490.00', 0, b'1'),
(308, 20220009, 2, 'GNE', 1, '17290.00', 0, b'1'),
(309, 20220009, 2, 'GNE', 2, '17290.00', 0, b'1'),
(310, 20220009, 2, 'GNE', 3, '17290.00', 0, b'1'),
(311, 20220009, 2, 'GNE', 4, '17290.00', 0, b'1'),
(312, 20220009, 2, 'GNE', 5, '17290.00', 0, b'1'),
(313, 20220009, 2, 'SLE', 1, '17390.00', 0, b'1'),
(314, 20220009, 2, 'SLE', 2, '17390.00', 0, b'1'),
(315, 20220009, 2, 'SLE', 3, '17390.00', 0, b'1'),
(316, 20220009, 2, 'SLE', 4, '17390.00', 0, b'1'),
(317, 20220009, 2, 'SLE', 5, '17390.00', 0, b'1');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `stationarr`
--

CREATE TABLE `stationarr` (
  `StationCode` varchar(20) NOT NULL,
  `StationName` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Đang đổ dữ liệu cho bảng `stationarr`
--

INSERT INTO `stationarr` (`StationCode`, `StationName`) VALUES
('HANOI', 'Hà Nội'),
('HOCHIMINH', 'Hồ Chí Minh'),
('HUE', 'Huế');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `stationdep`
--

CREATE TABLE `stationdep` (
  `StationCode` varchar(20) NOT NULL,
  `StationName` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Đang đổ dữ liệu cho bảng `stationdep`
--

INSERT INTO `stationdep` (`StationCode`, `StationName`) VALUES
('HANOI', 'Hà Nội'),
('HOCHIMINH', 'Hồ Chí Minh'),
('HUE', 'Huế');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `traindetails`
--

CREATE TABLE `traindetails` (
  `TrainNo` int(11) NOT NULL,
  `TrainName` varchar(30) NOT NULL,
  `Source` varchar(20) NOT NULL,
  `Destination` varchar(20) NOT NULL,
  `Departure` datetime NOT NULL,
  `NoOfCompartment` int(11) NOT NULL,
  `FirstClass` int(11) NOT NULL,
  `SecondClass` int(11) NOT NULL,
  `ThirdClass` int(11) NOT NULL,
  `SleepRoom` int(11) NOT NULL,
  `General` int(11) NOT NULL,
  `Status` bit(1) NOT NULL DEFAULT b'0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Đang đổ dữ liệu cho bảng `traindetails`
--

INSERT INTO `traindetails` (`TrainNo`, `TrainName`, `Source`, `Destination`, `Departure`, `NoOfCompartment`, `FirstClass`, `SecondClass`, `ThirdClass`, `SleepRoom`, `General`, `Status`) VALUES
(20220001, 'Tàu Thống Nhất Bắc Nam', 'HANOI', 'HOCHIMINH', '2022-06-14 22:31:00', 2, 3, 4, 5, 6, 7, b'1'),
(20220002, 'Tàu Thống Nhất 12', 'HOCHIMINH', 'HANOI', '2022-06-15 18:32:00', 2, 5, 4, 6, 7, 8, b'1'),
(20220003, 'Tàu cao tốc bắc nam', 'HOCHIMINH', 'HUE', '2022-06-16 17:32:00', 2, 3, 4, 5, 6, 7, b'1'),
(20220006, 'Tàu cao tốc bắc nam', 'HANOI', 'HOCHIMINH', '2022-06-30 22:09:00', 1, 1, 1, 1, 1, 1, b'1'),
(20220007, 'Tàu cao tốc bắc nam', 'HANOI', 'HOCHIMINH', '2022-06-19 05:15:00', 2, 5, 6, 5, 5, 5, b'1'),
(20220008, 'Tàu Thống Nhất 12', 'HANOI', 'HUE', '2022-06-19 04:16:00', 2, 5, 3, 6, 4, 6, b'1'),
(20220009, 'Tàu Thống Nhất Bắc Nam 131', 'HOCHIMINH', 'HANOI', '2022-06-18 11:17:00', 2, 6, 4, 3, 5, 5, b'1');

--
-- Chỉ mục cho các bảng đã đổ
--

--
-- Chỉ mục cho bảng `disprice`
--
ALTER TABLE `disprice`
  ADD PRIMARY KEY (`id`);

--
-- Chỉ mục cho bảng `logindetails`
--
ALTER TABLE `logindetails`
  ADD PRIMARY KEY (`UserID`);

--
-- Chỉ mục cho bảng `passengerdetails`
--
ALTER TABLE `passengerdetails`
  ADD PRIMARY KEY (`PNR`);

--
-- Chỉ mục cho bảng `pricedetails`
--
ALTER TABLE `pricedetails`
  ADD PRIMARY KEY (`SeatCode`);

--
-- Chỉ mục cho bảng `resetpass`
--
ALTER TABLE `resetpass`
  ADD PRIMARY KEY (`id`);

--
-- Chỉ mục cho bảng `seatdiagram`
--
ALTER TABLE `seatdiagram`
  ADD PRIMARY KEY (`Id`);

--
-- Chỉ mục cho bảng `stationarr`
--
ALTER TABLE `stationarr`
  ADD PRIMARY KEY (`StationCode`);

--
-- Chỉ mục cho bảng `stationdep`
--
ALTER TABLE `stationdep`
  ADD PRIMARY KEY (`StationCode`);

--
-- Chỉ mục cho bảng `traindetails`
--
ALTER TABLE `traindetails`
  ADD PRIMARY KEY (`TrainNo`);

--
-- AUTO_INCREMENT cho các bảng đã đổ
--

--
-- AUTO_INCREMENT cho bảng `disprice`
--
ALTER TABLE `disprice`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT cho bảng `logindetails`
--
ALTER TABLE `logindetails`
  MODIFY `UserID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20220011;

--
-- AUTO_INCREMENT cho bảng `passengerdetails`
--
ALTER TABLE `passengerdetails`
  MODIFY `PNR` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20220027;

--
-- AUTO_INCREMENT cho bảng `resetpass`
--
ALTER TABLE `resetpass`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- AUTO_INCREMENT cho bảng `seatdiagram`
--
ALTER TABLE `seatdiagram`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=318;

--
-- AUTO_INCREMENT cho bảng `traindetails`
--
ALTER TABLE `traindetails`
  MODIFY `TrainNo` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20220010;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;