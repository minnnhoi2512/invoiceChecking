using System.ComponentModel.DataAnnotations;

namespace ManagerInvoice.Models
{
    public class OrderDetail
    {
        [Key]
        public int DETAIL_ORDER_NO { get; set; }
        public int D_ORDER_NO { get; set; }
        public int D_ORDER_INT { get; set; }
        public int D_LINE { get; set; }
        public int D_ART_NO { get; set; }
        public string? D_ART_DVT { get; set; }
        public int D_MMUNT { get; set; }
        public string? D_ARTNAME { get; set; }
        public int D_QTY { get; set; }
        public int D_GOLDVAT { get; set; }
        public int D_GOLD_PRICE { get; set; }
        public int D_SUPVAT { get; set; }
        public int D_SUP_PRICE { get; set; }
        public string? D_UPDATEBY { get; set; }
        [DataType(DataType.Date)]
        public DateTime H_CREATED_DATE { get; set; }
        [DataType(DataType.Date)]
        public DateTime H_UPDATED_DATE { get; set; }
        public int D_STATUS { get; set; }
        public string? D_COMMENT { get; set; }
    }
}
