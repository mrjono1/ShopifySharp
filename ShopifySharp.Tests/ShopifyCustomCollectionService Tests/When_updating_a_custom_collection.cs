﻿using Machine.Specifications;
using System;

namespace ShopifySharp.Tests.ShopifyCustomCollectionService_Tests
{
    [Subject(typeof(ShopifyCustomCollectionService))]
    public class When_updating_a_custom_collection
    {
        Establish context = () =>
        {
            Service = new ShopifyCustomCollectionService(Utils.MyShopifyUrl, Utils.AccessToken);
            Collection = Service.CreateAsync(SubjectUtils.CreateValidObject()).Await().AsTask.Result;

            Collection.Title = "My New Collection Title";
        };

        Because of = () =>
        {
            Collection = Service.UpdateAsync(Collection).Await().AsTask.Result;
        };

        It should_update_a_custom_collection = () =>
        {
            Collection.ShouldNotBeNull();
            Collection.Title.ShouldEqual("My New Collection Title");
        };

        Cleanup after = () =>
        {
            Service.DeleteAsync(Collection.Id.Value).Await();
        };

        static ShopifyCustomCollectionService Service;

        static ShopifyCustomCollection Collection;
    }
}
