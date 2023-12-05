using Microsoft.Maui.Layouts;

namespace Poster;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		AutoWrapBody();
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
		catch (Exception ex) when (ex is HttpRequestException or InvalidOperationException)
		{
			responseStatusBox.Text = ex.Message;
			responseStatusBox.TextColor = Colors.Red;
		}
	}

	private void OnBodySizeChanged(object sender, EventArgs e)
	{
		AutoWrapBody();
	}

	static FlexBasis
		s_leftBasis = new(.58f, true),
		s_rightBasis = new(.4f, true);
	private void AutoWrapBody()
	{
		if (body.Width >= 600)
		{
			body.Direction = FlexDirection.Row;
			FlexLayout.SetBasis(leftPanel, s_leftBasis);
			FlexLayout.SetBasis(rightPanel, s_rightBasis);
		}
		else
		{
			body.Direction = FlexDirection.Column;
			FlexLayout.SetBasis(leftPanel, s_rightBasis);
			FlexLayout.SetBasis(rightPanel, s_leftBasis);
		}
	}
}

