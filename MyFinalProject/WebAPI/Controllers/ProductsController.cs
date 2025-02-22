﻿using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]  //Attribute
    public class ProductsController : ControllerBase
    {
        //Loosely coupled - zayıf bağımlılık
        //naming convention - isimlendirme
        //IoC Container  - Inversion of control(değişimin kontrolü)
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll() {
            //Dependency chain -- bağımlılık zinciri

            Thread.Sleep(5000);
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")] //içine yazdığımız sadece bir isimlendirme
        public IActionResult GetById(int id) {
            var result = _productService.GetById(id);
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]  //data vermek data almıyoruz
        public IActionResult Add(Product product) {
            var result = _productService.Add(product);
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
