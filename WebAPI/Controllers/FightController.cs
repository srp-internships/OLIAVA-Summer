namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FightController : ControllerBase
    {
        private readonly IFightService _fightService;
        public FightController(IFightService fightService)
        {
            _fightService = fightService;
        }

        [HttpPost("Weapon")]
        public async Task<ActionResult<ServiceResponse<AttackResultDTO>>> WeaponAttack(WeaponAttackDTO request)
        {
            return Ok(await _fightService.WeaponAttack(request));
        }

        [HttpPost("Skill")]
        public async Task<ActionResult<ServiceResponse<AttackResultDTO>>> SkillAttack(SkillAttackDTO request)
        {
            return Ok(await _fightService.SkillAttack(request));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<FightResultDTO>>> SkillAttack(FightRequestDTO request)
        {
            return Ok(await _fightService.Fight(request));
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<HighScoreDTO>>>> GetHightScore()
        {
            return Ok(await _fightService.GetHighScore());
        }
    }
}