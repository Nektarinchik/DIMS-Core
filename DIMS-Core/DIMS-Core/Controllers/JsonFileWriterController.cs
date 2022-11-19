using System;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using DIMS_Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DIMS_Core.Controllers
{
    [Route("json")]
    public class JsonFileWriterController : BaseController
    {
        public JsonFileWriterController(IMapper mapper, ILogger logger) : base(mapper, logger)
        {
        }

        [HttpPost("users")]
        public async Task<IActionResult> UsersWriter(UserProfileViewModel[] userProfileViewModels)
        {
            StreamWriter streamWriter = null;
            const string fileName = "users.json";

            try
            {
                // TODO: Task # 20
                // You need to create file in current directory

                // TODO: Task # 21
                // You need to write data in file using stream
            }
            catch (Exception exception)
            {
                Logger.LogError(exception, null);
            }
            finally
            {
                Logger.LogInformation("stream was closed");
                streamWriter?.Close();
            }

            return Json(new
                        {
                            Message = "Data was successfully saved",
                            StatusCode = 201
                        });
        }

        [HttpPost("tasks")]
        public async Task<IActionResult> TasksWriter( /*you have to use here TaskViewModel[]*/)
        {
            StreamWriter streamWriter = null;
            const string fileName = "tasks.json";

            // TODO: Task # 22
            // You need to implement this method as UsersWriter

            try
            {
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }

            return Json(new
                        {
                            Message = "Data was successfully saved",
                            StatusCode = 201
                        });
        }
    }
}