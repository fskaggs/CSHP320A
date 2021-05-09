using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Homework4.Models
{
    class ZipCode : IDataErrorInfo
    {
        public string this[string columnName]
        {
            get
            {
                return "ZipCode";
            }
        }

        public string Error { get; set; }

        public string PostCode { get; set; }
    }
}
