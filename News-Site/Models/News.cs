﻿namespace News_Site.Models
{
	public class News
	{
		public int NewsId { get; set; }
		public string NewsName { get; set;}
		public string NewsHeader { get; set;}
		public string NewsSubtitle { get; set;}
		public byte[] NewsImage { get; set;}
		public string NewsText { get; set;}

	}
}