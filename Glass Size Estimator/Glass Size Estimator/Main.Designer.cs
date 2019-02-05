namespace Glass_Size_Estimator
{
    partial class Main
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
            this.RestButton = new System.Windows.Forms.Button();
            this.ExportButton = new System.Windows.Forms.Button();
            this.MiscButton = new System.Windows.Forms.Button();
            this.ProductLineSelector = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // RestButton
            // 
            this.RestButton.Location = new System.Drawing.Point(333, 633);
            this.RestButton.Name = "RestButton";
            this.RestButton.Size = new System.Drawing.Size(178, 43);
            this.RestButton.TabIndex = 1;
            this.RestButton.Text = "Reset";
            this.RestButton.UseVisualStyleBackColor = true;
            // 
            // ExportButton
            // 
            this.ExportButton.Location = new System.Drawing.Point(667, 633);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(178, 43);
            this.ExportButton.TabIndex = 2;
            this.ExportButton.Text = "Export";
            this.ExportButton.UseVisualStyleBackColor = true;
            // 
            // MiscButton
            // 
            this.MiscButton.Location = new System.Drawing.Point(1005, 633);
            this.MiscButton.Name = "MiscButton";
            this.MiscButton.Size = new System.Drawing.Size(178, 43);
            this.MiscButton.TabIndex = 3;
            this.MiscButton.Text = "Misc.";
            this.MiscButton.UseVisualStyleBackColor = true;
            // 
            // ProductLineSelector
            // 
            this.ProductLineSelector.Location = new System.Drawing.Point(12, 12);
            this.ProductLineSelector.Name = "ProductLineSelector";
            this.ProductLineSelector.Size = new System.Drawing.Size(218, 664);
            this.ProductLineSelector.TabIndex = 4;
            this.ProductLineSelector.UseCompatibleStateImageBehavior = false;
            this.ProductLineSelector.View = System.Windows.Forms.View.List;
            this.ProductLineSelector.SelectedIndexChanged += new System.EventHandler(this.ProductLineSelector_SelectedIndexChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1322, 696);
            this.Controls.Add(this.ProductLineSelector);
            this.Controls.Add(this.MiscButton);
            this.Controls.Add(this.ExportButton);
            this.Controls.Add(this.RestButton);
            this.Name = "Main";
            this.Text = "Glass Estimator";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button RestButton;
        private System.Windows.Forms.Button ExportButton;
        private System.Windows.Forms.Button MiscButton;
        private System.Windows.Forms.ListView ProductLineSelector;
    }
}

