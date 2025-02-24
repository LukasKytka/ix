// Ix.ConnectorTests
// Copyright (c) 2023 Peter Kurhajec (PTKu), MTS,  and Contributors. All Rights Reserved.
// Contributors: https://github.com/ix-ax/ix/graphs/contributors
// See the LICENSE file in the repository root for more information.
// https://github.com/ix-ax/ix/blob/master/LICENSE
// Third party licenses: https://github.com/ix-ax/ix/blob/master/notices.md

using Xunit;
using Ix.Connector;
using Newtonsoft.Json.Serialization;

namespace Ix.Connector.Tests
{
    using Ix.Connector;
    using System;
    using Xunit;
    using NSubstitute;
    using System.Collections.Generic;
    using Ix.Connector.ValueTypes;
    using System.Threading.Tasks;

    public static class TwinObjectExtensionsTests
    {
        [Fact]
        public static void CanCallMakePrimitiveReadOnly()
        {
            // Arrange
            var structure = Substitute.For<ITwinPrimitive>();

            // Act
            structure.MakeReadOnly();

            // Assert
            Assert.Equal(ReadWriteAccess.Read, structure.ReadWriteAccess);
        }

        [Fact]
        public static void CanCallMakeTwinObjectReadOnly()
        {
            // Arrange
            var structure = Substitute.For<ITwinObject>();
            var primitive1 = Substitute.For<ITwinPrimitive>();
            structure.AddValueTag(primitive1);

            // Act
            structure.MakeReadOnly();

            // Assert
            Assert.Equal(ReadWriteAccess.Read, primitive1.ReadWriteAccess);
        }


        [Fact]
        public static void CanCallMakeTwinObjectRecursivelyReadOnly()
        {
            // Arrange
            var structure = Substitute.For<ITwinObject>();
            structure.GetChildren().Returns(new[] { Substitute.For<ITwinObject>() });
            structure.GetChildren().First().GetValueTags().Returns(new[] { Substitute.For<ITwinPrimitive>() });
            var primitive1 = Substitute.For<ITwinPrimitive>();
            structure.AddValueTag(primitive1);

            // Act
            structure.MakeReadOnly();

            // Assert
            Assert.Equal(ReadWriteAccess.Read, primitive1.ReadWriteAccess);
            Assert.Equal(ReadWriteAccess.Read, structure.GetChildren().First().GetValueTags().First().ReadWriteAccess);
        }

        [Fact]
        public static void CanCallMakeTwinPrimitiveReadOnly()
        {
            // Arrange

            var primitive1 = Substitute.For<ITwinPrimitive>();

            // Act
            primitive1.MakeReadOnly();

            // Assert
            Assert.Equal(ReadWriteAccess.Read, primitive1.ReadWriteAccess);
        }

        [Fact]
        public static void CannotCallMakeReadOnlyWithNullStructure()
        {
            Assert.Throws<ArgumentNullException>(() => default(ITwinObject).MakeReadOnly());
        }

        [Fact]
        public static async Task CanCallReadAsync()
        {
            // Arrange
            var structure = Substitute.For<ITwinObject>();
            structure.GetConnector().Returns(Substitute.For<DummyConnector>());

            var primitive = Substitute.For<OnlinerBool>();
            structure.AddValueTag(primitive);

            // Act
            await structure.ReadAsync();

            // Assert

            structure.GetConnector().Received().ReadBatchAsync(structure.Received().RetrievePrimitives());
        }

