using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BatchInterrupt
{
    public partial class Form1 : Form
    {
        Queue<Batch> tasks = new Queue<Batch>();
        Batch currentBatch = new Batch();
        Task currentTask = new Task();
        Timer t = new Timer();

        bool pause = false;
        bool error = false;
        bool interrupt = false;

        int mm = 0;
        int ss = 0;

        int finishedCount = -1;
        int taskCount = 0;
        int taskNum = 0;
        int execTime = 0;
        
        public Form1()
        {
            InitializeComponent();

            waitingProc.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            waitingProc.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            waitingProc.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            waitingProc.Rows.Add();

            execProc.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            execProc.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            execProc.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            finishedProc.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            finishedProc.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            finishedProc.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void Form1_Load(object sender, EventArgs e) { }


        private void start_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            int idCount = 0;
            int flag = 0;
            int count = 0;
            int amount = Convert.ToInt32(Math.Round(numProcess.Value, 0));
            string[] op = { "+", "-", "*", "/", "%" };
            while (count < amount)
            {
                if (amount < 3)
                {
                    flag = 3 - amount;
                }
                else
                {
                    flag = 0;
                }
                Batch batch = new Batch(idCount);
                while (flag < 3 && count < amount)
                {
                    flag++;
                    count++;
                    
                    Task process = new Task(count, rand.Next(1, 100),
                        rand.Next(1, 100), op[rand.Next(0,4)], rand.Next(7, 18), rand.Next(7, 18));
                    batch.AppendTask(process);
                }
                idCount++;
                tasks.Enqueue(batch);
            }
            t.Interval = 1000;
            t.Tick += new EventHandler(this.t_Tick);
            t.Start();
            start.Enabled = false;
            numProcess.Enabled = false;
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case 'i':
                    if (!pause)
                    {
                        interrupt = true;
                        currentBatch.AppendTask(currentTask);
                        execTime = 0;
                        finishedCount--;
                    }
                    break;
                case 'e':
                    if (!pause)
                    {
                        error = true;
                        currentTask.SetError();
                        finishedProc.Rows[finishedCount].Cells["finishID"].Value = "TASK-" + currentTask.ID.ToString();
                        finishedProc.Rows[finishedCount].Cells["finishExTime"].Value = currentTask.TotalRealTime;
                        finishedProc.Rows[finishedCount].Cells["finishOp"].Value = currentTask.Operation;
                        finishedProc.Rows[finishedCount].Cells["finishResult"].Value = currentTask.Result;
                        if (tasks.Count == 0 && currentBatch.Processes().Count == 0)
                        {
                            cleanFinish();
                        }
                    }
                    break;
                case 'p':
                    pause = true;
                    t.Stop();
                    break;
                case 'c':
                    pause = false;
                    t.Start();
                    break;
            }
        }

        private void cleanFinish()
        {
            execProc.Rows[0].Cells["execID"].Value = "********";
            execProc.Rows[0].Cells["execExTime"].Value = "********";
            execProc.Rows[0].Cells["execOp"].Value = "********";
            execProc.Rows[0].Cells["execRemTime"].Value = "********";
            t.Stop();
        }

        private void t_Tick(object sender, EventArgs e)
        {
            string time = "";
            
            if (execTime == 0)
            {
                error = false;
                if (taskCount == 0)
                {
                    if (tasks.Count != 0 && interrupt == false) { currentBatch = tasks.Dequeue(); }
                }
                if (currentBatch.Processes().Count != 0) {
                    currentTask = currentBatch.Processes().Dequeue();
                    finishedProc.Rows.Add();
                    finishedCount++;
                }
            }
            taskNum = currentBatch.Processes().Count;

            switch (taskNum)
            {
                case 2:
                    waitingProc.Rows[0].Cells["waitID"].Value = "TASK-" + currentBatch.Processes().ElementAt(1).ID.ToString();
                    waitingProc.Rows[0].Cells["waitMaxT"].Value = currentBatch.Processes().ElementAt(1).MaxTime.ToString() + " segundos";
                    if (currentBatch.Processes().ElementAt(1).RemainingTime > 0)
                    {
                        waitingProc.Rows[0].Cells["waitRemain"].Value =
                            currentBatch.Processes().ElementAt(1).RemainingTime.ToString() + " segundos";
                    }


                    waitingProc.Rows[1].Cells["waitID"].Value = "TASK-" + currentBatch.Processes().ElementAt(0).ID.ToString();
                    waitingProc.Rows[1].Cells["waitMaxT"].Value = currentBatch.Processes().ElementAt(0).MaxTime.ToString() + " segundos";
                    if (currentBatch.Processes().ElementAt(0).RemainingTime > 0)
                    {
                        waitingProc.Rows[1].Cells["waitRemain"].Value =
                            currentBatch.Processes().ElementAt(0).RemainingTime.ToString() + " segundos";
                    }
                    break;
                case 1:
                    waitingProc.Rows[0].Cells["waitID"].Value = null;
                    waitingProc.Rows[0].Cells["waitMaxT"].Value = null;
                    waitingProc.Rows[0].Cells["waitRemain"].Value = null;

                    waitingProc.Rows[1].Cells["waitID"].Value = "TASK-" + currentBatch.Processes().ElementAt(0).ID.ToString();
                    waitingProc.Rows[1].Cells["waitMaxT"].Value = currentBatch.Processes().ElementAt(0).MaxTime.ToString() + " segundos";
                    if (currentBatch.Processes().ElementAt(0).RemainingTime > 0)
                    {
                        waitingProc.Rows[1].Cells["waitRemain"].Value =
                            currentBatch.Processes().ElementAt(0).RemainingTime.ToString() + " segundos";
                    }
                    break;
                case 0:
                    waitingProc.Rows[0].Cells["waitID"].Value = null;
                    waitingProc.Rows[0].Cells["waitMaxT"].Value = null;
                    waitingProc.Rows[0].Cells["waitRemain"].Value = null;
                    
                    waitingProc.Rows[1].Cells["waitID"].Value = null;
                    waitingProc.Rows[1].Cells["waitMaxT"].Value = null;
                    waitingProc.Rows[1].Cells["waitRemain"].Value = null;
                    break;
            }
            interrupt = false;
            execProc.Rows[0].Cells["execID"].Value = "TASK-" + currentTask.ID.ToString();
            execProc.Rows[0].Cells["execExTime"].Value =currentTask.ExecTime.ToString() + " segundos";
            execProc.Rows[0].Cells["execOp"].Value = currentTask.Operation;
            // currentTask.IncreaseExec();
            if(!error)
                currentTask.IncreaseExec();
            execProc.Rows[0].Cells["execRemTime"].Value = currentTask.RemainingTime.ToString() + " segundos";

            if (currentTask.RemainingTime == 0) {
                if (mm < 10) { time += "0" + mm; }
                else { time += mm; }

                time += ":";

                if (ss < 10) { time += "0" + ss; }
                else { time += ss; }
                
                if (currentBatch.Processes().Count == 0) { taskCount = 0; }
                else { taskCount++; }

                execTime = 0;

                finishedProc.Rows[finishedCount].Cells["finishID"].Value = "TASK-" + currentTask.ID.ToString();
                finishedProc.Rows[finishedCount].Cells["finishExTime"].Value = currentTask.TotalRealTime;
                finishedProc.Rows[finishedCount].Cells["finishOp"].Value = currentTask.Operation;
                finishedProc.Rows[finishedCount].Cells["finishResult"].Value = currentTask.Result;

                if (currentBatch.Processes().Count == 0 && tasks.Count == 0) { cleanFinish(); }
            }
            else
            {
                if (mm < 10) { time += "0" + mm; }
                else { time += mm; }

                time += ":";

                if (ss < 10) { time += "0" + ss; }
                else { time += ss; }

                if (ss > 60) { mm++; ss = 0; }
                else { ss++; }

                execTime++;
            }

            timeLabel.Text = time;
        }
    }
}
