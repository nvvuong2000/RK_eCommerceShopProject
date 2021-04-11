using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RookieShop.Backend.Data;
using RookieShop.Backend.Models;
using RookieShop.Backend.Services.Interface;
using RookieShop.Shared;
using RookieShop.Shared.Repo;
using RookieShop.Shared.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RookieShop.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class CartController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserDF _repoUser;
        private readonly ICart _repo;


        public CartController(ApplicationDbContext context, IUserDF repoUser, ICart repo)
        {
            _context = context;
            _repoUser = repoUser;
            _repo = repo;
        }
        [HttpGet]
        [Authorize(Roles = "user")]
        public async Task<List<CartVM>> Index()
        {


          
            try
            {

                var list = await _repo.myCart();


                return list;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        [HttpGet("/add/{id}")]
        [Authorize(Roles = "user")]
        public async Task<IActionResult> Buy(int id)
        
        {
            // Kiểm tra UserId hiện tại
            var Userid = _repoUser.getUserID();

            // Lấy danh sách sản phẩm trong giỏ hàng
            var listItem = await _context.Carts.Where(x => x.userId.Equals(_repoUser.getUserID())).ToListAsync();

            // Lấy product theo Id
            var result = _context.Products.FirstOrDefault(x => x.Id == id);

            // Kiểm tra sản phẩm có trong giỏ hàng chưa?

            var index = await _repo.FindId(id);

            if (result.stock <= 0)
            {
                throw new Exception("Số lượng vượt quá số lượng tồn");
            }
            else
            {
                if (index != -1)
                {
                    
                    // Nếu có sản phẩm thì tăng số lượng lên 1
                    listItem[index].quantity = listItem[index].quantity + 1;
                    _context.Carts.Update(listItem[index]);
                }
                else
                {

                    if (result == null)
                    {
                        return NotFound();
                    }
                    // Tạo mới 1 đối tượng cart
                    var newItem = new Cart { productId = id, quantity = 1, unitPrice = result.unitPrice, userId = Userid };
                    _context.Carts.Add(newItem);
                }
            }
            await _context.SaveChangesAsync();
            return Ok(StatusCodes.Status200OK);


        }
        [HttpGet("addquantity/{Id}/number/{quan}/isUpdate/{isUpdate}")]
        [Authorize(Roles = "user")]
        public async Task<IActionResult> AddQuantity(int Id, int quan, bool isUpdate)
        {


            var listItem = await _context.Carts.Where(x => x.userId.Equals(_repoUser.getUserID())).ToListAsync();

            var result = _context.Products.FirstOrDefault(x => x.Id == Id);

            var index = await _repo.FindId(Id);


            if (result.stock <= 0)
            {
                throw new Exception("Số lượng vượt quá số lượng tồn");
            }
            else
            {
                if (index != -1)
                {
                    if(isUpdate == true)
                    {
                        listItem[index].quantity = quan;
     
                    }
                    else
                    {
                        listItem[index].quantity = listItem[index].quantity + quan;
                     
                    }
                    _context.Carts.Update(listItem[index]);

                }
                else
                {

                    if (result == null)
                    {
                        return NotFound();
                    }

                    var newItem = new Cart { productId = Id, quantity = quan, unitPrice = result.unitPrice, userId = _repoUser.getUserID() };
                    _context.Carts.Add(newItem);
                }
                await _context.SaveChangesAsync();
                return Ok(StatusCodes.Status200OK);

            }
        }

        [HttpGet("total")]
        [Authorize(Roles = "user")]
        public async Task<decimal> TotalBill()
        {
            try
            {

                var result = await _repo.TotalBill();


                return result;

            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        [HttpGet("/remove/{id}")]
        [Authorize(Roles = "user")]
        public async Task<IActionResult> Remove(int id)
        {

            try
            {

                var result = await _repo.RemoveItem(id);


                return Ok(StatusCodes.Status200OK);

            }
            catch (Exception ex)
            {
                return null;
            }


        }
        [HttpGet("checkout")]
        [Authorize(Roles = "user")]
        public async Task<IActionResult> Checkout()
        {

            try
            {

                var result = await _repo.Checkout();

                return Ok(StatusCodes.Status200OK);

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

}
