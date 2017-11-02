namespace Sitemap_Generator
{
    partial class MainF
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.playStopB = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.audioBarPB = new System.Windows.Forms.ProgressBar();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.audioInfoSS = new System.Windows.Forms.StatusStrip();
            this.audioPlayingL = new System.Windows.Forms.ToolStripStatusLabel();
            this.audioPositionL = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsmi = new System.Windows.Forms.MenuStrip();
            this.fileTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.listsTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.listsAddFilesTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.volumeTB = new System.Windows.Forms.TrackBar();
            this.listsTC = new System.Windows.Forms.TabControl();
            this.page1LTC = new System.Windows.Forms.TabPage();
            this.lbSS = new System.Windows.Forms.StatusStrip();
            this.listCMS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lbssOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.lbssSave = new System.Windows.Forms.ToolStripMenuItem();
            this.lbssSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.renameLCMS = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lbssRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.lbssAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.listBSS = new System.Windows.Forms.ToolStripDropDownButton();
            this.listInfoSS = new System.Windows.Forms.ToolStripStatusLabel();
            this.lists1LB = new System.Windows.Forms.ListBox();
            this.lbssNewList = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.audioInfoSS.SuspendLayout();
            this.tsmi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.volumeTB)).BeginInit();
            this.listsTC.SuspendLayout();
            this.page1LTC.SuspendLayout();
            this.lbSS.SuspendLayout();
            this.listCMS.SuspendLayout();
            this.SuspendLayout();
            // 
            // playStopB
            // 
            this.playStopB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.playStopB.Font = new System.Drawing.Font("Wingdings 3", 14F);
            this.playStopB.Location = new System.Drawing.Point(63, 188);
            this.playStopB.Name = "playStopB";
            this.playStopB.Size = new System.Drawing.Size(35, 32);
            this.playStopB.TabIndex = 1;
            this.playStopB.Text = "u";
            this.playStopB.UseVisualStyleBackColor = true;
            this.playStopB.Click += new System.EventHandler(this.playStopB_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(353, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 2;
            // 
            // audioBarPB
            // 
            this.audioBarPB.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.audioBarPB.Location = new System.Drawing.Point(0, 252);
            this.audioBarPB.Name = "audioBarPB";
            this.audioBarPB.Size = new System.Drawing.Size(385, 23);
            this.audioBarPB.TabIndex = 3;
            this.audioBarPB.MouseDown += new System.Windows.Forms.MouseEventHandler(this.audioBarPB_MouseDown);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // audioInfoSS
            // 
            this.audioInfoSS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.audioPlayingL,
            this.audioPositionL});
            this.audioInfoSS.Location = new System.Drawing.Point(0, 230);
            this.audioInfoSS.Name = "audioInfoSS";
            this.audioInfoSS.Size = new System.Drawing.Size(385, 22);
            this.audioInfoSS.TabIndex = 6;
            this.audioInfoSS.Text = "Sin reproducir ningún archivo";
            // 
            // audioPlayingL
            // 
            this.audioPlayingL.Name = "audioPlayingL";
            this.audioPlayingL.Size = new System.Drawing.Size(167, 17);
            this.audioPlayingL.Text = "Sin reproducir ningún archivo.";
            // 
            // audioPositionL
            // 
            this.audioPositionL.Name = "audioPositionL";
            this.audioPositionL.Size = new System.Drawing.Size(30, 17);
            this.audioPositionL.Text = "--:--";
            // 
            // tsmi
            // 
            this.tsmi.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileTSMI,
            this.listsTSMI});
            this.tsmi.Location = new System.Drawing.Point(0, 0);
            this.tsmi.Name = "tsmi";
            this.tsmi.Size = new System.Drawing.Size(385, 24);
            this.tsmi.TabIndex = 7;
            this.tsmi.Text = "menuStrip1";
            // 
            // fileTSMI
            // 
            this.fileTSMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileTSMI});
            this.fileTSMI.Name = "fileTSMI";
            this.fileTSMI.Size = new System.Drawing.Size(60, 20);
            this.fileTSMI.Text = "Archivo";
            // 
            // openFileTSMI
            // 
            this.openFileTSMI.Name = "openFileTSMI";
            this.openFileTSMI.Size = new System.Drawing.Size(155, 22);
            this.openFileTSMI.Text = "Abrir archivo(s)";
            this.openFileTSMI.Click += new System.EventHandler(this.openFileTSMI_Click);
            // 
            // listsTSMI
            // 
            this.listsTSMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listsAddFilesTSMI});
            this.listsTSMI.Name = "listsTSMI";
            this.listsTSMI.Size = new System.Drawing.Size(48, 20);
            this.listsTSMI.Text = "Listas";
            // 
            // listsAddFilesTSMI
            // 
            this.listsAddFilesTSMI.Name = "listsAddFilesTSMI";
            this.listsAddFilesTSMI.Size = new System.Drawing.Size(280, 22);
            this.listsAddFilesTSMI.Text = "Añadir archivo(s) a la lista seleccionada";
            this.listsAddFilesTSMI.Click += new System.EventHandler(this.listsAddFilesTSMI_Click);
            // 
            // volumeTB
            // 
            this.volumeTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.volumeTB.Location = new System.Drawing.Point(12, 116);
            this.volumeTB.Maximum = 100;
            this.volumeTB.Name = "volumeTB";
            this.volumeTB.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.volumeTB.Size = new System.Drawing.Size(45, 104);
            this.volumeTB.TabIndex = 8;
            this.volumeTB.Value = 100;
            this.volumeTB.Scroll += new System.EventHandler(this.volumeTB_Scroll);
            // 
            // listsTC
            // 
            this.listsTC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listsTC.Controls.Add(this.page1LTC);
            this.listsTC.Location = new System.Drawing.Point(212, 29);
            this.listsTC.Name = "listsTC";
            this.listsTC.SelectedIndex = 0;
            this.listsTC.Size = new System.Drawing.Size(173, 198);
            this.listsTC.TabIndex = 10;
            // 
            // page1LTC
            // 
            this.page1LTC.Controls.Add(this.lbSS);
            this.page1LTC.Controls.Add(this.lists1LB);
            this.page1LTC.Location = new System.Drawing.Point(4, 22);
            this.page1LTC.Name = "page1LTC";
            this.page1LTC.Padding = new System.Windows.Forms.Padding(3);
            this.page1LTC.Size = new System.Drawing.Size(165, 172);
            this.page1LTC.TabIndex = 0;
            this.page1LTC.Text = "Listas";
            this.page1LTC.UseVisualStyleBackColor = true;
            // 
            // lbSS
            // 
            this.lbSS.ContextMenuStrip = this.listCMS;
            this.lbSS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listBSS,
            this.listInfoSS});
            this.lbSS.Location = new System.Drawing.Point(3, 147);
            this.lbSS.Name = "lbSS";
            this.lbSS.Size = new System.Drawing.Size(159, 22);
            this.lbSS.TabIndex = 2;
            this.lbSS.Text = "statusStrip1";
            // 
            // listCMS
            // 
            this.listCMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbssNewList,
            this.toolStripSeparator3,
            this.lbssOpen,
            this.lbssSave,
            this.lbssSaveAs,
            this.toolStripSeparator2,
            this.renameLCMS,
            this.toolStripSeparator1,
            this.lbssRemove,
            this.lbssAdd});
            this.listCMS.Name = "listCMS";
            this.listCMS.Size = new System.Drawing.Size(184, 198);
            this.listCMS.Text = "Lista";
            // 
            // lbssOpen
            // 
            this.lbssOpen.Name = "lbssOpen";
            this.lbssOpen.Size = new System.Drawing.Size(183, 22);
            this.lbssOpen.Text = "Abrir lista";
            this.lbssOpen.Click += new System.EventHandler(this.lbssOpen_Click);
            // 
            // lbssSave
            // 
            this.lbssSave.Name = "lbssSave";
            this.lbssSave.Size = new System.Drawing.Size(183, 22);
            this.lbssSave.Text = "Guardar lista";
            this.lbssSave.Click += new System.EventHandler(this.lbssSave_Click);
            // 
            // lbssSaveAs
            // 
            this.lbssSaveAs.Name = "lbssSaveAs";
            this.lbssSaveAs.Size = new System.Drawing.Size(183, 22);
            this.lbssSaveAs.Text = "Guardar lista como...";
            this.lbssSaveAs.Click += new System.EventHandler(this.lbssSaveAs_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(180, 6);
            // 
            // renameLCMS
            // 
            this.renameLCMS.Name = "renameLCMS";
            this.renameLCMS.Size = new System.Drawing.Size(183, 22);
            this.renameLCMS.Text = "Renombrar lista";
            this.renameLCMS.Click += new System.EventHandler(this.renameLCMS_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(180, 6);
            // 
            // lbssRemove
            // 
            this.lbssRemove.Name = "lbssRemove";
            this.lbssRemove.Size = new System.Drawing.Size(183, 22);
            this.lbssRemove.Text = "Eliminar archivo(s)";
            this.lbssRemove.Click += new System.EventHandler(this.lbssRemove_Click);
            // 
            // lbssAdd
            // 
            this.lbssAdd.Name = "lbssAdd";
            this.lbssAdd.Size = new System.Drawing.Size(183, 22);
            this.lbssAdd.Text = "Añadir archivo(s)";
            this.lbssAdd.Click += new System.EventHandler(this.lbssAdd_Click);
            // 
            // listBSS
            // 
            this.listBSS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.listBSS.Image = ((System.Drawing.Image)(resources.GetObject("listBSS.Image")));
            this.listBSS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.listBSS.Name = "listBSS";
            this.listBSS.Size = new System.Drawing.Size(29, 20);
            this.listBSS.Text = "Lista";
            this.listBSS.Click += new System.EventHandler(this.listBSS_Click);
            // 
            // listInfoSS
            // 
            this.listInfoSS.Name = "listInfoSS";
            this.listInfoSS.Size = new System.Drawing.Size(94, 17);
            this.listInfoSS.Text = "Lista sin nombre";
            this.listInfoSS.Click += new System.EventHandler(this.listInfoSS_Click);
            // 
            // lists1LB
            // 
            this.lists1LB.AllowDrop = true;
            this.lists1LB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lists1LB.ContextMenuStrip = this.listCMS;
            this.lists1LB.FormattingEnabled = true;
            this.lists1LB.Location = new System.Drawing.Point(3, 3);
            this.lists1LB.Name = "lists1LB";
            this.lists1LB.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lists1LB.Size = new System.Drawing.Size(159, 134);
            this.lists1LB.TabIndex = 0;
            this.lists1LB.SelectedIndexChanged += new System.EventHandler(this.lists1LB_SelectedIndexChanged);
            this.lists1LB.DragDrop += new System.Windows.Forms.DragEventHandler(this.lists1LB_DragDrop);
            this.lists1LB.DragEnter += new System.Windows.Forms.DragEventHandler(this.lists1LB_DragEnter);
            this.lists1LB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lists1LB_KeyDown);
            // 
            // lbssNewList
            // 
            this.lbssNewList.Name = "lbssNewList";
            this.lbssNewList.Size = new System.Drawing.Size(183, 22);
            this.lbssNewList.Text = "Nueva lista";
            this.lbssNewList.Click += new System.EventHandler(this.lbssNewList_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(180, 6);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 275);
            this.Controls.Add(this.listsTC);
            this.Controls.Add(this.volumeTB);
            this.Controls.Add(this.audioInfoSS);
            this.Controls.Add(this.tsmi);
            this.Controls.Add(this.audioBarPB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.playStopB);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.tsmi;
            this.Name = "Form1";
            this.Text = "SAP";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.audioInfoSS.ResumeLayout(false);
            this.audioInfoSS.PerformLayout();
            this.tsmi.ResumeLayout(false);
            this.tsmi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.volumeTB)).EndInit();
            this.listsTC.ResumeLayout(false);
            this.page1LTC.ResumeLayout(false);
            this.page1LTC.PerformLayout();
            this.lbSS.ResumeLayout(false);
            this.lbSS.PerformLayout();
            this.listCMS.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button playStopB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar audioBarPB;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.StatusStrip audioInfoSS;
        private System.Windows.Forms.ToolStripStatusLabel audioPlayingL;
        private System.Windows.Forms.ToolStripStatusLabel audioPositionL;
        private System.Windows.Forms.MenuStrip tsmi;
        private System.Windows.Forms.ToolStripMenuItem fileTSMI;
        private System.Windows.Forms.ToolStripMenuItem openFileTSMI;
        private System.Windows.Forms.TrackBar volumeTB;
        private System.Windows.Forms.ToolStripMenuItem listsTSMI;
        private System.Windows.Forms.ToolStripMenuItem listsAddFilesTSMI;
        private System.Windows.Forms.TabControl listsTC;
        private System.Windows.Forms.TabPage page1LTC;
        private System.Windows.Forms.ListBox lists1LB;
        private System.Windows.Forms.StatusStrip lbSS;
        private System.Windows.Forms.ToolStripDropDownButton listBSS;
        private System.Windows.Forms.ContextMenuStrip listCMS;
        private System.Windows.Forms.ToolStripMenuItem renameLCMS;
        public System.Windows.Forms.ToolStripStatusLabel listInfoSS;
        private System.Windows.Forms.ToolStripMenuItem lbssOpen;
        private System.Windows.Forms.ToolStripMenuItem lbssSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem lbssRemove;
        private System.Windows.Forms.ToolStripMenuItem lbssAdd;
        private System.Windows.Forms.ToolStripMenuItem lbssSaveAs;
        private System.Windows.Forms.ToolStripMenuItem lbssNewList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}

