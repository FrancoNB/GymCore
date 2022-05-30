-- MySQL Script generated by MySQL Workbench
-- Mon May 30 16:28:02 2022
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema GymCore
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema GymCore
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `GymCore` DEFAULT CHARACTER SET utf8 ;
USE `GymCore` ;

-- -----------------------------------------------------
-- Table `GymCore`.`Clients`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `GymCore`.`Clients` (
  `idClients` INT NOT NULL AUTO_INCREMENT,
  `RegisterDate` DATE NOT NULL,
  `Name` VARCHAR(100) NOT NULL,
  `Surname` VARCHAR(100) NOT NULL,
  `Locality` VARCHAR(255) NOT NULL,
  `Address` VARCHAR(255) NOT NULL,
  `Phone` VARCHAR(45) NOT NULL,
  `Mail` VARCHAR(100) NOT NULL,
  `Observations` VARCHAR(255) NOT NULL,
  PRIMARY KEY (`idClients`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `GymCore`.`CurrentAccounts`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `GymCore`.`CurrentAccounts` (
  `idCurrentAccounts` INT NOT NULL AUTO_INCREMENT,
  `TicketCode` VARCHAR(45) NULL,
  `Date` DATE NULL,
  `Credit` DOUBLE NULL,
  `Debit` DOUBLE NULL,
  `Balance` DOUBLE NULL,
  `Detail` VARCHAR(255) NULL,
  `Clients_idClients` INT NOT NULL,
  PRIMARY KEY (`idCurrentAccounts`),
  INDEX `fk_CurrentAccounts_Clients1_idx` (`Clients_idClients` ASC) VISIBLE,
  CONSTRAINT `fk_CurrentAccounts_Clients1`
    FOREIGN KEY (`Clients_idClients`)
    REFERENCES `GymCore`.`Clients` (`idClients`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `GymCore`.`Subscriptions`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `GymCore`.`Subscriptions` (
  `idSubscriptions` INT NOT NULL AUTO_INCREMENT,
  `TicketCode` VARCHAR(45) NULL,
  `StartDate` DATE NULL,
  `Package` VARCHAR(100) NULL,
  `Price` DOUBLE NULL,
  `TotalSessions` INT NULL,
  `UsedSessions` INT NULL,
  `AvailableSessions` INT NULL,
  `EndDate` DATE NULL,
  `ExpireDate` DATE NULL,
  `Observations` VARCHAR(255) NULL,
  `State` VARCHAR(45) NULL,
  `Clients_idClients` INT NOT NULL,
  `CurrentAccounts_idCurrentAccounts` INT NOT NULL,
  PRIMARY KEY (`idSubscriptions`),
  INDEX `fk_Subscriptions_Clients_idx` (`Clients_idClients` ASC) VISIBLE,
  INDEX `fk_Subscriptions_CurrentAccounts1_idx` (`CurrentAccounts_idCurrentAccounts` ASC) VISIBLE,
  CONSTRAINT `fk_Subscriptions_Clients`
    FOREIGN KEY (`Clients_idClients`)
    REFERENCES `GymCore`.`Clients` (`idClients`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Subscriptions_CurrentAccounts1`
    FOREIGN KEY (`CurrentAccounts_idCurrentAccounts`)
    REFERENCES `GymCore`.`CurrentAccounts` (`idCurrentAccounts`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `GymCore`.`Packages`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `GymCore`.`Packages` (
  `idPackages` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(100) NULL,
  `NumberSessions` INT NULL,
  `AvailableDays` INT NULL,
  `Price` DOUBLE NULL,
  PRIMARY KEY (`idPackages`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `GymCore`.`Payments`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `GymCore`.`Payments` (
  `idPayments` INT NOT NULL AUTO_INCREMENT,
  `TicketCode` VARCHAR(45) NULL,
  `Date` DATE NULL,
  `PaymentMethod` VARCHAR(100) NULL,
  `Amount` DOUBLE NULL,
  `Observations` VARCHAR(255) NULL,
  `Clients_idClients` INT NOT NULL,
  `CurrentAccounts_idCurrentAccounts` INT NOT NULL,
  PRIMARY KEY (`idPayments`),
  INDEX `fk_Payments_Clients1_idx` (`Clients_idClients` ASC) VISIBLE,
  INDEX `fk_Payments_CurrentAccounts1_idx` (`CurrentAccounts_idCurrentAccounts` ASC) VISIBLE,
  CONSTRAINT `fk_Payments_Clients1`
    FOREIGN KEY (`Clients_idClients`)
    REFERENCES `GymCore`.`Clients` (`idClients`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Payments_CurrentAccounts1`
    FOREIGN KEY (`CurrentAccounts_idCurrentAccounts`)
    REFERENCES `GymCore`.`CurrentAccounts` (`idCurrentAccounts`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `GymCore`.`Users`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `GymCore`.`Users` (
  `idUsers` INT NOT NULL AUTO_INCREMENT,
  `RegisterDate` DATE NULL,
  `Type` VARCHAR(45) NULL,
  `Username` VARCHAR(100) NULL,
  `Password` VARCHAR(100) NULL,
  `LastConnection` DATETIME NULL,
  PRIMARY KEY (`idUsers`),
  UNIQUE INDEX `Username_UNIQUE` (`Username` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `GymCore`.`Assists`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `GymCore`.`Assists` (
  `idAssists` INT NOT NULL AUTO_INCREMENT,
  `Date` DATE NULL,
  `Clients_idClients` INT NOT NULL,
  `Subscriptions_idSubscriptions` INT NOT NULL,
  PRIMARY KEY (`idAssists`),
  INDEX `fk_Assists_Clients1_idx` (`Clients_idClients` ASC) VISIBLE,
  INDEX `fk_Assists_Subscriptions1_idx` (`Subscriptions_idSubscriptions` ASC) VISIBLE,
  CONSTRAINT `fk_Assists_Clients1`
    FOREIGN KEY (`Clients_idClients`)
    REFERENCES `GymCore`.`Clients` (`idClients`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Assists_Subscriptions1`
    FOREIGN KEY (`Subscriptions_idSubscriptions`)
    REFERENCES `GymCore`.`Subscriptions` (`idSubscriptions`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `GymCore`.`Exercises`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `GymCore`.`Exercises` (
  `idExercises` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(100) NULL,
  `Detail` VARCHAR(255) NULL,
  `QuadricepsPoints` INT NULL,
  `HamstringPoints` INT NULL,
  `CalvesPoints` INT NULL,
  `ButtocksPoints` INT NULL,
  `TrapeziusPoints` INT NULL,
  `DorsalsPoints` INT NULL,
  `LumbarsPoints` INT NULL,
  `PectaralsPoints` INT NULL,
  `AbdominalsPoints` INT NULL,
  `ObliquesPoints` INT NULL,
  `BicepsPoints` INT NULL,
  `TricepsPoints` INT NULL,
  `ForeArmPoints` INT NULL,
  `PosteriorDeltoidPoints` INT NULL,
  `LateralDeltoidPoints` INT NULL,
  `AnteriorDeltoidPoints` INT NULL,
  `AdductorPoints` INT NULL,
  PRIMARY KEY (`idExercises`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `GymCore`.`Works`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `GymCore`.`Works` (
  `idWorks` INT NOT NULL AUTO_INCREMENT,
  `Series` INT NULL,
  `Duration` INT NULL,
  `Repetitions` INT NULL,
  `RestTime` INT NULL,
  `Load` DOUBLE NULL,
  `Intensity` INT NULL,
  `Exercises_idExercises` INT NOT NULL,
  PRIMARY KEY (`idWorks`),
  INDEX `fk_Works_Exercises1_idx` (`Exercises_idExercises` ASC) VISIBLE,
  CONSTRAINT `fk_Works_Exercises1`
    FOREIGN KEY (`Exercises_idExercises`)
    REFERENCES `GymCore`.`Exercises` (`idExercises`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `GymCore`.`WorkPlans`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `GymCore`.`WorkPlans` (
  `idWorkPlans` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(100) NULL,
  `Category` VARCHAR(100) NULL,
  PRIMARY KEY (`idWorkPlans`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `GymCore`.`Routine`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `GymCore`.`Routine` (
  `idRoutine` INT NOT NULL AUTO_INCREMENT,
  `StartDate` DATE NULL,
  `EndDate` DATE NULL,
  `State` VARCHAR(45) NULL,
  `Clients_idClients` INT NOT NULL,
  `WorkPlans_idWorkPlans` INT NOT NULL,
  PRIMARY KEY (`idRoutine`),
  INDEX `fk_Routine_Clients1_idx` (`Clients_idClients` ASC) VISIBLE,
  INDEX `fk_Routine_WorkPlans1_idx` (`WorkPlans_idWorkPlans` ASC) VISIBLE,
  CONSTRAINT `fk_Routine_Clients1`
    FOREIGN KEY (`Clients_idClients`)
    REFERENCES `GymCore`.`Clients` (`idClients`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Routine_WorkPlans1`
    FOREIGN KEY (`WorkPlans_idWorkPlans`)
    REFERENCES `GymCore`.`WorkPlans` (`idWorkPlans`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `GymCore`.`WorkPlansDetail`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `GymCore`.`WorkPlansDetail` (
  `idWorkPlansDetail` INT NOT NULL AUTO_INCREMENT,
  `Day` INT NULL,
  `WorkPlans_idWorkPlans` INT NOT NULL,
  `Works_idWorks` INT NOT NULL,
  PRIMARY KEY (`idWorkPlansDetail`),
  INDEX `fk_WorkPlansDetail_WorkPlans1_idx` (`WorkPlans_idWorkPlans` ASC) VISIBLE,
  INDEX `fk_WorkPlansDetail_Works1_idx` (`Works_idWorks` ASC) VISIBLE,
  CONSTRAINT `fk_WorkPlansDetail_WorkPlans1`
    FOREIGN KEY (`WorkPlans_idWorkPlans`)
    REFERENCES `GymCore`.`WorkPlans` (`idWorkPlans`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_WorkPlansDetail_Works1`
    FOREIGN KEY (`Works_idWorks`)
    REFERENCES `GymCore`.`Works` (`idWorks`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
