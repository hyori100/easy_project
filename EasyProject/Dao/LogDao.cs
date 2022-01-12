﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using EasyProject.Model;
using log4net;

namespace EasyProject.Dao
{
    public class LogDao : CommonDBConn, ILogDao
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(App));

        public List<LogModel> GetAllLogs()
        {
            log.Info("GetAllLogs() invoked.");

            List<LogModel> list = new List<LogModel>();

            try
            {
                OracleConnection conn = new OracleConnection(connectionString);
                OracleCommand cmd = new OracleCommand();

                using (conn)
                {
                    conn.Open();

                    using (cmd)
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELET * " +
                                          "FROM EVENT_LOG " +
                                          "ORDER BY log_no";

                        OracleDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            LogModel dto = new LogModel()
                            {
                                Log_no = reader.GetInt32(0),
                                User_no = reader.GetString(1),
                                User_name = reader.GetString(2),
                                User_auth = reader.GetString(3),
                                User_ip = reader.GetString(4),
                                User_nation = reader.GetString(5),
                                Log_date = reader.GetDateTime(6),
                                Log_level = reader.GetString(7),
                                Log_class = reader.GetString(8),
                                Log_method = reader.GetString(9),
                                Message = reader.GetString(10)
                            };

                            list.Add(dto);

                        }//while

                    }//using(cmd)

                }//using(conn)

            }//try
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }//catch

            return list;

        }//GetAllLogs()


        public List<LogModel> GetAllLogs(DateTime? start_date, DateTime? end_date)
        {
            log.Info("GetAllLogs() invoked.");

            List<LogModel> list = new List<LogModel>();

            try
            {
                OracleConnection conn = new OracleConnection(connectionString);
                OracleCommand cmd = new OracleCommand();

                using (conn)
                {
                    conn.Open();

                    using (cmd)
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELET * " +
                                          "FROM EVENT_LOG " +
                                          "WHERE log_date BETWEEN :start_date AND :end_date" +
                                          "ORDER BY log_no";

                        cmd.Parameters.Add(new OracleParameter("start_date", start_date));
                        cmd.Parameters.Add(new OracleParameter("end_date", end_date));

                        OracleDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            LogModel dto = new LogModel()
                            {
                                Log_no = reader.GetInt32(0),
                                User_no = reader.GetString(1),
                                User_name = reader.GetString(2),
                                User_auth = reader.GetString(3),
                                User_ip = reader.GetString(4),
                                User_nation = reader.GetString(5),
                                Log_date = reader.GetDateTime(6),
                                Log_level = reader.GetString(7),
                                Log_class = reader.GetString(8),
                                Log_method = reader.GetString(9),
                                Message = reader.GetString(10)
                            };

                            list.Add(dto);

                        }//while

                    }//using(cmd)

                }//using(conn)

            }//try
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }//catch

            return list;
        }//GetAllLogs


        public List<LogModel> Search_GetLogs(string search_type, string search_keyword)
        {
            log.Info("GetAllLogs(string, string) invoked.");

            List<LogModel> list = new List<LogModel>();

            try
            {
                OracleConnection conn = new OracleConnection(connectionString);
                OracleCommand cmd = new OracleCommand();

                using (conn)
                {
                    conn.Open();

                    using (cmd)
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELET * " +
                                          "FROM EVENT_LOG " +
                                          "WHERE " +
                                          "((:search_type = '사번') AND (user_no '%'||:search_text||'%')) " +
                                          "((:search_type = '사용자명') AND (user_name '%'||:search_text||'%')) " +
                                          "((:search_type = '클래스') AND (log_class '%'||:search_text||'%')) " +
                                          "((:search_type = '메소드') AND (log_method '%'||:search_text||'%')) " +
                                          "((:search_type = '내용') AND (message '%'||:search_text||'%')) " +
                                          "ORDER BY log_no";

                        cmd.BindByName = true;

                        cmd.Parameters.Add(new OracleParameter("search_type", search_type));
                        cmd.Parameters.Add(new OracleParameter("search_text", search_keyword));

                        OracleDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            LogModel dto = new LogModel()
                            {
                                Log_no = reader.GetInt32(0),
                                User_no = reader.GetString(1),
                                User_name = reader.GetString(2),
                                User_auth = reader.GetString(3),
                                User_ip = reader.GetString(4),
                                User_nation = reader.GetString(5),
                                Log_date = reader.GetDateTime(6),
                                Log_level = reader.GetString(7),
                                Log_class = reader.GetString(8),
                                Log_method = reader.GetString(9),
                                Message = reader.GetString(10)
                            };

                            list.Add(dto);

                        }//while

                    }//using(cmd)

                }//using(conn)

            }//try
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }//catch

            return list;
        }//Search_GetLogs


        public List<LogModel> Search_GetLogs(string search_type, string search_keyword, DateTime? start_date, DateTime? end_date)
        {
            log.Info("GetAllLogs(string, string, DateTime?, DateTime?) invoked.");

            List<LogModel> list = new List<LogModel>();

            try
            {
                OracleConnection conn = new OracleConnection(connectionString);
                OracleCommand cmd = new OracleCommand();

                using (conn)
                {
                    conn.Open();

                    using (cmd)
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELET * " +
                                          "FROM EVENT_LOG " +
                                          "WHERE " +
                                          "((:search_type = '사번' AND log_date BETWEEN :start_date AND :end_date +1) AND (user_no '%'||:search_text||'%')) " +
                                          "((:search_type = '사용자명' AND log_date BETWEEN :start_date AND :end_date +1) AND (user_name '%'||:search_text||'%')) " +
                                          "((:search_type = '클래스' AND log_date BETWEEN :start_date AND :end_date +1) AND (log_class '%'||:search_text||'%')) " +
                                          "((:search_type = '메소드' AND log_date BETWEEN :start_date AND :end_date +1) AND (log_method '%'||:search_text||'%')) " +
                                          "((:search_type = '내용' AND log_date BETWEEN :start_date AND :end_date +1) AND (message '%'||:search_text||'%')) " +
                                          "ORDER BY log_no";

                        cmd.BindByName = true;

                        cmd.Parameters.Add(new OracleParameter("search_type", search_type));
                        cmd.Parameters.Add(new OracleParameter("search_text", search_keyword));
                        cmd.Parameters.Add(new OracleParameter("start_date", start_date));
                        cmd.Parameters.Add(new OracleParameter("end_date", end_date));

                        OracleDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            LogModel dto = new LogModel()
                            {
                                Log_no = reader.GetInt32(0),
                                User_no = reader.GetString(1),
                                User_name = reader.GetString(2),
                                User_auth = reader.GetString(3),
                                User_ip = reader.GetString(4),
                                User_nation = reader.GetString(5),
                                Log_date = reader.GetDateTime(6),
                                Log_level = reader.GetString(7),
                                Log_class = reader.GetString(8),
                                Log_method = reader.GetString(9),
                                Message = reader.GetString(10)
                            };

                            list.Add(dto);

                        }//while

                    }//using(cmd)

                }//using(conn)

            }//try
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }//catch

            return list;
        }//Search_GetLogs



        public List<LogModel> GetLoginLogs()
        {
            log.Info("GetLoginLogs() invoked.");

            List<LogModel> list = new List<LogModel>();

            try
            {
                OracleConnection conn = new OracleConnection(connectionString);
                OracleCommand cmd = new OracleCommand();

                using (conn)
                {
                    conn.Open();

                    using (cmd)
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT * " +
                            "FROM LOGIN_LOG " +
                            "ORDER BY login_log_no";

                        cmd.Parameters.Add(new OracleParameter());

                        OracleDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            LogModel dto = new LogModel()
                            {
                                Login_log_no = reader.GetInt32(0),
                                Login_log_ip = reader.GetString(1),
                                Login_log_nation = reader.GetString(2),
                                Login_log_date = reader.GetDateTime(3),
                                Nurse_no = reader.GetString(4),
                                Nurse_name = reader.GetString(5),
                                Nurse_auth = reader.GetString(6),
                                Dept_id = reader.GetInt32(7),
                                Dept_name = reader.GetString(8)
                            };

                            list.Add(dto);

                        }//while

                    }//using(cmd)

                }//using(conn)

            }//try
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }//catch

            return list;
        }//GetLoginLogs

        public List<LogModel> GetLogOutLogs()
        {
            log.Info("GetLogOutLogs() invoked.");
            List<LogModel> list = new List<LogModel>();

            try
            {
                OracleConnection conn = new OracleConnection(connectionString);
                OracleCommand cmd = new OracleCommand();

                using (conn)
                {
                    conn.Open();

                    using (cmd)
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT * " +
                            "FROM LOGOUT_LOG " +
                            "ORDER BY logout_log_no ";

                        cmd.Parameters.Add(new OracleParameter());

                        OracleDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            LogModel dto = new LogModel()
                            {
                                Logout_log_no = reader.GetInt32(0),
                                Logout_log_ip = reader.GetString(1),
                                Logout_log_nation = reader.GetString(2),
                                Logout_log_date = reader.GetDateTime(3),
                                Nurse_no = reader.GetString(4),
                                Nurse_name = reader.GetString(5),
                                Nurse_auth = reader.GetString(6),
                                Dept_id = reader.GetInt32(7),
                                Dept_name = reader.GetString(8)
                            };
                            list.Add(dto);

                        }//while

                    }//using(cmd)

                }//using(conn)

            }//try
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }//catch

            return list;
        }//GetLogOutLogs

        public List<LogModel> GetLoginLogs(DateTime? start_date, DateTime? end_date)
        {
            log.Info("GetLoginLogs(DateTime?, DateTime?) invoked.");
            List<LogModel> list = new List<LogModel>();

            try
            {
                OracleConnection conn = new OracleConnection(connectionString);
                OracleCommand cmd = new OracleCommand();

                using (conn)
                {
                    conn.Open();

                    using (cmd)
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT * " +
                            "FROM LOGIN_LOG " +
                            "WHERE login_log_date BETWEEN :start_date AND :end_date " +
                            "ORDER BY logout_log_no ";

                        cmd.Parameters.Add(new OracleParameter("start_date", start_date));
                        cmd.Parameters.Add(new OracleParameter("end_date", end_date));

                        OracleDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            LogModel dto = new LogModel()
                            {
                                Logout_log_no = reader.GetInt32(0),
                                Logout_log_ip = reader.GetString(1),
                                Logout_log_nation = reader.GetString(2),
                                Logout_log_date = reader.GetDateTime(3),
                                Nurse_no = reader.GetString(4),
                                Nurse_name = reader.GetString(5),
                                Nurse_auth = reader.GetString(6),
                                Dept_id = reader.GetInt32(7),
                                Dept_name = reader.GetString(8)
                            };
                            list.Add(dto);

                        }//while

                    }//using(cmd)

                }//using(conn)

            }//try
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }//catch

            return list;
        }//GetLoginLogs

        public List<LogModel> GetLoginLogs(string search_type, string search_keyword, DateTime? start_date, DateTime? end_date)
        {
            log.Info("GetLoginLogs(string, string, DateTime?, DateTime?) invoked.");
            List<LogModel> list = new List<LogModel>();

            try
            {
                OracleConnection conn = new OracleConnection(connectionString);
                OracleCommand cmd = new OracleCommand();

                using (conn)
                {
                    conn.Open();

                    using (cmd)
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT * " +
                            "FROM LOGIN_LOG " +
                            "WHERE " +
                            "((:search_type = '사용자명' AND login_log_date BETWEEN :start_date AND :end_date +1) AND (nurse_no '%'||:search_text||'%')) " +
                            "((:search_type = '부서명' AND login_log_date BETWEEN :start_date AND :end_date +1) AND (dept_name '%'||:search_text||'%')) " +
                            "((:search_type = 'IP주소' AND login_log_date BETWEEN :start_date AND :end_date +1) AND (login_log_ip '%'||:search_text||'%')) " +
                            "ORDER BY logout_log_no ";

                        cmd.BindByName = true;

                        cmd.Parameters.Add(new OracleParameter("search_type", search_type));
                        cmd.Parameters.Add(new OracleParameter("search_text", search_keyword));
                        cmd.Parameters.Add(new OracleParameter("start_date", start_date));
                        cmd.Parameters.Add(new OracleParameter("end_date", end_date));

                        OracleDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            LogModel dto = new LogModel()
                            {
                                Logout_log_no = reader.GetInt32(0),
                                Logout_log_ip = reader.GetString(1),
                                Logout_log_nation = reader.GetString(2),
                                Logout_log_date = reader.GetDateTime(3),
                                Nurse_no = reader.GetString(4),
                                Nurse_name = reader.GetString(5),
                                Nurse_auth = reader.GetString(6),
                                Dept_id = reader.GetInt32(7),
                                Dept_name = reader.GetString(8)
                            };
                            list.Add(dto);

                        }//while

                    }//using(cmd)

                }//using(conn)

            }//try
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }//catch

            return list;
        }//GetLoginLogs

        public List<LogModel> GetLogOutLogs(string search_type, string search_keyword, DateTime? start_date, DateTime? end_date)
        {
            log.Info("GetLogOutLogs(string, string, DateTime?, DateTime?) invoked.");
            List<LogModel> list = new List<LogModel>();

            try
            {
                OracleConnection conn = new OracleConnection(connectionString);
                OracleCommand cmd = new OracleCommand();

                using (conn)
                {
                    conn.Open();

                    using (cmd)
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT * " +
                            "FROM LOGOUT_LOG " +
                            "WHERE " +
                            "((:search_type = '사용자명' AND logout_log_date BETWEEN :start_date AND :end_date +1) AND (nurse_no '%'||:search_text||'%')) " +
                            "((:search_type = '부서명' AND logout_log_date BETWEEN :start_date AND :end_date +1) AND (dept_name '%'||:search_text||'%')) " +
                            "((:search_type = 'IP주소' AND logout_log_date BETWEEN :start_date AND :end_date +1) AND (logout_log_ip '%'||:search_text||'%')) " +
                            "ORDER BY logout_log_no ";

                        cmd.BindByName = true;

                        cmd.Parameters.Add(new OracleParameter("search_type", search_type));
                        cmd.Parameters.Add(new OracleParameter("search_text", search_keyword));
                        cmd.Parameters.Add(new OracleParameter("start_date", start_date));
                        cmd.Parameters.Add(new OracleParameter("end_date", end_date));

                        OracleDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            LogModel dto = new LogModel()
                            {
                                Logout_log_no = reader.GetInt32(0),
                                Logout_log_ip = reader.GetString(1),
                                Logout_log_nation = reader.GetString(2),
                                Logout_log_date = reader.GetDateTime(3),
                                Nurse_no = reader.GetString(4),
                                Nurse_name = reader.GetString(5),
                                Nurse_auth = reader.GetString(6),
                                Dept_id = reader.GetInt32(7),
                                Dept_name = reader.GetString(8)
                            };
                            list.Add(dto);

                        }//while

                    }//using(cmd)

                }//using(conn)

            }//try
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }//catch

            return list;
        }//GetLogOutLogs



        public List<LogModel> GetLogOutLogs(DateTime? start_date, DateTime? end_date)
        {
            log.Info("GetLogOutLogs(DateTime?, DateTime?) invoked.");
            List<LogModel> list = new List<LogModel>();

            try
            {
                OracleConnection conn = new OracleConnection(connectionString);
                OracleCommand cmd = new OracleCommand();

                using (conn)
                {
                    conn.Open();

                    using (cmd)
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT * " +
                            "FROM LOGOUT_LOG " +
                            "WHERE logout_log_date BETWEEN :start_date AND :end_date " +
                            "ORDER BY logout_log_no ";

                        cmd.Parameters.Add(new OracleParameter("start_date", start_date));
                        cmd.Parameters.Add(new OracleParameter("end_date", end_date));

                        OracleDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            LogModel dto = new LogModel()
                            {
                                Logout_log_no = reader.GetInt32(0),
                                Logout_log_ip = reader.GetString(1),
                                Logout_log_nation = reader.GetString(2),
                                Logout_log_date = reader.GetDateTime(3),
                                Nurse_no = reader.GetString(4),
                                Nurse_name = reader.GetString(5),
                                Nurse_auth = reader.GetString(6),
                                Dept_id = reader.GetInt32(7),
                                Dept_name = reader.GetString(8)
                            };
                            list.Add(dto);

                        }//while

                    }//using(cmd)

                }//using(conn)

            }//try
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }//catch

            return list;
        }//GetLogOutLogs


    }//class

}//namespace
