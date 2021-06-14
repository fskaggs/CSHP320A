﻿using Repository.Models;
using System;
using System.ComponentModel;
using SharedComponents;

namespace TradingCardTracker.Models
{
    public class CardModel : CardDTO, ICloneable, IDataErrorInfo, INotifyPropertyChanged
    {
        public string Error => throw new NotImplementedException();

        public event PropertyChangedEventHandler PropertyChanged;

        private void InvokePropertyChanged(string PropertyName)
        {
            PropertyChangedEventArgs e = new PropertyChangedEventArgs(PropertyName);
            PropertyChangedEventHandler propertyChangedEventHandler = PropertyChanged;
            if (propertyChangedEventHandler != null)
            {
                PropertyChanged(this, e);
            }
        }

        string titleError;
        public string TitleError 
        {
            get { return titleError; } 
            set
            {
                if (titleError != value)
                {
                    titleError = value;
                    InvokePropertyChanged("TitleError");
                }
            }
        }

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case "Title":
                        {
                            TitleError = string.Empty;
                            if (Title == null || string.IsNullOrEmpty(Title)) { TitleError = "Title cannot be empty"; }
                            return TitleError;
                        }
                }

                return string.Empty;
            }
        }

        public static CardRepoModel ToRepositoryModel(CardModel Card)
        {
            return new CardRepoModel()
            {
                CardID = Card.CardID,
                Title = Card.Title,
                CardNumber = Card.CardNumber,
                CardCount = Card.CardCount,
                Notes = Card.Notes,
                Value = Card.Value,
                ReleaseYear = Card.ReleaseYear,
                CardCondition = Card.CardCondition,
                TypeOfCard = Card.TypeOfCard
            };
        }

        public static CardModel ToModel(CardRepoModel Card)
        {
            return new CardModel()
                        {
                            CardID = Card.CardID,
                            Title = Card.Title,
                            CardNumber = Card.CardNumber,
                            CardCount = Card.CardCount,
                            Notes = Card.Notes,
                            Value = Card.Value,
                            ReleaseYear = Card.ReleaseYear,
                            CardCondition = Card.CardCondition,
                            TypeOfCard = Card.TypeOfCard
            };
        }

        public object Clone()
        {
            CardModel clone = new CardModel()
            {
                CardID = this.CardID,
                Title = this.Title,
                CardNumber = this.CardNumber,
                CardCount = this.CardCount,
                Notes = this.Notes,
                Value = this.Value,
                ReleaseYear = this.ReleaseYear,
                CardCondition = this.CardCondition,
                TypeOfCard = this.TypeOfCard
            };
            return clone;
        }
    }
}
