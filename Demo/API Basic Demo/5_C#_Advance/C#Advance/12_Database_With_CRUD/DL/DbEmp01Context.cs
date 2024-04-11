using _12_Database_With_CRUD.Models;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace _12_Database_With_CRUD.Services
{
    /// <summary>
    /// Consisting buisness logic of all methiods in Employee controller
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
        /// Adds Employee details in Employee Table in database
        /// </summary>
        /// <returns></returns>
        public Response AddEmployee(Emp01 objEmp01)
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
                    _response.Message = "Employee model added in database";
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
        /// To get employee details by employee id 
        /// </summary>
        /// <param name="p01f01"></param>
        /// <returns> Object of EMp01 class </returns>
        public Response GetEmployee(int p01f01)
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
                    _response.Message = "Employee Details";
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
        /// To update employee in database
        /// </summary>
        /// <param name="objEmp01"> New details of employee </param>
        public Response UpdateEmployee(Emp01 objEmp01)
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
                    _response.Message = "Employee details updated successfully";
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
        /// To delete employee drom the database
        /// </summary>
        /// <param name="p01f01"> EMployee Id </param>
        public Response DeleteEmployee(int p01f01)
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
                    _response.Message = "Employee details deleted successfully";
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

        #endregion

    }
}