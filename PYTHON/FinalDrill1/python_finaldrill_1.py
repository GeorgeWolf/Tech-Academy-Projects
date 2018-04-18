#!/usr/bin/python
# -*- coding: utf-8 -*-
# Python Ver:   2.7.14
#
# Author:       George Wolf (georgewolf.ot@gmail.com)
#
# Purpose:      Python Final Drill 1 - Datetime (The Tech Academy)
#
# Tested OS:    This code was written and tested to work with Windows 10.



# 1)This code can be used from any timezone, replaces # 2)

##from datetime import datetime, timedelta, time
##
### UTC time
##timeUTC = datetime.utcnow()
###print 'UTC Time:',timeUTC
##
### timePortland = current time in Portland compared to UTC time
##timePortland = timeUTC + timedelta(hours=-7)
###print 'Portland Time:',timePortland
##
### timeNYC = current time in New York City compared to UTC time
##timeNYC = timeUTC + timedelta(hours=-4)
###print 'NYC Time:',timeNYC 
##
### timeLondon = current time in London compared to UTC time
##timeLondon = timeUTC + timedelta(hours=1)
###print 'London Time:',timeLondon
##
### Opening Hours (09:00 - 21:00)
##openingHour = time(9,0,0)
##closingHour = time(21,0,0)
###print 'Opens at:',openingHour
###print 'Closes at:',closingHour
##
### check if NYC branch open
##if timeNYC.time() >= openingHour and timeNYC.time() <= closingHour:
##    print 'NYC Branch: Open'
##else:
##    print 'NYC Branch: Closed'
##
### check if London branch open
##if timeLondon.time() >= openingHour and timeLondon.time() <= closingHour:
##    print 'London Branch: Open'
##else:
##    print 'London Branch: Closed'



# 2)This code only works accurately if you are located in Portland, Oregon

import datetime
from datetime import timedelta, time

# timePortland = current time in Portland
timePortland = datetime.datetime.now()
#print 'Portland Time:',timePortland

# timeNYC = current time in New York City to Portland
timeNYC = timePortland + timedelta(hours=3)
#print 'NYC Time:',timeNYC

# timeLondon = current time in London compared to Portland
timeLondon = timePortland + timedelta(hours=8)
#print 'London Time:',timeLondon

# Opening Hours (09:00 - 21:00)
openingHour = time(9,0,0)
closingHour = time(21,0,0)
#print 'Opens at:',openingHour
#print 'Closes at:',closingHour

# check if NYC branch open
if timeNYC.time() >= openingHour and timeNYC.time() <= closingHour:
    print 'NYC Branch: Open'
else:
    print 'NYC Branch: Closed'

# check if London branch open
if timeLondon.time() >= openingHour and timeLondon.time() <= closingHour:
    print 'London Branch: Open'
else:
    print 'London Branch: Closed'
