﻿// Ix.Abstractions
// Copyright (c) 2023 Peter Kurhajec (PTKu), MTS,  and Contributors. All Rights Reserved.
// Contributors: https://github.com/ix-ax/ix/graphs/contributors
// See the LICENSE file in the repository root for more information.
// https://github.com/ix-ax/ix/blob/master/LICENSE
// Third party licenses: https://github.com/ix-ax/ix/blob/master/notices.md

using System;
using System.Collections.Generic;
using System.Text;

namespace Ix.Abstractions.Presentation
{
    public class PresentationProvider  
    {
        private PresentationProvider(ILayoutProvider layoutProvider)
        {
            LayoutProvider = layoutProvider;
        }

        public ILayoutProvider LayoutProvider
        {
            get;
        }

        private static readonly PresentationProvider emptyPresentationProvider = new PresentationProvider(new EmptyPresentationProvider());

        private static PresentationProvider provider;
        private static volatile object mutex = new object();
        public static PresentationProvider Get
        {
            get
            {
                if (provider == null)
                {
                    return emptyPresentationProvider;
                }

                return provider;

            }
        }

        public static PresentationProvider Create(ILayoutProvider layoutProvider)
        {
            if (provider == null)
            {
                lock (mutex)
                {
                    if (provider == null)
                    {
                        provider = new PresentationProvider(layoutProvider);
                    }
                }
            }

            return provider;
        }
        
    }
}
