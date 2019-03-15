namespace Programa_3
{
    partial class MainForm
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
            this.addProc = new System.Windows.Forms.Button();
            this.readyProc = new System.Windows.Forms.DataGridView();
            this.finishedProc = new System.Windows.Forms.DataGridView();
            this.clockLabel = new System.Windows.Forms.Label();
            this.execProc = new System.Windows.Forms.DataGridView();
            this.start = new System.Windows.Forms.Button();
            this.blockedProc = new System.Windows.Forms.DataGridView();
            this.lblNuevos = new System.Windows.Forms.Label();
            this.timerClock = new System.Windows.Forms.Timer(this.components);
            this.lblEstado = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.amountProc = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.procTable = new System.Windows.Forms.DataGridView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.readyProc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.finishedProc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.execProc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blockedProc)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.amountProc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.procTable)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // addProc
            // 
            this.addProc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addProc.Location = new System.Drawing.Point(15, 104);
            this.addProc.Name = "addProc";
            this.addProc.Size = new System.Drawing.Size(164, 26);
            this.addProc.TabIndex = 0;
            this.addProc.Text = "Agregar procesos";
            this.addProc.UseVisualStyleBackColor = true;
            this.addProc.Click += new System.EventHandler(this.addProc_Click);
            // 
            // readyProc
            // 
            this.readyProc.AllowUserToAddRows = false;
            this.readyProc.AllowUserToDeleteRows = false;
            this.readyProc.AllowUserToResizeColumns = false;
            this.readyProc.AllowUserToResizeRows = false;
            this.readyProc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.readyProc.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.readyProc.Location = new System.Drawing.Point(6, 19);
            this.readyProc.Name = "readyProc";
            this.readyProc.Size = new System.Drawing.Size(318, 123);
            this.readyProc.TabIndex = 3;
            // 
            // finishedProc
            // 
            this.finishedProc.AllowUserToAddRows = false;
            this.finishedProc.AllowUserToDeleteRows = false;
            this.finishedProc.AllowUserToResizeColumns = false;
            this.finishedProc.AllowUserToResizeRows = false;
            this.finishedProc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.finishedProc.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.finishedProc.Location = new System.Drawing.Point(6, 19);
            this.finishedProc.Name = "finishedProc";
            this.finishedProc.Size = new System.Drawing.Size(318, 141);
            this.finishedProc.TabIndex = 4;
            // 
            // clockLabel
            // 
            this.clockLabel.AutoSize = true;
            this.clockLabel.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clockLabel.Location = new System.Drawing.Point(217, 25);
            this.clockLabel.Name = "clockLabel";
            this.clockLabel.Size = new System.Drawing.Size(98, 22);
            this.clockLabel.TabIndex = 6;
            this.clockLabel.Text = "00:00:00";
            this.clockLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // execProc
            // 
            this.execProc.AllowUserToAddRows = false;
            this.execProc.AllowUserToDeleteRows = false;
            this.execProc.AllowUserToResizeColumns = false;
            this.execProc.AllowUserToResizeRows = false;
            this.execProc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.execProc.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.execProc.Location = new System.Drawing.Point(6, 17);
            this.execProc.Name = "execProc";
            this.execProc.Size = new System.Drawing.Size(318, 62);
            this.execProc.TabIndex = 8;
            // 
            // start
            // 
            this.start.Enabled = false;
            this.start.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start.Location = new System.Drawing.Point(15, 72);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(164, 26);
            this.start.TabIndex = 10;
            this.start.Text = "Ejecutar";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // blockedProc
            // 
            this.blockedProc.AllowUserToAddRows = false;
            this.blockedProc.AllowUserToDeleteRows = false;
            this.blockedProc.AllowUserToResizeColumns = false;
            this.blockedProc.AllowUserToResizeRows = false;
            this.blockedProc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.blockedProc.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.blockedProc.Location = new System.Drawing.Point(7, 17);
            this.blockedProc.Name = "blockedProc";
            this.blockedProc.Size = new System.Drawing.Size(154, 143);
            this.blockedProc.TabIndex = 11;
            // 
            // lblNuevos
            // 
            this.lblNuevos.AutoSize = true;
            this.lblNuevos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNuevos.Location = new System.Drawing.Point(19, 175);
            this.lblNuevos.Name = "lblNuevos";
            this.lblNuevos.Size = new System.Drawing.Size(119, 16);
            this.lblNuevos.TabIndex = 13;
            this.lblNuevos.Text = "Procesos Nuevos:";
            // 
            // timerClock
            // 
            this.timerClock.Interval = 1000;
            this.timerClock.Tick += new System.EventHandler(this.timerClock_Tick);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.Location = new System.Drawing.Point(19, 252);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(54, 16);
            this.lblEstado.TabIndex = 14;
            this.lblEstado.Text = "Estado:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.readyProc);
            this.groupBox1.Location = new System.Drawing.Point(215, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(333, 153);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Procesos Listos";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.execProc);
            this.groupBox2.Location = new System.Drawing.Point(215, 228);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(333, 85);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Proceso en Ejecución";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.finishedProc);
            this.groupBox3.Location = new System.Drawing.Point(215, 337);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(333, 169);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Procesos Terminados";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.blockedProc);
            this.groupBox4.Location = new System.Drawing.Point(15, 337);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(167, 169);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Procesos Bloqueados";
            // 
            // amountProc
            // 
            this.amountProc.Location = new System.Drawing.Point(127, 35);
            this.amountProc.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.amountProc.Name = "amountProc";
            this.amountProc.Size = new System.Drawing.Size(48, 20);
            this.amountProc.TabIndex = 19;
            this.amountProc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.amountProc.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Número de Procesos:";
            // 
            // procTable
            // 
            this.procTable.AllowUserToAddRows = false;
            this.procTable.AllowUserToDeleteRows = false;
            this.procTable.AllowUserToResizeColumns = false;
            this.procTable.AllowUserToResizeRows = false;
            this.procTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.procTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.procTable.Location = new System.Drawing.Point(6, 19);
            this.procTable.Name = "procTable";
            this.procTable.Size = new System.Drawing.Size(222, 427);
            this.procTable.TabIndex = 21;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.procTable);
            this.groupBox5.Location = new System.Drawing.Point(564, 51);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(235, 455);
            this.groupBox5.TabIndex = 22;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Tabla de Procesos";
            this.groupBox5.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(563, 509);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.amountProc);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.lblNuevos);
            this.Controls.Add(this.start);
            this.Controls.Add(this.clockLabel);
            this.Controls.Add(this.addProc);
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(821, 548);
            this.MinimumSize = new System.Drawing.Size(579, 548);
            this.Name = "MainForm";
            this.Text = "OSimulator";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.readyProc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.finishedProc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.execProc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blockedProc)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.amountProc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.procTable)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addProc;
        private System.Windows.Forms.DataGridView readyProc;
        private System.Windows.Forms.DataGridView finishedProc;
        private System.Windows.Forms.Label clockLabel;
        private System.Windows.Forms.DataGridView execProc;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.DataGridView blockedProc;
        private System.Windows.Forms.Label lblNuevos;
        private System.Windows.Forms.Timer timerClock;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.NumericUpDown amountProc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView procTable;
        private System.Windows.Forms.GroupBox groupBox5;
    }
}

