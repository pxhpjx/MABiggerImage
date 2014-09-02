namespace MABiggerImage
{
    partial class DECTool
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DECTool));
            this.txtSource = new System.Windows.Forms.TextBox();
            this.txtTarget = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGet = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnDEC = new System.Windows.Forms.Button();
            this.btnMove = new System.Windows.Forms.Button();
            this.btnSelectSource = new System.Windows.Forms.Button();
            this.btnSelectTarget = new System.Windows.Forms.Button();
            this.tcAll = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chkSlow = new System.Windows.Forms.CheckBox();
            this.chkTW = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnNormalMove = new System.Windows.Forms.Button();
            this.btnSelectPath = new System.Windows.Forms.Button();
            this.btnNormalDEC = new System.Windows.Forms.Button();
            this.txtNormalPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pbAll = new System.Windows.Forms.ProgressBar();
            this.btnBreak = new System.Windows.Forms.Button();
            this.chkFast = new System.Windows.Forms.CheckBox();
            this.tcAll.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSource
            // 
            this.txtSource.Location = new System.Drawing.Point(76, 10);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(366, 21);
            this.txtSource.TabIndex = 0;
            // 
            // txtTarget
            // 
            this.txtTarget.Location = new System.Drawing.Point(76, 54);
            this.txtTarget.Name = "txtTarget";
            this.txtTarget.Size = new System.Drawing.Size(366, 21);
            this.txtTarget.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "源路径";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "目标路径";
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(25, 90);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(75, 23);
            this.btnGet.TabIndex = 4;
            this.btnGet.Text = "获取";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(27, 155);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(35, 12);
            this.lblMessage.TabIndex = 5;
            this.lblMessage.Text = "Ready";
            // 
            // btnDEC
            // 
            this.btnDEC.Location = new System.Drawing.Point(132, 90);
            this.btnDEC.Name = "btnDEC";
            this.btnDEC.Size = new System.Drawing.Size(75, 23);
            this.btnDEC.TabIndex = 6;
            this.btnDEC.Text = "解密";
            this.btnDEC.UseVisualStyleBackColor = true;
            this.btnDEC.Click += new System.EventHandler(this.btnDEC_Click);
            // 
            // btnMove
            // 
            this.btnMove.Location = new System.Drawing.Point(242, 90);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(75, 23);
            this.btnMove.TabIndex = 7;
            this.btnMove.Text = "整理";
            this.btnMove.UseVisualStyleBackColor = true;
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // btnSelectSource
            // 
            this.btnSelectSource.Location = new System.Drawing.Point(453, 10);
            this.btnSelectSource.Name = "btnSelectSource";
            this.btnSelectSource.Size = new System.Drawing.Size(65, 23);
            this.btnSelectSource.TabIndex = 8;
            this.btnSelectSource.Text = "选择路径";
            this.btnSelectSource.UseVisualStyleBackColor = true;
            this.btnSelectSource.Click += new System.EventHandler(this.btnSelectSource_Click);
            // 
            // btnSelectTarget
            // 
            this.btnSelectTarget.Location = new System.Drawing.Point(453, 52);
            this.btnSelectTarget.Name = "btnSelectTarget";
            this.btnSelectTarget.Size = new System.Drawing.Size(65, 23);
            this.btnSelectTarget.TabIndex = 9;
            this.btnSelectTarget.Text = "选择路径";
            this.btnSelectTarget.UseVisualStyleBackColor = true;
            this.btnSelectTarget.Click += new System.EventHandler(this.btnSelectTarget_Click);
            // 
            // tcAll
            // 
            this.tcAll.Controls.Add(this.tabPage1);
            this.tcAll.Controls.Add(this.tabPage2);
            this.tcAll.Location = new System.Drawing.Point(0, 0);
            this.tcAll.Name = "tcAll";
            this.tcAll.SelectedIndex = 0;
            this.tcAll.Size = new System.Drawing.Size(532, 150);
            this.tcAll.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chkSlow);
            this.tabPage1.Controls.Add(this.chkTW);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.btnSelectTarget);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.btnMove);
            this.tabPage1.Controls.Add(this.txtSource);
            this.tabPage1.Controls.Add(this.btnDEC);
            this.tabPage1.Controls.Add(this.txtTarget);
            this.tabPage1.Controls.Add(this.btnSelectSource);
            this.tabPage1.Controls.Add(this.btnGet);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(524, 124);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "卡牌大图获取解密";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chkSlow
            // 
            this.chkSlow.AutoSize = true;
            this.chkSlow.Location = new System.Drawing.Point(394, 90);
            this.chkSlow.Name = "chkSlow";
            this.chkSlow.Size = new System.Drawing.Size(48, 16);
            this.chkSlow.TabIndex = 11;
            this.chkSlow.Text = "慢速";
            this.chkSlow.UseVisualStyleBackColor = true;
            // 
            // chkTW
            // 
            this.chkTW.AutoSize = true;
            this.chkTW.Location = new System.Drawing.Point(453, 90);
            this.chkTW.Name = "chkTW";
            this.chkTW.Size = new System.Drawing.Size(48, 16);
            this.chkTW.TabIndex = 10;
            this.chkTW.Text = "台服";
            this.chkTW.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chkFast);
            this.tabPage2.Controls.Add(this.btnNormalMove);
            this.tabPage2.Controls.Add(this.btnSelectPath);
            this.tabPage2.Controls.Add(this.btnNormalDEC);
            this.tabPage2.Controls.Add(this.txtNormalPath);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(524, 124);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "普通解密";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnNormalMove
            // 
            this.btnNormalMove.Location = new System.Drawing.Point(217, 58);
            this.btnNormalMove.Name = "btnNormalMove";
            this.btnNormalMove.Size = new System.Drawing.Size(75, 23);
            this.btnNormalMove.TabIndex = 4;
            this.btnNormalMove.Text = "整理";
            this.btnNormalMove.UseVisualStyleBackColor = true;
            this.btnNormalMove.Click += new System.EventHandler(this.btnNormalMove_Click);
            // 
            // btnSelectPath
            // 
            this.btnSelectPath.Location = new System.Drawing.Point(443, 17);
            this.btnSelectPath.Name = "btnSelectPath";
            this.btnSelectPath.Size = new System.Drawing.Size(75, 23);
            this.btnSelectPath.TabIndex = 3;
            this.btnSelectPath.Text = "选择路径";
            this.btnSelectPath.UseVisualStyleBackColor = true;
            this.btnSelectPath.Click += new System.EventHandler(this.btnSelectPath_Click);
            // 
            // btnNormalDEC
            // 
            this.btnNormalDEC.Location = new System.Drawing.Point(101, 58);
            this.btnNormalDEC.Name = "btnNormalDEC";
            this.btnNormalDEC.Size = new System.Drawing.Size(75, 23);
            this.btnNormalDEC.TabIndex = 2;
            this.btnNormalDEC.Text = "解密";
            this.btnNormalDEC.UseVisualStyleBackColor = true;
            this.btnNormalDEC.Click += new System.EventHandler(this.btnNormalDEC_Click);
            // 
            // txtNormalPath
            // 
            this.txtNormalPath.Location = new System.Drawing.Point(92, 19);
            this.txtNormalPath.Name = "txtNormalPath";
            this.txtNormalPath.Size = new System.Drawing.Size(342, 21);
            this.txtNormalPath.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "文件夹路径";
            // 
            // pbAll
            // 
            this.pbAll.Location = new System.Drawing.Point(180, 153);
            this.pbAll.Name = "pbAll";
            this.pbAll.Size = new System.Drawing.Size(300, 16);
            this.pbAll.TabIndex = 11;
            // 
            // btnBreak
            // 
            this.btnBreak.Location = new System.Drawing.Point(496, 150);
            this.btnBreak.Name = "btnBreak";
            this.btnBreak.Size = new System.Drawing.Size(22, 22);
            this.btnBreak.TabIndex = 12;
            this.btnBreak.Text = "×";
            this.btnBreak.UseVisualStyleBackColor = true;
            this.btnBreak.Click += new System.EventHandler(this.btnBreak_Click);
            // 
            // chkFast
            // 
            this.chkFast.AutoSize = true;
            this.chkFast.Location = new System.Drawing.Point(25, 62);
            this.chkFast.Name = "chkFast";
            this.chkFast.Size = new System.Drawing.Size(48, 16);
            this.chkFast.TabIndex = 5;
            this.chkFast.Text = "快速";
            this.chkFast.UseVisualStyleBackColor = true;
            // 
            // DECTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 174);
            this.Controls.Add(this.btnBreak);
            this.Controls.Add(this.pbAll);
            this.Controls.Add(this.tcAll);
            this.Controls.Add(this.lblMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DECTool";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PP\'s MA DEC Tool";
            this.tcAll.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.TextBox txtTarget;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnDEC;
        private System.Windows.Forms.Button btnMove;
        private System.Windows.Forms.Button btnSelectSource;
        private System.Windows.Forms.Button btnSelectTarget;
        private System.Windows.Forms.TabControl tcAll;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnNormalDEC;
        private System.Windows.Forms.TextBox txtNormalPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSelectPath;
        private System.Windows.Forms.Button btnNormalMove;
        private System.Windows.Forms.ProgressBar pbAll;
        private System.Windows.Forms.CheckBox chkTW;
        private System.Windows.Forms.Button btnBreak;
        private System.Windows.Forms.CheckBox chkSlow;
        private System.Windows.Forms.CheckBox chkFast;
    }
}

