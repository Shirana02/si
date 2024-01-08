namespace Oed {
	partial class OedPanel {
		/// <summary> 
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing) {
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region コンポーネント デザイナーで生成されたコード

		/// <summary> 
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent() {
			ktb_textArea = new kvi.KviTextBox();
			ktb_commandArea = new kvi.KviTextBox();
			SuspendLayout();
			// 
			// ktb_textArea
			// 
			ktb_textArea.Dock = DockStyle.Fill;
			ktb_textArea.Location = new Point(0, 0);
			ktb_textArea.Name = "ktb_textArea";
			ktb_textArea.Size = new Size(150, 126);
			ktb_textArea.TabIndex = 0;
			ktb_textArea.Text = "";
			// 
			// ktb_commandArea
			// 
			ktb_commandArea.Dock = DockStyle.Bottom;
			ktb_commandArea.Location = new Point(0, 126);
			ktb_commandArea.Multiline = false;
			ktb_commandArea.Name = "ktb_commandArea";
			ktb_commandArea.Size = new Size(150, 24);
			ktb_commandArea.TabIndex = 1;
			ktb_commandArea.Text = "";
			// 
			// OedPanel
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(ktb_textArea);
			Controls.Add(ktb_commandArea);
			Name = "OedPanel";
			ResumeLayout(false);
		}

		#endregion

		internal kvi.KviTextBox ktb_textArea;
		internal kvi.KviTextBox ktb_commandArea;
	}
}
