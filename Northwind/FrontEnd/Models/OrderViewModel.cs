namespace FrontEnd.Models
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }

        public string CustomerId { get; set; }
        public IEnumerable<CustomerViewModel> Customers { get; set; }

        public int? EmployeeId { get; set; }
        public IEnumerable<EmployeeViewModel> Employees { get; set; }

        public DateTime? OrderDate { get; set; }

        public DateTime? RequiredDate { get; set; }

        public DateTime? ShippedDate { get; set; }

        public int? ShipVia { get; set; }

        public IEnumerable<ShipperViewModel> Shippers { get; set; }
    }
}
