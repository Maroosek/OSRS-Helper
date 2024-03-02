using System.ComponentModel.DataAnnotations;

namespace OSRSHelper.Models
{
	public class FarmSpot
	{
		[Key]
        public int SpotId { get; set; }
		public required string SpotName { get; set; }
		public required int Time { get; set; }
    }
}
