using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.OrderAPI.Model.Base
{
	[Table("order_header")]
	public class OrderHeader : BaseEntity
	{
		[Column("user_id")]
		public string UserId { get; set; }

		[Column("coupon_code")]
		public string CouponCode { get; set; }
		[Column("purchase_amount")]
		public decimal PurchaseAmount { get; set; }
		[Column("discount_total")]
		public decimal DiscountTotal { get; set; }
		[Column("firstName")]
		public string FirstName { get; set; }
		[Column("lastName")]
		public string LastName { get; set; }
		[Column("purchase_date")]
		public DateTime Datatime { get; set; }
		[Column("order_time")]
		public DateTime OrderTime { get; set; }
		[Column("phone_number")]
		public string Phone { get; set; }
		[Column("email")]
		public string Email { get; set; }
		[Column("cardNumber")]
		public string CardNumber { get; set; }
		[Column("cvv")]
		public string CVV { get; set; }
		[Column("expire_month_year")]
		public string ExpireMonthYear { get; set; }
		[Column("total_itens")]
		public int CartTotalItens { get; set; }
		public IEnumerable<OrderDetail> OrderDetails { get; set; }
		[Column("payment_status")]
		public bool PaymentStatus { get; set; }
	}
}
