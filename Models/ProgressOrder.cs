using System.ComponentModel.DataAnnotations;

namespace ManagerInvoice.Models
{
    public class ProgressOrder
    {
        [Key]
        public int PO_ID { get; set; }
        public int H_ORDER_NO { get; set; }
        public int H_ORDER_INT { get; set; }
        public int HISTORY_ID { get; set; }
        public int HISTORY_STATUS { get; set; }
        public string? HISTORY_COMMIT_BY { get; set; }
        [DataType(DataType.Date)]
        public DateTime HISTORY_CREATED_DATE { get; set; }

    }
}
