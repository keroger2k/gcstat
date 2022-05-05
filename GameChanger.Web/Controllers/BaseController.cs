using GameChanger.Core;
using Microsoft.AspNetCore.Mvc;

namespace GameChanger.Web.Controllers;

[ApiController]
[Produces("application/json")]
[Route("api/[controller]")]
public class BaseController<T>: ControllerBase where T: BaseController<T>
{
	internal readonly GameChangerService _gameChangerService;
	internal readonly ILogger<T> _logger;

	public BaseController(GameChangerService gameChangerService, ILogger<T> logger)
	{
		_gameChangerService = gameChangerService;
		_logger = logger;
	}
}