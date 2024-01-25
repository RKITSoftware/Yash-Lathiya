using _3_File_System.BL;
using _3_File_System.Models;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace _3_File_System.Controllers
{
    /// <summary>
    /// Implements all operations to handle file
    /// </summary>
    public class CLFileController : ApiController
    {
        static string path = "~/Directory/";

        FileManager fileManager = new FileManager(path);

        [HttpGet]
        [Route("api/File/ListFile")]
        public IHttpActionResult GetListFile()
        {
            try
            {
                return Ok(fileManager.GetListFile());
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Uploads File
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("api/File/UploadFile")]
        public IHttpActionResult UploadFile()
        {
            try
            {
                if (fileManager.UploadFile())
                {
                    return Ok("File(s) uploaded successfully");
                }
                else
                {
                    return BadRequest("No files attached with request or file already exists");
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
           
        }

        /// <summary>
        /// Download File
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/File/DownloadFile/{fileName}")]
        public IHttpActionResult DownloadFile(string fileName)
        {
            try
            {
                //construct file path
                string filePath = HttpContext.Current.Server.MapPath(path + fileName);

                // check file exists
                if (!File.Exists(filePath))
                {
                    return BadRequest("File does not exist");
                }

                // To Download file with response

                // Read the file content
                byte[] fileBytes = File.ReadAllBytes(filePath);

                // Create a response with the file content
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new ByteArrayContent(fileBytes);
                response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                {
                    FileName = fileName
                };
                response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

                return Ok(response);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Read File
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns> Content of file </returns>
        [HttpGet]
        [Route("api/File/ReadFile/{fileName}")]
        public IHttpActionResult ReadFile(string fileName)
        {
            try
            {
                return Ok(fileManager.ReadFile(fileName));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Write File
        /// </summary>
        /// <param name="objFil01"> Object of File </param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/File/WriteFile")]
        public IHttpActionResult WriteFile([FromBody] Fil01 objFil01)
        {
            try
            {
                return Ok(fileManager.WriteFile(objFil01));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Create File
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("api/File/CreateFile/{fileName}")]
        public IHttpActionResult CreateFile(string fileName)
        {
            try
            {
                return Ok(fileManager.CreateFile(fileName));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// To delete file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("api/File/DeleteFile/{fileName}")]
        public IHttpActionResult DeleteFile(string fileName)
        {
            try
            {
                return Ok(fileManager.DeleteFile(fileName));
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
