namespace News_Site.ViewModels
{
	public class NewsViewModel
	{
		public string NewsName { get; set; }
		public string NewsHeader { get; set; }
		public string NewsSubtitle { get; set; }
		public IFormFile NewsImage { get; set; }
		public string NewsText { get; set; }
	}
}
