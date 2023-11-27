namespace WinForms
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			urlText = new TextBox();
			contentTypeBox = new TextBox();
			postBodyBox = new TextBox();
			sendButton = new Button();
			statusLabel = new Label();
			resultBox = new TextBox();
			SuspendLayout();
			// 
			// urlText
			// 
			urlText.Location = new Point(85, 25);
			urlText.Name = "urlText";
			urlText.Size = new Size(1179, 38);
			urlText.TabIndex = 0;
			urlText.KeyPress += urlText_KeyPress;
			// 
			// contentTypeBox
			// 
			contentTypeBox.Location = new Point(85, 137);
			contentTypeBox.Name = "contentTypeBox";
			contentTypeBox.Size = new Size(339, 38);
			contentTypeBox.TabIndex = 1;
			contentTypeBox.Text = "application/json";
			// 
			// postBodyBox
			// 
			postBodyBox.AcceptsReturn = true;
			postBodyBox.Location = new Point(85, 211);
			postBodyBox.Multiline = true;
			postBodyBox.Name = "postBodyBox";
			postBodyBox.Size = new Size(682, 506);
			postBodyBox.TabIndex = 2;
			// 
			// sendButton
			// 
			sendButton.Location = new Point(1344, 20);
			sendButton.Name = "sendButton";
			sendButton.Size = new Size(150, 46);
			sendButton.TabIndex = 3;
			sendButton.Text = "Send";
			sendButton.UseVisualStyleBackColor = true;
			sendButton.Click += sendButton_Click;
			// 
			// statusLabel
			// 
			statusLabel.Location = new Point(851, 87);
			statusLabel.Name = "statusLabel";
			statusLabel.Size = new Size(621, 88);
			statusLabel.TabIndex = 4;
			statusLabel.Text = "label1";
			// 
			// resultBox
			// 
			resultBox.Location = new Point(851, 211);
			resultBox.Multiline = true;
			resultBox.Name = "resultBox";
			resultBox.ReadOnly = true;
			resultBox.Size = new Size(621, 506);
			resultBox.TabIndex = 5;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(14F, 31F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1543, 777);
			Controls.Add(resultBox);
			Controls.Add(statusLabel);
			Controls.Add(sendButton);
			Controls.Add(postBodyBox);
			Controls.Add(contentTypeBox);
			Controls.Add(urlText);
			Name = "Form1";
			Text = "Form1";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox urlText;
		private TextBox contentTypeBox;
		private TextBox postBodyBox;
		private Button sendButton;
		private Label statusLabel;
		private TextBox resultBox;
	}
}