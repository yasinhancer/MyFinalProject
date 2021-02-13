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
        
        [HttpGet]
        public List<Product> Get()
        {
            var result = _productService.GetAll();
            return result.Data;
        }
    }
}
