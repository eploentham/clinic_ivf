CREATE TABLE `b_staff` (
  `staff_id` int(11) NOT NULL AUTO_INCREMENT,
  `staff_code` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `username` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `password1` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `prefix_id` int(11) DEFAULT NULL,
  `staff_fname_t` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `staff_fname_e` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `staff_lname_t` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `staff_lname_e` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `active` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `priority` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `tele` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `mobile` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `fax` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `email` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `posi_id` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `posi_name` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `remark` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `dept_id` int(11) DEFAULT NULL,
  `dept_name` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `pid` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `logo` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `status_admin` varchar(255) COLLATE utf8_bin DEFAULT NULL COMMENT '0=default; 1=user;2=admin',
  `status_module_imp_job` varchar(255) COLLATE utf8_bin DEFAULT NULL COMMENT '0=default;1=import job;',
  `status_module_exp_job` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `status_module_other_job` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `status_expense_draw` varchar(255) COLLATE utf8_bin DEFAULT NULL COMMENT 'หน้าจอเบิกเงิน',
  `status_expense_appv` varchar(255) COLLATE utf8_bin DEFAULT NULL COMMENT 'หน้าจอ อนุมัติ เบิกเงิน',
  `status_expense_pay` varchar(255) COLLATE utf8_bin DEFAULT NULL COMMENT 'หน้าจอ จ่ายเงิน',
  PRIMARY KEY (`staff_id`)
) ENGINE=MyISAM AUTO_INCREMENT=1220000001 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=122';

CREATE TABLE `b_prefix` (
  `prefix_id` int(11) NOT NULL AUTO_INCREMENT,
  `prefix_code` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `prefix_name_t` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `prefix_name_e` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `active` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `remark` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`prefix_id`)
) ENGINE=MyISAM AUTO_INCREMENT=1200000003 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=120';

CREATE TABLE `b_position` (
  `posi_id` int(11) NOT NULL AUTO_INCREMENT,
  `posi_code` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `posi_name_t` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `posi_name_e` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `dept_id` int(11) DEFAULT NULL,
  `date_create` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `active` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `remark` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `sort1` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`posi_id`)
) ENGINE=MyISAM AUTO_INCREMENT=1400000000 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=140';

CREATE TABLE `b_department` (
  `dept_id` int(11) NOT NULL AUTO_INCREMENT,
  `dept_code` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `dept_name_t` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `comp_id` int(11) DEFAULT NULL,
  `dept_parent_id` int(11) DEFAULT NULL,
  `remark` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `active` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `sort1` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`dept_id`)
) ENGINE=MyISAM AUTO_INCREMENT=1090000001 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=109';

CREATE TABLE `b_company` (
  `comp_id` int(11) NOT NULL AUTO_INCREMENT,
  `comp_code` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `comp_name_t` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `comp_name_e` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `comp_address_e` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `comp_address_t` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `addr1` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `addr2` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `amphur_id` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `district_id` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `province_id` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `zipcode` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `tele` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `fax` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `email` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `website` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `logo` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `tax_id` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `vat` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `spec1` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `qu_line1` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `qu_line2` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `qu_line3` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `qu_line4` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `qu_line5` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `qu_line6` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `inv_line1` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `inv_line2` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `inv_line3` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `inv_line4` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `inv_line5` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `inv_line6` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `po_line1` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `po_due_period` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `active` varchar(255) CHARACTER SET utf8 DEFAULT NULL,
  `remark` varchar(255) CHARACTER SET utf8 DEFAULT NULL,
  `taddr1` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `taddr2` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `taddr3` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `taddr4` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `eaddr1` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `eaddr2` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `eaddr3` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `eaddr4` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `cash_draw_doc` int(11) DEFAULT NULL COMMENT 'running ใบเบิกเงิน',
  `year_curr` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `amount_reserve` decimal(17,2) DEFAULT NULL COMMENT 'ยอดเงิน เบิกสำรองจ่าย คงเหลือ',
  `billing_doc` int(11) DEFAULT NULL COMMENT 'running invoice ใบแจ้งหนี้',
  `tax1` varchar(255) COLLATE utf8_bin DEFAULT NULL COMMENT 'อัตราภาษี หัก ณ ที่จ่าย',
  `tax3` varchar(255) COLLATE utf8_bin DEFAULT NULL COMMENT 'อัตราภาษี หัก ณ ที่จ่าย',
  `tax53` varchar(255) COLLATE utf8_bin DEFAULT NULL COMMENT 'อัตราภาษี หัก ณ ที่จ่าย',
  `receipt_doc` int(11) DEFAULT NULL COMMENT 'running ใบเสร็จรับเงิน',
  `vat_doc` int(11) DEFAULT NULL COMMENT 'running ใบกำกับภาษี',
  `billing_cover_doc` int(11) DEFAULT NULL COMMENT 'running ใบวางบิล ใบปะหน้า',
  `tax_doc` int(11) DEFAULT NULL COMMENT 'running ใบภาษีหัก ณ ที่จ่าย',
  `month_curr` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `prefix_cash_draw_doc` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `prefix_billing_doc` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `prefix_receipt_doc` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `prefix_billing_cover_doc` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `prefix_tax_doc` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `ecc_doc` int(11) DEFAULT NULL COMMENT 'expense clear cash \nเลขที่ ของ หน้าจอ ป้อน clear เงินสด ที่เบิกไป\nใช้เป็น table header ของ table t_expense_clear_cash',
  `erc_doc` int(11) DEFAULT NULL COMMENT 'หน้าจอ การเงิน เคลีย์เงินสด',
  PRIMARY KEY (`comp_id`)
) ENGINE=MyISAM AUTO_INCREMENT=1020000002 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=102';

