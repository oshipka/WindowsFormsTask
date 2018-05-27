using System.Windows.Forms;

namespace WinForm
{
    partial class DrawALine
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
        StatusBar mainStatusBar = new StatusBar();
        StatusBarPanel statusPanel = new StatusBarPanel();
        StatusBarPanel eventPanel = new StatusBarPanel();
        StatusBarPanel datetimePanel = new StatusBarPanel();
        private void CreateStatusBar()
        {
            statusPanel.BorderStyle = StatusBarPanelBorderStyle.Sunken;
            statusPanel.Text = "Application started. No location yet.";
            statusPanel.ToolTipText = "Last Location";
            statusPanel.AutoSize = StatusBarPanelAutoSize.Contents;
            mainStatusBar.Panels.Add(statusPanel);

            eventPanel.BorderStyle = StatusBarPanelBorderStyle.Sunken;
            eventPanel.Text = "Application started. No action yet.";
            eventPanel.ToolTipText = "Last Activity";
            eventPanel.AutoSize = StatusBarPanelAutoSize.Spring;
            mainStatusBar.Panels.Add(eventPanel);

            datetimePanel.BorderStyle = StatusBarPanelBorderStyle.Raised;
            datetimePanel.ToolTipText = "DateTime: " + System.DateTime.Today.ToString();
            datetimePanel.Text = System.DateTime.Today.ToLongDateString();
            datetimePanel.AutoSize = StatusBarPanelAutoSize.Contents;

            mainStatusBar.Panels.Add(datetimePanel);
            mainStatusBar.ShowPanels = true;
            Controls.Add(mainStatusBar);
        }


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shapesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawPan = new System.Windows.Forms.SplitContainer();
            this.panelDraw = new System.Windows.Forms.Panel();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drawPan)).BeginInit();
            this.drawPan.Panel1.SuspendLayout();
            this.drawPan.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.shapesToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(665, 24);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripSeparator1});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(100, 6);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drawToolStripMenuItem,
            this.moveToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // drawToolStripMenuItem
            // 
            this.drawToolStripMenuItem.Checked = true;
            this.drawToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.drawToolStripMenuItem.Name = "drawToolStripMenuItem";
            this.drawToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.drawToolStripMenuItem.Text = "Draw";
            // 
            // moveToolStripMenuItem
            // 
            this.moveToolStripMenuItem.Name = "moveToolStripMenuItem";
            this.moveToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.moveToolStripMenuItem.Text = "Move";
            // 
            // shapesToolStripMenuItem
            // 
            this.shapesToolStripMenuItem.Name = "shapesToolStripMenuItem";
            this.shapesToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.shapesToolStripMenuItem.Text = "Shapes";
            // 
            // drawPan
            // 
           //this.drawPan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawPan.IsSplitterFixed = true;
            this.drawPan.Location = new System.Drawing.Point(0, 24);
            this.drawPan.Name = "drawPan";
            this.drawPan.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // drawPan.Panel1
            // 
            this.drawPan.Panel1.Controls.Add(this.panelDraw);
            this.drawPan.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Draw);
            this.drawPan.Panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DrawMouseClick);
            this.drawPan.Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownHandler);
            this.drawPan.Panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveHandler);
            this.drawPan.Panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpHandler);
            this.drawPan.Size = new System.Drawing.Size(665, 419);
            this.drawPan.SplitterDistance = 348;
            this.drawPan.TabIndex = 2;
            // 
            // panelDraw
            // 
            this.panelDraw.Location = new System.Drawing.Point(3, 3);
            this.panelDraw.Name = "panelDraw";
            this.panelDraw.Size = new System.Drawing.Size(246, 392);
            this.panelDraw.TabIndex = 0;
            this.panelDraw.Paint += new System.Windows.Forms.PaintEventHandler(this.Draw);
            this.panelDraw.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DrawMouseClick);
            this.panelDraw.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownHandler);
            this.panelDraw.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveHandler);
            this.panelDraw.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpHandler);
            // 
            // DrawALine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 443);
            this.Controls.Add(this.drawPan);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.Name = "DrawALine";
            this.Text = "Draw It";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosingHandler);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ObjectMovingHandler);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.drawPan.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.drawPan)).EndInit();
            this.drawPan.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


      

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveToolStripMenuItem;
        private System.Windows.Forms.SplitContainer drawPan;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.ToolStripMenuItem shapesToolStripMenuItem;
        private Panel panelDraw;
    }
}

