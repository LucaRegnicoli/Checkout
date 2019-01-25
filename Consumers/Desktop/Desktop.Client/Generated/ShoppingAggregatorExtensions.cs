﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.16.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Desktop.Client
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Models;

    /// <summary>
    /// Extension methods for ShoppingAggregator.
    /// </summary>
    internal static partial class ShoppingAggregatorExtensions
    {
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static void Get(this IShoppingAggregator operations)
            {
                Task.Factory.StartNew(s => ((IShoppingAggregator)s).GetAsync(), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task GetAsync(this IShoppingAggregator operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.GetWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false);
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='data'>
            /// </param>
            public static BasketData ApiV1ShoppingPut(this IShoppingAggregator operations, UpdateBasketRequest data = default(UpdateBasketRequest))
            {
                return Task.Factory.StartNew(s => ((IShoppingAggregator)s).ApiV1ShoppingPutAsync(data), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='data'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<BasketData> ApiV1ShoppingPutAsync(this IShoppingAggregator operations, UpdateBasketRequest data = default(UpdateBasketRequest), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ApiV1ShoppingPutWithHttpMessagesAsync(data, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='data'>
            /// </param>
            public static BasketData ApiV1ShoppingPost(this IShoppingAggregator operations, UpdateBasketRequest data = default(UpdateBasketRequest))
            {
                return Task.Factory.StartNew(s => ((IShoppingAggregator)s).ApiV1ShoppingPostAsync(data), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='data'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<BasketData> ApiV1ShoppingPostAsync(this IShoppingAggregator operations, UpdateBasketRequest data = default(UpdateBasketRequest), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ApiV1ShoppingPostWithHttpMessagesAsync(data, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='data'>
            /// </param>
            public static BasketData ApiV1ShoppingItemsPut(this IShoppingAggregator operations, UpdateBasketItemsRequest data = default(UpdateBasketItemsRequest))
            {
                return Task.Factory.StartNew(s => ((IShoppingAggregator)s).ApiV1ShoppingItemsPutAsync(data), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='data'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<BasketData> ApiV1ShoppingItemsPutAsync(this IShoppingAggregator operations, UpdateBasketItemsRequest data = default(UpdateBasketItemsRequest), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ApiV1ShoppingItemsPutWithHttpMessagesAsync(data, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='data'>
            /// </param>
            public static void ApiV1ShoppingItemsPost(this IShoppingAggregator operations, AddBasketItemRequest data = default(AddBasketItemRequest))
            {
                Task.Factory.StartNew(s => ((IShoppingAggregator)s).ApiV1ShoppingItemsPostAsync(data), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='data'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task ApiV1ShoppingItemsPostAsync(this IShoppingAggregator operations, AddBasketItemRequest data = default(AddBasketItemRequest), CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.ApiV1ShoppingItemsPostWithHttpMessagesAsync(data, null, cancellationToken).ConfigureAwait(false);
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            public static void ApiV1ShoppingByIdDelete(this IShoppingAggregator operations, string id)
            {
                Task.Factory.StartNew(s => ((IShoppingAggregator)s).ApiV1ShoppingByIdDeleteAsync(id), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task ApiV1ShoppingByIdDeleteAsync(this IShoppingAggregator operations, string id, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.ApiV1ShoppingByIdDeleteWithHttpMessagesAsync(id, null, cancellationToken).ConfigureAwait(false);
            }

    }
}