CREATE TABLE `f_amphures` (
  `amph_id` int(11) NOT NULL AUTO_INCREMENT,
  `amph_code` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `amph_name_t` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `geo_id` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `prov_code` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `amph_name_e` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`amph_id`)
) ENGINE=MyISAM AUTO_INCREMENT=1280000000 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=128';

CREATE TABLE `f_districts` (
  `dist_id` int(11) NOT NULL AUTO_INCREMENT,
  `dist_code` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `dist_name_t` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `dist_name_e` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `amph_code` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `prov_code` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `geo_id` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `zipcode` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`dist_id`)
) ENGINE=MyISAM AUTO_INCREMENT=1290000000 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=129';

CREATE TABLE `f_provinces` (
  `prov_id` int(11) NOT NULL AUTO_INCREMENT,
  `prov_code` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `prov_name_t` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `prov_name_e` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `geo_id` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`prov_id`)
) ENGINE=MyISAM AUTO_INCREMENT=1300000000 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=130';

CREATE TABLE `f_zipcodes` (
  `id` int(11) NOT NULL,
  `dist_code` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `zipcode` varchar(255) COLLATE utf8_bin DEFAULT NULL
) ENGINE=MyISAM AUTO_INCREMENT=1310000000 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=131';



61-10-09

CREATE TABLE `ivf`.`lab_t_opu` (
  `opu_id` INT NOT NULL AUTO_INCREMENT,
  `opu_code` VARCHAR(255) NULL,
  `embryo_freez_stage` INT NULL,
  `embryoid_freez_position` VARCHAR(255) NULL,
  `hn_male` VARCHAR(255) NULL,
  `hn_female` VARCHAR(255) NULL,
  `name_male` VARCHAR(255) NULL,
  `name_female` VARCHAR(255) NULL,
  `dob_male` VARCHAR(255) NULL,
  `dob_female` VARCHAR(255) NULL,
  `doctor_id` INT NULL,
  `proce_id` INT NULL,
  `opu_date` VARCHAR(255) NULL,
  `no_of_opu` VARCHAR(255) NULL,
  `matura_date` VARCHAR(255) NULL,
  `matura_m_ii` VARCHAR(255) NULL,
  `matura_m_i` VARCHAR(255) NULL,
  `matura_gv` VARCHAR(255) NULL,
  `matura_abmormal` VARCHAR(255) NULL,
  `matura_dead` VARCHAR(255) NULL,
  `fertili_date` VARCHAR(255) NULL,
  `fertili_2_pn` VARCHAR(255) NULL,
  `fertili_1_pn` VARCHAR(255) NULL,
  `fertili_3_pn` VARCHAR(255) NULL,
  `fertili_4_pn` VARCHAR(255) NULL,
  `fertili_no_pn` VARCHAR(255) NULL,
  `fertili_dead` VARCHAR(255) NULL,
  `sperm_date` VARCHAR(255) NULL,
  `sperm_vloume` VARCHAR(255) NULL,
  `sperm_count` VARCHAR(255) NULL,
  `sperm_count_total` VARCHAR(255) NULL,
  `sperm_motile` VARCHAR(255) NULL,
  `sperm_motile_total` VARCHAR(255) NULL,
  `sperm_motility` VARCHAR(255) NULL,
  `sperm_fresh_sperm` VARCHAR(255) NULL,
  `sperm_frozen_sperm` VARCHAR(255) NULL,
  `embryo_freez_date` VARCHAR(255) NULL,
  `embryo_freez_day` VARCHAR(255) NULL,
  `embryo_freez_no_og` VARCHAR(255) NULL,
  `embryo_freez_no_of_straw` VARCHAR(255) NULL,
  `embryo_freez_mothod` VARCHAR(255) NULL,
  `embryo_freez_freeze_media` VARCHAR(255) NULL,
  `embryo_for_et_no_of_et` VARCHAR(255) NULL,
  `embbryo_for_et_day` VARCHAR(255) NULL,
  `embbryo_for_et_date` VARCHAR(255) NULL,
  `embbryo_for_et_assisted` VARCHAR(255) NULL,
  `embbryo_for_et_remark` VARCHAR(255) NULL,
  `embbryo_for_et_volume` VARCHAR(255) NULL,
  `embbryo_for_et_catheter` VARCHAR(255) NULL,
  `embbryo_for_et_doctor` VARCHAR(255) NULL,
  `embbryo_for_et_embryologist_id` INT NULL,
  `embbryo_for_et_number_of_transfer` VARCHAR(255) NULL,
  `embbryo_for_et_number_of_freeze` VARCHAR(255) NULL,
  `embbryo_for_et_number_of_discard` VARCHAR(255) NULL,
  `embryologist_report_id` INT NULL,
  `embryologist_approve_id` INT NULL,
  `date_create` VARCHAR(255) NULL,
  `date_modi` VARCHAR(255) NULL,
  `date_cancel` VARCHAR(255) NULL,
  `user_create` VARCHAR(255) NULL,
  `user_modi` VARCHAR(255) NULL,
  `user_cancel` VARCHAR(255) NULL,
  `active` VARCHAR(255) NULL,
  `remark` VARCHAR(255) NULL,
  PRIMARY KEY (`opu_id`))
