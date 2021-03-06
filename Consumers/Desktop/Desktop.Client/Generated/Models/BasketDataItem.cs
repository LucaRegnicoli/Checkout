﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.16.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Desktop.Client.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;

    public partial class BasketDataItem
    {
        /// <summary>
        /// Initializes a new instance of the BasketDataItem class.
        /// </summary>
        public BasketDataItem() { }

        /// <summary>
        /// Initializes a new instance of the BasketDataItem class.
        /// </summary>
        public BasketDataItem(string id = default(string), string productId = default(string), string productName = default(string), double? unitPrice = default(double?), int? quantity = default(int?), string pictureUrl = default(string))
        {
            Id = id;
            ProductId = productId;
            ProductName = productName;
            UnitPrice = unitPrice;
            Quantity = quantity;
            PictureUrl = pictureUrl;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "productId")]
        public string ProductId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "productName")]
        public string ProductName { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "unitPrice")]
        public double? UnitPrice { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "quantity")]
        public int? Quantity { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "pictureUrl")]
        public string PictureUrl { get; set; }

    }
}
