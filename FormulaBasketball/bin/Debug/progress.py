# Sample Homework 3 solution
# Allison Obourn 8/14/17

# This program emulates activity trackers that grow flowers or trees when the user is successful
# such as the power use monitor in the Prius and the activity tracker on the Fitbit One
# It Prompts the user for a number of steps and the draws a field of flowers. A new flower appears
# for each 5000 steps a user walks and each flower gains two leaves for each additional 1000 steps
# below 5000 the user has walked. 

from DrawingPanel import *
from random import *


def main():
    steps = int(input("How many steps have you walked? "))
    panel = DrawingPanel(500, 300, background="#FFFFFF")
    draw_background(panel)
    
    for i in range(steps // 5000 + 1):
        draw_flower(randint(0, 300), min(steps, 5000), panel)
        steps -= 5000

# an oppertunity for students to come up with something creative
def draw_background(panel):
    pass

# draws a flower with a green stemmmm,yellowflower and brown center. The flower starts from the bottom of the
# screen and the passed in x location. The hight is dependant on the passed in numberof steps. It gets taller
# and gains two extra leaves for every 1000 steps the user passes in. It is drawn on the passed in panel.
def draw_flower(x, steps, panel):
    # the flower stalk
    top_stalk = 300 - (steps // 1000 + 1) * 20 - 50
    panel.draw_line(x, 300, x, top_stalk, color="darkgreen", width="5")
    # the flower petals and center
    panel.fill_oval(x - 25, top_stalk, 50, 50, fill="yellow")
    panel.fill_oval(x - 5, top_stalk + 20, 10, 10, fill="brown")

    # the flower leaves
    shift_up = 10
    for i in range(steps // 1000):
        panel.draw_line(x, 300 - shift_up, x - 10, 300 - (shift_up + 10), fill="darkgreen", width="3")
        shift_up += 10
        panel.draw_line(x, 300 - shift_up, x + 10, 300 - (shift_up + 10), fill="darkgreen", width="3")
        shift_up += 10

main()