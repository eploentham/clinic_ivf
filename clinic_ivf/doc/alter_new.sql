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


delete from JobPx1;
delete from JobPxDetail1;

delete from JobLab1;
delete from JobLabDetail1;

delete from JobSpecial1;
delete from JobSpecialDetail1;

19-04-16
ALTER TABLE `ivf_101`.`LabItemGroup` 
ADD COLUMN `active` VARCHAR(45) NULL DEFAULT '1' AFTER `LGName`;

19-04-23
INSERT INTO `ivf_101`.`f_doc_type` (`doc_type_code`, `doc_type_name`, `active`, `status_combo`) VALUES ('Follicle', 'Follicle', '1', 'egg_sti_rt_ovary1');
INSERT INTO `ivf_101`.`f_doc_type` (`doc_type_code`, `doc_type_name`, `active`, `status_combo`) VALUES ('Follicle Other1', 'Follicle Other1', '1', 'egg_sti_rt_ovary1');
INSERT INTO `ivf_101`.`f_doc_type` (`doc_type_code`, `doc_type_name`, `active`, `status_combo`) VALUES ('Follicle Other2', 'Follicle Other2', '1', 'egg_sti_rt_ovary1');
INSERT INTO `ivf_101`.`f_doc_type` (`doc_type_code`, `doc_type_name`, `active`, `status_combo`) VALUES ('Follicle Other3', 'Follicle Other3', '1', 'egg_sti_rt_ovary1');
INSERT INTO `ivf_101`.`f_doc_type` (`doc_type_code`, `doc_type_name`, `active`, `status_combo`) VALUES ('2-3', '2-3', '1', 'egg_sti_rt_ovary2');
INSERT INTO `ivf_101`.`f_doc_type` (`doc_type_code`, `doc_type_name`, `active`, `status_combo`) VALUES ('3-4', '3-4', '1', 'egg_sti_rt_ovary2');
INSERT INTO `ivf_101`.`f_doc_type` (`doc_type_code`, `doc_type_name`, `active`, `status_combo`) VALUES ('5-6', '5-6', '1', 'egg_sti_rt_ovary2');
INSERT INTO `ivf_101`.`f_doc_type` (`doc_type_code`, `doc_type_name`, `active`, `status_combo`) VALUES ('7-8', '7-8', '1', 'egg_sti_rt_ovary2');
INSERT INTO `ivf_101`.`f_doc_type` (`doc_type_code`, `doc_type_name`, `active`, `status_combo`) VALUES ('9-10', '9-10', '1', 'egg_sti_rt_ovary2');
INSERT INTO `ivf_101`.`f_doc_type` (`doc_type_code`, `doc_type_name`, `active`, `status_combo`) VALUES ('11-12', '11-12', '1', 'egg_sti_rt_ovary2');
INSERT INTO `ivf_101`.`f_doc_type` (`doc_type_code`, `doc_type_name`, `active`, `status_combo`) VALUES ('13-14', '13-14', '1', 'egg_sti_rt_ovary2');
INSERT INTO `ivf_101`.`f_doc_type` (`doc_type_code`, `doc_type_name`, `active`, `status_combo`) VALUES ('15-16', '15-16', '1', 'egg_sti_rt_ovary2');
INSERT INTO `ivf_101`.`f_doc_type` (`doc_type_code`, `doc_type_name`, `active`, `status_combo`) VALUES ('17-18', '17-18', '1', 'egg_sti_rt_ovary2');
INSERT INTO `ivf_101`.`f_doc_type` (`doc_type_code`, `doc_type_name`, `active`, `status_combo`) VALUES ('18-19', '18-19', '1', 'egg_sti_rt_ovary2');
INSERT INTO `ivf_101`.`f_doc_type` (`doc_type_code`, `doc_type_name`, `active`, `status_combo`) VALUES ('19-20', '19-20', '1', 'egg_sti_rt_ovary2');
INSERT INTO `ivf_101`.`f_doc_type` (`doc_type_code`, `doc_type_name`, `active`, `status_combo`) VALUES ('FT 300 + IVF-M75U', 'FT 300 + IVF-M75U', '1', 'egg_sti_medication');
INSERT INTO `ivf_101`.`f_doc_type` (`doc_type_code`, `doc_type_name`, `active`, `status_combo`) VALUES ('FT 300 + IVF-M150U', 'FT 300 + IVF-M150U', '1', 'egg_sti_medication');
INSERT INTO `ivf_101`.`f_doc_type` (`doc_type_code`, `doc_type_name`, `active`, `status_combo`) VALUES ('FT 300U', 'FT 300U', '1', 'egg_sti_medication');
INSERT INTO `ivf_101`.`f_doc_type` (`doc_type_code`, `doc_type_name`, `active`, `status_combo`) VALUES ('FT 225U', 'FT 225U', '1', 'egg_sti_medication');
INSERT INTO `ivf_101`.`f_doc_type` (`doc_type_code`, `doc_type_name`, `active`, `status_combo`) VALUES ('FT 150U', 'FT 150U', '1', 'egg_sti_medication');
INSERT INTO `ivf_101`.`f_doc_type` (`doc_type_code`, `doc_type_name`, `active`, `status_combo`) VALUES ('FT 75U', 'FT 75U', '1', 'egg_sti_medication');
INSERT INTO `ivf_101`.`f_doc_type` (`doc_type_code`, `doc_type_name`, `active`, `status_combo`) VALUES ('GF 350U', 'GF 350U', '1', 'egg_sti_medication');
INSERT INTO `ivf_101`.`f_doc_type` (`doc_type_code`, `doc_type_name`, `active`, `status_combo`) VALUES ('GF 350U + IVF-M 75U', 'GF 350U + IVF-M 75U', '1', 'egg_sti_medication');
INSERT INTO `ivf_101`.`f_doc_type` (`doc_type_code`, `doc_type_name`, `active`, `status_combo`) VALUES ('GF 350U + IVF-M 150U', 'GF 350U + IVF-M 150U', '1', 'egg_sti_medication');
INSERT INTO `ivf_101`.`f_doc_type` (`doc_type_code`, `doc_type_name`, `active`, `status_combo`) VALUES ('GF 300U', 'GF 300U', '1', 'egg_sti_medication');
INSERT INTO `ivf_101`.`f_doc_type` (`doc_type_code`, `doc_type_name`, `active`, `status_combo`) VALUES ('GF 225U', 'GF 225U', '1', 'egg_sti_medication');
INSERT INTO `ivf_101`.`f_doc_type` (`doc_type_code`, `doc_type_name`, `active`, `status_combo`) VALUES ('GF 175U', 'GF 175U', '1', 'egg_sti_medication');
INSERT INTO `ivf_101`.`f_doc_type` (`doc_type_code`, `doc_type_name`, `active`, `status_combo`) VALUES ('IVF-M 225U', 'IVF-M 225U', '1', 'egg_sti_medication');
INSERT INTO `ivf_101`.`f_doc_type` (`doc_type_code`, `doc_type_name`, `active`, `status_combo`) VALUES ('IVF-M 150U', 'IVF-M 150U', '1', 'egg_sti_medication');
INSERT INTO `ivf_101`.`f_doc_type` (`doc_type_code`, `doc_type_name`, `active`, `status_combo`) VALUES ('IVF-M 75U', 'IVF-M 75U', '1', 'egg_sti_medication');

