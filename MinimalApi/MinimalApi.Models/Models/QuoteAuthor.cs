namespace MinimalApi.Models.Models
{
	public class QuoteAuthor
	{
		public int Id { get; set; }
		public string? Name { get; set;}
		public string? AnimeName { get; set;}
		public ICollection<Quote> Quotes { get; set; }
	}
}
