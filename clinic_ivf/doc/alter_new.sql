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

ALTER TABLE `ivf_101`.`t_patient`
ADD COLUMN `patient_hn_couple` VARCHAR(45) NULL AFTER `patient_country`;


ALTER TABLE `ivf_101`.`JobLabDetail`
ADD COLUMN `row1` INT NULL AFTER `active`;


ALTER TABLE `ivf_101`.`JobPxDetail`
ADD COLUMN `row1` INT NULL AFTER `EUsage`;

ALTER TABLE `ivf_101`.`JobSpecialDetail`
ADD COLUMN `row1` INT NULL AFTER `req_id`;

ALTER TABLE `ivf_101`.`PackageSold`
ADD COLUMN `row1` INT NULL AFTER `VN`;


ALTER TABLE `ivf_101`.`Agent`
ADD COLUMN `active` VARCHAR(45) NULL AFTER `AgentName`,
ADD COLUMN `remark` VARCHAR(255) NULL AFTER `active`,
ADD COLUMN `sort1` VARCHAR(45) NULL AFTER `remark`,
ADD COLUMN `date_create` VARCHAR(45) NULL AFTER `sort1`,
ADD COLUMN `date_modi` VARCHAR(45) NULL AFTER `date_create`,
ADD COLUMN `date_cancel` VARCHAR(45) NULL AFTER `date_modi`,
ADD COLUMN `user_create` VARCHAR(45) NULL AFTER `date_cancel`,
ADD COLUMN `user_modi` VARCHAR(45) NULL AFTER `user_create`,
ADD COLUMN `user_cancel` VARCHAR(45) NULL AFTER `user_modi`;


update Agent set active = '1'


ALTER TABLE `ivf_101`.`Agent`
CHANGE COLUMN `active` `active` VARCHAR(45) NULL DEFAULT '1' ;


ALTER TABLE `ivf_101`.`b_company`
ADD COLUMN `day_curr` VARCHAR(45) NULL AFTER `prefix_fet_doc`,
CHANGE COLUMN `year_curr` `year_curr` VARCHAR(55) NULL DEFAULT NULL ,
CHANGE COLUMN `month_curr` `month_curr` VARCHAR(55) NULL DEFAULT NULL ;

ALTER TABLE `ivf_101`.`PackageSold`
ADD COLUMN `payment_times` VARCHAR(45) NULL AFTER `row1`;


ALTER TABLE `ivf_101`.`BillDetail`
ADD COLUMN `item_id` INT NULL AFTER `Comment`;


CREATE TABLE `ivf_101`.`t_note` (
  `note_id` INT NOT NULL AUTO_INCREMENT,
  `note_1` VARCHAR(2000) NULL,
  `note_2` VARCHAR(2000) NULL,
  `active` VARCHAR(45) NULL,
  `remark` VARCHAR(45) NULL,
  `date_create` VARCHAR(45) NULL,
  `date_modi` VARCHAR(45) NULL,
  `date_cancel` VARCHAR(45) NULL,
  `user_create` VARCHAR(45) NULL,
  `user_modi` VARCHAR(45) NULL,
  `user_cancel` VARCHAR(45) NULL,
  `t_patient_id` INT NULL,
  PRIMARY KEY (`note_id`))
ENGINE = MyISAM
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin
COMMENT = 'id=223';

ALTER TABLE ivf.b_doc_group_sub_scan AUTO_INCREMENT = 223000000;

ALTER TABLE `ivf_101`.`t_note`
ADD COLUMN `b_service_point_id` INT NULL AFTER `t_patient_id`;

ALTER TABLE `ivf_101`.`t_note`
ADD COLUMN `status_all` VARCHAR(45) NULL AFTER `b_service_point_id`;


ALTER TABLE `ivf_101`.`t_patient`
ADD COLUMN `doctor_id` INT NULL AFTER `patient_hn_couple`;

ALTER TABLE `ivf_101`.`t_visit`
ADD COLUMN `doctor_id` INT NULL AFTER `patient_hn_male`;


CREATE TABLE `ivf_101`.`b_item_drug_instruction` (
  `instruction_id` INT NOT NULL AUTO_INCREMENT,
  `instruction_code` VARCHAR(45) NULL,
  `instruction_description_e` VARCHAR(255) NULL,
  `instruction_description_t` VARCHAR(255) NULL,
  `actice` VARCHAR(45) NULL,
  `remark` VARCHAR(45) NULL,
  `date_create` VARCHAR(45) NULL,
  `date_modi` VARCHAR(45) NULL,
  `date_cancel` VARCHAR(45) NULL,
  `user_create` VARCHAR(45) NULL,
  `user_modi` VARCHAR(45) NULL,
  `user_cancel` VARCHAR(45) NULL,
  PRIMARY KEY (`instruction_id`))
ENGINE = MyISAM
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin
COMMENT = 'id=224';

ALTER TABLE `ivf_101`.`StockDrug`
ADD COLUMN `drug_caution` VARCHAR(255) NULL COMMENT 'คำเตือน' AFTER `active`,
ADD COLUMN `drug_description` VARCHAR(255) NULL COMMENT 'คำบรรยาย' AFTER `drug_caution`,
ADD COLUMN `instruction_id` INT NULL AFTER `drug_description`,
ADD COLUMN `frequency_id` INT NULL AFTER `instruction_id`;

ALTER TABLE `ivf_101`.`StockDrug`
ADD COLUMN `drug_caution_e` VARCHAR(255) NULL AFTER `frequency_id`,
ADD COLUMN `drug_frequency_e` VARCHAR(255) NULL AFTER `drug_caution_e`;

ALTER TABLE ivf.PackageDetail AUTO_INCREMENT = 225000000;
ALTER TABLE `ivf_101`.`PackageDetail`
COMMENT = 'id=225' ;


delete from JobPx;
delete from JobPxDetail;

delete from JobLab;
delete from JobLabDetail;

delete from JobSpecial;
delete from JobSpecialDetail;
