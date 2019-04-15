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
			this.EstimateButton = new System.Windows.Forms.Button();
			this.ProductLineSelector = new System.Windows.Forms.ListView();
			this.ButtonLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.ResetButton = new System.Windows.Forms.Button();
			this.InputLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.OutputLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.InputLabel = new System.Windows.Forms.Label();
			this.OutputLabel = new System.Windows.Forms.Label();
			this.ButtonLayoutPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// EstimateButton
			// 
			this.EstimateButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.EstimateButton.Location = new System.Drawing.Point(461, 2);
			this.EstimateButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.EstimateButton.Name = "EstimateButton";
			this.EstimateButton.Size = new System.Drawing.Size(119, 28);
			this.EstimateButton.TabIndex = 3;
			this.EstimateButton.Text = "Estimate";
			this.EstimateButton.UseVisualStyleBackColor = true;
			this.EstimateButton.Click += new System.EventHandler(this.EstimateButton_Click);
			// 
			// ProductLineSelector
			// 
			this.ProductLineSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.ProductLineSelector.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ProductLineSelector.Location = new System.Drawing.Point(8, 8);
			this.ProductLineSelector.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.ProductLineSelector.MultiSelect = false;
			this.ProductLineSelector.Name = "ProductLineSelector";
			this.ProductLineSelector.ShowItemToolTips = true;
			this.ProductLineSelector.Size = new System.Drawing.Size(206, 433);
			this.ProductLineSelector.TabIndex = 4;
			this.ProductLineSelector.UseCompatibleStateImageBehavior = false;
			this.ProductLineSelector.View = System.Windows.Forms.View.List;
			this.ProductLineSelector.SelectedIndexChanged += new System.EventHandler(this.ProductLineSelector_SelectedIndexChanged);
			// 
			// ButtonLayoutPanel
			// 
			this.ButtonLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ButtonLayoutPanel.AutoSize = true;
			this.ButtonLayoutPanel.ColumnCount = 3;
			this.ButtonLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.ButtonLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
			this.ButtonLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
			this.ButtonLayoutPanel.Controls.Add(this.EstimateButton, 2, 0);
			this.ButtonLayoutPanel.Controls.Add(this.ResetButton, 0, 0);
			this.ButtonLayoutPanel.Location = new System.Drawing.Point(245, 406);
			this.ButtonLayoutPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.ButtonLayoutPanel.Name = "ButtonLayoutPanel";
			this.ButtonLayoutPanel.RowCount = 1;
			this.ButtonLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.ButtonLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
			this.ButtonLayoutPanel.Size = new System.Drawing.Size(625, 32);
			this.ButtonLayoutPanel.TabIndex = 0;
			// 
			// ResetButton
			// 
			this.ResetButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.ResetButton.Location = new System.Drawing.Point(44, 2);
			this.ResetButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.ResetButton.Name = "ResetButton";
			this.ResetButton.Size = new System.Drawing.Size(119, 28);
			this.ResetButton.TabIndex = 4;
			this.ResetButton.Text = "Reset";
			this.ResetButton.UseVisualStyleBackColor = true;
			this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
			// 
			// InputLayoutPanel
			// 
			this.InputLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.InputLayoutPanel.ColumnCount = 2;
			this.InputLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.InputLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.InputLayoutPanel.Location = new System.Drawing.Point(289, 47);
			this.InputLayoutPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.InputLayoutPanel.Name = "InputLayoutPanel";
			this.InputLayoutPanel.RowCount = 6;
			this.InputLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.InputLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.InputLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.InputLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.InputLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.InputLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.InputLayoutPanel.Size = new System.Drawing.Size(536, 135);
			this.InputLayoutPanel.TabIndex = 5;
			// 
			// OutputLayoutPanel
			// 
			this.OutputLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.OutputLayoutPanel.ColumnCount = 2;
			this.OutputLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.OutputLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.OutputLayoutPanel.Location = new System.Drawing.Point(289, 244);
			this.OutputLayoutPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.OutputLayoutPanel.Name = "OutputLayoutPanel";
			this.OutputLayoutPanel.RowCount = 6;
			this.OutputLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.OutputLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.OutputLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.OutputLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.OutputLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.OutputLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.OutputLayoutPanel.Size = new System.Drawing.Size(536, 135);
			this.OutputLayoutPanel.TabIndex = 6;
			// 
			// InputLabel
			// 
			this.InputLabel.AutoSize = true;
			this.InputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.InputLabel.Location = new System.Drawing.Point(240, 9);
			this.InputLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.InputLabel.Name = "InputLabel";
			this.InputLabel.Size = new System.Drawing.Size(76, 25);
			this.InputLabel.TabIndex = 8;
			this.InputLabel.Text = "Inputs";
			// 
			// OutputLabel
			// 
			this.OutputLabel.AutoSize = true;
			this.OutputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.OutputLabel.Location = new System.Drawing.Point(240, 208);
			this.OutputLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.OutputLabel.Name = "OutputLabel";
			this.OutputLabel.Size = new System.Drawing.Size(94, 25);
			this.OutputLabel.TabIndex = 8;
			this.OutputLabel.Text = "Outputs";
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(881, 452);
			this.Controls.Add(this.OutputLabel);
			this.Controls.Add(this.InputLabel);
			this.Controls.Add(this.OutputLayoutPanel);
			this.Controls.Add(this.InputLayoutPanel);
			this.Controls.Add(this.ButtonLayoutPanel);
			this.Controls.Add(this.ProductLineSelector);
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.Name = "Main";
			this.Text = "Glass Estimator";
			this.ButtonLayoutPanel.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button EstimateButton;
        private System.Windows.Forms.ListView ProductLineSelector;
        private System.Windows.Forms.TableLayoutPanel ButtonLayoutPanel;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.TableLayoutPanel InputLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel OutputLayoutPanel;
        private System.Windows.Forms.Label InputLabel;
        private System.Windows.Forms.Label OutputLabel;
    }
}

