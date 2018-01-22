using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LN.DBUtility;

namespace LN.DAL
{
    public class PromotionShopImage
    {
        public DataSet GetList(string whereStr)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select Id,ImageName from PromotionShopImage");
            if (!string.IsNullOrWhiteSpace(whereStr))
            {
                sql.Append(" where "+whereStr);
            }
            sql.Append(" order by ImageName");
            return DbHelperSQL.Query(DbHelperSQL.connectionString(), sql.ToString());
        }
    }
}
