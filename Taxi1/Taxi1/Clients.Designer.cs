namespace Taxi1
{
    partial class Clients
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.таксопаркDataSet = new Taxi1.ТаксопаркDataSet();
            this.клиентыBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.клиентыTableAdapter = new Taxi1.ТаксопаркDataSetTableAdapters.КлиентыTableAdapter();
            this.кодDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.фамилияDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.имяDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.отчетсвоDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.телефонDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.откудаКудаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.таксопаркDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.клиентыBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.кодDataGridViewTextBoxColumn,
            this.фамилияDataGridViewTextBoxColumn,
            this.имяDataGridViewTextBoxColumn,
            this.отчетсвоDataGridViewTextBoxColumn,
            this.телефонDataGridViewTextBoxColumn,
            this.откудаКудаDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.клиентыBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(0, 59);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(851, 251);
            this.dataGridView1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.lToolStripMenuItem,
            this.kToolStripMenuItem,
            this.sToolStripMenuItem,
            this.eToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(863, 56);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // таксопаркDataSet
            // 
            this.таксопаркDataSet.DataSetName = "ТаксопаркDataSet";
            this.таксопаркDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // клиентыBindingSource
            // 
            this.клиентыBindingSource.DataMember = "Клиенты";
            this.клиентыBindingSource.DataSource = this.таксопаркDataSet;
            // 
            // клиентыTableAdapter
            // 
            this.клиентыTableAdapter.ClearBeforeFill = true;
            // 
            // кодDataGridViewTextBoxColumn
            // 
            this.кодDataGridViewTextBoxColumn.DataPropertyName = "Код";
            this.кодDataGridViewTextBoxColumn.HeaderText = "Код";
            this.кодDataGridViewTextBoxColumn.Name = "кодDataGridViewTextBoxColumn";
            // 
            // фамилияDataGridViewTextBoxColumn
            // 
            this.фамилияDataGridViewTextBoxColumn.DataPropertyName = "Фамилия";
            this.фамилияDataGridViewTextBoxColumn.HeaderText = "Фамилия";
            this.фамилияDataGridViewTextBoxColumn.Name = "фамилияDataGridViewTextBoxColumn";
            // 
            // имяDataGridViewTextBoxColumn
            // 
            this.имяDataGridViewTextBoxColumn.DataPropertyName = "Имя";
            this.имяDataGridViewTextBoxColumn.HeaderText = "Имя";
            this.имяDataGridViewTextBoxColumn.Name = "имяDataGridViewTextBoxColumn";
            // 
            // отчетсвоDataGridViewTextBoxColumn
            // 
            this.отчетсвоDataGridViewTextBoxColumn.DataPropertyName = "Отчетсво";
            this.отчетсвоDataGridViewTextBoxColumn.HeaderText = "Отчетсво";
            this.отчетсвоDataGridViewTextBoxColumn.Name = "отчетсвоDataGridViewTextBoxColumn";
            // 
            // телефонDataGridViewTextBoxColumn
            // 
            this.телефонDataGridViewTextBoxColumn.DataPropertyName = "Телефон";
            this.телефонDataGridViewTextBoxColumn.HeaderText = "Телефон";
            this.телефонDataGridViewTextBoxColumn.Name = "телефонDataGridViewTextBoxColumn";
            // 
            // откудаКудаDataGridViewTextBoxColumn
            // 
            this.откудаКудаDataGridViewTextBoxColumn.DataPropertyName = "Откуда-Куда";
            this.откудаКудаDataGridViewTextBoxColumn.HeaderText = "Откуда-Куда";
            this.откудаКудаDataGridViewTextBoxColumn.Name = "откудаКудаDataGridViewTextBoxColumn";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = global::Taxi1.Properties.Resources.iconfinder_Plus_206460;
            this.toolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(60, 52);
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // lToolStripMenuItem
            // 
            this.lToolStripMenuItem.Image = global::Taxi1.Properties.Resources.iconfinder_edit_find_replace_118921;
            this.lToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.lToolStripMenuItem.Name = "lToolStripMenuItem";
            this.lToolStripMenuItem.Size = new System.Drawing.Size(60, 52);
            this.lToolStripMenuItem.Click += new System.EventHandler(this.lToolStripMenuItem_Click);
            // 
            // kToolStripMenuItem
            // 
            this.kToolStripMenuItem.Image = global::Taxi1.Properties.Resources.iconfinder_f_cross_256_282471;
            this.kToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.kToolStripMenuItem.Name = "kToolStripMenuItem";
            this.kToolStripMenuItem.Size = new System.Drawing.Size(60, 52);
            // 
            // sToolStripMenuItem
            // 
            this.sToolStripMenuItem.Image = global::Taxi1.Properties.Resources.iconfinder_floppy_285657;
            this.sToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.sToolStripMenuItem.Name = "sToolStripMenuItem";
            this.sToolStripMenuItem.Size = new System.Drawing.Size(60, 52);
            // 
            // eToolStripMenuItem
            // 
            this.eToolStripMenuItem.Image = global::Taxi1.Properties.Resources.iconfinder_excel_272697;
            this.eToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.eToolStripMenuItem.Name = "eToolStripMenuItem";
            this.eToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.eToolStripMenuItem.Size = new System.Drawing.Size(60, 52);
            // 
            // Clients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 322);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Clients";
            this.Text = "Clients";
            this.Load += new System.EventHandler(this.Clients_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.таксопаркDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.клиентыBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem lToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eToolStripMenuItem;
        private ТаксопаркDataSet таксопаркDataSet;
        private System.Windows.Forms.BindingSource клиентыBindingSource;
        private ТаксопаркDataSetTableAdapters.КлиентыTableAdapter клиентыTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn кодDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn фамилияDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn имяDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn отчетсвоDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn телефонDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn откудаКудаDataGridViewTextBoxColumn;
    }
}