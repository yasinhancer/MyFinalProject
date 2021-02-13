using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")] //route: bu istek yapılırken, nasıl ulaşsın?
    [ApiController] //ATTRIBUTE - class ile ilgili bilgi verme, imzalama yöntemi ( bu class bir controller'dır anlamında )
    public class ProductsController : ControllerBase
    {
        //IoC Container -> Inversion of Control / değişimin kontrolü / bellekte newleme olayı / IoC arka planda benim yerime newler 
        
        
        //DEPENDENCY INJECTION -> BAĞIMLILIK ENJEKSİYONU
        IProductService _productService;
        public ProductsController(IProductService productService) //Controller sen bir IProductService bağımlısısın 
        {
            _productService = productService;
        }
        
        [HttpGet("GetAll")] //en sonda takma isim vermemin sebebi, aynı olanlar ile karışmasın, yoksa karışıyor!!!
        public IActionResult GetAll()
        {
            var result = _productService.GetAll();
            if (result.Success) //UNUTMA: success'in default'ı true 
            {
                return Ok(result); //Ok: Status 200 ile döner.yanında istenirse, sonuç dönebilir.
            }

            return BadRequest(result); //BadRequest: Status 400 ile döner.
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("Add")] //post yazma/ekleme : güncelleme,silme için de kullanılabilir.
                          //güncelleme için ayrıca HttpPut,
                          //silme için de ayrıca HttpDelete kullanılabilir,
                          //ancak hepsi Post üzerinden de yazılabilir 
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
