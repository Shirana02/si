﻿namespace si {
	partial class OedForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			oed = new Oed.OedPanel();
			SuspendLayout();
			// 
			// oed
			// 
			oed.Dock = DockStyle.Fill;
			oed.Location = new Point(0, 0);
			oed.Name = "oed";
			oed.Size = new Size(800, 450);
			oed.TabIndex = 0;
			// 
			// OedForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(oed);
			Name = "OedForm";
			Text = "OedForm";
			ResumeLayout(false);
		}

		#endregion

		private Oed.OedPanel oed;
	}
}