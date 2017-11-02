namespace Sitemap_Generator
{
    partial class SitemapUpdater
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SitemapUpdater));
            this.pickDocB = new System.Windows.Forms.Button();
            this.cancelB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pickDocB
            // 
            this.pickDocB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.pickDocB.Location = new System.Drawing.Point(12, 7);
            this.pickDocB.Name = "pickDocB";
            this.pickDocB.Size = new System.Drawing.Size(146, 39);
            this.pickDocB.TabIndex = 0;
            this.pickDocB.Text = "Elegir sitemap";
            this.pickDocB.UseVisualStyleBackColor = true;
            this.pickDocB.Click += new System.EventHandler(this.pickDocB_Click);
            // 
            // cancelB
            // 
            this.cancelB.Location = new System.Drawing.Point(165, 22);
            this.cancelB.Name = "cancelB";
            this.cancelB.Size = new System.Drawing.Size(60, 23);
            this.cancelB.TabIndex = 1;
            this.cancelB.Text = "Cancelar";
            this.cancelB.UseVisualStyleBackColor = true;
            this.cancelB.Click += new System.EventHandler(this.cancelB_Click);
            // 
            // SitemapUpdater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(231, 52);
            this.Controls.Add(this.cancelB);
            this.Controls.Add(this.pickDocB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SitemapUpdater";
            this.Text = "Actualizar sitemap";
            this.Load += new System.EventHandler(this.SitemapUpdater_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button pickDocB;
        private System.Windows.Forms.Button cancelB;
    }
}