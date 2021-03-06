﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSeller
{
    public class Seller
    {
        public String fName { get; set; } 
        public String lName { get; set; }
        public String phoneNbr { get; set; }
        public String mail { get; set; }
        public String city { get; set; }
        public String password { get; set; }
    }
    public class BookAd
    {
        public String title { get; set; }
        public String isbn { get; set; }
        public String author { get; set; }
        public String date { get; set; }
        public int price { get; set; }
        public String adText { get; set; }
        public String mail { get; set; }
    }

    public class Course
    {
        public String cCode { get; set; }
        public String cName { get; set; }
    }

    public class Inst
    {
        public String instName { get; set; }
    }
}
