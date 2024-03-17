using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoMVC.Context;
using ProjetoMVC.Models;

namespace ProjetoMVC.Controllers;

public class ContatoController : Controller
{
  private readonly AgendaContext _context;     
  public ContatoController(AgendaContext context) 
  {
    _context = context;
  }

  //Carregar as páginas
  public IActionResult Index()
  {
    var contatos = _context.Contatos.ToList();

    return View(contatos);
  }

  public IActionResult Criar()
  {
    return View();
  }

  public IActionResult Deletar_Id()
  {
    return View();
  }
  public IActionResult Detalhes_Id()
  {
    return View();
  }
  public IActionResult Editar_Id()
  {
    return View();
  }

  //Requisições POST
  [HttpPost]
  public IActionResult Criar(Contato contato)
  {
    if (ModelState.IsValid)
    {
      _context.Contatos.Add(contato);
      _context.SaveChanges();
      return RedirectToAction(nameof(Index));
    }
    return View(contato);
  }

  [HttpPost]
  public IActionResult Editar(Contato contato)
  {
    var contatoBanco = _context.Contatos.Find(contato.Id);

    contatoBanco.Nome = contato.Nome;
    contatoBanco.Telefone = contato.Telefone;
    contatoBanco.Ativo = contato.Ativo;

    _context.Contatos.Update(contatoBanco);
    _context.SaveChanges();

    return RedirectToAction(nameof(Index));
  }

  [HttpPost]
  public IActionResult Deletar(Contato contato)
  {
    var contatoBanco = _context.Contatos.Find(contato.Id);

    _context.Contatos.Remove(contatoBanco);
    _context.SaveChanges();

    return RedirectToAction(nameof(Index));
  }

  [HttpPost]
  public IActionResult Editar_Id(Contato contato)
  {
    if (ModelState.IsValid)
    {
      var contatoBanco = _context.Contatos.Find(contato.Id);

      if (contatoBanco == null)
      {
        return NotFound();
      }

      contatoBanco.Nome = contato.Nome;
      contatoBanco.Telefone = contato.Telefone;
      contatoBanco.Ativo = contato.Ativo;

      _context.Update(contatoBanco);
      _context.SaveChanges();

      return RedirectToAction(nameof(Index));
    }
    return View();
  }

  [HttpPost]
  public IActionResult Deletar_Id(Contato contato)
  {
    if (ModelState.IsValid)
    {
      var contatoBanco = _context.Contatos.Find(contato.Id);

      if (contatoBanco == null)
      {
        return NotFound();
      }

      _context.Contatos.Remove(contatoBanco);
      _context.SaveChanges();

      return RedirectToAction(nameof(Index));
    }
    return View();
  }

  //Requisições GET
  [HttpGet]
  public IActionResult Editar_Id(int id)
  {
    var contato = _context.Contatos.Find(id);

    return View(contato);
  }

  [HttpGet]
  public IActionResult Deletar_Id(int id)
  {
    var contato = _context.Contatos.Find(id);

    return View(contato);
  }

  [HttpGet]
  public IActionResult Editar(int id)
  {
    var contato = _context.Contatos.Find(id);

    if (contato == null)
        
      return RedirectToAction(nameof(Index));
        
    return View(contato);
  }

  [HttpGet]
  public IActionResult Detalhes(int id)
  {
    var contato = _context.Contatos.Find(id);

    if (contato == null)
      return RedirectToAction(nameof(Index));
    return View(contato);
  }

  [HttpGet]
  public IActionResult Deletar(int id)
  {
    var contato = _context.Contatos.Find(id);

    if (contato == null)
      return RedirectToAction(nameof(Index));
    return View(contato);
  }

}
