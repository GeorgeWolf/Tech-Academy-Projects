#!/usr/bin/python
# -*- coding: utf-8 -*-
# Python Ver:   3.6.2
#
# Author:       George Wolf (georgewolf.ot@gmail.com)
#
# Purpose:      Python Final Drill 4 - UI for File Transfer project (The Tech Academy)
#
# Tested OS:    This code was written and tested to work with Windows 10.


from tkinter import *
import tkinter as tk

import python_finaldrill_4_gui
import python_finaldrill_4_func

# Frame is the Tkinter frame class that our own class will inherit from
class ParentWindow(Frame):
    def __init__(self, master, *args, **kwargs):
        Frame.__init__(self, master, *args, **kwargs)

        # define our master frame configuration
        self.master = master
        self.master.minsize(320,155) #(Height, Width)
        self.master.maxsize(320,155)
        # This CenterWindow method will center our app on the user's screen
        python_finaldrill_4_func.center_window(self,500,300)
        self.master.title("File Transfer")
        self.master.configure(bg="#F0F0F0")
        # This protocol method is a tkinter built-in method to catch if 
        # the user clicks the upper corner, "X" on Windows OS.
        self.master.protocol("WM_DELETE_WINDOW", lambda: python_finaldrill_4_func.ask_quit(self))

        # load in the GUI widgets from a separate module, 
        # keeping your code compartmentalized and clutter free
        python_finaldrill_4_gui.load_gui(self)

        
if __name__ == "__main__":
    root = tk.Tk()
    App = ParentWindow(root)
    root.mainloop()
