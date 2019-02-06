# @Author: schwarze_falke
# @Date:   2019-02-05T01:42:13-06:00
# @Last modified by:   schwarze_falke
# @Last modified time: 2019-02-05T03:38:57-06:00

import time, sys, random, os, constant

class Batch:
    def __init__(self, id):
        self.id = id
        self.processes = []

    def addProcess(self, data):
        self.processes.append(data)

    def execBatch(self):
        for process in self.processes:
            print("ID: {}".format(process.id))
            print("Nombre del programador: {}".format(process.progName))
            print("Tiempo maximo estimado: {}".format(process.maxTime))
            print("Operacion: {} {} {}".format(process.op1, process.op, process.op2))
            process.realTime = random.randint(3,process.maxTime)
            time_start = time.time()
            seconds = 0
            while True:
                try:
                    print("Tiempo transcurrido: {}s | Tiempo restante: {}s".format(seconds, process.realTime-seconds), end="\r")
                    time.sleep(1)
                    seconds += 1
                    if seconds > process.realTime:
                        break;
                except e:
                    break
