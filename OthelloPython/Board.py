import os

class Game(object):
    def gameBoard(self):
        boardList = [0] * 8
        for i in range(8):
            boardList[i] = [0] * 8

        return boardList

    #Prints the pretty square
    for i in range(1):
        print ("\n".join(map(str, gameBoard(0))))