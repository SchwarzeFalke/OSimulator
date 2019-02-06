# @Author: schwarze_falke
# @Date:   2019-02-05T01:42:08-06:00
# @Last modified by:   schwarze_falke
# @Last modified time: 2019-02-05T03:32:39-06:00

import sys, os, constant, time
from batch import Batch
from task import Task

TOTAL_BATCH = []
ID_REGISTER = []

def capture(amount):
    count = 0
    while count < amount:
        flag = 0
        batch = Batch(count)
        while flag < 3:
            os.system(constant.CLEAR)

            while True:
                id = input("Ingrese el ID del programa: ")
                if (id in ID_REGISTER) == False:
                    ID_REGISTER.append(id)
                    break
                else:
                    print("El ID se encuentra repetido!")

            progName = input("Ingrese el nombre del programador: ")

            while True:
                try:
                    maxTime = int(input("Ingrese el tiempo maximo esperado: "))
                    if maxTime > 0:
                        break
                    else:
                        print("El tiempo maximo esperado debe ser mayor a 0!")
                except:
                    print("Ha ingresado un numero invalido!")

            while True:
                try:
                    op1 = int(input("Ingrese un numero entero: "))
                    break
                except:
                    print("No es un numero valido!")

            while True:
                op = input("Ingresa el operando (+, -, *, /, %): ")
                if op == '+' or op == '-' or op == '*' or op == '/' or op == '%':
                    break;
                else:
                    print("Ha ingresado un caracter invalido!")

            while True:
                try:
                    op2 = int(input("Ingrese un numero entero: "))
                    break
                except:
                     print("No es un numero valido!")

            flag += 1
            process = Task(progName, op1, op2, op, maxTime, id)
            batch.addProcess(process)

        count += flag
        TOTAL_BATCH.append(batch)


def show(amount):
    count = 0
    while count < amount:
        print("Lote en ejecucion: {}".format(count+1))
        print("Lotes restantes: {}".format(amount-(count+1)))
        TOTAL_BATCH[count].execBatch()


def main():
    amount = int(input("Ingrese la cantidad de procesos: "))
    capture(amount)
    show(amount)

main()
