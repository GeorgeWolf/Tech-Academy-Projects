# Python:   3.6.5
#
# Author:   George Wolf (georgewolf.ot@gmail.com)
#
# Purpose:  Tkinter GUI Development Practice (The Tech Academy)

from tkinter import *
from tkinter import ttk
from tkinter import messagebox #Pop up window imported

class Feedback:

    def __init__(self, master):
        
        #Change style, title, etc
        master.title('Explore California Feedback')
        master.resizable(False, False)
        master.configure(background = '#e1d8b9')

        #Backgorund color and font for all elements
        self.style = ttk.Style()
        self.style.configure('TFrame', background = '#e1d8b9')
        self.style.configure('TButton', background = '#e1d8b9')
        self.style.configure('TLabel', background = '#e1d8b9', font = ('Arial', 11))
        self.style.configure('Header.TLabel', font = ('Arial', 18, 'bold'))

        self.frame_header = ttk.Frame(master) #Creates header frame, child of master
        self.frame_header.pack() #Places header frame into the window

        #Logo saved to class variable to avoid being garbage collected after init method completion
        self.logo = PhotoImage(file = 'tour_logo.gif')
        #Labels, child of frame_header, not stored in a variable(.grid can be added directly)
        ttk.Label(self.frame_header, image = self.logo).grid(row = 0, column = 0, rowspan = 2)
        ttk.Label(self.frame_header, text = "Thanks for Exploring!", style = 'Header.TLabel').grid(row = 0, column = 1)
        ttk.Label(self.frame_header, wraplength = 300,
                  text = ("We're glad you chose Explore California for your recent adventure. "
                          "Please tell us what you thought about the 'Desert to Sea' tour.")).grid(row = 1, column = 1)

        self.frame_content = ttk.Frame(master) #Creates content frame, child of master
        self.frame_content.pack() #Places content frame into the window

        #Labels, child of frame_content, not stored in a variable(.grid can be added directly)
        ttk.Label(self.frame_content, text = 'Name:').grid(row = 0, column = 0, padx = 5, sticky = 'sw')
        ttk.Label(self.frame_content, text = 'Email:').grid(row = 0, column = 1, padx = 5, sticky = 'sw')
        ttk.Label(self.frame_content, text = 'Comments:').grid(row = 2, column = 0, padx = 5, sticky = 'sw')

        #Entry widgets, one line, child of frame_content
        self.entry_name = ttk.Entry(self.frame_content, width = 24, font = ('Arial', 10))
        self.entry_email = ttk.Entry(self.frame_content, width = 24, font = ('Arial', 10))
        #Text, not themed tk widget(no ttk.), multiple lines, child of frame_content
        self.text_comments = Text(self.frame_content, width = 50, height = 10, font = ('Arial', 10))

        #Entry and text variables(.grid added)
        self.entry_name.grid(row = 1, column = 0, padx = 5)
        self.entry_email.grid(row = 1, column = 1, padx = 5)
        self.text_comments.grid(row = 3, column = 0, columnspan = 2, padx = 5)

        #Buttons, not saved to local variables, just executing commands, not need to referenced
        ttk.Button(self.frame_content, text = 'Submit', command = self.submit).grid(row = 4, column = 0, padx = 5, sticky = 'e')
        ttk.Button(self.frame_content, text = 'Clear', command = self.clear).grid(row = 4, column = 1, padx = 5, sticky = 'w')

    def submit(self):
        #Retrieve the values from the fields and print to console (in a real program it's "submit" instead of "print")
        print('Name: {}'.format(self.entry_name.get()))
        print('Email: {}'.format(self.entry_email.get()))
        print('Comments: {}'.format(self.text_comments.get(1.0, 'end')))
        #Clear fields
        self.clear()
        #Notify, comment submitted
        messagebox.showinfo(title = "Explore California Feedback", message = "Comments Submitted")
        
    #Clear entry fields
    def clear(self):
        self.entry_name.delete(0, 'end')
        self.entry_email.delete(0, 'end')
        self.text_comments.delete(1.0, 'end')

def main():

    root = Tk()
    feedback = Feedback(root)
    root.mainloop()

if __name__ == "__main__": main()
