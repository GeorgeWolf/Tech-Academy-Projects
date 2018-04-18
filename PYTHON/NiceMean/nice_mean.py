# Python:   2.7.14
#
# Author:   George Wolf (georgewolf.ot@gmail.com)
#
# Purpose:  The Tech Academy - Python Course, Drill 6 of 63
#           Demonstrating how to pass variables from function to function
#           while producing a functional game.
#
#           Remember, function_name(variable) _means that we pass in the variable.
#           return variable _means that we are returning the variable to
#           the calling function
# 1.
# def start():
#     print(get_number())
#
# def get_number():
#     number = 12
#     return number
#
# 2.
# def start():
#     print("Hello {}!".format(get_name()))
#
# def get_name():
#     name = raw_input("What is your name?")
#     return name
#
# 3.
# def start():
#     f_name = "Sarah"
#     l_name = "Connor"
#     age = 28
#     gender = "Female"
#     get_info(f_name,l_name,age,gender)
#
# def get_info(f_name,l_name,age,gender):
#     print("My name is {0} {1}. I am {2} yearold {3}.".format(f_name,l_name,age,gender))


def start(nice=0,mean=0,name=""):
    # Get user's name
    name = describe_game(name)
    nice,mean,name = nice_mean(nice,mean,name)


def describe_game(name):
    """
        check if this is a new game or not.
        If it is new, get the user's name.
        If it is not a new game, thank the player for
        playing again and continue with the game
    """
    if name != "": # Meaning, if we do not already have this user's name, then they are a new player and we need to get their name
        print("\n\n\nThank you for plyaing again, {}!".format(name))
    else:
        stop = True
        while stop:
                if name == "":
                    name = raw_input("\nWhat is your name? ").capitalize()
                    if name != "":
                        print("\nWelcome, {}!".format(name))
                        print("\nIn this game, you will be greeted by several different clan leaders. \nYou can be nice or mean.")
                        print("\nAt the end of the game your fate will be influenced from your actions.")
                        print("The future of your clan depends on you! Good luck warchief!")
                        stop = False
    return name


def nice_mean(nice,mean,name):
    stop = True
    while stop:
        show_score(nice,mean,name)
        pick = raw_input("\n\n\nA warrior from a stranger clan approaches you. He is wielding a battle axe\nWill you be nice or mean? n/m: ").lower()
        if pick == "n":
            print("\n\n\nHe greets you with respect. Your ways are parting, but you know you have just made a friend...")
            nice = (nice +1)
            stop = False
        if pick == "m":
            print("\n\n\nThe warrior glares at you menacingly. He holds his axe strong, but decides not to engage today. He will remember though. You just made an enemy...")
            mean = (mean +1)
            stop = False
        score(nice,mean,name) # Pass the 3 variables to the score ()


def show_score(nice,mean,name):
    print("\n{}, you currently have({}, Nice) and ({}, Mean) karma points.".format(name,nice,mean))


def score(nice,mean,name):
    # Score function is being passed the values stored within the 3 variables
    if nice > 3: # If condition is valid, call win function passing in the variables so it can use them
        win(nice,mean,name)
    if mean > 3: # If condition is valid, call lose function passing in the variables so it can use them
        lose(nice,mean,name)
    else:        # Else, call nice_mean function passing in the variables so it can use them
        nice_mean(nice,mean,name)


def win(nice,mean,name):
    print("\n\n\nGreat job warchief {}, you win! \nMajority of the clans loves you and will join your endeavour under your command! \nFor the warchief!".format(name)) # Substitute the {} wildcards with our variables
    print("\nLong live the Queen... Uhhhh, I mean {}!!!".format(name))
    again(nice,mean,name) # Call again function and pass in our variables


def lose(nice,mean,name):
    print("\n\n\nYour camp is in ruins, you lie on the ground as the ones who didn't got the greetings they expected stomp on your broken body. Your clan is at war.\n{}, you have failed your people!\nGame over!".format(name)) # Substitue the {} wildcards with our variables
    again(nice,mean,name) # Call again function and pass in our variables


def again(nice,mean,name):
    stop = True
    while stop:
        choice = raw_input("\nDo you want to play again? y/n: ").lower()
        if choice == "y":
            stop = False
            reset(nice,mean,name)
        if choice == "n":
            print("\nSee you later alligator!")
            stop = False
            exit()
        else:
            print("\nPlease enter 'y' for 'YES', 'n' for 'NO'...")
            

def reset(nice,mean,name):
    nice = 0
    mean = 0
    # Notice, I do not reset the name variable as that same user has elected to play again
    start(nice,mean,name)


if __name__ == "__main__":
    start()
