# @Author: schwarze_falke
# @Date:   2019-02-05T01:42:13-06:00
# @Last modified by:   schwarze_falke
# @Last modified time: 2019-02-15T13:45:26-06:00

import time
import sys
import random
import os
import constant
import keyboard
import threading


class Batch:
    def __init__(self, id):
        self.id = id
        self.processes = []

    def addProcess(self, data):
        self.processes.append(data)

    def execBatch(self, totalTime):
        counter = 3
        secondsClock = 0
        for process in self.processes:
            self.pause()
            process.realTime = random.randint(7, process.maxTime)
            time_start = time.time()
            seconds = 0
            while True:
                exec = "P R O C E S O   E N   E J E C U C I O N"
                finish = "P R O C E S O S   T E R M I N A D O S"
                string = "ID: {:>4} | Tiempo maximo estimado: {:>2}s | Operacion: {} {} {} | Tiempo transcurrido: {:2}s | Tiempo restante: {:2}s".format(process.id, process.maxTime, process.op1, process.op, process.op2, seconds, process.realTime-seconds)
                timeClock = int(totalTime + secondsClock)
                timeString = "Tiempo transcurrido total: {}s".format(timeClock)
                self.print_there(8, 50, exec)
                self.print_there(10, 6, string)
                self.print_there(15, 50, finish)
                self.print_there(2, 0, timeString)
                time.sleep(1)
                seconds += 1
                secondsClock += 1
                if seconds >= process.realTime:
                    proc = "ID: {:>4} | Tiempo de ejecucion: {:>2}s | Operacion y resultado: {} {} {} = {}".format(process.id, process.realTime, process.op1, process.op, process.op2, process.result)
                    x = 18 + ((self.id * 3)-counter)
                    self.print_there(x, 6, proc)
                    counter -= 1
                    break
        self.print_there(x, 130, "FIN DEL LOTE NO. {}".format(self.id))
        return (timeClock+1)

    def print_there(self, x, y, text):
        sys.stdout.write("\x1b7\x1b[%d;%df%s\x1b8" % (x, y, text))
        sys.stdout.flush()

    def pause(self):
        if keyboard.is_pressed('p'):
            self.print_there(0, 0, "P A U S A")
            while True:
                if keyboard.is_pressed('c'):
                    self.print_there(0, 0, "         ")
                    break
        else:
            return True

    def interrupt():
        if keyboard.is_pressed('i'):
            self.print_there('i')