CREATE TABLE `ivf_101`.`nurse_t_egg_sti` (
  `egg_sti_id` INT NOT NULL AUTO_INCREMENT,
  `lmp_date` VARCHAR(45) NULL,
  `nurse_t_egg_sticol` VARCHAR(45) NULL,
  `status_g` VARCHAR(45) NULL,
  `p` VARCHAR(45) NULL,
  `a` VARCHAR(45) NULL,
  `g` VARCHAR(45) NULL,
  `active` VARCHAR(45) NULL,
  `date_create` VARCHAR(45) NULL,
  `date_modi` VARCHAR(45) NULL,
  `date_cancel` VARCHAR(45) NULL,
  `user_create` VARCHAR(45) NULL,
  `user_modi` VARCHAR(45) NULL,
  `user_cancel` VARCHAR(45) NULL,
  PRIMARY KEY (`egg_sti_id`))
ENGINE = MyISAM
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin
COMMENT = 'id=226';

CREATE TABLE `ivf_101`.`nurse_t_egg_sti_day` (
  `egg_sti_day_id` INT NOT NULL AUTO_INCREMENT,
  `egg_sti_id` VARCHAR(45) NULL,
  `day` VARCHAR(45) NULL,
  `date` VARCHAR(45) NULL,
  `e2` VARCHAR(45) NULL,
  `lh` VARCHAR(45) NULL,
  `fsh` VARCHAR(45) NULL,
  `prolactin` VARCHAR(45) NULL,
  `rt_ovary_1` VARCHAR(45) NULL,
  `rt_ovary_2` VARCHAR(45) NULL,
  `lt_ovary_1` VARCHAR(45) NULL,
  `lt_ovary_2` VARCHAR(45) NULL,
  `endo` VARCHAR(45) NULL,
  `medication` VARCHAR(45) NULL,
  `active` VARCHAR(45) NULL,
  `date_create` VARCHAR(45) NULL,
  `date_modi` VARCHAR(45) NULL,
  `date_cancel` VARCHAR(45) NULL,
  `user_create` VARCHAR(45) NULL,
  `user_modi` VARCHAR(45) NULL,
  `user_cancel` VARCHAR(45) NULL,
  PRIMARY KEY (`egg_sti_day_id`))
