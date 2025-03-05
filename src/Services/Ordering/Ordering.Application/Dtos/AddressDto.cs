using Ordering.Domain.ValueObjects;

namespace Ordering.Application.Dtos;

public record AddressDto(
    string FirstName,
    string LastName,
    string? Email,
    string AddressLine,
    string Country,
    string State,
    string ZipCode)
{
    public static Address MapAddress(AddressDto addressDto)
        => new(addressDto.FirstName, addressDto.LastName, 
            addressDto.Email, addressDto.AddressLine, 
            addressDto.Country, addressDto.State, 
            addressDto.ZipCode);
    
    public static AddressDto Map(Address address)
        => new(address.FirstName, address.LastName, address.EmailAddress, 
            address.AddressLine, address.Country, address.State, address.ZipCode);
}