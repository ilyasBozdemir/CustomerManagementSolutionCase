﻿using CustomerManagement.Application.Features.DTOs;
using CustomerManagement.Domain.Entities;
using MediatR;

namespace CustomerManagement.Application.Features.Events.CustomerEvents;

public class CustomerUpdatedEvent : INotification
{
    public CustomerDTO Customer { get; }

    public CustomerUpdatedEvent(CustomerDTO customer)
    {
        Customer = customer;
    }
}
