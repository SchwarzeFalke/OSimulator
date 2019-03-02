# @Author: schwarze_falke
# @Date:   2019-02-05T01:42:08-06:00
# @Last modified by:   schwarze_falke
# @Last modified time: 2019-02-07T17:01:53-06:00

import sys
import os
import constant
from batch import Batch
from task import Task

TOTAL_BATCH = []  # Estructura principal para almacenar los lotes
ID_REGISTER = []  # Estructura de datos para almacenar los ID

# Función para imprimir en pantalla acorde a las coordenadas
# (x, y) parametrizadas


def print_there(x, y, text):
    sys.stdout.write("\x1b7\x1b[%d;%df%s\x1b8" % (x, y, text))
    sys.stdout.flush()

# Función para capturar los procesos/tareas de forma secuencial iterativa


def capture(amount):  # @amount es el parámetro de cantidad de procesos a capturar
    count = 0                   # @count lleva la cuenta de lotes acumulados/capturados
    idCount = 1                 # @idCount es una variable auxiliar para asignarle un ID consecutivo a los lotes
    while count < amount:
        # Si la cantidad de procesos a capturar es menor a 3 (cantidad total que compone a un lote)
        # la bandera de conteo se reduce para capturar lotes incompletos
        if amount < 3:
            flag = 3 - amount
        else:
            flag = 0
        batch = Batch(idCount)                  # Se asigna un tipo de dato Batch con ID en su constructor
        while flag < 3 and count < amount:
            os.system(constant.CLEAR)           # Limpieza de pantalla

            while True:
                id = input("Ingrese el ID del programa: ")
                if (id in ID_REGISTER) == False:            # Si el ID capturado no se encuentra en el registro
                    ID_REGISTER.append(id)                  # de ID, agrega el nuevo ID al registro
                    break
                else:
                    print("El ID se encuentra repetido!")   # de lo contrario, el ID se encuentra repetido

            progName = input("Ingrese el nombre del programador: ")

            # El tiempo máximo esperado debe ser mayor a 0,
            # si no se cumple con este requisito, la iteración
            # se repetirá hasta que la validación se haga verdadera y rompa el while
            while True:
                try:
                    maxTime = int(input("Ingrese el tiempo maximo esperado: "))
                    if maxTime > 0:
                        break
                    else:
                        print("El tiempo maximo esperado debe ser mayor a 0!")
                except:
                    print("Ha ingresado un numero invalido!")       # Las excepciones dadas por el input
                                                                    # son de tipo int(); si se ingresa un caracter
                                                                    #  alfanumérico, la excepción es atrapada

                                                                    # Los siguientes inputs funcionan
                                                                    # bajo la misma premisa de validación
            while True:
                try:
                    op1 = int(input("Ingrese un numero entero: "))
                    break
                except:
                    print("No es un numero valido!")

            while True:
                op = input("Ingresa el operando (+, -, *, /, %): ")
                if op == '+' or op == '-' or op == '*' or op == '/' or op == '%':
                    break
                else:
                    print("Ha ingresado un caracter invalido!")

            while True:
                try:
                    op2 = int(input("Ingrese un numero entero: "))
                    if (op == '/' or op == '%') and op2 == 0:
                        print("No se puede dividir entre 0!")
                    else:
                        break
                except:
                     print("No es un numero valido!")

            flag += 1
            count += 1
            # Se crea un proceso o tarea con la información capturada
            process = Task(progName, op1, op2, op, maxTime, id)
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
        string = "Lote en ejecucion: {}\t\t\tLotes restantes: {}".format((count+1), int(top-(count+1)))
        print_there(3, 0, string)
        totalTime = TOTAL_BATCH[count].execBatch(totalTime)
        count += 1
    end = "-----------------------------------------------------------TODOS LOS PROCESOS HAN SIDO TERMINADOS-----------------------------------------------------------"
    timeString = "Tiempo transcurrido total: {}s".format(totalTime)
    print_there(2, 0, timeString)
    print_there(10, 6, end)

def main():
    os.system(constant.CLEAR)
    amount = int(input("Ingrese la cantidad de procesos: "))
    capture(amount)
    show(amount)

main()
