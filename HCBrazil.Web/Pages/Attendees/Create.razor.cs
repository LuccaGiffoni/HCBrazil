using HCBrazil.Core.Requests.Attendees;
using HCBrazil.Core.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace HCBrazil.Web.Pages.Attendees;

public partial class CreateAttendeePage : ComponentBase
{
    #region Properties

    private const string BaseUrl = "/participantes";
    public bool IsBusy { get; set; } = false;
    public CreateAttendeeRequest Request { get; set; } = new();

    private bool _replicate = true;
    protected bool Replicate
    {
        get => _replicate;
        set
        {
            if (_replicate == value) return;
            
            _replicate = value;
            OnReplicateChanged();
        }
    }

    protected MudForm Form { get; set; } = null!;
    public bool Success { get; set; }
    public string[] Errors { get; set; } = [];
    protected bool IsCepValid { get; set; }
    public bool IsGuardianCepValid { get; set; }

    #endregion

    #region Services

    [Inject] public IAttendeeService AttendeeService { get; set; } = null!;
    [Inject] public IViaCepService ViaCepService { get; set; } = null!;
    [Inject] public NavigationManager NavigationManager { get; set; } = null!;
    [Inject] public ISnackbar Snackbar { get; set; } = null!;

    #endregion

    #region Methods

    public async Task Clear()
    {
        await Form.ResetAsync();
        
        IsCepValid = false;
        IsGuardianCepValid = false;
        Replicate = true;
        
        Snackbar.Add("Formulário limpo!", Severity.Warning);
    }
    
    public async Task Validate()
    {
        await Form.Validate();

        if (Form.IsValid) await OnValidSubmitAsync();
        else Snackbar.Add("Verifique todos os campos antes de enviar!", Severity.Error);
    }

    private async Task OnValidSubmitAsync()
    {
        IsBusy = true;

        try
        {
            var result = await AttendeeService.CreateAsync(Request);

            if (result.IsSuccess)
            {
                Snackbar.Add(result.Message, Severity.Success);
                NavigationManager.NavigateTo(BaseUrl);
            }
            else
            {
                Snackbar.Add(result.Message, Severity.Error);
            }
        }
        catch (Exception e)
        {
            Snackbar.Add(e.Message, Severity.Error);
        }
        finally
        {
            IsBusy = false;
        }
    }

    public async Task OnCepBlurAsync()
    {
        if (string.IsNullOrWhiteSpace(Request.PostalCode.ToString()))
        {
            Snackbar.Add("CEP não pode ser vazio", Severity.Error);
            return;
        }

        try
        {
            var address = await ViaCepService.GetAddressAsync(Request.PostalCode.ToString());

            if (address.IsSuccess)
            {
                Request.Country = "Brasil";
                Request.State = address.Data!.Uf;
                Request.City = address.Data.Localidade;
                Request.Street = address.Data.Logradouro;
                Request.Region = address.Data.Bairro;

                IsCepValid = true;
                Snackbar.Add("Endereço encontrado!", Severity.Success);

                if (Replicate)
                {
                    ReplicateAddressToGuardian();
                }
            }
            else
            {
                Snackbar.Add("Endereço não encontrado para o CEP informado.", Severity.Warning);
            }
        }
        catch (Exception ex)
        {
            Snackbar.Add($"Erro ao buscar endereço: {ex.Message}", Severity.Error);
        }
    }

    public async Task OnGuardianCepBlurAsync()
    {
        if (string.IsNullOrWhiteSpace(Request.GuardianPostalCode.ToString()))
        {
            Snackbar.Add("CEP do Guardião não pode ser vazio", Severity.Error);
            return;
        }

        try
        {
            var address = await ViaCepService.GetAddressAsync(Request.GuardianPostalCode.ToString());

            if (address.IsSuccess)
            {
                Request.GuardianCountry = "Brasil";
                Request.GuardianState = address.Data!.Uf;
                Request.GuardianCity = address.Data.Localidade;
                Request.GuardianStreet = address.Data.Logradouro;
                Request.GuardianRegion = address.Data.Bairro;

                IsGuardianCepValid = true;
                Snackbar.Add("Endereço do Guardião encontrado!", Severity.Success);
            }
            else
            {
                Snackbar.Add("Endereço não encontrado para o CEP informado.", Severity.Warning);
            }
        }
        catch (Exception ex)
        {
            Snackbar.Add($"Erro ao tentar encontrar o endereço: {ex.Message}", Severity.Error);
        }
    }

    private void OnReplicateChanged()
    {
        if (Replicate)
        {
            ReplicateAddressToGuardian();
        }
        else
        {
            ClearGuardianAddress();
        }

        InvokeAsync(StateHasChanged);
    }

    public void ReplicateAddressToGuardian()
    {
        Request.GuardianCountry = Request.Country;
        Request.GuardianState = Request.State;
        Request.GuardianCity = Request.City;
        Request.GuardianStreet = Request.Street;
        Request.GuardianRegion = Request.Region;
        Request.GuardianPostalCode = Request.PostalCode;
    }

    private void ClearGuardianAddress()
    {
        Request.GuardianCountry = string.Empty;
        Request.GuardianState = string.Empty;
        Request.GuardianCity = string.Empty;
        Request.GuardianStreet = string.Empty;
        Request.GuardianRegion = string.Empty;
        Request.GuardianPostalCode = 0;
    }

    #endregion
}