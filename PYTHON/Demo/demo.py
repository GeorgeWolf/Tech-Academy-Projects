# -*- coding: cp1250 -*-
# Python:   2.7.14
#
# Author:   George Wolf (georgewolf.ot@gmail.com)
#
# Purpose:  The Tech Academy - Python Course, Drill (p36)





def start(health=100,attack=10,name="",title="The Wanderer"): # 1. Assign an integer to a variable / 2. Assign a string to a variable / 12. Define a function that returns a string variable
    brag = float(3)/float(9) # 3. Assign a float to a variable
    tuples = ('Orcs', 'Trolls', 'Dragons') # 11. Create a tuple and iterate through it using a for loop to print each item out on a new line
    lists = [7, 13, 9, 19, 3]
    name = game_intro(name,brag,tuples,lists)
    health,attack,name,title = character_stats(health,attack,name,title)


def game_intro(name,brag,tuples,lists):
    if name != "": # If name is already given
        print("\n\n\n Welcome back {}!".format(name)) # 4. Use the print function and .format() notation to print out the variable you assigned
    else:
        change = True
        while change:
            if name == "":
                name = raw_input("\nHow do we call you stranger? ").capitalize()
                if name != "":
                    print("\n\nGreetings {}!".format(name))
                    print("\nI see you have just awakened. Let me introduce myself. My name is Merlin. Yes, that Merlin.")                
                    print("\nI don't want to brag, but I even know how to divide, like 3/9!")
                    print("\nI see you are confused, so I tell you. 3/9 = {}. See? Pretty simple.").format(brag)
                    print("\n\nYou are talking too much, there is no time to waste, The kingdom is in great danger, you must come with me!")
                    print("\nThe wizard is mumbling about creatures of this land, like:")
                    for countT in tuples: # 11. Create a tuple and iterate through it using a for loop to print each item out on a new line
                        print countT
                    print("\nHe looks at you still mumbling some numbers which don't make any sense.")
                    for countL in lists: # 9. Use of a for loop / 10. Create a list and iterate through that list using a for loop to print each item out on a new line
                        print countL
                    print("\nMaybe these are the lucky numbers for the coming lottery. Who knows?")
                    print("\nThen suddenly he turns to you and says:")
                    print("\n'It's dangerous to go alone! Take this.'")
                    print("\n\n             RUSTY SWORD (Attack: 10)")
                    print("\n\nAnd he suddenly disappears.")
                    print("\nYou decide to get moving.")
                    change = False
                
    return name


