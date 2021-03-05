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
        //连接的字符串
        private const string connString = "server=.;database=Order;uid=sa;pwd=sa";

        private SqlConnection conn = null;
        public SqlConnection Conn//创建连接对象的时候 
        {
            get
            {
                if (conn == null)//如果没有new 就new一个
                {
                    conn = new SqlConnection(connString);
                    conn.Open();
                }
                else if (conn.State == ConnectionState.Broken)//如果是断开的就把他关闭再打开
                {
                    //连接状态为中断，则先关闭连接，在打开连接
                    conn.Close();
                    conn.Open();
                }
                else if (conn.State == ConnectionState.Closed)//这是关闭状态，给他打开
                {
                    //如果连接状态为关闭，则直接打开
                    conn.Open();
                }
                return conn;
            }
        }
        public void CloseConnection()//关闭连接对象 
        {
            if (conn != null)
            {
                //如果连接状态为打开或者中断 则需要关闭
                if (conn.State == ConnectionState.Open || conn.State == ConnectionState.Broken)
                {
                    conn.Close();
                }
            }
        }
        /// <summary>
        /// 实现增，删，改操作的方法
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="sqlParams">sql语句中的参数列表</param>
        public int ExecuteNonQuery(string sql, params SqlParameter[] sqlParams)//Sql是：实现操作的SQL语句。sqlParams是：sql语句中的参数列表。
        {
            try//捕获异常，将可能出现异常的代码放入其中，不能单独出现
            {
                //创建执行对象
                SqlCommand cmd = new SqlCommand(sql, Conn);//大写的Conn,小写的conn不行
                if (sqlParams != null)
                {
                    //添加参数到执行对象中
                    cmd.Parameters.AddRange(sqlParams);//第一种方法
                   /* foreach (var param in sqlParams)//第二种方法
                    {
                        cmd.Parameters.Add(param);
                    }*/
                }
                return cmd.ExecuteNonQuery();//执行且返回影响行数
            }
            catch (Exception ex)//当try里面的代码出现异常，则会执行catch里面的代码，如果无异常就不会执行
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
            finally //不管有没有异常都会执行
            {
                this.CloseConnection();//关闭连接
            }
        }
        /// <summary>
        /// 返回单行单列的对象
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="sqlParams"></param>
        /// <returns></returns>
        public object ExecuteScalar(string sql, params SqlParameter[] sqlParams) //Sql是：实现操作的SQL语句。sqlParams是：sql语句中的参数列表。
        {
            try//捕获异常，将可能出现异常的代码放入其中，不能单独出现
            {
                //创建执行对象
                SqlCommand cmd = new SqlCommand(sql, Conn);//大写的Conn,小写的Conn不行
                if (sqlParams != null)
                {
                    //添加参数到执行对象中
                    //cmd.Parameters.AddRange(sqlParams);//第一种方法
                    foreach (var param in sqlParams)//第二种方法
                    {
                        cmd.Parameters.Add(param);
                    }
                }
                return cmd.ExecuteScalar();//执行且返回影响行数
            }
            catch (Exception ex)//当try里面的代码出现异常，则会执行catch里面的代码，如果无异常就不会执行
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally //不管有没有异常都会执行
            {
                this.CloseConnection();//关闭连接
            }
        }
        /// <summary>
        /// 实现多行查询的操作
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="sqlParams"></param>
        /// <returns></returns>
        public SqlDataReader ExecuteReader(string sql, params SqlParameter[] sqlParams)
        {
            /*try//捕获异常，将可能出现异常的代码放入其中，不能单独出现
            {*/
                //创建执行对象
                SqlCommand cmd = new SqlCommand(sql, Conn);//大写的Conn,小写的Conn不行
                if (sqlParams != null)
                {
                    //添加参数到执行对象中
                    //cmd.Parameters.AddRange(sqlParams);//第一种方法
                    foreach (var param in sqlParams)//第二种方法
                    {
                        cmd.Parameters.Add(param);
                    }
                }
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);//当关闭对象，则自动关闭连接对象
            /*}
            catch (Exception ex)//当try里面的代码出现异常，则会执行catch里面的代码，如果无异常就不会执行
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally //不管有没有异常都会执行
            {
                this.CloseConnection();//关闭连接
            }*/
        }
        /// <summary>
        /// 返回操作表
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="tableName"></param>
        /// <param name="sqlParams"></param>
        /// <returns></returns>
        public DataTable GetTable(string sql, string tableName = "", params SqlParameter[] sqlParams)
        {
            DataSet ds = new DataSet();

            try
            {
                //创建执行对象
                SqlCommand cmd = new SqlCommand(sql, Conn);//大写的Conn,小写的Conn不行
                if (sqlParams != null)
                {
                    //添加参数到执行对象中
                    //cmd.Parameters.AddRange(sqlParams);//第一种方法
                    foreach (var param in sqlParams)//第二种方法
                    {
                        cmd.Parameters.Add(param);
                    }
                }
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(ds, tableName);

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
