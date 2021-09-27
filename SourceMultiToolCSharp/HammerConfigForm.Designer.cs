namespace SourceMultiToolCSharp
{
    partial class HammerConfigForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HammerConfigForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listbox_HContent = new System.Windows.Forms.CheckedListBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.button_gmodSave = new System.Windows.Forms.Button();
            this.button_CHTU = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listbox_FGDs = new System.Windows.Forms.CheckedListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Exe = new System.Windows.Forms.Button();
            this.button_Exe_Folder = new System.Windows.Forms.Button();
            this.button_BSP = new System.Windows.Forms.Button();
            this.button_VMF = new System.Windows.Forms.Button();
            this.textBox_Game_Exe = new System.Windows.Forms.TextBox();
            this.textBox_Exe_Folder = new System.Windows.Forms.TextBox();
            this.textBox_BSP = new System.Windows.Forms.TextBox();
            this.textBox_VMF = new System.Windows.Forms.TextBox();
            this.button_HCancel = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listbox_HContent);
            this.groupBox1.Location = new System.Drawing.Point(10, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(231, 257);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Content To Mount";
            // 
            // listbox_HContent
            // 
            this.listbox_HContent.FormattingEnabled = true;
            this.listbox_HContent.Location = new System.Drawing.Point(6, 19);
            this.listbox_HContent.Name = "listbox_HContent";
            this.listbox_HContent.Size = new System.Drawing.Size(218, 229);
            this.listbox_HContent.Sorted = true;
            this.listbox_HContent.TabIndex = 0;
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // button_gmodSave
            // 
            this.button_gmodSave.Location = new System.Drawing.Point(10, 497);
            this.button_gmodSave.Name = "button_gmodSave";
            this.button_gmodSave.Size = new System.Drawing.Size(75, 23);
            this.button_gmodSave.TabIndex = 2;
            this.button_gmodSave.Text = "Save";
            this.button_gmodSave.UseVisualStyleBackColor = true;
            this.button_gmodSave.Click += new System.EventHandler(this.button_gmodSave_Click);
            // 
            // button_CHTU
            // 
            this.button_CHTU.Location = new System.Drawing.Point(122, 497);
            this.button_CHTU.Name = "button_CHTU";
            this.button_CHTU.Size = new System.Drawing.Size(112, 23);
            this.button_CHTU.TabIndex = 3;
            this.button_CHTU.Text = "How to use";
            this.button_CHTU.UseVisualStyleBackColor = true;
            this.button_CHTU.Click += new System.EventHandler(this.button_CHTU_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listbox_FGDs);
            this.groupBox2.Location = new System.Drawing.Point(268, 14);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(247, 257);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "FGD\'s to use";
            // 
            // listbox_FGDs
            // 
            this.listbox_FGDs.FormattingEnabled = true;
            this.listbox_FGDs.Location = new System.Drawing.Point(6, 19);
            this.listbox_FGDs.Name = "listbox_FGDs";
            this.listbox_FGDs.Size = new System.Drawing.Size(234, 229);
            this.listbox_FGDs.Sorted = true;
            this.listbox_FGDs.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.button_Exe);
            this.groupBox3.Controls.Add(this.button_Exe_Folder);
            this.groupBox3.Controls.Add(this.button_BSP);
            this.groupBox3.Controls.Add(this.button_VMF);
            this.groupBox3.Controls.Add(this.textBox_Game_Exe);
            this.groupBox3.Controls.Add(this.textBox_Exe_Folder);
            this.groupBox3.Controls.Add(this.textBox_BSP);
            this.groupBox3.Controls.Add(this.textBox_VMF);
            this.groupBox3.Location = new System.Drawing.Point(10, 277);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(505, 214);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Directories";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Game Exe";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Game Exe Folder";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "BSP location";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "VMF location";
            // 
            // button_Exe
            // 
            this.button_Exe.Location = new System.Drawing.Point(6, 155);
            this.button_Exe.Name = "button_Exe";
            this.button_Exe.Size = new System.Drawing.Size(62, 23);
            this.button_Exe.TabIndex = 7;
            this.button_Exe.Text = "Browse";
            this.button_Exe.UseVisualStyleBackColor = true;
            this.button_Exe.Click += new System.EventHandler(this.button_Exe_Click);
            // 
            // button_Exe_Folder
            // 
            this.button_Exe_Folder.Location = new System.Drawing.Point(6, 115);
            this.button_Exe_Folder.Name = "button_Exe_Folder";
            this.button_Exe_Folder.Size = new System.Drawing.Size(62, 23);
            this.button_Exe_Folder.TabIndex = 6;
            this.button_Exe_Folder.Text = "Browse";
            this.button_Exe_Folder.UseVisualStyleBackColor = true;
            this.button_Exe_Folder.Click += new System.EventHandler(this.button_Exe_Folder_Click);
            // 
            // button_BSP
            // 
            this.button_BSP.Location = new System.Drawing.Point(6, 72);
            this.button_BSP.Name = "button_BSP";
            this.button_BSP.Size = new System.Drawing.Size(62, 23);
            this.button_BSP.TabIndex = 5;
            this.button_BSP.Text = "Browse";
            this.button_BSP.UseVisualStyleBackColor = true;
            this.button_BSP.Click += new System.EventHandler(this.button_BSP_Click);
            // 
            // button_VMF
            // 
            this.button_VMF.Location = new System.Drawing.Point(6, 32);
            this.button_VMF.Name = "button_VMF";
            this.button_VMF.Size = new System.Drawing.Size(62, 23);
            this.button_VMF.TabIndex = 4;
            this.button_VMF.Text = "Browse";
            this.button_VMF.UseVisualStyleBackColor = true;
            this.button_VMF.Click += new System.EventHandler(this.button_VMF_Click);
            // 
            // textBox_Game_Exe
            // 
            this.textBox_Game_Exe.Location = new System.Drawing.Point(86, 158);
            this.textBox_Game_Exe.Name = "textBox_Game_Exe";
            this.textBox_Game_Exe.Size = new System.Drawing.Size(412, 20);
            this.textBox_Game_Exe.TabIndex = 3;
            // 
            // textBox_Exe_Folder
            // 
            this.textBox_Exe_Folder.Location = new System.Drawing.Point(86, 115);
            this.textBox_Exe_Folder.Name = "textBox_Exe_Folder";
            this.textBox_Exe_Folder.Size = new System.Drawing.Size(412, 20);
            this.textBox_Exe_Folder.TabIndex = 2;
            // 
            // textBox_BSP
            // 
            this.textBox_BSP.Location = new System.Drawing.Point(86, 72);
            this.textBox_BSP.Name = "textBox_BSP";
            this.textBox_BSP.Size = new System.Drawing.Size(412, 20);
            this.textBox_BSP.TabIndex = 1;
            // 
            // textBox_VMF
            // 
            this.textBox_VMF.Location = new System.Drawing.Point(86, 35);
            this.textBox_VMF.Name = "textBox_VMF";
            this.textBox_VMF.Size = new System.Drawing.Size(412, 20);
            this.textBox_VMF.TabIndex = 0;
            // 
            // button_HCancel
            // 
            this.button_HCancel.Location = new System.Drawing.Point(403, 497);
            this.button_HCancel.Name = "button_HCancel";
            this.button_HCancel.Size = new System.Drawing.Size(112, 23);
            this.button_HCancel.TabIndex = 5;
            this.button_HCancel.Text = "Cancel";
            this.button_HCancel.UseVisualStyleBackColor = true;
            this.button_HCancel.Click += new System.EventHandler(this.button_HCancel_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // HammerConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 532);
            this.Controls.Add(this.button_HCancel);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button_CHTU);
            this.Controls.Add(this.button_gmodSave);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HammerConfigForm";
            this.Text = "Custom Hammer Config";
            this.Shown += new System.EventHandler(this.HammerConfigForm_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox listbox_HContent;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button button_gmodSave;
        private System.Windows.Forms.Button button_CHTU;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckedListBox listbox_FGDs;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button_HCancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Exe;
        private System.Windows.Forms.Button button_Exe_Folder;
        private System.Windows.Forms.Button button_BSP;
        private System.Windows.Forms.Button button_VMF;
        private System.Windows.Forms.TextBox textBox_Game_Exe;
        private System.Windows.Forms.TextBox textBox_Exe_Folder;
        private System.Windows.Forms.TextBox textBox_BSP;
        private System.Windows.Forms.TextBox textBox_VMF;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}