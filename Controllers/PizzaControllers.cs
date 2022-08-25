using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    public PizzaController()
    {
    }

    // GET all action
    [HttpGet] //GET SOLO Permite que responda solo al HTTP y realiza consultas en todos el servicio en busca
                //de pizzas eso es lo que hace
public ActionResult<List<Pizza>> GetAll() =>
    PizzaService.GetAll();

    [HttpGet("{id}")] // GET y ID Permite llamar son a una pizza por eso tiene ID 
public ActionResult<Pizza> Get(int id)
{
    var pizza = PizzaService.Get(id);

    if(pizza == null)
        return NotFound();

    return pizza;
}

    // POST action
[HttpPost] //POST PERMTIE AGREGAR NUEVOS ELEMENTOS
public IActionResult Create(Pizza pizza)
{            
    PizzaService.Add(pizza);
    return CreatedAtAction(nameof(Create), new { id = pizza.Id }, pizza);
}

    // PUT action
[HttpPut("{id}")]//Proceso para actualizar o modificar
                 // PUT PERMITE ACTUALIZAR O MODIFICAR

public IActionResult Update(int id, Pizza pizza)
{
    if (id != pizza.Id)
        return BadRequest();
           
    var existingPizza = PizzaService.Get(id);
    if(existingPizza is null)
        return NotFound();
   
    PizzaService.Update(pizza);           
   
    return NoContent();
}

    // DELETE action

    [HttpDelete("{id}")]
public IActionResult Delete(int id)
{
    var pizza = PizzaService.Get(id);
   
    if (pizza is null)
        return NotFound();
       
    PizzaService.Delete(id);
   
    return NoContent();
}

   }
