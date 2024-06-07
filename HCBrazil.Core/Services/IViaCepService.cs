using HCBrazil.Core.Models;
using HCBrazil.Core.Responses;

namespace HCBrazil.Core.Services;

public interface IViaCepService
{
    Task<Response<Address?>> GetAddressAsync(string cep);
}