using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlTypes;
using System.Text;
using System.Windows.Forms;
using RTV_Report.Model;
using RTV_Report.Utils;

namespace RTV_Report.Domain.DAO
{

    public class ClaimOrderDao
    {
        private static ClaimOrder ReadClaimOrder(OleDbDataReader reader)
        {
            ClaimOrder claimOrder = new ClaimOrder();

            int ordinal = reader.GetOrdinal("oid");
            if (!reader.IsDBNull(ordinal))
            {
                claimOrder.oid = reader.GetInt32(ordinal);
            }

            ordinal = reader.GetOrdinal("RTV");
            if (!reader.IsDBNull(ordinal))
            {
                claimOrder.rtv = reader.GetString(ordinal);
            }

            ordinal = reader.GetOrdinal("claimNo");
            if (!reader.IsDBNull(ordinal))
            {
                claimOrder.claimNo = reader.GetString(ordinal);
            }

            ordinal = reader.GetOrdinal("storeNo");
            if (!reader.IsDBNull(ordinal))
            {
                claimOrder.storeNo = reader.GetString(ordinal);
            }

            ordinal = reader.GetOrdinal("lotNo");
            if (!reader.IsDBNull(ordinal))
            {
                claimOrder.lotNo = reader.GetString(ordinal);
            }

            ordinal = reader.GetOrdinal("supplierNo");
            if (!reader.IsDBNull(ordinal))
            {
                claimOrder.supplierNo = reader.GetString(ordinal);
            }

            ordinal = reader.GetOrdinal("supplierName");
            if (!reader.IsDBNull(ordinal))
            {
                claimOrder.supplierName = reader.GetString(ordinal);
            }

            ordinal = reader.GetOrdinal("dept");
            if (!reader.IsDBNull(ordinal))
            {
                claimOrder.dept = reader.GetString(ordinal);
            }

            ordinal = reader.GetOrdinal("qty");
            if (!reader.IsDBNull(ordinal))
            {
                claimOrder.qty = reader.GetDouble(ordinal);
            }

            ordinal = reader.GetOrdinal("pcs");
            if (!reader.IsDBNull(ordinal))
            {
                claimOrder.pcs = reader.GetDouble(ordinal);
            }

            ordinal = reader.GetOrdinal("claimAmount");
            if (!reader.IsDBNull(ordinal))
            {
                claimOrder.claimAmount = reader.GetDouble(ordinal);
            }

            ordinal = reader.GetOrdinal("claimReason");
            if (!reader.IsDBNull(ordinal))
            {
                claimOrder.claimReason = reader.GetString(ordinal);
            }

            ordinal = reader.GetOrdinal("decidedDate");
            if (!reader.IsDBNull(ordinal))
            {
                claimOrder.decidedDate = reader.GetDateTime(ordinal);
            }

            ordinal = reader.GetOrdinal("arriveRTVDate");
            if (!reader.IsDBNull(ordinal))
            {
                claimOrder.arriveRTVDate = reader.GetDateTime(ordinal);
            }

            ordinal = reader.GetOrdinal("informDate");
            if (!reader.IsDBNull(ordinal))
            {
                claimOrder.informDate = reader.GetDateTime(ordinal);
            }

            ordinal = reader.GetOrdinal("informDays");
            if (!reader.IsDBNull(ordinal))
            {
                claimOrder.informDays = reader.GetDouble(ordinal);
            }

            ordinal = reader.GetOrdinal("withdrawDate");
            if (!reader.IsDBNull(ordinal))
            {
                claimOrder.withdrawDate = reader.GetDateTime(ordinal);
            }

            ordinal = reader.GetOrdinal("gateOutType");
            if (!reader.IsDBNull(ordinal))
            {
                claimOrder.gateOutType = reader.GetString(ordinal);
            }

            ordinal = reader.GetOrdinal("destoryInformDate");
            if (!reader.IsDBNull(ordinal))
            {
                claimOrder.destoryInformDate = reader.GetDateTime(ordinal);
            }

            ordinal = reader.GetOrdinal("destoryType");
            if (!reader.IsDBNull(ordinal))
            {
                claimOrder.destoryType = reader.GetString(ordinal);
            }

            ordinal = reader.GetOrdinal("informDateIfOver50Days");
            if (!reader.IsDBNull(ordinal))
            {
                claimOrder.informDateIfOver50Days = reader.GetDateTime(ordinal);
            }

            ordinal = reader.GetOrdinal("creationDate");
            if (!reader.IsDBNull(ordinal))
            {
                claimOrder.creationDate = reader.GetDateTime(ordinal);
            }

            return claimOrder;
        }

