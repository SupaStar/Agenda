namespace Agenda
{
    partial class Evento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Evento));
            this.cbRec = new System.Windows.Forms.ComboBox();
            this.timeR = new System.Windows.Forms.DateTimePicker();
            this.mLblFecha = new MaterialSkin.Controls.MaterialLabel();
            this.mTxtNombre = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.mLblNombre = new MaterialSkin.Controls.MaterialLabel();
            this.mLblRecordatorio = new MaterialSkin.Controls.MaterialLabel();
            this.mRBtnGuardar = new MaterialSkin.Controls.MaterialRaisedButton();
            this.mRbtnVolver = new MaterialSkin.Controls.MaterialRaisedButton();
            this.SuspendLayout();
            // 
            // cbRec
            // 
            this.cbRec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRec.FormattingEnabled = true;
            this.cbRec.Items.AddRange(new object[] {
            "Ninguno",
            "1 dia antes",
            "2 dias antes",
            "1 semana antes",
            "Otros"});
            this.cbRec.Location = new System.Drawing.Point(164, 260);
            this.cbRec.Name = "cbRec";
            this.cbRec.Size = new System.Drawing.Size(200, 21);
            this.cbRec.TabIndex = 6;
            // 
            // timeR
            // 
            this.timeR.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timeR.Location = new System.Drawing.Point(374, 260);
            this.timeR.Name = "timeR";
            this.timeR.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.timeR.Size = new System.Drawing.Size(119, 20);
            this.timeR.TabIndex = 11;
            // 
            // mLblFecha
            // 
            this.mLblFecha.AutoSize = true;
            this.mLblFecha.Depth = 0;
            this.mLblFecha.Font = new System.Drawing.Font("Roboto", 11F);
            this.mLblFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mLblFecha.Location = new System.Drawing.Point(192, 86);
            this.mLblFecha.MouseState = MaterialSkin.MouseState.HOVER;
            this.mLblFecha.Name = "mLblFecha";
            this.mLblFecha.Size = new System.Drawing.Size(69, 19);
            this.mLblFecha.TabIndex = 12;
            this.mLblFecha.Text = "{{Fecha}}";
            // 
            // mTxtNombre
            // 
            this.mTxtNombre.Depth = 0;
            this.mTxtNombre.Hint = "";
            this.mTxtNombre.Location = new System.Drawing.Point(164, 161);
            this.mTxtNombre.MaxLength = 32767;
            this.mTxtNombre.MouseState = MaterialSkin.MouseState.HOVER;
            this.mTxtNombre.Name = "mTxtNombre";
            this.mTxtNombre.PasswordChar = '\0';
            this.mTxtNombre.SelectedText = "";
            this.mTxtNombre.SelectionLength = 0;
            this.mTxtNombre.SelectionStart = 0;
            this.mTxtNombre.Size = new System.Drawing.Size(200, 23);
            this.mTxtNombre.TabIndex = 13;
            this.mTxtNombre.TabStop = false;
            this.mTxtNombre.UseSystemPasswordChar = false;
            // 
            // mLblNombre
            // 
            this.mLblNombre.AutoSize = true;
            this.mLblNombre.Depth = 0;
            this.mLblNombre.Font = new System.Drawing.Font("Roboto", 11F);
            this.mLblNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mLblNombre.Location = new System.Drawing.Point(12, 165);
            this.mLblNombre.MouseState = MaterialSkin.MouseState.HOVER;
            this.mLblNombre.Name = "mLblNombre";
            this.mLblNombre.Size = new System.Drawing.Size(136, 19);
            this.mLblNombre.TabIndex = 14;
            this.mLblNombre.Text = "Nombre del evento";
            // 
            // mLblRecordatorio
            // 
            this.mLblRecordatorio.AutoSize = true;
            this.mLblRecordatorio.Depth = 0;
            this.mLblRecordatorio.Font = new System.Drawing.Font("Roboto", 11F);
            this.mLblRecordatorio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mLblRecordatorio.Location = new System.Drawing.Point(12, 262);
            this.mLblRecordatorio.MouseState = MaterialSkin.MouseState.HOVER;
            this.mLblRecordatorio.Name = "mLblRecordatorio";
            this.mLblRecordatorio.Size = new System.Drawing.Size(96, 19);
            this.mLblRecordatorio.TabIndex = 16;
            this.mLblRecordatorio.Text = "Recordatorio";
            // 
            // mRBtnGuardar
            // 
            this.mRBtnGuardar.AutoSize = true;
            this.mRBtnGuardar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mRBtnGuardar.Depth = 0;
            this.mRBtnGuardar.Icon = null;
            this.mRBtnGuardar.Location = new System.Drawing.Point(311, 333);
            this.mRBtnGuardar.MouseState = MaterialSkin.MouseState.HOVER;
            this.mRBtnGuardar.Name = "mRBtnGuardar";
            this.mRBtnGuardar.Primary = true;
            this.mRBtnGuardar.Size = new System.Drawing.Size(84, 36);
            this.mRBtnGuardar.TabIndex = 17;
            this.mRBtnGuardar.Text = "Guardar";
            this.mRBtnGuardar.UseVisualStyleBackColor = true;
            this.mRBtnGuardar.Click += new System.EventHandler(this.mRBtnGuardar_Click);
            // 
            // mRbtnVolver
            // 
            this.mRbtnVolver.AutoSize = true;
            this.mRbtnVolver.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mRbtnVolver.Depth = 0;
            this.mRbtnVolver.Icon = null;
            this.mRbtnVolver.Location = new System.Drawing.Point(421, 333);
            this.mRbtnVolver.MouseState = MaterialSkin.MouseState.HOVER;
            this.mRbtnVolver.Name = "mRbtnVolver";
            this.mRbtnVolver.Primary = true;
            this.mRbtnVolver.Size = new System.Drawing.Size(72, 36);
            this.mRbtnVolver.TabIndex = 18;
            this.mRbtnVolver.Text = "Volver";
            this.mRbtnVolver.UseVisualStyleBackColor = true;
            this.mRbtnVolver.Click += new System.EventHandler(this.mRbtnVolver_Click);
            // 
            // Evento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 381);
            this.Controls.Add(this.mRbtnVolver);
            this.Controls.Add(this.mRBtnGuardar);
            this.Controls.Add(this.mLblRecordatorio);
            this.Controls.Add(this.mLblNombre);
            this.Controls.Add(this.mTxtNombre);
            this.Controls.Add(this.mLblFecha);
            this.Controls.Add(this.timeR);
            this.Controls.Add(this.cbRec);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Evento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Evento";
            this.Load += new System.EventHandler(this.Evento_LoadAsync);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cbRec;
        private System.Windows.Forms.DateTimePicker timeR;
        public MaterialSkin.Controls.MaterialLabel mLblFecha;
        private MaterialSkin.Controls.MaterialSingleLineTextField mTxtNombre;
        private MaterialSkin.Controls.MaterialLabel mLblNombre;
        private MaterialSkin.Controls.MaterialLabel mLblRecordatorio;
        private MaterialSkin.Controls.MaterialRaisedButton mRBtnGuardar;
        private MaterialSkin.Controls.MaterialRaisedButton mRbtnVolver;
    }
}