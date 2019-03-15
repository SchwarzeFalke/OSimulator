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
        private List<Task> blockedTasks, procTasks;
        private DataTable readyList, blockedList, execList, finishedList;
        private Task exec;
        private int counter;
        private int id;
        private string newProcessLabel = "Procesos nuevos: ";
        private string state = "Estado: ";
        private Keys status;

        public MainForm()
        {
            InitializeComponent();
            newTasks = new Queue<Task>();
            readyTasks = new Queue<Task>();
            blockedTasks = new List<Task>();
            procTasks = new List<Task>();
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
                procTasks.Add(proceso);
                id = i;
            }
            id++;
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
            readyProc.Columns[0].Width = 91;
            readyProc.Columns[1].Width = 91;
            readyProc.Columns[2].Width = 91;
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

            execProc.Columns[0].Width = 40;
            execProc.Columns[1].Width = 70;
            execProc.Columns[2].Width = 40;
            execProc.Columns[3].Width = 70;
            execProc.Columns[4].Width = 54;
        }

        private void initFinishedTable()
        {
            finishedList = new DataTable();
            finishedList.Columns.Add("ID", typeof(int));
            finishedList.Columns.Add("Operacion", typeof(string));
            finishedList.Columns.Add("Resultado", typeof(string));
            finishedProc.DataSource = finishedList;
            finishedProc.Columns[0].Width = 91;
            finishedProc.Columns[1].Width = 91;
            finishedProc.Columns[2].Width = 91;
        }

        private void initProcTable()
        {
            initProcRows();
            int x = 0;
            foreach (Task task in procTasks.OrderBy(o => o.ID))
            {
                if (x > procTable.Columns.Count)
                    procTable.Columns.Add(" ", " ");
                procTable.Columns[x].Width = 110;
                procTable[x, 0].Value = task.ID;
                procTable[x, 1].Value = task.Estado;
                switch (task.Estado)
                {
                    case "Nuevo":
                        procTable[x, 2].Value = "";
                        procTable[x, 3].Value = "";
                        procTable[x, 4].Value = "";
                        procTable[x, 5].Value = "";
                        procTable[x, 6].Value = "";
                        procTable[x, 7].Value = "";
                        procTable[x, 8].Value = "";
                        procTable[x, 9].Value = "";
                        procTable[x, 10].Value = "";
                        procTable[x, 11].Value = "";
                        break;
                    case "Listo":
                        procTable[x, 2].Value = task.Operacion;
                        procTable[x, 3].Value = "";
                        procTable[x, 4].Value = task.TiempoLlegada;
                        procTable[x, 5].Value = "";
                        procTable[x, 6].Value = "";
                        procTable[x, 7].Value = task.TiempoAtendido;
                        procTable[x, 8].Value = task.TiempoServicio;
                        procTable[x, 9].Value = task.TiempoRestante;
                        if (task.TiempoAtendido != task.TiempoRespuesta2)
                            procTable[x, 10].Value = task.TiempoRespuesta2 + 1;
                        else
                            procTable[x, 10].Value = task.TiempoRespuesta2;
                        procTable[x, 11].Value = task.TME;
                        break;
                    case "En ejecución":
                        procTable[x, 2].Value = task.Operacion;
                        procTable[x, 3].Value = "";
                        procTable[x, 4].Value = task.TiempoLlegada;
                        procTable[x, 5].Value = "";
                        procTable[x, 6].Value = "";
                        procTable[x, 7].Value = task.TiempoAtendido;
                        procTable[x, 8].Value = task.TiempoServicio;
                        procTable[x, 9].Value = task.TiempoRestante;
                        if (task.TiempoAtendido != task.TiempoRespuesta2)
                            procTable[x, 10].Value = task.TiempoRespuesta2 + 1;
                        else
                            procTable[x, 10].Value = task.TiempoRespuesta2;
                        procTable[x, 11].Value = task.TME;
                        break;
                    case "Bloqueado":
                        procTable[x, 2].Value = task.Operacion;
                        procTable[x, 3].Value = "";
                        procTable[x, 4].Value = task.TiempoLlegada;
                        procTable[x, 5].Value = "";
                        procTable[x, 6].Value = "";
                        procTable[x, 7].Value = task.TiempoAtendido;
                        procTable[x, 8].Value = task.TiempoServicio;
                        procTable[x, 9].Value = task.TiempoRestante;
                        procTable[x, 10].Value = task.TiempoRespuesta2;
                        procTable[x, 11].Value = task.TME;
                        procTable[x, 12].Value = 10 - task.TiempoBloqueadoTranscurrido;
                        break;
                    case "Terminado":
                        procTable[x, 2].Value = task.Operacion;
                        procTable[x, 3].Value = task.Resultado();
                        procTable[x, 4].Value = task.TiempoLlegada;
                        procTable[x, 5].Value = task.TiempoFinalizacion;
                        procTable[x, 6].Value = task.TiempoRetorno;
                        procTable[x, 8].Value = task.TiempoServicio;
                        procTable[x, 9].Value = task.TiempoRestante;

                        if ((task.TiempoRespuesta2 + task.TiempoServicio) != task.TiempoRetorno) {
                            int diff = (task.TiempoRespuesta2 + task.TiempoServicio) - task.TiempoRetorno;
                            
                            procTable[x, 7].Value = task.TiempoAtendido - diff;
                            procTable[x, 10].Value = task.TiempoRespuesta2 - diff;
                            procTable[x, 11].Value = task.TME;
                        } else
                        {
                            procTable[x, 7].Value = task.TiempoAtendido;
                            if (task.TiempoAtendido != task.TiempoRespuesta2)
                                procTable[x, 10].Value = task.TiempoRespuesta2 + 1;
                            else
                                procTable[x, 10].Value = task.TiempoRespuesta2;
                            procTable[x, 11].Value = task.TME;
                        }
                        break;
                    case "Terminado por error":
                        procTable[x, 2].Value = task.Operacion;
                        procTable[x, 3].Value = "ERROR";
                        procTable[x, 4].Value = task.TiempoLlegada;
                        procTable[x, 5].Value = task.TiempoFinalizacion;
                        procTable[x, 6].Value = task.TiempoRetorno;
                        procTable[x, 7].Value = task.TiempoAtendido;
                        procTable[x, 8].Value = task.TiempoServicio;
                        procTable[x, 9].Value = task.TiempoRestante;
                        if (task.TiempoAtendido != task.TiempoRespuesta2)
                            procTable[x, 10].Value = task.TiempoRespuesta2 + 1;
                        else
                            procTable[x, 10].Value = task.TiempoRespuesta2;
                        procTable[x, 11].Value = task.TME;
                        break;
                }
                x++;
                if (x != procTasks.Count)
                    procTable.Columns.Add(" ", " ");
            }
        }
        #endregion

        #region Queues
        private void insertToReady(Task task)
        {
            procTasks.Remove(task);
            task.SetReady();
            readyTasks.Enqueue(task);
            procTasks.Add(task); // Proc Add
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
                exec.SetExec();
                this.execList.Rows.Clear();
                execList.Rows.Add(exec.toExecObject());
            }
        }

        private void updateExecutionProcess()
        {
            switch(this.readyTasks.Count)
            {
                case 2:
                    this.readyTasks.ElementAt(0).TiempoAtendido = 1;
                    this.readyTasks.ElementAt(1).TiempoAtendido = 1;

                    this.readyTasks.ElementAt(0).TiempoRespuesta2 = 1;
                    this.readyTasks.ElementAt(1).TiempoRespuesta2 = 1;
                    break;
                case 1:
                    this.readyTasks.ElementAt(0).TiempoAtendido = 1;

                    this.readyTasks.ElementAt(0).TiempoRespuesta2 = 1;
                    break;
            }
            this.execList.Rows[0][3] = this.exec.TiempoTranscurrido.ToString();
            this.execList.Rows[0][4] = this.exec.TiempoRestante.ToString();
        }

        private void sendToFinished(bool error)
        {
            if (exec != null)
            {
                switch (this.readyTasks.Count)
                {
                    case 2:
                        this.readyTasks.ElementAt(0).TiempoAtendido = 1;
                        this.readyTasks.ElementAt(1).TiempoAtendido = 1;

                        this.readyTasks.ElementAt(0).TiempoRespuesta2 = 1;
                        this.readyTasks.ElementAt(1).TiempoRespuesta2 = 1;
                        break;
                    case 1:
                        this.readyTasks.ElementAt(0).TiempoAtendido = 1;

                        this.readyTasks.ElementAt(0).TiempoRespuesta2 = 1;
                        break;
                }
                procTasks.Remove(exec);
                exec.TiempoFinalizacion = counter;
                exec.SetFinished();
                finishedTasks.Enqueue(exec);
                if (error)
                {
                    exec.SetError();
                    finishedList.Rows.Add(exec.toErrorObject());
                }
                else
                {
                    finishedList.Rows.Add(exec.toFinishedObject());
                }
                procTasks.Add(exec); // Proc Add
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
                procTasks.Remove(aux);
                aux.SetReady();
                aux.TiempoLlegada = counter;
                readyTasks.Enqueue(aux);
                procTasks.Add(aux); // Proc Add
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
                proceso.SetReady();
                readyTasks.Enqueue(proceso);
                readyList.Rows.Add(proceso.toReadyObject());
                blockedTasks.Remove(proceso);
            }
            blockedList.Rows.Clear();
            foreach(Task proceso in blockedTasks)
            {
                blockedList.Rows.Add(proceso.toBloquedObject());
                proceso.TiempoRespuesta2 = 1;
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
            TimeSpan t = TimeSpan.FromSeconds(counter);
            clockLabel.Text = t.ToString();
        }
        #endregion

        #region Form
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.I && (status != Keys.P && status != Keys.T))
            {
                interrupt();
                status = e.KeyCode;
            }
            if (e.KeyCode == Keys.E && (status != Keys.P && status != Keys.T))
            {
                sendToFinished(true);
                status = e.KeyCode;
            }
            if (e.KeyCode == Keys.P && (status != Keys.P || status != Keys.T))
            {
                timerClock.Stop();
                timerClock.Enabled = false;
                lblEstado.Text = state + "En pausa";
                status = e.KeyCode;
            }
            if (e.KeyCode == Keys.C && (status == Keys.P || status == Keys.T))
            {
                timerClock.Enabled = true;
                timerClock.Start();
                lblEstado.Text = state + "Corriendo";
                status = e.KeyCode;
                groupBox5.Visible = false;
                this.Size = new Size(579, 548);
            }
            if (e.KeyCode == Keys.N && (status != Keys.P && status != Keys.T))
            {
                Random random = new Random();
                Task proceso = new Task(id + 1, random);
                newTasks.Enqueue(proceso);
                procTasks.Add(proceso); // Add Proc
                id++;
                lblNuevos.Text = newProcessLabel + newTasks.Count;
                status = e.KeyCode;
            }
            if (e.KeyCode == Keys.T && status != Keys.P)
            {
                initProcTable();
                timerClock.Stop();
                timerClock.Enabled = false;
                lblEstado.Text = state + "En pausa";
                status = e.KeyCode;
                groupBox5.Visible = true;
                this.Size = new Size(821, 548);
            }
        }
        #endregion

        #region Functions
        private void interrupt()
        {
            if (exec != null)
            {
                procTasks.Remove(exec);
                exec.SetBlocked();
                blockedTasks.Add(exec);
                procTasks.Add(exec); // Proc Add
                blockedList.Rows.Add(exec.toBloquedObject());
                clearExecutionProcess();
                exec = null;
            }
        }

        private void initProcRows()
        {
            procTable.Rows.Clear();
            procTable.Columns.Clear();
            string[] headers = new string[] {
                "ID", "Estado del Proceso", "Operación",
                "Resultado", "T. Llegada", "T. Finalización",
                "T. Retorno", "T. Espera", "T. Servicio",
                "T. Restante", "T. Respuesta", "TME", "T.R. Bloqueo"
            };

            procTable.Columns.Add(" ", " ");
            procTable.RowHeadersWidth = 110;
            procTable.RowTemplate.Height = 29;
            foreach (string header in headers)
            {
                int rowId = procTable.Rows.Add();
                DataGridViewRow row = procTable.Rows[rowId];
                row.HeaderCell.Value = header;
            }
        }
        #endregion
    }
}
