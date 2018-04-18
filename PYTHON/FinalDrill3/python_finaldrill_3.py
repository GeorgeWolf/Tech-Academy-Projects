#!/usr/bin/python
# -*- coding: utf-8 -*-
# Python Ver:   2.7.14
#
# Author:       George Wolf (georgewolf.ot@gmail.com)
#
# Purpose:      Python Final Drill 3 - Daily File Transfer scripting project (The Tech Academy)
#
# Tested OS:    This code was written and tested to work with Windows 10.


import shutil
import os, time
import glob
import datetime as dt


present = dt.datetime.now()
past = present-dt.timedelta(hours=24)


# Source and Destination folders
folderA = 'C:\Users\MrWolf\Desktop\Folder A' # Replace it with your own source folder
folderB = 'C:\Users\MrWolf\Desktop\Folder B' # Replace it with your own destination folder

txtFiles = folderA + "\*.txt"

# copy all modified or newly created txt files (in the last 24 hours)
for files in glob.glob(txtFiles):
    stat = os.stat(files)
    mtime = dt.datetime.fromtimestamp(stat.st_mtime)
    if mtime >= past:     
        print('%s Modified: %s' %(files, mtime)) # prints out all the file paths and time change
        shutil.copy2(files, folderB)

