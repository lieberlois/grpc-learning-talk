namespace SushiOrderClient.Dtos
{
    public class CreateOrderDto
    {
        public string UserName { get; set; }
        public int M1Count { get; set; }
        public int M2Count { get; set; }
        public int M3Count { get; set; }
        public int M4Count { get; set; }
        public int SpringRollCount { get; set; }

        public override string ToString()
        {
            return $"{this.UserName} - M1: {this.M1Count} - M2: {this.M2Count} - M3: {this.M3Count} - M4: {this.M4Count} - Veg. Spring Rolls: {this.SpringRollCount}";
        }
    }
}