ENGINE = MyISAM
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin
COMMENT = 'id=300';


CREATE TABLE `ivf`.`lab_b_procedure` (
  `proce_id` INT NOT NULL AUTO_INCREMENT,
  `proce_code` VARCHAR(255) NULL,
  `proce_name_t` VARCHAR(255) NULL,
  `proce_name_e` VARCHAR(255) NULL,
  `remark` VARCHAR(255) NULL,
  `active` VARCHAR(255) NULL,
  `date_create` VARCHAR(255) NULL,
  `date_modi` VARCHAR(255) NULL,
  `date_cancel` VARCHAR(255) NULL,
  `user_create` VARCHAR(255) NULL,
  `user_modi` VARCHAR(255) NULL,
  `user_cancel` VARCHAR(255) NULL,
  PRIMARY KEY (`proce_id`))
ENGINE = MyISAM
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin
COMMENT = 'id=301';

CREATE TABLE `ivf`.`lab_t_opu_embryo_dev` (
  `opu_embryo_dev_id` INT NOT NULL AUTO_INCREMENT,
  `opu_fet_id` INT NULL,
  `status_day` VARCHAR(255) NULL,
  `opu_embryo_dev_no` INT NULL,
  `desc` VARCHAR(2000) NULL,
  `active` VARCHAR(255) NULL,
  `remark` VARCHAR(255) NULL,
  `path_pic` VARCHAR(255) NULL,
  `date_create` VARCHAR(255) NULL,
  `date_modi` VARCHAR(255) NULL,
  `date_cancel` VARCHAR(255) NULL,
  `user_create` VARCHAR(255) NULL,
  `user_modi` VARCHAR(255) NULL,
  `user_cancel` VARCHAR(255) NULL,
  PRIMARY KEY (`opu_embryo_dev_id`))
ENGINE = MyISAM
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin
COMMENT = 'id=302';

ALTER TABLE `ivf`.`lab_b_procedure` 
ADD COLUMN `status_lab` VARCHAR(255) NULL COMMENT '1=opu, 2=fet' AFTER `user_cancel`;

ALTER TABLE `ivf`.`lab_b_procedure` 
ADD COLUMN `sort1` VARCHAR(255) NULL AFTER `status_lab`;


61-10-10
ALTER TABLE `ivf`.`lab_t_opu` 
CHANGE COLUMN `no_of_opu` `matura_no_of_opu` VARCHAR(255) NULL DEFAULT NULL ;
ALTER TABLE `ivf`.`lab_t_opu` 
ADD COLUMN `matura_post_mat` VARCHAR(255) NULL AFTER `matura_gv`;

