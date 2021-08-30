namespace Vulder.Admin.Core.Interfaces
{
    public interface IAuthConfiguration
    {
        string Key { get; set; }
        string Issuer { get; set; }
        string Audience { get; set; }
    }
}