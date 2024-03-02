namespace OSRSHelper.Models
{
	public class FarmSpot
	{
        public int FarmSpotId { get; set; }
		public required string SpotName { get; set; }
		public required int Time { get; set; }
		public required FarmType FarmType { get; set; }
		public int FarmTypeId { get; set; }
    }
}
