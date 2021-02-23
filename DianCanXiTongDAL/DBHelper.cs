using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;   
using System.Data;
using System.Data.SqlClient;

namespace DianCanXiTongDAL
{
    public class DBHelper
    {
        private const string connString = "server=.;database=Order;uid=sa;pwd=sa";   
        private SqlConnection conn = null;

        public SqlConnection Conn
        {
            get
            {
                if (conn == null)
                {
                    this.conn = new SqlConnection(connString);
                    conn.Open();
                }
                else if (conn.State == ConnectionState.Broken)
                {
                    conn.Close();
                    conn.Open();
                }
                else if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                return conn;
            }
        }

        public void CloseConnection()
        {
            if (conn != null)
            {
                //状态为打开或中断
                if (conn.State == ConnectionState.Open || conn.State == ConnectionState.Broken)
                {
                    conn.Close();
                }
            }
        }

        public int ExecuteNonQuery(string sql, params SqlParameter[] sqlParames)
        {

            try//捕获异常，将可能出现异常的代码放入其中
            {
                //创建对象
                SqlCommand cmd = new SqlCommand(sql, Conn);
                if (sqlParames != null)
                {
                    //这一种是直接把数组传回去
                    cmd.Parameters.AddRange(sqlParames);


                    //通过循环一个一个传(俩种方法都可以)
                    /* foreach (var sqlpar in sqlParames)
                     {
                         cmd.Parameters.Add(sqlpar);
                     }*/
                }
                return cmd.ExecuteNonQuery();//执行且返回
            }
            catch (Exception ex)//当try里面的代码出现异常，则会执行catchl里面的代码，如果无异常则不会制行
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
            finally//不管是否有异常都会执行
            {
                this.CloseConnection();//关闭连接
            }

        }
        public object ExecuteScakar(string sql, params SqlParameter[] sqlParames)
        {
            try//捕获异常，将可能出现异常的代码放入其中
            {
                //创建对象
                SqlCommand cmd = new SqlCommand(sql, Conn);
                if (sqlParames != null)
                {
                    //这一种是直接把数组传回去
                     cmd.Parameters.AddRange(sqlParames);


                    //通过循环一个一个传(俩种方法都可以)
                   /* foreach (var sqlpar in sqlParames)
                    {
                        cmd.Parameters.Add(sqlpar);
                    }*/
                }
                return cmd.ExecuteScalar();//执行且返回
            }
            catch (Exception ex)//当try里面的代码出现异常，则会执行catchl里面的代码，如果无异常则不会制行
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally//不管是否有异常都会执行
            {
                this.CloseConnection();//关闭连接
            }
        }
        public SqlDataReader ExecuteReader(string sql, params SqlParameter[] sqlParames)
        {
            try//捕获异常，将可能出现异常的代码放入其中
            {
                //创建对象
                SqlCommand cmd = new SqlCommand(sql, Conn);
                if (sqlParames != null)
                {
                    //这一种是直接把数组传回去
                    cmd.Parameters.AddRange(sqlParames);


                    //通过循环一个一个传(俩种方法都可以)
                    /* foreach (var sqlpar in sqlParames)
                     {
                         cmd.Parameters.Add(sqlpar);
                     }*/
                }
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);//当关闭对象时，则自动关闭连接对象
            }
            catch (Exception ex)//当try里面的代码出现异常，则会执行catchl里面的代码，如果无异常则不会制行
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public DataTable GetTable(string sql, string tableName = "", params SqlParameter[] sqlParames)
        {
            DataSet ds = new DataSet();

            try
            {
                //创建快捷对象
                SqlCommand cmd = new SqlCommand(sql, Conn);
                if (sqlParames != null)
                {
                    //添加参数到执行对象中

                    cmd.Parameters.AddRange(sqlParames);

                   /* foreach (var param in sqlParames)
                    {
                        cmd.Parameters.Add(param);
                    }*/
                }
                SqlDataAdapter sdr = new SqlDataAdapter(cmd);
                sdr.Fill(ds, tableName);


                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }

    }
}
