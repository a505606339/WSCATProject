using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
    public partial class ProfessionManager
    {
        private readonly ProfessionService dal = new ProfessionService();
    }

    public partial class ProfessionManager
    {
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
    }
}
