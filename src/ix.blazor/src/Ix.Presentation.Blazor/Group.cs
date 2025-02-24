﻿// Ix.Presentation.Blazor
// Copyright (c) 2023 Peter Kurhajec (PTKu), MTS,  and Contributors. All Rights Reserved.
// Contributors: https://github.com/ix-ax/ix/graphs/contributors
// See the LICENSE file in the repository root for more information.
// https://github.com/ix-ax/ix/blob/master/LICENSE
// Third party licenses: https://github.com/ix-ax/ix/blob/master/notices.md

using System;
using System.Collections.Generic;
using System.Text;
using Ix.Connector;

namespace Ix.Presentation.Blazor
{
    /// <summary>
    ///  Class containing list of grouped elements by layout.
    /// </summary>

   
 
    public class Group
    {
       
        public Group(Type _parentLayout,Type _groupLayout, string _groupName)
        {
            ParentLayout = _parentLayout;
            GroupLayout = _groupLayout;
            GroupName = _groupName;
        }
        public Type GroupLayout { get; set; }
        public Type ParentLayout { get; set; }
        public string GroupName { get; set; }


        public List<ITwinElement> GroupElements { get; set; } = new List<ITwinElement>();
    }
}
