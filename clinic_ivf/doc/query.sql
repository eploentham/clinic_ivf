id_table=220  b_queue;


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
COMMENT = 'id=200';


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
COMMENT = 'id=201';

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
COMMENT = 'id=202';

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

CREATE TABLE `ivf`.`lab_t_request` (
  `req_id` INT NOT NULL AUTO_INCREMENT,
  `req_code` VARCHAR(255) NULL,
  `req_date` VARCHAR(255) NULL,
  `hn_male` VARCHAR(255) NULL,
  `name_male` VARCHAR(255) NULL,
  `hn_female` VARCHAR(255) NULL,
  `name_female` VARCHAR(255) NULL,
  `status_req` VARCHAR(255) NULL COMMENT '0=default, 1= req,2=accept req, 4=start req,5=result',
  `accept_date` VARCHAR(255) NULL,
  `start_date` VARCHAR(255) NULL,
  `result_date` VARCHAR(255) NULL,
  `visit_id` VARCHAR(255) NULL,
  `vn` VARCHAR(255) NULL,
  `active` VARCHAR(255) NULL,
  `remark` VARCHAR(255) NULL,
  `date_create` VARCHAR(255) NULL,
  `date_modi` VARCHAR(255) NULL,
  `date_cancel` VARCHAR(255) NULL,
  `user_create` VARCHAR(255) NULL,
  `user_modi` VARCHAR(255) NULL,
  `user_cancel` VARCHAR(255) NULL,
  `item_id` INT NULL,
  PRIMARY KEY (`req_id`))
ENGINE = MyISAM
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin
COMMENT = 'id=204';


