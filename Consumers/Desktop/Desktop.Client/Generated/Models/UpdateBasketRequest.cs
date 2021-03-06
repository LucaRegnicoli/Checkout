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

    public partial class UpdateBasketRequest
    {
        /// <summary>
        /// Initializes a new instance of the UpdateBasketRequest class.
        /// </summary>
        public UpdateBasketRequest() { }

        /// <summary>
        /// Initializes a new instance of the UpdateBasketRequest class.
        /// </summary>
        public UpdateBasketRequest(string customerId = default(string), IList<UpdateBasketRequestItemData> items = default(IList<UpdateBasketRequestItemData>))
        {
            CustomerId = customerId;
            Items = items;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "customerId")]
        public string CustomerId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "items")]
        public IList<UpdateBasketRequestItemData> Items { get; set; }

    }
}
