#!/usr/bin/python
# -*- coding: utf-8 -*-
# Python Ver:   3.6.5
#
# Author:       George Wolf (georgewolf.ot@gmail.com)
#
# Purpose:      Python Final Drill 4 - UI for File Transfer project (The Tech Academy)
#
# Tested OS:    This code was written and tested to work with Windows 10.


from tkinter import *
import tkinter as tk

import python_finaldrill_4_main
import python_finaldrill_4_func


def load_gui(self):

    self.lbl_browse1 = tk.Label(self.master,text='Select your folders to copy files from source to destination')
    self.lbl_browse1.grid(row=0,column=0,columnspan=2,padx=(1,1),pady=(1,1),sticky=N+E+S+W)
    
    self.btn_browse1 = tk.Button(self.master,width=12,height=2,text='Source',command=lambda: python_finaldrill_4_func.browseFolder1(self))
    self.btn_browse1.grid(row=1,column=0,padx=(1,1),pady=(1,1),sticky=N+E+S+W)
    self.btn_browse2 = tk.Button(self.master,width=12,height=2,text='Destination',command=lambda: python_finaldrill_4_func.browseFolder2(self))
    self.btn_browse2.grid(row=1,column=1,padx=(1,1),pady=(1,1),sticky=N+E+S+W)
    self.btn_fileCheck = tk.Button(self.master,width=12,height=2,text='File Check',command=lambda: python_finaldrill_4_func.fileCheck(self))
    self.btn_fileCheck.grid(row=2,column=0,columnspan=2,padx=(1,1),pady=(1,1),sticky=N+E+S+W)
    self.btn_exit = tk.Button(self.master,width=12,height=2,text='Exit',command=lambda: python_finaldrill_4_func.ask_quit(self))
    self.btn_exit.grid(row=3,column=0,columnspan=2,padx=(1,1),pady=(1,1),sticky=N+E+S+W)

    
if __name__ == "__main__":
    pass
