using System.Drawing.Drawing2D;

namespace Oex {
	partial class OexPanel {
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
			ktb_CurrentPath = new kvi.KviTextBox();
			ktb_CommandLine = new kvi.KviTextBox();
			flp_DisplayList = new FlowLayoutPanel();
			txt_DummyFocusCtrl_DisplayList = new TextBox();
			SuspendLayout();
			// 
			// ktb_CurrentPath
			// 
			ktb_CurrentPath.BackColor = SystemColors.Highlight;
			ktb_CurrentPath.Dock = DockStyle.Top;
			ktb_CurrentPath.Location = new Point(0, 0);
			ktb_CurrentPath.Name = "ktb_CurrentPath";
			ktb_CurrentPath.ScrollBars = RichTextBoxScrollBars.None;
			ktb_CurrentPath.Size = new Size(167, 23);
			ktb_CurrentPath.TabIndex = 0;
			ktb_CurrentPath.Text = "";
			// 
			// ktb_CommandLine
			// 
			ktb_CommandLine.Dock = DockStyle.Bottom;
			ktb_CommandLine.Location = new Point(0, 82);
			ktb_CommandLine.Name = "ktb_CommandLine";
			ktb_CommandLine.ScrollBars = RichTextBoxScrollBars.None;
			ktb_CommandLine.Size = new Size(167, 23);
			ktb_CommandLine.TabIndex = 2;
			ktb_CommandLine.Text = "";
			// 
			// flp_DisplayList
			// 
			flp_DisplayList.AutoScroll = true;
			flp_DisplayList.BackColor = SystemColors.ControlDark;
			flp_DisplayList.Dock = DockStyle.Fill;
			flp_DisplayList.FlowDirection = FlowDirection.TopDown;
			flp_DisplayList.Location = new Point(0, 23);
			flp_DisplayList.Name = "flp_DisplayList";
			flp_DisplayList.Size = new Size(167, 59);
			flp_DisplayList.TabIndex = 1;
			flp_DisplayList.WrapContents = false;
			flp_DisplayList.Click += FocusEvent_ToDummyFocusCtrl;
			// 
			// txt_DummyFocusCtrl_DisplayList
			// 
			txt_DummyFocusCtrl_DisplayList.Location = new Point(29, -1);
			txt_DummyFocusCtrl_DisplayList.Name = "txt_DummyFocusCtrl_DisplayList";
			txt_DummyFocusCtrl_DisplayList.ReadOnly = true;
			txt_DummyFocusCtrl_DisplayList.Size = new Size(100, 23);
			txt_DummyFocusCtrl_DisplayList.TabIndex = 3;
			txt_DummyFocusCtrl_DisplayList.Text = "hoge";
			txt_DummyFocusCtrl_DisplayList.WordWrap = false;
			txt_DummyFocusCtrl_DisplayList.KeyDown += KeyDownEvent_OexLogic;
			// 
			// OexPanel
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(flp_DisplayList);
			Controls.Add(ktb_CommandLine);
			Controls.Add(ktb_CurrentPath);
			Controls.Add(txt_DummyFocusCtrl_DisplayList);
			Name = "OexPanel";
			Size = new Size(167, 105);
			Load += OexPanel_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private kvi.KviTextBox ktb_CurrentPath;
		private kvi.KviTextBox ktb_CommandLine;
		private FlowLayoutPanel flp_DisplayList;
		private TextBox txt_DummyFocusCtrl_DisplayList;
	}
}
