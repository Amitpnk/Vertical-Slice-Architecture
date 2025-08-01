using VA.CrossCutting.CQRS;
using VA.CrossCutting.Pagination;

namespace VA.API.Customers.GetCustomers;
public class GetCustomersQuery(PaginationRequest request) : IQuery<GetCustomersResponse>
{
    public PaginationRequest Request { get; } = request;
}
public record GetCustomersResponse(PaginatedResult<CustomerDto> Customers);