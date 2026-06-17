using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OrderHub.Pages;

public class ConfirmOrderModel : PageModel
{
[BindProperty]
public List<OrderLineViewModel> Lines { get; set; } = [];

public string SchoolName { get; set; } = string.Empty;

public decimal Subtotal =>
    Lines.Sum(x => x.UnitPrice * x.Quantity);

public void OnGet()
{
    Lines =
    [
        new()
        {
            Id = 1,
            Sku = "SHIRT",
            Embroidery = "SMITH",
            Quantity = 2,
            UnitPrice = 25
        },
        new()
        {
            Id = 2,
            Sku = "BLAZER",
            Embroidery = "",
            Quantity = 1,
            UnitPrice = 50
        }
    ];

    SchoolName = "Brindleford Academy";
}

public IActionResult OnPost()
{
    if (!ModelState.IsValid)
    {
        return Page();
    }

    return RedirectToPage("Success");
}

}

public class OrderLineViewModel
{
public int Id { get; set; }

public string Sku { get; set; } = string.Empty;

public string Embroidery { get; set; } = string.Empty;

public int Quantity { get; set; }

public decimal UnitPrice { get; set; }

}
