using System.ComponentModel.DataAnnotations.Schema;

namespace OSRSHelper.Models
{
	public class Product
	{
        public int ProductId { get; set; }
		public required string ProductName { get; set; }
		public int ProductValue { get; set; }
		public int ProductExperience { get; set; }
		public int MaterialId { get; set; }
		[ForeignKey("MaterialId")]
		public Material? Material { get; set; }
		//public virtual ICollection<Material>? Materials { get; set; }

    }
}
