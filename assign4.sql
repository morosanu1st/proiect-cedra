-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema assign4
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema assign4
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `assign4` DEFAULT CHARACTER SET utf8 ;
USE `assign4` ;

-- -----------------------------------------------------
-- Table `assign4`.`package`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `assign4`.`package` (
  `idPackage` INT(11) NOT NULL AUTO_INCREMENT,
  `description` VARCHAR(45) NOT NULL,
  `name` VARCHAR(45) NOT NULL,
  `tracking` BIT(1) NOT NULL,
  `senderCity` VARCHAR(45) NOT NULL,
  `destinationCity` VARCHAR(45) NOT NULL,
  `sender` INT(11) NOT NULL,
  `receiver` INT(11) NOT NULL,
  PRIMARY KEY (`idPackage`),
  INDEX `fk_package_city_idx` (`senderCity` ASC) VISIBLE,
  INDEX `fk_package_city1_idx` (`destinationCity` ASC) VISIBLE,
  INDEX `fk_package_user1_idx` (`sender` ASC) VISIBLE,
  INDEX `fk_package_user2_idx` (`receiver` ASC) VISIBLE)
ENGINE = MyISAM
AUTO_INCREMENT = 2
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `assign4`.`route`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `assign4`.`route` (
  `idRoute` INT(11) NOT NULL AUTO_INCREMENT,
  `time` INT(11) NOT NULL,
  `city` VARCHAR(45) NOT NULL,
  `idPackage` INT(11) NOT NULL,
  PRIMARY KEY (`idRoute`),
  INDEX `fk_route_city1_idx` (`city` ASC) VISIBLE,
  INDEX `fk_route_package1_idx` (`idPackage` ASC) VISIBLE)
ENGINE = MyISAM
AUTO_INCREMENT = 2
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `assign4`.`user`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `assign4`.`user` (
  `idUser` INT(11) NOT NULL AUTO_INCREMENT,
  `isAdmin` BIT(1) NOT NULL DEFAULT b'0',
  `password` VARCHAR(45) NOT NULL,
  `username` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idUser`),
  INDEX `iduser` (`idUser` ASC) VISIBLE)
ENGINE = MyISAM
AUTO_INCREMENT = 8
DEFAULT CHARACTER SET = utf8;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
