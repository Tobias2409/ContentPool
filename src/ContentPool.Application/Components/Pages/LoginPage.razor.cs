using Microsoft.AspNetCore.Components;

namespace ContentPool.Application.Components.Pages;

public partial class LoginPage : ComponentBase
{
    
    public string Username { get; set; } = string.Empty;
    
    public string Password { get; set; } = string.Empty;
    
    private void HandleLogin(EventArgs obj)
    {
        throw new NotImplementedException();
    }
}