ENGINE = MyISAM
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin
COMMENT = 'id=227';

ALTER TABLE `ivf_101`.`nurse_t_egg_sti` 
ADD COLUMN `opu_date` VARCHAR(45) NULL AFTER `user_cancel`,
ADD COLUMN `opu_time` VARCHAR(45) NULL AFTER `opu_date`,
ADD COLUMN `et` VARCHAR(255) NULL AFTER `opu_time`,
ADD COLUMN `fet` VARCHAR(255) NULL AFTER `et`,
ADD COLUMN `bhcg_test` VARCHAR(255) NULL AFTER `fet`;

ALTER TABLE `ivf_101`.`nurse_t_egg_sti` 
ADD COLUMN `remark` VARCHAR(255) NULL AFTER `bhcg_test`;

ALTER TABLE `ivf_101`.`nurse_t_egg_sti` 
ADD COLUMN `t_patient_id` INT NULL AFTER `remark`,
ADD COLUMN `t_visit_id` INT NULL AFTER `t_patient_id`;

ALTER TABLE `ivf_101`.`nurse_t_egg_sti` 
ADD COLUMN `egg_sti_date` VARCHAR(45) NULL AFTER `t_visit_id`;


ALTER TABLE `ivf_101`.`nurse_t_egg_sti` 
CHANGE COLUMN `t_patient_id` `t_patient_id` INT(11) NULL DEFAULT NULL AFTER `lmp_date`,
CHANGE COLUMN `t_visit_id` `t_visit_id` INT(11) NULL DEFAULT NULL AFTER `t_patient_id`,
CHANGE COLUMN `egg_sti_date` `egg_sti_date` VARCHAR(45) NULL DEFAULT NULL AFTER `t_visit_id`;

ALTER TABLE nurse_t_egg_sti AUTO_INCREMENT = 22600000;
ALTER TABLE nurse_t_egg_sti_day AUTO_INCREMENT = 22700000;

ALTER TABLE `ivf_101`.`nurse_t_egg_sti_day` 
CHANGE COLUMN `day` `day1` VARCHAR(45) NULL DEFAULT NULL ;

ALTER TABLE `ivf_101`.`nurse_t_egg_sti_day` 
ADD COLUMN `remark` VARCHAR(255) NULL AFTER `user_cancel`;

ALTER TABLE `ivf_101`.`nurse_t_egg_sti` 
ADD COLUMN `doctor_id` INT NULL AFTER `remark`;

ALTER TABLE `ivf_101`.`nurse_t_egg_sti` 
ADD COLUMN `status_abnormal` VARCHAR(45) NULL AFTER `doctor_id`,
ADD COLUMN `abnormal1` VARCHAR(255) NULL AFTER `status_abnormal`,
ADD COLUMN `abnormal2` VARCHAR(255) NULL AFTER `abnormal1`,
ADD COLUMN `status_typing` VARCHAR(45) NULL AFTER `abnormal2`,
ADD COLUMN `status_typing_other` VARCHAR(45) NULL AFTER `status_typing`,
ADD COLUMN `typing_other` VARCHAR(255) NULL AFTER `status_typing_other`,
ADD COLUMN `status_infectious` VARCHAR(45) NULL AFTER `typing_other`,
ADD COLUMN `status_add_lab` VARCHAR(45) NULL AFTER `status_infectious`,
ADD COLUMN `add_lab` VARCHAR(255) NULL AFTER `status_add_lab`;

19-04-27
ALTER TABLE `ivf_101`.`b_staff` 
ADD COLUMN `doctor_id_old` VARCHAR(45) NULL COMMENT 'รหัสแพทย์ ระบบเก่า' AFTER `doctor_id`;

UPDATE `ivf_101`.`b_staff` SET `doctor_id_old` = '1' WHERE (`staff_id` = '1220000041');
UPDATE `ivf_101`.`b_staff` SET `doctor_id_old` = '2' WHERE (`staff_id` = '1220000042');

19-05-03
ALTER TABLE `ivf_101`.`nurse_t_egg_sti` 
ADD COLUMN `day_start` VARCHAR(45) NULL AFTER `add_lab`;

