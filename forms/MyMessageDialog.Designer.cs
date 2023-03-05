
namespace PathfinderPortraitManager.Forms
{
    partial class MyMessageDialog
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
            this.LayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.LayoutButtons = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonOK = new System.Windows.Forms.Button();
            this.LabelMain = new System.Windows.Forms.Label();
            this.LayoutMain.SuspendLayout();
            this.LayoutButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // LayoutMain
            // 
            this.LayoutMain.ColumnCount = 1;
            this.LayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutMain.Controls.Add(this.LayoutButtons, 0, 2);
            this.LayoutMain.Controls.Add(this.LabelMain, 0, 1);
            this.LayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutMain.Location = new System.Drawing.Point(0, 0);
            this.LayoutMain.Name = "LayoutMain";
            this.LayoutMain.RowCount = 4;
            this.LayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.LayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.42857F));
            this.LayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.42857F));
            this.LayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.LayoutMain.Size = new System.Drawing.Size(400, 140);
            this.LayoutMain.TabIndex = 0;
            // 
            // LayoutButtons
            // 
            this.LayoutButtons.ColumnCount = 3;
            this.LayoutButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.LayoutButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.LayoutButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.LayoutButtons.Controls.Add(this.ButtonOK, 1, 0);
            this.LayoutButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutButtons.Location = new System.Drawing.Point(3, 86);
            this.LayoutButtons.Name = "LayoutButtons";
            this.LayoutButtons.RowCount = 1;
            this.LayoutButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutButtons.Size = new System.Drawing.Size(394, 38);
            this.LayoutButtons.TabIndex = 0;
            // 
            // ButtonOK
            // 
            this.ButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ButtonOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonOK.Font = new System.Drawing.Font("Bebas Neue", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonOK.Location = new System.Drawing.Point(134, 3);
            this.ButtonOK.Name = "ButtonOK";
            this.ButtonOK.Size = new System.Drawing.Size(125, 32);
            this.ButtonOK.TabIndex = 1;
            this.ButtonOK.Text = "OK";
            this.ButtonOK.UseVisualStyleBackColor = true;
            this.ButtonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // LabelMain
            // 
            this.LabelMain.AutoSize = true;
            this.LabelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelMain.Font = new System.Drawing.Font("Bebas Neue", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelMain.Location = new System.Drawing.Point(3, 11);
            this.LabelMain.Name = "LabelMain";
            this.LabelMain.Size = new System.Drawing.Size(394, 72);
            this.LabelMain.TabIndex = 1;
            this.LabelMain.Text = "some text";
            this.LabelMain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MyMessageDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(400, 140);
            this.ControlBox = false;
            this.Controls.Add(this.LayoutMain);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 140);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 140);
            this.Name = "MyMessageDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "NoImageMessage";
            this.LayoutMain.ResumeLayout(false);
            this.LayoutMain.PerformLayout();
            this.LayoutButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel LayoutMain;
        private System.Windows.Forms.TableLayoutPanel LayoutButtons;
        private System.Windows.Forms.Button ButtonOK;
        private System.Windows.Forms.Label LabelMain;

    }
}