import os
import json
import numpy as np
import requests

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


    data = {'something': '1'}
    data_json = json.dumps(data)
    payload = {'json_payload': data_json, 'apikey': 'APIKEY'}
    r = requests.get('http://myserver', data=payload)