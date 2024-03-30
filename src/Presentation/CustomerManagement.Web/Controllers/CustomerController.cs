using CustomerManagement.Application.Features.Commands.CreateCustomer;
using CustomerManagement.Application.Features.Commands.DeleteCustomer;
using CustomerManagement.Application.Features.Commands.UpdateCustomer;
using CustomerManagement.Application.Features.DTOs;
using CustomerManagement.Application.Features.Queries.GetCustomer;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagement.Web.Controllers;

public class CustomerController : Controller
{
    private readonly IMediator _mediator;
    public CustomerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public IActionResult Index()
    {
        IEnumerable<CustomerDTO> model = new List<CustomerDTO>();

        return View(model);
    }


    [HttpGet]
    public IActionResult Create()
    {
        var model = new CreateCustomerCommandRequest();
        return View(model);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateCustomerCommandRequest command)
    {
        if (ModelState.IsValid)
        {
            var result = await _mediator.Send(command);
            if (result.Success)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                string errorMessage = string.Join(", ", result.Errors);
                ModelState.AddModelError("", errorMessage);
            }
        }
        return View(command);
    }

    public async Task<IActionResult> Edit(Guid id)
    {
        var customer = await _mediator.Send(new GetCustomerByIdQueryRequest() { CustomerId = id });

        if (customer == null)
        {
            return NotFound();
        }
        return View(customer);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, UpdateCustomerCommandRequest command)
    {
        if (id != command.CustomerId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            var result = await _mediator.Send(command);
            if (result.Success)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                string errorMessage = string.Join(", ", result.Errors);
                ModelState.AddModelError("", errorMessage);
            }
        }
        return View(command);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteCustomerCommandRequest() { CustomerId = id };
        var result = await _mediator.Send(command);
        if (result.Success)
        {
            return RedirectToAction(nameof(Index));
        }
        else
        {
            string errorMessage = string.Join(", ", result.Errors);
            return RedirectToAction(nameof(Index), new { errorMessage = errorMessage });
        }

    }

}
