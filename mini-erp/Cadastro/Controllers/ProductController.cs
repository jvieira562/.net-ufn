using Cadastro.Interfaces;
using Cadastro.ViewModels.Products;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Cadastro.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductViewModelService _productViewModelService;

        public ProductController(IProductViewModelService productViewModelService)
        {
            _productViewModelService = productViewModelService;
        }

        public ActionResult Index()
        {
            var list = _productViewModelService.GetAll();
            return View(list);
        }

        public ActionResult Details(int id)
        {
            var viewModel = _productViewModelService.Get(id);
            return View(viewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel viewModel)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _productViewModelService.Insert(viewModel);

                    return RedirectToAction(nameof(Index));
                }
                return View(viewModel);
            }
            catch
            {
                return View(viewModel);
            }
        }

        public ActionResult Edit(int id)
        {
            var viewModel = _productViewModelService.Get(id);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _productViewModelService.Update(viewModel);

                    return RedirectToAction(nameof(Index));
                }
                return View(viewModel);
            }
            catch
            {
                return View(viewModel);
            }
        }

        public ActionResult Delete(int id)
        {
            var viewModel = _productViewModelService.Get(id);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _productViewModelService.Delete(id);

                    return RedirectToAction(nameof(Index));
                }

                var viewModel = _productViewModelService.Get(id);
                return View(viewModel);
            }
            catch
            {
                var viewModel = _productViewModelService.Get(id);
                return View(viewModel);
            }
        }
    }
}
