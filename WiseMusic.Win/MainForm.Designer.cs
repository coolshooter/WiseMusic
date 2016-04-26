namespace WiseMusic.Win
{
	partial class MainForm
	{
		/// <summary>
		/// Требуется переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Обязательный метод для поддержки конструктора - не изменяйте
		/// содержимое данного метода при помощи редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.rtxtResult = new System.Windows.Forms.RichTextBox();
			this.lstSourceSongs = new System.Windows.Forms.ListBox();
			this.rtxtChords = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// rtxtResult
			// 
			this.rtxtResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.rtxtResult.Location = new System.Drawing.Point(12, 206);
			this.rtxtResult.Name = "rtxtResult";
			this.rtxtResult.Size = new System.Drawing.Size(680, 287);
			this.rtxtResult.TabIndex = 0;
			this.rtxtResult.Text = "";
			// 
			// lstSourceSongs
			// 
			this.lstSourceSongs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lstSourceSongs.FormattingEnabled = true;
			this.lstSourceSongs.ItemHeight = 16;
			this.lstSourceSongs.Location = new System.Drawing.Point(12, 12);
			this.lstSourceSongs.Name = "lstSourceSongs";
			this.lstSourceSongs.Size = new System.Drawing.Size(472, 180);
			this.lstSourceSongs.TabIndex = 2;
			// 
			// rtxtChords
			// 
			this.rtxtChords.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.rtxtChords.Location = new System.Drawing.Point(490, 12);
			this.rtxtChords.Name = "rtxtChords";
			this.rtxtChords.Size = new System.Drawing.Size(202, 180);
			this.rtxtChords.TabIndex = 3;
			this.rtxtChords.Text = "";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(704, 505);
			this.Controls.Add(this.rtxtChords);
			this.Controls.Add(this.lstSourceSongs);
			this.Controls.Add(this.rtxtResult);
			this.Name = "MainForm";
			this.Text = "Подбор музыки по переходам тональностей (автор: Лютько Сергей)";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.RichTextBox rtxtResult;
		private System.Windows.Forms.ListBox lstSourceSongs;
		private System.Windows.Forms.RichTextBox rtxtChords;
	}
}

