#!/usr/bin/python
# -*- coding: utf-8 -*-
# Python Ver:   3.6.2
#
# Author:       George Wolf (georgewolf.ot@gmail.com)
#
# Purpose:      Python Final Drill 5 - Database Functionality for File Transfer project (The Tech Academy)
#
# Tested OS:    This code was written and tested to work with Windows 10.


from tkinter import *
import tkinter as tk

import python_finaldrill_5_main
import python_finaldrill_5_func


def load_gui(self):
    
    self.lbl_browse1 = tk.Label(self.master,text='Select your folders to copy files from source to destination')
    self.lbl_browse1.grid(row=0,column=0,columnspan=2,padx=(1,1),pady=(1,1),sticky=N+E+S+W)
    self.lbl_browse1 = tk.Label(self.master,text='Last File Check Time:')
    self.lbl_browse1.grid(row=4,column=0,padx=(1,1),pady=(1,1),sticky=N+E+S+W)

    self.txt_folderApath = tk.Entry(self.master,text='')
    self.txt_folderApath.grid(row=2,column=0,padx=(1,1),pady=(1,1),sticky=N+E+S+W)
    self.txt_folderApath.config(state="readonly")
    self.txt_folderBpath = tk.Entry(self.master,text='')
    self.txt_folderBpath.grid(row=2,column=1,padx=(1,1),pady=(1,1),sticky=N+E+S+W)
    self.txt_folderBpath.config(state="readonly")
    self.txt_lastCheck = tk.Entry(self.master,text='')
    self.txt_lastCheck.grid(row=4,column=1,padx=(1,1),pady=(1,1),sticky=N+E+S+W)
    
    self.btn_browse1 = tk.Button(self.master,width=12,height=2,text='Source',command=lambda: python_finaldrill_5_func.browseFolder1(self))
    self.btn_browse1.grid(row=1,column=0,padx=(1,1),pady=(1,1),sticky=N+E+S+W)
    self.btn_browse2 = tk.Button(self.master,width=12,height=2,text='Destination',command=lambda: python_finaldrill_5_func.browseFolder2(self))
    self.btn_browse2.grid(row=1,column=1,padx=(1,1),pady=(1,1),sticky=N+E+S+W)
    self.btn_fileCheck = tk.Button(self.master,width=12,height=2,text='File Check',command=lambda: python_finaldrill_5_func.fileCheck(self))
    self.btn_fileCheck.grid(row=3,column=0,columnspan=2,padx=(1,1),pady=(1,1),sticky=N+E+S+W)
    self.btn_exit = tk.Button(self.master,width=12,height=2,text='Exit',command=lambda: python_finaldrill_5_func.ask_quit(self))
    self.btn_exit.grid(row=5,column=0,columnspan=2,padx=(1,1),pady=(1,1),sticky=N+E+S+W)
    
    python_finaldrill_5_func.create_db(self)
    
    
    
if __name__ == "__main__":
    pass
