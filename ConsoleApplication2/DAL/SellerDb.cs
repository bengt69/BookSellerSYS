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
            s.lName = r["LName"].ToString();
            s.fName = r["FName"].ToString();
            s.phoneNbr = r["PhoneNbr"].ToString();
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

        public static List<Seller> Read(string cmd)
        {
            List<Seller> sellers = null;
            using (DataTable table = DataBaseConnect.ExecuteSelectCommand(cmd, CommandType.Text))
            {
                if (table.Rows.Count > 0)
                {
                    sellers = MapSellers(table.Rows);
                }
            }
            return sellers;
        }

        //Lägger till en ny användare i databasen
        public static int Insert(string LName, string FName, string PhoneNbr, string Mail, string City, string Password)
        {
            string cmd = String.Format("INSERT INTO Seller VALUES('{0}','{1}','{2}','{3}','{4}','{5}')", LName, FName, PhoneNbr, Mail, City, Password); //String.Format för att underlätta inmatning

            int rowsAffected = 0;

            rowsAffected = DataBaseConnect.ExecuteNonQuery(cmd, CommandType.Text);

            return rowsAffected;
        }

        public static void Delete(string LName, string FName, string PhoneNbr, string Mail, string City, string Password)
        {
            string cmd = String.Format("DELETE FROM Seller WHERE Mail = '" + Mail + "' ;");
            DataBaseConnect.ExecuteSelectCommand(cmd, CommandType.Text);
        }

        //Hämtar säljare från databasen (mail nyckel)
        public static Seller getSeller(string Mail)
        {
            string cmd = String.Format("SELECT * FROM Seller WHERE Mail = '{0}'", Mail); //String.Format för att underlätta inmatning

            Seller tmpSeller = new Seller();
            List<Seller> seller = new List<Seller>();

            seller.Insert(0, tmpSeller);
            using (DataTable table = DataBaseConnect.ExecuteSelectCommand(cmd, CommandType.Text))
            {
                if (table.Rows.Count > 0)
                {
                    seller = MapSellers(table.Rows);
                }
            }

            tmpSeller = seller.ElementAt(0);
            return tmpSeller;
        }


        public static List<string> getAllSellerMail()
        {
            List<string> allsellers = new List<string>();
            string cmd = "SELECT mail FROM Seller";

            //Seller tmpSeller = new Seller();
            //List<Seller> seller = new List<Seller>();

            using (DataTable table = DataBaseConnect.ExecuteSelectCommand(cmd, CommandType.Text))
            {
                if (table.Rows.Count > 0)
                {
                    //seller = MapSellers(table.Rows);
                    //List<DataRow> rows = table.Rows.Cast<DataRow>().ToList();
                    //IEnumerable<DataRow> sequence = table.AsEnumerable();

                    allsellers = table.AsEnumerable().Select(x => x[0].ToString()).ToList();

                    //List<DataRow> list = table.AsEnumerable().ToList();

                    //allsellers = table.AsEnumerable()
                    //     .Select(r=> r.Field<string>("UserCode"))
                    //   .ToList();
                }
            }
            return allsellers;
        }
    }
}
