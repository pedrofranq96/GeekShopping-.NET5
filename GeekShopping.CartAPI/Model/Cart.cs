using System.Collections.Generic;

namespace GeekShopping.CartAPI.Model
{
	public class Cart
	{
		public CartHeader CartHeader { get; set; }

		public IEnumerable<CartDetailVO> CartDetails { get; set; }
	}
}
