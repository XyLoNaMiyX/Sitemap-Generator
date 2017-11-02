using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Xml;
using System.IO;

namespace Sitemap_Generator
{
    public partial class SitemapUpdater : Form
    {
        public SitemapUpdater() {
            InitializeComponent();
        }

        string sgfolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
           + @"\LonamiWebs\Sitemap Generator";

        List<string> name = new List<string>();
        List<string> value = new List<string>();

        private void cancelB_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pickDocB_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = value[name.IndexOf("messagebox_pickxml_t")];
            ofd.Filter = value[name.IndexOf("messagebox_pickxml_f")];
            DialogResult r = ofd.ShowDialog();
            if (r == DialogResult.OK)
            {
                XMLUpdate(ofd.FileName);
                this.Close();
            }
        }

        public static void XMLUpdate(string path)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(path);

            XmlNodeList xnl = xdoc.GetElementsByTagName("lastmod");

            for (int i = 0; i < xnl.Count; i++)
                xnl[i].InnerText = DateTime.Now.ToString("yyyy/MM/dd").Replace('/', '-');

            xdoc.Save(path);

            MessageBox.Show("Sitemap " + path + " updated to today's date: " + DateTime.Now.ToString("yyyy/MM/dd").Replace('/', '-'));
        }

        private void SitemapUpdater_Load(object sender, EventArgs e)
        {
            WinLoad();
        }

        private void WinLoad() {
            XmlDocument xdoc = new XmlDocument();

            string[] prefFile = File.ReadAllLines(sgfolder + @"\sige.preferences");

            if (prefFile[1] == "spanish")
                xdoc.Load(sgfolder + @"\sige.es.language");
            else if (prefFile[1] == "english")
                xdoc.Load(sgfolder + @"\sige.en.language");
            else if (prefFile[1] == "other")
                MessageBox.Show("Other language unavailable");

            XmlNodeList strings = xdoc.GetElementsByTagName("strings");
            XmlNodeList lista = ((XmlElement)strings[0]).GetElementsByTagName("string");

            foreach (XmlElement nodo in lista)
            {
                name.Add(nodo.GetAttribute("name"));
                value.Add(nodo.InnerText);
            }

            this.Text = value[name.IndexOf("update_" + this.Name)];
            pickDocB.Text = value[name.IndexOf("update_" + pickDocB.Name)];
            cancelB.Text = value[name.IndexOf("update_" + cancelB.Name)];
        }

    }
}
