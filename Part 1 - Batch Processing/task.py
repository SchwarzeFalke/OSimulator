# @Author: schwarze_falke
# @Date:   2019-02-05T02:10:27-06:00
# @Last modified by:   schwarze_falke
# @Last modified time: 2019-02-05T03:22:50-06:00

class Task:
    def __init__(self, progName, op1, op2, op, maxTime, id):
        self.id = id
        self.progName = progName
        self.op1 = op1
        self.op2 = op2
        self.op = op
        self.maxTime = maxTime
        self.realTime = 0
        if op == '+':
            self.result = op1 + op2
        elif op == '-':
            self.result = op1 - op2
        elif op == '*':
            self.result = op1 * op2
        elif op == '/':
            self.result = op1 / op2
        elif op == '%':
            self.result = op1 % op2
