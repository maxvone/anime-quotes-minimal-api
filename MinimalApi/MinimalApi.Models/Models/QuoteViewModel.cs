namespace MinimalApi.Models.Models
{
	public class QuoteViewModel
	{
		public string? Content { get; set; }
		public string? Author { get; set; }
		public string? AnimeName { get; set; }

        public QuoteViewModel(Quote quote)
        {
			Content = quote.Content;
			Author = quote.Author?.Name;
			AnimeName = quote.Author?.AnimeName;
        }
    }
}
