using System;
using System.Collections.Generic;
using System.Linq;
using CardDB;
using Repository.Models;

namespace Repository
{
    public class CardRepository
    {
        public CardRepoModel Add(CardRepoModel cardModel)
        {

            // Convert the repository model to the database model
            var cardDb = ToDbModel(cardModel);

            // database manager connection
            DatabaseManager.Instance.Card.Add(cardDb);
            DatabaseManager.Instance.SaveChanges();

            cardModel = new CardRepoModel
            {
                CardID = cardDb.CardID
            };
            return cardModel;
        }


        // gets the entire records and map to the repository model
        public List<CardRepoModel> GetAll()
        {
            // Use .Select() to map the database cards to CardRepoModel
            var items = DatabaseManager.Instance.Card
              .Select(t => new CardRepoModel
              {
                  CardID = t.CardID,
                  Title = t.Title,
                  CardNumber = t.CardNumber,
                  CardCount = t.CardCount,
                  Notes = t.Notes,
                  Value = t.Value,
                  ReleaseYear = t.ReleaseYear,
                  CardCondition = t.CardCondition,
                  TypeOfCard = t.TypeOfCard,
                  CardFranchise = t.CardFranchise,
                  Image = t.Image
              }).ToList();

            return items;
        }

        public bool Update(CardRepoModel cardModel)
        {
            var original = DatabaseManager.Instance.Card.Find(cardModel.CardID);

            if (original != null)
            {
                DatabaseManager.Instance.Entry(original).CurrentValues.SetValues(ToDbModel(cardModel));
                DatabaseManager.Instance.SaveChanges();
                return true;
            }

            return false;
        }

        public bool Remove(int cardId)
        {
            var items = DatabaseManager.Instance.Card
                                .Where(t => t.CardID == cardId);

            if (items.Count() == 0)
            {
                return false;
            }

            DatabaseManager.Instance.Card.Remove(items.First());
            DatabaseManager.Instance.SaveChanges();

            return true;
        }

        private CardDBModel ToDbModel(CardRepoModel Card)
        {
            var cardDb = new CardDBModel
            {
                CardID = Card.CardID,
                Title = Card.Title,
                CardNumber = Card.CardNumber,
                CardCount = Card.CardCount,
                Notes = Card.Notes,
                Value = Card.Value,
                ReleaseYear = Card.ReleaseYear,
                TypeOfCard = Card.TypeOfCard,
                CardCondition = Card.CardCondition,
                CardFranchise = Card.CardFranchise,
                Image = Card.Image
            };

            return cardDb;
        }
    }
}
