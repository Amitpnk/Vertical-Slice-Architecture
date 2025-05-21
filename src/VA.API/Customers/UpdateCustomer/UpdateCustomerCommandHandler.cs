﻿using VA.Shared.Exceptions;

namespace VA.API.Customers.UpdateCustomer;


//public record UpdateCustomerResult(bool IsSuccess);




internal class UpdateCustomerCommandHandler(CustomerContext context)
    : ICommandHandler<UpdateCustomerCommand, UpdateCustomerResponse>
{
    public async Task<UpdateCustomerResponse> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
    {
        var customer = await context.Customers.FindAsync([command.Id], cancellationToken);

        if (customer is null)
        {
            throw new NotFoundException(command.Id.ToString());
        }

        customer.CustomerCode = command.CustomerCode;
        customer.CustomerName = command.CustomerName;

        context.Customers.Update(customer);
        await context.SaveChangesAsync(cancellationToken);

        return new UpdateCustomerResponse(true, null, customer);
    }
}
