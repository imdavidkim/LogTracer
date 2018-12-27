namespace Tracer
{
    partial class main_window
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main_window));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileMonitorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemMonitorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.envSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.remoteCmdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jMonServiceStopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jMonServiceStartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qMonServiceStopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qMonServiceStartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.settingToolStripMenuItem,
            this.remoteCmdToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1092, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMonitorToolStripMenuItem,
            this.systemMonitorToolStripMenuItem});
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // fileMonitorToolStripMenuItem
            // 
            this.fileMonitorToolStripMenuItem.Name = "fileMonitorToolStripMenuItem";
            this.fileMonitorToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.fileMonitorToolStripMenuItem.Text = "FileMonitor";
            this.fileMonitorToolStripMenuItem.Click += new System.EventHandler(this.fileMonitorToolStripMenuItem_Click);
            // 
            // systemMonitorToolStripMenuItem
            // 
            this.systemMonitorToolStripMenuItem.Name = "systemMonitorToolStripMenuItem";
            this.systemMonitorToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.systemMonitorToolStripMenuItem.Text = "SystemMonitor";
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.envSettingToolStripMenuItem});
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.settingToolStripMenuItem.Text = "Setting";
            // 
            // envSettingToolStripMenuItem
            // 
            this.envSettingToolStripMenuItem.Name = "envSettingToolStripMenuItem";
            this.envSettingToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.envSettingToolStripMenuItem.Text = "환경설정";
            this.envSettingToolStripMenuItem.Click += new System.EventHandler(this.envSettingToolStripMenuItem_Click);
            // 
            // remoteCmdToolStripMenuItem
            // 
            this.remoteCmdToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jMonServiceStopToolStripMenuItem,
            this.jMonServiceStartToolStripMenuItem,
            this.qMonServiceStopToolStripMenuItem,
            this.qMonServiceStartToolStripMenuItem});
            this.remoteCmdToolStripMenuItem.Name = "remoteCmdToolStripMenuItem";
            this.remoteCmdToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.remoteCmdToolStripMenuItem.Text = "RemoteCmd";
            // 
            // jMonServiceStopToolStripMenuItem
            // 
            this.jMonServiceStopToolStripMenuItem.Name = "jMonServiceStopToolStripMenuItem";
            this.jMonServiceStopToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.jMonServiceStopToolStripMenuItem.Text = "JMon Service Stop";
            this.jMonServiceStopToolStripMenuItem.Click += new System.EventHandler(this.jMonServiceStopToolStripMenuItem_Click);
            // 
            // jMonServiceStartToolStripMenuItem
            // 
            this.jMonServiceStartToolStripMenuItem.Name = "jMonServiceStartToolStripMenuItem";
            this.jMonServiceStartToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.jMonServiceStartToolStripMenuItem.Text = "JMon Service Start";
            this.jMonServiceStartToolStripMenuItem.Click += new System.EventHandler(this.jMonServiceStartToolStripMenuItem_Click);
            // 
            // qMonServiceStopToolStripMenuItem
            // 
            this.qMonServiceStopToolStripMenuItem.Name = "qMonServiceStopToolStripMenuItem";
            this.qMonServiceStopToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.qMonServiceStopToolStripMenuItem.Text = "QMon Service Stop";
            this.qMonServiceStopToolStripMenuItem.Click += new System.EventHandler(this.qMonServiceStopToolStripMenuItem_Click);
            // 
            // qMonServiceStartToolStripMenuItem
            // 
            this.qMonServiceStartToolStripMenuItem.Name = "qMonServiceStartToolStripMenuItem";
            this.qMonServiceStartToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.qMonServiceStartToolStripMenuItem.Text = "QMon Service Start";
            this.qMonServiceStartToolStripMenuItem.Click += new System.EventHandler(this.qMonServiceStartToolStripMenuItem_Click);
            // 
            // main_window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 693);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "main_window";
            this.Text = "LogTracer";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileMonitorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem systemMonitorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem envSettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem remoteCmdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jMonServiceStopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jMonServiceStartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem qMonServiceStopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem qMonServiceStartToolStripMenuItem;
    }
}