ALTER TABLE `ivf`.`lab_t_opu` 
CHANGE COLUMN `embryo_freez_date` `embryo_freez_date_0` VARCHAR(255) NULL DEFAULT NULL ,
CHANGE COLUMN `embryo_freez_day` `embryo_freez_day_0` VARCHAR(255) NULL DEFAULT NULL ,
CHANGE COLUMN `embryo_freez_no_og` `embryo_freez_no_og_0` VARCHAR(255) NULL DEFAULT NULL ,
CHANGE COLUMN `embryo_freez_no_of_straw` `embryo_freez_no_of_straw_0` VARCHAR(255) NULL DEFAULT NULL ,
CHANGE COLUMN `embryo_freez_mothod` `embryo_freez_mothod_0` VARCHAR(255) NULL DEFAULT NULL ,
CHANGE COLUMN `embryo_freez_freeze_media` `embryo_freez_freeze_media_0` VARCHAR(255) NULL DEFAULT NULL ;

ALTER TABLE `ivf`.`lab_t_opu` 
ADD COLUMN `embryo_freez_date_1` VARCHAR(255) NULL AFTER `remark`,
ADD COLUMN `embryo_freez_day_1` VARCHAR(255) NULL AFTER `embryo_freez_date_1`,
ADD COLUMN `embryo_freez_no_og_1` VARCHAR(255) NULL AFTER `embryo_freez_day_1`,
ADD COLUMN `embryo_freez_no_of_straw_1` VARCHAR(255) NULL AFTER `embryo_freez_no_og_1`,
ADD COLUMN `embryo_freez_mothod_1` VARCHAR(255) NULL AFTER `embryo_freez_no_of_straw_1`,
ADD COLUMN `embryo_freez_freeze_media_1` VARCHAR(255) NULL AFTER `embryo_freez_mothod_1`,
ADD COLUMN `embryo_freez_stage_1` VARCHAR(45) NULL AFTER `embryo_freez_freeze_media_1`,
ADD COLUMN `embryo_freez_stage_0` VARCHAR(45) NULL AFTER `embryo_freez_stage_1`,
ADD COLUMN `embryo_freez_position_1` VARCHAR(45) NULL AFTER `embryo_freez_stage_0`,
ADD COLUMN `embryo_freez_position_0` VARCHAR(45) NULL AFTER `embryo_freez_position_1`;

ALTER TABLE `ivf`.`lab_t_opu` 
CHANGE COLUMN `embryo_freez_position_0` `embryo_freez_position_0` VARCHAR(45) NULL DEFAULT NULL AFTER `embryo_freez_freeze_media_0`,
CHANGE COLUMN `embryo_freez_stage_0` `embryo_freez_stage_0` VARCHAR(45) NULL DEFAULT NULL AFTER `embryo_freez_position_0`;

ALTER TABLE `ivf`.`lab_t_opu` 
CHANGE COLUMN `embryo_freez_stage_1` `embryo_freez_stage_1` VARCHAR(255) NULL DEFAULT NULL ,
CHANGE COLUMN `embryo_freez_position_1` `embryo_freez_position_1` VARCHAR(255) NULL DEFAULT NULL ;


ALTER TABLE `ivf`.`lab_t_opu` 
ADD COLUMN `embryo_freez_date_2` VARCHAR(255) NULL AFTER `embryo_freez_position_1`,
ADD COLUMN `embryo_freez_day_2` VARCHAR(255) NULL AFTER `embryo_freez_date_2`,
ADD COLUMN `embryo_freez_no_og_2` VARCHAR(255) NULL AFTER `embryo_freez_day_2`,
ADD COLUMN `embryo_freez_no_of_straw_2` VARCHAR(255) NULL AFTER `embryo_freez_no_og_2`,
ADD COLUMN `embryo_freez_mothod_2` VARCHAR(255) NULL AFTER `embryo_freez_no_of_straw_2`,
ADD COLUMN `embryo_freez_freeze_media_2` VARCHAR(255) NULL AFTER `embryo_freez_mothod_2`,
ADD COLUMN `embryo_freez_stage_2` VARCHAR(255) NULL AFTER `embryo_freez_freeze_media_2`,
ADD COLUMN `embryo_freez_position_2` VARCHAR(255) NULL AFTER `embryo_freez_stage_2`;

