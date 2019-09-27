#!/bin/bash

name="Ekapop"

#$date1 = $date "+%y-%m-%d" 

curdate="$(date +'%Y%m%d%H%M%S')"
ivfdonor="ivf_101_donor_$(date +'%Y%m%d%H%M%S').sql"
ivf="ivf_101_$(date +'%Y%m%d%H%M%S').sql"
echo $ivfdonor
echo $ivf

ivfdonor1="ivf_101_donor_$curdate.sql"
ivfdonortar="ivf_101_donor_$curdate.tar.gz"
ivf1="ivf_101_$curdate.sql"
ivftar="ivf_101_$curdate.tar.gz"
echo $ivfdonor1

user=root
password=ivf2017
host=localhost

mysqldump --user=$user --host=$host --password=$password  ivf_101_donor > /backup/$ivfdonor1

mysqldump --user=$user --host=$host --password=$password ivf_101 > /backup/$ivf1

tar -czvf $ivfdonortar  $ivfdonor1
tar -czvf $ivftar $ivf1
