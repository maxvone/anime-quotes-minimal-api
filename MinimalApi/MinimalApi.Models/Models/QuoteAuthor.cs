namespace MinimalApi.Models.Models
{
	public class QuoteAuthor
	{
		public int QuoteAuthorId { get; set; }
		public required string Name { get; set;}
		public required string AnimeName { get; set;}
		public required ICollection<Quote> Quotes {  get; set; }
	}
}
