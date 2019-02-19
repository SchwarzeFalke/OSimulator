# @Author: schwarze_falke
# @Date:   2019-02-05T01:42:08-06:00
# @Last modified by:   schwarze_falke
# @Last modified time: 2019-02-15T12:04:07-06:00

import sys
import os
import constant
import random
import keyboard

from batch import Batch
from task import Task

TOTAL_BATCH = [] # Estructura principal para almacenar los lotes

# Función para imprimir en pantalla acorde a las coordenadas (x, y) parametrizadas
def print_there(x, y, text):
    sys.stdout.write("\x1b7\x1b[%d;%df%s\x1b8" % (x, y, text))
    sys.stdout.flush()

# Función para capturar los procesos/tareas de forma secuencial iterativa
def capture(amount):            # @amount es el parámetro de cantidad de procesos a capturar
    count = 0                   # @count lleva la cuenta de lotes acumulados/capturados
    idCount = 1                 # @idCount es una variable auxiliar para asignarle un ID consecutivo a los lotes
    op = ['+', '-', '*', '/', '%']
    while count < amount:
        # Si la cantidad de procesos a capturar es menor a 3 (cantidad total que compone a un lote)
        # la bandera de conteo se reduce para capturar lotes incompletos
        if amount < 3:
            flag = 3 - amount
        else:
            flag = 0
        batch = Batch(idCount)  # Se asigna un tipo de dato Batch con ID en su constructor
        while flag < 3 and count < amount:
            os.system(constant.CLEAR)           # Limpieza de pantalla
            flag += 1
            count += 1
            # Se crea un proceso o tarea con la información capturada
            process = Task(random.randint(1, 100), random.randint(1, 100),
                           op[random.randint(0, 4)], random.randint(7, 18), count)
            # Dicho proceso es añadido a la lista de procesos del lote
            batch.addProcess(process)

        idCount += 1
        # El lote es añadido a la estructura de lotes
        TOTAL_BATCH.append(batch)


def show(amount):
    os.system(constant.CLEAR)
    count = 0
    top = int(amount/3)
    if (amount % 3) != 0:
        top += 1
    totalTime = 0
    while count < top:
        string = "Lote en ejecucion:\
         {}\t\t\tLotes restantes: {}".format((count+1), int(top-(count+1)))
        print_there(3, 0, string)
        totalTime = TOTAL_BATCH[count].execBatch(totalTime)
        count += 1
    end = "-----------------------------------------------------------TODOS\
    LOS PROCESOS HAN SIDO TERMINADOS--------------------------------\
    ---------------------------"
    timeString = "Tiempo transcurrido total: {}s".format(totalTime)
    print_there(2, 0, timeString)
    print_there(10, 6, end)


def pause(thread):
    print_there(10, 6, "P A U S A")
    thread.wait()
    while True:
        if keyboard.is_pressed('c'):
            thread.clear()
            break


if __name__ == '__main__':
    os.system(constant.CLEAR)
    amount = int(input("Ingrese la cantidad de procesos: "))
    capture(amount)
    show(amount)
