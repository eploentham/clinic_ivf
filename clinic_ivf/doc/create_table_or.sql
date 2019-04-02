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