ALTER TABLE `ivf`.`lab_t_opu` 
ADD COLUMN `embryo_freez_date_3` VARCHAR(255) NULL AFTER `embryo_freez_position_2`,
ADD COLUMN `embryo_freez_day_3` VARCHAR(255) NULL AFTER `embryo_freez_date_3`,
ADD COLUMN `embryo_freez_no_og_3` VARCHAR(255) NULL AFTER `embryo_freez_day_3`,
ADD COLUMN `embryo_freez_no_of_straw_3` VARCHAR(255) NULL AFTER `embryo_freez_no_og_3`,
ADD COLUMN `embryo_freez_mothod_3` VARCHAR(255) NULL AFTER `embryo_freez_no_of_straw_3`,
ADD COLUMN `embryo_freez_freeze_media_3` VARCHAR(255) NULL AFTER `embryo_freez_mothod_3`,
ADD COLUMN `embryo_freez_stage_3` VARCHAR(255) NULL AFTER `embryo_freez_freeze_media_3`,
ADD COLUMN `embryo_freez_position_3` VARCHAR(255) NULL AFTER `embryo_freez_stage_3`;

ALTER TABLE `ivf`.`lab_t_opu` 
ADD COLUMN `embryo_freez_date_4` VARCHAR(255) NULL AFTER `embryo_freez_position_3`,
ADD COLUMN `embryo_freez_day_4` VARCHAR(255) NULL AFTER `embryo_freez_date_4`,
ADD COLUMN `embryo_freez_no_og_4` VARCHAR(255) NULL AFTER `embryo_freez_day_4`,
ADD COLUMN `embryo_freez_no_of_straw_4` VARCHAR(255) NULL AFTER `embryo_freez_no_og_4`,
ADD COLUMN `embryo_freez_mothod_4` VARCHAR(255) NULL AFTER `embryo_freez_no_of_straw_4`,
ADD COLUMN `embryo_freez_freeze_media_4` VARCHAR(255) NULL AFTER `embryo_freez_mothod_4`,
ADD COLUMN `embryo_freez_stage_4` VARCHAR(255) NULL AFTER `embryo_freez_freeze_media_4`,
ADD COLUMN `embryo_freez_position_4` VARCHAR(255) NULL AFTER `embryo_freez_stage_4`;

ALTER TABLE `ivf`.`lab_t_opu` 
ADD COLUMN `embryo_freez_date_5` VARCHAR(255) NULL AFTER `embryo_freez_position_4`,
ADD COLUMN `embryo_freez_day_5` VARCHAR(255) NULL AFTER `embryo_freez_date_5`,
ADD COLUMN `embryo_freez_no_og_5` VARCHAR(255) NULL AFTER `embryo_freez_day_5`,
ADD COLUMN `embryo_freez_no_of_straw_5` VARCHAR(255) NULL AFTER `embryo_freez_no_og_5`,
ADD COLUMN `embryo_freez_mothod_5` VARCHAR(255) NULL AFTER `embryo_freez_no_of_straw_5`,
ADD COLUMN `embryo_freez_freeze_media_5` VARCHAR(255) NULL AFTER `embryo_freez_mothod_5`,
ADD COLUMN `embryo_freez_stage_5` VARCHAR(255) NULL AFTER `embryo_freez_freeze_media_5`,
ADD COLUMN `embryo_freez_position_5` VARCHAR(255) NULL AFTER `embryo_freez_stage_5`;

ALTER TABLE `ivf`.`lab_t_opu` 
ADD COLUMN `embryo_freez_date_6` VARCHAR(255) NULL AFTER `embryo_freez_position_5`,
ADD COLUMN `embryo_freez_day_6` VARCHAR(255) NULL AFTER `embryo_freez_date_6`,
ADD COLUMN `embryo_freez_no_og_6` VARCHAR(255) NULL AFTER `embryo_freez_day_6`,
ADD COLUMN `embryo_freez_no_of_straw_6` VARCHAR(255) NULL AFTER `embryo_freez_no_og_6`,
ADD COLUMN `embryo_freez_mothod_6` VARCHAR(255) NULL AFTER `embryo_freez_no_of_straw_6`,
ADD COLUMN `embryo_freez_freeze_media_6` VARCHAR(255) NULL AFTER `embryo_freez_mothod_6`,
ADD COLUMN `embryo_freez_stage_6` VARCHAR(255) NULL AFTER `embryo_freez_freeze_media_6`,
ADD COLUMN `embryo_freez_position_6` VARCHAR(255) NULL AFTER `embryo_freez_stage_6`;