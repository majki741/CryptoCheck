using Microsoft.AspNetCore.Mvc;

namespace Api.Service.Mail.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MailController : ControllerBase
{
    public MailController()
    {
        
    }
    [HttpPost]
    public ActionResult SendMail()
    {
        Console.WriteLine("--> Mail sent.");
        
        return Ok("OK - MailSentInfo");
    }
}