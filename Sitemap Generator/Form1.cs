using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Sitemap_Generator
{
    public class Form1 : Form
    {
        private IContainer components = (IContainer)null;
        private List<string> fp_files = new List<string>();
        private List<string> sn_files = new List<string>();
        private string savePath = "";
        private string sgfolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\LonamiWebs\\Sitemap Generator";
        private List<string> name = new List<string>();
        private List<string> value = new List<string>();
        private bool includeSubdirs = true;
        private bool saved = true;
        private List<ToolStripMenuItem> allTSMI = new List<ToolStripMenuItem>();
        private List<Button> allB = new List<Button>();
        private List<Label> allL = new List<Label>();
        private MenuStrip menuS;
        private ToolStripMenuItem sitemapTSMI;
        private ToolStripMenuItem saveTSMI;
        private ToolStripMenuItem saveAsTSMI;
        private ToolStripMenuItem helpTSMI;
        private ToolStripMenuItem supportTSMI;
        private ToolStripMenuItem helpPopTSMI;
        private ToolStripMenuItem exitTSMI;
        private TextBox sitemapDirectoryTB;
        private Button sitemapDirectoryB;
        private MonthCalendar sitemapDateMC;
        private ListBox sitemapPagesLB;
        private Label sitemapDateL;
        private Label sitemapPagesL;
        private Button sitemapListRemoveSelectedB;
        private Button sitemapListAddFileB;
        private GroupBox sitemapContentGB;
        private RadioButton generationTypeRB;
        private ComboBox sitemapChangeFreqCB;
        private Label sitemapChangeFreqL;
        private Label sitemapPriorityL;
        private NumericUpDown sitemapPriorityNUD;
        private Label sitemapUrlL;
        private ComboBox sitemapUrlCB;
        private TextBox sitemapUrlTB;
        private ToolStripMenuItem optionsTSMI;
        private ToolStripMenuItem includeSubdirsTSMI;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem updateTSMI;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem xmlViewerTSMI;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem languageTSMI;
        private ToolStripMenuItem spanishTSMI;
        private ToolStripMenuItem englishTSMI;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem checkUpdatesTSMI;
        private ToolStripMenuItem languageCustomTSMI;

        public Form1(string[] paths)
        {
            this.InitializeComponent();

            this.paths = paths;
        }

        string[] paths = new string[0];

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuS = new System.Windows.Forms.MenuStrip();
            this.sitemapTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.saveTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.updateTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.xmlViewerTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.includeSubdirsTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.languageTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.spanishTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.englishTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.languageCustomTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.helpTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.supportTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.helpPopTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.exitTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.sitemapDirectoryTB = new System.Windows.Forms.TextBox();
            this.sitemapDirectoryB = new System.Windows.Forms.Button();
            this.sitemapDateMC = new System.Windows.Forms.MonthCalendar();
            this.sitemapPagesLB = new System.Windows.Forms.ListBox();
            this.sitemapDateL = new System.Windows.Forms.Label();
            this.sitemapPagesL = new System.Windows.Forms.Label();
            this.sitemapListRemoveSelectedB = new System.Windows.Forms.Button();
            this.sitemapListAddFileB = new System.Windows.Forms.Button();
            this.sitemapContentGB = new System.Windows.Forms.GroupBox();
            this.sitemapPriorityNUD = new System.Windows.Forms.NumericUpDown();
            this.sitemapPriorityL = new System.Windows.Forms.Label();
            this.generationTypeRB = new System.Windows.Forms.RadioButton();
            this.sitemapChangeFreqCB = new System.Windows.Forms.ComboBox();
            this.sitemapChangeFreqL = new System.Windows.Forms.Label();
            this.sitemapUrlL = new System.Windows.Forms.Label();
            this.sitemapUrlCB = new System.Windows.Forms.ComboBox();
            this.sitemapUrlTB = new System.Windows.Forms.TextBox();
            this.checkUpdatesTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.menuS.SuspendLayout();
            this.sitemapContentGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sitemapPriorityNUD)).BeginInit();
            this.SuspendLayout();
            // 
            // menuS
            // 
            this.menuS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sitemapTSMI,
            this.optionsTSMI,
            this.helpTSMI,
            this.exitTSMI});
            this.menuS.Location = new System.Drawing.Point(0, 0);
            this.menuS.Name = "menuS";
            this.menuS.Size = new System.Drawing.Size(598, 24);
            this.menuS.TabIndex = 0;
            this.menuS.Text = "menuStrip1";
            // 
            // sitemapTSMI
            // 
            this.sitemapTSMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveTSMI,
            this.saveAsTSMI,
            this.toolStripSeparator1,
            this.updateTSMI,
            this.toolStripSeparator2,
            this.xmlViewerTSMI});
            this.sitemapTSMI.Name = "sitemapTSMI";
            this.sitemapTSMI.Size = new System.Drawing.Size(62, 20);
            this.sitemapTSMI.Text = "Sitemap";
            // 
            // saveTSMI
            // 
            this.saveTSMI.Name = "saveTSMI";
            this.saveTSMI.Size = new System.Drawing.Size(171, 22);
            this.saveTSMI.Text = "Guardar";
            this.saveTSMI.Click += new System.EventHandler(this.saveTSMI_Click);
            // 
            // saveAsTSMI
            // 
            this.saveAsTSMI.Name = "saveAsTSMI";
            this.saveAsTSMI.Size = new System.Drawing.Size(171, 22);
            this.saveAsTSMI.Text = "Guardar cómo...";
            this.saveAsTSMI.Click += new System.EventHandler(this.saveAsTSMI_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(168, 6);
            // 
            // updateTSMI
            // 
            this.updateTSMI.Name = "updateTSMI";
            this.updateTSMI.Size = new System.Drawing.Size(171, 22);
            this.updateTSMI.Text = "Actualizar sitemap";
            this.updateTSMI.Click += new System.EventHandler(this.updateTSMI_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(168, 6);
            // 
            // xmlViewerTSMI
            // 
            this.xmlViewerTSMI.Name = "xmlViewerTSMI";
            this.xmlViewerTSMI.Size = new System.Drawing.Size(171, 22);
            this.xmlViewerTSMI.Text = "Visor XML";
            this.xmlViewerTSMI.Click += new System.EventHandler(this.xmlViewerTSMI_Click);
            // 
            // optionsTSMI
            // 
            this.optionsTSMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.includeSubdirsTSMI,
            this.toolStripSeparator3,
            this.languageTSMI});
            this.optionsTSMI.Name = "optionsTSMI";
            this.optionsTSMI.Size = new System.Drawing.Size(69, 20);
            this.optionsTSMI.Text = "Opciones";
            // 
            // includeSubdirsTSMI
            // 
            this.includeSubdirsTSMI.CheckOnClick = true;
            this.includeSubdirsTSMI.Name = "includeSubdirsTSMI";
            this.includeSubdirsTSMI.Size = new System.Drawing.Size(283, 22);
            this.includeSubdirsTSMI.Text = "Incluir subdirectorios al elegir directorio";
            this.includeSubdirsTSMI.Click += new System.EventHandler(this.includeSubdirsTSMI_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(280, 6);
            // 
            // languageTSMI
            // 
            this.languageTSMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.spanishTSMI,
            this.englishTSMI,
            this.toolStripSeparator4,
            this.languageCustomTSMI});
            this.languageTSMI.Name = "languageTSMI";
            this.languageTSMI.Size = new System.Drawing.Size(283, 22);
            this.languageTSMI.Text = "Lenguaje";
            // 
            // spanishTSMI
            // 
            this.spanishTSMI.Name = "spanishTSMI";
            this.spanishTSMI.Size = new System.Drawing.Size(179, 22);
            this.spanishTSMI.Text = "Español";
            this.spanishTSMI.Click += new System.EventHandler(this.spanishTSMI_Click);
            // 
            // englishTSMI
            // 
            this.englishTSMI.Name = "englishTSMI";
            this.englishTSMI.Size = new System.Drawing.Size(179, 22);
            this.englishTSMI.Text = "English";
            this.englishTSMI.Click += new System.EventHandler(this.englishTSMI_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(176, 6);
            // 
            // languageCustomTSMI
            // 
            this.languageCustomTSMI.Name = "languageCustomTSMI";
            this.languageCustomTSMI.Size = new System.Drawing.Size(179, 22);
            this.languageCustomTSMI.Text = "Elegir personalizado";
            this.languageCustomTSMI.Click += new System.EventHandler(this.languageCustomTSMI_Click);
            // 
            // helpTSMI
            // 
            this.helpTSMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.supportTSMI,
            this.helpPopTSMI,
            this.checkUpdatesTSMI});
            this.helpTSMI.Name = "helpTSMI";
            this.helpTSMI.Size = new System.Drawing.Size(53, 20);
            this.helpTSMI.Text = "Ayuda";
            // 
            // supportTSMI
            // 
            this.supportTSMI.Name = "supportTSMI";
            this.supportTSMI.Size = new System.Drawing.Size(218, 22);
            this.supportTSMI.Text = "Soporte";
            this.supportTSMI.Click += new System.EventHandler(this.supportTSMI_Click);
            // 
            // helpPopTSMI
            // 
            this.helpPopTSMI.Name = "helpPopTSMI";
            this.helpPopTSMI.Size = new System.Drawing.Size(218, 22);
            this.helpPopTSMI.Text = "Ayuda";
            this.helpPopTSMI.Click += new System.EventHandler(this.helpPopTSMI_Click);
            // 
            // exitTSMI
            // 
            this.exitTSMI.Name = "exitTSMI";
            this.exitTSMI.Size = new System.Drawing.Size(41, 20);
            this.exitTSMI.Text = "Salir";
            this.exitTSMI.Click += new System.EventHandler(this.exitTSMI_Click);
            // 
            // sitemapDirectoryTB
            // 
            this.sitemapDirectoryTB.Location = new System.Drawing.Point(13, 28);
            this.sitemapDirectoryTB.Name = "sitemapDirectoryTB";
            this.sitemapDirectoryTB.Size = new System.Drawing.Size(360, 20);
            this.sitemapDirectoryTB.TabIndex = 1;
            this.sitemapDirectoryTB.Click += new System.EventHandler(this.sitemapDirectoryTB_Click);
            this.sitemapDirectoryTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sitemapDirectoryTB_KeyDown);
            // 
            // sitemapDirectoryB
            // 
            this.sitemapDirectoryB.Location = new System.Drawing.Point(379, 25);
            this.sitemapDirectoryB.Name = "sitemapDirectoryB";
            this.sitemapDirectoryB.Size = new System.Drawing.Size(210, 23);
            this.sitemapDirectoryB.TabIndex = 2;
            this.sitemapDirectoryB.Text = "Elegir directorio del cual generar sitemap";
            this.sitemapDirectoryB.UseVisualStyleBackColor = true;
            this.sitemapDirectoryB.Click += new System.EventHandler(this.sitemapDirectoryB_Click);
            // 
            // sitemapDateMC
            // 
            this.sitemapDateMC.Location = new System.Drawing.Point(7, 34);
            this.sitemapDateMC.Name = "sitemapDateMC";
            this.sitemapDateMC.TabIndex = 4;
            // 
            // sitemapPagesLB
            // 
            this.sitemapPagesLB.FormattingEnabled = true;
            this.sitemapPagesLB.Location = new System.Drawing.Point(12, 73);
            this.sitemapPagesLB.Name = "sitemapPagesLB";
            this.sitemapPagesLB.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.sitemapPagesLB.Size = new System.Drawing.Size(200, 160);
            this.sitemapPagesLB.TabIndex = 5;
            this.sitemapPagesLB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sitemapPagesLB_KeyDown);
            this.sitemapPagesLB.MouseDown += new System.Windows.Forms.MouseEventHandler(this.sitemapPagesLB_MouseDown);
            // 
            // sitemapDateL
            // 
            this.sitemapDateL.AutoSize = true;
            this.sitemapDateL.Location = new System.Drawing.Point(6, 16);
            this.sitemapDateL.Name = "sitemapDateL";
            this.sitemapDateL.Size = new System.Drawing.Size(150, 13);
            this.sitemapDateL.TabIndex = 6;
            this.sitemapDateL.Text = "Fecha de última actualización:";
            // 
            // sitemapPagesL
            // 
            this.sitemapPagesL.AutoSize = true;
            this.sitemapPagesL.Location = new System.Drawing.Point(12, 55);
            this.sitemapPagesL.Name = "sitemapPagesL";
            this.sitemapPagesL.Size = new System.Drawing.Size(89, 13);
            this.sitemapPagesL.TabIndex = 7;
            this.sitemapPagesL.Text = "Páginas a añadir:";
            // 
            // sitemapListRemoveSelectedB
            // 
            this.sitemapListRemoveSelectedB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.sitemapListRemoveSelectedB.Location = new System.Drawing.Point(13, 240);
            this.sitemapListRemoveSelectedB.Name = "sitemapListRemoveSelectedB";
            this.sitemapListRemoveSelectedB.Size = new System.Drawing.Size(199, 23);
            this.sitemapListRemoveSelectedB.TabIndex = 9;
            this.sitemapListRemoveSelectedB.Text = "Eliminar página(s) seleccionada(s)";
            this.sitemapListRemoveSelectedB.UseVisualStyleBackColor = true;
            this.sitemapListRemoveSelectedB.Click += new System.EventHandler(this.sitemapListRemoveSelectedB_Click);
            // 
            // sitemapListAddFileB
            // 
            this.sitemapListAddFileB.Location = new System.Drawing.Point(13, 270);
            this.sitemapListAddFileB.Name = "sitemapListAddFileB";
            this.sitemapListAddFileB.Size = new System.Drawing.Size(199, 23);
            this.sitemapListAddFileB.TabIndex = 10;
            this.sitemapListAddFileB.Text = "Añadir página(s) manualmente";
            this.sitemapListAddFileB.UseVisualStyleBackColor = true;
            this.sitemapListAddFileB.Click += new System.EventHandler(this.sitemapListAddFileB_Click);
            // 
            // sitemapContentGB
            // 
            this.sitemapContentGB.Controls.Add(this.sitemapPriorityNUD);
            this.sitemapContentGB.Controls.Add(this.sitemapPriorityL);
            this.sitemapContentGB.Controls.Add(this.generationTypeRB);
            this.sitemapContentGB.Controls.Add(this.sitemapChangeFreqCB);
            this.sitemapContentGB.Controls.Add(this.sitemapChangeFreqL);
            this.sitemapContentGB.Controls.Add(this.sitemapDateL);
            this.sitemapContentGB.Controls.Add(this.sitemapDateMC);
            this.sitemapContentGB.Location = new System.Drawing.Point(221, 55);
            this.sitemapContentGB.Name = "sitemapContentGB";
            this.sitemapContentGB.Size = new System.Drawing.Size(368, 238);
            this.sitemapContentGB.TabIndex = 11;
            this.sitemapContentGB.TabStop = false;
            this.sitemapContentGB.Text = "Contenido del sitemap";
            // 
            // sitemapPriorityNUD
            // 
            this.sitemapPriorityNUD.DecimalPlaces = 1;
            this.sitemapPriorityNUD.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.sitemapPriorityNUD.Location = new System.Drawing.Point(296, 77);
            this.sitemapPriorityNUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.sitemapPriorityNUD.Name = "sitemapPriorityNUD";
            this.sitemapPriorityNUD.Size = new System.Drawing.Size(66, 20);
            this.sitemapPriorityNUD.TabIndex = 11;
            this.sitemapPriorityNUD.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            // 
            // sitemapPriorityL
            // 
            this.sitemapPriorityL.AutoSize = true;
            this.sitemapPriorityL.Location = new System.Drawing.Point(238, 79);
            this.sitemapPriorityL.Name = "sitemapPriorityL";
            this.sitemapPriorityL.Size = new System.Drawing.Size(60, 13);
            this.sitemapPriorityL.TabIndex = 10;
            this.sitemapPriorityL.Text = "¿Prioridad?";
            // 
            // generationTypeRB
            // 
            this.generationTypeRB.AutoSize = true;
            this.generationTypeRB.Checked = true;
            this.generationTypeRB.Location = new System.Drawing.Point(6, 218);
            this.generationTypeRB.Name = "generationTypeRB";
            this.generationTypeRB.Size = new System.Drawing.Size(333, 17);
            this.generationTypeRB.TabIndex = 9;
            this.generationTypeRB.TabStop = true;
            this.generationTypeRB.Text = "Generación global (el contenido afecta a todas las URL por igual)";
            this.generationTypeRB.UseVisualStyleBackColor = true;
            // 
            // sitemapChangeFreqCB
            // 
            this.sitemapChangeFreqCB.FormattingEnabled = true;
            this.sitemapChangeFreqCB.Items.AddRange(new object[] {
            "always",
            "daily",
            "weekly",
            "monthly",
            "yearly",
            "never"});
            this.sitemapChangeFreqCB.Location = new System.Drawing.Point(241, 33);
            this.sitemapChangeFreqCB.Name = "sitemapChangeFreqCB";
            this.sitemapChangeFreqCB.Size = new System.Drawing.Size(121, 21);
            this.sitemapChangeFreqCB.TabIndex = 8;
            this.sitemapChangeFreqCB.Text = "daily";
            // 
            // sitemapChangeFreqL
            // 
            this.sitemapChangeFreqL.AutoSize = true;
            this.sitemapChangeFreqL.Location = new System.Drawing.Point(238, 16);
            this.sitemapChangeFreqL.Name = "sitemapChangeFreqL";
            this.sitemapChangeFreqL.Size = new System.Drawing.Size(124, 13);
            this.sitemapChangeFreqL.TabIndex = 7;
            this.sitemapChangeFreqL.Text = "¿Frecuencia de cambio?";
            // 
            // sitemapUrlL
            // 
            this.sitemapUrlL.AutoSize = true;
            this.sitemapUrlL.Location = new System.Drawing.Point(12, 308);
            this.sitemapUrlL.Name = "sitemapUrlL";
            this.sitemapUrlL.Size = new System.Drawing.Size(180, 13);
            this.sitemapUrlL.TabIndex = 12;
            this.sitemapUrlL.Text = "Especifica la URL de tu página web:";
            // 
            // sitemapUrlCB
            // 
            this.sitemapUrlCB.FormattingEnabled = true;
            this.sitemapUrlCB.Items.AddRange(new object[] {
            "http://",
            "https://",
            "www."});
            this.sitemapUrlCB.Location = new System.Drawing.Point(198, 305);
            this.sitemapUrlCB.Name = "sitemapUrlCB";
            this.sitemapUrlCB.Size = new System.Drawing.Size(60, 21);
            this.sitemapUrlCB.TabIndex = 13;
            this.sitemapUrlCB.Text = "http://";
            // 
            // sitemapUrlTB
            // 
            this.sitemapUrlTB.Location = new System.Drawing.Point(264, 305);
            this.sitemapUrlTB.Name = "sitemapUrlTB";
            this.sitemapUrlTB.Size = new System.Drawing.Size(322, 20);
            this.sitemapUrlTB.TabIndex = 14;
            // 
            // checkUpdatesTSMI
            // 
            this.checkUpdatesTSMI.Name = "checkUpdatesTSMI";
            this.checkUpdatesTSMI.Size = new System.Drawing.Size(218, 22);
            this.checkUpdatesTSMI.Text = "Comprobar actualizaciones";
            this.checkUpdatesTSMI.Click += new System.EventHandler(this.checkUpdatesTSMI_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(598, 333);
            this.Controls.Add(this.sitemapUrlTB);
            this.Controls.Add(this.sitemapUrlCB);
            this.Controls.Add(this.sitemapUrlL);
            this.Controls.Add(this.sitemapContentGB);
            this.Controls.Add(this.sitemapListAddFileB);
            this.Controls.Add(this.sitemapListRemoveSelectedB);
            this.Controls.Add(this.sitemapPagesL);
            this.Controls.Add(this.sitemapPagesLB);
            this.Controls.Add(this.sitemapDirectoryB);
            this.Controls.Add(this.sitemapDirectoryTB);
            this.Controls.Add(this.menuS);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuS;
            this.Name = "Form1";
            this.Text = "Generador de Sitemaps";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuS.ResumeLayout(false);
            this.menuS.PerformLayout();
            this.sitemapContentGB.ResumeLayout(false);
            this.sitemapContentGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sitemapPriorityNUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (paths.Length > 0)
            {
                foreach (var path in paths)
                    SitemapUpdater.XMLUpdate(path);
                this.Close();
            }

            this.FirstTimeSetup();
            this.sitemapDirectoryTB.Text = Directory.GetCurrentDirectory();
            this.GenerateSitemap();
            string[] strArray = File.ReadAllLines(this.sgfolder + "\\sige.preferences");
            if (strArray[0] == "True")
            {
                this.includeSubdirs = true;
                this.includeSubdirsTSMI.Checked = true;
            }
            if (strArray[1] == "spanish")
                this.spanishTSMI.Checked = true;
            else if (strArray[1] == "english")
                this.englishTSMI.Checked = true;
            else if (strArray[1] == "other")
                this.languageCustomTSMI.Checked = true;
            this.AllControlsSetup();
            this.ToggleLanguage();
            this.SavePreferences();
        }

        private void FirstTimeSetup()
        {
            Directory.CreateDirectory(this.sgfolder);
            string contents1 = "<strings>\r\n<string name=\"Form1\">Generador de Sitemaps</string>\r\n<string name=\"sitemapTSMI\">Sitemap</string>\r\n<string name=\"saveTSMI\">Guardar</string>\r\n<string name=\"saveAsTSMI\">Guardar cómo...</string>\r\n<string name=\"updateTSMI\">Actualizar sitemap</string>\r\n<string name=\"xmlViewerTSMI\">Visor XML</string>\r\n<string name=\"optionsTSMI\">Opciones</string>\r\n<string name=\"includeSubdirsTSMI\">Incluir subdirectorios al elegir directorio</string>\r\n<string name=\"languageTSMI\">Lenguaje</string>\r\n<string name=\"spanishTSMI\">Español</string>\r\n<string name=\"englishTSMI\">Inglés</string>\r\n<string name=\"languageCustomTSMI\">Elegir personalizado</string>\r\n<string name=\"helpTSMI\">Ayuda</string>\r\n<string name=\"supportTSMI\">Soporte</string>\r\n<string name=\"helpPopTSMI\">Ayuda</string>\r\n<string name=\"exitTSMI\">Salir</string>\r\n<string name=\"sitemapPagesL\">Páginas a añadir:</string>\r\n<string name=\"sitemapDateL\">Fecha de última actualización:</string>\r\n<string name=\"sitemapChangeFreqL\">¿Frecuencia de cambio?</string>\r\n<string name=\"sitemapPriorityL\">¿Prioridad?</string>\r\n<string name=\"sitemapUrlL\">Especifica la URL de tu página web:</string>\r\n<string name=\"sitemapListRemoveSelectedB\">Eliminar página(s) seleccionada(s)</string>\r\n<string name=\"sitemapListAddFileB\">Añadir página(s) manualmente</string>\r\n<string name=\"sitemapDirectoryB\">Elegir directorio del cual generar sitemap</string>\r\n<string name=\"generationTypeRB\">Generación global (el contenido afecta a todas las URL por igual)</string>\r\n<string name=\"sitemapContentGB\">Contenido del sitemap</string>\r\n<string name=\"help_Help\">Ayuda</string>\r\n<string name=\"help_label1\">(1) Indica la ruta de la carpeta. Si presiona enter en esta caja de texto, o elije un directorio que conetnga los archivos\r\nde la página, automáticamenete se cargará en el elemento 2\r\n(2) En esta lista se muestran las páginas listas para ser añadidas al generar el sitemap.\r\n...Puede seleccionar una, y pulsando en (3), eliminarla...\r\n...O puede pulsar en (4) para añadir archivos manualmente (que no sean necesariamente .html, .htm, .php o .ajax)\r\n(5) Puede elejir la fecha con la que se generará el Sitemap\r\n(6) Indica que frecuencia de cambio se ajustará en el Sitemap\r\n(7) Prioridad de las páginas dentro del sitemap\r\n(8) Indica si los cambios efectuados en Contenido del Sitemap afectarán a todo o solo a la página seleccionada.\r\nDe momento hay una única opción.\r\n\r\nPara guardar el Sitemap, desde el menú, vaya a Sitemap > Guardar para guardarlo si ya se ha especificado una ruta\r\nde guardado antes, o Guardar cómo... si es la primera vez.\r\n\r\nEn la sección de Ayuda, Soporte, accederá a la página oficial de soporte de esta aplicación. En ayuda, se abrirá esta\r\nventana.\r\n\r\nSi hace clic en salir, la aplicación se cerrará. No avisará de guardar cambios. Creado por Lonami (http://lonamiwebs.github.io)</string>\r\n<string name=\"update_SitemapUpdater\">Actualizar sitemap</string>\r\n<string name=\"update_pickDocB\">Elegir sitemap</string>\r\n<string name=\"update_cancelB\">Cancelar</string>\r\n<string name=\"viewer_XMLViewer\">Visor XML</string>\r\n<string name=\"viewer_pickDoc\">Elegir documento</string>\r\n<string name=\"viewer_acceptB\">Aceptar</string>\r\n<string name=\"messagebox_pickxml_t\">Elija un documento XML válido</string>\r\n<string name=\"messagebox_pickxml_f\">Documento XML|*.xml</string>\r\n<string name=\"messagebox_update\">El sitemap se ha actualizado correctamente a la fecha de hoy\nLa etiqueta lastmod de este ahora vale </string>\r\n<string name=\"messagebox_invaliddir_c\">Se ha elegido un directorio no válido. Por favor introduzca la ruta de otro directorio válido antes de generar la lista.</string>\r\n<string name=\"messagebox_invaliddir_t\">Directorio inválido</string>\r\n<string name=\"messagebox_listempty_c\">La lista no puede estar vacía. Asegurese de especificar un directorio y generarla o añade los archivos manualmente</string>\r\n<string name=\"messagebox_listempty_t\">Lista vacía</string>\r\n<string name=\"messagebox_openxml_f\">Todos los permitidos|*.php;*.html;*.htm;*.ajax|Archivos PHP|*.php|Archivos HTML|*.html;*.htm|Archivos AJAX|*.ajax|Todos los archivos|*</string>\r\n<string name=\"messagebox_save_c\">Elija un directorio donde guardar el sitemap.xml actual</string>\r\n<string name=\"messagebox_save_f\">Archivo XML|*.xml</string>\r\n<string name=\"messagebox_close_c\">Ha habido cambios en el sitemap,\r\npero estos no se han guardado todavía\r\n¿Desea guardarlos ahora el sitemap? </string>\r\n<string name=\"messagebox_close_t\">Cambios hechos en el sitemap</string>\r\n</strings>";
            string contents2 = "<strings>\r\n<string name=\"Form1\">Sitemap Generator</string>\r\n<string name=\"sitemapTSMI\">Sitemap</string>\r\n<string name=\"saveTSMI\">Save</string>\r\n<string name=\"saveAsTSMI\">Save as...</string>\r\n<string name=\"updateTSMI\">Update sitemap</string>\r\n<string name=\"xmlViewerTSMI\">XML viewer</string>\r\n<string name=\"optionsTSMI\">Options</string>\r\n<string name=\"includeSubdirsTSMI\">Include subdirectories on directory pick</string>\r\n<string name=\"languageTSMI\">Language</string>\r\n<string name=\"spanishTSMI\">Spanish</string>\r\n<string name=\"englishTSMI\">English</string>\r\n<string name=\"languageCustomTSMI\">Pick custom</string>\r\n<string name=\"helpTSMI\">Help</string>\r\n<string name=\"supportTSMI\">Support</string>\r\n<string name=\"helpPopTSMI\">Help</string>\r\n<string name=\"exitTSMI\">Exit</string>\r\n<string name=\"sitemapPagesL\">Pages to add:</string>\r\n<string name=\"sitemapDateL\">Last modification date:</string>\r\n<string name=\"sitemapChangeFreqL\">Change frequency?</string>\r\n<string name=\"sitemapPriorityL\">Priority?</string>\r\n<string name=\"sitemapUrlL\">Specify your website URL:</string>\r\n<string name=\"sitemapListRemoveSelectedB\">Remove selected page(s)</string>\r\n<string name=\"sitemapListAddFileB\">Add page(s) manually</string>\r\n<string name=\"sitemapDirectoryB\">Pick dir from which generate sitemap</string>\r\n<string name=\"generationTypeRB\">Global generation (content affect all URLs same way)</string>\r\n<string name=\"sitemapContentGB\">Sitemap content</string>\r\n<string name=\"help_Help\">Help</string>\r\n<string name=\"help_label1\">(1) Specify folder path. If enter key is pressed inside this text box, or you do pick a directory which contains the page\r\nfiles, these will be automatly loaded in the element 2\r\n(2) In this list are shown the pages to be added on the sitemap.xml generation\r\n...You can pick one (or multiple) and by pressing (3) (or Del/Back key), you can remove it...\r\n...Or you can press (4) to add files manually (not necessary .html, .htm, .php or .ajax)\r\n(5) You can pick the date which the sitemap will be generated with\r\n(6) Specify sitemap change frequency which will be generated with\r\n(7) Pages priority inside sitemap generation\r\n(8) Specify is changes made in Sitemap Content will affect all pages or only selected.\r\nAvailable only one option at the moment.\r\n\r\nTo save this Sitemap, from the menu, go to Sitemap > Save if you already have specified a save path before or Save as...\r\nif it is the first time.\r\n\r\nIn Help section, Support will open the official support web site page of this application. In help, this window will be \r\nopen.\r\n\r\nIf you click on close, the application will be close. It won't prompt to save changes. Made by Lonami (http://lonamiwebs.github.io)</string>\r\n<string name=\"update_SitemapUpdater\">Update sitemap</string>\r\n<string name=\"update_pickDocB\">Pick sitemap</string>\r\n<string name=\"update_cancelB\">Cancel</string>\r\n<string name=\"viewer_XMLViewer\">XML Viewer</string>\r\n<string name=\"viewer_pickDoc\">Pick document</string>\r\n<string name=\"viewer_acceptB\">Accept</string>\r\n<string name=\"messagebox_pickxml_t\">Pick a valid XML document</string>\r\n<string name=\"messagebox_pickxml_f\">XML Document|*.xml</string>\r\n<string name=\"messagebox_update\">Sitemap has been updated to today's date.\nlastmod tags of this contains now </string>\r\n<string name=\"messagebox_invaliddir_c\">You have specified a non-valid directory. Please enter another valid one before generating the list.</string>\r\n<string name=\"messagebox_invaliddir_t\">Invalid directory</string>\r\n<string name=\"messagebox_listempty_c\">The list cannot be empty. Make sure to specify a directory and generate it or add the files manually</string>\r\n<string name=\"messagebox_listempty_t\">Empty list</string>\r\n<string name=\"messagebox_openxml_f\">All files allowed|*.php;*.html;*.htm;*.ajax|PHP files|*.php|HTML files|*.html;*.htm|AJAX files|*.ajax|All file types|*</string>\r\n<string name=\"messagebox_save_c\">Pick a directory to save current sitemap.xml in</string>\r\n<string name=\"messagebox_save_f\">XML file|*.xml</string>\r\n<string name=\"messagebox_close_c\">Changes have been made to sitemap,\r\nbut these hasn't been save yet\r\nDo you wish to save sitemap now? </string>\r\n<string name=\"messagebox_close_t\">Changes made to sitemap</string>\r\n</strings>";
            if (!File.Exists(this.sgfolder + "\\sige.es.language"))
                File.WriteAllText(this.sgfolder + "\\sige.es.language", contents1);
            if (!File.Exists(this.sgfolder + "\\sige.en.language"))
                File.WriteAllText(this.sgfolder + "\\sige.en.language", contents2);
            if (File.Exists(this.sgfolder + "\\sige.preferences"))
                return;
            if (CultureInfo.CurrentCulture.EnglishName.ToLower().Contains("spanish"))
                this.spanishTSMI.Checked = true;
            else if (CultureInfo.CurrentCulture.EnglishName.ToLower().Contains("english"))
                this.englishTSMI.Checked = true;
            this.SavePreferences();
            this.ToggleLanguage();
        }

        private void SavePreferences()
        {
            string path = this.sgfolder + "\\sige.preferences";
            string str = "unknown";
            if (this.spanishTSMI.Checked)
                str = "spanish";
            else if (this.englishTSMI.Checked)
                str = "english";
            else if (this.languageCustomTSMI.Checked)
                str = "other";
            string contents = includeSubdirsTSMI.Checked ? "1" : 0 + "\r\n" + str;
            File.Delete(path);
            File.WriteAllText(path, contents);
        }

        private void sitemapDirectoryTB_Click(object sender, EventArgs e)
        {
            this.sitemapDirectoryTB.SelectAll();
        }

        private void sitemapDirectoryB_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
                return;
            this.sitemapDirectoryTB.Text = folderBrowserDialog.SelectedPath;
            this.GenerateSitemap();
        }

        private void sitemapDirectoryTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Return)
                return;
            e.Handled = true;
            e.SuppressKeyPress = true;
            this.GenerateSitemap();
        }

        private void sitemapGenerateB_Click(object sender, EventArgs e)
        {
            this.GenerateSitemap();
        }

        private void GenerateSitemap()
        {
            try
            {
                this.fp_files.Clear();
                this.sn_files.Clear();
                string text = this.sitemapDirectoryTB.Text;
                string[] files1 = Directory.GetFiles(text);
                string[] directories = Directory.GetDirectories(text);
                for (int index = 0; index < files1.Length; ++index)
                {
                    if (files1[index].Contains(".php") || files1[index].Contains(".htm") || files1[index].Contains(".ajax"))
                    {
                        this.fp_files.Add(files1[index]);
                        this.sn_files.Add(Path.GetFileName(files1[index]));
                        this.saved = false;
                    }
                }
                if (this.includeSubdirs)
                {
                    foreach (string path in directories)
                    {
                        string[] files2 = Directory.GetFiles(path);
                        string name = new DirectoryInfo(path).Name;
                        for (int index = 0; index < files2.Length; ++index)
                        {
                            if (files2[index].Contains(".php") || files2[index].Contains(".htm") || files2[index].Contains(".ajax"))
                            {
                                this.fp_files.Add(files2[index]);
                                this.sn_files.Add(name + "/" + Path.GetFileName(files2[index]));
                            }
                        }
                    }
                }
                this.sitemapPagesLB.Items.AddRange((object[])this.sn_files.ToArray());
            }
            catch { }
        }

        private void sitemapListRemoveSelectedB_Click(object sender, EventArgs e)
        {
            this.RemoveSelected();
        }

        private void RemoveSelected()
        {
            if (this.fp_files.Count != 0)
            {
                int selectedIndex = this.sitemapPagesLB.SelectedIndex;
                this.fp_files.RemoveRange(this.sitemapPagesLB.SelectedIndex, this.sitemapPagesLB.SelectedItems.Count);
                this.sn_files.RemoveRange(this.sitemapPagesLB.SelectedIndex, this.sitemapPagesLB.SelectedItems.Count);
                this.sitemapPagesLB.Items.Clear();
                this.sitemapPagesLB.Items.AddRange((object[])this.sn_files.ToArray());
                try
                {
                    this.sitemapPagesLB.SelectedIndex = selectedIndex;
                }
                catch { }
                this.saved = false;
            }
            else
            {
                int num = (int)MessageBox.Show(this.value[this.name.IndexOf("messagebox_listempty_c")], this.value[this.name.IndexOf("messagebox_listempty_t")], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void sitemapListAddFileB_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = this.value[this.name.IndexOf("messagebox_openxml_f")];
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;
            this.sitemapPagesLB.Items.Clear();
            this.fp_files.AddRange((IEnumerable<string>)openFileDialog.FileNames);
            foreach (string path in openFileDialog.FileNames)
                this.sn_files.Add(Path.GetFileName(path));
            this.sitemapPagesLB.Items.AddRange((object[])this.sn_files.ToArray());
            this.saved = false;
        }

        private void saveTSMI_Click(object sender, EventArgs e)
        {
            if (this.savePath.Length > 0)
                this.Save(this.savePath);
            else
                this.SaveAs();
        }

        private void saveAsTSMI_Click(object sender, EventArgs e)
        {
            this.SaveAs();
        }

        private void SaveAs()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = this.value[this.name.IndexOf("messagebox_save_c")];
            try
            {
                saveFileDialog.InitialDirectory = this.sitemapDirectoryTB.Text;
            }
            catch { }
            saveFileDialog.FileName = "sitemap.xml";
            saveFileDialog.Filter = this.value[this.name.IndexOf("messagebox_save_f")];
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                this.Save(saveFileDialog.FileName);
            else
                this.saved = false;
        }

        private void Save(string path)
        {
            this.savePath = path;
            this.GenerateXML().Save(path);
            this.saved = true;
        }

        private XDocument GenerateXML()
        {
            List<XElement> list = new List<XElement>();
            for (int index = 0; index < this.sn_files.Count; ++index)
                list.Add(new XElement((XName)"url", new object[4]
        {
          (object) new XElement((XName) "loc", (object) (this.sitemapUrlCB.Text + this.sitemapUrlTB.Text + "/" + this.sn_files[index])),
          (object) new XElement((XName) "lastmod", (object) this.sitemapDateMC.SelectionRange.Start.ToShortDateString().Replace('/', '-')),
          (object) new XElement((XName) "changefreq", (object) this.sitemapChangeFreqCB.Text),
          (object) new XElement((XName) "priority", (object) this.sitemapPriorityNUD.Value.ToString().Replace(',', '.'))
        }));
            return new XDocument(new object[1]
      {
        (object) new XElement((XNamespace) "http://www.sitemaps.org/schemas/sitemap/0.9" + "urlset", (object[]) list.ToArray())
      });
        }

        private void helpPopTSMI_Click(object sender, EventArgs e)
        {
            ((Control)new Help()).Show();
        }

        private void supportTSMI_Click(object sender, EventArgs e)
        {
            Process.Start("http://lonamiwebs.github.io/contacto.htm");
        }

        private void exitTSMI_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void includeSubdirsTSMI_Click(object sender, EventArgs e)
        {
            this.SavePreferences();
            this.includeSubdirs = false;
        }

        private void sitemapPagesLB_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.sitemapPagesLB.SelectedItems.Count <= 1)
                return;
            this.sitemapPagesLB.ClearSelected();
        }

        private void sitemapPagesLB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                this.RemoveSelected();
            if (e.KeyCode != Keys.Back)
                return;
            this.RemoveSelected();
        }

        private void updateTSMI_Click(object sender, EventArgs e)
        {
            ((Control)new SitemapUpdater()).Show();
        }

        private void xmlViewerTSMI_Click(object sender, EventArgs e)
        {
            ((Control)new XMLViewer()).Show();
        }

        private void spanishTSMI_Click(object sender, EventArgs e)
        {
            this.spanishTSMI.Checked = true;
            this.englishTSMI.Checked = false;
            this.languageCustomTSMI.Checked = false;
            this.SavePreferences();
            Process.Start(Application.ExecutablePath);
            Application.Exit();
        }

        private void englishTSMI_Click(object sender, EventArgs e)
        {
            this.spanishTSMI.Checked = false;
            this.englishTSMI.Checked = true;
            this.languageCustomTSMI.Checked = false;
            this.SavePreferences();
            Process.Start(Application.ExecutablePath);
            Application.Exit();
        }

        private void ToggleLanguage()
        {
            XmlDocument xmlDocument = new XmlDocument();
            if (this.spanishTSMI.Checked)
                xmlDocument.Load(this.sgfolder + "\\sige.es.language");
            else if (this.englishTSMI.Checked)
                xmlDocument.Load(this.sgfolder + "\\sige.en.language");
            foreach (XmlElement xmlElement in ((XmlElement)xmlDocument.GetElementsByTagName("strings")[0]).GetElementsByTagName("string"))
            {
                this.name.Add(xmlElement.GetAttribute("name"));
                this.value.Add(xmlElement.InnerText);
            }
            this.Text = this.value[this.name.IndexOf(this.Name)];
            for (int index = 0; index < this.allTSMI.Count; ++index)
                this.allTSMI[index].Text = this.value[this.name.IndexOf(this.allTSMI[index].Name)];
            for (int index = 0; index < this.allB.Count; ++index)
                this.allB[index].Text = this.value[this.name.IndexOf(this.allB[index].Name)];
            for (int index = 0; index < this.allL.Count; ++index)
                this.allL[index].Text = this.value[this.name.IndexOf(this.allL[index].Name)];
            this.generationTypeRB.Text = this.value[this.name.IndexOf(this.generationTypeRB.Name)];
            this.sitemapContentGB.Text = this.value[this.name.IndexOf(this.sitemapContentGB.Name)];
        }

        private void AllControlsSetup()
        {
            this.allTSMI.Add(this.sitemapTSMI);
            this.allTSMI.Add(this.saveTSMI);
            this.allTSMI.Add(this.saveAsTSMI);
            this.allTSMI.Add(this.updateTSMI);
            this.allTSMI.Add(this.xmlViewerTSMI);
            this.allTSMI.Add(this.optionsTSMI);
            this.allTSMI.Add(this.includeSubdirsTSMI);
            this.allTSMI.Add(this.languageTSMI);
            this.allTSMI.Add(this.spanishTSMI);
            this.allTSMI.Add(this.englishTSMI);
            this.allTSMI.Add(this.languageCustomTSMI);
            this.allTSMI.Add(this.helpTSMI);
            this.allTSMI.Add(this.supportTSMI);
            this.allTSMI.Add(this.helpPopTSMI);
            this.allTSMI.Add(this.exitTSMI);
            this.allL.Add(this.sitemapPagesL);
            this.allL.Add(this.sitemapDateL);
            this.allL.Add(this.sitemapChangeFreqL);
            this.allL.Add(this.sitemapPriorityL);
            this.allL.Add(this.sitemapUrlL);
            this.allB.Add(this.sitemapListRemoveSelectedB);
            this.allB.Add(this.sitemapListAddFileB);
            this.allB.Add(this.sitemapDirectoryB);
        }

        private void languageCustomTSMI_Click(object sender, EventArgs e)
        {
            int num = (int)MessageBox.Show("Not available yet!");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.saved || MessageBox.Show(this.value[this.name.IndexOf("messagebox_close_c")], this.value[this.name.IndexOf("messagebox_close_t")], MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.OK)
                return;
            if (this.savePath.Length > 0)
                this.Save(this.savePath);
            else
                this.SaveAs();
        }

        private void checkUpdatesTSMI_Click(object sender, EventArgs e)
        {
            new UpdateChecker.UpdateChecker(System.Reflection.Assembly.GetExecutingAssembly().Location, "sige").Show();
        }
    }
}