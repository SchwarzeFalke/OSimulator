using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchInterrupt
{
    public class Task
    {
        private readonly int id;
        private readonly float op1;
        private readonly float op2;
        private readonly string op;
        private int execTime;
        private readonly int maxTime;
        private int realTime;
        private int totalRealTime;
        private int remainingTime;
        private string result;

        public Task() { }

        public Task(int id, float op1, float op2, string op, int maxTime, int realTime)
        {
            this.id = id;
            this.op1 = op1;
            this.op2 = op2;
            this.op = op;
            this.maxTime = maxTime;
            this.realTime = realTime;
            this.totalRealTime = 0;
            this.remainingTime = 0;
            switch (this.op)
            {
                case "+":
                    this.result = (this.op1 + this.op2).ToString();
                    break;
                case "-":
                    this.result = (this.op1 - this.op2).ToString();
                    break;
                case "*":
                    this.result = (this.op1 * this.op2).ToString();
                    break;
                case "/":
                    this.result = (this.op1 / this.op2).ToString();
                    break;
                case "%":
                    this.result = (this.op1 % this.op2).ToString();
                    break;
            }
        }

        public int ID { get { return this.id; } }
        public string Operation { get { return this.op1.ToString() + this.op + this.op2.ToString(); } }
        public int MaxTime { get { return this.maxTime; } }
        public int RealTime { get { return this.realTime; } }
        public int ExecTime { get { return this.execTime; } }
        public int TotalRealTime { get { return this.totalRealTime; } }
        public int RemainingTime { get { this.remainingTime = this.realTime - this.execTime;  return this.remainingTime; } }
        public string Result { get { return this.result; } }

        public void SetRemaining(int time) { this.remainingTime = this.realTime - time; }
        public void SetInterruptTime(int time) { this.remainingTime = time;  }
        public void SetError() { this.result = "ERROR"; this.remainingTime = 0; this.execTime = this.realTime; }
        public void IncreaseExec() { this.execTime++; totalRealTime++; }
    }
}