CREATE TABLE `f_item_group` (
  `item_group_id` int(11) NOT NULL AUTO_INCREMENT,
  `item_group_code` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `item_group_name_t` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `item_group_name_e` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`item_group_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=205';



CREATE TABLE `ivf`.`b_item_sub_group` (
  `item_sub_group_id` INT NOT NULL AUTO_INCREMENT,
  `item_sub_group_code` VARCHAR(45) NULL,
  `item_sub_group_name_t` VARCHAR(45) NULL,
  `item_sub_group_name_e` VARCHAR(45) NULL,
  `b_item_sub_groupcol` VARCHAR(45) NULL,
  `item_group_id` INT NULL,
  `active` VARCHAR(45) NULL,
  `remark` VARCHAR(45) NULL,
  `date_create` VARCHAR(45) NULL,
  `date_modi` VARCHAR(45) NULL,
  `date_cancel` VARCHAR(45) NULL,
  `user_create` VARCHAR(45) NULL,
  `user_modi` VARCHAR(45) NULL,
  `user_cancel` VARCHAR(45) NULL,
  PRIMARY KEY (`item_sub_group_id`))
ENGINE = MyISAM
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin
COMMENT = 'id=206';

ALTER TABLE `ivf`.`f_item_group` 
CHARACTER SET = utf8 , COLLATE = utf8_bin , ENGINE = MyISAM ;


61-10-11

ALTER TABLE f_item_group AUTO_INCREMENT = 2050000000;
ALTER TABLE b_item_sub_group AUTO_INCREMENT = 2060000000;

INSERT INTO `ivf`.`f_item_group` (`item_group_code`, `item_group_name_t`) VALUES ('1', 'ยา');
INSERT INTO `ivf`.`f_item_group` (`item_group_code`, `item_group_name_t`) VALUES ('2', 'LAB');
INSERT INTO `ivf`.`f_item_group` (`item_group_code`, `item_group_name_t`) VALUES ('3', 'X-RAY');
INSERT INTO `ivf`.`f_item_group` (`item_group_code`, `item_group_name_t`) VALUES ('4', 'เวชภัณฑ์');
INSERT INTO `ivf`.`f_item_group` (`item_group_code`, `item_group_name_t`) VALUES ('5', 'ค่าบริการ');

CREATE TABLE `ivf`.`b_item` (
  `item_id` INT NOT NULL AUTO_INCREMENT,
  `item_code` VARCHAR(255) NULL,
  `item_name_t` VARCHAR(255) NULL,
  `item_name_e` VARCHAR(255) NULL,
  `b_itemcol` VARCHAR(255) NULL,
  `item_sub_group_id` INT NULL,
  `item_common_name` VARCHAR(255) NULL,
  `item_trade_name` VARCHAR(255) NULL,
  `item_nick_name` VARCHAR(255) NULL,
  `item_billing_subgroop_id` INT NULL,
  `item_secret` VARCHAR(255) NULL,
  `active` VARCHAR(255) NULL,
  `remark` VARCHAR(255) NULL,
  `date_create` VARCHAR(255) NULL,
  `date_modi` VARCHAR(255) NULL,
  `date_cancel` VARCHAR(255) NULL,
  `user_create` VARCHAR(255) NULL,
  `user_modi` VARCHAR(255) NULL,
  `user_cancel` VARCHAR(255) NULL,
  PRIMARY KEY (`item_id`))
ENGINE = MyISAM
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin
COMMENT = 'id=207';

INSERT INTO `ivf`.`b_item_sub_group` (`item_sub_group_code`, `item_sub_group_name_t`, `item_group_id`, `active`) VALUES ('CDR01', 'ยาในบัญชียาหลัก', '1', '1');
INSERT INTO `ivf`.`b_item_sub_group` (`item_sub_group_code`, `item_sub_group_name_t`, `item_group_id`, `active`) VALUES ('CDR02', 'ยานอกบัญชียาหลัก', '1', '1');
INSERT INTO `ivf`.`b_item_sub_group` (`item_sub_group_code`, `item_sub_group_name_t`, `item_group_id`, `active`) VALUES ('CLR01', 'LAB', '3', '1');
INSERT INTO `ivf`.`b_item_sub_group` (`item_sub_group_code`, `item_sub_group_name_t`, `item_group_id`, `active`) VALUES ('CXR01', 'X-RAY', '2', '1');

CREATE TABLE `ivf`.`f_item_billing_group` (
  `item_billing_group_id` INT NOT NULL AUTO_INCREMENT,
  `item_billing_group_code` VARCHAR(255) NULL,
  `item_billing_group_name_t` VARCHAR(255) NULL,
  `item_billing_group_name_e` VARCHAR(255) NULL,
  PRIMARY KEY (`item_billing_group_id`))
ENGINE = MyISAM
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin
COMMENT = 'id=208';
ALTER TABLE f_item_billing_group AUTO_INCREMENT = 2080000000;

ALTER TABLE `ivf`.`b_company` 
CHANGE COLUMN `tax_doc` `req_doc` INT(11) NULL DEFAULT NULL COMMENT 'running ใบภาษีหัก ณ ที่จ่าย' ,
CHANGE COLUMN `prefix_tax_doc` `prefix_req_doc` VARCHAR(255) CHARACTER SET 'utf8' COLLATE 'utf8_bin' NULL DEFAULT NULL ;

UPDATE `ivf`.`b_item_sub_group` SET `item_group_id` = '2' WHERE (`item_sub_group_id` = '2060000002');
UPDATE `ivf`.`b_item_sub_group` SET `item_group_id` = '3' WHERE (`item_sub_group_id` = '2060000003');


INSERT INTO `ivf`.`b_item` (`item_code`, `item_name_t`, `item_name_e`, `active`) VALUES ('l0001', 'LAB OPU', 'LAB OPU', '1');
INSERT INTO `ivf`.`b_item` (`item_code`, `item_name_t`, `item_name_e`, `active`) VALUES ('l0002', 'LAB FET', 'LAB FET', '1');

61-10-12

ALTER TABLE `ivf`.`lab_b_procedure` 
ADD COLUMN `sort1` VARCHAR(45) NULL AFTER `user_cancel`;

ALTER TABLE `ivf`.`b_staff` 
ADD COLUMN `password_confirm` VARCHAR(255) NULL AFTER `status_expense_pay`;
UPDATE `ivf`.`b_staff` SET `password_confirm` = '1618' WHERE (`staff_id` = '1220000001');

INSERT INTO `ivf`.`b_company` (`comp_code`, `vat`, `year_curr`, `prefix_req_doc`) VALUES ('001', '7', '2018', 'REQ');

61-10-13
ALTER TABLE `ivf`.`lab_t_request` 
ADD COLUMN `accept_staff_id` INT NULL AFTER `item_id`,
ADD COLUMN `start_staff_id` INT NULL AFTER `accept_staff_id`,
ADD COLUMN `result_staff_id` INT NULL AFTER `start_staff_id`;


61-10-16
ALTER TABLE `ivf`.`b_staff` 
ADD COLUMN `accept_staff_id` INT NULL AFTER `password_confirm`,
ADD COLUMN `start_staff_id` INT NULL AFTER `accept_staff_id`,
ADD COLUMN `result_staff_id` INT NULL AFTER `start_staff_id`;

ALTER TABLE `ivf`.`lab_t_request` 
COMMENT = 'id=204' ;
ALTER TABLE `ivf`.`lab_t_opu_embryo_dev` 
COMMENT = 'id=202' ;
ALTER TABLE `ivf`.`lab_t_opu` 
COMMENT = 'id=200' ;
UPDATE `ivf`.`b_company` SET `active` = '1' WHERE (`comp_id` = '1020000002');

61-10-17
ALTER TABLE `ivf`.`b_company` 
CHANGE COLUMN `prefix_cash_draw_doc` `prefix_opu_doc` VARCHAR(255) CHARACTER SET 'utf8' COLLATE 'utf8_bin' NULL DEFAULT NULL ,
CHANGE COLUMN `ecc_doc` `opu_doc` INT(11) NULL DEFAULT NULL COMMENT 'expense clear cash \\nเลขที่ ของ หน้าจอ ป้อน clear เงินสด ที่เบิกไป\\nใช้เป็น table header ของ table t_expense_clear_cash' ;
UPDATE `ivf`.`b_company` SET `prefix_opu_doc` = 'OPU', `opu_doc` = '0' WHERE (`comp_id` = '1020000002');
ALTER TABLE `ivf`.`lab_t_opu` 
ADD COLUMN `req_id` INT NULL AFTER `embryo_freez_position_6`;
ALTER TABLE `ivf`.`b_prefix` 
ADD COLUMN `status_doctor` VARCHAR(255) NULL AFTER `remark`;




61-10-19
ALTER TABLE f_patient_religion AUTO_INCREMENT = 2180000000;
INSERT INTO `ivf`.`f_patient_religion` (`patient_religion_description`) VALUES ('พุทธ');
INSERT INTO `ivf`.`f_patient_religion` (`patient_religion_description`) VALUES ('อิสลาม');
INSERT INTO `ivf`.`f_patient_religion` (`patient_religion_description`) VALUES ('คริสต์');
INSERT INTO `ivf`.`f_patient_religion` (`patient_religion_description`) VALUES ('ฮินดู');
INSERT INTO `ivf`.`f_patient_religion` (`patient_religion_description`) VALUES ('ขงจื้อ');
INSERT INTO `ivf`.`f_patient_religion` (`patient_religion_description`) VALUES ('ไม่นับถือศาสนา');
INSERT INTO `ivf`.`f_patient_religion` (`patient_religion_description`) VALUES ('อื่นๆ');
INSERT INTO `ivf`.`f_patient_religion` (`patient_religion_description`) VALUES ('ไม่ทราบ');

UPDATE `ivf`.`f_patient_blood_group` SET `patient_blood_group_description` = 'ไม่ระบุ' WHERE (`f_patient_blood_group_id` = '2140000001');
INSERT INTO `ivf`.`f_patient_blood_group` (`patient_blood_group_description`) VALUES ('A');
INSERT INTO `ivf`.`f_patient_blood_group` (`patient_blood_group_description`) VALUES ('B');
INSERT INTO `ivf`.`f_patient_blood_group` (`patient_blood_group_description`) VALUES ('AB');
INSERT INTO `ivf`.`f_patient_blood_group` (`patient_blood_group_description`) VALUES ('O');

ALTER TABLE f_patient_relation AUTO_INCREMENT = 219000000;
DELETE FROM `ivf`.`f_patient_relation` WHERE (`f_patient_relation_id` = '2147483647');
INSERT INTO `ivf`.`f_patient_relation` (`patient_relation_description`) VALUES ('ไม่ระบุ');
INSERT INTO `ivf`.`f_patient_relation` (`patient_relation_description`) VALUES ('บิดา');
INSERT INTO `ivf`.`f_patient_relation` (`patient_relation_description`) VALUES ('มารดา');
INSERT INTO `ivf`.`f_patient_relation` (`patient_relation_description`) VALUES ('พี่');
INSERT INTO `ivf`.`f_patient_relation` (`patient_relation_description`) VALUES ('น้อง');
INSERT INTO `ivf`.`f_patient_relation` (`patient_relation_description`) VALUES ('ลุง');
INSERT INTO `ivf`.`f_patient_relation` (`patient_relation_description`) VALUES ('ป้า');
INSERT INTO `ivf`.`f_patient_relation` (`patient_relation_description`) VALUES ('น้า');
INSERT INTO `ivf`.`f_patient_relation` (`patient_relation_description`) VALUES ('อา');
INSERT INTO `ivf`.`f_patient_relation` (`patient_relation_description`) VALUES ('เพื่อน');
INSERT INTO `ivf`.`f_patient_relation` (`patient_relation_description`) VALUES ('ภรรยา');
INSERT INTO `ivf`.`f_patient_relation` (`patient_relation_description`) VALUES ('สามี');
INSERT INTO `ivf`.`f_patient_relation` (`patient_relation_description`) VALUES ('ยาย');
INSERT INTO `ivf`.`f_patient_relation` (`patient_relation_description`) VALUES ('แฟน');
INSERT INTO `ivf`.`f_patient_relation` (`patient_relation_description`) VALUES ('คนรู้จัก');
INSERT INTO `ivf`.`f_patient_relation` (`patient_relation_description`) VALUES ('ลูก');
INSERT INTO `ivf`.`f_patient_relation` (`patient_relation_description`) VALUES ('ตนเอง');

ALTER TABLE f_patient_race AUTO_INCREMENT = 217000000;
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('ไม่ระบุ');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('อังกฤษ');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('โปรตุเกส');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('เนเธอร์แลนด์');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('เยอรมัน');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('ฝรั่งเศส');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('เดนมาร์ก');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('สวีเดน');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('ไนจีเรีย');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('สหรัฐอาหรับเอมิเรตส์');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('กินี');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('สวีสเซอร์แลนด์');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('ปาปัวนิวกินี');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('ม้ง');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('เมี่ยน');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('อิตาลี');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('รอให้สัญชาติไทย*');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('นอร์เวย์');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('อัฟกัน');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('บาห์เรน');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('ภูฏาน');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('จอร์แดน');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('เกาหลีเหนือ');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('มัลดีฟ');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('มองโกเลีย');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('โอมาน');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('กาตาร์');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('เยเมน');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('ออสเตรีย');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('เยเมน(ใต้)**');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('หมู่เกาะฟิจิ');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('คิริบาส');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('นาอูรู');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('หมู่เกาะโซโลมอน');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('ตองก้า');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('ตูวาลู');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('วานูอาตู');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('ซามัว');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('แอลเบเนีย');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('ไอร์แลนด์');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('อันดอร์รา');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('เยอรมนีตะวันออก**');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('ไอซ์แลนด์');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('ลิกเตนสไตน์');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('โมนาโก');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('ซานมารีโน');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('บริติช');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('แอลจีเรีย');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('แองโกลา');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('เบนิน');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('ฟินแลนด์');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('บอตสวานา');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('บูร์กินาฟาโซ');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('บุรุนดี');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('แคเมอรูน');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('เคปเวิร์ด');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('แอฟริกากลาง');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('ชาด');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('คอโมโรส');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('คองโก');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('โกตดิวัวร์');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('เบลเยี่ยม');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('จิบูตี');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('อิเควทอเรียลกินี');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('กาบอง');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('แกมเบีย');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('กานา');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('กินีบีสเซา');
INSERT INTO `ivf`.`f_patient_race` (`patient_race_description`) VALUES ('เลโซโท');


INSERT INTO `ivf`.`f_patient_prefix` (`patient_prefix_description`) VALUES ('ไม่ระบุ');
INSERT INTO `ivf`.`f_patient_prefix` (`patient_prefix_description`) VALUES ('ด.ช.');
INSERT INTO `ivf`.`f_patient_prefix` (`patient_prefix_description`) VALUES ('ด.ญ.');
INSERT INTO `ivf`.`f_patient_prefix` (`patient_prefix_description`) VALUES ('นาย');
INSERT INTO `ivf`.`f_patient_prefix` (`patient_prefix_description`) VALUES ('นางสาว');
INSERT INTO `ivf`.`f_patient_prefix` (`patient_prefix_description`) VALUES ('นาง');


INSERT INTO `ivf`.`f_patient_occupation` (`patient_occupation_description`) VALUES ('ไม่มีอาชีพ');
INSERT INTO `ivf`.`f_patient_occupation` (`patient_occupation_description`) VALUES ('นักสำรวจ');
INSERT INTO `ivf`.`f_patient_occupation` (`patient_occupation_description`) VALUES ('ช่างเทคนิควิศวกรรม');
INSERT INTO `ivf`.`f_patient_occupation` (`patient_occupation_description`) VALUES ('นักวิทยาศาสตร์');
INSERT INTO `ivf`.`f_patient_occupation` (`patient_occupation_description`) VALUES ('แพทย์');
INSERT INTO `ivf`.`f_patient_occupation` (`patient_occupation_description`) VALUES ('ศัลยแพทย์');
INSERT INTO `ivf`.`f_patient_occupation` (`patient_occupation_description`) VALUES ('ทันตแพทย์');
INSERT INTO `ivf`.`f_patient_occupation` (`patient_occupation_description`) VALUES ('สัตวแพทย์');
INSERT INTO `ivf`.`f_patient_occupation` (`patient_occupation_description`) VALUES ('อาจารย์มหาวิทยาลัย');
INSERT INTO `ivf`.`f_patient_occupation` (`patient_occupation_description`) VALUES ('อาจารย์โรงเรียน');
INSERT INTO `ivf`.`f_patient_occupation` (`patient_occupation_description`) VALUES ('พยาบาล');
INSERT INTO `ivf`.`f_patient_occupation` (`patient_occupation_description`) VALUES ('เภสัชกร');
INSERT INTO `ivf`.`f_patient_occupation` (`patient_occupation_description`) VALUES ('ผู้ปฏิบัติงานทางเทคนิคการแพทย์');
INSERT INTO `ivf`.`f_patient_occupation` (`patient_occupation_description`) VALUES ('พนักงานที่ทำงานช่วยเหลือด้านกา');
INSERT INTO `ivf`.`f_patient_occupation` (`patient_occupation_description`) VALUES ('ผู้พิพากษา');
INSERT INTO `ivf`.`f_patient_occupation` (`patient_occupation_description`) VALUES ('อัยการ');
INSERT INTO `ivf`.`f_patient_occupation` (`patient_occupation_description`) VALUES ('ประติมากร');

INSERT INTO `ivf`.`f_patient_marriage_status` (`patient_marriage_status_description`) VALUES ('โสด');
INSERT INTO `ivf`.`f_patient_marriage_status` (`patient_marriage_status_description`) VALUES ('คู่');
INSERT INTO `ivf`.`f_patient_marriage_status` (`patient_marriage_status_description`) VALUES ('แยกกันอยู่(ร้าง)');
INSERT INTO `ivf`.`f_patient_marriage_status` (`patient_marriage_status_description`) VALUES ('หย่า');
INSERT INTO `ivf`.`f_patient_marriage_status` (`patient_marriage_status_description`) VALUES ('หม้าย');
INSERT INTO `ivf`.`f_patient_marriage_status` (`patient_marriage_status_description`) VALUES ('สมณะ');
INSERT INTO `ivf`.`f_patient_marriage_status` (`patient_marriage_status_description`) VALUES ('ไม่ทราบ');

ALTER TABLE f_patient_race AUTO_INCREMENT = 216000000;
INSERT INTO `ivf`.`f_patient_education_type` (`patient_education_type_description`) VALUES ('ไม่เรียน');
INSERT INTO `ivf`.`f_patient_education_type` (`patient_education_type_description`) VALUES ('ประถมศึกษาปีที่ 4');
INSERT INTO `ivf`.`f_patient_education_type` (`patient_education_type_description`) VALUES ('ประถมศึกษาปีที่ 6');
INSERT INTO `ivf`.`f_patient_education_type` (`patient_education_type_description`) VALUES ('มัธยมศึกษาตอนปลาย');
INSERT INTO `ivf`.`f_patient_education_type` (`patient_education_type_description`) VALUES ('ปวช.');
INSERT INTO `ivf`.`f_patient_education_type` (`patient_education_type_description`) VALUES ('ปวส.');
INSERT INTO `ivf`.`f_patient_education_type` (`patient_education_type_description`) VALUES ('อนุปริญญา');
INSERT INTO `ivf`.`f_patient_education_type` (`patient_education_type_description`) VALUES ('ปริญญาตรี');
INSERT INTO `ivf`.`f_patient_education_type` (`patient_education_type_description`) VALUES ('สูงกว่าปริญญาตรี');
INSERT INTO `ivf`.`f_patient_education_type` (`patient_education_type_description`) VALUES ('ไม่ระบุ');
INSERT INTO `ivf`.`f_patient_education_type` (`patient_education_type_description`) VALUES ('มัธยมศึกษาตอนต้น');
INSERT INTO `ivf`.`f_patient_education_type` (`patient_education_type_description`) VALUES ('ปริญญาโท');
INSERT INTO `ivf`.`f_patient_education_type` (`patient_education_type_description`) VALUES ('ปริญญาเอก');


ALTER TABLE f_patient_discharge_status AUTO_INCREMENT = 215000000;
INSERT INTO `ivf`.`f_patient_discharge_status` (`patient_discharge_status_description`) VALUES ('ตาย');
INSERT INTO `ivf`.`f_patient_discharge_status` (`patient_discharge_status_description`) VALUES ('ย้าย');
INSERT INTO `ivf`.`f_patient_discharge_status` (`patient_discharge_status_description`) VALUES ('สาบสูญ');


INSERT INTO `ivf`.`f_item_billing_group` (`item_billing_group_code`, `item_billing_group_name_t`) VALUES ('00', 'ชันสูตรทางห้องปฏิบัติการ');
INSERT INTO `ivf`.`f_item_billing_group` (`item_billing_group_code`, `item_billing_group_name_t`) VALUES ('01', 'X-ray');
INSERT INTO `ivf`.`f_item_billing_group` (`item_billing_group_code`, `item_billing_group_name_t`) VALUES ('02', 'ตรวจชันสูตรอื่นๆ');
INSERT INTO `ivf`.`f_item_billing_group` (`item_billing_group_code`, `item_billing_group_name_t`) VALUES ('03', 'ผ่าตัด');
INSERT INTO `ivf`.`f_item_billing_group` (`item_billing_group_code`, `item_billing_group_name_t`) VALUES ('04', 'การรักษาอื่นๆ');
INSERT INTO `ivf`.`f_item_billing_group` (`item_billing_group_code`, `item_billing_group_name_t`) VALUES ('05', 'ยาและเวชภัณฑ์');
INSERT INTO `ivf`.`f_item_billing_group` (`item_billing_group_code`, `item_billing_group_name_t`) VALUES ('06', 'ICU');
INSERT INTO `ivf`.`f_item_billing_group` (`item_billing_group_code`, `item_billing_group_name_t`) VALUES ('07', 'ค่าห้อง');
INSERT INTO `ivf`.`f_item_billing_group` (`item_billing_group_code`, `item_billing_group_name_t`) VALUES ('08', 'ค่าอาหาร');
INSERT INTO `ivf`.`f_item_billing_group` (`item_billing_group_code`, `item_billing_group_name_t`) VALUES ('09', 'อื่นๆ');
INSERT INTO `ivf`.`f_item_billing_group` (`item_billing_group_code`, `item_billing_group_name_t`) VALUES ('10', 'ทันตกรรม');


INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('ไม่ระบุ');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('อังกฤษ');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('โปรตุเกส');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('เนเธอร์แลนด์');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('เยอรมัน');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('ฝรั่งเศส');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('เดนมาร์ก');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('สวีเดน');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('ไนจีเรีย');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('สหรัฐอาหรับเอมิเรตส์');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('กินี');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('สวีสเซอร์แลนด์');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('ปาปัวนิวกินี');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('ม้ง');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('เมี่ยน');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('อิตาลี');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('รอให้สัญชาติไทย*');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('นอร์เวย์');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('อัฟกัน');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('บาห์เรน');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('ภูฏาน');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('จอร์แดน');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('เกาหลีเหนือ');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('มัลดีฟ');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('มองโกเลีย');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('โอมาน');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('กาตาร์');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('เยเมน');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('ออสเตรีย');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('เยเมน(ใต้)**');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('หมู่เกาะฟิจิ');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('คิริบาส');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('นาอูรู');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('หมู่เกาะโซโลมอน');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('ตองก้า');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('ตูวาลู');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('วานูอาตู');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('ซามัว');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('แอลเบเนีย');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('ไอร์แลนด์');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('อันดอร์รา');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('เยอรมนีตะวันออก**');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('ไอซ์แลนด์');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('ลิกเตนสไตน์');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('โมนาโก');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('ซานมารีโน');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('บริติช');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('แอลจีเรีย');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('แองโกลา');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('เบนิน');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('ฟินแลนด์');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('บอตสวานา');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('บูร์กินาฟาโซ');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('บุรุนดี');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('แคเมอรูน');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('เคปเวิร์ด');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('แอฟริกากลาง');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('ชาด');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('คอโมโรส');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('คองโก');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('โกตดิวัวร์');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('เบลเยี่ยม');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('จิบูตี');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('อิเควทอเรียลกินี');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('กาบอง');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('แกมเบีย');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('กานา');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('กินีบีสเซา');
INSERT INTO `ivf`.`f_patient_nation` (`patient_nation_description`) VALUES ('เลโซโท');



ALTER TABLE `ivf`.`f_patient_blood_group` 
ADD COLUMN `active` VARCHAR(255) NULL AFTER `patient_blood_group_description`;

ALTER TABLE `ivf`.`f_patient_discharge_status` 
ADD COLUMN `active` VARCHAR(255) NULL AFTER `patient_discharge_status_description`;

ALTER TABLE `ivf`.`f_patient_education_type` 
ADD COLUMN `active` VARCHAR(255) NULL AFTER `patient_education_type_sort_index`;

ALTER TABLE `ivf`.`f_patient_marriage_status` 
ADD COLUMN `active` VARCHAR(255) NULL AFTER `patient_marriage_status_description`;

ALTER TABLE `ivf`.`f_patient_nation` 
ADD COLUMN `active` VARCHAR(255) NULL AFTER `patient_nation_description`;

ALTER TABLE `ivf`.`f_patient_occupation` 
CHANGE COLUMN `f_patient_occupation_active` `active` VARCHAR(255) CHARACTER SET 'utf8' COLLATE 'utf8_bin' NULL DEFAULT NULL ;

ALTER TABLE `ivf`.`f_patient_race` 
ADD COLUMN `active` VARCHAR(255) NULL AFTER `patient_race_description`;

ALTER TABLE `ivf`.`f_patient_relation` 
ADD COLUMN `active` VARCHAR(255) NULL AFTER `patient_relation_description`;

ALTER TABLE `ivf`.`f_patient_religion` 
ADD COLUMN `active` VARCHAR(255) NULL AFTER `patient_religion_description`;

ALTER TABLE `ivf`.`f_item_billing_group` 
ADD COLUMN `active` VARCHAR(255) NULL AFTER `item_billing_group_name_e`;

ALTER TABLE `ivf`.`f_sex` 
ADD COLUMN `active` VARCHAR(255) NULL AFTER `sex_description`;

ALTER TABLE `ivf`.`t_patient` 
ADD COLUMN `date_create` VARCHAR(45) NULL AFTER `picture_profile`,
ADD COLUMN `date_modi` VARCHAR(45) NULL AFTER `date_create`,
ADD COLUMN `date_cancel` VARCHAR(45) NULL AFTER `date_modi`,
ADD COLUMN `user_create` VARCHAR(45) NULL AFTER `date_cancel`,
ADD COLUMN `user_modi` VARCHAR(45) NULL AFTER `user_create`,
ADD COLUMN `user_cancel` VARCHAR(45) NULL AFTER `user_modi`;
ADD COLUMN `active` VARCHAR(45) NULL AFTER `user_modi`;

ALTER TABLE `ivf`.`t_patient` 
CHANGE COLUMN `date_create` `date_create` VARCHAR(255) NULL DEFAULT NULL ,
CHANGE COLUMN `date_modi` `date_modi` VARCHAR(255) NULL DEFAULT NULL ,
CHANGE COLUMN `date_cancel` `date_cancel` VARCHAR(255) NULL DEFAULT NULL ,
CHANGE COLUMN `user_create` `user_create` VARCHAR(255) NULL DEFAULT NULL ,
CHANGE COLUMN `user_modi` `user_modi` VARCHAR(255) NULL DEFAULT NULL ,
CHANGE COLUMN `user_cancel` `user_cancel` VARCHAR(255) NULL DEFAULT NULL ,
CHANGE COLUMN `active` `active` VARCHAR(255) NULL DEFAULT NULL ;

ALTER TABLE `ivf`.`b_company` 
ADD COLUMN `prefix_hn_doc` VARCHAR(255) NULL AFTER `hn_doc`,
CHANGE COLUMN `erc_doc` `hn_doc` INT(11) NULL DEFAULT NULL COMMENT 'หน้าจอ การเงิน เคลีย์เงินสด' ;

UPDATE `ivf`.`b_company` SET `hn_doc` = '0', `prefix_hn_doc` = 'BH' WHERE (`comp_id` = '1020000002');

ALTER TABLE `ivf`.`t_patient` 
ADD COLUMN `remark` VARCHAR(255) NULL AFTER `passport`;


61-10-22
ALTER TABLE `ivf`.`t_patient` 
ADD COLUMN `patient_type` VARCHAR(255) NULL AFTER `patient_active`,
ADD COLUMN `patient_group` VARCHAR(255) NULL AFTER `patient_type`;

ALTER TABLE `ivf`.`t_patient` 
ADD COLUMN `agent` VARCHAR(255) NULL AFTER `patient_group`;

INSERT INTO `ivf`.`f_patient_prefix` (`patient_prefix_description`, `active`) VALUES ('Mrs.', '1');
INSERT INTO `ivf`.`f_patient_prefix` (`patient_prefix_description`, `active`) VALUES ('Miss', '1');
INSERT INTO `ivf`.`f_patient_prefix` (`patient_prefix_description`, `active`) VALUES ('Mr.', '1');
INSERT INTO `ivf`.`f_patient_prefix` (`patient_prefix_description`, `active`) VALUES ('Girl', '1');
INSERT INTO `ivf`.`f_patient_prefix` (`patient_prefix_description`, `active`) VALUES ('Boy', '1');
INSERT INTO `ivf`.`f_patient_prefix` (`patient_prefix_description`, `active`) VALUES ('-', '1');

ALTER TABLE `ivf`.`t_patient` 
ADD COLUMN `status_convert` VARCHAR(255) NULL AFTER `remark`;

61-10-23
ALTER TABLE `ivf`.`t_patient` 
ADD COLUMN `patient_father_moble` VARCHAR(255) NULL AFTER `status_convert`,
ADD COLUMN `patient_mother_mobile` VARCHAR(255) NULL AFTER `patient_father_moble`,
ADD COLUMN `patient_couple_mobile` VARCHAR(255) NULL AFTER `patient_mother_mobile`;


61-10-25
ALTER TABLE `ivf`.`t_patient` 
ADD COLUMN `patient_firstname_e` VARCHAR(255) NULL AFTER `patient_couple_mobile`,
ADD COLUMN `patient_lastname_e` VARCHAR(255) NULL AFTER `patient_firstname_e`,
CHANGE COLUMN `date_create` `date_create` VARCHAR(55) CHARACTER SET 'utf8' COLLATE 'utf8_bin' NULL DEFAULT NULL ,
CHANGE COLUMN `date_modi` `date_modi` VARCHAR(55) CHARACTER SET 'utf8' COLLATE 'utf8_bin' NULL DEFAULT NULL ,
CHANGE COLUMN `date_cancel` `date_cancel` VARCHAR(55) CHARACTER SET 'utf8' COLLATE 'utf8_bin' NULL DEFAULT NULL ,
CHANGE COLUMN `user_create` `user_create` VARCHAR(55) CHARACTER SET 'utf8' COLLATE 'utf8_bin' NULL DEFAULT NULL ,
CHANGE COLUMN `user_modi` `user_modi` VARCHAR(55) CHARACTER SET 'utf8' COLLATE 'utf8_bin' NULL DEFAULT NULL ,
CHANGE COLUMN `user_cancel` `user_cancel` VARCHAR(55) CHARACTER SET 'utf8' COLLATE 'utf8_bin' NULL DEFAULT NULL ,
CHANGE COLUMN `active` `active` VARCHAR(1) CHARACTER SET 'utf8' COLLATE 'utf8_bin' NULL DEFAULT NULL ,
CHANGE COLUMN `status_convert` `status_convert` VARCHAR(1) NULL DEFAULT NULL ;

ALTER TABLE `ivf`.`t_patient` 
ADD COLUMN `contract` VARCHAR(255) NULL AFTER `patient_lastname_e`,
ADD COLUMN `insurance` VARCHAR(255) NULL AFTER `contract`;

ALTER TABLE `ivf`.`t_patient` 
CHANGE COLUMN `status_chronic` `status_chronic` VARCHAR(1) CHARACTER SET 'utf8' COLLATE 'utf8_bin' NULL DEFAULT NULL ,
CHANGE COLUMN `status_hiv` `status_hiv` VARCHAR(1) CHARACTER SET 'utf8' COLLATE 'utf8_bin' NULL DEFAULT NULL ,
CHANGE COLUMN `patient_status_hiv` `patient_status_hiv` VARCHAR(1) CHARACTER SET 'utf8' COLLATE 'utf8_bin' NULL DEFAULT NULL ,
CHANGE COLUMN `status_deny_allergy` `status_deny_allergy` VARCHAR(1) CHARACTER SET 'utf8' COLLATE 'utf8_bin' NULL DEFAULT NULL ;

INSERT INTO `ivf`.`f_patient_religion` (`patient_religion_description`) VALUES ('Buddhism');
INSERT INTO `ivf`.`f_patient_religion` (`patient_religion_description`) VALUES ('Christianity');
INSERT INTO `ivf`.`f_patient_religion` (`patient_religion_description`) VALUES ('Islam');
INSERT INTO `ivf`.`f_patient_religion` (`patient_religion_description`) VALUES ('African Traditional & Diasporic');
INSERT INTO `ivf`.`f_patient_religion` (`patient_religion_description`) VALUES ('Agnostic');
INSERT INTO `ivf`.`f_patient_religion` (`patient_religion_description`) VALUES ('Atheist');
INSERT INTO `ivf`.`f_patient_religion` (`patient_religion_description`) VALUES ('Baha\'i');
INSERT INTO `ivf`.`f_patient_religion` (`patient_religion_description`) VALUES ('Cao Dai');
INSERT INTO `ivf`.`f_patient_religion` (`patient_religion_description`) VALUES ('Chinese traditional religion');
INSERT INTO `ivf`.`f_patient_religion` (`patient_religion_description`) VALUES ('Hinduism');
INSERT INTO `ivf`.`f_patient_religion` (`patient_religion_description`) VALUES ('Jainism');
INSERT INTO `ivf`.`f_patient_religion` (`patient_religion_description`) VALUES ('Juche');
INSERT INTO `ivf`.`f_patient_religion` (`patient_religion_description`) VALUES ('Judaism');
INSERT INTO `ivf`.`f_patient_religion` (`patient_religion_description`) VALUES ('Neo-Paganism');
INSERT INTO `ivf`.`f_patient_religion` (`patient_religion_description`) VALUES ('Nonreligious');
INSERT INTO `ivf`.`f_patient_religion` (`patient_religion_description`) VALUES ('Rastafarianism');
INSERT INTO `ivf`.`f_patient_religion` (`patient_religion_description`) VALUES ('Secular');
INSERT INTO `ivf`.`f_patient_religion` (`patient_religion_description`) VALUES ('Shinto');
INSERT INTO `ivf`.`f_patient_religion` (`patient_religion_description`) VALUES ('Sikhism');
INSERT INTO `ivf`.`f_patient_religion` (`patient_religion_description`) VALUES ('Spiritism');
INSERT INTO `ivf`.`f_patient_religion` (`patient_religion_description`) VALUES ('Tenrikyo');
INSERT INTO `ivf`.`f_patient_religion` (`patient_religion_description`) VALUES ('Unitarian-Universalism');
INSERT INTO `ivf`.`f_patient_religion` (`patient_religion_description`) VALUES ('Zoroastrianism');
INSERT INTO `ivf`.`f_patient_religion` (`patient_religion_description`) VALUES ('primal-indigenous');

61-10-26

ALTER TABLE `ivf`.`t_patient` 
ADD COLUMN `patient_couple_f_patient_prefix_id` INT NULL AFTER `agent`;
ALTER TABLE `ivf`.`t_patient` 
CHANGE COLUMN `patient_couple_f_patient_prefix_id` `patient_couple_f_patient_prefix_id` INT(11) NULL DEFAULT NULL AFTER `patient_couple_mobile`;

ALTER TABLE `ivf`.`t_patient` 
CHANGE COLUMN `patient_firstname_e` `patient_firstname_e` VARCHAR(255) NULL DEFAULT NULL AFTER `patient_lastname`,
CHANGE COLUMN `patient_lastname_e` `patient_lastname_e` VARCHAR(255) NULL DEFAULT NULL AFTER `patient_firstname_e`;

ALTER TABLE `ivf`.`t_patient` 
ADD COLUMN `patient_contact_f_patient_relation_id` INT NULL AFTER `agent`,
ADD COLUMN `patient_coulpe_f_patient_relation_id` INT NULL AFTER `patient_contact_f_patient_relation_id`;

ALTER TABLE `ivf`.`t_patient` 
CHANGE COLUMN `patient_coulpe_f_patient_relation_id` `patient_coulpe_f_patient_relation_id` INT(11) NULL DEFAULT NULL AFTER `patient_couple_f_patient_prefix_id`,
CHANGE COLUMN `patient_contact_f_patient_relation_id` `patient_contact_f_patient_relation_id` INT(11) NULL DEFAULT NULL AFTER `f_patient_relation_id`;

ALTER TABLE `ivf`.`t_patient` 
ADD COLUMN `b_contract_plans_id` INT NULL AFTER `agent`;

ALTER TABLE `ivf`.`b_contract_plans` 
CHANGE COLUMN `contract_plans_active` `active` VARCHAR(255) CHARACTER SET 'utf8' COLLATE 'utf8_bin' NULL DEFAULT NULL ;


CREATE TABLE `ivf`.`t_patient_image` (
  `patient_image_id` INT NOT NULL AUTO_INCREMENT,
  `t_patient_id` INT NULL,
  `t_visit_id` INT NULL,
  `desc1` VARCHAR(255) NULL,
  `desc2` VARCHAR(255) NULL,
  `desc3` VARCHAR(255) NULL,
  `desc4` VARCHAR(255) NULL,
  `active` VARCHAR(255) NULL,
  `remark` VARCHAR(255) NULL,
  `date_create` VARCHAR(255) NULL,
  `date_modi` VARCHAR(255) NULL,
  `date_cancel` VARCHAR(255) NULL,
  `user_create` VARCHAR(255) NULL,
  `user_modi` VARCHAR(255) NULL,
  `user_cancel` VARCHAR(255) NULL,
  PRIMARY KEY (`patient_image_id`))
ENGINE = MyISAM
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin
COMMENT = 'id=211';
ALTER TABLE f_item_billing_group AUTO_INCREMENT = 2110000000;

61-10-27
ALTER TABLE `ivf`.`t_patient_image` 
ADD COLUMN `image_path` VARCHAR(255) NULL AFTER `user_cancel`,
ADD COLUMN `status_image` VARCHAR(255) NULL COMMENT '0=default; 1=pic profile;2=pic from patient add;' AFTER `image_path`;

61-10-28
ALTER TABLE `ivf`.`t_patient` 
ADD COLUMN `t_patient_id_old` INT NULL AFTER `b_contract_plans_id`;


61-10-29

CREATE TABLE b_service_point
(
    b_service_point_id INT NOT NULL AUTO_INCREMENT,
    service_point_number VARCHAR(255) NULL,
    service_point_description VARCHAR(255) NULL,
    f_service_group_id INT NULL,
    f_service_subgroup_id INT NULL,
    service_point_active VARCHAR(255) NULL,
    service_point_check VARCHAR(255) NULL,
    service_point_operation_room VARCHAR(255) NULL,
    service_point_color VARCHAR(255) NULL,
    alert_send_opdcard VARCHAR(255) NULL,
    is_ipd VARCHAR(1) NULL,
    PRIMARY KEY (`b_service_point_id`))
ENGINE = MyISAM
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin
COMMENT = 'id=212';
ALTER TABLE b_service_point AUTO_INCREMENT = 2120000000;


CREATE TABLE f_service_group
(
    f_service_group_id  INT NOT NULL AUTO_INCREMENT,
    service_group_description VARCHAR(255) NULL,
    PRIMARY KEY (`f_service_group_id`))
ENGINE = MyISAM
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin
COMMENT = 'id=213';
ALTER TABLE f_service_group AUTO_INCREMENT = 2130000000;

CREATE TABLE f_service_subgroup
(
    f_service_subgroup_id  INT NOT NULL AUTO_INCREMENT,
    service_subgroup_description VARCHAR(255) NULL,
    PRIMARY KEY (`f_service_subgroup_id`))
ENGINE = MyISAM
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin
COMMENT = 'id=214';
ALTER TABLE f_service_subgroup AUTO_INCREMENT = 2140000000;

INSERT INTO `ivf`.`f_service_group` (`service_group_description`) VALUES ('เวชระเบียน');
INSERT INTO `ivf`.`f_service_group` (`service_group_description`) VALUES ('หน้าห้องตรวจ');
INSERT INTO `ivf`.`f_service_group` (`service_group_description`) VALUES ('ห้องตรวจ');
INSERT INTO `ivf`.`f_service_group` (`service_group_description`) VALUES ('จุดบริการตรวจ รับ จ่าย');
INSERT INTO `ivf`.`f_service_group` (`service_group_description`) VALUES ('การเงิน');
INSERT INTO `ivf`.`f_service_group` (`service_group_description`) VALUES ('การตั้งค่า');
INSERT INTO `ivf`.`f_service_group` (`service_group_description`) VALUES ('คลินิกใช้การบันทึกรหัส ICD-10, ICD-9 ');
INSERT INTO `ivf`.`f_service_group` (`service_group_description`) VALUES ('อื่นๆ');

INSERT INTO `ivf`.`f_service_subgroup` (`service_subgroup_description`) VALUES ('Lab');
INSERT INTO `ivf`.`f_service_subgroup` (`service_subgroup_description`) VALUES ('Xray');
INSERT INTO `ivf`.`f_service_subgroup` (`service_subgroup_description`) VALUES ('Drug');
INSERT INTO `ivf`.`f_service_subgroup` (`service_subgroup_description`) VALUES ('Other');
INSERT INTO `ivf`.`f_service_subgroup` (`service_subgroup_description`) VALUES ('IPD');

INSERT INTO `ivf`.`b_service_point` (`service_point_number`, `service_point_description`, `f_service_group_id`, `service_point_active`, `service_point_operation_room`, `service_point_color`) VALUES ('10', 'Reception', '2130000000', '1', '0', '225,225,225');
INSERT INTO `ivf`.`b_service_point` (`service_point_number`, `service_point_description`, `f_service_group_id`, `f_service_subgroup_id`, `service_point_active`, `service_point_operation_room`, `service_point_color`) VALUES ('20', 'กุมารเวช', '2130000003', '', '1', '0', '225,225,225');
INSERT INTO `ivf`.`b_service_point` (`service_point_number`, `service_point_description`, `f_service_group_id`, `f_service_subgroup_id`, `service_point_active`, `service_point_operation_room`, `service_point_color`) VALUES ('30', 'สูติ-นาริเวช', '2130000003', '', '1', '0', '225,225,225');
INSERT INTO `ivf`.`b_service_point` (`service_point_number`, `service_point_description`, `f_service_group_id`, `f_service_subgroup_id`, `service_point_active`, `service_point_operation_room`, `service_point_color`) VALUES ('40', 'อายุรกรรม', '2130000003', '', '1', '0', '225,225,225');
INSERT INTO `ivf`.`b_service_point` (`service_point_number`, `service_point_description`, `f_service_group_id`, `f_service_subgroup_id`, `service_point_active`, `service_point_operation_room`, `service_point_color`) VALUES ('50', 'LAB', '2130000007', '2140000000', '1', '0', '225,225,225');
INSERT INTO `ivf`.`b_service_point` (`service_point_number`, `service_point_description`, `f_service_group_id`, `f_service_subgroup_id`, `service_point_active`, `service_point_operation_room`, `service_point_color`) VALUES ('60', 'X-Ray', '2130000007', '2140000001', '1', '0', '225,225,225');
INSERT INTO `ivf`.`b_service_point` (`service_point_number`, `service_point_description`, `f_service_group_id`, `f_service_subgroup_id`, `service_point_active`, `service_point_operation_room`, `service_point_color`) VALUES ('70', 'ห้องยา', '2130000007', '2140000002', '1', '0', '225,225,225');
INSERT INTO `ivf`.`b_service_point` (`service_point_number`, `service_point_description`, `f_service_group_id`, `f_service_subgroup_id`, `service_point_active`, `service_point_operation_room`, `service_point_color`) VALUES ('80', 'LR+NS', '2130000007', '2140000004', '1', '0', '225,225,225');
INSERT INTO `ivf`.`b_service_point` (`service_point_number`, `service_point_description`, `f_service_group_id`, `f_service_subgroup_id`, `service_point_active`, `service_point_operation_room`, `service_point_color`) VALUES ('90', 'WARD ', '2130000007', '2140000004', '1', '0', '225,225,225');
INSERT INTO `ivf`.`b_service_point` (`service_point_number`, `service_point_description`, `f_service_group_id`, `f_service_subgroup_id`, `service_point_active`, `service_point_operation_room`, `service_point_color`) VALUES ('A1', 'การเงิน', '2130000004', '2140000003', '1', '0', '225,225,225');
INSERT INTO `ivf`.`b_service_point` (`service_point_description`, `f_service_group_id`, `f_service_subgroup_id`, `service_point_operation_room`) VALUES ('OR', '2130000007', '2140000004', '1');

UPDATE `ivf`.`b_service_point` SET `service_point_number` = 'A2' WHERE (`b_service_point_id` = '2120000010');

ALTER TABLE `ivf`.`b_service_point` 
CHANGE COLUMN `service_point_active` `active` VARCHAR(255) NULL DEFAULT NULL ;


CREATE TABLE t_visit
(
    t_visit_id INT NOT NULL AUTO_INCREMENT,
    visit_hn VARCHAR(255) NULL,
    visit_vn VARCHAR(255) NULL,
    f_visit_type_id INT NULL,
    visit_begin_visit_time VARCHAR(255) NULL,
    visit_financial_discharge_time VARCHAR(255) NULL,
    visit_notice VARCHAR(255) NULL,
    b_visit_office_id_refer_in INT NULL,
    b_visit_office_id_refer_out INT NULL,
    visit_diagnosis_notice VARCHAR(255) NULL,
    f_visit_opd_discharge_status_id INT NULL,
    f_visit_ipd_discharge_type_id INT NULL,
    f_visit_ipd_discharge_status_id INT NULL,
    visit_locking VARCHAR(255) NULL,
    visit_staff_lock VARCHAR(255) NULL,
    visit_lock_date_time VARCHAR(255) NULL,
    f_visit_status_id INT NULL,
    visit_pregnant VARCHAR(255) NULL,
    b_visit_clinic_id INT NULL,
    b_visit_ward_id INT NULL,
    visit_bed VARCHAR(255) NULL,
    visit_observe VARCHAR(255) NULL,
    visit_patient_type VARCHAR(255) NULL,
    visit_queue VARCHAR(255) NULL,
    b_service_point_id INT NULL,
    visit_staff_observe VARCHAR(255) NULL,
    visit_dx VARCHAR(255) NULL,
    visit_ipd_discharge_status VARCHAR(255) NULL,
    visit_money_discharge_status VARCHAR(255) NULL,
    visit_doctor_discharge_status VARCHAR(255) NULL,
    t_patient_id INT NULL,
    visit_staff_financial_discharge VARCHAR(255) NULL,
    visit_staff_doctor_discharge VARCHAR(255) NULL,
    visit_staff_doctor_discharge_date_time VARCHAR(255) NULL,
    visit_an VARCHAR(255) NULL,
    visit_dx_stat VARCHAR(255) NULL,
    visit_begin_admit_date_time VARCHAR(255) NULL,
    visit_deny_allergy VARCHAR(255) NULL,
    visit_first_visit VARCHAR(255) NULL,
    visit_patient_self_doctor VARCHAR(255) NULL,
    visit_patient_age VARCHAR(255) NULL,
    visit_pcu_service VARCHAR(255) NULL,
    visit_hospital_service VARCHAR(255) NULL,
    visit_lab_status_id INT NULL,
    visit_ncd VARCHAR(255) NULL,
    b_ncd_group_id INT NULL,
    f_refer_cause_id INT NULL,
    f_emergency_status_id INT NULL,
    visit_emergency_staff VARCHAR(255) NULL,
    visit_have_appointment VARCHAR(255) NULL,
    visit_have_admit VARCHAR(255) NULL,
    visit_have_refer VARCHAR(255) NULL,
    t_patient_appointment_id INT NULL,
    visit_cal_date_appointment VARCHAR(255) NULL,
    visit_cause_appointment VARCHAR(255) NULL,
    b_contract_plans_id INT NULL,
    contact_id INT NULL,
    contact_namet VARCHAR(255) NULL,
    contact_join_id INT NULL,
    contact_join_namet VARCHAR(255) NULL,
    surveillance_case_id INT NULL,
    visit_record_date_time VARCHAR(255) NULL,
    visit_record_staff VARCHAR(255) NULL,
    visit_financial_record_date_time VARCHAR(255) NULL,
    visit_financial_record_staff VARCHAR(255) NULL,
    service_location VARCHAR(255) NULL,
    visit_have_scan_sn_dx VARCHAR(255) NULL,
    visit_status_lab_approve VARCHAR(255) NULL,
    visit_lab_approve_staff VARCHAR(255) NULL,
    visit_primary_symtom VARCHAR(255) NULL,
    b_visit_bed_id INT NULL,
    b_visit_room_id INT NULL,
    status_prepare_discharge VARCHAR(255) NULL,
    prepare_discharge_date_time VARCHAR(255) NULL,
    prepare_discharge_message VARCHAR(255) NULL,
    modify_discharge_datetime VARCHAR(255) NULL,
    visit_staff_financial_reverse VARCHAR(255) NULL,
    visit_financial_reverse_date_time VARCHAR(255) NULL,
    visit_staff_doctor_reverse VARCHAR(255) NULL,
    visit_doctor_reverse_date_time VARCHAR(255) NULL,
    visit_modify_staff VARCHAR(255) NULL,
    visit_modify_date_time VARCHAR(255) NULL,
    f_trama_status_id INT NULL,
    f_transportation_type_id INT NULL,
    other_transportation VARCHAR(255) NULL,
    f_visit_service_type_id INT NULL,
    visit_ipd_staff_discharge VARCHAR(255) NULL,
    visit_ipd_discharge_date_time VARCHAR(255) NULL,
    visit_ipd_staff_reverse VARCHAR(255) NULL,
    visit_ipd_reverse_date_time VARCHAR(255) NULL,
    ipd_discharge_doctor VARCHAR(255) NULL,
    PRIMARY KEY (`t_visit_id`))
ENGINE = MyISAM
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin
COMMENT = 'id=215';
ALTER TABLE t_visit AUTO_INCREMENT = 2150000000;

CREATE TABLE t_visit_queue_transfer
(
    t_visit_queue_transfer_id INT NOT NULL AUTO_INCREMENT,
    patient_drugallergy VARCHAR(255) NULL,
    visit_locking VARCHAR(255) NULL,
    visit_hn VARCHAR(255) NULL,
    visit_vn VARCHAR(255) NULL,
    visit_service_staff_doctor VARCHAR(255) NULL,
    patient_firstname VARCHAR(255) NULL,
    patient_lastname VARCHAR(255) NULL,
    assign_date_time VARCHAR(255) NULL,
    service_point_description VARCHAR(255) NULL,
    t_patient_id INT NULL,
    t_visit_id INT NULL,
    f_visit_type_id INT NULL,
    b_service_point_id INT NULL,
    visit_queue_map_queue VARCHAR(255) NULL,
    visit_queue_setup_queue_color VARCHAR(255) NULL,
    visit_queue_setup_description VARCHAR(255) NULL,
    f_sex_id INT NULL,
    f_patient_prefix_id INT NULL,
    visit_queue_transfer_lab_status VARCHAR(255) NULL,
    contact_namet VARCHAR(255) NULL,
    contact_join_namet VARCHAR(255) NULL,
    b_contract_plans_id INT NULL,
    visit_begin_visit_time VARCHAR(255) NULL,
    visit_financial_discharge_time VARCHAR(255) NULL,
    visit_payment_staff_record VARCHAR(255) NULL,
    contract_plans_description VARCHAR(255) NULL,
    order_staff_order VARCHAR(255) NULL,
    order_drug_modifier VARCHAR(255) NULL,
    billing_invoice_staff_record VARCHAR(255) NULL,
    scan_time VARCHAR(255) NULL,
    doctor_tmp VARCHAR(255) NULL,
    adm VARCHAR(255) NULL,
    med VARCHAR(255) NULL,
    xray VARCHAR(255) NULL,
    scan VARCHAR(255) NULL,
    description VARCHAR(255) NULL,
    contract_plans_color VARCHAR(255) NULL,
    visit_count VARCHAR(255) NULL,
    status_flow_opd VARCHAR(255) NULL,
    b_service_point_old_id VARCHAR(255) NULL,
    PRIMARY KEY (`t_visit_queue_transfer_id`))
ENGINE = MyISAM
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin
COMMENT = 'id=216';
ALTER TABLE t_visit AUTO_INCREMENT = 2160000000;


61-11-21
ALTER TABLE `ivf`.`JobSpecialDetail` 
ADD COLUMN `status_req_accept` VARCHAR(255) NULL DEFAULT 0 AFTER `FileName`,
ADD COLUMN `req_id` INT NULL AFTER `status_req_accept`;

ALTER TABLE `ivf`.`lab_t_request` 
ADD COLUMN `doctor_id` INT NULL AFTER `result_staff_id`;

ALTER TABLE `ivf`.`lab_t_request` 
ADD COLUMN `lab_id` INT NULL AFTER `doctor_id`;

ALTER TABLE lab_t_opu AUTO_INCREMENT = 2000000000;

ALTER TABLE `ivf`.`lab_t_opu` 
ADD COLUMN `status_opu` VARCHAR(255) NULL COMMENT '1=start;2=' AFTER `req_id`;

ALTER TABLE `ivf`.`lab_t_opu` 
ADD COLUMN `save_patient_staff_id` INT NULL AFTER `status_opu`,
ADD COLUMN `save_maturation_staff_id` INT NULL AFTER `save_patient_staff_id`,
ADD COLUMN `save_fetilization_staff_id` INT NULL AFTER `save_maturation_staff_id`,
ADD COLUMN `save_sperm_prepa_staff_id` INT NULL AFTER `save_fetilization_staff_id`,
ADD COLUMN `save_embryo_freezing_day_1_staff_id` INT NULL AFTER `save_sperm_prepa_staff_id`;

ALTER TABLE `ivf`.`b_position` 
ADD COLUMN `status_doctor` VARCHAR(255) NULL AFTER `sort1`,
ADD COLUMN `status_embryologist` VARCHAR(255) NULL AFTER `status_doctor`;


61-11-26
CREATE TABLE t_patient_appointment
(
    t_patient_appointment_id int(11) NOT NULL AUTO_INCREMENT,
    t_patient_id character varchar(255) COLLATE utf8_bin DEFAULT NULL,
    patient_appoint_date_time varchar(255) COLLATE utf8_bin DEFAULT NULL,
    patient_appointment_date varchar(255) COLLATE utf8_bin DEFAULT NULL,
    patient_appointment_time varchar(255) COLLATE utf8_bin DEFAULT NULL,
    patient_appointment character varchar(255) COLLATE utf8_bin DEFAULT NULL,
    patient_appointment_doctor int(11)  DEFAULT NULL,
    patient_appointment_servicepoint int(11)  DEFAULT NULL,
    patient_appointment_notice varchar(255) COLLATE utf8_bin DEFAULT NULL,
    patient_appointment_staff int(11)  DEFAULT NULL,
    t_visit_id int(11) COLLATE pg_catalog."default",
    patient_appointment_auto_visit varchar(255) COLLATE utf8_bin DEFAULT NULL,
    b_visit_queue_setup_id int(11)  DEFAULT NULL,
    patient_appointment_status varchar(255) COLLATE utf8_bin DEFAULT NULL,
    patient_appointment_vn character varchar(255) COLLATE utf8_bin DEFAULT NULL,
    patient_appointment_staff_record int(11)  DEFAULT NULL,
    patient_appointment_record_date_time varchar(255) COLLATE utf8_bin DEFAULT NULL,
    patient_appointment_staff_update varchar(255) COLLATE utf8_bin DEFAULT NULL,
    patient_appointment_update_date_time varchar(255) COLLATE utf8_bin DEFAULT NULL,
    patient_appointment_staff_cancel varchar(255) COLLATE utf8_bin DEFAULT NULL,
    patient_appointment_cancel_date_time varchar(255) COLLATE utf8_bin DEFAULT NULL,
    patient_appointment_active varchar(255) COLLATE utf8_bin DEFAULT NULL,
    r_rp1853_aptype_id character int(11)  DEFAULT NULL,
    patient_appointment_end_time varchar(255) COLLATE utf8_bin DEFAULT NULL,
    appointment_confirm_date varchar(255) COLLATE utf8_bin DEFAULT NULL,
    change_appointment_cause varchar(255) COLLATE utf8_bin DEFAULT NULL,
    visit_id_make_appointment int(11)  DEFAULT NULL,
    patient_appointment_clinic int(11)  DEFAULT NULL,
    PRIMARY KEY (`t_patient_appointment_id`)
)ENGINE=MyISAM AUTO_INCREMENT=2170000001 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=217';
ALTER TABLE t_patient_appointment AUTO_INCREMENT = 2170000000;

ALTER TABLE ivf_donor.lab_t_form_a AUTO_INCREMENT = 2180000000;

c# mysql error MessageUnable to convert MySQL date/time value to System.DateTime


select *
from Appointment
where PIDS like '%83491%';

update Appointment
Set Status = '0'
Where ID = '16282'

https://windowsreport.com/windows-10-ftp-client-wont-work/#.XDKS5lwzaUk

ALTER TABLE ivf.b_doc_group_scan AUTO_INCREMENT = 2210000000;
ALTER TABLE ivf.b_doc_group_sub_scan AUTO_INCREMENT = 2220000000;


delete from Patient1 Where PID = '20191591';
delete from t_patient1 Where t_patient_id = '2080000040';

delete from Visit1 Where VN = '20190429074';
delete from t_visit1 Where t_visit_id = '210000019';

ALTER TABLE ivf_101.nurse_t_egg_sti_day AUTO_INCREMENT = 2270000000;

ALTER TABLE ivf_101_donor.billheader AUTO_INCREMENT = 2390000000;

ALTER TABLE `ivf_101`.`b_company` 
ADD COLUMN `month_curr_cashier` VARCHAR(45) NULL AFTER `receipt_cover_doc`;


ALTER TABLE ivf_101.lab_t_result AUTO_INCREMENT = 2490000000;

63-02-15

ALTER TABLE `ivf_101_donor`.`b_item` 
CHANGE COLUMN `item_id` `item_id` BIGINT NOT NULL ,
CHANGE COLUMN `item_sub_group_id` `item_sub_group_id` BIGINT NULL DEFAULT NULL ,
CHANGE COLUMN `item_billing_subgroop_id` `item_billing_subgroop_id` BIGINT NULL DEFAULT NULL ;

ALTER TABLE `ivf_101`.`b_item` 
CHANGE COLUMN `item_id` `item_id` BIGINT NOT NULL ,
CHANGE COLUMN `item_sub_group_id` `item_sub_group_id` BIGINT NULL DEFAULT NULL ,
CHANGE COLUMN `item_billing_subgroop_id` `item_billing_subgroop_id` BIGINT NULL DEFAULT NULL ;

ALTER TABLE `ivf_101_donor`.`LabItem` 
ADD COLUMN `item_code` VARCHAR(45) NULL AFTER `sort1`;

ALTER TABLE `ivf_101`.`LabItem` 
ADD COLUMN `item_code` VARCHAR(45) NULL AFTER `sort1`;

ALTER TABLE `ivf_101_donor`.`SpecialItem` 
ADD COLUMN `item_code` VARCHAR(45) NULL AFTER `status_discount`;

ALTER TABLE `ivf_101`.`SpecialItem` 
ADD COLUMN `item_code` VARCHAR(45) NULL AFTER `status_discount`;

ALTER TABLE `ivf_101_donor`.`StockDrug` 
ADD COLUMN `item_code` VARCHAR(45) NULL AFTER `drug_description`;

ALTER TABLE `ivf_101`.`StockDrug` 
ADD COLUMN `item_code` VARCHAR(45) NULL AFTER `drug_description`;

ALTER TABLE `ivf_101`.`specialitem` 
ADD COLUMN `item_code` VARCHAR(45) NULL AFTER `BillGroupID`;

ALTER TABLE `ivf_101_donor`.`specialitem` 
ADD COLUMN `item_code` VARCHAR(45) NULL AFTER `BillGroupID`;

ALTER TABLE `ivf_101_donor`.`b_item` 
ADD COLUMN `status_item` VARCHAR(45) NULL COMMENT '0=default;1=lab; 2=special;3=drug' AFTER `user_cancel`;

ALTER TABLE `ivf_101`.`b_item` 
ADD COLUMN `status_item` VARCHAR(45) NULL COMMENT '0=default;1=lab; 2=special;3=drug' AFTER `user_cancel`;

ALTER TABLE ivf_101.b_item AUTO_INCREMENT = 2070000000;

ALTER TABLE `ivf_101`.`b_item` 
ADD COLUMN `item_master_id` BIGINT NULL AFTER `status_item`,
ADD COLUMN `item_link_id` BIGINT NULL AFTER `item_master_id`;

ALTER TABLE `ivf_101_donor`.`b_item` 
ADD COLUMN `item_master_id` BIGINT NULL AFTER `status_item`,
ADD COLUMN `item_link_id` BIGINT NULL AFTER `item_master_id`;


ALTER TABLE `ivf`.`labitem` 
ADD COLUMN `date_create` VARCHAR(45) NULL AFTER `item_code`,
ADD COLUMN `date_modi` VARCHAR(45) NULL AFTER `date_create`,
ADD COLUMN `date_cancel` VARCHAR(45) NULL AFTER `date_modi`,
ADD COLUMN `user_create` VARCHAR(45) NULL AFTER `date_cancel`,
ADD COLUMN `user_modi` VARCHAR(45) NULL AFTER `user_create`,
ADD COLUMN `user_cancel` VARCHAR(45) NULL AFTER `user_modi`;

ALTER TABLE `ivf`.`specialitem` 
ADD COLUMN `date_create` VARCHAR(45) NULL AFTER `status_discount`,
ADD COLUMN `date_modi` VARCHAR(45) NULL AFTER `date_create`,
ADD COLUMN `date_cancel` VARCHAR(45) NULL AFTER `date_modi`,
ADD COLUMN `user_create` VARCHAR(45) NULL AFTER `date_cancel`,
ADD COLUMN `user_modi` VARCHAR(45) NULL AFTER `user_create`,
ADD COLUMN `user_cancel` VARCHAR(45) NULL AFTER `user_modi`;

ALTER TABLE `ivf`.`stockdrug` 
ADD COLUMN `date_create` VARCHAR(45) NULL AFTER `order_amount_sub_3`,
ADD COLUMN `date_modi` VARCHAR(45) NULL AFTER `date_create`,
ADD COLUMN `date_cancel` VARCHAR(45) NULL AFTER `date_modi`,
ADD COLUMN `user_create` VARCHAR(45) NULL AFTER `date_cancel`,
ADD COLUMN `user_modi` VARCHAR(45) NULL AFTER `user_create`,
ADD COLUMN `user_cancel` VARCHAR(45) NULL AFTER `user_modi`;


63-03-14
ALTER TABLE `ivf`.`b_company` 
ADD COLUMN `receipt1_doc` INT NULL AFTER `month_curr_cashier`,
ADD COLUMN `prefix_receipt1_doc` VARCHAR(45) NULL AFTER `receipt1_doc`;

ALTER TABLE `ivf_101`.`billheader` 
ADD COLUMN `receipt1_no` VARCHAR(45) NULL AFTER `closeday_id`;

63-05-14
ALTER TABLE `ivf`.`lab_t_opu` 
ADD COLUMN `report_day1` VARCHAR(45) NULL AFTER `remark_day6`,
ADD COLUMN `report_day3` VARCHAR(45) NULL AFTER `report_day1`,
ADD COLUMN `report_day6` VARCHAR(45) NULL AFTER `report_day3`;


ALTER TABLE `ivf`.`PackageHeader` 
COMMENT = 'id=257' ;

ALTER TABLE `ivf`.`PackageHeader` 
ADD COLUMN `pckid_old` BIGINT NULL AFTER `active`,
CHANGE COLUMN `PCKID` `PCKID` BIGINT NOT NULL ;

update PackageHeader
set pckid_old = pckid;

ALTER TABLE PackageHeader AUTO_INCREMENT = 2570000048;

ALTER TABLE `ivf`.`PackageHeader` 
ENGINE = MyISAM ;

ALTER TABLE `ivf`.`PackageDetail` 
ENGINE = MyISAM ;

ALTER TABLE `ivf`.`PackageSold` 
ENGINE = MyISAM , COMMENT = 'id=258' ;

ALTER TABLE `ivf`.`PackageSold` 
CHARACTER SET = utf8 , COLLATE = utf8_bin ;

ALTER TABLE `ivf`.`PackageSold` 
CHANGE COLUMN `PCKSID` `PCKSID` BIGINT NOT NULL ,
CHANGE COLUMN `PID` `PID` BIGINT NULL DEFAULT NULL ,
CHANGE COLUMN `PCKID` `PCKID` BIGINT NULL DEFAULT NULL ;

ALTER TABLE `ivf`.`PackageSellThru` 
ENGINE = MyISAM , COMMENT = 'id=259' ;

ALTER TABLE `ivf`.`PackageSellThru` 
CHARACTER SET = utf8 , COLLATE = utf8_bin , ENGINE = MyISAM , COMMENT = 'id=259' ;

ALTER TABLE `ivf`.`PackageSellThru` 
CHANGE COLUMN `STID` `STID` BIGINT NOT NULL ;

ALTER TABLE `ivf`.`PackageDetail` 
CHANGE COLUMN `ID` `ID` BIGINT NOT NULL ,
CHANGE COLUMN `PCKID` `PCKID` BIGINT NULL DEFAULT NULL ,
CHANGE COLUMN `ItemID` `ItemID` BIGINT NULL DEFAULT NULL ;

ALTER TABLE `ivf`.`PackageDeposit` 
ENGINE = MyISAM , COMMENT = 'id=260' ;

ALTER TABLE `ivf`.`PackageDeposit` 
CHANGE COLUMN `PCKDPSID` `PCKDPSID` BIGINT NOT NULL ,
CHANGE COLUMN `PCKSID` `PCKSID` BIGINT NULL DEFAULT NULL ,
CHANGE COLUMN `PID` `PID` BIGINT NULL DEFAULT NULL ,
CHANGE COLUMN `ItemID` `ItemID` BIGINT NULL DEFAULT NULL ;

ALTER TABLE `ivf`.`PackageDepositDetail` 
ENGINE = MyISAM , COMMENT = 'id=261' ;

ALTER TABLE `ivf`.`PackageDepositDetail` 
CHANGE COLUMN `ID` `ID` BIGINT NOT NULL ,
CHANGE COLUMN `PCKDPSID` `PCKDPSID` BIGINT NOT NULL ,
CHANGE COLUMN `JobDetailID` `JobDetailID` BIGINT NOT NULL ,
CHANGE COLUMN `PCKSID` `PCKSID` BIGINT NOT NULL ;

ALTER TABLE `ivf`.`BillDetail` 
CHANGE COLUMN `item_id` `item_id` BIGINT NULL DEFAULT NULL ,
CHANGE COLUMN `pcksid` `pcksid` BIGINT NULL DEFAULT NULL ;


update ivf.PackageHeader set PCKID = 2570000000 where PCKID = 6;
update ivf.PackageDetail set PCKID = 2570000000 where PCKID = 6;
update ivf.PackageSold set PCKID = 2570000000 where PCKID = 6;
update ivf.BillDetail set item_id = 2570000000 where item_id = 6 and status = 'package';

  ALTER TABLE `ivf`.`SpecialItem` 
ENGINE = MyISAM ;

ALTER TABLE `ivf`.`SpecialItem` 
CHANGE COLUMN `SID` `SID` BIGINT NOT NULL ;

ALTER TABLE `ivf`.`LabItem` 
CHANGE COLUMN `LID` `LID` BIGINT NOT NULL ,
CHANGE COLUMN `LGID` `LGID` BIGINT NOT NULL , COMMENT = 'id=258' ;

ALTER TABLE LabItem AUTO_INCREMENT = 2580000149;

ALTER TABLE `ivf`.`SpecialItem` 
COMMENT = 'id=259' ;

ALTER TABLE `ivf`.`SpecialItem` 
CHANGE COLUMN `BillGroupID` `BillGroupID` BIGINT NULL DEFAULT NULL ;

ALTER TABLE `ivf`.`LabItem` 
ADD COLUMN `lid_old` BIGINT NULL AFTER `LGName`;

ALTER TABLE `ivf`.`SpecialItem` 
ADD COLUMN `sid_old` BIGINT NULL AFTER `item_code`;

ALTER TABLE `ivf`.`BillGroup` 
COMMENT = 'id=260' ;

ALTER TABLE `ivf`.`BillGroup` 
ENGINE = MyISAM ;

ALTER TABLE `ivf`.`BillGroup` 
ADD COLUMN `id_old` BIGINT NULL AFTER `active`;

update SpecialItem set SID = 2590000000 where SID = 169;
update JobSpecialDetail set SID = 2590000000 where SID = 169;
update BillDetail set item_id = 2590000000 where item_id = 169;

update LabItem set LID = 2580000006 where LID = 13;
update JobLabDetail set LID = 2580000006 where LID = 13;
update BillDetail set item_id = 25800000006 where item_id = 13;

update BillGroup set ID = 2600000000 where ID = 0;
update BillDetail set bill_group_id = 2600000000 Where bill_group_id = 0;
  
