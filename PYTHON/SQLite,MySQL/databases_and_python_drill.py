from __future__ import unicode_literals # string stored as a unicode by default (Default in Python 3)
#!/usr/bin/python
# -*- coding: utf-8 -*-
# Python Ver:   2.7.14
#
# Author:       George Wolf (georgewolf.ot@gmail.com)
#
# Purpose:      Databases and Python drill (The Tech Academy)
#
# Tested OS:    This code was written and tested to work with Windows 10.


import sqlite3


creaturesValues = (
    ("Jean-Baptiste Zorg","Human",122),
    ("Korben Dallas","Meat Popsicle",100),
    ("Ak'not","Mangalore",-5)
    )

with sqlite3.connect(':memory:') as connection:
    c = connection.cursor()
    c.execute("DROP TABLE IF EXISTS Roster")
    c.execute("CREATE TABLE Roster(Name TEXT, Species TEXT, IQ INT)")
    c.executemany("INSERT INTO Roster VALUES(?,?,?)",creaturesValues)
    c.execute("UPDATE Roster SET Species=? WHERE Name=?",('Human', 'Korben Dallas'))
    c.execute("SELECT Name,IQ FROM Roster WHERE Species == 'Human'")
    for row in c.fetchall():
        print row
