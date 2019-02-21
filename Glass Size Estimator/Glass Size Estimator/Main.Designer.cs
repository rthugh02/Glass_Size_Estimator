﻿namespace Glass_Size_Estimator
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
            this.ExportButton = new System.Windows.Forms.Button();
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
            // ExportButton
            // 
            this.ExportButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ExportButton.Location = new System.Drawing.Point(287, 3);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(178, 43);
            this.ExportButton.TabIndex = 2;
            this.ExportButton.Text = "Export";
            this.ExportButton.UseVisualStyleBackColor = true;
            // 
            // EstimateButton
            // 
            this.EstimateButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.EstimateButton.Location = new System.Drawing.Point(539, 3);
            this.EstimateButton.Name = "EstimateButton";
            this.EstimateButton.Size = new System.Drawing.Size(178, 43);
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
            this.ProductLineSelector.Location = new System.Drawing.Point(12, 12);
            this.ProductLineSelector.MultiSelect = false;
            this.ProductLineSelector.Name = "ProductLineSelector";
            this.ProductLineSelector.ShowItemToolTips = true;
            this.ProductLineSelector.Size = new System.Drawing.Size(307, 664);
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
            this.ButtonLayoutPanel.Controls.Add(this.ExportButton, 1, 0);
            this.ButtonLayoutPanel.Location = new System.Drawing.Point(368, 625);
            this.ButtonLayoutPanel.Name = "ButtonLayoutPanel";
            this.ButtonLayoutPanel.RowCount = 1;
            this.ButtonLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ButtonLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.ButtonLayoutPanel.Size = new System.Drawing.Size(754, 49);
            this.ButtonLayoutPanel.TabIndex = 0;
            // 
            // ResetButton
            // 
            this.ResetButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ResetButton.Location = new System.Drawing.Point(36, 3);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(178, 43);
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
            this.InputLayoutPanel.Location = new System.Drawing.Point(404, 107);
            this.InputLayoutPanel.Name = "InputLayoutPanel";
            this.InputLayoutPanel.RowCount = 4;
            this.InputLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.00062F));
            this.InputLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.00063F));
            this.InputLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.00063F));
            this.InputLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.99813F));
            this.InputLayoutPanel.Size = new System.Drawing.Size(533, 142);
            this.InputLayoutPanel.TabIndex = 5;
            // 
            // OutputLayoutPanel
            // 
            this.OutputLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OutputLayoutPanel.ColumnCount = 2;
            this.OutputLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.OutputLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.OutputLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.OutputLayoutPanel.Location = new System.Drawing.Point(404, 420);
            this.OutputLayoutPanel.Name = "OutputLayoutPanel";
            this.OutputLayoutPanel.RowCount = 3;
            this.OutputLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.OutputLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.OutputLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.OutputLayoutPanel.Size = new System.Drawing.Size(533, 125);
            this.OutputLayoutPanel.TabIndex = 6;
            // 
            // InputLabel
            // 
            this.InputLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.InputLabel.AutoSize = true;
            this.InputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputLabel.Location = new System.Drawing.Point(531, 48);
            this.InputLabel.Name = "InputLabel";
            this.InputLabel.Size = new System.Drawing.Size(65, 25);
            this.InputLabel.TabIndex = 7;
            this.InputLabel.Text = "Inputs";
            // 
            // OutputLabel
            // 
            this.OutputLabel.AutoSize = true;
            this.OutputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutputLabel.Location = new System.Drawing.Point(532, 359);
            this.OutputLabel.Name = "OutputLabel";
            this.OutputLabel.Size = new System.Drawing.Size(81, 25);
            this.OutputLabel.TabIndex = 8;
            this.OutputLabel.Text = "Outputs";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1322, 696);
            this.Controls.Add(this.OutputLabel);
            this.Controls.Add(this.InputLabel);
            this.Controls.Add(this.OutputLayoutPanel);
            this.Controls.Add(this.InputLayoutPanel);
            this.Controls.Add(this.ButtonLayoutPanel);
            this.Controls.Add(this.ProductLineSelector);
            this.Name = "Main";
            this.Text = "Glass Estimator";
            this.ButtonLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ExportButton;
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