        [Fact]
        public static async Task CannotCallReadAsyncWithNullStructure()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => default(ITwinObject).ReadAsync());
        }

        [Fact]
        public static async Task CanCallWriteAsync()
        {
            // Arrange
            var structure = Substitute.For<ITwinObject>();
            structure.GetConnector().Returns(Substitute.For<DummyConnector>());
            structure.GetValueTags().Returns(new[] { Substitute.For<ITwinPrimitive>(), Substitute.For<ITwinPrimitive>() });
            structure.GetChildren().Returns(new[] { Substitute.For<ITwinObject>() });
            structure.GetChildren().First().GetValueTags().Returns(new[] { Substitute.For<ITwinPrimitive>(), Substitute.For<ITwinPrimitive>() });


            // Act
            var primitives = await structure.WriteAsync();

            // Assert
            structure.Received().WriteAsync();
        }

        [Fact]
        public static async Task CannotCallWriteAsyncWithNullStructure()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => default(ITwinObject).WriteAsync());
        }

        [Fact]
        public static void CanCallRetrieveValueTags()
        {
            // Arrange
            var onlineObject = Substitute.For<ITwinObject>();
            var nestedOnlineObject = Substitute.For<ITwinObject>();

            onlineObject.GetChildren().Returns(new[] { nestedOnlineObject });
            onlineObject.GetValueTags().Returns(new[] { Substitute.For<ITwinPrimitive>(), Substitute.For<ITwinPrimitive>(), Substitute.For<ITwinPrimitive>() });
            nestedOnlineObject.GetValueTags().Returns(new[] { Substitute.For<ITwinPrimitive>(), Substitute.For<ITwinPrimitive>() });

            var valueTags = new List<ITwinPrimitive>();

            // Act
            var result = onlineObject.RetrievePrimitives(valueTags);

            // Assert
            Assert.Equal(5, result.Count());
        }

        [Fact]
        public static void CannotCallRetrieveValueTagsWithNullOnlineObject()
        {
            Assert.Throws<ArgumentNullException>(() => default(ITwinObject).RetrievePrimitives(new List<ITwinPrimitive>()));
        }

        [Fact]
        public static void CanCallSubscribeShadowValueChange()
        {


            var obj = Substitute.For<ITwinObject>();
            obj.GetValueTags().Returns(new[] { Substitute.For<ITwinPrimitive>(), Substitute.For<ITwinPrimitive>() });
            obj.GetChildren().Returns(new[] { Substitute.For<ITwinObject>() });
            obj.GetChildren().First().GetValueTags().Returns(new[] { Substitute.For<ITwinPrimitive>(), Substitute.For<ITwinPrimitive>() });
            OnlinerBase.ValueChangeDelegate valueChangeDelegate = (x, y, z) => { };

            // Act
            var subscribed = obj.SubscribeShadowValueChange(valueChangeDelegate);

            // Assert
            Assert.Equal(4, subscribed.Count());

            foreach (var subforedit in subscribed)
            {
                Assert.Equal(1, subforedit.ShadowValueChange.GetInvocationList().Length);
            }
        }

        [Fact]
        public static void CannotCallSubscribeShadowValueChangeWithNullObj()
        {
            Assert.Throws<ArgumentNullException>(() => default(ITwinObject).SubscribeShadowValueChange((x, y, z) => { }));
        }

        [Fact]
        public static void CannotCallSubscribeShadowValueChangeWithNullValueChangeDelegate()
        {
            Assert.Throws<ArgumentNullException>(() => Substitute.For<ITwinObject>().SubscribeShadowValueChange(default(OnlinerBase.ValueChangeDelegate)));
        }

        [Fact]
        public static void CanCallUnSubscribeShadowValueChange()
        {

            var obj = Substitute.For<ITwinObject>();
            obj.GetValueTags().Returns(new[] { Substitute.For<ITwinPrimitive>(), Substitute.For<ITwinPrimitive>() });
            obj.GetChildren().Returns(new[] { Substitute.For<ITwinObject>() });
            obj.GetChildren().First().GetValueTags().Returns(new[] { Substitute.For<ITwinPrimitive>(), Substitute.For<ITwinPrimitive>() });
            OnlinerBase.ValueChangeDelegate valueChangeDelegate = (x, y, z) => { };

            // Act
            var subscribed = obj.SubscribeShadowValueChange(valueChangeDelegate);

            // Assert
            Assert.Equal(4, subscribed.Count());

            foreach (var subforedit in subscribed)
            {
                Assert.Equal(1, subforedit.ShadowValueChange.GetInvocationList().Length);
            }

            // Act
            obj.UnSubscribeShadowValueChange();

            // Assert
            foreach (var subforedit in subscribed)
            {
                Assert.Null(subforedit.ShadowValueChange);
            }
        }

        [Fact]
        public static void CannotCallUnSubscribeShadowValueChangeWithNullObj()
        {
            Assert.Throws<ArgumentNullException>(() => default(ITwinObject).UnSubscribeShadowValueChange());
        }

        [Fact]
        public static void CanCallSubscribeEditValueChange()
        {
            // Arrange
            var obj = Substitute.For<ITwinObject>();
            obj.GetValueTags().Returns(new[] { Substitute.For<ITwinPrimitive>(), Substitute.For<ITwinPrimitive>() });
            obj.GetChildren().Returns(new[] { Substitute.For<ITwinObject>() });
            obj.GetChildren().First().GetValueTags().Returns(new[] { Substitute.For<ITwinPrimitive>(), Substitute.For<ITwinPrimitive>() });
            OnlinerBase.ValueChangeDelegate valueChangeDelegate = (x, y, z) => { };

            // Act
            var subscribed = obj.SubscribeEditValueChange(valueChangeDelegate);

            // Assert
            Assert.Equal(4, subscribed.Count());

            foreach (var subforedit in subscribed)
            {
                Assert.Equal(1, subforedit.EditValueChange.GetInvocationList().Length);
            }
        }

        [Fact]
        public static void CannotCallSubscribeEditValueChangeWithNullObj()
        {
            Assert.Throws<ArgumentNullException>(() => default(ITwinObject).SubscribeEditValueChange((x, y, z) => { }));
        }

        [Fact]
        public static void CannotCallSubscribeEditValueChangeWithNullValueChangeDelegate()
        {
            Assert.Throws<ArgumentNullException>(() => Substitute.For<ITwinObject>().SubscribeEditValueChange(default(OnlinerBase.ValueChangeDelegate)));
        }

        [Fact]
        public static void CanCallUnSubscribeEditValueChange()
        {
            var obj = Substitute.For<ITwinObject>();
            obj.GetValueTags().Returns(new[] { Substitute.For<ITwinPrimitive>(), Substitute.For<ITwinPrimitive>() });
            obj.GetChildren().Returns(new[] { Substitute.For<ITwinObject>() });
            obj.GetChildren().First().GetValueTags().Returns(new[] { Substitute.For<ITwinPrimitive>(), Substitute.For<ITwinPrimitive>() });
            OnlinerBase.ValueChangeDelegate valueChangeDelegate = (x, y, z) => { };

            // Act
            var subscribed = obj.SubscribeShadowValueChange(valueChangeDelegate);

            // Assert
            Assert.Equal(4, subscribed.Count());

            foreach (var subforedit in subscribed)
            {
                Assert.Equal(1, subforedit.EditValueChange.GetInvocationList().Length);
            }


            // Act
            obj.UnSubscribeEditValueChange();

            // Assert
            foreach (var subforedit in subscribed)
            {
                Assert.Null(subforedit.EditValueChange);
            }
        }

        [Fact]
        public static void CannotCallUnSubscribeEditValueChangeWithNullObj()
        {
            Assert.Throws<ArgumentNullException>(() => default(ITwinObject).UnSubscribeEditValueChange());
        }

        [Fact()]
        public static void CanCallMakeReadOnce()
        {
            var obj = Substitute.For<ITwinObject>();
            obj.GetValueTags().Returns(new[] { Substitute.For<ITwinPrimitive>(), Substitute.For<ITwinPrimitive>() });
            obj.GetChildren().Returns(new[] { Substitute.For<ITwinObject>() });
            obj.GetChildren().First().GetValueTags().Returns(new[] { Substitute.For<ITwinPrimitive>(), Substitute.For<ITwinPrimitive>() });

            obj.MakeReadOnce();
        }

        [Fact]
        public static void CannotCallMakeReadOnceWithNullStructure()
        {
            Assert.Throws<ArgumentNullException>(() => default(ITwinObject).MakeReadOnce());
        }
    }
}