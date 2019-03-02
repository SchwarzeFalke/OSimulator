namespace BatchInterrupt
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.numProcess = new System.Windows.Forms.NumericUpDown();
            this.start = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.waitingProc = new System.Windows.Forms.DataGridView();
            this.waitID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waitMaxT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waitRemain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.finishedProc = new System.Windows.Forms.DataGridView();
            this.finishID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.finishExTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.finishOp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.finishResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.execProc = new System.Windows.Forms.DataGridView();
            this.execID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.execOp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.execExTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.execRemTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.numProcess)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.waitingProc)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.finishedProc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.execProc)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Número de Procesos";
            // 
            // numProcess
            // 
            this.numProcess.Location = new System.Drawing.Point(124, 23);
            this.numProcess.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numProcess.Name = "numProcess";
            this.numProcess.Size = new System.Drawing.Size(41, 20);
            this.numProcess.TabIndex = 2;
            this.numProcess.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numProcess.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(15, 51);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(150, 23);
            this.start.TabIndex = 3;
            this.start.Text = "¡Comenzar Procesos!";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.waitingProc);
            this.groupBox1.Location = new System.Drawing.Point(195, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(593, 114);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Procesos en espera";
            // 
            // waitingProc
            // 
            this.waitingProc.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.waitingProc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.waitingProc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.waitID,
            this.waitMaxT,
            this.waitRemain});
            this.waitingProc.Location = new System.Drawing.Point(7, 20);
            this.waitingProc.Name = "waitingProc";
            this.waitingProc.ReadOnly = true;
            this.waitingProc.RowTemplate.Height = 20;
            this.waitingProc.RowTemplate.ReadOnly = true;
            this.waitingProc.Size = new System.Drawing.Size(580, 87);
            this.waitingProc.TabIndex = 0;
            // 
            // waitID
            // 
            this.waitID.HeaderText = "ID";
            this.waitID.Name = "waitID";
            this.waitID.ReadOnly = true;
            // 
            // waitMaxT
            // 
            this.waitMaxT.HeaderText = "Tiempo Máximo Estimado";
            this.waitMaxT.Name = "waitMaxT";
            this.waitMaxT.ReadOnly = true;
            // 
            // waitRemain
            // 
            this.waitRemain.HeaderText = "Tiempo restante";
            this.waitRemain.Name = "waitRemain";
            this.waitRemain.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.finishedProc);
            this.groupBox2.Location = new System.Drawing.Point(195, 274);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(593, 164);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Procesos terminados";
            // 
            // finishedProc
            // 
            this.finishedProc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.finishedProc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.finishID,
            this.finishExTime,
            this.finishOp,
            this.finishResult});
            this.finishedProc.Location = new System.Drawing.Point(7, 20);
            this.finishedProc.Name = "finishedProc";
            this.finishedProc.ReadOnly = true;
            this.finishedProc.Size = new System.Drawing.Size(580, 138);
            this.finishedProc.TabIndex = 0;
            // 
            // finishID
            // 
            this.finishID.HeaderText = "ID";
            this.finishID.Name = "finishID";
            this.finishID.ReadOnly = true;
            // 
            // finishExTime
            // 
            this.finishExTime.HeaderText = "Tiempo de ejecución";
            this.finishExTime.Name = "finishExTime";
            this.finishExTime.ReadOnly = true;
            // 
            // finishOp
            // 
            this.finishOp.HeaderText = "Operación";
            this.finishOp.Name = "finishOp";
            this.finishOp.ReadOnly = true;
            // 
            // finishResult
            // 
            this.finishResult.HeaderText = "Resultado";
            this.finishResult.Name = "finishResult";
            this.finishResult.ReadOnly = true;
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Font = new System.Drawing.Font("Courier New", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLabel.Location = new System.Drawing.Point(37, 194);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(100, 33);
            this.timeLabel.TabIndex = 6;
            this.timeLabel.Text = "00:00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(38, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 24);
            this.label2.TabIndex = 7;
            this.label2.Text = "R E L O J";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // execProc
            // 
            this.execProc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.execProc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.execID,
            this.execOp,
            this.execExTime,
            this.execRemTime});
            this.execProc.Location = new System.Drawing.Point(202, 194);
            this.execProc.Name = "execProc";
            this.execProc.ReadOnly = true;
            this.execProc.Size = new System.Drawing.Size(580, 60);
            this.execProc.TabIndex = 8;
            // 
            // execID
            // 
            this.execID.HeaderText = "ID";
            this.execID.Name = "execID";
            this.execID.ReadOnly = true;
            // 
            // execOp
            // 
            this.execOp.HeaderText = "Operación";
            this.execOp.Name = "execOp";
            this.execOp.ReadOnly = true;
            // 
            // execExTime
            // 
            this.execExTime.HeaderText = "Tiempo en ejecución";
            this.execExTime.Name = "execExTime";
            this.execExTime.ReadOnly = true;
            // 
            // execRemTime
            // 
            this.execRemTime.HeaderText = "Tiempo restante";
            this.execRemTime.Name = "execRemTime";
            this.execRemTime.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.execProc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.start);
            this.Controls.Add(this.numProcess);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "OSimulator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.numProcess)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.waitingProc)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.finishedProc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.execProc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numProcess;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView waitingProc;
        private System.Windows.Forms.DataGridView finishedProc;
        private System.Windows.Forms.DataGridViewTextBoxColumn waitID;
        private System.Windows.Forms.DataGridViewTextBoxColumn waitMaxT;
        private System.Windows.Forms.DataGridViewTextBoxColumn waitRemain;
        private System.Windows.Forms.DataGridView execProc;
        private System.Windows.Forms.DataGridViewTextBoxColumn execID;
        private System.Windows.Forms.DataGridViewTextBoxColumn execOp;
        private System.Windows.Forms.DataGridViewTextBoxColumn execExTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn execRemTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn finishID;
        private System.Windows.Forms.DataGridViewTextBoxColumn finishExTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn finishOp;
        private System.Windows.Forms.DataGridViewTextBoxColumn finishResult;
    }
}

