﻿// Ix.RenderableContent.Tests
// Copyright (c) 2023 Peter Kurhajec (PTKu), MTS,  and Contributors. All Rights Reserved.
// Contributors: https://github.com/ix-ax/ix/graphs/contributors
// See the LICENSE file in the repository root for more information.
// https://github.com/ix-ax/ix/blob/master/LICENSE
// Third party licenses: https://github.com/ix-ax/ix/blob/master/notices.md

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using ax_blazor_example;
using Ix.Connector;
using Ix.Presentation.Blazor.Services;
using Ix.Presentation.Blazor.Controls.RenderableContent;

namespace Ix.RenderableContent.Tests
{
    public class RenderableContentTestsFixture 
    {
        public RenderableContentTestsFixture()
        {
            Connector = new ax_blazor_exampleTwinController(new ConnectorAdapter(typeof(DummyConnectorFactory)), null);
            RenderableContent = new RenderableContentControl();
            RenderableContent.ComponentService = new ComponentService();
            RenderableContent.AttributesHandler = new AttributesHandler();
            RenderableContent.ComponentService.LoadComponents();

        }
        public ax_blazor_exampleTwinController Connector { get; set; }
        public RenderableContentControl RenderableContent { get; set; }

        
    }
}
