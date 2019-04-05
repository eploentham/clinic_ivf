CREATE TABLE `ivf`.`b_or_diag_group` (
  `diag_group_id` INT NOT NULL,
  `diag_group_code` VARCHAR(45) NULL,
  `diag_group_name` VARCHAR(255) NULL,
  `active` VARCHAR(45) NULL,
  `remark` VARCHAR(45) NULL,
  `date_create` VARCHAR(45) NULL,
  `date_modi` VARCHAR(45) NULL,
  `date_cancel` VARCHAR(45) NULL,
  `user_create` VARCHAR(45) NULL,
  `user_modi` VARCHAR(45) NULL,
  `user_cancel` VARCHAR(45) NULL,
  PRIMARY KEY (`diag_group_id`))
ENGINE = MyISAM
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin
COMMENT = 'id=226';

ALTER TABLE `ivf`.`b_or_diag_group` 
ADD COLUMN `status_or_diag_req` VARCHAR(45) NULL COMMENT '0=default;1= request er to or; 2= or use' AFTER `user_cancel`;

ALTER TABLE `ivf`.`b_or_diag_group` 
CHANGE COLUMN `diag_group_id` `diag_group_id` INT(11) NOT NULL AUTO_INCREMENT ;

CREATE TABLE `ivf`.`b_or_diag` (
  `diag_id` INT NOT NULL AUTO_INCREMENT,
  `diag_code` VARCHAR(45) NULL,
  `diag_code_ex` VARCHAR(45) NULL,
  `diag_name` VARCHAR(45) NULL,
  `diag_group_id` INT NULL,
  `active` VARCHAR(45) NULL,
  `remark` VARCHAR(255) NULL,
  `date_create` VARCHAR(45) NULL,
  `date_modi` VARCHAR(45) NULL,
  `date_cancel` VARCHAR(45) NULL,
  `user_create` VARCHAR(45) NULL,
  `user_modi` VARCHAR(45) NULL,
  `user_cancel` VARCHAR(45) NULL,
  PRIMARY KEY (`diag_id`))
ENGINE = MyISAM
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin
COMMENT = 'id=227';


CREATE TABLE `ivf`.`b_or_anesthesia` (
  `anesthesia_id` INT NOT NULL AUTO_INCREMENT,
  `anesthesia_code` VARCHAR(45) NULL,
  `anesthesia_code_ex` VARCHAR(45) NULL,
  `anesthesia_name` VARCHAR(255) NULL,
  `active` VARCHAR(45) NULL,
  `remark` VARCHAR(45) NULL,
  `date_create` VARCHAR(45) NULL,
  `date_modi` VARCHAR(45) NULL,
  `date_cancel` VARCHAR(45) NULL,
  `user_create` VARCHAR(45) NULL,
  `user_modi` VARCHAR(45) NULL,
  `user_cancel` VARCHAR(45) NULL,
  PRIMARY KEY (`anesthesia_id`))
ENGINE = MyISAM
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin
COMMENT = 'id=228';

CREATE TABLE `ivf`.`or_t_request` (
  `or_req_id` INT NOT NULL AUTO_INCREMENT,
  `or_req_code` VARCHAR(45) NULL,
  `or_req_date` VARCHAR(45) NULL,
  `patient_hn` VARCHAR(45) NULL,
  `patient_name` VARCHAR(45) NULL,
  `doctor_anesthesia_id` INT NULL,
  `doctor_surgical_id` INT NULL,
  `or_date` VARCHAR(45) NULL,
  `or_time` VARCHAR(45) NULL,
  `status_or` VARCHAR(45) NULL COMMENT '0=default;1= ด่วนที่สุด;2=ภายในวันนี้;3=ภายในวันนี้ ระบุเวลา;4=ระบุวันเวลา',
  `or_t_requestcol` VARCHAR(45) NULL,
  `or_t_requestcol1` VARCHAR(45) NULL,
  `b_service_point_id` INT NULL,
  `or_id` INT NULL,
  `active` VARCHAR(45) NULL,
  `remark` VARCHAR(45) NULL,
  `date_create` VARCHAR(45) NULL,
  `date_modi` VARCHAR(45) NULL,
  `date_cancel` VARCHAR(45) NULL,
  `user_create` VARCHAR(45) NULL,
  `user_modi` VARCHAR(45) NULL,
  `user_cancel` VARCHAR(45) NULL,
  PRIMARY KEY (`or_req_id`))
ENGINE = MyISAM
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin
COMMENT = 'id=229';

ALTER TABLE `ivf_101`.`b_or_diag_group` 
RENAME TO  `ivf_101`.`or_b_diag_group` ;

ALTER TABLE `ivf_101`.`b_or_diag` 
RENAME TO  `ivf_101`.`or_b_diag` ;

ALTER TABLE `ivf_101`.`b_or_anesthesia` 
RENAME TO  `ivf_101`.`or_b_anesthesia` ;

ALTER TABLE `ivf_101`.`or_b_diag_group` 
ADD COLUMN `sort1` VARCHAR(45) NULL AFTER `status_or_diag_req`;

