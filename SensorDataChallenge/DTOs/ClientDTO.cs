namespace SensorDataChallenge.DTOs
{
    public class ClientDTO
    {
        public int Id { get; set; }
        public string BusinessName { get; set; }
        public int RucNum { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int PostalCode { get; set; }
        public enum Zone
        {
            Norte,
            Centro,
            Sur
        }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Web { get; set; }
        public enum UruguayTransit
        {
            Si,
            No,
            Opcional
        }
        public enum UruguayLooseCargoTransit
        {
            Si,
            No,
            Opcional
        }
        public bool IsActive { get; set; }
    }
}