INSERT INTO `ivf_101`.`f_doc_type` (`doc_type_code`, `doc_type_name`, `active`, `status_combo`) VALUES ('Cereotide', 'Cereotide', '1', 'egg_sti_medication2');
INSERT INTO `ivf_101`.`f_doc_type` (`doc_type_code`, `doc_type_name`, `active`, `status_combo`) VALUES ('Orgalutan', 'Orgalutan', '1', 'egg_sti_medication2');
INSERT INTO `ivf_101`.`f_doc_type` (`doc_type_code`, `doc_type_name`, `active`, `status_combo`) VALUES ('Cetrotide+Oridvel(250mg)', 'Cetrotide+Oridvel(250mg)', '1', 'egg_sti_medication2');
INSERT INTO `ivf_101`.`f_doc_type` (`doc_type_code`, `doc_type_name`, `active`, `status_combo`) VALUES ('Cetrotide+dip+pregnyl', 'Cetrotide+dip+pregnyl', '1', 'egg_sti_medication2');
INSERT INTO `ivf_101`.`f_doc_type` (`doc_type_code`, `doc_type_name`, `active`, `status_combo`) VALUES ('Orgalutan+Dip+pregnyl', 'Orgalutan+Dip+pregnyl', '1', 'egg_sti_medication2');
INSERT INTO `ivf_101`.`f_doc_type` (`doc_type_code`, `doc_type_name`, `active`, `status_combo`) VALUES ('Oridrel 250mg', 'Oridrel 250mg', '1', 'egg_sti_medication2');
INSERT INTO `ivf_101`.`f_doc_type` (`doc_type_code`, `doc_type_name`, `active`, `status_combo`) VALUES ('Dip 0.0+Pregnyl 1500u', 'Dip 0.0+Pregnyl 1500u', '1', 'egg_sti_medication2');
INSERT INTO `ivf_101`.`f_doc_type` (`doc_type_code`, `doc_type_name`, `active`, `status_combo`) VALUES ('Pregnyl 500u', 'Pregnyl 500u', '1', 'egg_sti_medication2');

ALTER TABLE `ivf_101`.`nurse_t_egg_sti_day` 
ADD COLUMN `medication2` VARCHAR(45) NULL AFTER `remark`;

19-05-06
ALTER TABLE `ivf_101`.`t_visit` 
ADD COLUMN `status_cashier` VARCHAR(45) NULL COMMENT '0=default;1=operation;2=finish operation' AFTER `doctor_id`;

ALTER TABLE `ivf_101`.`BillHeader` 
ADD COLUMN `receipt_no` VARCHAR(45) NULL AFTER `IntLock`,
ADD COLUMN `receipt_cover_no` VARCHAR(45) NULL AFTER `receipt_no`;


19-05-11
ALTER TABLE `ivf_101`.`StockDrug` 
ADD COLUMN `on_hand` DECIMAL(17,2) NULL COMMENT 'คงเหลือ' AFTER `item_sub_group_id`,
ADD COLUMN `order_point` DECIMAL(17,2) NULL COMMENT 'จุดสั่งซื้อ' AFTER `on_hand`,
ADD COLUMN `order_amount` DECIMAL(17,2) NULL COMMENT 'จำนวนสั่งซื้อ' AFTER `order_point`,
ADD COLUMN `on_hand_sub_1` DECIMAL(17,2) NULL COMMENT 'คงเหลือ' AFTER `order_amount`,
ADD COLUMN `order_point_sub_1` DECIMAL(17,2) NULL COMMENT 'จุดสั่งซื้อ' AFTER `on_hand_sub_1`,
ADD COLUMN `order_amount_sub_1` DECIMAL(17,2) NULL COMMENT 'จำนวนสั่งซื้อ' AFTER `order_point_sub_1`,
ADD COLUMN `on_hand_sub_2` DECIMAL(17,2) NULL COMMENT 'คงเหลือ' AFTER `order_amount_sub_1`,
ADD COLUMN `order_point_sub_2` DECIMAL(17,2) NULL COMMENT 'จุดสั่งซื้อ' AFTER `on_hand_sub_2`,
ADD COLUMN `order_amount_sub_2` DECIMAL(17,2) NULL COMMENT 'จำนวนสั่งซื้อ' AFTER `order_point_sub_2`,
ADD COLUMN `on_hand_sub_3` DECIMAL(17,2) NULL COMMENT 'คงเหลือ' AFTER `order_amount_sub_2`,
ADD COLUMN `order_point_sub_3` DECIMAL(17,2) NULL COMMENT 'จุดสั่งซื้อ' AFTER `on_hand_sub_3`,
ADD COLUMN `order_amount_sub_3` DECIMAL(17,2) NULL COMMENT 'จำนวนสั่งซื้อ' AFTER `order_point_sub_3`;


