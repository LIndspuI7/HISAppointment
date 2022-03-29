/*
 Navicat Premium Data Transfer

 Source Server         : MySQL
 Source Server Type    : MySQL
 Source Server Version : 80028
 Source Host           : localhost:3306
 Source Schema         : 

 Target Server Type    : MySQL
 Target Server Version : 80028
 File Encoding         : 65001

 Date: 29/03/2022 20:56:01
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for depdoc
-- ----------------------------
DROP TABLE IF EXISTS `depdoc`;
CREATE TABLE `depdoc`  (
  `PrimaryId` int NOT NULL AUTO_INCREMENT,
  `DeptId` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `DoctorId` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`PrimaryId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 7 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of depdoc
-- ----------------------------
INSERT INTO `depdoc` VALUES (1, '1001', '10001');
INSERT INTO `depdoc` VALUES (2, '1001', '10002');
INSERT INTO `depdoc` VALUES (3, '1002', '10001');
INSERT INTO `depdoc` VALUES (4, '1003', '10001');
INSERT INTO `depdoc` VALUES (5, '1003', '10002');
INSERT INTO `depdoc` VALUES (6, '1003', '10003');

-- ----------------------------
-- Table structure for dept2
-- ----------------------------
DROP TABLE IF EXISTS `dept2`;
CREATE TABLE `dept2`  (
  `PrimaryId` int NOT NULL AUTO_INCREMENT,
  `DeptId` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `DeptName` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `DeptDesc` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  PRIMARY KEY (`PrimaryId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 4 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of dept2
-- ----------------------------
INSERT INTO `dept2` VALUES (1, '1001', '内科', '内科介绍');
INSERT INTO `dept2` VALUES (2, '1002', '外科', '外科介绍');
INSERT INTO `dept2` VALUES (3, '1003', '耳鼻咽喉科', '耳鼻咽喉科介绍');

-- ----------------------------
-- Table structure for dictionary
-- ----------------------------
DROP TABLE IF EXISTS `dictionary`;
CREATE TABLE `dictionary`  (
  `PrimaryId` int NOT NULL AUTO_INCREMENT,
  `Tables` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `Code` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `Key` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `Value` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `Description` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  PRIMARY KEY (`PrimaryId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 3 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of dictionary
-- ----------------------------
INSERT INTO `dictionary` VALUES (1, 'Order', 'OrderNo', 'order', '10000002', 'order表订单号');
INSERT INTO `dictionary` VALUES (2, 'Card', 'CurrentCardNo', 'card', '3', 'card表卡号');
INSERT INTO `dictionary` VALUES (3, 'Auth', 'ChannelId&Token', '1', '123', 'ChannelId=渠道ID，Token=token');

-- ----------------------------
-- Table structure for doctor
-- ----------------------------
DROP TABLE IF EXISTS `doctor`;
CREATE TABLE `doctor`  (
  `PrimaryId` int NOT NULL AUTO_INCREMENT,
  `DoctorId` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `DoctorName` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `DoctorLevel` int NULL DEFAULT NULL,
  `Sex` int NULL DEFAULT NULL,
  `Phone` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `Desc` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `Status` int NULL DEFAULT NULL,
  PRIMARY KEY (`PrimaryId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 4 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of doctor
-- ----------------------------
INSERT INTO `doctor` VALUES (1, '10001', '张某', 1, 1, '153****6545', NULL, 1);
INSERT INTO `doctor` VALUES (2, '10002', '李某', 1, 2, '183****4574', NULL, 1);
INSERT INTO `doctor` VALUES (3, '10003', '王某', 2, 1, '133****4154', NULL, 1);

-- ----------------------------
-- Table structure for order
-- ----------------------------
DROP TABLE IF EXISTS `order`;
CREATE TABLE `order`  (
  `PrimaryId` int NOT NULL AUTO_INCREMENT,
  `OrderId` int NOT NULL,
  `OrderDate` datetime NOT NULL,
  `Status` int NOT NULL,
  `ChannelId` int NOT NULL,
  `ScheduleId` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ScheduleDate` date NOT NULL,
  `SourceId` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `BeginTime` time NOT NULL,
  `EndTime` time NULL DEFAULT NULL,
  `DeptId` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `DoctorId` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `CardNo` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Phone` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  PRIMARY KEY (`PrimaryId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 9 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of order
-- ----------------------------

-- ----------------------------
-- Table structure for patient
-- ----------------------------
DROP TABLE IF EXISTS `patient`;
CREATE TABLE `patient`  (
  `PrimaryId` int NOT NULL AUTO_INCREMENT,
  `PatientId` int NOT NULL,
  `ChannelId` int NOT NULL,
  `CardNo` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `CardType` int NOT NULL,
  `Name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Sex` int NOT NULL,
  `Birth` date NOT NULL,
  `Address` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `Phone` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`PrimaryId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 4 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of patient
-- ----------------------------

-- ----------------------------
-- Table structure for schedule
-- ----------------------------
DROP TABLE IF EXISTS `schedule`;
CREATE TABLE `schedule`  (
  `PrimaryId` int NOT NULL AUTO_INCREMENT,
  `ScheduleId` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ScheduleDate` date NOT NULL,
  `DeptId` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `DoctorId` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Amt` decimal(10, 2) NOT NULL,
  `TotalNum` int NOT NULL,
  `UsedNum` int NOT NULL,
  `Status` int NOT NULL,
  `TimeType` int NOT NULL,
  `BeginTime` time NOT NULL,
  `EndTime` time NOT NULL,
  PRIMARY KEY (`PrimaryId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 17 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of schedule
-- ----------------------------
INSERT INTO `schedule` VALUES (1, '20220313210011000110', '2022-04-13', '1001', '10001', 10.50, 20, 0, 1, 1, '08:00:00', '12:00:00');
INSERT INTO `schedule` VALUES (2, '20220313210011000111', '2022-04-13', '1001', '10001', 10.50, 20, 0, 1, 2, '14:00:00', '18:00:00');
INSERT INTO `schedule` VALUES (3, '20220313210011000112', '2022-04-14', '1001', '10001', 10.50, 20, 0, 1, 1, '08:00:00', '12:00:00');
INSERT INTO `schedule` VALUES (4, '20220313210011000113', '2022-04-14', '1001', '10001', 10.50, 20, 0, 1, 2, '14:00:00', '18:00:00');
INSERT INTO `schedule` VALUES (5, '20220313210011000114', '2022-04-14', '1001', '10002', 17.50, 20, 0, 1, 1, '08:00:00', '12:00:00');
INSERT INTO `schedule` VALUES (6, '20220313210011000115', '2022-04-14', '1001', '10002', 17.50, 20, 0, 1, 2, '14:00:00', '18:00:00');
INSERT INTO `schedule` VALUES (7, '20220313210011000116', '2022-04-15', '1002', '10001', 10.50, 20, 0, 1, 1, '08:00:00', '12:00:00');
INSERT INTO `schedule` VALUES (8, '20220313210011000117', '2022-04-15', '1002', '10001', 10.50, 20, 0, 1, 2, '14:00:00', '18:00:00');
INSERT INTO `schedule` VALUES (9, '20220313210011000118', '2022-04-15', '1003', '10001', 10.50, 20, 0, 1, 1, '08:00:00', '12:00:00');
INSERT INTO `schedule` VALUES (10, '20220313210011000119', '2022-04-15', '1003', '10001', 10.50, 20, 0, 1, 2, '14:00:00', '18:00:00');
INSERT INTO `schedule` VALUES (11, '20220313210011000120', '2022-04-16', '1003', '10002', 10.50, 20, 0, 1, 1, '08:00:00', '12:00:00');
INSERT INTO `schedule` VALUES (12, '20220313210011000121', '2022-04-16', '1003', '10002', 10.50, 20, 0, 1, 2, '14:00:00', '18:00:00');
INSERT INTO `schedule` VALUES (13, '20220313210011000122', '2022-04-16', '1003', '10003', 22.50, 20, 0, 1, 1, '08:00:00', '12:00:00');
INSERT INTO `schedule` VALUES (14, '20220313210011000123', '2022-04-16', '1003', '10003', 22.50, 20, 0, 1, 2, '14:00:00', '18:00:00');
INSERT INTO `schedule` VALUES (15, '20220313210011000124', '2022-04-16', '1003', '10001', 10.50, 20, 0, 1, 1, '08:00:00', '12:00:00');
INSERT INTO `schedule` VALUES (16, '20220313210011000125', '2022-04-16', '1003', '10001', 10.50, 20, 2, 1, 2, '14:00:00', '18:00:00');

-- ----------------------------
-- Table structure for source
-- ----------------------------
DROP TABLE IF EXISTS `source`;
CREATE TABLE `source`  (
  `PrimaryId` int NOT NULL AUTO_INCREMENT,
  `ScheduleId` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `SourceId` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `DeptId` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `DoctorId` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Status` int NOT NULL,
  `TotalNum` int NOT NULL,
  `UsedNum` int NOT NULL,
  `BeginTime` time NOT NULL,
  `EndTime` time NOT NULL,
  PRIMARY KEY (`PrimaryId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 5 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of source
-- ----------------------------
INSERT INTO `source` VALUES (1, '20220313210011000125', '22031321001100012501', '1003', '10001', 1, 5, 0, '14:00:00', '15:00:00');
INSERT INTO `source` VALUES (2, '20220313210011000125', '22031321001100012502', '1003', '10001', 1, 5, 0, '15:00:00', '16:00:00');
INSERT INTO `source` VALUES (3, '20220313210011000125', '22031321001100012502', '1003', '10001', 1, 5, 0, '16:00:00', '17:00:00');
INSERT INTO `source` VALUES (4, '20220313210011000125', '22031321001100012502', '1003', '10001', 1, 5, 2, '17:00:00', '18:00:00');

SET FOREIGN_KEY_CHECKS = 1;
