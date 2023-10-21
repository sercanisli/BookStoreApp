using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/files")]
    public class FilesControllers : ControllerBase
    {
        [HttpPost("upload")]
        public async Task<IActionResult> Upload (IFormFile file)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            //folder

            var folder = Path.Combine(Directory.GetCurrentDirectory(), "Media");
            //combine birden çok parametreyi birleştirir.
            //Uygulamanın mevcut klasörünü alıyoum Media klasörünü alıyorum burada bir path oluşturmuş oldum

            if (!Directory.Exists(folder)) //bir yol yok ise yol oluşturucaz;
            {
                Directory.CreateDirectory(folder);
            }

            //path
            var path = Path.Combine(folder, file?.FileName);
            //dosya adını vermke için FileName deriz o isimi dosyanın oluşması için


            //stream
            //maliyetli işlemler olduğu için using;
            //using bloğu içerisinde kaynaklar kullanılır daha sonrasında serbest bırakılır.
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            //FileStrem nesnesi 10 farklı şekilde kullanılabilir.
            //biz burada bir path vericez, daha sonra FileMode alanı geldi bu demek oluyor ki ben bunu okuyacak mıyım yazacak mıyım?
            //async olarak çalışır

            return Ok(new
            {
                file = file.FileName,
                path = path,
                size= file.Length
            });
            //bir dosya kopyalama işlemi yapıldığı için anonim bir nesne tanımı olarak yapıyorum burada
        }
    }
}