CREATE TABLE `ivf_101`.`b_stock_name` (
  `stock_name_id` INT NOT NULL AUTO_INCREMENT,
  `stock_name` VARCHAR(45) NULL,
  `stock_column_name` VARCHAR(45) NULL,
  `active` VARCHAR(45) NULL,
  `remark` VARCHAR(45) NULL,
  `date_create` VARCHAR(45) NULL,
  `date_modi` VARCHAR(45) NULL,
  `date_cancel` VARCHAR(45) NULL,
  `user_create` VARCHAR(45) NULL,
  `user_modi` VARCHAR(45) NULL,
  `user_cancel` VARCHAR(45) NULL,
  `sort1` VARCHAR(45) NULL,
  PRIMARY KEY (`stock_name_id`))
ENGINE = MyISAM
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin
COMMENT = 'id=228';

ALTER TABLE `ivf_101`.`StockDrug` 
COMMENT = 'id=229' ;

ALTER TABLE `ivf_101`.StockDrug AUTO_INCREMENT = 22900000;

ALTER TABLE `ivf`.`b_stock_name` 
CHANGE COLUMN `stock_name_id` `stock_sub_name_id` INT(11) NOT NULL AUTO_INCREMENT ,
CHANGE COLUMN `stock_name` `stock_sub_name` VARCHAR(45) NULL DEFAULT NULL ,
CHANGE COLUMN `stock_column_name` `stock_sub_column_name` VARCHAR(45) NULL DEFAULT NULL , RENAME TO  `ivf`.`b_stock_sub_name` ;

ALTER TABLE `ivf_101`.`t_goods_draw` 
RENAME TO  `ivf_101`.`t_stock_draw` ;

ALTER TABLE `ivf_101`.`t_goods_draw_detail` 
RENAME TO  `ivf_101`.`t_stock_draw_detail` ;

ALTER TABLE `ivf_101`.`t_goods_rec` 
RENAME TO  `ivf_101`.`t_stock_rec` ;

ALTER TABLE `ivf_101`.`t_goods_rec_detail` 
RENAME TO  `ivf_101`.`t_stock_rec_detail` ;

ALTER TABLE `ivf_101`.`t_goods_return` 
RENAME TO  `ivf_101`.`t_stock_return` ;

ALTER TABLE `ivf_101`.`t_goods_return_detail` 
RENAME TO  `ivf_101`.`t_stock_return_detail` ;

CREATE TABLE `ivf_101`.`b_customer` (
  `cust_id` int(11) NOT NULL AUTO_INCREMENT,
  `org_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL COMMENT 'เป็นรหัส cust_id แต่ถ้า field นี้มีค่า \nหมายถึง ข้อมูลบริษัทนี้ เป็นเป็นบริษัทลูก ของบริษัท ที่ใช้รหัสนี้',
  `cust_code` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `cust_name_t` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `cust_name_e` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `active` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `address_t` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `address_e` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `addr` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `amphur_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `district_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `province_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `zipcode` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `sale_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `sale_name_t` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `fax` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `tele` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `email` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `tax_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `remark` varchar(2000) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `contact_name1` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `contact_name2` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `contact_name1_tel` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `contact_name2_tel` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `remark2` varchar(2000) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `po_due_period` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `taddr1` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `taddr2` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `taddr3` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `taddr4` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `eaddr1` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `eaddr2` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `eaddr3` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `eaddr4` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `sort1` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `status_cust` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `status_imp` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `status_exp` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `status_fwd` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `status_cons_imp` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `status_cons_exp` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `status_supp` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `status_insr` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `status_company` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL COMMENT '0=default; 1=customer ในประเทศ; 2=customer ต่างประเทศ ',
  `status_vendor` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `web_site1` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL COMMENT 'web cargo tracking',
  `web_site2` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL COMMENT 'web checking return emptry container',
  `web_site3` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL COMMENT 'web company',
  `insr_id` int(11) DEFAULT NULL,
  `status_truck` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL COMMENT 'บริษัทรับขนส่ง',
  `status_container_yard` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL COMMENT 'ลานคืนตู้',
  PRIMARY KEY (`cust_id`)
) ENGINE=MyISAM AUTO_INCREMENT=230000000 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=230';


CREATE TABLE `ivf_101`.`b_customer_remark` (
  `remark_id` int(11) NOT NULL AUTO_INCREMENT,
  `cust_id` int(11) DEFAULT NULL,
  `remark` varchar(2000) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `remark2` varchar(2000) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `active` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `sort1` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `status_show1` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `status_show2` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `status_show3` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`remark_id`)
) ENGINE=MyISAM AUTO_INCREMENT=231000000 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=231';

