#!/usr/bin/python
# -*- coding: utf-8 -*-
# Python Ver:   2.7.1
#
# Author:       George Wolf (georgewolf.ot@gmail.com)
#
# Purpose:      Python Final Drill 2 - File Mover (The Tech Academy)
#
# Tested OS:    This code was written and tested to work with Windows 10.


import shutil
import os
import glob

# Source and Destination folders
folderA = 'C:\Users\MrWolf\Desktop\Folder A' # Replace it with your own source folder
folderB = 'C:\Users\MrWolf\Desktop\Folder B' # Replace it with your own destination folder

txtFiles = folderA + "\*.txt"

# move all .txt files
for files in glob.glob(txtFiles):
    shutil.move(files, folderB)
    print files # prints out each file path that got moved
