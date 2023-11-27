namespace WinForms
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private async void sendButton_Click(object sender, EventArgs e)
		{
			statusLabel.Text = "Sending...";
			resultBox.Text = string.Empty;
			await SendAsync();
		}

		private async Task SendAsync()
		{
			HttpClient client = new()
			{
				Timeout = TimeSpan.FromSeconds(120)
			};
			var content = new StringContent(postBodyBox.Text, null, mediaType: contentTypeBox.Text);
			var result = await client.PostAsync(urlText.Text, content);
			statusLabel.Text = result.StatusCode.ToString();
			var response = await result.Content.ReadAsStringAsync();
			resultBox.Text = response;
		}

		private void urlText_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
				sendButton_Click(sender, e);
		}
	}
}