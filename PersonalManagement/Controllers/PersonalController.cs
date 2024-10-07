using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalManagement.Models;
using System.Linq;
using System.Threading.Tasks;

public class PersonalController : Controller
{
    private readonly ApplicationDbContext _context;

    public PersonalController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Mostrar la lista de personal
    public async Task<IActionResult> Index()
    {
        var personalList = await _context.Personal.Include(p => p.Cargo).ToListAsync();
        return View(personalList);
    }

    // Crear nuevo personal
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Personal personal)
    {
        if (ModelState.IsValid)
        {
            _context.Personal.Add(personal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(personal);
    }

    // Editar personal
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var personal = await _context.Personal.FindAsync(id);
        if (personal == null)
        {
            return NotFound();
        }
        return View(personal);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, Personal personal)
    {
        if (id != personal.NumeroDocumento)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(personal);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonalExists(personal.NumeroDocumento))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(personal);
    }

    // Eliminar personal
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var personal = await _context.Personal.Include(p => p.Cargo).FirstOrDefaultAsync(m => m.NumeroDocumento == id);
        if (personal == null)
        {
            return NotFound();
        }
        return View(personal);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var personal = await _context.Personal.FindAsync(id);
        _context.Personal.Remove(personal);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool PersonalExists(int id)
    {
        return _context.Personal.Any(e => e.NumeroDocumento == id);
    }
}
