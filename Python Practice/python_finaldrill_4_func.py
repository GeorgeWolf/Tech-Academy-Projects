#!/usr/bin/python
# -*- coding: utf-8 -*-
# Python Ver:   3.6.2
#
# Author:       George Wolf (georgewolf.ot@gmail.com)
#
# Purpose:      Python Final Drill 4 - UI for File Transfer project (The Tech Academy)
#
# Tested OS:    This code was written and tested to work with Windows 10.


import shutil
import os, time
import glob
import datetime as dt
from tkinter import *
from tkinter import messagebox
import tkinter as tk
from tkinter import filedialog

import python_finaldrill_4_main
import python_finaldrill_4_gui


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
        
folderA =  ""
folderB =  ""


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
    present = dt.datetime.now()
    past = present-dt.timedelta(hours=24)
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
            if mtime >= past:     
                print('%s Modified: %s' %(files, mtime)) # prints out all the file paths and time change
                shutil.copy2(files, folderB)
        messagebox.showinfo("File Check Successful","You have successfully copied all files\nmodified/created in the last 24 hours.\nWell done!\nNow let's go have an IceCream! :P")
    

if __name__ == "__main__":
    pass
