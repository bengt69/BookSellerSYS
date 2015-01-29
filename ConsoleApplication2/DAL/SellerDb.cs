﻿﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BookSeller
{
    class SellerDb
    {
        public static Seller MapSellers(DataRow r)
        {
            Seller s = new Seller();
            s.lName = r["LastName"].ToString();
            s.fName = r["FirstName"].ToString();
            s.phoneNbr =r["PhoneNumber"].ToString();
            s.mail = r["Mail"].ToString();
            s.city = r["City"].ToString();
            s.password = r["Password"].ToString();

            return s;
        }
        public static List<Seller> MapSellers(DataRowCollection rows)
        {
            List<Seller> sellers = new List<Seller>();
            foreach (DataRow r in rows)
            {
                sellers.Add(MapSellers(r));
            }
            return sellers;
        }

        public static List<Seller> Read()
        {
            List<Seller> sellers = null;
            using (DataTable table = DataBaseConnect.ExecuteSelectCommand("SELECT * FROM Seller", CommandType.Text))
            {
                if (table.Rows.Count > 0)
                {
                    sellers = MapSellers(table.Rows);
                }
            }
            return sellers;
        }
    }
}
