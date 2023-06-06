namespace PracticaResidus
{
    partial class FrMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbComarques = new System.Windows.Forms.ComboBox();
            this.lbxPoblacionsComarca = new System.Windows.Forms.ListBox();
            this.dgResidus = new System.Windows.Forms.DataGridView();
            this.Municipi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Any = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipusResidu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TonesRecollides = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Percentatge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbResidus = new System.Windows.Forms.Label();
            this.Convertir = new System.Windows.Forms.GroupBox();
            this.btnComarques = new System.Windows.Forms.Button();
            this.btnMunicipis = new System.Windows.Forms.Button();
            this.btnRecollida = new System.Windows.Forms.Button();
            this.sdgXmlFile = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgResidus)).BeginInit();
            this.Convertir.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbComarques
            // 
            this.cbComarques.FormattingEnabled = true;
            this.cbComarques.Location = new System.Drawing.Point(12, 12);
            this.cbComarques.Name = "cbComarques";
            this.cbComarques.Size = new System.Drawing.Size(251, 24);
            this.cbComarques.TabIndex = 0;
            this.cbComarques.SelectedIndexChanged += new System.EventHandler(this.cbComarques_SelectedIndexChanged);
            // 
            // lbxPoblacionsComarca
            // 
            this.lbxPoblacionsComarca.FormattingEnabled = true;
            this.lbxPoblacionsComarca.ItemHeight = 16;
            this.lbxPoblacionsComarca.Location = new System.Drawing.Point(12, 66);
            this.lbxPoblacionsComarca.Name = "lbxPoblacionsComarca";
            this.lbxPoblacionsComarca.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbxPoblacionsComarca.Size = new System.Drawing.Size(251, 404);
            this.lbxPoblacionsComarca.TabIndex = 1;
            this.lbxPoblacionsComarca.SelectedIndexChanged += new System.EventHandler(this.lbxPoblacionsComarca_SelectedIndexChanged);
            // 
            // dgResidus
            // 
            this.dgResidus.AllowUserToAddRows = false;
            this.dgResidus.AllowUserToDeleteRows = false;
            this.dgResidus.AllowUserToOrderColumns = true;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            this.dgResidus.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgResidus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgResidus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Municipi,
            this.Any,
            this.TipusResidu,
            this.TonesRecollides,
            this.Percentatge});
            this.dgResidus.Location = new System.Drawing.Point(288, 44);
            this.dgResidus.Margin = new System.Windows.Forms.Padding(4);
            this.dgResidus.MultiSelect = false;
            this.dgResidus.Name = "dgResidus";
            this.dgResidus.ReadOnly = true;
            this.dgResidus.RowHeadersVisible = false;
            this.dgResidus.RowHeadersWidth = 51;
            this.dgResidus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgResidus.Size = new System.Drawing.Size(634, 430);
            this.dgResidus.TabIndex = 34;
            this.dgResidus.Visible = false;
            // 
            // Municipi
            // 
            this.Municipi.HeaderText = "Municipi";
            this.Municipi.MinimumWidth = 6;
            this.Municipi.Name = "Municipi";
            this.Municipi.ReadOnly = true;
            this.Municipi.Width = 125;
            // 
            // Any
            // 
            this.Any.HeaderText = "Any";
            this.Any.MinimumWidth = 6;
            this.Any.Name = "Any";
            this.Any.ReadOnly = true;
            this.Any.Width = 125;
            // 
            // TipusResidu
            // 
            this.TipusResidu.HeaderText = "Tipus Residu";
            this.TipusResidu.MinimumWidth = 6;
            this.TipusResidu.Name = "TipusResidu";
            this.TipusResidu.ReadOnly = true;
            this.TipusResidu.Width = 125;
            // 
            // TonesRecollides
            // 
            this.TonesRecollides.HeaderText = "Tones Recollides";
            this.TonesRecollides.MinimumWidth = 6;
            this.TonesRecollides.Name = "TonesRecollides";
            this.TonesRecollides.ReadOnly = true;
            this.TonesRecollides.Width = 125;
            // 
            // Percentatge
            // 
            this.Percentatge.HeaderText = "Percentatge";
            this.Percentatge.MinimumWidth = 6;
            this.Percentatge.Name = "Percentatge";
            this.Percentatge.ReadOnly = true;
            this.Percentatge.Width = 125;
            // 
            // lbResidus
            // 
            this.lbResidus.AutoSize = true;
            this.lbResidus.BackColor = System.Drawing.Color.Orange;
            this.lbResidus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbResidus.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbResidus.Location = new System.Drawing.Point(288, 12);
            this.lbResidus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbResidus.MinimumSize = new System.Drawing.Size(500, 2);
            this.lbResidus.Name = "lbResidus";
            this.lbResidus.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.lbResidus.Size = new System.Drawing.Size(500, 34);
            this.lbResidus.TabIndex = 35;
            this.lbResidus.Text = "Residus del municipi ";
            this.lbResidus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbResidus.Visible = false;
            // 
            // Convertir
            // 
            this.Convertir.Controls.Add(this.btnRecollida);
            this.Convertir.Controls.Add(this.btnMunicipis);
            this.Convertir.Controls.Add(this.btnComarques);
            this.Convertir.Location = new System.Drawing.Point(13, 491);
            this.Convertir.Name = "Convertir";
            this.Convertir.Size = new System.Drawing.Size(909, 128);
            this.Convertir.TabIndex = 36;
            this.Convertir.TabStop = false;
            this.Convertir.Text = "gbBotons";
            // 
            // btnComarques
            // 
            this.btnComarques.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnComarques.Location = new System.Drawing.Point(30, 51);
            this.btnComarques.Name = "btnComarques";
            this.btnComarques.Size = new System.Drawing.Size(150, 46);
            this.btnComarques.TabIndex = 0;
            this.btnComarques.Text = "Comarques";
            this.btnComarques.UseVisualStyleBackColor = false;
            this.btnComarques.Click += new System.EventHandler(this.btnComarques_Click);
            // 
            // btnMunicipis
            // 
            this.btnMunicipis.BackColor = System.Drawing.Color.Yellow;
            this.btnMunicipis.Location = new System.Drawing.Point(331, 51);
            this.btnMunicipis.Name = "btnMunicipis";
            this.btnMunicipis.Size = new System.Drawing.Size(150, 46);
            this.btnMunicipis.TabIndex = 1;
            this.btnMunicipis.Text = "Municipis";
            this.btnMunicipis.UseVisualStyleBackColor = false;
            this.btnMunicipis.Click += new System.EventHandler(this.btnMunicipis_Click);
            // 
            // btnRecollida
            // 
            this.btnRecollida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnRecollida.Enabled = false;
            this.btnRecollida.Location = new System.Drawing.Point(662, 51);
            this.btnRecollida.Name = "btnRecollida";
            this.btnRecollida.Size = new System.Drawing.Size(150, 46);
            this.btnRecollida.TabIndex = 2;
            this.btnRecollida.Text = "Busca dades per habilitar aquest boto";
            this.btnRecollida.UseVisualStyleBackColor = false;
            this.btnRecollida.Click += new System.EventHandler(this.btnRecollida_Click);
            // 
            // sdgXmlFile
            // 
            this.sdgXmlFile.Filter = "(*.xml)|*.xml\"";
            // 
            // FrMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 631);
            this.Controls.Add(this.Convertir);
            this.Controls.Add(this.dgResidus);
            this.Controls.Add(this.lbResidus);
            this.Controls.Add(this.lbxPoblacionsComarca);
            this.Controls.Add(this.cbComarques);
            this.Name = "FrMain";
            this.Text = "Activitat Residus Llorca";
            this.Load += new System.EventHandler(this.FrMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgResidus)).EndInit();
            this.Convertir.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbComarques;
        private System.Windows.Forms.ListBox lbxPoblacionsComarca;
        private System.Windows.Forms.DataGridView dgResidus;
        private System.Windows.Forms.Label lbResidus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Municipi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Any;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipusResidu;
        private System.Windows.Forms.DataGridViewTextBoxColumn TonesRecollides;
        private System.Windows.Forms.DataGridViewTextBoxColumn Percentatge;
        private System.Windows.Forms.GroupBox Convertir;
        private System.Windows.Forms.Button btnRecollida;
        private System.Windows.Forms.Button btnMunicipis;
        private System.Windows.Forms.Button btnComarques;
        private System.Windows.Forms.SaveFileDialog sdgXmlFile;
    }
}