CREATE TABLE `ivf_101`.`b_customer_tax_invoice` (
  `tax_invoice_id` int(11) NOT NULL AUTO_INCREMENT,
  `cust_id` int(11) DEFAULT NULL,
  `tax_invoice_name_t` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `tax_invoice_name_e` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `tax_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `active` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `sort1` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`tax_invoice_id`)
) ENGINE=MyISAM AUTO_INCREMENT=232000000 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=232';

CREATE TABLE `ivf_101`.`b_address` (
  `address_id` int(11) NOT NULL AUTO_INCREMENT,
  `address_code` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `address_name` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `line_t1` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `line_t2` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `line_t3` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `line_t4` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `line_e1` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `line_e2` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `line_e3` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `line_e4` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `prov_id` int(11) DEFAULT NULL,
  `amphur_id` int(11) DEFAULT NULL,
  `district_id` int(11) DEFAULT NULL,
  `zipcode` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `email` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `email2` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `tele` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `mobile` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `fax` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `remark` varchar(2000) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `address_type_id` int(11) DEFAULT NULL,
  `table_id` int(11) DEFAULT NULL,
  `active` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `contact_id` int(11) DEFAULT NULL,
  `contact_name1` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `contact_name_tel1` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `contact_id2` int(11) DEFAULT NULL,
  `contact_name2` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `contact_name_tel2` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `web_site1` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `web_site2` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `google_map` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `status_default_customer` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL COMMENT 'ใช่เป็นที่อยู่ default บริษัท',
  `remark2` varchar(2000) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `time_open_close` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL COMMENT 'เวลาทำการ',
  `time_open_close_over_time` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL COMMENT 'เวลาเปิดล่วงเวลา',
  `web_site3` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `over_time` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `rate_over_time` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `map_pic_path` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `status_place_addr` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL COMMENT 'สถานที่ส่งของ',
  `status_container_yard` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL COMMENT 'ลานคืนตู้',
  `status_tax` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`address_id`)
) ENGINE=MyISAM AUTO_INCREMENT=233000000 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=233';

CREATE TABLE `ivf_101`.`b_address_type` (
  `address_type_id` int(11) NOT NULL AUTO_INCREMENT,
  `address_name_t` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `address_name_e` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `active` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`address_type_id`)
) ENGINE=MyISAM AUTO_INCREMENT=234000000 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=234';

CREATE TABLE `ivf_101`.`b_bank` (
  `bank_id` int(11) NOT NULL AUTO_INCREMENT,
  `bank_code` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `bank_name_t` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `bank_name_e` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `active` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `sort1` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`bank_id`)
) ENGINE=MyISAM AUTO_INCREMENT=235000000 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=235';

CREATE TABLE `ivf_101`.`b_bank_book` (
  `bank_book_id` int(11) NOT NULL AUTO_INCREMENT,
  `bank_id` int(11) DEFAULT NULL,
  `bank_book_name_t` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `bank_book_name_e` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `actvice` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `book_no` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`bank_book_id`)
) ENGINE=MyISAM AUTO_INCREMENT=236000000 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=236';

CREATE TABLE `ivf_101`.`b_company_bank` (
  `comp_bank_id` int(11) NOT NULL AUTO_INCREMENT,
  `comp_id` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `comp_bank_name_t` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `comp_bank_branch` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `comp_bank_active` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `acc_number` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `date_modi` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `date_cancel` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `user_create` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `user_modi` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `user_cancel` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `active` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `bank_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`comp_bank_id`)
) ENGINE=MyISAM AUTO_INCREMENT=237000000 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=237';

