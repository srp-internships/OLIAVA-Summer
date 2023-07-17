namespace WebAPI.DTOs.Weapon
{
    public class AddWeaponDTO
    {
        public string Name { get; set; } = string.Empty;

        public int Demage { get; set; }

        public int CharacterId { get; set; }
    }
}