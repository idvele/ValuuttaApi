using ValuuttaApi.Models;
using ValuuttaApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace Apitest.Controllers;

[ApiController]
[Route("[controller]")]
public class ValuuttaController : ControllerBase{
    public ValuuttaController(){

    }
    
    [HttpGet]
    public ActionResult<List<Valuutta>> GetAll() =>
    ValuuttaService.GetAll();
    
    [HttpGet("{currency}")]
    public ActionResult<Valuutta> Get(string Currency){
        var Val = ValuuttaService.Get(Currency);

        if (Val==null)
        return NotFound();

        return Val;
    }

    [HttpPost]
    public IActionResult Create(Valuutta valuutta){
        ValuuttaService.Add(valuutta);
        //Tutki toimiiko?
        return CreatedAtAction(nameof(Create), new {currency = valuutta.Currency}, valuutta);
    }

    [HttpPut("{currency}")]
    public IActionResult Put( string currency, Valuutta valuutta){

        if(currency!= valuutta.Currency)
        return BadRequest();

        var existingCurrency = ValuuttaService.Get(currency);
        if (existingCurrency is null)
        return NotFound();

        ValuuttaService.Update(valuutta);
        return NoContent();
    }

    [HttpDelete("currency")]
    public IActionResult Delete(string currency){
        var val = ValuuttaService.Get(currency);

        if(val is null){
            return NotFound();
        }
        ValuuttaService.Delete(currency);
        return NoContent();
    }

}