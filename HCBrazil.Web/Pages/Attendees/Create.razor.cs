using HCBrazil.Core.Requests.Attendees;
using HCBrazil.Core.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace HCBrazil.Web.Pages.Attendees;

public partial class CreateAttendeePage : ComponentBase
{
    #region Properties

    public bool IsBusy { get; set; } = false;
    public CreateAttendeeRequest Request { get; set; } = new();
    public const string BaseUrl = "/participantes";

    #endregion

    #region Services

    [Inject] public IAttendeeService Service { get; set; } = null!;
    [Inject] public NavigationManager NavigationManager { get; set; } = null!;
    [Inject] public ISnackbar Snackbar { get; set; } = null!;

    #endregion

    #region Methods

    public async Task OnValidSubmitAsync()
    {
        IsBusy = true;

        try
        {
            var result = await Service.CreateAsync(Request);

            if (result.IsSuccess)
            {
                Snackbar.Add(result.Message, Severity.Success);
                NavigationManager.NavigateTo(BaseUrl);
            }
            else
                Snackbar.Add(result.Message, Severity.Error);

            IsBusy = false;
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

    #endregion
}
