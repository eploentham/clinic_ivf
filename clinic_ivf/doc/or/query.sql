select  TOP (100) t06.mnc_ph_cd, m01.MNC_PH_TN, sum(t06.MNC_PH_QTY_PAY)  as qty, m05.MNC_PH_PRI01, m05.MNC_PH_COS
from PHARMACY_T06 as t06
left join PHARMACY_M01 as m01 on t06.mnc_ph_cd = m01.MNC_PH_CD
left join PHARMACY_M05 as m05 on t06.mnc_ph_cd = m05.MNC_PH_CD
group by t06.mnc_ph_cd,m01.MNC_PH_TN, m05.MNC_PH_PRI01, m05.MNC_PH_COS
order by qty desc


select  TOP (100) t06.mnc_ph_cd, sum(t06.MNC_PH_QTY_PAY)  as qty--, t06.mnc_ph_pri, t06.MNC_PH_COS
from PHARMACY_T06 as t06
group by t06.mnc_ph_cd--,t06.mnc_ph_pri, t06.MNC_PH_COS
order by qty desc