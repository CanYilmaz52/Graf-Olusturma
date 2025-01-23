namespace BITES_PROJE_REMAKE
{
    partial class MainForm
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
            this.btnCreateGraph = new System.Windows.Forms.Button();
            this.comboBoxAlgorithm = new System.Windows.Forms.ComboBox();
            this.btnRunAlgorithm = new System.Windows.Forms.Button();
            this.txtNumNodes = new System.Windows.Forms.TextBox();
            this.treeView = new System.Windows.Forms.TreeView();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.Input = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCreateGraph
            // 
            this.btnCreateGraph.Location = new System.Drawing.Point(12, 12);
            this.btnCreateGraph.Name = "btnCreateGraph";
            this.btnCreateGraph.Size = new System.Drawing.Size(90, 37);
            this.btnCreateGraph.TabIndex = 0;
            this.btnCreateGraph.Text = "Create Graph";
            this.btnCreateGraph.UseVisualStyleBackColor = true;
            this.btnCreateGraph.Click += new System.EventHandler(this.btnCreateGraph_Click);
            // 
            // comboBoxAlgorithm
            // 
            this.comboBoxAlgorithm.FormattingEnabled = true;
            this.comboBoxAlgorithm.Location = new System.Drawing.Point(491, 16);
            this.comboBoxAlgorithm.Name = "comboBoxAlgorithm";
            this.comboBoxAlgorithm.Size = new System.Drawing.Size(148, 21);
            this.comboBoxAlgorithm.TabIndex = 1;
            // 
            // btnRunAlgorithm
            // 
            this.btnRunAlgorithm.Location = new System.Drawing.Point(108, 12);
            this.btnRunAlgorithm.Name = "btnRunAlgorithm";
            this.btnRunAlgorithm.Size = new System.Drawing.Size(90, 37);
            this.btnRunAlgorithm.TabIndex = 2;
            this.btnRunAlgorithm.Text = "Run Algorithm";
            this.btnRunAlgorithm.UseVisualStyleBackColor = true;
            this.btnRunAlgorithm.Click += new System.EventHandler(this.btnRunAlgorithm_Click);
            // 
            // txtNumNodes
            // 
            this.txtNumNodes.Location = new System.Drawing.Point(262, 16);
            this.txtNumNodes.Name = "txtNumNodes";
            this.txtNumNodes.Size = new System.Drawing.Size(118, 20);
            this.txtNumNodes.TabIndex = 3;
            this.txtNumNodes.Validating += new System.ComponentModel.CancelEventHandler(this.txtNumNodes_Validating);
            // 
            // treeView
            // 
            this.treeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView.Location = new System.Drawing.Point(12, 55);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(627, 636);
            this.treeView.TabIndex = 4;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // Input
            // 
            this.Input.AutoSize = true;
            this.Input.BackColor = System.Drawing.Color.AliceBlue;
            this.Input.Location = new System.Drawing.Point(386, 19);
            this.Input.Name = "Input";
            this.Input.Size = new System.Drawing.Size(31, 13);
            this.Input.TabIndex = 5;
            this.Input.Text = "Input";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.AliceBlue;
            this.pictureBox2.Image = global::BITES_PROJE_REMAKE.Properties.Resources.graf_removebg_preview;
            this.pictureBox2.Location = new System.Drawing.Point(988, 44);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(518, 485);
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.AliceBlue;
            this.pictureBox1.Image = global::BITES_PROJE_REMAKE.Properties.Resources.algo_removebg_preview;
            this.pictureBox1.Location = new System.Drawing.Point(851, 535);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(753, 358);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.AliceBlue;
            this.pictureBox3.BackgroundImage = global::BITES_PROJE_REMAKE.Properties.Resources.alfo;
            this.pictureBox3.Location = new System.Drawing.Point(2, -1);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(1916, 986);
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            // 
            // dataGridView
            // 
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 697);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(262, 253);
            this.dataGridView.TabIndex = 10;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1884, 962);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Input);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.txtNumNodes);
            this.Controls.Add(this.btnRunAlgorithm);
            this.Controls.Add(this.comboBoxAlgorithm);
            this.Controls.Add(this.btnCreateGraph);
            this.Controls.Add(this.pictureBox3);
            this.Name = "MainForm";
            this.Text = "Main Form";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreateGraph;
        private System.Windows.Forms.ComboBox comboBoxAlgorithm;
        private System.Windows.Forms.Button btnRunAlgorithm;
        private System.Windows.Forms.TextBox txtNumNodes;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label Input;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        public System.Windows.Forms.DataGridView dataGridView;
    }
}

