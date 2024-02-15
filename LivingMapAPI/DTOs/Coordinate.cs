namespace LivingMapAPI.DTOs
{
    public class Coordinate
    {
        public Coordinate() { }

        public Coordinate(double x, double y) 
        { 
            X = x; 
            Y = y;
        }
        public double X { get; set; }
        public double Y { get; set; }
    }
}