        public void Save(ClaimOrder claimOrder)
        {
            OleDbConnection conn = null;
            try
            {
                conn = DBConnections.NewConnection();
                conn.Open();
                
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = 
                    "INSERT INTO claim_order" +
                    "(RTV, claimNo, storeNo, lotNo, supplierNo, supplierName, dept, " +
                    "qty, pcs, claimAmount, claimReason, decidedDate, arriveRTVDate, " +
                    "informDate, informDays, withdrawDate, gateOutDate, gateOutType, " +
                    "destoryInformDate, destoryType, " +
                    "informDateIfOver50Days" +
                    ", creationDate" +
                    ")" +
                    "VALUES " +
                    "(" +
                    "@RTV, @claimNo, @storeNo, @lotNo, @supplierNo, @supplierName, @dept, " +
                    "@qty, @pcs, @claimAmount, @claimReason, @decidedDate, @arriveRTVDate, " +
                    "@informDate, @informDays, @withdrawDate, @gateOutDate, @gateOutType, " +
                    "@destoryInformDate, @destoryType, " +
                    "@informDateIfOver50Days" +
                    ", @creationDate" + 
                    ")";

                OleDbParameter dateParam;
                cmd.Parameters.AddWithValue("@RTV", StringUtils.EmptyIfNull(claimOrder.rtv));
                cmd.Parameters.AddWithValue("@claimNo", StringUtils.EmptyIfNull(claimOrder.claimNo));
                cmd.Parameters.AddWithValue("@storeNo", StringUtils.EmptyIfNull(claimOrder.storeNo));
                cmd.Parameters.AddWithValue("@lotNo", StringUtils.EmptyIfNull(claimOrder.lotNo));
                cmd.Parameters.AddWithValue("@supplierNo", StringUtils.EmptyIfNull(claimOrder.supplierNo));
                cmd.Parameters.AddWithValue("@supplierName", StringUtils.EmptyIfNull(claimOrder.supplierName));
                cmd.Parameters.AddWithValue("@dept", StringUtils.EmptyIfNull(claimOrder.dept));
                cmd.Parameters.AddWithValue("@qty", claimOrder.qty);
                cmd.Parameters.AddWithValue("@pcs", claimOrder.pcs);
                cmd.Parameters.AddWithValue("@claimAmount", claimOrder.claimAmount);
                cmd.Parameters.AddWithValue("@claimReason", StringUtils.EmptyIfNull(claimOrder.claimReason));
                
                dateParam = new OleDbParameter("@decidedDate", OleDbType.Date);
                dateParam.Value = claimOrder.decidedDate == DateTime.MinValue ? (object)DBNull.Value : claimOrder.decidedDate;
                cmd.Parameters.Add(dateParam);
                
                dateParam = new OleDbParameter("@arriveRTVDate", OleDbType.Date);
                dateParam.Value = claimOrder.arriveRTVDate == DateTime.MinValue ? (object)DBNull.Value : claimOrder.arriveRTVDate;
                cmd.Parameters.Add(dateParam);               

                dateParam = new OleDbParameter("@informDate", OleDbType.Date);
                dateParam.Value = claimOrder.informDate == DateTime.MinValue ? (object)DBNull.Value : claimOrder.informDate;
                cmd.Parameters.Add(dateParam);

                cmd.Parameters.AddWithValue("@informDays", claimOrder.informDays);
                
                dateParam = new OleDbParameter("@withdrawDate", OleDbType.Date);
                dateParam.Value = claimOrder.withdrawDate == DateTime.MinValue ? (object)DBNull.Value : claimOrder.withdrawDate;
                cmd.Parameters.Add(dateParam);

                dateParam = new OleDbParameter("@gateOutDate", OleDbType.Date);
                dateParam.Value = claimOrder.gateOutDate == DateTime.MinValue ? (object)DBNull.Value : claimOrder.gateOutDate;
                cmd.Parameters.Add(dateParam);

                cmd.Parameters.AddWithValue("@gateOutType", StringUtils.EmptyIfNull(claimOrder.gateOutType));
                
                dateParam = new OleDbParameter("@destoryInformDate", OleDbType.Date);
                dateParam.Value = claimOrder.destoryInformDate == DateTime.MinValue ? (object)DBNull.Value : claimOrder.destoryInformDate;
                cmd.Parameters.Add(dateParam);

                cmd.Parameters.AddWithValue("@destoryType", StringUtils.EmptyIfNull(claimOrder.destoryType));

                dateParam = new OleDbParameter("@informDateIfOver50Days", OleDbType.Date);
                dateParam.Value = claimOrder.informDateIfOver50Days == DateTime.MinValue ? (object)DBNull.Value : claimOrder.informDateIfOver50Days;
                cmd.Parameters.Add(dateParam);

                dateParam = new OleDbParameter("@creationDate", OleDbType.Date);
                dateParam.Value = DateTime.Now;
                cmd.Parameters.Add(dateParam);

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("Message: " + e.Message + "\r\n" + "Stack Trace: " + e.StackTrace, "访问数据库错误");
            } 
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

        }

