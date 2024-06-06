using HCBrazil.Api.Data;
using HCBrazil.Core.Models;
using HCBrazil.Core.Requests.Attendees;
using HCBrazil.Core.Responses;
using HCBrazil.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace HCBrazil.Api.Services
{
    public class AttendeeService(AppDbContext context) : IAttendeeService
    {
        public async Task<Response<Attendee?>> CreateAsync(CreateAttendeeRequest request)
        {
            var attendee = new Attendee
            {
                OrganizationId = request.OrganizationId,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Phone = request.Phone,
                Instagram = request.Instagram,
                RG = request.RG,
                CPF = request.CPF,
                Country = request.Country,
                State = request.State,
                City = request.City,
                Street = request.Street,
                Region = request.Region,
                PostalCode = request.PostalCode,
                Number = request.Number,
                GuardianFirstName = request.GuardianFirstName,
                GuardianLastName = request.GuardianLastName,
                GuardianPhone = request.GuardianPhone,
                GuardianEmail = request.GuardianEmail,
                GuardianRG = request.GuardianRG,
                GuardianCPF = request.GuardianCPF,
                GuardianCountry = request.GuardianCountry,
                GuardianState = request.GuardianState,
                GuardianCity = request.GuardianCity,
                GuardianStreet = request.GuardianStreet,
                GuardianRegion = request.GuardianRegion,
                GuardianPostalCode = request.GuardianPostalCode,
                GuardianNumber = request.GuardianNumber
            };

            try
            {
                await context.Attendees.AddAsync(attendee);
                await context.SaveChangesAsync();

                return new Response<Attendee?>(attendee, 201, "Participante com um Responsável criado com sucesso!");
            }
            catch (Exception ex)
            {
                return new Response<Attendee?>(null, 500, $"Não foi possível criar o participante: {ex.Message}");
            }
        }

        public async Task<Response<Attendee?>> UpdateAsync(UpdateAttendeeRequest request)
        {
            try
            {
                var attendee = await context.Attendees
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (attendee is null)
                    return new Response<Attendee?>(null, 404, "Participante não encontrado.");

                attendee.OrganizationId = request.OrganizationId;
                attendee.FirstName = request.FirstName;
                attendee.LastName = request.LastName;
                attendee.Phone = request.Phone;
                attendee.Instagram = request.Instagram;
                attendee.RG = request.RG;
                attendee.CPF = request.CPF;
                attendee.Country = request.Country;
                attendee.State = request.State;
                attendee.City = request.City;
                attendee.Street = request.Street;
                attendee.Region = request.Region;
                attendee.PostalCode = request.PostalCode;
                attendee.Number = request.Number;
                attendee.GuardianFirstName = request.GuardianFirstName;
                attendee.GuardianLastName = request.GuardianLastName;
                attendee.GuardianPhone = request.GuardianPhone;
                attendee.GuardianEmail = request.GuardianEmail;
                attendee.GuardianRG = request.GuardianRG;
                attendee.GuardianCPF = request.GuardianCPF;
                attendee.GuardianCountry = request.GuardianCountry;
                attendee.GuardianState = request.GuardianState;
                attendee.GuardianCity = request.GuardianCity;
                attendee.GuardianStreet = request.GuardianStreet;
                attendee.GuardianRegion = request.GuardianRegion;
                attendee.GuardianPostalCode = request.GuardianPostalCode;
                attendee.GuardianNumber = request.GuardianNumber;

                context.Attendees.Update(attendee);
                await context.SaveChangesAsync();

                return new Response<Attendee?>(attendee, 200, "Participante atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                return new Response<Attendee?>(null, 500, $"Não foi possível atualizar o participante: {ex.Message}");
            }
        }

        public async Task<Response<Attendee?>> DeleteAsync(DeleteAttendeeRequest request)
        {
            try
            {
                var attendee = await context.Attendees
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (attendee is null)
                    return new Response<Attendee?>(null, 404, "Participante não encontrado.");

                context.Attendees.Remove(attendee);
                await context.SaveChangesAsync();

                return new Response<Attendee?>(attendee, 200, "Participante excluído com sucesso!");
            }
            catch (Exception ex)
            {
                return new Response<Attendee?>(null, 500, $"Não foi possível excluir o participante: {ex.Message}");
            }
        }

        public async Task<Response<Attendee?>> GetByIdAsync(GetAttendeeByIdRequest request)
        {
            try
            {
                var attendee = await context.Attendees
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                return attendee is null
                    ? new Response<Attendee?>(null, 404, "Participante não encontrado.")
                    : new Response<Attendee?>(attendee, 200, "Participante encontrado com sucesso!");
            }
            catch (Exception ex)
            {
                return new Response<Attendee?>(null, 500, $"Não foi possível obter o participante: {ex.Message}");
            }
        }

        public async Task<PagedResponse<IEnumerable<Attendee?>>> GetAllAsync(GetAllAttendeesRequest request)
        {
            try
            {
                var attendees = await context.Attendees
                    .Skip((request.PageNumber - 1) * request.PageSize)
                        .Take(request.PageSize).ToListAsync();

                return new PagedResponse<IEnumerable<Attendee?>>(attendees, attendees.Count, request.PageNumber, request.PageSize);
            }
            catch (Exception ex)
            {
                return new PagedResponse<IEnumerable<Attendee?>>(null, 500, $"Não foi possível obter os participantes: {ex.Message}");
            }
        }
    }
}
