using _3_File_System.Models;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace _3_File_System.BL
{
    /// <summary>
    /// All Operation to manage files
    /// </summary>
    public class FileManager
    {
        // Set Path at which File operation will be performed.
        string path;
        public FileManager(string path)
        {
            this.path = path;
        }

        /// <summary>
        /// To get list of files in directory
        /// </summary>
        /// <returns> List of files </returns>
        public List<string> GetListFile()
        {
            string directoryPath = HttpContext.Current.Server.MapPath(path);

            DirectoryInfo objDirectoryInfo = new DirectoryInfo(directoryPath);

            // List of all file names in current directory
            List<string> lstFileNames = new List<string>();

            // Checks directory exist or not 
            if(objDirectoryInfo.Exists)
            {
                foreach(FileInfo file in objDirectoryInfo.GetFiles())
                {
                    lstFileNames.Add(file.Name);
                }
            }

            return lstFileNames;
            //// Get list of fileNames in directory
            //string[] files = Directory.GetFiles(directoryPath);

            //// Extract file names from file
            //int index = 0;
            //string[] fileName = new string[files.Length];
            //foreach (string file in files)
            //{
            //    fileName[index] = Path.GetFileName(file);
            //    index++;
            //}

            //return fileName;
        }  

        /// <summary>
        /// To upload File in directory
        /// </summary>
        /// <returns> true -> if uploaded successfully 
        ///           false -> if file already exists or no file is attached in response 
        /// </returns>
        public bool UploadFile()
        {
            // Get file from the request.

            var request = HttpContext.Current.Request;

            // If request body consists file
            if (request.Files.Count > 0)
            {
                foreach (string fileName in request.Files)
                {
                    var file = request.Files[fileName];

                    // filepath = path + fileName
                    string filePath = HttpContext.Current.Server.MapPath(path + fileName);

                    // Check if filePath exists already

                    if (System.IO.File.Exists(filePath))
                    {
                        return false; 
                    }

                    file.SaveAs(filePath);
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Read File
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns> content of file </returns>
        public string ReadFile(string fileName)
        {
            //construct file path
            string filePath = HttpContext.Current.Server.MapPath(path + fileName);

            // check file exists
            if (!File.Exists(filePath))
            {
                return "file not found";
            }

            // Show File Content 
            string fileContent = File.ReadAllText(filePath);

            return fileContent;
        } 

        /// <summary>
        /// Write File
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public string WriteFile(Fil01 objFil01)
        {
            // Construct the file path
            string filePath = HttpContext.Current.Server.MapPath(path + objFil01.l01f01);

            // Write the file content
            File.WriteAllText(filePath, objFil01.l01f02);

            return "File is written successfully";
        }

        /// <summary>
        /// Create File
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns> Msg after file created </returns>
        public string CreateFile(string fileName)
        {
            Fil01 objFil01 = new Fil01();
            objFil01.l01f01 = fileName;

            // Construct the file path
            string filePath = HttpContext.Current.Server.MapPath(path + objFil01.l01f01);

            // Write the file content
            File.WriteAllText(filePath, objFil01.l01f02);

            return "File is Created Successfully";
        }

        /// <summary>
        /// To delete File
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>  Msg after file deleted </returns>
        public string DeleteFile(string fileName)
        {
            //construct file path
            string filePath = HttpContext.Current.Server.MapPath(path + fileName);

            // check file exists
            if (!File.Exists(filePath))
            {
                return "File is not found";
            }

            File.Delete(filePath);
            return fileName + " file is deleted successfully";
        }
    }
}