        public void Save(IList<ClaimOrder> claimOrders)
        {
            OleDbConnection conn = null;
            OleDbTransaction transaction = null;
            try
            {
                conn = DBConnections.NewConnection();
                conn.Open();
                transaction = conn.BeginTransaction();
                OleDbCommand cmd = conn.CreateCommand();
                cmd.Transaction = transaction;

                cmd.CommandText =
                    "INSERT INTO claim_order" +
                    "(RTV, claimNo, storeNo, lotNo, supplierNo, supplierName, dept, " +
                    "qty, pcs, claimAmount, claimReason, decidedDate, arriveRTVDate, " +
                    "informDate, informDays, withdrawDate, gateOutDate, gateOutType, " +
                    "destoryInformDate, destoryType, " +
                    "informDateIfOver50Days" +
                    ", creationDate" +
                    ")" +
                    "VALUES " +
                    "(" +
                    "@RTV, @claimNo, @storeNo, @lotNo, @supplierNo, @supplierName, @dept, " +
                    "@qty, @pcs, @claimAmount, @claimReason, @decidedDate, @arriveRTVDate, " +
                    "@informDate, @informDays, @withdrawDate, @gateOutDate, @gateOutType, " +
                    "@destoryInformDate, @destoryType, " +
                    "@informDateIfOver50Days" +
                    ", @creationDate" +
                    ")";

                for (int i = 0; i < claimOrders.Count; i++)
                {
                    ClaimOrder claimOrder = claimOrders[i];

                    OleDbParameter dateParam;
                    cmd.Parameters.AddWithValue("@RTV", StringUtils.EmptyIfNull(claimOrder.rtv));
                    cmd.Parameters.AddWithValue("@claimNo", StringUtils.EmptyIfNull(claimOrder.claimNo));
                    cmd.Parameters.AddWithValue("@storeNo", StringUtils.EmptyIfNull(claimOrder.storeNo));
                    cmd.Parameters.AddWithValue("@lotNo", StringUtils.EmptyIfNull(claimOrder.lotNo));
                    cmd.Parameters.AddWithValue("@supplierNo", StringUtils.EmptyIfNull(claimOrder.supplierNo));
                    cmd.Parameters.AddWithValue("@supplierName", StringUtils.EmptyIfNull(claimOrder.supplierName));
                    cmd.Parameters.AddWithValue("@dept", StringUtils.EmptyIfNull(claimOrder.dept));
                    cmd.Parameters.AddWithValue("@qty", claimOrder.qty);
                    cmd.Parameters.AddWithValue("@pcs", claimOrder.pcs);
                    cmd.Parameters.AddWithValue("@claimAmount", claimOrder.claimAmount);
                    cmd.Parameters.AddWithValue("@claimReason", StringUtils.EmptyIfNull(claimOrder.claimReason));

                    dateParam = new OleDbParameter("@decidedDate", OleDbType.Date);
                    dateParam.Value = claimOrder.decidedDate == DateTime.MinValue ? (object)DBNull.Value : claimOrder.decidedDate;
                    cmd.Parameters.Add(dateParam);

                    dateParam = new OleDbParameter("@arriveRTVDate", OleDbType.Date);
                    dateParam.Value = claimOrder.arriveRTVDate == DateTime.MinValue ? (object)DBNull.Value : claimOrder.arriveRTVDate;
                    cmd.Parameters.Add(dateParam);

                    dateParam = new OleDbParameter("@informDate", OleDbType.Date);
                    dateParam.Value = claimOrder.informDate == DateTime.MinValue ? (object)DBNull.Value : claimOrder.informDate;
                    cmd.Parameters.Add(dateParam);

                    cmd.Parameters.AddWithValue("@informDays", claimOrder.informDays);

                    dateParam = new OleDbParameter("@withdrawDate", OleDbType.Date);
                    dateParam.Value = claimOrder.withdrawDate == DateTime.MinValue ? (object)DBNull.Value : claimOrder.withdrawDate;
                    cmd.Parameters.Add(dateParam);

                    dateParam = new OleDbParameter("@gateOutDate", OleDbType.Date);
                    dateParam.Value = claimOrder.gateOutDate == DateTime.MinValue ? (object)DBNull.Value : claimOrder.gateOutDate;
                    cmd.Parameters.Add(dateParam);

                    cmd.Parameters.AddWithValue("@gateOutType", StringUtils.EmptyIfNull(claimOrder.gateOutType));

                    dateParam = new OleDbParameter("@destoryInformDate", OleDbType.Date);
                    dateParam.Value = claimOrder.destoryInformDate == DateTime.MinValue ? (object)DBNull.Value : claimOrder.destoryInformDate;
                    cmd.Parameters.Add(dateParam);

                    cmd.Parameters.AddWithValue("@destoryType", StringUtils.EmptyIfNull(claimOrder.destoryType));

                    dateParam = new OleDbParameter("@informDateIfOver50Days", OleDbType.Date);
                    dateParam.Value = claimOrder.informDateIfOver50Days == DateTime.MinValue ? (object)DBNull.Value : claimOrder.informDateIfOver50Days;
                    cmd.Parameters.Add(dateParam);

                    dateParam = new OleDbParameter("@creationDate", OleDbType.Date);
                    dateParam.Value = DateTime.Now;
                    cmd.Parameters.Add(dateParam);

                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                MessageBox.Show("Message: " + e.Message + "\r\n" + "Stack Trace: " + e.StackTrace, "访问数据库错误");
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

        }

        public int DeleteCreationDayBefore(DateTime date)
        {
            int deletedCnt = 0;
            OleDbConnection conn = null;
            try
            {
                conn = DBConnections.NewConnection();
                conn.Open();

                string sql =
                    "delete " +
                    "  from claim_order " +
                    "where creationDate < @date";

                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                OleDbParameter dateParam =  new OleDbParameter("@data", OleDbType.Date);
                dateParam.Value = date;
                cmd.Parameters.Add(dateParam);
                
                deletedCnt = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("Message: " + e.Message + "\r\n" + "Stack Trace: " + e.StackTrace, "访问数据库错误");
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return deletedCnt;
        }

//        public int DeleteAll()
//        {
//            int deletedCnt = 0;
//            OleDbConnection conn = null;
//            try
//            {
//                conn = DBConnections.NewConnection();
//                conn.Open();
//
//                string sql =
//                    "delete from claim_order";
//
//                OleDbCommand cmd = conn.CreateCommand();
//                cmd.CommandText = sql;
//
//                deletedCnt = cmd.ExecuteNonQuery();
//            }
//            catch (Exception e)
//            {
//                MessageBox.Show("Message: " + e.Message + "\r\n" + "Stack Trace: " + e.StackTrace, "访问数据库错误");
//            }
//            finally
//            {
//                if (conn != null)
//                {
//                    conn.Close();
//                }
//            }
//
//            return deletedCnt;
//        }

        public IList<ClaimOrder> FindYesterdaysClaimOrders()
        {
            IList<ClaimOrder> claimOrders = new List<ClaimOrder>();
            OleDbConnection conn = null;
            try
            {
                conn = DBConnections.NewConnection();
                conn.Open();

                string sql =
                    "SELECT " +
                    "RTV, claimNo, storeNo, lotNo, supplierNo, supplierName, dept, " +
                    "qty, pcs, claimAmount, claimReason, decidedDate, arriveRTVDate, " +
                    "informDate, informDays, withdrawDate, gateOutDate, gateOutType, " +
                    "destoryInformDate, destoryType, informDateIfOver50Days, creationDate, oid " +
                    "FROM claim_order " +
                    "WHERE creationDate > @BeginningOfYesterday " +
                    "  AND creationDate < @EndOfYesterday ";

               
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;

                OleDbParameter beginningOfYesterdayParam = new OleDbParameter("BeginningOfYesterday", OleDbType.Date);
                beginningOfYesterdayParam.Value = DateTime.Today.Subtract(new TimeSpan(TimeSpan.TicksPerDay));
                cmd.Parameters.Add(beginningOfYesterdayParam);

                OleDbParameter endOfYesterdayParam = new OleDbParameter("EndOfYesterday", OleDbType.Date);
                endOfYesterdayParam.Value = DateTime.Today.Subtract(new TimeSpan(TimeSpan.TicksPerSecond));
                cmd.Parameters.Add(endOfYesterdayParam);

                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    claimOrders.Add(ReadClaimOrder(reader));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Message: " + e.Message + "\r\n" + "Stack Trace: " + e.StackTrace, "访问数据库错误");
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return claimOrders;
        }

        public IList<ClaimOrder> Find(string suppilerNo, string claimNo)
        {
            IList<ClaimOrder> claimOrders = new List<ClaimOrder>();
            OleDbConnection conn = null;
            try
            {
                conn = DBConnections.NewConnection();
                conn.Open();

                string sql =
                    "SELECT " +
                    "RTV, claimNo, storeNo, lotNo, supplierNo, supplierName, dept, " +
                    "qty, pcs, claimAmount, claimReason, decidedDate, arriveRTVDate, " +
                    "informDate, informDays, withdrawDate, gateOutDate, gateOutType, " +
                    "destoryInformDate, destoryType, informDateIfOver50Days, creationDate, oid " +
                    "FROM claim_order " +
                    "WHERE 1=1";

                if (StringUtils.NotEmpty(suppilerNo))
                {
                    sql = sql + " AND supplierNo = '" + suppilerNo + "'";
                }

                if (StringUtils.NotEmpty(claimNo))
                {
                    sql = sql + " AND claimNo = '" + claimNo + "'";
                }

                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;

                OleDbDataReader reader = cmd.ExecuteReader();

                
                while (reader.Read())
                {
                    claimOrders.Add(ReadClaimOrder(reader));
                }
            } 
            catch (Exception e)
            {
                MessageBox.Show("Message: " + e.Message + "\r\n" + "Stack Trace: " + e.StackTrace, "访问数据库错误");
            } 
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return claimOrders;
        }

        public IList<ClaimOrder> FindOver10000YuanOver14DaysGroupBySupplier()
        {
            IList<ClaimOrder> claimOrders = new List<ClaimOrder>();
            OleDbConnection conn = null;
            try
            {
                conn = DBConnections.NewConnection();
                conn.Open();

                string sql =
                    "select t3.RTV, claimNo, storeNo, lotNo, t3.supplierNo, supplierName, dept, qty, pcs, claimAmount, claimReason, decidedDate, arriveRTVDate, informDate, informDays, withdrawDate, gateOutDate, gateOutType, destoryInformDate, destoryType, informDateIfOver50Days, creationDate,  oid " +
                    " from (" +
                    "      select supplierNo, rtv " +
                    "        from claim_order t1 " +
                    "        where t1.gateOutDate is NULL " +
                    "          and t1.destoryInformDate is NULL  " +
                    "          and t1.informDays >= 14 " +
                    "        group by t1.supplierNo, rtv" +
                    "        having sum(t1.claimAmount) >= 10000) t2, " +
                    "     claim_order t3 " +
                    "where t2.rtv = t3.rtv " +
                    "  and t2.supplierNo = t3.supplierNo  " +
                    "  and t3.gateOutDate is NULL " +
                    "  and t3.destoryInformDate is NULL " +
                    "  and t3.informDays >= 14";

                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;

                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    claimOrders.Add(ReadClaimOrder(reader));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Message: " + e.Message + "\r\n" + "Stack Trace: " + e.StackTrace, "访问数据库错误");
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return claimOrders;
        }


        public IList<ClaimOrder> FindInformDaysBetween(int lowerLimit, int upperLimit)
        {
            IList<ClaimOrder> claimOrders = new List<ClaimOrder>();
            OleDbConnection conn = null;
            try
            {
                conn = DBConnections.NewConnection();
                conn.Open();

                string sql =
                    "SELECT RTV," +
                    "claimNo," +
                    "storeNo," +
                    "lotNo," +
                    "supplierNo," +
                    "supplierName," +
                    "dept," +
                    "qty," +
                    "pcs," +
                    "claimAmount," +
                    "claimReason," +
                    "decidedDate," +
                    "arriveRTVDate," +
                    "informDate," +
                    "informDays," +
                    "withdrawDate," +
                    "gateOutDate," +
                    "gateOutType," +
                    "destoryInformDate," +
                    "destoryType," +
                    "informDateIfOver50Days," +
                    "creationDate, " +
                    "oid  " +
                    "FROM claim_order " +
                    "where gateOutDate IS NULL " +
                    "and destoryInformDate IS NULL " +
                    "and informDateIfOver50Days IS NULL " +
                    "and informDays between @lowerLimit and @upperLimit"; 

                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;

                cmd.Parameters.AddWithValue("@lowerLimit", lowerLimit);
                cmd.Parameters.AddWithValue("@upperLimit", upperLimit);


                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    claimOrders.Add(ReadClaimOrder(reader));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Message: " + e.Message + "\r\n" + "Stack Trace: " + e.StackTrace, "访问数据库错误");
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return claimOrders;
        }

        public enum Day
        {
            Today,
            Yesterday
        }

        public IList<ClaimOrder> Find64DaysDestory(Day day)
        {
            IList<ClaimOrder> claimOrders = new List<ClaimOrder>();
            OleDbConnection conn = null;
            try
            {
                conn = DBConnections.NewConnection();
                conn.Open();

                string sql =
                    "select RTV," +
                       "claimNo," +
                       "storeNo," +
                       "lotNo," +
                       "supplierNo," +
                       "supplierName," +
                       "dept," +
                       "qty," +
                       "pcs," +
                       "claimAmount," +
                       "claimReason," +
                       "decidedDate," +
                       "arriveRTVDate," +
                       "informDate," +
                       "informDays," +
                       "withdrawDate," +
                       "gateOutDate," +
                       "gateOutType," +
                       "destoryInformDate," +
                       "destoryType," +
                       "informDateIfOver50Days," +
                       "creationDate, " +
                       "oid " +
                     "from claim_order " +
                    "where gateOutDate IS NULL " +
                    "  and destoryInformDate IS NULL " +
                    "  and informDays >= 64 " +
                    "  and informDateIfOver50Days IS NOT NULL" +
                    "  and creationDate > @beginningOfCreationDay " +
                    "  and creationDate < @endOfCreationDay";

                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;

                OleDbParameter beginningOfCreationDayParam = new OleDbParameter("@beginningOfCreationDay", OleDbType.Date);
                OleDbParameter endOfCreationDayParam = new OleDbParameter("@endOfCreationDay", OleDbType.Date);

                switch (day)
                {
                    case Day.Today:
                        beginningOfCreationDayParam.Value = DateTime.Today;
                        endOfCreationDayParam.Value = DateTime.Today.AddDays(1);
                        break;
                    case Day.Yesterday:
                        beginningOfCreationDayParam.Value = DateTime.Today.AddDays(-1);
                        endOfCreationDayParam.Value = DateTime.Today;
                        break;
                    default:
                        throw new ArgumentException(day.ToString() + " is not implemented yet.");

                }

                cmd.Parameters.Add(beginningOfCreationDayParam);
                cmd.Parameters.Add(endOfCreationDayParam);

                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    claimOrders.Add(ReadClaimOrder(reader));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Message: " + e.Message + "\r\n" + "Stack Trace: " + e.StackTrace, "访问数据库错误");
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return claimOrders;
        }

        /*
            Dictionary<ClaimOrder, double> double 是需要核算费用的天数
         */
        public IDictionary<ClaimOrder, double> FindInformDaysOver14(DateTime lastAccountDate)
        {
            IDictionary<ClaimOrder, double> claimOrders = new Dictionary<ClaimOrder, double>();

            OleDbConnection conn = null;
            try
            {
                conn = DBConnections.NewConnection();
                conn.Open();

                string sql =
                    "select RTV," +
                        "claimNo," +
                        "storeNo," +
                        "lotNo," +
                        "supplierNo," +
                        "supplierName," +
                        "dept," +
                        "qty," +
                        "pcs," +
                        "claimAmount," +
                        "claimReason," +
                        "decidedDate," +
                        "arriveRTVDate," +
                        "informDate," +
                        "informDays," +
                        "withdrawDate," +
                        "gateOutDate," +
                        "gateOutType," +
                        "destoryInformDate," +
                        "destoryType," +
                        "informDateIfOver50Days," +
                        "creationDate, " +
                        "oid, " +
                        "IIF(withdrawDate > @lastAccountDate, " +
                            "informDays - (withdrawDate - informDate)," +
                            "informDays - (@lastAccountDate - informDate)) as needAccountDays " +                    
                    "from claim_order " +
                    "where informDays >= 14 ";
 ;

                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;

                OleDbParameter lastAccountParam = new OleDbParameter("@lastAccountDate", OleDbType.Date);
                lastAccountParam.Value = lastAccountDate;
                cmd.Parameters.Add(lastAccountParam);

                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    claimOrders[ReadClaimOrder(reader)] = 
                        reader.GetDouble(reader.GetOrdinal("needAccountDays"));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Message: " + e.Message + "\r\n" + "Stack Trace: " + e.StackTrace, "访问数据库错误");
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return claimOrders;
        }


    }
}
