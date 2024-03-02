namespace OSRSHelper.Models
{
	public class Product
	{
        public int ProductId { get; set; }
		public required string ProductName { get; set; }
		public required int ProductValue { get; set; }
		public required int ProductExperience { get; set; }
		public required FarmType FarmType { get; set; }
		public int FarmTypeId { get; set; }
		public required Material Material { get; set; }
		public int MaterialId { get; set; }
		public Material? MaterialSecond { get; set; }
		public int? MaterialSecondId { get; set; }
	}
}
