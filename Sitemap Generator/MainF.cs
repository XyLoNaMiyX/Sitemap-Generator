using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Diagnostics;

namespace Sitemap_Generator
{
    public partial class MainF : Form
    {
        public MainF(string path)
        {
            InitializeComponent();
            updatePath = path;
        }

        static public string updatePath;

        //fp = full path; sn = single name
        List<string> fp_files = new List<string>();
        List<string> sn_files = new List<string>();

        string savePath = "";

        string sgfolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
            + @"\LonamiWebs\Sitemap Generator";

        List<string> name = new List<string>();
        List<string> value = new List<string>();

        bool includeSubdirs = true;

        bool saved = true;

        private void Form1_Load(object sender, EventArgs e)
        {
            if (updatePath != string.Empty)
            {
                try
                {
                    new SitemapUpdater().Show();
                }
                catch (Exception ex) { }
                this.Close();
            }

            FirstTimeSetup();

            sitemapDirectoryTB.Text = Directory.GetCurrentDirectory();
            GenerateSitemap();

            string[] prefFile = File.ReadAllLines(sgfolder + @"\sige.preferences");

            if (prefFile[0] == "True")
            {
                includeSubdirs = true;
                includeSubdirsTSMI.Checked = true;
            }

            if (prefFile[1] == "spanish")
                spanishTSMI.Checked = true;
            else if (prefFile[1] == "english")
                englishTSMI.Checked = true;
            else if (prefFile[1] == "other")
                languageCustomTSMI.Checked = true;

            AllControlsSetup();

            ToggleLanguage();

            SavePreferences();
        }

