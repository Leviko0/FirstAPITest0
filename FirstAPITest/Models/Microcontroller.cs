namespace FirstAPITest.Models
{
    public class Microcontroller
    {
        public int Id { get; set; }
        public string Model { get; set; } = null!;
        public string Manufacturer { get; set; } = null!;
        public int ClockFz { get; set; }
    }
}
