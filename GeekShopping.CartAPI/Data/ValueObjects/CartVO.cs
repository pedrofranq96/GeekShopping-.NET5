using GeekShopping.CartAPI.Data.ValueObject;
using System.Collections.Generic;

namespace GeekShopping.CartAPI.Data.ValueObject
{
	public class CartVO
	{
		public CartHeaderVO CartHeader { get; set; }

		public IEnumerable<CartDetailVO> CartDetails { get; set; }
	}
}
