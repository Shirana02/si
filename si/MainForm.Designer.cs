﻿namespace si {
	partial class MainForm {
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			oex = new Oex.OexPanel();
			SuspendLayout();
			// 
			// oex
			// 
			oex.Dock = DockStyle.Fill;
			oex.Location = new Point(0, 0);
			oex.Name = "oex";
			oex.SelectionEndIdx = 0;
			oex.SelectionStartIdx = 0;
			oex.Size = new Size(800, 450);
			oex.TabIndex = 1;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(oex);
			Name = "MainForm";
			Text = "si";
			Load += MainForm_Load;
			Shown += MainForm_Shown;
			ResumeLayout(false);
		}

		#endregion

		private Oex.OexPanel oex;
	}
}