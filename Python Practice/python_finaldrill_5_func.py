#!/usr/bin/python
# -*- coding: utf-8 -*-
# Python Ver:   3.6.2
#
# Author:       George Wolf (georgewolf.ot@gmail.com)
#
# Purpose:      Python Final Drill 5 - Database Functionality for File Transfer project (The Tech Academy)
#
# Tested OS:    This code was written and tested to work with Windows 10.



import os, time, glob, shutil
import datetime as dt
from tkinter import *
from tkinter import messagebox, filedialog
import tkinter as tk
import sqlite3
from dateutil import parser

import python_finaldrill_5_main
import python_finaldrill_5_gui


def center_window(self, w, h): # pass in the tkinter frame (master) reference and the w and h
    # get user's screen width and height
    screen_width = self.master.winfo_screenwidth()
    screen_height = self.master.winfo_screenheight()
    # calculate x and y coordinates to paint the app centered on the user's screen
    x = int((screen_width/2) - (w/2))
    y = int((screen_height/2) - (h/2))
    centerGeo = self.master.geometry('{}x{}+{}+{}'.format(w, h, x, y))
    return centerGeo


# catch if the user's clicks on the windows upper-right 'X' to ensure they want to close
def ask_quit(self):
    if messagebox.askokcancel("Exit program", "Okay to exit application?"):
        # This closes the app
        self.master.destroy()
        os._exit(0)
        
folderA = ""
folderB = ""
present = ""
lastCheck = ""


def browseFolder1(self):
    global folderA
    folderA = filedialog.askdirectory()
    if folderA is "":
        messagebox.showinfo("Cancelled","Source folder selection cancelled.")
    else:
        messagebox.showinfo("Success","Source folder successfully selected!")
        

def browseFolder2(self):
    global folderB
    folderB = filedialog.askdirectory()
    if folderB is "":
        messagebox.showinfo("Cancelled","Destination folder selection cancelled.")
    else:
        messagebox.showinfo("Success","Destination folder successfully selected!")

    
# copy all modified or newly created txt files (in the last 24 hours)
def fileCheck(self):
    global present
    present = dt.datetime.now()
    txtFiles = folderA + "\*.txt"
    if folderA is "" and folderB is not "":
        messagebox.showinfo("Error","No Source folder found!\nPlease select a Source folder.")
    if folderB is "" and folderA is not "":
        messagebox.showinfo("Error","No Destination folder found!\nPlease select a Destination folder.")
    if folderA is "" and folderB is "":
        messagebox.showinfo("Error","No Source and Destination folder found!\nPlease select a Source and Destination folder.")
    if folderA is not "" and folderB is not "":
        for files in glob.glob(txtFiles):
            stat = os.stat(files)
            mtime = dt.datetime.fromtimestamp(stat.st_mtime)
            if mtime >= lastCheck:     
                print('%s Modified: %s' %(files, mtime)) # prints out all the file paths and time change
                shutil.copy2(files, folderB)
        save_datetime(self)
        time_select(self)
        messagebox.showinfo("File Check Successful","You have successfully copied all files\nmodified/created since the last File Check.\nAwesome!\nNow let's go have a Cookie! :P")


# create database and table
def create_db(self):
    conn = sqlite3.connect('db_filecheck.db')
    with conn:
        cur = conn.cursor()
        cur.execute("CREATE TABLE if not exists tbl_filecheck( \
            ID INTEGER PRIMARY KEY AUTOINCREMENT, \
            col_success TEXT, \
            col_datetime INTEGER \
            );")
        # commit() to save changes & close the database connection
        conn.commit()
    conn.close()
    first_run(self)
    time_select(self)

# create first row of data (Database time creation)
def first_run(self):
    startTime = dt.datetime.now()
    conn = sqlite3.connect('db_filecheck.db')
    with conn:
        cur = conn.cursor()
        cur,count = count_records(cur)
        if count < 1:
            cur.execute("""INSERT INTO tbl_filecheck (col_success,col_datetime) VALUES (?,?)""", ('Database Created',startTime))
            conn.commit()
    conn.close()


# saves Date and Time to db_filecheck when File Check done
def save_datetime(self):
    conn = sqlite3.connect('db_filecheck.db')
    with conn:
        cur = conn.cursor()
        cur,count = count_records(cur)
        cur.execute("""INSERT INTO tbl_filecheck (col_success,col_datetime) VALUES (?,?)""", ('FileCheck Successful',present))
        conn.commit()
    conn.close()

# select last saved Date and Time and displays it to GUI
def time_select(self):
    global lastCheck
    conn = sqlite3.connect('db_filecheck.db')
    with conn:
        cursor = conn.cursor()
        cursor.execute("""SELECT col_datetime FROM tbl_filecheck ORDER BY ID DESC LIMIT 1""")
        varBody = cursor.fetchone()
        for data in varBody:
            self.txt_lastCheck.config(state="normal")
            lastCheck = parser.parse(data)
            self.txt_lastCheck.delete(0,END)
            self.txt_lastCheck.insert(0,data)
            print('Last File Check Time: %s' %(lastCheck))
            self.txt_lastCheck.config(state="readonly")


def count_records(cur):
    count = ""
    cur.execute("""SELECT COUNT(*) FROM tbl_filecheck""")
    count = cur.fetchone()[0]
    return cur,count
   

if __name__ == "__main__":
    pass
