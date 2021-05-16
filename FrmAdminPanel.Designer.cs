
namespace Yazılım_Yapımı_Project
{
    partial class FrmAdminPanel
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
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.datagridurun = new System.Windows.Forms.DataGridView();
            this.datagridbakiye = new System.Windows.Forms.DataGridView();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtURUNAD = new System.Windows.Forms.TextBox();
            this.txtISIM = new System.Windows.Forms.TextBox();
            this.txtBAKIYE = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnUrunOnayla = new System.Windows.Forms.Button();
            this.btnBakiyeOnayla = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridurun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagridbakiye)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MV Boli", 22.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(442, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(319, 50);
            this.label5.TabIndex = 5;
            this.label5.Text = "ADMIN PANELI";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.datagridurun);
            this.panel1.Location = new System.Drawing.Point(12, 105);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(564, 307);
            this.panel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.datagridbakiye);
            this.panel2.Location = new System.Drawing.Point(635, 105);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(534, 307);
            this.panel2.TabIndex = 7;
            // 
            // datagridurun
            // 
            this.datagridurun.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datagridurun.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridurun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datagridurun.Location = new System.Drawing.Point(0, 0);
            this.datagridurun.Name = "datagridurun";
            this.datagridurun.RowHeadersWidth = 51;
            this.datagridurun.RowTemplate.Height = 24;
            this.datagridurun.Size = new System.Drawing.Size(564, 307);
            this.datagridurun.TabIndex = 0;
            this.datagridurun.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridurun_CellClick);
            // 
            // datagridbakiye
            // 
            this.datagridbakiye.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datagridbakiye.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridbakiye.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datagridbakiye.Location = new System.Drawing.Point(0, 0);
            this.datagridbakiye.Name = "datagridbakiye";
            this.datagridbakiye.RowHeadersWidth = 51;
            this.datagridbakiye.RowTemplate.Height = 24;
            this.datagridbakiye.Size = new System.Drawing.Size(534, 307);
            this.datagridbakiye.TabIndex = 0;
            this.datagridbakiye.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridbakiye_CellClick);
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtID.Location = new System.Drawing.Point(78, 449);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(161, 30);
            this.txtID.TabIndex = 11;
            this.txtID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtURUNAD
            // 
            this.txtURUNAD.Enabled = false;
            this.txtURUNAD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtURUNAD.Location = new System.Drawing.Point(302, 449);
            this.txtURUNAD.Name = "txtURUNAD";
            this.txtURUNAD.Size = new System.Drawing.Size(161, 30);
            this.txtURUNAD.TabIndex = 12;
            this.txtURUNAD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtISIM
            // 
            this.txtISIM.Enabled = false;
            this.txtISIM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtISIM.Location = new System.Drawing.Point(706, 449);
            this.txtISIM.Name = "txtISIM";
            this.txtISIM.Size = new System.Drawing.Size(161, 30);
            this.txtISIM.TabIndex = 13;
            this.txtISIM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBAKIYE
            // 
            this.txtBAKIYE.Enabled = false;
            this.txtBAKIYE.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtBAKIYE.Location = new System.Drawing.Point(929, 449);
            this.txtBAKIYE.Name = "txtBAKIYE";
            this.txtBAKIYE.Size = new System.Drawing.Size(161, 30);
            this.txtBAKIYE.TabIndex = 14;
            this.txtBAKIYE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(135, 429);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "URUN ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(350, 429);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 16;
            this.label2.Text = "URUN AD";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(736, 429);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "MUSTERI ISIM";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(939, 429);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 17);
            this.label4.TabIndex = 18;
            this.label4.Text = "YUKLENECEK BAKIYE";
            // 
            // btnUrunOnayla
            // 
            this.btnUrunOnayla.Location = new System.Drawing.Point(191, 508);
            this.btnUrunOnayla.Name = "btnUrunOnayla";
            this.btnUrunOnayla.Size = new System.Drawing.Size(149, 35);
            this.btnUrunOnayla.TabIndex = 19;
            this.btnUrunOnayla.Text = "URUN ONAYLA";
            this.btnUrunOnayla.UseVisualStyleBackColor = true;
            this.btnUrunOnayla.Click += new System.EventHandler(this.btnUrunOnayla_Click);
            // 
            // btnBakiyeOnayla
            // 
            this.btnBakiyeOnayla.Location = new System.Drawing.Point(822, 508);
            this.btnBakiyeOnayla.Name = "btnBakiyeOnayla";
            this.btnBakiyeOnayla.Size = new System.Drawing.Size(149, 35);
            this.btnBakiyeOnayla.TabIndex = 20;
            this.btnBakiyeOnayla.Text = "BAKIYE ONAYLA";
            this.btnBakiyeOnayla.UseVisualStyleBackColor = true;
            this.btnBakiyeOnayla.Click += new System.EventHandler(this.btnBakiyeOnayla_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(154, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(282, 26);
            this.label6.TabIndex = 21;
            this.label6.Text = "Onaylanma Bekleyen Ürünler";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(753, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(298, 26);
            this.label7.TabIndex = 22;
            this.label7.Text = "Onaylanma Bekleyen Bakiyeler";
            // 
            // FrmAdminPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1181, 555);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnBakiyeOnayla);
            this.Controls.Add(this.btnUrunOnayla);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBAKIYE);
            this.Controls.Add(this.txtISIM);
            this.Controls.Add(this.txtURUNAD);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Name = "FrmAdminPanel";
            this.Text = "FrmAdminPanel";
            this.Load += new System.EventHandler(this.FrmAdminPanel_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datagridurun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagridbakiye)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView datagridurun;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView datagridbakiye;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtURUNAD;
        private System.Windows.Forms.TextBox txtISIM;
        private System.Windows.Forms.TextBox txtBAKIYE;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnUrunOnayla;
        private System.Windows.Forms.Button btnBakiyeOnayla;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}