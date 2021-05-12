using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;

namespace Homework4.Models
{
    class ZipCode : IDataErrorInfo, INotifyPropertyChanged
    {
        private string postcode;

        public ZipCode()
        {
            ButtonState = false;
        }

        bool buttonState = false;
        public bool ButtonState 
        {
            get
            {
                return buttonState;
            }

            set
            {
                 buttonState = value;
                 OnPropertyChanged("ButtonState");
            }
        }

        public string this[string columnName]
        {
            get
            {
                bool ZipIsGood = false;
                Regex regexZipCode = new Regex(@"^[0-9]{5}(?:-[0-9]{4})?$");
                Regex regexPostCode = new Regex(@"^(?!.*[DFIOQU])[A-VXY][0-9][A-Z]●?[0-9][A-Z][0-9]$");
                switch (columnName)
                {
                    case "PostCode":
                        {
                            if (string.IsNullOrEmpty(PostCode) == false)
                            {
                                ZipIsGood = regexZipCode.IsMatch(PostCode) | regexPostCode.IsMatch(PostCode);
                            }
                            break;
                        }
                }

                ButtonState = ZipIsGood;
                return "zip";
            }
        }

        public string Error { get; set; }

        public string PostCode 
        { 
            get
            {
                return postcode;
            }

            set
            {
                if (postcode != value)
                {
                    postcode = value;
                    OnPropertyChanged("PostCode");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
