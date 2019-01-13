using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TangyRestaurant.Data;
using TangyRestaurant.Models;
using static TangyRestaurant.Models.Coupon;

namespace TangyRestaurant.Controllers.API
{
    [Route("api/[controller]")]
    [Authorize]
    public class CouponAPIController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CouponAPIController(ApplicationDbContext db)
        {
            _db = db;
        }

        [Route("AddCoupon")]
        [HttpGet]
        public IActionResult AddCoupon(double orderTotal, string couponCode)
        {
            var rtn = "";

            if (couponCode == null)
            {
                rtn = orderTotal + ":Error - Coupon code cannot be null.";
                return Ok(rtn);
            }

            Coupon coupon = _db.Coupons.SingleOrDefault(c => c.Name == couponCode);

            if (coupon == null)
            {
                //coupon dos not exist
                rtn = orderTotal + ":Error - Invalid coupon code.";
                return Ok(rtn);
            }

            if (coupon.MinAmount > orderTotal)
            {
                rtn = orderTotal + ":Error - The minimum amount for this coupon code is " + coupon.MinAmount + ".";
                return Ok(rtn);
            }
            
            int couponTypeTransformed = Convert.ToInt32(coupon.CouponType);

            if (couponTypeTransformed == (int)ECouponType.Dollar)
            {
                orderTotal = orderTotal - coupon.Discount;
                rtn = orderTotal + ":Success.";
                return Ok(rtn);
            }
            else if (couponTypeTransformed == (int)ECouponType.Percent)
            {
                orderTotal = orderTotal - (orderTotal * coupon.Discount / 100);
                rtn = orderTotal + ":Success.";
                return Ok(rtn);
            }

            return Ok();

        }

        [Route("RemoveCoupon")]
        [HttpGet]
        public IActionResult RemoveCoupon(double orderTotal, string couponCode)
        {
            var rtn = "";

            if (couponCode == null)
            {

                rtn = orderTotal + ":Error - Coupon code cannot be null.";
                return Ok(rtn);
            }

            Coupon coupon = _db.Coupons.SingleOrDefault(c => c.Name == couponCode);

            if (coupon == null)
            {
                //coupon dos not exist
                rtn = orderTotal + ":Error - Invalid coupon code.";
                return Ok(rtn);
            }

            int couponTypeTransformed = Convert.ToInt32(coupon.CouponType);

            if (couponTypeTransformed == (int)ECouponType.Dollar)
            {
                rtn = orderTotal + ":Success.";
                return Ok(rtn);
            }
            else if (couponTypeTransformed == (int)ECouponType.Percent)
            {
                rtn = orderTotal + ":Success.";
                return Ok(rtn);
            }

            return Ok();

        }



    }
}
