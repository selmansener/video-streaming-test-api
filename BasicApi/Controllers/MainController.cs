using Microsoft.AspNetCore.Mvc;

namespace BasicApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainController : ControllerBase
    {
        private readonly VideoSavePoint _videoSavePoint;

        public MainController(VideoSavePoint videoSavePoint)
        {
            _videoSavePoint = videoSavePoint;
        }

        [HttpGet("GetLastSavePoint")]
        public IActionResult GetLastSavePoint()
        {
            return Ok(_videoSavePoint);
        }

        [HttpPost("SavePoint")]
        public IActionResult SavePoint([FromBody] VideoSavePoint savepoint)
        {
            _videoSavePoint.LastTimestamp = savepoint.LastTimestamp;

            return Ok();
        }
    }

    public class VideoSavePoint
    {
        public float LastTimestamp { get; set; }
    }
}
