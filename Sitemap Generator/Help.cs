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

namespace Sitemap_Generator
{
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
        }

        string sgfolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
           + @"\LonamiWebs\Sitemap Generator";

        private void Help_Load(object sender, EventArgs e)
        {
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

            List<string> name = new List<string>();
            List<string> value = new List<string>();
            foreach (XmlElement nodo in lista)
            {
                name.Add(nodo.GetAttribute("name"));
                value.Add(nodo.InnerText);
            }

            this.Text = value[name.IndexOf("help_" + this.Name)];
            label1.Text = value[name.IndexOf("help_" + label1.Name)];
        }
    }
}
