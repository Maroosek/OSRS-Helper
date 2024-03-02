using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OSRSHelper.Models
{
	public class FarmType
	{
		[Key]
        public int FarmId { get; set; }
		public required string FarmName { get; set; }
		public int MaterialId { get; set; }
		[ForeignKey("MaterialId")]
		public Material? Material { get; set; }
		public int ProductId { get; set; }
		[ForeignKey("ProductId")]
		public Product? Product { get; set; }
		public int FarmSpotId { get; set; }
		[ForeignKey("FarmSpotId")]
		public FarmSpot? FarmSpot { get; set; }
		//public virtual ICollection<Material>? Materials { get; set; }
		//public virtual ICollection<Product>? Products { get; set; }
		//public virtual ICollection<FarmSpot>? FarmSpots { get; set; }
	}
}
