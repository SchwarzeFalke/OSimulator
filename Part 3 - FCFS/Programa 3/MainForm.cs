using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programa_3
{
    public partial class MainForm : Form
    {
        private Queue<Task> newTasks, readyTasks, finishedTasks;
        private List<Task> blockedTasks;
        private DataTable readyList, blockedList, execList, finishedList;
        private Task exec;
        private int counter;
        private string newProcessLabel = "Procesos nuevos: ";
        private string clock = "00:";
        private string state = "Estado: ";
        private Keys status;

        public MainForm()
        {
            InitializeComponent();
            newTasks = new Queue<Task>();
            readyTasks = new Queue<Task>();
            blockedTasks = new List<Task>();
            finishedTasks = new Queue<Task>();
            initTables();
            counter = 0;
            status = 0;
        }

        private void addProc_Click(object sender, EventArgs e)
        {
            finishedList.Rows.Clear();

            Random random = new Random();
            for (int i = 0; i < amountProc.Value; i++)
            {
                Task proceso = new Task(i + 1, random);
                newTasks.Enqueue(proceso);
            }
            int j = 0;
            while (j < 3 && newTasks.Count > 0)
            {
                insertToReady(newTasks.Dequeue());
                j++;
            }
            addProc.Enabled = false;
            start.Enabled = true;
            lblNuevos.Text = newProcessLabel + newTasks.Count;
        }

        private void start_Click(object sender, EventArgs e)
        {
            timerClock.Enabled = true;
            timerClock.Start();
            start.Enabled = false;
        }

        #region initDataGridViews
        private void initTables()
        {
            initReadyTable();
            initBlockedTable();
            initExecTable();
            initFinishedTable();
        }

        private void initReadyTable()
        {
            readyList = new DataTable();
            readyList.Columns.Add("ID", typeof(int));
            readyList.Columns.Add("TME", typeof(int));
            readyList.Columns.Add("TR", typeof(int));
            readyProc.DataSource = readyList;
            readyProc.Columns[0].Width = 169;
            readyProc.Columns[1].Width = 169;
            readyProc.Columns[2].Width = 169;
        }
        
        private void initBlockedTable()
        {
            blockedList = new DataTable();
            blockedList.Columns.Add("ID", typeof(int));
            blockedList.Columns.Add("Transcurrido", typeof(int));
            blockedProc.DataSource = blockedList;
            blockedProc.Columns[0].Width = 30;
            blockedProc.Columns[1].Width = 80;
        }

        private void initExecTable()
        {
            execList = new DataTable();
            execList.Columns.Add("ID", typeof(int));
            execList.Columns.Add("Operacion", typeof(string));
            execList.Columns.Add("TME", typeof(int));
            execList.Columns.Add("Transcurrido", typeof(int));
            execList.Columns.Add("Restante", typeof(int));
            execProc.DataSource = execList;

            execProc.Columns[0].Width = 101;
            execProc.Columns[1].Width = 101;
            execProc.Columns[2].Width = 102;
            execProc.Columns[3].Width = 102;
            execProc.Columns[4].Width = 102;
        }

        private void initFinishedTable()
        {
            finishedList = new DataTable();
            finishedList.Columns.Add("ID", typeof(int));
            finishedList.Columns.Add("Operacion", typeof(string));
            finishedList.Columns.Add("Resultado", typeof(string));
            finishedList.Columns.Add("Tiempo Llegada", typeof(int));
            finishedList.Columns.Add("Tiempo Finalizacion", typeof(int));
            finishedList.Columns.Add("Tiempo Retorno", typeof(int));
            finishedList.Columns.Add("Tiempo Respuesta", typeof(int));
            finishedList.Columns.Add("Tiempo Espera", typeof(int));
            finishedList.Columns.Add("Tiempo Servicio", typeof(int));
            finishedProc.DataSource = finishedList;
            finishedProc.Columns[0].Width = 35;
            finishedProc.Columns[1].Width = 65;
            finishedProc.Columns[2].Width = 70;
            finishedProc.Columns[3].Width = 52;
            finishedProc.Columns[4].Width = 65;
            finishedProc.Columns[5].Width = 52;
            finishedProc.Columns[6].Width = 65;
            finishedProc.Columns[7].Width = 52;
            finishedProc.Columns[8].Width = 52;
        }
        #endregion

        #region Queues
        private void insertToReady(Task task)
        {
            readyTasks.Enqueue(task);
            readyList.Rows.Add(task.toReadyObject());
        }

        private Task dequeueReadyProcess()
        {
            readyList.Rows.RemoveAt(0);
            return readyTasks.Dequeue();
        }

        private void setExecutionProcess()
        {
            if (readyTasks.Count > 0)
            {
                exec = dequeueReadyProcess();
                exec.TiempoRespuesta = counter;
                this.execList.Rows.Clear();
                execList.Rows.Add(exec.toExecObject());
            }
        }

        private void updateExecutionProcess()
        {
            this.execList.Rows[0][3] = this.exec.TiempoTranscurrido.ToString();
            this.execList.Rows[0][4] = this.exec.TiempoRestante.ToString();
        }

        private void sendToFinished(bool error)
        {
            if (exec != null)
            {
                exec.TiempoFinalizacion = counter;
                finishedTasks.Enqueue(exec);
                if (error)
                    finishedList.Rows.Add(exec.toErrorObject());
                else
                    finishedList.Rows.Add(exec.toFinishedObject());
                exec = null;
                if ((readyTasks.Count + blockedTasks.Count) == 0)
                {
                    timerClock.Stop();
                    timerClock.Enabled = false;
                    clearExecutionProcess();
                    addProc.Enabled = true;
                }
            }
        }

        private void insertNewProcess()
        {
            if (newTasks.Count > 0)
            {
                Task aux = newTasks.Dequeue();
                aux.TiempoLlegada = counter;
                readyTasks.Enqueue(aux);
                readyList.Rows.Add(aux.toReadyObject());
                lblNuevos.Text = newProcessLabel + newTasks.Count;
            }
        }

        private void clearExecutionProcess()
        {
            execList.Clear();
        }

        private void updateBlocked()
        {
            List<Task> aux = blockedTasks.Where(proceso => !proceso.IncrementBloqued()).ToList();
            foreach(Task proceso in aux)
            {
                proceso.TiempoBloqueadoTranscurrido = 0;
                readyTasks.Enqueue(proceso);
                readyList.Rows.Add(proceso.toReadyObject());
                blockedTasks.Remove(proceso);
            }
            blockedList.Rows.Clear();
            foreach(Task proceso in blockedTasks)
            {
                blockedList.Rows.Add(proceso.toBloquedObject());
            }
        }

        #endregion

        #region Timer
        private void timerClock_Tick(object sender, EventArgs e)
        {
            if (exec == null)
            {
                setExecutionProcess();
            }
            if((exec != null && (readyTasks.Count + blockedTasks.Count) < 2) || (exec == null && (readyTasks.Count + blockedTasks.Count < 3)))
            {
                insertNewProcess();
            }
            if (exec != null && exec.Increment())
            {
                updateExecutionProcess();
            }
            else if(exec != null)
            {
                sendToFinished(false);
            }
            if(blockedTasks.Count > 0)
            {
                updateBlocked();
            }
            updateClock();
        }

        private void updateClock()
        {
            this.counter++;
            if (counter < 10)
            {
                clockLabel.Text = clock + "0" + counter;
            }
            else
            {
                clockLabel.Text = clock + counter;
            } 
        }
        #endregion

        #region Form
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.I && status != Keys.P)
            {
                interrupt();
                status = e.KeyCode;
            }
            if (e.KeyCode == Keys.E && status != Keys.P)
            {
                sendToFinished(true);
                status = e.KeyCode;
            }
            if (e.KeyCode == Keys.P && status != Keys.P)
            {
                timerClock.Stop();
                timerClock.Enabled = false;
                lblEstado.Text = state + "En pausa";
                status = e.KeyCode;
            }
            if (e.KeyCode == Keys.C && status == Keys.P)
            {
                timerClock.Enabled = true;
                timerClock.Start();
                lblEstado.Text = state + "Corriendo";
                status = e.KeyCode;
            }
        }
        #endregion

        #region Functions
        private void interrupt()
        {
            if (exec != null)
            {
                blockedTasks.Add(exec);
                blockedList.Rows.Add(exec.toBloquedObject());
                clearExecutionProcess();
                exec = null;
            }
        }
        #endregion
    }
}
