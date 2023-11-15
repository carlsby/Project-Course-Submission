namespace Project_Course_Submission.ViewModels
{
    public class AddressViewModel
    {
        public List<Address> Addresses { get; set; }
    }

    public class Address
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string FullAddress { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string StreetName { get; set; }
    }
}