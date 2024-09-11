using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagerInvoice.Models
{
    public class Order
    {
        [Key]
        public int H_ORDER_NO { get; set; }
        public int H_ORDER_INT { get; set; }
        public int H_SUPP_NO { get; set; }
        public string? H_SUPP_COM { get; set; }
        public string? H_SUP_NAME { get; set; }
        public int H_STORE_NO { get; set; }
        public string? H_INVOICE_NO { get; set; }
        [DataType(DataType.Date)]
        public DateTime H_INVOICE_DATE { get; set; }
        public int H_TAX_NO { get; set; }
        public int H_INV_AMT { get; set; }
        [ForeignKey("H_SECTOR_ID")]
        public string? H_SECTOR_ID { get; set; }
        public string? H_UPDATEBY { get; set; }
        [DataType(DataType.Date)]
        public DateTime H_CREATED_DATE { get; set; }
        [DataType(DataType.Date)]
        public DateTime H_UPDATED_DATE { get; set; }
        public int H_STATUS { get; set; }
        public string? H_COMMENT { get; set; }
    }
}
