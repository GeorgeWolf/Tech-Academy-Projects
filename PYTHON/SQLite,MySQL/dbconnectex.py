#!/usr/bin/python
# -*- coding: utf-8 -*-
# Python Ver:   3.6.5
#
# Author:       George Wolf (georgewolf.ot@gmail.com)
#
# Purpose:      pythonanywhere.com MySQL practice (The Tech Academy)
#
# Tested OS:    This code was written and tested to work with Windows 10.


import MySQLdb
import time

conn = MySQLdb.connect("Pradopte.mysql.pythonanywhere-services.com","Pradopte","wolfpython","Pradopte$tutorial")

c = conn.cursor()

username = 'Python'
tweet = 'man im so cool'

c.execute("INSERT INTO wolves (time, username, tweet) VALUES (%s,%s,%s)",
            (time.time(), username, tweet))

conn.commit()


c.execute("SELECT * FROM wolves")

rows = c.fetchall()

for eachRow in rows:
    print(eachRow)
