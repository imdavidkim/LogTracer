using System.Windows.Forms;

namespace Tracer
{
    public class ListViewExt : System.Windows.Forms.ListView
    {
        public ListViewExt()
        {
            this.SetStyle(System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer | System.Windows.Forms.ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(System.Windows.Forms.ControlStyles.EnableNotifyMessage, true);
        }
        protected override void OnNotifyMessage(Message m)
        {
            if(m.Msg != 0x14) base.OnNotifyMessage(m);
        }
    }
    partial class ChildForm
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
            this.listView1 = new ListViewExt();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.ForeColor = System.Drawing.Color.White;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(904, 316);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.CacheVirtualItems += new System.Windows.Forms.CacheVirtualItemsEventHandler(this.listView1_CacheVirtualItems);
            this.listView1.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.listView1_RetrieveVirtualItem);
            //this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.Resize += new System.EventHandler(this.listView1_Resize);
            this.listView1.Font = new System.Drawing.Font("Courier New", 9);
            this.listView1.ShowItemToolTips = true;
            this.listView1.FullRowSelect = true;
            this.listView1.KeyUp += new KeyEventHandler(this.listView1_KeyUp);
            // 
            // ChildForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 316);
            this.Controls.Add(this.listView1);
            this.Name = "ChildForm";
            this.Text = "ChildForm";
            this.ResumeLayout(false);

        }



        #endregion

        //private System.Windows.Forms.ListView listView1;
        private ListViewExt listView1;
        private System.Windows.Forms.ListViewItem[] myCache;
        private int firstItem;
    }
}
