namespace Agenda
{
    partial class Calendario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Calendario));
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.Notificaciones = new System.Windows.Forms.NotifyIcon(this.components);
            this.materialFlatButton1 = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialFlatButton2 = new MaterialSkin.Controls.MaterialFlatButton();
            this.mLblInstr = new MaterialSkin.Controls.MaterialLabel();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyIcon2 = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyIcon3 = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyIcon4 = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyIcon5 = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.CalendarDimensions = new System.Drawing.Size(3, 3);
            this.monthCalendar1.Location = new System.Drawing.Point(-2, 67);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 0;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.MonthCalendar1_DateSelected);
            // 
            // Notificaciones
            // 
            this.Notificaciones.Text = "notifyIcon1";
            this.Notificaciones.Visible = true;
            this.Notificaciones.BalloonTipClicked += new System.EventHandler(this.Notificaciones_BalloonTipClicked);
            this.Notificaciones.BalloonTipClosed += new System.EventHandler(this.Notificaciones_BalloonTipClosed);
            // 
            // materialFlatButton1
            // 
            this.materialFlatButton1.AutoSize = true;
            this.materialFlatButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton1.Depth = 0;
            this.materialFlatButton1.Icon = null;
            this.materialFlatButton1.Location = new System.Drawing.Point(403, 524);
            this.materialFlatButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton1.Name = "materialFlatButton1";
            this.materialFlatButton1.Primary = false;
            this.materialFlatButton1.Size = new System.Drawing.Size(205, 36);
            this.materialFlatButton1.TabIndex = 3;
            this.materialFlatButton1.Text = "Crear copia de seguridad";
            this.materialFlatButton1.UseVisualStyleBackColor = true;
            this.materialFlatButton1.Click += new System.EventHandler(this.MaterialFlatButton1_Click);
            // 
            // materialFlatButton2
            // 
            this.materialFlatButton2.AutoSize = true;
            this.materialFlatButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton2.Depth = 0;
            this.materialFlatButton2.Icon = null;
            this.materialFlatButton2.Location = new System.Drawing.Point(626, 524);
            this.materialFlatButton2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton2.Name = "materialFlatButton2";
            this.materialFlatButton2.Primary = false;
            this.materialFlatButton2.Size = new System.Drawing.Size(98, 36);
            this.materialFlatButton2.TabIndex = 4;
            this.materialFlatButton2.Text = "Restaurar";
            this.materialFlatButton2.UseVisualStyleBackColor = true;
            this.materialFlatButton2.Click += new System.EventHandler(this.MaterialFlatButton2_Click);
            // 
            // mLblInstr
            // 
            this.mLblInstr.AutoSize = true;
            this.mLblInstr.Depth = 0;
            this.mLblInstr.Font = new System.Drawing.Font("Roboto", 11F);
            this.mLblInstr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mLblInstr.Location = new System.Drawing.Point(21, 532);
            this.mLblInstr.MouseState = MaterialSkin.MouseState.HOVER;
            this.mLblInstr.Name = "mLblInstr";
            this.mLblInstr.Size = new System.Drawing.Size(359, 19);
            this.mLblInstr.TabIndex = 5;
            this.mLblInstr.Text = "Haz click sobre cualquier fecha para ver los eventos";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.BalloonTipClicked += new System.EventHandler(this.notifyIcon1_BalloonTipClicked);
            this.notifyIcon1.BalloonTipClosed += new System.EventHandler(this.notifyIcon1_BalloonTipClosed);
            // 
            // notifyIcon2
            // 
            this.notifyIcon2.Text = "notifyIcon2";
            this.notifyIcon2.Visible = true;
            this.notifyIcon2.BalloonTipClicked += new System.EventHandler(this.notifyIcon2_BalloonTipClicked);
            this.notifyIcon2.BalloonTipClosed += new System.EventHandler(this.notifyIcon2_BalloonTipClosed);
            // 
            // notifyIcon3
            // 
            this.notifyIcon3.Text = "notifyIcon3";
            this.notifyIcon3.Visible = true;
            this.notifyIcon3.BalloonTipClicked += new System.EventHandler(this.notifyIcon3_BalloonTipClicked);
            this.notifyIcon3.BalloonTipClosed += new System.EventHandler(this.notifyIcon3_BalloonTipClosed);
            // 
            // notifyIcon4
            // 
            this.notifyIcon4.Text = "notifyIcon4";
            this.notifyIcon4.Visible = true;
            this.notifyIcon4.BalloonTipClicked += new System.EventHandler(this.notifyIcon4_BalloonTipClicked);
            this.notifyIcon4.BalloonTipClosed += new System.EventHandler(this.notifyIcon4_BalloonTipClosed);
            // 
            // notifyIcon5
            // 
            this.notifyIcon5.Text = "notifyIcon5";
            this.notifyIcon5.Visible = true;
            this.notifyIcon5.BalloonTipClicked += new System.EventHandler(this.notifyIcon5_BalloonTipClicked);
            this.notifyIcon5.BalloonTipClosed += new System.EventHandler(this.notifyIcon5_BalloonTipClosed);
            // 
            // Calendario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 566);
            this.Controls.Add(this.mLblInstr);
            this.Controls.Add(this.materialFlatButton2);
            this.Controls.Add(this.materialFlatButton1);
            this.Controls.Add(this.monthCalendar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Calendario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agenda";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Calendario_FormClosing);
            this.Load += new System.EventHandler(this.Calendario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendar1;
        public System.Windows.Forms.NotifyIcon Notificaciones;
        public MaterialSkin.Controls.MaterialFlatButton materialFlatButton1;
        public MaterialSkin.Controls.MaterialFlatButton materialFlatButton2;
        private MaterialSkin.Controls.MaterialLabel mLblInstr;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.NotifyIcon notifyIcon2;
        private System.Windows.Forms.NotifyIcon notifyIcon3;
        private System.Windows.Forms.NotifyIcon notifyIcon4;
        private System.Windows.Forms.NotifyIcon notifyIcon5;
    }
}