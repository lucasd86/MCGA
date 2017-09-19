//====================================================================================================
// Base code generated with LeatherGoods - ASF.Services.Contracts
// Architecture Solutions Foundation
//
// Generated by academic at LeatherGoods V 1.0 
//====================================================================================================

using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ASF.Entities;


namespace ASF.Services.Contracts
{
    
    [DataContract]
    public class FindResponse
    {
        [DataMember]
        public Cart CartResult { get; set; }
        [DataMember]
        public CartItem CartItemResult { get; set; }
        [DataMember]
        public Category CategoryResult { get; set; }
        [DataMember]
        public Client ClientResult { get; set; } 
        [DataMember]
        public Country CountryResult { get; set; }
        [DataMember]
        public Dealer DealerResult { get; set; }
        [DataMember]
        public Order OrderResult { get; set; }
        [DataMember]
        public OrderDetail OrderDetailResult { get; set; }
        [DataMember]
        public OrderNumber OrderNumberResult { get; set; }
        [DataMember]
        public Product ProductResult { get; set; }
        [DataMember]
        public Rating RatingResult { get; set; }
        [DataMember]
        public Setting SettingResult { get; set; }

    }
}

