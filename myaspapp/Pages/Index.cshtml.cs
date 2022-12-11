using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using myaspapp.models;
using myaspapp.Services;

namespace myaspapp.Pages
{
    public class IndexModel : PageModel
    {
        public List<product> products;

        public void OnGet()
        {
            ProductService productService = new ProductService();
            products = productService.GetProducts();
        }
    }
}