

namespace WebAPI.Services.WeaponService
{
    public interface IWeaponService
    {
         Task<ServiceResponse<GetCharacterDTO>> AddWeapon (AddWeaponDTO newWeapon);
    }
}