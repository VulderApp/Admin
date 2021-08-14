namespace Vulder.Admin.Core.Interfaces
{
    public interface IAuthConfiguration
    {
        string Issuer { get; set; }
        string Audience { get; set; }
        string Key { get; set; }
    }
}