        private void FirstTimeSetup()
        {
            Directory.CreateDirectory(sgfolder);

            string spanish = "<strings>\r\n<string name=\"Form1\">Generador de Sitemaps</string>\r\n<string name=\"sitemapTSMI\">Sitemap</string>\r\n<string name=\"saveTSMI\">Guardar</string>\r\n<string name=\"saveAsTSMI\">Guardar cómo...</string>\r\n<string name=\"updateTSMI\">Actualizar sitemap</string>\r\n<string name=\"xmlViewerTSMI\">Visor XML</string>\r\n<string name=\"optionsTSMI\">Opciones</string>\r\n<string name=\"includeSubdirsTSMI\">Incluir subdirectorios al elegir directorio</string>\r\n<string name=\"languageTSMI\">Lenguaje</string>\r\n<string name=\"spanishTSMI\">Español</string>\r\n<string name=\"englishTSMI\">Inglés</string>\r\n<string name=\"languageCustomTSMI\">Elegir personalizado</string>\r\n<string name=\"helpTSMI\">Ayuda</string>\r\n<string name=\"supportTSMI\">Soporte</string>\r\n<string name=\"helpPopTSMI\">Ayuda</string>\r\n<string name=\"exitTSMI\">Salir</string>\r\n<string name=\"sitemapPagesL\">Páginas a añadir:</string>\r\n<string name=\"sitemapDateL\">Fecha de última actualización:</string>\r\n<string name=\"sitemapChangeFreqL\">¿Frecuencia de cambio?</string>\r\n<string name=\"sitemapPriorityL\">¿Prioridad?</string>\r\n<string name=\"sitemapUrlL\">Especifica la URL de tu página web:</string>\r\n<string name=\"sitemapListRemoveSelectedB\">Eliminar página(s) seleccionada(s)</string>\r\n<string name=\"sitemapListAddFileB\">Añadir página(s) manualmente</string>\r\n<string name=\"sitemapDirectoryB\">Elegir directorio del cual generar sitemap</string>\r\n<string name=\"generationTypeRB\">Generación global (el contenido afecta a todas las URL por igual)</string>\r\n<string name=\"sitemapContentGB\">Contenido del sitemap</string>\r\n<string name=\"help_Help\">Ayuda</string>\r\n<string name=\"help_label1\">(1) Indica la ruta de la carpeta. Si presiona enter en esta caja de texto, o elije un directorio que conetnga los archivos\r\nde la página, automáticamenete se cargará en el elemento 2\r\n(2) En esta lista se muestran las páginas listas para ser añadidas al generar el sitemap.\r\n...Puede seleccionar una, y pulsando en (3), eliminarla...\r\n...O puede pulsar en (4) para añadir archivos manualmente (que no sean necesariamente .html, .htm, .php o .ajax)\r\n(5) Puede elejir la fecha con la que se generará el Sitemap\r\n(6) Indica que frecuencia de cambio se ajustará en el Sitemap\r\n(7) Prioridad de las páginas dentro del sitemap\r\n(8) Indica si los cambios efectuados en Contenido del Sitemap afectarán a todo o solo a la página seleccionada.\r\nDe momento hay una única opción.\r\n\r\nPara guardar el Sitemap, desde el menú, vaya a Sitemap > Guardar para guardarlo si ya se ha especificado una ruta\r\nde guardado antes, o Guardar cómo... si es la primera vez.\r\n\r\nEn la sección de Ayuda, Soporte, accederá a la página oficial de soporte de esta aplicación. En ayuda, se abrirá esta\r\nventana.\r\n\r\nSi hace clic en salir, la aplicación se cerrará. No avisará de guardar cambios. Creado por Lonami (http://lonamiwebs.github.io)</string>\r\n<string name=\"update_SitemapUpdater\">Actualizar sitemap</string>\r\n<string name=\"update_pickDocB\">Elegir sitemap</string>\r\n<string name=\"update_cancelB\">Cancelar</string>\r\n<string name=\"viewer_XMLViewer\">Visor XML</string>\r\n<string name=\"viewer_pickDoc\">Elegir documento</string>\r\n<string name=\"viewer_acceptB\">Aceptar</string>\r\n<string name=\"messagebox_pickxml_t\">Elija un documento XML válido</string>\r\n<string name=\"messagebox_pickxml_f\">Documento XML|*.xml</string>\r\n<string name=\"messagebox_update\">El sitemap se ha actualizado correctamente a la fecha de hoy\nLa etiqueta lastmod de este ahora vale </string>\r\n<string name=\"messagebox_invaliddir_c\">Se ha elegido un directorio no válido. Por favor introduzca la ruta de otro directorio válido antes de generar la lista.</string>\r\n<string name=\"messagebox_invaliddir_t\">Directorio inválido</string>\r\n<string name=\"messagebox_listempty_c\">La lista no puede estar vacía. Asegurese de especificar un directorio y generarla o añade los archivos manualmente</string>\r\n<string name=\"messagebox_listempty_t\">Lista vacía</string>\r\n<string name=\"messagebox_openxml_f\">Todos los permitidos|*.php;*.html;*.htm;*.ajax|Archivos PHP|*.php|Archivos HTML|*.html;*.htm|Archivos AJAX|*.ajax|Todos los archivos|*</string>\r\n<string name=\"messagebox_save_c\">Elija un directorio donde guardar el sitemap.xml actual</string>\r\n<string name=\"messagebox_save_f\">Archivo XML|*.xml</string>\r\n<string name=\"messagebox_close_c\">Ha habido cambios en el sitemap,\r\npero estos no se han guardado todavía\r\n¿Desea guardarlos ahora el sitemap? </string>\r\n<string name=\"messagebox_close_t\">Cambios hechos en el sitemap</string>\r\n</strings>";
            string english = "<strings>\r\n<string name=\"Form1\">Sitemap Generator</string>\r\n<string name=\"sitemapTSMI\">Sitemap</string>\r\n<string name=\"saveTSMI\">Save</string>\r\n<string name=\"saveAsTSMI\">Save as...</string>\r\n<string name=\"updateTSMI\">Update sitemap</string>\r\n<string name=\"xmlViewerTSMI\">XML viewer</string>\r\n<string name=\"optionsTSMI\">Options</string>\r\n<string name=\"includeSubdirsTSMI\">Include subdirectories on directory pick</string>\r\n<string name=\"languageTSMI\">Language</string>\r\n<string name=\"spanishTSMI\">Spanish</string>\r\n<string name=\"englishTSMI\">English</string>\r\n<string name=\"languageCustomTSMI\">Pick custom</string>\r\n<string name=\"helpTSMI\">Help</string>\r\n<string name=\"supportTSMI\">Support</string>\r\n<string name=\"helpPopTSMI\">Help</string>\r\n<string name=\"exitTSMI\">Exit</string>\r\n<string name=\"sitemapPagesL\">Pages to add:</string>\r\n<string name=\"sitemapDateL\">Last modification date:</string>\r\n<string name=\"sitemapChangeFreqL\">Change frequency?</string>\r\n<string name=\"sitemapPriorityL\">Priority?</string>\r\n<string name=\"sitemapUrlL\">Specify your website URL:</string>\r\n<string name=\"sitemapListRemoveSelectedB\">Remove selected page(s)</string>\r\n<string name=\"sitemapListAddFileB\">Add page(s) manually</string>\r\n<string name=\"sitemapDirectoryB\">Pick dir from which generate sitemap</string>\r\n<string name=\"generationTypeRB\">Global generation (content affect all URLs same way)</string>\r\n<string name=\"sitemapContentGB\">Sitemap content</string>\r\n<string name=\"help_Help\">Help</string>\r\n<string name=\"help_label1\">(1) Specify folder path. If enter key is pressed inside this text box, or you do pick a directory which contains the page\r\nfiles, these will be automatly loaded in the element 2\r\n(2) In this list are shown the pages to be added on the sitemap.xml generation\r\n...You can pick one (or multiple) and by pressing (3) (or Del/Back key), you can remove it...\r\n...Or you can press (4) to add files manually (not necessary .html, .htm, .php or .ajax)\r\n(5) You can pick the date which the sitemap will be generated with\r\n(6) Specify sitemap change frequency which will be generated with\r\n(7) Pages priority inside sitemap generation\r\n(8) Specify is changes made in Sitemap Content will affect all pages or only selected.\r\nAvailable only one option at the moment.\r\n\r\nTo save this Sitemap, from the menu, go to Sitemap > Save if you already have specified a save path before or Save as...\r\nif it is the first time.\r\n\r\nIn Help section, Support will open the official support web site page of this application. In help, this window will be \r\nopen.\r\n\r\nIf you click on close, the application will be close. It won't prompt to save changes. Made by Lonami (http://lonamiwebs.github.io)</string>\r\n<string name=\"update_SitemapUpdater\">Update sitemap</string>\r\n<string name=\"update_pickDocB\">Pick sitemap</string>\r\n<string name=\"update_cancelB\">Cancel</string>\r\n<string name=\"viewer_XMLViewer\">XML Viewer</string>\r\n<string name=\"viewer_pickDoc\">Pick document</string>\r\n<string name=\"viewer_acceptB\">Accept</string>\r\n<string name=\"messagebox_pickxml_t\">Pick a valid XML document</string>\r\n<string name=\"messagebox_pickxml_f\">XML Document|*.xml</string>\r\n<string name=\"messagebox_update\">Sitemap has been updated to today's date.\nlastmod tags of this contains now </string>\r\n<string name=\"messagebox_invaliddir_c\">You have specified a non-valid directory. Please enter another valid one before generating the list.</string>\r\n<string name=\"messagebox_invaliddir_t\">Invalid directory</string>\r\n<string name=\"messagebox_listempty_c\">The list cannot be empty. Make sure to specify a directory and generate it or add the files manually</string>\r\n<string name=\"messagebox_listempty_t\">Empty list</string>\r\n<string name=\"messagebox_openxml_f\">All files allowed|*.php;*.html;*.htm;*.ajax|PHP files|*.php|HTML files|*.html;*.htm|AJAX files|*.ajax|All file types|*</string>\r\n<string name=\"messagebox_save_c\">Pick a directory to save current sitemap.xml in</string>\r\n<string name=\"messagebox_save_f\">XML file|*.xml</string>\r\n<string name=\"messagebox_close_c\">Changes have been made to sitemap,\r\nbut these hasn't been save yet\r\nDo you wish to save sitemap now? </string>\r\n<string name=\"messagebox_close_t\">Changes made to sitemap</string>\r\n</strings>";
            
            if (!File.Exists(sgfolder + @"\sige.es.language"))
                File.WriteAllText(sgfolder + @"\sige.es.language", spanish);
            if (!File.Exists(sgfolder + @"\sige.en.language"))
                File.WriteAllText(sgfolder + @"\sige.en.language", english);

            if (!File.Exists(sgfolder + @"\sige.preferences"))
            {
                if (System.Globalization.CultureInfo.CurrentCulture.EnglishName.ToLower().Contains("spanish"))
                    spanishTSMI.Checked = true;
                else if (System.Globalization.CultureInfo.CurrentCulture.EnglishName.ToLower().Contains("english"))
                    englishTSMI.Checked = true;

                SavePreferences();
                ToggleLanguage();
            }
        }

