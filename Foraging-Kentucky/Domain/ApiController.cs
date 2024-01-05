using Foraging_Kentucky.Data;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Foraging_Kentucky.Domain;

[ApiController]
[Route("api/items/")]
public class ApiController : Controller
{
    private readonly ForageContext _context;

    public ApiController(ForageContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        List<Item> items = new List<Item>();
        items = await _context.Items.ToListAsync();

        if (items.Count == 0)
        {
            return NotFound();
        }
        
        return Ok(items);
    }

    [HttpPost("new")]
    public async Task<IActionResult> New(Item item)
    {
        Item newItem = new(item.Name) { Description=item.Description, IsEdibleRaw=item.IsEdibleRaw, Type=item.Type, ImagePath=item.ImagePath };
        try
        {
            await _context.Items.AddAsync(newItem);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        return Created(newItem.Name, 201);
    }

    [HttpGet("{itemId}")]
    public async Task<IActionResult> GetItem(int itemId)
    {
        Item item = await _context.Items
            .FirstOrDefaultAsync(item => item.Id == itemId);
        if (item == null)
        {
            return NotFound(itemId);
        }
        return Ok(item);
    }
}
