using System.ComponentModel.DataAnnotations;

namespace ManagerInvoice.Models
{
    public class Sector
    {
        [Key]
        public int H_SECTOR_ID { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? H_SECTOR { get; set; }
        public string? EMAIL { get; set; }
        public string? UPDATE_BY { get; set; }
        [DataType(DataType.Date)]
        public DateTime CREATED_DATE { get; set; }
        [DataType(DataType.Date)]
        public DateTime UPDATED_DATE { get; set; }
    }
}
