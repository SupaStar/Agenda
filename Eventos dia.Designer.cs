namespace Agenda
{
    partial class Eventos_dia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Eventos_dia));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.mLblEventos = new MaterialSkin.Controls.MaterialLabel();
            this.mLblFecha = new MaterialSkin.Controls.MaterialLabel();
            this.mRBtnAgregar = new MaterialSkin.Controls.MaterialRaisedButton();
            this.mRBtnVolver = new MaterialSkin.Controls.MaterialRaisedButton();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 106);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(330, 380);
            this.treeView1.TabIndex = 2;
            // 
            // mLblEventos
            // 
            this.mLblEventos.AutoSize = true;
            this.mLblEventos.Depth = 0;
            this.mLblEventos.Font = new System.Drawing.Font("Roboto", 11F);
            this.mLblEventos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mLblEventos.Location = new System.Drawing.Point(12, 75);
            this.mLblEventos.MouseState = MaterialSkin.MouseState.HOVER;
            this.mLblEventos.Name = "mLblEventos";
            this.mLblEventos.Size = new System.Drawing.Size(115, 19);
            this.mLblEventos.TabIndex = 6;
            this.mLblEventos.Text = "Eventos del dia:";
            // 
            // mLblFecha
            // 
            this.mLblFecha.AutoSize = true;
            this.mLblFecha.Depth = 0;
            this.mLblFecha.Font = new System.Drawing.Font("Roboto", 11F);
            this.mLblFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mLblFecha.Location = new System.Drawing.Point(133, 75);
            this.mLblFecha.MouseState = MaterialSkin.MouseState.HOVER;
            this.mLblFecha.Name = "mLblFecha";
            this.mLblFecha.Size = new System.Drawing.Size(69, 19);
            this.mLblFecha.TabIndex = 7;
            this.mLblFecha.Text = "{{Fecha}}";
            // 
            // mRBtnAgregar
            // 
            this.mRBtnAgregar.AutoSize = true;
            this.mRBtnAgregar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mRBtnAgregar.Depth = 0;
            this.mRBtnAgregar.Icon = null;
            this.mRBtnAgregar.Location = new System.Drawing.Point(363, 450);
            this.mRBtnAgregar.MouseState = MaterialSkin.MouseState.HOVER;
            this.mRBtnAgregar.Name = "mRBtnAgregar";
            this.mRBtnAgregar.Primary = true;
            this.mRBtnAgregar.Size = new System.Drawing.Size(83, 36);
            this.mRBtnAgregar.TabIndex = 9;
            this.mRBtnAgregar.Text = "Agregar";
            this.mRBtnAgregar.UseVisualStyleBackColor = true;
            this.mRBtnAgregar.Click += new System.EventHandler(this.mRBtnAgregar_Click);
            // 
            // mRBtnVolver
            // 
            this.mRBtnVolver.AutoSize = true;
            this.mRBtnVolver.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mRBtnVolver.Depth = 0;
            this.mRBtnVolver.Icon = null;
            this.mRBtnVolver.Location = new System.Drawing.Point(469, 450);
            this.mRBtnVolver.MouseState = MaterialSkin.MouseState.HOVER;
            this.mRBtnVolver.Name = "mRBtnVolver";
            this.mRBtnVolver.Primary = true;
            this.mRBtnVolver.Size = new System.Drawing.Size(72, 36);
            this.mRBtnVolver.TabIndex = 10;
            this.mRBtnVolver.Text = "Volver";
            this.mRBtnVolver.UseVisualStyleBackColor = true;
            this.mRBtnVolver.Click += new System.EventHandler(this.mRBtnVolver_Click);
            // 
            // Eventos_dia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 539);
            this.Controls.Add(this.mRBtnVolver);
            this.Controls.Add(this.mRBtnAgregar);
            this.Controls.Add(this.mLblFecha);
            this.Controls.Add(this.mLblEventos);
            this.Controls.Add(this.treeView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Eventos_dia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Eventos";
            this.Load += new System.EventHandler(this.Eventos_dia_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TreeView treeView1;
        private MaterialSkin.Controls.MaterialLabel mLblEventos;
        public MaterialSkin.Controls.MaterialLabel mLblFecha;
        private MaterialSkin.Controls.MaterialRaisedButton mRBtnVolver;
        public MaterialSkin.Controls.MaterialRaisedButton mRBtnAgregar;
    }
}