ALTER TABLE `ivf`.`StockDrug` 
ADD COLUMN `item_sub_group_id` INT NULL AFTER `active`;


ALTER TABLE `ivf`.`Item` 
ADD COLUMN `item_code` VARCHAR(45) NULL AFTER `DUID_QTY`,
ADD COLUMN `active` VARCHAR(45) NULL AFTER `item_code`,
ADD COLUMN `Itemcol` VARCHAR(45) NULL AFTER `active`,
ADD COLUMN `item_common_name` VARCHAR(255) NULL AFTER `Itemcol`,
ADD COLUMN `item_trade_name` VARCHAR(255) NULL AFTER `item_common_name`;


CREATE TABLE `ivf_101`.`f_company_type` (
  `comp_type_id` INT NOT NULL AUTO_INCREMENT,
  `comp_type_code` VARCHAR(255) NULL,
  `comp_type_name_t` VARCHAR(255) NULL,
  `comp_type_name_e` VARCHAR(255) NULL,
  `active` VARCHAR(45) NULL,
  PRIMARY KEY (`comp_type_id`))
ENGINE = MyISAM
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin
COMMENT = 'id=400';

ALTER TABLE f_company_type AUTO_INCREMENT = 40000000;

CREATE TABLE `ivf_101`.`b_unit` (
  `unit_id` INT NOT NULL AUTO_INCREMENT,
  `unit_code` VARCHAR(255) NULL,
  `unit_name` VARCHAR(255) NULL,
  `active` VARCHAR(45) NULL,
  `date_create` VARCHAR(45) NULL,
  `date_modi` VARCHAR(45) NULL,
  `date_cancel` VARCHAR(45) NULL,
  `user_create` VARCHAR(45) NULL,
  `user_modi` VARCHAR(45) NULL,
  `user_cancel` VARCHAR(45) NULL,
  PRIMARY KEY (`unit_id`))
ENGINE = MyISAM
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin
COMMENT = 'id=401';

ALTER TABLE b_unit AUTO_INCREMENT = 40100000;

ALTER TABLE `ivf_101`.`Item` 
ADD COLUMN `purchase_point` DECIMAL(17,2) NULL COMMENT 'จุดสั่งซื้อ' AFTER `price`,
ADD COLUMN `purchase_period` DECIMAL(17,2) NULL COMMENT 'จำนวน สั่งซื้อ' AFTER `purchase_point`;

ALTER TABLE `ivf_101`.`Item` 
ADD COLUMN `cost` DECIMAL(17,2) NULL AFTER `purchase_period`;

ALTER TABLE `ivf_101`.`Item` 
CHANGE COLUMN `price` `price` DECIMAL(17,2) NULL DEFAULT NULL COMMENT 'ราคาขาย' ,
CHANGE COLUMN `cost` `cost` DECIMAL(17,2) NULL DEFAULT NULL COMMENT 'ราคาซื้อ' ;