def character_stats(health,attack,name,title):
    change = True
    while change:
        show_stats(health,attack,name,title)
        
        pick = raw_input("which way to go? West(w), North(n), East(e), South(s): ").lower()
        if pick == "w" and health > 99 and attack < 16: # 6. Use of logical operators: and, or, not
            pick = raw_input("\n\nAs you wander in the wilderness a Cave Troll appears in the distance. This must be the creature Merlin mumbled about. It looks huge and robust, dragging a club after him. What to you do? Attack(a)/Flee(f): ").lower()
            if pick == "a":
                print("\n\nYou have fiercely attacked the Troll. His thick skin is nearly impenetrable. He kicks you aside and slowly moves on. \nYou barely escape. Luckily he was too bored to go after you. \nYour health is halved.")
                health = health/2 # 5. Use each of these operators
                change = not True
            if pick == "f":
                print("\n\nA great warrior knows when to attack and when to flee. \nThis might be the right choice for the second one. \nAs you walk away, you spend the rest of the day sharpening your sword. \nYou have just gained +2 Attack!")
                attack += 2 # 5. Use each of these operators
                change = False
        if pick == "w" and health < 100 and attack < 16:
            print("\n\nYou hear a voice in your head: 'You are running to your death'")
            pick = raw_input("\n\nAs you wander in the wilderness a Cave Troll appears in the distance. This must be the creature Merlin mumbled about. It looks huge and robust, dragging a club after him. What to you do? Attack(a)/Flee(f): ").lower()
            if pick == "a":
                print("\n\nYou have fiercely attacked the Troll. His thick skin is nearly impenetrable. He kicks you aside and slowly moves on. \nLuckily he was too bored to beat you to death. \nYour health is halved.")
                health = health/2 # 5. Use each of these operators
                change = False
            if pick == "f":
                print("\n\nA great warrior knows when to attack and when to flee. \nThis might be the right choice for the second one. \nAs you walk away, you spend the rest of the day sharpening your sword. \nYou have just gained +2 Attack!")
                attack += 2 # 5. Use each of these operators
                change = False
        if pick == "w" and attack > 15:
            print("\nYou charge with all your power. With only one slice you defeat the Cave Troll, you feel the energy going through your body, your sword starts to glow. \nAttack increased: +5")
            attack = attack +5
            win(health,attack,name,title)
        if pick == "n" and attack < 16:
            print("\nYou hear whispering in your mind: 'You are not ready yet!' \nYou have to go elsewhere.")
            change = False
        if pick == "n" and attack > 16:
            print("\nYou are now ready to face your destiny! (In the next episode!)")
        if pick == "e" and health > 99:
            print("\nYou have an urge to go West!")
            change = False
        if pick == "e" and health < 100 and health > 2:
            print("\nYou find a Fountain with glowing water. You already feel better as you get closer to the Fountain. \nAs you drink from it, your life starts to regenerate.\n\nLife doubled.")
            health = health * 2
            change = False
        if pick == "e" and health == 2 or pick == "e" and health == 1: # 6. Use of logical operators: and, or, not
            print("\nYou find a Fountain with glowing water. You already feel better as you get closer to the Fountain. \nAs you get closer the Fountain starts to talk:\n\n'Damn son! You look like s#@t! I think you need some serious help here!'\n\nThe fountain heals you to full health. Life restored.")
            health = 100
            change = False
        if pick == "s":
            print("\nNever go back! Basically this is where you came from (Or maybe from Oregon :P).")
            print("\nYou lose nearly all of your life.")
            health = health%health # Resets life to 0
            health = health -1 # 5. Use each of these operators
            health = health +3 # Just having some fun with numbers :D
            change = False
        if attack == 12:
            print("\n\nYou are on the right track. Just keep it up!")
            change = False
        if attack == 14:
            print("\n\nYou hear a voice in your head: 'That's the spirit! I mean for the weapon upgrade, not for the running.'")
            change = False
        if attack == 16:
            print("\n\nYou have done it! Now go to West and defeat the Troll!")
            change = False
        stats(health,attack,name,title)


def show_stats(health,attack,name,title):
    print("\n\nStats of {}:").format(name)
    print("\nTitle: {}").format(title)
    print("\nHealth: {}/100, Attack: {}").format(health,attack)
    print("\n\n               ---------*---------")
    

def stats(health,attack,name,title):
    if health < 1:
        lose(health,attack,name,title)
    else:
        character_stats(health,attack,name,title)


def win(health,attack,name,title):
    print("\n\n\nYou are ready {}! Merlin smiles in the distance as he watches you triumph. \nThank you for playing! More coming in the future ;P").format(name)
    again(health,attack,name,title)


def lose(health,attack,name,title):
    print("\n\n\nAs you fall to the ground you can see the face of Merlin in the distance. You feel a voice inside of your head: '{}, get up and fight!'").format(name)
    again(health,attack,name,title)


def again(health,attack,name,title):
    change = True
    while change: # 7. Use of conditional statements: if, elif, else / 8. Use of a while loop
        choice = raw_input("\nDo you wish to Continue(c)?/ Start a New Game(n)?/ Or Exit(x)? ").lower()
        if choice == "c": # Continue
            print("\nYou recover and your journey continues.") 
            change = False
            resetContinue(health,attack,name,title)
        elif choice == "n": # Reset/New Game with the same name
            change = False
            reset(health,attack,name,title)
        elif choice == "x": # Exit
            print("\nEven the greatest warriors need some rest.") 
            change = False
            exit()
        else:
            print("\n\n\nPlease enter 'c' for 'Continue the Game', 'n' for 'New Game', 'x' for 'Exit the Game'...")


def resetContinue(health,attack,name,title): # Sets values when continue is choosen
    health = 50
    attack = attack
    title = "The Survivor"
    start(health,attack,name,title)


def reset(health,attack,name,title): # Sets values when reset is choosen
    health = 100
    attack = 10
    title = "The Reborn"
    start(health,attack,name,title)


if __name__ == "__main__": # 13. Call the function you defined above and print the result to the shell
    start()