ALTER TABLE `ivf_101`.`or_b_diag` 
ADD COLUMN `sort1` VARCHAR(45) NULL AFTER `user_cancel`;

ALTER TABLE `ivf_101`.`or_b_anesthesia` 
ADD COLUMN `sort1` VARCHAR(45) NULL AFTER `user_cancel`;


ALTER TABLE `ivf_101`.`or_b_diag_group` 
ADD COLUMN `status_or_us` VARCHAR(45) NULL COMMENT '0=default;1= or use' AFTER `sort1`,
CHANGE COLUMN `status_or_diag_req` `status_or_diag_req` VARCHAR(45) NULL DEFAULT NULL COMMENT '0=default;1= request er to or; ' ;

ALTER TABLE `ivf_101`.`or_t_request` 
CHANGE COLUMN `or_t_requestcol` `diag_id` INT NULL DEFAULT NULL ;

ALTER TABLE `ivf_101`.`or_t_request` 
CHANGE COLUMN `or_t_requestcol1` `t_patient_id` INT NULL DEFAULT NULL ;

ALTER TABLE `ivf_101`.`or_t_request` 
ADD COLUMN `status_urgent` VARCHAR(45) NULL COMMENT '0=default;1= ด่วนที่สุด;2=ภายในวันนี้;3=ภายในวันนี้ ระบุเวลา;4=ระบุวันเวลา' AFTER `user_cancel`,
CHANGE COLUMN `status_or` `status_or` VARCHAR(45) NULL DEFAULT NULL COMMENT '0=default;1= send or; 2=or receive;3= or set commit date operation' ;

ALTER TABLE `ivf_101`.`or_t_request` 
CHANGE COLUMN `status_urgent` `status_urgent` VARCHAR(45) NULL DEFAULT NULL COMMENT '0=default;1= ด่วนที่สุด;2=normal' ;

ALTER TABLE `ivf_101`.`or_b_diag` 
CHANGE COLUMN `diag_id` `opera_id` INT(11) NOT NULL AUTO_INCREMENT ,
CHANGE COLUMN `diag_code` `opera_code` VARCHAR(45) NULL DEFAULT NULL ,
CHANGE COLUMN `diag_code_ex` `opera_code_ex` VARCHAR(45) NULL DEFAULT NULL ,
CHANGE COLUMN `diag_name` `opera_name` VARCHAR(45) NULL DEFAULT NULL ,
CHANGE COLUMN `diag_group_id` `opera_group_id` INT(11) NULL DEFAULT NULL , RENAME TO  `ivf_101`.`or_b_operation` ;

ALTER TABLE `ivf_101`.`or_b_diag_group` 
CHANGE COLUMN `diag_group_id` `opera_group_id` INT(11) NOT NULL AUTO_INCREMENT ,
CHANGE COLUMN `diag_group_code` `opera_group_code` VARCHAR(45) NULL DEFAULT NULL ,
CHANGE COLUMN `diag_group_name` `opera_group_name` VARCHAR(255) NULL DEFAULT NULL ,
CHANGE COLUMN `status_or_diag_req` `status_or_opera_req` VARCHAR(45) NULL DEFAULT NULL COMMENT '0=default;1= request er to or; ' , RENAME TO  `ivf_101`.`or_b_operation_group` ;

ALTER TABLE `ivf_101`.`or_t_request` 
ADD COLUMN `anesthesia_id` INT NULL AFTER `status_urgent`;

ALTER TABLE `ivf_101`.`b_staff` 
ADD COLUMN `status_doctor` VARCHAR(45) NULL COMMENT '0=default;1=doctor' AFTER `status_module_medicalrecord`,
ADD COLUMN `doctor_id` VARCHAR(45) NULL COMMENT 'รหัส ว แพทย์' AFTER `status_doctor`;

ALTER TABLE `ivf_101`.`or_t_request` 
CHANGE COLUMN `diag_id` `opera_id` INT(11) NULL DEFAULT NULL ;

CREATE TABLE `or_t_operation` (
  `or_id` int(11) NOT NULL AUTO_INCREMENT,
  `or_code` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `or_req_id` int(11) DEFAULT NULL,
  `patient_hn` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `patient_name` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `doctor_anesthesia_id` int(11) DEFAULT NULL,
  `doctor_surgical_id` int(11) DEFAULT NULL,
  `or_date` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `or_time` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `status_or` varchar(45) COLLATE utf8_bin DEFAULT NULL COMMENT '0=default;1= send or; 2=or receive;3= or set commit date operation',
  `opera_id` int(11) DEFAULT NULL,
  `t_patient_id` int(11) DEFAULT NULL,
  `b_service_point_id` int(11) DEFAULT NULL,
  `active` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `remark` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `status_urgent` varchar(45) COLLATE utf8_bin DEFAULT NULL COMMENT '0=default;1= ด่วนที่สุด;2=normal',
  `anesthesia_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`or_id`)
) ENGINE=MyISAM AUTO_INCREMENT=230000000 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=230';

ALTER TABLE ivf_101.or_t_operation AUTO_INCREMENT = 230000000;













