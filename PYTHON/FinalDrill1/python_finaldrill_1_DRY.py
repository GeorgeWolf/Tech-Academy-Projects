#!/usr/bin/python
# -*- coding: utf-8 -*-
# Python Ver:   3.6.5
#
# Author:       George Wolf (georgewolf.ot@gmail.com)
#
# Purpose:      Python Final Drill 1 - Datetime - DRY version (The Tech Academy)
#
# Tested OS:    This code was written and tested to work with Windows 10.


from datetime import  datetime
from pytz import timezone


def branch():    
    timezones = ['US/Eastern','US/Pacific','Europe/London']
    for zone in timezones:
        nowTime = [datetime.now(timezone(zone))]       
        for timeNow in nowTime:
            BranchTime=int(timeNow.strftime('%H'))
            if BranchTime >=9  and BranchTime <= 21:
                print(zone,'OPEN',timeNow)
            else:
                print(zone,'CLOSED',timeNow)
branch()
