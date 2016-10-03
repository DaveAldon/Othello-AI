import os
import json
import numpy as np
import requests
from bs4 import BeautifulSoup
import urllib2

class Game(object):
    def gameBoard():
        board = np.matrix([['-', '-', '-', '-', '-', '-', '-', '-'],
                           ['-', '-', '-', '-', '-', '-', '-', '-'],
                           ['-', '-', '-', '-', '-', '-', '-', '-'],
                           ['-', '-', '-', '-', '-', '-', '-', '-'],
                           ['-', '-', '-', '-', '-', '-', '-', '-'],
                           ['-', '-', '-', '-', '-', '-', '-', '-'],
                           ['-', '-', '-', '-', '-', '-', '-', '-'],
                           ['-', '-', '-', '-', '-', '-', '-', '-']])
        return board

    print (gameBoard())




    url = urllib2.urlopen("https://www.govtrack.us/data/congress/113/votes/2013/s11/data.json")
    content = url.read()
    soup = BeautifulSoup(content)
    print(content)