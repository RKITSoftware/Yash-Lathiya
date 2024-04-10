using _12_Database_With_CRUD.Models;
using MySql.Data.MySqlClient;
using System;

namespace _12_Database_With_CRUD.Services
{
    /// <summary>
    /// Consisting buisness logic of all methiods in Employee controller
    /// </summary>
    public class EmployeeService
    {
        #region Private Members

        private MySqlConnection _mySqlConnection;

        #endregion

        #region Constructor

        public EmployeeService()
        {
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
        public void AddEmployee(Emp01 objEmp01)
        {
            using (MySqlCommand command = new MySqlCommand())
            {
                //command.Connection = _mySqlConnection;
                //command.CommandText = String.Format(@"INSERT INTO 
                //                            EMP01 
                //                            (p01f01, p01f02, p01f03, p01f04, p01f05, p01f06) 
                //                        VALUES ({0}, {1}, {2}, {3}, {4}, {5})",
                //                        objEmp01.p01f01,
                //                        objEmp01.p01f02,
                //                        objEmp01.p01f03,
                //                        objEmp01.p01f04,
                //                        objEmp01.p01f05.ToString("dd-MM-yyyy hh:mm:ss"),
                //                        objEmp01.p01f06.ToString("dd-MM-yyyy HH:mm:ss"));

                command.CommandText = @"INSERT INTO EMP01 (p01f01, p01f02, p01f03, p01f04, p01f05, p01f06) 
                        VALUES (@p01f01, @p01f02, @p01f03, @p01f04, @p01f05, @p01f06)";

                command.Parameters.AddWithValue("@p01f01", objEmp01.p01f01);
                command.Parameters.AddWithValue("@p01f02", objEmp01.p01f02);
                command.Parameters.AddWithValue("@p01f03", objEmp01.p01f03);
                command.Parameters.AddWithValue("@p01f04", objEmp01.p01f04);
                command.Parameters.AddWithValue("@p01f05", objEmp01.p01f05);
                command.Parameters.AddWithValue("@p01f06", objEmp01.p01f06);

                try
                {
                    _mySqlConnection.Open();
                    command.ExecuteNonQuery();
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    _mySqlConnection.Close();
                }
            }
        }

        /// <summary>
        /// To get employee details by employee id 
        /// </summary>
        /// <param name="p01f01"></param>
        /// <returns> Object of EMp01 class </returns>
        public Emp01 GetEmployee(int p01f01)
        {
            using (MySqlCommand command = new MySqlCommand())
            {
                command.Connection = _mySqlConnection;

                command.CommandText = String.Format(@"SELECT 
                                            p01f01,
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

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Create and return an Emp01 object based on the data from the database
                            Emp01 employee = new Emp01
                            {
                                // Map database columns to Emp01 properties
                                p01f01 = Convert.ToInt32(reader["p01f01"]),
                                p01f02 = Convert.ToString(reader["p01f02"]),
                                p01f03 = Convert.ToString(reader["p01f03"]),
                                p01f04 = Convert.ToInt32(reader["p01f04"]),
                            };

                            return employee;
                        }
                    }
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    _mySqlConnection.Close();
                }
                
                return null;
            }
        }

        /// <summary>
        /// To update employee in database
        /// </summary>
        /// <param name="objEmp01"> New details of employee </param>
        public void UpdateEmployee(Emp01 objEmp01)
        {
            using (MySqlCommand command = new MySqlCommand())
            {
                command.Connection = _mySqlConnection;

                command.CommandText = String.Format(@"UPDATE 
                                            EMP01 
                                        SET 
                                            p01f02 = {0}, 
                                            p01f03 = {1}, 
                                            p01f04 = {2},
                                            p01f06 = {3}
                                        WHERE 
                                            p01f01 = {4}", 
                                            objEmp01.p01f02,
                                            objEmp01.p01f03,
                                            objEmp01.p01f04,
                                            objEmp01.p01f06,
                                            objEmp01.p01f01);

                try
                {
                    _mySqlConnection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    _mySqlConnection.Close();
                }
                
            }
        }

        /// <summary>
        /// To delete employee drom the database
        /// </summary>
        /// <param name="p01f01"> EMployee Id </param>
        public void DeleteEmployee(int p01f01)
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
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    _mySqlConnection.Close();
                }
            }
        }

        #endregion

    }
}