        private void SavePreferences()
        {
            string saveto = sgfolder + @"\sige.preferences";
            string language = "unknown";
            if (spanishTSMI.Checked == true)
                language = "spanish";
            else if (englishTSMI.Checked == true)
                language = "english";
            else if (languageCustomTSMI.Checked == true)
                language = "other";

            string prefs = includeSubdirsTSMI.Checked + "\r\n" + language;

            File.Delete(saveto);
            File.WriteAllText(saveto, prefs);
        }

        private void sitemapDirectoryTB_Click(object sender, EventArgs e)
        {
            sitemapDirectoryTB.SelectAll();
        }

        private void sitemapDirectoryB_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult dr = fbd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                sitemapDirectoryTB.Text = fbd.SelectedPath;
                GenerateSitemap();
            }
        }

        private void sitemapDirectoryTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                GenerateSitemap();
            }
        }

        private void sitemapGenerateB_Click(object sender, EventArgs e)
        {
            GenerateSitemap();
        }

        private void GenerateSitemap()
        {
            try
            {
                fp_files.Clear();
                sn_files.Clear();

                string dir = sitemapDirectoryTB.Text;
                string[] files = Directory.GetFiles(dir);
                string[] dirs = Directory.GetDirectories(dir);

                for (int i = 0; i < files.Length; i++)
                    if (files[i].Contains(".php") || files[i].Contains(".htm") || files[i].Contains(".ajax"))
                    {
                        fp_files.Add(files[i]);
                        sn_files.Add(Path.GetFileName(files[i]));

                        saved = false;
                    }

                if (includeSubdirs)
                    foreach (string d in dirs)
                    {
                        string[] dirfiles = Directory.GetFiles(d);
                        string dirname = new DirectoryInfo(d).Name;
                        for (int i = 0; i < dirfiles.Length; i++)
                            if (dirfiles[i].Contains(".php") || dirfiles[i].Contains(".htm") || dirfiles[i].Contains(".ajax"))
                            {
                                fp_files.Add(dirfiles[i]);
                                sn_files.Add(dirname + @"/" + Path.GetFileName(dirfiles[i]));
                            }
                    }

                sitemapPagesLB.Items.AddRange(sn_files.ToArray());
            }
            catch (Exception ex)
            {


                MessageBox.Show(value[name.IndexOf("messagebox_invaliddir_c")],
                    value[name.IndexOf("messagebox_invaliddir_t")], MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void sitemapListRemoveSelectedB_Click(object sender, EventArgs e)
        {
            RemoveSelected();
        }

        private void RemoveSelected()
        {
            if (fp_files.Count != 0)
            {
                int i = sitemapPagesLB.SelectedIndex;

                fp_files.RemoveRange(sitemapPagesLB.SelectedIndex, sitemapPagesLB.SelectedItems.Count);
                sn_files.RemoveRange(sitemapPagesLB.SelectedIndex, sitemapPagesLB.SelectedItems.Count);
                sitemapPagesLB.Items.Clear();
                sitemapPagesLB.Items.AddRange(sn_files.ToArray());

                try { sitemapPagesLB.SelectedIndex = i; }
                catch (Exception ex) { }

                saved = false;
            }
            else
            {
                MessageBox.Show(value[name.IndexOf("messagebox_listempty_c")],
                    value[name.IndexOf("messagebox_listempty_t")], MessageBoxButtons.OK, MessageBoxIcon.Warning);

                string r = "&lgt";
            }
        }

        private void sitemapListAddFileB_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = value[name.IndexOf("messagebox_openxml_f")];
            ofd.Multiselect = true;
            DialogResult r = ofd.ShowDialog();
            if (r == DialogResult.OK)
            {
                sitemapPagesLB.Items.Clear();

                fp_files.AddRange(ofd.FileNames);
                foreach (string f in ofd.FileNames)
                    sn_files.Add(Path.GetFileName(f));

                sitemapPagesLB.Items.AddRange(sn_files.ToArray());

                saved = false;
            }
        }

        private void saveTSMI_Click(object sender, EventArgs e)
        {
            if (savePath.Length > 0)
                Save(savePath);
            else
                SaveAs();
        }

        private void saveAsTSMI_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

        private void SaveAs()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = value[name.IndexOf("messagebox_save_c")];
            try
            {
                sfd.InitialDirectory = sitemapDirectoryTB.Text;
            }
            catch (Exception ex) { }
            sfd.FileName = "sitemap.xml";
            sfd.Filter = value[name.IndexOf("messagebox_save_f")];

            DialogResult r = sfd.ShowDialog();
            if (r == DialogResult.OK)
                Save(sfd.FileName);
            else
                saved = false;
        }

        private void Save(string path)
        {
            savePath = path;
            GenerateXML().Save(path);
            saved = true;
        }

        private XDocument GenerateXML()
        {
            //More about this at http://stackoverflow.com/questions/11492705/how-to-create-xml-document-using-xmldocument

            List<XElement> url = new List<XElement>();

            for (int i = 0; i < sn_files.Count; i++)
                url.Add(new XElement("url",
                        new XElement("loc", sitemapUrlCB.Text + sitemapUrlTB.Text + "/" + sn_files[i]),
                        new XElement("lastmod", sitemapDateMC.SelectionRange.Start.ToShortDateString().Replace('/', '-')),
                        new XElement("changefreq", sitemapChangeFreqCB.Text),
                        new XElement("priority", sitemapPriorityNUD.Value.ToString().Replace(',', '.'))));

            //Tengo la lista. FUNCIONA

            XNamespace ns = "http://www.sitemaps.org/schemas/sitemap/0.9";
            XElement urlset = new XElement(ns + "urlset",
                url.ToArray());
            

            //Esto funciona bien. Con una sola url. Bravo.
            /*XNamespace ns = "http://www.sitemaps.org/schemas/sitemap/0.9";
            XElement urlset = new XElement(ns + "urlset",
                new XElement("url", 
                    new XElement("loc", "LEER TODA LA LISTA"),
                    new XElement("lastmod", "GET SITEMAPDATEMC"),
                    new XElement("changefreq", sitemapChangeFreqCB.Text),
                    new XElement("priority", sitemapPriorityNUD.Value.ToString())));*/

            XDocument xDoc = new XDocument(urlset);

            return xDoc;
        }

        private void helpPopTSMI_Click(object sender, EventArgs e)
        {
            new Help().Show();
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
            SavePreferences();
            includeSubdirs = false;
        }

        private void sitemapPagesLB_MouseDown(object sender, MouseEventArgs e)
        {
            if (sitemapPagesLB.SelectedItems.Count > 1)
                sitemapPagesLB.ClearSelected();
        }

        private void sitemapPagesLB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                RemoveSelected();
            if (e.KeyCode == Keys.Back)
                RemoveSelected();
        }

        private void updateTSMI_Click(object sender, EventArgs e)
        {
            new SitemapUpdater().Show();
        }

        private void xmlViewerTSMI_Click(object sender, EventArgs e)
        {
            new XMLViewer().Show();
        }

        #region LANGUAGE

        List<ToolStripMenuItem> allTSMI = new List<ToolStripMenuItem>();
        List<Button> allB = new List<Button>();
        List<Label> allL = new List<Label>();

        private void spanishTSMI_Click(object sender, EventArgs e)
        {
            spanishTSMI.Checked = true;
            englishTSMI.Checked = false;
            languageCustomTSMI.Checked = false;

            SavePreferences();

            System.Diagnostics.Process.Start(Application.ExecutablePath);
            Application.Exit();
        }

        private void englishTSMI_Click(object sender, EventArgs e)
        {
            spanishTSMI.Checked = false;
            englishTSMI.Checked = true;
            languageCustomTSMI.Checked = false;

            SavePreferences();

            System.Diagnostics.Process.Start(Application.ExecutablePath);
            Application.Exit();
        }
        private void ToggleLanguage()
        {
            XmlDocument xdoc = new XmlDocument();

            if (spanishTSMI.Checked)
                xdoc.Load(sgfolder + @"\sige.es.language");
            else if (englishTSMI.Checked)
                xdoc.Load(sgfolder + @"\sige.en.language");

            XmlNodeList strings = xdoc.GetElementsByTagName("strings");
            XmlNodeList lista = ((XmlElement)strings[0]).GetElementsByTagName("string");

            foreach (XmlElement nodo in lista)
            {
                name.Add(nodo.GetAttribute("name"));
                value.Add(nodo.InnerText);
            }

            this.Text = value[name.IndexOf(this.Name)];

            for (int i = 0; i < allTSMI.Count; i++)
                allTSMI[i].Text = value[name.IndexOf(allTSMI[i].Name)];

            for (int i = 0; i < allB.Count; i++)
                allB[i].Text = value[name.IndexOf(allB[i].Name)];

            for (int i = 0; i < allL.Count; i++)
                allL[i].Text = value[name.IndexOf(allL[i].Name)];

            generationTypeRB.Text = value[name.IndexOf(generationTypeRB.Name)];
            sitemapContentGB.Text = value[name.IndexOf(sitemapContentGB.Name)];
        }

        private void AllControlsSetup()
        {
            //Setting up ToolStripMenuItem(s)
            allTSMI.Add(sitemapTSMI);
            allTSMI.Add(saveTSMI);
            allTSMI.Add(saveAsTSMI);
            allTSMI.Add(updateTSMI);
            allTSMI.Add(xmlViewerTSMI);
            allTSMI.Add(optionsTSMI);
            allTSMI.Add(includeSubdirsTSMI);
            allTSMI.Add(languageTSMI);
            allTSMI.Add(spanishTSMI);
            allTSMI.Add(englishTSMI);
            allTSMI.Add(languageCustomTSMI);
            allTSMI.Add(helpTSMI);
            allTSMI.Add(supportTSMI);
            allTSMI.Add(helpPopTSMI);
            allTSMI.Add(exitTSMI);
            
            //Setting up Label(s)
            allL.Add(sitemapPagesL);
            allL.Add(sitemapDateL);
            allL.Add(sitemapChangeFreqL);
            allL.Add(sitemapPriorityL);
            allL.Add(sitemapUrlL);
            
            //Setting up Button(s)
            allB.Add(sitemapListRemoveSelectedB);
            allB.Add(sitemapListAddFileB);
            allB.Add(sitemapDirectoryB);
        }

        #endregion

        private void languageCustomTSMI_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not available yet!");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!saved)
            {

                DialogResult r = MessageBox.Show(value[name.IndexOf("messagebox_close_c")],
                    value[name.IndexOf("messagebox_close_t")], MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (r == DialogResult.OK)
                    if (savePath.Length > 0)
                        Save(savePath);
                    else
                        SaveAs();
            }
        }
    }
}
