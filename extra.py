# @Author: schwarze_falke
# @Date:   2019-01-30T13:22:15-06:00
# @Last modified by:   schwarze_falke
# @Last modified time: 2019-01-30T13:40:49-06:00

import keyboard

def cycle():
    a = 0
    while True:
        print('...')
        if keyboard.is_pressed('i'):
            print('Interrupcion')
        if keyboard.is_pressed('e'):
            print('Error')
        if keyboard.is_pressed('p'):
            print('Pausa')
            break
        if keyboard.is_pressed('s'):
            finish()

def init():
    while keyboard.is_pressed('s') == False:
        cycle()
        while keyboard.is_pressed('c') == False:
            print('PAUSA')
            if keyboard.is_pressed('s'):
                finish()

def finish():
    print('TERMINADO')
    exit()

init()
