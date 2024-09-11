using System.ComponentModel.DataAnnotations;

namespace ManagerInvoice.Models
{
    public class Image
    {
        [Key]
        public int A_ID { get; set; }
        public int H_ORDER_NO { get; set; }
        public int H_ORDER_INT { get; set; }
        public string? A_FILE { get; set; }
        [DataType(DataType.Date)]
        public DateTime A_CREATED_DATE { get; set; }

    }
}
