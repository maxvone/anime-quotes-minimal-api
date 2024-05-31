namespace MinimalApi.Models.Models
{
	public class Quote
	{
		public int Id { get; set; }
		public string? Content { get; set; }
		public int AuthorId { get; set; }
		public QuoteAuthor Author { get; set; }
	}
}
