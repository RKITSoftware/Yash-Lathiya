using _12_Database_With_CRUD.Models;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace _12_Database_With_CRUD.Services
{
    /// <summary>
    /// Consisting buisness logic of all methiods in Emp01 controller
    /// </summary>
    public class DbEmp01Context
    {
        #region Private Members

        /// <summary>
        /// MySql Connection
        /// </summary>
        private readonly MySqlConnection _mySqlConnection;

        /// <summary>
        /// Response of Action Methods
        /// </summary>
        private readonly Response _response;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor of dbContext
        /// </summary>
        /// <exception cref="Exception"> Exception to get MySql Connection </exception>
        public DbEmp01Context()
        {
            _response = new Response();

            try
            {
                // Get the MySqlConnection instance from the Connection class
                _mySqlConnection = Connection.Connection.GetMySqlConnection();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Adds Emp01 details in Emp01 Table in database
        /// </summary>
        /// <returns></returns>
        public Response AddEmp01(Emp01 objEmp01)
        {
            using (MySqlCommand command = new MySqlCommand())
            {
                command.Connection = _mySqlConnection;
                command.CommandText = String.Format(@"INSERT INTO 
                                            EMP01 
                                            (p01f01, p01f02, p01f03, p01f04, p01f05, p01f06) 
                                        VALUES ({0}, '{1}', '{2}', {3}, '{4}', '{5}')",
                                        objEmp01.P01f01,
                                        objEmp01.P01f02,
                                        objEmp01.P01f03,
                                        objEmp01.P01f04,
                                        objEmp01.P01f05.ToString("yyyy-MM-dd hh-mm-ss"),
                                        objEmp01.P01f06.ToString("yyyy-MM-dd hh-mm-ss"));

                try
                {
                    _mySqlConnection.Open();
                    command.ExecuteNonQuery();

                    // configuring response
                    _response.StatusCode = System.Net.HttpStatusCode.Created;
                    _response.Message = "Emp01 model added in database";
                    _response.Data = null;
                }
                catch(Exception ex)
                {
                    // configuring response
                    _response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                    _response.Message = ex.Message;
                    _response.Data = null;
                }
                finally
                {
                    _mySqlConnection.Close();
                }

                return _response;
            }
        }

        /// <summary>
        /// To get Emp01 details by Emp01 id 
        /// </summary>
        /// <param name="p01f01"></param>
        /// <returns> Object of EMp01 class </returns>
        public Response GetEmp01(int p01f01)
        {
            // convert objEmp01 in data table
            DataTable dtEmp01 = new DataTable();

            using (MySqlCommand command = new MySqlCommand())
            {
                command.Connection = _mySqlConnection;

                command.CommandText = String.Format(@"SELECT 
                                            p01f02,
                                            p01f03,
                                            p01f04
                                        FROM 
                                            EMP01 
                                        WHERE 
                                            p01f01 = {0}", p01f01);

                try
                {
                    _mySqlConnection.Open();

                    MySqlDataReader reader = command.ExecuteReader();

                    // Load Data table
                    dtEmp01.Load(reader);

                    // configuring response
                    _response.StatusCode = System.Net.HttpStatusCode.OK;
                    _response.Message = "Emp01 Details";
                    _response.Data = dtEmp01;

                }
                catch(Exception ex)
                {
                    // configuring response
                    _response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                    _response.Message = ex.Message;
                    _response.Data = null;
                }
                finally
                {
                    _mySqlConnection.Close();
                }
                
                return _response;
            }
        }

        /// <summary>
        /// To update Emp01 in database
        /// </summary>
        /// <param name="objEmp01"> New details of Emp01 </param>
        public Response UpdateEmp01(Emp01 objEmp01)
        {
            using (MySqlCommand command = new MySqlCommand())
            {
                command.Connection = _mySqlConnection;

                command.CommandText = String.Format(@"UPDATE 
                                            EMP01 
                                        SET 
                                            p01f02 = '{0}', 
                                            p01f03 = '{1}', 
                                            p01f04 = {2},
                                            p01f06 = '{3}'
                                        WHERE 
                                            p01f01 = {4}", 
                                            objEmp01.P01f02,
                                            objEmp01.P01f03,
                                            objEmp01.P01f04,
                                            objEmp01.P01f06.ToString("yyyy-MM-dd hh-mm-ss"),
                                            objEmp01.P01f01);

                try
                {
                    _mySqlConnection.Open();
                    command.ExecuteNonQuery();

                    // configuring response
                    _response.StatusCode = System.Net.HttpStatusCode.Accepted;
                    _response.Message = "Emp01 details updated successfully";
                    _response.Data = null;
                }
                catch (Exception ex)
                {
                    // configuring response
                    _response.StatusCode = System.Net.HttpStatusCode.OK;
                    _response.Message = ex.Message;
                    _response.Data = null;
                }
                finally
                {
                    _mySqlConnection.Close();
                }

                return _response;
            }
        }

        /// <summary>
        /// To delete Emp01 drom the database
        /// </summary>
        /// <param name="p01f01"> Emp01 Id </param>
        public Response DeleteEmp01(int p01f01)
        {
            using (MySqlCommand command = new MySqlCommand())
            {
                command.Connection = _mySqlConnection;

                command.CommandText = @"DELETE FROM 
                                            EMP01 
                                        WHERE 
                                            p01f01 = @p01f01";

                command.Parameters.AddWithValue("@p01f01", p01f01);

                try
                {
                    _mySqlConnection.Open();
                    command.ExecuteNonQuery();

                    // configuring response
                    _response.StatusCode = System.Net.HttpStatusCode.Accepted;
                    _response.Message = "Emp01 details deleted successfully";
                    _response.Data = null;
                }
                catch (Exception ex)
                {
                    // configuring response
                    _response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                    _response.Message = ex.Message;
                    _response.Data = null;
                }
                finally
                {
                    _mySqlConnection.Close();
                }

                return _response;
            }
        }

        /// <summary>
        /// To check Emp01 id is available or not 
        /// </summary>
        /// <param name="p01f01"> Emp01 Id </param>
        public Response IsIdExists(int p01f01)
        {
            using (MySqlCommand command = new MySqlCommand())
            {
                command.Connection = _mySqlConnection;

                command.CommandText = String.Format(@"SELECT 
                                                          COUNT(*) 
                                                      FROM 
                                                          EMP01 
                                                      WHERE 
                                                           p01f01 = {0}", p01f01);

                try
                {
                    _mySqlConnection.Open();
                    int count = Convert.ToInt32(command.ExecuteScalar());

                    // configuring response based on count
                    if (count == 0)
                    {
                        // configuring response for exception
                        _response.StatusCode = System.Net.HttpStatusCode.OK;
                        _response.Message = "Emp01 ID exists";
                        _response.Data = null;
                    }
                    else
                    {
                        // configuring response for exception
                        _response.IsError = true;
                        _response.StatusCode = System.Net.HttpStatusCode.NotFound;
                        _response.Message = "Emp01 ID does not exist";
                        _response.Data = null;
                    }
                }
                catch (Exception ex)
                {
                    // configuring response for exception
                    _response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                    _response.Message = ex.Message;
                    _response.Data = null;
                }
                finally
                {
                    _mySqlConnection.Close();
                }

                return _response;
            }
        }
        #endregion

    }
}