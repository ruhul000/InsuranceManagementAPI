namespace InsuranceManagementAPI.Models
{
    public class MotorTariff
    {
        public int TariffKey { get; set; }
        public string TarrifType { get;set; }
        public string Category { get; set; }
        public decimal Basic { get; set; }
        public decimal Own_datage_theft { get; set; }
        public decimal Cyclone {  get; set; }    
        public decimal Earthquake {  get; set; }
        public decimal Strike { get; set; }
        public decimal Act_Liability { get; set; }
        public decimal Driver { get; set; }
        public decimal Passenger { get; set; }
        public decimal Tracking_Device { get; set; }

    }
}
