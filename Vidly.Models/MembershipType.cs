namespace Vidly.Models
{
    public class MembershipType
    {
        public int Id { get; set; }
        public short SignUpFee { get; set; }
        public short DurationInMonths { get; set; }
        public double DiscountRate { get; set; }
    }
}
