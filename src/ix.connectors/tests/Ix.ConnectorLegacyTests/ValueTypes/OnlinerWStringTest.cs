﻿// Ix.ConnectorLegacyTests
// Copyright (c) 2023 Peter Kurhajec (PTKu), MTS,  and Contributors. All Rights Reserved.
// Contributors: https://github.com/ix-ax/ix/graphs/contributors
// See the LICENSE file in the repository root for more information.
// https://github.com/ix-ax/ix/blob/master/LICENSE
// Third party licenses: https://github.com/ix-ax/ix/blob/master/notices.md

namespace Ix.Connector.Onliners.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using Ix.Connector.Tests;
    using Ix.Connector.ValueTypes;

    public class OnlinerWStringTest : OnlinerBaseTests<string>
    {
        protected override OnlinerBase<string> Onliner { get; set; }


        public override void Init()
        {
            Onliner = new OnlinerWString(new TestTwinObject(), $"readableTail", "symbolTail");
        }

        [Test()]
        public void ChangeEditedValueTest()
        {
            //-- Arrange

            var expected = "43ojtopgwj05tu*SE*DF:5┘>1Ç.ÞYF";

            //-- Act
            Onliner.Edit = expected;

            //-- Assert
            Assert.AreEqual(expected, Onliner.GetAsync().Result);
            Assert.AreEqual($"Edit of {Onliner.Symbol};{Onliner.HumanReadable};;{expected}", logs);

        }

        [Test()]
        public void ChangeShadow()
        {
            //-- Arrange

            var expected = "43ojtopgwj05tu*SE*DF:5┘>1Ç.ÞYF";

            //-- Act
            Onliner.Shadow = expected;

            //-- Assert
            Assert.AreEqual(expected, Onliner.Shadow);
            Assert.AreEqual($"Shadow of {Onliner.Symbol};{Onliner.HumanReadable};;{expected}", logs);
        }

        [Test]
        public override void CanSetAsyncTest()
        {
            var expected = "some wstring";
            Onliner.SetAsync(expected).Wait();

            Assert.AreEqual(expected, Onliner.GetAsync().Result);
        }
    }
}