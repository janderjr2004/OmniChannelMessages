using Microsoft.AspNetCore.Mvc;
using OC.Libraries.Classes;
using OC.Libraries.Enums;
using OC.Libraries.Interfaces;

namespace OC.Messaging.Controllers
{
    [ApiController]
    [Route("api/encrypt")]
    public class EncryptController : ControllerBase
    {
        private readonly IEncryptData _encryptData;
        private readonly IDecryptData _decryptData;

        public EncryptController(
            IEncryptData encryptData, 
            IDecryptData decryptData
        )
        {
            _encryptData = encryptData;
            _decryptData = decryptData;
        }

        [HttpGet]
        public IActionResult Get()
        {
            //var encryptData = new EncryptClass("Server=localhost;Database=OC_MESSAGING;User Id=sa;Password=senh@123;",9,CryptographyTypes.JC);

            //var teste = _encryptData.Execute(encryptData);

            //var value = FileFactory.Get(fileClass);

            //encryptData = new EncryptClass(value.GetValue(), 9, CryptographyTypes.JC);
            //var decryptData = _decryptData.Execute(encryptData);

            return Ok("Operação realizada com sucesso");
        }
    }
}
