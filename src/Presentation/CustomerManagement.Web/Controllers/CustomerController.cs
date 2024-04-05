using CustomerManagement.Application.Features.Commands.CreateCustomer;
using CustomerManagement.Application.Features.Commands.DeleteCustomer;
using CustomerManagement.Application.Features.Commands.UpdateCustomer;
using CustomerManagement.Application.Features.DTOs;
using CustomerManagement.Application.Features.Queries.GetCustomer;
using CustomerManagement.Application.Features.Queries.GetCustomers;
using CustomerManagement.Domain.Entities;
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

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var result = await _mediator.Send(new GetCustomersQueryRequest());
        if (ModelState.IsValid)
        {
            if (result.Success)
            {
                return View(result);
            }
            else
            {
                string errorMessage = string.Join(", ", result.Errors);
                ModelState.AddModelError("", errorMessage);
            }
        }
        return View(result);
    }

    [HttpGet]
    public IActionResult Create()
    {

        return View();
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
                TempData["SuccessMessage"] = "Customer created successfully.";
                return View();
            }
            else
            {

                if (result.StatusCode == 409)
                {
                    TempData["ErrorMessage"] = "Customer with the same data already exists.";
                }

                string errorMessage = string.Join(", ", result.Errors);
                ModelState.AddModelError("", errorMessage);
            }
        }
        return View(command);
    }

    [HttpGet("Edit/{id}")]
    public async Task<IActionResult> Edit([FromRoute] Guid id)
    {
        var customer = await _mediator.Send(new GetCustomerByIdQueryRequest() { CustomerId = id });

        if (customer == null)
            return NotFound();

        return View(customer.Data);
    }

    [HttpPost("Edit/{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit([FromRoute] Guid id, [FromForm] CustomerDTO model)
    {
        UpdateCustomerCommandRequest command = new UpdateCustomerCommandRequest()
        {
            CustomerId = model.Id,
            BankAccountNumber = model.BankAccountNumber,
            DateOfBirth = model.DateOfBirth,
            Email = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName,
            PhoneNumber = model.PhoneNumber,
        };
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
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var result = await _mediator.Send(new DeleteCustomerCommandRequest() { CustomerId = id });
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

    [HttpGet]
    public async Task<IActionResult> Details([FromRoute] Guid id)
    {
        var result = await _mediator.Send(new GetCustomerByIdQueryRequest() { CustomerId = id });
        if (!result.Success)
        {
            return NotFound();
        }

        return View(result.Data);
    }
}
