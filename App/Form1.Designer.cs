namespace App
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lisaaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.henkiloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projektiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tehtavaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageHenkilo = new System.Windows.Forms.TabPage();
            this.henkiloMuokkaaBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.etsiNimiButton = new System.Windows.Forms.Button();
            this.henkiloTextBox = new System.Windows.Forms.TextBox();
            this.poistaBtn = new System.Windows.Forms.Button();
            this.listViewHenkilot = new System.Windows.Forms.ListView();
            this.tabPageProjekti = new System.Windows.Forms.TabPage();
            this.projektiMuokkaaBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.etsiProjektiBtn = new System.Windows.Forms.Button();
            this.projektiTextBox = new System.Windows.Forms.TextBox();
            this.poistaProjBtn = new System.Windows.Forms.Button();
            this.listViewProjektit = new System.Windows.Forms.ListView();
            this.tabPageTehtavat = new System.Windows.Forms.TabPage();
            this.tehtavaMuokkaaBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tehtavaBtn = new System.Windows.Forms.Button();
            this.tehtavaTextBox = new System.Windows.Forms.TextBox();
            this.poistaTehtavatBtn = new System.Windows.Forms.Button();
            this.listViewTehtavat = new System.Windows.Forms.ListView();
            this.menuStrip1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageHenkilo.SuspendLayout();
            this.tabPageProjekti.SuspendLayout();
            this.tabPageTehtavat.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(745, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lisaaToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // lisaaToolStripMenuItem
            // 
            this.lisaaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.henkiloToolStripMenuItem,
            this.projektiToolStripMenuItem,
            this.tehtavaToolStripMenuItem});
            this.lisaaToolStripMenuItem.Name = "lisaaToolStripMenuItem";
            this.lisaaToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.lisaaToolStripMenuItem.Text = "Lisaa";
            // 
            // henkiloToolStripMenuItem
            // 
            this.henkiloToolStripMenuItem.Name = "henkiloToolStripMenuItem";
            this.henkiloToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.henkiloToolStripMenuItem.Text = "Henkilo";
            this.henkiloToolStripMenuItem.Click += new System.EventHandler(this.HenkiloToolStripMenuItem_Click);
            // 
            // projektiToolStripMenuItem
            // 
            this.projektiToolStripMenuItem.Name = "projektiToolStripMenuItem";
            this.projektiToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.projektiToolStripMenuItem.Text = "Projekti";
            this.projektiToolStripMenuItem.Click += new System.EventHandler(this.ProjektiToolStripMenuItem_Click);
            // 
            // tehtavaToolStripMenuItem
            // 
            this.tehtavaToolStripMenuItem.Name = "tehtavaToolStripMenuItem";
            this.tehtavaToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.tehtavaToolStripMenuItem.Text = "Tehtava";
            this.tehtavaToolStripMenuItem.Click += new System.EventHandler(this.TehtavaToolStripMenuItem_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageHenkilo);
            this.tabControl.Controls.Add(this.tabPageProjekti);
            this.tabControl.Controls.Add(this.tabPageTehtavat);
            this.tabControl.Location = new System.Drawing.Point(21, 27);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(616, 374);
            this.tabControl.TabIndex = 1;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabPageHenkilo
            // 
            this.tabPageHenkilo.Controls.Add(this.henkiloMuokkaaBtn);
            this.tabPageHenkilo.Controls.Add(this.label1);
            this.tabPageHenkilo.Controls.Add(this.etsiNimiButton);
            this.tabPageHenkilo.Controls.Add(this.henkiloTextBox);
            this.tabPageHenkilo.Controls.Add(this.poistaBtn);
            this.tabPageHenkilo.Controls.Add(this.listViewHenkilot);
            this.tabPageHenkilo.Location = new System.Drawing.Point(4, 22);
            this.tabPageHenkilo.Name = "tabPageHenkilo";
            this.tabPageHenkilo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHenkilo.Size = new System.Drawing.Size(608, 348);
            this.tabPageHenkilo.TabIndex = 0;
            this.tabPageHenkilo.Text = "Henkilo Tiedot";
            this.tabPageHenkilo.UseVisualStyleBackColor = true;
            this.tabPageHenkilo.Click += new System.EventHandler(this.tabPageHenkilo_Click);
            // 
            // henkiloMuokkaaBtn
            // 
            this.henkiloMuokkaaBtn.Location = new System.Drawing.Point(6, 316);
            this.henkiloMuokkaaBtn.Name = "henkiloMuokkaaBtn";
            this.henkiloMuokkaaBtn.Size = new System.Drawing.Size(75, 23);
            this.henkiloMuokkaaBtn.TabIndex = 6;
            this.henkiloMuokkaaBtn.Text = "Muokkaa";
            this.henkiloMuokkaaBtn.UseVisualStyleBackColor = true;
            this.henkiloMuokkaaBtn.Click += new System.EventHandler(this.henkiloMuokkaaBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(347, 271);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nimi";
            // 
            // etsiNimiButton
            // 
            this.etsiNimiButton.Location = new System.Drawing.Point(350, 313);
            this.etsiNimiButton.Name = "etsiNimiButton";
            this.etsiNimiButton.Size = new System.Drawing.Size(75, 23);
            this.etsiNimiButton.TabIndex = 4;
            this.etsiNimiButton.Text = "Etsi";
            this.etsiNimiButton.UseVisualStyleBackColor = true;
            this.etsiNimiButton.Click += new System.EventHandler(this.etsiNimiButton_Click);
            // 
            // henkiloTextBox
            // 
            this.henkiloTextBox.Location = new System.Drawing.Point(350, 287);
            this.henkiloTextBox.Name = "henkiloTextBox";
            this.henkiloTextBox.Size = new System.Drawing.Size(100, 20);
            this.henkiloTextBox.TabIndex = 3;
            this.henkiloTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.henkiloTextBox_KeyDown);
            // 
            // poistaBtn
            // 
            this.poistaBtn.Location = new System.Drawing.Point(6, 287);
            this.poistaBtn.Name = "poistaBtn";
            this.poistaBtn.Size = new System.Drawing.Size(75, 23);
            this.poistaBtn.TabIndex = 2;
            this.poistaBtn.Text = "Poista";
            this.poistaBtn.UseVisualStyleBackColor = true;
            this.poistaBtn.Click += new System.EventHandler(this.poistaBtn_Click);
            // 
            // listViewHenkilot
            // 
            this.listViewHenkilot.Location = new System.Drawing.Point(-4, -1);
            this.listViewHenkilot.Name = "listViewHenkilot";
            this.listViewHenkilot.Size = new System.Drawing.Size(610, 257);
            this.listViewHenkilot.TabIndex = 0;
            this.listViewHenkilot.UseCompatibleStateImageBehavior = false;
            this.listViewHenkilot.SelectedIndexChanged += new System.EventHandler(this.listViewHenkilot_SelectedIndexChanged);
            // 
            // tabPageProjekti
            // 
            this.tabPageProjekti.Controls.Add(this.projektiMuokkaaBtn);
            this.tabPageProjekti.Controls.Add(this.label2);
            this.tabPageProjekti.Controls.Add(this.etsiProjektiBtn);
            this.tabPageProjekti.Controls.Add(this.projektiTextBox);
            this.tabPageProjekti.Controls.Add(this.poistaProjBtn);
            this.tabPageProjekti.Controls.Add(this.listViewProjektit);
            this.tabPageProjekti.Location = new System.Drawing.Point(4, 22);
            this.tabPageProjekti.Name = "tabPageProjekti";
            this.tabPageProjekti.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProjekti.Size = new System.Drawing.Size(608, 348);
            this.tabPageProjekti.TabIndex = 1;
            this.tabPageProjekti.Text = "Projekti Tiedot";
            this.tabPageProjekti.UseVisualStyleBackColor = true;
            // 
            // projektiMuokkaaBtn
            // 
            this.projektiMuokkaaBtn.Location = new System.Drawing.Point(6, 316);
            this.projektiMuokkaaBtn.Name = "projektiMuokkaaBtn";
            this.projektiMuokkaaBtn.Size = new System.Drawing.Size(75, 23);
            this.projektiMuokkaaBtn.TabIndex = 9;
            this.projektiMuokkaaBtn.Text = "Muokkaa";
            this.projektiMuokkaaBtn.UseVisualStyleBackColor = true;
            this.projektiMuokkaaBtn.Click += new System.EventHandler(this.projektiMuokkaaBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(347, 271);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Nimi";
            // 
            // etsiProjektiBtn
            // 
            this.etsiProjektiBtn.Location = new System.Drawing.Point(350, 313);
            this.etsiProjektiBtn.Name = "etsiProjektiBtn";
            this.etsiProjektiBtn.Size = new System.Drawing.Size(75, 23);
            this.etsiProjektiBtn.TabIndex = 7;
            this.etsiProjektiBtn.Text = "Etsi";
            this.etsiProjektiBtn.UseVisualStyleBackColor = true;
            this.etsiProjektiBtn.Click += new System.EventHandler(this.etsiProjektiBtn_Click);
            // 
            // projektiTextBox
            // 
            this.projektiTextBox.Location = new System.Drawing.Point(350, 287);
            this.projektiTextBox.Name = "projektiTextBox";
            this.projektiTextBox.Size = new System.Drawing.Size(100, 20);
            this.projektiTextBox.TabIndex = 6;
            this.projektiTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.projektiTextBox_KeyDown);
            // 
            // poistaProjBtn
            // 
            this.poistaProjBtn.Location = new System.Drawing.Point(6, 287);
            this.poistaProjBtn.Name = "poistaProjBtn";
            this.poistaProjBtn.Size = new System.Drawing.Size(75, 23);
            this.poistaProjBtn.TabIndex = 3;
            this.poistaProjBtn.Text = "Poista";
            this.poistaProjBtn.UseVisualStyleBackColor = true;
            this.poistaProjBtn.Click += new System.EventHandler(this.poistaProjBtn_Click);
            // 
            // listViewProjektit
            // 
            this.listViewProjektit.Location = new System.Drawing.Point(-4, -1);
            this.listViewProjektit.Name = "listViewProjektit";
            this.listViewProjektit.Size = new System.Drawing.Size(610, 257);
            this.listViewProjektit.TabIndex = 1;
            this.listViewProjektit.UseCompatibleStateImageBehavior = false;
            this.listViewProjektit.SelectedIndexChanged += new System.EventHandler(this.listViewProjektit_SelectedIndexChanged);
            // 
            // tabPageTehtavat
            // 
            this.tabPageTehtavat.Controls.Add(this.tehtavaMuokkaaBtn);
            this.tabPageTehtavat.Controls.Add(this.label3);
            this.tabPageTehtavat.Controls.Add(this.tehtavaBtn);
            this.tabPageTehtavat.Controls.Add(this.tehtavaTextBox);
            this.tabPageTehtavat.Controls.Add(this.poistaTehtavatBtn);
            this.tabPageTehtavat.Controls.Add(this.listViewTehtavat);
            this.tabPageTehtavat.Location = new System.Drawing.Point(4, 22);
            this.tabPageTehtavat.Name = "tabPageTehtavat";
            this.tabPageTehtavat.Size = new System.Drawing.Size(608, 348);
            this.tabPageTehtavat.TabIndex = 2;
            this.tabPageTehtavat.Text = "Tehtavat";
            this.tabPageTehtavat.UseVisualStyleBackColor = true;
            // 
            // tehtavaMuokkaaBtn
            // 
            this.tehtavaMuokkaaBtn.Location = new System.Drawing.Point(6, 322);
            this.tehtavaMuokkaaBtn.Name = "tehtavaMuokkaaBtn";
            this.tehtavaMuokkaaBtn.Size = new System.Drawing.Size(75, 23);
            this.tehtavaMuokkaaBtn.TabIndex = 10;
            this.tehtavaMuokkaaBtn.Text = "Muokkaa";
            this.tehtavaMuokkaaBtn.UseVisualStyleBackColor = true;
            this.tehtavaMuokkaaBtn.Click += new System.EventHandler(this.tehtavaMuokkaaBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(347, 271);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Tehtava";
            // 
            // tehtavaBtn
            // 
            this.tehtavaBtn.Location = new System.Drawing.Point(350, 313);
            this.tehtavaBtn.Name = "tehtavaBtn";
            this.tehtavaBtn.Size = new System.Drawing.Size(75, 23);
            this.tehtavaBtn.TabIndex = 7;
            this.tehtavaBtn.Text = "Etsi";
            this.tehtavaBtn.UseVisualStyleBackColor = true;
            this.tehtavaBtn.Click += new System.EventHandler(this.tehtavaBtn_Click);
            // 
            // tehtavaTextBox
            // 
            this.tehtavaTextBox.Location = new System.Drawing.Point(350, 287);
            this.tehtavaTextBox.Name = "tehtavaTextBox";
            this.tehtavaTextBox.Size = new System.Drawing.Size(100, 20);
            this.tehtavaTextBox.TabIndex = 6;
            this.tehtavaTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tehtavaTextBox_KeyDown);
            // 
            // poistaTehtavatBtn
            // 
            this.poistaTehtavatBtn.Location = new System.Drawing.Point(6, 287);
            this.poistaTehtavatBtn.Name = "poistaTehtavatBtn";
            this.poistaTehtavatBtn.Size = new System.Drawing.Size(75, 23);
            this.poistaTehtavatBtn.TabIndex = 4;
            this.poistaTehtavatBtn.Text = "Poista";
            this.poistaTehtavatBtn.UseVisualStyleBackColor = true;
            this.poistaTehtavatBtn.Click += new System.EventHandler(this.poistaTehtavatBtn_Click);
            // 
            // listViewTehtavat
            // 
            this.listViewTehtavat.Location = new System.Drawing.Point(-4, -1);
            this.listViewTehtavat.Name = "listViewTehtavat";
            this.listViewTehtavat.Size = new System.Drawing.Size(610, 257);
            this.listViewTehtavat.TabIndex = 2;
            this.listViewTehtavat.UseCompatibleStateImageBehavior = false;
            this.listViewTehtavat.SelectedIndexChanged += new System.EventHandler(this.listViewTehtavat_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 472);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPageHenkilo.ResumeLayout(false);
            this.tabPageHenkilo.PerformLayout();
            this.tabPageProjekti.ResumeLayout(false);
            this.tabPageProjekti.PerformLayout();
            this.tabPageTehtavat.ResumeLayout(false);
            this.tabPageTehtavat.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lisaaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem henkiloToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projektiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tehtavaToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageHenkilo;
        private System.Windows.Forms.ListView listViewHenkilot;
        private System.Windows.Forms.TabPage tabPageProjekti;
        private System.Windows.Forms.ListView listViewProjektit;
        private System.Windows.Forms.TabPage tabPageTehtavat;
        private System.Windows.Forms.ListView listViewTehtavat;
        private System.Windows.Forms.Button poistaBtn;
        private System.Windows.Forms.Button poistaProjBtn;
        private System.Windows.Forms.Button poistaTehtavatBtn;
        private System.Windows.Forms.TextBox henkiloTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button etsiNimiButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button etsiProjektiBtn;
        private System.Windows.Forms.TextBox projektiTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button tehtavaBtn;
        private System.Windows.Forms.TextBox tehtavaTextBox;
        private System.Windows.Forms.Button henkiloMuokkaaBtn;
        private System.Windows.Forms.Button projektiMuokkaaBtn;
        private System.Windows.Forms.Button tehtavaMuokkaaBtn;
    }
}

