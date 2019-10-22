namespace Excel_Conversion_Tool
{
    partial class ExcelTool
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.importPathTextBox = new System.Windows.Forms.TextBox();
            this.selectButton = new System.Windows.Forms.Button();
            this.converModeBox = new System.Windows.Forms.GroupBox();
            this.multipleToggle = new System.Windows.Forms.RadioButton();
            this.singleToggle = new System.Windows.Forms.RadioButton();
            this.stateLabel = new System.Windows.Forms.Label();
            this.excelListBox = new System.Windows.Forms.ListBox();
            this.countLabel = new System.Windows.Forms.Label();
            this.convertButton = new System.Windows.Forms.Button();
            this.formatGroup = new System.Windows.Forms.GroupBox();
            this.csvToggle = new System.Windows.Forms.RadioButton();
            this.xmlToggle = new System.Windows.Forms.RadioButton();
            this.jsonToggle = new System.Windows.Forms.RadioButton();
            this.codingGroup = new System.Windows.Forms.GroupBox();
            this.gbToggle = new System.Windows.Forms.RadioButton();
            this.utf8Toggle = new System.Windows.Forms.RadioButton();
            this.exportPathInputBox = new System.Windows.Forms.TextBox();
            this.exportButton = new System.Windows.Forms.Button();
            this.openAssetMessageButton = new System.Windows.Forms.Button();
            this.converModeBox.SuspendLayout();
            this.formatGroup.SuspendLayout();
            this.codingGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // importPathTextBox
            // 
            this.importPathTextBox.Location = new System.Drawing.Point(26, 55);
            this.importPathTextBox.Name = "importPathTextBox";
            this.importPathTextBox.Size = new System.Drawing.Size(280, 21);
            this.importPathTextBox.TabIndex = 0;
            // 
            // selectButton
            // 
            this.selectButton.Location = new System.Drawing.Point(329, 55);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(83, 21);
            this.selectButton.TabIndex = 1;
            this.selectButton.Text = "选择文件";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // converModeBox
            // 
            this.converModeBox.Controls.Add(this.multipleToggle);
            this.converModeBox.Controls.Add(this.singleToggle);
            this.converModeBox.Location = new System.Drawing.Point(12, 12);
            this.converModeBox.Name = "converModeBox";
            this.converModeBox.Size = new System.Drawing.Size(249, 37);
            this.converModeBox.TabIndex = 2;
            this.converModeBox.TabStop = false;
            this.converModeBox.Text = "转换模式";
            // 
            // multipleToggle
            // 
            this.multipleToggle.AutoSize = true;
            this.multipleToggle.Location = new System.Drawing.Point(143, 15);
            this.multipleToggle.Name = "multipleToggle";
            this.multipleToggle.Size = new System.Drawing.Size(71, 16);
            this.multipleToggle.TabIndex = 1;
            this.multipleToggle.Text = "批量处理";
            this.multipleToggle.UseVisualStyleBackColor = true;
            this.multipleToggle.CheckedChanged += new System.EventHandler(this.multipleToggle_CheckedChanged);
            // 
            // singleToggle
            // 
            this.singleToggle.AutoSize = true;
            this.singleToggle.Checked = true;
            this.singleToggle.Location = new System.Drawing.Point(42, 15);
            this.singleToggle.Name = "singleToggle";
            this.singleToggle.Size = new System.Drawing.Size(71, 16);
            this.singleToggle.TabIndex = 0;
            this.singleToggle.TabStop = true;
            this.singleToggle.Text = "单项任务";
            this.singleToggle.UseVisualStyleBackColor = true;
            this.singleToggle.CheckedChanged += new System.EventHandler(this.singleToggle_CheckedChanged);
            // 
            // stateLabel
            // 
            this.stateLabel.AutoSize = true;
            this.stateLabel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.stateLabel.Location = new System.Drawing.Point(25, 313);
            this.stateLabel.Name = "stateLabel";
            this.stateLabel.Size = new System.Drawing.Size(0, 14);
            this.stateLabel.TabIndex = 3;
            // 
            // excelListBox
            // 
            this.excelListBox.FormattingEnabled = true;
            this.excelListBox.ItemHeight = 12;
            this.excelListBox.Location = new System.Drawing.Point(26, 207);
            this.excelListBox.Name = "excelListBox";
            this.excelListBox.Size = new System.Drawing.Size(364, 100);
            this.excelListBox.TabIndex = 4;
            this.excelListBox.Visible = false;
            // 
            // countLabel
            // 
            this.countLabel.AutoSize = true;
            this.countLabel.Location = new System.Drawing.Point(25, 164);
            this.countLabel.Name = "countLabel";
            this.countLabel.Size = new System.Drawing.Size(0, 12);
            this.countLabel.TabIndex = 5;
            // 
            // convertButton
            // 
            this.convertButton.Location = new System.Drawing.Point(155, 363);
            this.convertButton.Name = "convertButton";
            this.convertButton.Size = new System.Drawing.Size(105, 30);
            this.convertButton.TabIndex = 6;
            this.convertButton.Text = "执 行";
            this.convertButton.UseVisualStyleBackColor = true;
            this.convertButton.Click += new System.EventHandler(this.converButton_Click);
            // 
            // formatGroup
            // 
            this.formatGroup.Controls.Add(this.csvToggle);
            this.formatGroup.Controls.Add(this.xmlToggle);
            this.formatGroup.Controls.Add(this.jsonToggle);
            this.formatGroup.Location = new System.Drawing.Point(12, 158);
            this.formatGroup.Name = "formatGroup";
            this.formatGroup.Size = new System.Drawing.Size(378, 43);
            this.formatGroup.TabIndex = 7;
            this.formatGroup.TabStop = false;
            this.formatGroup.Text = "转换格式";
            // 
            // csvToggle
            // 
            this.csvToggle.AutoSize = true;
            this.csvToggle.Location = new System.Drawing.Point(245, 21);
            this.csvToggle.Name = "csvToggle";
            this.csvToggle.Size = new System.Drawing.Size(41, 16);
            this.csvToggle.TabIndex = 2;
            this.csvToggle.Text = "csv";
            this.csvToggle.UseVisualStyleBackColor = true;
            this.csvToggle.CheckedChanged += new System.EventHandler(this.csvToggle_CheckedChanged);
            // 
            // xmlToggle
            // 
            this.xmlToggle.AutoSize = true;
            this.xmlToggle.Location = new System.Drawing.Point(144, 21);
            this.xmlToggle.Name = "xmlToggle";
            this.xmlToggle.Size = new System.Drawing.Size(41, 16);
            this.xmlToggle.TabIndex = 1;
            this.xmlToggle.Text = "Xml";
            this.xmlToggle.UseVisualStyleBackColor = true;
            this.xmlToggle.CheckedChanged += new System.EventHandler(this.xmlToggle_CheckedChanged);
            // 
            // jsonToggle
            // 
            this.jsonToggle.AutoSize = true;
            this.jsonToggle.Checked = true;
            this.jsonToggle.Location = new System.Drawing.Point(42, 21);
            this.jsonToggle.Name = "jsonToggle";
            this.jsonToggle.Size = new System.Drawing.Size(47, 16);
            this.jsonToggle.TabIndex = 0;
            this.jsonToggle.TabStop = true;
            this.jsonToggle.Text = "Json";
            this.jsonToggle.UseVisualStyleBackColor = true;
            this.jsonToggle.CheckedChanged += new System.EventHandler(this.jsonToggle_CheckedChanged);
            // 
            // codingGroup
            // 
            this.codingGroup.Controls.Add(this.gbToggle);
            this.codingGroup.Controls.Add(this.utf8Toggle);
            this.codingGroup.Location = new System.Drawing.Point(12, 110);
            this.codingGroup.Name = "codingGroup";
            this.codingGroup.Size = new System.Drawing.Size(249, 42);
            this.codingGroup.TabIndex = 8;
            this.codingGroup.TabStop = false;
            this.codingGroup.Text = "编码格式";
            // 
            // gbToggle
            // 
            this.gbToggle.AutoSize = true;
            this.gbToggle.Location = new System.Drawing.Point(143, 19);
            this.gbToggle.Name = "gbToggle";
            this.gbToggle.Size = new System.Drawing.Size(59, 16);
            this.gbToggle.TabIndex = 1;
            this.gbToggle.Text = "gb2312";
            this.gbToggle.UseVisualStyleBackColor = true;
            this.gbToggle.CheckedChanged += new System.EventHandler(this.gbToggle_CheckedChanged);
            // 
            // utf8Toggle
            // 
            this.utf8Toggle.AutoSize = true;
            this.utf8Toggle.Checked = true;
            this.utf8Toggle.Location = new System.Drawing.Point(42, 20);
            this.utf8Toggle.Name = "utf8Toggle";
            this.utf8Toggle.Size = new System.Drawing.Size(53, 16);
            this.utf8Toggle.TabIndex = 0;
            this.utf8Toggle.TabStop = true;
            this.utf8Toggle.Text = "utf-8";
            this.utf8Toggle.UseVisualStyleBackColor = true;
            this.utf8Toggle.CheckedChanged += new System.EventHandler(this.utf8Toggle_CheckedChanged);
            // 
            // exportPathInputBox
            // 
            this.exportPathInputBox.Location = new System.Drawing.Point(27, 83);
            this.exportPathInputBox.Name = "exportPathInputBox";
            this.exportPathInputBox.Size = new System.Drawing.Size(279, 21);
            this.exportPathInputBox.TabIndex = 9;
            // 
            // exportButton
            // 
            this.exportButton.Location = new System.Drawing.Point(329, 83);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(83, 21);
            this.exportButton.TabIndex = 10;
            this.exportButton.Text = "导出路径";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // openAssetMessageButton
            // 
            this.openAssetMessageButton.Location = new System.Drawing.Point(311, 363);
            this.openAssetMessageButton.Name = "openAssetMessageButton";
            this.openAssetMessageButton.Size = new System.Drawing.Size(101, 30);
            this.openAssetMessageButton.TabIndex = 11;
            this.openAssetMessageButton.Text = "查 看";
            this.openAssetMessageButton.UseVisualStyleBackColor = true;
            this.openAssetMessageButton.Click += new System.EventHandler(this.openAssetMessageButton_Click);
            // 
            // ExcelTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 405);
            this.Controls.Add(this.openAssetMessageButton);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.exportPathInputBox);
            this.Controls.Add(this.codingGroup);
            this.Controls.Add(this.formatGroup);
            this.Controls.Add(this.convertButton);
            this.Controls.Add(this.countLabel);
            this.Controls.Add(this.excelListBox);
            this.Controls.Add(this.stateLabel);
            this.Controls.Add(this.converModeBox);
            this.Controls.Add(this.selectButton);
            this.Controls.Add(this.importPathTextBox);
            this.Name = "ExcelTool";
            this.Text = "Excel Conversion Tool";
            this.converModeBox.ResumeLayout(false);
            this.converModeBox.PerformLayout();
            this.formatGroup.ResumeLayout(false);
            this.formatGroup.PerformLayout();
            this.codingGroup.ResumeLayout(false);
            this.codingGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox importPathTextBox;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.GroupBox converModeBox;
        private System.Windows.Forms.RadioButton multipleToggle;
        private System.Windows.Forms.RadioButton singleToggle;
        private System.Windows.Forms.Label stateLabel;
        private System.Windows.Forms.ListBox excelListBox;
        private System.Windows.Forms.Label countLabel;
        private System.Windows.Forms.Button convertButton;
        private System.Windows.Forms.GroupBox formatGroup;
        private System.Windows.Forms.RadioButton csvToggle;
        private System.Windows.Forms.RadioButton xmlToggle;
        private System.Windows.Forms.RadioButton jsonToggle;
        private System.Windows.Forms.GroupBox codingGroup;
        private System.Windows.Forms.RadioButton gbToggle;
        private System.Windows.Forms.RadioButton utf8Toggle;
        private System.Windows.Forms.TextBox exportPathInputBox;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Button openAssetMessageButton;
    }
}