CREATE TABLE `ivf_101`.`b_contact` (
  `contact_id` int(11) NOT NULL AUTO_INCREMENT,
  `cust_id` int(11) DEFAULT NULL,
  `contact_code` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `username` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `password1` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `prefix_id` int(11) DEFAULT NULL,
  `contact_fname_t` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `contact_fname_e` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `contact_lname_t` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `contact_lname_e` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `active` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `priority` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `tele` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `mobile` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `fax` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `email` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `posi_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `posi_name` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `remark` varchar(2000) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `email2` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `nick_name` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL COMMENT 'ชื่อเล่น',
  `work_response` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL COMMENT 'งานที่รับผิดชอบ',
  `table_id` int(11) DEFAULT NULL,
  `status_insr_email` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`contact_id`)
) ENGINE=MyISAM AUTO_INCREMENT=238000000 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=238';

62-05-29
CREATE TABLE `BillHeader_1` (
	`bill_id` int(11) NOT NULL AUTO_INCREMENT,
  `VN` bigint(20) DEFAULT '0',
  `BillNo` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `PName` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `Date` date DEFAULT NULL,
  `Time` time DEFAULT NULL,
  `PID` bigint(20) DEFAULT NULL,
  `PIDS` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `Include_Pkg_Price` decimal(10,2) DEFAULT NULL,
  `Extra_Pkg_Price` decimal(10,2) DEFAULT NULL,
  `Total` decimal(10,2) DEFAULT NULL,
  `Discount` decimal(10,2) DEFAULT NULL,
  `CreditCardType` int(11) DEFAULT NULL,
  `CreditCardNumber` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `Status` int(11) DEFAULT NULL,
  `CreditAgent` int(11) DEFAULT NULL,
  `OName` varchar(250) COLLATE utf8_bin DEFAULT NULL,
  `BID` bigint(20) DEFAULT NULL,
  `PaymentBy` varchar(255) COLLATE utf8_bin DEFAULT 'NULL',
  `CashID` int(11) DEFAULT '0',
  `CreditCardID` int(11) DEFAULT '0',
  `SepCash` decimal(10,2) DEFAULT '0.00',
  `SepCredit` decimal(10,2) DEFAULT '0.00',
  `ExtBillNo` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `IntLock` int(11) NOT NULL DEFAULT '0',
  `receipt_no` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `receipt_cover_no` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`bill_id`)
)  ENGINE=MyISAM AUTO_INCREMENT=2390000000 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=239';

RENAME TABLE ivf_101.BillHeader TO ivf_101.BillHeader_old;
RENAME TABLE ivf_101.BillHeader_1 TO ivf_101.BillHeader;

ALTER TABLE `ivf_101`.`BillHeader` 
ADD COLUMN `active` VARCHAR(45) NULL AFTER `receipt_cover_no`,
ADD COLUMN `remark` VARCHAR(45) NULL AFTER `active`,
ADD COLUMN `date_create` VARCHAR(45) NULL AFTER `remark`,
ADD COLUMN `date_modi` VARCHAR(45) NULL AFTER `date_create`,
ADD COLUMN `date_cancel` VARCHAR(45) NULL AFTER `date_modi`,
ADD COLUMN `user_create` VARCHAR(45) NULL AFTER `date_cancel`,
ADD COLUMN `user_modi` VARCHAR(45) NULL AFTER `user_create`,
ADD COLUMN `user_cancel` VARCHAR(45) NULL AFTER `user_modi`;

ALTER TABLE `ivf_101`.`BillDetail` 
ADD COLUMN `active` VARCHAR(45) NULL AFTER `qty`,
ADD COLUMN `remark` VARCHAR(45) NULL AFTER `active`,
ADD COLUMN `sort1` VARCHAR(45) NULL AFTER `remark`,
ADD COLUMN `date_create` VARCHAR(45) NULL AFTER `sort1`,
ADD COLUMN `date_modi` VARCHAR(45) NULL AFTER `date_create`,
ADD COLUMN `date_cancel` VARCHAR(45) NULL AFTER `date_modi`,
ADD COLUMN `user_create` VARCHAR(45) NULL AFTER `date_cancel`,
ADD COLUMN `user_modi` VARCHAR(45) NULL AFTER `user_create`,
ADD COLUMN `use_cancel` VARCHAR(45) NULL AFTER `user_modi`,
ADD COLUMN `bill_id` INT NULL AFTER `use_cancel`;


CREATE TABLE `ivf_101_donor`.`lab_b_order_group` (
  `lab_order_group_id` BIGINT NOT NULL AUTO_INCREMENT,
  `lab_id` INT NULL,
  `active` VARCHAR(45) NULL,
  `remark` VARCHAR(45) NULL,
  `date_create` VARCHAR(45) NULL,
  `date_modi` VARCHAR(45) NULL,
  `date_cancel` VARCHAR(45) NULL,
  `user_create` VARCHAR(45) NULL,
  `user_modi` VARCHAR(45) NULL,
  `user_cancel` VARCHAR(45) NULL,
  PRIMARY KEY (`lab_order_group_id`))
ENGINE = MyISAM
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin
COMMENT = 'id=241';

ALTER TABLE `ivf_101_donor`.`lab_b_order_group` 
ADD COLUMN `sort1` VARCHAR(45) NULL AFTER `user_cancel`;

ALTER TABLE `ivf_101`.`lab_b_order_group` 
ADD COLUMN `qty` DECIMAL(17,2) NULL AFTER `lab_order_id`;


CREATE TABLE `ivf_101_donor`.`t_closeday` (
  `closeday_id` BIGINT NOT NULL AUTO_INCREMENT,
  `closeday_date` VARCHAR(45) NULL COMMENT 'วันที่ปิดเวร',
  `cnt_patient` DECIMAL(17,2) NULL COMMENT 'จำนวนคนไข้',
  `amt_cash` DECIMAL(17,2) NULL,
  `amt_credit_card` DECIMAL(17,2) NULL,
  `amount` DECIMAL(17,2) NULL,
  `expense_1` DECIMAL(17,2) NULL COMMENT 'ค่าใช้จ่าย',
  `expense_2` DECIMAL(17,2) NULL COMMENT 'ค่าใช้จ่าย',
  `expense_3` DECIMAL(17,2) NULL COMMENT 'ค่าใช้จ่าย',
  `expense_4` DECIMAL(17,2) NULL COMMENT 'ค่าใช้จ่าย',
  `expense_5` DECIMAL(17,2) NULL COMMENT 'ค่าใช้จ่าย',
  `total_cash` DECIMAL(17,2) NULL COMMENT 'ยอดคงเหลือหลังหักค่าใช้จ่าย',
  `active` VARCHAR(45) NULL,
  `remark` VARCHAR(45) NULL,
  `date_create` VARCHAR(45) NULL,
  `date_modi` VARCHAR(45) NULL,
  `date_cancel` VARCHAR(45) NULL,
  `user_create` VARCHAR(45) NULL,
  `user_modi` VARCHAR(45) NULL,
  `user_cancel` VARCHAR(45) NULL,
  PRIMARY KEY (`closeday_id`))
ENGINE = MyISAM
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin
COMMENT = 'id=244';

ALTER TABLE `ivf_101_donor`.`t_closeday` AUTO_INCREMENT = 244000000;

ALTER TABLE `ivf_101`.`t_closeday` 
ADD COLUMN `deposit` DECIMAL(17,2) NULL COMMENT 'เงินฝาก' AFTER `expense_5`;

CREATE TABLE  `ivf_101`.`t_closeday_bill` (
  `bill_id` bigint(20) NOT NULL AUTO_INCREMENT,
  `VN` bigint(20) DEFAULT NULL,
  `BillNo` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `PName` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Date` date DEFAULT NULL,
  `Time` time DEFAULT NULL,
  `PID` bigint(20) DEFAULT NULL,
  `PIDS` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Include_Pkg_Price` decimal(10,2) DEFAULT NULL,
  `Extra_Pkg_Price` decimal(10,2) DEFAULT NULL,
  `Total` decimal(10,2) DEFAULT NULL,
  `Discount` decimal(10,2) DEFAULT NULL,
  `CreditCardType` int(11) DEFAULT NULL,
  `CreditCardNumber` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Status` int(11) DEFAULT NULL,
  `CreditAgent` int(11) DEFAULT NULL,
  `OName` varchar(250) COLLATE utf8_unicode_ci DEFAULT NULL,
  `BID` bigint(20) DEFAULT NULL,
  `PaymentBy` varchar(255) COLLATE utf8_unicode_ci DEFAULT 'NULL',
  `CashID` int(11) DEFAULT '0',
  `CreditCardID` int(11) DEFAULT '0',
  `SepCash` decimal(10,2) DEFAULT '0.00',
  `SepCredit` decimal(10,2) DEFAULT '0.00',
  `ExtBillNo` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `IntLock` int(11) NOT NULL DEFAULT '0',
  `receipt_no` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL,
  `receipt_cover_no` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL,
  `active` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL,
  `remark` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `date_create` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL,
  `date_modi` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL,
  `date_cancel` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL,
  `user_create` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL,
  `user_modi` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL,
  `user_cancel` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL,
  `cash` decimal(10,2) DEFAULT NULL,
  `credit` decimal(10,2) DEFAULT NULL,
  `closeday_id` bigint(20) DEFAULT '0',
  PRIMARY KEY (`bill_id`)
) ENGINE=MyISAM AUTO_INCREMENT=2460000000 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci COMMENT='id=246';


CREATE TABLE `ivf_101_donor`.`t_closeday_bill_detail` (
  `ID` bigint(20) NOT NULL AUTO_INCREMENT,
  `VN` bigint(20) DEFAULT NULL,
  `Name` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Extra` int(11) DEFAULT NULL,
  `Price` decimal(10,2) DEFAULT NULL,
  `Total` decimal(10,2) DEFAULT NULL,
  `GroupType` varchar(250) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Comment` text COLLATE utf8_unicode_ci,
  `item_id` int(11) DEFAULT NULL,
  `status` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL,
  `pcksid` int(11) DEFAULT NULL,
  `price1` decimal(17,2) DEFAULT NULL,
  `qty` decimal(17,2) DEFAULT NULL,
  `active` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL,
  `remark` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `sort1` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL,
  `date_create` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL,
  `date_modi` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL,
  `date_cancel` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL,
  `user_create` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL,
  `user_modi` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL,
  `user_cancel` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL,
  `bill_id` bigint(20) DEFAULT NULL,
  `closeday_id` bigint(20) DEFAULT '0',
  `bill_group_id` bigint(20) DEFAULT '0',
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM AUTO_INCREMENT=1620 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
