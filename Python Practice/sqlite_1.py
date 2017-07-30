#!/usr/bin/python
# -*- coding: utf-8 -*-
# Python Ver:   3.6.2
#
# Author:       George Wolf (georgewolf.ot@gmail.com)
#
# Purpose:      SQLite3 practice (The Tech Academy)
#
# Tested OS:    This code was written and tested to work with Windows 10.


import sqlite3


conn = sqlite3.connect('tutorial.db')
c = conn.cursor()

def create_table():
    c.execute("CREATE TABLE IF NOT EXISTS stuffToPlot(unix REAL, datestamp TEXT, keyword TEXT, value REAL)")

def data_entry():
    c.execute("INSERT INTO stuffToPlot VALUES(1234567890, '2017-01-01', 'Python', 8)")
    conn.commit()
    c.close()
    conn.close()


create_table()
data_entry()
