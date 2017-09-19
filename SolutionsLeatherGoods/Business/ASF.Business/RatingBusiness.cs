
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ASF.Entities;
using ASF.Data;

namespace ASF.Business
{
    public class RatingBusiness
    {

        
        public Rating Add(Rating rating)
        {
            var ratingDac = new RatingDAC();
            return ratingDac.Create(rating);
        }

        public void Remove(int id)
        {
            var ratingDac = new RatingDAC();
            ratingDac.DeleteById(id);
        }

      
        public List<Rating> All()
        {
            var ratingDac = new RatingDAC();
            var result = ratingDac.Select();
            return result;
        }

       
        public Rating Find(int id)
        {
            var ratingDac = new RatingDAC();
            var result = ratingDac.SelectById(id);
            return result;
        }

       
        public void Edit(Rating rating)
        {
            var ratingDac = new RatingDAC();
            ratingDac.UpdateById(rating);
        }

    }
}