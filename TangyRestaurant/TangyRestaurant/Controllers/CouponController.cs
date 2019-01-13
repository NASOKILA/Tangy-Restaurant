using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TangyRestaurant.Data;
using TangyRestaurant.Models;
using TangyRestaurant.Utility;

namespace TangyRestaurant.Controllers
{
    [Authorize(Roles = SD.AdminAndUser)]
    public class CouponController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CouponController(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Coupon coupon { get; set; }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Coupon> coupons = await _db.Coupons.ToListAsync();

            return View(coupons);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Coupon coupon)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            //Save picture in the database
            
            //Take the uploaded file
            var files = HttpContext.Request.Form.Files;

            if (files.Count > 0 && files[0]!= null) {

                //save the uploaded picture in this byte array
                byte[] pic = null;

                //we will use streams to convert it into a byte[] array
                using (var fs1 = files[0].OpenReadStream())
                {
                    using (var ms1 = new MemoryStream())
                    {
                        fs1.CopyTo(ms1);
                        pic = ms1.ToArray();
                    }
                }

                //set it to the actual coupon
                coupon.Picture = pic;
            }

            await _db.Coupons.AddAsync(coupon);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public List<string> GetAllCouponTypes() {

            List<string> couponTypes = new List<string>();

            foreach (var couponType in Enum.GetValues(typeof(Coupon.ECouponType)))
            {
                couponTypes.Add(couponType.ToString());
            }

            return couponTypes;
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) {
                return NotFound();
            }

            Coupon coupon = await _db.Coupons
                .SingleOrDefaultAsync(s => s.Id == id);

            if (coupon == null){
                return NotFound();
            }
            
            return View(coupon);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            
            var couponFromDb = _db.Coupons.SingleOrDefault(c => c.Id == id);
            
            //picture
            var files = HttpContext.Request.Form.Files;

            if (files.Count > 0 && files[0] != null)
            {
                byte[] pic = null;

                using (var fs1 = files[0].OpenReadStream())
                {
                    using (var ms1 = new MemoryStream())
                    {
                        fs1.CopyTo(ms1);
                        pic = ms1.ToArray();
                    }
                }

                couponFromDb.Picture = pic;
            }

            couponFromDb.Name = coupon.Name;
            couponFromDb.IsActive = coupon.IsActive;
            couponFromDb.MinAmount = coupon.MinAmount;
            couponFromDb.CouponType = coupon.CouponType;
            couponFromDb.Discount = coupon.Discount;

            _db.Coupons.Update(couponFromDb);

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Coupon coupon = await _db.Coupons
                .SingleOrDefaultAsync(s => s.Id == id);

            if (coupon == null)
            {
                return NotFound();
            }

            return View(coupon);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id, Coupon coupon)
        {
            if (id == null) {
                return NotFound();
            }

            //var couponFromDb = await _db.Coupons.SingleOrDefaultAsync(s => s.Id == id);
            
            _db.Coupons.Remove(coupon);

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }       
    }
}