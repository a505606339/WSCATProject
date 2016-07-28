using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BuyManager
    {
        BuyService bs = new BuyService();
        public DataTable SelBuyDataTable()
        {
            return bs.SelBuyDataTable();
        }
        public DataTable SelBuyDataTableToCheck()
        {
            return bs.SelBuyDataTableToCheck();
        }
        public DataTable SelBuyByCodeDataTable(string code)
        {
            return bs.SelBuyByCodeDataTable(code);
        }
        public List<Buy> SelBuyByCode(string code)
        {
            return bs.SelBuyByCode(code);
        }
    }
}
