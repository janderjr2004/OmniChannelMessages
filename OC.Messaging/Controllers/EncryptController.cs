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
            //var encryptData = new EncryptClass("service feel love library soon bench limb they capable grab mosquito copy", CryptographyTypes.JC, 9);

            //var teste = _encryptData.Execute(encryptData);

            //var value = FileFactory.Get(fileClass);

            var encryptData = new EncryptClass("8Y/XfvFxMiE8R?#QR])R$M69%b8lyAc&Ihçmc:´mESRXA4\"UCNYTUGMUUPGPSNUGPYFC:C´G\"SSIGFUITKGPYOFGWKU´GT:A:FPUGBC:FGOS\"HVYWSGTSA´UçRJA)ÇWx'5gA&WbM(h[9z=R:*gr6DSf?6rQYynkSçnF7", CryptographyTypes.JC, 9);
            var decryptData = _decryptData.Execute(encryptData);

            return Ok("Operação realizada com sucesso");
        }
    }
}
