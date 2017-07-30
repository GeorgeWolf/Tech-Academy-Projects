from __future__ import unicode_literals # string stored as a unicode by default (Default in Python 3)
#!/usr/bin/python
# -*- coding: utf-8 -*-
# Python Ver:   2.7.1
#
# Author:       George Wolf (georgewolf.ot@gmail.com)
#
# Purpose:      Databases and Python practice (The Tech Academy)
#
# Tested OS:    This code was written and tested to work with Windows 10.


import sqlite3

# 1st part

##connection = sqlite3.connect("test_database.db")
##connection = sqlite3.connect(':memory:') # to create database in temporary RAM like
##c = connection.cursor()
##c.execute("CREATE TABLE People(FirstName TEXT, LastName TEXT, Age INT)")
##c.execute("INSERT INTO People VALUES('Ron','Obvious',42)")
##connection.commit()
##connection.close()


# 2nd part

##peopleValues = (
##    ('Ron','Obvious',42),
##    ('Luigi','Vercotti',43),
##    ('Arthur','Belling',28)
##    )
##
##with sqlite3.connect('test_database.db') as connection:
##    c = connection.cursor()
##    c.executescript("""
##    DROP TABLE IF EXISTS People;
##    CREATE TABLE People(FirstName TEXT, LastName TEXT, Age INT);
##    INSERT INTO People VALUES('Ron','Obvious','42');
##    """)
##    c.executemany("INSERT INTO People VALUES(?,?,?)",peopleValues)


# 3rd part - code can be broken as it's not parameterized

### get person data from user
##firstName = raw_input("Enter your first name:")
##lastName = raw_input("Enter your last name:")
##age = int(raw_input("Enter your age:"))
##
### execute insert statement for supplied person data
##with sqlite3.connect('test_database.db') as connection:
##    c = connection.cursor()
##    line = "INSERT INTO People Values('"+ firstName +"','"+ lastName +"'," + str(age) + ")"
##    c.execute(line)
##    print line


# 4th part

### get person data form user and isert into a tuple
##firstName = raw_input("Enter your first name:")
##lastName = raw_input("Enter your last name:")
##age = int(raw_input("Enter your age:"))
##personData = (firstName, lastName, age)
##
### execute insert statement for supplied person data
##with sqlite3.connect('test_database.db') as connection:
##    c = connection.cursor()
##    c.execute("INSERT INTO People VALUES(?,?,?)", personData)
##    c.execute("UPDATE People SET Age=? WHERE FirstName=? AND LastName=?",
##              (45, 'Luigi', 'Vercotti'))


# 5th part - fetchall()

##peopleValues = (
##    ('Ron','Obvious',42),
##    ('Luigi','Vercotti',43),
##    ('Arthur','Belling',28)
##    )
##
##with sqlite3.connect('test_database.db') as connection:
##    c = connection.cursor()
##    c.execute("DROP TABLE IF EXISTS People")
##    c.execute("CREATE TABLE People(FirstName TEXT, LastName TEXT, Age INT)")
##    c.executemany("INSERT INTO People VALUES(?,?,?)",peopleValues)
##
##    # select all first and last names from people over age 30
##    c.execute("SELECT FirstName,LastName FROM People WHERE Age > 30")
##    for row in c.fetchall():
##        print row


# 6th part - fetchone()

peopleValues = (
    ('Ron','Obvious',42),
    ('Luigi','Vercotti',43),
    ('Arthur','Belling',28)
    )

with sqlite3.connect('test_database.db') as connection:
    c = connection.cursor()
    c.execute("DROP TABLE IF EXISTS People")
    c.execute("CREATE TABLE People(FirstName TEXT, LastName TEXT, Age INT)")
    c.executemany("INSERT INTO People VALUES(?,?,?)",peopleValues)

    # select all first and last names from people over age 30
    c.execute("SELECT FirstName,LastName FROM People WHERE Age > 30")
    while True:
        row = c.fetchone()
        if row is None:
            break
        print row
