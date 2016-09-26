namespace TicTacToeWinForms.UI
{
    partial class GameConfigurationDialog
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
            if (disposing && (components != null)) {
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
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(447, 436);
            this.propertyGrid1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 436);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(447, 37);
            this.panel1.TabIndex = 1;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(360, 6);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Cancel";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(12, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Ok";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // PlayerConfigurationDialog
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(447, 473);
            this.ControlBox = false;
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "GameConfigurationDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Game Configuration";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
    }
}