// Type: Sitemap_Generator.XMLViewer
// Assembly: Sitemap Generator, Version=1.4.1.0, Culture=neutral, PublicKeyToken=null
// MVID: 9EB1B4DF-297A-439C-B3D8-32F6AC7C6FE3
// Assembly location: E:\Mi nube\Documentos\Visual Studio 2013\Projects\Sitemap Generator\Sitemap Generator\bin\Debug\Sitemap Generator.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace Sitemap_Generator
{
  public class XMLViewer : Form
  {
    private string sgfolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\LonamiWebs\\Sitemap Generator";
    private List<string> name = new List<string>();
    private List<string> value = new List<string>();
    private IContainer components = (IContainer) null;
    private Button pickDoc;
    private TextBox pickDocTB;
    private TreeView treeView1;
    private Button acceptB;

    public XMLViewer()
    {
      this.InitializeComponent();
    }

    private void pickDoc_Click(object sender, EventArgs e)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Title = this.value[this.name.IndexOf("messagebox_pickxml_t")];
      openFileDialog.Filter = this.value[this.name.IndexOf("messagebox_pickxml_f")];
      int num = (int) openFileDialog.ShowDialog();
      string fileName = openFileDialog.FileName;
      this.pickDocTB.Text = fileName;
      this.updateTree(fileName);
    }

    private void updateTree(string path)
    {
      XmlDocument xmlDocument = new XmlDocument();
      xmlDocument.Load(path);
      XmlNode inXmlNode = xmlDocument.ChildNodes[1];
      this.treeView1.Nodes.Clear();
      this.treeView1.Nodes.Add(new TreeNode(xmlDocument.DocumentElement.Name));
      TreeNode inTreeNode = this.treeView1.Nodes[0];
      this.AddNode(inXmlNode, inTreeNode);
    }

    private void AddNode(XmlNode inXmlNode, TreeNode inTreeNode)
    {
      if (inXmlNode.HasChildNodes)
      {
        XmlNodeList childNodes = inXmlNode.ChildNodes;
        for (int index = 0; index <= childNodes.Count - 1; ++index)
        {
          XmlNode inXmlNode1 = inXmlNode.ChildNodes[index];
          inTreeNode.Nodes.Add(new TreeNode(inXmlNode1.Name));
          TreeNode inTreeNode1 = inTreeNode.Nodes[index];
          this.AddNode(inXmlNode1, inTreeNode1);
        }
      }
      else
        inTreeNode.Text = ((object) inXmlNode.InnerText).ToString();
    }

    private void acceptB_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void XMLViewer_Load(object sender, EventArgs e)
    {
      XmlDocument xmlDocument = new XmlDocument();
      string[] strArray = File.ReadAllLines(this.sgfolder + "\\sige.preferences");
      if (strArray[1] == "spanish")
      {
        int num1 = (int) MessageBox.Show("Español");
      }
      else if (strArray[1] == "english")
        xmlDocument.Load(this.sgfolder + "\\sige.en.language");
      else if (strArray[1] == "other")
      {
        int num2 = (int) MessageBox.Show("Other language unavailable");
      }
      foreach (XmlElement xmlElement in ((XmlElement) xmlDocument.GetElementsByTagName("strings")[0]).GetElementsByTagName("string"))
      {
        this.name.Add(xmlElement.GetAttribute("name"));
        this.value.Add(xmlElement.InnerText);
      }
      this.Text = this.value[this.name.IndexOf("viewer_" + this.Name)];
      this.pickDoc.Text = this.value[this.name.IndexOf("viewer_" + this.pickDoc.Name)];
      this.acceptB.Text = this.value[this.name.IndexOf("viewer_" + this.acceptB.Name)];
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XMLViewer));
            this.pickDoc = new System.Windows.Forms.Button();
            this.pickDocTB = new System.Windows.Forms.TextBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.acceptB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pickDoc
            // 
            this.pickDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pickDoc.Location = new System.Drawing.Point(278, 12);
            this.pickDoc.Name = "pickDoc";
            this.pickDoc.Size = new System.Drawing.Size(100, 23);
            this.pickDoc.TabIndex = 0;
            this.pickDoc.Text = "Elegir documento";
            this.pickDoc.UseVisualStyleBackColor = true;
            this.pickDoc.Click += new System.EventHandler(this.pickDoc_Click);
            // 
            // pickDocTB
            // 
            this.pickDocTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pickDocTB.Location = new System.Drawing.Point(12, 15);
            this.pickDocTB.Name = "pickDocTB";
            this.pickDocTB.Size = new System.Drawing.Size(260, 20);
            this.pickDocTB.TabIndex = 1;
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.Location = new System.Drawing.Point(13, 42);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(365, 208);
            this.treeView1.TabIndex = 2;
            // 
            // acceptB
            // 
            this.acceptB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.acceptB.Location = new System.Drawing.Point(326, 256);
            this.acceptB.Name = "acceptB";
            this.acceptB.Size = new System.Drawing.Size(52, 23);
            this.acceptB.TabIndex = 3;
            this.acceptB.Text = "Aceptar";
            this.acceptB.UseVisualStyleBackColor = true;
            this.acceptB.Click += new System.EventHandler(this.acceptB_Click);
            // 
            // XMLViewer
            // 
            this.ClientSize = new System.Drawing.Size(390, 281);
            this.Controls.Add(this.acceptB);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.pickDocTB);
            this.Controls.Add(this.pickDoc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "XMLViewer";
            this.Text = "Visor XML";
            this.Load += new System.EventHandler(this.XMLViewer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

    }
  }
}
