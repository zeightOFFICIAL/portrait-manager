
namespace PathfinderKingmakerPortraitManager.AuxForms
{
    partial class UrlDialog
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
            this.ButtonDeny = new System.Windows.Forms.Button();
            this.ButtonLoad = new System.Windows.Forms.Button();
            this.LayoutTextEdit = new System.Windows.Forms.TableLayoutPanel();
            this.TextBoxMain = new System.Windows.Forms.TextBox();
            this.LabelMain = new System.Windows.Forms.Label();
            this.LayoutMain.SuspendLayout();
            this.LayoutButtons.SuspendLayout();
            this.LayoutTextEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // LayoutMain
            // 
            this.LayoutMain.AllowDrop = true;
            this.LayoutMain.BackColor = System.Drawing.Color.Black;
            this.LayoutMain.ColumnCount = 1;
            this.LayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutMain.Controls.Add(this.LayoutButtons, 0, 3);
            this.LayoutMain.Controls.Add(this.LayoutTextEdit, 0, 2);
            this.LayoutMain.Controls.Add(this.LabelMain, 0, 1);
            this.LayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutMain.ForeColor = System.Drawing.Color.White;
            this.LayoutMain.Location = new System.Drawing.Point(0, 0);
            this.LayoutMain.Name = "LayoutMain";
            this.LayoutMain.RowCount = 5;
            this.LayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.14629F));
            this.LayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 39.62264F));
            this.LayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.03773F));
            this.LayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.22642F));
            this.LayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.14629F));
            this.LayoutMain.Size = new System.Drawing.Size(531, 212);
            this.LayoutMain.TabIndex = 0;
            // 
            // LayoutButtons
            // 
            this.LayoutButtons.ColumnCount = 5;
            this.LayoutButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.2381F));
            this.LayoutButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.38095F));
            this.LayoutButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.761905F));
            this.LayoutButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.38095F));
            this.LayoutButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.2381F));
            this.LayoutButtons.Controls.Add(this.ButtonDeny, 1, 0);
            this.LayoutButtons.Controls.Add(this.ButtonLoad, 3, 0);
            this.LayoutButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutButtons.Location = new System.Drawing.Point(3, 144);
            this.LayoutButtons.Name = "LayoutButtons";
            this.LayoutButtons.RowCount = 1;
            this.LayoutButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutButtons.Size = new System.Drawing.Size(525, 39);
            this.LayoutButtons.TabIndex = 0;
            // 
            // ButtonDeny
            // 
            this.ButtonDeny.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonDeny.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonDeny.Font = new System.Drawing.Font("Bebas Neue", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonDeny.ForeColor = System.Drawing.SystemColors.Control;
            this.ButtonDeny.Location = new System.Drawing.Point(83, 3);
            this.ButtonDeny.Name = "ButtonDeny";
            this.ButtonDeny.Size = new System.Drawing.Size(163, 33);
            this.ButtonDeny.TabIndex = 0;
            this.ButtonDeny.Text = "Cancel";
            this.ButtonDeny.UseVisualStyleBackColor = true;
            this.ButtonDeny.Click += new System.EventHandler(this.ButtonDeny_Click);
            // 
            // ButtonLoad
            // 
            this.ButtonLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonLoad.Font = new System.Drawing.Font("Bebas Neue", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonLoad.ForeColor = System.Drawing.SystemColors.Control;
            this.ButtonLoad.Location = new System.Drawing.Point(277, 3);
            this.ButtonLoad.Name = "ButtonLoad";
            this.ButtonLoad.Size = new System.Drawing.Size(163, 33);
            this.ButtonLoad.TabIndex = 1;
            this.ButtonLoad.Text = "Load";
            this.ButtonLoad.UseVisualStyleBackColor = true;
            this.ButtonLoad.Click += new System.EventHandler(this.ButtonLoad_Click);
            // 
            // LayoutTextEdit
            // 
            this.LayoutTextEdit.ColumnCount = 3;
            this.LayoutTextEdit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.3453F));
            this.LayoutTextEdit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.31396F));
            this.LayoutTextEdit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.34074F));
            this.LayoutTextEdit.Controls.Add(this.TextBoxMain, 1, 0);
            this.LayoutTextEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutTextEdit.Location = new System.Drawing.Point(3, 110);
            this.LayoutTextEdit.Name = "LayoutTextEdit";
            this.LayoutTextEdit.RowCount = 1;
            this.LayoutTextEdit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutTextEdit.Size = new System.Drawing.Size(525, 28);
            this.LayoutTextEdit.TabIndex = 1;
            // 
            // TextBoxMain
            // 
            this.TextBoxMain.AllowDrop = true;
            this.TextBoxMain.BackColor = System.Drawing.Color.Black;
            this.TextBoxMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBoxMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextBoxMain.ForeColor = System.Drawing.Color.Gray;
            this.TextBoxMain.Location = new System.Drawing.Point(57, 3);
            this.TextBoxMain.Name = "TextBoxMain";
            this.TextBoxMain.Size = new System.Drawing.Size(410, 24);
            this.TextBoxMain.TabIndex = 0;
            this.TextBoxMain.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBoxMain.WordWrap = false;
            this.TextBoxMain.DragDrop += new System.Windows.Forms.DragEventHandler(this.TexteditUrl_DragDrop);
            this.TextBoxMain.DragEnter += new System.Windows.Forms.DragEventHandler(this.TexteditUrl_DragEnter);
            // 
            // LabelMain
            // 
            this.LabelMain.AutoSize = true;
            this.LabelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelMain.Font = new System.Drawing.Font("Bebas Neue", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelMain.ForeColor = System.Drawing.SystemColors.Control;
            this.LabelMain.Location = new System.Drawing.Point(10, 26);
            this.LabelMain.Margin = new System.Windows.Forms.Padding(10, 3, 10, 0);
            this.LabelMain.Name = "LabelMain";
            this.LabelMain.Size = new System.Drawing.Size(511, 81);
            this.LabelMain.TabIndex = 2;
            this.LabelMain.Text = "Drag and drop, input, or copy the URL of an existing image. The URL-address must " +
    "lead to an accessible web-source. ";
            this.LabelMain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UrlDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(531, 212);
            this.ControlBox = false;
            this.Controls.Add(this.LayoutMain);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(531, 212);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(531, 212);
            this.Name = "UrlDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "UrlDialog";
            this.LayoutMain.ResumeLayout(false);
            this.LayoutMain.PerformLayout();
            this.LayoutButtons.ResumeLayout(false);
            this.LayoutTextEdit.ResumeLayout(false);
            this.LayoutTextEdit.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel LayoutMain;
        private System.Windows.Forms.TableLayoutPanel LayoutButtons;
        private System.Windows.Forms.TableLayoutPanel LayoutTextEdit;
        private System.Windows.Forms.Button ButtonDeny;
        private System.Windows.Forms.Button ButtonLoad;
        private System.Windows.Forms.TextBox TextBoxMain;
        private System.Windows.Forms.Label LabelMain;
    }
}