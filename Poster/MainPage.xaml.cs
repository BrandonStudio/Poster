namespace Poster;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private void OnUrlChanged(object sender, TextChangedEventArgs e)
	{
		if (string.IsNullOrWhiteSpace(urlInput.Text))
			urlHintLabel.Text = "URL";
		else if (!urlInput.Text.StartsWith("http://") && !urlInput.Text.StartsWith("https://"))
			urlHintLabel.Text = "http://" + urlInput.Text;
		else
			urlHintLabel.Text = urlInput.Text;
	}

	private async void StartSend(object sender, EventArgs e)
	{
		responseStatusBox.Text = "Sending...";
		responseStatusBox.TextColor = Colors.Gray;
		responseBodyBox.Text = string.Empty;
		await SendAsync();
	}

	private async Task SendAsync()
	{
		HttpClient client = new()
		{
			Timeout = TimeSpan.FromSeconds(120)
		};
		HttpContent content = null;
		if (!string.IsNullOrWhiteSpace(requestBodyInput.Text))
			content = new StringContent(requestBodyInput.Text, null, mediaType: contentTypeInput.Text);
		try
		{
			var result = await client.PostAsync(urlHintLabel.Text, content);
			responseStatusBox.Text = result.StatusCode.ToString();
			if (!result.IsSuccessStatusCode)
				responseStatusBox.TextColor = Colors.Red;
			else
				responseStatusBox.TextColor = Colors.Green;
			var response = await result.Content.ReadAsStringAsync();
			responseBodyBox.Text = response;
		}
		catch (HttpRequestException ex)
		{
			responseStatusBox.Text = ex.Message;
			responseStatusBox.TextColor = Colors.Red;
		}
	}
}

